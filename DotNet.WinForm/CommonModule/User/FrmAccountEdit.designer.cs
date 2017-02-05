namespace DotNet.WinForm
{
    partial class FrmAccountEdit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpUser = new System.Windows.Forms.TabPage();
            this.grpRequestAnAccount = new System.Windows.Forms.GroupBox();
            this.ucSubCompany = new DotNet.WinForm.UCOrganizeSelect();
            this.lblSubCompany = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ucWorkgroup = new DotNet.WinForm.UCOrganizeSelect();
            this.lblWorkgroup = new System.Windows.Forms.Label();
            this.ucDepartment = new DotNet.WinForm.UCOrganizeSelect();
            this.ucCompany = new DotNet.WinForm.UCOrganizeSelect();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblE_mail = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUserNameReq = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtRealName = new System.Windows.Forms.TextBox();
            this.chbEnabled = new System.Windows.Forms.CheckBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblRealName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.tpUserOrganize = new System.Windows.Forms.TabPage();
            this.btnRemove = new System.Windows.Forms.Button();
            this.grdUserOrganize = new System.Windows.Forms.DataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWorkgroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddToOrganize = new System.Windows.Forms.Button();
            this.btnInvertSelect = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnSetPassword = new System.Windows.Forms.Button();
            this.btnLikeAdd = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tpUser.SuspendLayout();
            this.grpRequestAnAccount.SuspendLayout();
            this.tpUserOrganize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserOrganize)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(490, 463);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnSave.Location = new System.Drawing.Point(363, 463);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "更新用户(&R)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpUser);
            this.tabControl1.Controls.Add(this.tpUserOrganize);
            this.tabControl1.Location = new System.Drawing.Point(8, 11);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(558, 446);
            this.tabControl1.TabIndex = 0;
            // 
            // tpUser
            // 
            this.tpUser.BackColor = System.Drawing.SystemColors.Control;
            this.tpUser.Controls.Add(this.grpRequestAnAccount);
            this.tpUser.Location = new System.Drawing.Point(4, 22);
            this.tpUser.Name = "tpUser";
            this.tpUser.Padding = new System.Windows.Forms.Padding(3);
            this.tpUser.Size = new System.Drawing.Size(550, 420);
            this.tpUser.TabIndex = 0;
            this.tpUser.Text = "用户信息";
            // 
            // grpRequestAnAccount
            // 
            this.grpRequestAnAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRequestAnAccount.Controls.Add(this.ucSubCompany);
            this.grpRequestAnAccount.Controls.Add(this.lblSubCompany);
            this.grpRequestAnAccount.Controls.Add(this.txtCode);
            this.grpRequestAnAccount.Controls.Add(this.lblCode);
            this.grpRequestAnAccount.Controls.Add(this.txtMobile);
            this.grpRequestAnAccount.Controls.Add(this.label2);
            this.grpRequestAnAccount.Controls.Add(this.ucWorkgroup);
            this.grpRequestAnAccount.Controls.Add(this.lblWorkgroup);
            this.grpRequestAnAccount.Controls.Add(this.ucDepartment);
            this.grpRequestAnAccount.Controls.Add(this.ucCompany);
            this.grpRequestAnAccount.Controls.Add(this.txtEmail);
            this.grpRequestAnAccount.Controls.Add(this.lblE_mail);
            this.grpRequestAnAccount.Controls.Add(this.label4);
            this.grpRequestAnAccount.Controls.Add(this.txtDescription);
            this.grpRequestAnAccount.Controls.Add(this.lblDescription);
            this.grpRequestAnAccount.Controls.Add(this.label1);
            this.grpRequestAnAccount.Controls.Add(this.lblUserNameReq);
            this.grpRequestAnAccount.Controls.Add(this.lblDepartment);
            this.grpRequestAnAccount.Controls.Add(this.lblCompanyName);
            this.grpRequestAnAccount.Controls.Add(this.cmbRole);
            this.grpRequestAnAccount.Controls.Add(this.lblRole);
            this.grpRequestAnAccount.Controls.Add(this.txtRealName);
            this.grpRequestAnAccount.Controls.Add(this.chbEnabled);
            this.grpRequestAnAccount.Controls.Add(this.txtUserName);
            this.grpRequestAnAccount.Controls.Add(this.lblRealName);
            this.grpRequestAnAccount.Controls.Add(this.lblUserName);
            this.grpRequestAnAccount.Location = new System.Drawing.Point(9, 9);
            this.grpRequestAnAccount.Name = "grpRequestAnAccount";
            this.grpRequestAnAccount.Size = new System.Drawing.Size(531, 400);
            this.grpRequestAnAccount.TabIndex = 0;
            this.grpRequestAnAccount.TabStop = false;
            this.grpRequestAnAccount.Text = "用户";
            // 
            // ucSubCompany
            // 
            this.ucSubCompany.AllowNull = true;
            this.ucSubCompany.AllowSelect = true;
            this.ucSubCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSubCompany.AutoSize = true;
            this.ucSubCompany.CanEdit = false;
            this.ucSubCompany.CheckMove = false;
            this.ucSubCompany.Location = new System.Drawing.Point(116, 217);
            this.ucSubCompany.MultiSelect = false;
            this.ucSubCompany.Name = "ucSubCompany";
            this.ucSubCompany.OpenId = "";
            this.ucSubCompany.PermissionItemScopeCode = "";
            this.ucSubCompany.SelectedFullName = "";
            this.ucSubCompany.SelectedId = "";
            this.ucSubCompany.Size = new System.Drawing.Size(383, 23);
            this.ucSubCompany.TabIndex = 17;
            // 
            // lblSubCompany
            // 
            this.lblSubCompany.Location = new System.Drawing.Point(4, 221);
            this.lblSubCompany.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubCompany.Name = "lblSubCompany";
            this.lblSubCompany.Size = new System.Drawing.Size(106, 12);
            this.lblSubCompany.TabIndex = 16;
            this.lblSubCompany.Text = "所在分支机构：";
            this.lblSubCompany.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(116, 76);
            this.txtCode.MaxLength = 50;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(384, 21);
            this.txtCode.TabIndex = 6;
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(4, 78);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(106, 12);
            this.lblCode.TabIndex = 5;
            this.lblCode.Text = "工号(编号)：";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMobile
            // 
            this.txtMobile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMobile.Location = new System.Drawing.Point(116, 108);
            this.txtMobile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtMobile.MaxLength = 50;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(383, 21);
            this.txtMobile.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 111);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "手机(&M)：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucWorkgroup
            // 
            this.ucWorkgroup.AllowNull = true;
            this.ucWorkgroup.AllowSelect = true;
            this.ucWorkgroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucWorkgroup.AutoSize = true;
            this.ucWorkgroup.CanEdit = false;
            this.ucWorkgroup.CheckMove = false;
            this.ucWorkgroup.Location = new System.Drawing.Point(116, 275);
            this.ucWorkgroup.MultiSelect = false;
            this.ucWorkgroup.Name = "ucWorkgroup";
            this.ucWorkgroup.OpenId = "";
            this.ucWorkgroup.PermissionItemScopeCode = "";
            this.ucWorkgroup.SelectedFullName = "";
            this.ucWorkgroup.SelectedId = "";
            this.ucWorkgroup.Size = new System.Drawing.Size(383, 23);
            this.ucWorkgroup.TabIndex = 21;
            // 
            // lblWorkgroup
            // 
            this.lblWorkgroup.Location = new System.Drawing.Point(4, 278);
            this.lblWorkgroup.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWorkgroup.Name = "lblWorkgroup";
            this.lblWorkgroup.Size = new System.Drawing.Size(106, 12);
            this.lblWorkgroup.TabIndex = 20;
            this.lblWorkgroup.Text = "所在工作组：";
            this.lblWorkgroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucDepartment
            // 
            this.ucDepartment.AllowNull = true;
            this.ucDepartment.AllowSelect = true;
            this.ucDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucDepartment.AutoSize = true;
            this.ucDepartment.CanEdit = false;
            this.ucDepartment.CheckMove = false;
            this.ucDepartment.Location = new System.Drawing.Point(116, 247);
            this.ucDepartment.MultiSelect = false;
            this.ucDepartment.Name = "ucDepartment";
            this.ucDepartment.OpenId = "";
            this.ucDepartment.PermissionItemScopeCode = "";
            this.ucDepartment.SelectedFullName = "";
            this.ucDepartment.SelectedId = "";
            this.ucDepartment.Size = new System.Drawing.Size(383, 23);
            this.ucDepartment.TabIndex = 19;
            // 
            // ucCompany
            // 
            this.ucCompany.AllowNull = true;
            this.ucCompany.AllowSelect = true;
            this.ucCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucCompany.AutoSize = true;
            this.ucCompany.CanEdit = false;
            this.ucCompany.CheckMove = false;
            this.ucCompany.Location = new System.Drawing.Point(116, 190);
            this.ucCompany.MultiSelect = false;
            this.ucCompany.Name = "ucCompany";
            this.ucCompany.OpenId = "";
            this.ucCompany.PermissionItemScopeCode = "";
            this.ucCompany.SelectedFullName = "";
            this.ucCompany.SelectedId = "";
            this.ucCompany.Size = new System.Drawing.Size(383, 23);
            this.ucCompany.TabIndex = 14;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(116, 135);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(384, 21);
            this.txtEmail.TabIndex = 10;
            // 
            // lblE_mail
            // 
            this.lblE_mail.Location = new System.Drawing.Point(4, 138);
            this.lblE_mail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblE_mail.Name = "lblE_mail";
            this.lblE_mail.Size = new System.Drawing.Size(106, 12);
            this.lblE_mail.TabIndex = 9;
            this.lblE_mail.Text = "E_mail(&E)：";
            this.lblE_mail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(509, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "*";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(116, 332);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(384, 57);
            this.txtDescription.TabIndex = 24;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(4, 332);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(106, 12);
            this.lblDescription.TabIndex = 23;
            this.lblDescription.Text = "描述(&D)：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(509, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "*";
            // 
            // lblUserNameReq
            // 
            this.lblUserNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserNameReq.AutoSize = true;
            this.lblUserNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblUserNameReq.Location = new System.Drawing.Point(509, 24);
            this.lblUserNameReq.Name = "lblUserNameReq";
            this.lblUserNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblUserNameReq.TabIndex = 2;
            this.lblUserNameReq.Text = "*";
            // 
            // lblDepartment
            // 
            this.lblDepartment.Location = new System.Drawing.Point(4, 250);
            this.lblDepartment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(106, 12);
            this.lblDepartment.TabIndex = 18;
            this.lblDepartment.Text = "所在部门：";
            this.lblDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.Location = new System.Drawing.Point(4, 193);
            this.lblCompanyName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(106, 12);
            this.lblCompanyName.TabIndex = 13;
            this.lblCompanyName.Text = "所在单位：";
            this.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbRole
            // 
            this.cmbRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.Location = new System.Drawing.Point(116, 163);
            this.cmbRole.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(384, 20);
            this.cmbRole.TabIndex = 12;
            // 
            // lblRole
            // 
            this.lblRole.Location = new System.Drawing.Point(4, 166);
            this.lblRole.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(106, 12);
            this.lblRole.TabIndex = 11;
            this.lblRole.Text = "默认角色(&R)：";
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRealName
            // 
            this.txtRealName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRealName.Location = new System.Drawing.Point(116, 47);
            this.txtRealName.MaxLength = 50;
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.Size = new System.Drawing.Size(384, 21);
            this.txtRealName.TabIndex = 4;
            this.txtRealName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtRealName_MouseDoubleClick);
            // 
            // chbEnabled
            // 
            this.chbEnabled.AutoSize = true;
            this.chbEnabled.Location = new System.Drawing.Point(116, 309);
            this.chbEnabled.Name = "chbEnabled";
            this.chbEnabled.Size = new System.Drawing.Size(48, 16);
            this.chbEnabled.TabIndex = 22;
            this.chbEnabled.Text = "有效";
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.Location = new System.Drawing.Point(116, 19);
            this.txtUserName.MaxLength = 50;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(384, 21);
            this.txtUserName.TabIndex = 1;
            // 
            // lblRealName
            // 
            this.lblRealName.Location = new System.Drawing.Point(4, 50);
            this.lblRealName.Name = "lblRealName";
            this.lblRealName.Size = new System.Drawing.Size(106, 12);
            this.lblRealName.TabIndex = 3;
            this.lblRealName.Text = "姓名(&N)：";
            this.lblRealName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(4, 22);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(106, 12);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "用户名(&U)：";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tpUserOrganize
            // 
            this.tpUserOrganize.BackColor = System.Drawing.SystemColors.Control;
            this.tpUserOrganize.Controls.Add(this.btnRemove);
            this.tpUserOrganize.Controls.Add(this.grdUserOrganize);
            this.tpUserOrganize.Controls.Add(this.btnAddToOrganize);
            this.tpUserOrganize.Controls.Add(this.btnInvertSelect);
            this.tpUserOrganize.Controls.Add(this.btnSelectAll);
            this.tpUserOrganize.Location = new System.Drawing.Point(4, 22);
            this.tpUserOrganize.Name = "tpUserOrganize";
            this.tpUserOrganize.Padding = new System.Windows.Forms.Padding(3);
            this.tpUserOrganize.Size = new System.Drawing.Size(550, 420);
            this.tpUserOrganize.TabIndex = 1;
            this.tpUserOrganize.Text = "兼任职务";
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(449, 393);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(95, 23);
            this.btnRemove.TabIndex = 11;
            this.btnRemove.Text = "移除(&R)";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // grdUserOrganize
            // 
            this.grdUserOrganize.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.grdUserOrganize.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdUserOrganize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdUserOrganize.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdUserOrganize.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdUserOrganize.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUserOrganize.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colCompanyName,
            this.colDepartmentName,
            this.colWorkgroupName,
            this.colRoleName});
            this.grdUserOrganize.Location = new System.Drawing.Point(6, 6);
            this.grdUserOrganize.MultiSelect = false;
            this.grdUserOrganize.Name = "grdUserOrganize";
            this.grdUserOrganize.RowTemplate.Height = 23;
            this.grdUserOrganize.Size = new System.Drawing.Size(538, 384);
            this.grdUserOrganize.TabIndex = 4;
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "Selected";
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Width = 50;
            // 
            // colCompanyName
            // 
            this.colCompanyName.DataPropertyName = "CompanyName";
            this.colCompanyName.FillWeight = 90F;
            this.colCompanyName.HeaderText = "公司";
            this.colCompanyName.MaxInputLength = 50;
            this.colCompanyName.Name = "colCompanyName";
            this.colCompanyName.ReadOnly = true;
            this.colCompanyName.Width = 90;
            // 
            // colDepartmentName
            // 
            this.colDepartmentName.DataPropertyName = "DepartmentName";
            this.colDepartmentName.FillWeight = 200F;
            this.colDepartmentName.HeaderText = "部门";
            this.colDepartmentName.MaxInputLength = 50;
            this.colDepartmentName.Name = "colDepartmentName";
            this.colDepartmentName.ReadOnly = true;
            // 
            // colWorkgroupName
            // 
            this.colWorkgroupName.DataPropertyName = "WorkgroupName";
            this.colWorkgroupName.FillWeight = 90F;
            this.colWorkgroupName.HeaderText = "工作组";
            this.colWorkgroupName.MaxInputLength = 90;
            this.colWorkgroupName.Name = "colWorkgroupName";
            this.colWorkgroupName.ReadOnly = true;
            this.colWorkgroupName.Width = 90;
            // 
            // colRoleName
            // 
            this.colRoleName.DataPropertyName = "RoleName";
            this.colRoleName.FillWeight = 120F;
            this.colRoleName.HeaderText = "职务";
            this.colRoleName.MaxInputLength = 50;
            this.colRoleName.Name = "colRoleName";
            this.colRoleName.Width = 120;
            // 
            // btnAddToOrganize
            // 
            this.btnAddToOrganize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddToOrganize.Location = new System.Drawing.Point(342, 394);
            this.btnAddToOrganize.Name = "btnAddToOrganize";
            this.btnAddToOrganize.Size = new System.Drawing.Size(101, 23);
            this.btnAddToOrganize.TabIndex = 10;
            this.btnAddToOrganize.Text = "添加兼任(&D)...";
            this.btnAddToOrganize.UseVisualStyleBackColor = true;
            this.btnAddToOrganize.Click += new System.EventHandler(this.btnAddToOrganize_Click);
            // 
            // btnInvertSelect
            // 
            this.btnInvertSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvertSelect.Enabled = false;
            this.btnInvertSelect.Location = new System.Drawing.Point(115, 393);
            this.btnInvertSelect.Name = "btnInvertSelect";
            this.btnInvertSelect.Size = new System.Drawing.Size(105, 23);
            this.btnInvertSelect.TabIndex = 9;
            this.btnInvertSelect.Text = "反选";
            this.btnInvertSelect.UseVisualStyleBackColor = true;
            this.btnInvertSelect.Click += new System.EventHandler(this.btnInvertSelect_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Enabled = false;
            this.btnSelectAll.Location = new System.Drawing.Point(4, 393);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(105, 23);
            this.btnSelectAll.TabIndex = 8;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnSetPassword
            // 
            this.btnSetPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetPassword.Enabled = false;
            this.btnSetPassword.Location = new System.Drawing.Point(8, 463);
            this.btnSetPassword.Name = "btnSetPassword";
            this.btnSetPassword.Size = new System.Drawing.Size(115, 23);
            this.btnSetPassword.TabIndex = 1;
            this.btnSetPassword.Text = "设置密码(&S)...";
            this.btnSetPassword.Click += new System.EventHandler(this.btnSetPassword_Click);
            // 
            // btnLikeAdd
            // 
            this.btnLikeAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLikeAdd.Location = new System.Drawing.Point(128, 463);
            this.btnLikeAdd.Name = "btnLikeAdd";
            this.btnLikeAdd.Size = new System.Drawing.Size(113, 23);
            this.btnLikeAdd.TabIndex = 2;
            this.btnLikeAdd.Text = "类似添加(&A)";
            this.btnLikeAdd.UseVisualStyleBackColor = true;
            this.btnLikeAdd.Click += new System.EventHandler(this.btnLikeAdd_Click);
            // 
            // FrmAccountEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(573, 490);
            this.Controls.Add(this.btnLikeAdd);
            this.Controls.Add(this.btnSetPassword);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabControl1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAccountEdit";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "编辑用户";
            this.tabControl1.ResumeLayout(false);
            this.tpUser.ResumeLayout(false);
            this.grpRequestAnAccount.ResumeLayout(false);
            this.grpRequestAnAccount.PerformLayout();
            this.tpUserOrganize.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUserOrganize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpUser;
        private System.Windows.Forms.GroupBox grpRequestAnAccount;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label label2;
        private DotNet.WinForm.UCOrganizeSelect ucWorkgroup;
        private System.Windows.Forms.Label lblWorkgroup;
        private DotNet.WinForm.UCOrganizeSelect ucDepartment;
        private DotNet.WinForm.UCOrganizeSelect ucCompany;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblE_mail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUserNameReq;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.TextBox txtRealName;
        private System.Windows.Forms.CheckBox chbEnabled;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblRealName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TabPage tpUserOrganize;
        private System.Windows.Forms.DataGridView grdUserOrganize;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAddToOrganize;
        private System.Windows.Forms.Button btnInvertSelect;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkgroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoleName;
        private System.Windows.Forms.Button btnSetPassword;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Button btnLikeAdd;
        private UCOrganizeSelect ucSubCompany;
        private System.Windows.Forms.Label lblSubCompany;
    }
}