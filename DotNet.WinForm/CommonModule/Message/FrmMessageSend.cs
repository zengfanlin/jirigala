//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;
    
    /// <summary>
    /// FrmMessageSend.cs
    /// 发送消息
    ///		
    /// 修改记录
    /// 
    ///     2010.12.15 版本：2.1 JiRiGaLa 发送信息后关闭窗体。
    ///     2007.08.22 版本：2.0 JiRiGaLa 整理主键。
    ///     2007.08.17 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：2.0
    ///
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.08.22</date>
    /// </author> 
    /// </summary>
    public partial class FrmMessageSend : BaseForm
    {
        public FrmMessageSend()
        {
            InitializeComponent();
            // 加载系统信息
            // UserInfo = new BaseUserInfo(this.Name, this.Text);
            this.txtContents.Tag = false;
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnSend.Enabled = (((!String.IsNullOrEmpty(this.ucUser.SelectedId)) 
                || (this.ucUser.SelectedIds != null)) && (this.txtContents.Text.Length > 0));
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 不允许选择空
            this.ucUser.AllowNull = false;
            this.ucUser.MultiSelect = true;
            // 默认打开的节点为当前公司节点
            this.ucUser.OpenId = UserInfo.CompanyId;
        }
        #endregion

        private void FrmMessageSend_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    // 加载窗体
                    this.FormOnLoad();
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

        /// <summary>
        /// 设置发送给谁
        /// </summary>
        /// <param name="userId">主键</param>
        /// <param name="fullName">名称</param>
        public void SetSendTo(string userId, string fullName)
        {
            this.ucUser.SelectedId = userId;
            this.ucUser.SelectedFullName = fullName;
            this.ActiveControl = this.txtContents;
            this.txtContents.Focus();
        }

        private void SetUser(string userId)
        {
            this.SetControlState();
        }

        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            // 设置按钮状态
            this.SetControlState();
        }

        private void ucUser_SelectedIndexChanged(string selectedId)
        {
            // 设置按钮状态
            this.SetControlState();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            StringBuilder sbmy = new StringBuilder();
            sbmy.Append("<div style='margin:2px;padding:0px 0px 0px 15px;" +
                    "font-family:" + this.txtContents.Font.FontFamily.Name + ";" +
                    "font-size:" +
                    this.txtContents.Font.Size + "pt;color:#" +
                    this.txtContents.ForeColor.R.ToString("X2") +
                    this.txtContents.ForeColor.G.ToString("X2") +
                    this.txtContents.ForeColor.B.ToString("X2"));
            sbmy.Append(";font-weight:");
            sbmy.Append(this.txtContents.Font.Bold ? "bold" : "");
            sbmy.Append(";font-style:");
            sbmy.Append(this.txtContents.Font.Italic ? "italic" : "");
            sbmy.Append(";'>");
            sbmy.Append(GetHtmlHref(this.txtContents.Text) + "</div>");

            DotNetService dotNetService = new DotNetService();
            if (this.ucUser.SelectedIds != null)
            {
                // 发送信息
                BaseMessageEntity messageEntity = new BaseMessageEntity();
                messageEntity.Id = BaseBusinessLogic.NewGuid();
                messageEntity.FunctionCode = MessageFunction.Message.ToString();
                messageEntity.Contents = sbmy.ToString();
                messageEntity.IsNew = 1;
                messageEntity.ReadCount = 0;
                messageEntity.Enabled = 1;
                messageEntity.DeletionStateCode = 0;
                dotNetService.MessageService.BatchSend(UserInfo, this.ucUser.SelectedIds, null, null, messageEntity);
            }
            else
            {
                if (this.ucUser.SelectedId != null)
                {
                    dotNetService.MessageService.Send(UserInfo, this.ucUser.SelectedId, sbmy.ToString());
                }
            }
            if (dotNetService.MessageService is ICommunicationObject)
            {
                ((ICommunicationObject)dotNetService.MessageService).Close();
            }
            // 2010-12-15 发好信息了，还是关闭了比较好
            // this.txtContent.Clear();
            // this.txtContent.Focus();
            this.Close();
        }

        private void btnMsgFont_Click(object sender, EventArgs e)
        {
            if (fontDialogMsg.ShowDialog() != DialogResult.Cancel)
            {
                txtContents.Font = fontDialogMsg.Font;
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialogMsg.ShowDialog() != DialogResult.Cancel)
            {
                txtContents.ForeColor = colorDialogMsg.Color;
            }
        }

        private string GetHtmlHref(string html)
        {
            Regex regex = new Regex(@"(http:\/\/([\w.]+\/?)\S*) ", RegexOptions.IgnoreCase
                | RegexOptions.CultureInvariant
                | RegexOptions.IgnorePatternWhitespace
                | RegexOptions.Compiled);
            html = regex.Replace(html, "<a href=\"$1\" target=\"_blank\">$1</a>");
            return html;
        }

        public ImagePopup _faceForm = null;
        public ImagePopup FaceForm
        {
            get
            {
                if (this._faceForm == null)
                {
                    this._faceForm = new ImagePopup
                    {
                        ImagePath = "Face\\",
                        //CustomImagePath = "Face\\Custom\\",
                        CanManage = true,
                        ShowDemo = true,
                    };

                    this._faceForm.Init(24, 24, 8, 8, 12, 8);
                    this._faceForm.Selected += this._faceForm_AddFace;

                }

                return this._faceForm;
            }
        }

        void _faceForm_AddFace(object sender, SelectFaceArgs e)
        {
            string imgName = "";
            int? imgInt = null;

            imgName = e.Img.FullName.Replace(Application.StartupPath + "\\", "");
            imgInt = Tools.GetNumberInt(imgName);
            int i = this.txtContents.SelectionStart;
            string result = this.txtContents.Text;
            imgName = "{[" + imgInt + "]}";
            result = result.Insert(i, imgName);
            this.txtContents.Text = result;
            this.txtContents.SelectionStart = i + imgName.Length;
        }

        private void btnSelectFack_Click(object sender, EventArgs e)
        {
            System.Drawing.Point pt = this.PointToScreen(new System.Drawing.Point(((Button)sender).Left, ((Button)sender).Height + 5));
            this.FaceForm.Show(pt.X, pt.Y, ((Button)sender).Height);
        }

        private void FrmMessageSend_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void FrmMessageSend_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    DotNetService dotNetService = new DotNetService();
                    for (int i = 0; i <= file.Length - 1; i++)
                    {
                        if (System.IO.File.Exists(file[i]))
                        {
                            byte[] fileContents = FileUtil.GetFile(file[i]);
                            string fileName = System.IO.Path.GetFileName(file[i]);
                            // dotNetService.FileService.Send(UserInfo, fileName, fileContents, this.ReceiverId);
                            // this.Text = "发送文件 " + fileName + " 成功，等待对方接收。";
                        }
                    }
                    if (dotNetService.MessageService is ICommunicationObject)
                    {
                        ((ICommunicationObject)dotNetService.MessageService).Close();
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