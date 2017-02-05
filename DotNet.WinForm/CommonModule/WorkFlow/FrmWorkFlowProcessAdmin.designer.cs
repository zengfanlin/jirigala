namespace DotNet.WinForm
{
    partial class FrmWorkFlowProcessAdmin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdWorkFlow = new System.Windows.Forms.DataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBatchSave = new System.Windows.Forms.Button();
            this.btnBatchDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnStepAdmin = new System.Windows.Forms.Button();
            this.cmbBillCode = new System.Windows.Forms.ComboBox();
            this.lblDocument = new System.Windows.Forms.Label();
            this.lblContents = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblCategories = new System.Windows.Forms.Label();
            this.cmbWorkFlowCategory = new System.Windows.Forms.ComboBox();
            this.cmbAuditCategoryCode = new System.Windows.Forms.ComboBox();
            this.lblAuditCategoryCode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkFlow)).BeginInit();
            this.SuspendLayout();
            // 
            // grdWorkFlow
            // 
            this.grdWorkFlow.AllowUserToAddRows = false;
            this.grdWorkFlow.AllowUserToDeleteRows = false;
            this.grdWorkFlow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdWorkFlow.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdWorkFlow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdWorkFlow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdWorkFlow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colCode,
            this.colFullName,
            this.colDescription});
            this.grdWorkFlow.Location = new System.Drawing.Point(7, 38);
            this.grdWorkFlow.Name = "grdWorkFlow";
            this.grdWorkFlow.RowTemplate.Height = 23;
            this.grdWorkFlow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdWorkFlow.Size = new System.Drawing.Size(965, 494);
            this.grdWorkFlow.TabIndex = 4;
            this.grdWorkFlow.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdWorkFlow_CellDoubleClick);
            this.grdWorkFlow.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grdWorkFlow_UserDeletingRow);
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "Selected";
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Width = 50;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            this.colCode.HeaderText = "编号";
            this.colCode.MaxInputLength = 20;
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            this.colCode.Width = 200;
            // 
            // colFullName
            // 
            this.colFullName.DataPropertyName = "FullName";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colFullName.DefaultCellStyle = dataGridViewCellStyle2;
            this.colFullName.HeaderText = "名称";
            this.colFullName.MaxInputLength = 50;
            this.colFullName.Name = "colFullName";
            this.colFullName.Width = 200;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colDescription.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDescription.HeaderText = "描述";
            this.colDescription.MaxInputLength = 200;
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 250;
            // 
            // btnBatchSave
            // 
            this.btnBatchSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchSave.Location = new System.Drawing.Point(814, 537);
            this.btnBatchSave.Name = "btnBatchSave";
            this.btnBatchSave.Size = new System.Drawing.Size(75, 23);
            this.btnBatchSave.TabIndex = 9;
            this.btnBatchSave.Text = "保存(&S)";
            this.btnBatchSave.UseVisualStyleBackColor = true;
            this.btnBatchSave.Click += new System.EventHandler(this.btnBatchSave_Click);
            // 
            // btnBatchDelete
            // 
            this.btnBatchDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchDelete.Location = new System.Drawing.Point(734, 537);
            this.btnBatchDelete.Name = "btnBatchDelete";
            this.btnBatchDelete.Size = new System.Drawing.Size(75, 23);
            this.btnBatchDelete.TabIndex = 8;
            this.btnBatchDelete.Text = "删除(&D)";
            this.btnBatchDelete.UseVisualStyleBackColor = true;
            this.btnBatchDelete.Click += new System.EventHandler(this.btnBatchDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(502, 537);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "编辑(&E)...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(894, 537);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(421, 537);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "添加(&A)...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnStepAdmin
            // 
            this.btnStepAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStepAdmin.Location = new System.Drawing.Point(582, 537);
            this.btnStepAdmin.Name = "btnStepAdmin";
            this.btnStepAdmin.Size = new System.Drawing.Size(146, 23);
            this.btnStepAdmin.TabIndex = 7;
            this.btnStepAdmin.Text = "工作流程步骤定义(&T)...";
            this.btnStepAdmin.UseVisualStyleBackColor = true;
            this.btnStepAdmin.Click += new System.EventHandler(this.btnStepAdmin_Click);
            // 
            // cmbBillCode
            // 
            this.cmbBillCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBillCode.Location = new System.Drawing.Point(525, 11);
            this.cmbBillCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbBillCode.Name = "cmbBillCode";
            this.cmbBillCode.Size = new System.Drawing.Size(182, 20);
            this.cmbBillCode.TabIndex = 3;
            this.cmbBillCode.SelectedIndexChanged += new System.EventHandler(this.cmbBillCode_SelectedIndexChanged);
            // 
            // lblDocument
            // 
            this.lblDocument.Location = new System.Drawing.Point(456, 13);
            this.lblDocument.Name = "lblDocument";
            this.lblDocument.Size = new System.Drawing.Size(64, 16);
            this.lblDocument.TabIndex = 2;
            this.lblDocument.Text = "单据：";
            this.lblDocument.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblContents
            // 
            this.lblContents.Location = new System.Drawing.Point(719, 14);
            this.lblContents.Name = "lblContents";
            this.lblContents.Size = new System.Drawing.Size(89, 12);
            this.lblContents.TabIndex = 11;
            this.lblContents.Text = "查询内容(&C)：";
            this.lblContents.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(813, 11);
            this.txtSearch.MaxLength = 20;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(157, 21);
            this.txtSearch.TabIndex = 12;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(312, 537);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(104, 23);
            this.btnExport.TabIndex = 15;
            this.btnExport.Text = "导出Excel...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblCategories
            // 
            this.lblCategories.Location = new System.Drawing.Point(174, 13);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(93, 16);
            this.lblCategories.TabIndex = 16;
            this.lblCategories.Text = "分类：";
            this.lblCategories.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbWorkFlowCategory
            // 
            this.cmbWorkFlowCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkFlowCategory.Location = new System.Drawing.Point(272, 11);
            this.cmbWorkFlowCategory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbWorkFlowCategory.Name = "cmbWorkFlowCategory";
            this.cmbWorkFlowCategory.Size = new System.Drawing.Size(182, 20);
            this.cmbWorkFlowCategory.TabIndex = 17;
            this.cmbWorkFlowCategory.SelectedIndexChanged += new System.EventHandler(this.cmbWorkFlowCategory_SelectedIndexChanged);
            // 
            // cmbAuditCategoryCode
            // 
            this.cmbAuditCategoryCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAuditCategoryCode.Location = new System.Drawing.Point(86, 10);
            this.cmbAuditCategoryCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbAuditCategoryCode.Name = "cmbAuditCategoryCode";
            this.cmbAuditCategoryCode.Size = new System.Drawing.Size(114, 20);
            this.cmbAuditCategoryCode.TabIndex = 19;
            this.cmbAuditCategoryCode.SelectedIndexChanged += new System.EventHandler(this.cmbAuditCategoryCode_SelectedIndexChanged);
            // 
            // lblAuditCategoryCode
            // 
            this.lblAuditCategoryCode.Location = new System.Drawing.Point(7, 12);
            this.lblAuditCategoryCode.Name = "lblAuditCategoryCode";
            this.lblAuditCategoryCode.Size = new System.Drawing.Size(74, 16);
            this.lblAuditCategoryCode.TabIndex = 18;
            this.lblAuditCategoryCode.Text = "流程类型：";
            this.lblAuditCategoryCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmWorkFlowProcessAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(980, 564);
            this.Controls.Add(this.cmbAuditCategoryCode);
            this.Controls.Add(this.lblAuditCategoryCode);
            this.Controls.Add(this.cmbWorkFlowCategory);
            this.Controls.Add(this.lblCategories);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblContents);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cmbBillCode);
            this.Controls.Add(this.lblDocument);
            this.Controls.Add(this.btnStepAdmin);
            this.Controls.Add(this.grdWorkFlow);
            this.Controls.Add(this.btnBatchSave);
            this.Controls.Add(this.btnBatchDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmWorkFlowProcessAdmin";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "审批流程定义管理";
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkFlow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdWorkFlow;
        private System.Windows.Forms.Button btnBatchSave;
        private System.Windows.Forms.Button btnBatchDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnStepAdmin;
        private System.Windows.Forms.ComboBox cmbBillCode;
        private System.Windows.Forms.Label lblDocument;
        private System.Windows.Forms.Label lblContents;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblCategories;
        private System.Windows.Forms.ComboBox cmbWorkFlowCategory;
        private System.Windows.Forms.ComboBox cmbAuditCategoryCode;
        private System.Windows.Forms.Label lblAuditCategoryCode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;

    }
}