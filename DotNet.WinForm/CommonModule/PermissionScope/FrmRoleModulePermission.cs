//-----------------------------------------------------------
// All Rights Reserved , Copyright (C) 2010 ,Jirisoft , Ltd .
//-----------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    
    using DotNet.Business;
    using DotNet.Utilities;
    

    /// <summary>
    /// FrmRoleModulePermission.cs
    /// 模块管理-模块配置
    ///		
    /// 修改记录
    /// 
    ///     2009.11.09 版本: 2.1 JiRiGaLa  公开的模块没必要设置权限了，提高效率及友善性
    ///     2007.08.02 版本: 2.0 JiRiGaLa  解决全选反选问题增加 isUserClick 变量控制
    ///     2007.05.28 版本: 1.1 JiRiGaLa  添加全选反选按钮
    ///     2007.05.22 版本：1.0 JiRiGaLa  模块配置。
    ///		
    /// 版本：2.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.08.02</date>
    /// </author> 
    /// </summary>
    public partial class FrmRoleModulePermission : BaseForm
    {
        private DataTable DTModule = new DataTable(BaseModuleEntity.TableName);  // 模块 DataTable
        private string[] ModuleIds = null;

        private bool isUserClick        = false;    // 是否是用户点击了复选框

        /// <summary>
        /// 权限域（范围权限、数据权限）
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        /// <summary>
        /// 这个页面是否只读
        /// </summary>
        private bool ReadOnly = false;

        public FrmRoleModulePermission()
        {
            InitializeComponent();
        }

        public FrmRoleModulePermission(string userId, string userRealame)
            : this()
        {
            this.ucRole.SelectedId = userId;
            this.ucRole.SelectedFullName = userRealame;
        }

        public FrmRoleModulePermission(string userId, string userRealame, bool readOnly)
            : this(userId, userRealame)
        {
            this.ReadOnly = readOnly;
        }

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.isUserClick = false;
            this.DTModule = this.GetModuleScope(this.PermissionItemScopeCode);
            
            // 公开的就没必要显示了
            // BaseBusinessLogic.SetFilter(this.DTModule, BaseModuleEntity.FieldIsPublic, "0");
            // 只有有效的才可以显示出来
            BaseBusinessLogic.SetFilter(this.DTModule, BaseModuleEntity.FieldEnabled, "1");
            this.DTModule.DefaultView.Sort = BaseModuleEntity.FieldSortCode;
            // 查找 ParentId 字段的值是否在 ID字段 里
            // BaseInterfaceLogic.CheckTreeParentId(this.DTModule, BaseModuleEntity.FieldId, BaseModuleEntity.FieldParentId);
            this.ModuleIds = DotNetService.Instance.PermissionService.GetRoleScopeModuleIds(UserInfo, this.ucRole.SelectedId, "Resource.AccessPermission");
            // 设置鼠标默认状态，原来的光标状态
            this.BindData(true);
            // 有效性过滤，这个千万不能过滤的，这个过滤了，有效就设置不回来了
            // BUBaseBusinessLogic.SetFilter(this.DSModule.Tables[BaseModuleEntity.TableName], BaseModuleEntity.FieldEnabled, "1");
            // this.DSModule.Tables[BaseModuleEntity.TableName].AcceptChanges();
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
                    this.tvModule.SelectedNode = this.tvModule.Nodes[0];
                    
                }
            }
            if (this.tvModule.SelectedNode != null)
            {
                // 让选中的节点可视，并用展开方式
                this.tvModule.SelectedNode.Expand();
                this.tvModule.SelectedNode.EnsureVisible();
            }
        }
        #endregion

        #region private void LoadTree() 加载树
        /// <summary>
        /// 加载树
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvModule.BeginUpdate();
            this.tvModule.Nodes.Clear();
            TreeNode treeNode = new TreeNode();
            this.LoadTreeModule(treeNode);
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
                if ((treeNode.Tag != null) && ((treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString().Length > 0) && (!(treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString().Equals(dataRow[BaseModuleEntity.FieldParentId].ToString())))
                {
                    continue;
                }
                // 当前节点的子节点, 加载根节点
                if ((dataRow.IsNull(BaseModuleEntity.FieldParentId) || (dataRow[BaseModuleEntity.FieldParentId].ToString().Length == 0) || (dataRow[BaseModuleEntity.FieldParentId].ToString().Equals("0")) || (dataRow[BaseModuleEntity.FieldParentId].ToString().Equals(BaseSystemInfo.RootMenuCode)) || ((treeNode.Tag != null) && (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString().Equals(dataRow[BaseModuleEntity.FieldParentId].ToString()))))
                {
                    TreeNode newTreeNode = new TreeNode();
                    newTreeNode.Text = dataRow[BaseModuleEntity.FieldFullName].ToString();
                    
                    //newTreeNode.Tag = dataRow[BaseModuleEntity.FieldId].ToString();
                    // 2012.06.20 Pcsky 修正Bug(用户管理：管理员授权报如下错误)
                    newTreeNode.Tag = dataRow;

                    // 是否已经有这个权限
                    newTreeNode.Checked = Array.IndexOf(this.ModuleIds, (newTreeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString()) >= 0;
                    
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
            this.permissionAccess = this.IsModuleAuthorized("RoleModulePermission");    // 访问权限
            this.permissionEdit = this.IsAuthorized("RoleModulePermission.Edit");      // 编辑权限
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
                this.btnBatchSave.Enabled = false;
            }
            else
            {
                this.btnSelectAll.Enabled = this.permissionEdit;
                this.btnInvertSelect.Enabled = this.permissionEdit;
                this.btnBatchSave.Enabled = this.permissionEdit;
            }
            if (this.ReadOnly)
            {
                this.btnSelectAll.Visible = false;
                this.btnInvertSelect.Visible = false;
                this.btnBatchSave.Visible = false;
            }
        }
        #endregion

        private void FrmRoleModulePermission_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    // 加载窗体
                    this.FormOnLoad();
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
            if (this.ReadOnly)
            {
                e.Cancel = true;
            }
            else if (this.isUserClick)
            {
                if (!this.permissionEdit)
                {
                    e.Cancel = true;
                }
            }
        }

        //private void tvModule_AfterCheck(object sender, TreeViewEventArgs e)
        //{
        //    // 是用户点了复选框
        //    if (this.isUserClick)
        //    {
        //        for (int i = 0; i < e.Node.Nodes.Count; i++)
        //        {
        //            e.Node.Nodes[i].Checked = e.Node.Checked;
        //        }
        //    }
        //}

        private void tvModule_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            BaseInterfaceLogic.CheckChild(e.Node);
            BaseInterfaceLogic.CheckParent(e.Node);

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

        /// <summary>
        /// 授权的权限
        /// </summary>
        private string GrantModules = string.Empty;

        /// <summary>
        /// 撤销的权限
        /// </summary>
        private string RevokeModules = string.Empty;

        private void EntityToArray(TreeNode treeNode)
        {
            if (treeNode.Tag != null)
            {
                // 提高运行速度
                string moduleId = (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                if (treeNode.Checked)
                {
                    // 这里是授权的权限
                    if (Array.IndexOf(this.ModuleIds, moduleId) < 0)
                    {
                        this.GrantModules += moduleId + ";";
                    }
                }
                else
                {
                    // 这里是撤销的权限
                    if (Array.IndexOf(this.ModuleIds, moduleId) >= 0)
                    {
                        this.RevokeModules += moduleId + ";";
                    }
                }
            }
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.EntityToArray(treeNode.Nodes[i]);
            }
        }

        private void CheckParentChecked(TreeNode treeNode)
        {
            // 递归调用到所有的子节点 
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                this.CheckParentChecked(treeNode.Nodes[i]);
            }
            // 检查父节点的选中状态
            while (treeNode.Parent != null)
            {
                if (treeNode.Checked)
                {
                    treeNode.Parent.Checked = treeNode.Checked;
                    treeNode = treeNode.Parent;
                }
                else
                {
                    break;
                }
            }
        }

        public void CheckParentChecked()
        {
            this.isUserClick = false;
            for (int i = 0; i < this.tvModule.Nodes.Count; i++)
            {
                TreeNode treeNode = this.tvModule.Nodes[i];
                this.CheckParentChecked(treeNode);
            }
        }

        #region private bool DoBatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private bool DoBatchSave()
        {
            bool returnValue = true;
            for (int i = 0; i < this.tvModule.Nodes.Count; i++)
            {
                this.EntityToArray(this.tvModule.Nodes[i]);
            }
            string[] grantModuleIds = null;
            string[] revokeModuleIds = null;
            if (this.GrantModules.Length > 2)
            {
                this.GrantModules = this.GrantModules.Substring(0, this.GrantModules.Length - 1);
                grantModuleIds = this.GrantModules.Split(';');
            }
            if (this.RevokeModules.Length > 1)
            {
                this.RevokeModules = this.RevokeModules.Substring(0, this.RevokeModules.Length - 1);
                revokeModuleIds = this.RevokeModules.Split(';');
            }
            this.GrantModules = string.Empty;
            this.RevokeModules = string.Empty;
            DotNetService.Instance.PermissionService.GrantRoleModuleScopes(UserInfo, this.ucRole.SelectedId, "Resource.AccessPermission", grantModuleIds);
            DotNetService.Instance.PermissionService.RevokeRoleModuleScopes(UserInfo, this.ucRole.SelectedId, "Resource.AccessPermission", revokeModuleIds);
            if (BaseSystemInfo.ShowInformation)
            {
                // 更新成功，进行提示
                MessageBox.Show(AppMessage.MSG0012, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return returnValue;
        }
        #endregion

        public void BatchSave()
        {
            // 批量保存
            // this.CheckParentChecked();
            if (this.DoBatchSave())
            {
                // 关闭窗口
                this.Close();
            }
        }

        private void btnBatchSave_Click(object sender, EventArgs e)
        {
            this.BatchSave();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // 关闭窗体
            this.Close();
        }
    }
}