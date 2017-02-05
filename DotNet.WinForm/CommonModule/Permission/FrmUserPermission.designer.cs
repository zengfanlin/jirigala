namespace DotNet.WinForm
{
    partial class FrmUserPermission
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserPermission));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnClearPermission = new System.Windows.Forms.Button();
            this.ucUser = new DotNet.WinForm.UCUserSelect();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.tcUser = new System.Windows.Forms.TabControl();
            this.tpUser = new System.Windows.Forms.TabPage();
            this.cklstRole = new System.Windows.Forms.CheckedListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tcModule.SuspendLayout();
            this.tpModule.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tcPermissionItem.SuspendLayout();
            this.tpPermissionItem.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tcUser.SuspendLayout();
            this.tpUser.SuspendLayout();
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
            this.btnPaste.Location = new System.Drawing.Point(239, 3);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(102, 23);
            this.btnPaste.TabIndex = 31;
            this.btnPaste.Text = "粘贴权限";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.AutoSize = true;
            this.btnCopy.Enabled = false;
            this.btnCopy.Location = new System.Drawing.Point(131, 3);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(102, 23);
            this.btnCopy.TabIndex = 30;
            this.btnCopy.Text = "复制权限";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnClearPermission
            // 
            this.btnClearPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearPermission.AutoSize = true;
            this.btnClearPermission.Enabled = false;
            this.btnClearPermission.Location = new System.Drawing.Point(23, 3);
            this.btnClearPermission.Name = "btnClearPermission";
            this.btnClearPermission.Size = new System.Drawing.Size(102, 23);
            this.btnClearPermission.TabIndex = 32;
            this.btnClearPermission.Text = "清除权限(&C)";
            this.btnClearPermission.UseVisualStyleBackColor = true;
            this.btnClearPermission.Click += new System.EventHandler(this.btnClearPermission_Click);
            // 
            // ucUser
            // 
            this.ucUser.AllowNull = false;
            this.ucUser.AllowSelect = false;
            this.ucUser.Location = new System.Drawing.Point(152, 19);
            this.ucUser.MultiSelect = false;
            this.ucUser.Name = "ucUser";
            this.ucUser.OpenId = "";
            this.ucUser.PermissionItemScopeCode = "";
            this.ucUser.RemoveIds = null;
            this.ucUser.SelectedFullName = "";
            this.ucUser.SelectedId = "";
            this.ucUser.SelectedIds = null;
            this.ucUser.SetSelectIds = null;
            this.ucUser.Size = new System.Drawing.Size(227, 22);
            this.ucUser.TabIndex = 34;
            // 
            // lblParentReq
            // 
            this.lblParentReq.AutoSize = true;
            this.lblParentReq.ForeColor = System.Drawing.Color.Red;
            this.lblParentReq.Location = new System.Drawing.Point(383, 24);
            this.lblParentReq.Name = "lblParentReq";
            this.lblParentReq.Size = new System.Drawing.Size(11, 12);
            this.lblParentReq.TabIndex = 35;
            this.lblParentReq.Text = "*";
            // 
            // lblParent
            // 
            this.lblParent.Location = new System.Drawing.Point(17, 23);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(131, 12);
            this.lblParent.TabIndex = 33;
            this.lblParent.Text = "用户(&U)：";
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
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(6, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 510);
            this.panel1.TabIndex = 36;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tcModule);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(223, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(290, 510);
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
            this.tcModule.Size = new System.Drawing.Size(290, 510);
            this.tcModule.TabIndex = 12;
            // 
            // tpModule
            // 
            this.tpModule.Controls.Add(this.tvModule);
            this.tpModule.Location = new System.Drawing.Point(4, 22);
            this.tpModule.Name = "tpModule";
            this.tpModule.Padding = new System.Windows.Forms.Padding(3);
            this.tpModule.Size = new System.Drawing.Size(282, 484);
            this.tpModule.TabIndex = 0;
            this.tpModule.Text = "菜单访问权限";
            this.tpModule.UseVisualStyleBackColor = true;
            // 
            // tvModule
            // 
            this.tvModule.AllowDrop = true;
            this.tvModule.CheckBoxes = true;
            this.tvModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvModule.ImageIndex = 0;
            this.tvModule.ImageList = this.imageList;
            this.tvModule.Location = new System.Drawing.Point(3, 3);
            this.tvModule.Name = "tvModule";
            this.tvModule.SelectedImageIndex = 0;
            this.tvModule.Size = new System.Drawing.Size(276, 478);
            this.tvModule.TabIndex = 1;
            this.tvModule.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvModule_AfterCheck);
            this.tvModule.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvModule_NodeMouseClick);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(513, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 510);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(220, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 510);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tcPermissionItem);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(516, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(278, 510);
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
            this.tcPermissionItem.Size = new System.Drawing.Size(278, 510);
            this.tcPermissionItem.TabIndex = 10;
            // 
            // tpPermissionItem
            // 
            this.tpPermissionItem.Controls.Add(this.tvPermissionItem);
            this.tpPermissionItem.Location = new System.Drawing.Point(4, 22);
            this.tpPermissionItem.Name = "tpPermissionItem";
            this.tpPermissionItem.Padding = new System.Windows.Forms.Padding(3);
            this.tpPermissionItem.Size = new System.Drawing.Size(270, 484);
            this.tpPermissionItem.TabIndex = 0;
            this.tpPermissionItem.Text = "拥有操作权限";
            this.tpPermissionItem.UseVisualStyleBackColor = true;
            // 
            // tvPermissionItem
            // 
            this.tvPermissionItem.AllowDrop = true;
            this.tvPermissionItem.CheckBoxes = true;
            this.tvPermissionItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPermissionItem.HotTracking = true;
            this.tvPermissionItem.ImageIndex = 0;
            this.tvPermissionItem.ImageList = this.imageList;
            this.tvPermissionItem.Location = new System.Drawing.Point(3, 3);
            this.tvPermissionItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tvPermissionItem.Name = "tvPermissionItem";
            this.tvPermissionItem.SelectedImageIndex = 0;
            this.tvPermissionItem.Size = new System.Drawing.Size(264, 478);
            this.tvPermissionItem.TabIndex = 1;
            this.tvPermissionItem.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvPermissionItem_AfterCheck);
            this.tvPermissionItem.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvPermissionItem_NodeMouseClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tcUser);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 510);
            this.panel2.TabIndex = 0;
            // 
            // tcUser
            // 
            this.tcUser.Controls.Add(this.tpUser);
            this.tcUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcUser.Location = new System.Drawing.Point(0, 0);
            this.tcUser.MinimumSize = new System.Drawing.Size(100, 100);
            this.tcUser.Name = "tcUser";
            this.tcUser.SelectedIndex = 0;
            this.tcUser.Size = new System.Drawing.Size(220, 510);
            this.tcUser.TabIndex = 9;
            // 
            // tpUser
            // 
            this.tpUser.Controls.Add(this.cklstRole);
            this.tpUser.Location = new System.Drawing.Point(4, 22);
            this.tpUser.Name = "tpUser";
            this.tpUser.Padding = new System.Windows.Forms.Padding(3);
            this.tpUser.Size = new System.Drawing.Size(212, 484);
            this.tpUser.TabIndex = 0;
            this.tpUser.Text = "归属角色";
            this.tpUser.UseVisualStyleBackColor = true;
            // 
            // cklstRole
            // 
            this.cklstRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cklstRole.FormattingEnabled = true;
            this.cklstRole.Location = new System.Drawing.Point(3, 3);
            this.cklstRole.Name = "cklstRole";
            this.cklstRole.Size = new System.Drawing.Size(206, 478);
            this.cklstRole.TabIndex = 0;
            this.cklstRole.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cklstUser_ItemCheck);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.btnPaste);
            this.flowLayoutPanel1.Controls.Add(this.btnCopy);
            this.flowLayoutPanel1.Controls.Add(this.btnClearPermission);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(456, 15);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(344, 30);
            this.flowLayoutPanel1.TabIndex = 37;
            // 
            // FrmUserPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 568);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ucUser);
            this.Controls.Add(this.lblParentReq);
            this.Controls.Add(this.lblParent);
            this.Name = "FrmUserPermission";
            this.Text = "用户权限设置";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tcModule.ResumeLayout(false);
            this.tpModule.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tcPermissionItem.ResumeLayout(false);
            this.tpPermissionItem.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tcUser.ResumeLayout(false);
            this.tpUser.ResumeLayout(false);
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
        private DotNet.WinForm.UCUserSelect ucUser;
        private System.Windows.Forms.Label lblParentReq;
        private System.Windows.Forms.Label lblParent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tcUser;
        private System.Windows.Forms.TabPage tpUser;
        private System.Windows.Forms.CheckedListBox cklstRole;
        private System.Windows.Forms.TabControl tcModule;
        private System.Windows.Forms.TabPage tpModule;
        private System.Windows.Forms.TreeView tvModule;
        private System.Windows.Forms.TabControl tcPermissionItem;
        private System.Windows.Forms.TabPage tpPermissionItem;
        private System.Windows.Forms.TreeView tvPermissionItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

    }
}