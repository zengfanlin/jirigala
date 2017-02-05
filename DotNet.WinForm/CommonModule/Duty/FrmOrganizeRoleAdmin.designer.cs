namespace DotNet.WinForm
{
    partial class FrmOrganizeRoleAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOrganizeRoleAdmin));
            this.btnMove = new System.Windows.Forms.Button();
            this.btnBatchDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlRole = new System.Windows.Forms.Panel();
            this.grdRole = new System.Windows.Forms.DataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splRole = new System.Windows.Forms.Splitter();
            this.tvOrganize = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnBatchSave = new System.Windows.Forms.Button();
            this.cMnuRole = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItmAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmMove = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mItmAddStaff = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmAddOrganize = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRoleUser = new System.Windows.Forms.Button();
            this.btnRolePermission = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ucTableSort = new DotNet.WinForm.UCTableSort();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnInvertSelect = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.pnlRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRole)).BeginInit();
            this.cMnuRole.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMove
            // 
            this.btnMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMove.Location = new System.Drawing.Point(505, 468);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(75, 23);
            this.btnMove.TabIndex = 6;
            this.btnMove.Text = "移动(&M)...";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // btnBatchDelete
            // 
            this.btnBatchDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchDelete.Location = new System.Drawing.Point(583, 468);
            this.btnBatchDelete.Name = "btnBatchDelete";
            this.btnBatchDelete.Size = new System.Drawing.Size(75, 23);
            this.btnBatchDelete.TabIndex = 7;
            this.btnBatchDelete.Text = "删除(&D)";
            this.btnBatchDelete.UseVisualStyleBackColor = true;
            this.btnBatchDelete.Click += new System.EventHandler(this.btnBatchDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(427, 468);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "编辑(&E)...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(895, 468);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(349, 468);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "添加(&A)...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlRole
            // 
            this.pnlRole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRole.Controls.Add(this.grdRole);
            this.pnlRole.Controls.Add(this.splRole);
            this.pnlRole.Controls.Add(this.tvOrganize);
            this.pnlRole.Location = new System.Drawing.Point(8, 43);
            this.pnlRole.Name = "pnlRole";
            this.pnlRole.Size = new System.Drawing.Size(962, 419);
            this.pnlRole.TabIndex = 1;
            // 
            // grdRole
            // 
            this.grdRole.AllowUserToAddRows = false;
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
            this.colRealName,
            this.colEnabled,
            this.colDescription});
            this.grdRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRole.Location = new System.Drawing.Point(263, 0);
            this.grdRole.MultiSelect = false;
            this.grdRole.Name = "grdRole";
            this.grdRole.RowTemplate.Height = 23;
            this.grdRole.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdRole.Size = new System.Drawing.Size(699, 419);
            this.grdRole.TabIndex = 2;
            this.grdRole.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdRole_CellDoubleClick);
            this.grdRole.Sorted += new System.EventHandler(this.grdRole_Sorted);
            this.grdRole.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grdRole_UserDeletingRow);
            this.grdRole.Click += new System.EventHandler(this.grdRole_Click);
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "Selected";
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Width = 50;
            // 
            // colRealName
            // 
            this.colRealName.DataPropertyName = "RealName";
            this.colRealName.HeaderText = "名称";
            this.colRealName.Name = "colRealName";
            this.colRealName.ReadOnly = true;
            this.colRealName.Width = 225;
            // 
            // colEnabled
            // 
            this.colEnabled.DataPropertyName = "Enabled";
            this.colEnabled.HeaderText = "有效";
            this.colEnabled.Name = "colEnabled";
            this.colEnabled.ReadOnly = true;
            this.colEnabled.Width = 80;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colDescription.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDescription.HeaderText = "描述";
            this.colDescription.MaxInputLength = 200;
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 200;
            // 
            // splRole
            // 
            this.splRole.Location = new System.Drawing.Point(260, 0);
            this.splRole.Name = "splRole";
            this.splRole.Size = new System.Drawing.Size(3, 419);
            this.splRole.TabIndex = 2;
            this.splRole.TabStop = false;
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
            this.tvOrganize.Size = new System.Drawing.Size(260, 419);
            this.tvOrganize.TabIndex = 1;
            this.tvOrganize.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvOrganize_ItemDrag);
            this.tvOrganize.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOrganize_AfterSelect);
            this.tvOrganize.Click += new System.EventHandler(this.tvOrganize_Click);
            this.tvOrganize.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvOrganize_DragDrop);
            this.tvOrganize.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvOrganize_DragEnter);
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
            // btnBatchSave
            // 
            this.btnBatchSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchSave.Location = new System.Drawing.Point(817, 468);
            this.btnBatchSave.Name = "btnBatchSave";
            this.btnBatchSave.Size = new System.Drawing.Size(75, 23);
            this.btnBatchSave.TabIndex = 10;
            this.btnBatchSave.Text = "保存(&S)";
            this.btnBatchSave.UseVisualStyleBackColor = true;
            this.btnBatchSave.Click += new System.EventHandler(this.btnBatchSave_Click);
            // 
            // cMnuRole
            // 
            this.cMnuRole.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItmAdd,
            this.mItmEdit,
            this.mItmMove,
            this.mItmDelete,
            this.toolStripSeparator1,
            this.mItmAddStaff,
            this.mItmAddOrganize});
            this.cMnuRole.Name = "cMnuModule";
            this.cMnuRole.Size = new System.Drawing.Size(164, 142);
            // 
            // mItmAdd
            // 
            this.mItmAdd.Name = "mItmAdd";
            this.mItmAdd.Size = new System.Drawing.Size(163, 22);
            this.mItmAdd.Text = "添加岗位(&A)...";
            this.mItmAdd.Click += new System.EventHandler(this.mItmAdd_Click);
            // 
            // mItmEdit
            // 
            this.mItmEdit.Name = "mItmEdit";
            this.mItmEdit.Size = new System.Drawing.Size(163, 22);
            this.mItmEdit.Text = "编辑部门(&E)...";
            this.mItmEdit.Click += new System.EventHandler(this.mItmEdit_Click);
            // 
            // mItmMove
            // 
            this.mItmMove.Name = "mItmMove";
            this.mItmMove.Size = new System.Drawing.Size(163, 22);
            this.mItmMove.Text = "移动部门(&M)...";
            this.mItmMove.Click += new System.EventHandler(this.mItmMove_Click);
            // 
            // mItmDelete
            // 
            this.mItmDelete.Name = "mItmDelete";
            this.mItmDelete.Size = new System.Drawing.Size(163, 22);
            this.mItmDelete.Text = "删除部门(&D)";
            this.mItmDelete.Click += new System.EventHandler(this.mItmDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // mItmAddStaff
            // 
            this.mItmAddStaff.Name = "mItmAddStaff";
            this.mItmAddStaff.Size = new System.Drawing.Size(163, 22);
            this.mItmAddStaff.Text = "添加员工(&S)...";
            this.mItmAddStaff.Click += new System.EventHandler(this.mItmAddStaff_Click);
            // 
            // mItmAddOrganize
            // 
            this.mItmAddOrganize.Name = "mItmAddOrganize";
            this.mItmAddOrganize.Size = new System.Drawing.Size(163, 22);
            this.mItmAddOrganize.Text = "添加子部门(&O)...";
            this.mItmAddOrganize.Click += new System.EventHandler(this.mItmAddOrganize_Click);
            // 
            // btnRoleUser
            // 
            this.btnRoleUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRoleUser.Location = new System.Drawing.Point(661, 468);
            this.btnRoleUser.Name = "btnRoleUser";
            this.btnRoleUser.Size = new System.Drawing.Size(75, 23);
            this.btnRoleUser.TabIndex = 8;
            this.btnRoleUser.Text = "用户(&U)...";
            this.btnRoleUser.UseVisualStyleBackColor = true;
            this.btnRoleUser.Click += new System.EventHandler(this.btnRoleUser_Click);
            // 
            // btnRolePermission
            // 
            this.btnRolePermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRolePermission.Location = new System.Drawing.Point(739, 468);
            this.btnRolePermission.Name = "btnRolePermission";
            this.btnRolePermission.Size = new System.Drawing.Size(75, 23);
            this.btnRolePermission.TabIndex = 9;
            this.btnRolePermission.Text = "权限(&O)...";
            this.btnRolePermission.UseVisualStyleBackColor = true;
            this.btnRolePermission.Click += new System.EventHandler(this.btnRolePermission_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.Location = new System.Drawing.Point(11, 14);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(124, 12);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "查询内容(&C)：";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(138, 11);
            this.txtSearch.MaxLength = 20;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(203, 21);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(346, 11);
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
            this.ucTableSort.Location = new System.Drawing.Point(169, 468);
            this.ucTableSort.Margin = new System.Windows.Forms.Padding(0);
            this.ucTableSort.Name = "ucTableSort";
            this.ucTableSort.OEntityId = null;
            this.ucTableSort.Padding = new System.Windows.Forms.Padding(1);
            this.ucTableSort.SetBottomEnabled = false;
            this.ucTableSort.SetDownEnabled = false;
            this.ucTableSort.SetTopEnabled = false;
            this.ucTableSort.SetUpEnabled = false;
            this.ucTableSort.Size = new System.Drawing.Size(99, 24);
            this.ucTableSort.TabIndex = 3;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(857, 9);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(111, 23);
            this.btnExport.TabIndex = 12;
            this.btnExport.Text = "导出E&xcel...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnInvertSelect
            // 
            this.btnInvertSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvertSelect.Enabled = false;
            this.btnInvertSelect.Location = new System.Drawing.Point(88, 469);
            this.btnInvertSelect.Name = "btnInvertSelect";
            this.btnInvertSelect.Size = new System.Drawing.Size(78, 23);
            this.btnInvertSelect.TabIndex = 19;
            this.btnInvertSelect.Text = "反选";
            this.btnInvertSelect.UseVisualStyleBackColor = true;
            this.btnInvertSelect.Click += new System.EventHandler(this.btnInvertSelect_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Enabled = false;
            this.btnSelectAll.Location = new System.Drawing.Point(7, 469);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(78, 23);
            this.btnSelectAll.TabIndex = 18;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // FrmOrganizeRoleAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(978, 497);
            this.Controls.Add(this.btnInvertSelect);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.ucTableSort);
            this.Controls.Add(this.pnlRole);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnBatchSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRoleUser);
            this.Controls.Add(this.btnRolePermission);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnBatchDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnMove);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Name = "FrmOrganizeRoleAdmin";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "岗位管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmOrganizeRoleAdmin_FormClosing);
            this.pnlRole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRole)).EndInit();
            this.cMnuRole.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnBatchDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlRole;
        private System.Windows.Forms.Splitter splRole;
        private System.Windows.Forms.TreeView tvOrganize;
        private System.Windows.Forms.Button btnBatchSave;
        private System.Windows.Forms.DataGridView grdRole;
        private System.Windows.Forms.ContextMenuStrip cMnuRole;
        private System.Windows.Forms.ToolStripMenuItem mItmAdd;
        private System.Windows.Forms.ToolStripMenuItem mItmEdit;
        private System.Windows.Forms.ToolStripMenuItem mItmMove;
        private System.Windows.Forms.ToolStripMenuItem mItmDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mItmAddStaff;
        private System.Windows.Forms.ToolStripMenuItem mItmAddOrganize;
        private System.Windows.Forms.Button btnRoleUser;
        private System.Windows.Forms.Button btnRolePermission;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private DotNet.WinForm.UCTableSort ucTableSort;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnInvertSelect;
        private System.Windows.Forms.Button btnSelectAll;
    }
}