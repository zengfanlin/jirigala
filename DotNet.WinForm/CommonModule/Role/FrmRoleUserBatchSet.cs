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
    /// FrmRoleUserBatchSet.cs
    /// 权限设置-角色权限批量设置
    ///		
    /// 修改记录
    /// 
    ///     2010.12.24 版本：1.0 JiRiGaLa  角色权限批量设置。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.12.24</date>
    /// </author> 
    /// </summary>
    public partial class FrmRoleUserBatchSet : BaseForm
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

        public FrmRoleUserBatchSet()
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
            object clipboardData = Clipboard.GetData("userEntites");
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

            // 获得用户列表
            this.GetUserList();

            // 获得角色列表
            this.GetRoleList();

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
            this.lstRole.ValueMember = BaseRoleEntity.FieldId;
            this.lstRole.DisplayMember = BaseRoleEntity.FieldRealName;
            this.lstRole.DataSource = this.DTRole.DefaultView;
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
            foreach (DataRow dataRow in this.DTUser.Rows)
            {
                dataRow[BaseUserEntity.FieldRealName] = dataRow[BaseUserEntity.FieldUserName] + " [" + dataRow[BaseUserEntity.FieldRealName] + "]";
            }
            this.DTUser.DefaultView.Sort = BaseUserEntity.FieldSortCode;
            this.cklstUser.DataSource = this.DTUser.DefaultView;
            this.cklstUser.ValueMember = BaseUserEntity.FieldId;
            this.cklstUser.DisplayMember = BaseUserEntity.FieldRealName;
        }
        #endregion

        private void GetCurrentPermission()
        {
            //Pcsky 2012.05.02 未使用的功能，禁用
            //this.isUserClick = false;
            // 角色被选中状态取消
            for (int i = 0; i < this.cklstUser.Items.Count; i++)
            {
                this.cklstUser.SetItemChecked(i, false);
            }
            // 这些空间可以用了
            this.cklstUser.Enabled = true;
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
            // 获取当权角色中的用户列表
            this.GetRoleUsers();            
        }

        /// <summary>
        /// 获取当权角色中的用户列表
        /// </summary>
        private void GetRoleUsers()
        {
            // 获取当前角色中的用户
            string[] userIds = DotNetService.Instance.RoleService.GetRoleUserIds(this.UserInfo, this.TargetRoleId);
            // 把当前的用户设置为选中状态
            for (int i = 0; i < this.cklstUser.Items.Count; i++)
            {
                string userId = ((System.Data.DataRowView)this.cklstUser.Items[i])[BaseUserEntity.FieldId].ToString();
                if (Array.IndexOf(userIds, userId) >= 0)
                {
                    this.cklstUser.SetItemChecked(i, true);
                }
            }
        }

        private void cklstUser_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            /*
            if (this.isUserClick)
            {
                bool itemChecked = this.cklstUser.GetItemChecked(this.cklstUser.SelectedIndex);
                string userId = ((System.Data.DataRowView)this.cklstUser.Items[e.Index])[BaseUserEntity.FieldId].ToString();
                if (itemChecked)
                {
                    // 被撤销了
                    DotNetService.Instance.RoleService.RemoveUserFromRole(this.UserInfo, this.TargetRoleId, new string[] { userId });
                }
                else
                {
                    DotNetService.Instance.RoleService.AddUserToRole(this.UserInfo, this.TargetRoleId, new string[] { userId });
                }
            }
            */
        }

        private void btnClearPermission_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(AppMessage.MSG0200, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                DotNetService.Instance.RoleService.ClearRoleUser(this.UserInfo, this.TargetRoleId);
                this.GetCurrentPermission();
            }
        }


        private void btnCopy_Click(object sender, EventArgs e)
        {
            // 读取数据
            List<BaseUserEntity> userEntites = new List<BaseUserEntity>();
            for (int i = 0; i < this.cklstUser.CheckedItems.Count; i++)
            {
                BaseUserEntity userEntity = new BaseUserEntity(((System.Data.DataRowView)this.cklstUser.CheckedItems[i]).Row);
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
                // 获取当前的权限设置
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
                string[] userIds = DotNetService.Instance.RoleService.GetRoleUserIds(this.UserInfo, this.TargetRoleId);
                DotNetService.Instance.RoleService.RemoveUserFromRole(this.UserInfo, this.TargetRoleId, userIds);
                // 将新的角色添加到用户
                List<BaseUserEntity> userEntites = new List<BaseUserEntity>();
                for (int i = 0; i < this.cklstUser.CheckedItems.Count; i++)
                {
                    BaseUserEntity userEntity = new BaseUserEntity(((System.Data.DataRowView)this.cklstUser.CheckedItems[i]).Row);
                    userEntites.Add(userEntity);
                }
                string[] addUserIds = new string[userEntites.Count];
                for (int i = 0; i < userEntites.Count; i++)
                {
                    addUserIds[i] = userEntites[i].Id.ToString();
                }
                // 添加用户到角色
                DotNetService.Instance.RoleService.AddUserToRole(this.UserInfo, this.TargetRoleId, addUserIds);
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