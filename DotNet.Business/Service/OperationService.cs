//------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2008 , ESSE , Ltd. 
//------------------------------------------------------------

using System;
using System.Data;
using System.Reflection;
using System.Diagnostics;

namespace DotNet.Common.Service
{
    using DotNet.Common.Model;
    using DotNet.Common.Utilities;
    using DotNet.Common.DbUtilities;
    using DotNet.Common.Business;
    using DotNet.Common.IService;

    /// <summary>
    /// OperationService
    /// 权限操作服务
    /// 
    /// 修改纪录
    ///  
    ///		2008.05.09 版本：2.4 JiRiGaLa 命名修改为 OperationService。
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
    public class OperationService : System.MarshalByRefObject, IOperationService
    {
        private static OperationService instance = null;
        private static Object locker = new Object();

        public static OperationService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new OperationService();
                        }
                    }
                }
                return instance;
            }
        }

        public void Load()
        {
        }

        public DataTable GetList(BaseUserInfo userInfo)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.Instance.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            DataTable dataTable = new DataTable(BaseOperationTable.TableName);
            IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open();
                BaseOperationDao myPermission = new BaseOperationDao(dbHelper, userInfo);
                dataTable = myPermission.GetList();
                BaseLogDao.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
            }
            catch (Exception exception)
            {
                BaseExceptionDao.Instance.LogException(dbHelper, userInfo, exception);
                throw exception;
            }
            finally
            {
                dbHelper.Close();
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.Instance.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return dataTable;
        }

        #region public DataTable GetListByPermission(BaseUserInfo userInfo, String id) 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">代码</param> 
        /// <returns>数据集</returns>
        public DataTable GetListByPermission(BaseUserInfo userInfo, String id)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.Instance.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif
            DataTable dataTable = new DataTable();
            IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open();
                BaseModuleOperationDao myModuleOperation = new BaseModuleOperationDao(dbHelper, userInfo);
                dataTable = myModuleOperation.GetListByPermission(id);
                BaseLogDao.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
            }
            catch (Exception exception)
            {
                BaseExceptionDao.Instance.LogException(dbHelper, userInfo, exception);
                throw exception;
            }
            finally
            {
                dbHelper.Close();
            }
            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.Instance.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return dataTable;
        }
        #endregion

        public String Add(BaseUserInfo userInfo, BaseOperationEntity operationEntity, out String statusCode, out String statusMessage)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.Instance.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif
            statusCode = String.Empty;
            statusMessage = String.Empty;

            String returnValue = String.Empty;
            IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open();
                BaseOperationDao myOperationDao = new BaseOperationDao(dbHelper, userInfo);
                returnValue = myOperationDao.Add(operationEntity, out statusCode);
                // 获得状态消息
                statusMessage = myOperationDao.GetStateCodeMessage(statusCode);
                BaseLogDao.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
            }
            catch (Exception exception)
            {
                BaseExceptionDao.Instance.LogException(dbHelper, userInfo, exception);
                throw exception;
            }
            finally
            {
                dbHelper.Close();
            }
            
            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.Instance.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return returnValue;
        }

        public String AddByDetail(BaseUserInfo userInfo, String code, String fullName, out String statusCode, out String statusMessage)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.Instance.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif            
            statusCode = String.Empty;
            statusMessage = String.Empty;
            
            String returnValue = String.Empty;
            IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open();
                BaseOperationDao myOperation = new BaseOperationDao(dbHelper, userInfo);
                returnValue = myOperation.AddByDetail(code, fullName, out statusCode);
                // 获得状态消息
                statusMessage = myOperation.GetStateCodeMessage(statusCode);
                BaseLogDao.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
            }
            catch (Exception exception)
            {
                BaseExceptionDao.Instance.LogException(dbHelper, userInfo, exception);
                throw exception;
            }
            finally
            {
                dbHelper.Close();
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.Instance.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return returnValue;
        }

        public BaseOperationEntity Get(BaseUserInfo userInfo, String id)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.Instance.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            BaseOperationEntity operationEntity = new BaseOperationEntity();
            IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open();
                // 创建实现类
                DataTable myReturnDataTable = new DataTable(BaseOperationTable.TableName);
                BaseOperationDao myPermission = new BaseOperationDao(dbHelper, userInfo);
                myReturnDataTable = myPermission.Get(id);
                operationEntity = new BaseOperationEntity(myReturnDataTable);
                BaseLogDao.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
            }
            catch (Exception exception)
            {
                BaseExceptionDao.Instance.LogException(dbHelper, userInfo, exception);
                throw exception;
            }
            finally
            {
                dbHelper.Close();
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.Instance.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
                return operationEntity;
        }

        public DataTable GetByCode(BaseUserInfo userInfo, String code, out String statusCode, out String statusMessage)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.Instance.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif
            statusCode = String.Empty;
            statusMessage = String.Empty;

            DataTable myReturnDataTable = new DataTable(BaseOperationTable.TableName);
            IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open();
                // 创建实现类
                BaseOperationDao myOperation = new BaseOperationDao(dbHelper, userInfo);
                myReturnDataTable = myOperation.GetByCode(code);
                // 获得状态消息
                statusMessage = myOperation.GetStateCodeMessage(statusCode);
                BaseLogDao.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
            }
            catch (Exception exception)
            {
                BaseExceptionDao.Instance.LogException(dbHelper, userInfo, exception);
                throw exception;
            }
            finally
            {
                dbHelper.Close();
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.Instance.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return myReturnDataTable;
        }

        public String GetFullNameByCode(BaseUserInfo userInfo, String code)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.Instance.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif
            String returnValue = String.Empty;

            IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open();
                BaseOperationDao myPermissionDao = new BaseOperationDao(dbHelper, userInfo);
                returnValue = myPermissionDao.GetFullNameByCode(code);
                BaseLogDao.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
            }
            catch (Exception exception)
            {
                BaseExceptionDao.Instance.LogException(dbHelper, userInfo, exception);
                throw exception;
            }
            finally
            {
                dbHelper.Close();
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.Instance.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return returnValue;
        }

        public int Update(BaseUserInfo userInfo, BaseOperationEntity operationEntity, out String statusCode, out String statusMessage)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.Instance.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif
            statusCode = String.Empty;
            statusMessage = String.Empty;

            int returnValue = 0;
            IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open();
                BaseOperationDao myPermissionDao = new BaseOperationDao(dbHelper, userInfo);
                returnValue = myPermissionDao.Update(operationEntity, out statusCode);
                // 获得状态消息
                statusMessage = myPermissionDao.GetStateCodeMessage(statusCode);
                BaseLogDao.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
            }
            catch (Exception exception)
            {
                BaseExceptionDao.Instance.LogException(dbHelper, userInfo, exception);
                throw exception;
            }
            finally
            {
                dbHelper.Close();
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.Instance.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return returnValue;
        }

        public int BatchDelete(BaseUserInfo userInfo, String[] ids)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.Instance.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            int returnValue = 0;
            IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open();
                BaseOperationDao myPermissionDao = new BaseOperationDao(dbHelper, userInfo);
                returnValue = myPermissionDao.BatchDelete(ids);
                BaseLogDao.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
            }
            catch (Exception exception)
            {
                BaseExceptionDao.Instance.LogException(dbHelper, userInfo, exception);
                throw exception;
            }
            finally
            {
                dbHelper.Close();
            }
            
            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.Instance.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return returnValue;
        }

        public DataTable BatchSave(BaseUserInfo userInfo, DataTable dataTable)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.Instance.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif
            
            DataTable myReturnDataTable = new DataTable(BaseOperationTable.TableName);
            IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open();
                // 创建实现类
                BaseOperationDao myPermissionDao = new BaseOperationDao(dbHelper, userInfo);
                myPermissionDao.BatchSave(dataTable);
                myReturnDataTable = myPermissionDao.GetList();
                BaseLogDao.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
            }
            catch (Exception exception)
            {
                BaseExceptionDao.Instance.LogException(dbHelper, userInfo, exception);
                throw exception;
            }
            finally
            {
                dbHelper.Close();
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.Instance.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return myReturnDataTable;
        }

        #region public DataTable BatchSaveByModule(BaseUserInfo userInfo, DataTable dataTable, String id) 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <param name="id">模块代码</param>
        /// <returns>数据表</returns>
        public DataTable BatchSaveByModule(BaseUserInfo userInfo, DataTable dataTable, String id)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.Instance.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif
            IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open();
                BaseModuleOperationDao myModuleOperation = new BaseModuleOperationDao(dbHelper, userInfo);
                myModuleOperation.BatchSave(dataTable);
                dataTable = myModuleOperation.GetListByPermission(id);
                BaseLogDao.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
            }
            catch (Exception exception)
            {
                BaseExceptionDao.Instance.LogException(dbHelper, userInfo, exception);
                throw exception;
            }
            finally
            {
                dbHelper.Close();
            }
            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.Instance.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return dataTable;
        }
        #endregion
    }
}