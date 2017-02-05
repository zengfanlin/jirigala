namespace DotNet.WinForm
{
    partial class FrmCreateDigitalSignature
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCreateDigitalSignature));
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpSetPassword = new System.Windows.Forms.GroupBox();
            this.lblOutputReq = new System.Windows.Forms.Label();
            this.btnClearOutput = new System.Windows.Forms.Button();
            this.btnOutput = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.lblConfirmPasswordReq = new System.Windows.Forms.Label();
            this.lblNewPasswordReq = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.grpSetPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(446, 222);
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
            this.btnCancel.Location = new System.Drawing.Point(527, 222);
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
            this.grpSetPassword.Controls.Add(this.lblOutputReq);
            this.grpSetPassword.Controls.Add(this.btnClearOutput);
            this.grpSetPassword.Controls.Add(this.btnOutput);
            this.grpSetPassword.Controls.Add(this.txtOutput);
            this.grpSetPassword.Controls.Add(this.lblOutput);
            this.grpSetPassword.Controls.Add(this.lblConfirmPasswordReq);
            this.grpSetPassword.Controls.Add(this.lblNewPasswordReq);
            this.grpSetPassword.Controls.Add(this.txtPassword);
            this.grpSetPassword.Controls.Add(this.txtConfirmPassword);
            this.grpSetPassword.Controls.Add(this.lblConfirmPassword);
            this.grpSetPassword.Controls.Add(this.lblNewPassword);
            this.grpSetPassword.Location = new System.Drawing.Point(8, 65);
            this.grpSetPassword.Name = "grpSetPassword";
            this.grpSetPassword.Size = new System.Drawing.Size(594, 139);
            this.grpSetPassword.TabIndex = 0;
            this.grpSetPassword.TabStop = false;
            this.grpSetPassword.Text = "创建签名密钥";
            // 
            // lblOutputReq
            // 
            this.lblOutputReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOutputReq.AutoSize = true;
            this.lblOutputReq.ForeColor = System.Drawing.Color.Red;
            this.lblOutputReq.Location = new System.Drawing.Point(560, 100);
            this.lblOutputReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOutputReq.Name = "lblOutputReq";
            this.lblOutputReq.Size = new System.Drawing.Size(11, 12);
            this.lblOutputReq.TabIndex = 10;
            this.lblOutputReq.Text = "*";
            // 
            // btnClearOutput
            // 
            this.btnClearOutput.Image = ((System.Drawing.Image)(resources.GetObject("btnClearOutput.Image")));
            this.btnClearOutput.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClearOutput.Location = new System.Drawing.Point(522, 95);
            this.btnClearOutput.Name = "btnClearOutput";
            this.btnClearOutput.Size = new System.Drawing.Size(33, 23);
            this.btnClearOutput.TabIndex = 9;
            this.btnClearOutput.TabStop = false;
            this.btnClearOutput.UseVisualStyleBackColor = true;
            this.btnClearOutput.Click += new System.EventHandler(this.btnClearOutput_Click);
            // 
            // btnOutput
            // 
            this.btnOutput.Image = ((System.Drawing.Image)(resources.GetObject("btnOutput.Image")));
            this.btnOutput.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOutput.Location = new System.Drawing.Point(489, 95);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(33, 23);
            this.btnOutput.TabIndex = 8;
            this.btnOutput.TabStop = false;
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(142, 96);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(346, 21);
            this.txtOutput.TabIndex = 7;
            this.txtOutput.TabStop = false;
            // 
            // lblOutput
            // 
            this.lblOutput.Location = new System.Drawing.Point(15, 100);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(121, 12);
            this.lblOutput.TabIndex = 6;
            this.lblOutput.Text = "签名密钥输出目录：";
            this.lblOutput.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblConfirmPasswordReq
            // 
            this.lblConfirmPasswordReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConfirmPasswordReq.AutoSize = true;
            this.lblConfirmPasswordReq.ForeColor = System.Drawing.Color.Red;
            this.lblConfirmPasswordReq.Location = new System.Drawing.Point(560, 67);
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
            this.lblNewPasswordReq.Location = new System.Drawing.Point(560, 34);
            this.lblNewPasswordReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewPasswordReq.Name = "lblNewPasswordReq";
            this.lblNewPasswordReq.Size = new System.Drawing.Size(11, 12);
            this.lblNewPasswordReq.TabIndex = 2;
            this.lblNewPasswordReq.Text = "*";
            // 
            // txtPassword
            // 
            this.txtPassword.AllowDrop = true;
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtPassword.Location = new System.Drawing.Point(142, 29);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(413, 21);
            this.txtPassword.TabIndex = 1;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(142, 63);
            this.txtConfirmPassword.MaxLength = 20;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(413, 21);
            this.txtConfirmPassword.TabIndex = 4;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.Location = new System.Drawing.Point(15, 66);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(121, 12);
            this.lblConfirmPassword.TabIndex = 3;
            this.lblConfirmPassword.Text = "确认签名密码(&C)：";
            this.lblConfirmPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.Location = new System.Drawing.Point(15, 32);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(121, 12);
            this.lblNewPassword.TabIndex = 0;
            this.lblNewPassword.Text = "签名密码(&N)：";
            this.lblNewPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmCreateDigitalSignature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(610, 258);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpSetPassword);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCreateDigitalSignature";
            this.Text = "创建签名密钥";
            this.grpSetPassword.ResumeLayout(false);
            this.grpSetPassword.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpSetPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Label lblConfirmPasswordReq;
        private System.Windows.Forms.Label lblNewPasswordReq;
        private System.Windows.Forms.Label lblOutputReq;
        private System.Windows.Forms.Button btnClearOutput;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label lblOutput;
    }
}