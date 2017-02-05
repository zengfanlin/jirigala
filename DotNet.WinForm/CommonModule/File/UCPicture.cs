//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Drawing;
using System.IO;
using System.ServiceModel;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// UCPicture
    /// 照片显示控件
    /// 
    /// 修改纪录
    ///
    ///		2010.12.08 版本：2.0 JiRiGaLa 更新员工更新照片的错误。
    ///		2008.04.29 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：2.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.12.08</date>
    /// </author> 
    /// </summary>
    public partial class UCPicture : UserControl
    {
        public UCPicture()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 当前用户信息
        /// 这里表示是只读的
        /// 问题点：无法获得登录用户的相关信息 解决：采用继承基类的用户信息
        /// </summary>
        public BaseUserInfo UserInfo
        {
            get
            {
                return BaseSystemInfo.UserInfo;
            }
        }

        /// <summary>
        /// 保存到数据库
        /// </summary>
        public bool FromDatabase = true;

        private string fileId = string.Empty;
        public string PictureId
        {
            get
            {
                return this.fileId;
            }
            set
            {
                this.fileId = value;
                this.ShowPicture();
            }
        }

        private string folderId = string.Empty;
        public string FolderId
        {
            get
            {
                return this.folderId;
            }
            set
            {
                this.folderId = value;
            }
        }
        
        private void UCPicture_Load(object sender, EventArgs e)
        {
            // 设置按钮状态
            // this.SetControlState();
        }

        private void UCPicture_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void UCPicture_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);
                for (int i = 0; i <= file.Length - 1; i++)
                {
                    if (System.IO.File.Exists(file[i]))
                    {
                        this.fileId = string.Empty;
                        // 设置显示的图片
                        this.pic.ImageLocation = file[i];
                        // 设置按钮状态
                        this.SetControlState();
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 显示图片
        /// </summary>
        public void ShowPicture()
        {
            if (!String.IsNullOrEmpty(this.PictureId))
            {
                // 显示图片
                this.ShowPicture(this.PictureId);
            }
            else
            {
                // 清除图片
                this.ClearPicture();
            }
        }

        /// <summary>
        /// 显示图片
        /// </summary>
        /// <param name="id">主键</param>
        private void ShowPicture(string id)
        {
            if (!this.FromDatabase)
            {
                this.pic.ImageLocation = BaseSystemInfo.StartupPath + id;
            }
            else
            {
                byte[] fileContent = null;
                fileContent = this.Download(id);
                if (fileContent != null)
                {
                    // this.pic.Image = this.ByteToImage(fileContent);
                    MemoryStream memoryStream = new MemoryStream(fileContent);
                    Bitmap bitmap = new Bitmap(memoryStream);
                    this.pic.Image = bitmap;
                }
                else
                {
                    this.PictureId = string.Empty;
                    this.ClearPicture();
                }
            }
            // 设置按钮状态
            this.SetControlState();
        }

        /// <summary>
        /// 从数据库中读取文件
        /// </summary>
        /// <param name="id">文件主键</param>
        /// <returns>文件</returns>
        public byte[] Download(string id)
        {
            DotNetService dotNetService = new DotNetService();
            byte[] returnValue = dotNetService.FileService.Download(UserInfo, id);
            if (dotNetService.FileService is ICommunicationObject)
            {
                ((ICommunicationObject)dotNetService.FileService).Close();
            }
            return returnValue;
            // OleDbHelper dbHelper = new SqlHelper();
            // dbHelper.Open();
            // byte[] fileContent = null;
            // string sqlQuery = " SELECT " + BaseFileEntity.FieldFileContent
            //                + "   FROM " + BaseFileEntity.TableName
            //                + "  WHERE " + BaseFileEntity.FieldId + " = '" + Id + "'";
            // OleDbDataReader dataReader = (OleDbDataReader)dbHelper.ExecuteReader(sqlQuery);
            // if (dataReader.Read())
            // {
            //    fileContent = (byte[])dataReader[BaseFileEntity.FieldFileContent];
            // }
            // dbHelper.Close();
            // return fileContent;
        }

        public string Upload(string folderId, string categoryId)
        {
            this.FolderId = folderId;
            string returnValue = string.Empty;
            if (!String.IsNullOrEmpty(this.pic.ImageLocation))
            {
                // 保存到数据库
                if (this.FromDatabase)
                {
                    if (String.IsNullOrEmpty(this.PictureId))
                    {
                        DotNetService dotNetService = new DotNetService();
                        returnValue = dotNetService.FileService.Upload(UserInfo, folderId, Path.GetFileName(this.pic.ImageLocation), FileUtil.GetFile(this.pic.ImageLocation), true);
                        if (dotNetService.FileService is ICommunicationObject)
                        {
                            ((ICommunicationObject)dotNetService.FileService).Close();
                        }
                    }
                    else
                    {
                        string statusCode = string.Empty;
                        string statusMessage = string.Empty;
                        DotNetService dotNetService = new DotNetService();
                        dotNetService.FileService.UpdateFile(UserInfo, this.PictureId, Path.GetFileName(this.pic.ImageLocation), FileUtil.GetFile(this.pic.ImageLocation), out statusCode, out statusMessage);
                        if (dotNetService.FileService is ICommunicationObject)
                        {
                            ((ICommunicationObject)dotNetService.FileService).Close();
                        }
                        returnValue = this.PictureId;
                    }
                }
                else
                {
                    // 复制文件到指定的目录里
                    if (!this.pic.ImageLocation.Equals(BaseSystemInfo.StartupPath + this.PictureId))
                    {
                        string destDirectory = BaseSystemInfo.StartupPath + "\\UploadFiles" + "\\" + folderId + "\\" + categoryId;
                        System.IO.Directory.CreateDirectory(destDirectory);
                        string destFileName = destDirectory + "\\" + Path.GetFileName(this.pic.ImageLocation);
                        System.IO.File.Copy(this.pic.ImageLocation, destFileName);
                        returnValue = "\\UploadFiles" + "\\" + folderId + "\\" + categoryId + "\\" + Path.GetFileName(this.pic.ImageLocation);
                    }
                }
                // OleDbHelper dbHelper = new SqlHelper();
                // dbHelper.Open();
                // string sequence = BaseSequenceManager.Instance.GetSequence(DbHelper, BaseFileEntity.TableName);
                // OleDbSQLBuilder sqlBuilder = new OleDbSQLBuilder();
                // sqlBuilder.BeginInsert(DbHelper, BaseFileEntity.TableName);
                // sqlBuilder.SetValue(BaseFileEntity.FieldId, sequence);
                // sqlBuilder.SetValue(BaseFileEntity.FieldFolderId, folderId);
                // sqlBuilder.SetValue(BaseFileEntity.FieldFileName, Path.GetFileName(this.pic.ImageLocation));
                // // byte[] File = this.ImageToByte(this.pic.Image);
                // byte[] File = this.GetFile(this.pic.ImageLocation);
                // sqlBuilder.SetValue(BaseFileEntity.FieldFileContent, File);
                // sqlBuilder.SetValue(BaseFileEntity.FieldFileSize, File.Length);
                // sqlBuilder.SetValue(BaseFileEntity.FieldCreateUserId, UserInfo.Id);
                // sqlBuilder.SetDBNow(BaseFileEntity.FieldCreateOn);
                // sqlBuilder.EndInsert();
                // dbHelper.Close();
                // returnValue = sequence;
            }
            return returnValue;
        }

        private void SetControlState(bool enabled)
        {
            this.btnSelect.Enabled  = enabled;
            this.btnClear.Enabled   = enabled;
            this.btnDelete.Enabled  = enabled;
        }

        #region private void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        private void SetControlState()
        {
            this.btnSelect.Enabled = true;
            // 是从数据库里面读取出来的
            if (!String.IsNullOrEmpty(this.PictureId) && (String.IsNullOrEmpty(this.pic.ImageLocation) || !this.FromDatabase))
            {
                this.btnDelete.Enabled = true;
            }
            else
            {
                this.btnDelete.Enabled = false;
            }
            // 清除按钮
            this.btnClear.Enabled = false;
            if (!String.IsNullOrEmpty(this.pic.ImageLocation))
            {
                if (this.FromDatabase)
                {
                    this.btnClear.Enabled = true;
                    this.btnDelete.Enabled = false;
                }
                else
                {
                    if (!this.pic.ImageLocation.Equals(BaseSystemInfo.StartupPath + this.PictureId))
                    {
                        this.btnClear.Enabled = true;
                        this.btnDelete.Enabled = false;
                    }
                }
            }
        }
        #endregion

        private void pic_DoubleClick(object sender, EventArgs e)
        {
            if (this.pic.Image != null)
            {
                FrmPicture frmPicture = new FrmPicture(this.PictureId);
                frmPicture.SetImage(this.pic.Image);
                frmPicture.Show();
            }
        }        

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // OpenFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "位图文件(*.bmp)|*.bmp|JPEG(*.JPG;*.JPEG;*.JPE;*.JFIF)|*.JPG;*.JPEG;*.JPE;*.JFIF|GIF(*.GIF)|*.GIF|TIFF(*.TIF;*.TIIF)|*.TIF;*.TIIF|PNG(*.PNG)|*.PNG|ICO(*.ICO)|*.ICO|所有图片文件|(*.bmp;*.JPG;*.JPEG;*.JPE;*.JFIF;*.GIF;*.TIF;*.TIIF;*.PNG;*.ICO)|所有文件|*.*";
            openFileDialog.FilterIndex = 7;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "打开图片文件";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.fileId = string.Empty;
                this.SetControlState(false);
                this.pic.ImageLocation = openFileDialog.FileName;
                // 设置按钮状态
                this.SetControlState();
            }
        }

        /// <summary>
        /// 清除图片
        /// </summary>
        private void ClearPicture()
        {
            this.pic.ImageLocation = string.Empty;
            this.pic.Image = null;
        }

        public void DoClear()
        {
            this.ClearPicture();
            this.ShowPicture();
            // 设置按钮状态
            this.SetControlState();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.DoClear();
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响的行数</returns>
        public int DeleteFile(string id)
        {
            int returnValue = 0;
            if (this.FromDatabase)
            {
                // 从数据库服务器删除文件
                DotNetService dotNetService = new DotNetService();
                returnValue = dotNetService.FileService.Delete(UserInfo, id);
                if (dotNetService.FileService is ICommunicationObject)
                {
                    ((ICommunicationObject)dotNetService.FileService).Close();
                }
            }
            else
            {
                // 清除图片
                this.ClearPicture();
                // 删除文件
                System.IO.File.Delete(BaseSystemInfo.StartupPath + this.PictureId);
            }
            return returnValue;
        }

        /// <summary>
        /// 删除图片后调用的方法
        /// </summary>
        /// <param name="pictureId">图片主键</param>
        public delegate void OnAfterDeleteEventHandler(string pictureId);
        // 当删除后发生的事件
        public event OnAfterDeleteEventHandler OnAfterDelete;

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(AppMessage.MSG0207, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                this.SetControlState(false);
                this.DeleteFile(this.PictureId);
                if (this.OnAfterDelete != null)
                {
                    this.OnAfterDelete(this.PictureId);
                }
                this.PictureId = string.Empty;
                this.ShowPicture();
                // 设置按钮状态
                this.SetControlState();
            }
        }  
    }
}
