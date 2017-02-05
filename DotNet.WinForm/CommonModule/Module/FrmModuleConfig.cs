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
    /// FrmModuleConfig.cs
    /// 模块管理-模块配置
    ///		
    /// 修改记录
    /// 
    ///     2010.12.22 版本: 2.1 JiRiGaLa  主键变成数值类型后，不能正常加载菜单。
    ///     2007.08.02 版本: 2.0 JiRiGaLa  解决全选反选问题增加 isUserClick 变量控制。
    ///     2007.05.28 版本: 1.1 JiRiGaLa  添加全选反选按钮。
    ///     2007.05.22 版本：1.0 JiRiGaLa  模块配置。
    ///		
    /// 版本：2.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.12.22</date>
    /// </author> 
    /// </summary>
    public partial class FrmModuleConfig : BaseForm
    {
        /// <summary>
        /// 模块菜单数据表
        /// </summary>
        private DataTable DTModule = new DataTable(BaseModuleEntity.TableName);
        
        /// <summary>
        /// 原先被选中的节点主键
        /// </summary>
        public string OldEntityId = string.Empty; 

        private bool isUserClick        = false;    // 是否是用户点击了复选框

        private string currentEntityId = string.Empty;
        /// <summary>
        /// 当前选中的节点，树上
        /// </summary>
        public string CurrentEntityId
        {
            get
            {
                if ((this.tvModule.SelectedNode != null) && (this.tvModule.SelectedNode.Tag != null) && ((DataRow)this.tvModule.SelectedNode.Tag) != null)
                {
                    this.currentEntityId = ((DataRow)this.tvModule.SelectedNode.Tag)[BaseModuleEntity.FieldId].ToString();;
                }
                return this.currentEntityId;
            }
            set
            {
                this.currentEntityId = value;
            }
        }
                
        public FrmModuleConfig()
        {
            InitializeComponent();
        }

        public FrmModuleConfig(string currentId)  : this()
        {
            this.CurrentEntityId = currentId;
            this.OldEntityId = currentId;
        }

        #region private void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.isUserClick = false;
            this.DTModule = DotNetService.Instance.ModuleService.GetDataTable(UserInfo);
            // 有效性过滤，这个千万不能过滤的，这个过滤了，有效就设置不回来了
            // BUBaseBusinessLogic.SetFilter(this.DSModule.Tables[BaseModuleEntity.TableName], BaseModuleEntity.FieldEnabled, "1");
            // this.DSModule.Tables[BaseModuleEntity.TableName].AcceptChanges();
            this.BindData(true);
            //this.tvModule.ExpandAll();
            this.isUserClick = true;
        }
        #endregion

        #region private void BindData(bool reloadTree) 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        /// <param name="reloadTree">重新加载模块树</param>
        private void BindData(bool reloadTree)
        {
            // 加载模块树的主键
            if (reloadTree)
            {
                this.LoadTree();
            }
            if (this.tvModule.SelectedNode == null)
            {
                if (this.tvModule.Nodes.Count > 0)
                {
                    if (this.CurrentEntityId.Length == 0)
                    {
                        this.tvModule.SelectedNode = this.tvModule.Nodes[0];
                    }
                    else
                    {
                        BaseInterfaceLogic.FindTreeNode(this.tvModule, this.CurrentEntityId);
                        if (BaseInterfaceLogic.TargetNode != null)
                        {
                            this.tvModule.SelectedNode = BaseInterfaceLogic.TargetNode;
                            // 展开当前选中节点的所有父节点
                            BaseInterfaceLogic.ExpandTreeNode(this.tvModule);
                        }
                    }
                    if (this.tvModule.SelectedNode != null)
                    {
                        // 让选中的节点可视，并用展开方式
                        this.tvModule.SelectedNode.Expand();
                        this.tvModule.SelectedNode.EnsureVisible();
                    }
                }
            }
        }
        #endregion

        #region private void LoadTree() 加载树形结构数据
        /// <summary>
        /// 加载树形结构数据
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvModule.BeginUpdate();
            this.tvModule.Nodes.Clear();
            TreeNode treeNode = new TreeNode();

            //this.LoadTreeModule(treeNode);

            // 2012.06.11 Pcsky 改用基类的方式
            BaseInterfaceLogic.LoadTreeNodes(this.DTModule, BaseModuleEntity.FieldId, BaseModuleEntity.FieldParentId, BaseModuleEntity.FieldFullName, this.tvModule, treeNode, true, 0, null, 1, true, true);

            BaseInterfaceLogic.FindTreeNode(this.tvModule, this.OldEntityId);
            if (BaseInterfaceLogic.TargetNode != null)
            {
                this.tvModule.SelectedNode = BaseInterfaceLogic.TargetNode;
                BaseInterfaceLogic.ExpandTreeNode(this.tvModule);
                this.tvModule.SelectedNode.EnsureVisible();
                this.tvModule.SelectedNode.Expand();
            }
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvModule.EndUpdate();
        }
        #endregion

        #region private void LoadTreeModule(TreeNode treeNode)
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="TreeNode">当前节点</param>
        private void LoadTreeModule(TreeNode treeNode)
        {
            foreach (DataRow dataRow in this.DTModule.Rows)
            {
                // 判断不为空的当前节点的子节点
                if ((treeNode.Tag != null) && ((treeNode.Tag as DataRow) != null) && ((treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString().Length > 0) && (!(treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString().Equals(dataRow[BaseModuleEntity.FieldParentId].ToString())))
                {
                    continue;
                }
                // 当前节点的子节点, 加载根节点
                if ((dataRow.IsNull(BaseModuleEntity.FieldParentId) || (dataRow[BaseModuleEntity.FieldParentId].ToString().Length == 0) || (dataRow[BaseModuleEntity.FieldParentId].ToString().Equals("0")) || (dataRow[BaseModuleEntity.FieldParentId].ToString().Equals(BaseSystemInfo.RootMenuCode)) || ((treeNode.Tag != null) && (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString().Equals(dataRow[BaseModuleEntity.FieldParentId].ToString()))))
                {
                    TreeNode newTreeNode = new TreeNode();

                    // 写入调试信息
                    #if (DEBUG)
                        newTreeNode.Text = dataRow[BaseModuleEntity.FieldFullName].ToString() + " [" + dataRow[BaseModuleEntity.FieldCode].ToString() +"]";
                    #else
                        newTreeNode.Text = dataRow[BaseModuleEntity.FieldFullName].ToString();
                    #endif
                    
                    newTreeNode.Tag = dataRow;
                    newTreeNode.Checked = (dataRow[BaseModuleEntity.FieldEnabled].ToString().Equals("1"));

                    if (dataRow[BaseModuleEntity.FieldExpand].ToString().Equals("1"))
                    {
                        newTreeNode.Expand();
                    }
                    //else
                    //{
                    //    newTreeNode.Collapse(true);
                    //}
                    if ((treeNode.Tag == null) || ((treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString().Length == 0))
                    {
                        // 树的根节点加载
                        this.tvModule.Nodes.Add(newTreeNode);
                    }
                    else
                    {
                        // 节点的子节点加载
                        treeNode.Nodes.Add(newTreeNode);
                    }
                    // 递归调用本函数
                    this.LoadTreeModule(newTreeNode);
                }
            }
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAccess = this.IsModuleAuthorized("ModuleAdmin");    // 访问权限
            this.permissionEdit = this.IsAuthorized("ModuleAdmin.Edit");      // 编辑权限
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            if (this.DTModule.DefaultView.Count == 0)
            {
                this.btnSelectAll.Enabled = false;
                this.btnInvertSelect.Enabled = false;
                this.btnConfirm.Enabled = false;
            }
            else
            {
                this.btnSelectAll.Enabled = this.permissionEdit;
                this.btnInvertSelect.Enabled = this.permissionEdit;
                this.btnConfirm.Enabled = this.permissionEdit;
            }
        }
        #endregion

        private void tvModule_DragDrop(object sender, DragEventArgs e)
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
                        // 是否移动部门
                        if (MessageBox.Show(AppMessage.Format(AppMessage.MSG0038, treeNode.Text, targetTreeNode.Text), AppMessage.MSG0000, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    DotNetService.Instance.ModuleService.MoveTo(UserInfo, (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString(), (targetTreeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString());
                    // 往目标节点中加入被拖动节点的一份克隆
                    targetTreeNode.Nodes.Add((TreeNode)treeNode.Clone());
                    // 将被拖动的节点移除
                    treeNode.Remove();
                }
            }
        }

        private void tvModule_DragEnter(object sender, DragEventArgs e)
        {
            // 拖动效果设成移动
            e.Effect = DragDropEffects.Move;
        }

        private void tvModule_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (this.permissionEdit)
            {
                // 开始进行拖放操作，并将拖放的效果设置成移动。
                this.DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        #region private void SetTreeNodesSelected(TreeNode treeNode, bool selected) 递规设置树的选择状态
        /// <summary>
        /// 递规设置树的选择状态
        /// </summary>
        /// <param name="TreeNode">树节点</param>
        /// <param name="selected">选择</param>
        private void SetTreeNodesSelected(TreeNode treeNode, bool selected)
        {
            if ((treeNode!= null && treeNode.Tag != null && (treeNode.Tag as DataRow) != null))
            {
                treeNode.Checked = selected;
                for (int i = 0; i < treeNode.Nodes.Count; i++)
                {
                    // 这里进行递规操作
                    this.SetTreeNodesSelected(treeNode.Nodes[i], selected);
                }
            }
        }
        #endregion

        private void tvModule_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (this.isUserClick)
            {
                if (!this.permissionEdit)
                {
                    e.Cancel = true;
                }
            }
        }

        private void tvModule_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // 是用户点了复选框
            if (this.isUserClick)
            {
                for (int i = 0; i < e.Node.Nodes.Count; i++)
                {
                    e.Node.Nodes[i].Checked = e.Node.Checked;
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            this.isUserClick = false;
            for (int i = 0; i < this.tvModule.Nodes.Count; i++)
            {
                this.SetTreeNodesSelected(this.tvModule.Nodes[i], true);
            }
            this.isUserClick = true;
        }

        #region private void SetTreeNodesTurnSelected(TreeNode treeNode) 递规设置树的反选状态
        /// <summary>
        /// 递规设置树的反选状态
        /// </summary>
        /// <param name="TreeNode">树节点</param>
        private void SetTreeNodesTurnSelected(TreeNode treeNode)
        {
            if ((treeNode!= null && treeNode.Tag != null && (treeNode.Tag as DataRow) != null))
            {
                treeNode.Checked = !treeNode.Checked;
                for (int i = 0; i < treeNode.Nodes.Count; i++)
                {
                    // 这里进行递规操作
                    this.SetTreeNodesTurnSelected(treeNode.Nodes[i]);
                }
            }
        }
        #endregion

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            this.isUserClick = false;
            for (int i = 0; i < this.tvModule.Nodes.Count; i++)
            {
                this.SetTreeNodesTurnSelected(this.tvModule.Nodes[i]);
            }
            this.isUserClick = true;
        }

        private void EntityToDataTable(TreeNode treeNode)
        {
            // 提高运行速度
            DataRow[] dataRows = this.DTModule.Select(BaseModuleEntity.FieldId + "='" + (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString() + "'");
            foreach (DataRow dataRow in dataRows)
            {
                dataRow[BaseModuleEntity.FieldEnabled] = treeNode.Checked ? 1 : 0;
            }
            // BUBaseBusinessLogic.SetProperty(this.DSModule.Tables[BaseModuleEntity.TableName], (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString(), BaseModuleEntity.FieldEnabled, TreeNode.Checked ? 1 : 0);
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.EntityToDataTable(treeNode.Nodes[i]);
            }
        }

        #region private void BatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private void BatchSave()
        {
            for (int i = 0; i < this.tvModule.Nodes.Count; i++)
            {
                this.EntityToDataTable(this.tvModule.Nodes[i]);
            }
            DotNetService.Instance.ModuleService.BatchSave(UserInfo, this.DTModule);
            if (BaseSystemInfo.ShowInformation)
            {
                // 批量保存，进行提示
                MessageBox.Show(AppMessage.MSG0011, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        private void ReSet()
        {
            // 重新获取客户端的缓存模块数据
            ClientCache.Instance.DTMoule = DotNetService.Instance.ModuleService.GetDataTable(UserInfo);
            ClientCache.Instance.DTUserMoule = DotNetService.Instance.ModuleService.GetDataTable(UserInfo);
        }

        private void btnBatchSave_Click(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                // 批量保存
                this.BatchSave();
                // 重新获取客户端的缓存模块数据
                this.ReSet();
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

        private void tvModule_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvModule.GetNodeAt(e.X, e.Y) != null)
            {
                tvModule.SelectedNode = tvModule.GetNodeAt(e.X, e.Y);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // 关闭窗体
            this.Close();
        }
    }
}