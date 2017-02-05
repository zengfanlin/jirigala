namespace DotNet.WinForm
{
    partial class FrmWorkFlowProcessAdd
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grbWorkFlow = new System.Windows.Forms.GroupBox();
            this.lblWorkCategoryReq = new System.Windows.Forms.Label();
            this.lblWorkFlowCodeReq = new System.Windows.Forms.Label();
            this.lblRoleReq = new System.Windows.Forms.Label();
            this.lblBillTemplate = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.cmbAuditCategoryCode = new System.Windows.Forms.ComboBox();
            this.lblAuditCategoryCode = new System.Windows.Forms.Label();
            this.cmbWorkFlowCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.ucOrganize = new DotNet.WinForm.UCOrganizeSelect();
            this.lblFullNameReq = new System.Windows.Forms.Label();
            this.lblCodeReq = new System.Windows.Forms.Label();
            this.lblParentReq = new System.Windows.Forms.Label();
            this.lblParent = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.ucUser = new DotNet.WinForm.UCUserSelect();
            this.lstbBillTemlate = new System.Windows.Forms.ListBox();
            this.grbWorkFlow.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(409, 563);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(328, 563);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grbWorkFlow
            // 
            this.grbWorkFlow.Controls.Add(this.lstbBillTemlate);
            this.grbWorkFlow.Controls.Add(this.ucUser);
            this.grbWorkFlow.Controls.Add(this.lblWorkCategoryReq);
            this.grbWorkFlow.Controls.Add(this.lblWorkFlowCodeReq);
            this.grbWorkFlow.Controls.Add(this.lblRoleReq);
            this.grbWorkFlow.Controls.Add(this.lblBillTemplate);
            this.grbWorkFlow.Controls.Add(this.lblRole);
            this.grbWorkFlow.Controls.Add(this.cmbAuditCategoryCode);
            this.grbWorkFlow.Controls.Add(this.lblAuditCategoryCode);
            this.grbWorkFlow.Controls.Add(this.cmbWorkFlowCategory);
            this.grbWorkFlow.Controls.Add(this.lblCategory);
            this.grbWorkFlow.Controls.Add(this.ucOrganize);
            this.grbWorkFlow.Controls.Add(this.lblFullNameReq);
            this.grbWorkFlow.Controls.Add(this.lblCodeReq);
            this.grbWorkFlow.Controls.Add(this.lblParentReq);
            this.grbWorkFlow.Controls.Add(this.lblParent);
            this.grbWorkFlow.Controls.Add(this.txtCode);
            this.grbWorkFlow.Controls.Add(this.lblCode);
            this.grbWorkFlow.Controls.Add(this.txtDescription);
            this.grbWorkFlow.Controls.Add(this.lblDescription);
            this.grbWorkFlow.Controls.Add(this.chkEnabled);
            this.grbWorkFlow.Controls.Add(this.txtFullName);
            this.grbWorkFlow.Controls.Add(this.lblFullName);
            this.grbWorkFlow.Location = new System.Drawing.Point(12, 12);
            this.grbWorkFlow.Name = "grbWorkFlow";
            this.grbWorkFlow.Size = new System.Drawing.Size(474, 545);
            this.grbWorkFlow.TabIndex = 16;
            this.grbWorkFlow.TabStop = false;
            this.grbWorkFlow.Text = "添加审批流程：";
            // 
            // lblWorkCategoryReq
            // 
            this.lblWorkCategoryReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWorkCategoryReq.AutoSize = true;
            this.lblWorkCategoryReq.ForeColor = System.Drawing.Color.Red;
            this.lblWorkCategoryReq.Location = new System.Drawing.Point(452, 183);
            this.lblWorkCategoryReq.Name = "lblWorkCategoryReq";
            this.lblWorkCategoryReq.Size = new System.Drawing.Size(11, 12);
            this.lblWorkCategoryReq.TabIndex = 35;
            this.lblWorkCategoryReq.Text = "*";
            // 
            // lblWorkFlowCodeReq
            // 
            this.lblWorkFlowCodeReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWorkFlowCodeReq.AutoSize = true;
            this.lblWorkFlowCodeReq.ForeColor = System.Drawing.Color.Red;
            this.lblWorkFlowCodeReq.Location = new System.Drawing.Point(454, 31);
            this.lblWorkFlowCodeReq.Name = "lblWorkFlowCodeReq";
            this.lblWorkFlowCodeReq.Size = new System.Drawing.Size(11, 12);
            this.lblWorkFlowCodeReq.TabIndex = 34;
            this.lblWorkFlowCodeReq.Text = "*";
            // 
            // lblRoleReq
            // 
            this.lblRoleReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRoleReq.AutoSize = true;
            this.lblRoleReq.ForeColor = System.Drawing.Color.Red;
            this.lblRoleReq.Location = new System.Drawing.Point(453, 61);
            this.lblRoleReq.Name = "lblRoleReq";
            this.lblRoleReq.Size = new System.Drawing.Size(11, 12);
            this.lblRoleReq.TabIndex = 33;
            this.lblRoleReq.Text = "*";
            // 
            // lblBillTemplate
            // 
            this.lblBillTemplate.Location = new System.Drawing.Point(14, 213);
            this.lblBillTemplate.Name = "lblBillTemplate";
            this.lblBillTemplate.Size = new System.Drawing.Size(105, 12);
            this.lblBillTemplate.TabIndex = 31;
            this.lblBillTemplate.Text = "单据名称：";
            this.lblBillTemplate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRole
            // 
            this.lblRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRole.Location = new System.Drawing.Point(34, 61);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(85, 12);
            this.lblRole.TabIndex = 17;
            this.lblRole.Text = "用户(&U)：";
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbAuditCategoryCode
            // 
            this.cmbAuditCategoryCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAuditCategoryCode.Location = new System.Drawing.Point(125, 27);
            this.cmbAuditCategoryCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbAuditCategoryCode.Name = "cmbAuditCategoryCode";
            this.cmbAuditCategoryCode.Size = new System.Drawing.Size(322, 20);
            this.cmbAuditCategoryCode.TabIndex = 29;
            this.cmbAuditCategoryCode.SelectedIndexChanged += new System.EventHandler(this.cmbAuditCategoryCode_SelectedIndexChanged);
            // 
            // lblAuditCategoryCode
            // 
            this.lblAuditCategoryCode.Location = new System.Drawing.Point(45, 29);
            this.lblAuditCategoryCode.Name = "lblAuditCategoryCode";
            this.lblAuditCategoryCode.Size = new System.Drawing.Size(74, 16);
            this.lblAuditCategoryCode.TabIndex = 28;
            this.lblAuditCategoryCode.Text = "流程类型：";
            this.lblAuditCategoryCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbWorkFlowCategory
            // 
            this.cmbWorkFlowCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbWorkFlowCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkFlowCategory.Location = new System.Drawing.Point(124, 178);
            this.cmbWorkFlowCategory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbWorkFlowCategory.Name = "cmbWorkFlowCategory";
            this.cmbWorkFlowCategory.Size = new System.Drawing.Size(323, 20);
            this.cmbWorkFlowCategory.TabIndex = 24;
            this.cmbWorkFlowCategory.SelectedIndexChanged += new System.EventHandler(this.cmbWorkFlowCategory_SelectedIndexChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.Location = new System.Drawing.Point(14, 183);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(105, 12);
            this.lblCategory.TabIndex = 23;
            this.lblCategory.Text = "分类：";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucOrganize
            // 
            this.ucOrganize.AllowNull = true;
            this.ucOrganize.AllowSelect = true;
            this.ucOrganize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucOrganize.AutoSize = true;
            this.ucOrganize.CanEdit = false;
            this.ucOrganize.CheckMove = false;
            this.ucOrganize.Location = new System.Drawing.Point(125, 88);
            this.ucOrganize.MultiSelect = false;
            this.ucOrganize.Name = "ucOrganize";
            this.ucOrganize.OpenId = "";
            this.ucOrganize.PermissionItemScopeCode = "";
            this.ucOrganize.SelectedFullName = "";
            this.ucOrganize.SelectedId = "";
            this.ucOrganize.Size = new System.Drawing.Size(322, 23);
            this.ucOrganize.TabIndex = 15;
            // 
            // lblFullNameReq
            // 
            this.lblFullNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullNameReq.AutoSize = true;
            this.lblFullNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblFullNameReq.Location = new System.Drawing.Point(453, 122);
            this.lblFullNameReq.Name = "lblFullNameReq";
            this.lblFullNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblFullNameReq.TabIndex = 19;
            this.lblFullNameReq.Text = "*";
            // 
            // lblCodeReq
            // 
            this.lblCodeReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCodeReq.AutoSize = true;
            this.lblCodeReq.ForeColor = System.Drawing.Color.Red;
            this.lblCodeReq.Location = new System.Drawing.Point(453, 149);
            this.lblCodeReq.Name = "lblCodeReq";
            this.lblCodeReq.Size = new System.Drawing.Size(11, 12);
            this.lblCodeReq.TabIndex = 22;
            this.lblCodeReq.Text = "*";
            // 
            // lblParentReq
            // 
            this.lblParentReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblParentReq.AutoSize = true;
            this.lblParentReq.ForeColor = System.Drawing.Color.Red;
            this.lblParentReq.Location = new System.Drawing.Point(453, 91);
            this.lblParentReq.Name = "lblParentReq";
            this.lblParentReq.Size = new System.Drawing.Size(11, 12);
            this.lblParentReq.TabIndex = 16;
            this.lblParentReq.Text = "*";
            // 
            // lblParent
            // 
            this.lblParent.Location = new System.Drawing.Point(14, 93);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(105, 12);
            this.lblParent.TabIndex = 14;
            this.lblParent.Text = "组织机构(&O)：";
            this.lblParent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(125, 146);
            this.txtCode.MaxLength = 50;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(322, 21);
            this.txtCode.TabIndex = 21;
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(14, 151);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(105, 12);
            this.lblCode.TabIndex = 20;
            this.lblCode.Text = "编号(&C)：";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(125, 415);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(322, 106);
            this.txtDescription.TabIndex = 27;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(14, 415);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(105, 12);
            this.lblDescription.TabIndex = 26;
            this.lblDescription.Text = "描述(&D)：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(125, 393);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(48, 16);
            this.chkEnabled.TabIndex = 25;
            this.chkEnabled.Text = "有效";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.Location = new System.Drawing.Point(125, 119);
            this.txtFullName.MaxLength = 50;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(322, 21);
            this.txtFullName.TabIndex = 18;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(14, 123);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(105, 12);
            this.lblFullName.TabIndex = 17;
            this.lblFullName.Text = "名称(&N)：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucUser
            // 
            this.ucUser.AllowNull = true;
            this.ucUser.AllowSelect = true;
            this.ucUser.Location = new System.Drawing.Point(125, 56);
            this.ucUser.MultiSelect = false;
            this.ucUser.Name = "ucUser";
            this.ucUser.OpenId = "";
            this.ucUser.PermissionItemScopeCode = "";
            this.ucUser.RemoveIds = null;
            this.ucUser.SelectedFullName = "";
            this.ucUser.SelectedId = "";
            this.ucUser.SelectedIds = null;
            this.ucUser.SetSelectIds = null;
            this.ucUser.Size = new System.Drawing.Size(322, 22);
            this.ucUser.TabIndex = 36;
            // 
            // lstbBillTemlate
            // 
            this.lstbBillTemlate.FormattingEnabled = true;
            this.lstbBillTemlate.ItemHeight = 12;
            this.lstbBillTemlate.Location = new System.Drawing.Point(125, 213);
            this.lstbBillTemlate.Name = "lstbBillTemlate";
            this.lstbBillTemlate.Size = new System.Drawing.Size(322, 172);
            this.lstbBillTemlate.TabIndex = 38;
            // 
            // FrmWorkFlowProcessAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(498, 594);
            this.Controls.Add(this.grbWorkFlow);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWorkFlowProcessAdd";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "添加审批流程";
            this.grbWorkFlow.ResumeLayout(false);
            this.grbWorkFlow.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox grbWorkFlow;
        private System.Windows.Forms.ComboBox cmbWorkFlowCategory;
        private System.Windows.Forms.Label lblCategory;
        private UCOrganizeSelect ucOrganize;
        private System.Windows.Forms.Label lblFullNameReq;
        private System.Windows.Forms.Label lblCodeReq;
        private System.Windows.Forms.Label lblParentReq;
        private System.Windows.Forms.Label lblParent;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.ComboBox cmbAuditCategoryCode;
        private System.Windows.Forms.Label lblAuditCategoryCode;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblBillTemplate;
        private System.Windows.Forms.Label lblWorkCategoryReq;
        private System.Windows.Forms.Label lblWorkFlowCodeReq;
        private System.Windows.Forms.Label lblRoleReq;
        private UCUserSelect ucUser;
        private System.Windows.Forms.ListBox lstbBillTemlate;




    }
}