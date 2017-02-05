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
    /// FrmFolderSelect.cs
    /// 文件夹管理-选择文件夹窗体
    ///		
    /// 修改记录
    /// 
    ///     2007.05.29 版本：1.2 JiRiGaLa    默认选中的节点，以及移动节点的有效性判断。
    ///     2007.05.17 版本：1.1 JiRiGaLa    增加了多国语言功能，调整了细节部分。
    ///     2007.05.15 版本：1.0 JiRiGaLa    文件夹选择功能页面编写。
    ///		
    /// 版本：1.2
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.29</date>
    /// </author> 
    /// </summary>
    public partial class FrmFolderSelect : BaseForm
    {
        private DataTable DTFolder = new DataTable(BaseFolderEntity.TableName);  // 文件夹数据表
        public string OldEntityId       = string.Empty;          // 原先被选中的节点主键
        public string SelectedId        = string.Empty;          // 被选中的文件夹主键
        public string SelectedFullName  = string.Empty;          // 被选中的文件夹名称
        public bool   AllowNull         = true;                  // 是否允许空值

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

        public delegate bool ButtonConfirmEventHandler();
        public event ButtonConfirmEventHandler OnButtonConfirmClick;

        public FrmFolderSelect()
        {
            InitializeComponent();
        }

        public FrmFolderSelect(string currentId): this()
        {
            this.OldEntityId = currentId;
        }

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 权限信息
            this.DTFolder = DotNetService.Instance.FolderService.GetDataTable(UserInfo);
            this.DTFolder.DefaultView.Sort = BaseFolderEntity.FieldSortCode;
            // 加载文件夹树的主键
            this.LoadTree();
        }
        #endregion

        #region private void LoadTree() 加载文件夹树的主键
        /// <summary>
        /// 加载文件夹树的主键
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvFolder.BeginUpdate();
            this.tvFolder.Nodes.Clear();
            TreeNode treeNode = new TreeNode();
            this.LoadTreeFolder(treeNode);

            BaseInterfaceLogic.FindTreeNode(this.tvFolder, this.OldEntityId);
            if (BaseInterfaceLogic.TargetNode != null)
            {
                this.tvFolder.SelectedNode = BaseInterfaceLogic.TargetNode;
                BaseInterfaceLogic.ExpandTreeNode(this.tvFolder);
                this.tvFolder.SelectedNode.EnsureVisible();
                this.tvFolder.SelectedNode.Expand();
            }
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvFolder.EndUpdate();
        }
        #endregion

        #region private void LoadTreeFolder(TreeNode treeNode) 加载文件夹树的主键
        /// <summary>
        /// 加载文件夹树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeFolder(TreeNode treeNode)
        {
            BaseInterfaceLogic.LoadTreeNodes(this.DTFolder, BaseFolderEntity.FieldId, BaseFolderEntity.FieldParentId, BaseFolderEntity.FieldFolderName, this.tvFolder, treeNode);
        }
        #endregion

        /// <summary>
        /// 获取当前选择的路径
        /// </summary>
        /// <returns>路径</returns>
        private string GetPath()
        {
            string path = string.Empty;
            if (this.tvFolder.SelectedNode != null)
            {
                TreeNode treeNode = this.tvFolder.SelectedNode;
                path = treeNode.Text;
                while (treeNode.Parent != null)
                {
                    path = treeNode.Parent.Text + "\\" + path;
                    treeNode = treeNode.Parent;
                }
            }
            return path;
        }

        private void tvFolder_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.Text = "选择文件夹 " + "[" + this.GetPath() + "]";
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnSetNull.Visible = this.AllowNull;
            if (this.DTFolder.Rows.Count == 0)
            {
                this.btnConfirm.Enabled = false;
            }
            else
            {
                this.btnConfirm.Enabled = true;
            }
        }
        #endregion

        private void tvFolder_DoubleClick(object sender, EventArgs e)
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

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>bool</returns>
        public override bool CheckInput()
        {
            bool returnValue = false;
            if (this.tvFolder.SelectedNode != null)
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
            if (!String.IsNullOrEmpty(this.OldEntityId))
            {
                BaseInterfaceLogic.FindTreeNode(this.tvFolder, this.OldEntityId);
                TreeNode treeNode = BaseInterfaceLogic.TargetNode;
                TreeNode targetTreeNode = this.tvFolder.SelectedNode;
                if (treeNode != null)
                {
                    if (!BaseInterfaceLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode))
                    {
                        MessageBox.Show(AppMessage.Format(AppMessage.MSG0036, treeNode.Text, targetTreeNode.Text), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        returnValue = false;
                    }
                }
            }
            return returnValue;
        }
        #endregion

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!this.CheckInput())
            {
                return;
            }
            if (this.CheckMove)
            {
                if (!this.CheckInputMove())
                {
                    return;
                }
            }
            // 当前选择的文件夹
            this.SelectedId = (this.tvFolder.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
            this.SelectedFullName = this.tvFolder.SelectedNode.Text;
            // 要先确定好，已经选了哪个节点
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tvFolder_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvFolder.GetNodeAt(e.X, e.Y) != null)
            {
                tvFolder.SelectedNode = tvFolder.GetNodeAt(e.X, e.Y);
            }
        }
    }
}