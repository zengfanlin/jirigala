namespace DotNet.WinForm
{
    partial class FrmPrint
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrint));
            this.btnPrintPageOne = new System.Windows.Forms.Button();
            this.btnPrintPageTwo = new System.Windows.Forms.Button();
            this.btnPrintNow = new System.Windows.Forms.Button();
            this.radiobtnacross = new System.Windows.Forms.RadioButton();
            this.radiobtnvertinal = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPirntSet = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.BtnLocalIP = new System.Windows.Forms.Button();
            this.btnFieldIP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPrintPageOne
            // 
            this.btnPrintPageOne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintPageOne.Location = new System.Drawing.Point(422, 404);
            this.btnPrintPageOne.Name = "btnPrintPageOne";
            this.btnPrintPageOne.Size = new System.Drawing.Size(75, 23);
            this.btnPrintPageOne.TabIndex = 0;
            this.btnPrintPageOne.Text = "打印1(F7)";
            this.btnPrintPageOne.UseVisualStyleBackColor = true;
            this.btnPrintPageOne.Click += new System.EventHandler(this.btnPrintPageOne_Click_1);
            // 
            // btnPrintPageTwo
            // 
            this.btnPrintPageTwo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintPageTwo.Location = new System.Drawing.Point(499, 404);
            this.btnPrintPageTwo.Name = "btnPrintPageTwo";
            this.btnPrintPageTwo.Size = new System.Drawing.Size(75, 23);
            this.btnPrintPageTwo.TabIndex = 1;
            this.btnPrintPageTwo.Text = "打印2(F8)";
            this.btnPrintPageTwo.UseVisualStyleBackColor = true;
            this.btnPrintPageTwo.Click += new System.EventHandler(this.btnPrintPageTwo_Click_1);
            // 
            // btnPrintNow
            // 
            this.btnPrintNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintNow.Location = new System.Drawing.Point(345, 404);
            this.btnPrintNow.Name = "btnPrintNow";
            this.btnPrintNow.Size = new System.Drawing.Size(75, 23);
            this.btnPrintNow.TabIndex = 2;
            this.btnPrintNow.Text = "直接打印";
            this.btnPrintNow.UseVisualStyleBackColor = true;
            this.btnPrintNow.Click += new System.EventHandler(this.btnPrintNow_Click);
            // 
            // radiobtnacross
            // 
            this.radiobtnacross.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radiobtnacross.AutoSize = true;
            this.radiobtnacross.Location = new System.Drawing.Point(78, 411);
            this.radiobtnacross.Name = "radiobtnacross";
            this.radiobtnacross.Size = new System.Drawing.Size(71, 16);
            this.radiobtnacross.TabIndex = 3;
            this.radiobtnacross.Text = "横向打印";
            this.radiobtnacross.UseVisualStyleBackColor = true;
            // 
            // radiobtnvertinal
            // 
            this.radiobtnvertinal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radiobtnvertinal.AutoSize = true;
            this.radiobtnvertinal.Checked = true;
            this.radiobtnvertinal.Location = new System.Drawing.Point(7, 411);
            this.radiobtnvertinal.Name = "radiobtnvertinal";
            this.radiobtnvertinal.Size = new System.Drawing.Size(71, 16);
            this.radiobtnvertinal.TabIndex = 4;
            this.radiobtnvertinal.TabStop = true;
            this.radiobtnvertinal.Text = "纵向打印";
            this.radiobtnvertinal.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(575, 404);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "关闭(C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPirntSet
            // 
            this.btnPirntSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPirntSet.Location = new System.Drawing.Point(191, 404);
            this.btnPirntSet.Name = "btnPirntSet";
            this.btnPirntSet.Size = new System.Drawing.Size(75, 23);
            this.btnPirntSet.TabIndex = 6;
            this.btnPirntSet.Text = "打印设置";
            this.btnPirntSet.UseVisualStyleBackColor = true;
            this.btnPirntSet.Click += new System.EventHandler(this.btnPirntSet_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(268, 404);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // BtnLocalIP
            // 
            this.BtnLocalIP.Location = new System.Drawing.Point(499, 375);
            this.BtnLocalIP.Name = "BtnLocalIP";
            this.BtnLocalIP.Size = new System.Drawing.Size(75, 23);
            this.BtnLocalIP.TabIndex = 8;
            this.BtnLocalIP.Text = "本地IP";
            this.BtnLocalIP.UseVisualStyleBackColor = true;
            this.BtnLocalIP.Click += new System.EventHandler(this.BtnLocalIP_Click);
            // 
            // btnFieldIP
            // 
            this.btnFieldIP.Location = new System.Drawing.Point(575, 375);
            this.btnFieldIP.Name = "btnFieldIP";
            this.btnFieldIP.Size = new System.Drawing.Size(75, 23);
            this.btnFieldIP.TabIndex = 9;
            this.btnFieldIP.Text = "域名IP";
            this.btnFieldIP.UseVisualStyleBackColor = true;
            this.btnFieldIP.Click += new System.EventHandler(this.btnFieldIP_Click);
            // 
            // FormPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DotNet.WinForm.Properties.Resources.Head;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(657, 431);
            this.Controls.Add(this.btnFieldIP);
            this.Controls.Add(this.BtnLocalIP);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPirntSet);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.radiobtnvertinal);
            this.Controls.Add(this.radiobtnacross);
            this.Controls.Add(this.btnPrintNow);
            this.Controls.Add(this.btnPrintPageTwo);
            this.Controls.Add(this.btnPrintPageOne);
            this.KeyPreview = true;
            this.Name = "FormPrint";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "抓屏打印";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GetPrint_KeyDown);
            this.Load += new System.EventHandler(this.FormPrint_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrintPageOne;
        private System.Windows.Forms.Button btnPrintPageTwo;
        private System.Windows.Forms.Button btnPrintNow;
        private System.Windows.Forms.RadioButton radiobtnacross;
        private System.Windows.Forms.RadioButton radiobtnvertinal;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPirntSet;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button BtnLocalIP;
        private System.Windows.Forms.Button btnFieldIP;
    }
}

