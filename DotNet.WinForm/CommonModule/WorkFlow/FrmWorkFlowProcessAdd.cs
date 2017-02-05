//--------------------------------------------------------------------
// All Rights Reserved ,Copyright (C) 2012 , Hairihan TECH, Ltd. .
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Utilities;

    using DotNet.Business;


    /// <summary>
    /// FormWorkFlowAdd.cs
    /// 工作流管理-添加工作流窗体
    ///		
    /// 修改记录
    /// 
    ///     2010.08.03 版本：1.3 JiRiGaLa  重新整理代码。
    ///     2007.06.26 版本：1.2 JiRiGaLa  增加了多国语言功能，调整了细节部分。
    ///     2007.06.26 版本：1.1 JiRiGaLa  改进CheckInput()，SaveEntity()。
    ///     2007.06.26 版本：1.0 JiRiGaLa  工作流添加功能页面编写。
    ///		
    /// 版本：1.2
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.08.03</date>
    /// </author> 
    /// </summary> 
    public partial class FrmWorkFlowProcessAdd : BaseForm
    {
        public BaseWorkFlowProcessEntity WorkFlowProcessEntity = null;

        private string workFlowCategory = string.Empty;
        /// <summary>
        /// 分类
        /// </summary>
        public string WorkFlowCategory
        {
            get
            {
                return workFlowCategory;
            }
            set
            {
                workFlowCategory = value;
            }
        }

        public FrmWorkFlowProcessAdd()
        {
            InitializeComponent();
        }

        public FrmWorkFlowProcessAdd(String organizeId, string organizeFullName)
            : this()
        {
            this.ucOrganize.SelectedId = organizeId;
            this.ucOrganize.SelectedFullName = organizeFullName;
        }

        public FrmWorkFlowProcessAdd(String organizeId, string organizeFullName, string workFlowCategory)
            : this(organizeId, organizeFullName)
        {
            this.WorkFlowCategory = workFlowCategory;
        }

        #region private void BindItemDetails() 绑定下拉筐数据
        /// <summary>
        /// 绑定下拉筐数据
        /// </summary>
        private void BindItemDetails()
        {
            // 绑定职位数据
            DataTable dataTable = DotNetService.Instance.ItemDetailsService.GetDataTableByCode(UserInfo, "WorkFlowCategories");
            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbWorkFlowCategory.DisplayMember = BaseItemDetailsEntity.FieldItemName;
            this.cmbWorkFlowCategory.ValueMember = BaseItemDetailsEntity.FieldItemValue;
            this.cmbWorkFlowCategory.DataSource = dataTable.DefaultView;
            // 提高友善性，默认能选中角色类别
            if (!string.IsNullOrEmpty(this.WorkFlowCategory))
            {
                this.cmbWorkFlowCategory.SelectedValue = this.WorkFlowCategory;
            }
            // 获取获取审批类型
            this.GetWorkFlowCategoryList();
        }
        #endregion

        #region private void GetWorkFlowCategoryList() 获取流程类型
        /// <summary>
        /// 获取流程类型
        /// </summary>
        private void GetWorkFlowCategoryList()
        {
            // 绑定职位数据
            DataTable dataTable = DotNetService.Instance.ItemDetailsService.GetDataTableByCode(UserInfo, "AuditWorkFlowCodeType");
            this.cmbAuditCategoryCode.DisplayMember = BaseItemDetailsEntity.FieldItemName;
            this.cmbAuditCategoryCode.ValueMember = BaseItemDetailsEntity.FieldItemValue;
            this.cmbAuditCategoryCode.DataSource = dataTable.DefaultView;
            // 提高友善性，默认能选中角色类别
            this.cmbWorkFlowCategory.SelectedValue = "ByTemplate";
        }
        #endregion

        #region private void GetBillList(bool linkage) 获取单据数据
        /// <summary>
        /// 获取单据数据
        /// </summary>
        /// <param name="linkage"></param>
        private void GetBillList(bool linkage)
        {
            DataTable dataTable = new DataTable();
            if (linkage)
            {
                string billCategory = string.Empty;
                if (this.cmbWorkFlowCategory.SelectedValue != null)
                {
                    billCategory = this.cmbWorkFlowCategory.SelectedValue.ToString();
                }
                // 获取单据数据
                dataTable = DotNetService.Instance.WorkFlowProcessAdminService.Search(this.UserInfo, string.Empty, billCategory, string.Empty, null, false);
            }
            else
            {
                // 获取全部数据
                dataTable = DotNetService.Instance.WorkFlowProcessAdminService.GetBillTemplateDT(this.UserInfo);
            }
            this.lstbBillTemlate.DataSource = dataTable;
            this.lstbBillTemlate.DisplayMember = BaseWorkFlowBillTemplateEntity.FieldTitle;
            this.lstbBillTemlate.ValueMember = BaseWorkFlowBillTemplateEntity.FieldId;
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 获取分类列表
            this.BindItemDetails();
            // 获取单据数据
            this.GetBillList(false);
            // 定位焦点
            this.ActiveControl = this.txtFullName;
            this.txtFullName.Focus();
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
            // 是否为空
            if (this.cmbAuditCategoryCode.SelectedValue != null)
            {
                string categoryCode = this.cmbAuditCategoryCode.SelectedValue.ToString();
                // 按组织机构
                if (categoryCode.Equals("ByOrganize"))
                {
                    if (string.IsNullOrEmpty(this.ucOrganize.SelectedId))
                    {
                        MessageBox.Show(AppMessage.Format(AppMessage.MSG0303, AppMessage.MSG9971), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ucOrganize.Focus();
                        return false;
                    }
                }
                // 按用户
                else if (categoryCode.Equals("ByUser"))
                {
                    if (string.IsNullOrEmpty(this.ucUser.SelectedId))
                    {
                        MessageBox.Show(AppMessage.Format(AppMessage.MSG0303, AppMessage.MSG9957), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ucUser.Focus();
                        return false;
                    }
                }
            }
            if (this.txtFullName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9978), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtFullName.Focus();
                return false;
            }
            if (this.txtCode.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9977), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtCode.Focus();
                return false;
            }
            if ((this.cmbWorkFlowCategory.SelectedValue == null) || (string.IsNullOrEmpty(this.cmbWorkFlowCategory.SelectedValue.ToString())))
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0303, AppMessage.MSG0302), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cmbWorkFlowCategory.Focus();
                return false;
            }
            return returnValue;
        }
        #endregion

        #region private BaseWorkFlowProcessEntity GetEntity() 转换数据，将表单数据保存到实体类
        /// <summary>
        /// 读取屏幕中输入的数据
        /// </summary>
        /// <returns>操作权限项实体</returns>
        private BaseWorkFlowProcessEntity GetEntity()
        {
            if (this.WorkFlowProcessEntity == null)
            {
                this.WorkFlowProcessEntity = new BaseWorkFlowProcessEntity();
            }
            if (!string.IsNullOrEmpty(this.ucOrganize.SelectedId))
            {
                this.WorkFlowProcessEntity.OrganizeId = this.ucOrganize.SelectedId;
            }
            if (!string.IsNullOrEmpty(this.ucUser.SelectedId))
            {
                this.WorkFlowProcessEntity.UserId = this.ucUser.SelectedId;
                //BaseUserEntity userEntity = DotNetService.Instance.UserService.GetEntity(this.UserInfo, this.ucUser.SelectedId);
                //if (userEntity != null)
                //{
                //    this.WorkFlowProcessEntity.OrganizeId = userEntity.DepartmentId;
                //}
            }
            //this.WorkFlowProcessEntity.AuditCategoryCode = this.cmbAuditCategoryCode.SelectedValue.ToString();
            if (this.cmbWorkFlowCategory.SelectedValue != null)
            {
                this.WorkFlowProcessEntity.CategoryCode = this.cmbWorkFlowCategory.SelectedValue.ToString();
            }
            if (this.lstbBillTemlate.SelectedValue != null)
            {
                this.WorkFlowProcessEntity.BillTemplateId = this.lstbBillTemlate.SelectedValue.ToString();
            }
            this.WorkFlowProcessEntity.Code = this.txtCode.Text;
            this.WorkFlowProcessEntity.FullName = this.txtFullName.Text;
            this.WorkFlowProcessEntity.CategoryCode = this.cmbWorkFlowCategory.SelectedValue.ToString();
            this.WorkFlowProcessEntity.Enabled = this.chkEnabled.Checked ? 1 : 0;
            this.WorkFlowProcessEntity.DeletionStateCode = 0;
            this.WorkFlowProcessEntity.Description = this.txtDescription.Text;
            return this.WorkFlowProcessEntity;
        }
        #endregion

        #region private void SaveEntity() 保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="close">关闭窗体</param>
        /// <returns>保存成功</returns>
        private bool SaveEntity(bool close)
        {
            bool returnValue = false;
            // 转换数据，将实体类保存到数据表
            this.GetEntity();
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            // 调用接口方式实现
            this.EntityId = DotNetService.Instance.WorkFlowProcessAdminService.Add(this.UserInfo, this.WorkFlowProcessEntity, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKAdd.ToString())
            {
                if (!close)
                {
                    // 清除窗体
                    this.ClearForm();
                }
                if (BaseSystemInfo.ShowInformation)
                {
                    // 添加成功，进行提示
                    MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                returnValue = true;
                if (close)
                {
                    this.DialogResult = DialogResult.OK;
                }
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
            }
            return returnValue;
        }
        #endregion

        #region private void ClearForm() 清除窗体
        /// <summary>
        /// 清除窗体
        /// </summary>
        private void ClearForm()
        {
            this.txtCode.Clear();
            this.txtFullName.Clear();
            this.txtDescription.Clear();
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 检查输入的有效性
            if (this.CheckInput())
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    if (this.SaveEntity(true))
                    {
                        // 关闭窗口
                        this.Close();
                    }
                }
                catch (Exception exception)
                {
                    // 在本地记录异常
                    this.ProcessException(exception);
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

        /// <summary>
        /// 选择流程类型时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbAuditCategoryCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 是否为空
            if (this.cmbAuditCategoryCode.SelectedValue != null)
            {
                string categoryCode = this.cmbAuditCategoryCode.SelectedValue.ToString();
                // 按模版
                if (categoryCode.Equals("ByTemplate"))
                {
                    this.ucOrganize.Enabled = false;
                    this.ucUser.Enabled = false;
                    this.lblRoleReq.Visible = false;
                    this.lblParentReq.Visible = false;
                }
                // 按组织机构
                else if (categoryCode.Equals("ByOrganize"))
                {
                    this.ucOrganize.Enabled = true;
                    this.lblParentReq.Visible = true;
                    this.ucUser.Enabled = false;
                    this.lblRoleReq.Visible = false;

                }
                // 按用户
                else if (categoryCode.Equals("ByUser"))
                {
                    this.ucOrganize.Enabled = false;
                    this.lblParentReq.Visible = false;
                    this.ucUser.Enabled = true;
                    this.lblRoleReq.Visible = true;
                }
            }
        }

        /// <summary>
        /// 选择审批类型时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbWorkFlowCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetBillList(true);
        }
    }
}