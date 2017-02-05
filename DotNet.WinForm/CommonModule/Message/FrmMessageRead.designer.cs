namespace DotNet.WinForm
{
    partial class FrmMessageRead
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的主键

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用主键编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMessageRead));
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.webMessage = new System.Windows.Forms.WebBrowser();
            this.colorDialogMsg = new System.Windows.Forms.ColorDialog();
            this.btnColor = new System.Windows.Forms.Button();
            this.fontDialogMsg = new System.Windows.Forms.FontDialog();
            this.btnMsgFont = new System.Windows.Forms.Button();
            this.btnSelectFack = new System.Windows.Forms.Button();
            this.pic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // txtContent
            // 
            this.txtContent.AllowDrop = true;
            this.txtContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContent.Location = new System.Drawing.Point(2, 403);
            this.txtContent.MaxLength = 800;
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContent.Size = new System.Drawing.Size(405, 85);
            this.txtContent.TabIndex = 1;
            this.txtContent.TextChanged += new System.EventHandler(this.txtContent_TextChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDescription.Location = new System.Drawing.Point(1, 381);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(103, 12);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "回复内容(&C):";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(244, 493);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "发送(&S)";
            this.btnSend.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(325, 493);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // webMessage
            // 
            this.webMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webMessage.Location = new System.Drawing.Point(2, 55);
            this.webMessage.MinimumSize = new System.Drawing.Size(20, 20);
            this.webMessage.Name = "webMessage";
            this.webMessage.Size = new System.Drawing.Size(405, 314);
            this.webMessage.TabIndex = 5;
            this.webMessage.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBMsg_DocumentCompleted);
            // 
            // btnColor
            // 
            this.btnColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnColor.Location = new System.Drawing.Point(187, 376);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(47, 23);
            this.btnColor.TabIndex = 7;
            this.btnColor.Text = "颜色";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Visible = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnMsgFont
            // 
            this.btnMsgFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMsgFont.Location = new System.Drawing.Point(133, 376);
            this.btnMsgFont.Name = "btnMsgFont";
            this.btnMsgFont.Size = new System.Drawing.Size(48, 23);
            this.btnMsgFont.TabIndex = 9;
            this.btnMsgFont.Text = "字体";
            this.btnMsgFont.UseVisualStyleBackColor = true;
            this.btnMsgFont.Visible = false;
            this.btnMsgFont.Click += new System.EventHandler(this.btnMsgFont_Click);
            // 
            // btnSelectFack
            // 
            this.btnSelectFack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectFack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectFack.Image = global::DotNet.WinForm.Properties.Resources.Face_0;
            this.btnSelectFack.Location = new System.Drawing.Point(93, 370);
            this.btnSelectFack.Name = "btnSelectFack";
            this.btnSelectFack.Size = new System.Drawing.Size(34, 34);
            this.btnSelectFack.TabIndex = 11;
            this.btnSelectFack.UseVisualStyleBackColor = true;
            this.btnSelectFack.Visible = false;
            this.btnSelectFack.Click += new System.EventHandler(this.btnSelectFack_Click);
            // 
            // pic
            // 
            this.pic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic.Location = new System.Drawing.Point(406, 55);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(156, 156);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic.TabIndex = 12;
            this.pic.TabStop = false;
            // 
            // FrmMessageRead
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(565, 528);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.btnSelectFack);
            this.Controls.Add(this.btnMsgFont);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.webMessage);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnCancel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmMessageRead";
            this.ShowInTaskbar = true;
            this.Text = "即时通讯";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMessageRead_FormClosing);
            this.Load += new System.EventHandler(this.FrmMessageRead_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FrmMessageRead_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.FrmMessageRead_DragOver);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.WebBrowser webMessage;
        private System.Windows.Forms.ColorDialog colorDialogMsg;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.FontDialog fontDialogMsg;
        private System.Windows.Forms.Button btnMsgFont;
        private System.Windows.Forms.Button btnSelectFack;
        private System.Windows.Forms.PictureBox pic;
    }
}