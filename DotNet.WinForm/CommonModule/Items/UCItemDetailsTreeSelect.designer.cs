namespace DotNet.WinForm
{
    partial class UCItemDetailsTreeSelect
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

        #region 组件设计器生成的主键

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用主键编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlParent = new System.Windows.Forms.Panel();
            this.btnParent = new System.Windows.Forms.Button();
            this.pnlSelect = new System.Windows.Forms.Panel();
            this.btnSelectItemDetails = new System.Windows.Forms.Button();
            this.pnlItemDetails = new System.Windows.Forms.Panel();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.pnlParent.SuspendLayout();
            this.pnlSelect.SuspendLayout();
            this.pnlItemDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlParent
            // 
            this.pnlParent.Controls.Add(this.btnParent);
            this.pnlParent.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlParent.Location = new System.Drawing.Point(228, 0);
            this.pnlParent.Name = "pnlParent";
            this.pnlParent.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.pnlParent.Size = new System.Drawing.Size(75, 23);
            this.pnlParent.TabIndex = 3;
            // 
            // btnParent
            // 
            this.btnParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnParent.Location = new System.Drawing.Point(1, 0);
            this.btnParent.Name = "btnParent";
            this.btnParent.Size = new System.Drawing.Size(74, 23);
            this.btnParent.TabIndex = 1;
            this.btnParent.Text = "上级..";
            this.btnParent.UseVisualStyleBackColor = true;
            this.btnParent.Click += new System.EventHandler(this.btnParent_Click);
            // 
            // pnlSelect
            // 
            this.pnlSelect.Controls.Add(this.btnSelectItemDetails);
            this.pnlSelect.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSelect.Location = new System.Drawing.Point(151, 0);
            this.pnlSelect.Name = "pnlSelect";
            this.pnlSelect.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.pnlSelect.Size = new System.Drawing.Size(77, 23);
            this.pnlSelect.TabIndex = 2;
            // 
            // btnSelectItemDetails
            // 
            this.btnSelectItemDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectItemDetails.Location = new System.Drawing.Point(1, 0);
            this.btnSelectItemDetails.Name = "btnSelectItemDetails";
            this.btnSelectItemDetails.Size = new System.Drawing.Size(75, 23);
            this.btnSelectItemDetails.TabIndex = 1;
            this.btnSelectItemDetails.Text = "选择...";
            this.btnSelectItemDetails.UseVisualStyleBackColor = true;
            this.btnSelectItemDetails.Click += new System.EventHandler(this.btnSelectItemDetails_Click);
            // 
            // pnlItemDetails
            // 
            this.pnlItemDetails.Controls.Add(this.txtFullName);
            this.pnlItemDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlItemDetails.Location = new System.Drawing.Point(0, 0);
            this.pnlItemDetails.Name = "pnlItemDetails";
            this.pnlItemDetails.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.pnlItemDetails.Size = new System.Drawing.Size(151, 23);
            this.pnlItemDetails.TabIndex = 1;
            // 
            // txtFullName
            // 
            this.txtFullName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFullName.Location = new System.Drawing.Point(0, 0);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.ReadOnly = true;
            this.txtFullName.Size = new System.Drawing.Size(150, 21);
            this.txtFullName.TabIndex = 1;
            // 
            // UCItemDetailsTreeSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlItemDetails);
            this.Controls.Add(this.pnlSelect);
            this.Controls.Add(this.pnlParent);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Name = "UCItemDetailsTreeSelect";
            this.Size = new System.Drawing.Size(303, 23);
            this.pnlParent.ResumeLayout(false);
            this.pnlSelect.ResumeLayout(false);
            this.pnlItemDetails.ResumeLayout(false);
            this.pnlItemDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlParent;
        private System.Windows.Forms.Button btnParent;
        private System.Windows.Forms.Panel pnlSelect;
        private System.Windows.Forms.Button btnSelectItemDetails;
        private System.Windows.Forms.Panel pnlItemDetails;
        private System.Windows.Forms.TextBox txtFullName;
    }
}
