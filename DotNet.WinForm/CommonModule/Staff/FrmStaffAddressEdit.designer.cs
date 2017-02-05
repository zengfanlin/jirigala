namespace DotNet.WinForm
{
    partial class FrmStaffAddressEdit
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grbStaffAddress = new System.Windows.Forms.GroupBox();
            this.txtSignature = new System.Windows.Forms.TextBox();
            this.lblSignature = new System.Windows.Forms.Label();
            this.ucPicture = new DotNet.WinForm.UCPicture();
            this.txtShortNumber = new System.Windows.Forms.TextBox();
            this.lblShortNumber = new System.Windows.Forms.Label();
            this.txtDuty = new System.Windows.Forms.TextBox();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblDuty = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.lblDep = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtOICQ = new System.Windows.Forms.TextBox();
            this.lblOICQ = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.txtOfficeTel = new System.Windows.Forms.TextBox();
            this.lblTEl = new System.Windows.Forms.Label();
            this.txtRealName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.grbStaffAddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(488, 430);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(409, 430);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grbStaffAddress
            // 
            this.grbStaffAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbStaffAddress.Controls.Add(this.txtSignature);
            this.grbStaffAddress.Controls.Add(this.lblSignature);
            this.grbStaffAddress.Controls.Add(this.ucPicture);
            this.grbStaffAddress.Controls.Add(this.txtShortNumber);
            this.grbStaffAddress.Controls.Add(this.lblShortNumber);
            this.grbStaffAddress.Controls.Add(this.txtDuty);
            this.grbStaffAddress.Controls.Add(this.txtCompany);
            this.grbStaffAddress.Controls.Add(this.lblCompany);
            this.grbStaffAddress.Controls.Add(this.lblDuty);
            this.grbStaffAddress.Controls.Add(this.txtDepartment);
            this.grbStaffAddress.Controls.Add(this.lblDep);
            this.grbStaffAddress.Controls.Add(this.txtDescription);
            this.grbStaffAddress.Controls.Add(this.lblDescription);
            this.grbStaffAddress.Controls.Add(this.txtOICQ);
            this.grbStaffAddress.Controls.Add(this.lblOICQ);
            this.grbStaffAddress.Controls.Add(this.txtMobile);
            this.grbStaffAddress.Controls.Add(this.lblMobile);
            this.grbStaffAddress.Controls.Add(this.txtEmail);
            this.grbStaffAddress.Controls.Add(this.lblMail);
            this.grbStaffAddress.Controls.Add(this.txtOfficeTel);
            this.grbStaffAddress.Controls.Add(this.lblTEl);
            this.grbStaffAddress.Controls.Add(this.txtRealName);
            this.grbStaffAddress.Controls.Add(this.lblFullName);
            this.grbStaffAddress.Location = new System.Drawing.Point(13, 13);
            this.grbStaffAddress.Name = "grbStaffAddress";
            this.grbStaffAddress.Size = new System.Drawing.Size(550, 411);
            this.grbStaffAddress.TabIndex = 23;
            this.grbStaffAddress.TabStop = false;
            this.grbStaffAddress.Text = "通讯录";
            // 
            // txtSignature
            // 
            this.txtSignature.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSignature.Location = new System.Drawing.Point(125, 276);
            this.txtSignature.MaxLength = 200;
            this.txtSignature.Multiline = true;
            this.txtSignature.Name = "txtSignature";
            this.txtSignature.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSignature.Size = new System.Drawing.Size(408, 56);
            this.txtSignature.TabIndex = 43;
            // 
            // lblSignature
            // 
            this.lblSignature.Location = new System.Drawing.Point(17, 279);
            this.lblSignature.Name = "lblSignature";
            this.lblSignature.Size = new System.Drawing.Size(99, 12);
            this.lblSignature.TabIndex = 42;
            this.lblSignature.Text = "个性签名：";
            this.lblSignature.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucPicture
            // 
            this.ucPicture.AllowDrop = true;
            this.ucPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPicture.FolderId = "";
            this.ucPicture.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucPicture.Location = new System.Drawing.Point(352, 19);
            this.ucPicture.Name = "ucPicture";
            this.ucPicture.PictureId = "";
            this.ucPicture.Size = new System.Drawing.Size(187, 195);
            this.ucPicture.TabIndex = 41;
            // 
            // txtShortNumber
            // 
            this.txtShortNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShortNumber.Location = new System.Drawing.Point(125, 191);
            this.txtShortNumber.MaxLength = 20;
            this.txtShortNumber.Name = "txtShortNumber";
            this.txtShortNumber.Size = new System.Drawing.Size(219, 21);
            this.txtShortNumber.TabIndex = 34;
            // 
            // lblShortNumber
            // 
            this.lblShortNumber.Location = new System.Drawing.Point(17, 194);
            this.lblShortNumber.Name = "lblShortNumber";
            this.lblShortNumber.Size = new System.Drawing.Size(99, 12);
            this.lblShortNumber.TabIndex = 33;
            this.lblShortNumber.Text = "短号：";
            this.lblShortNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDuty
            // 
            this.txtDuty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDuty.Location = new System.Drawing.Point(125, 107);
            this.txtDuty.Name = "txtDuty";
            this.txtDuty.ReadOnly = true;
            this.txtDuty.Size = new System.Drawing.Size(219, 21);
            this.txtDuty.TabIndex = 28;
            // 
            // txtCompany
            // 
            this.txtCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompany.Location = new System.Drawing.Point(125, 52);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.ReadOnly = true;
            this.txtCompany.Size = new System.Drawing.Size(219, 21);
            this.txtCompany.TabIndex = 24;
            // 
            // lblCompany
            // 
            this.lblCompany.Location = new System.Drawing.Point(17, 55);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(99, 12);
            this.lblCompany.TabIndex = 23;
            this.lblCompany.Text = "公司：";
            this.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDuty
            // 
            this.lblDuty.Location = new System.Drawing.Point(17, 110);
            this.lblDuty.Name = "lblDuty";
            this.lblDuty.Size = new System.Drawing.Size(99, 12);
            this.lblDuty.TabIndex = 27;
            this.lblDuty.Text = "职务：";
            this.lblDuty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDepartment
            // 
            this.txtDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDepartment.Location = new System.Drawing.Point(125, 80);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(219, 21);
            this.txtDepartment.TabIndex = 26;
            // 
            // lblDep
            // 
            this.lblDep.Location = new System.Drawing.Point(17, 83);
            this.lblDep.Name = "lblDep";
            this.lblDep.Size = new System.Drawing.Size(99, 12);
            this.lblDep.TabIndex = 25;
            this.lblDep.Text = "部门：";
            this.lblDep.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(125, 338);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(408, 58);
            this.txtDescription.TabIndex = 40;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(20, 341);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(99, 12);
            this.lblDescription.TabIndex = 39;
            this.lblDescription.Text = "描述：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOICQ
            // 
            this.txtOICQ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOICQ.Location = new System.Drawing.Point(125, 248);
            this.txtOICQ.MaxLength = 20;
            this.txtOICQ.Name = "txtOICQ";
            this.txtOICQ.Size = new System.Drawing.Size(408, 21);
            this.txtOICQ.TabIndex = 38;
            // 
            // lblOICQ
            // 
            this.lblOICQ.Location = new System.Drawing.Point(17, 251);
            this.lblOICQ.Name = "lblOICQ";
            this.lblOICQ.Size = new System.Drawing.Size(99, 12);
            this.lblOICQ.TabIndex = 37;
            this.lblOICQ.Text = "QQ：";
            this.lblOICQ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMobile
            // 
            this.txtMobile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMobile.Location = new System.Drawing.Point(125, 164);
            this.txtMobile.MaxLength = 20;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(219, 21);
            this.txtMobile.TabIndex = 32;
            // 
            // lblMobile
            // 
            this.lblMobile.Location = new System.Drawing.Point(17, 167);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(99, 12);
            this.lblMobile.TabIndex = 31;
            this.lblMobile.Text = "手机：";
            this.lblMobile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(125, 220);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(408, 21);
            this.txtEmail.TabIndex = 36;
            // 
            // lblMail
            // 
            this.lblMail.Location = new System.Drawing.Point(17, 223);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(99, 12);
            this.lblMail.TabIndex = 35;
            this.lblMail.Text = "电子邮箱：";
            this.lblMail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOfficeTel
            // 
            this.txtOfficeTel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOfficeTel.Location = new System.Drawing.Point(125, 136);
            this.txtOfficeTel.MaxLength = 20;
            this.txtOfficeTel.Name = "txtOfficeTel";
            this.txtOfficeTel.Size = new System.Drawing.Size(219, 21);
            this.txtOfficeTel.TabIndex = 30;
            // 
            // lblTEl
            // 
            this.lblTEl.Location = new System.Drawing.Point(17, 139);
            this.lblTEl.Name = "lblTEl";
            this.lblTEl.Size = new System.Drawing.Size(99, 12);
            this.lblTEl.TabIndex = 29;
            this.lblTEl.Text = "办公电话：";
            this.lblTEl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRealName
            // 
            this.txtRealName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRealName.CausesValidation = false;
            this.txtRealName.Location = new System.Drawing.Point(125, 24);
            this.txtRealName.MaxLength = 100;
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.ReadOnly = true;
            this.txtRealName.Size = new System.Drawing.Size(219, 21);
            this.txtRealName.TabIndex = 22;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(17, 27);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(99, 12);
            this.lblFullName.TabIndex = 21;
            this.lblFullName.Text = "姓名：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmStaffAddressEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(575, 465);
            this.Controls.Add(this.grbStaffAddress);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmStaffAddressEdit";
            this.Text = "编辑通讯录";
            this.grbStaffAddress.ResumeLayout(false);
            this.grbStaffAddress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grbStaffAddress;
        private UCPicture ucPicture;
        private System.Windows.Forms.TextBox txtShortNumber;
        private System.Windows.Forms.Label lblShortNumber;
        private System.Windows.Forms.TextBox txtDuty;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblDuty;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Label lblDep;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtOICQ;
        private System.Windows.Forms.Label lblOICQ;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.TextBox txtOfficeTel;
        private System.Windows.Forms.Label lblTEl;
        private System.Windows.Forms.TextBox txtRealName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtSignature;
        private System.Windows.Forms.Label lblSignature;

    }
}