//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// ItemDetailsService
    /// 基础主键服务
    /// 
    /// 修改纪录
    /// 
    ///		2008.10.23 版本：2.3 JiRiGaLa 表明可以自己定义，可以控制多个表。
    ///		2007.08.15 版本：2.2 JiRiGaLa 改进运行速度采用 WebService 变量定义 方式处理数据。
    ///		2007.08.14 版本：2.1 JiRiGaLa 改进运行速度采用 Instance 方式处理数据。
    ///		2007.05.15 版本：1.0 JiRiGaLa 基础编码管理。
    ///		
    /// 版本：2.2
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.08.15</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class ItemDetailsService : System.MarshalByRefObject, IItemDetailsService
    {
        private string serviceName = AppMessage.ItemDetailsService;

        /// <summary>
        /// 用户中心数据库连接
        /// </summary>
        private readonly string UserCenterDbConnection = BaseSystemInfo.UserCenterDbConnection;

        #region public DataTable GetDataTable(BaseUserInfo userInfo, string tableName) 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="tableName">目标表</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTable(BaseUserInfo userInfo, string tableName)
        {
            // 写入调试信息
#if (DEBUG)
            int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
#endif

            // 加强安全验证防止未授权匿名调用
#if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
#endif

            DataTable dataTable = new DataTable(tableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseItemDetailsManager itemDetailsManager = new BaseItemDetailsManager(dbHelper, userInfo, tableName);
                    // 检查有其他目标数据库表存储了数据
                    // BaseItemsManager itemsManager = new BaseItemsManager(dbHelper, userInfo);
                    // BaseItemsEntity itemsEntity = new BaseItemsEntity(itemsManager.Get(BaseItemDetailsEntity.FieldItemCode, itemCode));
                    // if (!String.IsNullOrEmpty(itemsEntity.TargetTable))
                    // {
                    //     itemDetailsManager = new BaseItemDetailsManager(dbHelper, userInfo, itemsEntity.TargetTable);
                    // }
                    // dataTable = itemDetailsManager.GetDataTable(BaseItemDetailsEntity.FieldDeletionStateCode, 0, BaseItemDetailsEntity.FieldEnabled, 1, BaseItemDetailsEntity.FieldSortCode);
                    // 前台管理时，应该把有效无效的都显示出来，主要是为了管理设置时无效的也可以显示出来，下拉框时需要自己控制一下
                    dataTable = itemDetailsManager.GetDataTable(new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldDeletionStateCode, 0), BaseItemDetailsEntity.FieldSortCode);
                    dataTable.TableName = tableName;
                    // 添加日志
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.ItemDetailsService_GetDataTable, MethodBase.GetCurrentMethod());
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

        #region public DataTable GetDataTableByParent(BaseUserInfo userInfo, string tableName, string parentId) 获取子列表
        /// <summary>
        /// 获取子列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="tableName">目标表</param>
        /// <param name="parentId">父级主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByParent(BaseUserInfo userInfo, string tableName, string parentId)
        {
            // 写入调试信息
#if (DEBUG)
            int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
#endif

            // 加强安全验证防止未授权匿名调用
#if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
#endif

            DataTable dataTable = new DataTable(tableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseItemDetailsManager itemDetailsManager = new BaseItemDetailsManager(dbHelper, userInfo, tableName);
                    dataTable = itemDetailsManager.GetDataTableByParent(parentId);
                    dataTable.TableName = tableName;
                    // 添加日志
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.ItemDetailsService_GetDataTableByParent, MethodBase.GetCurrentMethod());
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

        public DataTable GetDataTableByCode(IDbHelper dbHelper, BaseUserInfo userInfo, string code)
        {
            // 加强安全验证防止未授权匿名调用
#if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
#endif

            DataTable dataTable = new DataTable(BaseItemDetailsEntity.TableName);
            BaseItemDetailsManager itemDetailsManager = new BaseItemDetailsManager(dbHelper, userInfo);
            // 检查有其他目标数据库表存储了数据
            BaseItemsManager itemsManager = new BaseItemsManager(dbHelper, userInfo);
            BaseItemsEntity itemsEntity = new BaseItemsEntity(itemsManager.GetDataTable(new KeyValuePair<string, object>(BaseItemsEntity.FieldCode, code)));
            if (!String.IsNullOrEmpty(itemsEntity.TargetTable))
            {
                itemDetailsManager = new BaseItemDetailsManager(dbHelper, userInfo, itemsEntity.TargetTable);
            }
            // 这里只要有效的，没被删除的
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldEnabled, 1));
            parameters.Add(new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldDeletionStateCode, 0));

            dataTable = itemDetailsManager.GetDataTable(parameters, BaseItemDetailsEntity.FieldSortCode);
            dataTable.TableName = itemsEntity.TargetTable;
            return dataTable;
        }

        /// <summary>
        /// 按编号获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="code">编号</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByCode(BaseUserInfo userInfo, string code)
        {
            // 写入调试信息
#if (DEBUG)
            int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
#endif

            // 加强安全验证防止未授权匿名调用
#if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
#endif

            DataTable dataTable = new DataTable(BaseItemDetailsEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    dataTable = this.GetDataTableByCode(dbHelper, userInfo, code);
                    // 添加日志
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.ItemDetailsService_GetDataTableByCode, MethodBase.GetCurrentMethod());
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
        /// 批量获取选项数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="codes">编号数组</param>
        /// <returns>数据权限合</returns>
        public DataSet GetDSByCodes(BaseUserInfo userInfo, string[] codes)
        {
            // 写入调试信息
#if (DEBUG)
            int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
#endif

            // 加强安全验证防止未授权匿名调用
#if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
#endif

            DataSet dataSet = new DataSet();
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    for (int i = 0; i < codes.Length; i++)
                    {
                        DataTable dataTable = this.GetDataTableByCode(dbHelper, userInfo, codes[i]);
                        dataTable.TableName = codes[i];
                        dataSet.Tables.Add(dataTable);
                    }
                    // 添加日志
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.ItemDetailsService_GetDSByCodes, MethodBase.GetCurrentMethod());
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

            return dataSet;
        }

        #region public BaseItemDetailsEntity GetEntity(BaseUserInfo userInfo, string tableName, string id) 获取實體
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
        public BaseItemDetailsEntity GetEntity(BaseUserInfo userInfo, string tableName, string id)
        {
            // 写入调试信息
#if (DEBUG)
            int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
#endif

            // 加强安全验证防止未授权匿名调用
#if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
#endif

            BaseItemDetailsEntity itemDetailsEntity = null;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseItemDetailsManager itemDetailsManager = new BaseItemDetailsManager(dbHelper, userInfo, tableName);
                    itemDetailsEntity = itemDetailsManager.GetEntity(id);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.ItemDetailsService_GetEntity, MethodBase.GetCurrentMethod());
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

            return itemDetailsEntity;
        }
        #endregion

        #region public BaseItemDetailsEntity GetEntity(BaseUserInfo userInfo, string tableName, string id) 获取實體
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
        public BaseItemDetailsEntity GetEntityByCode(BaseUserInfo userInfo, string tableName, string code)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            BaseItemDetailsEntity itemDetailsEntity = new BaseItemDetailsEntity();
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseItemDetailsManager itemDetailsManager = new BaseItemDetailsManager(dbHelper, userInfo, tableName);
                    DataTable datatable = itemDetailsManager.GetDataTable(new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldItemCode, code), BaseItemDetailsEntity.FieldSortCode);
                    if((datatable != null)&&(datatable.Rows.Count>0))
                    {
                        itemDetailsEntity =  itemDetailsEntity.GetFrom(datatable.Rows[0]);
                    }                   
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.ItemDetailsService_GetEntity, MethodBase.GetCurrentMethod());
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

            return itemDetailsEntity;
        }
        #endregion


        #region public string Add(BaseUserInfo userInfo, string tableName, BaseItemDetailsEntity itemDetailsEntity, out string statusCode, out string statusMessage) 添加编码
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>数据表</returns>
        public string Add(BaseUserInfo userInfo, string tableName, BaseItemDetailsEntity itemDetailsEntity, out string statusCode, out string statusMessage)
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
            statusCode = string.Empty;
            statusMessage = string.Empty;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseItemDetailsManager itemDetailsManager = new BaseItemDetailsManager(dbHelper, userInfo, tableName);
                    // 调用方法，并且返回运行结果
                    returnValue = itemDetailsManager.Add(itemDetailsEntity, out statusCode);
                    statusMessage = itemDetailsManager.GetStateMessage(statusCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.ItemDetailsService_Add, MethodBase.GetCurrentMethod());
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

        #region public int Update(BaseUserInfo userInfo, string tableName, BaseItemDetailsEntity itemDetailsEntity, out string statusCode, out string statusMessage) 更新编码
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>数据表</returns>
        public int Update(BaseUserInfo userInfo, string tableName, BaseItemDetailsEntity itemDetailsEntity, out string statusCode, out string statusMessage)
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
                    BaseItemDetailsManager itemDetailsManager = new BaseItemDetailsManager(dbHelper, userInfo, tableName);
                    // 编辑数据
                    returnValue = itemDetailsManager.Update(itemDetailsEntity, out statusCode);
                    statusMessage = itemDetailsManager.GetStateMessage(statusCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.ItemDetailsService_Update, MethodBase.GetCurrentMethod());
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

        #region public int Delete(BaseUserInfo userInfo, string tableName, string id) 删除實體
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="tableName">目标表</param>
        /// <param name="id">主键</param>
        /// <returns>影响的行数</returns>
        public int Delete(BaseUserInfo userInfo, string tableName, string id)
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
                    BaseItemDetailsManager itemDetailsManager = new BaseItemDetailsManager(dbHelper, userInfo, tableName);
                    returnValue = itemDetailsManager.Delete(id);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.ItemDetailsService_Delete, MethodBase.GetCurrentMethod());
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

        #region public int BatchMoveTo(BaseUserInfo userInfo, string tableName, string[] ids, string targetId) 批量移动
        /// <summary>
        /// 批量移动
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="tableName">目标表</param>
        /// <param name="ids">编码主键数组</param>
        /// <param name="targetId">目标主键</param>
        /// <returns>影响行数</returns>
        public int BatchMoveTo(BaseUserInfo userInfo, string tableName, string[] ids, string targetId)
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
                    BaseItemDetailsManager itemDetailsManager = new BaseItemDetailsManager(dbHelper, userInfo, tableName);
                    for (int i = 0; i < ids.Length; i++)
                    {
                        returnValue += itemDetailsManager.SetProperty(ids[i], new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldParentId, targetId));
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.ItemDetailsService_BatchMoveTo, MethodBase.GetCurrentMethod());
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

        #region public int BatchDelete(BaseUserInfo userInfo, string tableName, string[] ids) 批量删除编码
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="tableName">目标表</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int BatchDelete(BaseUserInfo userInfo, string tableName, string[] ids)
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
                    BaseItemDetailsManager itemDetailsManager = new BaseItemDetailsManager(dbHelper, userInfo, tableName);
                    returnValue = itemDetailsManager.Delete(ids);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.ItemDetailsService_BatchDelete, MethodBase.GetCurrentMethod());
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

        #region public int BatchSave(BaseUserInfo userInfo, DataTable dataTable) 批量保存
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
                    BaseItemDetailsManager itemDetailsManager = new BaseItemDetailsManager(dbHelper, userInfo, dataTable.TableName);
                    returnValue = itemDetailsManager.BatchSave(dataTable);
                    // dataTable = BaseItemDetails.GetDataTableByParent(ParentId);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.ItemDetailsService_BatchSave, MethodBase.GetCurrentMethod());
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