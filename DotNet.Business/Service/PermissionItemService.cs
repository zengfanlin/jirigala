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
    /// PermissionItemService
    /// 权限操作服务
    /// 
    /// 修改纪录
    ///  
    ///		2008.09.02 版本：2.5 JiRiGaLa 命名修改为 PermissionAdminService。
    ///		2008.05.09 版本：2.4 JiRiGaLa 命名修改为 PermissionService。
    ///		2008.03.23 版本：2.3 JiRiGaLa 改进接口功能，进行了一次飞跃。
    ///		2007.12.24 版本：2.2 JiRiGaLa 改进调试信息方式。
    ///		2007.08.15 版本：2.1 JiRiGaLa 改进运行速度采用 WebService 变量定义 方式处理数据。
    ///		2007.08.14 版本：2.0 JiRiGaLa 改进运行速度采用 Instance 方式处理数据。
    ///     2007.06.11 版本：1.2 JiRiGaLa 加入调试信息#if (DEBUG)。
    ///		2007.05.13 版本：1.1 JiRiGaLa 编号是否重复的判断。
    ///		2007.05.11 版本：1.0 JiRiGaLa 添加权限。
    ///		
    /// 版本：2.4
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.05.19</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class PermissionItemService : System.MarshalByRefObject, IPermissionItemService
    {
        private string serviceName = AppMessage.PermissionItemService;

        /// <summary>
        /// 用户中心数据库连接
        /// </summary>
        private readonly string UserCenterDbConnection = BaseSystemInfo.UserCenterDbConnection;

        /// <summary>
        /// 添加操作权限项
        /// </summary>
        /// <param name="userInfo">当前用户</param>
        /// <param name="permissionEntity">权限定义实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>主键</returns>
        public string Add(BaseUserInfo userInfo, BasePermissionItemEntity permissionItemEntity, out string statusCode, out string statusMessage)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            statusCode = string.Empty;
            statusMessage = string.Empty;
            string returnValue = string.Empty;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    // 数据库事务开始
                    // dbHelper.BeginTransaction();
                    string tableName = BasePermissionItemEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionItem";
                    }
                    BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(dbHelper, userInfo, tableName);
                    returnValue = permissionItemManager.Add(permissionItemEntity, out statusCode);
                    // 获得状态消息
                    statusMessage = permissionItemManager.GetStateMessage(statusCode);
                    // 写入日志信息
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionItemService_Add, MethodBase.GetCurrentMethod());
                    // 数据库事务提交
                    // dbHelper.CommitTransaction();
                }
                catch (Exception ex)
                {
                    // 数据库事务回滚
                    // dbHelper.RollbackTransaction();
                    // 记录异常信息
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
        /// 按详细信息添加
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="code">编号</param>
        /// <param name="fullName">名称</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>主键</returns>
        public string AddByDetail(BaseUserInfo userInfo, string code, string fullName, out string statusCode, out string statusMessage)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif
           
            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            statusCode = string.Empty;
            statusMessage = string.Empty;            
            string returnValue = string.Empty;
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
                    returnValue = permissionItemManager.AddByDetail(code, fullName, out statusCode);
                    // 获得状态消息
                    statusMessage = permissionItemManager.GetStateMessage(statusCode);
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

        #region public DataTable GetDataTableByIds(BaseUserInfo userInfo, string[] ids)
        /// <summary>
        /// 按主键数组获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">组织机构主键</param>
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

            DataTable dataTable = new DataTable(BasePermissionItemEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BasePermissionItemManager permissionItem = new BasePermissionItemManager(dbHelper, userInfo);
                    dataTable = permissionItem.GetDataTable(BasePermissionItemEntity.FieldId, ids, BasePermissionItemEntity.FieldSortCode);
                    dataTable.TableName = BasePermissionItemEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, serviceName, AppMessage.PermissionItemService_GetDataTable, MethodBase.GetCurrentMethod());
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
        /// 获取权限项列表
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
                    BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(dbHelper, userInfo, tableName);
                    dataTable = permissionItemManager.GetDataTable(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldDeletionStateCode, 0), BasePermissionItemEntity.FieldSortCode);
                    dataTable.TableName = BasePermissionItemEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionItemService_GetDataTable, MethodBase.GetCurrentMethod());
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
        /// 按父节点获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="parentId">父节点主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByParent(BaseUserInfo userInfo, string parentId)
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
                    BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(dbHelper, userInfo, tableName);

                    List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                    parameters.Add(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldParentId, parentId));
                    parameters.Add(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldDeletionStateCode, 0));

                    dataTable = permissionItemManager.GetDataTable(parameters, BasePermissionItemEntity.FieldSortCode);
                    dataTable.TableName = BasePermissionItemEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionItemService_GetDataTableByParent, MethodBase.GetCurrentMethod());
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
        /// 获取授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>数据表</returns>
        public DataTable GetLicensedDT(BaseUserInfo userInfo, string userId)
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
                    BasePermissionItemManager permissionAdminManager = new BasePermissionItemManager(dbHelper, userInfo, tableName);
                    string permissionItemId = permissionAdminManager.GetId(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldDeletionStateCode, 0), new KeyValuePair<string, object>(BasePermissionItemEntity.FieldCode, "Resource.ManagePermission"));
                    dataTable = permissionAdminManager.GetDataTableByUser(userId, permissionItemId);
                    dataTable.TableName = BasePermissionItemEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionItemService_GetLicensedDT, MethodBase.GetCurrentMethod());
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
        public BasePermissionItemEntity GetEntity(BaseUserInfo userInfo, string id)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            BasePermissionItemEntity permissionItemEntity = new BasePermissionItemEntity();
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    // 创建实现类
                    string tableName = BasePermissionItemEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionItem";
                    }
                    BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(dbHelper, userInfo, tableName);
                    DataTable returnDataTable = new DataTable(BasePermissionItemEntity.TableName);
                    returnDataTable = permissionItemManager.GetDataTableById(id);
                    permissionItemEntity = new BasePermissionItemEntity(returnDataTable);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionItemService_GetEntity, MethodBase.GetCurrentMethod());
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

            return permissionItemEntity;
        }

        /// <summary>
        /// 按编号获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="code">编号</param>
        /// <returns>实体</returns>
        public BasePermissionItemEntity GetEntityByCode(BaseUserInfo userInfo, string code)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            BasePermissionItemEntity permissionItemEntity = null;
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
                    permissionItemEntity = new BasePermissionItemEntity(permissionItemManager.GetDataTableByCode(code));
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionItemService_GetEntityByCode, MethodBase.GetCurrentMethod());
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

            return permissionItemEntity;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemEntity">实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>影响行数</returns>
        public int Update(BaseUserInfo userInfo, BasePermissionItemEntity permissionItemEntity, out string statusCode, out string statusMessage)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            statusCode = string.Empty;
            statusMessage = string.Empty;
            int returnValue = 0;
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
                    returnValue = permissionItemManager.Update(permissionItemEntity, out statusCode);
                    // 获得状态消息
                    statusMessage = permissionItemManager.GetStateMessage(statusCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionItemService_Update, MethodBase.GetCurrentMethod());
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
        /// 移动实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemId">权限项主键</param>
        /// <param name="parentId">父主键</param>
        /// <returns>影响行数</returns>
        public int MoveTo(BaseUserInfo userInfo, string permissionItemId, string parentId)
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
                    string tableName = BasePermissionItemEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionItem";
                    }
                    BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(dbHelper, userInfo, tableName);
                    returnValue = permissionItemManager.MoveTo(permissionItemId, parentId);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionItemService_MoveTo, MethodBase.GetCurrentMethod());
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
        /// 批量移动实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemIds">权限项主键数组</param>
        /// <param name="parentId">父主键</param>
        /// <returns>影响行数</returns>
        public int BatchMoveTo(BaseUserInfo userInfo, string[] permissionItemIds, string parentId)
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
                    string tableName = BasePermissionItemEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionItem";
                    }
                    BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(dbHelper, userInfo, tableName);
                    for (int i = 0; i < permissionItemIds.Length; i++)
                    {
                        returnValue += permissionItemManager.MoveTo(permissionItemIds[i], parentId);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionItemService_BatchMoveTo, MethodBase.GetCurrentMethod());
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
        /// 删除实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
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
                    string tableName = BasePermissionItemEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionItem";
                    }
                    BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(dbHelper, userInfo, tableName);
                    returnValue = permissionItemManager.Delete(id);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionItemService_Delete, MethodBase.GetCurrentMethod());
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
        /// 批量删除
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
                    string tableName = BasePermissionItemEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionItem";
                    }
                    BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(dbHelper, userInfo, tableName);
                    returnValue = permissionItemManager.Delete(ids);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionItemService_BatchDelete, MethodBase.GetCurrentMethod());
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

        #region public int SetDeleted(BaseUserInfo userInfo, string[] ids) 批量打删除标志
        /// <summary>
        /// 批量打删除标志
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
                    string tableName = BasePermissionItemEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionItem";
                    }
                    BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(dbHelper, userInfo, tableName);
                    returnValue = permissionItemManager.SetDeleted(ids);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionItemService_SetDeleted, MethodBase.GetCurrentMethod());
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

        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响行数</returns>
        public int BatchSave(BaseUserInfo userInfo, DataTable dataTable)
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
                    string tableName = BasePermissionItemEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionItem";
                    }
                    BasePermissionItemManager permissionAdminManager = new BasePermissionItemManager(dbHelper, userInfo, tableName);
                    returnValue = permissionAdminManager.BatchSave(dataTable);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionItemService_BatchSave, MethodBase.GetCurrentMethod());
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
        /// 重新生成排序码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int BatchSetSortCode(BaseUserInfo userInfo, string[] ids)
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
                    string tableName = BasePermissionItemEntity.TableName;
                    if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                    {
                        tableName = BaseSystemInfo.SystemCode + "PermissionItem";
                    }
                    BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(dbHelper, userInfo, tableName);
                    returnValue = permissionItemManager.BatchSetSortCode(ids);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionItemService_BatchSetSortCode, MethodBase.GetCurrentMethod());
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
        /// 操作权限主健数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleId">模块主键</param>
        /// <returns>主键数组</returns>
        public string[] GetIdsByModule(BaseUserInfo userInfo, string moduleId)
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
                    BasePermissionModuleManager modulePermissionManager = new BasePermissionModuleManager(dbHelper, userInfo);
                    returnValue = modulePermissionManager.GetPermissionIds(moduleId);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.PermissionItemService_GetIdsByModule, MethodBase.GetCurrentMethod());
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