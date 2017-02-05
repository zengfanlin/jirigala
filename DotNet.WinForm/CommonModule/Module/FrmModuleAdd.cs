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
    /// FrmModuleMultiSelect.cs
    /// 权限管理-选择权限窗体
    ///		
    /// 修改记录
    ///     2011.11.15 版本：1.5 张广梁    完善对FrmModuleAdmin的刷新。
    ///     2011.10.24 版本：1.4 张广梁    增加“添加”和“保存”的区别。
    ///     2011.10.24 版本：1.3 张广梁    增加ParentId和FullName属性，修改SaveEntity方法，适应FrmModuleAdmin中的处理。
    ///     2010.04.07 版本：1.2 JiRiGaLa  改进为面向实体对象。
    ///     2007.05.14 版本：1.1 JiRiGaLa  改进CheckInput()，SaveEntity()。
    ///     2007.05.10 版本：1.0 JiRiGaLa  添加功能页面编写。
    ///		
    /// 版本：1.4
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.10</date>
    /// </author> 
    /// </summary>
    public partial class FrmModuleAdd : BaseForm
    {
        /// <summary>
        /// 模块实体
        /// </summary>
        public BaseModuleEntity moduleEntity = null;

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

        /// <summary>
        /// 父模块Id
        /// </summary>
        private string parentId;

        /// <summary>
        /// /// <summary>
        /// 父模块Id
        /// </summary>
        /// </summary>
        public string ParentId
        {
            get { return this.parentId; }
            set { this.parentId = value; }
        }

        public FrmModuleAdd()
        {
            InitializeComponent();
        }

        #region public FrmModuleAdd(string id) 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">主键</param>
        public FrmModuleAdd(string id)
            : this()
        {
            this.EntityId = id;
        }
        #endregion

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

        /// <summary>
        /// 添加的菜单
        /// </summary>
        /// <returns>是否成功</returns>
        public delegate bool OnAddedEventHandler(string parentId,string fullName, string id);

        public event OnAddedEventHandler OnAdded;

        #region public FrmModuleAdd(string moduleId, string moduleFullName): this(string.Empty)
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="moduleId">模块主键</param>
        /// <param name="moduleFullName">模块名称</param>
        public FrmModuleAdd(string moduleId, string moduleFullName)
            : this(string.Empty)
        {
            this.ucParent.SelectedId = moduleId;
            this.ucParent.SelectedFullName = moduleFullName;
        }
        #endregion

        #region public override void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public override void ShowEntity()
        {
            if (this.moduleEntity != null)
            {
                // 将类转显示到页面
                if (moduleEntity.ParentId != null)
                {
                    this.ucParent.SelectedId = moduleEntity.ParentId.ToString();
                }
                this.txtFullName.Text = moduleEntity.FullName;
                this.txtCode.Text = moduleEntity.Code;
                this.txtNavigateUrl.Text = moduleEntity.NavigateUrl;
                this.txtTarget.Text = moduleEntity.Target;
                this.txtFormName.Text = moduleEntity.FormName;
                this.txtAssemblyName.Text = moduleEntity.AssemblyName;
                this.chkEnabled.Checked = moduleEntity.Enabled == 1;
                this.chkExpand.Checked = moduleEntity.Expand == 1;
                this.chkIsPublic.Checked = moduleEntity.IsPublic == 1;
                this.txtDescription.Text = moduleEntity.Description;
            }
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 菜单信息
            // this.DTModule = DotNetService.Instance.ModuleService.Get(UserInfo, this.EntityId);
            // 显示内容
            this.ShowEntity();
            // 设置焦点
            this.ActiveControl = this.txtFullName;
            this.txtFullName.Focus();

        }
        #endregion

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

        public FrmModuleAdd(BaseModuleEntity entity)
            : this()
        {
            this.moduleEntity = entity;
        }

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool returnValue = true;
            //this.txtCode.Text = this.txtCode.Text.TrimEnd();            
            //if (this.txtCode.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9977), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.txtCode.Focus();
            //    return false;
            //}
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
            BaseModuleEntity entity = new BaseModuleEntity();
            if (string.IsNullOrEmpty(this.ucParent.SelectedId))
            {
                entity.ParentId = null;
            }
            else
            {
                entity.ParentId = int.Parse(this.ucParent.SelectedId);
            }
            entity.Code = this.txtCode.Text;
            entity.FullName = this.txtFullName.Text;
            entity.NavigateUrl = this.txtNavigateUrl.Text;
            entity.Target = this.txtTarget.Text;
            entity.FormName = this.txtFormName.Text;
            entity.AssemblyName = this.txtAssemblyName.Text;
            entity.Enabled = this.chkEnabled.Checked ? 1 : 0;
            entity.Expand = this.chkExpand.Checked ? 1 : 0;
            entity.IsPublic = this.chkIsPublic.Checked ? 1 : 0;
            entity.Description = this.txtDescription.Text;
            entity.DeletionStateCode = 0;
            entity.AllowDelete = 1;
            entity.AllowEdit = 1;
            return entity;
        }
        #endregion

        #region private bool SaveEntity(bool close) 保存
        /// <summary>
        /// 保存
        /// </summary>
        private bool SaveEntity(bool close)
        {
            bool returnValue = false;
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            // 转换数据
            BaseModuleEntity entity = this.GetEntity();
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            this.EntityId = DotNetService.Instance.ModuleService.Add(UserInfo, entity, out statusCode, out statusMessage);
            this.FullName = entity.FullName;
            this.ParentId = this.ucParent.SelectedId;
            if (statusCode == StatusCode.OKAdd.ToString())
            {
                // 即时刷新
                //if (this.Owner != null && !close)
                //{
                //    // 在sdi模式下即时刷新，在tabs和mdi下不起作用
                //    if (this.Owner is FrmModuleAdmin)
                //    {
                //        ((FrmModuleAdmin)this.Owner).FormOnLoad();
                //    }
                //}
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
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
            return returnValue;
        }
        #endregion

        #region private void ClearForm() 清除窗体
        /// <summary>
        /// 清除窗体
        /// </summary>
        private void ClearForm()
        {
            this.txtFullName.Clear();
            this.txtCode.Clear();
            this.txtNavigateUrl.Clear();
            this.txtDescription.Clear();
        }
        #endregion

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
                        this.Changed = true;
                        if (close)
                        {
                            // 关闭窗口
                            this.Close();
                        }
                        else
                        {
                            if (OnAdded != null)
                            {
                                this.OnAdded(this.parentId, this.FullName, this.EntityId);
                            }
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

        private void txtFullName_DoubleClick(object sender, EventArgs e)
        {
            this.txtCode.Text = this.txtFullName.Text;
        }

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}