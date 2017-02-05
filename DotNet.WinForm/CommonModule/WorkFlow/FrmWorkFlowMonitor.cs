//--------------------------------------------------------------------
// All Rights Reserved ,Copyright (C) 2012 , Hairihan TECH, Ltd. .
//--------------------------------------------------------------------

using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FormWorkFlowAuditDetail.cs
    /// 权限管理-管理权限窗体
    ///		
    /// 修改记录
    /// 
    ///     2010.08.05 版本：1.1 JiRiGaLa 重新整理代码。
    ///     2007.07.18 版本：1.0 JiRiGaLa Gredview显示。
    /// 
    /// 版本：1.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.08.05</date>
    /// </author> 
    /// </summary> 
    public partial class FrmWorkFlowMonitor : BaseForm
    {
        private DataTable DTWorkFlowCurrent = new DataTable(BaseWorkFlowCurrentEntity.TableName);

        private string entityId = string.Empty;
        /// <summary>
        /// 当前选中的记录主键
        /// </summary>
        public string CurrentEntityId
        {
            get
            {
                return this.entityId;
            }
            set
            {
                this.entityId = value;
            }
        }

        public FrmWorkFlowMonitor()
        {
            InitializeComponent();
        }

        #region private void GetItemDetails() 绑定下拉框数据
        /// <summary>
        /// 绑定下拉框数据
        /// </summary>
        private void GetItemDetails()
        {       
            // 绑定单据分类
            DataTable dataTable = DotNetService.Instance.ItemDetailsService.GetDataTable(this.UserInfo, "ItemsWorkFlowCategories");
            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbCategory.DataSource = dataTable;
            this.cmbCategory.DisplayMember = BaseItemDetailsEntity.FieldItemName;
            this.cmbCategory.ValueMember = BaseItemDetailsEntity.FieldItemValue;

            GetItemsDetail(false );
        }

        /// <summary>
        /// 绑定单据列表
        /// <param name="linkage">是否属于联动</param>
        /// </summary>
        private void GetItemsDetail(bool linkage)
        {
            DataTable dataTable = new DataTable();
            if (linkage)
            {
                string billCategory = string.Empty;
                if (this.cmbCategory.SelectedValue != null)
                {
                    billCategory = this.cmbCategory.SelectedValue.ToString();
                }
                // 获取单据数据
                dataTable = DotNetService.Instance.WorkFlowProcessAdminService.Search(this.UserInfo, string.Empty, billCategory, string.Empty, null, false);
            }
            else
            {
                // 获取全部数据
                dataTable = DotNetService.Instance.WorkFlowProcessAdminService.GetBillTemplateDT(this.UserInfo);
            }
            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbBill.DataSource = dataTable;
            this.cmbBill.DisplayMember = BaseWorkFlowBillTemplateEntity.FieldTitle;
            this.cmbBill.ValueMember = BaseWorkFlowBillTemplateEntity.FieldCode;
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnAuditDetail.Enabled = this.grdAuditDetail.RowCount > 0;
            this.btnExport.Enabled = this.grdAuditDetail.RowCount > 0;
        }
        #endregion

        #region private void Search() 获取部门列表
        /// <summary>
        /// 获取部门列表
        /// </summary>
        private void Search()
        {
            int recordCount = 0;
            string searchValue = this.txtSearch.Text.Trim();
            string categoryCode = string.Empty;
            string categoryFullName = string.Empty;
            if (this.cmbCategory.SelectedValue != null)
            {
                categoryCode = this.cmbCategory.SelectedValue.ToString();
            }
            if (this.cmbBill.SelectedValue != null)
            {
                categoryFullName = this.cmbBill.Text;
            }
            // 获取全部数据
            this.DTWorkFlowCurrent = DotNetService.Instance.WorkFlowCurrentService.GetAuditRecord(this.UserInfo,categoryCode,categoryFullName,searchValue);
            // 获取查询列表
            GetSearchList(recordCount);
        }

        private void GetSearchList(int recordCount)
        {
            // 获取分页数据
            // this.DTWorkFlowCurrent = DotNetService.Instance.WorkFlowCurrentService.GetMonitorPagedDT(this.UserInfo, pager.PageSize, pager.PageIndex, out recordCount, billCategory, searchValue);
            foreach (DataRow dataRow in DTWorkFlowCurrent.Rows)
            {
                dataRow[BaseWorkFlowHistoryEntity.FieldAuditStatus] = BaseBusinessLogic.GetAuditStatus(dataRow[BaseWorkFlowHistoryEntity.FieldAuditStatus].ToString());
            }
            pager.RecordCount = recordCount;
            pager.InitPageInfo();

            // 绑定屏幕数据
            this.grdAuditDetail.AutoGenerateColumns = false;
            this.grdAuditDetail.DataSource = this.DTWorkFlowCurrent.DefaultView;
            this.grdAuditDetail.Refresh();
            if (this.CurrentEntityId.Length > 0)
            {
                this.grdAuditDetail.FirstDisplayedScrollingRowIndex = BaseInterfaceLogic.GetRowIndex(this.DTWorkFlowCurrent, BaseStaffEntity.FieldId, this.CurrentEntityId);
            }
            this.SetControlState();
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.GetItemDetails();
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdAuditDetail);
            //设置每页显示的数量
            pager.PageSize = 20;
            this.Search();
        }
        #endregion

        private void grdAuditDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnAuditDetail.PerformClick();
        }

        private void btnAuditDetail_Click(object sender, EventArgs e)
        {
            DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdAuditDetail);
            if (dataRow != null)
            {
                BaseWorkFlowCurrentEntity workFlowCurrentEntity = new BaseWorkFlowCurrentEntity(dataRow);
                FrmWorkFlowAuditDetail frmWorkFlowAuditDetail = new FrmWorkFlowAuditDetail(workFlowCurrentEntity.CategoryCode, workFlowCurrentEntity.ObjectId);
                frmWorkFlowAuditDetail.Show();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // 弹出关闭对话框
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                int recordCount = 0;                
                this.GetItemsDetail(true);
                // 获取列表
                this.GetSearchList();
                this.GetSearchList(recordCount);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                // 获取全部列表
                this.Search();
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

        private void pager_PageChanged(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 导出Excel
            //string exportFileName = this.Text + ".csv";
            string exportFileName = this.Text + ".xls";
            this.ExportExcel(this.grdAuditDetail, @"\Modules\Export\", exportFileName);
        }

        #region private void SetRowFilter() 设置数据过滤
        /// <summary>
        /// 设置数据过滤
        /// </summary>
        private void SetRowFilter()
        {
            string search = this.txtSearch.Text.Trim();
            if (String.IsNullOrEmpty(search))
            {
                this.DTWorkFlowCurrent.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                if (this.DTWorkFlowCurrent.Columns.Count > 1)
                {
                    string rowFilter = string.Empty;
                    search = StringUtil.GetSearchString(search);

                    rowFilter = StringUtil.GetLike(BaseWorkFlowCurrentEntity.FieldCategoryFullName, search)
                              + " OR " + StringUtil.GetLike(BaseWorkFlowCurrentEntity.FieldObjectFullName, search)
                              + " OR " + StringUtil.GetLike(BaseWorkFlowCurrentEntity.FieldToDepartmentName, search)
                              + " OR " + StringUtil.GetLike(BaseWorkFlowCurrentEntity.FieldToRoleRealName, search)
                              + " OR " + StringUtil.GetLike(BaseWorkFlowCurrentEntity.FieldToUserRealName, search)
                              + " OR " + StringUtil.GetLike(BaseWorkFlowCurrentEntity.FieldAuditUserRealName, search)
                              + " OR " + StringUtil.GetLike(BaseWorkFlowCurrentEntity.FieldAuditUserCode, search);

                    this.DTWorkFlowCurrent.DefaultView.RowFilter = rowFilter;
                }
            }
        }
        #endregion

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.SetRowFilter();
            // 设置按钮状态
            this.SetControlState();
        }

        private void cmbBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                int recordCount = 0;
                // 获取列表
                this.GetSearchList();
                this.GetSearchList(recordCount);
            }
        }
        
        /// <summary>
        /// 获取列表
        /// </summary>
        private void GetSearchList()
        {
            string categoryCode = string.Empty;
            string categoryFullName = string.Empty;
            if (this.cmbCategory.SelectedValue != null)
            {
                categoryCode = this.cmbCategory.SelectedValue.ToString();
            }
            if (this.cmbBill.SelectedValue != null)
            {
                categoryFullName = this.cmbBill.Text;
            }
            this.DTWorkFlowCurrent = DotNetService.Instance.WorkFlowCurrentService.GetAuditRecord(this.UserInfo, categoryCode, categoryFullName, this.txtSearch.Text);
        }

       
    }
}