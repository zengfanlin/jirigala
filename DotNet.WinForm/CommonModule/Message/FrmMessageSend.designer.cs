namespace DotNet.WinForm
{
    partial class FrmMessageSend
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
            this.btnSend = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.colorDialogMsg = new System.Windows.Forms.ColorDialog();
            this.fontDialogMsg = new System.Windows.Forms.FontDialog();
            this.grbMessage = new System.Windows.Forms.GroupBox();
            this.btnSelectFack = new System.Windows.Forms.Button();
            this.btnMsgFont = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.lblContentReq = new System.Windows.Forms.Label();
            this.ucUser = new DotNet.WinForm.UCUserSelect();
            this.lblStaffReq = new System.Windows.Forms.Label();
            this.txtContents = new System.Windows.Forms.TextBox();
            this.lblContents = new System.Windows.Forms.Label();
            this.lblSendTo = new System.Windows.Forms.Label();
            this.grbMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(445, 250);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "发送(&S)";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(526, 250);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grbMessage
            // 
            this.grbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbMessage.Controls.Add(this.btnSelectFack);
            this.grbMessage.Controls.Add(this.btnMsgFont);
            this.grbMessage.Controls.Add(this.btnColor);
            this.grbMessage.Controls.Add(this.lblContentReq);
            this.grbMessage.Controls.Add(this.ucUser);
            this.grbMessage.Controls.Add(this.lblStaffReq);
            this.grbMessage.Controls.Add(this.txtContents);
            this.grbMessage.Controls.Add(this.lblContents);
            this.grbMessage.Controls.Add(this.lblSendTo);
            this.grbMessage.Location = new System.Drawing.Point(13, 13);
            this.grbMessage.Name = "grbMessage";
            this.grbMessage.Size = new System.Drawing.Size(588, 227);
            this.grbMessage.TabIndex = 7;
            this.grbMessage.TabStop = false;
            this.grbMessage.Text = "信息";
            // 
            // btnSelectFack
            // 
            this.btnSelectFack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectFack.Image = global::DotNet.WinForm.Properties.Resources.Face_0;
            this.btnSelectFack.Location = new System.Drawing.Point(424, 15);
            this.btnSelectFack.Name = "btnSelectFack";
            this.btnSelectFack.Size = new System.Drawing.Size(34, 34);
            this.btnSelectFack.TabIndex = 22;
            this.btnSelectFack.UseVisualStyleBackColor = true;
            this.btnSelectFack.Visible = false;
            // 
            // btnMsgFont
            // 
            this.btnMsgFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMsgFont.Location = new System.Drawing.Point(464, 20);
            this.btnMsgFont.Name = "btnMsgFont";
            this.btnMsgFont.Size = new System.Drawing.Size(48, 23);
            this.btnMsgFont.TabIndex = 21;
            this.btnMsgFont.Text = "字体";
            this.btnMsgFont.UseVisualStyleBackColor = true;
            this.btnMsgFont.Visible = false;
            this.btnMsgFont.Click += new System.EventHandler(this.btnMsgFont_Click);
            // 
            // btnColor
            // 
            this.btnColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnColor.Location = new System.Drawing.Point(518, 20);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(47, 23);
            this.btnColor.TabIndex = 20;
            this.btnColor.Text = "颜色";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Visible = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // lblContentReq
            // 
            this.lblContentReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContentReq.AutoSize = true;
            this.lblContentReq.ForeColor = System.Drawing.Color.Red;
            this.lblContentReq.Location = new System.Drawing.Point(568, 57);
            this.lblContentReq.Name = "lblContentReq";
            this.lblContentReq.Size = new System.Drawing.Size(11, 12);
            this.lblContentReq.TabIndex = 19;
            this.lblContentReq.Text = "*";
            // 
            // ucUser
            // 
            this.ucUser.AllowNull = true;
            this.ucUser.AllowSelect = true;
            this.ucUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucUser.Location = new System.Drawing.Point(105, 21);
            this.ucUser.MultiSelect = true;
            this.ucUser.Name = "ucUser";
            this.ucUser.OpenId = "";
            this.ucUser.PermissionItemScopeCode = "";
            this.ucUser.RemoveIds = null;
            this.ucUser.SelectedFullName = "";
            this.ucUser.SelectedId = "";
            this.ucUser.SelectedIds = null;
            this.ucUser.SetSelectIds = null;
            this.ucUser.Size = new System.Drawing.Size(296, 22);
            this.ucUser.TabIndex = 15;
            this.ucUser.SelectedIndexChanged += new DotNet.Utilities.BaseBusinessLogic.SelectedIndexChangedEventHandler(this.ucUser_SelectedIndexChanged);
            // 
            // lblStaffReq
            // 
            this.lblStaffReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStaffReq.AutoSize = true;
            this.lblStaffReq.ForeColor = System.Drawing.Color.Red;
            this.lblStaffReq.Location = new System.Drawing.Point(407, 25);
            this.lblStaffReq.Name = "lblStaffReq";
            this.lblStaffReq.Size = new System.Drawing.Size(11, 12);
            this.lblStaffReq.TabIndex = 16;
            this.lblStaffReq.Text = "*";
            // 
            // txtContents
            // 
            this.txtContents.AllowDrop = true;
            this.txtContents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContents.Location = new System.Drawing.Point(105, 55);
            this.txtContents.MaxLength = 800;
            this.txtContents.Multiline = true;
            this.txtContents.Name = "txtContents";
            this.txtContents.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContents.Size = new System.Drawing.Size(460, 156);
            this.txtContents.TabIndex = 18;
            this.txtContents.TextChanged += new System.EventHandler(this.txtContent_TextChanged);
            // 
            // lblContents
            // 
            this.lblContents.Location = new System.Drawing.Point(9, 57);
            this.lblContents.Name = "lblContents";
            this.lblContents.Size = new System.Drawing.Size(90, 12);
            this.lblContents.TabIndex = 17;
            this.lblContents.Text = "内容(&C)：";
            this.lblContents.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSendTo
            // 
            this.lblSendTo.Location = new System.Drawing.Point(9, 24);
            this.lblSendTo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSendTo.Name = "lblSendTo";
            this.lblSendTo.Size = new System.Drawing.Size(90, 12);
            this.lblSendTo.TabIndex = 14;
            this.lblSendTo.Text = "发送给(&T)：";
            this.lblSendTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmMessageSend
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(613, 285);
            this.Controls.Add(this.grbMessage);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnCancel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmMessageSend";
            this.Text = "发送信息";
            this.Load += new System.EventHandler(this.FrmMessageSend_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FrmMessageSend_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.FrmMessageSend_DragOver);
            this.grbMessage.ResumeLayout(false);
            this.grbMessage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColorDialog colorDialogMsg;
        private System.Windows.Forms.FontDialog fontDialogMsg;
        private System.Windows.Forms.GroupBox grbMessage;
        private System.Windows.Forms.Button btnSelectFack;
        private System.Windows.Forms.Button btnMsgFont;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Label lblContentReq;
        private UCUserSelect ucUser;
        private System.Windows.Forms.Label lblStaffReq;
        private System.Windows.Forms.TextBox txtContents;
        private System.Windows.Forms.Label lblContents;
        private System.Windows.Forms.Label lblSendTo;
    }
}