//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;
    
    /// <summary>
    /// FrmSequenceAdmin.cs
    /// 序号发生器窗体
    ///		
    /// 修改记录
    ///
    ///     2007.06.07 版本：1.0 JiRiGaLa  页面创建
    ///     2010.01.25 版本：1.1 JiRiGaLa  序列生成器、按序列名字排序
    ///     2012.04.23 版本：1.0 zwd       修改单击选择一行，默认全部显示不选择.
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.06.07</date>
    /// </author> 
    /// </summary>
    public partial class FrmSequenceAdmin : BaseForm
    {
        private DataTable DTSequence = new DataTable(BaseSequenceEntity.TableName);

        /// <summary>
        /// 表格中的序列主键
        /// </summary>
        public string CurrentEntityId
        {
            get
            {
                return BaseInterfaceLogic.GetDataGridViewEntityId(this.grdSequence, BaseSequenceEntity.FieldId);
            }
        }

        public FrmSequenceAdmin()
        {
            InitializeComponent();
        }

        private bool OnAdded()
        {
            // 获得序列列表
            this.GetList();
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
            this.btnSelectAll.Enabled = false;
            this.btnInvertSelect.Enabled = false;
            this.btnAdd.Enabled = true ;
            this.btnEdit.Enabled = false;
            this.btnReset.Enabled = false;
            this.btnExport.Enabled = false;
            this.btnDelete.Enabled = false;

            if (this.DTSequence.DefaultView.Count == 0)
            {
                this.btnDelete.Enabled = false;
            }
            if (this.DTSequence.DefaultView.Count > 1)
            {
                this.btnSelectAll.Enabled = this.permissionEdit || this.permissionDelete || this.permissionExport;
                this.btnInvertSelect.Enabled = this.permissionEdit || this.permissionDelete || this.permissionExport;
                this.btnAdd.Enabled = this.permissionAdd;
                this.btnEdit.Enabled = this.permissionEdit;
                this.btnReset.Enabled = this.permissionEdit;
                this.btnExport.Enabled = this.permissionExport;
                this.btnDelete.Enabled = this.permissionDelete;
            }
            if (!this.permissionDelete)
            {
                this.colSelected.ReadOnly = !this.permissionDelete;
            }
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {

            // 这个是范围权限，对哪些（模块）有模块访问的权限？
            // this.permissionAccess = this.IsModuleAuthorized("FrmSequenceAdmin");
            this.permissionAccess = this.IsModuleAuthorized(this.Name);

            // 这些是操作权限，当前用户有什么相应的操作权限？
            this.permissionAdd = this.IsAuthorized("SequenceAdmin.Add");
            this.permissionEdit = this.IsAuthorized("SequenceAdmin.Edit");
            this.permissionExport = this.IsAuthorized("SequenceAdmin.Export");
            this.permissionDelete = this.IsAuthorized("SequenceAdmin.Delete");
        }
        #endregion

        #region public override void GetList() 获得序列数据
        /// <summary>
        /// 获得序列数据
        /// </summary>
        public override void GetList()
        {
            // 序列信息
            this.DTSequence = DotNetService.Instance.SequenceService.GetDataTable(UserInfo);
            this.DTSequence.DefaultView.Sort = BaseSequenceEntity.FieldFullName;
            this.DTSequence.DefaultView.RowFilter = BaseSequenceEntity.FieldIsVisible + " = '1'";
            this.grdSequence.AutoGenerateColumns = false;
            this.grdSequence.DataSource = this.DTSequence.DefaultView;
            this.grdSequence.Refresh();
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdSequence);
            // 获得序列数据
            this.GetList();

            // 默认隐藏查询到的数据 方便使用组件过滤。
            this.chkAll.Checked = false;
            this.HideInvisible();
        }
        #endregion

        private void Search()
        {
            string search = this.txtSearch.Text.Trim();
            if (String.IsNullOrEmpty(search))
            {
                this.DTSequence.DefaultView.RowFilter = string.Empty;
            }
            else
            {

                search = StringUtil.GetSearchString(search);
                this.DTSequence.DefaultView.RowFilter =
                    /* BaseSequenceEntity.FieldFullName + " LIKE '*" + search + "*'";*/

                  //+" OR " + BaseSequenceEntity.FieldSequence + " LIKE " + Convert.ToInt32(search) + ""
                    //+ " OR " + BaseSequenceEntity.FieldReduction + " LIKE " + Convert.ToInt32(search) + ""
                    //+ " OR " + BaseSequenceEntity.FieldStep + " LIKE " + Convert.ToInt32(search) + "";

                  StringUtil.GetLike(BaseSequenceEntity.FieldFullName, search);
                        //+ " OR " + StringUtil.GetLike(BaseSequenceEntity.FieldSequence, search)
                        //+ " OR " + StringUtil.GetLike(BaseSequenceEntity.FieldReduction, search)
                        //+ " OR " + StringUtil.GetLike(BaseSequenceEntity.FieldStep, search)

            }
            // 设置按钮状态
            this.SetControlState();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void grdSequence_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnEdit.PerformClick();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dgvRow in grdSequence.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }
            //foreach (DataRow dataRow in this.DTSequence.Rows)
            //{
            //    dataRow["colSelected"] = true.ToString();
            //}
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dgvRow in grdSequence.Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value??false);
            }
            //foreach (DataRow dataRow in this.DTSequence.Rows)
            //{
            //    if (dataRow["colSelected"].ToString() == true.ToString())
            //    {
            //        dataRow["colSelected"] = false.ToString();
            //    }
            //    else
            //    {
            //        dataRow["colSelected"] = true.ToString();
            //    }
            //}
        }

        #region public string Add() 添加序列
        /// <summary>
        /// 添加序列
        /// </summary>
        /// <returns>主键</returns>
        public string Add()
        {
            string returnValue = string.Empty;
            FrmSequenceAdd frmSequenceAdd = new FrmSequenceAdd();
            frmSequenceAdd.OnAdded+=new FrmSequenceAdd.OnAddedEventHandler(OnAdded);
            frmSequenceAdd.ShowDialog(this);
            if (frmSequenceAdd.Changed)
            {
                returnValue = frmSequenceAdd.EntityId;
                // 获得序列列表
                this.GetList();
                // 设置按钮状态
                this.SetControlState();
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
            FrmSequenceEdit frmSequenceEdit = new FrmSequenceEdit(this.CurrentEntityId);
            if (frmSequenceEdit.ShowDialog(this) == DialogResult.OK)
            {
                // 获得序列列表
                this.GetList();
                // 设置按钮状态
                this.SetControlState();
                this.chkAll.Checked = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Edit();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 导出Excel
            //string exportFileName = this.Text + ".csv";
            string exportFileName = this.Text + ".xls";
            this.ExportExcel(this.grdSequence , @"\Modules\Export\", exportFileName);
        }

        #region private string[] GetSelecteIds() 获得已被选择的部门主键数组
        /// <summary>
        /// 获得已被选择的部门主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelecteIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdSequence, BaseSequenceEntity.FieldId, "colSelected", true);
        }
        #endregion

        #region private void DoReSet() 重置
        /// <summary>
        /// 重置
        /// </summary>
        private void DoReSet()
        {
            string[] ids = this.GetSelecteIds();
            if (ids.Length > 0)
            {
                DotNetService.Instance.SequenceService.Reset(UserInfo, ids);
                MessageBox.Show(AppMessage.MSG0218, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.GetList();
            }
            else
            {
                MessageBox.Show(AppMessage.MSGC023, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdSequence, "colSelected"))
            {
                if (MessageBox.Show(AppMessage.MSG0219, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    // 设置鼠标繁忙状态，并保留原先的状态
                    Cursor holdCursor = this.Cursor;
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        // 重置序列
                        this.DoReSet();
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
        }

        #region private bool CheckInputBatchDelete() 检查批量删除的输入的有效性
        /// <summary>
        /// 检查批量删除的输入的有效性
        /// </summary>
        /// <returns>允许批量删除</returns>
        private bool CheckInputBatchDelete()
        {
            bool returnValue = false;
            // 检查至少要选择一个？
            if (!BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdSequence, "colSelected"))
            {
                return returnValue;
            }
            int selectedCount = 0;
            BaseSequenceEntity sequenceEntity = new BaseSequenceEntity();

            foreach (DataGridViewRow dgvRow in grdSequence.Rows)
            {
                DataRow dataRow = (dgvRow.DataBoundItem as DataRowView).Row;
                if (dataRow.RowState != DataRowState.Deleted)
                {
                    if ((System.Boolean)(dgvRow.Cells["colSelected"].Value??false))
                    {
                        sequenceEntity = new BaseSequenceEntity(dataRow);
                        // 有权限删除
                        if (!sequenceEntity.FullName.Equals("BaseSequence"))
                        {
                            selectedCount++;
                        }
                        else
                        {
                            MessageBox.Show(AppMessage.Format(AppMessage.MSG0018, "BaseSequence"), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return returnValue;
                        }
                    }
                }
            }

            //foreach (DataRowView dataRowView in this.DTSequence.DefaultView)
            //{
            //    DataRow dataRow = dataRowView.Row;
            //    if (dataRow.RowState != DataRowState.Deleted)
            //    {
            //        if (dataRow["colSelected"].ToString() == true.ToString())
            //        {
            //            sequenceEntity = new BaseSequenceEntity(dataRow);
            //            // 有权限删除
            //            if (!sequenceEntity.FullName.Equals("BaseSequence"))
            //            {
            //                selectedCount++;
            //            }
            //            else
            //            {
            //                MessageBox.Show(AppMessage.Format(AppMessage.MSG0018, "BaseSequence"), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                return returnValue;
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
        public override int BatchDelete()
        {
            int returnValue = 0;
            returnValue = DotNetService.Instance.SequenceService.BatchDelete(UserInfo, this.GetSelecteIds());
            // 绑定屏幕数据
            this.GetList();
            // 设置按钮状态
            this.SetControlState();
            return returnValue;
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
                        this.BatchDelete();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 删除
            this.Delete();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 隐藏不可见项
        /// </summary>
        private void HideInvisible()
        {
            string strShowAll = this.chkAll.Checked ? "" : "1";
            if (String.IsNullOrEmpty(strShowAll))
            {
                this.DTSequence.DefaultView.RowFilter = string.Empty;
                this.chkAll.Checked = true;
                // btnHide.Enabled = true;
            }
            else
            {
                this.DTSequence.DefaultView.RowFilter = BaseSequenceEntity.FieldIsVisible + " = '1'";
                this.chkAll.Checked = false;
                // btnHide.Enabled = false;
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkAll.Checked)
            {
                chkAll.Enabled = true;
                //btnHide.Enabled = false ;
            }
            // 获得序列列表
            this.GetList();
            this.HideInvisible();
            // 设置按钮状态
            this.SetControlState();
        }

        #region private int SetInvisible()
        /// <summary>
        /// 设置当前所有选中的记录为隐藏状态
        /// </summary>
        /// <returns>设置更新成功</returns>
        private bool SetInvisible()
        {
            bool returnValue = false;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            // 检查至少要选择一个
            if (!BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdSequence, "colSelected"))
            {
                return returnValue;
            }
            int selectedCount = 0;
            BaseSequenceEntity sequenceEntity = new BaseSequenceEntity();
            BaseSequenceManager sequenceManager = new BaseSequenceManager(this.UserInfo);

            foreach (DataGridViewRow dgvRow in grdSequence.Rows)
            {
                DataRow dataRow = (dgvRow.DataBoundItem as DataRowView).Row;
                if (dataRow.RowState != DataRowState.Deleted)
                {
                    if ((System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false))
                    {
                        sequenceEntity = new BaseSequenceEntity(dataRow);
                        // 记录BaseSequence不能被隐藏
                        if (!sequenceEntity.FullName.Equals("BaseSequence"))
                        {
                            selectedCount++;
                            sequenceEntity.IsVisible = 0;
                            //sequenceManager.Update(sequenceEntity);该方法调用不成，所以使用了下面调用服务方法更新，待优化
                            int rowCount = DotNetService.Instance.SequenceService.Update(UserInfo, sequenceEntity, out statusCode, out statusMessage);
                        }
                        else
                        {
                            MessageBox.Show(AppMessage.Format(AppMessage.MSG0018, "BaseSequence"), AppMessage.MSG0020, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return returnValue;
                        }
                    }
                }
            }

            // 被选中记录中被设置隐藏的次数
            returnValue = selectedCount > 0;
            if (!returnValue)
            {
                MessageBox.Show(AppMessage.MSG0024, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return returnValue;
        }
        #endregion

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.SetInvisible();
            this.chkAll.Checked = false;
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdSequence);
            // 获得序列数据
            this.GetList();

            // 默认隐藏查询到的数据 方便使用组件过滤。
            this.chkAll.Checked = false;
            this.HideInvisible();
            this.SetControlState();
        }
    }
}