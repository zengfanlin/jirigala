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
    /// FrmRolePermissionScope.cs
    /// 角色权限域
    ///		
    /// 修改记录
    ///     2011.07.23 版本：1.2 张广梁    修改tvModule  tvPermissionItem节点选择时的逻辑错误
    ///     2011.07.17 版本：1.1 张广梁    优化tvOragnize节点选择，自动选择父节点
    ///     2010.07.30 版本：3.0 JiRiGaLa 权限范围设置错误修正。
    ///     2007.08.23 版本：2.0 JiRiGaLa 整理主键。
    ///     2007.08.22 版本：1.0 JiRiGaLa 角色权限域。
    ///		
    /// 版本：2.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.07.30</date>
    /// </author> 
    /// </summary>  
    public partial class FrmRolePermissionScope : BaseForm
    {
        /// <summary>
        /// 显示提示信息
        /// </summary>
        public bool ShowInformation = true;

        /// <summary>
        /// 组织机构表
        /// </summary>
        private DataTable DTOrganize = new DataTable(BaseOrganizeEntity.TableName);

        private string[] OrganizeIds = null;

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

        /// <summary>
        /// 是否是用户点击了复选框
        /// </summary>
        //Pcsky 2012.05.02 未使用的功能，禁用
        //private bool isUserClick = true;

        /// <summary>
        /// 权限主键
        /// </summary>
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

        /// <summary>
        /// 权限名称
        /// </summary>     
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


        /// <summary>
        /// 角色主键
        /// </summary>
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

        /// <summary>
        /// 角色名称
        /// </summary>     
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
                    this.currentEntityId = this.tvOrganize.SelectedNode.Tag.ToString();
                }
                return this.currentEntityId;
            }
            set
            {
                this.currentEntityId = value;
            }
        }

        public FrmRolePermissionScope()
        {
            InitializeComponent();
        }

        public FrmRolePermissionScope(string targetRoleId)
            : this()
        {
            this.TargetRoleId = targetRoleId;
        }

        public FrmRolePermissionScope(string roleId, string permissionItemScopeCode)
            : this(roleId)
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
            this.ucRole.AllowNull = false;
            this.ucRole.ShowRoleOnly = true;
            this.ucRole.MultiSelect = false;
            this.ucPermissionScope.AllowNull = false;
            this.ucPermissionScope.MultiSelect = false;

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
            this.OrganizeIds = DotNetService.Instance.PermissionService.GetRoleScopeOrganizeIds(UserInfo, this.TargetRoleId, this.PermissionItemScopeCode);
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
                dataRows = this.DTOrganize.Select(BaseOrganizeEntity.FieldParentId + "=" + treeNode.Tag.ToString() + "", BaseOrganizeEntity.FieldSortCode);
            }
            foreach (DataRow dataRow in dataRows)
            {
                // 判断不为空的当前节点的子节点
                if ((treeNode.Tag != null) 
                    && (treeNode.Tag.ToString().Length > 0) 
                    && (!treeNode.Tag.ToString().Equals(dataRow[BaseOrganizeEntity.FieldParentId].ToString())))
                {
                    continue;
                }

                // 当前节点的子节点, 加载根节点
                if ((dataRow.IsNull(BaseOrganizeEntity.FieldParentId) 
                    || (dataRow[BaseOrganizeEntity.FieldParentId].ToString().Length == 0) 
                    || (dataRow[BaseOrganizeEntity.FieldParentId].ToString().Equals(BaseSystemInfo.RootMenuCode))
                    || ((treeNode.Tag != null) && treeNode.Tag.ToString().Equals(dataRow[BaseOrganizeEntity.FieldParentId].ToString()))))
                {
                    TreeNode newTreeNode = new TreeNode();
                    newTreeNode.Text = dataRow[BaseOrganizeEntity.FieldFullName].ToString();
                    newTreeNode.Tag = dataRow[BaseOrganizeEntity.FieldId].ToString();
                    newTreeNode.Checked = Array.IndexOf(this.OrganizeIds, dataRow[BaseOrganizeEntity.FieldId].ToString()) >= 0;

                    // 写入调试信息
                    #if (DEBUG)
                        newTreeNode.ToolTipText = dataRow[BaseRoleEntity.FieldId].ToString();
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
            if (treeNode != null && treeNode.Tag != null)
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
            if (treeNode != null && treeNode.Tag != null)
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
            //Pcsky 2012.05.02 未使用的功能，禁用
            //this.isUserClick = false;
            for (int i = 0; i < this.tvOrganize.Nodes.Count; i++)
            {
                this.SetTreeNodesSelected(this.tvOrganize.Nodes[i], true);
            }
            //Pcsky 2012.05.02 未使用的功能，禁用
            //this.isUserClick = true;
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            //Pcsky 2012.05.02 未使用的功能，禁用
            //this.isUserClick = false;
            for (int i = 0; i < this.tvOrganize.Nodes.Count; i++)
            {
                this.SetTreeNodesTurnSelected(this.tvOrganize.Nodes[i]);
            }
            //Pcsky 2012.05.02 未使用的功能，禁用
            //this.isUserClick = true;
        }

        /// <summary>
        /// 授权的权限
        /// </summary>
        string GrantOrganizes = string.Empty;

        /// <summary>
        /// 撤销的权限
        /// </summary>
        string RevokeOrganizes = string.Empty;

        private void EntityToArray(TreeNode treeNode)
        {
            if (treeNode.Tag != null)
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
            //Pcsky 2012.05.02 未使用的功能，禁用
            //this.isUserClick = false;
            for (int i = 0; i < this.tvOrganize.Nodes.Count; i++)
            {
                TreeNode treeNode = this.tvOrganize.Nodes[i];
                this.CheckParentChecked(treeNode);
            }
        }

        /// <summary>
        /// 显示当前选中的权限范围选项
        /// </summary>
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
        /// <param name="revokePermissionScope">被移除的权限</param>
        /// <returns>选中权限范围</returns>
        private PermissionScope GetPermissionScope(out string revokePermissionScope)
        {
            PermissionScope returnValue = PermissionScope.None;
            revokePermissionScope = string.Empty;

            if (this.rdbAll.Checked)
            {
                returnValue = PermissionScope.All;
            }
            else
            {
                revokePermissionScope += ((int)PermissionScope.All).ToString() + ";";
            }

            if (this.rdbUserCompany.Checked)
            {
                returnValue = PermissionScope.UserCompany;
            }
            else
            {
                revokePermissionScope += ((int)PermissionScope.UserCompany).ToString() + ";";
            }

            if (this.rdbUserSubCompany.Checked)
            {
                returnValue = PermissionScope.UserSubCompany;
            }
            else
            {
                revokePermissionScope += ((int)PermissionScope.UserSubCompany).ToString() + ";";
            }

            if (this.rdbUserDepartment.Checked)
            {
                returnValue = PermissionScope.UserDepartment;
            }
            else
            {
                revokePermissionScope += ((int)PermissionScope.UserDepartment).ToString() + ";";
            }

            if (this.rdbUserWorkgroup.Checked)
            {
                returnValue = PermissionScope.UserWorkgroup;
            }
            else
            {
                revokePermissionScope += ((int)PermissionScope.UserWorkgroup).ToString() + ";";
            }

            if (this.rdbUser.Checked)
            {
                returnValue = PermissionScope.User;
            }
            else
            {
                revokePermissionScope += ((int)PermissionScope.User).ToString() + ";";
            }

            if (this.rdbDetail.Checked)
            {
                returnValue = PermissionScope.Detail;
            }
            else
            {
                revokePermissionScope += ((int)PermissionScope.Detail).ToString() + ";";
            }

            if (this.rdbNone.Checked)
            {
                returnValue = PermissionScope.None;
            }
            else
            {
                revokePermissionScope += ((int)PermissionScope.None).ToString() + ";";
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
            // 吉日嘎拉 20110322- 这里不应该设置为 0 的，
            // nick
            // this.OrganizeIds = new string[0]; 
            for (int i = 0; i < this.tvOrganize.Nodes.Count; i++)
            {
                this.EntityToArray(this.tvOrganize.Nodes[i]);
            }
            string[] grantOrganizeIds = null;
            string[] revokeOrganizeIds = null;

            string revokePermissionScope = string.Empty;
            // 当前选中的，特殊的权限范围，也算是组织机构的特殊形式保存起来,如果选择有明细，则不记录特殊枚举
            if (String.IsNullOrEmpty(this.GrantOrganizes))
                this.GrantOrganizes += ((int)this.GetPermissionScope(out revokePermissionScope)).ToString() + ";";

            if (this.GrantOrganizes.Length > 2)
            {
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
            this.GrantOrganizes = string.Empty;
            this.RevokeOrganizes = string.Empty;

            if (grantOrganizeIds != null)
            {
                DotNetService.Instance.PermissionService.GrantRoleOrganizeScopes(UserInfo, this.TargetRoleId, this.PermissionItemScopeCode, grantOrganizeIds);
            }
            if (revokeOrganizeIds != null)
            {
                DotNetService.Instance.PermissionService.RevokeRoleOrganizeScopes(UserInfo, this.TargetRoleId, this.PermissionItemScopeCode, revokeOrganizeIds);
            }
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

        private void tvOrganize_AfterCheck(object sender, TreeViewEventArgs e)
        {
            this.CheckChild(e.Node);
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
                if(!childNodeCheck||!node.Checked)
                {
                    foreach (TreeNode item in node.Nodes)
                    {
                        item.Checked =node.Checked;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

 

    }
}