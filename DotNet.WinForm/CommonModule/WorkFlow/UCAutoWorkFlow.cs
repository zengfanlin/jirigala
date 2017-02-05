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
    /// UCAutoWorkFlow.cs
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
    public partial class UCAutoWorkFlow : UserControl
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

        public string CategoryId = String.Empty; // 单据分类代码
        public string CategoryFullName = String.Empty; // 单据分类名称
        public string[] ObjectIds = new string[0]; // 单据代码
        public string[] ObjectFullNames = new string[0]; // 单据名称

        public int WorkFlowId = 0; // 单据走哪个已定义的工作流代码

        // 单据当前工作流识别代码 （BaseWorkFlowCurrent里指定的表）
        public string CurrentWorkFlowId = String.Empty;
        // 多个单据当前工作流识别代码 （BaseWorkFlowCurrent里指定的表）
        public String[] CurrentWorkFlowIds = null;

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

        private string[] selectedIds = null;    // 被选中的主键集
        /// <summary>
        /// 被选中的主键
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

        // 审批通过单据 "通过" 按钮事件中挂接事件 并指定是否允许进行次操作
        public delegate bool ButtonAuditPassClickEventHandler(String categoryId, string[] objectIds);
        public event ButtonAuditPassClickEventHandler BeforBtnAuditPassClick;
        public event ButtonAuditPassClickEventHandler AfterBtnAuditPassClick;

        // 退回单据 "退回" 按钮事件中挂接事件 并指定是否允许进行次操作
        public delegate bool ButtonAuditRejectClickEventHandler(String categoryId, string[] objectIds);

        //Pcsky 2012.05.02 未使用的功能，禁用
        //public event ButtonAuditRejectClickEventHandler BeforBtnAuditRejectClick;

        //Pcsky 2012.05.02 未使用的功能，禁用
        //public event ButtonAuditRejectClickEventHandler AfterBtnAuditRejectClick;

        // 查看审批记录 "记录" 按钮事件中挂接事件 并指定是否允许进行次操作
        public delegate bool ButtonAuditDetailClickEventHandler(String categoryId, string[] objectIds);
        public event ButtonAuditDetailClickEventHandler BeforBtnAuditDetailClick;
        public event ButtonAuditDetailClickEventHandler AfterBtnAuditDetailClick;

        public UCAutoWorkFlow()
        {
            InitializeComponent();
        }

        private void UCAutoWorkFlow_Load(object sender, EventArgs e)
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
            this.btnAuditDetail.Visible = this.ShowAuditDetail;
            this.btnAuditReject.Visible = this.ShowAuditReject;
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
        }
        #endregion

        #region private bool AuditPass() 最终审批通过
        /// <summary>
        /// 最终审批通过
        /// </summary>
        /// <returns></returns>
        private bool AuditPass()
        {
            int returnValue = 0;
            // 是否单个发送？
            if (!string.IsNullOrEmpty(this.CurrentWorkFlowId))
            {
                this.CurrentWorkFlowIds = new string[] { this.CurrentWorkFlowId };
            }
            returnValue += DotNetService.Instance.WorkFlowCurrentService.AuditPass(this.UserInfo, this.CurrentWorkFlowIds, this.txtAuditIdea.Text);

            if (returnValue > 0)
            {
                if (BaseSystemInfo.ShowInformation)
                {
                    // 更新成功，进行提示
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0247, returnValue.ToString()), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (BaseSystemInfo.ShowInformation)
                {
                    // 更新成功，进行提示
                    MessageBox.Show(AppMessage.MSG0248, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            // 控件状态
            // this.txtAuditIdea.Enabled = false;
            // this.btnAuditReject.Enabled = false;
            // this.txtFullName.Enabled = false;

            return returnValue > 0;
        }
        #endregion

        private bool CheckAuditPass()
        {
            bool returnValue = true;
            if (string.IsNullOrEmpty(this.CurrentWorkFlowId) && this.CurrentWorkFlowIds == null)
            {
                MessageBox.Show(AppMessage.MSG0249, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (MessageBox.Show(AppMessage.MSG0250, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return false;
            }
            return returnValue;
        }

        private void btnAuditPass_Click(object sender, EventArgs e)
        {
            if (this.BeforBtnAuditPassClick != null)
            {
                if (!this.BeforBtnAuditPassClick(this.CategoryId, this.ObjectIds))
                {
                    return;
                }
            }
            if (this.CheckAuditPass())
            {
                // 最终审批通过
                if (this.AuditPass())
                {
                    if (this.AfterBtnAuditPassClick != null)
                    {
                        this.AfterBtnAuditPassClick(this.CategoryId, this.ObjectIds);
                    }
                }
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
                MessageBox.Show(AppMessage.MSG0251, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show(AppMessage.MSG0252, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (this.txtAuditIdea.Text.Length == 0)
            {
                if (MessageBox.Show(AppMessage.MSG0253, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    this.txtAuditIdea.Focus();
                    return false;
                }
            }
            if (MessageBox.Show(AppMessage.MSG0255, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                return false;
            }
            return returnValue;
        }

        private void btnAuditReject_Click(object sender, EventArgs e)
        {

        }

        private bool AuditDetail()
        {
            // 查看历史信息
            FrmWorkFlowAuditDetail frmWorkFlowAuditDetail = new FrmWorkFlowAuditDetail(this.CategoryId, this.ObjectIds[0]);
            frmWorkFlowAuditDetail.ShowDialog(this);
            return true;
        }

        public virtual void btnAuditDetail_Click(object sender, EventArgs e)
        {
            // 提交前的检查工作
            if (this.BeforBtnAuditDetailClick != null)
            {
                if (!this.BeforBtnAuditDetailClick(this.CategoryId, this.ObjectIds))
                {
                    return;
                }
            }
            // 转发单据
            if (this.AuditDetail())
            {
                if (this.AfterBtnAuditDetailClick != null)
                {
                    this.AfterBtnAuditDetailClick(this.CategoryId, this.ObjectIds);
                }
            }
        }
    }
}