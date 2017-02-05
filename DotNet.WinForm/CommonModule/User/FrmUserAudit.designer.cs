namespace DotNet.WinForm
{
    partial class FrmUserAudit
    {
        #region Windows 窗体设计器生成的主键

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用主键编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbUserAuditStates = new System.Windows.Forms.ComboBox();
            this.lblAudited = new System.Windows.Forms.Label();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnPass = new System.Windows.Forms.Button();
            this.btnInvertSelect = new System.Windows.Forms.Button();
            this.grdUser = new System.Windows.Forms.DataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDefaultRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAudited = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblRole = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(42, 19);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(71, 12);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "用户名(&U)：";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(133, 14);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(160, 21);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // cmbUserAuditStates
            // 
            this.cmbUserAuditStates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUserAuditStates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserAuditStates.FormattingEnabled = true;
            this.cmbUserAuditStates.Location = new System.Drawing.Point(601, 9);
            this.cmbUserAuditStates.Margin = new System.Windows.Forms.Padding(2);
            this.cmbUserAuditStates.Name = "cmbUserAuditStates";
            this.cmbUserAuditStates.Size = new System.Drawing.Size(160, 20);
            this.cmbUserAuditStates.TabIndex = 4;
            this.cmbUserAuditStates.SelectedIndexChanged += new System.EventHandler(this.cmbUserAuditStates_SelectedIndexChanged);
            // 
            // lblAudited
            // 
            this.lblAudited.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAudited.AutoSize = true;
            this.lblAudited.Location = new System.Drawing.Point(514, 12);
            this.lblAudited.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAudited.Name = "lblAudited";
            this.lblAudited.Size = new System.Drawing.Size(83, 12);
            this.lblAudited.TabIndex = 3;
            this.lblAudited.Text = "审核状态(&H)：";
            this.lblAudited.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Location = new System.Drawing.Point(6, 466);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(78, 23);
            this.btnSelectAll.TabIndex = 8;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(687, 468);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(608, 468);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReject
            // 
            this.btnReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReject.Location = new System.Drawing.Point(348, 468);
            this.btnReject.Margin = new System.Windows.Forms.Padding(2);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(75, 23);
            this.btnReject.TabIndex = 11;
            this.btnReject.Text = "退回(&R)";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnPass
            // 
            this.btnPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPass.Location = new System.Drawing.Point(269, 468);
            this.btnPass.Margin = new System.Windows.Forms.Padding(2);
            this.btnPass.Name = "btnPass";
            this.btnPass.Size = new System.Drawing.Size(75, 23);
            this.btnPass.TabIndex = 10;
            this.btnPass.Text = "通过(&P)";
            this.btnPass.UseVisualStyleBackColor = true;
            this.btnPass.Click += new System.EventHandler(this.btnPass_Click);
            // 
            // btnInvertSelect
            // 
            this.btnInvertSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvertSelect.Location = new System.Drawing.Point(88, 466);
            this.btnInvertSelect.Margin = new System.Windows.Forms.Padding(2);
            this.btnInvertSelect.Name = "btnInvertSelect";
            this.btnInvertSelect.Size = new System.Drawing.Size(78, 23);
            this.btnInvertSelect.TabIndex = 9;
            this.btnInvertSelect.Text = "反选";
            this.btnInvertSelect.UseVisualStyleBackColor = true;
            this.btnInvertSelect.Click += new System.EventHandler(this.btnInvertSelect_Click);
            // 
            // grdUser
            // 
            this.grdUser.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.grdUser.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdUser.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colUsername,
            this.colRealName,
            this.colDefaultRole,
            this.colAudited,
            this.colDepartment,
            this.colCreateOn,
            this.colDescription});
            this.grdUser.Location = new System.Drawing.Point(8, 56);
            this.grdUser.Margin = new System.Windows.Forms.Padding(2);
            this.grdUser.MultiSelect = false;
            this.grdUser.Name = "grdUser";
            this.grdUser.RowTemplate.Height = 23;
            this.grdUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdUser.Size = new System.Drawing.Size(754, 405);
            this.grdUser.TabIndex = 7;
            this.grdUser.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdUserManagement_CellDoubleClick);
            this.grdUser.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.grdUser_RowPrePaint);
            this.grdUser.SelectionChanged += new System.EventHandler(this.grdUser_SelectionChanged);
            this.grdUser.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grdUserManagement_UserDeletingRow);
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "Selected";
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSelected.Width = 50;
            // 
            // colUsername
            // 
            this.colUsername.DataPropertyName = "Username";
            this.colUsername.FillWeight = 90F;
            this.colUsername.Frozen = true;
            this.colUsername.HeaderText = "用户名";
            this.colUsername.Name = "colUsername";
            this.colUsername.ReadOnly = true;
            this.colUsername.Width = 90;
            // 
            // colRealName
            // 
            this.colRealName.DataPropertyName = "RealName";
            this.colRealName.FillWeight = 80F;
            this.colRealName.Frozen = true;
            this.colRealName.HeaderText = "姓名";
            this.colRealName.MaxInputLength = 20;
            this.colRealName.Name = "colRealName";
            this.colRealName.ReadOnly = true;
            this.colRealName.Width = 80;
            // 
            // colDefaultRole
            // 
            this.colDefaultRole.DataPropertyName = "RoleName";
            this.colDefaultRole.HeaderText = "默认角色";
            this.colDefaultRole.MaxInputLength = 200;
            this.colDefaultRole.Name = "colDefaultRole";
            this.colDefaultRole.ReadOnly = true;
            // 
            // colAudited
            // 
            this.colAudited.DataPropertyName = "AuditStates";
            this.colAudited.FillWeight = 80F;
            this.colAudited.HeaderText = "审核";
            this.colAudited.MaxInputLength = 200;
            this.colAudited.Name = "colAudited";
            this.colAudited.ReadOnly = true;
            this.colAudited.Width = 80;
            // 
            // colDepartment
            // 
            this.colDepartment.DataPropertyName = "DepartmentName";
            this.colDepartment.FillWeight = 150F;
            this.colDepartment.HeaderText = "部门";
            this.colDepartment.MaxInputLength = 200;
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.ReadOnly = true;
            this.colDepartment.Width = 150;
            // 
            // colCreateOn
            // 
            this.colCreateOn.DataPropertyName = "CreateOn";
            this.colCreateOn.FillWeight = 80F;
            this.colCreateOn.HeaderText = "创建日期";
            this.colCreateOn.Name = "colCreateOn";
            this.colCreateOn.ReadOnly = true;
            this.colCreateOn.Width = 80;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.FillWeight = 200F;
            this.colDescription.HeaderText = "描述";
            this.colDescription.MaxInputLength = 200;
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 200;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(298, 13);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询(&S)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblRole
            // 
            this.lblRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(514, 36);
            this.lblRole.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(83, 12);
            this.lblRole.TabIndex = 5;
            this.lblRole.Text = "默认角色(&T)：";
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbRole
            // 
            this.cmbRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new System.Drawing.Point(601, 32);
            this.cmbRole.Margin = new System.Windows.Forms.Padding(2);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(160, 20);
            this.cmbRole.TabIndex = 6;
            this.cmbRole.SelectedIndexChanged += new System.EventHandler(this.cmbRole_SelectedIndexChanged);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(427, 468);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "编辑(&E)...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(506, 468);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(98, 23);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "导出E&xcel...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // FrmUserAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(770, 495);
            this.Controls.Add(this.grdUser);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnInvertSelect);
            this.Controls.Add(this.btnPass);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.lblAudited);
            this.Controls.Add(this.cmbUserAuditStates);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblRole);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmUserAudit";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Text = "用户审核";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmUserAudit_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbUserAuditStates;
        private System.Windows.Forms.Label lblAudited;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnPass;
        private System.Windows.Forms.Button btnInvertSelect;
        private System.Windows.Forms.DataGridView grdUser;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDefaultRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAudited;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
    }
}