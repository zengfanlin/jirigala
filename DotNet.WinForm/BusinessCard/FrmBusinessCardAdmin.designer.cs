namespace DotNet.WinForm
{
    partial class FrmBusinessCardAdmin
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
            this.grdBusinessCard = new System.Windows.Forms.DataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colStaffFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOfficePhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkPersonal = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBatchSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.ucTableSort = new DotNet.WinForm.UCTableSort();
            this.btnBatchDelete = new System.Windows.Forms.Button();
            this.rbtnAll = new System.Windows.Forms.RadioButton();
            this.rbtnPersonal = new System.Windows.Forms.RadioButton();
            this.rbtnPublic = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdBusinessCard)).BeginInit();
            this.SuspendLayout();
            // 
            // grdBusinessCard
            // 
            this.grdBusinessCard.AllowUserToAddRows = false;
            this.grdBusinessCard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBusinessCard.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdBusinessCard.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdBusinessCard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBusinessCard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colStaffFullName,
            this.colCompany,
            this.colTitle,
            this.colOfficePhone,
            this.chkPersonal,
            this.colMobile,
            this.colEmail,
            this.colQQ,
            this.colDescription,
            this.colCreateBy});
            this.grdBusinessCard.Location = new System.Drawing.Point(9, 86);
            this.grdBusinessCard.MultiSelect = false;
            this.grdBusinessCard.Name = "grdBusinessCard";
            this.grdBusinessCard.RowTemplate.Height = 23;
            this.grdBusinessCard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdBusinessCard.Size = new System.Drawing.Size(875, 450);
            this.grdBusinessCard.TabIndex = 6;
            this.grdBusinessCard.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdStaffAddress_CellDoubleClick);
            this.grdBusinessCard.Sorted += new System.EventHandler(this.grdBusinessCard_Sorted);
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "Selected";
            this.colSelected.FalseValue = "False";
            this.colSelected.FillWeight = 50F;
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSelected.TrueValue = "True";
            this.colSelected.Width = 50;
            // 
            // colStaffFullName
            // 
            this.colStaffFullName.DataPropertyName = "FullName";
            this.colStaffFullName.FillWeight = 80F;
            this.colStaffFullName.Frozen = true;
            this.colStaffFullName.HeaderText = "名称";
            this.colStaffFullName.MaxInputLength = 20;
            this.colStaffFullName.Name = "colStaffFullName";
            this.colStaffFullName.ReadOnly = true;
            this.colStaffFullName.Width = 80;
            // 
            // colCompany
            // 
            this.colCompany.DataPropertyName = "Company";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.colCompany.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCompany.FillWeight = 200F;
            this.colCompany.Frozen = true;
            this.colCompany.HeaderText = "公司";
            this.colCompany.MaxInputLength = 20;
            this.colCompany.Name = "colCompany";
            this.colCompany.ReadOnly = true;
            this.colCompany.Width = 200;
            // 
            // colTitle
            // 
            this.colTitle.DataPropertyName = "Title";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.colTitle.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTitle.FillWeight = 110F;
            this.colTitle.Frozen = true;
            this.colTitle.HeaderText = "职位";
            this.colTitle.MaxInputLength = 20;
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            this.colTitle.Width = 110;
            // 
            // colOfficePhone
            // 
            this.colOfficePhone.DataPropertyName = "OfficePhone";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colOfficePhone.DefaultCellStyle = dataGridViewCellStyle4;
            this.colOfficePhone.HeaderText = "办公电话";
            this.colOfficePhone.MaxInputLength = 20;
            this.colOfficePhone.Name = "colOfficePhone";
            // 
            // chkPersonal
            // 
            this.chkPersonal.DataPropertyName = "Personal";
            this.chkPersonal.FalseValue = "0";
            this.chkPersonal.HeaderText = "私人";
            this.chkPersonal.Name = "chkPersonal";
            this.chkPersonal.TrueValue = "1";
            // 
            // colMobile
            // 
            this.colMobile.DataPropertyName = "Mobile";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colMobile.DefaultCellStyle = dataGridViewCellStyle5;
            this.colMobile.FillWeight = 90F;
            this.colMobile.HeaderText = "手机";
            this.colMobile.MaxInputLength = 20;
            this.colMobile.Name = "colMobile";
            this.colMobile.Width = 90;
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "Email";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colEmail.DefaultCellStyle = dataGridViewCellStyle6;
            this.colEmail.FillWeight = 150F;
            this.colEmail.HeaderText = "电子邮箱";
            this.colEmail.MaxInputLength = 100;
            this.colEmail.Name = "colEmail";
            this.colEmail.Width = 150;
            // 
            // colQQ
            // 
            this.colQQ.DataPropertyName = "QQ";
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colQQ.DefaultCellStyle = dataGridViewCellStyle7;
            this.colQQ.HeaderText = "QQ";
            this.colQQ.MaxInputLength = 20;
            this.colQQ.Name = "colQQ";
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colDescription.DefaultCellStyle = dataGridViewCellStyle8;
            this.colDescription.FillWeight = 250F;
            this.colDescription.HeaderText = "描述";
            this.colDescription.MaxInputLength = 200;
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 250;
            // 
            // colCreateBy
            // 
            this.colCreateBy.DataPropertyName = "CreateBy";
            this.colCreateBy.FillWeight = 80F;
            this.colCreateBy.HeaderText = "创建者";
            this.colCreateBy.MaxInputLength = 40;
            this.colCreateBy.Name = "colCreateBy";
            this.colCreateBy.ReadOnly = true;
            this.colCreateBy.Width = 80;
            // 
            // btnBatchSave
            // 
            this.btnBatchSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchSave.Location = new System.Drawing.Point(730, 546);
            this.btnBatchSave.Name = "btnBatchSave";
            this.btnBatchSave.Size = new System.Drawing.Size(75, 23);
            this.btnBatchSave.TabIndex = 12;
            this.btnBatchSave.Text = "保存(&S)";
            this.btnBatchSave.UseVisualStyleBackColor = true;
            this.btnBatchSave.Click += new System.EventHandler(this.btnBatchSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(807, 546);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(576, 546);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "编辑(&E)...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(773, 22);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(111, 23);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "导出E&xcel...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(264, 60);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询(&F)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Visible = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(92, 61);
            this.txtSearch.MaxLength = 20;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(169, 21);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.Location = new System.Drawing.Point(12, 65);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(77, 12);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "内容(&C)：";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(499, 546);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "添加(&A)...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ucTableSort
            // 
            this.ucTableSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ucTableSort.Location = new System.Drawing.Point(9, 546);
            this.ucTableSort.Margin = new System.Windows.Forms.Padding(0);
            this.ucTableSort.Name = "ucTableSort";
            this.ucTableSort.OEntityId = null;
            this.ucTableSort.Padding = new System.Windows.Forms.Padding(1);
            this.ucTableSort.SetBottomEnabled = false;
            this.ucTableSort.SetDownEnabled = false;
            this.ucTableSort.SetTopEnabled = false;
            this.ucTableSort.SetUpEnabled = false;
            this.ucTableSort.Size = new System.Drawing.Size(99, 24);
            this.ucTableSort.TabIndex = 7;
            // 
            // btnBatchDelete
            // 
            this.btnBatchDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchDelete.Location = new System.Drawing.Point(653, 546);
            this.btnBatchDelete.Name = "btnBatchDelete";
            this.btnBatchDelete.Size = new System.Drawing.Size(75, 23);
            this.btnBatchDelete.TabIndex = 11;
            this.btnBatchDelete.Text = "删除(&D)";
            this.btnBatchDelete.UseVisualStyleBackColor = true;
            this.btnBatchDelete.Click += new System.EventHandler(this.btnBatchDelete_Click);
            // 
            // rbtnAll
            // 
            this.rbtnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnAll.AutoSize = true;
            this.rbtnAll.Location = new System.Drawing.Point(659, 64);
            this.rbtnAll.Name = "rbtnAll";
            this.rbtnAll.Size = new System.Drawing.Size(47, 16);
            this.rbtnAll.TabIndex = 3;
            this.rbtnAll.Text = "全部";
            this.rbtnAll.UseVisualStyleBackColor = true;
            this.rbtnAll.CheckedChanged += new System.EventHandler(this.rbtnAll_CheckedChanged);
            // 
            // rbtnPersonal
            // 
            this.rbtnPersonal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnPersonal.AutoSize = true;
            this.rbtnPersonal.Location = new System.Drawing.Point(819, 64);
            this.rbtnPersonal.Name = "rbtnPersonal";
            this.rbtnPersonal.Size = new System.Drawing.Size(47, 16);
            this.rbtnPersonal.TabIndex = 5;
            this.rbtnPersonal.Text = "私人";
            this.rbtnPersonal.UseVisualStyleBackColor = true;
            this.rbtnPersonal.CheckedChanged += new System.EventHandler(this.rbtnPersonal_CheckedChanged);
            // 
            // rbtnPublic
            // 
            this.rbtnPublic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnPublic.AutoSize = true;
            this.rbtnPublic.Checked = true;
            this.rbtnPublic.Location = new System.Drawing.Point(739, 64);
            this.rbtnPublic.Name = "rbtnPublic";
            this.rbtnPublic.Size = new System.Drawing.Size(47, 16);
            this.rbtnPublic.TabIndex = 4;
            this.rbtnPublic.TabStop = true;
            this.rbtnPublic.Text = "公开";
            this.rbtnPublic.UseVisualStyleBackColor = true;
            this.rbtnPublic.CheckedChanged += new System.EventHandler(this.rbtnPublic_CheckedChanged);
            // 
            // FrmBusinessCardAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DotNet.WinForm.Properties.Resources.Head;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(893, 572);
            this.Controls.Add(this.rbtnPublic);
            this.Controls.Add(this.rbtnPersonal);
            this.Controls.Add(this.rbtnAll);
            this.Controls.Add(this.btnBatchDelete);
            this.Controls.Add(this.ucTableSort);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBatchSave);
            this.Controls.Add(this.grdBusinessCard);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MinimumSize = new System.Drawing.Size(390, 281);
            this.Name = "FrmBusinessCardAdmin";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "名片管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBusinessCardAdmin_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.grdBusinessCard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdBusinessCard;
        private System.Windows.Forms.Button btnBatchSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnAdd;
        private DotNet.WinForm.UCTableSort ucTableSort;
        private System.Windows.Forms.Button btnBatchDelete;
        private System.Windows.Forms.RadioButton rbtnAll;
        private System.Windows.Forms.RadioButton rbtnPersonal;
        private System.Windows.Forms.RadioButton rbtnPublic;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStaffFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOfficePhone;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkPersonal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateBy;
    }
}