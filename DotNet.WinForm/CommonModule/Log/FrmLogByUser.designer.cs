namespace DotNet.WinForm
{
    partial class FrmLogByUser
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblUserReq = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBatchDelete = new System.Windows.Forms.Button();
            this.btnInvertSelect = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.grdLog = new System.Windows.Forms.DataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMethodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnQuery = new System.Windows.Forms.Button();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblUser = new System.Windows.Forms.Label();
            this.ucUser = new DotNet.WinForm.UCUserSelect();
            ((System.ComponentModel.ISupportInitialize)(this.grdLog)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(761, 505);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 23);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(443, 505);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(111, 23);
            this.btnExport.TabIndex = 11;
            this.btnExport.Text = "导出Excel...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblUserReq
            // 
            this.lblUserReq.AutoSize = true;
            this.lblUserReq.ForeColor = System.Drawing.Color.Red;
            this.lblUserReq.Location = new System.Drawing.Point(376, 14);
            this.lblUserReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserReq.Name = "lblUserReq";
            this.lblUserReq.Size = new System.Drawing.Size(11, 12);
            this.lblUserReq.TabIndex = 2;
            this.lblUserReq.Text = "*";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(644, 505);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(111, 23);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "全部清除(&L)";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // btnBatchDelete
            // 
            this.btnBatchDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchDelete.Location = new System.Drawing.Point(560, 505);
            this.btnBatchDelete.Name = "btnBatchDelete";
            this.btnBatchDelete.Size = new System.Drawing.Size(78, 23);
            this.btnBatchDelete.TabIndex = 12;
            this.btnBatchDelete.Text = "删除(&D)";
            this.btnBatchDelete.UseVisualStyleBackColor = true;
            this.btnBatchDelete.Click += new System.EventHandler(this.btnBatchDelete_Click);
            // 
            // btnInvertSelect
            // 
            this.btnInvertSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvertSelect.Location = new System.Drawing.Point(90, 505);
            this.btnInvertSelect.Name = "btnInvertSelect";
            this.btnInvertSelect.Size = new System.Drawing.Size(78, 23);
            this.btnInvertSelect.TabIndex = 10;
            this.btnInvertSelect.Text = "反选";
            this.btnInvertSelect.UseVisualStyleBackColor = true;
            this.btnInvertSelect.Click += new System.EventHandler(this.btnInvertSelect_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Location = new System.Drawing.Point(6, 505);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(78, 23);
            this.btnSelectAll.TabIndex = 9;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // grdLog
            // 
            this.grdLog.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.grdLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdLog.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colProcessName,
            this.colUserRealName,
            this.colCreateOn,
            this.colIPAddress,
            this.colMethodName,
            this.colDescription});
            this.grdLog.Location = new System.Drawing.Point(8, 66);
            this.grdLog.MultiSelect = false;
            this.grdLog.Name = "grdLog";
            this.grdLog.RowTemplate.Height = 23;
            this.grdLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdLog.Size = new System.Drawing.Size(827, 433);
            this.grdLog.TabIndex = 8;
            this.grdLog.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grdLogGeneral_UserDeletingRow);
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "Selected";
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Width = 50;
            // 
            // colProcessName
            // 
            this.colProcessName.DataPropertyName = "ProcessName";
            this.colProcessName.Frozen = true;
            this.colProcessName.HeaderText = "模块";
            this.colProcessName.MaxInputLength = 20;
            this.colProcessName.Name = "colProcessName";
            this.colProcessName.ReadOnly = true;
            this.colProcessName.Width = 150;
            // 
            // colUserRealName
            // 
            this.colUserRealName.DataPropertyName = "UserRealName";
            this.colUserRealName.HeaderText = "姓名";
            this.colUserRealName.Name = "colUserRealName";
            this.colUserRealName.ReadOnly = true;
            this.colUserRealName.Width = 90;
            // 
            // colCreateOn
            // 
            this.colCreateOn.DataPropertyName = "CreateOn";
            dataGridViewCellStyle3.Format = "yyyy-MM-dd HH:mm:ss";
            this.colCreateOn.DefaultCellStyle = dataGridViewCellStyle3;
            this.colCreateOn.HeaderText = "访问时间";
            this.colCreateOn.Name = "colCreateOn";
            this.colCreateOn.ReadOnly = true;
            this.colCreateOn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCreateOn.Width = 120;
            // 
            // colIPAddress
            // 
            this.colIPAddress.DataPropertyName = "IPAddress";
            this.colIPAddress.HeaderText = "IP地址";
            this.colIPAddress.Name = "colIPAddress";
            this.colIPAddress.ReadOnly = true;
            this.colIPAddress.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colMethodName
            // 
            this.colMethodName.DataPropertyName = "MethodName";
            this.colMethodName.HeaderText = "操作";
            this.colMethodName.MaxInputLength = 150;
            this.colMethodName.Name = "colMethodName";
            this.colMethodName.ReadOnly = true;
            this.colMethodName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMethodName.Width = 150;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "描述";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(695, 37);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(100, 23);
            this.btnQuery.TabIndex = 7;
            this.btnQuery.Text = "查询(&Q)";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblEndDate
            // 
            this.lblEndDate.Location = new System.Drawing.Point(371, 42);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(102, 12);
            this.lblEndDate.TabIndex = 5;
            this.lblEndDate.Text = "结束日期：";
            this.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStartDate
            // 
            this.lblStartDate.Location = new System.Drawing.Point(8, 41);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(98, 12);
            this.lblStartDate.TabIndex = 3;
            this.lblStartDate.Text = "开始日期：";
            this.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(480, 38);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(180, 21);
            this.dtpEndDate.TabIndex = 6;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(110, 38);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(180, 21);
            this.dtpStartDate.TabIndex = 4;
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(8, 13);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(98, 12);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "用户：";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucUser
            // 
            this.ucUser.AllowNull = true;
            this.ucUser.AllowSelect = true;
            this.ucUser.Location = new System.Drawing.Point(110, 10);
            this.ucUser.MultiSelect = false;
            this.ucUser.Name = "ucUser";
            this.ucUser.OpenId = "";
            this.ucUser.PermissionItemScopeCode = "";
            this.ucUser.RemoveIds = null;
            this.ucUser.SelectedFullName = "";
            this.ucUser.SelectedId = "";
            this.ucUser.SelectedIds = null;
            this.ucUser.SetSelectIds = null;
            this.ucUser.Size = new System.Drawing.Size(257, 22);
            this.ucUser.TabIndex = 1;
            this.ucUser.SelectedIndexChanged += new DotNet.Utilities.BaseBusinessLogic.SelectedIndexChangedEventHandler(this.ucUser_SelectedIndexChanged);
            // 
            // FrmLogByUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(844, 532);
            this.Controls.Add(this.ucUser);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblUserReq);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnBatchDelete);
            this.Controls.Add(this.btnInvertSelect);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.grdLog);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblUser);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmLogByUser";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "按查询用户";
            ((System.ComponentModel.ISupportInitialize)(this.grdLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridView grdLog;
        private System.Windows.Forms.Button btnInvertSelect;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnBatchDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblUserReq;
        private System.Windows.Forms.Button btnExport;
        private DotNet.WinForm.UCUserSelect ucUser;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMethodName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
    }
}