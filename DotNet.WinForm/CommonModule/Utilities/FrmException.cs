//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Drawing.Printing;
using System.Net.Mail;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FrmException
    /// 
    /// 修改纪录
    /// 
    ///     2007.08.20 版本：2.0 JiRiGaLa Instance 实例调用模式，加快运行速度。
    ///		2007.04.16 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：2.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.04.16</date>
    /// </author> 
    /// </summary>
    public partial class FrmException : BaseForm
    {
        /// <summary>
        /// 异常信息
        /// </summary>
        public BaseExceptionEntity ExceptionEntity = null;

        public FrmException()
        {
            InitializeComponent();
        }

        private BaseExceptionEntity ConvertException(Exception ex)
        {
            BaseExceptionEntity exceptionEntity = new BaseExceptionEntity();
            exceptionEntity.Message = ex.Message;
            exceptionEntity.FormattedMessage = ex.Source;
            exceptionEntity.CreateOn = System.DateTime.Now.ToString(BaseSystemInfo.DateTimeFormat);
            exceptionEntity.CreateUserId = UserInfo.Id;
            exceptionEntity.CreateBy = UserInfo.RealName;
            return exceptionEntity;
        }

        public FrmException(BaseExceptionEntity exceptionEntity) : this()
        {
            this.ExceptionEntity = exceptionEntity;
        }

        public FrmException(Exception ex) : this()
        {
            this.ExceptionEntity = this.ConvertException(ex);
        }

        public override void FormOnLoad()
        {
            this.ShowEntity();
        }
        
        #region public override void ShowEntity() 显示异常
        /// <summary>
        /// 显示异常
        /// </summary>
        public override void ShowEntity()
        {
            this.txtCustomer.Text = BaseSystemInfo.CustomerCompanyName;
            this.txtSoft.Text = BaseSystemInfo.SoftFullName;
            this.txtUser.Text = this.ExceptionEntity.CreateBy;
            this.txtUser.Tag = this.ExceptionEntity.CreateUserId;
            this.txtOccurTime.Text = this.ExceptionEntity.CreateOn;
            this.txtException.Text = this.ExceptionEntity.Message + System.Environment.NewLine + this.ExceptionEntity.FormattedMessage;
        }
        #endregion

        private void docToPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string text = this.txtException.Text;
            System.Drawing.Font printFont = new System.Drawing.Font("宋体", 30, System.Drawing.FontStyle.Regular);
            e.Graphics.DrawString(text, printFont, System.Drawing.Brushes.Black, e.MarginBounds.X, e.MarginBounds.Y);
        }

        private void Print()
        {
            PrintDialog printDialogException = new PrintDialog();
            DialogResult result = printDialogException.ShowDialog();
            PrintDocument docToPrint = new PrintDocument(); 
            docToPrint.PrintPage += new PrintPageEventHandler(docToPrint_PrintPage);
            printDialogException.AllowSomePages = true; 
            printDialogException.ShowHelp = true;
            printDialogException.Document = docToPrint;
            if (result == DialogResult.OK)
            {
                docToPrint.Print();
            }
        }        

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.Print();
        }

        #region private void SendErrorReport() 发送错误报告
        /// <summary>
        /// 发送错误报告
        /// </summary>
        private void SendErrorReport()
        {
            if (string.IsNullOrEmpty(BaseSystemInfo.ErrorReportTo))
            {
                return;
            }
            string[] errorReportTo = BaseSystemInfo.ErrorReportTo.Split(',', ';', ' ');
            // 邮件的内容部分
            MailMessage mailMessage = new MailMessage();
            // 收件箱
            for (int i = 0; i < errorReportTo.Length; i++)
            {
                if (errorReportTo[i].Trim().Length > 0)
                {
                    mailMessage.To.Add(errorReportTo[i].Trim());
                }
            }
            if (mailMessage.To.Count > 0)
            {
                // 邮件主题
                mailMessage.Subject = "Error From " + this.txtCustomer.Text + "(" + this.UserInfo.IPAddress + ")";
                // 邮件内容
                mailMessage.Body = this.txtException.Text;
                mailMessage.IsBodyHtml = false;
                mailMessage.Priority = MailPriority.High;
                mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                mailMessage.From = new MailAddress(BaseSystemInfo.ErrorReportMailUserName, BaseSystemInfo.CustomerCompanyName + AppMessage.MSG0243);
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Credentials = new System.Net.NetworkCredential(BaseSystemInfo.ErrorReportMailUserName, BaseSystemInfo.ErrorReportMailPassword);
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);
            }
        }
        #endregion

        private void btnReport_Click(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.SendErrorReport();
                // 是否需要有提示信息？
                if (BaseSystemInfo.ShowInformation)
                {
                    // 批量保存，进行提示
                    MessageBox.Show(AppMessage.MSG0237, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}