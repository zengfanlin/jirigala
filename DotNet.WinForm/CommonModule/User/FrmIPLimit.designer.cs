namespace DotNet.WinForm
{
    partial class FrmIpLimit
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.tab1 = new System.Windows.Forms.TabControl();
            this.tpIP = new System.Windows.Forms.TabPage();
            this.cklstIp = new System.Windows.Forms.CheckedListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tcMac = new System.Windows.Forms.TabControl();
            this.tpMac = new System.Windows.Forms.TabPage();
            this.cklstMac = new System.Windows.Forms.CheckedListBox();
            this.lblCodeReq = new System.Windows.Forms.Label();
            this.txtMacAddress = new System.Windows.Forms.TextBox();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.lblMACAddress = new System.Windows.Forms.Label();
            this.lblIPAddress = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnInvertSelect = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.ucUser = new DotNet.WinForm.UCUserSelect();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblIPFormat = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMACFormat = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.tab1.SuspendLayout();
            this.tpIP.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tcMac.SuspendLayout();
            this.tpMac.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tab1);
            this.panel2.Location = new System.Drawing.Point(12, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(255, 362);
            this.panel2.TabIndex = 1;
            // 
            // tab1
            // 
            this.tab1.Controls.Add(this.tpIP);
            this.tab1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tab1.Location = new System.Drawing.Point(0, 0);
            this.tab1.Name = "tab1";
            this.tab1.SelectedIndex = 0;
            this.tab1.Size = new System.Drawing.Size(245, 362);
            this.tab1.TabIndex = 9;
            // 
            // tpIP
            // 
            this.tpIP.Controls.Add(this.cklstIp);
            this.tpIP.Location = new System.Drawing.Point(4, 22);
            this.tpIP.Name = "tpIP";
            this.tpIP.Padding = new System.Windows.Forms.Padding(3);
            this.tpIP.Size = new System.Drawing.Size(237, 336);
            this.tpIP.TabIndex = 0;
            this.tpIP.Text = "IP地址";
            this.tpIP.UseVisualStyleBackColor = true;
            // 
            // cklstIp
            // 
            this.cklstIp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cklstIp.FormattingEnabled = true;
            this.cklstIp.Location = new System.Drawing.Point(3, 3);
            this.cklstIp.Name = "cklstIp";
            this.cklstIp.Size = new System.Drawing.Size(231, 330);
            this.cklstIp.TabIndex = 0;
            this.cklstIp.Click += new System.EventHandler(this.cklstIp_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tcMac);
            this.panel3.Location = new System.Drawing.Point(263, 41);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(255, 362);
            this.panel3.TabIndex = 2;
            // 
            // tcMac
            // 
            this.tcMac.Controls.Add(this.tpMac);
            this.tcMac.Dock = System.Windows.Forms.DockStyle.Left;
            this.tcMac.Location = new System.Drawing.Point(0, 0);
            this.tcMac.Name = "tcMac";
            this.tcMac.SelectedIndex = 0;
            this.tcMac.Size = new System.Drawing.Size(252, 362);
            this.tcMac.TabIndex = 9;
            // 
            // tpMac
            // 
            this.tpMac.Controls.Add(this.cklstMac);
            this.tpMac.Location = new System.Drawing.Point(4, 22);
            this.tpMac.Name = "tpMac";
            this.tpMac.Padding = new System.Windows.Forms.Padding(3);
            this.tpMac.Size = new System.Drawing.Size(244, 336);
            this.tpMac.TabIndex = 0;
            this.tpMac.Text = "MAC地址";
            this.tpMac.UseVisualStyleBackColor = true;
            // 
            // cklstMac
            // 
            this.cklstMac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cklstMac.FormattingEnabled = true;
            this.cklstMac.Location = new System.Drawing.Point(3, 3);
            this.cklstMac.Name = "cklstMac";
            this.cklstMac.Size = new System.Drawing.Size(238, 330);
            this.cklstMac.TabIndex = 1;
            this.cklstMac.Click += new System.EventHandler(this.cklstMac_Click);
            // 
            // lblCodeReq
            // 
            this.lblCodeReq.AutoSize = true;
            this.lblCodeReq.ForeColor = System.Drawing.Color.Red;
            this.lblCodeReq.Location = new System.Drawing.Point(259, 423);
            this.lblCodeReq.Name = "lblCodeReq";
            this.lblCodeReq.Size = new System.Drawing.Size(11, 12);
            this.lblCodeReq.TabIndex = 9;
            this.lblCodeReq.Text = "*";
            // 
            // txtMacAddress
            // 
            this.txtMacAddress.Location = new System.Drawing.Point(350, 418);
            this.txtMacAddress.MaxLength = 50;
            this.txtMacAddress.Name = "txtMacAddress";
            this.txtMacAddress.Size = new System.Drawing.Size(168, 21);
            this.txtMacAddress.TabIndex = 11;
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(87, 419);
            this.txtIPAddress.MaxLength = 100;
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(163, 21);
            this.txtIPAddress.TabIndex = 8;
            // 
            // lblMACAddress
            // 
            this.lblMACAddress.Location = new System.Drawing.Point(237, 423);
            this.lblMACAddress.Name = "lblMACAddress";
            this.lblMACAddress.Size = new System.Drawing.Size(112, 12);
            this.lblMACAddress.TabIndex = 10;
            this.lblMACAddress.Text = "MAC地址(&M)：";
            this.lblMACAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIPAddress
            // 
            this.lblIPAddress.Location = new System.Drawing.Point(-13, 422);
            this.lblIPAddress.Name = "lblIPAddress";
            this.lblIPAddress.Size = new System.Drawing.Size(101, 12);
            this.lblIPAddress.TabIndex = 7;
            this.lblIPAddress.Text = "IP地址(&P)：";
            this.lblIPAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(360, 493);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "删除(&R)";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnInvertSelect
            // 
            this.btnInvertSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvertSelect.Location = new System.Drawing.Point(90, 493);
            this.btnInvertSelect.Name = "btnInvertSelect";
            this.btnInvertSelect.Size = new System.Drawing.Size(78, 23);
            this.btnInvertSelect.TabIndex = 14;
            this.btnInvertSelect.Text = "反选";
            this.btnInvertSelect.UseVisualStyleBackColor = true;
            this.btnInvertSelect.Click += new System.EventHandler(this.btnInvertSelect_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(439, 493);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Location = new System.Drawing.Point(8, 493);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(78, 23);
            this.btnSelectAll.TabIndex = 13;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.Location = new System.Drawing.Point(280, 493);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.Text = "添加(&D)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ucUser
            // 
            this.ucUser.AllowNull = false;
            this.ucUser.AllowSelect = false;
            this.ucUser.Location = new System.Drawing.Point(122, 9);
            this.ucUser.MultiSelect = false;
            this.ucUser.Name = "ucUser";
            this.ucUser.OpenId = "";
            this.ucUser.PermissionItemScopeCode = "";
            this.ucUser.RemoveIds = null;
            this.ucUser.SelectedFullName = "";
            this.ucUser.SelectedId = "";
            this.ucUser.SelectedIds = null;
            this.ucUser.SetSelectIds = null;
            this.ucUser.Size = new System.Drawing.Size(241, 22);
            this.ucUser.TabIndex = 19;
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(9, 12);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(107, 12);
            this.lblUser.TabIndex = 18;
            this.lblUser.Text = "用户(&U)：";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIPFormat
            // 
            this.lblIPFormat.Location = new System.Drawing.Point(-13, 444);
            this.lblIPFormat.Name = "lblIPFormat";
            this.lblIPFormat.Size = new System.Drawing.Size(101, 12);
            this.lblIPFormat.TabIndex = 20;
            this.lblIPFormat.Text = "IP地址格式：";
            this.lblIPFormat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(80, 445);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "192.168.0.1";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(67, 461);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "192.168.0.1-192.168.0.10";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(82, 476);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 12);
            this.label4.TabIndex = 23;
            this.label4.Text = "192.168.0.*";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMACFormat
            // 
            this.lblMACFormat.Location = new System.Drawing.Point(249, 445);
            this.lblMACFormat.Name = "lblMACFormat";
            this.lblMACFormat.Size = new System.Drawing.Size(101, 12);
            this.lblMACFormat.TabIndex = 24;
            this.lblMACFormat.Text = "MAC地址格式：";
            this.lblMACFormat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(342, 445);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "00-16-36-3F-95-98";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmIpLimit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 518);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblMACFormat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblIPFormat);
            this.Controls.Add(this.ucUser);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnInvertSelect);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.lblCodeReq);
            this.Controls.Add(this.txtMacAddress);
            this.Controls.Add(this.txtIPAddress);
            this.Controls.Add(this.lblMACAddress);
            this.Controls.Add(this.lblIPAddress);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "FrmIpLimit";
            this.Text = "IP访问限制";
            this.panel2.ResumeLayout(false);
            this.tab1.ResumeLayout(false);
            this.tpIP.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tcMac.ResumeLayout(false);
            this.tpMac.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabControl tab1;
        private System.Windows.Forms.TabPage tpIP;
        private System.Windows.Forms.TabControl tcMac;
        private System.Windows.Forms.TabPage tpMac;
        private System.Windows.Forms.Label lblCodeReq;
        private System.Windows.Forms.TextBox txtMacAddress;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label lblMACAddress;
        private System.Windows.Forms.Label lblIPAddress;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnInvertSelect;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.CheckedListBox cklstIp;
        private System.Windows.Forms.CheckedListBox cklstMac;
        private DotNet.WinForm.UCUserSelect ucUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblIPFormat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMACFormat;
        private System.Windows.Forms.Label label6;

    }
}