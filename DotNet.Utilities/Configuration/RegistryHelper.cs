//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using Microsoft.Win32;
using System.Globalization;

namespace DotNet.Utilities
{
    /// <summary>
    /// RegistryHelper
    /// 访问注册表的类。
    /// 
    /// 修改纪录
    ///
    ///		2008.06.08 版本：3.2 JiRiGaLa 命名修改为 RegistryHelper。 
    ///		2007.07.30 版本：3.1 JiRiGaLa Exists 函数名规范化。 
    ///		2007.04.14 版本：3.0 JiRiGaLa 检查程序格式通过，不再进行修改主键操作。 
    ///     2006.11.17 版本：2.2 JiRiGaLa 添加方法CheckExistSubKey()。
    ///     2006.09.08 版本：2.1 JiRiGaLa 变量命名规范化。
    ///     2006.04.18 版本：2.0 JiRiGaLa 重新调整主键的规范化。
    ///		2005.08.08 版本：1.0 JiRiGaLa 专门读取注册表的类，主键书写格式改进。
    ///		
    ///	版本：3.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.04.14</date>
    /// </author> 
    /// </summary>
    public class RegistryHelper
    {
        /// <summary>
        /// 注册表中的位置
        /// </summary>
        public static string SubKey = "Software\\" + "Hairihan TECH";

        #region public static string GetValue(string key) 读取注册表
        /// <summary>
		/// 读取注册表
		/// </summary>
        /// <param name="subKey">注册表子项</param>
		/// <param name="registryKey">键</param>
		/// <returns>值</returns>
        public static string GetValue(string key)
		{
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(SubKey, false);
            return (string)registryKey.GetValue(key);
		}
		#endregion

        #region public static void SetValue(string key, string keyValue) 设置注册表
        /// <summary>
        /// 设置注册表
        /// </summary>
        /// <param name="subKey">注册表子项</param>
        /// <param name="registryKey">键</param>
        /// <param name="keyValue">值</param>
        public static void SetValue(string key, string keyValue)
        {
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(SubKey, true);
            registryKey.SetValue(key, keyValue);
        }
        #endregion

        #region public static bool Exists(string key) 判断一个注册表项是否存在
        /// <summary>
        /// 判断一个注册表项是否存在
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>是否存在</returns>
        public static bool Exists(string key)
        {
            return Exists(SubKey, key);
        }
        #endregion

        #region public static bool Exists(string subKey, string key)
        /// <summary>
        /// 判断一个注册表项是否存在
        /// </summary>
        /// <param name="subKey">注册表子项</param>
        /// <param name="key">键</param>
        /// <returns>是否存在</returns>
        public static bool Exists(string subKey, string key)
        {
            bool returnValue = false;
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(subKey, false);
            string[] SubKeyNames = registryKey.GetSubKeyNames();
            for (int i = 0; i < SubKeyNames.Length; i++)
            {
                if (key.Equals(SubKeyNames[i]))
                {
                    returnValue = true;
                    break;
                }
            }
            return returnValue;
        }
        #endregion

        #region private static void GetValues() 获取注册表的值
        /// <summary>
        /// 获取注册表的值
        /// </summary>
        private static void GetValues()
        {
            SubKey = "Software\\" + "Hairihan TECH" + "\\" + BaseSystemInfo.SoftName;
            // 客户信息配置
            BaseSystemInfo.CustomerCompanyName = GetValue("CustomerCompanyName");
            BaseSystemInfo.ConfigurationFrom = BaseConfiguration.GetConfiguration(GetValue("ConfigurationFrom"));
            BaseSystemInfo.SoftName = GetValue("SoftName");
            BaseSystemInfo.SoftFullName = GetValue("SoftFullName");
            BaseSystemInfo.RootMenuCode = GetValue("RootMenuCode");
            BaseSystemInfo.CurrentLanguage = GetValue("CurrentLanguage");
            BaseSystemInfo.Version = GetValue("Version");            
            
            // 数据库连接
            BaseSystemInfo.BusinessDbConnection = GetValue("BusinessDbConnection");
            BaseSystemInfo.UserCenterDbConnection = GetValue("UserCenterDbConnection");

            BaseSystemInfo.BusinessDbType = BaseConfiguration.GetDbType(GetValue("DbType"));
            BaseSystemInfo.RegisterKey = GetValue("RegisterKey");
        }
        #endregion

        #region private static void SetValues() 设置注册表的值
        /// <summary>
        /// 设置注册表的值
        /// </summary>
        private static void SetValues()
        {
            // 默认的信息写入注册表
            SubKey = "Software\\" + "Hairihan TECH" + "\\" + BaseSystemInfo.SoftName;
            SetValue("CustomerCompanyName", BaseSystemInfo.CustomerCompanyName);
            SetValue("ConfigurationFrom", BaseSystemInfo.RegisterKey.ToString());
            SetValue("SoftName", BaseSystemInfo.SoftName);
            SetValue("SoftFullName", BaseSystemInfo.SoftFullName);
            SetValue("RootMenuCode", BaseSystemInfo.RootMenuCode);
            SetValue("CurrentLanguage", BaseSystemInfo.CurrentLanguage);

            // 数据库连接
            SetValue("DbType", CurrentDbType.SqlServer.ToString());
            SetValue("RegisterKey", "Hairihan TECH");
        }
        #endregion

        #region public static void GetConfig() 读取注册表信息
        /// <summary>
        /// 读取注册表信息
        /// 获取系统配置信息，在系统的原头解决问题，呵呵不错
        /// </summary>
        public static void GetConfig()
        {
            // 读取注册表信息
            // string subKey = "Software\\" + BaseConfiguration.COMPANY_NAME;
            if (!Exists("Software", "Hairihan TECH"))
            {
                // 设置注册表
                SetValues();
            }
            else
            {
                if (!Exists(BaseSystemInfo.SoftName))
                {
                    // 设置注册表
                    SetValues();
                }
            }
            // 检测是否已经有数据了，若已经有数据了，就不进行读取了。
            if (BaseSystemInfo.SoftName.Length == 0)
            {
                GetValues();
            }
        }
        #endregion
    }
}