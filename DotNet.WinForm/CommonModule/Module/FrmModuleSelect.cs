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
    /// FrmModuleSelect.cs
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
    public partial class FrmModuleSelect : BaseForm
    {
        private DataTable DTModule = new DataTable(BaseModuleEntity.TableName);  // 模块 DataTable

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

        private bool allowSelect = true;
        /// <summary>
        /// 是否允许选择
        /// </summary>
        public bool AllowSelect
        {
            get
            {
                return this.allowSelect;
            }
            set
            {
                this.allowSelect = value;
                this.SetControlState();
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

        private string selectedId = string.Empty;
        /// <summary>
        /// 被选中的组织主键
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

        private string selectedCode = string.Empty;
        /// <summary>
        /// 被选中的编号
        /// </summary>
        public string SelectedCode
        {
            get
            {
                return this.selectedCode;
            }
            set
            {
                this.selectedCode = value;
            }
        }

        private string selectedFullName = string.Empty;
        /// <summary>
        /// 被选中的选项的全名
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

        public FrmModuleSelect()
        {
            InitializeComponent();
        }

        public FrmModuleSelect(string currentId) : this()
        {
            this.CurrentEntityId = currentId;
            this.OpenId = currentId;
        }

        public FrmModuleSelect(string currentId, string parentId) : this()
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
            // 权限信息
            this.DTModule = DotNetService.Instance.ModuleService.GetDataTable(UserInfo);
            // 有效性过滤
            BaseBusinessLogic.SetFilter(this.DTModule, BaseModuleEntity.FieldEnabled, "1");
            this.DTModule.AcceptChanges();
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
        /// 加载模块树的主键
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvModule.BeginUpdate();
            this.tvModule.Nodes.Clear();
            TreeNode treeNode = new TreeNode();
            this.LoadTreeModule(treeNode);
            BaseInterfaceLogic.FindTreeNode(this.tvModule, this.OpenId);
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
            this.btnSetNull.Visible = this.AllowNull;
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

        private void tvModule_DoubleClick(object sender, EventArgs e)
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
            if (this.tvModule.SelectedNode != null)
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
            BaseInterfaceLogic.FindTreeNode(this.tvModule, this.OpenId);
            TreeNode treeNode = BaseInterfaceLogic.TargetNode;
            BaseInterfaceLogic.FindTreeNode(this.tvModule, this.CurrentEntityId);
            TreeNode targetTreeNode = BaseInterfaceLogic.TargetNode;
            if (!BaseInterfaceLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode))
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0036, treeNode.Text, targetTreeNode.Text), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                returnValue = false;
            }
            return returnValue;
        }
        #endregion

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                // 当前选择的部门
                //this.SelectedId = {this.tvModule.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString()};
                this.SelectedId = ((DataRow)this.tvModule.SelectedNode.Tag)[BaseModuleEntity.FieldId].ToString();

                this.SelectedCode = BaseBusinessLogic.GetProperty(this.DTModule, this.SelectedId, BaseModuleEntity.FieldCode);
                this.SelectedFullName = this.tvModule.SelectedNode.Text;
                // 检查移动的有效性
                if (this.CheckMove)
                {
                    if (!this.CheckInputMove())
                    {
                        return;
                    }
                }
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

        private void tvModule_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvModule.GetNodeAt(e.X, e.Y) != null)
            {
                tvModule.SelectedNode = tvModule.GetNodeAt(e.X, e.Y);
            }
        }
    }
}