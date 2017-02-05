//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DotNet.WinForm
{
    
    using DotNet.Business;
    using DotNet.Utilities;
    

    /// <summary>
    /// FrmRolePermission2.cs
    /// 权限设置-角色权限批量设置
    ///		
    /// 修改记录
    /// 
    ///     2010.12.24 版本：1.0 JiRiGaLa  角色权限批量设置。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.12.24</date>
    /// </author> 
    /// </summary>
    public partial class FrmRolePermission2 : BaseForm
    {
        /// <summary>
        /// 权限域（范围权限、数据权限）
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        /// <summary>
        /// 用户管理
        /// </summary>
        private DataTable DTUser = new DataTable(BaseUserEntity.TableName);

        /// <summary>
        /// 模块 DataTable
        /// </summary>
        private DataTable DTModule = new DataTable(BaseModuleEntity.TableName);

        private string[] ModuleIds = null;

        /// <summary>
        /// 操作权限项数据
        /// </summary>
        public DataTable DTPermissionItem = new DataTable(BasePermissionItemEntity.TableName);

        private string[] PermissionItemIds = null;

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
        /// <summary>
        /// 是否是用户点击了复选框
        /// </summary>
        private bool isUserClick = true;

        public FrmRolePermission2()
        {
            InitializeComponent();
        }

        public FrmRolePermission2(string roleId)
            : this()
        {
            this.TargetRoleId = roleId;
        }

        public FrmRolePermission2(string roleId, string roleName)
            : this()
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
            // 这里判断是否有数据被复制
            object clipboardData = Clipboard.GetData("rolePermission");
            this.btnPaste.Enabled = (clipboardData != null);
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.isUserClick = false;

            // 获得用户列表
            this.GetUserList();

            this.DTPermissionItem = this.GetPermissionItemScop(this.PermissionItemScopeCode);

            this.DTModule = this.GetModuleScope(this.PermissionItemScopeCode);

            this.LoadTree();

            this.GetCurrentPermission();

            this.isUserClick = true;
        }
        #endregion

        #region private void GetUserList() 获取用户列表
        /// <summary>
        /// 获取用户列表
        /// </summary>
        private void GetUserList()
        {
            // 是否启用了权限范围管理
            this.DTUser = this.GetUserScope(this.PermissionItemScopeCode);
            this.DTUser.DefaultView.Sort = BaseUserEntity.FieldSortCode;
            this.cklstUser.DataSource = this.DTUser.DefaultView;
            this.cklstUser.ValueMember = BaseUserEntity.FieldId;
            this.cklstUser.DisplayMember = BaseUserEntity.FieldRealName;
        }
        #endregion

        #region private void LoadTree() 加载树的主键
        /// <summary>
        /// 加载树的主键
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvPermissionItem.BeginUpdate();
            this.tvPermissionItem.Nodes.Clear();
            this.LoadTreePermissionItem();
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvPermissionItem.EndUpdate();

            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvModule.BeginUpdate();
            this.tvModule.Nodes.Clear();
            this.LoadTreeModule();
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvModule.EndUpdate();
        }
        #endregion

        private void LoadTreeModule()
        {
            TreeNode treeNode = new TreeNode();
            this.LoadTreeModule(treeNode);
        }

        #region private void LoadTreeModule(TreeNode treeNode) 加载组织机构树的主键
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeModule(TreeNode treeNode)
        {
            BaseInterfaceLogic.LoadTreeNodes(this.DTModule, BaseModuleEntity.FieldId, BaseModuleEntity.FieldParentId, BaseModuleEntity.FieldFullName, this.tvModule, treeNode);
        }
        #endregion

        private void LoadTreePermissionItem()
        {
            TreeNode treeNode = new TreeNode();
            this.LoadTreePermissionItem(treeNode);
        }

        #region private void LoadTreePermissionItem(TreeNode treeNode) 加载组织机构树的主键
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreePermissionItem(TreeNode treeNode)
        {
            BaseInterfaceLogic.LoadTreeNodes(this.DTPermissionItem, BasePermissionItemEntity.FieldId, BasePermissionItemEntity.FieldParentId, BasePermissionItemEntity.FieldFullName, this.tvPermissionItem, treeNode);
        }
        #endregion

        private void GetCurrentPermission()
        {
            this.isUserClick = false;

            // 这些控件可以用了
            this.cklstUser.Enabled = true;
            this.tvModule.Enabled = true;
            this.tvPermissionItem.Enabled = true;

            // 当前选中的角色被改变
            // 初始化权限设置页面
            this.ClearCheck();
            // 获取角色的权限
            this.GetRolePermission();

            this.isUserClick = true;

            this.btnClearPermission.Enabled = true;
            this.btnCopy.Enabled = true;
        }

        /// <summary>
        /// 获取角色的权限
        /// </summary>
        private void GetRolePermission()
        {
            // 获取当权角色中的用户列表
            this.GetRoleUsers();
            // 获取模块访问权限
            this.ModuleIds = DotNetService.Instance.PermissionService.GetRoleScopeModuleIds(UserInfo, this.TargetRoleId, "Resource.AccessPermission");
            if (this.ModuleIds != null && this.ModuleIds.Length > 0)
            {
                this.tvModule.BeginUpdate();
                this.ModuleCheck();
                this.tvModule.EndUpdate();
            }
            // 获得角色的权限主键数组
            this.PermissionItemIds = DotNetService.Instance.PermissionService.GetRolePermissionItemIds(UserInfo, this.TargetRoleId);
            if (this.PermissionItemIds != null && this.PermissionItemIds.Length > 0)
            {
                this.tvPermissionItem.BeginUpdate();
                this.PermissionItemCheck();
                this.tvPermissionItem.EndUpdate();
            }
        }

        /// <summary>
        /// 获取当权角色中的用户列表
        /// </summary>
        private void GetRoleUsers()
        {
            // 获取当前角色中的用户
            string[] userIds = DotNetService.Instance.RoleService.GetRoleUserIds(this.UserInfo, this.TargetRoleId);
            // 把当前的用户设置为选中状态
            for (int i = 0; i < this.cklstUser.Items.Count; i++)
            {
                string userId = ((System.Data.DataRowView)this.cklstUser.Items[i])[BaseUserEntity.FieldId].ToString();
                if (Array.IndexOf(userIds, userId) >= 0)
                {
                    this.cklstUser.SetItemChecked(i, true);
                }
            }
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
            // 用户被选中状态取消
            for (int i = -0; i < this.cklstUser.Items.Count; i++)
            {
                this.cklstUser.SetItemChecked(i, false);
            }
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

        private void PermissionItemCheck()
        {
            // 递归调用到所有的子节点 
            for (int i = 0; i < this.tvPermissionItem.Nodes.Count; i++)
            {
                this.PermissionItemCheck(this.tvPermissionItem.Nodes[i]);
            }
        }

        private void PermissionItemCheck(TreeNode treeNode)
        {
            if ((treeNode!= null && treeNode.Tag != null && (treeNode.Tag as DataRow) != null))
            {
                string permissionItemId = (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                treeNode.Checked = Array.IndexOf(this.PermissionItemIds, permissionItemId) >= 0;
                for (int i = 0; i < treeNode.Nodes.Count; i++)
                {
                    // 这里进行递规操作
                    this.PermissionItemCheck(treeNode.Nodes[i]);
                }
            }
        }

        private void cklstUser_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (this.isUserClick)
            {
                bool itemChecked = this.cklstUser.GetItemChecked(this.cklstUser.SelectedIndex);
                string userId = ((System.Data.DataRowView)this.cklstUser.SelectedItem)[BaseUserEntity.FieldId].ToString();
                if (itemChecked)
                {
                    // 被撤销了
                    DotNetService.Instance.RoleService.RemoveUserFromRole(this.UserInfo, this.TargetRoleId, new string[] { userId });
                }
                else
                {
                    DotNetService.Instance.RoleService.AddUserToRole(this.UserInfo, this.TargetRoleId, new string[] { userId });
                }
            }
        }

        private void tvModule_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (this.isUserClick)
            {
                if (e.Node.Checked)
                {
                    // 授予操作权限
                    DotNetService.Instance.PermissionService.GrantRoleModuleScope(this.UserInfo, this.TargetRoleId, "Resource.AccessPermission", (e.Node.Tag as DataRow)[BaseModuleEntity.FieldId].ToString());
                }
                else
                {
                    // 撤销操作权限
                    DotNetService.Instance.PermissionService.RevokeRoleModuleScope(this.UserInfo, this.TargetRoleId, "Resource.AccessPermission", (e.Node.Tag as DataRow)[BaseModuleEntity.FieldId].ToString());
                }
                for (int i = 0; i < e.Node.Nodes.Count; i++)
                {
                    e.Node.Nodes[i].Checked = e.Node.Checked;
                }
            }
        }

        private void tvPermissionItem_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (this.isUserClick)
            {
                if (e.Node.Checked)
                {
                    // 授予操作权限
                    DotNetService.Instance.PermissionService.GrantRolePermissionById(this.UserInfo, this.TargetRoleId, (e.Node.Tag as DataRow)[BaseModuleEntity.FieldId].ToString());
                }
                else
                {
                    // 撤销操作权限
                    DotNetService.Instance.PermissionService.RevokeRolePermissionById(this.UserInfo, this.TargetRoleId, (e.Node.Tag as DataRow)[BaseModuleEntity.FieldId].ToString());
                }
                for (int i = 0; i < e.Node.Nodes.Count; i++)
                {
                    e.Node.Nodes[i].Checked = e.Node.Checked;
                }
            }
        }

        private void tvModule_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvModule.GetNodeAt(e.X, e.Y) != null)
            {
                tvModule.SelectedNode = tvModule.GetNodeAt(e.X, e.Y);
            }
        }

        private void tvPermissionItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvPermissionItem.GetNodeAt(e.X, e.Y) != null)
            {
                tvPermissionItem.SelectedNode = tvPermissionItem.GetNodeAt(e.X, e.Y);
            }
        }

        private void btnClearPermission_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(AppMessage.MSG0600, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                // 清除角色权限
                DotNetService.Instance.PermissionService.ClearRolePermission(this.UserInfo, this.TargetRoleId);
                this.GetCurrentPermission();
            }
        }

        [Serializable]
        private class RolePermission
        {
            public List<BaseUserEntity> UserEntites = null;
            public string[] GrantModuleIds = null;
            public string[] GrantPermissionIds = null;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            RolePermission rolePermission = new RolePermission();
            // 读取角色数据
            List<BaseUserEntity> userEntites = new List<BaseUserEntity>();
            for (int i = 0; i < this.cklstUser.CheckedItems.Count; i++)
            {
                BaseUserEntity userEntity = new BaseUserEntity(((System.Data.DataRowView)this.cklstUser.CheckedItems[i]).Row);
                userEntites.Add(userEntity);
            }
            // 角色复制到剪切板
            rolePermission.UserEntites = userEntites;
            // 模块访问权限复制到剪切板
            string[] grantModuleIds = this.GetGrantModuleIds();
            rolePermission.GrantModuleIds = grantModuleIds;
            // 操作权限复制到剪切板
            string[] grantPermissionIds = this.GetGrantPermissionIds();
            rolePermission.GrantPermissionIds = grantPermissionIds;

            Clipboard.SetData("rolePermission", rolePermission);
            this.btnPaste.Enabled = true;
        }

        /// <summary>
        /// 授权的模块访问权限
        /// </summary>
        private string GrantModules = string.Empty;

        private void ModuleEntityToArray(TreeNode treeNode)
        {
            if (treeNode.Tag != null)
            {
                // 提高运行速度
                string moduleId = (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                if (treeNode.Checked)
                {
                    this.GrantModules += moduleId + ";";
                }
            }
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.ModuleEntityToArray(treeNode.Nodes[i]);
            }
        }

        #region private string[] GetGrantModuleIds() 批量获取模块访问权限选中状态
        /// <summary>
        /// 批量获取模块访问权限选中状态
        /// </summary>
        private string[] GetGrantModuleIds()
        {
            for (int i = 0; i < this.tvModule.Nodes.Count; i++)
            {
                this.ModuleEntityToArray(this.tvModule.Nodes[i]);
            }
            string[] grantModuleIds = null;
            if (this.GrantModules.Length > 2)
            {
                this.GrantModules = this.GrantModules.Substring(0, this.GrantModules.Length - 1);
                grantModuleIds = this.GrantModules.Split(';');
            }
            this.GrantModules = string.Empty;
            return grantModuleIds;
        }
        #endregion

        /// <summary>
        /// 授权的操作权限
        /// </summary>
        private string GrantPermissions = string.Empty;

        private void PermissionEntityToArray(TreeNode treeNode)
        {
            if (treeNode.Tag != null)
            {
                // 提高运行速度
                string permissionItemId = (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                if (treeNode.Checked)
                {
                    this.GrantPermissions += permissionItemId + ";";
                }
            }
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.PermissionEntityToArray(treeNode.Nodes[i]);
            }
        }

        #region private string[] GetGrantPermissionIds() 批量获取操作权限选中状态
        /// <summary>
        /// 批量获取操作权限选中状态
        /// </summary>
        private string[] GetGrantPermissionIds()
        {
            for (int i = 0; i < this.tvPermissionItem.Nodes.Count; i++)
            {
                this.PermissionEntityToArray(this.tvPermissionItem.Nodes[i]);
            }
            string[] grantPermissionIds = null;
            if (this.GrantPermissions.Length > 2)
            {
                this.GrantPermissions = this.GrantPermissions.Substring(0, this.GrantPermissions.Length - 1);
                grantPermissionIds = this.GrantPermissions.Split(';');
            }
            this.GrantPermissions = string.Empty;
            return grantPermissionIds;
        }
        #endregion

        private void btnPaste_Click(object sender, EventArgs e)
        {
            object clipboardData = Clipboard.GetData("rolePermission");
            if (clipboardData != null)
            {
                RolePermission rolePermission = (RolePermission)clipboardData;

                List<BaseUserEntity> userEntites = rolePermission.UserEntites;
                string[] addUserIds = new string[userEntites.Count];
                for (int i = 0; i < userEntites.Count; i++)
                {
                    addUserIds[i] = userEntites[i].Id.ToString();
                }
                // 添加用户到角色
                DotNetService.Instance.RoleService.AddUserToRole(this.UserInfo, this.TargetRoleId, addUserIds);

                string[] grantModuleIds = rolePermission.GrantModuleIds;
                DotNetService.Instance.PermissionService.GrantRoleModuleScopes(UserInfo, this.TargetRoleId, "Resource.AccessPermission", grantModuleIds);

                string[] grantPermissionIds = rolePermission.GrantPermissionIds;
                DotNetService.Instance.PermissionService.GrantRolePermissions(UserInfo, new string[] { this.TargetRoleId }, grantPermissionIds);

                this.GetCurrentPermission();
            }
        }
    }
}