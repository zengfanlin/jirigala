//------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2008 , ESSE , Ltd. 
//------------------------------------------------------------

using System;
using System.Data;
using System.Reflection;
using System.Diagnostics;

namespace ESSE.Common.Service
{
    using ESSE.Common.Persistence;

    /// <summary>
    /// StaffRoleService
    /// 
    /// 修改纪录
    /// 
    ///     2007.05.28 版本：1.0 JiRiGaLa 职员角色。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.28</date>
    /// </author> 
    /// </summary>
    public class StaffRoleService : System.MarshalByRefObject, IStaffRoleService
    {
        private static StaffRoleService instance = null;
        private static Object locker = new Object();

        public static StaffRoleService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new StaffRoleService();
                        }
                    }
                }
                return instance;
            }
        }

        #region public DataSet GetList(BaseOperatorInfo myOperatorInfo, string paramStaffID) 窗体加载
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="myOperatorInfo">操作员信息</param>
        /// <param name="paramStaffID">职员代码</param>
        /// <returns>数据集</returns>
        public DataSet GetList(BaseOperatorInfo myOperatorInfo, string paramStaffID)
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
                BaseOrganizeDao myBUOrganize = new BaseOrganizeDao(myDbConnection, myOperatorInfo);
                // myDataSet.Tables.Add(myBUOrganize.GetList());
                BaseStaffRoleImpl myStaffRoleImpl = new BaseStaffRoleImpl(myDbConnection, myOperatorInfo);
                myDataSet.Tables.Add(myStaffRoleImpl.GetListByStaff(paramStaffID));
                myDataSet.EnforceConstraints = false;
                // 添加相应的权限数据                        
                myDataSet.Tables.Add(BasePermissionCheck.Instance.GetAuthorization(myDbConnection, myOperatorInfo.OperatorID, "FormStaffRoleAdmin"));
                BaseLogDao.Instance.Add(myDbConnection, myOperatorInfo);
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

        #region public DataTable BatchSave(BaseOperatorInfo myOperatorInfo, DataTable myDataTable, string paramStaffID) 批量保存模块权限
        /// <summary>
        /// 批量保存角色
        /// </summary>
        /// <param name="myOperatorInfo">操作员信息</param>
        /// <param name="myDataTable">数据表</param>
        /// <param name="paramStaffID">职员代码</param>
        /// <returns>数据集</returns>
        public DataTable BatchSave(BaseOperatorInfo myOperatorInfo, DataTable myDataTable, string paramStaffID)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.Instance.StartDebug(myOperatorInfo, MethodBase.GetCurrentMethod());
            #endif
            IBaseDbConnection myDbConnection = new OleDbHelper();
            try
            {
                myDbConnection.Open();
                BaseStaffRoleImpl myStaffRoleImpl = new BaseStaffRoleImpl(myDbConnection, myOperatorInfo);
                myStaffRoleImpl.BatchSave(myDataTable);
                myDataTable = myStaffRoleImpl.GetListByStaff(paramStaffID);
                // BUBaseOrganize myBUOrganize = new BUBaseOrganize(myDbConnection, myOperatorInfo);
                // myDataSet.Tables.Add(myBUOrganize.GetList());
                // myDataSet.Tables.Add(myBUStaffRole.GetListByStaff(paramStaffID));
                // myDataSet.EnforceConstraints = false;
                // myDataSet.Relations.Add("OrganizeRole", myDataSet.Tables[BaseOrganizeTable.TableName].Columns["ID"], myDataSet.Tables[BUBaseStaffRole.TableName].Columns["OrganizeID"]);
                // 添加相应的权限数据                        
                // myDataSet.Tables.Add(BasePermissionCheck.Instance.GetAuthorization(myDbConnection, myOperatorInfo.OperatorID, "FormStaffRoleAdmin"));
                BaseLogDao.Instance.Add(myDbConnection, myOperatorInfo);
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