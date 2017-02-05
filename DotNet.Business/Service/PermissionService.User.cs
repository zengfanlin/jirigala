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
        /// 用户权限关联关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////


        #region public string[] GetUserPermissionItemIds(BaseUserInfo userInfo, string userId)
        /// <summary>
        /// 获取用户权限主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>主键数组</returns>
        public string[] GetUserPermissionItemIds(BaseUserInfo userInfo, string userId)
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
                    BaseUserPermissionManager userPermissionDa = new BaseUserPermissionManager(dbHelper, userInfo, tableName);
                    returnValue = userPermissionDa.GetPermissionItemIds(userId);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetUserPermissionItemIds, MethodBase.GetCurrentMethod());
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

        #region public string[] GetUserIdsByPermission(BaseUserInfo userInfo, string permissionItemId)
        /// <summary>
        /// 获取用户权限主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>主键数组</returns>
        public string[] GetUserIdsByPermission(BaseUserInfo userInfo, string permissionItemId)
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
                    BaseUserPermissionManager userPermissionDa = new BaseUserPermissionManager(dbHelper, userInfo);
                    returnValue = userPermissionDa.GetUserIds(permissionItemId);
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

        #region public int GrantUserPermissions(BaseUserInfo userInfo, string[] userIds, string[] grantPermissionItemIds)
        /// <summary>
        /// 授予用户操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键数组</param>
        /// <param name="grantPermissionItemIds">授予权限数组</param>
        /// <returns>影响的行数</returns>
        public int GrantUserPermissions(BaseUserInfo userInfo, string[] userIds, string[] grantPermissionItemIds)
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
                    BaseUserPermissionManager userPermissionManager = new BaseUserPermissionManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (userIds != null && grantPermissionItemIds != null)
                    {
                        returnValue += userPermissionManager.Grant(userIds, grantPermissionItemIds);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GrantUserPermissions, MethodBase.GetCurrentMethod());
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

        #region public string GrantUserPermissionById(BaseUserInfo userInfo, string userId, string grantPermissionItemId)
        /// <summary>
        /// 授予用户操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="grantPermissionItemIds">授予权限数组</param>
        /// <returns>影响的行数</returns>
        public string GrantUserPermissionById(BaseUserInfo userInfo, string userId, string grantPermissionItemId)
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
                    BaseUserPermissionManager userPermissionManager = new BaseUserPermissionManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (grantPermissionItemId != null)
                    {
                        returnValue = userPermissionManager.Grant(userId, grantPermissionItemId);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GrantUserPermissionById, MethodBase.GetCurrentMethod());
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

        #region public int RevokeUserPermissions(BaseUserInfo userInfo, string[] userIds, string[] revokePermissionItemIds)
        /// <summary>
        /// 撤消用户操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userIds">用户主键数组</param>
        /// <param name="revokePermissionItemIds">撤消权限数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeUserPermissions(BaseUserInfo userInfo, string[] userIds, string[] revokePermissionItemIds)
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
                    BaseUserPermissionManager userPermissionManager = new BaseUserPermissionManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (userIds != null && revokePermissionItemIds != null)
                    {
                        returnValue += userPermissionManager.Revoke(userIds, revokePermissionItemIds);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_RevokeUserPermission, MethodBase.GetCurrentMethod());
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

        #region public int RevokeUserPermissionById(BaseUserInfo userInfo, string userId, string revokePermissionItemId)
        /// <summary>
        /// 撤消用户操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="revokePermissionItemIds">撤消权限数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeUserPermissionById(BaseUserInfo userInfo, string userId, string revokePermissionItemId)
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
                    BaseUserPermissionManager userPermissionManager = new BaseUserPermissionManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (revokePermissionItemId != null)
                    {
                        returnValue += userPermissionManager.Revoke(userId, revokePermissionItemId);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_RevokeUserPermissionById, MethodBase.GetCurrentMethod());
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

        #region public string[] GetUserScopeOrganizeIds(BaseUserInfo userInfo, string userId, string permissionItemCode)
        /// <summary>
        /// 获取用户的某个权限域的组织范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键数组</returns>
        public string[] GetUserScopeOrganizeIds(BaseUserInfo userInfo, string userId, string permissionItemCode)
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
                    BaseUserScopeManager userPermissionScopeManager = new BaseUserScopeManager(dbHelper, userInfo, tableName);
                    returnValue = userPermissionScopeManager.GetOrganizeIds(userId, permissionItemCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetUserScopeOrganizeIds, MethodBase.GetCurrentMethod());
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

        #region public int GrantUserOrganizeScope(BaseUserInfo userInfo, string userId, string permissionScopeItemCode, string[] grantOrganizeIds)
        /// <summary>
        /// 设置用户的某个权限域的组织范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionScopeItemCode">权限编号</param>
        /// <param name="grantOrganizeIds">授予的组织主键数组</param>
        /// <returns>影响的行数</returns>
        public int GrantUserOrganizeScopes(BaseUserInfo userInfo, string userId, string permissionScopeItemCode, string[] grantOrganizeIds)
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
                    BaseUserScopeManager userPermissionScopeManager = new BaseUserScopeManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (grantOrganizeIds == null)
                    {
                        returnValue += userPermissionScopeManager.RevokeOrganize(userId, permissionScopeItemCode);
                    }
                    else
                    {
                        returnValue += userPermissionScopeManager.GrantOrganizes(userId, permissionScopeItemCode, grantOrganizeIds);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GrantUserOrganizeScopes, MethodBase.GetCurrentMethod());
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

        #region public int RevokeUserOrganizeScope(BaseUserInfo userInfo, string userId, string permissionScopeItemCode, string[] revokeOrganizeIds)
        /// <summary>
        /// 设置用户的某个权限域的组织范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionScopeItemCode">权限主键</param>
        /// <param name="revokeOrganizeIds">撤消的组织主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeUserOrganizeScopes(BaseUserInfo userInfo, string userId, string permissionScopeItemCode, string[] revokeOrganizeIds)
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
                    BaseUserScopeManager userPermissionScopeManager = new BaseUserScopeManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (revokeOrganizeIds != null)
                    {
                        returnValue += userPermissionScopeManager.RevokeOrganizes(userId, permissionScopeItemCode, revokeOrganizeIds);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_RevokeUserOrganizeScopes, MethodBase.GetCurrentMethod());
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

        #region public string[] GetUserScopeUserIds(BaseUserInfo userInfo, string userId, string permissionScopeItemId)
        /// <summary>
        /// 获取用户的某个权限域的用户范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionScopeItemId">权限主键</param>
        /// <returns>主键数组</returns>
        public string[] GetUserScopeUserIds(BaseUserInfo userInfo, string userId, string permissionScopeItemId)
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
                    BaseUserScopeManager userPermissionScopeManager = new BaseUserScopeManager(dbHelper, userInfo, tableName);
                    returnValue = userPermissionScopeManager.GetUserIds(userId, permissionScopeItemId);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetUserScopeUserIds, MethodBase.GetCurrentMethod());
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

        #region public int GrantUserUserScope(BaseUserInfo userInfo, string userId, string permissionScopeItemCode, string[] grantUserIds)
        /// <summary>
        /// 设置用户的某个权限域的用户范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionScopeItemCode">权限主键</param>
        /// <param name="grantUserIds">授予的用户主键数组</param>
        /// <returns>影响的行数</returns>
        public int GrantUserUserScopes(BaseUserInfo userInfo, string userId, string permissionScopeItemCode, string[] grantUserIds)
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
                    BaseUserScopeManager userPermissionScopeManager = new BaseUserScopeManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (grantUserIds != null)
                    {
                        returnValue += userPermissionScopeManager.GrantUsers(userId, permissionScopeItemCode, grantUserIds);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GrantUserUserScopes, MethodBase.GetCurrentMethod());
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

        #region public int RevokeUserUserScope(BaseUserInfo userInfo, string userId, string permissionScopeItemCode, string[] revokeUserIds)
        /// <summary>
        /// 设置用户的某个权限域的用户范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionScopeItemCode">权限主键</param>
        /// <param name="revokeUserIds">撤消的用户主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeUserUserScopes(BaseUserInfo userInfo, string userId, string permissionScopeItemCode, string[] revokeUserIds)
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
                    BaseUserScopeManager userPermissionScopeManager = new BaseUserScopeManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (revokeUserIds != null)
                    {
                        returnValue += userPermissionScopeManager.RevokeUsers(userId, permissionScopeItemCode, revokeUserIds);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_RevokeUserUserScopes, MethodBase.GetCurrentMethod());
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
        
        #region public string[] GetUserScopeRoleIds(BaseUserInfo userInfo, string userId, string permissionItemCode)
        /// <summary>
        /// 获取用户的某个权限域的用户范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限主键</param>
        /// <returns>主键数组</returns>
        public string[] GetUserScopeRoleIds(BaseUserInfo userInfo, string userId, string permissionItemCode)
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
                    BaseUserScopeManager userPermissionScopeManager = new BaseUserScopeManager(dbHelper, userInfo);
                    returnValue = userPermissionScopeManager.GetRoleIds(userId, permissionItemCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetUserScopeRoleIds, MethodBase.GetCurrentMethod());
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

        #region public int GrantUserRoleScope(BaseUserInfo userInfo, string userId, string permissionScopeItemCode, string[] grantRoleIds)
        /// <summary>
        /// 设置用户的某个权限域的用户范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionScopeItemCode">权限主键</param>
        /// <param name="grantRoleIds">授予的用户主键数组</param>
        /// <returns>影响的行数</returns>
        public int GrantUserRoleScopes(BaseUserInfo userInfo, string userId, string permissionScopeItemCode, string[] grantRoleIds)
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
                    BaseUserScopeManager userPermissionScopeManager = new BaseUserScopeManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (grantRoleIds != null)
                    {
                        returnValue += userPermissionScopeManager.GrantRoles(userId, permissionScopeItemCode, grantRoleIds);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GrantUserRoleScopes, MethodBase.GetCurrentMethod());
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

        #region public int RevokeUserRoleScope(BaseUserInfo userInfo, string userId, string permissionScopeItemCode, string[] revokeRoleIds)
        /// <summary>
        /// 设置用户的某个权限域的用户范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionScopeItemCode">权限主键</param>
        /// <param name="revokeUserIds">撤消的用户主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeUserRoleScopes(BaseUserInfo userInfo, string userId, string permissionScopeItemCode, string[] revokeRoleIds)
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
                    BaseUserScopeManager userPermissionScopeManager = new BaseUserScopeManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (revokeRoleIds != null)
                    {
                        returnValue += userPermissionScopeManager.RevokeRoles(userId, permissionScopeItemCode, revokeRoleIds);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_RevokeUserRoleScopes, MethodBase.GetCurrentMethod());
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
        
        #region public string[] GetUserScopePermissionItemIds(BaseUserInfo userInfo, string userId)
        /// <summary>
        /// 获取用户授权权限列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>主键数组</returns>
        public string[] GetUserScopePermissionItemIds(BaseUserInfo userInfo, string userId, string permissionItemCode)
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
                    string tableName = BasePermissionScopeEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionScope";
                    }
                    BaseUserScopeManager userPermissionScope = new BaseUserScopeManager(dbHelper, userInfo, tableName);
                    returnValue = userPermissionScope.GetPermissionItemIds(userId, permissionItemCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetUserScopePermissionItemIds, MethodBase.GetCurrentMethod());
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

        #region public int GrantUserPermissionItemScopes(BaseUserInfo userInfo, string userId, string permissionItemCode, string[] grantPermissionItemIds)
        /// <summary>
        /// 授予用户的授权权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="grantPermissionItemIds">授予的权限主键数组</param>
        /// <returns>影响的行数</returns>
        public int GrantUserPermissionItemScopes(BaseUserInfo userInfo, string userId, string permissionItemCode, string[] grantPermissionItemIds)
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
                    BaseUserScopeManager userPermissionScope = new BaseUserScopeManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (grantPermissionItemIds != null)
                    {
                        returnValue += userPermissionScope.GrantPermissionItemes(userId, permissionItemCode, grantPermissionItemIds);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GrantUserPermissionItemScopes, MethodBase.GetCurrentMethod());
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

        #region public int RevokeUserPermissionItemScopes(BaseUserInfo userInfo, string userId, string permissionItemCode, string[] revokePermissionItemIds)
        /// <summary>
        /// 撤消用户的授权权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="revokePermissionItemIds">撤消的权限主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeUserPermissionItemScopes(BaseUserInfo userInfo, string userId, string permissionItemCode, string[] revokePermissionItemIds)
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
                    BaseUserScopeManager userPermissionScope = new BaseUserScopeManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (revokePermissionItemIds != null)
                    {
                        returnValue += userPermissionScope.RevokePermissionItems(userId, permissionItemCode, revokePermissionItemIds);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_RevokeUserPermissionItemScopes, MethodBase.GetCurrentMethod());
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

        #region public int ClearUserPermission(BaseUserInfo userInfo, string id)
        /// <summary>
        /// 清除用户权限
        /// 
        /// 1.清除用户的角色归属。
        /// 2.清除用户的模块权限。
        /// 3.清除用户的操作权限。
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
        public int ClearUserPermission(BaseUserInfo userInfo, string id)
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
                    returnValue += userManager.ClearRole(id);

                    string tableName = BasePermissionEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "Permission";
                    }
                    BaseUserPermissionManager userPermissionManager = new BaseUserPermissionManager(dbHelper, userInfo, tableName);
                    returnValue += userPermissionManager.RevokeAll(id);

                    tableName = BasePermissionScopeEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionScope";
                    }
                    BaseUserScopeManager userPermissionScopeManager = new BaseUserScopeManager(dbHelper, userInfo, tableName);
                    returnValue += userPermissionScopeManager.RevokeAll(id);

                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_ClearUserPermission, MethodBase.GetCurrentMethod());
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

        #region public int ClearUserPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode)
        /// <summary>
        /// 清除用户权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">主键</param>
        /// <returns>数据表</returns>
        public int ClearUserPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode)
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
                    BaseUserScopeManager manager = new BaseUserScopeManager(dbHelper, userInfo, tableName);
                    returnValue = manager.ClearUserPermissionScope(userId, permissionItemCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_ClearUserPermissionScope, MethodBase.GetCurrentMethod());
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
        /// 用户模块关联关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        #region public string[] GetUserScopeModuleIds(BaseUserInfo userInfo, string userId, string permissionItemCode)
        /// <summary>
        /// 获取用户模块权限范围主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键数组</returns>
        public string[] GetUserScopeModuleIds(BaseUserInfo userInfo, string userId, string permissionItemCode)
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
                    BaseUserScopeManager userPermissionScopeManager = new BaseUserScopeManager(dbHelper, userInfo, tableName);
                    returnValue = userPermissionScopeManager.GetModuleIds(userId, permissionItemCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetUserScopeModuleIds, MethodBase.GetCurrentMethod());
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

        #region public int GrantUserModuleScopes(BaseUserInfo userInfo, string userId, string permissionScopeItemCode, string[] grantModuleIds)
        /// <summary>
        /// 授予用户模块的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="grantModuleIds">授予模块主键数组</param>
        /// <returns>影响的行数</returns>
        public int GrantUserModuleScopes(BaseUserInfo userInfo, string userId, string permissionScopeItemCode, string[] grantModuleIds)
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
                    BaseUserScopeManager userPermissionScopeManager = new BaseUserScopeManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (grantModuleIds != null)
                    {
                        BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(dbHelper, userInfo);
                        returnValue += userPermissionScopeManager.GrantModules(userId, permissionScopeItemCode, grantModuleIds);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GrantUserModuleScopes, MethodBase.GetCurrentMethod());
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

        #region public string GrantUserModuleScope(BaseUserInfo userInfo, string userId, string permissionScopeItemCode, string grantModuleId)
        /// <summary>
        /// 授予用户模块的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="grantModuleId">授予模块主键数组</param>
        /// <returns>影响的行数</returns>
        public string GrantUserModuleScope(BaseUserInfo userInfo, string userId, string permissionScopeItemCode, string grantModuleId)
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
                    BaseUserScopeManager userPermissionScopeManager = new BaseUserScopeManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (grantModuleId != null)
                    {
                        returnValue = userPermissionScopeManager.GrantModule(userId, permissionScopeItemCode, grantModuleId);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GrantUserModuleScope, MethodBase.GetCurrentMethod());
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

        #region public int RevokeUserModuleScope(BaseUserInfo userInfo, string userId, string permissionScopeItemCode, string revokeModuleId)
        /// <summary>
        /// 撤消用户模块的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="revokeModuleId">撤消模块主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeUserModuleScope(BaseUserInfo userInfo, string userId, string permissionScopeItemCode, string revokeModuleId)
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
                    BaseUserScopeManager userPermissionScopeManager = new BaseUserScopeManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (revokeModuleId != null)
                    {
                        returnValue += userPermissionScopeManager.RevokeModule(userId, permissionScopeItemCode, revokeModuleId);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_RevokeUserModuleScope, MethodBase.GetCurrentMethod());
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

        #region public int RevokeUserModuleScopes(BaseUserInfo userInfo, string userId, string permissionScopeItemCode, string[] revokeModuleIds)
        /// <summary>
        /// 撤消用户模块的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="revokeModuleIds">撤消模块主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeUserModuleScopes(BaseUserInfo userInfo, string userId, string permissionScopeItemCode, string[] revokeModuleIds)
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
                    BaseUserScopeManager userPermissionScopeManager = new BaseUserScopeManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (revokeModuleIds != null)
                    {
                        returnValue = userPermissionScopeManager.RevokeModules(userId, permissionScopeItemCode, revokeModuleIds);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_RevokeUserModuleScopes, MethodBase.GetCurrentMethod());
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