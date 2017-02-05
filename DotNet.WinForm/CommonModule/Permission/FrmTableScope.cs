//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Utilities;
    using DotNet.Business;
    
    /// <summary>
    /// FrmTableScope.cs
    /// 约束条件
    ///		
    /// 修改记录
    /// 
    ///     2011.05.17 版本：1.0 JiRiGaLa  模块配置。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.05.17</date>
    /// </author> 
    /// </summary>
    public partial class FrmTableScope : BaseForm
    {
        public FrmTableScope()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="resourceCategory">什么类型的</param>
        /// <param name="resourceId">什么资源</param>
        public FrmTableScope(string resourceCategory, string resourceId)
            : this()
        {
            this.ResourceCategory = resourceCategory;
            this.ResourceId = resourceId;
        }

        private DataTable DataTableScope = new DataTable(BaseItemDetailsEntity.TableName);

        private string resourceCategory = string.Empty;
        ///<summary>
        /// 什么类型的
        ///</summary>
        public string ResourceCategory
        {
            get
            {
                return resourceCategory;
            }
            set
            {
                resourceCategory = value;
            }
        }

        private string resourceId = string.Empty;
        ///<summary>
        /// 什么资源
        ///</summary>
        public string ResourceId
        {
            get
            {
                return resourceId;
            }
            set
            {
                resourceId = value;
            }
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnInvertSelect.Enabled = false;
            this.btnSelectAll.Enabled = false;
            this.btnDeleteCondition.Enabled = false;
            this.btnSetCondition.Enabled = false;
            this.btnExport.Enabled = false;

            if (this.DataTableScope.Rows.Count > 0)
            {
                this.btnInvertSelect.Enabled = true;
                this.btnSelectAll.Enabled = true;
                this.btnDeleteCondition.Enabled = true;
                this.btnSetCondition.Enabled = true;
                this.btnExport.Enabled = true;
            }
        }
        #endregion

        private void GetResourceInfo()
        {
            if (this.ResourceCategory == BaseRoleEntity.TableName)
            {
                this.txtUserOrRole.Text = DotNetService.Instance.RoleService.GetEntity(this.UserInfo, this.ResourceId).RealName;
            }
            if (this.ResourceCategory == BaseUserEntity.TableName)
            {
                this.txtUserOrRole.Text = DotNetService.Instance.UserService.GetEntity(this.UserInfo, this.ResourceId).RealName;
            }
        }

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.GetResourceInfo();
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(this.grdTable);
            // 获得列表
            this.GetList();
            // 这里是测试，看表达式是否正确
            // this.Text = DotNetService.Instance.TableColumnsService.GetUserConstraint(this.UserInfo, "BaseModule");
        }
        #endregion

        #region public override void GetList() 获取角色列表
        /// <summary>
        /// 获取角色列表
        /// </summary>
        public override void GetList()
        {
            this.DataTableScope = DotNetService.Instance.TableColumnsService.GetConstraintDT(this.UserInfo, this.ResourceCategory, this.ResourceId);
            this.grdTable.AutoGenerateColumns = false;
            this.DataTableScope.DefaultView.Sort = BaseItemDetailsEntity.FieldSortCode;
            this.grdTable.DataSource = this.DataTableScope.DefaultView;
        }
        #endregion

        private void grdTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnSetCondition.PerformClick();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in grdTable.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }
            //foreach (DataRowView dataRowView in this.DataTableScope.DefaultView)
            //{
            //    dataRowView.Row[BaseBusinessLogic.SelectedColumn] = true.ToString();
            //}
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in grdTable.Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false);
            }
            //foreach (DataRowView dataRowView in this.DataTableScope.DefaultView)
            //{
            //    if (dataRowView.Row[BaseBusinessLogic.SelectedColumn].ToString().Equals(true.ToString()))
            //    {
            //        dataRowView.Row[BaseBusinessLogic.SelectedColumn] = false.ToString();
            //    }
            //    else
            //    {
            //        dataRowView.Row[BaseBusinessLogic.SelectedColumn] = true.ToString();
            //    }
            //}
        }

        private int DeleteCondition()
        {
            int returnValue = 0;
            // 检查至少要选择一个？
            if (!BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdTable, "colSelected"))
            {
                return returnValue;
            }
            // 是否确认删除了？
            if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
            {
                return returnValue;
            }
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string[] ids = BaseInterfaceLogic.GetSelecteIds(this.grdTable, BasePermissionScopeEntity.FieldId, "colSelected", true);
                returnValue = DotNetService.Instance.TableColumnsService.BatchDeleteConstraint(this.UserInfo, ids);
                // 重新加载数据，先刷新屏幕，再显示提示信息
                this.FormOnLoad();
                // 是否需要有提示信息？
                if (BaseSystemInfo.ShowInformation)
                {
                    // 批量保存，进行提示
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0077, returnValue.ToString()), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            return returnValue;
        }

        private void btnDeleteCondition_Click(object sender, EventArgs e)
        {
            this.DeleteCondition();
        }

        private void SetCondition()
        {
            DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdTable);
            string tableName = dataRow[BaseTableColumnsEntity.FieldTableCode].ToString();
            FrmTableScopeConstraint frmTableScopeCondition = new FrmTableScopeConstraint(this.ResourceCategory, this.ResourceId, tableName);
            if (frmTableScopeCondition.ShowDialog(this) == DialogResult.OK)
            {
                this.FormOnLoad();
            }
        }

        private void btnSetCondition_Click(object sender, EventArgs e)
        {
            this.SetCondition();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 导出Excel
            //string exportFileName = this.Text + ".csv";
            string exportFileName = this.Text + ".xls";
            this.ExportExcel(this.grdTable , @"\Modules\Export\", exportFileName);
        }        
    }
}
