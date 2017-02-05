//--------------------------------------------------------------------
// All Rights Reserved ,Copyright (C) 2012 , Hairihan TECH, Ltd. .
//--------------------------------------------------------------------

using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// UCWorkFlowStatr.cs 
    /// 工作流管理-提交审批组合控件  
    /// 
    /// 版本:1.0
    /// 
    /// 修改记录
    ///     2012.05.04 版本：1.0 LiangMingMing  实现控件功能。    
    /// 
    /// <author>   
    ///		<name>LiangMingMing</name>
    ///		<date>2012.05.04</date>		
    /// </author> 
    /// </summary> 
    public partial class UCWorkFlowStatr : UserControl
    {
        // **********************************************************************************************
        // *                                                                                            * 
        // *                                       Property    属性                                     *
        // *                                                                                            * 
        // ********************************************************************************************** 

        /// <summary>
        /// 当前工作流主键
        /// </summary>
        private string WorkFlowId = string.Empty;

        /// <summary>
        /// 审核流类别(ByUser按用户审核、ByRole按角色审核、ByOrganize按部门审核)
        /// </summary>
        private string workFlowCategory = "ByUser";
        /// <summary>
        /// 审核流类别
        /// </summary>
        [Description("审核流类别(ByUser按用户审核、ByRole按角色审核、ByOrganize按部门审核)")]
        public string WorkFlowCategory
        {
            get
            {
                return workFlowCategory;
            }
            set
            {
                workFlowCategory = value;
            }
        }

        /// <summary>
        /// 审批流编号
        /// </summary>
        private string workFlowCode = string.Empty;
        /// <summary>
        /// 审批流编号
        /// </summary>
        [Description("审批流编号")]
        public string WorkFlowCode
        {
            get
            {
                return this.workFlowCode;
            }
            set
            {
                this.workFlowCode = value;
            }
        }

        /// <summary>
        /// 审批流程时，需要判断的操作权限
        /// </summary>
        public string CheckPermissionItemCode = string.Empty;

        /// <summary>
        /// 按什么权限域列表
        /// </summary>
        [Description("按什么权限域列表")]
        private string byPermissionCode = string.Empty;
        /// <summary>
        /// 按什么权限域列表
        /// </summary>
        public string PermissionItemScopeCode
        {
            get
            {
                return this.byPermissionCode;
            }
            set
            {
                this.byPermissionCode = value;
            }
        }

        /// <summary>
        /// 单据分类代码
        /// </summary>
        public string CategoryId = null;

        /// <summary>
        /// 单据分类名称
        /// </summary>
        public string CategoryFullName = null;

        /// <summary>
        /// 单据代码
        /// </summary>
        public string[] ObjectIds = null;

        /// <summary>
        /// 单据名称
        /// </summary>
        public string[] ObjectFullNames = null;

        /// <summary>
        /// 工作流类型
        /// </summary
        private string workFlowType = "FreeFlow";
        /// <summary>
        /// 工作流类型(自由流[FreeFlow]或步骤流[StepFlow]）,默认为自由流
        /// </summary>
        [Description("工作流类型(自由流[FreeFlow]或步骤流[StepFlow]）,默认为自由流")]
        public string WorkFlowType
        {
            get
            {
                return this.workFlowType;
            }
            set
            {
                this.workFlowType = value;
            }
        }

        /// <summary>
        /// 选中的主键组
        /// </summary
        private string[] selectedIds = null;
        /// <summary>
        /// 选中的主键组
        /// </summary>
        [Description("选中的主键组")]
        public string[] SelectedIds
        {
            get
            {
                return this.selectedIds;
            }
            set
            {
                this.selectedIds = value;
            }
        }

        /// <summary>
        /// 选中的名称
        /// </summary>
        private string selectedFullName = string.Empty;
        /// <summary>
        /// 选中的名称
        /// </summary>
        [Description("选中的名称")]
        public string SelectedFullName
        {
            get
            {
                return this.selectedFullName;
            }
            set
            {
                this.selectedFullName = value;
                //this.txtFullName.Text = value;
                //this.SetControlState();
            }
        }

        /// <summary>
        /// 是否允许多个选择(可以选择多条记录)
        /// </summary>
        private bool multiSelect = false;
        /// <summary>
        /// 是否允许多个选择(可以选择多条记录)
        /// </summary>
        [Description("是否允许多个选择(可以选择多条记录)")]
        public bool MultiSelect
        {
            get
            {
                return this.multiSelect;
            }
            set
            {
                this.multiSelect = value;
            }
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        private bool allowNull = false;
        /// <summary>
        /// 是否为空
        /// </summary>
        [Description("是否为空")]
        public bool AllowNull
        {
            get
            {
                return this.allowNull;
            }
            set
            {
                this.allowNull = value;
                //this.SetControlState();
            }
        }

        /// <summary>
        /// 是否允许选择
        /// </summary>
        private bool allowSelect = false;
        /// <summary>
        /// 是否允许选择
        /// </summary>
        [Description("是否允许选择")]
        public bool AllowSelect
        {
            get
            {
                return this.allowSelect;
            }
            set
            {
                this.allowSelect = value;
                //this.SetControlState();
            }
        }

        /// <summary>
        /// 当前用户信息
        /// </summary>
        public BaseUserInfo UserInfo
        {
            get
            {
                return BaseSystemInfo.UserInfo;
            }
        }

        //#################################委托事件#######################################      
        //################################################################################
       
        /// <summary>
        /// 委托事件（转发给其他人 "提交" 按钮事件中挂接事件 并指定是否允许进行次操作）
        /// </summary>
        /// <param name="categoryId">单据类型主键</param>
        /// <param name="objectId">单据主键</param>
        /// <param name="sendToUserId">发给谁</param>
        /// <returns></returns>
        public delegate bool ButtonSendToClickEventHandler(String categoryId, string[] objectId);
        /// <summary>
        /// 发生前
        /// </summary>
        public event ButtonSendToClickEventHandler AfterBtnSendToClick;
        /// <summary>
        /// 发生后
        /// </summary>
        public event ButtonSendToClickEventHandler BeforBtnSendToClick;

        // **********************************************************************************************
        // *                                                                                            * 
        // *                             InitializeComponent  初始化                                    * 
        // *                                                                                            * 
        // **********************************************************************************************

        #region public UCWorkFlowStatr() 重构函数
        /// <summary>
        /// 重构函数
        /// </summary>
        public UCWorkFlowStatr()
        {
            InitializeComponent();
        }
        #endregion

        #region public void Init() 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            // 检查判断是步骤流还是自由流
            this.CheckIsByWorkFlowStep();
            // 设置控件状态
            this.SetControlState();
        }
        #endregion

        // **********************************************************************************************
        // *                                                                                            * 
        // *                                       Method   操作方法                                    * 
        // *                                                                                            * 
        // **********************************************************************************************

        #region private void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        private void SetControlState()
        {
            // 按流程
            if (this.WorkFlowType.Equals("StepFlow"))
            {
                this.lblSendTo.ForeColor = System.Drawing.Color.Gray;
                this.btnSelect.Enabled = false;
            }
            // 按自由流
            else
            {
                this.lblSendTo.ForeColor = System.Drawing.Color.Black;
                this.btnSelect.Enabled = true;
            }
        }
        #endregion

        #region private bool CheckIsByWorkFlowStep() 检查是步骤流还是自由流
        /// <summary>
        /// 检查是步骤流还是自由流
        /// </summary>
        /// <returns></returns>
        private bool CheckIsByWorkFlowStep()
        {            
            // 默认为自由流
            this.WorkFlowType = "FreeFlow";
            // 返回值
            bool returnValue = false;
            // 获取工作流程主键
            this.WorkFlowId = DotNetService.Instance.WorkFlowProcessAdminService.GetProcessId(this.UserInfo, this.WorkFlowCode);
            // 判断是否为空
            if (!string.IsNullOrEmpty(this.WorkFlowId))
            {
                // 步骤流
                this.WorkFlowType = "StepFlow";
                returnValue = true;
            }
            return returnValue;
        }
        #endregion

        #region private void SelectSendTo() 选择发送给
        /// <summary>
        /// 选择发送给
        /// </summary>
        private void SelectSendTo()
        {
            // 用反射获得窗体
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmUserRoleOrganizeSelect";
            Form frmSelect = CacheManager.Instance.GetForm(assemblyName, formName);
            ((FrmUserRoleOrganizeSelect)frmSelect).AllowOrganizeNull = this.AllowNull;
            ((FrmUserRoleOrganizeSelect)frmSelect).AllowRoleNull = this.AllowNull;
            ((FrmUserRoleOrganizeSelect)frmSelect).AllowUserNull = this.AllowNull;
            ((FrmUserRoleOrganizeSelect)frmSelect).OrganizePermissionItemScopeCode = this.PermissionItemScopeCode;
            ((FrmUserRoleOrganizeSelect)frmSelect).RolePermissionItemScopeCode = this.PermissionItemScopeCode;
            ((FrmUserRoleOrganizeSelect)frmSelect).UserPermissionItemScopeCode = this.PermissionItemScopeCode;
            ((FrmUserRoleOrganizeSelect)frmSelect).AllowRoleSelect = this.AllowSelect;
            ((FrmUserRoleOrganizeSelect)frmSelect).AllowUserSelect = this.AllowSelect;
            ((FrmUserRoleOrganizeSelect)frmSelect).AllowOrganizeSelect = this.AllowSelect;
            // 目前先屏蔽多选
            ((FrmUserRoleOrganizeSelect)frmSelect).AllowMultiSelect = false;
            // 选择多条记录
            ((FrmUserRoleOrganizeSelect)frmSelect).MultiUserSelect = this.MultiSelect;
            ((FrmUserRoleOrganizeSelect)frmSelect).MultiOrganizeSelect = this.MultiSelect;
            ((FrmUserRoleOrganizeSelect)frmSelect).MultiRoleSelect = this.MultiSelect;

            if (frmSelect.ShowDialog() == DialogResult.OK)
            {
                this.txtFullName.Text = string.Empty;
                this.WorkFlowCategory = ((FrmUserRoleOrganizeSelect)frmSelect).CurrentSelect;

                // 组织机构
                if (WorkFlowCategory.Equals("ByOrganize"))
                {
                    this.SelectedIds = new string[] { ((FrmUserRoleOrganizeSelect)frmSelect).SelectedOrganizeId };
                    this.SelectedFullName = ((FrmUserRoleOrganizeSelect)frmSelect).SelectedOrganizeFullName;
                    this.txtFullName.Text = ((FrmUserRoleOrganizeSelect)frmSelect).SelectedOrganizeFullName;
                }
                // 角色
                else if (WorkFlowCategory.Equals("ByRole"))
                {
                    this.SelectedIds = new string[] { ((FrmUserRoleOrganizeSelect)frmSelect).SelectedRoleId };
                    this.SelectedFullName = ((FrmUserRoleOrganizeSelect)frmSelect).SelectedRoleFullName;
                    this.txtFullName.Text = ((FrmUserRoleOrganizeSelect)frmSelect).SelectedRoleFullName;
                }
                // 用户
                else if (WorkFlowCategory.Equals("ByUser"))
                {
                    this.SelectedIds = new string[] { ((FrmUserRoleOrganizeSelect)frmSelect).SelectedUserId };
                    this.SelectedFullName = ((FrmUserRoleOrganizeSelect)frmSelect).SelectedUserFullName;
                    this.txtFullName.Text = ((FrmUserRoleOrganizeSelect)frmSelect).SelectedUserFullName;
                }
            }
        }
        #endregion

        #region  private bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            // 返回值
            bool returnValue = true;
            // 判断选择的主键是否为空
            if ((this.SelectedIds == null) || (this.SelectedIds.Length == 0))
            {
                if (BaseSystemInfo.ShowInformation)
                {
                    MessageBox.Show(AppMessage.MSG0291, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                returnValue = false;
            }
            return returnValue;
        }
        #endregion

        #region private void SendToBy() 提交审核
        /// <summary>
        /// 提交审核
        /// </summary>
        private void SendToBy()
        {
            // 返回值
            string returnValue = string.Empty;
            // 返回状态
            string returnStatusCode = string.Empty;
            // 执行步骤流
            if (this.WorkFlowType.Equals("StepFlow"))
            {
                // 没有值的话重新获取一下
                if (string.IsNullOrEmpty(this.WorkFlowId))
                { 
                    // 重新获取工作流主键
                    this.WorkFlowId = DotNetService.Instance.WorkFlowProcessAdminService.GetProcessId(this.UserInfo, this.WorkFlowCode);
                }
                // 获取步骤列表
                DataTable dataTable = DotNetService.Instance.WorkFlowActivityAdminService.GetDataTable(this.UserInfo, this.WorkFlowId);
                // 返回值
                returnValue = DotNetService.Instance.WorkFlowCurrentService.AuditStatr(this.UserInfo, this.CategoryId, this.CategoryFullName, this.ObjectIds, StringUtil.ArrayToList(this.ObjectFullNames), this.WorkFlowCode, this.txtAuditIdea.Text, out returnStatusCode, dataTable); 
            }
            // 执行自由流
            else if (this.WorkFlowType.Equals("FreeFlow"))
            {
                // 检查选择的有效性
                if (this.CheckInput())
                {
                    // 提交自由流程
                    // returnValue = DotNetService.Instance.WorkFlowCurrentService.AuditFreeStart(this.UserInfo, this.CategoryId, this.CategoryFullName, this.ObjectIds, StringUtil.ArrayToList(this.ObjectFullNames), this.WorkFlowCode, this.txtAuditIdea.Text, this.WorkFlowCategory, this.SelectedIds[0], this.SelectedFullName, string.Empty, out returnStatusCode);
                }
                else
                {
                    return;
                }
            }
            // 提交成功
            if (returnStatusCode == StatusCode.OK.ToString())
            {
                // 是否显示信息
                if (BaseSystemInfo.ShowInformation)
                {
                    MessageBox.Show(AppMessage.MSG0256, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            // 提交失败
            else
            {
                // 是否显示信息
                if (BaseSystemInfo.ShowInformation)
                {
                    MessageBox.Show(AppMessage.MSG0257, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        // **********************************************************************************************
        // *                                                                                            * 
        // *                                       EventArgs    事件方法                                * 
        // *                                                                                            * 
        // **********************************************************************************************

        #region private void btnSelect_Click(object sender, EventArgs e) 选择发送给
        /// <summary>
        /// 选择发送给
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            // 选择发送给
            this.SelectSendTo();
        }
        #endregion

        #region private void btnSendToBy_Click(object sender, EventArgs e) 提交审核
        /// <summary>
        /// 提交审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendToBy_Click(object sender, EventArgs e)
        {
             // 判断事件是否存在
            if (this.BeforBtnSendToClick != null)
            {
                // 委托调用事件返回是否为true
                if (!this.BeforBtnSendToClick(this.CategoryId, this.ObjectIds))
                {
                    // 返回
                    return;
                }
            }
            // 执行提交
            this.SendToBy();
        }
        #endregion

    }
}
