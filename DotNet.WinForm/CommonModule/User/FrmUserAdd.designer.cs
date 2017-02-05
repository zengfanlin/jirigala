namespace DotNet.WinForm
{
    partial class FrmUserAdd
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
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkClose = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grbOperatorAdd = new System.Windows.Forms.GroupBox();
            this.cmbSecurityLevel = new System.Windows.Forms.ComboBox();
            this.lblSecurityLevel = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.cmbDefaultRole = new System.Windows.Forms.ComboBox();
            this.lblFullNameReq = new System.Windows.Forms.Label();
            this.lblConfirmPasswordReq = new System.Windows.Forms.Label();
            this.lblPasswordReq = new System.Windows.Forms.Label();
            this.lblUserNameReq = new System.Windows.Forms.Label();
            this.txtRealName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblDefaultRole = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblRealName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.grbOperatorAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // helpProvider
            // 
            this.helpProvider.HelpNamespace = "";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(361, 292);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkClose
            // 
            this.chkClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkClose.AutoSize = true;
            this.chkClose.Checked = true;
            this.chkClose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClose.Location = new System.Drawing.Point(11, 296);
            this.chkClose.Name = "chkClose";
            this.chkClose.Size = new System.Drawing.Size(132, 16);
            this.chkClose.TabIndex = 5;
            this.chkClose.Text = "注册成功后关闭窗体";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnAdd.Location = new System.Drawing.Point(280, 292);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(74, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grbOperatorAdd
            // 
            this.grbOperatorAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbOperatorAdd.Controls.Add(this.cmbSecurityLevel);
            this.grbOperatorAdd.Controls.Add(this.lblSecurityLevel);
            this.grbOperatorAdd.Controls.Add(this.chkEnabled);
            this.grbOperatorAdd.Controls.Add(this.cmbDefaultRole);
            this.grbOperatorAdd.Controls.Add(this.lblFullNameReq);
            this.grbOperatorAdd.Controls.Add(this.lblConfirmPasswordReq);
            this.grbOperatorAdd.Controls.Add(this.lblPasswordReq);
            this.grbOperatorAdd.Controls.Add(this.lblUserNameReq);
            this.grbOperatorAdd.Controls.Add(this.txtRealName);
            this.grbOperatorAdd.Controls.Add(this.txtUserName);
            this.grbOperatorAdd.Controls.Add(this.lblCode);
            this.grbOperatorAdd.Controls.Add(this.lblDefaultRole);
            this.grbOperatorAdd.Controls.Add(this.txtConfirmPassword);
            this.grbOperatorAdd.Controls.Add(this.lblConfirmPassword);
            this.grbOperatorAdd.Controls.Add(this.txtPassword);
            this.grbOperatorAdd.Controls.Add(this.lblPassword);
            this.grbOperatorAdd.Controls.Add(this.txtCode);
            this.grbOperatorAdd.Controls.Add(this.lblRealName);
            this.grbOperatorAdd.Controls.Add(this.lblUserName);
            this.grbOperatorAdd.Location = new System.Drawing.Point(11, 11);
            this.grbOperatorAdd.Name = "grbOperatorAdd";
            this.helpProvider.SetShowHelp(this.grbOperatorAdd, true);
            this.grbOperatorAdd.Size = new System.Drawing.Size(424, 268);
            this.grbOperatorAdd.TabIndex = 0;
            this.grbOperatorAdd.TabStop = false;
            this.grbOperatorAdd.Text = "用户";
            // 
            // cmbSecurityLevel
            // 
            this.cmbSecurityLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSecurityLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSecurityLevel.Location = new System.Drawing.Point(142, 141);
            this.cmbSecurityLevel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbSecurityLevel.Name = "cmbSecurityLevel";
            this.cmbSecurityLevel.Size = new System.Drawing.Size(236, 20);
            this.cmbSecurityLevel.TabIndex = 11;
            // 
            // lblSecurityLevel
            // 
            this.lblSecurityLevel.Location = new System.Drawing.Point(12, 144);
            this.lblSecurityLevel.Name = "lblSecurityLevel";
            this.lblSecurityLevel.Size = new System.Drawing.Size(130, 12);
            this.lblSecurityLevel.TabIndex = 10;
            this.lblSecurityLevel.Text = "安全级别(&S)：";
            this.lblSecurityLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(142, 238);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(48, 16);
            this.chkEnabled.TabIndex = 18;
            this.chkEnabled.Text = "有效";
            // 
            // cmbDefaultRole
            // 
            this.cmbDefaultRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDefaultRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDefaultRole.Location = new System.Drawing.Point(142, 114);
            this.cmbDefaultRole.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbDefaultRole.Name = "cmbDefaultRole";
            this.cmbDefaultRole.Size = new System.Drawing.Size(236, 20);
            this.cmbDefaultRole.TabIndex = 9;
            // 
            // lblFullNameReq
            // 
            this.lblFullNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullNameReq.AutoSize = true;
            this.lblFullNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblFullNameReq.Location = new System.Drawing.Point(393, 59);
            this.lblFullNameReq.Name = "lblFullNameReq";
            this.lblFullNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblFullNameReq.TabIndex = 5;
            this.lblFullNameReq.Text = "*";
            // 
            // lblConfirmPasswordReq
            // 
            this.lblConfirmPasswordReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConfirmPasswordReq.AutoSize = true;
            this.lblConfirmPasswordReq.ForeColor = System.Drawing.Color.Red;
            this.lblConfirmPasswordReq.Location = new System.Drawing.Point(392, 202);
            this.lblConfirmPasswordReq.Name = "lblConfirmPasswordReq";
            this.lblConfirmPasswordReq.Size = new System.Drawing.Size(11, 12);
            this.lblConfirmPasswordReq.TabIndex = 17;
            this.lblConfirmPasswordReq.Text = "*";
            // 
            // lblPasswordReq
            // 
            this.lblPasswordReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPasswordReq.AutoSize = true;
            this.lblPasswordReq.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordReq.Location = new System.Drawing.Point(392, 174);
            this.lblPasswordReq.Name = "lblPasswordReq";
            this.lblPasswordReq.Size = new System.Drawing.Size(11, 12);
            this.lblPasswordReq.TabIndex = 14;
            this.lblPasswordReq.Text = "*";
            // 
            // lblUserNameReq
            // 
            this.lblUserNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserNameReq.AutoSize = true;
            this.lblUserNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblUserNameReq.Location = new System.Drawing.Point(393, 31);
            this.lblUserNameReq.Name = "lblUserNameReq";
            this.lblUserNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblUserNameReq.TabIndex = 2;
            this.lblUserNameReq.Text = "*";
            // 
            // txtRealName
            // 
            this.txtRealName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRealName.Location = new System.Drawing.Point(142, 55);
            this.txtRealName.MaxLength = 50;
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.Size = new System.Drawing.Size(237, 21);
            this.txtRealName.TabIndex = 4;
            this.txtRealName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtFullName_MouseDoubleClick);
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.Location = new System.Drawing.Point(142, 27);
            this.txtUserName.MaxLength = 50;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(236, 21);
            this.txtUserName.TabIndex = 1;
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(12, 86);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(130, 12);
            this.lblCode.TabIndex = 6;
            this.lblCode.Text = "工号(编号)：";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDefaultRole
            // 
            this.lblDefaultRole.Location = new System.Drawing.Point(12, 117);
            this.lblDefaultRole.Name = "lblDefaultRole";
            this.lblDefaultRole.Size = new System.Drawing.Size(130, 12);
            this.lblDefaultRole.TabIndex = 8;
            this.lblDefaultRole.Text = "默认角色(&R)：";
            this.lblDefaultRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(142, 198);
            this.txtConfirmPassword.MaxLength = 20;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(237, 21);
            this.txtConfirmPassword.TabIndex = 16;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.Location = new System.Drawing.Point(12, 202);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(130, 12);
            this.lblConfirmPassword.TabIndex = 15;
            this.lblConfirmPassword.Text = "确认密码(&C)：";
            this.lblConfirmPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(142, 170);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(237, 21);
            this.txtPassword.TabIndex = 13;
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(12, 174);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(130, 12);
            this.lblPassword.TabIndex = 12;
            this.lblPassword.Text = "密码(&P)：";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(142, 83);
            this.txtCode.MaxLength = 20;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(237, 21);
            this.txtCode.TabIndex = 7;
            // 
            // lblRealName
            // 
            this.lblRealName.Location = new System.Drawing.Point(12, 58);
            this.lblRealName.Name = "lblRealName";
            this.lblRealName.Size = new System.Drawing.Size(130, 12);
            this.lblRealName.TabIndex = 3;
            this.lblRealName.Text = "姓名(&N)：";
            this.lblRealName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(12, 32);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(130, 12);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "登录用户名(&U)：";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmUserAdd
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(446, 324);
            this.Controls.Add(this.chkClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grbOperatorAdd);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUserAdd";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.helpProvider.SetShowHelp(this, true);
            this.Text = "添加用户";
            this.grbOperatorAdd.ResumeLayout(false);
            this.grbOperatorAdd.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grbOperatorAdd;
        private System.Windows.Forms.TextBox txtRealName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblDefaultRole;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblRealName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.HelpProvider helpProvider;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblConfirmPasswordReq;
        private System.Windows.Forms.Label lblPasswordReq;
        private System.Windows.Forms.Label lblUserNameReq;
        private System.Windows.Forms.Label lblFullNameReq;
        private System.Windows.Forms.ComboBox cmbDefaultRole;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.ComboBox cmbSecurityLevel;
        private System.Windows.Forms.Label lblSecurityLevel;
        private System.Windows.Forms.CheckBox chkClose;
    }
}