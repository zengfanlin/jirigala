namespace DotNet.WinForm
{
    partial class MDIMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIMainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSetTop = new System.Windows.Forms.ToolStripButton();
            this.tsbSetUp = new System.Windows.Forms.ToolStripButton();
            this.tsbSetDown = new System.Windows.Forms.ToolStripButton();
            this.tsbSetBottom = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.pnlModule = new System.Windows.Forms.Panel();
            this.tvModule = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnLogOnWeb = new System.Windows.Forms.Button();
            this.btnFrmUserAdmin = new System.Windows.Forms.Button();
            this.btnFrmModuleAdmin = new System.Windows.Forms.Button();
            this.btnFrmOrganizeAdmin = new System.Windows.Forms.Button();
            this.btnFrmRoleAdmin = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btnFrmPermissionItemAdmin = new System.Windows.Forms.Button();
            this.tmrLock = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.pnlModule.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSetTop,
            this.tsbSetUp,
            this.tsbSetDown,
            this.tsbSetBottom,
            this.toolStripSeparator1,
            this.tsbAdd,
            this.tsbEdit,
            this.tsbDelete,
            this.tsbSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(876, 25);
            this.toolStrip1.TabIndex = 4;
            // 
            // tsbSetTop
            // 
            this.tsbSetTop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSetTop.Enabled = false;
            this.tsbSetTop.Image = ((System.Drawing.Image)(resources.GetObject("tsbSetTop.Image")));
            this.tsbSetTop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSetTop.Name = "tsbSetTop";
            this.tsbSetTop.Size = new System.Drawing.Size(23, 22);
            this.tsbSetTop.Text = "Set Top";
            this.tsbSetTop.ToolTipText = "Set Top";
            this.tsbSetTop.Click += new System.EventHandler(this.tsbSetTop_Click);
            // 
            // tsbSetUp
            // 
            this.tsbSetUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSetUp.Enabled = false;
            this.tsbSetUp.Image = ((System.Drawing.Image)(resources.GetObject("tsbSetUp.Image")));
            this.tsbSetUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSetUp.Name = "tsbSetUp";
            this.tsbSetUp.Size = new System.Drawing.Size(23, 22);
            this.tsbSetUp.Text = "Set Up";
            this.tsbSetUp.ToolTipText = "Set Up";
            this.tsbSetUp.Click += new System.EventHandler(this.tsbSetUp_Click);
            // 
            // tsbSetDown
            // 
            this.tsbSetDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSetDown.Enabled = false;
            this.tsbSetDown.Image = ((System.Drawing.Image)(resources.GetObject("tsbSetDown.Image")));
            this.tsbSetDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSetDown.Name = "tsbSetDown";
            this.tsbSetDown.Size = new System.Drawing.Size(23, 22);
            this.tsbSetDown.Text = "Set Down";
            this.tsbSetDown.ToolTipText = "Set Down";
            this.tsbSetDown.Click += new System.EventHandler(this.tsbSetDown_Click);
            // 
            // tsbSetBottom
            // 
            this.tsbSetBottom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSetBottom.Enabled = false;
            this.tsbSetBottom.Image = ((System.Drawing.Image)(resources.GetObject("tsbSetBottom.Image")));
            this.tsbSetBottom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSetBottom.Name = "tsbSetBottom";
            this.tsbSetBottom.Size = new System.Drawing.Size(23, 22);
            this.tsbSetBottom.Text = "Set Bottom";
            this.tsbSetBottom.ToolTipText = "Set Bottom";
            this.tsbSetBottom.Click += new System.EventHandler(this.tsbSetBottom_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbAdd
            // 
            this.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAdd.Enabled = false;
            this.tsbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdd.Image")));
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(23, 22);
            this.tsbAdd.Text = "Add";
            this.tsbAdd.ToolTipText = "Add";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // tsbEdit
            // 
            this.tsbEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEdit.Enabled = false;
            this.tsbEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbEdit.Image")));
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(23, 22);
            this.tsbEdit.Text = "Edit";
            this.tsbEdit.ToolTipText = "Edit";
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelete.Enabled = false;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(23, 22);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.ToolTipText = "Delete";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Enabled = false;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(23, 22);
            this.tsbSave.Text = "Save";
            this.tsbSave.ToolTipText = "Save";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // pnlModule
            // 
            this.pnlModule.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlModule.Controls.Add(this.tvModule);
            this.pnlModule.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlModule.Location = new System.Drawing.Point(0, 25);
            this.pnlModule.Name = "pnlModule";
            this.pnlModule.Size = new System.Drawing.Size(228, 513);
            this.pnlModule.TabIndex = 8;
            // 
            // tvModule
            // 
            this.tvModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvModule.ImageIndex = 0;
            this.tvModule.ImageList = this.imageList;
            this.tvModule.Location = new System.Drawing.Point(0, 0);
            this.tvModule.Name = "tvModule";
            this.tvModule.SelectedImageIndex = 0;
            this.tvModule.Size = new System.Drawing.Size(224, 509);
            this.tvModule.TabIndex = 0;
            this.tvModule.DoubleClick += new System.EventHandler(this.tvModule_DoubleClick);
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
            // btnLogOnWeb
            // 
            this.btnLogOnWeb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogOnWeb.Location = new System.Drawing.Point(650, 355);
            this.btnLogOnWeb.Name = "btnLogOnWeb";
            this.btnLogOnWeb.Size = new System.Drawing.Size(214, 23);
            this.btnLogOnWeb.TabIndex = 9;
            this.btnLogOnWeb.Text = "LogOn Web";
            this.btnLogOnWeb.UseVisualStyleBackColor = true;
            this.btnLogOnWeb.Click += new System.EventHandler(this.btnLogOnWeb_Click);
            // 
            // btnFrmUserAdmin
            // 
            this.btnFrmUserAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFrmUserAdmin.Location = new System.Drawing.Point(649, 439);
            this.btnFrmUserAdmin.Name = "btnFrmUserAdmin";
            this.btnFrmUserAdmin.Size = new System.Drawing.Size(215, 23);
            this.btnFrmUserAdmin.TabIndex = 8;
            this.btnFrmUserAdmin.Tag = "DotNet.WinForm.User";
            this.btnFrmUserAdmin.Text = "FrmUserAdmin";
            this.btnFrmUserAdmin.UseVisualStyleBackColor = true;
            this.btnFrmUserAdmin.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnFrmModuleAdmin
            // 
            this.btnFrmModuleAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFrmModuleAdmin.Location = new System.Drawing.Point(649, 483);
            this.btnFrmModuleAdmin.Name = "btnFrmModuleAdmin";
            this.btnFrmModuleAdmin.Size = new System.Drawing.Size(215, 23);
            this.btnFrmModuleAdmin.TabIndex = 5;
            this.btnFrmModuleAdmin.Tag = "DotNet.WinForm.Module";
            this.btnFrmModuleAdmin.Text = "FrmModuleAdmin";
            this.btnFrmModuleAdmin.UseVisualStyleBackColor = true;
            this.btnFrmModuleAdmin.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnFrmOrganizeAdmin
            // 
            this.btnFrmOrganizeAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFrmOrganizeAdmin.Location = new System.Drawing.Point(649, 417);
            this.btnFrmOrganizeAdmin.Name = "btnFrmOrganizeAdmin";
            this.btnFrmOrganizeAdmin.Size = new System.Drawing.Size(215, 23);
            this.btnFrmOrganizeAdmin.TabIndex = 1;
            this.btnFrmOrganizeAdmin.Tag = "DotNet.WinForm.Organize";
            this.btnFrmOrganizeAdmin.Text = "FrmOrganizeAdmin";
            this.btnFrmOrganizeAdmin.UseVisualStyleBackColor = true;
            this.btnFrmOrganizeAdmin.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnFrmRoleAdmin
            // 
            this.btnFrmRoleAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFrmRoleAdmin.Location = new System.Drawing.Point(649, 461);
            this.btnFrmRoleAdmin.Name = "btnFrmRoleAdmin";
            this.btnFrmRoleAdmin.Size = new System.Drawing.Size(215, 23);
            this.btnFrmRoleAdmin.TabIndex = 0;
            this.btnFrmRoleAdmin.Tag = "DotNet.WinForm.Role";
            this.btnFrmRoleAdmin.Text = "FrmRoleAdmin";
            this.btnFrmRoleAdmin.UseVisualStyleBackColor = true;
            this.btnFrmRoleAdmin.Click += new System.EventHandler(this.btn_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(228, 25);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 513);
            this.splitter1.TabIndex = 9;
            this.splitter1.TabStop = false;
            // 
            // btnFrmPermissionItemAdmin
            // 
            this.btnFrmPermissionItemAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFrmPermissionItemAdmin.Location = new System.Drawing.Point(649, 505);
            this.btnFrmPermissionItemAdmin.Name = "btnFrmPermissionItemAdmin";
            this.btnFrmPermissionItemAdmin.Size = new System.Drawing.Size(215, 23);
            this.btnFrmPermissionItemAdmin.TabIndex = 11;
            this.btnFrmPermissionItemAdmin.Tag = "DotNet.WinForm.PermissionItem";
            this.btnFrmPermissionItemAdmin.Text = "FrmPermissionItemAdmin";
            this.btnFrmPermissionItemAdmin.UseVisualStyleBackColor = true;
            this.btnFrmPermissionItemAdmin.Click += new System.EventHandler(this.btn_Click);
            // 
            // tmrLock
            // 
            this.tmrLock.Interval = 10000;
            // 
            // MDIMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 538);
            this.Controls.Add(this.btnFrmPermissionItemAdmin);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlModule);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnLogOnWeb);
            this.Controls.Add(this.btnFrmUserAdmin);
            this.Controls.Add(this.btnFrmModuleAdmin);
            this.Controls.Add(this.btnFrmRoleAdmin);
            this.Controls.Add(this.btnFrmOrganizeAdmin);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.IsMdiContainer = true;
            this.Name = "MDIMainForm";
            this.Text = ".NET通用快速开发架构";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MDIMainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MDIMainForm_FormClosed);
            this.Load += new System.EventHandler(this.MDIMainForm_Load);
            this.MdiChildActivate += new System.EventHandler(this.MDIMainForm_MdiChildActivate);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlModule.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSetTop;
        private System.Windows.Forms.ToolStripButton tsbSetUp;
        private System.Windows.Forms.ToolStripButton tsbSetDown;
        private System.Windows.Forms.ToolStripButton tsbSetBottom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.Panel pnlModule;
        private System.Windows.Forms.Button btnFrmOrganizeAdmin;
        private System.Windows.Forms.Button btnFrmRoleAdmin;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button btnFrmModuleAdmin;
        private System.Windows.Forms.Button btnFrmUserAdmin;
        private System.Windows.Forms.Button btnLogOnWeb;
        private System.Windows.Forms.TreeView tvModule;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button btnFrmPermissionItemAdmin;
        private System.Windows.Forms.Timer tmrLock;


    }
}