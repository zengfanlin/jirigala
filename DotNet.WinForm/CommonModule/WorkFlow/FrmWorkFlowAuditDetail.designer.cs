namespace DotNet.WinForm
{
    partial class FrmWorkFlowAuditDetail
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
            this.btnClose = new System.Windows.Forms.Button();
            this.grdAuditDetail = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.colSendDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToUserRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToDepartmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToRoleRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAuditUserRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAuditDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAuditStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAuditIder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdAuditDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(786, 503);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grdAuditDetail
            // 
            this.grdAuditDetail.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.grdAuditDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdAuditDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAuditDetail.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAuditDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdAuditDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAuditDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSendDate,
            this.colToUserRealName,
            this.colToDepartmentName,
            this.colToRoleRealName,
            this.colAuditUserRealName,
            this.colAuditDate,
            this.colAuditStatus,
            this.colAuditIder});
            this.grdAuditDetail.Location = new System.Drawing.Point(7, 11);
            this.grdAuditDetail.Name = "grdAuditDetail";
            this.grdAuditDetail.RowTemplate.Height = 23;
            this.grdAuditDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAuditDetail.Size = new System.Drawing.Size(854, 485);
            this.grdAuditDetail.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(669, 503);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(111, 23);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "导出Excel...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // colSendDate
            // 
            this.colSendDate.DataPropertyName = "SendDate";
            this.colSendDate.FillWeight = 110F;
            this.colSendDate.HeaderText = "提交日期";
            this.colSendDate.MaxInputLength = 50;
            this.colSendDate.Name = "colSendDate";
            this.colSendDate.ReadOnly = true;
            this.colSendDate.Width = 110;
            // 
            // colToUserRealName
            // 
            this.colToUserRealName.DataPropertyName = "ToUserRealName";
            this.colToUserRealName.HeaderText = "送审人";
            this.colToUserRealName.MaxInputLength = 20;
            this.colToUserRealName.Name = "colToUserRealName";
            this.colToUserRealName.ReadOnly = true;
            this.colToUserRealName.Width = 80;
            // 
            // colToDepartmentName
            // 
            this.colToDepartmentName.DataPropertyName = "ToDepartmentName";
            this.colToDepartmentName.FillWeight = 90F;
            this.colToDepartmentName.HeaderText = "送审部门";
            this.colToDepartmentName.MaxInputLength = 50;
            this.colToDepartmentName.Name = "colToDepartmentName";
            this.colToDepartmentName.ReadOnly = true;
            this.colToDepartmentName.Width = 90;
            // 
            // colToRoleRealName
            // 
            this.colToRoleRealName.DataPropertyName = "ToRoleRealName";
            this.colToRoleRealName.FillWeight = 90F;
            this.colToRoleRealName.HeaderText = "送审角色";
            this.colToRoleRealName.Name = "colToRoleRealName";
            this.colToRoleRealName.ReadOnly = true;
            this.colToRoleRealName.Width = 90;
            // 
            // colAuditUserRealName
            // 
            this.colAuditUserRealName.DataPropertyName = "AuditUserRealName";
            this.colAuditUserRealName.FillWeight = 80F;
            this.colAuditUserRealName.HeaderText = "审核者";
            this.colAuditUserRealName.MaxInputLength = 50;
            this.colAuditUserRealName.Name = "colAuditUserRealName";
            this.colAuditUserRealName.ReadOnly = true;
            this.colAuditUserRealName.Width = 80;
            // 
            // colAuditDate
            // 
            this.colAuditDate.DataPropertyName = "AuditDate";
            this.colAuditDate.FillWeight = 110F;
            this.colAuditDate.HeaderText = "审核日期";
            this.colAuditDate.Name = "colAuditDate";
            this.colAuditDate.ReadOnly = true;
            this.colAuditDate.Width = 110;
            // 
            // colAuditStatus
            // 
            this.colAuditStatus.DataPropertyName = "AuditStatus";
            this.colAuditStatus.FillWeight = 80F;
            this.colAuditStatus.HeaderText = "状态";
            this.colAuditStatus.MaxInputLength = 200;
            this.colAuditStatus.Name = "colAuditStatus";
            this.colAuditStatus.ReadOnly = true;
            this.colAuditStatus.Width = 80;
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
            // FrmWorkFlowAuditDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(869, 529);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.grdAuditDetail);
            this.Controls.Add(this.btnClose);
            this.Name = "FrmWorkFlowAuditDetail";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "审批流程明细";
            ((System.ComponentModel.ISupportInitialize)(this.grdAuditDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView grdAuditDetail;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSendDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToUserRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToDepartmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToRoleRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuditUserRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuditDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuditStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuditIder;
    }
}