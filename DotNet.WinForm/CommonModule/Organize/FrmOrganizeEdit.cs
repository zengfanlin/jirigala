//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FrmOrganizeEdit.cs
    /// 组织机构管理-添加组织机构窗体
    ///		
    /// 修改记录
    ///     2011.10.19 版本：1.7 张广梁    增加fullname属性，修改SaveEntity。
    ///     2010.10.21 版本：1.6 JiRiGaLa  部门类别进行优化。
    ///     2007.06.05 版本：1.7 JiRiGaLa  整理主键。
    ///     2007.05.30 版本：1.4 JiRiGaLa  提示信息优化，标准工程完成。
    ///     2007.05.30 版本：1.3 JiRiGaLa  整体整理主键
    ///     2007.05.17 版本：1.2 JiRiGaLa  增加了多国语言功能，调整了细节部分。
    ///     2007.05.14 版本：1.1 JiRiGaLa  改进CheckInput()，SaveEntity()。
    ///     2007.05.10 版本：1.0 JiRiGaLa  组织机构添加功能页面编写。
    ///     2012.04.22 版本：1.0 zwd       修改新增类似数据的添加 新增 AddEntity()
    ///		
    /// 版本：1.7
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.10.21</date>
    /// </author> 
    /// </summary>
    public partial class FrmOrganizeEdit : BaseForm
    {
        /// <summary>
        /// 权限域编号
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        /// <summary>
        /// 机构名称
        /// </summary>
        private string fullName = string.Empty;
        public string FullName
        {
            get { return this.fullName; }
            set { this.fullName = value; }
        }

        /// <summary>
        /// 父机构Id
        /// </summary>
        private string parentId = string.Empty;
        public string ParentId
        {
            get { return this.parentId; }
            set { this.parentId = value; }
        }

        /// <summary>
        /// 实体
        /// </summary>
        private BaseOrganizeEntity organizeEntity = null;

        public FrmOrganizeEdit()
        {
            InitializeComponent();
        }

        public FrmOrganizeEdit(string entityId) : this()
        {
            this.EntityId = entityId;
        }

        #region private void BindItemDetails() 绑定下拉筐数据
        /// <summary>
        /// 绑定下拉筐数据
        /// </summary>
        private void BindItemDetails()
        {
            DataTable dataTable = new DataTable(BaseItemDetailsEntity.TableName);
            dataTable = DotNetService.Instance.ItemDetailsService.GetDataTableByCode(UserInfo, "OrganizeCategory");
            // 添加一个空记录
            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            // 绑定数据
            this.cmbCategory.DisplayMember = BaseItemDetailsEntity.FieldItemName;
            this.cmbCategory.ValueMember = BaseItemDetailsEntity.FieldItemCode;
            // this.cmbCategory.ValueMember = BaseItemDetailsEntity.FieldId;
            this.cmbCategory.DataSource = dataTable.DefaultView;
        }
        #endregion

        #region public override void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public override void ShowEntity()
        {
            // 将类转显示到页面
            this.txtId.Text = organizeEntity.Id.ToString();
            this.ucParent.SelectedId = organizeEntity.ParentId.ToString();
            //季俊武20110219修改OpenId赋值的条件
            //if (String.IsNullOrEmpty(this.ucParent.SelectedId))
            //{
                this.ucParent.OpenId = organizeEntity.Id.ToString();
            //}
            this.txtCode.Text = organizeEntity.Code;
            this.txtFullName.Text = organizeEntity.FullName;
            this.txtShortName.Text = organizeEntity.ShortName;
            if (organizeEntity.Category != null)
            {
                this.cmbCategory.SelectedValue = organizeEntity.Category;
            }
            this.txtOuterPhone.Text = organizeEntity.OuterPhone;
            this.txtInnerPhone.Text = organizeEntity.InnerPhone;
            this.txtFax.Text = organizeEntity.Fax;
            this.txtPostalcode.Text = organizeEntity.Postalcode;
            this.txtAddress.Text = organizeEntity.Address;
            this.txtWeb.Text = organizeEntity.Web;
            this.chkEnabled.Checked = organizeEntity.Enabled ==1;
            this.chkIsInnerOrganize.Checked = organizeEntity.IsInnerOrganize == 1;
            this.txtDescription.Text = organizeEntity.Description;
            // 这里需要进行判断，数据是否被其他人已经删除
            if (organizeEntity.Id == 0)
            {
                MessageBox.Show(AppMessage.MSG0005, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.ucParent.CheckMove = true;
            this.ucParent.OpenId = this.EntityId;
            // 若不是系统管理员，不能添加跟节点
            this.lblParentReq.Visible = false;
            this.ucParent.AllowNull = true;
            if (!UserInfo.IsAdministrator)
            {
                this.lblParentReq.Visible = true;
                this.ucParent.AllowNull = false;
                this.ucParent.PermissionItemScopeCode = this.PermissionItemScopeCode;
            }
            this.btnPermission.Visible = BaseSystemInfo.UseOrganizePermission;
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 组织机构信息
            this.organizeEntity = DotNetService.Instance.OrganizeService.GetEntity(UserInfo, this.EntityId);
            // 绑定下拉筐数据
            this.BindItemDetails();
            // 显示内容
            this.ShowEntity();
            // 获取岗位信息
            this.GetRoleUser();
            // 设置焦点
            this.ActiveControl = this.txtFullName;
            this.txtCode.Focus();
        }
        #endregion

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        public override bool CheckInput()
        {
            bool returnValue = true;
            // 部门是否已经是自己的子部门了？
            this.txtFullName.Text = this.txtFullName.Text.TrimEnd();
            if (this.txtFullName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9978), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtFullName.Focus();
                return false;
            }
            //if (this.cmbCategory.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("分类不能为空。", AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.cmbCategory.Focus();
            //    return false;
            //}
            return returnValue;
        }
        #endregion

        #region private BaseOrganizeEntity GetEntity() 转换数据
        /// <summary>
        /// 转换数据
        /// </summary>
        private BaseOrganizeEntity GetEntity()
        {
            if (string.IsNullOrEmpty(this.ucParent.SelectedId))
            {
                organizeEntity.ParentId = null;
            }
            else
            {
                organizeEntity.ParentId = this.ucParent.SelectedId;
            }
            organizeEntity.Code = this.txtCode.Text;
            organizeEntity.FullName = this.txtFullName.Text;
            organizeEntity.ShortName = this.txtShortName.Text;
            if (this.cmbCategory.SelectedValue == null)
            {
                organizeEntity.Category = string.Empty;
            }
            else
            {
                organizeEntity.Category = this.cmbCategory.SelectedValue.ToString();
            }
            organizeEntity.OuterPhone = this.txtOuterPhone.Text;
            organizeEntity.InnerPhone = this.txtInnerPhone.Text;
            organizeEntity.Fax = this.txtFax.Text;
            organizeEntity.Postalcode = this.txtPostalcode.Text;
            organizeEntity.Web = this.txtWeb.Text;
            organizeEntity.Enabled = this.chkEnabled.Checked ? 1 : 0;
            organizeEntity.IsInnerOrganize = this.chkIsInnerOrganize.Checked ? 1 : 0;
            organizeEntity.Description = this.txtDescription.Text;
            return organizeEntity;
        }
        #endregion

        #region private void GetRoleUser() 获取岗位信息
        /// <summary>
        /// 获取岗位信息
        /// </summary>
        private void GetRoleUser()
        {
            this.GetRoleId(this.btnLeadership);
            this.GetRoleUser(this.btnLeadership);
            this.GetRoleId(this.btnBusinessLeadership);
            this.GetRoleUser(this.btnBusinessLeadership);
            this.GetRoleId(this.btnFinancialLeadership);
            this.GetRoleUser(this.btnFinancialLeadership);
            this.GetRoleId(this.btnPersonnelLeadership);
            this.GetRoleUser(this.btnPersonnelLeadership);
            this.GetRoleId(this.btnManager);
            this.GetRoleUser(this.btnManager);
            this.GetRoleId(this.btnAssistantManager);
            this.GetRoleId(this.btnAssistant);
            this.GetRoleUser(this.btnAssistantManager);
            this.GetRoleId(this.btnFinancial);
            this.GetRoleUser(this.btnFinancial);
            this.GetRoleId(this.btnAccounting);
            this.GetRoleUser(this.btnAccounting);
            this.GetRoleId(this.btnCashier);
            this.GetRoleUser(this.btnCashier);
            this.GetRoleId(this.btnSystemManager);
            this.GetRoleUser(this.btnSystemManager);
        }
        #endregion

        private string GetRoleId(Button btnRole)
        {
            string returnValue = string.Empty;
            BaseRoleManager roleManager = new BaseRoleManager(this.UserInfo);
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldOrganizeId, this.EntityId));
            parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldCategoryCode, "Duty"));
            parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldCode, btnRole.Name.Substring(3).Replace("Delete","")));
            parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldEnabled, 1));
            parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldDeletionStateCode, 0));
            returnValue = roleManager.GetProperty(parameters, BaseRoleEntity.FieldId);
            btnRole.Tag = returnValue;
            return returnValue;
        }

        private void GetRoleUser(Button btnRole)
        {
            if (btnRole.Tag != null)
            {
                string roldId = (string)btnRole.Tag;
                if (!string.IsNullOrEmpty(roldId))
                {
                    string txtControlCode = btnRole.Name.Substring(3).Replace("Delete","");
                    TextBox txtUser = (TextBox)this.grbDuty.Controls.Find("txt" + txtControlCode, false)[0];
                    DataTable dtUser = DotNetService.Instance.UserService.GetDataTableByRole(UserInfo, roldId);
                    txtUser.Text = BaseBusinessLogic.FieldToList(dtUser, BaseUserEntity.FieldRealName).Replace("'", "");
                }
            }
        }

        private void btnRole_Click(object sender, EventArgs e)
        {
            string txtButton = ((Button)sender).Text;
            Button btnRole = (Button)sender;
            string roldId = GetRoleId(btnRole);
            if (string.IsNullOrEmpty(roldId))
            {
                BaseRoleEntity roleEntity = new BaseRoleEntity();
                roleEntity.OrganizeId = this.EntityId;
                roleEntity.Code = ((Button)sender).Name.Substring(3).Replace("Delete", "");
                roleEntity.RealName = this.txtFullName.Text + "_" + txtButton;
                roleEntity.Description = ((Button)sender).Text;
                roleEntity.CategoryCode = "Duty";
                roleEntity.Enabled = 1;
                roleEntity.DeletionStateCode = 0;
                BaseRoleManager roleManager = new BaseRoleManager(this.UserInfo);
                roldId = roleManager.Add(roleEntity);
                btnRole.Tag = roldId;
            }
            FrmRoleUserAdmin frmRoleUserAdmin = new FrmRoleUserAdmin(roldId);
            frmRoleUserAdmin.ShowDialog(this);

            this.GetRoleUser(btnRole);
        }

        private void btnRoleDelete_Click(object sender, EventArgs e)
        {
            Button btnRole = (Button)sender;
            string roldId = GetRoleId(btnRole);
            if (!string.IsNullOrEmpty(roldId))
            {
                DataTable DTUser = DotNetService.Instance.UserService.GetDataTableByRole(UserInfo, roldId);
                if (DTUser.Rows.Count > 0)
                {
                    string[] delUserIds = new string[DTUser.Rows.Count];
                    for (int i = 0; i < DTUser.Rows.Count; i++)
                    {
                        delUserIds[i] = DTUser.Rows[i][BaseUserEntity.FieldId].ToString();
                    }
                    if (MessageBox.Show(AppMessage.MSG0075, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        // 设置鼠标繁忙状态，并保留原先的状态
                        Cursor holdCursor = this.Cursor;
                        this.Cursor = Cursors.WaitCursor;
                        try
                        {
                            int returnValue = DotNetService.Instance.RoleService.RemoveUserFromRole(UserInfo, roldId, delUserIds);
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
            this.GetRoleUser(btnRole);
        }

        private void btnPermission_Click(object sender, EventArgs e)
        {
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmOrganizePermission";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmOrganizePermission = (Form)Activator.CreateInstance(assemblyType, this.EntityId);
            frmOrganizePermission.ShowDialog(this);
        }

        #region private void AddEntity() 添加保存
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns>添加成功</returns>
        private bool AddEntity()
        {
            bool returnValue = false;
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            // 转换数据
            BaseOrganizeEntity organizeEntity = this.GetEntity();
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            this.EntityId = DotNetService.Instance.OrganizeService.Add(UserInfo, organizeEntity, out statusCode, out statusMessage);
            this.FullName = this.txtFullName.Text;
            if (statusCode == StatusCode.OKAdd.ToString())
            {
                if (this.Owner != null)
                {
                    if (this.Owner is FrmOrganizeAdmin)
                    {
                        ((FrmOrganizeAdmin)this.Owner).FormOnLoad();
                    }
                }
                if (BaseSystemInfo.ShowInformation)
                {
                    // 添加成功，进行提示
                    MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                returnValue = true;                
            }
            else
            {
                MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                // 是否名称重复了，提高友善性
                if (statusCode == StatusCode.ErrorNameExist.ToString())
                {
                    this.txtFullName.SelectAll();
                    this.txtFullName.Focus();
                }
                else
                {
                    // 是否编号重复了，提高友善性
                    if (statusCode == StatusCode.ErrorCodeExist.ToString())
                    {
                        this.txtCode.SelectAll();
                        this.txtCode.Focus();
                    }
                }
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
            return returnValue;
        }
        #endregion

        private void btnLikeAdd_Click(object sender, EventArgs e)
        {
            BaseOrganizeEntity entity = GetEntity();
            entity.Id = null;
            FrmOrganizeAdd frmOrganizeAdd = new FrmOrganizeAdd(entity);
            frmOrganizeAdd.ShowDialog();
        }

        #region public override bool SaveEntity() 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>保存成功</returns>
        public override bool SaveEntity()
        {
            bool returnValue = false;
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            // 转换数据
            this.GetEntity();
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            this.FullName = this.txtFullName.Text;
            this.ParentId = this.ucParent.SelectedId;
            DotNetService.Instance.OrganizeService.Update(UserInfo, this.organizeEntity, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKUpdate.ToString())
            {
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
                // 是否名称重复了，提高友善性
                if (statusCode == StatusCode.ErrorNameExist.ToString())
                {
                    this.txtFullName.SelectAll();
                    this.txtFullName.Focus();
                }
                else
                {
                    // 是否编号重复了，提高友善性
                    if (statusCode == StatusCode.ErrorCodeExist.ToString())
                    {
                        this.txtCode.SelectAll();
                        this.txtCode.Focus();
                    }
                }
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
            return returnValue;
        }
        #endregion

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}