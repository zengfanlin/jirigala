namespace DotNet.WinForm
{
    partial class FrmDigitalSignature
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDigitalSignature));
            this.grbDigitalSignature = new System.Windows.Forms.GroupBox();
            this.lblCommunicationPasswordReq = new System.Windows.Forms.Label();
            this.lblSignedPasswordReq = new System.Windows.Forms.Label();
            this.lblDigitalSignatureReq = new System.Windows.Forms.Label();
            this.txtCommunicationPassword = new System.Windows.Forms.TextBox();
            this.txtSignedPassword = new System.Windows.Forms.TextBox();
            this.btnSelectDigitalSignature = new System.Windows.Forms.Button();
            this.txtDigitalSignature = new System.Windows.Forms.TextBox();
            this.lblCommunicationPassword = new System.Windows.Forms.Label();
            this.lblSignedPassword = new System.Windows.Forms.Label();
            this.lblDigitalSignature = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.grbDigitalSignature.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbDigitalSignature
            // 
            this.grbDigitalSignature.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDigitalSignature.Controls.Add(this.lblCommunicationPasswordReq);
            this.grbDigitalSignature.Controls.Add(this.lblSignedPasswordReq);
            this.grbDigitalSignature.Controls.Add(this.lblDigitalSignatureReq);
            this.grbDigitalSignature.Controls.Add(this.txtCommunicationPassword);
            this.grbDigitalSignature.Controls.Add(this.txtSignedPassword);
            this.grbDigitalSignature.Controls.Add(this.btnSelectDigitalSignature);
            this.grbDigitalSignature.Controls.Add(this.txtDigitalSignature);
            this.grbDigitalSignature.Controls.Add(this.lblCommunicationPassword);
            this.grbDigitalSignature.Controls.Add(this.lblSignedPassword);
            this.grbDigitalSignature.Controls.Add(this.lblDigitalSignature);
            this.grbDigitalSignature.Location = new System.Drawing.Point(8, 65);
            this.grbDigitalSignature.Name = "grbDigitalSignature";
            this.grbDigitalSignature.Size = new System.Drawing.Size(526, 137);
            this.grbDigitalSignature.TabIndex = 0;
            this.grbDigitalSignature.TabStop = false;
            this.grbDigitalSignature.Text = "数字签名";
            // 
            // lblCommunicationPasswordReq
            // 
            this.lblCommunicationPasswordReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCommunicationPasswordReq.AutoSize = true;
            this.lblCommunicationPasswordReq.ForeColor = System.Drawing.Color.Red;
            this.lblCommunicationPasswordReq.Location = new System.Drawing.Point(502, 105);
            this.lblCommunicationPasswordReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCommunicationPasswordReq.Name = "lblCommunicationPasswordReq";
            this.lblCommunicationPasswordReq.Size = new System.Drawing.Size(11, 12);
            this.lblCommunicationPasswordReq.TabIndex = 5;
            this.lblCommunicationPasswordReq.Text = "*";
            // 
            // lblSignedPasswordReq
            // 
            this.lblSignedPasswordReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSignedPasswordReq.AutoSize = true;
            this.lblSignedPasswordReq.ForeColor = System.Drawing.Color.Red;
            this.lblSignedPasswordReq.Location = new System.Drawing.Point(502, 70);
            this.lblSignedPasswordReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSignedPasswordReq.Name = "lblSignedPasswordReq";
            this.lblSignedPasswordReq.Size = new System.Drawing.Size(11, 12);
            this.lblSignedPasswordReq.TabIndex = 2;
            this.lblSignedPasswordReq.Text = "*";
            // 
            // lblDigitalSignatureReq
            // 
            this.lblDigitalSignatureReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDigitalSignatureReq.AutoSize = true;
            this.lblDigitalSignatureReq.ForeColor = System.Drawing.Color.Red;
            this.lblDigitalSignatureReq.Location = new System.Drawing.Point(502, 35);
            this.lblDigitalSignatureReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDigitalSignatureReq.Name = "lblDigitalSignatureReq";
            this.lblDigitalSignatureReq.Size = new System.Drawing.Size(11, 12);
            this.lblDigitalSignatureReq.TabIndex = 9;
            this.lblDigitalSignatureReq.Text = "*";
            // 
            // txtCommunicationPassword
            // 
            this.txtCommunicationPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommunicationPassword.Location = new System.Drawing.Point(110, 99);
            this.txtCommunicationPassword.MaxLength = 20;
            this.txtCommunicationPassword.Name = "txtCommunicationPassword";
            this.txtCommunicationPassword.PasswordChar = '*';
            this.txtCommunicationPassword.Size = new System.Drawing.Size(382, 21);
            this.txtCommunicationPassword.TabIndex = 4;
            // 
            // txtSignedPassword
            // 
            this.txtSignedPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSignedPassword.Location = new System.Drawing.Point(110, 65);
            this.txtSignedPassword.MaxLength = 20;
            this.txtSignedPassword.Name = "txtSignedPassword";
            this.txtSignedPassword.PasswordChar = '*';
            this.txtSignedPassword.Size = new System.Drawing.Size(382, 21);
            this.txtSignedPassword.TabIndex = 1;
            // 
            // btnSelectDigitalSignature
            // 
            this.btnSelectDigitalSignature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectDigitalSignature.Location = new System.Drawing.Point(420, 29);
            this.btnSelectDigitalSignature.Name = "btnSelectDigitalSignature";
            this.btnSelectDigitalSignature.Size = new System.Drawing.Size(71, 23);
            this.btnSelectDigitalSignature.TabIndex = 8;
            this.btnSelectDigitalSignature.TabStop = false;
            this.btnSelectDigitalSignature.Text = "选择...";
            this.btnSelectDigitalSignature.UseVisualStyleBackColor = true;
            this.btnSelectDigitalSignature.Click += new System.EventHandler(this.btnSelectDigitalSignature_Click);
            // 
            // txtDigitalSignature
            // 
            this.txtDigitalSignature.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDigitalSignature.Location = new System.Drawing.Point(110, 29);
            this.txtDigitalSignature.Name = "txtDigitalSignature";
            this.txtDigitalSignature.ReadOnly = true;
            this.txtDigitalSignature.Size = new System.Drawing.Size(308, 21);
            this.txtDigitalSignature.TabIndex = 7;
            this.txtDigitalSignature.TabStop = false;
            // 
            // lblCommunicationPassword
            // 
            this.lblCommunicationPassword.AutoSize = true;
            this.lblCommunicationPassword.Location = new System.Drawing.Point(18, 103);
            this.lblCommunicationPassword.Name = "lblCommunicationPassword";
            this.lblCommunicationPassword.Size = new System.Drawing.Size(89, 12);
            this.lblCommunicationPassword.TabIndex = 3;
            this.lblCommunicationPassword.Text = "安全通讯密码：";
            // 
            // lblSignedPassword
            // 
            this.lblSignedPassword.AutoSize = true;
            this.lblSignedPassword.Location = new System.Drawing.Point(42, 69);
            this.lblSignedPassword.Name = "lblSignedPassword";
            this.lblSignedPassword.Size = new System.Drawing.Size(65, 12);
            this.lblSignedPassword.TabIndex = 0;
            this.lblSignedPassword.Text = "签名密码：";
            // 
            // lblDigitalSignature
            // 
            this.lblDigitalSignature.AutoSize = true;
            this.lblDigitalSignature.Location = new System.Drawing.Point(42, 33);
            this.lblDigitalSignature.Name = "lblDigitalSignature";
            this.lblDigitalSignature.Size = new System.Drawing.Size(65, 12);
            this.lblDigitalSignature.TabIndex = 6;
            this.lblDigitalSignature.Text = "签名密钥：";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(463, 217);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(386, 217);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(71, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmDigitalSignature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(546, 249);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grbDigitalSignature);
            this.Controls.Add(this.btnOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDigitalSignature";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "签名密钥";
            this.grbDigitalSignature.ResumeLayout(false);
            this.grbDigitalSignature.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbDigitalSignature;
        private System.Windows.Forms.Label lblCommunicationPassword;
        private System.Windows.Forms.Label lblSignedPassword;
        private System.Windows.Forms.Label lblDigitalSignature;
        private System.Windows.Forms.TextBox txtCommunicationPassword;
        private System.Windows.Forms.TextBox txtSignedPassword;
        private System.Windows.Forms.Button btnSelectDigitalSignature;
        private System.Windows.Forms.TextBox txtDigitalSignature;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblCommunicationPasswordReq;
        private System.Windows.Forms.Label lblSignedPasswordReq;
        private System.Windows.Forms.Label lblDigitalSignatureReq;
    }
}