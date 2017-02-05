namespace DotNet.WinForm
{
    partial class FrmRoleAuthorizationScope
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRoleAuthorizationScope));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpUser = new System.Windows.Forms.TabPage();
            this.cklstUser = new System.Windows.Forms.CheckedListBox();
            this.tpRole = new System.Windows.Forms.TabPage();
            this.cklstRole = new System.Windows.Forms.CheckedListBox();
            this.tpOrganize = new System.Windows.Forms.TabPage();
            this.tvOrganize = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tpModule = new System.Windows.Forms.TabPage();
            this.tvModule = new System.Windows.Forms.TreeView();
            this.tpPermissionItem = new System.Windows.Forms.TabPage();
            this.tvPermissionItem = new System.Windows.Forms.TreeView();
            this.ucRole = new DotNet.WinForm.UCRoleSelect();
            this.lblParentReq = new System.Windows.Forms.Label();
            this.lblParent = new System.Windows.Forms.Label();
            this.btnClearPermission = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lblPermissionScopeReq = new System.Windows.Forms.Label();
            this.ucPermissionScope = new DotNet.WinForm.UCScopePermissionSelect();
            this.lblPermissionScope = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1.SuspendLayout();
            this.tpUser.SuspendLayout();
            this.tpRole.SuspendLayout();
            this.tpOrganize.SuspendLayout();
            this.tpModule.SuspendLayout();
            this.tpPermissionItem.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpUser);
            this.tabControl1.Controls.Add(this.tpRole);
            this.tabControl1.Controls.Add(this.tpOrganize);
            this.tabControl1.Controls.Add(this.tpModule);
            this.tabControl1.Controls.Add(this.tpPermissionItem);
            this.tabControl1.Location = new System.Drawing.Point(6, 78);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(738, 456);
            this.tabControl1.TabIndex = 9;
            // 
            // tpUser
            // 
            this.tpUser.Controls.Add(this.cklstUser);
            this.tpUser.Location = new System.Drawing.Point(4, 22);
            this.tpUser.Name = "tpUser";
            this.tpUser.Padding = new System.Windows.Forms.Padding(3);
            this.tpUser.Size = new System.Drawing.Size(730, 430);
            this.tpUser.TabIndex = 0;
            this.tpUser.Text = "用户";
            this.tpUser.UseVisualStyleBackColor = true;
            // 
            // cklstUser
            // 
            this.cklstUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cklstUser.Enabled = false;
            this.cklstUser.FormattingEnabled = true;
            this.cklstUser.Location = new System.Drawing.Point(3, 3);
            this.cklstUser.MultiColumn = true;
            this.cklstUser.Name = "cklstUser";
            this.cklstUser.Size = new System.Drawing.Size(724, 424);
            this.cklstUser.TabIndex = 1;
            this.cklstUser.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cklstUser_ItemCheck);
            // 
            // tpRole
            // 
            this.tpRole.Controls.Add(this.cklstRole);
            this.tpRole.Location = new System.Drawing.Point(4, 22);
            this.tpRole.Name = "tpRole";
            this.tpRole.Padding = new System.Windows.Forms.Padding(3);
            this.tpRole.Size = new System.Drawing.Size(730, 430);
            this.tpRole.TabIndex = 1;
            this.tpRole.Text = "角色";
            this.tpRole.UseVisualStyleBackColor = true;
            // 
            // cklstRole
            // 
            this.cklstRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cklstRole.Enabled = false;
            this.cklstRole.FormattingEnabled = true;
            this.cklstRole.Location = new System.Drawing.Point(3, 3);
            this.cklstRole.MultiColumn = true;
            this.cklstRole.Name = "cklstRole";
            this.cklstRole.Size = new System.Drawing.Size(724, 425);
            this.cklstRole.TabIndex = 1;
            this.cklstRole.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cklstRole_ItemCheck);
            // 
            // tpOrganize
            // 
            this.tpOrganize.Controls.Add(this.tvOrganize);
            this.tpOrganize.Location = new System.Drawing.Point(4, 22);
            this.tpOrganize.Name = "tpOrganize";
            this.tpOrganize.Padding = new System.Windows.Forms.Padding(3);
            this.tpOrganize.Size = new System.Drawing.Size(730, 430);
            this.tpOrganize.TabIndex = 2;
            this.tpOrganize.Text = "组织机构";
            this.tpOrganize.UseVisualStyleBackColor = true;
            // 
            // tvOrganize
            // 
            this.tvOrganize.CheckBoxes = true;
            this.tvOrganize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvOrganize.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvOrganize.ImageIndex = 0;
            this.tvOrganize.ImageList = this.imageList;
            this.tvOrganize.Location = new System.Drawing.Point(3, 3);
            this.tvOrganize.Name = "tvOrganize";
            this.tvOrganize.SelectedImageIndex = 0;
            this.tvOrganize.Size = new System.Drawing.Size(724, 389);
            this.tvOrganize.TabIndex = 8;
            this.tvOrganize.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvOrganize_AfterCheck);
            this.tvOrganize.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvOrganize_NodeMouseClick);
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
            // tpModule
            // 
            this.tpModule.Controls.Add(this.tvModule);
            this.tpModule.Location = new System.Drawing.Point(4, 22);
            this.tpModule.Name = "tpModule";
            this.tpModule.Padding = new System.Windows.Forms.Padding(3);
            this.tpModule.Size = new System.Drawing.Size(730, 430);
            this.tpModule.TabIndex = 4;
            this.tpModule.Text = "菜单";
            this.tpModule.UseVisualStyleBackColor = true;
            // 
            // tvModule
            // 
            this.tvModule.AllowDrop = true;
            this.tvModule.CheckBoxes = true;
            this.tvModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvModule.Enabled = false;
            this.tvModule.ImageIndex = 0;
            this.tvModule.ImageList = this.imageList;
            this.tvModule.Location = new System.Drawing.Point(3, 3);
            this.tvModule.Name = "tvModule";
            this.tvModule.SelectedImageIndex = 0;
            this.tvModule.Size = new System.Drawing.Size(724, 389);
            this.tvModule.TabIndex = 2;
            this.tvModule.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvModule_AfterCheck);
            this.tvModule.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvModule_NodeMouseClick);
            // 
            // tpPermissionItem
            // 
            this.tpPermissionItem.Controls.Add(this.tvPermissionItem);
            this.tpPermissionItem.Location = new System.Drawing.Point(4, 22);
            this.tpPermissionItem.Name = "tpPermissionItem";
            this.tpPermissionItem.Padding = new System.Windows.Forms.Padding(3);
            this.tpPermissionItem.Size = new System.Drawing.Size(730, 430);
            this.tpPermissionItem.TabIndex = 3;
            this.tpPermissionItem.Text = "可分配操作权限";
            this.tpPermissionItem.UseVisualStyleBackColor = true;
            // 
            // tvPermissionItem
            // 
            this.tvPermissionItem.AllowDrop = true;
            this.tvPermissionItem.CheckBoxes = true;
            this.tvPermissionItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPermissionItem.Enabled = false;
            this.tvPermissionItem.HotTracking = true;
            this.tvPermissionItem.ImageIndex = 0;
            this.tvPermissionItem.ImageList = this.imageList;
            this.tvPermissionItem.Location = new System.Drawing.Point(3, 3);
            this.tvPermissionItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tvPermissionItem.Name = "tvPermissionItem";
            this.tvPermissionItem.SelectedImageIndex = 0;
            this.tvPermissionItem.Size = new System.Drawing.Size(724, 389);
            this.tvPermissionItem.TabIndex = 2;
            this.tvPermissionItem.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvPermissionItem_AfterCheck);
            this.tvPermissionItem.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvPermissionItem_NodeMouseClick);
            // 
            // ucRole
            // 
            this.ucRole.AllowNull = false;
            this.ucRole.AllowSelect = false;
            this.ucRole.Location = new System.Drawing.Point(115, 8);
            this.ucRole.MultiSelect = false;
            this.ucRole.Name = "ucRole";
            this.ucRole.OpenId = "";
            this.ucRole.PermissionItemScopeCode = "";
            this.ucRole.RemoveIds = null;
            this.ucRole.SelectedFullName = "";
            this.ucRole.SelectedId = "";
            this.ucRole.SelectedIds = null;
            this.ucRole.ShowRoleOnly = true;
            this.ucRole.Size = new System.Drawing.Size(227, 22);
            this.ucRole.TabIndex = 4;
            // 
            // lblParentReq
            // 
            this.lblParentReq.AutoSize = true;
            this.lblParentReq.ForeColor = System.Drawing.Color.Red;
            this.lblParentReq.Location = new System.Drawing.Point(346, 13);
            this.lblParentReq.Name = "lblParentReq";
            this.lblParentReq.Size = new System.Drawing.Size(11, 12);
            this.lblParentReq.TabIndex = 5;
            this.lblParentReq.Text = "*";
            // 
            // lblParent
            // 
            this.lblParent.Location = new System.Drawing.Point(7, 12);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(108, 12);
            this.lblParent.TabIndex = 3;
            this.lblParent.Text = "角色(&R)：";
            this.lblParent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClearPermission
            // 
            this.btnClearPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearPermission.AutoSize = true;
            this.btnClearPermission.Enabled = false;
            this.btnClearPermission.Location = new System.Drawing.Point(55, 3);
            this.btnClearPermission.Name = "btnClearPermission";
            this.btnClearPermission.Size = new System.Drawing.Size(102, 23);
            this.btnClearPermission.TabIndex = 0;
            this.btnClearPermission.Text = "清除权限(&C)";
            this.btnClearPermission.UseVisualStyleBackColor = true;
            this.btnClearPermission.Click += new System.EventHandler(this.btnClearPermission_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaste.AutoSize = true;
            this.btnPaste.Enabled = false;
            this.btnPaste.Location = new System.Drawing.Point(271, 3);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(102, 23);
            this.btnPaste.TabIndex = 2;
            this.btnPaste.Text = "粘贴权限";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.AutoSize = true;
            this.btnCopy.Enabled = false;
            this.btnCopy.Location = new System.Drawing.Point(163, 3);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(102, 23);
            this.btnCopy.TabIndex = 1;
            this.btnCopy.Text = "复制权限";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lblPermissionScopeReq
            // 
            this.lblPermissionScopeReq.AutoSize = true;
            this.lblPermissionScopeReq.ForeColor = System.Drawing.Color.Red;
            this.lblPermissionScopeReq.Location = new System.Drawing.Point(346, 42);
            this.lblPermissionScopeReq.Name = "lblPermissionScopeReq";
            this.lblPermissionScopeReq.Size = new System.Drawing.Size(11, 12);
            this.lblPermissionScopeReq.TabIndex = 8;
            this.lblPermissionScopeReq.Text = "*";
            // 
            // ucPermissionScope
            // 
            this.ucPermissionScope.AllowNull = false;
            this.ucPermissionScope.AllowSelect = false;
            this.ucPermissionScope.Location = new System.Drawing.Point(115, 36);
            this.ucPermissionScope.MultiSelect = false;
            this.ucPermissionScope.Name = "ucPermissionScope";
            this.ucPermissionScope.SelectedFullName = "";
            this.ucPermissionScope.SelectedId = "";
            this.ucPermissionScope.Size = new System.Drawing.Size(227, 22);
            this.ucPermissionScope.TabIndex = 7;
            // 
            // lblPermissionScope
            // 
            this.lblPermissionScope.Location = new System.Drawing.Point(7, 40);
            this.lblPermissionScope.Name = "lblPermissionScope";
            this.lblPermissionScope.Size = new System.Drawing.Size(108, 12);
            this.lblPermissionScope.TabIndex = 6;
            this.lblPermissionScope.Text = "数据权限：";
            this.lblPermissionScope.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnPaste);
            this.flowLayoutPanel1.Controls.Add(this.btnCopy);
            this.flowLayoutPanel1.Controls.Add(this.btnClearPermission);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(364, 26);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(376, 32);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // FrmRoleAuthorizationScope
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 538);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblPermissionScopeReq);
            this.Controls.Add(this.ucPermissionScope);
            this.Controls.Add(this.lblPermissionScope);
            this.Controls.Add(this.ucRole);
            this.Controls.Add(this.lblParentReq);
            this.Controls.Add(this.lblParent);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmRoleAuthorizationScope";
            this.Text = "角色授权范围明细";
            this.tabControl1.ResumeLayout(false);
            this.tpUser.ResumeLayout(false);
            this.tpRole.ResumeLayout(false);
            this.tpOrganize.ResumeLayout(false);
            this.tpModule.ResumeLayout(false);
            this.tpPermissionItem.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpUser;
        private System.Windows.Forms.TabPage tpRole;
        private System.Windows.Forms.TabPage tpOrganize;
        private System.Windows.Forms.TabPage tpPermissionItem;
        private DotNet.WinForm.UCRoleSelect ucRole;
        private System.Windows.Forms.Label lblParentReq;
        private System.Windows.Forms.Label lblParent;
        private System.Windows.Forms.Button btnClearPermission;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.TabPage tpModule;
        private System.Windows.Forms.TreeView tvModule;
        private System.Windows.Forms.TreeView tvPermissionItem;
        private System.Windows.Forms.CheckedListBox cklstUser;
        private System.Windows.Forms.CheckedListBox cklstRole;
        private System.Windows.Forms.Label lblPermissionScopeReq;
        private DotNet.WinForm.UCScopePermissionSelect ucPermissionScope;
        private System.Windows.Forms.Label lblPermissionScope;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TreeView tvOrganize;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}