namespace DotNet.WinForm
{
    partial class FrmLogGeneral
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkOnlyOnLine = new System.Windows.Forms.CheckBox();
            this.lblContents = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnVisitDetail = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnInvertSelect = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.grdLog = new System.Windows.Forms.DataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsStaff = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsVisible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colFirstVisit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastVisit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLatestVisit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLogCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserOnLine = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMACAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdLog)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(905, 523);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(312, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "查询(&F)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chkOnlyOnLine
            // 
            this.chkOnlyOnLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkOnlyOnLine.AutoSize = true;
            this.chkOnlyOnLine.Location = new System.Drawing.Point(716, 11);
            this.chkOnlyOnLine.Name = "chkOnlyOnLine";
            this.chkOnlyOnLine.Size = new System.Drawing.Size(108, 16);
            this.chkOnlyOnLine.TabIndex = 2;
            this.chkOnlyOnLine.Text = "只显示在线用户";
            this.chkOnlyOnLine.UseVisualStyleBackColor = true;
            this.chkOnlyOnLine.CheckedChanged += new System.EventHandler(this.chkOnlyOnLine_CheckedChanged);
            // 
            // lblContents
            // 
            this.lblContents.Location = new System.Drawing.Point(37, 12);
            this.lblContents.Name = "lblContents";
            this.lblContents.Size = new System.Drawing.Size(82, 12);
            this.lblContents.TabIndex = 0;
            this.lblContents.Text = "查询内容(&C)：";
            this.lblContents.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(125, 8);
            this.txtSearch.MaxLength = 20;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(172, 21);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(870, 7);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(111, 23);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "导出Excel...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnVisitDetail
            // 
            this.btnVisitDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVisitDetail.Location = new System.Drawing.Point(703, 523);
            this.btnVisitDetail.Name = "btnVisitDetail";
            this.btnVisitDetail.Size = new System.Drawing.Size(112, 23);
            this.btnVisitDetail.TabIndex = 6;
            this.btnVisitDetail.Text = "访问详情(&V)...";
            this.btnVisitDetail.UseVisualStyleBackColor = true;
            this.btnVisitDetail.Click += new System.EventHandler(this.btnVisitDetail_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(821, 523);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(78, 23);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "重置(&R)";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnInvertSelect
            // 
            this.btnInvertSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvertSelect.Location = new System.Drawing.Point(90, 523);
            this.btnInvertSelect.Name = "btnInvertSelect";
            this.btnInvertSelect.Size = new System.Drawing.Size(78, 23);
            this.btnInvertSelect.TabIndex = 5;
            this.btnInvertSelect.Text = "反选";
            this.btnInvertSelect.UseVisualStyleBackColor = true;
            this.btnInvertSelect.Click += new System.EventHandler(this.btnInvertSelect_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Location = new System.Drawing.Point(6, 523);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(78, 23);
            this.btnSelectAll.TabIndex = 4;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // grdLog
            // 
            this.grdLog.AllowUserToAddRows = false;
            this.grdLog.AllowUserToDeleteRows = false;
            this.grdLog.AllowUserToOrderColumns = true;
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
            this.colUserName,
            this.colUserRealName,
            this.colIsStaff,
            this.colIsVisible,
            this.colEnabled,
            this.colFirstVisit,
            this.colLastVisit,
            this.colLatestVisit,
            this.colLogCount,
            this.colUserOnLine,
            this.colIPAddress,
            this.colMACAddress});
            this.grdLog.Location = new System.Drawing.Point(8, 36);
            this.grdLog.MultiSelect = false;
            this.grdLog.Name = "grdLog";
            this.grdLog.RowTemplate.Height = 23;
            this.grdLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdLog.Size = new System.Drawing.Size(973, 482);
            this.grdLog.TabIndex = 3;
            this.grdLog.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLog_CellDoubleClick);
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "Selected";
            this.colSelected.FillWeight = 80F;
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Width = 50;
            // 
            // colUserName
            // 
            this.colUserName.DataPropertyName = "UserName";
            this.colUserName.Frozen = true;
            this.colUserName.HeaderText = "用户名";
            this.colUserName.Name = "colUserName";
            this.colUserName.ReadOnly = true;
            // 
            // colUserRealName
            // 
            this.colUserRealName.DataPropertyName = "RealName";
            this.colUserRealName.Frozen = true;
            this.colUserRealName.HeaderText = "姓名";
            this.colUserRealName.MaxInputLength = 200;
            this.colUserRealName.Name = "colUserRealName";
            this.colUserRealName.ReadOnly = true;
            this.colUserRealName.Width = 60;
            // 
            // colIsStaff
            // 
            this.colIsStaff.DataPropertyName = "IsStaff";
            this.colIsStaff.FalseValue = "0";
            this.colIsStaff.FillWeight = 60F;
            this.colIsStaff.HeaderText = "员工";
            this.colIsStaff.Name = "colIsStaff";
            this.colIsStaff.ReadOnly = true;
            this.colIsStaff.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsStaff.TrueValue = "1";
            this.colIsStaff.Width = 40;
            // 
            // colIsVisible
            // 
            this.colIsVisible.DataPropertyName = "IsVisible";
            this.colIsVisible.FalseValue = "0";
            this.colIsVisible.FillWeight = 60F;
            this.colIsVisible.HeaderText = "显示";
            this.colIsVisible.Name = "colIsVisible";
            this.colIsVisible.ReadOnly = true;
            this.colIsVisible.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsVisible.TrueValue = "1";
            this.colIsVisible.Width = 40;
            // 
            // colEnabled
            // 
            this.colEnabled.DataPropertyName = "Enabled";
            this.colEnabled.FalseValue = "0";
            this.colEnabled.FillWeight = 60F;
            this.colEnabled.HeaderText = "有效";
            this.colEnabled.Name = "colEnabled";
            this.colEnabled.ReadOnly = true;
            this.colEnabled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEnabled.TrueValue = "1";
            this.colEnabled.Width = 40;
            // 
            // colFirstVisit
            // 
            this.colFirstVisit.DataPropertyName = "FirstVisit";
            dataGridViewCellStyle3.Format = "yyyy-MM-dd HH:mm:ss";
            dataGridViewCellStyle3.NullValue = null;
            this.colFirstVisit.DefaultCellStyle = dataGridViewCellStyle3;
            this.colFirstVisit.HeaderText = "首次访问";
            this.colFirstVisit.MaxInputLength = 20;
            this.colFirstVisit.Name = "colFirstVisit";
            this.colFirstVisit.Width = 120;
            // 
            // colLastVisit
            // 
            this.colLastVisit.DataPropertyName = "PreviousVisit";
            dataGridViewCellStyle4.Format = "yyyy-MM-dd HH:mm:ss";
            this.colLastVisit.DefaultCellStyle = dataGridViewCellStyle4;
            this.colLastVisit.HeaderText = "上次访问";
            this.colLastVisit.MaxInputLength = 20;
            this.colLastVisit.Name = "colLastVisit";
            this.colLastVisit.Width = 120;
            // 
            // colLatestVisit
            // 
            this.colLatestVisit.DataPropertyName = "LastVisit";
            dataGridViewCellStyle5.Format = "yyyy-MM-dd HH:mm:ss";
            this.colLatestVisit.DefaultCellStyle = dataGridViewCellStyle5;
            this.colLatestVisit.HeaderText = "最后访问";
            this.colLatestVisit.MaxInputLength = 20;
            this.colLatestVisit.Name = "colLatestVisit";
            this.colLatestVisit.Width = 120;
            // 
            // colLogCount
            // 
            this.colLogCount.DataPropertyName = "LogOnCount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.colLogCount.DefaultCellStyle = dataGridViewCellStyle6;
            this.colLogCount.HeaderText = "登录次数";
            this.colLogCount.MaxInputLength = 20;
            this.colLogCount.Name = "colLogCount";
            this.colLogCount.Width = 80;
            // 
            // colUserOnLine
            // 
            this.colUserOnLine.DataPropertyName = "UserOnLine";
            this.colUserOnLine.FalseValue = "0";
            this.colUserOnLine.FillWeight = 60F;
            this.colUserOnLine.HeaderText = "在线";
            this.colUserOnLine.Name = "colUserOnLine";
            this.colUserOnLine.ReadOnly = true;
            this.colUserOnLine.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colUserOnLine.TrueValue = "1";
            this.colUserOnLine.Width = 40;
            // 
            // colIPAddress
            // 
            this.colIPAddress.DataPropertyName = "IPAddress";
            this.colIPAddress.HeaderText = "IP地址";
            this.colIPAddress.MaxInputLength = 50;
            this.colIPAddress.Name = "colIPAddress";
            // 
            // colMACAddress
            // 
            this.colMACAddress.DataPropertyName = "MACAddress";
            this.colMACAddress.FillWeight = 120F;
            this.colMACAddress.HeaderText = "MAC地址";
            this.colMACAddress.MaxInputLength = 50;
            this.colMACAddress.Name = "colMACAddress";
            this.colMACAddress.Width = 120;
            // 
            // FrmLogGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(988, 550);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.chkOnlyOnLine);
            this.Controls.Add(this.lblContents);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnVisitDetail);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnInvertSelect);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.grdLog);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmLogGeneral";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "按用户访问情况";
            ((System.ComponentModel.ISupportInitialize)(this.grdLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdLog;
        private System.Windows.Forms.Button btnInvertSelect;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnVisitDetail;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblContents;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.CheckBox chkOnlyOnLine;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserRealName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsStaff;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsVisible;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstVisit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastVisit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLatestVisit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogCount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUserOnLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMACAddress;

    }
}