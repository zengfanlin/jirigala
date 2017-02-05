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
        /// 是否区分大小写
        /// </summary>
        public static bool MatchCase = true;

        /// <summary>
        /// 最多获取数据的行数限制
        /// </summary>
        public static int TopLimit = 200;

        /// <summary>
        /// 强类型密码管理
        /// </summary>
        public static bool CheckPasswordStrength = false;

        /// <summary>
        /// 服务器端加密存储密码
        /// </summary>
        public static bool ServerEncryptPassword = true;

        /// <summary>
        /// 密码最小长度
        /// </summary>
        public static int PasswordMiniLength = 6;

        /// <summary>
        /// 必须字母+数字组合
        /// </summary>
        public static bool NumericCharacters = true;

        /// <summary>
        /// 密码修改周期(月)
        /// </summary>
        public static int PasswordChangeCycle = 3;

        /// <summary>
        /// 用户名最小长度
        /// </summary>
        public static int AccountMinimumLength = 4;

        /// <summary>
        /// 密码错误锁定次数
        /// </summary>
        public static int PasswordErrowLockLimit = 5;

        /// <summary>
        /// 密码错误锁定周期(分钟)
        /// </summary>
        public static int PasswordErrowLockCycle = 30;
    }
}