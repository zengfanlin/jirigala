namespace DotNet.WinForm
{
    partial class UCAutoWorkFlow
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
            this.lblAuditIdea = new System.Windows.Forms.Label();
            this.btnAuditReject = new System.Windows.Forms.Button();
            this.txtAuditIdea = new System.Windows.Forms.TextBox();
            this.btnAuditPass = new System.Windows.Forms.Button();
            this.btnAuditDetail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAuditIdea
            // 
            this.lblAuditIdea.Location = new System.Drawing.Point(-1, 5);
            this.lblAuditIdea.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAuditIdea.Name = "lblAuditIdea";
            this.lblAuditIdea.Size = new System.Drawing.Size(87, 12);
            this.lblAuditIdea.TabIndex = 0;
            this.lblAuditIdea.Text = "批示:";
            this.lblAuditIdea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAuditReject
            // 
            this.btnAuditReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAuditReject.ForeColor = System.Drawing.Color.Red;
            this.btnAuditReject.Location = new System.Drawing.Point(295, 0);
            this.btnAuditReject.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAuditReject.Name = "btnAuditReject";
            this.btnAuditReject.Size = new System.Drawing.Size(55, 23);
            this.btnAuditReject.TabIndex = 3;
            this.btnAuditReject.Text = "退回";
            this.btnAuditReject.UseVisualStyleBackColor = true;
            this.btnAuditReject.Click += new System.EventHandler(this.btnAuditReject_Click);
            // 
            // txtAuditIdea
            // 
            this.txtAuditIdea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuditIdea.Location = new System.Drawing.Point(90, 1);
            this.txtAuditIdea.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtAuditIdea.Name = "txtAuditIdea";
            this.txtAuditIdea.Size = new System.Drawing.Size(144, 21);
            this.txtAuditIdea.TabIndex = 1;
            // 
            // btnAuditPass
            // 
            this.btnAuditPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAuditPass.ForeColor = System.Drawing.Color.Blue;
            this.btnAuditPass.Location = new System.Drawing.Point(239, 0);
            this.btnAuditPass.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAuditPass.Name = "btnAuditPass";
            this.btnAuditPass.Size = new System.Drawing.Size(55, 23);
            this.btnAuditPass.TabIndex = 2;
            this.btnAuditPass.Text = "通过";
            this.btnAuditPass.UseVisualStyleBackColor = true;
            this.btnAuditPass.Click += new System.EventHandler(this.btnAuditPass_Click);
            // 
            // btnAuditDetail
            // 
            this.btnAuditDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAuditDetail.Location = new System.Drawing.Point(351, 0);
            this.btnAuditDetail.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAuditDetail.Name = "btnAuditDetail";
            this.btnAuditDetail.Size = new System.Drawing.Size(55, 23);
            this.btnAuditDetail.TabIndex = 4;
            this.btnAuditDetail.Text = "明细...";
            this.btnAuditDetail.UseVisualStyleBackColor = true;
            this.btnAuditDetail.Click += new System.EventHandler(this.btnAuditDetail_Click);
            // 
            // UCAutoWorkFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblAuditIdea);
            this.Controls.Add(this.btnAuditReject);
            this.Controls.Add(this.txtAuditIdea);
            this.Controls.Add(this.btnAuditPass);
            this.Controls.Add(this.btnAuditDetail);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "UCAutoWorkFlow";
            this.Size = new System.Drawing.Size(410, 23);
            this.Load += new System.EventHandler(this.UCAutoWorkFlow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAuditIdea;
        private System.Windows.Forms.Button btnAuditReject;
        public System.Windows.Forms.TextBox txtAuditIdea;
        private System.Windows.Forms.Button btnAuditPass;
        private System.Windows.Forms.Button btnAuditDetail;

    }
}
