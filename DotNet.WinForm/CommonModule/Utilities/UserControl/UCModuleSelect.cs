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
    /// UCModuleSelect.cs
    /// 选择模块控件
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
    public partial class UCModuleSelect : UserControl
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
                if (!String.IsNullOrEmpty(this.selectedId))
                {
                    // 获取父节点
                    if (this.selectedId != null)
                    {
                        DotNetService dotNetService = new DotNetService();
                        BaseModuleEntity moduleEntity = dotNetService.ModuleService.GetEntity(UserInfo, this.selectedId);
                        if (dotNetService.ModuleService is ICommunicationObject)
                        {
                            ((ICommunicationObject)dotNetService.ModuleService).Close();
                        }
                        if (moduleEntity != null)
                        {
                            this.SelectedFullName = moduleEntity.FullName;
                        }
                        else
                        {
                            this.SelectedFullName = string.Empty;
                        }
                    }
                    this.SetControlState();
                }
                else
                {
                    this.SelectedFullName = string.Empty;
                }
            }
        }

        private string selectedCode = string.Empty; // 被选中的模块编号
        public string SelectedCode
        {
            get
            {
                return this.selectedCode;
            }
            set
            {
                this.selectedCode = value;
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

        private bool allowSelect = true;
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

        public UCModuleSelect()
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
            string formName = "FrmModuleSelect";
            Form frmModuleSelect = CacheManager.Instance.GetForm(assemblyName, formName);
            //if (!String.IsNullOrEmpty(this.SelectedId))
            //{
            //    ((IBaseSelectModuleForm)frmModuleSelect).OpenId = this.SelectedId;
            //}
            //else
            //{
                //if (!String.IsNullOrEmpty(this.OpenId))
                //{
                //    ((IBaseSelectModuleForm)frmModuleSelect).OpenId = this.OpenId;
                //}
            //}
            if (!String.IsNullOrEmpty(this.OpenId))
            {
                ((FrmModuleSelect)frmModuleSelect).OpenId = this.OpenId;
            }
            ((FrmModuleSelect)frmModuleSelect).CheckMove = this.CheckMove;
            ((FrmModuleSelect)frmModuleSelect).AllowNull = this.AllowNull;

            if (frmModuleSelect.ShowDialog() == DialogResult.OK)
            {
                this.SelectedId = ((FrmModuleSelect)frmModuleSelect).SelectedId;
                this.SelectedCode = ((FrmModuleSelect)frmModuleSelect).SelectedCode;
                this.SelectedFullName = ((FrmModuleSelect)frmModuleSelect).SelectedFullName;
                if (this.SelectedIndexChanged != null)
                {
                    this.SelectedIndexChanged(this.SelectedId);
                }
            }
            this.SetControlState();
        }

        private void btnSetNull_Click(object sender, EventArgs e)
        {
            this.SelectedId = null;
            this.SelectedCode = null;
            this.SelectedFullName = null;
            if (this.SelectedIndexChanged != null)
            {
                this.SelectedIndexChanged(this.SelectedId);
            }
            this.SetControlState();
        }
    }
}
