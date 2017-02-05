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
        /// 组织机构权限关联关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////


        #region public string[] GetOrganizePermissionItemIds(BaseUserInfo userInfo, string organizeId)
        /// <summary>
        /// 获取组织机构权限主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>主键数组</returns>
        public string[] GetOrganizePermissionItemIds(BaseUserInfo userInfo, string organizeId)
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
                    BaseOrganizePermissionManager organizePermissionManager = new BaseOrganizePermissionManager(dbHelper, userInfo, tableName);
                    returnValue = organizePermissionManager.GetPermissionItemIds(organizeId);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetOrganizePermissionItemIds, MethodBase.GetCurrentMethod());
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

        #region public string[] GetOrganizeIdsByPermission(BaseUserInfo userInfo, string permissionItemId)
        /// <summary>
        /// 获取组织机构主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemId">操作权限主键</param>
        /// <returns>主键数组</returns>
        public string[] GetOrganizeIdsByPermission(BaseUserInfo userInfo, string permissionItemId)
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
                    string tableName = BasePermissionEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "Permission";
                    }
                    BaseOrganizePermissionManager organizePermissionManager = new BaseOrganizePermissionManager(dbHelper, userInfo, tableName);
                    returnValue = organizePermissionManager.GetOrganizeIds(permissionItemId);
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

        #region public int GrantOrganizePermissions(BaseUserInfo userInfo, string[] organizeIds, string[] grantPermissionItemIds)
        /// <summary>
        /// 授予组织机构的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeIds">组织机构主键数组</param>
        /// <param name="grantPermissionItemIds">授予权限数组</param>
        /// <returns>影响的行数</returns>
        public int GrantOrganizePermissions(BaseUserInfo userInfo, string[] organizeIds, string[] grantPermissionItemIds)
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
                    BaseOrganizePermissionManager organizePermissionManager = new BaseOrganizePermissionManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (organizeIds != null && grantPermissionItemIds != null)
                    {
                        returnValue += organizePermissionManager.Grant(organizeIds, grantPermissionItemIds);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GrantOrganizePermissions, MethodBase.GetCurrentMethod());
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

        #region public string GrantOrganizePermissionById(BaseUserInfo userInfo, string organizeId, string grantPermissionItemId)
        /// <summary>
        /// 授予组织机构的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="grantPermissionItemId">授予权限数组</param>
        /// <returns>影响的行数</returns>
        public string GrantOrganizePermissionById(BaseUserInfo userInfo, string organizeId, string grantPermissionItemId)
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
                    BaseOrganizePermissionManager manager = new BaseOrganizePermissionManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (grantPermissionItemId != null)
                    {
                        returnValue = manager.Grant(organizeId, grantPermissionItemId);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GrantOrganizePermissionById, MethodBase.GetCurrentMethod());
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

        #region public int RevokeOrganizePermissions(BaseUserInfo userInfo, string[] organizeIds, string[] revokePermissionItemIds)
        /// <summary>
        /// 撤消组织机构的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeIds">组织机构主键数组</param>
        /// <param name="grantPermissionItemIds">授予权限数组</param>
        /// <param name="revokePermissionItemIds">撤消权限数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeOrganizePermissions(BaseUserInfo userInfo, string[] organizeIds, string[] revokePermissionItemIds)
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
                    BaseOrganizePermissionManager manager = new BaseOrganizePermissionManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (organizeIds != null && revokePermissionItemIds != null)
                    {
                        returnValue += manager.Revoke(organizeIds, revokePermissionItemIds);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_RevokeOrganizePermissions, MethodBase.GetCurrentMethod());
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

        #region public int ClearOrganizePermission(BaseUserInfo userInfo, string id)
        /// <summary>
        /// 清除组织机构权限
        /// 
        /// 1.清除组织机构的用户归属。
        /// 2.清除组织机构的模块权限。
        /// 3.清除组织机构的操作权限。
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
        public int ClearOrganizePermission(BaseUserInfo userInfo, string id)
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
                    BaseOrganizePermissionManager organizePermissionManager = new BaseOrganizePermissionManager(dbHelper, userInfo, tableName);
                    returnValue += organizePermissionManager.RevokeAll(id);

                    tableName = BasePermissionScopeEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionScope";
                    }
                    BaseOrganizeScopeManager organizeScopeManager = new BaseOrganizeScopeManager(dbHelper, userInfo, tableName);
                    returnValue += organizeScopeManager.RevokeAll(id);

                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_ClearOrganizePermission, MethodBase.GetCurrentMethod());
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

        #region public int RevokeOrganizePermissionById(BaseUserInfo userInfo, string organizeId, string revokePermissionItemId)
        /// <summary>
        /// 撤消组织机构的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="revokePermissionItemId">撤消权限数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeOrganizePermissionById(BaseUserInfo userInfo, string organizeId, string revokePermissionItemId)
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
                    BaseOrganizePermissionManager manager = new BaseOrganizePermissionManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (revokePermissionItemId != null)
                    {
                        returnValue += manager.Revoke(organizeId, revokePermissionItemId);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_RevokeOrganizePermissionById, MethodBase.GetCurrentMethod());
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
        /// 组织机构模块关联关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////


        #region public string[] GetOrganizeScopeModuleIds(BaseUserInfo userInfo, string organizeId, string permissionItemCode)
        /// <summary>
        /// 获取用户模块权限范围主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键数组</returns>
        public string[] GetOrganizeScopeModuleIds(BaseUserInfo userInfo, string organizeId, string permissionItemCode)
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
                    string tableName = BaseOrganizeEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionScope";
                    }
                    BaseOrganizeScopeManager organizeScopeManager = new BaseOrganizeScopeManager(dbHelper, userInfo, tableName);
                    returnValue = organizeScopeManager.GetModuleIds(organizeId, permissionItemCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetOrganizeScopeModuleIds, MethodBase.GetCurrentMethod());
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

        #region public int GrantOrganizeModuleScopes(BaseUserInfo userInfo, string organizeId, string[] grantModuleIds)
        /// <summary>
        /// 授予用户模块的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="grantModuleIds">授予模块主键数组</param>
        /// <returns>影响的行数</returns>
        public int GrantOrganizeModuleScopes(BaseUserInfo userInfo, string organizeId, string permissionItemCode, string[] grantModuleIds)
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
                    BaseOrganizeScopeManager organizeScopeManager = new BaseOrganizeScopeManager(dbHelper, userInfo);
                    // 小心异常，检查一下参数的有效性
                    if (grantModuleIds != null)
                    {
                        returnValue += organizeScopeManager.GrantModules(organizeId, permissionItemCode, grantModuleIds);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GrantOrganizeModuleScopes, MethodBase.GetCurrentMethod());
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

        #region public string GrantOrganizeModuleScope(BaseUserInfo userInfo, string organizeId, string permissionItemCode, string grantModuleId)
        /// <summary>
        /// 授予用户模块的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="grantModuleId">授予模块主键</param>
        /// <returns>影响的行数</returns>
        public string GrantOrganizeModuleScope(BaseUserInfo userInfo, string organizeId, string permissionItemCode, string grantModuleId)
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
                    BaseOrganizeScopeManager organizeScopeManager = new BaseOrganizeScopeManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (grantModuleId != null)
                    {
                        returnValue = organizeScopeManager.GrantModule(organizeId, permissionItemCode, grantModuleId);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GrantOrganizeModuleScope, MethodBase.GetCurrentMethod());
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

        #region public int RevokeOrganizeModuleScopes(BaseUserInfo userInfo, string organizeId, string permissionItemCode, string[] revokeModuleIds)
        /// <summary>
        /// 撤消用户模块的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="revokeModuleIds">撤消模块主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeOrganizeModuleScopes(BaseUserInfo userInfo, string organizeId, string permissionItemCode, string[] revokeModuleIds)
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
                    BaseOrganizeScopeManager organizeScopeManager = new BaseOrganizeScopeManager(dbHelper, userInfo);
                    // 小心异常，检查一下参数的有效性
                    if (revokeModuleIds != null)
                    {
                        returnValue += organizeScopeManager.RevokeModules(organizeId, permissionItemCode, revokeModuleIds);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_RevokeOrganizeModuleScopes, MethodBase.GetCurrentMethod());
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

        #region public int RevokeOrganizeModuleScope(BaseUserInfo userInfo, string organizeId, string permissionItemCode, string revokeModuleId)
        /// <summary>
        /// 撤消用户模块的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="revokeModuleId">撤消模块主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeOrganizeModuleScope(BaseUserInfo userInfo, string organizeId, string permissionItemCode, string revokeModuleId)
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
                    BaseOrganizeScopeManager organizeScopeManager = new BaseOrganizeScopeManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (revokeModuleId != null)
                    {
                        returnValue += organizeScopeManager.RevokeModule(organizeId, permissionItemCode, revokeModuleId);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_RevokeOrganizeModuleScope, MethodBase.GetCurrentMethod());
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