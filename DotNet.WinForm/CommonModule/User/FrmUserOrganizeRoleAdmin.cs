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
    /// FrmUserOrganizeRoleAdmin.cs
    /// 角色－员工管理窗体
    ///		
    /// 修改记录
    ///
    ///     2008.05.20 版本：1.1 JiRiGaLa 增加按权限域进行管理功能。
    ///     2007.05.28 版本：1.0 JiRiGaLa 员工-角色管理。
    ///		
    /// 版本：1.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.05.20</date>
    /// </author> 
    /// </summary> 
    public partial class FrmUserOrganizeRoleAdmin : BaseForm
    {
        private DataTable DTOrganize = new DataTable(BaseOrganizeEntity.TableName);     // 组织机构列表 DataTable
        private DataTable DTRole = new DataTable(BaseRoleEntity.TableName);     // 角色列表 DataTable

        /// <summary>
        /// 权限域编号
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        private string[] RoleIds = null;     // 员工角色主键数组
        
        // 员工主键
        private string TargetStaffId
        {
            set
            {
                this.ucStaffSelect.SelectedId = value;
            }
            get
            {
                return this.ucStaffSelect.SelectedId;
            }
        }

        // 员工名称     
        private string TargetStaffFullName
        {
            set
            {
                this.ucStaffSelect.SelectedFullName = value;
            }
            get
            {
                return this.ucStaffSelect.SelectedFullName;
            }
        }

        private bool isUserClick = true;    // 是否是用户点击了复选框

        public string OldEntityId      = string.Empty;                  // 原先被选中的节点主键
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
                   
        public FrmUserOrganizeRoleAdmin()
        {
            InitializeComponent();
        }

        public FrmUserOrganizeRoleAdmin(string currentId) : this()
        {
            this.CurrentEntityId = currentId;
            this.OldEntityId = currentId;
        }

        public FrmUserOrganizeRoleAdmin(string staffId, string staffFullName) : this()
        {
            this.TargetStaffId = staffId;
            this.TargetStaffFullName = staffFullName;
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.ucStaffSelect.AllowNull = false;
            this.ucStaffSelect.PermissionItemScopeCode = this.PermissionItemScopeCode;
            if (this.DTOrganize.Rows.Count == 0 || this.DTRole.Rows.Count == 0)
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
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAccess = this.IsModuleAuthorized("RoleAdmin");   // 访问权限
            this.permissionAdd = this.IsAuthorized("RoleAdmin.Add");      // 新增权限
            this.permissionEdit = this.IsAuthorized("RoleAdmin.Edit");     // 编辑权限
            this.permissionDelete = this.IsAuthorized("RoleAdmin.Delete");   // 删除权限
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.isUserClick = false;
            // 获取部门数据
            this.DTOrganize = this.GetOrganizeScope(this.PermissionItemScopeCode, true);
            if (!UserInfo.IsAdministrator)
            {
                // 查找 ParentId 字段的值是否在 ID字段 里
                BaseInterfaceLogic.CheckTreeParentId(this.DTOrganize, BaseOrganizeEntity.FieldId, BaseOrganizeEntity.FieldParentId);
            }
            BaseBusinessLogic.SetFilter(this.DTOrganize, BaseOrganizeEntity.FieldEnabled, "1");
            this.RoleIds = DotNetService.Instance.UserService.GetUserRoleIds(UserInfo, this.TargetStaffId);
            // 加载树
            this.BindData(true);
            this.isUserClick = true;
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
                dataRows = this.DTOrganize.Select(BaseOrganizeEntity.FieldParentId + " IS NULL OR " + BaseOrganizeEntity.FieldParentId + " = ''");
            }
            else
            {
                dataRows = this.DTOrganize.Select(BaseOrganizeEntity.FieldParentId + "='" + (treeNode.Tag as DataRow)[BaseOrganizeEntity.FieldId].ToString() + "'");
            }
            foreach (DataRow dataRow in dataRows)
            {
                // 判断不为空的当前节点的子节点
                if ((treeNode.Tag != null) && ((treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString().Length > 0) && (!(treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString().Equals(dataRow[BaseOrganizeEntity.FieldParentId].ToString())))
                {
                    continue;
                }
                // 当前节点的子节点, 加载根节点
                if ((dataRow.IsNull(BaseOrganizeEntity.FieldParentId) || (dataRow[BaseOrganizeEntity.FieldParentId].ToString().Length == 0) || (dataRow[BaseOrganizeEntity.FieldParentId].ToString().Equals(BaseSystemInfo.RootMenuCode)) || ((treeNode.Tag != null) && (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString().Equals(dataRow[BaseModuleEntity.FieldParentId].ToString()))))
                {
                    TreeNode newTreeNode = new TreeNode();
                    newTreeNode.Text = dataRow[BaseOrganizeEntity.FieldFullName].ToString();
                    newTreeNode.Tag = dataRow[BaseOrganizeEntity.FieldId].ToString();
                    DataRow[] childRows = this.DTRole.Select(BaseRoleEntity.FieldSystemId + "='" + (newTreeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString() + "'");
                    foreach (DataRow Row in childRows)
                    {
                        TreeNode roleNode = new TreeNode();
                        roleNode.Tag = Row[BaseRoleEntity.FieldId].ToString();
                        roleNode.Text = Row[BaseRoleEntity.FieldRealName].ToString();
                        roleNode.ImageIndex = 15;
                        roleNode.SelectedImageIndex = 15;
                        roleNode.Checked = true;
                        roleNode.Checked = (Row[BaseBusinessLogic.SelectedColumn].ToString() == "1");
                        newTreeNode.Nodes.Add(roleNode);
                    }

                    if ((treeNode.Tag == null) || ((treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString().Length == 0))
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

        private void ucStaffSelect_SelectedIndexChanged(string parentId)
        {
            this.FormOnLoad();
        }

        private void tvOrganize_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (this.isUserClick)
            {
                for (int i = 0; i < e.Node.Nodes.Count; i++)
                {
                    e.Node.Nodes[i].Checked = e.Node.Checked;
                }
            }
        }

        private void tvOrganize_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (!this.permissionEdit)
            {
                e.Cancel = true;
            }
        }

        private void tvOrganize_AfterSelect(object sender, TreeViewEventArgs e)
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

        private void EntityToDataTable(TreeNode treeNode)
        {
            if (treeNode.ImageIndex == 15)
            {
                // 提高运行速度
                DataRow[] dataRows = this.DTRole.Select(BaseRoleEntity.FieldId + "='" + (treeNode.Tag as DataRow)[BaseRoleEntity.FieldId].ToString() + "'");
                foreach (DataRow dataRow in dataRows)
                {
                    if (!dataRow["colSelected"].ToString().Equals(treeNode.Checked ? "1" : "0"))
                    {
                        dataRow["colSelected"] = treeNode.Checked ? 1 : 0;
                    }
                }
                // BUBaseBusinessLogic.SetProperty(this.DSOrganize.Tables[BUBaseUserRole.TableName], "RoleId", (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString(), "colSelected", TreeNode.Checked ? 1 : 0);
            }
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.EntityToDataTable(treeNode.Nodes[i]);
            }
        }

        #region private void BatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private void BatchSave()
        {
            for (int i = 0; i < this.tvOrganize.Nodes.Count; i++)
            {
                this.EntityToDataTable(this.tvOrganize.Nodes[i]);
            }

            // 去掉未修改的数据，提高运行速度
            for (int i = this.DTRole.Rows.Count - 1; i >= 0; i--)
            {
                if (this.DTRole.Rows[i].RowState == DataRowState.Unchanged)
                {
                    this.DTRole.Rows.RemoveAt(i);
                }
            }
            // DotNetService.Instance.StaffService.RoleBatchSave(UserInfo, this.DTUserRole, this.TargetStaffId);
            // 绑定屏幕数据
            // 设置按钮状态
            //this.SetControlState();
            if (BaseSystemInfo.ShowInformation)
            {
                // 批量保存，进行提示
                MessageBox.Show(AppMessage.MSG0012, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
                this.BatchSave();
                this.Close();
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
            // 关闭窗体
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