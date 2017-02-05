namespace DotNet.WinForm
{
    partial class UCWorkFlowStatr
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
            this.btnSendToBy = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblSendTo = new System.Windows.Forms.Label();
            this.txtAuditIdea = new System.Windows.Forms.TextBox();
            this.lblAuditIdea = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSendToBy
            // 
            this.btnSendToBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendToBy.Location = new System.Drawing.Point(537, 0);
            this.btnSendToBy.Name = "btnSendToBy";
            this.btnSendToBy.Size = new System.Drawing.Size(65, 23);
            this.btnSendToBy.TabIndex = 7;
            this.btnSendToBy.Text = "提交";
            this.btnSendToBy.UseVisualStyleBackColor = true;
            this.btnSendToBy.Click += new System.EventHandler(this.btnSendToBy_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(235, 0);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(65, 23);
            this.btnSelect.TabIndex = 6;
            this.btnSelect.Text = "选择...";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtFullName
            // 
            this.txtFullName.BackColor = System.Drawing.SystemColors.Control;
            this.txtFullName.Enabled = false;
            this.txtFullName.Location = new System.Drawing.Point(85, 1);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(149, 21);
            this.txtFullName.TabIndex = 5;
            // 
            // lblSendTo
            // 
            this.lblSendTo.Location = new System.Drawing.Point(3, 6);
            this.lblSendTo.Name = "lblSendTo";
            this.lblSendTo.Size = new System.Drawing.Size(80, 12);
            this.lblSendTo.TabIndex = 4;
            this.lblSendTo.Text = "提交给：";
            this.lblSendTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAuditIdea
            // 
            this.txtAuditIdea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuditIdea.BackColor = System.Drawing.SystemColors.Window;
            this.txtAuditIdea.Location = new System.Drawing.Point(389, 1);
            this.txtAuditIdea.Name = "txtAuditIdea";
            this.txtAuditIdea.Size = new System.Drawing.Size(147, 21);
            this.txtAuditIdea.TabIndex = 8;
            // 
            // lblAuditIdea
            // 
            this.lblAuditIdea.Location = new System.Drawing.Point(303, 5);
            this.lblAuditIdea.Name = "lblAuditIdea";
            this.lblAuditIdea.Size = new System.Drawing.Size(80, 12);
            this.lblAuditIdea.TabIndex = 9;
            this.lblAuditIdea.Text = "批示：";
            this.lblAuditIdea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UCWorkFlowStatr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblAuditIdea);
            this.Controls.Add(this.txtAuditIdea);
            this.Controls.Add(this.btnSendToBy);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblSendTo);
            this.Name = "UCWorkFlowStatr";
            this.Size = new System.Drawing.Size(602, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendToBy;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblSendTo;
        private System.Windows.Forms.TextBox txtAuditIdea;
        private System.Windows.Forms.Label lblAuditIdea;
    }
}
