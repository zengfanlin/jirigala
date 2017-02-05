//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    ///	DbLogic
    /// 通用基类
    /// 
    /// 修改纪录
    /// 
    ///		2012.02.05 版本：1.0	JiRiGaLa 分离程序。
    ///	
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.02.05</date>
    /// </author> 
    /// </summary>
    public partial class DbLogic
    {
        //
        // 判断数据是否已被更改
        //

        #region public static bool IsModifed(IDbHelper dbHelper, string tableName, Object id, string oldModifiedUserId, DateTime? oldModifiedOn) 数据是否已经被别人修改了
        /// <summary>
        /// 数据是否已经被别人修改了
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="tableName">表名</param>
        /// <param name="id">主键</param>
        /// <param name="oldModifiedUserId">最后修改者</param>
        /// <param name="oldModifiedOn">最后修改时间</param>
        /// <returns>已被修改</returns>
        public static bool IsModifed(IDbHelper dbHelper, string tableName, Object id, string oldModifiedUserId, DateTime? oldModifiedOn)
        {
            return IsModifed(dbHelper, tableName, BaseBusinessLogic.FieldId, id, oldModifiedUserId, oldModifiedOn);
        }
        #endregion

        #region public static bool IsModifed(IDbHelper dbHelper, string tableName, string fieldName, Object fieldValue, string oldModifiedUserId, DateTime? oldModifiedOn) 数据是否已经被别人修改了
        /// <summary>
        /// 数据是否已经被别人修改了
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="tableName">表名</param>
        /// <param name="id">主键</param>
        /// <param name="fieldName">字段</param>
        /// <param name="fieldValue">值</param>
        /// <param name="oldModifiedUserId">最后修改者</param>
        /// <param name="oldModifiedOn">最后修改时间</param>
        /// <returns>已被修改</returns>
        public static bool IsModifed(IDbHelper dbHelper, string tableName, string fieldName, Object fieldValue, string oldModifiedUserId, DateTime? oldModifiedOn)
        {
            bool returnValue = false;
            string sqlQuery = " SELECT " + BaseBusinessLogic.FieldId
                            + "," + BaseBusinessLogic.FieldCreateUserId
                            + "," + BaseBusinessLogic.FieldCreateOn
                            + "," + BaseBusinessLogic.FieldModifiedUserId
                            + "," + BaseBusinessLogic.FieldModifiedOn
                            + " FROM " + tableName
                            + " WHERE " + fieldName + " = " + dbHelper.GetParameter(fieldName);
            DataTable dataTable = dbHelper.Fill(sqlQuery, new IDbDataParameter[] { dbHelper.MakeParameter(fieldName, fieldValue)});
            returnValue = IsModifed(dataTable, oldModifiedUserId, oldModifiedOn);
            return returnValue;
        }
        #endregion

        #region private static bool IsModifed(DataTable dataTable, string oldModifiedUserId, DateTime? oldModifiedOn) 数据是否已经被别人修改了
        /// <summary>
        /// 数据是否已经被别人修改了
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="oldModifiedUserId">最后修改者</param>
        /// <param name="oldModifiedOn">最后修改时间</param>
        /// <returns>已被修改</returns>
        private static bool IsModifed(DataTable dataTable, string oldModifiedUserId, DateTime? oldModifiedOn)
        {
            bool returnValue = false;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                returnValue = IsModifed(dataRow, oldModifiedUserId, oldModifiedOn);
            }
            return returnValue;
        }
        #endregion

        #region public static bool IsModifed(DataRow dataRow, string oldModifiedUserId, DateTime? oldModifiedOn) 数据是否已经被别人修改了
        /// <summary>
        /// 数据是否已经被别人修改了
        /// </summary>
        /// <param name="dataRow">数据行</param>
        /// <param name="oldModifiedUserId">最后修改者</param>
        /// <param name="oldModifiedOn">最后修改时间</param>
        /// <returns>已被修改</returns>
        public static bool IsModifed(DataRow dataRow, string oldModifiedUserId, DateTime? oldModifiedOn)
        {
            bool returnValue = false;
            if ((dataRow[BaseBusinessLogic.FieldModifiedUserId] == DBNull.Value) || ((dataRow[BaseBusinessLogic.FieldModifiedOn] == DBNull.Value)))
            {
                return false;
            }
            DateTime newModifiedOn = DateTime.Parse(dataRow[BaseBusinessLogic.FieldModifiedOn].ToString());
            if (!dataRow[BaseBusinessLogic.FieldModifiedUserId].ToString().Equals(oldModifiedUserId) || newModifiedOn!=oldModifiedOn)
            {
                return true;
            }
            return returnValue;
        }
        #endregion
    }
}