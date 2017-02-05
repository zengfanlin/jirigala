namespace DotNet.WinForm
{
    partial class FrmUserPermissionAdmin
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserPermissionAdmin));
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.grdUser = new System.Windows.Forms.DataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSetPassword = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnProperty = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnPermission = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.btnUserRole = new System.Windows.Forms.Button();
            this.btnUserOrganizeScope = new System.Windows.Forms.Button();
            this.btnBatchPermission = new System.Windows.Forms.Button();
            this.btnRoleUserBatchSet = new System.Windows.Forms.Button();
            this.btnUseAuthorizationScope = new System.Windows.Forms.Button();
            this.btnFrmUserTableScope = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnFrmTableColumnPermission = new System.Windows.Forms.Button();
            this.splUser = new System.Windows.Forms.SplitContainer();
            this.tvOrganize = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splUser)).BeginInit();
            this.splUser.Panel1.SuspendLayout();
            this.splUser.Panel2.SuspendLayout();
            this.splUser.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdUser
            // 
            this.grdUser.AllowUserToAddRows = false;
            this.grdUser.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.grdUser.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            this.colUserName,
            this.colRealName,
            this.colRole,
            this.colDepartmentName,
            this.colEnabled,
            this.colDescription});
            this.grdUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUser.GridColor = System.Drawing.SystemColors.Control;
            this.grdUser.Location = new System.Drawing.Point(0, 0);
            this.grdUser.MultiSelect = false;
            this.grdUser.Name = "grdUser";
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.grdUser.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdUser.RowTemplate.Height = 23;
            this.grdUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdUser.Size = new System.Drawing.Size(884, 478);
            this.grdUser.TabIndex = 8;
            this.grdUser.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdUser_CellDoubleClick);
            this.grdUser.SelectionChanged += new System.EventHandler(this.grdUser_SelectionChanged);
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "Selected";
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.IndeterminateValue = "False";
            this.colSelected.Name = "colSelected";
            this.colSelected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSelected.Width = 50;
            // 
            // colUserName
            // 
            this.colUserName.DataPropertyName = "UserName";
            this.colUserName.HeaderText = "用户名";
            this.colUserName.Name = "colUserName";
            this.colUserName.ReadOnly = true;
            // 
            // colRealName
            // 
            this.colRealName.DataPropertyName = "RealName";
            this.colRealName.FillWeight = 70F;
            this.colRealName.HeaderText = "姓名";
            this.colRealName.MaxInputLength = 200;
            this.colRealName.Name = "colRealName";
            this.colRealName.ReadOnly = true;
            this.colRealName.Width = 70;
            // 
            // colRole
            // 
            this.colRole.DataPropertyName = "RoleName";
            this.colRole.FillWeight = 120F;
            this.colRole.HeaderText = "默认角色";
            this.colRole.Name = "colRole";
            this.colRole.ReadOnly = true;
            this.colRole.Width = 120;
            // 
            // colDepartmentName
            // 
            this.colDepartmentName.DataPropertyName = "DepartmentName";
            this.colDepartmentName.FillWeight = 200F;
            this.colDepartmentName.HeaderText = "部门";
            this.colDepartmentName.MaxInputLength = 200;
            this.colDepartmentName.Name = "colDepartmentName";
            this.colDepartmentName.ReadOnly = true;
            this.colDepartmentName.Width = 200;
            // 
            // colEnabled
            // 
            this.colEnabled.DataPropertyName = "Enabled";
            this.colEnabled.FalseValue = "0";
            this.colEnabled.FillWeight = 80F;
            this.colEnabled.HeaderText = "有效";
            this.colEnabled.Name = "colEnabled";
            this.colEnabled.ReadOnly = true;
            this.colEnabled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEnabled.TrueValue = "1";
            this.colEnabled.Width = 80;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.FillWeight = 160F;
            this.colDescription.HeaderText = "描述";
            this.colDescription.MaxInputLength = 200;
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 160;
            // 
            // btnSetPassword
            // 
            this.btnSetPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetPassword.Enabled = false;
            this.btnSetPassword.Location = new System.Drawing.Point(531, 527);
            this.btnSetPassword.Name = "btnSetPassword";
            this.btnSetPassword.Size = new System.Drawing.Size(110, 23);
            this.btnSetPassword.TabIndex = 11;
            this.btnSetPassword.Text = "设置密码(&S)...";
            this.btnSetPassword.Click += new System.EventHandler(this.btnSetPassword_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(1014, 527);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnProperty
            // 
            this.btnProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProperty.Enabled = false;
            this.btnProperty.Location = new System.Drawing.Point(449, 527);
            this.btnProperty.Name = "btnProperty";
            this.btnProperty.Size = new System.Drawing.Size(80, 23);
            this.btnProperty.TabIndex = 10;
            this.btnProperty.Text = "属性(&O)...";
            this.btnProperty.Click += new System.EventHandler(this.btnProperty_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(937, 527);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(372, 527);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "添加(&A)...";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnPermission
            // 
            this.btnPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPermission.Enabled = false;
            this.btnPermission.Location = new System.Drawing.Point(742, 527);
            this.btnPermission.Name = "btnPermission";
            this.btnPermission.Size = new System.Drawing.Size(80, 23);
            this.btnPermission.TabIndex = 13;
            this.btnPermission.Text = "权限(&P)...";
            this.btnPermission.Click += new System.EventHandler(this.btnPermission_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(3, 8);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(83, 12);
            this.lblSearch.TabIndex = 4;
            this.lblSearch.Text = "查询内容(&C)：";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(92, 3);
            this.txtSearch.MaxLength = 20;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(111, 21);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(209, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "查询(&F)";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(824, 527);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(111, 23);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "导出E&xcel...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // chkEnabled
            // 
            this.chkEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(8, 530);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(96, 16);
            this.chkEnabled.TabIndex = 7;
            this.chkEnabled.Text = "只显示有效的";
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.CheckedChanged += new System.EventHandler(this.chkEnabled_CheckedChanged);
            // 
            // btnUserRole
            // 
            this.btnUserRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserRole.Enabled = false;
            this.btnUserRole.Location = new System.Drawing.Point(643, 527);
            this.btnUserRole.Name = "btnUserRole";
            this.btnUserRole.Size = new System.Drawing.Size(97, 23);
            this.btnUserRole.TabIndex = 12;
            this.btnUserRole.Text = "用户角色(&R)...";
            this.btnUserRole.UseVisualStyleBackColor = true;
            this.btnUserRole.Click += new System.EventHandler(this.btnUserRole_Click);
            // 
            // btnUserOrganizeScope
            // 
            this.btnUserOrganizeScope.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserOrganizeScope.AutoSize = true;
            this.btnUserOrganizeScope.Enabled = false;
            this.btnUserOrganizeScope.Location = new System.Drawing.Point(268, 3);
            this.btnUserOrganizeScope.Name = "btnUserOrganizeScope";
            this.btnUserOrganizeScope.Size = new System.Drawing.Size(125, 23);
            this.btnUserOrganizeScope.TabIndex = 1;
            this.btnUserOrganizeScope.Text = "用户管理范围...";
            this.btnUserOrganizeScope.UseVisualStyleBackColor = true;
            this.btnUserOrganizeScope.Click += new System.EventHandler(this.btnUserOrganizeScope_Click);
            // 
            // btnBatchPermission
            // 
            this.btnBatchPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchPermission.AutoSize = true;
            this.btnBatchPermission.Enabled = false;
            this.btnBatchPermission.Location = new System.Drawing.Point(139, 3);
            this.btnBatchPermission.Name = "btnBatchPermission";
            this.btnBatchPermission.Size = new System.Drawing.Size(123, 23);
            this.btnBatchPermission.TabIndex = 2;
            this.btnBatchPermission.Text = "批量设置权限...";
            this.btnBatchPermission.UseVisualStyleBackColor = true;
            this.btnBatchPermission.Click += new System.EventHandler(this.btnBatchPermission_Click);
            // 
            // btnRoleUserBatchSet
            // 
            this.btnRoleUserBatchSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRoleUserBatchSet.AutoSize = true;
            this.btnRoleUserBatchSet.Enabled = false;
            this.btnRoleUserBatchSet.Location = new System.Drawing.Point(5, 3);
            this.btnRoleUserBatchSet.Name = "btnRoleUserBatchSet";
            this.btnRoleUserBatchSet.Size = new System.Drawing.Size(128, 23);
            this.btnRoleUserBatchSet.TabIndex = 3;
            this.btnRoleUserBatchSet.Text = "用户角色关联...";
            this.btnRoleUserBatchSet.UseVisualStyleBackColor = true;
            this.btnRoleUserBatchSet.Click += new System.EventHandler(this.btnRoleUserBatchSet_Click);
            // 
            // btnUseAuthorizationScope
            // 
            this.btnUseAuthorizationScope.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUseAuthorizationScope.AutoSize = true;
            this.btnUseAuthorizationScope.Enabled = false;
            this.btnUseAuthorizationScope.Location = new System.Drawing.Point(656, 3);
            this.btnUseAuthorizationScope.Name = "btnUseAuthorizationScope";
            this.btnUseAuthorizationScope.Size = new System.Drawing.Size(125, 23);
            this.btnUseAuthorizationScope.TabIndex = 0;
            this.btnUseAuthorizationScope.Text = "用户授权范围...";
            this.btnUseAuthorizationScope.UseVisualStyleBackColor = true;
            this.btnUseAuthorizationScope.Click += new System.EventHandler(this.btnFrmUseAuthorizationScope_Click);
            // 
            // btnFrmUserTableScope
            // 
            this.btnFrmUserTableScope.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFrmUserTableScope.AutoSize = true;
            this.btnFrmUserTableScope.Enabled = false;
            this.btnFrmUserTableScope.Location = new System.Drawing.Point(540, 3);
            this.btnFrmUserTableScope.Name = "btnFrmUserTableScope";
            this.btnFrmUserTableScope.Size = new System.Drawing.Size(110, 23);
            this.btnFrmUserTableScope.TabIndex = 17;
            this.btnFrmUserTableScope.Text = "约束条件...";
            this.btnFrmUserTableScope.UseVisualStyleBackColor = true;
            this.btnFrmUserTableScope.Click += new System.EventHandler(this.btnFrmUserTableScope_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnUseAuthorizationScope);
            this.flowLayoutPanel1.Controls.Add(this.btnFrmUserTableScope);
            this.flowLayoutPanel1.Controls.Add(this.btnFrmTableColumnPermission);
            this.flowLayoutPanel1.Controls.Add(this.btnUserOrganizeScope);
            this.flowLayoutPanel1.Controls.Add(this.btnBatchPermission);
            this.flowLayoutPanel1.Controls.Add(this.btnRoleUserBatchSet);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(310, 1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(784, 30);
            this.flowLayoutPanel1.TabIndex = 18;
            // 
            // btnFrmTableColumnPermission
            // 
            this.btnFrmTableColumnPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFrmTableColumnPermission.AutoSize = true;
            this.btnFrmTableColumnPermission.Enabled = false;
            this.btnFrmTableColumnPermission.Location = new System.Drawing.Point(399, 3);
            this.btnFrmTableColumnPermission.Name = "btnFrmTableColumnPermission";
            this.btnFrmTableColumnPermission.Size = new System.Drawing.Size(135, 23);
            this.btnFrmTableColumnPermission.TabIndex = 20;
            this.btnFrmTableColumnPermission.Text = "表字段权限...";
            this.btnFrmTableColumnPermission.UseVisualStyleBackColor = true;
            this.btnFrmTableColumnPermission.Click += new System.EventHandler(this.btnFrmTableColumnPermission_Click);
            // 
            // splUser
            // 
            this.splUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splUser.Location = new System.Drawing.Point(9, 40);
            this.splUser.Name = "splUser";
            // 
            // splUser.Panel1
            // 
            this.splUser.Panel1.Controls.Add(this.tvOrganize);
            this.splUser.Panel1MinSize = 0;
            // 
            // splUser.Panel2
            // 
            this.splUser.Panel2.Controls.Add(this.grdUser);
            this.splUser.Panel2MinSize = 0;
            this.splUser.Size = new System.Drawing.Size(1083, 478);
            this.splUser.SplitterDistance = 195;
            this.splUser.TabIndex = 19;
            // 
            // tvOrganize
            // 
            this.tvOrganize.AllowDrop = true;
            this.tvOrganize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvOrganize.ImageIndex = 0;
            this.tvOrganize.ImageList = this.imageList;
            this.tvOrganize.Location = new System.Drawing.Point(0, 0);
            this.tvOrganize.Name = "tvOrganize";
            this.tvOrganize.SelectedImageIndex = 0;
            this.tvOrganize.Size = new System.Drawing.Size(195, 478);
            this.tvOrganize.TabIndex = 20;
            this.tvOrganize.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOrganize_AfterSelect);
            this.tvOrganize.Click += new System.EventHandler(this.tvOrganize_Click);
            this.tvOrganize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvOrganize_MouseDown);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "");
            this.imageList.Images.SetKeyName(1, "");
            this.imageList.Images.SetKeyName(2, "");
            this.imageList.Images.SetKeyName(3, "");
            this.imageList.Images.SetKeyName(4, "");
            this.imageList.Images.SetKeyName(5, "");
            this.imageList.Images.SetKeyName(6, "");
            this.imageList.Images.SetKeyName(7, "");
            this.imageList.Images.SetKeyName(8, "");
            this.imageList.Images.SetKeyName(9, "");
            this.imageList.Images.SetKeyName(10, "");
            this.imageList.Images.SetKeyName(11, "");
            this.imageList.Images.SetKeyName(12, "");
            this.imageList.Images.SetKeyName(13, "");
            this.imageList.Images.SetKeyName(14, "");
            this.imageList.Images.SetKeyName(15, "icon_messenger1.gif");
            this.imageList.Images.SetKeyName(16, "icon_messenger0.gif");
            this.imageList.Images.SetKeyName(17, "icon_messenger2.gif");
            this.imageList.Images.SetKeyName(18, "icon_messenger3.gif");
            this.imageList.Images.SetKeyName(19, "icon_messenger4.gif");
            this.imageList.Images.SetKeyName(20, "icon_messenger5.gif");
            this.imageList.Images.SetKeyName(21, "icon_messenger6.gif");
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lblSearch);
            this.flowLayoutPanel2.Controls.Add(this.txtSearch);
            this.flowLayoutPanel2.Controls.Add(this.btnSearch);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(8, 1);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(295, 29);
            this.flowLayoutPanel2.TabIndex = 20;
            // 
            // FrmUserPermissionAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1098, 554);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.splUser);
            this.Controls.Add(this.btnUserRole);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnPermission);
            this.Controls.Add(this.btnSetPassword);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnProperty);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmUserPermissionAdmin";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "用户权限管理";
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.splUser.Panel1.ResumeLayout(false);
            this.splUser.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splUser)).EndInit();
            this.splUser.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HelpProvider helpProvider;
        private System.Windows.Forms.DataGridView grdUser;
        private System.Windows.Forms.Button btnSetPassword;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnProperty;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnPermission;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Button btnUserRole;
        private System.Windows.Forms.Button btnUserOrganizeScope;
        private System.Windows.Forms.Button btnBatchPermission;
        private System.Windows.Forms.Button btnRoleUserBatchSet;
        private System.Windows.Forms.Button btnUseAuthorizationScope;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartmentName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.Button btnFrmUserTableScope;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnFrmTableColumnPermission;
        private System.Windows.Forms.SplitContainer splUser;
        private System.Windows.Forms.TreeView tvOrganize;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}