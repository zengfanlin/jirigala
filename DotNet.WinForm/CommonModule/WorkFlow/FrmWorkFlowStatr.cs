//--------------------------------------------------------------------
// All Rights Reserved ,Copyright (C) 2012 , Hairihan TECH, Ltd. .
//--------------------------------------------------------------------

using System;

namespace DotNet.WinForm
{
    /// <summary>
    /// FormSubmitTest.cs
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
    public partial class FrmWorkFlowStatr : BaseForm
    {
        public FrmWorkFlowStatr()
        {
            InitializeComponent();
        }

        private void FormSubmitTest_Load(object sender, EventArgs e)
        {
            this.ucFreeStatr.CategoryId = this.txtCategoryId.Text;
            this.ucFreeStatr.CategoryFullName = this.txtCategoryFullName.Text;
            this.ucFreeStatr.ObjectId = this.txtObjectId.Text;
            this.ucFreeStatr.ObjectFullName = this.txtObjectFullName.Text;
            // this.ucFreeStatr.DefaultUser = "10000000";
            this.ucFreeStatr.Init(); 

            // 初始化控件 
            this.ucWorkFlowStatr1.WorkFlowCode =  this.txtWorkFlowCode.Text;
            this.ucWorkFlowStatr1.Init();
        }

        private bool ucAutoStatr_BeforBtnSendToClick(string categoryId, string[] objectIds)
        {
            this.ucAutoStatr.WorkFlowCode = this.txtWorkFlowCode.Text;
            this.ucAutoStatr.CategoryId = this.txtCategoryId.Text;
            this.ucAutoStatr.CategoryFullName = this.txtCategoryFullName.Text;
            this.ucAutoStatr.ObjectIds = new string[]{ this.txtObjectId.Text};
            this.ucAutoStatr.ObjectFullNames = new string[]{this.txtObjectFullName.Text};
            return true;
        }

        private bool ucUserStatr_BeforBtnSendToClick(string categoryId, string objectId, string sendToUserId)
        {
            this.ucFreeStatr.CategoryId = this.txtCategoryId.Text;
            this.ucFreeStatr.CategoryFullName = this.txtCategoryFullName.Text;
            this.ucFreeStatr.ObjectId = this.txtObjectId.Text;
            this.ucFreeStatr.ObjectFullName = this.txtObjectFullName.Text;
            return true;
        }

        private bool ucWorkFlowStatr1_BeforBtnSendToClick(string categoryId, string[] objectId)
        {
            //this.ucWorkFlowStatr1.WorkFlowCode = this.txtWorkFlowCode.Text;
            this.ucWorkFlowStatr1.CategoryId = this.txtCategoryId.Text;
            this.ucWorkFlowStatr1.CategoryFullName = this.txtCategoryFullName.Text;
            this.ucWorkFlowStatr1.ObjectIds = new string[] { this.txtObjectId.Text };
            this.ucWorkFlowStatr1.ObjectFullNames = new string[] { this.txtObjectFullName.Text };
            return true;
        }      
    }
}