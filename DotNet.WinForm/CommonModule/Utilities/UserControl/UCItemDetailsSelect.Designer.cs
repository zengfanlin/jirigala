namespace DotNet.WinForm
{
    partial class UCItemDetailsSelect
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
            this.pnlItemDetail = new System.Windows.Forms.Panel();
            this.cmbItemDetail = new System.Windows.Forms.ComboBox();
            this.pnlSetNull = new System.Windows.Forms.Panel();
            this.btnSetNull = new System.Windows.Forms.Button();
            this.pnlAdmin = new System.Windows.Forms.Panel();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.pnlItemDetail.SuspendLayout();
            this.pnlSetNull.SuspendLayout();
            this.pnlAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlItemDetail
            // 
            this.pnlItemDetail.Controls.Add(this.cmbItemDetail);
            this.pnlItemDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlItemDetail.Location = new System.Drawing.Point(0, 0);
            this.pnlItemDetail.Name = "pnlItemDetail";
            this.pnlItemDetail.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.pnlItemDetail.Size = new System.Drawing.Size(144, 22);
            this.pnlItemDetail.TabIndex = 1;
            // 
            // cmbItemDetail
            // 
            this.cmbItemDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbItemDetail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemDetail.Location = new System.Drawing.Point(0, 0);
            this.cmbItemDetail.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbItemDetail.Name = "cmbItemDetail";
            this.cmbItemDetail.Size = new System.Drawing.Size(143, 20);
            this.cmbItemDetail.TabIndex = 1;
            this.cmbItemDetail.SelectedIndexChanged += new System.EventHandler(this.cmbItemDetail_SelectedIndexChanged);
            // 
            // pnlSetNull
            // 
            this.pnlSetNull.Controls.Add(this.btnSetNull);
            this.pnlSetNull.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSetNull.Location = new System.Drawing.Point(204, 0);
            this.pnlSetNull.Name = "pnlSetNull";
            this.pnlSetNull.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.pnlSetNull.Size = new System.Drawing.Size(50, 22);
            this.pnlSetNull.TabIndex = 3;
            // 
            // btnSetNull
            // 
            this.btnSetNull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSetNull.Location = new System.Drawing.Point(1, 0);
            this.btnSetNull.Name = "btnSetNull";
            this.btnSetNull.Size = new System.Drawing.Size(49, 22);
            this.btnSetNull.TabIndex = 1;
            this.btnSetNull.Text = "置空";
            this.btnSetNull.UseVisualStyleBackColor = true;
            this.btnSetNull.Click += new System.EventHandler(this.btnSetNull_Click);
            // 
            // pnlAdmin
            // 
            this.pnlAdmin.Controls.Add(this.btnAdmin);
            this.pnlAdmin.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlAdmin.Location = new System.Drawing.Point(144, 0);
            this.pnlAdmin.Name = "pnlAdmin";
            this.pnlAdmin.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.pnlAdmin.Size = new System.Drawing.Size(60, 22);
            this.pnlAdmin.TabIndex = 2;
            // 
            // btnAdmin
            // 
            this.btnAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdmin.Location = new System.Drawing.Point(1, 0);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(58, 22);
            this.btnAdmin.TabIndex = 1;
            this.btnAdmin.Text = "管理...";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // UCItemDetailsSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlItemDetail);
            this.Controls.Add(this.pnlAdmin);
            this.Controls.Add(this.pnlSetNull);
            this.Name = "UCItemDetailsSelect";
            this.Size = new System.Drawing.Size(254, 22);
            this.pnlItemDetail.ResumeLayout(false);
            this.pnlSetNull.ResumeLayout(false);
            this.pnlAdmin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlItemDetail;
        private System.Windows.Forms.Panel pnlSetNull;
        private System.Windows.Forms.Button btnSetNull;
        private System.Windows.Forms.Panel pnlAdmin;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.ComboBox cmbItemDetail;
    }
}