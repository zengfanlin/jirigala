namespace DotNet.WinForm
{
    partial class FrmOrganizeEdit
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
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtWeb = new System.Windows.Forms.TextBox();
            this.lblWeb = new System.Windows.Forms.Label();
            this.txtPostalcode = new System.Windows.Forms.TextBox();
            this.lblPostalcode = new System.Windows.Forms.Label();
            this.lblParentReq = new System.Windows.Forms.Label();
            this.ucParent = new DotNet.WinForm.UCOrganizeSelect();
            this.chkIsInnerOrganize = new System.Windows.Forms.CheckBox();
            this.lblFullNameReq = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.lblParentOrganize = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtInnerPhone = new System.Windows.Forms.TextBox();
            this.txtOuterPhone = new System.Windows.Forms.TextBox();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.lblInnerPhone = new System.Windows.Forms.Label();
            this.lblOuterPhone = new System.Windows.Forms.Label();
            this.lblFax = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSystemManager = new System.Windows.Forms.Button();
            this.btnAccounting = new System.Windows.Forms.Button();
            this.btnCashier = new System.Windows.Forms.Button();
            this.btnFinancial = new System.Windows.Forms.Button();
            this.btnAssistantManager = new System.Windows.Forms.Button();
            this.btnManager = new System.Windows.Forms.Button();
            this.btnBusinessLeadership = new System.Windows.Forms.Button();
            this.btnLeadership = new System.Windows.Forms.Button();
            this.grbOrganize = new System.Windows.Forms.GroupBox();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.lblShortName = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtLeadership = new System.Windows.Forms.TextBox();
            this.txtBusinessLeadership = new System.Windows.Forms.TextBox();
            this.txtManager = new System.Windows.Forms.TextBox();
            this.txtAssistantManager = new System.Windows.Forms.TextBox();
            this.txtFinancial = new System.Windows.Forms.TextBox();
            this.txtAccounting = new System.Windows.Forms.TextBox();
            this.txtCashier = new System.Windows.Forms.TextBox();
            this.txtSystemManager = new System.Windows.Forms.TextBox();
            this.grbDuty = new System.Windows.Forms.GroupBox();
            this.btnSystemManagerDelete = new System.Windows.Forms.Button();
            this.btnFinancialDelete = new System.Windows.Forms.Button();
            this.btnAccountingDelete = new System.Windows.Forms.Button();
            this.btnCashierDelete = new System.Windows.Forms.Button();
            this.btnPersonnelLeadershipDelete = new System.Windows.Forms.Button();
            this.btnAssistantManagerDelete = new System.Windows.Forms.Button();
            this.btnBusinessLeadershipDelete = new System.Windows.Forms.Button();
            this.btnAssistantDelete = new System.Windows.Forms.Button();
            this.btnFinancialLeadershipDelete = new System.Windows.Forms.Button();
            this.btnManagerDelete = new System.Windows.Forms.Button();
            this.btnLeadershipDelete = new System.Windows.Forms.Button();
            this.btnAssistant = new System.Windows.Forms.Button();
            this.txtAssistant = new System.Windows.Forms.TextBox();
            this.btnPersonnelLeadership = new System.Windows.Forms.Button();
            this.txtPersonnelLeadership = new System.Windows.Forms.TextBox();
            this.btnFinancialLeadership = new System.Windows.Forms.Button();
            this.txtFinancialLeadership = new System.Windows.Forms.TextBox();
            this.btnPermission = new System.Windows.Forms.Button();
            this.btnLikeAdd = new System.Windows.Forms.Button();
            this.grbOrganize.SuspendLayout();
            this.grbDuty.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(128, 318);
            this.txtAddress.MaxLength = 20;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(330, 21);
            this.txtAddress.TabIndex = 21;
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(23, 321);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(99, 12);
            this.lblAddress.TabIndex = 20;
            this.lblAddress.Text = "地址：";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWeb
            // 
            this.txtWeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWeb.Location = new System.Drawing.Point(128, 345);
            this.txtWeb.MaxLength = 200;
            this.txtWeb.Name = "txtWeb";
            this.txtWeb.Size = new System.Drawing.Size(330, 21);
            this.txtWeb.TabIndex = 23;
            // 
            // lblWeb
            // 
            this.lblWeb.Location = new System.Drawing.Point(23, 349);
            this.lblWeb.Name = "lblWeb";
            this.lblWeb.Size = new System.Drawing.Size(99, 12);
            this.lblWeb.TabIndex = 22;
            this.lblWeb.Text = "网址：";
            this.lblWeb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPostalcode
            // 
            this.txtPostalcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPostalcode.Location = new System.Drawing.Point(128, 291);
            this.txtPostalcode.MaxLength = 20;
            this.txtPostalcode.Name = "txtPostalcode";
            this.txtPostalcode.Size = new System.Drawing.Size(330, 21);
            this.txtPostalcode.TabIndex = 19;
            // 
            // lblPostalcode
            // 
            this.lblPostalcode.Location = new System.Drawing.Point(23, 296);
            this.lblPostalcode.Name = "lblPostalcode";
            this.lblPostalcode.Size = new System.Drawing.Size(99, 12);
            this.lblPostalcode.TabIndex = 18;
            this.lblPostalcode.Text = "邮编：";
            this.lblPostalcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblParentReq
            // 
            this.lblParentReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblParentReq.AutoSize = true;
            this.lblParentReq.ForeColor = System.Drawing.Color.Red;
            this.lblParentReq.Location = new System.Drawing.Point(460, 68);
            this.lblParentReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblParentReq.Name = "lblParentReq";
            this.lblParentReq.Size = new System.Drawing.Size(11, 12);
            this.lblParentReq.TabIndex = 4;
            this.lblParentReq.Text = "*";
            // 
            // ucParent
            // 
            this.ucParent.AllowNull = true;
            this.ucParent.AllowSelect = true;
            this.ucParent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucParent.AutoSize = true;
            this.ucParent.CanEdit = false;
            this.ucParent.CheckMove = false;
            this.ucParent.Location = new System.Drawing.Point(128, 63);
            this.ucParent.MultiSelect = false;
            this.ucParent.Name = "ucParent";
            this.ucParent.OpenId = "";
            this.ucParent.PermissionItemScopeCode = "";
            this.ucParent.SelectedFullName = "";
            this.ucParent.SelectedId = "";
            this.ucParent.Size = new System.Drawing.Size(330, 23);
            this.ucParent.TabIndex = 3;
            // 
            // chkIsInnerOrganize
            // 
            this.chkIsInnerOrganize.AutoSize = true;
            this.chkIsInnerOrganize.Checked = true;
            this.chkIsInnerOrganize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsInnerOrganize.Location = new System.Drawing.Point(231, 375);
            this.chkIsInnerOrganize.Name = "chkIsInnerOrganize";
            this.chkIsInnerOrganize.Size = new System.Drawing.Size(72, 16);
            this.chkIsInnerOrganize.TabIndex = 25;
            this.chkIsInnerOrganize.Text = "内部组织";
            this.chkIsInnerOrganize.UseVisualStyleBackColor = true;
            // 
            // lblFullNameReq
            // 
            this.lblFullNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullNameReq.AutoSize = true;
            this.lblFullNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblFullNameReq.Location = new System.Drawing.Point(459, 97);
            this.lblFullNameReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFullNameReq.Name = "lblFullNameReq";
            this.lblFullNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblFullNameReq.TabIndex = 7;
            this.lblFullNameReq.Text = "*";
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(128, 375);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(48, 16);
            this.chkEnabled.TabIndex = 24;
            this.chkEnabled.Text = "有效";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // lblParentOrganize
            // 
            this.lblParentOrganize.Location = new System.Drawing.Point(23, 67);
            this.lblParentOrganize.Name = "lblParentOrganize";
            this.lblParentOrganize.Size = new System.Drawing.Size(99, 12);
            this.lblParentOrganize.TabIndex = 2;
            this.lblParentOrganize.Text = "父节点：";
            this.lblParentOrganize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCategory
            // 
            this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Location = new System.Drawing.Point(128, 178);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(330, 20);
            this.cmbCategory.TabIndex = 11;
            // 
            // lblCategory
            // 
            this.lblCategory.Location = new System.Drawing.Point(23, 181);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(99, 12);
            this.lblCategory.TabIndex = 10;
            this.lblCategory.Text = "分类：";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInnerPhone
            // 
            this.txtInnerPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInnerPhone.Location = new System.Drawing.Point(128, 237);
            this.txtInnerPhone.MaxLength = 20;
            this.txtInnerPhone.Name = "txtInnerPhone";
            this.txtInnerPhone.Size = new System.Drawing.Size(330, 21);
            this.txtInnerPhone.TabIndex = 15;
            // 
            // txtOuterPhone
            // 
            this.txtOuterPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOuterPhone.Location = new System.Drawing.Point(128, 210);
            this.txtOuterPhone.MaxLength = 20;
            this.txtOuterPhone.Name = "txtOuterPhone";
            this.txtOuterPhone.Size = new System.Drawing.Size(330, 21);
            this.txtOuterPhone.TabIndex = 13;
            // 
            // txtFax
            // 
            this.txtFax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFax.Location = new System.Drawing.Point(128, 264);
            this.txtFax.MaxLength = 20;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(330, 21);
            this.txtFax.TabIndex = 17;
            // 
            // lblInnerPhone
            // 
            this.lblInnerPhone.Location = new System.Drawing.Point(23, 241);
            this.lblInnerPhone.Name = "lblInnerPhone";
            this.lblInnerPhone.Size = new System.Drawing.Size(99, 12);
            this.lblInnerPhone.TabIndex = 14;
            this.lblInnerPhone.Text = "内线：";
            this.lblInnerPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOuterPhone
            // 
            this.lblOuterPhone.Location = new System.Drawing.Point(23, 214);
            this.lblOuterPhone.Name = "lblOuterPhone";
            this.lblOuterPhone.Size = new System.Drawing.Size(99, 12);
            this.lblOuterPhone.TabIndex = 12;
            this.lblOuterPhone.Text = "电话：";
            this.lblOuterPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFax
            // 
            this.lblFax.Location = new System.Drawing.Point(23, 268);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(99, 12);
            this.lblFax.TabIndex = 16;
            this.lblFax.Text = "传真：";
            this.lblFax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(128, 400);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(330, 85);
            this.txtDescription.TabIndex = 27;
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.Location = new System.Drawing.Point(128, 92);
            this.txtFullName.MaxLength = 80;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(330, 21);
            this.txtFullName.TabIndex = 6;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(128, 119);
            this.txtCode.MaxLength = 20;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(330, 21);
            this.txtCode.TabIndex = 9;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(13, 388);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(99, 12);
            this.lblDescription.TabIndex = 26;
            this.lblDescription.Text = "描述(&D)：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(23, 94);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(99, 12);
            this.lblFullName.TabIndex = 5;
            this.lblFullName.Text = "名称：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(23, 122);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(99, 12);
            this.lblCode.TabIndex = 8;
            this.lblCode.Text = "编号：";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(399, 520);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(315, 520);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSystemManager
            // 
            this.btnSystemManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSystemManager.Location = new System.Drawing.Point(13, 480);
            this.btnSystemManager.Name = "btnSystemManager";
            this.btnSystemManager.Size = new System.Drawing.Size(91, 23);
            this.btnSystemManager.TabIndex = 20;
            this.btnSystemManager.Text = "系统管理员";
            this.btnSystemManager.UseVisualStyleBackColor = true;
            this.btnSystemManager.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnAccounting
            // 
            this.btnAccounting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccounting.Location = new System.Drawing.Point(13, 388);
            this.btnAccounting.Name = "btnAccounting";
            this.btnAccounting.Size = new System.Drawing.Size(91, 23);
            this.btnAccounting.TabIndex = 16;
            this.btnAccounting.Text = "会计";
            this.btnAccounting.UseVisualStyleBackColor = true;
            this.btnAccounting.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnCashier
            // 
            this.btnCashier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCashier.Location = new System.Drawing.Point(13, 434);
            this.btnCashier.Name = "btnCashier";
            this.btnCashier.Size = new System.Drawing.Size(91, 23);
            this.btnCashier.TabIndex = 18;
            this.btnCashier.Text = "出纳";
            this.btnCashier.UseVisualStyleBackColor = true;
            this.btnCashier.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnFinancial
            // 
            this.btnFinancial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinancial.Location = new System.Drawing.Point(13, 341);
            this.btnFinancial.Name = "btnFinancial";
            this.btnFinancial.Size = new System.Drawing.Size(91, 23);
            this.btnFinancial.TabIndex = 14;
            this.btnFinancial.Text = "财务主管";
            this.btnFinancial.UseVisualStyleBackColor = true;
            this.btnFinancial.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnAssistantManager
            // 
            this.btnAssistantManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssistantManager.Location = new System.Drawing.Point(13, 249);
            this.btnAssistantManager.Name = "btnAssistantManager";
            this.btnAssistantManager.Size = new System.Drawing.Size(91, 23);
            this.btnAssistantManager.TabIndex = 10;
            this.btnAssistantManager.Text = "副主管";
            this.btnAssistantManager.UseVisualStyleBackColor = true;
            this.btnAssistantManager.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnManager
            // 
            this.btnManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManager.Location = new System.Drawing.Point(13, 202);
            this.btnManager.Name = "btnManager";
            this.btnManager.Size = new System.Drawing.Size(91, 23);
            this.btnManager.TabIndex = 8;
            this.btnManager.Text = "主管";
            this.btnManager.UseVisualStyleBackColor = true;
            this.btnManager.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnBusinessLeadership
            // 
            this.btnBusinessLeadership.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBusinessLeadership.Location = new System.Drawing.Point(13, 62);
            this.btnBusinessLeadership.Name = "btnBusinessLeadership";
            this.btnBusinessLeadership.Size = new System.Drawing.Size(91, 23);
            this.btnBusinessLeadership.TabIndex = 2;
            this.btnBusinessLeadership.Text = "业务分管领导";
            this.btnBusinessLeadership.UseVisualStyleBackColor = true;
            this.btnBusinessLeadership.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnLeadership
            // 
            this.btnLeadership.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLeadership.Location = new System.Drawing.Point(13, 17);
            this.btnLeadership.Name = "btnLeadership";
            this.btnLeadership.Size = new System.Drawing.Size(91, 23);
            this.btnLeadership.TabIndex = 0;
            this.btnLeadership.Text = "领导";
            this.btnLeadership.UseVisualStyleBackColor = true;
            this.btnLeadership.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // grbOrganize
            // 
            this.grbOrganize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbOrganize.Controls.Add(this.txtShortName);
            this.grbOrganize.Controls.Add(this.lblShortName);
            this.grbOrganize.Controls.Add(this.txtId);
            this.grbOrganize.Controls.Add(this.lblId);
            this.grbOrganize.Controls.Add(this.lblDescription);
            this.grbOrganize.Location = new System.Drawing.Point(10, 12);
            this.grbOrganize.Name = "grbOrganize";
            this.grbOrganize.Size = new System.Drawing.Size(464, 497);
            this.grbOrganize.TabIndex = 0;
            this.grbOrganize.TabStop = false;
            this.grbOrganize.Text = "组织机构";
            // 
            // txtShortName
            // 
            this.txtShortName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShortName.Location = new System.Drawing.Point(119, 137);
            this.txtShortName.MaxLength = 80;
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(328, 21);
            this.txtShortName.TabIndex = 32;
            // 
            // lblShortName
            // 
            this.lblShortName.Location = new System.Drawing.Point(2, 140);
            this.lblShortName.Name = "lblShortName";
            this.lblShortName.Size = new System.Drawing.Size(111, 12);
            this.lblShortName.TabIndex = 31;
            this.lblShortName.Text = "简称：";
            this.lblShortName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtId
            // 
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtId.Location = new System.Drawing.Point(119, 20);
            this.txtId.MaxLength = 50;
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(328, 21);
            this.txtId.TabIndex = 1;
            this.txtId.TabStop = false;
            // 
            // lblId
            // 
            this.lblId.Location = new System.Drawing.Point(33, 23);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(79, 12);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "主键：";
            this.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLeadership
            // 
            this.txtLeadership.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLeadership.BackColor = System.Drawing.Color.Bisque;
            this.txtLeadership.Location = new System.Drawing.Point(13, 41);
            this.txtLeadership.MaxLength = 80;
            this.txtLeadership.Name = "txtLeadership";
            this.txtLeadership.ReadOnly = true;
            this.txtLeadership.Size = new System.Drawing.Size(120, 21);
            this.txtLeadership.TabIndex = 1;
            // 
            // txtBusinessLeadership
            // 
            this.txtBusinessLeadership.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBusinessLeadership.BackColor = System.Drawing.Color.Bisque;
            this.txtBusinessLeadership.Location = new System.Drawing.Point(13, 86);
            this.txtBusinessLeadership.MaxLength = 80;
            this.txtBusinessLeadership.Name = "txtBusinessLeadership";
            this.txtBusinessLeadership.ReadOnly = true;
            this.txtBusinessLeadership.Size = new System.Drawing.Size(120, 21);
            this.txtBusinessLeadership.TabIndex = 3;
            // 
            // txtManager
            // 
            this.txtManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtManager.BackColor = System.Drawing.Color.OldLace;
            this.txtManager.Location = new System.Drawing.Point(13, 226);
            this.txtManager.MaxLength = 80;
            this.txtManager.Name = "txtManager";
            this.txtManager.ReadOnly = true;
            this.txtManager.Size = new System.Drawing.Size(120, 21);
            this.txtManager.TabIndex = 9;
            // 
            // txtAssistantManager
            // 
            this.txtAssistantManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssistantManager.Location = new System.Drawing.Point(13, 273);
            this.txtAssistantManager.MaxLength = 80;
            this.txtAssistantManager.Name = "txtAssistantManager";
            this.txtAssistantManager.ReadOnly = true;
            this.txtAssistantManager.Size = new System.Drawing.Size(120, 21);
            this.txtAssistantManager.TabIndex = 11;
            // 
            // txtFinancial
            // 
            this.txtFinancial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFinancial.Location = new System.Drawing.Point(13, 365);
            this.txtFinancial.MaxLength = 80;
            this.txtFinancial.Name = "txtFinancial";
            this.txtFinancial.ReadOnly = true;
            this.txtFinancial.Size = new System.Drawing.Size(120, 21);
            this.txtFinancial.TabIndex = 15;
            // 
            // txtAccounting
            // 
            this.txtAccounting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccounting.Location = new System.Drawing.Point(13, 412);
            this.txtAccounting.MaxLength = 80;
            this.txtAccounting.Name = "txtAccounting";
            this.txtAccounting.ReadOnly = true;
            this.txtAccounting.Size = new System.Drawing.Size(120, 21);
            this.txtAccounting.TabIndex = 17;
            // 
            // txtCashier
            // 
            this.txtCashier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCashier.Location = new System.Drawing.Point(13, 458);
            this.txtCashier.MaxLength = 80;
            this.txtCashier.Name = "txtCashier";
            this.txtCashier.ReadOnly = true;
            this.txtCashier.Size = new System.Drawing.Size(120, 21);
            this.txtCashier.TabIndex = 19;
            // 
            // txtSystemManager
            // 
            this.txtSystemManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSystemManager.Location = new System.Drawing.Point(13, 504);
            this.txtSystemManager.MaxLength = 80;
            this.txtSystemManager.Name = "txtSystemManager";
            this.txtSystemManager.ReadOnly = true;
            this.txtSystemManager.Size = new System.Drawing.Size(120, 21);
            this.txtSystemManager.TabIndex = 21;
            // 
            // grbDuty
            // 
            this.grbDuty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDuty.Controls.Add(this.btnSystemManagerDelete);
            this.grbDuty.Controls.Add(this.btnFinancialDelete);
            this.grbDuty.Controls.Add(this.btnAccountingDelete);
            this.grbDuty.Controls.Add(this.btnCashierDelete);
            this.grbDuty.Controls.Add(this.btnPersonnelLeadershipDelete);
            this.grbDuty.Controls.Add(this.btnAssistantManagerDelete);
            this.grbDuty.Controls.Add(this.btnBusinessLeadershipDelete);
            this.grbDuty.Controls.Add(this.btnAssistantDelete);
            this.grbDuty.Controls.Add(this.btnFinancialLeadershipDelete);
            this.grbDuty.Controls.Add(this.btnManagerDelete);
            this.grbDuty.Controls.Add(this.btnLeadershipDelete);
            this.grbDuty.Controls.Add(this.btnAssistant);
            this.grbDuty.Controls.Add(this.txtAssistant);
            this.grbDuty.Controls.Add(this.btnPersonnelLeadership);
            this.grbDuty.Controls.Add(this.txtPersonnelLeadership);
            this.grbDuty.Controls.Add(this.btnFinancialLeadership);
            this.grbDuty.Controls.Add(this.txtFinancialLeadership);
            this.grbDuty.Controls.Add(this.txtSystemManager);
            this.grbDuty.Controls.Add(this.btnLeadership);
            this.grbDuty.Controls.Add(this.txtCashier);
            this.grbDuty.Controls.Add(this.btnBusinessLeadership);
            this.grbDuty.Controls.Add(this.txtAccounting);
            this.grbDuty.Controls.Add(this.btnManager);
            this.grbDuty.Controls.Add(this.txtFinancial);
            this.grbDuty.Controls.Add(this.btnAssistantManager);
            this.grbDuty.Controls.Add(this.txtAssistantManager);
            this.grbDuty.Controls.Add(this.btnFinancial);
            this.grbDuty.Controls.Add(this.txtManager);
            this.grbDuty.Controls.Add(this.btnCashier);
            this.grbDuty.Controls.Add(this.txtBusinessLeadership);
            this.grbDuty.Controls.Add(this.btnAccounting);
            this.grbDuty.Controls.Add(this.txtLeadership);
            this.grbDuty.Controls.Add(this.btnSystemManager);
            this.grbDuty.Location = new System.Drawing.Point(486, 12);
            this.grbDuty.Name = "grbDuty";
            this.grbDuty.Size = new System.Drawing.Size(146, 536);
            this.grbDuty.TabIndex = 1;
            this.grbDuty.TabStop = false;
            this.grbDuty.Text = "岗位";
            // 
            // btnSystemManagerDelete
            // 
            this.btnSystemManagerDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSystemManagerDelete.Location = new System.Drawing.Point(105, 480);
            this.btnSystemManagerDelete.Name = "btnSystemManagerDelete";
            this.btnSystemManagerDelete.Size = new System.Drawing.Size(30, 23);
            this.btnSystemManagerDelete.TabIndex = 42;
            this.btnSystemManagerDelete.UseVisualStyleBackColor = true;
            this.btnSystemManagerDelete.Click += new System.EventHandler(this.btnRoleDelete_Click);
            // 
            // btnFinancialDelete
            // 
            this.btnFinancialDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinancialDelete.Location = new System.Drawing.Point(105, 341);
            this.btnFinancialDelete.Name = "btnFinancialDelete";
            this.btnFinancialDelete.Size = new System.Drawing.Size(30, 23);
            this.btnFinancialDelete.TabIndex = 39;
            this.btnFinancialDelete.UseVisualStyleBackColor = true;
            this.btnFinancialDelete.Click += new System.EventHandler(this.btnRoleDelete_Click);
            // 
            // btnAccountingDelete
            // 
            this.btnAccountingDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccountingDelete.Location = new System.Drawing.Point(105, 388);
            this.btnAccountingDelete.Name = "btnAccountingDelete";
            this.btnAccountingDelete.Size = new System.Drawing.Size(30, 23);
            this.btnAccountingDelete.TabIndex = 40;
            this.btnAccountingDelete.UseVisualStyleBackColor = true;
            this.btnAccountingDelete.Click += new System.EventHandler(this.btnRoleDelete_Click);
            // 
            // btnCashierDelete
            // 
            this.btnCashierDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCashierDelete.Location = new System.Drawing.Point(105, 434);
            this.btnCashierDelete.Name = "btnCashierDelete";
            this.btnCashierDelete.Size = new System.Drawing.Size(30, 23);
            this.btnCashierDelete.TabIndex = 41;
            this.btnCashierDelete.UseVisualStyleBackColor = true;
            this.btnCashierDelete.Click += new System.EventHandler(this.btnRoleDelete_Click);
            // 
            // btnPersonnelLeadershipDelete
            // 
            this.btnPersonnelLeadershipDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPersonnelLeadershipDelete.Location = new System.Drawing.Point(105, 156);
            this.btnPersonnelLeadershipDelete.Name = "btnPersonnelLeadershipDelete";
            this.btnPersonnelLeadershipDelete.Size = new System.Drawing.Size(30, 23);
            this.btnPersonnelLeadershipDelete.TabIndex = 35;
            this.btnPersonnelLeadershipDelete.UseVisualStyleBackColor = true;
            this.btnPersonnelLeadershipDelete.Click += new System.EventHandler(this.btnRoleDelete_Click);
            // 
            // btnAssistantManagerDelete
            // 
            this.btnAssistantManagerDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssistantManagerDelete.Location = new System.Drawing.Point(105, 249);
            this.btnAssistantManagerDelete.Name = "btnAssistantManagerDelete";
            this.btnAssistantManagerDelete.Size = new System.Drawing.Size(30, 23);
            this.btnAssistantManagerDelete.TabIndex = 37;
            this.btnAssistantManagerDelete.UseVisualStyleBackColor = true;
            this.btnAssistantManagerDelete.Click += new System.EventHandler(this.btnRoleDelete_Click);
            // 
            // btnBusinessLeadershipDelete
            // 
            this.btnBusinessLeadershipDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBusinessLeadershipDelete.Location = new System.Drawing.Point(105, 62);
            this.btnBusinessLeadershipDelete.Name = "btnBusinessLeadershipDelete";
            this.btnBusinessLeadershipDelete.Size = new System.Drawing.Size(30, 23);
            this.btnBusinessLeadershipDelete.TabIndex = 33;
            this.btnBusinessLeadershipDelete.UseVisualStyleBackColor = true;
            this.btnBusinessLeadershipDelete.Click += new System.EventHandler(this.btnRoleDelete_Click);
            // 
            // btnAssistantDelete
            // 
            this.btnAssistantDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssistantDelete.Location = new System.Drawing.Point(105, 295);
            this.btnAssistantDelete.Name = "btnAssistantDelete";
            this.btnAssistantDelete.Size = new System.Drawing.Size(30, 23);
            this.btnAssistantDelete.TabIndex = 38;
            this.btnAssistantDelete.UseVisualStyleBackColor = true;
            this.btnAssistantDelete.Click += new System.EventHandler(this.btnRoleDelete_Click);
            // 
            // btnFinancialLeadershipDelete
            // 
            this.btnFinancialLeadershipDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinancialLeadershipDelete.Location = new System.Drawing.Point(105, 109);
            this.btnFinancialLeadershipDelete.Name = "btnFinancialLeadershipDelete";
            this.btnFinancialLeadershipDelete.Size = new System.Drawing.Size(30, 23);
            this.btnFinancialLeadershipDelete.TabIndex = 34;
            this.btnFinancialLeadershipDelete.UseVisualStyleBackColor = true;
            this.btnFinancialLeadershipDelete.Click += new System.EventHandler(this.btnRoleDelete_Click);
            // 
            // btnManagerDelete
            // 
            this.btnManagerDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManagerDelete.Location = new System.Drawing.Point(105, 202);
            this.btnManagerDelete.Name = "btnManagerDelete";
            this.btnManagerDelete.Size = new System.Drawing.Size(30, 23);
            this.btnManagerDelete.TabIndex = 36;
            this.btnManagerDelete.UseVisualStyleBackColor = true;
            this.btnManagerDelete.Click += new System.EventHandler(this.btnRoleDelete_Click);
            // 
            // btnLeadershipDelete
            // 
            this.btnLeadershipDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLeadershipDelete.Location = new System.Drawing.Point(105, 17);
            this.btnLeadershipDelete.Name = "btnLeadershipDelete";
            this.btnLeadershipDelete.Size = new System.Drawing.Size(30, 23);
            this.btnLeadershipDelete.TabIndex = 32;
            this.btnLeadershipDelete.UseVisualStyleBackColor = true;
            this.btnLeadershipDelete.Click += new System.EventHandler(this.btnRoleDelete_Click);
            // 
            // btnAssistant
            // 
            this.btnAssistant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssistant.Location = new System.Drawing.Point(13, 295);
            this.btnAssistant.Name = "btnAssistant";
            this.btnAssistant.Size = new System.Drawing.Size(91, 23);
            this.btnAssistant.TabIndex = 12;
            this.btnAssistant.Text = "助理";
            this.btnAssistant.UseVisualStyleBackColor = true;
            this.btnAssistant.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // txtAssistant
            // 
            this.txtAssistant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssistant.Location = new System.Drawing.Point(13, 319);
            this.txtAssistant.MaxLength = 80;
            this.txtAssistant.Name = "txtAssistant";
            this.txtAssistant.ReadOnly = true;
            this.txtAssistant.Size = new System.Drawing.Size(120, 21);
            this.txtAssistant.TabIndex = 13;
            // 
            // btnPersonnelLeadership
            // 
            this.btnPersonnelLeadership.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPersonnelLeadership.Location = new System.Drawing.Point(13, 156);
            this.btnPersonnelLeadership.Name = "btnPersonnelLeadership";
            this.btnPersonnelLeadership.Size = new System.Drawing.Size(91, 23);
            this.btnPersonnelLeadership.TabIndex = 6;
            this.btnPersonnelLeadership.Text = "人事分管领导";
            this.btnPersonnelLeadership.UseVisualStyleBackColor = true;
            this.btnPersonnelLeadership.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // txtPersonnelLeadership
            // 
            this.txtPersonnelLeadership.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPersonnelLeadership.BackColor = System.Drawing.Color.Bisque;
            this.txtPersonnelLeadership.Location = new System.Drawing.Point(13, 180);
            this.txtPersonnelLeadership.MaxLength = 80;
            this.txtPersonnelLeadership.Name = "txtPersonnelLeadership";
            this.txtPersonnelLeadership.ReadOnly = true;
            this.txtPersonnelLeadership.Size = new System.Drawing.Size(120, 21);
            this.txtPersonnelLeadership.TabIndex = 7;
            // 
            // btnFinancialLeadership
            // 
            this.btnFinancialLeadership.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinancialLeadership.Location = new System.Drawing.Point(13, 109);
            this.btnFinancialLeadership.Name = "btnFinancialLeadership";
            this.btnFinancialLeadership.Size = new System.Drawing.Size(91, 23);
            this.btnFinancialLeadership.TabIndex = 4;
            this.btnFinancialLeadership.Text = "财务分管领导";
            this.btnFinancialLeadership.UseVisualStyleBackColor = true;
            this.btnFinancialLeadership.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // txtFinancialLeadership
            // 
            this.txtFinancialLeadership.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFinancialLeadership.BackColor = System.Drawing.Color.Bisque;
            this.txtFinancialLeadership.Location = new System.Drawing.Point(13, 133);
            this.txtFinancialLeadership.MaxLength = 80;
            this.txtFinancialLeadership.Name = "txtFinancialLeadership";
            this.txtFinancialLeadership.ReadOnly = true;
            this.txtFinancialLeadership.Size = new System.Drawing.Size(120, 21);
            this.txtFinancialLeadership.TabIndex = 5;
            // 
            // btnPermission
            // 
            this.btnPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPermission.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPermission.Location = new System.Drawing.Point(10, 520);
            this.btnPermission.Name = "btnPermission";
            this.btnPermission.Size = new System.Drawing.Size(104, 23);
            this.btnPermission.TabIndex = 28;
            this.btnPermission.Text = "权限(&P)...";
            this.btnPermission.UseVisualStyleBackColor = true;
            this.btnPermission.Click += new System.EventHandler(this.btnPermission_Click);
            // 
            // btnLikeAdd
            // 
            this.btnLikeAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLikeAdd.Location = new System.Drawing.Point(120, 520);
            this.btnLikeAdd.Name = "btnLikeAdd";
            this.btnLikeAdd.Size = new System.Drawing.Size(113, 23);
            this.btnLikeAdd.TabIndex = 29;
            this.btnLikeAdd.Text = "类似添加(&A)";
            this.btnLikeAdd.UseVisualStyleBackColor = true;
            this.btnLikeAdd.Click += new System.EventHandler(this.btnLikeAdd_Click);
            // 
            // FrmOrganizeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(635, 552);
            this.Controls.Add(this.btnLikeAdd);
            this.Controls.Add(this.btnPermission);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtWeb);
            this.Controls.Add(this.lblWeb);
            this.Controls.Add(this.txtPostalcode);
            this.Controls.Add(this.lblPostalcode);
            this.Controls.Add(this.lblParentReq);
            this.Controls.Add(this.ucParent);
            this.Controls.Add(this.chkIsInnerOrganize);
            this.Controls.Add(this.lblFullNameReq);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.lblParentOrganize);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtInnerPhone);
            this.Controls.Add(this.txtOuterPhone);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.lblInnerPhone);
            this.Controls.Add(this.lblOuterPhone);
            this.Controls.Add(this.lblFax);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grbOrganize);
            this.Controls.Add(this.grbDuty);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmOrganizeEdit";
            this.Text = "编辑组织机构";
            this.grbOrganize.ResumeLayout(false);
            this.grbOrganize.PerformLayout();
            this.grbDuty.ResumeLayout(false);
            this.grbDuty.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtWeb;
        private System.Windows.Forms.Label lblWeb;
        private System.Windows.Forms.TextBox txtPostalcode;
        private System.Windows.Forms.Label lblPostalcode;
        private System.Windows.Forms.Label lblParentReq;
        private DotNet.WinForm.UCOrganizeSelect ucParent;
        private System.Windows.Forms.CheckBox chkIsInnerOrganize;
        private System.Windows.Forms.Label lblFullNameReq;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Label lblParentOrganize;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtInnerPhone;
        private System.Windows.Forms.TextBox txtOuterPhone;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label lblInnerPhone;
        private System.Windows.Forms.Label lblOuterPhone;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSystemManager;
        private System.Windows.Forms.Button btnAccounting;
        private System.Windows.Forms.Button btnCashier;
        private System.Windows.Forms.Button btnFinancial;
        private System.Windows.Forms.Button btnAssistantManager;
        private System.Windows.Forms.Button btnManager;
        private System.Windows.Forms.Button btnBusinessLeadership;
        private System.Windows.Forms.Button btnLeadership;
        private System.Windows.Forms.GroupBox grbOrganize;
        private System.Windows.Forms.TextBox txtLeadership;
        private System.Windows.Forms.TextBox txtBusinessLeadership;
        private System.Windows.Forms.TextBox txtManager;
        private System.Windows.Forms.TextBox txtAssistantManager;
        private System.Windows.Forms.TextBox txtFinancial;
        private System.Windows.Forms.TextBox txtAccounting;
        private System.Windows.Forms.TextBox txtCashier;
        private System.Windows.Forms.TextBox txtSystemManager;
        private System.Windows.Forms.GroupBox grbDuty;
        private System.Windows.Forms.Button btnPermission;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnPersonnelLeadership;
        private System.Windows.Forms.TextBox txtPersonnelLeadership;
        private System.Windows.Forms.Button btnFinancialLeadership;
        private System.Windows.Forms.TextBox txtFinancialLeadership;
        private System.Windows.Forms.Button btnAssistant;
        private System.Windows.Forms.TextBox txtAssistant;
        private System.Windows.Forms.Button btnLikeAdd;
        private System.Windows.Forms.Button btnLeadershipDelete;
        private System.Windows.Forms.Button btnSystemManagerDelete;
        private System.Windows.Forms.Button btnFinancialDelete;
        private System.Windows.Forms.Button btnAccountingDelete;
        private System.Windows.Forms.Button btnCashierDelete;
        private System.Windows.Forms.Button btnPersonnelLeadershipDelete;
        private System.Windows.Forms.Button btnAssistantManagerDelete;
        private System.Windows.Forms.Button btnBusinessLeadershipDelete;
        private System.Windows.Forms.Button btnAssistantDelete;
        private System.Windows.Forms.Button btnFinancialLeadershipDelete;
        private System.Windows.Forms.Button btnManagerDelete;
        private System.Windows.Forms.TextBox txtShortName;
        private System.Windows.Forms.Label lblShortName;

    }
}