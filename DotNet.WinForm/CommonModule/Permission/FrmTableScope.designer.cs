namespace DotNet.WinForm
{
    partial class FrmTableScope
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdTable = new System.Windows.Forms.DataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colTableCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPermissionConstraint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInvertSelect = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDeleteCondition = new System.Windows.Forms.Button();
            this.btnSetCondition = new System.Windows.Forms.Button();
            this.lblUserOrRole = new System.Windows.Forms.Label();
            this.txtUserOrRole = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdTable)).BeginInit();
            this.SuspendLayout();
            // 
            // grdTable
            // 
            this.grdTable.AllowUserToAddRows = false;
            this.grdTable.AllowUserToDeleteRows = false;
            this.grdTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTable.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colTableCode,
            this.colTableName,
            this.colPermissionConstraint});
            this.grdTable.Location = new System.Drawing.Point(5, 39);
            this.grdTable.MultiSelect = false;
            this.grdTable.Name = "grdTable";
            this.grdTable.RowTemplate.Height = 23;
            this.grdTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTable.Size = new System.Drawing.Size(872, 402);
            this.grdTable.TabIndex = 2;
            this.grdTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdTable_CellDoubleClick);
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "Selected";
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Width = 50;
            // 
            // colTableCode
            // 
            this.colTableCode.DataPropertyName = "TableCode";
            this.colTableCode.HeaderText = "表";
            this.colTableCode.MaxInputLength = 200;
            this.colTableCode.Name = "colTableCode";
            this.colTableCode.ReadOnly = true;
            this.colTableCode.Width = 150;
            // 
            // colTableName
            // 
            this.colTableName.DataPropertyName = "TableName";
            this.colTableName.HeaderText = "名称";
            this.colTableName.MaxInputLength = 200;
            this.colTableName.Name = "colTableName";
            this.colTableName.ReadOnly = true;
            this.colTableName.Width = 200;
            // 
            // colPermissionConstraint
            // 
            this.colPermissionConstraint.DataPropertyName = "PermissionConstraint";
            this.colPermissionConstraint.HeaderText = "约束条件";
            this.colPermissionConstraint.MaxInputLength = 200;
            this.colPermissionConstraint.Name = "colPermissionConstraint";
            this.colPermissionConstraint.ReadOnly = true;
            this.colPermissionConstraint.Width = 400;
            // 
            // btnInvertSelect
            // 
            this.btnInvertSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvertSelect.Location = new System.Drawing.Point(88, 448);
            this.btnInvertSelect.Margin = new System.Windows.Forms.Padding(4);
            this.btnInvertSelect.Name = "btnInvertSelect";
            this.btnInvertSelect.Size = new System.Drawing.Size(78, 23);
            this.btnInvertSelect.TabIndex = 4;
            this.btnInvertSelect.Text = "反选";
            this.btnInvertSelect.UseVisualStyleBackColor = true;
            this.btnInvertSelect.Click += new System.EventHandler(this.btnInvertSelect_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Location = new System.Drawing.Point(3, 448);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(78, 23);
            this.btnSelectAll.TabIndex = 3;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(800, 448);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDeleteCondition
            // 
            this.btnDeleteCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteCondition.Location = new System.Drawing.Point(664, 448);
            this.btnDeleteCondition.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteCondition.Name = "btnDeleteCondition";
            this.btnDeleteCondition.Size = new System.Drawing.Size(129, 23);
            this.btnDeleteCondition.TabIndex = 6;
            this.btnDeleteCondition.Text = "删除条件表达式";
            this.btnDeleteCondition.UseVisualStyleBackColor = true;
            this.btnDeleteCondition.Click += new System.EventHandler(this.btnDeleteCondition_Click);
            // 
            // btnSetCondition
            // 
            this.btnSetCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetCondition.Location = new System.Drawing.Point(529, 448);
            this.btnSetCondition.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetCondition.Name = "btnSetCondition";
            this.btnSetCondition.Size = new System.Drawing.Size(129, 23);
            this.btnSetCondition.TabIndex = 5;
            this.btnSetCondition.Text = "设置条件表达式...";
            this.btnSetCondition.UseVisualStyleBackColor = true;
            this.btnSetCondition.Click += new System.EventHandler(this.btnSetCondition_Click);
            // 
            // lblUserOrRole
            // 
            this.lblUserOrRole.Location = new System.Drawing.Point(8, 13);
            this.lblUserOrRole.Name = "lblUserOrRole";
            this.lblUserOrRole.Size = new System.Drawing.Size(131, 12);
            this.lblUserOrRole.TabIndex = 0;
            this.lblUserOrRole.Text = "用户/角色(&R)：";
            this.lblUserOrRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUserOrRole
            // 
            this.txtUserOrRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserOrRole.Location = new System.Drawing.Point(142, 9);
            this.txtUserOrRole.MaxLength = 50;
            this.txtUserOrRole.Name = "txtUserOrRole";
            this.txtUserOrRole.ReadOnly = true;
            this.txtUserOrRole.Size = new System.Drawing.Size(357, 21);
            this.txtUserOrRole.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(764, 8);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(111, 23);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "导出Excel...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // FrmTableScope
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(885, 475);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.txtUserOrRole);
            this.Controls.Add(this.lblUserOrRole);
            this.Controls.Add(this.btnSetCondition);
            this.Controls.Add(this.btnDeleteCondition);
            this.Controls.Add(this.btnInvertSelect);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grdTable);
            this.Name = "FrmTableScope";
            this.Text = "约束条件";
            ((System.ComponentModel.ISupportInitialize)(this.grdTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdTable;
        private System.Windows.Forms.Button btnInvertSelect;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDeleteCondition;
        private System.Windows.Forms.Button btnSetCondition;
        private System.Windows.Forms.Label lblUserOrRole;
        private System.Windows.Forms.TextBox txtUserOrRole;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTableCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPermissionConstraint;
        private System.Windows.Forms.Button btnExport;
    }
}