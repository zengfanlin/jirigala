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
    using DotNet.WinForm;

    /// <summary>
    /// FrmOrganizeRoleEdit.cs
    /// 角色管理-编辑岗位窗体
    ///		
    /// 修改记录
    /// 
    ///     2007.06.05 版本：1.7 JiRiGaLa  整理主键。
    ///     2007.06.01 版本：1.3 JiRiGaLa  整体整理主键
    ///     2007.05.17 版本：1.2 JiRiGaLa  增加了多国语言功能，调整了细节部分。
    ///     2007.05.14 版本：1.1 JiRiGaLa  改进CheckInput()，SaveEntity()。
    ///     2007.05.10 版本：1.0 JiRiGaLa  角色添加功能页面编写。
    ///     2012.04.22 版本：1.0 zwd       修改新增类似数据的添加 新增 AddEntity()
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.10</date>
    /// </author> 
    /// </summary>
    public partial class FrmOrganizeRoleEdit : BaseForm
    {
        /// <summary>
        /// 角色实体
        /// </summary>
        private BaseRoleEntity roleEntity = null;

        /// <summary>
        /// 权限域编号
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        public FrmOrganizeRoleEdit()
        {
            InitializeComponent();
        }

        public FrmOrganizeRoleEdit(string id) : this()
        {
            this.EntityId = id;
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.ucOrganize.AllowNull = false;
            this.ucOrganize.PermissionItemScopeCode = this.PermissionItemScopeCode;
        }
        #endregion

        #region public override void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public override void ShowEntity()
        {
            // 将类转显示到页面
            this.txtRealName.Text = roleEntity.RealName;
            this.ucOrganize.SelectedId = roleEntity.OrganizeId;
            this.txtCode.Text = roleEntity.Code;
            this.chkEnabled.Checked = roleEntity.Enabled.ToString().Equals("1");
            this.txtDescription.Text = roleEntity.Description;
            // 这里需要进行判断，数据是否被其他人已经删除
            if (roleEntity.Id == 0)
            {
                MessageBox.Show(AppMessage.MSG0005, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            // 设置按钮状态
            this.SetControlState();
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.roleEntity = DotNetService.Instance.RoleService.GetEntity(UserInfo, this.EntityId);
            // 显示内容
            this.ShowEntity();
            // 焦点定位
            this.ActiveControl = this.txtRealName;
            this.txtRealName.SelectAll();
            this.txtRealName.Focus();
        }
        #endregion

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        public override bool CheckInput()
        {
            bool returnValue = true;
            if (this.ucOrganize.SelectedFullName.Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9978), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ucOrganize.Focus();
                return false;
            }
            this.txtRealName.Text = this.txtRealName.Text.TrimEnd();
            if (this.txtRealName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9978), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtRealName.Focus();
                return false;
            }
            return returnValue;
        }
        #endregion

        #region private BaseRoleEntity GetEntity()
        /// <summary>
        /// 读取屏幕数据
        /// </summary>
        /// <returns>角色实体</returns>
        private BaseRoleEntity GetEntity()
        {
            roleEntity.OrganizeId = this.ucOrganize.SelectedId;
            roleEntity.Code = this.txtCode.Text;
            roleEntity.RealName = this.txtRealName.Text;
            roleEntity.Description = this.txtDescription.Text;
            roleEntity.Enabled = this.chkEnabled.Checked ? 1 : 0;
            return roleEntity;
        }
        #endregion

        #region public void AddEntity() 添加保存
        /// <summary>
        /// 添加保存
        /// </summary>
        /// <returns>添加成功</returns>
        public bool AddEntity()
        {
            bool returnValue = false;
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            this.GetEntity();
            DotNetService.Instance.RoleService.Add(UserInfo, this.roleEntity, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKAdd.ToString())
            {
                // 有数据被改变过
                this.Changed = true;
                if (BaseSystemInfo.ShowInformation)
                {
                    // 添加成功，进行提示
                    MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                returnValue = true;
            }
            else
            {
                MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                // 是否名称重复了，提高友善性
                if (statusCode == StatusCode.ErrorNameExist.ToString())
                {
                    this.txtRealName.SelectAll();
                    this.txtRealName.Focus();
                }
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
            return returnValue;
        }
        #endregion

        private void btnLikeAdd_Click(object sender, EventArgs e)
        {
            // 检查输入的有效性
            if (this.CheckInput())
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    if (this.AddEntity())
                    {
                        // 关闭窗口
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

        #region public override void SaveEntity() 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>保存成功</returns>
        public override bool SaveEntity()
        {
            bool returnValue = false;
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            this.GetEntity();
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            DotNetService.Instance.RoleService.Update(UserInfo, this.roleEntity, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKUpdate.ToString())
            {
                if (BaseSystemInfo.ShowInformation)
                {
                    // 更新成功，进行提示
                    MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.DialogResult = DialogResult.OK;
                returnValue = true;
            }
            else
            {
                MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                // 是否名称重复了，提高友善性
                if (statusCode == StatusCode.ErrorNameExist.ToString())
                {
                    this.txtRealName.SelectAll();
                    this.txtRealName.Focus();
                }
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
            return returnValue;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 检查输入的有效性
            if (this.CheckInput())
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    if (this.SaveEntity())
                    {
                        // 关闭窗口
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}