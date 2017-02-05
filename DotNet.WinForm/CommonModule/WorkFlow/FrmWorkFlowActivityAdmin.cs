//--------------------------------------------------------------------
// All Rights Reserved ,Copyright (C) 2012 , Hairihan TECH, Ltd. .
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FrmWorkFlowActivityAdmin.cs
    /// 工作流管理窗体
    ///		
    /// 修改记录
    /// 
    ///     2010.08.03 版本：1.8 JiRiGaLa    重新整理代码。
    ///     2007.06.26 版本：1.7 JiRiGaLa    增加权限判断代码。
    ///     2007.06.26 版本：1.6 JiRiGaLa    整理代码。
    ///     2007.06.26 版本：1.5 JiRiGaLa    进行优化。
    ///     2007.06.26 版本：1.4 JiRiGaLa    SingleDelete() 进行优化。
    ///     2007.06.26 版本：1.3 JiRiGaLa    整体整理代码。
    ///     2007.06.26 版本：1.2 JiRiGaLa    增加了多国语言功能，调整了细节部分。
    ///     2007.06.26 版本：1.1 JiRiGaLa    整体进行调试改进。
    ///     2007.06.26 版本：1.0 JiRiGaLa    工作流管理功能页面编写。
    ///		
    /// 版本：1.7
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.06.26</date>
    /// </author>
    /// </summary>
    public partial class FrmWorkFlowActivityAdmin : BaseForm
    {
        private DataTable DTWorkFlowActivity = new DataTable(BaseWorkFlowActivityEntity.TableName);

        /// <summary>
        /// 工作流主键
        /// </summary>
        public string WorkFlowId = String.Empty;

        private bool PermissionAdd = false;                     // 新增权限
        private bool PermissionEdit = false;                    // 编辑权限
        private bool PermissionDelete = false;                  // 删除权限

        public FrmWorkFlowActivityAdmin()
        {
            InitializeComponent();
        }

        #region public FrmWorkFlowActivityAdmin(String workFlowId)
        /// <summary>
        /// 工作流的ID
        /// </summary>
        /// <param name="workFlowId">工作流主键</param>
        public FrmWorkFlowActivityAdmin(String workFlowId)
            : this()
        {
            // 传入工作流Id
            this.WorkFlowId = workFlowId;
        }
        #endregion

        #region public override void SetHelp() 设置帮助信息
        /// <summary>
        /// 设置帮助信息
        /// </summary>
        public override void SetHelp()
        {
            this.HelpButton = true;
        }
        #endregion

        #region public override void GetPermission() 获得权限
        /// <summary>
        /// 获得权限
        /// </summary>
        public override void GetPermission()
        {
            // 添加权限
            this.PermissionAdd = this.IsAuthorized("WorkFlowActivityAdmin.Add");
            // 删除权限
            this.PermissionDelete = this.IsAuthorized("WorkFlowActivityAdmin.Delete");
            // 编辑权限
            this.PermissionEdit = this.IsAuthorized("WorkFlowActivityAdmin.Edit");     
        }
        #endregion

        #region public override void SetControlState() 按钮的状态
        /// <summary>
        /// 按钮的状态
        /// </summary>
        public override void SetControlState()
        {
            // 是否有添加权限
            this.btnAdd.Enabled = this.PermissionAdd;
            if (this.DTWorkFlowActivity.Rows.Count <= 0)
            {
                // 没选种按钮变灰
                this.btnDelete.Enabled = false;
            }
            else
            {
                // 是否有删除权限
                this.btnDelete.Enabled = this.PermissionDelete;
            }
            this.btnExport.Enabled = this.grdWorkFlowActivity.RowCount > 0;
        }
        #endregion

        #region private void BindGrdData() 绑定Grd数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindGrdData()
        {
            this.DTWorkFlowActivity = DotNetService.Instance.WorkFlowActivityAdminService.GetDataTable(this.UserInfo, this.WorkFlowId);
            this.DTWorkFlowActivity.DefaultView.Sort = BaseWorkFlowActivityEntity.FieldSortCode;
            this.grdWorkFlowActivity.AutoGenerateColumns = false;
            this.grdWorkFlowActivity.DataSource = this.DTWorkFlowActivity.DefaultView;
            this.grdWorkFlowActivity.Refresh();
            if (this.EntityId.Length > 0)
            {
                this.grdWorkFlowActivity.FirstDisplayedScrollingRowIndex = BaseInterfaceLogic.GetRowIndex(this.DTWorkFlowActivity, BaseWorkFlowActivityEntity.FieldId, this.EntityId);
            }
            // 设置排序按钮
            this.ucTableSort.DataBind(this.grdWorkFlowActivity, this.PermissionEdit);
        }
        #endregion

        #region public override void ShowEntity() 显示信息
        /// <summary>
        /// 显示信息
        /// </summary>
        public override void ShowEntity()
        {
            //// 
            //BaseWorkFlowProcessEntity workFlowEntity = DotNetService.Instance.WorkFlowProcessAdminService.GetEntity(this.UserInfo, this.WorkFlowId);
            //this.txtWorkFlowCode.Text = workFlowEntity.Code;
            //this.txtWorkFlowFullName.Text = workFlowEntity.FullName;
            DataTable dataTable = DotNetService.Instance.WorkFlowProcessAdminService.GetDataTable(this.UserInfo, this.WorkFlowId);
            if ((dataTable != null) && (dataTable.Rows.Count > 0))
            {
                DataRow dataRow = dataTable.Rows[0];
                this.txtWorkFlowCode.Text = dataRow[BaseWorkFlowProcessEntity.FieldCode].ToString();
                this.txtWorkFlowFullName.Text = dataRow[BaseWorkFlowProcessEntity.FieldFullName].ToString();
                BaseItemDetailsEntity itemDetailsEntity = DotNetService.Instance.ItemDetailsService.GetEntityByCode(this.UserInfo, "ItemsWorkFlowCategories", dataRow[BaseWorkFlowProcessEntity.FieldCategoryCode].ToString());
                if (itemDetailsEntity != null)
                {
                    if (!string.IsNullOrEmpty(itemDetailsEntity.ItemName))
                    {
                        this.txtBillCategory.Text = itemDetailsEntity.ItemName;
                    }
                }
                // 这里可能没在数据库里设置过，需要有空时，整理一下
                BaseItemDetailsEntity itemDetailsEntityAuditWorkFlowCode = DotNetService.Instance.ItemDetailsService.GetEntityByCode(this.UserInfo, "ItemsAuditWorkFlowCodeType", dataRow[BaseWorkFlowProcessEntity.FieldAuditCategoryCode].ToString());
                if (itemDetailsEntityAuditWorkFlowCode != null)
                {
                    if (!string.IsNullOrEmpty(itemDetailsEntityAuditWorkFlowCode.ItemName))
                    {
                        this.txtAuditWorkFlowCode.Text = itemDetailsEntityAuditWorkFlowCode.ItemName;
                    }
                }
                this.txtBillName.Text = dataRow["BillTemplateName"].ToString();
            }
        }
        #endregion

        #region public override FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdWorkFlowActivity);
            // 显示信息
            this.ShowEntity();
            // 设置帮助信息
            this.SetHelp();
            // 加载Grd数据
            this.BindGrdData();
        }
        #endregion

        #region private String[] GetSelectIds() 选种的步骤ID数组
        /// <summary>
        /// 选种的步骤ID数组
        /// </summary>
        /// <returns></returns>
        private String[] GetSelectIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdWorkFlowActivity, BaseWorkFlowActivityEntity.FieldId, "colSelected", true);
        }
        #endregion

        #region public override void BatchDelete() 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        public override int BatchDelete()
        {
            int returnValue = 0;
            returnValue = DotNetService.Instance.WorkFlowActivityAdminService.BatchDelete(this.UserInfo, this.GetSelectIds());
            // 获取绑定数据
            this.FormOnLoad();
            return returnValue;
        }
        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
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
                catch (Exception exception)
                {
                    // 在本地记录异常
                    this.ProcessException(exception);
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
            this.Close();
        }

        #region private void AddClear() 添加时清楚
        /// <summary>
        /// 添加时清楚
        /// </summary>
        private void AddClear()
        {
            // 清空名字
            this.txtFullName.Text = String.Empty;
            this.txtDescription.Text = String.Empty;
            this.ucOrganize.SetNull();
            this.ucUserSelect.SetNull();
            this.ucRole.SetNull();
        }
        #endregion

        #region private bool AddCheckInput() 输入有效性
        /// <summary>
        /// 输入有效性
        /// </summary>
        /// <returns>有效</returns>
        private bool AddCheckInput()
        {
            bool returnValue = true;
            if (this.txtFullName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9978), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtFullName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.ucUserSelect.SelectedId) && string.IsNullOrEmpty(this.ucRole.SelectedId) && string.IsNullOrEmpty(this.ucOrganize.SelectedId))
            {
                MessageBox.Show(AppMessage.MSG0304, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ucUserSelect.Focus();
                return false;
            }
            if (!string.IsNullOrEmpty(this.ucUserSelect.SelectedId) && !string.IsNullOrEmpty(this.ucRole.SelectedId) && !string.IsNullOrEmpty(this.ucOrganize.SelectedId))
            {
                MessageBox.Show(AppMessage.MSG0245, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ucUserSelect.Focus();
                return false;
            }
            else if (!string.IsNullOrEmpty(this.ucUserSelect.SelectedId) && !string.IsNullOrEmpty(this.ucRole.SelectedId))
            {
                MessageBox.Show(AppMessage.MSG0245, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ucUserSelect.Focus();
                return false;
            }
            else if (!string.IsNullOrEmpty(this.ucUserSelect.SelectedId) && !string.IsNullOrEmpty(this.ucOrganize.SelectedId))
            {
                MessageBox.Show(AppMessage.MSG0245, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ucUserSelect.Focus();
                return false;
            }
            else if (!string.IsNullOrEmpty(this.ucRole.SelectedId) && !string.IsNullOrEmpty(this.ucOrganize.SelectedId))
            {
                MessageBox.Show(AppMessage.MSG0245, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ucUserSelect.Focus();
                return false;
            }
            return returnValue;
        }
        #endregion

        #region public override bool SaveEntity() 添加保存
        /// <summary>
        /// 添加保存
        /// </summary>
        /// <returns>保存成功</returns>
        public override bool SaveEntity()
        {
            bool returnValue = false;
            BaseWorkFlowActivityEntity workFlowActivityEntity = this.GetEntity();
            this.EntityId = DotNetService.Instance.WorkFlowActivityAdminService.Add(this.UserInfo, workFlowActivityEntity);
            this.FormOnLoad();
            // 按钮状态
            this.SetControlState();
            return returnValue;
        }
        #endregion

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <returns></returns>
        private BaseWorkFlowActivityEntity GetEntity()
        {
            BaseWorkFlowActivityEntity workFlowActivityEntity = new BaseWorkFlowActivityEntity();
            workFlowActivityEntity.WorkFlowId = int.Parse(this.WorkFlowId);
            workFlowActivityEntity.FullName = this.txtFullName.Text;

            workFlowActivityEntity.AuditDepartmentId = null;
            workFlowActivityEntity.AuditDepartmentName = null;
            // 选择的是组织机构
            if (!string.IsNullOrEmpty(this.ucOrganize.SelectedId))
            {
                workFlowActivityEntity.AuditDepartmentId = this.ucOrganize.SelectedId;
                workFlowActivityEntity.AuditDepartmentName = this.ucOrganize.SelectedFullName;
            }

            workFlowActivityEntity.AuditUserId = null;
            workFlowActivityEntity.AuditUserRealName = null;
            // 选择的是用户
            if (!string.IsNullOrEmpty(this.ucUserSelect.SelectedId))
            {
                workFlowActivityEntity.AuditUserId = this.ucUserSelect.SelectedId;
                workFlowActivityEntity.AuditUserRealName = this.ucUserSelect.SelectedFullName;
                BaseUserEntity userEntity = DotNetService.Instance.UserService.GetEntity(this.UserInfo, this.ucUserSelect.SelectedId);
                if (userEntity != null)
                {
                    workFlowActivityEntity.AuditDepartmentId = userEntity.DepartmentId;
                    workFlowActivityEntity.AuditDepartmentName = userEntity.DepartmentName;
                }
            }

            workFlowActivityEntity.AuditRoleId = null;
            workFlowActivityEntity.AuditRoleRealName = null;
            // 选择的是角色
            if (!string.IsNullOrEmpty(this.ucRole.SelectedId))
            {
                workFlowActivityEntity.AuditRoleId = this.ucRole.SelectedId;
                workFlowActivityEntity.AuditRoleRealName = this.ucRole.SelectedFullName;
            }

            workFlowActivityEntity.Description = this.txtDescription.Text;
            workFlowActivityEntity.DeletionStateCode = 0;
            workFlowActivityEntity.Enabled = 1;
            return workFlowActivityEntity;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.AddCheckInput())
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    // 添加的保存
                    this.SaveEntity();
                    // 清楚数据
                    this.AddClear();
                }
                catch (Exception exception)
                {
                    // 在本地记录异常
                    this.ProcessException(exception);
                }
                finally
                {
                    // 设置鼠标默认状态，原来的光标状态
                    this.Cursor = holdCursor;
                }
            }
        }

        #region private void BatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private void BatchSave()
        {
            DotNetService.Instance.WorkFlowActivityAdminService.BatchSave(UserInfo, this.DTWorkFlowActivity);
            // 绑定屏幕数据
            this.FormOnLoad();
            if (BaseSystemInfo.ShowInformation)
            {
                // 批量保存，进行提示
                MessageBox.Show(AppMessage.MSG0011, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        public void Save()
        {
            // 检查批量输入的有效性
            if (BaseInterfaceLogic.CheckInputModifyAnyOne(this.DTWorkFlowActivity))
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
                    this.DTWorkFlowActivity.AcceptChanges();
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

        private void btnBatchSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 导出Excel
            //string exportFileName = this.Text + ".csv";
            string exportFileName = this.Text + ".xls";
            this.ExportExcel(this.grdWorkFlowActivity, @"\Modules\Export\", exportFileName);
        }
    }
}