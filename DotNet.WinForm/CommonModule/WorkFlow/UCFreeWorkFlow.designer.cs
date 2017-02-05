namespace DotNet.WinForm
{
    partial class UCFreeWorkFlow
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
            this.btnAuditReject = new System.Windows.Forms.Button();
            this.lblAuditIdea = new System.Windows.Forms.Label();
            this.txtAuditIdea = new System.Windows.Forms.TextBox();
            this.lblSendTo = new System.Windows.Forms.Label();
            this.btnTransmit = new System.Windows.Forms.Button();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnAuditPass = new System.Windows.Forms.Button();
            this.btnAuditQuash = new System.Windows.Forms.Button();
            this.btnAuditDetail = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAuditReject
            // 
            this.btnAuditReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAuditReject.ForeColor = System.Drawing.Color.Red;
            this.btnAuditReject.Location = new System.Drawing.Point(325, 0);
            this.btnAuditReject.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAuditReject.Name = "btnAuditReject";
            this.btnAuditReject.Size = new System.Drawing.Size(55, 23);
            this.btnAuditReject.TabIndex = 3;
            this.btnAuditReject.Text = "退回";
            this.btnAuditReject.UseVisualStyleBackColor = true;
            this.btnAuditReject.Click += new System.EventHandler(this.btnAuditReject_Click);
            // 
            // lblAuditIdea
            // 
            this.lblAuditIdea.Location = new System.Drawing.Point(2, 5);
            this.lblAuditIdea.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAuditIdea.Name = "lblAuditIdea";
            this.lblAuditIdea.Size = new System.Drawing.Size(52, 12);
            this.lblAuditIdea.TabIndex = 0;
            this.lblAuditIdea.Text = "批示:";
            this.lblAuditIdea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAuditIdea
            // 
            this.txtAuditIdea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuditIdea.Location = new System.Drawing.Point(60, 1);
            this.txtAuditIdea.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtAuditIdea.Name = "txtAuditIdea";
            this.txtAuditIdea.Size = new System.Drawing.Size(163, 21);
            this.txtAuditIdea.TabIndex = 1;
            // 
            // lblSendTo
            // 
            this.lblSendTo.Location = new System.Drawing.Point(2, 6);
            this.lblSendTo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSendTo.Name = "lblSendTo";
            this.lblSendTo.Size = new System.Drawing.Size(59, 12);
            this.lblSendTo.TabIndex = 5;
            this.lblSendTo.Text = "提交给:";
            this.lblSendTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnTransmit
            // 
            this.btnTransmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTransmit.Location = new System.Drawing.Point(380, 0);
            this.btnTransmit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnTransmit.Name = "btnTransmit";
            this.btnTransmit.Size = new System.Drawing.Size(55, 23);
            this.btnTransmit.TabIndex = 4;
            this.btnTransmit.Text = "转发";
            this.btnTransmit.UseVisualStyleBackColor = true;
            this.btnTransmit.Click += new System.EventHandler(this.btnTransmit_Click);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.lblSendTo);
            this.splitContainerMain.Panel1.Controls.Add(this.txtFullName);
            this.splitContainerMain.Panel1.Controls.Add(this.btnSelect);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.btnAuditPass);
            this.splitContainerMain.Panel2.Controls.Add(this.lblAuditIdea);
            this.splitContainerMain.Panel2.Controls.Add(this.btnAuditReject);
            this.splitContainerMain.Panel2.Controls.Add(this.txtAuditIdea);
            this.splitContainerMain.Panel2.Controls.Add(this.btnAuditQuash);
            this.splitContainerMain.Panel2.Controls.Add(this.btnAuditDetail);
            this.splitContainerMain.Panel2.Controls.Add(this.btnTransmit);
            this.splitContainerMain.Size = new System.Drawing.Size(772, 23);
            this.splitContainerMain.SplitterDistance = 223;
            this.splitContainerMain.TabIndex = 0;
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.Location = new System.Drawing.Point(66, 0);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.ReadOnly = true;
            this.txtFullName.Size = new System.Drawing.Size(93, 21);
            this.txtFullName.TabIndex = 0;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(165, 0);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(55, 23);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "选择...";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnAuditPass
            // 
            this.btnAuditPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAuditPass.ForeColor = System.Drawing.Color.Blue;
            this.btnAuditPass.Location = new System.Drawing.Point(269, 0);
            this.btnAuditPass.Name = "btnAuditPass";
            this.btnAuditPass.Size = new System.Drawing.Size(55, 23);
            this.btnAuditPass.TabIndex = 2;
            this.btnAuditPass.Text = "通过";
            this.btnAuditPass.UseVisualStyleBackColor = true;
            this.btnAuditPass.Click += new System.EventHandler(this.btnAuditPass_Click);
            // 
            // btnAuditQuash
            // 
            this.btnAuditQuash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAuditQuash.ForeColor = System.Drawing.Color.Black;
            this.btnAuditQuash.Location = new System.Drawing.Point(490, 0);
            this.btnAuditQuash.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAuditQuash.Name = "btnAuditQuash";
            this.btnAuditQuash.Size = new System.Drawing.Size(55, 23);
            this.btnAuditQuash.TabIndex = 6;
            this.btnAuditQuash.Text = "撤消";
            this.btnAuditQuash.UseVisualStyleBackColor = true;
            this.btnAuditQuash.Visible = false;
            this.btnAuditQuash.Click += new System.EventHandler(this.btnAuditQuash_Click);
            // 
            // btnAuditDetail
            // 
            this.btnAuditDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAuditDetail.Location = new System.Drawing.Point(435, 0);
            this.btnAuditDetail.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAuditDetail.Name = "btnAuditDetail";
            this.btnAuditDetail.Size = new System.Drawing.Size(55, 23);
            this.btnAuditDetail.TabIndex = 5;
            this.btnAuditDetail.Text = "明细...";
            this.btnAuditDetail.UseVisualStyleBackColor = true;
            this.btnAuditDetail.Click += new System.EventHandler(this.btnAuditDetail_Click);
            // 
            // UCFreeWorkFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "UCFreeWorkFlow";
            this.Size = new System.Drawing.Size(772, 23);
            this.Load += new System.EventHandler(this.UCFreeWorkFlow_Load);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAuditReject;
        private System.Windows.Forms.Label lblAuditIdea;
        private System.Windows.Forms.Label lblSendTo;
        private System.Windows.Forms.Button btnTransmit;
        public System.Windows.Forms.TextBox txtAuditIdea;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Button btnAuditQuash;
        private System.Windows.Forms.Button btnAuditDetail;
        private System.Windows.Forms.Button btnAuditPass;
    }
}
