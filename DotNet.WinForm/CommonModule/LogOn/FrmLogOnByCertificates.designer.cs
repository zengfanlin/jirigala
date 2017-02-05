namespace DotNet.WinForm.LogOn
{
    partial class FrmLogOnByCertificates
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
            this.grpLogOn = new System.Windows.Forms.GroupBox();
            this.lblVerifyCodeReq = new System.Windows.Forms.Label();
            this.txtVerifyCode = new System.Windows.Forms.TextBox();
            this.lblVerifyCode = new System.Windows.Forms.Label();
            this.picVerifyCode = new System.Windows.Forms.PictureBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.chkRememberPassword = new System.Windows.Forms.CheckBox();
            this.labUserNameReq = new System.Windows.Forms.Label();
            this.labPasswordReq = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.grpLogOn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVerifyCode)).BeginInit();
            this.SuspendLayout();
            // 
            // grpLogOn
            // 
            this.grpLogOn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLogOn.Controls.Add(this.lblVerifyCodeReq);
            this.grpLogOn.Controls.Add(this.txtVerifyCode);
            this.grpLogOn.Controls.Add(this.lblVerifyCode);
            this.grpLogOn.Controls.Add(this.picVerifyCode);
            this.grpLogOn.Controls.Add(this.txtUser);
            this.grpLogOn.Controls.Add(this.chkRememberPassword);
            this.grpLogOn.Controls.Add(this.labUserNameReq);
            this.grpLogOn.Controls.Add(this.labPasswordReq);
            this.grpLogOn.Controls.Add(this.txtPassword);
            this.grpLogOn.Controls.Add(this.lblUser);
            this.grpLogOn.Controls.Add(this.lblPassword);
            this.grpLogOn.Location = new System.Drawing.Point(8, 61);
            this.grpLogOn.Name = "grpLogOn";
            this.grpLogOn.Size = new System.Drawing.Size(368, 152);
            this.grpLogOn.TabIndex = 0;
            this.grpLogOn.TabStop = false;
            this.grpLogOn.Text = "登录";
            // 
            // lblVerifyCodeReq
            // 
            this.lblVerifyCodeReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVerifyCodeReq.AutoSize = true;
            this.lblVerifyCodeReq.ForeColor = System.Drawing.Color.Red;
            this.lblVerifyCodeReq.Location = new System.Drawing.Point(350, 83);
            this.lblVerifyCodeReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVerifyCodeReq.Name = "lblVerifyCodeReq";
            this.lblVerifyCodeReq.Size = new System.Drawing.Size(11, 12);
            this.lblVerifyCodeReq.TabIndex = 8;
            this.lblVerifyCodeReq.Text = "*";
            // 
            // txtVerifyCode
            // 
            this.txtVerifyCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVerifyCode.Location = new System.Drawing.Point(105, 79);
            this.txtVerifyCode.MaxLength = 4;
            this.txtVerifyCode.Name = "txtVerifyCode";
            this.txtVerifyCode.Size = new System.Drawing.Size(92, 21);
            this.txtVerifyCode.TabIndex = 7;
            // 
            // lblVerifyCode
            // 
            this.lblVerifyCode.Location = new System.Drawing.Point(8, 83);
            this.lblVerifyCode.Name = "lblVerifyCode";
            this.lblVerifyCode.Size = new System.Drawing.Size(92, 12);
            this.lblVerifyCode.TabIndex = 6;
            this.lblVerifyCode.Text = "验证码(&V)：";
            this.lblVerifyCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picVerifyCode
            // 
            this.picVerifyCode.Location = new System.Drawing.Point(215, 79);
            this.picVerifyCode.Name = "picVerifyCode";
            this.picVerifyCode.Size = new System.Drawing.Size(128, 21);
            this.picVerifyCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picVerifyCode.TabIndex = 7;
            this.picVerifyCode.TabStop = false;
            this.picVerifyCode.DoubleClick += new System.EventHandler(this.picVerifyCode_DoubleClick);
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUser.Location = new System.Drawing.Point(105, 21);
            this.txtUser.MaxLength = 30;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(240, 21);
            this.txtUser.TabIndex = 1;
            // 
            // chkRememberPassword
            // 
            this.chkRememberPassword.AutoSize = true;
            this.chkRememberPassword.Location = new System.Drawing.Point(105, 125);
            this.chkRememberPassword.Name = "chkRememberPassword";
            this.chkRememberPassword.Size = new System.Drawing.Size(72, 16);
            this.chkRememberPassword.TabIndex = 9;
            this.chkRememberPassword.Text = "记住密码";
            this.chkRememberPassword.UseVisualStyleBackColor = true;
            // 
            // labUserNameReq
            // 
            this.labUserNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labUserNameReq.AutoSize = true;
            this.labUserNameReq.ForeColor = System.Drawing.Color.Red;
            this.labUserNameReq.Location = new System.Drawing.Point(350, 23);
            this.labUserNameReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labUserNameReq.Name = "labUserNameReq";
            this.labUserNameReq.Size = new System.Drawing.Size(11, 12);
            this.labUserNameReq.TabIndex = 2;
            this.labUserNameReq.Text = "*";
            // 
            // labPasswordReq
            // 
            this.labPasswordReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labPasswordReq.AutoSize = true;
            this.labPasswordReq.ForeColor = System.Drawing.Color.Red;
            this.labPasswordReq.Location = new System.Drawing.Point(350, 54);
            this.labPasswordReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labPasswordReq.Name = "labPasswordReq";
            this.labPasswordReq.Size = new System.Drawing.Size(11, 12);
            this.labPasswordReq.TabIndex = 5;
            this.labPasswordReq.Text = "*";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(105, 50);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(240, 21);
            this.txtPassword.TabIndex = 4;
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(8, 23);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(92, 12);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "用户(&U)：";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(8, 53);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(92, 12);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "密码(&P)：";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(217, 222);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(78, 23);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "登录(&L)";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(302, 222);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(74, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "退出(&E)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(301, 222);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfig.Location = new System.Drawing.Point(7, 222);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(110, 23);
            this.btnConfig.TabIndex = 3;
            this.btnConfig.Text = "系统配置...";
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // FrmLogOnByCertificates
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackgroundImage = global::DotNet.WinForm.Properties.Resources.Head;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(383, 251);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.grpLogOn);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExit);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogOnByCertificates";
            this.ShowInTaskbar = true;
            this.Text = "登录";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLogOnByName_FormClosed);
            this.Load += new System.EventHandler(this.FrmLogOnByName_Load);
            this.grpLogOn.ResumeLayout(false);
            this.grpLogOn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVerifyCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLogOn;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labUserNameReq;
        private System.Windows.Forms.Label labPasswordReq;
        private System.Windows.Forms.CheckBox chkRememberPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Label lblVerifyCodeReq;
        private System.Windows.Forms.TextBox txtVerifyCode;
        private System.Windows.Forms.Label lblVerifyCode;
        private System.Windows.Forms.PictureBox picVerifyCode;
    }
}