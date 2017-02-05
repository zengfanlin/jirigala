//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    ///	BaseManager
    /// 通用基类部分
    /// 
    /// 总觉得自己写的程序不上档次，这些新技术也玩玩，也许做出来的东西更专业了。
    /// 修改纪录
    /// 
    ///		2012.02.04 版本：1.0 JiRiGaLa 进行提炼，把代码进行分组。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.02.04</date>
    /// </author> 
    /// </summary>
    public partial class BaseManager : IBaseManager
    {
        //
        // 记录导航功能
        //

        public string PreviousId = string.Empty; // 上一个记录主键。
        public string NextId = string.Empty; // 下一个记录主键。

        #region public DataTable GetPreviousNextId(bool deletionStateCode, string id) 获得主键列表
        /// <summary>
        /// 获得主键列表中的，上一条，下一条记录的主键
        /// </summary>
        /// <param name="deletionStateCode">删除标志</param>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
        public DataTable GetPreviousNextId(bool deletionStateCode, string id, string order)
        {
            string sqlQuery = " SELECT Id "
                            + " FROM " + this.CurrentTableName
                            + " WHERE (" + BaseBusinessLogic.FieldCreateUserId + " = " + DbHelper.GetParameter(BaseBusinessLogic.FieldCreateUserId)
                            + " AND " + BaseBusinessLogic.FieldDeletionStateCode + " = " + (deletionStateCode ? 1 : 0) + ")"
                            + " ORDER BY " + order;
            string[] names = new string[1];
            Object[] values = new Object[1];
            names[0] = BaseBusinessLogic.FieldCreateUserId;
            values[0] = UserInfo.Id;
            DataTable dataTable = new DataTable(this.CurrentTableName);
            DbHelper.Fill(dataTable, sqlQuery, DbHelper.MakeParameters(names, values));
            this.NextId = this.GetNextId(dataTable, id);
            this.PreviousId = this.GetPreviousId(dataTable, id);
            return dataTable;
        }
        #endregion

        #region public void GetPreviousNextId(DataTable dataTable, string id) 获得主键列表
        /// <summary>
        /// 获取下一条、下一条记录主键
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="id">当前记录主键</param>
        public void GetPreviousNextId(DataTable dataTable, string id)
        {
            this.PreviousId = this.GetPreviousId(dataTable, id);
            this.NextId = this.GetNextId(dataTable, id);
        }
        #endregion

        #region private string GetPreviousId(string id) 获取上一条记录主键
        /// <summary>
        /// 获取上一条记录主键
        /// </summary>
        /// <param name="id">当前记录主键</param>
        /// <returns>上一条记录主键</returns>
        private string GetPreviousId(string id)
        {
            string returnValue = string.Empty;
            string sqlQuery = " SELECT TOP 1 " + BaseBusinessLogic.FieldId
                            + " FROM " + this.CurrentTableName
                            + " WHERE " + BaseBusinessLogic.FieldCreateOn + " = (SELECT MAX(" + BaseBusinessLogic.FieldCreateOn + ")"
                            + " FROM " + this.CurrentTableName
                            + " WHERE (" + BaseBusinessLogic.FieldCreateOn + "< (SELECT " + BaseBusinessLogic.FieldCreateOn
                            + " FROM " + this.CurrentTableName
                            + " WHERE " + BaseBusinessLogic.FieldId + " = " + DbHelper.GetParameter(BaseBusinessLogic.FieldId) + "))";
            sqlQuery += " AND (" + BaseBusinessLogic.FieldCreateUserId + " = " + DbHelper.GetParameter(BaseBusinessLogic.FieldCreateUserId) + " ) AND ( " + BaseBusinessLogic.FieldDeletionStateCode + " = 0 )) ";
            string[] names = new string[2];
            Object[] values = new Object[2];
            names[0] = BaseBusinessLogic.FieldId;
            values[0] = id;
            names[1] = BaseBusinessLogic.FieldCreateUserId;
            values[1] = UserInfo.Id;
            object returnObject = DbHelper.ExecuteScalar(sqlQuery, DbHelper.MakeParameters(names, values));
            if (returnObject != null)
            {
                returnValue = returnObject.ToString();
            }
            return returnValue;
        }
        #endregion

        #region public string GetPreviousId(DataTable dataTable, string id) 获取上一条记录ID
        /// <summary>
        /// 获取上一条记录主键
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="id">当前记录主键</param>
        /// <returns>上一条记录主键</returns>
        public string GetPreviousId(DataTable dataTable, string id)
        {
            string returnValue = string.Empty;
            foreach (DataRowView dataRowView in dataTable.DefaultView)
            {
                if (dataRowView[BaseBusinessLogic.FieldId].ToString().Equals(id))
                {
                    break;
                }
                returnValue = dataRowView[BaseBusinessLogic.FieldId].ToString();
            }

            return returnValue;
        }
        #endregion

        #region private string GetNextId(string id) 获取下一条记录主键
        /// <summary>
        /// 获取下一条记录主键
        /// </summary>
        /// <param name="id">当前记录主键</param>
        /// <returns>下一条记录主键</returns>
        private string GetNextId(string id)
        {
            string returnValue = string.Empty;
            string sqlQuery = " SELECT TOP 1 " + BaseBusinessLogic.FieldId
                            + " FROM " + this.CurrentTableName
                            + " WHERE " + BaseBusinessLogic.FieldCreateOn + " = (SELECT MIN(" + BaseBusinessLogic.FieldCreateOn + ")"
                            + " FROM " + this.CurrentTableName
                            + " WHERE (" + BaseBusinessLogic.FieldCreateOn + "> (SELECT " + BaseBusinessLogic.FieldCreateOn
                            + " FROM " + this.CurrentTableName
                            + " WHERE " + BaseBusinessLogic.FieldId + " = " + DbHelper.GetParameter(BaseBusinessLogic.FieldId) + "))";
            sqlQuery += " AND (" + BaseBusinessLogic.FieldCreateUserId + " = " + DbHelper.GetParameter(BaseBusinessLogic.FieldCreateUserId) + ") AND ( " + BaseBusinessLogic.FieldDeletionStateCode + " = 0 )) ";
            string[] names = new string[2];
            Object[] values = new Object[2];
            names[0] = BaseBusinessLogic.FieldId;
            values[0] = id;
            names[1] = BaseBusinessLogic.FieldCreateUserId;
            values[1] = UserInfo.Id;
            object returnObject = DbHelper.ExecuteScalar(sqlQuery, DbHelper.MakeParameters(names, values));
            if (returnObject != null)
            {
                returnValue = returnObject.ToString();
            }
            return returnValue;
        }
        #endregion

        #region public string GetNextId(DataTable dataTable, string id) 获取下一条记录主键
        /// <summary>
        /// 获取下一条记录主键
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="id">当前记录主键</param>
        /// <returns>下一条记录主键</returns>
        public string GetNextId(DataTable dataTable, string id)
        {
            string returnValue = string.Empty;
            bool finded = false;
            foreach (DataRowView dataRowView in dataTable.DefaultView)
            {
                if (finded)
                {
                    returnValue = dataRowView[BaseBusinessLogic.FieldId].ToString();
                    break;
                }
                if (dataRowView[BaseBusinessLogic.FieldId].ToString().Equals(id))
                {
                    finded = true;
                }
            }
            return returnValue;
        }
        #endregion
    }
}