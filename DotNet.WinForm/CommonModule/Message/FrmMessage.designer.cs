namespace DotNet.WinForm
{
    partial class FrmMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMessage));
            this.tvOrganize = new System.Windows.Forms.TreeView();
            this.cMnuUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mitmFrmMessageSend = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmFrmWorkReportAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmFrmWorkReportList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mitmFrmUserPermission = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmFrmUserEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmFrmUserRoleAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmFrmUserPermissionAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mitmApplicationRole = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmUserGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mitmFrmStaffAddressEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmFrmLogByUser = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.tcMessage = new System.Windows.Forms.TabControl();
            this.tpOrganize = new System.Windows.Forms.TabPage();
            this.tpApplicationRole = new System.Windows.Forms.TabPage();
            this.tvApplicationRole = new System.Windows.Forms.TreeView();
            this.tpUserGroup = new System.Windows.Forms.TabPage();
            this.tvUserGroup = new System.Windows.Forms.TreeView();
            this.picHome = new System.Windows.Forms.PictureBox();
            this.picAddress = new System.Windows.Forms.PictureBox();
            this.picOA = new System.Windows.Forms.PictureBox();
            this.picDocument = new System.Windows.Forms.PictureBox();
            this.picShareAnIdea = new System.Windows.Forms.PictureBox();
            this.cMnuUser.SuspendLayout();
            this.tcMessage.SuspendLayout();
            this.tpOrganize.SuspendLayout();
            this.tpApplicationRole.SuspendLayout();
            this.tpUserGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShareAnIdea)).BeginInit();
            this.SuspendLayout();
            // 
            // tvOrganize
            // 
            this.tvOrganize.AllowDrop = true;
            this.tvOrganize.ContextMenuStrip = this.cMnuUser;
            this.tvOrganize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvOrganize.ImageIndex = 0;
            this.tvOrganize.ImageList = this.imageList;
            this.tvOrganize.Location = new System.Drawing.Point(0, 0);
            this.tvOrganize.Name = "tvOrganize";
            this.tvOrganize.SelectedImageIndex = 0;
            this.tvOrganize.Size = new System.Drawing.Size(263, 486);
            this.tvOrganize.TabIndex = 1;
            this.tvOrganize.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvOrganize_ItemDrag);
            this.tvOrganize.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTree_AfterSelect);
            this.tvOrganize.Click += new System.EventHandler(this.tvTree_Click);
            this.tvOrganize.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvOrganize_DragDrop);
            this.tvOrganize.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvOrganize_DragEnter);
            this.tvOrganize.DoubleClick += new System.EventHandler(this.tvTree_DoubleClick);
            this.tvOrganize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvTreeView_MouseDown);
            // 
            // cMnuUser
            // 
            this.cMnuUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitmFrmMessageSend,
            this.mitmFrmWorkReportAdd,
            this.mitmFrmWorkReportList,
            this.toolStripSeparator1,
            this.mitmFrmUserPermission,
            this.mitmFrmUserEdit,
            this.mitmFrmUserRoleAdmin,
            this.mitmFrmUserPermissionAdmin,
            this.toolStripSeparator2,
            this.mitmApplicationRole,
            this.mitmUserGroup,
            this.toolStripSeparator3,
            this.mitmFrmStaffAddressEdit,
            this.mitmFrmLogByUser});
            this.cMnuUser.Name = "contextMenuStrip";
            this.cMnuUser.Size = new System.Drawing.Size(158, 264);
            // 
            // mitmFrmMessageSend
            // 
            this.mitmFrmMessageSend.Name = "mitmFrmMessageSend";
            this.mitmFrmMessageSend.Size = new System.Drawing.Size(157, 22);
            this.mitmFrmMessageSend.Text = "发送消息...";
            this.mitmFrmMessageSend.Click += new System.EventHandler(this.mitmFrmMessageSend_Click);
            // 
            // mitmFrmWorkReportAdd
            // 
            this.mitmFrmWorkReportAdd.Name = "mitmFrmWorkReportAdd";
            this.mitmFrmWorkReportAdd.Size = new System.Drawing.Size(157, 22);
            this.mitmFrmWorkReportAdd.Text = "分配工作任务...";
            this.mitmFrmWorkReportAdd.Visible = false;
            this.mitmFrmWorkReportAdd.Click += new System.EventHandler(this.mitmFrmWorkReportAdd_Click);
            // 
            // mitmFrmWorkReportList
            // 
            this.mitmFrmWorkReportList.Name = "mitmFrmWorkReportList";
            this.mitmFrmWorkReportList.Size = new System.Drawing.Size(157, 22);
            this.mitmFrmWorkReportList.Text = "查看工作日志...";
            this.mitmFrmWorkReportList.Visible = false;
            this.mitmFrmWorkReportList.Click += new System.EventHandler(this.mitmFrmWorkReportList_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // mitmFrmUserPermission
            // 
            this.mitmFrmUserPermission.Enabled = false;
            this.mitmFrmUserPermission.Name = "mitmFrmUserPermission";
            this.mitmFrmUserPermission.Size = new System.Drawing.Size(157, 22);
            this.mitmFrmUserPermission.Text = "查看用户权限...";
            this.mitmFrmUserPermission.Visible = false;
            this.mitmFrmUserPermission.Click += new System.EventHandler(this.mitmFrmUserPermission_Click);
            // 
            // mitmFrmUserEdit
            // 
            this.mitmFrmUserEdit.Enabled = false;
            this.mitmFrmUserEdit.Name = "mitmFrmUserEdit";
            this.mitmFrmUserEdit.Size = new System.Drawing.Size(157, 22);
            this.mitmFrmUserEdit.Text = "编辑用户信息...";
            this.mitmFrmUserEdit.Click += new System.EventHandler(this.mitmFrmUserEdit_Click);
            // 
            // mitmFrmUserRoleAdmin
            // 
            this.mitmFrmUserRoleAdmin.Enabled = false;
            this.mitmFrmUserRoleAdmin.Name = "mitmFrmUserRoleAdmin";
            this.mitmFrmUserRoleAdmin.Size = new System.Drawing.Size(157, 22);
            this.mitmFrmUserRoleAdmin.Text = "用户角色...";
            this.mitmFrmUserRoleAdmin.Click += new System.EventHandler(this.mitmFrmUserRoleAdmin_Click);
            // 
            // mitmFrmUserPermissionAdmin
            // 
            this.mitmFrmUserPermissionAdmin.Enabled = false;
            this.mitmFrmUserPermissionAdmin.Name = "mitmFrmUserPermissionAdmin";
            this.mitmFrmUserPermissionAdmin.Size = new System.Drawing.Size(157, 22);
            this.mitmFrmUserPermissionAdmin.Text = "用户权限...";
            this.mitmFrmUserPermissionAdmin.Click += new System.EventHandler(this.mitmFrmUserPermissionAdmin_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(154, 6);
            // 
            // mitmApplicationRole
            // 
            this.mitmApplicationRole.Enabled = false;
            this.mitmApplicationRole.Name = "mitmApplicationRole";
            this.mitmApplicationRole.Size = new System.Drawing.Size(157, 22);
            this.mitmApplicationRole.Text = "业务角色管理";
            this.mitmApplicationRole.Click += new System.EventHandler(this.mitmApplicationRole_Click);
            // 
            // mitmUserGroup
            // 
            this.mitmUserGroup.Name = "mitmUserGroup";
            this.mitmUserGroup.Size = new System.Drawing.Size(157, 22);
            this.mitmUserGroup.Text = "用户群组管理";
            this.mitmUserGroup.Click += new System.EventHandler(this.mitmUserGroup_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(154, 6);
            // 
            // mitmFrmStaffAddressEdit
            // 
            this.mitmFrmStaffAddressEdit.Enabled = false;
            this.mitmFrmStaffAddressEdit.Name = "mitmFrmStaffAddressEdit";
            this.mitmFrmStaffAddressEdit.Size = new System.Drawing.Size(157, 22);
            this.mitmFrmStaffAddressEdit.Text = "内部通讯录...";
            this.mitmFrmStaffAddressEdit.Click += new System.EventHandler(this.mitmFrmStaffAddressEdit_Click);
            // 
            // mitmFrmLogByUser
            // 
            this.mitmFrmLogByUser.Enabled = false;
            this.mitmFrmLogByUser.Name = "mitmFrmLogByUser";
            this.mitmFrmLogByUser.Size = new System.Drawing.Size(157, 22);
            this.mitmFrmLogByUser.Text = "系统操作日志...";
            this.mitmFrmLogByUser.Click += new System.EventHandler(this.mitmFrmLogByUser_Click);
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
            this.imageList.Images.SetKeyName(15, "icon_messenger0.gif");
            this.imageList.Images.SetKeyName(16, "icon_messenger1.gif");
            this.imageList.Images.SetKeyName(17, "icon_messenger2.gif");
            this.imageList.Images.SetKeyName(18, "icon_messenger3.gif");
            this.imageList.Images.SetKeyName(19, "icon_messenger4.gif");
            this.imageList.Images.SetKeyName(20, "icon_messenger5.gif");
            this.imageList.Images.SetKeyName(21, "icon_messenger6.gif");
            this.imageList.Images.SetKeyName(22, "Organize.gif");
            this.imageList.Images.SetKeyName(23, "Role.gif");
            this.imageList.Images.SetKeyName(24, "StaffAddress.gif");
            this.imageList.Images.SetKeyName(25, "Tree.jpg");
            // 
            // tcMessage
            // 
            this.tcMessage.Controls.Add(this.tpOrganize);
            this.tcMessage.Controls.Add(this.tpApplicationRole);
            this.tcMessage.Controls.Add(this.tpUserGroup);
            this.tcMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMessage.ImageList = this.imageList;
            this.tcMessage.Location = new System.Drawing.Point(0, 58);
            this.tcMessage.Multiline = true;
            this.tcMessage.Name = "tcMessage";
            this.tcMessage.SelectedIndex = 0;
            this.tcMessage.Size = new System.Drawing.Size(271, 513);
            this.tcMessage.TabIndex = 2;
            // 
            // tpOrganize
            // 
            this.tpOrganize.Controls.Add(this.tvOrganize);
            this.tpOrganize.ImageIndex = 22;
            this.tpOrganize.Location = new System.Drawing.Point(4, 23);
            this.tpOrganize.Margin = new System.Windows.Forms.Padding(0);
            this.tpOrganize.Name = "tpOrganize";
            this.tpOrganize.Size = new System.Drawing.Size(263, 486);
            this.tpOrganize.TabIndex = 0;
            this.tpOrganize.Text = "组织";
            this.tpOrganize.ToolTipText = "组织机构";
            this.tpOrganize.UseVisualStyleBackColor = true;
            // 
            // tpApplicationRole
            // 
            this.tpApplicationRole.Controls.Add(this.tvApplicationRole);
            this.tpApplicationRole.ImageKey = "Role.gif";
            this.tpApplicationRole.Location = new System.Drawing.Point(4, 23);
            this.tpApplicationRole.Margin = new System.Windows.Forms.Padding(0);
            this.tpApplicationRole.Name = "tpApplicationRole";
            this.tpApplicationRole.Size = new System.Drawing.Size(263, 449);
            this.tpApplicationRole.TabIndex = 1;
            this.tpApplicationRole.Text = "角色";
            this.tpApplicationRole.ToolTipText = "业务角色";
            this.tpApplicationRole.UseVisualStyleBackColor = true;
            // 
            // tvApplicationRole
            // 
            this.tvApplicationRole.AllowDrop = true;
            this.tvApplicationRole.ContextMenuStrip = this.cMnuUser;
            this.tvApplicationRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvApplicationRole.ImageIndex = 0;
            this.tvApplicationRole.ImageList = this.imageList;
            this.tvApplicationRole.Location = new System.Drawing.Point(0, 0);
            this.tvApplicationRole.Name = "tvApplicationRole";
            this.tvApplicationRole.SelectedImageIndex = 0;
            this.tvApplicationRole.Size = new System.Drawing.Size(263, 479);
            this.tvApplicationRole.TabIndex = 2;
            this.tvApplicationRole.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTree_AfterSelect);
            this.tvApplicationRole.Click += new System.EventHandler(this.tvTree_Click);
            this.tvApplicationRole.DoubleClick += new System.EventHandler(this.tvTree_DoubleClick);
            this.tvApplicationRole.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvTreeView_MouseDown);
            // 
            // tpUserGroup
            // 
            this.tpUserGroup.Controls.Add(this.tvUserGroup);
            this.tpUserGroup.ImageKey = "StaffAddress.gif";
            this.tpUserGroup.Location = new System.Drawing.Point(4, 23);
            this.tpUserGroup.Margin = new System.Windows.Forms.Padding(0);
            this.tpUserGroup.Name = "tpUserGroup";
            this.tpUserGroup.Size = new System.Drawing.Size(263, 449);
            this.tpUserGroup.TabIndex = 2;
            this.tpUserGroup.Text = "群组";
            this.tpUserGroup.ToolTipText = "用户群组";
            this.tpUserGroup.UseVisualStyleBackColor = true;
            // 
            // tvUserGroup
            // 
            this.tvUserGroup.AllowDrop = true;
            this.tvUserGroup.ContextMenuStrip = this.cMnuUser;
            this.tvUserGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvUserGroup.ImageIndex = 0;
            this.tvUserGroup.ImageList = this.imageList;
            this.tvUserGroup.Location = new System.Drawing.Point(0, 0);
            this.tvUserGroup.Name = "tvUserGroup";
            this.tvUserGroup.SelectedImageIndex = 0;
            this.tvUserGroup.Size = new System.Drawing.Size(263, 479);
            this.tvUserGroup.TabIndex = 2;
            this.tvUserGroup.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTree_AfterSelect);
            this.tvUserGroup.Click += new System.EventHandler(this.tvTree_Click);
            this.tvUserGroup.DoubleClick += new System.EventHandler(this.tvTree_DoubleClick);
            this.tvUserGroup.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvTreeView_MouseDown);
            // 
            // picHome
            // 
            this.picHome.Image = global::DotNet.WinForm.Properties.Resources.Home;
            this.picHome.Location = new System.Drawing.Point(5, 59);
            this.picHome.Name = "picHome";
            this.picHome.Size = new System.Drawing.Size(28, 29);
            this.picHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHome.TabIndex = 3;
            this.picHome.TabStop = false;
            this.picHome.Tag = "http://www.hairihan.com.cn";
            this.picHome.Click += new System.EventHandler(this.picHome_Click);
            // 
            // picAddress
            // 
            this.picAddress.Image = global::DotNet.WinForm.Properties.Resources.Address;
            this.picAddress.Location = new System.Drawing.Point(73, 59);
            this.picAddress.Name = "picAddress";
            this.picAddress.Size = new System.Drawing.Size(28, 29);
            this.picAddress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAddress.TabIndex = 4;
            this.picAddress.TabStop = false;
            this.picAddress.Click += new System.EventHandler(this.picAddress_Click);
            // 
            // picOA
            // 
            this.picOA.Image = global::DotNet.WinForm.Properties.Resources.OA;
            this.picOA.Location = new System.Drawing.Point(39, 59);
            this.picOA.Name = "picOA";
            this.picOA.Size = new System.Drawing.Size(28, 29);
            this.picOA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOA.TabIndex = 6;
            this.picOA.TabStop = false;
            this.picOA.Tag = "http://jirigala.cnblogs.com";
            this.picOA.Click += new System.EventHandler(this.picOA_Click);
            // 
            // picDocument
            // 
            this.picDocument.Image = global::DotNet.WinForm.Properties.Resources.Document;
            this.picDocument.Location = new System.Drawing.Point(107, 59);
            this.picDocument.Name = "picDocument";
            this.picDocument.Size = new System.Drawing.Size(28, 29);
            this.picDocument.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDocument.TabIndex = 5;
            this.picDocument.TabStop = false;
            this.picDocument.Click += new System.EventHandler(this.picDocument_Click);
            // 
            // picShareAnIdea
            // 
            this.picShareAnIdea.Image = global::DotNet.WinForm.Properties.Resources.ShareAnIdea;
            this.picShareAnIdea.Location = new System.Drawing.Point(141, 59);
            this.picShareAnIdea.Name = "picShareAnIdea";
            this.picShareAnIdea.Size = new System.Drawing.Size(28, 29);
            this.picShareAnIdea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picShareAnIdea.TabIndex = 7;
            this.picShareAnIdea.TabStop = false;
            this.picShareAnIdea.Tag = "http://jirigala.taobao.com";
            this.picShareAnIdea.Click += new System.EventHandler(this.picShareAnIdea_Click);
            // 
            // FrmMessage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::DotNet.WinForm.Properties.Resources.Head;
            this.ClientSize = new System.Drawing.Size(271, 571);
            this.Controls.Add(this.tcMessage);
            this.Controls.Add(this.picShareAnIdea);
            this.Controls.Add(this.picDocument);
            this.Controls.Add(this.picAddress);
            this.Controls.Add(this.picOA);
            this.Controls.Add(this.picHome);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmMessage";
            this.Padding = new System.Windows.Forms.Padding(0, 58, 0, 0);
            this.Text = "即时通讯";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Activated += new System.EventHandler(this.FrmMessage_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMessage_FormClosing);
            this.cMnuUser.ResumeLayout(false);
            this.tcMessage.ResumeLayout(false);
            this.tpOrganize.ResumeLayout(false);
            this.tpApplicationRole.ResumeLayout(false);
            this.tpUserGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShareAnIdea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvOrganize;
        private System.Windows.Forms.HelpProvider helpProvider;
        private System.Windows.Forms.ContextMenuStrip cMnuUser;
        private System.Windows.Forms.ToolStripMenuItem mitmFrmUserEdit;
        private System.Windows.Forms.ToolStripMenuItem mitmFrmUserPermission;
        private System.Windows.Forms.ToolStripMenuItem mitmFrmWorkReportList;
        private System.Windows.Forms.ToolStripMenuItem mitmFrmMessageSend;
        private System.Windows.Forms.ToolStripMenuItem mitmFrmLogByUser;
        private System.Windows.Forms.ToolStripMenuItem mitmFrmUserRoleAdmin;
        private System.Windows.Forms.ToolStripMenuItem mitmFrmUserPermissionAdmin;
        private System.Windows.Forms.ToolStripMenuItem mitmFrmStaffAddressEdit;
        private System.Windows.Forms.ToolStripMenuItem mitmFrmWorkReportAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TabPage tpOrganize;
        private System.Windows.Forms.TabPage tpApplicationRole;
        private System.Windows.Forms.TabPage tpUserGroup;
        private System.Windows.Forms.TabControl tcMessage;
        private System.Windows.Forms.TreeView tvApplicationRole;
        private System.Windows.Forms.TreeView tvUserGroup;
        private System.Windows.Forms.ToolStripMenuItem mitmApplicationRole;
        private System.Windows.Forms.ToolStripMenuItem mitmUserGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.PictureBox picHome;
        private System.Windows.Forms.PictureBox picAddress;
        private System.Windows.Forms.PictureBox picOA;
        private System.Windows.Forms.PictureBox picDocument;
        private System.Windows.Forms.PictureBox picShareAnIdea;
    }
}