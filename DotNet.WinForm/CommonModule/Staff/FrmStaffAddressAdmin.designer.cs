namespace DotNet.WinForm
{
    partial class FrmStaffAddressAdmin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdStaffAddress = new System.Windows.Forms.DataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDuty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShortNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOICQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBatchSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnMyAddress = new System.Windows.Forms.Button();
            this.pager = new DotNet.WinForm.Pager();
            this.lblOrganize = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnAll = new System.Windows.Forms.Button();
            this.ucOrganize = new DotNet.WinForm.UCOrganizeSelect();
            ((System.ComponentModel.ISupportInitialize)(this.grdStaffAddress)).BeginInit();
            this.SuspendLayout();
            // 
            // grdStaffAddress
            // 
            this.grdStaffAddress.AllowUserToAddRows = false;
            this.grdStaffAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdStaffAddress.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdStaffAddress.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdStaffAddress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdStaffAddress.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colRealName,
            this.colDepFullName,
            this.colDuty,
            this.colTel,
            this.colMobile,
            this.colShortNumber,
            this.colEmail,
            this.colOICQ,
            this.colDescription});
            this.grdStaffAddress.Location = new System.Drawing.Point(9, 40);
            this.grdStaffAddress.MultiSelect = false;
            this.grdStaffAddress.Name = "grdStaffAddress";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdStaffAddress.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.grdStaffAddress.RowTemplate.Height = 23;
            this.grdStaffAddress.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdStaffAddress.Size = new System.Drawing.Size(951, 472);
            this.grdStaffAddress.TabIndex = 6;
            this.grdStaffAddress.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdStaffAddress_CellDoubleClick);
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "Selected";
            this.colSelected.FillWeight = 50F;
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSelected.Width = 50;
            // 
            // colRealName
            // 
            this.colRealName.DataPropertyName = "RealName";
            this.colRealName.FillWeight = 80F;
            this.colRealName.Frozen = true;
            this.colRealName.HeaderText = "姓名";
            this.colRealName.MaxInputLength = 20;
            this.colRealName.Name = "colRealName";
            this.colRealName.ReadOnly = true;
            this.colRealName.Width = 80;
            // 
            // colDepFullName
            // 
            this.colDepFullName.DataPropertyName = "DepartmentName";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.colDepFullName.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDepFullName.FillWeight = 150F;
            this.colDepFullName.Frozen = true;
            this.colDepFullName.HeaderText = "部门";
            this.colDepFullName.MaxInputLength = 20;
            this.colDepFullName.Name = "colDepFullName";
            this.colDepFullName.ReadOnly = true;
            this.colDepFullName.Width = 150;
            // 
            // colDuty
            // 
            this.colDuty.DataPropertyName = "DutyName";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.colDuty.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDuty.Frozen = true;
            this.colDuty.HeaderText = "职位";
            this.colDuty.MaxInputLength = 20;
            this.colDuty.Name = "colDuty";
            this.colDuty.ReadOnly = true;
            this.colDuty.Width = 80;
            // 
            // colTel
            // 
            this.colTel.DataPropertyName = "OfficePhone";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colTel.DefaultCellStyle = dataGridViewCellStyle4;
            this.colTel.HeaderText = "办公电话";
            this.colTel.MaxInputLength = 20;
            this.colTel.Name = "colTel";
            // 
            // colMobile
            // 
            this.colMobile.DataPropertyName = "Mobile";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colMobile.DefaultCellStyle = dataGridViewCellStyle5;
            this.colMobile.HeaderText = "手机";
            this.colMobile.MaxInputLength = 20;
            this.colMobile.Name = "colMobile";
            // 
            // colShortNumber
            // 
            this.colShortNumber.DataPropertyName = "ShortNumber";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colShortNumber.DefaultCellStyle = dataGridViewCellStyle6;
            this.colShortNumber.HeaderText = "短号";
            this.colShortNumber.MaxInputLength = 20;
            this.colShortNumber.Name = "colShortNumber";
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "Email";
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colEmail.DefaultCellStyle = dataGridViewCellStyle7;
            this.colEmail.FillWeight = 150F;
            this.colEmail.HeaderText = "电子邮箱";
            this.colEmail.MaxInputLength = 100;
            this.colEmail.Name = "colEmail";
            this.colEmail.Width = 150;
            // 
            // colOICQ
            // 
            this.colOICQ.DataPropertyName = "OICQ";
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colOICQ.DefaultCellStyle = dataGridViewCellStyle8;
            this.colOICQ.HeaderText = "QQ";
            this.colOICQ.MaxInputLength = 20;
            this.colOICQ.Name = "colOICQ";
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colDescription.DefaultCellStyle = dataGridViewCellStyle9;
            this.colDescription.HeaderText = "描述";
            this.colDescription.MaxInputLength = 200;
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 150;
            // 
            // btnBatchSave
            // 
            this.btnBatchSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchSave.Enabled = false;
            this.btnBatchSave.Location = new System.Drawing.Point(780, 544);
            this.btnBatchSave.Name = "btnBatchSave";
            this.btnBatchSave.Size = new System.Drawing.Size(100, 23);
            this.btnBatchSave.TabIndex = 12;
            this.btnBatchSave.Text = "保存(&S)";
            this.btnBatchSave.UseVisualStyleBackColor = true;
            this.btnBatchSave.Click += new System.EventHandler(this.btnBatchSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(885, 544);
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
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(675, 544);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 23);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.Text = "编辑(&E)...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(842, 9);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(119, 23);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "导出E&xcel...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(569, 544);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "添加(&A)...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnMyAddress
            // 
            this.btnMyAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMyAddress.Location = new System.Drawing.Point(9, 544);
            this.btnMyAddress.Name = "btnMyAddress";
            this.btnMyAddress.Size = new System.Drawing.Size(137, 23);
            this.btnMyAddress.TabIndex = 8;
            this.btnMyAddress.Text = "我的联系方式(&M)...";
            this.btnMyAddress.UseVisualStyleBackColor = true;
            this.btnMyAddress.Click += new System.EventHandler(this.btnMyAddress_Click);
            // 
            // pager
            // 
            this.pager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pager.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pager.Location = new System.Drawing.Point(526, 518);
            this.pager.Name = "pager";
            this.pager.PageIndex = 1;
            this.pager.RecordCount = 0;
            this.pager.Size = new System.Drawing.Size(432, 24);
            this.pager.TabIndex = 14;
            this.pager.PageChanged += new DotNet.WinForm.PageChangedEventHandler(this.pager_PageChanged);
            // 
            // lblOrganize
            // 
            this.lblOrganize.AutoSize = true;
            this.lblOrganize.Location = new System.Drawing.Point(332, 14);
            this.lblOrganize.Name = "lblOrganize";
            this.lblOrganize.Size = new System.Drawing.Size(89, 12);
            this.lblOrganize.TabIndex = 3;
            this.lblOrganize.Text = "公司/部门(&D)：";
            this.lblOrganize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSize = true;
            this.btnSearch.Location = new System.Drawing.Point(226, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询(&F)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(100, 9);
            this.txtSearch.MaxLength = 20;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(120, 21);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(11, 12);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(83, 12);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "查询内容(&C)：";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(643, 9);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(75, 23);
            this.btnAll.TabIndex = 5;
            this.btnAll.Text = "全部(&A)";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // ucOrganize
            // 
            this.ucOrganize.AllowNull = false;
            this.ucOrganize.AllowSelect = true;
            this.ucOrganize.AutoSize = true;
            this.ucOrganize.CanEdit = false;
            this.ucOrganize.CheckMove = false;
            this.ucOrganize.Location = new System.Drawing.Point(427, 9);
            this.ucOrganize.MultiSelect = false;
            this.ucOrganize.Name = "ucOrganize";
            this.ucOrganize.OpenId = "";
            this.ucOrganize.PermissionItemScopeCode = "";
            this.ucOrganize.SelectedFullName = "";
            this.ucOrganize.SelectedId = "";
            this.ucOrganize.Size = new System.Drawing.Size(213, 23);
            this.ucOrganize.TabIndex = 4;
            this.ucOrganize.SelectedIndexChanged += new DotNet.Utilities.BaseBusinessLogic.SelectedIndexChangedEventHandler(this.Search);
            // 
            // FrmStaffAddressAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(969, 571);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblOrganize);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.pager);
            this.Controls.Add(this.btnMyAddress);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.ucOrganize);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBatchSave);
            this.Controls.Add(this.grdStaffAddress);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MinimumSize = new System.Drawing.Size(390, 281);
            this.Name = "FrmStaffAddressAdmin";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "内部通讯录";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmStaffAddressAdmin_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.grdStaffAddress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdStaffAddress;
        private System.Windows.Forms.Button btnBatchSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDuty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShortNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOICQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.Button btnMyAddress;
        private DotNet.WinForm.Pager pager;
        private System.Windows.Forms.Label lblOrganize;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnAll;
        private UCOrganizeSelect ucOrganize;
    }
}