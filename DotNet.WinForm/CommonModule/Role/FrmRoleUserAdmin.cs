//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FrmRoleUserAdmin.cs
    /// 角色－用户关系管理窗体
    ///		
    /// 修改记录
    ///
    ///     2011.05.20 版本：1.2 JiRiGaLa 已经删除的用户没必要显示，只显示有效的，未被删除的用户。
    ///     2008.02.18 版本：1.1 JiRiGaLa 显示速度、保存速度进行优化。
    ///     2007.05.26 版本：1.0 JiRiGaLa 角色－员工管理。
    ///		
    /// 版本：1.2
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.05.20</date>
    /// </author> 
    /// </summary>   
    public partial class FrmRoleUserAdmin : BaseForm
    {
        // 用户列表 DataTable
        private DataTable DTUser = new DataTable(BaseUserEntity.TableName);

        //Pcsky 2012.05.02 未使用的功能，禁用
        //private string[] UserIds = null;

        /// <summary>
        /// 权限域编号
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        // 角色主键
        private string TargetRoleId
        {
            set
            {
                this.ucRole.SelectedId = value;
            }
            get
            {
                return this.ucRole.SelectedId;
            }
        }

        // 角色名称     
        private string TargetRoleName
        {
            set
            {
                this.ucRole.SelectedFullName = value;
            }
            get
            {
                return this.ucRole.SelectedFullName;
            }
        }

        public FrmRoleUserAdmin()
        {
            InitializeComponent();
        }

        public FrmRoleUserAdmin(string roleId)
            : this()
        {
            this.TargetRoleId = roleId;
        }

        public FrmRoleUserAdmin(string roleId, string roleName)
            : this()
        {
            this.TargetRoleId = roleId;
            this.TargetRoleName = roleName;
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // 设置选择角色用户控件状态
            this.ucRole.AllowNull = false;
            this.ucRole.SimpleAdmin = true;
            this.ucRole.PermissionItemScopeCode = this.PermissionItemScopeCode;

            // this.btnSearch.Enabled = false;
            // this.txtSearch.Enabled = false;

            this.btnRemove.Enabled = false;
            this.btnSelectAll.Enabled = false;
            this.btnInvertSelect.Enabled = false;
            this.btnAdd.Enabled = this.permissionAdd;

            if (this.DTUser.DefaultView.Count > 0)
            {
                this.btnSelectAll.Enabled = this.permissionEdit;
                this.btnInvertSelect.Enabled = this.permissionEdit;
                this.btnRemove.Enabled = this.permissionDelete;
                // this.btnSearch.Enabled = true;
                // this.txtSearch.Enabled = true;
            }
            // 这里判断是否有数据被复制
            object clipboardData = Clipboard.GetData("userEntites");
            this.btnPaste.Enabled = (clipboardData != null);
            this.btnCopy.Enabled = this.grdUser.Rows.Count > 0;
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAccess = this.IsModuleAuthorized("RoleAdmin");   // 访问权限
            this.permissionAdd = this.IsAuthorized("RoleAdmin.Add");      // 新增权限
            this.permissionEdit = this.IsAuthorized("RoleAdmin.Edit");     // 编辑权限
            this.permissionDelete = this.IsAuthorized("RoleAdmin.Delete");   // 删除权限
        }
        #endregion

        #region private void BindData() 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        private void BindData()
        {
            if (this.TargetRoleId.Length > 0)
            {
                this.ucRole.SelectedId = this.TargetRoleId;
                this.ucRole.SelectedFullName = this.TargetRoleName;
            }
            // 加载员工数据主键
            this.grdUser.AutoGenerateColumns = false;
            this.grdUser.DataSource = this.DTUser.DefaultView;
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdUser);
            // 获得员工数据
            // this.UserIds = DotNetService.Instance.RoleService.GetRoleUserIds(UserInfo, this.TargetRoleId);
            // this.DTUser = DotNetService.Instance.UserService.GetDataTableByIds(UserInfo, this.UserIds);
            this.DTUser = DotNetService.Instance.UserService.GetDataTableByRole(UserInfo, this.TargetRoleId);
            // 绑定屏幕数据
            this.BindData();
        }
        #endregion

        private void btnCopy_Click(object sender, EventArgs e)
        {
            // 读取数据
            List<BaseUserEntity> userEntites = new List<BaseUserEntity>();
            for (int i = 0; i < this.DTUser.Rows.Count; i++)
            {
                BaseUserEntity userEntity = new BaseUserEntity(this.DTUser.Rows[i]);
                userEntites.Add(userEntity);
            }
            // 复制到剪切板
            Clipboard.SetData("userEntites", userEntites);
            this.btnPaste.Enabled = true;
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            object clipboardData = Clipboard.GetData("userEntites");
            if (clipboardData != null)
            {
                List<BaseUserEntity> userEntites = (List<BaseUserEntity>)clipboardData;
                string[] addUserIds = new string[userEntites.Count];
                for (int i = 0; i < userEntites.Count; i++)
                {
                    addUserIds[i] = userEntites[i].Id.ToString();
                }
                // 添加用户到角色
                DotNetService.Instance.RoleService.AddUserToRole(this.UserInfo, this.TargetRoleId, addUserIds);
                // 加载窗体
                this.OnLoad(e);
            }
        }

        private void ucRole_SelectedIndexChanged(string parentId)
        {
            if (!this.DesignMode)
            {
                this.FormOnLoad();
            }
        }

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
                    /*this.DTUser.DefaultView.RowFilter = BaseUserEntity.FieldUserName + " LIKE '" + search + "'"
                        + " OR " + BaseUserEntity.FieldCode + " LIKE '" + search + "'"
                        + " OR " + BaseUserEntity.FieldRealName + " LIKE '" + search + "'"
                        + " OR " + BaseUserEntity.FieldCompanyName + " LIKE '" + search + "'"
                        + " OR " + BaseUserEntity.FieldDepartmentName + " LIKE '" + search + "'"
                        + " OR " + BaseUserEntity.FieldDescription + " LIKE '" + search + "'";*/

                    this.DTUser.DefaultView.RowFilter = StringUtil.GetLike(BaseUserEntity.FieldUserName, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldCode, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldRealName, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldCompanyName, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldDepartmentName, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldDescription, search);                    
                }
            }
            // 设置按钮状态
            this.SetControlState();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in grdUser.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dgvRow in grdUser.Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false);
            }
        }

        //#region private bool BatchSave() 批量保存
        ///// <summary>
        ///// 批量保存
        ///// </summary>
        //private bool BatchSave()
        //{
        //    bool returnValue = true;
        //    string addToUsers = string.Empty;
        //    string removeFormUsers = string.Empty;

        //    foreach (DataGridViewRow dgvRow in grdUser.Rows)
        //    {
        //        DataRow dataRow = (dgvRow.DataBoundItem as DataRowView).Row;
        //        if (dataRow.RowState == DataRowState.Modified)
        //        {
        //            if ((System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false))
        //            {
        //                // 添加了权限
        //                addToUsers += dataRow[BaseUserEntity.FieldId].ToString() + ";";
        //            }
        //            else
        //            {
        //                // 删除了权限
        //                removeFormUsers += dataRow[BaseUserEntity.FieldId].ToString() + ";";
        //            }
        //        }
        //    }

        //    // 设定选中状态
        //    //foreach (DataRow dataRow in this.DTUser.Rows)
        //    //{
        //    //    if (dataRow.RowState == DataRowState.Modified)
        //    //    {
        //    //        if (dataRow["colSelected"].ToString().Equals(true.ToString()))
        //    //        {
        //    //            // 添加了权限
        //    //            addToUsers += dataRow[BaseUserEntity.FieldId].ToString() + ";";
        //    //        }
        //    //        else
        //    //        {
        //    //            // 删除了权限
        //    //            removeFormUsers += dataRow[BaseUserEntity.FieldId].ToString() + ";";
        //    //        }
        //    //    }
        //    //}

        //    string[] addToUserIds = null;
        //    string[] removeUserIds = null;
        //    if (addToUsers.Length > 0)
        //    {
        //        addToUsers = addToUsers.Substring(0, addToUsers.Length - 1);
        //        addToUserIds = addToUsers.Split(';');
        //    }
        //    if (removeFormUsers.Length > 0)
        //    {
        //        removeFormUsers = removeFormUsers.Substring(0, removeFormUsers.Length - 1);
        //        removeUserIds = removeFormUsers.Split(';');
        //    }
        //    DotNetService.Instance.RoleService.AddUserToRole(UserInfo, this.TargetRoleId, addToUserIds);
        //    DotNetService.Instance.RoleService.RemoveUserFromRole(UserInfo, this.TargetRoleId, removeUserIds);
        //    if (BaseSystemInfo.ShowInformation)
        //    {
        //        // 更新成功，进行提示
        //        MessageBox.Show(AppMessage.MSG0012, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    return returnValue;
        //}
        //#endregion

        //private void btnBatchSave_Click(object sender, EventArgs e)
        //{
        //    // 设置鼠标繁忙状态，并保留原先的状态
        //    Cursor holdCursor = this.Cursor;
        //    this.Cursor = Cursors.WaitCursor;
        //    try
        //    {
        //        // 批量保存
        //        if (this.BatchSave())
        //        {
        //            this.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.ProcessException(ex);
        //    }
        //    finally
        //    {
        //        // 设置鼠标默认状态，原来的光标状态
        //        this.Cursor = holdCursor;
        //    }
        //}

        private bool OnSelected(string[] selectedIds)
        {
            DotNetService.Instance.RoleService.AddUserToRole(UserInfo, this.TargetRoleId, selectedIds);
            // 加载窗体
            this.FormOnLoad();
            // 设置按钮状态
            this.SetControlState();
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 用反射获得窗体
            FrmUserSelect frmUserSelect = new FrmUserSelect();
            frmUserSelect.OnSelected += new FrmUserSelect.OnSelectedEventHandler(this.OnSelected);
            frmUserSelect.AllowNull = false;
            frmUserSelect.MultiSelect = true;
            frmUserSelect.PermissionItemScopeCode = this.PermissionItemScopeCode;
            frmUserSelect.RemoveIds = this.GetIds();
            if (frmUserSelect.ShowDialog() == DialogResult.OK)
            {
                string[] selectedIds = ((FrmUserSelect)frmUserSelect).SelectedIds;
                if (selectedIds != null)
                {
                    this.OnSelected(selectedIds);
                }
            }
        }

        #region private string[] GetSelecteIds() 获得已被选中主键数组
        /// <summary>
        /// 获得已被选中主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelecteIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdUser, BaseUserEntity.FieldId, "colSelected", true);
        }
        #endregion

        #region private string[] GetIds() 获得所有主键数组
        /// <summary>
        /// 获得所有主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetIds()
        {
            return BaseBusinessLogic.FieldToArray(this.DTUser, BaseUserEntity.FieldId);
        }
        #endregion

        #region private int BatchRemove() 批量移出
        /// <summary>
        /// 批量移出
        /// </summary>
        /// <returns>影响行数</returns>
        private int BatchRemove()
        {
            int returnValue = 0;
            this.FormLoaded = false;
            returnValue = DotNetService.Instance.RoleService.RemoveUserFromRole(UserInfo, this.TargetRoleId, this.GetSelecteIds());
            // 绑定数据
            this.FormOnLoad();
            // 设置按钮状态
            this.SetControlState();
            this.FormLoaded = true;
            return returnValue;
        }
        #endregion

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdUser, "colSelected"))
            {
                if (MessageBox.Show(AppMessage.MSG0075, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    // 设置鼠标繁忙状态，并保留原先的状态
                    Cursor holdCursor = this.Cursor;
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        this.BatchRemove();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.Changed)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
            this.Close();
        }
    }
}