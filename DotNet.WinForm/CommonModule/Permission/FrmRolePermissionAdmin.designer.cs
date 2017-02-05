namespace DotNet.WinForm
{
    partial class FrmRolePermissionAdmin
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
            this.btnBatchDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnBatchSave = new System.Windows.Forms.Button();
            this.btnRoleUser = new System.Windows.Forms.Button();
            this.btnRolePermission = new System.Windows.Forms.Button();
            this.ucTableSort = new DotNet.WinForm.UCTableSort();
            this.grdRole = new System.Windows.Forms.DataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblContents = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblRoleCategories = new System.Windows.Forms.Label();
            this.cmbRoleCategory = new System.Windows.Forms.ComboBox();
            this.btnFrmRoleTableScope = new System.Windows.Forms.Button();
            this.btnBatchPermission = new System.Windows.Forms.Button();
            this.btnRoleUserBatchSet = new System.Windows.Forms.Button();
            this.btnFrmRoleAuthorizationScope = new System.Windows.Forms.Button();
            this.btnFrmRoleAdminScope = new System.Windows.Forms.Button();
            this.btnFrmTableColumnPermission = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.grdRole)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBatchDelete
            // 
            this.btnBatchDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchDelete.Enabled = false;
            this.btnBatchDelete.Location = new System.Drawing.Point(682, 483);
            this.btnBatchDelete.Name = "btnBatchDelete";
            this.btnBatchDelete.Size = new System.Drawing.Size(75, 23);
            this.btnBatchDelete.TabIndex = 16;
            this.btnBatchDelete.Text = "删除(&D)";
            this.btnBatchDelete.UseVisualStyleBackColor = true;
            this.btnBatchDelete.Click += new System.EventHandler(this.btnBatchDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(327, 483);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(80, 23);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "编辑(&E)...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(834, 483);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(246, 483);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 23);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "添加(&A)...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnBatchSave
            // 
            this.btnBatchSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchSave.Enabled = false;
            this.btnBatchSave.Location = new System.Drawing.Point(758, 483);
            this.btnBatchSave.Name = "btnBatchSave";
            this.btnBatchSave.Size = new System.Drawing.Size(75, 23);
            this.btnBatchSave.TabIndex = 17;
            this.btnBatchSave.Text = "保存(&S)";
            this.btnBatchSave.UseVisualStyleBackColor = true;
            this.btnBatchSave.Click += new System.EventHandler(this.btnBatchSave_Click);
            // 
            // btnRoleUser
            // 
            this.btnRoleUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRoleUser.Enabled = false;
            this.btnRoleUser.Location = new System.Drawing.Point(408, 483);
            this.btnRoleUser.Name = "btnRoleUser";
            this.btnRoleUser.Size = new System.Drawing.Size(80, 23);
            this.btnRoleUser.TabIndex = 13;
            this.btnRoleUser.Text = "用户(&U)...";
            this.btnRoleUser.UseVisualStyleBackColor = true;
            this.btnRoleUser.Click += new System.EventHandler(this.btnRoleUser_Click);
            // 
            // btnRolePermission
            // 
            this.btnRolePermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRolePermission.Enabled = false;
            this.btnRolePermission.Location = new System.Drawing.Point(489, 483);
            this.btnRolePermission.Name = "btnRolePermission";
            this.btnRolePermission.Size = new System.Drawing.Size(80, 23);
            this.btnRolePermission.TabIndex = 14;
            this.btnRolePermission.Text = "权限(&P)...";
            this.btnRolePermission.UseVisualStyleBackColor = true;
            this.btnRolePermission.Click += new System.EventHandler(this.btnPermission_Click);
            // 
            // ucTableSort
            // 
            this.ucTableSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ucTableSort.Location = new System.Drawing.Point(7, 481);
            this.ucTableSort.Margin = new System.Windows.Forms.Padding(0);
            this.ucTableSort.Name = "ucTableSort";
            this.ucTableSort.OEntityId = null;
            this.ucTableSort.Padding = new System.Windows.Forms.Padding(1);
            this.ucTableSort.SetBottomEnabled = false;
            this.ucTableSort.SetDownEnabled = false;
            this.ucTableSort.SetTopEnabled = false;
            this.ucTableSort.SetUpEnabled = false;
            this.ucTableSort.Size = new System.Drawing.Size(99, 24);
            this.ucTableSort.TabIndex = 10;
            // 
            // grdRole
            // 
            this.grdRole.AllowUserToAddRows = false;
            this.grdRole.AllowUserToDeleteRows = false;
            this.grdRole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdRole.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdRole.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdRole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRole.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colCode,
            this.colRealName,
            this.colEnabled,
            this.colDescription});
            this.grdRole.Location = new System.Drawing.Point(7, 65);
            this.grdRole.MultiSelect = false;
            this.grdRole.Name = "grdRole";
            this.grdRole.RowTemplate.Height = 23;
            this.grdRole.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdRole.Size = new System.Drawing.Size(900, 411);
            this.grdRole.TabIndex = 9;
            this.grdRole.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdRole_CellDoubleClick);
            this.grdRole.SelectionChanged += new System.EventHandler(this.grdRole_SelectionChanged);
            this.grdRole.Sorted += new System.EventHandler(this.grdRole_Sorted);
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
            this.colCode.MaxInputLength = 200;
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            this.colCode.Width = 180;
            // 
            // colRealName
            // 
            this.colRealName.DataPropertyName = "RealName";
            this.colRealName.HeaderText = "名称";
            this.colRealName.MaxInputLength = 200;
            this.colRealName.Name = "colRealName";
            this.colRealName.ReadOnly = true;
            this.colRealName.Width = 220;
            // 
            // colEnabled
            // 
            this.colEnabled.DataPropertyName = "Enabled";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.NullValue = false;
            this.colEnabled.DefaultCellStyle = dataGridViewCellStyle2;
            this.colEnabled.FalseValue = "0";
            this.colEnabled.HeaderText = "有效";
            this.colEnabled.Name = "colEnabled";
            this.colEnabled.TrueValue = "1";
            this.colEnabled.Width = 80;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colDescription.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDescription.HeaderText = "描述";
            this.colDescription.MaxInputLength = 200;
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 300;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(570, 483);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(111, 23);
            this.btnExport.TabIndex = 15;
            this.btnExport.Text = "导出Excel...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblContents
            // 
            this.lblContents.Location = new System.Drawing.Point(30, 40);
            this.lblContents.Name = "lblContents";
            this.lblContents.Size = new System.Drawing.Size(89, 12);
            this.lblContents.TabIndex = 5;
            this.lblContents.Text = "查询内容(&C)：";
            this.lblContents.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(124, 36);
            this.txtSearch.MaxLength = 20;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(157, 21);
            this.txtSearch.TabIndex = 6;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblRoleCategories
            // 
            this.lblRoleCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRoleCategories.Location = new System.Drawing.Point(672, 43);
            this.lblRoleCategories.Name = "lblRoleCategories";
            this.lblRoleCategories.Size = new System.Drawing.Size(110, 12);
            this.lblRoleCategories.TabIndex = 7;
            this.lblRoleCategories.Text = "角色分类：";
            this.lblRoleCategories.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbRoleCategory
            // 
            this.cmbRoleCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRoleCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoleCategory.Location = new System.Drawing.Point(788, 39);
            this.cmbRoleCategory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbRoleCategory.Name = "cmbRoleCategory";
            this.cmbRoleCategory.Size = new System.Drawing.Size(118, 20);
            this.cmbRoleCategory.TabIndex = 8;
            this.cmbRoleCategory.SelectedIndexChanged += new System.EventHandler(this.cmbRoleCategory_SelectedIndexChanged);
            // 
            // btnFrmRoleTableScope
            // 
            this.btnFrmRoleTableScope.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFrmRoleTableScope.Enabled = false;
            this.btnFrmRoleTableScope.Location = new System.Drawing.Point(569, 3);
            this.btnFrmRoleTableScope.Name = "btnFrmRoleTableScope";
            this.btnFrmRoleTableScope.Size = new System.Drawing.Size(135, 23);
            this.btnFrmRoleTableScope.TabIndex = 2;
            this.btnFrmRoleTableScope.Text = "约束条件...";
            this.btnFrmRoleTableScope.UseVisualStyleBackColor = true;
            this.btnFrmRoleTableScope.Click += new System.EventHandler(this.btnFrmRoleOrganizeScope_Click);
            // 
            // btnBatchPermission
            // 
            this.btnBatchPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchPermission.Enabled = false;
            this.btnBatchPermission.Location = new System.Drawing.Point(146, 3);
            this.btnBatchPermission.Name = "btnBatchPermission";
            this.btnBatchPermission.Size = new System.Drawing.Size(135, 23);
            this.btnBatchPermission.TabIndex = 3;
            this.btnBatchPermission.Text = "批量设置权限...";
            this.btnBatchPermission.UseVisualStyleBackColor = true;
            this.btnBatchPermission.Visible = false;
            this.btnBatchPermission.Click += new System.EventHandler(this.btnBatchPermission_Click);
            // 
            // btnRoleUserBatchSet
            // 
            this.btnRoleUserBatchSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRoleUserBatchSet.Enabled = false;
            this.btnRoleUserBatchSet.Location = new System.Drawing.Point(5, 3);
            this.btnRoleUserBatchSet.Name = "btnRoleUserBatchSet";
            this.btnRoleUserBatchSet.Size = new System.Drawing.Size(135, 23);
            this.btnRoleUserBatchSet.TabIndex = 4;
            this.btnRoleUserBatchSet.Text = "角色用户关联...";
            this.btnRoleUserBatchSet.UseVisualStyleBackColor = true;
            this.btnRoleUserBatchSet.Click += new System.EventHandler(this.btnRoleUserBatchSet_Click);
            // 
            // btnFrmRoleAuthorizationScope
            // 
            this.btnFrmRoleAuthorizationScope.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFrmRoleAuthorizationScope.Enabled = false;
            this.btnFrmRoleAuthorizationScope.Location = new System.Drawing.Point(710, 3);
            this.btnFrmRoleAuthorizationScope.Name = "btnFrmRoleAuthorizationScope";
            this.btnFrmRoleAuthorizationScope.Size = new System.Drawing.Size(135, 23);
            this.btnFrmRoleAuthorizationScope.TabIndex = 0;
            this.btnFrmRoleAuthorizationScope.Text = "角色授权范围...";
            this.btnFrmRoleAuthorizationScope.UseVisualStyleBackColor = true;
            this.btnFrmRoleAuthorizationScope.Click += new System.EventHandler(this.btnFrmRoleAuthorizationScope_Click);
            // 
            // btnFrmRoleAdminScope
            // 
            this.btnFrmRoleAdminScope.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFrmRoleAdminScope.Enabled = false;
            this.btnFrmRoleAdminScope.Location = new System.Drawing.Point(287, 3);
            this.btnFrmRoleAdminScope.Name = "btnFrmRoleAdminScope";
            this.btnFrmRoleAdminScope.Size = new System.Drawing.Size(135, 23);
            this.btnFrmRoleAdminScope.TabIndex = 1;
            this.btnFrmRoleAdminScope.Text = "角色管理范围...";
            this.btnFrmRoleAdminScope.UseVisualStyleBackColor = true;
            this.btnFrmRoleAdminScope.Click += new System.EventHandler(this.btnFrmRoleAdminScope_Click);
            // 
            // btnFrmTableColumnPermission
            // 
            this.btnFrmTableColumnPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFrmTableColumnPermission.Enabled = false;
            this.btnFrmTableColumnPermission.Location = new System.Drawing.Point(428, 3);
            this.btnFrmTableColumnPermission.Name = "btnFrmTableColumnPermission";
            this.btnFrmTableColumnPermission.Size = new System.Drawing.Size(135, 23);
            this.btnFrmTableColumnPermission.TabIndex = 19;
            this.btnFrmTableColumnPermission.Text = "表字段权限...";
            this.btnFrmTableColumnPermission.UseVisualStyleBackColor = true;
            this.btnFrmTableColumnPermission.Click += new System.EventHandler(this.btnFrmTableColumnPermission_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnFrmRoleAuthorizationScope);
            this.flowLayoutPanel1.Controls.Add(this.btnFrmRoleTableScope);
            this.flowLayoutPanel1.Controls.Add(this.btnFrmTableColumnPermission);
            this.flowLayoutPanel1.Controls.Add(this.btnFrmRoleAdminScope);
            this.flowLayoutPanel1.Controls.Add(this.btnBatchPermission);
            this.flowLayoutPanel1.Controls.Add(this.btnRoleUserBatchSet);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(62, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(848, 29);
            this.flowLayoutPanel1.TabIndex = 20;
            // 
            // FrmRolePermissionAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(915, 510);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.cmbRoleCategory);
            this.Controls.Add(this.lblRoleCategories);
            this.Controls.Add(this.lblContents);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.ucTableSort);
            this.Controls.Add(this.btnBatchSave);
            this.Controls.Add(this.btnRolePermission);
            this.Controls.Add(this.btnRoleUser);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.grdRole);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnBatchDelete);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmRolePermissionAdmin";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "角色权限管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRoleAdmin_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.grdRole)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBatchDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnBatchSave;
        private System.Windows.Forms.Button btnRoleUser;
        private System.Windows.Forms.Button btnRolePermission;
        private DotNet.WinForm.UCTableSort ucTableSort;
        private System.Windows.Forms.DataGridView grdRole;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblContents;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblRoleCategories;
        private System.Windows.Forms.ComboBox cmbRoleCategory;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.Button btnFrmRoleTableScope;
        private System.Windows.Forms.Button btnBatchPermission;
        private System.Windows.Forms.Button btnRoleUserBatchSet;
        private System.Windows.Forms.Button btnFrmRoleAuthorizationScope;
        private System.Windows.Forms.Button btnFrmRoleAdminScope;
        private System.Windows.Forms.Button btnFrmTableColumnPermission;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}