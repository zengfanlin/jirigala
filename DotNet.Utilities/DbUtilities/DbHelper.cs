//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Data.Common;

namespace DotNet.Utilities
{
    /// <summary>
    /// DbHelper
    /// 有关数据库连接的方法。
    /// 
    /// 修改纪录
    /// 
    ///		2011.09.18 版本：2.0 JiRiGaLa 采用默认参数技术,把一些方法进行简化。
    ///		2008.09.03 版本：1.0 JiRiGaLa 创建。
    /// 
    /// 版本：2.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.09.18</date>
    /// </author> 
    /// </summary>
    public class DbHelper
    {
        /// <summary>
        /// 按数据类型获取数据库访问实现类
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <returns>数据库访问实现类</returns>
        public static string GetDbHelperClass(CurrentDbType dbType)
        {
            string returnValue = "DotNet.Utilities.SqlHelper";
            switch (dbType)
            {
                case CurrentDbType.SqlServer:
                    returnValue = "DotNet.Utilities.SqlHelper";
                    break;
                case CurrentDbType.Oracle:
                    returnValue = "DotNet.Utilities.MSOracleHelper";
                    break;
                case CurrentDbType.Access:
                    returnValue = "DotNet.Utilities.OleDbHelper";
                    break;
                case CurrentDbType.MySql:
                    returnValue = "DotNet.Utilities.MySqlHelper";
                    break;
                case CurrentDbType.DB2:
                    returnValue = "DotNet.Utilities.DB2Helper";
                    break;
                case CurrentDbType.SQLite:
                    returnValue = "DotNet.Utilities.SqLiteHelper";
                    break;
            }
            return returnValue;
        }

        /// <summary>
        /// 数据库连接串，这里是为了简化思路
        /// </summary>
        public static string DbConnection = BaseSystemInfo.BusinessDbConnection;

        /// <summary>
        /// 数据库类型，这里也是为了简化思路
        /// </summary>
        public static CurrentDbType DbType = BaseSystemInfo.BusinessDbType;

        private static readonly IDbHelper dbHelper = DbHelperFactory.GetHelper(DbType, DbConnection);

        /// <summary> DbProviderFactory 实例
        /// DbProviderFactory实例
        /// </summary>
        private static DbProviderFactory factory = null;

        /// <summary> DbFactory实例
        /// DbFactory实例
        /// </summary>
        public static DbProviderFactory Factory
        {
            get
            {
                if (factory == null)
                {
                    factory = dbHelper.GetInstance();
                }
                return factory;
            }
        }

        /// <summary> 构造方法
        /// 构造方法
        /// </summary>
        private DbHelper()
        {
        }

        /// <summary> 当前数据库类型
        /// 当前数据库类型
        /// </summary>
        public CurrentDbType CurrentDbType
        {
            get
            {
                return dbHelper.CurrentDbType;
            }
        }

        #region public static string GetDBNow() 获得数据库日期时间
        /// <summary>
        /// 获得数据库日期时间
        /// </summary>
        /// <returns>日期时间</returns>
        public static string GetDBNow()
        {
            return dbHelper.GetDBNow();
        }
        #endregion

        #region public static string GetDBDateTime() 获得数据库日期时间
        /// <summary>
        /// 获得数据库日期时间
        /// </summary>
        /// <returns>日期时间</returns>
        public static string GetDBDateTime()
        {
            return dbHelper.GetDBDateTime();
        }
        #endregion

        #region public static string SqlSafe(string value) 检查参数的安全性
        /// <summary>
        /// 检查参数的安全性
        /// </summary>
        /// <param name="value">参数</param>
        /// <returns>安全的参数</returns>
        public static string SqlSafe(string value)
        {
            return dbHelper.SqlSafe(value);
        }
        #endregion

        #region string PlusSign() 获得Sql字符串相加符号
        /// <summary>
        ///  获得Sql字符串相加符号
        /// </summary>
        /// <returns>字符加</returns>
        public static string PlusSign()
        {
            return dbHelper.PlusSign();
        }
        #endregion

        #region string PlusSign(params string[] values) 获得Sql字符串相加符号
        /// <summary>
        ///  获得Sql字符串相加符号
        /// </summary>
        /// <param name="values">参数值</param>
        /// <returns>字符加</returns>
        public static string PlusSign(params string[] values)
        {
            return dbHelper.PlusSign(values);
        }
        #endregion

        #region public static string GetParameter(string parameter) 获得参数Sql表达式
        /// <summary>
        /// 获得参数Sql表达式
        /// </summary>
        /// <param name="parameter">参数名称</param>
        /// <returns>字符串</returns>
        public static string GetParameter(string parameter)
        {
            return dbHelper.GetParameter(parameter);
        }
        #endregion

        #region public static IDbDataParameter MakeParameter(string targetFiled, object targetValue) 获取参数
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="targetFiled">目标字段</param>
        /// <param name="targetValue">值</param>
        /// <returns>参数集</returns>
        public static IDbDataParameter MakeParameter(string targetFiled, object targetValue)
        {
            return dbHelper.MakeParameter(targetFiled, targetValue);
        }
        #endregion

        #region public static IDbDataParameter[] MakeParameters(string[] targetFileds, Object[] targetValues) 获取参数
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="targetFiled">目标字段</param>
        /// <param name="targetValue">值</param>
        /// <returns>参数集</returns>
        public static IDbDataParameter[] MakeParameters(string[] targetFileds, Object[] targetValues)
        {
            return dbHelper.MakeParameters(targetFileds, targetValues);
        }
        #endregion

        #region public static IDbDataParameter MakeParameter(string parameterName, object parameterValue, DbType dbType, Int32 parameterSize, ParameterDirection parameterDirection) 获取参数
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <param name="parameterValue">值</param>
        /// <param name="dbType">数据类型</param>
        /// <param name="parameterSize">大小</param>
        /// <param name="parameterDirection">输出方向</param>
        /// <returns>参数集</returns>
        public static IDbDataParameter MakeParameter(string parameterName, object parameterValue, DbType dbType, Int32 parameterSize, ParameterDirection parameterDirection)
        {
            return dbHelper.MakeParameter(parameterName, parameterValue, dbType, parameterSize, parameterDirection);
        }
        #endregion
        
        #region public static int ExecuteNonQuery(string commandText, IDbDataParameter[] dbParameters = null, CommandType commandType = CommandType.Text) 执行查询返回受影响的行数
        /// <summary>
        /// 执行查询返回受影响的行数
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <param name="commandType">命令分类</param>
        /// <returns>影响行数</returns>
        public static int ExecuteNonQuery(string commandText, IDbDataParameter[] dbParameters = null, CommandType commandType = CommandType.Text)
        {
            int returnValue = 0;
            dbHelper.Open(DbConnection);
            returnValue = dbHelper.ExecuteNonQuery(commandText, dbParameters, commandType);
            dbHelper.Close();
            return returnValue;
        }
        #endregion

        #region public static object ExecuteScalar(string commandText, IDbDataParameter[] dbParameters = null, CommandType commandType = CommandType.Text) 执行查询返回受首行首列
        /// <summary>
        /// 执行查询返回受首行首列
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <param name="commandType">命令分类</param>
        /// <returns>object</returns>
        public static object ExecuteScalar(string commandText, IDbDataParameter[] dbParameters = null, CommandType commandType = CommandType.Text)
        {
            object returnValue = null;
            dbHelper.Open(DbConnection);
            returnValue = dbHelper.ExecuteScalar(commandText, dbParameters, commandType);
            dbHelper.Close();
            return returnValue;
        }
        #endregion

        #region public static IDataReader ExecuteReader(string commandText, IDbDataParameter[] dbParameters = null, CommandType commandType = CommandType.Text) 执行查询返回DataReader
        /// <summary>
        /// 执行查询返回DataReader
        /// </summary>
        /// <param name="commandType">命令分类</param>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>结果集流</returns>
        public static IDataReader ExecuteReader(string commandText, IDbDataParameter[] dbParameters = null, CommandType commandType = CommandType.Text)
        {
            dbHelper.Open(DbConnection);
            dbHelper.AutoOpenClose = true;
            return dbHelper.ExecuteReader(commandText, dbParameters, commandType);
        }
        #endregion

        #region public static DataTable Fill(string commandText, IDbDataParameter[] dbParameters, CommandType commandType = CommandType.Text) 填充数据表
        /// <summary>
        /// 填充数据表
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <param name="commandType">命令分类</param>
        /// <returns>数据表</returns>
        public static DataTable Fill(string commandText, IDbDataParameter[] dbParameters = null, CommandType commandType = CommandType.Text)
        {
            DataTable dataTable = new DataTable("DotNet");
            dbHelper.Open(DbConnection);
            dbHelper.Fill(dataTable, commandText, dbParameters, commandType);
            dbHelper.Close();
            return dataTable;
        }
        #endregion
    }
}