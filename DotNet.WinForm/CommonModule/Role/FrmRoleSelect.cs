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
    /// FrmRoleSelect.cs
    /// 权限管理-选择角色窗体
    ///		
    /// 修改记录
    /// 
    ///     2010.10.08 版本：1.2 JiRiGaLa   优化角色选择页面。
    ///     2007.05.29 版本：1.1 JiRiGaLa   优化CheckInput 方法。
    ///     2007.05.23 版本：1.0 JiRiGaLa   权限选择功能页面编写。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.23</date>
    /// </author> 
    /// </summary>
    public partial class FrmRoleSelect : BaseForm
    {
        private DataTable DTRole = new DataTable(BaseRoleEntity.TableName);

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

        private bool allowNull = true;
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

        private string selectedId = string.Empty; // 被选中的角色主键
        /// <summary>
        /// 被选中的角色主键
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

        private string selectedFullName = string.Empty; // 被选中的角色全名
        /// <summary>
        /// 被选中的角色全名
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

        private string[] selectedIds = new string[0];    // 被选中的主键集
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

        public FrmRoleSelect()
        {
            InitializeComponent();
        }

        public FrmRoleSelect(bool roleOnly)
            : this()
        {
        }

        #region private void BindItemDetails() 绑定下拉筐数据
        /// <summary>
        /// 绑定下拉筐数据
        /// </summary>
        private void BindItemDetails()
        {
            // 绑定职位数据，这里需要考虑屏幕刷新、批量保存时的效果问题
            if (this.cmbRoleCategory.Items.Count == 0)
            {
                DataTable dataTable = DotNetService.Instance.ItemDetailsService.GetDataTable(UserInfo, "ItemsRoleCategory");
                DataRow dataRow = dataTable.NewRow();
                dataTable.Rows.InsertAt(dataRow, 0);
                this.cmbRoleCategory.DisplayMember = BaseItemDetailsEntity.FieldItemName;
                this.cmbRoleCategory.ValueMember = BaseItemDetailsEntity.FieldItemValue;
                this.cmbRoleCategory.DataSource = dataTable.DefaultView;
            }
        }
        #endregion

        private void RemoveRole(string[] ids)
        {
            if (ids != null && ids.Length > 0)
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    DataRow dataRow = this.DTRole.Rows.Find(ids[i]);
                    if (dataRow != null)
                    {
                        dataRow.Delete();
                    }
                }
                this.DTRole.AcceptChanges();
            }
        }

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdRole);

            // 调用接口方式实现
            if (!String.IsNullOrEmpty(this.PermissionItemScopeCode))
            {
                this.DTRole = DotNetService.Instance.PermissionService.GetRoleDTByPermissionScope(UserInfo, UserInfo.Id, this.PermissionItemScopeCode);
            }
            else
            {
                this.DTRole = DotNetService.Instance.RoleService.GetDataTable(UserInfo);
            }

            // 设置表主键
            DataColumn[] primaryKey = new DataColumn[] { this.DTRole.Columns[BaseRoleEntity.FieldId] };
            this.DTRole.PrimaryKey = primaryKey;
            // 检查是否需要移出
            this.RemoveRole(this.RemoveIds);

            this.grdRole.AutoGenerateColumns = false;
            this.DTRole.DefaultView.Sort = BaseRoleEntity.FieldSortCode;
            this.grdRole.DataSource = this.DTRole;
            // 获取分类列表
            this.BindItemDetails();
            // 设置数据过滤
            this.SetRowFilter();
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnSelectAll.Enabled = false;
            this.btnInvertSelect.Enabled = false;
            this.btnSetNull.Visible = this.AllowNull;
            // 首先是需要能多选，其次是还有委托不是空的
            this.btnSelect.Visible = this.MultiSelect && this.OnSelected != null;
            if (this.DTRole.DefaultView.Count == 0)
            {
                this.btnConfirm.Enabled = false;
                this.btnSelect.Enabled = false;
            }
            else
            {
                this.btnSelectAll.Enabled = true;
                this.btnInvertSelect.Enabled = true;
                this.btnConfirm.Enabled = true;
                this.btnSelect.Enabled = true;
            }
            if (!this.MultiSelect)
            {
                this.btnSelectAll.Visible = false;
                this.btnInvertSelect.Visible = false;
            }
        }
        #endregion

        private string GetCategoryFilter()
        {
            string returnValue = string.Empty;
            if (this.cmbRoleCategory.SelectedValue != null)
            {
                if (this.cmbRoleCategory.SelectedValue.ToString().Length > 0)
                {
                    returnValue = BaseRoleEntity.FieldCategoryCode + " = '" + this.cmbRoleCategory.SelectedValue + "' ";
                }
            }
            return returnValue;
        }

        #region private void SetRowFilter() 设置数据过滤
        /// <summary>
        /// 设置数据过滤
        /// </summary>
        private void SetRowFilter()
        {
            this.DTRole.DefaultView.RowFilter = this.GetCategoryFilter();
        }
        #endregion

        private void rbtnDuty_CheckedChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                // 设置数据过滤
                this.SetRowFilter();
                // 设置按钮状态
                this.SetControlState();
            }
        }

        private void rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                // 设置数据过滤
                this.SetRowFilter();
                // 设置按钮状态
                this.SetControlState();
            }
        }

        #region private void GetSelectedId(DataRow dataRow) 获得已被选择的权限主键
        /// <summary>
        /// 获得已被选择的权限主键数组
        /// <param name="dataRow">数据行</param>
        /// </summary>
        private void GetSelectedId(DataRow dataRow)
        {
            // 获得当前选中的行 
            BaseRoleEntity roleEntity = new BaseRoleEntity();
            roleEntity.GetFrom(dataRow);
            // 获得具体选中的内容
            if (roleEntity.Id > 0)
            {
                this.SelectedId = roleEntity.Id.ToString();
                this.SelectedFullName = roleEntity.RealName;
            }
        }
        #endregion

        private void cmbRoleCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                // 设置数据过滤
                this.SetRowFilter();
                // 设置按钮状态
                this.SetControlState();
            }
        }

        private void grdRole_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!multiSelect)
            {
                if (!this.MultiSelect)
                {
                    foreach (DataGridViewRow dgvRow in grdRole.Rows)
                    {
                        if (dgvRow.Cells["colSelected"].Value != null && (bool)dgvRow.Cells["colSelected"].Value)
                        {
                            dgvRow.Cells["colSelected"].Value = false;
                        }
                    }
                }
            }
        }

        private void grdRole_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.MultiSelect)
            {
                DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdRole);
                if (dataRow != null)
                {
                    this.GetSelectedId(dataRow);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dgvRow in grdRole.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }
            //foreach (DataRowView dataRowView in this.DTRole.DefaultView)
            //{
            //    dataRowView.Row[BaseBusinessLogic.SelectedColumn] = true.ToString();
            //}
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in grdRole.Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false);
            }

            //foreach (DataRowView dataRowView in this.DTRole.DefaultView)
            //{
            //    if (dataRowView.Row[BaseBusinessLogic.SelectedColumn].ToString().Equals(true.ToString()))
            //    {
            //        dataRowView.Row[BaseBusinessLogic.SelectedColumn] = false.ToString();
            //    }
            //    else
            //    {
            //        dataRowView.Row[BaseBusinessLogic.SelectedColumn] = true.ToString();
            //    }
            //}
        }

        private void btnSetNull_Click(object sender, EventArgs e)
        {
            this.SelectedId = null;
            this.SelectedFullName = null;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #region private string[] GetSelectedIds() 获得已被选择的权限主键数组
        /// <summary>
        /// 获得已被选择的主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelectedIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdRole, BaseRoleEntity.FieldId, "colSelected", true);
        }
        #endregion

        /// <summary>
        /// 多项选择
        /// </summary>
        /// <param name="close">关闭窗体</param>
        private void SelectMulti(bool close = true)
        {
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdRole, "colSelected"))
            {
                this.SelectedIds = this.GetSelectedIds();
                // this.SelectedFullName = BaseBusinessLogic.ObjectsToList(this.GetSelectedFullNames());
                if (!close)
                {
                    if (this.OnSelected != null)
                    {
                        // 进行委托处理
                        if (this.OnSelected(this.SelectedIds))
                        {
                            this.RemoveRole(this.SelectedIds);
                            this.SelectedIds = null;
                        }
                        // 清除选中的数据
                        return;
                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void SelectRole()
        {
            if (BaseInterfaceLogic.CheckInputSelectOne(this.grdRole, "colSelected"))
            {
                DataRow dataRow = BaseInterfaceLogic.GetSelecteRow(this.grdRole, "colSelected");
                if (dataRow == null)
                {
                    // 默认当前的行
                    dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdRole);
                }
                if (dataRow != null)
                {
                    this.GetSelectedId(dataRow);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        /// <summary>
        /// 检查转移
        /// </summary>
        /// <param name="selectedId">选择的主键数组</param>
        /// <returns>是否成功</returns>
        public delegate bool OnSelectedEventHandler(string[] selectedIds);

        public event OnSelectedEventHandler OnSelected;

        private void btnSelect_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.MultiSelect)
            {
                // 选择好后，关闭窗体
                this.SelectMulti(true);
            }
            else
            {
                this.SelectRole();
            }
        }
    }
}