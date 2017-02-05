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
    /// FrmUserOrganizeBatchSet
    /// 用户所在部门设置。
    /// 
    /// 修改纪录
    /// 
    ///     2012-05-07 版本：3.71 Serwif 增加分公司代码、分公司名称
    ///     2012.04.23 版本：1.0 JiRiGaLa 创建。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.04.23</date>
    /// </author>
    public partial class FrmUserOrganizeBatchSet : BaseForm
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

        public FrmUserOrganizeBatchSet(string[] userIds)
            : this()
        {
            this.SelectedIds = userIds;
        }

        public FrmUserOrganizeBatchSet()
        {
            InitializeComponent();
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

        private void ucCompany_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                BaseUserManager userManager = new BaseUserManager(this.UserInfo);
                DataTable dtUser = userManager.GetDataTable(CurrentDbType.Access,this.SelectedIds);

                BaseUserEntity userEntity = null;
                foreach (DataRow dataRow in dtUser.Rows)
                {
                    userEntity = new BaseUserEntity(dataRow);
                    userEntity.CompanyId = this.ucCompany.SelectedId;
                    userEntity.CompanyName = this.ucCompany.SelectedFullName;
                    userEntity.SubCompanyId = this.ucSubCompany.SelectedId;
                    userEntity.SubCompanyName = this.ucSubCompany.SelectedFullName;
                    userEntity.DepartmentId = this.ucDepartment.SelectedId;
                    userEntity.DepartmentName = this.ucDepartment.SelectedFullName;
                    userEntity.WorkgroupId = this.ucWorkgroup.SelectedId;
                    userEntity.WorkgroupName = this.ucWorkgroup.SelectedFullName;
                    userManager.Update(userEntity);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }    
}