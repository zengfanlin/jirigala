namespace DotNet.WinForm
{
    partial class FrmWorkFlowStatr
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
            this.ucWorkFlowStatr1 = new DotNet.WinForm.UCWorkFlowStatr();
            this.ucFreeStatr = new DotNet.WinForm.UCFreeWorkFlowStatr();
            this.lblWorkFlowCode = new System.Windows.Forms.Label();
            this.txtWorkFlowCode = new System.Windows.Forms.TextBox();
            this.ucAutoStatr = new DotNet.WinForm.UCAutoWorkFlowStatr();
            this.lblObjectFullName = new System.Windows.Forms.Label();
            this.lblObjectId = new System.Windows.Forms.Label();
            this.lblCategoryFullName = new System.Windows.Forms.Label();
            this.lblCategoryId = new System.Windows.Forms.Label();
            this.txtObjectId = new System.Windows.Forms.TextBox();
            this.txtCategoryFullName = new System.Windows.Forms.TextBox();
            this.txtObjectFullName = new System.Windows.Forms.TextBox();
            this.txtCategoryId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ucWorkFlowStatr1
            // 
            this.ucWorkFlowStatr1.AllowNull = true;
            this.ucWorkFlowStatr1.AllowSelect = true;
            this.ucWorkFlowStatr1.Location = new System.Drawing.Point(236, 151);
            this.ucWorkFlowStatr1.MultiSelect = false;
            this.ucWorkFlowStatr1.Name = "ucWorkFlowStatr1";
            this.ucWorkFlowStatr1.PermissionItemScopeCode = "";
            this.ucWorkFlowStatr1.SelectedFullName = "";
            this.ucWorkFlowStatr1.SelectedIds = null;
            this.ucWorkFlowStatr1.Size = new System.Drawing.Size(602, 23);
            this.ucWorkFlowStatr1.TabIndex = 15;
            this.ucWorkFlowStatr1.WorkFlowCategory = "ByUser";
            this.ucWorkFlowStatr1.WorkFlowCode = "";
            this.ucWorkFlowStatr1.WorkFlowType = "FreeFlow";
            this.ucWorkFlowStatr1.BeforBtnSendToClick += new DotNet.WinForm.UCWorkFlowStatr.ButtonSendToClickEventHandler(this.ucWorkFlowStatr1_BeforBtnSendToClick);
            // 
            // ucFreeStatr
            // 
            this.ucFreeStatr.AllowNull = true;
            this.ucFreeStatr.AllowSelect = false;
            this.ucFreeStatr.Location = new System.Drawing.Point(12, 464);
            this.ucFreeStatr.MultiSelect = true;
            this.ucFreeStatr.Name = "ucFreeStatr";
            this.ucFreeStatr.OpenId = "";
            this.ucFreeStatr.OrganizeSelect = true;
            this.ucFreeStatr.PermissionItemScopeCode = "";
            this.ucFreeStatr.RemoveIds = null;
            this.ucFreeStatr.RoleSelect = true;
            this.ucFreeStatr.SelectedFullName = "";
            this.ucFreeStatr.SelectedId = "";
            this.ucFreeStatr.SelectedIds = null;
            this.ucFreeStatr.SelectedOrganizeFullName = "";
            this.ucFreeStatr.SelectedOrganizeId = "";
            this.ucFreeStatr.SelectedOrganizeIds = null;
            this.ucFreeStatr.SelectedRoleFullName = "";
            this.ucFreeStatr.SelectedRoleId = "";
            this.ucFreeStatr.SelectedRoleIds = null;
            this.ucFreeStatr.SelectedUserFullName = "";
            this.ucFreeStatr.SelectedUserId = "";
            this.ucFreeStatr.SelectedUserIds = null;
            this.ucFreeStatr.SelectMulti = true;
            this.ucFreeStatr.SendMessage = "";
            this.ucFreeStatr.SetSelectIds = null;
            this.ucFreeStatr.Size = new System.Drawing.Size(855, 24);
            this.ucFreeStatr.TabIndex = 14;
            this.ucFreeStatr.UserSelect = true;
            this.ucFreeStatr.WorkFlowCategory = "ByRole";
            this.ucFreeStatr.BeforBtnSendToClick += new DotNet.WinForm.UCFreeWorkFlowStatr.ButtonSendToClickEventHandler(this.ucUserStatr_BeforBtnSendToClick);
            // 
            // lblWorkFlowCode
            // 
            this.lblWorkFlowCode.Location = new System.Drawing.Point(10, 509);
            this.lblWorkFlowCode.Name = "lblWorkFlowCode";
            this.lblWorkFlowCode.Size = new System.Drawing.Size(258, 12);
            this.lblWorkFlowCode.TabIndex = 12;
            this.lblWorkFlowCode.Text = "走哪个工作流(是按工作流编号来确认的):";
            this.lblWorkFlowCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWorkFlowCode
            // 
            this.txtWorkFlowCode.Location = new System.Drawing.Point(268, 505);
            this.txtWorkFlowCode.Name = "txtWorkFlowCode";
            this.txtWorkFlowCode.Size = new System.Drawing.Size(301, 21);
            this.txtWorkFlowCode.TabIndex = 13;
            // 
            // ucAutoStatr
            // 
            this.ucAutoStatr.Location = new System.Drawing.Point(191, 532);
            this.ucAutoStatr.Name = "ucAutoStatr";
            this.ucAutoStatr.SelectedIds = null;
            this.ucAutoStatr.SetSelectIds = null;
            this.ucAutoStatr.Size = new System.Drawing.Size(378, 23);
            this.ucAutoStatr.TabIndex = 11;
            this.ucAutoStatr.BeforBtnSendToClick += new DotNet.WinForm.UCAutoWorkFlowStatr.ButtonSendToClickEventHandler(this.ucAutoStatr_BeforBtnSendToClick);
            // 
            // lblObjectFullName
            // 
            this.lblObjectFullName.Location = new System.Drawing.Point(116, 130);
            this.lblObjectFullName.Name = "lblObjectFullName";
            this.lblObjectFullName.Size = new System.Drawing.Size(258, 12);
            this.lblObjectFullName.TabIndex = 6;
            this.lblObjectFullName.Text = "订单名称 ObjectFullName:";
            this.lblObjectFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblObjectId
            // 
            this.lblObjectId.Location = new System.Drawing.Point(116, 103);
            this.lblObjectId.Name = "lblObjectId";
            this.lblObjectId.Size = new System.Drawing.Size(258, 12);
            this.lblObjectId.TabIndex = 4;
            this.lblObjectId.Text = "订单代码（Id）ObjectId:";
            this.lblObjectId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCategoryFullName
            // 
            this.lblCategoryFullName.Location = new System.Drawing.Point(116, 57);
            this.lblCategoryFullName.Name = "lblCategoryFullName";
            this.lblCategoryFullName.Size = new System.Drawing.Size(258, 12);
            this.lblCategoryFullName.TabIndex = 2;
            this.lblCategoryFullName.Text = "单据分类名称 CategoryFullName:";
            this.lblCategoryFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCategoryId
            // 
            this.lblCategoryId.Location = new System.Drawing.Point(116, 28);
            this.lblCategoryId.Name = "lblCategoryId";
            this.lblCategoryId.Size = new System.Drawing.Size(258, 12);
            this.lblCategoryId.TabIndex = 0;
            this.lblCategoryId.Text = "单据分类代码（表名） CategoryId:";
            this.lblCategoryId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtObjectId
            // 
            this.txtObjectId.Location = new System.Drawing.Point(380, 97);
            this.txtObjectId.Name = "txtObjectId";
            this.txtObjectId.Size = new System.Drawing.Size(155, 21);
            this.txtObjectId.TabIndex = 5;
            this.txtObjectId.Text = "JHD-0001";
            // 
            // txtCategoryFullName
            // 
            this.txtCategoryFullName.Location = new System.Drawing.Point(380, 51);
            this.txtCategoryFullName.Name = "txtCategoryFullName";
            this.txtCategoryFullName.Size = new System.Drawing.Size(155, 21);
            this.txtCategoryFullName.TabIndex = 3;
            this.txtCategoryFullName.Text = "进货单";
            // 
            // txtObjectFullName
            // 
            this.txtObjectFullName.Location = new System.Drawing.Point(380, 124);
            this.txtObjectFullName.Name = "txtObjectFullName";
            this.txtObjectFullName.Size = new System.Drawing.Size(155, 21);
            this.txtObjectFullName.TabIndex = 7;
            this.txtObjectFullName.Text = "进货单(JHD-0001)";
            // 
            // txtCategoryId
            // 
            this.txtCategoryId.Location = new System.Drawing.Point(380, 24);
            this.txtCategoryId.Name = "txtCategoryId";
            this.txtCategoryId.Size = new System.Drawing.Size(155, 21);
            this.txtCategoryId.TabIndex = 1;
            this.txtCategoryId.Text = "ERP_JHD";
            // 
            // FrmWorkFlowStatr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 567);
            this.Controls.Add(this.ucWorkFlowStatr1);
            this.Controls.Add(this.ucFreeStatr);
            this.Controls.Add(this.lblWorkFlowCode);
            this.Controls.Add(this.txtWorkFlowCode);
            this.Controls.Add(this.ucAutoStatr);
            this.Controls.Add(this.lblObjectFullName);
            this.Controls.Add(this.lblObjectId);
            this.Controls.Add(this.lblCategoryFullName);
            this.Controls.Add(this.lblCategoryId);
            this.Controls.Add(this.txtObjectId);
            this.Controls.Add(this.txtCategoryFullName);
            this.Controls.Add(this.txtObjectFullName);
            this.Controls.Add(this.txtCategoryId);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmWorkFlowStatr";
            this.Text = "启动审批流程";
            this.Load += new System.EventHandler(this.FormSubmitTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblObjectFullName;
        private System.Windows.Forms.Label lblObjectId;
        private System.Windows.Forms.Label lblCategoryFullName;
        private System.Windows.Forms.Label lblCategoryId;
        private System.Windows.Forms.TextBox txtObjectId;
        private System.Windows.Forms.TextBox txtCategoryFullName;
        private System.Windows.Forms.TextBox txtObjectFullName;
        private System.Windows.Forms.TextBox txtCategoryId;
        private UCAutoWorkFlowStatr ucAutoStatr;
        private System.Windows.Forms.Label lblWorkFlowCode;
        private System.Windows.Forms.TextBox txtWorkFlowCode;
        private UCFreeWorkFlowStatr ucFreeStatr;
        private UCWorkFlowStatr ucWorkFlowStatr1;
    }
}