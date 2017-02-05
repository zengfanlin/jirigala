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
    /// FrmPermissionSelect.cs
    /// 模块管理-选择模块窗体
    ///		
    /// 修改记录
    /// 
    ///     2007.05.10 版本：1.0 JiRiGaLa  选择功能页面编写。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.10</date>
    /// </author> 
    /// </summary>
    public partial class FrmPermissionSelect : BaseForm
    {
        private DataTable DTPermission = new DataTable(BasePermissionItemEntity.TableName);  // 模块 DataTable

        private bool isUserClick = false;    // 是否是用户点击了复选框

        private string[] selectedIds = new string[0];            // 被选中的主键
        /// <summary>
        /// 被选中的主键
        /// </summary>
        public string[] SelectedIds
        {
            get
            {
                return this.selectedIds;
            }
            set
            {
                this.selectedIds = value;
            }
        }

        private bool allowNull = false;
        /// <summary>
        /// 是否允许选择空
        /// </summary>
        public bool AllowNull
        {
            get
            {
                return this.allowNull;
            }
            set
            {
                this.allowNull = value;
            }
        }

        private bool multiSelect = false;
        /// <summary>
        /// 是否允许多个选择
        /// </summary>
        public bool MultiSelect
        {
            get
            {
                return this.multiSelect;
            }
            set
            {
                this.multiSelect = value;
            }
        }

        private bool checkMove = false;
        /// <summary>
        /// 检查移动
        /// </summary>
        public bool CheckMove
        {
            get
            {
                return this.checkMove;
            }
            set
            {
                this.checkMove = value;
            }
        }

        private string byPermission = string.Empty;
        /// <summary>
        /// 按什么权限域获取组织列表
        /// </summary>
        public string ByPermission
        {
            get
            {
                return this.byPermission;
            }
            set
            {
                this.byPermission = value;
            }
        }

        private string selectedId = string.Empty;
        /// <summary>
        /// 被选中的权限主键
        /// </summary>
        public string SelectedId
        {
            get
            {
                return this.selectedId;
            }
            set
            {
                this.selectedId = value;
            }
        }

        private string selectedFullName = string.Empty;
        /// <summary>
        /// 被选中的权限全名
        /// </summary>
        public string SelectedFullName
        {
            get
            {
                return this.selectedFullName;
            }
            set
            {
                this.selectedFullName = value;
            }
        }

        private string openId = string.Empty;
        /// <summary>
        /// 打开节点
        /// </summary>
        public string OpenId
        {
            get
            {
                return this.openId;
            }
            set
            {
                this.openId = value;
            }
        }

        public delegate bool ButtonConfirmEventHandler();
        public event ButtonConfirmEventHandler OnButtonConfirmClick;

        private string currentEntityId = string.Empty;

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

        public FrmPermissionSelect()
        {
            InitializeComponent();
            // 加载系统信息
            // UserInfo = new BaseUserInfo(this.Name, this.Text);
        }

        public FrmPermissionSelect(string currentId) : this()
        {
            this.CurrentEntityId = currentId;
            this.OpenId     = currentId;
        }

        public FrmPermissionSelect(string currentId, string parentId) : this()
        {
            this.OpenId = currentId;
            this.CurrentEntityId = parentId;
        }

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.isUserClick = false;
            // 权限信息
            this.DTPermission = DotNetService.Instance.PermissionItemService.GetDataTable(UserInfo);
            this.DTPermission.DefaultView.Sort = BasePermissionItemEntity.FieldSortCode;
            // 有效性过滤
            BaseBusinessLogic.SetFilter(this.DTPermission, BasePermissionItemEntity.FieldEnabled, "1");
            this.DTPermission.AcceptChanges();
            // 加载树
            this.BindData(true);
            this.isUserClick = true;
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
                if (this.tvPermission.SelectedNode != null)
                {
                    // 让选中的节点可视，并用展开方式
                    this.tvPermission.SelectedNode.Expand();
                    this.tvPermission.SelectedNode.EnsureVisible();
                    // 防止只有一个父节点的情况下，无法展开情况发生
                    // this.GetPermissionList();
                }
            }
        }
        #endregion

        #region private void LoadTree() 加载树
        /// <summary>
        /// 加载模块树的主键
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvPermission.BeginUpdate();
            this.tvPermission.Nodes.Clear();
            TreeNode treeNode = new TreeNode();
            this.LoadTreePermission(treeNode);
            BaseInterfaceLogic.FindTreeNode(this.tvPermission, this.OpenId);
            if (BaseInterfaceLogic.TargetNode != null)
            {
                this.tvPermission.SelectedNode = BaseInterfaceLogic.TargetNode;
                BaseInterfaceLogic.ExpandTreeNode(this.tvPermission);
                this.tvPermission.SelectedNode.EnsureVisible();
                this.tvPermission.SelectedNode.Expand();
            }
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvPermission.EndUpdate();
        }
        #endregion

        #region private void LoadTreePermission(TreeNode treeNode)
        /// <summary>
        /// 加载模块树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreePermission(TreeNode treeNode)
        {
            BaseInterfaceLogic.LoadTreeNodes(this.DTPermission, BasePermissionItemEntity.FieldId, BasePermissionItemEntity.FieldParentId, BasePermissionItemEntity.FieldFullName, this.tvPermission, treeNode);
        }
        #endregion

        private void tvPermission_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (!this.isUserClick)
            {
                e.Cancel = true;
            }
        }

        private void tvPermission_AfterCheck(object sender, TreeViewEventArgs e)
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

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnSetNull.Visible = this.AllowNull;

            if (this.DTPermission.Rows.Count > 0)
            {
                if (this.MultiSelect)
                {
                    this.btnSelectAll.Visible = true;
                    this.btnInvertSelect.Visible = true;
                }
                else
                {
                    this.btnSelectAll.Visible = false;
                    this.btnInvertSelect.Visible = false;
                }
                this.btnConfirm.Enabled = true;
            }

            if (this.DTPermission.Rows.Count == 0)
            {
                this.btnConfirm.Enabled = false;
            }
            else
            {
                this.btnConfirm.Enabled = true;
            }

            this.tvPermission.CheckBoxes = this.MultiSelect;
        }
        #endregion

        private void tvPermission_DoubleClick(object sender, EventArgs e)
        {
            this.btnConfirm.PerformClick();
        }

        private void btnSetNull_Click(object sender, EventArgs e)
        {
            this.SelectedId = string.Empty;
            this.SelectedFullName = string.Empty;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>bool</returns>
        public override bool CheckInput()
        {
            bool returnValue = false;
            if (this.tvPermission.SelectedNode != null)
            {
                returnValue = true;
            }
            if (!returnValue)
            {
                MessageBox.Show(AppMessage.MSGC023, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return returnValue;
        }
        #endregion

        #region private bool CheckInputMove() 检查能否移动
        /// <summary>
        /// 检查能否移动
        /// </summary>
        /// <returns>能否移动到目标位置</returns>
        private bool CheckInputMove()
        {
            bool returnValue = true;
            // 单个移动检查
            BaseInterfaceLogic.FindTreeNode(this.tvPermission, this.OpenId);
            TreeNode treeNode = BaseInterfaceLogic.TargetNode;
            BaseInterfaceLogic.FindTreeNode(this.tvPermission, this.CurrentEntityId);
            TreeNode targetTreeNode = BaseInterfaceLogic.TargetNode;
            if (!BaseInterfaceLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode))
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0036, treeNode.Text, targetTreeNode.Text), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                returnValue = false;
            }
            return returnValue;
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

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            this.isUserClick = false;
            for (int i = 0; i < this.tvPermission.Nodes.Count; i++)
            {
                this.SetTreeNodesSelected(this.tvPermission.Nodes[i], true);
            }
            this.isUserClick = true;
        }

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

        private void btnTurnSelect_Click(object sender, EventArgs e)
        {
            this.SetTreeNodesTurnSelected(this.tvPermission.Nodes[0]);
        }

        private string SelecteTreeNodesId = string.Empty;   // 当前被选中的树节点主键列表
        private string SelecteTreeNodesFullName = string.Empty;   // 当前被选中的树节点名称列表

        #region private void GetSelecteTreeNodes(TreeNode treeNode) 递规获得树节点的选中状态
        /// <summary>
        /// 递规获得树节点的选中状态
        /// </summary>
        /// <param name="TreeNode">树节点</param>
        private void GetSelecteTreeNodes(TreeNode treeNode)
        {
            if ((treeNode!= null && treeNode.Tag != null && (treeNode.Tag as DataRow) != null))
            {
                if (treeNode.Checked)
                {
                    this.SelecteTreeNodesId += (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString() + ",";
                }
                for (int i = 0; i < treeNode.Nodes.Count; i++)
                {
                    // 这里进行递规操作
                    this.GetSelecteTreeNodes(treeNode.Nodes[i]);
                }
            }
        }
        #endregion

        private void EntityToArray(TreeNode treeNode)
        {
            if (treeNode.Tag != null)
            {
                if (treeNode.Checked)
                {
                    // 提高运行速度
                    string permissionItemId = (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                    this.SelecteTreeNodesId += permissionItemId + ",";
                }
            }
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.EntityToArray(treeNode.Nodes[i]);
            }
        }

        #region private string[] GetSelecteIds() 获得已被选择的部门主键数组
        /// <summary>
        /// 获得已被选择的部门主键数组
        /// </summary>
        /// <returns></returns>
        private string[] GetSelecteIds()
        {
            string[] ids = new string[0];
            // 分离Id
            if (this.SelecteTreeNodesId.Length > 1)
            {
                SelecteTreeNodesId = SelecteTreeNodesId.Substring(0, SelecteTreeNodesId.Length - 1);
                ids = SelecteTreeNodesId.Split(',');
            }
            return ids;
        }
        #endregion

        private bool GetMultiSelect()
        {
            // 当前选择的部门
            for (int i = 0; i < this.tvPermission.Nodes.Count; i++)
            {
                this.EntityToArray(this.tvPermission.Nodes[i]);
            }
            this.SelectedIds = this.GetSelecteIds();
            this.SelectedFullName = this.tvPermission.SelectedNode.Text;
            if (this.OnButtonConfirmClick != null)
            {
                if (!this.OnButtonConfirmClick())
                {
                    return false;
                }
            }
            return true;
        }

        private bool GetSingleSelect()
        {
            // 当前选择的权限
            this.SelectedId = (this.tvPermission.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
            this.SelectedFullName = this.tvPermission.SelectedNode.Text;
            // 检查移动的有效性
            if (this.CheckMove)
            {
                if (!this.CheckInputMove())
                {
                    return false;
                }
            }
            if (this.OnButtonConfirmClick != null)
            {
                if (!this.OnButtonConfirmClick())
                {
                    return false;
                }
            }
            return true;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                // 是否选择成功
                bool returnValue = false;
                if (this.MultiSelect)
                {
                    returnValue = this.GetMultiSelect();
                }
                returnValue = this.GetSingleSelect();
                if (returnValue)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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