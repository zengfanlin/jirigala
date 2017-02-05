namespace DotNet.WinForm.LogOn
{
    partial class FrmSelectNetwork
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnInner = new System.Windows.Forms.Button();
            this.btnOuter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(212, 71);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(91, 44);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnInner
            // 
            this.btnInner.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnInner.Location = new System.Drawing.Point(18, 71);
            this.btnInner.Name = "btnInner";
            this.btnInner.Size = new System.Drawing.Size(91, 44);
            this.btnInner.TabIndex = 0;
            this.btnInner.Text = "内网访问";
            this.btnInner.UseVisualStyleBackColor = true;
            this.btnInner.Click += new System.EventHandler(this.btnInner_Click);
            // 
            // btnOuter
            // 
            this.btnOuter.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOuter.Location = new System.Drawing.Point(115, 71);
            this.btnOuter.Name = "btnOuter";
            this.btnOuter.Size = new System.Drawing.Size(91, 44);
            this.btnOuter.TabIndex = 1;
            this.btnOuter.Text = "外网访问";
            this.btnOuter.UseVisualStyleBackColor = true;
            this.btnOuter.Click += new System.EventHandler(this.btnOuter_Click);
            // 
            // FrmSelectNetwork
            // 
            this.AcceptButton = this.btnInner;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DotNet.WinForm.Properties.Resources.Head;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(320, 128);
            this.Controls.Add(this.btnOuter);
            this.Controls.Add(this.btnInner);
            this.Controls.Add(this.btnExit);
            this.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSelectNetwork";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择网络连接模式";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnInner;
        private System.Windows.Forms.Button btnOuter;
    }
}