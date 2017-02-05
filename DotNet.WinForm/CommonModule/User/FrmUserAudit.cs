//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using System.Drawing;
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FrmUserAudit.cs
    /// 用户管理-管理用户窗体
    ///		
    /// 修改记录
    /// 
    ///     2012.05.03 版本：1.2 Pcsky     加入列：创建日期，便于查看最新的注册用户
    ///     2008.04.21 版本：1.1 JiRiGaLa  已审核1；未审核0；已退回-1状态确认。
    ///     2007.07.07 版本：1.0 JiRiGaLa  建立主键。
    ///		
    /// 版本：1.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.04.21</date>
    /// </author> 
    /// </summary> 
    public partial class FrmUserAudit : BaseForm
    {
        private DataTable DTUser = new DataTable(BaseUserEntity.TableName);   // 用户
        private bool isPass = true;

        private bool permissionPass = false;    // 通过审核
        private bool permissionReject = false;    // 退回权限
        private bool permissionAccredit = false;        // 用户授权

        public override string EntityId
        {
            get
            {
                return BaseInterfaceLogic.GetDataGridViewEntityId(this.grdUser, BaseUserEntity.FieldId);
            }
        }

        private string entityId = string.Empty;

        public string CurrentEntityId
        {
            get
            {
                return this.entityId;
            }
            set
            {
                this.entityId = value;
            }
        }

        public FrmUserAudit()
        {

            InitializeComponent();
            Init();
        }

        /// <summary>
        /// 修改：通过事件委托调用方法
        /// </summary>
        public void Init()
        {
            this.grdUser.RowPrePaint += new DataGridViewRowPrePaintEventHandler(this.grdUser_RowPrePaint);
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnSearch.Enabled = false;
            this.txtSearch.Enabled = false;
            this.btnSelectAll.Enabled = false;
            this.btnInvertSelect.Enabled = false;
            this.btnPass.Enabled = false;
            this.btnReject.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnExport.Enabled = false;
            // this.btnUserPermission.Enabled = false;

            if (this.DTUser.DefaultView.Count > 0)
            {
                this.btnSelectAll.Enabled = this.permissionDelete;
                this.btnInvertSelect.Enabled = this.permissionDelete;

                // 是否有编辑权限
                this.btnPass.Enabled = this.permissionPass;
                this.btnReject.Enabled = this.permissionReject;
                this.btnEdit.Enabled = this.permissionEdit;
                // this.btnUserPermission.Enabled = this.permissionAccredit;
                this.btnExport.Enabled = this.permissionExport;
                // 是否有删除权限
                this.btnDelete.Enabled = this.permissionDelete;
            }

            this.btnSearch.Enabled = this.permissionSearch;
            this.txtSearch.Enabled = this.permissionSearch;
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAccess = this.IsModuleAuthorized("UserAudit");
            this.permissionSearch = this.IsAuthorized("UserAudit.Search");
            this.permissionPass = this.IsAuthorized("UserAudit.Pass");
            this.permissionReject = this.IsAuthorized("UserAudit.Reject");
            this.permissionEdit = this.IsAuthorized("UserAudit.Edit");
            this.permissionExport = this.IsAuthorized("UserAudit.Export");
            this.permissionDelete = this.IsAuthorized("UserAudit.Delete");
            this.permissionAccredit = this.IsAuthorized("UserAdmin.Accredit");
        }
        #endregion

        #region private void BindItemDetails() 绑定下拉筐数据
        /// <summary>
        /// 绑定下拉筐数据
        /// </summary>
        private void BindItemDetails()
        {
            // 绑定审核数据
            DataTable dtItemDetails = DotNetService.Instance.ItemDetailsService.GetDataTableByCode(UserInfo, "AuditStatus");
            DataRow dataRow = dtItemDetails.NewRow();
            dtItemDetails.Rows.InsertAt(dataRow, 0);
            this.cmbUserAuditStates.DisplayMember = BaseItemDetailsEntity.FieldItemName;
            this.cmbUserAuditStates.ValueMember = BaseItemDetailsEntity.FieldItemValue;
            this.cmbUserAuditStates.DataSource = dtItemDetails.DefaultView;

            // 添加一个空记录
            DataTable dataTable = DotNetService.Instance.RoleService.GetDefaultRoleDT(UserInfo);
            dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbRole.DisplayMember = BaseRoleEntity.FieldRealName;
            this.cmbRole.ValueMember = BaseRoleEntity.FieldId;
            this.cmbRole.DataSource = dataTable.DefaultView;
        }
        #endregion

        #region private void BindData() 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        private void BindData()
        {
            if (!this.DTUser.Columns.Contains("AuditStates"))
            {
                this.DTUser.Columns.Add("AuditStates", string.Empty.GetType());
            }
            foreach (DataRow dataRow in this.DTUser.Rows)
            {
                if (dataRow[BaseUserEntity.FieldAuditStatus].ToString().Equals(AuditStatus.WaitForAudit.ToString()))
                {
                    dataRow["AuditStates"] = "待审核";
                }
                else
                {
                    if (dataRow[BaseUserEntity.FieldAuditStatus].ToString().Equals(AuditStatus.AuditPass.ToString()))
                    {
                        dataRow["AuditStates"] = "已审核";
                    }
                    else
                    {
                        if (dataRow[BaseUserEntity.FieldAuditStatus].ToString().Equals(AuditStatus.AuditReject.ToString()))
                        {
                            dataRow["AuditStates"] = "已退回";
                        }
                    }
                }
            }
            this.grdUser.AutoGenerateColumns = false;
            this.grdUser.DataSource = this.DTUser.DefaultView;
            this.grdUser.Refresh();
            if (this.CurrentEntityId.Length > 0)
            {
                this.grdUser.FirstDisplayedScrollingRowIndex = BaseInterfaceLogic.GetRowIndex(this.DTUser, BaseUserEntity.FieldId, this.CurrentEntityId);
            }
            // 判断编辑权限
            if (!this.permissionDelete)
            {
                // 只读属性设置
                // this.grdUser.Columns["colSelected"].ReadOnly = !this.permissionDelete || this.permissionEdit || this.permissionPass || this.permissionReject;
                this.btnSelectAll.Enabled = false;
                this.btnInvertSelect.Enabled = false;
            }
            // 设置按钮状态
            this.SetControlState();
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdUser);
            // 绑定下拉筐数据
            this.BindItemDetails();
            // 获取用户数据，默认显示待审核数据
            this.DTUser = DotNetService.Instance.UserService.Search(UserInfo, this.txtSearch.Text, AuditStatus.WaitForAudit.ToString(), null);
            // 绑定屏幕数据
            this.BindData();
        }
        #endregion

        #region private void EntityToDataTable() 转换数据
        /// <summary>
        /// 转换数据
        /// </summary>
        private void EntityToDataTable()
        {
            DataRow dataRow = this.DTUser.Rows[0];
            dataRow[BaseUserEntity.FieldEnabled] = this.isPass ? 1 : 0;
            this.DTUser.AcceptChanges();
        }
        #endregion

        #region private void DoSearch() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        private void DoSearch()
        {
            string userName = this.txtSearch.Text.ToString();
            string auditStates = this.cmbUserAuditStates.SelectedValue.ToString();
            string[] roleIds = (this.cmbRole.SelectedValue.ToString().Length == 0) ? null : new string[] { this.cmbRole.SelectedValue.ToString() };
            // 用户信息
            this.DTUser = DotNetService.Instance.UserService.Search(UserInfo, userName, auditStates, roleIds);
            this.BindData();
        }
        #endregion

        private void FrmUserAudit_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 116:
                    // 点击了F5按钮
                    this.FormOnLoad();
                    break;
            }
        }

        private void grdUserManagement_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // 判断是否有删除权限
            //if (!this.permissionDelete)
            //{
            //    e.Cancel = true;
            //    return;
            //}
            //else
            //{
            //    if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            //    {
            //        e.Cancel = true;
            //    }
            //    else
            //    {
            //        UserManagementService.Instance.Delete(UserInfo, this.EntityId);
            //    }
            //}
        }

        private void grdUserManagement_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnEdit.PerformClick();
        }

        private void grdUser_SelectionChanged(object sender, EventArgs e)
        {
            // 选择行时候判断是不是没有审核的数据
            // grdUser.CurrentRow.Cells["审核"].Value.ToString();

            // string AuditStates = grdUser.Rows[grdUser.CurrentCell.RowIndex].Cells["AuditStates"].Value.ToString();
            // MessageBox.Show(AuditStates);
            // 
            // if (AuditStates == "已审核")
            //     btnPass.Enabled = false;
            // else
            //     btnPass.Enabled = true;

        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dgvRow in grdUser.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }
            //foreach (DataRow dataRow in this.DTUser.Rows)
            //{
            //    dataRow["colSelected"] = true.ToString();
            //}
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in grdUser.Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false);
            }

            //foreach (DataRow dataRow in this.DTUser.Rows)
            //{
            //    if (dataRow["colSelected"].ToString() == true.ToString())
            //    {
            //        dataRow["colSelected"] = false.ToString();
            //    }
            //    else
            //    {
            //        dataRow["colSelected"] = true.ToString();
            //    }
            //}
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = this.txtSearch.Text.Trim();
            if (String.IsNullOrEmpty(search))
            {
                this.DTUser.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                search = StringUtil.GetSearchString(search);
                this.DTUser.DefaultView.RowFilter =

                    /*BaseUserEntity.FieldUserName + " LIKE '" + search + "'"
                    + " OR " + BaseUserEntity.FieldRealName + " LIKE '" + search + "'"
                     + " OR " + BaseUserEntity.FieldCompanyName + " LIKE '" + search + "'"
                    + " OR " + BaseUserEntity.FieldDepartmentName + " LIKE '" + search + "'"
                     + " OR " + BaseUserEntity.FieldWorkgroupName + " LIKE '" + search + "'"
                    + " OR " + BaseUserEntity.FieldDescription + " LIKE '" + search + "'"*/

                    StringUtil.GetLike(BaseUserEntity.FieldUserName, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldRealName, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldCompanyName, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldDepartmentName, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldWorkgroupName, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldDescription, search)

                    + " OR RoleName LIKE '" + search + "'";
            }
            // 设置按钮状态
            this.SetControlState();
            // 焦点不要离开这个控件哦
            this.txtSearch.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.DoSearch();
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

        #region private void Pass() 通过
        /// <summary>
        /// 通过
        /// </summary>
        private void AuditPass()
        {
            DotNetService.Instance.UserService.SetUserAuditStates(UserInfo, this.GetSelectIds(), AuditStatus.AuditPass);
        }
        #endregion

        private void btnPass_Click(object sender, EventArgs e)
        {
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdUser, "colSelected"))
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                if (MessageBox.Show(AppMessage.MSG0041, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        this.AuditPass();
                        this.DoSearch();
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
            }
        }

        #region private void AuditReject() 退回
        /// <summary>
        /// 退回
        /// </summary>
        private void AuditReject()
        {
            DotNetService.Instance.UserService.SetUserAuditStates(UserInfo, this.GetSelectIds(), AuditStatus.AuditReject);
        }
        #endregion

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdUser, "colSelected"))
            {
                if (MessageBox.Show(AppMessage.MSG0042, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    // 设置鼠标繁忙状态，并保留原先的状态
                    Cursor holdCursor = this.Cursor;
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        this.AuditReject();
                        this.DoSearch();
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
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = BaseInterfaceLogic.GetDataGridViewEntityId(this.grdUser, BaseUserEntity.FieldId);
            FrmAccountEdit frmAccountEdit = new FrmAccountEdit(id);
            if (frmAccountEdit.ShowDialog(this) == DialogResult.OK)
            {
                // 获得用户列表
                this.DoSearch();
            }
        }

        private void btnPermission_Click(object sender, EventArgs e)
        {
            DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdUser);
            string id = dataRow[BaseRoleEntity.FieldId].ToString();
            string fullName = dataRow[BaseRoleEntity.FieldRealName].ToString();

            // 用反射获得窗体
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmUserPermission";
            Type type = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserPermissionAdmin = (Form)Activator.CreateInstance(type, id, fullName);
            frmUserPermissionAdmin.ShowDialog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 导出Excel
            string exportFileName = this.Text + ".xls";
            this.ExportExcel(this.grdUser, @"\Modules\Export\", exportFileName);
        }

        #region private string[] GetSelectIds() 选种的用户Id数组
        /// <summary>
        /// 选种的用户Id数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelectIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdUser, BaseUserEntity.FieldId, "colSelected", true);
        }
        #endregion

        #region public override int BatchDelete() 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        public override int BatchDelete()
        {
            return DotNetService.Instance.UserService.BatchDelete(UserInfo, this.GetSelectIds());
        }
        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdUser, "colSelected"))
            {
                if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    // 设置鼠标繁忙状态，并保留原先的状态
                    Cursor holdCursor = this.Cursor;
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        this.BatchDelete();
                        this.DoSearch();
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
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbUserAuditStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                this.DoSearch();
            }
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                this.DoSearch();
            }
        }

        private void grdUser_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridViewRow dgr = grdUser.Rows[e.RowIndex];
            try
            {
                if (dgr.Cells["colAudited"].Value.ToString() == "已审核")
                {
                    dgr.DefaultCellStyle.ForeColor = Color.Green;

                }
                else if (dgr.Cells["colAudited"].Value.ToString() == "待审核")
                {
                    dgr.DefaultCellStyle.ForeColor = Color.Blue;
                }
                else if (dgr.Cells["colAudited"].Value.ToString() == "已退回")
                {
                    dgr.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}