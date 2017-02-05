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
    ///		2012.03.22 版本：1.0 JiRiGaLa 创建权限判断服务。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.03.22</date>
    /// </author> 
    /// </summary>
    public partial class PermissionService : System.MarshalByRefObject, IPermissionService
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 用户权限范围判断相关(需要实现对外调用)
        //////////////////////////////////////////////////////////////////////////////////////////////////////


        #region public DataTable GetOrganizeDTByPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode, bool childrens = true)
        /// <summary>
        /// 按某个权限域获取组织列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">数据权限编号</param>
        /// <param name="childrens">获取子节点</param>
        /// <returns>数据表</returns>
        public DataTable GetOrganizeDTByPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode = "Resource.ManagePermission", bool childrens = true)
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

                    // 若权限是空的，直接返回所有数据
                    if (String.IsNullOrEmpty(permissionItemCode))
                    {
                        BaseOrganizeManager organizeManager = new BaseOrganizeManager(dbHelper, userInfo);
                        dataTable = organizeManager.GetDataTable();
                        dataTable.DefaultView.Sort = BaseOrganizeEntity.FieldSortCode;
                    }
                    else
                    {
                        // 获得组织机构列表
                        BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(dbHelper, userInfo);
                        dataTable = permissionScopeManager.GetOrganizeDT(userInfo.Id, permissionItemCode, childrens);
                        dataTable.DefaultView.Sort = BaseOrganizeEntity.FieldSortCode;
                    }
                    dataTable.TableName = BaseOrganizeEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetOrganizeDTByPermission, MethodBase.GetCurrentMethod());
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

        #region public string[] GetOrganizeIdsByPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode)
        /// <summary>
        /// 按某个数据权限获取组织主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">数据权限编号</param>
        /// <returns>主键数组</returns>
        public string[] GetOrganizeIdsByPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode)
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
                    // 若权限是空的，直接返回所有数据
                    if (String.IsNullOrEmpty(permissionItemCode))
                    {
                        return returnValue;
                    }
                    // 获得组织机构列表
                    BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(dbHelper, userInfo);
                    returnValue = permissionScopeManager.GetOrganizeIds(userId, permissionItemCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetOrganizeIdsByPermission, MethodBase.GetCurrentMethod());
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

        #region public DataTable GetRoleDTByPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode)
        /// <summary>
        /// 按某个权限域获取角色列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">数据权限编号</param>
        /// <returns>数据表</returns>
        public DataTable GetRoleDTByPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode)
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
                    // 若权限是空的，直接返回所有数据
                    if (userInfo.IsAdministrator || String.IsNullOrEmpty(permissionItemCode))
                    {
                        // 获得角色列表
                        BaseRoleManager roleManager = new BaseRoleManager(dbHelper, userInfo);
                        List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                        parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldIsVisible, 1));
                        parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldDeletionStateCode, 0));
                        dataTable = roleManager.GetDataTable(parameters, BaseRoleEntity.FieldSortCode);
                    }
                    else
                    {
                        // 获得组织机构列表
                        BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(dbHelper, userInfo);
                        dataTable = permissionScopeManager.GetRoleDT(userInfo.Id, permissionItemCode);
                    }
                    dataTable.TableName = BaseRoleEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetRoleDTByPermission, MethodBase.GetCurrentMethod());
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

        #region public string[] GetRoleIdsByPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode)
        /// <summary>
        /// 按某个数据权限获取角色主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">数据权限编号</param>
        /// <returns>主键数组</returns>
        public string[] GetRoleIdsByPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode)
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
                    // 若权限是空的，直接返回所有数据
                    if (String.IsNullOrEmpty(permissionItemCode))
                    {
                        return returnValue;
                    }
                    // 获得角色主键数组
                    BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(dbHelper, userInfo);
                    returnValue = permissionScopeManager.GetRoleIds(userId, permissionItemCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetRoleIdsByPermission, MethodBase.GetCurrentMethod());
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

        #region public DataTable GetUserDTByPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode)
        /// <summary>
        /// 按某个权限域获取用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">数据权限编号</param>
        /// <returns>数据表</returns>
        public DataTable GetUserDTByPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode)
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
                    // 获得组织机构列表
                    BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(dbHelper, userInfo);
                    // 若权限是空的，直接返回所有数据
                    if (!String.IsNullOrEmpty(permissionItemCode))
                    {
                        dataTable = permissionScopeManager.GetUserDT(userInfo.Id, permissionItemCode);
                    }
                    dataTable.TableName = BaseUserEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetUserDTByPermission, MethodBase.GetCurrentMethod());
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

        #region public string[] GetUserIdsByPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode)
        /// <summary>
        /// 按某个数据权限获取用户主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">数据权限编号</param>
        /// <returns>主键数组</returns>
        public string[] GetUserIdsByPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode)
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
                    // 若权限是空的，直接返回所有数据
                    if (String.IsNullOrEmpty(permissionItemCode))
                    {
                        return returnValue;
                    }
                    // 获得用户主键数组
                    BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(dbHelper, userInfo);
                    returnValue = permissionScopeManager.GetUserIds(userId, permissionItemCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetUserIdsByPermission, MethodBase.GetCurrentMethod());
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

        #region public DataTable GetModuleDTByPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode)
        /// <summary>
        /// 按某个权限域获取模块列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限域编号</param>
        /// <returns>数据表</returns>
        public DataTable GetModuleDTByPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode)
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
                    BaseModuleManager moduleManager = new BaseModuleManager(dbHelper, userInfo);
                    dataTable = moduleManager.GetDataTableByPermission(userId, permissionItemCode);
                    dataTable.TableName = BaseModuleEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetModuleDTByPermission, MethodBase.GetCurrentMethod());
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

        #region public DataTable GetPermissionItemDTByPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode)
        /// <summary>
        /// 用户的所有可授权范围(有授权权限的权限列表)
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限域编号</param>
        /// <returns>数据表</returns>
        public DataTable GetPermissionItemDTByPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode)
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
                    BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(dbHelper, userInfo);
                    string permissionItemId = permissionItemManager.GetId(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldCode, permissionItemCode));
                    // 数据库里没有设置可授权的权限项，系统自动增加一个权限配置项
                    if (String.IsNullOrEmpty(permissionItemId) && permissionItemCode.Equals("Resource.ManagePermission"))
                    {
                        BasePermissionItemEntity permissionItemEntity = new BasePermissionItemEntity();
                        permissionItemEntity.Code = "Resource.ManagePermission";
                        permissionItemEntity.FullName = "资源管理范围权限（系统默认）";
                        permissionItemEntity.IsScope = 1;
                        permissionItemEntity.Enabled = 1;
                        permissionItemEntity.AllowDelete = 0;
                        permissionItemEntity.AllowDelete = 0;
                        permissionItemManager.AddEntity(permissionItemEntity);
                    }
                    dataTable = permissionItemManager.GetDataTableByUser(userId, permissionItemCode);
                    dataTable.TableName = BasePermissionItemEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetPermissionItemDTByPermission, MethodBase.GetCurrentMethod());
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