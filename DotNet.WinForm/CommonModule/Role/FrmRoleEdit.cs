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
    /// FrmRoleEdit.cs
    /// 角色管理 - 编辑色窗体
    ///		
    /// 修改记录
    /// 
    ///     2012.04.06 版本：2.1 JiRiGaLa  改进数据传递方法。
    ///     2010.09.19 版本：2.0 JiRiGaLa  整理代码，与基础窗体进行更加严密的整合。
    ///     2007.06.05 版本：1.7 JiRiGaLa  整理主键。
    ///     2007.06.01 版本：1.3 JiRiGaLa  整体整理主键
    ///     2007.05.17 版本：1.2 JiRiGaLa  增加了多国语言功能，调整了细节部分。
    ///     2007.05.14 版本：1.1 JiRiGaLa  改进CheckInput()，SaveEntity()。
    ///     2007.05.10 版本：1.0 JiRiGaLa  角色添加功能页面编写。
    ///		
    /// 版本：2.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.04.06</date>
    /// </author> 
    /// </summary>
    public partial class FrmRoleEdit : BaseForm
    {
        /// <summary>
        /// 角色实体
        /// </summary>
        private BaseRoleEntity roleEntity = null;

        private DataRow drRole = null;

        public FrmRoleEdit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数，需要被编辑的角色主键
        /// </summary>
        /// <param name="id">主键</param>
        public FrmRoleEdit(string id) : this()
        {
            this.EntityId = id;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据表</param>
        public FrmRoleEdit(DataRow dataRow)
            : this()
        {
            this.drRole = dataRow;
            roleEntity = new BaseRoleEntity(this.drRole);
            this.EntityId = roleEntity.Id.ToString();
        }

        #region private void BindItemDetails() 绑定下拉筐数据
        /// <summary>
        /// 绑定下拉筐数据
        /// </summary>
        private void BindItemDetails()
        {
            // 绑定职位数据
            DataTable dataTable = DotNetService.Instance.ItemDetailsService.GetDataTableByCode(UserInfo, "RoleCategory");
            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbRoleCategory.DisplayMember = BaseItemDetailsEntity.FieldItemName;
            this.cmbRoleCategory.ValueMember = BaseItemDetailsEntity.FieldItemValue;
            this.cmbRoleCategory.DataSource = dataTable.DefaultView;
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // 焦点定位
            this.ActiveControl = this.txtRealName;
            this.txtRealName.SelectAll();
            this.txtRealName.Focus();

            // 若这个角色是不可编辑的，那只有超级管理员才可以修改，编辑描述，谁都可以修改
            if (this.roleEntity.AllowEdit == 0)
            {
                this.SetControlState(this.UserInfo.IsAdministrator);
            }

            if (roleEntity.Code != null && this.roleEntity.Code.Equals(DefaultRole.Administrators.ToString()))
            {
                // 若是超级管理员，就不应该可以被修改了
                this.SetControlState(false);
            }
        }
        #endregion

        #region public override void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public override void ShowEntity()
        {
            // 将类转显示到页面
            this.txtId.Text = this.roleEntity.Id.ToString();
            this.txtRealName.Text = this.roleEntity.RealName;
            this.txtCode.Text = this.roleEntity.Code;
            if (!string.IsNullOrEmpty(roleEntity.CategoryCode))
            {
                this.cmbRoleCategory.SelectedValue = roleEntity.CategoryCode;
            }
            this.chkEnabled.Checked = this.roleEntity.Enabled == 1;
            this.txtDescription.Text = this.roleEntity.Description;
            // 这里需要进行判断，打开编辑窗体时，数据可能被别人已经删除了，有可能的
            if (this.roleEntity.Id == null)
            {
                MessageBox.Show(AppMessage.MSG0005, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                // 有数据被修改了，需要重新获取数据的意思
                this.Changed = true;
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 绑定下拉筐数据
            this.BindItemDetails();
            // 获取数据
            if (this.roleEntity == null && !string.IsNullOrEmpty(this.EntityId))
            {
                this.roleEntity = DotNetService.Instance.RoleService.GetEntity(this.UserInfo, this.EntityId);
            }
            // 显示实体
            this.ShowEntity();
        }
        #endregion

        public override void SetControlState(bool enabled)
        {
            this.txtRealName.Enabled = enabled;
            this.txtCode.Enabled = enabled;
            this.cmbRoleCategory.Enabled = enabled;
            this.chkEnabled.Enabled = enabled;
            this.txtDescription.Enabled = enabled;
            this.btnSave.Enabled = enabled;
        }

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        public override bool CheckInput()
        {
            bool returnValue = true;
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
        
        #region private BaseRoleEntity GetEntity() 读取屏幕数据
        /// <summary>
        /// 读取屏幕数据
        /// </summary>
        /// <returns>角色实体</returns>
        private BaseRoleEntity GetEntity()
        {
            // 这里是先把数据都读取到类里了，再把页面上的修改赋值给实体类
            roleEntity.RealName = this.txtRealName.Text;
            roleEntity.Code = this.txtCode.Text;
            roleEntity.Description = this.txtDescription.Text;
            roleEntity.Enabled = this.chkEnabled.Checked ? 1 : 0;
            roleEntity.CategoryCode = string.Empty;
            if (this.cmbRoleCategory.SelectedValue != null)
            {
                roleEntity.CategoryCode = this.cmbRoleCategory.SelectedValue.ToString();
            }
            /*
            this.drRole[BaseRoleEntity.FieldRealName] = this.txtRealName.Text;
            this.drRole[BaseRoleEntity.FieldCode] = this.txtCode.Text;
            this.drRole[BaseRoleEntity.FieldCategoryCode] = this.cmbRoleCategory.SelectedValue == null ? null : this.cmbRoleCategory.SelectedValue.ToString();
            this.drRole[BaseRoleEntity.FieldEnabled] = this.chkEnabled.Checked ? 1 : 0;
            this.drRole[BaseRoleEntity.FieldDescription] = this.txtDescription.Text;
            roleEntity = new BaseRoleEntity(this.drRole);
            */
            return roleEntity;
        }
        #endregion

        private void btnLikeAdd_Click(object sender, EventArgs e)
        {
            BaseRoleEntity entity = GetEntity();
            entity.Id = null;
            FrmRoleAdd frmRoleAdd = new FrmRoleAdd(entity);
            frmRoleAdd.ShowDialog();
        }

        #region public override bool SaveEntity() 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>保存成功</returns>
        public bool SaveEntity(bool update = true)
        {
            bool returnValue = false;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            this.GetEntity();
            if (update)
            {
                DotNetService.Instance.RoleService.Update(UserInfo, this.roleEntity, out statusCode, out statusMessage);
            }
            else
            {
                // 这个是添加的功能
                this.roleEntity.Id = null;
                DotNetService.Instance.RoleService.Add(UserInfo, this.roleEntity, out statusCode, out statusMessage);
                returnValue = true;
            }
            if (statusCode == StatusCode.OKUpdate.ToString())
            {
                if (BaseSystemInfo.ShowInformation)
                {
                    // 更新成功，进行提示
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
                        // 数据发生了变化
                        this.Changed = true;
                        this.DialogResult = DialogResult.OK;
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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}