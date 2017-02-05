//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FrmOrganizeAdmin
    /// 组织机构管理-管理组织机构窗体
    ///		
    /// 修改记录
    ///     2012.05.22 版本：3.9 Pcsky     选择一个组织机构，添加员工时的所在公司，子公司、部门，工作组智能获取。
    ///     2012.2.2   版本：3.8 张毅      修改树状结构加载方法。
    ///     2011.12.08 版本：2.6 张广梁    屏蔽右键添加角色菜单，删除用户报表菜单。
    ///     2011.10.24 版本：2.5 张广梁    优化添加、删除、编译和移动操作。
    ///     2011.09.29 版本：2.4 JiRiGaLa 全部导出按钮的状态错误改进。
    ///     2011.05.05 版本：2.3 JiRiGaLa 第一层组织机构展开比较好。
    ///     2011.03.17 版本：2.2 JiRiGaLa 内部组织机构按权限范围进行过滤。
    ///     2008.10.27 版本：2.1 JiRiGaLa 整理权限主键。
    ///     2008.09.25 版本：2.0 JiRiGaLa 树型架构的节点加载顺序问题。
    ///     2008.02.05 版本：1.9 JiRiGaLa 速度性能进行优化。
    ///     2007.06.14 版本：1.8 JiRiGaLa 增加权限判断主键。
    ///     2007.06.05 版本：1.7 JiRiGaLa 整理主键。
    ///     2007.06.01 版本：1.6 JiRiGaLa 进行优化。
    ///     2007.05.30 版本：1.5 JiRiGaLa SingleDelete() 进行优化。
    ///     2007.05.29 版本：1.4 JiRiGaLa 删除移动的主键优化，提示信息优化，标准工程完成。
    ///     2007.05.28 版本：1.3 JiRiGaLa 整体整理主键。
    ///     2007.05.17 版本：1.2 JiRiGaLa 增加了多国语言功能，调整了细节部分。
    ///     2007.05.15 版本：1.1 JiRiGaLa 整体进行调试改进。
    ///     2007.05.12 版本：1.0 JiRiGaLa 组织机构管理功能页面编写。
    ///		
    /// 版本：2.5
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.09.29</date>
    /// </author> 
    /// </summary>    
    public partial class FrmOrganizeAdmin : BaseForm, IBaseForm
    {
        /// <summary>
        /// 新增组织机构权限
        /// </summary>
        private bool permissionAddRoot = false;

        /// <summary>
        /// 移动组织机构
        /// </summary>
        private bool permissionMove = false;

        /// <summary>
        /// 用户授权
        /// </summary>
        private bool permissionAccredit = false;

        /// <summary>
        /// 2011-03-17
        /// 权限域编号(按权限管理范围来列出数据才可以，只能管理这个范围的数据)
        /// </summary>
        public string PermissionItemScopeCode = "Resource.ManagePermission";

        /// <summary>
        /// 组织机构列表 DataTable
        /// </summary>
        private DataTable DTOrganize = new DataTable(BaseOrganizeEntity.TableName);

        /// <summary>
        /// 组织机构列表 DataTable
        /// </summary>
        private DataTable DTOrganizeList = new DataTable(BaseOrganizeEntity.TableName);

        /// <summary>
        /// 记录最后点击的控件
        /// </summary>
        private System.Windows.Forms.Control LastControl = null;

        public event SetControlStateEventHandler OnButtonStateChange;

        /// <summary>
        /// 设置是否为及时刷新的属性
        /// </summary>
        public bool RefreshData
        {
            set
            {
                this.chkRefresh.Checked = value;
            }
            get
            {
                return this.chkRefresh.Checked;
            }
        }

        /// <summary>
        /// 是否采用角色数据
        /// </summary>
        public bool UseRole = true;

        private string parentEntityId = string.Empty;
        /// <summary>
        /// 导航栏机构主键
        /// </summary>
        public string ParentEntityId
        {
            get
            {
                if ((this.tvOrganize.SelectedNode != null) && (this.tvOrganize.SelectedNode.Tag != null))
                {
                    if (this.tvOrganize.SelectedNode.Tag is DataRow)
                    {
                        this.parentEntityId = (this.tvOrganize.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                    }
                    else
                    {
                        this.parentEntityId = this.tvOrganize.SelectedNode.Tag.ToString();
                    }
                }
                else
                {
                    this.parentEntityId = string.Empty;
                }
                return this.parentEntityId;
            }
            set
            {
                this.parentEntityId = value;
            }
        }

        /// <summary>
        /// 表格中的组织机构主键
        /// </summary>
        public override string EntityId
        {
            get
            {
                return BaseInterfaceLogic.GetDataGridViewEntityId(this.grdOrganize, BaseOrganizeEntity.FieldId);
            }
        }

        /// <summary>
        /// 当前选中的节点，树或者表格上
        /// </summary>
        public string CurrentEntityId
        {
            get
            {
                string entityId = string.Empty;
                if (this.LastControl == this.tvOrganize)
                {
                    entityId = this.ParentEntityId;
                }
                else
                {
                    entityId = this.EntityId;
                }
                return entityId;
            }
        }

        public FrmOrganizeAdmin()
        {
            InitializeComponent();
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
            this.btnMove.Enabled = false;
            this.btnBatchDelete.Enabled = false;
            this.btnExport.Enabled = false;

            this.btnUserResourcePermission.Visible = BaseSystemInfo.UsePermissionScope && BaseSystemInfo.UseUserPermission;
            this.btnRoleResourcePermission.Visible = BaseSystemInfo.UsePermissionScope;

            this.btnRoleResourcePermission.Enabled = false;
            this.btnUserResourcePermission.Enabled = false;

            this.mItmAdd.Enabled = false;
            this.mItmEdit.Enabled = false;
            this.mItmMove.Enabled = false;
            this.mItmDelete.Enabled = false;

            this.mItemRoleAdd.Enabled = false;
            this.mItmStaffAdd.Enabled = false;
            this.mItmOrganizeCategory.Enabled = false;
            this.mItmFrmCodeBuilder.Enabled = false;
            this.mItmSetSortCode.Enabled = false;
            this.btnSelectAll.Enabled = false;
            this.btnInvertSelect.Enabled = false;

            // 检查添加权限
            this.btnAdd.Enabled = this.permissionAdd;

            if ((this.DTOrganizeList.DefaultView.Count >= 1) || (this.tvOrganize.Nodes.Count > 0))
            {
                this.btnEdit.Enabled = this.permissionEdit;
                this.btnMove.Enabled = this.permissionEdit;
                this.btnBatchDelete.Enabled = this.permissionDelete;
                if (this.tvOrganize.Nodes.Count > 0)
                {
                    this.btnExport.Enabled = this.permissionExport;
                }
                this.btnRoleResourcePermission.Enabled = this.permissionAccredit;
                this.btnUserResourcePermission.Enabled = this.permissionAccredit;
            }
            if (this.DTOrganizeList.DefaultView.Count >= 1)
            {
                this.btnBatchSave.Enabled = this.permissionEdit;
            }
            // 位置顺序改变按钮部分
            if (this.DTOrganizeList.DefaultView.Count > 1)
            {
                this.SetSortButton(this.permissionEdit);
            }
            if ((this.DTOrganize.DefaultView.Count > 0) && (this.tvOrganize.Nodes.Count > 0))
            {
                this.mItmAdd.Enabled = this.permissionAdd;
                this.mItmEdit.Enabled = this.permissionEdit;
                this.mItmMove.Enabled = this.permissionEdit;
                this.mItmDelete.Enabled = this.permissionDelete;

                // 这些都是属于管理权限的杂项，Admin 权限不能轻易给别人
                this.mItmStaffAdd.Enabled = this.ModuleIsVisible("FrmRoleAdmin");
                if (this.mItmStaffAdd.Visible)
                {
                    this.mItmStaffAdd.Enabled = this.IsModuleAuthorized("FrmStaffAdmin");
                }
                this.mItmUserAdd.Enabled = this.ModuleIsVisible("FrmUserAdmin");
                if (this.mItmUserAdd.Visible)
                {
                    this.mItmUserAdd.Enabled = this.IsModuleAuthorized("FrmUserAdmin");
                }
                this.mItemRoleAdd.Enabled = this.ModuleIsVisible("FrmRoleAdmin");
                if (this.mItemRoleAdd.Visible)
                {
                    this.mItemRoleAdd.Enabled = this.IsModuleAuthorized("FrmRoleAdmin");
                }
                this.mItmOrganizeCategory.Enabled = this.ModuleIsVisible("FrmItemsAdmin");
                if (this.mItmOrganizeCategory.Visible)
                {
                    this.mItmOrganizeCategory.Enabled = this.IsModuleAuthorized("FrmItemsAdmin");
                }
                this.mItmFrmCodeBuilder.Enabled = this.permissionEdit;
                this.mItmSetSortCode.Enabled = this.permissionEdit;
            }
            // 添加根组织机构，什么时候都可以用才对。
            this.mItmAddRoot.Enabled = this.permissionAddRoot;
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
            if ((this.grdOrganize.RowCount >= 1))
            {
                this.btnSelectAll.Enabled = this.permissionEdit || this.permissionDelete;
                this.btnInvertSelect.Enabled = this.permissionEdit || this.permissionDelete;
            }
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAccess = this.IsModuleAuthorized("OrganizeAdmin");
            this.permissionAdd = this.IsAuthorized("OrganizeAdmin.Add");
            this.permissionAddRoot = this.IsAuthorized("OrganizeAdmin.AddRoot");
            this.permissionEdit = this.IsAuthorized("OrganizeAdmin.Edit");
            this.permissionMove = this.IsAuthorized("OrganizeAdmin.Move");
            this.permissionDelete = this.IsAuthorized("OrganizeAdmin.Delete");
            this.permissionExport = this.IsAuthorized("OrganizeAdmin.Export");
            this.permissionAccredit = this.IsAuthorized("UserAdmin.Accredit");
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdOrganize);
            // 绑定屏幕数据
            this.BindData(true);
        }
        #endregion

        #region private void BindData(bool reloadTree) 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        /// <param name="reloadTree">重新加部门载树</param>
        private void BindData(bool reloadTree)
        {
            // 加载树
            if (reloadTree)
            {
                // 获取部门数据，这里是按权限范围进行获取
                this.DTOrganize = this.GetOrganizeScope(this.PermissionItemScopeCode, this.chkInnerOrganize.Checked);
                if (!this.UserInfo.IsAdministrator || this.chkInnerOrganize.Checked)
                {
                    BaseInterfaceLogic.CheckTreeParentId(this.DTOrganize, BaseOrganizeEntity.FieldId, BaseOrganizeEntity.FieldParentId);
                }
                this.LoadTree();
                if (this.tvOrganize.SelectedNode == null)
                {
                    if (this.tvOrganize.Nodes.Count > 0)
                    {
                        if (this.parentEntityId.Length == 0)
                        {
                            this.tvOrganize.SelectedNode = this.tvOrganize.Nodes[0];
                        }
                        else
                        {
                            BaseInterfaceLogic.FindTreeNode(this.tvOrganize, this.parentEntityId);
                            if (BaseInterfaceLogic.TargetNode != null)
                            {
                                this.tvOrganize.SelectedNode = BaseInterfaceLogic.TargetNode;
                                // 展开当前选中节点的所有父节点
                                BaseInterfaceLogic.ExpandTreeNode(this.tvOrganize);
                            }
                        }
                        if (this.tvOrganize.SelectedNode != null)
                        {
                            // 让选中的节点可视，并用展开方式
                            this.tvOrganize.SelectedNode.Expand();
                            this.tvOrganize.SelectedNode.EnsureVisible();
                        }
                    }
                }
            }
            if (this.ParentEntityId.Length > 0)
            {
                if (reloadTree)
                {
                    // 获得子部门列表
                    // this.GetOrganizeList();
                }
            }
            if (!this.permissionEdit)
            {
                // 只读属性设置
                this.grdOrganize.Columns["colSelected"].ReadOnly = !this.permissionEdit;
                this.grdOrganize.Columns["colFullName"].ReadOnly = !this.permissionEdit;
                this.grdOrganize.Columns["colIsInnerOrganize"].ReadOnly = !this.permissionEdit;
                this.grdOrganize.Columns["colDescription"].ReadOnly = !this.permissionEdit;
                // 修改背景颜色
                this.grdOrganize.Columns["colFullName"].DefaultCellStyle.BackColor = Color.White;
                this.grdOrganize.Columns["colIsInnerOrganize"].DefaultCellStyle.BackColor = Color.White;
                this.grdOrganize.Columns["colDescription"].DefaultCellStyle.BackColor = Color.White;
            }
            // 设置按钮状态
            this.SetControlState();
        }
        #endregion

        #region private void GetOrganizeList() 获得子部门列表
        /// <summary>
        /// 获得子部门列表
        /// </summary>
        private void GetOrganizeList()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            this.DTOrganizeList = DotNetService.Instance.OrganizeService.GetDataTableByParent(UserInfo, this.ParentEntityId);
            this.DTOrganizeList.DefaultView.Sort = BaseOrganizeEntity.FieldSortCode;
            this.grdOrganize.AutoGenerateColumns = false;
            this.grdOrganize.DataSource = this.DTOrganizeList.DefaultView;
            //// 动态加载树形结构
            //if (this.tvOrganize.SelectedNode.Nodes.Count == 0)
            //{
            //    foreach (DataRow dataRow in this.DTOrganizeList.Rows)
            //    {
            //        TreeNode treeNode = new TreeNode();
            //        treeNode.Text = dataRow[BaseOrganizeEntity.FieldFullName].ToString();
            //        treeNode.Tag = dataRow[BaseOrganizeEntity.FieldId].ToString();
            //        this.tvOrganize.SelectedNode.Nodes.Add(treeNode);
            //    }
            //    // this.tvOrganize.SelectedNode.Expand();
            //}
            // 设置排序按钮
            this.ucTableSort.DataBind(this.grdOrganize, this.permissionEdit);
            // 设置按钮状态
            this.SetControlState();
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }
        #endregion

        #region private void LoadTree() 加载树
        /// <summary>
        /// 加载树
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvOrganize.BeginUpdate();
            this.tvOrganize.Nodes.Clear();
            this.LoadTreeOrganize();
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvOrganize.EndUpdate();
        }
        #endregion

        private void LoadTreeOrganize()
        {
            TreeNode treeNode = new TreeNode();
            this.LoadTreeOrganize(treeNode);
        }

        #region private void LoadTreeOrganize(TreeNode treeNode) 加载组织机构树的主键
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="TreeNode">当前节点</param>
        private void LoadTreeOrganize(TreeNode treeNode)
        {
            if ((BaseSystemInfo.UsePermissionScope) && !UserInfo.IsAdministrator)
            {
                BaseInterfaceLogic.CheckTreeParentId(this.DTOrganize, BaseOrganizeEntity.FieldId, BaseOrganizeEntity.FieldParentId);
            }
            BaseInterfaceLogic.LoadTreeNodes(this.DTOrganize, BaseOrganizeEntity.FieldId, BaseOrganizeEntity.FieldParentId, BaseOrganizeEntity.FieldFullName, this.tvOrganize, treeNode, BaseSystemInfo.OrganizeDynamicLoading);
        }
        #endregion

        #region private void SetSearch() 设置查询条件
        /// <summary>
        /// 设置查询条件
        /// </summary>
        private void SetSearch()
        {
            this.grdOrganize.AutoGenerateColumns = false;
            string search = this.txtSearch.Text.Trim();
            if (String.IsNullOrEmpty(search))
            {
                this.DTOrganizeList.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                search = StringUtil.GetSearchString(search);
                this.DTOrganize.DefaultView.RowFilter =
                    /*
                    BaseOrganizeEntity.FieldCode + " LIKE '" + search + "'"
                    + " OR " + BaseOrganizeEntity.FieldFullName + " LIKE '" + search + "'"
                    + " OR " + BaseOrganizeEntity.FieldDescription + " LIKE '" + search + "'";*/

                    StringUtil.GetLike(BaseOrganizeEntity.FieldCode, search)
                        + " OR " + StringUtil.GetLike(BaseOrganizeEntity.FieldFullName, search)
                        + " OR " + StringUtil.GetLike(BaseOrganizeEntity.FieldDescription, search);

                this.grdOrganize.DataSource = this.DTOrganize.DefaultView;
            }
            // 设置按钮状态
            this.SetControlState();
        }
        #endregion

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.SetSearch();
        }

        #region 单击查找按钮
        /// <summary>
        /// 单击查找按钮。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.txtSearch.Text = this.txtSearch.Text.TrimEnd();
            if (this.txtSearch.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG0212), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtSearch.Focus();
                return;
            }
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            this.FormLoaded = false;
            // 点击了F5按钮
            ClientCache.Instance.DTOrganize = null;
            this.FormOnLoad();
            // 设置查询条件
            this.SetSearch();
            this.FormLoaded = true;
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }
        #endregion

        private void btnRoleResourcePermission_Click(object sender, EventArgs e)
        {
            // 资源管理权限
            string permissionItemCode = "Resource.ManagePermission";
            string targetResourceCategory = BaseOrganizeEntity.TableName;
            string targetResourceSQL = "SELECT " + BaseOrganizeEntity.FieldId + " AS Id, "
                                        + BaseOrganizeEntity.FieldParentId + " AS ParentId, "
                                        + BaseOrganizeEntity.FieldFullName + " AS RealName, "
                                        + BaseOrganizeEntity.FieldDescription + " AS Description FROM "
                                        + BaseOrganizeEntity.TableName
                                        + " WHERE " + BaseOrganizeEntity.FieldIsInnerOrganize + " = 1 AND " + BaseOrganizeEntity.FieldDeletionStateCode + " = 0 AND " + BaseOrganizeEntity.FieldEnabled + " = 1 ORDER BY " + BaseOrganizeEntity.FieldSortCode;

            string assemblyName = "DotNet.WinForm";
            string formName = "FrmRoleTreeResourcePermission";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmRoleModulePermission = (Form)Activator.CreateInstance(assemblyType, permissionItemCode, targetResourceCategory, targetResourceSQL);
            frmRoleModulePermission.ShowDialog(this);
        }

        private void btnUserResourcePermission_Click(object sender, EventArgs e)
        {
            // 资源管理权限
            string permissionItemCode = "Resource.ManagePermission";
            string targetResourceCategory = BaseOrganizeEntity.TableName;
            string targetResourceSQL = "SELECT " + BaseOrganizeEntity.FieldId + " AS Id, "
                                        + BaseOrganizeEntity.FieldParentId + " AS ParentId, "
                                        + BaseOrganizeEntity.FieldFullName + " AS RealName, "
                                        + BaseOrganizeEntity.FieldDescription + " AS Description FROM "
                                        + BaseOrganizeEntity.TableName
                                        + " WHERE " + BaseOrganizeEntity.FieldIsInnerOrganize + " = 1 AND " + BaseOrganizeEntity.FieldDeletionStateCode + " = 0 AND " + BaseOrganizeEntity.FieldEnabled + " = 1 ORDER BY " + BaseOrganizeEntity.FieldSortCode;

            string assemblyName = "DotNet.WinForm";
            string formName = "FrmUserTreeResourcePermission";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserModulePermission = (Form)Activator.CreateInstance(assemblyType, permissionItemCode, targetResourceCategory, targetResourceSQL);
            frmUserModulePermission.ShowDialog(this);
        }

        #region 仅显示内部组织机构
        /// <summary>
        /// 仅显示内部组织机构
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkInnerOrganize_CheckedChanged(object sender, EventArgs e)
        {
            this.OnLoad(e);
        }
        #endregion

        #region 即时刷新按钮
        /// <summary>
        /// 即时刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkRefresh.Checked)
            {
                ClientCache.Instance.DTOrganize = null;
                this.FormOnLoad();
            }
        }
        #endregion

        #region  树形结构动态事件集合
        /// <summary>
        /// 更改选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvOrganize_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.FormLoaded)
            {
                if (this.ActiveControl == this.tvOrganize)
                {
                    if (this.tvOrganize.SelectedNode != null)
                    {
                        // this.GetOrganizeList();
                    }
                }
            }
        }
        /// <summary>
        /// 单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvOrganize_Click(object sender, EventArgs e)
        {
            this.LastControl = this.tvOrganize;
            if (this.tvOrganize.SelectedNode == null)
            {
                this.tvOrganize.ContextMenuStrip = null;
            }
            else
            {
                this.tvOrganize.ContextMenuStrip = this.cMnuOrganize;
            }
            if (this.tvOrganize.SelectedNode != null)
            {
                this.GetOrganizeList();
            }
        }
        /// <summary>
        /// 展开动态加载部门
        /// 张毅 添加 因为数据量太大 动态获取数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvOrganize_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Node.ToolTipText))
            {
                e.Node.Nodes.Clear();
                LoadTreeOrganize(e.Node);
                e.Node.ToolTipText = e.Node.Text;
            }
        }
        #endregion

        private void tvOrganize_DragEnter(object sender, DragEventArgs e)
        {
            // 拖动效果设成移动
            e.Effect = DragDropEffects.Move;
        }

        private void tvOrganize_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (this.permissionEdit)
            {
                // 开始进行拖放操作，并将拖放的效果设置成移动。
                this.DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void tvOrganize_DragDrop(object sender, DragEventArgs e)
        {
            // 定义一个中间变量
            TreeNode treeNode;
            //判断拖动的是否为TreeNode类型，不是的话不予处理
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                // 拖放的目标节点
                TreeNode targetTreeNode;
                // 获取当前光标所处的坐标
                // 定义一个位置点的变量，保存当前光标所处的坐标点
                Point point = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                // 根据坐标点取得处于坐标点位置的节点
                targetTreeNode = ((TreeView)sender).GetNodeAt(point);
                // 获取被拖动的节点
                treeNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                // 判断拖动的节点与目标节点是否是同一个,同一个不予处理
                if (BaseInterfaceLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode))
                {
                    if (BaseSystemInfo.ShowInformation)
                    {
                        // 是否移动部门
                        if (MessageBox.Show(AppMessage.Format(AppMessage.MSG0038, treeNode.Text, targetTreeNode.Text), AppMessage.MSG0000, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    DotNetService.Instance.OrganizeService.MoveTo(UserInfo, (treeNode.Tag as DataRow)[BaseOrganizeEntity.FieldId].ToString(), (targetTreeNode.Tag as DataRow)[BaseOrganizeEntity.FieldId].ToString());
                    // 往目标节点中加入被拖动节点的一份克隆
                    targetTreeNode.Nodes.Add((TreeNode)treeNode.Clone());
                    // 将被拖动的节点移除
                    treeNode.Remove();
                }
            }
        }

        #region public string Add() 添加组织机构
        /// <summary>
        /// 添加组织机构
        /// </summary>
        /// <returns>主键</returns>
        public string Add()
        {
            string returnValue = string.Empty;
            string companyId = string.Empty;
            string subCompanyId = string.Empty;
            string departmentId = string.Empty;
            string workgroupId = string.Empty;

            TreeNode treeNode = this.tvOrganize.SelectedNode;
            while (treeNode != null)
            {
                string id = string.Empty;
                if (treeNode.Tag is DataRow)
                {
                    id = (treeNode.Tag as DataRow)[BaseOrganizeEntity.FieldId].ToString();
                }
                else
                {
                    id = treeNode.Tag.ToString();
                }
                if (BaseBusinessLogic.GetProperty(this.DTOrganize, id, BaseOrganizeEntity.FieldCategory).ToUpper() == "Company".ToUpper())
                {
                    if (string.IsNullOrEmpty(companyId))
                    {
                        companyId = id;
                    }
                }
                else if (BaseBusinessLogic.GetProperty(this.DTOrganize, id, BaseOrganizeEntity.FieldCategory).ToUpper() == "SubCompany".ToUpper())
                {
                    if (string.IsNullOrEmpty(subCompanyId))
                    {
                        subCompanyId = id;
                    }
                }
                else if (BaseBusinessLogic.GetProperty(this.DTOrganize, id, BaseOrganizeEntity.FieldCategory).ToUpper() == "Department".ToUpper())
                {
                    if (string.IsNullOrEmpty(departmentId))
                    {
                        departmentId = id;
                    }
                }
                else if (BaseBusinessLogic.GetProperty(this.DTOrganize, id, BaseOrganizeEntity.FieldCategory).ToUpper() == "WorkGroup".ToUpper())
                {
                    if (string.IsNullOrEmpty(workgroupId))
                    {
                        workgroupId = id;
                    }
                }
                treeNode = treeNode.Parent;
            }
            FrmStaffAdd frmStaffAdd = new FrmStaffAdd(companyId, subCompanyId, departmentId, workgroupId);
            if (frmStaffAdd.ShowDialog(this) == DialogResult.OK)
            {
                returnValue = frmStaffAdd.EntityId;
            }
            return returnValue;
        }
        #endregion

        private bool OnAdded(string parentId, string fullName, string id)
        {

            BaseInterfaceLogic.FindTreeNode(this.tvOrganize, BaseOrganizeEntity.FieldId, parentId);
            //if (BaseInterfaceLogic.TargetNode != null)
            //{
                this.tvOrganize.SelectedNode = BaseInterfaceLogic.TargetNode;
                //string parentId = parentEntityId;
                // tvModule 中增加结点
                TreeNode newNode = new TreeNode();
                newNode.Text = fullName;
                newNode.Tag = DotNetService.Instance.OrganizeService.GetDataTableByIds(this.UserInfo, new string[] { id }).Rows[0];
                BaseInterfaceLogic.AddTreeNode(this.tvOrganize, newNode, this.tvOrganize.SelectedNode);
                this.tvOrganize.SelectedNode = newNode;
                // 展开当前选中节点的所有父节点
                BaseInterfaceLogic.ExpandTreeNode(this.tvOrganize);
            //}
            return true;
        }

        private void mItmAdd_Click(object sender, EventArgs e)
        {
            this.btnAdd.PerformClick();
        }

        private void mItmEdit_Click(object sender, EventArgs e)
        {
            this.EditTree();
        }

        private void mItmMove_Click(object sender, EventArgs e)
        {
            this.SingleMove();
        }

        private void mItmDelete_Click(object sender, EventArgs e)
        {
            // 删除事件
            this.SingleDelete();
        }

        private void mItmAddRoot_Click(object sender, EventArgs e)
        {
            this.Add(true);
        }

        private void mItmAddStaff_Click(object sender, EventArgs e)
        {
            this.Add();
        }

        /// <summary>
        /// 获得对应的组织结构
        /// </summary>
        /// <param name="OrganizeCategory"></param>
        /// <param name="Id">组织结构编号</param>
        /// <param name="fullName">组织结构命名</param>
        private void GetOraganize(OrganizeCategory organizeCategory, out string Id, out string fullName)
        {
            Id = string.Empty;
            fullName = string.Empty;

            TreeNode treeNode = this.tvOrganize.SelectedNode;

            // 取得工作组
            if (BaseBusinessLogic.GetProperty(ClientCache.Instance.DTOrganize, (treeNode.Tag as DataRow)[BaseOrganizeEntity.FieldId].ToString(), BaseOrganizeEntity.FieldCategory) == organizeCategory.ToString())
            {
                Id = (treeNode.Tag as DataRow)[BaseOrganizeEntity.FieldId].ToString();
                fullName = treeNode.Text;
            }
            else
            {
                while (treeNode.Parent != null)
                {
                    if (BaseBusinessLogic.GetProperty(ClientCache.Instance.DTOrganize, (treeNode.Tag as DataRow)[BaseOrganizeEntity.FieldId].ToString(), BaseOrganizeEntity.FieldCategory) == organizeCategory.ToString())
                    {
                        Id = (treeNode.Tag as DataRow)[BaseOrganizeEntity.FieldId].ToString();
                        fullName = treeNode.Text;
                        break;
                    }
                    treeNode = treeNode.Parent;
                }
            }
        }

        private void mItmAddRole_Click(object sender, EventArgs e)
        {
            // 用反射获得窗体
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmOrganizeRoleAdd";
            Form frmOrganizeRoleAdd = CacheManager.Instance.GetForm(assemblyName, formName);
            if (this.tvOrganize.SelectedNode != null)
            {
                ((FrmOrganizeRoleAdd)frmOrganizeRoleAdd).OrganizeId = (this.tvOrganize.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                ((FrmOrganizeRoleAdd)frmOrganizeRoleAdd).OrganizeFullName = this.tvOrganize.SelectedNode.Text;
            }
            frmOrganizeRoleAdd.ShowDialog(this);
        }

        private void mItmOrganizeCategory_Click(object sender, EventArgs e)
        {
            // 用反射获得窗体
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmItemDetailsAdmin";
            Form frmItemDetailsAdmin = CacheManager.Instance.GetForm(assemblyName, formName);
            ((FrmItemDetailsAdmin)frmItemDetailsAdmin).TargetTable = "ItemsOrganizeCategory";
            frmItemDetailsAdmin.ShowDialog();
        }

        private void mItmFrmUserModuleOperationReport_Click(object sender, EventArgs e)
        {
            if (this.tvOrganize.SelectedNode != null)
            {
                //FrmUserModuleOperationReport FrmUserModuleOperationReport = new FrmUserModuleOperationReport((this.tvOrganize.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString(), this.tvOrganize.SelectedNode.Text);
                //FrmUserModuleOperationReport.ShowDialog(this);
                //if (frmItemDetailsAdmin.ShowDialog(this) == DialogResult.OK)
                //{
                //    this.FormLoaded = false;

                //    // 绑定屏幕数据
                //    this.BindData(true);
                //    this.FormLoaded = true;
                //}
            }
        }

        string organizeList = string.Empty;

        private void GetTreeSort(TreeNode treeNode)
        {
            organizeList += (treeNode.Tag as DataRow)[BaseOrganizeEntity.FieldId].ToString() + ",";
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                this.GetTreeSort(treeNode.Nodes[i]);
            }
        }

        #region private string[] GetTreeSort() 获得树型机构的排序顺序
        /// <summary>
        /// 获得树型机构的排序顺序
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetTreeSort()
        {
            string[] ids = new string[0];
            if (UserInfo.IsAdministrator)
            {
                this.organizeList = string.Empty;
                for (int i = 0; i < this.tvOrganize.Nodes.Count; i++)
                {
                    this.GetTreeSort(this.tvOrganize.Nodes[i]);
                }
                if (this.organizeList.Length > 0)
                {
                    this.organizeList = this.organizeList.Substring(0, this.organizeList.Length - 1);
                    ids = this.organizeList.Split(',');
                }
            }
            return ids;
        }
        #endregion

        private void mItmSetSortCode_Click(object sender, EventArgs e)
        {
            // 2012.04.23 Pcsky 加入提醒对话框
            if (MessageBox.Show(AppMessage.MSG0301, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                if (this.permissionEdit)
                {
                    DotNetService.Instance.OrganizeService.BatchSetSortCode(UserInfo, this.GetTreeSort());
                }
                // 设置鼠标默认状态，原来的光标状态
                this.Cursor = holdCursor;
            }
        }

        private void mItmFrmOrganizeCodeBuilder_Click(object sender, EventArgs e)
        {
            FrmOrganizeCodeBuilder FrmOrganizeCodeBuilder = new FrmOrganizeCodeBuilder(this.tvOrganize);
            if (FrmOrganizeCodeBuilder.ShowDialog(this) == DialogResult.OK)
            {
                this.GetOrganizeList();
            }
        }

        private void grdOrganize_Click(object sender, EventArgs e)
        {
            this.LastControl = this.grdOrganize;
        }

        private void grdOrganize_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            /*
            // 判断是否有删除权限
            if (!this.permissionDelete)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                // 是否有子节点不允许删除
                BaseInterfaceLogic.FindTreeNode(this.tvOrganize, this.EntityId);
                if (BaseInterfaceLogic.TargetNode != null)
                {
                    if (!BaseInterfaceLogic.NodeAllowDelete(BaseInterfaceLogic.TargetNode))
                    {
                        MessageBox.Show(AppMessage.Format(AppMessage.MSG0035, BaseInterfaceLogic.TargetNode.Text), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                    }
                    else
                    {
                        if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                        {
                            e.Cancel = true;
                        }
                        else
                        {
                            DotNetService.Instance.OrganizeAdminService.Delete(UserInfo, this.EntityId);
                        }
                    }
                }
            }
            */
        }

        private void grdOrganize_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnEdit.PerformClick();
        }

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

        #region private string[] GetSelecteIds() 获得已被选择的部门主键数组
        /// <summary>
        /// 获得已被选择的部门主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelecteIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdOrganize, BaseOrganizeEntity.FieldId, "colSelected", true);
        }
        #endregion

        private void grdOrganize_Sorted(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (this.permissionEdit)
            {
                string[] sequence = DotNetService.Instance.SequenceService.GetBatchSequence(UserInfo, BaseOrganizeEntity.TableName, this.DTOrganizeList.DefaultView.Count);
                int i = 0;
                foreach (DataRowView dataRowView in this.DTOrganizeList.DefaultView)
                {
                    dataRowView.Row[BaseOrganizeEntity.FieldSortCode] = sequence[i];
                    i++;
                }
                // 控制导航按钮
                this.SetSortButton(false);
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in this.grdOrganize.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }
            this.LastControl = this.grdOrganize;
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in this.grdOrganize.Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false);
            }
            this.LastControl = this.grdOrganize;
        }

        #region private void Add(bool root) 添加组织机构
        /// <summary>
        /// 添加组织机构
        /// </summary>
        /// <returns>主键</returns>
        public string Add(bool root)
        {
            string returnValue = string.Empty;
            FrmOrganizeAdd frmOrganizeAdd;
            if (this.LastControl == this.tvOrganize)
            {
                if ((root) || (this.ParentEntityId.Length == 0) || (this.tvOrganize.SelectedNode == null))
                {
                    frmOrganizeAdd = new FrmOrganizeAdd();
                }
                else
                {
                    frmOrganizeAdd = new FrmOrganizeAdd(this.ParentEntityId, this.tvOrganize.SelectedNode.Text);
                }
            }
            else
            {
                DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdOrganize);
                if ((root) || dataRow == null)
                {
                    frmOrganizeAdd = new FrmOrganizeAdd();
                }
                else
                {
                    frmOrganizeAdd = new FrmOrganizeAdd(dataRow[BaseOrganizeEntity.FieldId].ToString(), dataRow[BaseOrganizeEntity.FieldFullName].ToString());
                }
            }
            frmOrganizeAdd.OnAdded += new FrmOrganizeAdd.OnAddedEventHandler(OnAdded);
            if (frmOrganizeAdd.ShowDialog(this) == DialogResult.OK)
            {
                //returnValue = frmOrganizeAdd.EntityId;
                //string fullName = frmOrganizeAdd.FullName;
                //string parentId = frmOrganizeAdd.ParentId;
                //// tvOrganize 中增加结点，这里方法写得不好，应该重新刷新父亲节点，所有当前节点的子节点都加载一下就可以了
                //TreeNode newNode = new TreeNode();
                //newNode.Text = fullName;
                //newNode.Tag = returnValue;
                //TreeNode parentNode = null;
                //if (!root && !string.IsNullOrEmpty(parentId))
                //{
                //    BaseInterfaceLogic.FindTreeNode(this.tvOrganize, parentId);
                //    parentNode = BaseInterfaceLogic.TargetNode;
                //}
                //BaseInterfaceLogic.AddTreeNode(this.tvOrganize, newNode, parentNode);
                // 绑定grdOrganize数据
                this.GetOrganizeList();

                if ((BaseSystemInfo.ClientCache) && (this.chkRefresh.Checked))
                {
                    ClientCache.Instance.DTOrganize = null;
                }
                // 使新增加的数据在grdModule中可见
                if (this.DTOrganizeList.Rows.Count > 0)
                    this.grdOrganize.FirstDisplayedScrollingRowIndex = this.DTOrganizeList.Rows.Count - 1;
            }
            return returnValue;
        }
        #endregion

        //public string AddStaff()
        //{
        //    return this.Add(false);
        //}

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 添加组织机构
            this.Add(false);
        }

        #region private void EditTree() 编辑组织机构
        /// <summary>
        /// 编辑组织机构
        /// </summary>
        private void EditTree()
        {
            if (this.tvOrganize.SelectedNode == null)
            {
                return;
            }
            FrmOrganizeEdit frmOrganizeEdit = new FrmOrganizeEdit((this.tvOrganize.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString());
            if (frmOrganizeEdit.ShowDialog(this) == DialogResult.OK)
            {
                if ((BaseSystemInfo.ClientCache) && (this.chkRefresh.Checked))
                {
                    ClientCache.Instance.DTOrganize = null;
                }
                // 编辑节点
                this.tvOrganize.SelectedNode.Text = frmOrganizeEdit.FullName;
                // 绑定grdOrganize
                this.GetOrganizeList();
                if (this.DTOrganizeList.Rows.Count > 0)
                {
                    this.grdOrganize.FirstDisplayedScrollingRowIndex = this.DTOrganizeList.Rows.Count - 1;
                }
            }
        }
        #endregion

        #region private void EditGrid() 编辑组织机构
        /// <summary>
        /// 编辑组织机构
        /// </summary>
        private void EditGrid()
        {
            if (this.grdOrganize.RowCount == 0)
            {
                // 提高用户体验，如果grdPermission没有数据则修改tvPermissiion 中的selectedNode
                this.LastControl = this.tvOrganize;
                return;
            }
            FrmOrganizeEdit frmOrganizeEdit = new FrmOrganizeEdit(this.EntityId);
            if (frmOrganizeEdit.ShowDialog(this) == DialogResult.OK)
            {
                if ((BaseSystemInfo.ClientCache) && (this.chkRefresh.Checked))
                {
                    ClientCache.Instance.DTOrganize = null;
                }

                BaseInterfaceLogic.FindTreeNode(this.tvOrganize, this.EntityId);
                TreeNode selectNode = BaseInterfaceLogic.TargetNode;
                selectNode.Text = frmOrganizeEdit.FullName;
                TreeNode oldParentNode = selectNode.Parent;
                BaseInterfaceLogic.FindTreeNode(this.tvOrganize, frmOrganizeEdit.ParentId);
                TreeNode parentNode = BaseInterfaceLogic.TargetNode;
                // 编辑节点
                BaseInterfaceLogic.EditTreeNode(this.tvOrganize, selectNode, parentNode);
                // 绑定屏幕数据
                this.GetOrganizeList();
                if (this.DTOrganizeList.Rows.Count > 0)
                    this.grdOrganize.FirstDisplayedScrollingRowIndex = this.DTOrganizeList.Rows.Count - 1;
            }
        }
        #endregion

        /// <summary>
        /// 编辑
        /// </summary>
        public void Edit()
        {
            // 编辑组织机构
            if (this.LastControl == this.grdOrganize)
            {
                this.EditGrid();
            }
            if (this.LastControl == this.tvOrganize)
            {
                this.EditTree();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Edit();
        }

        #region private bool CheckInputMove(string selectedId) 检查能否移动
        /// <summary>
        /// 检查能否移动
        /// </summary>
        /// <returns>能否移动到目标位置</returns>
        private bool CheckInputMove(string selectedId)
        {
            bool returnValue = true;
            // 单个移动检查
            if (this.LastControl == this.tvOrganize)
            {
                BaseInterfaceLogic.FindTreeNode(this.tvOrganize, this.parentEntityId);
                TreeNode treeNode = BaseInterfaceLogic.TargetNode;
                BaseInterfaceLogic.FindTreeNode(this.tvOrganize, selectedId);
                TreeNode targetTreeNode = BaseInterfaceLogic.TargetNode;
                if (treeNode != null)
                {
                    if (!BaseInterfaceLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode))
                    {
                        MessageBox.Show(AppMessage.Format(AppMessage.MSG0036, treeNode.Text, targetTreeNode.Text), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        returnValue = false;
                    }
                }
            }
            // 进行批量检查
            if (this.LastControl == this.grdOrganize)
            {
                BaseInterfaceLogic.FindTreeNode(this.tvOrganize, selectedId);
                TreeNode targetTreeNode = BaseInterfaceLogic.TargetNode;
                string[] SelecteIds = this.GetSelecteIds();
                for (int i = 0; i < SelecteIds.Length; i++)
                {
                    BaseInterfaceLogic.FindTreeNode(this.tvOrganize, SelecteIds[i]);
                    TreeNode treeNode = BaseInterfaceLogic.TargetNode;
                    if (!BaseInterfaceLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode))
                    {
                        MessageBox.Show(AppMessage.Format(AppMessage.MSG0036, treeNode.Text, targetTreeNode.Text), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        returnValue = false;
                        break;
                    }
                }
            }
            return returnValue;
        }
        #endregion

        #region private void BatchMove() 批量移动
        /// <summary>
        /// 批量移动
        /// </summary>
        private void BatchMove()
        {
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdOrganize, "colSelected"))
            {
                FrmOrganizeSelect frmOrganizeSelect = new FrmOrganizeSelect(this.ParentEntityId, this.chkInnerOrganize.Checked);
                if (UserInfo.IsAdministrator)
                {
                    frmOrganizeSelect.AllowNull = true;
                }
                else
                {
                    frmOrganizeSelect.AllowNull = false;
                    frmOrganizeSelect.PermissionItemScopeCode = this.PermissionItemScopeCode;
                }
                frmOrganizeSelect.OnButtonConfirmClick += new BaseBusinessLogic.CheckMoveEventHandler(CheckInputMove);
                if (frmOrganizeSelect.ShowDialog() == DialogResult.OK)
                {
                    // 设置鼠标繁忙状态，并保留原先的状态
                    Cursor holdCursor = this.Cursor;
                    this.Cursor = Cursors.WaitCursor;
                    this.FormLoaded = false;
                    DotNetService.Instance.OrganizeService.BatchMoveTo(UserInfo, this.GetSelecteIds(), frmOrganizeSelect.SelectedId);
                    if ((BaseSystemInfo.ClientCache) && (this.chkRefresh.Checked))
                    {
                        ClientCache.Instance.DTOrganize = null;
                    }
                    this.ParentEntityId = frmOrganizeSelect.SelectedId;
                    // 调用事件
                    string[] tags = this.GetSelecteIds();
                    DotNetService.Instance.OrganizeService.BatchMoveTo(UserInfo, tags, frmOrganizeSelect.SelectedId);
                    // 移动treeNode
                    BaseInterfaceLogic.FindTreeNode(this.tvOrganize, frmOrganizeSelect.SelectedId);
                    TreeNode parentNode = BaseInterfaceLogic.TargetNode;
                    if (tags.Length > 0)
                    {
                        for (int i = 0; i < tags.Length; i++)
                        {
                            BaseInterfaceLogic.FindTreeNode(this.tvOrganize, tags[i]);
                            BaseInterfaceLogic.MoveTreeNode(this.tvOrganize, BaseInterfaceLogic.TargetNode, parentNode);
                        }
                    }
                    // 绑定grdOrganize
                    this.GetOrganizeList();
                    if (this.DTOrganizeList.Rows.Count > 0)
                        this.grdOrganize.FirstDisplayedScrollingRowIndex = this.DTOrganizeList.Rows.Count - 1;
                    this.FormLoaded = true;
                    // 设置鼠标默认状态，原来的光标状态
                    this.Cursor = holdCursor;
                }
            }
        }
        #endregion

        #region private void SingleMove() 单个记录移动
        /// <summary>
        /// 单个记录移动
        /// </summary>
        public void SingleMove()
        {
            if (String.IsNullOrEmpty(this.ParentEntityId))
            {
                return;
            }
            FrmOrganizeSelect frmOrganizeSelect = new FrmOrganizeSelect(this.ParentEntityId, this.chkInnerOrganize.Checked);
            if (UserInfo.IsAdministrator)
            {
                frmOrganizeSelect.AllowNull = true;
            }
            else
            {
                frmOrganizeSelect.AllowNull = false;
                frmOrganizeSelect.PermissionItemScopeCode = this.PermissionItemScopeCode;
            }
            frmOrganizeSelect.OnButtonConfirmClick += new BaseBusinessLogic.CheckMoveEventHandler(CheckInputMove);
            if (frmOrganizeSelect.ShowDialog() == DialogResult.OK)
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                this.FormLoaded = false;
                DotNetService.Instance.OrganizeService.MoveTo(UserInfo, this.CurrentEntityId, frmOrganizeSelect.SelectedId);
                if (!BaseSystemInfo.ClientCache)
                {
                    ClientCache.Instance.DTOrganize = null;
                }
                this.FormLoaded = false;
                if ((BaseSystemInfo.ClientCache) && (this.chkRefresh.Checked))
                {
                    ClientCache.Instance.DTOrganize = null;
                }
                // 移动treeNode
                BaseInterfaceLogic.FindTreeNode(this.tvOrganize, frmOrganizeSelect.SelectedId);
                BaseInterfaceLogic.MoveTreeNode(this.tvOrganize, this.tvOrganize.SelectedNode, BaseInterfaceLogic.TargetNode);
                // 绑定grdOrganize
                this.GetOrganizeList();
                if (this.DTOrganizeList.Rows.Count > 0)
                    this.grdOrganize.FirstDisplayedScrollingRowIndex = this.DTOrganizeList.Rows.Count - 1;
                this.FormLoaded = true;
                // 设置鼠标默认状态，原来的光标状态
                this.Cursor = holdCursor;
            }
        }
        #endregion

        #region private void MoveObject() 移动数据
        /// <summary>
        /// 移动数据
        /// </summary>
        private void MoveObject()
        {
            if (this.LastControl == this.grdOrganize)
            {
                this.BatchMove();
            }
            if (this.LastControl == this.tvOrganize)
            {
                this.SingleMove();
            }
        }
        #endregion

        private void btnMove_Click(object sender, EventArgs e)
        {
            // 移动数据
            this.MoveObject();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //// 导出Excel
            ////string exportFileName = this.Text + ".csv";
            //string exportFileName = this.Text + ".xls";
            //this.ExportExcel(this.grdOrganize, @"\Modules\Export\", exportFileName);

            // 全部导出Excel
            DataTable dataTable = DotNetService.Instance.OrganizeService.GetDataTable(UserInfo);
            dataTable.DefaultView.Sort = BaseOrganizeEntity.FieldParentId + ", " + BaseOrganizeEntity.FieldSortCode;
            string exportFileName = this.Text + ".xls";
            this.ExportExcel(this.grdOrganize, dataTable.DefaultView, @"\Modules\Export\", exportFileName);
        }

        #region private bool CheckInputBatchDelete() 检查输入的有效性
        /// <summary>
        /// 检查删除选择项的有效性
        /// </summary>
        /// <returns>有效</returns>
        private bool CheckInputBatchDelete()
        {
            bool returnValue = false;

            foreach (DataGridViewRow dgvRow in grdOrganize.Rows)
            {
                DataRow dataRow = (dgvRow.DataBoundItem as DataRowView).Row;
                if ((System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false))
                {
                    // 有记录被选中了
                    returnValue = true;
                    // break;
                    // 是否有子节点
                    string id = dataRow[BaseOrganizeEntity.FieldId].ToString();
                    BaseInterfaceLogic.FindTreeNode(this.tvOrganize, id);
                    if (BaseInterfaceLogic.TargetNode != null)
                    {
                        if (!BaseInterfaceLogic.NodeAllowDelete(BaseInterfaceLogic.TargetNode))
                        {
                            MessageBox.Show(AppMessage.Format(AppMessage.MSG0035, BaseInterfaceLogic.TargetNode.Text), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            returnValue = false;
                            return returnValue;
                        }
                    }
                }
            }
            if (!returnValue)
            {
                MessageBox.Show(AppMessage.MSGC023, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return returnValue;
        }
        #endregion

        #region public override int BatchDelete() 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <returns>影响行数</returns>
        public override int BatchDelete()
        {
            int returnValue = 0;
            if (this.CheckInputBatchDelete())
            {
                if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    if (!BaseSystemInfo.ClientCache)
                    {
                        ClientCache.Instance.DTOrganize = null;
                    }
                    this.FormLoaded = false;
                    // 绑定数据
                    string[] tags = this.GetSelecteIds();
                    returnValue = DotNetService.Instance.OrganizeService.SetDeleted(UserInfo, tags);
                    if ((BaseSystemInfo.ClientCache) && (this.chkRefresh.Checked))
                    {
                        ClientCache.Instance.DTOrganize = null;
                    }
                    // 获取列表
                    this.DTOrganize = DotNetService.Instance.OrganizeService.GetDataTable(UserInfo);
                    // 在tree删除相应的节点
                    BaseInterfaceLogic.BatchRemoveNode(this.tvOrganize, tags);
                    // 绑定grdModule
                    this.GetOrganizeList();
                    this.FormLoaded = true;
                }
            }
            return returnValue;
        }
        #endregion

        #region private int SingleDelete() 单个记录删除
        /// <summary>
        /// 单个记录删除
        /// </summary>
        /// <returns>影响行数</returns>
        public int SingleDelete()
        {
            int returnValue = 0;
            if (this.tvOrganize.SelectedNode == null)
            {
                return returnValue;
            }
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            this.FormLoaded = false;
            if (!BaseInterfaceLogic.NodeAllowDelete(this.tvOrganize.SelectedNode))
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0035, this.tvOrganize.SelectedNode.Text), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    returnValue = DotNetService.Instance.OrganizeService.SetDeleted(UserInfo, new String[] { this.ParentEntityId });
                    if ((BaseSystemInfo.ClientCache) && (this.chkRefresh.Checked))
                    {
                        ClientCache.Instance.DTOrganize = null;
                    }
                    if (returnValue > 0)
                    {
                        string[] ids = null;
                        if (this.tvOrganize.SelectedNode.Tag is DataRow)
                        {
                            ids = new String[] {(this.tvOrganize.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString() };
                        }
                        else
                        {
                            ids = new String[] { this.tvOrganize.SelectedNode.Tag.ToString() };
                        }
                        BaseInterfaceLogic.BatchRemoveNode(this.tvOrganize, ids);
                        // 绑定grdOrganize
                        this.GetOrganizeList();
                    }
                }
            }
            // 设置鼠标默认状态，原来的光标状态
            this.FormLoaded = true;
            this.Cursor = holdCursor;
            return returnValue;
        }
        #endregion

        #region public int Delete() 删除数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// 
        public int Delete()
        {
            int returnValue = 0;
            if (this.LastControl == this.grdOrganize)
            {
                // 检查批量输入的有效性
                returnValue = this.BatchDelete();
            }
            if (this.LastControl == this.tvOrganize)
            {
                returnValue = this.SingleDelete();
            }
            return returnValue;
        }
        #endregion

        private void btnBatchDelete_Click(object sender, EventArgs e)
        {
            // 删除数据
            this.Delete();
        }

        #region private void BatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private void BatchSave()
        {
            this.FormLoaded = false;
            DotNetService.Instance.OrganizeService.BatchSave(UserInfo, this.DTOrganizeList);
            if (!BaseSystemInfo.ClientCache)
            {
                ClientCache.Instance.DTOrganize = null;
            }
            // 绑定数据
            this.BindData(true);
            this.FormLoaded = true;
            if (BaseSystemInfo.ShowInformation)
            {
                // 批量保存，进行提示
                MessageBox.Show(AppMessage.MSG0011, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            // 检查批量输入的有效性
            if (BaseInterfaceLogic.CheckInputModifyAnyOne(this.DTOrganizeList))
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
                    this.DTOrganizeList.AcceptChanges();
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

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mItmUserAdd_Click(object sender, EventArgs e)
        {
            // 用反射获得窗体
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmUserAdd";
            Form frmUserAdd = CacheManager.Instance.GetForm(assemblyName, formName);
            if (this.tvOrganize.SelectedNode != null)
            {
                string DepartmentId = string.Empty;
                string departmentFullName = string.Empty;
                string CompanyId = string.Empty;
                string companyFullName = string.Empty;
                TreeNode treeNode = this.tvOrganize.SelectedNode;
                if (BaseBusinessLogic.GetProperty(ClientCache.Instance.DTOrganize, (treeNode.Tag as DataRow)[BaseOrganizeEntity.FieldId].ToString(), BaseOrganizeEntity.FieldCategory) != OrganizeCategory.Company.ToString())
                {
                    DepartmentId = (treeNode.Tag as DataRow)[BaseOrganizeEntity.FieldId].ToString();
                    departmentFullName = treeNode.Text;
                }
                while (treeNode.Parent != null)
                {
                    if (BaseBusinessLogic.GetProperty(ClientCache.Instance.DTOrganize, (treeNode.Tag as DataRow)[BaseOrganizeEntity.FieldId].ToString(), BaseOrganizeEntity.FieldCategory) == OrganizeCategory.Company.ToString())
                    {
                        CompanyId = (treeNode.Tag as DataRow)[BaseOrganizeEntity.FieldId].ToString();
                        companyFullName = treeNode.Text;
                        break;
                    }
                    treeNode = treeNode.Parent;
                }
                ((FrmUserAdd)frmUserAdd).CompanyId = CompanyId;
                ((FrmUserAdd)frmUserAdd).CompanyName = companyFullName;
                ((FrmUserAdd)frmUserAdd).DepartmentId = DepartmentId;
                ((FrmUserAdd)frmUserAdd).DepartmentName = departmentFullName;

            }
            frmUserAdd.ShowDialog(this);
            //if (frmUserAdd.ShowDialog(this) == DialogResult.OK)
            //{
            //    this.FormLoaded = false;

            //    // 绑定屏幕数据
            //    this.BindData(true);
            //    this.FormLoaded = true;
            //}
        }

        private void tvOrganize_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvOrganize.GetNodeAt(e.X, e.Y) != null)
            {
                tvOrganize.SelectedNode = tvOrganize.GetNodeAt(e.X, e.Y);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmOrganizeAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BaseInterfaceLogic.IsModfiedAnyOne(this.DTOrganizeList))
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