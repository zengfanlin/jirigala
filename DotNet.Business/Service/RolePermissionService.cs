//------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2008 , ESSE , Ltd. 
//------------------------------------------------------------

using System;
using System.Data;
using System.Reflection;
using System.Diagnostics;

namespace ESSE.Common.Service
{
    using ESSE.Common;
    using ESSE.Common.Utilities;

    /// <summary>
    /// RolePermissionAdminService
    /// 
    /// 修改纪录
    /// 
    ///     2007.06.11 版本：1.1 JiRiGaLa 加入调试信息#if (DEBUG)。
    ///     2007.06.06 版本：1.0 JiRiGaLa 职员模块。
    ///		
    /// 版本：1.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.06.11</date>
    /// </author> 
    /// </summary>
    public class RolePermissionService : System.MarshalByRefObject, IRolePermissionService
    {
        private static RolePermissionService instance = null;
        private static Object locker = new Object();

        public static RolePermissionService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new RolePermissionService();
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

        #region public DataSet GetList(BaseOperatorInfo myOperatorInfo, string paramRoleID) 窗体加载
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="myOperatorInfo">操作员信息</param>
        /// <param name="paramRoleID">角色代码</param>
        /// <returns>数据集</returns>
        public DataSet GetList(BaseOperatorInfo myOperatorInfo, string paramRoleID)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.Instance.StartDebug(myOperatorInfo, MethodBase.GetCurrentMethod());
            #endif
            DataSet myDataSet = new DataSet();
            IBaseDbConnection myDbConnection = new OleDbHelper();
            try
            {
                myDbConnection.Open();
                BaseLogDao.Instance.Add(myDbConnection, myOperatorInfo);
                BaseModuleDao myBUModule = new BaseModuleDao(myDbConnection, myOperatorInfo);
                BaseRolePermissionImpl myBaseRolePermissionImpl = new BaseRolePermissionImpl(myDbConnection, myOperatorInfo);
                myDataSet.Tables.Add(myBUModule.GetListByCategory(myOperatorInfo.RootMenuID));
                //BUBaseBusinessLogic.Instance.SetFilter(myDataSet, BUModule.TableName, BUModule.Field_Enabled, "1");
                myDataSet.Tables.Add(myBaseRolePermissionImpl.GetListByRole(paramRoleID));
                myDataSet.EnforceConstraints = false;
                myDataSet.Relations.Add("RolePermission", myDataSet.Tables[BaseModuleTable.TableName].Columns[BaseModuleTable.Field_ID], myDataSet.Tables[BaseRoleModulePermissionTable.TableName].Columns[BaseStaffModulePermissionTable.Field_ModuleID]);
                // 添加相应的权限数据
                myDataSet.Tables.Add(BasePermissionCheck.Instance.GetAuthorization(myDbConnection, myOperatorInfo.OperatorID, "FormRolePermissionAdmin"));
            }
            catch (Exception myException)
            {
                BaseExceptionDao.Instance.LogException(myDbConnection, myOperatorInfo, myException);
                throw myException;
            }
            finally
            {
                myDbConnection.Close();
            }
            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.Instance.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return myDataSet;
        }
        #endregion

        #region public DataTable BatchSave(BaseOperatorInfo myOperatorInfo, DataTable myDataTable, string paramID) 批量保存角色模块权限
        /// <summary>
        /// 批量保存角色模块权限
        /// </summary>
        /// <param name="myOperatorInfo">操作员信息</param>
        /// <param name="myDataTable">数据表</param>
        /// <param name="paramID">角色代码</param>
        /// <returns>音响的行数</returns>
        public DataTable BatchSave(BaseOperatorInfo myOperatorInfo, DataTable myDataTable, string paramID)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.Instance.StartDebug(myOperatorInfo, MethodBase.GetCurrentMethod());
            #endif
            IBaseDbConnection myDbConnection = new OleDbHelper();
            try
            {
                myDbConnection.Open();
                BaseRolePermissionImpl myRolePermissionImpl = new BaseRolePermissionImpl(myDbConnection, myOperatorInfo);
                myRolePermissionImpl.BatchSave(myDataTable);
                myDataTable = myRolePermissionImpl.GetListByRole(paramID);
                BaseLogDao.Instance.Add(myDbConnection, myOperatorInfo);
                // 添加相应的权限数据
                // myDataSet.Tables.Add(BasePermissionCheck.Instance.GetAuthorization(myDbConnection, myOperatorInfo.OperatorID, "FormRolePermissionAdmin"));
            }
            catch (Exception myException)
            {
                BaseExceptionDao.Instance.LogException(myDbConnection, myOperatorInfo, myException);
                throw myException;
            }
            finally
            {
                myDbConnection.Close();
            }
            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.Instance.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return myDataTable;
        }
        #endregion
    }
}