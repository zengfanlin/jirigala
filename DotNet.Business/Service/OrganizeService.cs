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
    /// OrganizeService
    /// 组织机构服务
    /// 
    /// 修改纪录
    /// 
    ///		2007.08.15 版本：2.2 JiRiGaLa 改进运行速度采用 WebService 变量定义 方式处理数据。
    ///		2007.08.14 版本：2.1 JiRiGaLa 改进运行速度采用 Instance 方式处理数据。
    ///     2007.06.11 版本：1.3 JiRiGaLa 加入调试信息#if (DEBUG)。
    ///     2007.06.04 版本：1.2 JiRiGaLa 加入WebService。
    ///     2007.05.29 版本：1.1 JiRiGaLa 排版，修改，完善。
    ///		2007.05.11 版本：1.0 JiRiGaLa 窗体与数据库连接的分离。
    ///	
    /// 版本：2.2
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.08.15</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class OrganizeService : System.MarshalByRefObject, IOrganizeService
    {
        private string serviceName = AppMessage.OrganizeService;

        /// <summary>
        /// 用户中心数据库连接
        /// </summary>
        private readonly string UserCenterDbConnection = BaseSystemInfo.UserCenterDbConnection;

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeEntity">实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>主键</returns>
        public string Add(BaseUserInfo userInfo, BaseOrganizeEntity organizeEntity, out string statusCode, out string statusMessage)
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
                    BaseOrganizeManager organizeManager = new BaseOrganizeManager(dbHelper, userInfo);
                    returnValue = organizeManager.Add(organizeEntity, out statusCode);
                    statusMessage = organizeManager.GetStateMessage(statusCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.OrganizeService_Add, MethodBase.GetCurrentMethod());
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

        /// <summary>
        /// 按详细情况添加实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="parentId">父主键</param>
        /// <param name="code">编号</param>
        /// <param name="fullName">全称</param>
        /// <param name="categoryId">分类</param>
        /// <param name="outerPhone">外线</param>
        /// <param name="innerPhone">内线</param>
        /// <param name="fax">传真</param>
        /// <param name="enabled">有效</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>主键</returns>
        public string AddByDetail(BaseUserInfo userInfo, string parentId, string code, string fullName, string categoryId, string outerPhone, string innerPhone, string fax, bool enabled, out string statusCode, out string statusMessage)
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
                    BaseOrganizeManager organizeManager = new BaseOrganizeManager(dbHelper, userInfo);
                    returnValue = organizeManager.AddByDetail(parentId, code, fullName, categoryId, outerPhone, innerPhone, fax, enabled, out statusCode);
                    statusMessage = organizeManager.GetStateMessage(statusCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.OrganizeService_AddByDetail, MethodBase.GetCurrentMethod());
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

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        public BaseOrganizeEntity GetEntity(BaseUserInfo userInfo, string id)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                BaseSystemInfo.IsAuthorized(userInfo);
            #endif

            BaseOrganizeEntity organizeEntity = null;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseOrganizeManager organizeManager = new BaseOrganizeManager(dbHelper, userInfo);
                    organizeEntity = organizeManager.GetEntity(id);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.OrganizeService_GetEntity, MethodBase.GetCurrentMethod());
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
            return organizeEntity;
        }

        /// <summary>
        /// 获取部门列表
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
                BaseSystemInfo.IsAuthorized(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseOrganizeEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    // 获得组织机构列表
                    BaseOrganizeManager organizeManager = new BaseOrganizeManager(dbHelper, userInfo);
                    dataTable = organizeManager.GetDataTable(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldDeletionStateCode, 0), BaseOrganizeEntity.FieldSortCode);
                    dataTable.DefaultView.Sort = BaseOrganizeEntity.FieldSortCode;
                    dataTable.TableName = BaseOrganizeEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.OrganizeService_GetDataTable, MethodBase.GetCurrentMethod());
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

            DataTable dataTable = new DataTable(BaseOrganizeEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseOrganizeManager organizeManager = new BaseOrganizeManager(dbHelper, userInfo);
                    dataTable = organizeManager.GetDataTable(BaseOrganizeEntity.FieldId, ids, BaseOrganizeEntity.FieldSortCode);
                    dataTable.TableName = BaseOrganizeEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, serviceName, AppMessage.OrganizeService_GetDataTable, MethodBase.GetCurrentMethod());
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
        /// 获取部门列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="parameters">参数</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTable(BaseUserInfo userInfo,List<KeyValuePair<string,object >> parameters)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                BaseSystemInfo.IsAuthorized(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseOrganizeEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    // 获得组织机构列表
                    BaseOrganizeManager organizeManager = new BaseOrganizeManager(dbHelper, userInfo);
                    dataTable = organizeManager.GetDataTable(parameters, BaseOrganizeEntity.FieldSortCode);
                    dataTable.DefaultView.Sort = BaseOrganizeEntity.FieldSortCode;
                    dataTable.TableName = BaseOrganizeEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.OrganizeService_GetDataTable, MethodBase.GetCurrentMethod());
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

        /// <summary>
        /// 按父节点获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="parentId">父节点</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByParent(BaseUserInfo userInfo, string parentId)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseOrganizeEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    // 获得组织机构列表
                    BaseOrganizeManager organizeManager = new BaseOrganizeManager(dbHelper, userInfo);

                    List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                    parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldParentId, parentId));
                    parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldEnabled, 1));
                    parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldDeletionStateCode, 0));

                    dataTable = organizeManager.GetDataTable(parameters, BaseOrganizeEntity.FieldSortCode);
                    dataTable.DefaultView.Sort = BaseOrganizeEntity.FieldSortCode;
                    dataTable.TableName = BaseOrganizeEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.OrganizeService_GetDataTableByParent, MethodBase.GetCurrentMethod());
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

        /// <summary>
        /// 获取内部组织机构
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构</param>
        /// <returns>数据表</returns>
        public DataTable GetInnerOrganizeDT(BaseUserInfo userInfo, string organizeId)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseOrganizeEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    // 获得组织机构列表
                    BaseOrganizeManager organizeManager = new BaseOrganizeManager(dbHelper, userInfo);
                    dataTable = organizeManager.GetInnerOrganize(organizeId);
                    dataTable.DefaultView.Sort = BaseOrganizeEntity.FieldSortCode;
                    dataTable.TableName = BaseOrganizeEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.OrganizeService_GetInnerOrganizeDT, MethodBase.GetCurrentMethod());
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

        /// <summary>
        /// 获取公司列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>数据表</returns>
        public DataTable GetCompanyDT(BaseUserInfo userInfo, string organizeId)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseOrganizeEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    // 获得组织机构列表
                    BaseOrganizeManager organizeManager = new BaseOrganizeManager(dbHelper, userInfo);
                    dataTable = organizeManager.GetCompanyDT(organizeId);
                    dataTable.DefaultView.Sort = BaseOrganizeEntity.FieldSortCode;
                    dataTable.TableName = BaseOrganizeEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.OrganizeService_GetCompanyDT, MethodBase.GetCurrentMethod());
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

        /// <summary>
        /// 获取公司列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构名称</param>
        /// <returns>数据表</returns>
        public DataTable GetCompanyDTByName(BaseUserInfo userInfo, string organizeName)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseOrganizeEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    // 获得组织机构列表
                    BaseOrganizeManager organizeManager = new BaseOrganizeManager(dbHelper, userInfo);
                    dataTable = organizeManager.GetCompanyDTByName(organizeName);
                    dataTable.DefaultView.Sort = BaseOrganizeEntity.FieldSortCode;
                    dataTable.TableName = BaseOrganizeEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.OrganizeService_GetCompanyDT, MethodBase.GetCurrentMethod());
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

        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构</param>
        /// <returns>数据表</returns>
        public DataTable GetDepartmentDT(BaseUserInfo userInfo, string organizeId)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseOrganizeEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    // 获得组织机构列表
                    BaseOrganizeManager organizeManager = new BaseOrganizeManager(dbHelper, userInfo);
                    dataTable = organizeManager.GetDepartmentDT(organizeId);
                    dataTable.DefaultView.Sort = BaseOrganizeEntity.FieldSortCode;
                    dataTable.TableName = BaseOrganizeEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.OrganizeService_GetDepartmentDT, MethodBase.GetCurrentMethod());
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

        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构名称</param>
        /// <returns>数据表</returns>
        public DataTable GetDepartmentDTByName(BaseUserInfo userInfo, string organizeName)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseOrganizeEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    // 获得组织机构列表
                    BaseOrganizeManager organizeManager = new BaseOrganizeManager(dbHelper, userInfo);
                    dataTable = organizeManager.GetDepartmentDTByName(organizeName);
                    dataTable.DefaultView.Sort = BaseOrganizeEntity.FieldSortCode;
                    dataTable.TableName = BaseOrganizeEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.OrganizeService_GetDepartmentDT, MethodBase.GetCurrentMethod());
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

        /// <summary>
        /// 查询组织机构
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构</param>
        /// <param name="searchValue">查询</param>
        /// <returns>数据表</returns>
        public DataTable Search(BaseUserInfo userInfo, string organizeId, string searchValue)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseOrganizeEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    // 获得组织机构列表
                    BaseOrganizeManager organizeManager = new BaseOrganizeManager(dbHelper, userInfo);
                    dataTable = organizeManager.Search(string.Empty, searchValue);
                    dataTable.DefaultView.Sort = BaseOrganizeEntity.FieldSortCode;
                    dataTable.TableName = BaseOrganizeEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.OrganizeService_Search, MethodBase.GetCurrentMethod());
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

        /// <summary>
        /// 更新组织机构
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeEntity">实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>影响行数</returns>
        public int Update(BaseUserInfo userInfo, BaseOrganizeEntity organizeEntity, out string statusCode, out string statusMessage)
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
                    BaseOrganizeManager organizeManager = new BaseOrganizeManager(dbHelper, userInfo);
                    returnValue = organizeManager.Update(organizeEntity, out statusCode);
                    statusMessage = organizeManager.GetStateMessage(statusCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.OrganizeService_Update, MethodBase.GetCurrentMethod());
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

        /// <summary>
        /// 删除数据
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
                    BaseOrganizeManager organizeManager = new BaseOrganizeManager(dbHelper, userInfo);
                    returnValue = organizeManager.Delete(id);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.OrganizeService_Delete, MethodBase.GetCurrentMethod());
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

        /// <summary>
        /// 批量删除数据
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
                    BaseOrganizeManager organizeManager = new BaseOrganizeManager(dbHelper, userInfo);
                    returnValue = organizeManager.Delete(ids);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.OrganizeService_BatchDelete, MethodBase.GetCurrentMethod());
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
                    BaseOrganizeManager organizeManager = new BaseOrganizeManager(dbHelper, userInfo);
                    for (int i = 0; i < ids.Length; i++ )
                    {
                        // 设置部门为删除状态
                        returnValue += organizeManager.SetDeleted(ids[i]);
                        // 相应的用户也需要处理
                        BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                        List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                        parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldCompanyId, null));
                        parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldCompanyName, null));
                        userManager.SetProperty(new KeyValuePair<string, object>(BaseUserEntity.FieldCompanyId, ids[i]), parameters);
                        parameters = new List<KeyValuePair<string, object>>();
                        parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldSubCompanyId, null));
                        parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldSubCompanyName, null));
                        userManager.SetProperty(new KeyValuePair<string, object>(BaseUserEntity.FieldSubCompanyId, ids[i]), parameters);
                        parameters = new List<KeyValuePair<string, object>>();
                        parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldDepartmentId, null));
                        parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldDepartmentName, null));
                        userManager.SetProperty(new KeyValuePair<string, object>(BaseUserEntity.FieldDepartmentId, ids[i]), parameters);
                        parameters = new List<KeyValuePair<string, object>>();
                        parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldWorkgroupId, null));
                        parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldWorkgroupName, null));
                        userManager.SetProperty(new KeyValuePair<string, object>(BaseUserEntity.FieldWorkgroupId, ids[i]), parameters);
                        // 相应的员工也需要处理
                        BaseStaffManager staffManager = new BaseStaffManager(dbHelper, userInfo);
                        staffManager.SetProperty(new KeyValuePair<string, object>(BaseStaffEntity.FieldCompanyId, ids[i]), new KeyValuePair<string, object>(BaseStaffEntity.FieldCompanyId, null));
                        staffManager.SetProperty(new KeyValuePair<string, object>(BaseStaffEntity.FieldSubCompanyId, ids[i]), new KeyValuePair<string, object>(BaseStaffEntity.FieldSubCompanyId, null));
                        staffManager.SetProperty(new KeyValuePair<string, object>(BaseStaffEntity.FieldDepartmentId, ids[i]), new KeyValuePair<string, object>(BaseStaffEntity.FieldDepartmentId, null));
                        staffManager.SetProperty(new KeyValuePair<string, object>(BaseStaffEntity.FieldWorkgroupId, ids[i]), new KeyValuePair<string, object>(BaseStaffEntity.FieldWorkgroupId, null));
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.OrganizeService_SetDeleted, MethodBase.GetCurrentMethod());
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

        /// <summary>
        /// 批量保存数据
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
                    BaseOrganizeManager organizeManager = new BaseOrganizeManager(dbHelper, userInfo);
                    returnValue = organizeManager.BatchSave(dataTable);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.OrganizeService_BatchSave, MethodBase.GetCurrentMethod());
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

        /// <summary>
        /// 移动数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构</param>
        /// <param name="parentId">父主键</param>
        /// <returns>影响行数</returns>
        public int MoveTo(BaseUserInfo userInfo, string organizeId, string parentId)
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
                    BaseOrganizeManager organizeManager = new BaseOrganizeManager(dbHelper, userInfo);
                    returnValue = organizeManager.MoveTo(organizeId, parentId);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.OrganizeService_MoveTo, MethodBase.GetCurrentMethod());
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

        /// <summary>
        /// 批量移动数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeIds">主键数组</param>
        /// <param name="parentId">父节点主键</param>
        /// <returns>影响行数</returns>
        public int BatchMoveTo(BaseUserInfo userInfo, string[] organizeIds, string parentId)
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
                    BaseOrganizeManager organizeManager = new BaseOrganizeManager(dbHelper, userInfo);
                    for (int i = 0; i < organizeIds.Length; i++)
                    {
                        returnValue += organizeManager.MoveTo(organizeIds[i], parentId);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.OrganizeService_BatchMoveTo, MethodBase.GetCurrentMethod());
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

        /// <summary>
        /// 批量重新生成编号
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键</param>
        /// <param name="codes">编号</param>
        /// <returns>影响行数</returns>
        public int BatchSetCode(BaseUserInfo userInfo, string[] ids, string[] codes)
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
                    BaseOrganizeManager organizeManager = new BaseOrganizeManager(dbHelper, userInfo);
                    returnValue = organizeManager.BatchSetCode(ids, codes);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.OrganizeService_BatchSetCode, MethodBase.GetCurrentMethod());
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

        /// <summary>
        /// 批量重新生成排序码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int BatchSetSortCode(BaseUserInfo userInfo, string[] ids)
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
                    BaseOrganizeManager organizeManager = new BaseOrganizeManager(dbHelper, userInfo);
                    returnValue = organizeManager.BatchSetSortCode(ids);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.OrganizeService_BatchSetSortCode, MethodBase.GetCurrentMethod());
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