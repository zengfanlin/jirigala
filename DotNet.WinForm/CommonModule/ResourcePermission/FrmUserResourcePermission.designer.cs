namespace DotNet.WinForm
{
    partial class FrmUserResourcePermission
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
            this.btnInvertSelect = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.tcTargetResource = new System.Windows.Forms.TabControl();
            this.tpTargetResource = new System.Windows.Forms.TabPage();
            this.grdTargetResource = new System.Windows.Forms.DataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPermissionItem = new System.Windows.Forms.Label();
            this.lblPermissionItemName = new System.Windows.Forms.Label();
            this.tcRole = new System.Windows.Forms.TabControl();
            this.tpUser = new System.Windows.Forms.TabPage();
            this.lstUser = new System.Windows.Forms.ListBox();
            this.btnClearPermission = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tcTargetResource.SuspendLayout();
            this.tpTargetResource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTargetResource)).BeginInit();
            this.tcRole.SuspendLayout();
            this.tpUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInvertSelect
            // 
            this.btnInvertSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvertSelect.Location = new System.Drawing.Point(90, 373);
            this.btnInvertSelect.Name = "btnInvertSelect";
            this.btnInvertSelect.Size = new System.Drawing.Size(78, 23);
            this.btnInvertSelect.TabIndex = 7;
            this.btnInvertSelect.Text = "反选";
            this.btnInvertSelect.UseVisualStyleBackColor = true;
            this.btnInvertSelect.Click += new System.EventHandler(this.btnInvertSelect_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Location = new System.Drawing.Point(4, 373);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(78, 23);
            this.btnSelectAll.TabIndex = 6;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(427, 373);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(344, 373);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 8;
            this.btnConfirm.Text = "保存(&S)";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // tcTargetResource
            // 
            this.tcTargetResource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcTargetResource.Controls.Add(this.tpTargetResource);
            this.tcTargetResource.Location = new System.Drawing.Point(0, 22);
            this.tcTargetResource.Name = "tcTargetResource";
            this.tcTargetResource.SelectedIndex = 0;
            this.tcTargetResource.Size = new System.Drawing.Size(515, 425);
            this.tcTargetResource.TabIndex = 13;
            // 
            // tpTargetResource
            // 
            this.tpTargetResource.BackColor = System.Drawing.SystemColors.Control;
            this.tpTargetResource.Controls.Add(this.grdTargetResource);
            this.tpTargetResource.Controls.Add(this.btnInvertSelect);
            this.tpTargetResource.Controls.Add(this.btnSelectAll);
            this.tpTargetResource.Controls.Add(this.btnCancel);
            this.tpTargetResource.Controls.Add(this.btnConfirm);
            this.tpTargetResource.Location = new System.Drawing.Point(4, 22);
            this.tpTargetResource.Name = "tpTargetResource";
            this.tpTargetResource.Padding = new System.Windows.Forms.Padding(3);
            this.tpTargetResource.Size = new System.Drawing.Size(507, 399);
            this.tpTargetResource.TabIndex = 0;
            this.tpTargetResource.Text = "目标资源";
            // 
            // grdTargetResource
            // 
            this.grdTargetResource.AllowUserToAddRows = false;
            this.grdTargetResource.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.grdTargetResource.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdTargetResource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTargetResource.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdTargetResource.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdTargetResource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTargetResource.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colRealName,
            this.colDescription});
            this.grdTargetResource.Location = new System.Drawing.Point(6, 6);
            this.grdTargetResource.MultiSelect = false;
            this.grdTargetResource.Name = "grdTargetResource";
            this.grdTargetResource.RowTemplate.Height = 23;
            this.grdTargetResource.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTargetResource.Size = new System.Drawing.Size(495, 360);
            this.grdTargetResource.TabIndex = 2;
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "Selected";
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Width = 50;
            // 
            // colRealName
            // 
            this.colRealName.DataPropertyName = "RealName";
            this.colRealName.HeaderText = "名称";
            this.colRealName.Name = "colRealName";
            this.colRealName.ReadOnly = true;
            this.colRealName.Width = 170;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "描述";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 205;
            // 
            // lblPermissionItem
            // 
            this.lblPermissionItem.Location = new System.Drawing.Point(185, 9);
            this.lblPermissionItem.Name = "lblPermissionItem";
            this.lblPermissionItem.Size = new System.Drawing.Size(184, 12);
            this.lblPermissionItem.TabIndex = 16;
            this.lblPermissionItem.Text = "操作权限：";
            this.lblPermissionItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPermissionItemName
            // 
            this.lblPermissionItemName.AutoSize = true;
            this.lblPermissionItemName.Location = new System.Drawing.Point(373, 9);
            this.lblPermissionItemName.Name = "lblPermissionItemName";
            this.lblPermissionItemName.Size = new System.Drawing.Size(53, 12);
            this.lblPermissionItemName.TabIndex = 19;
            this.lblPermissionItemName.Text = "管理权限";
            this.lblPermissionItemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tcRole
            // 
            this.tcRole.Controls.Add(this.tpUser);
            this.tcRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcRole.Location = new System.Drawing.Point(0, 0);
            this.tcRole.Name = "tcRole";
            this.tcRole.SelectedIndex = 0;
            this.tcRole.Size = new System.Drawing.Size(261, 445);
            this.tcRole.TabIndex = 20;
            // 
            // tpUser
            // 
            this.tpUser.Controls.Add(this.lstUser);
            this.tpUser.Location = new System.Drawing.Point(4, 22);
            this.tpUser.Name = "tpUser";
            this.tpUser.Padding = new System.Windows.Forms.Padding(3);
            this.tpUser.Size = new System.Drawing.Size(253, 419);
            this.tpUser.TabIndex = 0;
            this.tpUser.Text = "用户";
            this.tpUser.UseVisualStyleBackColor = true;
            // 
            // lstUser
            // 
            this.lstUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstUser.FormattingEnabled = true;
            this.lstUser.ItemHeight = 12;
            this.lstUser.Location = new System.Drawing.Point(3, 3);
            this.lstUser.Name = "lstUser";
            this.lstUser.Size = new System.Drawing.Size(247, 413);
            this.lstUser.TabIndex = 0;
            this.lstUser.SelectedIndexChanged += new System.EventHandler(this.lstUser_SelectedIndexChanged);
            // 
            // btnClearPermission
            // 
            this.btnClearPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearPermission.AutoSize = true;
            this.btnClearPermission.Enabled = false;
            this.btnClearPermission.Location = new System.Drawing.Point(22, 3);
            this.btnClearPermission.Name = "btnClearPermission";
            this.btnClearPermission.Size = new System.Drawing.Size(102, 23);
            this.btnClearPermission.TabIndex = 35;
            this.btnClearPermission.Text = "清除权限(&C)";
            this.btnClearPermission.UseVisualStyleBackColor = true;
            this.btnClearPermission.Click += new System.EventHandler(this.btnClearPermission_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaste.AutoSize = true;
            this.btnPaste.Enabled = false;
            this.btnPaste.Location = new System.Drawing.Point(238, 3);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(102, 23);
            this.btnPaste.TabIndex = 34;
            this.btnPaste.Text = "粘贴权限";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.AutoSize = true;
            this.btnCopy.Enabled = false;
            this.btnCopy.Location = new System.Drawing.Point(130, 3);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(102, 23);
            this.btnCopy.TabIndex = 33;
            this.btnCopy.Text = "复制权限";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(6, 36);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tcRole);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblPermissionItem);
            this.splitContainer1.Panel2.Controls.Add(this.lblPermissionItemName);
            this.splitContainer1.Panel2.Controls.Add(this.tcTargetResource);
            this.splitContainer1.Size = new System.Drawing.Size(782, 445);
            this.splitContainer1.SplitterDistance = 261;
            this.splitContainer1.TabIndex = 36;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnPaste);
            this.flowLayoutPanel1.Controls.Add(this.btnCopy);
            this.flowLayoutPanel1.Controls.Add(this.btnClearPermission);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(434, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(343, 27);
            this.flowLayoutPanel1.TabIndex = 37;
            // 
            // FrmUserResourcePermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(794, 485);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.splitContainer1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmUserResourcePermission";
            this.Text = "用户数据权限设置(列表资源)";
            this.tcTargetResource.ResumeLayout(false);
            this.tpTargetResource.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTargetResource)).EndInit();
            this.tcRole.ResumeLayout(false);
            this.tpUser.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInvertSelect;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TabControl tcTargetResource;
        private System.Windows.Forms.TabPage tpTargetResource;
        private System.Windows.Forms.DataGridView grdTargetResource;
        private System.Windows.Forms.Label lblPermissionItem;
        private System.Windows.Forms.Label lblPermissionItemName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.TabControl tcRole;
        private System.Windows.Forms.TabPage tpUser;
        private System.Windows.Forms.ListBox lstUser;
        private System.Windows.Forms.Button btnClearPermission;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}