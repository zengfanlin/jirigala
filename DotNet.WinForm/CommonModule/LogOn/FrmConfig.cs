//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Utilities;
    using DotNet.Business;

    /// <summary>
    /// FrmConfig
    /// 用户登录系统
    /// 
    /// 修改纪录
    /// 
    ///		2012.01.18 版本：2.4 JiRiGaLa 实现初始化系统的功能。
    ///		2011.10.08 版本：2.3 JiRiGaLa 同时支持多类型数据库。
    ///		2011.05.12 版本：2.2 JiRiGaLa 通讯密码、增加工作流配置。
    ///		2010.10.17 版本：2.1 JiRiGaLa 多次输入错误密码后，要求有提示信息再退出程序。
    ///		2010.09.19 版本：2.0 JiRiGaLa 完善记住密码功能，密码按加密方式保存。
    ///		2010.02.26 版本：1.6 JiRiGaLa 只有内部用户才能登录。
    ///		2009.01.19 版本：1.5 JiRiGaLa SAP登录问题解决。
    ///		2009.01.19 版本：1.4 JiRiGaLa 下拉框为用户的真实姓名问题解决。
    ///		2008.03.21 版本：1.3 JiRiGaLa 用户名密码不能记录的错误进行改进。
    ///		2007.09.17 版本：1.2 JiRiGaLa 窗体上按 ESC 按钮退不出的错误修正。
    ///		2007.08.05 版本：1.1 JiRiGaLa 用户名记录起来，提示信息显示，默认允许登录次数。
    ///		2007.06.12 版本：1.0 JiRiGaLa 整理文件。
    ///		
    /// 版本：2.4
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.01.18</date>
    /// </author> 
    /// </summary>
    public partial class FrmConfig : BaseForm
    {
        public FrmConfig()
        {
            this.ShowDialogOnly = true;
            InitializeComponent();
        }

        #region private void GetConfigInfo() 获取系统配置信息
        /// <summary>
        /// 获取系统配置信息
        /// </summary>
        private void GetConfigInfo()
        {
            // 若没有配置文件
            if (!UserConfigHelper.Exists())
            {
                return;
            }
            this.chkClientEncryptPassword.Checked = BaseSystemInfo.ClientEncryptPassword;
            this.chkClientEncryptPassword.Visible = UserConfigHelper.Exists("ClientEncryptPassword");

            this.txtUser.Text = BaseSystemInfo.CurrentUserName;
            // 对密码进行解密操作
            this.txtClientPassword.Text = BaseSystemInfo.CurrentPassword;
            if (BaseSystemInfo.ClientEncryptPassword)
            {
                this.txtClientPassword.Text = SecretUtil.Decrypt(BaseSystemInfo.CurrentPassword);
            }

            // 初始化语言选项菜单
            // this.cmbCurrentLanguage.Items.Clear();
            // this.cmbCurrentLanguage.Items.Add("zh-CN");
            // this.cmbCurrentLanguage.Items.Add("zh-TW");
            // this.cmbCurrentLanguage.Items.Add("en-US");
            string[] currentLanguageItems = UserConfigHelper.GetOptions("CurrentLanguage");
            for (int i = 0; i < currentLanguageItems.Length; i++)
            {
                this.cmbCurrentLanguage.Items.Add(currentLanguageItems[i]);
            }
            this.cmbCurrentLanguage.SelectedIndex = this.cmbCurrentLanguage.Items.IndexOf(BaseSystemInfo.CurrentLanguage);
            this.lblCurrentLanguage.Visible = UserConfigHelper.Exists("CurrentLanguage");
            this.cmbCurrentLanguage.Visible = UserConfigHelper.Exists("CurrentLanguage");

            // this.cmbService.Items.Clear();
            // this.cmbService.Items.Add("DotNet.Service");
            // this.cmbService.Items.Add("DotNet.WCFClient");
            // this.cmbService.Items.Add("DotNet.RemotingClient");
            string[] servicePathItems = UserConfigHelper.GetOptions("Service");
            for (int i = 0; i < servicePathItems.Length; i++)
            {
                this.cmbService.Items.Add(servicePathItems[i]);
            }
            this.cmbService.SelectedIndex = this.cmbService.Items.IndexOf(BaseSystemInfo.Service);

            this.chkRememberPassword.Checked = BaseSystemInfo.RememberPassword;
            this.chbAutoLogOn.Checked = BaseSystemInfo.AutoLogOn;
            this.chkRecordLog.Checked = BaseSystemInfo.RecordLog;

            // 客户端若没这个配置，那就不读取这个配置了。
            this.chkUseMessage.Visible = UserConfigHelper.Exists("UseMessage");
            this.chkUseMessage.Checked = BaseSystemInfo.UseMessage;

            this.chkAllowUserRegister.Checked = BaseSystemInfo.AllowUserRegister;
            this.txtCustomerCompanyName.Text = BaseSystemInfo.CustomerCompanyName;

            this.txtMainForm.Text = BaseSystemInfo.MainForm;
            this.txtLogOnForm.Text = BaseSystemInfo.LogOnForm;

            this.nupOnLineLimit.Value = BaseSystemInfo.OnLineLimit;

            this.chkUseUserPermission.Checked = BaseSystemInfo.UseUserPermission;
            this.chkUseOrganizePermission.Checked = BaseSystemInfo.UseOrganizePermission;
            this.chkUseModulePermission.Checked = BaseSystemInfo.UseModulePermission;
            this.chkWorkFlow.Visible = UserConfigHelper.Exists("UseWorkFlow");
            this.chkWorkFlow.Checked = BaseSystemInfo.UseWorkFlow;
            
            // 是否隐藏这个配置选项
            this.chkUseOrganizePermission.Visible = UserConfigHelper.Exists("UseOrganizePermission");
            this.chkUsePermissionScope.Visible = UserConfigHelper.Exists("UsePermissionScope");
            this.chkUsePermissionScope.Checked = BaseSystemInfo.UsePermissionScope;
            this.chkUseAuthorizationScope.Visible = UserConfigHelper.Exists("UseAuthorizationScope");
            this.chkUseAuthorizationScope.Checked = BaseSystemInfo.UseAuthorizationScope;
            
            // 是否隐藏这个配置选项
            this.chkUseTableColumnPermission.Visible = UserConfigHelper.Exists("UseTableColumnPermission");
            this.chkUseTableColumnPermission.Checked = BaseSystemInfo.UseTableColumnPermission;

            // 是否隐藏这个配置选项
            this.chkUseTableScopePermission.Visible = UserConfigHelper.Exists("UseTableScopePermission");
            this.chkUseTableScopePermission.Checked = BaseSystemInfo.UseTableScopePermission;

            // 初始化数据库
            // this.cmbDbType.Items.Clear();
            // this.cmbDbType.Items.Add("SqlServer");
            // this.cmbDbType.Items.Add("Oracle");
            // this.cmbDbType.Items.Add("Access");
            // this.cmbDbType.Items.Add("DB2");
            // this.cmbDbType.Items.Add("MySql");       
            // this.cmbDbType.Items.Add("SQLite");
            string[] dataBaseTypeItems = UserConfigHelper.GetOptions("UserCenterDbType");
            for (int i = 0; i < dataBaseTypeItems.Length; i++)
            {
                this.cmbUserCenterDbDbType.Items.Add(dataBaseTypeItems[i]);
            }
            this.cmbUserCenterDbDbType.SelectedIndex = this.cmbUserCenterDbDbType.Items.IndexOf(BaseSystemInfo.UserCenterDbType.ToString());

            dataBaseTypeItems = UserConfigHelper.GetOptions("BusinessDbType");
            for (int i = 0; i < dataBaseTypeItems.Length; i++)
            {
                this.cmbBusinessDbDbType.Items.Add(dataBaseTypeItems[i]);
            }
            this.cmbBusinessDbDbType.SelectedIndex = this.cmbBusinessDbDbType.Items.IndexOf(BaseSystemInfo.BusinessDbType.ToString());

            dataBaseTypeItems = UserConfigHelper.GetOptions("WorkFlowDbType");
            for (int i = 0; i < dataBaseTypeItems.Length; i++)
            {
                this.cmbWorkFlowDbDbType.Items.Add(dataBaseTypeItems[i]);
            }
            this.cmbWorkFlowDbDbType.SelectedIndex = this.cmbWorkFlowDbDbType.Items.IndexOf(BaseSystemInfo.WorkFlowDbType.ToString());

            this.chkEncryptDbConnection.Checked = BaseSystemInfo.EncryptDbConnection;
            this.btnEncrypt.Visible = !BaseSystemInfo.EncryptDbConnection;
            this.txtUserCenterDbConnection.Text = BaseSystemInfo.UserCenterDbConnectionString;
            this.txtBusinessDbConnection.Text = BaseSystemInfo.BusinessDbConnectionString;

            this.txtWorkFlowDbConnection.Text = BaseSystemInfo.WorkFlowDbConnectionString;
            this.lblWorkFlowDbConnection.Visible = UserConfigHelper.Exists() && UserConfigHelper.Exists("WorkFlowDbConnection");
            this.cmbWorkFlowDbDbType.Visible = UserConfigHelper.Exists() && UserConfigHelper.Exists("WorkFlowDbConnection");
            this.txtWorkFlowDbConnection.Visible = UserConfigHelper.Exists() && UserConfigHelper.Exists("WorkFlowDbConnection");
        }
        #endregion

        #region private void SaveConfigInfo() 保存系统设置
        /// <summary>
        /// 保存系统设置
        /// </summary>
        private void SaveConfigInfo()
        {
            // 是否加密先保存好
            BaseSystemInfo.ClientEncryptPassword = this.chkClientEncryptPassword.Checked;
            BaseSystemInfo.CurrentUserName = this.txtUser.Text;
            BaseSystemInfo.CurrentPassword = this.txtClientPassword.Text;
            if (BaseSystemInfo.ClientEncryptPassword)
            {
                BaseSystemInfo.CurrentPassword = SecretUtil.Encrypt(this.txtClientPassword.Text);
            }

            if (!string.IsNullOrEmpty(this.cmbCurrentLanguage.Text))
            {
                BaseSystemInfo.CurrentLanguage = this.cmbCurrentLanguage.SelectedItem.ToString();
            }

            BaseSystemInfo.RememberPassword = this.chkRememberPassword.Checked;
            BaseSystemInfo.AutoLogOn = this.chbAutoLogOn.Checked;
            BaseSystemInfo.UseMessage = this.chkUseMessage.Checked;

            BaseSystemInfo.Service = this.cmbService.SelectedItem.ToString();

            BaseSystemInfo.MainForm = txtMainForm.Text;
            BaseSystemInfo.LogOnForm = this.txtLogOnForm.Text;

            BaseSystemInfo.RecordLog = this.chkRecordLog.Checked;
            BaseSystemInfo.AllowUserRegister = this.chkAllowUserRegister.Checked;

            BaseSystemInfo.UseUserPermission = this.chkUseUserPermission.Checked;
            BaseSystemInfo.UseOrganizePermission = this.chkUseOrganizePermission.Checked;
            BaseSystemInfo.UseModulePermission = this.chkUseModulePermission.Checked;
            BaseSystemInfo.UsePermissionScope = this.chkUsePermissionScope.Checked;
            BaseSystemInfo.UseAuthorizationScope = this.chkUseAuthorizationScope.Checked;
            BaseSystemInfo.UseTableColumnPermission = this.chkUseTableColumnPermission.Checked;
            BaseSystemInfo.UseTableScopePermission = this.chkUseTableScopePermission.Checked;
            BaseSystemInfo.UseWorkFlow = this.chkWorkFlow.Checked;

            BaseSystemInfo.OnLineLimit = (int)this.nupOnLineLimit.Value;
            BaseSystemInfo.CustomerCompanyName = this.txtCustomerCompanyName.Text;

            if (this.cmbUserCenterDbDbType.Text.Length != 0)
            {
                BaseSystemInfo.UserCenterDbType = BaseConfiguration.GetDbType(this.cmbUserCenterDbDbType.SelectedItem.ToString());
            }
            if (this.cmbBusinessDbDbType.Text.Length != 0)
            {
                BaseSystemInfo.BusinessDbType = BaseConfiguration.GetDbType(this.cmbBusinessDbDbType.SelectedItem.ToString());
            }
            if (this.cmbWorkFlowDbDbType.Text.Length != 0)
            {
                BaseSystemInfo.WorkFlowDbType = BaseConfiguration.GetDbType(this.cmbWorkFlowDbDbType.SelectedItem.ToString());
            }
            BaseSystemInfo.EncryptDbConnection = this.chkEncryptDbConnection.Checked;
            BaseSystemInfo.UserCenterDbConnectionString = this.txtUserCenterDbConnection.Text;
            BaseSystemInfo.BusinessDbConnectionString = this.txtBusinessDbConnection.Text;
            BaseSystemInfo.WorkFlowDbConnectionString = this.txtWorkFlowDbConnection.Text;
            // 保存用户的信息
            UserConfigHelper.SaveConfig();
        }
        #endregion

        public override void FormOnLoad()
        {
            // 获取系统配置信息
            this.GetConfigInfo();
        }

        private void nupOnLineLimit_ValueChanged(object sender, EventArgs e)
        {
            this.SetControlState();
        }

        public override void SetControlState()
        {
            if (UserConfigHelper.Exists())
            {
                this.btnConfirm.Enabled = true;
                this.btnEncrypt.Enabled = true;
                this.btnSystemSecurity.Enabled = true;
            }
            // 已经登录了系统，并且是系统管理员才可以做这个服务器端的配置，第一次用时无法配置系统了
            /*
            if (!BaseSystemInfo.LogOned || !this.UserInfo.IsAdministrator)
            {
                this.tcConfirm.TabPages.Remove(tpServer);
            }
            */
            this.btnSystemSecurity.Visible = BaseSystemInfo.UserIsLogOn && BaseSystemInfo.UserInfo.IsAdministrator;
            // 只有系统管理员才可以初始化系统，并却是sqlserver数据库下才运行
            this.btnInitialize.Visible = BaseSystemInfo.UserIsLogOn && BaseSystemInfo.UserInfo.IsAdministrator;
            if (this.btnInitialize.Visible)
            {
                if (BaseSystemInfo.UserCenterDbType == CurrentDbType.SqlServer)
                {
                    string parameter = DotNetService.Instance.ParameterService.GetParameter(UserInfo, "System", "System", "Initialize");
                    if (!string.IsNullOrEmpty(parameter) && parameter.Equals("None"))
                    {
                        this.btnInitialize.Enabled = true;
                    }
                }
            }
        }

        private void cmbCurrentLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                if (!string.IsNullOrEmpty(this.cmbCurrentLanguage.Text))
                {
                    BaseSystemInfo.CurrentLanguage = this.cmbCurrentLanguage.SelectedItem.ToString();
                }
                // 从当前指定的语言包读取信息
                // AppMessage.GetLanguageResource();
                // 重置所有打开窗体的语言
                this.ResetLanguage();
            }
        }

        /// <summary>
        /// 重置所有打开窗体的语言
        /// </summary>
        private void ResetLanguage()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is BaseForm)
                {
                    (form as BaseForm).Localization(form);
                }
            }
        }

        private void btnMainForm_Click(object sender, EventArgs e)
        {
            txtMainForm.Text = ((Button)sender).Name.Substring(3);
        }

        private void btnSystemSecurity_Click(object sender, EventArgs e)
        {
            FrmSystemSecurity frmSystemSecurity = new FrmSystemSecurity();
            frmSystemSecurity.ShowDialog();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            //  如果当前处于未加密状态，则对数据库连接字符窜进行加密操作；
            if (!this.chkEncryptDbConnection.Checked)
            {
                this.chkEncryptDbConnection.Checked = true;
                this.txtUserCenterDbConnection.Text = SecretUtil.Encrypt(this.txtUserCenterDbConnection.Text);
                this.txtBusinessDbConnection.Text = SecretUtil.Encrypt(this.txtBusinessDbConnection.Text);
                this.txtWorkFlowDbConnection.Text = SecretUtil.Encrypt(this.txtWorkFlowDbConnection.Text);
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            // 如果当前处于已加密状态，则对数据库连接字符窜进行解密操作；
            if (this.chkEncryptDbConnection.Checked)
            {
                this.chkEncryptDbConnection.Checked = false;
                this.txtUserCenterDbConnection.Text = SecretUtil.Decrypt(this.txtUserCenterDbConnection.Text);
                this.txtBusinessDbConnection.Text = SecretUtil.Decrypt(this.txtBusinessDbConnection.Text);
                this.txtWorkFlowDbConnection.Text = SecretUtil.Decrypt(this.txtWorkFlowDbConnection.Text);
            }
        }

        private void btnSetUserCenter_Click(object sender, EventArgs e)
        {
            this.txtUserCenterDbConnection.Text = "Data Source=localhost;Initial Catalog=UserCenterV37;Integrated Security=SSPI;";
        }

        private void btnSetBusinessDb_Click(object sender, EventArgs e)
        {
            this.txtBusinessDbConnection.Text = "Data Source=localhost;Initial Catalog=ProjectV37;Integrated Security=SSPI;";
        }

        private void btnSetWorkFlowDb_Click(object sender, EventArgs e)
        {
            this.txtWorkFlowDbConnection.Text = "Data Source=localhost;Initial Catalog=WorkFlowV37;Integrated Security=SSPI;";
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            // 默认按钮放在第2个按钮上，尽量防止误操作。
            if (MessageBox.Show(AppMessage.MSG3000, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                // 按系统的配置信息动态获取数据库连接
                using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
                {
                    try
                    {
                        // 打开数据库连接
                        dbHelper.Open(BaseSystemInfo.UserCenterDbConnection);
                        // 执行存储过程
                        int returnValue = dbHelper.ExecuteNonQuery("SystemInitialize", CommandType.StoredProcedure);
                        // 成功的提示信息
                        MessageBox.Show(AppMessage.MSG3010, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.btnInitialize.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        // 在本地文件中记录系统异常信息
                        this.WriteException(ex);
                        throw ex;
                    }
                    finally
                    {
                        // 关闭数据库库连接
                        dbHelper.Close();
                    }
                }
            }
        }

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        public override bool CheckInput()
        {
            if (this.txtCustomerCompanyName.Text.Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG0286), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtCustomerCompanyName.Focus();
                return false;
            }
            // 是否没有输入用户名
            if (this.txtUser.Text.Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9957), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtUser.Focus();
                return false;
            }
            // 密码强度检查
            if (BaseSystemInfo.CheckPasswordStrength)
            {
                if (this.txtClientPassword.Text.Length == 0)
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9964), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtClientPassword.Focus();
                    return false;
                }
            }

            return true;
        }
        #endregion

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                // 保存系统设置
                this.SaveConfigInfo();
                // 读取配置信息，保存时已经读取了信息了，不用重复读取。
                MessageBox.Show(AppMessage.MSG0011, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}