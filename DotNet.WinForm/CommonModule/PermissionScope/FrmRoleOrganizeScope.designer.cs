namespace DotNet.WinForm
{
    partial class FrmRoleOrganizeScope
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ucTableSort = new DotNet.WinForm.UCTableSort();
            this.btnClose = new System.Windows.Forms.Button();
            this.grdRole = new System.Windows.Forms.DataGridView();
            this.colRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAll = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUserCompany = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUserSubCompany = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUserDepartment = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUserWorkgroup = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUser = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDetail = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnBatchSave = new System.Windows.Forms.Button();
            this.lblPermissionScopeReq = new System.Windows.Forms.Label();
            this.ucPermissionScope = new DotNet.WinForm.UCScopePermissionSelect();
            this.lblPermissionScope = new System.Windows.Forms.Label();
            this.cmbRoleCategory = new System.Windows.Forms.ComboBox();
            this.lblRoleCategories = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.grdRole)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucTableSort
            // 
            this.ucTableSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ucTableSort.Location = new System.Drawing.Point(8, 567);
            this.ucTableSort.Margin = new System.Windows.Forms.Padding(0);
            this.ucTableSort.Name = "ucTableSort";
            this.ucTableSort.OEntityId = null;
            this.ucTableSort.Padding = new System.Windows.Forms.Padding(1);
            this.ucTableSort.SetBottomEnabled = false;
            this.ucTableSort.SetDownEnabled = false;
            this.ucTableSort.SetTopEnabled = false;
            this.ucTableSort.SetUpEnabled = false;
            this.ucTableSort.Size = new System.Drawing.Size(99, 24);
            this.ucTableSort.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(842, 568);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
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
            this.colRealName,
            this.colAll,
            this.colUserCompany,
            this.colUserSubCompany,
            this.colUserDepartment,
            this.colUserWorkgroup,
            this.colUser,
            this.colDetail});
            this.grdRole.Location = new System.Drawing.Point(10, 32);
            this.grdRole.MultiSelect = false;
            this.grdRole.Name = "grdRole";
            this.grdRole.RowTemplate.Height = 23;
            this.grdRole.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdRole.Size = new System.Drawing.Size(905, 528);
            this.grdRole.TabIndex = 5;
            this.grdRole.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdRole_CellContentClick);
            // 
            // colRealName
            // 
            this.colRealName.DataPropertyName = "RealName";
            this.colRealName.FillWeight = 150F;
            this.colRealName.Frozen = true;
            this.colRealName.HeaderText = "名称";
            this.colRealName.MaxInputLength = 200;
            this.colRealName.Name = "colRealName";
            this.colRealName.ReadOnly = true;
            this.colRealName.Width = 150;
            // 
            // colAll
            // 
            this.colAll.DataPropertyName = "colAll";
            this.colAll.FillWeight = 80F;
            this.colAll.HeaderText = "全部";
            this.colAll.Name = "colAll";
            // 
            // colUserCompany
            // 
            this.colUserCompany.DataPropertyName = "colUserCompany";
            this.colUserCompany.FillWeight = 80F;
            this.colUserCompany.HeaderText = "所在公司";
            this.colUserCompany.Name = "colUserCompany";
            // 
            // colUserSubCompany
            // 
            this.colUserSubCompany.DataPropertyName = "colUserSubCompany";
            this.colUserSubCompany.HeaderText = "所在分支机构";
            this.colUserSubCompany.Name = "colUserSubCompany";
            // 
            // colUserDepartment
            // 
            this.colUserDepartment.DataPropertyName = "colUserDepartment";
            this.colUserDepartment.FillWeight = 80F;
            this.colUserDepartment.HeaderText = "所在部门";
            this.colUserDepartment.Name = "colUserDepartment";
            // 
            // colUserWorkgroup
            // 
            this.colUserWorkgroup.DataPropertyName = "colUserWorkgroup";
            this.colUserWorkgroup.FillWeight = 80F;
            this.colUserWorkgroup.HeaderText = "所在工作组";
            this.colUserWorkgroup.Name = "colUserWorkgroup";
            // 
            // colUser
            // 
            this.colUser.DataPropertyName = "colUser";
            this.colUser.FillWeight = 80F;
            this.colUser.HeaderText = "仅本人";
            this.colUser.Name = "colUser";
            // 
            // colDetail
            // 
            this.colDetail.FillWeight = 80F;
            this.colDetail.HeaderText = "设置明细";
            this.colDetail.Name = "colDetail";
            this.colDetail.Text = "Detail";
            this.colDetail.ToolTipText = "组织机构为基础数据权限明细";
            this.colDetail.UseColumnTextForButtonValue = true;
            this.colDetail.Width = 80;
            // 
            // btnBatchSave
            // 
            this.btnBatchSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchSave.Location = new System.Drawing.Point(764, 568);
            this.btnBatchSave.Name = "btnBatchSave";
            this.btnBatchSave.Size = new System.Drawing.Size(75, 23);
            this.btnBatchSave.TabIndex = 7;
            this.btnBatchSave.Text = "保存(&S)";
            this.btnBatchSave.UseVisualStyleBackColor = true;
            this.btnBatchSave.Click += new System.EventHandler(this.btnBatchSave_Click);
            // 
            // lblPermissionScopeReq
            // 
            this.lblPermissionScopeReq.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPermissionScopeReq.AutoSize = true;
            this.lblPermissionScopeReq.ForeColor = System.Drawing.Color.Red;
            this.lblPermissionScopeReq.Location = new System.Drawing.Point(391, 8);
            this.lblPermissionScopeReq.Name = "lblPermissionScopeReq";
            this.lblPermissionScopeReq.Size = new System.Drawing.Size(11, 12);
            this.lblPermissionScopeReq.TabIndex = 2;
            this.lblPermissionScopeReq.Text = "*";
            // 
            // ucPermissionScope
            // 
            this.ucPermissionScope.AllowNull = false;
            this.ucPermissionScope.AllowSelect = true;
            this.ucPermissionScope.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ucPermissionScope.Location = new System.Drawing.Point(146, 3);
            this.ucPermissionScope.MultiSelect = false;
            this.ucPermissionScope.Name = "ucPermissionScope";
            this.ucPermissionScope.SelectedFullName = "";
            this.ucPermissionScope.SelectedId = "";
            this.ucPermissionScope.Size = new System.Drawing.Size(239, 22);
            this.ucPermissionScope.TabIndex = 1;
            this.ucPermissionScope.SelectedIndexChanged += new DotNet.Utilities.BaseBusinessLogic.SelectedIndexChangedEventHandler(this.ucPermissionScope_SelectedIndexChanged);
            // 
            // lblPermissionScope
            // 
            this.lblPermissionScope.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPermissionScope.AutoSize = true;
            this.lblPermissionScope.Location = new System.Drawing.Point(75, 8);
            this.lblPermissionScope.Name = "lblPermissionScope";
            this.lblPermissionScope.Size = new System.Drawing.Size(65, 12);
            this.lblPermissionScope.TabIndex = 0;
            this.lblPermissionScope.Text = "数据权限：";
            this.lblPermissionScope.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbRoleCategory
            // 
            this.cmbRoleCategory.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmbRoleCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoleCategory.Location = new System.Drawing.Point(478, 4);
            this.cmbRoleCategory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbRoleCategory.Name = "cmbRoleCategory";
            this.cmbRoleCategory.Size = new System.Drawing.Size(184, 20);
            this.cmbRoleCategory.TabIndex = 4;
            this.cmbRoleCategory.SelectedIndexChanged += new System.EventHandler(this.cmbRoleCategory_SelectedIndexChanged);
            // 
            // lblRoleCategories
            // 
            this.lblRoleCategories.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblRoleCategories.AutoSize = true;
            this.lblRoleCategories.Location = new System.Drawing.Point(408, 8);
            this.lblRoleCategories.Name = "lblRoleCategories";
            this.lblRoleCategories.Size = new System.Drawing.Size(65, 12);
            this.lblRoleCategories.TabIndex = 3;
            this.lblRoleCategories.Text = "角色分类：";
            this.lblRoleCategories.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(806, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(111, 23);
            this.btnExport.TabIndex = 16;
            this.btnExport.Text = "导出Excel...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cmbRoleCategory);
            this.flowLayoutPanel1.Controls.Add(this.lblRoleCategories);
            this.flowLayoutPanel1.Controls.Add(this.lblPermissionScopeReq);
            this.flowLayoutPanel1.Controls.Add(this.ucPermissionScope);
            this.flowLayoutPanel1.Controls.Add(this.lblPermissionScope);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(664, 27);
            this.flowLayoutPanel1.TabIndex = 17;
            // 
            // FrmRoleOrganizeScope
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 597);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnBatchSave);
            this.Controls.Add(this.ucTableSort);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grdRole);
            this.Name = "FrmRoleOrganizeScope";
            this.Text = "角色管理范围设置";
            ((System.ComponentModel.ISupportInitialize)(this.grdRole)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DotNet.WinForm.UCTableSort ucTableSort;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView grdRole;
        private System.Windows.Forms.Button btnBatchSave;
        private System.Windows.Forms.Label lblPermissionScopeReq;
        private DotNet.WinForm.UCScopePermissionSelect ucPermissionScope;
        private System.Windows.Forms.Label lblPermissionScope;
        private System.Windows.Forms.ComboBox cmbRoleCategory;
        private System.Windows.Forms.Label lblRoleCategories;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUserCompany;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUserSubCompany;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUserDepartment;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUserWorkgroup;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUser;
        private System.Windows.Forms.DataGridViewButtonColumn colDetail;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}