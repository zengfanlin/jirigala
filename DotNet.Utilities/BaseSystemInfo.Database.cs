//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.Utilities
{
    /// <summary>
    /// BaseSystemInfo
    /// 这是系统的核心基础信息部分
    /// 
    /// 修改记录
    ///		2012.04.14 版本：1.0 JiRiGaLa	主键创建。
    ///		
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.04.14</date>
    /// </author>
    /// </summary>
    public partial class BaseSystemInfo
    {
        /// <summary>
        /// 业务数据库类别
        /// </summary>
        public static CurrentDbType BusinessDbType = CurrentDbType.SqlServer;

        /// <summary>
        /// 用户数据库类别
        /// </summary>
        public static CurrentDbType UserCenterDbType = CurrentDbType.SqlServer;

        /// <summary>
        /// 工作流数据库类别
        /// </summary>
        public static CurrentDbType WorkFlowDbType = CurrentDbType.SqlServer;

        /// <summary>
        /// 是否加数据库连接
        /// </summary>
        public static bool EncryptDbConnection = false;

        /// <summary>
        /// 数据库连接
        /// </summary>
        public static string UserCenterDbConnection = "server=.\\sqlexpress;database=ProjectV37;integrated security=true;";

        /// <summary>
        /// 数据库连接的字符串
        /// </summary>
        public static string UserCenterDbConnectionString = string.Empty;

        /// <summary>
        /// 业务数据库
        /// </summary>
        public static string BusinessDbConnection = "server=.\\sqlexpress;database=ProjectV37;integrated security=true;";

        /// <summary>
        /// 业务数据库（连接串，可能是加密的）
        /// </summary>
        public static string BusinessDbConnectionString = string.Empty;

        /// <summary>
        /// 工作流数据库
        /// </summary>
        public static string WorkFlowDbConnection = "Data Source=localhost;Initial Catalog=WorkFlowV37;Integrated Security=SSPI;";

        /// <summary>
        /// 工作流数据库（连接串，可能是加密的）
        /// </summary>
        public static string WorkFlowDbConnectionString = string.Empty;
    }
}