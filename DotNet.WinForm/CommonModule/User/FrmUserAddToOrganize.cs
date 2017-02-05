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
    /// FrmUserOrganize
    /// 用户帐号-组织机构关联关系设置。
    /// 
    /// 修改纪录
    /// 
    ///     2010.09.25 版本：1.0 JiRiGaLa 创建。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.09.25</date>
    /// </author>
    public partial class FrmUserAddToOrganize : BaseForm
    {
        private string userId = string.Empty;
        /// <summary>
        /// 目标用户主键
        /// </summary>
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public FrmUserAddToOrganize(string userId):this()
        {
            this.UserId = userId;
        }

        public FrmUserAddToOrganize()
        {
            InitializeComponent();
        }

        #region private void BindItemDetails() 绑定下拉筐数据
        /// <summary>
        /// 绑定下拉筐数据
        /// </summary>
        private void BindItemDetails()
        {
            // 绑定类型数据
            DataTable dataTable = DotNetService.Instance.UserService.GetRoleDT(this.UserInfo);
            // 只获取职位栏目，是一个过滤条件，也可以是一个视图
            BaseBusinessLogic.SetFilter(dataTable, BaseRoleEntity.FieldCategoryCode, "Duty");
            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbRole.DisplayMember = BaseRoleEntity.FieldRealName;
            this.cmbRole.ValueMember = BaseRoleEntity.FieldId;
            this.cmbRole.DataSource = dataTable.DefaultView;
            
            // 默认是本公司的，本部门的员工的用户帐户，为了提高友善性，一般是帮自己部门的人申请帐号
            // this.ucCompany.SelectedId = this.UserInfo.CompanyId;
            // this.ucCompany.SelectedFullName = this.UserInfo.CompanyName;
            // this.ucDepartment.SelectedId = this.UserInfo.DepartmentId;
            // this.ucDepartment.SelectedFullName = this.UserInfo.DepartmentName;
            // this.ucWorkgroup.SelectedId = this.UserInfo.WorkgroupId;
            // this.ucWorkgroup.SelectedFullName = this.UserInfo.WorkgroupName;
            // 默认打开的公司
            this.ucDepartment.OpenId = this.UserInfo.CompanyId;
            this.ucWorkgroup.OpenId = this.UserInfo.DepartmentId;
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
            this.ucDepartment.AllowNull = true;
            this.ucDepartment.CanEdit = false;
            this.ucWorkgroup.AllowNull = true;
            this.ucWorkgroup.CanEdit = false;
            // 当前用户是否系统管理员？
            this.chbEnabled.Enabled = this.UserInfo.IsAdministrator;
            this.chbEnabled.Checked = this.UserInfo.IsAdministrator;
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 绑定下拉筐数据
            this.BindItemDetails();
            // 获取用户信息
            this.ShwoEntity();
        }
        #endregion

        #region private BaseUserEntity ShwoEntity()
        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <returns>用户实体</returns>
        private BaseUserEntity ShwoEntity()
        {
            // 获取用户数据
            BaseUserEntity userEntity = DotNetService.Instance.UserService.GetEntity(this.UserInfo, this.UserId);
            this.txtUserName.Text = userEntity.UserName;
            this.txtRealName.Text = userEntity.RealName;
            return userEntity;
        }
        #endregion

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

        #region private BaseUserOrganizeEntity GetEntity()
        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <returns>用户实体</returns>
        private BaseUserOrganizeEntity GetEntity()
        {
            // 获取用户数据
            BaseUserOrganizeEntity userOrganizeEntity = new BaseUserOrganizeEntity();
            if (!string.IsNullOrEmpty(this.UserId))
            {
                userOrganizeEntity.UserId = int.Parse(this.UserId);
            }
            userOrganizeEntity.CompanyId = null;
            if (!string.IsNullOrEmpty(this.ucCompany.SelectedId))
            {
                userOrganizeEntity.CompanyId = int.Parse(this.ucCompany.SelectedId);
            }
            userOrganizeEntity.DepartmentId = null;
            if (!string.IsNullOrEmpty(this.ucDepartment.SelectedId))
            {
                userOrganizeEntity.DepartmentId = int.Parse(this.ucDepartment.SelectedId);
            }
            userOrganizeEntity.WorkgroupId = null;
            if (!string.IsNullOrEmpty(this.ucWorkgroup.SelectedId))
            {
                userOrganizeEntity.WorkgroupId = int.Parse(this.ucWorkgroup.SelectedId);
            }
            if (this.cmbRole.SelectedValue == null || this.cmbRole.SelectedValue.ToString().Length == 0)
            {
                userOrganizeEntity.RoleId = null;
            }
            else
            {
                userOrganizeEntity.RoleId = int.Parse(this.cmbRole.SelectedValue.ToString());
            }
            userOrganizeEntity.DeletionStateCode = 0;
            return userOrganizeEntity;
        }
        #endregion

        #region public virtual override CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        public override bool CheckInput()
        {
            // 总不能全空了吧？
            if (this.ucCompany.SelectedFullName.Length == 0)
            {
                MessageBox.Show(AppMessage.MSG0229, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ucCompany.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region private bool UserAddToOrganize() 申请帐号
        /// <summary>
        /// 申请帐号
        /// </summary>
        /// <returns>保存成功</returns>
        private bool UserAddToOrganize()
        {
            bool returnValue = false;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            BaseUserOrganizeEntity userOrganizeEntity = this.GetEntity();
            this.EntityId = DotNetService.Instance.UserService.AddUserToOrganize(this.UserInfo, userOrganizeEntity, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKAdd.ToString())
            {
                // 没审核通过的，才可以有提示信息
                if (BaseSystemInfo.ShowInformation && !this.chbEnabled.Checked)
                {
                    // 这里应该判断，申请帐号是否需要进行审核，若需要审核提示等待审核，否则直接提示成功信息。
                    // 添加成功，进行提示
                    MessageBox.Show(AppMessage.MSG0235, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                returnValue = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // 是否用户-组织机构重复了，提高友善性
                if (statusCode == StatusCode.Exist.ToString())
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0008, AppMessage.MSG9971), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return returnValue;
        }
        #endregion

        private void btnAddToOrganize_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                this.UserAddToOrganize();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }    
}