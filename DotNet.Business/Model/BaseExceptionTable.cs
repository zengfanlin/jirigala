//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.Business
{
	/// <summary>
    ///	BaseExceptionEntity
    /// 异常信息的基类结构定义（程序OK）
	///	
	/// 修改纪录
    /// 
    ///     2007.12.03 版本：3.1 JiRiGaLa   吉日整理主键规范化。
    ///     2007.06.07 版本：3.0 JiRiGaLa   重新整理主键。
    ///		2006.09.23 版本：2.0 JiRiGaLa   吉日整理主键规范化。
	///		2006.02.06 版本：1.1 JiRiGaLa   重新调整主键的规范化。
	///		2005.08.13 版本：1.0 JiRiGaLa   主键整理。
	///		
	/// 版本：3.1
	///
	/// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.12.03</date>
	/// </author>
	/// </summary>
    public partial class BaseExceptionEntity
	{
        [NonSerialized]
        public static string TableName = "BaseException";

        [NonSerialized]
        public static string FieldId = "LogId";

        [NonSerialized]
        public static string FieldEventID = "EventId";

        [NonSerialized]
        public static string FieldCategory = "Category";

        [NonSerialized]
        public static string FieldPriority = "Priority";

        [NonSerialized]
        public static string FieldSeverity = "Severity";

        [NonSerialized]
        public static string FieldTitle = "Title";

        [NonSerialized]
        public static string FieldTimestamp = "Timestamp";

        [NonSerialized]
        public static string FieldMachineName = "MachineName";

        [NonSerialized]
        public static string FieldIPAddress = "IPAddress";

        [NonSerialized]
        public static string FieldAppDomainName = "AppDomainName";

        [NonSerialized]
        public static string FieldProcessId = "ProcessId";

        [NonSerialized]
        public static string FieldProcessName = "ProcessName";

        [NonSerialized]
        public static string FieldThreadName = "ThreadName";

        [NonSerialized]
        public static string FieldWin32ThreadId = "Win32ThreadId";

        [NonSerialized]
        public static string FieldMessage = "Message";

        [NonSerialized]
        public static string FieldFormattedMessage = "FormattedMessage";

        [NonSerialized]
        public static string FieldCreateUserId = "CreateUserId";

        [NonSerialized]
        public static string FieldCreateBy = "CreateBy"; // 创建者名称

        [NonSerialized]
        public static string FieldCreateOn = "CreateOn";         // 创建日期
    }
}