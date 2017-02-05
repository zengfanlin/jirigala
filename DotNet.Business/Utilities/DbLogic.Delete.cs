//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;

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
        // 删除数据库方法
        //

        #region public int static Delete(IDbHelper dbHelper, string tableName, List<KeyValuePair<string, object>> parameters = null) 删除表格数据
        /// <summary>
        /// 删除表格数据
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="parameters">删除条件</param>
        /// <returns>影响行数</returns>
        public static int Delete(IDbHelper dbHelper, string tableName, List<KeyValuePair<string, object>> parameters = null)
        {
            string sqlQuery = " DELETE " + " FROM " + tableName;
            string whereString = GetWhereString(dbHelper, parameters, BaseBusinessLogic.SQLLogicConditional);
            if (whereString.Length > 0)
            {
                sqlQuery += " WHERE " + whereString;
            }
            return dbHelper.ExecuteNonQuery(sqlQuery, dbHelper.MakeParameters(parameters));
        }
        #endregion

        #region public static int Truncate(IDbHelper dbHelper, string tableName) 截断表格数据
        /// <summary>
        /// 截断表格数据
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="tableName">目标表格</param>
        /// <returns>是否成功</returns>
        public static int Truncate(IDbHelper dbHelper, string tableName)
        {
            string sqlQuery = " TRUNCATE TABLE " + tableName;
            // DB2 V9.7 以后才支持这个语句
            if (dbHelper.CurrentDbType == CurrentDbType.DB2)
            {
                sqlQuery = " ALTER TABLE " + tableName + " ACTIVATE NOT LOGGED INITIALLY WITH EMPTY TABLE ";
            }
            return dbHelper.ExecuteNonQuery(sqlQuery);
        }
        #endregion
    }
}