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
    /// FrmRolePermissionItemScope.cs
    /// 角色－可分配权限设定
    ///		
    /// 修改记录
    ///
    ///     2008.05.25 版本：1.0 JiRiGaLa 角色－权限管理。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.05.25</date>
    /// </author> 
    /// </summary>  
    public partial class FrmRolePermissionItemScope : BaseForm
    {
        private DataTable DTPermissionItem = new DataTable(BaseParameterEntity.TableName); // 权限数据表
        private string[] PermissionIds = null;

        /// <summary>
        /// 权限域编号
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";
        
        // 目标角色主键
        private string TargetRoleId
        {
            set
            {
                this.ucRole.SelectedId = value;
            }
            get
            {
                return this.ucRole.SelectedId;
            }
        }

        // 目标角色名称     
        private string TargetRoleName
        {
            set
            {
                this.ucRole.SelectedFullName = value;
            }
            get
            {
                return this.ucRole.SelectedFullName;
            }
        }

        public string OldEntityId = string.Empty;       // 原先被选中的节点主键
        private string currentEntityId = string.Empty;

        private bool isUserClick = true;    // 是否是用户点击了复选框

        /// <summary>
        /// 当前选中的节点，树上
        /// </summary>
        public string CurrentEntityId
        {
            get
            {
                if ((this.tvPermission.SelectedNode != null) && (this.tvPermission.SelectedNode.Tag != null))
                {
                    this.currentEntityId = (this.tvPermission.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                }
                return this.currentEntityId;
            }
            set
            {
                this.currentEntityId = value;
            }
        }
        
        public FrmRolePermissionItemScope()
        {
            InitializeComponent();
        }

        public FrmRolePermissionItemScope(string currentId) : this()
        {
            this.CurrentEntityId    = currentId;
            this.OldEntityId        = currentId;
        }

        public FrmRolePermissionItemScope(string roleId, string roleName) : this()
        {
            this.TargetRoleId = roleId;
            this.TargetRoleName = roleName;
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // 设置用户控件状态
            this.ucRole.AllowNull = false;
            this.ucRole.ShowRoleOnly = true;
            this.ucRole.PermissionItemScopeCode = this.PermissionItemScopeCode;
            // 是简化的角色管理
            this.ucRole.SimpleAdmin = true;
            if (String.IsNullOrEmpty(this.TargetRoleId) || this.DTPermissionItem.Rows.Count == 0)
            {
                this.btnBatchSave.Enabled = false;
                this.btnSelectAll.Enabled = false;
                this.btnInvertSelect.Enabled = false;
            }
            else
            {
                this.btnBatchSave.Enabled = this.permissionEdit;
                this.btnSelectAll.Enabled = this.permissionEdit;
                this.btnInvertSelect.Enabled = this.permissionEdit;
            }
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAccess = this.IsAuthorized("UserAdmin.Accredit");   // 访问权限
            this.permissionEdit = this.IsAuthorized("UserAdmin.Accredit");       // 编辑权限  
        }
        #endregion

        #region private void BindData(bool reloadTree) 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        /// <param name="reloadTree">重新加部门载树</param>
        private void BindData(bool reloadTree)
        {
            this.ucRole.SelectedId = this.TargetRoleId;
            this.ucRole.SelectedFullName = this.TargetRoleName;
            // 加载树
            if (reloadTree)
            {
                this.LoadTree();
            }
            if (this.tvPermission.SelectedNode == null)
            {
                if (this.tvPermission.Nodes.Count > 0)
                {
                    if (this.CurrentEntityId.Length == 0)
                    {
                        this.tvPermission.SelectedNode = this.tvPermission.Nodes[0];
                    }
                    else
                    {
                        BaseInterfaceLogic.FindTreeNode(this.tvPermission, this.CurrentEntityId);
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
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 获得指定权限表格
            this.DTPermissionItem = this.GetPermissionItemScop(this.PermissionItemScopeCode);
            // 这里需要只把有效的模块显示出来
            BaseBusinessLogic.SetFilter(this.DTPermissionItem, BasePermissionItemEntity.FieldEnabled, "1");
            // 未被打上删除标标志的
            // BaseBusinessLogic.SetFilter(this.DTPermissionItem, BasePermissionItemEntity.FieldDeletionStateCode, "0");

            this.DTPermissionItem.DefaultView.Sort = BasePermissionItemEntity.FieldSortCode;
            this.PermissionIds = DotNetService.Instance.PermissionService.GetRoleScopePermissionItemIds(UserInfo, this.TargetRoleId, this.PermissionItemScopeCode);
            // 设置鼠标默认状态，原来的光标状态
            this.BindData(true);
        }
        #endregion

        private void ucRole_SelectedIndexChanged(string parentId)
        {
            this.FormOnLoad();
        }

        #region private void LoadTree() 加载权限树的主键
        /// <summary>
        /// 加载权限树的主键
        /// </summary>
        private void LoadTree()
        {
            this.isUserClick = false;
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvPermission.BeginUpdate();
            this.tvPermission.Nodes.Clear();
            TreeNode treeNode = new TreeNode();
            this.LoadTree(treeNode);
            this.tvPermission.EndUpdate();
            this.isUserClick = true;
        }
        #endregion

        #region private void LoadTree(TreeNode treeNode)
        /// <summary>
        /// 加载权限构树的主键
        /// </summary>
        /// <param name="TreeNode">当前节点</param>
        private void LoadTree(TreeNode treeNode)
        {
            DataRow[] dataRows = null;
            if (treeNode.Tag == null)
            {
                dataRows = this.DTPermissionItem.Select(BasePermissionItemEntity.FieldParentId + " IS NULL OR " + BasePermissionItemEntity.FieldParentId + " = 0 ", BasePermissionItemEntity.FieldSortCode);
            }
            else
            {
                dataRows = this.DTPermissionItem.Select(BasePermissionItemEntity.FieldParentId + "=" + (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString() + "", BasePermissionItemEntity.FieldSortCode);
            }
            foreach (DataRow dataRow in dataRows)
            {
                // 判断不为空的当前节点的子节点
                if ((treeNode.Tag != null) && ((treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString().Length > 0) && (!(treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString().Equals(dataRow[BasePermissionItemEntity.FieldParentId].ToString())))
                {
                    continue;
                }
                // 当前节点的子节点, 加载根节点
                if ((dataRow.IsNull(BasePermissionItemEntity.FieldParentId) || (dataRow[BasePermissionItemEntity.FieldParentId].ToString().Length == 0) || ((treeNode.Tag != null) && (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString().Equals(dataRow[BasePermissionItemEntity.FieldParentId].ToString()))))
                {
                    TreeNode newTreeNode = new TreeNode();
                    newTreeNode.Text = dataRow[BasePermissionItemEntity.FieldFullName].ToString();
                    newTreeNode.Tag = dataRow[BasePermissionItemEntity.FieldId].ToString();
                    // 是否已经有这个权限
                    newTreeNode.Checked = Array.IndexOf(this.PermissionIds, dataRow[BasePermissionItemEntity.FieldId].ToString()) >= 0;
                    if ((treeNode.Tag == null) || ((treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString().Length == 0))
                    {
                        // 树的根节点加载
                        this.tvPermission.Nodes.Add(newTreeNode);
                    }
                    else
                    {
                        // 节点的子节点加载
                        treeNode.Nodes.Add(newTreeNode);
                    }
                    // 递归调用本函数
                    this.LoadTree(newTreeNode);
                }
            }
        }
        #endregion

        private void tvPermission_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (this.isUserClick)
            {
                if (!this.permissionEdit)
                {
                    e.Cancel = true;
                }
            }
        }

        private void tvPermission_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (this.isUserClick)
            {
                for (int i = 0; i < e.Node.Nodes.Count; i++)
                {
                    e.Node.Nodes[i].Checked = e.Node.Checked;
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

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            this.isUserClick = false;
            for (int i = 0; i < this.tvPermission.Nodes.Count; i++)
            {
                this.SetTreeNodesSelected(this.tvPermission.Nodes[i], true);
            }
            this.isUserClick = true;
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            this.isUserClick = false;
            for (int i = 0; i < this.tvPermission.Nodes.Count; i++)
            {
                this.SetTreeNodesTurnSelected(this.tvPermission.Nodes[i]);
            }
            this.isUserClick = true;
        }

        /// <summary>
        /// 授权的权限
        /// </summary>
        string GrantPermissions = string.Empty;

        /// <summary>
        /// 撤销的权限
        /// </summary>
        string RevokePermissions = string.Empty;

        private void EntityToArray(TreeNode treeNode)
        {
            if (treeNode.Tag != null)
            {
                // 提高运行速度
                string permissionItemId = (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                if (treeNode.Checked)
                {
                    // 这里是授权的权限
                    if (Array.IndexOf(this.PermissionIds, permissionItemId) < 0)
                    {
                        this.GrantPermissions += permissionItemId + ";";
                    }
                }
                else
                {
                    // 这里是撤销的权限
                    if (Array.IndexOf(this.PermissionIds, permissionItemId) >= 0)
                    {
                        this.RevokePermissions += permissionItemId + ";";
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

        private void CheckParentChecked()
        {
            this.isUserClick = false;
            for (int i = 0; i < this.tvPermission.Nodes.Count; i++)
            {
                TreeNode treeNode = this.tvPermission.Nodes[i];
                this.CheckParentChecked(treeNode);
            }
            this.isUserClick = true;
        }

        #region private bool BatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private bool BatchSave()
        {
            bool returnValue = true;
            for (int i = 0; i < this.tvPermission.Nodes.Count; i++)
            {
                this.EntityToArray(this.tvPermission.Nodes[i]);
            }
            string[] grantPermissionIds = null;
            string[] revokePermissionIds = null;
            if (this.GrantPermissions.Length > 2)
            {
                this.GrantPermissions = this.GrantPermissions.Substring(0, this.GrantPermissions.Length - 1);
                grantPermissionIds = this.GrantPermissions.Split(';');
            }
            if (this.RevokePermissions.Length > 1)
            {
                this.RevokePermissions = this.RevokePermissions.Substring(0, this.RevokePermissions.Length - 1);
                revokePermissionIds = this.RevokePermissions.Split(';');
            }
            this.GrantPermissions = string.Empty;
            this.RevokePermissions = string.Empty;
            DotNetService.Instance.PermissionService.GrantRolePermissions(UserInfo, new string[] { this.TargetRoleId }, grantPermissionIds);
            DotNetService.Instance.PermissionService.RevokeRolePermissions(UserInfo, new string[] { this.TargetRoleId }, revokePermissionIds);
            if (BaseSystemInfo.ShowInformation)
            {
                // 更新成功，进行提示
                MessageBox.Show(AppMessage.MSG0012, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return returnValue;
        }
        #endregion

        private void btnBatchSave_Click(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                // 批量保存
                // this.CheckParentChecked();
                if (this.BatchSave())
                {
                    // 关闭窗口
                    this.FormOnLoad();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tvPermission_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvPermission.GetNodeAt(e.X, e.Y) != null)
            {
                tvPermission.SelectedNode = tvPermission.GetNodeAt(e.X, e.Y);
            }
        }
    }
}