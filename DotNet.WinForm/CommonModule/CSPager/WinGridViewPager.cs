//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Utilities;
    public partial class WinGridViewPager : UserControl
    {
        private object dataSource;
        private string displayColumns = "";
        private string printTitle = "";
        private Dictionary<string, int> columnDict = new Dictionary<string, int>();

        private PagerInfo pagerInfo = null;
        //private Export2Excel export2XLS = new Export2Excel();
        private SaveFileDialog saveFileDialog = new SaveFileDialog();
        private bool isExportAllPage = false;
        private Dictionary<string, string> columnNameAlias = new Dictionary<string, string>();
        private ContextMenuStrip appendedMenu;

        public DataTable AllToExport;
        public ProgressBar ProgressBar;

        public event EventHandler OnStartExport;
        public event EventHandler OnEndExport;
        public event EventHandler OnPageChanged;
        public event EventHandler OnEditSelected;
        public event EventHandler OnDeleteSelected;
        public event EventHandler OnRefresh;
        public event EventHandler OnAddNew;

        /// <summary>
        /// 追加的菜单项目
        /// </summary>
        public ContextMenuStrip AppendedMenu
        {
            get
            { 
                return appendedMenu;
            }
            set
            {
                if (value != null)
                {
                    appendedMenu = value;
                    for (int i = 0; appendedMenu.Items.Count > 0; i++)
                    {
                        this.contextMenuStrip1.Items.Insert(i, appendedMenu.Items[0]);
                    }

                    this.menu_Delete.Visible = (this.OnDeleteSelected != null);
                    this.menu_Edit.Visible = (this.OnEditSelected != null);
                    this.menu_Refresh.Visible = (this.OnRefresh != null);
                    this.menu_Add.Visible = (this.OnAddNew != null);
                }
            }
        }

        public WinGridViewPager()
        {
            InitializeComponent();

            this.pager.PageChanged += new PageChangedEventHandler(pager_PageChanged);
            this.dataGridView1.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dataGridView1_DataBindingComplete);
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewRow row;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                row = dataGridView1.Rows[i];
                if ((i % 2) != 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Gainsboro;
                }
            }
        }

        private void pager_PageChanged(object sender, EventArgs e)
        {
            if (OnPageChanged != null)
            {
                OnPageChanged(this, new EventArgs());
            }
        }
        
        public object DataSource
        {
            get { return dataSource; }
            set
            {
                dataSource = value;

                InitializeDataGridView(dataSource);
                                
                this.dataGridView1.DataSource = dataSource;
                this.pager.InitPageInfo(PagerInfo.RecordCount, PagerInfo.PageSize);
            }
        }

        private void InitializeDataGridView(object objSource)
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.Columns.Clear();
            if (objSource != null)
            {
                int i = 0;
                if (objSource is DataView)
                {
                    #region 数据源是DataView
                    DataView dv = objSource as DataView;
                    DataTable dt = dv.Table;
                    if (dt != null)
                    {
                        Dictionary<string, string> dict = GetColumnNameTypes(dt);

                        foreach (DataRow dr in dt.Rows)
                        {
                            foreach (KeyValuePair<string, string> item in dict)
                            {
                                DataGridViewColumn col;
                                if (item.Value == "System.Boolean")
                                {
                                    col = new DataGridViewCheckBoxColumn();
                                }
                                else
                                {
                                    col = new DataGridViewTextBoxColumn();
                                }

                                col.Name = item.Key;
                                col.HeaderText = item.Key;
                                col.DataPropertyName = item.Key;

                                if (columnDict.Count > 0 && !columnDict.ContainsKey(item.Key))
                                {
                                    col.Width = 0;
                                    col.Visible = false;
                                    col.DisplayIndex = 1000 + i;
                                }
                                else
                                {
                                    col.DisplayIndex = i++;
                                }

                                this.dataGridView1.Columns.Add(col);
                            }
                            break;//进去一次就够了
                        }
                    } 
                    #endregion
                }
                else
                {
                    #region 数据源是IEnumerable
                    IEnumerable objList = objSource as IEnumerable;
                    foreach (object obj in objList)
                    {
                        Dictionary<string, string> dict = ReflectionUtil.GetPropertyNameTypes(obj);
                        foreach (KeyValuePair<string, string> item in dict)
                        {
                            DataGridViewColumn col;
                            if (item.Value == "System.Boolean")
                            {
                                col = new DataGridViewCheckBoxColumn();
                            }
                            else
                            {
                                col = new DataGridViewTextBoxColumn();
                            }

                            col.Name = item.Key;
                            col.HeaderText = item.Key;
                            col.DataPropertyName = item.Key;

                            if (columnDict.Count > 0 && !columnDict.ContainsKey(item.Key))
                            {
                                col.Width = 0;
                                col.Visible = false;
                                col.DisplayIndex = 1000 + i;
                            }
                            else
                            {
                                col.DisplayIndex = i++;
                            }

                            this.dataGridView1.Columns.Add(col);
                        }
                        break;//进去一次就够了
                    } 
                    #endregion
                }
            }
        }

        private Dictionary<string, string> GetColumnNameTypes(DataTable dt)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (DataColumn col in dt.Columns)
            {
                if (!dict.ContainsKey(col.ColumnName))
                {
                    dict.Add(col.ColumnName, col.DataType.FullName);
                }
            }
            return dict;
        }

        /// <summary>
        /// 显示的列内容，需要指定以防止GridView乱序
        /// 使用"|"或者","分开每个列，如“ID|Name”
        /// </summary>
        public string DisplayColumns
        {
            get { return displayColumns; }
            set
            {
                displayColumns = value;
                columnDict = new Dictionary<string, int>();
                string[] items = displayColumns.Split(new char[] { '|', ',' });
                for (int i = 0; i < items.Length; i++)
                {
                    string str = items[i];
                    if (!string.IsNullOrEmpty(str) && !columnDict.ContainsKey(str))
                    {
                        columnDict.Add(str, i);
                    }
                }
            }
        }

        /// <summary>
        /// 返回对应字段的显示顺序，如果没有，返回-1
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private int GetDisplayColumnIndex(string columnName)
        {
            int result = -1;
            if (columnDict.ContainsKey(columnName))
            {
                result = columnDict[columnName];
            }

            return result;
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

        /// <summary>
        /// 打印报表的抬头（标题）
        /// </summary>
        public string PrintTitle
        {
            get { return printTitle; }
            set { printTitle = value; }
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

        /// <summary>
        /// 使用背景线程导出Excel文档
        /// </summary>
        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            DataView dv = null;
            if (AllToExport != null && isExportAllPage)
            {
                dv = AllToExport.DefaultView;//导出用户指定的数据，如全部数据
            }
            else
            {
                object objSource = this.dataGridView1.DataSource;
                if (objSource is DataView)
                {
                    dv = (DataView)this.dataGridView1.DataSource;//默认导出显示内容
                }
                else
                {
                    DataTable table = ReflectionUtil.CreateTable(objSource);
                    dv = table.DefaultView;
                }
            }
            
            DataTable dt = dv.ToTable();
            string originalName = string.Empty;
            foreach (DataColumn column in dt.Columns)
            {
                originalName = column.Caption;
                if (columnNameAlias.ContainsKey(originalName))
                {
                    column.Caption = columnNameAlias[originalName];
                    column.ColumnName = columnNameAlias[originalName];
                }
            }

            //dv = dt.DefaultView;
            //export2XLS.ExportToExcel(dv, (String)e.Argument, "newSheet1");
            string outError = "";
            AsposeExcelTools.DataTableToExcel2(dt, (String)e.Argument, out outError);
        }

        /// <summary>
        /// 更新进度条的值
        /// </summary>
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
                OnDeleteSelected(this.dataGridView1, new EventArgs());
            }
        }

        private void menu_Refresh_Click(object sender, EventArgs e)
        {
            if (this.OnRefresh != null)
            {
                OnRefresh(this.dataGridView1, new EventArgs());
            }
        }
        
        private void menu_Edit_Click(object sender, EventArgs e)
        {
            if (OnEditSelected != null)
            {
                OnEditSelected(this.dataGridView1, new EventArgs());
            }
        }

        private void menu_Print_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(this.dataGridView1, this.printTitle);
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            string originalName = string.Empty;
            DataGridViewColumn column;
            DataGridViewRow row;

            this.dataGridView1.AutoGenerateColumns = false;
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                column = this.dataGridView1.Columns[i];
                originalName = column.Name;

                if (columnNameAlias.ContainsKey(originalName))
                {
                    column.HeaderText = columnNameAlias[originalName];
                }
            }

            object cellValue = "";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                row = dataGridView1.Rows[i];
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    cellValue = row.Cells[j].Value;
                    if(cellValue.GetType() == typeof(DateTime))
                    {
                        TimeSpan ts = Convert.ToDateTime(row.Cells[j].Value).Subtract(Convert.ToDateTime("1753/1/1"));
                        if(ts.TotalDays < 1)
                        {
                            row.Cells[j].Value = null;
                        }
                    }
                }

                if ((i % 2) != 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Gainsboro;
                }
            }
        }

        /// <summary>
        /// 添加列名的别名
        /// </summary>
        /// <param name="key">列的原始名称</param>
        /// <param name="alias">列的别名</param>
        public void AddColumnAlias(string key, string alias)
        {
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(alias))
            {
                if (!columnNameAlias.ContainsKey(key))
                {
                    columnNameAlias.Add(key, alias);
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.OnEditSelected != null)
            {
                this.OnEditSelected(this.dataGridView1, new EventArgs());
            }
        }

        private void menu_Add_Click(object sender, EventArgs e)
        {
            if (this.OnAddNew != null)
            {
                this.OnAddNew(this.dataGridView1, new EventArgs());
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows[e.RowIndex].Cells.Count; i++)
                {
                    StringBuilder tooltipText = new StringBuilder();
                    tooltipText.AppendFormat("行数据基本信息：\r\n\t");
                    for (int j = 0; j < this.dataGridView1.Rows[e.RowIndex].Cells.Count; j++)
                    {
                        if (this.dataGridView1.Columns[j].Visible)
                        {
                            DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[j];
                            tooltipText.AppendFormat("{0}：{1}\r\n\t", 
                                this.dataGridView1.Columns[j].HeaderText, cell.Value);
                        }
                    }
                    dataGridView1[i, e.RowIndex].ToolTipText = tooltipText.ToString();
                }
            }
            catch //(Exception ex)
            {
                //MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows[e.RowIndex].Cells.Count; i++)
            {
                dataGridView1[i, e.RowIndex].ToolTipText = string.Empty;
            }
        }

        protected override void OnBindingContextChanged(EventArgs e)
        {
            DataGridViewRow row;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                row = dataGridView1.Rows[i];
                if ((i % 2) != 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Gainsboro;
                }
            }
            base.OnBindingContextChanged(e);
        }
    }
}
