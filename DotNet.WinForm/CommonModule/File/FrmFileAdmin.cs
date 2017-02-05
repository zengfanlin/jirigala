//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FrmFileAdmin.cs
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
    public partial class FrmFileAdmin : BaseForm, IBaseForm
    {
        private DataTable DTFolder = new DataTable(BaseFolderEntity.TableName);  // 文件夹数据表
        private DataTable DTFileList = new DataTable(BaseFileEntity.TableName);  // 文件夹数据表
        private System.Windows.Forms.Control LastControl = null;   // 记录最后点击的控件

        FrmFolderSelect FrmFolderSelect = null;           // 移动功能选择窗口

        //private bool permissionAccess           = false;    // 访问权限
        private bool permissionAddFile = false;    // 新增文夹权限
        private bool permissionEditFile = false;    // 编辑文件权限
        private bool permissionDeleteFile = false;    // 删除文件权限
        private bool permissionMoveFile = false;    // 移动文件

        private bool permissionAddRootFolder = false;    // 新增文件夹权限
        private bool permissionAddFolder = false;    // 新增文件夹权限
        private bool permissionEditFolder = false;    // 编辑文件夹权限
        private bool permissionDeleteFolder = false;    // 删除文件夹权限
        private bool permissionMoveFolder = false;    // 移动文件夹
        private bool permissionAdminFolder = false;    // 管理文件夹

        public event SetControlStateEventHandler OnButtonStateChange;

        /// <summary>
        /// 最多能上传文件的容量，单位GB;必须加上显式的后缀防止编译器误判按默认的int存储而溢出
        /// </summary>
        public long UploadMaxSumSize = 2 * 1024 * 1024 * 1024L;

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

        /// <summary>
        /// 表格中的文件夹主键
        /// </summary>
        public override string EntityId
        {
            get
            {
                return BaseInterfaceLogic.GetDataGridViewEntityId(this.grdFile, BaseFileEntity.FieldId);
            }
        }

        // 当前选中的节点，树或者表格上
        public string CurrentEntityId
        {
            get
            {
                string entityId = string.Empty;
                if (this.LastControl == this.grdFile)
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

        public FrmFileAdmin()
        {
            InitializeComponent();
        }

        private void CheckFileTable()
        {
            if (this.DTFileList == null)
            {
                this.DTFileList = new DataTable(BaseFileEntity.TableName);
            }
            //if (!this.DTFileList.Columns.Contains(BaseBusinessLogic.SelectedColumn))
            //{
            //    this.DTFileList.Columns.Add(BaseBusinessLogic.SelectedColumn);
            //}
            if (!this.DTFileList.Columns.Contains(BaseFileEntity.FieldId))
            {
                this.DTFileList.Columns.Add(BaseFileEntity.FieldId);
            }
            if (!this.DTFileList.Columns.Contains(BaseFileEntity.FieldFileName))
            {
                this.DTFileList.Columns.Add(BaseFileEntity.FieldFileName);
            }
            if (!this.DTFileList.Columns.Contains(BaseFileEntity.FieldFilePath))
            {
                this.DTFileList.Columns.Add(BaseFileEntity.FieldFilePath);
            }
            if (!this.DTFileList.Columns.Contains("FileFriendlySize"))
            {
                this.DTFileList.Columns.Add("FileFriendlySize");
            }
            if (!this.DTFileList.Columns.Contains(BaseFileEntity.FieldDescription))
            {
                this.DTFileList.Columns.Add(BaseFileEntity.FieldDescription);
            }
            // 计算文件的大小，更友善的现实数据
            foreach (DataRow dataRow in this.DTFileList.Rows)
            {
                if (dataRow.RowState == DataRowState.Unchanged)
                {
                    int fileSize = int.Parse(dataRow[BaseFileEntity.FieldFileSize].ToString());
                    dataRow["FileFriendlySize"] = FileUtil.GetFriendlyFileSize(fileSize);
                }
            }
            this.DTFileList.AcceptChanges();
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.SetSortButton(false);
            this.btnAdd.Enabled = false;
            this.btnBatchDelete.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnBatchSave.Enabled = false;
            this.btnMove.Enabled = false;
            this.btnSelectAll.Enabled = false;
            this.btnInvertSelect.Enabled = false;
            this.btnFolderAdmin.Enabled = this.permissionAdminFolder;
            // 是否已经有文件夹，好增加文件
            if ((this.DTFileList.DefaultView.Count >= 1) || (this.tvFolder.Nodes.Count > 0))
            {
                this.btnAdd.Enabled = this.permissionAddFile;
                this.btnEdit.Enabled = this.permissionEditFile;
                this.btnMove.Enabled = this.permissionMoveFile;
                this.btnBatchDelete.Enabled = this.permissionMoveFile;
                // 右手弹出菜单
                this.mItmAddFolder.Enabled = this.permissionAddFolder;
                this.mItmDeleteFolder.Enabled = this.permissionDeleteFolder;
                this.mItmEditFolder.Enabled = this.permissionEditFolder;
                this.mItmMoveFolder.Enabled = this.permissionMoveFolder;
                this.mItmFrmFolderAdmin.Enabled = this.permissionAdminFolder;
            }
            // 添加根文件夹，什么时候都可以用才对。
            this.mItmAddRootFolder.Enabled = this.permissionAddRootFolder;

            if ((this.DTFileList.DefaultView.Count >= 1))
            {
                this.btnSelectAll.Enabled = this.permissionEditFile || this.permissionDeleteFile;
                this.btnInvertSelect.Enabled = this.permissionEditFile || this.permissionDeleteFile;
            }
            if (this.DTFileList.DefaultView.Count >= 1)
            {
                this.btnBatchSave.Enabled = this.permissionEditFile || this.permissionMoveFile;
            }
            // 位置顺序改变按钮部分
            if (this.DTFileList.DefaultView.Count > 1)
            {
                this.SetSortButton(this.permissionMoveFile);
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

            //检查有没有可导出数据和权限
            this.btnExport.Enabled = this.grdFile.RowCount > 0;
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            /*
            this.permissionAddFile      = this.IsAuthorized("FileAdmin.AddFile");      
            this.permissionEditFile     = this.IsAuthorized("FileAdmin.EditFile");     
            this.permissionDeleteFile   = this.IsAuthorized("FileAdmin.DeleteFile");   
            this.permissionMoveFile     = this.IsAuthorized("FileAdmin.MoveFile");     

            */
            this.permissionAddRootFolder = this.IsAuthorized("FileAdmin.AddRootFolder");
            this.permissionAddFolder = this.IsAuthorized("FileAdmin.AddFolder");
            this.permissionEditFolder = this.IsAuthorized("FileAdmin.EditFolder");
            this.permissionDeleteFolder = this.IsAuthorized("FileAdmin.DeleteFolder");
            this.permissionMoveFolder = this.IsAuthorized("FileAdmin.MoveFolder");
            this.permissionAdminFolder = this.IsAuthorized("FileAdmin.AdminFolder");

            this.permissionAddFile = true;
            this.permissionEditFile = true;
            this.permissionDeleteFile = true;
            this.permissionMoveFile = true;
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
            if (!string.IsNullOrEmpty(this.ParentEntityId))
            {
                if (reloadTree)
                {
                    // 获得子文件夹列表
                    this.GetFileList();
                }
            }
            if (!this.permissionEditFile)
            {
                // 只读属性设置
                this.grdFile.Columns["colSelected"].ReadOnly = !this.permissionEditFile;
                this.grdFile.Columns["colDescription"].ReadOnly = !this.permissionEditFile;
                // 修改背景颜色
                this.grdFile.Columns["colDescription"].DefaultCellStyle.BackColor = Color.White;
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
            this.DataGridViewOnLoad(grdFile);
            // 没有权限的，只能访问自己的目录
            this.DTFolder = DotNetService.Instance.FolderService.GetDataTable(UserInfo);
            if (this.UserInfo.IsAdministrator)
            {
            }
            else
            {
                // 这个是只加载某个路径下的文件
                // this.DTFolder = DotNetService.Instance.FolderService.GetDataTableByParent(UserInfo, UserInfo.Id);
                // BaseBusinessLogic.SetProperty(this.DTFolder, UserInfo.Id, BaseFolderEntity.FieldParentId, null);
            }
            this.DTFolder.DefaultView.Sort = BaseFolderEntity.FieldSortCode;
            // 绑定屏幕数据
            this.BindData(true);
        }
        #endregion

        #region private void GetFileList() 获得子文件夹文件列表
        /// <summary>
        /// 获得子文件夹列表
        /// </summary>
        private void GetFileList()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            this.DTFileList = DotNetService.Instance.FileService.GetDataTableByFolder(UserInfo, this.ParentEntityId);
            this.DTFileList.DefaultView.Sort = BaseFileEntity.FieldSortCode;
            this.CheckFileTable();
            this.grdFile.AutoGenerateColumns = false;
            this.grdFile.DataSource = this.DTFileList.DefaultView;
            // 设置排序按钮
            this.ucTableSort.DataBind(this.grdFile, this.permissionEditFile);
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

        /// <summary>
        /// 获取当面目录的操作权限
        /// </summary>
        private void GetFolderPermission()
        {
            bool addFolder = false;
            bool editFolder = false;
            bool deleteFolder = false;
            bool moveFolder = false;
            if (this.permissionAddFolder)
            {
                addFolder = true;
            }
            if (this.permissionEditFolder)
            {
                editFolder = true;
            }
            if (this.permissionDeleteFolder)
            {
                deleteFolder = true;
            }
            if (this.permissionMoveFolder)
            {
                moveFolder = true;
            }
            if ((this.tvFolder.SelectedNode != null))
            {
                TreeNode treeNode = this.tvFolder.SelectedNode;
                while (treeNode != null)
                {
                    // 自己的文件夹不能删除，不能修改。
                    // 自己文件夹下的，可以任意管理。
                    if ((treeNode.Tag as DataRow)[BaseFolderEntity.FieldId].ToString().Equals(this.UserInfo.Id))
                    {
                        addFolder = true;
                        break;
                    }
                    if (treeNode.Parent != null && treeNode.Parent.Tag.ToString().Equals(this.UserInfo.Id))
                    {
                        editFolder = true;
                        deleteFolder = true;
                        moveFolder = true;
                        break;
                    }
                    if (treeNode.Parent != null && treeNode.Parent.Tag.ToString().Equals(this.UserInfo.Id))
                    {
                        editFolder = true;
                        deleteFolder = true;
                        moveFolder = true;
                        break;
                    }
                    // 共享文件夹下的，可以任意管理。
                    if ((treeNode.Tag as DataRow)[BaseFolderEntity.FieldId].ToString().Equals("ShareFolder"))
                    {
                        addFolder = true;
                        break;
                    }
                    if (treeNode.Parent != null && treeNode.Parent.Tag.ToString().Equals("ShareFolder"))
                    {
                        editFolder = true;
                        deleteFolder = true;
                        moveFolder = true;
                        break;
                    }
                    // 部门文件夹的，可以任意管理。
                    if ((treeNode.Tag as DataRow)[BaseOrganizeEntity.FieldId].ToString().Equals(this.UserInfo.DepartmentId))
                    {
                        addFolder = true;
                        break;
                    }
                    if (treeNode.Parent != null && treeNode.Parent.Tag.ToString().Equals(this.UserInfo.DepartmentId))
                    {
                        editFolder = true;
                        deleteFolder = true;
                        moveFolder = true;
                        break;
                    }
                    treeNode = treeNode.Parent;
                }
            }
            this.permissionAddFolder = addFolder;
            this.permissionEditFolder = editFolder;
            this.permissionDeleteFolder = deleteFolder;
            this.permissionMoveFolder = moveFolder;
        }

        private void tvFolder_Click(object sender, EventArgs e)
        {
            this.LastControl = this.tvFolder;
            if (this.tvFolder.SelectedNode == null)
            {
                this.tvFolder.ContextMenuStrip = null;
            }
            else
            {
                this.tvFolder.ContextMenuStrip = this.cMnuFolder;
                this.GetFolderPermission();
                // mItmAddFolder.Enabled = addFolder;
                // mItmEditFolder.Enabled = editFolder;
                // mItmDeleteFolder.Enabled = deleteFolder;
                // mItmMoveFolder.Enabled = moveFolder;
                // 这里控制权限
                this.GetFileList();
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

        private void GetFolderList()
        {
            if (!this.UserInfo.IsAdministrator && this.tvFolder.SelectedNode != null)
            {
                this.DTFolder = null;
                if (this.tvFolder.SelectedNode.Level == 1)
                {
                    // 获取公开的，或者比自己安全级别低的文件夹
                    string commandText = string.Format(@"SELECT * 
                                                           FROM BaseFolder 
                                                          WHERE DeletionStateCode = 0 
                                                                 AND Enabled = 1
                                                                 AND ParentId = '{0}'           
                                                                 AND (IsPublic = 1 
                                                                      OR ID = '{1}'
                                                                      OR CreateUserId = '{1}' ", this.ParentEntityId, UserInfo.Id);
                    if (this.UserInfo.SecurityLevel > 0)
                    {
                        commandText += string.Format(@" OR ID IN ( SELECT CONVERT(NVARCHAR(40) ,Id) AS Id
                                                       FROM BaseUser
                                                      WHERE (DeletionStateCode = 0) 
                                                            AND (Enabled = 1) 
                                                            AND (IsVisible = 1) 
                                                            AND (DepartmentId = '{0}' )
                                                            AND (SecurityLevel < {1}) ) ", this.ParentEntityId, this.UserInfo.SecurityLevel);
                    }
                    commandText += " ) ";
                    this.DTFolder = this.UserCenterDbHelper.Fill(commandText);

                }
                else if (this.tvFolder.SelectedNode.Level > 1)
                {
                    // 获取所有文件列表
                    this.tvFolder.SelectedNode.Nodes.Clear();
                    this.DTFolder = DotNetService.Instance.FolderService.GetDataTableByParent(UserInfo, this.ParentEntityId);
                }
                if (this.DTFolder != null)
                {
                    foreach (DataRow dataRow in this.DTFolder.Rows)
                    {
                        TreeNode newTreeNode = new TreeNode();
                        newTreeNode.Text = dataRow[BaseFolderEntity.FieldFolderName].ToString();
                        newTreeNode.Tag = dataRow;
                        this.tvFolder.SelectedNode.Nodes.Add(newTreeNode);
                    }
                }
            }
        }

        private void tvFolder_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.FormLoaded)
            {
                if (this.ParentEntityId.Length > 0)
                {
                    this.Text = "文档管理 [" + this.GetPath() + "]";
                    this.GetFolderList();
                    this.GetFileList();
                    // this.DSRole.Tables[BaseRoleEntity.TableName].DefaultView.RowFilter = BURole.FieldOrganizeId + "=" + this.ParentEntityId;
                }
                else
                {
                    this.Text = "文档管理";
                }
            }
        }

        private void tvFolder_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (this.permissionEditFolder)
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
                Point Point;
                //拖放的目标节点
                TreeNode targetTreeNode;
                //获取当前光标所处的坐标
                Point = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                //根据坐标点取得处于坐标点位置的节点
                targetTreeNode = ((TreeView)sender).GetNodeAt(Point);
                //获取被拖动的节点
                treeNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                //判断拖动的节点与目标节点是否是同一个,同一个不予处理
                if (BaseInterfaceLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode))
                {
                    if (BaseSystemInfo.ShowInformation)
                    {
                        // 是否移动文件夹
                        if (MessageBox.Show(string.Format(AppMessage.MSG0203, treeNode.Text, targetTreeNode.Text), AppMessage.MSG0000, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    DotNetService.Instance.FolderService.MoveTo(UserInfo, (treeNode.Tag as DataRow)[BaseFileEntity.FieldId].ToString(), (targetTreeNode.Tag as DataRow)[BaseFileEntity.FieldId].ToString());
                    // 往目标节点中加入被拖动节点的一份克隆
                    targetTreeNode.Nodes.Add((TreeNode)treeNode.Clone());
                    // 展开目标节点
                    // targetTreeNode.Expand();
                    // 将被拖动的节点移除
                    treeNode.Remove();
                }
            }
        }

        private void mItmAddUrl_Click(object sender, EventArgs e)
        {
            if (this.tvFolder.SelectedNode == null)
            {
                return;
            }
            FrmDocumentAdd frmDocumentAdd = new FrmDocumentAdd((this.tvFolder.Tag as DataRow)[BaseModuleEntity.FieldId].ToString(), "url");
            frmDocumentAdd.ShowDialog();
            if (frmDocumentAdd.Changed)
            {
                // 获得子文件夹列表
                this.GetFileList();
            }
        }

        private void mItmAddFile_Click(object sender, EventArgs e)
        {
            if (this.tvFolder.SelectedNode == null)
            {
                return;
            }
            FrmDocumentAdd frmDocumentAdd = new FrmDocumentAdd((this.tvFolder.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString(), "txt");
            frmDocumentAdd.ShowDialog();
            if (frmDocumentAdd.Changed)
            {
                // 获得子文件夹列表
                this.GetFileList();
            }
        }

        private void mItmAddFolder_Click(object sender, EventArgs e)
        {
            this.AddFolder(false);
        }

        private void mItmAddRootFolder_Click(object sender, EventArgs e)
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

        private void mItmFrmFolderAdmin_Click(object sender, EventArgs e)
        {
            FrmFolderAdmin FrmFolderAdmin = new FrmFolderAdmin();
            if (FrmFolderAdmin.ShowDialog() == DialogResult.OK)
            {
                // 设置开关变量
                this.FormLoaded = false;
                // 加载窗体
                this.FormOnLoad();
                this.FormLoaded = true;
            }
        }

        private void grdFile_Click(object sender, EventArgs e)
        {
            this.LastControl = this.grdFile;
        }

        private void grdFolder_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            //// 提示删除确认
            //if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            //{
            //    e.Cancel = true;
            //}
        }

        private void SaveFile(string fileId)
        {
            BaseFileEntity fileEntity = DotNetService.Instance.FileService.GetEntity(UserInfo, fileId);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            // SaveFileDialog.Filter = "位图文件(*.bmp)|*.bmp|JPEG(*.JPG;*.JPEG;*.JPE;*.JFIF)|*.JPG;*.JPEG;*.JPE;*.JFIF|GIF(*.GIF)|*.GIF|TIFF(*.TIF;*.TIIF)|*.TIF;*.TIIF|PNG(*.PNG)|*.PNG|ICO(*.ICO)|*.ICO|所有图片文件|(*.bmp;*.JPG;*.JPEG;*.JPE;*.JFIF;*.GIF;*.TIF;*.TIIF;*.PNG;*.ICO)|所有文件|*.*";
            // SaveFileDialog.FilterIndex = 7;
            saveFileDialog.FileName = fileEntity.FileName;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                FileUtil.SaveFile(DotNetService.Instance.FileService.Download(UserInfo, fileId), fileName);
            }
        }

        private void grdFile_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.EntityId))
            {
                this.SaveFile(this.EntityId);
            }
        }

        private void grdFile_Sorted(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (this.permissionMoveFile || this.permissionEditFile)
            {
                string[] sequence = DotNetService.Instance.SequenceService.GetBatchSequence(UserInfo, BaseFileEntity.TableName, this.DTFileList.DefaultView.Count);
                int i = 0;
                foreach (DataRowView dataRowView in this.DTFileList.DefaultView)
                {
                    dataRowView.Row[BaseFileEntity.FieldSortCode] = sequence[i];
                    i++;
                }
                // 控制导航按钮
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

        private void grdFile_DragOver(object sender, DragEventArgs e)
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
                //if (!statusCode.Equals(StatusCode.OKAdd.ToString()))
                //{
                //    MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return returnValue;
                //}

                //上传目录下的文件
                int intReturnValue = 0;
                //string[] folder = (string[])e.Data.GetData(DataFormats.FileDrop);
                string[] folder = Directory.GetFiles(directory);
                for (int i = 0; i <= folder.Length - 1; i++)
                {
                    //returnValue为当前目录的主键，如果returnValue为空，则获取出已存在的目录的主键
                    if (returnValue == "")
                    {
                        string conectionString = BaseSystemInfo.UserCenterDbConnection;
                        IDbHelper userCenterDbHelper = DbHelperFactory.GetHelper(conectionString);
                        userCenterDbHelper.Open();
                        BaseFolderManager folderManager = new BaseFolderManager(userCenterDbHelper, this.UserInfo);
                        returnValue = folderManager.GetId(new KeyValuePair<string, object>(BaseFolderEntity.FieldFolderName, folderName), new KeyValuePair<string, object>(BaseFolderEntity.FieldParentId, parentId));
                    }
                    if (this.AddFile(returnValue, folder[i], false, false).Length > 0)
                    {
                        intReturnValue++;
                    }
                    if (this.AddFolder(returnValue, folder[i], true).Length > 0)
                    {
                        intReturnValue++;
                    }
                }

                //子文件夹处理
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

        /// <summary>
        /// 检查上传文件大小和剩余空间容量
        /// </summary>
        public bool CheckUploadSumSize(int currentFileSize, int oldFileSize)
        {
            bool returnValue = true;
            if (this.UploadMaxSumSize != 0)
            {
                if (currentFileSize > this.UploadMaxSumSize)
                {
                    // 上传的文件太大了
                    MessageBox.Show(AppMessage.MSG0206, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    returnValue = false;
                }
                //int sumSize = 0;
                //foreach (DataRowView dataRowView in this.dataTable.DefaultView)
                //{
                //    sumSize += int.Parse(dataRowView.Row[BaseFileEntity.FieldFileSize].ToString());
                //}
                //// 计算被替换的文件的大小
                //if (this.UploadMaxSumSize < sumSize + currentFileSize - oldFileSize)
                //{
                //    // 上传的文件太大了
                //    MessageBox.Show(AppMessage.MSG0206, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    returnValue = false;
                //}
            }
            return returnValue;
        }

        /// <summary>
        /// 新上传一个文件时判断
        /// </summary>
        /// <param name="currentFileSize">当前文件大小</param>
        /// <returns>是否可以上传</returns>
        public bool CheckUploadSumSize(int currentFileSize)
        {
            return this.CheckUploadSumSize(currentFileSize, 0);
        }

        /// <summary>
        /// 检查上传文件的剩余空间容量
        /// </summary>
        //public bool CheckUploadSumSize()
        //{
        //    return this.CheckUploadSumSize(0);
        //}

        private string AddFile(string parentId, string filePath, bool child, bool overwritePrompt)
        {
            string returnValue = string.Empty;
            if (System.IO.File.Exists(filePath))
            {
                // 获得最终的文件名
                string fileName = Path.GetFileName(filePath);
                if (!ValidateUtil.CheckFolderName(fileName))
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0032, fileName), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    {
                        return returnValue;
                    }
                }

                // 检查上传文件容量
                byte[] file = FileUtil.GetFile(filePath);
                int currentFileSize = file.Length;
                if (!this.CheckUploadSumSize(currentFileSize))
                {
                    file = null;
                    return returnValue;
                }

                if (DotNetService.Instance.FileService.Exists(UserInfo, parentId, fileName))
                {
                    if (overwritePrompt == true)
                    {
                        if ((MessageBox.Show(AppMessage.Format(AppMessage.MSG0205, fileName), AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Cancel))
                        {
                            return returnValue;
                        }
                    }
                }
                returnValue = DotNetService.Instance.FileService.Upload(UserInfo, parentId, fileName, FileUtil.GetFile(filePath), true);
            }
            return returnValue;
        }

        private void grdFile_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                int returnValue = 0;
                string[] folder = (string[])e.Data.GetData(DataFormats.FileDrop);
                for (int i = 0; i <= folder.Length - 1; i++)
                {
                    if (this.AddFile(this.ParentEntityId, folder[i], false, false).Length > 0)
                    {
                        returnValue++;
                    }
                    if (this.AddFolder(this.ParentEntityId, folder[i], true).Length > 0)
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
            foreach (DataGridViewRow dgvRow in grdFile.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }

            //foreach (DataRow dataRow in this.DTFileList.Rows)
            //{
            //    dataRow["colSelected"] = true.ToString();
            //}
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in grdFile.Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false);
            }

            //foreach (DataRow dataRow in this.DTFileList.Rows)
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
            return BaseInterfaceLogic.GetSelecteIds(this.grdFile, BaseFileEntity.FieldId, "colSelected", true);
        }
        #endregion

        #region public string AddFolder(bool root) 添加文件夹
        /// <summary>
        /// 添加文件夹
        /// </summary>
        /// <param name="root">根目录</param>
        /// <returns>主键</returns>
        public string AddFolder(bool root)
        {
            string returnValue = string.Empty;
            FrmFolderAdd FrmFolderAdd;
            if ((root) || (this.tvFolder.SelectedNode == null))
            {
                FrmFolderAdd = new FrmFolderAdd();
            }
            else
            {
                FrmFolderAdd = new FrmFolderAdd((this.tvFolder.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString(), this.tvFolder.SelectedNode.Text);
            }
            if (FrmFolderAdd.ShowDialog(this) == DialogResult.OK)
            {
                returnValue = FrmFolderAdd.EntityId;
                this.FormLoaded = false;
                // 绑定屏幕数据
                this.FormOnLoad();
                this.FormLoaded = true;
            }
            return returnValue;
        }
        #endregion

        private bool OnAdded(string parentId, string fullName, string id)
        {

            BaseInterfaceLogic.FindTreeNode(this.tvFolder, BaseFileEntity.FieldId, parentId);
            //if (BaseInterfaceLogic.TargetNode != null)
            //{
            this.tvFolder.SelectedNode = BaseInterfaceLogic.TargetNode;
            //string parentId = parentEntityId;
            // tvModule 中增加结点
            TreeNode newNode = new TreeNode();
            newNode.Text = fullName;
            newNode.Tag = DotNetService.Instance.FileService.GetDataTableByIds(this.UserInfo, new string[] { id }).Rows[0];
            BaseInterfaceLogic.AddTreeNode(this.tvFolder, newNode, this.tvFolder.SelectedNode);
            this.tvFolder.SelectedNode = newNode;
            // 展开当前选中节点的所有父节点
            BaseInterfaceLogic.ExpandTreeNode(this.tvFolder);
            //}
            return true;
        }

        /// <summary>
        /// 添加文件
        /// </summary>
        /// <returns>主键</returns>
        public string Add()
        {
            string returnValue = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < openFileDialog.FileNames.Length; i++)
                {
                    string filePath = openFileDialog.FileNames[i];
                    returnValue = this.AddFile(this.ParentEntityId, filePath, false, true);
                }
            }
            return returnValue;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (this.Add().Length > 0)
                {
                    this.GetFileList();
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
            string id = (this.tvFolder.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
            FrmFolderEdit frmFolderEdit = new FrmFolderEdit(id);
            if (frmFolderEdit.ShowDialog(this) == DialogResult.OK)
            {
                this.FormLoaded = false;
                // 绑定屏幕数据
                this.FormOnLoad();
                this.FormLoaded = true;
            }
        }
        #endregion

        #region private void EditGrid() 编辑模块
        /// <summary>
        /// 编辑模块
        /// </summary>
        private void EditGrid()
        {
            //if (BaseInterfaceLogic.CheckInputSelectOne(this.grdFile, "colSelected"))
            //{
            string id = BaseInterfaceLogic.GetDataGridViewEntityId(this.grdFile, BaseModuleEntity.FieldId);
            // DataTable dtFile = DotNetService.Instance.FileService.Get(UserInfo, id);
            BaseFileEntity fileEntity = new BaseFileEntity();
            Form frmFileEdit = null;
            // frmFileEdit = new FrmDocumentEdit(id);
            frmFileEdit = new FrmFileEdit(id);
            if (frmFileEdit.ShowDialog(this) == DialogResult.OK)
            {
                this.FormLoaded = false;
                // 绑定屏幕数据
                this.GetFileList();
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
            if (this.LastControl == this.grdFile)
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
                BaseInterfaceLogic.FindTreeNode(this.tvFolder, FrmFolderSelect.SelectedId);
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
            if (this.LastControl == this.grdFile)
            {
                BaseInterfaceLogic.FindTreeNode(this.tvFolder, FrmFolderSelect.SelectedId);
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
            FrmFolderSelect = new FrmFolderSelect(this.parentEntityId);
            // FrmFolderSelect.OnButtonConfirmClick += new FrmFolderSelect.ButtonConfirmEventHandler(CheckInputMove);
            FrmFolderSelect.AllowNull = false;
            if (FrmFolderSelect.ShowDialog() == DialogResult.OK)
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                this.FormLoaded = false;
                // 调用事件
                DotNetService.Instance.FileService.BatchMoveTo(UserInfo, this.GetSelecteIds(), FrmFolderSelect.SelectedId);
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
            FrmFolderSelect = new FrmFolderSelect(this.parentEntityId);
            FrmFolderSelect.OnButtonConfirmClick += new FrmFolderSelect.ButtonConfirmEventHandler(CheckInputMove);
            FrmFolderSelect.AllowNull = true;
            if (FrmFolderSelect.ShowDialog() == DialogResult.OK)
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                this.FormLoaded = false;
                // 调用事件
                DotNetService.Instance.FolderService.MoveTo(UserInfo, currentEntityId, FrmFolderSelect.SelectedId);
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
            if (this.LastControl == this.grdFile)
            {
                if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdFile, "colSelected"))
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
            this.GetFileList();
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
            returnValue = DotNetService.Instance.FileService.BatchDelete(UserInfo, this.GetSelecteIds());
            // 绑定数据
            this.FormOnLoad();
            this.FormLoaded = true;
            return returnValue;
        }
        #endregion

        public int Delete()
        {
            int returnValue = 0;
            if (this.LastControl == this.grdFile)
            {
                if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdFile, "colSelected"))
                {
                    if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        // 设置鼠标繁忙状态，并保留原先的状态
                        Cursor holdCursor = this.Cursor;
                        this.Cursor = Cursors.WaitCursor;
                        try
                        {
                            returnValue = this.BatchDelete();
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
            DotNetService.Instance.FileService.BatchSave(UserInfo, this.DTFileList);
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
            if (BaseInterfaceLogic.CheckInputModifyAnyOne(this.DTFileList))
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
                    this.DTFileList.AcceptChanges();
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

        private void btnFolderAdmin_Click(object sender, EventArgs e)
        {
            FrmFolderAdmin frmFolderAdmin = new FrmFolderAdmin();
            frmFolderAdmin.ShowDialog();
            if (frmFolderAdmin.Changed)
            {
                // 设置开关变量
                this.FormLoaded = false;
                // 加载窗体
                this.FormOnLoad();
                this.FormLoaded = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmFolderAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BaseInterfaceLogic.IsModfiedAnyOne(this.DTFileList))
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
            this.ExportExcel(this.grdFile, @"\Modules\Export\", exportFileName);
        }
    }
}