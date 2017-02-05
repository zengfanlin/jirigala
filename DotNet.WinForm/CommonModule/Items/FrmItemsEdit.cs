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
    /// FrmItemsEdit.cs
    /// 项目详细资料窗体
    ///		
    /// 修改记录
    /// 
    ///     
    ///     2007.05.11 版本：1.0 JiRiGaLa  项目详细资料功能页面编写。
    ///     2012.04.22 版本：1.0 zwd       修改新增类似数据的添加
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.15</date>
    /// </author> 
    /// </summary>
    public partial class FrmItemsEdit : BaseForm
    {
        private BaseItemsEntity itemsEntity = null;

        public FrmItemsEdit()
        {
            InitializeComponent();
        }

        #region public FrmItemsEdit(string id) 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">主键</param>
        public FrmItemsEdit(string id)
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
        }
        #endregion

        #region public override void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public override void ShowEntity()
        {
            // 将类转显示到页面
            this.txtCode.Text = itemsEntity.Code;
            this.txtFullName.Text = itemsEntity.FullName;
            this.txtTargetTable.Text = itemsEntity.TargetTable;
            this.chkIsTree.Checked = itemsEntity.IsTree == 1;
            this.txtUseItemCode.Text = itemsEntity.UseItemCode;
            this.txtUseItemName.Text = itemsEntity.UseItemName;
            this.txtUseItemValue.Text = itemsEntity.UseItemValue;
            this.chkEnabled.Checked = itemsEntity.Enabled == 1;
            this.txtDescription.Text = itemsEntity.Description;
            // 这里需要进行判断，数据是否被其他人已经删除
            if (itemsEntity.Id == 0)
            {
                MessageBox.Show(AppMessage.MSG0005, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // 如果已经创建了明细，则不能重复创建  这里只是功能演示，等待吉日的规范程序调用。2011-10-25
            //select count(1) from sysobjects where name = '" + tablename + "'";
            //string sueryString = "select count(1) from sysobjects where name='" + this.txtTargetTable.Text.Trim()+ "'";
            //string conectionString =BaseSystemInfo.UserCenterDbConnection;
            //IDbHelper userCenterDbHelper = DbHelperFactory.GetHelper(conectionString);
            //    userCenterDbHelper.Open();
            //    int result = int.Parse(userCenterDbHelper.ExecuteScalar(sueryString).ToString());
            //    if (result !=0)
            //    {
            //        this.btnCreateTable.Enabled = false;
            //    }
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.itemsEntity = DotNetService.Instance.ItemsService.GetEntity(UserInfo, this.EntityId);
            // 显示内容
            this.ShowEntity();
            // 设置焦点
            this.ActiveControl = this.txtCode;
            this.txtCode.Focus();
            this.SetControlState();
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

        #region private BaseItemsEntity GetEntity() 转换数据
        /// <summary>
        /// 转换数据
        /// </summary>
        private BaseItemsEntity GetEntity()
        {
            this.itemsEntity.Code = this.txtCode.Text;
            this.itemsEntity.FullName = this.txtFullName.Text;
            this.itemsEntity.TargetTable = this.txtTargetTable.Text;
            this.itemsEntity.IsTree = this.chkIsTree.Checked ? 1 : 0;
            this.itemsEntity.UseItemCode = this.txtUseItemCode.Text;
            this.itemsEntity.UseItemName = this.txtUseItemName.Text;
            this.itemsEntity.UseItemValue = this.txtUseItemValue.Text;
            this.itemsEntity.Description = this.txtDescription.Text;
            this.itemsEntity.Enabled = this.chkEnabled.Checked ? 1 : 0;
            return this.itemsEntity;
        }
        #endregion

        private void CreateTable()
        {
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            DotNetService.Instance.ItemsService.CreateTable(UserInfo, this.txtTargetTable.Text, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OK.ToString())
            {
                if (BaseSystemInfo.ShowInformation)
                {
                    // 创建表结构成功，进行提示
                    MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            //  创建表结构成功，进行提示
            this.CreateTable();
        }

        #region private void SetAccessPermission() 权限资源访问设置
        /// <summary>
        /// 权限资源访问设置
        /// </summary>
        private void SetAccessPermission()
        {
            string targetResourceCategory = BaseModuleEntity.TableName;
            string targetResourceId = this.itemsEntity.Id.ToString();
            string targetResourceName = this.itemsEntity.FullName;
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

        #region private void AddEntity() 新建
        /// <summary>
        /// 新建
        /// </summary>
        /// <returns>新建成功</returns>
        private bool AddEntity()
        {
            bool returnValue = false;
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            // 转换数据
            BaseItemsEntity itemsEntity = this.GetEntity();
            this.EntityId = DotNetService.Instance.ItemsService.Add(UserInfo, itemsEntity, out statusCode, out statusMessage);
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
                else
                {
                    if (statusCode == StatusCode.ErrorNameExist.ToString())
                    {
                        this.txtFullName.SelectAll();
                        this.txtFullName.Focus();
                    }
                }
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
            return returnValue;
        }
        #endregion

        private void btnLikeAdd_Click(object sender, EventArgs e)
        {
            BaseItemsEntity entity = GetEntity();
            entity.Id = null;
            FrmItemsAdd frmItemsAdd = new FrmItemsAdd(entity);
            frmItemsAdd.ShowDialog();
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
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            this.GetEntity();
            DotNetService.Instance.ItemsService.Update(UserInfo, this.itemsEntity, out statusCode, out statusMessage);
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
                else
                {
                    if (statusCode == StatusCode.ErrorNameExist.ToString())
                    {
                        this.txtFullName.SelectAll();
                        this.txtFullName.Focus();
                    }
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