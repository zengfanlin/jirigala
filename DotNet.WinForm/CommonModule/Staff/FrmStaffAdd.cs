//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Utilities;
    using DotNet.Business;

    /// <summary>
    /// FrmStaffAdd.cs
    /// 员工管理-添加员工窗体
    ///		
    /// 修改记录
    /// 
    ///     2012.01.16 版本：2.4 JiRiGaLa  整理完善员工信息数据。
    ///     2011.09.05 版本：2.3 张广梁    解决无法添加员工的错误。
    ///     2010.12.07 版本：2.2 dfhjc     修改添加员工时，默认角色如果为空（没有选择）时出错，职务如果为空（没有选择）时出错（原因是没有判空串），员工照片如果为空不用到数据库中再执行一次
    ///     2010.04.08 版本: 2.1 JiRiGaLa  面向对象方式改进。
    ///     2007.06.06 版本: 2.0 JiRiGaLa  页面整理，功能改进。
    ///     2007.05.22 版本：1.0 JiRiGaLa  员工添加功能页面编写。
    ///		
    /// 版本：2.4
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.01.16</date>
    /// </author> 
    /// </summary>
    public partial class FrmStaffAdd : BaseForm
    {
        /// <summary>
        /// 员工实体
        /// </summary>
        public BaseStaffEntity staffEntity = null;

        /// <summary>
        /// 权限域编号（限制创建员工的范围用）
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        /// <summary>
        /// 被选中的公司主键
        /// </summary>
        public string CompanyId
        {
            get
            {
                return this.ucCompany.SelectedId;
            }
            set
            {
                this.ucCompany.SelectedId = value;
            }
        }

        /// <summary>
        /// 被选中的部门主键
        /// </summary>
        public string DepartmentId
        {
            get
            {
                return this.ucDepartment.SelectedId;
            }
            set
            {
                this.ucDepartment.SelectedId = value;
            }
        }

        /// <summary>
        /// 被选中的分支机构主键
        /// </summary>
        public string SubCompanyId
        {
            get
            {
                return this.ucSubCompany.SelectedId;
            }
            set
            {
                this.ucSubCompany.SelectedId = value;
            }
        }

        /// <summary>
        /// 被选中的工作组主键
        /// </summary>
        public string WorkGroupId
        {
            get
            {
                return this.ucWorkgroup.SelectedId;
            }
            set
            {
                this.ucWorkgroup.SelectedId = value;
            }
        }

        public FrmStaffAdd()
        {
            InitializeComponent();
        }

        public FrmStaffAdd(BaseStaffEntity entity)
            : this()
        {
            this.staffEntity = entity;
        }

        #region public FrmStaffAdd(string companyId, string subCompanyId, string departmentId, string workgroupId) : this() 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="companyId">公司主键</param>
        /// <param name="subCompanyId">分公司主键</param>
        /// <param name="departmentId">部门主键</param>
        /// <param name="workgroupId">工作组主键</param>
        public FrmStaffAdd(string companyId, string subCompanyId, string departmentId, string workgroupId)
            : this()
        {
            this.CompanyId = companyId;
            this.SubCompanyId = subCompanyId;
            this.DepartmentId = departmentId;
            this.WorkGroupId = workgroupId;
        }
        #endregion

        #region private void BindItemDetails() 绑定下拉筐数据
        /// <summary>
        /// 绑定下拉筐数据
        /// </summary>
        private void BindItemDetails()
        {
            DataTable dataTable = null;
            DataRow dataRow = null;

            // 绑定性别数据
            dataTable = DotNetService.Instance.ItemDetailsService.GetDataTableByCode(UserInfo, "Gender");
            dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbGender.DisplayMember = BaseItemDetailsEntity.FieldItemValue;
            this.cmbGender.ValueMember = BaseItemDetailsEntity.FieldItemValue;
            this.cmbGender.DataSource = dataTable.DefaultView;

            // 绑定政治面貌数据
            dataTable = DotNetService.Instance.ItemDetailsService.GetDataTableByCode(UserInfo, "Party");
            dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbParty.DisplayMember = BaseItemDetailsEntity.FieldItemValue;
            this.cmbParty.ValueMember = BaseItemDetailsEntity.FieldItemValue;
            this.cmbParty.DataSource = dataTable.DefaultView;

            // 绑定民族数据
            dataTable = DotNetService.Instance.ItemDetailsService.GetDataTableByCode(UserInfo, "Nationality");
            dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbNationality.DisplayMember = BaseItemDetailsEntity.FieldItemValue;
            this.cmbNationality.ValueMember = BaseItemDetailsEntity.FieldItemValue;
            this.cmbNationality.DataSource = dataTable.DefaultView;

            // 绑定职位数据，这里要绑定主键
            dataTable = DotNetService.Instance.ItemDetailsService.GetDataTableByCode(UserInfo, "Duty");
            dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbDuty.DisplayMember = BaseItemDetailsEntity.FieldItemName;
            this.cmbDuty.ValueMember = BaseItemDetailsEntity.FieldId;
            this.cmbDuty.DataSource = dataTable.DefaultView;

            // 绑定职称数据，这里要绑定主键
            dataTable = DotNetService.Instance.ItemDetailsService.GetDataTableByCode(UserInfo, "Title");
            dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbTitle.DisplayMember = BaseItemDetailsEntity.FieldItemName;
            this.cmbTitle.ValueMember = BaseItemDetailsEntity.FieldId;
            this.cmbTitle.DataSource = dataTable.DefaultView;

            // 绑定用工性质数据
            dataTable = DotNetService.Instance.ItemDetailsService.GetDataTableByCode(UserInfo, "WorkingProperty");
            dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbWorkingProperty.DisplayMember = BaseItemDetailsEntity.FieldItemValue;
            this.cmbWorkingProperty.ValueMember = BaseItemDetailsEntity.FieldItemValue;
            this.cmbWorkingProperty.DataSource = dataTable.DefaultView;

            // 绑定用学历据
            dataTable = DotNetService.Instance.ItemDetailsService.GetDataTableByCode(UserInfo, "Education");
            dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbEducation.DisplayMember = BaseItemDetailsEntity.FieldItemValue;
            this.cmbEducation.ValueMember = BaseItemDetailsEntity.FieldItemValue;
            this.cmbEducation.DataSource = dataTable.DefaultView;

            // 绑定用学历据
            dataTable = DotNetService.Instance.ItemDetailsService.GetDataTableByCode(UserInfo, "Degree");
            dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbDegree.DisplayMember = BaseItemDetailsEntity.FieldItemValue;
            this.cmbDegree.ValueMember = BaseItemDetailsEntity.FieldItemValue;
            this.cmbDegree.DataSource = dataTable.DefaultView;

            // 绑定用户类型数据
            dataTable = DotNetService.Instance.RoleService.GetDefaultRoleDT(UserInfo);
            // 若不是系统管理员，那就只能增加普通员工
            if (!UserInfo.IsAdministrator)
            {
                for (int i = dataTable.Rows.Count - 1; i >= 0; i--)
                {
                    string role = dataTable.Rows[i][BaseRoleEntity.FieldId].ToString();
                    if (role != "User" && role != "Staff")
                    {
                        dataTable.Rows[i].Delete();
                    }
                }
                dataTable.AcceptChanges();
            }

            dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbRole.DisplayMember = BaseRoleEntity.FieldRealName;
            this.cmbRole.ValueMember = BaseRoleEntity.FieldId;
            this.cmbRole.DataSource = dataTable.DefaultView;
            // 绑定省
            this.BindProvince();
        }
        // 绑定省
        private void BindProvince()
        {
            List<KeyValuePair<string,object>> keyValuePairs=new List<KeyValuePair<string, object>>();
            keyValuePairs.Add(new KeyValuePair<string, object>(BaseItemsEntity.FieldParentId,null));
            keyValuePairs.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldIsInnerOrganize,0));
            keyValuePairs.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldDeletionStateCode,0));
            DataTable dataTable = DotNetService.Instance.OrganizeService.GetDataTable(this.UserInfo,keyValuePairs);
            dataTable.DefaultView.Sort = BaseOrganizeEntity.FieldId + " ASC ";
            DataRow dataRow = dataTable.NewRow();
            dataRow[BaseOrganizeEntity.FieldFullName] = "请选择省份";
            dataRow[BaseOrganizeEntity.FieldId] = -1;
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbProvince.DisplayMember = BaseOrganizeEntity.FieldFullName;
            this.cmbProvince.ValueMember = BaseOrganizeEntity.FieldId;
            this.cmbProvince.DataSource = dataTable.DefaultView;
        }
        // 绑定市
        private void BindCity()
        {
            string parentId = this.cmbProvince.SelectedValue.ToString();
            if (!String.IsNullOrEmpty(parentId))
            {
                DataTable dataTable = DotNetService.Instance.OrganizeService.GetDataTableByParent(this.UserInfo, parentId);
                dataTable.DefaultView.Sort = BaseOrganizeEntity.FieldId + " ASC ";
                DataRow dataRow = dataTable.NewRow();
                dataRow[BaseOrganizeEntity.FieldFullName] = "请选择城市";
                dataRow[BaseOrganizeEntity.FieldId] = -1;
                dataTable.Rows.InsertAt(dataRow, 0);
                this.cmbCity.DisplayMember = BaseOrganizeEntity.FieldFullName;
                this.cmbCity.ValueMember = BaseOrganizeEntity.FieldId;
                this.cmbCity.DataSource = dataTable.DefaultView;
            }
        }
        // 绑定区县
        private void BindArea()
        {
            string parentId = this.cmbCity.SelectedValue.ToString();
            if (!String.IsNullOrEmpty(parentId))
            {
                DataTable dataTable = DotNetService.Instance.OrganizeService.GetDataTableByParent(this.UserInfo, parentId);
                dataTable.DefaultView.Sort = BaseOrganizeEntity.FieldId + " ASC ";
                DataRow dataRow = dataTable.NewRow();
                dataRow[BaseOrganizeEntity.FieldFullName] = "请选择区县";
                dataRow[BaseOrganizeEntity.FieldId] = -1;
                dataTable.Rows.InsertAt(dataRow, 0);
                this.cmbArea.DisplayMember = BaseOrganizeEntity.FieldFullName;
                this.cmbArea.ValueMember = BaseOrganizeEntity.FieldId;
                this.cmbArea.DataSource = dataTable.DefaultView;
            }
        }
        #endregion

        #region private void BindData() 绑定下拉筐数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            // 绑定公司数据
            if (String.IsNullOrEmpty(this.ucCompany.SelectedId))
            {
                this.ucCompany.SelectedId = UserInfo.DepartmentId;
                this.ucCompany.SelectedFullName = UserInfo.DepartmentName;
            }
            if (String.IsNullOrEmpty(this.ucDepartment.SelectedId))
            {
                this.ucDepartment.SelectedId = UserInfo.CompanyId;
                this.ucDepartment.SelectedFullName = UserInfo.CompanyName;
            }
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // 按组织机构管理来增加员工
            this.ucCompany.AllowNull = false;
            this.ucCompany.PermissionItemScopeCode = this.PermissionItemScopeCode;
            this.ucDepartment.AllowNull = false;
            this.ucDepartment.PermissionItemScopeCode = this.PermissionItemScopeCode;

            // 是否创建用户
            this.txtUserName.Enabled = this.chbCreateUser.Checked;
            this.txtPassword.Enabled = this.chbCreateUser.Checked;
            this.lblUserNameReq.Visible = this.chbCreateUser.Checked;

            this.txtConfirmPassword.Enabled = this.chbCreateUser.Checked;
            this.cmbRole.Enabled = this.chbCreateUser.Checked;

            if (this.chbCreateUser.Checked)
            {
                this.lblUserNameReq.Visible = true;
                // 密码强度检查
                if (BaseSystemInfo.CheckPasswordStrength)
                {
                    this.lblPasswordReq.Visible = true;
                    this.lblConfirmPasswordReq.Visible = true;
                }
                else
                {
                    this.lblPasswordReq.Visible = false;
                    this.lblConfirmPasswordReq.Visible = false;
                }
            }
            else
            {
                this.lblUserNameReq.Visible = false;
                this.lblPasswordReq.Visible = false;
                this.lblConfirmPasswordReq.Visible = false;
            }
        }
        #endregion

        #region public override void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public override void ShowEntity()
        {
            if (this.staffEntity != null)
            {
                this.txtRealName.Text = staffEntity.RealName;
                this.txtCode.Text = staffEntity.Code;
                this.cmbGender.SelectedValue = staffEntity.Gender;
                this.cmbParty.SelectedValue = staffEntity.Party;
                // 将类转显示到页面
                if (staffEntity.CompanyId != null)
                {
                    this.ucCompany.SelectedId = staffEntity.CompanyId;
                }
                if (staffEntity.SubCompanyId != null)
                {
                    this.ucSubCompany.SelectedId = staffEntity.SubCompanyId;
                }
                if (staffEntity.DepartmentId != null)
                {
                    this.ucDepartment.SelectedId = staffEntity.DepartmentId;
                }
                if (staffEntity.WorkgroupId != null)
                {
                    this.ucWorkgroup.SelectedId = staffEntity.WorkgroupId;
                }
                this.cmbWorkingProperty.SelectedValue = staffEntity.WorkingProperty;
                this.txtOfficePhone.Text = staffEntity.OfficePhone;
                this.txtMobile.Text = staffEntity.Mobile;
                this.txtShortNumber.Text = staffEntity.ShortNumber;
                this.txtOICQ.Text = staffEntity.OICQ;
                this.txtUserName.Text = staffEntity.UserName;
                this.chbEnabled.Checked = staffEntity.Enabled == 1;
                this.cmbNationality.SelectedValue = staffEntity.Nationality;
                this.txtIdCard.Text = staffEntity.IDCard;
                this.txtBankCode.Text = staffEntity.BankCode;
                this.txtEmail.Text = staffEntity.Email;
                this.txtSchool.Text = staffEntity.School;
                this.txtMajor.Text = staffEntity.Major;
                this.cmbEducation.SelectedValue = staffEntity.Education;
                this.cmbDegree.SelectedValue = staffEntity.Degree;
                this.txtHomeAddress.Text = staffEntity.HomeAddress;
                this.txtHomePhone.Text = staffEntity.HomePhone;
                this.txtEmergencyContact.Text = staffEntity.EmergencyContact;
                this.txtDescription.Text = staffEntity.Description;
            }
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 权限信息
            // this.DTStaff = DotNetService.Instance.StaffService.Get(UserInfo, this.EntityId);s
            // 绑定下拉筐数据
            this.BindItemDetails();
            // 显示内容
            this.ShowEntity();
            // 绑定数据
            this.BindData();
        }
        #endregion

        private void SetCompany(string companyId)
        {
            // 设置部门与公司的联动功能
            this.ucDepartment.OpenId = companyId;
        }

        private void chbIsUser_CheckedChanged(object sender, EventArgs e)
        {
            this.SetControlState();
        }

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        public override bool CheckInput()
        {
            bool returnValue = true;
            this.txtRealName.Text = this.txtRealName.Text.TrimEnd();
            if (this.txtRealName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9978), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtRealName.Focus();
                return false;
            }

            if (this.ucCompany.SelectedId == null)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9900), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ucCompany.Focus();
                return false;
            }
            if ((this.ucDepartment.SelectedId == null))
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9901), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ucDepartment.Focus();
                return false;
            }

            if (this.chbCreateUser.Checked)
            {
                this.txtUserName.Text = this.txtUserName.Text.TrimEnd();
                if (this.txtUserName.Text.Trim().Length == 0)
                {
                    MessageBox.Show(AppMessage.MSG0223, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtUserName.Focus();
                    return false;
                }
                //if (this.cmbRole.SelectedValue == null || this.cmbRole.SelectedValue.ToString() == "")
                //{
                //    MessageBox.Show("默认角色不能为空。", AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    this.cmbRole.Focus();
                //    return false;
                //}
                // 密码强度检查
                if (this.lblPasswordReq.Visible)
                {
                    if (this.txtConfirmPassword.Text != this.txtPassword.Text)
                    {
                        MessageBox.Show(AppMessage.Format(AppMessage.MSG0039, AppMessage.MSG9964, AppMessage.MSG9960), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtPassword.Clear();
                        this.txtConfirmPassword.Clear();
                        this.txtPassword.Focus();
                        return false;
                    }
                }
            }
            return returnValue;
        }
        #endregion

        /// <summary>
        /// 员工信息
        /// </summary>
        /// <returns>实体</returns>
        private BaseStaffEntity GetStaffEntity()
        {
            BaseStaffEntity staffEntity = new BaseStaffEntity();
            staffEntity.RealName = this.txtRealName.Text;
            if (this.cmbGender.SelectedValue == null)
            {
                staffEntity.Gender = null;
            }
            else
            {
                staffEntity.Gender = this.cmbGender.SelectedValue.ToString();
            }
            if (this.dtpBirthday.Checked)
            {
                staffEntity.Birthday = this.dtpBirthday.Value.ToString(BaseSystemInfo.DateFormat);
            }
            else
            {
                staffEntity.Birthday = null;
            }
            staffEntity.Code = this.txtCode.Text;
            staffEntity.Party = null;
            if (this.cmbParty.SelectedValue != null && this.cmbParty.SelectedValue.ToString() != "")
            {
                staffEntity.Party = this.cmbParty.SelectedValue.ToString();
            }
            staffEntity.Nationality = null;
            if (this.cmbNationality.SelectedValue != null && this.cmbNationality.SelectedValue.ToString() != "")
            {
                staffEntity.Nationality = this.cmbNationality.SelectedValue.ToString();
            }
            staffEntity.CompanyId = null;
            if (!string.IsNullOrEmpty(this.ucCompany.SelectedId))
            {
                staffEntity.CompanyId = this.ucCompany.SelectedId;
            }
            staffEntity.SubCompanyId = null;
            if (!string.IsNullOrEmpty(this.ucSubCompany.SelectedId))
            {
                staffEntity.SubCompanyId = this.ucSubCompany.SelectedId;
            }
            staffEntity.DepartmentId = null;
            if (!string.IsNullOrEmpty(this.ucDepartment.SelectedId))
            {
                staffEntity.DepartmentId = this.ucDepartment.SelectedId;
            }
            staffEntity.WorkgroupId = null;
            if (!string.IsNullOrEmpty(this.ucWorkgroup.SelectedId))
            {
                staffEntity.WorkgroupId = this.ucWorkgroup.SelectedId;
            }
            staffEntity.DutyId = null;
            if (this.cmbDuty.SelectedValue != null && this.cmbDuty.SelectedValue.ToString() != "")
            {
                staffEntity.DutyId = this.cmbDuty.SelectedValue.ToString();
            }
            staffEntity.TitleId = null;
            if (this.cmbTitle.SelectedValue != null && this.cmbTitle.SelectedValue.ToString() != "")
            {
                staffEntity.TitleId = this.cmbTitle.SelectedValue.ToString();
            }
            if (this.dtpWorkingDate.Checked)
            {
                staffEntity.WorkingDate = this.dtpWorkingDate.Value.ToString(BaseSystemInfo.DateFormat);
            }
            else
            {
                staffEntity.WorkingDate = null;
            }
            if (this.dtpJoinInDate.Checked)
            {
                staffEntity.JoinInDate = this.dtpJoinInDate.Value.ToString(BaseSystemInfo.DateFormat);
            }
            else
            {
                staffEntity.JoinInDate = null;
            }
            staffEntity.IDCard = this.txtIdCard.Text;
            staffEntity.WorkingProperty = null;
            if (this.cmbWorkingProperty.SelectedValue != null && this.cmbWorkingProperty.SelectedValue.ToString() != "")
            {
                staffEntity.WorkingProperty = this.cmbWorkingProperty.SelectedValue.ToString();
            }
            staffEntity.OICQ = this.txtOICQ.Text;
            staffEntity.OfficePhone = this.txtOfficePhone.Text;
            staffEntity.ShortNumber = this.txtShortNumber.Text;
            staffEntity.Email = this.txtEmail.Text;
            staffEntity.Mobile = this.txtMobile.Text;
            staffEntity.School = this.txtSchool.Text;
            staffEntity.Major = this.txtMajor.Text;
            staffEntity.Education = null;
            if (this.cmbEducation.SelectedValue != null && this.cmbEducation.SelectedValue.ToString() != "")
            {
                staffEntity.Education = this.cmbEducation.SelectedValue.ToString();
            }
            staffEntity.Degree = null;
            if (this.cmbDegree.SelectedValue != null && this.cmbDegree.SelectedValue.ToString() != "")
            {
                staffEntity.Degree = this.cmbDegree.SelectedValue.ToString();
            }
            staffEntity.BankCode = this.txtBankCode.Text;
            staffEntity.UserName = this.txtUserName.Text;
            staffEntity.HomeAddress = this.txtHomeAddress.Text;
            staffEntity.HomePhone = this.txtHomePhone.Text;
            staffEntity.CarCode = this.txtCarCode.Text;
            staffEntity.EmergencyContact = this.txtEmergencyContact.Text;
            staffEntity.Description = this.txtDescription.Text;
            staffEntity.DeletionStateCode = 0;
            staffEntity.Enabled = this.chbEnabled.Checked ? 1 : 0;
            if (this.cmbProvince.SelectedValue.ToString() != "-1")
                staffEntity.Province = this.cmbProvince.Text;
            else
            {
                staffEntity.Province = string.Empty;
            }
            if (this.cmbCity.SelectedValue.ToString() != "-1")
                staffEntity.City = this.cmbCity.Text;
            else
            {
                staffEntity.City = string.Empty;
            }
            if (this.cmbArea.SelectedValue.ToString() != "-1")
                staffEntity.Area = this.cmbArea.Text;
            else
            {
                staffEntity.Area = string.Empty;
            }
            return staffEntity;
        }

        private void txtRealName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtUserName.Text))
            {
                this.txtUserName.Text = StringUtil.GetPinyin(this.txtRealName.Text);
                // this.txtUserName.Text = StringUtil.GetFirstPinyin(this.txtRealName.Text);
            }
        }

        private void txtRealName_DoubleClick(object sender, EventArgs e)
        {
            this.txtUserName.Text = this.txtRealName.Text;
        }

        private void txtCode_DoubleClick(object sender, EventArgs e)
        {
            this.txtUserName.Text = this.txtCode.Text;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns>实体</returns>
        private BaseUserEntity GetUserEntity()
        {
            BaseUserEntity userEntity = new BaseUserEntity();
            userEntity.RealName = this.txtRealName.Text;
            if (this.cmbGender.SelectedValue != null)
            {
                userEntity.Gender = this.cmbGender.Text;
            }
            if (!string.IsNullOrEmpty(this.ucCompany.SelectedId))
            {
                userEntity.CompanyId = this.ucCompany.SelectedId;
                userEntity.CompanyName = this.ucCompany.SelectedFullName;
            }
            if (!string.IsNullOrEmpty(this.ucDepartment.SelectedId))
            {
                userEntity.DepartmentId = this.ucDepartment.SelectedId;
                userEntity.DepartmentName = this.ucDepartment.SelectedFullName;
            }
            if (!string.IsNullOrEmpty(this.ucWorkgroup.SelectedId))
            {
                userEntity.WorkgroupId = this.ucWorkgroup.SelectedId;
                userEntity.WorkgroupName = this.ucWorkgroup.SelectedFullName;
            }
            userEntity.Code = this.txtCode.Text;
            userEntity.Email = this.txtEmail.Text;
            userEntity.Mobile = this.txtMobile.Text;
            userEntity.OICQ = this.txtOICQ.Text;
            userEntity.UserName = this.txtUserName.Text;
            userEntity.Telephone = this.txtOfficePhone.Text;
            if (this.dtpBirthday.Checked)
            {
                userEntity.Birthday = this.dtpBirthday.Value.ToString(BaseSystemInfo.DateFormat);
            }
            else
            {
                userEntity.Birthday = null;
            }
            // 是否系统管理员有关系，是系统管理员才能用户生效
            if (this.cmbRole.SelectedValue != null && this.cmbRole.SelectedValue.ToString() != "")
            {
                userEntity.RoleId = this.cmbRole.SelectedValue.ToString();
            }
            userEntity.UserPassword = this.txtPassword.Text;
            userEntity.Enabled = this.chbEnabled.Checked ? 1 : 0;
            userEntity.Description = this.txtDescription.Text;
            userEntity.IsStaff = 1;
            userEntity.DeletionStateCode = 0;
            return userEntity;
        }

        #region private bool SaveEntity() 保存
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns>保存成功</returns>
        private bool SaveEntity(bool closeForm)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            bool returnValue = true;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            // 转换数据
            try
            {
                // 先处理是否创建了用户
                string userId = string.Empty;
                if (this.chbCreateUser.Checked)
                {
                    BaseUserEntity userEntity = this.GetUserEntity();
                    userId = DotNetService.Instance.UserService.AddUser(UserInfo, userEntity, out statusCode, out statusMessage);
                    if (statusCode != StatusCode.OKAdd.ToString())
                    {
                        MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // 是否编号重复了，提高友善性
                        if (statusCode == StatusCode.ErrorCodeExist.ToString())
                        {
                            this.txtCode.SelectAll();
                            this.txtCode.Focus();
                        }
                        // 是否用户名重复了，提高友善性
                        if (statusCode == StatusCode.ErrorUserExist.ToString())
                        {
                            this.txtUserName.SelectAll();
                            this.txtUserName.Focus();
                        }
                        returnValue = false;
                    }

                    // 判断如果不能创建用户直接退出
                    if (returnValue == false)
                    {
                        return returnValue;
                    }
                }
                // 再处理员工信息
                BaseStaffEntity staffEntity = this.GetStaffEntity();
                if (this.chbCreateUser.Checked)
                {
                    staffEntity.UserId = int.Parse(userId);
                }
                this.EntityId = DotNetService.Instance.StaffService.AddStaff(UserInfo, staffEntity, out statusCode, out statusMessage);
                // 添加员工的照片
                if (!string.IsNullOrEmpty(this.EntityId))
                {
                    string pictureContent = string.Empty;
                    pictureContent = this.ucPicture.Upload("StaffPicture", this.EntityId);
                    //判断图片是否为空，如果为空说明没有图片不再执行  dfhjc
                    if (pictureContent != "")
                    {
                        DotNetService.Instance.ParameterService.SetParameter(UserInfo, "Staff", this.EntityId, "StaffPictureId", pictureContent);
                    }
                    this.Changed = true;
                }
                if (BaseSystemInfo.ShowInformation)
                {
                    // 添加成功，进行提示
                    MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (statusCode == StatusCode.OKAdd.ToString() && closeForm)
                {
                    // 自动关闭窗体了
                    this.DialogResult = DialogResult.OK;
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
            return returnValue;
        }
        #endregion

        private void ClearForm()
        {
            //如果是连续添加,则清空表单
            this.txtRealName.Text = string.Empty;
            this.txtUserName.Text = string.Empty;
            this.txtOfficePhone.Text = string.Empty;
            this.txtMobile.Text = string.Empty;
            this.txtShortNumber.Text = string.Empty;
            this.txtBankCode.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            this.txtEmergencyContact.Text = string.Empty;
            this.txtBankCode.Text = string.Empty;
            this.txtCode.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtHomeAddress.Text = string.Empty;
            this.txtHomePhone.Text = string.Empty;
            this.txtIdCard.Text = string.Empty;
            this.txtMajor.Text = string.Empty;
            this.txtOICQ.Text = string.Empty;
            this.txtSchool.Text = string.Empty;
            this.txtShortNumber.Text = string.Empty;
            this.ucCompany.Text = string.Empty;
            this.ucDepartment.Text = string.Empty;
            this.ucPicture.Text = string.Empty;
            this.ucSubCompany.Text = string.Empty;
            this.ucWorkgroup.Text = string.Empty;
            this.txtCarCode.Text = string.Empty;
            this.dtpBirthday.Text = string.Empty;
            this.dtpWorkingDate.Text = string.Empty;
            this.cmbEducation.Text = string.Empty;
            this.cmbDegree.Text = string.Empty;
            this.dtpJoinInDate.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
            this.txtConfirmPassword.Text = string.Empty;
            // 模仿清空图片
            this.ucPicture.DoClear();
        }

        private void btnGetMyDepartment_Click(object sender, EventArgs e)
        {
            // 默认是本公司的，本部门的员工的用户帐户，为了提高友善性，一般是帮自己部门的人申请帐号
            this.ucCompany.SelectedId = this.UserInfo.CompanyId;
            this.ucSubCompany.SelectedId = this.UserInfo.SubCompanyId;
            this.ucDepartment.SelectedId = this.UserInfo.DepartmentId;
            this.ucWorkgroup.SelectedId = this.UserInfo.WorkgroupId;
            // 默认打开的公司
            this.ucDepartment.OpenId = UserInfo.CompanyId;
            this.ucWorkgroup.OpenId = UserInfo.DepartmentId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 检查输入的有效性
            if (this.CheckInput())
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    //增加了保存成功后关闭窗体
                    if (this.SaveEntity(chkClose.Checked))
                    {
                        if (!chkClose.Checked)
                        {
                            this.ClearForm();
                        }
                        else
                        {
                            this.DialogResult = DialogResult.OK;
                            // 关闭窗口
                            this.Close();
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

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 检查输入的有效性
            if (this.CheckInput())
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    this.SaveEntity(true);
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

        private void cmbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindCity();
        }

        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindArea();
        }
    }
}