namespace DotNet.WinForm
{
    partial class FrmFileEdit
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
            this.grpFile = new System.Windows.Forms.GroupBox();
            this.ucFolder = new DotNet.WinForm.UCFolderSelect();
            this.lblFullNameReq = new System.Windows.Forms.Label();
            this.lblSelectReq = new System.Windows.Forms.Label();
            this.lblSelect = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.btnDownLoad = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpFile
            // 
            this.grpFile.Controls.Add(this.ucFolder);
            this.grpFile.Controls.Add(this.lblFullNameReq);
            this.grpFile.Controls.Add(this.lblSelectReq);
            this.grpFile.Controls.Add(this.lblSelect);
            this.grpFile.Controls.Add(this.txtDescription);
            this.grpFile.Controls.Add(this.lblDescription);
            this.grpFile.Controls.Add(this.txtFileName);
            this.grpFile.Controls.Add(this.lblFullName);
            this.grpFile.Location = new System.Drawing.Point(12, 66);
            this.grpFile.Name = "grpFile";
            this.grpFile.Size = new System.Drawing.Size(523, 176);
            this.grpFile.TabIndex = 0;
            this.grpFile.TabStop = false;
            this.grpFile.Text = "编辑文件";
            // 
            // ucFolder
            // 
            this.ucFolder.AllowNull = true;
            this.ucFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucFolder.CheckMove = false;
            this.ucFolder.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucFolder.Location = new System.Drawing.Point(144, 26);
            this.ucFolder.Name = "ucFolder";
            this.ucFolder.SelectedFullName = "";
            this.ucFolder.SelectedId = "";
            this.ucFolder.Size = new System.Drawing.Size(345, 22);
            this.ucFolder.TabIndex = 12;
            // 
            // lblFullNameReq
            // 
            this.lblFullNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullNameReq.AutoSize = true;
            this.lblFullNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblFullNameReq.Location = new System.Drawing.Point(494, 64);
            this.lblFullNameReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFullNameReq.Name = "lblFullNameReq";
            this.lblFullNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblFullNameReq.TabIndex = 16;
            this.lblFullNameReq.Text = "*";
            // 
            // lblSelectReq
            // 
            this.lblSelectReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectReq.AutoSize = true;
            this.lblSelectReq.ForeColor = System.Drawing.Color.Red;
            this.lblSelectReq.Location = new System.Drawing.Point(494, 32);
            this.lblSelectReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelectReq.Name = "lblSelectReq";
            this.lblSelectReq.Size = new System.Drawing.Size(11, 12);
            this.lblSelectReq.TabIndex = 13;
            this.lblSelectReq.Text = "*";
            // 
            // lblSelect
            // 
            this.lblSelect.Location = new System.Drawing.Point(25, 30);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(113, 12);
            this.lblSelect.TabIndex = 11;
            this.lblSelect.Text = "选择文件夹(&T):";
            this.lblSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(144, 91);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(345, 70);
            this.txtDescription.TabIndex = 18;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(18, 94);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(120, 12);
            this.lblDescription.TabIndex = 17;
            this.lblDescription.Text = "描述(&B):";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Location = new System.Drawing.Point(144, 59);
            this.txtFileName.MaxLength = 50;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(345, 21);
            this.txtFileName.TabIndex = 15;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(16, 62);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(122, 12);
            this.lblFullName.TabIndex = 14;
            this.lblFullName.Text = "名称(&N):";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDownLoad
            // 
            this.btnDownLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDownLoad.Location = new System.Drawing.Point(10, 254);
            this.btnDownLoad.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDownLoad.Name = "btnDownLoad";
            this.btnDownLoad.Size = new System.Drawing.Size(87, 23);
            this.btnDownLoad.TabIndex = 22;
            this.btnDownLoad.Text = "下载(&D)";
            this.btnDownLoad.UseVisualStyleBackColor = true;
            this.btnDownLoad.Click += new System.EventHandler(this.btnDownLoad_Click_1);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(460, 254);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(379, 254);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // FrmFileEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DotNet.WinForm.Properties.Resources.Head;
            this.ClientSize = new System.Drawing.Size(546, 288);
            this.Controls.Add(this.btnDownLoad);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpFile);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFileEdit";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "编辑文件";
            this.grpFile.ResumeLayout(false);
            this.grpFile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFile;
        private UCFolderSelect ucFolder;
        private System.Windows.Forms.Label lblFullNameReq;
        private System.Windows.Forms.Label lblSelectReq;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Button btnDownLoad;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;

    }
}