//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;
    
    /// <summary>
    /// FrmUserRoleBatchSet.cs
    /// 权限设置-用户权限批量设置
    ///		
    /// 修改记录
    /// 
    ///     2010.12.28 版本：1.0 JiRiGaLa  角色权限批量设置。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.12.28</date>
    /// </author> 
    /// </summary>
    public partial class FrmUserRoleBatchSet : BaseForm
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
        /// 用户管理
        /// </summary>
        private DataTable DTUser = new DataTable(BaseUserEntity.TableName);

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

        public FrmUserRoleBatchSet()
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
            object clipboardData = Clipboard.GetData("roleEntites");
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

            // 获得角色列表
            this.GetRoleList();

            // 获得用户列表
            this.GetUserList();

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
            this.DTRole.DefaultView.Sort = BaseRoleEntity.FieldSortCode;
            this.cklstRole.DataSource = this.DTRole.DefaultView;
            this.cklstRole.ValueMember = BaseUserEntity.FieldId;
            this.cklstRole.DisplayMember = BaseUserEntity.FieldRealName;
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
            // 超级管理员不用显示
            BaseBusinessLogic.SetFilter(this.DTUser, BaseUserEntity.FieldCode, DefaultRole.Administrator.ToString(), true);
            foreach (DataRow dataRow in this.DTUser.Rows)
            {
                dataRow[BaseUserEntity.FieldRealName] = dataRow[BaseUserEntity.FieldUserName] + " [" + dataRow[BaseUserEntity.FieldRealName] + "]";
            }
            this.DTUser.DefaultView.Sort = BaseUserEntity.FieldSortCode;
            this.lstUser.ValueMember = BaseRoleEntity.FieldId;
            this.lstUser.DisplayMember = BaseRoleEntity.FieldRealName;
            this.lstUser.DataSource = this.DTUser.DefaultView;
        }
        #endregion

        private void GetCurrentPermission()
        {
            //Pcsky 2012.05.02 未使用的功能，禁用
            //this.isUserClick = false;

            // 角色被选中状态取消
            for (int i = 0; i < this.cklstRole.Items.Count; i++)
            {
                this.cklstRole.SetItemChecked(i, false);
            }
            // 这些空间可以用了
            this.cklstRole.Enabled = true;

            // 获取用户的权限
            this.GetUserPermission();

            //Pcsky 2012.05.02 未使用的功能，禁用
            //this.isUserClick = true;

            this.btnClearPermission.Enabled = true;
            this.btnCopy.Enabled = true;
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
            // 获取当权用户中的角色列表
            this.GetRoleUsers();            
        }

        /// <summary>
        /// 获取当权角色中的用户列表
        /// </summary>
        private void GetRoleUsers()
        {
            // 获取当前角色中的用户
            string[] roleIds = DotNetService.Instance.UserService.GetUserRoleIds(this.UserInfo, this.TargetUserId);
            // 把当前的用户设置为选中状态
            for (int i = 0; i < this.cklstRole.Items.Count; i++)
            {
                string userId = ((System.Data.DataRowView)this.cklstRole.Items[i])[BaseUserEntity.FieldId].ToString();
                if (Array.IndexOf(roleIds, userId) >= 0)
                {
                    this.cklstRole.SetItemChecked(i, true);
                }
            }
        }

        private void cklstRole_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            /*
            if (this.isUserClick)
            {
                 bool itemChecked = this.cklstRole.GetItemChecked(this.cklstRole.SelectedIndex);
                 string roleId = ((System.Data.DataRowView)this.cklstRole.Items[e.Index])[BaseRoleEntity.FieldId].ToString();
                 if (itemChecked)
                 {
                    // 被撤销了
                     DotNetService.Instance.RoleService.RemoveUserFromRole(this.UserInfo, roleId, new string[] { this.TargetUserId });
                 }
                 else
                 {
                     DotNetService.Instance.RoleService.AddUserToRole(this.UserInfo, roleId, new string[] { this.TargetUserId });
                 }
            }
            */
        }

        private void btnClearPermission_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(AppMessage.MSG0200, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                DotNetService.Instance.UserService.ClearUserRole(this.UserInfo, this.TargetUserId);
                this.GetCurrentPermission();
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            // 读取数据
            List<BaseRoleEntity> roleEntites = new List<BaseRoleEntity>();
            for (int i = 0; i < this.cklstRole.CheckedItems.Count; i++)
            {
                BaseRoleEntity roleEntity = new BaseRoleEntity(((System.Data.DataRowView)this.cklstRole.CheckedItems[i]).Row);
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
                //获取当前的权限设置
                this.GetCurrentPermission();
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        private void Save()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.btnOK.Enabled = false;
                // 将原来的角色移出，获取当前角色中的用户
                string[] roleIds = DotNetService.Instance.UserService.GetUserRoleIds(this.UserInfo, this.TargetUserId);
                DotNetService.Instance.UserService.RemoveUserFromRole(this.UserInfo, this.TargetUserId, roleIds);
                // 将新的角色添加到用户
                List<BaseRoleEntity> roleEntites = new List<BaseRoleEntity>();
                for (int i = 0; i < this.cklstRole.CheckedItems.Count; i++)
                {
                    BaseRoleEntity roleEntity = new BaseRoleEntity(((System.Data.DataRowView)this.cklstRole.CheckedItems[i]).Row);
                    roleEntites.Add(roleEntity);
                }
                string[] addRoleIds = new string[roleEntites.Count];
                for (int i = 0; i < roleEntites.Count; i++)
                {
                    addRoleIds[i] = roleEntites[i].Id.ToString();
                }
                // 添加用户到角色
                DotNetService.Instance.UserService.AddUserToRole(this.UserInfo, this.TargetUserId, addRoleIds);
                this.btnOK.Enabled = true;
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Save();
        }
    }
}