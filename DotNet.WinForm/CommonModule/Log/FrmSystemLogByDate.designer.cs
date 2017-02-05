namespace DotNet.WinForm
{
    partial class FrmSystemLogByDate
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
            this.btnQuery = new System.Windows.Forms.Button();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
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
            this.btnExport = new System.Windows.Forms.Button();
            this.ucUserSelect = new DotNet.WinForm.UCUserSelect();
            this.lblUser = new System.Windows.Forms.Label();
            this.ucModuleSelect = new DotNet.WinForm.UCModuleSelect();
            this.lblModule = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdLog)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(696, 7);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(100, 23);
            this.btnQuery.TabIndex = 4;
            this.btnQuery.Text = "查询(&Q)";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblEndDate
            // 
            this.lblEndDate.Location = new System.Drawing.Point(361, 12);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(91, 12);
            this.lblEndDate.TabIndex = 2;
            this.lblEndDate.Text = "结束日期：";
            this.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStartDate
            // 
            this.lblStartDate.Location = new System.Drawing.Point(7, 12);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(91, 12);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "开始日期：";
            this.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "yyyy-MM-dd";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(458, 8);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(180, 21);
            this.dtpEndDate.TabIndex = 3;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "yyyy-MM-dd";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(103, 9);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(180, 21);
            this.dtpStartDate.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(749, 505);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(631, 505);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(111, 23);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "全部清除(&C)";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // btnBatchDelete
            // 
            this.btnBatchDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchDelete.Location = new System.Drawing.Point(546, 505);
            this.btnBatchDelete.Name = "btnBatchDelete";
            this.btnBatchDelete.Size = new System.Drawing.Size(78, 23);
            this.btnBatchDelete.TabIndex = 9;
            this.btnBatchDelete.Text = "删除(&D)";
            this.btnBatchDelete.UseVisualStyleBackColor = true;
            this.btnBatchDelete.Click += new System.EventHandler(this.btnBatchDelete_Click);
            // 
            // btnInvertSelect
            // 
            this.btnInvertSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvertSelect.Location = new System.Drawing.Point(91, 505);
            this.btnInvertSelect.Name = "btnInvertSelect";
            this.btnInvertSelect.Size = new System.Drawing.Size(78, 23);
            this.btnInvertSelect.TabIndex = 7;
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
            this.btnSelectAll.TabIndex = 6;
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
            this.grdLog.Size = new System.Drawing.Size(816, 429);
            this.grdLog.TabIndex = 5;
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
            this.colUserRealName.Width = 80;
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
            this.colMethodName.Width = 180;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "描述";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(427, 505);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(111, 23);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "导出E&xcel...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // ucUserSelect
            // 
            this.ucUserSelect.AllowNull = true;
            this.ucUserSelect.AllowSelect = true;
            this.ucUserSelect.Location = new System.Drawing.Point(103, 38);
            this.ucUserSelect.MultiSelect = false;
            this.ucUserSelect.Name = "ucUserSelect";
            this.ucUserSelect.OpenId = "";
            this.ucUserSelect.PermissionItemScopeCode = "";
            this.ucUserSelect.RemoveIds = null;
            this.ucUserSelect.SelectedFullName = "";
            this.ucUserSelect.SelectedId = "";
            this.ucUserSelect.SelectedIds = null;
            this.ucUserSelect.SetSelectIds = null;
            this.ucUserSelect.Size = new System.Drawing.Size(257, 22);
            this.ucUserSelect.TabIndex = 13;
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(14, 41);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(84, 12);
            this.lblUser.TabIndex = 12;
            this.lblUser.Text = "用户：";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucModuleSelect
            // 
            this.ucModuleSelect.AllowNull = true;
            this.ucModuleSelect.AllowSelect = true;
            this.ucModuleSelect.CheckMove = false;
            this.ucModuleSelect.Location = new System.Drawing.Point(458, 38);
            this.ucModuleSelect.MultiSelect = false;
            this.ucModuleSelect.Name = "ucModuleSelect";
            this.ucModuleSelect.OpenId = "";
            this.ucModuleSelect.SelectedCode = "";
            this.ucModuleSelect.SelectedFullName = "";
            this.ucModuleSelect.SelectedId = "";
            this.ucModuleSelect.Size = new System.Drawing.Size(254, 22);
            this.ucModuleSelect.TabIndex = 15;
            // 
            // lblModule
            // 
            this.lblModule.Location = new System.Drawing.Point(377, 42);
            this.lblModule.Name = "lblModule";
            this.lblModule.Size = new System.Drawing.Size(75, 12);
            this.lblModule.TabIndex = 14;
            this.lblModule.Text = "菜单：";
            this.lblModule.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmSystemLogByDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(834, 532);
            this.Controls.Add(this.ucModuleSelect);
            this.Controls.Add(this.lblModule);
            this.Controls.Add(this.ucUserSelect);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.grdLog);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnBatchDelete);
            this.Controls.Add(this.btnInvertSelect);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmSystemLogByDate";
            this.Text = "按日期查询";
            ((System.ComponentModel.ISupportInitialize)(this.grdLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBatchDelete;
        private System.Windows.Forms.Button btnInvertSelect;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.DataGridView grdLog;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMethodName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private DotNet.WinForm.UCUserSelect ucUserSelect;
        private System.Windows.Forms.Label lblUser;
        private DotNet.WinForm.UCModuleSelect ucModuleSelect;
        private System.Windows.Forms.Label lblModule;
    }
}