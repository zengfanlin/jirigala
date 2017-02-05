namespace DotNet.WinForm
{
    partial class FrmModuleEdit
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
            this.lblParent = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblFullNameReq = new System.Windows.Forms.Label();
            this.lblCodeReq = new System.Windows.Forms.Label();
            this.ucParent = new DotNet.WinForm.UCModuleSelect();
            this.chkIsPublic = new System.Windows.Forms.CheckBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnAccessPermission = new System.Windows.Forms.Button();
            this.grbModule = new System.Windows.Forms.GroupBox();
            this.btnSetTarget = new System.Windows.Forms.Button();
            this.btnSetAssemblyName = new System.Windows.Forms.Button();
            this.lblAssembly = new System.Windows.Forms.Label();
            this.txtAssemblyName = new System.Windows.Forms.TextBox();
            this.txtFormName = new System.Windows.Forms.TextBox();
            this.lblFormName = new System.Windows.Forms.Label();
            this.txtNavigateUrl = new System.Windows.Forms.TextBox();
            this.lblTarget = new System.Windows.Forms.Label();
            this.lblNavigateUrl = new System.Windows.Forms.Label();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.chkExpand = new System.Windows.Forms.CheckBox();
            this.btnLikeAdd = new System.Windows.Forms.Button();
            this.grbModule.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblParent
            // 
            this.lblParent.Location = new System.Drawing.Point(17, 32);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(106, 12);
            this.lblParent.TabIndex = 0;
            this.lblParent.Text = "父节点：";
            this.lblParent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(124, 320);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(420, 43);
            this.txtDescription.TabIndex = 22;
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.Location = new System.Drawing.Point(124, 88);
            this.txtFullName.MaxLength = 50;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(420, 21);
            this.txtFullName.TabIndex = 5;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(124, 119);
            this.txtCode.MaxLength = 100;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(420, 21);
            this.txtCode.TabIndex = 8;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(17, 319);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(106, 12);
            this.lblDescription.TabIndex = 21;
            this.lblDescription.Text = "描述：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(17, 91);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(106, 12);
            this.lblFullName.TabIndex = 4;
            this.lblFullName.Text = "名称：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(17, 123);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(106, 12);
            this.lblCode.TabIndex = 7;
            this.lblCode.Text = "编号：";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(512, 407);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(431, 407);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblFullNameReq
            // 
            this.lblFullNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullNameReq.AutoSize = true;
            this.lblFullNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblFullNameReq.Location = new System.Drawing.Point(549, 93);
            this.lblFullNameReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFullNameReq.Name = "lblFullNameReq";
            this.lblFullNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblFullNameReq.TabIndex = 6;
            this.lblFullNameReq.Text = "*";
            // 
            // lblCodeReq
            // 
            this.lblCodeReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCodeReq.AutoSize = true;
            this.lblCodeReq.ForeColor = System.Drawing.Color.Red;
            this.lblCodeReq.Location = new System.Drawing.Point(549, 124);
            this.lblCodeReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCodeReq.Name = "lblCodeReq";
            this.lblCodeReq.Size = new System.Drawing.Size(11, 12);
            this.lblCodeReq.TabIndex = 9;
            this.lblCodeReq.Text = "*";
            // 
            // ucParent
            // 
            this.ucParent.AllowNull = true;
            this.ucParent.AllowSelect = true;
            this.ucParent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucParent.CheckMove = true;
            this.ucParent.Location = new System.Drawing.Point(124, 29);
            this.ucParent.MultiSelect = false;
            this.ucParent.Name = "ucParent";
            this.ucParent.OpenId = "";
            this.ucParent.SelectedCode = "";
            this.ucParent.SelectedFullName = "";
            this.ucParent.SelectedId = "";
            this.ucParent.Size = new System.Drawing.Size(420, 21);
            this.ucParent.TabIndex = 1;
            // 
            // chkIsPublic
            // 
            this.chkIsPublic.AutoSize = true;
            this.chkIsPublic.Location = new System.Drawing.Point(268, 286);
            this.chkIsPublic.Name = "chkIsPublic";
            this.chkIsPublic.Size = new System.Drawing.Size(48, 16);
            this.chkIsPublic.TabIndex = 20;
            this.chkIsPublic.Text = "公开";
            this.chkIsPublic.UseVisualStyleBackColor = true;
            this.chkIsPublic.CheckedChanged += new System.EventHandler(this.chkIsPublic_CheckedChanged);
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(124, 286);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(48, 16);
            this.chkEnabled.TabIndex = 18;
            this.chkEnabled.Text = "有效";
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.CheckedChanged += new System.EventHandler(this.chkEnabled_CheckedChanged);
            // 
            // lblId
            // 
            this.lblId.Location = new System.Drawing.Point(17, 62);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(106, 12);
            this.lblId.TabIndex = 2;
            this.lblId.Text = "主键：";
            this.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtId
            // 
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtId.Location = new System.Drawing.Point(124, 58);
            this.txtId.MaxLength = 100;
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(420, 21);
            this.txtId.TabIndex = 3;
            // 
            // btnAccessPermission
            // 
            this.btnAccessPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccessPermission.Location = new System.Drawing.Point(12, 407);
            this.btnAccessPermission.Name = "btnAccessPermission";
            this.btnAccessPermission.Size = new System.Drawing.Size(134, 23);
            this.btnAccessPermission.TabIndex = 1;
            this.btnAccessPermission.Text = "访问权限(&P)...";
            this.btnAccessPermission.UseVisualStyleBackColor = true;
            this.btnAccessPermission.Click += new System.EventHandler(this.btnAccessPermission_Click);
            // 
            // grbModule
            // 
            this.grbModule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbModule.Controls.Add(this.btnSetTarget);
            this.grbModule.Controls.Add(this.btnSetAssemblyName);
            this.grbModule.Controls.Add(this.lblAssembly);
            this.grbModule.Controls.Add(this.txtAssemblyName);
            this.grbModule.Controls.Add(this.lblFullNameReq);
            this.grbModule.Controls.Add(this.lblCodeReq);
            this.grbModule.Controls.Add(this.txtId);
            this.grbModule.Controls.Add(this.txtFormName);
            this.grbModule.Controls.Add(this.lblId);
            this.grbModule.Controls.Add(this.lblFormName);
            this.grbModule.Controls.Add(this.ucParent);
            this.grbModule.Controls.Add(this.txtNavigateUrl);
            this.grbModule.Controls.Add(this.lblTarget);
            this.grbModule.Controls.Add(this.lblParent);
            this.grbModule.Controls.Add(this.lblNavigateUrl);
            this.grbModule.Controls.Add(this.txtFullName);
            this.grbModule.Controls.Add(this.txtTarget);
            this.grbModule.Controls.Add(this.txtCode);
            this.grbModule.Controls.Add(this.chkExpand);
            this.grbModule.Controls.Add(this.lblFullName);
            this.grbModule.Controls.Add(this.chkIsPublic);
            this.grbModule.Controls.Add(this.lblCode);
            this.grbModule.Controls.Add(this.chkEnabled);
            this.grbModule.Controls.Add(this.txtDescription);
            this.grbModule.Controls.Add(this.lblDescription);
            this.grbModule.Location = new System.Drawing.Point(14, 15);
            this.grbModule.Name = "grbModule";
            this.grbModule.Size = new System.Drawing.Size(579, 379);
            this.grbModule.TabIndex = 0;
            this.grbModule.TabStop = false;
            this.grbModule.Text = "模块菜单";
            // 
            // btnSetTarget
            // 
            this.btnSetTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetTarget.Location = new System.Drawing.Point(547, 180);
            this.btnSetTarget.Name = "btnSetTarget";
            this.btnSetTarget.Size = new System.Drawing.Size(24, 23);
            this.btnSetTarget.TabIndex = 32;
            this.btnSetTarget.UseVisualStyleBackColor = true;
            this.btnSetTarget.Click += new System.EventHandler(this.btnSetTarget_Click);
            // 
            // btnSetAssemblyName
            // 
            this.btnSetAssemblyName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetAssemblyName.Location = new System.Drawing.Point(547, 247);
            this.btnSetAssemblyName.Name = "btnSetAssemblyName";
            this.btnSetAssemblyName.Size = new System.Drawing.Size(24, 23);
            this.btnSetAssemblyName.TabIndex = 32;
            this.btnSetAssemblyName.UseVisualStyleBackColor = true;
            this.btnSetAssemblyName.Click += new System.EventHandler(this.btnSetAssemblyName_Click);
            // 
            // lblAssembly
            // 
            this.lblAssembly.Location = new System.Drawing.Point(17, 252);
            this.lblAssembly.Name = "lblAssembly";
            this.lblAssembly.Size = new System.Drawing.Size(106, 12);
            this.lblAssembly.TabIndex = 16;
            this.lblAssembly.Text = "动态连接库：";
            this.lblAssembly.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAssemblyName
            // 
            this.txtAssemblyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssemblyName.BackColor = System.Drawing.Color.AliceBlue;
            this.txtAssemblyName.Location = new System.Drawing.Point(124, 248);
            this.txtAssemblyName.MaxLength = 100;
            this.txtAssemblyName.Name = "txtAssemblyName";
            this.txtAssemblyName.Size = new System.Drawing.Size(420, 21);
            this.txtAssemblyName.TabIndex = 17;
            this.txtAssemblyName.Text = "DotNet.WinForm";
            // 
            // txtFormName
            // 
            this.txtFormName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFormName.BackColor = System.Drawing.Color.AliceBlue;
            this.txtFormName.Location = new System.Drawing.Point(124, 221);
            this.txtFormName.MaxLength = 200;
            this.txtFormName.Name = "txtFormName";
            this.txtFormName.Size = new System.Drawing.Size(420, 21);
            this.txtFormName.TabIndex = 15;
            // 
            // lblFormName
            // 
            this.lblFormName.Location = new System.Drawing.Point(17, 225);
            this.lblFormName.Name = "lblFormName";
            this.lblFormName.Size = new System.Drawing.Size(106, 12);
            this.lblFormName.TabIndex = 14;
            this.lblFormName.Text = "窗体名：";
            this.lblFormName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNavigateUrl
            // 
            this.txtNavigateUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNavigateUrl.BackColor = System.Drawing.Color.Cornsilk;
            this.txtNavigateUrl.Location = new System.Drawing.Point(124, 150);
            this.txtNavigateUrl.MaxLength = 200;
            this.txtNavigateUrl.Name = "txtNavigateUrl";
            this.txtNavigateUrl.Size = new System.Drawing.Size(420, 21);
            this.txtNavigateUrl.TabIndex = 11;
            // 
            // lblTarget
            // 
            this.lblTarget.Location = new System.Drawing.Point(17, 184);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(106, 12);
            this.lblTarget.TabIndex = 12;
            this.lblTarget.Text = "目标窗体中打开：";
            this.lblTarget.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNavigateUrl
            // 
            this.lblNavigateUrl.Location = new System.Drawing.Point(17, 154);
            this.lblNavigateUrl.Name = "lblNavigateUrl";
            this.lblNavigateUrl.Size = new System.Drawing.Size(106, 12);
            this.lblNavigateUrl.TabIndex = 10;
            this.lblNavigateUrl.Text = "Web网址：";
            this.lblNavigateUrl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTarget
            // 
            this.txtTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTarget.BackColor = System.Drawing.Color.Cornsilk;
            this.txtTarget.Location = new System.Drawing.Point(124, 181);
            this.txtTarget.MaxLength = 100;
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(420, 21);
            this.txtTarget.TabIndex = 13;
            this.txtTarget.Text = "fraContent";
            // 
            // chkExpand
            // 
            this.chkExpand.AutoSize = true;
            this.chkExpand.Location = new System.Drawing.Point(198, 286);
            this.chkExpand.Name = "chkExpand";
            this.chkExpand.Size = new System.Drawing.Size(48, 16);
            this.chkExpand.TabIndex = 19;
            this.chkExpand.Text = "展开";
            this.chkExpand.UseVisualStyleBackColor = true;
            // 
            // btnLikeAdd
            // 
            this.btnLikeAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLikeAdd.Location = new System.Drawing.Point(152, 407);
            this.btnLikeAdd.Name = "btnLikeAdd";
            this.btnLikeAdd.Size = new System.Drawing.Size(113, 23);
            this.btnLikeAdd.TabIndex = 2;
            this.btnLikeAdd.Text = "类似添加(&A)";
            this.btnLikeAdd.UseVisualStyleBackColor = true;
            this.btnLikeAdd.Click += new System.EventHandler(this.btnLikeAdd_Click);
            // 
            // FrmModuleEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(605, 441);
            this.Controls.Add(this.btnLikeAdd);
            this.Controls.Add(this.btnAccessPermission);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grbModule);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmModuleEdit";
            this.Text = "编辑菜单";
            this.grbModule.ResumeLayout(false);
            this.grbModule.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblParent;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblFullNameReq;
        private System.Windows.Forms.Label lblCodeReq;
        private DotNet.WinForm.UCModuleSelect ucParent;
        private System.Windows.Forms.CheckBox chkIsPublic;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnAccessPermission;
        private System.Windows.Forms.GroupBox grbModule;
        private System.Windows.Forms.Button btnLikeAdd;
        private System.Windows.Forms.CheckBox chkExpand;
        private System.Windows.Forms.Label lblAssembly;
        private System.Windows.Forms.TextBox txtAssemblyName;
        private System.Windows.Forms.TextBox txtFormName;
        private System.Windows.Forms.Label lblFormName;
        private System.Windows.Forms.TextBox txtNavigateUrl;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.Label lblNavigateUrl;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.Button btnSetTarget;
        private System.Windows.Forms.Button btnSetAssemblyName;

    }
}