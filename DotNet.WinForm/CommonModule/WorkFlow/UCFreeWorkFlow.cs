//--------------------------------------------------------------------
// All Rights Reserved ,Copyright (C) 2012 , Hairihan TECH, Ltd. .
//--------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// UserControlUserWorkFlow.cs
    /// 工作流管理-步骤编辑窗体
    ///		
    /// 修改记录
    ///
    ///     2007.07.26 版本：1.0 JiRiGaLa  实现控件审批功能。
    ///		
    /// 版本：1.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.07.26</date>
    /// </author> 
    /// </summary> 
    public partial class UCFreeWorkFlow : UserControl
    {
        // ByUser按用户审核、ByRole按角色审核
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

        public string CategoryId        = String.Empty; // 单据分类代码
        public string CategoryFullName  = String.Empty; // 单据分类名称
        public string ObjectId          = String.Empty; // 单据代码
        public string ObjectFullName    = String.Empty; // 单据名称
        
        public int WorkFlowId           = 0; // 单据走哪个已定义的工作流代码

        // 单据当前工作流识别代码 （BaseWorkFlowCurrent里指定的表）
        public string CurrentWorkFlowId = String.Empty; 
        // 多个单据当前工作流识别代码 （BaseWorkFlowCurrent里指定的表）
        public String[] CurrentWorkFlowIds = null; 

        public bool AutomaticFollow     = false;        // 自动流转

        private bool permissionAuditing  = false;
        /// <summary>
        /// 是否有最终审批权限
        /// </summary>
        public bool PermissionAuditing
        {
            get
            {
                return permissionAuditing;
            }
            set
            {
                this.permissionAuditing = value;
                if (this.permissionAuditing)
                {
                    this.btnAuditPass.Visible = false;
                }
                else
                {
                    this.btnAuditPass.Visible = true;
                }
            }
        }

        public string DefaultRole = string.Empty;

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

        private string selectedId = string.Empty;

        /// <summary>
        /// 发送给谁审核
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
                    this.selectedId = value;
                    if (!string.IsNullOrEmpty(this.selectedId))
                    {
                        BaseRoleEntity roleEntity = DotNetService.Instance.RoleService.GetEntity(UserInfo, this.selectedId);
                        if (roleEntity != null)
                        {
                            this.SelectedFullName = roleEntity.RealName;
                            this.txtFullName.Text = roleEntity.RealName;
                        }
                        else
                        {
                            this.SelectedFullName = string.Empty;
                        }
                    }
                    else
                    {
                        this.SelectedFullName = string.Empty;
                    }
                    this.SetControlState();
                }
            }
        }

        private string[] selectedIds = null;    // 被选中的主键集
        /// <summary>
        /// 被选中的员工主键
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

        private string selectedFullName = string.Empty;
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

        private bool multiSelect = false;
        /// <summary>
        /// 是否允许多个选择
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

        private bool allowNull = false;
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

        // 当选择的用户发生变化时
        public event BaseBusinessLogic.SelectedIndexChangedEventHandler SelectedIndexChanged;


        public string AuditIdea
        {
            get
            {
                return this.txtAuditIdea.Text;
            }
        }

        private bool showAuditIdea = true;
        /// <summary>
        /// 显示批示审批意见输入框
        /// </summary>
        public bool ShowAuditIdea
        {
            set
            {
                this.lblAuditIdea.Visible = value;
                this.txtAuditIdea.Visible = value;
                this.showAuditIdea = value;
            }
            get
            {
                return this.showAuditIdea;
            }
        }
        
        private bool showAuditReject = true;
        /// <summary>
        /// 显示退回按钮
        /// </summary>
        public bool ShowAuditReject
        {
            set
            {
                this.btnAuditReject.Visible = value;
                this.showAuditReject = value;
            }
            get
            {
                return this.showAuditReject;
            }
        }
        
        private bool showAuditQuash = false;
        /// <summary>
        /// 显示撤销按钮
        /// </summary>
        public bool ShowAuditQuash
        {
            set
            {
                this.btnAuditQuash.Visible = value;
                this.showAuditQuash = value;
            }
            get
            {
                return this.showAuditQuash;
            }
        }

        private bool showAuditDetail = true;
        /// <summary>
        /// 显示记录按钮
        /// </summary>
        public bool ShowAuditDetail
        {
            set
            {
                this.btnAuditDetail.Visible = value;
                this.showAuditDetail = value;
            }
            get
            {
                return this.showAuditDetail;
            }
        }

        private bool showSendTo = true;
        /// <summary>
        /// 显示发送给谁区域
        /// </summary>
        public bool ShowSendTo
        {
            set
            {
                this.splitContainerMain.Panel2.Visible = value;
                this.showSendTo = value;
            }
            get
            {
                return this.showSendTo;
            }
        }

        // 审批通过单据 "通过" 按钮事件中挂接事件 并指定是否允许进行次操作
        public delegate bool ButtonAuditPassClickEventHandler(String categoryId, string objectId, string sendToUserId);
        public event ButtonAuditPassClickEventHandler BeforBtnAuditPassClick;
        public event ButtonAuditPassClickEventHandler AfterBtnAuditPassClick;

        // 退回单据 "退回" 按钮事件中挂接事件 并指定是否允许进行次操作
        public delegate bool ButtonAuditRejectClickEventHandler(String categoryId, string objectId);
        public event ButtonAuditRejectClickEventHandler BeforBtnAuditRejectClick;
        public event ButtonAuditRejectClickEventHandler AfterBtnAuditRejectClick;

        // 转发给其他人 "提交" 按钮事件中挂接事件 并指定是否允许进行次操作
        public delegate bool ButtonTransmitClickEventHandler(String categoryId, string objectId, string sendToUserId);
        public event ButtonTransmitClickEventHandler BeforBtnTransmitClick;
        public event ButtonTransmitClickEventHandler AfterBtnTransmitClick;

        // 最终审批通过 "审批" 按钮事件中挂接事件 并指定是否允许进行次操作
        public delegate bool ButtonAuditCompleteClickEventHandler(String categoryId, string objectId);
        public event ButtonAuditCompleteClickEventHandler BeforBtnAuditCompleteClick;
        public event ButtonAuditCompleteClickEventHandler AfterBtnAuditCompleteClick;
        
        // 最终审批通过 "撤消" 按钮事件中挂接事件 并指定是否允许进行次操作
        public delegate bool ButtonAuditQuashClickEventHandler(String categoryId, string objectId);
        public event ButtonAuditQuashClickEventHandler BeforBtnAuditQuashClick;
        public event ButtonAuditQuashClickEventHandler AfterBtnAuditQuashClick;

        // 查看审批记录 "记录" 按钮事件中挂接事件 并指定是否允许进行次操作
        public delegate bool ButtonAuditDetailClickEventHandler(String categoryId, string objectId);
        public event ButtonAuditDetailClickEventHandler BeforBtnAuditDetailClick;
        public event ButtonAuditDetailClickEventHandler AfterBtnAuditDetailClick;

        public UCFreeWorkFlow()
        {
            InitializeComponent();
        }

        private void UCFreeWorkFlow_Load(object sender, EventArgs e)
        {
            // 设置工作流组建的可用性
            // this.SetControlState(false);
        }

        #region private void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        private void SetControlState()
        {
            this.lblAuditIdea.Visible = this.ShowAuditIdea;
            this.txtAuditIdea.Visible = this.ShowAuditIdea;
            this.btnAuditQuash.Visible = this.ShowAuditQuash;
            this.btnAuditDetail.Visible = this.ShowAuditDetail;
            this.btnAuditReject.Visible = this.ShowAuditReject;
            if (!this.ShowSendTo)
            {
                this.txtFullName.Visible = false;
                this.lblSendTo.Visible = false;
                this.btnSelect.Visible = false;
                this.btnTransmit.Visible = false;
            }
            // 若是自动工作流，这些发送给谁的部分就不用显示了。
            if (this.AutomaticFollow)
            {
                this.lblSendTo.Visible = false;
                this.txtFullName.Visible = false;
                this.btnTransmit.Visible = false;
            }
        }
        #endregion

        #region public void SetControlState(bool enabled) 设置工作流组建的可用性
        /// <summary>
        /// 设置工作流组建的可用性
        /// </summary>
        /// <param name="enabled">是否有效</param>
        public void SetControlState(bool enabled)
        {
            this.txtAuditIdea.Enabled = enabled;
            this.btnAuditPass.Enabled = enabled;
            this.btnAuditReject.Enabled = enabled;
            this.btnAuditDetail.Enabled = enabled;
            this.txtFullName.Enabled = enabled;
        }
        #endregion
  
        #region public string Init() 初始化工作流控件
        /// <summary>
        /// 初始化工作流控件
        /// </summary>
        /// <returns>单据当前工作流识别代码</returns>
        public string Init()
        {
            // 清除挂接的事件
            // this.BeforBtnAuditPassClick = null;
            // this.BeforBtnAuditRejectClick = null;
            // this.BeforBtnTransmitClick = null;
            // this.BeforBtnAuditCompleteClick = null;

            // this.AfterBtnAuditPassClick = null;
            // this.AfterBtnAuditRejectClick = null;
            // this.AfterBtnTransmitClick = null;
            // this.AfterBtnAuditCompleteClick = null;

            // 设置按钮状态
            this.SetControlState();
            // 判断单据当前工作流识别代码的有效性
            // 这里最后一个参数不需要了 audiStaffId。
            // this.CurrentWorkFlowId = DotNetService.Instance.WorkFlowCurrentService.AuditStatr(this.UserInfo, this.WorkFlowId, this.CategoryId, this.CategoryFullName, this.ObjectId, this.ObjectFullName); 
            if (this.CurrentWorkFlowId.Length > 0)
            {
                // 设置工作流组建的可用性
                this.SetControlState(true);
            }
            return this.CurrentWorkFlowId;
        }
        #endregion

        #region private bool AuditPass() 审批通过
        /// <summary>
        /// 审批通过
        /// </summary>
        /// <returns>审批成功</returns>
        private bool AuditPass()
        {
            int returnValue = 0;
            // 是否单个发送？
            if (!string.IsNullOrEmpty(this.CurrentWorkFlowId))
            {
                this.CurrentWorkFlowIds = new string[] { this.CurrentWorkFlowId };
            }
            // 按多个发送来处理
            for (int i = 0; i < this.CurrentWorkFlowIds.Length; i++)
            {
                if (this.WorkFlowCategory.Equals("ByUser"))
                {
                  //  returnValue += DotNetService.Instance.WorkFlowCurrentService.AuditPass(this.UserInfo, this.CurrentWorkFlowIds[i], this.txtAuditIdea.Text);
                }
            }
            if (returnValue > 0)
            {
                if (BaseSystemInfo.ShowInformation)
                {
                    // 更新成功，进行提示
                    MessageBox.Show(AppMessage.MSG0258, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return returnValue > 0;
        }
        #endregion

        private bool CheckAuditPass()
        {
            bool returnValue = true;
            if (string.IsNullOrEmpty(this.CurrentWorkFlowId) && this.CurrentWorkFlowIds == null)
            {
                MessageBox.Show(AppMessage.MSG0259, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrEmpty(this.SelectedId))
            {
                MessageBox.Show(AppMessage.MSG0260, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnSelect.Focus();
                return false;
            }
            return returnValue;
        }

        private void btnAuditPassClick()
        {
            if (this.BeforBtnAuditPassClick != null)
            {
                if (!this.BeforBtnAuditPassClick(this.CategoryId, this.ObjectId, this.SelectedId))
                {
                    return;
                }
            }
            if (this.CheckAuditPass())
            {
                // 审批通过单据
                if (this.AuditPass())
                {
                    if (this.AfterBtnAuditPassClick != null)
                    {
                        this.AfterBtnAuditPassClick(this.CategoryId, this.ObjectId, this.SelectedId);
                    }
                }
            }
        }

        #region private bool AuditComplete() 最终审批通过
        /// <summary>
        /// 最终审批通过
        /// </summary>
        /// <returns></returns>
        private bool AuditComplete()
        {
            int returnValue = 0;
            // 是否单个发送？
            if (!string.IsNullOrEmpty(this.CurrentWorkFlowId))
            {
                this.CurrentWorkFlowIds = new string[] { this.CurrentWorkFlowId };
            }
            // 按多个发送来处理
            for (int i = 0; i < this.CurrentWorkFlowIds.Length; i++)
            {
                //returnValue += DotNetService.Instance.WorkFlowCurrentService.AuditComplete(this.UserInfo, this.CurrentWorkFlowIds[i], this.txtAuditIdea.Text);
            }

            if (returnValue > 0)
            {
                if (BaseSystemInfo.ShowInformation)
                {
                    // 更新成功，进行提示
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0261, returnValue.ToString()), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (BaseSystemInfo.ShowInformation)
                {
                    // 更新成功，进行提示
                    MessageBox.Show(AppMessage.MSG0262, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            // 控件状态
            // this.txtAuditIdea.Enabled = false;
            // this.btnAuditReject.Enabled = false;
            // this.txtFullName.Enabled = false;
            
            return returnValue > 0;
        }
        #endregion

        private bool CheckAuditComplete()
        {
            bool returnValue = true;
            if (string.IsNullOrEmpty(this.CurrentWorkFlowId) && this.CurrentWorkFlowIds == null)
            {
                MessageBox.Show(AppMessage.MSG0263, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (MessageBox.Show(AppMessage.MSG0264, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return false;
            }
            return returnValue;
        }

        private void btnAuditCompleteClick()
        {
            if (this.BeforBtnAuditCompleteClick != null)
            {
                if (!this.BeforBtnAuditCompleteClick(this.CategoryId, this.ObjectId))
                {
                    return;
                }
            }
            if (this.CheckAuditComplete())
            {
                // 最终审批通过
                if (this.AuditComplete())
                {
                    if (this.AfterBtnAuditCompleteClick != null)
                    {
                        this.AfterBtnAuditCompleteClick(this.CategoryId, this.ObjectId);
                    }
                }
            }
        }

        private void btnAuditPass_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.SelectedId))
            {
                // 若没选人，就是直接结束了
                this.btnAuditCompleteClick();
            }
            else
            {
                // 若是选了人了，进入下一个审批流程了
                this.btnAuditPassClick();            
            }
        }

        #region private bool AuditReject() 退回单据
        /// <summary>
        /// 退回单据
        /// </summary>
        /// <returns></returns>
        private bool AuditReject()
        {
            int returnValue = 0;
            // 是否单个发送？
            if (!string.IsNullOrEmpty(this.CurrentWorkFlowId))
            {
                this.CurrentWorkFlowIds = new string[] { this.CurrentWorkFlowId };
            }
            // 按多个发送来处理
            for (int i = 0; i < this.CurrentWorkFlowIds.Length; i++)
            {
               // returnValue += DotNetService.Instance.WorkFlowCurrentService.AuditReject(this.UserInfo, this.CurrentWorkFlowIds[i], this.txtAuditIdea.Text);
            }
            if (BaseSystemInfo.ShowInformation)
            {
                // 更新成功，进行提示
                MessageBox.Show(AppMessage.MSG0264, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // 控件状态
            // this.txtAuditIdea.Enabled = false;
            // this.btnAuditReject.Enabled = false;
            // this.btnAuditPass.Enabled = false;
            // this.btnAuditComplete.Enabled = false;
            // this.txtFullName.Enabled = false;

            return returnValue > 0;
        }
        #endregion

        private bool CheckInputAuditReject()
        {
            bool returnValue = true;
            if (string.IsNullOrEmpty(this.CurrentWorkFlowId) && this.CurrentWorkFlowIds == null)
            {
                MessageBox.Show(AppMessage.MSG0265, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (this.txtAuditIdea.Text.Length == 0)
            {
                if (MessageBox.Show(AppMessage.MSG0266, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    this.txtAuditIdea.Focus();
                    return false;
                }
            }
            if (MessageBox.Show(AppMessage.MSG0267, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                return false;
            }
            return returnValue;
        }

        private void btnAuditReject_Click(object sender, EventArgs e)
        {
            if (this.BeforBtnAuditRejectClick != null)
            {
                if (!this.BeforBtnAuditRejectClick(this.CategoryId, this.ObjectId))
                {
                    return;
                }
            }
            if (this.CheckInputAuditReject())
            {
                // 退回单据
                if (this.AuditReject())
                {
                    if (this.AfterBtnAuditRejectClick != null)
                    {
                        this.AfterBtnAuditRejectClick(this.CategoryId, this.ObjectId);
                    }
                }
            }
        }

        private void SelectByUser()
        {
            // 用反射获得窗体
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmUserSelect";
            Form frmSelect = CacheManager.Instance.GetForm(assemblyName, formName);
            ((FrmUserSelect)frmSelect).AllowNull = this.AllowNull;
            ((FrmUserSelect)frmSelect).PermissionItemScopeCode = this.PermissionItemScopeCode;

            if (frmSelect.ShowDialog() == DialogResult.OK)
            {
                this.SelectedId = ((FrmUserSelect)frmSelect).SelectedId;
                this.SelectedFullName = ((FrmUserSelect)frmSelect).SelectedFullName;
                this.txtFullName.Text = ((FrmUserSelect)frmSelect).SelectedFullName;
                if (this.SelectedIndexChanged != null)
                {
                    this.SelectedIndexChanged(this.SelectedId);
                }
                this.SetControlState();
            }
        }

        private void SelectByRole()
        {
            // 用反射获得窗体
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmRoleSelect";
            Form frmSelect = CacheManager.Instance.GetForm(assemblyName, formName);
            ((FrmRoleSelect)frmSelect).AllowNull = this.AllowNull;
            ((FrmRoleSelect)frmSelect).PermissionItemScopeCode = this.PermissionItemScopeCode;

            if (frmSelect.ShowDialog() == DialogResult.OK)
            {
                this.SelectedId = ((FrmRoleSelect)frmSelect).SelectedId;
                this.SelectedFullName = ((FrmRoleSelect)frmSelect).SelectedFullName;
                this.txtFullName.Text = ((FrmRoleSelect)frmSelect).SelectedFullName;
                if (this.SelectedIndexChanged != null)
                {
                    this.SelectedIndexChanged(this.SelectedId);
                }
                this.SetControlState();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (this.WorkFlowCategory.Equals("ByUser"))
            {
                this.SelectByUser();
            }
            else
            {
                this.SelectByRole();
            }
        }

        #region private bool AuditTransmit() 流程发送给谁
        /// <summary>
        /// 流程发送给谁
        /// </summary>
        /// <returns></returns>
        private bool AuditTransmit()
        {
            int returnValue = 0;
            // 是否单个发送？
            if (!string.IsNullOrEmpty(this.CurrentWorkFlowId))
            {
                this.CurrentWorkFlowIds = new string[] { this.CurrentWorkFlowId };
            }
            // 按多个发送来处理
            for (int i = 0; i < this.CurrentWorkFlowIds.Length; i++)
            {
                if (this.WorkFlowCategory.Equals("ByUser"))
                {
                    //returnValue += DotNetService.Instance.WorkFlowCurrentService.AuditTransmit(this.UserInfo, this.CurrentWorkFlowIds[i], this.SelectedId, this.txtAuditIdea.Text);
                }
            }
            if (BaseSystemInfo.ShowInformation)
            {
                // 更新成功，进行提示
                MessageBox.Show(AppMessage.MSG0268, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // 控件状态
            // this.txtAuditIdea.Enabled = false;
            // this.btnAuditReject.Enabled = false;
            // this.btnAuditPass.Enabled = false;
            // this.btnAuditComplete.Enabled = false;
            // this.txtFullName.Enabled = false;

            return returnValue > 0;
        }
        #endregion

        private bool CheckInputTransmit()
        {
            bool returnValue = true;
            if (string.IsNullOrEmpty(this.CurrentWorkFlowId) && this.CurrentWorkFlowIds == null)
            {
                MessageBox.Show(AppMessage.MSG0269, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrEmpty(this.SelectedId))
            {
                MessageBox.Show(AppMessage.MSG0270, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnSelect.Focus();
                return false;
            }
            if (MessageBox.Show(AppMessage.Format(AppMessage.MSG0271, this.txtFullName.Text), AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return false;
            }
            return returnValue;
        }

        private void btnTransmit_Click(object sender, EventArgs e)
        {
            // 提交前的检查工作
            if (this.BeforBtnTransmitClick != null)
            {
                if (!this.BeforBtnTransmitClick(this.CategoryId, this.ObjectId, this.SelectedId))
                {
                    return;
                }
            }
            if (this.CheckInputTransmit())
            {
                // 转发单据
                if (this.AuditTransmit())
                {
                    if (this.AfterBtnTransmitClick != null)
                    {
                        this.AfterBtnTransmitClick(this.CategoryId, this.ObjectId, this.SelectedId);
                    }
                }
            }
        }

        private bool AuditDetail()
        {
            // 查看历史信息
            FrmWorkFlowAuditDetail frmWorkFlowAuditDetail = new FrmWorkFlowAuditDetail(this.CategoryId, this.ObjectId);
            frmWorkFlowAuditDetail.ShowDialog(this);
            return true;
        }

        public virtual void btnAuditDetail_Click(object sender, EventArgs e)
        {
            // 提交前的检查工作
            if (this.BeforBtnAuditDetailClick != null)
            {
                if (!this.BeforBtnAuditDetailClick(this.CategoryId, this.ObjectId))
                {
                    return;
                }
            }
            if (this.CheckInputTransmit())
            {
                // 转发单据
                if (this.AuditDetail())
                {
                    if (this.AfterBtnAuditDetailClick != null)
                    {
                        this.AfterBtnAuditDetailClick(this.CategoryId, this.ObjectId);
                    }
                }
            }
        }

        #region private bool AuditQuash() 撤消审批流程中的单据
        /// <summary>
        /// 撤消审批流程中的单据
        /// </summary>
        /// <returns></returns>
        private bool AuditQuash()
        {
            int returnValue = 0;

            // 是否单个发送？
            if (!string.IsNullOrEmpty(this.CurrentWorkFlowId))
            {
                this.CurrentWorkFlowIds = new string[] { this.CurrentWorkFlowId };
            }
            // 按多个发送来处理
            for (int i = 0; i < this.CurrentWorkFlowIds.Length; i++)
            {
                returnValue += DotNetService.Instance.WorkFlowCurrentService.AuditQuash(this.UserInfo, this.CurrentWorkFlowIds, this.txtAuditIdea.Text);
            }
            if (returnValue > 0)
            {
                if (BaseSystemInfo.ShowInformation)
                {
                    // 更新成功，进行提示
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0272, returnValue.ToString()), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (BaseSystemInfo.ShowInformation)
                {
                    // 更新成功，进行提示
                    MessageBox.Show(AppMessage.MSG0273, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return returnValue > 0;
        }
        #endregion

        private bool CheckInputAuditQuash()
        {
            bool returnValue = true;
            if (string.IsNullOrEmpty(this.CurrentWorkFlowId) && this.CurrentWorkFlowIds == null)
            {
                MessageBox.Show(AppMessage.MSG0274, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (this.txtAuditIdea.Text.Length == 0)
            {
                if (MessageBox.Show(AppMessage.MSG0275, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    this.txtAuditIdea.Focus();
                    return false;
                }
            }
            if (MessageBox.Show(AppMessage.MSG0276, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                return false;
            }
            return returnValue;
        }

        private void btnAuditQuash_Click(object sender, EventArgs e)
        {
            if (this.BeforBtnAuditQuashClick != null)
            {
                if (!this.BeforBtnAuditQuashClick(this.CategoryId, this.ObjectId))
                {
                    return;
                }
            }
            if (this.CheckInputAuditQuash())
            {
                // 撤消审批流程中的单据
                if (this.AuditQuash())
                {
                    if (this.AfterBtnAuditQuashClick != null)
                    {
                        this.AfterBtnAuditQuashClick(this.CategoryId, this.ObjectId);
                    }
                }
            }
        }
    }
}