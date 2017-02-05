namespace DotNet.WinForm
{
    partial class FrmStaffAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStaffAdmin));
            this.btnBatchSave = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnBatchDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSetPassword = new System.Windows.Forms.Button();
            this.pnlStaff = new System.Windows.Forms.Panel();
            this.grdStaff = new System.Windows.Forms.DataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOfficePhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splOrganize = new System.Windows.Forms.Splitter();
            this.tvOrganize = new System.Windows.Forms.TreeView();
            this.cMnuStaff = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItmStaffAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemRoleAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mItmAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmMove = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mItmGender = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmParty = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmNationality = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmTitle = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmDuty = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmEducation = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmDegree = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmWorkingProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mItemResetSortCode = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnUserPermission = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ucTableSort = new DotNet.WinForm.UCTableSort();
            this.chkNotIsUser = new System.Windows.Forms.CheckBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.btnInvertSelect = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.picExport = new System.Windows.Forms.PictureBox();
            this.picImport = new System.Windows.Forms.PictureBox();
            this.picSetting = new System.Windows.Forms.PictureBox();
            this.picBug = new System.Windows.Forms.PictureBox();
            this.chkNotDepartment = new System.Windows.Forms.CheckBox();
            this.btnOrganize = new System.Windows.Forms.Button();
            this.pnlStaff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStaff)).BeginInit();
            this.cMnuStaff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBug)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBatchSave
            // 
            this.btnBatchSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchSave.Enabled = false;
            this.btnBatchSave.Location = new System.Drawing.Point(885, 506);
            this.btnBatchSave.Name = "btnBatchSave";
            this.btnBatchSave.Size = new System.Drawing.Size(75, 23);
            this.btnBatchSave.TabIndex = 13;
            this.btnBatchSave.Text = "保存(&S)";
            this.btnBatchSave.UseVisualStyleBackColor = true;
            this.btnBatchSave.Click += new System.EventHandler(this.btnBatchSave_Click);
            // 
            // btnMove
            // 
            this.btnMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMove.Enabled = false;
            this.btnMove.Location = new System.Drawing.Point(549, 506);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(75, 23);
            this.btnMove.TabIndex = 8;
            this.btnMove.Text = "移动(&M)...";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // btnBatchDelete
            // 
            this.btnBatchDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchDelete.Enabled = false;
            this.btnBatchDelete.Location = new System.Drawing.Point(807, 506);
            this.btnBatchDelete.Name = "btnBatchDelete";
            this.btnBatchDelete.Size = new System.Drawing.Size(75, 23);
            this.btnBatchDelete.TabIndex = 12;
            this.btnBatchDelete.Text = "删除(&D)";
            this.btnBatchDelete.UseVisualStyleBackColor = true;
            this.btnBatchDelete.Click += new System.EventHandler(this.btnBatchDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(471, 506);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "编辑(&E)...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(963, 506);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(393, 506);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "添加(&A)...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSetPassword
            // 
            this.btnSetPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetPassword.Enabled = false;
            this.btnSetPassword.Location = new System.Drawing.Point(627, 506);
            this.btnSetPassword.Name = "btnSetPassword";
            this.btnSetPassword.Size = new System.Drawing.Size(86, 23);
            this.btnSetPassword.TabIndex = 9;
            this.btnSetPassword.Text = "设置密码(&P)...";
            this.btnSetPassword.UseVisualStyleBackColor = true;
            this.btnSetPassword.Click += new System.EventHandler(this.btnSetPassword_Click);
            // 
            // pnlStaff
            // 
            this.pnlStaff.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStaff.Controls.Add(this.grdStaff);
            this.pnlStaff.Controls.Add(this.splOrganize);
            this.pnlStaff.Controls.Add(this.tvOrganize);
            this.pnlStaff.Location = new System.Drawing.Point(8, 40);
            this.pnlStaff.Name = "pnlStaff";
            this.pnlStaff.Size = new System.Drawing.Size(1030, 458);
            this.pnlStaff.TabIndex = 1;
            // 
            // grdStaff
            // 
            this.grdStaff.AllowUserToAddRows = false;
            this.grdStaff.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdStaff.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdStaff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colCode,
            this.colRealName,
            this.colGender,
            this.colMobile,
            this.colOfficePhone,
            this.colDescription});
            this.grdStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStaff.Location = new System.Drawing.Point(263, 0);
            this.grdStaff.MultiSelect = false;
            this.grdStaff.Name = "grdStaff";
            this.grdStaff.RowTemplate.Height = 23;
            this.grdStaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdStaff.Size = new System.Drawing.Size(767, 458);
            this.grdStaff.TabIndex = 1;
            this.grdStaff.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdStaff_CellDoubleClick);
            this.grdStaff.SelectionChanged += new System.EventHandler(this.grdStaff_SelectionChanged);
            this.grdStaff.Sorted += new System.EventHandler(this.grdStaff_Sorted);
            this.grdStaff.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grdStaff_UserDeletingRow);
            this.grdStaff.Click += new System.EventHandler(this.grdStaff_Click);
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
            this.colCode.MaxInputLength = 20;
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            // 
            // colRealName
            // 
            this.colRealName.DataPropertyName = "RealName";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colRealName.DefaultCellStyle = dataGridViewCellStyle2;
            this.colRealName.FillWeight = 80F;
            this.colRealName.HeaderText = "姓名";
            this.colRealName.MaxInputLength = 50;
            this.colRealName.Name = "colRealName";
            this.colRealName.Width = 80;
            // 
            // colGender
            // 
            this.colGender.DataPropertyName = "Gender";
            this.colGender.FillWeight = 40F;
            this.colGender.HeaderText = "性别";
            this.colGender.Name = "colGender";
            this.colGender.Width = 40;
            // 
            // colMobile
            // 
            this.colMobile.DataPropertyName = "Mobile";
            this.colMobile.HeaderText = "手机";
            this.colMobile.MaxInputLength = 20;
            this.colMobile.Name = "colMobile";
            this.colMobile.ReadOnly = true;
            // 
            // colOfficePhone
            // 
            this.colOfficePhone.DataPropertyName = "OfficePhone";
            this.colOfficePhone.HeaderText = "电话";
            this.colOfficePhone.Name = "colOfficePhone";
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colDescription.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDescription.HeaderText = "描述";
            this.colDescription.MaxInputLength = 200;
            this.colDescription.Name = "colDescription";
            // 
            // splOrganize
            // 
            this.splOrganize.Location = new System.Drawing.Point(260, 0);
            this.splOrganize.Name = "splOrganize";
            this.splOrganize.Size = new System.Drawing.Size(3, 458);
            this.splOrganize.TabIndex = 2;
            this.splOrganize.TabStop = false;
            // 
            // tvOrganize
            // 
            this.tvOrganize.AllowDrop = true;
            this.tvOrganize.ContextMenuStrip = this.cMnuStaff;
            this.tvOrganize.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvOrganize.ImageIndex = 0;
            this.tvOrganize.ImageList = this.imageList;
            this.tvOrganize.Location = new System.Drawing.Point(0, 0);
            this.tvOrganize.Name = "tvOrganize";
            this.tvOrganize.SelectedImageIndex = 1;
            this.tvOrganize.Size = new System.Drawing.Size(260, 458);
            this.tvOrganize.TabIndex = 0;
            this.tvOrganize.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvOrganize_ItemDrag);
            this.tvOrganize.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOrganize_AfterSelect);
            this.tvOrganize.Click += new System.EventHandler(this.tvOrganize_Click);
            this.tvOrganize.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvOrganize_DragDrop);
            this.tvOrganize.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvOrganize_DragEnter);
            this.tvOrganize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvOrganize_MouseDown);
            // 
            // cMnuStaff
            // 
            this.cMnuStaff.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItmStaffAdd,
            this.mItemRoleAdd,
            this.toolStripSeparator4,
            this.mItmAdd,
            this.mItmEdit,
            this.mItmMove,
            this.mItmDelete,
            this.toolStripSeparator2,
            this.mItmGender,
            this.mItmParty,
            this.mItmNationality,
            this.mItmTitle,
            this.mItmDuty,
            this.mItmEducation,
            this.mItmDegree,
            this.mItmWorkingProperty,
            this.toolStripSeparator3,
            this.mItemResetSortCode});
            this.cMnuStaff.Name = "cMnuStaff";
            this.cMnuStaff.Size = new System.Drawing.Size(158, 352);
            // 
            // mItmStaffAdd
            // 
            this.mItmStaffAdd.Enabled = false;
            this.mItmStaffAdd.Name = "mItmStaffAdd";
            this.mItmStaffAdd.Size = new System.Drawing.Size(157, 22);
            this.mItmStaffAdd.Text = "添加员工...";
            this.mItmStaffAdd.Click += new System.EventHandler(this.mitmStaffAdd_Click);
            // 
            // mItemRoleAdd
            // 
            this.mItemRoleAdd.Enabled = false;
            this.mItemRoleAdd.Name = "mItemRoleAdd";
            this.mItemRoleAdd.Size = new System.Drawing.Size(157, 22);
            this.mItemRoleAdd.Text = "添加角色...";
            this.mItemRoleAdd.Visible = false;
            this.mItemRoleAdd.Click += new System.EventHandler(this.mItemRoleAdd_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(154, 6);
            // 
            // mItmAdd
            // 
            this.mItmAdd.Enabled = false;
            this.mItmAdd.Name = "mItmAdd";
            this.mItmAdd.Size = new System.Drawing.Size(157, 22);
            this.mItmAdd.Text = "添加(&A)...";
            this.mItmAdd.Click += new System.EventHandler(this.mitmAdd_Click);
            // 
            // mItmEdit
            // 
            this.mItmEdit.Enabled = false;
            this.mItmEdit.Name = "mItmEdit";
            this.mItmEdit.Size = new System.Drawing.Size(157, 22);
            this.mItmEdit.Text = "编辑(&E)...";
            this.mItmEdit.Click += new System.EventHandler(this.mitmEdit_Click);
            // 
            // mItmMove
            // 
            this.mItmMove.Enabled = false;
            this.mItmMove.Name = "mItmMove";
            this.mItmMove.Size = new System.Drawing.Size(157, 22);
            this.mItmMove.Text = "移动(&M)...";
            this.mItmMove.Click += new System.EventHandler(this.mitmMove_Click);
            // 
            // mItmDelete
            // 
            this.mItmDelete.Enabled = false;
            this.mItmDelete.Name = "mItmDelete";
            this.mItmDelete.Size = new System.Drawing.Size(157, 22);
            this.mItmDelete.Text = "删除(&D)";
            this.mItmDelete.Click += new System.EventHandler(this.mitmDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(154, 6);
            // 
            // mItmGender
            // 
            this.mItmGender.Enabled = false;
            this.mItmGender.Name = "mItmGender";
            this.mItmGender.Size = new System.Drawing.Size(157, 22);
            this.mItmGender.Text = "性别维护...";
            this.mItmGender.Click += new System.EventHandler(this.mitm_Click);
            // 
            // mItmParty
            // 
            this.mItmParty.Enabled = false;
            this.mItmParty.Name = "mItmParty";
            this.mItmParty.Size = new System.Drawing.Size(157, 22);
            this.mItmParty.Text = "政治面貌维护...";
            this.mItmParty.Click += new System.EventHandler(this.mitm_Click);
            // 
            // mItmNationality
            // 
            this.mItmNationality.Enabled = false;
            this.mItmNationality.Name = "mItmNationality";
            this.mItmNationality.Size = new System.Drawing.Size(157, 22);
            this.mItmNationality.Text = "民族维护...";
            this.mItmNationality.Click += new System.EventHandler(this.mitm_Click);
            // 
            // mItmTitle
            // 
            this.mItmTitle.Enabled = false;
            this.mItmTitle.Name = "mItmTitle";
            this.mItmTitle.Size = new System.Drawing.Size(157, 22);
            this.mItmTitle.Text = "职称维护...";
            this.mItmTitle.Click += new System.EventHandler(this.mitm_Click);
            // 
            // mItmDuty
            // 
            this.mItmDuty.Enabled = false;
            this.mItmDuty.Name = "mItmDuty";
            this.mItmDuty.Size = new System.Drawing.Size(157, 22);
            this.mItmDuty.Text = "职务维护...";
            this.mItmDuty.Click += new System.EventHandler(this.mitm_Click);
            // 
            // mItmEducation
            // 
            this.mItmEducation.Enabled = false;
            this.mItmEducation.Name = "mItmEducation";
            this.mItmEducation.Size = new System.Drawing.Size(157, 22);
            this.mItmEducation.Text = "学历维护...";
            this.mItmEducation.Click += new System.EventHandler(this.mitm_Click);
            // 
            // mItmDegree
            // 
            this.mItmDegree.Enabled = false;
            this.mItmDegree.Name = "mItmDegree";
            this.mItmDegree.Size = new System.Drawing.Size(157, 22);
            this.mItmDegree.Text = "学位维护...";
            this.mItmDegree.Click += new System.EventHandler(this.mitm_Click);
            // 
            // mItmWorkingProperty
            // 
            this.mItmWorkingProperty.Enabled = false;
            this.mItmWorkingProperty.Name = "mItmWorkingProperty";
            this.mItmWorkingProperty.Size = new System.Drawing.Size(157, 22);
            this.mItmWorkingProperty.Text = "用工性质维护...";
            this.mItmWorkingProperty.Click += new System.EventHandler(this.mitm_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(154, 6);
            // 
            // mItemResetSortCode
            // 
            this.mItemResetSortCode.Enabled = false;
            this.mItemResetSortCode.Name = "mItemResetSortCode";
            this.mItemResetSortCode.Size = new System.Drawing.Size(157, 22);
            this.mItemResetSortCode.Text = "保存排序顺序";
            this.mItemResetSortCode.Click += new System.EventHandler(this.mItemResetSortCode_Click);
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
            // btnUserPermission
            // 
            this.btnUserPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserPermission.Enabled = false;
            this.btnUserPermission.Location = new System.Drawing.Point(716, 506);
            this.btnUserPermission.Name = "btnUserPermission";
            this.btnUserPermission.Size = new System.Drawing.Size(88, 23);
            this.btnUserPermission.TabIndex = 10;
            this.btnUserPermission.Text = "权限(&P)...";
            this.btnUserPermission.UseVisualStyleBackColor = true;
            this.btnUserPermission.Click += new System.EventHandler(this.btnUserPermission_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.Location = new System.Drawing.Point(4, 14);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(74, 12);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "查询内容(&C)：";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(79, 10);
            this.txtSearch.MaxLength = 20;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(168, 21);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(255, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询(&F)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ucTableSort
            // 
            this.ucTableSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ucTableSort.Location = new System.Drawing.Point(169, 506);
            this.ucTableSort.Margin = new System.Windows.Forms.Padding(0);
            this.ucTableSort.Name = "ucTableSort";
            this.ucTableSort.OEntityId = null;
            this.ucTableSort.Padding = new System.Windows.Forms.Padding(1);
            this.ucTableSort.SetBottomEnabled = false;
            this.ucTableSort.SetDownEnabled = false;
            this.ucTableSort.SetTopEnabled = false;
            this.ucTableSort.SetUpEnabled = false;
            this.ucTableSort.Size = new System.Drawing.Size(92, 24);
            this.ucTableSort.TabIndex = 5;
            // 
            // chkNotIsUser
            // 
            this.chkNotIsUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkNotIsUser.AutoSize = true;
            this.chkNotIsUser.Location = new System.Drawing.Point(609, 11);
            this.chkNotIsUser.Name = "chkNotIsUser";
            this.chkNotIsUser.Size = new System.Drawing.Size(96, 16);
            this.chkNotIsUser.TabIndex = 3;
            this.chkNotIsUser.Text = "无用户帐号的";
            this.chkNotIsUser.UseVisualStyleBackColor = true;
            this.chkNotIsUser.CheckedChanged += new System.EventHandler(this.chkNotIsUser_CheckedChanged);
            // 
            // chkEnabled
            // 
            this.chkEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(711, 11);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(60, 16);
            this.chkEnabled.TabIndex = 4;
            this.chkEnabled.Text = "有效的";
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.CheckedChanged += new System.EventHandler(this.chkEnabled_CheckedChanged);
            // 
            // btnInvertSelect
            // 
            this.btnInvertSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvertSelect.Enabled = false;
            this.btnInvertSelect.Location = new System.Drawing.Point(88, 507);
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
            this.btnSelectAll.Location = new System.Drawing.Point(7, 507);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(78, 23);
            this.btnSelectAll.TabIndex = 22;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // picExport
            // 
            this.picExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picExport.Image = ((System.Drawing.Image)(resources.GetObject("picExport.Image")));
            this.picExport.Location = new System.Drawing.Point(912, 4);
            this.picExport.Name = "picExport";
            this.picExport.Size = new System.Drawing.Size(30, 30);
            this.picExport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picExport.TabIndex = 27;
            this.picExport.TabStop = false;
            this.picExport.Click += new System.EventHandler(this.picExport_Click);
            // 
            // picImport
            // 
            this.picImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picImport.Image = ((System.Drawing.Image)(resources.GetObject("picImport.Image")));
            this.picImport.Location = new System.Drawing.Point(944, 4);
            this.picImport.Name = "picImport";
            this.picImport.Size = new System.Drawing.Size(30, 30);
            this.picImport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImport.TabIndex = 26;
            this.picImport.TabStop = false;
            this.picImport.Click += new System.EventHandler(this.picImport_Click);
            // 
            // picSetting
            // 
            this.picSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSetting.Image = ((System.Drawing.Image)(resources.GetObject("picSetting.Image")));
            this.picSetting.Location = new System.Drawing.Point(976, 4);
            this.picSetting.Name = "picSetting";
            this.picSetting.Size = new System.Drawing.Size(30, 30);
            this.picSetting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSetting.TabIndex = 25;
            this.picSetting.TabStop = false;
            this.picSetting.Click += new System.EventHandler(this.picSetting_Click);
            // 
            // picBug
            // 
            this.picBug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBug.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBug.Image = ((System.Drawing.Image)(resources.GetObject("picBug.Image")));
            this.picBug.Location = new System.Drawing.Point(1008, 4);
            this.picBug.Name = "picBug";
            this.picBug.Size = new System.Drawing.Size(30, 30);
            this.picBug.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBug.TabIndex = 24;
            this.picBug.TabStop = false;
            this.picBug.Click += new System.EventHandler(this.picBug_Click);
            // 
            // chkNotDepartment
            // 
            this.chkNotDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkNotDepartment.AutoSize = true;
            this.chkNotDepartment.Location = new System.Drawing.Point(507, 11);
            this.chkNotDepartment.Name = "chkNotDepartment";
            this.chkNotDepartment.Size = new System.Drawing.Size(96, 16);
            this.chkNotDepartment.TabIndex = 28;
            this.chkNotDepartment.Text = "部门未设置的";
            this.chkNotDepartment.UseVisualStyleBackColor = true;
            this.chkNotDepartment.CheckedChanged += new System.EventHandler(this.chkNotDepartment_CheckedChanged);
            // 
            // btnOrganize
            // 
            this.btnOrganize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrganize.Enabled = false;
            this.btnOrganize.Location = new System.Drawing.Point(779, 9);
            this.btnOrganize.Name = "btnOrganize";
            this.btnOrganize.Size = new System.Drawing.Size(124, 23);
            this.btnOrganize.TabIndex = 29;
            this.btnOrganize.Text = "组织机构管理...";
            this.btnOrganize.UseVisualStyleBackColor = true;
            this.btnOrganize.Click += new System.EventHandler(this.btnOrganize_Click);
            // 
            // FrmStaffAdmin
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1046, 536);
            this.Controls.Add(this.btnOrganize);
            this.Controls.Add(this.chkNotDepartment);
            this.Controls.Add(this.picExport);
            this.Controls.Add(this.picImport);
            this.Controls.Add(this.picSetting);
            this.Controls.Add(this.picBug);
            this.Controls.Add(this.btnInvertSelect);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.ucTableSort);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.chkNotIsUser);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnBatchSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlStaff);
            this.Controls.Add(this.btnSetPassword);
            this.Controls.Add(this.btnBatchDelete);
            this.Controls.Add(this.btnUserPermission);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmStaffAdmin";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "员工管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmStaffAdmin_FormClosing);
            this.pnlStaff.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStaff)).EndInit();
            this.cMnuStaff.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBug)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBatchSave;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnBatchDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSetPassword;
        private System.Windows.Forms.Panel pnlStaff;
        private System.Windows.Forms.DataGridView grdStaff;
        private System.Windows.Forms.Splitter splOrganize;
        private System.Windows.Forms.TreeView tvOrganize;
        private System.Windows.Forms.ContextMenuStrip cMnuStaff;
        private System.Windows.Forms.ToolStripMenuItem mItmAdd;
        private System.Windows.Forms.ToolStripMenuItem mItmEdit;
        private System.Windows.Forms.ToolStripMenuItem mItmMove;
        private System.Windows.Forms.ToolStripMenuItem mItmDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mItmStaffAdd;
        private System.Windows.Forms.ToolStripMenuItem mItemRoleAdd;
        private System.Windows.Forms.Button btnUserPermission;
        private System.Windows.Forms.ToolStripMenuItem mItemResetSortCode;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private DotNet.WinForm.UCTableSort ucTableSort;
        private System.Windows.Forms.CheckBox chkNotIsUser;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mItmDuty;
        private System.Windows.Forms.ToolStripMenuItem mItmGender;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOfficePhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.ToolStripMenuItem mItmEducation;
        private System.Windows.Forms.ToolStripMenuItem mItmDegree;
        private System.Windows.Forms.ToolStripMenuItem mItmWorkingProperty;
        private System.Windows.Forms.ToolStripMenuItem mItmParty;
        private System.Windows.Forms.ToolStripMenuItem mItmNationality;
        private System.Windows.Forms.ToolStripMenuItem mItmTitle;
        private System.Windows.Forms.Button btnInvertSelect;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.PictureBox picExport;
        private System.Windows.Forms.PictureBox picImport;
        private System.Windows.Forms.PictureBox picSetting;
        private System.Windows.Forms.PictureBox picBug;
        private System.Windows.Forms.CheckBox chkNotDepartment;
        private System.Windows.Forms.Button btnOrganize;


    }
}