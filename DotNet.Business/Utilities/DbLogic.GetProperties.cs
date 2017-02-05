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
        #region public static string[] GetProperties(IDbHelper dbHelper, string tableName, string name, Object[] values, string targetField) 获取数据表
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="name">字段名</param>
        /// <param name="values">字段值</param>
        /// <param name="targetField">目标字段</param>
        /// <returns>数据表</returns>
        public static string[] GetProperties(IDbHelper dbHelper, string tableName, string name, Object[] values, string targetField)
        {
            string sqlQuery = " SELECT " + targetField
                            + "   FROM " + tableName
                            + "  WHERE " + name + " IN (" + BaseBusinessLogic.ObjectsToList(values) + ")";
            DataTable dataTable = dbHelper.Fill(sqlQuery);
            return BaseBusinessLogic.FieldToArray(dataTable, targetField);
        }
        #endregion

        #region public static string[] GetProperties(IDbHelper dbHelper, string tableName, List<KeyValuePair<string, object>> parameters, int? topLimit = null, string targetField = null) 获取数据权限
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="parameters">字段名,字段值</param>
        /// <param name="topLimit">前几个记录</param>
        /// <param name="targetField">目标字段</param>
        /// <returns>数据表</returns>
        public static string[] GetProperties(IDbHelper dbHelper, string tableName, List<KeyValuePair<string, object>> parameters, int? topLimit = null, string targetField = null)
        {
            if (string.IsNullOrEmpty(targetField))
            {
                targetField = BaseBusinessLogic.FieldId;
            }
            // 这里是需要完善的功能，完善了这个，是一次重大突破           
            string sqlQuery = " SELECT " + targetField + " FROM " + tableName;
            string whereSql = string.Empty;
            if (topLimit != null && topLimit > 0)
            {
                switch (dbHelper.CurrentDbType)
                {
                    case CurrentDbType.Access:
                    case CurrentDbType.SqlServer:
                        sqlQuery = " SELECT TOP " + topLimit.ToString() + targetField + " FROM " + tableName;
                        break;
                    case CurrentDbType.Oracle:
                        whereSql = " ROWNUM < = " + topLimit;
                        break;
                }
            }
            string subSql = GetWhereString(dbHelper, parameters, BaseBusinessLogic.SQLLogicConditional);
            if (subSql.Length > 0)
            {
                if (whereSql.Length > 0)
                {
                    whereSql = whereSql + BaseBusinessLogic.SQLLogicConditional + subSql;
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
            if (topLimit != null)
            {
                switch (dbHelper.CurrentDbType)
                {
                    case CurrentDbType.MySql:
                        sqlQuery += " LIMIT 0, " + topLimit;
                        break;
                }
            }
            DataTable dataTable = new DataTable(tableName);
            dbHelper.Fill(dataTable, sqlQuery, dbHelper.MakeParameters(parameters));
            return BaseBusinessLogic.FieldToArray(dataTable, targetField);
        }
        #endregion
    }
}