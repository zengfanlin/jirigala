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
        /// 是否启用即时内部消息
        /// </summary>
        public static bool UseMessage = true;

        /// <summary>
        /// 目前使用者名稱
        /// </summary>
        public static string CurrentUserName = string.Empty;

        /// <summary>
        /// 目前使用者密碼
        /// </summary>
        public static string CurrentPassword = string.Empty;

        /// <summary>
        /// 是否儲存登入密碼，預設記住密碼
        /// </summary>
        public static bool RememberPassword = true;

        /// <summary>
        /// 是否自動登入，預設不自動登入
        /// </summary>
        public static bool AutoLogOn = false;

        /// <summary>
        /// 客戶端加密儲存密碼
        /// </summary>
        public static bool ClientEncryptPassword = true;

        /// <summary>
        /// 遠端調用Service使用者名稱（提高系統安全性）
        /// </summary>
        public static string ServiceUserName = "JiRiGaLa";

        /// <summary>
        /// 遠端調用Service密碼（提高系統安全性）
        /// </summary>
        public static string ServicePassword = "JiRiGaLa";

        /// <summary>
        /// 預設加載所有使用者，使用者量特別大時可設置為關閉
        /// </summary>
        public static bool LoadAllUser = true;

        /// <summary>
        /// 動態加載組織機構樹，當資料量非常龐大時可設置為開啟
        /// </summary>
        public static bool OrganizeDynamicLoading = true;

        /// <summary>
        /// 是否使用多語言
        /// </summary>
        public static bool MultiLanguage = true;

        /// <summary>
        /// 目前使用者選擇的語系
        /// </summary>
        public static string CurrentLanguage = "zh-CN";

        /// <summary>
        /// 目前佈景
        /// </summary>
        public static string Themes = string.Empty;

        /// <summary>
        /// 是否採用客戶端緩存
        /// </summary>
        public static bool ClientCache = false;

        private int lockWaitMinute = 60;

        /// <summary>
        /// 鎖定等待時間分鐘
        /// </summary>
        public int LockWaitMinute
        {
            get { return lockWaitMinute; }
            set { lockWaitMinute = value; }
        }

        /// <summary>
        /// 即時通訊指向的網站位置
        /// </summary>
        public static string WebHostUrl = "WebHostUrl";

        /// <summary>
        /// 主應用程式集名稱
        /// </summary>
        public static string MainAssembly = "DotNet.WinForm";

        /// <summary>
        /// 主視窗
        /// </summary>
        public static string MainForm = "SDIMainForm";

        /// <summary>
        /// 登入視窗
        /// </summary>
        public static string LogOnForm = "FrmLogOnByName";
    }
}