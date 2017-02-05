//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    
    using DotNet.Business;
    

    /// <summary>
    /// FrmResourceSetPermission.cs
    /// 资源权限设置
    ///		
    /// 修改记录
    ///
    ///     2010.07.06 版本：1.0 JiRiGaLa 资源权限设置。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.07.06</date>
    /// </author> 
    /// </summary>  
    public partial class FrmResourceSetPermission : BaseForm
    {
        /// <summary>
        /// 用户表
        /// </summary>
        DataTable dtUser = new DataTable();

        /// <summary>
        /// 角色表
        /// </summary>
        DataTable dtRole = new DataTable();

        private string[] setSelectUserIds = null;
        /// <summary>
        /// 选中的用户主键数组
        /// </summary>
        public string[] SetSelectUserIds
        {
            get
            {
                return this.setSelectUserIds;
            }
            set
            {
                this.setSelectUserIds = value;
            }
        }

        private string[] setSelectRoleIds = null;
        /// <summary>
        /// 选中的角色主键数组
        /// </summary>
        public string[] SetSelectRoleIds
        {
            get
            {
                return this.setSelectRoleIds;
            }
            set
            {
                this.setSelectRoleIds = value;
            }
        }

        public string PermissionItemId = "";
        public string PermissionItemCode = "ProjectAdmin";
        public string PermissionItemName = "项目管理权限";

        public string TargetResourceCategory = "Project";
        public string TargetResourceId = "1";
        public string TargetResourceName = "药监局项目";


        public FrmResourceSetPermission()
        {
            InitializeComponent();
        }

        public FrmResourceSetPermission(string targetResourceCategory, string targetResourceId, string targetResourceName, string permissionItemCode)
            : this()
        {
            this.TargetResourceCategory = targetResourceCategory;
            this.TargetResourceId = targetResourceId;
            this.TargetResourceName = targetResourceName;
            this.PermissionItemCode = permissionItemCode;
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.lblTargetResourceName.Text = this.TargetResourceName;
            this.lblPermissionItemName.Text = this.PermissionItemName;

            this.btnSelectAll.Enabled = false;
            this.btnInvertSelect.Enabled = false;
            if (this.dtUser.DefaultView.Count == 0)
            {
                this.btnConfirm.Enabled = false;
            }
            else
            {
                this.btnSelectAll.Enabled = true;
                this.btnInvertSelect.Enabled = true;
                this.btnConfirm.Enabled = true;
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
            this.DataGridViewOnLoad(grdRole);
            this.DataGridViewOnLoad(grdUser);

            if (string.IsNullOrEmpty(this.PermissionItemId))
            {
                BasePermissionItemEntity permissionItemEntity = DotNetService.Instance.PermissionItemService.GetEntityByCode(this.UserInfo, this.PermissionItemCode);
                this.PermissionItemId = permissionItemEntity.Id.ToString();
                this.PermissionItemName = permissionItemEntity.FullName;
            }

            // 被选中的权限
            this.tcResource.SelectedIndex = 1;
            this.SetSelectUserIds = DotNetService.Instance.PermissionService.GetPermissionScopeResourceIds(this.UserInfo, BaseUserEntity.TableName, this.TargetResourceId, this.TargetResourceCategory, this.PermissionItemCode);
            // 读取资源
            this.dtUser = DotNetService.Instance.UserService.GetDataTable(this.UserInfo);
            this.dtUser.PrimaryKey = new DataColumn[] { this.dtUser.Columns["Id"] };
            // 检查选中状态
            this.grdUser.AutoGenerateColumns = false;
            this.grdUser.DataSource = this.dtUser.DefaultView;
            if (this.SetSelectUserIds != null)
            {
                foreach (DataGridViewRow dgvRow in grdUser.Rows)
                {
                    DataRow dataRow = (dgvRow.DataBoundItem as DataRowView).Row;
                    if (Array.IndexOf(this.SetSelectUserIds, dataRow["Id"].ToString()) >= 0)
                        dgvRow.Cells["colUserSelected"].Value = true;
                }
                //for (int i = 0; i < this.SetSelectUserIds.Length; i++)
                //{
                //    DataRow dataRow = this.dtUser.Rows.Find(int.Parse(SetSelectUserIds[i]));
                //    if (dataRow != null)
                //    {
                //        dataRow["colUserSelected"] = true;
                //    }
                //}
                //this.dtUser.AcceptChanges();
            }

            // 被选中的权限
            this.tcResource.SelectedIndex = 0;
            this.SetSelectRoleIds = DotNetService.Instance.PermissionService.GetPermissionScopeResourceIds(this.UserInfo, BaseRoleEntity.TableName, this.TargetResourceId, this.TargetResourceCategory, this.PermissionItemCode);
            // 读取资源
            this.dtRole = DotNetService.Instance.RoleService.GetDataTable(this.UserInfo);
            this.dtRole.PrimaryKey = new DataColumn[] { this.dtRole.Columns["Id"] };
            // 检查选中状态
            this.grdRole.AutoGenerateColumns = false;
            this.grdRole.DataSource = this.dtRole.DefaultView;
            if (this.SetSelectRoleIds != null)
            {
                foreach (DataGridViewRow dgvRow in grdRole.Rows)
                {
                    DataRow dataRow = (dgvRow.DataBoundItem as DataRowView).Row;
                    if (Array.IndexOf(this.SetSelectRoleIds, dataRow["Id"].ToString()) >= 0)
                        dgvRow.Cells["colRoleSelected"].Value = true;
                }
                //for (int i = 0; i < this.SetSelectRoleIds.Length; i++)
                //{
                //    DataRow dataRow = this.dtRole.Rows.Find(int.Parse(SetSelectRoleIds[i]));
                //    if (dataRow != null)
                //    {
                //        dataRow["colRoleSelected"] = true;
                //    }
                //}
                //this.dtRole.AcceptChanges();
            }

        }
        #endregion

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (this.tcResource.SelectedIndex == 0)
            {
                foreach (DataGridViewRow dgvRow in grdRole.Rows)
                {
                    dgvRow.Cells["colRoleSelected"].Value = true;
                }
                //foreach (DataRowView dataRowView in this.dtRole.DefaultView)
                //{
                //    dataRowView.Row[BaseBusinessLogic.SelectedColumn] = true.ToString();
                //}
            }
            else
            {
                foreach (DataGridViewRow dgvRow in grdUser.Rows)
                {
                    dgvRow.Cells["colUserSelected"].Value = true;
                }
                //foreach (DataRowView dataRowView in this.dtUser.DefaultView)
                //{
                //    dataRowView.Row[BaseBusinessLogic.SelectedColumn] = true.ToString();
                //}
            }
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            if (this.tcResource.SelectedIndex == 0)
            {
                foreach (DataGridViewRow dgvRow in grdRole.Rows)
                {
                    dgvRow.Cells["colRoleSelected"].Value = !(System.Boolean)(dgvRow.Cells["colRoleSelected"].Value??false);
                }
                //foreach (DataRowView dataRowView in this.dtRole.DefaultView)
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
            else
            {
                foreach (DataGridViewRow dgvRow in grdUser.Rows)
                {
                    dgvRow.Cells["colUserSelected"].Value = !(System.Boolean)(dgvRow.Cells["colUserSelected"].Value??false);
                }
                //foreach (DataRowView dataRowView in this.dtUser.DefaultView)
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
        }

        #region private string[] GetUserSelectedIds() 获得已被选择的权限主键数组
        /// <summary>
        /// 获得已被选择的主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetUserSelectedIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdUser, "Id", "colUserSelected", true);
        }
        #endregion

        #region private string[] GetUserUnSelectedIds() 获得已被选择的权限主键数组
        /// <summary>
        /// 获得未被选择的主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetUserUnSelectedIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdUser, "Id", "colUserSelected", false);
        }
        #endregion

        #region private string[] GetRoleSelectedIds() 获得已被选择的权限主键数组
        /// <summary>
        /// 获得已被选择的主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetRoleSelectedIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdRole, "Id", "colRoleSelected", true);
        }
        #endregion

        #region private string[] GetRoleUnSelectedIds() 获得已被选择的权限主键数组
        /// <summary>
        /// 获得未被选择的主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetRoleUnSelectedIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdRole, "Id", "colRoleSelected", false);
        }
        #endregion

        #region private int UserBatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private int UserBatchSave()
        {
            int returnValue = 0;
            // 被设置的权限
            string[] grantUserResourceIds = this.GetUserSelectedIds();
            returnValue += DotNetService.Instance.PermissionService.GrantPermissionScopeTarget(this.UserInfo, BaseUserEntity.TableName, grantUserResourceIds, this.TargetResourceCategory, this.TargetResourceId, this.PermissionItemId);
            // 被取消的权限
            string[] revokeUserResourceIds = this.GetUserUnSelectedIds();
            returnValue += DotNetService.Instance.PermissionService.RevokePermissionScopeTarget(this.UserInfo, BaseUserEntity.TableName, revokeUserResourceIds, this.TargetResourceCategory, this.TargetResourceId, this.PermissionItemId);
            return returnValue;
        }
        #endregion

        #region private int RoleBatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private int RoleBatchSave()
        {
            int returnValue = 0;
            // 被设置的权限
            string[] grantRoleResourceIds = this.GetRoleSelectedIds();
            returnValue += DotNetService.Instance.PermissionService.GrantPermissionScopeTarget(this.UserInfo, BaseRoleEntity.TableName, grantRoleResourceIds, this.TargetResourceCategory, this.TargetResourceId, this.PermissionItemId);
            // 被取消的权限
            string[] revokeRoleResourceIds = this.GetRoleUnSelectedIds();
            returnValue += DotNetService.Instance.PermissionService.RevokePermissionScopeTarget(this.UserInfo, BaseRoleEntity.TableName, revokeRoleResourceIds, this.TargetResourceCategory, this.TargetResourceId, this.PermissionItemId);
            return returnValue;
        }
        #endregion

        private int BatchSave()
        {
            return UserBatchSave() + RoleBatchSave();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                // 批量保存
                if (this.BatchSave() > 0)
                {
                    // 关闭窗口
                    this.FormOnLoad();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}