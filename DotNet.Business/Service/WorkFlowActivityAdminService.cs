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
    /// WorkFlowActivityAdminService
    /// 工作流定义服务
    /// 
    /// 修改纪录
    /// 
    ///         2007.07.05 版本：1.0 完成了窗体加载、批量删除、关闭、写入日志功能
    ///		
    /// 版本：1.0
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.07.05</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class WorkFlowActivityAdminService : System.MarshalByRefObject,IWorkFlowActivityAdminService
    {
        private string serviceName = AppMessage.WorkFlowActivityAdminService;

        /// <summary>
        /// 用户中心数据库连接
        /// </summary>
        private readonly string WorkFlowDbConnection = BaseSystemInfo.WorkFlowDbConnection;

        #region public DataTable GetDataTable(BaseUserInfo BaseUserInfo, string workFlowId) 获取工作流步骤定义列表
        /// <summary>
        /// 获取工作流步骤定义列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">工作流主键</param> 
        /// <returns>数据表</returns>
        public DataTable GetDataTable(BaseUserInfo userInfo, string workFlowId)
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
                    BaseWorkFlowActivityManager workFlowActivityManager = new BaseWorkFlowActivityManager(dbHelper, userInfo);

                    List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                    parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowStepEntity.FieldWorkFlowId, workFlowId));
                    parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowStepEntity.FieldEnabled, 1));
                    parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowStepEntity.FieldDeletionStateCode, 0));

                    dataTable = workFlowActivityManager.GetDataTable(parameters, BaseWorkFlowActivityEntity.FieldSortCode);
                    dataTable.TableName = BaseWorkFlowActivityEntity.TableName;
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

        /// <summary>
        /// 添加工作流
        /// </summary>
        /// <param name="userInfo">当前用户</param>
        /// <param name="workFlowActivityEntity">工作流定义实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>主键</returns>
        public string Add(BaseUserInfo userInfo, BaseWorkFlowActivityEntity workFlowActivityEntity)
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
                    // 数据库事务开始
                    // dbHelper.BeginTransaction();
                    BaseWorkFlowActivityManager workFlowActivityManager = new BaseWorkFlowActivityManager(dbHelper, userInfo);
                    returnValue = workFlowActivityManager.Add(workFlowActivityEntity);
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

        #region public int BatchDelete(BaseUserInfo userInfo, string[] ids) 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">选种的数组</param>
        /// <returns>数据权限</returns>
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
                    BaseWorkFlowActivityManager WorkFlowActivity = new BaseWorkFlowActivityManager(dbHelper, userInfo);
                    returnValue = WorkFlowActivity.Delete(ids);
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
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowActivityManager workFlowActivityManager = new BaseWorkFlowActivityManager(dbHelper, userInfo);
                    returnValue = workFlowActivityManager.BatchSave(dataTable);
                    // dataTable = Role.GetDataTableByOrganize(organizeId);
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
    }
}