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
    using DotNet.WinForm;

    /// <summary>
    /// FrmOrganizeRoleSelect.cs
    /// 角色管理-选择角色窗体
    ///		
    /// 修改记录
    /// 
    ///     2007.06.05 版本：1.7 JiRiGaLa  整理主键。
    ///     2007.05.31 版本：1.3 JiRiGaLa  主键进行统一整理。
    ///     2007.05.17 版本：1.2 JiRiGaLa  增加了多国语言功能，调整了细节部分。
    ///     2007.05.12 版本：1.0 JiRiGaLa  角色选择功能页面编写。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.12</date>
    /// </author> 
    /// </summary>
    public partial class FrmOrganizeRoleSelect : BaseForm // , IBaseSelectRoleForm
    {
        private DataTable DTOrganize = new DataTable(BaseOrganizeEntity.TableName); // 组织机构
        private DataTable DTRole = new DataTable(); // 角色数据表
        
        public string SelectedId        = string.Empty; // 被选中的角色主键
        public string SelectedFullName  = string.Empty; // 被选中的角色全名
        
        public bool AllowNull = true;

        /// <summary>
        /// 权限域编号
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";
        
        public delegate bool ButtonConfirmEventHandler();
        //public event ButtonConfirmEventHandler OnButtonConfirmClick;

        public FrmOrganizeRoleSelect()
        {
            InitializeComponent();
        }

        public FrmOrganizeRoleSelect(string parentId) : this()
        {
            this.ParentEntityId = parentId;
        }

        private string parentEntityId = string.Empty;

        /// <summary>
        /// 组织机构主键
        /// </summary>
        public string ParentEntityId
        {
            get
            {
                if ((this.tvOrganize.SelectedNode != null) && (this.tvOrganize.SelectedNode.Tag != null))
                {
                    this.parentEntityId = (this.tvOrganize.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                }
                return this.parentEntityId;
            }
            set
            {
                this.parentEntityId = value;
            }
        }

        /// <summary>
        /// 角色主键
        /// </summary>
        public override string EntityId
        {
            get
            {
                string entityId = string.Empty;
                if (this.tvOrganize.SelectedNode != null)
                {
                    entityId = (this.tvOrganize.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                }
                return entityId;
            }
        }

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
                    this.tvOrganize.SelectedNode = this.tvOrganize.Nodes[0];
                    if (String.IsNullOrEmpty(this.parentEntityId))
                    {
                        BaseInterfaceLogic.FindTreeNode(this.tvOrganize, this.parentEntityId);
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

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 获得组织机构数据
            this.DTOrganize = this.GetOrganizeScope(this.PermissionItemScopeCode, true);
            if (!UserInfo.IsAdministrator)
            {
                // 查找 ParentId 字段的值是否在 Id字段 里
                BaseInterfaceLogic.CheckTreeParentId(this.DTOrganize, BaseOrganizeEntity.FieldId, BaseOrganizeEntity.FieldParentId);
            }            
            // 加载树
            this.BindData(true);
            // 加载角色列表的主键
            this.GetRoleList();
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
            this.LoadTreeRole(treeNode);
            BaseInterfaceLogic.FindTreeNode(this.tvOrganize, this.ParentEntityId);
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

        #region private void LoadTreeRole(TreeNode treeNode)
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeRole(TreeNode treeNode)
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
            this.btnSetNull.Visible = this.AllowNull;
            if (this.DTRole.Rows.Count == 0)
            {
                this.btnConfirm.Enabled = false;
            }
            else
            {
                this.btnConfirm.Enabled = true;
            }
        }
        #endregion

        private void GetRoleList()
        {
            // 加载角色列表的主键
            this.DTRole = DotNetService.Instance.RoleService.GetDataTableByOrganize(UserInfo, this.ParentEntityId);
            this.grdRole.AutoGenerateColumns = false;
            this.DTRole.DefaultView.Sort = BaseStaffEntity.FieldSortCode;
            this.grdRole.DataSource = this.DTRole.DefaultView;
            // 设置按钮状态
            this.SetControlState();
        }

        private void tvOrganize_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.GetRoleList();
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

        private void grdRole_DoubleClick(object sender, EventArgs e)
        {
            this.btnConfirm.PerformClick();
        }

        private void grdRole_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnConfirm.PerformClick();
        }

        #region private void GetSelectedId() 获得已被选择的角色主键
        /// <summary>
        /// 获得已被选择的角色主键
        /// </summary>
        /// <returns></returns>
        private void GetSelectedId()
        {
            DataRow dataRow = BaseInterfaceLogic.GetSelecteRow(this.grdRole, "colSelected");
            // DataRowView dataRowView = (DataRowView)this.grdRole.BindingContext[this.grdRole.DataSource].Current;
            if (dataRow != null)
            {
                this.SelectedId = dataRow[BaseRoleEntity.FieldId].ToString();
                this.SelectedFullName = dataRow[BaseRoleEntity.FieldRealName].ToString();
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

        private void btnSetNull_Click(object sender, EventArgs e)
        {
            this.SelectedId = string.Empty;
            this.SelectedFullName = string.Empty;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdRole, "colSelected"))
            {
                this.GetSelectedId();
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