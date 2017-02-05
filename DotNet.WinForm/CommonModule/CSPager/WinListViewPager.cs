//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    public partial class WinListViewPager : UserControl
    {
        private DataTable dataSource = new DataTable();
        private PagerInfo pagerInfo = null;
        //private Export2Excel export2XLS = new Export2Excel();
        private SaveFileDialog saveFileDialog = new SaveFileDialog();
        private bool isExportAllPage = false;

        public DataTable TableToExport = new DataTable();
        public ProgressBar ProgressBar;
        public event EventHandler OnStartExport;
        public event EventHandler OnEndExport;
        public event EventHandler OnPageChanged;
        public event EventHandler OnDeleteSelected;
        public event EventHandler OnRefresh;

        public WinListViewPager()
        {
            InitializeComponent();

            this.pager.PageChanged += new PageChangedEventHandler(pager_PageChanged);
        }

        private void pager_PageChanged(object sender, EventArgs e)
        {
            if (OnPageChanged != null)
            {
                OnPageChanged(this, new EventArgs());
            }
        }
        
        public DataTable DataSource
        {
            get { return dataSource; }
            set
            {
                dataSource = value;
                this.listView1.Columns.Clear();
                foreach (DataColumn col in value.Columns)
                {
                    this.listView1.Columns.Add(col.ColumnName, 120);
                }

                ListViewItem item;
                this.listView1.Items.Clear();
                foreach (DataRow row in value.Rows)
                {
                    item = new ListViewItem();
                    item.SubItems.Clear();

                    item.SubItems[0].Text = row[0].ToString();
                    for (int i = 1; i < value.Columns.Count; i++)
                    {
                        item.SubItems.Add(row[i].ToString());
                    }
                    this.listView1.Items.Add(item);
                }

                this.pager.InitPageInfo(PagerInfo.RecordCount);
            }
        }

        public PagerInfo PagerInfo
        {
            get
            {
                if (pagerInfo == null)
                {
                    pagerInfo = new PagerInfo();
                    pagerInfo.RecordCount = this.pager.RecordCount;
                    pagerInfo.CurrenetPageIndex = this.pager.PageIndex;
                    pagerInfo.PageSize = this.pager.PageSize;
                }
                else
                {
                    pagerInfo.CurrenetPageIndex = this.pager.PageIndex;
                }

                return pagerInfo;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            isExportAllPage = true;
            ExportToExcel();
        }

        private void btnExportCurrent_Click(object sender, EventArgs e)
        {
            isExportAllPage = false;
            ExportToExcel();
        }        

        #region 导出Excel操作

        private void ExportToExcel()
        {
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel (*.xls)|*.xls";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!saveFileDialog.FileName.Equals(String.Empty))
                {
                    FileInfo f = new FileInfo(saveFileDialog.FileName);
                    if (f.Extension.ToLower().Equals(".xls"))
                    {
                        StartExport(saveFileDialog.FileName);
                    }
                    else
                    {
                        MessageBox.Show("文件格式不正确");
                    }
                }
                else
                {
                    MessageBox.Show("需要指定一个保存的目录");
                }
            }
        }

        /// <summary>
        /// starts the export to new excel document
        /// </summary>
        /// <param name="filepath">the file to export to</param>
        private void StartExport(String filepath)
        {
            if (OnStartExport != null)
            {
                OnStartExport(this, new EventArgs());
            }

            CallCtrlSafety.SetEnable<Button>(btnExport, false, this.ParentForm);
            CallCtrlSafety.SetEnable<Button>(btnExportCurrent, false, this.ParentForm);
            CallCtrlSafety.SetVisible<ProgressBar>(ProgressBar, true, this.ParentForm);

            //create a new background worker, to do the exporting
            BackgroundWorker bg = new BackgroundWorker();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
            bg.RunWorkerAsync(filepath);

            //create a new export2XLS object, providing DataView as a input parameter
            //export2XLS = new Export2Excel();
            //export2XLS.OnProgressHandler += new Export2Excel.ProgressHandler(export2XLS_prg);
        }

        //do the new excel document work using the background worker
        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            //DataView dv = this.dataSource.DefaultView;//默认导出显示内容
            //if (TableToExport != null && isExportAllPage)
            //{
            //    dv = TableToExport.DefaultView;//导出用户指定的数据，如全部数据
            //}

            //export2XLS.ExportToExcel(dv, (String)e.Argument, "newSheet1");

            DataTable dtExport = this.dataSource;
            if (TableToExport != null && isExportAllPage)
            {
                dtExport = TableToExport;
            }

            string outError = "";
            AsposeExcelTools.DataTableToExcel2(dtExport, (String)e.Argument, out outError);
        }

        //Update the progress bar with the a value
        private void export2XLS_prg(object sender, ProgressEventArgs e)
        {
            CallCtrlSafety.SetValue<ProgressBar>(ProgressBar, e.ProgressValue, this.ParentForm);
        }

        //show a message to the user when the background worker has finished
        //and re-enable the export buttons
        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CallCtrlSafety.SetEnable<Button>(btnExport, true, this.ParentForm);
            CallCtrlSafety.SetEnable<Button>(btnExportCurrent, true, this.ParentForm);
            CallCtrlSafety.SetVisible<ProgressBar>(ProgressBar, false, this.ParentForm);

            if (OnEndExport != null)
            {
                OnEndExport(this, new EventArgs());
            }

            if (MessageBox.Show("导出操作完成, 您想打开该Excel文件么?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Process.Start(saveFileDialog.FileName);
            }
        }
                
        #endregion

        private void menu_Delete_Click(object sender, EventArgs e)
        {
            if (OnDeleteSelected != null)
            {
                OnDeleteSelected(this.listView1, new EventArgs());
            }
        }

        private void menu_Refresh_Click(object sender, EventArgs e)
        {
            if (this.OnRefresh != null)
            {
                OnRefresh(this.listView1, new EventArgs());
            }
        }

        private void menu_Print_Click(object sender, EventArgs e)
        {

        }

        private void WinListViewPager_Load(object sender, EventArgs e)
        {
            if (this.ContextMenuStrip == null)
            {
                this.ContextMenuStrip = new ContextMenuStrip();
            }

            for (int i = 0; i < this.contextMenuStrip1.Items.Count; i++)
            {
                ToolStripItem item = this.contextMenuStrip1.Items[i];
                this.ContextMenuStrip.Items.Add(item);
            }
        }
    }
}
