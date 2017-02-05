namespace DotNet.WinForm
{
    partial class FrmOrganizePermissionAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOrganizePermissionAdmin));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.cMnuOrganize = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItmAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmMove = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmAddRoot = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mItmUserAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmStaffAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemRoleAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mItmOrganizeCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmFrmCodeBuilder = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmSetSortCode = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPermission = new System.Windows.Forms.Button();
            this.btnInvertSelect = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.chkInnerOrganize = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnRoleResourcePermission = new System.Windows.Forms.Button();
            this.btnUserResourcePermission = new System.Windows.Forms.Button();
            this.chkRefresh = new System.Windows.Forms.CheckBox();
            this.lblContents = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnBatchSave = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlOrganize = new System.Windows.Forms.Panel();
            this.grdOrganize = new System.Windows.Forms.DataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsInnerOrganize = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splOrganize = new System.Windows.Forms.Splitter();
            this.tvOrganize = new System.Windows.Forms.TreeView();
            this.btnBatchDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.ucTableSort = new DotNet.WinForm.UCTableSort();
            this.cMnuOrganize.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlOrganize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrganize)).BeginInit();
            this.SuspendLayout();
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
            // cMnuOrganize
            // 
            this.cMnuOrganize.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItmAdd,
            this.mItmEdit,
            this.mItmMove,
            this.mItmDelete,
            this.mItmAddRoot,
            this.toolStripSeparator1,
            this.mItmUserAdd,
            this.mItmStaffAdd,
            this.mItemRoleAdd,
            this.toolStripSeparator2,
            this.mItmOrganizeCategory,
            this.mItmFrmCodeBuilder,
            this.mItmSetSortCode});
            this.cMnuOrganize.Name = "cMnuModule";
            this.cMnuOrganize.Size = new System.Drawing.Size(182, 258);
            // 
            // mItmAdd
            // 
            this.mItmAdd.Enabled = false;
            this.mItmAdd.Name = "mItmAdd";
            this.mItmAdd.Size = new System.Drawing.Size(181, 22);
            this.mItmAdd.Text = "添加(&A)...";
            this.mItmAdd.Click += new System.EventHandler(this.mItmAdd_Click);
            // 
            // mItmEdit
            // 
            this.mItmEdit.Enabled = false;
            this.mItmEdit.Name = "mItmEdit";
            this.mItmEdit.Size = new System.Drawing.Size(181, 22);
            this.mItmEdit.Text = "编辑(&E)...";
            this.mItmEdit.Click += new System.EventHandler(this.mItmEdit_Click);
            // 
            // mItmMove
            // 
            this.mItmMove.Enabled = false;
            this.mItmMove.Name = "mItmMove";
            this.mItmMove.Size = new System.Drawing.Size(181, 22);
            this.mItmMove.Text = "移动(&M)...";
            this.mItmMove.Click += new System.EventHandler(this.mItmMove_Click);
            // 
            // mItmDelete
            // 
            this.mItmDelete.Enabled = false;
            this.mItmDelete.Name = "mItmDelete";
            this.mItmDelete.Size = new System.Drawing.Size(181, 22);
            this.mItmDelete.Text = "删除(&D)";
            this.mItmDelete.Click += new System.EventHandler(this.mItmDelete_Click);
            // 
            // mItmAddRoot
            // 
            this.mItmAddRoot.Enabled = false;
            this.mItmAddRoot.Name = "mItmAddRoot";
            this.mItmAddRoot.Size = new System.Drawing.Size(181, 22);
            this.mItmAddRoot.Text = "添加根组织机构...";
            this.mItmAddRoot.Click += new System.EventHandler(this.mItmAddRoot_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // mItmUserAdd
            // 
            this.mItmUserAdd.Enabled = false;
            this.mItmUserAdd.Name = "mItmUserAdd";
            this.mItmUserAdd.Size = new System.Drawing.Size(181, 22);
            this.mItmUserAdd.Text = "添加用户(&U)...";
            this.mItmUserAdd.Click += new System.EventHandler(this.mItmUserAdd_Click);
            // 
            // mItmStaffAdd
            // 
            this.mItmStaffAdd.Enabled = false;
            this.mItmStaffAdd.Name = "mItmStaffAdd";
            this.mItmStaffAdd.ShowShortcutKeys = false;
            this.mItmStaffAdd.Size = new System.Drawing.Size(181, 22);
            this.mItmStaffAdd.Text = "添加员工(&S)...";
            this.mItmStaffAdd.Click += new System.EventHandler(this.mItmAddStaff_Click);
            // 
            // mItemRoleAdd
            // 
            this.mItemRoleAdd.Enabled = false;
            this.mItemRoleAdd.Name = "mItemRoleAdd";
            this.mItemRoleAdd.Size = new System.Drawing.Size(181, 22);
            this.mItemRoleAdd.Text = "添加角色(&R)...";
            this.mItemRoleAdd.Visible = false;
            this.mItemRoleAdd.Click += new System.EventHandler(this.mItmAddRole_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // mItmOrganizeCategory
            // 
            this.mItmOrganizeCategory.Enabled = false;
            this.mItmOrganizeCategory.Name = "mItmOrganizeCategory";
            this.mItmOrganizeCategory.Size = new System.Drawing.Size(181, 22);
            this.mItmOrganizeCategory.Text = "组织机构类别维护...";
            this.mItmOrganizeCategory.Click += new System.EventHandler(this.mItmOrganizeCategory_Click);
            // 
            // mItmFrmCodeBuilder
            // 
            this.mItmFrmCodeBuilder.Enabled = false;
            this.mItmFrmCodeBuilder.Name = "mItmFrmCodeBuilder";
            this.mItmFrmCodeBuilder.Size = new System.Drawing.Size(181, 22);
            this.mItmFrmCodeBuilder.Text = "编号产生器设置...";
            this.mItmFrmCodeBuilder.Click += new System.EventHandler(this.mItmFrmOrganizeCodeBuilder_Click);
            // 
            // mItmSetSortCode
            // 
            this.mItmSetSortCode.Enabled = false;
            this.mItmSetSortCode.Name = "mItmSetSortCode";
            this.mItmSetSortCode.Size = new System.Drawing.Size(181, 22);
            this.mItmSetSortCode.Text = "保存排序顺序";
            this.mItmSetSortCode.Click += new System.EventHandler(this.mItmSetSortCode_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(884, 545);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPermission
            // 
            this.btnPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPermission.Location = new System.Drawing.Point(402, 545);
            this.btnPermission.Name = "btnPermission";
            this.btnPermission.Size = new System.Drawing.Size(75, 23);
            this.btnPermission.TabIndex = 24;
            this.btnPermission.Text = "权限(&P)...";
            this.btnPermission.Click += new System.EventHandler(this.btnPermission_Click);
            // 
            // btnInvertSelect
            // 
            this.btnInvertSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvertSelect.Enabled = false;
            this.btnInvertSelect.Location = new System.Drawing.Point(89, 545);
            this.btnInvertSelect.Name = "btnInvertSelect";
            this.btnInvertSelect.Size = new System.Drawing.Size(78, 23);
            this.btnInvertSelect.TabIndex = 23;
            this.btnInvertSelect.Text = "反选";
            this.btnInvertSelect.UseVisualStyleBackColor = true;
            this.btnInvertSelect.Click += new System.EventHandler(this.btnInvertSelect_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Enabled = false;
            this.btnSelectAll.Location = new System.Drawing.Point(6, 545);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(78, 23);
            this.btnSelectAll.TabIndex = 22;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // chkInnerOrganize
            // 
            this.chkInnerOrganize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkInnerOrganize.AutoSize = true;
            this.chkInnerOrganize.Checked = true;
            this.chkInnerOrganize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInnerOrganize.Location = new System.Drawing.Point(730, 38);
            this.chkInnerOrganize.Name = "chkInnerOrganize";
            this.chkInnerOrganize.Size = new System.Drawing.Size(132, 16);
            this.chkInnerOrganize.TabIndex = 6;
            this.chkInnerOrganize.Text = "仅显示内部组织机构";
            this.chkInnerOrganize.UseVisualStyleBackColor = true;
            this.chkInnerOrganize.CheckedChanged += new System.EventHandler(this.chkInnerOrganize_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnExport);
            this.flowLayoutPanel1.Controls.Add(this.btnRoleResourcePermission);
            this.flowLayoutPanel1.Controls.Add(this.btnUserResourcePermission);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(575, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(388, 29);
            this.flowLayoutPanel1.TabIndex = 16;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(265, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(120, 23);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "导出Excel...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnRoleResourcePermission
            // 
            this.btnRoleResourcePermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRoleResourcePermission.Enabled = false;
            this.btnRoleResourcePermission.Location = new System.Drawing.Point(139, 3);
            this.btnRoleResourcePermission.Name = "btnRoleResourcePermission";
            this.btnRoleResourcePermission.Size = new System.Drawing.Size(120, 23);
            this.btnRoleResourcePermission.TabIndex = 4;
            this.btnRoleResourcePermission.Text = "角色权限...";
            this.btnRoleResourcePermission.UseVisualStyleBackColor = true;
            this.btnRoleResourcePermission.Click += new System.EventHandler(this.btnRoleResourcePermission_Click);
            // 
            // btnUserResourcePermission
            // 
            this.btnUserResourcePermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserResourcePermission.Enabled = false;
            this.btnUserResourcePermission.Location = new System.Drawing.Point(13, 3);
            this.btnUserResourcePermission.Name = "btnUserResourcePermission";
            this.btnUserResourcePermission.Size = new System.Drawing.Size(120, 23);
            this.btnUserResourcePermission.TabIndex = 3;
            this.btnUserResourcePermission.Text = "用户权限...";
            this.btnUserResourcePermission.UseVisualStyleBackColor = true;
            this.btnUserResourcePermission.Click += new System.EventHandler(this.btnUserResourcePermission_Click);
            // 
            // chkRefresh
            // 
            this.chkRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRefresh.AutoSize = true;
            this.chkRefresh.Checked = true;
            this.chkRefresh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRefresh.Location = new System.Drawing.Point(884, 38);
            this.chkRefresh.Name = "chkRefresh";
            this.chkRefresh.Size = new System.Drawing.Size(72, 16);
            this.chkRefresh.TabIndex = 7;
            this.chkRefresh.Text = "即时刷新";
            this.chkRefresh.UseVisualStyleBackColor = true;
            this.chkRefresh.CheckedChanged += new System.EventHandler(this.chkRefresh_CheckedChanged);
            // 
            // lblContents
            // 
            this.lblContents.Location = new System.Drawing.Point(23, 25);
            this.lblContents.Name = "lblContents";
            this.lblContents.Size = new System.Drawing.Size(90, 12);
            this.lblContents.TabIndex = 0;
            this.lblContents.Text = "查询内容(&C)：";
            this.lblContents.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(117, 21);
            this.txtSearch.MaxLength = 20;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(168, 21);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnBatchSave
            // 
            this.btnBatchSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchSave.Enabled = false;
            this.btnBatchSave.Location = new System.Drawing.Point(804, 545);
            this.btnBatchSave.Name = "btnBatchSave";
            this.btnBatchSave.Size = new System.Drawing.Size(75, 23);
            this.btnBatchSave.TabIndex = 14;
            this.btnBatchSave.Text = "保存(&S)";
            this.btnBatchSave.UseVisualStyleBackColor = true;
            this.btnBatchSave.Click += new System.EventHandler(this.btnBatchSave_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(290, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询(&F)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlOrganize
            // 
            this.pnlOrganize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOrganize.Controls.Add(this.grdOrganize);
            this.pnlOrganize.Controls.Add(this.splOrganize);
            this.pnlOrganize.Controls.Add(this.tvOrganize);
            this.pnlOrganize.Location = new System.Drawing.Point(8, 60);
            this.pnlOrganize.Name = "pnlOrganize";
            this.pnlOrganize.Size = new System.Drawing.Size(951, 478);
            this.pnlOrganize.TabIndex = 1;
            // 
            // grdOrganize
            // 
            this.grdOrganize.AllowUserToAddRows = false;
            this.grdOrganize.AllowUserToDeleteRows = false;
            this.grdOrganize.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdOrganize.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdOrganize.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdOrganize.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colCode,
            this.colFullName,
            this.colIsInnerOrganize,
            this.colDescription});
            this.grdOrganize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOrganize.Location = new System.Drawing.Point(263, 0);
            this.grdOrganize.MultiSelect = false;
            this.grdOrganize.Name = "grdOrganize";
            this.grdOrganize.RowTemplate.Height = 23;
            this.grdOrganize.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdOrganize.Size = new System.Drawing.Size(688, 478);
            this.grdOrganize.TabIndex = 2;
            this.grdOrganize.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdOrganize_CellDoubleClick);
            this.grdOrganize.Sorted += new System.EventHandler(this.grdOrganize_Sorted);
            this.grdOrganize.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grdOrganize_UserDeletingRow);
            this.grdOrganize.Click += new System.EventHandler(this.grdOrganize_Click);
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
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colFullName.DefaultCellStyle = dataGridViewCellStyle2;
            this.colFullName.FillWeight = 170F;
            this.colFullName.HeaderText = "名称";
            this.colFullName.MaxInputLength = 100;
            this.colFullName.Name = "colFullName";
            this.colFullName.Width = 170;
            // 
            // colIsInnerOrganize
            // 
            this.colIsInnerOrganize.DataPropertyName = "IsInnerOrganize";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.NullValue = false;
            this.colIsInnerOrganize.DefaultCellStyle = dataGridViewCellStyle3;
            this.colIsInnerOrganize.FalseValue = "0";
            this.colIsInnerOrganize.HeaderText = "内部组织";
            this.colIsInnerOrganize.Name = "colIsInnerOrganize";
            this.colIsInnerOrganize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsInnerOrganize.TrueValue = "1";
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colDescription.DefaultCellStyle = dataGridViewCellStyle4;
            this.colDescription.HeaderText = "描述";
            this.colDescription.MaxInputLength = 200;
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 105;
            // 
            // splOrganize
            // 
            this.splOrganize.Location = new System.Drawing.Point(260, 0);
            this.splOrganize.Name = "splOrganize";
            this.splOrganize.Size = new System.Drawing.Size(3, 478);
            this.splOrganize.TabIndex = 8;
            this.splOrganize.TabStop = false;
            // 
            // tvOrganize
            // 
            this.tvOrganize.AllowDrop = true;
            this.tvOrganize.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvOrganize.HotTracking = true;
            this.tvOrganize.ImageIndex = 0;
            this.tvOrganize.ImageList = this.imageList;
            this.tvOrganize.Location = new System.Drawing.Point(0, 0);
            this.tvOrganize.Name = "tvOrganize";
            this.tvOrganize.SelectedImageIndex = 1;
            this.tvOrganize.Size = new System.Drawing.Size(260, 478);
            this.tvOrganize.TabIndex = 1;
            this.tvOrganize.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvOrganize_ItemDrag);
            this.tvOrganize.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOrganize_AfterSelect);
            this.tvOrganize.Click += new System.EventHandler(this.tvOrganize_Click);
            this.tvOrganize.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvOrganize_DragDrop);
            this.tvOrganize.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvOrganize_DragEnter);
            this.tvOrganize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvOrganize_MouseDown);
            // 
            // btnBatchDelete
            // 
            this.btnBatchDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchDelete.Enabled = false;
            this.btnBatchDelete.Location = new System.Drawing.Point(724, 545);
            this.btnBatchDelete.Name = "btnBatchDelete";
            this.btnBatchDelete.Size = new System.Drawing.Size(75, 23);
            this.btnBatchDelete.TabIndex = 13;
            this.btnBatchDelete.Text = "删除(&D)";
            this.btnBatchDelete.UseVisualStyleBackColor = true;
            this.btnBatchDelete.Click += new System.EventHandler(this.btnBatchDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(483, 545);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "添加(&A)...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnMove
            // 
            this.btnMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMove.Enabled = false;
            this.btnMove.Location = new System.Drawing.Point(644, 545);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(75, 23);
            this.btnMove.TabIndex = 11;
            this.btnMove.Text = "移动(&M)...";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(564, 545);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "编辑(&E)...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // ucTableSort
            // 
            this.ucTableSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ucTableSort.Location = new System.Drawing.Point(172, 543);
            this.ucTableSort.Margin = new System.Windows.Forms.Padding(0);
            this.ucTableSort.Name = "ucTableSort";
            this.ucTableSort.OEntityId = null;
            this.ucTableSort.Padding = new System.Windows.Forms.Padding(1);
            this.ucTableSort.SetBottomEnabled = false;
            this.ucTableSort.SetDownEnabled = false;
            this.ucTableSort.SetTopEnabled = false;
            this.ucTableSort.SetUpEnabled = false;
            this.ucTableSort.Size = new System.Drawing.Size(99, 26);
            this.ucTableSort.TabIndex = 8;
            // 
            // FrmOrganizePermissionAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(967, 572);
            this.Controls.Add(this.btnPermission);
            this.Controls.Add(this.btnInvertSelect);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.chkInnerOrganize);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.chkRefresh);
            this.Controls.Add(this.lblContents);
            this.Controls.Add(this.ucTableSort);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnBatchSave);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.pnlOrganize);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBatchDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.btnEdit);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmOrganizePermissionAdmin";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "组织机构权限管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmOrganizeAdmin_FormClosing);
            this.cMnuOrganize.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlOrganize.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrganize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Panel pnlOrganize;
        private System.Windows.Forms.Splitter splOrganize;
        private System.Windows.Forms.TreeView tvOrganize;
        private System.Windows.Forms.Button btnBatchDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView grdOrganize;
        private System.Windows.Forms.Button btnBatchSave;
        private System.Windows.Forms.ContextMenuStrip cMnuOrganize;
        private System.Windows.Forms.ToolStripMenuItem mItmAdd;
        private System.Windows.Forms.ToolStripMenuItem mItmEdit;
        private System.Windows.Forms.ToolStripMenuItem mItmMove;
        private System.Windows.Forms.ToolStripMenuItem mItmDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mItmStaffAdd;
        private System.Windows.Forms.ToolStripMenuItem mItemRoleAdd;
        private System.Windows.Forms.ToolStripMenuItem mItmOrganizeCategory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mItmSetSortCode;
        private System.Windows.Forms.Label lblContents;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox chkRefresh;
        private System.Windows.Forms.ToolStripMenuItem mItmFrmCodeBuilder;
        private DotNet.WinForm.UCTableSort ucTableSort;
        private System.Windows.Forms.ToolStripMenuItem mItmAddRoot;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripMenuItem mItmUserAdd;
        private System.Windows.Forms.CheckBox chkInnerOrganize;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnUserResourcePermission;
        private System.Windows.Forms.Button btnRoleResourcePermission;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsInnerOrganize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnInvertSelect;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnPermission;
    }
}