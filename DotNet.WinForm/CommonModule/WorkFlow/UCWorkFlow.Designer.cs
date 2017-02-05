namespace DotNet.WinForm
{
    partial class UCWorkFlow
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
            this.btnAuditPass = new System.Windows.Forms.Button();
            this.txtAuditIdea = new System.Windows.Forms.TextBox();
            this.lblAuditIdea = new System.Windows.Forms.Label();
            this.btnAuditReject = new System.Windows.Forms.Button();
            this.btnTransmit = new System.Windows.Forms.Button();
            this.btnAuditQuash = new System.Windows.Forms.Button();
            this.btnAuditDetail = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblSendTo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAuditPass
            // 
            this.btnAuditPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAuditPass.ForeColor = System.Drawing.Color.Blue;
            this.btnAuditPass.Location = new System.Drawing.Point(574, 0);
            this.btnAuditPass.Name = "btnAuditPass";
            this.btnAuditPass.Size = new System.Drawing.Size(65, 23);
            this.btnAuditPass.TabIndex = 4;
            this.btnAuditPass.Text = "通过";
            this.btnAuditPass.UseVisualStyleBackColor = true;
            this.btnAuditPass.Click += new System.EventHandler(this.btnAuditPass_Click);
            // 
            // txtAuditIdea
            // 
            this.txtAuditIdea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuditIdea.BackColor = System.Drawing.SystemColors.Window;
            this.txtAuditIdea.Location = new System.Drawing.Point(393, 1);
            this.txtAuditIdea.Name = "txtAuditIdea";
            this.txtAuditIdea.Size = new System.Drawing.Size(180, 21);
            this.txtAuditIdea.TabIndex = 5;
            // 
            // lblAuditIdea
            // 
            this.lblAuditIdea.Location = new System.Drawing.Point(307, 5);
            this.lblAuditIdea.Name = "lblAuditIdea";
            this.lblAuditIdea.Size = new System.Drawing.Size(80, 12);
            this.lblAuditIdea.TabIndex = 6;
            this.lblAuditIdea.Text = "批示：";
            this.lblAuditIdea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAuditReject
            // 
            this.btnAuditReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAuditReject.ForeColor = System.Drawing.Color.Red;
            this.btnAuditReject.Location = new System.Drawing.Point(638, 0);
            this.btnAuditReject.Name = "btnAuditReject";
            this.btnAuditReject.Size = new System.Drawing.Size(65, 23);
            this.btnAuditReject.TabIndex = 7;
            this.btnAuditReject.Text = "退回";
            this.btnAuditReject.UseVisualStyleBackColor = true;
            this.btnAuditReject.Click += new System.EventHandler(this.btnAuditReject_Click);
            // 
            // btnTransmit
            // 
            this.btnTransmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTransmit.Location = new System.Drawing.Point(702, 0);
            this.btnTransmit.Name = "btnTransmit";
            this.btnTransmit.Size = new System.Drawing.Size(65, 23);
            this.btnTransmit.TabIndex = 8;
            this.btnTransmit.Text = "转发";
            this.btnTransmit.UseVisualStyleBackColor = true;
            this.btnTransmit.Click += new System.EventHandler(this.btnTransmit_Click);
            // 
            // btnAuditQuash
            // 
            this.btnAuditQuash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAuditQuash.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnAuditQuash.Location = new System.Drawing.Point(766, 0);
            this.btnAuditQuash.Name = "btnAuditQuash";
            this.btnAuditQuash.Size = new System.Drawing.Size(65, 23);
            this.btnAuditQuash.TabIndex = 9;
            this.btnAuditQuash.Text = "撤销";
            this.btnAuditQuash.UseVisualStyleBackColor = true;
            this.btnAuditQuash.Click += new System.EventHandler(this.btnAuditQuash_Click);
            // 
            // btnAuditDetail
            // 
            this.btnAuditDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAuditDetail.Location = new System.Drawing.Point(830, 0);
            this.btnAuditDetail.Name = "btnAuditDetail";
            this.btnAuditDetail.Size = new System.Drawing.Size(65, 23);
            this.btnAuditDetail.TabIndex = 10;
            this.btnAuditDetail.Text = "明细";
            this.btnAuditDetail.UseVisualStyleBackColor = true;
            this.btnAuditDetail.Click += new System.EventHandler(this.btnAuditDetail_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(236, 0);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(65, 23);
            this.btnSelect.TabIndex = 13;
            this.btnSelect.Text = "选择...";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtFullName
            // 
            this.txtFullName.BackColor = System.Drawing.SystemColors.Control;
            this.txtFullName.Enabled = false;
            this.txtFullName.Location = new System.Drawing.Point(86, 1);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(149, 21);
            this.txtFullName.TabIndex = 12;
            // 
            // lblSendTo
            // 
            this.lblSendTo.Location = new System.Drawing.Point(4, 6);
            this.lblSendTo.Name = "lblSendTo";
            this.lblSendTo.Size = new System.Drawing.Size(80, 12);
            this.lblSendTo.TabIndex = 11;
            this.lblSendTo.Text = "提交给：";
            this.lblSendTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UCWorkFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblSendTo);
            this.Controls.Add(this.btnAuditDetail);
            this.Controls.Add(this.btnAuditQuash);
            this.Controls.Add(this.btnTransmit);
            this.Controls.Add(this.btnAuditReject);
            this.Controls.Add(this.lblAuditIdea);
            this.Controls.Add(this.txtAuditIdea);
            this.Controls.Add(this.btnAuditPass);
            this.Name = "UCWorkFlow";
            this.Size = new System.Drawing.Size(897, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAuditPass;
        private System.Windows.Forms.TextBox txtAuditIdea;
        private System.Windows.Forms.Label lblAuditIdea;
        private System.Windows.Forms.Button btnAuditReject;
        private System.Windows.Forms.Button btnTransmit;
        private System.Windows.Forms.Button btnAuditQuash;
        private System.Windows.Forms.Button btnAuditDetail;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblSendTo;
    }
}
