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
    /// FormRightMultiSelect.cs
    /// 模块管理-选择权限窗体
    ///		
    /// 修改记录
    /// 
    ///     2007.05.10 版本：1.0 JiRiGaLa  查选择功能页面编写。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.10</date>
    /// </author> 
    /// </summary>
    public partial class FrmModuleMultiSelect : BaseForm
    {
        private DataTable DTModule = new DataTable(BaseModuleEntity.TableName);  // 模块 DataTable

        public string OldEntityId = string.Empty;                       // 原先被选中的节点主键

        //Pcsky 2012.05.02 未使用的功能，禁用
        //private bool isUserClick = true;    // 是否是用户点击了复选框

        public delegate bool ButtonConfirmEventHandler();


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

        private string currentEntityId = string.Empty;
        /// <summary>
        /// 当前选中的节点，树上
        /// </summary>
        public string CurrentEntityId
        {
            get
            {
                if (this.tvModule.SelectedNode != null && this.tvModule.SelectedNode.Tag != null && (this.tvModule.SelectedNode.Tag as DataRow) != null)
                {
                    this.currentEntityId = (this.tvModule.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                }
                return this.currentEntityId;
            }
            set
            {
                this.currentEntityId = value;
            }
        }

        public FrmModuleMultiSelect()
        {
            InitializeComponent();
            // 加载系统信息
            // UserInfo = new BaseUserInfo(this.Name, this.Text);
        }

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 权限信息
            this.DTModule = DotNetService.Instance.ModuleService.GetDataTable(UserInfo);
            // 加载树
            this.LoadTree();
            this.BindData(true);
        }
        #endregion

        #region private void BindData(bool reloadTree) 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        /// <param name="reloadTree">重新加载模块树</param>
        private void BindData(bool reloadTree)
        {
            // 加载模块树的主键
            if (reloadTree)
            {
                this.LoadTree();
            }
            if (this.tvModule.SelectedNode == null)
            {
                if (this.tvModule.Nodes.Count > 0)
                {
                    if (this.CurrentEntityId.Length == 0)
                    {
                        this.tvModule.SelectedNode = this.tvModule.Nodes[0];
                    }
                    else
                    {
                        BaseInterfaceLogic.FindTreeNode(this.tvModule, this.CurrentEntityId);
                        if (BaseInterfaceLogic.TargetNode != null)
                        {
                            this.tvModule.SelectedNode = BaseInterfaceLogic.TargetNode;
                            // 展开当前选中节点的所有父节点
                            BaseInterfaceLogic.ExpandTreeNode(this.tvModule);
                        }
                    }
                    if (this.tvModule.SelectedNode != null)
                    {
                        // 让选中的节点可视，并用展开方式
                        this.tvModule.SelectedNode.Expand();
                        this.tvModule.SelectedNode.EnsureVisible();
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
            this.tvModule.BeginUpdate();
            this.tvModule.Nodes.Clear();
            TreeNode treeNode = new TreeNode();
            this.LoadTreeModule(treeNode);
            BaseInterfaceLogic.FindTreeNode(this.tvModule, this.OldEntityId);
            if (BaseInterfaceLogic.TargetNode != null)
            {
                this.tvModule.SelectedNode = BaseInterfaceLogic.TargetNode;
                BaseInterfaceLogic.ExpandTreeNode(this.tvModule);
                this.tvModule.SelectedNode.EnsureVisible();
                this.tvModule.SelectedNode.Expand();
            }
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvModule.EndUpdate();
        }
        #endregion

        #region private void LoadTreeModule(TreeNode treeNode)
        /// <summary>
        /// 加载模块树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeModule(TreeNode treeNode)
        {
            BaseInterfaceLogic.LoadTreeNodes(this.DTModule, BaseModuleEntity.FieldId, BaseModuleEntity.FieldParentId, BaseModuleEntity.FieldFullName, this.tvModule, treeNode);
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            if (this.DTModule.Rows.Count == 0)
            {
                this.btnConfirm.Enabled = false;
            }
            else
            {
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
            bool returnValue = true;
            this.SelecteTreeNodesId = string.Empty;
            // 递规获得树节点的选中状态
            this.GetSelecteTreeNodes(this.tvModule.Nodes[0]);
            if (this.SelecteTreeNodesId.Length == 0)
            {
                returnValue = false;
                MessageBox.Show(AppMessage.MSGC023, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            //Pcsky 2012.05.02 未使用的功能，禁用
            //this.isUserClick = false;
            for (int i = 0; i < this.tvModule.Nodes.Count; i++)
            {
                this.SetTreeNodesSelected(this.tvModule.Nodes[i], true);
            }

            //Pcsky 2012.05.02 未使用的功能，禁用
            //this.isUserClick = true;
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

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.tvModule.Nodes.Count; i++)
            {
                this.SetTreeNodesTurnSelected(this.tvModule.Nodes[i]);
            }
        }

        private string SelecteTreeNodesId = string.Empty;   // 当前被选中的树节点主键列表

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

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                // 当前选择的主键
                this.SelectedIds = this.GetSelecteIds();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tvModule_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvModule.GetNodeAt(e.X, e.Y) != null)
            {
                tvModule.SelectedNode = tvModule.GetNodeAt(e.X, e.Y);
            }
        }
    }
}