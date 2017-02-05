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
    /// FrmRolePermissionItem.cs
    /// 权限设置-角色权限批量设置
    ///		
    /// 修改记录
    ///     2011.11.02 版本：1.4 张广梁    完善批量保存方法。
    ///     2011.10.16 版本：1.3 JiRiGaLa  友善的现实权限编号功能实现
    ///     2011.07.23 版本：1.2 张广梁    修改tvModule tvPermissionItem节点选择时的逻辑错误
    ///     2011.07.17 版本：1.1 张广梁    优化tvPermissionItem节点选择，自动选择父节点
    ///     2010.12.24 版本：1.0 JiRiGaLa  角色权限批量设置。
    ///		
    /// 版本：1.4
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.12.24</date>
    /// </author> 
    /// </summary>
    public partial class FrmRolePermissionItem : BaseForm
    {
        /// <summary>
        /// 权限域（范围权限、数据权限）
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable DTRole = new DataTable(BaseRoleEntity.TableName);

        /// <summary>
        /// 操作权限项数据
        /// </summary>
        public DataTable DTPermissionItem = new DataTable(BasePermissionItemEntity.TableName);

        private string[] PermissionItemIds = null;

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

        /// <summary>
        /// 是否是用户点击了复选框
        /// </summary>
        //Pcsky 2012.05.02 未使用的功能，禁用
        //private bool isUserClick = true;

        public FrmRolePermissionItem()
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
            object clipboardData = Clipboard.GetData("rolePermissionItem");
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
            // 获取当前用户的授权范围
            this.DTPermissionItem = this.GetPermissionItemScop(this.PermissionItemScopeCode);
            // 这里需要只把有效的权限项显示出来
            BaseBusinessLogic.SetFilter(this.DTPermissionItem, BasePermissionItemEntity.FieldEnabled, "1");
            // 未被打上删除标标志的
            // BaseBusinessLogic.SetFilter(this.DTPermissionItem, BasePermissionItemEntity.FieldDeletionStateCode, "0");

            // 获得角色列表
            this.GetRoleList();
            
            // 加载权限项树
            this.LoadTree();

            // 检查角色权限
            this.GetRolePermission();

            //Pcsky 2012.05.02 未使用的功能，禁用
            //this.isUserClick = true;
        }
        #endregion

        #region private void GetRoleList() 获取角色列表
        /// <summary>
        /// 获取角色列表
        /// </summary>
        private void GetRoleList()
        {
            // 是否启用了权限范围管理
            this.DTRole = this.GetRoleScope(this.PermissionItemScopeCode);
            // 对超级管理员不用设置权限
            BaseBusinessLogic.SetFilter(this.DTRole, BaseUserEntity.FieldCode, DefaultRole.Administrators.ToString(), true);            
            this.DTRole.DefaultView.Sort = BaseRoleEntity.FieldSortCode;
            this.lstRole.ValueMember = BaseRoleEntity.FieldId;
            this.lstRole.DisplayMember = BaseRoleEntity.FieldRealName;
            this.lstRole.DataSource = this.DTRole.DefaultView;
        }
        #endregion

        #region private void LoadTree() 加载树的主键
        /// <summary>
        /// 加载树的主键
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvPermissionItem.BeginUpdate();
            this.tvPermissionItem.Nodes.Clear();
            this.LoadTreePermissionItem();
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvPermissionItem.EndUpdate();
        }
        #endregion

        private void LoadTreePermissionItem()
        {
            TreeNode treeNode = new TreeNode();
            this.LoadTreePermissionItem(treeNode);
        }

        #region private void LoadTreePermissionItem(TreeNode treeNode) 加载组织机构树的主键
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreePermissionItem(TreeNode treeNode)
        {
            BaseInterfaceLogic.LoadTreeNodes(this.DTPermissionItem, BasePermissionItemEntity.FieldId, BasePermissionItemEntity.FieldParentId, BasePermissionItemEntity.FieldFullName, this.tvPermissionItem, treeNode, true, 1, BasePermissionItemEntity.FieldCode);
        }
        #endregion

        private void GetCurrentPermission()
        {
            //Pcsky 2012.05.02 未使用的功能，禁用
            //this.isUserClick = false;

            // 这些控件可以用了
            this.tvPermissionItem.Enabled = true;

            // 当前选中的角色被改变
            // 初始化权限设置页面
            this.ClearCheck();
            // 获取角色的权限
            this.GetRolePermission();

            //Pcsky 2012.05.02 未使用的功能，禁用
            //this.isUserClick = true;

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

        /// <summary>
        /// 获取角色的权限
        /// </summary>
        private void GetRolePermission()
        {
            // 获取模块访问权限
            // 获得角色的权限主键数组
            this.PermissionItemIds = DotNetService.Instance.PermissionService.GetRolePermissionItemIds(UserInfo, this.TargetRoleId);
            if (this.PermissionItemIds != null && this.PermissionItemIds.Length > 0)
            {
                this.tvPermissionItem.BeginUpdate();
                this.PermissionItemCheck();
                this.tvPermissionItem.EndUpdate();
            }
        }

        #region private void ClearCheck(TreeNode treeNode)
        /// <summary>
        /// 取消选中状态
        /// </summary>
        /// <param name="treeNode">树节点</param>
        private void ClearCheck(TreeNode treeNode)
        {
            if ((treeNode!= null && treeNode.Tag != null && (treeNode.Tag as DataRow) != null))
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
            // 操作权限项被选中状态取消
            for (int i = 0; i < this.tvPermissionItem.Nodes.Count; i++)
            {
                this.ClearCheck(this.tvPermissionItem.Nodes[i]);
            }
        }

        private void PermissionItemCheck()
        {
            // 递归调用到所有的子节点 
            for (int i = 0; i < this.tvPermissionItem.Nodes.Count; i++)
            {
                this.PermissionItemCheck(this.tvPermissionItem.Nodes[i]);
            }
        }

        private void PermissionItemCheck(TreeNode treeNode)
        {
            if ((treeNode!= null && treeNode.Tag != null && (treeNode.Tag as DataRow) != null))
            {
                string permissionItemId = (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                treeNode.Checked = Array.IndexOf(this.PermissionItemIds, permissionItemId) >= 0;
                for (int i = 0; i < treeNode.Nodes.Count; i++)
                {
                    // 这里进行递规操作
                    this.PermissionItemCheck(treeNode.Nodes[i]);
                }
            }
        }

        private void tvPermissionItem_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // 在点击节点执行保存时使用此方法， comment by zgl
            //if (this.isUserClick)
            //{
            //    if (e.Node.Checked)
            //    {
            //        // 授予操作权限
            //        DotNetService.Instance.PermissionService.GrantRolePermissionById(this.UserInfo, this.TargetRoleId, (e.Node.Tag as DataRow)[BaseModuleEntity.FieldId].ToString());
            //    }
            //    else
            //    {
            //        // 撤销操作权限
            //        DotNetService.Instance.PermissionService.RevokeRolePermissionById(this.UserInfo, this.TargetRoleId, (e.Node.Tag as DataRow)[BaseModuleEntity.FieldId].ToString());
            //    }

            //}
        }


        private void btnClearPermission_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(AppMessage.MSG0600, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                // 清除角色权限
                DotNetService.Instance.PermissionService.ClearRolePermission(this.UserInfo, this.TargetRoleId);
                this.GetCurrentPermission();
            }
        }

        [Serializable]
        private class RolePermissionItem
        {
            public string[] GrantPermissionIds = null;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            RolePermissionItem rolePermission = new RolePermissionItem();
            // 操作权限复制到剪切板
            string[] grantPermissionIds = this.GetGrantPermissionIds();
            rolePermission.GrantPermissionIds = grantPermissionIds;

            Clipboard.SetData("rolePermissionItem", rolePermission);
            this.btnPaste.Enabled = true;
        }

        /// <summary>
        /// 授权的操作权限
        /// </summary>
        private string GrantPermissions = string.Empty;

        private void PermissionEntityToArray(TreeNode treeNode)
        {
            if (treeNode.Tag != null)
            {
                // 提高运行速度
                string permissionItemId = (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                if (treeNode.Checked)
                {
                    this.GrantPermissions += permissionItemId + ";";
                }
            }
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.PermissionEntityToArray(treeNode.Nodes[i]);
            }
        }

        #region private string[] GetGrantPermissionIds() 批量获取操作权限选中状态
        /// <summary>
        /// 批量获取操作权限选中状态
        /// </summary>
        private string[] GetGrantPermissionIds()
        {
            for (int i = 0; i < this.tvPermissionItem.Nodes.Count; i++)
            {
                this.PermissionEntityToArray(this.tvPermissionItem.Nodes[i]);
            }
            string[] grantPermissionIds = null;
            if (this.GrantPermissions.Length > 2)
            {
                this.GrantPermissions = this.GrantPermissions.Substring(0, this.GrantPermissions.Length - 1);
                grantPermissionIds = this.GrantPermissions.Split(';');
            }
            this.GrantPermissions = string.Empty;
            return grantPermissionIds;
        }
        #endregion

        private void btnPaste_Click(object sender, EventArgs e)
        {
            object clipboardData = Clipboard.GetData("rolePermissionItem");
            if (clipboardData != null)
            {
                RolePermissionItem rolePermission = (RolePermissionItem)clipboardData;
                
                string[] grantPermissionIds = rolePermission.GrantPermissionIds;
                DotNetService.Instance.PermissionService.GrantRolePermissions(UserInfo, new string[]{ this.TargetRoleId } , grantPermissionIds);

                this.GetCurrentPermission();
            }
        }

        private void tvPermissionItem_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            BaseInterfaceLogic.CheckChild(e.Node);
            BaseInterfaceLogic.CheckParent(e.Node);
        }

        /// <summary>
        /// 撤销的权限
        /// </summary>
        string RevokePermissions = string.Empty;

        private void EntityToArray(TreeNode treeNode)
        {
            if (treeNode.Tag != null)
            {
                // 提高运行速度
                string moduleId = (treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                if (treeNode.Checked)
                {
                    // 这里是授权的权限
                    if (Array.IndexOf(this.PermissionItemIds, moduleId) < 0)
                    {
                        this.GrantPermissions += moduleId + ";";
                    }
                }
                else
                {
                    // 这里是撤销的权限
                    if (Array.IndexOf(this.PermissionItemIds, moduleId) >= 0)
                    {
                        this.RevokePermissions += moduleId + ";";
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
            for (int i = 0; i < this.tvPermissionItem.Nodes.Count; i++)
            {
                this.EntityToArray(this.tvPermissionItem.Nodes[i]);
            }
            string[] grantPermissionIds = null;
            string[] revokePermissionIds = null;
            if (this.GrantPermissions.Length > 2)
            {
                this.GrantPermissions = this.GrantPermissions.Substring(0, this.GrantPermissions.Length - 1);
                grantPermissionIds = this.GrantPermissions.Split(';');
            }
            if (this.RevokePermissions.Length > 1)
            {
                this.RevokePermissions = this.RevokePermissions.Substring(0, this.RevokePermissions.Length - 1);
                revokePermissionIds = this.RevokePermissions.Split(';');
            }
            this.GrantPermissions = string.Empty;
            this.RevokePermissions = string.Empty;
            DotNetService.Instance.PermissionService.GrantRolePermissions(UserInfo, new string[] { this.TargetRoleId }, grantPermissionIds);
            DotNetService.Instance.PermissionService.RevokeRolePermissions(UserInfo, new string[] { this.TargetRoleId }, revokePermissionIds);
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.BatchSave();
        }
    }
}