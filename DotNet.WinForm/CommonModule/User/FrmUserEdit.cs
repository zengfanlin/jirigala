//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FrmUserInfo.cs
    /// 用户属性-用户属性窗体
    ///		
    /// 修改记录
    ///     
    ///     2008.04.05 版本：1.1 JiRiGaLa 整理调试程序。
    ///     2007.07.02 版本：1.0 JiRiGaLa  用户属性页面编写。
    ///     2012.04.22 版本：1.0 zwd       修改新增类似数据的添加
    ///		
    /// 版本：1.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.04.05</date>
    /// </author> 
    /// </summary>
    public partial class FrmUserEdit : BaseForm
    {
        /// <summary>
        /// 用户实体
        /// </summary>
        private BaseUserEntity userEntity = null;

        public FrmUserEdit()
        {
            InitializeComponent();
        }

        #region public override void SetHelp() 设置帮助信息
        /// <summary>
        /// 设置帮助信息
        /// </summary>
        public override void SetHelp()
        {
            this.HelpButton = true;
            this.helpProvider.SetHelpString(this.lblUserName, "在此处键入用户名。(建议用英文)");
            this.helpProvider.SetHelpString(this.lblRealName, "在此处键入全称。(建议用中文)");
            this.helpProvider.SetHelpString(this.lblCode, "在此处键入用户编号。(建议用数字)");
            this.helpProvider.SetHelpString(this.lblDefaultRole, "在此处选择类型。");
        }
        #endregion

        #region public FrmUserEdit(string id) : this() 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">主键</param>
        public FrmUserEdit(string id) : this()
        {
            this.EntityId = id;
        }
        #endregion

        #region private void GetRoles() 获取角色列表
        /// <summary>
        /// 获取角色列表
        /// </summary>
        private void GetRoles()
        {
            // 绑定类型数据
            DataTable dataTable = DotNetService.Instance.RoleService.GetDefaultRoleDT(UserInfo);
            BaseBusinessLogic.SetFilter(dataTable, BaseRoleEntity.FieldDeletionStateCode, "0");
            BaseBusinessLogic.SetFilter(dataTable, BaseRoleEntity.FieldEnabled, "1");
            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbDefaultRole.DisplayMember = BaseRoleEntity.FieldRealName;
            this.cmbDefaultRole.ValueMember = BaseRoleEntity.FieldId;
            this.cmbDefaultRole.DataSource = dataTable.DefaultView;
        }
        #endregion

        #region private void BindItemDetails() 绑定下拉筐数据
        /// <summary>
        /// 绑定下拉筐数据
        /// </summary>
        private void BindItemDetails()
        {
            // 绑定职位数据
            DataTable dataTable = DotNetService.Instance.ItemDetailsService.GetDataTableByCode(UserInfo, "SecurityLevel");
            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbSecurityLevel.DisplayMember = BaseItemDetailsEntity.FieldItemName;
            this.cmbSecurityLevel.ValueMember = BaseItemDetailsEntity.FieldItemValue;
            this.cmbSecurityLevel.DataSource = dataTable.DefaultView;
            // 提高友善性，默认能选中角色类别
            // if (!string.IsNullOrEmpty(this.SecurityLevel))
            // {
            //     this.cmbSecurityLevel.SelectedValue = this.SecurityLevel;
            // }
        }
        #endregion

        #region public override void ShowEntity() 显示数据
        /// <summary>
        /// 显示数据
        /// </summary>
        public override void ShowEntity()
        {
            // 在页面上显示
            this.txtId.Text = userEntity.Id;
            this.txtUserName.Text = userEntity.UserName;
            this.txtRealName.Text = userEntity.RealName;
            if (!string.IsNullOrEmpty(userEntity.Code))
            {
                this.txtCode.Text = userEntity.Code;
            }
            if (userEntity.RoleId != null)
            {
                this.cmbDefaultRole.SelectedValue = userEntity.RoleId.ToString();
            }
            if (userEntity.SecurityLevel != null && userEntity.SecurityLevel > 0)
            {
                this.cmbSecurityLevel.SelectedValue = userEntity.SecurityLevel.ToString();
            }
            if (userEntity.AllowStartTime != null)
            {
                this.dtpAllowStartTime.Checked = true;
                this.dtpAllowStartTime.Value = (DateTime)userEntity.AllowStartTime;
            }
            if (userEntity.AllowEndTime != null)
            {
                this.dtpAllowEndTime.Checked = true;
                this.dtpAllowEndTime.Value = (DateTime)userEntity.AllowEndTime;
            }
            if (userEntity.LockStartDate != null)
            {
                this.dtpLockStartDate.Checked = true;
                this.dtpLockStartDate.Value = (DateTime)userEntity.LockStartDate;
            }
            if (userEntity.LockEndDate != null)
            {
                this.dtpLockEndDate.Checked = true;
                this.dtpLockEndDate.Value = (DateTime)userEntity.LockEndDate;
            }
            // this.chbIsVisible.Checked = userEntity.IsVisible;
            this.chkLock.Checked = userEntity.Enabled == 0;
            // 判断数据是否被其他人删除
            if (string.IsNullOrEmpty(userEntity.Id))
            {
                MessageBox.Show(AppMessage.MSG0005, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 让时间显示得更友善,默认是上班下班时间
            this.dtpAllowStartTime.Checked = true;
            this.dtpAllowStartTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
            this.dtpAllowStartTime.Checked = false;
            this.dtpAllowEndTime.Checked = true;
            this.dtpAllowEndTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 0, 0);
            this.dtpAllowEndTime.Checked = false;
            // 默认是锁定一周比较好
            this.dtpLockStartDate.Checked = true;
            this.dtpLockStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            this.dtpLockStartDate.Checked = false;
            this.dtpLockEndDate.Checked = true;
            this.dtpLockEndDate.Value = this.dtpLockStartDate.Value.AddDays(7);
            this.dtpLockEndDate.Checked = false;
            // 加载用户
            this.userEntity = DotNetService.Instance.UserService.GetEntity(UserInfo, this.EntityId);
            // 绑定下拉框
            this.GetRoles();
            // 获取分类列表
            this.BindItemDetails();
            // 显示内容
            this.ShowEntity();
            // 焦点
            this.txtUserName.Focus();
        }
        #endregion

        public override void SetControlState()
        {
            if (this.userEntity.Code != null && this.userEntity.Code.Equals(DefaultRole.Administrator.ToString()))
            {
                // 若是超级管理员，就不应该可以被修改了
                this.SetControlState(false);
            }
            this.btnIPLimitr.Visible = BaseSystemInfo.CheckIPAddress;
            this.btnHandwrittenSignature.Visible = BaseSystemInfo.HandwrittenSignature;
        }

        public override void SetControlState(bool enabled)
        {
            this.txtCode.Enabled = enabled;
            this.txtUserName.Enabled = enabled;
            this.txtRealName.Enabled = enabled;
            this.cmbDefaultRole.Enabled = enabled;
            this.cmbSecurityLevel.Enabled = enabled;
            this.dtpAllowStartTime.Enabled = enabled;
            this.dtpAllowEndTime.Enabled = enabled;
            this.dtpLockStartDate.Enabled = enabled;
            this.dtpLockEndDate.Enabled = enabled;
            this.chkLock.Enabled = enabled;
            this.btnSave.Enabled = enabled;
            this.btnIPLimitr.Enabled = enabled;
        }

        private void btnIPLimitr_Click(object sender, EventArgs e)
        {
            FrmIpLimit frmIPLimit = new FrmIpLimit(userEntity);
            frmIPLimit.ShowDialog();
        }

        private void btnSetCommunicationPassword_Click(object sender, EventArgs e)
        {
            FrmUserSetCommunicationPassword frmUserSetCommunicationPassword = new FrmUserSetCommunicationPassword(this.userEntity.Id.ToString());
            frmUserSetCommunicationPassword.Show();
        }

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        public override bool CheckInput()
        {
            bool returnValue = true;
            this.txtUserName.Text = this.txtUserName.Text.TrimEnd();
            if (this.txtUserName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9978), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtUserName.Focus();
                return false;
            }
            // 这里需要检查系统设置的用户名长度限制
            if (BaseSystemInfo.CheckPasswordStrength && BaseSystemInfo.AccountMinimumLength > 0)
            {
                if (this.txtUserName.Text.Trim().Length < BaseSystemInfo.AccountMinimumLength)
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0026, AppMessage.MSG9957, BaseSystemInfo.AccountMinimumLength.ToString()), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtUserName.Focus();
                    return false;
                }
            }
            this.txtRealName.Text = this.txtRealName.Text.TrimEnd();
            if (this.txtRealName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG0233), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtRealName.Focus();
                return false;
            }
            if (this.dtpAllowStartTime.Checked)
            {
                this.dtpAllowStartTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, this.dtpAllowStartTime.Value.Hour, this.dtpAllowStartTime.Value.Minute, this.dtpAllowStartTime.Value.Second);
            }
            if (this.dtpAllowEndTime.Checked)
            {
                this.dtpAllowEndTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, this.dtpAllowEndTime.Value.Hour, this.dtpAllowEndTime.Value.Minute, this.dtpAllowEndTime.Value.Second);
            }
            if (this.dtpAllowStartTime.Checked && this.dtpAllowEndTime.Checked)
            {
                if (this.dtpAllowStartTime.Value > this.dtpAllowEndTime.Value)
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0025, AppMessage.MSG0092, AppMessage.MSG0093), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dtpAllowStartTime.Focus();
                    return false;
                }
            }
            if (this.dtpLockStartDate.Checked && this.dtpLockEndDate.Checked)
            {
                if (this.dtpLockStartDate.Value > this.dtpLockEndDate.Value)
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0025, AppMessage.MSG0094, AppMessage.MSG0095), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dtpLockStartDate.Focus();
                    return false;
                }
            }
            return returnValue;
        }
        #endregion

        private BaseUserEntity GetEntity()
        {
            // 读取类属性
            // 更新到数据库
            // 转换数据
            userEntity.RealName = this.txtRealName.Text;
            userEntity.UserName = this.txtUserName.Text;
            userEntity.Code = this.txtCode.Text;
            userEntity.QuickQuery = StringUtil.GetPinyin(userEntity.RealName);
            if (this.cmbDefaultRole.SelectedValue != null && this.cmbDefaultRole.SelectedValue.ToString().Length > 0)
            {
                userEntity.RoleId = this.cmbDefaultRole.SelectedValue.ToString();
            }
            else
            {
                userEntity.RoleId = null;
            }
            int securityLevel = 0;
            if (this.cmbSecurityLevel.SelectedValue != null && this.cmbSecurityLevel.SelectedValue.ToString().Length > 0)
            {
                int.TryParse(this.cmbSecurityLevel.SelectedValue.ToString(), out securityLevel);
            }
            userEntity.SecurityLevel = securityLevel;
            if (this.dtpAllowStartTime.Checked)
            {
                userEntity.AllowStartTime = this.dtpAllowStartTime.Value;
            }
            else
            {
                userEntity.AllowStartTime = null;
            }
            if (this.dtpAllowEndTime.Checked)
            {
                userEntity.AllowEndTime = this.dtpAllowEndTime.Value;
            }
            else
            {
                userEntity.AllowEndTime = null;
            }
            if (this.dtpLockStartDate.Checked)
            {
                userEntity.LockStartDate = this.dtpLockStartDate.Value;
            }
            else
            {
                userEntity.LockStartDate = null;
            }
            if (this.dtpLockEndDate.Checked)
            {
                userEntity.LockEndDate = this.dtpLockEndDate.Value;
            }
            else
            {
                userEntity.LockEndDate = null;
            }
            userEntity.Enabled = this.chkLock.Checked ? 0 : 1;
            return this.userEntity;
        }

        private void txtRealName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.txtUserName.Text = StringUtil.GetPinyin(this.txtRealName.Text);
        }

        private void btnSignature_Click(object sender, EventArgs e)
        {
            FrmSignature frmSignature = new FrmSignature(this.userEntity.Id.ToString());
            frmSignature.Show();
        }

        #region private bool AddUser() 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>成功</returns>
        private bool AddUser()
        {
            bool returnValue = false;
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            // 转换数据
            // this.EntityID = DotNetService.Instance.UserService.AddUser(UserInfo, string.Empty, UserInfo.CompanyName, UserInfo.DepartmentName, UserInfo.WorkgroupName, userName, fullName, code, role, password, string.Empty, string.Empty, enabled, string.Empty, out statusCode, out statusMessage);

            BaseUserEntity userEntity = this.GetEntity(); //填充类数据
            this.EntityId = DotNetService.Instance.UserService.AddUser(UserInfo, userEntity, out statusCode, out statusMessage);

            if (statusCode == StatusCode.OKAdd.ToString())
            {
                if (BaseSystemInfo.ShowInformation)
                {
                    // 添加成功，进行提示
                    MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Changed = true;
                this.DialogResult = DialogResult.OK;
                returnValue = true;
            }
            else
            {
                MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (statusCode == StatusCode.ErrorUserExist.ToString())
                {
                    this.txtUserName.SelectAll();
                    this.txtUserName.Focus();
                }
                // 是否编号重复了，提高友善性
                if (statusCode == StatusCode.ErrorCodeExist.ToString())
                {
                    this.txtCode.SelectAll();
                    this.txtCode.Focus();
                }
                return false;
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
            return returnValue;
        }
        #endregion

        private void btnLikeAdd_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    if (this.AddUser())
                    {
                        this.Close();
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
        }

        #region public override bool SaveEntity() 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>成功</returns>
        public override bool SaveEntity()
        {
            bool returnValue = false;
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string statusCode = string.Empty;
                string statusMessage = string.Empty;
                this.GetEntity();
                DotNetService.Instance.UserService.UpdateUser(UserInfo, userEntity, out statusCode, out statusMessage);
                // DotNetService.Instance.UserService.UpdateUser(UserInfo, this.EntityId, this.txtUserName.Text, this.txtFullName.Text, this.txtCode.Text, role, string.Empty, string.Empty, string.Empty, this.chbEnabled.Checked, out statusCode, out statusMessage);
                if (statusCode == StatusCode.OKUpdate.ToString())
                {
                    if (BaseSystemInfo.ShowInformation)
                    {
                        // 添加成功，进行提示
                        MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.DialogResult = DialogResult.OK;
                    return true;
                }
                else
                {
                    MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (statusCode == StatusCode.ErrorUserExist.ToString())
                    {
                        this.txtUserName.SelectAll();
                        this.txtUserName.Focus();
                    }
                    // 是否编号重复了，提高友善性
                    if (statusCode == StatusCode.ErrorCodeExist.ToString())
                    {
                        this.txtCode.SelectAll();
                        this.txtCode.Focus();
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                this.ProcessException(ex);
            }
            finally
            {
                // 鼠标正常状态
                this.Cursor = holdCursor;
            }
            return returnValue;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    if (this.SaveEntity())
                    {
                        this.Close();
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
    }
}