namespace DotNet.WinForm
{
    partial class FrmResourceSetPermission
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnInvertSelect = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.tcResource = new System.Windows.Forms.TabControl();
            this.tpRole = new System.Windows.Forms.TabPage();
            this.grdRole = new System.Windows.Forms.DataGridView();
            this.colRoleSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpUser = new System.Windows.Forms.TabPage();
            this.grdUser = new System.Windows.Forms.DataGridView();
            this.colUserSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTargetResource = new System.Windows.Forms.Label();
            this.lblPermissionItem = new System.Windows.Forms.Label();
            this.lblPermissionItemName = new System.Windows.Forms.Label();
            this.lblTargetResourceName = new System.Windows.Forms.Label();
            this.tcResource.SuspendLayout();
            this.tpRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRole)).BeginInit();
            this.tpUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInvertSelect
            // 
            this.btnInvertSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvertSelect.Location = new System.Drawing.Point(92, 490);
            this.btnInvertSelect.Name = "btnInvertSelect";
            this.btnInvertSelect.Size = new System.Drawing.Size(78, 23);
            this.btnInvertSelect.TabIndex = 6;
            this.btnInvertSelect.Text = "反选";
            this.btnInvertSelect.UseVisualStyleBackColor = true;
            this.btnInvertSelect.Click += new System.EventHandler(this.btnInvertSelect_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Location = new System.Drawing.Point(6, 490);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(78, 23);
            this.btnSelectAll.TabIndex = 5;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(519, 490);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(437, 490);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 7;
            this.btnConfirm.Text = "保存(&S)";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // tcResource
            // 
            this.tcResource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcResource.Controls.Add(this.tpRole);
            this.tcResource.Controls.Add(this.tpUser);
            this.tcResource.Location = new System.Drawing.Point(6, 70);
            this.tcResource.Name = "tcResource";
            this.tcResource.SelectedIndex = 0;
            this.tcResource.Size = new System.Drawing.Size(590, 414);
            this.tcResource.TabIndex = 4;
            // 
            // tpRole
            // 
            this.tpRole.Controls.Add(this.grdRole);
            this.tpRole.Location = new System.Drawing.Point(4, 22);
            this.tpRole.Name = "tpRole";
            this.tpRole.Padding = new System.Windows.Forms.Padding(3);
            this.tpRole.Size = new System.Drawing.Size(582, 388);
            this.tpRole.TabIndex = 1;
            this.tpRole.Text = "角色";
            this.tpRole.UseVisualStyleBackColor = true;
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
            this.colRoleSelected,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.grdRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRole.Location = new System.Drawing.Point(3, 3);
            this.grdRole.MultiSelect = false;
            this.grdRole.Name = "grdRole";
            this.grdRole.RowTemplate.Height = 23;
            this.grdRole.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdRole.Size = new System.Drawing.Size(576, 382);
            this.grdRole.TabIndex = 3;
            // 
            // colRoleSelected
            // 
            this.colRoleSelected.DataPropertyName = "Selected";
            this.colRoleSelected.Frozen = true;
            this.colRoleSelected.HeaderText = "选择";
            this.colRoleSelected.Name = "colRoleSelected";
            this.colRoleSelected.Width = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "RealName";
            this.dataGridViewTextBoxColumn1.HeaderText = "名称";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 250;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn2.HeaderText = "描述";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 205;
            // 
            // tpUser
            // 
            this.tpUser.BackColor = System.Drawing.Color.Transparent;
            this.tpUser.Controls.Add(this.grdUser);
            this.tpUser.Location = new System.Drawing.Point(4, 22);
            this.tpUser.Name = "tpUser";
            this.tpUser.Padding = new System.Windows.Forms.Padding(3);
            this.tpUser.Size = new System.Drawing.Size(582, 388);
            this.tpUser.TabIndex = 0;
            this.tpUser.Text = "用户";
            this.tpUser.UseVisualStyleBackColor = true;
            // 
            // grdUser
            // 
            this.grdUser.AllowUserToAddRows = false;
            this.grdUser.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.grdUser.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdUser.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUserSelected,
            this.colUserName,
            this.colRealName,
            this.colDescription});
            this.grdUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUser.Location = new System.Drawing.Point(3, 3);
            this.grdUser.MultiSelect = false;
            this.grdUser.Name = "grdUser";
            this.grdUser.RowTemplate.Height = 23;
            this.grdUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdUser.Size = new System.Drawing.Size(576, 382);
            this.grdUser.TabIndex = 2;
            // 
            // colUserSelected
            // 
            this.colUserSelected.DataPropertyName = "Selected";
            this.colUserSelected.Frozen = true;
            this.colUserSelected.HeaderText = "选择";
            this.colUserSelected.Name = "colUserSelected";
            this.colUserSelected.Width = 50;
            // 
            // colUserName
            // 
            this.colUserName.DataPropertyName = "UserName";
            this.colUserName.HeaderText = "用戶";
            this.colUserName.Name = "colUserName";
            this.colUserName.ReadOnly = true;
            this.colUserName.Width = 150;
            // 
            // colRealName
            // 
            this.colRealName.DataPropertyName = "RealName";
            this.colRealName.HeaderText = "姓名";
            this.colRealName.Name = "colRealName";
            this.colRealName.ReadOnly = true;
            this.colRealName.Width = 150;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "描述";
            this.colDescription.MaxInputLength = 200;
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 150;
            // 
            // lblTargetResource
            // 
            this.lblTargetResource.Location = new System.Drawing.Point(13, 9);
            this.lblTargetResource.Name = "lblTargetResource";
            this.lblTargetResource.Size = new System.Drawing.Size(128, 12);
            this.lblTargetResource.TabIndex = 0;
            this.lblTargetResource.Text = "当前资源：";
            this.lblTargetResource.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPermissionItem
            // 
            this.lblPermissionItem.Location = new System.Drawing.Point(10, 40);
            this.lblPermissionItem.Name = "lblPermissionItem";
            this.lblPermissionItem.Size = new System.Drawing.Size(131, 12);
            this.lblPermissionItem.TabIndex = 2;
            this.lblPermissionItem.Text = "操作权限：";
            this.lblPermissionItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPermissionItemName
            // 
            this.lblPermissionItemName.AutoSize = true;
            this.lblPermissionItemName.Location = new System.Drawing.Point(147, 40);
            this.lblPermissionItemName.Name = "lblPermissionItemName";
            this.lblPermissionItemName.Size = new System.Drawing.Size(53, 12);
            this.lblPermissionItemName.TabIndex = 3;
            this.lblPermissionItemName.Text = "管理权限";
            this.lblPermissionItemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTargetResourceName
            // 
            this.lblTargetResourceName.AutoSize = true;
            this.lblTargetResourceName.Location = new System.Drawing.Point(147, 9);
            this.lblTargetResourceName.Name = "lblTargetResourceName";
            this.lblTargetResourceName.Size = new System.Drawing.Size(35, 12);
            this.lblTargetResourceName.TabIndex = 1;
            this.lblTargetResourceName.Text = "资源A";
            this.lblTargetResourceName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmResourceSetPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(602, 519);
            this.Controls.Add(this.lblPermissionItemName);
            this.Controls.Add(this.lblTargetResourceName);
            this.Controls.Add(this.lblPermissionItem);
            this.Controls.Add(this.lblTargetResource);
            this.Controls.Add(this.tcResource);
            this.Controls.Add(this.btnInvertSelect);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmResourceSetPermission";
            this.Text = "资源权限设置";
            this.tcResource.ResumeLayout(false);
            this.tpRole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRole)).EndInit();
            this.tpUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInvertSelect;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TabControl tcResource;
        private System.Windows.Forms.TabPage tpUser;
        private System.Windows.Forms.DataGridView grdUser;
        private System.Windows.Forms.Label lblTargetResource;
        private System.Windows.Forms.Label lblPermissionItem;
        private System.Windows.Forms.Label lblPermissionItemName;
        private System.Windows.Forms.Label lblTargetResourceName;
        private System.Windows.Forms.TabPage tpRole;
        private System.Windows.Forms.DataGridView grdRole;
        //private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        //private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colRoleSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUserSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
    }
}