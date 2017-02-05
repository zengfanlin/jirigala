namespace DotNet.WinForm
{
    partial class WinGridView
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Print = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Export = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(540, 212);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowLeave);
            this.dataGridView1.DataSourceChanged += new System.EventHandler(this.dataGridView1_DataSourceChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.menu_Add,
            this.menu_Edit,
            this.menu_Delete,
            this.menu_Refresh,
            this.menu_Print,
            this.menu_Export});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 164);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // menu_Add
            // 
            this.menu_Add.Name = "menu_Add";
            this.menu_Add.Size = new System.Drawing.Size(152, 22);
            this.menu_Add.Text = "新建(&N)";
            this.menu_Add.Click += new System.EventHandler(this.menu_Add_Click);
            // 
            // menu_Edit
            // 
            this.menu_Edit.Name = "menu_Edit";
            this.menu_Edit.Size = new System.Drawing.Size(152, 22);
            this.menu_Edit.Text = "编辑选定项(&E)";
            this.menu_Edit.Click += new System.EventHandler(this.menu_Edit_Click);
            // 
            // menu_Delete
            // 
            this.menu_Delete.Name = "menu_Delete";
            this.menu_Delete.Size = new System.Drawing.Size(152, 22);
            this.menu_Delete.Text = "删除选定项(&D)";
            this.menu_Delete.Click += new System.EventHandler(this.menu_Delete_Click);
            // 
            // menu_Refresh
            // 
            this.menu_Refresh.Name = "menu_Refresh";
            this.menu_Refresh.Size = new System.Drawing.Size(152, 22);
            this.menu_Refresh.Text = "刷新列表(&R)";
            this.menu_Refresh.Click += new System.EventHandler(this.menu_Refresh_Click);
            // 
            // menu_Print
            // 
            this.menu_Print.Name = "menu_Print";
            this.menu_Print.Size = new System.Drawing.Size(152, 22);
            this.menu_Print.Text = "打印列表(&P)";
            this.menu_Print.Click += new System.EventHandler(this.menu_Print_Click);
            // 
            // menu_Export
            // 
            this.menu_Export.Name = "menu_Export";
            this.menu_Export.Size = new System.Drawing.Size(152, 22);
            this.menu_Export.Text = "导出数据(&E)";
            this.menu_Export.Click += new System.EventHandler(this.menu_Export_Click);
            // 
            // WinGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.MinimumSize = new System.Drawing.Size(540, 0);
            this.Name = "WinGridView";
            this.Size = new System.Drawing.Size(540, 212);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem menu_Delete;
        private System.Windows.Forms.ToolStripMenuItem menu_Refresh;
        private System.Windows.Forms.ToolStripMenuItem menu_Print;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_Edit;
        private System.Windows.Forms.ToolStripMenuItem menu_Add;
        private System.Windows.Forms.ToolStripMenuItem menu_Export;
    }
}
