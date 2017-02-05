//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
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
        // 树型结构的算法
        //

        #region public static DataTable GetParentsByCode(IDbHelper dbHelper, string tableName, string fieldCode, string code, string order) 获取父节点列表
        /// <summary>
        /// 获取父节点列表
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="tableName">目标表明</param>
        /// <param name="fieldCode">编码字段</param>
        /// <param name="code">编码</param>
        /// <param name="order">排序</param>
        /// <param name="idOnly">只需要主键</param>
        /// <returns>数据表</returns>
        public static DataTable GetParentsByCode(IDbHelper dbHelper, string tableName, string fieldCode, string code, string order, bool idOnly = false)
        {
            string sqlQuery = string.Empty;
            if (idOnly)
            {
                sqlQuery = "   SELECT " + BaseBusinessLogic.FieldId;
            }
            else
            {
                sqlQuery = "   SELECT * ";
            }
            sqlQuery += "     FROM " + tableName;
            switch (dbHelper.CurrentDbType)
            {
                case CurrentDbType.Access:
                case CurrentDbType.SqlServer:
                    sqlQuery += "    WHERE (LEFT(" + dbHelper.GetParameter(fieldCode) + ", LEN(" + fieldCode + ")) = " + fieldCode + ") ";
                    break;
                case CurrentDbType.Oracle:
                    sqlQuery += "    WHERE (SUBSTR(" + dbHelper.GetParameter(fieldCode) + ", 1, LENGTH(" + fieldCode + ")) = " + fieldCode + ") ";
                    break;
            }
            if (!String.IsNullOrEmpty(order))
            {
                sqlQuery += " ORDER BY " + order;
            }
            string[] names = new string[1];
            Object[] values = new Object[1];
            names[0] = fieldCode;
            values[0] = code;
            DataTable dataTable = new DataTable(tableName);
            dbHelper.Fill(dataTable, sqlQuery, dbHelper.MakeParameters(names, values));
            return dataTable;
        }
        #endregion

        #region public static DataTable GetChildrens(IDbHelper dbHelper, string tableName, string fieldId, string id, string fieldParentId, string order, bool idOnly) 获取子节点列表
        /// <summary>
        /// 获取子节点列表
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="tableName">目标表明</param>
        /// <param name="fieldId">主键字段</param>
        /// <param name="id">值</param>
        /// <param name="fieldParentId">父亲节点字段</param>
        /// <param name="order">排序</param>
        /// <param name="idOnly">只需要主键</param>
        /// <returns>数据表</returns>
        public static DataTable GetChildrens(IDbHelper dbHelper, string tableName, string fieldId, string id, string fieldParentId = null, string order = null, bool idOnly = false)
        {
            string sqlQuery = string.Empty;
            DataTable dataTable = new DataTable(tableName);
            if (dbHelper.CurrentDbType == CurrentDbType.Oracle)
            {
                if (idOnly)
                {
                    sqlQuery = "   SELECT " + fieldId;
                }
                else
                {
                    sqlQuery = "   SELECT * ";
                }
                sqlQuery += "          FROM " + tableName
                         + "    START WITH " + fieldId + " = " + dbHelper.GetParameter(fieldId)
                         + "  CONNECT BY PRIOR " + fieldId + " = " + fieldParentId;
                if (!String.IsNullOrEmpty(order))
                {
                    sqlQuery += " ORDER BY " + order;
                }
                string[] names = new string[1];
                names[0] = fieldId;
                Object[] values = new Object[1];
                values[0] = id;
                dbHelper.Fill(dataTable, sqlQuery, dbHelper.MakeParameters(names, values));
            }
            else if (dbHelper.CurrentDbType == CurrentDbType.SqlServer)
            {
                if (idOnly)
                {
                    sqlQuery = " WITH Tree AS (SELECT Id "
                             + "       FROM " + tableName
                             + "       WHERE Id IN ('" + id + "') "
                             + "       UNION ALL "
                             + "      SELECT ResourceTree.Id "
                             + "        FROM " + tableName + " AS ResourceTree INNER JOIN "
                             + "             Tree AS A ON A." + fieldId + " = ResourceTree." + fieldParentId + ") "
                             + " SELECT Id "
                             + "   FROM Tree ";
                }
                else
                {
                    sqlQuery = " WITH Tree AS (SELECT * "
                             + "       FROM " + tableName
                             + "       WHERE Id IN ('" + id + "') "
                             + "       UNION ALL "
                             + "      SELECT ResourceTree.* "
                             + "        FROM " + tableName + " AS ResourceTree INNER JOIN "
                             + "             Tree AS A ON A." + fieldId + " = ResourceTree." + fieldParentId + ") "
                             + " SELECT * "
                             + "   FROM Tree ";
                }

                dbHelper.Fill(dataTable, sqlQuery);
            }
            return dataTable;
        }
        #endregion

        #region public static DataTable GetChildrens(IDbHelper dbHelper, string tableName, string fieldId, string[] ids, string fieldParentId, string order, bool idOnly) 获取子节点列表
        /// <summary>
        /// 获取子节点列表
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="tableName">目标表明</param>
        /// <param name="fieldId">主键字段</param>
        /// <param name="ids">主键数组</param>
        /// <param name="fieldParentId">父亲节点字段</param>
        /// <param name="order">排序</param>
        /// <param name="idOnly">只需要主键</param>
        /// <returns>数据表</returns>
        public static DataTable GetChildrens(IDbHelper dbHelper, string tableName, string fieldId, string[] ids, string fieldParentId, string order, bool idOnly)
        {
            string sqlQuery = string.Empty;
            if (idOnly)
            {
                sqlQuery = "   SELECT " + fieldId;
            }
            else
            {
                sqlQuery = "   SELECT * ";
            }
            sqlQuery += "          FROM " + tableName
                     + "    START WITH " + fieldId + " IN (" + BaseBusinessLogic.ObjectsToList(ids) + ")"
                     + "  CONNECT BY PRIOR " + fieldId + " = " + fieldParentId;
            if (!String.IsNullOrEmpty(order))
            {
                sqlQuery += " ORDER BY " + order;
            }
            return dbHelper.Fill(sqlQuery);
        }
        #endregion

        #region public static DataTable GetChildrensByCode(IDbHelper dbHelper, string tableName, string fieldCode, string code, string order, bool idOnly) 获取子节点列表
        /// <summary>
        /// 获取子节点列表
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="tableName">目标表明</param>
        /// <param name="fieldCode">编码字段</param>
        /// <param name="code">编码</param>
        /// <param name="order">排序</param>
        /// <param name="idOnly">只需要主键</param>
        /// <returns>数据表</returns>
        public static DataTable GetChildrensByCode(IDbHelper dbHelper, string tableName, string fieldCode, string code, string order, bool idOnly = false)
        {
            string sqlQuery = string.Empty;
            if (idOnly)
            {
                sqlQuery = "   SELECT " + BaseBusinessLogic.FieldId;
            }
            else
            {
                sqlQuery = "   SELECT * ";
            }
            sqlQuery += "     FROM " + tableName;
            switch (dbHelper.CurrentDbType)
            {
                case CurrentDbType.Access:
                case CurrentDbType.SqlServer:
                    sqlQuery += "    WHERE (LEFT(" + fieldCode + ", LEN('" + code + "')) = '" + code + "') ";
                    break;
                case CurrentDbType.Oracle:
                    sqlQuery += "    WHERE (SUBSTR(" + fieldCode + ", 1, LENGTH('" + code + "')) = '" + code + "') ";
                    break;
            }
            if (!String.IsNullOrEmpty(order))
            {
                sqlQuery += " ORDER BY " + order;
            }
            DataTable dataTable = new DataTable(tableName);
            dbHelper.Fill(dataTable, sqlQuery);
            return dataTable;
        }
        #endregion

        #region public static DataTable GetParentChildrensByCode(IDbHelper dbHelper, string tableName, string fieldCode, string code, string order, bool idOnly) 获取父子节点列表
        /// <summary>
        /// 获取父子节点列表
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="tableName">目标表明</param>
        /// <param name="fieldCode">编码字段</param>
        /// <param name="code">编码</param>
        /// <param name="order">排序</param>
        /// <param name="idOnly">只需要主键</param>
        /// <returns>数据表</returns>
        public static DataTable GetParentChildrensByCode(IDbHelper dbHelper, string tableName, string fieldCode, string code, string order, bool idOnly = false)
        {
            string sqlQuery = string.Empty;
            if (idOnly)
            {
                sqlQuery = "   SELECT " + BaseBusinessLogic.FieldId;
            }
            else
            {
                sqlQuery = "   SELECT * ";
            }
            sqlQuery += "     FROM " + tableName;
            switch (dbHelper.CurrentDbType)
            {
                case CurrentDbType.Access:
                case CurrentDbType.SqlServer:
                    sqlQuery += "    WHERE (LEFT(" + fieldCode + ", LEN(" + dbHelper.GetParameter(fieldCode) + ")) = " + dbHelper.GetParameter(fieldCode) + ") ";
                    sqlQuery += "          OR (LEFT(" + dbHelper.GetParameter(fieldCode) + ", LEN(" + fieldCode + ")) = " + fieldCode + ") ";
                    break;
                case CurrentDbType.Oracle:
                    sqlQuery += "    WHERE (SUBSTR(" + fieldCode + ", 1, LENGTH(" + dbHelper.GetParameter(fieldCode) + ")) = " + dbHelper.GetParameter(fieldCode) + ") ";
                    sqlQuery += "          OR (" + fieldCode + " = SUBSTR(" + dbHelper.GetParameter(fieldCode) + ", 1, LENGTH(" + fieldCode + "))) ";
                    break;
            }
            if (!String.IsNullOrEmpty(order))
            {
                sqlQuery += " ORDER BY " + order;
            }
            string[] names = new string[3];
            names[0] = fieldCode;
            names[1] = fieldCode;
            names[2] = fieldCode;
            Object[] values = new Object[3];
            values[0] = code;
            values[1] = code;
            values[2] = code;
            DataTable dataTable = new DataTable("DotNet");
            dbHelper.Fill(dataTable, sqlQuery, dbHelper.MakeParameters(names, values));
            return dataTable;
        }
        #endregion



        #region public static string[] GetParentsIDByCode(IDbHelper dbHelper, string tableName, string fieldCode, string code, string order) 获取父节点列表
        /// <summary>
        /// 获取父节点列表
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="tableName">目标表明</param>
        /// <param name="fieldCode">编码字段</param>
        /// <param name="code">编码</param>
        /// <param name="order">排序</param>
        /// <returns>主键数组</returns>
        public static string[] GetParentsIDByCode(IDbHelper dbHelper, string tableName, string fieldCode, string code, string order)
        {
            return BaseBusinessLogic.FieldToArray(GetParentsByCode(dbHelper, tableName, fieldCode, code, order, true), BaseBusinessLogic.FieldId);
        }
        #endregion

        #region public static string[] GetChildrensId(IDbHelper dbHelper, string tableName, string fieldId, string id, string fieldParentId, string order) 获取子节点列表
        /// <summary>
        /// 获取子节点列表
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="tableName">目标表明</param>
        /// <param name="fieldId">主键字段</param>
        /// <param name="id">值</param>
        /// <param name="fieldParentId">父亲节点字段</param>
        /// <param name="order">排序</param>
        /// <returns>主键数组</returns>
        public static string[] GetChildrensId(IDbHelper dbHelper, string tableName, string fieldId, string id, string fieldParentId, string order)
        {
            return BaseBusinessLogic.FieldToArray(GetChildrens(dbHelper, tableName, fieldId, id, fieldParentId, order, true), BaseBusinessLogic.FieldId);
        }
        #endregion

        #region public static string[] GetChildrensByIDCode(IDbHelper dbHelper, string tableName, string fieldCode, string code, string order) 获取子节点列表
        /// <summary>
        /// 获取子节点列表
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="tableName">目标表明</param>
        /// <param name="fieldCode">编码字段</param>
        /// <param name="code">编码</param>
        /// <param name="order">排序</param>
        /// <returns>主键数组</returns>
        public static string[] GetChildrensIdByCode(IDbHelper dbHelper, string tableName, string fieldCode, string code, string order)
        {
            return BaseBusinessLogic.FieldToArray(GetChildrensByCode(dbHelper, tableName, fieldCode, code, order, true), BaseBusinessLogic.FieldId);
        }
        #endregion

        #region public static string[] GetParentChildrensIdByCode(IDbHelper dbHelper, string tableName, string fieldCode, string code, string order) 获取父子节点列表
        /// <summary>
        /// 获取父子节点列表
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="tableName">目标表明</param>
        /// <param name="fieldCode">编码字段</param>
        /// <param name="code">编码</param>
        /// <param name="order">排序</param>
        /// <returns>主键数组</returns>
        public static string[] GetParentChildrensIdByCode(IDbHelper dbHelper, string tableName, string fieldCode, string code, string order)
        {
            return BaseBusinessLogic.FieldToArray(GetParentChildrensByCode(dbHelper, tableName, fieldCode, code, order, true), BaseBusinessLogic.FieldId);
        }
        #endregion


        #region public static string GetParentIdByCode(IDbHelper dbHelper, string tableName, string fieldCode, string code) 获取父节点
        /// <summary>
        /// 获取父节点
        /// </summary>
        /// <param name="tableName">目标表名</param>
        /// <param name="fieldCode">编码字段</param>
        /// <param name="code">编号</param>
        /// <returns>主键</returns>
        public static string GetParentIdByCode(IDbHelper dbHelper, string tableName, string fieldCode, string code)
        {
            string parentId = string.Empty;
            string sqlQuery = " SELECT MAX(Id) AS Id "
                            + "    FROM " + tableName
                            + "  WHERE (LEFT(" + dbHelper.GetParameter(fieldCode) + ", LEN(" + fieldCode + ")) = " + fieldCode + ") "
                            + "    AND " + fieldCode + " <>  '" + code + " ' ";
            string[] names = new string[1];
            Object[] values = new Object[1];
            names[0] = fieldCode;
            values[0] = code;
            object returnObject = dbHelper.ExecuteScalar(sqlQuery, dbHelper.MakeParameters(names, values));
            if (returnObject != null)
            {
                parentId = returnObject.ToString();
            }
            return parentId;
        }
        #endregion
    }
}