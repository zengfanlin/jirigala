//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.ServiceModel;
using System.Windows.Forms;

namespace DotNet.WinForm.LogOn
{
    
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FrmLogOnByCertificates
    /// 用户登录系统
    /// 
    /// 修改纪录
    /// 
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
    /// 版本：2.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.10.17</date>
    /// </author> 
    /// </summary>
    public partial class FrmLogOnByCertificates : BaseForm
    {
        /// <summary>
        /// 允许错误登录次数
        /// </summary>
        private int AllowLogOnCount = 3; 

        /// <summary>
        /// 已登录次数
        /// </summary>
        private int LogOnCount = 0;

        public FrmLogOnByCertificates()
        {
            this.ShowDialogOnly = true;
            InitializeComponent();
        }

        #region public override void SetHelp() 设置帮助
        /// <summary>
        /// 设置帮助
        /// </summary>
        public override void SetHelp()
        {
            this.HelpButton = true;
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

                this.ActiveControl = this.txtVerifyCode;
                this.txtVerifyCode.Focus();
            }
        }
        #endregion

        /// <summary>
        /// 显示验证码
        /// </summary>
        /// <returns>验证码</returns>
        private void GetVerifyCode()
        {
            VerifyCodeImage verifyCodeImage = new VerifyCodeImage();
            // 取随机码
            string code = verifyCodeImage.CreateVerifyCode().ToUpper();
            // 输出图片
            this.picVerifyCode.Image = verifyCodeImage.CreateImage(code, 3);
            this.picVerifyCode.Tag = code;
        }
   
        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 保存密码
            this.chkRememberPassword.Checked = BaseSystemInfo.RememberPassword; 
            // 获取现有的登录信息
            this.GetLogOnInfo();
            // 显示验证码
            this.GetVerifyCode();
            // 默认焦点在用户名输入上
            this.txtUser.Focus();
            // 当前的输入焦点停留在密码编辑框上，呵呵不错的改进。
            if (this.txtUser.Text.Length > 0 && this.txtPassword.Text.Length == 0)
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

            // 交验验证码
            if (this.txtVerifyCode.Text.Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSGS965), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtVerifyCode.Focus();
                return false;
            }

            if (!this.txtVerifyCode.Text.ToUpper().Equals(this.picVerifyCode.Tag.ToString()))
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG2000, AppMessage.MSGS965), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtVerifyCode.SelectAll();
                this.txtVerifyCode.Focus();
                return false;
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
            if (this.LogOnCount >= this.AllowLogOnCount)
            {
                // 控件重新设置状态
                this.txtPassword.Clear();
                this.txtUser.Enabled = false;
                this.txtPassword.Enabled = false;
                this.btnConfirm.Enabled = false;

                // 进行提示信息，不能再输入了，已经错误N次了。
			     MessageBox.Show(AppMessage.Format(AppMessage.MSG0211, this.AllowLogOnCount.ToString()), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
            // 已经登录次数 ++
            this.LogOnCount++;
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
                            // 这里不允许重复初始化服务
                            // ((IBaseMainForm)mainForm).InitService();
                            ((IBaseMainForm)mainForm).InitForm();
                            ((IBaseMainForm)mainForm).CheckMenu();
                            mainForm.Show();
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
                                string assemblyName = "DotNet.WinForm.User";
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
            // 保存用户的信息
            UserConfigHelper.SaveConfig();
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

        private void btnConfig_Click(object sender, EventArgs e)
        {
            FrmConfig frmConfig = new FrmConfig();
            frmConfig.ShowDialog(this);
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

        private void picVerifyCode_DoubleClick(object sender, EventArgs e)
        {
            this.GetVerifyCode();
            // this.txtVerifyCode.Clear();
            this.txtVerifyCode.SelectAll();
            this.txtVerifyCode.Focus();
        }

        private void FrmLogOnByName_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 若没登录，直接关闭了，就需要退出了
            if (!BaseSystemInfo.UserIsLogOn)
            {
                Application.Exit();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // 退出应用程序
            Application.Exit();
        }
    }
}