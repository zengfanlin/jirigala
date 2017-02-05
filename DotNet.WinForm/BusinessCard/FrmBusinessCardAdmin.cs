//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.IO;

namespace DotNet.WinForm
{    
    using DotNet.Utilities;
    using DotNet.Business;   

    /// <summary>
    /// FrmBusinessCardAdmin.cs
    /// 名片夹管理
    /// 
    /// 自己的名片需要自己能管理。
    /// 名片是否要公开？
    /// 修改公开的名片？
    /// 删除公开的名片？
    /// 导出公开的名片？
    /// 添加评论？
    ///		
    /// 修改记录
    ///     
    ///     2008.11.07 版本：1.0 JiRiGaLa  内部通讯录窗体编写。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.11.07</date>
    /// </author> 
    /// </summary>
    public partial class FrmBusinessCardAdmin : BaseForm
    {
        private DataTable DTBusinessCard = new DataTable(BaseBusinessCardTable.TableName);  // 名片表

        private bool permissionEditPublic   = false;    // 编辑公开的名片权限
        private bool permissionDeletePublic = false;    // 删除公开的名片权限
        private bool permissionExportPublic = false;    // 导出公开的名片权限

        /// <summary>
        /// 权限主键
        /// </summary>
        public override string EntityId
        {
            get
            {
                return BaseInterfaceLogic.GetDataGridViewEntityId(this.grdBusinessCard, BaseStaffEntity.FieldId);
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

        public FrmBusinessCardAdmin()
        {
            InitializeComponent();
        }

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionEditPublic   = this.IsAuthorized("BusinessCardAdmin.EditPublic");   // 编辑公开的名片权限
            this.permissionDeletePublic = this.IsAuthorized("BusinessCardAdmin.DeletePublic"); // 删除公开的名片权限
            this.permissionExportPublic = this.IsAuthorized("BusinessCardAdmin.ExportPublic"); // 导出公开的名片权限
        }
        #endregion

        #region private void DataTableAddColumn() 往DataTable里面添加一列
        /// <summary>
        /// 往DataTable里面添加一列
        /// </summary>
        private void DataTableAddColumn()
        {
            BaseInterfaceLogic.DataTableAddColumn(this.DTBusinessCard, BaseBusinessLogic.SelectedColumn);
        }
        #endregion

        #region private void BindData() 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        private void BindData()
        {
            this.DataTableAddColumn();
            this.grdBusinessCard.AutoGenerateColumns = false;
            this.DTBusinessCard.DefaultView.Sort = BaseBusinessCardTable.FieldSortCode;
            this.grdBusinessCard.DataSource = this.DTBusinessCard.DefaultView;
            this.grdBusinessCard.Refresh();
            if (this.CurrentEntityId.Length > 0)
            {
                this.grdBusinessCard.FirstDisplayedScrollingRowIndex = BaseInterfaceLogic.GetRowIndex(this.DTBusinessCard, BaseStaffEntity.FieldId, this.CurrentEntityId);
            }
            // 过滤数据
            this.SetRowFilter();//this.txtSearch.Text
            // 设置排序按钮
            this.ucTableSort.DataBind(this.grdBusinessCard, this.permissionEdit);
            // 设置按钮状态
            this.SetControlState();
        }
        #endregion

        #region public override void SetControlState() 设置按钮状态
        /// <summary>
        /// 设置按钮状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnEdit.Enabled = false;
            this.btnExport.Enabled = false;
            this.btnBatchSave.Enabled = false;
            this.btnBatchDelete.Enabled = false;

            if (this.DTBusinessCard.DefaultView.Count > 0)
            {
                // 修改背景颜色
                this.grdBusinessCard.Columns["colOfficePhone"].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                this.grdBusinessCard.Columns["colMobile"].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                this.grdBusinessCard.Columns["colEmail"].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                this.grdBusinessCard.Columns["colQQ"].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                this.grdBusinessCard.Columns["colDescription"].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));

                // 判断编辑权限
                if ((this.rbtnAll.Checked || this.rbtnPublic.Checked))
                {
                    // 只读属性设置
                    this.grdBusinessCard.Columns["colOfficePhone"].ReadOnly = !this.permissionEditPublic;
                    this.grdBusinessCard.Columns["colMobile"].ReadOnly = !this.permissionEditPublic;
                    this.grdBusinessCard.Columns["colEmail"].ReadOnly = !this.permissionEditPublic;
                    this.grdBusinessCard.Columns["colQQ"].ReadOnly = !this.permissionEditPublic;
                    this.grdBusinessCard.Columns["colDescription"].ReadOnly = !this.permissionEditPublic;
                    if (!this.permissionEditPublic)
                    {
                        // 修改背景颜色
                        this.grdBusinessCard.Columns["colOfficePhone"].DefaultCellStyle.BackColor = Color.White;
                        this.grdBusinessCard.Columns["colMobile"].DefaultCellStyle.BackColor = Color.White;
                        this.grdBusinessCard.Columns["colEmail"].DefaultCellStyle.BackColor = Color.White;
                        this.grdBusinessCard.Columns["colQQ"].DefaultCellStyle.BackColor = Color.White;
                        this.grdBusinessCard.Columns["colDescription"].DefaultCellStyle.BackColor = Color.White;
                    }
                    this.btnEdit.Enabled = this.permissionEditPublic;
                    this.btnBatchDelete.Enabled = this.permissionDeletePublic;
                    this.btnBatchSave.Enabled = this.permissionEditPublic;
                    this.btnExport.Enabled = this.permissionExportPublic;
                }
                else
                {
                    // 只读属性设置
                    this.grdBusinessCard.Columns["colOfficePhone"].ReadOnly = !this.permissionEdit;
                    this.grdBusinessCard.Columns["colMobile"].ReadOnly = !this.permissionEdit;
                    this.grdBusinessCard.Columns["colEmail"].ReadOnly = !this.permissionEdit;
                    this.grdBusinessCard.Columns["colQQ"].ReadOnly = !this.permissionEdit;
                    this.grdBusinessCard.Columns["colDescription"].ReadOnly = !this.permissionEdit;

                    if (!this.permissionEdit)
                    {
                        // 修改背景颜色
                        this.grdBusinessCard.Columns["colOfficePhone"].DefaultCellStyle.BackColor = Color.White;
                        this.grdBusinessCard.Columns["colMobile"].DefaultCellStyle.BackColor = Color.White;
                        this.grdBusinessCard.Columns["colEmail"].DefaultCellStyle.BackColor = Color.White;
                        this.grdBusinessCard.Columns["colQQ"].DefaultCellStyle.BackColor = Color.White;
                        this.grdBusinessCard.Columns["colDescription"].DefaultCellStyle.BackColor = Color.White;
                    }
                    this.btnEdit.Enabled = this.permissionEdit;
                    this.btnBatchDelete.Enabled = this.permissionDelete;
                    this.btnBatchSave.Enabled = this.permissionEdit;
                    this.btnExport.Enabled = this.permissionExport;
                }
            }
            if (this.rbtnPublic.Checked)
            {
                this.SetSortButton(this.permissionEditPublic);
            }
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            //加载DGV列头重绘事件
            this.DataGridViewOnLoad(grdBusinessCard);
            // 检查用户是否登录
            this.CheckLogOn();
            // 获取全部列表
            this.Search();
            // 设置排序按钮
            this.ucTableSort.DataBind(this.grdBusinessCard, this.permissionEdit);

            /*
            // 这里是按列的数据权限的权限进行数据绑定的例子代码
            // 这里是当前用户能访问的列名
            TableColumnsService tableColumnsService = new TableColumnsService();
            string[] accessColumns = tableColumnsService.GetColumns(this.UserInfo, BaseBusinessCardTable.TableName, "Column.Access");
            // 设置为只能访问的列
            BaseInterfaceLogic.SetColumns(this.grdBusinessCard, accessColumns);

            string[] editColumns = tableColumnsService.GetColumns(this.UserInfo, BaseBusinessCardTable.TableName, "Column.Edit");
            // 设置为可编辑列
            BaseInterfaceLogic.SetEditColumns(this.grdBusinessCard, editColumns);

            // 拒绝访问的权限列名获取
            string[] deneyColumns = tableColumnsService.GetColumns(this.UserInfo, BaseBusinessCardTable.TableName, "Column.Deney");
            BaseInterfaceLogic.RemoveColumns(this.grdBusinessCard, deneyColumns);
            */
        }
        #endregion

        #region private void Search()
        /// <summary>
        /// 获取部门列表
        /// </summary>
        private void Search()
        {
            BusinessCardService businessCardService = new BusinessCardService();
            // 获取数据
            if (this.rbtnPersonal.Checked)
            {
                this.DTBusinessCard = businessCardService.GetDataTableByUser(UserInfo);
            }
            else
            {
                if (this.rbtnPublic.Checked)
                {
                    this.DTBusinessCard = businessCardService.GetPublicDT(UserInfo);
                }
                else
                {
                    if (this.rbtnAll.Checked)
                    {
                        this.DTBusinessCard = businessCardService.GetDataTable(UserInfo);
                    }
                }
            }
            // 绑定屏幕数据
            this.BindData();
        }
        #endregion

        private void Search(string organizeId)
        {
            // 获取数据
            BusinessCardService businessCardService = new BusinessCardService();
            this.DTBusinessCard = businessCardService.GetDataTable(UserInfo);
            // 绑定屏幕数据
            this.BindData();
        }

        #region private void CheckLogOn()
        /// <summary>
        /// 检查用户是否登录
        /// </summary>
        private void CheckLogOn()
        {
            if (!BaseSystemInfo.UserIsLogOn)
            {
                this.rbtnPersonal.Checked = true;
                this.rbtnPersonal.Visible = false;
                this.rbtnPublic.Visible = false;
                this.rbtnAll.Visible = false;
            }
            else
            {
                this.rbtnPublic.Checked = true;
                this.rbtnAll.Visible = UserInfo.IsAdministrator;
            }
        }
        #endregion

        /// <summary>
        /// 获取全部列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                if (this.rbtnAll.Checked)
                {
                    // 获取全部列表
                    this.Search();
                }
            }
        }
        /// <summary>
        /// 获取公开列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnPublic_CheckedChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                if (this.rbtnPublic.Checked)
                {
                    // 获取全部列表
                    this.Search();
                }
            }
        }
        /// <summary>
        /// 获取私有列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnPersonal_CheckedChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                if (this.rbtnPersonal.Checked)
                {
                    // 获取全部列表
                    this.Search();
                }
            }
        }

        private void grdStaffAddress_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnEdit.PerformClick();
        }

        /// <summary>
        /// 过滤数据
        /// </summary>
        /// <param name="search">查询条件</param>
        /*private void SetRowFilter(string searchValue)
        {
            if (String.IsNullOrEmpty(searchValue))
            {
                this.DTBusinessCard.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                searchValue = StringUtil.GetSearchString(searchValue);
                this.DTBusinessCard.DefaultView.RowFilter = BaseBusinessCardTable.FieldFullName + " LIKE '" + searchValue + "'"
                    + " OR " + BaseBusinessCardTable.FieldTitle + " LIKE '" + searchValue + "'"
                    + " OR " + BaseBusinessCardTable.FieldCompany + " LIKE '" + searchValue + "'"
                    + " OR " + BaseBusinessCardTable.FieldPhone + " LIKE '" + searchValue + "'"
                    + " OR " + BaseBusinessCardTable.FieldPostalcode + " LIKE '" + searchValue + "'"
                    + " OR " + BaseBusinessCardTable.FieldMobile + " LIKE '" + searchValue + "'"
                    + " OR " + BaseBusinessCardTable.FieldAddress + " LIKE '" + searchValue + "'"
                    + " OR " + BaseBusinessCardTable.FieldEmail + " LIKE '" + searchValue + "'"
                    + " OR " + BaseBusinessCardTable.FieldOfficePhone + " LIKE '" + searchValue + "'"
                    + " OR " + BaseBusinessCardTable.FieldQQ + " LIKE '" + searchValue + "'"
                    + " OR " + BaseBusinessCardTable.FieldFax + " LIKE '" + searchValue + "'"
                    + " OR " + BaseBusinessCardTable.FieldWeb + " LIKE '" + searchValue + "'"
                    + " OR " + BaseBusinessCardTable.FieldBankName + " LIKE '" + searchValue + "'"
                    + " OR " + BaseBusinessCardTable.FieldBankAccount + " LIKE '" + searchValue + "'"
                    + " OR " + BaseBusinessCardTable.FieldTaxAccount + " LIKE '" + searchValue + "'"
                    + " OR " + BaseBusinessCardTable.FieldDescription + " LIKE '" + searchValue + "'";
            }
        }*/


        private void SetRowFilter()
        {
            string search = this.txtSearch.Text.Trim();
            if (String.IsNullOrEmpty(search))
            {
                this.DTBusinessCard.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                if (this.DTBusinessCard.Columns.Count > 1)
                {
                    string rowFilter = string.Empty;
                    search = StringUtil.GetSearchString(search);
                    rowFilter = StringUtil.GetLike(BaseBusinessCardTable.FieldFullName, search)
                        + " OR " + StringUtil.GetLike(BaseBusinessCardTable.FieldTitle, search)
                        + " OR " + StringUtil.GetLike(BaseBusinessCardTable.FieldCompany, search)
                        + " OR " + StringUtil.GetLike(BaseBusinessCardTable.FieldPhone, search)
                        + " OR " + StringUtil.GetLike(BaseBusinessCardTable.FieldPostalcode, search)
                        + " OR " + StringUtil.GetLike(BaseBusinessCardTable.FieldMobile, search)
                        + " OR " + StringUtil.GetLike(BaseBusinessCardTable.FieldAddress, search)
                        + " OR " + StringUtil.GetLike(BaseBusinessCardTable.FieldEmail, search)
                        + " OR " + StringUtil.GetLike(BaseBusinessCardTable.FieldOfficePhone, search)
                        + " OR " + StringUtil.GetLike(BaseBusinessCardTable.FieldQQ, search)
                        + " OR " + StringUtil.GetLike(BaseBusinessCardTable.FieldFax, search)
                        + " OR " + StringUtil.GetLike(BaseBusinessCardTable.FieldWeb, search)
                        + " OR " + StringUtil.GetLike(BaseBusinessCardTable.FieldBankName, search)
                        + " OR " + StringUtil.GetLike(BaseBusinessCardTable.FieldBankAccount, search)                        
                        + " OR " + StringUtil.GetLike(BaseBusinessCardTable.FieldDescription, search);
                    this.DTBusinessCard.DefaultView.RowFilter = rowFilter;
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //string search = this.txtSearch.Text.Trim();
            // 过滤数据
            this.SetRowFilter();
            // 设置按钮状态
            this.SetControlState();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                // 获取全部列表
                this.Search();
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

        public void SetSortButton(bool enabled)
        {
            this.ucTableSort.SetSortButton(enabled);
        }

        private void grdBusinessCard_Sorted(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (this.permissionEdit)
            {
                SequenceService sequenceService = new SequenceService();
                string[] sequence = sequenceService.GetBatchSequence(UserInfo, BaseBusinessCardTable.TableName, this.DTBusinessCard.DefaultView.Count);
                int i = 0;
                foreach (DataRowView DataRowView in this.DTBusinessCard.DefaultView)
                {
                    DataRowView.Row[BaseBusinessCardTable.FieldSortCode] = sequence[i];
                    i++;
                }
                // 控制导航按钮
                this.SetSortButton(false);
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmBusinessCardAdd frmBusinessCardAdd = new FrmBusinessCardAdd(this.rbtnPersonal.Checked);
            frmBusinessCardAdd.ShowDialog();
            if (frmBusinessCardAdd.Changed)
            {
                // 获取列表
                this.Search();
            }
        }

        /// <summary>
        /// 编辑
        /// </summary>
        public void Edit()
        {
            DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdBusinessCard);
            BaseBusinessCardEntity businessCardEntity = new BaseBusinessCardEntity(dataRow);
            // 有权限编辑
            if (this.permissionEditPublic || businessCardEntity.CreateUserId.Equals(UserInfo.Id))
            {
                string id = BaseInterfaceLogic.GetDataGridViewEntityId(this.grdBusinessCard, BaseItemDetailsEntity.FieldId);
                FrmBusinessCardEdit frmBusinessCardEdit = new FrmBusinessCardEdit(id);
                if (frmBusinessCardEdit.ShowDialog() == DialogResult.OK)
                {
                    // 获取列表
                    this.Search();
                }
            }
            else
            {
                // 没有权限编辑公开的名片
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
        /// <returns>选中的主键</returns>
        private string[] GetSelecteIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.DTBusinessCard, BaseBusinessCardTable.FieldId, BaseBusinessLogic.SelectedColumn);
        }
        #endregion

        #region private bool CheckInputBatchDelete() 检查批量删除的输入的有效性
        /// <summary>
        /// 检查批量删除的输入的有效性
        /// </summary>
        /// <returns>允许批量删除</returns>
        private bool CheckInputBatchDelete()
        {
            bool returnValue = false;
            int selectedCount = 0;
            BaseBusinessCardEntity businessCardEntity = new BaseBusinessCardEntity();
            foreach (DataRowView DataRowView in this.DTBusinessCard.DefaultView)
            {
                DataRow dataRow = DataRowView.Row;
                if (dataRow.RowState != DataRowState.Deleted)
                {
                    if (dataRow[BaseBusinessLogic.SelectedColumn].ToString() == true.ToString())
                    {
                        businessCardEntity = new BaseBusinessCardEntity(dataRow);
                        // 有权限删除
                        if (this.permissionEditPublic || businessCardEntity.CreateUserId.Equals(UserInfo.Id))
                        {
                            selectedCount ++;
                        }
                        else
                        {
                            // MessageBox.Show(AppMessage.MSG0024, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return returnValue;
                        }
                    }
                }
            }
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
            BusinessCardService businessCardService = new BusinessCardService();
            return businessCardService.BatchDelete(UserInfo, this.GetSelecteIds());
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
                        // 获取列表
                        this.Search();
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 导出Excel
            //string exportFileName = this.Text + ".csv";
            string exportFileName = this.Text + ".xls";
            this.ExportExcel(this.grdBusinessCard , @"\Modules\Export\", exportFileName);
        }

        #region private void BatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private void BatchSave()
        {
            // 去掉未修改的数据，提高运行速度
            for (int i = this.DTBusinessCard.Rows.Count - 1; i >= 0; i--)
            {
                if (this.DTBusinessCard.Rows[i].RowState == DataRowState.Unchanged)
                {
                    this.DTBusinessCard.Rows.RemoveAt(i);
                }
            }
            BusinessCardService businessCardService = new BusinessCardService();
            businessCardService.BatchSave(UserInfo, this.DTBusinessCard);
            // 获取列表
            this.Search();
            if (BaseSystemInfo.ShowInformation)
            {
                // 批量保存，进行提示
                MessageBox.Show(AppMessage.MSG0012, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        private void btnBatchSave_Click(object sender, EventArgs e)
        {
            // 检查批量输入的有效性
            if (BaseInterfaceLogic.CheckInputModifyAnyOne(this.DTBusinessCard))
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
                    this.DTBusinessCard.AcceptChanges();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            // 关闭窗体
            this.Close();
        }

        private void FrmBusinessCardAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BaseInterfaceLogic.IsModfiedAnyOne(this.DTBusinessCard))
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
    }
}