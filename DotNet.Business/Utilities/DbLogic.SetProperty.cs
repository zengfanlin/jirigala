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
    /// 通用基类 设置各种属性
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
        // 设置属性部分
        //

        #region public static int SetProperty(IDbHelper dbHelper, string tableName, List<KeyValuePair<string, object>> whereParameters, List<KeyValuePair<string, object>> parameters) 设置属性
        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="whereParameters">条件字段,条件值</param>
        /// <param name="parameters">更新字段,更新值</param>
        /// <returns>影响行数</returns>
        public static int SetProperty(IDbHelper dbHelper, string tableName, List<KeyValuePair<string, object>> whereParameters, List<KeyValuePair<string, object>> parameters)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(dbHelper);
            sqlBuilder.BeginUpdate(tableName);
            foreach (var parameter in parameters)
            {
                sqlBuilder.SetValue(parameter.Key, parameter.Value);
            }
            sqlBuilder.SetWhere(whereParameters);
            // sqlBuilder.SetDBNow(FieldModifiedOn);
            return sqlBuilder.EndUpdate();
        }
        #endregion
    }
}