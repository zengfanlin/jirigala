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
    /// UCAutoWorkFlowStatr.cs
    /// 工作流提交控件
    ///		
    /// 修改记录
    ///     2012.04.27 版本：2.0 LiangMingMing 加入多条记录提交功能。
    ///     2010.10.09 版本：1.0 JiRiGaLa 编写此组件。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.10.09</date>
    /// </author> 
    /// </summary> 
    public partial class UCAutoWorkFlowStatr : UserControl
    {
        /// <summary>
        /// 审批流编号
        /// </summary>
        public string WorkFlowCode = "KaiFaBu_QingJiaLiuCheng";

        public string CategoryId        = String.Empty; // 单据分类代码
        public string CategoryFullName  = String.Empty; // 单据分类名称
        public string[] ObjectIds       = new string[0]; // 单据代码
        public string[] ObjectFullNames = new string[0]; // 单据名称

        // 转发给其他人 "提交" 按钮事件中挂接事件 并指定是否允许进行次操作
        public delegate bool ButtonSendToClickEventHandler(String categoryId, string[] objectId);
        public event ButtonSendToClickEventHandler BeforBtnSendToClick;
        public event ButtonSendToClickEventHandler AfterBtnSendToClick;

        // 输入有效性事件中挂接事件 并指定是否允许进行次操作
        public delegate bool OnCheckInputClickEventHandler();
        public event OnCheckInputClickEventHandler BeforCheckInputClick;

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

        public UCAutoWorkFlowStatr()
        {
            InitializeComponent();
        }

        private string selectedId = string.Empty;


        private string[] selectedIds = null;
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

        #region private void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        private void SetControlState()
        {
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
        }
        #endregion

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
            if ((this.ObjectIds.Length>0) && !string.IsNullOrEmpty(this.CategoryId))
            {
                string returnStatusCode = string.Empty;
                //DotNetService.Instance.WorkFlowCurrentService.AuditStatr(this.UserInfo, this.CategoryId, this.CategoryFullName, this.ObjectIds, this.ObjectFullNames, this.WorkFlowCode, this.txtAuditIdea.Text, out returnStatusCode);
                if (returnStatusCode == StatusCode.OK.ToString())
                {
                    if (BaseSystemInfo.ShowInformation)
                    {
                        MessageBox.Show(AppMessage.MSG0256, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    returnValue = true;
                }
                else
                {
                    if (BaseSystemInfo.ShowInformation)
                    {
                        MessageBox.Show(AppMessage.MSG0257, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (!this.BeforBtnSendToClick(this.CategoryId, this.ObjectIds))
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
                        this.AfterBtnSendToClick(this.CategoryId, this.ObjectIds);
                    }
                }
            }
        }
    }
}