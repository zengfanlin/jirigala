namespace DotNet.WinForm
{
    partial class FrmRolePermissionItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRolePermissionItem));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tvPermissionItem = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tcRole = new System.Windows.Forms.TabControl();
            this.tpRole = new System.Windows.Forms.TabPage();
            this.lstRole = new System.Windows.Forms.ListBox();
            this.tcPermissionItem = new System.Windows.Forms.TabControl();
            this.tpPermissionItem = new System.Windows.Forms.TabPage();
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnClearPermission = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tcRole.SuspendLayout();
            this.tpRole.SuspendLayout();
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
            this.tvPermissionItem.ShowNodeToolTips = true;
            this.tvPermissionItem.Size = new System.Drawing.Size(386, 370);
            this.tvPermissionItem.TabIndex = 1;
            this.tvPermissionItem.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvPermissionItem_AfterCheck);
            this.tvPermissionItem.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvPermissionItem_NodeMouseClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(5, 36);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tcRole);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tcPermissionItem);
            this.splitContainer1.Size = new System.Drawing.Size(624, 402);
            this.splitContainer1.SplitterDistance = 220;
            this.splitContainer1.TabIndex = 11;
            // 
            // tcRole
            // 
            this.tcRole.Controls.Add(this.tpRole);
            this.tcRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcRole.Location = new System.Drawing.Point(0, 0);
            this.tcRole.Name = "tcRole";
            this.tcRole.SelectedIndex = 0;
            this.tcRole.Size = new System.Drawing.Size(220, 402);
            this.tcRole.TabIndex = 9;
            // 
            // tpRole
            // 
            this.tpRole.Controls.Add(this.lstRole);
            this.tpRole.Location = new System.Drawing.Point(4, 22);
            this.tpRole.Name = "tpRole";
            this.tpRole.Padding = new System.Windows.Forms.Padding(3);
            this.tpRole.Size = new System.Drawing.Size(212, 376);
            this.tpRole.TabIndex = 0;
            this.tpRole.Text = "角色";
            this.tpRole.UseVisualStyleBackColor = true;
            // 
            // lstRole
            // 
            this.lstRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRole.FormattingEnabled = true;
            this.lstRole.ItemHeight = 12;
            this.lstRole.Location = new System.Drawing.Point(3, 3);
            this.lstRole.Name = "lstRole";
            this.lstRole.Size = new System.Drawing.Size(206, 370);
            this.lstRole.TabIndex = 0;
            this.lstRole.SelectedIndexChanged += new System.EventHandler(this.lstRole_SelectedIndexChanged);
            // 
            // tcPermissionItem
            // 
            this.tcPermissionItem.Controls.Add(this.tpPermissionItem);
            this.tcPermissionItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPermissionItem.Location = new System.Drawing.Point(0, 0);
            this.tcPermissionItem.Name = "tcPermissionItem";
            this.tcPermissionItem.SelectedIndex = 0;
            this.tcPermissionItem.Size = new System.Drawing.Size(400, 402);
            this.tcPermissionItem.TabIndex = 9;
            // 
            // tpPermissionItem
            // 
            this.tpPermissionItem.Controls.Add(this.tvPermissionItem);
            this.tpPermissionItem.Location = new System.Drawing.Point(4, 22);
            this.tpPermissionItem.Name = "tpPermissionItem";
            this.tpPermissionItem.Padding = new System.Windows.Forms.Padding(3);
            this.tpPermissionItem.Size = new System.Drawing.Size(392, 376);
            this.tpPermissionItem.TabIndex = 0;
            this.tpPermissionItem.Text = "拥有操作权限";
            this.tpPermissionItem.UseVisualStyleBackColor = true;
            // 
            // btnPaste
            // 
            this.btnPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaste.AutoSize = true;
            this.btnPaste.Enabled = false;
            this.btnPaste.Location = new System.Drawing.Point(337, 3);
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
            this.btnCopy.Location = new System.Drawing.Point(229, 3);
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
            this.btnClearPermission.Location = new System.Drawing.Point(121, 3);
            this.btnClearPermission.Name = "btnClearPermission";
            this.btnClearPermission.Size = new System.Drawing.Size(102, 23);
            this.btnClearPermission.TabIndex = 32;
            this.btnClearPermission.Text = "清除权限(&C)";
            this.btnClearPermission.UseVisualStyleBackColor = true;
            this.btnClearPermission.Click += new System.EventHandler(this.btnClearPermission_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(558, 444);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 23);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(481, 444);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(71, 23);
            this.btnOK.TabIndex = 36;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnPaste);
            this.flowLayoutPanel1.Controls.Add(this.btnCopy);
            this.flowLayoutPanel1.Controls.Add(this.btnClearPermission);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(187, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(442, 27);
            this.flowLayoutPanel1.TabIndex = 38;
            // 
            // FrmRolePermissionItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 470);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmRolePermissionItem";
            this.Text = "角色操作权限设置";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tcRole.ResumeLayout(false);
            this.tpRole.ResumeLayout(false);
            this.tcPermissionItem.ResumeLayout(false);
            this.tpPermissionItem.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvPermissionItem;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TabControl tcPermissionItem;
        private System.Windows.Forms.TabPage tpPermissionItem;
        private System.Windows.Forms.TabControl tcRole;
        private System.Windows.Forms.TabPage tpRole;
        private System.Windows.Forms.ListBox lstRole;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnClearPermission;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

    }
}