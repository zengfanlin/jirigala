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
        //
        // 获取个数
        //

        #region public static int GetCount(IDbHelper dbHelper, string tableName, List<KeyValuePair<string, object>> parameters, KeyValuePair<string, object> parameter = new KeyValuePair<string, object>()) 获取个数
        /// <summary>
        /// 获取个数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="parameters">目标字段,值</param>
        /// <returns>行数</returns>
        public static int GetCount(IDbHelper dbHelper, string tableName, List<KeyValuePair<string, object>> parameters, KeyValuePair<string, object> parameter = new KeyValuePair<string, object>())
        {
            int returnValue = 0;
            string sqlQuery = " SELECT COUNT(1) "
                + " FROM " + tableName
                + " WHERE " + GetWhereString(dbHelper, parameters, BaseBusinessLogic.SQLLogicConditional);

            if (!string.IsNullOrEmpty(parameter.Key))
            {
               switch (DbHelper.DbType)
               {
                   case CurrentDbType.Access :
                       // BaseSequence表的ID 是字符类型
                       if (tableName == "BaseSequence")
                           sqlQuery += BaseBusinessLogic.SQLLogicConditional + "( " + parameter.Key + " <> '" + parameter.Value + "' ) ";
                       else if (parameter.Value == null)
                           sqlQuery += BaseBusinessLogic.SQLLogicConditional + "( " + parameter.Key + " <> 0 ) ";
                        else
                           sqlQuery += BaseBusinessLogic.SQLLogicConditional + "( " + parameter.Key + " <> " + parameter.Value + " ) ";
                       break ;
                   default :
                       sqlQuery += BaseBusinessLogic.SQLLogicConditional + "( " + parameter.Key + " <> '" + parameter.Value + "' ) ";
                       break ;
               }
            }

            object returnObject = null;
            if (parameters != null)
            {
                returnObject = dbHelper.ExecuteScalar(sqlQuery, dbHelper.MakeParameters(parameters));
            }
            else
            {
                returnObject = dbHelper.ExecuteScalar(sqlQuery);
            }
            if (returnObject != null)
            {
                returnValue = int.Parse(returnObject.ToString());
            }
            return returnValue;
        }
        #endregion

        #region public static int GetCount(IDbHelper dbHelper, string tableName, whereConditional = null) 获取个数
        /// <summary>
        /// 获取个数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="whereConditional">条件</param>
        /// <returns>行数</returns>
        public static int GetCount(IDbHelper dbHelper, string tableName, string whereConditional = null)
        {
            int returnValue = 0;
            string sqlQuery = " SELECT COUNT(1) "
                + " FROM " + tableName;
            if (!string.IsNullOrEmpty(whereConditional))
            {
                sqlQuery += " WHERE " + whereConditional;
            }

            object returnObject = null;
            returnObject = dbHelper.ExecuteScalar(sqlQuery);
            if (returnObject != null)
            {
                returnValue = int.Parse(returnObject.ToString());
            }
            return returnValue;
        }
        #endregion

        //
        // 记录是否存在
        //

        #region public static bool Exists(IDbHelper dbHelper, string tableName, List<KeyValuePair<string, object>> parameters, KeyValuePair<string, object> parameter = null) 记录是否存在
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="parameters">参数</param>
        /// <param name="targetField">获取字段</param>
        /// <param name="name">目标字段名</param>
        /// <param name="parameters">目标字段值</param>
        /// <returns>存在</returns>
        public static bool Exists(IDbHelper dbHelper, string tableName, List<KeyValuePair<string, object>> parameters, KeyValuePair<string, object> parameter = new KeyValuePair<string, object>())
        {
            return GetCount(dbHelper, tableName, parameters, parameter) > 0;
        }
        #endregion
    }
}