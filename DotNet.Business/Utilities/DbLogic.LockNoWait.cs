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
    ///		2012.03.21 版本：2.0	JiRiGaLa 优化代码。
    ///		2012.02.05 版本：1.0	JiRiGaLa 分离程序。
    ///	
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.03.21</date>
    /// </author> 
    /// </summary>
    public partial class DbLogic
    {
        //
        // 锁定表记录
        //

        public static int LockNoWait(IDbHelper dbHelper, string tableName, params KeyValuePair<string, object>[] parameters)
        {
            List<KeyValuePair<string, object>> parametersList = new List<KeyValuePair<string, object>>();
            for (int i = 0; i < parameters.Length; i++)
            {
                parametersList.Add(parameters[i]);
            }
            return LockNoWait(dbHelper, tableName, parametersList);
        }


        #region public static int LockNoWait(IDbHelper dbHelper, string tableName, List<KeyValuePair<string, object>> parameters) 记录是否存在
        /// <summary>
        /// 锁定表记录
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="names">字段名数组</param>
        /// <param name="values">键值数组</param>
        /// <param name="targetField">获取字段</param>
        /// <returns>锁定的行数</returns>
        public static int LockNoWait(IDbHelper dbHelper, string tableName, List<KeyValuePair<string, object>> parameters)
        {
            int returnValue = 0;
            string sqlQuery = " SELECT " + BaseBusinessLogic.FieldId
                + " FROM " + tableName
                + " WHERE " + GetWhereString(dbHelper, parameters, BaseBusinessLogic.SQLLogicConditional);
            sqlQuery += " FOR UPDATE NOWAIT ";
            try
            {
                DataTable dataTable = new DataTable("ForUpdateNoWait");
                dbHelper.Fill(dataTable, sqlQuery, dbHelper.MakeParameters(parameters));
                returnValue = dataTable.Rows.Count;
            }
            catch
            {
                returnValue = -1;
            }
            return returnValue;
        }
        #endregion
    }
}