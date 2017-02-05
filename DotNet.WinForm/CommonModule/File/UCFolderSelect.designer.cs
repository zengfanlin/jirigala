namespace DotNet.WinForm
{
    partial class UCFolderSelect
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

        #region 组件设计器生成的主键

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用主键编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlNull = new System.Windows.Forms.Panel();
            this.btnSetNull = new System.Windows.Forms.Button();
            this.pnlSelect = new System.Windows.Forms.Panel();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.pnlFolder = new System.Windows.Forms.Panel();
            this.txtFolder1 = new System.Windows.Forms.TextBox();
            this.pnlNull.SuspendLayout();
            this.pnlSelect.SuspendLayout();
            this.pnlFolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNull
            // 
            this.pnlNull.Controls.Add(this.btnSetNull);
            this.pnlNull.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlNull.Location = new System.Drawing.Point(266, 0);
            this.pnlNull.Name = "pnlNull";
            this.pnlNull.Size = new System.Drawing.Size(50, 22);
            this.pnlNull.TabIndex = 5;
            // 
            // btnSetNull
            // 
            this.btnSetNull.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSetNull.Location = new System.Drawing.Point(2, 0);
            this.btnSetNull.Name = "btnSetNull";
            this.btnSetNull.Size = new System.Drawing.Size(48, 22);
            this.btnSetNull.TabIndex = 0;
            this.btnSetNull.Text = "置空";
            this.btnSetNull.UseVisualStyleBackColor = true;
            this.btnSetNull.Click += new System.EventHandler(this.btnSetNull_Click);
            // 
            // pnlSelect
            // 
            this.pnlSelect.Controls.Add(this.btnSelectFolder);
            this.pnlSelect.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSelect.Location = new System.Drawing.Point(189, 0);
            this.pnlSelect.Name = "pnlSelect";
            this.pnlSelect.Size = new System.Drawing.Size(77, 22);
            this.pnlSelect.TabIndex = 6;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSelectFolder.Location = new System.Drawing.Point(2, 0);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(75, 22);
            this.btnSelectFolder.TabIndex = 0;
            this.btnSelectFolder.Text = "选择...";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // pnlFolder
            // 
            this.pnlFolder.Controls.Add(this.txtFolder1);
            this.pnlFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFolder.Location = new System.Drawing.Point(0, 0);
            this.pnlFolder.Name = "pnlFolder";
            this.pnlFolder.Size = new System.Drawing.Size(189, 22);
            this.pnlFolder.TabIndex = 1;
            // 
            // txtFolder1
            // 
            this.txtFolder1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFolder1.Location = new System.Drawing.Point(0, 0);
            this.txtFolder1.Name = "txtFolder1";
            this.txtFolder1.ReadOnly = true;
            this.txtFolder1.Size = new System.Drawing.Size(189, 21);
            this.txtFolder1.TabIndex = 0;
            // 
            // UCFolderSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlFolder);
            this.Controls.Add(this.pnlSelect);
            this.Controls.Add(this.pnlNull);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Name = "UCFolderSelect";
            this.Size = new System.Drawing.Size(316, 22);
            this.pnlNull.ResumeLayout(false);
            this.pnlSelect.ResumeLayout(false);
            this.pnlFolder.ResumeLayout(false);
            this.pnlFolder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNull;
        private System.Windows.Forms.Button btnSetNull;
        private System.Windows.Forms.Panel pnlSelect;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Panel pnlFolder;
        private System.Windows.Forms.TextBox txtFolder1;
    }
}