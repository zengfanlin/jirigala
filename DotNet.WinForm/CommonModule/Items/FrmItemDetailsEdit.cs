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
    /// FormItemDetalsEdit.cs
    /// 选项详细资料窗体
    ///		
    /// 修改记录
    ///     
    ///     2007.05.11 版本：1.0 JiRiGaLa  项目详细资料功能页面编写。
    ///		2012.04.22 版本：1.0 zwd       修改新增类似数据的添加
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.15</date>
    /// </author> 
    /// </summary>
    public partial class FrmItemDetailsEdit : BaseForm
    {
        /// <summary>
        /// 目标基础主键表
        /// </summary>
        public string TargetTableName = BaseItemDetailsEntity.TableName;

        private BaseItemDetailsEntity itemDetailsEntity = null;

        public FrmItemDetailsEdit()
        {
            InitializeComponent();
        }

        #region public FrmItemDetailsEdit(string id) 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">主键</param>
        public FrmItemDetailsEdit(string id) : this()
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
            this.txtId.Text = itemDetailsEntity.Id.ToString();
            this.txtCode.Text = itemDetailsEntity.ItemCode;
            this.txtFullName.Text = itemDetailsEntity.ItemName;
            this.txtItemValue.Text = itemDetailsEntity.ItemValue;
            this.chkEnabled.Checked = itemDetailsEntity.Enabled.ToString().Equals("1");
            this.txtDescription.Text = itemDetailsEntity.Description;
            // 这里需要进行判断，数据是否被其他人已经删除
            if (itemDetailsEntity.Id == 0)
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
            this.itemDetailsEntity = DotNetService.Instance.ItemDetailsService.GetEntity(UserInfo, this.TargetTableName, this.EntityId);
            // 显示内容
            this.ShowEntity();
            // 设置焦点
            this.ActiveControl = this.txtCode;
            this.txtCode.Focus();
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

        #region private void EntityToDataTable() 转换数据
        /// <summary>
        /// 转换数据
        /// </summary>
        private BaseItemDetailsEntity GetEntity()
        {
            this.itemDetailsEntity.ItemCode = this.txtCode.Text;
            this.itemDetailsEntity.ItemName = this.txtFullName.Text;
            this.itemDetailsEntity.ItemValue = this.txtItemValue.Text;
            this.itemDetailsEntity.Enabled = this.chkEnabled.Checked ? 1 : 0;
            this.itemDetailsEntity.Description = this.txtDescription.Text;
            return this.itemDetailsEntity;
        }
        #endregion
                
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
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            this.GetEntity();
            DotNetService.Instance.ItemDetailsService.Update(UserInfo, this.TargetTableName, this.itemDetailsEntity, out statusCode, out statusMessage);
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

        #region public void AddEntity() 保存
        /// <summary>
        /// 添加
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
            // 转换数据
            //BaseItemDetailsEntity itemDetailsEntity = 
            this.GetEntity();

            this.EntityId = DotNetService.Instance.ItemDetailsService.Add(UserInfo, this.TargetTableName, itemDetailsEntity, out statusCode, out statusMessage);
            
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

        private void txtCode_DoubleClick(object sender, EventArgs e)
        {
            this.txtFullName.Text = this.txtCode.Text;
            this.txtItemValue.Text = this.txtCode.Text;
        }

        private void btnLikeAdd_Click(object sender, EventArgs e)
        {
            BaseItemDetailsEntity entity = GetEntity();
            entity.Id = null;
            FrmItemDetailsAdd frmItemDetailsAdd = new FrmItemDetailsAdd(entity);
            frmItemDetailsAdd.TargetTableName = this.TargetTableName;
            frmItemDetailsAdd.ShowDialog();
        }

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