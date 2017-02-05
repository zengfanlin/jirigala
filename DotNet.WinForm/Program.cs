//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.IO;
using System.ServiceModel;
using System.Windows.Forms;
using System.Configuration;
// using System.Security.Principal;

namespace DotNet.WinForm
{
    using DotNet.Utilities;
    using DotNet.Business;

    /// <summary>
    /// Program
    /// 
    /// 修改纪录
    ///
    ///		2011.07.15 版本：2.0 JiRiGaLa 创建。
    ///		2007.10.25 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：2.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.07.15</date>
    /// </author> 
    /// </summary>
    static class Program
    {
        /// <summary>
        /// 即时通讯
        /// </summary>
        public static FrmMessage frmMessage = null;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // System.Console.WriteLine(WindowsIdentity.GetCurrent().Name);

            // 主应用程序集名
            BaseSystemInfo.MainAssembly = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
            BaseSystemInfo.StartupPath = Application.StartupPath;
            BaseSystemInfo.AppIco = Path.Combine(Application.StartupPath, "Resource/Form.ico");

            // PermissionItemService permissionItemService = new Business.PermissionItemService();
            // BasePermissionItemEntity permissionItemEntity = permissionItemService.GetEntityByCode(BaseSystemInfo.UserInfo, "UserAdmin");
            // System.Console.WriteLine(permissionItemEntity);
            
            // 获取配置信息
            GetConfig();
            // 强制使用表数据权限
            // BaseSystemInfo.UseTablePermission = true;
            BaseSystemInfo.WebHostUrl = ConfigurationManager.AppSettings["WebHostUrl"];

            // 这里检查是否有外部用户名密码传输进来过
            if (args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i].ToString().StartsWith("UserName"))
                    {
                        BaseSystemInfo.CurrentUserName = args[i].ToString().Substring("UserName".Length + 1);
                    }
                    else if (args[i].ToString().StartsWith("Password"))
                    {
                        BaseSystemInfo.CurrentPassword = args[i].ToString().Substring("Password".Length + 1);
                        if (BaseSystemInfo.ClientEncryptPassword)
                        {
                            BaseSystemInfo.CurrentPassword = SecretUtil.Encrypt(BaseSystemInfo.CurrentPassword);
                        }
                    }
                    // Console.WriteLine(i.ToString() + ":" + args[i].ToString());
                }
            }

            if (BaseSystemInfo.MultiLanguage)
            {
                // 多语言国际化加载
                ResourceManagerWrapper.Instance.LoadResources(Path.Combine(Application.StartupPath, "Resources/Localization/"));
                // 从当前指定的语言包读取信息
                AppMessage.GetLanguageResource();
            }

            // 初始化服务
            DotNetService.Instance.InitService();

            // 按配置的登录页面进行登录，这里需要运行的是主程序才可以
            Form mainForm = BaseInterfaceLogic.GetForm(BaseSystemInfo.MainAssembly, BaseSystemInfo.MainForm);
            Application.Run(mainForm);
        }

        /// <summary>
        /// 获取配置信息
        /// </summary>
        public static void GetConfig()
        {
            // 读取客户端配置文件
            BaseSystemInfo.ConfigurationFrom = ConfigurationCategory.UserConfig;
            UserConfigHelper.GetConfig();

            // 这里应该读取服务上的配置信息，不只是读取本地的配置信息
            /*
            DotNetService dotNetService = new DotNetService();
            string allowUserRegister = dotNetService.ParameterService.GetServiceConfig(BaseSystemInfo.UserInfo, "AllowUserRegister");
            BaseSystemInfo.AllowUserRegister = allowUserRegister.Equals(false.ToString()) ? false : true;
            // 密码强度检查
            string checkPasswordStrength = dotNetService.ParameterService.GetServiceConfig(BaseSystemInfo.UserInfo, "CheckPasswordStrength");
            BaseSystemInfo.CheckPasswordStrength = checkPasswordStrength.Equals(false.ToString()) ? false : true;
            string useColumnPermission = dotNetService.ParameterService.GetServiceConfig(BaseSystemInfo.UserInfo, "UseColumnPermission");
            BaseSystemInfo.UseColumnPermission = useColumnPermission.Equals(true.ToString()) ? true : false;
            string useModulePermission = dotNetService.ParameterService.GetServiceConfig(BaseSystemInfo.UserInfo, "UseModulePermission");
            BaseSystemInfo.UseModulePermission = useModulePermission.Equals(true.ToString()) ? true : false;
            string usePermissionScope = dotNetService.ParameterService.GetServiceConfig(BaseSystemInfo.UserInfo, "UsePermissionScope");
            BaseSystemInfo.UsePermissionScope = usePermissionScope.Equals(true.ToString()) ? true : false;
            string useTablePermission = dotNetService.ParameterService.GetServiceConfig(BaseSystemInfo.UserInfo, "UseTablePermission");
            BaseSystemInfo.UseTablePermission = useTablePermission.Equals(true.ToString()) ? true : false;
            if (dotNetService.ParameterService is ICommunicationObject)
            {
                ((ICommunicationObject)dotNetService.ParameterService).Close();
            }
            */
        }

        #region public static void InitService(BaseUserInfo userInfo) 加载服务
        /// <summary>
        /// 多线程加载服务
        /// </summary>
        public static void InitService(BaseUserInfo userInfo)
        {
            // 加载内部部门
            ClientCache.Instance.DTOrganize = null;
            DotNetService.Instance.InitService();
            ClientCache.Instance.GetOrganizeDT(userInfo);
        }
        #endregion

        /// <summary>
        /// 测试远程调用服务
        /// </summary>
        public static void TestService()
        {
            System.Console.WriteLine("用户中心数据库服务器 数据库连接：");
            System.Console.WriteLine(DotNetService.Instance.UserCenterDbHelperService.ExecuteScalar(BaseSystemInfo.UserInfo, "SELECT GETDATE()").ToString());
            System.Console.WriteLine();

            System.Console.WriteLine("业务中心数据库服务器 数据库连接：");
            System.Console.WriteLine(DotNetService.Instance.BusinessDbHelperService.ExecuteScalar(BaseSystemInfo.UserInfo, "SELECT GETDATE()").ToString());
        }
    }
}