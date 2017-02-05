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
    /// FrmUserPermissionBatchSet.cs
    /// 权限设置-用户权限批量设置
    ///		
    /// 修改记录
    ///     2011.07.23 版本：1.2 张广梁    修改tvModule  tvPermissionItem节点选择时的逻辑错误
    ///     2011.07.07 版本：1.1 zgl       优化批量设置模块权限和菜单权限
    ///     2010.12.28 版本：1.0 JiRiGaLa  角色权限批量设置。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.12.28</date>
    /// </author> 
    /// </summary>
    public partial class FrmUserPermissionBatchSet : BaseForm
    {
        /// <summary>
        /// 权限域（范围权限、数据权限）
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable DTRole = new DataTable(BaseRoleEntity.TableName);

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

        /// <summary>
        /// 目标角色主键
        /// </summary>
        public string TargetUserId
        {
            get
            {
                string userId = string.Empty;
                if (this.lstUser.SelectedItem != null)
                {
                    userId = this.lstUser.SelectedValue.ToString();
                }
                return userId;
            }
        }

        /// <summary>
        /// 是否是用户点击了复选框
        /// </summary>
        private bool isUserClick = true;

        public FrmUserPermissionBatchSet()
        {
            InitializeComponent();
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // 这里判断是否有数据被复制
            object clipboardData = Clipboard.GetData("userPermission");
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

            // 获得角色列表
            this.GetRoleList();

            this.DTPermissionItem = this.GetPermissionItemScop(this.PermissionItemScopeCode);
            // 这里需要只把有效的模块显示出来
            BaseBusinessLogic.SetFilter(this.DTPermissionItem, BasePermissionItemEntity.FieldEnabled, "1");
            // 未被打上删除标标志的
            // BaseBusinessLogic.SetFilter(this.DTPermissionItem, BasePermissionItemEntity.FieldDeletionStateCode, "0");

            this.DTModule = this.GetModuleScope(this.PermissionItemScopeCode);
            // 这里需要只把有效的模块显示出来
            BaseBusinessLogic.SetFilter(this.DTModule, BaseModuleEntity.FieldEnabled, "1");
            // 未被打上删除标标志的
            // BaseBusinessLogic.SetFilter(this.DTModule, BaseModuleEntity.FieldDeletionStateCode, "0");

            this.LoadTree();

            // 获得用户列表
            this.GetUserList();

            // 获取用户的权限
            // this.GetUserPermission();

            this.isUserClick = true;
        }
        #endregion

        #region private void GetRoleList() 获取角色列表
        /// <summary>
        /// 获取角色列表
        /// </summary>
        private void GetRoleList()
        {
            // 是否启用了权限范围管理
            this.DTRole = this.GetRoleScope(this.PermissionItemScopeCode);
            this.DTRole.DefaultView.Sort = BaseRoleEntity.FieldSortCode;
            this.cklstRole.DataSource = this.DTRole.DefaultView;
            this.cklstRole.ValueMember = BaseRoleEntity.FieldId;
            this.cklstRole.DisplayMember = BaseRoleEntity.FieldRealName;
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
            // 超级管理员不用显示
            BaseBusinessLogic.SetFilter(this.DTUser, BaseUserEntity.FieldCode, DefaultRole.Administrator.ToString(), true);
            foreach (DataRow dataRow in this.DTUser.Rows)
            {
                dataRow[BaseUserEntity.FieldRealName] = dataRow[BaseUserEntity.FieldUserName] + " [" + dataRow[BaseUserEntity.FieldRealName] + "]";
            }
            this.DTUser.DefaultView.Sort = BaseUserEntity.FieldSortCode;
            this.lstUser.ValueMember = BaseUserEntity.FieldId;
            this.lstUser.DisplayMember = BaseUserEntity.FieldRealName;
            this.lstUser.DataSource = this.DTUser.DefaultView;
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

            // 当前选中的角色被改变
            // 初始化权限设置页面
            this.ClearCheck();
            // 获取用户的权限
            this.GetUserPermission();
            this.isUserClick = true;

            this.btnClearPermission.Enabled = true;
            this.btnCopy.Enabled = true;

            // 这些空间可以用了
            this.cklstRole.Enabled = true;
            this.tvModule.Enabled = true;
            this.tvPermissionItem.Enabled = true;
        }

        private void lstUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.GetCurrentPermission();
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

        /// <summary>
        /// 获取角色的权限
        /// </summary>
        private void GetUserPermission()
        {
            // 获取当权用户中的角色列表
            this.GetRoleUsers();
            // 获取用户的模块访问权限
            this.ModuleIds = DotNetService.Instance.PermissionService.GetUserScopeModuleIds(UserInfo, this.TargetUserId, "Resource.AccessPermission");
            if (this.ModuleIds != null && this.ModuleIds.Length > 0)
            {
                this.tvModule.BeginUpdate();
                this.ModuleCheck();
                this.tvModule.EndUpdate();
            }
            // 获得用户的权限主键数组
            this.PermissionItemIds = DotNetService.Instance.PermissionService.GetUserPermissionItemIds(UserInfo, this.TargetUserId);
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
            string[] roleIds = DotNetService.Instance.UserService.GetUserRoleIds(this.UserInfo, this.TargetUserId);
            // 把当前的用户设置为选中状态
            for (int i = 0; i < this.cklstRole.Items.Count; i++)
            {
                string userId = ((System.Data.DataRowView)this.cklstRole.Items[i])[BaseUserEntity.FieldId].ToString();
                if (Array.IndexOf(roleIds, userId) >= 0)
                {
                    this.cklstRole.SetItemChecked(i, true);
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
            for (int i = 0; i < this.cklstRole.Items.Count; i++)
            {
                this.cklstRole.SetItemChecked(i, false);
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

        private void cklstRole_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (this.isUserClick)
            {
                bool itemChecked = this.cklstRole.GetItemChecked(this.cklstRole.SelectedIndex);
                string roleId = ((System.Data.DataRowView)this.cklstRole.Items[e.Index])[BaseRoleEntity.FieldId].ToString();
                if (itemChecked)
                {
                    // 被撤销了
                    DotNetService.Instance.RoleService.RemoveUserFromRole(this.UserInfo, roleId, new string[] { TargetUserId });
                }
                else
                {
                    DotNetService.Instance.RoleService.AddUserToRole(this.UserInfo, roleId, new string[] { TargetUserId });
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
                    
                    DotNetService.Instance.PermissionService.GrantUserModuleScope(this.UserInfo, this.TargetUserId, "Resource.AccessPermission", (e.Node.Tag as DataRow)[BaseModuleEntity.FieldId].ToString());
                }
                else
                {
                    // 撤销操作权限
                    DotNetService.Instance.PermissionService.RevokeUserModuleScope(this.UserInfo, this.TargetUserId, "Resource.AccessPermission", (e.Node.Tag as DataRow)[BaseModuleEntity.FieldId].ToString());
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
                    DotNetService.Instance.PermissionService.GrantUserPermissionById(this.UserInfo, this.TargetUserId, (e.Node.Tag as DataRow)[BaseModuleEntity.FieldId].ToString());
                }
                else
                {
                    // 撤销操作权限
                    DotNetService.Instance.PermissionService.RevokeUserPermissionById(this.UserInfo, this.TargetUserId, (e.Node.Tag as DataRow)[BaseModuleEntity.FieldId].ToString());
                }
            }
        }


        //comment by zgl on 20110707
        //private void tvModule_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (tvModule.GetNodeAt(e.X, e.Y) != null)
        //    {
        //        tvModule.SelectedNode = tvModule.GetNodeAt(e.X, e.Y);
        //    }
        //}

        //comment by zgl on 20110707
        //private void tvPermissionItem_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (tvPermissionItem.GetNodeAt(e.X, e.Y) != null)
        //    {
        //        tvPermissionItem.SelectedNode = tvPermissionItem.GetNodeAt(e.X, e.Y);
        //    }
        //}

        private void btnClearPermission_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(AppMessage.MSG0600, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                // 清除权限
                DotNetService.Instance.PermissionService.ClearUserPermission(UserInfo, this.TargetUserId);
                this.GetCurrentPermission();
            }
        }

        [Serializable]
        private class UserPermission
        {
            public List<BaseRoleEntity> RoleEntites = null;
            public string[] GrantModuleIds = null;
            public string[] GrantPermissionIds = null;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            UserPermission userPermission = new UserPermission();
            // 读取角色数据
            List<BaseRoleEntity> roleEntites = new List<BaseRoleEntity>();
            for (int i = 0; i < this.cklstRole.CheckedItems.Count; i++)
            {
                BaseRoleEntity roleEntity = new BaseRoleEntity(((System.Data.DataRowView)this.cklstRole.CheckedItems[i]).Row);
                roleEntites.Add(roleEntity);
            }
            // 角色复制到剪切板
            userPermission.RoleEntites = roleEntites;
            // 模块访问权限复制到剪切板
            string[] grantModuleIds = this.GetGrantModuleIds();
            userPermission.GrantModuleIds = grantModuleIds;
            // 操作权限复制到剪切板
            string[] grantPermissionIds = this.GetGrantPermissionIds();
            userPermission.GrantPermissionIds = grantPermissionIds;

            Clipboard.SetData("userPermission", userPermission);
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
            object clipboardData = Clipboard.GetData("userPermission");
            if (clipboardData != null)
            {
                UserPermission userPermission = (UserPermission)clipboardData;

                List<BaseRoleEntity> roleEntites = userPermission.RoleEntites;
                string[] addRoleIds = new string[roleEntites.Count];
                for (int i = 0; i < roleEntites.Count; i++)
                {
                    addRoleIds[i] = roleEntites[i].Id.ToString();
                }
                // 添加用户到角色
                DotNetService.Instance.UserService.AddUserToRole(this.UserInfo, this.TargetUserId, addRoleIds);

                string[] grantModuleIds = userPermission.GrantModuleIds;
                DotNetService.Instance.PermissionService.GrantUserModuleScopes(UserInfo, this.TargetUserId,"Resource.AccessPermission", grantModuleIds);

                string[] grantPermissionIds = userPermission.GrantPermissionIds;
                DotNetService.Instance.PermissionService.GrantUserPermissions(UserInfo, new string[] { this.TargetUserId }, grantPermissionIds);

                this.GetCurrentPermission();
            }
        }

        private void tvModule_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            CheckChild(e.Node);
            CheckParent(e.Node);
        }
        private void tvPermissionItem_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            CheckChild(e.Node);
            CheckParent(e.Node);
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