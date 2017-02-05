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
    /// FrmOrganizeMultiSelect.cs
    /// 部门管理-选择部门窗体
    ///		
    /// 修改记录
    /// 
    ///     2007.06.06 版本：1.8 JiRiGaLa  改进CheckInput()方法。
    ///     2007.06.05 版本：1.7 JiRiGaLa  整理主键。
    ///     2007.06.01 版本：1.3 JiRiGaLa  主键进行统一整理。
    ///     2007.05.30 版本：1.2 JiRiGaLa  整体整理主键。
    ///     2007.05.17 版本：1.1 JiRiGaLa  增加了多国语言功能，调整了细节部分。
    ///     2007.05.13 版本：1.0 JiRiGaLa  部门选择功能页面编写。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.10</date>
    /// </author> 
    /// </summary>
    public partial class FrmOrganizeMultiSelect : BaseForm
    {
        private DataTable DTOrganize = new DataTable(BaseOrganizeEntity.TableName); // 组织机构 DataTable
        public string OldEntityId               = string.Empty;             // 原先被选中的节点主键
        public string[] SelectedIds = new string[0];            // 被选中的组织机构主键
        public string SelectedFullName = string.Empty;             // 被选中的组织机构名称

        public delegate bool ButtonConfirmEventHandler();
        public event ButtonConfirmEventHandler OnButtonConfirmClick;

        //Pcsky 2012.05.02 未使用的功能，禁用
        //private bool isUserClick = false;

        /// <summary>
        /// 权限域编号
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

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

        public FrmOrganizeMultiSelect()
        {
            InitializeComponent();
            // 加载系统信息
            // UserInfo = new BaseUserInfo(this.Name, this.Text);
        }

        public FrmOrganizeMultiSelect(string currentId) : this()
        {
            this.CurrentEntityId = currentId;
            this.OldEntityId = currentId;
        }

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 部门信息
            this.DTOrganize = this.GetOrganizeScope(this.PermissionItemScopeCode, true);
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
            BaseInterfaceLogic.FindTreeNode(this.tvOrganize, this.OldEntityId);
            if (BaseInterfaceLogic.TargetNode != null)
            {
                this.tvOrganize.SelectedNode = BaseInterfaceLogic.TargetNode;
                BaseInterfaceLogic.ExpandTreeNode(this.tvOrganize);
                this.tvOrganize.SelectedNode.EnsureVisible();
                this.tvOrganize.SelectedNode.Expand();
            }
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvOrganize.EndUpdate();
        }
        #endregion

        #region private void LoadTreeOrganize(TreeNode treeNode)
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeOrganize(TreeNode treeNode)
        {
            BaseInterfaceLogic.LoadTreeNodes(this.DTOrganize, BaseOrganizeEntity.FieldId, BaseOrganizeEntity.FieldParentId, BaseOrganizeEntity.FieldFullName, this.tvOrganize, treeNode);
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            if (this.DTOrganize.Rows.Count == 0)
            {
                this.btnSelectAll.Enabled = false;
                this.btnInvertSelect.Enabled = false;
                this.btnConfirm.Enabled = false;
            }
            else
            {
                this.btnSelectAll.Enabled = true;
                this.btnInvertSelect.Enabled = true;
                this.btnConfirm.Enabled = true;
            }
        }
        #endregion

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>bool</returns>
        public override bool CheckInput()
        {
            return BaseInterfaceLogic.CheckInputSelectAnyOne(this.DTOrganize, "colSelected");
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
            //Pcsky 2012.05.02 未使用的功能，禁用
            //this.isUserClick = false;
            for (int i = 0; i < this.tvOrganize.Nodes.Count; i++)
            {
                this.SetTreeNodesSelected(this.tvOrganize.Nodes[i], true);
            }
            //Pcsky 2012.05.02 未使用的功能，禁用
            //this.isUserClick = true;
        }

        private void tvOrganize_DoubleClick(object sender, EventArgs e)
        {
            this.btnConfirm.PerformClick();
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
            this.SetTreeNodesTurnSelected(this.tvOrganize.Nodes[0]);
        }

        private string SelecteTreeNodesId       = string.Empty;   // 当前被选中的树节点主键列表
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
                    this.SelecteTreeNodesId += (treeNode.Tag as DataRow)[BaseOrganizeEntity.FieldId].ToString() + ",";
                }
                for (int i = 0; i < treeNode.Nodes.Count; i++)
                {
                    // 这里进行递规操作
                    this.GetSelecteTreeNodes(treeNode.Nodes[i]);
                }
            }
        }
        #endregion

        #region private string[] GetSelecteIds() 获得已被选择的部门主键数组
        /// <summary>
        /// 获得已被选择的部门主键数组
        /// </summary>
        /// <returns></returns>
        private string[] GetSelecteIds()
        {
            string[] ids = new string[0];
            // 分离ID
            if (this.SelecteTreeNodesId.Length > 1)
            {
                SelecteTreeNodesId = SelecteTreeNodesId.Substring(0, SelecteTreeNodesId.Length - 1);
                ids = SelecteTreeNodesId.Split(',');
            }
            return ids;
        }
        #endregion

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                // 当前选择的部门
                this.SelectedIds = this.GetSelecteIds();
                this.SelectedFullName = this.tvOrganize.SelectedNode.Text;
                if (this.OnButtonConfirmClick != null)
                {
                    if (!this.OnButtonConfirmClick())
                    {
                        return;
                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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