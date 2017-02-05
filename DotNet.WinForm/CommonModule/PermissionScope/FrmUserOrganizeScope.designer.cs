namespace DotNet.WinForm
{
    partial class FrmUserOrganizeScope
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
            this.grdUser = new System.Windows.Forms.DataGridView();
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblContents = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).BeginInit();
            this.SuspendLayout();
            // 
            // ucTableSort
            // 
            this.ucTableSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ucTableSort.Location = new System.Drawing.Point(8, 563);
            this.ucTableSort.Margin = new System.Windows.Forms.Padding(0);
            this.ucTableSort.Name = "ucTableSort";
            this.ucTableSort.OEntityId = null;
            this.ucTableSort.Padding = new System.Windows.Forms.Padding(1);
            this.ucTableSort.SetBottomEnabled = false;
            this.ucTableSort.SetDownEnabled = false;
            this.ucTableSort.SetTopEnabled = false;
            this.ucTableSort.SetUpEnabled = false;
            this.ucTableSort.Size = new System.Drawing.Size(99, 24);
            this.ucTableSort.TabIndex = 7;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(841, 564);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // grdUser
            // 
            this.grdUser.AllowUserToAddRows = false;
            this.grdUser.AllowUserToDeleteRows = false;
            this.grdUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdUser.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRealName,
            this.colAll,
            this.colUserCompany,
            this.colUserSubCompany,
            this.colUserDepartment,
            this.colUserWorkgroup,
            this.colUser,
            this.colDetail});
            this.grdUser.Location = new System.Drawing.Point(10, 40);
            this.grdUser.MultiSelect = false;
            this.grdUser.Name = "grdUser";
            this.grdUser.RowTemplate.Height = 23;
            this.grdUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdUser.Size = new System.Drawing.Size(904, 516);
            this.grdUser.TabIndex = 6;
            this.grdUser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdUser_CellContentClick);
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
            this.colUserSubCompany.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            this.btnBatchSave.Location = new System.Drawing.Point(763, 564);
            this.btnBatchSave.Name = "btnBatchSave";
            this.btnBatchSave.Size = new System.Drawing.Size(75, 23);
            this.btnBatchSave.TabIndex = 8;
            this.btnBatchSave.Text = "保存(&S)";
            this.btnBatchSave.UseVisualStyleBackColor = true;
            this.btnBatchSave.Click += new System.EventHandler(this.btnBatchSave_Click);
            // 
            // lblPermissionScopeReq
            // 
            this.lblPermissionScopeReq.AutoSize = true;
            this.lblPermissionScopeReq.ForeColor = System.Drawing.Color.Red;
            this.lblPermissionScopeReq.Location = new System.Drawing.Point(372, 16);
            this.lblPermissionScopeReq.Name = "lblPermissionScopeReq";
            this.lblPermissionScopeReq.Size = new System.Drawing.Size(11, 12);
            this.lblPermissionScopeReq.TabIndex = 2;
            this.lblPermissionScopeReq.Text = "*";
            // 
            // ucPermissionScope
            // 
            this.ucPermissionScope.AllowNull = false;
            this.ucPermissionScope.AllowSelect = true;
            this.ucPermissionScope.Location = new System.Drawing.Point(91, 11);
            this.ucPermissionScope.MultiSelect = false;
            this.ucPermissionScope.Name = "ucPermissionScope";
            this.ucPermissionScope.SelectedFullName = "";
            this.ucPermissionScope.SelectedId = "";
            this.ucPermissionScope.Size = new System.Drawing.Size(276, 22);
            this.ucPermissionScope.TabIndex = 1;
            this.ucPermissionScope.SelectedIndexChanged += new DotNet.Utilities.BaseBusinessLogic.SelectedIndexChangedEventHandler(this.ucPermissionScope_SelectedIndexChanged);
            // 
            // lblPermissionScope
            // 
            this.lblPermissionScope.Location = new System.Drawing.Point(14, 14);
            this.lblPermissionScope.Name = "lblPermissionScope";
            this.lblPermissionScope.Size = new System.Drawing.Size(81, 12);
            this.lblPermissionScope.TabIndex = 0;
            this.lblPermissionScope.Text = "数据权限：";
            this.lblPermissionScope.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(702, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "查询(&F)";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // lblContents
            // 
            this.lblContents.Location = new System.Drawing.Point(425, 16);
            this.lblContents.Name = "lblContents";
            this.lblContents.Size = new System.Drawing.Size(87, 12);
            this.lblContents.TabIndex = 3;
            this.lblContents.Text = "查询(&S)：";
            this.lblContents.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(515, 12);
            this.txtSearch.MaxLength = 20;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(184, 21);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(805, 10);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(111, 23);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "导出Excel...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // FrmUserOrganizeScope
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 593);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblContents);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblPermissionScopeReq);
            this.Controls.Add(this.ucPermissionScope);
            this.Controls.Add(this.lblPermissionScope);
            this.Controls.Add(this.btnBatchSave);
            this.Controls.Add(this.ucTableSort);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grdUser);
            this.Name = "FrmUserOrganizeScope";
            this.Text = "用户管理范围设置";
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DotNet.WinForm.UCTableSort ucTableSort;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView grdUser;
        private System.Windows.Forms.Button btnBatchSave;
        private System.Windows.Forms.Label lblPermissionScopeReq;
        private DotNet.WinForm.UCScopePermissionSelect ucPermissionScope;
        private System.Windows.Forms.Label lblPermissionScope;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblContents;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUserCompany;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUserSubCompany;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUserDepartment;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUserWorkgroup;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUser;
        private System.Windows.Forms.DataGridViewButtonColumn colDetail;
    }
}