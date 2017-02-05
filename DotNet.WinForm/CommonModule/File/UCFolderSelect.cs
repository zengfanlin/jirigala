//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Utilities;
    using DotNet.Business;

    /// <summary>
    /// UCFolderSelect.cs
    /// 文件夹管理-选择文件夹控件
    ///		
    /// 修改记录
    /// 
    ///     2008.03.21 版本：1.0 JiRiGaLa   初步创建。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.03.20</date>
    /// </author> 
    /// </summary>
    public partial class UCFolderSelect : UserControl
    {
        /// <summary>
        /// 当前用户信息
        /// 这里表示是只读的
        /// 问题点：无法获得登录用户的相关信息 解决：采用继承基类的用户信息
        /// </summary>
        public BaseUserInfo UserInfo
        {
            get
            {
                return BaseSystemInfo.UserInfo;
            }
        }

        private string selectedId = string.Empty; // 被选中的主键
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
                if (this.selectedId != null)
                {
                    if (!this.DesignMode)
                    {
                        BaseFolderEntity folderEntity = DotNetService.Instance.FolderService.GetEntity(UserInfo, this.selectedId);;
                        if (folderEntity != null)
                        {
                            this.SelectedFullName = folderEntity.FolderName;
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

        private string selectedFullName = string.Empty; // 被选中的名称
        public string SelectedFullName
        {
            get
            {
                return this.selectedFullName;
            }
            set
            {
                this.selectedFullName = value;
                this.txtFolder1.Text = value;
                this.SetControlState();
            }
        }

        public string OpenId = string.Empty;       // 原先被选中的节点主键

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

        public UCFolderSelect()
        {
            InitializeComponent();
            if (!this.DesignMode)
            {
                this.SetControlState();
            }
        }

        // 当选择的发生变化时
        public delegate void SelectedIndexChangedEventHandler(string id);
        public event SelectedIndexChangedEventHandler SelectedIndexChanged;

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

        private void btnSetNull_Click(object sender, EventArgs e)
        {
            if (this.txtFolder1.Text.Length > 0)
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

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.OpenId))
            {
                this.OpenId = this.SelectedId;
            }
            FrmFolderSelect FrmFolderSelect;
            if (String.IsNullOrEmpty(this.OpenId))
            {
                FrmFolderSelect = new FrmFolderSelect();
            }
            else
            {
                FrmFolderSelect = new FrmFolderSelect(this.OpenId);
            }
            FrmFolderSelect.AllowNull = this.AllowNull;
            FrmFolderSelect.CheckMove = this.CheckMove;

            if (FrmFolderSelect.ShowDialog() == DialogResult.OK)
            {

                this.SelectedFullName   = FrmFolderSelect.SelectedFullName;
                this.txtFolder1.Text     = FrmFolderSelect.SelectedFullName;
                this.SelectedId         = FrmFolderSelect.SelectedId;
                txtFolder1.Text = FrmFolderSelect.SelectedFullName;
               
                if (this.SelectedIndexChanged != null)
                {
                    this.SelectedIndexChanged(this.SelectedId);
                }
            }
            this.SetControlState();
        }
    }
}