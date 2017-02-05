namespace DotNet.WinForm
{
    partial class FrmImportUser
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImportUser));
            this.btnClose = new System.Windows.Forms.Button();
            this.grbImport = new System.Windows.Forms.GroupBox();
            this.pbImport = new System.Windows.Forms.ProgressBar();
            this.grbFile = new System.Windows.Forms.GroupBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.lblFile = new System.Windows.Forms.Label();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.grdUser = new System.Windows.Forms.DataGridView();
            this.btnImport = new System.Windows.Forms.Button();
            this.grbImport.SuspendLayout();
            this.grbFile.SuspendLayout();
            this.grpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(619, 382);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grbImport
            // 
            this.grbImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbImport.Controls.Add(this.pbImport);
            this.grbImport.Location = new System.Drawing.Point(10, 324);
            this.grbImport.Name = "grbImport";
            this.grbImport.Size = new System.Drawing.Size(684, 47);
            this.grbImport.TabIndex = 2;
            this.grbImport.TabStop = false;
            this.grbImport.Text = "导入进度";
            // 
            // pbImport
            // 
            this.pbImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImport.Location = new System.Drawing.Point(3, 17);
            this.pbImport.Name = "pbImport";
            this.pbImport.Size = new System.Drawing.Size(678, 27);
            this.pbImport.TabIndex = 0;
            // 
            // grbFile
            // 
            this.grbFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbFile.Controls.Add(this.btnDownload);
            this.grbFile.Controls.Add(this.btnBrowse);
            this.grbFile.Controls.Add(this.txtFile);
            this.grbFile.Controls.Add(this.lblFile);
            this.grbFile.Location = new System.Drawing.Point(10, 10);
            this.grbFile.Name = "grbFile";
            this.grbFile.Size = new System.Drawing.Size(683, 57);
            this.grbFile.TabIndex = 0;
            this.grbFile.TabStop = false;
            this.grbFile.Text = "导入数据文件";
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.Location = new System.Drawing.Point(583, 23);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(90, 23);
            this.btnDownload.TabIndex = 3;
            this.btnDownload.Text = "下载模板";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(503, 23);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "浏览...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.BackColor = System.Drawing.SystemColors.Control;
            this.txtFile.Location = new System.Drawing.Point(72, 25);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(427, 21);
            this.txtFile.TabIndex = 1;
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(7, 29);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(65, 12);
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "导入文件：";
            // 
            // grpData
            // 
            this.grpData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpData.Controls.Add(this.grdUser);
            this.grpData.Location = new System.Drawing.Point(9, 73);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(684, 245);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            this.grpData.Text = "导入数据预览";
            // 
            // grdUser
            // 
            this.grdUser.AllowUserToAddRows = false;
            this.grdUser.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.grdUser.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdUser.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUser.GridColor = System.Drawing.SystemColors.Control;
            this.grdUser.Location = new System.Drawing.Point(3, 17);
            this.grdUser.MultiSelect = false;
            this.grdUser.Name = "grdUser";
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.grdUser.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdUser.RowTemplate.Height = 23;
            this.grdUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdUser.Size = new System.Drawing.Size(678, 225);
            this.grdUser.TabIndex = 5;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Enabled = false;
            this.btnImport.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnImport.Location = new System.Drawing.Point(513, 382);
            this.btnImport.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(103, 23);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "导入数据(&I)";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // FrmImportUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(703, 417);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grbImport);
            this.Controls.Add(this.grbFile);
            this.Controls.Add(this.btnClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmImportUser";
            this.Text = "导入用户数据";
            this.grbImport.ResumeLayout(false);
            this.grbFile.ResumeLayout(false);
            this.grbFile.PerformLayout();
            this.grpData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbImport;
        private System.Windows.Forms.GroupBox grbFile;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.DataGridView grdUser;
        private System.Windows.Forms.ProgressBar pbImport;
    }
}