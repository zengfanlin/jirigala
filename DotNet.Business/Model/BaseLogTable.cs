//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.Business
{
    /// <summary>
    /// BaseLogEntity
    /// 日志的基类结构定义（程序OK）
    ///
    /// 修改纪录
    /// 
    ///     2011.03.24 版本：2.6 JiRiGaLa   讲程序转移到DotNet.BaseManager命名空间中。
    ///     2008.06.13 版本：2.4 JiRiGaLa   将思路调整为面向服务记录日志。
    ///     2007.12.03 版本：2.3 JiRiGaLa   进行规范化整理。
    ///     2007.11.08 版本：2.2 JiRiGaLa   整理多余的主键（OK）。
    ///		2007.06.01 版本：2.1 JiRiGaLa   GetFrom()函数改进。
    ///		2006.12.02 版本：2.0 JiRiGaLa   程序整理。
    ///		2004.07.28 版本：1.0 JiRiGaLa   主键ID需要进行倒序排序，这样数据库管理员很方便地找到最新的纪录及被修改的纪录。
    ///									    ModuleId 需要进行外键数据库完整性约束。
    ///		2004.11.12 版本：1.0 JiRiGaLa   改进了一些思路，把以前优秀的想法加进来，已备后用。
    ///		2005.09.30 版本：1.0 JiRiGaLa   又进行一次飞跃，把一些思想进行了统一。
    /// 
    /// 版本：2.4
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.06.13</date>
    /// </author> 
    /// </summary>
    public partial class BaseLogEntity
    {
        /// <summary>
        /// 系统日志表
        /// </summary>
        [NonSerialized]
        public static string TableName = "BaseLog";

        /// <summary>
        /// 主键
        /// </summary>
        [NonSerialized]
        public static string FieldId = "LogId";

        /// <summary>
        /// 服务
        /// </summary>
        [NonSerialized]
        public static string FieldProcessId = "ProcessId";

        /// <summary>
        /// 服务名称
        /// </summary>
        [NonSerialized]
        public static string FieldProcessName = "ProcessName";

        /// <summary>
        /// 操作
        /// </summary>
        [NonSerialized]
        public static string FieldMethodId = "MethodId";

        /// <summary>
        /// 操作名称
        /// </summary>
        [NonSerialized]
        public static string FieldMethodName = "MethodName";

        /// <summary>
        /// 操作参数
        /// </summary>
        [NonSerialized]
        public static string FieldParameters = "Parameters";

        /// <summary>
        /// 用户主键
        /// </summary>
        [NonSerialized]
        public static string FieldUserId = "UserId";

        /// <summary>
        /// 用户名称
        /// </summary>
        [NonSerialized]
        public static string FieldUserRealName = "UserRealName";

        /// <summary>
        /// IP地址
        /// </summary>
        [NonSerialized]
        public static string FieldIPAddress = "IPAddress";

        /// <summary>
        /// 上一个网络地址
        /// </summary>
        [NonSerialized]
        public static string FieldUrlReferrer = "UrlReferrer";

        /// <summary>
        /// 网络地址
        /// </summary>
        [NonSerialized]
        public static string FieldWebUrl = "WebUrl";

        /// <summary>
        /// 描述
        /// </summary>
        [NonSerialized]
        public static string FieldDescription = "Description";

        /// <summary>
        /// 创建时间
        /// </summary>
        [NonSerialized]
        public static string FieldCreateOn = "CreateOn";

        ///<summary>
        /// 修改用户
        ///</summary>
        public static string FieldModifiedOn = "ModifiedOn";
    }
}