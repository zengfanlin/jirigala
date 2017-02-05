namespace DotNet.WinForm
{
    partial class UCTableSort
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
            this.btnSetBottom = new System.Windows.Forms.Button();
            this.btnSetDown = new System.Windows.Forms.Button();
            this.btnSetUp = new System.Windows.Forms.Button();
            this.btnSetTop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSetBottom
            // 
            this.btnSetBottom.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSetBottom.Location = new System.Drawing.Point(70, 1);
            this.btnSetBottom.Name = "btnSetBottom";
            this.btnSetBottom.Size = new System.Drawing.Size(23, 22);
            this.btnSetBottom.TabIndex = 3;
            this.btnSetBottom.Text = "▼";
            this.btnSetBottom.UseVisualStyleBackColor = true;
            this.btnSetBottom.Click += new System.EventHandler(this.btnSetBottom_Click);
            // 
            // btnSetDown
            // 
            this.btnSetDown.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSetDown.Location = new System.Drawing.Point(47, 1);
            this.btnSetDown.Name = "btnSetDown";
            this.btnSetDown.Size = new System.Drawing.Size(23, 22);
            this.btnSetDown.TabIndex = 2;
            this.btnSetDown.Text = "▽";
            this.btnSetDown.UseVisualStyleBackColor = true;
            this.btnSetDown.Click += new System.EventHandler(this.btnSetDown_Click);
            // 
            // btnSetUp
            // 
            this.btnSetUp.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSetUp.Location = new System.Drawing.Point(24, 1);
            this.btnSetUp.Name = "btnSetUp";
            this.btnSetUp.Padding = new System.Windows.Forms.Padding(2);
            this.btnSetUp.Size = new System.Drawing.Size(23, 22);
            this.btnSetUp.TabIndex = 1;
            this.btnSetUp.Text = "△";
            this.btnSetUp.UseVisualStyleBackColor = true;
            this.btnSetUp.Click += new System.EventHandler(this.btnSetUp_Click);
            // 
            // btnSetTop
            // 
            this.btnSetTop.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSetTop.Location = new System.Drawing.Point(1, 1);
            this.btnSetTop.Name = "btnSetTop";
            this.btnSetTop.Size = new System.Drawing.Size(23, 22);
            this.btnSetTop.TabIndex = 0;
            this.btnSetTop.Text = "▲";
            this.btnSetTop.UseVisualStyleBackColor = true;
            this.btnSetTop.Click += new System.EventHandler(this.btnSetTop_Click);
            // 
            // UCTableSort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSetBottom);
            this.Controls.Add(this.btnSetDown);
            this.Controls.Add(this.btnSetUp);
            this.Controls.Add(this.btnSetTop);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UCTableSort";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(94, 24);
            this.Load += new System.EventHandler(this.UCTableSort_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSetBottom;
        private System.Windows.Forms.Button btnSetDown;
        private System.Windows.Forms.Button btnSetUp;
        private System.Windows.Forms.Button btnSetTop;
    }
}
