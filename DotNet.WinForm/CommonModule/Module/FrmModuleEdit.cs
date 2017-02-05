//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{   
    using DotNet.Utilities;
    using DotNet.Business;
    
    /// <summary>
    /// FormRightMultiSelect.cs
    /// 模块管理-编辑模块窗体
    ///		
    /// 修改记录
    ///     2011.10.24 版本：1.2 张广梁    增加ParentId和FullName属性，修改SaveEntity方法，适应FrmPermissionItemAdmin中的处理。
    ///     2007.05.14 版本：1.1 JiRiGaLa  改进CheckInput()，SaveEntity()。
    ///     2007.05.10 版本：1.0 JiRiGaLa  编辑功能页面编写。
    ///		2012.04.22 版本：1.0 zwd       修改新增类似数据的添加 新增 SaveEntity()
    ///		
    /// 版本：1.2
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.10</date>
    /// </author> 
    /// </summary>
    /// 
    public partial class FrmModuleEdit : BaseForm
    {
        /// <summary>
        /// 父节点ID
        /// </summary>
        private string parentId = string.Empty;
        /// <summary>
        /// 父节点ID
        /// </summary>
        public string ParentId
        {
            set { this.parentId = value; }
            get { return this.parentId; }
        }

        /// <summary>
        /// 模块名称
        /// </summary>
        private string fullName;

        /// <summary>
        /// 模块名称
        /// </summary>
        public string FullName
        {
            get { return this.fullName; }
            set { this.fullName = value; }
        }

        public BaseModuleEntity moduleEntity = new BaseModuleEntity();

        public FrmModuleEdit()
        {
            InitializeComponent();
        }

        #region public FrmModuleEdit(string id) 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">主键</param>
        public FrmModuleEdit(string id):this()
        {
            this.EntityId = id;
        }
        #endregion

        #region public override void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public override void ShowEntity()
        {
            this.txtId.Text = moduleEntity.Id.ToString();
            this.ucParent.SelectedId = moduleEntity.ParentId.ToString();
            if (String.IsNullOrEmpty(this.ucParent.SelectedId))
            {
                this.ucParent.OpenId = moduleEntity.Id.ToString();
            }
            this.txtId.Text = moduleEntity.Id.ToString();
            this.txtCode.Text = moduleEntity.Code;
            this.txtFullName.Text = moduleEntity.FullName;
            // this.txtCategoryId.Text = ModuleEntity.CategoryId;
            this.txtNavigateUrl.Text = moduleEntity.NavigateUrl;
            this.txtTarget.Text = moduleEntity.Target;
            this.txtFormName.Text = moduleEntity.FormName;
            this.txtAssemblyName.Text = moduleEntity.AssemblyName;
            this.chkEnabled.Checked = moduleEntity.Enabled == 1;
            this.chkExpand.Checked = moduleEntity.Expand == 1;
            this.chkIsPublic.Checked = moduleEntity.IsPublic == 1;
            this.txtDescription.Text = moduleEntity.Description;
            // 这里需要进行判断，数据是否被其他人已经删除
            if (moduleEntity.Id == 0)
            {
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
            // 权限信息
            this.moduleEntity = DotNetService.Instance.ModuleService.GetEntity(UserInfo, this.EntityId);
            // 设置用户控件状态
            this.ucParent.CheckMove = true;
            this.ucParent.OpenId = this.EntityId;
            // 显示内容
            this.ShowEntity();
            // 设置焦点
            this.ActiveControl = this.txtFullName;
            this.txtFullName.Focus();
        }
        #endregion
        
        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns></returns>
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

        #region private BaseModuleEntity GetEntity() 转换数据
        /// <summary>
        /// 转换数据
        /// </summary>
        private BaseModuleEntity GetEntity()
        {
            if (string.IsNullOrEmpty(this.ucParent.SelectedId))
            {
                moduleEntity.ParentId = null;
            }
            else
            {
                moduleEntity.ParentId = int.Parse(this.ucParent.SelectedId);
            }
            moduleEntity.Code = this.txtCode.Text;
            moduleEntity.FullName = this.txtFullName.Text;
            moduleEntity.NavigateUrl = this.txtNavigateUrl.Text;
            moduleEntity.Target = this.txtTarget.Text;
            moduleEntity.FormName = this.txtFormName.Text;
            moduleEntity.AssemblyName = this.txtAssemblyName.Text;
            moduleEntity.Enabled = this.chkEnabled.Checked ? 1:0;
            moduleEntity.Expand = this.chkExpand.Checked ? 1 : 0;
            moduleEntity.IsPublic = this.chkIsPublic.Checked ? 1 : 0;
            moduleEntity.Description = this.txtDescription.Text;
            return moduleEntity;
        }
        #endregion

        private void btnSetTarget_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtTarget.Text))
            {
                this.txtTarget.Text = "fraContent";
            }
            else
            {
                this.txtTarget.Text = string.Empty;
            }
        }

        private void btnSetAssemblyName_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtAssemblyName.Text))
            {
                this.txtAssemblyName.Text = BaseSystemInfo.MainAssembly;
            }
            else
            {
                this.txtAssemblyName.Text = string.Empty;
            }
        }

        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.chkEnabled.Checked)
            {
                this.chkExpand.Checked = false;
                this.chkIsPublic.Checked = false;
            }
        }

        private void chkIsPublic_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkIsPublic.Checked)
            {
                this.chkEnabled.Checked = true;
            }
        }

        #region private void SetAccessPermission() 权限资源访问设置
        /// <summary>
        /// 权限资源访问设置
        /// </summary>
        private void SetAccessPermission()
        {
            string targetResourceCategory = BaseModuleEntity.TableName;
            string targetResourceId = this.moduleEntity.Id.ToString();
            string targetResourceName = this.moduleEntity.FullName;
            string permissionItemCode = "Resource.AccessPermission";
            if (!string.IsNullOrEmpty(targetResourceId))
            {
                string assemblyName = "DotNet.WinForm";
                string formName = "FrmResourceSetPermission";
                Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
                Form frmResourceSetPermission = (Form)Activator.CreateInstance(assemblyType, targetResourceCategory, targetResourceId, targetResourceName, permissionItemCode);
                frmResourceSetPermission.ShowDialog(this);
            }
        }
        #endregion

        private void btnAccessPermission_Click(object sender, EventArgs e)
        {
            // 权限资源访问设置
            this.SetAccessPermission();
        }

        #region private bool AddModule() 添加事件
        /// <summary>
        /// 
        /// </summary>
        /// <returns>添加成功</returns>
        private bool AddModule()
        {
            bool returnValue = false;
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            // 转换数据
            BaseModuleEntity moduleEntity = this.GetEntity();
            string statusCode = string.Empty;
            string statusMessage = string.Empty;

            this.EntityId = DotNetService.Instance.ModuleService.Add(UserInfo, moduleEntity, out statusCode, out statusMessage);
            
            this.FullName = moduleEntity.FullName;
            this.ParentId = this.ucParent.SelectedId;

            if (statusCode == StatusCode.OKAdd.ToString())
            {                
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
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
            return returnValue;
        }
        #endregion

        private void btnLikeAdd_Click(object sender, EventArgs e)
        {
            BaseModuleEntity entity = GetEntity();
            entity.Id = null;
            FrmModuleAdd frmModuleAdd = new FrmModuleAdd(entity);
            frmModuleAdd.ShowDialog();
        }

        #region public override bool SaveEntity() 保存
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
            this.ParentId = this.ucParent.SelectedId;
            this.FullName = this.txtFullName.Text;
            DotNetService.Instance.ModuleService.Update(UserInfo, this.moduleEntity, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKUpdate.ToString())
            {
                if (BaseSystemInfo.ShowInformation)
                {
                    // 添加成功，进行提示
                    MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.DialogResult = DialogResult.OK;
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
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }    
    }
}