//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DotNet.WinForm
{
    using DotNet.Utilities;
    using DotNet.Business;

    /// <summary>
    /// FrmUserRoleAdmin.cs
    /// 角色－员工管理窗体
    ///		
    /// 修改记录
    ///
    ///     2011.02.24 版本：1.2 JiRiGaLa 增加复制粘贴功能。
    ///     2008.05.20 版本：1.1 JiRiGaLa 增加按权限域进行管理功能。
    ///     2007.05.28 版本：1.0 JiRiGaLa 员工-角色管理。
    ///		
    /// 版本：1.2
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.02.24</date>
    /// </author> 
    /// </summary> 
    public partial class FrmUserRoleAdmin : BaseForm
    {
        /// <summary>
        /// 用户授权
        /// </summary>
        private bool permissionAccredit = false;

        // 角色列表 DataTable
        private DataTable DTRole = new DataTable(BaseRoleEntity.TableName);
        private string[] roleIds = null;

        /// <summary>
        /// 权限域编号
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        /// <summary>
        /// 用户主键
        /// </summary>
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

        /// <summary>
        /// 用户姓名
        /// </summary>    
        private string TargetUserRealName
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

        public FrmUserRoleAdmin()
        {
            InitializeComponent();
        }

        public FrmUserRoleAdmin(string userId)
            : this()
        {
            this.TargetUserId = userId;
        }

        public FrmUserRoleAdmin(string userId, string realName)
            : this()
        {
            this.TargetUserId = userId;
            this.TargetUserRealName = realName;
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.ucUser.SimpleAdmin = true;
            this.ucUser.AllowNull = false;
            this.ucUser.PermissionItemScopeCode = this.PermissionItemScopeCode;

            this.btnRemove.Enabled = false;
            this.btnSelectAll.Enabled = false;
            this.btnInvertSelect.Enabled = false;
            this.btnRolePermission.Enabled = false;
            this.btnAddToRole.Enabled = this.permissionEdit;

            if (this.DTRole.Rows.Count > 0)
            {
                this.btnSelectAll.Enabled = this.permissionEdit;
                this.btnInvertSelect.Enabled = this.permissionEdit;
                this.btnRemove.Enabled = this.permissionDelete;
                this.btnRolePermission.Enabled = this.permissionAccredit;
            }

            // 这里判断是否有数据被复制
            this.btnCopy.Enabled = this.grdRole.RowCount > 0;
            object clipboardData = Clipboard.GetData("roleEntites");
            this.btnPaste.Enabled = (clipboardData != null);
        }
        #endregion

        #region private void BindData() 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        private void BindData()
        {
            this.grdRole.AutoGenerateColumns = false;
            this.grdRole.DataSource = this.DTRole.DefaultView;
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAccess = this.IsModuleAuthorized("RoleAdmin");
            this.permissionAdd = this.IsAuthorized("RoleAdmin.Add");
            this.permissionEdit = this.IsAuthorized("RoleAdmin.Edit");
            this.permissionDelete = this.IsAuthorized("RoleAdmin.Delete");
            this.permissionAccredit = this.IsAuthorized("UserAdmin.Accredit");
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdRole);
            // 获得角色数据
            // this.DTRole = DotNetService.Instance.RoleService.GetList(UserInfo);
            this.roleIds = DotNetService.Instance.UserService.GetUserRoleIds(UserInfo, this.TargetUserId);
            this.DTRole = DotNetService.Instance.RoleService.GetDataTableByIds(UserInfo, this.roleIds);
            // 获得角色列表
            this.GetRoles();
            // 加载树
            this.BindData();
        }
        #endregion

        private void ucUser_SelectedIndexChanged(string parentId)
        {
            this.FormOnLoad();
        }

        #region private void GetRoles() 获得角色列表
        /// <summary>
        /// 获得角色列表
        /// </summary>
        private void GetRoles()
        {
            // 绑定类型数据
            DataTable dataTable = DotNetService.Instance.RoleService.GetDefaultRoleDT(UserInfo);
            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbRole.DisplayMember = BaseRoleEntity.FieldRealName;
            this.cmbRole.ValueMember = BaseRoleEntity.FieldId;
            this.cmbRole.DataSource = dataTable.DefaultView;

            // 加载用户，显示用户的默认角色
            BaseUserEntity userEntity = DotNetService.Instance.UserService.GetEntity(UserInfo, this.ucUser.SelectedId);
            if (!string.IsNullOrEmpty(userEntity.RoleId))
            {
                this.cmbRole.SelectedValue = userEntity.RoleId;
            }
        }
        #endregion

        private void btnSelectAll_Click(object sender, EventArgs e)
        {


            foreach (DataGridViewRow dgvRow in grdRole.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }
            //foreach (DataRowView dataRowView in this.DTRole.DefaultView)
            //{
            //    dataRowView.Row[BaseBusinessLogic.SelectedColumn] = true.ToString();
            //}
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in grdRole.Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false);
            }

            //foreach (DataRowView dataRowView in this.DTRole.DefaultView)
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

        #region private bool BatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private bool BatchSave()
        {
            bool returnValue = true;
            string addToRoles = string.Empty;
            string removeFormRoles = string.Empty;

            foreach (DataGridViewRow dgvRow in grdRole.Rows)
            {
                DataRow dataRow = (dgvRow.DataBoundItem as DataRowView).Row;
                if (dataRow.RowState == DataRowState.Modified)
                {
                    if ((System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false))
                    {
                        // 添加了权限
                        addToRoles += dataRow[BaseRoleEntity.FieldId].ToString() + ";";
                    }
                    else
                    {
                        // 删除了权限
                        removeFormRoles += dataRow[BaseRoleEntity.FieldId].ToString() + ";";
                    }
                }
            }

            // 设定选中状态
            //foreach (DataRow dataRow in this.DTRole.Rows)
            //{
            //    if (dataRow.RowState == DataRowState.Modified)
            //    {
            //        if (dataRow["colSelected"].ToString().Equals(true.ToString()))
            //        {
            //            // 添加了权限
            //            addToRoles += dataRow[BaseRoleEntity.FieldId].ToString() + ";";
            //        }
            //        else
            //        {
            //            // 删除了权限
            //            removeFormRoles += dataRow[BaseRoleEntity.FieldId].ToString() + ";";
            //        }
            //    }
            //}

            string[] addToRoleIds = null;
            string[] removeFormRoleIds = null;
            if (addToRoles.Length > 0)
            {
                addToRoles = addToRoles.Substring(0, addToRoles.Length - 1);
                addToRoleIds = addToRoles.Split(';');
            }
            if (removeFormRoles.Length > 0)
            {
                removeFormRoles = removeFormRoles.Substring(0, removeFormRoles.Length - 1);
                removeFormRoleIds = removeFormRoles.Split(';');
            }
            // DotNetService.Instance.StaffService.RoleBatchSave(UserInfo, this.TargetStaffId, addToRoleIds, removeFormRoleIds);
            if (BaseSystemInfo.ShowInformation)
            {
                // 更新成功，进行提示
                MessageBox.Show(AppMessage.MSG0012, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return returnValue;
        }
        #endregion

        #region private string[] GetIds() 获得所有主键数组
        /// <summary>
        /// 获得所有主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetIds()
        {
            return BaseBusinessLogic.FieldToArray(this.DTRole, BaseRoleEntity.FieldId);
        }
        #endregion

        private bool OnSelected(string[] selectedIds)
        {
            DotNetService.Instance.UserService.AddUserToRole(UserInfo, this.TargetUserId, selectedIds);
            // 加载窗体
            this.FormOnLoad();
            // 设置按钮状态
            this.SetControlState();
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 用反射获得窗体
            FrmRoleSelect frmRoleSelect = new FrmRoleSelect();
            frmRoleSelect.OnSelected += new FrmRoleSelect.OnSelectedEventHandler(this.OnSelected);
            frmRoleSelect.AllowNull = false;
            frmRoleSelect.MultiSelect = true;
            frmRoleSelect.ShowRoleOnly = true;
            frmRoleSelect.RemoveIds = this.GetIds();
            if (frmRoleSelect.ShowDialog() == DialogResult.OK)
            {
                string[] selectedIds = frmRoleSelect.SelectedIds;
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
            return BaseInterfaceLogic.GetSelecteIds(this.grdRole, BaseRoleEntity.FieldId, "colSelected", true);
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
            returnValue = DotNetService.Instance.UserService.RemoveUserFromRole(UserInfo, this.TargetUserId, this.GetSelecteIds());
            this.FormLoaded = true;
            return returnValue;
        }
        #endregion

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdRole, "colSelected"))
            {
                if (MessageBox.Show(AppMessage.MSG0075, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    // 设置鼠标繁忙状态，并保留原先的状态
                    Cursor holdCursor = this.Cursor;
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        this.BatchRemove();
                        // 重新加载窗体
                        this.Form_Load(sender, e);
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

        private void btnRolePermission_Click(object sender, EventArgs e)
        {
            DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdRole);
            string id = dataRow[BaseRoleEntity.FieldId].ToString();
            string realName = dataRow[BaseRoleEntity.FieldRealName].ToString();

            string assemblyName = "DotNet.WinForm";
            string formName = "FrmRoleModulePermission";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmRolePermission = (Form)Activator.CreateInstance(assemblyType, id, realName, true);
            frmRolePermission.ShowDialog(this);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            // 读取数据
            List<BaseRoleEntity> roleEntites = new List<BaseRoleEntity>();

            for (int i = 0; i < this.DTRole.Rows.Count; i++)
            {
                BaseRoleEntity roleEntity = new BaseRoleEntity(this.DTRole.Rows[i]);
                roleEntites.Add(roleEntity);
            }
            // 复制到剪切板
            Clipboard.SetData("roleEntites", roleEntites);
            this.btnPaste.Enabled = true;
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            object clipboardData = Clipboard.GetData("roleEntites");
            if (clipboardData != null)
            {
                List<BaseRoleEntity> roleEntites = (List<BaseRoleEntity>)clipboardData;
                string[] addRoleIds = new string[roleEntites.Count];
                for (int i = 0; i < roleEntites.Count; i++)
                {
                    addRoleIds[i] = roleEntites[i].Id.ToString();
                }
                // 添加用户到角色
                DotNetService.Instance.UserService.AddUserToRole(this.UserInfo, this.TargetUserId, addRoleIds);
                // 加载窗体
                this.OnLoad(e);
            }
        }

        public override bool SaveEntity()
        {
            if (this.FormLoaded)
            {
                string roleId = string.Empty;
                if (this.cmbRole.SelectedValue != null && this.cmbRole.SelectedValue.ToString().Length > 0)
                {
                    roleId = this.cmbRole.SelectedValue.ToString();
                }
                DotNetService.Instance.UserService.SetDefaultRole(UserInfo, this.ucUser.SelectedId, roleId);
                this.Changed = true;
            }
            return true;
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    if (this.SaveEntity())
                    {
                        this.Close();

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