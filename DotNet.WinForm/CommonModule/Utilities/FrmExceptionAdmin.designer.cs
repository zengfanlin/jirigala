namespace DotNet.WinForm
{
    partial class FrmExceptionAdmin
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

        #region Windows 窗体设计器生成的主键

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用主键编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdExceptionAdmin = new System.Windows.Forms.DataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCreateOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThreadName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFormattedMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBatchDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnInvertSelect = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnClearException = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdExceptionAdmin)).BeginInit();
            this.SuspendLayout();
            // 
            // grdExceptionAdmin
            // 
            this.grdExceptionAdmin.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.grdExceptionAdmin.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdExceptionAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdExceptionAdmin.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdExceptionAdmin.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdExceptionAdmin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdExceptionAdmin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colCreateOn,
            this.colMessage,
            this.colThreadName,
            this.colFormattedMessage,
            this.colCreateBy});
            this.grdExceptionAdmin.Location = new System.Drawing.Point(7, 42);
            this.grdExceptionAdmin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grdExceptionAdmin.MultiSelect = false;
            this.grdExceptionAdmin.Name = "grdExceptionAdmin";
            this.grdExceptionAdmin.RowTemplate.Height = 23;
            this.grdExceptionAdmin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdExceptionAdmin.Size = new System.Drawing.Size(850, 456);
            this.grdExceptionAdmin.TabIndex = 0;
            this.grdExceptionAdmin.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdExceptionAdmin_CellDoubleClick);
            this.grdExceptionAdmin.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grdExceptionAdmin_UserDeletingRow);
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "Selected";
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colSelected.Width = 50;
            // 
            // colCreateOn
            // 
            this.colCreateOn.DataPropertyName = "CreateOn";
            this.colCreateOn.HeaderText = "发生时间";
            this.colCreateOn.MaxInputLength = 20;
            this.colCreateOn.Name = "colCreateOn";
            this.colCreateOn.ReadOnly = true;
            this.colCreateOn.Width = 120;
            // 
            // colMessage
            // 
            this.colMessage.DataPropertyName = "Message";
            this.colMessage.HeaderText = "异常信息";
            this.colMessage.MaxInputLength = 800;
            this.colMessage.Name = "colMessage";
            this.colMessage.ReadOnly = true;
            this.colMessage.Width = 400;
            // 
            // colThreadName
            // 
            this.colThreadName.DataPropertyName = "ThreadName";
            this.colThreadName.HeaderText = "异常信息来源";
            this.colThreadName.MaxInputLength = 200;
            this.colThreadName.Name = "colThreadName";
            this.colThreadName.ReadOnly = true;
            // 
            // colFormattedMessage
            // 
            this.colFormattedMessage.DataPropertyName = "FormattedMessage";
            this.colFormattedMessage.HeaderText = "异常信息描述";
            this.colFormattedMessage.MaxInputLength = 800;
            this.colFormattedMessage.Name = "colFormattedMessage";
            this.colFormattedMessage.ReadOnly = true;
            this.colFormattedMessage.Width = 200;
            // 
            // colCreateBy
            // 
            this.colCreateBy.DataPropertyName = "CreateBy";
            this.colCreateBy.HeaderText = "创建者";
            this.colCreateBy.MaxInputLength = 20;
            this.colCreateBy.Name = "colCreateBy";
            this.colCreateBy.ReadOnly = true;
            this.colCreateBy.Width = 120;
            // 
            // btnBatchDelete
            // 
            this.btnBatchDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchDelete.Location = new System.Drawing.Point(597, 504);
            this.btnBatchDelete.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnBatchDelete.Name = "btnBatchDelete";
            this.btnBatchDelete.Size = new System.Drawing.Size(74, 23);
            this.btnBatchDelete.TabIndex = 4;
            this.btnBatchDelete.Text = "删除(&D)";
            this.btnBatchDelete.UseVisualStyleBackColor = true;
            this.btnBatchDelete.Click += new System.EventHandler(this.btnBatchDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(783, 504);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnInvertSelect
            // 
            this.btnInvertSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvertSelect.Location = new System.Drawing.Point(92, 504);
            this.btnInvertSelect.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnInvertSelect.Name = "btnInvertSelect";
            this.btnInvertSelect.Size = new System.Drawing.Size(78, 23);
            this.btnInvertSelect.TabIndex = 2;
            this.btnInvertSelect.Text = "反选";
            this.btnInvertSelect.UseVisualStyleBackColor = true;
            this.btnInvertSelect.Click += new System.EventHandler(this.btnInvertSelect_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Location = new System.Drawing.Point(6, 504);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(78, 23);
            this.btnSelectAll.TabIndex = 1;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnClearException
            // 
            this.btnClearException.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearException.Location = new System.Drawing.Point(679, 504);
            this.btnClearException.Name = "btnClearException";
            this.btnClearException.Size = new System.Drawing.Size(97, 23);
            this.btnClearException.TabIndex = 5;
            this.btnClearException.Text = "全部清除(&C)";
            this.btnClearException.UseVisualStyleBackColor = true;
            this.btnClearException.Click += new System.EventHandler(this.btnClearException_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(745, 11);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(111, 23);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "导出Excel...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // FrmExceptionAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(866, 531);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnClearException);
            this.Controls.Add(this.btnInvertSelect);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBatchDelete);
            this.Controls.Add(this.grdExceptionAdmin);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "FrmExceptionAdmin";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "系统异常情况记录";
            ((System.ComponentModel.ISupportInitialize)(this.grdExceptionAdmin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdExceptionAdmin;
        private System.Windows.Forms.Button btnBatchDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnInvertSelect;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnClearException;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThreadName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFormattedMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateBy;
    }
}