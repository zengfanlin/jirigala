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
    /// FrmPermissionItemAdmin
    /// 权限管理
    ///		
    /// 修改记录
    ///     2011.10.24 版本：1.2 张广梁    优化添加、删除、编译和移动操作。
    ///     2009.08.27 版本：1.1 JiRiGaLa 导出按钮的错误进行修正。
    ///     2008.05.22 版本：1.0 JiRiGaLa 权限管理页面。
    ///		
    /// 版本：1.2
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2009.08.27</date>
    /// </author> 
    /// </summary>    
    public partial class FrmPermissionItemAdmin : BaseForm, IBaseForm
    {
        /// <summary>
        /// 权限项DataTable
        /// </summary>
        private DataTable DTPermission = new DataTable(BasePermissionItemEntity.TableName);

        /// <summary>
        /// 权限项列表DataTable
        /// </summary>
        private DataTable DTPermissionList = new DataTable(BasePermissionItemEntity.TableName);

        /// <summary>
        /// 移动功能选择窗口
        /// </summary>
        FrmPermissionSelect frmPermissionItemSelect = null; 

        /// <summary>
        /// 记录最后点击的控件
        /// </summary>
        private System.Windows.Forms.Control LastControl = null;

        /// <summary>
        /// 添加根权限
        /// </summary>
        private bool permissionAddRoot = false;

        /// <summary>
        /// 移动权限
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

        public event SetControlStateEventHandler OnButtonStateChange;

        /// <summary>
        /// 权限项主键，作为grdPermission 中记录的父主键
        /// </summary>
        private string parentEntityId = string.Empty;

        /// <summary>
        /// 权限项主键，作为grdPermission 中记录的父主键
        /// </summary>
        public string ParentEntityId
        {
            get
            {
                if ((this.tvPermission.SelectedNode != null) && (this.tvPermission.SelectedNode.Tag != null))
                {
                    this.parentEntityId = (this.tvPermission.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
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
        /// 权限项主键，grdPermission中的选择项Id
        /// </summary>
        public override string EntityId
        {
            get
            {
                return BaseInterfaceLogic.GetDataGridViewEntityId(this.grdPermission, BasePermissionItemEntity.FieldId);
            }
        }

        /// <summary>
        /// 当前选中的节点，树或者表格上
        /// </summary>
        private string currentEntityId = string.Empty;
        /// <summary>
        /// 当前选中的节点，树或者表格上
        /// </summary>
        public string CurrentEntityId
        {
            get
            {
                if (this.LastControl == this.tvPermission)
                {
                    this.currentEntityId = this.ParentEntityId;
                }
                else
                {
                    this.currentEntityId = this.EntityId;
                }
                return this.currentEntityId;
            }
            set { this.currentEntityId = value; }
        }

        public FrmPermissionItemAdmin()
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
            this.mItmAdd.Enabled = false;
            this.mItmEdit.Enabled = false;
            this.mItmMove.Enabled = false;
            this.mItmDelete.Enabled = false;
            this.mItmModulePermission.Enabled = false;
            this.mItmSetSortCode.Enabled = false;
            this.btnAdd.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnMove.Enabled = false;
            this.btnBatchDelete.Enabled = false;
            this.btnModulePermission.Enabled = false;
            this.btnBatchSave.Enabled = false;
            this.btnRolePermissionItem.Enabled = false;
            this.btnUserPermissionItem.Enabled = false;
            this.btnExport.Enabled = false;

            this.btnSelectAll.Enabled = false;
            this.btnInvertSelect.Enabled = false;

            this.btnUserPermissionItem.Visible = BaseSystemInfo.UseUserPermission;            
            // 检查添加权限
            this.btnAdd.Enabled = this.permissionAdd;
            if ((this.DTPermission.DefaultView.Count >= 1) || (this.tvPermission.Nodes.Count > 0))
            {
                this.mItmAdd.Enabled = this.permissionAdd;
                this.mItmEdit.Enabled = this.permissionEdit;
                this.mItmMove.Enabled = this.permissionMove;
                this.mItmDelete.Enabled = this.permissionDelete;
                this.mItmModulePermission.Enabled = this.permissionEdit;
                this.mItmPermissionItems.Enabled = this.permissionEdit;
                // 这些都是属于管理权限的杂项，Admin 权限不能轻易给别人
                this.mItmSetSortCode.Enabled = this.permissionMove;
            }
            this.mItmRootAdd.Enabled = this.permissionAddRoot;
            if ((this.grdPermission.DataSource != null) && (this.grdPermission.RowCount > 0))
            {
                this.btnEdit.Enabled = this.permissionEdit;
                this.btnMove.Enabled = this.permissionEdit;
                this.btnModulePermission.Enabled = this.permissionEdit;
                this.btnBatchDelete.Enabled = this.permissionDelete;
                this.btnBatchSave.Enabled = this.permissionEdit;        
            }
            if (this.tvPermission.Nodes.Count > 0)
            {
                this.btnEdit.Enabled = this.permissionEdit;
                this.btnMove.Enabled = this.permissionEdit;
                this.btnModulePermission.Enabled = this.permissionEdit;
                this.btnBatchDelete.Enabled = this.permissionDelete;

                this.btnRolePermissionItem.Enabled = this.permissionAccredit;
                this.btnUserPermissionItem.Enabled = this.permissionAccredit;
                this.btnExport.Enabled = this.permissionExport;
                
            }
            // 位置顺序改变按钮部分
            if (this.DTPermissionList.DefaultView.Count > 1)
            {
                this.SetSortButton(this.permissionEdit);
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
            if ((this.grdPermission .RowCount >= 1))
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
            // 模块访问权限
            this.permissionAccess = this.IsModuleAuthorized(this.Name);
            this.permissionAdd = this.IsAuthorized("PermissionItemAdmin.Add");        // 新增权限
            this.permissionAddRoot = this.IsAuthorized("PermissionItemAdmin.AddRoot");    // 添加根权限
            this.permissionEdit = this.IsAuthorized("PermissionItemAdmin.Edit");       // 编辑权限
            this.permissionMove = this.IsAuthorized("PermissionItemAdmin.Move");       // 移动权限
            this.permissionDelete = this.IsAuthorized("PermissionItemAdmin.Delete");     // 删除权限
            this.permissionExport = this.IsAuthorized("PermissionItemAdmin.Export");     // 导出数据
            this.permissionAccredit = this.IsAuthorized("UserAdmin.Accredit");
        }
        #endregion

        #region private void BindData(bool reloadTree) 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        /// <param name="reloadTree">重新加载树</param>
        private void BindData(bool reloadTree)
        {
            // 加载树的主键
            if (reloadTree)
            {
                this.LoadTree();
                if (this.tvPermission.SelectedNode == null)
                {
                    if (this.tvPermission.Nodes.Count > 0)
                    {
                        if (this.parentEntityId.Length == 0)
                        {
                            this.tvPermission.SelectedNode = this.tvPermission.Nodes[0];
                        }
                        else
                        {
                            BaseInterfaceLogic.FindTreeNode(this.tvPermission, this.parentEntityId);
                            if (BaseInterfaceLogic.TargetNode != null)
                            {
                                this.tvPermission.SelectedNode = BaseInterfaceLogic.TargetNode;
                                // 展开当前选中节点的所有父节点
                                BaseInterfaceLogic.ExpandTreeNode(this.tvPermission);
                            }
                        }
                        if (this.tvPermission.SelectedNode != null)
                        {
                            // 让选中的节点可视，并用展开方式
                            this.tvPermission.SelectedNode.Expand();
                            this.tvPermission.SelectedNode.EnsureVisible();
                        }
                    }
                }

            }
            if (this.ParentEntityId.Length > 0)
            {
                if (reloadTree)
                {
                    this.GetPermissionList();
                }
            }
            if (!this.permissionEdit)
            {
                // 只读属性设置
                this.grdPermission.Columns["colSelected"].ReadOnly    = !this.permissionEdit;
                this.grdPermission.Columns["colFullName"].ReadOnly    = !this.permissionEdit;
                this.grdPermission.Columns["colIsScope"].ReadOnly     = !this.permissionEdit;
                this.grdPermission.Columns["colDescription"].ReadOnly = !this.permissionEdit;
                // 修改背景颜色
                this.grdPermission.Columns["colFullName"].DefaultCellStyle.BackColor    = Color.White;
                this.grdPermission.Columns["colIsScope"].DefaultCellStyle.BackColor = Color.White;
                this.grdPermission.Columns["colDescription"].DefaultCellStyle.BackColor = Color.White;
            }
            // 设置按钮状态
            this.SetControlState();
        }
        #endregion

        #region private void BindItemDetails() 绑定下拉筐数据
        /// <summary>
        /// 绑定下拉筐数据
        /// </summary>
        private void BindItemDetails()
        {
            // 绑定职位数据，这里需要考虑屏幕刷新、批量保存时的效果问题
            if (this.cmbSystem.Items.Count == 0)
            {
                DataTable dataTable = DotNetService.Instance.ItemDetailsService.GetDataTable(UserInfo, "ItemsSystem");
                DataRow dataRow = dataTable.NewRow();
                dataTable.Rows.InsertAt(dataRow, 0);
                this.cmbSystem.DisplayMember = BaseItemDetailsEntity.FieldItemName;
                this.cmbSystem.ValueMember = BaseItemDetailsEntity.FieldItemValue;
                this.cmbSystem.DataSource = dataTable.DefaultView;
            }
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.BindItemDetails();
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdPermission);
            // 获取操作权限项定义数据
            // this.DTPermission = DotNetService.Instance.PermissionItemService.GetDataTable(UserInfo);
            this.DTPermission = this.GetPermissionItemScop(this.PermissionItemScopeCode);
            this.DTPermission.DefaultView.Sort = BasePermissionItemEntity.FieldSortCode;
            // 绑定屏幕数据
            this.BindData(true);
        }
        #endregion

        #region private void GetPermissionList() 获得子部门列表
        /// <summary>
        /// 获得子部门列表
        /// </summary>
        private void GetPermissionList()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            this.DTPermissionList = DotNetService.Instance.PermissionItemService.GetDataTableByParent(UserInfo, this.ParentEntityId);
            this.grdPermission.AutoGenerateColumns = false;
            this.DTPermissionList.DefaultView.Sort = BasePermissionItemEntity.FieldSortCode;
            this.grdPermission.DataSource = this.DTPermissionList.DefaultView;
            // 设置排序按钮
            this.ucTableSort.DataBind(this.grdPermission, this.permissionEdit);
            // 设置按钮状态
            this.SetControlState();
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }
        #endregion

        #region private void LoadTree() 加载树的主键
        /// <summary>
        /// 加载树的主键
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvPermission.BeginUpdate();
            this.tvPermission.Nodes.Clear();
            TreeNode treeNode = new TreeNode();
            this.LoadTreePermission(treeNode);
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvPermission.EndUpdate();
        }
        #endregion

        #region private void LoadTreePermission(TreeNode treeNode) 加载组织机构树的主键
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreePermission(TreeNode treeNode)
        {
            BaseInterfaceLogic.LoadTreeNodes(this.DTPermission, BasePermissionItemEntity.FieldId, BasePermissionItemEntity.FieldParentId, BasePermissionItemEntity.FieldFullName, this.tvPermission, treeNode);
        }
        #endregion

        private void tvPermission_Click(object sender, EventArgs e)
        {
            this.LastControl = this.tvPermission;
            if (this.tvPermission.SelectedNode == null)
            {
                this.tvPermission.ContextMenuStrip = null;
            }
            else
            {
                this.tvPermission.ContextMenuStrip = this.cMnuPermission;
            }
        }

        private void tvPermission_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.FormLoaded)
            {
                if (this.ActiveControl == this.tvPermission)
                {
                    this.parentEntityId = (this.tvPermission.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                    if (this.ParentEntityId.Length > 0)
                    {
                        this.GetPermissionList();
                    }
                }
            }
        }

        private void tvPermission_DragEnter(object sender, DragEventArgs e)
        {
            // 拖动效果设成移动
            e.Effect = DragDropEffects.Move;
        }

        private void tvPermission_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (this.permissionEdit)
            {
                // 开始进行拖放操作，并将拖放的效果设置成移动。
                this.DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void tvPermission_DragDrop(object sender, DragEventArgs e)
        {
            // 定义一个中间变量
            TreeNode treeNode;
            //判断拖动的是否为TreeNode类型，不是的话不予处理
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                //定义一个位置点的变量，保存当前光标所处的坐标点
                Point point;
                //拖放的目标节点
                TreeNode targetTreeNode;
                //获取当前光标所处的坐标
                point = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                //根据坐标点取得处于坐标点位置的节点
                targetTreeNode = ((TreeView)sender).GetNodeAt(point);
                //获取被拖动的节点
                treeNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                //判断拖动的节点与目标节点是否是同一个,同一个不予处理
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
                    DotNetService.Instance.PermissionItemService.MoveTo(UserInfo, (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString(), (targetTreeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString());
                    // 往目标节点中加入被拖动节点的一份克隆
                    targetTreeNode.Nodes.Add((TreeNode)treeNode.Clone());
                    // 将被拖动的节点移除
                    treeNode.Remove();
                }
            }
        }

        private void mItmAdd_Click(object sender, EventArgs e)
        {
            this.btnAdd.PerformClick();
        }

        private void mItmRootAdd_Click(object sender, EventArgs e)
        {
            this.Add(true);
        }

        private void mItmEdit_Click(object sender, EventArgs e)
        {
            this.EditTree();
        }

        private void mItmMove_Click(object sender, EventArgs e)
        {
            this.SingleMove();
        }

        private void mItmPermissionItemsClick(object sender, EventArgs e)
        {
            FrmSetPermissionItem frmPermissionItem = new FrmSetPermissionItem(this.CurrentEntityId);
            frmPermissionItem.ShowDialog();
        } 

        private void mItmDelete_Click(object sender, EventArgs e)
        {
            // 删除事件
            this.SingleDelete();
        }

        private void mItmModulePermission_Click(object sender, EventArgs e)
        {
            // 权限挂接
            this.ModuleSetPermission();
        }

        string PermissionList = string.Empty;

        private void GetTreeSort(TreeNode treeNode)
        {
            PermissionList += (treeNode.Tag as DataRow)[BaseOrganizeEntity.FieldId].ToString() + ",";
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                this.GetTreeSort(treeNode.Nodes[i]);
            }
        }

        #region private string[] GetTreeSort() 获得树型权限项的排序顺序
        /// <summary>
        /// 获得树型机构的排序顺序
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetTreeSort()
        {
            string[] ids = new string[0];
            if (UserInfo.IsAdministrator)
            {
                this.PermissionList = string.Empty;
                for (int i = 0; i < this.tvPermission.Nodes.Count; i++)
                {
                    this.GetTreeSort(this.tvPermission.Nodes[i]);
                }
                if (this.PermissionList.Length > 0)
                {
                    this.PermissionList = this.PermissionList.Substring(0, this.PermissionList.Length - 1);
                    ids = this.PermissionList.Split(',');
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
                    DotNetService.Instance.PermissionItemService.BatchSetSortCode(UserInfo, this.GetTreeSort());
                }
                // 设置鼠标默认状态，原来的光标状态
                this.Cursor = holdCursor;
            }
        }

        private void grdPermission_Click(object sender, EventArgs e)
        {
            this.LastControl = this.grdPermission;
        }

        private void grdPermission_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
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
                BaseInterfaceLogic.FindTreeNode(this.tvPermission, this.EntityId);
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
                            DotNetService.Instance.PermissionAdminService.Delete(UserInfo, this.EntityId);
                        }
                    }
                }
            }
            */
        }

        private void grdPermission_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.permissionEdit)
            {
                this.EditGrid();
            }
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

        private void btnRolePermissionItem_Click(object sender, EventArgs e)
        {
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmRolePermissionItem";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmRoleModulePermission = (Form)Activator.CreateInstance(assemblyType);
            frmRoleModulePermission.ShowDialog(this);
        }

        private void btnUserPermissionItem_Click(object sender, EventArgs e)
        {
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmUserPermissionItem";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmRoleModulePermission = (Form)Activator.CreateInstance(assemblyType);
            frmRoleModulePermission.ShowDialog(this);
        }

        private void btnExportAll_Click(object sender, EventArgs e)
        {
            string exportFileName = this.Text + ".xls";
            this.ExportExcel(this.grdPermission, @"\Modules\Export\", exportFileName);
        }

        private void grdPermission_Sorted(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (this.permissionEdit)
            {
                string[] sequence = DotNetService.Instance.SequenceService.GetBatchSequence(UserInfo, BasePermissionItemEntity.TableName, this.DTPermissionList.DefaultView.Count);
                int i = 0;
                foreach (DataRowView dataRowView in this.DTPermissionList.DefaultView)
                {
                    dataRowView.Row[BasePermissionItemEntity.FieldSortCode] = sequence[i];
                    i++;
                }
                // 控制导航按钮
                this.SetSortButton(false);
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }

        #region private string Add(bool root) 添加组织机构
        /// <summary>
        /// 添加组织机构
        /// </summary>
        /// <returns>主键</returns>
        private string Add(bool root)
        {
            string returnValue = string.Empty;
            FrmPermissionItemAdd frmPermissionItemAdd;
            if (this.LastControl == this.tvPermission)
            {
                if (root||(this.ParentEntityId.Length == 0) || (this.tvPermission.SelectedNode == null))
                {
                    frmPermissionItemAdd = new FrmPermissionItemAdd();
                }
                else
                {
                    frmPermissionItemAdd = new FrmPermissionItemAdd(this.ParentEntityId, this.tvPermission.SelectedNode.Text);
                }
            }
            else
            {
                DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdPermission);
                if (root || dataRow == null)
                {
                    frmPermissionItemAdd = new FrmPermissionItemAdd();
                }
                else
                {
                    frmPermissionItemAdd = new FrmPermissionItemAdd(dataRow[BasePermissionItemEntity.FieldId].ToString(), dataRow[BasePermissionItemEntity.FieldFullName].ToString());
                }
            }
            frmPermissionItemAdd.OnAdded += new FrmPermissionItemAdd.OnAddedEventHandler(OnAdded);
            if (frmPermissionItemAdd.ShowDialog(this) == DialogResult.OK)
            {
                //returnValue = frmPermissionItemAdd.permissionItemEntity.Id.ToString();
                //string fullName = frmPermissionItemAdd.FullName;
                //string parentId = frmPermissionItemAdd.ParentId;
                //// tvModule 中增加结点
                //TreeNode newNode = new TreeNode();
                //newNode.Text = fullName;
                //newNode.Tag = returnValue;
                //TreeNode parentNode = null;
                //if (!root && !string.IsNullOrEmpty(parentId))
                //{
                //    BaseInterfaceLogic.FindTreeNode(this.tvPermission, parentId);
                //    parentNode = BaseInterfaceLogic.TargetNode;
                //}
                //BaseInterfaceLogic.AddTreeNode(this.tvPermission, newNode, parentNode);
                //this.tvPermission.SelectedNode = newNode;
                // 绑定grdModule
                this.GetPermissionList();
                // 使新增加的数据在grdModule中可见
                if (this.DTPermissionList.Rows.Count > 0)
                    this.grdPermission.FirstDisplayedScrollingRowIndex = this.DTPermissionList.Rows.Count - 1;
            }
            return returnValue;
        }
        #endregion

        private bool OnAdded(string parentId, string fullName, string id)
        {

            BaseInterfaceLogic.FindTreeNode(this.tvPermission, BasePermissionItemEntity.FieldId, parentId);
            //if (BaseInterfaceLogic.TargetNode != null)
            //{
            this.tvPermission.SelectedNode = BaseInterfaceLogic.TargetNode;
            //string parentId = parentEntityId;
            // tvModule 中增加结点
            TreeNode newNode = new TreeNode();
            newNode.Text = fullName;
            newNode.Tag = DotNetService.Instance.PermissionItemService.GetDataTableByIds(this.UserInfo, new string[] { id }).Rows[0];
            BaseInterfaceLogic.AddTreeNode(this.tvPermission, newNode, this.tvPermission.SelectedNode);
            this.tvPermission.SelectedNode = newNode;
            // 展开当前选中节点的所有父节点
            BaseInterfaceLogic.ExpandTreeNode(this.tvPermission);
            //}
            return true;
        }

        #region public void AddFromChild(TreeNode newNode,TreeNode parentNode) 从FrmPermissionItemAdd调用该方法添加节点
        /// <summary>
        /// 从FrmPermissionItemAdd调用该方法添加节点
        /// </summary>
        /// <param name="newNode"></param>
        /// <param name="parentNode"></param>
        public void AddFromChild(TreeNode newNode, TreeNode parentNode)
        {
            BaseInterfaceLogic.AddTreeNode(tvPermission, newNode, parentNode);
            // 绑定grdModule
            this.GetPermissionList();
            // 使新增加的数据在grdModule中可见
            if (this.DTPermissionList.Rows.Count > 0)
                this.grdPermission.FirstDisplayedScrollingRowIndex = this.DTPermissionList.Rows.Count - 1;
        }
        #endregion

        public  string Add()
        {
            return this.Add(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 添加组织机构
            this.Add();
        }

        #region private void EditGrid() 编辑权限项
        /// <summary>
        /// 编辑组织机构
        /// </summary>
        private void EditGrid()
        {
            if (this.grdPermission.RowCount == 0)
            {
                // 提高用户体验，如果grdPermission没有数据则修改tvPermissiion 中的selectedNode
                this.LastControl = this.tvPermission;
                return;
            }
            FrmPermissionItemEdit frmPermissionItemEdit = new FrmPermissionItemEdit(this.EntityId);
            if (frmPermissionItemEdit.ShowDialog(this) == DialogResult.OK)
            {
                BaseInterfaceLogic.FindTreeNode(this.tvPermission, this.EntityId);
                TreeNode selectNode = BaseInterfaceLogic.TargetNode;
                selectNode.Text = frmPermissionItemEdit.FullName;
                TreeNode oldParentNode = selectNode.Parent;

                BaseInterfaceLogic.FindTreeNode(this.tvPermission, frmPermissionItemEdit.ParentId);
                TreeNode parentNode = BaseInterfaceLogic.TargetNode;
                // 编辑节点
                BaseInterfaceLogic.EditTreeNode(this.tvPermission, selectNode, parentNode);
                // 绑定grdPermission
                this.GetPermissionList();
                if (this.DTPermissionList.Rows.Count > 0)
                    this.grdPermission.FirstDisplayedScrollingRowIndex = this.DTPermissionList.Rows.Count - 1;
            }
        }
        #endregion

        #region private void EditTree() 编辑权限项
        private void EditTree()
        {
            if (this.tvPermission.SelectedNode == null)
            {
                return;
            }
            FrmPermissionItemEdit frmPermissionItemEdit = new FrmPermissionItemEdit((this.tvPermission.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString());
            if (frmPermissionItemEdit.ShowDialog(this) == DialogResult.OK)
            {
                // 编辑节点
                this.tvPermission.SelectedNode.Text = frmPermissionItemEdit.FullName;
                // 绑定grdPermission
                this.GetPermissionList();
                if (this.DTPermissionList.Rows.Count > 0)
                {
                    this.grdPermission.FirstDisplayedScrollingRowIndex = this.DTPermissionList.Rows.Count - 1;
                }
            }
        }
        #endregion

        #region public void Edit() 编辑
        /// <summary>
        /// 编辑
        /// </summary>
        public void Edit()
        {
            // 编辑组织机构
            if (this.LastControl == this.grdPermission)
            {
               this.EditGrid();
            }
            if (this.LastControl == this.tvPermission)
            {
                this.EditTree();
            }
        }
        #endregion

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Edit();
        }

        #region private bool CheckInputMove() 检查能否移动
        /// <summary>
        /// 检查能否移动
        /// </summary>
        /// <returns>能否移动到目标位置</returns>
        private bool CheckInputMove()
        {
            bool returnValue = true;
            // 单个移动检查
            if (this.LastControl == this.tvPermission)
            {
                BaseInterfaceLogic.FindTreeNode(this.tvPermission, this.parentEntityId);
                TreeNode treeNode = BaseInterfaceLogic.TargetNode;
                BaseInterfaceLogic.FindTreeNode(this.tvPermission, frmPermissionItemSelect.SelectedId);
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
            if (this.LastControl == this.grdPermission)
            {
                BaseInterfaceLogic.FindTreeNode(this.tvPermission, frmPermissionItemSelect.SelectedId);
                TreeNode targetTreeNode = BaseInterfaceLogic.TargetNode;
                string[] SelecteIds = this.GetSelecteIds();
                for (int i = 0; i < SelecteIds.Length; i++)
                {
                    BaseInterfaceLogic.FindTreeNode(this.tvPermission, SelecteIds[i]);
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
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdPermission, "colSelected"))
            {
                frmPermissionItemSelect = new FrmPermissionSelect(this.parentEntityId);
                if (UserInfo.IsAdministrator)
                {
                    frmPermissionItemSelect.AllowNull = true;
                }
                else
                {
                    frmPermissionItemSelect.AllowNull = false;
                }
                frmPermissionItemSelect.OnButtonConfirmClick += new FrmPermissionSelect.ButtonConfirmEventHandler(CheckInputMove);
                if (frmPermissionItemSelect.ShowDialog() == DialogResult.OK)
                {
                    // 设置鼠标繁忙状态，并保留原先的状态
                    Cursor holdCursor = this.Cursor;
                    this.Cursor = Cursors.WaitCursor;
                    this.ParentEntityId = frmPermissionItemSelect.SelectedId;
                    // 调用事件
                    string[] tags = this.GetSelecteIds();
                    DotNetService.Instance.PermissionItemService.BatchMoveTo(UserInfo, tags, frmPermissionItemSelect.SelectedId);
                    // 移动treeNode
                    BaseInterfaceLogic.FindTreeNode(this.tvPermission, frmPermissionItemSelect.SelectedId);
                    TreeNode parentNode = BaseInterfaceLogic.TargetNode;
                    if (tags.Length > 0)
                    {
                        for (int i = 0; i < tags.Length; i++)
                        {
                            BaseInterfaceLogic.FindTreeNode(this.tvPermission, tags[i]);
                            BaseInterfaceLogic.MoveTreeNode(this.tvPermission, BaseInterfaceLogic.TargetNode, parentNode);
                        }
                    }
                    // 绑定grdModule
                    this.GetPermissionList();
                    if (this.DTPermissionList.Rows.Count > 0)
                        this.grdPermission.FirstDisplayedScrollingRowIndex = this.DTPermissionList.Rows.Count - 1;
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
            frmPermissionItemSelect = new FrmPermissionSelect(this.ParentEntityId);
            if (UserInfo.IsAdministrator)
            {
                frmPermissionItemSelect.AllowNull = true;
            }
            else
            {
                frmPermissionItemSelect.AllowNull = false;
            }
            frmPermissionItemSelect.OnButtonConfirmClick += new FrmPermissionSelect.ButtonConfirmEventHandler(this.CheckInputMove);
            if (frmPermissionItemSelect.ShowDialog() == DialogResult.OK)
            {
                DotNetService.Instance.PermissionItemService.MoveTo(this.UserInfo, this.CurrentEntityId, frmPermissionItemSelect.SelectedId);
                // 移动treeNode
                BaseInterfaceLogic.FindTreeNode(this.tvPermission, frmPermissionItemSelect.SelectedId);
                BaseInterfaceLogic.MoveTreeNode(this.tvPermission, this.tvPermission.SelectedNode, BaseInterfaceLogic.TargetNode);
                // 绑定grdPermission
                this.GetPermissionList();
                if (this.DTPermissionList.Rows.Count > 0)
                    this.grdPermission.FirstDisplayedScrollingRowIndex = this.DTPermissionList.Rows.Count - 1;
            }
        }
        #endregion

        #region private void MoveObject() 移动数据
        /// <summary>
        /// 移动数据
        /// </summary>
        private void MoveObject()
        {
            if (this.LastControl == this.grdPermission)
            {
                this.BatchMove();
            }
            if (this.LastControl == this.tvPermission)
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

        #region private string[] GetSelecteIds() 获得已被选中主键数组
        /// <summary>
        /// 获得已被选中主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelecteIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdPermission, BasePermissionItemEntity.FieldId, "colSelected", true);
        }
        #endregion

        #region private bool CheckInputBatchDelete() 检查输入的有效性
        /// <summary>
        /// 检查删除选择项的有效性
        /// </summary>
        /// <returns>有效</returns>
        private bool CheckInputBatchDelete()
        {
            bool returnValue = true;
            int selectedCount = 0;

            foreach (DataGridViewRow dgvRow in grdPermission.Rows)
            {
                DataRow dataRow = (dgvRow.DataBoundItem as DataRowView).Row;
                if ((System.Boolean)(dgvRow.Cells["colSelected"].Value??false))
                {
                    // break;
                    // 是否有子节点
                    string id = dataRow[BasePermissionItemEntity.FieldId].ToString();
                    BaseInterfaceLogic.FindTreeNode(this.tvPermission, id);
                    if (BaseInterfaceLogic.TargetNode != null)
                    {
                        if (!BaseInterfaceLogic.NodeAllowDelete(BaseInterfaceLogic.TargetNode))
                        {
                            MessageBox.Show(AppMessage.Format(AppMessage.MSG0035, BaseInterfaceLogic.TargetNode.Text), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            returnValue = false;
                            return returnValue;
                        }
                    }

                    BasePermissionItemEntity permissionItemEntity = new BasePermissionItemEntity(dataRow);
                    if (permissionItemEntity.AllowDelete.ToString().Equals("0"))
                    {
                        // 有不允许删除的数据
                        MessageBox.Show(AppMessage.Format(AppMessage.MSG0018, permissionItemEntity.FullName), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        returnValue = false;
                        break;
                    }
                }
                if ((System.Boolean)(dgvRow.Cells["colSelected"].Value??false))
                {
                    // 有记录被选中了
                    returnValue = true;
                    // break;
                    // 是否有子节点
                    string id = dataRow[BasePermissionItemEntity.FieldId].ToString();
                    BaseInterfaceLogic.FindTreeNode(this.tvPermission, id);
                    if (BaseInterfaceLogic.TargetNode != null)
                    {
                        if (!BaseInterfaceLogic.NodeAllowDelete(BaseInterfaceLogic.TargetNode))
                        {
                            MessageBox.Show(AppMessage.Format(AppMessage.MSG0035, BaseInterfaceLogic.TargetNode.Text), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            returnValue = false;
                            return returnValue;
                        }
                    }

                    BasePermissionItemEntity permissionItemEntity = new BasePermissionItemEntity(dataRow);
                    if (permissionItemEntity.AllowDelete.ToString().Equals("0"))
                    {
                        // 有不允许删除的数据
                        MessageBox.Show(AppMessage.Format(AppMessage.MSG0018, permissionItemEntity.FullName), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        returnValue = false;
                        break;
                    }

                    selectedCount++;
                }
            }

            //foreach (DataRow dataRow in this.DTPermissionList.Rows)
            //{
            //    if (dataRow["colSelected"].ToString() == true.ToString())
            //    {
            //        // break;
            //        // 是否有子节点
            //        string id = dataRow[BasePermissionItemEntity.FieldId].ToString();
            //        BaseInterfaceLogic.FindTreeNode(this.tvPermission, id);
            //        if (BaseInterfaceLogic.TargetNode != null)
            //        {
            //            if (!BaseInterfaceLogic.NodeAllowDelete(BaseInterfaceLogic.TargetNode))
            //            {
            //                MessageBox.Show(AppMessage.Format(AppMessage.MSG0035, BaseInterfaceLogic.TargetNode.Text), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                returnValue = false;
            //                return returnValue;
            //            }
            //        }

            //        BasePermissionItemEntity permissionItemEntity = new BasePermissionItemEntity(dataRow);
            //        if (permissionItemEntity.AllowDelete.ToString().Equals("0"))
            //        {
            //            // 有不允许删除的数据
            //            MessageBox.Show(AppMessage.Format(AppMessage.MSG0018, permissionItemEntity.FullName), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            returnValue = false;
            //            break;
            //        }
            //    }
            //    if (dataRow["colSelected"].ToString() == true.ToString())
            //    {
            //        // 有记录被选中了
            //        returnValue = true;
            //        // break;
            //        // 是否有子节点
            //        string id = dataRow[BasePermissionItemEntity.FieldId].ToString();
            //        BaseInterfaceLogic.FindTreeNode(this.tvPermission, id);
            //        if (BaseInterfaceLogic.TargetNode != null)
            //        {
            //            if (!BaseInterfaceLogic.NodeAllowDelete(BaseInterfaceLogic.TargetNode))
            //            {
            //                MessageBox.Show(AppMessage.Format(AppMessage.MSG0035, BaseInterfaceLogic.TargetNode.Text), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                returnValue = false;
            //                return returnValue;
            //            }
            //        }

            //        BasePermissionItemEntity permissionItemEntity = new BasePermissionItemEntity(dataRow);
            //        if (permissionItemEntity.AllowDelete.ToString().Equals("0"))
            //        {
            //            // 有不允许删除的数据
            //            MessageBox.Show(AppMessage.Format(AppMessage.MSG0018, permissionItemEntity.FullName), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            returnValue = false;
            //            break;
            //        }

            //        selectedCount++;
            //    }
            //}
            if (returnValue && selectedCount == 0)
            {
                returnValue = false;
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
                    // returnValue = DotNetService.Instance.PermissionItemService.BatchDelete(UserInfo, this.GetSelecteIds());  
                    string[] tags = this.GetSelecteIds();
                    // 逻辑删除
                    returnValue = DotNetService.Instance.PermissionItemService.SetDeleted(UserInfo, tags);
                    // 获取模块列表
                    this.DTPermission = DotNetService.Instance.ModuleService.GetDataTable(UserInfo);
                    // 在tree删除相应的节点
                    BaseInterfaceLogic.BatchRemoveNode(this.tvPermission, tags);
                    // 绑定grdPermission
                    this.GetPermissionList();
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
            if (this.tvPermission.SelectedNode == null)
            {
                return returnValue;
            }
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (!BaseInterfaceLogic.NodeAllowDelete(this.tvPermission.SelectedNode))
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0035, this.tvPermission.SelectedNode.Text), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    // 逻辑上删除
                    returnValue = DotNetService.Instance.PermissionItemService.SetDeleted(UserInfo, new string[] { this.ParentEntityId });
                    // 物理删除
                    // returnValue = DotNetService.Instance.PermissionItemService.Delete(UserInfo, this.ParentEntityId);
                    // 有数据被删除了？
                    if (returnValue > 0)
                    {
                        string[] tags = {(this.tvPermission.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString()};
                        BaseInterfaceLogic.BatchRemoveNode(this.tvPermission, tags);
                        // 绑定grdPermission
                        this.GetPermissionList();
                    }
                }
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
            return returnValue;
        }
        #endregion

        #region public int Delete() 删除数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <returns></returns>
        public int Delete()
        {
            int returnValue = 0;
            if (this.LastControl == this.grdPermission)
            {
               returnValue = this.BatchDelete();  
            }
            if (this.LastControl == this.tvPermission)
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
            DotNetService.Instance.PermissionItemService.BatchSave(UserInfo, this.DTPermissionList);
            // 绑定数据
            this.FormOnLoad();
            this.FormLoaded = true;
            if (BaseSystemInfo.ShowInformation)
            {
                // 批量保存，进行提示
                MessageBox.Show(AppMessage.MSG0011, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region public void Save() 保存
        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            // 检查批量输入的有效性
            if (BaseInterfaceLogic.CheckInputModifyAnyOne(this.DTPermissionList))
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
                    this.DTPermissionList.AcceptChanges();
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
        #endregion 

        #region private void ModuleSetPermission() 模块权限设置
        /// <summary>
        /// 模块权限设置
        /// </summary>
        private void ModuleSetPermission()
        {
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmPermissionItemModuleBatchSet";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmModulePermissionBatchSet = (Form)Activator.CreateInstance(assemblyType);
            frmModulePermissionBatchSet.ShowDialog(this);
        }
        #endregion

        private void btnModulePermission_Click(object sender, EventArgs e)
        {
            // 权限挂接
            this.ModuleSetPermission();
        }

        private void tvPermission_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvPermission.GetNodeAt(e.X, e.Y) != null)
            {
                tvPermission.SelectedNode = tvPermission.GetNodeAt(e.X, e.Y);
            }
        }

        private void cmbSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                string systemCode = this.cmbSystem.SelectedValue.ToString();
                if (string.IsNullOrEmpty(systemCode))
                {
                    systemCode = "Base";
                }
                BaseSystemInfo.SystemCode = systemCode;
                this.FormOnLoad();
                this.GetPermissionList();
            }
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
                this.DTPermission .DefaultView.RowFilter = string.Empty;
            }
            else
            {
                if (this.DTPermissionList  .Columns.Count > 1)
                {
                    string rowFilter = string.Empty;
                    search = StringUtil.GetSearchString(search);
                    rowFilter = StringUtil.GetLike(BasePermissionItemEntity.FieldDescription, search)
                        + " OR " + StringUtil.GetLike(BasePermissionItemEntity.FieldCode, search);
                        //+ " OR " + StringUtil.GetLike(BasePermissionItemEntity.FieldFullName , search)
                        //+ " OR " + StringUtil.GetLike(BasePermissionItemEntity.FieldIsScope , search)
                        //+ " OR " + StringUtil.GetLike(BasePermissionItemEntity.FieldLastCall , search)
                        //+ " OR " + StringUtil.GetLike(BasePermissionItemEntity.FieldIsPublic , search);
                    this.DTPermissionList .DefaultView.RowFilter = rowFilter;
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

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in this.grdPermission .Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in this.grdPermission .Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false);
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

        private void FrmPermissionAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BaseInterfaceLogic.IsModfiedAnyOne(this.DTPermissionList))
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