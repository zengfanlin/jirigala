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
    /// LogService
    /// 日志服务
    /// 
    /// 修改纪录
    /// 
    ///		2008.03.23 版本：1.0 JiRiGaLa 创建。 
    /// 
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.03.23</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class LogService : System.MarshalByRefObject, ILogService
    {
        private string serviceName = AppMessage.LogService;

        /// <summary>
        /// 用户中心数据库连接
        /// </summary>
        private readonly string UserCenterDbConnection = BaseSystemInfo.UserCenterDbConnection;

        /// <summary>
        /// 业务中心数据库连接
        /// </summary>
        private readonly string BusinessDbConnection = BaseSystemInfo.BusinessDbConnection;

        #region public void WriteLog(BaseUserInfo userInfo, string processId, string processName, string methodId, string methodName) 写入日志
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="processId">服务</param>
        /// <param name="processName">服务名称</param>
        /// <param name="methodId">操作</param>
        /// <param name="methodName">操作名称</param>
        /// <param name="description">描述</param>
        public void WriteLog(BaseUserInfo userInfo, string processId, string processName, string methodId, string methodName)
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
                        BaseLogManager.Instance.Add(dbHelper, userInfo, processName, methodName, processId, methodId, string.Empty);
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
        }
        #endregion

        #region public void WriteExit(BaseUserInfo userInfo, string logId) 离开时的日志记录
        /// <summary>
        /// 离开时的日志记录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="logId">日志主键</param>
        public void WriteExit(BaseUserInfo userInfo, string logId)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            if (!string.IsNullOrEmpty(logId))
            {
                using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
                {
                    try
                    {
                        dbHelper.Open(UserCenterDbConnection);
                        SQLBuilder sqlBuilder = new SQLBuilder(dbHelper);
                        sqlBuilder.BeginUpdate(BaseLogEntity.TableName);
                        sqlBuilder.SetDBNow(BaseLogEntity.FieldModifiedOn);
                        sqlBuilder.SetWhere(BaseLogEntity.FieldId, logId);
                        sqlBuilder.EndUpdate();
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
            }            
            
            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
        }
        #endregion

        #region public DataTable GetLogGeneral(BaseUserInfo userInfo) 获取用户访问情况日志
        /// <summary>
        /// 获取用户访问情况日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetLogGeneral(BaseUserInfo userInfo)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseLogEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    if (userInfo.IsAdministrator)
                    {
                        dataTable = userManager.GetDataTable();
                    }
                    else
                    {
                        BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(dbHelper, userInfo);
                        string[] userIds = permissionScopeManager.GetUserIds(userInfo.Id, "Resource.ManagePermission");
                        dataTable = userManager.GetDataTableByIds(userIds);
                    }
                    dataTable.TableName = BaseLogEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.LogService_GetLogGeneral, MethodBase.GetCurrentMethod());
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

//        #region public DataTable GetLogGeneralForOnlineUser(BaseUserInfo userInfo) 获取用户访问情况日志
//        /// <summary>
//        /// 获取用户访问情况日志
//        /// </summary>
//        /// <param name="userInfo">用户</param>
//        /// <returns>数据表</returns>
//        public DataTable GetLogGeneralForOnlineUser(BaseUserInfo userInfo, bool UserOnLine)
//        {
//            // 写入调试信息
//             #if (DEBUG)
//            int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
//            #endif

//            // 加强安全验证防止未授权匿名调用
//                #if (!DEBUG)
//                LogOnService.UserIsLogOn(userInfo);
//                #endif

//            DataTable dataTable = new DataTable(BaseLogEntity.TableName);
//            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
//            {
//                BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
//                try
//                {
//                    dbHelper.Open(UserCenterDbConnection);
//                    if (userInfo.IsAdministrator)
//                    {
//                        dataTable = userManager.GetDataTable();
//                    }
//                    else
//                    {
//                        BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(dbHelper, userInfo);
//                        string[] userIds = permissionScopeManager.GetUserIds(userInfo.Id, "Resource.ManagePermission");
//                        dataTable = userManager.GetDataTableByIds(userIds,UserOnLine);
//                    }
//                    dataTable.TableName = BaseLogEntity.TableName;
//                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.LogService_GetLogGeneral, MethodBase.GetCurrentMethod());
//                }
//                catch (Exception ex)
//                {
//                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
//                    throw ex;
//                }
//                finally
//                {
//                    dbHelper.Close();
//                }
//            }

//            // 写入调试信息
//#if (DEBUG)
//            BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
//#endif
//            return dataTable;
//        }
//        #endregion

        #region public DataTable ResetVisitInfo(BaseUserInfo userInfo, string[] ids) 重置用户访问情况
        /// <summary>
        /// 重置用户访问情况
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">日志主键</param>
        /// <returns>数据表</returns>
        public DataTable ResetVisitInfo(BaseUserInfo userInfo, string[] ids)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseLogEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    dbHelper.BeginTransaction();
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    // 重置访问情况
                    userManager.ResetVisitInfo(ids);
                    // 获取列表
                    dataTable = userManager.GetDataTable();
                    dataTable.TableName = BaseLogEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.LogService_ResetVisitInfo, MethodBase.GetCurrentMethod());
                    dbHelper.CommitTransaction();
                }
                catch (Exception ex)
                {
                    dbHelper.RollbackTransaction();
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

        #region public DataTable GetDataTableByDate(BaseUserInfo userInfo, string beginDate, string endDate) 按日期获取日志
        /// <summary>
        /// 按日期获取日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByDate(BaseUserInfo userInfo, string beginDate, string endDate, string userId, string moduleId)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif
            
            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseLogEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseLogManager logManager = new BaseLogManager(dbHelper, userInfo);
                    if (!string.IsNullOrEmpty(userId))
                    {
                        dataTable = logManager.GetDataTableByDateByUserIds(new string[] { userId }, BaseLogEntity.FieldProcessId, moduleId, beginDate, endDate);
                    }
                    else
                    {
                        if (userInfo.IsAdministrator)
                        {
                            dataTable = logManager.GetDataTableByDate(BaseLogEntity.FieldProcessId, moduleId, beginDate, endDate);
                        }
                        else
                        {
                            BasePermissionScopeManager BasePermissionScopeManager = new BasePermissionScopeManager(dbHelper, userInfo);
                            string[] userIds = BasePermissionScopeManager.GetUserIds(userInfo.Id, "Resource.ManagePermission");
                            dataTable = logManager.GetDataTableByDateByUserIds(userIds, BaseLogEntity.FieldProcessId, moduleId, beginDate, endDate);
                        }
                    }
                    dataTable.TableName = BaseLogEntity.TableName;
                    // 添加访问日志
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.LogService_GetDataTableByDate, MethodBase.GetCurrentMethod());
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

        #region public DataTable GetDataTableByModule(BaseUserInfo userInfo, string processId, string beginDate,string endDate) 按模块获取日志
        /// <summary>
        /// 按模块获取日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="processId">服务名称</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByModule(BaseUserInfo userInfo, string processId, string beginDate, string endDate)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseLogEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseLogManager logManager = new BaseLogManager(dbHelper, userInfo);
                    if (userInfo.IsAdministrator)
                    {
                        dataTable = logManager.GetDataTableByDate(BaseLogEntity.FieldProcessId, processId, beginDate, endDate);
                    }
                    else
                    {
                        BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(dbHelper, userInfo);
                        string[] userIds = permissionScopeManager.GetUserIds(userInfo.Id, "Resource.ManagePermission");
                        dataTable = logManager.GetDataTableByDateByUserIds(userIds, BaseLogEntity.FieldProcessId, processId, beginDate, endDate);
                    }
                    dataTable.TableName = BaseLogEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.LogService_GetDataTableByModule, MethodBase.GetCurrentMethod());
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

        #region public DataTable GetDataTableByUser(BaseUserInfo userInfo, string userId, string beginDate, string endDate) 按用户获取日志
        /// <summary>
        /// 按用户获取日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByUser(BaseUserInfo userInfo, string userId, string beginDate, string endDate)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseLogEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseLogManager logManager = new BaseLogManager(dbHelper, userInfo);
                    dataTable = logManager.GetDataTableByDate(BaseLogEntity.FieldUserId, userId, beginDate, endDate);
                    dataTable.TableName = BaseLogEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.LogService_GetDataTableByUser, MethodBase.GetCurrentMethod());
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

        #region public int Delete(BaseUserInfo userInfo, string id) 删除日志
        /// <summary>
        /// 删除日志
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
                    BaseLogManager logManager = new BaseLogManager(dbHelper, userInfo);
                    returnValue = logManager.Delete(new KeyValuePair<string, object>(BaseLogEntity.FieldId, id));
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.LogService_Delete, MethodBase.GetCurrentMethod());
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

        #region public int BatchDelete(BaseUserInfo userInfo, string[] ids) 批量删除日志
        /// <summary>
        /// 批量删除日志
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
                    BaseLogManager logManager = new BaseLogManager(dbHelper, userInfo);
                    returnValue = logManager.Delete(BaseLogEntity.FieldId, ids);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.LogService_BatchDelete, MethodBase.GetCurrentMethod());
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

        #region public void Truncate(BaseUserInfo userInfo) 全部清除日志
        /// <summary>
        /// 全部清除日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public void Truncate(BaseUserInfo userInfo)
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
                    BaseLogManager logManager = new BaseLogManager(dbHelper, userInfo);
                    logManager.Truncate();
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.LogService_Truncate, MethodBase.GetCurrentMethod());
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
        }
        #endregion

        #region public DataTable GetDataTableApplicationByDate(BaseUserInfo userInfo, string beginDate, string endDate) 按日期获取日志（业务）
        /// <summary>
        /// 按日期获取日志（业务）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableApplicationByDate(BaseUserInfo userInfo, string beginDate, string endDate)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseLogEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(BusinessDbConnection);
                    BaseLogManager logManager = new BaseLogManager(dbHelper, userInfo);
                    dataTable = logManager.GetDataTableByDate(string.Empty, string.Empty, beginDate, endDate);
                    dataTable.TableName = BaseLogEntity.TableName;
                    // 添加访问日志
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.LogService_GetDataTableApplicationByDate, MethodBase.GetCurrentMethod());
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
        
        #region public int BatchDeleteApplication(BaseUserInfo userInfo, string[] ids) 批量删除日志(业务)
        /// <summary>
        /// 批量删除日志(业务)
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int BatchDeleteApplication(BaseUserInfo userInfo, string[] ids)
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
                    dbHelper.Open(BusinessDbConnection);
                    BaseLogManager logManager = new BaseLogManager(dbHelper, userInfo);
                    returnValue = logManager.Delete(BaseLogEntity.FieldId, ids);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.LogService_BatchDeleteApplication, MethodBase.GetCurrentMethod());
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

        #region public void TruncateApplication(BaseUserInfo userInfo) 全部清除日志(业务)
        /// <summary>
        /// 全部清除日志(业务)
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public void TruncateApplication(BaseUserInfo userInfo)
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
                    dbHelper.Open(BusinessDbConnection);
                    BaseLogManager logManager = new BaseLogManager(dbHelper, userInfo);
                    logManager.Truncate();
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.LogService_TruncateApplication, MethodBase.GetCurrentMethod());
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
        }
        #endregion

        #region public DataTable Search(BaseUserInfo userInfo, string searchValue, bool OnlyOnLine) 查询用户
        /// <summary>
        /// 查询日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="search">查询</param>
        /// <param name="OnlyOnLine">是否在线</param>
        /// <returns>数据表</returns>
        public DataTable Search(BaseUserInfo userInfo, string searchValue, bool OnlyOnLine)
        {
            // 写入调试信息
#if (DEBUG)
            int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
#endif

            // 加强安全验证防止未授权匿名调用
#if (!DEBUG)
            LogOnService.UserIsLogOn(userInfo);
#endif

            DataTable dataTable = new DataTable(BaseLogEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseLogManager logManager = new BaseLogManager(dbHelper, userInfo);
                    BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(dbHelper, userInfo);
                    string[] userIds = permissionScopeManager.GetUserIds(userInfo.Id, "Resource.ManagePermission");
                    dataTable = logManager.Search(userIds,searchValue, OnlyOnLine, true);
                    dataTable.TableName = BaseLogEntity.TableName;
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
    }
}