namespace DotNet.WinForm
{
    partial class FrmUserOrganizeRoleAdmin
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

        #region Windows 窗体设计器生成的主键

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用主键编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserOrganizeRoleAdmin));
            this.tvOrganize = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBatchSave = new System.Windows.Forms.Button();
            this.btnInvertSelect = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.ucStaffSelect = new DotNet.WinForm.UCStaffSelect();
            this.lblParentReq = new System.Windows.Forms.Label();
            this.lblStaff = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tvOrganize
            // 
            this.tvOrganize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvOrganize.CheckBoxes = true;
            this.tvOrganize.ImageIndex = 0;
            this.tvOrganize.ImageList = this.imageList;
            this.tvOrganize.Location = new System.Drawing.Point(8, 44);
            this.tvOrganize.Name = "tvOrganize";
            this.tvOrganize.SelectedImageIndex = 1;
            this.tvOrganize.Size = new System.Drawing.Size(676, 334);
            this.tvOrganize.TabIndex = 3;
            this.tvOrganize.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvOrganize_BeforeCheck);
            this.tvOrganize.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvOrganize_AfterCheck);
            this.tvOrganize.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOrganize_AfterSelect);
            this.tvOrganize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvOrganize_MouseDown);
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
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(597, 383);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBatchSave
            // 
            this.btnBatchSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchSave.Location = new System.Drawing.Point(515, 383);
            this.btnBatchSave.Name = "btnBatchSave";
            this.btnBatchSave.Size = new System.Drawing.Size(75, 23);
            this.btnBatchSave.TabIndex = 6;
            this.btnBatchSave.Text = "保存(&S)";
            this.btnBatchSave.UseVisualStyleBackColor = true;
            this.btnBatchSave.Click += new System.EventHandler(this.btnBatchSave_Click);
            // 
            // btnInvertSelect
            // 
            this.btnInvertSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvertSelect.Location = new System.Drawing.Point(91, 383);
            this.btnInvertSelect.Name = "btnInvertSelect";
            this.btnInvertSelect.Size = new System.Drawing.Size(78, 23);
            this.btnInvertSelect.TabIndex = 5;
            this.btnInvertSelect.Text = "反选";
            this.btnInvertSelect.UseVisualStyleBackColor = true;
            this.btnInvertSelect.Click += new System.EventHandler(this.btnInvertSelect_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Location = new System.Drawing.Point(7, 383);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(78, 23);
            this.btnSelectAll.TabIndex = 4;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // ucStaffSelect
            // 
            this.ucStaffSelect.AllowNull = true;
            this.ucStaffSelect.AllowSelect = false;
            this.ucStaffSelect.Location = new System.Drawing.Point(122, 13);
            this.ucStaffSelect.MultiSelect = false;
            this.ucStaffSelect.Name = "ucStaffSelect";
            this.ucStaffSelect.OpenId = "";
            this.ucStaffSelect.PermissionItemScopeCode = "";
            this.ucStaffSelect.RemoveIds = null;
            this.ucStaffSelect.SelectedFullName = "";
            this.ucStaffSelect.SelectedId = "";
            this.ucStaffSelect.SelectedIds = null;
            this.ucStaffSelect.SetSelectIds = null;
            this.ucStaffSelect.Size = new System.Drawing.Size(271, 22);
            this.ucStaffSelect.TabIndex = 1;
            this.ucStaffSelect.SelectedIndexChanged += new DotNet.Utilities.BaseBusinessLogic.SelectedIndexChangedEventHandler(this.ucStaffSelect_SelectedIndexChanged);
            // 
            // lblParentReq
            // 
            this.lblParentReq.AutoSize = true;
            this.lblParentReq.ForeColor = System.Drawing.Color.Red;
            this.lblParentReq.Location = new System.Drawing.Point(366, 20);
            this.lblParentReq.Name = "lblParentReq";
            this.lblParentReq.Size = new System.Drawing.Size(11, 12);
            this.lblParentReq.TabIndex = 2;
            this.lblParentReq.Text = "*";
            // 
            // lblStaff
            // 
            this.lblStaff.Location = new System.Drawing.Point(37, 17);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(81, 12);
            this.lblStaff.TabIndex = 0;
            this.lblStaff.Text = "用户(&N)：";
            this.lblStaff.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmUserOrganizeRoleAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(692, 410);
            this.Controls.Add(this.ucStaffSelect);
            this.Controls.Add(this.lblParentReq);
            this.Controls.Add(this.lblStaff);
            this.Controls.Add(this.btnInvertSelect);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBatchSave);
            this.Controls.Add(this.tvOrganize);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmUserOrganizeRoleAdmin";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "用户角色管理";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvOrganize;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBatchSave;
        private System.Windows.Forms.Button btnInvertSelect;
        private System.Windows.Forms.Button btnSelectAll;
        private DotNet.WinForm.UCStaffSelect ucStaffSelect;
        private System.Windows.Forms.Label lblParentReq;
        private System.Windows.Forms.Label lblStaff;
        private System.Windows.Forms.ImageList imageList;
    }
}