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
    /// UCItemDetailsTreeSelect
    /// 编码管理-选择编码控件
    ///		
    /// 修改记录
    /// 
    ///     2008.04.03 版本：1.0 JiRiGaLa 创建主键。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.04.03</date>
    /// </author> 
    /// </summary>
    public partial class UCItemDetailsTreeSelect : UserControl
    {
        /// <summary>
        /// 目标基础主键表
        /// </summary>
        public string TargetTableName = BaseItemDetailsEntity.TableName;

        /// <summary>
        /// 当前用户信息
        /// </summary>
        public BaseUserInfo UserInfo
        {
            get
            {
                return BaseSystemInfo.UserInfo;
            }
            set
            {
                BaseSystemInfo.UserInfo = value;
            }
        }

        public string SelectedId = string.Empty; // 被选中的编码主键

        public string ParentId = string.Empty;     // 基础主键父节点
        
        private string selectedFullName = string.Empty; // 被选中的编码名称
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
            }
        }
        public bool AllowNull = false;

        public delegate void SelectedIndexChangedEventHandler(string parentId);
        public event SelectedIndexChangedEventHandler SelectedIndexChanged;

        public UCItemDetailsTreeSelect()
        {
            InitializeComponent();
        }

        #region private void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        private void SetControlState()
        {
            this.btnParent.Enabled = ((this.ParentId !=null) && (this.ParentId.Length > 0));
        }
        #endregion

        #region private void GetParentId(DataTable dataTable) 获取父节点
        /// <summary>
        /// 获取父节点
        /// </summary>
        /// <param name="dataTable">数据表</param>
        private void GetParentId(DataTable dataTable)
        {
            BaseItemDetailsEntity itemDetailsEntity = new BaseItemDetailsEntity(dataTable);
            this.SelectedId         = itemDetailsEntity.Id.ToString();
            this.SelectedFullName   = itemDetailsEntity.ItemName;
            this.txtFullName.Text   = itemDetailsEntity.ItemName;
            this.ParentId           = itemDetailsEntity.ParentId.ToString();
        }
        #endregion

        #region public void SetParentId(BaseUserInfo userInfo, string id) 设置父节点
        /// <summary>
        /// 设置父节点
        /// </summary>
        /// <param name="id">主键</param>
        public void SetParentId(string id)
        {
            // 获取父节点
            // DataTable dataTable = DotNetService.Instance.ItemDetailsService.GetEntity(UserInfo, this.TargetTableName, id);
            // 设置父节点信息
            // this.GetParentId(dataTable);
            // 设置按钮状态
            this.SetControlState();
            if (this.SelectedIndexChanged != null)
            {
                this.SelectedIndexChanged(id);
            }
        }
        #endregion

        private void btnSelectItemDetails_Click(object sender, EventArgs e)
        {
            // 检测页面数据是否变化
            if (this.IsModfied != null)
            {
                if (this.IsModfied())
                {
                    // 数据有变动是否保存的提示
                    DialogResult myDialogResult = MessageBox.Show(AppMessage.MSG0065, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (myDialogResult == DialogResult.Cancel)
                    {
                        return;
                    }
                }
            }
            // 弹出选择窗口
            FrmItemDetailsTreeSelect myFrmItemDetailsTreeSelect = new FrmItemDetailsTreeSelect();
            myFrmItemDetailsTreeSelect.AllowNull = this.AllowNull;
            if (myFrmItemDetailsTreeSelect.ShowDialog() == DialogResult.OK)
            {
                this.SelectedId = myFrmItemDetailsTreeSelect.SelectedId;
                this.SetParentId(this.SelectedId);
            }
        }

        public delegate bool IsModfiedEventHandler();
        public event IsModfiedEventHandler IsModfied;

        private void btnParent_Click(object sender, EventArgs e)
        {
            if (this.IsModfied != null)
            {
                if (this.IsModfied())
                {
                    // 数据有变动是否保存的提示
                    DialogResult myDialogResult = MessageBox.Show(AppMessage.MSG0065, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (myDialogResult == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                // 设置父节点
                this.SetParentId(this.ParentId);
            }
        }
    }
}
