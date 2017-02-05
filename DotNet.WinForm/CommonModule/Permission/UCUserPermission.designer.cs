namespace DotNet.WinForm
{
    partial class UCUserPermission
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCUserPermission));
            this.tvUserPermission = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // tvUserPermission
            // 
            this.tvUserPermission.CheckBoxes = true;
            this.tvUserPermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvUserPermission.ImageIndex = 0;
            this.tvUserPermission.ImageList = this.imageList;
            this.tvUserPermission.Location = new System.Drawing.Point(0, 0);
            this.tvUserPermission.Name = "tvUserPermission";
            this.tvUserPermission.SelectedImageIndex = 0;
            this.tvUserPermission.Size = new System.Drawing.Size(676, 409);
            this.tvUserPermission.TabIndex = 6;
            this.tvUserPermission.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvStaffPermission_BeforeCheck);
            this.tvUserPermission.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvStaffPermission_AfterCheck);
            this.tvUserPermission.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvStaffPermission_AfterSelect);
            this.tvUserPermission.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvUserPermission_MouseDown);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "");
            this.imageList.Images.SetKeyName(1, "");
            this.imageList.Images.SetKeyName(2, "");
            this.imageList.Images.SetKeyName(3, "");
            this.imageList.Images.SetKeyName(4, "");
            this.imageList.Images.SetKeyName(5, "");
            this.imageList.Images.SetKeyName(6, "");
            this.imageList.Images.SetKeyName(7, "");
            this.imageList.Images.SetKeyName(8, "");
            this.imageList.Images.SetKeyName(9, "");
            this.imageList.Images.SetKeyName(10, "");
            this.imageList.Images.SetKeyName(11, "");
            this.imageList.Images.SetKeyName(12, "");
            this.imageList.Images.SetKeyName(13, "");
            this.imageList.Images.SetKeyName(14, "");
            this.imageList.Images.SetKeyName(15, "icon_messenger1.gif");
            this.imageList.Images.SetKeyName(16, "icon_messenger0.gif");
            this.imageList.Images.SetKeyName(17, "icon_messenger2.gif");
            this.imageList.Images.SetKeyName(18, "icon_messenger3.gif");
            this.imageList.Images.SetKeyName(19, "icon_messenger4.gif");
            this.imageList.Images.SetKeyName(20, "icon_messenger5.gif");
            this.imageList.Images.SetKeyName(21, "icon_messenger6.gif");
            // 
            // UCUserPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvUserPermission);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Name = "UCUserPermission";
            this.Size = new System.Drawing.Size(676, 409);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvUserPermission;
        private System.Windows.Forms.ImageList imageList;
    }
}
