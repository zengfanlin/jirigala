namespace DotNet.WinForm
{
    partial class FrmRolePermission
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRolePermission));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnClearPermission = new System.Windows.Forms.Button();
            this.ucRole = new DotNet.WinForm.UCRoleSelect();
            this.lblParentReq = new System.Windows.Forms.Label();
            this.lblParent = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tcModule = new System.Windows.Forms.TabControl();
            this.tpModule = new System.Windows.Forms.TabPage();
            this.tvModule = new System.Windows.Forms.TreeView();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tcPermissionItem = new System.Windows.Forms.TabControl();
            this.tpPermissionItem = new System.Windows.Forms.TabPage();
            this.tvPermissionItem = new System.Windows.Forms.TreeView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tcModule.SuspendLayout();
            this.tpModule.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tcPermissionItem.SuspendLayout();
            this.tpPermissionItem.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
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
            // btnPaste
            // 
            this.btnPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaste.AutoSize = true;
            this.btnPaste.Enabled = false;
            this.btnPaste.Location = new System.Drawing.Point(313, 3);
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
            this.btnCopy.Location = new System.Drawing.Point(205, 3);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(102, 23);
            this.btnCopy.TabIndex = 1;
            this.btnCopy.Text = "复制权限";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnClearPermission
            // 
            this.btnClearPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearPermission.AutoSize = true;
            this.btnClearPermission.Enabled = false;
            this.btnClearPermission.Location = new System.Drawing.Point(97, 3);
            this.btnClearPermission.Name = "btnClearPermission";
            this.btnClearPermission.Size = new System.Drawing.Size(102, 23);
            this.btnClearPermission.TabIndex = 0;
            this.btnClearPermission.Text = "清除权限(&C)";
            this.btnClearPermission.UseVisualStyleBackColor = true;
            this.btnClearPermission.Click += new System.EventHandler(this.btnClearPermission_Click);
            // 
            // ucRole
            // 
            this.ucRole.AllowNull = false;
            this.ucRole.AllowSelect = false;
            this.ucRole.Location = new System.Drawing.Point(122, 11);
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
            this.lblParentReq.Location = new System.Drawing.Point(353, 16);
            this.lblParentReq.Name = "lblParentReq";
            this.lblParentReq.Size = new System.Drawing.Size(11, 12);
            this.lblParentReq.TabIndex = 5;
            this.lblParentReq.Text = "*";
            // 
            // lblParent
            // 
            this.lblParent.Location = new System.Drawing.Point(13, 15);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(110, 12);
            this.lblParent.TabIndex = 3;
            this.lblParent.Text = "角色(&R)：";
            this.lblParent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.splitter2);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(6, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 488);
            this.panel1.TabIndex = 36;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tcModule);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(418, 488);
            this.panel3.TabIndex = 1;
            // 
            // tcModule
            // 
            this.tcModule.Controls.Add(this.tpModule);
            this.tcModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcModule.Location = new System.Drawing.Point(0, 0);
            this.tcModule.MinimumSize = new System.Drawing.Size(100, 100);
            this.tcModule.Name = "tcModule";
            this.tcModule.SelectedIndex = 0;
            this.tcModule.Size = new System.Drawing.Size(418, 488);
            this.tcModule.TabIndex = 0;
            // 
            // tpModule
            // 
            this.tpModule.Controls.Add(this.tvModule);
            this.tpModule.Location = new System.Drawing.Point(4, 22);
            this.tpModule.Name = "tpModule";
            this.tpModule.Padding = new System.Windows.Forms.Padding(3);
            this.tpModule.Size = new System.Drawing.Size(410, 462);
            this.tpModule.TabIndex = 0;
            this.tpModule.Text = "菜单访问权限";
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
            this.tvModule.Size = new System.Drawing.Size(404, 456);
            this.tvModule.TabIndex = 0;
            this.tvModule.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvModule_AfterCheck);
            this.tvModule.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvModule_NodeMouseClick);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(421, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 488);
            this.splitter2.TabIndex = 2;
            this.splitter2.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 488);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tcPermissionItem);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(424, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(370, 488);
            this.panel4.TabIndex = 2;
            // 
            // tcPermissionItem
            // 
            this.tcPermissionItem.Controls.Add(this.tpPermissionItem);
            this.tcPermissionItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPermissionItem.Location = new System.Drawing.Point(0, 0);
            this.tcPermissionItem.MinimumSize = new System.Drawing.Size(100, 100);
            this.tcPermissionItem.Name = "tcPermissionItem";
            this.tcPermissionItem.SelectedIndex = 0;
            this.tcPermissionItem.Size = new System.Drawing.Size(370, 488);
            this.tcPermissionItem.TabIndex = 0;
            // 
            // tpPermissionItem
            // 
            this.tpPermissionItem.Controls.Add(this.tvPermissionItem);
            this.tpPermissionItem.Location = new System.Drawing.Point(4, 22);
            this.tpPermissionItem.Name = "tpPermissionItem";
            this.tpPermissionItem.Padding = new System.Windows.Forms.Padding(3);
            this.tpPermissionItem.Size = new System.Drawing.Size(362, 462);
            this.tpPermissionItem.TabIndex = 0;
            this.tpPermissionItem.Text = "拥有操作权限";
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
            this.tvPermissionItem.Size = new System.Drawing.Size(356, 456);
            this.tvPermissionItem.TabIndex = 0;
            this.tvPermissionItem.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvPermissionItem_AfterCheck);
            this.tvPermissionItem.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvPermissionItem_NodeMouseClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnPaste);
            this.flowLayoutPanel1.Controls.Add(this.btnCopy);
            this.flowLayoutPanel1.Controls.Add(this.btnClearPermission);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(382, 8);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(418, 30);
            this.flowLayoutPanel1.TabIndex = 37;
            // 
            // FrmRolePermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 568);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ucRole);
            this.Controls.Add(this.lblParentReq);
            this.Controls.Add(this.lblParent);
            this.Name = "FrmRolePermission";
            this.Text = "角色权限设置";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tcModule.ResumeLayout(false);
            this.tpModule.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tcPermissionItem.ResumeLayout(false);
            this.tpPermissionItem.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnClearPermission;
        private DotNet.WinForm.UCRoleSelect ucRole;
        private System.Windows.Forms.Label lblParentReq;
        private System.Windows.Forms.Label lblParent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TabControl tcModule;
        private System.Windows.Forms.TabPage tpModule;
        private System.Windows.Forms.TreeView tvModule;
        private System.Windows.Forms.TabControl tcPermissionItem;
        private System.Windows.Forms.TabPage tpPermissionItem;
        private System.Windows.Forms.TreeView tvPermissionItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

    }
}