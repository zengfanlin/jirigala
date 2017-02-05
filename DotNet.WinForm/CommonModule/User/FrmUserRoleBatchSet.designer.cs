namespace DotNet.WinForm
{
    partial class FrmUserRoleBatchSet
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
            this.tcRole = new System.Windows.Forms.TabControl();
            this.tpRole = new System.Windows.Forms.TabPage();
            this.cklstRole = new System.Windows.Forms.CheckedListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tcUser = new System.Windows.Forms.TabControl();
            this.tpUser = new System.Windows.Forms.TabPage();
            this.lstUser = new System.Windows.Forms.ListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClearPermission = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.tcRole.SuspendLayout();
            this.tpRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tcUser.SuspendLayout();
            this.tpUser.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcRole
            // 
            this.tcRole.Controls.Add(this.tpRole);
            this.tcRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcRole.Location = new System.Drawing.Point(0, 0);
            this.tcRole.Name = "tcRole";
            this.tcRole.SelectedIndex = 0;
            this.tcRole.Size = new System.Drawing.Size(293, 405);
            this.tcRole.TabIndex = 8;
            // 
            // tpRole
            // 
            this.tpRole.Controls.Add(this.cklstRole);
            this.tpRole.Location = new System.Drawing.Point(4, 22);
            this.tpRole.Name = "tpRole";
            this.tpRole.Padding = new System.Windows.Forms.Padding(3);
            this.tpRole.Size = new System.Drawing.Size(285, 379);
            this.tpRole.TabIndex = 0;
            this.tpRole.Text = "归属角色";
            this.tpRole.UseVisualStyleBackColor = true;
            // 
            // cklstRole
            // 
            this.cklstRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cklstRole.Enabled = false;
            this.cklstRole.FormattingEnabled = true;
            this.cklstRole.Location = new System.Drawing.Point(3, 3);
            this.cklstRole.Name = "cklstRole";
            this.cklstRole.Size = new System.Drawing.Size(279, 373);
            this.cklstRole.TabIndex = 0;
            this.cklstRole.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cklstRole_ItemCheck);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(5, 35);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tcUser);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tcRole);
            this.splitContainer1.Size = new System.Drawing.Size(592, 405);
            this.splitContainer1.SplitterDistance = 295;
            this.splitContainer1.TabIndex = 11;
            // 
            // tcUser
            // 
            this.tcUser.Controls.Add(this.tpUser);
            this.tcUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcUser.Location = new System.Drawing.Point(0, 0);
            this.tcUser.Name = "tcUser";
            this.tcUser.SelectedIndex = 0;
            this.tcUser.Size = new System.Drawing.Size(295, 405);
            this.tcUser.TabIndex = 9;
            // 
            // tpUser
            // 
            this.tpUser.Controls.Add(this.lstUser);
            this.tpUser.Location = new System.Drawing.Point(4, 22);
            this.tpUser.Name = "tpUser";
            this.tpUser.Padding = new System.Windows.Forms.Padding(3);
            this.tpUser.Size = new System.Drawing.Size(287, 379);
            this.tpUser.TabIndex = 0;
            this.tpUser.Text = "用户";
            this.tpUser.UseVisualStyleBackColor = true;
            // 
            // lstUser
            // 
            this.lstUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstUser.FormattingEnabled = true;
            this.lstUser.ItemHeight = 12;
            this.lstUser.Location = new System.Drawing.Point(3, 3);
            this.lstUser.Name = "lstUser";
            this.lstUser.Size = new System.Drawing.Size(281, 373);
            this.lstUser.TabIndex = 0;
            this.lstUser.SelectedIndexChanged += new System.EventHandler(this.lstUser_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(525, 447);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 23);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(448, 447);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(71, 23);
            this.btnOK.TabIndex = 34;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnClearPermission);
            this.flowLayoutPanel1.Controls.Add(this.btnPaste);
            this.flowLayoutPanel1.Controls.Add(this.btnCopy);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(585, 28);
            this.flowLayoutPanel1.TabIndex = 36;
            // 
            // btnClearPermission
            // 
            this.btnClearPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearPermission.Enabled = false;
            this.btnClearPermission.Location = new System.Drawing.Point(480, 3);
            this.btnClearPermission.Name = "btnClearPermission";
            this.btnClearPermission.Size = new System.Drawing.Size(102, 23);
            this.btnClearPermission.TabIndex = 36;
            this.btnClearPermission.Text = "清除角色(&C)";
            this.btnClearPermission.UseVisualStyleBackColor = true;
            // 
            // btnPaste
            // 
            this.btnPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaste.Enabled = false;
            this.btnPaste.Location = new System.Drawing.Point(372, 3);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(102, 23);
            this.btnPaste.TabIndex = 35;
            this.btnPaste.Text = "粘贴角色";
            this.btnPaste.UseVisualStyleBackColor = true;
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Enabled = false;
            this.btnCopy.Location = new System.Drawing.Point(264, 3);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(102, 23);
            this.btnCopy.TabIndex = 34;
            this.btnCopy.Text = "复制角色";
            this.btnCopy.UseVisualStyleBackColor = true;
            // 
            // FrmUserRoleBatchSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(602, 474);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmUserRoleBatchSet";
            this.Text = "用户角色关联";
            this.tcRole.ResumeLayout(false);
            this.tpRole.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tcUser.ResumeLayout(false);
            this.tpUser.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcRole;
        private System.Windows.Forms.TabPage tpRole;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tcUser;
        private System.Windows.Forms.TabPage tpUser;
        private System.Windows.Forms.CheckedListBox cklstRole;
        private System.Windows.Forms.ListBox lstUser;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnClearPermission;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Button btnCopy;

    }
}