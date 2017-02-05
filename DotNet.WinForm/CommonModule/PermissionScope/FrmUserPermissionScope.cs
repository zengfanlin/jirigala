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
    /// FrmUserPermissionScope.cs
    /// 用户权限域设置
    ///		
    /// 修改记录
    /// 
    ///     2010.07.30 版本：3.0 JiRiGaLa 权限范围设置错误修正。
    ///     2007.08.23 版本：2.0 JiRiGaLa 整理主键。
    ///     2007.08.22 版本：1.0 JiRiGaLa 角色权限域。
    ///		
    /// 版本：2.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.08.23</date>
    /// </author> 
    /// </summary>  
    public partial class FrmUserPermissionScope : BaseForm
    {
        /// <summary>
        /// 显示提示信息
        /// </summary>
        public bool ShowInformation = true;

        private DataTable DTOrganize = new DataTable(BaseOrganizeEntity.TableName);   // 组织机构表
        private DataTable DTRole = new DataTable(BaseRoleEntity.TableName);       // 角色表
        private DataTable DTUser = new DataTable(BaseUserEntity.TableName);      // 用户表

        private string[] OrganizeIds = null;
        private string[] RoleIds = null;
        private string[] UserIds = null;

        /// <summary>
        /// 是否是用户点击了复选框
        /// </summary>
        private bool isUserClick = true;

        public string permissionItemScopeCode = "Resource.ManagePermission";

        /// <summary>
        /// 权限域编号
        /// </summary>
        public string PermissionItemScopeCode
        {
            set
            {
                permissionItemScopeCode = value;
                BasePermissionItemEntity permissionItemEntity = DotNetService.Instance.PermissionItemService.GetEntityByCode(this.UserInfo, permissionItemScopeCode);
                this.ucPermissionScope.SelectedId = permissionItemEntity.Id.ToString();
            }
            get
            {
                return permissionItemScopeCode;
            }
        }


        // 权限主键
        private string TargetPermissionId
        {
            set
            {
                this.ucPermissionScope.SelectedId = value;
            }
            get
            {
                return this.ucPermissionScope.SelectedId;
            }
        }

        // 权限名称     
        private string TargetPermissionFullName
        {
            set
            {
                this.ucPermissionScope.SelectedFullName = value;
            }
            get
            {
                return this.ucPermissionScope.SelectedFullName;
            }
        }

        // 用户主键
        private string TargetUserId
        {
            set
            {
                this.ucUser.SelectedId = value;
            }
            get
            {
                return this.ucUser.SelectedId;
            }
        }

        // 用户名称     
        private string TargetUserFullName
        {
            set
            {
                this.ucUser.SelectedFullName = value;
            }
            get
            {
                return this.ucUser.SelectedFullName;
            }
        }

        private string currentEntityId = string.Empty;
        /// <summary>
        /// 当前选中的节点，树上
        /// </summary>
        public string CurrentEntityId
        {
            get
            {
                if ((this.tvOrganize.SelectedNode != null) && (this.tvOrganize.SelectedNode.Tag != null))
                {
                    this.currentEntityId = (this.tvOrganize.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                }
                return this.currentEntityId;
            }
            set
            {
                this.currentEntityId = value;
            }
        }


        public FrmUserPermissionScope()
        {
            InitializeComponent();
        }

        public FrmUserPermissionScope(string targetUserId)
            : this()
        {
            this.TargetUserId = targetUserId;
        }

        public FrmUserPermissionScope(string targetUserId, string permissionItemScopeCode)
            : this(targetUserId)
        {
            this.PermissionItemScopeCode = permissionItemScopeCode;
        }

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAccess = this.IsAuthorized("UserAdmin.Accredit");   // 访问权限
            this.permissionEdit = this.IsAuthorized("UserAdmin.Accredit");     // 编辑权限
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // 是否可以选择空
            this.ucPermissionScope.AllowNull = false;
            this.ucUser.AllowNull = false;
            // 检查编辑权限
            this.btnBatchSave.Enabled = this.permissionEdit;
            this.btnSelectAll.Enabled = this.permissionEdit;
            this.btnInvertSelect.Enabled = this.permissionEdit;
        }
        #endregion

        private void chkInnerOrganize_CheckedChanged(object sender, EventArgs e)
        {
            this.OnLoad(e);
        }

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 获取组织机构数据
            this.DTOrganize = this.GetOrganizeScope(this.PermissionItemScopeCode, this.chkInnerOrganize.Checked);
            this.DTRole = this.GetRoleScope(this.PermissionItemScopeCode);
            this.DTUser = this.GetUserScope(this.PermissionItemScopeCode);
            // 权限域数据
            this.OrganizeIds = DotNetService.Instance.PermissionService.GetUserScopeOrganizeIds(UserInfo, this.TargetUserId, this.PermissionItemScopeCode);
            this.RoleIds = DotNetService.Instance.PermissionService.GetUserScopeRoleIds(UserInfo, this.TargetUserId, this.PermissionItemScopeCode);
            this.UserIds = DotNetService.Instance.PermissionService.GetUserScopeUserIds(UserInfo, this.TargetUserId, this.PermissionItemScopeCode);
            // 显示当前选中的权限范围选项
            this.ShowPermissionScope(this.OrganizeIds);
            // 加载树
            this.BindData(true);
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
                // 查找 ParentId 字段的值是否在 ID字段 里
                BaseInterfaceLogic.CheckTreeParentId(this.DTOrganize, BaseOrganizeEntity.FieldId, BaseOrganizeEntity.FieldParentId);
                this.LoadTree();
            }
            if (this.tvOrganize.SelectedNode == null)
            {
                if (this.tvOrganize.Nodes.Count > 0)
                {
                    if (this.CurrentEntityId.Length == 0)
                    {
                        this.tvOrganize.SelectedNode = this.tvOrganize.Nodes[0];
                    }
                    else
                    {
                        BaseInterfaceLogic.FindTreeNode(this.tvOrganize, this.CurrentEntityId);
                        if (BaseInterfaceLogic.TargetNode != null)
                        {
                            this.tvOrganize.SelectedNode = BaseInterfaceLogic.TargetNode;
                            // 展开当前选中节点的所有父节点
                            BaseInterfaceLogic.ExpandTreeNode(this.tvOrganize);
                        }
                    }
                    if (this.tvOrganize.SelectedNode != null)
                    {
                        // 让选中的节点可视，并用展开方式
                        this.tvOrganize.SelectedNode.Expand();
                        this.tvOrganize.SelectedNode.EnsureVisible();
                    }
                }
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
            this.tvOrganize.BeginUpdate();
            this.tvOrganize.Nodes.Clear();
            TreeNode treeNode = new TreeNode();
            this.LoadTreeOrganize(treeNode);
            this.tvOrganize.EndUpdate();
        }
        #endregion

        #region private void LoadTreeOrganize(TreeNode treeNode)
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="TreeNode">当前节点</param>
        private void LoadTreeOrganize(TreeNode treeNode)
        {
            DataRow[] dataRows = null;
            if (treeNode.Tag == null)
            {
                dataRows = this.DTOrganize.Select(BaseOrganizeEntity.FieldParentId + " IS NULL OR " + BaseOrganizeEntity.FieldParentId + " = 0 ", BaseOrganizeEntity.FieldSortCode);
            }
            else
            {
                // string id = (treeNode.Tag as DataRow)[BaseOrganizeEntity.FieldId].ToString();
                string id = treeNode.Tag.ToString();
                dataRows = this.DTOrganize.Select(BaseOrganizeEntity.FieldParentId + "= " + id, BaseOrganizeEntity.FieldSortCode);
            }
            foreach (DataRow dataRow in dataRows)
            {
                // 判断不为空的当前节点的子节点
                if ((treeNode.Tag != null) && ((treeNode.Tag.ToString().Length > 0) && (!(treeNode.Tag.ToString().Equals(dataRow[BaseOrganizeEntity.FieldParentId].ToString())))))
                {
                    continue;
                }

                // 当前节点的子节点, 加载根节点
                if (dataRow.IsNull(BaseOrganizeEntity.FieldParentId) 
                    || (dataRow[BaseOrganizeEntity.FieldParentId].ToString().Length == 0) 
                    || (dataRow[BaseOrganizeEntity.FieldParentId].ToString().Equals(BaseSystemInfo.RootMenuCode)) 
                    || ((treeNode.Tag != null) && (treeNode.Tag.ToString().Equals(dataRow[BaseModuleEntity.FieldParentId].ToString()))))
                {
                    TreeNode newTreeNode = new TreeNode();
                    newTreeNode.Text = dataRow[BaseOrganizeEntity.FieldFullName].ToString();
                    newTreeNode.Tag = dataRow[BaseOrganizeEntity.FieldId].ToString();
                    newTreeNode.Checked = Array.IndexOf(this.OrganizeIds, dataRow[BasePermissionItemEntity.FieldId].ToString()) >= 0;
                    newTreeNode.ImageIndex = 0;
                    newTreeNode.SelectedImageIndex = 1;

                    // 写入调试信息
                    #if (DEBUG)
                        newTreeNode.ToolTipText = dataRow[BaseOrganizeEntity.FieldId].ToString();
                    #endif

                    if ((treeNode.Tag == null) || (treeNode.Tag.ToString().Length == 0))
                    {
                        // 树的根节点加载
                        this.tvOrganize.Nodes.Add(newTreeNode);
                    }
                    else
                    {
                        // 节点的子节点加载
                        treeNode.Nodes.Add(newTreeNode);
                    }

                    // 递归调用本函数
                    this.LoadTreeOrganize(newTreeNode);
                }
            }

            // 添加角色
            if ((treeNode.Tag != null) && (treeNode.Tag.ToString().Length > 0))
            {
                // 添加角色
                dataRows = this.DTRole.Select(BaseRoleEntity.FieldSystemId + "=" + treeNode.Tag.ToString() + "");
                foreach (DataRow roleDataRow in dataRows)
                {
                    TreeNode roleTreeNode = new TreeNode();
                    roleTreeNode.Text = roleDataRow[BaseRoleEntity.FieldRealName].ToString();
                    roleTreeNode.Tag = roleDataRow[BaseRoleEntity.FieldId].ToString();
                    roleTreeNode.Checked = Array.IndexOf(this.RoleIds, roleDataRow[BaseRoleEntity.FieldId].ToString()) >= 0;
                    roleTreeNode.ImageIndex = 22;
                    roleTreeNode.SelectedImageIndex = 22;

                    // 写入调试信息
                    #if (DEBUG)
                        roleTreeNode.ToolTipText = roleDataRow[BaseRoleEntity.FieldId].ToString();
                    #endif

                    treeNode.Nodes.Add(roleTreeNode);
                }

                // 添加员工
                dataRows = this.DTUser.Select(BaseUserEntity.FieldDepartmentId + "='" + treeNode.Tag.ToString() + "'");
                foreach (DataRow userDataRow in dataRows)
                {
                    TreeNode userTreeNode = new TreeNode();
                    userTreeNode.Text = userDataRow[BaseUserEntity.FieldRealName].ToString();
                    userTreeNode.Tag = userDataRow[BaseUserEntity.FieldId].ToString();
                    userTreeNode.Checked = Array.IndexOf(this.UserIds, userDataRow[BaseUserEntity.FieldId].ToString()) >= 0;
                    userTreeNode.ImageIndex = 16;
                    userTreeNode.SelectedImageIndex = 16;

                    // 写入调试信息
                    #if (DEBUG)
                        userTreeNode.ToolTipText = userDataRow[BaseUserEntity.FieldId].ToString();
                    #endif

                    treeNode.Nodes.Add(userTreeNode);
                }
            }
        }
        #endregion

        private void tvOrganize_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (this.isUserClick)
            {
                for (int i = 0; i < e.Node.Nodes.Count; i++)
                {
                    // 只将部门选择上就可以了，提高运行效率
                    if (e.Node.Nodes[i].ImageIndex <= 1)
                    {
                        e.Node.Nodes[i].Checked = e.Node.Checked;
                    }
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
            if ((treeNode != null && treeNode.Tag != null && (treeNode.Tag as DataRow) != null))
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
            if ((treeNode != null && treeNode.Tag != null && (treeNode.Tag as DataRow) != null))
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
            for (int i = 0; i < this.tvOrganize.Nodes.Count; i++)
            {
                this.SetTreeNodesSelected(this.tvOrganize.Nodes[i], true);
            }
            this.isUserClick = true;
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            this.isUserClick = false;
            for (int i = 0; i < this.tvOrganize.Nodes.Count; i++)
            {
                this.SetTreeNodesTurnSelected(this.tvOrganize.Nodes[i]);
            }
            this.isUserClick = true;
        }

        /// <summary>
        /// 授权的部门权限域
        /// </summary>
        string GrantOrganizes = string.Empty;

        /// <summary>
        /// 撤销的部门权限域
        /// </summary>
        string RevokeOrganizes = string.Empty;

        string GrantRoles = string.Empty;
        string RevokeRoles = string.Empty;

        string GrantUsers = string.Empty;
        string RevokeUsers = string.Empty;

        private void EntityToArray(TreeNode treeNode)
        {
            if (treeNode.Tag != null)
            {
                // 这是部门数据
                if (treeNode.ImageIndex == 0)
                {
                    // 提高运行速度
                    string organizeId = treeNode.Tag.ToString();
                    if (treeNode.Checked)
                    {
                        // 这里是授权的权限
                        if (Array.IndexOf(this.OrganizeIds, organizeId) < 0)
                        {
                            this.GrantOrganizes += organizeId + ";";
                        }
                    }
                    else
                    {
                        // 这里是撤销的权限
                        if (Array.IndexOf(this.OrganizeIds, organizeId) >= 0)
                        {
                            this.RevokeOrganizes += organizeId + ";";
                        }
                    }
                }
                // 这是角色数据
                else if (treeNode.ImageIndex == 22)
                {
                    // 提高运行速度
                    string roleId = treeNode.Tag.ToString();
                    if (treeNode.Checked)
                    {
                        // 这里是授权的权限
                        if (Array.IndexOf(this.RoleIds, roleId) < 0)
                        {
                            this.GrantRoles += roleId + ";";
                        }
                    }
                    else
                    {
                        // 这里是撤销的权限
                        if (Array.IndexOf(this.RoleIds, roleId) >= 0)
                        {
                            this.RevokeRoles += roleId + ";";
                        }
                    }
                }
                // 这是用户数据
                else if (treeNode.ImageIndex == 16)
                {
                    // 提高运行速度
                    string userId = treeNode.Tag.ToString();
                    if (treeNode.Checked)
                    {
                        // 这里是授权的权限
                        if (Array.IndexOf(this.UserIds, userId) < 0)
                        {
                            this.GrantUsers += userId + ";";
                        }
                    }
                    else
                    {
                        // 这里是撤销的权限
                        if (Array.IndexOf(this.UserIds, userId) >= 0)
                        {
                            this.RevokeUsers += userId + ";";
                        }
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
            for (int i = 0; i < this.tvOrganize.Nodes.Count; i++)
            {
                TreeNode treeNode = this.tvOrganize.Nodes[i];
                this.CheckParentChecked(treeNode);
            }
        }

        /// <summary>
        /// 显示当前选中的权限范围选项
        /// </summary>
        /// <param name="organizeIds">组织机构权限范围</param>
        private void ShowPermissionScope(string[] organizeIds)
        {
            // 从小到大的顺序进行显示，防止错误发生
            this.rdbNone.Checked = StringUtil.Exists(organizeIds, ((int)PermissionScope.None).ToString());
            this.rdbDetail.Checked = StringUtil.Exists(organizeIds, ((int)PermissionScope.Detail).ToString());
            this.rdbUser.Checked = StringUtil.Exists(organizeIds, ((int)PermissionScope.User).ToString());
            this.rdbUserWorkgroup.Checked = StringUtil.Exists(organizeIds, ((int)PermissionScope.UserWorkgroup).ToString());
            this.rdbUserDepartment.Checked = StringUtil.Exists(organizeIds, ((int)PermissionScope.UserDepartment).ToString());
            this.rdbUserSubCompany.Checked = StringUtil.Exists(organizeIds, ((int)PermissionScope.UserSubCompany).ToString());
            this.rdbUserCompany.Checked = StringUtil.Exists(organizeIds, ((int)PermissionScope.UserCompany).ToString());
            this.rdbAll.Checked = StringUtil.Exists(organizeIds, ((int)PermissionScope.All).ToString());
        }

        /// <summary>
        /// 获得当前选中的权限范围选项
        /// </summary>
        /// <param name="revokePermissionItemScope">被移除的权限</param>
        /// <returns>选中权限范围</returns>
        private PermissionScope GetPermissionScope(out string revokePermissionItemScope)
        {
            PermissionScope returnValue = PermissionScope.None;
            revokePermissionItemScope = string.Empty;

            if (this.rdbAll.Checked)
            {
                returnValue = PermissionScope.All;
            }
            else
            {
                revokePermissionItemScope += ((int)PermissionScope.All).ToString() + ";";
            }

            if (this.rdbUserCompany.Checked)
            {
                returnValue = PermissionScope.UserCompany;
            }
            else
            {
                revokePermissionItemScope += ((int)PermissionScope.UserCompany).ToString() + ";";
            }

            if (this.rdbUserSubCompany.Checked)
            {
                returnValue = PermissionScope.UserSubCompany;
            }
            else
            {
                revokePermissionItemScope += ((int)PermissionScope.UserSubCompany).ToString() + ";";
            }

            if (this.rdbUserDepartment.Checked)
            {
                returnValue = PermissionScope.UserDepartment;
            }
            else
            {
                revokePermissionItemScope += ((int)PermissionScope.UserDepartment).ToString() + ";";
            }

            if (this.rdbUserWorkgroup.Checked)
            {
                returnValue = PermissionScope.UserWorkgroup;
            }
            else
            {
                revokePermissionItemScope += ((int)PermissionScope.UserWorkgroup).ToString() + ";";
            }

            if (this.rdbUser.Checked)
            {
                returnValue = PermissionScope.User;
            }
            else
            {
                revokePermissionItemScope += ((int)PermissionScope.User).ToString() + ";";
            }

            if (this.rdbDetail.Checked)
            {
                returnValue = PermissionScope.Detail;
            }
            else
            {
                revokePermissionItemScope += ((int)PermissionScope.Detail).ToString() + ";";
            }

            if (this.rdbNone.Checked)
            {
                returnValue = PermissionScope.None;
            }
            else
            {
                revokePermissionItemScope += ((int)PermissionScope.None).ToString() + ";";
            }

            return returnValue;
        }

        #region private bool BatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private bool BatchSave()
        {
            bool returnValue = true;

            this.GrantOrganizes = string.Empty;
            this.RevokeOrganizes = string.Empty;

            this.GrantRoles = string.Empty;
            this.RevokeRoles = string.Empty;

            this.GrantUsers = string.Empty;
            this.RevokeUsers = string.Empty;

            // 吉日嘎拉 20110322- 这里不应该设置为 0 的，
            // nick
            // this.OrganizeIds = new string[0]; 
            for (int i = 0; i < this.tvOrganize.Nodes.Count; i++)
            {
                this.EntityToArray(this.tvOrganize.Nodes[i]);
            }

            // 员工的部门权限域
            string[] grantOrganizeIds = null;
            string[] revokeOrganizeIds = null;

            string revokePermissionScope = string.Empty;
            // 当前选中的，特殊的权限范围，也算是组织机构的特殊形式保存起来
            if (String.IsNullOrEmpty(this.GrantOrganizes))
                this.GrantOrganizes += ((int)this.GetPermissionScope(out revokePermissionScope)).ToString() + ";";

            if (this.GrantOrganizes.Length > 1)
            {
                // 按正常的组织机构进行处理
                this.GrantOrganizes = this.GrantOrganizes.Substring(0, this.GrantOrganizes.Length - 1);
                if (this.GrantOrganizes != "0")
                {
                    grantOrganizeIds = this.GrantOrganizes.Split(';');
                }
            }

            // 这里是被选中的被移除的，特殊的权限范围，也算是组织机构的特殊形式保存起来
            this.RevokeOrganizes += revokePermissionScope;
            if (this.RevokeOrganizes.Length > 1)
            {
                this.RevokeOrganizes = this.RevokeOrganizes.Substring(0, this.RevokeOrganizes.Length - 1);
                revokeOrganizeIds = this.RevokeOrganizes.Split(';');
            }

            // 员工的角色权限域
            string[] grantRoleIds = null;
            string[] revokeRoleIds = null;
            if (this.GrantRoles.Length > 1)
            {
                this.GrantRoles = this.GrantRoles.Substring(0, this.GrantRoles.Length - 1);
                grantRoleIds = this.GrantRoles.Split(';');
            }
            if (this.RevokeRoles.Length > 1)
            {
                this.RevokeRoles = this.RevokeRoles.Substring(0, this.RevokeRoles.Length - 1);
                revokeRoleIds = this.RevokeRoles.Split(';');
            }

            // 员工的员工权限域
            string[] grantUserIds = null;
            string[] revokeUserIds = null;
            if (this.GrantUsers.Length > 1)
            {
                this.GrantUsers = this.GrantUsers.Substring(0, this.GrantUsers.Length - 1);
                grantUserIds = this.GrantUsers.Split(';');
            }
            if (this.RevokeUsers.Length > 1)
            {
                this.RevokeUsers = this.RevokeUsers.Substring(0, this.RevokeUsers.Length - 1);
                revokeUserIds = this.RevokeUsers.Split(';');
            }

            // 批量保存权限域
            DotNetService.Instance.PermissionService.GrantUserOrganizeScopes(UserInfo, this.TargetUserId, this.PermissionItemScopeCode, grantOrganizeIds);
            if (grantOrganizeIds != null)
            {
                DotNetService.Instance.PermissionService.RevokeUserOrganizeScopes(UserInfo, this.TargetUserId, this.PermissionItemScopeCode, revokeOrganizeIds);
            }

            DotNetService.Instance.PermissionService.GrantUserRoleScopes(UserInfo, this.TargetUserId, this.PermissionItemScopeCode, grantRoleIds);
            DotNetService.Instance.PermissionService.RevokeUserRoleScopes(UserInfo, this.TargetUserId, this.PermissionItemScopeCode, revokeRoleIds);

            DotNetService.Instance.PermissionService.GrantUserUserScopes(UserInfo, this.TargetUserId, this.PermissionItemScopeCode, grantUserIds);
            DotNetService.Instance.PermissionService.RevokeUserUserScopes(UserInfo, this.TargetUserId, this.PermissionItemScopeCode, revokeUserIds);
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

        private void tvOrganize_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvOrganize.GetNodeAt(e.X, e.Y) != null)
            {
                tvOrganize.SelectedNode = tvOrganize.GetNodeAt(e.X, e.Y);
            }
        }
    }
}