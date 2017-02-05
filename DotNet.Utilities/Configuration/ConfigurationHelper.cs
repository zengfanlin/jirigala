//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Configuration;
using System.Globalization;

namespace DotNet.Utilities
{
    /// <summary>
    /// ConfigurationHelper
    /// 连接配置。
    /// 
    /// 修改纪录
    /// 
    ///     2011.07.05 版本：1.1 zgl 增加  BaseSystemInfo.CheckIPAddress 
    ///		2008.06.08 版本：1.0 JiRiGaLa 将程序从 BaseConfiguration 进行了分离。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.06.08</date>
    /// </author> 
    /// </summary>
    public class ConfigurationHelper
    {
        #region public static void GetConfig()
        /// <summary>
        /// 从配置信息获取配置信息
        /// </summary>
        /// <param name="configuration">配置</param>
        public static void GetConfig()
        {
            // 读取注册码
            BaseSystemInfo.RegisterKey = ConfigurationManager.AppSettings["RegisterKey"];

            // 客户信息配置
            if (ConfigurationManager.AppSettings["CustomerCompanyName"] != null)
            {
                BaseSystemInfo.CustomerCompanyName = ConfigurationManager.AppSettings["CustomerCompanyName"];
            }
            if (ConfigurationManager.AppSettings["ConfigurationFrom"] != null)
            {
                BaseSystemInfo.ConfigurationFrom = BaseConfiguration.GetConfiguration(ConfigurationManager.AppSettings["ConfigurationFrom"]);
            }
            if (ConfigurationManager.AppSettings["SoftName"] != null)
            {
                BaseSystemInfo.SoftName = ConfigurationManager.AppSettings["SoftName"];
            }
            if (ConfigurationManager.AppSettings["SoftFullName"] != null)
            {
                BaseSystemInfo.SoftFullName = ConfigurationManager.AppSettings["SoftFullName"];
            }
            if (ConfigurationManager.AppSettings["SystemCode"] != null)
            {
                BaseSystemInfo.SystemCode = ConfigurationManager.AppSettings["SystemCode"];
            }
            if (ConfigurationManager.AppSettings["RootMenuCode"] != null)
            {
                BaseSystemInfo.RootMenuCode = ConfigurationManager.AppSettings["RootMenuCode"];
            }
            if (ConfigurationManager.AppSettings["ServiceUserName"] != null)
            {
                BaseSystemInfo.ServiceUserName = ConfigurationManager.AppSettings["ServiceUserName"];
            }
            if (ConfigurationManager.AppSettings["ServicePassword"] != null)
            {
                BaseSystemInfo.ServicePassword = ConfigurationManager.AppSettings["ServicePassword"];
            }
            // BaseSystemInfo.CurrentLanguage = ConfigurationManager.AppSettings[BaseConfiguration.CURRENT_LANGUAGE];
            // BaseSystemInfo.Version = ConfigurationManager.AppSettings[BaseConfiguration.VERSION];

            // BaseSystemInfo.UseModulePermission = (ConfigurationManager.AppSettings[BaseConfiguration.USE_MODULE_PERMISSION].ToUpper(), true.ToString().ToUpper(), true);
            // BaseSystemInfo.UsePermissionScope = (ConfigurationManager.AppSettings[BaseConfiguration.USE_PERMISSIONS_COPE].ToUpper(), true.ToString().ToUpper(), true);
            // BaseSystemInfo.UseTablePermission = (ConfigurationManager.AppSettings[BaseConfiguration.USE_TABLE_PERMISSION].ToUpper(), true.ToString().ToUpper(), true);

            // BaseSystemInfo.Service = ConfigurationManager.AppSettings[BaseConfiguration.SERVICE];
            // BaseSystemInfo.RecordLog = (ConfigurationManager.AppSettings[BaseConfiguration.RECORD_LOG].ToUpper(), true.ToString().ToUpper(), true);

            if (ConfigurationManager.AppSettings["ServerEncryptPassword"] != null)
            {
                BaseSystemInfo.ServerEncryptPassword = ConfigurationManager.AppSettings["ServerEncryptPassword"].ToUpper().Equals(true.ToString().ToUpper());
            }
            if (ConfigurationManager.AppSettings["ClientEncryptPassword"] != null)
            {
                BaseSystemInfo.ClientEncryptPassword = ConfigurationManager.AppSettings["ClientEncryptPassword"].ToUpper().Equals(true.ToString().ToUpper());
            }
            if (ConfigurationManager.AppSettings["CheckIPAddress"] != null)
            {
                BaseSystemInfo.CheckIPAddress = ConfigurationManager.AppSettings["CheckIPAddress"].ToUpper().Equals(true.ToString().ToUpper());
            }

            // BaseSystemInfo.AutoLogOn = (ConfigurationManager.AppSettings[BaseConfiguration.AUTO_LOGON].ToUpper(), true.ToString().ToUpper(), true);
            // BaseSystemInfo.LogOnAssembly = ConfigurationManager.AppSettings[BaseConfiguration.LOGON_ASSEMBLY];
            // BaseSystemInfo.LogOnForm = ConfigurationManager.AppSettings[BaseConfiguration.LOGON_FORM];
            // BaseSystemInfo.MainForm = ConfigurationManager.AppSettings[BaseConfiguration.MAIN_FORM];

            if (ConfigurationManager.AppSettings["CheckOnLine"] != null)
            {
                BaseSystemInfo.CheckOnLine = ConfigurationManager.AppSettings["CheckOnLine"].ToUpper().Equals(true.ToString().ToUpper());
            }
            // BaseSystemInfo.LoadAllUser = (ConfigurationManager.AppSettings[BaseConfiguration.LOAD_All_USER].ToUpper(), true.ToString().ToUpper(), true);
            // BaseSystemInfo.AllowUserRegister = (ConfigurationManager.AppSettings[BaseConfiguration.ALLOW_USER_REGISTER].ToUpper(), true.ToString().ToUpper(), true); 

            // 数据库连接
            if (ConfigurationManager.AppSettings["UserCenterDbType"] != null)
            {
                BaseSystemInfo.UserCenterDbType = BaseConfiguration.GetDbType(ConfigurationManager.AppSettings["UserCenterDbType"]);
            }
            if (ConfigurationManager.AppSettings["BusinessDbType"] != null)
            {
                BaseSystemInfo.BusinessDbType = BaseConfiguration.GetDbType(ConfigurationManager.AppSettings["BusinessDbType"]);
            }
            if (ConfigurationManager.AppSettings["WorkFlowDbType"] != null)
            {
                BaseSystemInfo.WorkFlowDbType = BaseConfiguration.GetDbType(ConfigurationManager.AppSettings["WorkFlowDbType"]);
            }
            if (ConfigurationManager.AppSettings["EncryptDbConnection"] != null)
            {
                BaseSystemInfo.EncryptDbConnection = ConfigurationManager.AppSettings["EncryptDbConnection"].ToUpper().Equals(true.ToString().ToUpper());
            }
            if (ConfigurationManager.AppSettings["BusinessDbConnection"] != null)
            {
                BaseSystemInfo.BusinessDbConnectionString = ConfigurationManager.AppSettings["BusinessDbConnection"];
            }
            if (ConfigurationManager.AppSettings["UserCenterDbConnection"] != null)
            {
                BaseSystemInfo.UserCenterDbConnectionString = ConfigurationManager.AppSettings["UserCenterDbConnection"];
            }
            if (ConfigurationManager.AppSettings["WorkFlowDbConnection"] != null)
            {
                BaseSystemInfo.WorkFlowDbConnectionString = ConfigurationManager.AppSettings["WorkFlowDbConnection"];
            }
            // 对加密的数据库连接进行解密操作
            if (BaseSystemInfo.EncryptDbConnection)
            {
                BaseSystemInfo.BusinessDbConnection = SecretUtil.Decrypt(BaseSystemInfo.BusinessDbConnectionString);
                BaseSystemInfo.UserCenterDbConnection = SecretUtil.Decrypt(BaseSystemInfo.UserCenterDbConnectionString);
                BaseSystemInfo.WorkFlowDbConnection = SecretUtil.Decrypt(BaseSystemInfo.WorkFlowDbConnectionString);
            }
            else
            {
                BaseSystemInfo.BusinessDbConnection = BaseSystemInfo.BusinessDbConnectionString;
                BaseSystemInfo.UserCenterDbConnection = BaseSystemInfo.UserCenterDbConnectionString;
                BaseSystemInfo.WorkFlowDbConnection = BaseSystemInfo.WorkFlowDbConnectionString;
            }

            // 这里重新给静态数据库连接对象进行赋值
            // DotNet.Utilities.DbHelper.DbConnection = BaseSystemInfo.BusinessDbConnection;
            // DotNet.Utilities.DbHelper.DbType = BaseSystemInfo.BusinessDbType;
        }
        #endregion
    }
}