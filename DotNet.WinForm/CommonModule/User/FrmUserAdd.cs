//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FrmUserAdd
    /// 添加用户。
    /// 
    /// 修改纪录
    /// 
    ///     2010.09.16 版本：1.3 JiRiGaLa 仔细整理代码一次。
    ///     2010.04.06 版本：1.2 JiRiGaLa 修改为面向实体。
    ///     2008.04.05 版本：1.1 JiRiGaLa 整理调试程序。
    ///     2007.07.03 版本：1.0 JiRiGaLa 主键编辑。
    /// 
    /// 版本：1.3
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.09.16</date>
    /// </author>
    public partial class FrmUserAdd : BaseForm
    {
        /// <summary>
        /// 用户实体
        /// </summary>
        public BaseUserEntity userEntity = null;

        /// <summary>
        /// 被选中的公司主键
        /// </summary>
        public string CompanyId { get; set;}

        /// <summary>
        /// 被选中的公司全名
        /// </summary>
        public new string CompanyName { get; set;}

        /// <summary>
        /// 被选中的部门主键
        /// </summary>
        public string DepartmentId { get; set;}

        /// <summary>
        /// 被选中的部门全名
        /// </summary>
        public string DepartmentName { get; set;}

        public FrmUserAdd()
        {
            InitializeComponent();
        }

        public FrmUserAdd(BaseUserEntity entity)
            : this()
        {
            this.userEntity = entity;
        }

        /// <summary>
        /// 添加的用户
        /// </summary>
        /// <returns>是否成功</returns>
        public delegate bool OnAddedEventHandler();

        public event OnAddedEventHandler OnAdded;

        #region public FrmUserAdd(string companyId, string companyFullName, string departmentId, string departmentFullName) : this() 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="companyId">公司主键</param>
        /// <param name="companyFullName">公司名称</param>
        /// <param name="departmentId">部门主键</param>
        /// <param name="departmentFullName">部门名称</param>
        public FrmUserAdd(string companyId, string companyFullName, string departmentId, string departmentFullName)
            : this()
        {
            this.CompanyId = companyId;
            this.CompanyName = companyFullName;
            this.DepartmentId = departmentId;
            this.DepartmentName = departmentFullName;
        }
        #endregion

        #region public override void SetHelp() 设置帮助信息
        /// <summary>
        /// 设置帮助信息
        /// </summary>
        public override void SetHelp()
        {
            this.HelpButton = true;
            this.helpProvider.SetHelpString(this.lblUserName, "在此处键入用户名（建议用英文）。");
            this.helpProvider.SetHelpString(this.lblRealName, "在此处键入全称（建议用中文）。");
            this.helpProvider.SetHelpString(this.lblCode, "在此处键入用户编号（建议用数字）。");
            this.helpProvider.SetHelpString(this.lblDefaultRole, "在此处选择类型。");
            this.helpProvider.SetHelpString(this.lblPassword, "在此处键入密码。");
            this.helpProvider.SetHelpString(this.lblConfirmPassword, "在此处键入确认密码。");
        }
        #endregion

        #region private void GetRoles() 获得角色列表
        /// <summary>
        /// 获得角色列表
        /// </summary>
        private void GetRoles()
        {
            // 绑定类型数据
            DataTable dataTable = DotNetService.Instance.RoleService.GetDefaultRoleDT(this.UserInfo);
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

        #region public override void SetControlState() 按钮的状态设置
        /// <summary>
        /// 按钮的状态设置
        /// </summary>
        public override void SetControlState()
        {
            // 密码强度检查
            this.lblConfirmPasswordReq.Visible = BaseSystemInfo.CheckPasswordStrength;
            this.lblPasswordReq.Visible = BaseSystemInfo.CheckPasswordStrength;
        }
        #endregion

        #region public override void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public override void ShowEntity()
        {
            if (this.userEntity != null)
            {
                this.txtUserName.Text = this.userEntity.UserName;
                this.txtRealName.Text = this.userEntity.RealName;
                this.txtCode.Text = this.userEntity.Code;
                this.cmbDefaultRole.SelectedValue = this.userEntity.DepartmentName;
                this.cmbSecurityLevel.SelectedValue = this.userEntity.SecurityLevel;
                this.chkEnabled.Checked = this.userEntity.Enabled == 1;
            }
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.ShowEntity();
            // 获得角色列表
            this.GetRoles();
            // 获取分类列表
            this.BindItemDetails();
        }
        #endregion

        private void txtFullName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.txtUserName.Text = StringUtil.GetPinyin(this.txtRealName.Text);
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
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9957), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9978), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtRealName.Focus();
                return false;
            }            

            // 密码不能为空
            if (BaseSystemInfo.CheckPasswordStrength)
            {
                if (this.txtPassword.Text.Trim().Length == 0)
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9964), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtPassword.Focus();
                    return false;
                }
                if (!BaseCheckInput.CheckPasswordStrength(this.txtPassword))
                {
                    return false;
                }
            }
            if (!this.txtConfirmPassword.Text.Equals(this.txtPassword.Text))
            {
                MessageBox.Show(AppMessage.MSG9967, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtPassword.Clear();
                this.txtConfirmPassword.Clear();
                this.txtPassword.Focus();
                return false;
            }
            return returnValue;
        }
        #endregion

        public BaseUserEntity GetUserEntity()
        {
            BaseUserEntity userEntity = new BaseUserEntity();
            userEntity.UserName = this.txtUserName.Text;
            userEntity.RealName = this.txtRealName.Text;
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
            userEntity.UserPassword = this.txtPassword.Text;
            // 安全交易密码、安全通讯密码
            userEntity.CommunicationPassword = this.txtPassword.Text;
            // 是否进行分级管理
            if (BaseSystemInfo.UsePermissionScope)
            {
                userEntity.CompanyName = UserInfo.CompanyName;
                userEntity.DepartmentName = UserInfo.DepartmentName;
                userEntity.WorkgroupName = UserInfo.WorkgroupName;
            }

            // 2012.05.21 Pcsky 新增公司和部门的保存功能
            if (!string.IsNullOrEmpty(CompanyId))
            {
                userEntity.CompanyId = CompanyId;
            }
            if (!string.IsNullOrEmpty(CompanyName))
            {
                userEntity.CompanyName = CompanyName;
            }
            if (!string.IsNullOrEmpty(DepartmentId))
            {
                userEntity.DepartmentId = DepartmentId;
            }
            if (!string.IsNullOrEmpty(DepartmentName))
            {
                userEntity.DepartmentName = DepartmentName;
            }

            userEntity.Enabled = this.chkEnabled.Checked ? 1 : 0;
            userEntity.DeletionStateCode = 0;
            userEntity.IsVisible = 1;
            return userEntity;
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
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            // 转换数据
            // this.EntityID = DotNetService.Instance.UserService.AddUser(UserInfo, string.Empty, UserInfo.CompanyName, UserInfo.DepartmentName, UserInfo.WorkgroupName, userName, fullName, code, role, password, string.Empty, string.Empty, enabled, string.Empty, out statusCode, out statusMessage);
            BaseUserEntity userEntity = this.GetUserEntity();
            this.EntityId = DotNetService.Instance.UserService.AddUser(UserInfo, userEntity, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKAdd.ToString())
            {
                if (BaseSystemInfo.ShowInformation)
                {
                    // 添加成功，进行提示
                    MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Changed = true;
                //添加成功后是否关闭窗口，必须加这个判断，否则会触发FrmClose事情关闭本窗口
                if (chkClose.Checked)
                {
                    this.DialogResult = DialogResult.OK;
                }
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

        #region private void ClearForm()
        /// <summary>
        /// 清除窗体
        /// </summary>
        private void ClearForm()
        {
            this.txtUserName.Text = string.Empty;
            this.txtRealName.Text = string.Empty;
            this.txtCode.Text = string.Empty;
            this.cmbDefaultRole.SelectedIndex = 0;
            this.cmbSecurityLevel.SelectedIndex = 0;
            this.txtPassword.Text = string.Empty;
            this.txtConfirmPassword.Text = string.Empty;
            this.chkEnabled.Checked = true;
            this.txtUserName.Focus();
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
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
                        if (this.OnAdded != null)
                        {
                            this.OnAdded();
                        }
                        if (this.chkClose.Checked)
                        {
                            // 关闭窗口
                            this.Close();
                        }
                        else
                        {
                            this.ClearForm();
                        }
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