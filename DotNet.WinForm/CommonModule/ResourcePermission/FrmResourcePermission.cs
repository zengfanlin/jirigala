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
    /// FrmResourcePermission.cs
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
    ///		<date>2007.06.06</date>
    /// </author> 
    /// </summary>  
    public partial class FrmResourcePermission : BaseForm
    {
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

        public string ResourceCategory = BaseUserEntity.TableName;
        public string ResourceId = string.Empty;
        public string ResourceName = string.Empty;

        public string TargetResourceCategory = "Project";
        public string TargetResourceSQL = "SELECT Id, RealName, Description FROM BaseProject WHERE DeletionStateCode = 0 AND Enabled = 1 ORDER BY SortCode";
        
        /// <summary>
        /// 资源表
        /// </summary>
        public DataTable TargetResourceDT = null;

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

        public FrmResourcePermission()
        {
            InitializeComponent();
        }

        public FrmResourcePermission(string resourceCategory, string resourceId, string resourceName, string permissionItemCode, string targetResourceCategory, string targetResourceSQL)
            : this()
        {
            this.ResourceCategory = resourceCategory;
            this.ResourceId = resourceId;
            this.ResourceName = resourceName;
            this.PermissionItemCode = permissionItemCode;
            this.TargetResourceCategory = targetResourceCategory;
            this.TargetResourceSQL = targetResourceSQL;
        }

        public FrmResourcePermission(string resourceCategory, string resourceId, string resourceName, string permissionItemCode, string targetResourceCategory, DataTable targetResourceDT)
            : this()
        {
            this.ResourceCategory = resourceCategory;
            this.ResourceId = resourceId;
            this.ResourceName = resourceName;
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
            this.lblResourceName.Text = this.ResourceName;
            this.lblPermissionItemName.Text = this.PermissionItemName;

            this.btnSelectAll.Enabled = false;
            this.btnInvertSelect.Enabled = false;
            if (this.TargetResourceDT.DefaultView.Count == 0)
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
            this.DataGridViewOnLoad(grdTargetResource);
            // 若没找到就默认为当前用户
            if (string.IsNullOrEmpty(ResourceId))
            {
                ResourceCategory = BaseUserEntity.TableName;
                ResourceId = this.UserInfo.Id;
                ResourceName = this.UserInfo.RealName;
            }

            if (string.IsNullOrEmpty(this.PermissionItemId))
            {
                BasePermissionItemEntity permissionItemEntity = DotNetService.Instance.PermissionItemService.GetEntityByCode(this.UserInfo, this.PermissionItemCode);
                this.PermissionItemId = permissionItemEntity.Id.ToString();
                this.PermissionItemName = permissionItemEntity.FullName;
            }

            // 当前用户对哪些资源有权限（用户自己的权限 + 相应的角色拥有的权限）
            // string[] ids = DotNetService.Instance.PermissionService.GetResourceScopeIds(this.UserInfo, this.ResourceId, this.TargetCategory, this.PermissionItemCode);

            // 被选中的权限
            this.setSelectIds = DotNetService.Instance.PermissionService.GetPermissionScopeTargetIds(this.UserInfo, this.ResourceCategory, this.ResourceId, this.TargetResourceCategory, this.PermissionItemCode);
            
            // 读取资源
            if (this.TargetResourceDT == null || !string.IsNullOrEmpty(this.TargetResourceSQL))
            {
                this.TargetResourceDT = DotNetService.Instance.UserCenterDbHelperService.Fill(this.UserInfo, this.TargetResourceSQL);
            }
            this.TargetResourceDT.PrimaryKey = new DataColumn[] { this.TargetResourceDT.Columns["Id"] };
            // 检查选中状态
            if (this.SetSelectIds != null)
            {
                for (int i = 0; i < this.SetSelectIds.Length; i++)
                {
                    DataRow dataRow = this.TargetResourceDT.Rows.Find(int.Parse(SetSelectIds[i]));
                    if (dataRow != null)
                    {
                        dataRow["colSelected"] = true;
                    }
                }
                this.TargetResourceDT.AcceptChanges();
            }
            this.grdTargetResource.Columns["colRealName"].DataPropertyName = this.ColumnRealName;
            this.grdTargetResource.Columns["colDescription"].DataPropertyName = this.ColumnDescription;
            this.grdTargetResource.AutoGenerateColumns = false;
            this.grdTargetResource.DataSource = this.TargetResourceDT.DefaultView;
        }
        #endregion

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in grdTargetResource.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }

            //foreach (DataRowView dataRowView in this.dtTargetResource.DefaultView)
            //{
            //    dataRowView.Row[BaseBusinessLogic.SelectedColumn] = true.ToString();
            //}
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in grdTargetResource.Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value??false);
            }

            //foreach (DataRowView dataRowView in this.dtTargetResource.DefaultView)
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

        #region private string[] GetSelectedIds() 获得已被选择的权限主键数组
        /// <summary>
        /// 获得已被选择的主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelectedIds()
        {
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
            return BaseInterfaceLogic.GetSelecteIds(this.grdTargetResource, "Id", "colSelected", false);
        }
        #endregion

        #region private int BatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private int BatchSave()
        {
            int returnValue = 0;
            // 被设置的权限
            string[] grantResourceIds = this.GetSelectedIds();
            returnValue += DotNetService.Instance.PermissionService.GrantPermissionScopeTargets(this.UserInfo, this.ResourceCategory, this.ResourceId, this.TargetResourceCategory, grantResourceIds, this.PermissionItemId);
            // 被取消的权限
            string[] revokeResourceIds = this.GetUnSelectedIds();
            returnValue += DotNetService.Instance.PermissionService.RevokePermissionScopeTargets(this.UserInfo, this.ResourceCategory, this.ResourceId, this.TargetResourceCategory, revokeResourceIds, this.PermissionItemId);
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