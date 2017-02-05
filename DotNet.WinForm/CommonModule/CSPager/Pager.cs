//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

using System.ComponentModel;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    public delegate void PageChangedEventHandler(object sender, EventArgs e);

    /// <summary>
    /// 分页工具条用户控件，仅提供分页信息显示及改变页码操作
    /// </summary>
    public class Pager : UserControl
    {
        public event PageChangedEventHandler PageChanged;

        private int m_PageSize;
        private int m_PageCount;
        private int m_RecordCount;
        private int m_PageIndex;

        private Label lblPageInfo;
        private TextBox txtPageIndex;
        private Button btnFirst;
        private Button btnPrevious;
        private Button btnNext;
        private Button btnLast;

        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;
        
        /// <summary> 
        /// 默认构造函数，设置分页初始信息
        /// </summary>
        public Pager()
        {
            InitializeComponent();

            this.m_PageSize = 10;
            this.m_RecordCount = 0;
            this.m_PageIndex = 1; //默认为第一页
            //this.InitPageInfo();//此处不需要调用HJC
        }

        /// <summary> 
        /// 带参数的构造函数
        /// <param name="pageSize">每页记录数</param>
        /// <param name="recordCount">总记录数</param>
        /// </summary>
        public Pager(int recordCount, int pageSize)
        {
            InitializeComponent();

            this.m_PageSize = pageSize;
            this.m_RecordCount = recordCount;
            this.m_PageIndex = 1; //默认为第一页
            this.InitPageInfo();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
       
        #region 组件设计器生成的代码
        /// <summary> 
        /// 设计器支持所需的方法 - 不要使用代码编辑器 
        /// 修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.txtPageIndex = new System.Windows.Forms.TextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.Location = new System.Drawing.Point(0, 4);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(264, 16);
            this.lblPageInfo.TabIndex = 0;
            this.lblPageInfo.Text = "共 {0} 条记录，每页 {1} 条，共 {2} 页";
            this.lblPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPageIndex
            // 
            this.txtPageIndex.AutoSize = false;
            this.txtPageIndex.Location = new System.Drawing.Point(336, 0);
            this.txtPageIndex.Name = "txtPageIndex";
            this.txtPageIndex.Size = new System.Drawing.Size(25, 20);
            this.txtPageIndex.TabIndex = 5;
            this.txtPageIndex.Text = "1";
            this.txtPageIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPageIndex.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPageIndex_KeyDown);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(364, 0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(30, 20);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = ">";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(272, 0);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(30, 20);
            this.btnFirst.TabIndex = 7;
            this.btnFirst.Text = "|<";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(304, 0);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(30, 20);
            this.btnPrevious.TabIndex = 8;
            this.btnPrevious.Text = "<";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(396, 0);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(30, 20);
            this.btnLast.TabIndex = 9;
            this.btnLast.Text = ">|";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // PageSplit
            // 
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtPageIndex);
            this.Controls.Add(this.lblPageInfo);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "PageSplit";
            this.Size = new System.Drawing.Size(432, 24);
            this.ResumeLayout(false);
        }
        #endregion



        protected virtual void OnPageChanged(EventArgs e)
        {
            if (PageChanged != null)
            {
                InitPageInfo();
                PageChanged(this, e);
            }
        }

        [Description("设置或获取一页中显示的记录数目"), DefaultValue(10), Category("分页")]
        public int PageSize
        {
            set
            {
                this.m_PageSize = value;
            }
            get
            {
                return this.m_PageSize;
            }
        }
        
        [Description("获取记录总页数"), DefaultValue(0), Category("分页")]
        public int PageCount
        {
            get
            {
                return this.m_PageCount;
            }
        }

        [Description("设置或获取记录总数"), Category("分页")]
        public int RecordCount
        {
            set
            {
                this.m_RecordCount = value;
            }
            get
            {
                return this.m_RecordCount;
            }
        }
        
        [Description("当前的页面索引, 开始为1"), DefaultValue(0), Category("分页")]
        [Browsable(false)]
        public int PageIndex
        {
            set
            {
                this.m_PageIndex = value;
            }
            get
            {
                return this.m_PageIndex;
            }
        }
        
        /// <summary> 
        /// 初始化分页信息
        /// <param name="pageSize">每页记录数</param>
        /// <param name="recordCount">总记录数</param>
        /// </summary>
        public void InitPageInfo(int recordCount, int pageSize)
        {
            this.m_RecordCount = recordCount;
            this.m_PageSize = pageSize;
            this.InitPageInfo();
        }
        
        /// <summary> 
        /// 初始化分页信息
        /// <param name="recordCount">总记录数</param>
        /// </summary>
        public void InitPageInfo(int recordCount)
        {
            this.m_RecordCount = recordCount;
            this.InitPageInfo();
        }
        
        /// <summary> 
        /// 初始化分页信息
        /// </summary>
        public void InitPageInfo()
        {
            if (this.m_PageSize < 1)
                this.m_PageSize = 10; //如果每页记录数不正确，即更改为10
            if (this.m_RecordCount < 0)
                this.m_RecordCount = 0; //如果记录总数不正确，即更改为0

            //取得总页数
            if (this.m_RecordCount % this.m_PageSize == 0)
            {
                this.m_PageCount = this.m_RecordCount / this.m_PageSize;
            }
            else
            {
                this.m_PageCount = this.m_RecordCount / this.m_PageSize + 1;
            }

            //设置当前页
            if (this.m_PageIndex > this.m_PageCount)
            {
                this.m_PageIndex = this.m_PageCount;
            }
            if (this.m_PageIndex < 1)
            {
                this.m_PageIndex = 1;
            }

            //设置上一页按钮的可用性
            bool enable = (this.PageIndex > 1);
            this.btnPrevious.Enabled = enable;

            //设置首页按钮的可用性
            enable = (this.PageIndex > 1);
            this.btnFirst.Enabled = enable;

            //设置下一页按钮的可用性
            enable = (this.PageIndex < this.PageCount);
            this.btnNext.Enabled = enable;

            //设置末页按钮的可用性
            enable = (this.PageIndex < this.PageCount);
            this.btnLast.Enabled = enable;

            this.txtPageIndex.Text = this.m_PageIndex.ToString();
            this.lblPageInfo.Text = string.Format("共 {0} 条记录，每页 {1} 条，共 {2} 页", this.m_RecordCount, this.m_PageSize, this.m_PageCount);
        }

        public void RefreshData(int page)
        {
            this.m_PageIndex = page;
            EventArgs e = new EventArgs();
            OnPageChanged(e);
        }
        
        private void btnFirst_Click(object sender, System.EventArgs e)
        {
            this.RefreshData(1);
        }
        
        private void btnPrevious_Click(object sender, System.EventArgs e)
        {
            if (this.m_PageIndex > 1)
            {
                this.RefreshData(this.m_PageIndex - 1);
            }
            else
            {
                this.RefreshData(1);
            }
        }
        private void btnNext_Click(object sender, System.EventArgs e)
        {
            if (this.m_PageIndex < this.m_PageCount)
            {
                this.RefreshData(this.m_PageIndex + 1);
            }
            else if (this.m_PageCount < 1)
            {
                this.RefreshData(1);
            }
            else
            {
                this.RefreshData(this.m_PageCount);
            }
        }
        
        private void btnLast_Click(object sender, System.EventArgs e)
        {
            if (this.m_PageCount > 0)
            {
                this.RefreshData(this.m_PageCount);
            }
            else
            {
                this.RefreshData(1);
            }
        }
        
        private void txtPageIndex_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int num;
                try
                {
                    num = Convert.ToInt16(this.txtPageIndex.Text);
                }
                catch// (Exception ex)
                {
                    num = 1;
                }

                if (num > this.m_PageCount)
                    num = this.m_PageCount;
                if (num < 1)
                    num = 1;

                this.RefreshData(num);
            }
        }
    }
}

