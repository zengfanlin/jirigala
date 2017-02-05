namespace DotNet.WinForm
{
    partial class FrmAboutThis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAboutThis));
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblWarning = new System.Windows.Forms.Label();
            this.grpAboutThis = new System.Windows.Forms.GroupBox();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblSoftFullName = new System.Windows.Forms.Label();
            this.lblBuy = new System.Windows.Forms.LinkLabel();
            this.lblBlog = new System.Windows.Forms.LinkLabel();
            this.picCompany = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCompany)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnConfirm.Location = new System.Drawing.Point(457, 220);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 7;
            this.btnConfirm.Text = "&OK";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lblWarning
            // 
            this.lblWarning.Location = new System.Drawing.Point(79, 161);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(424, 64);
            this.lblWarning.TabIndex = 6;
            this.lblWarning.Text = resources.GetString("lblWarning.Text");
            this.lblWarning.Click += new System.EventHandler(this.FrmAboutThis_Click);
            // 
            // grpAboutThis
            // 
            this.grpAboutThis.Location = new System.Drawing.Point(26, 144);
            this.grpAboutThis.Name = "grpAboutThis";
            this.grpAboutThis.Size = new System.Drawing.Size(498, 3);
            this.grpAboutThis.TabIndex = 5;
            this.grpAboutThis.TabStop = false;
            // 
            // lblCopyright
            // 
            this.lblCopyright.Location = new System.Drawing.Point(190, 121);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(300, 16);
            this.lblCopyright.TabIndex = 4;
            this.lblCopyright.Text = "Copyright 2003-2011 Hairihan TECH";
            this.lblCopyright.Click += new System.EventHandler(this.FrmAboutThis_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.Location = new System.Drawing.Point(190, 99);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(300, 16);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "Version V3.7";
            this.lblVersion.Click += new System.EventHandler(this.FrmAboutThis_Click);
            // 
            // lblSoftFullName
            // 
            this.lblSoftFullName.Location = new System.Drawing.Point(190, 77);
            this.lblSoftFullName.Name = "lblSoftFullName";
            this.lblSoftFullName.Size = new System.Drawing.Size(300, 16);
            this.lblSoftFullName.TabIndex = 2;
            this.lblSoftFullName.Text = "DotNet Soft";
            this.lblSoftFullName.Click += new System.EventHandler(this.FrmAboutThis_Click);
            // 
            // lblBuy
            // 
            this.lblBuy.AutoSize = true;
            this.lblBuy.Location = new System.Drawing.Point(286, 16);
            this.lblBuy.Name = "lblBuy";
            this.lblBuy.Size = new System.Drawing.Size(227, 12);
            this.lblBuy.TabIndex = 0;
            this.lblBuy.TabStop = true;
            this.lblBuy.Tag = "http://jirigala.cnblogs.com";
            this.lblBuy.Text = "学习博客：http://jirigala.cnblogs.com";
            this.lblBuy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLinkLabel_LinkClicked);
            // 
            // lblBlog
            // 
            this.lblBlog.AutoSize = true;
            this.lblBlog.Location = new System.Drawing.Point(286, 32);
            this.lblBlog.Name = "lblBlog";
            this.lblBlog.Size = new System.Drawing.Size(221, 12);
            this.lblBlog.TabIndex = 1;
            this.lblBlog.TabStop = true;
            this.lblBlog.Tag = "http://jirigala.taobao.com";
            this.lblBlog.Text = "购买正版：http://jirigala.taobao.com";
            this.lblBlog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLinkLabel_LinkClicked);
            // 
            // picCompany
            // 
            this.picCompany.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picCompany.Image = global::DotNet.WinForm.Properties.Resources.Company;
            this.picCompany.Location = new System.Drawing.Point(57, 24);
            this.picCompany.Name = "picCompany";
            this.picCompany.Size = new System.Drawing.Size(100, 100);
            this.picCompany.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCompany.TabIndex = 15;
            this.picCompany.TabStop = false;
            // 
            // FrmAboutThis
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnConfirm;
            this.ClientSize = new System.Drawing.Size(550, 253);
            this.Controls.Add(this.picCompany);
            this.Controls.Add(this.lblBlog);
            this.Controls.Add(this.lblBuy);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.grpAboutThis);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblSoftFullName);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAboutThis";
            this.Text = "关于本软件";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAboutThis_FormClosing);
            this.Click += new System.EventHandler(this.FrmAboutThis_Click);
            ((System.ComponentModel.ISupportInitialize)(this.picCompany)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.GroupBox grpAboutThis;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblSoftFullName;
        private System.Windows.Forms.LinkLabel lblBuy;
        private System.Windows.Forms.LinkLabel lblBlog;
        private System.Windows.Forms.PictureBox picCompany;
    }
}