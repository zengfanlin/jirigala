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
    /// SequenceService
    /// 序列服务
    /// 
    /// 修改纪录
    /// 
    ///		2007.08.15 版本：2.2 JiRiGaLa 改进运行速度采用 WebService 变量定义 方式处理数据。
    ///		2007.08.14 版本：2.1 JiRiGaLa 改进运行速度采用 Instance 方式处理数据。
    ///		2007.05.14 版本：1.0 JiRiGaLa 窗体与数据库连接的分离。
    ///		
    /// 版本：2.2
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.08.15</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class SequenceService : System.MarshalByRefObject, ISequenceService
    {
        private string serviceName = AppMessage.SequenceService;

        /// <summary>
        /// 多用户并发处理用
        /// </summary>
        private static Object LOCK = new Object();

        /// <summary>
        /// 用户中心数据库连接
        /// </summary>
        private readonly string UserCenterDbConnection = BaseSystemInfo.UserCenterDbConnection;

        #region public string Add(BaseUserInfo userInfo, BaseSequenceEntity sequenceEntity, out string statusCode, out string statusMessage)
        /// <summary>
        /// 添加序列
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="sequenceEntity">序列实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>主键</returns>
        public string Add(BaseUserInfo userInfo, BaseSequenceEntity sequenceEntity, out string statusCode, out string statusMessage)
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
                    BaseSequenceManager sequenceManager = new BaseSequenceManager(dbHelper, userInfo);
                    // 调用方法，并且返回运行结果
                    returnValue = sequenceManager.Add(sequenceEntity, out statusCode);
                    // returnValue = businessCardManager.Add(businessCardEntity, out statusCode);
                    statusMessage = sequenceManager.GetStateMessage(statusCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.SequenceService_Add, MethodBase.GetCurrentMethod());
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

        #region public string Add(BaseUserInfo userInfo, DataTable dataTable, out string statusCode, out string statusMessage)
        /// <summary>
        /// 添加编码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>数据表</returns>
        public string Add(BaseUserInfo userInfo, DataTable dataTable, out string statusCode, out string statusMessage)
        {
            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            BaseSequenceEntity sequenceEntity = new BaseSequenceEntity(dataTable);
            return this.Add(userInfo, sequenceEntity, out statusCode, out statusMessage);
        }
        #endregion

        #region public DataTable GetDataTable(BaseUserInfo userInfo) 获取序列号列表
        /// <summary>
        /// 获取序列号列表
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

            DataTable dataTable = new DataTable(BaseSequenceEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseSequenceManager sequenceManager = new BaseSequenceManager(dbHelper);
                    dataTable = sequenceManager.GetDataTable();
                    dataTable.TableName = BaseSequenceEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.SequenceService_GetDataTable, MethodBase.GetCurrentMethod());
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

        #region public BaseSequenceEntity GetEntity(BaseUserInfo userInfo, string id)
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        public BaseSequenceEntity GetEntity(BaseUserInfo userInfo, string id)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            BaseSequenceEntity sequenceEntity = null;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseSequenceManager sequenceManager = new BaseSequenceManager(dbHelper, userInfo);
                    sequenceEntity = sequenceManager.GetEntity(id);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.SequenceService_GetEntity, MethodBase.GetCurrentMethod());
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
            return sequenceEntity;
        }
        #endregion

        #region public int Update(BaseUserInfo userInfo, BaseSequenceEntity sequenceEntity, out string statusCode, out string statusMessage)
        /// <summary>
        /// 更新序列
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="sequenceEntity">序列实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>影响行数</returns>
        public int Update(BaseUserInfo userInfo, BaseSequenceEntity sequenceEntity, out string statusCode, out string statusMessage)
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
                    BaseSequenceManager sequenceManager = new BaseSequenceManager(dbHelper, userInfo);
                    // 编辑数据
                    returnValue = sequenceManager.Update(sequenceEntity, out statusCode);
                    // returnValue = businessCardManager.Update(businessCardEntity, out statusCode);
                    statusMessage = sequenceManager.GetStateMessage(statusCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.SequenceService_Update, MethodBase.GetCurrentMethod());
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

        #region public int Update(BaseUserInfo userInfo, DataTable dataTable, out string statusCode, out string statusMessage)
        /// <summary>
        /// 更新编码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>数据表</returns>
        public int Update(BaseUserInfo userInfo, DataTable dataTable, out string statusCode, out string statusMessage)
        {
            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            BaseSequenceEntity sequenceEntity = new BaseSequenceEntity(dataTable);
            return this.Update(userInfo, sequenceEntity, out statusCode, out statusMessage);
        }
        #endregion

        #region public string GetSequence(BaseUserInfo userInfo, string fullName) 获取序列号
        /// <summary>
        /// 获取序列号
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="fullName">序列名称</param>
        /// <returns>序列号</returns>
        public string GetSequence(BaseUserInfo userInfo, string fullName)
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

            // 这里是为了防止并发冲突用的
            lock (LOCK)
            {
                using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
                {
                    try
                    {
                        dbHelper.Open(UserCenterDbConnection);
                        returnValue = this.GetSequence(dbHelper, userInfo, fullName);
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
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return returnValue;
        }
        #endregion

        #region public string GetSequence(IDbHelper dbHelper, BaseUserInfo userInfo, string fullName) 获取序列号
        /// <summary>
        /// 获取序列号
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户</param>
        /// <param name="fullName">序列名称</param>
        /// <returns>序列号</returns>
        public string GetSequence(IDbHelper dbHelper, BaseUserInfo userInfo, string fullName)
        {
            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            BaseSequenceManager sequenceManager = new BaseSequenceManager(dbHelper);
            return sequenceManager.GetSequence(fullName);
        }
        #endregion

        #region public string GetOldSequence(BaseUserInfo userInfo, string fullName, int defaultSequence, int sequenceLength, bool fillZeroPrefix) 获取原序列号
        /// <summary>
        /// 获取原序列号
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="fullName">序列名称</param>
        /// <param name="defaultSequence">默认序列</param>
        /// <param name="sequenceLength">序列长度</param>
        /// <param name="fillZeroPrefix">是否填充补零</param>
        /// <returns>序列号</returns>
        public string GetOldSequence(BaseUserInfo userInfo, string fullName, int defaultSequence, int sequenceLength, bool fillZeroPrefix)
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

            // 这里是为了防止并发冲突用的
            lock (LOCK)
            {
                using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
                {
                    try
                    {
                        dbHelper.Open(UserCenterDbConnection);
                        BaseSequenceManager sequenceManager = new BaseSequenceManager(dbHelper);
                        returnValue = sequenceManager.GetOldSequence(fullName, defaultSequence, sequenceLength, fillZeroPrefix);
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
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return returnValue;
        }
        #endregion

        #region public string GetNewSequence(BaseUserInfo userInfo, string fullName, int defaultSequence, int sequenceLength, bool fillZeroPrefix) 获取原序列号
        /// <summary>
        /// 获取新序列号
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="fullName">序列名称</param>
        /// <param name="defaultSequence">默认序列</param>
        /// <param name="sequenceLength">序列长度</param>
        /// <param name="fillZeroPrefix">是否填充补零</param>
        /// <returns>序列号</returns>
        public string GetNewSequence(BaseUserInfo userInfo, string fullName, int defaultSequence, int sequenceLength, bool fillZeroPrefix)
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

            // 这里是为了防止并发冲突用的
            lock (LOCK)
            {
                using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
                {
                    try
                    {
                        dbHelper.Open(UserCenterDbConnection);
                        BaseSequenceManager sequenceManager = new BaseSequenceManager(dbHelper);
                        returnValue = sequenceManager.GetSequence(fullName, defaultSequence, sequenceLength, fillZeroPrefix);
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
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return returnValue;
        }
        #endregion


        #region public string[] GetBatchSequence(BaseUserInfo userInfo, string fullName, int count) 获取序列号
        /// <summary>
        /// 获取序列号
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="fullName">序列名称</param>
        /// <param name="count">个数</param>
        /// <returns>序列号</returns>
        public string[] GetBatchSequence(BaseUserInfo userInfo, string fullName, int count)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            string[] returnValue = new string[0];

            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    returnValue = this.GetBatchSequence(dbHelper, userInfo, fullName, count);
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

        #region public string[] GetBatchSequence(IDbHelper dbHelper, BaseUserInfo userInfo, string fullName, count) 获取序列号
        /// <summary>
        /// 获取序列号
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户</param>
        /// <param name="fullName">序列名称</param>
        /// <param name="count">个数</param>
        /// <returns>序列号</returns>
        public string[] GetBatchSequence(IDbHelper dbHelper, BaseUserInfo userInfo, string fullName, int count)
        {
            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            BaseSequenceManager sequenceManager = new BaseSequenceManager(dbHelper);
            return sequenceManager.GetBatchSequence(fullName, count);
        }
        #endregion

        #region public string GetReduction(BaseUserInfo userInfo, string fullName) 获取序列号
        /// <summary>
        /// 获取倒序序列号
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="fullName">序列名称</param>
        /// <returns>序列号</returns>
        public string GetReduction(BaseUserInfo userInfo, string fullName)
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

            // 这里是为了防止并发冲突用的
            lock (LOCK)
            {
                using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
                {
                    try
                    {
                        dbHelper.Open(UserCenterDbConnection);
                        returnValue = this.GetReduction(dbHelper, userInfo, fullName);
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
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return returnValue;
        }
        #endregion

        #region public string GetReduction(IDbHelper dbHelper, BaseUserInfo userInfo, string fullName)
        /// <summary>
        /// 获取倒序序列号
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户</param>
        /// <param name="fullName">序列名称</param>
        /// <returns>序列号</returns>
        public string GetReduction(IDbHelper dbHelper, BaseUserInfo userInfo, string fullName)
        {
            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            BaseSequenceManager sequenceManager = new BaseSequenceManager(dbHelper);
            return sequenceManager.GetReduction(fullName);
        }
        #endregion

        #region public int Reset(BaseUserInfo userInfo, string[] ids) 批量重置
        /// <summary>
        /// 批量重置序列
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int Reset(BaseUserInfo userInfo, string[] ids)
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
                    BaseSequenceManager sequenceManager = new BaseSequenceManager(dbHelper);
                    returnValue = sequenceManager.Reset(ids);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.SequenceService_Reset, MethodBase.GetCurrentMethod());
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

        #region public int Delete(BaseUserInfo userInfo, string id) 删除序列
        /// <summary>
        /// 删除序列
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
                    BaseSequenceManager sequenceManager = new BaseSequenceManager(dbHelper);
                    returnValue = sequenceManager.Delete(id);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.SequenceService_Delete, MethodBase.GetCurrentMethod());
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

        #region public int BatchDelete(BaseUserInfo userInfo, string[] ids) 批量删除序列
        /// <summary>
        /// 批量删除序列
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>数据表</returns>
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
                    BaseSequenceManager sequenceManager = new BaseSequenceManager(dbHelper);
                    returnValue = sequenceManager.Delete(ids);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.SequenceService_BatchDelete, MethodBase.GetCurrentMethod());
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