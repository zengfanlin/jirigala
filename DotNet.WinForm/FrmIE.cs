//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Configuration;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DotNet.Utilities;

namespace DotNet.WinForm
{
    public partial class FrmIE : BaseForm
    {
        public string MUrl { get; set; }

        public string MText { get; set; }

        public FrmIE()
        {
            InitializeComponent();
        }
        public FrmIE(string url)
            : this()
        {
            this.MUrl = url;
        }

        private void FrmIE_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MUrl)) return;
            if (CheckUrl(MUrl))
            {
                this.webBrowser.Navigate(MUrl);
            }
            else
            {
                this.webBrowser.Navigate(BaseSystemInfo.WebHostUrl + "/" + MUrl + string.Format("?{0}={1}", "OpenId", BaseSystemInfo.UserInfo.OpenId));
            }

            this.barAddress.ComboBoxEx.KeyDown += new KeyEventHandler(this.ComboKeyDown);
            barAddress.ComboBoxEx.SelectedIndexChanged += new EventHandler(this.ComboSelectionChanged);
        }

        private void ComboSelectionChanged(object sender, EventArgs e)
        {
            this.webBrowser.Navigate(this.barAddress.Text);
        }

        private void ComboKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.webBrowser.Navigate(this.barAddress.Text);
            }
        }

        #region IE处理相关
        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser.ReadyState < WebBrowserReadyState.Complete) return;
            //执行正常流程代码
            //WebLogin();
            if (!barAddress.Items.Contains(this.barAddress.Text))
                barAddress.Items.Add(this.barAddress.Text);
            this.webBrowser.Document.Window.Error += new HtmlElementErrorEventHandler(Window_Error);
        }

        //捕获控件的错误
        private void Window_Error(object sender, HtmlElementErrorEventArgs e)
        {
            // 自己的处理代码
            e.Handled = true;
        }

        //导航发生后发生
        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            this.barAddress.Text = this.webBrowser.Url.ToString();
            this.btnIEBack.Enabled = this.webBrowser.CanGoBack;
            this.btnIEForward.Enabled = this.webBrowser.CanGoForward;
        }

        //接收传进来的URL自动登录到web服务器，即URL单点登陆，这里只是简单的例子
        private void WebLogin()
        {
            HtmlDocument htmlDocument = webBrowser.Document;
            HtmlElement UserName = htmlDocument.GetElementById("UserName");//登录用户名
            HtmlElement Password = htmlDocument.GetElementById("Password");//登录用户名
            HtmlElement btnLogin = htmlDocument.GetElementById("btnLogin");//登录确定按钮
            btnLogin.Click += new HtmlElementEventHandler(btnLogin_Click);
        }

        private void btnLogin_Click(object sender, HtmlElementEventArgs e)
        {
            //这里写你的真正登录逻辑
        }


        private void webBrowser_NewWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            webBrowser.Navigate(webBrowser.StatusText);
        }
        #endregion

        #region 按钮处理相关
        private void BarNavigation_ItemClick(object sender, EventArgs e)
        {
            BaseItem item = sender as BaseItem;
            if (item == null) return;
            switch (item.Name)
            {
                case "btnIEBack":
                    webBrowser.GoBack();
                    break;
                case "btnIEForward":
                    webBrowser.GoForward();
                    break;
                case "btnIEGo":
                    BtnIEGo();
                    break;
                case "btnIEStop":
                    webBrowser.Stop();
                    break;
                case "btnIERefresh":
                    webBrowser.Refresh();
                    break;
                case "btnIEHome":
                    // 这里实现与B\S的单点登录功能
                    string url = @"http://www.hairihan.com.cn/dotnet.html?OpenId={OpenId}";
                    if (ConfigurationManager.AppSettings["HomePage"] != null)
                    {
                        url = ConfigurationManager.AppSettings["HomePage"];
                    }
                    url = this.UserInfo.GetUserParameter(url);
                    this.webBrowser.Url = new Uri(url);
                    //webBrowser.GoHome();
                    break;
                case "btnIEPrint":
                    webBrowser.Print();
                    break;
                default:
                    webBrowser.GoHome();
                    break;
            }

        }

        private void BtnIEGo()
        {
            webBrowser.Navigate(CheckUrl(this.barAddress.Text) ? GetUrl(this.barAddress.Text) : string.Format("http://www.baidu.com/s?wd={0}", barAddress.Text.Trim()));
        }

        private string GetUrl(string text)
        {
            text = text.ToLower();
            if (text.StartsWith("http:") || text.IndexOf(":") >= 0) return text;
            text = text.StartsWith("www") ? "http://" + text : "http://www." + text;
            return text;
        }
        /// <summary>
        /// URL检查
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool CheckUrl(string url)
        {
            url = url.ToLower();
            return url.StartsWith("http:") || url.StartsWith("www");
        }

        #endregion
    }
}