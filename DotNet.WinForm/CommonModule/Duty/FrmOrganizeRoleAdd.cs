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
    /// FrmOrganizeRoleAdd.cs
    /// 岗位管理-添加岗位窗体
    ///		
    /// 修改记录
    /// 
    ///     2007.06.05 版本：1.7 JiRiGaLa  整理主键。
    ///     2007.06.01 版本：1.3 JiRiGaLa  整体整理主键
    ///     2007.05.17 版本：1.2 JiRiGaLa  增加了多国语言功能，调整了细节部分。
    ///     2007.05.14 版本：1.1 JiRiGaLa  改进CheckInput()，SaveEntity()。
    ///     2007.05.10 版本：1.0 JiRiGaLa  岗位添加功能页面编写。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.10</date>
    /// </author> 
    /// </summary>
    public partial class FrmOrganizeRoleAdd : BaseForm
    {
        /// <summary>
        /// 岗位实体
        /// </summary>
        private BaseRoleEntity roleEntity = null;

        /// <summary>
        /// 权限域编号
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        /// <summary>
        /// 被选中的组织机构主键
        /// </summary>
        public string OrganizeId
        {
            get
            {
                return this.ucOrganize.SelectedId;
            }
            set
            {
                this.ucOrganize.SelectedId = value;
            }
        }

        /// <summary>
        /// 被选中的组织机构全名
        /// </summary>
        public string OrganizeFullName
        {
            get
            {
                return this.ucOrganize.SelectedFullName;
            }
            set
            {
                this.ucOrganize.SelectedFullName = value;
            }
        }

        public FrmOrganizeRoleAdd()
        {
            InitializeComponent();
        }

        public FrmOrganizeRoleAdd(string id)
            : this()
        {
            this.EntityId = id;
        }

        public FrmOrganizeRoleAdd(string organizeId, string organizeFullName)
            : this(string.Empty)
        {
            this.OrganizeId = organizeId;
            this.OrganizeFullName = organizeFullName;
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // 按组织机构管理来增加员工
            this.ucOrganize.PermissionItemScopeCode = this.PermissionItemScopeCode;
            this.ucOrganize.AllowNull = false;
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 焦点定位
            this.ActiveControl = this.txtRealName;
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
            if (this.ucOrganize.SelectedFullName == null)
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

        #region private BaseRoleEntity GetEntity()
        /// <summary>
        /// 读取屏幕数据
        /// </summary>
        /// <returns>岗位实体</returns>
        private BaseRoleEntity GetEntity()
        {
            roleEntity = new BaseRoleEntity();
            roleEntity.OrganizeId = this.ucOrganize.SelectedId;
            roleEntity.Code = this.txtCode.Text;
            roleEntity.RealName = this.txtRealName.Text;
            roleEntity.CategoryCode = "Duty";
            roleEntity.Description = this.txtDescription.Text;
            roleEntity.Enabled = this.chkEnabled.Checked ? 1 : 0;
            roleEntity.AllowDelete = 1;
            roleEntity.AllowEdit = 1;
            roleEntity.DeletionStateCode = 0;
            return roleEntity;
        }
        #endregion

        #region private void ClearForm()
        /// <summary>
        /// 清除窗体
        /// </summary>
        private void ClearForm()
        {
            this.txtCode.Text = string.Empty;
            this.txtRealName.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            this.txtRealName.Focus();
        }
        #endregion

        #region private void AddRole(bool close = true)
        /// <summary>
        /// 保存岗位
        /// </summary>
        /// <param name="close">关闭窗体</param>
        private void AddRole(bool close = true)
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
                        if (close)
                        {
                            this.DialogResult = DialogResult.OK;
                            // 关闭窗口
                            this.Close();
                        }
                        else
                        {
                            this.ClearForm();
                        }
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
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.AddRole(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.AddRole(true);
        }

        private void btnRole_Click(object sender, EventArgs e)
        {
            Button btnRole = (Button)sender;
            this.txtCode.Text = btnRole.Name.Substring(3);
            if (!string.IsNullOrEmpty(this.ucOrganize.SelectedFullName))
            {
                this.txtRealName.Text = this.ucOrganize.SelectedFullName + "_" + btnRole.Text;
            }
            else
            {
                this.txtRealName.Text = btnRole.Text;
            }
            this.txtDescription.Text = btnRole.Text;
        }

        private void FrmOrganizeRoleAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Changed)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}