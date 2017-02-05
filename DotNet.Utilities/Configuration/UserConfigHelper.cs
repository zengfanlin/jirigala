//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace DotNet.Utilities
{
    /// <summary>
    /// UserConfigHelper
    /// 访问用户配置文件的类
    /// 
    /// 修改纪录
    ///     2011.07.06 版本：1.4 zgl      增加对 CheckIPAddress 的操作
    ///		2008.06.08 版本：1.3 JiRiGaLa 命名修改为 ConfigHelper。
    ///		2008.04.22 版本：1.2 JiRiGaLa 从指定的文件读取配置项。
    ///		2007.07.31 版本：1.1 JiRiGaLa 规范化 FielName 变量。
    ///		2007.04.14 版本：1.0 JiRiGaLa 专门读取注册表的类，主键书写格式改进。
    ///		
    ///	版本：1.2
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.04.22</date>
    /// </author> 
    /// </summary>
    public class UserConfigHelper
    {
        public static string LogOnTo = "Config";

        public static string FileName
        {
            get
            {
                return LogOnTo + ".xml";
            }
        }

        public static string SelectPath = "//appSettings/add";

        public static string ConfigFielName
        {
            get
            {
                return FileName;
                // return Application.StartupPath + "\\" + FielName;
            }
        }

        #region public static Dictionary<String, String> GetLogOnTo() 获取配置文件选项
        /// <summary>
        /// 获取配置文件选项
        /// </summary>
        /// <returns>配置文件设置</returns>
        public static Dictionary<String, String> GetLogOnTo()
        {
            Dictionary<String, String> returnValue = new Dictionary<String, String>();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(ConfigFielName);
            XmlNodeList xmlNodeList = xmlDocument.SelectNodes(SelectPath);
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                if (xmlNode.Attributes["key"].Value.ToUpper().Equals("LogOnTo".ToUpper()))
                {
                    returnValue.Add(xmlNode.Attributes["value"].Value, xmlNode.Attributes["dispaly"].Value);
                }
            }
            return returnValue;
        }
        #endregion      

        public static bool Exists(string key)
        {
            return !string.IsNullOrEmpty(GetValue(key));
        }

        public static string[] GetOptions(string key)
        {
            string option = string.Empty;
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(ConfigFielName);
            option = GetOption(xmlDocument, SelectPath, key);
            return option.Split(',');
        }

        #region public static string GetOption(XmlDocument xmlDocument, string selectPath, string key) 设置配置项
        /// <summary>
        /// 读取配置项
        /// </summary>
        /// <param name="xmlDocument">配置文件</param>
        /// <param name="selectPath">查询条件</param>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static string GetOption(XmlDocument xmlDocument, string selectPath, string key)
        {
            string returnValue = string.Empty;
            XmlNodeList xmlNodeList = xmlDocument.SelectNodes(selectPath);
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                if (xmlNode.Attributes["key"].Value.ToUpper().Equals(key.ToUpper()))
                {
                    if (xmlNode.Attributes["Options"] != null)
                    {
                        returnValue = xmlNode.Attributes["Options"].Value;
                        break;
                    }
                }
            }
            return returnValue;
        }
        #endregion

        #region public static string GetValue(string key) 读取配置项
        /// <summary>
        /// 读取配置项
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static string GetValue(string key)
        {
            return GetValue(ConfigFielName, SelectPath, key);
        }
        #endregion

        #region public static string GetValue(string fileName, string key) 读取配置项
        /// <summary>
        /// 读取配置项
        /// </summary>
        /// <param name="fileName">配置文件</param>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static string GetValue(string fileName, string key)
        {
            return GetValue(fileName, SelectPath, key);
        }
        #endregion

        #region public static string GetValue(string fileName, string selectPath, string key) 设置配置项
        /// <summary>
        /// 读取配置项
        /// </summary>
        /// <param name="fileName">配置文件</param>
        /// <param name="selectPath">查询条件</param>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static string GetValue(string fileName, string selectPath, string key)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            return GetValue(xmlDocument, selectPath, key);
        }
        #endregion

        #region public static string GetValue(XmlDocument xmlDocument, string key) 读取配置项
        /// <summary>
        /// 读取配置项
        /// </summary>
        /// <param name="xmlDocument">配置文件</param>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static string GetValue(XmlDocument xmlDocument, string key)
        {
            return GetValue(xmlDocument, SelectPath, key);
        }
        #endregion

        #region public static string GetValue(XmlDocument xmlDocument, string selectPath, string key) 设置配置项
        /// <summary>
        /// 读取配置项
        /// </summary>
        /// <param name="xmlDocument">配置文件</param>
        /// <param name="selectPath">查询条件</param>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static string GetValue(XmlDocument xmlDocument, string selectPath, string key)
        {
            string returnValue = string.Empty;
            XmlNodeList xmlNodeList = xmlDocument.SelectNodes(selectPath);
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                if (xmlNode.Attributes["key"].Value.ToUpper().Equals(key.ToUpper()))
                {
                    returnValue = xmlNode.Attributes["value"].Value;
                    break;
                }
            }
            return returnValue;
        }
        #endregion

        public static bool Exists()
        {
            bool returnValue = false;
            string fileName = BaseSystemInfo.StartupPath + "//" + ConfigFielName;
            if (System.IO.File.Exists(ConfigFielName))
            {
                returnValue = true;
            }
            return returnValue;
        }

        #region public static void GetConfig() 读取配置文件
        /// <summary>
        /// 读取配置文件
        /// </summary>
        public static void GetConfig()
        {
            if (Exists())
            {
                string fileName = BaseSystemInfo.StartupPath + "//" + ConfigFielName;
                GetConfig(fileName);
            }
        }
        #endregion

        #region public static void GetConfig(string fileName) 从指定的文件读取配置项
        /// <summary>
        /// 从指定的文件读取配置项
        /// </summary>
        /// <param name="fileName">配置文件</param>
        public static void GetConfig(string fileName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            
            // 客户信息配置
            if (Exists("CurrentUserName"))
            {
                BaseSystemInfo.CurrentUserName = GetValue(xmlDocument, "CurrentUserName");
            }
            if (Exists("CurrentPassword"))
            {
                BaseSystemInfo.CurrentPassword = GetValue(xmlDocument, "CurrentPassword");
            }
            if (Exists("MultiLanguage"))
            {
                BaseSystemInfo.MultiLanguage = (String.Compare(GetValue(xmlDocument, "MultiLanguage"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            if (Exists("CurrentLanguage"))
            {
                BaseSystemInfo.CurrentLanguage = GetValue(xmlDocument, "CurrentLanguage");
            }
            if (Exists("RememberPassword"))
            {
                BaseSystemInfo.RememberPassword = (String.Compare(GetValue(xmlDocument, "RememberPassword"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            if (Exists("AutoLogOn"))
            {
                BaseSystemInfo.AutoLogOn = (String.Compare(GetValue(xmlDocument, "AutoLogOn"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            if (Exists("ClientEncryptPassword"))
            {
                BaseSystemInfo.ClientEncryptPassword = (String.Compare(GetValue(xmlDocument, "ClientEncryptPassword"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            if (Exists("ServerEncryptPassword"))
            {
                BaseSystemInfo.ServerEncryptPassword = (String.Compare(GetValue(xmlDocument, "ServerEncryptPassword"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            
            // add by zgl
            if (Exists("CheckIPAddress"))
            {
                BaseSystemInfo.CheckIPAddress = (String.Compare(GetValue(xmlDocument, "CheckIPAddress"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            if (Exists("CheckOnLine"))
            {
                BaseSystemInfo.CheckOnLine = (String.Compare(GetValue(xmlDocument, "CheckOnLine"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            if (Exists("UseMessage"))
            {
                BaseSystemInfo.UseMessage = (String.Compare(GetValue(xmlDocument, "UseMessage"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            if (Exists("AllowUserRegister"))
            {
                BaseSystemInfo.AllowUserRegister = (String.Compare(GetValue(xmlDocument, "AllowUserRegister"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            if (Exists("RecordLog"))
            {
                BaseSystemInfo.RecordLog = (String.Compare(GetValue(xmlDocument, "RecordLog"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }

            BaseSystemInfo.CustomerCompanyName = GetValue(xmlDocument, "CustomerCompanyName");
            BaseSystemInfo.ConfigurationFrom = BaseConfiguration.GetConfiguration(GetValue(xmlDocument, "ConfigurationFrom"));
            BaseSystemInfo.SoftName = GetValue(xmlDocument, "SoftName");
            BaseSystemInfo.SoftFullName = GetValue(xmlDocument, "SoftFullName");

            if (Exists("SystemCode"))
            {
                BaseSystemInfo.SystemCode = GetValue(xmlDocument, "SystemCode");
            }
            if (Exists("RootMenuCode"))
            {
                BaseSystemInfo.RootMenuCode = GetValue(xmlDocument, "RootMenuCode");
            }
            BaseSystemInfo.Version = GetValue(xmlDocument, "Version");

            if (Exists("UseOrganizePermission"))
            {
                BaseSystemInfo.UseOrganizePermission = (String.Compare(GetValue(xmlDocument, "UseOrganizePermission"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            if (Exists("UseUserPermission"))
            {
                BaseSystemInfo.UseUserPermission = (String.Compare(GetValue(xmlDocument, "UseUserPermission"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            if (Exists("UseModulePermission"))
            {
                BaseSystemInfo.UseModulePermission = (String.Compare(GetValue(xmlDocument, "UseModulePermission"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            if (Exists("UsePermissionItem"))
            {
                BaseSystemInfo.UsePermissionItem = (String.Compare(GetValue(xmlDocument, "UsePermissionItem"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            if (Exists("UseTableColumnPermission"))
            {
                BaseSystemInfo.UseTableColumnPermission = (String.Compare(GetValue(xmlDocument, "UseTableColumnPermission"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            if (Exists("UseTableScopePermission"))
            {
                BaseSystemInfo.UseTableScopePermission = (String.Compare(GetValue(xmlDocument, "UseTableScopePermission"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            if (Exists("UsePermissionScope"))
            {
                BaseSystemInfo.UsePermissionScope = (String.Compare(GetValue(xmlDocument, "UsePermissionScope"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            if (Exists("UseAuthorizationScope"))
            {
                BaseSystemInfo.UseAuthorizationScope = (String.Compare(GetValue(xmlDocument, "UseAuthorizationScope"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            if (Exists("HandwrittenSignature"))
            {
                BaseSystemInfo.HandwrittenSignature = (String.Compare(GetValue(xmlDocument, "HandwrittenSignature"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }

            if (Exists("LoadAllUser"))
            {
                BaseSystemInfo.LoadAllUser = (String.Compare(GetValue(xmlDocument, "LoadAllUser"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }

            if (Exists("Service"))
            {
                BaseSystemInfo.Service = GetValue(xmlDocument, "Service");
            }
            if (Exists("LogOnForm"))
            {
                BaseSystemInfo.LogOnForm = GetValue(xmlDocument, "LogOnForm");
            }
            if (Exists("MainForm"))
            {
                BaseSystemInfo.MainForm = GetValue(xmlDocument, "MainForm");
            }

            int.TryParse(GetValue(xmlDocument, "OnLineLimit"), out BaseSystemInfo.OnLineLimit);
            
            // 打开数据库连接
            if (Exists("UserCenterDbType"))
            {
                BaseSystemInfo.UserCenterDbType = BaseConfiguration.GetDbType(GetValue(xmlDocument, "UserCenterDbType"));
            }
            if (Exists("BusinessDbType"))
            {
                BaseSystemInfo.BusinessDbType = BaseConfiguration.GetDbType(GetValue(xmlDocument, "BusinessDbType"));
            }
            if (Exists("WorkFlowDbType"))
            {
                BaseSystemInfo.WorkFlowDbType = BaseConfiguration.GetDbType(GetValue(xmlDocument, "WorkFlowDbType"));
            }
            BaseSystemInfo.EncryptDbConnection = (String.Compare(GetValue(xmlDocument, "EncryptDbConnection"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            BaseSystemInfo.BusinessDbConnectionString = GetValue(xmlDocument, "BusinessDbConnection");
            BaseSystemInfo.WorkFlowDbConnectionString = GetValue(xmlDocument, "WorkFlowDbConnection");
            BaseSystemInfo.UserCenterDbConnectionString = GetValue(xmlDocument, "UserCenterDbConnection");
            if (BaseSystemInfo.EncryptDbConnection)
            {
                BaseSystemInfo.WorkFlowDbConnection = SecretUtil.Decrypt(BaseSystemInfo.WorkFlowDbConnectionString);
                BaseSystemInfo.BusinessDbConnection = SecretUtil.Decrypt(BaseSystemInfo.BusinessDbConnectionString);
                BaseSystemInfo.UserCenterDbConnection = SecretUtil.Decrypt(BaseSystemInfo.UserCenterDbConnectionString);
            }
            else
            {
                BaseSystemInfo.WorkFlowDbConnection = BaseSystemInfo.WorkFlowDbConnectionString;
                BaseSystemInfo.BusinessDbConnection = BaseSystemInfo.BusinessDbConnectionString;
                BaseSystemInfo.UserCenterDbConnection = BaseSystemInfo.UserCenterDbConnectionString;
            }

            if (Exists("ServiceUserName"))
            {
                BaseSystemInfo.ServiceUserName = GetValue(xmlDocument, "ServiceUserName");
            }
            if (Exists("ServicePassword"))
            {
                BaseSystemInfo.ServicePassword = GetValue(xmlDocument, "ServicePassword");
            }
            
            BaseSystemInfo.RegisterKey = GetValue(xmlDocument, "RegisterKey");

            // 错误报告相关
            BaseSystemInfo.ErrorReportTo = GetValue(xmlDocument, "ErrorReportTo");
            BaseSystemInfo.ErrorReportMailUserName = GetValue(xmlDocument, "ErrorReportMailUserName");
            BaseSystemInfo.ErrorReportMailPassword = GetValue(xmlDocument, "ErrorReportMailPassword");
            // BaseSystemInfo.ErrorReportMailPassword = SecretUtil.Encrypt(BaseSystemInfo.ErrorReportMailPassword);
            BaseSystemInfo.ErrorReportMailPassword = SecretUtil.Decrypt(BaseSystemInfo.ErrorReportMailPassword);

            // 这里重新给静态数据库连接对象进行赋值
            // DotNet.Utilities.DbHelper.DbConnection = BaseSystemInfo.BusinessDbConnection;
            // DotNet.Utilities.DbHelper.DbType = BaseSystemInfo.BusinessDbType;
        }
        #endregion

        public static bool SetValue(XmlDocument xmlDocument, string key, string keyValue)
        {
            return SetValue(xmlDocument, SelectPath, key, keyValue);
        }

        public static bool SetValue(XmlDocument xmlDocument, string selectPath, string key, string keyValue)
        {
            bool returnValue = false;
            XmlNodeList xmlNodeList = xmlDocument.SelectNodes(selectPath);
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                if (xmlNode.Attributes["key"].Value.ToUpper().Equals(key.ToUpper()))
                {
                    xmlNode.Attributes["value"].Value = keyValue;
                    returnValue = true;
                    break;
                }
            }
            return returnValue;
        }

        #region public static void SaveConfig() 保存配置文件
        /// <summary>
        /// 保存配置文件
        /// </summary>
        public static void SaveConfig()
        {
            if (System.IO.File.Exists(ConfigFielName))
            {
                SaveConfig(ConfigFielName);
            }
        }
        #endregion

        #region public static void SaveConfig(string fileName) 保存到指定的文件
        /// <summary>
        /// 保存到指定的文件
        /// </summary>
        /// <param name="fileName">配置文件</param>
        public static void SaveConfig(string fileName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);

            SetValue(xmlDocument, "CurrentUserName", BaseSystemInfo.CurrentUserName);
            SetValue(xmlDocument, "CurrentPassword", BaseSystemInfo.CurrentPassword);
            SetValue(xmlDocument, "MultiLanguage", BaseSystemInfo.MultiLanguage.ToString());
            SetValue(xmlDocument, "CurrentLanguage", BaseSystemInfo.CurrentLanguage);
            SetValue(xmlDocument, "RememberPassword", BaseSystemInfo.RememberPassword.ToString());
            SetValue(xmlDocument, "ClientEncryptPassword", BaseSystemInfo.ClientEncryptPassword.ToString());
            SetValue(xmlDocument, "CheckIPAddress", BaseSystemInfo.CheckIPAddress.ToString());//add by zgl

            SetValue(xmlDocument, "ServerEncryptPassword", BaseSystemInfo.ServerEncryptPassword.ToString());
            SetValue(xmlDocument, "PasswordMiniLength", BaseSystemInfo.PasswordMiniLength.ToString());
            SetValue(xmlDocument, "NumericCharacters", BaseSystemInfo.NumericCharacters.ToString());
            SetValue(xmlDocument, "PasswordChangeCycle", BaseSystemInfo.PasswordChangeCycle.ToString());
            SetValue(xmlDocument, "CheckOnLine", BaseSystemInfo.CheckOnLine.ToString());
            SetValue(xmlDocument, "AccountMinimumLength", BaseSystemInfo.AccountMinimumLength.ToString());
            SetValue(xmlDocument, "PasswordErrowLockLimit", BaseSystemInfo.PasswordErrowLockLimit.ToString());
            SetValue(xmlDocument, "PasswordErrowLockCycle", BaseSystemInfo.PasswordErrowLockCycle.ToString());
            
            SetValue(xmlDocument, "UseMessage", BaseSystemInfo.UseMessage.ToString());
            SetValue(xmlDocument, "AutoLogOn", BaseSystemInfo.AutoLogOn.ToString());
            SetValue(xmlDocument, "AllowUserRegister", BaseSystemInfo.AllowUserRegister.ToString());
            SetValue(xmlDocument, "RecordLog", BaseSystemInfo.RecordLog.ToString());

            // 客户信息配置
            SetValue(xmlDocument, "CustomerCompanyName", BaseSystemInfo.CustomerCompanyName);
            SetValue(xmlDocument, "ConfigurationFrom", BaseSystemInfo.ConfigurationFrom.ToString());
            SetValue(xmlDocument, "SoftName", BaseSystemInfo.SoftName);
            SetValue(xmlDocument, "SoftFullName", BaseSystemInfo.SoftFullName);

            SetValue(xmlDocument, "RootMenuCode", BaseSystemInfo.RootMenuCode);
            SetValue(xmlDocument, "Version", BaseSystemInfo.Version);

            SetValue(xmlDocument, "UseUserPermission", BaseSystemInfo.UseUserPermission.ToString());
            SetValue(xmlDocument, "UseAuthorizationScope", BaseSystemInfo.UseAuthorizationScope.ToString());
            SetValue(xmlDocument, "UsePermissionScope", BaseSystemInfo.UsePermissionScope.ToString());
            SetValue(xmlDocument, "UseOrganizePermission", BaseSystemInfo.UseOrganizePermission.ToString());
            SetValue(xmlDocument, "UseModulePermission", BaseSystemInfo.UseModulePermission.ToString());
            SetValue(xmlDocument, "UseTableColumnPermission", BaseSystemInfo.UseTableColumnPermission.ToString());
            SetValue(xmlDocument, "UseTableScopePermission", BaseSystemInfo.UseTableScopePermission.ToString());
            SetValue(xmlDocument, "UseWorkFlow", BaseSystemInfo.UseWorkFlow.ToString());
            SetValue(xmlDocument, "LoadAllUser", BaseSystemInfo.LoadAllUser.ToString());

            SetValue(xmlDocument, "Service", BaseSystemInfo.Service);

            SetValue(xmlDocument, "LogOnForm", BaseSystemInfo.LogOnForm);
            SetValue(xmlDocument, "MainForm", BaseSystemInfo.MainForm);

            SetValue(xmlDocument, "OnLineLimit", BaseSystemInfo.OnLineLimit.ToString());
            SetValue(xmlDocument, "DbType", BaseSystemInfo.BusinessDbType.ToString());
            
            // 保存数据库配置
            SetValue(xmlDocument, "BusinessDbType", BaseSystemInfo.BusinessDbType.ToString());
            SetValue(xmlDocument, "UserCenterDbType", BaseSystemInfo.UserCenterDbType.ToString());
            SetValue(xmlDocument, "WorkFlowDbType", BaseSystemInfo.WorkFlowDbType.ToString());

            SetValue(xmlDocument, "EncryptDbConnection", BaseSystemInfo.EncryptDbConnection.ToString());
            SetValue(xmlDocument, "BusinessDbConnection", BaseSystemInfo.BusinessDbConnectionString);
            SetValue(xmlDocument, "UserCenterDbConnection", BaseSystemInfo.UserCenterDbConnectionString);
            SetValue(xmlDocument, "WorkFlowDbConnection", BaseSystemInfo.WorkFlowDbConnectionString);

            SetValue(xmlDocument, "RegisterKey", BaseSystemInfo.RegisterKey);

            xmlDocument.Save(fileName);
        }
        #endregion
    }
}