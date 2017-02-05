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
    /// FrmFolderMultiSelect.cs
    /// 文件夹管理-选择文件夹窗体
    ///		
    /// 修改记录
    ///
    ///     2007.05.15 版本：1.0 JiRiGaLa  文件夹选择功能页面编写。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.15</date>
    /// </author> 
    /// </summary>
    public partial class FrmFolderMultiSelect : BaseForm
    {
        private DataTable DTFolder = new DataTable(BaseFolderEntity.TableName);  // 文件夹数据表

        //Pcsky 2012.05.02 未使用的功能，禁用
        //private bool isUserClick = true;    // 是否是用户点击了复选框

        public string[] SelecteIds = new string[0]; // 被选中的文件夹主键

        public FrmFolderMultiSelect()
        {
            InitializeComponent();
        }

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 加载文件夹树的主键
            this.LoadTree();
            this.tvFolder.ExpandAll();
        }
        #endregion

        #region private void LoadTree() 加载文件夹树的主键
        /// <summary>
        /// 加载文件夹树的主键
        /// </summary>
        private void LoadTree()
        {
            TreeNode treeNode = new TreeNode();
            this.LoadTreeFolder(treeNode);
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

        private void FrmFolderMultiSelect_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    // 加载窗体
                    this.FormOnLoad();
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
        }

        #region 设置按钮状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
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

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>bool</returns>
        public override bool CheckInput()
        {
            bool returnValue = true;
            this.SelecteTreeNodesID = string.Empty;
            // 递规获得树节点的选中状态
            this.GetSelecteTreeNodes(this.tvFolder.Nodes[0]);
            if (this.SelecteTreeNodesID.Length == 0)
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

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            //Pcsky 2012.05.02 未使用的功能，禁用
            //this.isUserClick = false;
            for (int i = 0; i < this.tvFolder.Nodes.Count; i++)
            {
                this.SetTreeNodesSelected(this.tvFolder.Nodes[i], true);
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
            this.SetTreeNodesTurnSelected(this.tvFolder.Nodes[0]);
        }

        private string SelecteTreeNodesID       = string.Empty;   // 当前被选中的树节点主键列表
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
                    this.SelecteTreeNodesID += (treeNode.Tag as DataRow)[BaseFolderEntity.FieldId].ToString() + ",";
                }
                for (int i = 0; i < treeNode.Nodes.Count; i++)
                {
                    // 这里进行递规操作
                    this.GetSelecteTreeNodes(treeNode.Nodes[i]);
                }
            }
        }
        #endregion

        #region private string[] GetSelecteIds() 获得已被选择的文件夹主键数组
        /// <summary>
        /// 获得已被选择的文件夹主键数组
        /// </summary>
        /// <returns></returns>
        private string[] GetSelecteIds()
        {
            //方便检查,暂时修改
            //return BaseInterfaceLogic.GetSelecteIds(this.DTFolder, BaseFolderEntity.FieldId, "colSelected");
            return new string[0];
        }
        #endregion

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                // 当前选择的文件夹
                this.SelecteIds = this.GetSelecteIds();
                this.DialogResult = DialogResult.OK;
                this.Close();  
            }
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