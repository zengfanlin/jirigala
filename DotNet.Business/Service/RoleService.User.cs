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
    ///		2012.03.27 版本：1.0 JiRiGaLa 分离程序。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.03.27</date>
    /// </author> 
    /// </summary>
    public partial class RoleService : System.MarshalByRefObject, IRoleService
    {
        /// <summary>
        /// 获得角色中的用户主键
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>用户主键</returns>
        public string[] GetRoleUserIds(BaseUserInfo userInfo, string roleId)
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
                    string tableName = BaseUserRoleEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "UserRole";
                    }
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo, tableName);
                    returnValue = userManager.GetUserIdsInRole(roleId);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, serviceName, AppMessage.RoleService_GetRoleUserIds, MethodBase.GetCurrentMethod());
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
        /// 用户添加到角色
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="addUserIds">用户主键</param>
        /// <returns>影响行数</returns>
        public int AddUserToRole(BaseUserInfo userInfo, string roleId, string[] addUserIds)
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
                    string tableName = BaseUserRoleEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "UserRole";
                    }
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo, tableName);
                    // 小心异常，检查一下参数的有效性
                    if (addUserIds != null)
                    {
                        returnValue += userManager.AddToRole(addUserIds, roleId);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, serviceName, AppMessage.RoleService_AddUserToRole, MethodBase.GetCurrentMethod());
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
        /// 将用户从角色中移除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="userIds">用户主键</param>
        /// <returns>影响行数</returns>
        public int RemoveUserFromRole(BaseUserInfo userInfo, string roleId, string[] userIds)
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
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    if (userIds != null)
                    {
                        returnValue += userManager.RemoveFormRole(userIds, roleId);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, serviceName, AppMessage.RoleService_RemoveUserFromRole, MethodBase.GetCurrentMethod());
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
        /// 清除角色用户关联
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>影响行数</returns>
        public int ClearRoleUser(BaseUserInfo userInfo, string roleId)
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
                    string tableName = BaseUserRoleEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "UserRole";
                    }
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo, tableName);
                    returnValue = userManager.ClearUser(roleId);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, serviceName, AppMessage.RoleService_ClearRoleUser, MethodBase.GetCurrentMethod());
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