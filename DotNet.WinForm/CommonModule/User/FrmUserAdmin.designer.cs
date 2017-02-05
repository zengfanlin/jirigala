namespace DotNet.WinForm
{
    partial class FrmUserAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserAdmin));
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.grdUser = new System.Windows.Forms.DataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDefaultRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSetPassword = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnProperty = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblContents = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.ucTableSort = new DotNet.WinForm.UCTableSort();
            this.btnBatchSave = new System.Windows.Forms.Button();
            this.btnRoleUser = new System.Windows.Forms.Button();
            this.picBug = new System.Windows.Forms.PictureBox();
            this.picSetting = new System.Windows.Forms.PictureBox();
            this.picImport = new System.Windows.Forms.PictureBox();
            this.picExport = new System.Windows.Forms.PictureBox();
            this.btnInvertSelect = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnSetOrganize = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.splUser = new System.Windows.Forms.SplitContainer();
            this.tvOrganize = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splUser)).BeginInit();
            this.splUser.Panel1.SuspendLayout();
            this.splUser.Panel2.SuspendLayout();
            this.splUser.SuspendLayout();
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
            this.colCode,
            this.colRealName,
            this.colDepartment,
            this.colEmail,
            this.colTelephone,
            this.colMobile,
            this.colDefaultRole,
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
            this.grdUser.Size = new System.Drawing.Size(741, 511);
            this.grdUser.TabIndex = 4;
            this.grdUser.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdUser_CellDoubleClick);
            this.grdUser.Sorted += new System.EventHandler(this.grdUser_Sorted);
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
            // colUserName
            // 
            this.colUserName.DataPropertyName = "UserName";
            this.colUserName.HeaderText = "用户名";
            this.colUserName.Name = "colUserName";
            this.colUserName.ReadOnly = true;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            this.colCode.HeaderText = "工号";
            this.colCode.MaxInputLength = 100;
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
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
            // colDepartment
            // 
            this.colDepartment.DataPropertyName = "DepartmentName";
            this.colDepartment.FillWeight = 200F;
            this.colDepartment.HeaderText = "部门";
            this.colDepartment.MaxInputLength = 200;
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.ReadOnly = true;
            this.colDepartment.Width = 200;
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "Email";
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            // 
            // colTelephone
            // 
            this.colTelephone.DataPropertyName = "Telephone";
            this.colTelephone.HeaderText = "电话";
            this.colTelephone.Name = "colTelephone";
            // 
            // colMobile
            // 
            this.colMobile.DataPropertyName = "Mobile";
            this.colMobile.HeaderText = "手机";
            this.colMobile.Name = "colMobile";
            // 
            // colDefaultRole
            // 
            this.colDefaultRole.DataPropertyName = "RoleName";
            this.colDefaultRole.HeaderText = "默认角色";
            this.colDefaultRole.Name = "colDefaultRole";
            this.colDefaultRole.ReadOnly = true;
            // 
            // colEnabled
            // 
            this.colEnabled.DataPropertyName = "Enabled";
            this.colEnabled.FalseValue = "0";
            this.colEnabled.FillWeight = 80F;
            this.colEnabled.HeaderText = "有效";
            this.colEnabled.Name = "colEnabled";
            this.colEnabled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEnabled.TrueValue = "1";
            this.colEnabled.Width = 80;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.FillWeight = 135F;
            this.colDescription.HeaderText = "描述";
            this.colDescription.MaxInputLength = 200;
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 135;
            // 
            // btnSetPassword
            // 
            this.btnSetPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetPassword.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSetPassword.Enabled = false;
            this.btnSetPassword.Location = new System.Drawing.Point(517, 563);
            this.btnSetPassword.Name = "btnSetPassword";
            this.btnSetPassword.Size = new System.Drawing.Size(108, 23);
            this.btnSetPassword.TabIndex = 7;
            this.btnSetPassword.Text = "重置密码(&P)...";
            this.btnSetPassword.Click += new System.EventHandler(this.btnSetPassword_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(885, 563);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnProperty
            // 
            this.btnProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProperty.Enabled = false;
            this.btnProperty.Location = new System.Drawing.Point(434, 563);
            this.btnProperty.Name = "btnProperty";
            this.btnProperty.Size = new System.Drawing.Size(80, 23);
            this.btnProperty.TabIndex = 6;
            this.btnProperty.Text = "属性(&O)...";
            this.btnProperty.Click += new System.EventHandler(this.btnProperty_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(729, 563);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(356, 563);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "添加(&A)...";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblContents
            // 
            this.lblContents.Location = new System.Drawing.Point(21, 16);
            this.lblContents.Name = "lblContents";
            this.lblContents.Size = new System.Drawing.Size(87, 12);
            this.lblContents.TabIndex = 0;
            this.lblContents.Text = "查询内容(&C)：";
            this.lblContents.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(112, 11);
            this.txtSearch.MaxLength = 20;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(168, 21);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(285, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询(&F)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(366, 16);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(96, 16);
            this.chkEnabled.TabIndex = 3;
            this.chkEnabled.Text = "只显示有效的";
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.CheckedChanged += new System.EventHandler(this.chkEnabled_CheckedChanged);
            // 
            // ucTableSort
            // 
            this.ucTableSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ucTableSort.Enabled = false;
            this.ucTableSort.Location = new System.Drawing.Point(167, 562);
            this.ucTableSort.Margin = new System.Windows.Forms.Padding(0);
            this.ucTableSort.Name = "ucTableSort";
            this.ucTableSort.OEntityId = null;
            this.ucTableSort.Padding = new System.Windows.Forms.Padding(1);
            this.ucTableSort.SetBottomEnabled = false;
            this.ucTableSort.SetDownEnabled = false;
            this.ucTableSort.SetTopEnabled = false;
            this.ucTableSort.SetUpEnabled = false;
            this.ucTableSort.Size = new System.Drawing.Size(99, 24);
            this.ucTableSort.TabIndex = 12;
            // 
            // btnBatchSave
            // 
            this.btnBatchSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchSave.Enabled = false;
            this.btnBatchSave.Location = new System.Drawing.Point(807, 563);
            this.btnBatchSave.Name = "btnBatchSave";
            this.btnBatchSave.Size = new System.Drawing.Size(75, 23);
            this.btnBatchSave.TabIndex = 10;
            this.btnBatchSave.Text = "保存(&S)";
            this.btnBatchSave.UseVisualStyleBackColor = true;
            this.btnBatchSave.Click += new System.EventHandler(this.btnBatchSave_Click);
            // 
            // btnRoleUser
            // 
            this.btnRoleUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRoleUser.Enabled = false;
            this.btnRoleUser.Location = new System.Drawing.Point(628, 563);
            this.btnRoleUser.Name = "btnRoleUser";
            this.btnRoleUser.Size = new System.Drawing.Size(98, 23);
            this.btnRoleUser.TabIndex = 8;
            this.btnRoleUser.Text = "角色关联...";
            this.btnRoleUser.UseVisualStyleBackColor = true;
            this.btnRoleUser.Click += new System.EventHandler(this.btnRoleUser_Click);
            // 
            // picBug
            // 
            this.picBug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBug.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBug.Image = ((System.Drawing.Image)(resources.GetObject("picBug.Image")));
            this.picBug.Location = new System.Drawing.Point(929, 5);
            this.picBug.Name = "picBug";
            this.picBug.Size = new System.Drawing.Size(30, 30);
            this.picBug.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBug.TabIndex = 14;
            this.picBug.TabStop = false;
            this.picBug.Click += new System.EventHandler(this.picBug_Click);
            // 
            // picSetting
            // 
            this.picSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSetting.Image = ((System.Drawing.Image)(resources.GetObject("picSetting.Image")));
            this.picSetting.Location = new System.Drawing.Point(897, 5);
            this.picSetting.Name = "picSetting";
            this.picSetting.Size = new System.Drawing.Size(30, 30);
            this.picSetting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSetting.TabIndex = 15;
            this.picSetting.TabStop = false;
            this.picSetting.Click += new System.EventHandler(this.picSetting_Click);
            // 
            // picImport
            // 
            this.picImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picImport.Image = ((System.Drawing.Image)(resources.GetObject("picImport.Image")));
            this.picImport.Location = new System.Drawing.Point(865, 5);
            this.picImport.Name = "picImport";
            this.picImport.Size = new System.Drawing.Size(30, 30);
            this.picImport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImport.TabIndex = 16;
            this.picImport.TabStop = false;
            this.picImport.Click += new System.EventHandler(this.picImport_Click);
            // 
            // picExport
            // 
            this.picExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picExport.Image = ((System.Drawing.Image)(resources.GetObject("picExport.Image")));
            this.picExport.Location = new System.Drawing.Point(833, 5);
            this.picExport.Name = "picExport";
            this.picExport.Size = new System.Drawing.Size(30, 30);
            this.picExport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picExport.TabIndex = 17;
            this.picExport.TabStop = false;
            this.picExport.Click += new System.EventHandler(this.picExport_Click);
            // 
            // btnInvertSelect
            // 
            this.btnInvertSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvertSelect.Enabled = false;
            this.btnInvertSelect.Location = new System.Drawing.Point(86, 562);
            this.btnInvertSelect.Name = "btnInvertSelect";
            this.btnInvertSelect.Size = new System.Drawing.Size(78, 23);
            this.btnInvertSelect.TabIndex = 20;
            this.btnInvertSelect.Text = "反选";
            this.btnInvertSelect.UseVisualStyleBackColor = true;
            this.btnInvertSelect.Click += new System.EventHandler(this.btnInvertSelect_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Enabled = false;
            this.btnSelectAll.Location = new System.Drawing.Point(5, 562);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(78, 23);
            this.btnSelectAll.TabIndex = 19;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnSetOrganize
            // 
            this.btnSetOrganize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetOrganize.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSetOrganize.Enabled = false;
            this.btnSetOrganize.Location = new System.Drawing.Point(714, 9);
            this.btnSetOrganize.Name = "btnSetOrganize";
            this.btnSetOrganize.Size = new System.Drawing.Size(113, 23);
            this.btnSetOrganize.TabIndex = 21;
            this.btnSetOrganize.Text = "设置部门...";
            this.btnSetOrganize.Click += new System.EventHandler(this.btnSetOrganize_Click);
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
            // splUser
            // 
            this.splUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splUser.Location = new System.Drawing.Point(6, 45);
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
            this.splUser.Size = new System.Drawing.Size(954, 511);
            this.splUser.SplitterDistance = 209;
            this.splUser.TabIndex = 22;
            // 
            // tvOrganize
            // 
            this.tvOrganize.AllowDrop = true;
            this.tvOrganize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvOrganize.ImageIndex = 0;
            this.tvOrganize.ImageList = this.imageList;
            this.tvOrganize.Location = new System.Drawing.Point(0, 0);
            this.tvOrganize.Name = "tvOrganize";
            this.tvOrganize.SelectedImageIndex = 1;
            this.tvOrganize.Size = new System.Drawing.Size(209, 511);
            this.tvOrganize.TabIndex = 1;
            this.tvOrganize.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOrganize_AfterSelect);
            this.tvOrganize.Click += new System.EventHandler(this.tvOrganize_Click);
            this.tvOrganize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvOrganize_MouseDown);
            // 
            // FrmUserAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(967, 590);
            this.Controls.Add(this.splUser);
            this.Controls.Add(this.btnSetOrganize);
            this.Controls.Add(this.btnInvertSelect);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.picExport);
            this.Controls.Add(this.picImport);
            this.Controls.Add(this.picSetting);
            this.Controls.Add(this.picBug);
            this.Controls.Add(this.btnRoleUser);
            this.Controls.Add(this.btnBatchSave);
            this.Controls.Add(this.ucTableSort);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblContents);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSetPassword);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnProperty);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmUserAdmin";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "用户管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmUserAdmin_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExport)).EndInit();
            this.splUser.Panel1.ResumeLayout(false);
            this.splUser.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splUser)).EndInit();
            this.splUser.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblContents;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox chkEnabled;
        private DotNet.WinForm.UCTableSort ucTableSort;
        private System.Windows.Forms.Button btnBatchSave;
        private System.Windows.Forms.Button btnRoleUser;
        private System.Windows.Forms.PictureBox picBug;
        private System.Windows.Forms.PictureBox picSetting;
        private System.Windows.Forms.PictureBox picImport;
        private System.Windows.Forms.PictureBox picExport;
        private System.Windows.Forms.Button btnInvertSelect;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDefaultRole;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.Button btnSetOrganize;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.SplitContainer splUser;
        private System.Windows.Forms.TreeView tvOrganize;
    }
}