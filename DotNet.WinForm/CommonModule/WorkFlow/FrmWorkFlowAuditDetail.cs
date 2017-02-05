//--------------------------------------------------------------------
// All Rights Reserved ,Copyright (C) 2012 , Hairihan TECH, Ltd. .
//--------------------------------------------------------------------

using System;
using System.Data;

namespace DotNet.WinForm
{    
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FrmWorkFlowAuditDetail.cs
    /// 权限管理-管理权限窗体
    ///		
    /// 修改记录
    /// 
    ///     2010.10.10 版本：1.2 JiRiGaLa 审核状态用中文显示。
    ///     2010.08.05 版本：1.1 JiRiGaLa 重新整理代码。
    ///     2007.07.18 版本：1.0 JiRiGaLa Gredview显示。
    /// 
    /// 版本：1.2
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.10.10</date>
    /// </author> 
    /// </summary> 
    public partial class FrmWorkFlowAuditDetail : BaseForm
    {
        public string CategoryId = string.Empty;
        public string ObjectId = string.Empty;

        public FrmWorkFlowAuditDetail()
        {
            InitializeComponent();
        }

        public FrmWorkFlowAuditDetail(String categoryId, string objectId)
            : this()
        {
            this.CategoryId = categoryId;
            this.ObjectId = objectId;
        }

        #region private void BindData() 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        private void BindData()
        {
            this.grdAuditDetail.AutoGenerateColumns = false;
            DataTable dataTable = DotNetService.Instance.WorkFlowCurrentService.GetAuditDetailDT(this.UserInfo, this.CategoryId, this.ObjectId);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                dataRow[BaseWorkFlowHistoryEntity.FieldAuditStatus] = BaseBusinessLogic.GetAuditStatus(dataRow[BaseWorkFlowHistoryEntity.FieldAuditStatus].ToString());
            }
            this.grdAuditDetail.DataSource = dataTable.DefaultView;
            this.grdAuditDetail.Refresh();
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdAuditDetail);
            // 绑定屏幕数据
            this.BindData();
            this.btnExport.Enabled = this.grdAuditDetail.RowCount > 0;
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 导出Excel
            //string exportFileName = this.Text + ".csv";
            string exportFileName = this.Text + ".xls";
            this.ExportExcel(this.grdAuditDetail , @"\Modules\Export\", exportFileName);
        }
    }
}