namespace DotNet.WinForm
{
    partial class FrmWorkFlowActivityAdmin
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpActivity = new System.Windows.Forms.GroupBox();
            this.lblParentReq = new System.Windows.Forms.Label();
            this.ucOrganize = new DotNet.WinForm.UCOrganizeSelect();
            this.lblParent = new System.Windows.Forms.Label();
            this.ucRole = new DotNet.WinForm.UCRoleSelect();
            this.ucUserSelect = new DotNet.WinForm.UCUserSelect();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblFullNameReq = new System.Windows.Forms.Label();
            this.lblStaffReq = new System.Windows.Forms.Label();
            this.lblRoleReq = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtWorkFlowCode = new System.Windows.Forms.TextBox();
            this.lblWorkFlowCode = new System.Windows.Forms.Label();
            this.txtWorkFlowFullName = new System.Windows.Forms.TextBox();
            this.lblWorkFlowFullName = new System.Windows.Forms.Label();
            this.ucTableSort = new DotNet.WinForm.UCTableSort();
            this.btnBatchSave = new System.Windows.Forms.Button();
            this.grdWorkFlowActivity = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtAuditWorkFlowCode = new System.Windows.Forms.TextBox();
            this.lblAuditWorkFlowCode = new System.Windows.Forms.Label();
            this.txtBillCategory = new System.Windows.Forms.TextBox();
            this.lblBillCategory = new System.Windows.Forms.Label();
            this.txtBillName = new System.Windows.Forms.TextBox();
            this.lblBillName = new System.Windows.Forms.Label();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAuditUserRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAuditDepartmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAuditRoleRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpActivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkFlowActivity)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(917, 462);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(918, 625);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grpActivity
            // 
            this.grpActivity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpActivity.Controls.Add(this.lblParentReq);
            this.grpActivity.Controls.Add(this.ucOrganize);
            this.grpActivity.Controls.Add(this.lblParent);
            this.grpActivity.Controls.Add(this.ucRole);
            this.grpActivity.Controls.Add(this.ucUserSelect);
            this.grpActivity.Controls.Add(this.lblDescription);
            this.grpActivity.Controls.Add(this.txtDescription);
            this.grpActivity.Controls.Add(this.lblFullNameReq);
            this.grpActivity.Controls.Add(this.lblStaffReq);
            this.grpActivity.Controls.Add(this.lblRoleReq);
            this.grpActivity.Controls.Add(this.lblRole);
            this.grpActivity.Controls.Add(this.lblUser);
            this.grpActivity.Controls.Add(this.lblFullName);
            this.grpActivity.Controls.Add(this.txtFullName);
            this.grpActivity.Location = new System.Drawing.Point(7, 489);
            this.grpActivity.Name = "grpActivity";
            this.grpActivity.Padding = new System.Windows.Forms.Padding(8);
            this.grpActivity.Size = new System.Drawing.Size(985, 131);
            this.grpActivity.TabIndex = 8;
            this.grpActivity.TabStop = false;
            this.grpActivity.Text = "审批流程步骤";
            // 
            // lblParentReq
            // 
            this.lblParentReq.AutoSize = true;
            this.lblParentReq.ForeColor = System.Drawing.Color.Red;
            this.lblParentReq.Location = new System.Drawing.Point(414, 53);
            this.lblParentReq.Name = "lblParentReq";
            this.lblParentReq.Size = new System.Drawing.Size(11, 12);
            this.lblParentReq.TabIndex = 18;
            this.lblParentReq.Text = "*";
            // 
            // ucOrganize
            // 
            this.ucOrganize.AllowNull = true;
            this.ucOrganize.AllowSelect = true;
            this.ucOrganize.AutoSize = true;
            this.ucOrganize.CanEdit = false;
            this.ucOrganize.CheckMove = false;
            this.ucOrganize.Location = new System.Drawing.Point(115, 47);
            this.ucOrganize.MultiSelect = false;
            this.ucOrganize.Name = "ucOrganize";
            this.ucOrganize.OpenId = "";
            this.ucOrganize.PermissionItemScopeCode = "";
            this.ucOrganize.SelectedFullName = "";
            this.ucOrganize.SelectedId = "";
            this.ucOrganize.Size = new System.Drawing.Size(284, 23);
            this.ucOrganize.TabIndex = 17;
            // 
            // lblParent
            // 
            this.lblParent.Location = new System.Drawing.Point(-2, 53);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(111, 12);
            this.lblParent.TabIndex = 16;
            this.lblParent.Text = "组织机构(&O)：";
            this.lblParent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucRole
            // 
            this.ucRole.AllowNull = true;
            this.ucRole.AllowSelect = true;
            this.ucRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucRole.Location = new System.Drawing.Point(666, 48);
            this.ucRole.MultiSelect = false;
            this.ucRole.Name = "ucRole";
            this.ucRole.OpenId = "";
            this.ucRole.PermissionItemScopeCode = "";
            this.ucRole.RemoveIds = null;
            this.ucRole.SelectedFullName = "";
            this.ucRole.SelectedId = "";
            this.ucRole.SelectedIds = null;
            this.ucRole.ShowRoleOnly = true;
            this.ucRole.Size = new System.Drawing.Size(289, 22);
            this.ucRole.TabIndex = 7;
            // 
            // ucUserSelect
            // 
            this.ucUserSelect.AllowNull = true;
            this.ucUserSelect.AllowSelect = true;
            this.ucUserSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucUserSelect.Location = new System.Drawing.Point(666, 20);
            this.ucUserSelect.MultiSelect = false;
            this.ucUserSelect.Name = "ucUserSelect";
            this.ucUserSelect.OpenId = "";
            this.ucUserSelect.PermissionItemScopeCode = "";
            this.ucUserSelect.RemoveIds = null;
            this.ucUserSelect.SelectedFullName = "";
            this.ucUserSelect.SelectedId = "";
            this.ucUserSelect.SelectedIds = null;
            this.ucUserSelect.SetSelectIds = null;
            this.ucUserSelect.Size = new System.Drawing.Size(289, 22);
            this.ucUserSelect.TabIndex = 4;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(39, 79);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(70, 12);
            this.lblDescription.TabIndex = 9;
            this.lblDescription.Text = "描述(&I)：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(115, 76);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(841, 44);
            this.txtDescription.TabIndex = 10;
            // 
            // lblFullNameReq
            // 
            this.lblFullNameReq.AutoSize = true;
            this.lblFullNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblFullNameReq.Location = new System.Drawing.Point(414, 22);
            this.lblFullNameReq.Name = "lblFullNameReq";
            this.lblFullNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblFullNameReq.TabIndex = 2;
            this.lblFullNameReq.Text = "*";
            // 
            // lblStaffReq
            // 
            this.lblStaffReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStaffReq.AutoSize = true;
            this.lblStaffReq.ForeColor = System.Drawing.Color.Red;
            this.lblStaffReq.Location = new System.Drawing.Point(963, 24);
            this.lblStaffReq.Name = "lblStaffReq";
            this.lblStaffReq.Size = new System.Drawing.Size(11, 12);
            this.lblStaffReq.TabIndex = 5;
            this.lblStaffReq.Text = "*";
            // 
            // lblRoleReq
            // 
            this.lblRoleReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRoleReq.AutoSize = true;
            this.lblRoleReq.ForeColor = System.Drawing.Color.Red;
            this.lblRoleReq.Location = new System.Drawing.Point(963, 49);
            this.lblRoleReq.Name = "lblRoleReq";
            this.lblRoleReq.Size = new System.Drawing.Size(11, 12);
            this.lblRoleReq.TabIndex = 8;
            this.lblRoleReq.Text = "*";
            // 
            // lblRole
            // 
            this.lblRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRole.Location = new System.Drawing.Point(575, 53);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(85, 12);
            this.lblRole.TabIndex = 6;
            this.lblRole.Text = "角色(&R)：";
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUser
            // 
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.Location = new System.Drawing.Point(575, 24);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(85, 12);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "用户(&U)：";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(25, 22);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(84, 12);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "审核(&F)：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(115, 16);
            this.txtFullName.MaxLength = 200;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(284, 21);
            this.txtFullName.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(831, 625);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(81, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtWorkFlowCode
            // 
            this.txtWorkFlowCode.Location = new System.Drawing.Point(145, 36);
            this.txtWorkFlowCode.MaxLength = 50;
            this.txtWorkFlowCode.Name = "txtWorkFlowCode";
            this.txtWorkFlowCode.ReadOnly = true;
            this.txtWorkFlowCode.Size = new System.Drawing.Size(180, 21);
            this.txtWorkFlowCode.TabIndex = 1;
            // 
            // lblWorkFlowCode
            // 
            this.lblWorkFlowCode.Location = new System.Drawing.Point(5, 39);
            this.lblWorkFlowCode.Name = "lblWorkFlowCode";
            this.lblWorkFlowCode.Size = new System.Drawing.Size(144, 12);
            this.lblWorkFlowCode.TabIndex = 0;
            this.lblWorkFlowCode.Text = "审批流程编号(&C)：";
            this.lblWorkFlowCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWorkFlowFullName
            // 
            this.txtWorkFlowFullName.Location = new System.Drawing.Point(478, 36);
            this.txtWorkFlowFullName.MaxLength = 50;
            this.txtWorkFlowFullName.Name = "txtWorkFlowFullName";
            this.txtWorkFlowFullName.ReadOnly = true;
            this.txtWorkFlowFullName.Size = new System.Drawing.Size(180, 21);
            this.txtWorkFlowFullName.TabIndex = 3;
            // 
            // lblWorkFlowFullName
            // 
            this.lblWorkFlowFullName.Location = new System.Drawing.Point(330, 39);
            this.lblWorkFlowFullName.Name = "lblWorkFlowFullName";
            this.lblWorkFlowFullName.Size = new System.Drawing.Size(142, 12);
            this.lblWorkFlowFullName.TabIndex = 2;
            this.lblWorkFlowFullName.Text = "审批流程名称(&N)：";
            this.lblWorkFlowFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucTableSort
            // 
            this.ucTableSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ucTableSort.Location = new System.Drawing.Point(7, 461);
            this.ucTableSort.Margin = new System.Windows.Forms.Padding(0);
            this.ucTableSort.Name = "ucTableSort";
            this.ucTableSort.OEntityId = null;
            this.ucTableSort.Padding = new System.Windows.Forms.Padding(1);
            this.ucTableSort.SetBottomEnabled = false;
            this.ucTableSort.SetDownEnabled = false;
            this.ucTableSort.SetTopEnabled = false;
            this.ucTableSort.SetUpEnabled = false;
            this.ucTableSort.Size = new System.Drawing.Size(99, 24);
            this.ucTableSort.TabIndex = 5;
            // 
            // btnBatchSave
            // 
            this.btnBatchSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchSave.Location = new System.Drawing.Point(839, 462);
            this.btnBatchSave.Name = "btnBatchSave";
            this.btnBatchSave.Size = new System.Drawing.Size(75, 23);
            this.btnBatchSave.TabIndex = 6;
            this.btnBatchSave.Text = "保存(&S)";
            this.btnBatchSave.UseVisualStyleBackColor = true;
            this.btnBatchSave.Click += new System.EventHandler(this.btnBatchSave_Click);
            // 
            // grdWorkFlowActivity
            // 
            this.grdWorkFlowActivity.AllowUserToAddRows = false;
            this.grdWorkFlowActivity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdWorkFlowActivity.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdWorkFlowActivity.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdWorkFlowActivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdWorkFlowActivity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colFullName,
            this.colAuditUserRealName,
            this.colAuditDepartmentName,
            this.colAuditRoleRealName,
            this.colDescription});
            this.grdWorkFlowActivity.Location = new System.Drawing.Point(7, 69);
            this.grdWorkFlowActivity.MultiSelect = false;
            this.grdWorkFlowActivity.Name = "grdWorkFlowActivity";
            this.grdWorkFlowActivity.RowTemplate.Height = 23;
            this.grdWorkFlowActivity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdWorkFlowActivity.Size = new System.Drawing.Size(982, 385);
            this.grdWorkFlowActivity.TabIndex = 4;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(722, 462);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(111, 23);
            this.btnExport.TabIndex = 12;
            this.btnExport.Text = "导出Excel...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtAuditWorkFlowCode
            // 
            this.txtAuditWorkFlowCode.Location = new System.Drawing.Point(145, 9);
            this.txtAuditWorkFlowCode.MaxLength = 50;
            this.txtAuditWorkFlowCode.Name = "txtAuditWorkFlowCode";
            this.txtAuditWorkFlowCode.ReadOnly = true;
            this.txtAuditWorkFlowCode.Size = new System.Drawing.Size(180, 21);
            this.txtAuditWorkFlowCode.TabIndex = 14;
            // 
            // lblAuditWorkFlowCode
            // 
            this.lblAuditWorkFlowCode.Location = new System.Drawing.Point(5, 12);
            this.lblAuditWorkFlowCode.Name = "lblAuditWorkFlowCode";
            this.lblAuditWorkFlowCode.Size = new System.Drawing.Size(144, 12);
            this.lblAuditWorkFlowCode.TabIndex = 13;
            this.lblAuditWorkFlowCode.Text = "流程类型(&T)：";
            this.lblAuditWorkFlowCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBillCategory
            // 
            this.txtBillCategory.Location = new System.Drawing.Point(478, 9);
            this.txtBillCategory.MaxLength = 50;
            this.txtBillCategory.Name = "txtBillCategory";
            this.txtBillCategory.ReadOnly = true;
            this.txtBillCategory.Size = new System.Drawing.Size(180, 21);
            this.txtBillCategory.TabIndex = 16;
            // 
            // lblBillCategory
            // 
            this.lblBillCategory.Location = new System.Drawing.Point(330, 12);
            this.lblBillCategory.Name = "lblBillCategory";
            this.lblBillCategory.Size = new System.Drawing.Size(142, 12);
            this.lblBillCategory.TabIndex = 15;
            this.lblBillCategory.Text = "单据分类(&B)：";
            this.lblBillCategory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBillName
            // 
            this.txtBillName.Location = new System.Drawing.Point(808, 12);
            this.txtBillName.MaxLength = 50;
            this.txtBillName.Name = "txtBillName";
            this.txtBillName.ReadOnly = true;
            this.txtBillName.Size = new System.Drawing.Size(180, 21);
            this.txtBillName.TabIndex = 18;
            // 
            // lblBillName
            // 
            this.lblBillName.Location = new System.Drawing.Point(660, 15);
            this.lblBillName.Name = "lblBillName";
            this.lblBillName.Size = new System.Drawing.Size(142, 12);
            this.lblBillName.TabIndex = 17;
            this.lblBillName.Text = "单据名称(&I)：";
            this.lblBillName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "Selected";
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Width = 50;
            // 
            // colFullName
            // 
            this.colFullName.DataPropertyName = "FullName";
            this.colFullName.FillWeight = 200F;
            this.colFullName.HeaderText = "审核";
            this.colFullName.MaxInputLength = 150;
            this.colFullName.Name = "colFullName";
            this.colFullName.ReadOnly = true;
            this.colFullName.Width = 150;
            // 
            // colAuditUserRealName
            // 
            this.colAuditUserRealName.DataPropertyName = "AuditUserRealName";
            this.colAuditUserRealName.HeaderText = "用户";
            this.colAuditUserRealName.MaxInputLength = 20;
            this.colAuditUserRealName.Name = "colAuditUserRealName";
            this.colAuditUserRealName.ReadOnly = true;
            // 
            // colAuditDepartmentName
            // 
            this.colAuditDepartmentName.DataPropertyName = "AuditDepartmentName";
            this.colAuditDepartmentName.HeaderText = "部门";
            this.colAuditDepartmentName.Name = "colAuditDepartmentName";
            this.colAuditDepartmentName.Width = 200;
            // 
            // colAuditRoleRealName
            // 
            this.colAuditRoleRealName.DataPropertyName = "AuditRoleRealName";
            this.colAuditRoleRealName.FillWeight = 150F;
            this.colAuditRoleRealName.HeaderText = "角色";
            this.colAuditRoleRealName.MaxInputLength = 20;
            this.colAuditRoleRealName.Name = "colAuditRoleRealName";
            this.colAuditRoleRealName.ReadOnly = true;
            this.colAuditRoleRealName.Width = 150;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colDescription.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDescription.FillWeight = 180F;
            this.colDescription.HeaderText = "描述";
            this.colDescription.MaxInputLength = 140;
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 200;
            // 
            // FrmWorkFlowActivityAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1000, 655);
            this.Controls.Add(this.txtBillName);
            this.Controls.Add(this.lblBillName);
            this.Controls.Add(this.txtAuditWorkFlowCode);
            this.Controls.Add(this.lblAuditWorkFlowCode);
            this.Controls.Add(this.txtBillCategory);
            this.Controls.Add(this.lblBillCategory);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.grdWorkFlowActivity);
            this.Controls.Add(this.btnBatchSave);
            this.Controls.Add(this.ucTableSort);
            this.Controls.Add(this.txtWorkFlowCode);
            this.Controls.Add(this.lblWorkFlowCode);
            this.Controls.Add(this.txtWorkFlowFullName);
            this.Controls.Add(this.lblWorkFlowFullName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.grpActivity);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClose);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmWorkFlowActivityAdmin";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "审批流程步骤定义";
            this.grpActivity.ResumeLayout(false);
            this.grpActivity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkFlowActivity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grpActivity;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblFullNameReq;
        private System.Windows.Forms.Label lblStaffReq;
        private System.Windows.Forms.Label lblRoleReq;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtWorkFlowCode;
        private System.Windows.Forms.Label lblWorkFlowCode;
        private System.Windows.Forms.TextBox txtWorkFlowFullName;
        private System.Windows.Forms.Label lblWorkFlowFullName;
        private DotNet.WinForm.UCTableSort ucTableSort;
        private System.Windows.Forms.Button btnBatchSave;
        private DotNet.WinForm.UCRoleSelect ucRole;
        private DotNet.WinForm.UCUserSelect ucUserSelect;
        private System.Windows.Forms.DataGridView grdWorkFlowActivity;
        private System.Windows.Forms.Button btnExport;
        private UCOrganizeSelect ucOrganize;
        private System.Windows.Forms.Label lblParent;
        private System.Windows.Forms.Label lblParentReq;
        private System.Windows.Forms.TextBox txtAuditWorkFlowCode;
        private System.Windows.Forms.Label lblAuditWorkFlowCode;
        private System.Windows.Forms.TextBox txtBillCategory;
        private System.Windows.Forms.Label lblBillCategory;
        private System.Windows.Forms.TextBox txtBillName;
        private System.Windows.Forms.Label lblBillName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuditUserRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuditDepartmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuditRoleRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
    }
}