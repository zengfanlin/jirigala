//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Utilities;
    using DotNet.Business;

    /// <summary>
    /// UCOrganizeSelect.cs
    /// 部门管理-选择部门控件
    ///		
    /// 修改记录
    /// 
    ///     2008.04.18 版本：1.1 JiRiGaLa   进行优化，删除重复运行的逻辑主键。
    ///     2008.03.20 版本：1.0 JiRiGaLa   初步创建。
    ///		
    /// 版本：1.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.04.18</date>
    /// </author> 
    /// </summary>
    public partial class UCOrganizeSelect : UserControl
    {
        public event BaseBusinessLogic.CheckMoveEventHandler OnButtonConfirmClick;

        public bool CanEdit
        {
            get
            {
                return !this.txtFullName.ReadOnly;
            }
            set
            {
                this.txtFullName.ReadOnly = !value;
            }
        }

        /// <summary>
        /// 是否允许选择
        /// </summary>
        public bool AllowSelect
        {
            get
            {
                return this.btnSelect.Visible;
            }
            set
            {
                this.btnSelect.Visible = value;
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
                this.SelectedFullName = string.Empty;
                if (!this.DesignMode)
                {
                    // 获取父节点
                    if (!string.IsNullOrEmpty(this.selectedId))
                    {
                        if (!this.DesignMode)
                        {
                            DotNetService dotNetService = new DotNetService();
                            BaseOrganizeEntity organizeEntity = dotNetService.OrganizeService.GetEntity(UserInfo, this.selectedId);
                            if (dotNetService.OrganizeService is ICommunicationObject)
                            {
                                ((ICommunicationObject)dotNetService.OrganizeService).Close();
                            }
                            if (organizeEntity != null)
                            {
                                this.SelectedFullName = organizeEntity.FullName;
                            }
                            else
                            {
                                this.SelectedFullName = string.Empty;
                            }
                        }
                    }
                    this.SetControlState();
                }
            }
        }

        /// <summary>
        /// 被选中的组织机构名称
        /// </summary>
        public string SelectedFullName
        {
            get
            {
                return this.txtFullName.Text;
            }
            set
            {
                this.txtFullName.Text = value;
                this.SetControlState();
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

        private string byPermission = string.Empty;
        /// <summary>
        /// 按什么权限域获取角色列表
        /// </summary>
        public string PermissionItemScopeCode
        {
            get
            {
                return this.byPermission;
            }
            set
            {
                this.byPermission = value;
            }
        }

        private string openId = string.Empty;
        /// <summary>
        /// 原先被选中的节点主键
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


        private bool checkMove = false;
        /// <summary>
        /// 是否检查移动
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

        public UCOrganizeSelect()
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
            this.btnSetNull.Enabled = !String.IsNullOrEmpty(this.SelectedId);
        }
        #endregion

        private void UCOrganizeSelect_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.SetControlState();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            // 用反射获得窗体
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmOrganizeSelect";
            Form frmOrganizeSelect = CacheManager.Instance.GetForm(assemblyName, formName);
            //季俊武 20110219 修改给OpenId赋值,OpenId为当前节点的Code每次都需要赋值  
            //if (!String.IsNullOrEmpty(this.SelectedId))
            //{
            //    ((IBaseSelectOrganizeForm)frmOrganizeSelect).OpenId = this.SelectedId;
            //}
            //else
            //{
            //    if (!String.IsNullOrEmpty(this.OpenId))
            //    {
            ((FrmOrganizeSelect)frmOrganizeSelect).OpenId = this.OpenId;
            //    }
            //}
            ((FrmOrganizeSelect)frmOrganizeSelect).CheckMove = this.CheckMove;
            ((FrmOrganizeSelect)frmOrganizeSelect).AllowNull = this.AllowNull;
            ((FrmOrganizeSelect)frmOrganizeSelect).PermissionItemScopeCode = this.PermissionItemScopeCode;

            if (frmOrganizeSelect.ShowDialog() == DialogResult.OK)
            {
                this.SelectedId = ((FrmOrganizeSelect)frmOrganizeSelect).SelectedId;
                this.SelectedFullName = ((FrmOrganizeSelect)frmOrganizeSelect).SelectedFullName;
                if (this.SelectedIndexChanged != null)
                {
                    this.SelectedIndexChanged(this.SelectedId);
                }
            }
        }

        public void SetNull()
        {
            if (!String.IsNullOrEmpty(this.SelectedId))
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
            this.SetNull();
        }

        private void Confirm()
        {
            if (this.OnButtonConfirmClick != null)
            {
                if (this.OnButtonConfirmClick(this.SelectedId))
                {

                }
            }
            else
            {

            }
        }
    }
}