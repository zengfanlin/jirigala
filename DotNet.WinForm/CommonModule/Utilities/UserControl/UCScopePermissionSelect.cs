//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Windows.Forms;
using System.ServiceModel;

namespace DotNet.WinForm
{
    using DotNet.Utilities;
    using DotNet.Business;

    /// <summary>
    /// UCScopePermissionSelect.cs
    /// 选择权限控件
    ///		
    /// 修改记录
    /// 
    ///     2008.04.14 版本：1.0 JiRiGaLa 创建主键。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.04.14</date>
    /// </author> 
    /// </summary>
    public partial class UCScopePermissionSelect : UserControl
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
                if (!String.IsNullOrEmpty(value))
                {
                    this.selectedId = value;
                    // 获取父节点
                    if (!this.DesignMode)
                    {
                        DotNetService dotNetService = new DotNetService();
                        BasePermissionItemEntity permissionItemEntity = dotNetService.PermissionItemService.GetEntity(UserInfo, this.selectedId);
                        if (dotNetService.PermissionItemService is ICommunicationObject)
                        {
                            ((ICommunicationObject)dotNetService.PermissionItemService).Close();
                        }
                        if (permissionItemEntity != null)
                        {
                            this.SelectedFullName = permissionItemEntity.FullName;
                        }
                        else
                        {
                            this.SelectedFullName = string.Empty;
                        } 
                    }
                    this.SetControlState();
                }
            }
        }


        private string selectedFullName = string.Empty; // 被选中的组织机构名称
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

        public string OpenParentId = string.Empty;  // 原先被选中的节点主键
        public bool CheckMove = false;              // 是否检查移动

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

        public UCScopePermissionSelect()
        {
            InitializeComponent();
            if (!this.DesignMode)
            {
                this.SetControlState();
            }
        }

        // 当选择的模块发生变化时
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            // 用反射获得窗体
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmScopePermissionSelect";
            Form frmScopePermissionSelect = CacheManager.Instance.GetForm(assemblyName, formName);
            ((FrmScopePermissionSelect)frmScopePermissionSelect).AllowNull = this.AllowNull;

            if (frmScopePermissionSelect.ShowDialog() == DialogResult.OK)
            {
                this.SelectedId = ((FrmScopePermissionSelect)frmScopePermissionSelect).SelectedId;
                this.SelectedFullName = ((FrmScopePermissionSelect)frmScopePermissionSelect).SelectedFullName;
                if (this.SelectedIndexChanged != null)
                {
                    this.SelectedIndexChanged(this.SelectedId);
                }
            }
        }

        private void btnSetNull_Click(object sender, EventArgs e)
        {
            if (this.txtFullName.Text.Length > 0)
            {
                this.SelectedId = null;
                this.SelectedFullName = null;
                if (this.SelectedIndexChanged != null)
                {
                    this.SelectedIndexChanged(this.SelectedId);
                }
            }
            this.SetControlState();
        }
    }
}
