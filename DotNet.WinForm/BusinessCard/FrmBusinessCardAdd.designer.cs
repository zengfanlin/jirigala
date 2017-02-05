namespace DotNet.WinForm
{
    partial class FrmBusinessCardAdd
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
            this.grpBusinessCard = new System.Windows.Forms.GroupBox();
            this.chkPersonal = new System.Windows.Forms.CheckBox();
            this.ucCompany = new DotNet.WinForm.UCOrganizeSelect();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtBankAccount = new System.Windows.Forms.TextBox();
            this.lblBankAccount = new System.Windows.Forms.Label();
            this.txtTaxAccount = new System.Windows.Forms.TextBox();
            this.lblTaxAccount = new System.Windows.Forms.Label();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.lblBank = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtWeb = new System.Windows.Forms.TextBox();
            this.lblWeb = new System.Windows.Forms.Label();
            this.txtPostalcode = new System.Windows.Forms.TextBox();
            this.lblPostalcode = new System.Windows.Forms.Label();
            this.txtOfficePhone = new System.Windows.Forms.TextBox();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.lblOuterPhone = new System.Windows.Forms.Label();
            this.lblFax = new System.Windows.Forms.Label();
            this.txtQQ = new System.Windows.Forms.TextBox();
            this.lblQQ = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblFullNameReq = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grpBusinessCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBusinessCard
            // 
            this.grpBusinessCard.Controls.Add(this.chkPersonal);
            this.grpBusinessCard.Controls.Add(this.ucCompany);
            this.grpBusinessCard.Controls.Add(this.txtTitle);
            this.grpBusinessCard.Controls.Add(this.lblTitle);
            this.grpBusinessCard.Controls.Add(this.txtBankAccount);
            this.grpBusinessCard.Controls.Add(this.lblBankAccount);
            this.grpBusinessCard.Controls.Add(this.txtTaxAccount);
            this.grpBusinessCard.Controls.Add(this.lblTaxAccount);
            this.grpBusinessCard.Controls.Add(this.txtBankName);
            this.grpBusinessCard.Controls.Add(this.lblBank);
            this.grpBusinessCard.Controls.Add(this.txtAddress);
            this.grpBusinessCard.Controls.Add(this.lblAddress);
            this.grpBusinessCard.Controls.Add(this.txtWeb);
            this.grpBusinessCard.Controls.Add(this.lblWeb);
            this.grpBusinessCard.Controls.Add(this.txtPostalcode);
            this.grpBusinessCard.Controls.Add(this.lblPostalcode);
            this.grpBusinessCard.Controls.Add(this.txtOfficePhone);
            this.grpBusinessCard.Controls.Add(this.txtFax);
            this.grpBusinessCard.Controls.Add(this.lblOuterPhone);
            this.grpBusinessCard.Controls.Add(this.lblFax);
            this.grpBusinessCard.Controls.Add(this.txtQQ);
            this.grpBusinessCard.Controls.Add(this.lblQQ);
            this.grpBusinessCard.Controls.Add(this.txtMobile);
            this.grpBusinessCard.Controls.Add(this.lblMobile);
            this.grpBusinessCard.Controls.Add(this.txtEmail);
            this.grpBusinessCard.Controls.Add(this.lblMail);
            this.grpBusinessCard.Controls.Add(this.txtPhone);
            this.grpBusinessCard.Controls.Add(this.lblPhone);
            this.grpBusinessCard.Controls.Add(this.lblCompany);
            this.grpBusinessCard.Controls.Add(this.txtDescription);
            this.grpBusinessCard.Controls.Add(this.lblDescription);
            this.grpBusinessCard.Controls.Add(this.lblFullNameReq);
            this.grpBusinessCard.Controls.Add(this.txtFullName);
            this.grpBusinessCard.Controls.Add(this.lblFullName);
            this.grpBusinessCard.Location = new System.Drawing.Point(12, 65);
            this.grpBusinessCard.Name = "grpBusinessCard";
            this.grpBusinessCard.Size = new System.Drawing.Size(724, 354);
            this.grpBusinessCard.TabIndex = 0;
            this.grpBusinessCard.TabStop = false;
            this.grpBusinessCard.Text = "添加名片";
            // 
            // chkPersonal
            // 
            this.chkPersonal.AutoSize = true;
            this.chkPersonal.Location = new System.Drawing.Point(119, 325);
            this.chkPersonal.Name = "chkPersonal";
            this.chkPersonal.Size = new System.Drawing.Size(72, 16);
            this.chkPersonal.TabIndex = 70;
            this.chkPersonal.Text = "私人名片";
            this.chkPersonal.UseVisualStyleBackColor = true;
            // 
            // ucCompany
            // 
            this.ucCompany.AllowNull = true;
            this.ucCompany.AllowSelect = true;
            this.ucCompany.AutoSize = true;
            this.ucCompany.CanEdit = true;
            this.ucCompany.CheckMove = false;
            this.ucCompany.Location = new System.Drawing.Point(119, 86);
            this.ucCompany.MultiSelect = false;
            this.ucCompany.Name = "ucCompany";
            this.ucCompany.OpenId = "";
            this.ucCompany.PermissionItemScopeCode = "";
            this.ucCompany.SelectedFullName = "";
            this.ucCompany.SelectedId = "";
            this.ucCompany.Size = new System.Drawing.Size(592, 23);
            this.ucCompany.TabIndex = 47;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(459, 20);
            this.txtTitle.MaxLength = 40;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(252, 21);
            this.txtTitle.TabIndex = 41;
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(377, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(85, 12);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "职位：";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBankAccount
            // 
            this.txtBankAccount.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtBankAccount.Location = new System.Drawing.Point(119, 261);
            this.txtBankAccount.MaxLength = 40;
            this.txtBankAccount.Name = "txtBankAccount";
            this.txtBankAccount.Size = new System.Drawing.Size(252, 21);
            this.txtBankAccount.TabIndex = 65;
            // 
            // lblBankAccount
            // 
            this.lblBankAccount.Location = new System.Drawing.Point(16, 264);
            this.lblBankAccount.Name = "lblBankAccount";
            this.lblBankAccount.Size = new System.Drawing.Size(100, 12);
            this.lblBankAccount.TabIndex = 64;
            this.lblBankAccount.Text = "帐号：";
            this.lblBankAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTaxAccount
            // 
            this.txtTaxAccount.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtTaxAccount.Location = new System.Drawing.Point(119, 288);
            this.txtTaxAccount.MaxLength = 40;
            this.txtTaxAccount.Name = "txtTaxAccount";
            this.txtTaxAccount.Size = new System.Drawing.Size(252, 21);
            this.txtTaxAccount.TabIndex = 67;
            // 
            // lblTaxAccount
            // 
            this.lblTaxAccount.Location = new System.Drawing.Point(16, 291);
            this.lblTaxAccount.Name = "lblTaxAccount";
            this.lblTaxAccount.Size = new System.Drawing.Size(99, 12);
            this.lblTaxAccount.TabIndex = 66;
            this.lblTaxAccount.Text = "税号：";
            this.lblTaxAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBankName
            // 
            this.txtBankName.Location = new System.Drawing.Point(119, 234);
            this.txtBankName.MaxLength = 40;
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(252, 21);
            this.txtBankName.TabIndex = 63;
            // 
            // lblBank
            // 
            this.lblBank.Location = new System.Drawing.Point(24, 237);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(93, 12);
            this.lblBank.TabIndex = 62;
            this.lblBank.Text = "开户行：";
            this.lblBank.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(119, 114);
            this.txtAddress.MaxLength = 200;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(376, 21);
            this.txtAddress.TabIndex = 49;
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(26, 118);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(91, 12);
            this.lblAddress.TabIndex = 48;
            this.lblAddress.Text = "地址：";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWeb
            // 
            this.txtWeb.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtWeb.Location = new System.Drawing.Point(459, 166);
            this.txtWeb.MaxLength = 40;
            this.txtWeb.Name = "txtWeb";
            this.txtWeb.Size = new System.Drawing.Size(252, 21);
            this.txtWeb.TabIndex = 59;
            // 
            // lblWeb
            // 
            this.lblWeb.Location = new System.Drawing.Point(377, 169);
            this.lblWeb.Name = "lblWeb";
            this.lblWeb.Size = new System.Drawing.Size(85, 12);
            this.lblWeb.TabIndex = 58;
            this.lblWeb.Text = "网址：";
            this.lblWeb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPostalcode
            // 
            this.txtPostalcode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtPostalcode.Location = new System.Drawing.Point(583, 113);
            this.txtPostalcode.MaxLength = 40;
            this.txtPostalcode.Name = "txtPostalcode";
            this.txtPostalcode.Size = new System.Drawing.Size(127, 21);
            this.txtPostalcode.TabIndex = 51;
            // 
            // lblPostalcode
            // 
            this.lblPostalcode.Location = new System.Drawing.Point(501, 118);
            this.lblPostalcode.Name = "lblPostalcode";
            this.lblPostalcode.Size = new System.Drawing.Size(84, 12);
            this.lblPostalcode.TabIndex = 50;
            this.lblPostalcode.Text = "邮编：";
            this.lblPostalcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOfficePhone
            // 
            this.txtOfficePhone.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtOfficePhone.Location = new System.Drawing.Point(119, 140);
            this.txtOfficePhone.MaxLength = 40;
            this.txtOfficePhone.Name = "txtOfficePhone";
            this.txtOfficePhone.Size = new System.Drawing.Size(252, 21);
            this.txtOfficePhone.TabIndex = 53;
            // 
            // txtFax
            // 
            this.txtFax.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtFax.Location = new System.Drawing.Point(459, 141);
            this.txtFax.MaxLength = 40;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(252, 21);
            this.txtFax.TabIndex = 55;
            // 
            // lblOuterPhone
            // 
            this.lblOuterPhone.Location = new System.Drawing.Point(18, 145);
            this.lblOuterPhone.Name = "lblOuterPhone";
            this.lblOuterPhone.Size = new System.Drawing.Size(99, 12);
            this.lblOuterPhone.TabIndex = 52;
            this.lblOuterPhone.Text = "办公电话：";
            this.lblOuterPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFax
            // 
            this.lblFax.Location = new System.Drawing.Point(375, 144);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(87, 12);
            this.lblFax.TabIndex = 54;
            this.lblFax.Text = "传真(&F)：";
            this.lblFax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQQ
            // 
            this.txtQQ.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtQQ.Location = new System.Drawing.Point(459, 46);
            this.txtQQ.MaxLength = 40;
            this.txtQQ.Name = "txtQQ";
            this.txtQQ.Size = new System.Drawing.Size(252, 21);
            this.txtQQ.TabIndex = 45;
            // 
            // lblQQ
            // 
            this.lblQQ.Location = new System.Drawing.Point(390, 51);
            this.lblQQ.Name = "lblQQ";
            this.lblQQ.Size = new System.Drawing.Size(72, 12);
            this.lblQQ.TabIndex = 44;
            this.lblQQ.Text = "QQ：";
            this.lblQQ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMobile
            // 
            this.txtMobile.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtMobile.Location = new System.Drawing.Point(119, 166);
            this.txtMobile.MaxLength = 40;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(252, 21);
            this.txtMobile.TabIndex = 57;
            // 
            // lblMobile
            // 
            this.lblMobile.Location = new System.Drawing.Point(26, 171);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(91, 12);
            this.lblMobile.TabIndex = 56;
            this.lblMobile.Text = "手机：";
            this.lblMobile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmail
            // 
            this.txtEmail.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtEmail.Location = new System.Drawing.Point(119, 192);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(592, 21);
            this.txtEmail.TabIndex = 61;
            // 
            // lblMail
            // 
            this.lblMail.Location = new System.Drawing.Point(26, 195);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(91, 12);
            this.lblMail.TabIndex = 60;
            this.lblMail.Text = "邮箱：";
            this.lblMail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPhone
            // 
            this.txtPhone.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtPhone.Location = new System.Drawing.Point(119, 45);
            this.txtPhone.MaxLength = 40;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(252, 21);
            this.txtPhone.TabIndex = 43;
            // 
            // lblPhone
            // 
            this.lblPhone.Location = new System.Drawing.Point(12, 45);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(103, 12);
            this.lblPhone.TabIndex = 42;
            this.lblPhone.Text = "私人电话：";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCompany
            // 
            this.lblCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCompany.Location = new System.Drawing.Point(23, 86);
            this.lblCompany.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(93, 12);
            this.lblCompany.TabIndex = 46;
            this.lblCompany.Text = "公司(&C)：";
            this.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(459, 234);
            this.txtDescription.MaxLength = 800;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(252, 77);
            this.txtDescription.TabIndex = 69;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(375, 238);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(87, 12);
            this.lblDescription.TabIndex = 68;
            this.lblDescription.Text = "描述(&D)：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFullNameReq
            // 
            this.lblFullNameReq.AutoSize = true;
            this.lblFullNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblFullNameReq.Location = new System.Drawing.Point(373, 24);
            this.lblFullNameReq.Name = "lblFullNameReq";
            this.lblFullNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblFullNameReq.TabIndex = 39;
            this.lblFullNameReq.Text = "*";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(119, 20);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtFullName.MaxLength = 40;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(252, 21);
            this.txtFullName.TabIndex = 38;
            // 
            // lblFullName
            // 
            this.lblFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullName.Location = new System.Drawing.Point(22, 23);
            this.lblFullName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(93, 12);
            this.lblFullName.TabIndex = 37;
            this.lblFullName.Text = "名称(&N)：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(582, 425);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 75;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(661, 425);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 76;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(503, 425);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 74;
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FrmBusinessCardAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DotNet.WinForm.Properties.Resources.Head;
            this.ClientSize = new System.Drawing.Size(748, 456);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.grpBusinessCard);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBusinessCardAdd";
            this.Text = "添加名片";
            this.grpBusinessCard.ResumeLayout(false);
            this.grpBusinessCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBusinessCard;
        private System.Windows.Forms.CheckBox chkPersonal;
        private UCOrganizeSelect ucCompany;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtBankAccount;
        private System.Windows.Forms.Label lblBankAccount;
        private System.Windows.Forms.TextBox txtTaxAccount;
        private System.Windows.Forms.Label lblTaxAccount;
        private System.Windows.Forms.TextBox txtBankName;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtWeb;
        private System.Windows.Forms.Label lblWeb;
        private System.Windows.Forms.TextBox txtPostalcode;
        private System.Windows.Forms.Label lblPostalcode;
        private System.Windows.Forms.TextBox txtOfficePhone;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label lblOuterPhone;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.TextBox txtQQ;
        private System.Windows.Forms.Label lblQQ;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblFullNameReq;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;

    }
}