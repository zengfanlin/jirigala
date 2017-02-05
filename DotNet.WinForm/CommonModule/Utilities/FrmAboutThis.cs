//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Utilities;

    /// <summary>
    /// FrmAboutThis
    /// 
    /// 修改纪录
    /// 
    ///     2008.04.18 版本：2.1 JiRiGaLa 整理主键。
    ///     2007.08.20 版本：2.0 JiRiGaLa Instance 实例调用模式，加快运行速度。
    ///		2007.04.16 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：2.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.04.18</date>
    /// </author> 
    /// </summary>
    public partial class FrmAboutThis : BaseForm
    {
        public FrmAboutThis()
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
            // this.Text = "About " + BaseSystemInfo.SoftName + " Software";
            this.lblSoftFullName.Text = BaseSystemInfo.SoftFullName;
            this.lblVersion.Text = "Edition V" + BaseSystemInfo.Version;
            this.lblCopyright.Text = "Copyright 2003-2011 Hairihan TECH";
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
            // 漸進式開啟視窗
            TransparentToShowForm();
        }
        #endregion

        // Form.Opacity 可以取得或設定表單的透明度等級，
        // 當將這個屬性設為小於 100% (1.00) 的值時，整個表單 (包括框線) 將變得更為透明。
        // 將這個屬性設為 0% (0.00) 的值則使表單完全不可見。
        // 運用這個屬性，做Form的漸出與漸入

        // Form 漸出，Form.Opacity由 0 增加到 1，每次增加 0.01
        private void TransparentToShowForm()
        {
            for (Double dblLoop = 0.01; dblLoop <= 1; dblLoop += 0.1)
            {
                this.Opacity = dblLoop;
                Application.DoEvents();
                System.Threading.Thread.Sleep(100);
            }
        }

        // Form 漸入，Form.Opacity由 1 減少到 0，每次減少 0.01
        private void TransparentToHideForm()
        {
            for (Double dblLoop = 1.00; dblLoop >= 0; dblLoop -= 0.1)
            {
                this.Opacity = dblLoop;
                Application.DoEvents();
                System.Threading.Thread.Sleep(100);
            }
        }

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

        private void FrmAboutThis_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 漸進式退出視窗
            TransparentToHideForm();
        }
    }
}