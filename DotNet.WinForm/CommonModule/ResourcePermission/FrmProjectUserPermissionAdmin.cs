//-----------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------

using System;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;

    public partial class FrmProjectUserPermissionAdmin : FrmUserPermissionAdmin
    {
        public FrmProjectUserPermissionAdmin()
        {
            InitializeComponent();
        }

        protected override void btnPermission_Click(object sender, EventArgs e)
        {
            // 资源权限调用的参数

            // 资源分类
            string resourceCategory = BaseUserEntity.TableName;
            // 资源主键
            string resourceId = this.TargetUserId;
            // 资源名称
            string resourceName = this.TargetUserRealName;
            // 权限项编号
            string permissionItemCode = "ProjectAdmin";
            // 目标的分类
            string targetCategory = "Project";
            // 目标视图
            string targetSQL = "SELECT Id, RealName, Description FROM BaseProject WHERE DeletionStateCode = 0 AND Enabled = 1 ORDER BY SortCode";
            // 这里调用个性化的权限设置窗体
            string assemblyName = "DotNet.WinForm.ResourcePermission";
            string formName = "FrmResourcePermission";
            // 用反射调用窗体
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            // 调用窗体的构造函数
            Form frmUserPermissionAdmin = (Form)Activator.CreateInstance(assemblyType, resourceCategory, resourceId, resourceName, permissionItemCode, targetCategory, targetSQL);
            // 显示窗体
            frmUserPermissionAdmin.ShowDialog(this);
        }
    }
}
