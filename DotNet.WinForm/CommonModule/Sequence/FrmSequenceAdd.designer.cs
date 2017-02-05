namespace DotNet.WinForm
{
    partial class FrmSequenceAdd
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
            this.grbSequence = new System.Windows.Forms.GroupBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grbSequence.SuspendLayout();
            this.SuspendLayout();
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
            this.grbSequence.Location = new System.Drawing.Point(12, 12);
            this.grbSequence.Name = "grbSequence";
            this.grbSequence.Size = new System.Drawing.Size(365, 297);
            this.grbSequence.TabIndex = 0;
            this.grbSequence.TabStop = false;
            this.grbSequence.Text = "序号（流水号）：";
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(96, 220);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(48, 16);
            this.chkEnabled.TabIndex = 43;
            this.chkEnabled.Text = "显示";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // txtPrefix
            // 
            this.txtPrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrefix.Location = new System.Drawing.Point(95, 61);
            this.txtPrefix.MaxLength = 40;
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(230, 21);
            this.txtPrefix.TabIndex = 26;
            // 
            // lblPrefix
            // 
            this.lblPrefix.Location = new System.Drawing.Point(8, 64);
            this.lblPrefix.Name = "lblPrefix";
            this.lblPrefix.Size = new System.Drawing.Size(85, 12);
            this.lblPrefix.TabIndex = 25;
            this.lblPrefix.Text = "前缀：";
            this.lblPrefix.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSeparator
            // 
            this.txtSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSeparator.Location = new System.Drawing.Point(95, 92);
            this.txtSeparator.MaxLength = 40;
            this.txtSeparator.Name = "txtSeparator";
            this.txtSeparator.Size = new System.Drawing.Size(230, 21);
            this.txtSeparator.TabIndex = 28;
            // 
            // lblSeparator
            // 
            this.lblSeparator.Location = new System.Drawing.Point(8, 95);
            this.lblSeparator.Name = "lblSeparator";
            this.lblSeparator.Size = new System.Drawing.Size(85, 12);
            this.lblSeparator.TabIndex = 27;
            this.lblSeparator.Text = "分割符：";
            this.lblSeparator.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(330, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 37;
            this.label5.Text = "*";
            // 
            // txtStep
            // 
            this.txtStep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStep.Location = new System.Drawing.Point(95, 187);
            this.txtStep.MaxLength = 5;
            this.txtStep.Name = "txtStep";
            this.txtStep.Size = new System.Drawing.Size(230, 21);
            this.txtStep.TabIndex = 36;
            this.txtStep.Text = "1";
            // 
            // lblStep
            // 
            this.lblStep.Location = new System.Drawing.Point(8, 190);
            this.lblStep.Name = "lblStep";
            this.lblStep.Size = new System.Drawing.Size(85, 12);
            this.lblStep.TabIndex = 35;
            this.lblStep.Text = "步调：";
            this.lblStep.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(330, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 31;
            this.label3.Text = "*";
            // 
            // txtSequence
            // 
            this.txtSequence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSequence.Location = new System.Drawing.Point(95, 124);
            this.txtSequence.MaxLength = 10;
            this.txtSequence.Name = "txtSequence";
            this.txtSequence.Size = new System.Drawing.Size(230, 21);
            this.txtSequence.TabIndex = 30;
            this.txtSequence.Text = "10000000";
            // 
            // lblSequence
            // 
            this.lblSequence.Location = new System.Drawing.Point(8, 127);
            this.lblSequence.Name = "lblSequence";
            this.lblSequence.Size = new System.Drawing.Size(85, 17);
            this.lblSequence.TabIndex = 29;
            this.lblSequence.Text = "增序列：";
            this.lblSequence.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(330, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "*";
            // 
            // txtReduction
            // 
            this.txtReduction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReduction.Location = new System.Drawing.Point(95, 155);
            this.txtReduction.MaxLength = 10;
            this.txtReduction.Name = "txtReduction";
            this.txtReduction.Size = new System.Drawing.Size(230, 21);
            this.txtReduction.TabIndex = 33;
            this.txtReduction.Text = "9999999";
            // 
            // lblReduction
            // 
            this.lblReduction.Location = new System.Drawing.Point(8, 159);
            this.lblReduction.Name = "lblReduction";
            this.lblReduction.Size = new System.Drawing.Size(85, 12);
            this.lblReduction.TabIndex = 32;
            this.lblReduction.Text = "减序列：";
            this.lblReduction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFullNameReq
            // 
            this.lblFullNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullNameReq.AutoSize = true;
            this.lblFullNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblFullNameReq.Location = new System.Drawing.Point(330, 30);
            this.lblFullNameReq.Name = "lblFullNameReq";
            this.lblFullNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblFullNameReq.TabIndex = 24;
            this.lblFullNameReq.Text = "*";
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.Location = new System.Drawing.Point(95, 28);
            this.txtFullName.MaxLength = 40;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(230, 21);
            this.txtFullName.TabIndex = 23;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(8, 33);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(85, 12);
            this.lblFullName.TabIndex = 22;
            this.lblFullName.Text = "名称(&N)：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(95, 246);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(230, 37);
            this.txtDescription.TabIndex = 39;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(8, 249);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(85, 12);
            this.lblDescription.TabIndex = 38;
            this.lblDescription.Text = "描述(&D)：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(217, 317);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(302, 317);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 42;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(131, 317);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 40;
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FrmSequenceAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 347);
            this.Controls.Add(this.grbSequence);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSequenceAdd";
            this.Text = "添加序号（流水号）";
            this.grbSequence.ResumeLayout(false);
            this.grbSequence.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbSequence;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
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

    }
}