//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Drawing;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    
    using DotNet.Business;
    using DotNet.Utilities;
    

    /// <summary>
    /// FrmPicture
    /// 
    /// 修改纪录
    ///
    ///		2008.05.06 版本：1.1 JiRiGaLa 增加图片保存功能。
    ///		2008.04.29 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.04.29</date>
    /// </author> 
    /// </summary>
    public partial class FrmPicture : BaseForm
    {
        public FrmPicture()
        {
            InitializeComponent();
        }

        public string FileId = string.Empty;

        public FrmPicture(string fileId) : this()
        {
            this.FileId = fileId;
        }

        public void SetImage(Image Image)
        {
            this.pic.Image = Image;
        }

        private void DownLoadFile(string fileId)
        {
            // DataTable dataTable = DotNetService.Instance.FileService.GetEntity(UserInfo, fileId);
            BaseFileEntity fileEntity = new BaseFileEntity();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "位图文件(*.bmp)|*.bmp|JPEG(*.JPG;*.JPEG;*.JPE;*.JFIF)|*.JPG;*.JPEG;*.JPE;*.JFIF|GIF(*.GIF)|*.GIF|TIFF(*.TIF;*.TIIF)|*.TIF;*.TIIF|PNG(*.PNG)|*.PNG|ICO(*.ICO)|*.ICO|所有图片文件|(*.bmp;*.JPG;*.JPEG;*.JPE;*.JFIF;*.GIF;*.TIF;*.TIIF;*.PNG;*.ICO)|所有文件|*.*";
            saveFileDialog.FilterIndex = 7;
            saveFileDialog.FileName = fileEntity.FileName;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                FileUtil.SaveFile(DotNetService.Instance.FileService.Download(UserInfo, fileId), fileName);
                this.Close();
            }
        }

        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            this.DownLoadFile(this.FileId);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}