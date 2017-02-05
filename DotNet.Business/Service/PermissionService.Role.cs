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
        /// 角色权限关联关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////


        #region public string[] GetRolePermissionItemIds(BaseUserInfo userInfo, string roleId)
        /// <summary>
        /// 获取角色权限主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>主键数组</returns>
        public string[] GetRolePermissionItemIds(BaseUserInfo userInfo, string roleId)
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
                    string tableName = BasePermissionEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "Permission";
                    }
                    BaseRolePermissionManager rolePermissionManager = new BaseRolePermissionManager(dbHelper, userInfo, tableName);
                    returnValue = rolePermissionManager.GetPermissionItemIds(roleId);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetRolePermissionItemIds, MethodBase.GetCurrentMethod());
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

        #region public string[] GetRoleIdsByPermission(BaseUserInfo userInfo, string permissionItemId)
        /// <summary>
        /// 获取角色主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemId">操作权限主键</param>
        /// <returns>主键数组</returns>
        public string[] GetRoleIdsByPermission(BaseUserInfo userInfo, string permissionItemId)
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
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                    BaseRolePermissionManager rolePermissionManager = new BaseRolePermissionManager(dbHelper, userInfo);
                    returnValue = rolePermissionManager.GetRoleIds(permissionItemId);
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

        #region public int GrantRolePermissions(BaseUserInfo userInfo, string[] roleIds, string[] grantPermissionItemIds)
        /// <summary>
        /// 授予角色的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleIds">角色主键数组</param>
        /// <param name="grantPermissionItemIds">授予权限数组</param>
        /// <returns>影响的行数</returns>
        public int GrantRolePermissions(BaseUserInfo userInfo, string[] roleIds, string[] grantPermissionItemIds)
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
                    string tableName = BasePermissionEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "Permission";
                    }
                    BaseRolePermissionManager rolePermissionManager = new BaseRolePermissionManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (roleIds != null && grantPermissionItemIds != null)
                    {
                        returnValue += rolePermissionManager.Grant(roleIds, grantPermissionItemIds);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GrantRolePermissions, MethodBase.GetCurrentMethod());
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

        #region public string GrantRolePermissionById(BaseUserInfo userInfo, string roleId, string grantPermissionItemId)
        /// <summary>
        /// 授予角色的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="grantPermissionItemId">授予权限数组</param>
        /// <returns>影响的行数</returns>
        public string GrantRolePermissionById(BaseUserInfo userInfo, string roleId, string grantPermissionItemId)
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
                    string tableName = BasePermissionEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "Permission";
                    }
                    BaseRolePermissionManager manager = new BaseRolePermissionManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (grantPermissionItemId != null)
                    {
                        returnValue = manager.Grant(roleId, grantPermissionItemId);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GrantRolePermissionById, MethodBase.GetCurrentMethod());
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

        #region public int RevokeRolePermissions(BaseUserInfo userInfo, string[] roleIds, string[] revokePermissionItemIds)
        /// <summary>
        /// 撤消角色的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleIds">角色主键数组</param>
        /// <param name="grantPermissionItemIds">授予权限数组</param>
        /// <param name="revokePermissionItemIds">撤消权限数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeRolePermissions(BaseUserInfo userInfo, string[] roleIds, string[] revokePermissionItemIds)
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
                    string tableName = BasePermissionEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "Permission";
                    }
                    BaseRolePermissionManager manager = new BaseRolePermissionManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (roleIds != null && revokePermissionItemIds != null)
                    {
                        returnValue += manager.Revoke(roleIds, revokePermissionItemIds);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_RevokeRolePermissions, MethodBase.GetCurrentMethod());
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

        #region public int ClearRolePermission(BaseUserInfo userInfo, string id)
        /// <summary>
        /// 清除角色权限
        /// 
        /// 1.清除角色的用户归属。
        /// 2.清除角色的模块权限。
        /// 3.清除角色的操作权限。
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
        public int ClearRolePermission(BaseUserInfo userInfo, string id)
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

                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    returnValue += userManager.ClearUser(id);

                    string tableName = BasePermissionEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "Permission";
                    }
                    BaseRolePermissionManager rolePermissionManager = new BaseRolePermissionManager(dbHelper, userInfo, tableName);
                    returnValue += rolePermissionManager.RevokeAll(id);

                    tableName = BasePermissionScopeEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionScope";
                    }
                    BaseRoleScopeManager roleScopeManager = new BaseRoleScopeManager(dbHelper, userInfo, tableName);
                    returnValue += roleScopeManager.RevokeAll(id);

                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_ClearRolePermission, MethodBase.GetCurrentMethod());
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

        #region public int RevokeRolePermissionById(BaseUserInfo userInfo, string roleId, string revokePermissionItemId)
        /// <summary>
        /// 撤消角色的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="revokePermissionItemId">撤消权限数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeRolePermissionById(BaseUserInfo userInfo, string roleId, string revokePermissionItemId)
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
                    string tableName = BasePermissionEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "Permission";
                    }
                    BaseRolePermissionManager manager = new BaseRolePermissionManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (revokePermissionItemId != null)
                    {
                        returnValue += manager.Revoke(roleId, revokePermissionItemId);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_RevokeRolePermissionById, MethodBase.GetCurrentMethod());
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

        #region public string[] GetRoleScopeUserIds(BaseUserInfo userInfo, string roleId, string permissionItemCode)
        /// <summary>
        /// 28.获取角色的某个权限域的组织范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键数组</returns>
        public string[] GetRoleScopeUserIds(BaseUserInfo userInfo, string roleId, string permissionItemCode)
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
                    string tableName = BasePermissionScopeEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionScope";
                    }
                    BaseRoleScopeManager roleScopeManager = new BaseRoleScopeManager(dbHelper, userInfo, tableName);
                    returnValue = roleScopeManager.GetUserIds(roleId, permissionItemCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetRoleScopeUserIds, MethodBase.GetCurrentMethod());
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

        #region public string[] GetRoleScopeRoleIds(BaseUserInfo userInfo, string roleId, string permissionItemCode)
        /// <summary>
        /// 28.获取角色的某个权限域的组织范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键数组</returns>
        public string[] GetRoleScopeRoleIds(BaseUserInfo userInfo, string roleId, string permissionItemCode)
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
                    string tableName = BasePermissionScopeEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionScope";
                    }
                    BaseRoleScopeManager roleScopeManager = new BaseRoleScopeManager(dbHelper, userInfo, tableName);
                    returnValue = roleScopeManager.GetRoleIds(roleId, permissionItemCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetRoleScopeRoleIds, MethodBase.GetCurrentMethod());
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

        #region public string[] GetRoleScopeOrganizeIds(BaseUserInfo userInfo, string roleId, string permissionItemCode)
        /// <summary>
        /// 获取角色的某个权限域的组织范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键数组</returns>
        public string[] GetRoleScopeOrganizeIds(BaseUserInfo userInfo, string roleId, string permissionItemCode)
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
                    string tableName = BasePermissionScopeEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionScope";
                    }
                    BaseRoleScopeManager roleScopeManager = new BaseRoleScopeManager(dbHelper, userInfo, tableName);
                    returnValue = roleScopeManager.GetOrganizeIds(roleId, permissionItemCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetRoleScopeOrganizeIds, MethodBase.GetCurrentMethod());
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

        #region public int GrantRoleUserScopes(BaseUserInfo userInfo, string roleId, string permissionItemId, string[] grantUserIds)
        /// <summary>
        /// 29.授予角色的某个权限域的组织范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <param name="grantUserIds">授予用户主键数组</param>
        /// <returns>影响的行数</returns>
        public int GrantRoleUserScopes(BaseUserInfo userInfo, string roleId, string permissionItemId, string[] grantUserIds)
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
                    string tableName = BasePermissionScopeEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionScope";
                    }
                    BaseRoleScopeManager roleScopeManager = new BaseRoleScopeManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (grantUserIds != null)
                    {
                        returnValue += roleScopeManager.GrantUsers(roleId, permissionItemId, grantUserIds);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GrantRoleUserScopes, MethodBase.GetCurrentMethod());
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

        #region public int RevokeRoleUserScopes(BaseUserInfo userInfo, string roleId, string permissionItemId, string[] revokeUserIds)
        /// <summary>
        /// 30.撤消角色的某个权限域的组织范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <param name="revokeUserIds">撤消的用户主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeRoleUserScopes(BaseUserInfo userInfo, string roleId, string permissionItemId, string[] revokeUserIds)
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
                    string tableName = BasePermissionScopeEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionScope";
                    }
                    BaseRoleScopeManager roleScopeManager = new BaseRoleScopeManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (revokeUserIds != null)
                    {
                        returnValue += roleScopeManager.RevokeUsers(roleId, permissionItemId, revokeUserIds);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_RevokeRoleUserScopes, MethodBase.GetCurrentMethod());
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

        #region public int GrantRoleRoleScopes(BaseUserInfo userInfo, string roleId, string permissionItemId, string[] grantRoleIds)
        /// <summary>
        /// 31.授予角色的某个权限域的组织范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <param name="grantRoleIds">授予角色主键数组</param>
        /// <returns>影响的行数</returns>
        public int GrantRoleRoleScopes(BaseUserInfo userInfo, string roleId, string permissionItemId, string[] grantRoleIds)
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
                    string tableName = BasePermissionScopeEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionScope";
                    }
                    BaseRoleScopeManager roleScopeManager = new BaseRoleScopeManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (grantRoleIds != null)
                    {
                        returnValue += roleScopeManager.GrantRoles(roleId, permissionItemId, grantRoleIds);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GrantRoleRoleScopes, MethodBase.GetCurrentMethod());
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

        #region public int RevokeRoleRoleScopes(BaseUserInfo userInfo, string roleId, string permissionItemId, string[] revokeRoleIds)
        /// <summary>
        /// 32.撤消角色的某个权限域的组织范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <param name="revokeRoleIds">撤消的角色主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeRoleRoleScopes(BaseUserInfo userInfo, string roleId, string permissionItemId, string[] revokeRoleIds)
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
                    string tableName = BasePermissionScopeEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionScope";
                    }
                    BaseRoleScopeManager roleScopeManager = new BaseRoleScopeManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (revokeRoleIds != null)
                    {
                        returnValue += roleScopeManager.RevokeRoles(roleId, permissionItemId, revokeRoleIds);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_RevokeRoleRoleScopes, MethodBase.GetCurrentMethod());
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

        #region public int GrantRoleOrganizeScopes(BaseUserInfo userInfo, string roleId, string permissionItemId, string[] grantOrganizeIds)
        /// <summary>
        /// 授予角色的某个权限域的组织范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <param name="grantOrganizeIds">授予组织主键数组</param>
        /// <returns>影响的行数</returns>
        public int GrantRoleOrganizeScopes(BaseUserInfo userInfo, string roleId, string permissionItemCode, string[] grantOrganizeIds)
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
                    string tableName = BasePermissionScopeEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionScope";
                    }
                    BaseRoleScopeManager roleScopeManager = new BaseRoleScopeManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (grantOrganizeIds != null)
                    {
                        returnValue += roleScopeManager.GrantOrganizes(roleId, permissionItemCode, grantOrganizeIds);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GrantRoleOrganizeScopes, MethodBase.GetCurrentMethod());
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

        #region public int RevokeRoleOrganizeScopes(BaseUserInfo userInfo, string roleId, string permissionItemId, string[] revokeOrganizeIds)
        /// <summary>
        /// 撤消角色的某个权限域的组织范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <param name="revokeOrganizeIds">撤消的组织主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeRoleOrganizeScopes(BaseUserInfo userInfo, string roleId, string permissionItemId, string[] revokeOrganizeIds)
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
                    string tableName = BasePermissionScopeEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionScope";
                    }
                    BaseRoleScopeManager roleScopeManager = new BaseRoleScopeManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (revokeOrganizeIds != null)
                    {
                        returnValue += roleScopeManager.RevokeOrganizes(roleId, permissionItemId, revokeOrganizeIds);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_RevokeRoleOrganizeScopes, MethodBase.GetCurrentMethod());
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

        #region public string[] GetRoleScopePermissionItemIds(BaseUserInfo userInfo, string roleId, string permissionItemCode)
        /// <summary>
        /// 获取角色授权权限列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限项</param>
        /// <returns>主键数组</returns>
        public string[] GetRoleScopePermissionItemIds(BaseUserInfo userInfo, string roleId, string permissionItemCode)
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
                    string tableName = BasePermissionScopeEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionScope";
                    }
                    BaseRoleScopeManager roleScopeManager = new BaseRoleScopeManager(dbHelper, userInfo, tableName);
                    returnValue = roleScopeManager.GetPermissionItemIds(roleId, permissionItemCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetRoleScopePermissionItemIds, MethodBase.GetCurrentMethod());
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

        #region public int GrantRolePermissionItemScopes(BaseUserInfo userInfo, string roleId, string[] grantPermissionItemIds)
        /// <summary>
        /// 授予角色的授权权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="grantPermissionItemIds">授予的权限主键数组</param>
        /// <returns>影响的行数</returns>
        public int GrantRolePermissionItemScopes(BaseUserInfo userInfo, string roleId, string permissionItemCode, string[] grantPermissionItemIds)
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
                    BaseRoleScopeManager roleScopeManager = new BaseRoleScopeManager(dbHelper, userInfo);
                    // 小心异常，检查一下参数的有效性
                    if (grantPermissionItemIds != null)
                    {
                        returnValue += roleScopeManager.GrantPermissionItemes(roleId, permissionItemCode, grantPermissionItemIds);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GrantRolePermissionItemScopes, MethodBase.GetCurrentMethod());
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

        #region public int RevokeRolePermissionItemScopes(BaseUserInfo userInfo, string roleId, string permissionItemCode, string[] revokePermissionItemIds)
        /// <summary>
        /// 授予角色的授权权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="revokePermissionItemIds">撤消的权限主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeRolePermissionItemScopes(BaseUserInfo userInfo, string roleId, string permissionItemCode, string[] revokePermissionItemIds)
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
                    BaseRoleScopeManager manager = new BaseRoleScopeManager(dbHelper, userInfo);
                    // 小心异常，检查一下参数的有效性
                    if (revokePermissionItemIds != null)
                    {
                        returnValue += manager.RevokePermissionItems(roleId, permissionItemCode, revokePermissionItemIds);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_RevokeRolePermissionItemScopes, MethodBase.GetCurrentMethod());
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

        #region public int ClearRolePermissionScope(BaseUserInfo userInfo, string roleId, string permissionItemCode)
        /// <summary>
        /// 清除角色权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">主键</param>
        /// <returns>数据表</returns>
        public int ClearRolePermissionScope(BaseUserInfo userInfo, string roleId, string permissionItemCode)
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
                    string tableName = BasePermissionScopeEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionScope";
                    }
                    BaseRoleScopeManager manager = new BaseRoleScopeManager(dbHelper, userInfo, tableName);
                    returnValue = manager.ClearRolePermissionScope(roleId, permissionItemCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_ClearRolePermissionScope, MethodBase.GetCurrentMethod());
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


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 角色模块关联关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        #region public string[] GetRoleScopeModuleIds(BaseUserInfo userInfo, string roleId, string permissionItemCode)
        /// <summary>
        /// 获取用户模块权限范围主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键数组</returns>
        public string[] GetRoleScopeModuleIds(BaseUserInfo userInfo, string roleId, string permissionItemCode)
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
                    string tableName = BasePermissionScopeEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionScope";
                    }
                    BaseRoleScopeManager roleScopeManager = new BaseRoleScopeManager(dbHelper, userInfo, tableName);
                    returnValue = roleScopeManager.GetModuleIds(roleId, permissionItemCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetRoleScopeModuleIds, MethodBase.GetCurrentMethod());
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

        #region public int GrantRoleModuleScopes(BaseUserInfo userInfo, string roleId, string[] grantModuleIds)
        /// <summary>
        /// 授予用户模块的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="grantModuleIds">授予模块主键数组</param>
        /// <returns>影响的行数</returns>
        public int GrantRoleModuleScopes(BaseUserInfo userInfo, string roleId, string permissionItemCode, string[] grantModuleIds)
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
                    string tableName = BasePermissionScopeEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionScope";
                    }
                    BaseRoleScopeManager roleScopeManager = new BaseRoleScopeManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (grantModuleIds != null)
                    {
                        returnValue += roleScopeManager.GrantModules(roleId, permissionItemCode, grantModuleIds);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GrantRoleModuleScopes, MethodBase.GetCurrentMethod());
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

        #region public string GrantRoleModuleScope(BaseUserInfo userInfo, string roleId, string permissionItemCode, string grantModuleId)
        /// <summary>
        /// 授予用户模块的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="grantModuleId">授予模块主键</param>
        /// <returns>影响的行数</returns>
        public string GrantRoleModuleScope(BaseUserInfo userInfo, string roleId, string permissionItemCode, string grantModuleId)
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
                    string tableName = BasePermissionScopeEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionScope";
                    }
                    BaseRoleScopeManager roleScopeManager = new BaseRoleScopeManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (grantModuleId != null)
                    {
                        returnValue = roleScopeManager.GrantModule(roleId, permissionItemCode, grantModuleId);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GrantRoleModuleScope, MethodBase.GetCurrentMethod());
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

        #region public int RevokeRoleModuleScopes(BaseUserInfo userInfo, string roleId, string permissionItemCode, string[] revokeModuleIds)
        /// <summary>
        /// 撤消用户模块的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="revokeModuleIds">撤消模块主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeRoleModuleScopes(BaseUserInfo userInfo, string roleId, string permissionItemCode, string[] revokeModuleIds)
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
                    string tableName = BasePermissionScopeEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionScope";
                    }
                    BaseRoleScopeManager roleScopeManager = new BaseRoleScopeManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (revokeModuleIds != null)
                    {
                        returnValue += roleScopeManager.RevokeModules(roleId, permissionItemCode, revokeModuleIds);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_RevokeRoleModuleScopes, MethodBase.GetCurrentMethod());
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

        #region public int RevokeRoleModuleScope(BaseUserInfo userInfo, string roleId, string permissionItemCode, string revokeModuleId)
        /// <summary>
        /// 撤消用户模块的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="revokeModuleId">撤消模块主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeRoleModuleScope(BaseUserInfo userInfo, string roleId, string permissionItemCode, string revokeModuleId)
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
                    string tableName = BasePermissionScopeEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionScope";
                    }
                    BaseRoleScopeManager roleScopeManager = new BaseRoleScopeManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (revokeModuleId != null)
                    {
                        returnValue += roleScopeManager.RevokeModule(roleId, permissionItemCode, revokeModuleId);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_RevokeRoleModuleScope, MethodBase.GetCurrentMethod());
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