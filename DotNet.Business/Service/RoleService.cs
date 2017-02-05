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
    /// RoleService
    /// 角色管理服务
    /// 
    /// 修改纪录
    /// 
    ///     2010.03.12 版本：1.5 JiRiGaLa 程序注释整理、函数整理、函数顺序等。
    ///     2008.04.09 版本：1.4 JiRiGaLa 重新整理主键。
    ///     2007.06.11 版本：1.3 JiRiGaLa 加入调试信息#if (DEBUG)。
    ///     2007.06.04 版本：1.2 JiRiGaLa 加入WebService。
    ///     2007.05.29 版本：1.1 JiRiGaLa 排版，修改，完善。
    ///		2007.05.11 版本：1.0 JiRiGaLa 窗体与数据库连接的分离。
    ///		
    /// 版本：1.3
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.06.11</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public partial class RoleService : System.MarshalByRefObject, IRoleService
    {
        private string serviceName = AppMessage.RoleService;

        /// <summary>
        /// 用户中心数据库连接
        /// </summary>
        private readonly string UserCenterDbConnection = BaseSystemInfo.UserCenterDbConnection;

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>主键</returns>
        public string Add(BaseUserInfo userInfo, BaseRoleEntity roleEntity, out string statusCode, out string statusMessage)
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
                    dbHelper.BeginTransaction();
                    string tableName = BaseRoleEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "Role";
                    }
                    BaseRoleManager roleManager = new BaseRoleManager(dbHelper, userInfo, tableName);
                    returnValue = roleManager.Add(roleEntity, out statusCode);
                    statusMessage = roleManager.GetStateMessage(statusCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, serviceName, AppMessage.RoleService_Add, MethodBase.GetCurrentMethod());
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

        #region public DataTable GetDataTable(BaseUserInfo userInfo) 获取角色列表
        /// <summary>
        /// 获取角色列表
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

            DataTable dataTable = new DataTable(BaseRoleEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    string tableName = BaseRoleEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "Role";
                    }
                    // 获得角色列表
                    BaseRoleManager roleManager = new BaseRoleManager(dbHelper, userInfo, tableName);

                    List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                    parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldDeletionStateCode, 0));
                    parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldEnabled, 1));
                    parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldIsVisible, 1));

                    dataTable = roleManager.GetDataTable(parameters, BaseRoleEntity.FieldSortCode);
                    dataTable.TableName = BaseRoleEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, serviceName, AppMessage.RoleService_GetDataTable, MethodBase.GetCurrentMethod());
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
        /// 获取默认角色列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetDefaultRoleDT(BaseUserInfo userInfo)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                BaseSystemInfo.IsAuthorized(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseRoleEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    // 获得角色列表
                    BaseRoleManager roleManager = new BaseRoleManager(dbHelper, userInfo);
                    List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                    parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldCategoryCode, "DefaultRole"));
                    parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldDeletionStateCode, 0));
                    parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldIsVisible, 1));
                    dataTable = roleManager.GetDataTable(parameters, BaseRoleEntity.FieldSortCode);
                    dataTable.TableName = BaseRoleEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, serviceName, AppMessage.RoleService_GetDataTable, MethodBase.GetCurrentMethod());
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
        /// 获取业务角色列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetApplicationRole(BaseUserInfo userInfo)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                BaseSystemInfo.IsAuthorized(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseRoleEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    string tableName = BaseRoleEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "Role";
                    }
                    // 获得角色列表
                    BaseRoleManager roleManager = new BaseRoleManager(dbHelper, userInfo, tableName);
                    List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                    parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldCategoryCode, "ApplicationRole"));
                    parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldDeletionStateCode, 0));
                    parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldIsVisible, 1));
                    dataTable = roleManager.GetDataTable(parameters, BaseRoleEntity.FieldSortCode);
                    dataTable.TableName = tableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, serviceName, AppMessage.RoleService_GetDataTable, MethodBase.GetCurrentMethod());
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
        /// 获取用户群组列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetUserGroup(BaseUserInfo userInfo)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                BaseSystemInfo.IsAuthorized(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseRoleEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    string tableName = BaseRoleEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "Role";
                    }
                    // 获得角色列表
                    BaseRoleManager roleManager = new BaseRoleManager(dbHelper, userInfo, tableName);
                    List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                    parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldCategoryCode, "UserGroup"));
                    parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldDeletionStateCode, 0));
                    parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldIsVisible, 1));
                    parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldCreateUserId, userInfo.Id));
                    dataTable = roleManager.GetDataTable(parameters, BaseRoleEntity.FieldSortCode);
                    dataTable.TableName = tableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, serviceName, AppMessage.RoleService_GetDataTable, MethodBase.GetCurrentMethod());
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
        /// 按组织机构获取角色列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByOrganize(BaseUserInfo userInfo, string organizeId)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseRoleEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    string tableName = BaseRoleEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "Role";
                    }
                    // 获得角色列表
                    BaseRoleManager roleManager = new BaseRoleManager(dbHelper, userInfo, tableName);
                    dataTable = roleManager.GetDataTableByOrganize(organizeId);
                    dataTable.TableName = BaseRoleEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, serviceName, AppMessage.RoleService_GetDataTableByOrganize, MethodBase.GetCurrentMethod());
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
        /// 按角色名获取角色列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">角色名</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByRoleName(BaseUserInfo userInfo, string roleName)
        {
            // 写入调试信息
#if (DEBUG)
            int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
#endif

            // 加强安全验证防止未授权匿名调用
#if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
#endif

            DataTable dataTable = new DataTable(BaseRoleEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    string tableName = BaseRoleEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "Role";
                    }
                    // 获得角色列表
                    BaseRoleManager roleManager = new BaseRoleManager(dbHelper, userInfo, tableName);
                    dataTable = roleManager.GetDataTableByName(roleName);
                    dataTable.TableName = BaseRoleEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, serviceName, AppMessage.RoleService_GetDataTableByOrganize, MethodBase.GetCurrentMethod());
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
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        public BaseRoleEntity GetEntity(BaseUserInfo userInfo, string id)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            BaseRoleEntity roleEntity = null;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    string tableName = BaseRoleEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "Role";
                    }
                    BaseRoleManager roleManager = new BaseRoleManager(dbHelper, userInfo, tableName);
                    roleEntity = roleManager.GetEntity(id);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, serviceName, AppMessage.RoleService_GetEntity, MethodBase.GetCurrentMethod());
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

            return roleEntity;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>影响行数</returns>
        public int Update(BaseUserInfo userInfo, BaseRoleEntity roleEntity, out string statusCode, out string statusMessage)
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
                    dbHelper.BeginTransaction();
                    string tableName = BaseRoleEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "Role";
                    }
                    BaseRoleManager roleManager = new BaseRoleManager(dbHelper, userInfo, tableName);
                    returnValue = roleManager.Update(roleEntity, out statusCode);
                    statusMessage = roleManager.GetStateMessage(statusCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, serviceName, AppMessage.RoleService_Update, MethodBase.GetCurrentMethod());
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

        /// <summary>
        /// 按主键数组获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">角色主键</param>
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

            DataTable dataTable = new DataTable(BaseRoleEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    string tableName = BaseRoleEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "Role";
                    }
                    BaseRoleManager roleManager = new BaseRoleManager(dbHelper, userInfo, tableName);
                    dataTable = roleManager.GetDataTable(BaseRoleEntity.FieldId, ids, BaseRoleEntity.FieldSortCode);
                    dataTable.TableName = BaseRoleEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, serviceName, AppMessage.RoleService_GetDataTableByIds, MethodBase.GetCurrentMethod());
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
        /// 查询角色列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="search">查询字符串</param>
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

            DataTable dataTable = new DataTable(BaseRoleEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    string tableName = BaseRoleEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "Role";
                    }
                    // 获得角色列表
                    BaseRoleManager roleManager = new BaseRoleManager(dbHelper, userInfo, tableName);
                    dataTable = roleManager.Search(organizeId, searchValue);
                    dataTable.TableName = BaseRoleEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, serviceName, AppMessage.RoleService_Search, MethodBase.GetCurrentMethod());
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
        /// 批量保存角色
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleEntites">角色列表</param>
        /// <returns>影响行数</returns>
        public int BatchSave(BaseUserInfo userInfo, List<BaseRoleEntity> roleEntites)
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
                    dbHelper.BeginTransaction();
                    string tableName = BaseRoleEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "Role";
                    }
                    BaseRoleManager roleManager = new BaseRoleManager(dbHelper, userInfo, tableName);
                    returnValue = roleManager.BatchSave(roleEntites);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, serviceName, AppMessage.RoleService_BatchSave, MethodBase.GetCurrentMethod());
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
        
        /// <summary>
        /// 移动角色数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <param name="targetId">目标主键</param>
        /// <returns>影响行数</returns>
        public int MoveTo(BaseUserInfo userInfo, string id, string targetId)
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
                    string tableName = BaseRoleEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "Role";
                    }
                    BaseRoleManager roleManager = new BaseRoleManager(dbHelper, userInfo, tableName);
                    returnValue = roleManager.MoveTo(id, targetId);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, serviceName, AppMessage.RoleService_MoveTo, MethodBase.GetCurrentMethod());
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
        /// 批量移动角色数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <param name="targetId">目标主键</param>
        /// <returns>影响行数</returns>
        public int BatchMoveTo(BaseUserInfo userInfo, string[] ids, string targetId)
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
                    string tableName = BaseRoleEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "Role";
                    }
                    BaseRoleManager roleManager = new BaseRoleManager(dbHelper, userInfo, tableName);
                    returnValue = roleManager.BatchMoveTo(ids, targetId);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, serviceName, AppMessage.RoleService_BatchMoveTo, MethodBase.GetCurrentMethod());
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
        /// 排序角色顺序
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>影响行数</returns>
        public int ResetSortCode(BaseUserInfo userInfo, string organizeId)
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
                    string tableName = BaseRoleEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "Role";
                    }
                    BaseRoleManager roleManager = new BaseRoleManager(dbHelper, userInfo, tableName);
                    returnValue = roleManager.ResetSortCode(organizeId);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, serviceName, AppMessage.RoleService_ResetSortCode, MethodBase.GetCurrentMethod());
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
        /// 删除角色
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
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
                    string tableName = BaseRoleEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "Role";
                    }
                    BaseRoleManager roleManager = new BaseRoleManager(dbHelper, userInfo, tableName);
                    returnValue = roleManager.Delete(id);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, serviceName, AppMessage.RoleService_Delete, MethodBase.GetCurrentMethod());
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
        /// 批量删除角色
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
                    // 开始数据库事务
                    dbHelper.BeginTransaction();
                    string tableName = BaseRoleEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "Role";
                    }
                    BaseRoleManager roleManager = new BaseRoleManager(dbHelper, userInfo, tableName);
                    returnValue = roleManager.BatchDelete(ids);
                    // 提交数据库事务
                    BaseLogManager.Instance.Add(dbHelper, userInfo, serviceName, AppMessage.RoleService_BatchDelete, MethodBase.GetCurrentMethod());
                    dbHelper.CommitTransaction();
                }
                catch (Exception ex)
                {
                    // 撤销数据库事务
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

        /// <summary>
        /// 批量打角色删除标志
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
                    string tableName = BaseRoleEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "Role";
                    }
                    BaseRoleManager roleManager = new BaseRoleManager(dbHelper, userInfo, tableName);

                    switch (DbHelper.DbType)
                    {
                        case CurrentDbType.Access:
                            
                            // 考虑主键是数值类型的，支持Access//xtzwd
                            int[] keys = BaseBusinessLogic.GetIntKeys(ids);
                            returnValue = roleManager.SetDeleted(keys, true);
                            break;
                        default:
                            returnValue = roleManager.SetDeleted(ids, true);
                            break;
                    }                    
                    
                    BaseLogManager.Instance.Add(dbHelper, userInfo, serviceName, AppMessage.RoleService_SetDeleted, MethodBase.GetCurrentMethod());
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