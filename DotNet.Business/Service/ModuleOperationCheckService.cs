//------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2008 , ESSE , Ltd. 
//------------------------------------------------------------

using System;
using System.Data;
using System.Reflection;
using System.Diagnostics;

namespace DotNet.Common.Service
{
    using DotNet.Common.Utilities;
    using DotNet.Common.DbUtilities;
    using DotNet.Common.Business;

    /// <summary>
    /// ModuleOperationCheckService
    /// 权限判断服务
    /// 
    /// 修改纪录
    /// 
    ///		2008.05.10 版本：2.4 JiRiGaLa 命名为 ModuleOperationCheckService。
    ///		2007.10.18 版本：2.3 JiRiGaLa Authorization 函数进行整理。
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
    public class ModuleOperationCheckService : System.MarshalByRefObject
    {
        private static ModuleOperationCheckService instance = null;
        private static Object locker = new Object();

        public static ModuleOperationCheckService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new ModuleOperationCheckService();
                        }
                    }
                }
                return instance;
            }
        }

        #region public void Load()
        /// <summary>
        /// 加载服务层
        /// </summary>
        public void Load()
        {
        }
        #endregion

        #region public DataTable GetAuthorization(BaseUserInfo userInfo)
        /// <summary>
        /// 获得当前操作员的所有权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetAuthorization(BaseUserInfo userInfo)
        {
            return this.GetAuthorization(userInfo, userInfo.ID);
        }
        #endregion

        #region public DataTable GetAuthorization(BaseUserInfo userInfo, String userID)
        /// <summary>
        /// 获得一个职员的所有权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userID">职员代码</param>
        /// <returns>数据表</returns>
        public DataTable GetAuthorization(BaseUserInfo userInfo, String staffID)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.Instance.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif
            
            DataTable returnValue = new DataTable(BaseModuleOperationCheckDao.TableName);
            IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open();
                returnValue = BaseModuleOperationCheckDao.Instance.GetAuthorization(dbHelper, staffID);
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
        #endregion

        #region public DataTable GetAuthorization(BaseUserInfo userInfo, String userID, String moduleCode)
        /// <summary>
        /// 获得一个职员的某一模块的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userID">职员代码</param>
        /// <param name="moduleCode">模块代码</param>
        /// <returns>数据表</returns>
        public DataTable GetAuthorization(BaseUserInfo userInfo, String staffID, String moduleCode)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.Instance.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif
            
            DataTable returnValue = new DataTable(BaseModuleOperationCheckDao.TableName);
            IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open();
                returnValue = BaseModuleOperationCheckDao.Instance.GetAuthorization(dbHelper, staffID, moduleCode);
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
        #endregion
        
        #region public bool Authorization(BaseUserInfo userInfo, String moduleCode, OperationCode operationCode)
        /// <summary>
        /// 是否有相应模块的相应权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userID">职员代码</param>
        /// <param name="moduleCode">模块编号</param>
        /// <param name="operationCode">权限编号</param>
        /// <returns>是否有权限</returns>
        public bool Authorization(BaseUserInfo userInfo, String moduleCode, OperationCode operationCode)
        {
            return this.Authorization(userInfo, userInfo.ID, moduleCode, operationCode.ToString());
        }
        #endregion

        #region public bool Authorization(BaseUserInfo userInfo, String moduleCode, String operationCode)
        /// <summary>
        /// 是否有相应模块的相应权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleCode">模块编号</param>
        /// <param name="operationCode">权限编号</param>
        /// <returns>是否有权限</returns>
        public bool Authorization(BaseUserInfo userInfo, String moduleCode, String operationCode)
        {
            return this.Authorization(userInfo, userInfo.ID, moduleCode, operationCode);
        }
        #endregion

        #region public bool Authorization(BaseUserInfo userInfo, String userID, String moduleCode, OperationCode operationCode)
        /// <summary>
        /// 是否有相应模块的相应权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userID">职员代码</param>
        /// <param name="moduleCode">模块编号</param>
        /// <param name="operationCode">权限编号</param>
        /// <returns>是否有权限</returns>
        public bool Authorization(BaseUserInfo userInfo, String staffID, String moduleCode, OperationCode operationCode)
        {
            return this.Authorization(userInfo, staffID, moduleCode, operationCode.ToString());
        }
        #endregion

        #region public bool Authorization(BaseUserInfo userInfo, String userID, String moduleCode, String operationCode)
        /// <summary>
        /// 是否有相应模块的相应权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userID">职员代码</param>
        /// <param name="moduleCode">模块编号</param>
        /// <param name="operationCode">权限编号</param>
        /// <returns>是否有权限</returns>
        public bool Authorization(BaseUserInfo userInfo, String staffID, String moduleCode, String operationCode)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.Instance.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif
            bool returnValue = false;
            IDbHelper dbHelper = DbHelperFactory.GetHelper();
            try
            {
                dbHelper.Open();
                returnValue = BaseModuleOperationCheckDao.Instance.Authorization(dbHelper, staffID, moduleCode, operationCode);
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
        #endregion
    }
}