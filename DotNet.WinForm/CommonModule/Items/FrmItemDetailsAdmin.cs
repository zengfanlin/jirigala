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
    /// FrmItemDetailsAdmin.cs
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
    public partial class FrmItemDetailsAdmin : BaseForm, IBaseForm
    {
        private DataTable DTItemDetails = new DataTable(BaseItemDetailsEntity.TableName);           // 基础主键表

        public event SetControlStateEventHandler OnButtonStateChange;

        private bool permissionMove = false;    // 移动

        private string parentId = null;
        /// <summary>
        /// 分类主键
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

        private string targetTable = BaseItemDetailsEntity.TableName;    // 基础主键分类
        /// <summary>
        /// 分类主键
        /// </summary>
        public string TargetTable
        {
            get
            {
                return this.targetTable;
            }
            set
            {
                this.targetTable = value;
            }
        }

        public bool AllowDetails = true;            // 是否允许显示明细部分
        public bool AllowSelectItemDetails = true;  // 是否允许选择

        // 实体主键
        public override string EntityId
        {
            get
            {
                return BaseInterfaceLogic.GetDataGridViewEntityId(this.grdItemDetails, BaseItemDetailsEntity.FieldId);
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

        public FrmItemDetailsAdmin()
        {
            InitializeComponent();
        }

        public FrmItemDetailsAdmin(string targetTable)
            : this()
        {
            this.TargetTable = targetTable;
        }

        private bool OnAdded()
        {
            // 重新加载窗体
            this.FormOnLoad();
            // 设置按钮状态
            this.SetControlState();
            return true;
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.ucTableSort.Enabled = false;
            this.SetSortButton(false);
            this.btnEdit.Enabled = false;
            this.btnExport.Enabled = false;
            this.btnBatchDelete.Enabled = false;
            this.btnBatchSave.Enabled = false;

            this.btnSelectAll.Enabled = false;
            this.btnInvertSelect.Enabled = false;
            // 检查添加组织机构
            this.btnAdd.Enabled = this.permissionAdd;
            if (this.DTItemDetails.DefaultView.Count >= 1)
            {
                this.btnEdit.Enabled = this.permissionEdit;
                this.btnExport.Enabled = this.permissionExport;
                this.btnBatchDelete.Enabled = this.permissionDelete;
                this.btnBatchSave.Enabled = this.permissionEdit;
            }
            // 位置顺序改变按钮部分
            if (this.DTItemDetails.DefaultView.Count > 1)
            {
                this.ucTableSort.Enabled = this.permissionEdit;
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

            if ((this.grdItemDetails.RowCount >= 1))
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
            this.permissionAccess = this.IsModuleAuthorized("ItemDetailsAdmin");    // 访问用基础主键管理
            this.permissionSearch = this.IsAuthorized("ItemDetailsAdmin.Search");    // 查询用户
            this.permissionAdd = this.IsAuthorized("ItemDetailsAdmin.Add");       // 添加用户
            this.permissionEdit = this.IsAuthorized("ItemDetailsAdmin.Edit");      // 编辑用户
            this.permissionMove = this.IsAuthorized("ItemDetailsAdmin.Move");      // 设置密码
            this.permissionExport = this.IsAuthorized("ItemDetailsAdmin.Export");    // 设置密码
            this.permissionDelete = this.IsAuthorized("ItemDetailsAdmin.Delete");    // 删除用户
        }
        #endregion

        #region private void BindData() 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        private void BindData()
        {
            this.txtTargetTable.Text = this.DTItemDetails.TableName;
            this.grdItemDetails.AutoGenerateColumns = false;
            this.DTItemDetails.DefaultView.Sort = BaseItemDetailsEntity.FieldSortCode;
            this.grdItemDetails.DataSource = this.DTItemDetails.DefaultView;
            if (this.grdItemDetails.Rows.Count > 0)
            {
                if (this.CurrentEntityId.Length > 0)
                {
                    this.grdItemDetails.FirstDisplayedScrollingRowIndex = BaseInterfaceLogic.GetRowIndex(this.DTItemDetails, BaseItemDetailsEntity.FieldId, this.CurrentEntityId);
                }
            }
            // 判断编辑权限
            if (!this.permissionEdit)
            {
                // 只读属性设置
                this.grdItemDetails.Columns["colSelected"].ReadOnly = true;
                this.grdItemDetails.Columns["colItemCode"].ReadOnly = true;
                this.grdItemDetails.Columns["colItemName"].ReadOnly = true;
                this.grdItemDetails.Columns["colItemValue"].ReadOnly = true;
                this.grdItemDetails.Columns["colEnabled"].ReadOnly = true;
                // 修改背景颜色
                this.grdItemDetails.Columns["colItemCode"].DefaultCellStyle.BackColor = Color.White;
                this.grdItemDetails.Columns["colItemName"].DefaultCellStyle.BackColor = Color.White;
                this.grdItemDetails.Columns["colItemValue"].DefaultCellStyle.BackColor = Color.White;
                this.grdItemDetails.Columns["colDescription"].DefaultCellStyle.BackColor = Color.White;
            }
            // 设置排序按钮
            this.ucTableSort.DataBind(this.grdItemDetails, this.permissionEdit);
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
                this.DTItemDetails = DotNetService.Instance.ItemDetailsService.GetDataTableByParent(UserInfo, this.TargetTable, this.ParentId);
            }
            else
            {
                this.DTItemDetails = DotNetService.Instance.ItemDetailsService.GetDataTable(UserInfo, this.TargetTable);
            }
            // 绑定屏幕数据
            this.BindData();
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdItemDetails);
            this.GetList();
        }
        #endregion

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = this.txtSearch.Text.Trim();
            if (String.IsNullOrEmpty(search))
            {
                this.DTItemDetails.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                search = StringUtil.GetSearchString(search);
                this.DTItemDetails.DefaultView.RowFilter = StringUtil.GetLike(BaseItemDetailsEntity.FieldItemCode, search)
                        + " OR " + StringUtil.GetLike(BaseItemDetailsEntity.FieldItemName, search)
                        + " OR " + StringUtil.GetLike(BaseItemDetailsEntity.FieldItemValue, search)
                        + " OR " + StringUtil.GetLike(BaseItemDetailsEntity.FieldDescription, search);

            }
            // 设置按钮状态
            this.SetControlState();
        }

        private void btnRoleResourcePermission_Click(object sender, EventArgs e)
        {
            // 资源管理权限
            string permissionItemCode = "Resource.ManagePermission";
            string targetResourceCategory = this.TargetTable;
            string targetResourceSQL = "SELECT " + BaseItemDetailsEntity.FieldId + " AS Id, "
                                        + BaseItemDetailsEntity.FieldItemName + " AS RealName, "
                                        + BaseItemDetailsEntity.FieldDescription + " AS Description FROM "
                                        + this.TargetTable  //BaseItemDetailsEntity.TableName 旧表被废弃，所以更换为新表名
                                        + " WHERE " + BaseItemDetailsEntity.FieldDeletionStateCode + " = 0 AND " + BaseItemDetailsEntity.FieldEnabled + " = 1 ORDER BY " + BaseItemDetailsEntity.FieldSortCode;

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
            string targetResourceCategory = this.TargetTable;
            string targetResourceSQL = "SELECT " + BaseItemDetailsEntity.FieldId + " AS Id, "
                                        + BaseItemDetailsEntity.FieldItemName + " AS RealName, "
                                        + BaseItemDetailsEntity.FieldDescription + " AS Description FROM "
                                        + this.TargetTable //BaseItemDetailsEntity.TableName 旧表被废弃，所以更换为新表名
                                        + " WHERE " + BaseItemDetailsEntity.FieldDeletionStateCode + " = 0 AND " + BaseItemDetailsEntity.FieldEnabled + " = 1 ORDER BY " + BaseItemDetailsEntity.FieldSortCode;

            string assemblyName = "DotNet.WinForm";
            string formName = "FrmUserResourcePermission";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmRoleModulePermission = (Form)Activator.CreateInstance(assemblyType, permissionItemCode, targetResourceCategory, targetResourceSQL);
            frmRoleModulePermission.ShowDialog(this);
        }

        private void ucItemDetailsTreeSelect_SelectedIndexChanged(string parentId)
        {
            this.txtSearch.Text = string.Empty;
            this.ParentId = ParentId;
            this.GetList();
        }

        private void grdItemDetails_Sorted(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (this.permissionEdit)
            {
                string[] sequence = DotNetService.Instance.SequenceService.GetBatchSequence(UserInfo, BaseItemDetailsEntity.TableName, this.DTItemDetails.DefaultView.Count);
                int i = 0;
                foreach (DataRowView dataRowView in this.DTItemDetails.DefaultView)
                {
                    dataRowView.Row[BaseItemDetailsEntity.FieldSortCode] = sequence[i];
                    i++;
                }
                // 控制导航按钮
                this.SetSortButton(false);
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }

        private void grdItemDetails_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // 当前记录是否允许被删除
            BaseItemDetailsEntity ItemDetailsEntity = new BaseItemDetailsEntity();
            DataRow dataRow = BaseBusinessLogic.GetDataRow(this.DTItemDetails, this.EntityId);
            ItemDetailsEntity.GetFrom(dataRow);
            // 判断是否允许删除
            if (ItemDetailsEntity.AllowDelete == 0)
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
                    DotNetService.Instance.ItemDetailsService.Delete(UserInfo, this.TargetTable, this.EntityId);
                }
            }
        }

        private void grdItemDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnEdit.PerformClick();
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

        ///// <summary>
        ///// 当数据变化时
        ///// </summary>
        //private void OnDataChanged()
        //{
        //    // 重新加载窗体
        //    this.FormOnLoad();
        //    // 设置按钮状态
        //    this.SetControlState();
        //}

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns>主键</returns>
        public string Add()
        {
            FrmItemDetailsAdd frmItemDetailsAdd = new FrmItemDetailsAdd();
            frmItemDetailsAdd.ParentId = this.ParentId;
            frmItemDetailsAdd.TargetTableName = this.TargetTable;
            frmItemDetailsAdd.OnAdded+=new FrmItemDetailsAdd.OnAddedEventHandler(this.OnAdded);
            //frmItemDetailsAdd.OnDataChanged += new FrmItemDetailsAdd.OnDataChangedEventHandler(this.OnDataChanged);
            if (frmItemDetailsAdd.ShowDialog(this) == DialogResult.OK)
            {
                // 记录当前选中的主键
                this.CurrentEntityId = frmItemDetailsAdd.EntityId;
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
            string id = BaseInterfaceLogic.GetDataGridViewEntityId(this.grdItemDetails, BaseItemDetailsEntity.FieldId);
            FrmItemDetailsEdit frmItemDetailsEdit = new FrmItemDetailsEdit(id);
            frmItemDetailsEdit.TargetTableName = this.TargetTable;
            if (frmItemDetailsEdit.ShowDialog(this) == DialogResult.OK)
            {
                // 加载窗体
                this.FormOnLoad();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Edit();
        }

        #region private string[] GetSelecteIds() 获得已被选择的编码主键数组
        /// <summary>
        /// 获得已被选择的编码主键数组
        /// </summary>
        /// <returns></returns>
        private string[] GetSelecteIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdItemDetails, BaseItemDetailsEntity.FieldId, "colSelected", true);
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
            FrmItemDetailsTreeSelect FrmItemDetailsTreeSelect = new FrmItemDetailsTreeSelect();
            FrmItemDetailsTreeSelect.OldItemDetailsId = this.EntityId;
            FrmItemDetailsTreeSelect.CheckMove = true;
            FrmItemDetailsTreeSelect.AllowNull = false;
            // 弹出选择窗体
            if (FrmItemDetailsTreeSelect.ShowDialog() == DialogResult.OK)
            {
                targetId = FrmItemDetailsTreeSelect.SelectedId;
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
                    DotNetService.Instance.ItemDetailsService.BatchMoveTo(UserInfo, this.TargetTable, this.GetSelecteIds(), targetId);
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
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdItemDetails, "colSelected"))
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
            this.ExportExcel(this.grdItemDetails, @"\Modules\Export\", exportFileName);
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
            BaseItemDetailsEntity itemDetailsEntity = new BaseItemDetailsEntity();

            foreach (DataGridViewRow dgvRow in grdItemDetails.Rows)
            {
                DataRow dataRow = (dgvRow.DataBoundItem as DataRowView).Row;
                if (dataRow.RowState != DataRowState.Deleted)
                {
                    if ((System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false))
                    {
                        // 是否允许删除
                        itemDetailsEntity.GetFrom(dataRow);
                        if (itemDetailsEntity.AllowDelete == 0)
                        {
                            returnValue = false;
                            MessageBox.Show(AppMessage.Format(AppMessage.MSG0018, itemDetailsEntity.ItemName), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            //foreach (DataRowView dataRowView in this.DTItemDetails.DefaultView)
            //{
            //    DataRow dataRow = dataRowView.Row;
            //    if (dataRow.RowState != DataRowState.Deleted)
            //    {
            //        if (dataRow["colSelected"].ToString() == true.ToString())
            //        {
            //            // 是否允许删除
            //            itemDetailsEntity.GetFrom(dataRow);
            //            if (itemDetailsEntity.AllowDelete == 0)
            //            {
            //                returnValue = false;
            //                MessageBox.Show(AppMessage.Format(AppMessage.MSG0018, itemDetailsEntity.ItemName), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        #region public override void BatchDelete() 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <returns>影响行数</returns>
        public override int BatchDelete()
        {
            return DotNetService.Instance.ItemDetailsService.BatchDelete(UserInfo, this.TargetTable, this.GetSelecteIds());
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
            foreach (DataRow dataRow in this.DTItemDetails.Rows)
            {
                // 这里判断数据的各种状态
                if (dataRow.RowState == DataRowState.Modified)
                {
                    BaseItemDetailsEntity itemDetails = new BaseItemDetailsEntity(dataRow);
                    if (itemDetails.AllowEdit.Equals("0"))
                    {
                        if ((dataRow[BaseItemDetailsEntity.FieldItemName, DataRowVersion.Original] != dataRow[BaseItemDetailsEntity.FieldItemName, DataRowVersion.Current]) || (dataRow[BaseItemDetailsEntity.FieldItemValue, DataRowVersion.Original]) != dataRow[BaseItemDetailsEntity.FieldItemValue, DataRowVersion.Current] || (dataRow[BaseItemDetailsEntity.FieldDescription, DataRowVersion.Original] != dataRow[BaseItemDetailsEntity.FieldDescription, DataRowVersion.Current]))
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
                    DotNetService.Instance.ItemDetailsService.BatchSave(UserInfo, this.DTItemDetails);

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
            return BaseInterfaceLogic.IsModfiedAnyOne(this.DTItemDetails);
        }

        private void FrmItemDetailsAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BaseInterfaceLogic.IsModfiedAnyOne(this.DTItemDetails))
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
            foreach (DataGridViewRow dgvRow in this.grdItemDetails.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in this.grdItemDetails.Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false);
            }
        }
    }
}