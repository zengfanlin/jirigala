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
    /// FrmStaffEdit.cs
    /// 员工管理-编辑员工窗体
    ///		
    /// 修改记录
    /// 
    ///     2012.01.16 版本：3.3 JiRiGaLa  完善员工信息表。
    ///     2011.03.19 版本：3.2 JiRiGaLa  整理代码。
    ///     2010.12.07 版本：3.1 JiRiGaLa  修改员工信息时照片删除问题。
    ///     2009.08.31 版本：2.1 JiRiGaLa  下拉框数据整理。
    ///     2009.04.27 版本：2.0 JiRiGaLa  主键整理。
    ///     2007.06.04 版本：1.0 JiRiGaLa  员工编辑功能页面编写。
    ///     2012.04.22 版本：1.0 zwd       修改新增类似数据的添加 新增 AddEntity()
    ///		
    /// 版本：3.2
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.03.19</date>
    /// </author> 
    /// </summary>
    public partial class FrmStaffEdit : BaseForm
    {
        /// <summary>
        /// 员工主键
        /// </summary>
        public string StaffId = string.Empty;

        /// <summary>
        /// 用户主键
        /// </summary>
        public string UserId = string.Empty;

        /// <summary>
        /// 权限域编号
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        // 从数据权限获得类
        BaseStaffEntity staffEntity = null;
        BaseUserEntity userEntity = null;

        public FrmStaffEdit()
        {
            InitializeComponent();
        }

        #region public FrmStaffEdit(string id) 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">主键</param>
        public FrmStaffEdit(string id): this()
        {
            this.StaffId = id;
        }
        #endregion

        #region public FrmStaffEdit(string staffId, string realName) : this(staffId)
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userId">主键</param>
        /// <param name="realName">名称</param>
        public FrmStaffEdit(string staffId, string realName) : this(staffId)
        {
            this.StaffId = staffId;
            this.Text = realName;
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

            // 绑定省份
            this.BindProvince();
        }

        // 绑定省
        private void BindProvince()
        {
            List<KeyValuePair<string, object>> keyValuePairs = new List<KeyValuePair<string, object>>();
            keyValuePairs.Add(new KeyValuePair<string, object>(BaseItemsEntity.FieldParentId, null));
            keyValuePairs.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldIsInnerOrganize, 0));
            keyValuePairs.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldDeletionStateCode, 0));
            DataTable dataTable = DotNetService.Instance.OrganizeService.GetDataTable(this.UserInfo, keyValuePairs);
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

        #region private BaseModuleEntity GetEntity() 转换数据
        /// <summary>
        /// 转换数据
        /// </summary>
        private BaseStaffEntity GetEntity()
        {
            staffEntity.RealName = this.txtRealName.Text;
            staffEntity.Code = this.txtCode.Text;
            if (this.cmbGender.SelectedValue == null)
            {
                staffEntity.Gender = string.Empty;
            }
            else
            {
                staffEntity.Gender = this.cmbGender.SelectedValue.ToString();
            }
            if (this.cmbParty.SelectedValue == null)
            {
                staffEntity.Party = string.Empty;
            }
            else
            {
                staffEntity.Party = this.cmbParty.SelectedValue.ToString();
            }
            // 将类转显示到页面
            if (string.IsNullOrEmpty(this.ucCompany.SelectedId))
            {
                staffEntity.CompanyId = null;
            }
            else
            {
                staffEntity.CompanyId = this.ucCompany.SelectedId;
            }
            if (string.IsNullOrEmpty(this.ucSubCompany.SelectedId))
            {
                staffEntity.SubCompanyId = null;
            }
            else
            {
                staffEntity.SubCompanyId = this.ucSubCompany.SelectedId;
            }
            if (string.IsNullOrEmpty(this.ucDepartment.SelectedId))
            {
                staffEntity.DepartmentId = null;
            }
            else
            {
                staffEntity.DepartmentId = this.ucDepartment.SelectedId;
            }
            if (string.IsNullOrEmpty(this.ucWorkgroup.SelectedId))
            {
                staffEntity.WorkgroupId = null;
            }
            else
            {
                staffEntity.WorkgroupId = this.ucWorkgroup.SelectedId;
            }
            if (this.cmbWorkingProperty.SelectedValue == null)
            {
                staffEntity.WorkingProperty = string.Empty;
            }
            else
            {
                staffEntity.WorkingProperty = this.cmbWorkingProperty.SelectedValue.ToString();
            }
            staffEntity.OfficePhone = this.txtOfficePhone.Text;
            staffEntity.Mobile = this.txtMobile.Text;
            staffEntity.ShortNumber = this.txtShortNumber.Text;
            staffEntity.OICQ = this.txtOICQ.Text;
            staffEntity.UserName = this.txtUserName.Text;
            if (this.cmbRole.SelectedValue == null)
            {
                staffEntity.CreateBy = string.Empty;
            }
            else
            {
                staffEntity.CreateBy = this.cmbRole.SelectedValue.ToString();
            }
            staffEntity.Enabled = this.chbEnabled.Checked ? 1 : 0;
            if (this.cmbNationality.SelectedValue == null)
            {
                staffEntity.Nationality = string.Empty;
            }
            else
            {
                staffEntity.Nationality = this.cmbNationality.SelectedValue.ToString();
            }
            if (this.cmbDuty.SelectedValue == null)
            {
                staffEntity.DutyId = string.Empty;
            }
            else
            {
                staffEntity.DutyId = this.cmbDuty.SelectedValue.ToString();
            }
            if (this.cmbTitle.SelectedValue == null)
            {
                staffEntity.TitleId = string.Empty;
            }
            else
            {
                staffEntity.TitleId = this.cmbTitle.SelectedValue.ToString();
            }
            staffEntity.IDCard = this.txtIdCard.Text;
            staffEntity.BankCode = this.txtBankCode.Text;
            staffEntity.Email = this.txtEmail.Text;
            staffEntity.School = this.txtSchool.Text;
            staffEntity.Major = this.txtMajor.Text;
            if (this.cmbEducation.SelectedValue == null)
            {
                staffEntity.Education = string.Empty;
            }
            else
            {
                staffEntity.Education = this.cmbEducation.SelectedValue.ToString();
            }
            if (this.cmbDegree.SelectedValue == null)
            {
                staffEntity.Degree = string.Empty;
            }
            else
            {
                staffEntity.Degree = this.cmbDegree.SelectedValue.ToString();
            }
            staffEntity.Education = this.cmbEducation.SelectedValue.ToString();
            staffEntity.HomeAddress = this.txtHomeAddress.Text;
            staffEntity.HomePhone = this.txtHomePhone.Text;
            staffEntity.EmergencyContact = this.txtEmergencyContact.Text;
            staffEntity.Description = this.txtDescription.Text;
            return staffEntity;
        }
        #endregion

        #region private void ShowStaffEntity() 显示内容
        /// <summary>
        /// 显示员工内容
        /// </summary>
        private void ShowStaffEntity()
        {
            if (this.staffEntity.Id == null)
            {
                return;
            }
            // 将类转显示到页面
            this.txtRealName.Text = this.staffEntity.RealName;
            // 性别
            if (!string.IsNullOrEmpty(this.staffEntity.Gender))
            {
                this.cmbGender.SelectedValue = this.staffEntity.Gender;
            }
            this.txtCode.Text = this.staffEntity.Code;
            if (!string.IsNullOrEmpty(this.staffEntity.Birthday))
            {
                this.dtpBirthday.Value = DateTime.Parse(this.staffEntity.Birthday);
                this.dtpBirthday.Checked = true;
            }
            if (!string.IsNullOrEmpty(this.staffEntity.GraduationDate))
            {
                this.dtpGraduationDate.Value = DateTime.Parse(this.staffEntity.GraduationDate);
                this.dtpGraduationDate.Checked = true;
            }
            if (!string.IsNullOrEmpty(this.staffEntity.Party))
            {
                this.cmbParty.SelectedValue = this.staffEntity.Party;
            }
            if (!string.IsNullOrEmpty(this.staffEntity.Nationality))
            {
                this.cmbNationality.SelectedValue = this.staffEntity.Nationality;
            }
            if (this.staffEntity.CompanyId != null)
            {
                this.ucCompany.SelectedId = this.staffEntity.CompanyId;
            }
            if (this.staffEntity.SubCompanyId != null)
            {
                this.ucSubCompany.SelectedId = this.staffEntity.SubCompanyId;
            }
            if (this.staffEntity.DepartmentId != null)
            {
                this.ucDepartment.SelectedId = this.staffEntity.DepartmentId;
            }
            if (this.staffEntity.WorkgroupId != null)
            {
                this.ucWorkgroup.SelectedId = this.staffEntity.WorkgroupId;
            }
            if (!string.IsNullOrEmpty(this.staffEntity.DutyId))
            {
                this.cmbDuty.SelectedValue = this.staffEntity.DutyId;
            }
            if (!string.IsNullOrEmpty(this.staffEntity.TitleId))
            {
                this.cmbTitle.SelectedValue = this.staffEntity.TitleId;
            }
            if (!string.IsNullOrEmpty(this.staffEntity.WorkingDate))
            {
                this.dtpWorkingDate.Value = DateTime.Parse(this.staffEntity.WorkingDate);
                this.dtpWorkingDate.Checked = true;
            }
            if (!string.IsNullOrEmpty(this.staffEntity.JoinInDate))
            {
                this.dtpJoinInDate.Value = DateTime.Parse(this.staffEntity.JoinInDate);
                this.dtpJoinInDate.Checked = true;
            }
            if (!string.IsNullOrEmpty(this.staffEntity.WorkingProperty))
            {
                this.cmbWorkingProperty.SelectedValue = this.staffEntity.WorkingProperty;                
            }
            this.txtIdCard.Text = this.staffEntity.IDCard;
            this.txtOICQ.Text = this.staffEntity.OICQ;
            this.txtOfficePhone.Text = this.staffEntity.OfficePhone;
            this.txtShortNumber.Text = this.staffEntity.ShortNumber;
            this.txtEmail.Text = this.staffEntity.Email;
            this.txtMobile.Text = this.staffEntity.Mobile;
            this.txtBankCode.Text = this.staffEntity.BankCode;
            this.txtIdentificationCode.Text = this.staffEntity.IdentificationCode;
            this.txtSchool.Text = this.staffEntity.School;
            this.txtMajor.Text = this.staffEntity.Major;
            if (!string.IsNullOrEmpty(this.staffEntity.Education))
            {
                this.cmbEducation.SelectedValue = this.staffEntity.Education;
            }
            if (!string.IsNullOrEmpty(this.staffEntity.Degree))
            {
                this.cmbDegree.SelectedValue = this.staffEntity.Degree;
            }
            this.txtHomeAddress.Text = this.staffEntity.HomeAddress;
            this.txtHomePhone.Text = this.staffEntity.HomePhone;
            this.txtCarCode.Text = this.staffEntity.CarCode;
            this.txtEmergencyContact.Text = this.staffEntity.EmergencyContact;
            this.chbEnabled.Checked = this.staffEntity.Enabled == 1;
            this.txtDescription.Text = this.staffEntity.Description;
            if (!string.IsNullOrEmpty(staffEntity.Province))
                this.cmbProvince.SelectedIndex=this.cmbProvince.FindString(staffEntity.Province);
            if (!string.IsNullOrEmpty(staffEntity.City))
                this.cmbCity.SelectedIndex=this.cmbCity.FindString(staffEntity.City);
            if (!string.IsNullOrEmpty(staffEntity.Area))
                this.cmbArea.SelectedIndex=this.cmbArea.FindString(staffEntity.Area);
            this.chbCreateUser.Checked = false;
            // 显示用户信息部分
            if (this.staffEntity.UserId != null)
            {
                // 加载用户
                this.userEntity = DotNetService.Instance.UserService.GetEntity(UserInfo, this.staffEntity.UserId.ToString());
                // 判断是否被删除的用户
                if (this.userEntity.Id == null || this.userEntity.DeletionStateCode == 1)
                {
                    // 若用户是被物理删除了，找不到相应的用户信息了
                    this.staffEntity.UserId = null;
                }
                else
                {
                    // 显示用户内容
                    this.ShowUserEntity();
                }
            }
            // 获取图片部分，显示图片部分
            string fileId = DotNetService.Instance.ParameterService.GetParameter(UserInfo, "Staff", this.staffEntity.Id.ToString(), "StaffPictureId");
            if (!String.IsNullOrEmpty(fileId))
            {
                this.ucPicture.PictureId = fileId;
            }
            this.txtUserName.Text = this.staffEntity.UserName;
            if (staffEntity.UserId != null && staffEntity.UserId > 0)
            {
                this.UserId = staffEntity.UserId.ToString();
                this.userEntity = DotNetService.Instance.UserService.GetEntity(UserInfo, this.UserId);
                this.ShowUserEntity();
            }
        }
        #endregion

        #region private void ShowUserEntity() 显示用户数据
        /// <summary>
        /// 显示用户数据
        /// </summary>
        private void ShowUserEntity()
        {
            this.chbCreateUser.Checked = true;
            // 在页面上显示
            // this.txtMobile.Text = this.userEntity.Mobile;
            // this.txtEmail.Text = this.userEntity.Email;
            // this.txtOICQ.Text = this.userEntity.OICQ;
            this.txtUserName.Text = this.userEntity.UserName;
            if (!string.IsNullOrEmpty(this.userEntity.RoleId))
            {
                this.cmbRole.SelectedValue = this.userEntity.RoleId;
            }
            /*
            this.ucCompany.SelectedFullName = this.userEntity.CompanyName;
            this.ucDepartment.SelectedFullName = this.userEntity.DepartmentName;
            this.ucWorkgroup.SelectedFullName = this.userEntity.WorkgroupName;
            */
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // 这里要限制组织机构的选择范围
            this.ucCompany.AllowNull = false;
            this.ucCompany.PermissionItemScopeCode = this.PermissionItemScopeCode;
            this.ucDepartment.AllowNull = true;
            this.ucDepartment.PermissionItemScopeCode = this.PermissionItemScopeCode;
            
            // 若用户没有创建，没有必要设置权限
            this.btnSetStaffUser.Enabled = true; // 无论什么时候都可以设置关联
            this.btnUserProperty.Enabled = this.staffEntity.UserId > 0;
            this.btnUpdateUser.Enabled = this.staffEntity.UserId > 0;
            this.btnUserPermission.Enabled = this.staffEntity.UserId > 0;
            this.btnDeleteStaffUser.Enabled = this.staffEntity.UserId > 0;
            
            // 是否创建用户
            this.chbCreateUser.Checked = this.staffEntity.UserId > 0;
            this.chbCreateUser.Enabled = this.staffEntity.UserId > 0;
            this.txtUserName.Enabled = this.chbCreateUser.Checked;
            this.lblUserNameReq.Visible = this.chbCreateUser.Checked;
            this.cmbRole.Enabled = this.chbCreateUser.Checked;
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
            this.staffEntity = DotNetService.Instance.StaffService.GetEntity(UserInfo, this.StaffId);
            // 显示内容
            this.ShowStaffEntity();
        }
        #endregion        

        private void SetCompany(string CompanyId)
        {
            this.ucDepartment.OpenId = CompanyId;
        }

        private void SetDepartment(string DepartmentId)
        {
            this.ucWorkgroup.OpenId = DepartmentId;
        }

        private void chbIsUser_CheckedChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                this.SetControlState();
            }
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
            }
            return returnValue;
        }
        #endregion

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns>实体</returns>
        private BaseUserEntity GetUserEntity()
        {
            this.userEntity.RealName = this.txtRealName.Text;
            // this.userEntity.Gender = this.cmbGender.SelectedValue.ToString();
            if (this.cmbGender.SelectedValue != null)
            {
                this.userEntity.Gender = this.cmbGender.Text;
            }
            this.userEntity.Mobile = this.txtMobile.Text;
            this.userEntity.OICQ = this.txtOICQ.Text;
            this.userEntity.Email = this.txtEmail.Text;
            this.userEntity.Code = this.txtCode.Text;
            this.userEntity.UserName = this.txtUserName.Text;
            if (!string.IsNullOrEmpty(this.ucCompany.SelectedId))
            {
                this.userEntity.CompanyId = this.ucCompany.SelectedId;
                this.userEntity.CompanyName = this.ucCompany.SelectedFullName;
            }
            if (!string.IsNullOrEmpty(this.ucSubCompany.SelectedId))
            {
                this.userEntity.SubCompanyId = this.ucSubCompany.SelectedId;
                this.userEntity.SubCompanyName = this.ucSubCompany.SelectedFullName;
            }
            if (!string.IsNullOrEmpty(this.ucDepartment.SelectedId))
            {
                this.userEntity.DepartmentId = this.ucDepartment.SelectedId;
                this.userEntity.DepartmentName = this.ucDepartment.SelectedFullName;
            }
            if (!string.IsNullOrEmpty(this.ucWorkgroup.SelectedId))
            {
                this.userEntity.WorkgroupId = this.ucWorkgroup.SelectedId;
                this.userEntity.WorkgroupName = this.ucWorkgroup.SelectedFullName;
            }
            if (this.cmbRole.SelectedValue == null || this.cmbRole.SelectedValue.ToString().Length == 0)
            {
                this.userEntity.RoleId = null;
            }
            else
            {
                this.userEntity.RoleId = this.cmbRole.SelectedValue.ToString();
            }
            this.userEntity.Enabled = this.chbEnabled.Checked ? 1 : 0;
            userEntity.Telephone = this.txtMobile.Text;
            if (this.dtpBirthday.Checked)
            {
                userEntity.Birthday = this.dtpBirthday.Value.ToString(BaseSystemInfo.DateFormat);
            }
            else
            {
                userEntity.Birthday = null;
            }
            return this.userEntity;
        }

        /// <summary>
        /// 获取员工信息
        /// </summary>
        /// <returns>实体</returns>
        private BaseStaffEntity GetStaffEntity()
        {
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
            if (this.dtpGraduationDate.Checked)
            {
                staffEntity.GraduationDate = this.dtpGraduationDate.Value.ToString(BaseSystemInfo.DateFormat);
            }
            else
            {
                staffEntity.GraduationDate = null;
            }
            staffEntity.Code = this.txtCode.Text;
            if (this.cmbParty.SelectedValue != null && this.cmbParty.SelectedValue.ToString() != "")
            {
                staffEntity.Party = this.cmbParty.SelectedValue.ToString();
            }
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
            staffEntity.IdentificationCode = this.txtIdentificationCode.Text;
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
            return this.staffEntity;
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (this.staffEntity.UserId > 0)
            {
                BaseUserEntity userEntity = DotNetService.Instance.UserService.GetEntity(UserInfo, this.staffEntity.UserId.ToString());
                userEntity.Birthday = staffEntity.Birthday;
                userEntity.Code = staffEntity.Code;
                userEntity.CompanyId = staffEntity.CompanyId;
                userEntity.CompanyName = staffEntity.DepartmentId;
                userEntity.WorkgroupId = staffEntity.WorkgroupId;
                userEntity.Email = staffEntity.Email;
                userEntity.Gender = staffEntity.Gender;
                userEntity.IsStaff = 1;
                userEntity.Mobile = staffEntity.Mobile;
                userEntity.OICQ = staffEntity.OICQ;
                userEntity.RealName = staffEntity.RealName;
                userEntity.Telephone = staffEntity.Telephone;
                userEntity.UserName = staffEntity.UserName;
                string statusCode = string.Empty;
                string statusMessage = string.Empty;
                DotNetService.Instance.UserService.UpdateUser(UserInfo, userEntity, out statusCode, out statusMessage);
                MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region private bool AddEntity() 新增
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <returns新增>成功</returns>
        private bool AddEntity()
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
                string pictureContent = string.Empty;
                pictureContent = this.ucPicture.Upload("StaffPicture", this.EntityId);
                //判断图片是否为空，如果为空说明没有图片不再执行  dfhjc
                if (pictureContent != "")
                {
                    DotNetService.Instance.ParameterService.SetParameter(UserInfo, "Staff", this.EntityId, "StaffPictureId", pictureContent);
                }
                this.Changed = true;
                if (BaseSystemInfo.ShowInformation)
                {
                    // 添加成功，进行提示
                    MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnLikeAdd_Click(object sender, EventArgs e)
        {
            BaseStaffEntity entity = GetEntity();
            entity.Id = null;
            FrmStaffAdd frmModuleAdd = new FrmStaffAdd(entity);
            frmModuleAdd.ShowDialog();
        }

        #region public override void SaveEntity() 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>保存成功</returns>
        public override bool SaveEntity()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            bool returnValue = false;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            // 1.先保存用户信息
            if (this.staffEntity.UserId != null && this.staffEntity.UserId > 0)
            {
                this.GetUserEntity();
                DotNetService.Instance.UserService.UpdateUser(UserInfo, this.userEntity, out statusCode, out statusMessage);
                if (statusCode != StatusCode.OKUpdate.ToString())
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
            // 2.再保存员工信息
            this.GetStaffEntity();
            DotNetService.Instance.StaffService.UpdateStaff(UserInfo, this.staffEntity, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKUpdate.ToString())
            {
                // 更新员工的照片，若新照片被更新时FileId会变空，所以照片更换了，才会执行下面的代码，若照片不更换就不执行这个代码。
                if (string.IsNullOrEmpty(this.ucPicture.PictureId))
                {
                    string pictureContent = string.Empty;
                    pictureContent = this.ucPicture.Upload("StaffPicture", this.StaffId);
                    //判断图片是否为空，如果为空不对图片过行更新 dfhjc
                    if (pictureContent != "")
                    {
                        DotNetService.Instance.ParameterService.SetParameter(UserInfo, "Staff", this.StaffId, "StaffPictureId", pictureContent);
                    }
                }
                if (BaseSystemInfo.ShowInformation)
                {
                    // 添加成功，进行提示
                    MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.DialogResult = DialogResult.OK;
                returnValue = true;
            }
            else
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
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
            return returnValue;
        }
        #endregion

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
                    if (this.SaveEntity())
                    {
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

        private void btnSetStaffUser_Click(object sender, EventArgs e)
        {
            // 用反射获得窗体
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmUserSelect";
            Form frmUserSelect = CacheManager.Instance.GetForm(assemblyName, formName);
            if (this.staffEntity.UserId > 0)
            {
                ((FrmUserSelect)frmUserSelect).OpenId = this.staffEntity.UserId.ToString();
            }
            ((FrmUserSelect)frmUserSelect).AllowNull = true;
            ((FrmUserSelect)frmUserSelect).MultiSelect = false;
            if (frmUserSelect.ShowDialog() == DialogResult.OK)
            {
                string userId = ((FrmUserSelect)frmUserSelect).SelectedId;
                int returnValue = DotNetService.Instance.StaffService.SetStaffUser(UserInfo, this.staffEntity.Id.ToString(), userId);
                if (returnValue == 1)
                {
                    if (BaseSystemInfo.ShowInformation)
                    {
                        // 添加成功，进行提示
                        MessageBox.Show(AppMessage.MSG0228, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                // 加载窗体
                this.OnLoad(e);
            }
        }

        private void btnUserProperty_Click(object sender, EventArgs e)
        {
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmUserEdit";
            Type type = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserEdit = (Form)Activator.CreateInstance(type, this.staffEntity.UserId.ToString());
            if (frmUserEdit.ShowDialog(this) == DialogResult.OK)
            {
                // 加载窗体
                this.FormOnLoad();
            }
        }

        private void btnDeleteStaffUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(AppMessage.Format(AppMessage.MSG0016, AppMessage.MSG9914), AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                DotNetService.Instance.StaffService.DeleteUser(UserInfo, this.StaffId);
                // 加载窗体
                this.OnLoad(e);
            }
        }

        private void btnUserPermission_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.staffEntity.UserId.ToString()))
            {
                string assemblyName = "DotNet.WinForm";
                string formName = "FrmUserPermission";
                Type type = CacheManager.Instance.GetType(assemblyName, formName);
                Form frmUserPermission = (Form)Activator.CreateInstance(type, this.staffEntity.UserId.ToString(), this.staffEntity.RealName);
                frmUserPermission.ShowDialog(this);
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