//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// UCUserSelect.cs
    /// 用户管理-选择用户控件
    ///		
    /// 修改记录
    /// 
    ///     2011.08.07 版本：2.0 JiRiGaLa   显示姓名功能实现。
    ///     2008.09.30 版本：1.0 JiRiGaLa   初步创建。
    ///		
    /// 版本：2.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.08.07</date>
    /// </author> 
    /// </summary>
    public partial class UCUserSelect : UserControl
    {
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

        private string selectedId = string.Empty; // 被选中的组织机构主键
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
                    // 获取父节点
                    if (!string.IsNullOrEmpty(this.selectedId))
                    {
                        DotNetService dotNetService = new DotNetService();
                        BaseUserEntity userEntity = dotNetService.UserService.GetEntity(UserInfo, this.selectedId);
                        if (dotNetService.UserService is ICommunicationObject)
                        {
                            ((ICommunicationObject)dotNetService.UserService).Close();
                        }

                        if (userEntity != null)
                        {
                            this.SelectedFullName = userEntity.RealName;
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

        /// <summary>
        /// 是否简化的角色管理
        /// </summary>
        public bool SimpleAdmin = false;

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

        private bool allowNull = true;
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
        /// 按什么权限域获取员工列表
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

        public UCUserSelect()
        {
            InitializeComponent();
            if (!this.DesignMode)
            {
                this.SetControlState();
            }
        }

        // 当选择的公司部门发生变化时
        public event BaseBusinessLogic.SelectedIndexChangedEventHandler SelectedIndexChanged;

        #region private void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        private void SetControlState()
        {
            this.pnlNull.Visible = this.AllowNull;
            this.btnSetNull.Visible = this.AllowNull;
            if (String.IsNullOrEmpty(this.SelectedId))
            {
                this.btnSetNull.Enabled = false;
            }
            else
            {
                this.btnSetNull.Enabled = true;
            }

            this.btnSelect.Visible = this.AllowSelect;
            this.pnlSelect.Visible = this.AllowSelect;
        }
        #endregion

        public void SetNull()
        {
            if (this.SelectedId != null)
            {
                this.SelectedId = null;
                this.SelectedFullName = null;
                this.selectedIds = null;
                if (this.SelectedIndexChanged != null)
                {
                    this.SelectedIndexChanged(this.SelectedId);
                }
            }
            this.SetControlState();
        }

        private void btnSetNull_Click(object sender, EventArgs e)
        {
            this.SetNull();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            // 用反射获得窗体
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmUserSelect";
            FrmUserSelect frmUserSelect = (FrmUserSelect)CacheManager.Instance.GetForm(assemblyName, formName);
            frmUserSelect.AllowNull = this.AllowNull;
            frmUserSelect.MultiSelect = this.MultiSelect;
            if (!String.IsNullOrEmpty(this.OpenId))
            {
                frmUserSelect.OpenId = this.OpenId;
            }
            if (this.MultiSelect && this.SelectedIds != null)
            {
                frmUserSelect.SetSelectIds = this.SelectedIds;
            }
            frmUserSelect.PermissionItemScopeCode = this.PermissionItemScopeCode;
            if (frmUserSelect.ShowDialog() == DialogResult.OK)
            {
                this.SelectedId = frmUserSelect.SelectedId;
                this.SelectedFullName = frmUserSelect.SelectedFullName;
                this.txtFullName.Text = frmUserSelect.SelectedFullName;
                this.SelectedIds = frmUserSelect.SelectedIds;
                if (this.SelectedIndexChanged != null)
                {
                    this.SelectedIndexChanged(this.SelectedId);
                }
            }
            this.SetControlState();
        }
    }
}