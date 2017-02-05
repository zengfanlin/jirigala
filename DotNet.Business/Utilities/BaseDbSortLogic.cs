//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    ///	BaseDbSortLogic
    /// 通用排序逻辑基类（程序OK）
    /// 
    /// 修改纪录
    /// 
    ///		2007.12.10 版本：   1.3 JiRiGaLa 改进 序列产生码的长度问题。
    ///		2007.11.01 版本：   1.2 JiRiGaLa 改进 BUOperatorInfo 去掉这个变量，可以提高性能，提高速度，基类的又一次飞跃。
    ///		2007.03.01 版本：   1.0 JiRiGaLa 将主键从 BUBaseBusinessLogic 类分离出来。
    ///	
    /// 版本：1.3
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.12.10</date>
    /// </author> 
    /// </summary>
    public class BaseDbSortLogic
    {
        public const string CommandSetTop       = "SetTop";     // 置顶排方法令命名定义
        public const string CommandSetUp        = "SetUp";      // 上移排序方法命名定义
        public const string CommandSetDown      = "SetDown";    // 下移排序方法命名定义
        public const string CommandSetBottom    = "SetBottom";  // 置底排序方法命名定义
        public const string CommandSwap         = "Swap";       // 交换排序方法命名定义

        //
        // 排序操作针对数据库的运算方式定义（好用高效的排序顺序设定方法）
        //

        #region public static int SetTop(IDbHelper dbHelper, string tableName, string id) 置顶排序命令
        /// <summary>
        /// 置顶排序方法
        /// </summary>
        /// <param name="dbHelper">当前数据库连接</param>
        /// <param name="tableName">表名</param>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public static int SetTop(IDbHelper dbHelper, string tableName, string id)
        {
            BaseSequenceManager sequenceManager = new BaseSequenceManager(dbHelper);
            string sequence = sequenceManager.GetReduction(tableName);
            List<KeyValuePair<string, object>> whereParameters = new List<KeyValuePair<string, object>>();
            whereParameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldId, id));
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldSortCode, sequence));
            return DbLogic.SetProperty(dbHelper, tableName, whereParameters, parameters);
        }
        #endregion

        public static int SetTop(IDbHelper dbHelper, string tableName, string id, string sequenceName)
        {
            if (String.IsNullOrEmpty(sequenceName))
            {
                sequenceName = tableName;
            }
            BaseSequenceManager sequenceManager = new BaseSequenceManager(dbHelper);
            string sequence = sequenceManager.GetReduction(sequenceName);

            List<KeyValuePair<string, object>> whereParameters = new List<KeyValuePair<string, object>>();
            whereParameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldId, id));
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldSortCode, sequence));
            return DbLogic.SetProperty(dbHelper, tableName, whereParameters, parameters);
        }


        #region public static int Swap(IDbHelper dbHelper, string tableName, string id, string targetId) 交换排序命令
        /// <summary>
        /// 交换排序方法
        /// </summary>
        /// <param name="dbHelper">当前数据库连接</param>
        /// <param name="tableName">表名</param>
        /// <param name="id">记录主键</param>
        /// <param name="targetId">目标记录主键</param>
        /// <returns>影响行数</returns>
        public static int Swap(IDbHelper dbHelper, string tableName, string id, string targetId)
        {
            int returnValue = 0;
            // 要移动的主键的排序码
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldId, id));
            string sortCode = DbLogic.GetProperty(dbHelper, tableName, parameters, BaseBusinessLogic.FieldSortCode);
            // 目标主键的排序码
            parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldId, targetId));
            string targetSortCode = DbLogic.GetProperty(dbHelper, tableName, parameters, BaseBusinessLogic.FieldSortCode);

            // 以下方法，在MySQL里不能正常运行，虽然效率是很高
            // 设置要移动的主键的排序码（注：少读取数据库一次，提高主键运行效率）
            // string sqlQuery = " UPDATE " + tableName
            //                    + "    SET " + BaseBusinessLogic.FieldSortCode + " = (SELECT " + BaseBusinessLogic.FieldSortCode
            //                    + "                                    FROM " + tableName
            //                    + "                                   WHERE " + BaseBusinessLogic.FieldId + " = '" + targetId + "') "
            //                    + "  WHERE " + BaseBusinessLogic.FieldId + " = '" + Id + "' ";
            // returnValue = DbHelper.ExecuteNonQuery(sqlQuery);

            List<KeyValuePair<string, object>> whereParameters = new List<KeyValuePair<string, object>>();
            whereParameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldId, id));
            parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldSortCode, targetSortCode));
            // 设置目标主键的排序码
            returnValue += DbLogic.SetProperty(dbHelper, tableName, whereParameters, parameters);
            whereParameters = new List<KeyValuePair<string, object>>();
            whereParameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldId, targetId));
            parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldSortCode, sortCode));
            // 设置目标主键的排序码
            returnValue += DbLogic.SetProperty(dbHelper, tableName, whereParameters, parameters);
            return returnValue;
        }
        #endregion

        #region public static int SetBottom(IDbHelper dbHelper, string tableName, string id) 置底排序方法
        /// <summary>
        /// 置底排序方法
        /// </summary>
        /// <param name="dbHelper">当前数据库连接</param>
        /// <param name="tableName">表名</param>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public static int SetBottom(IDbHelper dbHelper, string tableName, string id)
        {
            BaseSequenceManager sequenceManager = new BaseSequenceManager(dbHelper);
            string sequence = sequenceManager.GetSequence(tableName);
            List<KeyValuePair<string, object>> whereParameters = new List<KeyValuePair<string, object>>();
            whereParameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldId, id));
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldSortCode, sequence));
            return DbLogic.SetProperty(dbHelper, tableName, whereParameters, parameters);
        }
        #endregion

        public static int SetBottom(IDbHelper dbHelper, string tableName, string id, string sequenceName)
        {
            if (String.IsNullOrEmpty(sequenceName))
            {
                sequenceName = tableName;
            }
            BaseSequenceManager sequenceManager = new BaseSequenceManager(dbHelper);
            string sequence = sequenceManager.GetSequence(sequenceName);

            List<KeyValuePair<string, object>> whereParameters = new List<KeyValuePair<string, object>>();
            whereParameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldId, id));
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldSortCode, sequence));
            return DbLogic.SetProperty(dbHelper, tableName, whereParameters, parameters);
        }

        //
        // 通过数据库底层进行排序位置交换（这些方法不常用）
        //

        #region public static string GetUpId(IDbHelper dbHelper, string tableName, string categoryId, string id) 获得上一个记录主键
        /// <summary>
        /// 获得上一个记录主键
        /// </summary>
        /// <param name="dbHelper">当前数据库连接</param>
        /// <param name="tableName">表名</param>
        /// <param name="categoryId">类别主键</param>
        /// <param name="id">当前主键</param>
        /// <returns>目标主键</returns>
        public static string GetUpId(IDbHelper dbHelper, string tableName, string categoryId, string id)
        {
            string subQuery = string.Empty;
            string sqlQuery = string.Empty;
            string returnValue = string.Empty;
            if (categoryId.Length > 0)
            {
                subQuery = BaseBusinessLogic.FieldCategoryId + " = '" + categoryId 
                                + "' AND ";
            }
            sqlQuery = " SELECT TOP 1 " + BaseBusinessLogic.FieldId
                + " FROM " + tableName
                + " WHERE ( " + subQuery + BaseBusinessLogic.FieldSortCode + " > (SELECT TOP 1 " + BaseBusinessLogic.FieldSortCode
                + " FROM " + tableName
                + " WHERE ( " + subQuery + BaseBusinessLogic.FieldId + " = '" + id + "' ) "
                + " ORDER BY " + BaseBusinessLogic.FieldSortCode + " )) "
                + " ORDER BY " + BaseBusinessLogic.FieldSortCode + " ASC ";
            return dbHelper.ExecuteScalar(sqlQuery).ToString();
        }
        #endregion

        #region public static string GetUpId(IDbHelper dbHelper, string tableName, string id) 获得上一个记录主键
        /// <summary>
        /// 获得上一个记录主键
        /// </summary>
        /// <param name="dbHelper">当前数据库连接</param>
        /// <param name="tableName">表名</param>
        /// <param name="id">当前主键</param>
        /// <returns>目标主键</returns>
        public static string GetUpId(IDbHelper dbHelper, string tableName, string id)
        {
            return GetUpId(dbHelper, tableName, string.Empty, id);
        }
        #endregion

        #region public static int SetUp(IDbHelper dbHelper, string tableName, string categoryId, string id) 上移记录的方法
        /// <summary>
        /// 上移记录的方法
        /// </summary>
        /// <param name="dbHelper">当前数据库连接</param>
        /// <param name="tableName">表名</param>
        /// <param name="categoryId">类别主键</param>
        /// <param name="id">当前主键</param>
        /// <returns>目标主键</returns>
        public static int SetUp(IDbHelper dbHelper, string tableName, string categoryId, string id)
        {
            string upId = GetUpId(dbHelper, tableName, categoryId, id);
            string sortCode = string.Empty;
            string upSortCode = string.Empty;
            int returnValue = 0;
            if (upId.Length == 0)
            {
                return returnValue;
            }
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldId, id));
            sortCode = DbLogic.GetProperty(dbHelper, tableName, parameters, BaseBusinessLogic.FieldSortCode);

            parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldId, upId));
            upSortCode = DbLogic.GetProperty(dbHelper, tableName, parameters, BaseBusinessLogic.FieldSortCode);

            List<KeyValuePair<string, object>> whereParameters = new List<KeyValuePair<string, object>>();
            whereParameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldId, upId));
            parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldSortCode, sortCode));
            returnValue = DbLogic.SetProperty(dbHelper, tableName, whereParameters, parameters);

            whereParameters = new List<KeyValuePair<string, object>>();
            whereParameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldId, id));
            parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldSortCode, upSortCode));
            returnValue += DbLogic.SetProperty(dbHelper, tableName, whereParameters, parameters);
            return returnValue;
        }
        #endregion

        #region public static int SetUp(IDbHelper dbHelper, string tableName, string id) 上移记录的方法
        /// <summary>
        /// 上移记录的方法
        /// </summary>
        /// <param name="dbHelper">当前数据库连接</param>
        /// <param name="tableName">表名</param>
        /// <param name="id">当前主键</param>
        /// <returns>目标主键</returns>
        public static int SetUp(IDbHelper dbHelper, string tableName, string id)
        {
            return SetUp(dbHelper, tableName, string.Empty, id);
        }
        #endregion


        #region public static string GetDownId(IDbHelper dbHelper, string tableName, string categoryId, string id) 获得下一个记录主键
        /// <summary>
        /// 获得下一个记录主键
        /// </summary>
        /// <param name="dbHelper">当前数据库连接</param>
        /// <param name="tableName">表名</param>
        /// <param name="categoryId">类别主键</param>
        /// <param name="id">当前主键</param>
        /// <returns>目标主键</returns>
        public static string GetDownId(IDbHelper dbHelper, string tableName, string categoryId, string id)
        {
            string subQuery = string.Empty;
            string sqlQuery = string.Empty;
            // string upID = string.Empty;
            // string returnValue = string.Empty;
            if (categoryId.Length > 0)
            {
                subQuery = BaseBusinessLogic.FieldCategoryId + " = '" + categoryId + "' And ";
            }
            sqlQuery = "SELECT TOP 1 " + BaseBusinessLogic.FieldId
                + " FROM " + tableName
                + " WHERE ( " + subQuery + BaseBusinessLogic.FieldSortCode + " < (SELECT TOP 1 " + BaseBusinessLogic.FieldSortCode
                + " FROM " + tableName
                + " WHERE ( " + subQuery + BaseBusinessLogic.FieldId + " = '" + id + "' ) "
                + " ORDER BY " + BaseBusinessLogic.FieldSortCode + " )) ORDER BY " + BaseBusinessLogic.FieldSortCode + " DESC ";
            return dbHelper.ExecuteScalar(sqlQuery).ToString();
        }
        #endregion

        #region public static string GetDownId(IDbHelper dbHelper,　String tableName, string id) 获得下一个记录主键
        /// <summary>
        /// 获得下一个记录主键
        /// </summary>
        /// <param name="dbHelper">当前数据库连接</param>
        /// <param name="tableName">表名</param>
        /// <param name="id">当前主键</param>
        /// <returns>目标主键</returns>
        public static string GetDownId(IDbHelper dbHelper, string tableName, string id)
        {
            return GetDownId(dbHelper, tableName, string.Empty, id);
        }
        #endregion

        #region public static int SetDown(IDbHelper dbHelper, string tableName, string categoryId, string id) 下移记录的方法
        /// <summary>
        /// 下移记录的方法
        /// </summary>
        /// <param name="dbHelper">当前数据库连接</param>
        /// <param name="tableName">表名</param>
        /// <param name="categoryId">类别主键</param>
        /// <param name="id">当前主键</param>
        /// <returns>目标主键</returns>
        public static int SetDown(IDbHelper dbHelper, string tableName, string categoryId, string id)
        {
            string downId = string.Empty;
            string sortCode = string.Empty;
            string downSortCode = string.Empty;
            int returnValue = 0;
            downId = GetDownId(dbHelper, tableName, categoryId, id);
            if (downId.Length == 0)
            {
                return returnValue;
            }
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldId, id));
            sortCode = DbLogic.GetProperty(dbHelper, tableName, parameters, BaseBusinessLogic.FieldSortCode);
            parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldId, downId));
            downSortCode = DbLogic.GetProperty(dbHelper, tableName, parameters, BaseBusinessLogic.FieldSortCode);

            List<KeyValuePair<string, object>> whereParameters = new List<KeyValuePair<string, object>>();
            whereParameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldId, downId));
            parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldSortCode, sortCode));
            DbLogic.SetProperty(dbHelper, tableName, whereParameters, parameters);

            whereParameters = new List<KeyValuePair<string, object>>();
            whereParameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldId, id));
            parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldSortCode, downSortCode));
            returnValue = DbLogic.SetProperty(dbHelper, tableName, whereParameters, parameters);
            return returnValue;
        }
        #endregion

        #region public static int SetDown(IDbHelper dbHelper, string tableName, string id) 下移记录的方法
        /// <summary>
        /// 下移记录的方法
        /// </summary>
        /// <param name="dbHelper">当前数据库连接</param>
        /// <param name="tableName">表名</param>
        /// <param name="id">当前主键</param>
        /// <returns>目标主键</returns>
        public static int SetDown(IDbHelper dbHelper, string tableName, string id)
        {
            return SetDown(dbHelper, tableName, string.Empty, id);
        }
        #endregion
    }
}