//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

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
        // SqlServer By StoredProcedure

        #region  public static DataTable GetDataTableByPage(IDbHelper dbHelper, out int recordCount, int pageIndex = 1, int pageSize = 20, string sortExpression = null, string sortDire = null, string tableName = null, string whereConditional = null, string selectField = null)
        /// <summary>
        /// 使用存储过程获取分页数据
        /// </summary>
        /// <param name="dbHelper">数据源</param>
        /// <param name="recordCount">返回的记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDire">排序</param>
        /// <param name="tableName">表名</param>
        /// <param name="whereConditional">查询条件</param>
        /// <param name="selectField">查询字段</param>
        /// <returns></returns>
        public static DataTable GetDataTableByPage(IDbHelper dbHelper, out int recordCount, int pageIndex = 1, int pageSize = 20, string sortExpression = null, string sortDire = null, string tableName = null, string whereConditional = null, string selectField = null)
        {
            DataTable dataTable = null;
            recordCount = 0;
            if (string.IsNullOrEmpty(selectField))
            {
                selectField = "*";
            }
            if (string.IsNullOrEmpty(whereConditional))
            {
                whereConditional = string.Empty;
            }
            List<IDbDataParameter> dbParameters = new List<IDbDataParameter>();
            IDbDataParameter dbDataParameter = DbHelper.MakeParameter("RecordCount", recordCount, DbType.Int64, 0, ParameterDirection.Output);
            dbParameters.Add(dbDataParameter);
            dbParameters.Add(DbHelper.MakeParameter("PageIndex", pageIndex));
            dbParameters.Add(DbHelper.MakeParameter("PageSize", pageSize));
            dbParameters.Add(DbHelper.MakeParameter("SortExpression", sortExpression));
            dbParameters.Add(DbHelper.MakeParameter("SortDire", sortDire));
            dbParameters.Add(DbHelper.MakeParameter("TableName", tableName));
            dbParameters.Add(DbHelper.MakeParameter("SelectField", selectField));
            dbParameters.Add(DbHelper.MakeParameter("WhereConditional", whereConditional));
            string commandText = "GetRecordByPage";
            dataTable = dbHelper.Fill(commandText, dbParameters.ToArray(), CommandType.StoredProcedure);
            recordCount = int.Parse(dbDataParameter.Value.ToString());
            return dataTable;
        }
        #endregion

        #region public static DataTable GetDataTableByPage(IDbHelper dbHelper, int recordCount, int pageIndex, int pageSize, string sqlQuery, string sortExpression = null, string sortDire = null) 分页获取指定数量的数据
        /// <summary>
        ///  分页获取指定数量的数据
        /// </summary>
        /// <param name="dbHelper">数据源</param>
        /// <param name="recordCount">获取多少条</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="sqlQuery"></param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDire">排序</param>
        /// <returns></returns>
        public static DataTable GetDataTableByPage(IDbHelper dbHelper, int recordCount, int pageIndex, int pageSize, string sqlQuery, string sortExpression = null, string sortDire = null)
        {
            if (string.IsNullOrEmpty(sortExpression))
            {
                sortExpression = BaseBusinessLogic.FieldCreateOn;
            }
            if (string.IsNullOrEmpty(sortDire))
            {
                sortDire = " DESC";
            }
            string sqlCount = recordCount - ((pageIndex - 1) * pageSize) > pageSize ? pageSize.ToString() : (recordCount - ((pageIndex - 1) * pageSize)).ToString();
            string sqlStart = (pageIndex * pageSize).ToString();
            string sqlEnd = ((pageIndex + 1) * pageSize).ToString();
            string commandText = string.Empty;

            switch (dbHelper.CurrentDbType)
            {
                case CurrentDbType.SqlServer:
                case CurrentDbType.DB2:
                    sqlStart = ((pageIndex - 1) * pageSize).ToString();
                    sqlEnd = (pageIndex * pageSize).ToString();
                    commandText = " SELECT * FROM ( "
                               + " SELECT ROW_NUMBER() OVER(ORDER BY " + sortExpression + ") AS ROWNUM, "
                               + sqlQuery.Substring(7) + "  ) A "
                               + " WHERE ROWNUM > " + sqlStart + " AND ROWNUM <= " + sqlEnd;
                    break;
                case CurrentDbType.Access:
                    if (sqlQuery.ToUpper().IndexOf("SELECT") >= 0)
                    {
                        sqlQuery = " (" + sqlQuery + ") ";
                    }
                    commandText = string.Format("SELECT * FROM (SELECT TOP {0} * FROM (SELECT TOP {1} * FROM {2} T ORDER BY {3} " + sortDire + ") T1 ORDER BY {4} DESC ) T2 ORDER BY {5} " + sortDire
                                    , sqlCount, sqlStart, sqlQuery, sortExpression, sortExpression, sortExpression);
                    break;
                case CurrentDbType.Oracle:
                    break;
            }
            return dbHelper.Fill(commandText);
        }
        #endregion

        // Oracle GetDataTableByPage

        #region public static DataTable GetDataTableByPage(IDbHelper dbHelper, string tableName, int pageIndex, int pageSize, string conditions, string orderby) 获取分页数据
        /// <summary>
        /// Oracle 获取分页数据
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示多少条</param>
        /// <param name="conditions">查询条件</param>
        /// <param name="orderby"></param>
        /// <returns>数据表</returns>
        public static DataTable GetDataTableByPage(IDbHelper dbHelper, string tableName, int pageIndex, int pageSize, string conditions, string orderby)
        {
            string sqlStart = ((pageIndex - 1) * pageSize).ToString();
            string sqlEnd = (pageIndex * pageSize).ToString();
            if (!string.IsNullOrEmpty(conditions))
            {
                conditions = "WHERE " + conditions;
            }
            string sqlQuery = string.Empty;

            if (dbHelper.CurrentDbType == CurrentDbType.Oracle)
            {
                sqlQuery = string.Format("SELECT * FROM (SELECT T.*, ROWNUM RN FROM (SELECT * FROM {0} {1} ORDER BY {2}) T WHERE ROWNUM <= {3}) WHERE RN > {4}"
                    , tableName, conditions, orderby, sqlEnd, sqlStart);
            }
            if (dbHelper.CurrentDbType == CurrentDbType.SqlServer)
            {
                sqlQuery = string.Format("SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY {0}) AS RowIndex, * FROM {1} {2}) AS PageTable WHERE RowIndex BETWEEN {3} AND {4} ORDER BY {5}"
                    , orderby, tableName, conditions, sqlStart, sqlEnd, orderby);
            }
            DataTable dataTable = new DataTable(tableName);
            dataTable = dbHelper.Fill(sqlQuery);
            return dataTable;
        }
        #endregion

        #region public static DataTable GetDataTableByPage(IDbHelper dbHelper, string tableName, int pageIndex, int pageSize, string conditions, List<IDbDataParameter> dbParameters, string orderby) 分页获取数据
        /// <summary>
        /// Oracle 获取数据表
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示多少条</param>
        /// <param name="conditions">查询条件</param>
        /// <returns>数据表</returns>
        public static DataTable GetDataTableByPage(IDbHelper dbHelper, string tableName, int pageIndex, int pageSize, string conditions, List<IDbDataParameter> dbParameters, string orderby)
        {
            string sqlCount = (pageIndex * pageSize).ToString();
            string sqlStart = ((pageIndex - 1) * pageSize).ToString();

            if (!string.IsNullOrEmpty(conditions))
            {
                conditions = "WHERE " + conditions;
            }

            string sqlQuery = string.Format("SELECT * FROM (SELECT T.*, ROWNUM RN FROM (SELECT * FROM {0} {1} ORDER BY {2}) T WHERE ROWNUM <= {3}) WHERE RN > {4}"
                , tableName, conditions, orderby, sqlCount, sqlStart);

            DataTable dataTable = new DataTable(tableName);
            if (dbParameters != null && dbParameters.Count > 0)
            {
                dataTable = dbHelper.Fill(sqlQuery, dbParameters.ToArray());
            }
            else
            {
                dataTable = dbHelper.Fill(sqlQuery);
            }
            return dataTable;
        }
        #endregion
    }
}