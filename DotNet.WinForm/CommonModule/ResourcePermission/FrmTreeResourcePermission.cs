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
    /// FrmTreeResourcePermission.cs
    /// 模块管理-模块配置
    ///		
    /// 修改记录
    /// 
    ///     2010.07.09 版本: 3.0 JiRiGaLa  树型资源权限设置
    ///     2009.11.09 版本: 2.1 JiRiGaLa  公开的模块没必要设置权限了，提高效率及友善性
    ///     2007.08.02 版本: 2.0 JiRiGaLa  解决全选反选问题增加 isUserClick 变量控制
    ///     2007.05.28 版本: 1.1 JiRiGaLa  添加全选反选按钮
    ///     2007.05.22 版本：1.0 JiRiGaLa  模块配置。
    ///		
    /// 版本：3.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.07.09</date>
    /// </author> 
    /// </summary>
    public partial class FrmTreeResourcePermission : BaseForm
    {
        /// <summary>
        /// 是否是用户点击了复选框
        /// </summary>
        private bool isUserClick = false;

        /// <summary>
        /// 编辑权限
        /// </summary>
        private new bool permissionEdit = true;

        // <summary>
        /// 资源表
        /// </summary>
        DataTable DTTargetResource = new DataTable();

        private string[] setSelectIds = null;
        /// <summary>
        /// 选中的主键数组
        /// </summary>
        public string[] SetSelectIds
        {
            get
            {
                return this.setSelectIds;
            }
            set
            {
                this.setSelectIds = value;
            }
        }

        public string ResourceCategory = BaseUserEntity.TableName;
        public string ResourceId = string.Empty;
        public string ResourceName = string.Empty;

        public string PermissionItemId = "";
        public string PermissionItemCode = "OrganizeAdmin";
        public string PermissionItemName = "组织机构管理";

        public string TargetResourceCategory = "Organize";
        public string TargetResourceSQL = "SELECT Id, parentId, FullName AS RealName, Description, SortCode FROM BaseOrganize WHERE DeletionStateCode = 0 AND Enabled = 1 ORDER BY SortCode";

        private string fieldId = "Id";
        /// <summary>
        /// 主键列字段名
        /// </summary>
        public string FieldId
        {
            get
            {
                return fieldId;
            }
            set
            {
                fieldId = value;
            }
        }

        private string columnParentId = "ParentId";
        /// <summary>
        /// 主键列字段名
        /// </summary>
        public string FieldParentId
        {
            get
            {
                return columnParentId;
            }
            set
            {
                columnParentId = value;
            }
        }

        private string columnRealName = "RealName";
        /// <summary>
        /// 名称列字段名
        /// </summary>
        public string FieldRealName
        {
            get
            {
                return columnRealName;
            }
            set
            {
                columnRealName = value;
            }
        }

        private string columnDescription = "Description";
        /// <summary>
        /// 描述列字段名
        /// </summary>
        public string FieldDescription
        {
            get
            {
                return columnDescription;
            }
            set
            {
                columnDescription = value;
            }
        }

        public FrmTreeResourcePermission()
        {
            InitializeComponent();
        }

        public FrmTreeResourcePermission(string resourceCategory, string resourceId, string resourceName, string permissionItemCode, string targetCategory, string targetSQL)
            : this()
        {
            this.ResourceCategory = resourceCategory;
            this.ResourceId = resourceId;
            this.ResourceName = resourceName;
            this.PermissionItemCode = permissionItemCode;
            this.TargetResourceCategory = targetCategory;
            this.TargetResourceSQL = targetSQL;
        }


        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.isUserClick = false;

            // 若没找到就默认为当前用户
            if (string.IsNullOrEmpty(ResourceId))
            {
                ResourceCategory = BaseUserEntity.TableName;
                ResourceId = this.UserInfo.Id;
                ResourceName = this.UserInfo.RealName;
            }

            if (string.IsNullOrEmpty(this.PermissionItemId))
            {
                BasePermissionItemEntity permissionItemEntity = DotNetService.Instance.PermissionItemService.GetEntityByCode(this.UserInfo, this.PermissionItemCode);
                this.PermissionItemId = permissionItemEntity.Id.ToString();
                this.PermissionItemName = permissionItemEntity.FullName;
            }

            // 当前用户对哪些资源有权限（用户自己的权限 + 相应的角色拥有的权限 + 递归子节点的权限）
            // string[] ids = DotNetService.Instance.PermissionService.GetTreeResourceScopeIds(this.UserInfo, this.ResourceId, this.TargetCategory, this.PermissionItemCode, true);

            // 被选中的权限
            this.setSelectIds = DotNetService.Instance.PermissionService.GetPermissionScopeTargetIds(this.UserInfo, this.ResourceCategory, this.ResourceId, this.TargetResourceCategory, this.PermissionItemCode);
            // 读取资源
            this.DTTargetResource = DotNetService.Instance.UserCenterDbHelperService.Fill(this.UserInfo, this.TargetResourceSQL);
            this.DTTargetResource.PrimaryKey = new DataColumn[] { this.DTTargetResource.Columns[this.FieldId] };

            // 公开的就没必要显示了
            // BaseBusinessLogic.SetFilter(this.DTModule, BaseModuleEntity.FieldIsPublic, "0");
            // 只有有效的才可以显示出来
            // BaseBusinessLogic.SetFilter(this.dtTargetResource, BaseModuleEntity.FieldEnabled, "1");
            this.DTTargetResource.DefaultView.Sort = BaseModuleEntity.FieldSortCode;
            // 查找 ParentId 字段的值是否在 Id字段 里
            // BaseInterfaceLogic.CheckTreeParentId(this.DTModule, BaseModuleEntity.FieldId, BaseModuleEntity.FieldParentId);

            // 加载树型控件
            this.BindData(true);
            // this.tvResource.ExpandAll();

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
            if (this.tvResource.SelectedNode == null)
            {
                if (this.tvResource.Nodes.Count > 0)
                {
                    this.tvResource.SelectedNode = this.tvResource.Nodes[0];
                    
                }
            }
            if (this.tvResource.SelectedNode != null)
            {
                // 让选中的节点可视，并用展开方式
                this.tvResource.SelectedNode.Expand();
                this.tvResource.SelectedNode.EnsureVisible();
            }
        }
        #endregion

        #region private void LoadTree() 加载树的主键
        /// <summary>
        /// 加载树的主键
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvResource.BeginUpdate();
            this.tvResource.Nodes.Clear();
            TreeNode treeNode = new TreeNode();
            this.LoadTreeModule(treeNode);
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvResource.EndUpdate();
        }
        #endregion

        #region private void LoadTreeModule(TreeNode treeNode)
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="TreeNode">当前节点</param>
        private void LoadTreeModule(TreeNode treeNode)
        {
            foreach (DataRow dataRow in this.DTTargetResource.Rows)
            {
                // 判断不为空的当前节点的子节点
                if ((treeNode.Tag != null) && ((treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString().Length > 0) && (!(treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString().Equals(dataRow[this.FieldParentId].ToString())))
                {
                    continue;
                }
                // 当前节点的子节点, 加载根节点
                if ((dataRow.IsNull(this.FieldParentId) || (dataRow[this.FieldParentId].ToString().Length == 0) || (dataRow[this.FieldParentId].ToString().Equals(BaseSystemInfo.RootMenuCode)) || ((treeNode.Tag != null) && (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString().Equals(dataRow[this.FieldParentId].ToString()))))
                {
                    TreeNode newTreeNode = new TreeNode();
                    newTreeNode.Text = dataRow[this.FieldRealName].ToString();
                    newTreeNode.Tag = dataRow[this.FieldId].ToString();
                    // 是否已经有这个权限
                    newTreeNode.Checked = Array.IndexOf(this.SetSelectIds, (newTreeNode.Tag as DataRow)[BasePermissionItemEntity.FieldId].ToString()) >= 0;
                    
                    if ((treeNode.Tag == null) || ((treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString().Length == 0))
                    {
                        // 树的根节点加载
                        this.tvResource.Nodes.Add(newTreeNode);
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
            // this.permissionAccess = this.IsAuthorized("FrmUserModulePermissionBatchSet.Access");    // 访问权限
            // this.permissionEdit = this.IsAuthorized("FrmUserModulePermissionBatchSet.Edit");      // 编辑权限
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.lblResourceName.Text = this.ResourceName;
            this.lblPermissionItemName.Text = this.PermissionItemName;

            if (this.DTTargetResource.DefaultView.Count == 0)
            {
                this.btnSelectAll.Enabled = false;
                this.btnInvertSelect.Enabled = false;
                this.btnBatchSave.Enabled = false;
            }
            else
            {
                // this.btnSelectAll.Enabled = this.permissionEdit;
                // this.btnInvertSelect.Enabled = this.permissionEdit;
                // this.btnBatchSave.Enabled = this.permissionEdit;
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

        private void tvResourcee_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (this.isUserClick)
            {
                if (!this.permissionEdit)
                {
                    e.Cancel = true;
                }
            }
        }

        private void tvResource_AfterCheck(object sender, TreeViewEventArgs e)
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
            for (int i = 0; i < this.tvResource.Nodes.Count; i++)
            {
                this.SetTreeNodesSelected(this.tvResource.Nodes[i], true);
            }
            this.isUserClick = true;
        }

        #region private void SetTreeNodesTurnSelected(TreeNode treeNode) 递规设置树的反选状态
        /// <summary>
        /// 递规设置树的反选状态
        /// </summary>
        /// <param name="treeNode">树节点</param>
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
            for (int i = 0; i < this.tvResource.Nodes.Count; i++)
            {
                this.SetTreeNodesTurnSelected(this.tvResource.Nodes[i]);
            }
            this.isUserClick = true;
        }

        /// <summary>
        /// 授权的权限
        /// </summary>
        private string GrantResources = string.Empty;

        /// <summary>
        /// 撤销的权限
        /// </summary>
        private string RevokeResources = string.Empty;

        private void EntityToArray(TreeNode treeNode)
        {
            if (treeNode.Tag != null)
            {
                // 提高运行速度
                string resourceId = (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                if (treeNode.Checked)
                {
                    // 这里是授权的权限
                    if (Array.IndexOf(this.SetSelectIds, resourceId) < 0)
                    {
                        this.GrantResources += resourceId + ";";
                    }
                }
                else
                {
                    // 这里是撤销的权限
                    if (Array.IndexOf(this.SetSelectIds, resourceId) >= 0)
                    {
                        this.RevokeResources += resourceId + ";";
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
            for (int i = 0; i < this.tvResource.Nodes.Count; i++)
            {
                TreeNode treeNode = this.tvResource.Nodes[i];
                this.CheckParentChecked(treeNode);
            }
        }

        #region private bool DoBatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private int DoBatchSave()
        {
            int returnValue = 0;
            for (int i = 0; i < this.tvResource.Nodes.Count; i++)
            {
                this.EntityToArray(this.tvResource.Nodes[i]);
            }
            string[] grantResourceIds = null;
            string[] revokeResourceIds = null;
            if (this.GrantResources.Length > 2)
            {
                this.GrantResources = this.GrantResources.Substring(0, this.GrantResources.Length - 1);
                grantResourceIds = this.GrantResources.Split(';');
            }
            if (this.RevokeResources.Length > 1)
            {
                this.RevokeResources = this.RevokeResources.Substring(0, this.RevokeResources.Length - 1);
                revokeResourceIds = this.RevokeResources.Split(';');
            }
            this.GrantResources = string.Empty;
            this.RevokeResources = string.Empty;

            // 授予权限的资源
            if (grantResourceIds != null)
            {
                returnValue = DotNetService.Instance.PermissionService.GrantPermissionScopeTargets(this.UserInfo, this.ResourceCategory, this.ResourceId, this.TargetResourceCategory, grantResourceIds, this.PermissionItemId);
            }
            // 撤销权限的资源
            if (revokeResourceIds != null)
            {
                returnValue += DotNetService.Instance.PermissionService.RevokePermissionScopeTargets(this.UserInfo, this.ResourceCategory, this.ResourceId, this.TargetResourceCategory, revokeResourceIds, this.PermissionItemId);
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
            if (this.DoBatchSave() > 0)
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

        private void tvResource_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvResource.GetNodeAt(e.X, e.Y) != null)
            {
                tvResource.SelectedNode = tvResource.GetNodeAt(e.X, e.Y);
            }
        }        
    }
}