namespace DotNet.WinForm
{
    partial class FrmResourcePermission
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
            this.lblResource = new System.Windows.Forms.Label();
            this.lblPermissionItem = new System.Windows.Forms.Label();
            this.lblPermissionItemName = new System.Windows.Forms.Label();
            this.lblResourceName = new System.Windows.Forms.Label();
            this.tcTargetResource.SuspendLayout();
            this.tpTargetResource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTargetResource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInvertSelect
            // 
            this.btnInvertSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvertSelect.Location = new System.Drawing.Point(91, 465);
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
            this.btnSelectAll.Location = new System.Drawing.Point(6, 465);
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
            this.btnCancel.Location = new System.Drawing.Point(450, 465);
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
            this.btnConfirm.Location = new System.Drawing.Point(369, 465);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 7;
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
            this.tcTargetResource.Location = new System.Drawing.Point(6, 71);
            this.tcTargetResource.Name = "tcTargetResource";
            this.tcTargetResource.SelectedIndex = 0;
            this.tcTargetResource.Size = new System.Drawing.Size(521, 388);
            this.tcTargetResource.TabIndex = 4;
            // 
            // tpTargetResource
            // 
            this.tpTargetResource.BackColor = System.Drawing.SystemColors.Control;
            this.tpTargetResource.Controls.Add(this.grdTargetResource);
            this.tpTargetResource.Location = new System.Drawing.Point(4, 22);
            this.tpTargetResource.Name = "tpTargetResource";
            this.tpTargetResource.Padding = new System.Windows.Forms.Padding(3);
            this.tpTargetResource.Size = new System.Drawing.Size(513, 362);
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
            this.grdTargetResource.Size = new System.Drawing.Size(501, 351);
            this.grdTargetResource.TabIndex = 0;
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
            // lblResource
            // 
            this.lblResource.Location = new System.Drawing.Point(8, 9);
            this.lblResource.Name = "lblResource";
            this.lblResource.Size = new System.Drawing.Size(82, 12);
            this.lblResource.TabIndex = 0;
            this.lblResource.Text = "当前对象：";
            this.lblResource.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPermissionItem
            // 
            this.lblPermissionItem.Location = new System.Drawing.Point(8, 40);
            this.lblPermissionItem.Name = "lblPermissionItem";
            this.lblPermissionItem.Size = new System.Drawing.Size(82, 12);
            this.lblPermissionItem.TabIndex = 2;
            this.lblPermissionItem.Text = "操作权限：";
            this.lblPermissionItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPermissionItemName
            // 
            this.lblPermissionItemName.AutoSize = true;
            this.lblPermissionItemName.Location = new System.Drawing.Point(94, 40);
            this.lblPermissionItemName.Name = "lblPermissionItemName";
            this.lblPermissionItemName.Size = new System.Drawing.Size(53, 12);
            this.lblPermissionItemName.TabIndex = 3;
            this.lblPermissionItemName.Text = "管理权限";
            this.lblPermissionItemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblResourceName
            // 
            this.lblResourceName.AutoSize = true;
            this.lblResourceName.Location = new System.Drawing.Point(94, 9);
            this.lblResourceName.Name = "lblResourceName";
            this.lblResourceName.Size = new System.Drawing.Size(35, 12);
            this.lblResourceName.TabIndex = 1;
            this.lblResourceName.Text = "用户A";
            this.lblResourceName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmResourcePermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(533, 494);
            this.Controls.Add(this.lblPermissionItemName);
            this.Controls.Add(this.lblResourceName);
            this.Controls.Add(this.lblPermissionItem);
            this.Controls.Add(this.lblResource);
            this.Controls.Add(this.tcTargetResource);
            this.Controls.Add(this.btnInvertSelect);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmResourcePermission";
            this.Text = "数据权限设置(列表资源)";
            this.tcTargetResource.ResumeLayout(false);
            this.tpTargetResource.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTargetResource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInvertSelect;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TabControl tcTargetResource;
        private System.Windows.Forms.TabPage tpTargetResource;
        private System.Windows.Forms.DataGridView grdTargetResource;
        private System.Windows.Forms.Label lblResource;
        private System.Windows.Forms.Label lblPermissionItem;
        private System.Windows.Forms.Label lblPermissionItemName;
        private System.Windows.Forms.Label lblResourceName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
    }
}