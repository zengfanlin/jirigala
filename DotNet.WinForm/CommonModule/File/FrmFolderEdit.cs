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
    /// FrmFolderEdit.cs
    /// 文件夹管理-编辑文件夹窗体
    ///		
    /// 修改记录
    ///
    ///     2007.05.13 版本：1.1 JiRiGaLa  改进CheckInput()，SaveEntity()。
    ///     2007.05.11 版本：1.0 JiRiGaLa  文件夹编辑功能页面编写。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.15</date>
    /// </author> 
    /// </summary> 
    public partial class FrmFolderEdit : BaseForm
    {
        public string FolderId = string.Empty;  // 文件夹主键

        BaseFolderEntity folderEntity = new BaseFolderEntity();

        public FrmFolderEdit()
        {
            InitializeComponent();
        }

        #region public FrmFolderEdit(string id): this()
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="folderId">文件夹主键</param>
        /// <param name="folderFullName">文件夹名称</param>
        public FrmFolderEdit(string id) : this()        
        {
            this.FolderId = id;            
        }
        #endregion

        #region public FrmFolderEdit(string id, string folderId, string folderFullName): this(string.Empty)
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="folderId">文件夹主键</param>
        /// <param name="folderFullName">文件夹名称</param>
        public FrmFolderEdit(string id, string folderId, string folderFullName) : this(string.Empty)
        {
            this.FolderId = id;
            this.ucFolder.SelectedId = folderId;
            this.ucFolder.SelectedFullName = folderFullName;
        }
        #endregion

        #region public override void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public override void ShowEntity()
        {
            this.ucFolder.SelectedId = folderEntity.ParentId;
            this.ucFolder.CheckMove = true;
            this.txtFolderName.Text = folderEntity.FolderName;
            this.chkEnabled.Checked = folderEntity.Enabled == 1;
            this.txtDescription.Text = folderEntity.Description;
            // 这里需要进行判断，数据是否被其他人已经删除
            if (folderEntity.Id.Length == 0)
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
            // 文件夹信息
            this.folderEntity = DotNetService.Instance.FolderService.GetEntity(UserInfo, this.FolderId);
            // 显示内容
            this.ShowEntity();
            this.ActiveControl = this.txtFolderName;
            // 定位焦点
            this.txtFolderName.Focus();
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
            if (!BaseCheckInput.CheckEmpty(this.txtFolderName, AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9974)))
            {
                return false;
            }
            if (!BaseCheckInput.CheckFolderName(this.txtFolderName, AppMessage.Format(AppMessage.MSG0032, AppMessage.MSG9974)))
            {
                return false;
            }
            return returnValue;
        }
        #endregion

        private BaseFolderEntity GetEntity()
        {
            folderEntity.ParentId = this.ucFolder.SelectedId;
            folderEntity.FolderName = this.txtFolderName.Text;
            folderEntity.Enabled = this.chkEnabled.Checked ? 1:0;
            folderEntity.Description = this.txtDescription.Text;
            return folderEntity;
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
            DotNetService.Instance.FolderService.Update(UserInfo, this.folderEntity, out statusCode, out statusMessage);
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
                // 是否文件夹名重复了，提高友善性
                if (statusCode == StatusCode.ErrorNameExist.ToString())
                {
                    this.txtFolderName.SelectAll();
                    this.txtFolderName.Focus();
                }
                returnValue = false;
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
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