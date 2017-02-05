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
    /// FrmUserSelect.cs
    /// 用户管理-选择用户窗体
    ///		
    /// 修改记录
    /// 
    ///     2010.10.08 版本：1.2 JiRiGaLa  部门名称不显示的问题解决。
    ///     2008.11.01 版本：1.1 JiRiGaLa  移出用户功能完善。
    ///     2008.10.01 版本：1.0 JiRiGaLa  用户选择功能页面编写。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.10.1</date>
    /// </author> 
    /// </summary>
    public partial class FrmUserSelect : BaseForm
    {
        private DataTable DTUser = new DataTable(BaseUserEntity.TableName);

        private string[] removeIds = null;
        /// <summary>
        /// 移出的主键数组
        /// </summary>
        public string[] RemoveIds
        {
            get
            {
                return this.removeIds;
            }
            set
            {
                this.removeIds = value;
            }
        }

        private string[] setSelectIds = null;
        /// <summary>
        /// 选中的主键数组
        /// </summary>
        public string[] SetSelectIds
        {
            get
            {
                return this.setSelectIds;
            }
            set
            {
                this.setSelectIds = value;
            }
        }

        public string CheckPermissionFullName = string.Empty;   // 检查什么模块
        public string CheckModuleCode = string.Empty;   // 检查什么模块
        public string CheckOperationCode = string.Empty;   // 检查什么权限

        public bool AllowSelectOther = true;

        private bool multiSelect = false;
        /// <summary>
        /// 是否允许多个选择
        /// </summary>
        public bool MultiSelect
        {
            get
            {
                return this.multiSelect;
            }
            set
            {
                this.multiSelect = value;
            }
        }

        private bool allowNull = false;
        /// <summary>
        /// 是否允许选择空
        /// </summary>
        public bool AllowNull
        {
            get
            {
                return this.allowNull;
            }
            set
            {
                this.allowNull = value;
            }
        }

        private bool allowSelect = true;
        /// <summary>
        /// 是否允许选择
        /// </summary>
        public bool AllowSelect
        {
            get
            {
                return this.allowSelect;
            }
            set
            {
                this.allowSelect = value;
                this.SetControlState();
            }
        }

        private string byPermissionCode = string.Empty;
        /// <summary>
        /// 按什么权限域获取员工列表
        /// </summary>
        public string PermissionItemScopeCode
        {
            get
            {
                return this.byPermissionCode;
            }
            set
            {
                this.byPermissionCode = value;
            }
        }

        private string selectedId = string.Empty;
        /// <summary>
        /// 被选中的员工主键
        /// </summary>
        public string SelectedId
        {
            get
            {
                return this.selectedId;
            }
            set
            {
                this.selectedId = value;
            }
        }

        private string selectedFullName = string.Empty;
        /// <summary>
        /// 被选中的员工全名
        /// </summary>
        public string SelectedFullName
        {
            get
            {
                return this.selectedFullName;
            }
            set
            {
                this.selectedFullName = value;
            }
        }

        private string openId = string.Empty;
        /// <summary>
        /// 打开节点
        /// </summary>
        public string OpenId
        {
            get
            {
                return this.openId;
            }
            set
            {
                this.openId = value;
            }
        }

        private string[] selectedIds = null;    // 被选中的主键集
        /// <summary>
        /// 被选中的员工主键
        /// </summary>
        public string[] SelectedIds
        {
            get
            {
                return this.selectedIds;
            }
            set
            {
                this.selectedIds = value;
            }
        }

        public delegate bool ButtonConfirmEventHandler();

        public FrmUserSelect()
        {
            InitializeComponent();
        }

        #region private void GetList(string searchValue) 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        private void GetList(string searchValue)
        {
            if (String.IsNullOrEmpty(searchValue))
            {
                // 不是管理员，并且需要按权限过滤数据
                if ((UserInfo.IsAdministrator) || String.IsNullOrEmpty(this.PermissionItemScopeCode))
                {
                    // 这里是获取所有的用户
                    this.DTUser = DotNetService.Instance.UserService.GetDataTable(UserInfo);
                }
                else
                {
                    // 这里是按权限范围进行过滤后的用户
                    this.DTUser = DotNetService.Instance.PermissionService.GetUserDTByPermissionScope(UserInfo, UserInfo.Id, this.PermissionItemScopeCode);
                }
            }
            else
            {
                this.DTUser = DotNetService.Instance.UserService.Search(UserInfo, searchValue, string.Empty, null);
            }
            this.grdUser.AutoGenerateColumns = false;
            this.DTUser.PrimaryKey = new DataColumn[] { this.DTUser.Columns[BaseUserEntity.FieldId] };
            this.DTUser.AcceptChanges();
            this.DTUser.DefaultView.Sort = BaseUserEntity.FieldSortCode;
            this.grdUser.DataSource = this.DTUser.DefaultView;
        }
        #endregion

        private void FormOnLoad(bool loadUser)
        {
            this.FormOnLoad(loadUser, string.Empty);
        }

        private void RemoveUser(string[] ids)
        {
            if (ids != null && ids.Length > 0)
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    DataRow dataRow = this.DTUser.Rows.Find(ids[i]);
                    if (dataRow != null)
                    {
                        dataRow.Delete();
                    }
                }
                this.DTUser.AcceptChanges();
            }
        }

        #region private void FormOnLoad(bool loadUser, string searchValue) 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        private void FormOnLoad(bool loadUser, string searchValue)
        {
            if (loadUser)
            {
                // 加载数据
                this.GetList(searchValue);

                // 检查是否需要移出
                this.RemoveUser(this.RemoveIds);
                
                // 检查选中状态
                if (this.SetSelectIds != null && this.SetSelectIds.Length > 0)
                {
                    foreach (DataGridViewRow dgvRow in this.grdUser.Rows)
                    {
                        DataRowView dataRowView = dgvRow.DataBoundItem as DataRowView;
                        if (dataRowView.Row.RowState == DataRowState.Deleted)
                        {
                            continue;
                        }
                        string id = dataRowView.Row[BaseUserEntity.FieldId].ToString();
                        // 是否已经发了消息
                        if (Array.Exists(SetSelectIds, element => element.Equals(id)))
                        {
                            dgvRow.Cells["colSelected"].Value = true;
                        }
                    }
                }
            }
            // 设置按钮状态
            this.SetControlState();
        }
        #endregion

        public override void FormOnLoad()
        {
            // 获取角色列表
            this.GetRoles();
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdUser);
            // 加载窗体，检查是否配置为默认加载用户列表，就怕用户数量太多了。
            this.FormOnLoad(BaseSystemInfo.LoadAllUser);
        }

        #region private void GetRoles() 获取角色列表
        /// <summary>
        /// 获取角色列表
        /// </summary>
        private void GetRoles()
        {
            // 绑定类型数据
            DataTable dataTable = DotNetService.Instance.RoleService.GetDefaultRoleDT(UserInfo);
            BaseBusinessLogic.SetFilter(dataTable, BaseRoleEntity.FieldDeletionStateCode, "0");
            BaseBusinessLogic.SetFilter(dataTable, BaseRoleEntity.FieldEnabled, "1");
            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbRole.DisplayMember = BaseRoleEntity.FieldRealName;
            this.cmbRole.ValueMember = BaseRoleEntity.FieldId;
            this.cmbRole.DataSource = dataTable.DefaultView;
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnSearch.Visible = !BaseSystemInfo.LoadAllUser;
            this.btnSetNull.Visible = this.AllowNull;
            this.btnSetNull.Enabled = this.AllowNull;
            this.btnSelectAll.Enabled = false;
            this.btnInvertSelect.Enabled = false;
            // 首先是需要能多选，其次是还有委托不是空的
            this.btnSelect.Visible = this.MultiSelect && this.OnSelected != null;
            if (!this.MultiSelect)
            {
                this.btnSelectAll.Visible = false;
                this.btnInvertSelect.Visible = false;
            }
            this.btnConfirm.Enabled = false;

            if (this.DTUser.Rows.Count > 0)
            {
                if (this.MultiSelect)
                {
                    this.btnSelectAll.Enabled = true;
                    this.btnInvertSelect.Enabled = true;
                }
                this.btnConfirm.Enabled = true;
            }
            this.txtSearch.Visible = this.AllowSelectOther;
            this.btnSearch.Visible = this.AllowSelectOther;
            if ((this.btnSearch.Visible) && (!UserInfo.IsAdministrator))
            {
                // 若是进行了权限范围过滤了，那就不能在数据库里进行查询了
                this.btnSearch.Enabled = String.IsNullOrEmpty(this.PermissionItemScopeCode);
            }
        }
        #endregion

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = this.txtSearch.Text.Trim();
            if (String.IsNullOrEmpty(search))
            {
                this.DTUser.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                if (this.DTUser.Rows.Count > 0)
                {
                    search = StringUtil.GetSearchString(search);
                    this.DTUser.DefaultView.RowFilter = StringUtil.GetLike(BaseUserEntity.FieldUserName,search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldCode, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldRealName, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldQuickQuery, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldDescription, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldCompanyName, search)                        
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldDepartmentName, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldDescription, search);              
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.btnSearch.Enabled = false;
            this.FormOnLoad(true, this.txtSearch.Text);
            this.btnSearch.Enabled = true;
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] roleIds = (this.cmbRole.SelectedValue.ToString().Length == 0) ? null : new string[] { this.cmbRole.SelectedValue.ToString() };
            // 用户信息
            this.DTUser = DotNetService.Instance.UserService.Search(UserInfo, string.Empty, string.Empty, roleIds);

            this.grdUser.AutoGenerateColumns = false;
            this.DTUser.PrimaryKey = new DataColumn[] { this.DTUser.Columns[BaseUserEntity.FieldId] };
            this.DTUser.AcceptChanges();
            this.DTUser.DefaultView.Sort = BaseUserEntity.FieldSortCode;
            this.grdUser.DataSource = this.DTUser.DefaultView;
            this.SetControlState();
        }

        private void grdUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.MultiSelect)
            {
                foreach (DataGridViewRow dgvRow in grdUser.Rows)
                {
                    if (dgvRow.Cells["colSelected"].Value != null && (bool)dgvRow.Cells["colSelected"].Value)
                    {
                        dgvRow.Cells["colSelected"].Value = false;
                    }
                }
            }
        }

        private void grdUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // TODO: 若是单选功能，双击就表示选定了当前的数据了。
            if (!this.MultiSelect)
            {
                DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdUser);
                if (dataRow != null)
                {
                    this.SelectedId = dataRow[BaseUserEntity.FieldId].ToString();
                    this.SelectedFullName = dataRow[BaseUserEntity.FieldRealName].ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in grdUser.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }
            //foreach (DataRow dataRow in this.DTUser.Rows)
            //{
            //    dataRow["colSelected"] = true.ToString();
            //}
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in grdUser.Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false);
            }
            //foreach (DataRow dataRow in this.DTUser.Rows)
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

        private string[] GetSelectedFullNames()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdUser, BaseUserEntity.FieldRealName, "colSelected", true);
        }

        #region private string[] GetSelectedIds() 获得已被选择的权限主键数组
        /// <summary>
        /// 获得已被选择的权限主键数组
        /// </summary>
        /// <returns>主键组</returns>
        private string[] GetSelectedIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdUser, BaseUserEntity.FieldId, "colSelected", true);
        }
        #endregion

        #region private bool CheckPermission(string userId, string userFullName) 检查权限
        /// <summary>
        /// 检查权限
        /// </summary>
        /// <param name="userId">员工主键</param>
        /// <param name="userFullName">员工姓名</param>
        /// <returns>是否有权限</returns>
        private bool CheckPermission(string userId, string userFullName)
        {
            bool returnValue = true;
            //if ((this.CheckModuleCode.Length > 0) && (this.CheckOperationCode.Length > 0))
            //{
            //    if (ModuleOperationCheckService.Instance.IsAuthorized(UserInfo, userId, this.CheckModuleCode, this.CheckOperationCode))
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        MessageBox.Show(userFullName + "无权限：" + this.CheckPermissionFullName, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return false;
            //    }
            //}
            return returnValue;
        }
        #endregion

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        public override bool CheckInput()
        {
            bool returnValue = false;
            DataRow dataRow = BaseInterfaceLogic.GetSelecteRow(this.grdUser, "colSelected");
            if (dataRow != null)
            {
                if ((dataRow[BaseUserEntity.FieldId].ToString().Length > 0) && (dataRow[BaseUserEntity.FieldRealName].ToString().Length > 0))
                {
                    string userId = dataRow[BaseUserEntity.FieldId].ToString();
                    string userFullName = dataRow[BaseUserEntity.FieldRealName].ToString();
                    if (this.CheckPermission(userId, userFullName))
                    {
                        returnValue = true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            if (!returnValue)
            {
                MessageBox.Show(AppMessage.MSGC023, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return returnValue;
        }
        #endregion

        private void btnSetNull_Click(object sender, EventArgs e)
        {
            this.SelectedId = null;
            this.SelectedFullName = null;
            this.SelectedIds = null;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #region private void GetSelectedId() 获得已被选择的权限主键
        /// <summary>
        /// 获得已被选择的权限主键数组
        /// </summary>
        private void GetSelectedId()
        {
            DataRow dataRow = BaseInterfaceLogic.GetSelecteRow(this.grdUser, "colSelected");
            if (dataRow == null)
            {
                // 默认当前的行
                dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdUser);
            }
            if (dataRow != null)
            {
                this.SelectedId = dataRow[BaseUserEntity.FieldId].ToString();
                this.SelectedFullName = dataRow[BaseUserEntity.FieldRealName].ToString();
            }
        }
        #endregion

        private void SelectUser()
        {
            if (BaseInterfaceLogic.CheckInputSelectOne(this.grdUser, "colSelected"))
            {
                DataRow dataRow = BaseInterfaceLogic.GetSelecteRow(this.grdUser, "colSelected");
                if (dataRow == null)
                {
                    // 默认当前的行
                    dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdUser);
                }
                if (dataRow != null)
                {
                    this.GetSelectedId();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        /// <summary>
        /// 选择用户
        /// </summary>
        /// <param name="close">关闭窗体</param>
        private void SelectMulti(bool close = true)
        {
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdUser, "colSelected"))
            {
                this.SelectedIds = this.GetSelectedIds();
                this.SelectedFullName = BaseBusinessLogic.ObjectsToList(this.GetSelectedFullNames());
                if (!close)
                {
                    if (this.OnSelected != null)
                    {
                        // 进行委托处理
                        if(this.OnSelected(this.SelectedIds))
                        {
                            this.RemoveUser(this.SelectedIds);
                            this.SelectedIds = null;
                        }
                        // 清除选中的数据
                        return;
                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// 添加的用户主键
        /// </summary>
        /// <param name="selectedId">选择的主键数组</param>
        /// <returns>是否成功</returns>
        public delegate bool OnSelectedEventHandler(string[] selectedIds);

        public event OnSelectedEventHandler OnSelected;

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (this.MultiSelect)
            {
                // 不要关闭窗体
                this.SelectMulti(false);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.MultiSelect)
            {
                // 选择好后，关闭窗体
                this.SelectMulti(true);
            }
            else
            {
                this.SelectUser();
            }
        }
    }
}