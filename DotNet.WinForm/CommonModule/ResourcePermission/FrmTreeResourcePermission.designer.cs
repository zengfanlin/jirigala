namespace DotNet.WinForm
{
    partial class FrmTreeResourcePermission
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTreeResourcePermission));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnBatchSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnInvertSelect = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.lblPermissionItemName = new System.Windows.Forms.Label();
            this.lblResourceName = new System.Windows.Forms.Label();
            this.lblPermissionItem = new System.Windows.Forms.Label();
            this.lblResource = new System.Windows.Forms.Label();
            this.tpTargetResource = new System.Windows.Forms.TabPage();
            this.tvResource = new System.Windows.Forms.TreeView();
            this.tcTargetResource = new System.Windows.Forms.TabControl();
            this.tpTargetResource.SuspendLayout();
            this.tcTargetResource.SuspendLayout();
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
            // btnBatchSave
            // 
            this.btnBatchSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchSave.Location = new System.Drawing.Point(524, 549);
            this.btnBatchSave.Name = "btnBatchSave";
            this.btnBatchSave.Size = new System.Drawing.Size(75, 23);
            this.btnBatchSave.TabIndex = 2;
            this.btnBatchSave.Text = "保存(&S)";
            this.btnBatchSave.UseVisualStyleBackColor = true;
            this.btnBatchSave.Click += new System.EventHandler(this.btnBatchSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(609, 549);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnInvertSelect
            // 
            this.btnInvertSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvertSelect.Location = new System.Drawing.Point(97, 549);
            this.btnInvertSelect.Name = "btnInvertSelect";
            this.btnInvertSelect.Size = new System.Drawing.Size(78, 23);
            this.btnInvertSelect.TabIndex = 4;
            this.btnInvertSelect.Text = "反选";
            this.btnInvertSelect.UseVisualStyleBackColor = true;
            this.btnInvertSelect.Click += new System.EventHandler(this.btnInvertSelect_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Location = new System.Drawing.Point(8, 549);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(78, 23);
            this.btnSelectAll.TabIndex = 3;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // lblPermissionItemName
            // 
            this.lblPermissionItemName.AutoSize = true;
            this.lblPermissionItemName.Location = new System.Drawing.Point(105, 44);
            this.lblPermissionItemName.Name = "lblPermissionItemName";
            this.lblPermissionItemName.Size = new System.Drawing.Size(53, 12);
            this.lblPermissionItemName.TabIndex = 23;
            this.lblPermissionItemName.Text = "管理权限";
            this.lblPermissionItemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblResourceName
            // 
            this.lblResourceName.AutoSize = true;
            this.lblResourceName.Location = new System.Drawing.Point(105, 13);
            this.lblResourceName.Name = "lblResourceName";
            this.lblResourceName.Size = new System.Drawing.Size(35, 12);
            this.lblResourceName.TabIndex = 22;
            this.lblResourceName.Text = "用户A";
            this.lblResourceName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPermissionItem
            // 
            this.lblPermissionItem.Location = new System.Drawing.Point(2, 44);
            this.lblPermissionItem.Name = "lblPermissionItem";
            this.lblPermissionItem.Size = new System.Drawing.Size(97, 12);
            this.lblPermissionItem.TabIndex = 21;
            this.lblPermissionItem.Text = "操作权限：";
            this.lblPermissionItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblResource
            // 
            this.lblResource.Location = new System.Drawing.Point(2, 13);
            this.lblResource.Name = "lblResource";
            this.lblResource.Size = new System.Drawing.Size(97, 12);
            this.lblResource.TabIndex = 20;
            this.lblResource.Text = "目标对象：";
            this.lblResource.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tpTargetResource
            // 
            this.tpTargetResource.BackColor = System.Drawing.SystemColors.Control;
            this.tpTargetResource.Controls.Add(this.tvResource);
            this.tpTargetResource.Location = new System.Drawing.Point(4, 22);
            this.tpTargetResource.Name = "tpTargetResource";
            this.tpTargetResource.Padding = new System.Windows.Forms.Padding(3);
            this.tpTargetResource.Size = new System.Drawing.Size(664, 443);
            this.tpTargetResource.TabIndex = 0;
            this.tpTargetResource.Text = "目标资源";
            // 
            // tvResource
            // 
            this.tvResource.AllowDrop = true;
            this.tvResource.CheckBoxes = true;
            this.tvResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvResource.ImageIndex = 0;
            this.tvResource.ImageList = this.imageList;
            this.tvResource.Location = new System.Drawing.Point(3, 3);
            this.tvResource.Name = "tvResource";
            this.tvResource.SelectedImageIndex = 0;
            this.tvResource.Size = new System.Drawing.Size(658, 437);
            this.tvResource.TabIndex = 2;
            this.tvResource.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvResourcee_BeforeCheck);
            this.tvResource.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvResource_AfterCheck);
            this.tvResource.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvResource_MouseDown);
            // 
            // tcTargetResource
            // 
            this.tcTargetResource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcTargetResource.Controls.Add(this.tpTargetResource);
            this.tcTargetResource.Location = new System.Drawing.Point(11, 74);
            this.tcTargetResource.Name = "tcTargetResource";
            this.tcTargetResource.SelectedIndex = 0;
            this.tcTargetResource.Size = new System.Drawing.Size(672, 469);
            this.tcTargetResource.TabIndex = 24;
            // 
            // FrmTreeResourcePermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(692, 577);
            this.Controls.Add(this.tcTargetResource);
            this.Controls.Add(this.lblPermissionItemName);
            this.Controls.Add(this.lblResourceName);
            this.Controls.Add(this.lblPermissionItem);
            this.Controls.Add(this.lblResource);
            this.Controls.Add(this.btnInvertSelect);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBatchSave);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmTreeResourcePermission";
            this.Text = "数据权限设置(树型资源)";
            this.tpTargetResource.ResumeLayout(false);
            this.tcTargetResource.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBatchSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnInvertSelect;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label lblPermissionItemName;
        private System.Windows.Forms.Label lblResourceName;
        private System.Windows.Forms.Label lblPermissionItem;
        private System.Windows.Forms.Label lblResource;
        private System.Windows.Forms.TabPage tpTargetResource;
        private System.Windows.Forms.TreeView tvResource;
        private System.Windows.Forms.TabControl tcTargetResource;
    }
}