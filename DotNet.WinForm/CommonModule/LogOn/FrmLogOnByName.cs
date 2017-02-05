//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.ServiceModel;
using System.Windows.Forms;
using System.Reflection;

namespace DotNet.WinForm
{    
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FrmLogOn
    /// 用户登录系统
    /// 
    /// 修改纪录
    /// 
    ///     2011.10.24 版本：2.4 JiRiGaLa 系统配置后，本页面的数据可以更新。
    ///     2011.10.01 版本：2.3 Pcsky    修改成窗体显示软件名称+版本号。
    ///		2011.09.28 版本：2.2 JiRiGaLa WCF连接问题解决。
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
    ///		<date>2011.10.24</date>
    /// </author> 
    /// </summary>
    public partial class FrmLogOnByName:BaseForm 
    {
        /// <summary>
        /// 已登录次数
        /// </summary>
        private int LogOnCount = 0;

        public FrmLogOnByName()
        {
            //this.ShowDialogOnly = true;
            InitializeComponent();
        }

        #region public override void SetHelp() 设置帮助
        /// <summary>
        /// 设置帮助
        /// </summary>
        public override void SetHelp()
        {
            this.HelpButton = true;
            // 修改成窗体显示软件名称+版本号
            Assembly assembly = Assembly.Load(BaseSystemInfo.MainAssembly);
            // 程序集名
            this.Text = BaseSystemInfo.SoftFullName + " V" + assembly.GetName().Version.ToString();
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            if (BaseSystemInfo.UserIsLogOn)
            {
                this.Text = AppMessage.MSGReLogOn;
            }
            // 是否允许申请密码
            this.btnRequestAnAccount.Visible = BaseSystemInfo.AllowUserRegister;
            // 密码强度检查
            this.labPasswordReq.Visible = BaseSystemInfo.CheckPasswordStrength;
            // 已登录了？还是未登录状态
            if (BaseSystemInfo.UserIsLogOn)
            {
                this.CancelButton = this.btnCancel;
                this.btnCancel.Show();
                this.btnExit.Hide();
            }
            else
            {
                this.CancelButton = this.btnExit;
                this.btnExit.Show();
                this.btnCancel.Hide();
            }
            this.btnConfig.Visible = UserConfigHelper.Exists();
        }
        #endregion

        #region private void GetLogOnInfo() 获取现有的登录信息
        /// <summary>
        /// 获取现有的登录信息
        /// </summary>
        private void GetLogOnInfo()
        {
            if (this.chkRememberPassword.Checked)
            {
                this.txtUser.Text = BaseSystemInfo.CurrentUserName;

                // 对密码进行解密操作
                string password = BaseSystemInfo.CurrentPassword;
                if (BaseSystemInfo.ClientEncryptPassword)
                {
                    password = SecretUtil.Decrypt(password);
                }
                this.txtPassword.Text = password;
                
                // 写入注册表信息，这个往往是会遇到安全问题，出现异常等
                /*
                RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(@"Software\" + BaseConfiguration.COMPANY_NAME + "\\" + BaseSystemInfo.SoftName, false);
                if (registryKey != null)
                {
                    // 这里是保存用户名的读取，对用户名进行解密操作
                    string userName = (string)registryKey.GetValue(BaseConfiguration.CURRENT_USERNAME);
                    userName = SecretUtil.Decrypt(userName);
                    DataRowView dataRowView = null;
                    for (int i = 0; i < this.cmbUser.Items.Count; i++)
                    {
                        dataRowView = (DataRowView)this.cmbUser.Items[i];
                        if (dataRowView[BaseUserEntity.FieldUserName].ToString().Equals(userName))
                        {
                            this.cmbUser.SelectedIndex = i;
                            // this.cmbUser.SelectedItem = this.cmbUser.Items[i];
                            // this.cmbUser.SelectedValue = userName;
                            break;
                        }
                    }
                    // 对密码进行解密操作
                    string password = (string)registryKey.GetValue(BaseConfiguration.CURRENT_PASSWORD);
                    password = SecretUtil.Decrypt(password);
                    this.txtPassword.Text = password;
                }
                */
            }
            this.chbAutoLogOn.Checked = BaseSystemInfo.AutoLogOn;
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 这里是按员工登录
            // this.DTUser = DotNetService.Instance.LogOnService.GetStaffDT(UserInfo);
            // 这里是按用户登录
            // this.DTUser = DotNetService.Instance.LogOnService.GetUserDT(UserInfo);
            
            // 员工需要按用户名排序问题解决
            // this.DTUser.DefaultView.Sort = BaseUserEntity.FieldSortCode;
            // 解决用户名密码记不住的问题
            // foreach (DataRowView dataRowView in this.DTUser.DefaultView)
            // {
            //     this.cmbUser.Items.Add(dataRowView[BaseUserEntity.FieldUserName].ToString(//));
            // }
            // 显示用户真实姓名，保存用户名
            // this.txtUser.DataSource = this.DTUser.DefaultView;
            // this.txtUser.DisplayMember = BaseUserEntity.FieldRealName;
            // this.txtUser.ValueMember = BaseUserEntity.FieldUserName;

            // 保存密码
            this.HelpButton = false;
            this.chkRememberPassword.Checked = BaseSystemInfo.RememberPassword; 
            // 获取现有的登录信息
            this.GetLogOnInfo();
            // 默认焦点在用户名输入上
            this.txtUser.Focus();
            
            // 当前的输入焦点停留在密码编辑框上，呵呵不错的改进。
            if (this.txtUser.Text.Length > 0)
            {
                this.ActiveControl = this.txtPassword;
                this.txtPassword.Focus();
            }
        }
        #endregion

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        public override bool CheckInput()
        {
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
                if (this.txtPassword.Text.Length == 0)
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9964), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtPassword.Focus();
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region private bool CheckAllowLogOnCount() 允许登录次数已经到了
        /// <summary>
        /// 允许登录次数已经到了
        /// </summary>
        /// <returns>继续允许输入</returns>
        private bool CheckAllowLogOnCount()
        {
            if (this.LogOnCount >=  BaseSystemInfo.PasswordErrowLockLimit)
            {
                // 控件重新设置状态
                this.txtPassword.Clear();
                this.txtUser.Enabled = false;
                this.txtPassword.Enabled = false;
                this.btnConfirm.Enabled = false;
                // 若是强类型的密码管理
                if (BaseSystemInfo.CheckPasswordStrength)
                {
                    // 防止被黑客攻击，帐户被锁定 15分钟后才可以用
                    string userName = this.txtUser.Text;
                    DotNetService dotNetService = new DotNetService();
                    dotNetService.LogOnService.LockUser(UserInfo, userName);
                    if (dotNetService.LogOnService is ICommunicationObject)
                    {
                        ((ICommunicationObject)dotNetService.LogOnService).Close();
                    }
                    // 提示帐户被锁定
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0400, BaseSystemInfo.LockUserPasswordError.ToString()), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    // 进行提示信息，不能再输入了，已经错误N次了。
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0211, BaseSystemInfo.PasswordErrowLockLimit.ToString()), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                return false;
            }
            return true;
        }
        #endregion

        #region private bool LogOn()
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns>是否成功</returns>
        private bool LogOn()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            try
            {
                string userName = this.txtUser.Text;

                DotNetService dotNetService = new DotNetService();
                BaseUserInfo userInfo = dotNetService.LogOnService.UserLogOn(UserInfo, userName, this.txtPassword.Text, true, out statusCode, out statusMessage);
                if (dotNetService.LogOnService is ICommunicationObject)
                {
                    ((ICommunicationObject)dotNetService.LogOnService).Close();
                }
                if (statusCode == StatusCode.OK.ToString())
                {
                    // 检查身份
                    if ((userInfo != null) && (userInfo.Id.Length > 0))
                    {
                        // 用户登录，保存登录信息
                        BaseSystemInfo.UserInfo = userInfo;
                        // 保存登录信息
                        this.SaveLogOnInfo(userInfo);
                        // 这里表示已经登录系统了
                        BaseSystemInfo.UserIsLogOn = true;
                        // 这里是登录功能部分
                        if (this.Parent == null)
                        {
                            this.Hide();
                            Form mainForm = this.Owner;
                            if (mainForm is IBaseMainForm)
                            {
                                // 这里不允许重复初始化服务
                                // ((IBaseMainForm)mainForm).InitService();
                                ((IBaseMainForm)mainForm).InitForm();
                                ((IBaseMainForm)mainForm).CheckMenu();
                                mainForm.Show();
                            }
                        }
                        // 登录次数归零，允许重新登录
                        this.LogOnCount = 0;
                        // 密码强度检查
                        // 周期性更换密码要求,一个月更换一次密码,30天
                        if (BaseSystemInfo.CheckPasswordStrength)
                        {
                            bool chanagePassword = false;
                            string message = string.Empty;
                            BaseUserEntity userEntity = dotNetService.UserService.GetEntity(userInfo, userInfo.Id);
                            if (dotNetService.UserService is ICommunicationObject)
                            {
                                ((ICommunicationObject)dotNetService.UserService).Close();
                            }
                            if (userEntity.ChangePasswordDate == null)
                            {
                                message = AppMessage.MSG0062;
                                chanagePassword = true;
                            }
                            else
                            {
                                TimeSpan ts = ((DateTime)userEntity.ChangePasswordDate).Subtract(DateTime.Now);
                                if (ts.TotalDays > 30)
                                {
                                    message = AppMessage.MSG0063;
                                    chanagePassword = true;
                                }
                            }
                            if (chanagePassword)
                            {
                                string assemblyName = "DotNet.WinForm";
                                string formName = "FrmUserChangePassword";
                                Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
                                Form frmUserChangePassword = (Form)Activator.CreateInstance(assemblyType, message);
                                frmUserChangePassword.ShowDialog(this);
                            }
                        }
                    }
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    // 已经登录次数 ++
                    this.LogOnCount++;

                    // 消息提醒    
                    MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtPassword.Focus();
                    this.txtPassword.SelectAll();
                    return false;
                }
            }
            catch (Exception ex)
            {
                this.ProcessException(ex);
            }
            finally
            {
                // 已经忙完了
                this.Cursor = holdCursor;
            }
            return true;
        }
        #endregion	

        #region private void SaveLogOnInfo(BaseUserInfo userInfo) 将登录信息保存到XML文件中
        /// <summary>
        /// 将登录信息保存到XML文件中。
        /// 若不保存用户名密码，那就应该删除掉。
        /// </summary>
        /// <param name="userInfo">登录用户</param>
        private void SaveLogOnInfo(BaseUserInfo userInfo)
        {
            BaseSystemInfo.RememberPassword = this.chkRememberPassword.Checked;
            if (this.chkRememberPassword.Checked)
            {
                BaseSystemInfo.CurrentUserName = userInfo.UserName;
                // BaseSystemInfo.CurrentUserName = SecretUtil.Encrypt(userInfo.UserName);
                if (BaseSystemInfo.ClientEncryptPassword)
                {
                    BaseSystemInfo.CurrentPassword = SecretUtil.Encrypt(this.txtPassword.Text);
                }
                else
                {
                    BaseSystemInfo.CurrentPassword = this.txtPassword.Text;
                }
            }
            else
            {
                BaseSystemInfo.CurrentUserName = string.Empty;
                BaseSystemInfo.CurrentPassword = string.Empty;
            }
            BaseSystemInfo.AutoLogOn = this.chbAutoLogOn.Checked;

            // 保存用户的信息
            #if (!DEBUG)
                UserConfigHelper.SaveConfig();
            #endif
            
            /*
            // 写入注册表，有时候会没有权限，发生异常信息等，可以考虑写入XML文件
            RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(@"Software\" + BaseConfiguration.COMPANY_NAME + "\\" + BaseSystemInfo.SoftName);
            if (this.chkRememberPassword.Checked)
            {
                // 默认的信息写入注册表,呵呵需要改进一下
                registryKey.SetValue(BaseConfiguration.CURRENT_USERNAME, SecretUtil.Encrypt(userInfo.UserName));
                registryKey.SetValue(BaseConfiguration.CURRENT_PASSWORD, SecretUtil.Encrypt(this.txtPassword.Text));
            }
            else
            {
                registryKey.SetValue(BaseConfiguration.CURRENT_USERNAME, string.Empty);
                registryKey.SetValue(BaseConfiguration.CURRENT_PASSWORD, string.Empty);
            }
            */
        }
        #endregion

        private void txtPassword_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                // 检查输入的有效性
                if (this.CheckInput())
                {
                    // 用户登录
                    this.LogOn();
                }
            }
        }


        private void FrmLogOnByName_DoubleClick(object sender, EventArgs e)
        {
            #if (DEBUG)
                this.txtUser.Text = "Administrator";
                this.txtPassword.Text = "Administrator";           
            #endif
        }

        private void btnRequestAnAccount_Click(object sender, EventArgs e)
        {
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmRequestAnAccount";
            Form frmRequestAnAccount = CacheManager.Instance.GetForm(assemblyName, formName);
            if (frmRequestAnAccount.ShowDialog() == DialogResult.OK)
            {
                // 不能老申请帐户吧，当作攻击的一种类型
                this.btnRequestAnAccount.Enabled = false;
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            FrmConfig frmConfig = new FrmConfig();
            if (frmConfig.ShowDialog(this) == DialogResult.OK)
            {
                this.FormOnLoad();
            }
        }

        private void ConfirmLogOn()
        {
            // 验证用户输入
            if (this.CheckInput())
            {
                // 用户登录
                this.LogOn();
                // 允许登录次数已经到了
                this.CheckAllowLogOnCount();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.ConfirmLogOn();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // 退出应用程序
            Application.Exit();
        }

        private void FrmLogOnByName_Load(object sender, EventArgs e)
        {
            // 这里判断自动登录
            if (!BaseSystemInfo.UserIsLogOn && BaseSystemInfo.AutoLogOn)
            {
                this.ConfirmLogOn();
                if (BaseSystemInfo.UserIsLogOn)
                {
                    this.Close();
                }
            }
        }

        private void FrmLogOnByName_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 若没登录，直接关闭了，就需要退出了
            if (!BaseSystemInfo.UserIsLogOn)
            {
                Application.Exit();
            }
        }
    }
}