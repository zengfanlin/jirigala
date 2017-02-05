//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Drawing;

namespace DotNet.WinForm
{
    using DotNet.Utilities;
    using DotNet.Business;

    /// <summary>
    /// FrmMessageRemind.cs
    /// 消息提醒
    ///     1：首先所有的提醒信息都在这里显示比较好。
    ///     2：弹出的窗口位置最好是比较理想的位置，不能是屏幕中间。
    ///     3：消息一直在这个窗体里，能累加显示，比较省事，不要打开很多窗口比较好。
    ///     4：每次来消息的时候，应该有声音提示比较好。
    ///     5：还应该有个查看内容的按钮比较好。
    ///     6：消息一次取多个，好像有问题，现在只显示一个。 
    ///		
    /// 修改记录
    /// 
    ///     2012.06.04 版本：2.0 JiRiGaLa 改进功能。
    ///     2007.10.31 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：2.0
    ///
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.06.04</date>
    /// </author> 
    /// </summary>
    public partial class FrmMessageRemind : BaseForm
    {
        public FrmMessageRemind()
        {
            InitializeComponent();
        }

        // 声明FlashWindow()
        [DllImport("user32.dll")]
        public static extern bool FlashWindow(
         IntPtr hWnd,           //   handle   to   window   
         bool bInvert       //   flash   status   
         );

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // this.TopMost = true;
            this.StartPosition = FormStartPosition.Manual;

            Rectangle bounds = Screen.FromControl(this).WorkingArea;
            this.Location = new Point(bounds.Width - this.Width, bounds.Height - this.Height);
        }

        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }

        // 播放音乐
        [DllImport("winmm.dll")]
        // 播放windows音乐，重载
        public static extern bool PlaySound(string pszSound, int hmod, int fdwSound);
        public const int SND_FILENAME = 0x00020000;
        public const int SND_ASYNC = 0x0001;

        string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\Resources\\Media\\msg.wav";

        private void PlaySound()
        {
            PlaySound(filePath, 0, SND_ASYNC | SND_FILENAME);
        }

        // 防止线程阻塞的写法
        private delegate bool SetMessage(BaseMessageEntity message);

        public bool OnReceiveMessage(string message, string createOn = null)
        {
            if (createOn == null)
            {
                createOn = DateTime.Now.ToString(BaseSystemInfo.DateTimeFormat);
            }
            this.txtContents.AppendText(createOn + " : " + "\r\n");
            this.txtContents.AppendText(message + "\r\n");
            this.txtContents.AppendText("- - - - - - - - - - - - - - -" + "\r\n");
            this.txtContents.ScrollToCaret();
            this.PlaySound();
            FlashWindow(this.Handle, true);
            return true;
        }

        public bool OnReceiveMessage(BaseMessageEntity messageEntity)
        {
            bool returnValue = false;
            if (this.InvokeRequired)
            {
                SetMessage SetMessage = new SetMessage(OnReceiveMessage);
                this.Invoke(SetMessage, new object[] { messageEntity });
            }
            else
            {
                OnReceiveMessage(messageEntity.Contents, ((DateTime)messageEntity.CreateOn).ToString(BaseSystemInfo.DateTimeFormat));
                returnValue = true;
            }
            return returnValue;
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            /*
            if (this.FromUserId.Length == 0)
            {
                this.btnReply.Enabled = false;
            }
            else
            {
                this.btnReply.Enabled = true;
            }
            */
        }
        #endregion

        private void btnReply_Click(object sender, EventArgs e)
        {
            /*
            if (this.FromUserId.Length > 0)
            {
                this.Hide();
                ((FrmMessage)this.Owner).ShowMessageRead(this.FromUserId, this.FromUserFullName, this.Owner);
                this.Close();
            }
            */
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}