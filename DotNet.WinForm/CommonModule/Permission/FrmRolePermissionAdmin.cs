//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;
    
    /// <summary>
    /// FrmRolePermissionAdmin.cs
    /// 角色管理-角色管理窗体
    ///	
    /// 修改记录
    /// 
    ///     2011.08.11 版本：2.2 JiRiGaLa  有些系统角色是需要隐藏起来的。    
    ///     2011.05.17 版本：2.1 JiRiGaLa  数据权限完善。    
    ///     2010.09.19 版本：2.0 JiRiGaLa  整理完善代码。    
    ///     2007.06.14 版本：1.8 JiRiGaLa  增加权限判断主键。
    ///     2007.06.05 版本：1.7 JiRiGaLa  整理主键。
    ///     2007.05.31 版本：1.6 JiRiGaLa  主键进行统一整理。
    ///     2007.05.30 版本：1.5 JiRiGaLa  SingleDelete() 进行优化。
    ///     2007.05.30 版本：1.4 JiRiGaLa  删除移动的主键优化，提示信息优化，标准工程完成。
    ///     2007.05.29 版本：1.3 JiRiGaLa  整体整理主键。
    ///     2007.05.17 版本：1.2 JiRiGaLa  增加了多国语言功能，调整了细节部分。
    ///     2007.05.15 版本：1.1 JiRiGaLa  整体进行调试改进。
    ///     2007.05.12 版本：1.0 JiRiGaLa  角色管理功能页面编写。
    ///	
    /// 版本：2.2
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.08.11</date>
    /// </author> 
    /// </summary>
    public partial class FrmRolePermissionAdmin : BaseForm, IBaseForm
    {
        /// <summary>
        /// 本模块的角色用户关联关系管理
        /// </summary>
        private bool permissionRoleUser = false;

        /// <summary>
        /// 本模块的用户角色授权权限
        /// </summary>
        private bool permissionAccredit = false;

        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable DTRole = new DataTable(BaseRoleEntity.TableName);

        /// <summary>
        /// 目标角色主键
        /// </summary>
        public string TargetRoleId
        {
            get
            {
                DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdRole);
                string roleId = dataRow[BaseRoleEntity.FieldId].ToString();
                return roleId;
            }
        }

        /// <summary>
        /// 目标角色名称
        /// </summary>
        public string TargetRoleRealName
        {
            get
            {
                DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdRole);
                string roleRealName = dataRow[BaseRoleEntity.FieldRealName].ToString();
                return roleRealName;
            }
        }

        public event SetControlStateEventHandler OnButtonStateChange;

        private bool OnAdded()
        {
            // 获得角色列表
            this.GetList();
            // 设置数据过滤
            this.SetRowFilter();
            // 设置按钮状态
            this.SetControlState();
            return true;
        }

        /// <summary>
        /// 权限域（范围权限、数据权限）
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        public FrmRolePermissionAdmin()
        {
            InitializeComponent();
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

        /// <summary>
        /// 置顶
        /// </summary>
        public int SetTop()
        {
            return this.ucTableSort.SetTop();
        }

        /// <summary>
        /// 上移
        /// </summary>
        public int SetUp()
        {
            return this.ucTableSort.SetUp();
        }

        /// <summary>
        /// 下移
        /// </summary>
        public int SetDown()
        {
            return this.ucTableSort.SetDown();
        }

        /// <summary>
        /// 置底
        /// </summary>
        public int SetBottom()
        {
            return this.ucTableSort.SetBottom();
        }

        public void SetSortButton(bool enabled)
        {
            this.ucTableSort.SetSortButton(enabled);
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.SetSortButton(false);

            this.btnAdd.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnExport.Enabled = false;
            this.btnBatchDelete.Enabled = false;
            this.btnRolePermission.Enabled = false;
            this.btnRoleUser.Enabled = false;
            this.btnBatchSave.Enabled = false;
            this.btnRoleUserBatchSet.Enabled = false;            
            this.btnFrmRoleTableScope.Enabled = false;
            this.btnFrmTableColumnPermission.Enabled = false;
            this.btnFrmRoleAuthorizationScope.Enabled = false;
            this.btnFrmRoleAdminScope.Enabled = false;
            this.btnBatchPermission.Enabled = false;

            // 检查添加组织机构
            this.btnAdd.Enabled = this.permissionAdd;

            this.btnFrmRoleAdminScope.Visible = BaseSystemInfo.UsePermissionScope;
            this.btnFrmTableColumnPermission.Visible = BaseSystemInfo.UseTableColumnPermission;
            this.btnFrmRoleTableScope.Visible = BaseSystemInfo.UseTableScopePermission;
            // 是否采用了操作权限
            this.btnBatchPermission.Visible = BaseSystemInfo.UsePermissionItem;
            this.btnFrmRoleAuthorizationScope.Visible = BaseSystemInfo.UseAuthorizationScope;
            
            if ((this.DTRole.DefaultView.Count >= 1))
            {
                this.btnEdit.Enabled = this.permissionEdit;
                this.btnExport.Enabled = this.permissionExport;
                this.btnBatchDelete.Enabled = this.permissionDelete;
                this.btnRolePermission.Enabled = this.permissionAccredit;
                this.btnRoleUser.Enabled = this.permissionRoleUser;
                this.btnBatchSave.Enabled = this.permissionEdit;
                this.btnRoleUserBatchSet.Enabled = this.permissionEdit;
                this.btnFrmRoleTableScope.Enabled = this.permissionAccredit;
                this.btnFrmTableColumnPermission.Enabled = this.permissionEdit;
                this.btnFrmRoleAuthorizationScope.Enabled = this.permissionAccredit;
                this.btnFrmRoleAdminScope.Enabled = this.permissionAccredit;                
                this.btnBatchPermission.Enabled = this.permissionAccredit;
            }
            // 位置顺序改变按钮部分
            if (this.DTRole.DefaultView.Count > 1)
            {
                this.SetSortButton(this.permissionEdit);
            }
            if (!this.permissionEdit)
            {
                // 只读属性设置
                this.grdRole.Columns["colSelected"].ReadOnly = !this.permissionEdit;
                this.grdRole.Columns["colEnabled"].ReadOnly = !this.permissionEdit;
                this.grdRole.Columns["colDescription"].ReadOnly = !this.permissionEdit;
                // 修改背景颜色
                this.grdRole.Columns["colEnabled"].DefaultCellStyle.BackColor = Color.White;
                this.grdRole.Columns["colDescription"].DefaultCellStyle.BackColor = Color.White;
            }
            // 用户组是不需要进行权限配置的
            DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdRole);
            if (dataRow != null)
            {
                BaseRoleEntity roleEntity = new BaseRoleEntity(dataRow);
                // 超级管理员没必要设置权限，设置了权限反而增加误解了
                if (roleEntity.Code != null && roleEntity.Code.Equals(DefaultRole.Administrators.ToString()))
                {
                    this.btnEdit.Enabled = false;
                    this.btnRolePermission.Enabled = false;
                    this.btnBatchDelete.Enabled = false;

                    this.btnFrmRoleTableScope.Enabled = false;
                    this.btnFrmTableColumnPermission.Enabled = false;
                    this.btnFrmRoleAuthorizationScope.Enabled = false;
                    this.btnBatchPermission.Enabled = false;
                    this.btnFrmRoleAdminScope.Enabled = false;
                }
                if (((roleEntity.CategoryCode != null) && (roleEntity.CategoryCode.Equals("UserGroup"))))
                {
                    this.btnRolePermission.Enabled = false;
                }
            }
            // 检查委托是否为空
            if (OnButtonStateChange != null)
            {
                bool setTop = this.ucTableSort.SetTopEnabled;
                bool setUp = this.ucTableSort.SetUpEnabled;
                bool setDown = this.ucTableSort.SetDownEnabled;
                bool setBottom = this.ucTableSort.SetBottomEnabled;
                bool add = this.btnAdd.Enabled;
                bool edit = this.btnEdit.Enabled;
                bool batchDelete = this.btnBatchDelete.Enabled;
                bool batchSave = this.btnBatchSave.Enabled;
                OnButtonStateChange(setTop, setUp, setDown, setBottom, add, edit, batchDelete, batchSave);
            }
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            // 这个是范围权限，对哪些（模块）有模块访问的权限？
            // this.permissionAccess = this.IsModuleAuthorized("FrmRoleAdmin");
            this.permissionAccess = this.IsModuleAuthorized(this.Name);
            // 这个可以是范围权限（这里当操作权限处理），对哪些（组织机构、用户、角色）分配权限的范围权限？
            this.permissionAccredit = this.IsAuthorized("UserAdmin.Accredit");

            // 这些是操作权限，当前用户有什么相应的操作权限？
            this.permissionAdd = this.IsAuthorized("RoleAdmin.Add");
            this.permissionEdit = this.IsAuthorized("RoleAdmin.Edit");
            this.permissionExport = this.IsAuthorized("RoleAdmin.Export");
            this.permissionDelete = this.IsAuthorized("RoleAdmin.Delete");
            this.permissionRoleUser = this.IsAuthorized("RoleAdmin.RoleUser");
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            FormOnLoad(true);
        }
        #endregion

        private void FormOnLoad(bool bindItemDetails)
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdRole);
            // 获取分类列表
            if (bindItemDetails)
            {
                this.BindItemDetails();
            }
            // 获得角色列表
            this.GetList();
            // 设置数据过滤
            this.SetRowFilter();
            // 这里是控制只读属性
            for (int i = 0; i < this.grdRole.Rows.Count; i++)
            {
                DataRow dataRow = (this.grdRole.Rows[i].DataBoundItem as DataRowView).Row;
                if (dataRow[BaseRoleEntity.FieldAllowEdit].ToString().Equals("0") || dataRow[BaseRoleEntity.FieldAllowDelete].ToString().Equals("0"))
                {
                    // this.grdRole.Rows[i].Cells["colEnabled"].ReadOnly = true;
                    // this.grdRole.Rows[i].Cells["colDescription"].ReadOnly = true;
                    this.grdRole.Rows[i].Cells[3].ReadOnly = true;
                    this.grdRole.Rows[i].Cells[4].ReadOnly = true;
                }
            }
        }

        #region public override void GetList() 获取角色列表
        /// <summary>
        /// 获取角色列表
        /// </summary>
        public override void GetList()
        {
            // 是否启用了权限范围管理
            this.DTRole = this.GetRoleScope(this.PermissionItemScopeCode);
            this.grdRole.AutoGenerateColumns = false;
            this.DTRole.DefaultView.Sort = BaseRoleEntity.FieldSortCode;
            this.grdRole.DataSource = this.DTRole.DefaultView;
            // 设置排序按钮
            this.ucTableSort.DataBind(this.grdRole, this.permissionEdit);
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
            string rowFilter = string.Empty;
            string search = this.txtSearch.Text.Trim();
            search = StringUtil.GetSearchString(search);
            if (!string.IsNullOrEmpty(search))
            {
                rowFilter =

                    /* BaseRoleEntity.FieldRealName + " LIKE '" + search + "'"
                    + " OR " + BaseRoleEntity.FieldCode + " LIKE '" + search + "'"
                    + " OR " + BaseRoleEntity.FieldDescription + " LIKE '" + search + "'";*/

                StringUtil.GetLike(BaseRoleEntity.FieldRealName, search)
                        + " OR " + StringUtil.GetLike(BaseRoleEntity.FieldCode, search)
                        + " OR " + StringUtil.GetLike(BaseRoleEntity.FieldDescription, search);
            }
            string categoryFilter = this.GetCategoryFilter();
            if (!string.IsNullOrEmpty(categoryFilter))
            {
                if (!string.IsNullOrEmpty(rowFilter))
                {
                    rowFilter = categoryFilter + " AND (" + rowFilter + ") ";
                }
                else
                {
                    rowFilter = categoryFilter;
                }
            }
            this.DTRole.DefaultView.RowFilter = rowFilter;
        }
        #endregion

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.SetRowFilter();
        }

        private void btnFrmRoleAuthorizationScope_Click(object sender, EventArgs e)
        {
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmRoleAuthorizationScope";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmRoleAuthorizationScope = (Form)Activator.CreateInstance(assemblyType, this.TargetRoleId);
            frmRoleAuthorizationScope.ShowDialog(this);
        }

        private void btnRoleUserBatchSet_Click(object sender, EventArgs e)
        {
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmRoleUserBatchSet";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmRolePermissionScopes = (Form)Activator.CreateInstance(assemblyType);
            frmRolePermissionScopes.ShowDialog(this);
        }

        private void btnFrmRoleAdminScope_Click(object sender, EventArgs e)
        {
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmRoleOrganizeScope";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserPermissionAdmin = (Form)Activator.CreateInstance(assemblyType, this.PermissionItemScopeCode);
            frmUserPermissionAdmin.ShowDialog(this);
        }

        private void btnFrmRoleOrganizeScope_Click(object sender, EventArgs e)
        {
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmTableScope";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserPermissionAdmin = (Form)Activator.CreateInstance(assemblyType, BaseRoleEntity.TableName, this.TargetRoleId);
            frmUserPermissionAdmin.ShowDialog(this);
        }

        private void btnFrmTableColumnPermission_Click(object sender, EventArgs e)
        {
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmTableColumnPermission";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmTableColumnPermission = (Form)Activator.CreateInstance(assemblyType, BaseRoleEntity.TableName, this.TargetRoleId);
            frmTableColumnPermission.ShowDialog(this);
        }

        private void btnBatchPermission_Click(object sender, EventArgs e)
        {
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmRolePermissionBatchSet";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserPermissionAdmin = (Form)Activator.CreateInstance(assemblyType, this.PermissionItemScopeCode);
            frmUserPermissionAdmin.ShowDialog(this);
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

        private void grdRole_Sorted(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (this.permissionEdit)
            {
                string[] sequence = DotNetService.Instance.SequenceService.GetBatchSequence(UserInfo, BaseRoleEntity.TableName, this.DTRole.DefaultView.Count);
                int i = 0;
                foreach (DataRowView dataRowView in this.DTRole.DefaultView)
                {
                    dataRowView.Row[BaseRoleEntity.FieldSortCode] = sequence[i];
                    i++;
                }
                // 控制导航按钮
                this.SetSortButton(false);
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }

        private void grdRole_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
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
            //        RoleAdminService.Instance.Delete(this.UserInfo, this.EntityId);
            //    }
            //}
        }

        private void grdRole_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnRolePermission.PerformClick();
        }

        #region private string[] GetSelecteIds() 获得已被选择的部门主键数组
        /// <summary>
        /// 获得已被选择的部门主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelecteIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdRole, BaseRoleEntity.FieldId, "colSelected", true);
        }
        #endregion

        private void grdRole_SelectionChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                // 设置按钮状态
                this.SetControlState();
            }
        }

        #region public string Add() 添加角色
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <returns>主键</returns>
        public string Add()
        {
            string returnValue = string.Empty;
            //string assemblyName = "DotNet.WinForm";
            //string formName = "FrmRoleAdd";
            //Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            //BaseForm frmRoleAdd = (BaseForm)Activator.CreateInstance(assemblyType, this.cmbRoleCategory.SelectedValue.ToString());
            FrmRoleWithUser frmRoleWithUser = new FrmRoleWithUser(this.cmbRoleCategory.SelectedValue.ToString());
            frmRoleWithUser.OnAdded += new FrmRoleWithUser.OnAddedEventHandler(this.OnAdded);
            if (frmRoleWithUser.ShowDialog(this) == DialogResult.OK || frmRoleWithUser.Changed)
            {
                // 获得角色列表
                this.GetList();
                // 设置数据过滤
                this.SetRowFilter();
                // 设置按钮状态
                this.SetControlState();
            }
            return returnValue;
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Add();
        }

        public void Edit()
        {
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmRoleEdit";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            BaseForm frmRoleEdit = (BaseForm)Activator.CreateInstance(assemblyType, this.TargetRoleId);
            if (frmRoleEdit.ShowDialog(this) == DialogResult.OK && frmRoleEdit.Changed)
            {
                this.FormOnLoad(false);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Edit();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 导出Excel
            //string exportFileName = this.Text + ".csv";
            string exportFileName = this.Text + ".xls";
            this.ExportExcel(this.grdRole , @"\Modules\Export\", exportFileName);
        }

        #region public override int BatchDelete() 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <returns>影响行数</returns>
        public override int BatchDelete()
        {
            // 这个是直接在数据库里删除的方法
            // int returnValue = DotNetService.Instance.RoleService.BatchDelete(this.UserInfo, this.GetSelecteIds());
            // 这个是只打上删除标记的方法
            return DotNetService.Instance.RoleService.SetDeleted(this.UserInfo, this.GetSelecteIds());
        }
        #endregion

        #region public override bool CheckInput() 检查批量删除
        /// <summary>
        /// 检查批量删除
        /// </summary>
        /// <returns>允许删除</returns>
        public override bool CheckInput()
        {
            bool returnValue = true;
            foreach (DataGridViewRow dgvRow in grdRole.Rows)
            {
                DataRow dataRow = (dgvRow.DataBoundItem as DataRowView).Row;
                if ((System.Boolean)(dgvRow.Cells["colSelected"].Value??false))
                {
                    BaseRoleEntity roleEntity = new BaseRoleEntity(dataRow);
                    if (roleEntity.AllowDelete == 0)
                    {
                        // 有不允许删除的数据
                        MessageBox.Show(AppMessage.Format(AppMessage.MSG0018, roleEntity.RealName), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        returnValue = false;
                        break;
                    }
                }
            }

            //foreach (DataRowView dataRowView in this.DTRole.DefaultView)
            //{
            //    if (dataRowView.Row[BaseBusinessLogic.SelectedColumn].ToString().ToUpper().Equals(true.ToString().ToUpper()))
            //    {
            //        BaseRoleEntity roleEntity = new BaseRoleEntity(dataRowView.Row);
            //        if (roleEntity.AllowDelete == 0)
            //        {
            //            // 有不允许删除的数据
            //            MessageBox.Show(AppMessage.Format(AppMessage.MSG0018, roleEntity.RealName), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            returnValue = false;
            //            break;
            //        }
            //    }
            //}
            return returnValue;
        }
        #endregion

        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete()
        {
            int returnValue = 0;
            // 检查至少要选择一个？
            if (!BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdRole, "colSelected"))
            {
                return returnValue;
            }
            // 检查是否有不允许删除的数据？
            if (!this.CheckInput())
            {
                return returnValue;
            }
            // 是否确认删除了？
            if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
            {
                return returnValue;
            }
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.btnBatchDelete.Enabled = false;
                returnValue = this.BatchDelete();
                // 重新加载数据，先刷新屏幕，再显示提示信息
                this.FormOnLoad(false);
                // 是否需要有提示信息？
                if (BaseSystemInfo.ShowInformation)
                {
                    // 批量保存，进行提示
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0077, returnValue.ToString()), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            return returnValue;
        }

        private void btnBatchDelete_Click(object sender, EventArgs e)
        {
            // 删除数据
            this.Delete();
        }

        protected virtual void btnPermission_Click(object sender, EventArgs e)
        {
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmRolePermission";
            if (!BaseSystemInfo.UsePermissionItem)
            {
                formName = "FrmRoleModulePermission";
            }
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserPermissionAdmin = (Form)Activator.CreateInstance(assemblyType, this.TargetRoleId, this.TargetRoleRealName);
            frmUserPermissionAdmin.ShowDialog(this);
        }

        private void btnRoleUser_Click(object sender, EventArgs e)
        {
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmRoleUserAdmin";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmRoleUserAdmin = (Form)Activator.CreateInstance(assemblyType, this.TargetRoleId, this.TargetRoleRealName);
            frmRoleUserAdmin.ShowDialog(this);
        }

        #region private int BatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private int BatchSave()
        {
            this.btnBatchSave.Enabled = false;
            int returnValue = 0;
            // 这里需要把没有变动的数据删除掉，这样可以提高效率
            // 去掉未修改的数据，提高运行速度
            for (int i = this.DTRole.Rows.Count - 1; i >= 0; i--)
            {
                if (this.DTRole.Rows[i].RowState == DataRowState.Unchanged)
                {
                    this.DTRole.Rows.RemoveAt(i);
                }
            }
            // 泛型化
            List<BaseRoleEntity> roleEntites = new List<BaseRoleEntity>();
            for (int i = 0; i < this.DTRole.Rows.Count; i++)
            {
                BaseRoleEntity roleEntity = new BaseRoleEntity(this.DTRole.Rows[i]);
                roleEntites.Add(roleEntity);
            }
            // 调用后台的批量保存功能
            returnValue = DotNetService.Instance.RoleService.BatchSave(this.UserInfo, roleEntites);
            // 绑定屏幕数据
            this.FormOnLoad(false);
            if (BaseSystemInfo.ShowInformation)
            {
                // 批量保存，进行提示
                MessageBox.Show(AppMessage.MSG0011, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return returnValue;
        }
        #endregion

        public void Save()
        {
            // 检查批量输入的有效性
            if (BaseInterfaceLogic.CheckInputModifyAnyOne(this.DTRole))
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    // 批量保存
                    this.BatchSave();

                    // 2012.05.12 Pcsky
                    // 更新datatable的状态，解决无法二次修改的问题
                    this.DTRole.AcceptChanges();
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

        private void btnBatchSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmRoleAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BaseInterfaceLogic.IsModfiedAnyOne(this.DTRole))
            {
                // 数据有变动是否保存的提示
                DialogResult dialogResult = MessageBox.Show(AppMessage.MSG0045, AppMessage.MSG0000, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
                if (dialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else if (dialogResult == DialogResult.Yes)
                {
                    // 保存数据
                    this.BatchSave();
                }
            }
        }
    }
}