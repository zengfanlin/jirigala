namespace DotNet.WinForm
{
    partial class FrmItemsEdit
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
            this.txtUseItemValue = new System.Windows.Forms.TextBox();
            this.lblUseItemValue = new System.Windows.Forms.Label();
            this.txtUseItemName = new System.Windows.Forms.TextBox();
            this.lblUseItemName = new System.Windows.Forms.Label();
            this.txtUseItemCode = new System.Windows.Forms.TextBox();
            this.lblUseItemCode = new System.Windows.Forms.Label();
            this.chkIsTree = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblCodeReq = new System.Windows.Forms.Label();
            this.lblFullNameReq = new System.Windows.Forms.Label();
            this.txtTargetTable = new System.Windows.Forms.TextBox();
            this.lblTargetTable = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.btnAccessPermission = new System.Windows.Forms.Button();
            this.btnCreateTable = new System.Windows.Forms.Button();
            this.grbItemDetails = new System.Windows.Forms.GroupBox();
            this.btnLikeAdd = new System.Windows.Forms.Button();
            this.grbItemDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUseItemValue
            // 
            this.txtUseItemValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUseItemValue.Location = new System.Drawing.Point(115, 194);
            this.txtUseItemValue.MaxLength = 50;
            this.txtUseItemValue.Name = "txtUseItemValue";
            this.txtUseItemValue.Size = new System.Drawing.Size(357, 21);
            this.txtUseItemValue.TabIndex = 13;
            // 
            // lblUseItemValue
            // 
            this.lblUseItemValue.Location = new System.Drawing.Point(28, 197);
            this.lblUseItemValue.Name = "lblUseItemValue";
            this.lblUseItemValue.Size = new System.Drawing.Size(85, 18);
            this.lblUseItemValue.TabIndex = 12;
            this.lblUseItemValue.Text = "值字段：";
            this.lblUseItemValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUseItemName
            // 
            this.txtUseItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUseItemName.Location = new System.Drawing.Point(115, 166);
            this.txtUseItemName.MaxLength = 50;
            this.txtUseItemName.Name = "txtUseItemName";
            this.txtUseItemName.Size = new System.Drawing.Size(357, 21);
            this.txtUseItemName.TabIndex = 11;
            // 
            // lblUseItemName
            // 
            this.lblUseItemName.Location = new System.Drawing.Point(28, 169);
            this.lblUseItemName.Name = "lblUseItemName";
            this.lblUseItemName.Size = new System.Drawing.Size(85, 18);
            this.lblUseItemName.TabIndex = 10;
            this.lblUseItemName.Text = "名称字段：";
            this.lblUseItemName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUseItemCode
            // 
            this.txtUseItemCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUseItemCode.Location = new System.Drawing.Point(115, 139);
            this.txtUseItemCode.MaxLength = 50;
            this.txtUseItemCode.Name = "txtUseItemCode";
            this.txtUseItemCode.Size = new System.Drawing.Size(357, 21);
            this.txtUseItemCode.TabIndex = 9;
            // 
            // lblUseItemCode
            // 
            this.lblUseItemCode.Location = new System.Drawing.Point(28, 142);
            this.lblUseItemCode.Name = "lblUseItemCode";
            this.lblUseItemCode.Size = new System.Drawing.Size(85, 18);
            this.lblUseItemCode.TabIndex = 8;
            this.lblUseItemCode.Text = "编号字段：";
            this.lblUseItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkIsTree
            // 
            this.chkIsTree.AutoSize = true;
            this.chkIsTree.Location = new System.Drawing.Point(115, 229);
            this.chkIsTree.Name = "chkIsTree";
            this.chkIsTree.Size = new System.Drawing.Size(48, 16);
            this.chkIsTree.TabIndex = 14;
            this.chkIsTree.Text = "树型";
            this.chkIsTree.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(340, 344);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCodeReq
            // 
            this.lblCodeReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCodeReq.AutoSize = true;
            this.lblCodeReq.ForeColor = System.Drawing.Color.Red;
            this.lblCodeReq.Location = new System.Drawing.Point(460, 24);
            this.lblCodeReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCodeReq.Name = "lblCodeReq";
            this.lblCodeReq.Size = new System.Drawing.Size(11, 12);
            this.lblCodeReq.TabIndex = 0;
            this.lblCodeReq.Text = "*";
            // 
            // lblFullNameReq
            // 
            this.lblFullNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullNameReq.AutoSize = true;
            this.lblFullNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblFullNameReq.Location = new System.Drawing.Point(460, 55);
            this.lblFullNameReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFullNameReq.Name = "lblFullNameReq";
            this.lblFullNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblFullNameReq.TabIndex = 1;
            this.lblFullNameReq.Text = "*";
            // 
            // txtTargetTable
            // 
            this.txtTargetTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetTable.Location = new System.Drawing.Point(115, 109);
            this.txtTargetTable.MaxLength = 100;
            this.txtTargetTable.Name = "txtTargetTable";
            this.txtTargetTable.Size = new System.Drawing.Size(357, 21);
            this.txtTargetTable.TabIndex = 7;
            // 
            // lblTargetTable
            // 
            this.lblTargetTable.Location = new System.Drawing.Point(28, 112);
            this.lblTargetTable.Name = "lblTargetTable";
            this.lblTargetTable.Size = new System.Drawing.Size(85, 18);
            this.lblTargetTable.TabIndex = 6;
            this.lblTargetTable.Text = "目标表(&T)：";
            this.lblTargetTable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(418, 344);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(115, 260);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(357, 56);
            this.txtDescription.TabIndex = 17;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(28, 262);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(85, 18);
            this.lblDescription.TabIndex = 16;
            this.lblDescription.Text = "描述(&D)：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(242, 229);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(48, 16);
            this.chkEnabled.TabIndex = 15;
            this.chkEnabled.Text = "有效";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.Location = new System.Drawing.Point(115, 78);
            this.txtFullName.MaxLength = 50;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(357, 21);
            this.txtFullName.TabIndex = 5;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(115, 47);
            this.txtCode.MaxLength = 50;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(357, 21);
            this.txtCode.TabIndex = 3;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(28, 81);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(85, 18);
            this.lblFullName.TabIndex = 4;
            this.lblFullName.Text = "名称(&N)：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(28, 50);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(85, 18);
            this.lblCode.TabIndex = 2;
            this.lblCode.Text = "编号(&O)：";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAccessPermission
            // 
            this.btnAccessPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccessPermission.Location = new System.Drawing.Point(19, 344);
            this.btnAccessPermission.Name = "btnAccessPermission";
            this.btnAccessPermission.Size = new System.Drawing.Size(159, 23);
            this.btnAccessPermission.TabIndex = 18;
            this.btnAccessPermission.Text = "访问权限(&P)...";
            this.btnAccessPermission.UseVisualStyleBackColor = true;
            this.btnAccessPermission.Click += new System.EventHandler(this.btnAccessPermission_Click);
            // 
            // btnCreateTable
            // 
            this.btnCreateTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateTable.Location = new System.Drawing.Point(351, 5);
            this.btnCreateTable.Name = "btnCreateTable";
            this.btnCreateTable.Size = new System.Drawing.Size(143, 23);
            this.btnCreateTable.TabIndex = 0;
            this.btnCreateTable.Text = "创建选项明细表";
            this.btnCreateTable.UseVisualStyleBackColor = true;
            this.btnCreateTable.Click += new System.EventHandler(this.btnCreateTable_Click);
            // 
            // grbItemDetails
            // 
            this.grbItemDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbItemDetails.Controls.Add(this.lblCodeReq);
            this.grbItemDetails.Controls.Add(this.lblFullNameReq);
            this.grbItemDetails.Location = new System.Drawing.Point(19, 27);
            this.grbItemDetails.Name = "grbItemDetails";
            this.grbItemDetails.Size = new System.Drawing.Size(481, 307);
            this.grbItemDetails.TabIndex = 1;
            this.grbItemDetails.TabStop = false;
            this.grbItemDetails.Text = "选项";
            // 
            // btnLikeAdd
            // 
            this.btnLikeAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLikeAdd.Location = new System.Drawing.Point(184, 345);
            this.btnLikeAdd.Name = "btnLikeAdd";
            this.btnLikeAdd.Size = new System.Drawing.Size(113, 23);
            this.btnLikeAdd.TabIndex = 19;
            this.btnLikeAdd.Text = "类似添加(&A)";
            this.btnLikeAdd.UseVisualStyleBackColor = true;
            this.btnLikeAdd.Click += new System.EventHandler(this.btnLikeAdd_Click);
            // 
            // FrmItemsEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 380);
            this.Controls.Add(this.btnLikeAdd);
            this.Controls.Add(this.btnCreateTable);
            this.Controls.Add(this.btnAccessPermission);
            this.Controls.Add(this.txtUseItemValue);
            this.Controls.Add(this.lblUseItemValue);
            this.Controls.Add(this.txtUseItemName);
            this.Controls.Add(this.lblUseItemName);
            this.Controls.Add(this.txtUseItemCode);
            this.Controls.Add(this.lblUseItemCode);
            this.Controls.Add(this.chkIsTree);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtTargetTable);
            this.Controls.Add(this.lblTargetTable);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.grbItemDetails);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmItemsEdit";
            this.Text = "选项编辑";
            this.grbItemDetails.ResumeLayout(false);
            this.grbItemDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUseItemValue;
        private System.Windows.Forms.Label lblUseItemValue;
        private System.Windows.Forms.TextBox txtUseItemName;
        private System.Windows.Forms.Label lblUseItemName;
        private System.Windows.Forms.TextBox txtUseItemCode;
        private System.Windows.Forms.Label lblUseItemCode;
        private System.Windows.Forms.CheckBox chkIsTree;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblCodeReq;
        private System.Windows.Forms.Label lblFullNameReq;
        private System.Windows.Forms.TextBox txtTargetTable;
        private System.Windows.Forms.Label lblTargetTable;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Button btnAccessPermission;
        private System.Windows.Forms.Button btnCreateTable;
        private System.Windows.Forms.GroupBox grbItemDetails;
        private System.Windows.Forms.Button btnLikeAdd;

    }
}