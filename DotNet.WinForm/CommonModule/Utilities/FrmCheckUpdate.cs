//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Utilities;

    /// <summary>
    /// FrmCheckUpdate
    /// 
    /// 修改纪录
    /// 
    ///		2011.12.17 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.04.18</date>
    /// </author> 
    /// </summary>
    public partial class FrmCheckUpdate : BaseForm
    {
        public FrmCheckUpdate()
        {
            this.ShowDialogOnly = true;
            InitializeComponent();
        }

        #region private void GetSystemInfo() 获取配置信息
        /// <summary>
        /// 获取配置信息
        /// </summary>
        private void GetSystemInfo()
        {
            this.lblCurrentVersion.Text = BaseSystemInfo.Version;
            string fileName = "http://files.cnblogs.com/jirigala/Config.xml";
            string selectPath = "//appSettings/add";
            string key = "Version";
            this.lblNewVersion.Text = UserConfigHelper.GetValue(fileName, selectPath, key);
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 获取配置信息
            this.GetSystemInfo();
        }
        #endregion

        private void lblLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // 获取导航地址
            LinkLabel llabNavigation = (LinkLabel)sender;
            string targetUrl = llabNavigation.Tag.ToString();
            // 打开浏览器，导航到相应的网址上
            System.Diagnostics.Process.Start(targetUrl);
        }

        private void FrmAboutThis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 关闭此窗口
            this.Close();
        }
    }
}