namespace DotNet.WinForm
{
    partial class FrmUserPermissionView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserPermissionView));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpUserInfo = new System.Windows.Forms.TabPage();
            this.btnExport = new System.Windows.Forms.Button();
            this.grpRole = new System.Windows.Forms.GroupBox();
            this.grdRole = new System.Windows.Forms.DataGridView();
            this.colRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnShowRolePermission = new System.Windows.Forms.Button();
            this.tpModule = new System.Windows.Forms.TabPage();
            this.grpModule = new System.Windows.Forms.GroupBox();
            this.tvModule = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tpPermission = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tvPermissionItem = new System.Windows.Forms.TreeView();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tpColumnScope = new System.Windows.Forms.TabPage();
            this.grpPermission = new System.Windows.Forms.GroupBox();
            this.grdTable = new System.Windows.Forms.DataGridView();
            this.colTableCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPermissionConstraint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tpUserInfo.SuspendLayout();
            this.grpRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRole)).BeginInit();
            this.tpModule.SuspendLayout();
            this.grpModule.SuspendLayout();
            this.tpPermission.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tpColumnScope.SuspendLayout();
            this.grpPermission.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTable)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRole
            // 
            this.txtRole.Location = new System.Drawing.Point(118, 79);
            this.txtRole.Name = "txtRole";
            this.txtRole.ReadOnly = true;
            this.txtRole.Size = new System.Drawing.Size(222, 21);
            this.txtRole.TabIndex = 5;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(118, 50);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.ReadOnly = true;
            this.txtFullName.Size = new System.Drawing.Size(222, 21);
            this.txtFullName.TabIndex = 3;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(118, 23);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(222, 21);
            this.txtUserName.TabIndex = 1;
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(36, 26);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(77, 12);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "登录用户名：";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(36, 53);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(77, 12);
            this.lblFullName.TabIndex = 1;
            this.lblFullName.Text = "姓名：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRole
            // 
            this.lblRole.Location = new System.Drawing.Point(36, 83);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(77, 12);
            this.lblRole.TabIndex = 4;
            this.lblRole.Text = "默认角色：";
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(694, 488);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpUserInfo);
            this.tabControl1.Controls.Add(this.tpModule);
            this.tabControl1.Controls.Add(this.tpPermission);
            this.tabControl1.Controls.Add(this.tpColumnScope);
            this.tabControl1.Location = new System.Drawing.Point(5, 11);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(769, 470);
            this.tabControl1.TabIndex = 14;
            // 
            // tpUserInfo
            // 
            this.tpUserInfo.Controls.Add(this.btnExport);
            this.tpUserInfo.Controls.Add(this.grpRole);
            this.tpUserInfo.Controls.Add(this.btnShowRolePermission);
            this.tpUserInfo.Controls.Add(this.txtUserName);
            this.tpUserInfo.Controls.Add(this.lblUserName);
            this.tpUserInfo.Controls.Add(this.txtRole);
            this.tpUserInfo.Controls.Add(this.txtFullName);
            this.tpUserInfo.Controls.Add(this.lblFullName);
            this.tpUserInfo.Controls.Add(this.lblRole);
            this.tpUserInfo.Location = new System.Drawing.Point(4, 22);
            this.tpUserInfo.Name = "tpUserInfo";
            this.tpUserInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpUserInfo.Size = new System.Drawing.Size(761, 444);
            this.tpUserInfo.TabIndex = 2;
            this.tpUserInfo.Text = "用户信息";
            this.tpUserInfo.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(504, 415);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(111, 23);
            this.btnExport.TabIndex = 11;
            this.btnExport.Text = "导出Excel...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // grpRole
            // 
            this.grpRole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRole.Controls.Add(this.grdRole);
            this.grpRole.Location = new System.Drawing.Point(8, 119);
            this.grpRole.Name = "grpRole";
            this.grpRole.Size = new System.Drawing.Size(747, 293);
            this.grpRole.TabIndex = 8;
            this.grpRole.TabStop = false;
            this.grpRole.Text = "归属角色";
            // 
            // grdRole
            // 
            this.grdRole.AllowUserToAddRows = false;
            this.grdRole.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.grdRole.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdRole.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdRole.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdRole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRole.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRealName,
            this.colDescription});
            this.grdRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRole.Location = new System.Drawing.Point(3, 17);
            this.grdRole.MultiSelect = false;
            this.grdRole.Name = "grdRole";
            this.grdRole.ReadOnly = true;
            this.grdRole.RowTemplate.Height = 23;
            this.grdRole.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdRole.Size = new System.Drawing.Size(741, 273);
            this.grdRole.TabIndex = 6;
            // 
            // colRealName
            // 
            this.colRealName.DataPropertyName = "RealName";
            this.colRealName.HeaderText = "角色名称";
            this.colRealName.Name = "colRealName";
            this.colRealName.ReadOnly = true;
            this.colRealName.Width = 180;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "描述";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 250;
            // 
            // btnShowRolePermission
            // 
            this.btnShowRolePermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowRolePermission.Location = new System.Drawing.Point(621, 415);
            this.btnShowRolePermission.Name = "btnShowRolePermission";
            this.btnShowRolePermission.Size = new System.Drawing.Size(135, 23);
            this.btnShowRolePermission.TabIndex = 7;
            this.btnShowRolePermission.Text = "察看角色权限...";
            this.btnShowRolePermission.UseVisualStyleBackColor = true;
            this.btnShowRolePermission.Click += new System.EventHandler(this.btnShowRolePermission_Click);
            // 
            // tpModule
            // 
            this.tpModule.Controls.Add(this.grpModule);
            this.tpModule.Location = new System.Drawing.Point(4, 22);
            this.tpModule.Name = "tpModule";
            this.tpModule.Padding = new System.Windows.Forms.Padding(3);
            this.tpModule.Size = new System.Drawing.Size(761, 444);
            this.tpModule.TabIndex = 0;
            this.tpModule.Text = "菜单权限";
            this.tpModule.UseVisualStyleBackColor = true;
            // 
            // grpModule
            // 
            this.grpModule.Controls.Add(this.tvModule);
            this.grpModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpModule.Location = new System.Drawing.Point(3, 3);
            this.grpModule.Name = "grpModule";
            this.grpModule.Size = new System.Drawing.Size(755, 438);
            this.grpModule.TabIndex = 3;
            this.grpModule.TabStop = false;
            this.grpModule.Text = "模块菜单";
            // 
            // tvModule
            // 
            this.tvModule.AllowDrop = true;
            this.tvModule.CheckBoxes = true;
            this.tvModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvModule.ImageIndex = 0;
            this.tvModule.ImageList = this.imageList;
            this.tvModule.Location = new System.Drawing.Point(3, 17);
            this.tvModule.Name = "tvModule";
            this.tvModule.SelectedImageIndex = 0;
            this.tvModule.Size = new System.Drawing.Size(749, 418);
            this.tvModule.TabIndex = 2;
            this.tvModule.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvModule_BeforeCheck);
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
            // tpPermission
            // 
            this.tpPermission.Controls.Add(this.groupBox1);
            this.tpPermission.Location = new System.Drawing.Point(4, 22);
            this.tpPermission.Name = "tpPermission";
            this.tpPermission.Padding = new System.Windows.Forms.Padding(3);
            this.tpPermission.Size = new System.Drawing.Size(761, 444);
            this.tpPermission.TabIndex = 4;
            this.tpPermission.Text = "操作权限";
            this.tpPermission.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tvPermissionItem);
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(755, 438);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作权限项";
            // 
            // tvPermissionItem
            // 
            this.tvPermissionItem.AllowDrop = true;
            this.tvPermissionItem.CheckBoxes = true;
            this.tvPermissionItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPermissionItem.ImageIndex = 0;
            this.tvPermissionItem.ImageList = this.imageList;
            this.tvPermissionItem.Location = new System.Drawing.Point(3, 17);
            this.tvPermissionItem.Name = "tvPermissionItem";
            this.tvPermissionItem.SelectedImageIndex = 0;
            this.tvPermissionItem.Size = new System.Drawing.Size(749, 418);
            this.tvPermissionItem.TabIndex = 3;
            this.tvPermissionItem.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvPermissionItem_BeforeCheck);
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.CheckBoxes = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList;
            this.treeView1.Location = new System.Drawing.Point(3, 17);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(749, 418);
            this.treeView1.TabIndex = 2;
            // 
            // tpColumnScope
            // 
            this.tpColumnScope.Controls.Add(this.grpPermission);
            this.tpColumnScope.Location = new System.Drawing.Point(4, 22);
            this.tpColumnScope.Name = "tpColumnScope";
            this.tpColumnScope.Padding = new System.Windows.Forms.Padding(3);
            this.tpColumnScope.Size = new System.Drawing.Size(761, 444);
            this.tpColumnScope.TabIndex = 3;
            this.tpColumnScope.Text = "数据权限";
            this.tpColumnScope.UseVisualStyleBackColor = true;
            // 
            // grpPermission
            // 
            this.grpPermission.Controls.Add(this.grdTable);
            this.grpPermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPermission.Location = new System.Drawing.Point(3, 3);
            this.grpPermission.Name = "grpPermission";
            this.grpPermission.Size = new System.Drawing.Size(755, 438);
            this.grpPermission.TabIndex = 0;
            this.grpPermission.TabStop = false;
            this.grpPermission.Text = "条件约束";
            // 
            // grdTable
            // 
            this.grdTable.AllowUserToAddRows = false;
            this.grdTable.AllowUserToDeleteRows = false;
            this.grdTable.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTableCode,
            this.colTableName,
            this.colPermissionConstraint});
            this.grdTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTable.Location = new System.Drawing.Point(3, 17);
            this.grdTable.MultiSelect = false;
            this.grdTable.Name = "grdTable";
            this.grdTable.RowTemplate.Height = 23;
            this.grdTable.Size = new System.Drawing.Size(749, 418);
            this.grdTable.TabIndex = 4;
            // 
            // colTableCode
            // 
            this.colTableCode.DataPropertyName = "TableCode";
            this.colTableCode.HeaderText = "表";
            this.colTableCode.MaxInputLength = 200;
            this.colTableCode.Name = "colTableCode";
            this.colTableCode.ReadOnly = true;
            this.colTableCode.Width = 150;
            // 
            // colTableName
            // 
            this.colTableName.DataPropertyName = "TableName";
            this.colTableName.HeaderText = "名称";
            this.colTableName.MaxInputLength = 200;
            this.colTableName.Name = "colTableName";
            this.colTableName.ReadOnly = true;
            this.colTableName.Width = 200;
            // 
            // colPermissionConstraint
            // 
            this.colPermissionConstraint.DataPropertyName = "PermissionConstraint";
            this.colPermissionConstraint.HeaderText = "约束条件";
            this.colPermissionConstraint.MaxInputLength = 200;
            this.colPermissionConstraint.Name = "colPermissionConstraint";
            this.colPermissionConstraint.ReadOnly = true;
            this.colPermissionConstraint.Width = 400;
            // 
            // FrmUserPermissionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(778, 516);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControl1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmUserPermissionView";
            this.Text = "用户权限";
            this.tabControl1.ResumeLayout(false);
            this.tpUserInfo.ResumeLayout(false);
            this.tpUserInfo.PerformLayout();
            this.grpRole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRole)).EndInit();
            this.tpModule.ResumeLayout(false);
            this.grpModule.ResumeLayout(false);
            this.tpPermission.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tpColumnScope.ResumeLayout(false);
            this.grpPermission.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpModule;
        private System.Windows.Forms.TabPage tpUserInfo;
        private System.Windows.Forms.TabPage tpColumnScope;
        private System.Windows.Forms.DataGridView grdRole;
        private System.Windows.Forms.Button btnShowRolePermission;
        private System.Windows.Forms.TreeView tvModule;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.GroupBox grpRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.GroupBox grpPermission;
        private System.Windows.Forms.DataGridView grdTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTableCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPermissionConstraint;
        private System.Windows.Forms.GroupBox grpModule;
        private System.Windows.Forms.TabPage tpPermission;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TreeView tvPermissionItem;
        private System.Windows.Forms.Button btnExport;
    }
}