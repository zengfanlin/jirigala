namespace DotNet.WinForm
{
    partial class FrmWorkFlowTest
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCategoryId = new System.Windows.Forms.TextBox();
            this.txtObjectFullName = new System.Windows.Forms.TextBox();
            this.txtCategoryFullName = new System.Windows.Forms.TextBox();
            this.txtObjectId = new System.Windows.Forms.TextBox();
            this.btnInit = new System.Windows.Forms.Button();
            this.lblCategoryId = new System.Windows.Forms.Label();
            this.lblCategoryFullName = new System.Windows.Forms.Label();
            this.lblObjectId = new System.Windows.Forms.Label();
            this.lblObjectFullName = new System.Windows.Forms.Label();
            this.txtWorkFlowId = new System.Windows.Forms.TextBox();
            this.lblWorkFlowId = new System.Windows.Forms.Label();
            this.chkPermissionAuditing = new System.Windows.Forms.CheckBox();
            this.ucWorkFlowUser = new DotNet.WinForm.UCFreeWorkFlow();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnWorkFlowMonitor = new System.Windows.Forms.Button();
            this.btnMyWorkFlow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCategoryId
            // 
            this.txtCategoryId.Location = new System.Drawing.Point(585, 106);
            this.txtCategoryId.Name = "txtCategoryId";
            this.txtCategoryId.Size = new System.Drawing.Size(155, 21);
            this.txtCategoryId.TabIndex = 4;
            this.txtCategoryId.Text = "SCM_JHD";
            // 
            // txtObjectFullName
            // 
            this.txtObjectFullName.Location = new System.Drawing.Point(585, 191);
            this.txtObjectFullName.Name = "txtObjectFullName";
            this.txtObjectFullName.Size = new System.Drawing.Size(155, 21);
            this.txtObjectFullName.TabIndex = 12;
            this.txtObjectFullName.Text = "进货单(JHD-0001)";
            // 
            // txtCategoryFullName
            // 
            this.txtCategoryFullName.Location = new System.Drawing.Point(585, 135);
            this.txtCategoryFullName.Name = "txtCategoryFullName";
            this.txtCategoryFullName.Size = new System.Drawing.Size(155, 21);
            this.txtCategoryFullName.TabIndex = 7;
            this.txtCategoryFullName.Text = "进货单";
            // 
            // txtObjectId
            // 
            this.txtObjectId.Location = new System.Drawing.Point(585, 164);
            this.txtObjectId.Name = "txtObjectId";
            this.txtObjectId.Size = new System.Drawing.Size(155, 21);
            this.txtObjectId.TabIndex = 10;
            this.txtObjectId.Text = "JHD-0001";
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(580, 256);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(155, 38);
            this.btnInit.TabIndex = 14;
            this.btnInit.Text = "初始化工作流";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInitWorkFlow_Click);
            // 
            // lblCategoryId
            // 
            this.lblCategoryId.Location = new System.Drawing.Point(231, 110);
            this.lblCategoryId.Name = "lblCategoryId";
            this.lblCategoryId.Size = new System.Drawing.Size(345, 12);
            this.lblCategoryId.TabIndex = 3;
            this.lblCategoryId.Text = "单据分类代码（表名） CategoryId:";
            this.lblCategoryId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCategoryFullName
            // 
            this.lblCategoryFullName.Location = new System.Drawing.Point(243, 139);
            this.lblCategoryFullName.Name = "lblCategoryFullName";
            this.lblCategoryFullName.Size = new System.Drawing.Size(333, 12);
            this.lblCategoryFullName.TabIndex = 6;
            this.lblCategoryFullName.Text = "单据分类名称 CategoryFullName:";
            this.lblCategoryFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblObjectId
            // 
            this.lblObjectId.Location = new System.Drawing.Point(245, 168);
            this.lblObjectId.Name = "lblObjectId";
            this.lblObjectId.Size = new System.Drawing.Size(331, 12);
            this.lblObjectId.TabIndex = 9;
            this.lblObjectId.Text = "订单代码（Id）ObjectId:";
            this.lblObjectId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblObjectFullName
            // 
            this.lblObjectFullName.Location = new System.Drawing.Point(239, 195);
            this.lblObjectFullName.Name = "lblObjectFullName";
            this.lblObjectFullName.Size = new System.Drawing.Size(337, 12);
            this.lblObjectFullName.TabIndex = 11;
            this.lblObjectFullName.Text = "订单名称 ObjectFullName:";
            this.lblObjectFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWorkFlowId
            // 
            this.txtWorkFlowId.Location = new System.Drawing.Point(585, 70);
            this.txtWorkFlowId.Name = "txtWorkFlowId";
            this.txtWorkFlowId.Size = new System.Drawing.Size(155, 21);
            this.txtWorkFlowId.TabIndex = 2;
            // 
            // lblWorkFlowId
            // 
            this.lblWorkFlowId.Location = new System.Drawing.Point(229, 73);
            this.lblWorkFlowId.Name = "lblWorkFlowId";
            this.lblWorkFlowId.Size = new System.Drawing.Size(350, 12);
            this.lblWorkFlowId.TabIndex = 1;
            this.lblWorkFlowId.Text = "当前工作流代码（自动产生） WorkFlowId:";
            this.lblWorkFlowId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkPermissionAuditing
            // 
            this.chkPermissionAuditing.AutoSize = true;
            this.chkPermissionAuditing.Location = new System.Drawing.Point(585, 225);
            this.chkPermissionAuditing.Name = "chkPermissionAuditing";
            this.chkPermissionAuditing.Size = new System.Drawing.Size(150, 16);
            this.chkPermissionAuditing.TabIndex = 13;
            this.chkPermissionAuditing.Text = "最终审核权限 Auditing";
            this.chkPermissionAuditing.UseVisualStyleBackColor = true;
            // 
            // ucWorkFlowUser
            // 
            this.ucWorkFlowUser.AllowNull = false;
            this.ucWorkFlowUser.AllowSelect = false;
            this.ucWorkFlowUser.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucWorkFlowUser.Location = new System.Drawing.Point(35, 358);
            this.ucWorkFlowUser.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ucWorkFlowUser.MultiSelect = false;
            this.ucWorkFlowUser.Name = "ucWorkFlowUser";
            this.ucWorkFlowUser.OpenId = "";
            this.ucWorkFlowUser.PermissionAuditing = false;
            this.ucWorkFlowUser.PermissionItemScopeCode = "";
            this.ucWorkFlowUser.RemoveIds = null;
            this.ucWorkFlowUser.SelectedFullName = "";
            this.ucWorkFlowUser.SelectedId = "";
            this.ucWorkFlowUser.SelectedIds = null;
            this.ucWorkFlowUser.SetSelectIds = null;
            this.ucWorkFlowUser.ShowAuditDetail = true;
            this.ucWorkFlowUser.ShowAuditIdea = true;
            this.ucWorkFlowUser.ShowAuditQuash = false;
            this.ucWorkFlowUser.ShowAuditReject = true;
            this.ucWorkFlowUser.ShowSendTo = true;
            this.ucWorkFlowUser.Size = new System.Drawing.Size(688, 23);
            this.ucWorkFlowUser.TabIndex = 15;
            this.ucWorkFlowUser.WorkFlowCategory = "ByRole";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(35, 89);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(155, 38);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "启动工作流";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnWorkFlowMonitor
            // 
            this.btnWorkFlowMonitor.Location = new System.Drawing.Point(35, 135);
            this.btnWorkFlowMonitor.Name = "btnWorkFlowMonitor";
            this.btnWorkFlowMonitor.Size = new System.Drawing.Size(155, 38);
            this.btnWorkFlowMonitor.TabIndex = 5;
            this.btnWorkFlowMonitor.Text = "工作流状态监控";
            this.btnWorkFlowMonitor.UseVisualStyleBackColor = true;
            this.btnWorkFlowMonitor.Click += new System.EventHandler(this.btnWorkFlowMonitor_Click);
            // 
            // btnMyWorkFlow
            // 
            this.btnMyWorkFlow.Location = new System.Drawing.Point(35, 181);
            this.btnMyWorkFlow.Name = "btnMyWorkFlow";
            this.btnMyWorkFlow.Size = new System.Drawing.Size(155, 38);
            this.btnMyWorkFlow.TabIndex = 8;
            this.btnMyWorkFlow.Text = "待审批流程（我的）";
            this.btnMyWorkFlow.UseVisualStyleBackColor = true;
            this.btnMyWorkFlow.Click += new System.EventHandler(this.btnMyWorkFlow_Click);
            // 
            // FrmWorkFlowTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 474);
            this.Controls.Add(this.btnMyWorkFlow);
            this.Controls.Add(this.btnWorkFlowMonitor);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.ucWorkFlowUser);
            this.Controls.Add(this.chkPermissionAuditing);
            this.Controls.Add(this.lblWorkFlowId);
            this.Controls.Add(this.txtWorkFlowId);
            this.Controls.Add(this.lblObjectFullName);
            this.Controls.Add(this.lblObjectId);
            this.Controls.Add(this.lblCategoryFullName);
            this.Controls.Add(this.lblCategoryId);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.txtObjectId);
            this.Controls.Add(this.txtCategoryFullName);
            this.Controls.Add(this.txtObjectFullName);
            this.Controls.Add(this.txtCategoryId);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Name = "FrmWorkFlowTest";
            this.Text = "工作流测试";
            this.Load += new System.EventHandler(this.FrmWorkFlowTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCategoryId;
        private System.Windows.Forms.TextBox txtObjectFullName;
        private System.Windows.Forms.TextBox txtCategoryFullName;
        private System.Windows.Forms.TextBox txtObjectId;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Label lblCategoryId;
        private System.Windows.Forms.Label lblCategoryFullName;
        private System.Windows.Forms.Label lblObjectId;
        private System.Windows.Forms.Label lblObjectFullName;
        private System.Windows.Forms.TextBox txtWorkFlowId;
        private System.Windows.Forms.Label lblWorkFlowId;
        private System.Windows.Forms.CheckBox chkPermissionAuditing;
        private UCFreeWorkFlow ucWorkFlowUser;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnWorkFlowMonitor;
        private System.Windows.Forms.Button btnMyWorkFlow;
    }
}