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
    public partial class PermissionService : System.MarshalByRefObject, IPermissionService
    {
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 测试权限用的
        /////////////////////////////////////////////////////////////////////////////////////////////////////////


        #region public string AddPermission(BaseUserInfo userInfo, string permissionCode)
        /// <summary>
        /// 添加操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionCode">权限编号</param>
        /// <returns>主键</returns>
        public string AddPermission(BaseUserInfo userInfo, string permissionCode)
        {
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
                    BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(dbHelper, userInfo);
                    string statusCode = string.Empty;
                    BasePermissionItemEntity permissionItemEntity = new BasePermissionItemEntity();
                    permissionItemEntity.Code = permissionCode;
                    permissionItemEntity.Enabled = 1;
                    permissionItemEntity.AllowDelete = 1;
                    permissionItemEntity.AllowEdit = 1;
                    permissionItemEntity.IsScope = 0;
                    returnValue = permissionItemManager.Add(permissionItemEntity, out statusCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.MSG0091, MethodBase.GetCurrentMethod());
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

            return returnValue;
        }
        #endregion

        #region public int DeletePermission(BaseUserInfo userInfo, string permissionItemCode)
        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>影响行数</returns>
        public int DeletePermission(BaseUserInfo userInfo, string permissionItemCode)
        {
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
                    BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(dbHelper, userInfo);
                    string id = permissionItemManager.GetId(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldCode, permissionItemCode));
                    if (!String.IsNullOrEmpty(id))
                    {
                        // 在删除时，可能会把相关的其他配置权限会删除掉，所以需要调用这个方法。
                        returnValue = permissionItemManager.Delete(id);
                    }
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

            return returnValue;
        }
        #endregion

        #region public string GrantUserPermission(BaseUserInfo userInfo, string userName, string permissionItemCode)
        /// <summary>
        /// 给用户权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userName">用户名</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键</returns>
        public string GrantUserPermission(BaseUserInfo userInfo, string userName, string permissionItemCode)
        {
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
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    string userId = userManager.GetId(new KeyValuePair<string, object>(BaseUserEntity.FieldUserName, userName));
                    BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(dbHelper, userInfo);
                    string permissionItemId = permissionItemManager.GetId(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldCode, permissionItemCode));
                    if (!String.IsNullOrEmpty(userId) && !String.IsNullOrEmpty(permissionItemId))
                    {
                        BaseUserPermissionManager userPermissionManager = new BaseUserPermissionManager(dbHelper, userInfo);
                        returnValue = userPermissionManager.Grant(userId, permissionItemId);
                    }
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

            return returnValue;
        }
        #endregion

        #region public int RevokeUserPermission(BaseUserInfo userInfo, string userName, string permissionItemCode)
        /// <summary>
        /// 撤销用户权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userName">用户名</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键</returns>
        public int RevokeUserPermission(BaseUserInfo userInfo, string userName, string permissionItemCode)
        {
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
                    string userId = userManager.GetId(new KeyValuePair<string, object>(BaseUserEntity.FieldUserName, userName));
                    BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(dbHelper, userInfo);
                    string permissionItemId = permissionItemManager.GetId(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldCode, permissionItemCode));
                    if (!String.IsNullOrEmpty(userId) && !String.IsNullOrEmpty(permissionItemId))
                    {
                        BaseUserPermissionManager userPermissionManager = new BaseUserPermissionManager(dbHelper, userInfo);
                        returnValue = userPermissionManager.Revoke(userId, permissionItemId);
                    }
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

            return returnValue;
        }
        #endregion

        #region public string AddRole(BaseUserInfo userInfo, string role)
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="role">角色</param>
        /// <returns>主键</returns>
        public string AddRole(BaseUserInfo userInfo, string role)
        {
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
                    BaseRoleManager roleManager = new BaseRoleManager(dbHelper, userInfo);
                    string statusCode = string.Empty;
                    BaseRoleEntity roleEntity = new BaseRoleEntity();
                    roleEntity.RealName = role;
                    roleEntity.Enabled = 1;
                    returnValue = roleManager.Add(roleEntity, out statusCode);
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

            return returnValue;
        }
        #endregion

        #region public int DeleteRole(BaseUserInfo userInfo, string role)
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="role">角色</param>
        /// <returns>影响行数</returns>
        public int DeleteRole(BaseUserInfo userInfo, string role)
        {
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
                    BaseRoleManager roleManager = new BaseRoleManager(dbHelper, userInfo);
                    string id = roleManager.GetId(new KeyValuePair<string, object>(BaseRoleEntity.FieldRealName, role));
                    if (!String.IsNullOrEmpty(id))
                    {
                        // 在删除时，可能会把相关的其他配置角色会删除掉，所以需要调用这个方法。
                        returnValue = roleManager.Delete(id);
                    }
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

            return returnValue;
        }
        #endregion

        #region public string AddUserToRole(BaseUserInfo userInfo, string userName, string roleName)
        /// <summary>
        /// 用户添加到角色
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleName">角色名</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键</returns>
        public string AddUserToRole(BaseUserInfo userInfo, string userName, string roleName)
        {
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
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    string userId = userManager.GetId(new KeyValuePair<string, object>(BaseUserEntity.FieldUserName, userName));
                    BaseRoleManager roleManager = new BaseRoleManager(dbHelper, userInfo);
                    string roleId = roleManager.GetId(new KeyValuePair<string, object>(BaseRoleEntity.FieldRealName, roleName));
                    if (!String.IsNullOrEmpty(userId) && !String.IsNullOrEmpty(roleId))
                    {
                        returnValue = userManager.AddToRole(userId, roleId);
                    }
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

            return returnValue;
        }
        #endregion

        #region public int RemoveUserFromRole(BaseUserInfo userInfo, string userName, string roleName)
        /// <summary>
        /// 用户从角色移除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleName">角色名</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键</returns>
        public int RemoveUserFromRole(BaseUserInfo userInfo, string userName, string roleName)
        {
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
                    string userId = userManager.GetId(new KeyValuePair<string, object>(BaseUserEntity.FieldUserName, userName));
                    BaseRoleManager roleManager = new BaseRoleManager(dbHelper, userInfo);
                    string roleId = roleManager.GetId(new KeyValuePair<string, object>(BaseRoleEntity.FieldRealName, roleName));
                    if (!String.IsNullOrEmpty(userId) && !String.IsNullOrEmpty(roleId))
                    {
                        returnValue = userManager.RemoveFormRole(userId, roleId);
                    }
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

            return returnValue;
        }
        #endregion

        #region public string GrantRolePermission(BaseUserInfo userInfo, string roleName, string permissionItemCode)
        /// <summary>
        /// 给角色权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleName">角色名</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键</returns>
        public string GrantRolePermission(BaseUserInfo userInfo, string roleName, string permissionItemCode)
        {
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
                    BaseRoleManager roleManager = new BaseRoleManager(dbHelper, userInfo);
                    string roleId = roleManager.GetId(new KeyValuePair<string, object>(BaseRoleEntity.FieldRealName, roleName));
                    BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(dbHelper, userInfo);
                    string permissionItemId = permissionItemManager.GetId(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldCode, permissionItemCode));
                    if (!String.IsNullOrEmpty(roleId) && !String.IsNullOrEmpty(permissionItemId))
                    {
                        BaseRolePermissionManager rolePermissionManager = new BaseRolePermissionManager(dbHelper, userInfo);
                        returnValue = rolePermissionManager.Grant(roleId, permissionItemId);
                    }
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

            return returnValue;
        }
        #endregion

        #region public int RevokeRolePermission(BaseUserInfo userInfo, string roleName, string permissionItemCode)
        /// <summary>
        /// 撤销角色权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleName">角色名</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键</returns>
        public int RevokeRolePermission(BaseUserInfo userInfo, string roleName, string permissionItemCode)
        {
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
                    BaseRoleManager roleManager = new BaseRoleManager(dbHelper, userInfo);
                    string roleId = roleManager.GetId(new KeyValuePair<string, object>(BaseRoleEntity.FieldRealName, roleName));
                    BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(dbHelper, userInfo);
                    string permissionItemId = permissionItemManager.GetId(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldCode, permissionItemCode));
                    if (!String.IsNullOrEmpty(roleId) && !String.IsNullOrEmpty(permissionItemId))
                    {
                        BaseRolePermissionManager rolePermissionManager = new BaseRolePermissionManager(dbHelper, userInfo);
                        returnValue = rolePermissionManager.Revoke(roleId, permissionItemId);
                    }
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

            return returnValue;
        }
        #endregion
    }
}