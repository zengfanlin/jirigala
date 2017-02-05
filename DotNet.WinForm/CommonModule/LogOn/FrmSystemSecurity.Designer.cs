namespace DotNet.WinForm
{
    partial class FrmSystemSecurity
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
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpPasswordSecurity = new System.Windows.Forms.GroupBox();
            this.nudPasswordChangeCycle = new System.Windows.Forms.NumericUpDown();
            this.nudPasswordMiniLength = new System.Windows.Forms.NumericUpDown();
            this.lblPasswordChangeCycle = new System.Windows.Forms.Label();
            this.chkNumericCharacters = new System.Windows.Forms.CheckBox();
            this.lblPasswordMiniLength = new System.Windows.Forms.Label();
            this.chkServerEncryptPassword = new System.Windows.Forms.CheckBox();
            this.chkCheckOnLine = new System.Windows.Forms.CheckBox();
            this.lblPasswordLockCycle = new System.Windows.Forms.Label();
            this.lblPasswordErrowLock = new System.Windows.Forms.Label();
            this.lblAccountMinimumLength = new System.Windows.Forms.Label();
            this.grpBruteForce = new System.Windows.Forms.GroupBox();
            this.nudPasswordErrowLockLimit = new System.Windows.Forms.NumericUpDown();
            this.nudPasswordErrowLockCycle = new System.Windows.Forms.NumericUpDown();
            this.grpAccountSecurity = new System.Windows.Forms.GroupBox();
            this.nudAccountMinimumLength = new System.Windows.Forms.NumericUpDown();
            this.grpPasswordSecurity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPasswordChangeCycle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPasswordMiniLength)).BeginInit();
            this.grpBruteForce.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPasswordErrowLockLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPasswordErrowLockCycle)).BeginInit();
            this.grpAccountSecurity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAccountMinimumLength)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(345, 331);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(78, 23);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "保存(&S)";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(432, 331);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grpPasswordSecurity
            // 
            this.grpPasswordSecurity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPasswordSecurity.Controls.Add(this.nudPasswordChangeCycle);
            this.grpPasswordSecurity.Controls.Add(this.nudPasswordMiniLength);
            this.grpPasswordSecurity.Controls.Add(this.lblPasswordChangeCycle);
            this.grpPasswordSecurity.Controls.Add(this.chkNumericCharacters);
            this.grpPasswordSecurity.Controls.Add(this.lblPasswordMiniLength);
            this.grpPasswordSecurity.Controls.Add(this.chkServerEncryptPassword);
            this.grpPasswordSecurity.Location = new System.Drawing.Point(12, 66);
            this.grpPasswordSecurity.Name = "grpPasswordSecurity";
            this.grpPasswordSecurity.Size = new System.Drawing.Size(498, 93);
            this.grpPasswordSecurity.TabIndex = 0;
            this.grpPasswordSecurity.TabStop = false;
            this.grpPasswordSecurity.Text = "密码安全";
            // 
            // nudPasswordChangeCycle
            // 
            this.nudPasswordChangeCycle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPasswordChangeCycle.Location = new System.Drawing.Point(404, 60);
            this.nudPasswordChangeCycle.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this.nudPasswordChangeCycle.Name = "nudPasswordChangeCycle";
            this.nudPasswordChangeCycle.Size = new System.Drawing.Size(75, 21);
            this.nudPasswordChangeCycle.TabIndex = 5;
            this.nudPasswordChangeCycle.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // nudPasswordMiniLength
            // 
            this.nudPasswordMiniLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPasswordMiniLength.Location = new System.Drawing.Point(404, 29);
            this.nudPasswordMiniLength.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.nudPasswordMiniLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPasswordMiniLength.Name = "nudPasswordMiniLength";
            this.nudPasswordMiniLength.Size = new System.Drawing.Size(75, 21);
            this.nudPasswordMiniLength.TabIndex = 2;
            this.nudPasswordMiniLength.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // lblPasswordChangeCycle
            // 
            this.lblPasswordChangeCycle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPasswordChangeCycle.AutoSize = true;
            this.lblPasswordChangeCycle.Location = new System.Drawing.Point(284, 64);
            this.lblPasswordChangeCycle.Name = "lblPasswordChangeCycle";
            this.lblPasswordChangeCycle.Size = new System.Drawing.Size(113, 12);
            this.lblPasswordChangeCycle.TabIndex = 4;
            this.lblPasswordChangeCycle.Text = "密码修改周期(月)：";
            // 
            // chkNumericCharacters
            // 
            this.chkNumericCharacters.AutoSize = true;
            this.chkNumericCharacters.Checked = true;
            this.chkNumericCharacters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNumericCharacters.Location = new System.Drawing.Point(27, 60);
            this.chkNumericCharacters.Name = "chkNumericCharacters";
            this.chkNumericCharacters.Size = new System.Drawing.Size(126, 16);
            this.chkNumericCharacters.TabIndex = 3;
            this.chkNumericCharacters.Text = "必须字母+数字组合";
            this.chkNumericCharacters.UseVisualStyleBackColor = true;
            // 
            // lblPasswordMiniLength
            // 
            this.lblPasswordMiniLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPasswordMiniLength.AutoSize = true;
            this.lblPasswordMiniLength.Location = new System.Drawing.Point(308, 33);
            this.lblPasswordMiniLength.Name = "lblPasswordMiniLength";
            this.lblPasswordMiniLength.Size = new System.Drawing.Size(89, 12);
            this.lblPasswordMiniLength.TabIndex = 1;
            this.lblPasswordMiniLength.Text = "密码最小长度：";
            // 
            // chkServerEncryptPassword
            // 
            this.chkServerEncryptPassword.AutoSize = true;
            this.chkServerEncryptPassword.Checked = true;
            this.chkServerEncryptPassword.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkServerEncryptPassword.Location = new System.Drawing.Point(27, 29);
            this.chkServerEncryptPassword.Name = "chkServerEncryptPassword";
            this.chkServerEncryptPassword.Size = new System.Drawing.Size(144, 16);
            this.chkServerEncryptPassword.TabIndex = 0;
            this.chkServerEncryptPassword.Text = "服务器上加密存储密码";
            this.chkServerEncryptPassword.UseVisualStyleBackColor = true;
            // 
            // chkCheckOnLine
            // 
            this.chkCheckOnLine.AutoSize = true;
            this.chkCheckOnLine.Checked = true;
            this.chkCheckOnLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCheckOnLine.Location = new System.Drawing.Point(27, 30);
            this.chkCheckOnLine.Name = "chkCheckOnLine";
            this.chkCheckOnLine.Size = new System.Drawing.Size(120, 16);
            this.chkCheckOnLine.TabIndex = 0;
            this.chkCheckOnLine.Text = "禁止用户重复登录";
            this.chkCheckOnLine.UseVisualStyleBackColor = true;
            // 
            // lblPasswordLockCycle
            // 
            this.lblPasswordLockCycle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPasswordLockCycle.AutoSize = true;
            this.lblPasswordLockCycle.Location = new System.Drawing.Point(248, 31);
            this.lblPasswordLockCycle.Name = "lblPasswordLockCycle";
            this.lblPasswordLockCycle.Size = new System.Drawing.Size(149, 12);
            this.lblPasswordLockCycle.TabIndex = 2;
            this.lblPasswordLockCycle.Text = "密码错误锁定周期(分钟)：";
            // 
            // lblPasswordErrowLock
            // 
            this.lblPasswordErrowLock.AutoSize = true;
            this.lblPasswordErrowLock.Location = new System.Drawing.Point(27, 31);
            this.lblPasswordErrowLock.Name = "lblPasswordErrowLock";
            this.lblPasswordErrowLock.Size = new System.Drawing.Size(113, 12);
            this.lblPasswordErrowLock.TabIndex = 0;
            this.lblPasswordErrowLock.Text = "密码错误锁定次数：";
            // 
            // lblAccountMinimumLength
            // 
            this.lblAccountMinimumLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAccountMinimumLength.AutoSize = true;
            this.lblAccountMinimumLength.Location = new System.Drawing.Point(296, 30);
            this.lblAccountMinimumLength.Name = "lblAccountMinimumLength";
            this.lblAccountMinimumLength.Size = new System.Drawing.Size(101, 12);
            this.lblAccountMinimumLength.TabIndex = 3;
            this.lblAccountMinimumLength.Text = "用户名最小长度：";
            // 
            // grpBruteForce
            // 
            this.grpBruteForce.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBruteForce.Controls.Add(this.nudPasswordErrowLockLimit);
            this.grpBruteForce.Controls.Add(this.nudPasswordErrowLockCycle);
            this.grpBruteForce.Controls.Add(this.lblPasswordErrowLock);
            this.grpBruteForce.Controls.Add(this.lblPasswordLockCycle);
            this.grpBruteForce.Location = new System.Drawing.Point(12, 255);
            this.grpBruteForce.Name = "grpBruteForce";
            this.grpBruteForce.Size = new System.Drawing.Size(498, 63);
            this.grpBruteForce.TabIndex = 2;
            this.grpBruteForce.TabStop = false;
            this.grpBruteForce.Text = "防暴力破解";
            // 
            // nudPasswordErrowLockLimit
            // 
            this.nudPasswordErrowLockLimit.Location = new System.Drawing.Point(140, 27);
            this.nudPasswordErrowLockLimit.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudPasswordErrowLockLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPasswordErrowLockLimit.Name = "nudPasswordErrowLockLimit";
            this.nudPasswordErrowLockLimit.Size = new System.Drawing.Size(75, 21);
            this.nudPasswordErrowLockLimit.TabIndex = 1;
            this.nudPasswordErrowLockLimit.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // nudPasswordErrowLockCycle
            // 
            this.nudPasswordErrowLockCycle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPasswordErrowLockCycle.Location = new System.Drawing.Point(404, 27);
            this.nudPasswordErrowLockCycle.Name = "nudPasswordErrowLockCycle";
            this.nudPasswordErrowLockCycle.Size = new System.Drawing.Size(75, 21);
            this.nudPasswordErrowLockCycle.TabIndex = 3;
            this.nudPasswordErrowLockCycle.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // grpAccountSecurity
            // 
            this.grpAccountSecurity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAccountSecurity.Controls.Add(this.nudAccountMinimumLength);
            this.grpAccountSecurity.Controls.Add(this.chkCheckOnLine);
            this.grpAccountSecurity.Controls.Add(this.lblAccountMinimumLength);
            this.grpAccountSecurity.Location = new System.Drawing.Point(12, 173);
            this.grpAccountSecurity.Name = "grpAccountSecurity";
            this.grpAccountSecurity.Size = new System.Drawing.Size(498, 63);
            this.grpAccountSecurity.TabIndex = 1;
            this.grpAccountSecurity.TabStop = false;
            this.grpAccountSecurity.Text = "帐户安全";
            // 
            // nudAccountMinimumLength
            // 
            this.nudAccountMinimumLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudAccountMinimumLength.Location = new System.Drawing.Point(404, 26);
            this.nudAccountMinimumLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAccountMinimumLength.Name = "nudAccountMinimumLength";
            this.nudAccountMinimumLength.Size = new System.Drawing.Size(75, 21);
            this.nudAccountMinimumLength.TabIndex = 4;
            this.nudAccountMinimumLength.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // FrmSystemSecurity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DotNet.WinForm.Properties.Resources.Head;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(519, 366);
            this.Controls.Add(this.grpAccountSecurity);
            this.Controls.Add(this.grpBruteForce);
            this.Controls.Add(this.grpPasswordSecurity);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSystemSecurity";
            this.ShowInTaskbar = true;
            this.Text = "系统安全设置";
            this.grpPasswordSecurity.ResumeLayout(false);
            this.grpPasswordSecurity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPasswordChangeCycle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPasswordMiniLength)).EndInit();
            this.grpBruteForce.ResumeLayout(false);
            this.grpBruteForce.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPasswordErrowLockLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPasswordErrowLockCycle)).EndInit();
            this.grpAccountSecurity.ResumeLayout(false);
            this.grpAccountSecurity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAccountMinimumLength)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpPasswordSecurity;
        private System.Windows.Forms.CheckBox chkServerEncryptPassword;
        private System.Windows.Forms.CheckBox chkCheckOnLine;
        private System.Windows.Forms.Label lblAccountMinimumLength;
        private System.Windows.Forms.Label lblPasswordErrowLock;
        private System.Windows.Forms.Label lblPasswordLockCycle;
        private System.Windows.Forms.Label lblPasswordMiniLength;
        private System.Windows.Forms.Label lblPasswordChangeCycle;
        private System.Windows.Forms.CheckBox chkNumericCharacters;
        private System.Windows.Forms.GroupBox grpBruteForce;
        private System.Windows.Forms.GroupBox grpAccountSecurity;
        private System.Windows.Forms.NumericUpDown nudPasswordChangeCycle;
        private System.Windows.Forms.NumericUpDown nudPasswordMiniLength;
        private System.Windows.Forms.NumericUpDown nudPasswordErrowLockLimit;
        private System.Windows.Forms.NumericUpDown nudPasswordErrowLockCycle;
        private System.Windows.Forms.NumericUpDown nudAccountMinimumLength;
    }
}