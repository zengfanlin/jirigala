namespace DotNet.WinForm
{
    partial class FrmScreenLock
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
            this.cmbLockWaitMinute = new System.Windows.Forms.ComboBox();
            this.lblWait = new System.Windows.Forms.Label();
            this.labPasswordReq = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.ckbIsLock = new System.Windows.Forms.CheckBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.grpLogOn.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLogOn
            // 
            this.grpLogOn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLogOn.Controls.Add(this.cmbLockWaitMinute);
            this.grpLogOn.Controls.Add(this.lblWait);
            this.grpLogOn.Controls.Add(this.labPasswordReq);
            this.grpLogOn.Controls.Add(this.txtPassword);
            this.grpLogOn.Controls.Add(this.lblPassword);
            this.grpLogOn.Location = new System.Drawing.Point(8, 61);
            this.grpLogOn.Name = "grpLogOn";
            this.grpLogOn.Size = new System.Drawing.Size(449, 133);
            this.grpLogOn.TabIndex = 1;
            this.grpLogOn.TabStop = false;
            this.grpLogOn.Text = "锁屏";
            // 
            // cmbLockWaitMinute
            // 
            this.cmbLockWaitMinute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLockWaitMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLockWaitMinute.FormattingEnabled = true;
            this.cmbLockWaitMinute.Location = new System.Drawing.Point(339, 83);
            this.cmbLockWaitMinute.Name = "cmbLockWaitMinute";
            this.cmbLockWaitMinute.Size = new System.Drawing.Size(67, 20);
            this.cmbLockWaitMinute.TabIndex = 5;
            this.cmbLockWaitMinute.SelectedIndexChanged += new System.EventHandler(this.cmbLockWaitMinute_SelectedIndexChanged);
            // 
            // lblWait
            // 
            this.lblWait.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWait.AutoSize = true;
            this.lblWait.Location = new System.Drawing.Point(278, 86);
            this.lblWait.Name = "lblWait";
            this.lblWait.Size = new System.Drawing.Size(65, 12);
            this.lblWait.TabIndex = 3;
            this.lblWait.Text = "閒置時間：";
            // 
            // labPasswordReq
            // 
            this.labPasswordReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labPasswordReq.AutoSize = true;
            this.labPasswordReq.ForeColor = System.Drawing.Color.Red;
            this.labPasswordReq.Location = new System.Drawing.Point(416, 50);
            this.labPasswordReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labPasswordReq.Name = "labPasswordReq";
            this.labPasswordReq.Size = new System.Drawing.Size(11, 12);
            this.labPasswordReq.TabIndex = 2;
            this.labPasswordReq.Text = "*";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(69, 46);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(337, 21);
            this.txtPassword.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(5, 50);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(64, 12);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "密码(&P)：";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ckbIsLock
            // 
            this.ckbIsLock.AutoSize = true;
            this.ckbIsLock.Checked = true;
            this.ckbIsLock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbIsLock.Location = new System.Drawing.Point(8, 204);
            this.ckbIsLock.Name = "ckbIsLock";
            this.ckbIsLock.Size = new System.Drawing.Size(96, 16);
            this.ckbIsLock.TabIndex = 2;
            this.ckbIsLock.Text = "下次自动锁定";
            this.ckbIsLock.UseVisualStyleBackColor = true;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(272, 25);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(185, 12);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "请输入登录系统的密码解除屏幕。";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(348, 200);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(110, 23);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "解屏(&L)";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // FrmScreenLock
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackgroundImage = global::DotNet.WinForm.Properties.Resources.Head;
            this.ClientSize = new System.Drawing.Size(469, 227);
            this.ControlBox = false;
            this.Controls.Add(this.grpLogOn);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.ckbIsLock);
            this.Controls.Add(this.lblMessage);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmScreenLock";
            this.ShowInTaskbar = true;
            this.Text = "锁屏";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmScreenLock_FormClosing);
            this.grpLogOn.ResumeLayout(false);
            this.grpLogOn.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLogOn;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label labPasswordReq;
        private System.Windows.Forms.Label lblWait;
        private System.Windows.Forms.CheckBox ckbIsLock;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.ComboBox cmbLockWaitMinute;
    }
}