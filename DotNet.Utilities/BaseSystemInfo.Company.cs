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
        /// 当前客户公司电话
        /// </summary>
        public static string CustomerPhone = "0571-85461005";

        /// <summary>
        /// 公司名称
        /// </summary>
        public static string CompanyName = "杭州海日涵科技有限公司";

        /// <summary>
        /// 公司电话
        /// </summary>
        public static string CompanyPhone = "13858163011";

        /// <summary>
        /// 发送给谁，用,;符号隔开
        /// </summary>
        public static string ErrorReportTo = "JiRiGaLa_Bao@Hotmail.com";

        /// <summary>
        /// 邮件服务器地址
        /// </summary>
        public static string ErrorReportMailServer = "";

        /// <summary>
        /// 用户名
        /// </summary>
        public static string ErrorReportMailUserName = "";

        /// <summary>
        /// 密码
        /// </summary>
        public static string ErrorReportMailPassword = "";

        /// <summary>
        /// 要求客户注册的信息
        /// </summary>
        public static string RegisterException = "请您联系： 杭州海日涵科技 吉日嘎拉 手机：13858163011 电子邮件：JiRiGaLa_Bao@Hotmail.com 对软件进行注册。";
    }
}