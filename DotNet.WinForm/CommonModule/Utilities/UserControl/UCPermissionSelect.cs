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
    /// UCPermissionSelect.cs
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
    public partial class UCPermissionSelect : UserControl
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


        private string[] selectedIds = new string[0];            // 被选中的主键
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

        private bool checkMove = false;
        /// <summary>
        /// 检查移动
        /// </summary>
        public bool CheckMove
        {
            get
            {
                return this.checkMove;
            }
            set
            {
                this.checkMove = value;
            }
        }

        private string selectedId = string.Empty; // 被选中的权限主键
        public string SelectedId
        {
            get
            {
                return this.selectedId;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    // 置为空
                    this.SetNull();
                }
                else
                {
                    this.selectedId = value;
                    this.SelectedFullName = string.Empty;
                    if (!this.DesignMode)
                    {
                        // 获得权限信息
                        if (value != null)
                        {
                            DotNetService dotNetService = new DotNetService();
                            BasePermissionItemEntity permissionItemEntity = dotNetService.PermissionItemService.GetEntity(UserInfo, selectedId);
                            if (dotNetService.PermissionItemService is ICommunicationObject)
                            {
                                ((ICommunicationObject)dotNetService.PermissionItemService).Close();
                            }
                            this.SelectedFullName = permissionItemEntity.FullName;
                        }
                    }
                }
            }
        }

        private string selectedFullName = string.Empty; // 被选中的权限名称
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

        public UCPermissionSelect()
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
        }
        #endregion

        private void btnSelect_Click(object sender, EventArgs e)
        {
            // 用反射获得窗体
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmPermissionSelect";
            Form frmPermissionSelect = CacheManager.Instance.GetForm(assemblyName, formName);
            if (!String.IsNullOrEmpty(this.SelectedId))
            {
                ((FrmPermissionSelect)frmPermissionSelect).SelectedId = this.SelectedId;
            }
            if (!String.IsNullOrEmpty(this.OpenId))
            {
                ((FrmPermissionSelect)frmPermissionSelect).OpenId = this.OpenId;
            }
            ((FrmPermissionSelect)frmPermissionSelect).CheckMove = this.CheckMove;
            ((FrmPermissionSelect)frmPermissionSelect).AllowNull = this.AllowNull;
            
            if (frmPermissionSelect.ShowDialog() == DialogResult.OK)
            {
                this.SelectedId = ((FrmPermissionSelect)frmPermissionSelect).SelectedId;
                this.SelectedFullName = ((FrmPermissionSelect)frmPermissionSelect).SelectedFullName;
                if (this.SelectedIndexChanged != null)
                {
                    this.SelectedIndexChanged(this.SelectedId);
                }
            }
        }

        /// <summary>
        /// 置为空
        /// </summary>
        private void SetNull()
        {
            if (this.txtFullName.Text.Length > 0)
            {
                this.selectedId = null;
                this.selectedFullName = null;
                this.txtFullName.Text = string.Empty;
                if (this.SelectedIndexChanged != null)
                {
                    this.SelectedIndexChanged(this.SelectedId);
                }
            }
            this.SetControlState();
        }

        private void btnSetNull_Click(object sender, EventArgs e)
        {
            // 置为空
            this.SetNull();
        }
    }
}
