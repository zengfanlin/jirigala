namespace DotNet.WinForm
{
    partial class FrmLogOnByName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogOnByName));
            this.grpLogOn = new System.Windows.Forms.GroupBox();
            this.chbAutoLogOn = new System.Windows.Forms.CheckBox();
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
            this.btnRequestAnAccount = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.grpLogOn.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLogOn
            // 
            this.grpLogOn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLogOn.Controls.Add(this.chbAutoLogOn);
            this.grpLogOn.Controls.Add(this.txtUser);
            this.grpLogOn.Controls.Add(this.chkRememberPassword);
            this.grpLogOn.Controls.Add(this.labUserNameReq);
            this.grpLogOn.Controls.Add(this.labPasswordReq);
            this.grpLogOn.Controls.Add(this.txtPassword);
            this.grpLogOn.Controls.Add(this.lblUser);
            this.grpLogOn.Controls.Add(this.lblPassword);
            this.grpLogOn.Location = new System.Drawing.Point(8, 61);
            this.grpLogOn.Name = "grpLogOn";
            this.grpLogOn.Size = new System.Drawing.Size(364, 105);
            this.grpLogOn.TabIndex = 0;
            this.grpLogOn.TabStop = false;
            this.grpLogOn.Text = "登录";
            // 
            // chbAutoLogOn
            // 
            this.chbAutoLogOn.AutoSize = true;
            this.chbAutoLogOn.Location = new System.Drawing.Point(246, 80);
            this.chbAutoLogOn.Name = "chbAutoLogOn";
            this.chbAutoLogOn.Size = new System.Drawing.Size(72, 16);
            this.chbAutoLogOn.TabIndex = 7;
            this.chbAutoLogOn.Text = "自动登录";
            this.chbAutoLogOn.UseVisualStyleBackColor = true;
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUser.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtUser.Location = new System.Drawing.Point(105, 21);
            this.txtUser.MaxLength = 30;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(236, 21);
            this.txtUser.TabIndex = 1;
            // 
            // chkRememberPassword
            // 
            this.chkRememberPassword.AutoSize = true;
            this.chkRememberPassword.Location = new System.Drawing.Point(105, 80);
            this.chkRememberPassword.Name = "chkRememberPassword";
            this.chkRememberPassword.Size = new System.Drawing.Size(72, 16);
            this.chkRememberPassword.TabIndex = 6;
            this.chkRememberPassword.Text = "记住密码";
            this.chkRememberPassword.UseVisualStyleBackColor = true;
            // 
            // labUserNameReq
            // 
            this.labUserNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labUserNameReq.AutoSize = true;
            this.labUserNameReq.ForeColor = System.Drawing.Color.Red;
            this.labUserNameReq.Location = new System.Drawing.Point(346, 23);
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
            this.labPasswordReq.Location = new System.Drawing.Point(346, 54);
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
            this.txtPassword.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtPassword.Location = new System.Drawing.Point(105, 50);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(236, 21);
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
            this.btnConfirm.Location = new System.Drawing.Point(210, 175);
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
            this.btnExit.Location = new System.Drawing.Point(298, 175);
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
            this.btnCancel.Location = new System.Drawing.Point(294, 175);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRequestAnAccount
            // 
            this.btnRequestAnAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRequestAnAccount.Location = new System.Drawing.Point(250, 8);
            this.btnRequestAnAccount.Name = "btnRequestAnAccount";
            this.btnRequestAnAccount.Size = new System.Drawing.Size(122, 23);
            this.btnRequestAnAccount.TabIndex = 4;
            this.btnRequestAnAccount.Text = "申请帐户...";
            this.btnRequestAnAccount.Click += new System.EventHandler(this.btnRequestAnAccount_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfig.Location = new System.Drawing.Point(7, 175);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(110, 23);
            this.btnConfig.TabIndex = 3;
            this.btnConfig.Text = "系统配置...";
            this.btnConfig.Visible = false;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // FrmLogOnByName
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(379, 204);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnRequestAnAccount);
            this.Controls.Add(this.grpLogOn);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExit);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogOnByName";
            this.ShowInTaskbar = true;
            this.Text = "登录";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLogOnByName_FormClosed);
            this.Load += new System.EventHandler(this.FrmLogOnByName_Load);
            this.DoubleClick += new System.EventHandler(this.FrmLogOnByName_DoubleClick);
            this.grpLogOn.ResumeLayout(false);
            this.grpLogOn.PerformLayout();
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
        private System.Windows.Forms.Button btnRequestAnAccount;
        private System.Windows.Forms.CheckBox chkRememberPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.CheckBox chbAutoLogOn;
    }
}