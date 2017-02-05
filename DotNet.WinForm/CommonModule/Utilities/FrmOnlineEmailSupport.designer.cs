namespace DotNet.WinForm
{
    partial class FrmOnlineEmailSupport
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.grbOnlineEmailSupport = new System.Windows.Forms.GroupBox();
            this.txtSendTo = new System.Windows.Forms.TextBox();
            this.lblSendTo = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblExceptionInfo = new System.Windows.Forms.Label();
            this.grbOnlineEmailSupport.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(650, 385);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendEmail.Enabled = false;
            this.btnSendEmail.Location = new System.Drawing.Point(537, 385);
            this.btnSendEmail.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(109, 23);
            this.btnSendEmail.TabIndex = 4;
            this.btnSendEmail.Text = "发送邮件(&S)";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // grbOnlineEmailSupport
            // 
            this.grbOnlineEmailSupport.Controls.Add(this.txtSendTo);
            this.grbOnlineEmailSupport.Controls.Add(this.lblSendTo);
            this.grbOnlineEmailSupport.Controls.Add(this.txtContent);
            this.grbOnlineEmailSupport.Controls.Add(this.lblExceptionInfo);
            this.grbOnlineEmailSupport.Location = new System.Drawing.Point(13, 13);
            this.grbOnlineEmailSupport.Name = "grbOnlineEmailSupport";
            this.grbOnlineEmailSupport.Size = new System.Drawing.Size(710, 364);
            this.grbOnlineEmailSupport.TabIndex = 6;
            this.grbOnlineEmailSupport.TabStop = false;
            this.grbOnlineEmailSupport.Text = "在线技术支持：";
            // 
            // txtSendTo
            // 
            this.txtSendTo.Location = new System.Drawing.Point(108, 21);
            this.txtSendTo.MaxLength = 200;
            this.txtSendTo.Name = "txtSendTo";
            this.txtSendTo.ReadOnly = true;
            this.txtSendTo.Size = new System.Drawing.Size(569, 21);
            this.txtSendTo.TabIndex = 5;
            this.txtSendTo.TabStop = false;
            // 
            // lblSendTo
            // 
            this.lblSendTo.AutoSize = true;
            this.lblSendTo.Location = new System.Drawing.Point(38, 24);
            this.lblSendTo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSendTo.Name = "lblSendTo";
            this.lblSendTo.Size = new System.Drawing.Size(53, 12);
            this.lblSendTo.TabIndex = 4;
            this.lblSendTo.Text = "发送给：";
            // 
            // txtContent
            // 
            this.txtContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContent.Location = new System.Drawing.Point(108, 51);
            this.txtContent.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(570, 293);
            this.txtContent.TabIndex = 7;
            // 
            // lblExceptionInfo
            // 
            this.lblExceptionInfo.AutoSize = true;
            this.lblExceptionInfo.Location = new System.Drawing.Point(32, 51);
            this.lblExceptionInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblExceptionInfo.Name = "lblExceptionInfo";
            this.lblExceptionInfo.Size = new System.Drawing.Size(59, 12);
            this.lblExceptionInfo.TabIndex = 6;
            this.lblExceptionInfo.Text = "内容(&I)：";
            // 
            // FrmOnlineEmailSupport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(735, 414);
            this.Controls.Add(this.grbOnlineEmailSupport);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSendEmail);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MinimumSize = new System.Drawing.Size(346, 209);
            this.Name = "FrmOnlineEmailSupport";
            this.Text = "在线技术支持";
            this.grbOnlineEmailSupport.ResumeLayout(false);
            this.grbOnlineEmailSupport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.GroupBox grbOnlineEmailSupport;
        private System.Windows.Forms.TextBox txtSendTo;
        private System.Windows.Forms.Label lblSendTo;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblExceptionInfo;
    }
}