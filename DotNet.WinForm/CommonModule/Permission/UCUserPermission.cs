//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    
    using DotNet.Utilities;
    using DotNet.Business;
    

    /// <summary>
    /// UCUserPermission.cs
    /// 用户权限管理控件
    ///		
    /// 修改记录
    ///
    ///     2008.06.27 版本：1.0 JiRiGaLa 员工－权限管理。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.06.27</date>
    /// </author> 
    /// </summary> 
    public partial class UCUserPermission : UserControl
    {
        /// <summary>
        /// 权限域（范围权限、数据权限）
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        public bool permissionEdit = true;

        /// <summary>
        /// 操作权限项数据
        /// </summary>
        public DataTable DTPermission = new DataTable(BaseParameterEntity.TableName);

        private string[] permissionItemIds = null;

        // 目标用户主键
        private string targetUserId = string.Empty;
        public string TargetUserId
        {
            set
            {
                this.targetUserId = value;
            }
            get
            {
                return this.targetUserId;
            }
        }

        private BaseUserInfo userInfo = new BaseUserInfo();
        /// <summary>
        /// 当前用户信息
        /// </summary>
        public BaseUserInfo UserInfo
        {
            get
            {
                return userInfo;
            }
            set
            {
                userInfo = value;
            }
        }

        public string OldEntityId = string.Empty;       // 原先被选中的节点主键
        private string currentEntityId = string.Empty;

        /// <summary>
        /// 获取用户权限域数据
        /// </summary>
        public DataTable GetUserScope(string permissionItemScopeCode)
        {
            // 获取部门数据
            if ((UserInfo.IsAdministrator) || (String.IsNullOrEmpty(permissionItemScopeCode)))
            {
                return DotNetService.Instance.UserService.GetDataTable(UserInfo);
            }
            else
            {
                return DotNetService.Instance.PermissionService.GetUserDTByPermissionScope(UserInfo, UserInfo.Id, permissionItemScopeCode);
            }
        }

        public UCUserPermission()
        {
            InitializeComponent();
        }

        #region public void UserControlOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public void UserControlOnLoad()
        {
            // 获得指定权限表格
            this.DTPermission = this.GetUserScope(this.PermissionItemScopeCode);
            this.DTPermission.DefaultView.Sort = BasePermissionItemEntity.FieldSortCode;
            // 获得用户的权限主键数组
            this.permissionItemIds = DotNetService.Instance.PermissionService.GetUserPermissionItemIds(UserInfo, this.TargetUserId);
            // 设置鼠标默认状态，原来的光标状态
            this.BindData(true);
        }
        #endregion

        private bool isUserClick = true;    // 是否是用户点击了复选框

        /// <summary>
        /// 当前选中的节点，树上
        /// </summary>
        public string CurrentEntityId
        {
            get
            {
                if ((this.tvUserPermission.SelectedNode != null) && (this.tvUserPermission.SelectedNode.Tag != null))
                {
                    this.currentEntityId = ((BasePermissionItemEntity)this.tvUserPermission.SelectedNode.Tag).Id.ToString();
                }
                return this.currentEntityId;
            }
            set
            {
                this.currentEntityId = value;
            }
        }

        #region private void LoadTree() 加载权限树的主键
        /// <summary>
        /// 加载权限树的主键
        /// </summary>
        private void LoadTree()
        {
            this.isUserClick = false;
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvUserPermission.BeginUpdate();
            this.tvUserPermission.Nodes.Clear();
            TreeNode treeNode = new TreeNode();
            this.LoadTree(treeNode);
            this.tvUserPermission.EndUpdate();
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
                dataRows = this.DTPermission.Select(BasePermissionItemEntity.FieldParentId + " IS NULL OR " + BasePermissionItemEntity.FieldParentId + " = 0", BasePermissionItemEntity.FieldSortCode);
            }
            else
            {
                dataRows = this.DTPermission.Select(BasePermissionItemEntity.FieldParentId + "=" + ((BasePermissionItemEntity)treeNode.Tag).Id.ToString(), BasePermissionItemEntity.FieldSortCode);
            }
            foreach (DataRow dataRow in dataRows)
            {
                BasePermissionItemEntity permissionItemEntity = new BasePermissionItemEntity(dataRow);
                // 判断不为空的当前节点的子节点
                if ((treeNode.Tag != null) && ((treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString().Length > 0) && (((BasePermissionItemEntity)treeNode.Tag).Id.ToString() != permissionItemEntity.ParentId))
                {
                    continue;
                }
                // 当前节点的子节点, 加载根节点
                if ((treeNode.Tag == null) || ((BasePermissionItemEntity)treeNode.Tag).Id.Equals(permissionItemEntity.ParentId))
                {
                    TreeNode newTreeNode = new TreeNode();
                    newTreeNode.Text = permissionItemEntity.FullName;
                    newTreeNode.Tag = permissionItemEntity;
                    // 是否已经有这个权限
                    newTreeNode.Checked = Array.IndexOf(this.permissionItemIds, permissionItemEntity.Id.ToString()) >= 0;
                    if ((treeNode.Tag == null) || ((treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString().Length == 0))
                    {
                        // 树的根节点加载
                        this.tvUserPermission.Nodes.Add(newTreeNode);
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
                this.LoadTree();
            }
            if (this.tvUserPermission.SelectedNode == null)
            {
                if (this.tvUserPermission.Nodes.Count > 0)
                {
                    this.tvUserPermission.SelectedNode = this.tvUserPermission.Nodes[0];
                    /*
                    if (this.CurrentEntityID.Length == 0)
                    {
                        
                    }
                    else
                    {
                        BaseInterfaceLogic.FindTreeNode(this.tvUserPermission, this.CurrentEntityId);
                        if (BaseInterfaceLogic.TargetNode != null)
                        {
                            this.tvUserPermission.SelectedNode = BaseInterfaceLogic.TargetNode;
                            // 展开当前选中节点的所有父节点
                            BaseInterfaceLogic.ExpandTreeNode(this.tvUserPermission);
                        }
                    }
                    */
                    for (int i = 0; i < this.tvUserPermission.Nodes.Count; i++)
                    {
                        this.tvUserPermission.Nodes[i].Expand();
                    }
                    if (this.tvUserPermission.SelectedNode != null)
                    {
                        // 让选中的节点可视，并用展开方式
                        this.tvUserPermission.SelectedNode.Expand();
                        this.tvUserPermission.SelectedNode.EnsureVisible();
                    }
                }
            }
        }
        #endregion

        private void tvStaffPermission_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.isUserClick)
            {
                if (this.SelectedIndexChanged != null)
                {
                    if ((this.tvUserPermission.SelectedNode != null) && (this.tvUserPermission.SelectedNode.Tag != null))
                    {
                        this.SelectedIndexChanged((BasePermissionItemEntity)this.tvUserPermission.SelectedNode.Tag, this.tvUserPermission.SelectedNode.Checked);
                    }
                }
            }
        }

        private void tvStaffPermission_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (this.isUserClick)
            {
                if (!this.permissionEdit)
                {
                    e.Cancel = true;
                }
            }
        }

        public delegate void SelectedIndexChangedEventHandler(BasePermissionItemEntity permissionItemEntity, bool nodeChecked);
        // 当选择节点发生变化时
        public event SelectedIndexChangedEventHandler SelectedIndexChanged;

        private void tvStaffPermission_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (this.isUserClick)
            {
                if (this.tvUserPermission.SelectedNode != null)
                {
                    if (this.SelectedIndexChanged != null)
                    {
                        this.SelectedIndexChanged((BasePermissionItemEntity)this.tvUserPermission.SelectedNode.Tag, this.tvUserPermission.SelectedNode.Checked);
                    }
                }
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
        /// <param name="treeNode">树节点</param>
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

        public void SelectAll()
        {
            this.isUserClick = false;
            for (int i = 0; i < this.tvUserPermission.Nodes.Count; i++)
            {
                this.SetTreeNodesSelected(this.tvUserPermission.Nodes[i], true);
            }
            this.isUserClick = true;
        }

        public void InvertSelect()
        {
            this.isUserClick = false;
            for (int i = 0; i < this.tvUserPermission.Nodes.Count; i++)
            {
                this.SetTreeNodesTurnSelected(this.tvUserPermission.Nodes[i]);
            }
            this.isUserClick = true;
        }

        /// <summary>
        /// 授权的权限
        /// </summary>
        private string GrantPermissions = string.Empty;

        /// <summary>
        /// 撤销的权限
        /// </summary>
        private string RevokePermissions = string.Empty;

        private void EntityToArray(TreeNode treeNode)
        {
            if (treeNode.Tag != null)
            {
                // 提高运行速度
                string permissionItemId = ((BasePermissionItemEntity)treeNode.Tag).Id.ToString();
                if (treeNode.Checked)
                {
                    // 这里是授权的权限
                    if (Array.IndexOf(this.permissionItemIds, permissionItemId) < 0)
                    {
                        this.GrantPermissions += permissionItemId + ";";
                    }
                }
                else
                {
                    // 这里是撤销的权限
                    if (Array.IndexOf(this.permissionItemIds, permissionItemId) >= 0)
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

        public void CheckParentChecked()
        {
            this.isUserClick = false;
            for (int i = 0; i < this.tvUserPermission.Nodes.Count; i++)
            {
                TreeNode treeNode = this.tvUserPermission.Nodes[i];
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
            for (int i = 0; i < this.tvUserPermission.Nodes.Count; i++)
            {
                this.EntityToArray(this.tvUserPermission.Nodes[i]);
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
            DotNetService.Instance.PermissionService.GrantUserPermissions(UserInfo, new string[] { this.TargetUserId }, grantPermissionIds);
            DotNetService.Instance.PermissionService.RevokeUserPermissions(UserInfo, new string[]{ this.TargetUserId }, revokePermissionIds);
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
                this.UserControlOnLoad();
            }
        }

        private void tvUserPermission_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvUserPermission.GetNodeAt(e.X, e.Y) != null)
            {
                tvUserPermission.SelectedNode = tvUserPermission.GetNodeAt(e.X, e.Y);
            }
        }
    }
}
