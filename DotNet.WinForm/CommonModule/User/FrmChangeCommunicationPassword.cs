//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FrmChangeCommunicationPassword.cs
    /// 修改通讯密码
    ///		
    /// 修改记录
    ///     
    ///     2011.05.12 版本：1.0 JiRiGaLa  用户修改密码页面编写。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.05.12</date>
    /// </author> 
    /// </summary>
    public partial class FrmChangeCommunicationPassword : BaseForm
    {
        public FrmChangeCommunicationPassword()
        {
            this.ShowDialogOnly = true;
            InitializeComponent();
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // 密码强度检查
            this.lblConfirmPasswordReq.Visible = BaseSystemInfo.CheckPasswordStrength;
            this.lblNewPasswordReq.Visible = BaseSystemInfo.CheckPasswordStrength;
            this.lblOldPasswordReq.Visible = BaseSystemInfo.CheckPasswordStrength;
        }
        #endregion

        #region private void ClearNewPassword() 清除密码
        /// <summary>
        /// 清除密码
        /// </summary>
        private void ClearNewPassword()
        {
            this.txtNewPassword.Text = string.Empty;
            this.txtConfirmPassword.Text = string.Empty;
            this.txtNewPassword.Focus();
        }
        #endregion

        #region private void ClearOldPassword() 清除密码
        /// <summary>
        /// 清除密码
        /// </summary>
        private void ClearOldPassword()
        {
            this.txtOldPassword.Text = string.Empty;
            this.txtOldPassword.Focus();
        }
        #endregion

        #region public override bool CheckInput() 加查输入的有效性
        /// <summary>
        /// 加查输入的有效性
        /// </summary>
        public override bool CheckInput()
        {
            // 密码强度检查
            if (BaseSystemInfo.CheckPasswordStrength)
            {
                // 原来密码为空
                if (this.txtOldPassword.Text.Length == 0)
                {
                    // 判断是否为确认按钮
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9961), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtOldPassword.Focus();
                    return false;
                }
                // 新密码为空
                if (this.txtNewPassword.Text.Length == 0)
                {
                    // 判断是否为确认按钮
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9959), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtNewPassword.Focus();
                    return false;
                }
                // 确认密码为空
                if (this.txtConfirmPassword.Text.Length == 0)
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9960), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtConfirmPassword.Focus();
                    return false;
                }
                if (!BaseCheckInput.CheckPasswordStrength(this.txtNewPassword))
                {
                    return false;
                }
            }
            // 新密码不一致
            if (this.txtConfirmPassword.Text != this.txtNewPassword.Text)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0039, AppMessage.MSG9959, AppMessage.MSG9960), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ClearNewPassword();
                return false;
            }
            return true;
        }
        #endregion

        /// <summary>
        /// 当修改通讯密码后触发的事件
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="oldPassword">旧密码</param>
        /// <param name="newPassword">新密码</param>
        public delegate bool AfterChangeCommunicationPasswordEventHandler(string userId, string oldPassword, string newPassword);

        /// <summary>
        /// 修改通讯密码后触发的事件委托
        /// </summary>
        public event AfterChangeCommunicationPasswordEventHandler AfterChangeCommunicationPassword;

        #region private bool ChangePassword(string oldPassword, string newPassword) 修改密码
        /// <summary>
        /// 修改密码
        /// </summary>
        private bool ChangePassword()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            bool returnValue = false;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            if (AfterChangeCommunicationPassword == null)
            {
                DotNetService.Instance.LogOnService.ChangeCommunicationPassword(UserInfo, this.txtOldPassword.Text, this.txtNewPassword.Text, out statusCode, out statusMessage);
            }
            else
            {
                statusCode = StatusCode.ChangePasswordOK.ToString();
            }
            // 设置为平常状态
            this.Cursor = holdCursor;
            if (statusCode == StatusCode.ChangePasswordOK.ToString())
            {
                // 修改通讯密码后的方法
                if (AfterChangeCommunicationPassword != null)
                {
                    AfterChangeCommunicationPassword(this.UserInfo.Id, this.txtOldPassword.Text, this.txtNewPassword.Text);
                }
                else
                {
                    if (BaseSystemInfo.ShowInformation)
                    {
                        // 提示修改成功
                        MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                this.DialogResult = DialogResult.OK;
                returnValue = true;
            }
            else
            {
                if (statusCode == StatusCode.PasswordCanNotBeNull.ToString())
                {
                    this.ClearOldPassword();
                }
                if (statusCode == StatusCode.OldPasswordError.ToString())
                {
                    this.ClearOldPassword();
                }
                MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                returnValue = false;
            }
            return returnValue;
        }
        #endregion

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 检查输入的有效性
            if (this.CheckInput())
            {
                // 更新用户的密码
                if (this.ChangePassword())
                {
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}