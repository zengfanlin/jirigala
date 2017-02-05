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
    /// FrmCompanySelect.cs
    /// 部门管理-选择公司窗体
    ///		
    /// 修改记录
    ///     
    /// 　　2007.06.20 版本：1.0 JiRiGaLa 　选择公司编写
    ///     2007.05.13 版本：1.0 JiRiGaLa       建立窗体
    ///		
    /// 版本：1.6
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.06.20</date>
    /// </author> 
    /// </summary>
    public partial class FrmCompanySelect : BaseForm
    {
        private DataTable DTOrganize = new DataTable(BaseOrganizeEntity.TableName); // 组织机构 DataSet
        public string OldEntityId = string.Empty;                          // 原先被选中的节点主键
        public string SelecteId = string.Empty;                            // 被选中的组织机构主键
        public string SelecteFullName = string.Empty;                      // 被选中的组织机构名称

        /// <summary>
        /// 权限域编号
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

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
        
        public FrmCompanySelect()
        {
            InitializeComponent();
        }

        public FrmCompanySelect(string currentId) : this()
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
            // 权限信息
            this.DTOrganize = this.GetOrganizeScope(this.PermissionItemScopeCode, true);
            BaseBusinessLogic.SetFilter(this.DTOrganize, BaseOrganizeEntity.FieldCategory, "Company");
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
                this.btnConfirm.Enabled = false;
            }
            else
            {
                this.btnConfirm.Enabled = true;
            }
        }
        #endregion

        private void FormCompanySelect_DoubleClick(object sender, EventArgs e)
        {
            this.btnConfirm.PerformClick();
        }

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>bool</returns>
        public override bool CheckInput()
        {
            bool returnValue = false;
            if (this.tvOrganize.SelectedNode != null)
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

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                // 当前选择的部门
                this.SelecteId = (this.tvOrganize.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                this.SelecteFullName = this.tvOrganize.SelectedNode.Text;
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

        #region private void SetRowFilter() 设置数据过滤
        /// <summary>
        /// 设置数据过滤
        /// </summary>
        private void SetRowFilter()
        {
            string search = this.txtSearch.Text.Trim();
            if (String.IsNullOrEmpty(search))
            {
                this.DTOrganize.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                if (this.DTOrganize.Columns.Count > 1)
                {
                    string rowFilter = string.Empty;
                    search = StringUtil.GetSearchString(search);
                    rowFilter = StringUtil.GetLike(BaseOrganizeEntity.FieldCode, search)
                        + " OR " + StringUtil.GetLike(BaseOrganizeEntity.FieldDescription, search)
                        + " OR " + StringUtil.GetLike(BaseOrganizeEntity.FieldAddress, search)
                        + " OR " + StringUtil.GetLike(BaseOrganizeEntity.FieldBank, search)
                        + " OR " + StringUtil.GetLike(BaseOrganizeEntity.FieldBankAccount, search)
                        + " OR " + StringUtil.GetLike(BaseOrganizeEntity.FieldShortName, search);
                    this.DTOrganize.DefaultView.RowFilter = rowFilter;
                }
            }
        }
        #endregion

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.SetRowFilter();
            // 设置按钮状态
            this.SetControlState();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}