//-----------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2010 , Hairihan TECH, Ltd.  
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.ServiceModel;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// LogOnService
    /// 
    /// 修改纪录
    /// 
    ///		2009.04.15 版本：1.0 JiRiGaLa 添加接口定义。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2009.04.15</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class LogOnService : System.MarshalByRefObject, ILogOnService
    {
        private string serviceName = AppMessage.LogOnService;

        /// <summary>
        /// 用户中心数据库连接
        /// </summary>
        private readonly string UserCenterDbConnection = BaseSystemInfo.UserCenterDbConnection;

        #region public DataTable GetUserDT(BaseUserInfo userInfo)
        /// <summary>
        /// 获得用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetUserDT(BaseUserInfo userInfo)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                BaseSystemInfo.IsAuthorized(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseUserEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    // 检查用户在线状态(服务器专用)
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    userManager.CheckOnLine();
                    // 获取允许登录列表
                    List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                    parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldEnabled, 1));
                    parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldDeletionStateCode, 0));
                    dataTable = userManager.GetDataTable(parameters, BaseUserEntity.FieldSortCode);
                    dataTable.TableName = BaseUserEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.LogOnService_GetUserDT, MethodBase.GetCurrentMethod());
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

        #region public DataTable GetStaffUserDT(BaseUserInfo userInfo)
        /// <summary>
        /// 获得内部员工列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetStaffUserDT(BaseUserInfo userInfo)
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
                    // 检查用户在线状态(服务器专用)
                    BaseUserManager userManager = new BaseUserManager(dbHelper);
                    userManager.CheckOnLine();
                    // 获取允许登录列表
                    List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                    parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldIsStaff, 1));
                    parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldEnabled, 1));
                    parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldDeletionStateCode, 0));
                    dataTable = userManager.GetDataTable(parameters, BaseStaffEntity.FieldSortCode);
                    dataTable.TableName = BaseUserEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.LogOnService_GetStaffUserDT, MethodBase.GetCurrentMethod());
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

        #region public BaseUserInfo AccountActivation(BaseUserInfo userInfo, string openId, out string statusCode, out string statusMessage)
        /// <summary>
        /// 激活用户
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="openId">唯一识别码</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>用户实体</returns>
        public BaseUserInfo AccountActivation(BaseUserInfo userInfo, string openId, out string statusCode, out string statusMessage)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            BaseUserInfo returnUserInfo = null;
            statusCode = string.Empty;
            statusMessage = string.Empty;

            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    // 先侦测是否在线
                    userManager.CheckOnLine();
                    // 再进行登录
                    returnUserInfo = userManager.AccountActivation(openId, out statusCode);
                    statusMessage = userManager.GetStateMessage(statusCode);
                    // 登录时会自动记录进行日志记录，所以不需要进行重复日志记录
                    // BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, "激活用户", MethodBase.GetCurrentMethod());
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

            return returnUserInfo;
        }
        #endregion

        #region public BaseUserInfo LogOnByOpenId(BaseUserInfo userInfo, string openId, out string statusCode, out string statusMessage)
        /// <summary>
        /// 按唯一识别码登录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="openId">唯一识别码</param>
        /// <param name="returnStatusCode">返回状态码</param>
        /// <param name="returnStatusMessage">返回状消息</param>
        /// <returns>用户实体</returns>
        public BaseUserInfo LogOnByOpenId(BaseUserInfo userInfo, string openId, out string returnStatusCode, out string returnStatusMessage)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                BaseSystemInfo.IsAuthorized(userInfo);
            #endif

            BaseUserInfo returnUserInfo = null;
            returnStatusCode = string.Empty;
            returnStatusMessage = string.Empty;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    // 先侦测是否在线
                    userManager.CheckOnLine();
                    // 再进行登录
                    returnUserInfo = userManager.LogOnByOpenId(openId, userInfo.IPAddress, userInfo.MACAddress);
                    returnStatusCode = userManager.ReturnStatusCode;
                    returnStatusMessage = userManager.GetStateMessage(userManager.ReturnStatusCode);
                    // 登录时会自动记录进行日志记录，所以不需要进行重复日志记录
                    // BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
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

            return returnUserInfo;
        }
        #endregion

        #region public BaseUserInfo LogOnByUserName(BaseUserInfo userInfo, string userName, out string returnStatusCode, out string returnStatusMessage)
        /// <summary>
        /// 按用户名登录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userName">用户名</param>
        /// <param name="returnStatusCode">返回状态码</param>
        /// <param name="returnStatusMessage">返回状消息</param>
        /// <returns>用户实体</returns>
        public BaseUserInfo LogOnByUserName(BaseUserInfo userInfo, string userName, out string returnStatusCode, out string returnStatusMessage)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                BaseSystemInfo.IsAuthorized(userInfo);
            #endif

            BaseUserInfo returnUserInfo = null;
            returnStatusCode = string.Empty;
            returnStatusMessage = string.Empty;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    // 先侦测是否在线
                    userManager.CheckOnLine();
                    // 再进行登录
                    returnUserInfo = userManager.LogOnByUserName(userName, userInfo.IPAddress, userInfo.MACAddress);
                    returnStatusCode = userManager.ReturnStatusCode;
                    returnStatusMessage = userManager.GetStateMessage();
                    // 登录时会自动记录进行日志记录，所以不需要进行重复日志记录
                    // BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
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

            return returnUserInfo;
        }
        #endregion

        #region public BaseUserInfo UserLogOn(BaseUserInfo userInfo, string userName, string password, out string returnStatusCode, out string returnStatusMessage)
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="ipAddress">IP地址</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>用户实体</returns>
        public BaseUserInfo UserLogOn(BaseUserInfo userInfo, string userName, string password, bool createOpenId, out string returnStatusCode, out string returnStatusMessage)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            returnStatusCode = StatusCode.DbError.ToString();
            returnStatusMessage = string.Empty;
            
            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                BaseSystemInfo.IsAuthorized(userInfo);
            #endif

            BaseUserInfo returnUserInfo = null;
            // statusCode = ServiceSecurityContext.Current.PrimaryIdentity.Name;            

            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    // 先侦测是否在线
                    userManager.CheckOnLine();
                    // 再进行登录
                    returnUserInfo = userManager.LogOn(userName, password, createOpenId);
                    returnStatusCode = userManager.ReturnStatusCode;
                    returnStatusMessage = userManager.GetStateMessage(returnStatusCode);
                    // 登录时会自动记录进行日志记录，所以不需要进行重复日志记录
                    // BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
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
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart, ConsoleColor.Red);
            #endif

            return returnUserInfo;
        }
        #endregion

        #region public int ServerCheckOnLine()
        /// <summary>
        /// 服务器端检查在线状态
        /// </summary>
        /// <returns>离线人数</returns>
        public int ServerCheckOnLine()
        {
            int returnValue = 0;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseUserManager userManager = new BaseUserManager(dbHelper);
                    returnValue = userManager.CheckOnLine();
                }
                catch (Exception ex)
                {
                    LogUtil.WriteException(ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }
            return returnValue;
        }
        #endregion

        #region public int SetPassword(BaseUserInfo userInfo, string[] userIds, string password, out string returnStatusCode, out string returnStatusMessage)
        /// <summary>
        /// 设置用户密码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">被设置的员工主键</param>
        /// <param name="password">新密码</param>
        /// <param name="returnStatusCode">返回状态码</param>
        /// <param name="returnStatusMessage">返回状消息</param>
        /// <returns>影响行数</returns>
        public int SetPassword(BaseUserInfo userInfo, string[] userIds, string password, out string returnStatusCode, out string returnStatusMessage)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            returnStatusCode = string.Empty;
            returnStatusMessage = string.Empty;
            int returnValue = 0;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.LogOnService_SetPassword, MethodBase.GetCurrentMethod());
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    returnValue = userManager.BatchSetPassword(userIds, password);
                    returnStatusCode = userManager.ReturnStatusCode;
                    // 获得状态消息
                    returnStatusMessage = userManager.GetStateMessage(returnStatusCode);
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
        
        #region public int ChangePassword(BaseUserInfo userInfo, string oldPassword, string newPassword, out string statusCode, out string statusMessage)
        /// <summary>
        /// 用户修改密码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="oldPassword">原始密码</param>
        /// <param name="newPassword">新密码</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>影响行数</returns>
        public int ChangePassword(BaseUserInfo userInfo, string oldPassword, string newPassword, out string statusCode, out string statusMessage)
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
                    // 事务开始
                    // dbHelper.BeginTransaction();
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.LogOnService_ChangePassword, MethodBase.GetCurrentMethod());
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    returnValue = userManager.ChangePassword(oldPassword, newPassword, out statusCode);
                    // 获得状态消息
                    statusMessage = userManager.GetStateMessage(statusCode);
                    // 事务提交
                    // dbHelper.CommitTransaction();
                }
                catch (Exception ex)
                {
                    // 事务回滚
                    // dbHelper.RollbackTransaction();
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
        
        #region public int ChangeCommunicationPassword(BaseUserInfo userInfo, string oldPassword, string newPassword, out string statusCode, out string statusMessage)
        /// <summary>
        /// 用户修改通讯密码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="oldPassword">原始密码</param>
        /// <param name="newPassword">新密码</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>影响行数</returns>
        public int ChangeCommunicationPassword(BaseUserInfo userInfo, string oldPassword, string newPassword, out string statusCode, out string statusMessage)
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
                    // 事务开始
                    // dbHelper.BeginTransaction();
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.LogOnService_ChangeCommunicationPassword, MethodBase.GetCurrentMethod());
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    returnValue = userManager.ChangeCommunicationPassword(oldPassword, newPassword, out statusCode);
                    // 获得状态消息
                    statusMessage = userManager.GetStateMessage(statusCode);
                    // 事务提交
                    // dbHelper.CommitTransaction();
                }
                catch (Exception ex)
                {
                    // 事务回滚
                    // dbHelper.RollbackTransaction();
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

        #region public bool CommunicationPassword(BaseUserInfo userInfo, string communicationPassword)
        /// <summary>
        /// 验证用户通讯密码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="communicationPassword">通讯密码</param>
        /// <param name="ipAddress">IP地址</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>是否正确</returns>
        public bool CommunicationPassword(BaseUserInfo userInfo, string communicationPassword)
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
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    returnValue = userManager.CommunicationPassword(communicationPassword);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.LogOnService_CommunicationPassword, MethodBase.GetCurrentMethod());
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

        #region public int SetCommunicationPassword(BaseUserInfo userInfo, string[] userIds, string password, out string statusCode, out string statusMessage)
        /// <summary>
        /// 设置用户通讯密码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">被设置的员工主键</param>
        /// <param name="password">新密码</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>影响行数</returns>
        public int SetCommunicationPassword(BaseUserInfo userInfo, string[] userIds, string password, out string statusCode, out string statusMessage)
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
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.LogOnService_SetPassword, MethodBase.GetCurrentMethod());
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    returnValue = userManager.BatchSetCommunicationPassword(userIds, password, out statusCode);
                    // 获得状态消息
                    statusMessage = userManager.GetStateMessage(statusCode);
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

        #region public string CreateDigitalSignature(BaseUserInfo userInfo, string password, out string returnStatusCode, out string returnStatusMessage)
        /// <summary>
        /// 创建数字证书签名
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="password">密码</param>
        /// <param name="returnStatusCode">返回状态码</param>
        /// <param name="returnStatusMessage">返回状消息</param>
        /// <returns>私钥</returns>
        public string CreateDigitalSignature(BaseUserInfo userInfo, string password, out string returnStatusCode, out string returnStatusMessage)
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
            returnStatusCode = string.Empty;
            returnStatusMessage = string.Empty;

            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    returnValue = userManager.CreateDigitalSignature(password, out returnStatusCode);
                    // 获得状态消息
                    returnStatusMessage = userManager.GetStateMessage(returnStatusCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.LogOnService_CreateDigitalSignature, MethodBase.GetCurrentMethod());
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

        #region public string GetPublicKey(BaseUserInfo userInfo, string userId)
        /// <summary>
        /// 获取当前用户的公钥
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <returns>公钥</returns>
        public string GetPublicKey(BaseUserInfo userInfo, string userId)
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
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    returnValue = userManager.GetPublicKey(userId);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.LogOnService_GetPublicKey, MethodBase.GetCurrentMethod());
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

        #region public int ChangeSignedPasswordd(BaseUserInfo userInfo, string oldPassword, string newPassword, out string statusCode, out string statusMessage)
        /// <summary>
        /// 用户修改签名密码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="oldPassword">原始密码</param>
        /// <param name="newPassword">新密码</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>影响行数</returns>
        public int ChangeSignedPassword(BaseUserInfo userInfo, string oldPassword, string newPassword, out string statusCode, out string statusMessage)
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
                    // 事务开始
                    // dbHelper.BeginTransaction();
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    returnValue = userManager.ChangeSignedPassword(oldPassword, newPassword, out statusCode);
                    // 获得状态消息
                    statusMessage = userManager.GetStateMessage(statusCode);
                    // 事务提交
                    // dbHelper.CommitTransaction();
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.LogOnService_ChangeSignedPassword, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    // 事务回滚
                    // dbHelper.RollbackTransaction();
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

        #region public bool SignedPassword(BaseUserInfo userInfo, string signedPassword)
        /// <summary>
        /// 验证用户数字签名密码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="signedPassword">验证数字签名密码</param>
        /// <param name="ipAddress">IP地址</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>是否正确</returns>
        public bool SignedPassword(BaseUserInfo userInfo, string signedPassword)
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
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    returnValue = userManager.SignedPassword(signedPassword);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.LogOnService_SignedPassword, MethodBase.GetCurrentMethod());
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

        #region public static bool UserIsLogOn(BaseUserInfo userInfo)
        /// <summary>
        /// 用户是否已经登录了系统？
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>是否登录</returns>
        public static bool UserIsLogOn(BaseUserInfo userInfo)
        {
            // 加强安全验证防止未授权匿名调用
            if (!BaseSystemInfo.IsAuthorized(userInfo))
            {
                throw new Exception(AppMessage.MSG0800);
            }
            // 这里表示是没登录过的用户
            // if (string.IsNullOrEmpty(userInfo.OpenId))
            // {
            //    throw new Exception(AppMessage.MSG0900);            
            // }
            // 确认用户是否登录了？是否进行了匿名的破坏工作
            /*
            IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbConnection);
            BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
            if (!userManager.UserIsLogOn(userInfo))
            {
                throw new Exception(AppMessage.MSG0900);            
            }
            */
            return true;
        }
        #endregion

        #region public void OnLine(BaseUserInfo userInfo)
        /// <summary>
        /// 用户现在
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="onLineState">用户在线状态</param>
        public void OnLine(BaseUserInfo userInfo, int onLineState = 1)
        {
            // 写入调试信息
            #if (DEBUG)
                // int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    // BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.LogOnService_OnLine, MethodBase.GetCurrentMethod());
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    userManager.OnLine(userInfo.Id, onLineState);
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
                // BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart, ConsoleColor.Green);
            #endif
        }
        #endregion

        #region public void OnExit(BaseUserInfo userInfo)
        /// <summary>
        /// 用户离线
        /// </summary>
        /// <param name="userInfo">用户</param>
        public void OnExit(BaseUserInfo userInfo)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

                using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
                {
                    try
                    {
                        dbHelper.Open(UserCenterDbConnection);
                        BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.LogOnService_OnExit, MethodBase.GetCurrentMethod());
                        BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                        userManager.OnExit(userInfo.Id);
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
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart, ConsoleColor.Yellow);
            #endif
        }
        #endregion

        #region public bool LockUser(BaseUserInfo userInfo, string userName)
        /// <summary>
        /// 锁定用户
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userName">用户名</param>
        /// <returns>是否成功锁定</returns>
        public bool LockUser(BaseUserInfo userInfo, string userName)
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
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.LogOnService_LockUser, MethodBase.GetCurrentMethod());
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                    parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldUserName, userName));
                    parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldEnabled, 1));
                    parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldDeletionStateCode, 0));
                    BaseUserEntity userEntity = new BaseUserEntity(userManager.GetDataTable(parameters));
                    // 判断是否为空的
                    if (userEntity != null && !string.IsNullOrEmpty(userEntity.Id))
                    {
                        // 被锁定15分钟，不允许15分钟内登录，这时间是按服务器的时间来的。
                        userEntity.LockStartDate = DateTime.Now;
                        userEntity.LockEndDate = DateTime.Now.AddMinutes(BaseSystemInfo.LockUserPasswordError);
                        returnValue = userManager.UpdateEntity(userEntity) > 0;
                    }
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
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart, ConsoleColor.Yellow);
            #endif

            return returnValue;
        }
        #endregion
    }
}