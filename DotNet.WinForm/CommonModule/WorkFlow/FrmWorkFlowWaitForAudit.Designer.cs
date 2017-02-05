namespace DotNet.WinForm
{
    partial class FrmWorkFlowWaitForAudit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdWorkFlowCurrent = new System.Windows.Forms.DataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCategoryFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObjectFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSendDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAuditUserRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAuditIder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToDepartmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToRoleRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToUserRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAuditStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExport = new System.Windows.Forms.Button();
            this.ucWorkFlow = new DotNet.WinForm.UCWorkFlow();
            this.lblBill = new System.Windows.Forms.Label();
            this.cmbBill = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkFlowCurrent)).BeginInit();
            this.SuspendLayout();
            // 
            // grdWorkFlowCurrent
            // 
            this.grdWorkFlowCurrent.AllowUserToAddRows = false;
            this.grdWorkFlowCurrent.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.grdWorkFlowCurrent.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdWorkFlowCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdWorkFlowCurrent.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdWorkFlowCurrent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdWorkFlowCurrent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdWorkFlowCurrent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colCategoryFullName,
            this.colObjectFullName,
            this.colCreateBy,
            this.colCreateOn,
            this.colSendDate,
            this.colAuditUserRealName,
            this.colAuditIder,
            this.colToDepartmentName,
            this.colToRoleRealName,
            this.colToUserRealName,
            this.colAuditStatus});
            this.grdWorkFlowCurrent.Location = new System.Drawing.Point(6, 39);
            this.grdWorkFlowCurrent.MultiSelect = false;
            this.grdWorkFlowCurrent.Name = "grdWorkFlowCurrent";
            this.grdWorkFlowCurrent.RowTemplate.Height = 23;
            this.grdWorkFlowCurrent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdWorkFlowCurrent.Size = new System.Drawing.Size(1012, 492);
            this.grdWorkFlowCurrent.TabIndex = 0;
            this.grdWorkFlowCurrent.SelectionChanged += new System.EventHandler(this.grdWorkFlowCurrent_SelectionChanged);
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "Selected";
            this.colSelected.FillWeight = 50F;
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Width = 50;
            // 
            // colCategoryFullName
            // 
            this.colCategoryFullName.DataPropertyName = "CategoryFullName";
            this.colCategoryFullName.Frozen = true;
            this.colCategoryFullName.HeaderText = "单据类型";
            this.colCategoryFullName.Name = "colCategoryFullName";
            this.colCategoryFullName.Width = 120;
            // 
            // colObjectFullName
            // 
            this.colObjectFullName.DataPropertyName = "ObjectFullName";
            this.colObjectFullName.FillWeight = 120F;
            this.colObjectFullName.Frozen = true;
            this.colObjectFullName.HeaderText = "单据名称";
            this.colObjectFullName.Name = "colObjectFullName";
            this.colObjectFullName.ReadOnly = true;
            this.colObjectFullName.Width = 120;
            // 
            // colCreateBy
            // 
            this.colCreateBy.DataPropertyName = "CreateBy";
            this.colCreateBy.Frozen = true;
            this.colCreateBy.HeaderText = "发起人";
            this.colCreateBy.Name = "colCreateBy";
            // 
            // colCreateOn
            // 
            this.colCreateOn.DataPropertyName = "CreateOn";
            this.colCreateOn.Frozen = true;
            this.colCreateOn.HeaderText = "发起日期";
            this.colCreateOn.Name = "colCreateOn";
            this.colCreateOn.Width = 110;
            // 
            // colSendDate
            // 
            this.colSendDate.DataPropertyName = "AuditDate";
            this.colSendDate.FillWeight = 110F;
            this.colSendDate.Frozen = true;
            this.colSendDate.HeaderText = "审核日期";
            this.colSendDate.MaxInputLength = 50;
            this.colSendDate.Name = "colSendDate";
            this.colSendDate.ReadOnly = true;
            this.colSendDate.Width = 110;
            // 
            // colAuditUserRealName
            // 
            this.colAuditUserRealName.DataPropertyName = "AuditUserRealName";
            this.colAuditUserRealName.HeaderText = "审核人";
            this.colAuditUserRealName.MaxInputLength = 20;
            this.colAuditUserRealName.Name = "colAuditUserRealName";
            this.colAuditUserRealName.ReadOnly = true;
            this.colAuditUserRealName.Width = 80;
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
            // colToRoleRealName
            // 
            this.colToRoleRealName.DataPropertyName = "ToRoleRealName";
            this.colToRoleRealName.FillWeight = 80F;
            this.colToRoleRealName.HeaderText = "待审角色";
            this.colToRoleRealName.Name = "colToRoleRealName";
            this.colToRoleRealName.ReadOnly = true;
            this.colToRoleRealName.Width = 80;
            // 
            // colToUserRealName
            // 
            this.colToUserRealName.DataPropertyName = "ToUserRealName";
            this.colToUserRealName.FillWeight = 80F;
            this.colToUserRealName.HeaderText = "待审人";
            this.colToUserRealName.MaxInputLength = 50;
            this.colToUserRealName.Name = "colToUserRealName";
            this.colToUserRealName.ReadOnly = true;
            this.colToUserRealName.Width = 80;
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
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(904, 9);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(111, 23);
            this.btnExport.TabIndex = 16;
            this.btnExport.Text = "导出Excel...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // ucWorkFlow
            // 
            this.ucWorkFlow.AllowNull = true;
            this.ucWorkFlow.AllowSelect = true;
            this.ucWorkFlow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucWorkFlow.Location = new System.Drawing.Point(8, 538);
            this.ucWorkFlow.MultiSelect = false;
            this.ucWorkFlow.Name = "ucWorkFlow";
            this.ucWorkFlow.PermissionItemScopeCode = "";
            this.ucWorkFlow.SelectedFullName = "";
            this.ucWorkFlow.SelectedIds = null;
            this.ucWorkFlow.Size = new System.Drawing.Size(1010, 23);
            this.ucWorkFlow.TabIndex = 17;
            this.ucWorkFlow.WorkFlowCategory = "ByUser";
            this.ucWorkFlow.WorkFlowCode = "";
            this.ucWorkFlow.WorkFlowType = null;
            this.ucWorkFlow.BeforAuditPassClick += new DotNet.WinForm.UCWorkFlow.AuditPassClickEventHandler(this.ucWorkFlow_BeforAuditPassClick);
            this.ucWorkFlow.AfterAuditPassClick += new DotNet.WinForm.UCWorkFlow.AuditPassClickEventHandler(this.ucWorkFlow_AfterAuditPassClick);
            this.ucWorkFlow.BeforAuditRejectClick += new DotNet.WinForm.UCWorkFlow.AuditRejectClickEventHandler(this.ucWorkFlow_BeforAuditRejectClick);
            this.ucWorkFlow.AfterAuditRejectClick += new DotNet.WinForm.UCWorkFlow.AuditRejectClickEventHandler(this.ucWorkFlow_AfterAuditRejectClick);
            this.ucWorkFlow.BeforTransmitClick += new DotNet.WinForm.UCWorkFlow.TransmitClickEventHandler(this.ucWorkFlow_BeforTransmitClick);
            this.ucWorkFlow.AfterTransmitClick += new DotNet.WinForm.UCWorkFlow.TransmitClickEventHandler(this.ucWorkFlow_AfterTransmitClick);
            this.ucWorkFlow.BeforAuditQuashClick += new DotNet.WinForm.UCWorkFlow.AuditQuashClickEventHandler(this.ucWorkFlow_BeforAuditQuashClick);
            this.ucWorkFlow.AfterAuditQuashClick += new DotNet.WinForm.UCWorkFlow.AuditQuashClickEventHandler(this.ucWorkFlow_AfterAuditQuashClick);
            this.ucWorkFlow.BeforAuditDetailClick += new DotNet.WinForm.UCWorkFlow.AuditDetailClickEventHandler(this.ucWorkFlow_BeforAuditDetailClick);
            this.ucWorkFlow.AfterAuditDetailClick += new DotNet.WinForm.UCWorkFlow.AuditDetailClickEventHandler(this.ucWorkFlow_AfterAuditDetailClick);
            // 
            // lblBill
            // 
            this.lblBill.AutoSize = true;
            this.lblBill.Location = new System.Drawing.Point(227, 14);
            this.lblBill.Name = "lblBill";
            this.lblBill.Size = new System.Drawing.Size(41, 12);
            this.lblBill.TabIndex = 20;
            this.lblBill.Text = "单据：";
            // 
            // cmbBill
            // 
            this.cmbBill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBill.FormattingEnabled = true;
            this.cmbBill.Location = new System.Drawing.Point(274, 9);
            this.cmbBill.Name = "cmbBill";
            this.cmbBill.Size = new System.Drawing.Size(180, 20);
            this.cmbBill.TabIndex = 21;
            this.cmbBill.SelectedIndexChanged += new System.EventHandler(this.cmbBill_SelectedIndexChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(22, 13);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(41, 12);
            this.lblCategory.TabIndex = 18;
            this.lblCategory.Text = "分类：";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(76, 9);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(126, 20);
            this.cmbCategory.TabIndex = 19;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.Location = new System.Drawing.Point(482, 14);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(106, 12);
            this.lblSearch.TabIndex = 23;
            this.lblSearch.Text = "查询内容(&C)：";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(590, 10);
            this.txtSearch.MaxLength = 20;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(119, 21);
            this.txtSearch.TabIndex = 22;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(715, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 24;
            this.btnSearch.Text = "查询(&F)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FrmWorkFlowWaitForAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 567);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblBill);
            this.Controls.Add(this.cmbBill);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.ucWorkFlow);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.grdWorkFlowCurrent);
            this.Name = "FrmWorkFlowWaitForAudit";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "待审核流程";
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkFlowCurrent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdWorkFlowCurrent;
        private System.Windows.Forms.Button btnExport;
        private UCWorkFlow ucWorkFlow;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoryFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObjectFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSendDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuditUserRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuditIder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToDepartmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToRoleRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToUserRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuditStatus;
        private System.Windows.Forms.Label lblBill;
        private System.Windows.Forms.ComboBox cmbBill;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
    }
}