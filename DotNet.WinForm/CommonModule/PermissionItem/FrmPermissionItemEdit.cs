//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;
    
    /// <summary>
    /// FrmPermissionItemEdit.cs
    /// 权限管理-编辑权限窗体
    ///		
    /// 修改记录
    /// 
    ///     2011.10.24 版本：1.4 张广梁    增加ParentId和FullName属性，修改SaveEntity方法，适应FrmPermissionItemAdmin中的处理。
    ///     2008.03.24 版本：1.3 JiRiGaLa  整个程序进行调整。
    ///     2007.06.13 版本：1.2 JiRiGaLa  改进 GetPermission()。
    ///     2007.05.13 版本：1.1 JiRiGaLa  改进 CheckInput()，SaveEntity()。
    ///     2007.05.11 版本：1.0 JiRiGaLa  权限编辑功能页面编写。
    ///     2012.04.22 版本：1.0 zwd       修改新增类似数据的添加 新增 AddEntity()
    ///		
    /// 版本：1.4
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.06.13</date>
    /// </author> 
    /// </summary>    
    public partial class FrmPermissionItemEdit : BaseForm
    {
        public BasePermissionItemEntity PermissionItemEntity = new BasePermissionItemEntity();

        /// <summary>
        /// 权限项名称
        /// </summary>
        private string fullName = string.Empty;

        /// <summary>
        /// 权限项名称
        /// </summary>
        public string FullName
        {
            get { return this.fullName; }
            set { this.fullName = value; }
        }

        /// <summary>
        /// 父权限项id
        /// </summary>
        private string parentId = string.Empty;

        /// <summary>
        /// 父权限项id
        /// </summary>
        public string ParentId
        {
            get { return this.parentId; }
            set { this.parentId = value; }
        }

        public FrmPermissionItemEdit()
        {
            InitializeComponent();
        }

        public FrmPermissionItemEdit(string id)
            : this()
        {
            this.PermissionItemEntity.Id = int.Parse(id);
        }

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            if (!UserInfo.IsAdministrator)
            {
            }
        }
        #endregion

        #region public override void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public override void ShowEntity()
        {
            // 从数据权限读取类属性
            if (this.PermissionItemEntity.Id > 0)
            {
                // 将类转显示到页面
                this.ucParent.CheckMove = true;
                // 默认选中的节点
                this.ucParent.SelectedId = this.PermissionItemEntity.ParentId;
                if (this.PermissionItemEntity.Id > 0)
                {
                    // 原来的节点
                    this.ucParent.OpenId = this.PermissionItemEntity.Id.ToString();
                }
                this.txtCode.Text = this.PermissionItemEntity.Code;
                this.txtFullName.Text = this.PermissionItemEntity.FullName;
                this.chkIsScope.Checked = this.PermissionItemEntity.IsScope == 1;
                this.chkEnabled.Checked = this.PermissionItemEntity.Enabled == 1;
                this.txtDescription.Text = this.PermissionItemEntity.Description;
                // 自己的数据，自己能修改
                if (UserInfo.Id.Equals(this.PermissionItemEntity.CreateUserId))
                {
                }
                // 设置焦点
                this.ActiveControl = this.txtFullName;
                this.txtFullName.Focus();
            }
            else
            {
                // 这里需要进行判断，数据是否被其他人已经删除
                MessageBox.Show(AppMessage.MSG0005, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
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
            // 调用接口方式实现
            // this.PermissionEntity = Singleton<PermissionAdminService>.Instance.Get(UserInfo, this.PermissionEntity.Id);
            this.PermissionItemEntity = DotNetService.Instance.PermissionItemService.GetEntity(UserInfo, this.PermissionItemEntity.Id.ToString());
            // 获得页面的权限
            this.GetPermission();
            // 显示内容
            this.ShowEntity();
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
            this.txtCode.Text = this.txtCode.Text.TrimEnd();
            if (this.txtCode.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9977), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtCode.Focus();
                return false;
            }
            this.txtFullName.Text = this.txtFullName.Text.TrimEnd();
            if (this.txtFullName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9978), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtFullName.Focus();
                return false;
            }
            return returnValue;
        }
        #endregion

        #region private void GetEntity() 转换数据，将表单保存到实体类
        /// <summary>
        /// 转换数据，将表单保存到实体类
        /// </summary>
        private BasePermissionItemEntity GetEntity()
        {
            if (string.IsNullOrEmpty(this.ucParent.SelectedId))
            {
                this.PermissionItemEntity.ParentId = null;
            }
            else
            {
                this.PermissionItemEntity.ParentId = this.ucParent.SelectedId;
            }
            this.PermissionItemEntity.Code = this.txtCode.Text;
            this.PermissionItemEntity.FullName = this.txtFullName.Text;
            this.PermissionItemEntity.IsScope = this.chkIsScope.Checked ? 1:0;
            this.PermissionItemEntity.Enabled = this.chkEnabled.Checked ? 1:0;
            this.PermissionItemEntity.Description = this.txtDescription.Text;
            return this.PermissionItemEntity;
        }
        #endregion

        private void ucParent_SelectedIndexChanged(string selectedId)
        {
            if (!string.IsNullOrEmpty(selectedId))
            {
                this.PermissionItemEntity.ParentId = selectedId;
            }
            else
            {
                this.PermissionItemEntity.ParentId = "0";
            }
        }

        #region private void AddEntity() 添加保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="close">关闭窗体</param>
        /// <returns>保存成功</returns>
        private bool AddEntity()
        {
            bool returnValue = false;
            // 转换数据，将实体类保存到数据表
            this.GetEntity();
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            this.ParentId = this.ucParent.SelectedId;
            this.FullName = this.txtFullName.Text;
            // 调用接口方式实现
            // this.PermissionEntity.Id = Singleton<PermissionItemService>.Instance.Add(UserInfo, this.PermissionItemEntity, out statusCode, out statusMessage);
            DotNetService.Instance.PermissionItemService.Add(UserInfo, this.PermissionItemEntity, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKAdd.ToString())
            {
                if (this.Owner != null)
                {
                    if (this.Owner is FrmPermissionItemAdmin)
                    {
                        ((FrmPermissionItemAdmin)this.Owner).FormOnLoad();                       
                    }
                }
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
                // 是否编号重复了，提高友善性
                if (statusCode == StatusCode.ErrorCodeExist.ToString())
                {
                    this.txtCode.SelectAll();
                    this.txtCode.Focus();
                }
            }
            return returnValue;
        }
        #endregion

        private void btnLikeAdd_Click(object sender, EventArgs e)
        {
            BasePermissionItemEntity entity = GetEntity();
            entity.Id = null;
            FrmPermissionItemAdd frmpermissionItemAdd = new FrmPermissionItemAdd(entity);
            frmpermissionItemAdd.ShowDialog();
        }

        #region public override bool SaveEntity() 保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns>保存成功</returns>
        public override bool SaveEntity()
        {
            bool returnValue = false;
            this.GetEntity();
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            this.FullName = this.txtFullName.Text;
            this.ParentId = this.ucParent.SelectedId;
            // 调用接口方式实现
            DotNetService.Instance.PermissionItemService.Update(UserInfo, this.PermissionItemEntity, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKUpdate.ToString())
            {
                if (BaseSystemInfo.ShowInformation)
                {
                    // 添加成功，进行提示
                    MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                returnValue = true;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                // 是否编号重复了，提高友善性
                if (statusCode == StatusCode.ErrorCodeExist.ToString())
                {
                    this.txtCode.SelectAll();
                    this.txtCode.Focus();
                }
            }
            return returnValue;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
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
    }
}