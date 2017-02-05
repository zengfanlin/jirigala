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
    /// FrmUserTreeResourcePermission.cs
    /// 权限设置-用户权限批量设置
    ///     2011.07.23 版本：1.2 张广梁    修改tvModule  tvPermissionItem节点选择时的逻辑错误		
    /// 修改记录
    ///     2011.07.17 版本：1.1 张广梁     优化tvTargetTreeResource 的选项选择自动选择parent node
    ///     2010.12.28 版本：1.0 JiRiGaLa  角色权限批量设置。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.12.28</date>
    /// </author> 
    /// </summary>
    public partial class FrmUserTreeResourcePermission : BaseForm
    {
        /// <summary>
        /// 权限域（范围权限、数据权限）
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        /// <summary>
        /// 用户管理
        /// </summary>
        private DataTable DTUser = new DataTable(BaseUserEntity.TableName);

        private string[] TargetResourceIds = null;

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
        /// 资源表
        /// </summary>
        DataTable DTTargetResource = new DataTable(BaseOrganizeEntity.TableName);

        public string TargetResourceCategory = BaseOrganizeEntity.TableName;
        public string TargetResourceSQL = "SELECT Id, parentId, FullName AS RealName, Description, SortCode FROM BaseOrganize WHERE DeletionStateCode = 0 AND Enabled = 1 ORDER BY SortCode";

        public string PermissionItemId = "";
        public string PermissionItemCode = "Resource.AccessPermission";
        public string PermissionItemName = "资源访问范围权限（系统默认）";

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

        /// <summary>
        /// 是否是用户点击了复选框
        /// </summary>
        private bool isUserClick = false;

        public FrmUserTreeResourcePermission()
        {
            InitializeComponent();
        }

        public FrmUserTreeResourcePermission(string permissionItemCode, string targetResourceCategory, string targetResourceSQL)
            : this()
        {
            this.PermissionItemCode = permissionItemCode;
            this.TargetResourceCategory = targetResourceCategory;
            this.TargetResourceSQL = targetResourceSQL;
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // 这里判断是否有数据被复制
            object clipboardData = Clipboard.GetData("userTreeResourcePermission");
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

            if (string.IsNullOrEmpty(this.PermissionItemId))
            {
                BasePermissionItemEntity permissionItemEntity = DotNetService.Instance.PermissionItemService.GetEntityByCode(this.UserInfo, this.PermissionItemCode);
                this.PermissionItemId = permissionItemEntity.Id.ToString();
                this.PermissionItemName = permissionItemEntity.FullName;
            }

            this.DTTargetResource = DotNetService.Instance.UserCenterDbHelperService.Fill(this.UserInfo, this.TargetResourceSQL);
            this.DTTargetResource.PrimaryKey = new DataColumn[] { this.DTTargetResource.Columns[this.FieldId] };
            BaseInterfaceLogic.CheckTreeParentId(this.DTTargetResource, this.FieldId, this.FieldParentId);

            this.LoadTree();

            // 获得用户列表
            this.GetUserList();

            this.isUserClick = true;

            // 2012.05.21 Pcsky
            // 组织机构需要展开第一层
            foreach (TreeNode treeNode in tvTargetTreeResource.Nodes)
            {
                if (treeNode.Level == 0)
                {
                    treeNode.Expand();
                }
            }
        }
        #endregion

        #region private void SetRowFilter() 设置数据过滤
        /// <summary>
        /// 设置数据过滤
        /// </summary>
        private void SetRowFilter()
        {
            string search = this.txtSearch.Text.Trim();

            if (search == "'")
            {
                search = string.Empty;
            }

            this.txtSearch.Text = this.txtSearch.Text.Replace("'", "");
            search = search.Replace("'", "");

            if (String.IsNullOrEmpty(search))
            {
                this.DTUser.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                if (this.DTUser.Columns.Count > 1)
                {
                    string rowFilter = string.Empty;
                    search = StringUtil.GetSearchString(search);
                    rowFilter = StringUtil.GetLike(BaseUserEntity.FieldUserName, search)
                         + " OR " + StringUtil.GetLike(BaseUserEntity.FieldRealName, search);
                    this.DTUser.DefaultView.RowFilter = rowFilter;
                }
            }
        }
        #endregion

        #region private void GetUserList() 获取用户列表
        /// <summary>
        /// 获取用户列表
        /// </summary>
        private void GetUserList()
        {
            // 是否启用了权限范围管理
            if (BaseSystemInfo.UsePermissionScope && !this.UserInfo.IsAdministrator)
            {
                this.DTUser = DotNetService.Instance.PermissionService.GetUserDTByPermissionScope(this.UserInfo, UserInfo.Id, this.PermissionItemScopeCode);
            }
            else
            {
                this.DTUser = DotNetService.Instance.UserService.GetDataTable(this.UserInfo);
            }

            // 对超级管理员不用设置权限
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
            this.tvTargetTreeResource.BeginUpdate();
            this.tvTargetTreeResource.Nodes.Clear();
            this.LoadTreePermissionItem();
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvTargetTreeResource.EndUpdate();
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
            BaseInterfaceLogic.LoadTreeNodes(this.DTTargetResource, this.FieldId, this.FieldParentId, this.FieldRealName, this.tvTargetTreeResource, treeNode);
        }
        #endregion

        private void GetCurrentPermission()
        {
            this.isUserClick = false;

            // 这些空间可以用了
            this.tvTargetTreeResource.Enabled = true;

            // 当前选中的角色被改变
            // 初始化权限设置页面
            this.ClearCheck();
            // 获取用户的权限
            this.GetUserPermission();
            this.isUserClick = true;

            this.btnClearPermission.Enabled = true;
            this.btnCopy.Enabled = true;
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
            // 获得用户的权限主键数组
            this.TargetResourceIds = DotNetService.Instance.PermissionService.GetPermissionScopeTargetIds(UserInfo, BaseUserEntity.TableName, this.TargetUserId, this.TargetResourceCategory, this.PermissionItemCode);
            if (this.TargetResourceIds != null && this.TargetResourceIds.Length > 0)
            {
                this.tvTargetTreeResource.BeginUpdate();
                this.LoadTreeResource();
                this.tvTargetTreeResource.EndUpdate();
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
            // 操作权限项被选中状态取消
            for (int i = 0; i < this.tvTargetTreeResource.Nodes.Count; i++)
            {
                this.ClearCheck(this.tvTargetTreeResource.Nodes[i]);
            }
        }

        private void LoadTreeResource()
        {
            // 递归调用到所有的子节点 
            for (int i = 0; i < this.tvTargetTreeResource.Nodes.Count; i++)
            {
                this.LoadTreeResource(this.tvTargetTreeResource.Nodes[i]);
            }
        }

        private void LoadTreeResource(TreeNode treeNode)
        {
            if ((treeNode!= null && treeNode.Tag != null && (treeNode.Tag as DataRow) != null))
            {
                string targetResourceId = (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                treeNode.Checked = Array.IndexOf(this.TargetResourceIds, targetResourceId) >= 0;
                for (int i = 0; i < treeNode.Nodes.Count; i++)
                {
                    // 这里进行递规操作
                    this.LoadTreeResource(treeNode.Nodes[i]);
                }
            }
        }

        private void tvTargetTreeResource_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            BaseInterfaceLogic.CheckChild(e.Node);
            BaseInterfaceLogic.CheckParent(e.Node);
        }

        private void tvTargetTreeResource_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (this.isUserClick)
            {
                if (e.Node.Checked)
                {
                    string[] grantResourceIds = new string[] { (e.Node.Tag as DataRow)[BaseModuleEntity.FieldId].ToString() };
                    DotNetService.Instance.PermissionService.GrantPermissionScopeTargets(this.UserInfo, BaseUserEntity.TableName, this.TargetUserId, this.TargetResourceCategory, grantResourceIds, this.PermissionItemId);
                }
                else
                {
                    string[] revokeResourceIds = new string[] { (e.Node.Tag as DataRow)[BaseModuleEntity.FieldId].ToString() };
                    DotNetService.Instance.PermissionService.RevokePermissionScopeTargets(this.UserInfo, BaseUserEntity.TableName, this.TargetUserId, this.TargetResourceCategory, revokeResourceIds, this.PermissionItemId);
                }
            }
        }

        private void btnClearPermission_Click(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DotNetService.Instance.PermissionService.ClearPermissionScopeTarget(this.UserInfo, BaseUserEntity.TableName, this.TargetUserId, this.TargetResourceCategory, this.PermissionItemId);
                // 重新刷新数据
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

        [Serializable]
        private class UserTreeResourcePermission
        {
            public string[] GrantResourceIds = null;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            UserTreeResourcePermission userTreeResourcePermission = new UserTreeResourcePermission();
            // 操作权限复制到剪切板
            string[] grantResourceIds = this.GetGrantResourceIds();
            userTreeResourcePermission.GrantResourceIds = grantResourceIds;

            Clipboard.SetData("userTreeResourcePermission", userTreeResourcePermission);
            this.btnPaste.Enabled = true;
        }

        /// <summary>
        /// 授权的操作权限
        /// </summary>
        private string GrantResources = string.Empty;

        private void ResourceEntityToArray(TreeNode treeNode)
        {
            if (treeNode.Tag != null)
            {
                // 提高运行速度
                string pesourceId = (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                if (treeNode.Checked)
                {
                    this.GrantResources += pesourceId + ";";
                }
            }
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.ResourceEntityToArray(treeNode.Nodes[i]);
            }
        }

        #region private string[] GetGrantResourceIds() 批量获取操作权限选中状态
        /// <summary>
        /// 批量获取操作权限选中状态
        /// </summary>
        private string[] GetGrantResourceIds()
        {
            for (int i = 0; i < this.tvTargetTreeResource.Nodes.Count; i++)
            {
                this.ResourceEntityToArray(this.tvTargetTreeResource.Nodes[i]);
            }
            string[] grantResourceIds = null;
            if (this.GrantResources.Length > 2)
            {
                this.GrantResources = this.GrantResources.Substring(0, this.GrantResources.Length - 1);
                grantResourceIds = this.GrantResources.Split(';');
            }
            this.GrantResources = string.Empty;
            return grantResourceIds;
        }
        #endregion

        private void btnPaste_Click(object sender, EventArgs e)
        {
            object clipboardData = Clipboard.GetData("userTreeResourcePermission");
            if (clipboardData != null)
            {
                UserTreeResourcePermission userTreeResourcePermission = (UserTreeResourcePermission)clipboardData;
                string[] grantResourceIds = userTreeResourcePermission.GrantResourceIds;

                // 添加权限范围
				if (grantResourceIds!=null)
				{
					if (grantResourceIds.Length > 0)
					{
						DotNetService.Instance.PermissionService.GrantPermissionScopeTargets(this.UserInfo, BaseUserEntity.TableName, this.TargetUserId, this.TargetResourceCategory, grantResourceIds, this.PermissionItemId);
					}
					// 加载窗体
					this.GetCurrentPermission();				
				}
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SetRowFilter();
        }

        
    }
}