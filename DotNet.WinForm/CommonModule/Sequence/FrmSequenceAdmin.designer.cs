namespace DotNet.WinForm
{
    partial class FrmSequenceAdmin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdSequence = new System.Windows.Forms.DataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeparator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReduction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnInvertSelect = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblContents = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnHide = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdSequence)).BeginInit();
            this.SuspendLayout();
            // 
            // grdSequence
            // 
            this.grdSequence.AllowUserToAddRows = false;
            this.grdSequence.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.grdSequence.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSequence.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSequence.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSequence.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdSequence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSequence.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colFullName,
            this.colPrefix,
            this.colSeparator,
            this.colSequence,
            this.colReduction,
            this.colStep,
            this.colDescription});
            this.grdSequence.Location = new System.Drawing.Point(8, 40);
            this.grdSequence.MultiSelect = false;
            this.grdSequence.Name = "grdSequence";
            this.grdSequence.RowTemplate.Height = 23;
            this.grdSequence.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSequence.Size = new System.Drawing.Size(823, 480);
            this.grdSequence.TabIndex = 3;
            this.grdSequence.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSequence_CellDoubleClick);
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "Selected";
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Width = 45;
            // 
            // colFullName
            // 
            this.colFullName.DataPropertyName = "FullName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colFullName.DefaultCellStyle = dataGridViewCellStyle3;
            this.colFullName.FillWeight = 200F;
            this.colFullName.HeaderText = "名称";
            this.colFullName.Name = "colFullName";
            this.colFullName.ReadOnly = true;
            this.colFullName.Width = 200;
            // 
            // colPrefix
            // 
            this.colPrefix.DataPropertyName = "Prefix";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colPrefix.DefaultCellStyle = dataGridViewCellStyle4;
            this.colPrefix.FillWeight = 60F;
            this.colPrefix.HeaderText = "前缀";
            this.colPrefix.MaxInputLength = 20;
            this.colPrefix.Name = "colPrefix";
            this.colPrefix.ReadOnly = true;
            this.colPrefix.Width = 60;
            // 
            // colSeparator
            // 
            this.colSeparator.DataPropertyName = "Separator";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colSeparator.DefaultCellStyle = dataGridViewCellStyle5;
            this.colSeparator.HeaderText = "分隔符";
            this.colSeparator.MaxInputLength = 20;
            this.colSeparator.Name = "colSeparator";
            this.colSeparator.ReadOnly = true;
            // 
            // colSequence
            // 
            this.colSequence.DataPropertyName = "Sequence";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colSequence.DefaultCellStyle = dataGridViewCellStyle6;
            this.colSequence.FillWeight = 80F;
            this.colSequence.HeaderText = "增序列";
            this.colSequence.MaxInputLength = 20;
            this.colSequence.Name = "colSequence";
            this.colSequence.ReadOnly = true;
            this.colSequence.Width = 80;
            // 
            // colReduction
            // 
            this.colReduction.DataPropertyName = "Reduction";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colReduction.DefaultCellStyle = dataGridViewCellStyle7;
            this.colReduction.FillWeight = 80F;
            this.colReduction.HeaderText = "减序列";
            this.colReduction.MaxInputLength = 20;
            this.colReduction.Name = "colReduction";
            this.colReduction.ReadOnly = true;
            this.colReduction.Width = 80;
            // 
            // colStep
            // 
            this.colStep.DataPropertyName = "Step";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colStep.DefaultCellStyle = dataGridViewCellStyle8;
            this.colStep.FillWeight = 60F;
            this.colStep.HeaderText = "步调";
            this.colStep.MaxInputLength = 20;
            this.colStep.Name = "colStep";
            this.colStep.ReadOnly = true;
            this.colStep.Width = 60;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colDescription.DefaultCellStyle = dataGridViewCellStyle9;
            this.colDescription.HeaderText = "描述";
            this.colDescription.MaxInputLength = 200;
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 130;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(674, 524);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(754, 524);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Enabled = false;
            this.btnSelectAll.Location = new System.Drawing.Point(6, 524);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(78, 23);
            this.btnSelectAll.TabIndex = 4;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnInvertSelect
            // 
            this.btnInvertSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvertSelect.Enabled = false;
            this.btnInvertSelect.Location = new System.Drawing.Point(89, 524);
            this.btnInvertSelect.Name = "btnInvertSelect";
            this.btnInvertSelect.Size = new System.Drawing.Size(78, 23);
            this.btnInvertSelect.TabIndex = 5;
            this.btnInvertSelect.Text = "反选";
            this.btnInvertSelect.UseVisualStyleBackColor = true;
            this.btnInvertSelect.Click += new System.EventHandler(this.btnInvertSelect_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(594, 524);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "重置(&R)";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(720, 8);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(111, 23);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "导出Excel...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblContents
            // 
            this.lblContents.Location = new System.Drawing.Point(23, 15);
            this.lblContents.Name = "lblContents";
            this.lblContents.Size = new System.Drawing.Size(90, 12);
            this.lblContents.TabIndex = 0;
            this.lblContents.Text = "查询内容(&C)：";
            this.lblContents.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(118, 11);
            this.txtSearch.MaxLength = 20;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(171, 21);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(292, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询(&F)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(354, 524);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "添加(&A)...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(434, 524);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "编辑(&E)...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(390, 14);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(72, 16);
            this.chkAll.TabIndex = 12;
            this.chkAll.Text = "显示所有";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // btnHide
            // 
            this.btnHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHide.Location = new System.Drawing.Point(514, 524);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(75, 23);
            this.btnHide.TabIndex = 13;
            this.btnHide.Text = "隐藏(&H)";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // FrmSequenceAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(841, 551);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lblContents);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnInvertSelect);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.grdSequence);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmSequenceAdmin";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "序号（流水号）管理";
            ((System.ComponentModel.ISupportInitialize)(this.grdSequence)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdSequence;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnInvertSelect;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblContents;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeparator;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSequence;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReduction;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStep;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnHide;
    }
}