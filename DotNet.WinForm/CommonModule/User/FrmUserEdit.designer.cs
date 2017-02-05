namespace DotNet.WinForm
{
    partial class FrmUserEdit
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
            this.chkLock = new System.Windows.Forms.CheckBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblDefaultRole = new System.Windows.Forms.Label();
            this.grpUser = new System.Windows.Forms.GroupBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.cmbSecurityLevel = new System.Windows.Forms.ComboBox();
            this.lblSecurityLevel = new System.Windows.Forms.Label();
            this.dtpAllowEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpAllowStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblTimeTo = new System.Windows.Forms.Label();
            this.lblAllowTime = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpLockEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpLockStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblLockDate = new System.Windows.Forms.Label();
            this.cmbDefaultRole = new System.Windows.Forms.ComboBox();
            this.lblFullNameReq = new System.Windows.Forms.Label();
            this.lblUserNameReq = new System.Windows.Forms.Label();
            this.lblRealName = new System.Windows.Forms.Label();
            this.txtRealName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnIPLimitr = new System.Windows.Forms.Button();
            this.btnHandwrittenSignature = new System.Windows.Forms.Button();
            this.btnSetCommunicationPassword = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.grpUser.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkLock
            // 
            this.chkLock.AutoSize = true;
            this.chkLock.Location = new System.Drawing.Point(137, 273);
            this.chkLock.Name = "chkLock";
            this.chkLock.Size = new System.Drawing.Size(48, 16);
            this.chkLock.TabIndex = 22;
            this.chkLock.Text = "封锁";
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(11, 117);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(123, 12);
            this.lblCode.TabIndex = 8;
            this.lblCode.Text = "工号(编号)：";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDefaultRole
            // 
            this.lblDefaultRole.Location = new System.Drawing.Point(11, 151);
            this.lblDefaultRole.Name = "lblDefaultRole";
            this.lblDefaultRole.Size = new System.Drawing.Size(123, 12);
            this.lblDefaultRole.TabIndex = 10;
            this.lblDefaultRole.Text = "默认角色(&R)：";
            this.lblDefaultRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpUser
            // 
            this.grpUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpUser.Controls.Add(this.txtId);
            this.grpUser.Controls.Add(this.lblId);
            this.grpUser.Controls.Add(this.cmbSecurityLevel);
            this.grpUser.Controls.Add(this.lblSecurityLevel);
            this.grpUser.Controls.Add(this.dtpAllowEndTime);
            this.grpUser.Controls.Add(this.dtpAllowStartTime);
            this.grpUser.Controls.Add(this.lblTimeTo);
            this.grpUser.Controls.Add(this.lblAllowTime);
            this.grpUser.Controls.Add(this.lblDateTo);
            this.grpUser.Controls.Add(this.dtpLockEndDate);
            this.grpUser.Controls.Add(this.dtpLockStartDate);
            this.grpUser.Controls.Add(this.lblLockDate);
            this.grpUser.Controls.Add(this.cmbDefaultRole);
            this.grpUser.Controls.Add(this.lblFullNameReq);
            this.grpUser.Controls.Add(this.lblUserNameReq);
            this.grpUser.Controls.Add(this.lblRealName);
            this.grpUser.Controls.Add(this.txtRealName);
            this.grpUser.Controls.Add(this.chkLock);
            this.grpUser.Controls.Add(this.lblCode);
            this.grpUser.Controls.Add(this.lblDefaultRole);
            this.grpUser.Controls.Add(this.txtUserName);
            this.grpUser.Controls.Add(this.lblUserName);
            this.grpUser.Controls.Add(this.txtCode);
            this.grpUser.Location = new System.Drawing.Point(12, 34);
            this.grpUser.Name = "grpUser";
            this.grpUser.Padding = new System.Windows.Forms.Padding(8);
            this.grpUser.Size = new System.Drawing.Size(450, 306);
            this.grpUser.TabIndex = 0;
            this.grpUser.TabStop = false;
            this.grpUser.Text = "用户";
            // 
            // txtId
            // 
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtId.Location = new System.Drawing.Point(138, 19);
            this.txtId.MaxLength = 50;
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(288, 21);
            this.txtId.TabIndex = 1;
            this.txtId.TabStop = false;
            // 
            // lblId
            // 
            this.lblId.Location = new System.Drawing.Point(55, 22);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(79, 12);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "主键：";
            this.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbSecurityLevel
            // 
            this.cmbSecurityLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSecurityLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSecurityLevel.Location = new System.Drawing.Point(137, 174);
            this.cmbSecurityLevel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbSecurityLevel.Name = "cmbSecurityLevel";
            this.cmbSecurityLevel.Size = new System.Drawing.Size(288, 20);
            this.cmbSecurityLevel.TabIndex = 13;
            // 
            // lblSecurityLevel
            // 
            this.lblSecurityLevel.Location = new System.Drawing.Point(11, 177);
            this.lblSecurityLevel.Name = "lblSecurityLevel";
            this.lblSecurityLevel.Size = new System.Drawing.Size(123, 12);
            this.lblSecurityLevel.TabIndex = 12;
            this.lblSecurityLevel.Text = "安全级别(&S)：";
            this.lblSecurityLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpAllowEndTime
            // 
            this.dtpAllowEndTime.Checked = false;
            this.dtpAllowEndTime.CustomFormat = "HH:mm";
            this.dtpAllowEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAllowEndTime.Location = new System.Drawing.Point(302, 209);
            this.dtpAllowEndTime.Name = "dtpAllowEndTime";
            this.dtpAllowEndTime.ShowCheckBox = true;
            this.dtpAllowEndTime.ShowUpDown = true;
            this.dtpAllowEndTime.Size = new System.Drawing.Size(126, 21);
            this.dtpAllowEndTime.TabIndex = 17;
            this.dtpAllowEndTime.Value = new System.DateTime(2011, 6, 13, 17, 0, 0, 0);
            // 
            // dtpAllowStartTime
            // 
            this.dtpAllowStartTime.Checked = false;
            this.dtpAllowStartTime.CustomFormat = "HH:mm";
            this.dtpAllowStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAllowStartTime.Location = new System.Drawing.Point(137, 209);
            this.dtpAllowStartTime.Name = "dtpAllowStartTime";
            this.dtpAllowStartTime.ShowCheckBox = true;
            this.dtpAllowStartTime.ShowUpDown = true;
            this.dtpAllowStartTime.Size = new System.Drawing.Size(126, 21);
            this.dtpAllowStartTime.TabIndex = 15;
            this.dtpAllowStartTime.Value = new System.DateTime(2011, 6, 13, 8, 0, 0, 0);
            // 
            // lblTimeTo
            // 
            this.lblTimeTo.Location = new System.Drawing.Point(268, 213);
            this.lblTimeTo.Name = "lblTimeTo";
            this.lblTimeTo.Size = new System.Drawing.Size(28, 12);
            this.lblTimeTo.TabIndex = 16;
            this.lblTimeTo.Text = "至";
            this.lblTimeTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAllowTime
            // 
            this.lblAllowTime.Location = new System.Drawing.Point(11, 212);
            this.lblAllowTime.Name = "lblAllowTime";
            this.lblAllowTime.Size = new System.Drawing.Size(123, 12);
            this.lblAllowTime.TabIndex = 14;
            this.lblAllowTime.Text = "允许登录时间(&T)：";
            this.lblAllowTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDateTo
            // 
            this.lblDateTo.Location = new System.Drawing.Point(268, 243);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(28, 12);
            this.lblDateTo.TabIndex = 20;
            this.lblDateTo.Text = "至";
            this.lblDateTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpLockEndDate
            // 
            this.dtpLockEndDate.Checked = false;
            this.dtpLockEndDate.CustomFormat = "yyyy-MM-dd";
            this.dtpLockEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLockEndDate.Location = new System.Drawing.Point(302, 238);
            this.dtpLockEndDate.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpLockEndDate.MinDate = new System.DateTime(2011, 1, 1, 0, 0, 0, 0);
            this.dtpLockEndDate.Name = "dtpLockEndDate";
            this.dtpLockEndDate.ShowCheckBox = true;
            this.dtpLockEndDate.Size = new System.Drawing.Size(126, 21);
            this.dtpLockEndDate.TabIndex = 21;
            // 
            // dtpLockStartDate
            // 
            this.dtpLockStartDate.Checked = false;
            this.dtpLockStartDate.CustomFormat = "yyyy-MM-dd";
            this.dtpLockStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLockStartDate.Location = new System.Drawing.Point(137, 238);
            this.dtpLockStartDate.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpLockStartDate.MinDate = new System.DateTime(2011, 1, 1, 0, 0, 0, 0);
            this.dtpLockStartDate.Name = "dtpLockStartDate";
            this.dtpLockStartDate.ShowCheckBox = true;
            this.dtpLockStartDate.Size = new System.Drawing.Size(126, 21);
            this.dtpLockStartDate.TabIndex = 19;
            // 
            // lblLockDate
            // 
            this.lblLockDate.Location = new System.Drawing.Point(11, 243);
            this.lblLockDate.Name = "lblLockDate";
            this.lblLockDate.Size = new System.Drawing.Size(123, 12);
            this.lblLockDate.TabIndex = 18;
            this.lblLockDate.Text = "暂停(&L)：";
            this.lblLockDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDefaultRole
            // 
            this.cmbDefaultRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDefaultRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDefaultRole.Location = new System.Drawing.Point(137, 147);
            this.cmbDefaultRole.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbDefaultRole.Name = "cmbDefaultRole";
            this.cmbDefaultRole.Size = new System.Drawing.Size(288, 20);
            this.cmbDefaultRole.TabIndex = 11;
            // 
            // lblFullNameReq
            // 
            this.lblFullNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullNameReq.AutoSize = true;
            this.lblFullNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblFullNameReq.Location = new System.Drawing.Point(431, 87);
            this.lblFullNameReq.Name = "lblFullNameReq";
            this.lblFullNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblFullNameReq.TabIndex = 7;
            this.lblFullNameReq.Text = "*";
            // 
            // lblUserNameReq
            // 
            this.lblUserNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserNameReq.AutoSize = true;
            this.lblUserNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblUserNameReq.Location = new System.Drawing.Point(431, 57);
            this.lblUserNameReq.Name = "lblUserNameReq";
            this.lblUserNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblUserNameReq.TabIndex = 4;
            this.lblUserNameReq.Text = "*";
            // 
            // lblRealName
            // 
            this.lblRealName.Location = new System.Drawing.Point(11, 87);
            this.lblRealName.Name = "lblRealName";
            this.lblRealName.Size = new System.Drawing.Size(123, 12);
            this.lblRealName.TabIndex = 5;
            this.lblRealName.Text = "姓名(&N)：";
            this.lblRealName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRealName
            // 
            this.txtRealName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRealName.Location = new System.Drawing.Point(137, 82);
            this.txtRealName.MaxLength = 50;
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.Size = new System.Drawing.Size(288, 21);
            this.txtRealName.TabIndex = 6;
            this.txtRealName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtRealName_MouseDoubleClick);
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.Location = new System.Drawing.Point(137, 52);
            this.txtUserName.MaxLength = 50;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(288, 21);
            this.txtUserName.TabIndex = 3;
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(11, 57);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(123, 12);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "登录用户名(&U)：";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(137, 112);
            this.txtCode.MaxLength = 20;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(288, 21);
            this.txtCode.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(387, 354);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(300, 354);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnIPLimitr
            // 
            this.btnIPLimitr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIPLimitr.Location = new System.Drawing.Point(149, 3);
            this.btnIPLimitr.Name = "btnIPLimitr";
            this.btnIPLimitr.Size = new System.Drawing.Size(138, 23);
            this.btnIPLimitr.TabIndex = 0;
            this.btnIPLimitr.Text = "IP地址限制(&I)...";
            this.btnIPLimitr.Visible = false;
            this.btnIPLimitr.Click += new System.EventHandler(this.btnIPLimitr_Click);
            // 
            // btnHandwrittenSignature
            // 
            this.btnHandwrittenSignature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHandwrittenSignature.Location = new System.Drawing.Point(11, 354);
            this.btnHandwrittenSignature.Name = "btnHandwrittenSignature";
            this.btnHandwrittenSignature.Size = new System.Drawing.Size(138, 23);
            this.btnHandwrittenSignature.TabIndex = 1;
            this.btnHandwrittenSignature.Text = "用户签名(&D)...";
            this.btnHandwrittenSignature.Click += new System.EventHandler(this.btnSignature_Click);
            // 
            // btnSetCommunicationPassword
            // 
            this.btnSetCommunicationPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetCommunicationPassword.Location = new System.Drawing.Point(5, 3);
            this.btnSetCommunicationPassword.Name = "btnSetCommunicationPassword";
            this.btnSetCommunicationPassword.Size = new System.Drawing.Size(138, 23);
            this.btnSetCommunicationPassword.TabIndex = 1;
            this.btnSetCommunicationPassword.Text = "设置通讯密码(&P)...";
            this.btnSetCommunicationPassword.Visible = false;
            this.btnSetCommunicationPassword.Click += new System.EventHandler(this.btnSetCommunicationPassword_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnIPLimitr);
            this.flowLayoutPanel1.Controls.Add(this.btnSetCommunicationPassword);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(170, 7);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(290, 29);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // FrmUserEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(474, 388);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnHandwrittenSignature);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpUser);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUserEdit";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "用户属性";
            this.grpUser.ResumeLayout(false);
            this.grpUser.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkLock;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblDefaultRole;
        private System.Windows.Forms.GroupBox grpUser;
        private System.Windows.Forms.Label lblRealName;
        private System.Windows.Forms.TextBox txtRealName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.HelpProvider helpProvider;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblUserNameReq;
        private System.Windows.Forms.Label lblFullNameReq;
        private System.Windows.Forms.ComboBox cmbDefaultRole;
        private System.Windows.Forms.Label lblLockDate;
        private System.Windows.Forms.DateTimePicker dtpLockEndDate;
        private System.Windows.Forms.DateTimePicker dtpLockStartDate;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Label lblAllowTime;
        private System.Windows.Forms.Label lblTimeTo;
        private System.Windows.Forms.DateTimePicker dtpAllowStartTime;
        private System.Windows.Forms.DateTimePicker dtpAllowEndTime;
        private System.Windows.Forms.Button btnIPLimitr;
        private System.Windows.Forms.ComboBox cmbSecurityLevel;
        private System.Windows.Forms.Label lblSecurityLevel;
        private System.Windows.Forms.Button btnHandwrittenSignature;
        private System.Windows.Forms.Button btnSetCommunicationPassword;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
    }
}