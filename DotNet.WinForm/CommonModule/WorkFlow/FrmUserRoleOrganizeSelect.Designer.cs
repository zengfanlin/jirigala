namespace DotNet.WinForm
{
    partial class FrmUserRoleOrganizeSelect
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserRoleOrganizeSelect));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbcSelect = new System.Windows.Forms.TabControl();
            this.tbpOrganize = new System.Windows.Forms.TabPage();
            this.tcOrganizeTree = new System.Windows.Forms.TabControl();
            this.tpOrganizeTree = new System.Windows.Forms.TabPage();
            this.tvOrganize = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tpOrganizeList = new System.Windows.Forms.TabPage();
            this.grdOrganize = new System.Windows.Forms.DataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsInnerOrganize = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblContents = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbpRole = new System.Windows.Forms.TabPage();
            this.cmbRoleCategory = new System.Windows.Forms.ComboBox();
            this.lblRoleCategroy = new System.Windows.Forms.Label();
            this.grdRole = new System.Windows.Forms.DataGridView();
            this.colSelected1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colFullName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbpUser = new System.Windows.Forms.TabPage();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.lblRoleCategories = new System.Windows.Forms.Label();
            this.grdUser = new System.Windows.Forms.DataGridView();
            this.colSelected2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch1 = new System.Windows.Forms.TextBox();
            this.btnSearch1 = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnSetNull = new System.Windows.Forms.Button();
            this.flpControl = new System.Windows.Forms.FlowLayoutPanel();
            this.btnInvertSelect = new System.Windows.Forms.Button();
            this.chkInnerOrganize = new System.Windows.Forms.CheckBox();
            this.tbcSelect.SuspendLayout();
            this.tbpOrganize.SuspendLayout();
            this.tcOrganizeTree.SuspendLayout();
            this.tpOrganizeTree.SuspendLayout();
            this.tpOrganizeList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrganize)).BeginInit();
            this.tbpRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRole)).BeginInit();
            this.tbpUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).BeginInit();
            this.flpControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcSelect
            // 
            this.tbcSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcSelect.Controls.Add(this.tbpOrganize);
            this.tbcSelect.Controls.Add(this.tbpRole);
            this.tbcSelect.Controls.Add(this.tbpUser);
            this.tbcSelect.Location = new System.Drawing.Point(10, 12);
            this.tbcSelect.Name = "tbcSelect";
            this.tbcSelect.SelectedIndex = 0;
            this.tbcSelect.Size = new System.Drawing.Size(918, 561);
            this.tbcSelect.TabIndex = 0;
            this.tbcSelect.SelectedIndexChanged += new System.EventHandler(this.tbcSelect_SelectedIndexChanged);
            // 
            // tbpOrganize
            // 
            this.tbpOrganize.Controls.Add(this.tcOrganizeTree);
            this.tbpOrganize.Location = new System.Drawing.Point(4, 22);
            this.tbpOrganize.Name = "tbpOrganize";
            this.tbpOrganize.Padding = new System.Windows.Forms.Padding(3);
            this.tbpOrganize.Size = new System.Drawing.Size(910, 535);
            this.tbpOrganize.TabIndex = 0;
            this.tbpOrganize.Text = "组织机构选择";
            this.tbpOrganize.UseVisualStyleBackColor = true;
            // 
            // tcOrganizeTree
            // 
            this.tcOrganizeTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcOrganizeTree.Controls.Add(this.tpOrganizeTree);
            this.tcOrganizeTree.Controls.Add(this.tpOrganizeList);
            this.tcOrganizeTree.Location = new System.Drawing.Point(6, 6);
            this.tcOrganizeTree.Name = "tcOrganizeTree";
            this.tcOrganizeTree.SelectedIndex = 0;
            this.tcOrganizeTree.Size = new System.Drawing.Size(898, 523);
            this.tcOrganizeTree.TabIndex = 23;
            this.tcOrganizeTree.SelectedIndexChanged += new System.EventHandler(this.tcOrganizeTree_SelectedIndexChanged);
            // 
            // tpOrganizeTree
            // 
            this.tpOrganizeTree.Controls.Add(this.tvOrganize);
            this.tpOrganizeTree.Location = new System.Drawing.Point(4, 22);
            this.tpOrganizeTree.Name = "tpOrganizeTree";
            this.tpOrganizeTree.Padding = new System.Windows.Forms.Padding(3);
            this.tpOrganizeTree.Size = new System.Drawing.Size(890, 497);
            this.tpOrganizeTree.TabIndex = 0;
            this.tpOrganizeTree.Text = "组织机构";
            this.tpOrganizeTree.UseVisualStyleBackColor = true;
            // 
            // tvOrganize
            // 
            this.tvOrganize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvOrganize.HotTracking = true;
            this.tvOrganize.ImageIndex = 0;
            this.tvOrganize.ImageList = this.imageList;
            this.tvOrganize.Location = new System.Drawing.Point(6, 6);
            this.tvOrganize.Name = "tvOrganize";
            this.tvOrganize.SelectedImageIndex = 1;
            this.tvOrganize.Size = new System.Drawing.Size(878, 485);
            this.tvOrganize.TabIndex = 2;
            this.tvOrganize.Click += new System.EventHandler(this.tvOrganize_Click);
            this.tvOrganize.DoubleClick += new System.EventHandler(this.tvOrganize_DoubleClick);
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
            // tpOrganizeList
            // 
            this.tpOrganizeList.Controls.Add(this.grdOrganize);
            this.tpOrganizeList.Controls.Add(this.lblContents);
            this.tpOrganizeList.Controls.Add(this.txtSearch);
            this.tpOrganizeList.Controls.Add(this.btnSearch);
            this.tpOrganizeList.Location = new System.Drawing.Point(4, 22);
            this.tpOrganizeList.Name = "tpOrganizeList";
            this.tpOrganizeList.Padding = new System.Windows.Forms.Padding(3);
            this.tpOrganizeList.Size = new System.Drawing.Size(890, 497);
            this.tpOrganizeList.TabIndex = 1;
            this.tpOrganizeList.Text = "查询";
            this.tpOrganizeList.UseVisualStyleBackColor = true;
            // 
            // grdOrganize
            // 
            this.grdOrganize.AllowUserToAddRows = false;
            this.grdOrganize.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.grdOrganize.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdOrganize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdOrganize.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdOrganize.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdOrganize.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdOrganize.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colCode,
            this.colFullName,
            this.colIsInnerOrganize,
            this.colDescription});
            this.grdOrganize.Location = new System.Drawing.Point(6, 35);
            this.grdOrganize.MultiSelect = false;
            this.grdOrganize.Name = "grdOrganize";
            this.grdOrganize.RowTemplate.Height = 23;
            this.grdOrganize.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdOrganize.Size = new System.Drawing.Size(878, 456);
            this.grdOrganize.TabIndex = 16;
            this.grdOrganize.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdOrganize_CellDoubleClick);
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
            this.colCode.Frozen = true;
            this.colCode.HeaderText = "编号";
            this.colCode.MaxInputLength = 20;
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            // 
            // colFullName
            // 
            this.colFullName.DataPropertyName = "FullName";
            this.colFullName.FillWeight = 170F;
            this.colFullName.HeaderText = "名称";
            this.colFullName.MaxInputLength = 100;
            this.colFullName.Name = "colFullName";
            this.colFullName.ReadOnly = true;
            this.colFullName.Width = 170;
            // 
            // colIsInnerOrganize
            // 
            this.colIsInnerOrganize.DataPropertyName = "IsInnerOrganize";
            this.colIsInnerOrganize.FalseValue = "0";
            this.colIsInnerOrganize.HeaderText = "内部组织";
            this.colIsInnerOrganize.Name = "colIsInnerOrganize";
            this.colIsInnerOrganize.ReadOnly = true;
            this.colIsInnerOrganize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsInnerOrganize.TrueValue = "1";
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "描述";
            this.colDescription.MaxInputLength = 200;
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 170;
            // 
            // lblContents
            // 
            this.lblContents.Location = new System.Drawing.Point(10, 11);
            this.lblContents.Name = "lblContents";
            this.lblContents.Size = new System.Drawing.Size(74, 12);
            this.lblContents.TabIndex = 13;
            this.lblContents.Text = "查询内容(&C)：";
            this.lblContents.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(99, 7);
            this.txtSearch.MaxLength = 20;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(203, 21);
            this.txtSearch.TabIndex = 14;
            this.txtSearch.Click += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(307, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "查询(&F)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbpRole
            // 
            this.tbpRole.Controls.Add(this.cmbRoleCategory);
            this.tbpRole.Controls.Add(this.lblRoleCategroy);
            this.tbpRole.Controls.Add(this.grdRole);
            this.tbpRole.Location = new System.Drawing.Point(4, 22);
            this.tbpRole.Name = "tbpRole";
            this.tbpRole.Padding = new System.Windows.Forms.Padding(3);
            this.tbpRole.Size = new System.Drawing.Size(910, 535);
            this.tbpRole.TabIndex = 1;
            this.tbpRole.Text = "角色选择";
            this.tbpRole.UseVisualStyleBackColor = true;
            // 
            // cmbRoleCategory
            // 
            this.cmbRoleCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRoleCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoleCategory.Location = new System.Drawing.Point(576, 5);
            this.cmbRoleCategory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbRoleCategory.Name = "cmbRoleCategory";
            this.cmbRoleCategory.Size = new System.Drawing.Size(326, 20);
            this.cmbRoleCategory.TabIndex = 4;
            this.cmbRoleCategory.SelectedIndexChanged += new System.EventHandler(this.cmbRoleCategory_SelectedIndexChanged);
            // 
            // lblRoleCategroy
            // 
            this.lblRoleCategroy.Location = new System.Drawing.Point(483, 8);
            this.lblRoleCategroy.Name = "lblRoleCategroy";
            this.lblRoleCategroy.Size = new System.Drawing.Size(88, 12);
            this.lblRoleCategroy.TabIndex = 3;
            this.lblRoleCategroy.Text = "角色分类：";
            this.lblRoleCategroy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grdRole
            // 
            this.grdRole.AllowUserToAddRows = false;
            this.grdRole.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.grdRole.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdRole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdRole.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdRole.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdRole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRole.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected1,
            this.colFullName1,
            this.colDescription1});
            this.grdRole.Location = new System.Drawing.Point(6, 31);
            this.grdRole.MultiSelect = false;
            this.grdRole.Name = "grdRole";
            this.grdRole.RowTemplate.Height = 23;
            this.grdRole.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdRole.Size = new System.Drawing.Size(896, 496);
            this.grdRole.TabIndex = 5;
            this.grdRole.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdRole_CellDoubleClick);
            // 
            // colSelected1
            // 
            this.colSelected1.DataPropertyName = "Selected";
            this.colSelected1.Frozen = true;
            this.colSelected1.HeaderText = "选择";
            this.colSelected1.Name = "colSelected1";
            this.colSelected1.Width = 50;
            // 
            // colFullName1
            // 
            this.colFullName1.DataPropertyName = "RealName";
            this.colFullName1.HeaderText = "名称";
            this.colFullName1.Name = "colFullName1";
            this.colFullName1.ReadOnly = true;
            this.colFullName1.Width = 180;
            // 
            // colDescription1
            // 
            this.colDescription1.DataPropertyName = "Description";
            this.colDescription1.HeaderText = "描述";
            this.colDescription1.Name = "colDescription1";
            this.colDescription1.ReadOnly = true;
            this.colDescription1.Width = 250;
            // 
            // tbpUser
            // 
            this.tbpUser.Controls.Add(this.cmbRole);
            this.tbpUser.Controls.Add(this.lblRoleCategories);
            this.tbpUser.Controls.Add(this.grdUser);
            this.tbpUser.Controls.Add(this.lblSearch);
            this.tbpUser.Controls.Add(this.txtSearch1);
            this.tbpUser.Controls.Add(this.btnSearch1);
            this.tbpUser.Location = new System.Drawing.Point(4, 22);
            this.tbpUser.Name = "tbpUser";
            this.tbpUser.Padding = new System.Windows.Forms.Padding(3);
            this.tbpUser.Size = new System.Drawing.Size(910, 535);
            this.tbpUser.TabIndex = 2;
            this.tbpUser.Text = "用户选择";
            this.tbpUser.UseVisualStyleBackColor = true;
            // 
            // cmbRole
            // 
            this.cmbRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.Location = new System.Drawing.Point(699, 7);
            this.cmbRole.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(202, 20);
            this.cmbRole.TabIndex = 10;
            this.cmbRole.SelectedIndexChanged += new System.EventHandler(this.cmbRole_SelectedIndexChanged);
            // 
            // lblRoleCategories
            // 
            this.lblRoleCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRoleCategories.Location = new System.Drawing.Point(617, 11);
            this.lblRoleCategories.Name = "lblRoleCategories";
            this.lblRoleCategories.Size = new System.Drawing.Size(79, 12);
            this.lblRoleCategories.TabIndex = 9;
            this.lblRoleCategories.Text = "角色：";
            this.lblRoleCategories.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grdUser
            // 
            this.grdUser.AllowUserToAddRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.AliceBlue;
            this.grdUser.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grdUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdUser.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grdUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected2,
            this.colUserName,
            this.colRealName,
            this.colDepartment,
            this.colDescription2});
            this.grdUser.Location = new System.Drawing.Point(6, 36);
            this.grdUser.MultiSelect = false;
            this.grdUser.Name = "grdUser";
            this.grdUser.RowTemplate.Height = 23;
            this.grdUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdUser.Size = new System.Drawing.Size(896, 491);
            this.grdUser.TabIndex = 11;
            this.grdUser.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdUser_CellDoubleClick);
            // 
            // colSelected2
            // 
            this.colSelected2.DataPropertyName = "Selected";
            this.colSelected2.HeaderText = "选择";
            this.colSelected2.Name = "colSelected2";
            this.colSelected2.Width = 50;
            // 
            // colUserName
            // 
            this.colUserName.DataPropertyName = "UserName";
            this.colUserName.HeaderText = "用户名";
            this.colUserName.MaxInputLength = 20;
            this.colUserName.Name = "colUserName";
            this.colUserName.ReadOnly = true;
            this.colUserName.Width = 150;
            // 
            // colRealName
            // 
            this.colRealName.DataPropertyName = "RealName";
            this.colRealName.HeaderText = "姓名";
            this.colRealName.MaxInputLength = 20;
            this.colRealName.Name = "colRealName";
            this.colRealName.ReadOnly = true;
            // 
            // colDepartment
            // 
            this.colDepartment.DataPropertyName = "DepartmentName";
            this.colDepartment.HeaderText = "部门";
            this.colDepartment.MaxInputLength = 200;
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.ReadOnly = true;
            this.colDepartment.Width = 200;
            // 
            // colDescription2
            // 
            this.colDescription2.DataPropertyName = "Description";
            this.colDescription2.HeaderText = "描述";
            this.colDescription2.MaxInputLength = 200;
            this.colDescription2.Name = "colDescription2";
            this.colDescription2.ReadOnly = true;
            this.colDescription2.Width = 150;
            // 
            // lblSearch
            // 
            this.lblSearch.Location = new System.Drawing.Point(9, 12);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(86, 12);
            this.lblSearch.TabIndex = 6;
            this.lblSearch.Text = "查询内容(&C)：";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearch1
            // 
            this.txtSearch1.Location = new System.Drawing.Point(96, 8);
            this.txtSearch1.MaxLength = 20;
            this.txtSearch1.Name = "txtSearch1";
            this.txtSearch1.Size = new System.Drawing.Size(171, 21);
            this.txtSearch1.TabIndex = 7;
            this.txtSearch1.TextChanged += new System.EventHandler(this.txtSearch1_TextChanged);
            // 
            // btnSearch1
            // 
            this.btnSearch1.Location = new System.Drawing.Point(270, 7);
            this.btnSearch1.Name = "btnSearch1";
            this.btnSearch1.Size = new System.Drawing.Size(75, 23);
            this.btnSearch1.TabIndex = 8;
            this.btnSearch1.Text = "查询(&F)";
            this.btnSearch1.UseVisualStyleBackColor = true;
            this.btnSearch1.Click += new System.EventHandler(this.btnSearch1_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Enabled = false;
            this.btnSelectAll.Location = new System.Drawing.Point(8, 581);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(78, 23);
            this.btnSelectAll.TabIndex = 20;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(272, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(191, 3);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 9;
            this.btnSelect.Text = "添加";
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(110, 3);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 10;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnSetNull
            // 
            this.btnSetNull.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetNull.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSetNull.Enabled = false;
            this.btnSetNull.Location = new System.Drawing.Point(19, 3);
            this.btnSetNull.Name = "btnSetNull";
            this.btnSetNull.Size = new System.Drawing.Size(85, 23);
            this.btnSetNull.TabIndex = 8;
            this.btnSetNull.Text = "置空(&N)";
            this.btnSetNull.UseVisualStyleBackColor = true;
            this.btnSetNull.Click += new System.EventHandler(this.btnSetNull_Click);
            // 
            // flpControl
            // 
            this.flpControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flpControl.Controls.Add(this.btnCancel);
            this.flpControl.Controls.Add(this.btnSelect);
            this.flpControl.Controls.Add(this.btnConfirm);
            this.flpControl.Controls.Add(this.btnSetNull);
            this.flpControl.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpControl.Location = new System.Drawing.Point(580, 578);
            this.flpControl.Name = "flpControl";
            this.flpControl.Size = new System.Drawing.Size(350, 30);
            this.flpControl.TabIndex = 22;
            // 
            // btnInvertSelect
            // 
            this.btnInvertSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvertSelect.Enabled = false;
            this.btnInvertSelect.Location = new System.Drawing.Point(93, 581);
            this.btnInvertSelect.Name = "btnInvertSelect";
            this.btnInvertSelect.Size = new System.Drawing.Size(78, 23);
            this.btnInvertSelect.TabIndex = 21;
            this.btnInvertSelect.Text = "反选";
            this.btnInvertSelect.UseVisualStyleBackColor = true;
            // 
            // chkInnerOrganize
            // 
            this.chkInnerOrganize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkInnerOrganize.AutoSize = true;
            this.chkInnerOrganize.Checked = true;
            this.chkInnerOrganize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInnerOrganize.Location = new System.Drawing.Point(798, 10);
            this.chkInnerOrganize.Name = "chkInnerOrganize";
            this.chkInnerOrganize.Size = new System.Drawing.Size(132, 16);
            this.chkInnerOrganize.TabIndex = 27;
            this.chkInnerOrganize.Text = "仅显示内部组织机构";
            this.chkInnerOrganize.UseVisualStyleBackColor = true;
            this.chkInnerOrganize.CheckedChanged += new System.EventHandler(this.chkInnerOrganize_CheckedChanged);
            // 
            // FrmUserRoleOrganizeSelect
            // 
            this.ClientSize = new System.Drawing.Size(936, 612);
            this.Controls.Add(this.chkInnerOrganize);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.flpControl);
            this.Controls.Add(this.btnInvertSelect);
            this.Controls.Add(this.tbcSelect);
            this.Name = "FrmUserRoleOrganizeSelect";
            this.Text = "选择";
            this.tbcSelect.ResumeLayout(false);
            this.tbpOrganize.ResumeLayout(false);
            this.tcOrganizeTree.ResumeLayout(false);
            this.tpOrganizeTree.ResumeLayout(false);
            this.tpOrganizeList.ResumeLayout(false);
            this.tpOrganizeList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrganize)).EndInit();
            this.tbpRole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRole)).EndInit();
            this.tbpUser.ResumeLayout(false);
            this.tbpUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).EndInit();
            this.flpControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tbcSelect;
        private System.Windows.Forms.TabPage tbpOrganize;
        private System.Windows.Forms.TabPage tbpRole;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnSetNull;
        private System.Windows.Forms.FlowLayoutPanel flpControl;
        private System.Windows.Forms.Button btnInvertSelect;
        private System.Windows.Forms.TabPage tbpUser;
        private System.Windows.Forms.TabControl tcOrganizeTree;
        private System.Windows.Forms.TabPage tpOrganizeList;
        private System.Windows.Forms.DataGridView grdOrganize;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsInnerOrganize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.Label lblContents;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox chkInnerOrganize;
        private System.Windows.Forms.ComboBox cmbRoleCategory;
        private System.Windows.Forms.Label lblRoleCategroy;
        private System.Windows.Forms.DataGridView grdRole;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblRoleCategories;
        private System.Windows.Forms.DataGridView grdUser;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch1;
        private System.Windows.Forms.Button btnSearch1;
        private System.Windows.Forms.TabPage tpOrganizeTree;
        private System.Windows.Forms.TreeView tvOrganize;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription2;
        private System.Windows.Forms.ImageList imageList;
    }
}
