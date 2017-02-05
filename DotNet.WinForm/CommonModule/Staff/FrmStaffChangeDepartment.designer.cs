namespace DotNet.WinForm
{
    partial class FrmStaffChangeDepartment
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
            this.btnConfirm = new System.Windows.Forms.Button();
            this.grbStaffChangDepartment = new System.Windows.Forms.GroupBox();
            this.ucDepartment = new DotNet.WinForm.UCOrganizeSelect();
            this.ucCompany = new DotNet.WinForm.UCOrganizeSelect();
            this.lblDepartmentReq = new System.Windows.Forms.Label();
            this.lblCompanyNameReq = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.ucPicture = new DotNet.WinForm.UCPicture();
            this.txtDuty = new System.Windows.Forms.TextBox();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblDuty = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.lblDep = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtRealName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.grbStaffChangDepartment.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(453, 317);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(374, 317);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 17;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // grbStaffChangDepartment
            // 
            this.grbStaffChangDepartment.Controls.Add(this.ucDepartment);
            this.grbStaffChangDepartment.Controls.Add(this.ucCompany);
            this.grbStaffChangDepartment.Controls.Add(this.lblDepartmentReq);
            this.grbStaffChangDepartment.Controls.Add(this.lblCompanyNameReq);
            this.grbStaffChangDepartment.Controls.Add(this.lblDepartment);
            this.grbStaffChangDepartment.Controls.Add(this.lblCompanyName);
            this.grbStaffChangDepartment.Controls.Add(this.ucPicture);
            this.grbStaffChangDepartment.Controls.Add(this.txtDuty);
            this.grbStaffChangDepartment.Controls.Add(this.txtCompany);
            this.grbStaffChangDepartment.Controls.Add(this.lblCompany);
            this.grbStaffChangDepartment.Controls.Add(this.lblDuty);
            this.grbStaffChangDepartment.Controls.Add(this.txtDepartment);
            this.grbStaffChangDepartment.Controls.Add(this.lblDep);
            this.grbStaffChangDepartment.Controls.Add(this.txtDescription);
            this.grbStaffChangDepartment.Controls.Add(this.lblDescription);
            this.grbStaffChangDepartment.Controls.Add(this.txtRealName);
            this.grbStaffChangDepartment.Controls.Add(this.lblFullName);
            this.grbStaffChangDepartment.Location = new System.Drawing.Point(13, 13);
            this.grbStaffChangDepartment.Name = "grbStaffChangDepartment";
            this.grbStaffChangDepartment.Size = new System.Drawing.Size(515, 298);
            this.grbStaffChangDepartment.TabIndex = 19;
            this.grbStaffChangDepartment.TabStop = false;
            this.grbStaffChangDepartment.Text = "员工移动部门：";
            // 
            // ucDepartment
            // 
            this.ucDepartment.AllowNull = true;
            this.ucDepartment.AllowSelect = true;
            this.ucDepartment.AutoSize = true;
            this.ucDepartment.CanEdit = false;
            this.ucDepartment.CheckMove = false;
            this.ucDepartment.Location = new System.Drawing.Point(109, 254);
            this.ucDepartment.MultiSelect = false;
            this.ucDepartment.Name = "ucDepartment";
            this.ucDepartment.OpenId = "";
            this.ucDepartment.PermissionItemScopeCode = "";
            this.ucDepartment.SelectedFullName = "";
            this.ucDepartment.SelectedId = "";
            this.ucDepartment.Size = new System.Drawing.Size(378, 23);
            this.ucDepartment.TabIndex = 32;
            // 
            // ucCompany
            // 
            this.ucCompany.AllowNull = true;
            this.ucCompany.AllowSelect = true;
            this.ucCompany.AutoSize = true;
            this.ucCompany.CanEdit = false;
            this.ucCompany.CheckMove = false;
            this.ucCompany.Location = new System.Drawing.Point(109, 225);
            this.ucCompany.MultiSelect = false;
            this.ucCompany.Name = "ucCompany";
            this.ucCompany.OpenId = "";
            this.ucCompany.PermissionItemScopeCode = "";
            this.ucCompany.SelectedFullName = "";
            this.ucCompany.SelectedId = "";
            this.ucCompany.Size = new System.Drawing.Size(378, 23);
            this.ucCompany.TabIndex = 29;
            // 
            // lblDepartmentReq
            // 
            this.lblDepartmentReq.AutoSize = true;
            this.lblDepartmentReq.ForeColor = System.Drawing.Color.Red;
            this.lblDepartmentReq.Location = new System.Drawing.Point(490, 260);
            this.lblDepartmentReq.Name = "lblDepartmentReq";
            this.lblDepartmentReq.Size = new System.Drawing.Size(11, 12);
            this.lblDepartmentReq.TabIndex = 33;
            this.lblDepartmentReq.Text = "*";
            // 
            // lblCompanyNameReq
            // 
            this.lblCompanyNameReq.AutoSize = true;
            this.lblCompanyNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblCompanyNameReq.Location = new System.Drawing.Point(490, 232);
            this.lblCompanyNameReq.Name = "lblCompanyNameReq";
            this.lblCompanyNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblCompanyNameReq.TabIndex = 30;
            this.lblCompanyNameReq.Text = "*";
            // 
            // lblDepartment
            // 
            this.lblDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDepartment.Location = new System.Drawing.Point(11, 257);
            this.lblDepartment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(89, 12);
            this.lblDepartment.TabIndex = 31;
            this.lblDepartment.Text = "部门(&A)：";
            this.lblDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCompanyName.Location = new System.Drawing.Point(11, 229);
            this.lblCompanyName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(89, 12);
            this.lblCompanyName.TabIndex = 28;
            this.lblCompanyName.Text = "公司(&C)：";
            this.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucPicture
            // 
            this.ucPicture.AllowDrop = true;
            this.ucPicture.FolderId = "";
            this.ucPicture.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucPicture.Location = new System.Drawing.Point(305, 21);
            this.ucPicture.Name = "ucPicture";
            this.ucPicture.PictureId = "";
            this.ucPicture.Size = new System.Drawing.Size(187, 195);
            this.ucPicture.TabIndex = 27;
            // 
            // txtDuty
            // 
            this.txtDuty.Location = new System.Drawing.Point(109, 109);
            this.txtDuty.Name = "txtDuty";
            this.txtDuty.ReadOnly = true;
            this.txtDuty.Size = new System.Drawing.Size(189, 21);
            this.txtDuty.TabIndex = 24;
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(109, 54);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.ReadOnly = true;
            this.txtCompany.Size = new System.Drawing.Size(189, 21);
            this.txtCompany.TabIndex = 20;
            // 
            // lblCompany
            // 
            this.lblCompany.Location = new System.Drawing.Point(12, 57);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(88, 12);
            this.lblCompany.TabIndex = 19;
            this.lblCompany.Text = "公司：";
            this.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDuty
            // 
            this.lblDuty.Location = new System.Drawing.Point(12, 112);
            this.lblDuty.Name = "lblDuty";
            this.lblDuty.Size = new System.Drawing.Size(88, 12);
            this.lblDuty.TabIndex = 23;
            this.lblDuty.Text = "职位：";
            this.lblDuty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(109, 82);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(189, 21);
            this.txtDepartment.TabIndex = 22;
            // 
            // lblDep
            // 
            this.lblDep.Location = new System.Drawing.Point(12, 85);
            this.lblDep.Name = "lblDep";
            this.lblDep.Size = new System.Drawing.Size(88, 12);
            this.lblDep.TabIndex = 21;
            this.lblDep.Text = "部门：";
            this.lblDep.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(109, 136);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(190, 80);
            this.txtDescription.TabIndex = 26;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(12, 139);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(88, 12);
            this.lblDescription.TabIndex = 25;
            this.lblDescription.Text = "描述：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRealName
            // 
            this.txtRealName.CausesValidation = false;
            this.txtRealName.Location = new System.Drawing.Point(109, 26);
            this.txtRealName.MaxLength = 100;
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.ReadOnly = true;
            this.txtRealName.Size = new System.Drawing.Size(189, 21);
            this.txtRealName.TabIndex = 18;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(12, 29);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(88, 12);
            this.lblFullName.TabIndex = 17;
            this.lblFullName.Text = "姓名：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmStaffChangeDepartment
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(540, 352);
            this.Controls.Add(this.grbStaffChangDepartment);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmStaffChangeDepartment";
            this.Text = "员工移动部门";
            this.grbStaffChangDepartment.ResumeLayout(false);
            this.grbStaffChangDepartment.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.GroupBox grbStaffChangDepartment;
        private UCOrganizeSelect ucDepartment;
        private UCOrganizeSelect ucCompany;
        private System.Windows.Forms.Label lblDepartmentReq;
        private System.Windows.Forms.Label lblCompanyNameReq;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblCompanyName;
        private UCPicture ucPicture;
        private System.Windows.Forms.TextBox txtDuty;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblDuty;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Label lblDep;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtRealName;
        private System.Windows.Forms.Label lblFullName;
    }
}