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
    /// FrmItemsAdmin.cs
    /// 主键管理窗体
    ///		
    /// 修改记录
    ///
    ///     2008.04.02 版本：1.5 JiRiGaLa  主键整理。
    ///     2008.02.04 版本：1.4 JiRiGaLa  页面操作优化，主键整理。
    ///     2007.12.26 版本：1.3 JiRiGaLa  增加 Sorted 方法。
    ///     2007.05.15 版本：1.2 JiRiGaLa  整体进行调试改进。
    ///     2007.05.10 版本：1.0 JiRiGaLa  基础编码管理功能页面编写。
    ///		
    /// 版本：1.4
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.04.02</date>
    /// </author> 
    /// </summary>
    public partial class FrmItemsAdmin : BaseForm, IBaseForm
    {
        private DataTable DTItems = new DataTable(BaseItemsEntity.TableName);           // 基础主键表

        /// <summary>
        /// 目标基础主键表
        /// </summary>
        public string TargetTableName = BaseItemsEntity.TableName;

        public event SetControlStateEventHandler OnButtonStateChange;

        /// <summary>
        /// 本模块的用户角色授权权限
        /// </summary>
        private bool permissionAccredit = false;

        private string parentId = "Items";
        /// <summary>
        /// 父亲节点
        /// </summary>
        public string ParentId
        {
            get
            {
                return this.parentId;
            }
            set
            {
                this.parentId = value;
            }
        }

        public bool AllowDetails = true;      // 是否允许显示明细部分
        public bool AllowSelectItems = true;  // 是否允许选择

        // 实体主键
        public override string EntityId
        {
            get
            {
                return BaseInterfaceLogic.GetDataGridViewEntityId(this.grdItems_, BaseModuleEntity.FieldId);
            }
        }

        public string EntityFullName
        {
            get
            {
                return BaseInterfaceLogic.GetDataGridViewEntityId(this.grdItems_, BaseModuleEntity.FieldFullName);
            }
        }        

        private string entityId = string.Empty;
        /// <summary>
        /// 当前选中的记录主键
        /// </summary>
        public string CurrentEntityId
        {
            get
            {
                return this.entityId;
            }
            set
            {
                this.entityId = value;
            }
        }

        public FrmItemsAdmin()
        {
            InitializeComponent();
        }

        public FrmItemsAdmin(string parentId) : this()
        {
            this.ParentId   = ParentId;
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.SetSortButton(false);
            this.btnDetails.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnExport.Enabled = false;
            this.btnBatchDelete.Enabled = false;
            this.btnBatchSave.Enabled = false;
            this.btnPermission.Enabled = false;
            this.btnUserResourcePermission.Enabled = false;
            this.btnRoleResourcePermission.Enabled = false;

            this.btnSelectAll.Enabled = false;
            this.btnInvertSelect.Enabled = false;

            this.btnUserResourcePermission.Visible = BaseSystemInfo.UsePermissionScope && BaseSystemInfo.UseUserPermission;
            this.btnRoleResourcePermission.Visible = BaseSystemInfo.UsePermissionScope;
            
            // 检查添加组织机构
            this.btnAdd.Enabled     = this.permissionAdd;
            this.btnDetails.Visible = this.AllowDetails;
            if (this.DTItems.DefaultView.Count >= 1)
            {
                if (this.permissionEdit)
                {
                    this.btnDetails.Enabled = this.ParentId.Equals("Items");
                }
                this.btnEdit.Enabled        = this.permissionEdit;
                this.btnExport.Enabled      = this.permissionExport;
                this.btnBatchDelete.Enabled = this.permissionDelete;
                this.btnBatchSave.Enabled   = this.permissionEdit;

                this.btnPermission.Enabled = this.permissionAccredit && BaseSystemInfo.UsePermissionScope;

                this.btnRoleResourcePermission.Enabled = this.permissionAccredit;
                this.btnUserResourcePermission.Enabled = this.permissionAccredit;
            }
            // 位置顺序改变按钮部分
            if (this.DTItems.DefaultView.Count > 1)
            {
                this.SetSortButton(this.permissionEdit);
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

            if ((this.grdItems_ .RowCount >= 1))
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
            this.permissionAccess = this.IsModuleAuthorized("ItemsAdmin");    // 访问用基础主键管理
            this.permissionSearch   = this.IsAuthorized("ItemsAdmin.Search");    // 查询用户
            this.permissionAdd      = this.IsAuthorized("ItemsAdmin.Add");       // 添加用户
            this.permissionEdit     = this.IsAuthorized("ItemsAdmin.Edit");      // 编辑用户
            this.permissionExport   = this.IsAuthorized("ItemsAdmin.Export");    // 设置密码
            this.permissionDelete   = this.IsAuthorized("ItemsAdmin.Delete");    // 删除用户
            // 这个可以是范围权限（这里当操作权限处理），对哪些（组织机构、用户、角色）分配权限的范围权限？
            this.permissionAccredit = this.IsAuthorized("UserAdmin.Accredit");
        }
        #endregion

        #region private void BindData() 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        private void BindData()
        {
            this.grdItems_.AutoGenerateColumns = false;
            this.DTItems.DefaultView.Sort = BaseItemsEntity.FieldSortCode;

            string rowFilter = string.Empty;
            if (this.chkEnabled.Checked)
            {
                rowFilter = BaseItemsEntity.FieldEnabled + " = 1 ";
                this.DTItems.DefaultView.RowFilter = rowFilter;
            }

            this.grdItems_.DataSource = this.DTItems.DefaultView;
            // this.grdItems_.Refresh();
            if (this.grdItems_.Rows.Count > 0)
            {
                if (this.CurrentEntityId.Length > 0)
                {
                    this.grdItems_.FirstDisplayedScrollingRowIndex = BaseInterfaceLogic.GetRowIndex(this.DTItems, BaseItemsEntity.FieldId, this.CurrentEntityId);
                }
            }
            // 判断编辑权限
            if (!this.permissionEdit)
            {
                // 只读属性设置
                this.grdItems_.Columns["colSelected"].ReadOnly = true;
                this.grdItems_.Columns["colCode"].ReadOnly = true;
                this.grdItems_.Columns["colFullName"].ReadOnly = true;
                this.grdItems_.Columns["colTargetTable"].ReadOnly = true;
                this.grdItems_.Columns["colDescription"].ReadOnly = true;
                this.grdItems_.Columns["colUseItemCode"].ReadOnly = true;
                this.grdItems_.Columns["colUseItemName"].ReadOnly = true;
                this.grdItems_.Columns["colUseItemValue"].ReadOnly = true;
                this.grdItems_.Columns["colEnabled"].ReadOnly = true;

                // 修改背景颜色
                this.grdItems_.Columns["colCode"].DefaultCellStyle.BackColor = Color.White;
                this.grdItems_.Columns["colFullName"].DefaultCellStyle.BackColor = Color.White;
                this.grdItems_.Columns["colTargetTable"].DefaultCellStyle.BackColor = Color.White;
                this.grdItems_.Columns["colDescription"].DefaultCellStyle.BackColor = Color.White;
            }
            // 设置排序按钮
            this.ucTableSort.DataBind(this.grdItems_, this.permissionEdit);
            // 设置按钮状态
            this.SetControlState();
        }
        #endregion

        #region public override void GetList() 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        public override void GetList()
        {
            if (!String.IsNullOrEmpty(this.ParentId))
            {
                // 获得数据
                this.DTItems = DotNetService.Instance.ItemsService.GetDataTable(UserInfo);
            }
            else
            {
                this.DTItems = DotNetService.Instance.ItemsService.GetDataTableByParent(UserInfo, this.ParentId);
            }
            this.TargetTableName = this.DTItems.TableName;
            // 绑定屏幕数据
            this.BindData();
            // 设置按钮状态
            this.SetControlState();
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdItems_);
            this.GetList();
        }
        #endregion

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string rowFilter = string.Empty;
            if (this.chkEnabled.Checked)
            {
                rowFilter = BaseItemsEntity.FieldEnabled + " = 1 ";
            }
            string search = this.txtSearch.Text.Trim();
            if (String.IsNullOrEmpty(search))
            {
                this.DTItems.DefaultView.RowFilter = rowFilter;
            }
            else
            {
                search = StringUtil.GetSearchString(search);
                if (!string.IsNullOrEmpty(rowFilter))
                {
                    rowFilter = "(" + rowFilter + ") AND ";
                }
                rowFilter += "("+ 
                    
                    /*BaseItemsEntity.FieldCode + " LIKE '" + search + "'"
                    + " OR " + BaseItemsEntity.FieldFullName + " LIKE '" + search + "'"
                    + " OR " + BaseItemsEntity.FieldTargetTable + " LIKE '" + search + "'"
                    + " OR " + BaseItemsEntity.FieldDescription + " LIKE '" + search + */

                    StringUtil.GetLike(BaseItemsEntity.FieldCode, search)
                        + " OR " + StringUtil.GetLike(BaseItemsEntity.FieldFullName, search)
                        + " OR " + StringUtil.GetLike(BaseItemsEntity.FieldTargetTable, search)
                        + " OR " + StringUtil.GetLike(BaseItemsEntity.FieldDescription, search) +
                    ")";

                this.DTItems.DefaultView.RowFilter = rowFilter;
            }
            // 设置按钮状态
            this.SetControlState();
        }

        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            string rowFilter = string.Empty;
            if (this.chkEnabled.Checked)
            {
                rowFilter = BaseItemsEntity.FieldEnabled + " = 1 ";
            }
            this.DTItems.DefaultView.RowFilter = rowFilter;
            // 设置按钮状态
            this.SetControlState();
        }    

        private void ucItemsTreeSelect_SelectedIndexChanged(string parentId)
        {
            this.txtSearch.Text = string.Empty;
            this.ParentId = ParentId;
            this.GetList();
        }

        private void btnRoleResourcePermission_Click(object sender, EventArgs e)
        {
            // 资源管理权限
            string permissionItemCode = "Resource.ManagePermission";
            string targetResourceCategory = BaseItemsEntity.TableName;
            string targetResourceSQL = "SELECT " + BaseItemsEntity.FieldId + " AS Id, " 
                                        + BaseItemsEntity.FieldFullName + " AS RealName, " 
                                        + BaseItemsEntity.FieldDescription + " AS Description FROM " 
                                        + BaseItemsEntity.TableName
                                        + " WHERE " + BaseItemsEntity.FieldDeletionStateCode + " = 0 AND " + BaseItemsEntity.FieldEnabled + " = 1 ORDER BY " + BaseItemsEntity.FieldSortCode;

            string assemblyName = "DotNet.WinForm";
            string formName = "FrmRoleResourcePermission";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmRoleModulePermission = (Form)Activator.CreateInstance(assemblyType, permissionItemCode, targetResourceCategory, targetResourceSQL);
            frmRoleModulePermission.ShowDialog(this);
        }

        private void btnUserResourcePermission_Click(object sender, EventArgs e)
        {
            // 资源管理权限
            string permissionItemCode = "Resource.ManagePermission";
            string targetResourceCategory = BaseItemsEntity.TableName;
            string targetResourceSQL = "SELECT " + BaseItemsEntity.FieldId + " AS Id, "
                                        + BaseItemsEntity.FieldFullName + " AS RealName, "
                                        + BaseItemsEntity.FieldDescription + " AS Description FROM "
                                        + BaseItemsEntity.TableName
                                        + " WHERE " + BaseItemsEntity.FieldDeletionStateCode + " = 0 AND " + BaseItemsEntity.FieldEnabled + " = 1 ORDER BY " + BaseItemsEntity.FieldSortCode;

            string assemblyName = "DotNet.WinForm";
            string formName = "FrmUserResourcePermission";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmRoleModulePermission = (Form)Activator.CreateInstance(assemblyType, permissionItemCode, targetResourceCategory, targetResourceSQL);
            frmRoleModulePermission.ShowDialog(this);
        }

        private void grdItems_Sorted(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (this.permissionEdit)
            {
                string[] sequence = DotNetService.Instance.SequenceService.GetBatchSequence(UserInfo, BaseItemsEntity.TableName, this.DTItems.DefaultView.Count);
                int i = 0;
                foreach (DataRowView dataRowView in this.DTItems.DefaultView)
                {
                    dataRowView.Row[BaseItemsEntity.FieldSortCode] = sequence[i];
                    i++;
                }
                // 控制导航按钮
                this.SetSortButton(false);
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }

        private void grdItems_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // 当前记录是否允许被删除
            BaseItemsEntity ItemsEntity = new BaseItemsEntity();
            DataRow dataRow = BaseBusinessLogic.GetDataRow(this.DTItems, this.EntityId);
            ItemsEntity.GetFrom(dataRow);
            // 判断是否允许删除
            if (ItemsEntity.AllowDelete == 0)
            {
                MessageBox.Show(AppMessage.MSG0017, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Question);
                e.Cancel = true;
            }
            else
            {
                if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else
                {
                    // 删除数据
                    DotNetService.Instance.ItemsService.Delete(UserInfo, this.TargetTableName, this.EntityId);
                }
            }
        }

        private void grdItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnDetails.PerformClick();
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


        private void btnDetails_Click(object sender, EventArgs e)
        {
            DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdItems_);
            BaseItemsEntity itemsEntity = new BaseItemsEntity(dataRow);
            FrmItemDetailsAdmin frmItemDetailsAdmin = new FrmItemDetailsAdmin(itemsEntity.TargetTable);
            // 窗口的弹出位置进行友善化
            if (this.WindowState == FormWindowState.Normal)
            {
                // frmItemsAdmin.Left = this.Left;
                // frmItemsAdmin.Top = this.Top;
                // frmItemsAdmin.Height = this.Height + 40;
            }
            frmItemDetailsAdmin.AllowDetails = false;
            // frmItemDetailsAdmin.AllowSelectItems = false;
            // if (!String.IsNullOrEmpty(itemsEntity.TargetTable))
            // {
                //frmItemsAdmin.TargetTableName = itemsEntity.TargetTable;
            // }
            frmItemDetailsAdmin.ShowDialog(this);
        }

        /// <summary>
        /// 当数据变化时
        /// </summary>
        private void OnDataChanged()
        {
            // 重新加载窗体
            this.FormOnLoad();
            // 设置按钮状态
            this.SetControlState();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns>主键</returns>
        public string Add()
        {
            FrmItemsAdd frmItemsAdd = new FrmItemsAdd();
            frmItemsAdd.OnDataChanged += new FrmItemsAdd.OnDataChangedEventHandler(this.OnDataChanged);
            if (frmItemsAdd.ShowDialog(this) == DialogResult.OK)
            {
                // 记录当前选中的主键
                this.CurrentEntityId = frmItemsAdd.EntityId;
                // 加载窗体
                this.FormOnLoad();
            }
            return this.CurrentEntityId;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Add();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        public void Edit()
        {
            string id = BaseInterfaceLogic.GetDataGridViewEntityId(this.grdItems_, BaseItemsEntity.FieldId);
            FrmItemsEdit frmItemsEdit = new FrmItemsEdit(id);
            if (frmItemsEdit.ShowDialog(this) == DialogResult.OK)
            {
                // 加载窗体
                this.FormOnLoad();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Edit();
        }        

        #region private void SetAccessPermission() 权限资源访问设置
        /// <summary>
        /// 权限资源访问设置
        /// </summary>
        private void SetAccessPermission()
        {
            string targetResourceCategory = BaseItemsEntity.TableName;
            string targetResourceId = this.EntityId;
            string targetResourceName = this.EntityFullName;
            string permissionItemCode = "Resource.ManagePermission";
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

        private void btnPermission_Click(object sender, EventArgs e)
        {
            // 权限资源访问设置
            this.SetAccessPermission();
        }

        #region private string[] GetSelecteIds() 获得已被选择的编码主键数组
        /// <summary>
        /// 获得已被选择的编码主键数组
        /// </summary>
        /// <returns></returns>
        private string[] GetSelecteIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdItems_, BaseItemsEntity.FieldId, "colSelected", true);
        }
        #endregion

        #region private void BatchMove() 移动
        /// <summary>
        /// 批量移动
        /// </summary>
        private void BatchMove()
        {
            // 判断是否有编辑权限
            if (!this.permissionEdit)
            {
                return;
            }

            // 选择目标节点
            string targetId = string.Empty;
            FrmItemDetailsTreeSelect frmItemsTreeSelect = new FrmItemDetailsTreeSelect();
            // frmItemsTreeSelect.OldItemsId = this.EntityId;
            frmItemsTreeSelect.CheckMove = true;
            frmItemsTreeSelect.AllowNull = false;
            // 弹出选择窗体
            if (frmItemsTreeSelect.ShowDialog() == DialogResult.OK)
            {
                targetId = frmItemsTreeSelect.SelectedId;
            }
            else
            {
                return;
            }

            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (targetId.Length > 0)
                {
                    DotNetService.Instance.ItemsService.BatchMoveTo(UserInfo, this.TargetTableName, this.GetSelecteIds(), targetId);
                    // 绑定屏幕数据
                    this.GetList();
                    if (BaseSystemInfo.ShowInformation)
                    {
                        // 批量保存，进行提示
                        MessageBox.Show(AppMessage.MSG0242, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
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

        private void btnMoveTo_Click(object sender, EventArgs e)
        {
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdItems_, "colSelected"))
            {
                // 移动
                this.BatchMove();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 导出Excel
            //string exportFileName = this.Text + ".csv";
            string exportFileName = this.Text + ".xls";
            this.ExportExcel(this.grdItems_ , @"\Modules\Export\", exportFileName);
        }

        #region private bool CheckInputBatchDelete() 检查批量删除的输入的有效性
        /// <summary>
        /// 检查批量删除的输入的有效性
        /// </summary>
        /// <returns>允许批量删除</returns>
        private bool CheckInputBatchDelete()
        {
            bool returnValue = false;
            int selectedCount = 0;
            BaseItemsEntity itemsEntity = new BaseItemsEntity();

            foreach (DataGridViewRow dgvRow in grdItems_.Rows)
            {
                DataRow dataRow = (dgvRow.DataBoundItem as DataRowView).Row;
                if (dataRow.RowState != DataRowState.Deleted)
                {
                    if ((System.Boolean)(dgvRow.Cells["colSelected"].Value??false))
                    {
                        // 是否允许删除
                        itemsEntity.GetFrom(dataRow);
                        if (itemsEntity.AllowDelete == 0)
                        {
                            returnValue = false;
                            MessageBox.Show(AppMessage.Format(AppMessage.MSG0018, itemsEntity.FullName), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // 这里需要直接返回了，不再进行输入交验了。
                            return returnValue;
                        }
                        else
                        {
                            selectedCount++;
                        }
                    }
                }
            }

            //foreach (DataRowView dataRowView in this.DTItems.DefaultView)
            //{
            //    DataRow dataRow = dataRowView.Row;
            //    if (dataRow.RowState != DataRowState.Deleted)
            //    {
            //        if (dataRow["colSelected"].ToString() == true.ToString())
            //        {
            //            // 是否允许删除
            //            itemsEntity.GetFrom(dataRow);
            //            if (itemsEntity.AllowDelete == 0)
            //            {
            //                returnValue = false;
            //                MessageBox.Show(AppMessage.Format(AppMessage.MSG0018, itemsEntity.FullName), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                // 这里需要直接返回了，不再进行输入交验了。
            //                return returnValue;
            //            }
            //            else
            //            {
            //                selectedCount++;
            //            }
            //        }
            //    }
            //}
            // 有记录被选中了
            returnValue = selectedCount > 0;
            if (!returnValue)
            {
                MessageBox.Show(AppMessage.MSG0024, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            return DotNetService.Instance.ItemsService.BatchDelete(UserInfo, this.TargetTableName, this.GetSelecteIds());
        }
        #endregion

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <returns>影响行数</returns>
        public int Delete()
        {
            int returnValue = 0;
            if (this.CheckInputBatchDelete())
            {
                if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    // 设置鼠标繁忙状态，并保留原先的状态
                    Cursor holdCursor = this.Cursor;
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        // 批量删除
                        returnValue = this.BatchDelete();
                        // 绑定屏幕数据
                        this.GetList();
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

        private void btnBatchDelete_Click(object sender, EventArgs e)
        {
            // 删除
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
            foreach (DataRow dataRow in this.DTItems.Rows)
            {
                // 这里判断数据的各种状态
                if (dataRow.RowState == DataRowState.Modified)
                {
                    BaseItemsEntity items = new BaseItemsEntity(dataRow);
                    if (items.AllowEdit == 0)
                    {
                        if ((dataRow[BaseItemsEntity.FieldCode, DataRowVersion.Original] != dataRow[BaseItemsEntity.FieldCode, DataRowVersion.Current]) || (dataRow[BaseItemsEntity.FieldFullName, DataRowVersion.Original]) != dataRow[BaseItemsEntity.FieldFullName, DataRowVersion.Current] || (dataRow[BaseItemsEntity.FieldDescription, DataRowVersion.Original] != dataRow[BaseItemsEntity.FieldDescription, DataRowVersion.Current]))
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
            // 检查批量输入的有效性
            if (this.CheckInputBatchSave())
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    DotNetService.Instance.ItemsService.BatchSave(UserInfo, this.DTItems);

                    // 加载窗体
                    this.FormOnLoad();

                    if (BaseSystemInfo.ShowInformation)
                    {
                        // 批量保存，进行提示
                        MessageBox.Show(AppMessage.MSG0012, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
        #endregion

        /// <summary>
        /// 批量保存
        /// </summary>
        public void Save()
        {
            this.BatchSave();
        }

        private void btnBatchSave_Click(object sender, EventArgs e)
        {
            // 保存
            this.Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // 关闭窗体
            this.Close();
        }

        /// <summary>
        /// 数据是否被修改过
        /// </summary>
        /// <returns>是否修改过</returns>
        private bool IsModfied()
        {
            return BaseInterfaceLogic.IsModfiedAnyOne(this.DTItems);
        }

        private void FrmItemsAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BaseInterfaceLogic.IsModfiedAnyOne(this.DTItems))
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

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in this.grdItems_ .Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in this.grdItems_ .Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false);
            }
        }
    }
}