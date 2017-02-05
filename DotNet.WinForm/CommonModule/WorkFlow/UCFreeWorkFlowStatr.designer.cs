namespace DotNet.WinForm
{
    partial class UCFreeWorkFlowStatr
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
            this.lblSendTo = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblAuditIdea = new System.Windows.Forms.Label();
            this.txtAuditIdea = new System.Windows.Forms.TextBox();
            this.btnSendToBy = new System.Windows.Forms.Button();
            this.btnUserSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSendTo
            // 
            this.btnSendTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendTo.Location = new System.Drawing.Point(748, 0);
            this.btnSendTo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSendTo.Name = "btnSendTo";
            this.btnSendTo.Size = new System.Drawing.Size(61, 23);
            this.btnSendTo.TabIndex = 10;
            this.btnSendTo.Text = "提交";
            this.btnSendTo.UseVisualStyleBackColor = true;
            this.btnSendTo.Click += new System.EventHandler(this.btnSendTo_Click);
            // 
            // lblSendTo
            // 
            this.lblSendTo.Location = new System.Drawing.Point(2, 6);
            this.lblSendTo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSendTo.Name = "lblSendTo";
            this.lblSendTo.Size = new System.Drawing.Size(109, 12);
            this.lblSendTo.TabIndex = 8;
            this.lblSendTo.Text = "提交给:";
            this.lblSendTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(118, 2);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.ReadOnly = true;
            this.txtFullName.Size = new System.Drawing.Size(158, 21);
            this.txtFullName.TabIndex = 11;
            // 
            // lblAuditIdea
            // 
            this.lblAuditIdea.Location = new System.Drawing.Point(365, 6);
            this.lblAuditIdea.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAuditIdea.Name = "lblAuditIdea";
            this.lblAuditIdea.Size = new System.Drawing.Size(95, 12);
            this.lblAuditIdea.TabIndex = 13;
            this.lblAuditIdea.Text = "批示:";
            this.lblAuditIdea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAuditIdea
            // 
            this.txtAuditIdea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuditIdea.Location = new System.Drawing.Point(464, 2);
            this.txtAuditIdea.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtAuditIdea.Name = "txtAuditIdea";
            this.txtAuditIdea.Size = new System.Drawing.Size(154, 21);
            this.txtAuditIdea.TabIndex = 14;
            // 
            // btnSendToBy
            // 
            this.btnSendToBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendToBy.Location = new System.Drawing.Point(618, 1);
            this.btnSendToBy.Name = "btnSendToBy";
            this.btnSendToBy.Size = new System.Drawing.Size(51, 23);
            this.btnSendToBy.TabIndex = 15;
            this.btnSendToBy.Text = "提交";
            this.btnSendToBy.UseVisualStyleBackColor = true;
            this.btnSendToBy.Click += new System.EventHandler(this.btnSendToBy_Click);
            // 
            // btnUserSelect
            // 
            this.btnUserSelect.Location = new System.Drawing.Point(276, 1);
            this.btnUserSelect.Name = "btnUserSelect";
            this.btnUserSelect.Size = new System.Drawing.Size(84, 23);
            this.btnUserSelect.TabIndex = 18;
            this.btnUserSelect.Tag = "ByUser";
            this.btnUserSelect.Text = "用户选择...";
            this.btnUserSelect.UseVisualStyleBackColor = true;
            this.btnUserSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // UCFreeWorkFlowStatr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnUserSelect);
            this.Controls.Add(this.btnSendToBy);
            this.Controls.Add(this.lblAuditIdea);
            this.Controls.Add(this.txtAuditIdea);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.btnSendTo);
            this.Controls.Add(this.lblSendTo);
            this.Name = "UCFreeWorkFlowStatr";
            this.Size = new System.Drawing.Size(670, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendTo;
        private System.Windows.Forms.Label lblSendTo;
        public System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblAuditIdea;
        public System.Windows.Forms.TextBox txtAuditIdea;
        private System.Windows.Forms.Button btnSendToBy;
        private System.Windows.Forms.Button btnUserSelect;

    }
}
