//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2010 , DotNet , Ltd .
//--------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// UCFreeWorkFlowStatr.cs
    /// 自由工作流提交控件
    ///		
    /// 修改记录
    ///
    ///     2012.04.25 版本: 1.4 LiangMingMing 整合控件并新添加人员、部门、角色选择 。
    ///     2010.08.03 版本：1.3 JiRiGaLa 重新整理程序。
    ///     2007.08.10 版本：1.2 chenning 添加委托 完善提交逻辑。
    ///     2007.08.10 版本：1.0 JiRiGaLa 实现控件提交功能。
    ///		
    /// 版本：1.2
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.08.03</date>
    /// </author> 
    /// </summary> 
    public partial class UCFreeWorkFlowStatr : UserControl
    {
        /// <summary>
        /// 审核流类别(ByUser按用户审核、ByRole按角色审核、ByOrganize按部门审核)
        /// </summary>
        private string workFlowCategory = "ByRole";
        /// <summary>
        /// 审核流类别
        /// </summary>
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
        /// 被选中的主键
        /// </summary>
        private string selectedId = string.Empty;
        /// <summary>
        /// 被选中的主键
        /// </summary>
        public string SelectedId
        {
            get
            {
                return this.selectedId;
            }
            set
            {
                if (!this.DesignMode)
                {
                    this.SelectedFullName = string.Empty;
                    this.selectedId = value;
                    if (!string.IsNullOrEmpty(this.selectedId))
                    {
                        if (this.WorkFlowCategory.Equals("ByUser"))
                        {
                            // 用户审核模式
                            BaseUserEntity userEntity = DotNetService.Instance.UserService.GetEntity(UserInfo, this.selectedId);
                            if (userEntity != null)
                            {
                                this.SelectedFullName = userEntity.RealName;
                                this.txtFullName.Text = userEntity.RealName;
                            }
                        }
                        else
                        {
                            // 角色审核模式
                            BaseRoleEntity roleEntity = DotNetService.Instance.RoleService.GetEntity(UserInfo, this.selectedId);
                            if (roleEntity != null)
                            {
                                this.SelectedFullName = roleEntity.RealName;
                                this.txtFullName.Text = roleEntity.RealName;
                            }
                        }
                    }
                    this.SetControlState();
                }
            }
        }

        /// <summary>
        /// 被选中的主键集
        /// </summary>
        private string[] selectedIds = null;
        /// <summary>
        /// 被选中的主键集
        /// </summary>
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
        /// 选择后的名称（人员或部门或角色）
        /// </summary>
        private string selectedFullName = string.Empty;
        /// <summary>
        /// 选择后的名称（人员或部门或角色）
        /// </summary>
        public string SelectedFullName
        {
            get
            {
                return this.selectedFullName;
            }
            set
            {
                this.selectedFullName = value;
                this.txtFullName.Text = value;
                this.SetControlState();
            }
        }

        /// <summary>
        /// 打开节点 
        /// </summary>
        private string openId = string.Empty;
        /// <summary>
        /// 打开节点
        /// </summary>
        public string OpenId
        {
            get
            {
                return this.openId;
            }
            set
            {
                this.openId = value;
            }
        }

        /// <summary>
        /// 是否允许多个选择(可以选择多条记录)
        /// </summary>
        private bool multiSelect = false;
        /// <summary>
        /// 是否允许多个选择(可以选择多条记录)
        /// </summary>
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
        public bool AllowNull
        {
            get
            {
                return this.allowNull;
            }
            set
            {
                this.allowNull = value;
                this.SetControlState();
            }
        }

        /// <summary>
        /// 是否允许同时选择部门、角色、人员
        /// </summary>
        private bool selectMulti = false;
        /// <summary>
        /// 是否允许同时选择部门、角色、人员
        /// </summary>
        public bool SelectMulti
        {
            get
            {
                return this.selectMulti;
            }
            set
            {
                this.selectMulti = value;
            }
        }

        /// <summary>
        /// 是否允许选择
        /// </summary>
        private bool allowSelect = false;
        /// <summary>
        /// 是否允许选择
        /// </summary>
        public bool AllowSelect
        {
            get
            {
                return this.allowSelect;
            }
            set
            {
                this.allowSelect = value;
                this.SetControlState();
            }
        }

        /// <summary>
        /// 按什么权限域列表
        /// </summary>
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
        /// 移出的主键数组
        /// </summary>
        private string[] removeIds = null;
        /// <summary>
        /// 移出的主键数组
        /// </summary>
        public string[] RemoveIds
        {
            get
            {
                return this.removeIds;
            }
            set
            {
                this.removeIds = value;
            }
        }

        /// <summary>
        /// 是否开启用户选择
        /// </summary>
        private bool userSelect = true;
        /// <summary>
        /// 是否开启用户选择
        /// </summary>
        public bool UserSelect
        {
            get { return userSelect; }
            set { this.userSelect = value; this.SetControlState(); }
        }

        /// <summary>
        /// 是否开启角色选择
        /// </summary>
        private bool roleSelect = true;
        /// <summary>
        /// 是否开启角色选择
        /// </summary>
        public bool RoleSelect
        {
            get { return roleSelect; }
            set { this.roleSelect = value; this.SetControlState(); }
        }

        /// <summary>
        /// 是否开启部门选择
        /// </summary>
        private bool organizeSelect = true;
        /// <summary>
        /// 是否开启部门选择
        /// </summary>
        public bool OrganizeSelect
        {
            get { return organizeSelect; }
            set { this.organizeSelect = value; this.SetControlState(); }
        }

        /// <summary>
        /// 确认发送信息
        /// </summary>
        private string sendMessage = string.Empty;
        /// <summary>
        /// 确认发送信息
        /// </summary>
        public string SendMessage
        {
            get { return sendMessage; }
            set { this.sendMessage = value; }
        }

        /// <summary>
        /// 审批流程时，需要判断的操作权限
        /// </summary>
        public string CheckPermissionItemCode = String.Empty;

        /// <summary>
        /// 单据分类代码
        /// </summary>
        public string CategoryId = String.Empty;

        /// <summary>
        /// 单据分类名称
        /// </summary>
        public string CategoryFullName = String.Empty;

        /// <summary>
        /// 单据代码
        /// </summary>
        public string ObjectId = String.Empty;

        /// <summary>
        /// 单据名称
        /// </summary>
        public string ObjectFullName = String.Empty;

        /// <summary>
        /// 委托事件（转发给其他人 "提交" 按钮事件中挂接事件 并指定是否允许进行次操作）
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="objectId"></param>
        /// <param name="sendToUserId"></param>
        /// <returns></returns>
        public delegate bool ButtonSendToClickEventHandler(String categoryId, string objectId, string sendToUserId);

        /// <summary>
        /// 发生后
        /// </summary>
        public event ButtonSendToClickEventHandler BeforBtnSendToClick;

        /// <summary>
        /// 发生前
        /// </summary>
        public event ButtonSendToClickEventHandler AfterBtnSendToClick;

        /// <summary>
        /// 输入有效性事件中挂接事件 并指定是否允许进行次操作
        /// </summary>
        /// <returns></returns> 
        public delegate bool OnCheckInputClickEventHandler();
        /// <summary>
        /// 
        /// </summary>
        public event OnCheckInputClickEventHandler BeforCheckInputClick;

        /// <summary>
        /// 默认用户
        /// </summary>
        public string DefaultUser = string.Empty;

        /// <summary>
        /// 只显示角色
        /// </summary>
        public bool ShowRoleOnly = true;

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

        #region public UCFreeWorkFlowStatr() 重构函数
        /// <summary>
        /// 重构函数
        /// </summary>
        public UCFreeWorkFlowStatr()
        {
            InitializeComponent();
        }
        #endregion

        //-------------------------------------
        //             组织机构
        //-------------------------------------

        /// <summary>
        /// 选中的主键数组
        /// </summary>
        private string[] setSelectIds = null;
        /// <summary>
        /// 选中的主键数组
        /// </summary>
        public string[] SetSelectIds
        {
            get
            {
                return this.setSelectIds;
            }
            set
            {
                this.setSelectIds = value;
            }
        }

        /// <summary>
        /// 被选中组织机构的主键
        /// </summary>
        private string selectedOrganizeId = string.Empty;
        /// <summary>
        /// 被选中组织机构的主键
        /// </summary>
        public string SelectedOrganizeId
        {
            get
            {
                return this.selectedOrganizeId;
            }
            set
            {
                this.selectedOrganizeId = value;
                this.SetControlState();
            }
        }

        /// <summary>
        /// 被选中组织机构的主键集
        /// </summary>
        private string[] selectedOrganizeIds = null;
        /// <summary>
        /// 被选中组织机构的主键集
        /// </summary>
        public string[] SelectedOrganizeIds
        {
            get
            {
                return this.selectedOrganizeIds;
            }
            set
            {
                this.selectedOrganizeIds = value;
                this.SetControlState();
            }
        }

        /// <summary>
        /// 选择后的组织机构名称
        /// </summary>
        private string selectedOrganizeFullName = string.Empty;
        /// <summary>
        /// 选择后的组织机构名称
        /// </summary>
        public string SelectedOrganizeFullName
        {
            get
            {
                return this.selectedOrganizeFullName;
            }
            set
            {
                this.selectedOrganizeFullName = value;
                //this.txtFullName.Text = value;
                this.SetControlState();
            }
        }

        //-------------------------------------
        //             角色
        //-------------------------------------

        /// <summary>
        /// 被选中角色的主键
        /// </summary>
        private string selectedRoleId = string.Empty;
        /// <summary>
        /// 被选中角色的主键
        /// </summary>
        public string SelectedRoleId
        {
            get
            {
                return this.selectedRoleId;
            }
            set
            {
                this.selectedRoleId = value;
                this.SetControlState();
            }
        }

        /// <summary>
        /// 被选中角色的主键集
        /// </summary>
        private string[] selectedRoleIds = null;
        /// <summary>
        /// 被选中角色的主键集
        /// </summary>
        public string[] SelectedRoleIds
        {
            get
            {
                return this.selectedRoleIds;
            }
            set
            {
                this.selectedRoleIds = value;
                this.SetControlState();
            }
        }

        /// <summary>
        /// 选择后的角色名称
        /// </summary>
        private string selectedRoleFullName = string.Empty;
        /// <summary>
        /// 选择后的角色名称
        /// </summary>
        public string SelectedRoleFullName
        {
            get
            {
                return this.selectedRoleFullName;
            }
            set
            {
                this.selectedRoleFullName = value;
                //this.txtFullName.Text = value;
                this.SetControlState();
            }
        }

        //-------------------------------------
        //             用户
        //-------------------------------------

        /// <summary>
        /// 被选中用户的主键
        /// </summary>
        private string selectedUserId = string.Empty;
        /// <summary>
        /// 被选中用户的主键
        /// </summary>
        public string SelectedUserId
        {
            get
            {
                return this.selectedUserId;
            }
            set
            {
                this.selectedUserId = value;
                this.SetControlState();
            }
        }

        /// <summary>
        /// 被选中用户的主键集
        /// </summary>
        private string[] selectedUserIds = null;
        /// <summary>
        /// 被选中用户的主键集
        /// </summary>
        public string[] SelectedUserIds
        {
            get
            {
                return this.selectedUserIds;
            }
            set
            {
                this.selectedUserIds = value;
                this.SetControlState();
            }
        }

        /// <summary>
        /// 选择后的用户名称
        /// </summary>
        private string selectedUserFullName = string.Empty;
        /// <summary>
        /// 选择后的用户名称
        /// </summary>
        public string SelectedUserFullName
        {
            get
            {
                return this.selectedUserFullName;
            }
            set
            {
                this.selectedUserFullName = value;
                //this.txtFullName.Text = value;
                this.SetControlState();
            }
        }

        // 当选择的用户发生变化时
        public event BaseBusinessLogic.SelectedIndexChangedEventHandler SelectedIndexChanged;

        #region private void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        private void SetControlState()
        {
            // 全部都关闭了的话，提交按钮也将自动关闭
            if ((!this.UserSelect) && (!this.RoleSelect) && (!this.OrganizeSelect))
            {
                this.btnSendTo.Enabled = false;
                this.btnSendToBy.Enabled = false;
                this.btnUserSelect.Enabled = false;
            }
        }
        #endregion

        #region public void Init() 初始化工作流控件
        /// <summary>
        /// 初始化工作流控件
        /// </summary>
        /// <returns>单据当前工作流识别代码</returns>
        public void Init()
        {
            // 清除挂接的事件
            // this.BeforCheckInputClick = null;
            // this.BeforBtnSendToClick = null;
            // this.AfterBtnSendToClick = null;
            if (!string.IsNullOrEmpty(this.DefaultUser))
            {
                this.SelectedId = this.DefaultUser;
            }
        }
        #endregion

        #region private void SelectBy() 选择
        /// <summary>
        /// 选择
        /// </summary>
        private void SelectBy()
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
            ((FrmUserRoleOrganizeSelect)frmSelect).AllowRoleSelect = this.RoleSelect;
            ((FrmUserRoleOrganizeSelect)frmSelect).AllowUserSelect = this.UserSelect;
            ((FrmUserRoleOrganizeSelect)frmSelect).AllowOrganizeSelect = this.OrganizeSelect;
            ((FrmUserRoleOrganizeSelect)frmSelect).AllowMultiSelect = this.SelectMulti;
            ((FrmUserRoleOrganizeSelect)frmSelect).MultiUserSelect = this.MultiSelect;
            ((FrmUserRoleOrganizeSelect)frmSelect).MultiOrganizeSelect = this.MultiSelect;
            ((FrmUserRoleOrganizeSelect)frmSelect).MultiRoleSelect = this.MultiSelect;

            if (frmSelect.ShowDialog() == DialogResult.OK)
            {
                this.txtFullName.Text = string.Empty;
                this.WorkFlowCategory = ((FrmUserRoleOrganizeSelect)frmSelect).CurrentSelect;
                // 可以同时选择组织机构、角色、用户
                if (this.SelectMulti)
                {
                    // 组织机构
                    this.SelectedOrganizeIds = ((FrmUserRoleOrganizeSelect)frmSelect).SelectedOrganizeIds;
                    this.SelectedOrganizeId = ((FrmUserRoleOrganizeSelect)frmSelect).SelectedOrganizeId;
                    this.SelectedOrganizeFullName = ((FrmUserRoleOrganizeSelect)frmSelect).SelectedOrganizeFullName;
                    this.txtFullName.Text += ((FrmUserRoleOrganizeSelect)frmSelect).SelectedOrganizeFullName;
                    // 角色
                    this.SelectedRoleIds = ((FrmUserRoleOrganizeSelect)frmSelect).SelectedRoleIds;
                    this.SelectedRoleId = ((FrmUserRoleOrganizeSelect)frmSelect).SelectedRoleId;
                    this.SelectedRoleFullName = ((FrmUserRoleOrganizeSelect)frmSelect).SelectedRoleFullName;
                    this.txtFullName.Text += ((FrmUserRoleOrganizeSelect)frmSelect).SelectedRoleFullName;
                    // 用户
                    this.SelectedUserIds = ((FrmUserRoleOrganizeSelect)frmSelect).SelectedUserIds;
                    this.SelectedUserId = ((FrmUserRoleOrganizeSelect)frmSelect).SelectedUserId;
                    this.SelectedUserFullName = ((FrmUserRoleOrganizeSelect)frmSelect).SelectedUserFullName;
                    this.txtFullName.Text += ((FrmUserRoleOrganizeSelect)frmSelect).SelectedUserFullName;
                }
                // 只能选择一个类型
                else
                {
                    // 组织机构
                    if (WorkFlowCategory.Equals("ByOrganize"))
                    {
                        this.SelectedIds = ((FrmUserRoleOrganizeSelect)frmSelect).SelectedOrganizeIds;
                        this.SelectedId = ((FrmUserRoleOrganizeSelect)frmSelect).SelectedOrganizeId;
                        this.SelectedFullName = ((FrmUserRoleOrganizeSelect)frmSelect).SelectedOrganizeFullName;
                        this.txtFullName.Text = ((FrmUserRoleOrganizeSelect)frmSelect).SelectedOrganizeFullName;
                    }
                    // 角色
                    else if (WorkFlowCategory.Equals("ByRole"))
                    {
                        this.SelectedIds = ((FrmUserRoleOrganizeSelect)frmSelect).SelectedRoleIds;
                        this.SelectedId = ((FrmUserRoleOrganizeSelect)frmSelect).SelectedRoleId;
                        this.SelectedFullName = ((FrmUserRoleOrganizeSelect)frmSelect).SelectedRoleFullName;
                        this.txtFullName.Text = ((FrmUserRoleOrganizeSelect)frmSelect).SelectedRoleFullName;
                    }
                    // 用户
                    else if (WorkFlowCategory.Equals("ByUser"))
                    {
                        this.SelectedIds = ((FrmUserRoleOrganizeSelect)frmSelect).SelectedUserIds;
                        this.SelectedId = ((FrmUserRoleOrganizeSelect)frmSelect).SelectedUserId;
                        this.SelectedFullName = ((FrmUserRoleOrganizeSelect)frmSelect).SelectedUserFullName;
                        this.txtFullName.Text = ((FrmUserRoleOrganizeSelect)frmSelect).SelectedUserFullName;
                    }
                    if (this.SelectedIndexChanged != null)
                    {
                        this.SelectedIndexChanged(this.SelectedId);
                    }
                }
                this.SetControlState();
            }
        }
        #endregion

        #region private void btnSelect_Click(object sender, EventArgs e) 选择
        /// <summary>
        /// 选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.SelectBy();
        }
        #endregion

        /// <summary>
        /// 获取发送信息
        /// </summary>
        private void GetSendMessage()
        {
            // 组织机构
            if (WorkFlowCategory.Equals("ByOrganize"))
            {
                this.SendMessage = AppMessage.MSG0288;
            }
            // 角色
            else if (WorkFlowCategory.Equals("ByRole"))
            {
                this.SendMessage = AppMessage.MSG0290;
            }
            // 用户
            else if (WorkFlowCategory.Equals("ByUser"))
            {
                this.SendMessage = AppMessage.MSG0278;
            }
        }

        #region private bool CheckInput() 是否选择了角色
        /// <summary>
        /// 是否选择了角色
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            bool returnValue = true;
            if (this.BeforCheckInputClick != null)
            {
                returnValue = this.BeforCheckInputClick();
            }
            if (!returnValue)
            {
                return returnValue;
            }
            if (string.IsNullOrEmpty(this.SelectedId))
            {
                MessageBox.Show(AppMessage.MSG0291, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtFullName.Focus();
                return false;
            }
            if (MessageBox.Show(AppMessage.Format(this.SendMessage, this.txtFullName.Text), AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return false;
            }
            return returnValue;
        }
        #endregion

        #region private bool SendTo() 提交单据、进入审批流程
        /// <summary>
        /// 提交单据、进入审批流程
        /// </summary>
        /// <returns>成功</returns>
        private bool SendTo()
        {
            bool returnValue = false;
            if (!string.IsNullOrEmpty(this.ObjectId) && !string.IsNullOrEmpty(this.CategoryId) && !string.IsNullOrEmpty(this.SelectedId))
            {
                string returnStatusCode = string.Empty;

                if (this.WorkFlowCategory.Equals("ByUser"))
                {
                    //DotNetService.Instance.WorkFlowCurrentService.AutoStart(this.UserInfo, this.CategoryId, this.CategoryFullName, this.ObjectId.Split(','), new string[]{ this.ObjectFullName }, this.SelectedId, this.txtAuditIdea.Text, out returnStatusCode);
                }
                if (this.WorkFlowCategory.Equals("ByRole"))
                {
                    // DotNetService.Instance.WorkFlowCurrentService.AuditStatr(this.UserInfo, this.CategoryId, this.CategoryFullName, this.ObjectId, this.ObjectFullName, this.SelectedId, this.txtAuditIdea.Text, out returnStatusCode);
                }
                if (this.WorkFlowCategory.Equals("ByOrganize"))
                {
                    // DotNetService.Instance.WorkFlowCurrentService.AuditStatr(this.UserInfo, this.CategoryId, this.CategoryFullName, this.ObjectId, this.ObjectFullName, this.SelectedId, this.txtAuditIdea.Text, out returnStatusCode);
                }
                if (returnStatusCode == StatusCode.OK.ToString())
                {
                    if (BaseSystemInfo.ShowInformation)
                    {
                        MessageBox.Show(AppMessage.MSG0279, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    returnValue = true;
                }
                else
                {
                    if (BaseSystemInfo.ShowInformation)
                    {
                        MessageBox.Show(AppMessage.MSG0280, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    returnValue = false;
                }
            }
            return returnValue;
        }
        #endregion

        private void btnSendTo_Click(object sender, EventArgs e)
        {
            // 提交前的检查工作
            if (this.BeforBtnSendToClick != null)
            {
                if (!this.BeforBtnSendToClick(this.CategoryId, this.ObjectId, this.SelectedId))
                {
                    return;
                }
            }
            if (this.CheckInput())
            {
                // 提交单据、进入审批流程
                if (this.SendTo())
                {
                    if (this.AfterBtnSendToClick != null)
                    {
                        this.AfterBtnSendToClick(this.CategoryId, this.ObjectId, this.SelectedId);
                    }
                }
            }
        }

        private void btnSendToBy_Click(object sender, EventArgs e)
        {
            // 提交前的检查工作
            if (this.BeforBtnSendToClick != null)
            {
                if (!this.BeforBtnSendToClick(this.CategoryId, this.ObjectId, this.SelectedId))
                {
                    return;
                }
            }
            if (this.CheckInput())
            {
                // 提交单据、进入审批流程
                if (this.SendTo())
                {
                    if (this.AfterBtnSendToClick != null)
                    {
                        this.AfterBtnSendToClick(this.CategoryId, this.ObjectId, this.SelectedId);
                    }
                }
            }
        }
    }
}