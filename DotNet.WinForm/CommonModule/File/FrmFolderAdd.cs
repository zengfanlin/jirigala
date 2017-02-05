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
    /// FrmFolderAdd.cs
    /// 文件夹管理-添加文件夹窗体
    ///		
    /// 修改记录
    /// 
    ///     2007.05.29 版本：1.2 JiRiGaLa  增加了多国语言功能，调整了细节部分。
    ///     2007.05.13 版本：1.1 JiRiGaLa  改进CheckInput()，SaveEntity()。
    ///     2007.05.11 版本：1.0 JiRiGaLa  文件夹添加功能页面编写。
    ///		
    /// 版本：1.2
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.29</date>
    /// </author> 
    /// </summary> 
    public partial class FrmFolderAdd : BaseForm
    {
        public FrmFolderAdd()
        {
            InitializeComponent();
        }

        #region public FrmFolderAdd(string id) 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">主键</param>
        public FrmFolderAdd(string id) : this()
        {
            this.EntityId = id;
        }
        #endregion

        #region public FrmFolderAdd(string folderId, string folderFullName): this(string.Empty) 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="folderId">文件夹主键</param>
        /// <param name="folderFullName">文件夹名称</param>
        public FrmFolderAdd(string folderId, string folderFullName): this(string.Empty)
        {
            this.ucFolder.SelectedId = folderId;
            this.ucFolder.SelectedFullName = folderFullName;
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 定位焦点
            this.ActiveControl = this.txtFolderName;
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
            BaseFolderEntity folderEntity = new BaseFolderEntity();
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
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            BaseFolderEntity folderEntity = this.GetEntity();
            this.EntityId = DotNetService.Instance.FolderService.Add(UserInfo, folderEntity, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKAdd.ToString())
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
                // 是否文件夹重复了，提高友善性
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

        private void btnAdd_Click(object sender, EventArgs e)
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

        private void ucFolder_Load(object sender, EventArgs e)
        {
            
        }

        
    }
}