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
    ///     2012.02.02 版本：3.8 zhangyi    修改OrganizeDynamicLoading = true。
    ///     2011.10.07 版本：2.3 JiRiGaLa   每个数据库都支持多类型数据库。
    ///     2011.07.15 版本：2.2 JiRiGaLa   参数信息整理，获取硬件信息的功能部分进行分离。
    ///     2011.07.07 版本：2.1 zgl        优化获取IP地址和Mac地址的方法
    ///		2010.09.19 版本：2.0 JiRiGaLa   彻底进行重构。
    ///		2007.04.02 版本：1.2 JiRiGaLa   进行主键优化。
    ///		2007.01.02 版本：1.1 JiRiGaLa   进行主键优化。
    ///		2006.02.05 版本：1.1 JiRiGaLa	重新调整主键的规范化。
    ///		2004.11.19 版本：1.0 JiRiGaLa	主键创建。
    ///		
    /// 版本：2.3
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.10.07</date>
    /// </author>
    /// </summary>
    public partial class BaseSystemInfo
    {
        /// <summary>
        /// 用户是否已经成功登录系统
        /// </summary>
        public static bool UserIsLogOn = false;

        /// <summary>
        /// 用户在线状态
        /// </summary>
        public static int OnLineState = 0;

        /// <summary>
        /// 当前网站的安装地址
        /// </summary>
        public static string StartupPath = string.Empty;

        /// <summary>
        /// 当前版本
        /// </summary>
        public static string Version = "3.7";

        /// <summary>
        /// 每个操作是否进行信息提示。
        /// </summary>
        public static bool ShowInformation = true;

        /// <summary>
        /// 时间格式
        /// </summary>
        public static string TimeFormat = "HH:mm:ss";

        /// <summary>
        /// 日期短格式
        /// </summary>
        public static string DateFormat = "yyyy-MM-dd";

        /// <summary>
        /// 日期长格式
        /// </summary>
        public static string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// 当前软件Id
        /// </summary>
        public static string SoftName = string.Empty;

        /// <summary>
        /// 软件的名称
        /// </summary>
        public static string SoftFullName = string.Empty;

        /// <summary>
        /// 当前客户公司名称
        /// </summary>
        public static string CustomerCompanyName = string.Empty;

        /// <summary>
        /// 系统图标文件
        /// </summary>
        public static string AppIco = "Resource\\Form.ico";

        /// <summary>
        /// RegistryKey、Configuration、UserConfig 注册表或者配置文件读取参数
        /// </summary>
        public static ConfigurationCategory ConfigurationFrom = ConfigurationCategory.Configuration;
    }
}