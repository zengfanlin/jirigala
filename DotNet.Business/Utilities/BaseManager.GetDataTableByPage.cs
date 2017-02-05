//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Collections.Generic;
using System.Data;

namespace DotNet.Business
{
    /// <summary>
    ///	BaseManager
    /// 通用基类部分（分页）
    /// 
    /// 总觉得自己写的程序不上档次，这些新技术也玩玩，也许做出来的东西更专业了。
    /// 修改纪录
    /// 
    ///		2012.02.04 版本：1.0 JiRiGaLa 进行提炼，把代码进行分组。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.02.04</date>
    /// </author> 
    /// </summary>
    public partial class BaseManager : IBaseManager
    {
        /// <summary>
        /// 获取分页DataTable
        /// </summary>
        /// <param name="recordCount">记录总数</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="pageSize">每页显示多少条</param>
        /// <param name="whereConditional">条件</param>
        /// <param name="order">排序字段</param>
        /// <returns>数据表</returns>
        public virtual DataTable GetDataTableByPage(out int recordCount, int pageIndex, int pageSize, string whereConditional, string order)
        {
            recordCount = DbLogic.GetCount(DbHelper, this.CurrentTableName, whereConditional);
            return DbLogic.GetDataTableByPage(DbHelper, this.CurrentTableName, pageIndex, pageSize, whereConditional, order);
        }

        /// <summary>
        /// 分页读取数据
        /// </summary>
        /// <param name="recordCount">页面个数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="tableName">从什么表</param>
        /// <param name="whereConditional">条件</param>
        /// <param name="selectField">选择哪些字段</param>
        /// <returns>数据表</returns>
        public virtual DataTable GetDataTableByPage(out int recordCount, int pageIndex = 1, int pageSize = 20, string sortExpression = null, string sortDire = null, string tableName = null, string whereConditional = null, string selectField = null)
        {
            if (tableName.ToUpper().IndexOf("SELECT") >= 0)
            {
                // 统计总条数
                string commandText = string.Empty;
                if (string.IsNullOrEmpty(tableName))
                {
                    tableName = this.CurrentTableName;
                }
                commandText = tableName;
                if (tableName.ToUpper().IndexOf("SELECT") >= 0)
                {
                    commandText = "(" + tableName + ") AS T ";
                }
                commandText = string.Format("SELECT COUNT(1) AS recordCount FROM {0}", commandText);
                object returnObject = DbHelper.ExecuteScalar(commandText);
                if (returnObject != null)
                {
                    recordCount = int.Parse(returnObject.ToString());
                }
                else
                {
                    recordCount = 0;
                }
                return DbLogic.GetDataTableByPage(DbHelper, recordCount, pageIndex, pageSize, tableName, sortExpression, sortDire);
            }
            // 这个是调用存储过程的方法
            return DbLogic.GetDataTableByPage(DbHelper, out recordCount, pageIndex, pageSize, sortExpression, sortDire, tableName, whereConditional, selectField);
        }
    }
}