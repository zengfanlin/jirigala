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
    

    /// FrmUserPermissionView.cs
    /// 显示用户权限
    ///		
    /// 修改记录

    ///     2011.12.13 版本：1.1 张广梁    修改获取、绑定、检查Module的方法，增加操作权限
    ///     2010.12.28 版本：1.0 JiRiGaLa  角色权限批量设置。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.12.28</date>
    /// </author> 
    /// </summary>

    public partial class FrmUserPermissionView : BaseForm
    {
        public FrmUserPermissionView()
        {
            InitializeComponent();
        }

        public FrmUserPermissionView(string userId): this()
        {
            this.TargetUserId = userId;
        }

        public string TargetUserId = string.Empty;

        private DataTable DTModule = new DataTable(BaseModuleEntity.TableName);

        private DataTable DTPermissionItem = new DataTable(BasePermissionItemEntity.TableName);

        private string[] ModuleIds = null;

        private string[] PermissionItemIds = null;

        public override void FormOnLoad()
        {
            if (string.IsNullOrEmpty(this.TargetUserId))
            {
                this.TargetUserId = this.UserInfo.Id;
            }

            // 显示用户信息
            this.ShowUserEntity();

            // 显示角色列表
            this.ShowRoleList();

            // 显示菜单权限
            this.ShowModule();

            // 显示操作权限
            this.ShowPermissionItem();

            // 显示数据集权限
            this.GetTableScope();
        }

        public override void SetControlState()
        {
            this.btnShowRolePermission.Enabled = this.grdRole.RowCount > 0;
        }

        #region private void ShowUserEntity() 显示内容
        /// <summary>
        /// 显示用户信息
        /// </summary>
        private void ShowUserEntity()
        {
            BaseUserEntity userEntity = DotNetService.Instance.UserService.GetEntity(this.UserInfo, this.TargetUserId);
            // 绑定用户信息
            this.txtUserName.Text = userEntity.UserName;
            this.txtFullName.Text = userEntity.RealName;
            if (userEntity.RoleId != null)
            {
                BaseRoleEntity roleEntity = DotNetService.Instance.RoleService.GetEntity(this.UserInfo, userEntity.RoleId.ToString());
                this.txtRole.Text = roleEntity.RealName;
            }
        }
        #endregion

        #region private void ShowRoleList() 显示角色
        private void ShowRoleList()
        {
            string[] roleIds = DotNetService.Instance.UserService.GetUserRoleIds(UserInfo, this.TargetUserId);
            DataTable DTRole = DotNetService.Instance.RoleService.GetDataTableByIds(UserInfo, roleIds);
            DTRole.DefaultView.Sort = BaseRoleEntity.FieldSortCode;
            this.grdRole.AutoGenerateColumns = false;
            this.grdRole.DataSource = DTRole;
        }
        #endregion

        private void btnShowRolePermission_Click(object sender, EventArgs e)
        {
            DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdRole);
            string id = dataRow[BaseRoleEntity.FieldId].ToString();
            string realName = dataRow[BaseRoleEntity.FieldRealName].ToString();

            string assemblyName = "DotNet.WinForm";
            string formName = "FrmRoleModulePermission";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmRolePermission = (Form)Activator.CreateInstance(assemblyType, id, realName, true);
            frmRolePermission.ShowDialog(this);
        }

        #region 显示菜单权限

            #region  private void ShowModule() 显示菜单权限
            private void ShowModule()
            {
                this.ModuleIds = DotNetService.Instance.PermissionService.GetModuleIdsByUser(UserInfo, this.TargetUserId);
                this.DTModule = DotNetService.Instance.ModuleService.GetDataTable(UserInfo);
                BaseBusinessLogic.SetFilter(this.DTModule, BaseModuleEntity.FieldEnabled, "1");
                this.BindModule(true);
            }
            #endregion

            #region private void BindModule(bool reloadTree) 绑定菜单权限
            /// <summary>
            /// 绑定屏幕数据
            /// </summary>
            /// <param name="reloadTree">重新加载模块树</param>
            private void BindModule(bool reloadTree)
            {
                // 加载模块树的主键
                if (reloadTree)
                {
                    this.LoadModuleTree();
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
                this.CheckModule();
            }
            #endregion

            #region private void LoadModuleTree() 加载树的
            /// <summary>
            /// 加载树的
            /// </summary>
            private void LoadModuleTree()
            {
                // 开始更新控件，屏幕不刷新，提高效率。
                this.tvModule.BeginUpdate();
                this.tvModule.Nodes.Clear();
                TreeNode treeNode = new TreeNode();
                this.LoadTreeModuleItem(treeNode);
                // 更新控件，屏幕一次性刷新，提高效率。
                this.tvModule.EndUpdate();
            }
            #endregion

            #region private void LoadTreeModuleItem(TreeNode treeNode) 加载组织机构树的主键
            /// <summary>
            /// 加载组织机构树的主键
            /// </summary>
            /// <param name="treeNode">当前节点</param>
            private void LoadTreeModuleItem(TreeNode treeNode)
            {
                BaseInterfaceLogic.LoadTreeNodes(this.DTModule, BaseModuleEntity.FieldId, BaseModuleEntity.FieldParentId, BaseModuleEntity.FieldFullName, this.tvModule, treeNode, true, 1, BaseModuleEntity.FieldCode);
            }
            #endregion

            private void CheckModule()
            {
                // 获得用户的权限主键数组
                this.ModuleIds = DotNetService.Instance.PermissionService.GetModuleIdsByUser(UserInfo, this.TargetUserId);
                if (this.ModuleIds != null && this.ModuleIds.Length > 0)
                {
                    this.tvModule.BeginUpdate();
                    this.ModuleCheck();
                    this.tvModule.EndUpdate();
                }
            }

            private void ModuleCheck()
            {
                // 如果是管理员拥有所有权限
                if (this.UserInfo.IsAdministrator)
                {
                    // 递归调用到所有的子节点 
                    for (int i = 0; i < this.tvModule.Nodes.Count; i++)
                    {
                        this.tvModule.Nodes[i].Checked = true;
                        BaseInterfaceLogic.CheckChild(this.tvModule.Nodes[i]);
                    }
                    return;
                }
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
                    string moduleId = (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                    treeNode.Checked = Array.IndexOf(this.ModuleIds, moduleId) >= 0;
                    for (int i = 0; i < treeNode.Nodes.Count; i++)
                    {
                        // 这里进行递规操作
                        this.ModuleCheck(treeNode.Nodes[i]);
                    }
                }
            }
        #endregion

        #region 显示操作权限
            #region   private void ShowPermissionItem() 显示操作权限
            private void ShowPermissionItem()
            {
                this.PermissionItemIds = DotNetService.Instance.PermissionService.GetUserPermissionItemIds(UserInfo, this.TargetUserId);
                this.DTPermissionItem = DotNetService.Instance.PermissionItemService.GetDataTable(this.UserInfo);
                BaseBusinessLogic.SetFilter(this.DTModule, BaseModuleEntity.FieldEnabled, "1");
                this.BindPermissionItem(true);
            }
            #endregion

            #region private void BindPermissionItem(bool reloadTree) 绑定屏幕数据
            /// <summary>
            /// 绑定屏幕数据
            /// </summary>
            /// <param name="reloadTree">重新加载模块树</param>
            private void BindPermissionItem(bool reloadTree)
            {
                // 加载模块树的主键
                if (reloadTree)
                {
                    this.LoadPermissionTree();
                }
                if (this.tvPermissionItem.SelectedNode == null)
                {
                    if (this.tvPermissionItem.Nodes.Count > 0)
                    {
                        this.tvPermissionItem.SelectedNode = this.tvPermissionItem.Nodes[0];
                    }
                }
                if (this.tvPermissionItem.SelectedNode != null)
                {
                    // 让选中的节点可视，并用展开方式
                    this.tvPermissionItem.SelectedNode.Expand();
                    this.tvPermissionItem.SelectedNode.EnsureVisible();
                }
                this.CheckPemissionItem();
            }
            #endregion

            #region private void LoadPermissionTree() 加载树的主键
            /// <summary>
            /// 加载树的主键
            /// </summary>
            private void LoadPermissionTree()
            {
                // 开始更新控件，屏幕不刷新，提高效率。
                this.tvPermissionItem.BeginUpdate();
                this.tvPermissionItem.Nodes.Clear();
                TreeNode treeNode = new TreeNode();
                this.LoadTreePermissionItem(treeNode);
                // 更新控件，屏幕一次性刷新，提高效率。
                this.tvPermissionItem.EndUpdate();
            }
            #endregion

            #region private void LoadTreePermissionItem(TreeNode treeNode) 加载组织机构树的主键

            /// <summary>
            /// 加载组织机构树的主键
            /// </summary>
            /// <param name="treeNode">当前节点</param>
            private void LoadTreePermissionItem(TreeNode treeNode)
            {
                BaseInterfaceLogic.LoadTreeNodes(this.DTPermissionItem, BasePermissionItemEntity.FieldId, BasePermissionItemEntity.FieldParentId, BasePermissionItemEntity.FieldFullName, this.tvPermissionItem, treeNode, true, 1, BasePermissionItemEntity.FieldCode);
            }
            #endregion

            private void CheckPemissionItem()
            {
                // 如果是管理员拥有所有权限
                if (this.UserInfo.IsAdministrator)
                {
                    // 递归调用到所有的子节点 
                    for (int i = 0; i < this.tvPermissionItem.Nodes.Count; i++)
                    {
                        this.tvPermissionItem.Nodes[i].Checked = true;
                        BaseInterfaceLogic.CheckChild(this.tvPermissionItem.Nodes[i]);
                    }
                    return ;
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
            
        #endregion

        #region 显示数据集权限
        private void GetTableScope()
        {
            string resourceCategory = BaseUserEntity.TableName;
            string resourceId = this.TargetUserId;

            DataTable dataTableScope = DotNetService.Instance.TableColumnsService.GetConstraintDT(this.UserInfo, resourceCategory, resourceId);
            this.grdTable.AutoGenerateColumns = false;
            dataTableScope.DefaultView.Sort = BaseItemDetailsEntity.FieldSortCode;
            this.grdTable.DataSource = dataTableScope.DefaultView;
        }
        #endregion

        private void tvModule_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            // 窗体已经加载完毕
            if (this.FormLoaded)
            {
                e.Cancel = true;
            }
        }

        private void tvPermissionItem_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (this.FormLoaded)
            {
                e.Cancel = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 导出Excel
            //string exportFileName = this.Text + ".csv";
            string exportFileName = this.Text + ".xls";
            this.ExportExcel(this.grdRole , @"\Modules\Export\", exportFileName);
        }
    }
}