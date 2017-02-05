namespace DotNet.WinForm
{
    partial class FrmFileAdmin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFileAdmin));
            this.btnBatchSave = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.pnlFolder = new System.Windows.Forms.Panel();
            this.grdFile = new System.Windows.Forms.DataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColReadCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModifiedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModifiedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splFolder = new System.Windows.Forms.Splitter();
            this.tvFolder = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnBatchDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cMnuFolder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItmAddFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmAddFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmEditFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmMoveFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmDeleteFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmAddRootFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mItmFrmFolderAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.ucTableSort = new DotNet.WinForm.UCTableSort();
            this.btnFolderAdmin = new System.Windows.Forms.Button();
            this.btnInvertSelect = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.pnlFolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFile)).BeginInit();
            this.cMnuFolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBatchSave
            // 
            this.btnBatchSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchSave.Location = new System.Drawing.Point(694, 528);
            this.btnBatchSave.Name = "btnBatchSave";
            this.btnBatchSave.Size = new System.Drawing.Size(75, 23);
            this.btnBatchSave.TabIndex = 8;
            this.btnBatchSave.Text = "保存(&S)";
            this.btnBatchSave.UseVisualStyleBackColor = true;
            this.btnBatchSave.Click += new System.EventHandler(this.btnBatchSave_Click);
            // 
            // btnMove
            // 
            this.btnMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMove.Location = new System.Drawing.Point(532, 528);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(75, 23);
            this.btnMove.TabIndex = 6;
            this.btnMove.Text = "移动(&M)...";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // pnlFolder
            // 
            this.pnlFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFolder.Controls.Add(this.grdFile);
            this.pnlFolder.Controls.Add(this.splFolder);
            this.pnlFolder.Controls.Add(this.tvFolder);
            this.pnlFolder.Location = new System.Drawing.Point(8, 65);
            this.pnlFolder.Name = "pnlFolder";
            this.pnlFolder.Size = new System.Drawing.Size(956, 457);
            this.pnlFolder.TabIndex = 1;
            // 
            // grdFile
            // 
            this.grdFile.AllowDrop = true;
            this.grdFile.AllowUserToAddRows = false;
            this.grdFile.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdFile.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colFileName,
            this.colFileSize,
            this.ColReadCount,
            this.colModifiedBy,
            this.colModifiedOn,
            this.colDescription});
            this.grdFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFile.Location = new System.Drawing.Point(263, 0);
            this.grdFile.MultiSelect = false;
            this.grdFile.Name = "grdFile";
            this.grdFile.RowTemplate.Height = 23;
            this.grdFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFile.Size = new System.Drawing.Size(693, 457);
            this.grdFile.TabIndex = 1;
            this.grdFile.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFile_CellDoubleClick);
            this.grdFile.Sorted += new System.EventHandler(this.grdFile_Sorted);
            this.grdFile.Click += new System.EventHandler(this.grdFile_Click);
            this.grdFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdFile_DragDrop);
            this.grdFile.DragOver += new System.Windows.Forms.DragEventHandler(this.grdFile_DragOver);
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "Selected";
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Width = 55;
            // 
            // colFileName
            // 
            this.colFileName.DataPropertyName = "FileName";
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            this.colFileName.DefaultCellStyle = dataGridViewCellStyle2;
            this.colFileName.Frozen = true;
            this.colFileName.HeaderText = "文件名";
            this.colFileName.MaxInputLength = 200;
            this.colFileName.Name = "colFileName";
            this.colFileName.ReadOnly = true;
            this.colFileName.Width = 170;
            // 
            // colFileSize
            // 
            this.colFileSize.DataPropertyName = "FileFriendlySize";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colFileSize.DefaultCellStyle = dataGridViewCellStyle3;
            this.colFileSize.FillWeight = 60F;
            this.colFileSize.HeaderText = "大小";
            this.colFileSize.MaxInputLength = 20;
            this.colFileSize.Name = "colFileSize";
            this.colFileSize.ReadOnly = true;
            this.colFileSize.Width = 60;
            // 
            // ColReadCount
            // 
            this.ColReadCount.DataPropertyName = "ReadCount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = "1";
            this.ColReadCount.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColReadCount.FillWeight = 50F;
            this.ColReadCount.HeaderText = "下载";
            this.ColReadCount.MaxInputLength = 20;
            this.ColReadCount.Name = "ColReadCount";
            this.ColReadCount.ReadOnly = true;
            this.ColReadCount.Width = 50;
            // 
            // colModifiedBy
            // 
            this.colModifiedBy.DataPropertyName = "ModifiedBy";
            this.colModifiedBy.FillWeight = 60F;
            this.colModifiedBy.HeaderText = "修改人";
            this.colModifiedBy.MaxInputLength = 20;
            this.colModifiedBy.Name = "colModifiedBy";
            this.colModifiedBy.ReadOnly = true;
            this.colModifiedBy.Width = 60;
            // 
            // colModifiedOn
            // 
            this.colModifiedOn.DataPropertyName = "ModifiedOn";
            this.colModifiedOn.HeaderText = "修改时间";
            this.colModifiedOn.MaxInputLength = 20;
            this.colModifiedOn.Name = "colModifiedOn";
            this.colModifiedOn.ReadOnly = true;
            this.colModifiedOn.Width = 110;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "DESCRIPTION";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colDescription.DefaultCellStyle = dataGridViewCellStyle5;
            this.colDescription.HeaderText = "描述";
            this.colDescription.MaxInputLength = 200;
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 125;
            // 
            // splFolder
            // 
            this.splFolder.Location = new System.Drawing.Point(260, 0);
            this.splFolder.Name = "splFolder";
            this.splFolder.Size = new System.Drawing.Size(3, 457);
            this.splFolder.TabIndex = 8;
            this.splFolder.TabStop = false;
            // 
            // tvFolder
            // 
            this.tvFolder.AllowDrop = true;
            this.tvFolder.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvFolder.ImageIndex = 0;
            this.tvFolder.ImageList = this.imageList;
            this.tvFolder.Location = new System.Drawing.Point(0, 0);
            this.tvFolder.Name = "tvFolder";
            this.tvFolder.SelectedImageIndex = 1;
            this.tvFolder.Size = new System.Drawing.Size(260, 457);
            this.tvFolder.TabIndex = 0;
            this.tvFolder.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvFolder_ItemDrag);
            this.tvFolder.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFolder_AfterSelect);
            this.tvFolder.Click += new System.EventHandler(this.tvFolder_Click);
            this.tvFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvFolder_DragDrop);
            this.tvFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvFolder_DragEnter);
            this.tvFolder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvFolder_MouseDown);
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
            // btnBatchDelete
            // 
            this.btnBatchDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchDelete.Location = new System.Drawing.Point(613, 528);
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
            this.btnEdit.Location = new System.Drawing.Point(451, 528);
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
            this.btnClose.Location = new System.Drawing.Point(879, 528);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(370, 528);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "添加(&A)...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cMnuFolder
            // 
            this.cMnuFolder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItmAddFile,
            this.mItmAddFolder,
            this.mItmEditFolder,
            this.mItmMoveFolder,
            this.mItmDeleteFolder,
            this.mItmAddRootFolder,
            this.toolStripSeparator1,
            this.mItmFrmFolderAdmin});
            this.cMnuFolder.Name = "cMnuModule";
            this.cMnuFolder.Size = new System.Drawing.Size(174, 186);
            // 
            // mItmAddFile
            // 
            this.mItmAddFile.Name = "mItmAddFile";
            this.mItmAddFile.Size = new System.Drawing.Size(173, 22);
            this.mItmAddFile.Text = "添加文本文档...";
            this.mItmAddFile.Click += new System.EventHandler(this.mItmAddFile_Click);
            // 
            // mItmAddFolder
            // 
            this.mItmAddFolder.Name = "mItmAddFolder";
            this.mItmAddFolder.Size = new System.Drawing.Size(173, 22);
            this.mItmAddFolder.Text = "添加文件夹(&A)...";
            this.mItmAddFolder.Click += new System.EventHandler(this.mItmAddFolder_Click);
            // 
            // mItmEditFolder
            // 
            this.mItmEditFolder.Name = "mItmEditFolder";
            this.mItmEditFolder.Size = new System.Drawing.Size(173, 22);
            this.mItmEditFolder.Text = "编辑文件夹(&E)...";
            this.mItmEditFolder.Click += new System.EventHandler(this.mItmEdit_Click);
            // 
            // mItmMoveFolder
            // 
            this.mItmMoveFolder.Name = "mItmMoveFolder";
            this.mItmMoveFolder.Size = new System.Drawing.Size(173, 22);
            this.mItmMoveFolder.Text = "移动文件夹(&M)...";
            this.mItmMoveFolder.Click += new System.EventHandler(this.mItmMove_Click);
            // 
            // mItmDeleteFolder
            // 
            this.mItmDeleteFolder.Name = "mItmDeleteFolder";
            this.mItmDeleteFolder.Size = new System.Drawing.Size(173, 22);
            this.mItmDeleteFolder.Text = "删除文件夹(&D)";
            this.mItmDeleteFolder.Click += new System.EventHandler(this.mItmDelete_Click);
            // 
            // mItmAddRootFolder
            // 
            this.mItmAddRootFolder.Name = "mItmAddRootFolder";
            this.mItmAddRootFolder.Size = new System.Drawing.Size(173, 22);
            this.mItmAddRootFolder.Text = "添加根文件夹(&R)...";
            this.mItmAddRootFolder.Click += new System.EventHandler(this.mItmAddRootFolder_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
            // 
            // mItmFrmFolderAdmin
            // 
            this.mItmFrmFolderAdmin.Name = "mItmFrmFolderAdmin";
            this.mItmFrmFolderAdmin.Size = new System.Drawing.Size(173, 22);
            this.mItmFrmFolderAdmin.Text = "文件夹管理(&F)...";
            this.mItmFrmFolderAdmin.Click += new System.EventHandler(this.mItmFrmFolderAdmin_Click);
            // 
            // ucTableSort
            // 
            this.ucTableSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ucTableSort.Location = new System.Drawing.Point(175, 526);
            this.ucTableSort.Margin = new System.Windows.Forms.Padding(0);
            this.ucTableSort.Name = "ucTableSort";
            this.ucTableSort.OEntityId = null;
            this.ucTableSort.Padding = new System.Windows.Forms.Padding(1);
            this.ucTableSort.SetBottomEnabled = false;
            this.ucTableSort.SetDownEnabled = false;
            this.ucTableSort.SetTopEnabled = false;
            this.ucTableSort.SetUpEnabled = false;
            this.ucTableSort.Size = new System.Drawing.Size(99, 24);
            this.ucTableSort.TabIndex = 0;
            // 
            // btnFolderAdmin
            // 
            this.btnFolderAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFolderAdmin.Location = new System.Drawing.Point(775, 528);
            this.btnFolderAdmin.Name = "btnFolderAdmin";
            this.btnFolderAdmin.Size = new System.Drawing.Size(98, 23);
            this.btnFolderAdmin.TabIndex = 9;
            this.btnFolderAdmin.Text = "文件夹(&F)...";
            this.btnFolderAdmin.UseVisualStyleBackColor = true;
            this.btnFolderAdmin.Click += new System.EventHandler(this.btnFolderAdmin_Click);
            // 
            // btnInvertSelect
            // 
            this.btnInvertSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvertSelect.Location = new System.Drawing.Point(91, 528);
            this.btnInvertSelect.Name = "btnInvertSelect";
            this.btnInvertSelect.Size = new System.Drawing.Size(78, 23);
            this.btnInvertSelect.TabIndex = 3;
            this.btnInvertSelect.Text = "反选";
            this.btnInvertSelect.UseVisualStyleBackColor = true;
            this.btnInvertSelect.Click += new System.EventHandler(this.btnInvertSelect_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Location = new System.Drawing.Point(7, 528);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(78, 23);
            this.btnSelectAll.TabIndex = 2;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(835, 21);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(111, 23);
            this.btnExport.TabIndex = 11;
            this.btnExport.Text = "导出E&xcel...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // FrmFileAdmin
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DotNet.WinForm.Properties.Resources.Head;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(957, 554);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnInvertSelect);
            this.Controls.Add(this.ucTableSort);
            this.Controls.Add(this.pnlFolder);
            this.Controls.Add(this.btnFolderAdmin);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnBatchDelete);
            this.Controls.Add(this.btnBatchSave);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MinimumSize = new System.Drawing.Size(375, 288);
            this.Name = "FrmFileAdmin";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "文档管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmFolderAdmin_FormClosing);
            this.pnlFolder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFile)).EndInit();
            this.cMnuFolder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBatchSave;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Panel pnlFolder;
        private System.Windows.Forms.Splitter splFolder;
        private System.Windows.Forms.TreeView tvFolder;
        private System.Windows.Forms.Button btnBatchDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ContextMenuStrip cMnuFolder;
        private System.Windows.Forms.ToolStripMenuItem mItmAddRootFolder;
        private System.Windows.Forms.ToolStripMenuItem mItmEditFolder;
        private System.Windows.Forms.ToolStripMenuItem mItmMoveFolder;
        private System.Windows.Forms.ToolStripMenuItem mItmDeleteFolder;
        private System.Windows.Forms.DataGridView grdFile;
        private DotNet.WinForm.UCTableSort ucTableSort;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mItmFrmFolderAdmin;
        private System.Windows.Forms.Button btnFolderAdmin;
        private System.Windows.Forms.ToolStripMenuItem mItmAddFolder;
        private System.Windows.Forms.Button btnInvertSelect;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.ToolStripMenuItem mItmAddFile;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColReadCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModifiedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModifiedOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.Button btnExport;
    }
}