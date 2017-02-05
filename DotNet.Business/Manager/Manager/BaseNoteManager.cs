//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// <author>
    ///		<name>Caihuajun</name>
    ///		<date>2008.09.16</date>
    /// </author>
    /// </summary>
    public partial class BaseNoteManager : BaseManager
    {
        #region public DataTable GetDataTableByUser(string userId, bool deletionStateCode) 获得列表
        /// <summary>
        /// 获得列表
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="deletionStateCode">删除标志</param>
        /// <param name="search">查询字符</param>
        /// <returns>数据集</returns>
        public DataTable GetDataTableByUser(string userId, bool deletionStateCode)
        {
            string sqlQuery = " SELECT * "
                            + " FROM " + BaseNoteEntity.TableName
                            + " WHERE (" + BaseNoteEntity.FieldCreateUserId + " = " + DbHelper.GetParameter(BaseNoteEntity.FieldCreateUserId)
                            + " AND " + BaseNoteEntity.FieldDeletionStateCode + " = " + (deletionStateCode ? 1 : 0) + ")"
                            + " ORDER BY " + BaseNoteEntity.FieldSortCode;
            string[] names = new string[1];
            Object[] values = new Object[1];
            names[0] = BaseNoteEntity.FieldCreateUserId;
            values[0] = userId;
            DataTable dataTable = new DataTable(BaseNoteEntity.TableName);
            DbHelper.Fill(dataTable, sqlQuery, DbHelper.MakeParameters(names, values));
            return dataTable;
        }
        #endregion

        #region public DataTable GetDataTableByUser(string userId, bool deletionStateCode, string searchValue) 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="deletionStateCode">删除标志</param>
        /// <param name="search">查询字符</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByUser(string userId, bool deletionStateCode, string searchValue)
        {
            // 2007.01.01 若没有查询内容，为了让速度更快列出数据，进行了改进。
            if (searchValue.Length == 0)
            {
                return this.GetDataTableByUser(userId, deletionStateCode);
            }
            searchValue = StringUtil.GetSearchString(searchValue);
            DataTable dataTable = new DataTable(BaseNoteEntity.TableName);
            string sqlQuery = " SELECT * "
                            + " FROM " + BaseNoteEntity.TableName
                            + " WHERE ((" + BaseNoteEntity.FieldTitle + " LIKE " + DbHelper.GetParameter(BaseNoteEntity.FieldTitle) + " )"
                            + " OR (" + BaseNoteEntity.FieldContent + " LIKE " + DbHelper.GetParameter(BaseNoteEntity.FieldContent) + " )"
                            + " OR (" + BaseNoteEntity.FieldCategoryFullName + " LIKE " + DbHelper.GetParameter(BaseNoteEntity.FieldCategoryFullName) + " )"
                            + " OR (CONVERT (NVARCHAR(10), " + BaseNoteEntity.FieldCreateOn + ", 20) LIKE " + DbHelper.GetParameter(BaseNoteEntity.FieldCreateOn) + " ))"
                            + " AND (" + BaseNoteEntity.FieldCreateUserId + " = " + DbHelper.GetParameter(BaseNoteEntity.FieldCreateUserId)
                            + " AND " + BaseNoteEntity.FieldDeletionStateCode + " = " + (deletionStateCode ? 1 : 0) + ")"
                            + " ORDER BY " + BaseNoteEntity.FieldSortCode;
            string[] names = new string[5];
            Object[] values = new Object[5];
            names[0] = BaseNoteEntity.FieldTitle;
            values[0] = searchValue;
            names[1] = BaseNoteEntity.FieldContent;
            values[1] = searchValue;
            names[2] = BaseNoteEntity.FieldCategoryFullName;
            values[2] = searchValue;
            names[3] = BaseNoteEntity.FieldCreateOn;
            values[3] = searchValue;
            names[4] = BaseNoteEntity.FieldCreateUserId;
            values[4] = userId;
            DbHelper.Fill(dataTable, sqlQuery, DbHelper.MakeParameters(names, values));
            return dataTable;
        }
        #endregion
    }
}