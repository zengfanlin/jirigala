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
    ///		2012.03.20 版本：2.0	JiRiGaLa 整理参数传递方法。
    ///		2012.02.05 版本：1.0	JiRiGaLa 分离程序。
    ///	
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.03.20</date>
    /// </author> 
    /// </summary>
    public partial class DbLogic
    {
        #region public static string GetProperty(IDbHelper dbHelper, string tableName, List<KeyValuePair<string, object>> parameters, string targetField) 读取属性
        /// <summary>
        /// 读取属性
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="parameters">字段名,键值</param>
        /// <param name="targetField">获取字段</param>
        /// <returns>属性</returns>
        public static string GetProperty(IDbHelper dbHelper, string tableName, List<KeyValuePair<string, object>> parameters, string targetField)
        {
           string returnValue = string.Empty;
           string sqlQuery = " SELECT " + targetField
               + " FROM " + tableName
               + " WHERE " + GetWhereString(dbHelper, parameters, BaseBusinessLogic.SQLLogicConditional);
           object returnObject = dbHelper.ExecuteScalar(sqlQuery, dbHelper.MakeParameters(parameters));
           if (returnObject != null)
           {
              returnValue = returnObject.ToString();
           }
           return returnValue;
        }
        #endregion
    }
}