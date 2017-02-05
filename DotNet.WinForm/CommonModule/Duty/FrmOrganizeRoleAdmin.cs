//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;
    using DotNet.WinForm;

    /// <summary>
    /// FrmOrganizeRoleAdmin.cs
    /// 岗位管理-岗位管理窗体
    ///	
    /// 修改记录
    /// 
    ///     2007.06.14 版本：1.8 JiRiGaLa  增加权限判断主键。
    ///     2007.06.05 版本：1.7 JiRiGaLa  整理主键。
    ///     2007.05.31 版本：1.6 JiRiGaLa  主键进行统一整理。
    ///     2007.05.30 版本：1.5 JiRiGaLa  SingleDelete() 进行优化。
    ///     2007.05.30 版本：1.4 JiRiGaLa  删除移动的主键优化，提示信息优化，标准工程完成。
    ///     2007.05.29 版本：1.3 JiRiGaLa  整体整理主键。
    ///     2007.05.17 版本：1.2 JiRiGaLa  增加了多国语言功能，调整了细节部分。
    ///     2007.05.15 版本：1.1 JiRiGaLa  整体进行调试改进。
    ///     2007.05.12 版本：1.0 JiRiGaLa  岗位管理功能页面编写。
    ///	
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.12</date>
    /// </author> 
    /// </summary>
    public partial class FrmOrganizeRoleAdmin : BaseForm, IBaseForm
    {
        private DataTable DTRoleList = new DataTable(BaseRoleEntity.TableName);   // 岗位 DataTable
        private DataTable DTOrganize = new DataTable(BaseOrganizeEntity.TableName); // 组织机构 DataTable

        private System.Windows.Forms.Control LastControl  = null;  // 记录最后点击的控件
        
        public event SetControlStateEventHandler OnButtonStateChange;

        /// <summary>
        /// 权限域编号
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        private string parentEntityId = string.Empty;

        /// <summary>
        /// 导航栏机构主键
        /// </summary>
        public string ParentEntityId
        {
            get
            {
                if ((this.tvOrganize.SelectedNode != null) && (this.tvOrganize.SelectedNode.Tag != null))
                {
                    this.parentEntityId = (this.tvOrganize.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                }
                else
                {
                    this.parentEntityId = string.Empty;
                }
                return this.parentEntityId;
            }
            set
            {
                this.parentEntityId = value;
            }
        }

        /// <summary>
        /// 表格中的岗位主键
        /// </summary>
        public override string EntityId
        {
            get
            {
                return BaseInterfaceLogic.GetDataGridViewEntityId(this.grdRole, BaseRoleEntity.FieldId);
            }
        }

        /// <summary>
        /// 当前选中的节点，树或者表格上
        /// </summary>
        public string CurrentEntityId
        {
            get
            {
                string entityId = string.Empty;
                if (this.LastControl == this.tvOrganize)
                {
                    entityId = this.parentEntityId;
                }
                else
                {
                    entityId = this.EntityId;
                }
                return entityId;
            }
        }

        public FrmOrganizeRoleAdmin()
        {
            InitializeComponent();
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.SetSortButton(false);
            this.btnAdd.Enabled             = false;
            this.btnEdit.Enabled            = false;
            this.btnMove.Enabled            = false;
            this.btnBatchDelete.Enabled     = false;
            this.btnRolePermission.Enabled = false;
            this.btnRoleUser.Enabled       = false;
            this.btnBatchSave.Enabled       = false;

            this.btnSelectAll.Enabled = false;
            this.btnInvertSelect.Enabled = false;

            // 检查添加组织机构
            this.btnAdd.Enabled = this.permissionAdd;
            if ((this.DTRoleList.DefaultView.Count >= 1))
            {
                this.btnEdit.Enabled            = this.permissionEdit;
                this.btnMove.Enabled            = this.permissionEdit;
                this.btnBatchDelete.Enabled     = this.permissionDelete;
                this.btnRolePermission.Enabled = this.permissionEdit;
                this.btnRoleUser.Enabled       = this.permissionEdit;
                this.btnBatchSave.Enabled       = this.permissionEdit;
            }
            // 位置顺序改变按钮部分
            if (this.DTRoleList.DefaultView.Count > 1)
            {
                this.SetSortButton(this.permissionEdit);
            }
            // 右手弹出菜单
            this.mItmAdd.Enabled         = this.permissionAdd;
            this.mItmEdit.Enabled        = this.permissionEdit;
            this.mItmMove.Enabled        = this.permissionEdit;
            this.mItmDelete.Enabled      = this.permissionDelete;
            this.mItmAddOrganize.Enabled = this.permissionAdd;
            this.mItmAddStaff.Enabled    = this.permissionAdd;

            if (!this.permissionEdit)
            {
                // 只读属性设置
                this.grdRole.Columns["colSelected"].ReadOnly = !this.permissionEdit;
                this.grdRole.Columns["colFullName"].ReadOnly = !this.permissionEdit;
                this.grdRole.Columns["colDescription"].ReadOnly = !this.permissionEdit;
                // 修改背景颜色
                this.grdRole.Columns["colFullName"].DefaultCellStyle.BackColor = Color.White;
                this.grdRole.Columns["colDescription"].DefaultCellStyle.BackColor = Color.White;
            }

            // 检查委托是否为空
            if (OnButtonStateChange != null)
            {
                bool setTop = this.ucTableSort.SetTopEnabled;
                bool setUp = this.ucTableSort.SetUpEnabled;
                bool setDown = this.ucTableSort.SetDownEnabled;
                bool setBottom = this.ucTableSort.SetBottomEnabled;
                bool add = this.btnAdd.Enabled;
                bool edit = this.btnEdit.Enabled;
                bool batchDelete = this.btnBatchDelete.Enabled;
                bool batchSave = this.btnBatchSave.Enabled;
                OnButtonStateChange(setTop, setUp, setDown, setBottom, add, edit, batchDelete, batchSave);
            }
            //检查有没有可导出数据
            this.btnExport.Enabled = (this.grdRole .RowCount > 0);

            if ((this.grdRole.RowCount >= 1))
            {
                this.btnSelectAll.Enabled = this.permissionEdit || this.permissionDelete;
                this.btnInvertSelect.Enabled = this.permissionEdit || this.permissionDelete;
            }
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAccess = this.IsModuleAuthorized("RoleAdmin");   // 访问权限
            this.permissionAdd = this.IsAuthorized("RoleAdmin.Add");      // 新增权限
            this.permissionEdit = this.IsAuthorized("RoleAdmin.Edit");     // 编辑权限
            this.permissionDelete = this.IsAuthorized("RoleAdmin.Delete");   // 删除权限
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
                    if (this.parentEntityId.Length == 0)
                    {
                        this.tvOrganize.SelectedNode = this.tvOrganize.Nodes[0];
                    }
                    else
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
            if (reloadTree)
            {
                this.GetRoleList();
            }
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdRole);
            // 获取部门数据
            this.DTOrganize = this.GetOrganizeScope(this.PermissionItemScopeCode, true);
            this.DTOrganize.AcceptChanges();
            // 加载树
            this.BindData(true);
            // 加载这些完毕了，再加载相应的员工 
            this.DTRoleList = DotNetService.Instance.RoleService.GetDataTableByOrganize(UserInfo, this.ParentEntityId);
        }
        #endregion

        #region private void GetRoleList() 获取岗位列表
        /// <summary>
        /// 获取岗位列表
        /// </summary>
        private void GetRoleList()
        {
            this.DTRoleList = DotNetService.Instance.RoleService.GetDataTableByOrganize(UserInfo, this.ParentEntityId);
            this.grdRole.AutoGenerateColumns = false;
            this.DTRoleList.DefaultView.Sort = BaseRoleEntity.FieldSortCode;
            this.grdRole.DataSource = this.DTRoleList.DefaultView;
            // 设置排序按钮
            this.ucTableSort.DataBind(this.grdRole, this.permissionEdit);
            // 绑定数据
            this.SetControlState();
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

        /// <summary>
        /// 设置查询条件
        /// </summary>
        private void SetSearch()
        {
            this.grdRole.AutoGenerateColumns = false;
            string search = this.txtSearch.Text.Trim();
            if (String.IsNullOrEmpty(search))
            {
                this.DTRoleList.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                search = StringUtil.GetSearchString(search);
                this.DTRoleList.DefaultView.RowFilter =

                    /*BaseRoleEntity.FieldRealName + " LIKE '" + search + "'"
                    + " OR " + BaseRoleEntity.FieldDescription + " LIKE '" + search + "'";*/

                    StringUtil.GetLike(BaseRoleEntity.FieldRealName, search)
                        + " OR " + StringUtil.GetLike(BaseRoleEntity.FieldDescription, search);

                this.grdRole.DataSource = this.DTRoleList.DefaultView;
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
            this.txtSearch.Text = this.txtSearch.Text.TrimEnd();
            if (this.txtSearch.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG0212), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtSearch.Focus();
                return;
            }
            this.DTRoleList = DotNetService.Instance.RoleService.Search(UserInfo, this.ParentEntityId, this.txtSearch.Text);
            this.grdRole.DataSource = this.DTRoleList.DefaultView;
            // 设置按钮状态
            this.SetControlState();
        }

        private void tvOrganize_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (this.permissionEdit)
            {
                // 开始进行拖放操作，并将拖放的效果设置成移动。
                this.DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void tvOrganize_DragDrop(object sender, DragEventArgs e)
        {
            // 定义一个中间变量
            TreeNode treeNode;
            //判断拖动的是否为TreeNode类型，不是的话不予处理
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                //定义一个位置点的变量，保存当前光标所处的坐标点
                Point point;
                //拖放的目标节点
                TreeNode targetTreeNode;
                //获取当前光标所处的坐标
                point = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                //根据坐标点取得处于坐标点位置的节点
                targetTreeNode = ((TreeView)sender).GetNodeAt(point);
                //获取被拖动的节点
                treeNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                //判断拖动的节点与目标节点是否是同一个,同一个不予处理
                if (BaseInterfaceLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode))
                {
                    if (BaseSystemInfo.ShowInformation)
                    {
                        // 是否移动部门
                        if (MessageBox.Show(AppMessage.Format(AppMessage.MSG0038, treeNode.Text, targetTreeNode.Text), AppMessage.MSG0000, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    DotNetService.Instance.OrganizeService.MoveTo(UserInfo, (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString(), (targetTreeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString());
                    // 往目标节点中加入被拖动节点的一份克隆
                    targetTreeNode.Nodes.Add((TreeNode)treeNode.Clone());
                    // 将被拖动的节点移除
                    treeNode.Remove();
                }
            }
        }

        private void tvOrganize_DragEnter(object sender, DragEventArgs e)
        {
            // 拖动效果设成移动
            e.Effect = DragDropEffects.Move;
        }

        private void tvOrganize_Click(object sender, EventArgs e)
        {
            this.LastControl = this.tvOrganize;
            if (this.tvOrganize.SelectedNode == null)
            {
                this.tvOrganize.ContextMenuStrip = null;
            }
            else
            {
                this.tvOrganize.ContextMenuStrip = this.cMnuRole;
            }
        }

        private void tvOrganize_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.FormLoaded)
            {
                if (this.ParentEntityId.Length > 0)
                {
                    this.GetRoleList();
                }
            }
        }

        private void grdRole_Click(object sender, EventArgs e)
        {
            this.LastControl = this.grdRole;
        }

        private void grdRole_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // 判断是否有删除权限
            //if (!this.permissionDelete)
            //{
            //    e.Cancel = true;
            //    return;
            //}
            //else
            //{
            //    if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            //    {
            //        e.Cancel = true;
            //    }
            //    else
            //    {
            //        RoleAdminService.Instance.Delete(UserInfo, this.EntityId);
            //    }
            //}
        }

        private void grdRole_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnRoleUser.PerformClick();
        }

        private void mItmAdd_Click(object sender, EventArgs e)
        {
            this.btnAdd.PerformClick();
        }

        private void mItmEdit_Click(object sender, EventArgs e)
        {
            if (this.tvOrganize.SelectedNode != null)
            {
                // 用反射获得窗体
                string assemblyName = "DotNet.WinForm";
                string formName = "FrmOrganizeEdit";
                Type type = CacheManager.Instance.GetType(assemblyName, formName);
                Form frmOrganizeEdit = (Form)Activator.CreateInstance(type, (this.tvOrganize.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString());
                // Form frmOrganizeEdit = AssemblyManager.Instance.GetForm(assemblyName, formName);
                // ((IBaseOrganizeEditForm)frmOrganizeEdit).EntityID = (this.tvOrganize.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                if (frmOrganizeEdit.ShowDialog() == DialogResult.OK)
                {
                    this.FormLoaded = false;
                    this.FormOnLoad();
                    this.FormLoaded = true;
                }
            }
        }

        private void mItmMove_Click(object sender, EventArgs e)
        {
            if (this.tvOrganize.SelectedNode != null)
            {
                this.SingleMove(this.CurrentEntityId);
            }
        }

        private void mItmDelete_Click(object sender, EventArgs e)
        {
            if (this.LastControl == this.tvOrganize)
            {
                if (!BaseInterfaceLogic.NodeAllowDelete(this.tvOrganize.SelectedNode))
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0035, this.tvOrganize.SelectedNode.Text), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        // this.SingleDelete();
                    }
                }
            }
        }

        private void mItmAddStaff_Click(object sender, EventArgs e)
        {
            string returnValue = string.Empty;
            string companyId = string.Empty;
            string subCompanyId = string.Empty;
            string departmentId = string.Empty;
            string workgroupId = string.Empty;

            TreeNode treeNode = this.tvOrganize.SelectedNode;
            while (treeNode != null)
            {
                string id = string.Empty;
                if (treeNode.Tag is DataRow)
                {
                    id = (treeNode.Tag as DataRow)[BaseOrganizeEntity.FieldId].ToString();
                }
                else
                {
                    id = treeNode.Tag.ToString();
                }
                if (BaseBusinessLogic.GetProperty(this.DTOrganize, id, BaseOrganizeEntity.FieldCategory).ToUpper() == "Company".ToUpper())
                {
                    if (string.IsNullOrEmpty(companyId))
                    {
                        companyId = id;
                    }
                }
                else if (BaseBusinessLogic.GetProperty(this.DTOrganize, id, BaseOrganizeEntity.FieldCategory).ToUpper() == "SubCompany".ToUpper())
                {
                    if (string.IsNullOrEmpty(subCompanyId))
                    {
                        subCompanyId = id;
                    }
                }
                else if (BaseBusinessLogic.GetProperty(this.DTOrganize, id, BaseOrganizeEntity.FieldCategory).ToUpper() == "Department".ToUpper())
                {
                    if (string.IsNullOrEmpty(departmentId))
                    {
                        departmentId = id;
                    }
                }
                else if (BaseBusinessLogic.GetProperty(this.DTOrganize, id, BaseOrganizeEntity.FieldCategory).ToUpper() == "WorkGroup".ToUpper())
                {
                    if (string.IsNullOrEmpty(workgroupId))
                    {
                        workgroupId = id;
                    }
                }
                treeNode = treeNode.Parent;
            }
            FrmStaffAdd frmStaffAdd = new FrmStaffAdd(companyId, subCompanyId, departmentId, workgroupId);
            if (frmStaffAdd.ShowDialog(this) == DialogResult.OK)
            {
                returnValue = frmStaffAdd.EntityId;
            }
        }

        private void mItmFrmUserModuleOperationReport_Click(object sender, EventArgs e)
        {
            if (this.tvOrganize.SelectedNode != null)
            {
                // FrmUserModuleOperationReport FrmUserModuleOperationReport = new FrmUserModuleOperationReport((this.tvOrganize.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString(), this.tvOrganize.SelectedNode.Text);
                // FrmUserModuleOperationReport.ShowDialog(this);
            }
        }

        private void mItmAddOrganize_Click(object sender, EventArgs e)
        {
            // 用反射获得窗体
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmOrganizeAdd";
            Form frmOrganizeAdd = CacheManager.Instance.GetForm(assemblyName, formName);
            if (this.tvOrganize.SelectedNode != null)
            {
                ((FrmOrganizeAdd)frmOrganizeAdd).ParentId = (this.tvOrganize.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
            }
            if (frmOrganizeAdd.ShowDialog() == DialogResult.OK)
            {
                this.FormLoaded = false;
                this.FormOnLoad();
                this.FormLoaded = true;
            }
        }

        /// <summary>
        /// 置顶
        /// </summary>
        public int SetTop()
        {
            return this.ucTableSort.SetTop();
        }

        /// <summary>
        /// 上移
        /// </summary>
        public int SetUp()
        {
            return this.ucTableSort.SetUp();
        }

        /// <summary>
        /// 下移
        /// </summary>
        public int SetDown()
        {
            return this.ucTableSort.SetDown();
        }

        /// <summary>
        /// 置底
        /// </summary>
        public int SetBottom()
        {
            return this.ucTableSort.SetBottom();
        }

        public void SetSortButton(bool enabled)
        {
            this.ucTableSort.SetSortButton(enabled);
        }

        #region private string[] GetSelecteIds() 获得已被选择的部门主键数组
        /// <summary>
        /// 获得已被选择的部门主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelecteIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdRole, BaseRoleEntity.FieldId, "colSelected", true);
        }
        #endregion

        private void grdRole_Sorted(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (this.permissionEdit)
            {
                string[] sequence = DotNetService.Instance.SequenceService.GetBatchSequence(UserInfo, BaseRoleEntity.TableName, this.DTRoleList.DefaultView.Count);
                int i = 0;
                foreach (DataRowView dataRowView in this.DTRoleList.DefaultView)
                {
                    dataRowView.Row[BaseRoleEntity.FieldSortCode] = sequence[i];
                    i++;
                }
                // 控制导航按钮
                this.SetSortButton(false);
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }

        #region public string Add() 添加岗位
        /// <summary>
        /// 添加岗位
        /// </summary>
        /// <returns>主键</returns>
        public string Add()
        {
            string returnValue = string.Empty;
            FrmOrganizeRoleAdd frmOrganizeRoleAdd;
            if (this.parentEntityId.Length == 0)
            {
                frmOrganizeRoleAdd = new FrmOrganizeRoleAdd();
            }
            else
            {
                frmOrganizeRoleAdd = new FrmOrganizeRoleAdd(this.parentEntityId, this.tvOrganize.SelectedNode.Text);
            }
            if (frmOrganizeRoleAdd.ShowDialog(this) == DialogResult.OK)
            {
                returnValue = frmOrganizeRoleAdd.EntityId;
                // 获得岗位列表
                this.GetRoleList();
            }
            return returnValue;
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Add();
        }

        public void Edit()
        {
            string id = BaseInterfaceLogic.GetDataGridViewEntityId(this.grdRole, BaseRoleEntity.FieldId);
            FrmOrganizeRoleEdit FrmOrganizeRoleEdit = new FrmOrganizeRoleEdit(id);
            if (FrmOrganizeRoleEdit.ShowDialog(this) == DialogResult.OK)
            {
                // 获得岗位列表
                this.GetRoleList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Edit();
        }

        #region private bool CheckInputMove() 检查能否移动
        /// <summary>
        /// 检查能否移动
        /// </summary>
        /// <returns>能否移动到目标位置</returns>
        private bool CheckInputMove(string selectedId)
        {
            bool returnValue = true;
            // 单个移动检查
            BaseInterfaceLogic.FindTreeNode(this.tvOrganize, this.parentEntityId);
            TreeNode treeNode = BaseInterfaceLogic.TargetNode;
            BaseInterfaceLogic.FindTreeNode(this.tvOrganize, selectedId);
            TreeNode targetTreeNode = BaseInterfaceLogic.TargetNode;
            if (!BaseInterfaceLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode))
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0036, treeNode.Text, targetTreeNode.Text), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                returnValue = false;
            }
            return returnValue;
        }
        #endregion

        #region private void BatchMove() 批量移动
        /// <summary>
        /// 批量移动
        /// </summary>
        private void BatchMove()
        {
            // 用反射获得窗体
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmOrganizeSelect";
            Form frmOrganizeSelect = CacheManager.Instance.GetForm(assemblyName, formName);
            if (!String.IsNullOrEmpty(this.parentEntityId))
            {
                ((FrmOrganizeSelect)frmOrganizeSelect).OpenId = this.parentEntityId;
            }
            ((FrmOrganizeSelect)frmOrganizeSelect).AllowNull = false;
            ((FrmOrganizeSelect)frmOrganizeSelect).PermissionItemScopeCode = this.PermissionItemScopeCode;
            if (frmOrganizeSelect.ShowDialog() == DialogResult.OK)
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                this.FormLoaded = false;
                // 调用事件
                DotNetService.Instance.RoleService.BatchMoveTo(UserInfo, this.GetSelecteIds(), ((FrmOrganizeSelect)frmOrganizeSelect).SelectedId);
                // 绑定屏幕数据
                this.GetRoleList();
                this.FormLoaded = true;
                // 设置鼠标默认状态，原来的光标状态
                this.Cursor = holdCursor;
            }
        }
        #endregion

        #region private void SingleMove() 单个记录移动
        /// <summary>
        /// 单个记录移动
        /// </summary>
        private void SingleMove(string currentEntityId)
        {
            // 用反射获得窗体
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmOrganizeSelect";
            Form frmOrganizeSelect = CacheManager.Instance.GetForm(assemblyName, formName);
            if (!String.IsNullOrEmpty(this.parentEntityId))
            {
                ((FrmOrganizeSelect)frmOrganizeSelect).OpenId = this.parentEntityId;
            }
            ((FrmOrganizeSelect)frmOrganizeSelect).AllowNull = false;
            ((FrmOrganizeSelect)frmOrganizeSelect).PermissionItemScopeCode = this.PermissionItemScopeCode;
            if (frmOrganizeSelect.ShowDialog() == DialogResult.OK)
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                this.FormLoaded = false;
                // 调用事件
                DotNetService.Instance.RoleService.MoveTo(UserInfo, currentEntityId, ((FrmOrganizeSelect)frmOrganizeSelect).SelectedId);
                //this.DTPermissionCheck = DataSet.Tables[BasePermissionCheck.TableName];
                //this.DTRole = DataSet.Tables[BaseRoleEntity.TableName];
                // 加载窗体
                this.GetRoleList();
                this.BindData(true);
                this.FormLoaded = true;
                // 设置鼠标默认状态，原来的光标状态
                this.Cursor = holdCursor;
            }
        }
        #endregion

        #region private void MoveObject() 移动数据
        /// <summary>
        /// 移动数据
        /// </summary>
        private void MoveObject()
        {
            if (this.LastControl == this.grdRole)
            {
                if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdRole, "colSelected"))
                {
                    this.BatchMove();
                }
            }
            if (this.LastControl == this.tvOrganize)
            {
                if (this.parentEntityId.Length > 0)
                {
                    this.SingleMove(this.CurrentEntityId);
                }
            }
        }
        #endregion

        private void btnMove_Click(object sender, EventArgs e)
        {
            // 移动数据
            this.MoveObject();
        }

        #region public override int BatchDelete() 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <returns>影响行数</returns>
        public override int BatchDelete()
        {
            int returnValue = 0;
            returnValue = DotNetService.Instance.RoleService.BatchDelete(UserInfo, this.GetSelecteIds());
            // 加载窗体
            this.GetRoleList();
            return returnValue;
        }
        #endregion

        #region public int Delete() 删除数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <returns>影响行数</returns>
        public int Delete()
        {
            int returnValue = 0;
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdRole, "colSelected"))
            {
                if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    // 设置鼠标繁忙状态，并保留原先的状态
                    Cursor holdCursor = this.Cursor;
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        returnValue = this.BatchDelete();
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
            return returnValue;
        }
        #endregion

        private void btnBatchDelete_Click(object sender, EventArgs e)
        {
            // 删除数据
            this.Delete();
        }

        #region private void BatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private void BatchSave()
        {
            // DotNetService.Instance.RoleService.BatchSave(UserInfo, this.DTRoleList);
            // 绑定屏幕数据
            this.FormOnLoad();
            if (BaseSystemInfo.ShowInformation)
            {
                // 批量保存，进行提示
                MessageBox.Show(AppMessage.MSG0011, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        private void btnRolePermission_Click(object sender, EventArgs e)
        {
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmRolePermission";
            if (!BaseSystemInfo.UsePermissionItem)
            {
                formName = "FrmRoleModulePermission";
            }
            DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdRole);
            string id = dataRow[BaseRoleEntity.FieldId].ToString();
            string realName = dataRow[BaseRoleEntity.FieldRealName].ToString();
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserPermissionAdmin = (Form)Activator.CreateInstance(assemblyType, id, realName);
            frmUserPermissionAdmin.ShowDialog(this);
        }

        private void btnRoleUser_Click(object sender, EventArgs e)
        {
            DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdRole);
            string id = dataRow[BaseRoleEntity.FieldId].ToString();
            string realName = dataRow[BaseRoleEntity.FieldRealName].ToString();
            FrmRoleUserAdmin frmRoleUserAdmin = new FrmRoleUserAdmin(id, realName);
            frmRoleUserAdmin.ShowDialog(this);
        }

        public void Save()
        {
            // 检查批量输入的有效性
            if (BaseInterfaceLogic.CheckInputModifyAnyOne(this.DTRoleList))
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    // 批量保存
                    this.BatchSave();

                    // 2012.05.12 Pcsky
                    // 更新datatable的状态，解决无法二次修改的问题
                    this.DTRoleList.AcceptChanges();
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

        private void btnBatchSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmOrganizeRoleAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BaseInterfaceLogic.IsModfiedAnyOne(this.DTRoleList))
            {
                // 数据有变动是否保存的提示
                DialogResult dialogResult = MessageBox.Show(AppMessage.MSG0045, AppMessage.MSG0000, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
                if (dialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else if (dialogResult == DialogResult.Yes)
                {
                    // 保存数据
                    this.BatchSave();
                }
            }
        }

        private void tvOrganize_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvOrganize.GetNodeAt(e.X, e.Y) != null)
            {
                tvOrganize.SelectedNode = tvOrganize.GetNodeAt(e.X, e.Y);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 导出Excel
            //string exportFileName = this.Text + ".csv";
            string exportFileName = this.Text + ".xls";
            this.ExportExcel(this.grdRole , @"\Modules\Export\", exportFileName);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in this.grdRole.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in this.grdRole .Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false);
            }
        }
    }
}