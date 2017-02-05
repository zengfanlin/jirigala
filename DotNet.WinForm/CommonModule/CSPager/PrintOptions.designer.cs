namespace DotNet.WinForm
{
    partial class PrintOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintOptions));
            this.grpPrintOptions = new System.Windows.Forms.GroupBox();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.chkFitToPageWidth = new System.Windows.Forms.CheckBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.gboxRowsToPrint = new System.Windows.Forms.GroupBox();
            this.rdoSelectedRows = new System.Windows.Forms.RadioButton();
            this.rdoAllRows = new System.Windows.Forms.RadioButton();
            this.lblColumnsToPrint = new System.Windows.Forms.Label();
            this.chklst = new System.Windows.Forms.CheckedListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpPrintOptions.SuspendLayout();
            this.gboxRowsToPrint.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPrintOptions
            // 
            this.grpPrintOptions.Controls.Add(this.chkSelectAll);
            this.grpPrintOptions.Controls.Add(this.chkFitToPageWidth);
            this.grpPrintOptions.Controls.Add(this.lblTitle);
            this.grpPrintOptions.Controls.Add(this.txtTitle);
            this.grpPrintOptions.Controls.Add(this.gboxRowsToPrint);
            this.grpPrintOptions.Controls.Add(this.lblColumnsToPrint);
            this.grpPrintOptions.Controls.Add(this.chklst);
            this.grpPrintOptions.Location = new System.Drawing.Point(13, 13);
            this.grpPrintOptions.Name = "grpPrintOptions";
            this.grpPrintOptions.Size = new System.Drawing.Size(375, 286);
            this.grpPrintOptions.TabIndex = 0;
            this.grpPrintOptions.TabStop = false;
            this.grpPrintOptions.Text = "打印选项";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Checked = true;
            this.chkSelectAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSelectAll.Location = new System.Drawing.Point(133, 31);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(48, 16);
            this.chkSelectAll.TabIndex = 31;
            this.chkSelectAll.Text = "全选";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            // 
            // chkFitToPageWidth
            // 
            this.chkFitToPageWidth.AutoSize = true;
            this.chkFitToPageWidth.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFitToPageWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkFitToPageWidth.Font = new System.Drawing.Font("新宋体", 9F);
            this.chkFitToPageWidth.Location = new System.Drawing.Point(190, 107);
            this.chkFitToPageWidth.Name = "chkFitToPageWidth";
            this.chkFitToPageWidth.Size = new System.Drawing.Size(102, 17);
            this.chkFitToPageWidth.TabIndex = 30;
            this.chkFitToPageWidth.Text = "适应页面宽度";
            this.chkFitToPageWidth.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("新宋体", 9F);
            this.lblTitle.Location = new System.Drawing.Point(187, 147);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(53, 12);
            this.lblTitle.TabIndex = 29;
            this.lblTitle.Text = "页面抬头";
            // 
            // txtTitle
            // 
            this.txtTitle.AcceptsReturn = true;
            this.txtTitle.Font = new System.Drawing.Font("新宋体", 9F);
            this.txtTitle.Location = new System.Drawing.Point(187, 162);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTitle.Size = new System.Drawing.Size(176, 71);
            this.txtTitle.TabIndex = 28;
            // 
            // gboxRowsToPrint
            // 
            this.gboxRowsToPrint.Controls.Add(this.rdoSelectedRows);
            this.gboxRowsToPrint.Controls.Add(this.rdoAllRows);
            this.gboxRowsToPrint.Font = new System.Drawing.Font("新宋体", 9F);
            this.gboxRowsToPrint.Location = new System.Drawing.Point(187, 44);
            this.gboxRowsToPrint.Name = "gboxRowsToPrint";
            this.gboxRowsToPrint.Size = new System.Drawing.Size(173, 39);
            this.gboxRowsToPrint.TabIndex = 27;
            this.gboxRowsToPrint.TabStop = false;
            this.gboxRowsToPrint.Text = "打印方式";
            // 
            // rdoSelectedRows
            // 
            this.rdoSelectedRows.AutoSize = true;
            this.rdoSelectedRows.Font = new System.Drawing.Font("新宋体", 9F);
            this.rdoSelectedRows.Location = new System.Drawing.Point(91, 18);
            this.rdoSelectedRows.Name = "rdoSelectedRows";
            this.rdoSelectedRows.Size = new System.Drawing.Size(59, 16);
            this.rdoSelectedRows.TabIndex = 1;
            this.rdoSelectedRows.TabStop = true;
            this.rdoSelectedRows.Text = "选中行";
            this.rdoSelectedRows.UseVisualStyleBackColor = true;
            // 
            // rdoAllRows
            // 
            this.rdoAllRows.AutoSize = true;
            this.rdoAllRows.Font = new System.Drawing.Font("新宋体", 9F);
            this.rdoAllRows.Location = new System.Drawing.Point(9, 18);
            this.rdoAllRows.Name = "rdoAllRows";
            this.rdoAllRows.Size = new System.Drawing.Size(59, 16);
            this.rdoAllRows.TabIndex = 0;
            this.rdoAllRows.TabStop = true;
            this.rdoAllRows.Text = "全部行";
            this.rdoAllRows.UseVisualStyleBackColor = true;
            // 
            // lblColumnsToPrint
            // 
            this.lblColumnsToPrint.AutoSize = true;
            this.lblColumnsToPrint.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnsToPrint.Location = new System.Drawing.Point(11, 31);
            this.lblColumnsToPrint.Name = "lblColumnsToPrint";
            this.lblColumnsToPrint.Size = new System.Drawing.Size(65, 12);
            this.lblColumnsToPrint.TabIndex = 26;
            this.lblColumnsToPrint.Text = "待打印的列";
            // 
            // chklst
            // 
            this.chklst.CheckOnClick = true;
            this.chklst.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chklst.FormattingEnabled = true;
            this.chklst.Location = new System.Drawing.Point(11, 49);
            this.chklst.Name = "chklst";
            this.chklst.Size = new System.Drawing.Size(170, 212);
            this.chklst.TabIndex = 23;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.Control;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Font = new System.Drawing.Font("新宋体", 9F);
            this.btnOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(253, 313);
            this.btnOK.Name = "btnOK";
            this.btnOK.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnOK.Size = new System.Drawing.Size(63, 23);
            this.btnOK.TabIndex = 26;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Font = new System.Drawing.Font("新宋体", 9F);
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(325, 313);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCancel.Size = new System.Drawing.Size(63, 23);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // PrintOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 355);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpPrintOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PrintOptions";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "打印选项";
            this.Load += new System.EventHandler(this.PrintOtions_Load);
            this.grpPrintOptions.ResumeLayout(false);
            this.grpPrintOptions.PerformLayout();
            this.gboxRowsToPrint.ResumeLayout(false);
            this.gboxRowsToPrint.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPrintOptions;
        private System.Windows.Forms.CheckBox chkSelectAll;
        internal System.Windows.Forms.CheckBox chkFitToPageWidth;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.TextBox txtTitle;
        internal System.Windows.Forms.GroupBox gboxRowsToPrint;
        internal System.Windows.Forms.RadioButton rdoSelectedRows;
        internal System.Windows.Forms.RadioButton rdoAllRows;
        internal System.Windows.Forms.Label lblColumnsToPrint;
        internal System.Windows.Forms.CheckedListBox chklst;
        protected System.Windows.Forms.Button btnOK;
        protected System.Windows.Forms.Button btnCancel;


    }
}