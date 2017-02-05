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
    
    /// <summary>
    /// FrmLogGeneral.cs
    /// 权限管理-管理权限窗体
    ///		
    /// 修改记录
    /// 
    ///     2007.05.31 版本：1.0 JiRiGaLa  日志－访问情况功能页面编写。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.31</date>
    /// </author> 
    /// </summary>    
    public partial class FrmLogGeneral : BaseForm
    {
        private DataTable DTLogGeneral = new DataTable(BaseLogEntity.TableName);        // 日志 DataTable
        
        /// <summary>
        /// 表格中的登录人员主键
        /// </summary>
        public override string EntityId
        {
            get
            {
                string entityId = string.Empty;
                entityId = BaseInterfaceLogic.GetDataGridViewEntityId(this.grdLog, BaseUserEntity.FieldId);
                return entityId;
            }
        }

        #region public string CurrentEntityId 当前选种的Id
        /// <summary>
        /// 当前选种的ID
        /// </summary>
        private string entityId = string.Empty;
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
        #endregion

        private bool permissionReset = false;    // 编辑权限

        /// <summary>
        /// 编辑用户
        /// </summary>
        private bool permissionProperty = false;
        
        public FrmLogGeneral()
        {
            // 加载系统信息
            InitializeComponent();
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnVisitDetail.Enabled = this.permissionSearch;
            if (this.DTLogGeneral.DefaultView.Count > 0)
            {
                // 检查重置权限
                this.btnSelectAll.Enabled = this.permissionReset;
                this.btnInvertSelect.Enabled = this.permissionReset;
                this.btnVisitDetail.Enabled = this.permissionSearch;
                this.btnExport.Enabled = this.permissionExport;
                this.btnReset.Enabled = this.permissionReset;
            }
            else
            {
                this.btnSelectAll.Enabled = false;
                this.btnInvertSelect.Enabled = false;
                this.btnVisitDetail.Enabled = false;
                this.btnExport.Enabled = false;
                this.btnReset.Enabled = false;
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
            this.permissionReset = this.IsAuthorized("LogAdmin.Reset");     // 重置权限
            this.permissionExport = this.IsAuthorized("LogAdmin.Export");   // 导出权限
            this.permissionSearch = this.IsAuthorized("LogAdmin.Search");   // 查询权限
        }
        #endregion

        #region public override void GetList() 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        public override void GetList()
        {
            this.grdLog.AutoGenerateColumns = false;
            this.grdLog.DataSource = this.DTLogGeneral.DefaultView;
            // 判断删除权限
            if (!this.permissionReset)
            {
                // 只读属性设置
                this.grdLog.Columns["colSelected"].ReadOnly = !this.permissionReset;
            }
            if (this.chkOnlyOnLine.Checked)
            {
                this.SetFilter();
            }
            else
            {
                // 设置按钮状态
                this.SetControlState();
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
            this.DataGridViewOnLoad(grdLog);
            // 获取数据
            this.DTLogGeneral = DotNetService.Instance.LogService.GetLogGeneral(UserInfo);
            // 绑定屏幕数据
            this.GetList();
        }
        #endregion

        #region private void BindData() 绑定数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            if (this.chkOnlyOnLine.Checked)
            {
                BaseBusinessLogic.SetFilter(this.DTLogGeneral, BaseUserEntity.FieldUserOnLine, "1");
            }
            this.grdLog.AutoGenerateColumns = false;
            //this.DTLogGeneral.DefaultView.Sort = BaseUserEntity.FieldSortCode;
            this.grdLog.DataSource = this.DTLogGeneral.DefaultView;
            if (this.CurrentEntityId.Length > 0)
            {
                this.grdLog.FirstDisplayedScrollingRowIndex = BaseInterfaceLogic.GetRowIndex(this.DTLogGeneral, BaseUserEntity.FieldId, this.CurrentEntityId);
            }
            // 设置排序按钮
            //this.ucTableSort.DataBind(this.grdUser, this.permissionProperty);
            // 设置用户能否修改有效状态
            if (!this.permissionProperty)
            {
                // 只读属性设置
                this.grdLog.Columns["colEnabled"].ReadOnly = !this.permissionProperty;
            }
            this.SetControlState();
        }
        #endregion

        public void FormOnLoad(bool LoadLog, string searchValue)
        {
            // 加载窗体，检查是否配置为默认加载用户列表，就怕用户数量太多了。
            if (LoadLog)
            {
                if (String.IsNullOrEmpty(searchValue))
                {
                    this.DTLogGeneral.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    this.DTLogGeneral = DotNetService.Instance.LogService.Search(UserInfo, searchValue, (!this.chkOnlyOnLine.Checked));
                }
                // 加载绑定数据
                this.BindData();
            }
        }

        private void SetFilter()
        {
            string search = this.txtSearch.Text.Trim();
            if (String.IsNullOrEmpty(search) && (!this.chkOnlyOnLine.Checked))
            {
                this.DTLogGeneral.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                string filter = string.Empty;
                if (this.chkOnlyOnLine.Checked)
                {
                    filter = BaseUserEntity.FieldUserOnLine + " ='1' ";
                }
                if (!String.IsNullOrEmpty(search))
                {
                    if (filter.Length > 0)
                    {
                        filter += " AND ";
                    }
                    search = StringUtil.GetSearchString(search);
                    filter += "(" + 
                        
                        /*BaseStaffEntity.FieldCode + " LIKE '" + search + "'"
                        + " OR " + BaseUserEntity.FieldUserName + " LIKE '" + search + "'"
                        + " OR " + BaseStaffEntity.FieldRealName + " LIKE '" + search + "'"
                        + " OR " + BaseUserEntity.FieldIPAddress + " LIKE '" + search + "'"
                        + " OR " + BaseUserEntity.FieldMACAddress + " LIKE '" + search + */

                        StringUtil.GetLike(BaseUserEntity.FieldCode, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldUserName, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldRealName, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldIPAddress, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldMACAddress, search)+

                        ")";
                }
                this.DTLogGeneral.DefaultView.RowFilter = filter;
            }
            this.SetControlState();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.SetFilter();
        }

        private void chkOnlyOnLine_CheckedChanged(object sender, EventArgs e)
        {
            this.FormOnLoad(true, this.txtSearch.Text);
        }

        private void grdLog_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnVisitDetail.PerformClick();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in grdLog.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }

            //foreach (DataRow dataRow in this.DTLogGeneral.Rows)
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

            //foreach (DataRow dataRow in this.DTLogGeneral.Rows)
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

        private void btnVisitDetail_Click(object sender, EventArgs e)
        {
            DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdLog);
            string id = dataRow[BaseUserEntity.FieldId].ToString();
            string realName = dataRow[BaseUserEntity.FieldRealName].ToString();
            FrmLogByUser FrmLogByUser = new FrmLogByUser(id, realName);
            FrmLogByUser.ShowDialog();
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

        #region private string[] GetSelecteIds() 获得已被选择的权限主键数组
        /// <summary>
        /// 获得已被选择的权限主键数组
        /// </summary>
        /// <returns></returns>
        private string[] GetSelecteIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdLog, BaseUserEntity.FieldId, "colSelected", true);          
        }
        #endregion

        #region private void DoReset() 重置访问情况
        /// <summary>
        /// 重置访问情况
        /// </summary>
        private void DoReset()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string[] ids = this.GetSelecteIds();
                if (ids.Length > 0)
                {
                    this.DTLogGeneral = DotNetService.Instance.LogService.ResetVisitInfo(UserInfo, ids);
                    this.GetList();
                    MessageBox.Show(AppMessage.MSG0210, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(AppMessage.MSGC023, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                // 重置访问情况
                this.DoReset();
            }    
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // 关闭窗体
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.FormOnLoad(true, this.txtSearch.Text);
        }
    }
}