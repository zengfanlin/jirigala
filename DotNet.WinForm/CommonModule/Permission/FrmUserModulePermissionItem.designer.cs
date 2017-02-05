namespace DotNet.WinForm
{
    partial class FrmUserModulePermissionItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserModulePermissionItem));
            this.tvModulePermissionItem = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnBatchSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnInvertSelect = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.ucUser = new DotNet.WinForm.UCUserSelect();
            this.lblParentReq = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.tcModule = new System.Windows.Forms.TabControl();
            this.tpModule = new System.Windows.Forms.TabPage();
            this.tcModule.SuspendLayout();
            this.tpModule.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvModulePermissionItem
            // 
            this.tvModulePermissionItem.AllowDrop = true;
            this.tvModulePermissionItem.CheckBoxes = true;
            this.tvModulePermissionItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvModulePermissionItem.ImageIndex = 0;
            this.tvModulePermissionItem.ImageList = this.imageList;
            this.tvModulePermissionItem.Location = new System.Drawing.Point(3, 3);
            this.tvModulePermissionItem.Name = "tvModulePermissionItem";
            this.tvModulePermissionItem.SelectedImageIndex = 0;
            this.tvModulePermissionItem.Size = new System.Drawing.Size(662, 414);
            this.tvModulePermissionItem.TabIndex = 1;
            this.tvModulePermissionItem.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvModule_BeforeCheck);
            this.tvModulePermissionItem.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvModulePermissionItem_NodeMouseClick);
            this.tvModulePermissionItem.DoubleClick += new System.EventHandler(this.tvModulePermissionItem_DoubleClick);
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
            this.btnBatchSave.Location = new System.Drawing.Point(520, 490);
            this.btnBatchSave.Name = "btnBatchSave";
            this.btnBatchSave.Size = new System.Drawing.Size(78, 23);
            this.btnBatchSave.TabIndex = 2;
            this.btnBatchSave.Text = "保存(&S)";
            this.btnBatchSave.UseVisualStyleBackColor = true;
            this.btnBatchSave.Click += new System.EventHandler(this.btnBatchSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(606, 490);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnInvertSelect
            // 
            this.btnInvertSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvertSelect.Location = new System.Drawing.Point(94, 490);
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
            this.btnSelectAll.Location = new System.Drawing.Point(8, 490);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(78, 23);
            this.btnSelectAll.TabIndex = 3;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // ucUser
            // 
            this.ucUser.AllowNull = false;
            this.ucUser.AllowSelect = false;
            this.ucUser.Location = new System.Drawing.Point(117, 12);
            this.ucUser.MultiSelect = false;
            this.ucUser.Name = "ucUser";
            this.ucUser.OpenId = "";
            this.ucUser.PermissionItemScopeCode = "";
            this.ucUser.RemoveIds = null;
            this.ucUser.SelectedFullName = "";
            this.ucUser.SelectedId = "";
            this.ucUser.SelectedIds = null;
            this.ucUser.SetSelectIds = null;
            this.ucUser.Size = new System.Drawing.Size(266, 22);
            this.ucUser.TabIndex = 6;
            // 
            // lblParentReq
            // 
            this.lblParentReq.AutoSize = true;
            this.lblParentReq.ForeColor = System.Drawing.Color.Red;
            this.lblParentReq.Location = new System.Drawing.Point(389, 17);
            this.lblParentReq.Name = "lblParentReq";
            this.lblParentReq.Size = new System.Drawing.Size(11, 12);
            this.lblParentReq.TabIndex = 7;
            this.lblParentReq.Text = "*";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(48, 16);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(59, 12);
            this.lblUser.TabIndex = 5;
            this.lblUser.Text = "用户(&U)：";
            // 
            // tcModule
            // 
            this.tcModule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcModule.Controls.Add(this.tpModule);
            this.tcModule.Location = new System.Drawing.Point(9, 40);
            this.tcModule.Name = "tcModule";
            this.tcModule.SelectedIndex = 0;
            this.tcModule.Size = new System.Drawing.Size(676, 446);
            this.tcModule.TabIndex = 8;
            // 
            // tpModule
            // 
            this.tpModule.Controls.Add(this.tvModulePermissionItem);
            this.tpModule.Location = new System.Drawing.Point(4, 22);
            this.tpModule.Name = "tpModule";
            this.tpModule.Padding = new System.Windows.Forms.Padding(3);
            this.tpModule.Size = new System.Drawing.Size(668, 420);
            this.tpModule.TabIndex = 0;
            this.tpModule.Text = "用户权限";
            this.tpModule.UseVisualStyleBackColor = true;
            // 
            // FrmUserModulePermissionItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(692, 518);
            this.Controls.Add(this.tcModule);
            this.Controls.Add(this.ucUser);
            this.Controls.Add(this.lblParentReq);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btnInvertSelect);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBatchSave);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmUserModulePermissionItem";
            this.Text = "用户权限";
            this.tcModule.ResumeLayout(false);
            this.tpModule.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvModulePermissionItem;
        private System.Windows.Forms.Button btnBatchSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnInvertSelect;
        private System.Windows.Forms.Button btnSelectAll;
        private DotNet.WinForm.UCUserSelect ucUser;
        private System.Windows.Forms.Label lblParentReq;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TabControl tcModule;
        private System.Windows.Forms.TabPage tpModule;
    }
}