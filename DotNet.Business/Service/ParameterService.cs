//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd.
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Reflection;
using System.ServiceModel;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// ParameterService
    /// 参数服务
    /// 
    /// 修改纪录
    /// 
    ///		2008.04.30 版本：1.0 JiRiGaLa 创建。
    ///		2011.07.15 版本：2.0 JiRiGaLa 获取服务器端配置的功能改进。
    ///	
    /// 版本：2.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.07.15</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class ParameterService : System.MarshalByRefObject, IParameterService
    {
        private string serviceName = AppMessage.ParameterService;

        /// <summary>
        /// 用户中心数据库连接
        /// </summary>
        private readonly string UserCenterDbConnection = BaseSystemInfo.UserCenterDbConnection;

        /// <summary>
        /// 获取服务器上的配置信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="key">配置项主键</param>
        /// <returns>配置内容</returns>
        public string GetServiceConfig(BaseUserInfo userInfo, string key)
        {
            return UserConfigHelper.GetValue(key);
        }

        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryId">分类主键</param>
        /// <param name="parameterId">参数主键</param>
        /// <param name="parameterCode">参数编号</param>
        /// <returns>参数值</returns>
        public string GetParameter(BaseUserInfo userInfo, string categoryId, string parameterId, string parameterCode)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            // #if (!DEBUG)
            //     LogOnService.UserIsLogOn(userInfo);
            // #endif

            string returnValue = string.Empty;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseParameterManager parameterManager = new BaseParameterManager(dbHelper, userInfo);
                    returnValue = parameterManager.GetParameter(categoryId, parameterId, parameterCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.ParameterService_GetParameter, MethodBase.GetCurrentMethod());
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
        /// 设置参数值
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryId">分类主键</param>
        /// <param name="parameterId">参数主键</param>
        /// <param name="parameterCode">参数编号</param>
        /// <param name="parameterContent">参数内容</param>
        /// <returns>影响行数</returns>
        public int SetParameter(BaseUserInfo userInfo, string categoryId, string parameterId, string parameterCode, string parameterContent)
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
                    BaseParameterManager parameterManager = new BaseParameterManager(dbHelper, userInfo);
                    returnValue = parameterManager.SetParameter(categoryId, parameterId, parameterCode, parameterContent);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.ParameterService_SetParameter, MethodBase.GetCurrentMethod());
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
        /// 获取参数列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryId">分类主键</param>
        /// <param name="parameterId">参数主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByParameter(BaseUserInfo userInfo, string categoryId, string parameterId)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseParameterEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseParameterManager parameterManager = new BaseParameterManager(dbHelper, userInfo);
                    dataTable = parameterManager.GetDataTableByParameter(categoryId, parameterId);
                    dataTable.TableName = BaseParameterEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, AppMessage.ParameterService_GetDataTableByParameter, this.serviceName, MethodBase.GetCurrentMethod());
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
        /// 按编号获取参数列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryId">分类主键</param>
        /// <param name="parameterId">参数主键</param>
        /// <param name="parameterCode">参数编号</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableParameterCode(BaseUserInfo userInfo, string categoryId, string parameterId, string parameterCode)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseParameterEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseParameterManager parameterManager = new BaseParameterManager(dbHelper, userInfo);
                    dataTable = parameterManager.GetDataTableParameterCode(categoryId, parameterId, parameterCode);
                    dataTable.TableName = BaseParameterEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.ParameterService_GetDataTableParameterCode, MethodBase.GetCurrentMethod());
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
        /// 删除参数
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryId">分类主键</param>
        /// <param name="parameterId">参数主键</param>
        /// <returns>影响行数</returns>
        public int DeleteByParameter(BaseUserInfo userInfo, string categoryId, string parameterId)
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
                    BaseParameterManager parameterManager = new BaseParameterManager(dbHelper, userInfo);
                    returnValue = parameterManager.DeleteByParameter(categoryId, parameterId);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.ParameterService_DeleteByParameter, MethodBase.GetCurrentMethod());
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
        /// 按参数编号删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryId">分类主键</param>
        /// <param name="parameterId">参数主键</param>
        /// <param name="parameterCode">参数编号</param>
        /// <returns>影响行数</returns>
        public int DeleteByParameterCode(BaseUserInfo userInfo, string categoryId, string parameterId, string parameterCode)
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
                    BaseParameterManager parameterManager = new BaseParameterManager(dbHelper, userInfo);
                    returnValue = parameterManager.DeleteByParameterCode(categoryId, parameterId, parameterCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.ParameterService_DeleteByParameterCode, MethodBase.GetCurrentMethod());
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
        /// 删除参数
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
                    BaseParameterManager parameterManager = new BaseParameterManager(dbHelper, userInfo);
                    returnValue = parameterManager.Delete(id);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.ParameterService_Delete, MethodBase.GetCurrentMethod());
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
        /// 批量删除参数
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
                    BaseParameterManager parameterManager = new BaseParameterManager(dbHelper, userInfo);
                    for (int i = 0; i < ids.Length; i++)
                    {
                        returnValue += parameterManager.Delete(ids[i]);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.ParameterService_BatchDelete, MethodBase.GetCurrentMethod());
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