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
    /// FrmFileEdit.cs
    /// 文件管理-编辑文件窗体
    ///		
    /// 修改记录
    ///
    ///     2008.05.06 版本：1.4 JiRiGaLa  程序进行整理。
    ///     2007.06.01 版本：1.3 JiRiGaLa  解决了外部文件的编辑问题。
    ///     2007.05.31 版本：1.2 JiRiGaLa  解决了文件的路径,文件名显示问题。
    ///     2007.05.30 版本：1.1 JiRiGaLa  改进CheckInput()，SaveEntity()，增加了多国语言功能。
    ///		
    /// 版本：1.3
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.05.06</date>
    /// </author> 
    /// </summary> 
    public partial class FrmFileEdit : BaseForm
    {
        private DataTable DTFile = new DataTable(BaseFileEntity.TableName);     // 文件
        public string FileId   = string.Empty;      // 主键
        
        public FrmFileEdit()
        {
            InitializeComponent();
        }

        #region public FrmFileEdit(string id) 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">主键</param>
        public FrmFileEdit(string id) : this()
        {
            this.FileId = id;
        }
        #endregion

        #region public override void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public override void ShowEntity()
        {
            BaseFileEntity fileEntity = new BaseFileEntity();
            fileEntity = DotNetService.Instance.FileService.GetEntity(UserInfo, this.FileId);
            // 从数据权限获得类
            //fileEntity.GetSingle(this.DTFile);
            // 将类转显示到页面
            this.ucFolder.SelectedId = fileEntity.FolderId;
            this.txtFileName.Text = fileEntity.FileName;
            this.txtDescription.Text = fileEntity.Description;            
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // this.DTFile = DotNetService.Instance.FileService.Get(UserInfo, this.FileId);
            this.ucFolder.AllowNull = false;
            this.ucFolder.CheckMove = false;
            // 显示内容
            this.ShowEntity();
            // 定位焦点
            this.ActiveControl = this.txtFileName;
            this.txtFileName.Focus();
        }
        #endregion

        private void DownLoadFile(string fileId)
        {
            // DataTable dataTable = DotNetService.Instance.FileService.GetEntity(UserInfo, fileId);
            BaseFileEntity fileEntity = new BaseFileEntity();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = fileEntity.FileName;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                FileUtil.SaveFile(DotNetService.Instance.FileService.Download(UserInfo, fileId), fileName);
                this.Close();
            }
        }

        #region public override bool CheckInput() 检查输入的有效性
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
            DotNetService.Instance.FileService.Update(UserInfo, this.FileId, this.ucFolder.SelectedId, this.txtFileName.Text, this.txtDescription.Text, true, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKUpdate.ToString())
            {
                if (BaseSystemInfo.ShowInformation)
                {
                    // 修改成功，进行提示
                    MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.DialogResult = DialogResult.OK;
                returnValue = true;
            }
            else
            {
                MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                // 是否文件名重复了，提高友善性
                if (statusCode == StatusCode.ErrorNameExist.ToString())
                {
                    this.txtFileName.SelectAll();
                    this.txtFileName.Focus();
                }
                returnValue = false;
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
            return returnValue;
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
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

        private void btnDownLoad_Click_1(object sender, EventArgs e)
        {
            this.DownLoadFile(this.FileId);
        }        
    }
}