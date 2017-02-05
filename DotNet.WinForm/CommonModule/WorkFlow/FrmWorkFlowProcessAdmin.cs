//--------------------------------------------------------------------
// All Rights Reserved ,Copyright (C) 2012 , Hairihan TECH, Ltd. .
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FormWorkFlowAdmin.cs
    /// 工作流管理窗体
    ///		
    /// 修改记录
    /// 
    ///     2010.08.03 版本：1.8 JiRiGaLa    重新整理维护。
    ///     2007.06.26 版本：1.7 JiRiGaLa    增加权限判断代码。
    ///     2007.06.26 版本：1.6 JiRiGaLa    整理代码。
    ///     2007.06.26 版本：1.5 JiRiGaLa    进行优化。
    ///     2007.06.26 版本：1.4 JiRiGaLa    SingleDelete() 进行优化。
    ///     2007.06.26 版本：1.3 JiRiGaLa    整体整理代码。
    ///     2007.06.26 版本：1.2 JiRiGaLa    增加了多国语言功能，调整了细节部分。
    ///     2007.06.26 版本：1.1 JiRiGaLa    整体进行调试改进。
    ///     2007.06.26 版本：1.0 JiRiGaLa    工作流管理功能页面编写。
    ///		
    /// 版本：1.8
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.08.03</date>
    /// </author>
    /// </summary>
    public partial class FrmWorkFlowProcessAdmin : BaseForm
    {
        private DataTable DTWorkFlow = new DataTable(BaseWorkFlowProcessEntity.TableName);


        /// <summary>
        /// 表格中的组织机构主键
        /// </summary>
        public string CurrentEntityId
        {
            get
            {
                return BaseInterfaceLogic.GetDataGridViewEntityId(this.grdWorkFlow, BaseOrganizeEntity.FieldId);
            }
        }

        private bool PermissionAdd = false;                     // 新增权限
        private bool PermissionEdit = false;                    // 编辑权限
        private bool PermissionDelete = false;                  // 删除权限

        public FrmWorkFlowProcessAdmin(String organizeID, string organizeFullName)
            : this()
        {
        }

        public FrmWorkFlowProcessAdmin()
        {
            InitializeComponent();
        }

        private void ucOrganize_SelectedIndexChanged(string selectedId)
        {
            this.FormOnLoad();
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // 检查编辑权限
            if (this.DTWorkFlow.Rows.Count > 0)
            {
                if (this.PermissionDelete)
                {
                    // 检查删除权限
                    this.btnBatchDelete.Enabled = true;
                }
                this.btnStepAdmin.Enabled = true;
                if (this.PermissionEdit)
                {
                    this.btnBatchSave.Enabled = true;
                    this.btnEdit.Enabled = true;
                }
            }
            else
            {
                this.btnStepAdmin.Enabled = false;
                this.btnAdd.Enabled = false;
                this.btnEdit.Enabled = false;
                this.btnBatchDelete.Enabled = false;
                this.btnBatchSave.Enabled = false;
            }
            if (this.PermissionAdd)
            {
                this.btnAdd.Enabled = true;
            }
            this.btnExport.Enabled = this.grdWorkFlow.RowCount > 0;
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.PermissionAdd = this.IsAuthorized("WorkFlowAdmin.Add");      // 新增权限
            this.PermissionEdit = this.IsAuthorized("WorkFlowAdmin.Edit");     // 编辑权限
            this.PermissionDelete = this.IsAuthorized("WorkFlowAdmin.Delete");   // 删除权限
        }
        #endregion

        #region private void BindData() 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        private void BindData()
        {
            this.grdWorkFlow.AutoGenerateColumns = false;
            this.DTWorkFlow.DefaultView.Sort = BaseWorkFlowProcessEntity.FieldSortCode;
            this.grdWorkFlow.DataSource = this.DTWorkFlow.DefaultView;
            this.grdWorkFlow.Refresh();
            if (!string.IsNullOrEmpty(this.EntityId))
            {
                this.grdWorkFlow.FirstDisplayedScrollingRowIndex = BaseInterfaceLogic.GetRowIndex(this.DTWorkFlow, BaseWorkFlowProcessEntity.FieldId, this.EntityId);
            }
            // 判断编辑权限
            if (!this.PermissionEdit)
            {
                // 只读属性设置
                this.grdWorkFlow.Columns["colSelected"].ReadOnly = !this.PermissionEdit;
                this.grdWorkFlow.Columns["colFullName"].ReadOnly = !this.PermissionEdit;
                this.grdWorkFlow.Columns["colDescription"].ReadOnly = !this.PermissionEdit;
                // 修改背景颜色
                this.grdWorkFlow.Columns["colFullName"].DefaultCellStyle.BackColor = Color.White;
                this.grdWorkFlow.Columns["colDescription"].DefaultCellStyle.BackColor = Color.White;
            }
            // 设置按钮状态
            this.SetControlState();
        }
        #endregion

        #region private void BindItemDetails() 绑定下拉筐数据
        /// <summary>
        /// 绑定下拉筐数据
        /// </summary>
        private void BindItemDetails()
        {
            // 获取审批类型
            this.GetWorkFlowCategoryList();

            DataTable dataTable = null;
            DataRow dataRow = null;
            // 绑定单据分类
            dataTable = DotNetService.Instance.ItemDetailsService.GetDataTableByCode(this.UserInfo, "WorkFlowCategories");
            dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbWorkFlowCategory.DataSource = dataTable;
            this.cmbWorkFlowCategory.DisplayMember = BaseItemDetailsEntity.FieldItemName;
            this.cmbWorkFlowCategory.ValueMember = BaseItemDetailsEntity.FieldItemValue;

            // 绑定关联的表单
            this.BindBillTemplate();
        }

        private void BindBillTemplate()
        {
            // 绑定表单类别
            DataTable dataTable = DotNetService.Instance.WorkFlowProcessAdminService.GetBillTemplateDT(this.UserInfo);
            DataRow dataRow = dataTable.NewRow();
            // 分类关联表单
            if (!string.IsNullOrEmpty(this.cmbWorkFlowCategory.SelectedValue.ToString()))
                BaseBusinessLogic.SetFilter(dataTable, BaseWorkFlowBillTemplateEntity.FieldCategoryCode,
                                            this.cmbWorkFlowCategory.SelectedValue.ToString());
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbBillCode.DataSource = dataTable;
            this.cmbBillCode.DisplayMember = BaseWorkFlowBillTemplateEntity.FieldTitle;
            this.cmbBillCode.ValueMember = BaseWorkFlowBillTemplateEntity.FieldCode;
        }
        #endregion

        #region private void GetWorkFlowCategoryList() 获取审批类型
        /// <summary>
        /// 获取审批类型
        /// </summary>
        private void GetWorkFlowCategoryList()
        {
            // 绑定职位数据
            DataTable dataTable = DotNetService.Instance.ItemDetailsService.GetDataTableByCode(UserInfo, "AuditWorkFlowCodeType");
            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbAuditCategoryCode.DisplayMember = BaseItemDetailsEntity.FieldItemName;
            this.cmbAuditCategoryCode.ValueMember = BaseItemDetailsEntity.FieldItemValue;
            this.cmbAuditCategoryCode.DataSource = dataTable.DefaultView;
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
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdWorkFlow);
            // 工作流信息
            this.DTWorkFlow = DotNetService.Instance.WorkFlowProcessAdminService.GetDataTable(this.UserInfo);
            // 主管理页面，不应该过滤数据才对
            // BUBaseBusinessLogic.SetFilter(this.DSWorkFlow.Tables[BaseWorkFlowTable.TableName], BUWorkFlow.Field_Enabled, "1");
            // 绑定屏幕数据
            this.BindData();
        }
        #endregion

        private void grdWorkFlow_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // 判断是否有删除权限
            if (!this.PermissionDelete)
            {
                e.Cancel = true;
                return;
            }
            // 当前记录是否允许被删除
            BaseWorkFlowProcessEntity workFlowProcessEntity = new BaseWorkFlowProcessEntity();
            DataRow dataRow = BaseBusinessLogic.GetDataRow(this.DTWorkFlow, this.EntityId);
            workFlowProcessEntity.GetFrom(dataRow);
            if (this.DTWorkFlow.Rows.Count < 0)
            {
                MessageBox.Show(AppMessage.MSG0017, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Question);
                e.Cancel = true;
            }
            else
            {
                if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.SetRowFilter();
        }

        #region private void SetRowFilter() 设置数据过滤
        /// <summary>
        /// 设置数据过滤
        /// </summary>
        private void SetRowFilter()
        {
            string rowFilter = string.Empty;
            string search = this.txtSearch.Text.Trim();
            search = StringUtil.GetSearchString(search);
            if (!string.IsNullOrEmpty(search))
            {
                rowFilter =

                    /*BaseWorkFlowProcessEntity.FieldCode + " LIKE '" + search + "'"
                    + " OR " + BaseWorkFlowProcessEntity.FieldFullName + " LIKE '" + search + "'"
                    + " OR " + BaseWorkFlowProcessEntity.FieldDescription + " LIKE '" + search + "'"*/

                    StringUtil.GetLike(BaseWorkFlowProcessEntity.FieldCode, search)
                        + " OR " + StringUtil.GetLike(BaseWorkFlowProcessEntity.FieldFullName, search)
                        + " OR " + StringUtil.GetLike(BaseWorkFlowProcessEntity.FieldDescription, search)
                    ;
            }
            string categoryFilter = this.GetCategoryFilter();
            if (!string.IsNullOrEmpty(categoryFilter))
            {
                if (!string.IsNullOrEmpty(rowFilter))
                {
                    rowFilter = categoryFilter + " AND (" + rowFilter + ") ";
                }
                else
                {
                    rowFilter = categoryFilter;
                }
            }

            this.DTWorkFlow.DefaultView.RowFilter = rowFilter;
        }
        #endregion

        private string GetCategoryFilter()
        {
            string rowFilter = string.Empty;

            if (this.cmbAuditCategoryCode.SelectedValue != null)
            {
                if (this.cmbAuditCategoryCode.SelectedValue.ToString().Length > 0)
                {
                    rowFilter = BaseWorkFlowProcessEntity.FieldAuditCategoryCode + " = '" + this.cmbAuditCategoryCode.SelectedValue + "' ";
                }
            }

            if (this.cmbWorkFlowCategory.SelectedValue != null)
            {
                if (this.cmbWorkFlowCategory.SelectedValue.ToString().Length > 0)
                {
                    if (!string.IsNullOrEmpty(rowFilter))
                    {
                        rowFilter += " AND ";
                    }
                    rowFilter += BaseWorkFlowProcessEntity.FieldCategoryCode + " = '" + this.cmbWorkFlowCategory.SelectedValue + "' ";
                    if (this.cmbBillCode.SelectedValue != null)
                    {
                        if (this.cmbBillCode.SelectedValue.ToString().Length > 0)
                        {
                            rowFilter += " AND " + BaseWorkFlowProcessEntity.FieldCode + " = '" + this.cmbBillCode.SelectedValue + "' ";
                        }
                    }
                }
            }
            return rowFilter;
        }

        private void cmbWorkFlowCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.FormLoaded)
            {
                this.BindBillTemplate();
            }
        }

        private void cmbBillCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                // 设置数据过滤
                this.SetRowFilter();
                // 设置按钮状态
                this.SetControlState();
            }
        }

        private void grdWorkFlow_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnStepAdmin.PerformClick();
        }

        private void btnStepAdmin_Click(object sender, EventArgs e)
        {
            if (this.PermissionEdit)
            {
                if (!string.IsNullOrEmpty(this.CurrentEntityId))
                {
                    FrmWorkFlowActivityAdmin frmWorkFlowActivityAdmin = new FrmWorkFlowActivityAdmin(this.CurrentEntityId);
                    frmWorkFlowActivityAdmin.ShowDialog(this);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmWorkFlowProcessAdd frmWorkFlowAdd = new FrmWorkFlowProcessAdd(null, string.Empty, this.cmbBillCode.SelectedValue.ToString());
            if (frmWorkFlowAdd.ShowDialog(this) == DialogResult.OK)
            {
                // 记录当前选中的代码
                this.EntityId = frmWorkFlowAdd.EntityId;
                // 加载窗体
                this.FormOnLoad();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.PermissionEdit)
            {
                if (!string.IsNullOrEmpty(this.CurrentEntityId))
                {
                    FrmWorkFlowProcessEdit frmWorkFlowEdit = new FrmWorkFlowProcessEdit(this.CurrentEntityId);
                    if (frmWorkFlowEdit.ShowDialog(this) == DialogResult.OK)
                    {
                        // 记录当前选中的代码
                        this.EntityId = frmWorkFlowEdit.EntityId;
                        // 加载窗体
                        this.FormOnLoad();
                    }
                }
            }
        }

        #region public override bool CheckInputDelete() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        public override bool CheckInputDelete()
        {
            //int selectedCount = 0;
            bool returnValue = false;

            foreach (DataGridViewRow dgvRow in grdWorkFlow.Rows)
            {
                if ((dgvRow.DataBoundItem as DataRowView).Row.RowState == DataRowState.Deleted)
                {
                    continue;
                }
                if ((System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false))
                {
                    // 有记录被选中了
                    returnValue = true;
                    break;
                }
            }

            //foreach (DataRow dataRow in this.DTWorkFlow.Rows)
            //{
            //    if (dataRow.RowState == DataRowState.Deleted)
            //    {
            //        continue;
            //    }
            //    if (dataRow["colSelected"].ToString() == true.ToString())
            //    {
            //        // 有记录被选中了
            //        returnValue = true;
            //        break;
            //    }
            //}
            if (!returnValue)
            {
                MessageBox.Show(AppMessage.MSGC023, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return returnValue;
        }
        #endregion

        #region private string[] GetSelecteIds() 获得已被选择的部门代码数组
        /// <summary>
        /// 获得已被选择的部门代码数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelecteIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdWorkFlow, BaseWorkFlowProcessEntity.FieldId, "colSelected", true);
        }
        #endregion

        #region public override int BatchDelete() 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        public override int BatchDelete()
        {
            int returnValue = 0;
            returnValue = DotNetService.Instance.WorkFlowProcessAdminService.SetDeleted(this.UserInfo, this.GetSelecteIds());
            this.DTWorkFlow = DotNetService.Instance.WorkFlowProcessAdminService.GetDataTable(this.UserInfo);
            // 绑定屏幕数据
            this.BindData();
            return returnValue;
        }
        #endregion

        private void btnBatchDelete_Click(object sender, EventArgs e)
        {
            if (this.CheckInputDelete())
            {
                if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    // 设置鼠标繁忙状态，并保留原先的状态
                    Cursor holdCursor = this.Cursor;
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        this.BatchDelete();
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
        }

        #region private bool CheckInputBatchSave() 检查批量输入的有效性
        /// <summary>
        /// 检查批量输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        private bool CheckInputBatchSave()
        {
            int selectedCount = 0;
            bool returnValue = false;
            foreach (DataRow dataRow in this.DTWorkFlow.Rows)
            {
                // 这里判断数据的各种状态
                if (dataRow.RowState == DataRowState.Modified)
                {
                    // 是否允许编辑
                    if (this.DTWorkFlow.Rows.Count > 0)
                    {
                        if ((dataRow[BaseWorkFlowProcessEntity.FieldFullName, DataRowVersion.Original] != dataRow[BaseWorkFlowProcessEntity.FieldFullName, DataRowVersion.Current]) || (dataRow[BaseWorkFlowProcessEntity.FieldDescription, DataRowVersion.Original] != dataRow[BaseWorkFlowProcessEntity.FieldDescription, DataRowVersion.Current]))
                        {
                            returnValue = false;
                            MessageBox.Show(AppMessage.Format(AppMessage.MSG0020, AppMessage.MSG9978), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // 这里需要直接返回了，不再进行输入交验了。
                            return returnValue;
                        }
                    }
                    selectedCount++;
                }
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    // 是否允许删除
                    // myBUWorkFlow.GetFromDR(myDataRow);
                    // if (!myBUWorkFlow.AllowDelete)
                    // {
                    //     returnValue = false;
                    //     MessageBox.Show(AppMessage.Format(AppMessage.MSG0020, AppMessage.MSG9978), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //     // 这里需要直接返回了，不再进行输入交验了。
                    //     return returnValue;
                    // }
                    selectedCount++;
                }
            }
            // 有记录被选中了
            returnValue = selectedCount > 0;
            if (!returnValue)
            {
                MessageBox.Show(AppMessage.MSG0004, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return returnValue;
        }
        #endregion

        #region private void BatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private void BatchSave()
        {
            DotNetService.Instance.WorkFlowProcessAdminService.BatchSave(this.UserInfo, this.DTWorkFlow);
            // 绑定屏幕数据
            this.FormOnLoad();
            if (BaseSystemInfo.ShowInformation)
            {
                // 批量保存，进行提示
                MessageBox.Show(AppMessage.MSG0012, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        private void btnBatchSave_Click(object sender, EventArgs e)
        {
            // 检查批量输入的有效性
            if (BaseInterfaceLogic.CheckInputModifyAnyOne(this.DTWorkFlow))
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    // 批量保存
                    this.BatchSave();

                    // 2012.05.12 Pcsky
                    // 更新datatable的状态，解决无法二次修改的问题
                    this.DTWorkFlow.AcceptChanges();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            // 关闭窗体
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 导出Excel
            //string exportFileName = this.Text + ".csv";
            string exportFileName = this.Text + ".xls";
            this.ExportExcel(this.grdWorkFlow, @"\Modules\Export\", exportFileName);
        }

        private void cmbAuditCategoryCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                // 设置数据过滤
                this.SetRowFilter();
                // 设置按钮状态
                this.SetControlState();
            }
        }

    }
}