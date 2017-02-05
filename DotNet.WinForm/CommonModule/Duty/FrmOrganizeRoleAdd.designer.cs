namespace DotNet.WinForm
{
    partial class FrmOrganizeRoleAdd
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
            this.grbOrganizeRole = new System.Windows.Forms.GroupBox();
            this.lblCodeReq = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.ucOrganize = new DotNet.WinForm.UCOrganizeSelect();
            this.lblFullNameReq = new System.Windows.Forms.Label();
            this.lblOrganizeReq = new System.Windows.Forms.Label();
            this.lblOrganize = new System.Windows.Forms.Label();
            this.txtRealName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnAssistant = new System.Windows.Forms.Button();
            this.btnPersonnelLeadership = new System.Windows.Forms.Button();
            this.btnFinancialLeadership = new System.Windows.Forms.Button();
            this.btnBusinessLeadership = new System.Windows.Forms.Button();
            this.btnSystemManager = new System.Windows.Forms.Button();
            this.btnAccounting = new System.Windows.Forms.Button();
            this.btnCashier = new System.Windows.Forms.Button();
            this.btnFinancial = new System.Windows.Forms.Button();
            this.btnAssistantManager = new System.Windows.Forms.Button();
            this.btnManager = new System.Windows.Forms.Button();
            this.btnLeadership = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grbOrganizeRole.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbOrganizeRole
            // 
            this.grbOrganizeRole.Controls.Add(this.lblCodeReq);
            this.grbOrganizeRole.Controls.Add(this.txtCode);
            this.grbOrganizeRole.Controls.Add(this.lblCode);
            this.grbOrganizeRole.Controls.Add(this.ucOrganize);
            this.grbOrganizeRole.Controls.Add(this.lblFullNameReq);
            this.grbOrganizeRole.Controls.Add(this.lblOrganizeReq);
            this.grbOrganizeRole.Controls.Add(this.lblOrganize);
            this.grbOrganizeRole.Controls.Add(this.txtRealName);
            this.grbOrganizeRole.Controls.Add(this.lblFullName);
            this.grbOrganizeRole.Controls.Add(this.chkEnabled);
            this.grbOrganizeRole.Controls.Add(this.txtDescription);
            this.grbOrganizeRole.Controls.Add(this.lblDescription);
            this.grbOrganizeRole.Location = new System.Drawing.Point(13, 13);
            this.grbOrganizeRole.Name = "grbOrganizeRole";
            this.grbOrganizeRole.Size = new System.Drawing.Size(422, 233);
            this.grbOrganizeRole.TabIndex = 0;
            this.grbOrganizeRole.TabStop = false;
            this.grbOrganizeRole.Text = "岗位";
            // 
            // lblCodeReq
            // 
            this.lblCodeReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCodeReq.AutoSize = true;
            this.lblCodeReq.ForeColor = System.Drawing.Color.Red;
            this.lblCodeReq.Location = new System.Drawing.Point(388, 92);
            this.lblCodeReq.Name = "lblCodeReq";
            this.lblCodeReq.Size = new System.Drawing.Size(11, 12);
            this.lblCodeReq.TabIndex = 34;
            this.lblCodeReq.Text = "*";
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(112, 87);
            this.txtCode.MaxLength = 50;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(270, 21);
            this.txtCode.TabIndex = 33;
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(25, 90);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(75, 12);
            this.lblCode.TabIndex = 32;
            this.lblCode.Text = "编号(&C)：";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucOrganize
            // 
            this.ucOrganize.AllowNull = true;
            this.ucOrganize.AllowSelect = true;
            this.ucOrganize.AutoSize = true;
            this.ucOrganize.CanEdit = false;
            this.ucOrganize.CheckMove = false;
            this.ucOrganize.Location = new System.Drawing.Point(112, 16);
            this.ucOrganize.MultiSelect = false;
            this.ucOrganize.Name = "ucOrganize";
            this.ucOrganize.OpenId = "";
            this.ucOrganize.PermissionItemScopeCode = "";
            this.ucOrganize.SelectedFullName = "";
            this.ucOrganize.SelectedId = "";
            this.ucOrganize.Size = new System.Drawing.Size(270, 23);
            this.ucOrganize.TabIndex = 27;
            // 
            // lblFullNameReq
            // 
            this.lblFullNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullNameReq.AutoSize = true;
            this.lblFullNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblFullNameReq.Location = new System.Drawing.Point(388, 58);
            this.lblFullNameReq.Name = "lblFullNameReq";
            this.lblFullNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblFullNameReq.TabIndex = 31;
            this.lblFullNameReq.Text = "*";
            // 
            // lblOrganizeReq
            // 
            this.lblOrganizeReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrganizeReq.AutoSize = true;
            this.lblOrganizeReq.ForeColor = System.Drawing.Color.Red;
            this.lblOrganizeReq.Location = new System.Drawing.Point(388, 22);
            this.lblOrganizeReq.Name = "lblOrganizeReq";
            this.lblOrganizeReq.Size = new System.Drawing.Size(11, 12);
            this.lblOrganizeReq.TabIndex = 28;
            this.lblOrganizeReq.Text = "*";
            // 
            // lblOrganize
            // 
            this.lblOrganize.Location = new System.Drawing.Point(25, 19);
            this.lblOrganize.Name = "lblOrganize";
            this.lblOrganize.Size = new System.Drawing.Size(75, 12);
            this.lblOrganize.TabIndex = 26;
            this.lblOrganize.Text = "机构(&O)：";
            this.lblOrganize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRealName
            // 
            this.txtRealName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRealName.Location = new System.Drawing.Point(112, 53);
            this.txtRealName.MaxLength = 50;
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.Size = new System.Drawing.Size(270, 21);
            this.txtRealName.TabIndex = 30;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(25, 56);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(75, 12);
            this.lblFullName.TabIndex = 29;
            this.lblFullName.Text = "名称(&F)：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(112, 122);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(48, 16);
            this.chkEnabled.TabIndex = 35;
            this.chkEnabled.Text = "有效";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(112, 154);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(270, 60);
            this.txtDescription.TabIndex = 37;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(25, 156);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(75, 12);
            this.lblDescription.TabIndex = 36;
            this.lblDescription.Text = "描述(&D)：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAssistant
            // 
            this.btnAssistant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssistant.Location = new System.Drawing.Point(318, 293);
            this.btnAssistant.Name = "btnAssistant";
            this.btnAssistant.Size = new System.Drawing.Size(91, 23);
            this.btnAssistant.TabIndex = 79;
            this.btnAssistant.Text = "助理";
            this.btnAssistant.UseVisualStyleBackColor = true;
            this.btnAssistant.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnPersonnelLeadership
            // 
            this.btnPersonnelLeadership.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPersonnelLeadership.Location = new System.Drawing.Point(225, 321);
            this.btnPersonnelLeadership.Name = "btnPersonnelLeadership";
            this.btnPersonnelLeadership.Size = new System.Drawing.Size(91, 23);
            this.btnPersonnelLeadership.TabIndex = 74;
            this.btnPersonnelLeadership.Text = "人事分管领导";
            this.btnPersonnelLeadership.UseVisualStyleBackColor = true;
            this.btnPersonnelLeadership.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnFinancialLeadership
            // 
            this.btnFinancialLeadership.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinancialLeadership.Location = new System.Drawing.Point(132, 321);
            this.btnFinancialLeadership.Name = "btnFinancialLeadership";
            this.btnFinancialLeadership.Size = new System.Drawing.Size(91, 23);
            this.btnFinancialLeadership.TabIndex = 73;
            this.btnFinancialLeadership.Text = "财务分管领导";
            this.btnFinancialLeadership.UseVisualStyleBackColor = true;
            this.btnFinancialLeadership.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnBusinessLeadership
            // 
            this.btnBusinessLeadership.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBusinessLeadership.Location = new System.Drawing.Point(40, 321);
            this.btnBusinessLeadership.Name = "btnBusinessLeadership";
            this.btnBusinessLeadership.Size = new System.Drawing.Size(91, 23);
            this.btnBusinessLeadership.TabIndex = 72;
            this.btnBusinessLeadership.Text = "业务分管领导";
            this.btnBusinessLeadership.UseVisualStyleBackColor = true;
            this.btnBusinessLeadership.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnSystemManager
            // 
            this.btnSystemManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSystemManager.Location = new System.Drawing.Point(318, 348);
            this.btnSystemManager.Name = "btnSystemManager";
            this.btnSystemManager.Size = new System.Drawing.Size(91, 23);
            this.btnSystemManager.TabIndex = 78;
            this.btnSystemManager.Text = "系统管理员";
            this.btnSystemManager.UseVisualStyleBackColor = true;
            this.btnSystemManager.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnAccounting
            // 
            this.btnAccounting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccounting.Location = new System.Drawing.Point(132, 348);
            this.btnAccounting.Name = "btnAccounting";
            this.btnAccounting.Size = new System.Drawing.Size(91, 23);
            this.btnAccounting.TabIndex = 76;
            this.btnAccounting.Text = "会计";
            this.btnAccounting.UseVisualStyleBackColor = true;
            this.btnAccounting.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnCashier
            // 
            this.btnCashier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCashier.Location = new System.Drawing.Point(225, 348);
            this.btnCashier.Name = "btnCashier";
            this.btnCashier.Size = new System.Drawing.Size(91, 23);
            this.btnCashier.TabIndex = 77;
            this.btnCashier.Text = "出纳";
            this.btnCashier.UseVisualStyleBackColor = true;
            this.btnCashier.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnFinancial
            // 
            this.btnFinancial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinancial.Location = new System.Drawing.Point(40, 348);
            this.btnFinancial.Name = "btnFinancial";
            this.btnFinancial.Size = new System.Drawing.Size(91, 23);
            this.btnFinancial.TabIndex = 75;
            this.btnFinancial.Text = "财务主管";
            this.btnFinancial.UseVisualStyleBackColor = true;
            this.btnFinancial.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnAssistantManager
            // 
            this.btnAssistantManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssistantManager.Location = new System.Drawing.Point(225, 293);
            this.btnAssistantManager.Name = "btnAssistantManager";
            this.btnAssistantManager.Size = new System.Drawing.Size(91, 23);
            this.btnAssistantManager.TabIndex = 71;
            this.btnAssistantManager.Text = "部门副主管";
            this.btnAssistantManager.UseVisualStyleBackColor = true;
            this.btnAssistantManager.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnManager
            // 
            this.btnManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManager.Location = new System.Drawing.Point(132, 293);
            this.btnManager.Name = "btnManager";
            this.btnManager.Size = new System.Drawing.Size(91, 23);
            this.btnManager.TabIndex = 70;
            this.btnManager.Text = "部门主管";
            this.btnManager.UseVisualStyleBackColor = true;
            this.btnManager.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnLeadership
            // 
            this.btnLeadership.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLeadership.Location = new System.Drawing.Point(40, 293);
            this.btnLeadership.Name = "btnLeadership";
            this.btnLeadership.Size = new System.Drawing.Size(91, 23);
            this.btnLeadership.TabIndex = 69;
            this.btnLeadership.Text = "公司领导";
            this.btnLeadership.UseVisualStyleBackColor = true;
            this.btnLeadership.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnSave.Location = new System.Drawing.Point(244, 256);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 23);
            this.btnSave.TabIndex = 67;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(323, 256);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 68;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(164, 256);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 66;
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FrmOrganizeRoleAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 394);
            this.Controls.Add(this.btnAssistant);
            this.Controls.Add(this.btnPersonnelLeadership);
            this.Controls.Add(this.btnFinancialLeadership);
            this.Controls.Add(this.btnBusinessLeadership);
            this.Controls.Add(this.btnSystemManager);
            this.Controls.Add(this.btnAccounting);
            this.Controls.Add(this.btnCashier);
            this.Controls.Add(this.btnFinancial);
            this.Controls.Add(this.btnAssistantManager);
            this.Controls.Add(this.btnManager);
            this.Controls.Add(this.btnLeadership);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.grbOrganizeRole);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOrganizeRoleAdd";
            this.Text = "添加岗位";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmOrganizeRoleAdd_FormClosing);
            this.grbOrganizeRole.ResumeLayout(false);
            this.grbOrganizeRole.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbOrganizeRole;
        private System.Windows.Forms.Label lblCodeReq;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblCode;
        private UCOrganizeSelect ucOrganize;
        private System.Windows.Forms.Label lblFullNameReq;
        private System.Windows.Forms.Label lblOrganizeReq;
        private System.Windows.Forms.Label lblOrganize;
        private System.Windows.Forms.TextBox txtRealName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnAssistant;
        private System.Windows.Forms.Button btnPersonnelLeadership;
        private System.Windows.Forms.Button btnFinancialLeadership;
        private System.Windows.Forms.Button btnBusinessLeadership;
        private System.Windows.Forms.Button btnSystemManager;
        private System.Windows.Forms.Button btnAccounting;
        private System.Windows.Forms.Button btnCashier;
        private System.Windows.Forms.Button btnFinancial;
        private System.Windows.Forms.Button btnAssistantManager;
        private System.Windows.Forms.Button btnManager;
        private System.Windows.Forms.Button btnLeadership;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;



    }
}