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
    /// UserService
    /// 用户管理服务
    /// 
    /// 修改纪录
    /// 
    ///     2009.09.11 版本：2.4 JiRiGaLa SetUserAuditStates 函数进行改进，严格按审核状态来，还需要按工作流改进。
    ///		2008.03.17 版本：2.3 JiRiGaLa 增加，已经在线，进行重新登录及扮演情况下在线状态事件处理。
    ///		2007.08.18 版本：2.2 JiRiGaLa 将文件名修改为 UserService。
    ///		2007.08.15 版本：2.1 JiRiGaLa 改进运行速度采用 WebService 变量定义 方式处理数据。
    ///		2007.08.14 版本：2.0 JiRiGaLa 改进运行速度采用 Instance 方式处理数据。
    ///     2007.06.12 版本：1.1 JiRiGaLa 加入调试信息#if (DEBUG)。
    ///		2007.04.16 版本：1.0 JiRiGaLa 窗体与数据库连接的分离。
    ///		
    /// 版本：2.4
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2009.09.11</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public partial class UserService : System.MarshalByRefObject, IUserService
    {
        private string serviceName = AppMessage.UserService;

        /// <summary>
        /// 用户中心数据库连接
        /// </summary>
        private readonly string UserCenterDbConnection = BaseSystemInfo.UserCenterDbConnection;

        #region public bool Exists(BaseUserInfo userInfo, List<KeyValuePair<string, object>> parameters)
        /// <summary>
        /// 用户名是否重复
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="parameters">字段名,字段值</param>
        /// <returns>已存在</returns>
        public bool Exists(BaseUserInfo userInfo, List<KeyValuePair<string, object>> parameters)
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
                    BaseUserManager userManager = new BaseUserManager(dbHelper);
                    returnValue = userManager.Exists(parameters);
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

        #region public string AddUser(IDbHelper dbHelper, BaseUserInfo userInfo, BaseUserEntity userEntity, out string statusCode, out string statusMessage)
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="userEntity">用户实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>主键</returns>
        public string AddUser(IDbHelper dbHelper, BaseUserInfo userInfo, BaseUserEntity userEntity, out string statusCode, out string statusMessage)
        {
            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                BaseSystemInfo.IsAuthorized(userInfo);
            #endif

            string returnValue = string.Empty;
            BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
            // 若是系统需要用加密的密码，这里需要加密密码。
            if (BaseSystemInfo.ServerEncryptPassword)
            {
                userEntity.UserPassword = userManager.EncryptUserPassword(userEntity.UserPassword);
                // 安全通讯密码、交易密码也生成好
                userEntity.CommunicationPassword = userManager.EncryptUserPassword(userEntity.CommunicationPassword);
            }
            returnValue = userManager.Add(userEntity, out statusCode);
            statusMessage = userManager.GetStateMessage(statusCode);
            // 自己不用给自己发提示信息，这个提示信息是为了提高工作效率的，还是需要审核通过的，否则垃圾信息太多了
            if (userEntity.Enabled == 0 && statusCode.Equals(StatusCode.OKAdd.ToString()))
            {
                // 不是系统管理员添加
                if (!userInfo.IsAdministrator)
                {
                    // 给超级管理员群组发信息
                    BaseRoleManager roleManager = new BaseRoleManager(dbHelper, userInfo);
                    string[] roleIds = roleManager.GetIds(new KeyValuePair<string, object>(BaseRoleEntity.FieldCode, "Administrators"));
                    string[] userIds = userManager.GetIds(new KeyValuePair<string, object>(BaseUserEntity.FieldCode, "Administrator"));
                    // 发送请求审核的信息
                    BaseMessageEntity messageEntity = new BaseMessageEntity();
                    messageEntity.FunctionCode = MessageFunction.WaitForAudit.ToString();

                    // Pcsky 2012.05.04 显示申请的用户名
                    messageEntity.Contents = userInfo.RealName + "(" + userInfo.IPAddress + ")" + AppMessage.UserService_Application + userEntity.UserName + AppMessage.UserService_Check;
                    //messageEntity.Contents = userInfo.RealName + "(" + userInfo.IPAddress + ")" + AppMessage.UserService_Application + userEntity.RealName + AppMessage.UserService_Check;

                    BaseMessageManager messageManager = new BaseMessageManager(dbHelper, userInfo);
                    messageManager.BatchSend(userIds, null, roleIds, messageEntity, false);
                }
            }
            return returnValue;
        }
        #endregion

        #region public string AddUser(BaseUserInfo userInfo, BaseUserEntity userEntity, out string statusCode, out string statusMessage)
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="userEntity">用户实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>主键</returns>
        public string AddUser(BaseUserInfo userInfo, BaseUserEntity userEntity, out string statusCode, out string statusMessage)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                BaseSystemInfo.IsAuthorized(userInfo);
            #endif
            
            string returnValue = string.Empty;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    returnValue = AddUser(dbHelper, userInfo, userEntity, out statusCode, out statusMessage);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.UserService_AddUser, MethodBase.GetCurrentMethod());
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

        #region public BaseUserEntity GetEntity(BaseUserInfo userInfo, string id)
        /// <summary>
        /// 获取用户实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        public BaseUserEntity GetEntity(BaseUserInfo userInfo, string id)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            BaseUserEntity userEntity = null;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    userEntity = userManager.GetEntity(id);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.UserService_GetEntity, MethodBase.GetCurrentMethod());
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

            return userEntity;
        }
        #endregion

        #region public DataTable GetDataTable(BaseUserInfo userInfo) 获取用户列表
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTable(BaseUserInfo userInfo)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseUserEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    // 获取允许登录列表
                    dataTable = userManager.GetDataTable();
                    dataTable.TableName = BaseUserEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.UserService_GetDataTable, MethodBase.GetCurrentMethod());
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

        #region public DataTable GetDataTableByIds(BaseUserInfo userInfo, string[] ids) 获取用户列表
        /// <summary>
        /// 按主键获取用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
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

            DataTable dataTable = new DataTable(BaseStaffEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    dataTable = userManager.GetDataTable(BaseUserEntity.FieldId, ids, BaseUserEntity.FieldSortCode);
                    dataTable.TableName = BaseUserEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.UserService_GetDataTableByIds, MethodBase.GetCurrentMethod());
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

        #region public DataTable Search(BaseUserInfo userInfo, string searchValue, string auditStates, string[] roleIds) 查询用户
        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="search">查询</param>
        /// <param name="auditStates">有效</param>
        /// <param name="roleIds">用户角色</param>
        /// <returns>数据表</returns>
        public DataTable Search(BaseUserInfo userInfo, string searchValue, string auditStates, string[] roleIds)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseUserEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    dataTable = userManager.Search(searchValue, roleIds, null, auditStates);
                    dataTable.TableName = BaseUserEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.UserService_Search, MethodBase.GetCurrentMethod());
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

        #region public int UpdateUser(BaseUserInfo userInfo, BaseUserEntity userEntity, out string statusCode, out string statusMessage)
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="userEntity">用户实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>影响行数</returns>
        public int UpdateUser(BaseUserInfo userInfo, BaseUserEntity userEntity, out string statusCode, out string statusMessage)
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
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    // 调用方法，并且返回运行结果
                    returnValue = userManager.Update(userEntity, out statusCode);
                    statusMessage = userManager.GetStateMessage(statusCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.UserService_UpdateUser, MethodBase.GetCurrentMethod());
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

        #region public int SetUserAuditStates(BaseUserInfo userInfo, string[] ids, AuditStatus auditStates) 设置用户审核状态
        /// <summary>
        /// 设置用户审核状态
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <param name="auditStates">审核状态</param>
        /// <returns>影响行数</returns>
        public int SetUserAuditStates(BaseUserInfo userInfo, string[] ids, AuditStatus auditStates)
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
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    returnValue = userManager.SetProperty(ids, new KeyValuePair<string, object>(BaseUserEntity.FieldAuditStatus, auditStates.ToString()));
                    // 被审核通过
                    if (auditStates == AuditStatus.AuditPass)
                    {
                        returnValue = userManager.SetProperty(ids, new KeyValuePair<string, object>(BaseUserEntity.FieldEnabled, 1));
                        // returnValue = userManager.SetProperty(ids, BaseUserEntity.FieldAuditStatus, StatusCode.UserIsActivate.ToString());
                    }
                    // 被退回
                    if (auditStates == AuditStatus.AuditReject)
                    {
                        returnValue = userManager.SetProperty(ids, new KeyValuePair<string, object>(BaseUserEntity.FieldEnabled, 0));
                        returnValue = userManager.SetProperty(ids, new KeyValuePair<string, object>(BaseUserEntity.FieldAuditStatus, StatusCode.UserLocked.ToString()));
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.UserService_SetUserAuditStates, MethodBase.GetCurrentMethod());
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
        /// <param name="dataTable">数据表</param>
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
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    returnValue = userManager.BatchSave(dataTable);
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

        #region public int SetDeleted(BaseUserInfo userInfo, string[] ids) 批量打删除标志
        /// <summary>
        /// 批量打删除标志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int SetDeleted(BaseUserInfo userInfo, string[] ids)
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
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    // 考虑主键是数值类型的，支持Access
                    returnValue = userManager.SetDeleted(ids, true);
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

        #region public int Delete(BaseUserInfo userInfo, string id) 单个删除
        /// <summary>
        /// 单个删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
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
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    returnValue = userManager.Delete(id);
                    // 用户已经被删除的员工的UserId设置为Null，说白了，是需要整理数据
                    userManager.CheckUserStaff();
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

            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif

            return returnValue;
        }
        #endregion

        #region public int BatchDelete(BaseUserInfo userInfo, string[] ids) 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
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
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    returnValue = userManager.Delete(ids);
                    // 用户已经被删除的员工的UserId设置为Null，说白了，是需要整理数据
                    userManager.CheckUserStaff();
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