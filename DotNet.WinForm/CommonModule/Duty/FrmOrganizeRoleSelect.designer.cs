namespace DotNet.WinForm
{
    partial class FrmOrganizeRoleSelect
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
            this.pnlRole = new System.Windows.Forms.Panel();
            this.grdRole = new System.Windows.Forms.DataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splOrganize = new System.Windows.Forms.Splitter();
            this.tvOrganize = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnSetNull = new System.Windows.Forms.Button();
            this.pnlRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRole)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlRole
            // 
            this.pnlRole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRole.Controls.Add(this.grdRole);
            this.pnlRole.Controls.Add(this.splOrganize);
            this.pnlRole.Controls.Add(this.tvOrganize);
            this.pnlRole.Location = new System.Drawing.Point(8, 11);
            this.pnlRole.Name = "pnlRole";
            this.pnlRole.Size = new System.Drawing.Size(724, 381);
            this.pnlRole.TabIndex = 1;
            // 
            // grdRole
            // 
            this.grdRole.AllowUserToAddRows = false;
            this.grdRole.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
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
            this.colSelected,
            this.colRealName,
            this.colDescription});
            this.grdRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRole.Location = new System.Drawing.Point(263, 0);
            this.grdRole.Name = "grdRole";
            this.grdRole.RowTemplate.Height = 23;
            this.grdRole.Size = new System.Drawing.Size(461, 381);
            this.grdRole.TabIndex = 0;
            this.grdRole.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdRole_CellDoubleClick);
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
            this.colRealName.MaxInputLength = 50;
            this.colRealName.Name = "colRealName";
            this.colRealName.ReadOnly = true;
            this.colRealName.Width = 150;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.FillWeight = 200F;
            this.colDescription.HeaderText = "描述";
            this.colDescription.MaxInputLength = 200;
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 200;
            // 
            // splOrganize
            // 
            this.splOrganize.Location = new System.Drawing.Point(260, 0);
            this.splOrganize.Name = "splOrganize";
            this.splOrganize.Size = new System.Drawing.Size(3, 381);
            this.splOrganize.TabIndex = 8;
            this.splOrganize.TabStop = false;
            // 
            // tvOrganize
            // 
            this.tvOrganize.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvOrganize.ImageIndex = 0;
            this.tvOrganize.ImageList = this.imageList;
            this.tvOrganize.Location = new System.Drawing.Point(0, 0);
            this.tvOrganize.Name = "tvOrganize";
            this.tvOrganize.SelectedImageIndex = 0;
            this.tvOrganize.Size = new System.Drawing.Size(260, 381);
            this.tvOrganize.TabIndex = 0;
            this.tvOrganize.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOrganize_AfterSelect);
            this.tvOrganize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvOrganize_MouseDown);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(657, 398);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(578, 398);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnSetNull
            // 
            this.btnSetNull.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetNull.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSetNull.Location = new System.Drawing.Point(499, 398);
            this.btnSetNull.Name = "btnSetNull";
            this.btnSetNull.Size = new System.Drawing.Size(75, 23);
            this.btnSetNull.TabIndex = 2;
            this.btnSetNull.Text = "置空(&N)";
            this.btnSetNull.UseVisualStyleBackColor = true;
            this.btnSetNull.Click += new System.EventHandler(this.btnSetNull_Click);
            // 
            // FrmOrganizeRoleSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(740, 426);
            this.Controls.Add(this.btnSetNull);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.pnlRole);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Name = "FrmOrganizeRoleSelect";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "选择岗位";
            this.pnlRole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRole)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRole;
        private System.Windows.Forms.Splitter splOrganize;
        private System.Windows.Forms.TreeView tvOrganize;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button btnSetNull;
        private System.Windows.Forms.DataGridView grdRole;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
    }
}