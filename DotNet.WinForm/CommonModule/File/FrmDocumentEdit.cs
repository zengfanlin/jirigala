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
    /// FrmDocumentEdit.cs
    /// 文档管理 - 编辑窗体
    /// 
    ///	byte[] byteArray = System.Text.Encoding.Default.GetBytes(str);
    ///	string str = System.Text.Encoding.Default.GetString(byteArray);
    /// 
    /// 修改记录
    /// 
    ///     2008.11.17 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.11.17</date>
    /// </author> 
    /// </summary>
    public partial class FrmDocumentEdit : BaseForm
    {
        public FrmDocumentEdit()
        {
            InitializeComponent();
        }

        BaseFileEntity FileEntity = null;

        public FrmDocumentEdit(string id) : this()
        {
            this.EntityId = id;
        }

        #region public override void GetPermission()
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
        }
        #endregion

        #region private void ShowEntity(BaseFileEntity fileEntity)
        /// <summary>
        /// 显示内容
        /// </summary>
        private void ShowEntity(BaseFileEntity fileEntity)
        {
            this.txtFileName.Text = fileEntity.FileName;
            this.txtContent.Text = string.Empty;
            if (fileEntity.Contents != null)
            {
                this.txtContent.Text = System.Text.Encoding.Default.GetString(fileEntity.Contents);
            }
            this.txtDescription.Text = fileEntity.Description;
            this.chbEnabled.Checked = fileEntity.Enabled == 1;
        }
        #endregion

        #region public override void FormOnLoad()
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // DataTable dtFile = DotNetService.Instance.FileService.Get(UserInfo, this.EntityId);
            this.FileEntity = new BaseFileEntity();
            this.FileEntity.Contents = DotNetService.Instance.FileService.Download(UserInfo, this.EntityId);
            // 显示内容
            this.ShowEntity(this.FileEntity);
            // 设置焦点
            this.ActiveControl = this.txtFileName;
            this.txtFileName.Focus();
        }
        #endregion

        #region public override bool CheckInput()
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        public override bool CheckInput()
        {
            bool returnValue = true;
            this.txtFileName.Text = this.txtFileName.Text.TrimEnd();
            if (this.txtFileName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9978), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtFileName.Focus();
                return false;
            }
            return returnValue;
        }
        #endregion

        #region private BaseFileEntity GetEntity(BaseFileEntity fileEntity)
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <returns>名片类</returns>
        private BaseFileEntity GetEntity(BaseFileEntity fileEntity)
        {
            fileEntity.FileName = this.txtFileName.Text;
            fileEntity.Contents = System.Text.Encoding.Default.GetBytes(this.txtContent.Text);
            fileEntity.Enabled = this.chbEnabled.Checked ? 1:0;
            fileEntity.Description = this.txtDescription.Text;
            return fileEntity;
        }
        #endregion

        #region public override void SaveEntity()
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
            this.GetEntity(this.FileEntity);
            DotNetService.Instance.FileService.Upload(UserInfo, this.FileEntity.FolderId, this.txtFileName.Text, System.Text.Encoding.Default.GetBytes(this.txtContent.Text), true);
            int rowCount = DotNetService.Instance.FileService.Update(UserInfo, this.EntityId, this.FileEntity.FolderId, this.txtFileName.Text, this.txtDescription.Text, this.chbEnabled.Checked, out statusCode, out statusMessage);
            returnValue = rowCount > 0;
            this.Changed = returnValue;
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