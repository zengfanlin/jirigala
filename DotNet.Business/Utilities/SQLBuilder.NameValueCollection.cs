//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Collections;
using System.Collections.Specialized;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// SQLBuilder
    /// SQL语句生成器（适合简单的添加、删除、更新等语句，可以写出编译时强类型检查的效果）
    /// 
    /// 修改记录
    ///    
    ///		2012.02.16 版本：1.0 JiRiGaLa   主键创建。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.02.16</date>
    /// </author> 
    /// </summary>
    public partial class SQLBuilder
    {
        #region public string SetWhere(NameValueCollection parameters, string relation = " AND ")
        /// <summary>
        /// 设置条件
        /// </summary>
        /// <param name="parameters">条件</param>
        /// <param name="relation">条件 AND OR</param>
        /// <returns>条件语句</returns>
        public string SetWhere(NameValueCollection parameters, string relation = " AND ")
        {
            foreach (var key in parameters.AllKeys)
            {
                this.SetWhere(key, parameters[key], relation);
            }
            string returnValue = this.WhereSql;
            return returnValue;
        }
        #endregion
    }
}