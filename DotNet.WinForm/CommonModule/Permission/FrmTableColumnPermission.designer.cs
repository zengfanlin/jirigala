namespace DotNet.WinForm
{
    partial class FrmTableColumnPermission
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdTableColumns = new System.Windows.Forms.DataGridView();
            this.colTableCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPublic = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colAccess = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColEdit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDeney = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblUserOrRole = new System.Windows.Forms.Label();
            this.txtUserOrRole = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cklbTable = new System.Windows.Forms.CheckedListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdTableColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdTableColumns
            // 
            this.grdTableColumns.AllowUserToAddRows = false;
            this.grdTableColumns.AllowUserToDeleteRows = false;
            this.grdTableColumns.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdTableColumns.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdTableColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTableColumns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTableCode,
            this.colPublic,
            this.colAccess,
            this.ColEdit,
            this.colDeney});
            this.grdTableColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTableColumns.Location = new System.Drawing.Point(0, 0);
            this.grdTableColumns.MultiSelect = false;
            this.grdTableColumns.Name = "grdTableColumns";
            this.grdTableColumns.RowTemplate.Height = 23;
            this.grdTableColumns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTableColumns.Size = new System.Drawing.Size(523, 427);
            this.grdTableColumns.TabIndex = 0;
            this.grdTableColumns.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdTableColumns_CellValueChanged);
            // 
            // colTableCode
            // 
            this.colTableCode.DataPropertyName = "ColumnName";
            this.colTableCode.Frozen = true;
            this.colTableCode.HeaderText = "字段";
            this.colTableCode.MaxInputLength = 200;
            this.colTableCode.Name = "colTableCode";
            this.colTableCode.ReadOnly = true;
            this.colTableCode.Width = 150;
            // 
            // colPublic
            // 
            this.colPublic.DataPropertyName = "IsPublic";
            this.colPublic.Frozen = true;
            this.colPublic.HeaderText = "公开";
            this.colPublic.Name = "colPublic";
            this.colPublic.ReadOnly = true;
            this.colPublic.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPublic.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colPublic.Width = 50;
            // 
            // colAccess
            // 
            this.colAccess.DataPropertyName = "ColumnAccess";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.NullValue = false;
            this.colAccess.DefaultCellStyle = dataGridViewCellStyle2;
            this.colAccess.FalseValue = "0";
            this.colAccess.HeaderText = "访问列权限";
            this.colAccess.Name = "colAccess";
            this.colAccess.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAccess.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colAccess.ToolTipText = "Column.Access";
            this.colAccess.TrueValue = "1";
            this.colAccess.Width = 80;
            // 
            // ColEdit
            // 
            this.ColEdit.DataPropertyName = "ColumnEdit";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.NullValue = false;
            this.ColEdit.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColEdit.FalseValue = "0";
            this.ColEdit.HeaderText = "编辑列权限";
            this.ColEdit.Name = "ColEdit";
            this.ColEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColEdit.ToolTipText = "Column.Edit";
            this.ColEdit.TrueValue = "1";
            this.ColEdit.Width = 80;
            // 
            // colDeney
            // 
            this.colDeney.DataPropertyName = "ColumnDeney";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.NullValue = false;
            this.colDeney.DefaultCellStyle = dataGridViewCellStyle4;
            this.colDeney.FalseValue = "0";
            this.colDeney.HeaderText = "拒绝列访问";
            this.colDeney.Name = "colDeney";
            this.colDeney.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDeney.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDeney.ToolTipText = "Column.Deney";
            this.colDeney.TrueValue = "1";
            this.colDeney.Width = 80;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(684, 471);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblUserOrRole
            // 
            this.lblUserOrRole.Location = new System.Drawing.Point(11, 16);
            this.lblUserOrRole.Name = "lblUserOrRole";
            this.lblUserOrRole.Size = new System.Drawing.Size(121, 12);
            this.lblUserOrRole.TabIndex = 0;
            this.lblUserOrRole.Text = "用户/角色(&R)：";
            this.lblUserOrRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUserOrRole
            // 
            this.txtUserOrRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserOrRole.Location = new System.Drawing.Point(135, 12);
            this.txtUserOrRole.MaxLength = 50;
            this.txtUserOrRole.Name = "txtUserOrRole";
            this.txtUserOrRole.ReadOnly = true;
            this.txtUserOrRole.Size = new System.Drawing.Size(373, 21);
            this.txtUserOrRole.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(5, 39);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cklbTable);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grdTableColumns);
            this.splitContainer1.Size = new System.Drawing.Size(755, 427);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.TabIndex = 9;
            // 
            // cklbTable
            // 
            this.cklbTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cklbTable.FormattingEnabled = true;
            this.cklbTable.Location = new System.Drawing.Point(0, 0);
            this.cklbTable.Name = "cklbTable";
            this.cklbTable.Size = new System.Drawing.Size(228, 427);
            this.cklbTable.TabIndex = 0;
            this.cklbTable.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cklbTable_ItemCheck);
            this.cklbTable.SelectedIndexChanged += new System.EventHandler(this.cklbTable_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(598, 471);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(481, 471);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(111, 23);
            this.btnExport.TabIndex = 17;
            this.btnExport.Text = "导出Excel...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // FrmTableColumnPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(763, 500);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.txtUserOrRole);
            this.Controls.Add(this.lblUserOrRole);
            this.Controls.Add(this.btnCancel);
            this.Name = "FrmTableColumnPermission";
            this.Text = "字段权限设置";
            ((System.ComponentModel.ISupportInitialize)(this.grdTableColumns)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdTableColumns;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblUserOrRole;
        private System.Windows.Forms.TextBox txtUserOrRole;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckedListBox cklbTable;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTableCode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colPublic;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAccess;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColEdit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colDeney;
        private System.Windows.Forms.Button btnExport;
    }
}