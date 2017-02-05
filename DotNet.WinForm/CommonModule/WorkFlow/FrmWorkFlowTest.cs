//--------------------------------------------------------------------
// All Rights Reserved ,Copyright (C) 2012 , Hairihan TECH, Ltd. .
//--------------------------------------------------------------------

using System;

namespace DotNet.WinForm
{
    /// <summary>
    /// FormWorkFlowTest.cs
    /// 工作流测试-测试窗体
    ///		
    /// 修改记录
    ///
    ///     2007.07.25 版本：1.0 JiRiGaLa  页面编写。
    ///		
    /// 版本：1.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.07.25</date>
    /// </author> 
    /// </summary> 
    public partial class FrmWorkFlowTest : BaseForm
    {
        public FrmWorkFlowTest()
        {
            InitializeComponent();
        }

        private void FrmWorkFlowTest_Load(object sender, EventArgs e)
        {
        }

        // 自定义的方法，返回值为 bool，表示是否允许 审核通过
        private bool AuditPass(String categoryId, string objectId)
        {
            // 通过这个函数，可以修改自己的 单据表的状态。
            this.Text = categoryId + objectId;
            return true;
        }

        // 自定义的方法
        private bool AfterAuditPass(String categoryId, string objectId)
        {
            this.Close();
            return true;
        }

        private void GetWorkFlowId()
        {
            // 这些值是赋值进去的
            this.ucWorkFlowUser.CategoryId = this.txtCategoryId.Text;
            this.ucWorkFlowUser.CategoryFullName = this.txtCategoryFullName.Text;
            this.ucWorkFlowUser.ObjectId = this.txtObjectId.Text;
            this.ucWorkFlowUser.ObjectFullName = this.txtObjectFullName.Text;
            this.ucWorkFlowUser.PermissionAuditing = this.chkPermissionAuditing.Checked;
            this.ucWorkFlowUser.ShowAuditQuash = true;
            // 初始化工作流控件
            this.ucWorkFlowUser.Init();

            // 这里是挂自定义事件的方法
            this.ucWorkFlowUser.BeforBtnAuditCompleteClick += new UCFreeWorkFlow.ButtonAuditCompleteClickEventHandler(AuditPass);
            this.ucWorkFlowUser.AfterBtnAuditCompleteClick += new UCFreeWorkFlow.ButtonAuditCompleteClickEventHandler(AfterAuditPass);

            // 这个值是要获得出来的，然后工作流就开始正常流转了
            this.txtWorkFlowId.Text = this.ucWorkFlowUser.CurrentWorkFlowId;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            FrmWorkFlowStatr frmWorkFlowStatr = new FrmWorkFlowStatr();
            frmWorkFlowStatr.Show();
        }

        private void btnInitWorkFlow_Click(object sender, EventArgs e)
        {
            // 获取Id
            this.GetWorkFlowId();
        }

        private void btnWorkFlowMonitor_Click(object sender, EventArgs e)
        {
            FrmWorkFlowMonitor frmWorkFlowMonitor = new FrmWorkFlowMonitor();
            frmWorkFlowMonitor.Show();
        }

        private void btnMyWorkFlow_Click(object sender, EventArgs e)
        {
            FrmWorkFlowWaitForAudit frmMyWorkFlow = new FrmWorkFlowWaitForAudit();
            frmMyWorkFlow.Show();            
        }
    }
}