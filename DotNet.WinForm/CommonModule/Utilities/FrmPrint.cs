//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    /// <summary>
    /// FormPrint
    /// 窗體打印
    /// 
    /// 修改紀錄
    ///
    ///     2007.07.31 版本：1.5 JinGangBo  新增獲得本地IP地址與通過域名獲得IP地址
    ///     2007.07.30 版本：1.4 JinGangBo  新增設置打印按鈕功能。
    ///     2007.07.27 版本：1.3 JinGangBo  實現打印設置，修改橫向打印，新增了焦點和???，界面排布修改
    ///     2007.07.27 版本：1.2 JinGangBo  實現橫向打印和縱向打印，打印預覽最大化，及自動調及100%，及直接打印。
    ///     2007.07.26 版本：1.1 JinGangBo  代碼修改與整理
    ///     2007.07.26 版本：1.0 JinGangBo  使用2種方法進行了窗體打印
    ///     
    /// 版本：1.3
    /// 
    /// <author>
    ///		<name>JinGangBo</name>
    ///		<date>2007.07.26</date>
    /// </author>
    /// </summary>
    public partial class FrmPrint : Form
    {
        public FrmPrint()
        {
            InitializeComponent();
        }

        private Bitmap memoryImageOne;
        private Image memoryImageTwo;

        //新建打印設置
        PrintDocument myPrintDocumentSet = new PrintDocument();

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

        private void GetPrint_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 118:
                    // 點擊了F7按鈕
                    this.PrintPageOne();
                    break;
                case 119:
                    // 點擊了F8按鈕
                    this.PrintPageTwo();
                    break;
                case 67:
                    this.Close();
                    break;
                case 27:
                    this.Close();
                    break;
            }
        }

        #region private void PrintPageOne() 打印預覽方法一
        /// <summary>
        /// 打印預覽
        /// </summary>
        private void PrintPageOne()
        {
            //設置為忙碌狀態
            this.Cursor = Cursors.WaitCursor;
            //創建當前屏幕的DC對像
            Graphics mygraphics = this.CreateGraphics();
            Size s = this.Size;
            //創建以當前活動頁大小為標準的位圖對像 
            memoryImageOne = new Bitmap(s.Width, s.Height, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImageOne);
            //得到屏幕DC
            IntPtr dc1 = mygraphics.GetHdc();
            //得到位圖的DC 
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, dc1, 0, 0, 13369376);
            //釋放DC 
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
            //新建打印預覽窗體
            PrintPreviewDialog myPrintPreviewDialogOne = new PrintPreviewDialog();
            //新建打印對像
            PrintDocument myPrintDocumentOne = new PrintDocument();
            //新建打印設置
            PageSetupDialog myPageSetupDialogOne = new PageSetupDialog();
            //新建打印輸出
            myPrintDocumentOne.PrintPage += new PrintPageEventHandler(myPrintDocumentOne_PrintPage);
            //獲取打印預覽
            myPrintPreviewDialogOne.Document = myPrintDocumentOne;
            //將預攬調製100%
            myPrintPreviewDialogOne.PrintPreviewControl.Zoom = 1.0;
            //將預覽窗體最大化
            ((System.Windows.Forms.Form)myPrintPreviewDialogOne).WindowState = FormWindowState.Maximized;
            //打開打印預覽窗口
            myPrintPreviewDialogOne.ShowDialog();
            //設置鼠標默認狀態
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region private void PrintPageTwo() 打印預覽方法二
        /// <summary>
        /// 打印預覽
        /// </summary>
        private void PrintPageTwo()
        {
            //設置為忙碌狀態
            this.Cursor = Cursors.WaitCursor;
            //獲得ALT+PRINT熱鍵
            //SendKeys.SendWait("%{PRTSC}");
            //新建打印預覽窗體 
            PrintPreviewDialog myPrintPreviewDialogTwo = new PrintPreviewDialog();
            //新建打印對像
            PrintDocument myPrintDocumentTwo = new PrintDocument();
            //新建打印輸出 
            myPrintDocumentTwo.PrintPage += new PrintPageEventHandler(myPrintDocumentTwo_PrintPage);
            //新建打印設置
            PageSetupDialog myPageSetupDialogTwo = new PageSetupDialog();
            //獲取打印預覽
            myPrintPreviewDialogTwo.Document = myPrintDocumentTwo;
            //將預攬調製100%
            myPrintPreviewDialogTwo.PrintPreviewControl.Zoom = 1.0;
            //將預覽窗體最大化
            ((System.Windows.Forms.Form)myPrintPreviewDialogTwo).WindowState = FormWindowState.Maximized;
            //打開打印預覽窗口
            myPrintPreviewDialogTwo.ShowDialog();
            //設置鼠標默認狀態
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region private void PrintPageImmediacy() 直接打印
        /// <summary>
        /// 直接打印
        /// </summary>
        private void PrintPageImmediacy()
        {
            //設置為忙碌狀態
            this.Cursor = Cursors.WaitCursor;
            //獲得ALT+PRINT熱鍵
            //SendKeys.SendWait("%{PRTSC}");
            //新建打印預覽窗體 
            PrintPreviewDialog myPrintPreviewDialogTwo = new PrintPreviewDialog();
            //新建打印對像
            PrintDocument myPrintDocumentTwo = new PrintDocument();
            //新建打印輸出 
            myPrintDocumentTwo.PrintPage += new PrintPageEventHandler(myPrintDocumentTwo_PrintPage);
            //新建打印設置
            PageSetupDialog myPageSetupDialogTwo = new PageSetupDialog();
            //獲取打印預覽
            myPrintPreviewDialogTwo.Document = myPrintDocumentTwo;
            //將預攬調製100%
            myPrintPreviewDialogTwo.PrintPreviewControl.Zoom = 1.0;
            //直接打印
            myPrintDocumentTwo.Print();
            //設置鼠標默認狀態
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region private void PrintSet() 打印設置
        /// <summary>
        /// 打印設置
        /// </summary>
        private void PrintSet()
        {
            //設置為忙碌狀態
            this.Cursor = Cursors.WaitCursor;
            //獲得ALT+PRINT熱鍵
            //SendKeys.SendWait("%{PRTSC}");
            //新建打印輸出 
            myPrintDocumentSet.PrintPage += new PrintPageEventHandler(myPrintDocumentTwo_PrintPage);
            //新建打印設置
            PageSetupDialog myPageSetupDialog = new PageSetupDialog();
            //在打印設置中填充圖像            
            myPageSetupDialog.Document = myPrintDocumentSet;
            myPageSetupDialog.PageSettings.Landscape = true;
            myPageSetupDialog.ShowDialog(this);
            //保存設置
            myPrintDocumentSet.DefaultPageSettings = myPageSetupDialog.PageSettings;
            myPrintDocumentSet.PrinterSettings = myPageSetupDialog.PrinterSettings;
            //設置鼠標默認狀態
            this.Cursor = Cursors.Default;
        }
        #endregion

        private void myPrintDocumentOne_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (radiobtnvertinal.Checked == true)
            {
                //繪製打印預覽方法一
                e.Graphics.DrawImage(memoryImageOne, 0, 0);
            }
            else
            {
                //圖片旋轉９０
                memoryImageOne.RotateFlip(RotateFlipType.Rotate90FlipXY);
                e.Graphics.DrawImage(memoryImageOne, 0, 0);
            }
        }

        private void myPrintDocumentTwo_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //從剪切板中獲得圖片
            memoryImageTwo = Clipboard.GetImage();
            if (radiobtnvertinal.Checked == true)
            {
                //繪製打印預覽方法一
                e.Graphics.DrawImage(memoryImageTwo, 0, 0);
            }
            else
            {
                //圖片旋轉９０
                memoryImageTwo.RotateFlip(RotateFlipType.Rotate90FlipXY);
                e.Graphics.DrawImage(memoryImageTwo, 0, 0);
            }
        }

        private void btnPirntSet_Click(object sender, EventArgs e)
        {
            this.PrintSet();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            myPrintDocumentSet.Print();
        }

        private void btnPrintNow_Click(object sender, EventArgs e)
        {
            this.PrintPageImmediacy();
        }

        private void btnPrintPageOne_Click_1(object sender, EventArgs e)
        {
            this.PrintPageOne();
        }

        private void btnPrintPageTwo_Click_1(object sender, EventArgs e)
        {
            this.PrintPageTwo();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPrint_Load(object sender, EventArgs e)
        {
            btnCancel.Focus();
        }

        private void BtnLocalIP_Click(object sender, EventArgs e)
        {
            //取得本地的機器名
            string strHostName = System.Net.Dns.GetHostName();
            //根據字符串型的主機名稱,得到IP地址
            //IP獲得過時寫法[否決的]
            //System.Net.IPHostEntry myHostinfo = System.Net.Dns.GetHostByName(strHostName);
            //IP最新獲得方法　　
            System.Net.IPHostEntry myHostinfo = System.Net.Dns.GetHostEntry(strHostName);
            System.Net.IPAddress myIpAddress = myHostinfo.AddressList[0];
            MessageBox.Show(myIpAddress.ToString());
        }

        private void btnFieldIP_Click(object sender, EventArgs e)
        {
            //域名IP獲得過時寫法[否決的]
            //string strIP = System.Net.Dns.GetHostByName("www.sina.com.cn").AddressList[0].ToString();
            string strIP = System.Net.Dns.GetHostEntry("www.sina.com.cn").AddressList[0].ToString();
            MessageBox.Show(strIP);
        }
    }
}