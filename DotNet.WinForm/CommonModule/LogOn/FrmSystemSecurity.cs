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
    /// FrmSystemSecurity
    /// 用户登录系统
    /// 
    /// 修改纪录
    /// 
    ///		2012.02.12 版本：1.1 JiRiGaLa 功能实现。
    ///		2012.01.19 版本：1.0 JiRiGaLa 整理文件。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.02.12</date>
    /// </author> 
    /// </summary>
    public partial class FrmSystemSecurity : BaseForm
    {
        public FrmSystemSecurity()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 从数据库读取当前配置情况
        /// </summary>
        private void GetParameter()
        {
            string parameter = string.Empty;
            parameter = DotNetService.Instance.ParameterService.GetParameter(this.UserInfo, "System", "SystemSecurity", "ServerEncryptPassword");
            if (!string.IsNullOrEmpty(parameter))
            {
                this.chkServerEncryptPassword.Checked = parameter.Equals(true.ToString());
            }
            parameter = DotNetService.Instance.ParameterService.GetParameter(this.UserInfo, "System", "SystemSecurity", "PasswordMiniLength");
            if (!string.IsNullOrEmpty(parameter))
            {
                this.nudPasswordMiniLength.Value = int.Parse(parameter);
            }
            parameter = DotNetService.Instance.ParameterService.GetParameter(this.UserInfo, "System", "SystemSecurity", "NumericCharacters");
            if (!string.IsNullOrEmpty(parameter))
            {
                this.chkNumericCharacters.Checked = parameter.Equals(true.ToString());
            }
            parameter = DotNetService.Instance.ParameterService.GetParameter(this.UserInfo, "System", "SystemSecurity", "PasswordCycle");
            if (!string.IsNullOrEmpty(parameter))
            {
                this.nudPasswordChangeCycle.Value = int.Parse(parameter);
            }
            parameter = DotNetService.Instance.ParameterService.GetParameter(this.UserInfo, "System", "SystemSecurity", "CheckOnLine");
            if (!string.IsNullOrEmpty(parameter))
            {
                this.chkCheckOnLine.Checked = parameter.Equals(true.ToString());
            }
            parameter = DotNetService.Instance.ParameterService.GetParameter(this.UserInfo, "System", "SystemSecurity", "AccountMinimumLength");
            if (!string.IsNullOrEmpty(parameter))
            {
                this.nudAccountMinimumLength.Value = int.Parse(parameter);
            }
            parameter = DotNetService.Instance.ParameterService.GetParameter(this.UserInfo, "System", "SystemSecurity", "PasswordErrowLockLimit");
            if (!string.IsNullOrEmpty(parameter))
            {
                this.nudPasswordErrowLockLimit.Value = int.Parse(parameter);
            }
            parameter = DotNetService.Instance.ParameterService.GetParameter(this.UserInfo, "System", "SystemSecurity", "PasswordErrowLockCycle");
            if (!string.IsNullOrEmpty(parameter))
            {
                this.nudPasswordErrowLockCycle.Value = int.Parse(parameter);
            }
        }

        /// <summary>
        /// 将设置保存到数据库
        /// </summary>
        private void SaveParameter()
        {
            DotNetService.Instance.ParameterService.SetParameter(this.UserInfo, "System", "SystemSecurity", "ServerEncryptPassword", this.chkServerEncryptPassword.Checked.ToString());
            DotNetService.Instance.ParameterService.SetParameter(this.UserInfo, "System", "SystemSecurity", "PasswordMiniLength", this.nudPasswordMiniLength.Value.ToString());
            DotNetService.Instance.ParameterService.SetParameter(this.UserInfo, "System", "SystemSecurity", "NumericCharacters", this.chkNumericCharacters.Checked.ToString());
            DotNetService.Instance.ParameterService.SetParameter(this.UserInfo, "System", "SystemSecurity", "PasswordCycle", this.nudPasswordChangeCycle.Value.ToString());
            DotNetService.Instance.ParameterService.SetParameter(this.UserInfo, "System", "SystemSecurity", "CheckOnLine", this.chkCheckOnLine.Checked.ToString());
            DotNetService.Instance.ParameterService.SetParameter(this.UserInfo, "System", "SystemSecurity", "AccountMinimumLength", this.nudAccountMinimumLength.Value.ToString());
            DotNetService.Instance.ParameterService.SetParameter(this.UserInfo, "System", "SystemSecurity", "PasswordErrowLockLimit", this.nudPasswordErrowLockLimit.Value.ToString());
            DotNetService.Instance.ParameterService.SetParameter(this.UserInfo, "System", "SystemSecurity", "PasswordErrowLockCycle", this.nudPasswordErrowLockCycle.Value.ToString());
        }

        /// <summary>
        /// 从当前配置文件显示到界面上
        /// </summary>
        private void GetConfig()
        {
            this.chkServerEncryptPassword.Checked = BaseSystemInfo.ServerEncryptPassword;
            this.nudPasswordMiniLength.Value = BaseSystemInfo.PasswordMiniLength;
            this.chkNumericCharacters.Checked = BaseSystemInfo.NumericCharacters;
            this.nudPasswordChangeCycle.Value = BaseSystemInfo.PasswordChangeCycle;
            this.chkCheckOnLine.Checked = BaseSystemInfo.CheckOnLine;
            this.nudAccountMinimumLength.Value = BaseSystemInfo.AccountMinimumLength;
            this.nudPasswordErrowLockLimit.Value = BaseSystemInfo.PasswordErrowLockLimit;
            this.nudPasswordErrowLockCycle.Value = BaseSystemInfo.PasswordErrowLockCycle;
        }

        /// <summary>
        /// 当窗体加载时执行的方法，
        /// 这个方法会自动处理鼠标的忙碌状态等等
        /// </summary>
        public override void FormOnLoad()
        {
            this.GetConfig();
            this.GetParameter();
        }

        /// <summary>
        /// 将配置文件保存到XML文件里
        /// </summary>
        private void SaveConfig()
        {
            BaseSystemInfo.ServerEncryptPassword = this.chkServerEncryptPassword.Checked;
            BaseSystemInfo.PasswordMiniLength = (int)this.nudPasswordMiniLength.Value;
            BaseSystemInfo.NumericCharacters = this.chkNumericCharacters.Checked;
            BaseSystemInfo.PasswordChangeCycle = (int)this.nudPasswordChangeCycle.Value;
            BaseSystemInfo.CheckOnLine = this.chkCheckOnLine.Checked;
            BaseSystemInfo.AccountMinimumLength =  (int)this.nudAccountMinimumLength.Value;
            BaseSystemInfo.PasswordErrowLockLimit = (int)this.nudPasswordErrowLockLimit.Value;
            BaseSystemInfo.PasswordErrowLockCycle = (int)this.nudPasswordErrowLockCycle.Value;

            // 保存用户的信息
            #if (!DEBUG)
                UserConfigHelper.SaveConfig();
            #endif
        }

        /// <summary>
        /// 保存系统设置
        /// </summary>
        private void SaveSystemConfig()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.SaveParameter();
                this.SaveConfig();

                // 是否需要有提示信息？
                if (BaseSystemInfo.ShowInformation)
                {
                    // 批量保存，进行提示
                    MessageBox.Show(AppMessage.MSG0011, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                this.ProcessException(ex);
            }
            finally
            {
                // 设置鼠标默认状态，原来的光标状态
                this.Cursor = holdCursor;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 保存系统设置
            this.SaveSystemConfig();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}