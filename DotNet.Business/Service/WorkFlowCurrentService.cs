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
    /// WorkFlowCurrentService
    /// 当前工作流服务
    /// 
    /// 修改纪录
    /// 
    ///		2007.08.15 版本：2.2 JiRiGaLa 改进运行速度采用 WebService 变量定义 方式处理数据。
    ///		2007.08.14 版本：2.1 JiRiGaLa 改进运行速度采用 Instance 方式处理数据。
    ///		2007.07.19 版本：1.0 JiRiGaLa 实现控件功能。
    ///		
    /// 版本：2.2
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.08.15</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class WorkFlowCurrentService : System.MarshalByRefObject, IWorkFlowCurrentService
    {
        private string serviceName = AppMessage.WorkFlowCurrentService;

        /// <summary>
        /// 工作流数据库连接
        /// </summary>
        private readonly string WorkFlowDbConnection = BaseSystemInfo.WorkFlowDbConnection;

        /// <summary>
        /// 用户中心数据库连接
        /// </summary>
        private readonly string UserCenterDbConnection = BaseSystemInfo.UserCenterDbConnection;

        #region public bool CheckIsAutoWorkFlow(BaseUserInfo userInfo, string[] currentFlowIds, out string returnStatusCode,out string returnStatusMessage) 检查是否是步骤流
        /// <summary>
        /// 检查是否是步骤流
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="currentFlowIds">主键组</param>
        /// <param name="returnStatusCode">返回代码</param>
        /// <param name="returnStatusMessage">返回信息</param>
        /// <returns></returns>
        public bool CheckIsAutoWorkFlow(BaseUserInfo userInfo, string[] currentFlowIds, out string returnStatusCode,out string returnStatusMessage)
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
            bool returnValue = false ;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    // 打开数据库
                    dbHelper.Open(WorkFlowDbConnection);
                   
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    string processId = string.Empty;
                    for (int i = 0; i < currentFlowIds.Length; i++)
                    {
                        BaseWorkFlowCurrentEntity workFlowCurrentEntity = workFlowCurrentManager.GetEntity(currentFlowIds[i]);
                        if ((workFlowCurrentEntity != null) && (!string.IsNullOrEmpty(workFlowCurrentEntity.Id)))
                        {
                            if (workFlowCurrentEntity.AuditStatus.Equals(AuditStatus.StartAudit.ToString())
                   || workFlowCurrentEntity.AuditStatus.Equals(AuditStatus.AuditPass.ToString())
                   || workFlowCurrentEntity.AuditStatus.Equals(AuditStatus.WaitForAudit.ToString())
                   || workFlowCurrentEntity.AuditStatus.Equals(AuditStatus.AuditReject.ToString()))
                            {
                                // 不为空的话是步骤流
                                if (workFlowCurrentEntity.WorkFlowId != null)
                                {
                                    returnValue = true;
                                }
                                else
                                {
                                    // 判断是否是批量审核，只有自由流才限制批量审批
                                    if (i > 0)
                                    {
                                        returnStatusMessage = "你选中的记录里包含自由审批流程所以不能批量审批。";
                                    }
                                    return false;
                                }
                            }
                            else
                            {
                                returnStatusMessage = "你选中的记录里包含状态不明确的记录。";
                                return false;
                            }
                        }
                        else
                        {
                            returnStatusMessage = "你选中的记录里可能已被删除。";
                            return false;
                        }
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

        #region public bool CheckIsAutoWorkFlow(BaseUserInfo userInfo, string categoryCode, string[] objectIds, out string returnStatusCode,out string returnStatusMessage) 检查是否是步骤流
        /// <summary>
        /// 检查是否是步骤流
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="categoryCode">单据类型代码</param>
        /// <param name="objectIds">单据主键组</param>
        /// <param name="returnStatusCode">返回代码</param>
        /// <param name="returnStatusMessage">返回信息</param>
        /// <returns></returns>
        public bool CheckIsAutoWorkFlow(BaseUserInfo userInfo, string categoryCode, string[] objectIds, out string returnStatusCode,out string returnStatusMessage)
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
            bool returnValue = true;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    // 打开数据库
                    dbHelper.Open(WorkFlowDbConnection);
                   
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    string processId = string.Empty;
                    for (int i = 0; i < objectIds.Length; i++)
                    {
                        processId = workFlowCurrentManager.GetCurrentId(categoryCode, objectIds[i]);
                        if (string.IsNullOrEmpty(processId))
                        {
                            // 批量审批时需要返回false 含有自由流是不能批量审批的。
                            if (i > 0)
                            {                               
                                returnStatusMessage = "你选中的记录里包含自由审批流程所以不能批量审批。";
                            }
                            return false;
                        }
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

        #region public string GetCurrentId(BaseUserInfo userInfo, string categoryId, string objectId) 获取工作流主键
        /// <summary>
        /// 获取工作流主键
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="categoryId">类型主键</param>
        /// <param name="objectId">单据主键</param>
        /// <returns></returns>
        public string GetCurrentId(BaseUserInfo userInfo, string categoryId, string objectId)
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
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    // 打开数据库
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    returnValue = workFlowCurrentManager.GetCurrentId(categoryId, objectId);
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

        #region public string AuditStatr(BaseUserInfo userInfo, string categoryCode, string categoryFullName, string[] objectIds, string objectFullName, string workFlowCode, string auditIdea, out string returnStatusCode, DataTable dtWorkFlowActivity = null) 提交审批(步骤流)
        /// <summary>
        /// 提交审批(步骤流)
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="categoryCode">单据类型代码</param>
        /// <param name="categoryFullName">单据类型名称</param>
        /// <param name="objectIds">单据主键组</param>
        /// <param name="objectFullName">单据名称</param>
        /// <param name="workFlowCode">工作流编号</param>
        /// <param name="auditIdea">审批意见</param>
        /// <param name="returnStatusCode">返回码</param>
        /// <param name="dtWorkFlowActivity">步骤列表</param>
        /// <returns></returns>
        public string AuditStatr(BaseUserInfo userInfo, string categoryCode, string categoryFullName, string[] objectIds, string objectFullName, string workFlowCode, string auditIdea, out string returnStatusCode, DataTable dtWorkFlowActivity = null)
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
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    // 默认的都按报表来处理，特殊的直接调用，明确指定
                    IWorkFlowManager userReportManager = new UserReportManager(userInfo);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    // 事物开始
                    dbHelper.BeginTransaction();
                    for (int i = 0; i < objectIds.Length; i++)
                    {
                        returnValue = workFlowCurrentManager.AutoStatr(userReportManager, objectIds[i], objectFullName, categoryCode, categoryFullName, workFlowCode, auditIdea, dtWorkFlowActivity);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                    // 提交事务
                    dbHelper.CommitTransaction();
                    if (!string.IsNullOrEmpty(returnValue))
                    {
                        returnStatusCode = StatusCode.OK.ToString();
                    }
                }
                catch (Exception ex)
                {
                    // 回滚事务
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

            return returnValue;
        }
        #endregion

        #region public int AuditPass(BaseUserInfo userInfo, string[] flowIds, string auditIdea) 自动工作流审核通过
        /// <summary>
        /// 自动工作流审核通过
        /// </summary>
        /// <param name="flowIds">当前流程主键组</param>
        /// <param name="auditIdea">提交意见</param>
        /// <returns>影响行数</returns>
        public int AuditPass(BaseUserInfo userInfo, string[] flowIds, string auditIdea)
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
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    IWorkFlowManager userReportManager = new UserReportManager(userInfo);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    dbHelper.BeginTransaction();
                    returnValue = workFlowCurrentManager.AutoAuditPass(flowIds, auditIdea);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
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

            return returnValue;
        }
        #endregion

        #region public int AuditTransmit(BaseUserInfo userInfo,string id,  string workFlowCategory, string sendToUserId) 下个流程发送给谁
        /// <summary>
        /// 下个流程发送给谁
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">当前主键</param>
        /// <param name="sendToUserId">用户主键</param>
        /// <param name="auditIdea">审核意见</param>
        /// <returns>数据权限</returns>
        public int AuditTransmit(BaseUserInfo userInfo, string id, string workFlowCategory, string sendToUserId, string auditIdea)
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
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    dbHelper.BeginTransaction();
                    returnValue = workFlowCurrentManager.AuditTransmit(id,workFlowCategory, sendToUserId, auditIdea);
                    dbHelper.CommitTransaction();
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
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

            return returnValue;
        }
        #endregion

        #region public int AuditReject(BaseUserInfo userInfo, string[] ids, string auditIdea)
        /// <summary>
        /// 审核退回
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">当前主键</param>
        /// <param name="auditIdea">审核建议</param>
        /// <returns>数据权限</returns>
        public int AuditReject(BaseUserInfo userInfo, string[] ids, string auditIdea)
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
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    dbHelper.BeginTransaction();
                    returnValue = workFlowCurrentManager.AuditReject(ids, auditIdea);
                    dbHelper.CommitTransaction();
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
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

            return returnValue;
        }
        #endregion

        #region public int AuditQuash(BaseUserInfo userInfo, string string[] currentWorkFlowIds, string auditIdea) 撤消审批流程中的单据
        /// <summary>
        /// 撤消审批流程中的单据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="currentWorkFlowId">当前工作流主键</param>
        /// <param name="auditIdea">撤销意见</param>
        /// <returns>影响行数</returns>
        public int AuditQuash(BaseUserInfo userInfo, string[] currentWorkFlowIds, string auditIdea)
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
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    dbHelper.BeginTransaction();
                    returnValue = workFlowCurrentManager.AuditQuash(currentWorkFlowIds, auditIdea);
                    dbHelper.CommitTransaction();
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
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

            return returnValue;
        }
        #endregion

        #region public int AuditComplete(BaseUserInfo userInfo, string id, string auditIdea) 最终审核通过
        /// <summary>
        /// 最终审核通过
        /// </summary>
        /// <param name="userInfo">当前用户</param>
        /// <param name="id">主键</param>
        /// <param name="auditIdea">审核意见</param>
        /// <returns>影响行数</returns>
        public int AuditComplete(BaseUserInfo userInfo, string[] ids, string auditIdea)
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
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    //IWorkFlowManager userReportManager = new UserReportManager(userInfo);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    dbHelper.BeginTransaction();                  
                    returnValue += workFlowCurrentManager.AuditComplete(ids, auditIdea);
                    dbHelper.CommitTransaction();
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
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

            return returnValue;
        }
        #endregion

        #region public DataTable GetDataTable(BaseUserInfo BaseUserInfo) 获取流程当前步骤列表
        /// <summary>
        /// 获取流程当前步骤列表
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

            DataTable dataTable = new DataTable(BaseWorkFlowCurrentEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                    parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowCurrentEntity.FieldEnabled, 1));
                    parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowCurrentEntity.FieldDeletionStateCode, 0));
                    dataTable = workFlowCurrentManager.GetDataTable(parameters, BaseWorkFlowCurrentEntity.FieldSendDate);
                    dataTable.TableName = BaseWorkFlowCurrentEntity.TableName;
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

        #region public DataTable GetMonitorPagedDT(BaseUserInfo userInfo, int pageSize, int pageIndex, out int recordCount, string categoryCode = null, string searchValue = null) 按分页获取监控列表
        /// <summary>
        /// 按分页获取监控列表
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">第几页</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="categoryCode">类型</param>
        /// <param name="searchValue">查找内容</param>
        /// <returns></returns>
        public DataTable GetMonitorPagedDT(BaseUserInfo userInfo, int pageSize, int pageIndex, out int recordCount, string categoryCode = null, string searchValue = null)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = null;
            recordCount = 0;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    if (userInfo.IsAdministrator)
                    {
                        // 不分页
                        dataTable = workFlowCurrentManager.GetDataTable(new KeyValuePair<string, object>(BaseWorkFlowCurrentEntity.FieldDeletionStateCode, 0), BaseWorkFlowCurrentEntity.FieldSendDate);
                        // 分页
                        // dataTable = workFlowCurrentManager.GetPagedDT(pageSize, pageIndex, out recordCount, categoryCode, searchValue);
                    }
                    else
                    {
                        //dataTable = workFlowCurrentManager.GetMonitorDT();
                        dataTable = workFlowCurrentManager.GetMonitorPagedDT(pageSize,pageIndex,out recordCount,categoryCode,searchValue);
                    }
                    dataTable.TableName = BaseWorkFlowCurrentEntity.TableName;
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

        #region public DataTable GetMonitorDT(BaseUserInfo userInfo) 获取监控列表
        /// <summary>
        /// 获取监控列表
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <returns></returns>
        public DataTable GetMonitorDT(BaseUserInfo userInfo)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = null;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    if (userInfo.IsAdministrator)
                    {
                        dataTable = workFlowCurrentManager.GetDataTable(new KeyValuePair<string, object>(BaseWorkFlowCurrentEntity.FieldDeletionStateCode, 0), BaseWorkFlowCurrentEntity.FieldSendDate);
                    }
                    else
                    {
                        dataTable = workFlowCurrentManager.GetMonitorDT();
                    }
                    dataTable.TableName = BaseWorkFlowCurrentEntity.TableName;
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

        #region public DataTable GetWaitForAudit(BaseUserInfo userInfo,string userId = null, string categoryCode = null, string categorybillFullName = null, string searchValue = null) 获取待审批
        /// <summary>
        /// 获取待审批
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="userId">用户主键</param>
        /// <param name="categoryCode">分类代码</param>      
        /// <param name="categorybillFullName">单据分类名称</param>
        /// <param name="searchValue">查询字符串</param>
        /// <returns></returns>
        public DataTable GetWaitForAudit(BaseUserInfo userInfo, string userId = null, string categoryCode = null, string categorybillFullName = null, string searchValue = null)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = null;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    // 这个是获取用户的角色信息
                    dbHelper.Open(UserCenterDbConnection);
                    BaseUserManager userManager = new BaseUserManager(dbHelper);
                    string[] roleIds = userManager.GetAllRoleIds(userInfo.Id);
                    dbHelper.Close();
                    // 这里是获取待审核信息
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    dataTable = workFlowCurrentManager.GetWaitForAudit(userId, categoryCode, categorybillFullName, searchValue);
                    dataTable.TableName = BaseWorkFlowCurrentEntity.TableName;
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

        #region public DataTable GetAuditDetailDT(BaseUserInfo userInfo, string categoryId, string objectId) 获取审核历史明细
        /// <summary>
        /// 获取审核历史明细 
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryId">单据分类主键</param>
        /// <param name="objectId">单据主键</param>
        /// <returns>数据权限</returns>
        public DataTable GetAuditDetailDT(BaseUserInfo userInfo, string categoryId, string objectId)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = null;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    string[] ids = workFlowCurrentManager.GetIds(new KeyValuePair<string, object>(BaseWorkFlowCurrentEntity.FieldCategoryCode, categoryId), new KeyValuePair<string, object>(BaseWorkFlowCurrentEntity.FieldObjectId, objectId));
                    BaseWorkFlowHistoryManager workFlowHistoryManager = new BaseWorkFlowHistoryManager(dbHelper, userInfo);
                    dataTable = workFlowHistoryManager.GetDataTable(BaseWorkFlowHistoryEntity.FieldCurrentFlowId, ids, BaseWorkFlowHistoryEntity.FieldCreateOn);
                    dataTable.TableName = BaseWorkFlowCurrentEntity.TableName;
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

        #region public int Replace(BaseUserInfo userInfo, string oldCode, string newCode) 替换工作审核者
        /// <summary>
        /// 替换工作审核者
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="oldCode">原来的工号</param>
        /// <param name="newCode">新的工号</param>
        /// <returns>影响行数</returns>
        public int Replace(BaseUserInfo userInfo, string oldCode, string newCode)
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
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    returnValue = workFlowCurrentManager.ReplaceUser(oldCode, newCode);
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

        /// <summary>
        /// 获取已审核流程列表
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="categoryCode">单据类型</param>
        /// <param name="categorybillFullName">流程</param>
        /// <param name="searchValue">关键字</param>
        /// <returns></returns>
        public DataTable GetAuditRecord(BaseUserInfo userInfo, string categoryCode, string categorybillFullName = null, string searchValue = null)
        {
             // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = null;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    dataTable = workFlowCurrentManager.GetAuditRecord(categoryCode, categorybillFullName, searchValue);
                    dataTable.TableName = BaseWorkFlowCurrentEntity.TableName;
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

        //----------------------------------------------------------------------------
        //                                  自由流 
        //----------------------------------------------------------------------------

        #region public string AuditFreeStart(BaseUserInfo userInfo, string categoryCode, string categoryFullName, string[] objectIds, string objectFullName, string objectId, string workFlowCode, string toUserId, string toDepartmentId, string toRoleId, string auditIdea, out string returnStatusCode)
        /// <summary>
        /// 提交审批（自由流）
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="categoryCode"></param>
        /// <param name="categoryFullName"></param>
        /// <param name="objectIds"></param>
        /// <param name="objectFullName"></param>
        /// <param name="objectId"></param>
        /// <param name="workFlowCode"></param>
        /// <param name="toUserId"></param>
        /// <param name="toDepartmentId"></param>
        /// <param name="toRoleId"></param>
        /// <param name="auditIdea"></param>
        /// <param name="returnStatusCode"></param>
        /// <returns></returns>
        public string AuditFreeStart(BaseUserInfo userInfo, string categoryCode, string categoryFullName, string[] objectIds, string objectFullName, string objectId, string workFlowCode, string toUserId, string toDepartmentId, string toRoleId, string auditIdea, out string returnStatusCode)
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
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    // 默认的都按报表来处理，特殊的直接调用，明确指定
                    IWorkFlowManager workFlowManager = new BaseUserBillManager(userInfo);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    // 事物开始
                    dbHelper.BeginTransaction();
                    for (int i = 0; i < objectIds.Length; i++)
                    {
                        returnValue = workFlowCurrentManager.FreeStart(workFlowManager, objectIds[i], objectFullName, categoryCode, categoryFullName, workFlowCode, toUserId, toDepartmentId, toRoleId, auditIdea);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                    // 提交事务
                    dbHelper.CommitTransaction();
                    if (!string.IsNullOrEmpty(returnValue))
                    {
                        returnStatusCode = StatusCode.OK.ToString();
                    }
                }
                catch (Exception ex)
                {
                    // 回滚事务
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

            return returnValue;
        }
        #endregion

        #region public int FreeAuditPass(BaseUserInfo userInfo,string flowId,string workFlowCategory, string toId, string toFullName, string auditIdea) 自由工作流审核通过
        /// <summary>
        /// 自由工作流审核通过
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="flowId">工作流主键</param>
        /// <param name="workFlowCategory">类型</param>
        /// <param name="toId">发送给主键</param>
        /// <param name="toFullName">发送给名称</param>
        /// <param name="auditIdea">意见</param>
        /// <returns></returns>
        public int FreeAuditPass(BaseUserInfo userInfo, string flowId, string workFlowCategory, string toId, string toFullName, string auditIdea)
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
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    IWorkFlowManager userReportManager = new UserReportManager(userInfo);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    dbHelper.BeginTransaction();
                    returnValue = workFlowCurrentManager.FreeAuditPass(userReportManager, flowId,workFlowCategory, toId, toFullName, auditIdea);
                    dbHelper.CommitTransaction();
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());                   
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

            return returnValue;
        }
        #endregion
    }
}