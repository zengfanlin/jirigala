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
    /// FrmUserOrganizeScope.cs
    /// 用户数据权限范围设置
    ///		
    /// 修改记录
    /// 
    ///     2012.05.09 版本：2.0 JiRiGaLa  优化无权限的功能实现。
    ///     2010.12.08 版本：1.0 JiRiGaLa  模块配置。
    ///		
    /// 版本：2.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.05.09</date>
    /// </author> 
    /// </summary>
    public partial class FrmUserOrganizeScope : BaseForm
    {
        public FrmUserOrganizeScope()
        {
            InitializeComponent();
        }

        public FrmUserOrganizeScope(string permissionItemScopeCode) : this()
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
        DataTable dtUserOrganizeScope = new DataTable(BaseUserEntity.TableName);

        private void ucPermissionScope_SelectedIndexChanged(string selectedId)
        {
            BasePermissionItemEntity permissionItemEntity = DotNetService.Instance.PermissionItemService.GetEntity(this.UserInfo, selectedId);
            if (permissionItemEntity != null)
            {
                this.TargetPermissionId = permissionItemEntity.Id.ToString();
                this.PermissionItemScopeCode = permissionItemEntity.Code;
                this.GetUserOrganizeScope();
            }
        }

        public override void SetControlState()
        {
            this.btnBatchSave.Enabled = false;
            if (this.dtUserOrganizeScope.Rows.Count > 0)
            {
                this.btnBatchSave.Enabled = true;
            }
        }

        private void GetUserOrganizeScope()
        {
            // 1.获取角色列表
            // 自己能管理的角色列表才对，是否启用了权限范围管理
            dtUserOrganizeScope = this.GetUserScope(this.PermissionItemScopeCode);
            // 去掉超级管理员
            for (int i = 0; i < dtUserOrganizeScope.Rows.Count; i++)
            {
                if (dtUserOrganizeScope.Rows[i][BaseUserEntity.FieldCode].ToString().Equals(DefaultRole.Administrator.ToString()))
                {
                    dtUserOrganizeScope.Rows[i].Delete();
                    break;
                }
            }
            dtUserOrganizeScope.AcceptChanges();
            foreach (DataRow dataRow in dtUserOrganizeScope.Rows)
            {
                dataRow[BaseUserEntity.FieldRealName] = dataRow[BaseUserEntity.FieldUserName] + " [" + dataRow[BaseUserEntity.FieldRealName] + "]";
            }
            dtUserOrganizeScope.AcceptChanges();
            
            // 2.设置数据权限范围的列
            dtUserOrganizeScope.Columns.Add("colAll", typeof(bool));
            dtUserOrganizeScope.Columns.Add("colUserCompany", typeof(bool));
            dtUserOrganizeScope.Columns.Add("colUserSubCompany", typeof(bool));
            dtUserOrganizeScope.Columns.Add("colUserDepartment", typeof(bool));
            dtUserOrganizeScope.Columns.Add("colUserWorkgroup", typeof(bool));
            dtUserOrganizeScope.Columns.Add("colUser", typeof(bool));
            dtUserOrganizeScope.Columns.Add("colNone", typeof(bool));
            dtUserOrganizeScope.Columns.Add("colDetail", typeof(bool));

            // 3.获取数据权限
            // 4.绑定数据
            string targetUserId = string.Empty;
            for (int i = 0; i < dtUserOrganizeScope.Rows.Count; i++)
            {
                targetUserId = this.dtUserOrganizeScope.Rows[i][BaseUserEntity.FieldId].ToString();
                // Nick Deng 将参数从this.PermissionItemScopeCode改为this.PermissionItemScopeCode
                string[] organizeIds = DotNetService.Instance.PermissionService.GetUserScopeOrganizeIds(UserInfo, targetUserId, this.PermissionItemScopeCode);
                if (StringUtil.Exists(organizeIds, ((int)PermissionScope.None).ToString()))
                {
                    // dtUserOrganizeScope.Rows[i]["colNone"] = true;
                }
                if (StringUtil.Exists(organizeIds, ((int)PermissionScope.Detail).ToString()))
                {
                    dtUserOrganizeScope.Rows[i]["colDetail"] = true;
                }
                if (StringUtil.Exists(organizeIds, ((int)PermissionScope.User).ToString()))
                {
                    dtUserOrganizeScope.Rows[i]["colUser"] = true;
                }
                if (StringUtil.Exists(organizeIds, ((int)PermissionScope.UserWorkgroup).ToString()))
                {
                    dtUserOrganizeScope.Rows[i]["colUserWorkgroup"] = true;
                }
                if (StringUtil.Exists(organizeIds, ((int)PermissionScope.UserDepartment).ToString()))
                {
                    dtUserOrganizeScope.Rows[i]["colUserDepartment"] = true;
                }
                if (StringUtil.Exists(organizeIds, ((int)PermissionScope.UserSubCompany).ToString()))
                {
                    dtUserOrganizeScope.Rows[i]["colUserSubCompany"] = true;
                }
                if (StringUtil.Exists(organizeIds, ((int)PermissionScope.UserCompany).ToString()))
                {
                    dtUserOrganizeScope.Rows[i]["colUserCompany"] = true;
                }
                if (StringUtil.Exists(organizeIds, ((int)PermissionScope.All).ToString()))
                {
                    dtUserOrganizeScope.Rows[i]["colAll"] = true;
                }
            }

            // 5.表格绑定数据
            dtUserOrganizeScope.DefaultView.Sort = BaseUserEntity.FieldSortCode;
            this.grdUser.DataSource = dtUserOrganizeScope.DefaultView;

            // 6.设置排序按钮
            this.ucTableSort.DataBind(this.grdUser);

            // 设置数据过滤
            this.SetRowFilter();
            this.SetControlState();
        }

        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdUser);
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
            this.grdUser.AutoGenerateColumns = false;
            this.GetUserOrganizeScope();
            this.SetControlState();
        }

        private void SetRowFilter()
        {
            string search = this.txtSearch.Text.Trim();
            if (String.IsNullOrEmpty(search))
            {
                this.dtUserOrganizeScope.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                if (this.dtUserOrganizeScope.Columns.Count > 1)
                {
                    search = StringUtil.GetSearchString(search);
                    this.dtUserOrganizeScope.DefaultView.RowFilter =

                        /* BaseUserEntity.FieldUserName + " LIKE '" + search + "'"
                        + " OR " + BaseUserEntity.FieldRealName + " LIKE '" + search + "'"
                        + " OR " + BaseUserEntity.FieldCode + " LIKE '" + search + "'"
                        + " OR " + BaseUserEntity.FieldDepartmentName + " LIKE '" + search + "'"
                        + " OR " + BaseUserEntity.FieldDescription + " LIKE '" + search + "'";*/

                        StringUtil.GetLike(BaseUserEntity.FieldUserName, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldRealName, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldCode, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldDepartmentName, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldDescription, search);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // 设置数据过滤
            this.SetRowFilter();
            // 设置按钮状态
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
            string targetUserId = string.Empty;
            for (int i = 0; i < this.dtUserOrganizeScope.Rows.Count; i++)
            {
                targetUserId = this.dtUserOrganizeScope.Rows[i][BaseUserEntity.FieldId].ToString();
                
                string[] grantOrganizeIds = null;
                string[] revokeOrganizeIds = null;

                grantOrganizes = string.Empty;
                revokeOrganizes = string.Empty;
                grantOrganizes = ((int)this.GetPermissionScope(this.dtUserOrganizeScope.Rows[i], out revokeOrganizes)).ToString() + ";";
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
                DotNetService.Instance.PermissionService.GrantUserOrganizeScopes(UserInfo, targetUserId, this.PermissionItemScopeCode, grantOrganizeIds);
                if (grantOrganizeIds != null)
                {
                    DotNetService.Instance.PermissionService.RevokeUserOrganizeScopes(UserInfo, targetUserId, this.PermissionItemScopeCode, revokeOrganizeIds);
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
            if (this.grdUser.Columns[cellEvent.ColumnIndex] is DataGridViewButtonColumn && cellEvent.RowIndex != -1)
            { 
                return true; 
            }
            else 
            {
                return false;
            }
        }

        private void grdUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsANonHeaderButtonCell(e))
            {
                string userId = BaseInterfaceLogic.GetDataGridViewEntityId(this.grdUser, BaseUserEntity.FieldId);
                if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(this.TargetPermissionId))
                {
                    FrmUserPermissionScope frmUserPermissionScope = new FrmUserPermissionScope(userId, this.PermissionItemScopeCode);
                    frmUserPermissionScope.ShowDialog(this);
                }
            }
            // 保证只能勾选一个
            else if (this.grdUser.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewCheckBoxCell)
            {
                Boolean bl = Convert.ToBoolean(this.grdUser.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue);
                if (bl)
                {
                    this.grdUser.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = bl;
                    dtUserOrganizeScope.Rows[e.RowIndex]["colDetail"] = false; //勾选其他选项后Detail项为false
                    for (int i = 0; i < e.ColumnIndex; i++)
                    {
                        if (this.grdUser.Rows[e.RowIndex].Cells[i] is DataGridViewCheckBoxCell)
                        {
                            this.grdUser.Rows[e.RowIndex].Cells[i].Value = !bl;
                        }
                    }
                    for (int i = e.ColumnIndex + 1; i < grdUser.ColumnCount; i++)
                    {
                        if (this.grdUser.Rows[e.RowIndex].Cells[i] is DataGridViewCheckBoxCell)
                        {
                            this.grdUser.Rows[e.RowIndex].Cells[i].Value = !bl;
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
            this.ExportExcel(this.grdUser , @"\Modules\Export\", exportFileName);
        }
    }
}