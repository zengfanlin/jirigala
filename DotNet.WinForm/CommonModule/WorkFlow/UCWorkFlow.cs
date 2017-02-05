//--------------------------------------------------------------------
// All Rights Reserved ,Copyright (C) 2012 , Hairihan TECH, Ltd. .
//--------------------------------------------------------------------

using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace DotNet.WinForm
{
    // 系统生成类库
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// UCWorkFlow.cs 
    /// 工作流管理-审批组合控件  
    /// 
    /// 版本:1.0
    /// 
    /// 修改记录
    ///     2012.05.05 版本：1.0 LiangMingMing  实现控件功能。    
    /// 
    /// <author>   
    ///		<name>LiangMingMing</name>
    ///		<date>2012.05.05</date>		
    /// </author> 
    /// </summary> 
    public partial class UCWorkFlow : UserControl
    {
        // **********************************************************************************************
        // *                                                                                            * 
        // *                                       Property    属性                                     *
        // *                                                                                            * 
        // **********************************************************************************************           

        /// <summary>
        /// 当前工作流主键组
        /// </summary>
        public string[] WorkFlowIds = null;

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

        ///// <summary>
        ///// 单据分类代码
        ///// </summary>
        //public string CategoryId = null;

        ///// <summary>
        ///// 单据分类名称
        ///// </summary>
        //public string CategoryFullName = null;

        ///// <summary>
        ///// 单据代码
        ///// </summary>
        //public string[] ObjectIds = null;

        ///// <summary>
        ///// 单据名称
        ///// </summary>
        //public string[] ObjectFullNames = null;

        /// <summary>
        /// 工作流类型
        /// </summary
        private string workFlowType = null;
        /// <summary>
        /// 工作流类型(自由流[FreeFlow]或步骤流[StepFlow]）
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

        //##########################################################
        //#                        委托事件                        #
        //##########################################################

        ///// <summary>
        ///// 委托重新加载列表
        ///// </summary>
        ///// <returns></returns>
        //public delegate bool ReloadClickEventHandler();
        ///// <summary>
        ///// 重新加载列表
        ///// </summary>
        //public event ReloadClickEventHandler ReloadClick;

        /// <summary>
        /// 定义委托(审核通过时调用委托事件）
        /// </summary>
        /// <returns></returns>
        public delegate bool AuditPassClickEventHandler();
        /// <summary>
        /// 审批前调用获取值(审核通过时调用委托事件）
        /// </summary>
        public event AuditPassClickEventHandler BeforAuditPassClick;
        /// <summary>
        /// 审核通过后调用操作
        /// </summary>
        public event AuditPassClickEventHandler AfterAuditPassClick;

        /// <summary>
        /// 定义委托(审核退回时调用委托事件）
        /// </summary>
        /// <returns></returns>
        public delegate bool AuditRejectClickEventHandler();
        /// <summary>
        /// 退回前调用获取值(退回时调用委托事件）
        /// </summary>
        public event AuditRejectClickEventHandler BeforAuditRejectClick;
        /// <summary>
        /// 退回后调用操作
        /// </summary>
        public event AuditRejectClickEventHandler AfterAuditRejectClick;

        /// <summary>
        /// 定义委托(审核转发时调用委托事件）
        /// </summary>
        /// <returns></returns>
        public delegate bool TransmitClickEventHandler();
        /// <summary>
        /// 转发前调用获取值(转发时调用委托事件）
        /// </summary>
        public event TransmitClickEventHandler BeforTransmitClick;
        /// <summary>
        /// 转发后调用操作
        /// </summary>
        public event TransmitClickEventHandler AfterTransmitClick;

        /// <summary>
        /// 定义委托(审核撤销时调用委托事件）
        /// </summary>
        /// <returns></returns>
        public delegate bool AuditQuashClickEventHandler();
        /// <summary>
        /// 撤销前调用获取值(撤销时调用委托事件）
        /// </summary>
        public event AuditQuashClickEventHandler BeforAuditQuashClick;
        /// <summary>
        /// 撤销后调用操作
        /// </summary>
        public event AuditQuashClickEventHandler AfterAuditQuashClick;

        /// <summary>
        /// 定义委托(明细时调用委托事件）
        /// </summary>
        /// <returns></returns>
        public delegate bool AuditDetailClickEventHandler();
        /// <summary>
        /// 明细前调用获取值(撤销时调用委托事件）
        /// </summary>
        public event AuditDetailClickEventHandler BeforAuditDetailClick;
        /// <summary>
        /// 明细后调用操作
        /// </summary>
        public event AuditDetailClickEventHandler AfterAuditDetailClick;

        // **********************************************************************************************
        // *                                                                                            * 
        // *                             InitializeComponent  初始化                                    * 
        // *                                                                                            * 
        // **********************************************************************************************

        #region public UCWorkFlow() 重构函数
        /// <summary>
        /// 重构函数
        /// </summary>
        public UCWorkFlow()
        {
            InitializeComponent();
        }
        #endregion

        // **********************************************************************************************
        // *                                                                                            * 
        // *                                       Method   操作方法                                    * 
        // *                                                                                            * 
        // **********************************************************************************************

        #region public void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public void SetControlState()
        {
            // 检查一下是否按步骤流
            this.CheckIsByWorkFlowStep(false);
            // 判断单据主键是否为空
            if ((this.WorkFlowIds == null) || (this.WorkFlowIds.Length == 0) || (string.IsNullOrEmpty(this.WorkFlowType)))
            {
                // 如果单据主键为空所有控件屏蔽不能操作
                this.btnAuditDetail.Enabled = false;
                this.btnAuditPass.Enabled = false;
                this.btnAuditQuash.Enabled = false;
                this.btnAuditReject.Enabled = false;
                this.btnSelect.Enabled = false;
                this.btnTransmit.Enabled = false;
                this.txtAuditIdea.Enabled = false;
                this.lblSendTo.ForeColor = System.Drawing.Color.Gray;
                this.lblAuditIdea.ForeColor = System.Drawing.Color.Gray;
            }
            // 检查是否是自由流
            else if (this.WorkFlowType.Equals("FreeFlow"))
            {
                this.btnAuditDetail.Enabled = true;
                this.btnAuditPass.Enabled = true;
                this.btnAuditQuash.Enabled = true;
                this.btnAuditReject.Enabled = true;
                this.btnSelect.Enabled = true;
                this.btnTransmit.Enabled = true;
                this.txtAuditIdea.Enabled = true;
                this.lblSendTo.ForeColor = System.Drawing.Color.Black;
                this.lblAuditIdea.ForeColor = System.Drawing.Color.Black;
            }
            // 检查是否是步骤流
            else if (this.WorkFlowType.Equals("StepFlow"))
            {
                this.btnAuditDetail.Enabled = true;
                this.btnAuditPass.Enabled = true;
                this.btnAuditQuash.Enabled = true;
                this.btnAuditReject.Enabled = true;
                this.btnSelect.Enabled = false;
                this.btnTransmit.Enabled = false;
                this.txtAuditIdea.Enabled = true;
                this.lblSendTo.ForeColor = System.Drawing.Color.Gray;
                this.lblAuditIdea.ForeColor = System.Drawing.Color.Black;
            }
        }
        #endregion

        #region private bool CheckIsByWorkFlowStep(bool isShowMessage) 检查是否是步骤流
        /// <summary>
        /// 检查是否是步骤流
        /// </summary>
        /// <returns></returns>
        private bool CheckIsByWorkFlowStep(bool isShowMessage)
        {
            // 定义返回代码和返回信息
            string returnStatusCode = string.Empty, returnStatusMessage = string.Empty;
            // 判断单据主键是否为空
            if ((this.WorkFlowIds == null) || (this.WorkFlowIds.Length == 0))
            {
                if (isShowMessage)
                {
                    MessageBox.Show(AppMessage.MSG0265, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return false;
            }
            // 检查是否有自由流的存在，自由流不能批量审批，只能单个审批
            if (!DotNetService.Instance.WorkFlowCurrentService.CheckIsAutoWorkFlow(this.UserInfo, this.WorkFlowIds, out returnStatusCode, out returnStatusMessage))
            {
                // 有提示信息说明是批量审批当中含有自由流
                if (!string.IsNullOrEmpty(returnStatusMessage))
                {
                    if (isShowMessage)
                    {
                        MessageBox.Show(returnStatusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    // 设置为空，防止错误审批
                    this.WorkFlowType = null;
                }
                // 单条自由流
                else
                {
                    this.WorkFlowType = "FreeFlow";
                }
                return false;
            }
            // 步骤流
            this.WorkFlowType = "StepFlow";
            return true;
        }
        #endregion

        #region private bool CheckSelect() 检查选择记录的有效性
        /// <summary>
        /// 检查选择记录的有效性
        /// </summary>
        /// <returns></returns>
        private bool CheckSelect()
        {
            // 判断单据主键是否为空
            if ((this.WorkFlowIds == null) || (this.WorkFlowIds.Length == 0))
            {
                MessageBox.Show(AppMessage.MSG0265, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            // 查看明细不能多选
            if (this.WorkFlowIds.Length > 1)
            {
                MessageBox.Show(AppMessage.MSGC024, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        #endregion

        #region private bool AuditPass(bool isAutoFlow) 审核通过
        /// <summary>
        /// 审核通过
        /// <param name="isAutoFlow">是否是步骤流</param>
        /// </summary>
        private bool AuditPass(bool isAutoFlow)
        {
            bool returnValue = false;
            int result = 0;
            if (isAutoFlow)
            {
                // 步骤流审核
                result = DotNetService.Instance.WorkFlowCurrentService.AuditPass(this.UserInfo, this.WorkFlowIds, this.txtAuditIdea.Text);
            }
            else
            {
                //
                if ((this.SelectedIds == null)||(this.SelectedIds[0] == null))
                {
                    // 若没选人，就是直接结束了
                    result = DotNetService.Instance.WorkFlowCurrentService.AuditComplete(this.UserInfo, this.WorkFlowIds, this.txtAuditIdea.Text);
                }
                else
                {
                    // 若是选了人了，进入下一个审批流程了
                    result = DotNetService.Instance.WorkFlowCurrentService.AuditTransmit(this.UserInfo, this.WorkFlowIds[0], this.WorkFlowCategory, this.SelectedIds[0], this.txtAuditIdea.Text);
                }

            }

            if (result > 0)
            {
                // 是否显示信息
                if (BaseSystemInfo.ShowInformation)
                {
                    // 审核成功，进行提示
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0247, result.ToString()), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                returnValue = true;
            }
            else
            {
                // 是否显示信息
                if (BaseSystemInfo.ShowInformation)
                {
                    // 审核失败，进行提示
                    MessageBox.Show(AppMessage.MSG0248, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return returnValue;
        }
        #endregion

        #region private bool AuditReject() 退回
        /// <summary>
        /// 退回
        /// </summary>
        /// <returns></returns>
        private bool AuditReject()
        {
            // 返回值
            bool returnValue = false;
            // 定义返回结果
            int result = 0;
            // 获取退回结果
            result = DotNetService.Instance.WorkFlowCurrentService.AuditReject(this.UserInfo, this.WorkFlowIds, this.txtAuditIdea.Text);
            // 执行成功
            if (result > 0)
            {
                if (BaseSystemInfo.ShowInformation)
                {
                    // 审核成功，进行提示
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0292, result.ToString()), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                returnValue = true;
            }
            else
            {
                if (BaseSystemInfo.ShowInformation)
                {

                    // 审核失败，进行提示
                    MessageBox.Show(AppMessage.MSG0293, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return returnValue;
        }
        #endregion

        #region private bool Transmit() 转发
        /// <summary>
        /// 转发
        /// </summary>
        /// <returns></returns>
        private bool Transmit()
        {
            // 返回值
            bool returnValue = false;
            int result = 0;
            result = DotNetService.Instance.WorkFlowCurrentService.AuditTransmit(this.UserInfo, this.WorkFlowIds[0], this.WorkFlowCategory, this.SelectedIds[0], this.txtAuditIdea.Text);
            if (result > 0)
            {
                // 是否显示信息
                if (BaseSystemInfo.ShowInformation)
                {
                    // 转发成功，进行提示
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0295, result.ToString()), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                returnValue = true;
            }
            else
            {
                // 是否显示信息
                if (BaseSystemInfo.ShowInformation)
                {
                    // 审核失败，进行提示
                    MessageBox.Show(AppMessage.MSG0296, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            // 返回
            return returnValue;
        }
        #endregion

        #region private bool AuditQuash() 撤回
        /// <summary>
        /// 撤回
        /// </summary>
        /// <returns></returns>
        private bool AuditQuash()
        {
            // 返回值
            bool returnValue = false;
            int result = 0;
            result = DotNetService.Instance.WorkFlowCurrentService.AuditQuash(this.UserInfo, this.WorkFlowIds, this.txtAuditIdea.Text);
            if (result > 0)
            {
                // 是否显示信息
                if (BaseSystemInfo.ShowInformation)
                {
                    // 转发成功，进行提示
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0272, result.ToString()), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                returnValue = true;
            }
            else
            {
                // 是否显示信息
                if (BaseSystemInfo.ShowInformation)
                {
                    // 审核失败，进行提示
                    MessageBox.Show(AppMessage.MSG0273, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            // 返回
            return returnValue;
        }
        #endregion

        #region private bool AuditDetail() 审核明细
        /// <summary>
        /// 审核明细
        /// </summary>
        /// <returns></returns>
        private bool AuditDetail()
        {
            // 返回值
            bool returnValue = false;
            // 根据工作流id获取单据类型主键和单据主键
            BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.UserInfo);
            BaseWorkFlowCurrentEntity workFlowCurrentEntity = workFlowCurrentManager.GetEntity(this.WorkFlowIds[0]);
            // 查看历史信息
            FrmWorkFlowAuditDetail frmWorkFlowAuditDetail = new FrmWorkFlowAuditDetail(workFlowCurrentEntity.CategoryCode, workFlowCurrentEntity.ObjectId);
            frmWorkFlowAuditDetail.ShowDialog(this);
            returnValue = true;
            // 返回
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

        // **********************************************************************************************
        // *                                                                                            * 
        // *                                       EventArgs    事件方法                                * 
        // *                                                                                            * 
        // **********************************************************************************************

        /// <summary>
        /// 通过
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAuditPass_Click(object sender, EventArgs e)
        {
            bool returnValue = false;
            // 1、检查事件是否为空
            if (this.BeforAuditPassClick != null)
            {
                // 调用事件返回false则终止
                if (!this.BeforAuditPassClick())
                {
                    return;
                }
            }
            // 2、为了安全先得检查一下
            if (this.CheckIsByWorkFlowStep(true))
            {
                if (MessageBox.Show(AppMessage.MSG0250, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }
                // 步骤流审核
                returnValue = this.AuditPass(true);
            }
            else
            {
                // 自由流审核,得检查一下
                if (!string.IsNullOrEmpty(this.WorkFlowType))
                {
                    if (MessageBox.Show(AppMessage.MSG0250, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    {
                        return;
                    }
                    // 自由流审核
                    returnValue = this.AuditPass(false);
                }
            }
            // 3、执行是否成功
            if (returnValue)
            {
                // 判断事件是否为空
                if (this.AfterAuditPassClick != null)
                {
                    // 执行事件
                    this.AfterAuditPassClick();
                }
            }
        }

        /// <summary>
        /// 退回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAuditReject_Click(object sender, EventArgs e)
        {
            bool returnValue = false;
            // 1、检查事件是否为空
            if (this.BeforAuditRejectClick != null)
            {
                // 调用事件返回false则终止
                if (!this.BeforAuditRejectClick())
                {
                    return;
                }
            }
            // 2、为了安全先得检查一下, 判断单据主键是否为空
            if ((this.WorkFlowIds == null) || (this.WorkFlowIds.Length == 0))
            {
                MessageBox.Show(AppMessage.MSG0265, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show(AppMessage.MSG0255, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return;
            }
            // 不需要检查是是步骤流还是自由流， 退回是同一个操作
            returnValue = this.AuditReject();
            // 3、执行是否成功
            if (returnValue)
            {
                // 判断事件是否为空
                if (this.AfterAuditRejectClick != null)
                {
                    // 执行事件
                    this.AfterAuditRejectClick();
                }
            }
        }

        /// <summary>
        /// 转发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransmit_Click(object sender, EventArgs e)
        {
            bool returnValue = false;
            // 1、检查事件是否为空
            if (this.BeforTransmitClick != null)
            {
                // 调用事件返回false则终止
                if (!this.BeforTransmitClick())
                {
                    return;
                }
            }
            // 2、为了安全先得检查一下, 判断单据主键是否为空
            if ((this.WorkFlowIds == null) || (this.WorkFlowIds.Length == 0))
            {
                MessageBox.Show(AppMessage.MSG0265, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((this.SelectedIds == null) || (this.SelectedIds[0] == null))
            {
                MessageBox.Show(AppMessage.MSG0291, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show(string.Format(AppMessage.MSG0294, this.txtFullName.Text), AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return;
            }
            // 不需要检查是是步骤流还是自由流， 转发的是自由流
            returnValue = this.Transmit();
            // 3、执行是否成功
            if (returnValue)
            {
                // 判断事件是否为空
                if (this.AfterTransmitClick != null)
                {
                    // 执行事件
                    this.AfterTransmitClick();
                }
            }
        }

        /// <summary>
        /// 撤回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAuditQuash_Click(object sender, EventArgs e)
        {
            bool returnValue = false;
            // 1、检查事件是否为空
            if (this.BeforAuditQuashClick != null)
            {
                // 调用事件返回false则终止
                if (!this.BeforAuditQuashClick())
                {
                    return;
                }
            }
            // 2、为了安全先得检查一下, 判断单据主键是否为空
            if ((this.WorkFlowIds == null) || (this.WorkFlowIds.Length == 0))
            {
                MessageBox.Show(AppMessage.MSG0265, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show(AppMessage.MSG0276, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return;
            }
            // 不需要检查是是步骤流还是自由流， 撤回的是自由流
            returnValue = this.AuditQuash();
            // 3、执行是否成功
            if (returnValue)
            {
                // 判断事件是否为空
                if (this.AfterAuditQuashClick != null)
                {
                    // 执行事件
                    this.AfterAuditQuashClick();
                }
            }
        }

        /// <summary>
        /// 审批明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAuditDetail_Click(object sender, EventArgs e)
        {
            bool returnValue = false;
            // 提交前的检查工作
            if (this.BeforAuditDetailClick != null)
            {
                if (!this.BeforAuditDetailClick())
                {
                    return;
                }
            }
            // 检查选择记录的条数
            if (this.CheckSelect())
            {
                // 查看明细数据
                returnValue = this.AuditDetail();
            }
            if (returnValue)
            {
                if (this.AfterAuditDetailClick != null)
                {
                    this.AfterAuditDetailClick();
                }
            }
        }

        /// <summary>
        /// 选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            // 选择
            this.SelectSendTo();
        }

    }
}
