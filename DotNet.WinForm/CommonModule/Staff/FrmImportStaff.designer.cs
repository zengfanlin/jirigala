namespace DotNet.WinForm
{
    partial class FrmImportStaff
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnImport = new System.Windows.Forms.Button();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.grdStaff = new System.Windows.Forms.DataGridView();
            this.grbImport = new System.Windows.Forms.GroupBox();
            this.pbImport = new System.Windows.Forms.ProgressBar();
            this.grbFile = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblFile = new System.Windows.Forms.Label();
            this.txtFile1 = new System.Windows.Forms.TextBox();
            this.btnBrowse1 = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStaff)).BeginInit();
            this.grbImport.SuspendLayout();
            this.grbFile.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Enabled = false;
            this.btnImport.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnImport.Location = new System.Drawing.Point(501, 413);
            this.btnImport.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(111, 23);
            this.btnImport.TabIndex = 8;
            this.btnImport.Text = "导入数据(&I)";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // grpData
            // 
            this.grpData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpData.Controls.Add(this.grdStaff);
            this.grpData.Location = new System.Drawing.Point(5, 75);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(684, 274);
            this.grpData.TabIndex = 6;
            this.grpData.TabStop = false;
            this.grpData.Text = "导入数据预览";
            // 
            // grdStaff
            // 
            this.grdStaff.AllowUserToAddRows = false;
            this.grdStaff.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.grdStaff.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdStaff.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdStaff.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStaff.GridColor = System.Drawing.SystemColors.Control;
            this.grdStaff.Location = new System.Drawing.Point(3, 17);
            this.grdStaff.MultiSelect = false;
            this.grdStaff.Name = "grdStaff";
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.grdStaff.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grdStaff.RowTemplate.Height = 23;
            this.grdStaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdStaff.Size = new System.Drawing.Size(678, 254);
            this.grdStaff.TabIndex = 5;
            // 
            // grbImport
            // 
            this.grbImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbImport.Controls.Add(this.pbImport);
            this.grbImport.Location = new System.Drawing.Point(6, 355);
            this.grbImport.Name = "grbImport";
            this.grbImport.Size = new System.Drawing.Size(684, 47);
            this.grbImport.TabIndex = 7;
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
            this.grbFile.Controls.Add(this.flowLayoutPanel1);
            this.grbFile.Location = new System.Drawing.Point(6, 11);
            this.grbFile.Name = "grbFile";
            this.grbFile.Size = new System.Drawing.Size(683, 58);
            this.grbFile.TabIndex = 5;
            this.grbFile.TabStop = false;
            this.grbFile.Text = "导入数据文件";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnDownload);
            this.flowLayoutPanel1.Controls.Add(this.btnBrowse1);
            this.flowLayoutPanel1.Controls.Add(this.txtFile1);
            this.flowLayoutPanel1.Controls.Add(this.lblFile);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 20);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(671, 32);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // lblFile
            // 
            this.lblFile.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(40, 8);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(65, 12);
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "导入文件：";
            // 
            // txtFile1
            // 
            this.txtFile1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile1.BackColor = System.Drawing.SystemColors.Control;
            this.txtFile1.Location = new System.Drawing.Point(111, 3);
            this.txtFile1.Name = "txtFile1";
            this.txtFile1.Size = new System.Drawing.Size(380, 21);
            this.txtFile1.TabIndex = 1;
            // 
            // btnBrowse1
            // 
            this.btnBrowse1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse1.Location = new System.Drawing.Point(497, 3);
            this.btnBrowse1.Name = "btnBrowse1";
            this.btnBrowse1.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse1.TabIndex = 2;
            this.btnBrowse1.Text = "浏览...";
            this.btnBrowse1.UseVisualStyleBackColor = true;
            this.btnBrowse1.Click += new System.EventHandler(this.btnBrowse1_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.Location = new System.Drawing.Point(578, 3);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(90, 23);
            this.btnDownload.TabIndex = 3;
            this.btnDownload.Text = "下载模板";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(615, 413);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "关闭";
            // 
            // FrmImportStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 447);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grbImport);
            this.Controls.Add(this.grbFile);
            this.Controls.Add(this.btnClose);
            this.Name = "FrmImportStaff";
            this.Text = "导入员工数据";
            this.grpData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStaff)).EndInit();
            this.grbImport.ResumeLayout(false);
            this.grbFile.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.DataGridView grdStaff;
        private System.Windows.Forms.GroupBox grbImport;
        private System.Windows.Forms.ProgressBar pbImport;
        private System.Windows.Forms.GroupBox grbFile;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnBrowse1;
        private System.Windows.Forms.TextBox txtFile1;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

    }
}