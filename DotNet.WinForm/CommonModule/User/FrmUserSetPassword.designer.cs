namespace DotNet.WinForm
{
    partial class FrmUserSetPassword
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
            this.grpSetPassword = new System.Windows.Forms.GroupBox();
            this.lblConfirmPasswordReq = new System.Windows.Forms.Label();
            this.lblNewPasswordReq = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDeletePassword = new System.Windows.Forms.Button();
            this.btnSetDefaultPassword = new System.Windows.Forms.Button();
            this.btnSetAsUserCode = new System.Windows.Forms.Button();
            this.btnSetAsUserName = new System.Windows.Forms.Button();
            this.grpSetPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSetPassword
            // 
            this.grpSetPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSetPassword.Controls.Add(this.lblConfirmPasswordReq);
            this.grpSetPassword.Controls.Add(this.lblNewPasswordReq);
            this.grpSetPassword.Controls.Add(this.txtConfirmPassword);
            this.grpSetPassword.Controls.Add(this.txtNewPassword);
            this.grpSetPassword.Controls.Add(this.lblConfirmPassword);
            this.grpSetPassword.Controls.Add(this.lblNewPassword);
            this.grpSetPassword.Location = new System.Drawing.Point(8, 67);
            this.grpSetPassword.Name = "grpSetPassword";
            this.grpSetPassword.Size = new System.Drawing.Size(483, 119);
            this.grpSetPassword.TabIndex = 0;
            this.grpSetPassword.TabStop = false;
            this.grpSetPassword.Text = "设置密码";
            // 
            // lblConfirmPasswordReq
            // 
            this.lblConfirmPasswordReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConfirmPasswordReq.AutoSize = true;
            this.lblConfirmPasswordReq.ForeColor = System.Drawing.Color.Red;
            this.lblConfirmPasswordReq.Location = new System.Drawing.Point(461, 71);
            this.lblConfirmPasswordReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConfirmPasswordReq.Name = "lblConfirmPasswordReq";
            this.lblConfirmPasswordReq.Size = new System.Drawing.Size(11, 12);
            this.lblConfirmPasswordReq.TabIndex = 5;
            this.lblConfirmPasswordReq.Text = "*";
            // 
            // lblNewPasswordReq
            // 
            this.lblNewPasswordReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNewPasswordReq.AutoSize = true;
            this.lblNewPasswordReq.ForeColor = System.Drawing.Color.Red;
            this.lblNewPasswordReq.Location = new System.Drawing.Point(461, 39);
            this.lblNewPasswordReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewPasswordReq.Name = "lblNewPasswordReq";
            this.lblNewPasswordReq.Size = new System.Drawing.Size(11, 12);
            this.lblNewPasswordReq.TabIndex = 2;
            this.lblNewPasswordReq.Text = "*";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfirmPassword.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtConfirmPassword.Location = new System.Drawing.Point(132, 66);
            this.txtConfirmPassword.MaxLength = 20;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(324, 21);
            this.txtConfirmPassword.TabIndex = 4;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewPassword.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtNewPassword.Location = new System.Drawing.Point(132, 34);
            this.txtNewPassword.MaxLength = 20;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(324, 21);
            this.txtNewPassword.TabIndex = 1;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.Location = new System.Drawing.Point(8, 69);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(118, 12);
            this.lblConfirmPassword.TabIndex = 3;
            this.lblConfirmPassword.Text = "确认密码(&C)：";
            this.lblConfirmPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.Location = new System.Drawing.Point(8, 37);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(118, 12);
            this.lblNewPassword.TabIndex = 0;
            this.lblNewPassword.Text = "新密码(&N)：";
            this.lblNewPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(335, 200);
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
            this.btnCancel.Location = new System.Drawing.Point(416, 200);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDeletePassword
            // 
            this.btnDeletePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeletePassword.Location = new System.Drawing.Point(7, 200);
            this.btnDeletePassword.Name = "btnDeletePassword";
            this.btnDeletePassword.Size = new System.Drawing.Size(110, 23);
            this.btnDeletePassword.TabIndex = 3;
            this.btnDeletePassword.Text = "删除密码(&D)";
            this.btnDeletePassword.Click += new System.EventHandler(this.btnDeletePassword_Click);
            // 
            // btnSetDefaultPassword
            // 
            this.btnSetDefaultPassword.Location = new System.Drawing.Point(123, 201);
            this.btnSetDefaultPassword.Name = "btnSetDefaultPassword";
            this.btnSetDefaultPassword.Size = new System.Drawing.Size(146, 23);
            this.btnSetDefaultPassword.TabIndex = 4;
            this.btnSetDefaultPassword.Text = "设置为系统默认密码";
            this.btnSetDefaultPassword.Visible = false;
            this.btnSetDefaultPassword.Click += new System.EventHandler(this.btnSetDefaultPassword_Click);
            // 
            // btnSetAsUserCode
            // 
            this.btnSetAsUserCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetAsUserCode.Location = new System.Drawing.Point(297, 8);
            this.btnSetAsUserCode.Name = "btnSetAsUserCode";
            this.btnSetAsUserCode.Size = new System.Drawing.Size(95, 23);
            this.btnSetAsUserCode.TabIndex = 5;
            this.btnSetAsUserCode.Text = "设置为工号";
            this.btnSetAsUserCode.Visible = false;
            this.btnSetAsUserCode.Click += new System.EventHandler(this.btnSetAsUserCode_Click);
            // 
            // btnSetAsUserName
            // 
            this.btnSetAsUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetAsUserName.Location = new System.Drawing.Point(396, 8);
            this.btnSetAsUserName.Name = "btnSetAsUserName";
            this.btnSetAsUserName.Size = new System.Drawing.Size(95, 23);
            this.btnSetAsUserName.TabIndex = 6;
            this.btnSetAsUserName.Text = "设置为用户名";
            this.btnSetAsUserName.Visible = false;
            this.btnSetAsUserName.Click += new System.EventHandler(this.btnSetAsUserName_Click);
            // 
            // FrmUserSetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DotNet.WinForm.Properties.Resources.Head;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(499, 232);
            this.Controls.Add(this.btnSetAsUserName);
            this.Controls.Add(this.btnSetAsUserCode);
            this.Controls.Add(this.btnSetDefaultPassword);
            this.Controls.Add(this.btnDeletePassword);
            this.Controls.Add(this.grpSetPassword);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUserSetPassword";
            this.Text = "重置密码";
            this.grpSetPassword.ResumeLayout(false);
            this.grpSetPassword.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSetPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblConfirmPasswordReq;
        private System.Windows.Forms.Label lblNewPasswordReq;
        private System.Windows.Forms.Button btnDeletePassword;
        private System.Windows.Forms.Button btnSetDefaultPassword;
        private System.Windows.Forms.Button btnSetAsUserCode;
        private System.Windows.Forms.Button btnSetAsUserName;
    }
}