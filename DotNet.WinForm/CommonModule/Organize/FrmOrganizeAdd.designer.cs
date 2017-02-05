namespace DotNet.WinForm
{
    partial class FrmOrganizeAdd
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
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grbOrganize = new System.Windows.Forms.GroupBox();
            this.lblParentReq = new System.Windows.Forms.Label();
            this.lblFullNameReq = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtPostalcode = new System.Windows.Forms.TextBox();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.lblPostalcode = new System.Windows.Forms.Label();
            this.lblParentOrganize = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.lblShortName = new System.Windows.Forms.Label();
            this.txtWeb = new System.Windows.Forms.TextBox();
            this.lblWeb = new System.Windows.Forms.Label();
            this.chkIsInnerOrganize = new System.Windows.Forms.CheckBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.lblFax = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.ucParent = new DotNet.WinForm.UCOrganizeSelect();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblInnerPhone = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblOuterPhone = new System.Windows.Forms.Label();
            this.txtOuterPhone = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtInnerPhone = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.grbOrganize.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(350, 422);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(78, 23);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(435, 422);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(266, 422);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(78, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grbOrganize
            // 
            this.grbOrganize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbOrganize.Controls.Add(this.lblParentReq);
            this.grbOrganize.Controls.Add(this.lblFullNameReq);
            this.grbOrganize.Controls.Add(this.lblAddress);
            this.grbOrganize.Controls.Add(this.txtPostalcode);
            this.grbOrganize.Controls.Add(this.txtShortName);
            this.grbOrganize.Controls.Add(this.lblPostalcode);
            this.grbOrganize.Controls.Add(this.lblParentOrganize);
            this.grbOrganize.Controls.Add(this.txtFax);
            this.grbOrganize.Controls.Add(this.lblShortName);
            this.grbOrganize.Controls.Add(this.txtWeb);
            this.grbOrganize.Controls.Add(this.lblWeb);
            this.grbOrganize.Controls.Add(this.chkIsInnerOrganize);
            this.grbOrganize.Controls.Add(this.chkEnabled);
            this.grbOrganize.Controls.Add(this.lblFax);
            this.grbOrganize.Controls.Add(this.lblDescription);
            this.grbOrganize.Controls.Add(this.txtDescription);
            this.grbOrganize.Controls.Add(this.txtAddress);
            this.grbOrganize.Controls.Add(this.ucParent);
            this.grbOrganize.Controls.Add(this.cmbCategory);
            this.grbOrganize.Controls.Add(this.lblInnerPhone);
            this.grbOrganize.Controls.Add(this.lblCategory);
            this.grbOrganize.Controls.Add(this.lblOuterPhone);
            this.grbOrganize.Controls.Add(this.txtOuterPhone);
            this.grbOrganize.Controls.Add(this.txtFullName);
            this.grbOrganize.Controls.Add(this.txtCode);
            this.grbOrganize.Controls.Add(this.lblFullName);
            this.grbOrganize.Controls.Add(this.txtInnerPhone);
            this.grbOrganize.Controls.Add(this.lblCode);
            this.grbOrganize.Location = new System.Drawing.Point(17, 9);
            this.grbOrganize.Name = "grbOrganize";
            this.grbOrganize.Size = new System.Drawing.Size(497, 407);
            this.grbOrganize.TabIndex = 0;
            this.grbOrganize.TabStop = false;
            this.grbOrganize.Text = "组织机构";
            // 
            // lblParentReq
            // 
            this.lblParentReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblParentReq.AutoSize = true;
            this.lblParentReq.ForeColor = System.Drawing.Color.Red;
            this.lblParentReq.Location = new System.Drawing.Point(474, 22);
            this.lblParentReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblParentReq.Name = "lblParentReq";
            this.lblParentReq.Size = new System.Drawing.Size(11, 12);
            this.lblParentReq.TabIndex = 2;
            this.lblParentReq.Text = "*";
            // 
            // lblFullNameReq
            // 
            this.lblFullNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullNameReq.AutoSize = true;
            this.lblFullNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblFullNameReq.Location = new System.Drawing.Point(474, 51);
            this.lblFullNameReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFullNameReq.Name = "lblFullNameReq";
            this.lblFullNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblFullNameReq.TabIndex = 5;
            this.lblFullNameReq.Text = "*";
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(6, 276);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(111, 12);
            this.lblAddress.TabIndex = 20;
            this.lblAddress.Text = "地址：";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPostalcode
            // 
            this.txtPostalcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPostalcode.Location = new System.Drawing.Point(126, 243);
            this.txtPostalcode.MaxLength = 20;
            this.txtPostalcode.Name = "txtPostalcode";
            this.txtPostalcode.Size = new System.Drawing.Size(339, 21);
            this.txtPostalcode.TabIndex = 19;
            // 
            // txtShortName
            // 
            this.txtShortName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShortName.Location = new System.Drawing.Point(126, 104);
            this.txtShortName.MaxLength = 80;
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(339, 21);
            this.txtShortName.TabIndex = 9;
            // 
            // lblPostalcode
            // 
            this.lblPostalcode.Location = new System.Drawing.Point(6, 248);
            this.lblPostalcode.Name = "lblPostalcode";
            this.lblPostalcode.Size = new System.Drawing.Size(111, 12);
            this.lblPostalcode.TabIndex = 18;
            this.lblPostalcode.Text = "邮编：";
            this.lblPostalcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblParentOrganize
            // 
            this.lblParentOrganize.Location = new System.Drawing.Point(6, 24);
            this.lblParentOrganize.Name = "lblParentOrganize";
            this.lblParentOrganize.Size = new System.Drawing.Size(111, 12);
            this.lblParentOrganize.TabIndex = 0;
            this.lblParentOrganize.Text = "父节点(&P)：";
            this.lblParentOrganize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFax
            // 
            this.txtFax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFax.Location = new System.Drawing.Point(126, 215);
            this.txtFax.MaxLength = 20;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(339, 21);
            this.txtFax.TabIndex = 17;
            // 
            // lblShortName
            // 
            this.lblShortName.Location = new System.Drawing.Point(6, 108);
            this.lblShortName.Name = "lblShortName";
            this.lblShortName.Size = new System.Drawing.Size(111, 12);
            this.lblShortName.TabIndex = 8;
            this.lblShortName.Text = "简称(&S)：";
            this.lblShortName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWeb
            // 
            this.txtWeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWeb.Location = new System.Drawing.Point(126, 299);
            this.txtWeb.MaxLength = 200;
            this.txtWeb.Name = "txtWeb";
            this.txtWeb.Size = new System.Drawing.Size(339, 21);
            this.txtWeb.TabIndex = 23;
            // 
            // lblWeb
            // 
            this.lblWeb.Location = new System.Drawing.Point(6, 304);
            this.lblWeb.Name = "lblWeb";
            this.lblWeb.Size = new System.Drawing.Size(111, 12);
            this.lblWeb.TabIndex = 22;
            this.lblWeb.Text = "网址：";
            this.lblWeb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkIsInnerOrganize
            // 
            this.chkIsInnerOrganize.AutoSize = true;
            this.chkIsInnerOrganize.Checked = true;
            this.chkIsInnerOrganize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsInnerOrganize.Location = new System.Drawing.Point(223, 327);
            this.chkIsInnerOrganize.Name = "chkIsInnerOrganize";
            this.chkIsInnerOrganize.Size = new System.Drawing.Size(72, 16);
            this.chkIsInnerOrganize.TabIndex = 25;
            this.chkIsInnerOrganize.Text = "内部组织";
            this.chkIsInnerOrganize.UseVisualStyleBackColor = true;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(126, 327);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(66, 16);
            this.chkEnabled.TabIndex = 24;
            this.chkEnabled.Text = "有效(&E)";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // lblFax
            // 
            this.lblFax.Location = new System.Drawing.Point(6, 220);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(111, 12);
            this.lblFax.TabIndex = 16;
            this.lblFax.Text = "传真(&F)：";
            this.lblFax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(6, 353);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(111, 12);
            this.lblDescription.TabIndex = 26;
            this.lblDescription.Text = "描述(&D)：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(126, 350);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(339, 37);
            this.txtDescription.TabIndex = 27;
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(126, 271);
            this.txtAddress.MaxLength = 20;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(339, 21);
            this.txtAddress.TabIndex = 21;
            // 
            // ucParent
            // 
            this.ucParent.AllowNull = true;
            this.ucParent.AllowSelect = true;
            this.ucParent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucParent.AutoSize = true;
            this.ucParent.CanEdit = false;
            this.ucParent.CheckMove = false;
            this.ucParent.Location = new System.Drawing.Point(126, 18);
            this.ucParent.MultiSelect = false;
            this.ucParent.Name = "ucParent";
            this.ucParent.OpenId = "";
            this.ucParent.PermissionItemScopeCode = "";
            this.ucParent.SelectedFullName = "";
            this.ucParent.SelectedId = "";
            this.ucParent.Size = new System.Drawing.Size(339, 23);
            this.ucParent.TabIndex = 1;
            // 
            // cmbCategory
            // 
            this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Location = new System.Drawing.Point(126, 132);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(339, 20);
            this.cmbCategory.TabIndex = 11;
            // 
            // lblInnerPhone
            // 
            this.lblInnerPhone.Location = new System.Drawing.Point(6, 192);
            this.lblInnerPhone.Name = "lblInnerPhone";
            this.lblInnerPhone.Size = new System.Drawing.Size(111, 12);
            this.lblInnerPhone.TabIndex = 14;
            this.lblInnerPhone.Text = "内线(&I)：";
            this.lblInnerPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCategory
            // 
            this.lblCategory.Location = new System.Drawing.Point(6, 136);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(111, 12);
            this.lblCategory.TabIndex = 10;
            this.lblCategory.Text = "分类(&G)：";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOuterPhone
            // 
            this.lblOuterPhone.Location = new System.Drawing.Point(6, 164);
            this.lblOuterPhone.Name = "lblOuterPhone";
            this.lblOuterPhone.Size = new System.Drawing.Size(111, 12);
            this.lblOuterPhone.TabIndex = 12;
            this.lblOuterPhone.Text = "电话(&O)：";
            this.lblOuterPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOuterPhone
            // 
            this.txtOuterPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOuterPhone.Location = new System.Drawing.Point(126, 159);
            this.txtOuterPhone.MaxLength = 20;
            this.txtOuterPhone.Name = "txtOuterPhone";
            this.txtOuterPhone.Size = new System.Drawing.Size(339, 21);
            this.txtOuterPhone.TabIndex = 13;
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.Location = new System.Drawing.Point(126, 48);
            this.txtFullName.MaxLength = 80;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(339, 21);
            this.txtFullName.TabIndex = 4;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(126, 76);
            this.txtCode.MaxLength = 20;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(339, 21);
            this.txtCode.TabIndex = 7;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(6, 52);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(111, 12);
            this.lblFullName.TabIndex = 3;
            this.lblFullName.Text = "名称(&N)：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInnerPhone
            // 
            this.txtInnerPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInnerPhone.Location = new System.Drawing.Point(126, 187);
            this.txtInnerPhone.MaxLength = 20;
            this.txtInnerPhone.Name = "txtInnerPhone";
            this.txtInnerPhone.Size = new System.Drawing.Size(339, 21);
            this.txtInnerPhone.TabIndex = 15;
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(6, 80);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(111, 12);
            this.lblCode.TabIndex = 6;
            this.lblCode.Text = "编号(&E)：";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmOrganizeAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(532, 457);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.grbOrganize);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOrganizeAdd";
            this.Text = "添加组织机构";
            this.grbOrganize.ResumeLayout(false);
            this.grbOrganize.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox grbOrganize;
        private System.Windows.Forms.Label lblParentReq;
        private System.Windows.Forms.Label lblFullNameReq;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtPostalcode;
        private System.Windows.Forms.TextBox txtShortName;
        private System.Windows.Forms.Label lblPostalcode;
        private System.Windows.Forms.Label lblParentOrganize;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label lblShortName;
        private System.Windows.Forms.TextBox txtWeb;
        private System.Windows.Forms.Label lblWeb;
        private System.Windows.Forms.CheckBox chkIsInnerOrganize;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtAddress;
        private UCOrganizeSelect ucParent;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblInnerPhone;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblOuterPhone;
        private System.Windows.Forms.TextBox txtOuterPhone;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtInnerPhone;
        private System.Windows.Forms.Label lblCode;
    }
}