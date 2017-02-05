namespace DotNet.WinForm
{
    partial class FrmItemsAdd
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
            this.lblFullNameReq = new System.Windows.Forms.Label();
            this.lblCodeReq = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.chkIsTree = new System.Windows.Forms.CheckBox();
            this.txtUseItemCode = new System.Windows.Forms.TextBox();
            this.lblUseItemCode = new System.Windows.Forms.Label();
            this.txtUseItemName = new System.Windows.Forms.TextBox();
            this.lblUseItemName = new System.Windows.Forms.Label();
            this.txtUseItemValue = new System.Windows.Forms.TextBox();
            this.lblUseItemValue = new System.Windows.Forms.Label();
            this.chkCreateTable = new System.Windows.Forms.CheckBox();
            this.grbItemDetails = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // txtTargetTable
            // 
            this.txtTargetTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetTable.Location = new System.Drawing.Point(120, 94);
            this.txtTargetTable.MaxLength = 100;
            this.txtTargetTable.Name = "txtTargetTable";
            this.txtTargetTable.Size = new System.Drawing.Size(352, 21);
            this.txtTargetTable.TabIndex = 8;
            this.txtTargetTable.Text = "Items";
            // 
            // lblTargetTable
            // 
            this.lblTargetTable.Location = new System.Drawing.Point(15, 97);
            this.lblTargetTable.Name = "lblTargetTable";
            this.lblTargetTable.Size = new System.Drawing.Size(100, 12);
            this.lblTargetTable.TabIndex = 7;
            this.lblTargetTable.Text = "目标表(&T)：";
            this.lblTargetTable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(422, 333);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(120, 245);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(352, 62);
            this.txtDescription.TabIndex = 19;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(15, 246);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(100, 12);
            this.lblDescription.TabIndex = 18;
            this.lblDescription.Text = "描述(&D)：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(193, 214);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(48, 16);
            this.chkEnabled.TabIndex = 16;
            this.chkEnabled.Text = "有效";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.Location = new System.Drawing.Point(120, 63);
            this.txtFullName.MaxLength = 50;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(352, 21);
            this.txtFullName.TabIndex = 5;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(120, 32);
            this.txtCode.MaxLength = 50;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(352, 21);
            this.txtCode.TabIndex = 2;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(15, 66);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(100, 12);
            this.lblFullName.TabIndex = 4;
            this.lblFullName.Text = "名称(&N)：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(15, 35);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(100, 12);
            this.lblCode.TabIndex = 1;
            this.lblCode.Text = "编号(&C)：";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFullNameReq
            // 
            this.lblFullNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullNameReq.AutoSize = true;
            this.lblFullNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblFullNameReq.Location = new System.Drawing.Point(479, 67);
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
            this.lblCodeReq.Location = new System.Drawing.Point(479, 37);
            this.lblCodeReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCodeReq.Name = "lblCodeReq";
            this.lblCodeReq.Size = new System.Drawing.Size(11, 12);
            this.lblCodeReq.TabIndex = 3;
            this.lblCodeReq.Text = "*";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(344, 333);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(265, 333);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // chkIsTree
            // 
            this.chkIsTree.AutoSize = true;
            this.chkIsTree.Location = new System.Drawing.Point(120, 214);
            this.chkIsTree.Name = "chkIsTree";
            this.chkIsTree.Size = new System.Drawing.Size(48, 16);
            this.chkIsTree.TabIndex = 15;
            this.chkIsTree.Text = "树型";
            this.chkIsTree.UseVisualStyleBackColor = true;
            // 
            // txtUseItemCode
            // 
            this.txtUseItemCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUseItemCode.Location = new System.Drawing.Point(120, 124);
            this.txtUseItemCode.MaxLength = 50;
            this.txtUseItemCode.Name = "txtUseItemCode";
            this.txtUseItemCode.Size = new System.Drawing.Size(352, 21);
            this.txtUseItemCode.TabIndex = 10;
            this.txtUseItemCode.Text = "编号";
            // 
            // lblUseItemCode
            // 
            this.lblUseItemCode.Location = new System.Drawing.Point(15, 127);
            this.lblUseItemCode.Name = "lblUseItemCode";
            this.lblUseItemCode.Size = new System.Drawing.Size(100, 12);
            this.lblUseItemCode.TabIndex = 9;
            this.lblUseItemCode.Text = "编号字段：";
            this.lblUseItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUseItemName
            // 
            this.txtUseItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUseItemName.Location = new System.Drawing.Point(120, 151);
            this.txtUseItemName.MaxLength = 50;
            this.txtUseItemName.Name = "txtUseItemName";
            this.txtUseItemName.Size = new System.Drawing.Size(352, 21);
            this.txtUseItemName.TabIndex = 12;
            this.txtUseItemName.Text = "名称";
            // 
            // lblUseItemName
            // 
            this.lblUseItemName.Location = new System.Drawing.Point(15, 154);
            this.lblUseItemName.Name = "lblUseItemName";
            this.lblUseItemName.Size = new System.Drawing.Size(100, 12);
            this.lblUseItemName.TabIndex = 11;
            this.lblUseItemName.Text = "名称字段：";
            this.lblUseItemName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUseItemValue
            // 
            this.txtUseItemValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUseItemValue.Location = new System.Drawing.Point(120, 179);
            this.txtUseItemValue.MaxLength = 50;
            this.txtUseItemValue.Name = "txtUseItemValue";
            this.txtUseItemValue.Size = new System.Drawing.Size(352, 21);
            this.txtUseItemValue.TabIndex = 14;
            this.txtUseItemValue.Text = "值";
            // 
            // lblUseItemValue
            // 
            this.lblUseItemValue.Location = new System.Drawing.Point(15, 182);
            this.lblUseItemValue.Name = "lblUseItemValue";
            this.lblUseItemValue.Size = new System.Drawing.Size(100, 12);
            this.lblUseItemValue.TabIndex = 13;
            this.lblUseItemValue.Text = "值字段：";
            this.lblUseItemValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkCreateTable
            // 
            this.chkCreateTable.AutoSize = true;
            this.chkCreateTable.Checked = true;
            this.chkCreateTable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCreateTable.Location = new System.Drawing.Point(271, 214);
            this.chkCreateTable.Name = "chkCreateTable";
            this.chkCreateTable.Size = new System.Drawing.Size(84, 16);
            this.chkCreateTable.TabIndex = 17;
            this.chkCreateTable.Text = "创建选项表";
            this.chkCreateTable.UseVisualStyleBackColor = true;
            // 
            // grbItemDetails
            // 
            this.grbItemDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbItemDetails.Location = new System.Drawing.Point(8, 8);
            this.grbItemDetails.Name = "grbItemDetails";
            this.grbItemDetails.Size = new System.Drawing.Size(490, 319);
            this.grbItemDetails.TabIndex = 0;
            this.grbItemDetails.TabStop = false;
            this.grbItemDetails.Text = "选项";
            // 
            // FrmItemsAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(509, 367);
            this.Controls.Add(this.chkCreateTable);
            this.Controls.Add(this.txtUseItemValue);
            this.Controls.Add(this.lblUseItemValue);
            this.Controls.Add(this.txtUseItemName);
            this.Controls.Add(this.lblUseItemName);
            this.Controls.Add(this.txtUseItemCode);
            this.Controls.Add(this.lblUseItemCode);
            this.Controls.Add(this.chkIsTree);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblCodeReq);
            this.Controls.Add(this.lblFullNameReq);
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
            this.Name = "FrmItemsAdd";
            this.Text = "选项添加";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.Label lblFullNameReq;
        private System.Windows.Forms.Label lblCodeReq;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.CheckBox chkIsTree;
        private System.Windows.Forms.TextBox txtUseItemCode;
        private System.Windows.Forms.Label lblUseItemCode;
        private System.Windows.Forms.TextBox txtUseItemName;
        private System.Windows.Forms.Label lblUseItemName;
        private System.Windows.Forms.TextBox txtUseItemValue;
        private System.Windows.Forms.Label lblUseItemValue;
        private System.Windows.Forms.CheckBox chkCreateTable;
        private System.Windows.Forms.GroupBox grbItemDetails;

    }
}