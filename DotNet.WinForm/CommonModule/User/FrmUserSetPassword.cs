//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Utilities;
    using DotNet.Business;

    /// <summary>
    /// FrmUserSetPassword.cs
    /// 设置用户密码
    ///		
    /// 修改记录
    ///     
    ///     2011.12.27 版本：2.0 JiRiGaLa  增加删除密码功能。
    ///     2007.05.23 版本：1.0 JiRiGaLa  用户设置密码功能页面编写。
    ///		
    /// 版本：2.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.12.27</date>
    /// </author> 
    /// </summary>
    public partial class FrmUserSetPassword : BaseForm
    {
        // 用户主键数组
        private string[] selectedIds;
        
        /// <summary>
        /// 用户主键数组
        /// </summary>
        public string[] SelectedIds
        {
            get
            {
                return this.selectedIds;
            }
            set
            {
                this.selectedIds = value;
            }
        }

        /// <summary>
        /// 系统默认密码
        /// </summary>
        string DefaultPassword = string.Empty;

        public FrmUserSetPassword()
        {
            InitializeComponent();
        }

        #region public FrmUserSetPassword(string userIds)
        /// <summary>
		/// 设置员工密码
		/// </summary>
        /// <param name="userIds">被设置密码的用户主键</param>
        public FrmUserSetPassword(string[] userIds)
            : this()
		{
            this.SelectedIds = userIds;
		}
		#endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            if (UserConfigHelper.Exists())
            {
                DefaultPassword = UserConfigHelper.GetValue("DefaultPassword");
            }
            this.btnSetDefaultPassword.Visible = !string.IsNullOrEmpty(DefaultPassword);
            // 密码强度检查
            this.lblConfirmPasswordReq.Visible = BaseSystemInfo.CheckPasswordStrength;
            this.lblNewPasswordReq.Visible = BaseSystemInfo.CheckPasswordStrength;
            // this.btnDeletePassword.Visible = !BaseSystemInfo.CheckPasswordStrength;
            this.btnSetAsUserCode.Visible = this.UserInfo.IsAdministrator;
            this.btnSetAsUserName.Visible = this.UserInfo.IsAdministrator;
        }
        #endregion

        private void btnSetDefaultPassword_Click(object sender, EventArgs e)
        {
            if (this.SetPassword(DefaultPassword))
            {
                this.Close();
            }
        }

        #region private void ClearPassword()
        /// <summary>
        /// 清除密码
        /// </summary>
        private void ClearPassword()
        {
            this.txtConfirmPassword.Text    = string.Empty;
            this.txtNewPassword.Text        = string.Empty;
            this.txtNewPassword.Focus();
        }
        #endregion

        #region public override bool CheckInput()
        /// <summary>
        /// 加查输入的有效性
        /// </summary>
        public override bool CheckInput()
        {
            // 密码强度检查
            if (BaseSystemInfo.CheckPasswordStrength)
            {
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
            }
            // 新密码不一致
            if (this.txtNewPassword.Text != this.txtConfirmPassword.Text)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0039, AppMessage.MSG9959, AppMessage.MSG9960), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ClearPassword();
                return false;
            }
            return true;
        }
        #endregion

        #region private bool SetPassword()
        /// <summary>
        /// 设置用户密码
        /// </summary>
        /// <returns>是否成功</returns>
        private bool SetPassword()
        {
            return SetPassword(this.txtNewPassword.Text);
        }
        #endregion

        #region private bool SetPassword(string newPassword)
        /// <summary>
        /// 设置用户密码
        /// </summary>
        /// <param name="newPassword">新密码</param>
        /// <returns>是否成功</returns>
        private bool SetPassword(string newPassword)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            bool returnValue = false;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            DotNetService.Instance.LogOnService.SetPassword(UserInfo, this.SelectedIds, newPassword, out statusCode, out statusMessage);
            // 设置为平常状态
            this.Cursor = holdCursor;
            if (statusCode == StatusCode.SetPasswordOK.ToString())
            {
                if (BaseSystemInfo.ShowInformation)
                {
                    // 提示修改成功
                    MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.DialogResult = DialogResult.OK;
                returnValue = true;
            }
            else
            {
                MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                returnValue = false;
            }
            return returnValue;
        }
        #endregion

        private void btnSetAsUserCode_Click(object sender, EventArgs e)
        {
            BaseUserManager userManager = new BaseUserManager(this.UserInfo);
            DataTable dtUser = userManager.GetDataTable(this.SelectedIds);
            BaseUserEntity userEntity = null;
            foreach (DataRow dataRow in dtUser.Rows)
            {
                userEntity = new BaseUserEntity(dataRow);
                // 设置密码
                userManager.SetPassword(userEntity.Id.ToString(), userEntity.Code.ToString());
            }
            this.Close();
        }

        private void btnSetAsUserName_Click(object sender, EventArgs e)
        {
            BaseUserManager userManager = new BaseUserManager(this.UserInfo);
            DataTable dtUser = userManager.GetDataTable(this.SelectedIds);
            BaseUserEntity userEntity = null;
            foreach (DataRow dataRow in dtUser.Rows)
            {
                userEntity = new BaseUserEntity(dataRow);
                // 设置密码
                userManager.SetPassword(userEntity.Id.ToString(), userEntity.UserName.ToString());
            }
            this.Close();
        }

        private void btnDeletePassword_Click(object sender, EventArgs e)
        {
            // 更新用户的密码
            if (this.SetPassword(null))
            {
                this.Close();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 检查输入的有效性
            if (this.CheckInput())
            {
                // 更新用户的密码
                if (this.SetPassword())
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