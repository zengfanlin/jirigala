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
    /// FrmpermissionAdd.cs
    /// 权限管理-添加权限窗体
    ///		
    /// 修改记录
    ///     2011.10.24 版本：1.5 张广梁    增加ParentId和FullName属性，修改SaveEntity方法，适应FrmPermissionItemAdmin中的处理。
    ///     2008.03.24 版本：1.4 JiRiGaLa  改进主窗口的刷新功能，将功能改进为更加友善，主键也重新整理了一次。
    ///     2007.06.13 版本：1.3 JiRiGaLa  改进 GetPermission()。
    ///     2007.05.23 版本：1.2 JiRiGaLa  改进 ReturnStatusCode 方面的处理。
    ///     2007.05.13 版本：1.1 JiRiGaLa  改进 CheckInput()，SaveEntity()。
    ///     2007.05.11 版本：1.0 JiRiGaLa  权限编辑功能页面编写。
    ///		
    /// 版本：1.5
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.03.24</date>
    /// </author> 
    /// </summary>    
    public partial class FrmPermissionItemAdd : BaseForm
    {
        public BasePermissionItemEntity permissionItemEntity = null;

        /// <summary>
        /// 权限项实体
        /// </summary>
        public BaseModuleEntity moduleEntity = null;

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

        public FrmPermissionItemAdd()
        {
            InitializeComponent();
        }

        public FrmPermissionItemAdd(string parentId, string parentdFullName)
            : this()
        {
            this.ucParent.SelectedId = parentId;
            this.ucParent.SelectedFullName = parentdFullName;
        }

        /// <summary>
        /// 添加的菜单
        /// </summary>
        /// <returns>是否成功</returns>
        public delegate bool OnAddedEventHandler(string parentId, string fullName, string id);

        public event OnAddedEventHandler OnAdded;

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            // 系统管理员，还有自己创建的数据，可以进行修改
            if (UserInfo.IsAdministrator)
            {
                this.chkEnabled.Checked = true;
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
            if (this.permissionItemEntity != null)
            {
                // 将类转显示到页面
                if (this.permissionItemEntity.ParentId != null)
                {
                    this.ucParent.SelectedId = permissionItemEntity.ParentId.ToString();
                }
                this.txtCode.Text = this.permissionItemEntity.Code;
                this.txtFullName.Text = this.permissionItemEntity.FullName;
                this.chkIsScope.Checked = this.permissionItemEntity.IsScope == 1;
                this.chkEnabled.Checked = this.permissionItemEntity.Enabled == 1;
                this.txtDescription.Text = this.permissionItemEntity.Description;
            }
            // 设置焦点
            this.ActiveControl = this.txtFullName;
            this.txtFullName.Focus();
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // 若不是系统管理员，不能添加跟节点
            this.lblParentReq.Visible = false;
            this.ucParent.AllowNull = true;
            if (!UserInfo.IsAdministrator)
            {
                this.lblParentReq.Visible = true;
                this.ucParent.AllowNull = false;
            }
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 显示内容
            this.ShowEntity();
        }
        #endregion

        public FrmPermissionItemAdd(BasePermissionItemEntity entity)
            : this()
        {
            this.permissionItemEntity = entity;
        }


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

        #region private BasePermissionEntity GetEntity() 转换数据，将表单数据保存到实体类
        /// <summary>
        /// 读取屏幕中输入的数据
        /// </summary>
        /// <returns>操作权限项实体</returns>
        private BasePermissionItemEntity GetEntity()
        {
            if (this.permissionItemEntity == null)
            {
                this.permissionItemEntity = new BasePermissionItemEntity();
            }
            if (string.IsNullOrEmpty(this.ucParent.SelectedId))
            {
                this.permissionItemEntity.ParentId = null;
            }
            else
            {
                this.permissionItemEntity.ParentId = this.ucParent.SelectedId;
            }
            this.permissionItemEntity.Code = this.txtCode.Text;
            this.permissionItemEntity.FullName = this.txtFullName.Text;
            this.permissionItemEntity.IsScope = this.chkIsScope.Checked ? 1 : 0;
            this.permissionItemEntity.Enabled = this.chkEnabled.Checked ? 1 : 0;
            // this.permissionItemEntity.IsVisible = 1;
            this.permissionItemEntity.DeletionStateCode = 0;
            this.permissionItemEntity.Description = this.txtDescription.Text;
            return this.permissionItemEntity;
        }
        #endregion

        private void ucParent_SelectedIndexChanged(string selectedId)
        {
            if (this.permissionItemEntity != null)
            {
                this.permissionItemEntity.ParentId = selectedId;
            }
        }

        #region private void SaveEntity() 保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="close">关闭窗体</param>
        /// <returns>保存成功</returns>
        private bool SaveEntity(bool close)
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
            this.EntityId = DotNetService.Instance.PermissionItemService.Add(UserInfo, this.permissionItemEntity, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKAdd.ToString())
            {
                if (this.Owner != null && !close)
                {
                    if (this.Owner is FrmPermissionItemAdmin)
                    {
                        ((FrmPermissionItemAdmin)this.Owner).FormOnLoad();
                        // TODO：下述方法无法刷新树
                        //TreeNode parentNode = new TreeNode();
                        //if (!string.IsNullOrEmpty(this.ucParent.SelectedId))
                        //{
                        //    parentNode.Text = this.ucParent.SelectedFullName;
                        //    parentNode.Tag = this.ucParent.SelectedId;
                        //}
                        //else { parentNode = null; }
                        //TreeNode newNode = new TreeNode();
                        //newNode.Text = this.PermissionItemEntity.FullName;
                        //newNode.Tag = this.PermissionItemEntity.Id;
                        //((FrmPermissionItemAdmin)this.Owner).AddFromChild(newNode, parentNode);

                    }
                }
                if (BaseSystemInfo.ShowInformation)
                {
                    // 添加成功，进行提示
                    MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                returnValue = true;
                if (close)
                {
                    this.DialogResult = DialogResult.OK;
                }
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

        #region private void ClearForm() 清除窗体
        /// <summary>
        /// 清除窗体
        /// </summary>
        private void ClearForm()
        {
            this.permissionItemEntity.Id = 0;
            this.txtCode.Clear();
            this.txtFullName.Clear();
            this.txtDescription.Clear();
        }
        #endregion

        #region private void SaveData(bool close) 保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="close">关闭窗体</param>
        private void SaveData(bool close)
        {
            // 检查输入的有效性
            if (this.CheckInput())
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    if (this.SaveEntity(close))
                    {
                        if (OnAdded != null)
                        {
                            this.OnAdded(this.ParentId, this.FullName, this.EntityId);
                        }
                        if (close)
                        {
                            // 关闭窗口
                            this.Close();
                        }
                        else
                        {
                            // 重新加载窗体
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
            // 保存不关闭窗体
            this.SaveData(false);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 保存并关闭窗体
            this.SaveData(true);
        }
    }
}