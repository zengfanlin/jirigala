//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    
    using DotNet.Business;
    

    /// <summary>
    /// FrmPermissionItemModuleBatchSet.cs
    /// 模块管理窗体
    ///		
    /// 修改记录
    ///     2011.07.23 版本：1.2 张广梁    修改tvModule  tvPermissionItem节点选择时的逻辑错误
    ///     2011.07.17 版本：1.1 张广梁    优化tvModule节点选择，自动选择父节点
    ///     2011.03.20 版本：1.0 JiRiGaLa  模块管理功能页面编写。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.03.20</date>
    /// </author>
    /// </summary>
    public partial class FrmPermissionItemModuleBatchSet : BaseForm
    {
        /// <summary>
        /// 权限域（范围权限、数据权限）
        /// </summary>
        private string PermissionItemScopeCode = "Resource.AccessPermission";

        /// <summary>
        /// 模块 DataTable
        /// </summary>
        private DataTable DTModule = new DataTable(BaseModuleEntity.TableName);

        private string[] ModuleIds = null;

        /// <summary>
        /// 操作权限项数据
        /// </summary>
        public DataTable DTPermissionItem = new DataTable(BasePermissionItemEntity.TableName);

        /// <summary>
        /// 目标模块主键
        /// </summary>
        public string TargetPermissionItemId
        {
            get
            {
                string permissionItemId = string.Empty;
                if (this.tvPermissionItem.SelectedNode != null)
                {
                    permissionItemId = (this.tvPermissionItem.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                }
                return permissionItemId;
            }
        }

        /// <summary>
        /// 是否是用户点击了复选框
        /// </summary>
        private bool isUserClick = true;

        public FrmPermissionItemModuleBatchSet()
        {
            InitializeComponent();
        }

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.isUserClick = false;

            this.DTModule = this.GetModuleScope(this.PermissionItemScopeCode);
            
            this.DTPermissionItem = this.GetPermissionItemScop(this.PermissionItemScopeCode);

            this.LoadTree();

            this.tvPermissionItem.Enabled = true;
            this.tvModule.Enabled = false;

            this.isUserClick = true;
        }
        #endregion

        #region private void LoadTree() 加载树的主键
        /// <summary>
        /// 加载树的主键
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvModule.BeginUpdate();
            this.tvModule.Nodes.Clear();
            this.LoadTreeModule();
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvModule.EndUpdate();

            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvPermissionItem.BeginUpdate();
            this.tvPermissionItem.Nodes.Clear();
            this.LoadTreePermissionItem();
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvPermissionItem.EndUpdate();
        }
        #endregion

        private void LoadTreeModule()
        {
            TreeNode treeNode = new TreeNode();
            this.LoadTreeModule(treeNode);
        }

        #region private void LoadTreeModule(TreeNode treeNode) 加载模块菜单树
        /// <summary>
        /// 加载模块菜单树
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeModule(TreeNode treeNode)
        {
            BaseInterfaceLogic.LoadTreeNodes(this.DTModule, BaseModuleEntity.FieldId, BaseModuleEntity.FieldParentId, BaseModuleEntity.FieldFullName, this.tvModule, treeNode, true, 2, BaseModuleEntity.FieldCode);
        }
        #endregion

        private void LoadTreePermissionItem()
        {
            TreeNode treeNode = new TreeNode();
            this.LoadTreePermissionItem(treeNode);
        }

        #region private void LoadTreePermissionItem(TreeNode treeNode) 加载操作权限树
        /// <summary>
        /// 加载操作权限树
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreePermissionItem(TreeNode treeNode)
        {
            BaseInterfaceLogic.LoadTreeNodes(this.DTPermissionItem, BasePermissionItemEntity.FieldId, BasePermissionItemEntity.FieldParentId, BasePermissionItemEntity.FieldFullName, this.tvPermissionItem, treeNode, true, 2, BasePermissionItemEntity.FieldCode);
        }
        #endregion

        private void ModuleCheck()
        {
            // 递归调用到所有的子节点 
            for (int i = 0; i < this.tvModule.Nodes.Count; i++)
            {
                this.ModuleCheck(this.tvModule.Nodes[i]);
            }
        }

        private void ModuleCheck(TreeNode treeNode)
        {
            if ((treeNode!= null && treeNode.Tag != null && (treeNode.Tag as DataRow) != null))
            {
                string permissionItemId = (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                treeNode.Checked = Array.IndexOf(this.ModuleIds, permissionItemId) >= 0;
                for (int i = 0; i < treeNode.Nodes.Count; i++)
                {
                    // 这里进行递规操作
                    this.ModuleCheck(treeNode.Nodes[i]);
                }
            }
        }

        private void GetCurrentPermission()
        {
            this.isUserClick = false;

            // 这些空间可以用了
            this.tvPermissionItem.Enabled = true;

            // 当前选中的角色被改变
            // 初始化权限设置页面
            this.ClearCheck();

            // 获取模块访问权限
            this.ModuleIds = DotNetService.Instance.ModuleService.GetIdsByPermission(UserInfo, this.TargetPermissionItemId);
            if (this.ModuleIds != null && this.ModuleIds.Length > 0)
            {
                this.tvModule.BeginUpdate();
                this.ModuleCheck();
                this.tvModule.EndUpdate();
            }

            this.tvModule.Enabled = true;
            // 获取角色的权限
            this.isUserClick = true;
        }

        #region private void ClearCheck(TreeNode treeNode)
        /// <summary>
        /// 取消选中状态
        /// </summary>
        /// <param name="treeNode">树节点</param>
        private void ClearCheck(TreeNode treeNode)
        {
            if ((treeNode!= null && treeNode.Tag != null && (treeNode.Tag as DataRow) != null))
            {
                treeNode.Checked = false;
                for (int i = 0; i < treeNode.Nodes.Count; i++)
                {
                    // 这里进行递规操作
                    this.ClearCheck(treeNode.Nodes[i]);
                }
            }
        }
        #endregion

        /// <summary>
        /// 初始化权限设置页面
        /// </summary>
        private void ClearCheck()
        {
            // 模块菜单选中状态被取消
            for (int i = 0; i < this.tvModule.Nodes.Count; i++)
            {
                this.ClearCheck(this.tvModule.Nodes[i]);
            }
            // 操作权限项被选中状态取消
            for (int i = 0; i < this.tvPermissionItem.Nodes.Count; i++)
            {
                this.ClearCheck(this.tvPermissionItem.Nodes[i]);
            }
        }

        private void tvModule_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (this.isUserClick)
            {
                if (e.Node.Checked)
                {
                    // 关联操作权限
                    DotNetService.Instance.ModuleService.BatchAddModules(UserInfo, this.TargetPermissionItemId, new string[] { (e.Node.Tag as DataRow)[BaseModuleEntity.FieldId].ToString() });
                }
                else
                {
                    // 撤销关联操作权限
                    DotNetService.Instance.ModuleService.BatchDleteModules(UserInfo, this.TargetPermissionItemId, new string[] { (e.Node.Tag as DataRow)[BaseModuleEntity.FieldId].ToString() });
                }

            }
        }


        private void tvPermissionItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvPermissionItem.GetNodeAt(e.X, e.Y) != null)
            {
                tvPermissionItem.SelectedNode = tvPermissionItem.GetNodeAt(e.X, e.Y);
            }
        }

        private void tvPermissionItem_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                // if (this.FormLoaded)
                // {
                this.GetCurrentPermission();
                // }
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

        private void tvModule_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // CheckChild(e.Node);
            // CheckParent(e.Node);
        }

        /// <summary>
        /// 递归检查字节点
        /// </summary>
        /// <param name="node"></param>
        private void CheckChild(TreeNode node)
        {
            bool childNodeCheck = false;

            if (node.Nodes.Count != 0)
            {
                //如果节点下有已选子节点
                foreach (TreeNode item in node.Nodes)
                {
                    childNodeCheck = item.Checked;
                    if (childNodeCheck)
                        break;
                }

                //1、如果node下有子节点checked，展开或者收缩节点不影响子节点的选择
                //2、如果节点由checked 变为Uncheced  子节点也都 变成unchecked
                if (!childNodeCheck || !node.Checked)
                {
                    foreach (TreeNode item in node.Nodes)
                    {
                        item.Checked = node.Checked;
                        CheckChild(item);
                    }
                }


            }
        }
        /// <summary>
        /// 递归检查父节点，如果父节点下有node是checked，则该父节点是checked
        /// </summary>
        /// <param name="node"></param>
        private void CheckParent(TreeNode node)
        {
            bool childNodeCheck = false;
            if (node.Parent != null)
            {
                foreach (TreeNode item in node.Parent.Nodes)
                {
                    childNodeCheck = item.Checked;
                    if (childNodeCheck)
                        break;
                }
                node.Parent.Checked = childNodeCheck;
                CheckParent(node.Parent);
            }

        }
    }
}