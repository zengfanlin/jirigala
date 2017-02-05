//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FrmScreenLock
    /// 锁定屏幕
    /// 
    /// 修改纪录
    ///     2011.10.24 版本：1.1 张广梁 修改锁定时间为下拉框。
    ///		2011.05.11 版本：1.0 JiRiGaLa 整理文件。
    ///		
    /// 版本：1.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.05.11</date>
    /// </author> 
    /// </summary>
    public partial class FrmScreenLock : BaseForm
    {
        public FrmScreenLock()
        {
            this.ShowDialogOnly = true;
            InitializeComponent();
        }

        /// <summary>
        /// 用户是否已经重新登录了系统
        /// </summary>
        private bool LogOned = false;

        #region public override void FormOnLoad() 窗体加载
        public override void FormOnLoad()
        {
            this.BindItemDetails();
            // 是否锁定系统
            DotNetService dotNetService = new DotNetService();
            string isLockSystem = dotNetService.ParameterService.GetParameter(UserInfo, "User", UserInfo.Id, "IsLockSystem");
            // 锁定等待时间
            string lockWaitMinute = dotNetService.ParameterService.GetParameter(UserInfo, "User", UserInfo.Id, "LockWaitMinute");
            if (dotNetService.ParameterService is ICommunicationObject)
            {
                ((ICommunicationObject)dotNetService.ParameterService).Close();
            }            
            // 这里是需要保证，默认是选中的，只有被确认过不选，才是不选才对
            this.ckbIsLock.Checked = (isLockSystem == false.ToString() ? false : true);
            // 这里也要保证，屏幕上的默认值能保存，只有客户设置过参数才读取客户的参数
            if (!string.IsNullOrEmpty(lockWaitMinute))
            {
                this.cmbLockWaitMinute.SelectedValue = lockWaitMinute;
            }
            if (this.Owner != null)
            {
                this.Owner.Opacity = 0;
            }
        }
        #endregion

        #region private void BindItemDetails() 绑定下拉筐数据
        /// <summary>
        /// 绑定下拉筐数据
        /// </summary>
        private void BindItemDetails()
        {
            // 绑定职位数据
            DataTable dataTable = DotNetService.Instance.ItemDetailsService.GetDataTableByCode(UserInfo, "LockWaitMinute");
            this.cmbLockWaitMinute.DisplayMember = BaseItemDetailsEntity.FieldItemName;
            this.cmbLockWaitMinute.ValueMember = BaseItemDetailsEntity.FieldItemValue;
            this.cmbLockWaitMinute.DataSource = dataTable.DefaultView;
        }
        #endregion

        #region public override void SetHelp() 设置帮助
        /// <summary>
        /// 设置帮助
        /// </summary>
        public override void SetHelp()
        {
            this.HelpButton = false;
            this.grpLogOn.Text = this.grpLogOn.Text + " （" + this.UserInfo.RealName + "）";
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // 密码强度检查
            this.labPasswordReq.Visible = BaseSystemInfo.CheckPasswordStrength;
        }
        #endregion

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        public override bool CheckInput()
        {
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

        #region private bool LogOn()
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns>是否成功</returns>
        private bool LogOn(bool prompt)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            try
            {
                string userName = BaseSystemInfo.CurrentUserName;
                DotNetService dotNetService = new DotNetService();
                BaseUserInfo userInfo = dotNetService.LogOnService.UserLogOn(UserInfo, userName, this.txtPassword.Text, false, out statusCode, out statusMessage);
                if (dotNetService.LogOnService is ICommunicationObject)
                {
                    ((ICommunicationObject)dotNetService.LogOnService).Close();
                }
                if (statusCode == StatusCode.OK.ToString())
                {
                    this.LogOned = true;
                    BaseSystemInfo.UserInfo = userInfo;
                    return true;
                }
                else
                {
                    // 是否进行消息提示
                    if (prompt)
                    {
                        // MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // "密码错误，请注意大小写。"
                        MessageBox.Show(AppMessage.MSG9967, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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

        private void txtPassword_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.ConfirmLogOn(true);
            }
        }

        private void ConfirmLogOn(bool prompt)
        {
            // 验证用户输入
            if (this.CheckInput())
            {
                // 用户登录成功了，才关闭
                if (this.LogOn(prompt))
                {
                    this.SaveConfiguration();
                    if (this.Owner != null)
                    {
                        this.Owner.Opacity = 1;
                    }
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        /// <summary>
        /// 保存页面个性化配置情况
        /// </summary>
        private void SaveConfiguration()
        {
            DotNetService dotNetService = new DotNetService();
            dotNetService.ParameterService.SetParameter(UserInfo, "User", UserInfo.Id, "IsLockSystem", ckbIsLock.Checked.ToString());

            if(this.cmbLockWaitMinute.SelectedValue!=null)
            {
                dotNetService.ParameterService.SetParameter(UserInfo, "User", UserInfo.Id, "LockWaitMinute", this.cmbLockWaitMinute.SelectedValue.ToString());
            }
            if (dotNetService.ParameterService is ICommunicationObject)
            {
                ((ICommunicationObject)dotNetService.ParameterService).Close();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.ConfirmLogOn(true);
        }

        private void FrmScreenLock_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 当窗体被强制关闭时的优化处理
            e.Cancel = !this.LogOned;
        }

        private void cmbLockWaitMinute_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbLockWaitMinute.SelectedValue.ToString() == "0")
            {
                this.ckbIsLock.Checked = false;
                this.ckbIsLock.Enabled = false;
            }
            else
            {
                this.ckbIsLock.Checked = true;
                this.ckbIsLock.Enabled = true;
            }
        }
    }
}