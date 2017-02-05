//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
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
        #region public static DataTable GetDataTable(IDbHelper dbHelper, string tableName, string name, object[] values, string order = null) 获取数据表 一参 参数为数组
        /// <summary>
        /// 获取数据表 一参 参数为数组
        /// </summary>
        /// <param name="dbHelper">数据库类型</param>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="name">字段名</param>
        /// <param name="value">字段值</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        public static DataTable GetDataTable(CurrentDbType DbType,IDbHelper dbHelper, string tableName, string name, object[] values, string order = null)
        {
            string sqlQuery = " SELECT * "
                            + "   FROM " + tableName;
            if (values == null)
            {
                sqlQuery += "  WHERE " + name + " IS NULL";
            }
            else
            {
                sqlQuery += "  WHERE " + name + " IN (" + BaseBusinessLogic.ObjectsToList(DbType,values) + ")";
            }
            if (!String.IsNullOrEmpty(order))
            {
                sqlQuery += " ORDER BY " + order;
            }
            return dbHelper.Fill(sqlQuery);
        }
        #endregion

        #region public static DataTable GetDataTable(IDbHelper dbHelper, string tableName, string name, object[] values, string order = null) 获取数据表 一参 参数为数组
        /// <summary>
        /// 获取数据表 一参 参数为数组
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="name">字段名</param>
        /// <param name="value">字段值</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        public static DataTable GetDataTable(IDbHelper dbHelper, string tableName, string name, object[] values, string order = null)
        {
            string sqlQuery = " SELECT * "
                            + "   FROM " + tableName;
            if (values == null)
            {
                sqlQuery += "  WHERE " + name + " IS NULL";
            }
            else
            {
                sqlQuery += "  WHERE " + name + " IN (" + BaseBusinessLogic.ObjectsToList(values) + ")";
            }
            if (!String.IsNullOrEmpty(order))
            {
                sqlQuery += " ORDER BY " + order;
            }
            return dbHelper.Fill(sqlQuery);
        }
        #endregion
        
        public static DataTable GetDataTable(IDbHelper dbHelper, string tableName, List<KeyValuePair<string, object>> parameters, int topLimit = 0, string order = null, string sqlLogicConditional = null)
        {
            // 这里是需要完善的功能，完善了这个，是一次重大突破           
            string sqlQuery = " SELECT * FROM " + tableName;
            string whereSql = string.Empty;
            if (topLimit != 0)
            {
                switch (dbHelper.CurrentDbType)
                {
                    case CurrentDbType.Access:
                    case CurrentDbType.SqlServer:
                        sqlQuery = " SELECT TOP " + topLimit.ToString() + " * FROM " + tableName;
                        break;
                    case CurrentDbType.Oracle:
                        whereSql = " ROWNUM < = " + topLimit;
                        break;
                }
            }
            if (string.IsNullOrEmpty(sqlLogicConditional))
            {
                sqlLogicConditional = BaseBusinessLogic.SQLLogicConditional;
            }
            string subSql = GetWhereString(dbHelper, parameters, sqlLogicConditional);
            if (!string.IsNullOrEmpty(subSql))
            {
                if (whereSql.Length > 0)
                {
                    whereSql = whereSql + sqlLogicConditional + subSql;
                }
                else
                {
                    whereSql = subSql;
                }
            }
            if (whereSql.Length > 0)
            {
                sqlQuery += " WHERE " + whereSql;
            }
            if ((order != null) && (order.Length > 0))
            {
                sqlQuery += " ORDER BY " + order;
            }
            if (topLimit != 0)
            {
                switch (dbHelper.CurrentDbType)
                {
                    case CurrentDbType.MySql:
                        sqlQuery += " LIMIT 0, " + topLimit;
                        break;
                }
            }
            DataTable dataTable = new DataTable(tableName);
            if (parameters != null && parameters.Count > 0)
            {
                dataTable = dbHelper.Fill(sqlQuery, dbHelper.MakeParameters(parameters));
            }
            else
            {
                dataTable = dbHelper.Fill(sqlQuery);
            }
            return dataTable;
        }
    }
}