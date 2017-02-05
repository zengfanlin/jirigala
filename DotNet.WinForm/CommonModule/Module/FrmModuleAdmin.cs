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
    
    /// <summary>
    /// FrmModuleAdmin.cs
    /// 模块管理窗体
    ///		
    /// 修改记录
    /// 
    ///     2011.10.19 版本：1.6 张广梁    优化添加、删除、编译和移动操作。
    ///     2007.06.04 版本：1.5 JiRiGaLa  添加右键弹出菜单。
    ///     2007.05.30 版本：1.4 JiRiGaLa  删除移动的主键优化，提示信息优化，标准工程完成。
    ///     2007.05.15 版本：1.2 JiRiGaLa  整体进行调试改进。
    ///     2007.05.10 版本：1.0 JiRiGaLa  模块管理功能页面编写。
    ///		
    /// 版本：1.6
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.10</date>
    /// </author>
    /// </summary>
    public partial class FrmModuleAdmin : BaseForm, IBaseForm
    {
        /// <summary>
        /// 模块 DataTable
        /// </summary>
        private DataTable DTModule = new DataTable(BaseModuleEntity.TableName);

        /// <summary>
        /// 模块列表 DataTable
        /// </summary>
        private DataTable DTModuleList = new DataTable(BaseModuleEntity.TableName);
        
        /// <summary>
        /// 记录最后点击的控件
        /// </summary>
        private System.Windows.Forms.Control LastControl  = null;

        /// <summary>
        /// 移动功能选择窗口
        /// </summary>
        FrmModuleSelect frmModuleSelect = null;

        public event SetControlStateEventHandler OnButtonStateChange;

        /// <summary>
        /// 用户授权
        /// </summary>
        private bool permissionAccredit = false;

        /// <summary>
        /// 2011-03-17
        /// 权限域编号(按权限管理范围来列出数据才可以，只能管理这个范围的数据)
        /// </summary>
        public string PermissionItemScopeCode = "Resource.ManagePermission";

        private string parentEntityId = string.Empty;
        /// <summary>
        /// 导航栏主键
        /// </summary>
        public string ParentEntityId
        {
            get
            {
                if (this.tvModule.SelectedNode != null && this.tvModule.SelectedNode.Tag != null && (this.tvModule.SelectedNode.Tag as DataRow) != null)
                {
                    //this.parentEntityId = {this.tvModule.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString()};
                    this.parentEntityId = ((DataRow)this.tvModule.SelectedNode.Tag)[BaseModuleEntity.FieldId].ToString();
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
        /// 列表中的主键
        /// </summary>
        public override string EntityId
        {
            get
            {
                return BaseInterfaceLogic.GetDataGridViewEntityId(this.grdModule, BaseModuleEntity.FieldId);
            }
        }

        /// <summary>
        /// 当前选中的节点，树或者表格上
        /// </summary>
        private string currentEntityId = string.Empty;
        /// <summary>
        /// 当前选中的节点，树或者表格上
        /// </summary>
        public string CurrentEntityId
        {
            get
            {
                if (this.LastControl == this.tvModule)
                {
                    this.currentEntityId = this.ParentEntityId;
                }
                else
                {
                    this.currentEntityId = this.EntityId;
                }
                return this.currentEntityId;
            }
            set { this.currentEntityId = value; }
        }

        public FrmModuleAdmin()
        {
            InitializeComponent();
        }

        #region private void BindItemDetails() 绑定下拉筐数据
        /// <summary>
        /// 绑定下拉筐数据
        /// </summary>
        private void BindItemDetails()
        {
            // 绑定职位数据，这里需要考虑屏幕刷新、批量保存时的效果问题
            if (this.cmbSystem.Items.Count == 0)
            {
                DataTable dataTable = DotNetService.Instance.ItemDetailsService.GetDataTable(UserInfo, "ItemsSystem");
                DataRow dataRow = dataTable.NewRow();
                dataTable.Rows.InsertAt(dataRow, 0);
                this.cmbSystem.DisplayMember = BaseItemDetailsEntity.FieldItemName;
                this.cmbSystem.ValueMember = BaseItemDetailsEntity.FieldItemValue;
                this.cmbSystem.DataSource = dataTable.DefaultView;
            }
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.SetSortButton(false);

            this.btnModulePermissionRelation.Visible = BaseSystemInfo.UseModulePermission && BaseSystemInfo.UsePermissionItem;
            this.mItmModulePermissionRelation.Visible = BaseSystemInfo.UseModulePermission && BaseSystemInfo.UsePermissionItem;
            this.mItmModuleSetPermission.Visible = BaseSystemInfo.UseModulePermission;

            this.mItmAdd.Enabled = false;
            this.mItmEdit.Enabled = false;
            this.mItmMove.Enabled = false;
            this.mItmDelete.Enabled = false;
            this.mItmModulePermissionRelation.Enabled = false;
            this.mItmModuleSetPermission.Enabled = false;
            this.mItmSetSortCode.Enabled = false;

            this.btnBatchDelete.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnBatchSave.Enabled = false;
            this.btnMove.Enabled = false;
            this.btnModulePermissionRelation.Enabled = false;
            this.btnRoleModulePermission.Enabled = false;
            this.btnUserModulePermission.Enabled = false;
            this.btnModuleConfig.Enabled = false;
            this.btnExport.Enabled = false;
            this.btnSelectAll.Enabled = false;
            this.btnInvertSelect.Enabled = false;

            this.btnUserModulePermission.Visible = BaseSystemInfo.UseUserPermission;
            this.btnRoleModulePermission.Visible = BaseSystemInfo.UseModulePermission;
            
            // 检查添加组织机构
            this.btnAdd.Enabled= this.permissionAdd;
            if (this.DTModuleList.DefaultView.Count >= 1)
            {
                this.btnEdit.Enabled = this.permissionEdit;
                this.btnMove.Enabled = this.permissionEdit;
                this.btnModulePermissionRelation.Enabled = this.permissionEdit;
                this.btnBatchDelete.Enabled = this.permissionDelete;
                this.btnBatchSave.Enabled = this.permissionEdit;
            }
            if (this.tvModule.Nodes.Count > 0)
            {
                this.btnEdit.Enabled = this.permissionEdit;
                this.btnMove.Enabled = this.permissionEdit;
                this.btnBatchDelete.Enabled = this.permissionDelete;
                this.btnModulePermissionRelation.Enabled = this.permissionAccredit;
                this.btnRoleModulePermission.Enabled = this.permissionAccredit;
                this.btnUserModulePermission.Enabled = this.permissionAccredit;
                this.btnModuleConfig.Enabled = this.permissionEdit;
                this.btnExport.Enabled = this.permissionExport;
            }
            // 位置顺序改变按钮部分
            if (this.DTModuleList.DefaultView.Count > 1)
            {
                this.SetSortButton(this.permissionEdit);

            }

            // 右手弹出菜单
            if ((this.DTModule.DefaultView.Count > 0) && (this.tvModule.Nodes.Count > 0))
            {
                this.mItmAdd.Enabled = this.permissionAdd;
                this.mItmEdit.Enabled = this.permissionEdit;
                this.mItmMove.Enabled = this.permissionEdit;
                this.mItmDelete.Enabled = this.permissionDelete;
                this.mItmModulePermissionRelation.Enabled = this.permissionAccredit;
                this.mItmModuleSetPermission.Enabled = this.permissionAccredit;                
                this.mItmSetSortCode.Enabled = this.permissionEdit;
            }
            // 添加根，什么时候都可以用才对。
            this.mItmAddRoot.Enabled = this.permissionEdit;

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

            if ((this.grdModule.RowCount >= 1))
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
            this.permissionAccess = this.IsModuleAuthorized("ModuleAdmin");
            this.permissionAdd = this.IsAuthorized("ModuleAdmin.Add");
            this.permissionEdit = this.IsAuthorized("ModuleAdmin.Edit");
            this.permissionDelete = this.IsAuthorized("ModuleAdmin.Delete");
            this.permissionExport = this.IsAuthorized("ModuleAdmin.Export");
            this.permissionAccredit = this.IsAuthorized("UserAdmin.Accredit");
        }
        #endregion

        #region private void BindData(bool reloadTree) 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        /// <param name="reloadTree">重新加模块载树</param>
        private void BindData(bool reloadTree)
        {
            // 加载模块树的主键
            if (reloadTree)
            {
                // 加载模块树
                this.LoadTree();
                if (this.tvModule.SelectedNode == null)
                {
                    if (this.tvModule.Nodes.Count > 0)
                    {
                        if (this.parentEntityId.Length == 0)
                        {
                            this.tvModule.SelectedNode = this.tvModule.Nodes[0];
                        }
                        else
                        {
                            BaseInterfaceLogic.FindTreeNode(this.tvModule, BaseModuleEntity.FieldId, this.parentEntityId);
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
            if (reloadTree)
            {
                this.GetModuleList();
            }
            // 判断编辑权限
            if (!this.permissionEdit)
            {
                // 只读属性设置
                this.grdModule.Columns["colSelected"].ReadOnly = !this.permissionEdit;
                this.grdModule.Columns["colFullName"].ReadOnly = !this.permissionEdit;
                this.grdModule.Columns["colDescription"].ReadOnly = !this.permissionEdit;
                // 修改背景颜色
                this.grdModule.Columns["colFullName"].DefaultCellStyle.BackColor = Color.White;
                this.grdModule.Columns["colDescription"].DefaultCellStyle.BackColor = Color.White;
            }
            // 设置按钮状态
            // this.SetControlState();
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdModule);
            // 获取选项明细
            this.BindItemDetails();
            // 获取模块列表
            this.DTModule = this.GetModuleScope(this.PermissionItemScopeCode);
            // 绑定屏幕数据
            this.BindData(true);
        }
        #endregion

        #region private void GetModuleList() 获得子模块列表
        /// <summary>
        /// 获得子模块列表
        /// </summary>
        private void GetModuleList()
        {
            //if (!reloadTree && !this.FormLoaded)
            //{
            //    return;
            //}
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.DTModuleList = DotNetService.Instance.ModuleService.GetDataTableByParent(UserInfo, this.ParentEntityId);
                this.grdModule.AutoGenerateColumns = false;
                this.DTModuleList.DefaultView.Sort = BaseModuleEntity.FieldSortCode;
                this.grdModule.DataSource = this.DTModuleList.DefaultView;
                // 设置排序按钮
                this.ucTableSort.DataBind(this.grdModule, this.permissionEdit);
                this.SetControlState();
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
        #endregion

        #region private void LoadTree() 加载模块树的主键
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
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvModule.EndUpdate();
        }
        #endregion

        #region private void LoadTreeModule(TreeNode treeNode) 加载组织机构树的主键
        /// <summary>
        /// 加载模块树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeModule(TreeNode treeNode)
        {
            if ((BaseSystemInfo.UsePermissionScope) && !UserInfo.IsAdministrator)
            {
                BaseInterfaceLogic.CheckTreeParentId(this.DTModule, BaseModuleEntity.FieldId, BaseModuleEntity.FieldParentId);
            }

            // 2012.06.15 改成按用户配置展开
            BaseInterfaceLogic.LoadTreeNodes(this.DTModule, BaseModuleEntity.FieldId, BaseModuleEntity.FieldParentId, BaseModuleEntity.FieldFullName, this.tvModule, treeNode, true, 0 , null, 1, true);
        }
        #endregion

        private void tvModule_Click(object sender, EventArgs e)
        {
            this.LastControl = this.tvModule;
            if (this.tvModule.SelectedNode == null)
            {
                this.tvModule.ContextMenuStrip = null;
            }
            else
            {
                this.tvModule.ContextMenuStrip = this.cMnuModule;
            }
        }

        private void tvModule_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.FormLoaded)
            {
                if (this.ParentEntityId.Length > 0)
                {
                    this.GetModuleList();
                }
            }
        }

        private void tvModule_DragEnter(object sender, DragEventArgs e)
        {
            // 拖动效果设成移动
            e.Effect = DragDropEffects.Move;
        }

        private void tvModule_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (this.permissionEdit)
            {
                // 开始进行拖放操作，并将拖放的效果设置成移动。
                this.DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void tvModule_DragDrop(object sender, DragEventArgs e)
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
                        // 是否移动模块
                        if (MessageBox.Show(AppMessage.Format(AppMessage.MSG0038, treeNode.Text, targetTreeNode.Text), AppMessage.MSG0000, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    DotNetService.Instance.ModuleService.MoveTo(UserInfo, (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString(), (targetTreeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString());
                    // 往目标节点中加入被拖动节点的一份克隆
                    this.tvModule.SelectedNode = targetTreeNode;
                    targetTreeNode.Nodes.Add((TreeNode)treeNode.Clone());
                    // 将被拖动的节点移除
                    treeNode.Remove();
                }
            }
        }

        private void grdModule_Sorted(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (this.permissionEdit)
            {
                string[] sequence = DotNetService.Instance.SequenceService.GetBatchSequence(UserInfo, BaseModuleEntity.TableName, this.DTModuleList.DefaultView.Count);
                int i = 0;
                foreach (DataRowView dataRowView in this.DTModuleList.DefaultView)
                {
                    dataRowView.Row[BaseModuleEntity.FieldSortCode] = sequence[i];
                    i++;
                }
                // 控制导航按钮
                this.SetSortButton(false);
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }

        private void mItmAdd_Click(object sender, EventArgs e)
        {
            this.btnAdd.PerformClick();
        }

        private void mItmEdit_Click(object sender, EventArgs e)
        {
            this.EditTree();
        }

        private void mItmMove_Click(object sender, EventArgs e)
        {
            this.SingleMove();
        }

        private void mItmDelete_Click(object sender, EventArgs e)
        {
            this.SingleDelete();
        }

        private void mItmAddRoot_Click(object sender, EventArgs e)
        {
            this.Add(true);
        }

        private void mItmModuleSetPermission_Click(object sender, EventArgs e)
        {
            // 权限资源访问设置
            this.SetAccessPermission();
        }

        #region private void ModuleSetPermission() 模块权限设置
        /// <summary>
        /// 模块权限设置
        /// </summary>
        private void ModulePermissionRelation()
        {
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmModulePermissionItemBatchSet";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmModulePermissionBatchSet = (Form)Activator.CreateInstance(assemblyType);
            frmModulePermissionBatchSet.ShowDialog(this);
        }
        #endregion

        #region private void SetAccessPermission() 权限资源访问设置
        /// <summary>
        /// 权限资源访问设置
        /// </summary>
        private void SetAccessPermission()
        {
            string targetResourceCategory = BaseModuleEntity.TableName;
            string targetResourceId = (this.tvModule.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
            string targetResourceName = this.tvModule.SelectedNode.Text;
            string permissionItemCode = "Resource.AccessPermission";
            if (!string.IsNullOrEmpty(targetResourceId))
            {
                string assemblyName = "DotNet.WinForm";
                string formName = "FrmResourceSetPermission";
                Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
                Form frmResourceSetPermission = (Form)Activator.CreateInstance(assemblyType, targetResourceCategory, targetResourceId, targetResourceName, permissionItemCode);
                frmResourceSetPermission.ShowDialog(this);
            }
        }
        #endregion

        private void mItmModulePermissionRelation_Click(object sender, EventArgs e)
        {
            // 菜单与操作权限关联
            this.ModulePermissionRelation();
        }

        string moduleList = string.Empty;

        private void GetTreeSort(TreeNode treeNode)
        {
            moduleList += (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString() + ",";
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                this.GetTreeSort(treeNode.Nodes[i]);
            }
        }

        #region private string[] GetTreeSort() 获得树型机构的排序顺序
        /// <summary>
        /// 获得树型机构的排序顺序
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetTreeSort()
        {
            string[] ids = new string[0];
            if (UserInfo.IsAdministrator)
            {
                this.moduleList = string.Empty;
                for (int i = 0; i < this.tvModule.Nodes.Count; i++)
                {
                    this.GetTreeSort(this.tvModule.Nodes[i]);
                }
                if (this.moduleList.Length > 0)
                {
                    this.moduleList = this.moduleList.Substring(0, this.moduleList.Length - 1);
                    ids = this.moduleList.Split(',');
                }
            }
            return ids;
        }
        #endregion

        private void mItmSetSortCode_Click(object sender, EventArgs e)
        {
            DotNetService.Instance.ModuleService.SetSortCode(UserInfo, this.GetTreeSort());
        }

        private void grdModule_Click(object sender, EventArgs e)
        {
            this.LastControl = this.grdModule;
        }

        private void grdModule_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            //// 判断是否有删除权限
            //if (!this.permissionDelete)
            //{
            //    e.Cancel = true;
            //    return;
            //}
            //else
            //{
            //    // 是否有子节点不允许删除
            //    BaseInterfaceLogic.FindTreeNode(this.tvModule, this.EntityId);
            //    if (BaseInterfaceLogic.TargetNode != null)
            //    {
            //        if (!BaseInterfaceLogic.NodeAllowDelete(BaseInterfaceLogic.TargetNode))
            //        {
            //            MessageBox.Show(AppMessage.Format(AppMessage.MSG0035, BaseInterfaceLogic.TargetNode.Text), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            e.Cancel = true;
            //        }
            //        else
            //        {
            //            // 提示删除确认
            //            if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            //            {
            //                e.Cancel = true;
            //            }
            //        }
            //    }
            //}
        }

        private void grdModule_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.permissionEdit)
            {
                this.EditGrid();
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

        private void cmbSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                string systemCode = this.cmbSystem.SelectedValue.ToString();
                if (string.IsNullOrEmpty(systemCode))
                {
                    systemCode = "Base";
                }
                BaseSystemInfo.SystemCode = systemCode;
                this.FormOnLoad();
            }
        }

        private void btnRoleModulePermission_Click(object sender, EventArgs e)
        {
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmRoleModulePermissionBatchSet";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmRoleModulePermission = (Form)Activator.CreateInstance(assemblyType);
            frmRoleModulePermission.ShowDialog(this);
        }

        private void btnUserModulePermission_Click(object sender, EventArgs e)
        {
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmUserModulePermissionBatchSet";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmRoleModulePermission = (Form)Activator.CreateInstance(assemblyType);
            frmRoleModulePermission.ShowDialog(this);
        }

        private void btnModuleConfig_Click(object sender, EventArgs e)
        {
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmModuleConfig";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserPermissionAdmin = (Form)Activator.CreateInstance(assemblyType);
            frmUserPermissionAdmin.ShowDialog(this);
        }

        private void btnExportAll_Click(object sender, EventArgs e)
        {
            // 全部导出Excel
            DataTable dataTable = DotNetService.Instance.ModuleService.GetDataTable(UserInfo);
            dataTable.DefaultView.Sort = BaseModuleEntity.FieldParentId + ", " + BaseModuleEntity.FieldSortCode;
            string exportFileName = this.Text + ".csv";
            this.ExportExcel(this.grdModule, dataTable.DefaultView, @"\Modules\Export\", exportFileName);
        }

        public string Add()
        {
            return this.Add(false);
        }

        #region public string Add(bool root) 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns>主键</returns>
        public string Add(bool root)
        {
            string returnValue = string.Empty;
            FrmModuleAdd frmModuleAdd;

            if (this.LastControl == this.tvModule)
            {
                if (root || (this.ParentEntityId.Length == 0) || (this.tvModule.SelectedNode == null))
                {
                    frmModuleAdd = new FrmModuleAdd();
                }
                else
                {
                    frmModuleAdd = new FrmModuleAdd(this.ParentEntityId, this.tvModule.SelectedNode.Text);
                }
            }
            else
            {
                DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdModule);
                if ((root) || dataRow == null)
                {
                    frmModuleAdd = new FrmModuleAdd();
                }
                else
                {
                    frmModuleAdd = new FrmModuleAdd(dataRow[BaseModuleEntity.FieldId].ToString(), dataRow[BaseModuleEntity.FieldFullName].ToString());
                }
            }
            frmModuleAdd.OnAdded += new FrmModuleAdd.OnAddedEventHandler(this.OnAdded);
            if ((frmModuleAdd.ShowDialog(this) == DialogResult.OK))
            {

                returnValue = frmModuleAdd.EntityId;
                string fullName = frmModuleAdd.FullName;
                string parentId = frmModuleAdd.ParentId;
                // tvModule 中增加结点
                TreeNode newNode = new TreeNode();
                newNode.Text = fullName;
                
                //newNode.Tag = returnValue;

                // 2012.06.11 Pcsky Tree基类修改后，需要修改对应的传值方式
                DataTable DTModuleAdd = new DataTable();
                DTModuleAdd = DotNetService.Instance.ModuleService.GetDataTableByIds(UserInfo, new string[] { returnValue });
                newNode.Tag = DTModuleAdd.Rows[0];

                TreeNode parentNode = null;
                if (!root&&!string.IsNullOrEmpty(parentId))
                {
                    BaseInterfaceLogic.FindTreeNode(this.tvModule, BaseModuleEntity.FieldId, parentId);
                    parentNode =BaseInterfaceLogic.TargetNode;
                }
                BaseInterfaceLogic.AddTreeNode(this.tvModule, newNode, parentNode);
            }

            if (frmModuleAdd.Changed)
            {
                // 绑定grdModule
                this.GetModuleList();
                // 使新增加的数据在grdModule中可见
                if (this.DTModuleList.Rows.Count > 0)
                {
                    this.grdModule.FirstDisplayedScrollingRowIndex = this.DTModuleList.Rows.Count - 1;
                }
            }
            return returnValue;
        }
        #endregion

        private bool OnAdded(string parentId, string fullName, string id)
        {

            BaseInterfaceLogic.FindTreeNode(this.tvModule, BaseModuleEntity.FieldId, parentId);
            //if (BaseInterfaceLogic.TargetNode != null)
            //{
                this.tvModule.SelectedNode = BaseInterfaceLogic.TargetNode;
                //string parentId = parentEntityId;
                // tvModule 中增加结点
                TreeNode newNode = new TreeNode();
                newNode.Text = fullName;
                newNode.Tag = DotNetService.Instance.ModuleService.GetDataTableByIds(UserInfo, new string[] { id }).Rows[0];
                BaseInterfaceLogic.AddTreeNode(this.tvModule, newNode, this.tvModule.SelectedNode);
                this.tvModule.SelectedNode = newNode;
                // 展开当前选中节点的所有父节点
                BaseInterfaceLogic.ExpandTreeNode(this.tvModule);
            //}
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 添加
            this.Add(false);
        }

        #region private void EditTree() 编辑树节点
        /// <summary>
        /// 编辑树节点
        /// </summary>
        private void EditTree()
        {
            if (this.tvModule.SelectedNode == null)
            {
                return;
            }
            FrmModuleEdit frmModuleEdit = new FrmModuleEdit((this.tvModule.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString());
            if (frmModuleEdit.ShowDialog(this) == DialogResult.OK)
            {
                // 编辑节点
                this.tvModule.SelectedNode.Text = frmModuleEdit.FullName;
                // 绑定grdModule
                this.GetModuleList();
                if (this.DTModuleList.Rows.Count > 0)
                {
                    this.grdModule.FirstDisplayedScrollingRowIndex = this.DTModuleList.Rows.Count - 1;
                }
            }
        }
        #endregion

        #region private void EditGrid() 编辑模块
        /// <summary>
        /// 编辑模块
        /// </summary>
        private void EditGrid()
        {
            if (this.grdModule.RowCount == 0)
            {
                // 提高用户体验，如果grdPermission没有数据则修改tvPermissiion 中的selectedNode
                this.LastControl = this.tvModule;
                return;
            }
            FrmModuleEdit frmModuleEdit = new FrmModuleEdit(this.EntityId);
            if (frmModuleEdit.ShowDialog(this) == DialogResult.OK)
            {
                BaseInterfaceLogic.FindTreeNode(this.tvModule, BaseModuleEntity.FieldId, this.EntityId);
                TreeNode selectNode = BaseInterfaceLogic.TargetNode;
                if (selectNode != null)
                {
                    selectNode.Text = frmModuleEdit.FullName;
                    TreeNode oldParentNode = selectNode.Parent;

                    BaseInterfaceLogic.FindTreeNode(this.tvModule, BaseModuleEntity.FieldId, frmModuleEdit.ParentId);
                    TreeNode parentNode = BaseInterfaceLogic.TargetNode;
                    // 编辑节点
                    BaseInterfaceLogic.EditTreeNode(this.tvModule, selectNode, parentNode);
                }
                // 绑定grdModule
                this.GetModuleList();
                if (this.DTModuleList.Rows.Count>0)
                {
                    this.grdModule.FirstDisplayedScrollingRowIndex = this.DTModuleList.Rows.Count - 1;
                }
            }
        }
        #endregion

        #region public void Edit() 编辑
        /// <summary>
        /// 编辑
        /// </summary>
        public void Edit()
        {
            // 编辑模块
            if (this.LastControl == this.grdModule)
            {
                this.EditGrid();
            }
            if (this.LastControl == this.tvModule)
            {
                this.EditTree();
            }
        }
        #endregion

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // 编辑模块
            this.Edit();
            this.ReSet();
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
            if (this.LastControl == this.tvModule)
            {
                BaseInterfaceLogic.FindTreeNode(this.tvModule, BaseModuleEntity.FieldId, this.parentEntityId);
                TreeNode treeNode = BaseInterfaceLogic.TargetNode;
                BaseInterfaceLogic.FindTreeNode(this.tvModule, BaseModuleEntity.FieldId, frmModuleSelect.SelectedId);
                TreeNode targetTreeNode = BaseInterfaceLogic.TargetNode;
                if (!BaseInterfaceLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode))
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0036, treeNode.Text, targetTreeNode.Text), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    returnValue = false;
                }
            }
            // 进行批量检查
            if (this.LastControl == this.grdModule)
            {
                BaseInterfaceLogic.FindTreeNode(this.tvModule, BaseModuleEntity.FieldId, frmModuleSelect.SelectedId);
                TreeNode targetTreeNode = BaseInterfaceLogic.TargetNode;
                string[] SelecteIds = this.GetSelecteIds();
                for (int i = 0; i < SelecteIds.Length; i++)
                {
                    BaseInterfaceLogic.FindTreeNode(this.tvModule, BaseModuleEntity.FieldId, SelecteIds[i]);
                    TreeNode treeNode = BaseInterfaceLogic.TargetNode;
                    if (!BaseInterfaceLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode))
                    {
                        MessageBox.Show(AppMessage.Format(AppMessage.MSG0036, treeNode.Text, targetTreeNode.Text), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        returnValue = false;
                        break;
                    }
                }
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
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdModule, "colSelected"))
            {
                frmModuleSelect = new FrmModuleSelect(this.ParentEntityId);
                frmModuleSelect.AllowNull = true;
                frmModuleSelect.OnButtonConfirmClick += new FrmModuleSelect.ButtonConfirmEventHandler(CheckInputMove);
                if (frmModuleSelect.ShowDialog() == DialogResult.OK)
                {
                    // 设置鼠标繁忙状态，并保留原先的状态
                    Cursor holdCursor = this.Cursor;
                    this.Cursor = Cursors.WaitCursor;
                    this.ParentEntityId = frmModuleSelect.SelectedId;
                    // 调用事件
                    string[] tags = this.GetSelecteIds();
                    DotNetService.Instance.ModuleService.BatchMoveTo(UserInfo, tags, frmModuleSelect.SelectedId);
                    // 移动treeNode
                    BaseInterfaceLogic.FindTreeNode(this.tvModule, BaseModuleEntity.FieldId, frmModuleSelect.SelectedId);
                    TreeNode parentNode = BaseInterfaceLogic.TargetNode;
                    if (tags.Length > 0)
                    {
                        for (int i = 0; i < tags.Length; i++)
                        {
                            BaseInterfaceLogic.FindTreeNode(this.tvModule, BaseModuleEntity.FieldId, tags[i]);
                            BaseInterfaceLogic.MoveTreeNode(this.tvModule, BaseInterfaceLogic.TargetNode, parentNode);
                        }
                    }
                    // 绑定grdModule
                    this.GetModuleList();
                    if (this.DTModuleList.Rows.Count > 0)
                        this.grdModule.FirstDisplayedScrollingRowIndex = this.DTModuleList.Rows.Count - 1;
                    // 设置鼠标默认状态，原来的光标状态
                    this.Cursor = holdCursor;
                }
            }
        }
        #endregion

        #region private void SingleMove() 单个记录移动
        /// <summary>
        /// 单个记录移动
        /// </summary>
        private void SingleMove()
        {
           if (String.IsNullOrEmpty(this.ParentEntityId))
            {
                return;
            }
            frmModuleSelect = new FrmModuleSelect(this.ParentEntityId);
            frmModuleSelect.AllowNull = true;
            frmModuleSelect.OnButtonConfirmClick += new FrmModuleSelect.ButtonConfirmEventHandler(this.CheckInputMove);
            if (frmModuleSelect.ShowDialog() == DialogResult.OK)
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                // 调用事件
                DotNetService.Instance.ModuleService.MoveTo(UserInfo, this.CurrentEntityId, frmModuleSelect.SelectedId);
                // 移动treeNode
                BaseInterfaceLogic.FindTreeNode(this.tvModule, BaseModuleEntity.FieldId, frmModuleSelect.SelectedId);
                BaseInterfaceLogic.MoveTreeNode(this.tvModule, this.tvModule.SelectedNode, BaseInterfaceLogic.TargetNode);
                // 绑定grdModule
                this.GetModuleList();
                if (this.DTModuleList.Rows.Count > 0)
                    this.grdModule.FirstDisplayedScrollingRowIndex = this.DTModuleList.Rows.Count - 1;
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
            if (this.LastControl == this.grdModule)
            {
                this.BatchMove();
            }
            if (this.LastControl == this.tvModule)
            {
                this.SingleMove();
            }
        }
        #endregion

        private void btnMove_Click(object sender, EventArgs e)
        {
            // 移动数据
            this.MoveObject();
            this.ReSet();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 导出Excel
            //string exportFileName = this.Text + ".csv";
            string exportFileName = this.Text + ".xls";
            this.ExportExcel(this.grdModule , @"\Modules\Export\", exportFileName);
        }

        #region private string[] GetSelecteIds() 获得已被选择的模块主键数组
        /// <summary>
        /// 获得已被选择的模块主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelecteIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdModule, BaseModuleEntity.FieldId, "colSelected", true);
        }
        #endregion

        #region private bool CheckInputBatchDelete() 检查输入的有效性
        /// <summary>
        /// 检查删除选择项的有效性
        /// </summary>
        /// <returns>有效</returns>
        private bool CheckInputBatchDelete()
        {
            bool returnValue = false;
            BaseModuleEntity moduleEntity = new BaseModuleEntity();

            foreach (DataGridViewRow dgvRow in grdModule.Rows)
            {
                DataRow dataRow = (dgvRow.DataBoundItem as DataRowView).Row;
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    continue;
                }
                if ((System.Boolean)(dgvRow.Cells["colSelected"].Value??false))
                {
                    // 是否允许删除
                    moduleEntity.GetFrom(dataRow);
                    if (moduleEntity.AllowDelete == 0)
                    {
                        returnValue = false;
                        MessageBox.Show(AppMessage.Format(AppMessage.MSG0018, moduleEntity.FullName), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return returnValue;
                    }
                    else
                    {
                        returnValue = true;
                        // 是否有子节点
                        string id = dataRow[BaseModuleEntity.FieldId].ToString();
                        BaseInterfaceLogic.FindTreeNode(this.tvModule, BaseModuleEntity.FieldId, id);
                        if (BaseInterfaceLogic.TargetNode != null)
                        {
                            if (!BaseInterfaceLogic.NodeAllowDelete(BaseInterfaceLogic.TargetNode))
                            {
                                MessageBox.Show(AppMessage.Format(AppMessage.MSG0035, BaseInterfaceLogic.TargetNode.Text), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                returnValue = false;
                            }
                        }
                        return returnValue;
                    }
                }
            }

            //foreach (DataRow dataRow in this.DTModuleList.Rows)
            //{
            //    if (dataRow.RowState == DataRowState.Deleted)
            //    {
            //        continue;
            //    }
            //    if (dataRow["colSelected"].ToString() == true.ToString())
            //    {
            //        // 是否允许删除
            //        moduleEntity.GetFrom(dataRow);
            //        if (moduleEntity.AllowDelete == 0)
            //        {
            //            returnValue = false;
            //            MessageBox.Show(AppMessage.Format(AppMessage.MSG0018, moduleEntity.FullName), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            return returnValue;
            //        }
            //        else
            //        {
            //            returnValue = true;
            //            // 是否有子节点
            //            string id = dataRow[BaseModuleEntity.FieldId].ToString();
            //            BaseInterfaceLogic.FindTreeNode(this.tvModule, id);
            //            if (BaseInterfaceLogic.TargetNode != null)
            //            {
            //                if (!BaseInterfaceLogic.NodeAllowDelete(BaseInterfaceLogic.TargetNode))
            //                {
            //                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0035, BaseInterfaceLogic.TargetNode.Text), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                    returnValue = false;
            //                }
            //            }
            //            return returnValue;
            //        }
            //    }
            //}
            if (!returnValue)
            {
                MessageBox.Show(AppMessage.MSGC023, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return returnValue;
        }
        #endregion

        #region public override int BatchDelete() 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <returns>影响行数</returns>
        public override int BatchDelete()
        {
            int returnValue = 0;
            if (this.CheckInputBatchDelete())
            {
                if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    // 删除选中的纪录
                    // returnValue = DotNetService.Instance.ModuleService.BatchDelete(UserInfo, this.GetSelecteIds());
                    string[] tags = this.GetSelecteIds();
                    returnValue = DotNetService.Instance.ModuleService.SetDeleted(UserInfo, tags);
                    // 获取模块列表
                    this.DTModule = DotNetService.Instance.ModuleService.GetDataTable(UserInfo);
                    // 在tree删除相应的节点
                    BaseInterfaceLogic.BatchRemoveNode(this.tvModule, tags);
                    // 绑定grdModule
                    this.GetModuleList();
                }
            }
            return returnValue;
        }
        #endregion

        #region private void SingleDelete() 单个记录删除
        /// <summary>
        /// 单个记录删除
        /// </summary>
        /// <returns>影响行数</returns>
        private int SingleDelete()
        {
            int returnValue = 0;
            if (this.tvModule.SelectedNode == null)
            {
                return returnValue;
            }
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (!BaseInterfaceLogic.NodeAllowDelete(this.tvModule.SelectedNode))
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0035, this.tvModule.SelectedNode.Text), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    // returnValue = DotNetService.Instance.ModuleService.Delete(UserInfo, this.ParentEntityId);
                    returnValue = DotNetService.Instance.ModuleService.SetDeleted(UserInfo, new string[] { this.ParentEntityId });
                    // 有数据被删除了？
                    if (returnValue > 0)
                    {
                        string[] tags ={(this.tvModule.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString()};
                        BaseInterfaceLogic.BatchRemoveNode(this.tvModule, tags);
                        // 绑定grdModule
                        this.GetModuleList();
                    }
                }
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
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
            if (this.LastControl == this.grdModule)
            {
                // 检查批量输入的有效性
                if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdModule, "colSelected"))
                {
                    returnValue = this.BatchDelete();
                }
            }
            if (this.LastControl == this.tvModule)
            {
                returnValue = this.SingleDelete();
            }
            return returnValue;
        }
        #endregion

        private void btnBatchDelete_Click(object sender, EventArgs e)
        {
            this.Delete();
        }

        #region private bool CheckInputBatchSave() 检查批量输入的有效性
        /// <summary>
        /// 检查批量输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        private bool CheckInputBatchSave()
        {
            int selectedCount = 0;
            bool returnValue = false;
            BaseModuleEntity moduleEntity = new BaseModuleEntity();
            foreach (DataRow dataRow in this.DTModuleList.Rows)
            {
                // 这里判断数据的各种状态
                if (dataRow.RowState == DataRowState.Modified)
                {
                    // 是否允许编辑
                    moduleEntity.GetFrom(dataRow);
                    if (moduleEntity.AllowEdit == 0)
                    {
                        if ((dataRow[BaseModuleEntity.FieldFullName, DataRowVersion.Original] != dataRow[BaseModuleEntity.FieldFullName, DataRowVersion.Current]) || (dataRow[BaseModuleEntity.FieldDescription, DataRowVersion.Original] != dataRow[BaseModuleEntity.FieldDescription, DataRowVersion.Current]))
                        {
                            returnValue = false;
                            MessageBox.Show(AppMessage.Format(AppMessage.MSG0020, AppMessage.MSG9978), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // 这里需要直接返回了，不再进行输入交验了。
                            return returnValue;
                        }
                    }
                    selectedCount++;
                }
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    selectedCount++;
                }
            }
            // 有记录被选中了
            returnValue = selectedCount > 0;
            if (!returnValue)
            {
                MessageBox.Show(AppMessage.MSG0004, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return returnValue;
        }
        #endregion

        #region private void BatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private void BatchSave()
        {
            DotNetService.Instance.ModuleService.BatchSave(UserInfo, this.DTModuleList);
            // 绑定屏幕数据
            this.FormOnLoad();
            if (BaseSystemInfo.ShowInformation)
            {
                // 批量保存，进行提示
                MessageBox.Show(AppMessage.MSG0012, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        public void Save()
        {
            // 检查批量输入的有效性
            if (this.CheckInputBatchSave())
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    // 批量保存
                    this.BatchSave();
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

        private void ReSet()
        {
            // 重新获取客户端的缓存模块数据
            ClientCache.Instance.DTMoule = DotNetService.Instance.ModuleService.GetDataTable(UserInfo);
            ClientCache.Instance.DTUserMoule = DotNetService.Instance.ModuleService.GetDataTable(UserInfo);
        }

        private void btnBatchSave_Click(object sender, EventArgs e)
        {
            this.Save();
            this.ReSet();
        }

        private void btnModulePermissionRelation_Click(object sender, EventArgs e)
        {
            // 模块权限设置
            this.ModulePermissionRelation();
            this.ReSet();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmModuleAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BaseInterfaceLogic.IsModfiedAnyOne(this.DTModuleList))
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
        private void tvModule_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvModule.GetNodeAt(e.X, e.Y) != null)
            {
                tvModule.SelectedNode = tvModule.GetNodeAt(e.X, e.Y);
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in this.grdModule.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }
            this.LastControl = this.grdModule;
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in this.grdModule.Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false);
            }
            this.LastControl = this.grdModule;
        }  
    }
}