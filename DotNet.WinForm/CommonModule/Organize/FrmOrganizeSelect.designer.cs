namespace DotNet.WinForm
{
    partial class FrmOrganizeSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOrganizeSelect));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tvOrganize = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnSetNull = new System.Windows.Forms.Button();
            this.tcOrganizeTree = new System.Windows.Forms.TabControl();
            this.tpOrganizeTree = new System.Windows.Forms.TabPage();
            this.tpOrganizeList = new System.Windows.Forms.TabPage();
            this.grdOrganize = new System.Windows.Forms.DataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsInnerOrganize = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblContents = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkInnerOrganize = new System.Windows.Forms.CheckBox();
            this.tcOrganizeTree.SuspendLayout();
            this.tpOrganizeTree.SuspendLayout();
            this.tpOrganizeList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrganize)).BeginInit();
            this.SuspendLayout();
            // 
            // tvOrganize
            // 
            this.tvOrganize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvOrganize.HotTracking = true;
            this.tvOrganize.ImageIndex = 0;
            this.tvOrganize.ImageList = this.imageList;
            this.tvOrganize.Location = new System.Drawing.Point(6, 6);
            this.tvOrganize.Name = "tvOrganize";
            this.tvOrganize.SelectedImageIndex = 1;
            this.tvOrganize.Size = new System.Drawing.Size(655, 393);
            this.tvOrganize.TabIndex = 1;
            this.tvOrganize.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOrganize_AfterSelect);
            this.tvOrganize.Click += new System.EventHandler(this.tvOrganize_Click);
            this.tvOrganize.DoubleClick += new System.EventHandler(this.tvOrganize_DoubleClick);
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
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(603, 456);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(518, 456);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(78, 23);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnSetNull
            // 
            this.btnSetNull.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetNull.Location = new System.Drawing.Point(434, 456);
            this.btnSetNull.Name = "btnSetNull";
            this.btnSetNull.Size = new System.Drawing.Size(78, 23);
            this.btnSetNull.TabIndex = 1;
            this.btnSetNull.Text = "置空(&R)";
            this.btnSetNull.UseVisualStyleBackColor = true;
            this.btnSetNull.Click += new System.EventHandler(this.btnSetNull_Click);
            // 
            // tcOrganizeTree
            // 
            this.tcOrganizeTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcOrganizeTree.Controls.Add(this.tpOrganizeTree);
            this.tcOrganizeTree.Controls.Add(this.tpOrganizeList);
            this.tcOrganizeTree.Location = new System.Drawing.Point(8, 14);
            this.tcOrganizeTree.Name = "tcOrganizeTree";
            this.tcOrganizeTree.SelectedIndex = 0;
            this.tcOrganizeTree.Size = new System.Drawing.Size(675, 430);
            this.tcOrganizeTree.TabIndex = 0;
            // 
            // tpOrganizeTree
            // 
            this.tpOrganizeTree.Controls.Add(this.tvOrganize);
            this.tpOrganizeTree.Location = new System.Drawing.Point(4, 22);
            this.tpOrganizeTree.Name = "tpOrganizeTree";
            this.tpOrganizeTree.Padding = new System.Windows.Forms.Padding(3);
            this.tpOrganizeTree.Size = new System.Drawing.Size(667, 404);
            this.tpOrganizeTree.TabIndex = 0;
            this.tpOrganizeTree.Text = "组织机构";
            this.tpOrganizeTree.UseVisualStyleBackColor = true;
            // 
            // tpOrganizeList
            // 
            this.tpOrganizeList.Controls.Add(this.grdOrganize);
            this.tpOrganizeList.Controls.Add(this.lblContents);
            this.tpOrganizeList.Controls.Add(this.txtSearch);
            this.tpOrganizeList.Controls.Add(this.btnSearch);
            this.tpOrganizeList.Location = new System.Drawing.Point(4, 22);
            this.tpOrganizeList.Name = "tpOrganizeList";
            this.tpOrganizeList.Padding = new System.Windows.Forms.Padding(3);
            this.tpOrganizeList.Size = new System.Drawing.Size(667, 404);
            this.tpOrganizeList.TabIndex = 1;
            this.tpOrganizeList.Text = "查询";
            this.tpOrganizeList.UseVisualStyleBackColor = true;
            // 
            // grdOrganize
            // 
            this.grdOrganize.AllowUserToAddRows = false;
            this.grdOrganize.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.grdOrganize.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdOrganize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdOrganize.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdOrganize.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdOrganize.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdOrganize.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colCode,
            this.colFullName,
            this.colIsInnerOrganize,
            this.colDescription});
            this.grdOrganize.Location = new System.Drawing.Point(6, 35);
            this.grdOrganize.MultiSelect = false;
            this.grdOrganize.Name = "grdOrganize";
            this.grdOrganize.RowTemplate.Height = 23;
            this.grdOrganize.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdOrganize.Size = new System.Drawing.Size(658, 367);
            this.grdOrganize.TabIndex = 16;
            this.grdOrganize.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdOrganize_CellContentClick);
            this.grdOrganize.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdOrganize_CellDoubleClick);
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "Selected";
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Width = 50;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            this.colCode.Frozen = true;
            this.colCode.HeaderText = "编号";
            this.colCode.MaxInputLength = 20;
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            // 
            // colFullName
            // 
            this.colFullName.DataPropertyName = "FullName";
            this.colFullName.FillWeight = 170F;
            this.colFullName.HeaderText = "名称";
            this.colFullName.MaxInputLength = 100;
            this.colFullName.Name = "colFullName";
            this.colFullName.ReadOnly = true;
            this.colFullName.Width = 170;
            // 
            // colIsInnerOrganize
            // 
            this.colIsInnerOrganize.DataPropertyName = "IsInnerOrganize";
            this.colIsInnerOrganize.FalseValue = "0";
            this.colIsInnerOrganize.HeaderText = "内部组织";
            this.colIsInnerOrganize.Name = "colIsInnerOrganize";
            this.colIsInnerOrganize.ReadOnly = true;
            this.colIsInnerOrganize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsInnerOrganize.TrueValue = "1";
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "描述";
            this.colDescription.MaxInputLength = 200;
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 170;
            // 
            // lblContents
            // 
            this.lblContents.Location = new System.Drawing.Point(139, 10);
            this.lblContents.Name = "lblContents";
            this.lblContents.Size = new System.Drawing.Size(74, 12);
            this.lblContents.TabIndex = 13;
            this.lblContents.Text = "查询内容(&C)：";
            this.lblContents.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(228, 6);
            this.txtSearch.MaxLength = 20;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(203, 21);
            this.txtSearch.TabIndex = 14;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(436, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "查询(&F)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chkInnerOrganize
            // 
            this.chkInnerOrganize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkInnerOrganize.AutoSize = true;
            this.chkInnerOrganize.Checked = true;
            this.chkInnerOrganize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInnerOrganize.Location = new System.Drawing.Point(544, 10);
            this.chkInnerOrganize.Name = "chkInnerOrganize";
            this.chkInnerOrganize.Size = new System.Drawing.Size(132, 16);
            this.chkInnerOrganize.TabIndex = 5;
            this.chkInnerOrganize.Text = "仅显示内部组织机构";
            this.chkInnerOrganize.UseVisualStyleBackColor = true;
            this.chkInnerOrganize.CheckedChanged += new System.EventHandler(this.chkInnerOrganize_CheckedChanged);
            // 
            // FrmOrganizeSelect
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(691, 488);
            this.Controls.Add(this.chkInnerOrganize);
            this.Controls.Add(this.tcOrganizeTree);
            this.Controls.Add(this.btnSetNull);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmOrganizeSelect";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "选择组织机构";
            this.tcOrganizeTree.ResumeLayout(false);
            this.tpOrganizeTree.ResumeLayout(false);
            this.tpOrganizeList.ResumeLayout(false);
            this.tpOrganizeList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrganize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TreeView tvOrganize;
        private System.Windows.Forms.Button btnSetNull;
        private System.Windows.Forms.TabControl tcOrganizeTree;
        private System.Windows.Forms.TabPage tpOrganizeTree;
        private System.Windows.Forms.TabPage tpOrganizeList;
        private System.Windows.Forms.Label lblContents;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView grdOrganize;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.CheckBox chkInnerOrganize;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsInnerOrganize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
    }
}