//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    
    public partial class FrmSendEmail : BaseForm
    {
        BaseStaffEntity staffEntity = null;
        BaseUserEntity UserEntity = null;

        public FrmSendEmail()
        {
            InitializeComponent();
            // 若是没有
            if (this.EntityId.Length == 0)
            {
                this.EntityId = UserInfo.StaffId;
            }
        }

        public FrmSendEmail(string id)
            : this()
        {
            this.EntityId = id;
            staffEntity = DotNetService.Instance.StaffService.GetEntity(UserInfo, EntityId);
            UserEntity = DotNetService.Instance.UserService.GetEntity(UserInfo, staffEntity.UserId.ToString());
            this.txtEmailAddress.Text = UserEntity.Email;
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {

            // 邮件内容
            string mailContent = txtMailContent.Text.ToString();
            // 收件人
            string mailAddres = staffEntity.Email;

            try
            {
                MailMessage msg = new MailMessage();
                msg.To.Add(mailAddres);

                msg.From = new MailAddress("gaowenbinmarr@gamil.com", "高文彬", System.Text.Encoding.UTF8);
                // 邮件标题
                //msg.Subject = txtTitle.Text;
                // 标题编码
                msg.SubjectEncoding = System.Text.Encoding.UTF8;
                // 邮件主体
                msg.Body = mailContent;
                // 邮件主题编码
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                msg.IsBodyHtml = false;
                // 设置优先级
                msg.Priority = MailPriority.High;

                SmtpClient client = new SmtpClient();
                client.Host = "stmp.gmail.com";
                client.Port = 587;

                client.Credentials = new NetworkCredential("gaowenbinmarr@gmail.com", "63020661146");
                client.EnableSsl = true;
                try
                {
                    client.Send(msg);
                    MessageBox.Show("邮件发送成功");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("邮件发送失败，" + ex);
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("邮件发送失败，" + ex);
            }
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
