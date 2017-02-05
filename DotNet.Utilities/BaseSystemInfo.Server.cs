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
        /// 允许新用户注册
        /// </summary>
        public static bool AllowUserRegister = true;

        /// <summary>
        /// 禁止用户重复登录
        /// 只允许登录一次
        /// </summary>
        public static bool CheckOnLine = false;

        /// <summary>
        /// 软件是否需要注册
        /// </summary>
        public static bool NeedRegister = true;

        /// <summary>
        /// 注册码
        /// </summary>
        public static string RegisterKey = string.Empty;

        /// <summary>
        /// 是否采用服务器端缓存
        /// </summary>
        public static bool ServerCache = false;

        /// <summary>
        /// 这里是设置，读取哪个系统的菜单
        /// </summary>
        public static string SystemCode = "Base";

        /// <summary>
        /// 这里是设置，读取哪个子系统的菜单
        /// </summary>
        public static string RootMenuCode = "DotNet.Common";

        /// <summary>
        /// 检查周期5分钟内不在线的，就认为是已经没在线了，生命周期检查
        /// </summary>
        public static int OnLineTime0ut = 5 * 60 + 20;

        /// <summary>
        /// 每过1分钟，检查一次在线状态
        /// </summary>
        public static int OnLineCheck = 60;

        /// <summary>
        /// 锁不住记录时的循环次数
        /// </summary>
        public static int LockNoWaitCount = 5;

        /// <summary>
        /// 锁不住记录时的等待时间
        /// </summary>
        public static int LockNoWaitTickMilliSeconds = 30;

        /// <summary>
        /// 连续输入N次密码后，需要锁定的X分钟时间 
        /// </summary>
        public static int LockUserPasswordError = 15;

        /// <summary>
        /// 上传文件路径
        /// </summary>
        public static string UploadDirectory = "Document/";

        /// <summary>
        /// 服務實現包
        /// </summary>
        public static string Service = "DotNet.Business";

        /// <summary>
        /// 服務映射工廠
        /// </summary>
        public static string ServiceFactory = "ServiceFactory";

        /// <summary>
        /// 系统默认密码
        /// </summary>
        public static string DefaultPassword = "123456";
    }
}