namespace DotNet.WinForm
{
    partial class FrmPermissionItemEdit
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLikeAdd = new System.Windows.Forms.Button();
            this.grbPermissionItem = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.chkIsScope = new System.Windows.Forms.CheckBox();
            this.ucParent = new DotNet.WinForm.UCPermissionSelect();
            this.lblParent = new System.Windows.Forms.Label();
            this.lblFullNameReq = new System.Windows.Forms.Label();
            this.lblCodeReq = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.grbPermissionItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(424, 277);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(345, 277);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLikeAdd
            // 
            this.btnLikeAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLikeAdd.Location = new System.Drawing.Point(12, 277);
            this.btnLikeAdd.Name = "btnLikeAdd";
            this.btnLikeAdd.Size = new System.Drawing.Size(113, 23);
            this.btnLikeAdd.TabIndex = 12;
            this.btnLikeAdd.Text = "类似添加(&A)";
            this.btnLikeAdd.UseVisualStyleBackColor = true;
            this.btnLikeAdd.Click += new System.EventHandler(this.btnLikeAdd_Click);
            // 
            // grbPermissionItem
            // 
            this.grbPermissionItem.Controls.Add(this.txtDescription);
            this.grbPermissionItem.Controls.Add(this.lblDescription);
            this.grbPermissionItem.Controls.Add(this.chkIsScope);
            this.grbPermissionItem.Controls.Add(this.ucParent);
            this.grbPermissionItem.Controls.Add(this.lblParent);
            this.grbPermissionItem.Controls.Add(this.lblFullNameReq);
            this.grbPermissionItem.Controls.Add(this.lblCodeReq);
            this.grbPermissionItem.Controls.Add(this.chkEnabled);
            this.grbPermissionItem.Controls.Add(this.txtFullName);
            this.grbPermissionItem.Controls.Add(this.txtCode);
            this.grbPermissionItem.Controls.Add(this.lblFullName);
            this.grbPermissionItem.Controls.Add(this.lblCode);
            this.grbPermissionItem.Location = new System.Drawing.Point(13, 13);
            this.grbPermissionItem.Name = "grbPermissionItem";
            this.grbPermissionItem.Size = new System.Drawing.Size(486, 253);
            this.grbPermissionItem.TabIndex = 15;
            this.grbPermissionItem.TabStop = false;
            this.grbPermissionItem.Text = "编辑操作权限项";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(128, 183);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(325, 50);
            this.txtDescription.TabIndex = 23;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.Location = new System.Drawing.Point(21, 183);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(103, 17);
            this.lblDescription.TabIndex = 22;
            this.lblDescription.Text = "描述(&D)：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkIsScope
            // 
            this.chkIsScope.AutoSize = true;
            this.chkIsScope.Location = new System.Drawing.Point(127, 128);
            this.chkIsScope.Name = "chkIsScope";
            this.chkIsScope.Size = new System.Drawing.Size(72, 16);
            this.chkIsScope.TabIndex = 20;
            this.chkIsScope.Text = "数据权限";
            this.chkIsScope.UseVisualStyleBackColor = true;
            // 
            // ucParent
            // 
            this.ucParent.AllowNull = true;
            this.ucParent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucParent.CheckMove = false;
            this.ucParent.Location = new System.Drawing.Point(127, 31);
            this.ucParent.MultiSelect = false;
            this.ucParent.Name = "ucParent";
            this.ucParent.OpenId = "";
            this.ucParent.SelectedFullName = "";
            this.ucParent.SelectedId = "";
            this.ucParent.SelectedIds = new string[0];
            this.ucParent.Size = new System.Drawing.Size(327, 22);
            this.ucParent.TabIndex = 13;
            // 
            // lblParent
            // 
            this.lblParent.Location = new System.Drawing.Point(21, 34);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(103, 17);
            this.lblParent.TabIndex = 12;
            this.lblParent.Text = "父节点(&P)：";
            this.lblParent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFullNameReq
            // 
            this.lblFullNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullNameReq.AutoSize = true;
            this.lblFullNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblFullNameReq.Location = new System.Drawing.Point(456, 71);
            this.lblFullNameReq.Name = "lblFullNameReq";
            this.lblFullNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblFullNameReq.TabIndex = 16;
            this.lblFullNameReq.Text = "*";
            // 
            // lblCodeReq
            // 
            this.lblCodeReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCodeReq.AutoSize = true;
            this.lblCodeReq.ForeColor = System.Drawing.Color.Red;
            this.lblCodeReq.Location = new System.Drawing.Point(456, 101);
            this.lblCodeReq.Name = "lblCodeReq";
            this.lblCodeReq.Size = new System.Drawing.Size(11, 12);
            this.lblCodeReq.TabIndex = 19;
            this.lblCodeReq.Text = "*";
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(127, 155);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(48, 16);
            this.chkEnabled.TabIndex = 21;
            this.chkEnabled.Text = "有效";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.Location = new System.Drawing.Point(127, 65);
            this.txtFullName.MaxLength = 100;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(325, 21);
            this.txtFullName.TabIndex = 15;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(127, 96);
            this.txtCode.MaxLength = 100;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(325, 21);
            this.txtCode.TabIndex = 18;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(21, 68);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(103, 17);
            this.lblFullName.TabIndex = 14;
            this.lblFullName.Text = "名称(&N)：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(65, 98);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(59, 12);
            this.lblCode.TabIndex = 17;
            this.lblCode.Text = "编号(&C)：";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmPermissionItemEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(511, 312);
            this.Controls.Add(this.grbPermissionItem);
            this.Controls.Add(this.btnLikeAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmPermissionItemEdit";
            this.Text = "编辑操作权限项";
            this.grbPermissionItem.ResumeLayout(false);
            this.grbPermissionItem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLikeAdd;
        private System.Windows.Forms.GroupBox grbPermissionItem;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.CheckBox chkIsScope;
        private UCPermissionSelect ucParent;
        private System.Windows.Forms.Label lblParent;
        private System.Windows.Forms.Label lblFullNameReq;
        private System.Windows.Forms.Label lblCodeReq;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblCode;

    }
}