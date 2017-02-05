//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Reflection;

namespace DotNet.Utilities
{
    /// <summary>
    /// DbHelperFactory
    /// 数据库服务工厂。
    /// 
    /// 修改纪录
    /// 
    ///		2011.10.09 版本：2.1 JiRiGaLa 改进直接用数据库连接就可以打开连接的方法。
    ///		2011.10.08 版本：2.0 JiRiGaLa 支持多类型的多种数据库。
    ///		2011.09.18 版本：1.4 JiRiGaLa 整理代码注释。
    ///		2011.03.30 版本：1.3 JiRiGaLa 增加数据库连串的构造函数。
    ///		2009.07.23 版本：1.2 JiRiGaLa 每次都获取一个新的数据库连接，解决并发错误问题。
    ///		2008.09.23 版本：1.1 JiRiGaLa 优化改进为单实例模式。
    ///		2008.08.26 版本：1.0 JiRiGaLa 创建数据库服务工厂。
    /// 
    /// 版本：2.1
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.10.09</date>
    /// </author> 
    /// </summary>
    public class DbHelperFactory
    {
        /// <summary>
        /// 获取指定的数据库连接
        /// </summary>
        /// <param name="connectionString">数据库连接串</param>
        /// <returns>数据库访问类</returns>
        public static IDbHelper GetHelper(string connectionString)
        {
            CurrentDbType dbType = CurrentDbType.SqlServer;
            return GetHelper(dbType, connectionString);
        }

        /// <summary>
        /// 获取指定的数据库连接
        /// </summary>
        /// <param name="dataBaseType">数据库类型</param>
        /// <param name="connectionString">数据库连接串</param>
        /// <returns>数据库访问类</returns>
        public static IDbHelper GetHelper(CurrentDbType dbType = CurrentDbType.SqlServer, string connectionString = null)
        {
            // 这里是每次都获取新的数据库连接,否则会有并发访问的问题存在
            string dbHelperClass = DbHelper.GetDbHelperClass(dbType);
            IDbHelper dbHelper = (IDbHelper)Assembly.Load("DotNet.Utilities").CreateInstance(dbHelperClass, true);
            if (!string.IsNullOrEmpty(connectionString))
            {
                dbHelper.ConnectionString = connectionString;
            }
            else
            {
                dbHelper.ConnectionString = BaseSystemInfo.BusinessDbConnection;
            }
            return dbHelper;
        }
    }
}