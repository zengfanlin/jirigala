//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FrmScopePermissionSelect.cs
    /// 权限管理-选择权限域窗体
    ///		
    /// 修改记录
    /// 
    ///     2007.05.30 版本：1.0 JiRiGaLa   权限选择功能页面编写。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.30</date>
    /// </author> 
    /// </summary>
    public partial class FrmScopePermissionSelect : BaseForm
    {
        private DataTable DTPermission = new DataTable(BasePermissionItemEntity.TableName);  // 权限 DataTable

        private bool allowNull = false;
        /// <summary>
        /// 是否允许选择空
        /// </summary>
        public bool AllowNull
        {
            get
            {
                return this.allowNull;
            }
            set
            {
                this.allowNull = value;
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
            }
        }

        private string selectedId = string.Empty;
        /// <summary>
        /// 被选中的权限主键
        /// </summary>
        public string SelectedId
        {
            get
            {
                return this.selectedId;
            }
            set
            {
                this.selectedId = value;
            }
        }

        private string selectedFullName = string.Empty;
        /// <summary>
        /// 被选中的权限全名
        /// </summary>
        public string SelectedFullName
        {
            get
            {
                return this.selectedFullName;
            }
            set
            {
                this.selectedFullName = value;
            }
        }

        /// <summary>
        /// 按什么权限获取角色列表
        /// </summary>
        public string PermissionItemScopeCode = string.Empty;

        public FrmScopePermissionSelect()
        {
            InitializeComponent();
        }

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdPermission);
            // 调用接口方式实现
            this.DTPermission = DotNetService.Instance.PermissionItemService.GetDataTable(UserInfo);
            this.DTPermission.DefaultView.Sort = BasePermissionItemEntity.FieldSortCode;
            // 只显示权限域的权限列表
            BaseBusinessLogic.SetFilter(this.DTPermission, BasePermissionItemEntity.FieldIsScope, "1");
            this.grdPermission.AutoGenerateColumns = false;
            this.DTPermission.DefaultView.Sort = BasePermissionItemEntity.FieldSortCode;
            this.grdPermission.DataSource = this.DTPermission;
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnSetNull.Visible = this.AllowNull;
            if (this.DTPermission.DefaultView.Count == 0)
            {
                this.btnConfirm.Enabled = false;
            }
            else
            {
                this.btnConfirm.Enabled = true;
            }
        }
        #endregion

        #region private void GetSelecteId(DataRow dataRow) 获得已被选择的权限主键
        /// <summary>
        /// 获得已被选择的权限主键数组
        /// <param name="dataRow">数据行</param>
        /// </summary>
        private void GetSelectedId(DataRow dataRow)
        {
            // 获得当前选中的行 
            BasePermissionItemEntity permissionItemEntity = new BasePermissionItemEntity();
            permissionItemEntity.GetFrom(dataRow);
            // 获得具体选中的内容
            if (permissionItemEntity.Id > 0)
            {
                this.SelectedId = permissionItemEntity.Id.ToString();
                this.SelectedFullName = permissionItemEntity.FullName;
            }
        }
        #endregion

        private void grdPermission_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow dgvRow in grdPermission.Rows)
            {
                if (dgvRow.Cells["colSelected"].Value != null && (bool)dgvRow.Cells["colSelected"].Value)
                {
                    dgvRow.Cells["colSelected"].Value = false;
                }
            }
        }

        private void grdPermission_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdPermission);
            if (dataRow != null)
            {
                this.GetSelectedId(dataRow);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnSetNull_Click(object sender, EventArgs e)
        {
            this.SelectedId = null;
            this.SelectedFullName = null;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (BaseInterfaceLogic.CheckInputSelectOne(this.grdPermission, "colSelected"))
            {
                DataRow dataRow = BaseInterfaceLogic.GetSelecteRow(this.grdPermission, "colSelected");
                if (dataRow == null)
                {
                    // 默认当前的行
                    dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdPermission);
                }
                if (dataRow != null)
                {
                    this.GetSelectedId(dataRow);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}