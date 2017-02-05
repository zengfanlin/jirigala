//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd.
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.ServiceModel;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// FileService
    /// 文件服务
    /// 
    /// 修改纪录
    /// 
    ///		2008.04.30 版本：1.0 JiRiGaLa 创建。
    ///	
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.04.30</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class FileService : System.MarshalByRefObject, IFileService
    {
        private string serviceName = AppMessage.FileService;

        /// <summary>
        /// 用户中心数据库连接
        /// </summary>
        private readonly string UserCenterDbConnection = BaseSystemInfo.UserCenterDbConnection;

        #region public string Send(BaseUserInfo userInfo, string fileName, byte[] file, string toUserId)
        /// <summary>
        /// 发送文件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="fileName">文件名</param>
        /// <param name="file">文件内容</param>
        /// <param name="toUserId">发送给谁主键</param>
        /// <returns>文件主键</returns>
        public string Send(BaseUserInfo userInfo, string fileName, byte[] file, string toUserId)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            string returnValue = string.Empty;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseFolderEntity folderEntity = new BaseFolderEntity();
                    BaseFolderManager folderManager = new BaseFolderManager(dbHelper, userInfo);
                    // 检查相应的系统必备文件夹
                    folderManager.FolderCheck();
                    BaseUserEntity userEntity = new BaseUserManager(dbHelper, userInfo).GetEntity(toUserId);
                    if (!string.IsNullOrEmpty(userEntity.Id))
                    {
                        // 04:判断发送者的空间是否存在？
                        // 05:判断已收文件夹是否存在？
                        if (!folderManager.Exists(userEntity.Id.ToString()))
                        {
                            folderEntity.FolderName = userEntity.RealName + AppMessage.FileService_File;
                            folderEntity.ParentId = "UserSpace";
                            folderEntity.Id = userEntity.Id.ToString();
                            folderEntity.Enabled = 1;
                            folderEntity.DeletionStateCode = 0;
                            folderManager.AddEntity(folderEntity);
                        }
                        // 06:判断来自谁的文件夹是否存在？
                        // 07:判断发给谁的文件夹是否存在？
                        if (!folderManager.Exists(toUserId + "_Receive"))
                        {
                            folderEntity.FolderName = AppMessage.FileService_ReceiveFile;
                            folderEntity.ParentId = toUserId;
                            folderEntity.Id = toUserId + "_Receive";
                            folderEntity.Enabled = 1;
                            folderEntity.DeletionStateCode = 0;
                            folderManager.AddEntity(folderEntity);
                        }
                        if (!folderManager.Exists(userInfo.Id + "_Send_" + toUserId))
                        {
                            folderEntity.FolderName = userEntity.RealName + "(" + userEntity.UserName + ")";
                            folderEntity.ParentId = userInfo.Id + "_Send";
                            folderEntity.Id = userInfo.Id + "_Send_" + toUserId;
                            folderEntity.Enabled = 1;
                            folderEntity.DeletionStateCode = 0;
                            folderManager.AddEntity(folderEntity);
                        }
                        if (!folderManager.Exists(toUserId + "_Receive_" + userInfo.Id))
                        {
                            folderEntity.FolderName = userInfo.RealName + "(" + userInfo.UserName + ")";
                            folderEntity.ParentId = toUserId + "_Receive";
                            folderEntity.Id = toUserId + "_Receive_" + userInfo.Id;
                            folderEntity.Enabled = 1;
                            folderEntity.DeletionStateCode = 0;
                            folderManager.AddEntity(folderEntity);
                        }
                        // 08:已发送文件夹多一个文件。
                        // 09:已接收文件夹多一个文件。
                        BaseFileEntity fileEntity = new BaseFileEntity();
                        fileEntity.FileName = fileName;
                        fileEntity.Contents = file;
                        fileEntity.Enabled = 1;
                        fileEntity.ReadCount = 0;
                        fileEntity.FolderId = userInfo.Id + "_Send_" + toUserId;
                        // 把修改人显示出来
                        fileEntity.ModifiedBy = userInfo.RealName;
                        fileEntity.ModifiedUserId = userInfo.Id;
                        fileEntity.ModifiedOn = DateTime.Now;
                        BaseFileManager fileManager = new BaseFileManager(dbHelper, userInfo);
                        fileManager.AddEntity(fileEntity);
                        fileEntity.FolderId = toUserId + "_Receive_" + userInfo.Id;
                        returnValue = fileManager.AddEntity(fileEntity);
                        // string webHostUrl = BaseSystemInfo.WebHostUrl;
                        // if (string.IsNullOrEmpty(webHostUrl))
                        // {
                        //    webHostUrl = "WebHostUrl";
                        // }
                        // 10:应该还发一个短信提醒一下才对。
                        BaseMessageEntity messageEntity = new BaseMessageEntity();
                        messageEntity.Id = Guid.NewGuid().ToString();
                        messageEntity.CategoryCode = MessageCategory.Send.ToString();
                        messageEntity.FunctionCode = MessageFunction.Message.ToString();
                        messageEntity.ObjectId = returnValue;
                        messageEntity.ReceiverId = toUserId;
                        // target=\"_blank\"
                        messageEntity.Contents = AppMessage.FileService_SendFileFrom + " <a href={WebHostUrl}Download.aspx?Id=" + returnValue + ">" + fileName + "</a>" + AppMessage.FileService_CheckReceiveFile;
                        messageEntity.IsNew = (int)MessageStateCode.New;
                        messageEntity.ReadCount = 0;
                        messageEntity.DeletionStateCode = 0;
                        messageEntity.Enabled = 1;
                        BaseMessageManager messageManager = new BaseMessageManager(dbHelper, userInfo);
                        returnValue = messageManager.Add(messageEntity);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif

            return returnValue;
        }
        #endregion

        #region public string Add(BaseUserInfo userInfo, string folderId, string fileName, byte[] file, string description, bool enabled, out string statusCode, out string statusMessage)
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="folderId">文件夹主键</param>
        /// <param name="fileName">文件名</param>
        /// <param name="file"></param>
        /// <param name="description"></param>
        /// <param name="enabled"></param>
        /// <param name="statusCode"></param>
        /// <param name="statusMessage"></param>
        /// <returns></returns>
        public string Add(BaseUserInfo userInfo, string folderId, string fileName, byte[] file, string description, bool enabled, out string statusCode, out string statusMessage)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            statusCode = string.Empty;
            statusMessage = string.Empty;

            string returnValue = string.Empty;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseFileManager fileManager = new BaseFileManager(dbHelper, userInfo);
                    returnValue = fileManager.Add(folderId, fileName, file, description, enabled, out statusCode);
                    statusMessage = fileManager.GetStateMessage(statusCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif

            return returnValue;
        }
        #endregion

        #region public BaseFileEntity GetEntity(BaseUserInfo userInfo, string id)
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        public BaseFileEntity GetEntity(BaseUserInfo userInfo, string id)
        {
            // 写入调试信息
#if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
#endif

            // 加强安全验证防止未授权匿名调用
#if (!DEBUG)
            LogOnService.UserIsLogOn(userInfo);
#endif

            BaseFileEntity fileEntity = null;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseFileManager fileManager = new BaseFileManager(dbHelper, userInfo);
                    fileEntity = fileManager.GetEntity(id);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.FileService_GetEntity, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
#if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
#endif

            return fileEntity;
        }
        #endregion

        #region public bool Exists(BaseUserInfo userInfo, string folderId, string fileName)
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="folderId">文件夹主键</param>
        /// <param name="fileName">文件名</param>
        /// <returns>存在</returns>
        public bool Exists(BaseUserInfo userInfo, string folderId, string fileName)
        {
            // 写入调试信息
#if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
#endif

            // 加强安全验证防止未授权匿名调用
#if (!DEBUG)
            LogOnService.UserIsLogOn(userInfo);
#endif

            bool returnValue = false;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseFileManager fileManager = new BaseFileManager(dbHelper, userInfo);
                    //returnValue = fileManager.Exists(new KeyValuePair<string, object>(BaseFileEntity.FieldFolderId, folderId), new KeyValuePair<string, object>(BaseFileEntity.FieldFileName, fileName));
                    //加入删除状态为0的条件
                    List<KeyValuePair<string, object>> parametersList = new List<KeyValuePair<string, object>>();
                    parametersList.Add(new KeyValuePair<string, object>(BaseFileEntity.FieldFolderId, folderId));
                    parametersList.Add(new KeyValuePair<string, object>(BaseFileEntity.FieldFileName, fileName));
                    parametersList.Add(new KeyValuePair<string, object>(BaseFileEntity.FieldDeletionStateCode, 0));
                    returnValue = fileManager.Exists(parametersList);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.FileService_Exists, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
#if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
#endif

            return returnValue;
        }
        #endregion

        #region public byte[] Download(BaseUserInfo userInfo, string id)
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>文件</returns>
        public byte[] Download(BaseUserInfo userInfo, string id)
        {
            // 写入调试信息
#if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
#endif

            // 加强安全验证防止未授权匿名调用
#if (!DEBUG)
            LogOnService.UserIsLogOn(userInfo);
#endif

            byte[] returnValue = null;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseFileManager fileManager = new BaseFileManager(dbHelper, userInfo);
                    returnValue = fileManager.Download(id);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.FileService_Download, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
#if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
#endif

            return returnValue;
        }
        #endregion

        #region public string Upload(BaseUserInfo userInfo, string folderId, string fileName, byte[] file, bool enabled)
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="folderId">文件夹主键</param>
        /// <param name="fileName">文件名</param>
        /// <param name="file">文件</param>
        /// <param name="enabled">有效</param>
        /// <returns>主键</returns>
        public string Upload(BaseUserInfo userInfo, string folderId, string fileName, byte[] file, bool enabled)
        {
            // 写入调试信息
#if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
#endif

            // 加强安全验证防止未授权匿名调用
#if (!DEBUG)
            LogOnService.UserIsLogOn(userInfo);
#endif

            string returnValue = string.Empty;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseFileManager fileManager = new BaseFileManager(dbHelper, userInfo);
                    returnValue = fileManager.Upload(folderId, fileName, file, enabled);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.FileService_Upload, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
#if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
#endif

            return returnValue;
        }
        #endregion

        #region public DataTable GetDataTableByFolder(BaseUserInfo userInfo, string folderId)
        /// <summary>
        /// 按文件夹获取文件列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="folderId">文件夹主键</param>
        /// <returns>列表</returns>
        public DataTable GetDataTableByFolder(BaseUserInfo userInfo, string folderId)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseFileEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseFileManager fileManager = new BaseFileManager(dbHelper, userInfo);
                    dataTable = fileManager.GetDataTableByFolder(folderId);
                    dataTable.TableName = BaseFolderEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.FileService_GetDataTableByFolder, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif

            return dataTable;
        }
        #endregion

        #region public DataTable GetDataTableByIds(BaseUserInfo userInfo, string[] ids)
        /// <summary>
        /// 按主键数组获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">组织机构主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByIds(BaseUserInfo userInfo, string[] ids)
        {
            // 写入调试信息
#if (DEBUG)
            int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
#endif

            // 加强安全验证防止未授权匿名调用
#if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
#endif

            DataTable dataTable = new DataTable(BaseFileEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseFileManager fileManager = new BaseFileManager(dbHelper, userInfo);
                    dataTable = fileManager.GetDataTable(BaseFileEntity.FieldId, ids, BaseFileEntity.FieldSortCode);
                    dataTable.TableName = BaseFileEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, serviceName, AppMessage.FileService_GetDataTableByIds, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
#if (DEBUG)
            BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
#endif

            return dataTable;
        }
        #endregion

        #region public int DeleteByFolder(BaseUserInfo userInfo, string folderId)
        /// <summary>
        /// 按文件夹删除文件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="folderId">文件夹主键</param>
        /// <returns>影响行数</returns>
        public int DeleteByFolder(BaseUserInfo userInfo, string folderId)
        {
            // 写入调试信息
#if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
#endif

            // 加强安全验证防止未授权匿名调用
#if (!DEBUG)
            LogOnService.UserIsLogOn(userInfo);
#endif

            int returnValue = 0;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseFileManager fileManager = new BaseFileManager(dbHelper, userInfo);
                    returnValue = fileManager.DeleteByFolder(folderId);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.FileService_DeleteByFolder, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
#if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
#endif

            return returnValue;
        }
        #endregion

        #region public int Update(BaseUserInfo userInfo, string id, string folderId, string fileName, string description, bool enabled, out string statusCode, out string statusMessage)
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id"></param>
        /// <param name="folderId"></param>
        /// <param name="fileName"></param>
        /// <param name="description"></param>
        /// <param name="enabled"></param>
        /// <param name="statusCode"></param>
        /// <param name="statusMessage"></param>
        /// <returns></returns>
        public int Update(BaseUserInfo userInfo, string id, string folderId, string fileName, string description, bool enabled, out string statusCode, out string statusMessage)
        {
            // 写入调试信息
#if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
#endif

            // 加强安全验证防止未授权匿名调用
#if (!DEBUG)
            LogOnService.UserIsLogOn(userInfo);
#endif

            statusCode = string.Empty;
            statusMessage = string.Empty;
            int returnValue = 0;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseFileManager fileManager = new BaseFileManager(dbHelper, userInfo);
                    returnValue = fileManager.Update(id, folderId, fileName, description, enabled, out statusCode);
                    statusMessage = fileManager.GetStateMessage(statusCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
#if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
#endif

            return returnValue;
        }
        #endregion

        #region public int UpdateFile(BaseUserInfo userInfo, string id, string fileName, byte[] file, out string statusCode, out string statusMessage)
        /// <summary>
        /// 更新文件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">文件主键</param>
        /// <param name="fileName">文件名</param>
        /// <param name="file">文件内容</param>
        /// <param name="statusCode">返回状态</param>
        /// <param name="statusMessage">反悔信息</param>
        /// <returns></returns>
        public int UpdateFile(BaseUserInfo userInfo, string id, string fileName, byte[] file, out string statusCode, out string statusMessage)
        {
            // 写入调试信息
#if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
#endif

            // 加强安全验证防止未授权匿名调用
#if (!DEBUG)
            LogOnService.UserIsLogOn(userInfo);
#endif

            statusCode = string.Empty;
            statusMessage = string.Empty;
            int returnValue = 0;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseFileManager fileManager = new BaseFileManager(dbHelper, userInfo);
                    returnValue = fileManager.UpdateFile(id, fileName, file, out statusCode);
                    statusMessage = fileManager.GetStateMessage(statusCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
#if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
#endif

            return returnValue;
        }
        #endregion

        #region public int Rename(BaseUserInfo userInfo, string id, string newName, bool enabled, out string statusCode, out string statusMessage)
        /// <summary>
        /// 重命名
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <param name="newName">新名称</param>
        /// <param name="enabled">有效</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>影响行数</returns>
        public int Rename(BaseUserInfo userInfo, string id, string newName, bool enabled, out string statusCode, out string statusMessage)
        {
            // 写入调试信息
#if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
#endif

            // 加强安全验证防止未授权匿名调用
#if (!DEBUG)
            LogOnService.UserIsLogOn(userInfo);
#endif

            statusCode = string.Empty;
            statusMessage = string.Empty;

            int returnValue = 0;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseFileEntity fileEntity = new BaseFileEntity();
                    BaseFileManager fileManager = new BaseFileManager(dbHelper, userInfo);
                    DataTable dataTable = fileManager.GetDataTableById(id);
                    fileEntity.GetSingle(dataTable);
                    fileEntity.FileName = newName;
                    fileEntity.Enabled = enabled ? 1 : 0;
                    returnValue = fileManager.Update(fileEntity, out statusCode);
                    statusMessage = fileManager.GetStateMessage(statusCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
#if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
#endif

            return returnValue;
        }
        #endregion

        #region public DataTable Search(BaseUserInfo userInfo, string searchValue)
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="search">查询</param>
        /// <returns>数据表</returns>
        public DataTable Search(BaseUserInfo userInfo, string searchValue)
        {
            // 写入调试信息
#if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
#endif

            // 加强安全验证防止未授权匿名调用
#if (!DEBUG)
            LogOnService.UserIsLogOn(userInfo);
#endif

            DataTable dataTable = new DataTable(BaseFileEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseFileManager fileManager = new BaseFileManager(dbHelper, userInfo);
                    dataTable = fileManager.Search(searchValue);
                    dataTable.TableName = BaseFileEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
#if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
#endif

            return dataTable;
        }
        #endregion

        #region public int MoveTo(BaseUserInfo userInfo, string id, string folderId)
        /// <summary>
        /// 移动
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <param name="folderId">移动到目录</param>
        /// <returns>影响行数</returns>
        public int MoveTo(BaseUserInfo userInfo, string id, string folderId)
        {
            // 写入调试信息
#if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
#endif

            // 加强安全验证防止未授权匿名调用
#if (!DEBUG)
            LogOnService.UserIsLogOn(userInfo);
#endif

            int returnValue = 0;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseFileManager fileManager = new BaseFileManager(dbHelper, userInfo);
                    returnValue = fileManager.MoveTo(id, folderId);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
#if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
#endif

            return returnValue;
        }
        #endregion

        #region public int BatchMoveTo(BaseUserInfo userInfo, string[] ids, string folderId)
        /// <summary>
        /// 批量移动
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">文件主键</param>
        /// <param name="folderId">移动到目录主键</param>
        /// <returns>影响行数</returns>
        public int BatchMoveTo(BaseUserInfo userInfo, string[] ids, string folderId)
        {
            // 写入调试信息
#if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
#endif

            // 加强安全验证防止未授权匿名调用
#if (!DEBUG)
            LogOnService.UserIsLogOn(userInfo);
#endif

            int returnValue = 0;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseFileManager fileManager = new BaseFileManager(dbHelper, userInfo);
                    for (int i = 0; i < ids.Length; i++)
                    {
                        returnValue += fileManager.MoveTo(ids[i], folderId);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
#if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
#endif

            return returnValue;
        }
        #endregion

        #region public int Delete(BaseUserInfo userInfo, string id)
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">文件主键</param>
        /// <returns>影响行数</returns>
        public int Delete(BaseUserInfo userInfo, string id)
        {
            // 写入调试信息
#if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
#endif

            // 加强安全验证防止未授权匿名调用
#if (!DEBUG)
            LogOnService.UserIsLogOn(userInfo);
#endif

            int returnValue = 0;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseFileManager fileManager = new BaseFileManager(dbHelper, userInfo);
                    returnValue = fileManager.Delete(id);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
#if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
#endif

            return returnValue;
        }
        #endregion

        #region public int BatchDelete(BaseUserInfo userInfo, string[] ids)
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">文件主键数组</param>
        /// <returns>影响行数</returns>
        public int BatchDelete(BaseUserInfo userInfo, string[] ids)
        {
            // 写入调试信息
#if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
#endif

            // 加强安全验证防止未授权匿名调用
#if (!DEBUG)
            LogOnService.UserIsLogOn(userInfo);
#endif

            int returnValue = 0;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseFileManager fileManager = new BaseFileManager(dbHelper, userInfo);
                    for (int i = 0; i < ids.Length; i++)
                    {
                        returnValue += fileManager.Delete(ids[i]);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
#if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
#endif

            return returnValue;
        }
        #endregion

        #region public int BatchSave(BaseUserInfo userInfo, DataTable dataTable)
        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable"></param>
        /// <returns>影响行数</returns>
        public int BatchSave(BaseUserInfo userInfo, DataTable dataTable)
        {
            // 写入调试信息
#if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
#endif

            // 加强安全验证防止未授权匿名调用
#if (!DEBUG)
            LogOnService.UserIsLogOn(userInfo);
#endif

            int returnValue = 0;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseFileManager fileManager = new BaseFileManager(dbHelper, userInfo);
                    returnValue = fileManager.BatchSave(dataTable);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
#if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
#endif

            return returnValue;
        }
        #endregion
    }
}