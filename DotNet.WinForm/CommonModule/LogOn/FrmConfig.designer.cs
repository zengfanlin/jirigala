namespace DotNet.WinForm
{
    partial class FrmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfig));
            this.txtWorkFlowDbConnection = new System.Windows.Forms.TextBox();
            this.lblWorkFlowDbConnection = new System.Windows.Forms.Label();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.chkEncryptDbConnection = new System.Windows.Forms.CheckBox();
            this.cmbUserCenterDbDbType = new System.Windows.Forms.ComboBox();
            this.txtUserCenterDbConnection = new System.Windows.Forms.TextBox();
            this.txtBusinessDbConnection = new System.Windows.Forms.TextBox();
            this.lblUserCenterDbConnection = new System.Windows.Forms.Label();
            this.lblBusinessDbConnection = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tcConfirm = new System.Windows.Forms.TabControl();
            this.tpClient = new System.Windows.Forms.TabPage();
            this.btnTabsMainForm = new System.Windows.Forms.Button();
            this.btnSDIMainForm = new System.Windows.Forms.Button();
            this.lblService = new System.Windows.Forms.Label();
            this.cmbService = new System.Windows.Forms.ComboBox();
            this.chkUseMessage = new System.Windows.Forms.CheckBox();
            this.chbAutoLogOn = new System.Windows.Forms.CheckBox();
            this.txtLogOnForm = new System.Windows.Forms.TextBox();
            this.lblLogOnForm = new System.Windows.Forms.Label();
            this.txtMainForm = new System.Windows.Forms.TextBox();
            this.lblMainForm = new System.Windows.Forms.Label();
            this.chkClientEncryptPassword = new System.Windows.Forms.CheckBox();
            this.chkRememberPassword = new System.Windows.Forms.CheckBox();
            this.cmbCurrentLanguage = new System.Windows.Forms.ComboBox();
            this.lblCurrentLanguage = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.labUserNameReq = new System.Windows.Forms.Label();
            this.labPasswordReq = new System.Windows.Forms.Label();
            this.txtClientPassword = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tpServer = new System.Windows.Forms.TabPage();
            this.chkUseAuthorizationScope = new System.Windows.Forms.CheckBox();
            this.btnSetWorkFlowDb = new System.Windows.Forms.Button();
            this.btnSetBusinessDb = new System.Windows.Forms.Button();
            this.btnSetUserCenter = new System.Windows.Forms.Button();
            this.chkWorkFlow = new System.Windows.Forms.CheckBox();
            this.chkUseOrganizePermission = new System.Windows.Forms.CheckBox();
            this.btnSystemSecurity = new System.Windows.Forms.Button();
            this.chkUseTableScopePermission = new System.Windows.Forms.CheckBox();
            this.cmbWorkFlowDbDbType = new System.Windows.Forms.ComboBox();
            this.cmbBusinessDbDbType = new System.Windows.Forms.ComboBox();
            this.nupOnLineLimit = new System.Windows.Forms.NumericUpDown();
            this.lblOnLineLimit = new System.Windows.Forms.Label();
            this.chkUseUserPermission = new System.Windows.Forms.CheckBox();
            this.chkUseTableColumnPermission = new System.Windows.Forms.CheckBox();
            this.chkUsePermissionScope = new System.Windows.Forms.CheckBox();
            this.chkUseModulePermission = new System.Windows.Forms.CheckBox();
            this.chkAllowUserRegister = new System.Windows.Forms.CheckBox();
            this.chkRecordLog = new System.Windows.Forms.CheckBox();
            this.txtCustomerCompanyName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCustomerCompanyName = new System.Windows.Forms.Label();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.tcConfirm.SuspendLayout();
            this.tpClient.SuspendLayout();
            this.tpServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupOnLineLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // txtWorkFlowDbConnection
            // 
            this.txtWorkFlowDbConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkFlowDbConnection.Location = new System.Drawing.Point(259, 261);
            this.txtWorkFlowDbConnection.MaxLength = 200;
            this.txtWorkFlowDbConnection.Name = "txtWorkFlowDbConnection";
            this.txtWorkFlowDbConnection.Size = new System.Drawing.Size(492, 21);
            this.txtWorkFlowDbConnection.TabIndex = 20;
            this.txtWorkFlowDbConnection.Visible = false;
            // 
            // lblWorkFlowDbConnection
            // 
            this.lblWorkFlowDbConnection.Location = new System.Drawing.Point(8, 263);
            this.lblWorkFlowDbConnection.Name = "lblWorkFlowDbConnection";
            this.lblWorkFlowDbConnection.Size = new System.Drawing.Size(138, 15);
            this.lblWorkFlowDbConnection.TabIndex = 18;
            this.lblWorkFlowDbConnection.Text = "工作流数据库连接(&W)：";
            this.lblWorkFlowDbConnection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblWorkFlowDbConnection.Visible = false;
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDecrypt.Enabled = false;
            this.btnDecrypt.Location = new System.Drawing.Point(707, 145);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnDecrypt.TabIndex = 22;
            this.btnDecrypt.Text = "解密(&D)";
            this.btnDecrypt.Visible = false;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEncrypt.Location = new System.Drawing.Point(707, 172);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 23;
            this.btnEncrypt.Text = "加密(&E)";
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // chkEncryptDbConnection
            // 
            this.chkEncryptDbConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEncryptDbConnection.AutoSize = true;
            this.chkEncryptDbConnection.Location = new System.Drawing.Point(542, 179);
            this.chkEncryptDbConnection.Name = "chkEncryptDbConnection";
            this.chkEncryptDbConnection.Size = new System.Drawing.Size(120, 16);
            this.chkEncryptDbConnection.TabIndex = 21;
            this.chkEncryptDbConnection.Text = "加密数据库连接串";
            this.chkEncryptDbConnection.UseVisualStyleBackColor = true;
            // 
            // cmbUserCenterDbDbType
            // 
            this.cmbUserCenterDbDbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserCenterDbDbType.FormattingEnabled = true;
            this.cmbUserCenterDbDbType.Location = new System.Drawing.Point(148, 202);
            this.cmbUserCenterDbDbType.Name = "cmbUserCenterDbDbType";
            this.cmbUserCenterDbDbType.Size = new System.Drawing.Size(105, 20);
            this.cmbUserCenterDbDbType.TabIndex = 12;
            // 
            // txtUserCenterDbConnection
            // 
            this.txtUserCenterDbConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserCenterDbConnection.Location = new System.Drawing.Point(259, 203);
            this.txtUserCenterDbConnection.MaxLength = 200;
            this.txtUserCenterDbConnection.Name = "txtUserCenterDbConnection";
            this.txtUserCenterDbConnection.Size = new System.Drawing.Size(492, 21);
            this.txtUserCenterDbConnection.TabIndex = 13;
            // 
            // txtBusinessDbConnection
            // 
            this.txtBusinessDbConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBusinessDbConnection.Location = new System.Drawing.Point(259, 232);
            this.txtBusinessDbConnection.MaxLength = 200;
            this.txtBusinessDbConnection.Name = "txtBusinessDbConnection";
            this.txtBusinessDbConnection.Size = new System.Drawing.Size(492, 21);
            this.txtBusinessDbConnection.TabIndex = 17;
            // 
            // lblUserCenterDbConnection
            // 
            this.lblUserCenterDbConnection.Location = new System.Drawing.Point(8, 205);
            this.lblUserCenterDbConnection.Name = "lblUserCenterDbConnection";
            this.lblUserCenterDbConnection.Size = new System.Drawing.Size(138, 15);
            this.lblUserCenterDbConnection.TabIndex = 11;
            this.lblUserCenterDbConnection.Text = "用户数据库连接(&C)：";
            this.lblUserCenterDbConnection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBusinessDbConnection
            // 
            this.lblBusinessDbConnection.Location = new System.Drawing.Point(8, 234);
            this.lblBusinessDbConnection.Name = "lblBusinessDbConnection";
            this.lblBusinessDbConnection.Size = new System.Drawing.Size(138, 15);
            this.lblBusinessDbConnection.TabIndex = 15;
            this.lblBusinessDbConnection.Text = "业务数据库连接(&B)：";
            this.lblBusinessDbConnection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Location = new System.Drawing.Point(655, 392);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(78, 23);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "保存(&S)";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(737, 392);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tcConfirm
            // 
            this.tcConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcConfirm.Controls.Add(this.tpClient);
            this.tcConfirm.Controls.Add(this.tpServer);
            this.tcConfirm.Location = new System.Drawing.Point(9, 49);
            this.tcConfirm.Name = "tcConfirm";
            this.tcConfirm.SelectedIndex = 0;
            this.tcConfirm.Size = new System.Drawing.Size(810, 333);
            this.tcConfirm.TabIndex = 0;
            // 
            // tpClient
            // 
            this.tpClient.Controls.Add(this.btnTabsMainForm);
            this.tpClient.Controls.Add(this.btnSDIMainForm);
            this.tpClient.Controls.Add(this.lblService);
            this.tpClient.Controls.Add(this.cmbService);
            this.tpClient.Controls.Add(this.chkUseMessage);
            this.tpClient.Controls.Add(this.chbAutoLogOn);
            this.tpClient.Controls.Add(this.txtLogOnForm);
            this.tpClient.Controls.Add(this.lblLogOnForm);
            this.tpClient.Controls.Add(this.txtMainForm);
            this.tpClient.Controls.Add(this.lblMainForm);
            this.tpClient.Controls.Add(this.chkClientEncryptPassword);
            this.tpClient.Controls.Add(this.chkRememberPassword);
            this.tpClient.Controls.Add(this.cmbCurrentLanguage);
            this.tpClient.Controls.Add(this.lblCurrentLanguage);
            this.tpClient.Controls.Add(this.txtUser);
            this.tpClient.Controls.Add(this.labUserNameReq);
            this.tpClient.Controls.Add(this.labPasswordReq);
            this.tpClient.Controls.Add(this.txtClientPassword);
            this.tpClient.Controls.Add(this.lblUserName);
            this.tpClient.Controls.Add(this.lblPassword);
            this.tpClient.Location = new System.Drawing.Point(4, 22);
            this.tpClient.Name = "tpClient";
            this.tpClient.Padding = new System.Windows.Forms.Padding(3);
            this.tpClient.Size = new System.Drawing.Size(802, 307);
            this.tpClient.TabIndex = 0;
            this.tpClient.Text = "客户端配置";
            this.tpClient.UseVisualStyleBackColor = true;
            // 
            // btnTabsMainForm
            // 
            this.btnTabsMainForm.Location = new System.Drawing.Point(564, 190);
            this.btnTabsMainForm.Name = "btnTabsMainForm";
            this.btnTabsMainForm.Size = new System.Drawing.Size(145, 23);
            this.btnTabsMainForm.TabIndex = 15;
            this.btnTabsMainForm.Text = "主应用程序方式运行";
            this.btnTabsMainForm.UseVisualStyleBackColor = true;
            this.btnTabsMainForm.Click += new System.EventHandler(this.btnMainForm_Click);
            // 
            // btnSDIMainForm
            // 
            this.btnSDIMainForm.Location = new System.Drawing.Point(411, 190);
            this.btnSDIMainForm.Name = "btnSDIMainForm";
            this.btnSDIMainForm.Size = new System.Drawing.Size(145, 23);
            this.btnSDIMainForm.TabIndex = 14;
            this.btnSDIMainForm.Text = "系统工具方式运行";
            this.btnSDIMainForm.UseVisualStyleBackColor = true;
            this.btnSDIMainForm.Click += new System.EventHandler(this.btnMainForm_Click);
            // 
            // lblService
            // 
            this.lblService.Location = new System.Drawing.Point(17, 255);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(138, 15);
            this.lblService.TabIndex = 18;
            this.lblService.Text = "运行模式(&R)：";
            this.lblService.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbService
            // 
            this.cmbService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbService.FormattingEnabled = true;
            this.cmbService.Location = new System.Drawing.Point(160, 253);
            this.cmbService.Name = "cmbService";
            this.cmbService.Size = new System.Drawing.Size(224, 20);
            this.cmbService.TabIndex = 19;
            // 
            // chkUseMessage
            // 
            this.chkUseMessage.AutoSize = true;
            this.chkUseMessage.Location = new System.Drawing.Point(287, 153);
            this.chkUseMessage.Name = "chkUseMessage";
            this.chkUseMessage.Size = new System.Drawing.Size(96, 16);
            this.chkUseMessage.TabIndex = 10;
            this.chkUseMessage.Text = "启用即时通讯";
            this.chkUseMessage.UseVisualStyleBackColor = true;
            // 
            // chbAutoLogOn
            // 
            this.chbAutoLogOn.AutoSize = true;
            this.chbAutoLogOn.Location = new System.Drawing.Point(160, 153);
            this.chbAutoLogOn.Name = "chbAutoLogOn";
            this.chbAutoLogOn.Size = new System.Drawing.Size(72, 16);
            this.chbAutoLogOn.TabIndex = 9;
            this.chbAutoLogOn.Text = "自动登录";
            this.chbAutoLogOn.UseVisualStyleBackColor = true;
            // 
            // txtLogOnForm
            // 
            this.txtLogOnForm.Location = new System.Drawing.Point(160, 223);
            this.txtLogOnForm.MaxLength = 20;
            this.txtLogOnForm.Name = "txtLogOnForm";
            this.txtLogOnForm.Size = new System.Drawing.Size(224, 21);
            this.txtLogOnForm.TabIndex = 17;
            // 
            // lblLogOnForm
            // 
            this.lblLogOnForm.Location = new System.Drawing.Point(17, 224);
            this.lblLogOnForm.Name = "lblLogOnForm";
            this.lblLogOnForm.Size = new System.Drawing.Size(138, 15);
            this.lblLogOnForm.TabIndex = 16;
            this.lblLogOnForm.Text = "系统登录窗体(&F)：";
            this.lblLogOnForm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMainForm
            // 
            this.txtMainForm.Location = new System.Drawing.Point(160, 193);
            this.txtMainForm.MaxLength = 20;
            this.txtMainForm.Name = "txtMainForm";
            this.txtMainForm.Size = new System.Drawing.Size(224, 21);
            this.txtMainForm.TabIndex = 13;
            // 
            // lblMainForm
            // 
            this.lblMainForm.Location = new System.Drawing.Point(17, 194);
            this.lblMainForm.Name = "lblMainForm";
            this.lblMainForm.Size = new System.Drawing.Size(138, 15);
            this.lblMainForm.TabIndex = 12;
            this.lblMainForm.Text = "系统主窗体(&M)：";
            this.lblMainForm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkClientEncryptPassword
            // 
            this.chkClientEncryptPassword.AutoSize = true;
            this.chkClientEncryptPassword.Location = new System.Drawing.Point(160, 120);
            this.chkClientEncryptPassword.Name = "chkClientEncryptPassword";
            this.chkClientEncryptPassword.Size = new System.Drawing.Size(96, 16);
            this.chkClientEncryptPassword.TabIndex = 11;
            this.chkClientEncryptPassword.Text = "加密存储密码";
            this.chkClientEncryptPassword.UseVisualStyleBackColor = true;
            // 
            // chkRememberPassword
            // 
            this.chkRememberPassword.AutoSize = true;
            this.chkRememberPassword.Location = new System.Drawing.Point(287, 120);
            this.chkRememberPassword.Name = "chkRememberPassword";
            this.chkRememberPassword.Size = new System.Drawing.Size(72, 16);
            this.chkRememberPassword.TabIndex = 8;
            this.chkRememberPassword.Text = "记住密码";
            this.chkRememberPassword.UseVisualStyleBackColor = true;
            // 
            // cmbCurrentLanguage
            // 
            this.cmbCurrentLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrentLanguage.FormattingEnabled = true;
            this.cmbCurrentLanguage.Location = new System.Drawing.Point(160, 77);
            this.cmbCurrentLanguage.Name = "cmbCurrentLanguage";
            this.cmbCurrentLanguage.Size = new System.Drawing.Size(224, 20);
            this.cmbCurrentLanguage.TabIndex = 7;
            this.cmbCurrentLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbCurrentLanguage_SelectedIndexChanged);
            // 
            // lblCurrentLanguage
            // 
            this.lblCurrentLanguage.Location = new System.Drawing.Point(17, 79);
            this.lblCurrentLanguage.Name = "lblCurrentLanguage";
            this.lblCurrentLanguage.Size = new System.Drawing.Size(138, 15);
            this.lblCurrentLanguage.TabIndex = 6;
            this.lblCurrentLanguage.Text = "语言(&L)：";
            this.lblCurrentLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(160, 17);
            this.txtUser.MaxLength = 20;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(224, 21);
            this.txtUser.TabIndex = 1;
            // 
            // labUserNameReq
            // 
            this.labUserNameReq.AutoSize = true;
            this.labUserNameReq.ForeColor = System.Drawing.Color.Red;
            this.labUserNameReq.Location = new System.Drawing.Point(392, 21);
            this.labUserNameReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labUserNameReq.Name = "labUserNameReq";
            this.labUserNameReq.Size = new System.Drawing.Size(11, 12);
            this.labUserNameReq.TabIndex = 2;
            this.labUserNameReq.Text = "*";
            // 
            // labPasswordReq
            // 
            this.labPasswordReq.AutoSize = true;
            this.labPasswordReq.ForeColor = System.Drawing.Color.Red;
            this.labPasswordReq.Location = new System.Drawing.Point(392, 52);
            this.labPasswordReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labPasswordReq.Name = "labPasswordReq";
            this.labPasswordReq.Size = new System.Drawing.Size(11, 12);
            this.labPasswordReq.TabIndex = 5;
            this.labPasswordReq.Text = "*";
            // 
            // txtClientPassword
            // 
            this.txtClientPassword.Location = new System.Drawing.Point(160, 47);
            this.txtClientPassword.MaxLength = 20;
            this.txtClientPassword.Name = "txtClientPassword";
            this.txtClientPassword.PasswordChar = '*';
            this.txtClientPassword.Size = new System.Drawing.Size(224, 21);
            this.txtClientPassword.TabIndex = 4;
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(17, 20);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(138, 15);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "用户名(&U)：";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(17, 50);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(138, 15);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "密码(&P)：";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tpServer
            // 
            this.tpServer.Controls.Add(this.chkUseAuthorizationScope);
            this.tpServer.Controls.Add(this.btnSetWorkFlowDb);
            this.tpServer.Controls.Add(this.btnSetBusinessDb);
            this.tpServer.Controls.Add(this.btnSetUserCenter);
            this.tpServer.Controls.Add(this.chkWorkFlow);
            this.tpServer.Controls.Add(this.chkUseOrganizePermission);
            this.tpServer.Controls.Add(this.btnSystemSecurity);
            this.tpServer.Controls.Add(this.chkUseTableScopePermission);
            this.tpServer.Controls.Add(this.cmbWorkFlowDbDbType);
            this.tpServer.Controls.Add(this.cmbBusinessDbDbType);
            this.tpServer.Controls.Add(this.nupOnLineLimit);
            this.tpServer.Controls.Add(this.lblOnLineLimit);
            this.tpServer.Controls.Add(this.txtWorkFlowDbConnection);
            this.tpServer.Controls.Add(this.lblWorkFlowDbConnection);
            this.tpServer.Controls.Add(this.chkUseUserPermission);
            this.tpServer.Controls.Add(this.lblBusinessDbConnection);
            this.tpServer.Controls.Add(this.chkEncryptDbConnection);
            this.tpServer.Controls.Add(this.lblUserCenterDbConnection);
            this.tpServer.Controls.Add(this.chkUseTableColumnPermission);
            this.tpServer.Controls.Add(this.txtBusinessDbConnection);
            this.tpServer.Controls.Add(this.chkUsePermissionScope);
            this.tpServer.Controls.Add(this.txtUserCenterDbConnection);
            this.tpServer.Controls.Add(this.chkUseModulePermission);
            this.tpServer.Controls.Add(this.btnDecrypt);
            this.tpServer.Controls.Add(this.chkAllowUserRegister);
            this.tpServer.Controls.Add(this.chkRecordLog);
            this.tpServer.Controls.Add(this.btnEncrypt);
            this.tpServer.Controls.Add(this.cmbUserCenterDbDbType);
            this.tpServer.Location = new System.Drawing.Point(4, 22);
            this.tpServer.Name = "tpServer";
            this.tpServer.Padding = new System.Windows.Forms.Padding(3);
            this.tpServer.Size = new System.Drawing.Size(802, 307);
            this.tpServer.TabIndex = 1;
            this.tpServer.Text = "服务器端配置";
            this.tpServer.UseVisualStyleBackColor = true;
            // 
            // chkUseAuthorizationScope
            // 
            this.chkUseAuthorizationScope.AutoSize = true;
            this.chkUseAuthorizationScope.Location = new System.Drawing.Point(616, 99);
            this.chkUseAuthorizationScope.Name = "chkUseAuthorizationScope";
            this.chkUseAuthorizationScope.Size = new System.Drawing.Size(96, 16);
            this.chkUseAuthorizationScope.TabIndex = 35;
            this.chkUseAuthorizationScope.Text = "启用授权范围";
            this.chkUseAuthorizationScope.UseVisualStyleBackColor = true;
            // 
            // btnSetWorkFlowDb
            // 
            this.btnSetWorkFlowDb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetWorkFlowDb.Location = new System.Drawing.Point(757, 261);
            this.btnSetWorkFlowDb.Name = "btnSetWorkFlowDb";
            this.btnSetWorkFlowDb.Size = new System.Drawing.Size(24, 23);
            this.btnSetWorkFlowDb.TabIndex = 34;
            this.btnSetWorkFlowDb.UseVisualStyleBackColor = true;
            this.btnSetWorkFlowDb.Click += new System.EventHandler(this.btnSetWorkFlowDb_Click);
            // 
            // btnSetBusinessDb
            // 
            this.btnSetBusinessDb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetBusinessDb.Location = new System.Drawing.Point(757, 232);
            this.btnSetBusinessDb.Name = "btnSetBusinessDb";
            this.btnSetBusinessDb.Size = new System.Drawing.Size(24, 23);
            this.btnSetBusinessDb.TabIndex = 33;
            this.btnSetBusinessDb.UseVisualStyleBackColor = true;
            this.btnSetBusinessDb.Click += new System.EventHandler(this.btnSetBusinessDb_Click);
            // 
            // btnSetUserCenter
            // 
            this.btnSetUserCenter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetUserCenter.Location = new System.Drawing.Point(757, 203);
            this.btnSetUserCenter.Name = "btnSetUserCenter";
            this.btnSetUserCenter.Size = new System.Drawing.Size(24, 23);
            this.btnSetUserCenter.TabIndex = 32;
            this.btnSetUserCenter.UseVisualStyleBackColor = true;
            this.btnSetUserCenter.Click += new System.EventHandler(this.btnSetUserCenter_Click);
            // 
            // chkWorkFlow
            // 
            this.chkWorkFlow.AutoSize = true;
            this.chkWorkFlow.Location = new System.Drawing.Point(436, 32);
            this.chkWorkFlow.Name = "chkWorkFlow";
            this.chkWorkFlow.Size = new System.Drawing.Size(120, 16);
            this.chkWorkFlow.TabIndex = 2;
            this.chkWorkFlow.Text = "启用行政审批流程";
            this.chkWorkFlow.UseVisualStyleBackColor = true;
            // 
            // chkUseOrganizePermission
            // 
            this.chkUseOrganizePermission.AutoSize = true;
            this.chkUseOrganizePermission.Location = new System.Drawing.Point(436, 65);
            this.chkUseOrganizePermission.Name = "chkUseOrganizePermission";
            this.chkUseOrganizePermission.Size = new System.Drawing.Size(120, 16);
            this.chkUseOrganizePermission.TabIndex = 5;
            this.chkUseOrganizePermission.Text = "启用组织机构授权";
            this.chkUseOrganizePermission.UseVisualStyleBackColor = true;
            // 
            // btnSystemSecurity
            // 
            this.btnSystemSecurity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSystemSecurity.Enabled = false;
            this.btnSystemSecurity.Location = new System.Drawing.Point(636, 25);
            this.btnSystemSecurity.Name = "btnSystemSecurity";
            this.btnSystemSecurity.Size = new System.Drawing.Size(145, 23);
            this.btnSystemSecurity.TabIndex = 0;
            this.btnSystemSecurity.Text = "系统安全设置...";
            this.btnSystemSecurity.UseVisualStyleBackColor = true;
            this.btnSystemSecurity.Visible = false;
            this.btnSystemSecurity.Click += new System.EventHandler(this.btnSystemSecurity_Click);
            // 
            // chkUseTableScopePermission
            // 
            this.chkUseTableScopePermission.AutoSize = true;
            this.chkUseTableScopePermission.Location = new System.Drawing.Point(244, 99);
            this.chkUseTableScopePermission.Name = "chkUseTableScopePermission";
            this.chkUseTableScopePermission.Size = new System.Drawing.Size(108, 16);
            this.chkUseTableScopePermission.TabIndex = 7;
            this.chkUseTableScopePermission.Text = "启用表约束条件";
            this.chkUseTableScopePermission.UseVisualStyleBackColor = true;
            // 
            // cmbWorkFlowDbDbType
            // 
            this.cmbWorkFlowDbDbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkFlowDbDbType.FormattingEnabled = true;
            this.cmbWorkFlowDbDbType.Location = new System.Drawing.Point(148, 261);
            this.cmbWorkFlowDbDbType.Name = "cmbWorkFlowDbDbType";
            this.cmbWorkFlowDbDbType.Size = new System.Drawing.Size(105, 20);
            this.cmbWorkFlowDbDbType.TabIndex = 19;
            this.cmbWorkFlowDbDbType.Visible = false;
            // 
            // cmbBusinessDbDbType
            // 
            this.cmbBusinessDbDbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusinessDbDbType.FormattingEnabled = true;
            this.cmbBusinessDbDbType.Location = new System.Drawing.Point(148, 232);
            this.cmbBusinessDbDbType.Name = "cmbBusinessDbDbType";
            this.cmbBusinessDbDbType.Size = new System.Drawing.Size(105, 20);
            this.cmbBusinessDbDbType.TabIndex = 16;
            // 
            // nupOnLineLimit
            // 
            this.nupOnLineLimit.Location = new System.Drawing.Point(152, 146);
            this.nupOnLineLimit.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nupOnLineLimit.Name = "nupOnLineLimit";
            this.nupOnLineLimit.Size = new System.Drawing.Size(64, 21);
            this.nupOnLineLimit.TabIndex = 10;
            this.nupOnLineLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nupOnLineLimit.ValueChanged += new System.EventHandler(this.nupOnLineLimit_ValueChanged);
            // 
            // lblOnLineLimit
            // 
            this.lblOnLineLimit.Location = new System.Drawing.Point(8, 148);
            this.lblOnLineLimit.Name = "lblOnLineLimit";
            this.lblOnLineLimit.Size = new System.Drawing.Size(138, 15);
            this.lblOnLineLimit.TabIndex = 9;
            this.lblOnLineLimit.Text = "在线用户数限制：";
            this.lblOnLineLimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkUseUserPermission
            // 
            this.chkUseUserPermission.AutoSize = true;
            this.chkUseUserPermission.Location = new System.Drawing.Point(56, 65);
            this.chkUseUserPermission.Name = "chkUseUserPermission";
            this.chkUseUserPermission.Size = new System.Drawing.Size(108, 16);
            this.chkUseUserPermission.TabIndex = 3;
            this.chkUseUserPermission.Text = "启用按用户授权";
            this.chkUseUserPermission.UseVisualStyleBackColor = true;
            // 
            // chkUseTableColumnPermission
            // 
            this.chkUseTableColumnPermission.AutoSize = true;
            this.chkUseTableColumnPermission.Location = new System.Drawing.Point(56, 99);
            this.chkUseTableColumnPermission.Name = "chkUseTableColumnPermission";
            this.chkUseTableColumnPermission.Size = new System.Drawing.Size(108, 16);
            this.chkUseTableColumnPermission.TabIndex = 6;
            this.chkUseTableColumnPermission.Text = "启用表字段权限";
            this.chkUseTableColumnPermission.UseVisualStyleBackColor = true;
            // 
            // chkUsePermissionScope
            // 
            this.chkUsePermissionScope.AutoSize = true;
            this.chkUsePermissionScope.Location = new System.Drawing.Point(436, 99);
            this.chkUsePermissionScope.Name = "chkUsePermissionScope";
            this.chkUsePermissionScope.Size = new System.Drawing.Size(96, 16);
            this.chkUsePermissionScope.TabIndex = 8;
            this.chkUsePermissionScope.Text = "启用权限范围";
            this.chkUsePermissionScope.UseVisualStyleBackColor = true;
            // 
            // chkUseModulePermission
            // 
            this.chkUseModulePermission.AutoSize = true;
            this.chkUseModulePermission.Location = new System.Drawing.Point(244, 65);
            this.chkUseModulePermission.Name = "chkUseModulePermission";
            this.chkUseModulePermission.Size = new System.Drawing.Size(120, 16);
            this.chkUseModulePermission.TabIndex = 4;
            this.chkUseModulePermission.Text = "启用模块菜单权限";
            this.chkUseModulePermission.UseVisualStyleBackColor = true;
            // 
            // chkAllowUserRegister
            // 
            this.chkAllowUserRegister.AutoSize = true;
            this.chkAllowUserRegister.Location = new System.Drawing.Point(56, 32);
            this.chkAllowUserRegister.Name = "chkAllowUserRegister";
            this.chkAllowUserRegister.Size = new System.Drawing.Size(96, 16);
            this.chkAllowUserRegister.TabIndex = 0;
            this.chkAllowUserRegister.Text = "允许用户注册";
            this.chkAllowUserRegister.UseVisualStyleBackColor = true;
            // 
            // chkRecordLog
            // 
            this.chkRecordLog.AutoSize = true;
            this.chkRecordLog.Location = new System.Drawing.Point(244, 32);
            this.chkRecordLog.Name = "chkRecordLog";
            this.chkRecordLog.Size = new System.Drawing.Size(96, 16);
            this.chkRecordLog.TabIndex = 1;
            this.chkRecordLog.Text = "记录系统日志";
            this.chkRecordLog.UseVisualStyleBackColor = true;
            // 
            // txtCustomerCompanyName
            // 
            this.txtCustomerCompanyName.Location = new System.Drawing.Point(160, 12);
            this.txtCustomerCompanyName.MaxLength = 100;
            this.txtCustomerCompanyName.Name = "txtCustomerCompanyName";
            this.txtCustomerCompanyName.Size = new System.Drawing.Size(462, 21);
            this.txtCustomerCompanyName.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(627, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "*";
            // 
            // lblCustomerCompanyName
            // 
            this.lblCustomerCompanyName.Location = new System.Drawing.Point(17, 14);
            this.lblCustomerCompanyName.Name = "lblCustomerCompanyName";
            this.lblCustomerCompanyName.Size = new System.Drawing.Size(138, 15);
            this.lblCustomerCompanyName.TabIndex = 12;
            this.lblCustomerCompanyName.Text = "单位名称(&C)：";
            this.lblCustomerCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnInitialize
            // 
            this.btnInitialize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInitialize.Enabled = false;
            this.btnInitialize.Location = new System.Drawing.Point(9, 392);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(145, 23);
            this.btnInitialize.TabIndex = 15;
            this.btnInitialize.Text = "初始化系统";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Visible = false;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // FrmConfig
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(828, 421);
            this.Controls.Add(this.btnInitialize);
            this.Controls.Add(this.txtCustomerCompanyName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblCustomerCompanyName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tcConfirm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmConfig";
            this.Text = "系统配置";
            this.tcConfirm.ResumeLayout(false);
            this.tpClient.ResumeLayout(false);
            this.tpClient.PerformLayout();
            this.tpServer.ResumeLayout(false);
            this.tpServer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupOnLineLimit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtUserCenterDbConnection;
        private System.Windows.Forms.TextBox txtBusinessDbConnection;
        private System.Windows.Forms.Label lblUserCenterDbConnection;
        private System.Windows.Forms.Label lblBusinessDbConnection;
        private System.Windows.Forms.ComboBox cmbUserCenterDbDbType;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.CheckBox chkEncryptDbConnection;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.TextBox txtWorkFlowDbConnection;
        private System.Windows.Forms.Label lblWorkFlowDbConnection;
        private System.Windows.Forms.TabControl tcConfirm;
        private System.Windows.Forms.TabPage tpClient;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.ComboBox cmbService;
        private System.Windows.Forms.CheckBox chkUseMessage;
        private System.Windows.Forms.CheckBox chbAutoLogOn;
        private System.Windows.Forms.TextBox txtLogOnForm;
        private System.Windows.Forms.Label lblLogOnForm;
        private System.Windows.Forms.TextBox txtMainForm;
        private System.Windows.Forms.Label lblMainForm;
        private System.Windows.Forms.CheckBox chkClientEncryptPassword;
        private System.Windows.Forms.CheckBox chkRememberPassword;
        private System.Windows.Forms.ComboBox cmbCurrentLanguage;
        private System.Windows.Forms.Label lblCurrentLanguage;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label labUserNameReq;
        private System.Windows.Forms.Label labPasswordReq;
        private System.Windows.Forms.TextBox txtClientPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TabPage tpServer;
        private System.Windows.Forms.CheckBox chkUseUserPermission;
        private System.Windows.Forms.CheckBox chkUseTableColumnPermission;
        private System.Windows.Forms.CheckBox chkUsePermissionScope;
        private System.Windows.Forms.CheckBox chkUseModulePermission;
        private System.Windows.Forms.CheckBox chkAllowUserRegister;
        private System.Windows.Forms.CheckBox chkRecordLog;
        private System.Windows.Forms.Label lblOnLineLimit;
        private System.Windows.Forms.NumericUpDown nupOnLineLimit;
        private System.Windows.Forms.TextBox txtCustomerCompanyName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCustomerCompanyName;
        private System.Windows.Forms.ComboBox cmbWorkFlowDbDbType;
        private System.Windows.Forms.ComboBox cmbBusinessDbDbType;
        private System.Windows.Forms.CheckBox chkUseTableScopePermission;
        private System.Windows.Forms.Button btnTabsMainForm;
        private System.Windows.Forms.Button btnSDIMainForm;
        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.Button btnSystemSecurity;
        private System.Windows.Forms.CheckBox chkUseOrganizePermission;
        private System.Windows.Forms.CheckBox chkWorkFlow;
        private System.Windows.Forms.Button btnSetWorkFlowDb;
        private System.Windows.Forms.Button btnSetBusinessDb;
        private System.Windows.Forms.Button btnSetUserCenter;
        private System.Windows.Forms.CheckBox chkUseAuthorizationScope;
    }
}