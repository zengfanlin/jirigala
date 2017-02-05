//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    
    using DotNet.Business;
    using DotNet.Utilities;
    

    /// <summary>
    /// UCAttachment.cs
    /// 文件管理-附件控件
    ///		
    /// 修改记录
    /// 
    ///     2008.05.16 版本：1.0 JiRiGaLa 重新整理主键。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.05.16</date>
    /// </author> 
    /// </summary>
    public partial class UCAttachment : UserControl
    {
        public UCAttachment()
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

        /// <summary>
        /// 是否马上就进行上传操作
        /// 若文件夹还没确定，那不能马上进行操作的。
        /// </summary>
        private bool immediately = false;
        public bool Immediately
        {
            get
            {
                return this.immediately;
            }
            set
            {
                if (!String.IsNullOrEmpty(this.FolderId))
                {
                    this.immediately = value;
                }
                else
                {
                    this.immediately = false;
                }
            }
        }

        public bool ShowSelectButton    = false;    // 是否现实全选反选按钮

        public bool permissionUpLoad    = true; // 上传权限
        public bool permissionDownLoad  = true; // 下载权限

        /// <summary>
        /// 文件主键
        /// </summary>
        public string FileId
        {
            get
            {
                return BaseInterfaceLogic.GetDataGridViewEntityId(this.grdFile, BaseFileEntity.FieldId);
            }
        }

        /// <summary>
        /// 最多能上传文件的容量
        /// </summary>
        public int UploadMaxSumSize = 0;

        public DataTable dataTable = new DataTable(BaseFileEntity.TableName);

        private void CheckFileTable()
        {
            if (this.dataTable == null)
            {
                this.dataTable = new DataTable(BaseFileEntity.TableName);
            }
            //if (!this.dataTable.Columns.Contains(BaseBusinessLogic.SelectedColumn))
            //{
            //    this.dataTable.Columns.Add(BaseBusinessLogic.SelectedColumn);
            //}
            if (!this.dataTable.Columns.Contains(BaseFileEntity.FieldId))
            {
                this.dataTable.Columns.Add(BaseFileEntity.FieldId);
            }
            if (!this.dataTable.Columns.Contains(BaseFileEntity.FieldFileName))
            {
                this.dataTable.Columns.Add(BaseFileEntity.FieldFileName);
            }
            if (!this.dataTable.Columns.Contains(BaseFileEntity.FieldFilePath))
            {
                this.dataTable.Columns.Add(BaseFileEntity.FieldFilePath);
            }
            if (!this.dataTable.Columns.Contains(BaseFileEntity.FieldFileSize))
            {
                this.dataTable.Columns.Add(BaseFileEntity.FieldFileSize);
            }
            if (!this.dataTable.Columns.Contains("FileFriendlySize"))
            {
                this.dataTable.Columns.Add("FileFriendlySize");
            }
            if (!this.dataTable.Columns.Contains(BaseFileEntity.FieldDescription))
            {
                this.dataTable.Columns.Add(BaseFileEntity.FieldDescription);
            }
            // 计算文件的大小，更友善的现实数据
            foreach (DataRow dataRow in this.dataTable.Rows)
            {
                if (dataRow.RowState == DataRowState.Unchanged)
                {
                    int fileSize = int.Parse(dataRow[BaseFileEntity.FieldFileSize].ToString());
                    dataRow["FileFriendlySize"] = FileUtil.GetFriendlyFileSize(fileSize);
                }
            }
            this.dataTable.AcceptChanges();
        }

        private void SetControlState(bool enabled)
        {
            this.btnSelectAll.Enabled = enabled;
            this.btnInvertSelect.Enabled = enabled;

            this.btnSelect.Enabled = enabled;
            this.btnUpload.Enabled = enabled;
            this.btnDownload.Enabled = enabled;
            this.btnDelete.Enabled = enabled;
        }

        #region private void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        private void SetControlState()
        {
            this.btnSelectAll.Enabled = false;
            this.btnInvertSelect.Enabled = false;
            this.btnDownload.Enabled = false;
            this.btnDelete.Enabled = false;
            if (this.dataTable.DefaultView.Count > 0)
            {
                this.btnSelectAll.Enabled = true;
                this.btnInvertSelect.Enabled = true;

                this.btnDelete.Enabled = this.permissionUpLoad;
            }

            this.btnSelectAll.Visible = this.ShowSelectButton;
            this.btnInvertSelect.Visible = this.ShowSelectButton;

            // 是否有上传权限
            this.btnSelect.Enabled = this.permissionUpLoad;

            this.btnUpload.Enabled = false;
            if (!String.IsNullOrEmpty(this.FolderId))
            {
                // 是否马上就进行上传操作
                if (!this.Immediately)
                {
                    if (this.permissionUpLoad)
                    {
                        this.btnUpload.Enabled = this.CanUpload();
                    }
                }
            }            
        }
        #endregion

        public void DataBind(string folderId, bool immediately)
        {
            this.DataBind(folderId);
            this.Immediately = immediately;
        }

        public void DataBind(string folderId)
        {
            this.FolderId = folderId;
            this.dataTable = DotNetService.Instance.FileService.GetDataTableByFolder(UserInfo, folderId);
            this.CheckFileTable();
            this.grdFile.DataSource = this.dataTable.DefaultView;
            // 设置按钮状态
            this.SetControlState();
        }

        /// <summary>
        /// 是否有文件可以上传了
        /// </summary>
        /// <returns>有文件可以上传</returns>
        private bool CanUpload()
        {
            bool returnValue = false;
            foreach (DataRow dataRow in this.dataTable.Rows)
            {
                // 已经被删除了，不进行判断
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    returnValue = true;
                    break;
                }
                // 已上传的文件，有要被替换了
                if (dataRow.RowState == DataRowState.Modified)
                {
                    returnValue = true;
                    break;
                }
                if (String.IsNullOrEmpty(dataRow[BaseFileEntity.FieldId].ToString()))
                {
                    returnValue = true;
                    break;
                }
            }
            return returnValue;
        }

        private void UCAttachment_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.CheckFileTable();
                this.grdFile.AutoGenerateColumns = false;
                this.grdFile.DataSource = this.dataTable.DefaultView;
                // 设置按钮状态
                this.SetControlState();
            }
        }

        private void AddFile(string fileName)
        {
            int fileSize = FileUtil.GetFile(fileName).Length;
            // 检查文件的大小
            if (this.CheckUploadSumSize(fileSize))
            {
                DataRow dataRow = this.dataTable.NewRow();
                dataRow[BaseFileEntity.FieldFileName] = Path.GetFileName(fileName);
                dataRow[BaseFileEntity.FieldFilePath] = fileName;

                dataRow[BaseFileEntity.FieldFileSize] = fileSize;
                dataRow["FileFriendlySize"] = FileUtil.GetFriendlyFileSize(fileSize);
                // 是否马上就进行上传操作
                if (this.Immediately)
                {
                    // 文件进行上传
                    dataRow[BaseFileEntity.FieldId] = DotNetService.Instance.FileService.Upload(UserInfo, this.FolderId, dataRow[BaseFileEntity.FieldFileName].ToString(), FileUtil.GetFile(dataRow[BaseFileEntity.FieldFilePath].ToString()), true);
                }
                this.dataTable.Rows.Add(dataRow);
            }
        }

        private void CheckAddFile(string fileName)
        {
            bool finded = false;
            fileName = Path.GetFileName(fileName);
            foreach (DataRow dataRow in this.dataTable.Rows)
            {
                // 已经被删除了，不进行判断
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    continue;
                }
                // 文件名注意大小写问题
                if (dataRow[BaseFileEntity.FieldFileName].ToString().ToUpper().Equals(fileName.ToUpper()))
                {
                    // 文件大小判断，替换时的判断
                    byte[] file = FileUtil.GetFile(fileName);
                    int currentFileSize = file.Length;
                    int oldFileSize = int.Parse(dataRow[BaseFileEntity.FieldFileSize].ToString());
                    if (!this.CheckUploadSumSize(currentFileSize, oldFileSize))
                    {
                        file = null;
                        break;
                    }
                    // 文件是否已经存在服务器上
                    if (!String.IsNullOrEmpty(dataRow[BaseFileEntity.FieldId].ToString()))
                    {
                        // 是否确认从服务器上删除文件
                        if (MessageBox.Show(AppMessage.Format(AppMessage.MSG0281, dataRow[BaseFileEntity.FieldFileName].ToString()), AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                        {
                            // 是否马上就进行上传操作
                            if (this.Immediately)
                            {
                                DotNetService.Instance.FileService.Upload(UserInfo, this.FolderId, fileName, file, true);
                            }
                            else
                            {
                                // 已经上传的文件
                                int fileSize = FileUtil.GetFile(fileName).Length;
                                dataRow[BaseFileEntity.FieldFileSize] = fileSize;
                                dataRow["FileFriendlySize"] = FileUtil.GetFriendlyFileSize(fileSize);
                                dataRow[BaseFileEntity.FieldFileName] = fileName;
                                dataRow[BaseFileEntity.FieldFilePath] = fileName;
                            }
                        }
                    }
                    else
                    {
                        int fileSize = FileUtil.GetFile(fileName).Length;
                        dataRow[BaseFileEntity.FieldFileSize] = fileSize;
                        dataRow["FileFriendlySize"] = FileUtil.GetFriendlyFileSize(fileSize);
                        // 还未上传的文件，已经添加的文件
                        dataRow[BaseFileEntity.FieldFileName] = fileName;
                        dataRow[BaseFileEntity.FieldFilePath] = fileName;
                    }
                    // 这里是为了提高运行效率。
                    finded = true;
                    break;
                }
            }
            if (!finded)
            {
                this.AddFile(fileName);
            }
        }

        private void grdFile_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void grdFile_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // 是否有上穿权限
                if (this.permissionUpLoad)
                {
                    this.SetControlState(false);
                    string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);
                    for (int i = 0; i <= file.Length - 1; i++)
                    {
                        if (System.IO.File.Exists(file[i]))
                        {
                            this.CheckAddFile(file[i]);
                        }
                    }
                    // 设置按钮状态
                    this.SetControlState();
                }
            }
        }

        private void grdFile_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnDownload.Enabled = false;
            if (this.Immediately)
            {
                if (!String.IsNullOrEmpty(this.FileId))
                {
                    // 是否有下载权限
                    this.btnDownload.Enabled = this.permissionDownLoad;
                }
            }
            else
            {
                DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdFile);
                if (dataRow != null)
                {
                    // 文件没被修改过，才可以下载
                    if (!String.IsNullOrEmpty(dataRow[BaseFileEntity.FieldId].ToString()) && (String.IsNullOrEmpty(dataRow[BaseFileEntity.FieldFilePath].ToString())))
                    {
                        this.btnDownload.Enabled = this.permissionDownLoad;
                    }
                }
            }
        }

        private void OpenFile(string fileId)
        {
            string fileName = this.GetFileName(fileId);
            fileName = System.IO.Path.GetTempPath() + fileName;
            this.SaveFile(fileId, fileName);
            Process.Start(fileName);
        }

        private void grdFile_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.btnDownload.Enabled)
            {
                this.OpenFile(this.FileId);
            }
        }

        private void grdFile_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Immediately)
            {
                // 描述什么的修改了
                DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdFile);
                if (dataRow != null)
                {
                    string statusCode = string.Empty;
                    string statusMessage = string.Empty;
                    DotNetService.Instance.FileService.Update(UserInfo, dataRow[BaseFileEntity.FieldId].ToString(), this.FolderId, dataRow[BaseFileEntity.FieldFileName].ToString(), dataRow[BaseFileEntity.FieldDescription].ToString(), true, out statusCode, out statusMessage);
                }
            }
            else
            {
                // 设置按钮状态
                this.SetControlState();
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in grdFile.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }

            //foreach (DataRow dataRow in this.dataTable.Rows)
            //{
            //    dataRow["colSelected"] = true.ToString();
            //}
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dgvRow in grdFile.Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value??false);
            }
            //foreach (DataRow dataRow in this.dataTable.Rows)
            //{
            //    if (dataRow["colSelected"].ToString() == true.ToString())
            //    {
            //        dataRow["colSelected"] = false.ToString();
            //    }
            //    else
            //    {
            //        dataRow["colSelected"] = true.ToString();
            //    }
            //}
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            // OpenFileDialog.InitialDirectory = Application.StartupPath;
            OpenFileDialog.RestoreDirectory = true;
            OpenFileDialog.Title = "选择附件";
            OpenFileDialog.Multiselect = true;
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.SetControlState(false);
                for (int i = 0; i < OpenFileDialog.FileNames.Length; i++)
                {
                    this.CheckAddFile(OpenFileDialog.FileNames[i]);
                }
                // 设置按钮状态
                this.SetControlState();
            }
        }

        /// <summary>
        /// 将文件上传到务服务上
        /// </summary>
        /// <param name="folderId">文件夹主键</param>
        public void Upload(string folderId)
        {
            this.FolderId = folderId;
            foreach (DataRow dataRow in this.dataTable.Rows)
            {
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    continue;
                }
                if (dataRow.RowState == DataRowState.Added)
                {
                    dataRow[BaseFileEntity.FieldFolderId] = folderId;
                }
            }
            this.Upload();
        }

        public bool CheckUploadSumSize(int currentFileSize, int oldFileSize)
        {
            bool returnValue = true;
            if (this.UploadMaxSumSize != 0)
            {
                if (currentFileSize > this.UploadMaxSumSize)
                {
                    // 上传的文件太大了
                    MessageBox.Show(AppMessage.MSG0206, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    returnValue = false;
                }
                int sumSize = 0;
                foreach (DataRowView dataRowView in this.dataTable.DefaultView)
                {
                    sumSize += int.Parse(dataRowView.Row[BaseFileEntity.FieldFileSize].ToString());
                }
                // 计算被替换的文件的大小
                if (this.UploadMaxSumSize < sumSize + currentFileSize - oldFileSize)
                {
                    // 上传的文件太大了
                    MessageBox.Show(AppMessage.MSG0206, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    returnValue = false;
                }
            }
            return returnValue;
        }

        /// <summary>
        /// 新上传一个文件时判断
        /// </summary>
        /// <param name="currentFileSize">当前文件大小</param>
        /// <returns>是否可以上传</returns>
        public bool CheckUploadSumSize(int currentFileSize)
        {
            return this.CheckUploadSumSize(currentFileSize, 0);
        }

        /// <summary>
        /// 检查上传文件容量
        /// </summary>
        public bool CheckUploadSumSize()
        {
            return this.CheckUploadSumSize(0);
        }

        /// <summary>
        /// 将文件上传到务服务上
        /// </summary>
        public void Upload()
        {
            // 是否马上就进行上传操作
            if (this.Immediately)
            {
                return;
            }
            // 检查上传文件容量
            if (!this.CheckUploadSumSize())
            {
                return;
            }
            this.SetControlState(false);
            foreach (DataRow dataRow in this.dataTable.Rows)
            {
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    // 是否服务器上的文件，被删除了？
                    if (!String.IsNullOrEmpty(dataRow[BaseFileEntity.FieldId, DataRowVersion.Original].ToString()))
                    {
                        DotNetService.Instance.FileService.Delete(UserInfo, dataRow[BaseFileEntity.FieldId, DataRowVersion.Original].ToString());
                    }
                    continue;
                }
                // 被添加或者被更新
                if ((dataRow.RowState == DataRowState.Added) || (dataRow.RowState == DataRowState.Modified))
                {
                    // 文件进行上传
                    if (dataRow[BaseFileEntity.FieldFilePath].ToString().Length > 0)
                    {
                        dataRow[BaseFileEntity.FieldId] = DotNetService.Instance.FileService.Upload(UserInfo, this.FolderId, dataRow[BaseFileEntity.FieldFileName].ToString(), FileUtil.GetFile(dataRow[BaseFileEntity.FieldFilePath].ToString()), true);
                        dataRow[BaseFileEntity.FieldFilePath] = string.Empty;
                    }
                    else
                    {
                        // 描述什么的修改了
                        string statusCode = string.Empty;
                        string statusMessage = string.Empty;
                        DotNetService.Instance.FileService.Update(UserInfo, dataRow[BaseFileEntity.FieldId].ToString(), this.FolderId, dataRow[BaseFileEntity.FieldFileName].ToString(), dataRow[BaseFileEntity.FieldDescription].ToString(), true, out statusCode, out statusMessage);
                    }
                    continue;
                }
            }
            // 将数据全部清除
            this.ClearTable();
        }

        #region public void ClearTable() 将数据全部清除
        /// <summary>
        /// 将数据全部清除
        /// </summary>
        public void ClearTable()
        {
            // 将数据全部清除
            this.dataTable.Clear();
            this.dataTable.AcceptChanges();
            // 设置按钮状态
            this.SetControlState();
        }
        #endregion

        private void btnUpload_Click(object sender, EventArgs e)
        {
            // 上传文件
            this.Upload();            
        }

        private string GetFileName(string fileId)
        {
            // BaseFileEntity fileEntity = DotNetService.Instance.FileService.GetEntity(UserInfo, fileId);
            // return fileEntity.FileName;
            return string.Empty;
        }

        private void SaveFile(string fileId)
        {
            this.SaveFile(fileId, string.Empty);
        }

        private void SaveFile(string fileId, string fileName)
        {
            if (String.IsNullOrEmpty(fileId))
            {
                return;
            }
            // 是否未指定文件名
            if (String.IsNullOrEmpty(fileName))
            {
                SaveFileDialog SaveFileDialog = new SaveFileDialog();
                // 获得文件名
                SaveFileDialog.FileName = this.GetFileName(fileId);
                if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = SaveFileDialog.FileName;
                }
            }
            // 有文件名，进行保存操作
            if (!String.IsNullOrEmpty(fileName))
            {
                FileUtil.SaveFile(DotNetService.Instance.FileService.Download(UserInfo, fileId), fileName);
            }
        }        

        private void btnDownload_Click(object sender, EventArgs e)
        {
            this.SaveFile(this.FileId);
        }

        private void Delete()
        {
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdFile, "colSelected"))
            {
                this.SetControlState(false);

                foreach (DataGridViewRow dgvRow in grdFile.Rows)
                {
                    DataRow dataRow = (dgvRow.DataBoundItem as DataRowView).Row;
                    if (dataRow.RowState != DataRowState.Deleted)
                    {
                        if ((System.Boolean)(dgvRow.Cells["colSelected"].Value??false))
                        {
                            if (dataRow[BaseFileEntity.FieldId].ToString().Length == 0)
                            {
                                dataRow.Delete();
                            }
                            else
                            {
                                if (MessageBox.Show(AppMessage.Format(AppMessage.MSG0016, dataRow[BaseFileEntity.FieldFileName].ToString()), AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                                {
                                    // 是否马上就进行上传操作
                                    if (this.Immediately)
                                    {
                                        DotNetService.Instance.FileService.Delete(UserInfo, dataRow[BaseFileEntity.FieldId].ToString());
                                    }
                                    dataRow.Delete();
                                }
                            }
                        }
                    }
                }

                //for (int i = this.dataTable.Rows.Count - 1; i >= 0; i--)
                //{
                //    DataRow dataRow = this.dataTable.Rows[i];
                //    if (dataRow.RowState != DataRowState.Deleted)
                //    {
                //        if (dataRow["colSelected"].ToString() == true.ToString())
                //        {
                //            if (dataRow[BaseFileEntity.FieldId].ToString().Length == 0)
                //            {
                //                dataRow.Delete();
                //            }
                //            else
                //            {
                //                if (MessageBox.Show(AppMessage.Format(AppMessage.MSG0016, dataRow[BaseFileEntity.FieldFileName].ToString()), AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                //                {
                //                    // 是否马上就进行上传操作
                //                    if (this.Immediately)
                //                    {
                //                        DotNetService.Instance.FileService.Delete(UserInfo, dataRow[BaseFileEntity.FieldId].ToString());
                //                    }
                //                    dataRow.Delete();
                //                }
                //            }
                //        }
                //    }
                //}
                this.SetControlState();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Delete();            
        }
    }
}
