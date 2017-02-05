namespace DotNet.WinForm
{
    partial class FrmWorkFlowMonitor
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new System.Windows.Forms.Button();
            this.grdAuditDetail = new System.Windows.Forms.DataGridView();
            this.colCategoryFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObjectFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAuditUserRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSendDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAuditIder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToDepartmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToUserRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToRoleRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAuditStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAuditDetail = new System.Windows.Forms.Button();
            this.pager = new DotNet.WinForm.Pager();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblBill = new System.Windows.Forms.Label();
            this.cmbBill = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdAuditDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(885, 503);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grdAuditDetail
            // 
            this.grdAuditDetail.AllowUserToAddRows = false;
            this.grdAuditDetail.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.grdAuditDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdAuditDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAuditDetail.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAuditDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdAuditDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAuditDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCategoryFullName,
            this.colObjectFullName,
            this.colCreateBy,
            this.colAuditUserRealName,
            this.colSendDate,
            this.colAuditIder,
            this.colToDepartmentName,
            this.colToUserRealName,
            this.colToRoleRealName,
            this.colAuditStatus});
            this.grdAuditDetail.Location = new System.Drawing.Point(7, 40);
            this.grdAuditDetail.Name = "grdAuditDetail";
            this.grdAuditDetail.ReadOnly = true;
            this.grdAuditDetail.RowTemplate.Height = 23;
            this.grdAuditDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAuditDetail.Size = new System.Drawing.Size(953, 421);
            this.grdAuditDetail.TabIndex = 4;
            this.grdAuditDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAuditDetail_CellDoubleClick);
            // 
            // colCategoryFullName
            // 
            this.colCategoryFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colCategoryFullName.DataPropertyName = "CategoryFullName";
            this.colCategoryFullName.FillWeight = 60F;
            this.colCategoryFullName.Frozen = true;
            this.colCategoryFullName.HeaderText = "分类";
            this.colCategoryFullName.Name = "colCategoryFullName";
            this.colCategoryFullName.ReadOnly = true;
            this.colCategoryFullName.Width = 60;
            // 
            // colObjectFullName
            // 
            this.colObjectFullName.DataPropertyName = "ObjectFullName";
            this.colObjectFullName.FillWeight = 120F;
            this.colObjectFullName.Frozen = true;
            this.colObjectFullName.HeaderText = "名称";
            this.colObjectFullName.Name = "colObjectFullName";
            this.colObjectFullName.ReadOnly = true;
            this.colObjectFullName.Width = 120;
            // 
            // colCreateBy
            // 
            this.colCreateBy.DataPropertyName = "CreateBy";
            this.colCreateBy.Frozen = true;
            this.colCreateBy.HeaderText = "发起人";
            this.colCreateBy.MaxInputLength = 20;
            this.colCreateBy.Name = "colCreateBy";
            this.colCreateBy.ReadOnly = true;
            this.colCreateBy.Width = 70;
            // 
            // colAuditUserRealName
            // 
            this.colAuditUserRealName.DataPropertyName = "AuditUserRealName";
            this.colAuditUserRealName.HeaderText = "审核人";
            this.colAuditUserRealName.MaxInputLength = 20;
            this.colAuditUserRealName.Name = "colAuditUserRealName";
            this.colAuditUserRealName.ReadOnly = true;
            this.colAuditUserRealName.Width = 70;
            // 
            // colSendDate
            // 
            this.colSendDate.DataPropertyName = "AuditDate";
            this.colSendDate.FillWeight = 110F;
            this.colSendDate.HeaderText = "审核日期";
            this.colSendDate.MaxInputLength = 50;
            this.colSendDate.Name = "colSendDate";
            this.colSendDate.ReadOnly = true;
            this.colSendDate.Width = 110;
            // 
            // colAuditIder
            // 
            this.colAuditIder.DataPropertyName = "AuditIdea";
            this.colAuditIder.FillWeight = 150F;
            this.colAuditIder.HeaderText = "批示";
            this.colAuditIder.MaxInputLength = 600;
            this.colAuditIder.Name = "colAuditIder";
            this.colAuditIder.ReadOnly = true;
            this.colAuditIder.Width = 150;
            // 
            // colToDepartmentName
            // 
            this.colToDepartmentName.DataPropertyName = "ToDepartmentName";
            this.colToDepartmentName.FillWeight = 80F;
            this.colToDepartmentName.HeaderText = "待审部门";
            this.colToDepartmentName.MaxInputLength = 50;
            this.colToDepartmentName.Name = "colToDepartmentName";
            this.colToDepartmentName.ReadOnly = true;
            this.colToDepartmentName.Width = 80;
            // 
            // colToUserRealName
            // 
            this.colToUserRealName.DataPropertyName = "ToUserRealName";
            this.colToUserRealName.FillWeight = 80F;
            this.colToUserRealName.HeaderText = "待审人";
            this.colToUserRealName.MaxInputLength = 50;
            this.colToUserRealName.Name = "colToUserRealName";
            this.colToUserRealName.ReadOnly = true;
            this.colToUserRealName.Width = 70;
            // 
            // colToRoleRealName
            // 
            this.colToRoleRealName.DataPropertyName = "ToRoleRealName";
            this.colToRoleRealName.FillWeight = 80F;
            this.colToRoleRealName.HeaderText = "待审角色";
            this.colToRoleRealName.Name = "colToRoleRealName";
            this.colToRoleRealName.ReadOnly = true;
            this.colToRoleRealName.Width = 80;
            // 
            // colAuditStatus
            // 
            this.colAuditStatus.DataPropertyName = "AuditStatus";
            this.colAuditStatus.FillWeight = 80F;
            this.colAuditStatus.HeaderText = "审核状态";
            this.colAuditStatus.MaxInputLength = 200;
            this.colAuditStatus.Name = "colAuditStatus";
            this.colAuditStatus.ReadOnly = true;
            this.colAuditStatus.Width = 80;
            // 
            // btnAuditDetail
            // 
            this.btnAuditDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAuditDetail.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAuditDetail.Location = new System.Drawing.Point(654, 503);
            this.btnAuditDetail.Name = "btnAuditDetail";
            this.btnAuditDetail.Size = new System.Drawing.Size(115, 23);
            this.btnAuditDetail.TabIndex = 6;
            this.btnAuditDetail.Text = "审核明细...";
            this.btnAuditDetail.UseVisualStyleBackColor = true;
            this.btnAuditDetail.Click += new System.EventHandler(this.btnAuditDetail_Click);
            // 
            // pager
            // 
            this.pager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pager.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pager.Location = new System.Drawing.Point(535, 473);
            this.pager.Name = "pager";
            this.pager.PageIndex = 1;
            this.pager.RecordCount = 0;
            this.pager.Size = new System.Drawing.Size(432, 24);
            this.pager.TabIndex = 5;
            this.pager.PageChanged += new DotNet.WinForm.PageChangedEventHandler(this.pager_PageChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.Location = new System.Drawing.Point(521, 13);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(106, 12);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "查询内容(&C)：";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(629, 9);
            this.txtSearch.MaxLength = 20;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(164, 21);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(804, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "查询(&F)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(96, 9);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(180, 20);
            this.cmbCategory.TabIndex = 1;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(28, 13);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(65, 12);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "单据分类：";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(771, 503);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(111, 23);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "导出Excel...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblBill
            // 
            this.lblBill.AutoSize = true;
            this.lblBill.Location = new System.Drawing.Point(288, 14);
            this.lblBill.Name = "lblBill";
            this.lblBill.Size = new System.Drawing.Size(41, 12);
            this.lblBill.TabIndex = 15;
            this.lblBill.Text = "单据：";
            // 
            // cmbBill
            // 
            this.cmbBill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBill.FormattingEnabled = true;
            this.cmbBill.Location = new System.Drawing.Point(335, 9);
            this.cmbBill.Name = "cmbBill";
            this.cmbBill.Size = new System.Drawing.Size(180, 20);
            this.cmbBill.TabIndex = 16;
            this.cmbBill.SelectedIndexChanged += new System.EventHandler(this.cmbBill_SelectedIndexChanged);
            // 
            // FrmWorkFlowMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(968, 529);
            this.Controls.Add(this.lblBill);
            this.Controls.Add(this.cmbBill);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.pager);
            this.Controls.Add(this.btnAuditDetail);
            this.Controls.Add(this.grdAuditDetail);
            this.Controls.Add(this.btnClose);
            this.Name = "FrmWorkFlowMonitor";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "已审核流程";
            ((System.ComponentModel.ISupportInitialize)(this.grdAuditDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView grdAuditDetail;
        private System.Windows.Forms.Button btnAuditDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoryFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObjectFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuditUserRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSendDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuditIder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToDepartmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToUserRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToRoleRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuditStatus;
        private DotNet.WinForm.Pager pager;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblBill;
        private System.Windows.Forms.ComboBox cmbBill;
    }
}