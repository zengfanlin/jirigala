namespace DotNet.WinForm
{
    partial class FrmMessageBroadcast
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
            this.colorDialogMsg = new System.Windows.Forms.ColorDialog();
            this.fontDialogMsg = new System.Windows.Forms.FontDialog();
            this.grbMessage = new System.Windows.Forms.GroupBox();
            this.lblContentReq = new System.Windows.Forms.Label();
            this.txtContents = new System.Windows.Forms.TextBox();
            this.lblContents = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grbMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbMessage
            // 
            this.grbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbMessage.Controls.Add(this.lblContentReq);
            this.grbMessage.Controls.Add(this.txtContents);
            this.grbMessage.Controls.Add(this.lblContents);
            this.grbMessage.Location = new System.Drawing.Point(13, 13);
            this.grbMessage.Name = "grbMessage";
            this.grbMessage.Size = new System.Drawing.Size(565, 224);
            this.grbMessage.TabIndex = 0;
            this.grbMessage.TabStop = false;
            this.grbMessage.Text = "消息";
            // 
            // lblContentReq
            // 
            this.lblContentReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContentReq.AutoSize = true;
            this.lblContentReq.ForeColor = System.Drawing.Color.Red;
            this.lblContentReq.Location = new System.Drawing.Point(547, 22);
            this.lblContentReq.Name = "lblContentReq";
            this.lblContentReq.Size = new System.Drawing.Size(11, 12);
            this.lblContentReq.TabIndex = 17;
            this.lblContentReq.Text = "*";
            // 
            // txtContents
            // 
            this.txtContents.AllowDrop = true;
            this.txtContents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContents.Location = new System.Drawing.Point(99, 20);
            this.txtContents.MaxLength = 800;
            this.txtContents.Multiline = true;
            this.txtContents.Name = "txtContents";
            this.txtContents.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContents.Size = new System.Drawing.Size(445, 193);
            this.txtContents.TabIndex = 14;
            this.txtContents.TextChanged += new System.EventHandler(this.txtContent_TextChanged);
            // 
            // lblContents
            // 
            this.lblContents.Location = new System.Drawing.Point(3, 23);
            this.lblContents.Name = "lblContents";
            this.lblContents.Size = new System.Drawing.Size(90, 12);
            this.lblContents.TabIndex = 13;
            this.lblContents.Text = "内容(&C)：";
            this.lblContents.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(422, 247);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 17;
            this.btnSend.Text = "发送(&S)";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(503, 247);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmMessageBroadcast
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 282);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grbMessage);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmMessageBroadcast";
            this.Text = "广播消息";
            this.grbMessage.ResumeLayout(false);
            this.grbMessage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialogMsg;
        private System.Windows.Forms.FontDialog fontDialogMsg;
        private System.Windows.Forms.GroupBox grbMessage;
        private System.Windows.Forms.Label lblContentReq;
        private System.Windows.Forms.TextBox txtContents;
        private System.Windows.Forms.Label lblContents;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCancel;
    }
}