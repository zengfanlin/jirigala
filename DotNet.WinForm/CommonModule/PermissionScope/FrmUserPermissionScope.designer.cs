namespace DotNet.WinForm
{
    partial class FrmUserPermissionScope
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserPermissionScope));
            this.btnInvertSelect = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBatchSave = new System.Windows.Forms.Button();
            this.tvOrganize = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.ucPermissionScope = new DotNet.WinForm.UCScopePermissionSelect();
            this.lblPermissionScope = new System.Windows.Forms.Label();
            this.lblPermissionScopeReq = new System.Windows.Forms.Label();
            this.ucUser = new DotNet.WinForm.UCUserSelect();
            this.lblStaffReq = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.grbPermissionScope = new System.Windows.Forms.GroupBox();
            this.rdbUserSubCompany = new System.Windows.Forms.RadioButton();
            this.rdbNone = new System.Windows.Forms.RadioButton();
            this.rdbDetail = new System.Windows.Forms.RadioButton();
            this.rdbUser = new System.Windows.Forms.RadioButton();
            this.rdbUserWorkgroup = new System.Windows.Forms.RadioButton();
            this.rdbUserDepartment = new System.Windows.Forms.RadioButton();
            this.rdbUserCompany = new System.Windows.Forms.RadioButton();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.chkInnerOrganize = new System.Windows.Forms.CheckBox();
            this.grbPermissionScope.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInvertSelect
            // 
            this.btnInvertSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvertSelect.Location = new System.Drawing.Point(93, 507);
            this.btnInvertSelect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInvertSelect.Name = "btnInvertSelect";
            this.btnInvertSelect.Size = new System.Drawing.Size(78, 23);
            this.btnInvertSelect.TabIndex = 10;
            this.btnInvertSelect.Text = "反选";
            this.btnInvertSelect.UseVisualStyleBackColor = true;
            this.btnInvertSelect.Click += new System.EventHandler(this.btnInvertSelect_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Location = new System.Drawing.Point(5, 507);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(78, 23);
            this.btnSelectAll.TabIndex = 9;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(666, 507);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBatchSave
            // 
            this.btnBatchSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchSave.Location = new System.Drawing.Point(582, 507);
            this.btnBatchSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBatchSave.Name = "btnBatchSave";
            this.btnBatchSave.Size = new System.Drawing.Size(75, 23);
            this.btnBatchSave.TabIndex = 11;
            this.btnBatchSave.Text = "保存(&S)";
            this.btnBatchSave.UseVisualStyleBackColor = true;
            this.btnBatchSave.Click += new System.EventHandler(this.btnBatchSave_Click);
            // 
            // tvOrganize
            // 
            this.tvOrganize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvOrganize.CheckBoxes = true;
            this.tvOrganize.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvOrganize.ImageIndex = 0;
            this.tvOrganize.ImageList = this.imageList;
            this.tvOrganize.Location = new System.Drawing.Point(7, 131);
            this.tvOrganize.Name = "tvOrganize";
            this.tvOrganize.SelectedImageIndex = 1;
            this.tvOrganize.Size = new System.Drawing.Size(735, 369);
            this.tvOrganize.TabIndex = 8;
            this.tvOrganize.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvOrganize_AfterCheck);
            this.tvOrganize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvOrganize_MouseDown);
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
            this.imageList.Images.SetKeyName(22, "Role.gif");
            // 
            // ucPermissionScope
            // 
            this.ucPermissionScope.AllowNull = true;
            this.ucPermissionScope.AllowSelect = false;
            this.ucPermissionScope.Location = new System.Drawing.Point(120, 38);
            this.ucPermissionScope.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucPermissionScope.MultiSelect = false;
            this.ucPermissionScope.Name = "ucPermissionScope";
            this.ucPermissionScope.SelectedFullName = "";
            this.ucPermissionScope.SelectedId = "";
            this.ucPermissionScope.Size = new System.Drawing.Size(290, 22);
            this.ucPermissionScope.TabIndex = 5;
            // 
            // lblPermissionScope
            // 
            this.lblPermissionScope.Location = new System.Drawing.Point(6, 42);
            this.lblPermissionScope.Name = "lblPermissionScope";
            this.lblPermissionScope.Size = new System.Drawing.Size(108, 12);
            this.lblPermissionScope.TabIndex = 4;
            this.lblPermissionScope.Text = "数据权限：";
            this.lblPermissionScope.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPermissionScopeReq
            // 
            this.lblPermissionScopeReq.AutoSize = true;
            this.lblPermissionScopeReq.ForeColor = System.Drawing.Color.Red;
            this.lblPermissionScopeReq.Location = new System.Drawing.Point(417, 44);
            this.lblPermissionScopeReq.Name = "lblPermissionScopeReq";
            this.lblPermissionScopeReq.Size = new System.Drawing.Size(11, 12);
            this.lblPermissionScopeReq.TabIndex = 6;
            this.lblPermissionScopeReq.Text = "*";
            // 
            // ucUser
            // 
            this.ucUser.AllowNull = true;
            this.ucUser.AllowSelect = false;
            this.ucUser.Location = new System.Drawing.Point(120, 10);
            this.ucUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucUser.MultiSelect = false;
            this.ucUser.Name = "ucUser";
            this.ucUser.OpenId = "";
            this.ucUser.PermissionItemScopeCode = "";
            this.ucUser.RemoveIds = null;
            this.ucUser.SelectedFullName = "";
            this.ucUser.SelectedId = "";
            this.ucUser.SelectedIds = null;
            this.ucUser.SetSelectIds = null;
            this.ucUser.Size = new System.Drawing.Size(290, 22);
            this.ucUser.TabIndex = 1;
            // 
            // lblStaffReq
            // 
            this.lblStaffReq.AutoSize = true;
            this.lblStaffReq.ForeColor = System.Drawing.Color.Red;
            this.lblStaffReq.Location = new System.Drawing.Point(417, 15);
            this.lblStaffReq.Name = "lblStaffReq";
            this.lblStaffReq.Size = new System.Drawing.Size(11, 12);
            this.lblStaffReq.TabIndex = 2;
            this.lblStaffReq.Text = "*";
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(6, 14);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(108, 12);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "用户：";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grbPermissionScope
            // 
            this.grbPermissionScope.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbPermissionScope.Controls.Add(this.rdbUserSubCompany);
            this.grbPermissionScope.Controls.Add(this.rdbNone);
            this.grbPermissionScope.Controls.Add(this.rdbDetail);
            this.grbPermissionScope.Controls.Add(this.rdbUser);
            this.grbPermissionScope.Controls.Add(this.rdbUserWorkgroup);
            this.grbPermissionScope.Controls.Add(this.rdbUserDepartment);
            this.grbPermissionScope.Controls.Add(this.rdbUserCompany);
            this.grbPermissionScope.Controls.Add(this.rdbAll);
            this.grbPermissionScope.Location = new System.Drawing.Point(8, 67);
            this.grbPermissionScope.Name = "grbPermissionScope";
            this.grbPermissionScope.Size = new System.Drawing.Size(734, 54);
            this.grbPermissionScope.TabIndex = 7;
            this.grbPermissionScope.TabStop = false;
            this.grbPermissionScope.Text = "权限范围";
            // 
            // rdbUserSubCompany
            // 
            this.rdbUserSubCompany.AutoSize = true;
            this.rdbUserSubCompany.Location = new System.Drawing.Point(172, 20);
            this.rdbUserSubCompany.Name = "rdbUserSubCompany";
            this.rdbUserSubCompany.Size = new System.Drawing.Size(95, 16);
            this.rdbUserSubCompany.TabIndex = 2;
            this.rdbUserSubCompany.Text = "所在分支机构";
            this.rdbUserSubCompany.UseVisualStyleBackColor = true;
            // 
            // rdbNone
            // 
            this.rdbNone.AutoSize = true;
            this.rdbNone.Location = new System.Drawing.Point(608, 20);
            this.rdbNone.Name = "rdbNone";
            this.rdbNone.Size = new System.Drawing.Size(35, 16);
            this.rdbNone.TabIndex = 7;
            this.rdbNone.Text = "无";
            this.rdbNone.UseVisualStyleBackColor = true;
            // 
            // rdbDetail
            // 
            this.rdbDetail.AutoSize = true;
            this.rdbDetail.Checked = true;
            this.rdbDetail.Location = new System.Drawing.Point(516, 20);
            this.rdbDetail.Name = "rdbDetail";
            this.rdbDetail.Size = new System.Drawing.Size(83, 16);
            this.rdbDetail.TabIndex = 6;
            this.rdbDetail.TabStop = true;
            this.rdbDetail.Text = "按明细设置";
            this.rdbDetail.UseVisualStyleBackColor = true;
            // 
            // rdbUser
            // 
            this.rdbUser.AutoSize = true;
            this.rdbUser.Location = new System.Drawing.Point(448, 20);
            this.rdbUser.Name = "rdbUser";
            this.rdbUser.Size = new System.Drawing.Size(59, 16);
            this.rdbUser.TabIndex = 5;
            this.rdbUser.Text = "仅本人";
            this.rdbUser.UseVisualStyleBackColor = true;
            // 
            // rdbUserWorkgroup
            // 
            this.rdbUserWorkgroup.AutoSize = true;
            this.rdbUserWorkgroup.Location = new System.Drawing.Point(356, 20);
            this.rdbUserWorkgroup.Name = "rdbUserWorkgroup";
            this.rdbUserWorkgroup.Size = new System.Drawing.Size(83, 16);
            this.rdbUserWorkgroup.TabIndex = 4;
            this.rdbUserWorkgroup.Text = "所在工作组";
            this.rdbUserWorkgroup.UseVisualStyleBackColor = true;
            // 
            // rdbUserDepartment
            // 
            this.rdbUserDepartment.AutoSize = true;
            this.rdbUserDepartment.Location = new System.Drawing.Point(276, 20);
            this.rdbUserDepartment.Name = "rdbUserDepartment";
            this.rdbUserDepartment.Size = new System.Drawing.Size(71, 16);
            this.rdbUserDepartment.TabIndex = 3;
            this.rdbUserDepartment.Text = "所在部门";
            this.rdbUserDepartment.UseVisualStyleBackColor = true;
            // 
            // rdbUserCompany
            // 
            this.rdbUserCompany.AutoSize = true;
            this.rdbUserCompany.Location = new System.Drawing.Point(92, 20);
            this.rdbUserCompany.Name = "rdbUserCompany";
            this.rdbUserCompany.Size = new System.Drawing.Size(71, 16);
            this.rdbUserCompany.TabIndex = 1;
            this.rdbUserCompany.Text = "所在公司";
            this.rdbUserCompany.UseVisualStyleBackColor = true;
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Location = new System.Drawing.Point(12, 20);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(71, 16);
            this.rdbAll.TabIndex = 0;
            this.rdbAll.Text = "所有数据";
            this.rdbAll.UseVisualStyleBackColor = true;
            // 
            // chkInnerOrganize
            // 
            this.chkInnerOrganize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkInnerOrganize.AutoSize = true;
            this.chkInnerOrganize.Checked = true;
            this.chkInnerOrganize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInnerOrganize.Location = new System.Drawing.Point(609, 30);
            this.chkInnerOrganize.Name = "chkInnerOrganize";
            this.chkInnerOrganize.Size = new System.Drawing.Size(132, 16);
            this.chkInnerOrganize.TabIndex = 3;
            this.chkInnerOrganize.Text = "仅显示内部组织机构";
            this.chkInnerOrganize.UseVisualStyleBackColor = true;
            this.chkInnerOrganize.CheckedChanged += new System.EventHandler(this.chkInnerOrganize_CheckedChanged);
            // 
            // FrmUserPermissionScope
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(748, 536);
            this.Controls.Add(this.chkInnerOrganize);
            this.Controls.Add(this.grbPermissionScope);
            this.Controls.Add(this.ucUser);
            this.Controls.Add(this.lblStaffReq);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblPermissionScopeReq);
            this.Controls.Add(this.ucPermissionScope);
            this.Controls.Add(this.lblPermissionScope);
            this.Controls.Add(this.btnInvertSelect);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBatchSave);
            this.Controls.Add(this.tvOrganize);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmUserPermissionScope";
            this.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.Text = "用户数据权限设置";
            this.grbPermissionScope.ResumeLayout(false);
            this.grbPermissionScope.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInvertSelect;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBatchSave;
        private System.Windows.Forms.TreeView tvOrganize;
        private DotNet.WinForm.UCScopePermissionSelect ucPermissionScope;
        private System.Windows.Forms.Label lblPermissionScope;
        private System.Windows.Forms.Label lblPermissionScopeReq;
        private DotNet.WinForm.UCUserSelect ucUser;
        private System.Windows.Forms.Label lblStaffReq;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.GroupBox grbPermissionScope;
        private System.Windows.Forms.RadioButton rdbDetail;
        private System.Windows.Forms.RadioButton rdbUser;
        private System.Windows.Forms.RadioButton rdbUserWorkgroup;
        private System.Windows.Forms.RadioButton rdbUserDepartment;
        private System.Windows.Forms.RadioButton rdbUserCompany;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.RadioButton rdbNone;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.RadioButton rdbUserSubCompany;
        private System.Windows.Forms.CheckBox chkInnerOrganize;
    }
}