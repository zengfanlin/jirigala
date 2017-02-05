namespace DotNet.WinForm
{
    partial class UCAutoWorkFlowStatr
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSendTo = new System.Windows.Forms.Button();
            this.lblAuditIdea = new System.Windows.Forms.Label();
            this.txtAuditIdea = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSendTo
            // 
            this.btnSendTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendTo.Location = new System.Drawing.Point(233, 0);
            this.btnSendTo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSendTo.Name = "btnSendTo";
            this.btnSendTo.Size = new System.Drawing.Size(61, 23);
            this.btnSendTo.TabIndex = 10;
            this.btnSendTo.Text = "提交";
            this.btnSendTo.UseVisualStyleBackColor = true;
            this.btnSendTo.Click += new System.EventHandler(this.btnSendTo_Click);
            // 
            // lblAuditIdea
            // 
            this.lblAuditIdea.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAuditIdea.AutoSize = false;
            this.lblAuditIdea.Location = new System.Drawing.Point(0, 6);
            this.lblAuditIdea.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAuditIdea.Name = "lblAuditIdea";
            this.lblAuditIdea.Size = new System.Drawing.Size(74, 12);
            this.lblAuditIdea.TabIndex = 13;
            this.lblAuditIdea.Text = "批示:";
            this.lblAuditIdea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAuditIdea
            // 
            this.txtAuditIdea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuditIdea.Location = new System.Drawing.Point(78, 1);
            this.txtAuditIdea.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtAuditIdea.Name = "txtAuditIdea";
            this.txtAuditIdea.Size = new System.Drawing.Size(151, 21);
            this.txtAuditIdea.TabIndex = 14;
            // 
            // UCAutoWorkFlowStatr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblAuditIdea);
            this.Controls.Add(this.txtAuditIdea);
            this.Controls.Add(this.btnSendTo);
            this.Name = "UCAutoWorkFlowStatr";
            this.Size = new System.Drawing.Size(296, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendTo;
        private System.Windows.Forms.Label lblAuditIdea;
        public System.Windows.Forms.TextBox txtAuditIdea;

    }
}
