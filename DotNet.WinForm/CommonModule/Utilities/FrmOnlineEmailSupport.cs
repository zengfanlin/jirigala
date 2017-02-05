//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace DotNet.WinForm
{
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
    public partial class FrmOnlineEmailSupport : BaseForm
    {
        public FrmOnlineEmailSupport()
        {
            InitializeComponent();
            // UserInfo = new BaseUserInfo(this.Name, this.Text);
        }

        public override void FormOnLoad()
        {
            this.txtSendTo.Text = BaseSystemInfo.ErrorReportTo;
            this.txtContent.Focus();
        }

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool returnValue = true;
            if (this.txtContent.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessage.MSG0240, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtContent.Focus();
                return false;
            }
            return returnValue;
        }
        #endregion

        #region private void SendEmail() 发送邮件
        /// <summary>
        /// 发送邮件
        /// </summary>
        private void SendEmail()
        {
            if (BaseSystemInfo.ErrorReportTo.Length == 0)
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
                mailMessage.Subject = "Online Email Support " + BaseSystemInfo.CustomerCompanyName + " - " + UserInfo.RealName;
                // 邮件内容
                mailMessage.Body = this.txtContent.Text;
                mailMessage.IsBodyHtml = false;
                mailMessage.Priority = MailPriority.High;
                mailMessage.From = new MailAddress(BaseSystemInfo.ErrorReportMailUserName, BaseSystemInfo.CustomerCompanyName + "程序异常报告");
                // 我的邮件服务器是哪里
                SmtpClient SmtpClient = new SmtpClient(BaseSystemInfo.ErrorReportMailServer);
                // 用我的用户名密码连接服务器
                SmtpClient.Credentials = new NetworkCredential(BaseSystemInfo.ErrorReportMailUserName, BaseSystemInfo.ErrorReportMailPassword);
                // 我的用户名密码是什么
                SmtpClient.UseDefaultCredentials = true;
                // 邮件来自哪里

                // 发送邮件
                SmtpClient.Send(mailMessage);
            }
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnSendEmail.Enabled = this.txtContent.Text.Length > 0;
        }
        #endregion

        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            // 设置按钮状态
            this.SetControlState();
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                try
                {
                    this.SendEmail();
                    this.Close();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(AppMessage.MSG0241 + "\n" + ex.Message, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}