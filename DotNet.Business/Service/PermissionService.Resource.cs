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
        /// 资源权限设定关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////


        #region public string[] GetResourcePermissionItemIds(BaseUserInfo userInfo, string resourceCategory, string resourceId)
        /// <summary>
        /// 获取资源权限主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <returns>主键数组</returns>
        public string[] GetResourcePermissionItemIds(BaseUserInfo userInfo, string resourceCategory, string resourceId)
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

                    List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                    parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceCategory, resourceCategory));
                    parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceId, resourceId));

                    DataTable dataTable = DbLogic.GetDataTable(dbHelper, BasePermissionEntity.TableName, parameters);
                    returnValue = BaseBusinessLogic.FieldToArray(dataTable, BasePermissionEntity.FieldPermissionItemId);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetResourcePermissionItemIds, MethodBase.GetCurrentMethod());
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

        #region public int GrantResourcePermission(BaseUserInfo userInfo, string resourceCategory, string resourceId, string[] grantPermissionItemIds)
        /// <summary>
        /// 授予资源的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="grantPermissionItemIds">权限主键</param>
        /// <returns>影响的行数</returns>
        public int GrantResourcePermission(BaseUserInfo userInfo, string resourceCategory, string resourceId, string[] grantPermissionItemIds)
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
                        BasePermissionManager permissionManager = new BasePermissionManager(dbHelper, userInfo);
                        for (int i = 0; i < grantPermissionItemIds.Length; i++)
                        {
                            BasePermissionEntity resourcePermissionEntity = new BasePermissionEntity();
                            resourcePermissionEntity.ResourceCategory = resourceCategory;
                            resourcePermissionEntity.ResourceId = resourceId;
                            resourcePermissionEntity.PermissionId = int.Parse(grantPermissionItemIds[i]);
                            resourcePermissionEntity.Enabled = 1;
                            resourcePermissionEntity.DeletionStateCode = 0;
                            permissionManager.Add(resourcePermissionEntity);
                            returnValue++;
                        }
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GrantResourcePermission, MethodBase.GetCurrentMethod());
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

        #region public int RevokeResourcePermission(BaseUserInfo userInfo, string resourceCategory, string resourceId, string[] revokePermissionItemIds)
        /// <summary>
        /// 撤消资源的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="revokePermissionItemIds">权限主键</param>
        /// <returns>影响的行数</returns>
        public int RevokeResourcePermission(BaseUserInfo userInfo, string resourceCategory, string resourceId, string[] revokePermissionItemIds)
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
                    // BaseRoleScopeManager manager = new BaseRoleScopeManager(dbHelper, userInfo);
                    // 小心异常，检查一下参数的有效性
                    if (revokePermissionItemIds != null)
                    {
                        BasePermissionManager permissionManager = new BasePermissionManager(dbHelper, userInfo);
                        for (int i = 0; i < revokePermissionItemIds.Length; i++)
                        {
                            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceCategory, resourceCategory));
                            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceId, resourceId));
                            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldPermissionItemId, revokePermissionItemIds[i]));
                            // returnValue += permissionManager.SetDeleted(parameters);
                            returnValue += permissionManager.Delete(parameters);
                        }
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_RevokeResourcePermission, MethodBase.GetCurrentMethod());
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
        /// 资源权限范围设定关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////


        #region public string[] GetPermissionScopeTargetIds(BaseUserInfo userInfo, string resourceCategory, string resourceId, string targetCategory, string permissionItemCode)
        /// <summary>
        /// 获取资源权限范围主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键数组</returns>
        public string[] GetPermissionScopeTargetIds(BaseUserInfo userInfo, string resourceCategory, string resourceId, string targetCategory, string permissionItemCode)
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
                    string tableName = BasePermissionItemEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionItem";
                    }
                    BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(dbHelper, userInfo, tableName);
                    string permissionItemId = permissionItemManager.GetId(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldCode, permissionItemCode));

                    List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                    parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, resourceCategory));
                    parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, resourceId));
                    parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetCategory, targetCategory));
                    parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldPermissionItemId, permissionItemId));
                    parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldEnabled, 1));
                    parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldDeletionStateCode, 0));

                    tableName = BasePermissionScopeEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionScope";
                    }
                    returnValue = DbLogic.GetProperties(dbHelper, tableName, parameters, 0, BasePermissionScopeEntity.FieldTargetId);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetPermissionScopeTargetIds, MethodBase.GetCurrentMethod());
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

        #region public string[] GetPermissionScopeResourceIds(BaseUserInfo userInfo, string resourceCategory, string targetId, string targetResourceCategory, string permissionItemCode)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="resourceCategory"></param>
        /// <param name="targetId"></param>
        /// <param name="targetResourceCategory"></param>
        /// <param name="permissionItemCode"></param>
        /// <returns></returns>
        public string[] GetPermissionScopeResourceIds(BaseUserInfo userInfo, string resourceCategory, string targetId, string targetResourceCategory, string permissionItemCode)
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
                    string tableName = BasePermissionItemEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionItem";
                    }
                    BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(dbHelper, userInfo, tableName);
                    string permissionItemId = permissionItemManager.GetId(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldCode, permissionItemCode));
                    
                    List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
					parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetId, targetId));
                    parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, resourceCategory));
                    parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldPermissionItemId, permissionItemId));
                    parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetCategory, targetResourceCategory));
                    parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldEnabled, 1));
                    parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldDeletionStateCode, 0));

                    tableName = BasePermissionScopeEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionScope";
                    }
                    returnValue = DbLogic.GetProperties(dbHelper, tableName, parameters, 0, BasePermissionScopeEntity.FieldResourceId);
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

        #region public int GrantPermissionScopeTarget(BaseUserInfo userInfo, string resourceCategory, string resourceId, string targetCategory, string[] grantTargetIds, string permissionItemId)
        /// <summary>
        /// 授予资源的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="grantTargetIds">目标主键数组</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响的行数</returns>
        public int GrantPermissionScopeTargets(BaseUserInfo userInfo, string resourceCategory, string resourceId, string targetCategory, string[] grantTargetIds, string permissionItemId)
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
                    BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(dbHelper, userInfo, tableName);
                    returnValue = permissionScopeManager.GrantResourcePermissionScopeTarget(resourceCategory, resourceId, targetCategory, grantTargetIds, permissionItemId);
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

        #region public int GrantPermissionScopeTarget(BaseUserInfo userInfo, string resourceCategory, string[] resourceIds, string targetCategory, string grantTargetId, string permissionItemId)
        public int GrantPermissionScopeTarget(BaseUserInfo userInfo, string resourceCategory, string[] resourceIds, string targetCategory, string grantTargetId, string permissionItemId)
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
                    BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(dbHelper, userInfo, tableName);
                    returnValue = permissionScopeManager.GrantResourcePermissionScopeTarget(resourceCategory, resourceIds, targetCategory, grantTargetId, permissionItemId);
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

        #region public int RevokePermissionScopeTargets(BaseUserInfo userInfo, string resourceCategory, string resourceId, string targetCategory, string[] revokeTargetIds, string permissionItemId)
        /// <summary>
        /// 撤消资源的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="revokeTargetIds">目标主键数组</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响的行数</returns>
        public int RevokePermissionScopeTargets(BaseUserInfo userInfo, string resourceCategory, string resourceId, string targetCategory, string[] revokeTargetIds, string permissionItemId)
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
                    BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(dbHelper, userInfo, tableName);
                    returnValue = permissionScopeManager.RevokeResourcePermissionScopeTarget(resourceCategory, resourceId, targetCategory, revokeTargetIds, permissionItemId);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_RevokePermissionScopeTargets, MethodBase.GetCurrentMethod());
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

        #region public int RevokePermissionScopeTarget(BaseUserInfo userInfo, string resourceCategory, string[] resourceIds, string targetCategory, string revokeTargetId, string permissionItemId)
        /// <summary>
        /// 移除权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceIds">资源主键</param>
        /// <param name="targetCategory">目标分类</param>
        /// <param name="revokeTargetId">目标主键</param>
        /// <param name="permissionItemId">操作权限项</param>
        /// <returns>影响行数</returns>
        public int RevokePermissionScopeTarget(BaseUserInfo userInfo, string resourceCategory, string[] resourceIds, string targetCategory, string revokeTargetId, string permissionItemId)
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
                    BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(dbHelper, userInfo, tableName);
                    returnValue = permissionScopeManager.RevokeResourcePermissionScopeTarget(resourceCategory, resourceIds, targetCategory, revokeTargetId, permissionItemId);
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

        #region public int ClearPermissionScopeTarget(BaseUserInfo userInfo, string resourceCategory, string resourceId, string targetCategory, string permissionItemId)
        /// <summary>
        /// 撤消资源的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响的行数</returns>
        public int ClearPermissionScopeTarget(BaseUserInfo userInfo, string resourceCategory, string resourceId, string targetCategory, string permissionItemId)
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
                    BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(dbHelper, userInfo, tableName);
                    returnValue = permissionScopeManager.RevokeResourcePermissionScopeTarget(resourceCategory, resourceId, targetCategory, permissionItemId);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_ClearPermissionScopeTarget, MethodBase.GetCurrentMethod());
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

        #region public string[] GetResourceScopeIds(BaseUserInfo userInfo, string userId, string targetCategory, string permissionItemCode)
        /// <summary>
        /// 获取用户的某个资源的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键数组</returns>
        public string[] GetResourceScopeIds(BaseUserInfo userInfo, string userId, string targetCategory, string permissionItemCode)
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
                    BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(dbHelper, userInfo, tableName);
                    returnValue = permissionScopeManager.GetResourceScopeIds(userId, targetCategory, permissionItemCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetResourceScopeIds, MethodBase.GetCurrentMethod());
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

        #region public string[] GetTreeResourceScopeIds(BaseUserInfo userInfo, string userId, string targetCategory, string permissionItemCode, bool childrens)
        /// <summary>
        /// 60.获取用户的某个资源的权限范围(树型资源)
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <param name="childrens">是否含子节点</param>
        /// <returns>主键数组</returns>
        public string[] GetTreeResourceScopeIds(BaseUserInfo userInfo, string userId, string targetCategory, string permissionItemCode, bool childrens)
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
                    BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(dbHelper, userInfo, tableName);
                    returnValue = permissionScopeManager.GetTreeResourceScopeIds(userId, targetCategory, permissionItemCode, childrens);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionService_GetTreeResourceScopeIds, MethodBase.GetCurrentMethod());
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