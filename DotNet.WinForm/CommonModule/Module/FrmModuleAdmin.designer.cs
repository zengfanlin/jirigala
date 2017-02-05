namespace DotNet.WinForm
{
    partial class FrmModuleAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModuleAdmin));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.cMnuModule = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItmAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmMove = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmAddRoot = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mItmModulePermissionRelation = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmModuleSetPermission = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mItmSetSortCode = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnInvertSelect = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.cmbSystem = new System.Windows.Forms.ComboBox();
            this.lblSystem = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnModulePermissionRelation = new System.Windows.Forms.Button();
            this.btnModuleConfig = new System.Windows.Forms.Button();
            this.btnUserModulePermission = new System.Windows.Forms.Button();
            this.btnRoleModulePermission = new System.Windows.Forms.Button();
            this.pnlModule = new System.Windows.Forms.Panel();
            this.grdModule = new System.Windows.Forms.DataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNavigateUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsPublic = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colExpand = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.splModule = new System.Windows.Forms.Splitter();
            this.tvModule = new System.Windows.Forms.TreeView();
            this.btnBatchSave = new System.Windows.Forms.Button();
            this.ucTableSort = new DotNet.WinForm.UCTableSort();
            this.btnBatchDelete = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cMnuModule.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlModule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdModule)).BeginInit();
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
            // cMnuModule
            // 
            this.cMnuModule.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItmAdd,
            this.mItmEdit,
            this.mItmMove,
            this.mItmDelete,
            this.mItmAddRoot,
            this.toolStripSeparator1,
            this.mItmModulePermissionRelation,
            this.mItmModuleSetPermission,
            this.toolStripSeparator2,
            this.mItmSetSortCode});
            this.cMnuModule.Name = "cMnuModule";
            this.cMnuModule.Size = new System.Drawing.Size(173, 192);
            // 
            // mItmAdd
            // 
            this.mItmAdd.Enabled = false;
            this.mItmAdd.Name = "mItmAdd";
            this.mItmAdd.Size = new System.Drawing.Size(172, 22);
            this.mItmAdd.Text = "添加(&A)...";
            this.mItmAdd.Click += new System.EventHandler(this.mItmAdd_Click);
            // 
            // mItmEdit
            // 
            this.mItmEdit.Enabled = false;
            this.mItmEdit.Name = "mItmEdit";
            this.mItmEdit.Size = new System.Drawing.Size(172, 22);
            this.mItmEdit.Text = "编辑(&E)...";
            this.mItmEdit.Click += new System.EventHandler(this.mItmEdit_Click);
            // 
            // mItmMove
            // 
            this.mItmMove.Enabled = false;
            this.mItmMove.Name = "mItmMove";
            this.mItmMove.Size = new System.Drawing.Size(172, 22);
            this.mItmMove.Text = "移动(&M)...";
            this.mItmMove.Click += new System.EventHandler(this.mItmMove_Click);
            // 
            // mItmDelete
            // 
            this.mItmDelete.Enabled = false;
            this.mItmDelete.Name = "mItmDelete";
            this.mItmDelete.Size = new System.Drawing.Size(172, 22);
            this.mItmDelete.Text = "删除(&D)";
            this.mItmDelete.Click += new System.EventHandler(this.mItmDelete_Click);
            // 
            // mItmAddRoot
            // 
            this.mItmAddRoot.Enabled = false;
            this.mItmAddRoot.Name = "mItmAddRoot";
            this.mItmAddRoot.Size = new System.Drawing.Size(172, 22);
            this.mItmAddRoot.Text = "添加根菜单...";
            this.mItmAddRoot.Click += new System.EventHandler(this.mItmAddRoot_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // mItmModulePermissionRelation
            // 
            this.mItmModulePermissionRelation.Enabled = false;
            this.mItmModulePermissionRelation.Name = "mItmModulePermissionRelation";
            this.mItmModulePermissionRelation.Size = new System.Drawing.Size(172, 22);
            this.mItmModulePermissionRelation.Text = "关联操作权限(&I)...";
            this.mItmModulePermissionRelation.Click += new System.EventHandler(this.mItmModulePermissionRelation_Click);
            // 
            // mItmModuleSetPermission
            // 
            this.mItmModuleSetPermission.Enabled = false;
            this.mItmModuleSetPermission.Name = "mItmModuleSetPermission";
            this.mItmModuleSetPermission.Size = new System.Drawing.Size(172, 22);
            this.mItmModuleSetPermission.Text = "菜单访问权限(&P)...";
            this.mItmModuleSetPermission.Click += new System.EventHandler(this.mItmModuleSetPermission_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(169, 6);
            // 
            // mItmSetSortCode
            // 
            this.mItmSetSortCode.Enabled = false;
            this.mItmSetSortCode.Name = "mItmSetSortCode";
            this.mItmSetSortCode.Size = new System.Drawing.Size(172, 22);
            this.mItmSetSortCode.Text = "保存排序顺序";
            this.mItmSetSortCode.Click += new System.EventHandler(this.mItmSetSortCode_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(944, 522);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnInvertSelect
            // 
            this.btnInvertSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvertSelect.Enabled = false;
            this.btnInvertSelect.Location = new System.Drawing.Point(88, 521);
            this.btnInvertSelect.Name = "btnInvertSelect";
            this.btnInvertSelect.Size = new System.Drawing.Size(78, 23);
            this.btnInvertSelect.TabIndex = 17;
            this.btnInvertSelect.Text = "反选";
            this.btnInvertSelect.UseVisualStyleBackColor = true;
            this.btnInvertSelect.Click += new System.EventHandler(this.btnInvertSelect_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Enabled = false;
            this.btnSelectAll.Location = new System.Drawing.Point(6, 521);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(78, 23);
            this.btnSelectAll.TabIndex = 16;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // cmbSystem
            // 
            this.cmbSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSystem.Location = new System.Drawing.Point(78, 8);
            this.cmbSystem.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbSystem.Name = "cmbSystem";
            this.cmbSystem.Size = new System.Drawing.Size(190, 20);
            this.cmbSystem.TabIndex = 15;
            this.cmbSystem.SelectedIndexChanged += new System.EventHandler(this.cmbSystem_SelectedIndexChanged);
            // 
            // lblSystem
            // 
            this.lblSystem.Location = new System.Drawing.Point(0, 11);
            this.lblSystem.Name = "lblSystem";
            this.lblSystem.Size = new System.Drawing.Size(73, 12);
            this.lblSystem.TabIndex = 14;
            this.lblSystem.Text = "业务系统：";
            this.lblSystem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnExport);
            this.flowLayoutPanel1.Controls.Add(this.btnModulePermissionRelation);
            this.flowLayoutPanel1.Controls.Add(this.btnModuleConfig);
            this.flowLayoutPanel1.Controls.Add(this.btnUserModulePermission);
            this.flowLayoutPanel1.Controls.Add(this.btnRoleModulePermission);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(336, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(687, 29);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(584, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 23);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "导出Excel...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExportAll_Click);
            // 
            // btnModulePermissionRelation
            // 
            this.btnModulePermissionRelation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModulePermissionRelation.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnModulePermissionRelation.Enabled = false;
            this.btnModulePermissionRelation.Location = new System.Drawing.Point(478, 3);
            this.btnModulePermissionRelation.Name = "btnModulePermissionRelation";
            this.btnModulePermissionRelation.Size = new System.Drawing.Size(100, 23);
            this.btnModulePermissionRelation.TabIndex = 11;
            this.btnModulePermissionRelation.Text = "关联操作权限(&P)...";
            this.btnModulePermissionRelation.UseVisualStyleBackColor = true;
            this.btnModulePermissionRelation.Click += new System.EventHandler(this.btnModulePermissionRelation_Click);
            // 
            // btnModuleConfig
            // 
            this.btnModuleConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModuleConfig.Enabled = false;
            this.btnModuleConfig.Location = new System.Drawing.Point(372, 3);
            this.btnModuleConfig.Name = "btnModuleConfig";
            this.btnModuleConfig.Size = new System.Drawing.Size(100, 23);
            this.btnModuleConfig.TabIndex = 2;
            this.btnModuleConfig.Text = "菜单配置...";
            this.btnModuleConfig.UseVisualStyleBackColor = true;
            this.btnModuleConfig.Click += new System.EventHandler(this.btnModuleConfig_Click);
            // 
            // btnUserModulePermission
            // 
            this.btnUserModulePermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserModulePermission.Enabled = false;
            this.btnUserModulePermission.Location = new System.Drawing.Point(266, 3);
            this.btnUserModulePermission.Name = "btnUserModulePermission";
            this.btnUserModulePermission.Size = new System.Drawing.Size(100, 23);
            this.btnUserModulePermission.TabIndex = 0;
            this.btnUserModulePermission.Text = "用户菜单权限...";
            this.btnUserModulePermission.UseVisualStyleBackColor = true;
            this.btnUserModulePermission.Click += new System.EventHandler(this.btnUserModulePermission_Click);
            // 
            // btnRoleModulePermission
            // 
            this.btnRoleModulePermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRoleModulePermission.Enabled = false;
            this.btnRoleModulePermission.Location = new System.Drawing.Point(160, 3);
            this.btnRoleModulePermission.Name = "btnRoleModulePermission";
            this.btnRoleModulePermission.Size = new System.Drawing.Size(100, 23);
            this.btnRoleModulePermission.TabIndex = 1;
            this.btnRoleModulePermission.Text = "角色菜单权限...";
            this.btnRoleModulePermission.UseVisualStyleBackColor = true;
            this.btnRoleModulePermission.Click += new System.EventHandler(this.btnRoleModulePermission_Click);
            // 
            // pnlModule
            // 
            this.pnlModule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlModule.Controls.Add(this.grdModule);
            this.pnlModule.Controls.Add(this.splModule);
            this.pnlModule.Controls.Add(this.tvModule);
            this.pnlModule.Location = new System.Drawing.Point(8, 37);
            this.pnlModule.Name = "pnlModule";
            this.pnlModule.Size = new System.Drawing.Size(1011, 477);
            this.pnlModule.TabIndex = 1;
            // 
            // grdModule
            // 
            this.grdModule.AllowUserToAddRows = false;
            this.grdModule.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdModule.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdModule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdModule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colCode,
            this.colFullName,
            this.colNavigateUrl,
            this.colDescription,
            this.colIsPublic,
            this.colExpand,
            this.colEnabled});
            this.grdModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdModule.Location = new System.Drawing.Point(245, 0);
            this.grdModule.MultiSelect = false;
            this.grdModule.Name = "grdModule";
            this.grdModule.RowTemplate.Height = 23;
            this.grdModule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdModule.Size = new System.Drawing.Size(766, 477);
            this.grdModule.TabIndex = 1;
            this.grdModule.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdModule_CellDoubleClick);
            this.grdModule.Sorted += new System.EventHandler(this.grdModule_Sorted);
            this.grdModule.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grdModule_UserDeletingRow);
            this.grdModule.Click += new System.EventHandler(this.grdModule_Click);
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
            this.colCode.FillWeight = 150F;
            this.colCode.Frozen = true;
            this.colCode.HeaderText = "编号";
            this.colCode.MaxInputLength = 20;
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            this.colCode.Width = 120;
            // 
            // colFullName
            // 
            this.colFullName.DataPropertyName = "FullName";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colFullName.DefaultCellStyle = dataGridViewCellStyle2;
            this.colFullName.FillWeight = 180F;
            this.colFullName.Frozen = true;
            this.colFullName.HeaderText = "名称";
            this.colFullName.MaxInputLength = 120;
            this.colFullName.Name = "colFullName";
            // 
            // colNavigateUrl
            // 
            this.colNavigateUrl.DataPropertyName = "NavigateUrl";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colNavigateUrl.DefaultCellStyle = dataGridViewCellStyle3;
            this.colNavigateUrl.Frozen = true;
            this.colNavigateUrl.HeaderText = "web地址";
            this.colNavigateUrl.MaxInputLength = 500;
            this.colNavigateUrl.Name = "colNavigateUrl";
            this.colNavigateUrl.Width = 200;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colDescription.DefaultCellStyle = dataGridViewCellStyle4;
            this.colDescription.FillWeight = 70F;
            this.colDescription.HeaderText = "描述";
            this.colDescription.MaxInputLength = 200;
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 80;
            // 
            // colIsPublic
            // 
            this.colIsPublic.DataPropertyName = "IsPublic";
            this.colIsPublic.FalseValue = "0";
            this.colIsPublic.FillWeight = 70F;
            this.colIsPublic.HeaderText = "公开";
            this.colIsPublic.Name = "colIsPublic";
            this.colIsPublic.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsPublic.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsPublic.TrueValue = "1";
            this.colIsPublic.Width = 50;
            // 
            // colExpand
            // 
            this.colExpand.DataPropertyName = "Expand";
            this.colExpand.FalseValue = "0";
            this.colExpand.HeaderText = "展开";
            this.colExpand.Name = "colExpand";
            this.colExpand.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colExpand.TrueValue = "1";
            this.colExpand.Width = 50;
            // 
            // colEnabled
            // 
            this.colEnabled.DataPropertyName = "Enabled";
            this.colEnabled.FalseValue = "0";
            this.colEnabled.FillWeight = 70F;
            this.colEnabled.HeaderText = "有效";
            this.colEnabled.Name = "colEnabled";
            this.colEnabled.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEnabled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEnabled.TrueValue = "1";
            this.colEnabled.Width = 50;
            // 
            // splModule
            // 
            this.splModule.Location = new System.Drawing.Point(242, 0);
            this.splModule.Name = "splModule";
            this.splModule.Size = new System.Drawing.Size(3, 477);
            this.splModule.TabIndex = 8;
            this.splModule.TabStop = false;
            // 
            // tvModule
            // 
            this.tvModule.AllowDrop = true;
            this.tvModule.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvModule.ImageIndex = 0;
            this.tvModule.ImageList = this.imageList;
            this.tvModule.Location = new System.Drawing.Point(0, 0);
            this.tvModule.Name = "tvModule";
            this.tvModule.SelectedImageIndex = 1;
            this.tvModule.Size = new System.Drawing.Size(242, 477);
            this.tvModule.TabIndex = 0;
            this.tvModule.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvModule_ItemDrag);
            this.tvModule.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvModule_AfterSelect);
            this.tvModule.Click += new System.EventHandler(this.tvModule_Click);
            this.tvModule.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvModule_DragDrop);
            this.tvModule.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvModule_DragEnter);
            this.tvModule.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvModule_MouseDown);
            // 
            // btnBatchSave
            // 
            this.btnBatchSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchSave.Enabled = false;
            this.btnBatchSave.Location = new System.Drawing.Point(865, 522);
            this.btnBatchSave.Name = "btnBatchSave";
            this.btnBatchSave.Size = new System.Drawing.Size(75, 23);
            this.btnBatchSave.TabIndex = 10;
            this.btnBatchSave.Text = "保存(&S)";
            this.btnBatchSave.UseVisualStyleBackColor = true;
            this.btnBatchSave.Click += new System.EventHandler(this.btnBatchSave_Click);
            // 
            // ucTableSort
            // 
            this.ucTableSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ucTableSort.Location = new System.Drawing.Point(170, 520);
            this.ucTableSort.Margin = new System.Windows.Forms.Padding(0);
            this.ucTableSort.Name = "ucTableSort";
            this.ucTableSort.OEntityId = null;
            this.ucTableSort.Padding = new System.Windows.Forms.Padding(1);
            this.ucTableSort.SetBottomEnabled = false;
            this.ucTableSort.SetDownEnabled = false;
            this.ucTableSort.SetTopEnabled = false;
            this.ucTableSort.SetUpEnabled = false;
            this.ucTableSort.Size = new System.Drawing.Size(99, 24);
            this.ucTableSort.TabIndex = 4;
            // 
            // btnBatchDelete
            // 
            this.btnBatchDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchDelete.Enabled = false;
            this.btnBatchDelete.Location = new System.Drawing.Point(786, 522);
            this.btnBatchDelete.Name = "btnBatchDelete";
            this.btnBatchDelete.Size = new System.Drawing.Size(75, 23);
            this.btnBatchDelete.TabIndex = 9;
            this.btnBatchDelete.Text = "删除(&D)";
            this.btnBatchDelete.UseVisualStyleBackColor = true;
            this.btnBatchDelete.Click += new System.EventHandler(this.btnBatchDelete_Click);
            // 
            // btnMove
            // 
            this.btnMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMove.Enabled = false;
            this.btnMove.Location = new System.Drawing.Point(707, 522);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(75, 23);
            this.btnMove.TabIndex = 7;
            this.btnMove.Text = "移动(&M)...";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(628, 522);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "编辑(&E)...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(548, 522);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "添加(&A)...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FrmModuleAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1027, 549);
            this.Controls.Add(this.btnInvertSelect);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.cmbSystem);
            this.Controls.Add(this.lblSystem);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pnlModule);
            this.Controls.Add(this.btnBatchSave);
            this.Controls.Add(this.ucTableSort);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBatchDelete);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmModuleAdmin";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "菜单管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmModuleAdmin_FormClosing);
            this.cMnuModule.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlModule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdModule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Panel pnlModule;
        private System.Windows.Forms.Splitter splModule;
        private System.Windows.Forms.Button btnBatchDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnBatchSave;
        private System.Windows.Forms.DataGridView grdModule;
        private System.Windows.Forms.TreeView tvModule;
        private System.Windows.Forms.ContextMenuStrip cMnuModule;
        private System.Windows.Forms.ToolStripMenuItem mItmAdd;
        private System.Windows.Forms.ToolStripMenuItem mItmEdit;
        private System.Windows.Forms.ToolStripMenuItem mItmMove;
        private System.Windows.Forms.ToolStripMenuItem mItmDelete;
        private System.Windows.Forms.ToolStripMenuItem mItmModulePermissionRelation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button btnModulePermissionRelation;
        private System.Windows.Forms.ToolStripMenuItem mItmSetSortCode;
        private DotNet.WinForm.UCTableSort ucTableSort;
        private System.Windows.Forms.ToolStripMenuItem mItmAddRoot;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Button btnModuleConfig;
        private System.Windows.Forms.ToolStripMenuItem mItmModuleSetPermission;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnRoleModulePermission;
        private System.Windows.Forms.Button btnUserModulePermission;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox cmbSystem;
        private System.Windows.Forms.Label lblSystem;
        private System.Windows.Forms.Button btnInvertSelect;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNavigateUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsPublic;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colExpand;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEnabled;

    }
}