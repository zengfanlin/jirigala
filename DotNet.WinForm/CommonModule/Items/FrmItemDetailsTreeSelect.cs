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
    /// FrmItemDetailsTreeSelect
    /// 数型结构选择编码
    ///		
    /// 修改记录
    ///     
    ///     2008.04.03 版本：1.0 JiRiGaLa  创建主键。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.04.03</date>
    /// </author> 
    /// </summary>
    public partial class FrmItemDetailsTreeSelect : BaseForm
    {
        private DataTable DTItemDetails = new DataTable(BaseItemDetailsEntity.TableName); // 编码数据表

        /// <summary>
        /// 目标基础主键表
        /// </summary>
        public string TargetTableName = BaseItemDetailsEntity.TableName;

        public bool   AllowNull         = false;        // 是否允许空值
        public bool   CheckMove         = false;        // 是否检查移动
        public string OldItemDetailsId  = string.Empty; // 原先被选中的编码主键
        public string SelectedId        = string.Empty; // 被选中的编码主键
        public string SelectedFullName  = string.Empty; // 被选中的编码名称

        private string entityId = string.Empty;
        // 编码主键
        public string CurrentEntityId
        {
            get
            {
                if ((this.tvItemDetails.SelectedNode != null) && (this.tvItemDetails.SelectedNode.Tag != null))
                {
                    this.entityId = (this.tvItemDetails.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                }
                return this.entityId;
            }
            set
            {
                this.entityId = value;
            }
        }

        public FrmItemDetailsTreeSelect()
        {
            InitializeComponent();
        }

        #region public FrmItemDetailsTreeSelect(string id) 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">主键</param>
        public FrmItemDetailsTreeSelect(string id) : this()
        {
            this.CurrentEntityId = id;
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
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 若是在忙碌状态，退出本程序
            if (this.FormLoaded || this.Busyness)
            {
                return;
            }
            this.DTItemDetails = DotNetService.Instance.ItemDetailsService.GetDataTable(UserInfo, this.TargetTableName);
            // 绑定屏幕数据
            this.BindData(true);
            if (this.tvItemDetails.Nodes.Count > 0)
            {
                // this.tvItemDetails.SelectedNode = this.tvItemDetails.Nodes[0];
                this.tvItemDetails.Nodes[0].Expand();
            }
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnSetNull.Visible = this.AllowNull;
            if (this.DTItemDetails.Rows.Count == 0)
            {
                this.btnConfirm.Enabled = false;
            }
            else
            {
                this.btnConfirm.Enabled = true;
            }
        }
        #endregion

        #region private void LoadTree() 加载编码树的主键
        /// <summary>
        /// 加载编码树的主键
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvItemDetails.BeginUpdate();
            this.tvItemDetails.Nodes.Clear();
            TreeNode myTreeNode = new TreeNode();
            this.LoadTreeChildren(myTreeNode);
            myTreeNode.ImageIndex = 0;
            myTreeNode.SelectedImageIndex = 1;
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvItemDetails.EndUpdate();
        }
        #endregion

        #region private void LoadTreeChildren(TreeNode myTreeNode) 加载叶子
        /// <summary>
        /// 加载叶子
        /// </summary>
        /// <param name="myTreeNode">当前节点</param>
        private void LoadTreeChildren(TreeNode myTreeNode)
        {
            foreach (DataRow dataRow in this.DTItemDetails.Rows)
            {
                TreeNode myNewTreeNode = new TreeNode();
                myNewTreeNode.Text  = dataRow[BaseItemDetailsEntity.FieldItemName].ToString();
                myNewTreeNode.Tag   = dataRow[BaseItemDetailsEntity.FieldId].ToString();
                if ((myTreeNode.Tag == null) || ((myTreeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString().Length == 0))
                {
                    // 树的根节点加载
                    this.tvItemDetails.Nodes.Add(myNewTreeNode);
                }
                else
                {
                    // 节点的子节点加载
                    myTreeNode.Nodes.Add(myNewTreeNode);
                }
            }
        }
        #endregion

        #region private void GetChildrenList(TreeNode myParentTreeNode) 获得子节点用户
        /// <summary>
        /// 获得子节点用户
        /// </summary>
        /// <param name="myParentTreeNode">父节点</param>
        private void GetChildrenList(TreeNode myParentTreeNode)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            // 当前是空节点
            if (myParentTreeNode == null)
            {
                return;
            }
            this.DTItemDetails = DotNetService.Instance.ItemDetailsService.GetDataTable(UserInfo, this.TargetTableName);
            // 过滤数据
            BaseBusinessLogic.SetFilter(this.DTItemDetails, BaseItemDetailsEntity.FieldEnabled, "1");
            foreach (DataRow dataRow in this.DTItemDetails.Rows)
            {
                TreeNode myTreeNode = new TreeNode();
                myTreeNode.Text = dataRow[BaseItemDetailsEntity.FieldItemName].ToString();
                myTreeNode.Tag = dataRow[BaseItemDetailsEntity.FieldId].ToString();
                myTreeNode.ImageIndex = 0;
                myTreeNode.SelectedImageIndex = 1;
                myParentTreeNode.Nodes.Add(myTreeNode);
            }

            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }
        #endregion

        private void tvItemDetails_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.FormLoaded)
            {
                if (this.tvItemDetails.SelectedNode != null)
                {
                    if (this.tvItemDetails.SelectedNode.Tag != null)
                    {
                        if (this.tvItemDetails.SelectedNode.Nodes.Count == 0)
                        {
                            this.GetChildrenList(this.tvItemDetails.SelectedNode);
                        }
                    }
                }
            }
        }

        private void tvItemDetails_DoubleClick(object sender, EventArgs e)
        {
            this.btnConfirm.PerformClick();
        }

        private void btnSetNull_Click(object sender, EventArgs e)
        {
            this.SelectedId = null;
            this.SelectedFullName = null;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #region private bool CheckInputMove() 检查能否移动
        /// <summary>
        /// 检查能否移动
        /// </summary>
        /// <returns>能否移动到目标位置</returns>
        private bool CheckInputMove()
        {
            bool returnValue = true;
            // 单个移动检查
            BaseInterfaceLogic.FindTreeNode(this.tvItemDetails, this.OldItemDetailsId);
            TreeNode myTreeNode = BaseInterfaceLogic.TargetNode;
            BaseInterfaceLogic.FindTreeNode(this.tvItemDetails, this.CurrentEntityId);
            TreeNode targetTreeNode = BaseInterfaceLogic.TargetNode;
            // 原先的节点是否在这个已打开的树形结构上
            if (myTreeNode != null)
            {
                if (!BaseInterfaceLogic.TreeNodeCanMoveTo(myTreeNode, targetTreeNode))
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0036, myTreeNode.Text, targetTreeNode.Text), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    returnValue = false;
                }
            }
            return returnValue;
        }
        #endregion

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.tvItemDetails.SelectedNode == null)
            {
                MessageBox.Show(AppMessage.MSG0024, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.CheckMove)
            {
                if (!this.CheckInputMove())
                {
                    return;
                }
            }
            this.SelectedId = (this.tvItemDetails.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
            this.SelectedFullName = this.tvItemDetails.SelectedNode.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tvItemDetails_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvItemDetails.GetNodeAt(e.X, e.Y) != null)
            {
                tvItemDetails.SelectedNode = tvItemDetails.GetNodeAt(e.X, e.Y);
            }
        }
    }
}