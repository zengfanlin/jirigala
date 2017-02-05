//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;
    
    /// <summary>
    /// FrmStaffAddressAdmin.cs
    /// 内部通讯录窗体
    ///		
    /// 修改记录
    ///     
    ///     2007.06.12 版本：1.0 JiRiGaLa  内部通讯录窗体编写。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.06.11</date>
    /// </author> 
    /// </summary>
    public partial class FrmStaffAddressAdmin : BaseForm
    {
        private DataTable DTStaff = new DataTable(BaseStaffEntity.TableName);    // 员工 DataTable

        /// <summary>
        /// 权限主键
        /// </summary>
        public override string EntityId
        {
            get
            {
                return BaseInterfaceLogic.GetDataGridViewEntityId(this.grdStaffAddress, BaseStaffEntity.FieldId);
            }
        }

        public string OrganizeId
        {
            get
            {
                return this.ucOrganize.SelectedId;
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

        public FrmStaffAddressAdmin()
        {
            InitializeComponent();
        }

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAccess = this.IsModuleAuthorized("StaffAdmin");  // 访问权限
            this.permissionAdd = this.IsAuthorized("StaffAdmin.Add");     // 新增权限
            this.permissionEdit = this.IsAuthorized("StaffAdmin.Edit");    // 编辑权限
            this.permissionDelete = this.IsAuthorized("StaffAdmin.Delete");  // 删除权限
            this.permissionExport = this.IsAuthorized("StaffAdmin.Export");  // 导出权限
        }
        #endregion

        #region private void BindData() 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        private void BindData()
        {
            // 获取表格的权限
            this.GetPermission();
            this.grdStaffAddress.AutoGenerateColumns = false;
            this.grdStaffAddress.DataSource = this.DTStaff.DefaultView;
            this.grdStaffAddress.Refresh();
            if (this.CurrentEntityId.Length > 0)
            {
                this.grdStaffAddress.FirstDisplayedScrollingRowIndex = BaseInterfaceLogic.GetRowIndex(this.DTStaff, BaseStaffEntity.FieldId, this.CurrentEntityId);
            }
            // 设置按钮状态
            this.SetControlState();
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            if (this.DTStaff.DefaultView.Count > 0)
            {
                this.btnBatchSave.Enabled = this.permissionEdit;
                this.btnEdit.Enabled = this.permissionEdit;
                this.btnExport.Enabled = this.permissionExport;
                // this.btnSendEmail.Enabled = this.permissionExport;
            }
            else
            {
                this.btnBatchSave.Enabled = false;
                this.btnEdit.Enabled = false;
                this.btnExport.Enabled = false;
            }
            // 判断编辑权限
            if (!this.permissionEdit)
            {
                // 只读属性设置
                this.grdStaffAddress.Columns["colTel"].ReadOnly         = true;
                this.grdStaffAddress.Columns["colMobile"].ReadOnly      = true;
                this.grdStaffAddress.Columns["colShortNumber"].ReadOnly = true;
                this.grdStaffAddress.Columns["colEmail"].ReadOnly       = true;
                this.grdStaffAddress.Columns["colOICQ"].ReadOnly        = true;
                this.grdStaffAddress.Columns["colDescription"].ReadOnly = true;
                // 修改背景颜色
                this.grdStaffAddress.Columns["colTel"].DefaultCellStyle.BackColor           = Color.White;
                this.grdStaffAddress.Columns["colMobile"].DefaultCellStyle.BackColor        = Color.White;
                this.grdStaffAddress.Columns["colShortNumber"].DefaultCellStyle.BackColor   = Color.White;
                this.grdStaffAddress.Columns["colEmail"].DefaultCellStyle.BackColor         = Color.White;
                this.grdStaffAddress.Columns["colOICQ"].DefaultCellStyle.BackColor          = Color.White;
                this.grdStaffAddress.Columns["colDescription"].DefaultCellStyle.BackColor   = Color.White;
                this.btnEdit.Enabled = false;
            }
            // 空表示全部
            this.btnAdd.Enabled = this.permissionAdd;
            // this.btnAll.Enabled = !String.IsNullOrEmpty(this.ucOrganize.SelectedId); 
            // 当前用户是否为员工
            this.btnMyAddress.Enabled = !String.IsNullOrEmpty(UserInfo.StaffId);
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdStaffAddress);
            //设置每页显示的数量
            pager.PageSize = 20;
            // 获取全部列表
            this.Search();
        }
        #endregion

        #region private void Search() 获取部门列表
        /// <summary>
        /// 获取部门列表
        /// </summary>
        private void Search()
        {
            // 获取数据
            //this.DTStaff = DotNetService.Instance.StaffService.GetAddressDT(UserInfo, this.ucOrganize.SelectedId, this.txtSearch.Text);
            int recordCount = 0;
            DotNetService dotNetService = new DotNetService();
            // 获取数据
            this.DTStaff = dotNetService.StaffService.GetAddressDataTableByPage(UserInfo, this.ucOrganize.SelectedId, this.txtSearch.Text, pager.PageSize, pager.PageIndex, out recordCount);
            if (dotNetService.StaffService is ICommunicationObject)
            {
                ((ICommunicationObject)dotNetService.StaffService).Close();
            }
            pager.RecordCount = recordCount;
            pager.InitPageInfo();
            // 绑定屏幕数据
            this.BindData();
        }
        #endregion

        private void Search(string organizeId)
        {
            int recordCount = 0;
            DotNetService dotNetService = new DotNetService();
            // 获取数据
            this.DTStaff = dotNetService.StaffService.GetAddressDataTableByPage(UserInfo, organizeId, this.txtSearch.Text, pager.PageSize, pager.PageIndex, out recordCount);
            if (dotNetService.StaffService is ICommunicationObject)
            {
                ((ICommunicationObject)dotNetService.StaffService).Close();
            }
            pager.RecordCount = recordCount;
            pager.InitPageInfo();
            // 绑定屏幕数据
            this.BindData();
        }

        private void grdStaffAddress_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnEdit.PerformClick();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            this.ucOrganize.SetNull();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = this.txtSearch.Text.Trim();
            if (String.IsNullOrEmpty(search))
            {
                this.DTStaff.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                search = StringUtil.GetSearchString(search);
                this.DTStaff.DefaultView.RowFilter = 
                    
                    /*BaseStaffEntity.FieldRealName + " LIKE '" + search + "'"
                    + " OR DepartmentName LIKE '" + search + "'"
                    + " OR DutyName LIKE '" + search + "'"
                    + " OR " + BaseStaffEntity.FieldOfficePhone + " LIKE '" + search + "'"
                    + " OR " + BaseStaffEntity.FieldMobile + " LIKE '" + search + "'"
                    + " OR " + BaseStaffEntity.FieldShortNumber + " LIKE '" + search + "'"
                    + " OR " + BaseStaffEntity.FieldEmail + " LIKE '" + search + "'"
                    + " OR " + BaseStaffEntity.FieldShortNumber + " LIKE '" + search + "'"
                    + " OR " + BaseStaffEntity.FieldDescription + " LIKE '" + search + "'";*/

                    StringUtil.GetLike(BaseStaffEntity.FieldRealName, search)
                        //+" OR " + StringUtil.GetLike(DepartmentName, search)
                        //+ " OR " + StringUtil.GetLike(DutyName, search)

                        + " OR " + StringUtil.GetLike(BaseStaffEntity.FieldOfficePhone, search)
                        + " OR " + StringUtil.GetLike(BaseStaffEntity.FieldMobile, search)
                        + " OR " + StringUtil.GetLike(BaseStaffEntity.FieldShortNumber, search)
                        + " OR " + StringUtil.GetLike(BaseStaffEntity.FieldEmail, search)
                        + " OR " + StringUtil.GetLike(BaseStaffEntity.FieldDescription, search);
            }
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


        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Add();       
        }

        public string Add()
        {
            FrmStaffAdd frmStaffAdd = new FrmStaffAdd();
            if (frmStaffAdd.ShowDialog(this) == DialogResult.OK)
            {
                // 记录当前选中的主键
                this.CurrentEntityId = frmStaffAdd.EntityId;
                // 加载窗体
                this.FormOnLoad();
            }
            return this.CurrentEntityId;
        }

        private void btnMyAddress_Click(object sender, EventArgs e)
        {
            FrmStaffAddressEdit frmStaffAddressEdit = new FrmStaffAddressEdit(UserInfo.StaffId);
            if (frmStaffAddressEdit.ShowDialog(this) == DialogResult.OK)
            {
                // 记录当前选中的主键
                this.CurrentEntityId = this.EntityId;
                // 加载窗体
                this.FormOnLoad();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 导出Excel
            //string exportFileName = this.Text + ".csv";
            string exportFileName = this.Text + ".xls";
            this.ExportExcel(this.grdStaffAddress , @"\Modules\Export\", exportFileName);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = BaseInterfaceLogic.GetDataGridViewEntityId(this.grdStaffAddress, BaseStaffEntity.FieldId);
            FrmStaffAddressEdit frmStaffAddressEdit = new FrmStaffAddressEdit(id);
            if (frmStaffAddressEdit.ShowDialog(this) == DialogResult.OK)
            {
                // 记录当前选中的主键
                this.CurrentEntityId = this.EntityId;
                // 加载窗体
                this.FormOnLoad();
            }
        }

        #region private void BatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private void BatchSave()
        {
            // 去掉未修改的数据，提高运行速度
            for (int i = this.DTStaff.Rows.Count - 1; i >= 0; i--)
            {
                if (this.DTStaff.Rows[i].RowState == DataRowState.Unchanged)
                {
                    this.DTStaff.Rows.RemoveAt(i);
                }
            }
            List<BaseStaffEntity> staffEntites = new List<BaseStaffEntity>();
            for (int i = 0; i < this.DTStaff.Rows.Count; i++)
            {
                BaseStaffEntity staffEntity = new BaseStaffEntity(this.DTStaff.Rows[i]);
                staffEntites.Add(staffEntity);
            }
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            DotNetService.Instance.StaffService.BatchUpdateAddress(this.UserInfo, staffEntites, out statusCode, out statusMessage);
            this.DTStaff = DotNetService.Instance.StaffService.GetAddressDataTable(UserInfo, this.OrganizeId, this.txtSearch.Text);
            // 绑定屏幕数据
            this.BindData();
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
            if (BaseInterfaceLogic.CheckInputModifyAnyOne(this.DTStaff))
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
                    this.DTStaff.AcceptChanges();
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

        private void FrmStaffAddressAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BaseInterfaceLogic.IsModfiedAnyOne(this.DTStaff))
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
        
        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            // 获取选择列的邮件
            string id = BaseInterfaceLogic.GetDataGridViewEntityId(this.grdStaffAddress, BaseStaffEntity.FieldId);
            FrmSendEmail frmSendEmail = new FrmSendEmail(id);
            if (frmSendEmail.ShowDialog(this) == DialogResult.OK)
            {
                // 记录当前选中的主键
                this.CurrentEntityId = this.EntityId;
                // 加载窗体
                this.FormOnLoad();
            }            
        }

        private void pager_PageChanged(object sender, EventArgs e)
        {
            this.Search();
        }
    }
}