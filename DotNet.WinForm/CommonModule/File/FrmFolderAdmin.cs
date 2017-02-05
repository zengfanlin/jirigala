//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FrmFolderAdmin.cs
    /// 文件夹管理-管理文件夹窗体
    ///		
    /// 修改记录
    /// 
    ///     2008.10.27 版本：1.7 JiRiGaLa 整理权限主键。
    ///     2008.05.04 版本：1.6 JiRiGaLa 重新整理主键。
    ///     2007.06.04 版本：1.5 JiRiGaLa 添加右键弹出菜单。
    ///     2007.05.29 版本：1.4 JiRiGaLa 整体整理主键。
    ///     2007.05.17 版本：1.3 JiRiGaLa 增加了多国语言功能，调整了细节部分。
    ///     2007.05.15 版本：1.2 JiRiGaLa 整体进行调试改进。
    ///     2007.05.15 版本：1.0 JiRiGaLa 文件夹管理功能页面编写。
    ///		
    /// 版本：1.6
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.05.04</date>
    /// </author> 
    /// </summary>
    public partial class FrmFolderAdmin : BaseForm, IBaseForm
    {
        private DataTable DTFolder = new DataTable(BaseFolderEntity.TableName);      // 文件夹数据表
        private DataTable DTFolderList = new DataTable(BaseFolderEntity.TableName);  // 文件夹数据表
        private System.Windows.Forms.Control LastControl = null;   // 记录最后点击的控件

        FrmFolderSelect frmFolderSelect = null;           // 移动功能选择窗口

        private new bool permissionAccess = false;    // 访问权限
        private bool permissionAddRoot = false;    // 新增文件夹权限
        private bool permissionMove = false;    // 移动文件夹

        public event SetControlStateEventHandler OnButtonStateChange;

        // 上级文件夹主键
        private string parentEntityId = string.Empty;
        public string ParentEntityId
        {
            get
            {
                if ((this.tvFolder.SelectedNode != null) && (this.tvFolder.SelectedNode.Tag != null))
                {
                    this.parentEntityId = (this.tvFolder.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
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

        // 表格中的文件夹主键
        public new string EntityId
        {
            get
            {
                return BaseInterfaceLogic.GetDataGridViewEntityId(this.grdFolder, BaseOrganizeEntity.FieldId);
            }
        }

        // 当前选中的节点，树或者表格上
        public string CurrentEntityId
        {
            get
            {
                string entityId = string.Empty;
                if (this.LastControl == this.grdFolder)
                {
                    entityId = this.EntityId;
                }
                else
                {
                    entityId = this.parentEntityId;
                }
                return entityId;
            }
        }

        public FrmFolderAdmin()
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
            this.btnBatchDelete.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnBatchSave.Enabled = false;
            this.btnMove.Enabled = false;
            this.btnSelectAll.Enabled = false;
            this.btnInvertSelect.Enabled = false;
            // 检查添加文件夹
            this.btnAdd.Enabled = this.permissionAdd;
            if ((this.tvFolder.Nodes.Count > 0) || (this.DTFolderList.DefaultView.Count >= 1))
            {
                this.btnEdit.Enabled = this.permissionEdit;
                this.btnMove.Enabled = this.permissionMove;
                this.btnBatchDelete.Enabled = this.permissionDelete;
            }
            if (this.DTFolderList.DefaultView.Count >= 1)
            {
                this.btnSelectAll.Enabled = this.permissionEdit || this.permissionDelete;
                this.btnInvertSelect.Enabled = this.permissionEdit || this.permissionDelete;
            }
            if (this.DTFolderList.DefaultView.Count >= 1)
            {
                this.btnBatchSave.Enabled = this.permissionEdit;
            }
            // 位置顺序改变按钮部分
            if (this.DTFolderList.DefaultView.Count > 1)
            {
                this.SetSortButton(this.permissionEdit);
            }

            // 是否已经有文件夹，好增加文件
            if (this.tvFolder.Nodes.Count > 0)
            {
                // 右手弹出菜单
                this.mItmAdd.Enabled = this.permissionAdd;
                this.mItmEdit.Enabled = this.permissionEdit;
                this.mItmMove.Enabled = this.permissionMove;
                this.mItmDelete.Enabled = this.permissionDelete;
            }
            // 添加根文件夹，什么时候都可以用才对。
            this.mItmAddRootFolder.Enabled = this.permissionAddRoot;

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
            //检查有没有可导出数据
            this.btnExport.Enabled = this.grdFolder.RowCount > 0;
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAccess = this.IsModuleAuthorized("FolderAdmin");   // 访问权限
            this.permissionAdd = this.IsAuthorized("FolderAdmin.Add");      // 新增权限
            this.permissionAddRoot = this.IsAuthorized("FolderAdmin.AddRoot");  // 新增权限
            this.permissionEdit = this.IsAuthorized("FolderAdmin.Edit");     // 编辑权限
            this.permissionMove = this.IsAuthorized("FolderAdmin.Move");     // 移动权限
            this.permissionDelete = this.IsAuthorized("FolderAdmin.Delete");   // 删除权限
        }
        #endregion

        #region private void BindData(bool reloadTree) 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        /// <param name="reloadTree">重新加载文件夹树</param>
        private void BindData(bool reloadTree)
        {
            // 加载文件夹树的主键
            if (reloadTree)
            {
                this.LoadTree();
                if (this.tvFolder.SelectedNode == null)
                {
                    if (this.tvFolder.Nodes.Count > 0)
                    {
                        if (this.parentEntityId.Length == 0)
                        {
                            this.tvFolder.SelectedNode = this.tvFolder.Nodes[0];
                        }
                        else
                        {
                            BaseInterfaceLogic.FindTreeNode(this.tvFolder, this.parentEntityId);
                            if (BaseInterfaceLogic.TargetNode != null)
                            {
                                this.tvFolder.SelectedNode = BaseInterfaceLogic.TargetNode;
                                // 展开当前选中节点的所有父节点
                                BaseInterfaceLogic.ExpandTreeNode(this.tvFolder);
                            }
                        }
                        if (this.tvFolder.SelectedNode != null)
                        {
                            this.tvFolder.SelectedNode.EnsureVisible();
                            this.tvFolder.SelectedNode.Expand();
                        }
                    }
                }
            }
            // 添加选择列
            if (this.ParentEntityId.Length > 0)
            {
                if (reloadTree)
                {
                    // 获得子文件夹列表
                    this.GetFolderList();
                }
            }
            if (!this.permissionEdit)
            {
                // 只读属性设置
                this.grdFolder.Columns["colSelected"].ReadOnly = !this.permissionEdit;
                this.grdFolder.Columns["colDescription"].ReadOnly = !this.permissionEdit;
                // 修改背景颜色
                this.grdFolder.Columns["colDescription"].DefaultCellStyle.BackColor = Color.White;
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
            this.DataGridViewOnLoad(grdFolder);
            // 权限信息
            this.DTFolder = DotNetService.Instance.FolderService.GetDataTable(UserInfo);
            this.DTFolder.DefaultView.Sort = BaseFolderEntity.FieldSortCode;
            // 绑定屏幕数据
            this.BindData(true);
        }
        #endregion

        #region private void GetFolderList() 获得子文件夹列表
        /// <summary>
        /// 获得子文件夹列表
        /// </summary>
        private void GetFolderList()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            this.DTFolderList = DotNetService.Instance.FolderService.GetDataTableByParent(UserInfo, this.ParentEntityId);
            this.DTFolderList.DefaultView.Sort = BaseFolderEntity.FieldSortCode;
            this.grdFolder.AutoGenerateColumns = false;
            this.grdFolder.DataSource = this.DTFolderList.DefaultView;
            // 设置排序按钮
            this.ucTableSort.DataBind(this.grdFolder, this.permissionEdit);
            // 设置按钮状态
            this.SetControlState();
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }
        #endregion

        #region private void LoadTree() 加载文件夹树的主键
        /// <summary>
        /// 加载文件夹树的主键
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvFolder.BeginUpdate();
            this.tvFolder.Nodes.Clear();
            TreeNode treeNode = new TreeNode();
            this.LoadTreeFolder(treeNode);
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvFolder.EndUpdate();
        }
        #endregion

        #region private void LoadTreeFolder(TreeNode treeNode) 加载文件夹树的主键
        /// <summary>
        /// 加载文件夹树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeFolder(TreeNode treeNode)
        {
            BaseInterfaceLogic.LoadTreeNodes(this.DTFolder, BaseFolderEntity.FieldId, BaseFolderEntity.FieldParentId, BaseFolderEntity.FieldFolderName, this.tvFolder, treeNode);
        }
        #endregion

        private void FrmFolderAdmin_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                // 设置开关变量
                this.FormLoaded = false;
                // 加载窗体
                this.FormOnLoad();
                this.FormLoaded = true;
            }
        }

        /// <summary>
        /// 获取当前选择的路径
        /// </summary>
        /// <returns>路径</returns>
        private string GetPath()
        {
            string path = string.Empty;
            if (this.tvFolder.SelectedNode != null)
            {
                TreeNode treeNode = this.tvFolder.SelectedNode;
                path = treeNode.Text;
                while (treeNode.Parent != null)
                {
                    path = treeNode.Parent.Text + "\\" + path;
                    treeNode = treeNode.Parent;
                }
            }
            return path;
        }

        private void cMnuFolder_Opened(object sender, EventArgs e)
        {
            // 右手弹出菜单
            this.LastControl = this.tvFolder;
            if (this.tvFolder.SelectedNode == null)
            {
                this.mItmAdd.Enabled = false;
                this.mItmEdit.Enabled = false;
                this.mItmMove.Enabled = false;
                this.mItmDelete.Enabled = false;
                this.mItmAddRootFolder.Enabled = this.permissionAdd;
            }
            else
            {
                this.mItmAdd.Enabled = this.permissionAdd;
                this.mItmAddRootFolder.Enabled = this.permissionAdd;
                this.mItmEdit.Enabled = this.permissionEdit;
                this.mItmMove.Enabled = this.permissionEdit;
                this.mItmDelete.Enabled = this.permissionDelete;
            }
        }

        private void tvFolder_Click(object sender, EventArgs e)
        {
        }

        private void tvFolder_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.FormLoaded)
            {
                if (this.ParentEntityId.Length > 0)
                {
                    this.Text = "文件夹管理 [" + this.GetPath() + "]";
                    this.GetFolderList();
                }
                else
                {
                    this.Text = "文件夹管理";
                }
            }
        }

        private void tvFolder_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (this.permissionEdit)
            {
                // 开始进行拖放操作，并将拖放的效果设置成移动。
                this.DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void tvFolder_DragEnter(object sender, DragEventArgs e)
        {
            // 拖动效果设成移动
            e.Effect = DragDropEffects.Move;
        }

        private void tvFolder_DragDrop(object sender, DragEventArgs e)
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
                        // 是否移动文件夹
                        if (MessageBox.Show(AppMessage.Format(AppMessage.MSG0203, treeNode.Text, targetTreeNode.Text), AppMessage.MSG0000, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    DotNetService.Instance.FolderService.MoveTo(UserInfo, (treeNode.Tag as DataRow)[BaseFolderEntity.FieldId].ToString(), (targetTreeNode.Tag as DataRow)[BaseFolderEntity.FieldId].ToString());
                    // 往目标节点中加入被拖动节点的一份克隆
                    targetTreeNode.Nodes.Add((TreeNode)treeNode.Clone());
                    // 展开目标节点
                    // targetTreeNode.Expand();
                    // 将被拖动的节点移除
                    treeNode.Remove();
                }
            }
        }

        #region public string AddFolder(bool root) 添加文件夹
        /// <summary>
        /// 添加文件夹
        /// </summary>
        /// <param name="root">根目录</param>
        /// <returns>主键</returns>
        public string AddFolder(bool root)
        {
            string returnValue = string.Empty;
            FrmFolderAdd frmFolderAdd;
            if ((root) || (this.tvFolder.SelectedNode == null))
            {
                frmFolderAdd = new FrmFolderAdd();
            }
            else
            {
                frmFolderAdd = new FrmFolderAdd((this.tvFolder.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString(), this.tvFolder.SelectedNode.Text);
            }
            if (frmFolderAdd.ShowDialog(this) == DialogResult.OK)
            {
                returnValue = frmFolderAdd.EntityId;
                this.Changed = true;
                this.FormLoaded = false;
                // 绑定屏幕数据
                this.FormOnLoad();
                this.FormLoaded = true;
            }
            return returnValue;
        }
        #endregion

        private void mItmAdd_Click(object sender, EventArgs e)
        {
            this.AddFolder(false);
        }

        private void mItmAddFolder_Click(object sender, EventArgs e)
        {
            this.AddFolder(true);
        }

        private void mItmEdit_Click(object sender, EventArgs e)
        {
            this.btnEdit.PerformClick();
        }

        private void mItmMove_Click(object sender, EventArgs e)
        {
            this.btnMove.PerformClick();
        }

        private void mItmDelete_Click(object sender, EventArgs e)
        {
            this.btnBatchDelete.PerformClick();
        }

        private void grdFolder_Click(object sender, EventArgs e)
        {
            this.LastControl = this.grdFolder;
        }

        private void grdFolder_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            //// 提示删除确认
            //if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            //{
            //    e.Cancel = true;
            //}
        }

        private void grdFolder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnEdit.PerformClick();
        }

        private void grdFolder_Sorted(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (this.permissionEdit)
            {
                string[] sequence = DotNetService.Instance.SequenceService.GetBatchSequence(UserInfo, BaseFolderEntity.TableName, this.DTFolderList.DefaultView.Count);
                int i = 0;
                foreach (DataRowView dataRowView in this.DTFolderList.DefaultView)
                {
                    dataRowView.Row[BaseFolderEntity.FieldSortCode] = sequence[i];
                    i++;
                }
                this.SetSortButton(false);
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
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

        private void grdFolder_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private string AddFolder(string parentId, string directory, bool child)
        {
            string returnValue = string.Empty;
            if (Directory.Exists(directory))
            {
                // 获得最终的文件名
                string folderName = directory.Substring(directory.LastIndexOf(Path.DirectorySeparatorChar) + 1);
                string statusCode = string.Empty;
                string statusMessage = string.Empty;
                returnValue = DotNetService.Instance.FolderService.AddByFolderName(UserInfo, parentId, folderName, true, out statusCode, out statusMessage);
                if (!statusCode.Equals(StatusCode.OKAdd.ToString()))
                {
                    MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return returnValue;
                }
                if (child && !String.IsNullOrEmpty(returnValue))
                {
                    // 子文件夹递归增加
                    string[] directores = Directory.GetDirectories(directory);
                    for (int i = 0; i < directores.Length; i++)
                    {
                        this.AddFolder(returnValue, directores[i], child);
                    }
                }
            }
            return returnValue;
        }

        private void grdFolder_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                int returnValue = 0;
                string[] folder = (string[])e.Data.GetData(DataFormats.FileDrop);
                for (int i = 0; i <= folder.Length - 1; i++)
                {
                    if (this.AddFolder(this.ParentEntityId, folder[i], false).Length > 0)
                    {
                        returnValue++;
                    }
                }
                if (returnValue > 0)
                {
                    this.FormLoaded = false;
                    this.FormOnLoad();
                    this.FormLoaded = true;
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            //foreach (DataRow dataRow in this.DTFolderList.Rows)
            //{
            //    dataRow.["colSelected"] = true.ToString();
            //}
            foreach (DataGridViewRow dgvRow in grdFolder.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in grdFolder.Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false);
            }
            //foreach (DataRow dataRow in this.DTFolderList.Rows)
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

        #region private string[] GetSelecteIds() 获得已被选择的文件夹主键数组
        /// <summary>
        /// 获得已被选择的文件夹主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelecteIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdFolder, BaseFolderEntity.FieldId, "colSelected", true);
        }
        #endregion

        #region public string Add() 添加文件夹
        /// <summary>
        /// 添加文件夹
        /// </summary>
        public string Add()
        {
            string returnValue = string.Empty;
            FrmFolderAdd frmFolderAdd;
            if (this.LastControl == this.tvFolder)
            {
                if ((this.ParentEntityId.Length == 0) || (this.tvFolder.SelectedNode == null))
                {
                    frmFolderAdd = new FrmFolderAdd();
                }
                else
                {
                    frmFolderAdd = new FrmFolderAdd(this.ParentEntityId, this.tvFolder.SelectedNode.Text);
                }
            }
            else
            {
                DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdFolder);
                if (dataRow == null)
                {
                    frmFolderAdd = new FrmFolderAdd();
                }
                else
                {
                    frmFolderAdd = new FrmFolderAdd(dataRow[BaseFolderEntity.FieldId].ToString(), dataRow[BaseFolderEntity.FieldFolderName].ToString());
                }
            }
            if (frmFolderAdd.ShowDialog(this) == DialogResult.OK)
            {
                returnValue = frmFolderAdd.EntityId;
                this.Changed = true;
                this.FormLoaded = false;
                // 绑定屏幕数据
                this.FormOnLoad();
                this.FormLoaded = true;
            }
            return returnValue;
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Add();
        }

        #region private void EditTree() 编辑树节点
        /// <summary>
        /// 编辑树节点
        /// </summary>
        private void EditTree()
        {
            if (this.tvFolder.SelectedNode == null)
            {
                return;
            }
            string id = string.Empty;
            if (this.tvFolder.SelectedNode.Tag is DataRow)
            {
                id = (this.tvFolder.SelectedNode.Tag as DataRow)[BaseOrganizeEntity.FieldId].ToString();
            }
            else
            {
                id = this.tvFolder.SelectedNode.Tag.ToString();
            }
            FrmFolderEdit FrmFolderEdit = new FrmFolderEdit(id);
            if (FrmFolderEdit.ShowDialog(this) == DialogResult.OK)
            {
                this.Changed = true;
                this.FormLoaded = false;
                // 绑定屏幕数据
                this.FormOnLoad();
                this.FormLoaded = true;
            }
        }
        #endregion

        #region private void EditGrid() 编辑模块
        /// <summary>
        /// 编辑模块   CheckInputSelectOne
        /// </summary>
        private void EditGrid()
        {
            //if (BaseInterfaceLogic.CheckInputSelectOne(this.DTFolderList, "colSelected"))
            //{
            string id = BaseInterfaceLogic.GetDataGridViewEntityId(this.grdFolder, BaseModuleEntity.FieldId);
            FrmFolderEdit FrmFolderEdit = new FrmFolderEdit(id);
            if (FrmFolderEdit.ShowDialog(this) == DialogResult.OK)
            {
                this.Changed = true;
                this.FormLoaded = false;
                // 绑定屏幕数据
                this.FormOnLoad();
                this.FormLoaded = true;
            }
            //}
        }
        #endregion

        #region public void Edit() 编辑
        /// <summary>
        /// 编辑
        /// </summary>
        public void Edit()
        {
            // 编辑模块
            if (this.LastControl == this.grdFolder)
            {
                this.EditGrid();
            }
            if (this.LastControl == this.tvFolder)
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
            if (this.LastControl == this.tvFolder)
            {
                BaseInterfaceLogic.FindTreeNode(this.tvFolder, this.parentEntityId);
                TreeNode treeNode = BaseInterfaceLogic.TargetNode;
                BaseInterfaceLogic.FindTreeNode(this.tvFolder, frmFolderSelect.SelectedId);
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
            if (this.LastControl == this.grdFolder)
            {
                BaseInterfaceLogic.FindTreeNode(this.tvFolder, frmFolderSelect.SelectedId);
                TreeNode targetTreeNode = BaseInterfaceLogic.TargetNode;
                string[] SelecteIds = this.GetSelecteIds();
                for (int i = 0; i < SelecteIds.Length; i++)
                {
                    BaseInterfaceLogic.FindTreeNode(this.tvFolder, SelecteIds[i]);
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
            frmFolderSelect = new FrmFolderSelect(this.parentEntityId);
            frmFolderSelect.OnButtonConfirmClick += new FrmFolderSelect.ButtonConfirmEventHandler(CheckInputMove);
            frmFolderSelect.AllowNull = true;
            if (frmFolderSelect.ShowDialog() == DialogResult.OK)
            {
                this.Changed = true;
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                this.FormLoaded = false;
                // 调用事件
                DotNetService.Instance.FolderService.BatchMoveTo(UserInfo, this.GetSelecteIds(), frmFolderSelect.SelectedId);
                // 绑定屏幕数据
                this.FormOnLoad();
                this.FormLoaded = true;
                // 设置鼠标默认状态，原来的光标状态
                this.Cursor = holdCursor;
            }
        }
        #endregion

        #region private void SingleMove(string currentEntityId) 单个记录移动
        /// <summary>
        /// 单个记录移动
        /// </summary>
        private void SingleMove(string currentEntityId)
        {
            frmFolderSelect = new FrmFolderSelect(this.parentEntityId);
            frmFolderSelect.OnButtonConfirmClick += new FrmFolderSelect.ButtonConfirmEventHandler(CheckInputMove);
            frmFolderSelect.AllowNull = true;
            if (frmFolderSelect.ShowDialog() == DialogResult.OK)
            {
                this.Changed = true;
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                this.FormLoaded = false;
                // 调用事件
                DotNetService.Instance.FolderService.MoveTo(UserInfo, currentEntityId, frmFolderSelect.SelectedId);
                // 绑定屏幕数据
                this.FormOnLoad();
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
            if (this.LastControl == this.grdFolder)
            {
                if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdFolder, "colSelected"))
                {
                    this.BatchMove();
                }
            }
            if (this.LastControl == this.tvFolder)
            {
                if (this.ParentEntityId.Length > 0)
                {
                    this.SingleMove(this.CurrentEntityId);
                }
            }
        }
        #endregion

        private void btnMove_Click(object sender, EventArgs e)
        {
            this.MoveObject();
        }

        #region private int SingleDelete() 单个删除
        /// <summary>
        /// 单个删除
        /// </summary>
        private int SingleDelete()
        {
            int returnValue = 0;
            // this.FormLoaded = false;
            returnValue = DotNetService.Instance.FolderService.Delete(UserInfo, this.ParentEntityId);
            this.tvFolder.SelectedNode.Remove();
            // 绑定数据
            this.GetFolderList();
            // this.FormLoaded = true;
            return returnValue;
        }
        #endregion

        #region public override int BatchDelete() 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        public override int BatchDelete()
        {
            int returnValue = 0;
            this.FormLoaded = false;
            returnValue = DotNetService.Instance.FolderService.BatchDelete(UserInfo, this.GetSelecteIds());
            // 绑定数据
            this.FormOnLoad();
            this.FormLoaded = true;
            return returnValue;
        }
        #endregion

        public int Delete()
        {
            int returnValue = 0;
            if (this.LastControl == this.grdFolder)
            {
                if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdFolder, "colSelected"))
                {
                    if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        // 设置鼠标繁忙状态，并保留原先的状态
                        Cursor holdCursor = this.Cursor;
                        this.Cursor = Cursors.WaitCursor;
                        try
                        {
                            returnValue = this.BatchDelete();
                            this.Changed = true;
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
            if (this.LastControl == this.tvFolder)
            {
                if (!BaseInterfaceLogic.NodeAllowDelete(this.tvFolder.SelectedNode))
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0035, this.tvFolder.SelectedNode.Text), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        // 设置鼠标繁忙状态，并保留原先的状态
                        Cursor holdCursor = this.Cursor;
                        this.Cursor = Cursors.WaitCursor;
                        try
                        {
                            returnValue = this.SingleDelete();
                            this.Changed = true;
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
            return returnValue;
        }

        private void btnBatchDelete_Click(object sender, EventArgs e)
        {
            this.Delete();
        }

        #region private void BatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private void BatchSave()
        {
            this.FormLoaded = false;
            DotNetService.Instance.FolderService.BatchSave(UserInfo, this.DTFolderList);
            this.Changed = true;
            // 绑定屏幕数据
            this.FormOnLoad();
            this.FormLoaded = true;
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
            if (BaseInterfaceLogic.CheckInputModifyAnyOne(this.DTFolderList))
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
                    this.DTFolderList.AcceptChanges();
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

        private void FrmFolderAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BaseInterfaceLogic.IsModfiedAnyOne(this.DTFolderList))
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
            if (this.Changed)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void tvFolder_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvFolder.GetNodeAt(e.X, e.Y) != null)
            {
                tvFolder.SelectedNode = tvFolder.GetNodeAt(e.X, e.Y);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 导出Excel
            //string exportFileName = this.Text + ".csv";
            string exportFileName = this.Text + ".xls";
            exportFileName = exportFileName.Replace("\\", ".");
            this.ExportExcel(this.grdFolder, @"\Modules\Export\", exportFileName);
        }
    }
}