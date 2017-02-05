//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.ServiceModel;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// UCRoleSelect.cs
    /// 选择角色控件
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
    public partial class UCRoleSelect : UserControl
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


        /// <summary>
        /// 是否简化的角色管理
        /// </summary>
        public bool SimpleAdmin = false;

        private string selectedId = string.Empty; // 被选中的组织机构主键
        public string SelectedId
        {
            get
            {
                return this.selectedId;
            }
            set
            {
                this.selectedId = value;
                // 获取父节点
                if (!string.IsNullOrEmpty(this.selectedId))
                {
                    DotNetService dotNetService = new DotNetService();
                    BaseRoleEntity roleEntity = dotNetService.RoleService.GetEntity(UserInfo, this.selectedId);
                    if (dotNetService.RoleService is ICommunicationObject)
                    {
                        ((ICommunicationObject)dotNetService.RoleService).Close();
                    }
                    if (roleEntity != null)
                    {
                        this.SelectedFullName = roleEntity.RealName;
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

        private string selectedFullName = string.Empty; // 被选中的角色名称
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

        public bool CheckMove = false;             // 是否检查移动

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
        /// 是否允许选择用户
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

        private bool showRoleOnly = true;
        /// <summary>
        /// 只显示角色
        /// </summary>
        public bool ShowRoleOnly
        {
            get
            {
                return this.showRoleOnly;
            }
            set
            {
                this.showRoleOnly = value;
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

        private string byPermissionCode = string.Empty;
        /// <summary>
        /// 按什么权限域获取角色列表
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

        public UCRoleSelect()
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

        private void ShowRoleSelect()
        {
            // 用反射获得窗体
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmRoleSelect";
            Form frmRoleSelect = CacheManager.Instance.GetForm(assemblyName, formName);
            ((FrmRoleSelect)frmRoleSelect).ShowRoleOnly = this.ShowRoleOnly;
            ((FrmRoleSelect)frmRoleSelect).AllowNull = this.AllowNull;
            ((FrmRoleSelect)frmRoleSelect).PermissionItemScopeCode = this.PermissionItemScopeCode;
            if (frmRoleSelect.ShowDialog() == DialogResult.OK)
            {
                this.SelectedId = ((FrmRoleSelect)frmRoleSelect).SelectedId;
                this.SelectedFullName = ((FrmRoleSelect)frmRoleSelect).SelectedFullName;
                this.txtFullName.Text = ((FrmRoleSelect)frmRoleSelect).SelectedFullName;
                if (this.SelectedIndexChanged != null)
                {
                    this.SelectedIndexChanged(this.SelectedId);
                }
                this.SetControlState();
            }
        }

        private void ShowOrganizeRoleSelect()
        {
            // 用反射获得窗体
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmRoleSelect";
            Form frmRoleSelect = CacheManager.Instance.GetForm(assemblyName, formName);
            if (!String.IsNullOrEmpty(this.SelectedId))
            {
                ((FrmRoleSelect)frmRoleSelect).OpenId = this.SelectedId;
            }
            else
            {
                if (!String.IsNullOrEmpty(this.OpenId))
                {
                    ((FrmRoleSelect)frmRoleSelect).OpenId = this.OpenId;
                }
            }
            ((FrmRoleSelect)frmRoleSelect).ShowRoleOnly = this.ShowRoleOnly;
            ((FrmRoleSelect)frmRoleSelect).AllowNull = this.AllowNull;
            ((FrmRoleSelect)frmRoleSelect).PermissionItemScopeCode = this.PermissionItemScopeCode;
            if (frmRoleSelect.ShowDialog() == DialogResult.OK)
            {
                this.SelectedId = ((FrmRoleSelect)frmRoleSelect).SelectedId;
                this.SelectedFullName = ((FrmRoleSelect)frmRoleSelect).SelectedFullName;
                this.txtFullName.Text = ((FrmRoleSelect)frmRoleSelect).SelectedFullName;
                if (this.SelectedIndexChanged != null)
                {
                    this.SelectedIndexChanged(this.SelectedId);
                }
                this.SetControlState();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (this.SimpleAdmin)
            {
                this.ShowRoleSelect();
            }
            else
            {
                this.ShowOrganizeRoleSelect();
            }
        }

        public void SetNull()
        {
            if (this.SelectedId != null)
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

        private void btnSetNull_Click(object sender, EventArgs e)
        {
            SetNull();
        }
    }
}
