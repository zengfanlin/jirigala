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
    /// FrmRoleOrganizeScope.cs
    /// 角色数据权限范围设置
    ///		
    /// 修改记录
    /// 
    ///     2012.05.07 版本：1.2 JiRiGaLa  所在分支机构。
    ///     2011.02.26 版本：1.1 JiRiGaLa  默认加载数据权限。
    ///     2010.12.08 版本：1.0 JiRiGaLa  模块配置。
    ///		
    /// 版本：1.2
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.05.07</date>
    /// </author> 
    /// </summary>
    public partial class FrmRoleOrganizeScope : BaseForm
    {
        public FrmRoleOrganizeScope()
        {
            InitializeComponent();
        }

        public FrmRoleOrganizeScope(string permissionItemScopeCode)
            : this()
        {
            this.PermissionItemScopeCode = permissionItemScopeCode;
        }

        private string TargetPermissionId
        {
            get
            {
                return this.ucPermissionScope.SelectedId;
            }
            set
            {
                this.ucPermissionScope.SelectedId = value;
            }
        }

        public string permissionItemScopeCode = "Resource.ManagePermission";

        /// <summary>
        /// 权限域（范围权限、数据权限）
        /// </summary>
        public string PermissionItemScopeCode
        {
            set
            {
                permissionItemScopeCode = value;
                BasePermissionItemEntity permissionItemEntity = DotNetService.Instance.PermissionItemService.GetEntityByCode(this.UserInfo, permissionItemScopeCode);
                this.ucPermissionScope.SelectedId = permissionItemEntity.Id.ToString();
            }
            get
            {
                return permissionItemScopeCode;
            }
        }

        /// <summary>
        /// 以组织机构为主的数据权限
        /// </summary>
        DataTable dtRoleOrganizeScope = new DataTable(BaseRoleEntity.TableName);

        private void ucPermissionScope_SelectedIndexChanged(string selectedId)
        {
            BasePermissionItemEntity permissionItemEntity = DotNetService.Instance.PermissionItemService.GetEntity(this.UserInfo, selectedId);
            if (permissionItemEntity != null)
            {
                this.TargetPermissionId = permissionItemEntity.Id.ToString();
                this.PermissionItemScopeCode = permissionItemEntity.Code;
                this.GetRoleOrganizeScope();
            }
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

        #region private void SetRowFilter() 设置数据过滤
        /// <summary>
        /// 设置数据过滤
        /// </summary>
        private void SetRowFilter()
        {
            if (dtRoleOrganizeScope.Rows.Count > 0)
            {
                this.dtRoleOrganizeScope.DefaultView.RowFilter = this.GetCategoryFilter();
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

        public override void SetControlState()
        {
            this.btnBatchSave.Enabled = false;
            if (this.dtRoleOrganizeScope.Rows.Count > 0)
            {
                this.btnBatchSave.Enabled = true;
            }
        }

        private void GetRoleOrganizeScope()
        {
            // 1.获取角色列表
            // 自己能管理的角色列表才对，是否启用了权限范围管理
            dtRoleOrganizeScope = this.GetRoleScope(this.PermissionItemScopeCode);

            // 去掉超级管理员
            for (int i = 0; i < dtRoleOrganizeScope.Rows.Count; i++)
            {
                if (dtRoleOrganizeScope.Rows[i][BaseRoleEntity.FieldCode].ToString().Equals(DefaultRole.Administrators.ToString()))
                {
                    dtRoleOrganizeScope.Rows[i].Delete();
                    break;
                }
            }
            dtRoleOrganizeScope.AcceptChanges();
            
            // 2.设置数据权限范围的列
            dtRoleOrganizeScope.Columns.Add("colAll", typeof(bool));
            dtRoleOrganizeScope.Columns.Add("colUserCompany", typeof(bool));
            dtRoleOrganizeScope.Columns.Add("colUserSubCompany", typeof(bool));
            dtRoleOrganizeScope.Columns.Add("colUserDepartment", typeof(bool));
            dtRoleOrganizeScope.Columns.Add("colUserWorkgroup", typeof(bool));
            dtRoleOrganizeScope.Columns.Add("colUser", typeof(bool));
            dtRoleOrganizeScope.Columns.Add("colNone", typeof(bool));
            dtRoleOrganizeScope.Columns.Add("colDetail", typeof(bool));

            // 3.获取数据权限

            // 4.绑定数据
            string targetRoleId = string.Empty;
            for (int i = 0; i < dtRoleOrganizeScope.Rows.Count; i++)
            {
                targetRoleId = this.dtRoleOrganizeScope.Rows[i][BaseRoleEntity.FieldId].ToString();
                // Nick Deng 将参数从this.PermissionItemScopeCode改为this.PermissionItemScopeCode
                string[] organizeIds = DotNetService.Instance.PermissionService.GetRoleScopeOrganizeIds(UserInfo, targetRoleId, this.PermissionItemScopeCode);
                if (StringUtil.Exists(organizeIds, ((int)PermissionScope.None).ToString()))
                {
                    // dtRoleOrganizeScope.Rows[i]["colNone"] = true;
                }
                if (StringUtil.Exists(organizeIds, ((int)PermissionScope.Detail).ToString()))
                {
                    dtRoleOrganizeScope.Rows[i]["colDetail"] = true;
                }
                if (StringUtil.Exists(organizeIds, ((int)PermissionScope.User).ToString()))
                {
                    dtRoleOrganizeScope.Rows[i]["colUser"] = true;
                }
                if (StringUtil.Exists(organizeIds, ((int)PermissionScope.UserWorkgroup).ToString()))
                {
                    dtRoleOrganizeScope.Rows[i]["colUserWorkgroup"] = true;
                }
                if (StringUtil.Exists(organizeIds, ((int)PermissionScope.UserDepartment).ToString()))
                {
                    dtRoleOrganizeScope.Rows[i]["colUserDepartment"] = true;
                }
                if (StringUtil.Exists(organizeIds, ((int)PermissionScope.UserSubCompany).ToString()))
                {
                    dtRoleOrganizeScope.Rows[i]["colUserSubCompany"] = true;
                }
                if (StringUtil.Exists(organizeIds, ((int)PermissionScope.UserCompany).ToString()))
                {
                    dtRoleOrganizeScope.Rows[i]["colUserCompany"] = true;
                }
                if (StringUtil.Exists(organizeIds, ((int)PermissionScope.All).ToString()))
                {
                    dtRoleOrganizeScope.Rows[i]["colAll"] = true;
                }
            }

            // 5.表格绑定数据
            dtRoleOrganizeScope.DefaultView.Sort = BaseRoleEntity.FieldSortCode;
            this.grdRole.DataSource = dtRoleOrganizeScope.DefaultView;

            // 6.设置排序按钮
            this.ucTableSort.DataBind(this.grdRole);

            // 设置数据过滤
            this.SetRowFilter();
            this.SetControlState();
        }

        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdRole);
            // 获取分类列表
            this.BindItemDetails();
            if (string.IsNullOrEmpty(this.TargetPermissionId))
            {
                DataTable dtPermissionItem = this.GetPermissionItemScop(this.PermissionItemScopeCode);
                dtPermissionItem.DefaultView.Sort = BasePermissionItemEntity.FieldSortCode;
                // 只显示权限域的权限列表
                BaseBusinessLogic.SetFilter(dtPermissionItem, BasePermissionItemEntity.FieldIsScope, "1");
                if (dtPermissionItem.Rows.Count > 0)
                {
                    BasePermissionItemEntity permissionItemEntity = new BasePermissionItemEntity(dtPermissionItem.Rows[0]);
                    this.ucPermissionScope.SelectedId = permissionItemEntity.Id.ToString();
                }
            }
            this.grdRole.AutoGenerateColumns = false;

            this.GetRoleOrganizeScope();

            this.SetControlState();
        }

        /// <summary>
        /// 获得当前选中的权限范围选项
        /// </summary>
        /// <param name="dataRow">当前数据权限的设置</param>
        /// <returns>选中权限范围</returns>
        private PermissionScope GetPermissionScope(DataRow dataRow, out string revokePermissionScope)
        {
            revokePermissionScope = string.Empty;
            PermissionScope returnValue = PermissionScope.None;

            if (dataRow["colAll"] != DBNull.Value)
            {
                if ((bool)dataRow["colAll"])
                {
                    returnValue = PermissionScope.All;
                }
                else
                {
                    revokePermissionScope += ((int)PermissionScope.All).ToString() + ";";
                }
            }

            if (dataRow["colUserCompany"] != DBNull.Value)
            {
                if ((bool)dataRow["colUserCompany"])
                {
                    returnValue = PermissionScope.UserCompany;
                }
                else
                {
                    revokePermissionScope += ((int)PermissionScope.UserCompany).ToString() + ";";
                }
            }

            if (dataRow["colUserSubCompany"] != DBNull.Value)
            {
                if ((bool)dataRow["colUserSubCompany"])
                {
                    returnValue = PermissionScope.UserSubCompany;
                }
                else
                {
                    revokePermissionScope += ((int)PermissionScope.UserSubCompany).ToString() + ";";
                }
            }

            if (dataRow["colUserDepartment"] != DBNull.Value)
            {
                if ((bool)dataRow["colUserDepartment"])
                {
                    returnValue = PermissionScope.UserDepartment;
                }
                else
                {
                    revokePermissionScope += ((int)PermissionScope.UserDepartment).ToString() + ";";
                }
            }

            if (dataRow["colUserWorkgroup"] != DBNull.Value)
            {
                if ((bool)dataRow["colUserWorkgroup"])
                {
                    returnValue = PermissionScope.UserWorkgroup;
                }
                else
                {
                    revokePermissionScope += ((int)PermissionScope.UserWorkgroup).ToString() + ";";
                }
            }

            if (dataRow["colUser"] != DBNull.Value)
            {
                if ((bool)dataRow["colUser"])
                {
                    returnValue = PermissionScope.User;
                }
                else
                {
                    revokePermissionScope += ((int)PermissionScope.User).ToString() + ";";
                }
            }

            if (dataRow["colDetail"] != DBNull.Value)
            {
                if ((bool)dataRow["colDetail"])
                {
                    returnValue = PermissionScope.Detail;
                }
                else
                {
                    revokePermissionScope += ((int)PermissionScope.Detail).ToString() + ";";
                }
            }

            if (dataRow["colNone"] != DBNull.Value)
            {
                if ((bool)dataRow["colNone"])
                {
                    returnValue = PermissionScope.None;
                }
                else
                {
                    revokePermissionScope += ((int)PermissionScope.None).ToString() + ";";
                }
            }

            return returnValue;
        }

        public bool BatchSave()
        {
            string grantOrganizes = string.Empty;
            string revokeOrganizes = string.Empty;
            string targetRoleId = string.Empty;
            for (int i = 0; i < this.dtRoleOrganizeScope.Rows.Count; i++)
            {
                targetRoleId = this.dtRoleOrganizeScope.Rows[i][BaseRoleEntity.FieldId].ToString();

                string[] grantOrganizeIds = null;
                string[] revokeOrganizeIds = null;

                grantOrganizes = string.Empty;
                revokeOrganizes = string.Empty;
                grantOrganizes = ((int)this.GetPermissionScope(this.dtRoleOrganizeScope.Rows[i], out revokeOrganizes)).ToString() + ";";
                if (grantOrganizes.Length > 1)
                {
                    grantOrganizes = grantOrganizes.Substring(0, grantOrganizes.Length - 1);
                    if (grantOrganizes != "0")
                    {
                        grantOrganizeIds = grantOrganizes.Split(';');
                    }
                }
                if (revokeOrganizes.Length > 1)
                {
                    revokeOrganizes = revokeOrganizes.Substring(0, revokeOrganizes.Length - 1);
                    revokeOrganizeIds = revokeOrganizes.Split(';');
                }
                // 设置数据据权限范围
                // Nick Deng 将参数从this.PermissionItemScopeCode改为this.PermissionItemScopeCode
                DotNetService.Instance.PermissionService.GrantRoleOrganizeScopes(UserInfo, targetRoleId, this.PermissionItemScopeCode, grantOrganizeIds);
                if (grantOrganizeIds != null)
                {
                    DotNetService.Instance.PermissionService.RevokeRoleOrganizeScopes(UserInfo, targetRoleId, this.PermissionItemScopeCode, revokeOrganizeIds);
                }
            }
            return true;
        }

        private void btnBatchSave_Click(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                // 批量保存
                if (this.BatchSave())
                {
                    if (BaseSystemInfo.ShowInformation)
                    {
                        // 批量保存，进行提示
                        MessageBox.Show(AppMessage.MSG0011, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                this.ProcessException(ex);
            }
            finally
            {
                // 设置鼠标默认状态，原来的光标状态
                this.Cursor = holdCursor;
            }
        }

        private bool IsANonHeaderButtonCell(DataGridViewCellEventArgs cellEvent)
        {
            if (this.grdRole.Columns[cellEvent.ColumnIndex] is DataGridViewButtonColumn && cellEvent.RowIndex != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void grdRole_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsANonHeaderButtonCell(e))
            {
                string userId = BaseInterfaceLogic.GetDataGridViewEntityId(this.grdRole, BaseUserEntity.FieldId);
                if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(this.TargetPermissionId))
                {
                    FrmRolePermissionScope frmRolePermissionScope = new FrmRolePermissionScope(userId, this.PermissionItemScopeCode);
                    frmRolePermissionScope.ShowDialog(this);
                }
            }
            // 保证只能勾选一个
            else if (this.grdRole.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewCheckBoxCell)
            {
                Boolean bl = Convert.ToBoolean(this.grdRole.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue);
                if (bl)
                {
                    for (int i = 0; i < e.ColumnIndex; i++)
                    {
                        if (this.grdRole.Rows[e.RowIndex].Cells[i] is DataGridViewCheckBoxCell)
                        {
                            this.grdRole.Rows[e.RowIndex].Cells[i].Value = !bl;
                        }
                    }
                    this.grdRole.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = bl;
                    for (int i = e.ColumnIndex + 1; i < grdRole.ColumnCount; i++)
                    {
                        if (this.grdRole.Rows[e.RowIndex].Cells[i] is DataGridViewCheckBoxCell)
                        {
                            this.grdRole.Rows[e.RowIndex].Cells[i].Value = !bl;
                        }
                    }
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 导出Excel
            //string exportFileName = this.Text + ".csv";
            string exportFileName = this.Text + ".xls";
            this.ExportExcel(this.grdRole , @"\Modules\Export\", exportFileName);
        }
    }
}