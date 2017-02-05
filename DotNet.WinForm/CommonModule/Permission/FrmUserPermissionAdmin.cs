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
    /// FrmUserPermissionAdmin.cs
    /// 后台管理-用户管理窗体
    ///		
    /// 修改记录
    ///     
    ///     2008.04.05 版本：1.1 JiRiGaLa 整理调试程序，删除多余主键。
    ///     2007.07.02 版本：1.0 JiRiGaLa 用户管理功能页面编写。
    ///		
    /// 版本：1.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.04.05</date>
    /// </author> 
    /// </summary>
    public partial class FrmUserPermissionAdmin : BaseForm
    {
        /// <summary>
        /// 用户管理
        /// </summary>
        private DataTable DTUser = new DataTable(BaseUserEntity.TableName);

        /// <summary>
        /// 组织机构 DataTable
        /// </summary>
        private DataTable DTOrganize = new DataTable(BaseOrganizeEntity.TableName);

        /// <summary>
        /// 组织机构 DataTable
        /// </summary>
        private DataTable DTOrganizeList = new DataTable(BaseOrganizeEntity.TableName); 

        /// <summary>
        /// 用户授权
        /// </summary>
        private bool permissionAccredit = false;

        /// <summary>
        /// 用户属性
        /// </summary>
        private bool permissionProperty = false;

        /// <summary>
        /// 设置密码
        /// </summary>
        private bool permissionSetPassword = false;

        /// <summary>
        /// 2011-03-17
        /// 权限域编号(按权限管理范围来列出数据才可以，只能管理这个范围的数据)
        /// </summary>
        public string PermissionItemScopeCode = "Resource.ManagePermission";

        public FrmUserPermissionAdmin()
        {
            InitializeComponent();
        }

        private bool OnAdded()
        {
            // 加载窗体
            this.FormOnLoad(BaseSystemInfo.LoadAllUser);
            // 设置按钮状态
            this.SetControlState();
            return true;
        }

        private void grdUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnPermission.PerformClick();
        }

        #region public override string EntityId 用户主键
        /// <summary>
        /// 用户主键
        /// </summary>
        public override string EntityId
        {
            get
            {
                return BaseInterfaceLogic.GetDataGridViewEntityId(this.grdUser, BaseUserEntity.FieldId);
            }
        }
        #endregion

        #region public string CurrentEntityId 当前选种的ID
        /// <summary>
        /// 当前选种的ID
        /// </summary>
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
        #endregion

        #region public override void SetHelp() 设置帮助信息
        /// <summary>
        /// 设置帮助信息
        /// </summary>
        public override void SetHelp()
        {
            this.HelpButton = true;
        }
        #endregion

        #region public override void GetPermission() 获得权限
        /// <summary>
        /// 获得权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAccess = this.IsModuleAuthorized("UserPermissionAdmin");
            this.permissionSearch = this.IsAuthorized("UserPermissionAdmin.Search");
            this.permissionAdd = this.IsAuthorized("UserPermissionAdmin.Add");
            this.permissionProperty = this.IsAuthorized("UserPermissionAdmin.Property");
            this.permissionSetPassword = this.IsAuthorized("UserPermissionAdmin.SetPassword");
            this.permissionExport = this.IsAuthorized("UserPermissionAdmin.Export");
            this.permissionDelete = this.IsAuthorized("UserPermissionAdmin.Delete");
            this.permissionAccredit = this.IsAuthorized("UserPermissionAdmin.Accredit");
        }
        #endregion

        #region public override void SetControlState() 按钮的状态设置
        /// <summary>
        /// 按钮的状态设置
        /// </summary>
        public override void SetControlState()
        {
            this.btnSearch.Visible = !BaseSystemInfo.LoadAllUser;

            this.btnProperty.Enabled = false;
            this.btnPermission.Enabled = false;
            this.btnSetPassword.Enabled = false;
            this.btnUserRole.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnExport.Enabled = false;
            this.btnUserOrganizeScope.Enabled = false;
            this.btnUseAuthorizationScope.Enabled = false;
            this.btnFrmUserTableScope.Enabled = false;
            this.btnFrmTableColumnPermission.Enabled = false;
            this.btnRoleUserBatchSet.Enabled = false;
            this.btnUserOrganizeScope.Enabled = false;
            this.btnBatchPermission.Enabled = false;

            this.btnUserOrganizeScope.Visible = BaseSystemInfo.UsePermissionScope && BaseSystemInfo.UseUserPermission;
            this.btnBatchPermission.Visible = BaseSystemInfo.UsePermissionScope && BaseSystemInfo.UseUserPermission;
            this.btnFrmUserTableScope.Visible = BaseSystemInfo.UseTableScopePermission;
            this.btnFrmTableColumnPermission.Visible = BaseSystemInfo.UseTableColumnPermission;
            this.btnUseAuthorizationScope.Visible = BaseSystemInfo.UsePermissionScope && BaseSystemInfo.UseAuthorizationScope;
            
            // 是否有添加权限
            this.btnAdd.Enabled = this.permissionAdd;
            // 是否有数据的判断
            if (this.DTUser.DefaultView.Count > 0)
            {
                this.btnProperty.Enabled = this.permissionProperty;
                this.btnPermission.Enabled = this.permissionAccredit && BaseSystemInfo.UseUserPermission;
                this.btnSetPassword.Enabled = this.permissionSetPassword;
                this.btnUserRole.Enabled = this.permissionProperty;
                this.btnExport.Enabled = this.permissionExport;
                this.btnDelete.Enabled = this.permissionDelete;
                this.btnUserOrganizeScope.Enabled = permissionAccredit;
                this.btnUseAuthorizationScope.Enabled = permissionAccredit;
                this.btnRoleUserBatchSet.Enabled = permissionAccredit;
                this.btnUserOrganizeScope.Enabled = permissionAccredit;
                this.btnBatchPermission.Enabled = permissionAccredit;
                this.btnFrmUserTableScope.Enabled = permissionAccredit;
                this.btnFrmTableColumnPermission.Enabled = permissionAccredit;
            }

            // 超级管理员不需要设置权限
            DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdUser);
            if (dataRow != null)
            {
                BaseUserEntity userEntity = new BaseUserEntity(dataRow);
                // 超级管理员没必要设置权限，设置了权限反而增加误解了
                if (userEntity.Code != null && userEntity.Code.Equals(DefaultRole.Administrator.ToString()))
                {
                    this.btnUseAuthorizationScope.Enabled = false;
                    this.btnProperty.Enabled = false;
                    this.btnPermission.Enabled = false;
                    this.btnDelete.Enabled = false;
                }
            }
        }
        #endregion

        #region private void BindData() 绑定数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            if (this.chkEnabled.Checked)
            {
                BaseBusinessLogic.SetFilter(this.DTUser, BaseUserEntity.FieldEnabled, "1");
            }
            this.grdUser.AutoGenerateColumns = false;
            // if (this.grdUser.DataSource == null)
            // {
            this.grdUser.DataSource = this.DTUser.DefaultView;
            // }
            // else
            // {
            //    ((CurrencyManager)this.grdUser.BindingContext[this.grdUser.DataSource, string.Empty]).Refresh();
            // }
            if (this.CurrentEntityId.Length > 0)
            {
                this.grdUser.FirstDisplayedScrollingRowIndex = BaseInterfaceLogic.GetRowIndex(this.DTUser, BaseUserEntity.FieldId, this.CurrentEntityId);
            }
            this.SetControlState();
        }
        #endregion

        private void FormOnLoad(bool loadUser, string searchValue)
        {
            // 加载窗体，检查是否配置为默认加载用户列表，就怕用户数量太多了。
            if (loadUser)
            {
                if (String.IsNullOrEmpty(searchValue))
                {
                }
                this.DTUser = this.GetUserScope(this.PermissionItemScopeCode);
                // 加载绑定数据
                this.BindData();
            }
        }

        #region private void LoadTreeOrganize() 加载树
        /// <summary>
        /// 加载树
        /// </summary>
        private void LoadTreeOrganize()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvOrganize.BeginUpdate();
            this.tvOrganize.Nodes.Clear();
            TreeNode treeNode = new TreeNode();
            this.LoadTreeOrganize(treeNode);
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvOrganize.EndUpdate();
        }
        #endregion

        #region private void LoadTreeOrganize(TreeNode treeNode)
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeOrganize(TreeNode treeNode)
        {
            BaseInterfaceLogic.LoadTreeNodes(this.DTOrganize, BaseOrganizeEntity.FieldId, BaseOrganizeEntity.FieldParentId, BaseOrganizeEntity.FieldFullName, this.tvOrganize, treeNode, !BaseSystemInfo.OrganizeDynamicLoading);
        }
        #endregion

        private string organizeId = string.Empty;
        // 部门主键
        public string OrganizeId
        {
            get
            {
                if ((this.tvOrganize.SelectedNode != null) && (this.tvOrganize.SelectedNode.Tag != null))
                {
                    this.organizeId = (this.tvOrganize.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                }
                else
                {
                    this.organizeId = string.Empty;
                }
                return this.organizeId;
            }
            set
            {
                this.organizeId = value;
            }
        }

        #region private void GetOrganizeList() 获得子部门列表
        /// <summary>
        /// 获得子部门列表
        /// </summary>
        private void GetOrganizeList()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            this.DTOrganizeList = DotNetService.Instance.OrganizeService.GetDataTableByParent(UserInfo, this.OrganizeId);
            this.DTOrganizeList.DefaultView.Sort = BaseOrganizeEntity.FieldSortCode;
            // 动态加载树形结构
            if (this.tvOrganize.SelectedNode.Nodes.Count == 0)
            {
                foreach (DataRow dataRow in this.DTOrganizeList.Rows)
                {
                    TreeNode treeNode = new TreeNode();
                    treeNode.Text = dataRow[BaseOrganizeEntity.FieldFullName].ToString();
                    treeNode.Tag = dataRow[BaseOrganizeEntity.FieldId].ToString();
                    this.tvOrganize.SelectedNode.Nodes.Add(treeNode);
                }
            }
            this.tvOrganize.SelectedNode.Expand();
            // 设置按钮状态
            this.SetControlState();
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.splUser.SplitterDistance = 0;
            // 获取部门数据，这里按管理范围进行获取数据
            this.DTOrganize = this.GetOrganizeScope(this.PermissionItemScopeCode, true);
            // 内部组织机构必须要检查父亲节点的逻辑关系
            BaseInterfaceLogic.CheckTreeParentId(this.DTOrganize, BaseOrganizeEntity.FieldId, BaseOrganizeEntity.FieldParentId);
            this.LoadTreeOrganize();
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdUser);
            // 加载窗体，检查是否配置为默认加载用户列表，就怕用户数量太多了。
            FormOnLoad(BaseSystemInfo.LoadAllUser);
            this.SetRowFilter();
        }
        #endregion

        private void FormOnLoad(bool loadUser)
        {
            // 加载窗体，检查是否配置为默认加载用户列表，就怕用户数量太多了。
            this.FormOnLoad(loadUser, string.Empty);
        }

        private void btnFrmUseAuthorizationScope_Click(object sender, EventArgs e)
        {
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmUseAuthorizationScope";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUseAuthorizationScope = (Form)Activator.CreateInstance(assemblyType, this.TargetUserId);
            frmUseAuthorizationScope.ShowDialog(this);
        }

        private void btnFrmUserTableScope_Click(object sender, EventArgs e)
        {
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmTableScope";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserPermissionAdmin = (Form)Activator.CreateInstance(assemblyType, BaseUserEntity.TableName, this.TargetUserId);
            frmUserPermissionAdmin.ShowDialog(this);
        }

        private void btnFrmTableColumnPermission_Click(object sender, EventArgs e)
        {
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmTableColumnPermission";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmTableColumnPermission = (Form)Activator.CreateInstance(assemblyType, BaseUserEntity.TableName, this.TargetUserId);
            frmTableColumnPermission.ShowDialog(this);
        }

        private void btnRoleUserBatchSet_Click(object sender, EventArgs e)
        {
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmUserRoleBatchSet";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserRoleBatchSet = (Form)Activator.CreateInstance(assemblyType);
            frmUserRoleBatchSet.ShowDialog(this);
        }

        private void btnUserOrganizeScope_Click(object sender, EventArgs e)
        {
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmUserOrganizeScope";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserPermissionAdmin = (Form)Activator.CreateInstance(assemblyType, this.PermissionItemScopeCode);
            frmUserPermissionAdmin.ShowDialog(this);
        }

        private void btnBatchPermission_Click(object sender, EventArgs e)
        {
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmUserPermissionBatchSet";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserPermissionAdmin = (Form)Activator.CreateInstance(assemblyType);
            frmUserPermissionAdmin.ShowDialog(this);
        }

        #region private void SetRowFilter() 设置数据过滤
        /// <summary>
        /// 设置数据过滤
        /// </summary>
        private void SetRowFilter()
        {
            string search = this.txtSearch.Text.Trim();
            if (String.IsNullOrEmpty(search))
            {
                this.DTUser.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                if (this.DTUser.Columns.Count > 1)
                {
                    search = StringUtil.GetSearchString(search);
                    this.DTUser.DefaultView.RowFilter =
                        
                        /*BaseUserEntity.FieldUserName + " LIKE '" + search + "'"
                        + " OR " + BaseUserEntity.FieldRealName + " LIKE '" + search + "'"
                        + " OR " + BaseUserEntity.FieldCode + " LIKE '" + search + "'"
                        + " OR " + BaseUserEntity.FieldQuickQuery + " LIKE '" + search + "'"
                        + " OR " + BaseUserEntity.FieldDepartmentName + " LIKE '" + search + "'"
                        + " OR " + BaseUserEntity.FieldDescription + " LIKE '" + search + "'";*/

                        StringUtil.GetLike(BaseUserEntity.FieldUserName, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldRealName, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldCode, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldQuickQuery, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldDepartmentName, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldDescription, search);
                }
            }
        }
        #endregion

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.SetRowFilter();
            // 设置按钮状态
            this.SetControlState();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.FormOnLoad(true, this.txtSearch.Text);
        }

        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            this.FormOnLoad(true, this.txtSearch.Text);
        }

        #region private void GetStaffList() 获得表格里的用户
        /// <summary>
        /// 获得表格里的用户
        /// </summary>
        private void GetUserList()
        {
            this.grdUser.AutoGenerateColumns = false;
            this.DTUser = DotNetService.Instance.UserService.GetDataTableByDepartment(UserInfo, this.OrganizeId, true);

            // 把已经删除的过滤掉
            BaseBusinessLogic.SetFilter(this.DTUser, BaseStaffEntity.FieldDeletionStateCode, "0");
            // 只显示有效的用户
            if (this.chkEnabled.Checked)
            {
                BaseBusinessLogic.SetFilter(this.DTUser, BaseStaffEntity.FieldEnabled, "1");
            }
            if (this.OrganizeId.Length > 0)
            {
                this.DTUser.DefaultView.Sort = BaseUserEntity.FieldSortCode;
                this.grdUser.DataSource = this.DTUser.DefaultView;
            }
            // 设置按钮状态
            this.SetControlState();
        }
        #endregion

        private void tvOrganize_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.FormLoaded)
            {
                this.GetUserList();
            }
        }

        private void tvOrganize_Click(object sender, EventArgs e)
        {
            this.GetOrganizeList();
            this.GetUserList();
        }

        private void tvOrganize_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvOrganize.GetNodeAt(e.X, e.Y) != null)
            {
                tvOrganize.SelectedNode = tvOrganize.GetNodeAt(e.X, e.Y);
            }
        }

        private void grdUser_SelectionChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                // 设置按钮状态
                this.SetControlState();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //string assemblyName = "DotNet.WinForm";
            //string formName = "FrmUserAdd";
            //Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            //Form frmUserAdd = (Form)Activator.CreateInstance(assemblyType);
            FrmUserAdd frmUserAdd = new FrmUserAdd();
            frmUserAdd.OnAdded += new FrmUserAdd.OnAddedEventHandler(this.OnAdded);
            if (frmUserAdd.ShowDialog(this) == DialogResult.OK)
            {
                // 记录当前选中的主键
                // this.CurrentEntityId = frmUserAdd.entityId;
                // 加载窗体
                //this.FormOnLoad(true);
            }
        }

        private void btnProperty_Click(object sender, EventArgs e)
        {
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmUserEdit";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserEdit = (Form)Activator.CreateInstance(assemblyType, this.EntityId);
            if (frmUserEdit.ShowDialog(this) == DialogResult.OK)
            {
                // 记录当前选中的主键
                // this.CurrentEntityId = frmUserAdd.entityId;
                // 加载窗体
                this.FormOnLoad(true);
            }
        }

        #region private string[] GetSelectIds() 选种的用户主键数组
        /// <summary>
        /// 选种的用户主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelectIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdUser, BaseUserEntity.FieldId, "colSelected", true);
        }
        #endregion

        private void btnSetPassword_Click(object sender, EventArgs e)
        {
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdUser, "colSelected"))
            {
                string assemblyName = "DotNet.WinForm";
                string formName = "FrmUserSetPassword";
                Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
                Form frmUserSetPassword = (Form)Activator.CreateInstance(assemblyType, (object)this.GetSelectIds());
                frmUserSetPassword.ShowDialog(this);
            }
        }

        private void btnUserRole_Click(object sender, EventArgs e)
        {
            DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdUser);
            string id = dataRow[BaseUserEntity.FieldId].ToString();
            string realName = dataRow[BaseUserEntity.FieldRealName].ToString();

            string assemblyName = "DotNet.WinForm";
            string formName = "FrmUserRoleAdmin";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserPermissionAdmin = (Form)Activator.CreateInstance(assemblyType, id, realName);
            frmUserPermissionAdmin.ShowDialog(this);
        }

        public string TargetUserId
        {
            get
            {
                DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdUser);
                string userId = dataRow[BaseUserEntity.FieldId].ToString();
                return userId;
            }
        }

        public string TargetUserRealName
        {
            get
            {
                DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdUser);
                return dataRow[BaseUserEntity.FieldRealName].ToString();
            }
        }

        protected virtual void btnPermission_Click(object sender, EventArgs e)
        {
            string assemblyName = "DotNet.WinForm";
             string formName = "FrmUserPermission";
            // 若不采用操作权限，直接设置模块权限
            if (!BaseSystemInfo.UsePermissionItem)
            {
                formName = "FrmUserModulePermission";
            }
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserPermissionAdmin = (Form)Activator.CreateInstance(assemblyType, this.TargetUserId, this.TargetUserRealName);
            frmUserPermissionAdmin.ShowDialog(this);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 导出Excel
            //string exportFileName = this.Text + ".csv";
            string exportFileName = this.Text + ".xls";
            this.ExportExcel(this.grdUser , @"\Modules\Export\", exportFileName);
        }

        #region public override int BatchDelete() 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        public override int BatchDelete()
        {
            int returnValue = 0;
            // 删除用户
            returnValue = DotNetService.Instance.UserService.BatchDelete(UserInfo, this.GetSelectIds());
            // 获取用户
            this.DTUser = DotNetService.Instance.UserService.GetDataTable(UserInfo);
            // 获取绑定数据
            this.BindData();
            return returnValue;
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

            foreach (DataGridViewRow dgvRow in grdUser.Rows)
            {
                DataRow dataRow = (dgvRow.DataBoundItem as DataRowView).Row;
                if ((System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false))
                {
                    BaseUserEntity userEntity = new BaseUserEntity(dataRow);
                    // 自己不允许删除自己
                    if (userEntity.Id != null && this.UserInfo.Id.Equals(userEntity.Id.ToString()))
                    {
                        MessageBox.Show(AppMessage.Format(AppMessage.MSG0101, userEntity.RealName), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        returnValue = false;
                        break;
                    }
                    // 已经在线的用户不能被删除
                    userEntity = DotNetService.Instance.UserService.GetEntity(this.UserInfo, userEntity.Id.ToString());
                    if (userEntity.UserOnLine != null && userEntity.UserOnLine > 0)
                    {
                        MessageBox.Show(AppMessage.Format(AppMessage.MSG0100, userEntity.RealName), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        returnValue = false;
                        break;
                    }
                    // 超级管理员等不允许删除
                    if (userEntity.Code != null && userEntity.Code.Equals(DefaultRole.Administrator.ToString()))
                    {
                        MessageBox.Show(AppMessage.Format(AppMessage.MSG0018, userEntity.RealName), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        returnValue = false;
                        break;
                    }
                }
            }
            return returnValue;
        }
        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdUser, "colSelected"))
            {
                if (!this.CheckInput())
                {
                    return;
                }
                if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    // 设置鼠标繁忙状态，并保留原先的状态
                    Cursor holdCursor = this.Cursor;
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        this.BatchDelete();
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
    }
}