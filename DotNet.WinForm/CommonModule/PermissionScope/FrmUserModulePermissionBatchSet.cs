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
    /// FrmUserModulePermissionBatchSet.cs
    /// 权限设置-用户权限批量设置
    ///		
    /// 修改记录
    ///
    ///     2011.11.01 版本：1.3 张广梁    优化批量保存。
    ///     2011.07.23 版本：1.2 张广梁    修改tvModule  tvPermissionItem节点选择时的逻辑错误 
    ///     2011.07.17 版本：1.1 张广梁    优化tvMoudle节点选择，自动选择父节点
    ///     2010.12.28 版本：1.0 JiRiGaLa  角色权限批量设置。
    ///		
    /// 版本：1.3
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.12.28</date>
    /// </author> 
    /// </summary>
    public partial class FrmUserModulePermissionBatchSet : BaseForm
    {
        /// <summary>
        /// 权限域（范围权限、数据权限）
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        /// <summary>
        /// 用户管理
        /// </summary>
        private DataTable DTUser = new DataTable(BaseUserEntity.TableName);

        /// <summary>
        /// 模块 DataTable
        /// </summary>
        private DataTable DTModule = new DataTable(BaseModuleEntity.TableName);

        private string[] moduleIds = null;

        /// <summary>
        /// 目标角色主键
        /// </summary>
        public string TargetUserId
        {
            get
            {
                string userId = string.Empty;
                if (this.lstUser.SelectedItem != null)
                {
                    userId = this.lstUser.SelectedValue.ToString();
                }
                return userId;
            }
        }

        /// <summary>
        /// 是否是用户点击了复选框
        /// </summary>
        //Pcsky 2012.05.02 未使用的功能，禁用
        //private bool isUserClick = true;

        public FrmUserModulePermissionBatchSet()
        {
            InitializeComponent();
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // 这里判断是否有数据被复制
            object clipboardData = Clipboard.GetData("userModulePermission");
            this.btnPaste.Enabled = (clipboardData != null);
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            //Pcsky 2012.05.02 未使用的功能，禁用
            //this.isUserClick = false;
            this.DTModule = this.GetModuleScope(this.PermissionItemScopeCode);
            // 这里需要只把有效的模块显示出来
            BaseBusinessLogic.SetFilter(this.DTModule, BaseModuleEntity.FieldEnabled, "1");
            // 未被打上删除标标志的
            // BaseBusinessLogic.SetFilter(this.DTModule, BaseModuleEntity.FieldDeletionStateCode, "0");
            this.LoadTree();
            // 获得用户列表
            this.GetUserList();

            //Pcsky 2012.05.02 未使用的功能，禁用
            //this.isUserClick = true;
        }
        #endregion

        #region private void GetUserList() 获取用户列表
        /// <summary>
        /// 获取用户列表
        /// </summary>
        private void GetUserList()
        {
            // 是否启用了权限范围管理
            this.DTUser = this.GetUserScope(this.PermissionItemScopeCode);
            // 对超级管理员不用设置权限
            BaseBusinessLogic.SetFilter(this.DTUser, BaseUserEntity.FieldCode, DefaultRole.Administrator.ToString(), true);
            this.DTUser.AcceptChanges();
            foreach (DataRow dataRow in this.DTUser.Rows)
            {
                dataRow[BaseUserEntity.FieldRealName] = dataRow[BaseUserEntity.FieldUserName] + " [" + dataRow[BaseUserEntity.FieldRealName] + "]";
            }
            this.DTUser.AcceptChanges();
            this.DTUser.DefaultView.Sort = BaseUserEntity.FieldSortCode;
            this.lstUser.ValueMember = BaseRoleEntity.FieldId;
            this.lstUser.DisplayMember = BaseRoleEntity.FieldRealName;
            this.lstUser.DataSource = this.DTUser.DefaultView;
        }
        #endregion

        #region private void LoadTree() 加载树的主键
        /// <summary>
        /// 加载树的主键
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvModule.BeginUpdate();
            this.tvModule.Nodes.Clear();
            this.LoadTreeModule();
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvModule.EndUpdate();
        }
        #endregion

        private void LoadTreeModule()
        {
            TreeNode treeNode = new TreeNode();
            this.LoadTreeModule(treeNode);
        }

        #region private void LoadTreeModule(TreeNode treeNode) 加载组织机构树的主键
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeModule(TreeNode treeNode)
        {
            //BaseInterfaceLogic.LoadTreeNodes(this.DTModule, BaseModuleEntity.FieldId, BaseModuleEntity.FieldParentId, BaseModuleEntity.FieldFullName, this.tvModule, treeNode);

            // 2012.06.09 Pcsky 改成按用户配置展开
            BaseInterfaceLogic.LoadTreeNodes(this.DTModule, BaseModuleEntity.FieldId, BaseModuleEntity.FieldParentId, BaseModuleEntity.FieldFullName, this.tvModule, treeNode, true, 0, null, 1, true);        
        }
        #endregion

        private void GetCurrentPermission()
        {
            //Pcsky 2012.05.02 未使用的功能，禁用
            //this.isUserClick = false;

            // 当前选中的角色被改变
            // 初始化权限设置页面
            this.ClearCheck();
            // 获取用户的权限
            this.GetUserPermission();

            //Pcsky 2012.05.02 未使用的功能，禁用
            //this.isUserClick = true;

            this.btnClearPermission.Enabled = true;
            this.btnCopy.Enabled = true;

            // 这些空间可以用了
            this.tvModule.Enabled = true;
        }

        private void lstUser_SelectedIndexChanged(object sender, EventArgs e)
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

        /// <summary>
        /// 获取角色的权限
        /// </summary>
        private void GetUserPermission()
        {
            // 获取用户的模块访问权限
            this.moduleIds = DotNetService.Instance.PermissionService.GetUserScopeModuleIds(UserInfo, this.TargetUserId, "Resource.AccessPermission");
            if (this.moduleIds != null && this.moduleIds.Length > 0)
            {
                this.tvModule.BeginUpdate();
                this.ModuleCheck();
                this.tvModule.EndUpdate();
            }            
        }        

        #region private void ClearCheck(TreeNode treeNode)
        /// <summary>
        /// 取消选中状态
        /// </summary>
        /// <param name="treeNode">树节点</param>
        private void ClearCheck(TreeNode treeNode)
        {
            if ((treeNode != null) && (treeNode.Tag != null) && ((treeNode.Tag as DataRow)[BaseModuleEntity.FieldId] != null))
            {
                treeNode.Checked = false;
                for (int i = 0; i < treeNode.Nodes.Count; i++)
                {
                    // 这里进行递规操作
                    this.ClearCheck(treeNode.Nodes[i]);
                }
            }
        }
        #endregion

        /// <summary>
        /// 初始化权限设置页面
        /// </summary>
        private void ClearCheck()
        {
            // 模块菜单选中状态被取消
            for (int i = 0; i < this.tvModule.Nodes.Count; i++)
            {
                this.ClearCheck(this.tvModule.Nodes[i]);
            }
        }

        private void ModuleCheck()
        {
            // 递归调用到所有的子节点 
            for (int i = 0; i < this.tvModule.Nodes.Count; i++)
            {
                this.ModuleCheck(this.tvModule.Nodes[i]);
            }
        }

        private void ModuleCheck(TreeNode treeNode)
        {
            if ((treeNode != null) && (treeNode.Tag != null) && ((treeNode.Tag as DataRow)[BaseModuleEntity.FieldId] != null))
            {
                //string permissionItemId = (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();

                string permissionItemId = (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();

                treeNode.Checked = Array.IndexOf(this.moduleIds, permissionItemId) >= 0;
                for (int i = 0; i < treeNode.Nodes.Count; i++)
                {
                    // 这里进行递规操作
                    this.ModuleCheck(treeNode.Nodes[i]);
                }
            }
        }

        private void tvModule_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // 点击节点执行保存时使用，edit by 张广梁
            //if (this.isUserClick)
            //{
            //    if (e.Node.Checked)
            //    {
            //        // 授予操作权限
            //        DotNetService.Instance.PermissionService.GrantUserModuleScope(this.UserInfo, this.TargetUserId, "Resource.AccessPermission", (e.Node.Tag as DataRow)[BaseModuleEntity.FieldId].ToString());
            //    }
            //    else
            //    {
            //        // 撤销操作权限
            //        DotNetService.Instance.PermissionService.RevokeUserModuleScope(this.UserInfo, this.TargetUserId, "Resource.AccessPermission", (e.Node.Tag as DataRow)[BaseModuleEntity.FieldId].ToString());
            //    }

            //}
        }


        private void tvModule_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            BaseInterfaceLogic.CheckChild(e.Node);
            BaseInterfaceLogic.CheckParent(e.Node);

        }

        private void btnClearPermission_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(AppMessage.MSG0600, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                // 清除权限
                DotNetService.Instance.PermissionService.ClearUserPermission(UserInfo, this.TargetUserId);
                this.GetCurrentPermission();
            }
        }

        [Serializable]
        private class UserModulePermission
        {
            public string[] GrantModuleIds = null;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            UserModulePermission userPermission = new UserModulePermission();
            // 模块访问权限复制到剪切板
            string[] grantModuleIds = this.GetGrantModuleIds();
            userPermission.GrantModuleIds = grantModuleIds;

            Clipboard.SetData("userModulePermission", userPermission);
            this.btnPaste.Enabled = true;
        }

        /// <summary>
        /// 授权的模块访问权限
        /// </summary>
        private string GrantModules = string.Empty;

        private void ModuleEntityToArray(TreeNode treeNode)
        {
            if (treeNode.Tag != null && (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId] != null)
            {
                // 提高运行速度
                //string moduleId = (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();

                string moduleId = (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();

                if (treeNode.Checked)
                {
                    this.GrantModules += moduleId + ";";
                }
            }
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.ModuleEntityToArray(treeNode.Nodes[i]);
            }
        }

        #region private string[] GetGrantModuleIds() 批量获取模块访问权限选中状态
        /// <summary>
        /// 批量获取模块访问权限选中状态
        /// </summary>
        private string[] GetGrantModuleIds()
        {
            for (int i = 0; i < this.tvModule.Nodes.Count; i++)
            {
                this.ModuleEntityToArray(this.tvModule.Nodes[i]);
            }
            string[] grantModuleIds = null;
            if (this.GrantModules.Length > 2)
            {
                this.GrantModules = this.GrantModules.Substring(0, this.GrantModules.Length - 1);
                grantModuleIds = this.GrantModules.Split(';');
            }
            this.GrantModules = string.Empty;
            return grantModuleIds;
        }
        #endregion

        private void btnPaste_Click(object sender, EventArgs e)
        {
            object clipboardData = Clipboard.GetData("userModulePermission");
            if (clipboardData != null)
            {
                UserModulePermission userPermission = (UserModulePermission)clipboardData;
                string[] grantModuleIds = userPermission.GrantModuleIds;
                DotNetService.Instance.PermissionService.GrantUserModuleScopes(UserInfo, this.TargetUserId, "Resource.AccessPermission", grantModuleIds);

                this.GetCurrentPermission();
            }
        }


        /// <summary>
        /// 撤销的权限
        /// </summary>
        private string RevokeModules = string.Empty;

        private void EntityToArray(TreeNode treeNode)
        {
            if (treeNode.Tag != null && (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId] != null)
            {
                // 提高运行速度
                string moduleId = (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                if (treeNode.Checked)
                {
                    // 这里是授权的权限
                    if (Array.IndexOf(this.moduleIds, moduleId) < 0)
                    {
                        this.GrantModules += moduleId + ";";
                    }
                }
                else
                {
                    // 这里是撤销的权限
                    if (Array.IndexOf(this.moduleIds, moduleId) >= 0)
                    {
                        this.RevokeModules += moduleId + ";";
                    }
                }
            }
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.EntityToArray(treeNode.Nodes[i]);
            }
        }

        #region private bool DoBatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private bool DoBatchSave()
        {
            bool returnValue = true;
            for (int i = 0; i < this.tvModule.Nodes.Count; i++)
            {
                this.EntityToArray(this.tvModule.Nodes[i]);
            }
            string[] grantModuleIds = null;
            string[] revokeModuleIds = null;
            if (this.GrantModules.Length > 2)
            {
                this.GrantModules = this.GrantModules.Substring(0, this.GrantModules.Length - 1);
                grantModuleIds = this.GrantModules.Split(';');
            }
            if (this.RevokeModules.Length > 1)
            {
                this.RevokeModules = this.RevokeModules.Substring(0, this.RevokeModules.Length - 1);
                revokeModuleIds = this.RevokeModules.Split(';');
            }
            this.GrantModules = string.Empty;
            this.RevokeModules = string.Empty;
            DotNetService.Instance.PermissionService.GrantUserModuleScopes(UserInfo, this.TargetUserId, "Resource.AccessPermission", grantModuleIds);
            DotNetService.Instance.PermissionService.RevokeUserModuleScopes(UserInfo, this.TargetUserId, "Resource.AccessPermission", revokeModuleIds);
            if (BaseSystemInfo.ShowInformation)
            {
                // 更新成功，进行提示
                MessageBox.Show(AppMessage.MSG0012, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return returnValue;
        }
        #endregion

        public void BatchSave()
        {
            // 批量保存
            // this.CheckParentChecked();
            if (this.DoBatchSave())
            {
                // 关闭窗口
                this.Close();
            }
        }

        private void btnBatchSave_Click(object sender, EventArgs e)
        {
            this.BatchSave();
        }
    }
}