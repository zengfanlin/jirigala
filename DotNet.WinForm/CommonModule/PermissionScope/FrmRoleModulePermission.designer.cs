namespace DotNet.WinForm
{
    partial class FrmRoleModulePermission
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRoleModulePermission));
            this.tvModule = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnBatchSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnInvertSelect = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.ucRole = new DotNet.WinForm.UCRoleSelect();
            this.lblRoleReq = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.tbcModule = new System.Windows.Forms.TabControl();
            this.tbpModule = new System.Windows.Forms.TabPage();
            this.tbcModule.SuspendLayout();
            this.tbpModule.SuspendLayout();
            this.SuspendLayout();
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
            this.tvModule.SelectedImageIndex = 1;
            this.tvModule.Size = new System.Drawing.Size(661, 370);
            this.tvModule.TabIndex = 1;
            this.tvModule.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvModule_BeforeCheck);
            this.tvModule.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvModule_NodeMouseClick);
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
            this.btnBatchSave.Location = new System.Drawing.Point(524, 448);
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
            this.btnClose.Location = new System.Drawing.Point(609, 448);
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
            this.btnInvertSelect.Location = new System.Drawing.Point(97, 448);
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
            this.btnSelectAll.Location = new System.Drawing.Point(8, 448);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(78, 23);
            this.btnSelectAll.TabIndex = 3;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // ucRole
            // 
            this.ucRole.AllowNull = false;
            this.ucRole.AllowSelect = false;
            this.ucRole.Location = new System.Drawing.Point(139, 9);
            this.ucRole.MultiSelect = false;
            this.ucRole.Name = "ucRole";
            this.ucRole.OpenId = "";
            this.ucRole.PermissionItemScopeCode = "";
            this.ucRole.RemoveIds = null;
            this.ucRole.SelectedFullName = "";
            this.ucRole.SelectedId = "";
            this.ucRole.SelectedIds = null;
            this.ucRole.ShowRoleOnly = true;
            this.ucRole.Size = new System.Drawing.Size(257, 22);
            this.ucRole.TabIndex = 6;
            // 
            // lblRoleReq
            // 
            this.lblRoleReq.AutoSize = true;
            this.lblRoleReq.ForeColor = System.Drawing.Color.Red;
            this.lblRoleReq.Location = new System.Drawing.Point(402, 15);
            this.lblRoleReq.Name = "lblRoleReq";
            this.lblRoleReq.Size = new System.Drawing.Size(11, 12);
            this.lblRoleReq.TabIndex = 7;
            this.lblRoleReq.Text = "*";
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(12, 11);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(121, 17);
            this.lblUser.TabIndex = 5;
            this.lblUser.Text = "角色(&R)：";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbcModule
            // 
            this.tbcModule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcModule.Controls.Add(this.tbpModule);
            this.tbcModule.Location = new System.Drawing.Point(10, 40);
            this.tbcModule.Name = "tbcModule";
            this.tbcModule.SelectedIndex = 0;
            this.tbcModule.Size = new System.Drawing.Size(675, 402);
            this.tbcModule.TabIndex = 8;
            // 
            // tbpModule
            // 
            this.tbpModule.Controls.Add(this.tvModule);
            this.tbpModule.Location = new System.Drawing.Point(4, 22);
            this.tbpModule.Name = "tbpModule";
            this.tbpModule.Padding = new System.Windows.Forms.Padding(3);
            this.tbpModule.Size = new System.Drawing.Size(667, 376);
            this.tbpModule.TabIndex = 0;
            this.tbpModule.Text = "模块（菜单）";
            this.tbpModule.UseVisualStyleBackColor = true;
            // 
            // FrmRoleModulePermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(692, 476);
            this.Controls.Add(this.tbcModule);
            this.Controls.Add(this.ucRole);
            this.Controls.Add(this.lblRoleReq);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btnInvertSelect);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBatchSave);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmRoleModulePermission";
            this.Text = "角色菜单权限";
            this.Load += new System.EventHandler(this.FrmRoleModulePermission_Load);
            this.tbcModule.ResumeLayout(false);
            this.tbpModule.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvModule;
        private System.Windows.Forms.Button btnBatchSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnInvertSelect;
        private System.Windows.Forms.Button btnSelectAll;
        private DotNet.WinForm.UCRoleSelect ucRole;
        private System.Windows.Forms.Label lblRoleReq;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TabControl tbcModule;
        private System.Windows.Forms.TabPage tbpModule;
    }
}