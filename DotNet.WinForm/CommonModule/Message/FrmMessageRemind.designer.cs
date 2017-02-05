namespace DotNet.WinForm
{
    partial class FrmMessageRemind
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
            this.grbMessage = new System.Windows.Forms.GroupBox();
            this.txtContents = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnReply = new System.Windows.Forms.Button();
            this.grbMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbMessage
            // 
            this.grbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbMessage.Controls.Add(this.txtContents);
            this.grbMessage.Location = new System.Drawing.Point(11, 9);
            this.grbMessage.Name = "grbMessage";
            this.grbMessage.Size = new System.Drawing.Size(262, 168);
            this.grbMessage.TabIndex = 0;
            this.grbMessage.TabStop = false;
            this.grbMessage.Text = "消息";
            // 
            // txtContents
            // 
            this.txtContents.AllowDrop = true;
            this.txtContents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContents.Location = new System.Drawing.Point(14, 20);
            this.txtContents.MaxLength = 800;
            this.txtContents.Multiline = true;
            this.txtContents.Name = "txtContents";
            this.txtContents.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContents.Size = new System.Drawing.Size(242, 137);
            this.txtContents.TabIndex = 15;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(197, 154);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 10;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnReply
            // 
            this.btnReply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReply.Location = new System.Drawing.Point(116, 154);
            this.btnReply.Name = "btnReply";
            this.btnReply.Size = new System.Drawing.Size(75, 23);
            this.btnReply.TabIndex = 12;
            this.btnReply.Text = "回复(&S)";
            this.btnReply.Visible = false;
            this.btnReply.Click += new System.EventHandler(this.btnReply_Click);
            // 
            // FrmMessageRemind
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 187);
            this.Controls.Add(this.grbMessage);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnReply);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMessageRemind";
            this.ShowInTaskbar = true;
            this.Text = "消息提醒";
            this.TopMost = true;
            this.grbMessage.ResumeLayout(false);
            this.grbMessage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbMessage;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnReply;
        private System.Windows.Forms.TextBox txtContents;
    }
}