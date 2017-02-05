namespace DotNet.WinForm
{
    partial class FrmDocumentEdit
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
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblFullNameReq = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.chbEnabled = new System.Windows.Forms.CheckBox();
            this.grpDocument = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpDocument.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDescription.Location = new System.Drawing.Point(6, 318);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(74, 12);
            this.lblDescription.TabIndex = 15;
            this.lblDescription.Text = "描述(&D):";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(86, 315);
            this.txtDescription.MaxLength = 800;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(613, 78);
            this.txtDescription.TabIndex = 16;
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(6, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(74, 12);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "标题(&T):";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Location = new System.Drawing.Point(86, 21);
            this.txtFileName.MaxLength = 50;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(613, 21);
            this.txtFileName.TabIndex = 11;
            // 
            // lblFullNameReq
            // 
            this.lblFullNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullNameReq.AutoSize = true;
            this.lblFullNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblFullNameReq.Location = new System.Drawing.Point(702, 24);
            this.lblFullNameReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFullNameReq.Name = "lblFullNameReq";
            this.lblFullNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblFullNameReq.TabIndex = 12;
            this.lblFullNameReq.Text = "*";
            // 
            // lblContent
            // 
            this.lblContent.Location = new System.Drawing.Point(6, 52);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(74, 12);
            this.lblContent.TabIndex = 13;
            this.lblContent.Text = "内容(&C):";
            this.lblContent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtContent
            // 
            this.txtContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContent.Location = new System.Drawing.Point(86, 49);
            this.txtContent.MaxLength = 800;
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContent.Size = new System.Drawing.Size(613, 259);
            this.txtContent.TabIndex = 14;
            // 
            // chbEnabled
            // 
            this.chbEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbEnabled.AutoSize = true;
            this.chbEnabled.Checked = true;
            this.chbEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbEnabled.Location = new System.Drawing.Point(86, 403);
            this.chbEnabled.Name = "chbEnabled";
            this.chbEnabled.Size = new System.Drawing.Size(48, 16);
            this.chbEnabled.TabIndex = 17;
            this.chbEnabled.Text = "有效";
            // 
            // grpDocument
            // 
            this.grpDocument.Controls.Add(this.chbEnabled);
            this.grpDocument.Controls.Add(this.txtContent);
            this.grpDocument.Controls.Add(this.lblContent);
            this.grpDocument.Controls.Add(this.lblFullNameReq);
            this.grpDocument.Controls.Add(this.txtFileName);
            this.grpDocument.Controls.Add(this.lblTitle);
            this.grpDocument.Controls.Add(this.txtDescription);
            this.grpDocument.Controls.Add(this.lblDescription);
            this.grpDocument.Location = new System.Drawing.Point(13, 13);
            this.grpDocument.Name = "grpDocument";
            this.grpDocument.Size = new System.Drawing.Size(719, 437);
            this.grpDocument.TabIndex = 0;
            this.grpDocument.TabStop = false;
            this.grpDocument.Text = "编辑文本文档";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(578, 461);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(657, 461);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FrmDocumentEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 491);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpDocument);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmDocumentEdit";
            this.Text = "编辑文本文档";
            this.grpDocument.ResumeLayout(false);
            this.grpDocument.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblFullNameReq;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.CheckBox chbEnabled;
        private System.Windows.Forms.GroupBox grpDocument;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

    }
}