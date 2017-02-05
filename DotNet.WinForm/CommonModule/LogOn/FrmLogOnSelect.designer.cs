namespace DotNet.WinForm
{
    partial class FrmLogOnSelect
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
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.cmbLogOnTo = new System.Windows.Forms.ComboBox();
            this.lblLogOnTo = new System.Windows.Forms.Label();
            this.labUserNameReq = new System.Windows.Forms.Label();
            this.labPasswordReq = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.labUserName = new System.Windows.Forms.Label();
            this.labPassword = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpLogOn.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLogOn
            // 
            this.grpLogOn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLogOn.Controls.Add(this.txtUserName);
            this.grpLogOn.Controls.Add(this.cmbLogOnTo);
            this.grpLogOn.Controls.Add(this.lblLogOnTo);
            this.grpLogOn.Controls.Add(this.labUserNameReq);
            this.grpLogOn.Controls.Add(this.labPasswordReq);
            this.grpLogOn.Controls.Add(this.txtPassword);
            this.grpLogOn.Controls.Add(this.labUserName);
            this.grpLogOn.Controls.Add(this.labPassword);
            this.grpLogOn.Location = new System.Drawing.Point(8, 61);
            this.grpLogOn.Name = "grpLogOn";
            this.grpLogOn.Size = new System.Drawing.Size(404, 112);
            this.grpLogOn.TabIndex = 0;
            this.grpLogOn.TabStop = false;
            this.grpLogOn.Text = "登录";
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.Location = new System.Drawing.Point(123, 50);
            this.txtUserName.MaxLength = 20;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(256, 21);
            this.txtUserName.TabIndex = 3;
            // 
            // cmbLogOnTo
            // 
            this.cmbLogOnTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLogOnTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogOnTo.Location = new System.Drawing.Point(123, 20);
            this.cmbLogOnTo.Name = "cmbLogOnTo";
            this.cmbLogOnTo.Size = new System.Drawing.Size(256, 20);
            this.cmbLogOnTo.TabIndex = 1;
            // 
            // lblLogOnTo
            // 
            this.lblLogOnTo.Location = new System.Drawing.Point(16, 23);
            this.lblLogOnTo.Name = "lblLogOnTo";
            this.lblLogOnTo.Size = new System.Drawing.Size(98, 12);
            this.lblLogOnTo.TabIndex = 0;
            this.lblLogOnTo.Text = "登录到(&T)：";
            this.lblLogOnTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labUserNameReq
            // 
            this.labUserNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labUserNameReq.AutoSize = true;
            this.labUserNameReq.ForeColor = System.Drawing.Color.Red;
            this.labUserNameReq.Location = new System.Drawing.Point(386, 53);
            this.labUserNameReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labUserNameReq.Name = "labUserNameReq";
            this.labUserNameReq.Size = new System.Drawing.Size(11, 12);
            this.labUserNameReq.TabIndex = 4;
            this.labUserNameReq.Text = "*";
            // 
            // labPasswordReq
            // 
            this.labPasswordReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labPasswordReq.AutoSize = true;
            this.labPasswordReq.ForeColor = System.Drawing.Color.Red;
            this.labPasswordReq.Location = new System.Drawing.Point(386, 84);
            this.labPasswordReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labPasswordReq.Name = "labPasswordReq";
            this.labPasswordReq.Size = new System.Drawing.Size(11, 12);
            this.labPasswordReq.TabIndex = 7;
            this.labPasswordReq.Text = "*";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(123, 80);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(256, 21);
            this.txtPassword.TabIndex = 6;
            // 
            // labUserName
            // 
            this.labUserName.Location = new System.Drawing.Point(16, 53);
            this.labUserName.Name = "labUserName";
            this.labUserName.Size = new System.Drawing.Size(98, 12);
            this.labUserName.TabIndex = 2;
            this.labUserName.Text = "用户名(&U)：";
            this.labUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labPassword
            // 
            this.labPassword.Location = new System.Drawing.Point(16, 83);
            this.labPassword.Name = "labPassword";
            this.labPassword.Size = new System.Drawing.Size(98, 12);
            this.labPassword.TabIndex = 5;
            this.labPassword.Text = "密码(&P)：";
            this.labPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(256, 182);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "登录(&L)";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(338, 182);
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
            this.btnCancel.Location = new System.Drawing.Point(337, 182);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmLogOnSelect
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackgroundImage = global::DotNet.WinForm.Properties.Resources.Head;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(419, 211);
            this.Controls.Add(this.grpLogOn);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExit);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogOnSelect";
            this.Text = "登录";
            this.grpLogOn.ResumeLayout(false);
            this.grpLogOn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLogOn;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label labUserName;
        private System.Windows.Forms.Label labPassword;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labUserNameReq;
        private System.Windows.Forms.Label labPasswordReq;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.ComboBox cmbLogOnTo;
        private System.Windows.Forms.Label lblLogOnTo;
    }
}