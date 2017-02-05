//------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2010 , Jirisoft , Ltd. 
//------------------------------------------------------------

using System;
using System.Data;
using System.Reflection;
using System.Web;
//using Microsoft.Office.Interop.Excel;
//using ExcelApplication = Microsoft.Office.Interop.Excel.Application;
using System.Windows.Forms;
using System.IO;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Runtime.InteropServices;

namespace DotNet.Utilities
{
    /// <summary>
    /// BaseExportExcel
    /// 导出Excel格式数据
    /// 
    /// 修改纪录
    /// 
    ///     2012.04.02 版本：3.0 Pcsky      增加判断文件是否打开的方法
    ///     2012.04.02 版本：3.0 Pcsky      增加新的导出Excel方法，非Com+方式，改用.Net控件
    ///     2009.07.08 版本：2.0 JiRiGaLa	更新完善程序，将方法修改为静态方法。
    ///     2006.12.02 版本：1.0 JiRiGaLa	新创建。
    /// 
    /// 版本：2.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2009.07.08</date>
    /// </author> 
    /// </summary>
    //public class BaseExportExcel
    //{
    //    #region private void DeleteExistFile(string fileName) 删除已经存在的文件
    //    /// <summary>
    //    /// 删除已经存在的文件
    //    /// </summary>
    //    /// <param name="fileName">文件路径</param>
    //    private void DeleteExistFile(string fileName)
    //    {
    //        if (System.IO.File.Exists(fileName))
    //        {
    //            System.IO.File.Delete(fileName);
    //        }
    //    }
    //    #endregion

    //    #region public void GetExcelFile(DataTable dataTable, string templateFilePath, string outFilePath, int startRowIndex, int startColIndex, string downloadPath) 导出Excel
    //    /// <summary>
    //    /// 导出Excel
    //    /// </summary>
    //    /// <param name="dataTable">数据表</param>
    //    /// <param name="paramOutFileName">输出名称</param>
    //    /// <param name="outFilePath">输出路径</param>
    //    /// <param name="startRowIndex">粘贴起始行</param>
    //    /// <param name="startColIndex">粘贴起始列</param>
    //    /// <param name="downloadPath">下载路径</param>
    //    public void GetExcelFile(System.Data.DataTable dataTable, string templateFilePath, string outFilePath, int startRowIndex, int startColIndex, string downloadPath)
    //    {
    //        int colIndex = 0;
    //        int rowIndex = 0;
    //        int rowCount = dataTable.Rows.Count;
    //        int colCount = dataTable.Columns.Count + 1;
    //        DataView dataView = dataTable.DefaultView;
    //        templateFilePath = HttpContext.Current.Server.MapPath(templateFilePath);
    //        string outTemplateFilePath = HttpContext.Current.Server.MapPath(outFilePath);
    //        ExcelApplication excel = new ExcelApplication();
    //        excel.Visible = false;
    //        // 检测模版是否存在
    //        if (System.IO.File.Exists(templateFilePath))
    //        {
    //            excel.Workbooks.Open(templateFilePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
    //        }
    //        else
    //        {
    //            excel.Workbooks.Add(Missing.Value);
    //        }
    //        Worksheet worksheet = (Worksheet)excel.ActiveSheet;
    //        Object[,] objData = new Object[rowCount, colCount];

    //        foreach (DataRowView Row in dataView)
    //        {
    //            colIndex = 0;
    //            foreach (DataColumn Column in dataView.Table.Columns)
    //            {
    //                if (colIndex == 0)
    //                {
    //                    objData[rowIndex, colIndex] = rowIndex + 1;
    //                    colIndex++;
    //                }

    //                if (Column.DataType == System.Type.GetType("System.DateTime"))
    //                {
    //                    if (Row[Column.ColumnName].ToString().Length > 0)
    //                    {
    //                        objData[rowIndex, colIndex] = (Convert.ToDateTime(Row[Column.ColumnName].ToString()).ToString());
    //                    }
    //                    else
    //                    {
    //                        objData[rowIndex, colIndex] = string.Empty;
    //                    }
    //                }
    //                else
    //                {
    //                    if (Column.DataType == System.Type.GetType("System.String"))
    //                    {
    //                        objData[rowIndex, colIndex] = "'" + Row[Column.ColumnName].ToString();
    //                    }
    //                    else
    //                    {
    //                        objData[rowIndex, colIndex] = Row[Column.ColumnName].ToString();
    //                    }
    //                }
    //                colIndex ++;
    //            }
    //            rowIndex++;
    //        }
    //        // 写入Excel
    //        Range range = worksheet.get_Range(worksheet.Cells[startRowIndex, startColIndex], worksheet.Cells[rowCount + startRowIndex -1, colCount + startColIndex -1]);
    //        range.Value2 = objData;
    //        // 删除已经存在的文件
    //        this.DeleteExistFile(outTemplateFilePath);
    //        worksheet.SaveAs(outTemplateFilePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
    //        excel.Quit();
    //        System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
    //        System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
    //        GC.Collect();
    //        HttpContext.Current.Response.Redirect(downloadPath);
    //    }
    //    #endregion

    //    #region API
    //    [DllImport("kernel32.dll")]
    //    public static extern IntPtr _lopen(string lpPathName, int iReadWrite);

    //    [DllImport("kernel32.dll")]
    //    public static extern bool CloseHandle(IntPtr hObject);

    //    public const int OF_READWRITE = 2;
    //    public const int OF_SHARE_DENY_NONE = 0x40;
    //    public static readonly IntPtr HFILE_ERROR = new IntPtr(-1);
    //    #endregion

    //    #region public static bool CheckIsOpened(string fileName) 检测文件是否被打开
    //    /// <summary>
    //    /// 检测文件是否被打开
    //    /// </summary>
    //    /// <param name="fileName">文件名，带路径</param>
    //    /// <returns>是否打开</returns>
    //    public static bool CheckIsOpened(string fileName)
    //    {
    //        IntPtr vHandle = _lopen(fileName, OF_READWRITE | OF_SHARE_DENY_NONE);

    //        if (vHandle == HFILE_ERROR && File.Exists(fileName))
    //        {
    //            CloseHandle(vHandle);
    //            return true;
    //        }

    //        CloseHandle(vHandle);
    //        return false;
    //    }
    //    #endregion

    //    #region public static void ExportXlsByNPOI(DataGridView dataGridView, DataView dataView, string fileName) 导出Excel格式文件(NPOI组件方式)
    //    /// <summary>
    //    /// 导出Excel格式文件(NPOI组件方式)
    //    /// </summary>
    //    /// <param name="dataGridView">表格控件</param>
    //    /// <param name="dataView">数据表</param>
    //    /// <param name="fileName">文件名</param>
    //    public static void ExportXlsByNPOI(DataGridView dataGridView, DataView dataView, string fileName)
    //    {
    //        FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);

    //        HSSFWorkbook workbook = new HSSFWorkbook();
    //        MemoryStream ms = new MemoryStream();
    //        Sheet sheet = workbook.CreateSheet();
    //        Row headerRow = sheet.CreateRow(0);

    //        // 写出表头
    //        for (int i = 0; i < dataGridView.Columns.Count; i++)
    //        {
    //            if (dataGridView.Columns[i].Visible && (dataGridView.Columns[i].Name.ToUpper() != "colSelected".ToUpper()))
    //            {
    //                headerRow.CreateCell(i).SetCellValue(dataGridView.Columns[i].HeaderText);
    //            }
    //        }

    //        // 行索引号
    //        int rowIndex = 1;

    //        // 写出数据
    //        foreach (DataRowView dataRowView in dataView)
    //        {
    //            Row dataRow = sheet.CreateRow(rowIndex);

    //            for (int i = 0; i < dataGridView.Columns.Count; i++)
    //            {
    //                if (dataGridView.Columns[i].Visible && (dataGridView.Columns[i].Name.ToUpper() != "colSelected".ToUpper()))
    //                {
    //                    switch (dataRowView[dataGridView.Columns[i].DataPropertyName].GetType().ToString())
    //                    {
    //                        case "System.String":
    //                        default:
    //                            dataRow.CreateCell(i).SetCellValue(
    //                                Convert.ToString(dataRowView[dataGridView.Columns[i].DataPropertyName])
    //                                );
    //                            break;
    //                        case "System.Int16":
    //                        case "System.Int32":
    //                        case "System.Int64":
    //                        case "System.Decimal":
    //                        case "System.Double":
    //                            dataRow.CreateCell(i).SetCellValue(
    //                                Convert.ToDouble(dataRowView[dataGridView.Columns[i].DataPropertyName])
    //                                );
    //                            break;
    //                    }
    //                }
    //            }
    //            rowIndex++;
    //        }

    //        workbook.Write(ms);
    //        byte[] data = ms.ToArray();

    //        ms.Flush();
    //        ms.Close();

    //        fs.Write(data, 0, data.Length);
    //        fs.Flush();
    //        fs.Close();
    //    }
    //    #endregion


    //    #region public static void ExportXlsByNPOI(System.Data.DataTable dataTable, Dictionary<string,string> fieldList, string fileName) 导出Excel格式文件(NPOI组件方式)
    //    /// <summary>
    //    /// 导出Excel格式文件(NPOI组件方式)
    //    /// </summary>
    //    /// <param name="dataGridView">表格控件</param>
    //    /// <param name="dataTable">数据表</param>
    //    /// <param name="fieldList">数据表字段名-说明对应列表</param>
    //    /// <param name="fileName">文件名</param>
    //    public static void ExportXlsByNPOI(System.Data.DataTable dataTable, System.Collections.Generic.Dictionary<string, string> fieldList, string fileName)
    //    {
    //        FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);

    //        HSSFWorkbook workbook = new HSSFWorkbook();
    //        MemoryStream ms = new MemoryStream();
    //        Sheet sheet = workbook.CreateSheet();
    //        Row headerRow = sheet.CreateRow(0);

    //        // 写出表头
    //        for (int i = 0; i < dataTable.Columns.Count; i++)
    //        {
    //            //if (dataTable.Columns[i].Visible && (dataTable.Columns[i].Name.ToUpper() != "colSelected".ToUpper()))
    //            //{
    //            //headerRow.CreateCell(i).SetCellValue(fieldList[dataTable.Columns[i].ColumnName.ToLower()]);
    //            //}

    //            //增加了try Catch，解决字典fieldList中没有table列中项时，会出错。
    //            //此处采用跳过的方式,表现方式是此列的表头没值
    //            try
    //            {
    //                headerRow.CreateCell(i).SetCellValue(fieldList[dataTable.Columns[i].ColumnName.ToLower()]);
    //            }
    //            catch (Exception)
    //            {
    //                continue;
    //            }
    //        }

    //        // 行索引号
    //        int rowIndex = 1;

    //        // 写出数据
    //        foreach (DataRow dataTableRow in dataTable.Rows)
    //        {
    //            Row dataRow = sheet.CreateRow(rowIndex);

    //            for (int i = 0; i < dataTable.Columns.Count; i++)
    //            {
    //                //if (dataGridView.Columns[i].Visible && (dataGridView.Columns[i].Name.ToUpper() != "colSelected".ToUpper()))
    //                //{
    //                switch (dataTable.Columns[i].DataType.ToString())
    //                {
    //                    case "System.String":
    //                    default:
    //                        dataRow.CreateCell(i).SetCellValue(
    //                            Convert.ToString(Convert.IsDBNull(dataTableRow[i]) ? "" : dataTableRow[i])
    //                            );
    //                        break;
    //                    case "System.Int16":
    //                    case "System.Int32":
    //                    case "System.Int64":
    //                    case "System.Decimal":
    //                    case "System.Double":
    //                        dataRow.CreateCell(i).SetCellValue(
    //                            Convert.ToDouble(Convert.IsDBNull(dataTableRow[i]) ? 0 : dataTableRow[i])
    //                            );
    //                        break;
    //                }
    //                //                    }
    //            }
    //            rowIndex++;
    //        }

    //        workbook.Write(ms);
    //        byte[] data = ms.ToArray();

    //        ms.Flush();
    //        ms.Close();

    //        fs.Write(data, 0, data.Length);
    //        fs.Flush();
    //        fs.Close();
    //    }
    //    #endregion
    //}
}