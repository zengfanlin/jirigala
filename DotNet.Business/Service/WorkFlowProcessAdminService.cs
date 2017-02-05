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
    /// WorkFlowProcessAdminService
    /// 工作流处理过程服务
    /// 
    /// 修改纪录
    /// 
    ///		2007.06.26 版本：1.0 JiRiGaLa 窗体与数据库连接的分离。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.06.26</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class WorkFlowProcessAdminService : System.MarshalByRefObject, IWorkFlowProcessAdminService
    {
        private string serviceName = AppMessage.WorkFlowProcessAdminService;

        /// <summary>
        /// 用户中心数据库连接
        /// </summary>
        private readonly string WorkFlowDbConnection = BaseSystemInfo.WorkFlowDbConnection;

        /// <summary>
        /// 添加工作流
        /// </summary>
        /// <param name="userInfo">当前用户</param>
        /// <param name="workFlowProcessEntity">工作流定义实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>主键</returns>
        public string Add(BaseUserInfo userInfo, BaseWorkFlowProcessEntity workFlowProcessEntity, out string statusCode, out string statusMessage)
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
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    // 数据库事务开始
                    // dbHelper.BeginTransaction();
                    BaseWorkFlowProcessManager workFlowManager = new BaseWorkFlowProcessManager(dbHelper, userInfo);
                    returnValue = workFlowManager.Add(workFlowProcessEntity, out statusCode);
                    // 获得状态消息
                    statusMessage = workFlowManager.GetStateMessage(statusCode);
                    // 写入日志信息
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                    // 数据库事务提交
                    // dbHelper.CommitTransaction();
                }
                catch (Exception ex)
                {
                    // 数据库事务回滚
                    // dbHelper.RollbackTransaction();
                    // 记录异常信息
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

        public BaseWorkFlowProcessEntity GetEntity(BaseUserInfo userInfo, string id)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            BaseWorkFlowProcessEntity workFlowEntity = new BaseWorkFlowProcessEntity();
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    // 创建实现类
                    BaseWorkFlowProcessManager workFlowManager = new BaseWorkFlowProcessManager(dbHelper, userInfo);
                    workFlowEntity = workFlowManager.GetEntity(id);
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

            return workFlowEntity;
        }

        public int Update(BaseUserInfo userInfo, BaseWorkFlowProcessEntity workFlowProcessEntity, out string statusCode, out string statusMessage)
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
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowProcessManager workFlowManager = new BaseWorkFlowProcessManager(dbHelper, userInfo);
                    returnValue = workFlowManager.Update(workFlowProcessEntity, out statusCode);
                    // 获得状态消息
                    statusMessage = workFlowManager.GetStateMessage(statusCode);
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


        #region public DataTable GetDataTable(BaseUserInfo BaseUserInfo,string id = null) 获取数据
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTable(BaseUserInfo userInfo,string id = null)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseWorkFlowProcessEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowProcessManager workFlowManager = new BaseWorkFlowProcessManager(dbHelper, userInfo);
                    if (string.IsNullOrEmpty(id))
                    {
                        dataTable = workFlowManager.GetDataTable(new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldDeletionStateCode, 0), BaseWorkFlowProcessEntity.FieldSortCode);
                    }
                    else
                    {
                        dataTable = workFlowManager.GetDataTable(id);
                    }                    
                    //dataTable = workFlowManager.GetDataTable();
                    dataTable.TableName = BaseWorkFlowProcessEntity.TableName;
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

        #region public int Delete(BaseUserInfo userInfo, string id) 单个删除工作流
        /// <summary>
        /// 单个删除工作流
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <param name="organizeId">组织主键</param> 
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
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowProcessManager WorkFlowProcess = new BaseWorkFlowProcessManager(dbHelper, userInfo);
                    returnValue = WorkFlowProcess.Delete(id);
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

        #region public int BatchDelete(BaseUserInfo userInfo, string[] ids) 批量删除组织机构
        /// <summary>
        /// 批量删除组织机构
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
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowProcessManager WorkFlowProcess = new BaseWorkFlowProcessManager(dbHelper, userInfo);
                    returnValue = WorkFlowProcess.Delete(ids);
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

        #region public int BatchSave(BaseUserInfo userInfo, DataTable dataTable) 批量保存权限
        /// <summary>
        /// 批量保存权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <returns>数据表</returns>
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
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowProcessManager workFlowManager = new BaseWorkFlowProcessManager(dbHelper, userInfo);
                    returnValue = workFlowManager.BatchSave(dataTable);
                    // this.ReturnStatusMessage = workFlowManager.ReturnStatusMessage;
                    // this.ReturnStatusCode = workFlowManager.ReturnStatusCode;
                    // ReturnDataTable = workFlowManager.GetDataTable();
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
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowProcessManager workFlowManager = new BaseWorkFlowProcessManager(dbHelper, userInfo);
                    returnValue = workFlowManager.SetDeleted(ids);
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

        #region public DataTable GetBillTemplateDT(BaseUserInfo userInfo) 获取表单模板类型
        /// <summary>
        /// 获取表单模板类型
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public DataTable GetBillTemplateDT(BaseUserInfo userInfo)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseWorkFlowBillTemplateEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowBillTemplateManager templateManager = new BaseWorkFlowBillTemplateManager(dbHelper, userInfo);
                    dataTable = templateManager.GetDataTable(new KeyValuePair<string, object>(BaseWorkFlowBillTemplateEntity.FieldDeletionStateCode, 0), BaseWorkFlowBillTemplateEntity.FieldSortCode);
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

        #region public string GetProcessId(BaseUserInfo userInfo, string workFlowCode) 获取具体的审批流程
        /// <summary>
        /// 获取具体的审批流程
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="workFlowCode">工作流程编号</param>
        /// <returns>流程</returns>
        public string GetProcessId(BaseUserInfo userInfo, string workFlowCode)
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
                    dbHelper.Open(WorkFlowDbConnection);                 
                    BaseWorkFlowProcessManager workFlowManager = new BaseWorkFlowProcessManager(dbHelper, userInfo);
                    returnValue = workFlowManager.GetProcessId(userInfo, workFlowCode);                  
                    // 写入日志信息
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());                   
                }
                catch (Exception ex)
                {
                    // 记录异常信息
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
        /// 查询
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="userId"></param>
        /// <param name="categoryCode"></param>
        /// <param name="searchValue"></param>
        /// <param name="enabled"></param>
        /// <param name="deletionStateCode"></param>
        /// <returns></returns>
        public DataTable Search(BaseUserInfo userInfo, string userId, string categoryCode, string searchValue, bool? enabled, bool? deletionStateCode)
        {
             // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseWorkFlowBillTemplateEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowBillTemplateManager templateManager = new BaseWorkFlowBillTemplateManager(dbHelper, userInfo);
                    dataTable = templateManager.Search(userId, categoryCode, searchValue, enabled, deletionStateCode);
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


    }
}