namespace DotNet.WinForm
{
    partial class FrmSequenceEdit
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
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.lblPrefix = new System.Windows.Forms.Label();
            this.txtSeparator = new System.Windows.Forms.TextBox();
            this.lblSeparator = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStep = new System.Windows.Forms.TextBox();
            this.lblStep = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSequence = new System.Windows.Forms.TextBox();
            this.lblSequence = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReduction = new System.Windows.Forms.TextBox();
            this.lblReduction = new System.Windows.Forms.Label();
            this.lblFullNameReq = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.grbSequence = new System.Windows.Forms.GroupBox();
            this.grbSequence.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(307, 341);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(223, 341);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPrefix
            // 
            this.txtPrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrefix.Location = new System.Drawing.Point(88, 55);
            this.txtPrefix.MaxLength = 40;
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(256, 21);
            this.txtPrefix.TabIndex = 4;
            // 
            // lblPrefix
            // 
            this.lblPrefix.Location = new System.Drawing.Point(23, 59);
            this.lblPrefix.Name = "lblPrefix";
            this.lblPrefix.Size = new System.Drawing.Size(59, 12);
            this.lblPrefix.TabIndex = 3;
            this.lblPrefix.Text = "前缀：";
            this.lblPrefix.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSeparator
            // 
            this.txtSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSeparator.Location = new System.Drawing.Point(88, 87);
            this.txtSeparator.MaxLength = 40;
            this.txtSeparator.Name = "txtSeparator";
            this.txtSeparator.Size = new System.Drawing.Size(256, 21);
            this.txtSeparator.TabIndex = 6;
            // 
            // lblSeparator
            // 
            this.lblSeparator.Location = new System.Drawing.Point(23, 91);
            this.lblSeparator.Name = "lblSeparator";
            this.lblSeparator.Size = new System.Drawing.Size(59, 12);
            this.lblSeparator.TabIndex = 5;
            this.lblSeparator.Text = "分割符：";
            this.lblSeparator.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(347, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "*";
            // 
            // txtStep
            // 
            this.txtStep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStep.Location = new System.Drawing.Point(88, 183);
            this.txtStep.MaxLength = 5;
            this.txtStep.Name = "txtStep";
            this.txtStep.Size = new System.Drawing.Size(256, 21);
            this.txtStep.TabIndex = 14;
            // 
            // lblStep
            // 
            this.lblStep.Location = new System.Drawing.Point(23, 187);
            this.lblStep.Name = "lblStep";
            this.lblStep.Size = new System.Drawing.Size(59, 12);
            this.lblStep.TabIndex = 13;
            this.lblStep.Text = "步调：";
            this.lblStep.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(347, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "*";
            // 
            // txtSequence
            // 
            this.txtSequence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSequence.Location = new System.Drawing.Point(88, 119);
            this.txtSequence.MaxLength = 10;
            this.txtSequence.Name = "txtSequence";
            this.txtSequence.Size = new System.Drawing.Size(256, 21);
            this.txtSequence.TabIndex = 8;
            // 
            // lblSequence
            // 
            this.lblSequence.Location = new System.Drawing.Point(23, 123);
            this.lblSequence.Name = "lblSequence";
            this.lblSequence.Size = new System.Drawing.Size(59, 12);
            this.lblSequence.TabIndex = 7;
            this.lblSequence.Text = "增序列：";
            this.lblSequence.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(347, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "*";
            // 
            // txtReduction
            // 
            this.txtReduction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReduction.Location = new System.Drawing.Point(88, 152);
            this.txtReduction.MaxLength = 10;
            this.txtReduction.Name = "txtReduction";
            this.txtReduction.Size = new System.Drawing.Size(256, 21);
            this.txtReduction.TabIndex = 11;
            // 
            // lblReduction
            // 
            this.lblReduction.Location = new System.Drawing.Point(23, 156);
            this.lblReduction.Name = "lblReduction";
            this.lblReduction.Size = new System.Drawing.Size(59, 12);
            this.lblReduction.TabIndex = 10;
            this.lblReduction.Text = "减序列：";
            this.lblReduction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFullNameReq
            // 
            this.lblFullNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullNameReq.AutoSize = true;
            this.lblFullNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblFullNameReq.Location = new System.Drawing.Point(347, 17);
            this.lblFullNameReq.Name = "lblFullNameReq";
            this.lblFullNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblFullNameReq.TabIndex = 2;
            this.lblFullNameReq.Text = "*";
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.Location = new System.Drawing.Point(88, 22);
            this.txtFullName.MaxLength = 40;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(256, 21);
            this.txtFullName.TabIndex = 1;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(23, 26);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(59, 12);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "名称(&N)：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(88, 239);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(256, 59);
            this.txtDescription.TabIndex = 17;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(23, 238);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(59, 12);
            this.lblDescription.TabIndex = 16;
            this.lblDescription.Text = "描述(&D)：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(88, 214);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(48, 16);
            this.chkEnabled.TabIndex = 20;
            this.chkEnabled.Text = "显示";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // grbSequence
            // 
            this.grbSequence.Controls.Add(this.chkEnabled);
            this.grbSequence.Controls.Add(this.txtPrefix);
            this.grbSequence.Controls.Add(this.lblPrefix);
            this.grbSequence.Controls.Add(this.txtSeparator);
            this.grbSequence.Controls.Add(this.lblSeparator);
            this.grbSequence.Controls.Add(this.label5);
            this.grbSequence.Controls.Add(this.txtStep);
            this.grbSequence.Controls.Add(this.lblStep);
            this.grbSequence.Controls.Add(this.label3);
            this.grbSequence.Controls.Add(this.txtSequence);
            this.grbSequence.Controls.Add(this.lblSequence);
            this.grbSequence.Controls.Add(this.label1);
            this.grbSequence.Controls.Add(this.txtReduction);
            this.grbSequence.Controls.Add(this.lblReduction);
            this.grbSequence.Controls.Add(this.lblFullNameReq);
            this.grbSequence.Controls.Add(this.txtFullName);
            this.grbSequence.Controls.Add(this.lblFullName);
            this.grbSequence.Controls.Add(this.txtDescription);
            this.grbSequence.Controls.Add(this.lblDescription);
            this.grbSequence.Location = new System.Drawing.Point(6, 13);
            this.grbSequence.Name = "grbSequence";
            this.grbSequence.Size = new System.Drawing.Size(376, 315);
            this.grbSequence.TabIndex = 21;
            this.grbSequence.TabStop = false;
            this.grbSequence.Text = "序号（流水号）：";
            // 
            // FrmSequenceEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(389, 376);
            this.Controls.Add(this.grbSequence);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSequenceEdit";
            this.Text = "编辑序号（流水号）";
            this.grbSequence.ResumeLayout(false);
            this.grbSequence.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.Label lblPrefix;
        private System.Windows.Forms.TextBox txtSeparator;
        private System.Windows.Forms.Label lblSeparator;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStep;
        private System.Windows.Forms.Label lblStep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSequence;
        private System.Windows.Forms.Label lblSequence;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReduction;
        private System.Windows.Forms.Label lblReduction;
        private System.Windows.Forms.Label lblFullNameReq;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.GroupBox grbSequence;
    }
}