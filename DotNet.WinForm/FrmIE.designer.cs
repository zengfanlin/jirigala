namespace DotNet.WinForm
{
    partial class FrmIE
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIE));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.BarNavigation = new DevComponents.DotNetBar.Bar();
            this.btnIEBack = new DevComponents.DotNetBar.ButtonItem();
            this.btnIEForward = new DevComponents.DotNetBar.ButtonItem();
            this.barAddress = new DevComponents.DotNetBar.ComboBoxItem();
            this.btnIEGo = new DevComponents.DotNetBar.ButtonItem();
            this.btnIEStop = new DevComponents.DotNetBar.ButtonItem();
            this.btnIERefresh = new DevComponents.DotNetBar.ButtonItem();
            this.btnIEHome = new DevComponents.DotNetBar.ButtonItem();
            this.btnIEPrint = new DevComponents.DotNetBar.ButtonItem();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarNavigation)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.webBrowser);
            this.panelEx1.Controls.Add(this.BarNavigation);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(957, 500);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            this.panelEx1.Text = "panelEx1";
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(957, 500);
            this.webBrowser.TabIndex = 5;
            this.webBrowser.Url = new System.Uri("http://www.baidu.com", System.UriKind.Absolute);
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            this.webBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser_Navigated);
            this.webBrowser.NewWindow += new System.ComponentModel.CancelEventHandler(this.webBrowser_NewWindow);
            // 
            // BarNavigation
            // 
            this.BarNavigation.AccessibleDescription = "DotNetBar Bar (BarNavigation)";
            this.BarNavigation.AccessibleName = "DotNetBar Bar";
            this.BarNavigation.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.BarNavigation.CanAutoHide = false;
            this.BarNavigation.CanDockBottom = false;
            this.BarNavigation.CanDockRight = false;
            this.BarNavigation.CanDockTab = false;
            this.BarNavigation.CanDockTop = false;
            this.BarNavigation.CanReorderTabs = false;
            this.BarNavigation.CanUndock = false;
            this.BarNavigation.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarNavigation.DockedBorderStyle = DevComponents.DotNetBar.eBorderType.Raised;
            this.BarNavigation.DockLine = 1;
            this.BarNavigation.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.BarNavigation.FadeEffect = true;
            this.BarNavigation.Font = new System.Drawing.Font("宋体", 9F);
            this.BarNavigation.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.Office2003;
            this.BarNavigation.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnIEBack,
            this.btnIEForward,
            this.barAddress,
            this.btnIEGo,
            this.btnIEStop,
            this.btnIERefresh,
            this.btnIEHome,
            this.btnIEPrint});
            this.BarNavigation.Location = new System.Drawing.Point(0, 0);
            this.BarNavigation.MenuBar = true;
            this.BarNavigation.Name = "BarNavigation";
            this.BarNavigation.Size = new System.Drawing.Size(957, 38);
            this.BarNavigation.Stretch = true;
            this.BarNavigation.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.BarNavigation.TabIndex = 6;
            this.BarNavigation.TabStop = false;
            this.BarNavigation.Text = "IE浏览器";
            this.BarNavigation.Visible = false;
            this.BarNavigation.ItemClick += new System.EventHandler(this.BarNavigation_ItemClick);
            // 
            // btnIEBack
            // 
            this.btnIEBack.GlobalName = "btnIEBack";
            this.btnIEBack.Image = ((System.Drawing.Image)(resources.GetObject("btnIEBack.Image")));
            this.btnIEBack.Name = "btnIEBack";
            this.btnIEBack.Text = "&Back";
            // 
            // btnIEForward
            // 
            this.btnIEForward.GlobalName = "btnIEForward";
            this.btnIEForward.Image = ((System.Drawing.Image)(resources.GetObject("btnIEForward.Image")));
            this.btnIEForward.Name = "btnIEForward";
            this.btnIEForward.Text = "&Forward";
            // 
            // barAddress
            // 
            this.barAddress.ComboWidth = 128;
            this.barAddress.DropDownHeight = 106;
            this.barAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.barAddress.GlobalName = "barAddress";
            this.barAddress.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.barAddress.LabelForeColor = System.Drawing.Color.Transparent;
            this.barAddress.Name = "barAddress";
            this.barAddress.Stretch = true;
            this.barAddress.Text = "http://";
            this.barAddress.Tooltip = "请输入查询";
            this.barAddress.WatermarkText = "请输入查询";
            // 
            // btnIEGo
            // 
            this.btnIEGo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnIEGo.FixedSize = new System.Drawing.Size(0, 9);
            this.btnIEGo.GlobalName = "btnIEGo";
            this.btnIEGo.Image = ((System.Drawing.Image)(resources.GetObject("btnIEGo.Image")));
            this.btnIEGo.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.btnIEGo.Name = "btnIEGo";
            this.btnIEGo.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnIEGo.SplitButton = true;
            this.btnIEGo.Text = "Go";
            // 
            // btnIEStop
            // 
            this.btnIEStop.GlobalName = "btnIEStop";
            this.btnIEStop.Image = ((System.Drawing.Image)(resources.GetObject("btnIEStop.Image")));
            this.btnIEStop.Name = "btnIEStop";
            this.btnIEStop.Text = "&Stop";
            // 
            // btnIERefresh
            // 
            this.btnIERefresh.GlobalName = "btnIERefresh";
            this.btnIERefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnIERefresh.Image")));
            this.btnIERefresh.Name = "btnIERefresh";
            this.btnIERefresh.Text = "&Refresh";
            // 
            // btnIEHome
            // 
            this.btnIEHome.GlobalName = "btnIEHome";
            this.btnIEHome.Image = ((System.Drawing.Image)(resources.GetObject("btnIEHome.Image")));
            this.btnIEHome.Name = "btnIEHome";
            this.btnIEHome.Text = "&Home";
            // 
            // btnIEPrint
            // 
            this.btnIEPrint.BeginGroup = true;
            this.btnIEPrint.GlobalName = "btnIEPrint";
            this.btnIEPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnIEPrint.Image")));
            this.btnIEPrint.Name = "btnIEPrint";
            this.btnIEPrint.Text = "&Print";
            // 
            // FrmIE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 500);
            this.Controls.Add(this.panelEx1);
            this.Name = "FrmIE";
            this.Text = "导航页面";
            this.Load += new System.EventHandler(this.FrmIE_Load);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BarNavigation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        public System.Windows.Forms.WebBrowser webBrowser;
        private DevComponents.DotNetBar.Bar BarNavigation;
        private DevComponents.DotNetBar.ButtonItem btnIEBack;
        private DevComponents.DotNetBar.ButtonItem btnIEForward;
        private DevComponents.DotNetBar.ComboBoxItem barAddress;
        private DevComponents.DotNetBar.ButtonItem btnIEGo;
        private DevComponents.DotNetBar.ButtonItem btnIEHome;
        private DevComponents.DotNetBar.ButtonItem btnIEStop;
        private DevComponents.DotNetBar.ButtonItem btnIERefresh;
        private DevComponents.DotNetBar.ButtonItem btnIEPrint;
    }
}