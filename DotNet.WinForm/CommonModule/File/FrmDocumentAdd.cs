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
    /// FrmDocumentAdd.cs
    /// 文档管理 - 添加窗体
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
    public partial class FrmDocumentAdd : BaseForm
    {
        public FrmDocumentAdd()
        {
            InitializeComponent();
        }

        public FrmDocumentAdd(string folderId, string category) : this()
        {
            this.FolderId = folderId;
            this.Category = category;
        }

        public string FolderId = string.Empty;
        public string Category = "txt";

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

        #region private BaseFileEntity GetEntity()
        /// <summary>
        /// 获取输入的信息
        /// </summary>
        /// <returns>文档类</returns>
        private BaseFileEntity GetEntity()
        {
            BaseFileEntity fileEntity = new BaseFileEntity();
            fileEntity.FileName = this.txtFileName.Text;
            fileEntity.Contents = System.Text.Encoding.Default.GetBytes(this.txtContent.Text);
            fileEntity.Enabled = this.chbEnabled.Checked ? 1:0;
            fileEntity.Description = this.txtDescription.Text;
            return fileEntity;
        }
        #endregion

        #region private void ClearScreen()
        /// <summary>
        /// 清除屏幕
        /// </summary>
        private void ClearScreen()
        {
            this.txtFileName.Text = string.Empty;
            this.txtContent.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            this.txtFileName.Focus();
        }
        #endregion

        #region public override bool SaveEntity()
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>保存成功</returns>
        public override bool SaveEntity()
        {
            bool returnValue = true;
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            this.EntityId = DotNetService.Instance.FileService.Add(UserInfo, this.FolderId, this.txtFileName.Text, System.Text.Encoding.Default.GetBytes(this.txtContent.Text), this.txtDescription.Text, this.chbEnabled.Checked, out statusCode, out statusMessage);
            returnValue = !String.IsNullOrEmpty(EntityId);
            this.Changed = returnValue;
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
            return returnValue;
        }
        #endregion

        #region private void SaveEntity(bool close)
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="close">关闭窗体</param>
        private void SaveEntity(bool close)
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
                            // 关闭窗口
                            this.Close();
                        }
                        else
                        {
                            this.ClearScreen();
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
            this.SaveEntity(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveEntity(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
