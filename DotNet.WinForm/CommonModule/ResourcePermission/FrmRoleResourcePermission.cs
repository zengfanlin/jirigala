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
    /// FrmRoleResourcePermission.cs
    /// 资源权限设置
    ///		
    /// 修改记录
    ///
    ///     2011.08.08 版本：2.0 JiRiGaLa 这里应该能直接传入数据表才对。
    ///     2010.07.06 版本：1.0 JiRiGaLa 资源权限设置。
    ///		
    /// 版本：2.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.08.08</date>
    /// </author> 
    /// </summary>  
    public partial class FrmRoleResourcePermission : BaseForm
    {
        /// <summary>
        /// 权限域（范围权限、数据权限）
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        /// <summary>
        /// 资源表
        /// </summary>
        public DataTable TargetResourceDT = null;

        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable DTRole = new DataTable(BaseRoleEntity.TableName);

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

        public string TargetResourceCategory = "Project";
        public string TargetResourceSQL = "SELECT Id, RealName, Description FROM BaseProject WHERE DeletionStateCode = 0 AND Enabled = 1 ORDER BY SortCode";

        public string PermissionItemId = "";
        public string PermissionItemCode = "ProjectAdmin";
        public string PermissionItemName = "项目管理权限";

        private string columnRealName = "RealName";
        /// <summary>
        /// 名称列字段名
        /// </summary>
        public string ColumnRealName
        {
            get
            {
                return columnRealName;
            }
            set
            {
                columnRealName = value;
            }
        }

        private string columnDescription = "Description";
        /// <summary>
        /// 描述列字段名
        /// </summary>
        public string ColumnDescription
        {
            get
            {
                return columnDescription;
            }
            set
            {
                columnDescription = value;
            }
        }

        /// <summary>
        /// 目标角色主键
        /// </summary>
        public string TargetRoleId
        {
            get
            {
                string roleId = string.Empty;
                if (this.lstRole.SelectedItem != null)
                {
                    roleId = this.lstRole.SelectedValue.ToString();
                }
                return roleId;
            }
        }

        public FrmRoleResourcePermission()
        {
            InitializeComponent();
        }

        public FrmRoleResourcePermission(string permissionItemCode, string targetResourceCategory, string targetResourceSQL)
            : this()
        {
            this.PermissionItemCode = permissionItemCode;
            this.TargetResourceCategory = targetResourceCategory;
            this.TargetResourceSQL = targetResourceSQL;
        }

        public FrmRoleResourcePermission(string permissionItemCode, string targetResourceCategory, DataTable targetResourceDT)
            : this()
        {
            this.PermissionItemCode = permissionItemCode;
            this.TargetResourceCategory = targetResourceCategory;
            this.TargetResourceDT = targetResourceDT;
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.lblPermissionItemName.Text = this.PermissionItemName;

            this.btnSelectAll.Enabled = false;
            this.btnInvertSelect.Enabled = false;
            this.btnConfirm.Enabled = false;
            if (this.TargetResourceDT.DefaultView.Count > 0)
            {
                this.btnSelectAll.Enabled = true;
                this.btnInvertSelect.Enabled = true;
                if (this.lstRole.Items.Count > 0)
                {
                    this.btnConfirm.Enabled = true;
                }
            }
            // 这里判断是否有数据被复制
            object clipboardData = Clipboard.GetData("itemsEntites");
            this.btnPaste.Enabled = (clipboardData != null);
        }
        #endregion

        #region private void GetRoleList() 获取角色列表
        /// <summary>
        /// 获取角色列表
        /// </summary>
        private void GetRoleList()
        {
            // 是否启用了权限范围管理
            if (BaseSystemInfo.UsePermissionScope && !this.UserInfo.IsAdministrator)
            {
                this.DTRole = DotNetService.Instance.PermissionService.GetRoleDTByPermissionScope(this.UserInfo, UserInfo.Id, this.PermissionItemScopeCode);
            }
            else
            {
                this.DTRole = DotNetService.Instance.RoleService.GetDataTable(this.UserInfo);
            }
            // 对超级管理员不用设置权限
            BaseBusinessLogic.SetFilter(this.DTRole, BaseUserEntity.FieldCode, DefaultRole.Administrators.ToString(), true);            
            
            this.DTRole.DefaultView.Sort = BaseRoleEntity.FieldSortCode;
            this.lstRole.ValueMember = BaseRoleEntity.FieldId;
            this.lstRole.DisplayMember = BaseRoleEntity.FieldRealName;
            this.lstRole.DataSource = this.DTRole.DefaultView;
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdTargetResource);
            if (string.IsNullOrEmpty(this.PermissionItemId))
            {
                BasePermissionItemEntity permissionItemEntity = DotNetService.Instance.PermissionItemService.GetEntityByCode(this.UserInfo, this.PermissionItemCode);
                this.PermissionItemId = permissionItemEntity.Id.ToString();
                this.PermissionItemName = permissionItemEntity.FullName;
            }

            // 获得角色列表
            this.GetRoleList();

            this.GetRolePermission();
        }
        #endregion

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            
            foreach (DataGridViewRow dgvRow in grdTargetResource.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }
            /*
            foreach (DataRowView dataRowView in this.DTTargetResource.DefaultView)
            {
                dataRowView.Row[BaseBusinessLogic.SelectedColumn] = true.ToString();
            }*/
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            
            foreach (DataGridViewRow dgvRow in grdTargetResource.Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value??false);
            }
            /*
            foreach (DataRowView dataRowView in this.DTTargetResource.DefaultView)
            {
                if (dataRowView.Row[BaseBusinessLogic.SelectedColumn].ToString().Equals(true.ToString()))
                {
                    dataRowView.Row[BaseBusinessLogic.SelectedColumn] = false.ToString();
                }
                else
                {
                    dataRowView.Row[BaseBusinessLogic.SelectedColumn] = true.ToString();
                }
            }*/
        }

        #region private string[] GetSelectedIds() 获得已被选择的权限主键数组
        /// <summary>
        /// 获得已被选择的主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelectedIds()
        {
            //return BaseInterfaceLogic.GetSelecteIds(this.DTTargetResource.DefaultView, "Id", "colSelected", true);
            return BaseInterfaceLogic.GetSelecteIds(this.grdTargetResource, "Id", "colSelected", true);
        }
        #endregion

        #region private string[] GetUnSelectedIds() 获得已被选择的权限主键数组
        /// <summary>
        /// 获得未被选择的主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetUnSelectedIds()
        {
            //return BaseInterfaceLogic.GetSelecteIds(this.DTTargetResource.DefaultView, "Id", "colSelected", false);
            return BaseInterfaceLogic.GetSelecteIds(this.grdTargetResource, "Id", "colSelected", false);
        }
        #endregion

        /// <summary>
        /// 初始化权限设置页面
        /// </summary>
        private void ClearCheck()
        {

            foreach (DataGridViewRow dgvRow in grdTargetResource.Rows)
            {
                dgvRow.Cells["colSelected"].Value = false;
            }
            /*
            // 用户被选中状态取消
            foreach (DataRowView dataRowView in this.DTTargetResource.DefaultView)
            {
                dataRowView.Row["colSelected"] = false.ToString();
                
            }*/
        }

        /// <summary>
        /// 获取角色的权限
        /// </summary>
        private void GetRolePermission()
        {
            // 当前用户对哪些资源有权限（用户自己的权限 + 相应的角色拥有的权限）
            // string[] ids = DotNetService.Instance.PermissionService.GetResourceScopeIds(this.UserInfo, this.ResourceId, this.TargetCategory, this.PermissionItemCode);

            // 被选中的权限
            this.setSelectIds = DotNetService.Instance.PermissionService.GetPermissionScopeTargetIds(this.UserInfo, BaseRoleEntity.TableName, this.TargetRoleId, this.TargetResourceCategory, this.PermissionItemCode);
            // 读取资源
            if (this.TargetResourceDT == null && !string.IsNullOrEmpty(this.TargetResourceSQL))
            {
                this.TargetResourceDT = DotNetService.Instance.UserCenterDbHelperService.Fill(this.UserInfo, this.TargetResourceSQL);
            }
            this.TargetResourceDT.PrimaryKey = new DataColumn[] { this.TargetResourceDT.Columns["Id"] };
            // 检查选中状态
            this.grdTargetResource.Columns["colRealName"].DataPropertyName = this.ColumnRealName;
            this.grdTargetResource.Columns["colDescription"].DataPropertyName = this.ColumnDescription;
            this.grdTargetResource.AutoGenerateColumns = false;
            this.grdTargetResource.DataSource = this.TargetResourceDT.DefaultView;
            if (this.SetSelectIds != null)
            {
               
                foreach (DataGridViewRow dgvRow in grdTargetResource.Rows)
                {
                    DataRow dataRow = (dgvRow.DataBoundItem as DataRowView).Row;
                    if (Array.IndexOf(this.SetSelectIds, dataRow["Id"].ToString()) >= 0)
                        dgvRow.Cells["colSelected"].Value = true;
                }
                 /*
                for (int i = 0; i < this.SetSelectIds.Length; i++)
                {
                    DataRow dataRow = this.DTTargetResource.Rows.Find(int.Parse(SetSelectIds[i]));
                    if (dataRow != null)
                    {
                        dataRow["colSelected"] = true;
                    }
                }*/
                //this.DTTargetResource.AcceptChanges();
            }
        }

        private void GetCurrentPermission()
        {
            // 初始化权限设置页面
            this.ClearCheck();
            // 获取角色的权限
            this.GetRolePermission();
            this.btnClearPermission.Enabled = true;
            this.btnCopy.Enabled = true;
        }

        private void lstRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.GetCurrentPermission();
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

        private void btnClearPermission_Click(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DotNetService.Instance.PermissionService.ClearPermissionScopeTarget(this.UserInfo, BaseRoleEntity.TableName, this.TargetRoleId, this.TargetResourceCategory, this.PermissionItemId);
                // 重新刷新数据
                this.GetCurrentPermission();
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

        private void btnCopy_Click(object sender, EventArgs e)
        {
            // 读取数据
            List<BaseItemsEntity> itemsEntites = new List<BaseItemsEntity>();

            foreach (DataGridViewRow dgvRow in grdTargetResource.Rows)
            {
                if ((System.Boolean)(dgvRow.Cells["colSelected"].Value??false))
                {
                    BaseItemsEntity itemsEntity = new BaseItemsEntity();
                    itemsEntity.Id = int.Parse((dgvRow.DataBoundItem as DataRowView).Row["id"].ToString());
                    itemsEntites.Add(itemsEntity);
                }
            }

            //for (int i = 0; i < this.DTTargetResource.Rows.Count; i++)
            //{
            //    if (this.DTTargetResource.Rows[i][BaseBusinessLogic.SelectedColumn].ToString() == true.ToString())
            //    {
            //        BaseItemsEntity itemsEntity = new BaseItemsEntity();
            //        itemsEntity.Id = int.Parse(this.DTTargetResource.Rows[i]["Id"].ToString());
            //        itemsEntites.Add(itemsEntity);
            //    }
            //}
            // 复制到剪切板
            Clipboard.SetData("itemsEntites", itemsEntites);
            this.btnPaste.Enabled = true;
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            object clipboardData = Clipboard.GetData("itemsEntites");
            if (clipboardData != null)
            {
                List<BaseItemsEntity> itemsEntites = (List<BaseItemsEntity>)clipboardData;
                string[] grantResourceIds = new string[itemsEntites.Count];
                for (int i = 0; i < itemsEntites.Count; i++)
                {
                    grantResourceIds[i] = itemsEntites[i].Id.ToString();
                }
                // 添加用户到角色
                if (grantResourceIds.Length > 0)
                {
                    DotNetService.Instance.PermissionService.GrantPermissionScopeTargets(this.UserInfo, BaseRoleEntity.TableName, this.TargetRoleId, this.TargetResourceCategory, grantResourceIds, this.PermissionItemId);
                }
                // 加载窗体
                this.GetCurrentPermission();
            }
        }

        #region private int BatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private int BatchSave()
        {
            int returnValue = 0;
            // 被设置的权限
            string[] grantResourceIds = this.GetSelectedIds();
            if (grantResourceIds.Length > 0)
            {
                returnValue += DotNetService.Instance.PermissionService.GrantPermissionScopeTargets(this.UserInfo, BaseRoleEntity.TableName, this.TargetRoleId, this.TargetResourceCategory, grantResourceIds, this.PermissionItemId);
            }
            // 被取消的权限
            string[] revokeResourceIds = this.GetUnSelectedIds();
            if (revokeResourceIds.Length > 0)
            {
                returnValue += DotNetService.Instance.PermissionService.RevokePermissionScopeTargets(this.UserInfo, BaseRoleEntity.TableName, this.TargetRoleId, this.TargetResourceCategory, revokeResourceIds, this.PermissionItemId);
            }
            return returnValue;
        }
        #endregion

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
                    // 重新刷新数据
                    this.GetRolePermission();
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