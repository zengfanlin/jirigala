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
    /// UserService
    /// 用户管理服务
    /// 
    /// 修改纪录
    /// 
    ///		2012.03.27 版本：1.0 JiRiGaLa 窗体与数据库连接的分离。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.03.27</date>
    /// </author> 
    /// </summary>
    public partial class UserService : System.MarshalByRefObject, IUserService
    {
        #region public bool UserIsInRole(BaseUserInfo userInfo, string userId, string roleCode)
        /// <summary>
        /// 用户是否在某个角色里的判断
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="roleCode">角色编号</param>
        /// <returns>存在</returns>
        public bool UserIsInRole(BaseUserInfo userInfo, string userId, string roleCode)
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
                    returnValue = userManager.IsInRoleByCode(userId, roleCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.UserService_UserInRole, MethodBase.GetCurrentMethod());
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

        #region public DataTable GetDataTableByRole(BaseUserInfo userInfo, string roleId)
        /// <summary>
        /// 按角色获取用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据权限</returns>
        public DataTable GetDataTableByRole(BaseUserInfo userInfo, string roleId)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseStaffEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    // 获取允许登录列表
                    dataTable = userManager.GetDataTableByRole(roleId);
                    dataTable.TableName = BaseUserEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.UserService_GetDataTableByRole, MethodBase.GetCurrentMethod());
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

        #region public DataTable GetRoleDT(BaseUserInfo userInfo)
        /// <summary>
        /// 获取用户的角色列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetRoleDT(BaseUserInfo userInfo)
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

                    List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                    parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldEnabled, 1));
                    parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldDeletionStateCode, 0));
                    BaseRoleManager roleManager = new BaseRoleManager(dbHelper, userInfo);
                    // 获取有效的，未必删除的数据，按排序码排序
                    dataTable = roleManager.GetDataTable(parameters, BaseRoleEntity.FieldSortCode);
                    // 不是超级管理员，不能添加超级管理员
                    if (!userInfo.IsAdministrator)
                    {
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            if (dataRow[BaseRoleEntity.FieldCode].ToString().Equals(DefaultRole.Administrators.ToString()))
                            {
                                dataRow.Delete();
                            }
                        }
                        dataTable.AcceptChanges();
                    }
                    dataTable.TableName = BaseUserEntity.TableName;
                    dataTable.DefaultView.Sort = BaseUserEntity.FieldSortCode;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.UserService_GetRoleDT, MethodBase.GetCurrentMethod());
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

        #region public int SetDefaultRole(BaseUserInfo userInfo, string userId, string roleId)
        /// <summary>
        /// 设置用户的默认角色
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>影响的行数</returns>
        public int SetDefaultRole(BaseUserInfo userInfo, string userId, string roleId)
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
                    returnValue = userManager.SetProperty(userId, new KeyValuePair<string, object>(BaseUserEntity.FieldRoleId, roleId));
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.UserService_SetDefaultRole, MethodBase.GetCurrentMethod());
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

            return 0;
        }
        #endregion

        #region public int BatchSetDefaultRole(BaseUserInfo userInfo, string[] userIds, string roleId)
        /// <summary>
        /// 批量设置默认角色
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="userIds"></param>
        /// <param name="roleId"></param>
        /// <returns>影响行数</returns>
        public int BatchSetDefaultRole(BaseUserInfo userInfo, string[] userIds, string roleId)
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
                    returnValue = userManager.SetProperty(userIds, new KeyValuePair<string, object>(BaseUserEntity.FieldRoleId, roleId));

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

        #region public string[] GetUserRoleIds(BaseUserInfo userInfo, string userId)
        /// <summary>
        /// 获取用户的角色主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">员工主键</param>
        /// <returns>主键数组</returns>
        public string[] GetUserRoleIds(BaseUserInfo userInfo, string userId)
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
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    returnValue = userManager.GetAllRoleIds(userId);
                    // returnValue = userRoleManager.GetRoleIds(userId);
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

        #region public string[] GetAllUserRoleIds(BaseUserInfo userInfo, string userId)
        /// <summary>
        /// 获取用户的所有角色主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">员工主键</param>
        /// <returns>主键数组</returns>
        public string[] GetAllUserRoleIds(BaseUserInfo userInfo, string userId)
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
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    returnValue = userManager.GetAllRoleIds(userId);
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

        #region public int AddUserToRole(BaseUserInfo userInfo, string userId, string[] addRoleIds)
        /// <summary>
        /// 添加用户到某些角色里
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">员工主键</param>
        /// <param name="addRoleIds">加入角色</param>
        /// <returns>影响的行数</returns>
        public int AddUserToRole(BaseUserInfo userInfo, string userId, string[] addRoleIds)
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
                    // 小心异常，检查一下参数的有效性
                    if (addRoleIds != null)
                    {
                        returnValue += userManager.AddToRole(userId, addRoleIds);
                    }
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

        #region public int RemoveUserFromRole(BaseUserInfo userInfo, string userId, string[] removeRoleIds)
        /// <summary>
        /// 将用户从某些角色中移除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="removeRoleIds">角色主键数组</param>
        /// <returns>影响行数</returns>
        public int RemoveUserFromRole(BaseUserInfo userInfo, string userId, string[] removeRoleIds)
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
                    if (removeRoleIds != null)
                    {
                        returnValue += userManager.RemoveFormRole(userId, removeRoleIds);
                    }
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

        #region public int ClearUserRole(BaseUserInfo userInfo, string userId)
        /// <summary>
        /// 清除用户归属的角色
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>影响行数</returns>
        public int ClearUserRole(BaseUserInfo userInfo, string userId)
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
                    returnValue = userManager.ClearRole(userId);
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
    }
}