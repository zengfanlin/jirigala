//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FrmTableColumnPermission.cs
    /// 字段权限设置
    ///		
    /// 修改记录
    /// 
    ///     2011.06.06 版本：1.0 JiRiGaLa  模块配置。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.06.06</date>
    /// </author> 
    /// </summary>
    public partial class FrmTableColumnPermission : BaseForm
    {
        public FrmTableColumnPermission()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="resourceCategory">什么类型的</param>
        /// <param name="resourceId">什么资源</param>
        public FrmTableColumnPermission(string resourceCategory, string resourceId)
            : this()
        {
            this.ResourceCategory = resourceCategory;
            this.ResourceId = resourceId;
        }

        private DataTable DataTableScope = new DataTable(BaseItemDetailsEntity.TableName);

        private DataTable DataTableColumns = new DataTable(BaseTableColumnsEntity.TableName);

        private string resourceCategory = string.Empty;
        ///<summary>
        /// 什么类型的
        ///</summary>
        public string ResourceCategory
        {
            get
            {
                return resourceCategory;
            }
            set
            {
                resourceCategory = value;
            }
        }

        private string resourceId = string.Empty;
        ///<summary>
        /// 什么资源
        ///</summary>
        public string ResourceId
        {
            get
            {
                return resourceId;
            }
            set
            {
                resourceId = value;
            }
        }

        // 资源访问权限
        public string PermissionItemId = "";
        public string PermissionItemCode = "Resource.AccessPermission";

        // 访问列
        public string ColumnAccessPermissionId = "";
        public string ColumnAccessPermissionCode = "Column.Access";

        // 编辑列
        public string ColumnEditPermissionId = "";
        public string ColumnEditPermissionCode = "Column.Edit";

        // 拒绝访问列
        public string ColumnDeneyPermissionId = "";
        public string ColumnDeneyPermissionCode = "Column.Deney";

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            if (string.IsNullOrEmpty(this.PermissionItemId))
            {
                BasePermissionItemEntity permissionItemEntity = DotNetService.Instance.PermissionItemService.GetEntityByCode(this.UserInfo, this.PermissionItemCode);
                this.PermissionItemId = permissionItemEntity.Id.ToString();
            }
            if (string.IsNullOrEmpty(this.ColumnAccessPermissionId))
            {
                BasePermissionItemEntity permissionItemEntity = DotNetService.Instance.PermissionItemService.GetEntityByCode(this.UserInfo, this.ColumnAccessPermissionCode);
                this.ColumnAccessPermissionId = permissionItemEntity.Id.ToString();
            }
            if (string.IsNullOrEmpty(this.ColumnEditPermissionId))
            {
                BasePermissionItemEntity permissionItemEntity = DotNetService.Instance.PermissionItemService.GetEntityByCode(this.UserInfo, this.ColumnEditPermissionCode);
                this.ColumnEditPermissionId = permissionItemEntity.Id.ToString();
            }
            if (string.IsNullOrEmpty(this.ColumnDeneyPermissionId))
            {
                BasePermissionItemEntity permissionItemEntity = DotNetService.Instance.PermissionItemService.GetEntityByCode(this.UserInfo, this.ColumnDeneyPermissionCode);
                this.ColumnDeneyPermissionId = permissionItemEntity.Id.ToString();
            }

            if (this.ResourceCategory == BaseRoleEntity.TableName)
            {
                this.txtUserOrRole.Text = DotNetService.Instance.RoleService.GetEntity(this.UserInfo, this.ResourceId).RealName;
            }
            if (this.ResourceCategory == BaseUserEntity.TableName)
            {
                this.txtUserOrRole.Text = DotNetService.Instance.UserService.GetEntity(this.UserInfo, this.ResourceId).RealName;
            }
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(this.grdTableColumns);
            // 获得列表
            this.GetList();
            this.GetTableColumnList();
        }
        #endregion

        #region public override void GetList() 获取角色列表
        /// <summary>
        /// 获取角色列表
        /// </summary>
        public override void GetList()
        {
            this.DataTableScope = DotNetService.Instance.ItemDetailsService.GetDataTableByCode(UserInfo, "TablePermissionScope");
            this.DataTableScope.DefaultView.Sort = BaseItemDetailsEntity.FieldSortCode;
            // this.grdTable.AutoGenerateColumns = false;
            this.cklbTable.DataSource = this.DataTableScope.DefaultView;
            this.cklbTable.ValueMember = BaseItemDetailsEntity.FieldItemCode;
            this.cklbTable.DisplayMember = BaseItemDetailsEntity.FieldItemName;

            // 表的访问权限显示
            string[] selectIds = DotNetService.Instance.PermissionService.GetPermissionScopeTargetIds(this.UserInfo, this.ResourceCategory, this.ResourceId, "Table", this.PermissionItemCode);
            if (selectIds != null && selectIds.Length > 0)
            {
                for (int i = 0; i < this.cklbTable.Items.Count; i++)
                {
                    // this.cklbTable.SetItemChecked(i, true);
                    this.cklbTable.SetItemChecked(i, StringUtil.Exists(selectIds, ((DataRowView)this.cklbTable.Items[i])[BaseItemDetailsEntity.FieldItemCode].ToString()));
                }
            }
        }
        #endregion

        public override void SetControlState()
        {
            this.grdTableColumns.Columns[1].ReadOnly = !this.UserInfo.IsAdministrator;
        }

        private void GetTableColumnList()
        {
            if (this.cklbTable.Items.Count > 0)
            {
                this.cklbTable.SetSelected(0, true);
                string tableName = this.cklbTable.SelectedValue.ToString();
                this.GetTableColumnList(tableName);
            }
        }

        private void GetTableColumnList(string tableName)
        {
            this.DataTableColumns = DotNetService.Instance.TableColumnsService.GetDataTableByTable(UserInfo, tableName);
            this.grdTableColumns.AutoGenerateColumns = false;
            this.DataTableColumns.DefaultView.Sort = BaseTableColumnsEntity.FieldSortCode;
            this.grdTableColumns.DataSource = this.DataTableColumns.DefaultView;
            // 这里是列的访问权限处里
            // 表的访问权限显示
            string[] columns = DotNetService.Instance.PermissionService.GetPermissionScopeTargetIds(this.UserInfo, this.ResourceCategory, this.ResourceId, tableName, this.ColumnAccessPermissionCode);
            if (columns != null && columns.Length > 0)
            {
                for (int i = 0; i < columns.Length; i++)
                {
                    BaseBusinessLogic.SetProperty(this.DataTableColumns, BaseTableColumnsEntity.FieldColumnCode, columns[i], "ColumnAccess", 1);
                }
            }
            columns = DotNetService.Instance.PermissionService.GetPermissionScopeTargetIds(this.UserInfo, this.ResourceCategory, this.ResourceId, tableName, this.ColumnEditPermissionCode);
            if (columns != null && columns.Length > 0)
            {
                for (int i = 0; i < columns.Length; i++)
                {
                    BaseBusinessLogic.SetProperty(this.DataTableColumns, BaseTableColumnsEntity.FieldColumnCode, columns[i], "ColumnEdit", 1);
                }
            }
            columns = DotNetService.Instance.PermissionService.GetPermissionScopeTargetIds(this.UserInfo, this.ResourceCategory, this.ResourceId, tableName, this.ColumnDeneyPermissionCode);
            if (columns != null && columns.Length > 0)
            {
                for (int i = 0; i < columns.Length; i++)
                {
                    BaseBusinessLogic.SetProperty(this.DataTableColumns, BaseTableColumnsEntity.FieldColumnCode, columns[i], "ColumnDeney", 1);
                }
            }
        }

        private void cklbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                // 防止反复触发事件
                this.FormLoaded = false;
                this.grdTableColumns.DataSource = null;
                if (this.cklbTable.SelectedItem != null)
                {
                    string tableName = this.cklbTable.SelectedValue.ToString();
                    this.GetTableColumnList(tableName);
                }
                this.FormLoaded = true;
                // 设置鼠标默认状态，原来的光标状态
                this.Cursor = holdCursor;
            }
        }

        private void grdTableColumns_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.FormLoaded)
            {
                return;
            }

            // 2: 若是可以编辑，那就需要能访问。
            // 3: 访问权限的设置
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
                // 1: 若是拒绝的权限，那就不能把访问与可编辑权限赋予
                DataGridView dataGridView = (DataGridView)sender;
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                bool checkBoxChecked = (int)checkBoxCell.Value > 0;
                if (e.ColumnIndex == 1)
                {
                    if (!this.UserInfo.IsAdministrator)
                    {
                        return;
                    }
                    // 修改字段的公开属性
                    string id = ((DataRowView)dataGridView.Rows[e.RowIndex].DataBoundItem)[BaseTableColumnsEntity.FieldId].ToString();
                    string commandText = " UPDATE " + BaseTableColumnsEntity.TableName
                                       + "    SET " + BaseTableColumnsEntity.FieldIsPublic + " = ";
                    commandText += checkBoxChecked ? "1" : "0";
                    commandText += "  WHERE " + BaseTableColumnsEntity.FieldId + " = " + id;
                    DotNetService.Instance.UserCenterDbHelperService.ExecuteNonQuery(this.UserInfo, commandText);
                    return;
                }
                string columnPermissionId = string.Empty;
                if (e.ColumnIndex == 2)
                {
                    columnPermissionId = this.ColumnAccessPermissionId;
                }
                if (e.ColumnIndex == 3)
                {
                    columnPermissionId = this.ColumnEditPermissionId;
                }
                if (e.ColumnIndex == 4)
                {
                    columnPermissionId = this.ColumnDeneyPermissionId;
                }
                // 表名
                string tableCode = ((DataRowView)dataGridView.Rows[e.RowIndex].DataBoundItem)[BaseTableColumnsEntity.FieldTableCode].ToString();
                // 字段名
                string columnCode = ((DataRowView)dataGridView.Rows[e.RowIndex].DataBoundItem)[BaseTableColumnsEntity.FieldColumnCode].ToString();
                // e.ColumnIndex.ToString() + e.RowIndex.ToString();
                if (checkBoxChecked)
                {
                    // 被设置的权限
                    string grantResourceId = columnCode;
                    DotNetService.Instance.PermissionService.GrantPermissionScopeTarget(this.UserInfo, this.ResourceCategory, new string[] { this.ResourceId }, tableCode, grantResourceId, columnPermissionId);
                }
                else
                {
                    // 被取消的权限
                    string revokeResourceId = columnCode;
                    DotNetService.Instance.PermissionService.RevokePermissionScopeTarget(this.UserInfo, this.ResourceCategory, new string[] { this.ResourceId }, tableCode, revokeResourceId, columnPermissionId);
                }
            }
        }

        private void cklbTable_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            string tableName = ((System.Data.DataRowView)this.cklbTable.Items[e.Index])[BaseItemDetailsEntity.FieldItemCode].ToString();
            if (e.NewValue == CheckState.Checked)
            {
                string[] grantResourceIds = new string[] { tableName };
                DotNetService.Instance.PermissionService.GrantPermissionScopeTargets(this.UserInfo, this.ResourceCategory, this.ResourceId, "Table", grantResourceIds, this.PermissionItemId);
            }
            else
            {
                string[] revokeResourceIds = new string[] { tableName };
                DotNetService.Instance.PermissionService.RevokePermissionScopeTargets(this.UserInfo, this.ResourceCategory, this.ResourceId, "Table", revokeResourceIds, this.PermissionItemId);
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }

        #region private string[] GetSelectedIds() 获得已被选择的权限主键数组
        /// <summary>
        /// 获得已被选择的主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelectedIds()
        {
            List<string> ids = new List<string>();
            for (int i = 0; i < cklbTable.CheckedItems.Count; i++)
            {
                ids.Add(((System.Data.DataRowView)this.cklbTable.CheckedItems[i])[BaseItemDetailsEntity.FieldItemCode].ToString());
            }
            return ids.ToArray();
        }
        #endregion

        #region private string[] GetUnSelectedIds() 获得已被选择的权限主键数组
        /// <summary>
        /// 获得未被选择的主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetUnSelectedIds()
        {
            List<string> ids = new List<string>();
            for (int i = 0; i < cklbTable.Items.Count; i++)
            {
                if (!cklbTable.GetItemChecked(i))
                {
                    ids.Add(((System.Data.DataRowView)this.cklbTable.Items[i])[BaseItemDetailsEntity.FieldItemCode].ToString());
                }
            }
            return ids.ToArray();
        }
        #endregion

        #region private int BatchSaveTable() 批量保存表格访问权限
        /// <summary>
        /// 批量保存表格访问权限
        /// </summary>
        private int BatchSaveTable()
        {
            int returnValue = 0;
            // 被设置的权限
            string[] grantResourceIds = this.GetSelectedIds();
            returnValue += DotNetService.Instance.PermissionService.GrantPermissionScopeTargets(this.UserInfo, this.ResourceCategory, this.ResourceId, "Table", grantResourceIds, this.PermissionItemId);
            // 被取消的权限
            string[] revokeResourceIds = this.GetUnSelectedIds();
            returnValue += DotNetService.Instance.PermissionService.RevokePermissionScopeTargets(this.UserInfo, this.ResourceCategory, this.ResourceId, "Table", revokeResourceIds, this.PermissionItemId);
            return returnValue;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1：批量保存表格访问权限。
            this.BatchSaveTable();
            // 1：1 授权处理。
            // 1：2 取消授权处理。

            // 2：用户的列访问权限保存。
            // 2: 1 访问 权限处理
            // 2: 2 编辑 权限处理
            // 2: 3 拒绝访问 权限处理
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 导出Excel
            //string exportFileName = this.Text + ".csv";
            string exportFileName = this.Text + ".xls";
            this.ExportExcel(this.grdTableColumns , @"\Modules\Export\", exportFileName);
        }
    }
}