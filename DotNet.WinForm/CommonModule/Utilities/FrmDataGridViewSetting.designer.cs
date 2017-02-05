namespace DotNet.WinForm
{
    partial class FrmDataGridViewSetting
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
            this.grbSetting = new System.Windows.Forms.GroupBox();
            this.grdSetting = new System.Windows.Forms.DataGridView();
            this.colColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeaderText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisplayIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVisible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colFrozen = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSetBottom = new System.Windows.Forms.Button();
            this.btnSetDown = new System.Windows.Forms.Button();
            this.btnSetUp = new System.Windows.Forms.Button();
            this.btnSetTop = new System.Windows.Forms.Button();
            this.grbSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSetting)).BeginInit();
            this.SuspendLayout();
            // 
            // grbSetting
            // 
            this.grbSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbSetting.Controls.Add(this.grdSetting);
            this.grbSetting.Location = new System.Drawing.Point(2, 12);
            this.grbSetting.Name = "grbSetting";
            this.grbSetting.Size = new System.Drawing.Size(451, 388);
            this.grbSetting.TabIndex = 0;
            this.grbSetting.TabStop = false;
            this.grbSetting.Text = "设置";
            // 
            // grdSetting
            // 
            this.grdSetting.AllowUserToAddRows = false;
            this.grdSetting.AllowUserToDeleteRows = false;
            this.grdSetting.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSetting.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSetting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colColumnName,
            this.colHeaderText,
            this.colDisplayIndex,
            this.colWidth,
            this.colVisible,
            this.colFrozen});
            this.grdSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSetting.Location = new System.Drawing.Point(3, 17);
            this.grdSetting.MultiSelect = false;
            this.grdSetting.Name = "grdSetting";
            this.grdSetting.RowTemplate.Height = 23;
            this.grdSetting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSetting.Size = new System.Drawing.Size(445, 368);
            this.grdSetting.TabIndex = 0;
            this.grdSetting.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSetting_RowEnter);
            // 
            // ColumnName
            // 
            this.colColumnName.DataPropertyName = "ColumnName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.colColumnName.DefaultCellStyle = dataGridViewCellStyle2;
            this.colColumnName.HeaderText = "列名";
            this.colColumnName.Name = "ColumnName";
            this.colColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colColumnName.Visible = false;
            // 
            // HeaderText
            // 
            this.colHeaderText.DataPropertyName = "HeaderText";
            this.colHeaderText.HeaderText = "列名";
            this.colHeaderText.Name = "HeaderText";
            this.colHeaderText.ReadOnly = true;
            this.colHeaderText.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colHeaderText.Width = 120;
            // 
            // DisplayIndex
            // 
            this.colDisplayIndex.DataPropertyName = "DisplayIndex";
            this.colDisplayIndex.HeaderText = "位置";
            this.colDisplayIndex.Name = "DisplayIndex";
            this.colDisplayIndex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDisplayIndex.Visible = false;
            // 
            // Width
            // 
            this.colWidth.DataPropertyName = "Width";
            this.colWidth.FillWeight = 120F;
            this.colWidth.HeaderText = "宽度";
            this.colWidth.MaxInputLength = 200;
            this.colWidth.Name = "Width";
            this.colWidth.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colWidth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colWidth.Width = 120;
            // 
            // Visible
            // 
            this.colVisible.DataPropertyName = "Visible";
            this.colVisible.FalseValue = "False";
            this.colVisible.HeaderText = "显示";
            this.colVisible.Name = "Visible";
            this.colVisible.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colVisible.TrueValue = "True";
            this.colVisible.Width = 80;
            // 
            // Frozen
            // 
            this.colFrozen.DataPropertyName = "Frozen";
            this.colFrozen.FalseValue = "False";
            this.colFrozen.HeaderText = "冻结";
            this.colFrozen.Name = "Frozen";
            this.colFrozen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFrozen.TrueValue = "True";
            this.colFrozen.Width = 80;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(288, 406);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "确定";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(366, 406);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSetBottom
            // 
            this.btnSetBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetBottom.Location = new System.Drawing.Point(81, 406);
            this.btnSetBottom.Name = "btnSetBottom";
            this.btnSetBottom.Size = new System.Drawing.Size(23, 23);
            this.btnSetBottom.TabIndex = 10;
            this.btnSetBottom.Text = "▼";
            this.btnSetBottom.UseVisualStyleBackColor = true;
            this.btnSetBottom.Click += new System.EventHandler(this.btnSetBottom_Click);
            // 
            // btnSetDown
            // 
            this.btnSetDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetDown.Location = new System.Drawing.Point(56, 406);
            this.btnSetDown.Name = "btnSetDown";
            this.btnSetDown.Size = new System.Drawing.Size(23, 23);
            this.btnSetDown.TabIndex = 9;
            this.btnSetDown.Text = "▽";
            this.btnSetDown.UseVisualStyleBackColor = true;
            this.btnSetDown.Click += new System.EventHandler(this.btnSetDown_Click);
            // 
            // btnSetUp
            // 
            this.btnSetUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetUp.Location = new System.Drawing.Point(31, 406);
            this.btnSetUp.Name = "btnSetUp";
            this.btnSetUp.Size = new System.Drawing.Size(23, 23);
            this.btnSetUp.TabIndex = 8;
            this.btnSetUp.Text = "△";
            this.btnSetUp.UseVisualStyleBackColor = true;
            this.btnSetUp.Click += new System.EventHandler(this.btnSetUp_Click);
            // 
            // btnSetTop
            // 
            this.btnSetTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetTop.Location = new System.Drawing.Point(6, 406);
            this.btnSetTop.Name = "btnSetTop";
            this.btnSetTop.Size = new System.Drawing.Size(23, 23);
            this.btnSetTop.TabIndex = 7;
            this.btnSetTop.Text = "▲";
            this.btnSetTop.UseVisualStyleBackColor = true;
            this.btnSetTop.Click += new System.EventHandler(this.btnSetTop_Click);
            // 
            // FrmDataGridViewSetting
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(453, 432);
            this.Controls.Add(this.btnSetBottom);
            this.Controls.Add(this.btnSetDown);
            this.Controls.Add(this.btnSetUp);
            this.Controls.Add(this.btnSetTop);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grbSetting);
            this.Name = "FrmDataGridViewSetting";
            this.Text = "数据列设置";
            this.grbSetting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSetting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbSetting;
        private System.Windows.Forms.DataGridView grdSetting;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSetBottom;
        private System.Windows.Forms.Button btnSetDown;
        private System.Windows.Forms.Button btnSetUp;
        private System.Windows.Forms.Button btnSetTop;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeaderText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDisplayIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWidth;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colVisible;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colFrozen;
    }
}