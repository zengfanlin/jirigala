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
    /// PermissionService
    /// 权限判断服务
    /// 
    /// 修改纪录
    /// 
    ///		2011.09.26 版本：3.2 JiRiGaLa 整理一些范围函数名。
    ///		2011.06.04 版本：3.1 JiRiGaLa 整理日志功能。
    ///		2009.09.25 版本：3.0 JiRiGaLa Resource.ManagePermission 自动判断增加。
    ///		2008.12.12 版本：2.0 JiRiGaLa 进行了彻底的改进。
    ///		2008.05.30 版本：1.0 JiRiGaLa 创建权限判断服务。
    ///		
    /// 版本：3.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.06.04</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public partial class PermissionService : System.MarshalByRefObject, IPermissionService
    {
        private string serviceName = AppMessage.PermissionService;

        /// <summary>
        /// 用户中心数据库连接
        /// </summary>
        private readonly string UserCenterDbConnection = BaseSystemInfo.UserCenterDbConnection;

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 用户权限判断相关(需要实现对外调用)
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        #region public bool IsInRole(BaseUserInfo userInfo, string userId, string roleName)
        /// <summary>
        /// 用户是否在指定的角色里
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="UserId">用户主键</param>
        /// <param name="roleName">角色名称</param>
        /// <returns>在角色里</returns>
        public bool IsInRole(BaseUserInfo userInfo, string userId, string roleName)
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
                    // 先获得角色主键
                    BaseRoleManager roleManager = new BaseRoleManager(dbHelper, userInfo);
                    string roleCode = roleManager.GetProperty(new KeyValuePair<string, object>(BaseRoleEntity.FieldRealName, roleName), BaseRoleEntity.FieldCode);
                    // 判断用户的默认角色
                    if (!string.IsNullOrEmpty(roleCode))
                    {
                        BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                        returnValue = userManager.IsInRoleByCode(userId, roleCode);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_IsInRole, MethodBase.GetCurrentMethod());
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

        #region public bool IsAuthorized(BaseUserInfo userInfo, string permissionItemCode, string permissionItemName = null)
        /// <summary>
        /// 当前用户是否有相应的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <param name="permissionItemName">权限名称</param>
        /// <returns>是否有权限</returns>
        public bool IsAuthorized(BaseUserInfo userInfo, string permissionItemCode, string permissionItemName = null)
        {
            return IsAuthorizedByUser(userInfo, userInfo.Id, permissionItemCode, permissionItemName);
        }
        #endregion

        #region public bool IsAuthorizedByUser(BaseUserInfo userInfo, string userId, string permissionItemCode, string permissionItemName = null)
        /// <summary>
        /// 某个用户是否有相应的操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <param name="permissionItemName">权限名称</param>
        /// <returns>是否有权限</returns>
        public bool IsAuthorizedByUser(BaseUserInfo userInfo, string userId, string permissionItemCode, string permissionItemName = null)
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
                    if (string.IsNullOrEmpty(userId))
                    {
                        userId = userInfo.Id;
                    }
                    #if (!DEBUG)
                        // 是超级管理员,就不用继续判断权限了
                        BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                        returnValue = userManager.IsAdministrator(userId);
                        if (returnValue)
                        {
                            return returnValue;
                        }
                    #endif

                    BasePermissionManager permissionManager = new BasePermissionManager(dbHelper, userInfo);
                    returnValue = permissionManager.CheckPermissionByUser(userId, permissionItemCode, permissionItemName);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_IsAuthorizedByUser, MethodBase.GetCurrentMethod());
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

        #region public bool IsAuthorizedByRole(BaseUserInfo userInfo, string roleId, string permissionItemCode)
        /// <summary>
        /// 某个角色是否有相应的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>是否有权限</returns>
        public bool IsAuthorizedByRole(BaseUserInfo userInfo, string roleId, string permissionItemCode)
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
                    // 是超级管理员,就不用继续判断权限了
                    returnValue = roleId.Equals("Administrators");
                    if (returnValue)
                    {
                        return returnValue;
                    }
                    BasePermissionManager permissionManager = new BasePermissionManager(dbHelper, userInfo);
                    returnValue = permissionManager.CheckPermissionByRole(roleId, permissionItemCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_IsAuthorizedByRole, MethodBase.GetCurrentMethod());
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

        #region public bool IsAdministrator(BaseUserInfo userInfo)
        /// <summary>
        /// 当前用户是否超级管理员
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns>是超级管理员</returns>
        public bool IsAdministrator(BaseUserInfo userInfo)
        {
            return IsAdministratorByUser(userInfo, userInfo.Id);
        }
        #endregion

        #region public bool IsAdministratorByUser(BaseUserInfo userInfo, string userId)
        /// <summary>
        /// 某个用户是否超级管理员
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="userId"></param>
        /// <returns>是超级管理员</returns>
        public bool IsAdministratorByUser(BaseUserInfo userInfo, string userId)
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
                    returnValue = userManager.IsAdministrator(userId);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_IsAdministratorByUser, MethodBase.GetCurrentMethod());
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

        #region public DataTable GetPermissionDT(BaseUserInfo userInfo)
        /// <summary>
        /// 获得当前用户的所有权限列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetPermissionDT(BaseUserInfo userInfo)
        {
            return GetPermissionDTByUser(userInfo, userInfo.Id);
        }
        #endregion

        #region public DataTable GetPermissionDTByUser(BaseUserInfo userInfo, string userId)
        /// <summary>
        /// 获得某个用户的所有权限列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>数据表</returns>
        public DataTable GetPermissionDTByUser(BaseUserInfo userInfo, string userId)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BasePermissionItemEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    string tableName = BasePermissionItemEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionItem";
                    }
                    // 是否超级管理员
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(dbHelper, userInfo, tableName);
                    if (userManager.IsAdministrator(userId))
                    {
                        dataTable = permissionItemManager.GetDataTable();
                    }
                    else
                    {
                        tableName = BasePermissionEntity.TableName;
                        if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                        {
                            tableName = BaseSystemInfo.SystemCode + "Permission";
                        }
                        BasePermissionManager permissionManager = new BasePermissionManager(dbHelper, userInfo, tableName);
                        string[] ids = permissionManager.GetPermissionIdsByUser(userId);
                        // 若是以前赋予的权限，后来有些权限设置为无效了，那就不应该再获取哪些无效的权限才对。
                        // bug修正：没有赋值DataTable，导致返回值空
                        dataTable = permissionItemManager.GetDataTable(
                            new KeyValuePair<string, object>(BasePermissionItemEntity.FieldId, ids)
                            , new KeyValuePair<string, object>(BasePermissionItemEntity.FieldEnabled, 1)
                            , new KeyValuePair<string, object>(BasePermissionItemEntity.FieldDeletionStateCode, 0));
                    }
                    dataTable.TableName = tableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetPermissionDTByUser, MethodBase.GetCurrentMethod());
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

        #region public string[] GetModuleIdsByUser(BaseUserInfo userInfo, string userId)
        /// <summary>
        /// 获取用户有权限访问的模块主键
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>主键数组</returns>
        public string[] GetModuleIdsByUser(BaseUserInfo userInfo, string userId)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            string[] returnValue = null;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseModuleManager moduleManager = new BaseModuleManager(dbHelper, userInfo);
                    if (userInfo.IsAdministrator)
                    {
                        // 有效的，未被删除的显示出来
                        returnValue = moduleManager.GetIds(new KeyValuePair<string, object>(BaseModuleEntity.FieldDeletionStateCode, 0), new KeyValuePair<string, object>(BaseModuleEntity.FieldEnabled, 1));
                    }
                    else
                    {
                        returnValue = moduleManager.GetIdsByUser(userId);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetModuleDTByUser, MethodBase.GetCurrentMethod());
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

        #region public DataTable GetModuleDT(BaseUserInfo userInfo)
        /// <summary>
        /// 获得用户有权限的模块
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetModuleDT(BaseUserInfo userInfo)
        {
            return GetModuleDTByUser(userInfo, userInfo.Id);
        }
        #endregion

        #region public DataTable GetModuleDTByUser(BaseUserInfo userInfo, string userId)
        /// <summary>
        /// 获得用户有访问权限的模块
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>数据表</returns>
        public DataTable GetModuleDTByUser(BaseUserInfo userInfo, string userId)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseModuleEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    string tableName = BaseModuleEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "Module";
                    }
                    BaseModuleManager moduleManager = new BaseModuleManager(dbHelper, userInfo, tableName);
                    if (userInfo.IsAdministrator)
                    {
                        List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                        parameters.Add(new KeyValuePair<string, object>(BaseModuleEntity.FieldEnabled, 1));
                        parameters.Add(new KeyValuePair<string, object>(BaseModuleEntity.FieldDeletionStateCode, 0));
                        // 有效的，未被删除的显示出来
                        dataTable = moduleManager.GetDataTable(parameters, BaseModuleEntity.FieldSortCode);
                    }
                    else
                    {
                        dataTable = moduleManager.GetDataTableByUser(userId);
                    }
                    // 若不是员工，有些菜单可以去掉的功能，加在这里
                    if (string.IsNullOrEmpty(userInfo.StaffId))
                    {
                        BaseBusinessLogic.Delete(dataTable, BaseModuleEntity.FieldCode, "FrmStaffAddressEdit");
                        dataTable.AcceptChanges();
                    }
                    dataTable.TableName = BaseModuleEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetModuleDTByUser, MethodBase.GetCurrentMethod());
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

        #region public bool IsModuleAuthorized(BaseUserInfo userInfo, string moduleCode)
        /// <summary>
        /// 当前用户是否对某个模块有相应的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleCode">模块编号</param>
        /// <returns>是否有权限</returns>
        public bool IsModuleAuthorized(BaseUserInfo userInfo, string moduleCode)
        {
            return IsModuleAuthorizedByUser(userInfo, userInfo.Id, moduleCode);
        }
        #endregion

        #region public bool IsModuleAuthorizedByUser(BaseUserInfo userInfo, string userId, string moduleCode)
        /// <summary>
        /// 某个用户是否对某个模块有相应的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="moduleCode">模块编号</param>
        /// <returns>是否有权限</returns>
        public bool IsModuleAuthorizedByUser(BaseUserInfo userInfo, string userId, string moduleCode)
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
                    // 是否超级管理员
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    if (userManager.IsAdministrator(userId))
                    {
                        return true;
                    }
                    else
                    {
                        BaseModuleManager moduleManager = new BaseModuleManager(dbHelper, userInfo);
                        DataTable dataTable = moduleManager.GetDataTableByUser(userId);
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            if (dataRow[BaseModuleEntity.FieldCode].ToString().Equals(moduleCode))
                            {
                                returnValue = true;
                                break;
                            }
                        }
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_IsModuleAuthorizedByUser, MethodBase.GetCurrentMethod());
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

        #region public bool IsModuleAuthorizedByUser(BaseUserInfo userInfo, string userId, string moduleCode, string permissionItemCode)
        /// <summary>
        /// 某个用户是否对某个模块有相应的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="moduleCode">模块编号</param>
        /// <returns>是否有权限</returns>
        public bool IsModuleAuthorizedByUser(BaseUserInfo userInfo, string userId, string moduleCode, string permissionItemCode)
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
                    // 是超级管理员,就不用继续判断权限了
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    returnValue = userManager.IsAdministrator(userId);
                    if (returnValue)
                    {
                        return returnValue;
                    }
                    BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(dbHelper);
                    returnValue = permissionScopeManager.IsModuleAuthorized(userId, moduleCode, permissionItemCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_IsModuleAuthorizedByUser, MethodBase.GetCurrentMethod());
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

        #region public PermissionScope GetUserPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode)
        /// <summary>
        /// 获得用户的数据权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">数据权限编号</param>
        /// <returns>数据权限范围</returns>
        public PermissionScope GetUserPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            PermissionScope returnValue = PermissionScope.None;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    // 是超级管理员,就不用继续判断权限了
                    BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(dbHelper, userInfo);
                    returnValue = permissionScopeManager.GetUserPermissionScope(userId, permissionItemCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetUserPermissionScope, MethodBase.GetCurrentMethod());
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