namespace DotNet.WinForm
{
    partial class FrmChangeCommunicationPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChangeCommunicationPassword));
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpSetPassword = new System.Windows.Forms.GroupBox();
            this.lblOldPasswordReq = new System.Windows.Forms.Label();
            this.lblConfirmPasswordReq = new System.Windows.Forms.Label();
            this.lblNewPasswordReq = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.lblOldPassword = new System.Windows.Forms.Label();
            this.grpSetPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(297, 204);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(378, 204);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grpSetPassword
            // 
            this.grpSetPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSetPassword.Controls.Add(this.lblOldPasswordReq);
            this.grpSetPassword.Controls.Add(this.lblConfirmPasswordReq);
            this.grpSetPassword.Controls.Add(this.lblNewPasswordReq);
            this.grpSetPassword.Controls.Add(this.txtNewPassword);
            this.grpSetPassword.Controls.Add(this.txtOldPassword);
            this.grpSetPassword.Controls.Add(this.txtConfirmPassword);
            this.grpSetPassword.Controls.Add(this.lblConfirmPassword);
            this.grpSetPassword.Controls.Add(this.lblNewPassword);
            this.grpSetPassword.Controls.Add(this.lblOldPassword);
            this.grpSetPassword.Location = new System.Drawing.Point(8, 65);
            this.grpSetPassword.Name = "grpSetPassword";
            this.grpSetPassword.Size = new System.Drawing.Size(445, 130);
            this.grpSetPassword.TabIndex = 0;
            this.grpSetPassword.TabStop = false;
            this.grpSetPassword.Text = "修改通讯密码";
            // 
            // lblOldPasswordReq
            // 
            this.lblOldPasswordReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOldPasswordReq.AutoSize = true;
            this.lblOldPasswordReq.ForeColor = System.Drawing.Color.Red;
            this.lblOldPasswordReq.Location = new System.Drawing.Point(409, 29);
            this.lblOldPasswordReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOldPasswordReq.Name = "lblOldPasswordReq";
            this.lblOldPasswordReq.Size = new System.Drawing.Size(11, 12);
            this.lblOldPasswordReq.TabIndex = 2;
            this.lblOldPasswordReq.Text = "*";
            // 
            // lblConfirmPasswordReq
            // 
            this.lblConfirmPasswordReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConfirmPasswordReq.AutoSize = true;
            this.lblConfirmPasswordReq.ForeColor = System.Drawing.Color.Red;
            this.lblConfirmPasswordReq.Location = new System.Drawing.Point(409, 94);
            this.lblConfirmPasswordReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConfirmPasswordReq.Name = "lblConfirmPasswordReq";
            this.lblConfirmPasswordReq.Size = new System.Drawing.Size(11, 12);
            this.lblConfirmPasswordReq.TabIndex = 8;
            this.lblConfirmPasswordReq.Text = "*";
            // 
            // lblNewPasswordReq
            // 
            this.lblNewPasswordReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNewPasswordReq.AutoSize = true;
            this.lblNewPasswordReq.ForeColor = System.Drawing.Color.Red;
            this.lblNewPasswordReq.Location = new System.Drawing.Point(409, 61);
            this.lblNewPasswordReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewPasswordReq.Name = "lblNewPasswordReq";
            this.lblNewPasswordReq.Size = new System.Drawing.Size(11, 12);
            this.lblNewPasswordReq.TabIndex = 5;
            this.lblNewPasswordReq.Text = "*";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.AllowDrop = true;
            this.txtNewPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewPassword.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtNewPassword.Location = new System.Drawing.Point(140, 58);
            this.txtNewPassword.MaxLength = 20;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(264, 21);
            this.txtNewPassword.TabIndex = 4;
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.AllowDrop = true;
            this.txtOldPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOldPassword.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtOldPassword.Location = new System.Drawing.Point(140, 26);
            this.txtOldPassword.MaxLength = 20;
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '*';
            this.txtOldPassword.Size = new System.Drawing.Size(264, 21);
            this.txtOldPassword.TabIndex = 1;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(140, 89);
            this.txtConfirmPassword.MaxLength = 20;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(264, 21);
            this.txtConfirmPassword.TabIndex = 7;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.Location = new System.Drawing.Point(13, 93);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(121, 12);
            this.lblConfirmPassword.TabIndex = 6;
            this.lblConfirmPassword.Text = "确认密码(&C)：";
            this.lblConfirmPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.Location = new System.Drawing.Point(13, 62);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(121, 12);
            this.lblNewPassword.TabIndex = 3;
            this.lblNewPassword.Text = "新密码(&N)：";
            this.lblNewPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.Location = new System.Drawing.Point(13, 30);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(121, 12);
            this.lblOldPassword.TabIndex = 0;
            this.lblOldPassword.Text = "原密码(&O)：";
            this.lblOldPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmChangeCommunicationPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(461, 233);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpSetPassword);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChangeCommunicationPassword";
            this.Text = "修改通讯密码";
            this.grpSetPassword.ResumeLayout(false);
            this.grpSetPassword.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpSetPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Label lblOldPassword;
        private System.Windows.Forms.Label lblOldPasswordReq;
        private System.Windows.Forms.Label lblConfirmPasswordReq;
        private System.Windows.Forms.Label lblNewPasswordReq;
    }
}