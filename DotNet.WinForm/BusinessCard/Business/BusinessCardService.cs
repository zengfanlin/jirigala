//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace DotNet.WinForm
{
    using DotNet.Utilities;
    using DotNet.Business;

    /// <summary>
    /// BusinessCardService
    /// 名片管理服务
    /// 
    /// 修改纪录
    /// 
    ///		2008.11.16 版本：1.0 JiRiGaLa 基础编码管理。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.11.16</date>
    /// </author> 
    /// </summary>
    public class BusinessCardService : System.MarshalByRefObject, IBusinessCardService
    {
        /// <summary>
        /// 用户中心数据库连接
        /// </summary>
        private readonly string UserCenterDbConnection = BaseSystemInfo.UserCenterDbConnection;

        #region public DataTable GetDataTable(BaseUserInfo userInfo)
        /// <summary>
        /// 获取全部列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTable(BaseUserInfo userInfo)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif
            DataTable dataTable = new DataTable(BaseBusinessCardTable.TableName);

            // IDbHelper dbHelper = DbHelperFactory.GetHelper();
            
            // 使用工厂模式 传入 数据库类型
            IDbHelper dbHelper = null;
            if (DbHelper.DbType == CurrentDbType.Access)
                dbHelper = DbHelperFactory.GetHelper(DbHelper.DbType);
            else
                dbHelper = DbHelperFactory.GetHelper();
            // 使用工厂模式 传入 数据库类型

            try
            {
                dbHelper.Open(UserCenterDbConnection);
                BaseBusinessCardManager businessCardManager = new BaseBusinessCardManager(dbHelper, userInfo);
                dataTable = businessCardManager.GetDataTable();
                dataTable.TableName = BaseBusinessCardTable.TableName;
                // 添加日志
                BaseLogManager.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
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

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return dataTable;
        }
        #endregion

        #region public DataTable GetPublicDT(BaseUserInfo userInfo)
        /// <summary>
        /// 获取公开列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetPublicDT(BaseUserInfo userInfo)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif
            DataTable dataTable = new DataTable(BaseBusinessCardTable.TableName);
                        
            // 使用工厂模式 传入 数据库类型
            IDbHelper dbHelper = null;
            if (DbHelper.DbType == CurrentDbType.Access)
                dbHelper = DbHelperFactory.GetHelper(DbHelper.DbType);
            else
                dbHelper = DbHelperFactory.GetHelper();
            // 使用工厂模式 传入 数据库类型      

            try
            {
                dbHelper.Open(UserCenterDbConnection);
                BaseBusinessCardManager businessCardManager = new BaseBusinessCardManager(dbHelper, userInfo);
                dataTable = businessCardManager.GetDataTable(new KeyValuePair<string, object>(BaseBusinessCardTable.FieldPersonal, 0), BaseBusinessCardTable.FieldSortCode);
                dataTable.TableName = BaseBusinessCardTable.TableName;
                
                /*
                // 这里按权限进行过滤字段(表字段权限用例，把没权限的字段都进行排除)
                BaseTableColumnsManager tableColumnsManager = new BaseTableColumnsManager(dbHelper, userInfo);
                // 这里是当前用户能访问的列名
                string[] columns = tableColumnsManager.GetColumns(userInfo.Id, BaseBusinessCardTable.TableName, "Column.Access");
                // 这是按能访问的列进行过滤的函数
                BaseBusinessLogic.SetColumnsFilter(dataTable, columns);
                */

                // 添加日志
                BaseLogManager.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
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

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return dataTable;
        }
        #endregion

        #region public DataTable GetDataTableByUser(BaseUserInfo userInfo)
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByUser(BaseUserInfo userInfo)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif
            DataTable dataTable = new DataTable(BaseBusinessCardTable.TableName);

            // IDbHelper dbHelper = DbHelperFactory.GetHelper();
            
            // 使用工厂模式 传入 数据库类型
            IDbHelper dbHelper = null;
            if (DbHelper.DbType == CurrentDbType.Access)
                dbHelper = DbHelperFactory.GetHelper(DbHelper.DbType);
            else
                dbHelper = DbHelperFactory.GetHelper();
            
            try
            {
                dbHelper.Open(UserCenterDbConnection);
                BaseBusinessCardManager businessCardManager = new BaseBusinessCardManager(dbHelper, userInfo);
                //dataTable = businessCardManager.GetDataTable(BaseBusinessCardTable.FieldCreateUserId, userInfo.Id);
                dataTable = businessCardManager.GetDataTable(new KeyValuePair<string, object>(BaseBusinessCardTable.FieldPersonal, 1), BaseBusinessCardTable.FieldSortCode);
          
                
                dataTable.TableName = BaseBusinessCardTable.TableName;
                // 添加日志
                BaseLogManager.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
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

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return dataTable;
        }
        #endregion

        #region public DataTable Get(BaseUserInfo userInfo, string id)
        /// <summary>
        /// 获取某个
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
        public DataTable Get(BaseUserInfo userInfo, string id)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif
            DataTable dataTable = new DataTable(BaseBusinessCardTable.TableName);

            // 使用工厂模式 传入 数据库类型
            IDbHelper dbHelper = null;
            if (DbHelper.DbType == CurrentDbType.Access)
                dbHelper = DbHelperFactory.GetHelper(DbHelper.DbType);
            else
                dbHelper = DbHelperFactory.GetHelper();
            // 使用工厂模式 传入 数据库类型 

            try
            {
                dbHelper.Open(UserCenterDbConnection);
                BaseBusinessCardManager businessCardManager = new BaseBusinessCardManager(dbHelper, userInfo);
                dataTable = businessCardManager.GetDataTableById(id);
                dataTable.TableName = BaseBusinessCardTable.TableName;
                // 添加日志
                BaseLogManager.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
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
            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return dataTable;
        }
        #endregion

        #region public BaseBusinessCardEntity GetEntity(BaseUserInfo userInfo, string id)
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
        public BaseBusinessCardEntity GetEntity(BaseUserInfo userInfo, string id)
        {
            DataTable dataTable = this.Get(userInfo, id);
            BaseBusinessCardEntity businessCardEntity = new BaseBusinessCardEntity(dataTable);
            return businessCardEntity;
        }
        #endregion

        #region public string AddEntity(BaseUserInfo userInfo, BaseBusinessCardEntity businessCardEntity, out string statusCode, out string statusMessage)
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="businessCardEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>主键主键</returns>
        public string AddEntity(BaseUserInfo userInfo, BaseBusinessCardEntity businessCardEntity, out string statusCode, out string statusMessage)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif
            
            string returnValue = string.Empty;
            statusCode = string.Empty;
            statusMessage = string.Empty;
            
            // 使用工厂模式 传入 数据库类型
            IDbHelper dbHelper = null;
            if (DbHelper.DbType == CurrentDbType.Access)
                dbHelper = DbHelperFactory.GetHelper(DbHelper.DbType);
            else
                dbHelper = DbHelperFactory.GetHelper();
            // 使用工厂模式 传入 数据库类型

            // IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open(UserCenterDbConnection);
                BaseBusinessCardManager businessCardManager = new BaseBusinessCardManager(dbHelper, userInfo);
                // 调用方法，并且返回运行结果
                returnValue = businessCardManager.Add(businessCardEntity);
                // returnValue = businessCardManager.Add(businessCardEntity, out statusCode);
                statusMessage = businessCardManager.GetStateMessage(statusCode);
                BaseLogManager.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
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
            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return returnValue;
        }
        #endregion

        #region public string Add(BaseUserInfo userInfo, DataTable dataTable, out string statusCode, out string statusMessage)
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>数据表</returns>
        public string Add(BaseUserInfo userInfo, DataTable dataTable, out string statusCode, out string statusMessage)
        {
            BaseBusinessCardEntity businessCardEntity = new BaseBusinessCardEntity(dataTable);
            return this.AddEntity(userInfo, businessCardEntity, out statusCode, out statusMessage);
        }
        #endregion

        #region public int UpdateEntity(BaseUserInfo userInfo, BaseBusinessCardEntity businessCardEntity, out string statusCode, out string statusMessage)
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="businessCardEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>影响行数</returns>
        public int UpdateEntity(BaseUserInfo userInfo, BaseBusinessCardEntity businessCardEntity, out string statusCode, out string statusMessage)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif
            statusCode = string.Empty;
            statusMessage = string.Empty;

            int returnValue = 0;

            // 使用工厂模式 传入 数据库类型
            IDbHelper dbHelper = null;
            if (DbHelper.DbType == CurrentDbType.Access)
                dbHelper = DbHelperFactory.GetHelper(DbHelper.DbType);
            else
                dbHelper = DbHelperFactory.GetHelper();

            // IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open(UserCenterDbConnection);
                BaseBusinessCardManager businessCardManager = new BaseBusinessCardManager(dbHelper, userInfo);
                // 编辑数据
                returnValue = businessCardManager.Update(businessCardEntity);
                // returnValue = businessCardManager.Update(businessCardEntity, out statusCode);

                statusMessage = businessCardManager.GetStateMessage(statusCode);
                BaseLogManager.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
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

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return returnValue;
        }
        #endregion

        #region public int Update(BaseUserInfo userInfo, DataTable dataTable, out string statusCode, out string statusMessage)
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>影响行数</returns>
        public int Update(BaseUserInfo userInfo, DataTable dataTable, out string statusCode, out string statusMessage)
        {
            BaseBusinessCardEntity businessCardEntity = new BaseBusinessCardEntity(dataTable);
            return this.UpdateEntity(userInfo, businessCardEntity, out statusCode, out statusMessage);
        }
        #endregion

        #region public int BatchDelete(BaseUserInfo userInfo, string[] ids)
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

            int returnValue = 0;

            // 使用工厂模式 传入 数据库类型
            IDbHelper dbHelper = null;
            if (DbHelper.DbType == CurrentDbType.Access)
                dbHelper = DbHelperFactory.GetHelper(DbHelper.DbType);
            else
                dbHelper = DbHelperFactory.GetHelper();

            // IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open(UserCenterDbConnection);
                BaseBusinessCardManager businessCardManager = new BaseBusinessCardManager(dbHelper, userInfo);
                returnValue = businessCardManager.Delete(ids);
                BaseLogManager.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
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

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return returnValue;
        }
        #endregion

        #region public DataTable BatchSave(BaseUserInfo userInfo, DataTable dataTable)
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

            int returnValue = 0;

            // 使用工厂模式 传入 数据库类型
            IDbHelper dbHelper = null;
            if (DbHelper.DbType == CurrentDbType.Access)
                dbHelper = DbHelperFactory.GetHelper(DbHelper.DbType);
            else
                dbHelper = DbHelperFactory.GetHelper();

            // IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open(UserCenterDbConnection);
                BaseBusinessCardManager businessCardManager = new BaseBusinessCardManager(dbHelper, userInfo);
                BaseBusinessCardEntity businessCardEntity = null;
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    businessCardEntity = new BaseBusinessCardEntity(dataRow);
                    returnValue += businessCardManager.Update(businessCardEntity);
                }
                BaseLogManager.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
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

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return returnValue;
        }
        #endregion
    }
}