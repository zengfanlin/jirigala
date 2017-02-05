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
    /// FrmUserAdmin.cs
    /// 后台管理-用户管理窗体
    ///		
    /// 修改记录
    ///     
    ///     2011.08.11 版本：1.2 JiRiGaLa 有些系统默认的,隐藏的用户不能显示出来。
    ///     2008.04.05 版本：1.1 JiRiGaLa 整理调试程序，删除多余主键。
    ///     2007.07.02 版本：1.0 JiRiGaLa 用户管理功能页面编写。
    ///     2012.04.23 版本：1.2 ZhangWeiDong 用户信息中不显示 Email，电话
    ///		
    /// 版本：1.2
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.08.11</date>
    /// </author> 
    /// </summary>
    public partial class FrmUserAdmin : BaseForm, IBaseForm
    {
        /// <summary>
        /// 用户管理用户数据
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
        /// 编辑用户
        /// </summary>
        private bool permissionProperty = false;
        
        /// <summary>
        /// 设置密码
        /// </summary>
        private bool permissionSetPassword = false;
        
        /// <summary>
        /// 用户授权
        /// </summary>
        private bool permissionAccredit = false;

        /// <summary>
        /// 2011-03-17
        /// 权限域编号(按权限管理范围来列出数据才可以，只能管理这个范围的数据)
        /// </summary>
        public string PermissionItemScopeCode = "Resource.ManagePermission";

        public event SetControlStateEventHandler OnButtonStateChange;

        public FrmUserAdmin()
        {
            InitializeComponent();
        }

        private bool OnAdded()
        {
            // 加载窗体
            this.FormOnLoad();
            // 设置按钮状态
            this.SetControlState();
            return true;
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

        #region public string CurrentEntityId 当前选种的Id
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
            this.permissionAccess = this.IsModuleAuthorized(this.Name);
            this.permissionSearch = this.IsAuthorized("UserAdmin.Search");
            this.permissionAdd = this.IsAuthorized("UserAdmin.Add");
            this.permissionProperty = this.IsAuthorized("UserAdmin.Property");
            this.permissionSetPassword = this.IsAuthorized("UserAdmin.SetPassword");
            this.permissionExport = this.IsAuthorized("UserAdmin.Export");
            this.permissionDelete = this.IsAuthorized("UserAdmin.Delete");
            this.permissionAccredit = this.IsAuthorized("UserAdmin.Accredit");
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

        #region public override void SetControlState() 按钮的状态设置
        /// <summary>
        /// 按钮的状态设置
        /// </summary>
        public override void SetControlState()
        {          
            this.btnSelectAll.Enabled = false;
            this.btnInvertSelect.Enabled = false;

            this.btnSearch.Visible = !BaseSystemInfo.LoadAllUser;
            // 是否有添加权限
            this.btnAdd.Enabled = this.permissionAdd;
            // 是否有数据的判断
            if (this.DTUser.DefaultView.Count <= 0)
            {
                this.btnProperty.Enabled = false;
                this.btnSetPassword.Enabled = false;
                this.btnDelete.Enabled = false;
                // this.btnExport.Enabled = false;
                this.btnBatchSave.Enabled = false;
                this.btnRoleUser.Enabled = false;
                this.ucTableSort.Enabled = false;
            }
            else
            {
                this.btnSetOrganize.Enabled = this.permissionProperty;
                this.btnProperty.Enabled = this.permissionProperty;
                this.btnSetPassword.Enabled = this.permissionSetPassword;
                // this.btnExport.Enabled = this.permissionExport;
                this.btnDelete.Enabled = this.permissionDelete;
                this.btnBatchSave.Enabled = this.permissionProperty;
                this.btnRoleUser.Enabled = this.permissionAccess;
                this.ucTableSort.Enabled = this.permissionProperty;
            }

            // 检查委托是否为空
            if (OnButtonStateChange != null)
            {
                bool setTop = this.ucTableSort.SetTopEnabled;
                bool setUp = this.ucTableSort.SetUpEnabled;
                bool setDown = this.ucTableSort.SetDownEnabled;
                bool setBottom = this.ucTableSort.SetBottomEnabled;
                bool add = this.btnAdd.Enabled;
                bool edit = this.btnProperty.Enabled;
                bool batchDelete = this.btnDelete.Enabled;
                bool batchSave = this.btnBatchSave.Enabled;
                OnButtonStateChange(setTop, setUp, setDown, setBottom, add, edit, batchDelete, batchSave);
            }
            // 检查有没有可导出数据
            this.picExport.Enabled = (this.grdUser .RowCount > 0);
            if ((this.grdUser.RowCount >= 1))
            {
                this.btnSelectAll.Enabled = this.permissionEdit || this.permissionDelete;
                this.btnInvertSelect.Enabled = this.permissionEdit || this.permissionDelete;
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

            // 2012.06.20 Pcksy 修正Bug:普通用户进入用户管理报找不到 SortCode
            if (this.DTUser.Columns.Count > 0)
            {
                this.DTUser.DefaultView.Sort = BaseUserEntity.FieldSortCode;
            }
            this.grdUser.DataSource = this.DTUser.DefaultView;
            if (this.CurrentEntityId.Length > 0)
            {
                this.grdUser.FirstDisplayedScrollingRowIndex = BaseInterfaceLogic.GetRowIndex(this.DTUser, BaseUserEntity.FieldId, this.CurrentEntityId);
            }
            // 设置排序按钮
            this.ucTableSort.DataBind(this.grdUser, this.permissionProperty);
            // 设置用户能否修改有效状态
            if (!this.permissionProperty)
            {
                // 只读属性设置
                this.grdUser.Columns["colEnabled"].ReadOnly = !this.permissionProperty;
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
                    // this.DTUser = DotNetService.Instance.UserService.GetDataTable(UserInfo);
                    this.DTUser = this.GetUserScope(this.PermissionItemScopeCode);
                }
                else
                {
                    // Bug 吉日嘎拉 2011-03-17 这里是不应该全部搜索数据库，按权限范围过滤才对，将来再修改吧，现在可以先不修改了，能用再说。
                    this.DTUser = DotNetService.Instance.UserService.Search(UserInfo, searchValue, string.Empty, null);
                }
                // 加载绑定数据
                this.BindData();

                // 如果是在调试状态
                #if (DEBUG)
                    foreach (DataRow dataRow in this.DTUser.Rows)
                    {
                        dataRow[BaseUserEntity.FieldQuestion] = StringUtil.GetPinyin(dataRow[BaseUserEntity.FieldRealName].ToString());
                    }
                #endif
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
            if (this.tvOrganize.Nodes.Count > 0)
            {
                this.tvOrganize.Nodes[0].Expand();
            }
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
                    if (this.tvOrganize.SelectedNode.Tag is DataRow)
                    {
                        this.organizeId = (this.tvOrganize.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                    }
                    else
                    {
                        this.organizeId = this.tvOrganize.SelectedNode.Tag.ToString();
                    }
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
            this.FormOnLoad(BaseSystemInfo.LoadAllUser, string.Empty);
            // 若有过滤条件，要进行数据过滤
            this.SetRowFilter();
        }
        #endregion

        #region private void SetRowFilter() 设置数据过滤
        /// <summary>
        /// 设置数据过滤
        /// </summary>
        private void SetRowFilter()
        {
            string search = this.txtSearch.Text.Trim();

            if (search == "'")
            {
                search = string.Empty;
            }

            this.txtSearch.Text = this.txtSearch.Text.Replace("'", "") ;
            search = search.Replace("'", "");


            if (String.IsNullOrEmpty(search))
            {
                this.DTUser.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                if (this.DTUser.Columns.Count > 1)
                {
                    string rowFilter = string.Empty;
                    search = StringUtil.GetSearchString(search);
                    rowFilter = StringUtil.GetLike(BaseUserEntity.FieldUserName, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldRealName, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldCode, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldQuickQuery, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldDepartmentName, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldDescription, search);
                    this.DTUser.DefaultView.RowFilter = rowFilter;
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
            this.FormOnLoad(true,this.txtSearch.Text);
        }

        private void btnSetOrganize_Click(object sender, EventArgs e)
        {
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdUser, "colSelected"))
            {
                FrmUserOrganizeBatchSet frmUserOrganizeBatchSet = new FrmUserOrganizeBatchSet(this.GetSelectIds());
                if (frmUserOrganizeBatchSet.ShowDialog(this) == DialogResult.OK)
                {
                    // 重新加载页面
                    this.FormOnLoad();
                }
            }
        }

        private void picExport_Click(object sender, EventArgs e)
        {
            // 导出Excel
            string exportFileName = this.Text + ".xls";
            this.ExportExcel(this.grdUser, @"\Modules\Export\", exportFileName);
        }

        private void picImport_Click(object sender, EventArgs e)
        {
            FrmImportUser frmImportUser = new FrmImportUser();
            frmImportUser.ShowDialog();
        }

        private void picSetting_Click(object sender, EventArgs e)
        {
            FrmDataGridViewSetting frmDataGridViewSetting = new FrmDataGridViewSetting();
            frmDataGridViewSetting.TargetForm = this;
            frmDataGridViewSetting.TargetDataGridView = this.grdUser;
            frmDataGridViewSetting.ShowDialog();
        }

        private void picBug_Click(object sender, EventArgs e)
        {
            string url = "http://www.cnblogs.com/jirigala/archive/2011/12/17/2291253.html";
            System.Diagnostics.Process.Start(url);
        }

        private void grdUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmUserEdit frmUserEdit = new FrmUserEdit(this.EntityId);
            if (frmUserEdit.ShowDialog(this) == DialogResult.OK)
            {
                // 记录当前选中的主键
                this.CurrentEntityId = frmUserEdit.EntityId;
                // 加载窗体
                this.FormOnLoad();
            }
            // this.btnProperty.PerformClick();
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
            BaseBusinessLogic.SetFilter(this.DTUser, BaseUserEntity.FieldDeletionStateCode, "0");
            // 只显示可视的用户
            BaseBusinessLogic.SetFilter(this.DTUser, BaseUserEntity.FieldIsVisible, "1");
            // 只显示有效的用户
            if (this.chkEnabled.Checked)
            {
                BaseBusinessLogic.SetFilter(this.DTUser, BaseUserEntity.FieldEnabled, "1");
            }
            if (this.OrganizeId.Length > 0)
            {
                this.DTUser.DefaultView.Sort = BaseUserEntity.FieldSortCode;
                this.grdUser.DataSource = this.DTUser.DefaultView;
            }
            // 设置排序按钮
            this.ucTableSort.DataBind(this.grdUser, this.permissionProperty);
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

        private void grdUser_Sorted(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (this.permissionProperty)
            {
                string[] sequence = DotNetService.Instance.SequenceService.GetBatchSequence(UserInfo, BaseUserEntity.TableName, this.DTUser.DefaultView.Count);
                int i = 0;
                foreach (DataRowView dataRowView in this.DTUser.DefaultView)
                {
                    dataRowView.Row[BaseUserEntity.FieldSortCode] = sequence[i];
                    i++;
                }
                // 控制导航按钮
                this.SetSortButton(false);
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }

        public string Add()
        {
            // FrmUserAdd frmUserAdd = new FrmUserAdd();
            FrmRequestAnAccount frmUserAdd = new FrmRequestAnAccount();
            frmUserAdd.OnAdded += new FrmRequestAnAccount.OnAddedEventHandler(this.OnAdded);
            if (frmUserAdd.ShowDialog(this) == DialogResult.OK)
            {
                // 记录当前选中的主键
                this.CurrentEntityId = frmUserAdd.EntityId;
                // 加载窗体
                this.FormOnLoad();
            }
            return this.CurrentEntityId;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Add();
        }

        public void Edit()
        {
            FrmAccountEdit frmUserEdit = new FrmAccountEdit(this.EntityId);
            // FrmUserEdit frmUserEdit = new FrmUserEdit(this.EntityId);
            if (frmUserEdit.ShowDialog(this) == DialogResult.OK)
            {
                // 记录当前选中的主键
                this.CurrentEntityId = frmUserEdit.EntityId;
                // 加载窗体
                this.FormOnLoad();
            }
        }

        private void btnProperty_Click(object sender, EventArgs e)
        {
            this.Edit();
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
                FrmUserSetPassword frmUserSetPassword = new FrmUserSetPassword(this.GetSelectIds());
                frmUserSetPassword.ShowDialog(this);
            }
        }

        private void btnPermission_Click(object sender, EventArgs e)
        {
            DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdUser);
            string id = dataRow[BaseUserEntity.FieldId].ToString();
            string realName = dataRow[BaseUserEntity.FieldRealName].ToString();

            string assemblyName = "DotNet.WinForm";
            string formName = "FrmUserPermission";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserPermissionAdmin = (Form)Activator.CreateInstance(assemblyType, id, realName);
            frmUserPermissionAdmin.ShowDialog(this);
        }

        private void btnRoleUser_Click(object sender, EventArgs e)
        {
            DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdUser);
            if (dataRow != null)
            {
                string id = dataRow[BaseUserEntity.FieldId].ToString();
                string realName = dataRow[BaseUserEntity.FieldRealName].ToString();
                FrmUserRoleAdmin frmUserRoleAdmin = new FrmUserRoleAdmin(id, realName);
                frmUserRoleAdmin.ShowDialog(this);
            }
        }

        public int Delete()
        {
            // 删除用户
            // DotNetService.Instance.UserService.BatchDelete(UserInfo, this.GetSelectIds());
            int returnValue = DotNetService.Instance.UserService.SetDeleted(UserInfo, this.GetSelectIds());
            // 获取用户
            this.DTUser = DotNetService.Instance.UserService.GetDataTable(UserInfo);
            // 获取绑定数据
            this.BindData();
            return returnValue;
        }

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
                if ((System.Boolean)(dgvRow.Cells["colSelected"].Value??false))
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

            //foreach (DataRowView dataRowView in this.DTUser.DefaultView)
            //{
            //    if (dataRowView.Row[BaseBusinessLogic.SelectedColumn].ToString().ToUpper().Equals(true.ToString().ToUpper()))
            //    {
            //        BaseUserEntity userEntity = new BaseUserEntity(dataRowView.Row);
            //        if (userEntity.Code != null && userEntity.Code.Equals(DefaultRole.Administrator.ToString()))
            //        {
            //            // 有不允许删除的数据
            //            MessageBox.Show(AppMessage.Format(AppMessage.MSG0018, userEntity.RealName), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            returnValue = false;
            //            break;
            //        }
            //    }
            //}
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
                        this.Delete();
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

        #region private void BatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private void BatchSave()
        {
            DotNetService.Instance.UserService.BatchSave(this.UserInfo, this.DTUser);
            // 绑定屏幕数据
            this.FormOnLoad();
            if (BaseSystemInfo.ShowInformation)
            {
                // 批量保存，进行提示
                MessageBox.Show(AppMessage.MSG0011, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        public void Save()
        {
            // 检查批量输入的有效性
            if (BaseInterfaceLogic.CheckInputModifyAnyOne(this.DTUser))
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
                    this.DTUser.AcceptChanges();
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

        private void FrmUserAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BaseInterfaceLogic.IsModfiedAnyOne(this.DTUser))
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

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in this.grdUser.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in this.grdUser.Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false);
            }
        }
    }
}