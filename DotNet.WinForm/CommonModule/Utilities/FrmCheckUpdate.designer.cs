namespace DotNet.WinForm
{
    partial class FrmCheckUpdate
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
            this.btnConfirm = new System.Windows.Forms.Button();
            this.grpAboutThis = new System.Windows.Forms.GroupBox();
            this.lblBuy = new System.Windows.Forms.LinkLabel();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblCurrentVersion = new System.Windows.Forms.Label();
            this.lblNewVersion = new System.Windows.Forms.Label();
            this.lblNew = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
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
            // grpAboutThis
            // 
            this.grpAboutThis.Location = new System.Drawing.Point(26, 144);
            this.grpAboutThis.Name = "grpAboutThis";
            this.grpAboutThis.Size = new System.Drawing.Size(498, 3);
            this.grpAboutThis.TabIndex = 5;
            this.grpAboutThis.TabStop = false;
            // 
            // lblBuy
            // 
            this.lblBuy.AutoSize = true;
            this.lblBuy.Location = new System.Drawing.Point(24, 161);
            this.lblBuy.Name = "lblBuy";
            this.lblBuy.Size = new System.Drawing.Size(227, 12);
            this.lblBuy.TabIndex = 8;
            this.lblBuy.TabStop = true;
            this.lblBuy.Tag = "http://jirigala.cnblogs.com";
            this.lblBuy.Text = "官方博客：http://jirigala.cnblogs.com";
            this.lblBuy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLinkLabel_LinkClicked);
            // 
            // lblCopyright
            // 
            this.lblCopyright.Location = new System.Drawing.Point(221, 123);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(300, 16);
            this.lblCopyright.TabIndex = 9;
            this.lblCopyright.Text = "Copyright 2003-2011 Hairihan TECH";
            // 
            // lblCurrentVersion
            // 
            this.lblCurrentVersion.Location = new System.Drawing.Point(299, 67);
            this.lblCurrentVersion.Name = "lblCurrentVersion";
            this.lblCurrentVersion.Size = new System.Drawing.Size(171, 16);
            this.lblCurrentVersion.TabIndex = 10;
            this.lblCurrentVersion.Text = "Version V3.7";
            this.lblCurrentVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNewVersion
            // 
            this.lblNewVersion.Location = new System.Drawing.Point(299, 41);
            this.lblNewVersion.Name = "lblNewVersion";
            this.lblNewVersion.Size = new System.Drawing.Size(171, 16);
            this.lblNewVersion.TabIndex = 11;
            this.lblNewVersion.Text = "Version V3.7";
            this.lblNewVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNew
            // 
            this.lblNew.Location = new System.Drawing.Point(166, 41);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(124, 16);
            this.lblNew.TabIndex = 12;
            this.lblNew.Text = "最新版本：";
            this.lblNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCurrent
            // 
            this.lblCurrent.Location = new System.Drawing.Point(168, 67);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(122, 16);
            this.lblCurrent.TabIndex = 13;
            this.lblCurrent.Text = "当前版本：";
            this.lblCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picCompany
            // 
            this.picCompany.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picCompany.Image = global::DotNet.WinForm.Properties.Resources.Company;
            this.picCompany.Location = new System.Drawing.Point(60, 25);
            this.picCompany.Name = "picCompany";
            this.picCompany.Size = new System.Drawing.Size(100, 100);
            this.picCompany.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCompany.TabIndex = 14;
            this.picCompany.TabStop = false;
            // 
            // FrmCheckUpdate
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnConfirm;
            this.ClientSize = new System.Drawing.Size(550, 253);
            this.Controls.Add(this.picCompany);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.lblNew);
            this.Controls.Add(this.lblNewVersion);
            this.Controls.Add(this.lblCurrentVersion);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.lblBuy);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.grpAboutThis);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCheckUpdate";
            this.Text = "通用权限管理系统组件";
            this.Click += new System.EventHandler(this.FrmAboutThis_Click);
            ((System.ComponentModel.ISupportInitialize)(this.picCompany)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.GroupBox grpAboutThis;
        private System.Windows.Forms.LinkLabel lblBuy;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblCurrentVersion;
        private System.Windows.Forms.Label lblNewVersion;
        private System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.PictureBox picCompany;
    }
}