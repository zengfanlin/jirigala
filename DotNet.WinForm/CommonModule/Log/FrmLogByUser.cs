﻿//--------------------------------------------------------------------
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
    /// FrmLogByUser.cs
    /// 日志－访问情况按查询用户窗体
    ///		
    /// 修改记录
    /// 
    ///     2007.05.31 版本：1.0 JiRiGaLa  日志－访问情况按员工查询功能页面编写。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.31</date>
    /// </author> 
    /// </summary> 
    public partial class FrmLogByUser : BaseForm
    {
        private bool permissionClear    = false;  // 清除权限

        /// <summary>
        /// 权限域编号
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        private DataTable DTLog = new DataTable(BaseLogEntity.TableName);    // 日志 DataTable

        // 员工主键
        private string TargetUserId
        {
            set
            {
                this.ucUser.SelectedId = value;
            }
            get
            {
                return this.ucUser.SelectedId;
            }
        }

        // 员工名称     
        private string TargetStaffFullName
        {
            set
            {
                this.ucUser.SelectedFullName = value;
            }
            get
            {
                return this.ucUser.SelectedFullName;
            }
        }

        /// <summary>
        /// 日志主键
        /// </summary>
        public override string EntityId
        {
            get
            {
                return BaseInterfaceLogic.GetDataGridViewEntityId(this.grdLog, BaseLogEntity.FieldId);
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
               
        public FrmLogByUser()
        {
            InitializeComponent();
        }

        public FrmLogByUser(string userId, string userRealName) : this()
        {
            this.TargetUserId = userId;
            this.TargetStaffFullName = userRealName;
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.ucUser.PermissionItemScopeCode = this.PermissionItemScopeCode;
            // 默认是看自己的访问记录
            if (String.IsNullOrEmpty(this.ucUser.SelectedId))
            {
                this.ucUser.SelectedId = UserInfo.Id;
                this.ucUser.SelectedFullName = UserInfo.RealName;
            }

            this.btnExport.Enabled = false;
            this.btnBatchDelete.Enabled = false;
            this.btnClear.Enabled = false;
            this.btnSelectAll.Enabled = false;
            this.btnInvertSelect.Enabled = false;

            this.btnQuery.Enabled = false;
            this.ucUser.Enabled = false;

            if (this.DTLog.Rows.Count > 0)
            {
                // 检查删除权限
                this.btnExport.Enabled = this.permissionExport;
                this.btnBatchDelete.Enabled = this.permissionDelete;
                this.btnClear.Enabled = this.permissionClear;
                // this.grdLog.AllowUserToDeleteRows = this.permissionDelete;
                this.btnSelectAll.Enabled = this.permissionDelete;
                this.btnInvertSelect.Enabled = this.permissionDelete;
            }

            this.btnQuery.Enabled = this.permissionSearch;
            this.ucUser.Enabled = this.permissionSearch;

            if (this.UserInfo.IsAdministrator)
            {
                this.ucUser.AllowNull = true;
                this.lblUserReq.Visible = false;
            }
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAccess = this.IsModuleAuthorized("LogAdmin");   // 访问权限
            this.permissionSearch = this.IsAuthorized("LogAdmin.Search");   // 查询权限
            this.permissionExport = this.IsAuthorized("LogAdmin.Export");   // 导出权限
            this.permissionDelete = this.IsAuthorized("LogAdmin.Delete");   // 删除权限
            this.permissionClear = this.IsAuthorized("LogAdmin.Clear");    // 清除权限

            // this.permissionItemScopeCode = ConfigHelper.GetValue("PermissionMapping.xml", "LogByUser.PermissionItemScopeCode");
        }
        #endregion

        #region public override void GetList() 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        public override void GetList()
        {
            this.grdLog.AutoGenerateColumns = false;
            this.grdLog.DataSource = this.DTLog.DefaultView;
            this.grdLog.Refresh();
            if (this.CurrentEntityId.Length > 0)
            {
                this.grdLog.FirstDisplayedScrollingRowIndex = BaseInterfaceLogic.GetRowIndex(this.DTLog, BaseLogEntity.FieldId, this.CurrentEntityId);
            }
            // 判断删除权限
            if (!this.permissionDelete)
            {
                // 只读属性设置
                this.grdLog.Columns["colSelected"].ReadOnly = !this.permissionDelete;
            }
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
            this.DataGridViewOnLoad(grdLog);
            // 设置用户控件状态，默认只能看自己的
            this.ucUser.AllowNull = false;
            this.ucUser.PermissionItemScopeCode = this.PermissionItemScopeCode;
            this.ucUser.OpenId = UserInfo.CompanyId;
            // 权限信息
            this.DTLog = DotNetService.Instance.LogService.GetDataTableByUser(UserInfo, this.TargetUserId, this.dtpStartDate.Value.Date.ToString("yyyy/MM/dd hh:mm:ss"), this.dtpEndDate.Value.Date.ToString("yyyy/MM/dd hh:mm:ss"));
            // 绑定屏幕数据
            this.GetList();
        }
        #endregion
        
        #region private bool CheckSearch() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns></returns>
        private bool CheckSearch()
        {
            bool returnValue = true;
            if (DateTime.Compare(this.dtpEndDate.Value.Date, this.dtpStartDate.Value.Date) < 0)
            {
                MessageBox.Show(AppMessage.MSG0208, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false; 
            }
            return returnValue;
        }
        #endregion

        #region private void DoSearch() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        private void DoSearch()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string startDate = this.dtpStartDate.Value.Date.ToString("yyyy-MM-dd");
                string endDate = this.dtpEndDate.Value.Date.ToString("yyyy-MM-dd");
                // 权限信息
                this.DTLog = DotNetService.Instance.LogService.GetDataTableByUser(UserInfo, this.ucUser.SelectedId == null ? string.Empty : this.ucUser.SelectedId, startDate, endDate);
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
        #endregion

        private void ucUser_SelectedIndexChanged(string parentId)
        {
            this.DoSearch();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 检查输入的有效性
            if (this.CheckSearch())
            {
                this.DoSearch();
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in grdLog.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }

            //foreach (DataRow dataRow in this.DTLog.Rows)
            //{
            //    dataRow["colSelected"] = true.ToString();
            //}
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dgvRow in grdLog.Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value??false);
            }

            //foreach (DataRow dataRow in this.DTLog.Rows)
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

        private void grdLogGeneral_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (this.permissionDelete)
            {
                if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else
                {
                    DotNetService.Instance.LogService.Delete(UserInfo, this.EntityId);
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 导出Excel
            //string exportFileName = this.Text + ".csv";
            string exportFileName = this.Text + ".xls";
            this.ExportExcel(this.grdLog , @"\Modules\Export\", exportFileName);
        }
    
        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>bool</returns>
        public override bool CheckInput()
        {
            return BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdLog, "colSelected");
        }
        #endregion

        #region private string[] GetSelecteIds() 获得已被选择的部门主键数组
        /// <summary>
        /// 获得已被选择的部门主键数组
        /// </summary>
        /// <returns></returns>
        private string[] GetSelecteIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdLog, BaseLogEntity.FieldId, "colSelected", true);
        }
        #endregion

        #region public override int BatchDelete() 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        public override int BatchDelete()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            int returnValue = 0;
            try
            {
                returnValue = DotNetService.Instance.LogService.BatchDelete(UserInfo, this.GetSelecteIds());
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
            return returnValue;
        }
        #endregion

        private void btnBatchDelete_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    this.BatchDelete();
                    this.DoSearch();
                }
            }       
        }

        #region private void DoClearLog() 清除日志
        /// <summary>
        /// 清除日志
        /// </summary>
        private void DoClearLog()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DotNetService.Instance.LogService.Truncate(UserInfo);
                this.DTLog.Clear();
                // 绑定屏幕数据
                this.GetList();
                MessageBox.Show(AppMessage.MSG0209, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            //  清除日志
            if (this.permissionDelete)
            {
                if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    this.DoClearLog();
                    this.FormOnLoad();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // 关闭窗体
            this.Close();
        }
    }
}