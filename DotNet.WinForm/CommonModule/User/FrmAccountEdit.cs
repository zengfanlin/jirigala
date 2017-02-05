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
    /// FrmAccountEdit
    /// 申请帐户
    /// 
    /// 修改纪录
    /// 
    ///     2012-05-07 版本：3.71 Serwif 增加分公司代码、分公司名称
    ///     2010.08.07 版本：1.3 JiRiGaLa 利用周末休息时间，把帐户申请功能重新仔细整理一下，做得铜墙铁臂的小程序。
    ///     2008.10.01 版本：1.2 JiRiGaLa 重新定位账号申请。
    ///     2008.04.17 版本：1.1 JiRiGaLa 主键整理。
    ///     2007.07.03 版本：1.0 JiRiGaLa 主键编辑。
    /// 
    /// 版本：1.3
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.08.07</date>
    /// </author>
    public partial class FrmAccountEdit : BaseForm
    {
        private DataTable DTUserOrganize = null;
        private BaseUserEntity userEntity = null;
        private BaseStaffEntity staffEntity = null;

        public FrmAccountEdit()
        {
            InitializeComponent();
        }

        #region public FrmAccountEdit(string id) : this() 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">主键</param>
        public FrmAccountEdit(string id)
            : this()
        {
            this.EntityId = id;
        }
        #endregion

        #region private void BindItemDetails() 绑定下拉筐数据
        /// <summary>
        /// 绑定下拉筐数据
        /// </summary>
        private void BindItemDetails()
        {
            // 绑定类型数据
            DataTable dataTable = DotNetService.Instance.RoleService.GetDefaultRoleDT(this.UserInfo);
            // 只获取系统角色栏目，是一个过滤条件，也可以是一个视图
            // BaseBusinessLogic.SetFilter(dataTable, BaseRoleEntity.FieldCategory, "SystemRole");

            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbRole.DisplayMember = BaseRoleEntity.FieldRealName;
            this.cmbRole.ValueMember = BaseRoleEntity.FieldId;
            this.cmbRole.DataSource = dataTable.DefaultView;
            
            // 默认是本公司的，本部门的员工的用户，为了提高友善性，一般是帮自己部门的人申请帐号
            this.ucCompany.SelectedId = this.UserInfo.CompanyId;
            this.ucCompany.SelectedFullName = this.UserInfo.CompanyName;
            this.ucSubCompany.SelectedId = this.UserInfo.SubCompanyId;
            this.ucSubCompany.SelectedFullName = this.UserInfo.SubCompanyName;
            this.ucDepartment.SelectedId = this.UserInfo.DepartmentId;
            this.ucDepartment.SelectedFullName = this.UserInfo.DepartmentName;
            this.ucWorkgroup.SelectedId = this.UserInfo.WorkgroupId;
            this.ucWorkgroup.SelectedFullName = this.UserInfo.WorkgroupName;
            // 默认打开的公司
            this.ucDepartment.OpenId = UserInfo.CompanyId;
            this.ucWorkgroup.OpenId = UserInfo.DepartmentId;
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.ucCompany.AllowNull = false;
            this.ucCompany.CanEdit = false;
            this.ucSubCompany.AllowNull = true;
            this.ucSubCompany.CanEdit = false;
            this.ucDepartment.AllowNull = true;
            this.ucDepartment.CanEdit = false;
            this.ucWorkgroup.AllowNull = true;
            this.ucWorkgroup.CanEdit = false;
            // 当前用户是否系统管理员？
            this.chbEnabled.Enabled = this.UserInfo.IsAdministrator;

            if (this.DTUserOrganize.DefaultView.Count > 0)
            {
                this.btnSelectAll.Enabled = true;
                this.btnInvertSelect.Enabled = true;
                // 是否有删除权限
                this.btnRemove.Enabled = true;
            }
            else
            {
                this.btnSelectAll.Enabled = false;
                this.btnInvertSelect.Enabled = false;
                // 是否有删除权限
                this.btnRemove.Enabled = false;
            }
        }
        #endregion

        #region private void GetUserOrganizeList() 用户的兼职情况
        /// <summary>
        /// 用户的兼职情况
        /// </summary>
        private void GetUserOrganizeList()
        {
            this.DTUserOrganize = DotNetService.Instance.UserService.GetUserOrganizeDT(this.UserInfo, this.EntityId);
            this.grdUserOrganize.AutoGenerateColumns = false;
            this.grdUserOrganize.DataSource = this.DTUserOrganize.DefaultView;
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdUserOrganize);
            this.userEntity = DotNetService.Instance.UserService.GetEntity(this.UserInfo, this.EntityId);
            // 绑定下拉筐数据
            this.BindItemDetails();
            // 显示用户信息
            this.ShowUser();
            // 用户的兼职情况
            this.GetUserOrganizeList();
            this.btnSetPassword.Enabled = true;
            //定位焦点
            this.ActiveControl = this.txtUserName;
            this.txtUserName.Focus();
        }
        #endregion

        private void txtRealName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.txtUserName.Text = StringUtil.GetPinyin(this.txtRealName.Text);
        }

        private void ShowUser()
        {
            // 显示用户数据
            this.txtUserName.Text = userEntity.UserName;
            this.txtRealName.Text = userEntity.RealName;
            this.txtCode.Text = userEntity.Code;
            this.txtMobile.Text = userEntity.Mobile;
            this.txtEmail.Text = userEntity.Email;
            if (userEntity.RoleId != null)
            {
                this.cmbRole.SelectedValue = userEntity.RoleId.ToString();
            }
            this.ucCompany.SelectedId = userEntity.CompanyId;
            this.ucSubCompany.SelectedId = userEntity.SubCompanyId;
            this.ucDepartment.SelectedId = userEntity.DepartmentId;
            this.ucWorkgroup.SelectedId = userEntity.WorkgroupId;
            this.chbEnabled.Checked = (userEntity.Enabled == 1);
            this.txtDescription.Text = userEntity.Description;
            // 获取用户对应的员工信息
            if (this.userEntity.Id != null)
            {
                // 加载员工
                BaseStaffManager staffManager = new BaseStaffManager(UserInfo);
                this.staffEntity = new BaseStaffEntity(staffManager.GetDataTable(BaseStaffEntity.FieldUserId, userEntity.Id.ToString()));
            }
        }

        private void SetCompany(string companyId)
        {
            // 设置部门与公司的联动功能
            this.ucDepartment.OpenId = companyId;
        }

        private void SetDepartment(string departmentId)
        {
            // 设置部门与公司的联动功能
            this.ucWorkgroup.OpenId = departmentId;
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
            if (!BaseCheckInput.CheckEmpty(this.txtUserName, AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9957)))
            {
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
            if (!BaseCheckInput.CheckEmpty(this.txtRealName, AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG0233)))
            {
                return false;
            }
            if (!string.IsNullOrEmpty(this.txtEmail.Text))
            {
                if (!BaseCheckInput.CheckEmail(this.txtEmail, "E_mail 格式不正确，请重新输入。"))
                {
                    return false;
                }
            }
            if (this.ucCompany.SelectedFullName.Length == 0)
            {
                MessageBox.Show(AppMessage.MSG0229, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ucCompany.Focus();
                return false;
            }
            return returnValue;
        }
        #endregion

        #region private BaseUserEntity GetEntity()
        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <returns>用户实体</returns>
        private BaseUserEntity GetEntity()
        {
            string roleId = null;
            if (this.cmbRole.SelectedValue == null || this.cmbRole.SelectedValue.ToString().Length == 0)
            {
                roleId = null;
            }
            else
            {
                roleId = this.cmbRole.SelectedValue.ToString();
            }
            // 获取用户数据
            userEntity.UserName = this.txtUserName.Text;
            userEntity.Code = this.txtCode.Text;
            userEntity.RealName = this.txtRealName.Text;
            userEntity.QuickQuery = StringUtil.GetPinyin(userEntity.RealName);
            userEntity.Mobile = this.txtMobile.Text;
            userEntity.Email = this.txtEmail.Text;
            userEntity.RoleId = roleId;
            if (string.IsNullOrEmpty(this.ucCompany.SelectedId))
            {
                userEntity.CompanyId = null;
                userEntity.CompanyName = null;
            }
            else
            {
                userEntity.CompanyId = this.ucCompany.SelectedId;
                userEntity.CompanyName = this.ucCompany.SelectedFullName;
            }
            if (string.IsNullOrEmpty(this.ucSubCompany.SelectedId))
            {
                userEntity.SubCompanyId = null;
                userEntity.SubCompanyName = null;
            }
            else
            {
                userEntity.SubCompanyId = this.ucSubCompany.SelectedId;
                userEntity.SubCompanyName = this.ucSubCompany.SelectedFullName;
            }
            if (string.IsNullOrEmpty(this.ucDepartment.SelectedId))
            {
                userEntity.DepartmentId = null;
                userEntity.DepartmentName = null;
            }
            else
            {
                userEntity.DepartmentId = this.ucDepartment.SelectedId;
                userEntity.DepartmentName = this.ucDepartment.SelectedFullName;
            }
            if (string.IsNullOrEmpty(this.ucWorkgroup.SelectedId))
            {
                userEntity.WorkgroupId = null;
                userEntity.WorkgroupName = null;
            }
            else
            {
                userEntity.WorkgroupId = this.ucWorkgroup.SelectedId;
                userEntity.WorkgroupName = this.ucWorkgroup.SelectedFullName;
            }
            userEntity.Enabled = this.chbEnabled.Checked ? 1 : 0;
            // 应该是在待审核状态
            if (userEntity.Enabled == 0)
            {
                userEntity.AuditStatus = AuditStatus.WaitForAudit.ToString();
            }
            userEntity.Description = this.txtDescription.Text;
            return userEntity;
        }
        #endregion

        #region private bool SaveAccount() 申请帐号
        /// <summary>
        /// 更新帐号
        /// </summary>
        /// <returns>保存成功</returns>
        private bool SaveAccount()
        {
            int returnValue = 0;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            //1.先更新用户信息
            BaseUserEntity userEntity = this.GetEntity();
            returnValue = DotNetService.Instance.UserService.UpdateUser(this.UserInfo, userEntity, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKUpdate.ToString())
            {
                //2.如果更新用户成功，则更新对应的员工
                this.GetStaffEntity();
                if (this.staffEntity.Id != null && this.staffEntity.Id > 0)
                {
                    DotNetService.Instance.StaffService.UpdateStaff(UserInfo, this.staffEntity, out statusCode, out statusMessage);
                    if (statusCode != StatusCode.OKUpdate.ToString())
                    {
                        MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // 是否编号重复了，提高友善性
                        if (statusCode == StatusCode.ErrorCodeExist.ToString())
                        {
                            this.txtCode.SelectAll();
                            this.txtCode.Focus();
                        }
                        if (statusCode == StatusCode.ErrorUserExist.ToString())
                        {
                            this.txtUserName.SelectAll();
                            this.txtUserName.Focus();
                        }
                        return returnValue < 0;
                    }
                }
                // 没审核通过的，才可以有提示信息
                if (BaseSystemInfo.ShowInformation && !this.chbEnabled.Checked)
                {
                    // 这里应该判断，申请帐号是否需要进行审核，若需要审核提示等待审核，否则直接提示成功信息。
                    // 添加成功，进行提示
                    MessageBox.Show(AppMessage.MSG0230, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // 是否用户名重复了，提高友善性
                if (statusCode == StatusCode.ErrorUserExist.ToString())
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0008, AppMessage.MSG9957), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtUserName.SelectAll();
                    this.txtUserName.Focus();
                }
                else
                {
                    MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return returnValue < 0;
            }
            return returnValue > 0;
        }
        #endregion

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
            BaseUserEntity entity = GetEntity();
            entity.Id = null;
            FrmUserAdd frmUserAdd = new FrmUserAdd(entity);
            frmUserAdd.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    // 更新帐号
                    if (this.SaveAccount())
                    {
                        this.DialogResult = DialogResult.OK;
                        // 关闭窗口
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

        private void btnAddToOrganize_Click(object sender, EventArgs e)
        {
            // 把当前的用户信息传递过去
            FrmUserAddToOrganize frmUserAddToOrganize = new FrmUserAddToOrganize(this.EntityId);
            if (frmUserAddToOrganize.ShowDialog() == DialogResult.OK)
            {
                this.GetUserOrganizeList();
                this.SetControlState();
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in grdUserOrganize.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }
            //foreach (DataRow dataRow in this.DTUserOrganize.Rows)
            //{
            //    dataRow["colSelected"] = true.ToString();
            //}
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in grdUserOrganize.Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value??false);
            }

            //foreach (DataRow dataRow in this.DTUserOrganize.Rows)
            //{
            //    if (dataRow["colSelected"].ToString() == true.ToString())
            //    {
            //        dataRow["colSelected"] = false.ToString();
            //    }
            //    else
            //    {
            //        dataRow["colSelected"] = true.ToString();
            //    }
            //}
        }

        #region private string[] GetSelecteIds() 获得已被选中主键数组
        /// <summary>
        /// 获得已被选中主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelecteIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdUserOrganize, BaseRoleEntity.FieldId, "colSelected", true);
        }
        #endregion

        #region private int BatchRemove() 批量移出
        /// <summary>
        /// 批量移出
        /// </summary>
        /// <returns>影响行数</returns>
        private int BatchRemove()
        {
            return DotNetService.Instance.UserService.BatchDeleteUserOrganize(UserInfo, this.GetSelecteIds());
        }
        #endregion

        #region private BaseStaffEntity GetStaffEntity() 从用户信息获取员工信息
        /// <summary>
        /// 员工信息
        /// </summary>
        /// <returns>实体</returns>
        private BaseStaffEntity GetStaffEntity()
        {
            this.staffEntity.Code = this.userEntity.Code;
            this.staffEntity.UserName = this.userEntity.UserName;
            this.staffEntity.RealName = this.userEntity.RealName;
            this.staffEntity.Birthday = this.userEntity.Birthday;
            this.staffEntity.CompanyId = this.userEntity.CompanyId;
            this.staffEntity.DepartmentId = this.userEntity.DepartmentId;
            this.staffEntity.Email = this.userEntity.Email;
            this.staffEntity.Gender = this.userEntity.Gender;
            this.staffEntity.Mobile = this.userEntity.Mobile;
            this.staffEntity.OICQ = this.userEntity.OICQ;
            this.staffEntity.Telephone = this.userEntity.Telephone;
            return this.staffEntity;
        }
        #endregion

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdUserOrganize, "colSelected"))
            {
                if (MessageBox.Show(AppMessage.MSG0075, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    // 设置鼠标繁忙状态，并保留原先的状态
                    Cursor holdCursor = this.Cursor;
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        int returnValue = this.BatchRemove();
                        // 重新加载数据，先刷新屏幕，再显示提示信息
                        this.GetUserOrganizeList();
                        this.SetControlState();
                        // 是否需要有提示信息？
                        if (BaseSystemInfo.ShowInformation)
                        {
                            // 批量保存，进行提示
                            MessageBox.Show(AppMessage.Format(AppMessage.MSG0077, returnValue.ToString()), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }

        private void btnSetPassword_Click(object sender, EventArgs e)
        {
            FrmUserSetPassword frmUserSetPassword = new FrmUserSetPassword(new string[] { this.userEntity.Id.ToString()});
            frmUserSetPassword.ShowDialog(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }    
}