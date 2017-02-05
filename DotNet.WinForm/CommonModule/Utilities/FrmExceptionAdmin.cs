//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FrmExceptionAdmin.cs
    /// 异常信息管理-管理异常信息窗体
    ///		
    /// 修改记录
    /// 
    ///     2010.09.21 版本：2.0 JiRiGaLa  按继承基础类窗体的方式改进好代码。
    ///     2007.08.20 版本：1.2 JiRiGaLa  Instance 实例调用模式，加快运行速度。
    ///     2007.06.14 版本：1.1 JiRiGaLa  进行调试修改细节上的错误改进。
    ///     2007.06.07 版本：1.0 JiRiGaLa  异常信息管理功能页面编写。
    ///		
    /// 版本：2.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.09.21</date>
    /// </author> 
    /// </summary> 
    public partial class FrmExceptionAdmin : BaseForm
    {
        /// <summary>
        /// 异常 DataTable
        /// </summary>
        private DataTable DTException = new DataTable(BaseExceptionEntity.TableName);

        /// <summary>
        /// 异常信息主键
        /// </summary>
        public new string EntityId
        {
            get
            {
                return BaseInterfaceLogic.GetDataGridViewEntityId(this.grdExceptionAdmin, BaseExceptionEntity.FieldId);
            }
        }

        public FrmExceptionAdmin()
        {
            InitializeComponent();
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnSelectAll.Enabled = false;
            this.btnInvertSelect.Enabled = false;
            this.btnExport.Enabled = false;
            this.btnClearException.Enabled = false;
            this.btnBatchDelete.Enabled = false;
            if (this.DTException.DefaultView.Count > 0)
            {
                this.btnSelectAll.Enabled = this.permissionExport || this.permissionExport;
                this.btnInvertSelect.Enabled = this.permissionExport || this.permissionExport;
                this.btnExport.Enabled = this.permissionExport;
                this.btnClearException.Enabled = this.permissionDelete;
                this.btnBatchDelete.Enabled = this.permissionDelete;
            }
            // 判断编辑权限
            if (!this.permissionDelete)
            {
                // 只读属性设置
                this.grdExceptionAdmin.Columns["colSelected"].ReadOnly = !this.permissionDelete;
                this.btnSelectAll.Enabled = false;
                this.btnInvertSelect.Enabled = false;
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
            // this.permissionAccess = this.IsModuleAuthorized("FrmExceptionAdmin");
            this.permissionAccess = this.IsModuleAuthorized(this.Name);

            // 获取操作权限
            this.permissionDelete = this.IsAuthorized("ExceptionAdmin.Delete");
            this.permissionExport = this.IsAuthorized("ExceptionAdmin.Export");
        }
        #endregion

        #region public override void GetList() 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        public override void GetList()
        {
            // 权限信息
            DotNetService dotNetService = new DotNetService();
            this.DTException = dotNetService.ExceptionService.GetDataTable(UserInfo);
            if (dotNetService.ExceptionService is ICommunicationObject)
            {
                ((ICommunicationObject)dotNetService.ExceptionService).Close();
            }
            this.grdExceptionAdmin.AutoGenerateColumns = false;

            // 2012.05.23 Pcsky 按创建时间倒序排列，方便查看最新的异常
            this.DTException.DefaultView.Sort = BaseExceptionEntity.FieldCreateOn + " DESC";
            this.grdExceptionAdmin.DataSource = this.DTException.DefaultView;
            this.grdExceptionAdmin.Refresh();
            
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
            this.DataGridViewOnLoad(grdExceptionAdmin);
            // 绑定屏幕数据
            this.GetList();
        }
        #endregion

        private void grdExceptionAdmin_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // 判断是否有删除权限
            if (!this.permissionDelete)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else
                {
                    DotNetService dotNetService = new DotNetService();
                    dotNetService.ExceptionService.Delete(this.UserInfo, this.EntityId);
                    if (dotNetService.ExceptionService is ICommunicationObject)
                    {
                        ((ICommunicationObject)dotNetService.ExceptionService).Close();
                    }

                }
            }
        }

        private void grdExceptionAdmin_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdExceptionAdmin);
            if (dataRow != null)
            {
                BaseExceptionEntity exceptionEntity = new BaseExceptionEntity(dataRow);
                FrmException frmException = new FrmException(exceptionEntity);
                frmException.ShowDialog();
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dgvRow in grdExceptionAdmin.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }
            //foreach (DataRow dataRow in this.DTException.Rows)
            //{
            //    dataRow["colSelected"] = true.ToString();
            //}
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dgvRow in grdExceptionAdmin.Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value??false);
            }
            //foreach (DataRow dataRow in this.DTException.Rows)
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 导出Excel
            //string exportFileName = this.Text + ".csv";
            string exportFileName = this.Text + ".xls";
            this.ExportExcel(this.grdExceptionAdmin , @"\Modules\Export\", exportFileName);
        }

        #region private string[] GetSelecteIds() 获得已被选择的部门主键数组
        /// <summary>
        /// 获得已被选择的部门主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelecteIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdExceptionAdmin, BaseExceptionEntity.FieldId, "colSelected", true);
        }
        #endregion

        #region private bool CheckInputBatchDelete() 检查删除选择项的有效性
        /// <summary>
        /// 检查删除选择项的有效性
        /// </summary>
        /// <returns>有效</returns>
        private bool CheckInputBatchDelete()
        {
            return BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdExceptionAdmin, "colSelected");
        }
        #endregion

        #region public override int BatchDelete() 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        public override int BatchDelete()
        {
            DotNetService dotNetService = new DotNetService();
            int returnValue = dotNetService.ExceptionService.BatchDelete(this.UserInfo, this.GetSelecteIds());
            if (dotNetService.ExceptionService is ICommunicationObject)
            {
                ((ICommunicationObject)dotNetService.ExceptionService).Close();
            }
            // 绑定数据
            this.GetList();
            return returnValue;
        }
        #endregion

        private void btnBatchDelete_Click(object sender, EventArgs e)
        {
            if (this.CheckInputBatchDelete())
            {
                if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    this.BatchDelete();
                }
            }
        }

        #region private void ClearException() 清除日志
        /// <summary>
        /// 清除日志
        /// </summary>
        private void ClearException()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DotNetService dotNetService = new DotNetService();
                dotNetService.ExceptionService.Truncate(this.UserInfo);
                if (dotNetService.ExceptionService is ICommunicationObject)
                {
                    ((ICommunicationObject)dotNetService.ExceptionService).Close();
                }
                MessageBox.Show(AppMessage.MSG0238, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnClearException_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(AppMessage.MSG0239, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.ClearException();
                this.FormOnLoad();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}