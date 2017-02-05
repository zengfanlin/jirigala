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
    /// FrmOrganizeSelect.cs
    /// 部门管理-选择部门窗体
    ///		
    /// 修改记录
    ///     2011.10.19 版本：1.9 张广梁     修改LoadTreeOrganize，使展开相应的节点。
    ///     2011.09.07 版本：1.9 张广梁     修改选择部门时的错误，不往DTOrganize增加colSelected 列。
    ///     2009.09.28 版本：1.8 JiRiGaLa   部门的排序顺序显示优化。
    ///     2009.09.28 版本：1.8 JiRiGaLa   部门的排序顺序显示优化。
    ///     2007.06.05 版本：1.7 JiRiGaLa   整理主键。
    ///     2007.05.31 版本：1.6 JiRiGaLa   主键进行统一整理。
    ///     2007.05.30 版本：1.5 JiRiGaLa   删除移动的主键优化，提示信息优化，标准工程完成。
    ///     2007.05.30 版本：1.4 JiRiGaLa   整体整理主键。
    ///     2007.05.28 版本：1.3 JiRiGaLa   默认选中的节点，以及移动节点的有效性判断。
    ///     2007.05.17 版本：1.2 JiRiGaLa   增加了多国语言功能，调整了细节部分。
    ///     2007.05.13 版本：1.0 JiRiGaLa   部门选择功能页面编写。
    ///		
    /// 版本：1.6
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.31</date>
    /// </author> 
    /// </summary>
    public partial class FrmOrganizeSelect : BaseForm
    {
        private DataTable DTOrganize = new DataTable(BaseOrganizeEntity.TableName); // 组织机构
        
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
        public string PermissionItemScopeCode
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

        private string selectedFullName = string.Empty;
        /// <summary>
        /// 被选中的组织全名
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

        public event BaseBusinessLogic.CheckMoveEventHandler OnButtonConfirmClick;

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
        /// <summary>
        /// 通过本窗体调用另外窗体(gwb)
        /// </summary>
        private FrmOrganizeAdmin paf;

        public FrmOrganizeSelect(FrmOrganizeAdmin parent)
        {
            paf = parent;
        }

        public FrmOrganizeSelect()
        {
            InitializeComponent();           
        }

        public FrmOrganizeSelect(string currentId) : this()
        {
            this.CurrentEntityId = currentId;
            this.OpenId = currentId;
        }

        public FrmOrganizeSelect(string currentId, bool isInnerOrganize) : this(currentId)
        {
            this.chkInnerOrganize.Checked = isInnerOrganize;
        }

        public FrmOrganizeSelect(string currentId, string parentId) : this()
        {
            this.OpenId = currentId;
            this.CurrentEntityId = parentId;
        }

        #region private void Localization() 多语言国际化加载
        /// <summary>
        /// 多语言国际化加载
        /// </summary>
        private void Localization()
        {
            BaseInterfaceLogic.SetLanguageResource(this);
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.DTOrganize = this.GetOrganizeScope(this.PermissionItemScopeCode, this.chkInnerOrganize.Checked);
            // 只要有效的数据
            BaseBusinessLogic.SetFilter(this.DTOrganize, BaseOrganizeEntity.FieldEnabled, "1");
            this.DTOrganize.DefaultView.Sort = BaseOrganizeEntity.FieldSortCode;
            // 列表邦定
            this.grdOrganize.AutoGenerateColumns = false;
            this.grdOrganize.DataSource = this.DTOrganize.DefaultView;
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
                }
                if (this.tvOrganize.SelectedNode != null)
                {
                    // 让选中的节点可视，并用展开方式
                    this.tvOrganize.SelectedNode.Expand();
                    this.tvOrganize.SelectedNode.EnsureVisible();
                    // 防止只有一个父节点的情况下，无法展开情况发生
                    this.GetOrganizeList();
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
            BaseInterfaceLogic.FindTreeNode(this.tvOrganize, this.OpenId);
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
            if ((BaseSystemInfo.UsePermissionScope) && !UserInfo.IsAdministrator)
            {
                BaseInterfaceLogic.CheckTreeParentId(this.DTOrganize, BaseOrganizeEntity.FieldId, BaseOrganizeEntity.FieldParentId);
            }
            BaseInterfaceLogic.LoadTreeNodes(this.DTOrganize, BaseOrganizeEntity.FieldId, BaseOrganizeEntity.FieldParentId, BaseOrganizeEntity.FieldFullName, this.tvOrganize, treeNode);
        }
        #endregion

        private void chkInnerOrganize_CheckedChanged(object sender, EventArgs e)
        {
            this.OnLoad(e);
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnSetNull.Visible = this.AllowNull;
            if (this.DTOrganize.Rows.Count == 0)
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
            bool returnValue = false;
            if (this.tcOrganizeTree.SelectedIndex == 0)
            {
                if (this.tvOrganize.SelectedNode != null)
                {
                    returnValue = true;
                }
                if (!returnValue)
                {
                    MessageBox.Show(AppMessage.MSGC023, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (this.tcOrganizeTree.SelectedIndex == 1)
            {
                return BaseInterfaceLogic.CheckInputSelectOne(this.grdOrganize, "colSelected") ;
            }
            return returnValue;
        }
        #endregion

        #region private void GetSelecteId() 获得已被选择的权限主键
        /// <summary>
        /// 获得已被选择的权限主键数组
        /// </summary>
        private void GetSelectedId()
        {
            // 是否已有选中的
            DataRow dataRow = BaseInterfaceLogic.GetSelecteRow(this.grdOrganize, "colSelected");
            if (dataRow == null)
            {
                // 默认当前的行
                dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdOrganize);
            }
            if (dataRow != null)
            {
                this.SelectedId = dataRow[BaseOrganizeEntity.FieldId].ToString();
                this.SelectedFullName = dataRow[BaseOrganizeEntity.FieldFullName].ToString();
            }
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
            BaseInterfaceLogic.FindTreeNode(this.tvOrganize, this.OpenId);
            TreeNode treeNode = BaseInterfaceLogic.TargetNode;
            BaseInterfaceLogic.FindTreeNode(this.tvOrganize, this.CurrentEntityId);
            TreeNode targetTreeNode = BaseInterfaceLogic.TargetNode;
            if (!BaseInterfaceLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode))
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0036, treeNode.Text, targetTreeNode.Text), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                returnValue = false;
            }
            return returnValue;
        }
        #endregion

        /// <summary>
        /// 设置查询条件
        /// </summary>
        private void SetSearch()
        {
            string search = this.txtSearch.Text.Trim();
            if (String.IsNullOrEmpty(search))
            {
                // this.DTOrganizeList.DefaultView.RowFilter = string.Empty;
  
                this.grdOrganize.DataSource = this.DTOrganize.DefaultView;
                
            }
            else
            {
                search = StringUtil.GetSearchString(search);
                this.DTOrganize.DefaultView.RowFilter = BaseOrganizeEntity.FieldCode + " LIKE '" + search + "'"
                    + " OR " + BaseOrganizeEntity.FieldFullName + " LIKE '" + search + "'"
                    + " OR " + BaseOrganizeEntity.FieldDescription + " LIKE '" + search + "'";
                this.grdOrganize.DataSource = this.DTOrganize.DefaultView;
            }
            // 设置按钮状态
            this.SetControlState();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.SetSearch();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            this.FormLoaded = false;
            this.DTOrganize = null;
            // 点击了F5按钮
            ClientCache.Instance.DTOrganize = null;
            this.FormOnLoad();
            // 设置查询条件
            this.SetSearch();
            this.FormLoaded = true;
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }


        private void grdOrganize_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!multiSelect)
            {
                if (!this.MultiSelect)
                {
                    foreach (DataGridViewRow dgvRow in grdOrganize.Rows)
                    {
                        if (dgvRow.Cells["colSelected"].Value != null && (bool)dgvRow.Cells["colSelected"].Value)
                        {
                            dgvRow.Cells["colSelected"].Value = false;
                        }
                    }
                }
            }
        }

        private void grdOrganize_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdOrganize);
            if (dataRow != null)
            {
                this.SelectedId = dataRow[BaseOrganizeEntity.FieldId].ToString();
                this.SelectedFullName = dataRow[BaseOrganizeEntity.FieldFullName].ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        
        private void tvOrganize_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.FormLoaded)
            {
                if (this.tvOrganize.SelectedNode != null)
                {
                    this.GetOrganizeList();
                }
            }
        }

        private void tvOrganize_Click(object sender, EventArgs e)
        {
            /*
            这里这么写了，性能太低了一些，会有重复执行情况发生
            if (this.FormLoaded)
            {
                if (this.tvOrganize.SelectedNode != null)
                {
                    this.GetOrganizeList();
                }
            }
            */
        }

        #region private void GetOrganizeList() 获得子部门列表
        /// <summary>
        /// 获得子部门列表
        /// </summary>
        private void GetOrganizeList()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            // 动态加载树形结构
            if (this.tvOrganize.SelectedNode.Nodes.Count == 0)
            {
                DataTable DTOrganizeList = DotNetService.Instance.OrganizeService.GetDataTableByParent(UserInfo, (this.tvOrganize.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString());
                DTOrganizeList.DefaultView.Sort = BaseOrganizeEntity.FieldSortCode;
                foreach (DataRow dataRow in DTOrganizeList.Rows)
                {
                    TreeNode treeNode = new TreeNode();
                    treeNode.Text = dataRow[BaseOrganizeEntity.FieldFullName].ToString();
                    treeNode.Tag = dataRow[BaseOrganizeEntity.FieldId].ToString();
                    this.tvOrganize.SelectedNode.Nodes.Add(treeNode);
                }
                this.tvOrganize.SelectedNode.Expand();
                // 设置按钮状态
                this.SetControlState();
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }
        #endregion

        private void tvOrganize_DoubleClick(object sender, EventArgs e)
        {
            //if (!BaseSystemInfo.OrganizeDynamicLoading)
            //{
                this.btnConfirm.PerformClick();
            //}
        }

        private void btnSetNull_Click(object sender, EventArgs e)
        {
            this.SelectedId = null;
            this.SelectedFullName = null;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                // 当前选择的部门
                if (this.tcOrganizeTree.SelectedIndex == 0)
                {
                    this.SelectedId = (this.tvOrganize.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                    this.SelectedFullName = this.tvOrganize.SelectedNode.Text;
                }
                if (this.tcOrganizeTree.SelectedIndex == 1)
                {
                   this.GetSelectedId();
                }
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
                    if (this.OnButtonConfirmClick(this.SelectedId))
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
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

        private void tvOrganize_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvOrganize.GetNodeAt(e.X, e.Y) != null)
            {
                tvOrganize.SelectedNode = tvOrganize.GetNodeAt(e.X, e.Y);
            }
        }
    }
}