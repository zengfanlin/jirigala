//-----------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------

using System;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;

    public partial class FrmProjectRolePermissionAdmin : FrmRoleAdmin
    {
        public FrmProjectRolePermissionAdmin()
        {
            InitializeComponent();
        }

        protected override void btnPermission_Click(object sender, EventArgs e)
        {
            // 资源权限调用的参数
            string resourceCategory = BaseRoleEntity.TableName;
            string resourceId = this.TargetRoleId;
            string resourceName = this.TargetRoleRealName;
            string permissionItemCode = "ProjectAdmin";
            string targetCategory = "Project";
            string targetSQL = "SELECT Id, RealName, Description FROM BaseProject WHERE DeletionStateCode = 0 AND Enabled = 1 ORDER BY SortCode";
            string assemblyName = "DotNet.WinForm.ResourcePermission";
            string formName = "FrmResourcePermission";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserPermissionAdmin = (Form)Activator.CreateInstance(assemblyType, resourceCategory, resourceId, resourceName, permissionItemCode, targetCategory, targetSQL);
            frmUserPermissionAdmin.ShowDialog(this);
        }
    }
}
