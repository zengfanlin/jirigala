namespace DotNet.Common.UILayer.WinForm.Login
{
    partial class FrmSAPLogin
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。

        /// </summary>
        private void InitializeComponent()
        {
            this.grpLogin = new System.Windows.Forms.GroupBox();
            this.labUsernameReq = new System.Windows.Forms.Label();
            this.labPasswordReq = new System.Windows.Forms.Label();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.labUser = new System.Windows.Forms.Label();
            this.labPassword = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRequestAnAccount = new System.Windows.Forms.Button();
            this.grpLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLogin
            // 
            this.grpLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLogin.Controls.Add(this.labUsernameReq);
            this.grpLogin.Controls.Add(this.labPasswordReq);
            this.grpLogin.Controls.Add(this.cmbUser);
            this.grpLogin.Controls.Add(this.txtPassword);
            this.grpLogin.Controls.Add(this.labUser);
            this.grpLogin.Controls.Add(this.labPassword);
            this.grpLogin.Location = new System.Drawing.Point(8, 61);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.Size = new System.Drawing.Size(349, 83);
            this.grpLogin.TabIndex = 0;
            this.grpLogin.TabStop = false;
            this.grpLogin.Text = "登录";
            // 
            // labUsernameReq
            // 
            this.labUsernameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labUsernameReq.AutoSize = true;
            this.labUsernameReq.ForeColor = System.Drawing.Color.Red;
            this.labUsernameReq.Location = new System.Drawing.Point(331, 23);
            this.labUsernameReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labUsernameReq.Name = "labUsernameReq";
            this.labUsernameReq.Size = new System.Drawing.Size(11, 12);
            this.labUsernameReq.TabIndex = 2;
            this.labUsernameReq.Text = "*";
            // 
            // labPasswordReq
            // 
            this.labPasswordReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labPasswordReq.AutoSize = true;
            this.labPasswordReq.ForeColor = System.Drawing.Color.Red;
            this.labPasswordReq.Location = new System.Drawing.Point(331, 54);
            this.labPasswordReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labPasswordReq.Name = "labPasswordReq";
            this.labPasswordReq.Size = new System.Drawing.Size(11, 12);
            this.labPasswordReq.TabIndex = 5;
            this.labPasswordReq.Text = "*";
            // 
            // cmbUser
            // 
            this.cmbUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.Location = new System.Drawing.Point(105, 20);
            this.cmbUser.MaxDropDownItems = 10;
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(221, 20);
            this.cmbUser.TabIndex = 1;
            this.cmbUser.SelectedIndexChanged += new System.EventHandler(this.cmbUsername_SelectedIndexChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(105, 50);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(221, 21);
            this.txtPassword.TabIndex = 4;
            // 
            // labUser
            // 
            this.labUser.AutoSize = true;
            this.labUser.Location = new System.Drawing.Point(9, 23);
            this.labUser.Name = "labUser";
            this.labUser.Size = new System.Drawing.Size(53, 12);
            this.labUser.TabIndex = 0;
            this.labUser.Text = "用户(&U):";
            // 
            // labPassword
            // 
            this.labPassword.AutoSize = true;
            this.labPassword.Location = new System.Drawing.Point(9, 53);
            this.labPassword.Name = "labPassword";
            this.labPassword.Size = new System.Drawing.Size(53, 12);
            this.labPassword.TabIndex = 3;
            this.labPassword.Text = "密码(&P):";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(199, 153);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "登录(&L)";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(283, 153);
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
            this.btnCancel.Location = new System.Drawing.Point(282, 153);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRequestAnAccount
            // 
            this.btnRequestAnAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRequestAnAccount.Location = new System.Drawing.Point(8, 153);
            this.btnRequestAnAccount.Name = "btnRequestAnAccount";
            this.btnRequestAnAccount.Size = new System.Drawing.Size(75, 23);
            this.btnRequestAnAccount.TabIndex = 1;
            this.btnRequestAnAccount.Text = "申请帐户";
            this.btnRequestAnAccount.Click += new System.EventHandler(this.btnRequestAnAccount_Click);
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(364, 182);
            this.Controls.Add(this.btnRequestAnAccount);
            this.Controls.Add(this.grpLogin);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExit);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.Text = "登录";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.grpLogin.ResumeLayout(false);
            this.grpLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLogin;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label labUser;
        private System.Windows.Forms.Label labPassword;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labUsernameReq;
        private System.Windows.Forms.Label labPasswordReq;
        private System.Windows.Forms.Button btnRequestAnAccount;
    }
}