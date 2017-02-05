namespace DotNet.WinForm
{
    partial class FrmSignature
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSignature));
            this.ucPicture = new DotNet.WinForm.UCPicture();
            this.SuspendLayout();
            // 
            // ucPicture
            // 
            this.ucPicture.AllowDrop = true;
            this.ucPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPicture.FolderId = "";
            this.ucPicture.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucPicture.Location = new System.Drawing.Point(0, 0);
            this.ucPicture.Name = "ucPicture";
            this.ucPicture.PictureId = "";
            this.ucPicture.Size = new System.Drawing.Size(331, 218);
            this.ucPicture.TabIndex = 37;
            // 
            // FrmSignature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 218);
            this.Controls.Add(this.ucPicture);
            this.Name = "FrmSignature";
            this.Text = "用户签名";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSignature_FormClosing);
            this.Load += new System.EventHandler(this.FrmSignature_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DotNet.WinForm.UCPicture ucPicture;
    }
}