//-----------------------------------------------------------
// All Rights Reserved , Copyright (C) 2010 ,Jirisoft , Ltd .
//-----------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Utilities;
    using DotNet.Business;

    /// <summary>
    /// FrmUserModulePermissionItem.cs
    /// 模块管理-模块配置
    ///		
    /// 修改记录
    ///
    ///     2011.10.15 版本: 2.2 JiRiGaLa  关联操作权限的功能改进。
    ///     2009.11.09 版本: 2.1 JiRiGaLa  公开的模块没必要设置权限了，提高效率及友善性。
    ///     2007.08.02 版本: 2.0 JiRiGaLa  解决全选反选问题增加 isUserClick 变量控制。
    ///     2007.05.28 版本: 1.1 JiRiGaLa  添加全选反选按钮。
    ///     2007.05.22 版本：1.0 JiRiGaLa  模块配置。
    ///		
    /// 版本：2.2
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.10.15</date>
    /// </author> 
    /// </summary>
    public partial class FrmUserModulePermissionItem : BaseForm
    {
        private DataTable DTModule = new DataTable(BaseModuleEntity.TableName);
        private string[] ModuleIds = null;
        private string[] PermissionItemIds = null;

        private bool isUserClick        = false;    // 是否是用户点击了复选框

        /// <summary>
        /// 权限域（范围权限、数据权限）
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        public FrmUserModulePermissionItem()
        {
            InitializeComponent();
        }

        public FrmUserModulePermissionItem(string userId, string userRealame)
            : this()
        {
            this.ucUser.SelectedId = userId;
            this.ucUser.SelectedFullName = userRealame;
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
            this.ModuleIds = DotNetService.Instance.PermissionService.GetUserScopeModuleIds(UserInfo, this.ucUser.SelectedId, "Resource.AccessPermission");

            // 获得用户的操作权限主键数组
            this.PermissionItemIds = DotNetService.Instance.PermissionService.GetUserPermissionItemIds(UserInfo, this.ucUser.SelectedId);

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
            if (this.tvModulePermissionItem.SelectedNode == null)
            {
                if (this.tvModulePermissionItem.Nodes.Count > 0)
                {
                    this.tvModulePermissionItem.SelectedNode = this.tvModulePermissionItem.Nodes[0];                    
                }
            }
            if (this.tvModulePermissionItem.SelectedNode != null)
            {
                // 让选中的节点可视，并用展开方式
                this.tvModulePermissionItem.SelectedNode.Expand();
                this.tvModulePermissionItem.SelectedNode.EnsureVisible();
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
            this.tvModulePermissionItem.BeginUpdate();
            this.tvModulePermissionItem.Nodes.Clear();
            TreeNode treeNode = new TreeNode();
            this.LoadTreeModule(treeNode);
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvModulePermissionItem.EndUpdate();
        }
        #endregion

        #region private void LoadTreeModule(TreeNode treeNode)
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="TreeNode">当前节点</param>
        private void LoadTreeModule(TreeNode treeNode)
        {
            BaseModuleEntity moduleEntity = null;

            DataTable permissionItemDT = null;
            
            string id = string.Empty;
            if ((treeNode.Tag != null))
            {
                moduleEntity = (BaseModuleEntity)treeNode.Tag;
                id = moduleEntity.Id.ToString();
            }
             
            foreach (DataRow dataRow in this.DTModule.Rows)
            {
                // 判断不为空的当前节点的子节点
                if ((!id.Equals(dataRow[BaseModuleEntity.FieldParentId].ToString())))
                {
                    continue;
                }
                // 当前节点的子节点, 加载根节点
                if ((dataRow.IsNull(BaseModuleEntity.FieldParentId) 
                    || (dataRow[BaseModuleEntity.FieldParentId].ToString().Length == 0) 
                    || (dataRow[BaseModuleEntity.FieldParentId].ToString().Equals("0")) 
                    || (dataRow[BaseModuleEntity.FieldParentId].ToString().Equals(BaseSystemInfo.RootMenuCode))
                    || (id.Equals(dataRow[BaseModuleEntity.FieldParentId].ToString()))))
                {
                    moduleEntity = new BaseModuleEntity(dataRow);
                    TreeNode newTreeNode = new TreeNode();

                    #if (DEBUG)
                        // newTreeNode.Text = moduleEntity.FullName + " [" + moduleEntity.Code +"]";
                        newTreeNode.Text = moduleEntity.FullName;
                    #else
                        newTreeNode.Text = moduleEntity.FullName;
                    #endif
                    
                    newTreeNode.Tag = moduleEntity;
                    if (!string.IsNullOrEmpty(moduleEntity.PermissionScopeTables))
                    {
                        newTreeNode.ImageIndex = 3;
                        newTreeNode.SelectedImageIndex = 3;
                    }
                    // 是否已经有这个模块访问权限
                    newTreeNode.Checked = Array.IndexOf(this.ModuleIds, moduleEntity.Id.ToString()) >= 0;
                    
                    if ((treeNode.Tag == null) || ((treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString().Length == 0))
                    {
                        // 树的根节点加载
                        this.tvModulePermissionItem.Nodes.Add(newTreeNode);
                    }
                    else
                    {
                        // 节点的子节点加载
                        treeNode.Nodes.Add(newTreeNode);
                    }

                    permissionItemDT = GetPermissionItemDT(moduleEntity.Id.ToString());
                    foreach (DataRow dataRowPermissionItem in permissionItemDT.Rows)
                    {
                        TreeNode treeNodePermissionItem = new TreeNode();

                        #if (DEBUG)
                            treeNodePermissionItem.Text = dataRowPermissionItem[BasePermissionItemEntity.FieldFullName].ToString() + " [" + dataRowPermissionItem[BasePermissionItemEntity.FieldCode].ToString() +"]";
                        #else
                            treeNodePermissionItem.Text = dataRowPermissionItem[BasePermissionItemEntity.FieldFullName].ToString();
                        #endif

                        treeNodePermissionItem.Tag = dataRowPermissionItem[BasePermissionItemEntity.FieldId].ToString();
                        treeNodePermissionItem.ImageIndex = 14;
                        treeNodePermissionItem.SelectedImageIndex = 14;
                        // 是否已经有这个操作权限
                        treeNodePermissionItem.Checked = Array.IndexOf(this.PermissionItemIds, treeNodePermissionItem.Tag.ToString()) >= 0;
                        newTreeNode.Nodes.Add(treeNodePermissionItem);
                    }

                    if (treeNode.Level < 2)
                    {
                        treeNode.Expand();
                    }

                    // 递归调用本函数
                    this.LoadTreeModule(newTreeNode);
                }
            }
        }
        #endregion

        /// <summary>
        /// 操作权限列表
        /// </summary>
        /// <param name="moduleId">模块主键</param>
        /// <returns>数据表</returns>
        private DataTable GetPermissionItemDT(string moduleId)
        {
            string commandText = @" SELECT  *
                                      FROM BasePermissionItem
                                     WHERE (Id IN
                                                (SELECT PermissionId
                                                   FROM BasePermission
                                                  WHERE (ResourceId = '" + moduleId + @"') 
                                                        AND (ResourceCategory = 'BaseModule') 
                                                        AND (DeletionStateCode = 0)))
                                            AND (Enabled = 1) 
                                            AND (DeletionStateCode = 0)
                                   ORDER BY SortCode ";

            BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(this.UserInfo);
            return permissionItemManager.Fill(commandText);
        }

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAccess = this.IsModuleAuthorized("UserModulePermission");    // 访问权限
            this.permissionEdit = this.IsModuleAuthorized("UserModulePermission");      // 编辑权限
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
        }
        #endregion

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

        private void tvModulePermissionItem_DoubleClick(object sender, EventArgs e)
        {
            if (this.tvModulePermissionItem.SelectedNode != null)
            {
                if (this.tvModulePermissionItem.SelectedNode.ImageIndex != 14)
                {
                    BaseModuleEntity moduleEntity = (BaseModuleEntity)(this.tvModulePermissionItem.SelectedNode.Tag);
                    if (!string.IsNullOrEmpty(moduleEntity.PermissionScopeTables))
                    {
                        string resourceCategory = BaseUserEntity.TableName;
                        string resourceId = this.ucUser.SelectedId;
                        string tableName = moduleEntity.PermissionScopeTables;
                        FrmTableScopeConstraint frmTableScopeConstraint = new FrmTableScopeConstraint(resourceCategory, resourceId, tableName);
                        frmTableScopeConstraint.ShowDialog();
                    }
                }
            }
        }

        private void tvModulePermissionItem_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            BaseInterfaceLogic.CheckChild(e.Node);
            BaseInterfaceLogic.CheckParent(e.Node);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            this.isUserClick = false;
            for (int i = 0; i < this.tvModulePermissionItem.Nodes.Count; i++)
            {
                this.SetTreeNodesSelected(this.tvModulePermissionItem.Nodes[i], true);
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
            for (int i = 0; i < this.tvModulePermissionItem.Nodes.Count; i++)
            {
                this.SetTreeNodesTurnSelected(this.tvModulePermissionItem.Nodes[i]);
            }
            this.isUserClick = true;
        }

        /// <summary>
        /// 授权的模块访问权限
        /// </summary>
        private string GrantModules = string.Empty;

        /// <summary>
        /// 撤销的模块访问权限
        /// </summary>
        private string RevokeModules = string.Empty;

        private void ModulesEntityToArray(TreeNode treeNode)
        {
            if (treeNode.Tag != null)
            {
                // 提高运行速度
                if (treeNode.ImageIndex != 14)
                {
                    string moduleId = ((BaseModuleEntity)treeNode.Tag).Id.ToString();
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
            }
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.ModulesEntityToArray(treeNode.Nodes[i]);
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
                if (treeNode.Checked && treeNode.ImageIndex != 14)
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
            for (int i = 0; i < this.tvModulePermissionItem.Nodes.Count; i++)
            {
                TreeNode treeNode = this.tvModulePermissionItem.Nodes[i];
                this.CheckParentChecked(treeNode);
            }
        }

        /// <summary>
        /// 授权的操作权限
        /// </summary>
        private string GrantPermissionItems = string.Empty;

        /// <summary>
        /// 撤销的操作权限
        /// </summary>
        private string RevokePermissionItems = string.Empty;

        private void PermissionItemEntityToArray(TreeNode treeNode)
        {
            if (treeNode.Tag != null)
            {
                // 提高运行速度
                if (treeNode.ImageIndex == 14)
                {
                    string permissionItemId = (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                    if (treeNode.Checked)
                    {
                        // 这里是授权的权限
                        if (Array.IndexOf(this.PermissionItemIds, permissionItemId) < 0)
                        {
                            this.GrantPermissionItems += permissionItemId + ";";
                        }
                    }
                    else
                    {
                        // 这里是撤销的权限
                        if (Array.IndexOf(this.PermissionItemIds, permissionItemId) >= 0)
                        {
                            this.RevokePermissionItems += permissionItemId + ";";
                        }
                    }
                }
            }
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.PermissionItemEntityToArray(treeNode.Nodes[i]);
            }
        }

        #region private bool DoBatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private bool DoBatchSave()
        {
            // 模块访问权限的处理部分
            bool returnValue = true;
            for (int i = 0; i < this.tvModulePermissionItem.Nodes.Count; i++)
            {
                this.ModulesEntityToArray(this.tvModulePermissionItem.Nodes[i]);
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
            if (grantModuleIds != null)
            {
                DotNetService.Instance.PermissionService.GrantUserModuleScopes(UserInfo, this.ucUser.SelectedId, "Resource.AccessPermission", grantModuleIds);
            }
            if (revokeModuleIds != null)
            {
                DotNetService.Instance.PermissionService.RevokeUserModuleScopes(UserInfo, this.ucUser.SelectedId, "Resource.AccessPermission", revokeModuleIds);
            }

            // 操作权限的处理部分
            for (int i = 0; i < this.tvModulePermissionItem.Nodes.Count; i++)
            {
                this.PermissionItemEntityToArray(this.tvModulePermissionItem.Nodes[i]);
            }
            string[] grantPermissionItemIds = null;
            string[] revokePermissionItemIds = null;
            if (this.GrantPermissionItems.Length > 2)
            {
                this.GrantPermissionItems = this.GrantPermissionItems.Substring(0, this.GrantPermissionItems.Length - 1);
                grantPermissionItemIds = this.GrantPermissionItems.Split(';');
            }
            if (this.RevokePermissionItems.Length > 1)
            {
                this.RevokePermissionItems = this.RevokePermissionItems.Substring(0, this.RevokePermissionItems.Length - 1);
                revokePermissionItemIds = this.RevokePermissionItems.Split(';');
            }
            this.GrantPermissionItems = string.Empty;
            this.RevokePermissionItems = string.Empty;
            if (grantPermissionItemIds != null)
            {
                DotNetService.Instance.PermissionService.GrantUserPermissions(UserInfo, new string[] { this.ucUser.SelectedId }, grantPermissionItemIds);
            }
            if (revokePermissionItemIds != null)
            {
                DotNetService.Instance.PermissionService.RevokeUserPermissions(UserInfo, new string[] { this.ucUser.SelectedId }, revokePermissionItemIds);
            }

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
            this.CheckParentChecked();
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