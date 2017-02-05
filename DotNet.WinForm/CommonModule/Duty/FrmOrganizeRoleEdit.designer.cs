namespace DotNet.WinForm
{
    partial class FrmOrganizeRoleEdit
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
            this.btnLikeAdd = new System.Windows.Forms.Button();
            this.grbOrganizeRole = new System.Windows.Forms.GroupBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.ucOrganize = new DotNet.WinForm.UCOrganizeSelect();
            this.lblFullNameReq = new System.Windows.Forms.Label();
            this.lblOrganizeReq = new System.Windows.Forms.Label();
            this.lblOrganize = new System.Windows.Forms.Label();
            this.txtRealName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.grbOrganizeRole.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(332, 270);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(251, 270);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLikeAdd
            // 
            this.btnLikeAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLikeAdd.Location = new System.Drawing.Point(12, 270);
            this.btnLikeAdd.Name = "btnLikeAdd";
            this.btnLikeAdd.Size = new System.Drawing.Size(113, 23);
            this.btnLikeAdd.TabIndex = 11;
            this.btnLikeAdd.Text = "类似添加(&A)";
            this.btnLikeAdd.UseVisualStyleBackColor = true;
            this.btnLikeAdd.Click += new System.EventHandler(this.btnLikeAdd_Click);
            // 
            // grbOrganizeRole
            // 
            this.grbOrganizeRole.Controls.Add(this.txtCode);
            this.grbOrganizeRole.Controls.Add(this.lblCode);
            this.grbOrganizeRole.Controls.Add(this.ucOrganize);
            this.grbOrganizeRole.Controls.Add(this.lblFullNameReq);
            this.grbOrganizeRole.Controls.Add(this.lblOrganizeReq);
            this.grbOrganizeRole.Controls.Add(this.lblOrganize);
            this.grbOrganizeRole.Controls.Add(this.txtRealName);
            this.grbOrganizeRole.Controls.Add(this.lblFullName);
            this.grbOrganizeRole.Controls.Add(this.chkEnabled);
            this.grbOrganizeRole.Controls.Add(this.txtDescription);
            this.grbOrganizeRole.Controls.Add(this.lblDescription);
            this.grbOrganizeRole.Location = new System.Drawing.Point(13, 13);
            this.grbOrganizeRole.Name = "grbOrganizeRole";
            this.grbOrganizeRole.Size = new System.Drawing.Size(394, 244);
            this.grbOrganizeRole.TabIndex = 14;
            this.grbOrganizeRole.TabStop = false;
            this.grbOrganizeRole.Text = "编辑岗位：";
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(95, 67);
            this.txtCode.MaxLength = 50;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(270, 21);
            this.txtCode.TabIndex = 15;
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(13, 70);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(75, 12);
            this.lblCode.TabIndex = 14;
            this.lblCode.Text = "编号(&C)：";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucOrganize
            // 
            this.ucOrganize.AllowNull = true;
            this.ucOrganize.AllowSelect = true;
            this.ucOrganize.AutoSize = true;
            this.ucOrganize.CanEdit = false;
            this.ucOrganize.CheckMove = false;
            this.ucOrganize.Location = new System.Drawing.Point(95, 27);
            this.ucOrganize.MultiSelect = false;
            this.ucOrganize.Name = "ucOrganize";
            this.ucOrganize.OpenId = "";
            this.ucOrganize.PermissionItemScopeCode = "";
            this.ucOrganize.SelectedFullName = "";
            this.ucOrganize.SelectedId = "";
            this.ucOrganize.Size = new System.Drawing.Size(270, 23);
            this.ucOrganize.TabIndex = 12;
            // 
            // lblFullNameReq
            // 
            this.lblFullNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullNameReq.AutoSize = true;
            this.lblFullNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblFullNameReq.Location = new System.Drawing.Point(371, 106);
            this.lblFullNameReq.Name = "lblFullNameReq";
            this.lblFullNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblFullNameReq.TabIndex = 18;
            this.lblFullNameReq.Text = "*";
            // 
            // lblOrganizeReq
            // 
            this.lblOrganizeReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrganizeReq.AutoSize = true;
            this.lblOrganizeReq.ForeColor = System.Drawing.Color.Red;
            this.lblOrganizeReq.Location = new System.Drawing.Point(371, 31);
            this.lblOrganizeReq.Name = "lblOrganizeReq";
            this.lblOrganizeReq.Size = new System.Drawing.Size(11, 12);
            this.lblOrganizeReq.TabIndex = 13;
            this.lblOrganizeReq.Text = "*";
            // 
            // lblOrganize
            // 
            this.lblOrganize.Location = new System.Drawing.Point(13, 30);
            this.lblOrganize.Name = "lblOrganize";
            this.lblOrganize.Size = new System.Drawing.Size(75, 12);
            this.lblOrganize.TabIndex = 11;
            this.lblOrganize.Text = "机构(&O)：";
            this.lblOrganize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRealName
            // 
            this.txtRealName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRealName.Location = new System.Drawing.Point(95, 103);
            this.txtRealName.MaxLength = 50;
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.Size = new System.Drawing.Size(270, 21);
            this.txtRealName.TabIndex = 17;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(13, 105);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(75, 12);
            this.lblFullName.TabIndex = 16;
            this.lblFullName.Text = "名称(&F)：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(95, 141);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(48, 16);
            this.chkEnabled.TabIndex = 19;
            this.chkEnabled.Text = "有效";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(95, 168);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(270, 58);
            this.txtDescription.TabIndex = 21;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(13, 171);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(75, 12);
            this.lblDescription.TabIndex = 20;
            this.lblDescription.Text = "描述(&D)：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmOrganizeRoleEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(419, 308);
            this.Controls.Add(this.grbOrganizeRole);
            this.Controls.Add(this.btnLikeAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOrganizeRoleEdit";
            this.Text = "编辑岗位";
            this.grbOrganizeRole.ResumeLayout(false);
            this.grbOrganizeRole.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLikeAdd;
        private System.Windows.Forms.GroupBox grbOrganizeRole;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblCode;
        private UCOrganizeSelect ucOrganize;
        private System.Windows.Forms.Label lblFullNameReq;
        private System.Windows.Forms.Label lblOrganizeReq;
        private System.Windows.Forms.Label lblOrganize;
        private System.Windows.Forms.TextBox txtRealName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
    }
}