//-------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Hairihan TECH, Ltd. 
//-------------------------------------------------------------------------------------

using System;
using System.Data;
using System.Reflection;

namespace DotNet.Service
{
    using DotNet.BaseManager;
    using DotNet.Manager;
    using DotNet.DbUtilities;
    using DotNet.Model;
    using DotNet.Utilities;
    using DotNet.IService;

    /// <summary>
    /// WorkReportService
    /// 
    /// 修改纪录
    /// 
    ///     2008.06.09 版本:1.2 吉日嘎拉 CheckWorkDate的修改
    ///     2008.05.21 版本:1.1 吉日嘎拉 GetDTByUser的修改
    ///     2008.05.17 版本:1.1 吉日嘎拉 审核管理添加姓名查询
    ///     2008.05.16 版本:1.1 吉日嘎拉 主键优化
    ///     2008.05.15 版本:1.0 吉日嘎拉 添加新数据字段项目主键，对于部分主键进行修改
    ///     2008.05.08 版本:1.0 吉日嘎拉 公司主键及部门主键两个数据字段的添加,对于部分主键进行修改
    ///     2008.04.30 版本:1.0 吉日嘎拉 创建主键
    /// 
    /// 版本:1.2
    /// 
    /// <author>
    ///     <name>吉日嘎拉</name>
    ///     <date>2008.04.30</date>
    /// </author>
    /// </summary>
    public class WorkReportService : System.MarshalByRefObject, IWorkReportService
    {
        /// <summary>
        /// 用户中心数据库连接
        /// </summary>
        private readonly string UserCenterDbConnection = BaseSystemInfo.UserCenterDbConnection;

        #region public DataTable GetDT(BaseUserInfo userInfo, string id) 获取一个工作日志列表
        /// <summary>
        /// 获取一个工作日志列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDT(BaseUserInfo userInfo, string id)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif
            DataTable ReturnDataTable = new DataTable(BaseWorkReportTable.TableName);

            IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open(UserCenterDbConnection);
                // 创建实现类
                BaseWorkReportManager workReporManager = new BaseWorkReportManager(dbHelper, userInfo);
                ReturnDataTable = workReporManager.Get(id);
                BaseLogManager.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
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
            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return ReturnDataTable;
        }
        #endregion

        #region public DataTable GetDTByUser(BaseUserInfo userInfo, string DepartmentId, string userId) 获取职员工作日志
        /// <summary>
        /// 获取职员工作日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">职员主键</param>
        /// <param name="date">日期</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByUser(BaseUserInfo userInfo, string staffId, string date)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif
            DataTable dataTable = new DataTable(BaseWorkReportTable.TableName);

            IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open(UserCenterDbConnection);
                BaseWorkReportManager workReportManager = new BaseWorkReportManager(dbHelper, userInfo);
                dataTable = workReportManager.GetDTByUser(staffId, date);
                BaseLogManager.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
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

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return dataTable;
        }
        #endregion

        #region public int Update(BaseUserInfo userInfo, DataTable dataTable, out string statusCode, out string statusMessage) 更新工作日志信息
        /// <summary>
        ///  更新工作日志信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>影响行数</returns>
        public int Update(BaseUserInfo userInfo, DataTable dataTable, out string statusCode, out string statusMessage)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif
            statusCode = string.Empty;
            statusMessage = string.Empty;

            int returnValue = 0;
            IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open(UserCenterDbConnection);
                BaseWorkReportEntity PermissionEntity = new BaseWorkReportEntity(dataTable);
                BaseWorkReportManager workReportManager = new BaseWorkReportManager(dbHelper, userInfo);
                returnValue = workReportManager.Update(PermissionEntity, out statusCode);
                // 获得状态消息
                statusMessage = workReportManager.GetStateMessage(statusCode);
                BaseLogManager.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
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

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return returnValue;
        }
        #endregion

        #region public string Add(BaseUserInfo userInfo, DataTable dataTable, out string statusCode, out string statusMessage) 工作日志添加
        /// <summary>
        /// 工作日志添加
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>主键</returns>
        public string Add(BaseUserInfo userInfo, DataTable dataTable, out string statusCode, out string statusMessage)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif
            statusCode = string.Empty;
            statusMessage = string.Empty;

            string returnValue = string.Empty;
            IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open(UserCenterDbConnection);
                BaseWorkReportEntity WorkReportEntity = new BaseWorkReportEntity(dataTable);
                BaseWorkReportManager workReportManager = new BaseWorkReportManager(dbHelper, userInfo);
                returnValue = workReportManager.Add(WorkReportEntity, out statusCode);
                // 获得状态消息
                statusMessage = workReportManager.GetStateMessage(statusCode);
                // 写入日志
                BaseLogManager.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
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

            // 写入调试信息
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
        /// <param name="ids">主键</param>
        /// <returns>影响行数</returns>
        public int BatchDelete(BaseUserInfo userInfo, string[] ids)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            int returnValue = 0;
            IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open(UserCenterDbConnection);
                BaseWorkReportManager workReportManager = new BaseWorkReportManager(dbHelper, userInfo);
                returnValue = workReportManager.BatchDelete(ids);
                BaseLogManager.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
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

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return returnValue;
        }
        #endregion

        #region public DataTable SearchAuditing(BaseUserInfo userInfo, DateTime startDate, DateTime endDate, int enabled) 查询审核列表
        /// <summary>
        /// 查询审核列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="enabled">有效</param>
        /// <returns>数据表</returns>
        public DataTable SearchAuditing(BaseUserInfo userInfo, DateTime startDate, DateTime endDate, int enabled)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif
            DataTable dataTable = new DataTable(BaseWorkReportTable.TableName);

            IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open(UserCenterDbConnection);
                BaseWorkReportManager workReportManager = new BaseWorkReportManager(dbHelper, userInfo);
                dataTable = workReportManager.Search(enabled, startDate, endDate);                
                BaseLogManager.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
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

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return dataTable;
        }
        #endregion

        #region public int BatchSetEnabled(BaseUserInfo userInfo, string[] ids, int enabled) 设置审核状态
        /// <summary>
        /// 批量设置审核状态
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <param name="enabled">有效</param>
        /// <returns>影响行数</returns>
        public bool BatchSetEnabled(BaseUserInfo userInfo, string[] ids, int enabled)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif
            bool returnValue = false;

            IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open(UserCenterDbConnection);
                BaseWorkReportManager workReportManager = new BaseWorkReportManager(dbHelper, userInfo);
                returnValue= workReportManager.SetProperty(ids, BaseWorkReportTable.FieldEnabled, enabled) > 0 ? true : false;
                // 设置审核者主键
                workReportManager.SetProperty(ids, BaseWorkReportTable.FieldAuditStaffId, userInfo.Id);
                BaseLogManager.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
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

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return returnValue;
        }
        #endregion

        #region public DataTable BatchSave(BaseUserInfo userInfo, DataTable dataTable, int enabled, string staffFullName) 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <param name="enabled">有效性</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns>数据表</returns>
        public DataTable BatchSave(BaseUserInfo userInfo, DataTable dataTable, int enabled, DateTime startDate, DateTime endDate)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            DataTable ReturnDataTable = new DataTable(BaseWorkReportTable.TableName);
            IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open(UserCenterDbConnection);
                // 创建实现类
                BaseWorkReportManager workReportManager = new BaseWorkReportManager(dbHelper, userInfo);
                workReportManager.BatchSave(dataTable);
                ReturnDataTable = workReportManager.Search(enabled, startDate, endDate);
                BaseLogManager.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
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

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return ReturnDataTable;
        }
        #endregion

        #region public DataTable GetProjectDT(BaseUserInfo userInfo) 获取项目列表
        /// <summary>
        ///  获取项目列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetProjectDT(BaseUserInfo userInfo)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            DataTable dataTable = null;
            IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open(UserCenterDbConnection);
                dataTable = dbHelper.Fill("SELECT * FROM Base_Project");
                BaseLogManager.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
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

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return dataTable;
        }
        #endregion

        #region public string GetProjectFullName(BaseUserInfo userInfo, string id) 获取项目全称
        /// <summary>
        /// 获取项目全称
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>项目全称</returns>
        public string GetProjectFullName(BaseUserInfo userInfo, string id)
        {
             // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif
            string returnValue = string.Empty;

            IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open(UserCenterDbConnection);
                BaseProjectManager projectManager = new BaseProjectManager(dbHelper, userInfo);
                returnValue = projectManager.GetFullName(id);
                BaseLogManager.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
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

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return returnValue;
        }
        #endregion

        #region public DateTime[] CheckWorkDate(BaseUserInfo userInfo, string paramStaffId) 检查工作日志
        /// <summary>
        /// 检查工作日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="paramstaffId">当前查询职员主键</param>
        /// <returns>日期数组</returns>
        public DateTime[] CheckWorkDate(BaseUserInfo userInfo, string paramStaffId)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            DateTime[] returnValue = new DateTime[31];
            IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open(UserCenterDbConnection);
                // 创建实现类
                BaseWorkReportManager workReportManager = new BaseWorkReportManager(dbHelper, userInfo);
                returnValue = workReportManager.CheckWorkDate(paramStaffId);
                BaseLogManager.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
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

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return returnValue;
        }
        #endregion

        #region public Double SumManHour(BaseUserInfo userInfo, string paramStaffId, DateTime paramDate)
        /// <summary>
        /// 求某天工时之和
        /// </summary>
        /// <param name="userInfo">当前操作员信息</param>
        /// <param name="paramStaffID">职员主键</param>
        /// <param name="paramDate">日期</param>
        /// <returns>工时之和</returns>
        public Double SumManHour(BaseUserInfo userInfo, string paramStaffId, DateTime paramDate)
        {
             // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            Double returnValue=0.0;
            IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open(UserCenterDbConnection);
                // 创建实现类
                BaseWorkReportManager workReportManager = new BaseWorkReportManager(dbHelper, userInfo);
                returnValue = workReportManager.SumManHour(paramStaffId, paramDate);
                BaseLogManager.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
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

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return returnValue;
        }
        #endregion
    }
}
