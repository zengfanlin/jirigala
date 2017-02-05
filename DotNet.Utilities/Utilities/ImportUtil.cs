using System;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Data.OleDb;
using NPOI.HSSF.UserModel;
using System.IO;
using NPOI.SS.UserModel;

namespace DotNet.Utilities
{
    public class ImportUtil
    {
        private int returnStatus = 0;
        private string returnMessage = null;

        /// <summary>
        /// 执行返回状态
        /// </summary>
        public int ReturnStatus
        {
            get { return returnStatus; }
        }

        /// <summary>
        /// 执行返回信息
        /// </summary>
        public string ReturnMessage
        {
            get { return returnMessage; }
        }

        /// <summary>
        /// 选择要导入的Excel文件
        /// </summary>
        /// <returns></returns>
        public static  string SelectExcelFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel文件(*.XLS)|*.XLS";

            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileNames[0];
                return filePath;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 读取Excel
        /// 默认第一行为标头
        /// 
        /// 替换原先的方式，不存在非托管方式无法释放资源的问题
        /// 适用于B/S C/S。服务器可免安装Office。
        /// Pcsky 2012.05.01
        /// </summary>
        /// <param name="path">excel文档路径</param>
        /// <returns></returns>
        public DataTable ImportExcel(string path)
        {
            DataTable dt = new DataTable();

            HSSFWorkbook workbook;
            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                workbook = new HSSFWorkbook(file);
            }
            ISheet sheet = workbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            IRow headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;

            // 添加datatable的标题行
            for (int i = 0; i < cellCount; i++)
            {
                //ICell cell = headerRow.GetCell(j);
                //dt.Columns.Add(cell.ToString());

                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                dt.Columns.Add(column);
            }

            // 从第2行起添加内容行
            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = dt.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    //if (row.GetCell(j) != null)
                    //{
                    //dataRow[j] = row.GetCell(j).ToString();
                    dataRow[j] = row.GetCell(j);
                    //}
                }

                dt.Rows.Add(dataRow);
            }

            workbook = null;
            sheet = null;
            return dt;
        }


        ///// <summary>
        ///// 导入EXCEL到DataSet
        ///// </summary>
        ///// <param name="fileName">Excel全路径文件名</param>
        ///// <returns>导入成功的DataSet</returns>
        //public DataTable ImportExcel(string fileName)
        //{
        //    //判断是否安装EXCEL
        //    Excel.Application xlApp = new Excel.ApplicationClass();
        //    if (xlApp == null)
        //    {
        //        returnStatus = -1;
        //        returnMessage = "无法创建Excel对象，可能您的计算机未安装Excel";
        //        return null;
        //    }

        //    //判断文件是否被其他进程使用            
        //    Excel.Workbook workbook;
        //    try
        //    {
        //        workbook = xlApp.Workbooks.Open(fileName, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, 1, 0);
        //    }
        //    catch
        //    {
        //        returnStatus = -1;
        //        returnMessage = "Excel文件处于打开状态，请保存关闭";
        //        return null;
        //    }

        //    //获得所有Sheet名称
        //    int n = workbook.Worksheets.Count;
        //    string[] SheetSet = new string[n];
        //    System.Collections.ArrayList al = new System.Collections.ArrayList();
        //    for (int i = 1; i <= n; i++)
        //    {
        //        SheetSet[i - 1] = ((Excel.Worksheet)workbook.Worksheets[i]).Name;
        //    }

        //    //释放Excel相关对象
        //    workbook.Close(null, null, null);
        //    xlApp.Quit();
        //    if (workbook != null)
        //    {
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
        //        workbook = null;
        //    }
        //    if (xlApp != null)
        //    {
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
        //        xlApp = null;
        //    }
        //    GC.Collect();

        //    //把EXCEL导入到DataSet
        //    DataSet ds = new DataSet();
        //    string connStr = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + fileName + ";Extended Properties=Excel 8.0";
        //    using (OleDbConnection conn = new OleDbConnection(connStr))
        //    {
        //        conn.Open();
        //        OleDbDataAdapter da;
        //        for (int i = 1; i <= n; i++)
        //        {
        //            string sql = "select * from [" + SheetSet[i - 1] + "$] ";
        //            da = new OleDbDataAdapter(sql, conn);
        //            da.Fill(ds, SheetSet[i - 1]);
        //            da.Dispose();
        //        }
        //        conn.Close();
        //        conn.Dispose();
        //    }
        //    ds.Tables[0].Columns.Add("错误信息");
        //    return ds.Tables[0];
        //}
    }
}
