//--------------------------------------------------------------------
// All Rights Reserved ,Copyright (C) 2012 , Hairihan TECH, Ltd. .
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FrmMyWorkFlow.cs
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
    public partial class FrmWorkFlowWaitForAudit : BaseForm
    {
        DataTable DTWorkFlowCurrent = null;

        public FrmWorkFlowWaitForAudit()
        {
            InitializeComponent();
        }

        #region private void GetList() 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        private void GetList()
        {
            this.DTWorkFlowCurrent = DotNetService.Instance.WorkFlowCurrentService.GetWaitForAudit(this.UserInfo);
        }
        #endregion

        #region private void BindData() 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        private void BindData()
        {
            this.grdWorkFlowCurrent.AutoGenerateColumns = false;
            foreach (DataRow dataRow in DTWorkFlowCurrent.Rows)
            {
                dataRow[BaseWorkFlowHistoryEntity.FieldAuditStatus] = BaseBusinessLogic.GetAuditStatus(dataRow[BaseWorkFlowHistoryEntity.FieldAuditStatus].ToString());
            }
            this.DTWorkFlowCurrent.DefaultView.Sort = BaseWorkFlowCurrentEntity.FieldSortCode;
            this.grdWorkFlowCurrent.DataSource = this.DTWorkFlowCurrent.DefaultView;
            this.grdWorkFlowCurrent.Refresh();
            this.SetControlState();
            if (this.grdWorkFlowCurrent.Rows.Count == 0)
            {
                this.ucWorkFlow.WorkFlowIds = null;
            }
            // 初始化控件状态
            this.ucWorkFlow.SetControlState();
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 绑定下拉框
            this.GetItemDetails();
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdWorkFlowCurrent);
            // 获取列表
            this.GetList();
            // 绑定屏幕数据
            this.BindData();
            // 这里设置他是否有最终审核权限？
            //this.ucFreeWorkFlow.PermissionAuditing = this.UserInfo.IsAdministrator;           
        }
        #endregion

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

        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // this.btnAuditDetail.Enabled = this.grdAuditDetail.RowCount > 0;
            this.btnExport.Enabled = this.grdWorkFlowCurrent.RowCount > 0;
        }

        private void grdAuditDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // this.btnAuditDetail.PerformClick();
        }

        private void btnAuditDetail_Click(object sender, EventArgs e)
        {
            DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdWorkFlowCurrent);
            if (dataRow != null)
            {
                BaseWorkFlowCurrentEntity workFlowCurrentEntity = new BaseWorkFlowCurrentEntity(dataRow);
                FrmWorkFlowAuditDetail frmWorkFlowAuditDetail = new FrmWorkFlowAuditDetail(workFlowCurrentEntity.CategoryCode, workFlowCurrentEntity.ObjectId);
                frmWorkFlowAuditDetail.Show();
            }
        }

        #region private string[] GetSelecteIds() 获得已被选择的部门主键数组
        /// <summary>
        /// 获得已被选择的主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelecteIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdWorkFlowCurrent, BaseWorkFlowCurrentEntity.FieldId, "colSelected", true);
        }
        #endregion

        private bool GetIds()
        {
            bool returnValue = false;
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdWorkFlowCurrent, "colSelected"))
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    this.ucWorkFlow.WorkFlowIds = this.GetSelecteIds();
                    returnValue = true;
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
            return returnValue;
        }

        private bool ucWorkFlowUser_BeforBtnAuditDetailClick(string categoryId, string objectId)
        {
            DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdWorkFlowCurrent);
            if (dataRow != null)
            {
                BaseWorkFlowCurrentEntity workFlowCurrentEntity = new BaseWorkFlowCurrentEntity(dataRow);
                FrmWorkFlowAuditDetail frmWorkFlowAuditDetail = new FrmWorkFlowAuditDetail(workFlowCurrentEntity.CategoryCode, workFlowCurrentEntity.ObjectId);
                frmWorkFlowAuditDetail.Show();
            }
            return false;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 导出Excel
            //string exportFileName = this.Text + ".csv";
            string exportFileName = this.Text + ".xls";
            this.ExportExcel(this.grdWorkFlowCurrent, @"\Modules\Export\", exportFileName);
        }

        /// <summary>
        /// 点审核明细时发生
        /// </summary>
        /// <returns></returns>
        private bool ucWorkFlow_BeforAuditDetailClick()
        {
            // 获取主键组
            return this.GetIds();
        }

        /// <summary>
        /// 点击审批通过时发生
        /// </summary>
        /// <returns></returns>
        private bool ucWorkFlow_BeforAuditPassClick()
        {
            // 获取主键组
            return this.GetIds();
        }

        /// <summary>
        /// 点击撤销时发生
        /// </summary>
        /// <returns></returns>
        private bool ucWorkFlow_BeforAuditQuashClick()
        {
            // 获取主键组
            return this.GetIds();
        }

        /// <summary>
        /// 点击退回时发生
        /// </summary>
        /// <returns></returns>
        private bool ucWorkFlow_BeforAuditRejectClick()
        {
            // 获取主键组
            return this.GetIds();
        }

        /// <summary>
        /// 点击转发时发生
        /// </summary>
        /// <returns></returns>
        private bool ucWorkFlow_BeforTransmitClick()
        {
            // 获取主键组
            return this.GetIds();
        }

        /// <summary>
        /// 点击审核明细后发生
        /// </summary>
        /// <returns></returns>
        private bool ucWorkFlow_AfterAuditDetailClick()
        {
            // 刷新
            this.FormOnLoad();
            return true;
        }

        /// <summary>
        /// 点击审批通过后发生
        /// </summary>
        /// <returns></returns>
        private bool ucWorkFlow_AfterAuditPassClick()
        {
            // 刷新
            this.FormOnLoad();
            return true;
        }

        /// <summary>
        /// 点击审批撤销后发生
        /// </summary>
        /// <returns></returns>
        private bool ucWorkFlow_AfterAuditQuashClick()
        {
            // 刷新
            this.FormOnLoad();
            return true;
        }

        /// <summary>
        /// 点击审批退回后发生
        /// </summary>
        /// <returns></returns>
        private bool ucWorkFlow_AfterAuditRejectClick()
        {
            // 刷新
            this.FormOnLoad();
            return true;
        }

        /// <summary>
        /// 点击审批转发后发生
        /// </summary>
        /// <returns></returns>
        private bool ucWorkFlow_AfterTransmitClick()
        {
            // 刷新
            this.FormOnLoad();
            return true;
        }

        private void grdWorkFlowCurrent_SelectionChanged(object sender, EventArgs e)
        {
            if (this.grdWorkFlowCurrent.Rows.Count > 0)
            {
                DataGridViewRow dgvRow = this.grdWorkFlowCurrent.Rows[this.grdWorkFlowCurrent.CurrentRow.Index];
                DataRowView dataRowView = dgvRow.DataBoundItem as DataRowView;
                // 获取单个主键来设置按钮状态
                this.ucWorkFlow.WorkFlowIds = new string[] { dataRowView.Row[BaseWorkFlowCurrentEntity.FieldId].ToString() };
            }
            else
            {
                this.ucWorkFlow.WorkFlowIds = null;
            }
            // 设置状态
            this.ucWorkFlow.SetControlState();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                this.GetItemsDetail(true);
                // 查询列表
                SearchList();
            }
        }

        private void cmbBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 查询列表
            SearchList();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        private void SearchList()
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
            // 获取数据
            this.DTWorkFlowCurrent = DotNetService.Instance.WorkFlowCurrentService.GetWaitForAudit(this.UserInfo, this.UserInfo.Id, categoryCode, categoryFullName, this.txtSearch.Text);
            // 绑定数据
            this.BindData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 查询列表
            SearchList();
        }

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
                              + " OR " + StringUtil.GetLike(BaseWorkFlowCurrentEntity.FieldAuditIdea, search)
                              + " OR " + StringUtil.GetLike(BaseWorkFlowCurrentEntity.FieldAuditUserCode, search);

                    this.DTWorkFlowCurrent.DefaultView.RowFilter = rowFilter;
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.SetRowFilter();
        }
    }
}