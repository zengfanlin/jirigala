//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic; // to ensure EXCEL process is really killed
using System.Data;    // For Missing.Value and BindingFlags
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices; // For COMException
using System.Windows.Forms;

//using Microsoft.Office.Core;
//using Microsoft.Office.Interop.Excel;

namespace DotNet.WinForm
{ 
    /// <summary>
    /// This class processes the DataView that it is provided and
    /// Exports this DataView to an Excel document.
    /// </summary>
    //public class Export2Excel
    //{
    //    #region InstanceFields
    //    //Instance Fields
    //    public delegate void ProgressHandler(object sender, ProgressEventArgs e);
    //    public event ProgressHandler OnProgressHandler;

    //    private List<DataView> dvList;
    //    private Style styleRows;
    //    private Style styleColumnHeadings;
    //    private Microsoft.Office.Interop.Excel.Application EXL;
    //    private Workbook workbook;
    //    private Sheets sheets;
    //    private Worksheet worksheet;
    //    private string[,] myTemplateValues;
    //    private int position;

    //    #endregion
        
    //    #region Constructor
    //    //Constructs a new export2Excel object. The user must
    //    //call the createExcelDocument method once a valid export2Excel
    //    //object has been instantiated
    //    public Export2Excel()
    //    {

    //    }
    //    #endregion

    //    #region EXCEL : ExportToExcel

    //    /// <summary>
    //    /// Exports a DataView to Excel
    //    /// </summary>
    //    /// <param name="dv">DataView to use</param>
    //    /// <param name="path">The path to save/open the EXCEL file to/from</param>
    //    /// <param name="sheetName">The target sheet within the EXCEL file</param>
    //    public void ExportToExcel(DataView dv, string path, string sheetName)
    //    {
    //        List<DataView> dvList = new List<DataView>() { dv };
    //        // ExportToExcel(dvList, path, sheetName);
    //    }

    //    //Exports a DataView to Excel. The following steps are carried out
    //    //in order to export the DataView to Excel
    //    //Create Excel Objects
    //    //Create Column & Row Workbook Cell Rendering Styles
    //    //Fill Worksheet With DataView
    //    //Add Auto Shapes To Excel Worksheet
    //    //Select All Used Cells
    //    //Create Headers/Footers
    //    //Set Status Finished
    //    //Save workbook & Tidy up all objects
    //    //@param dv : DataView to use
    //    //@param path : The path to save/open the EXCEL file to/from
    //    //@param sheetName : The target sheet within the EXCEL file

    //    //public void ExportToExcel(List<DataView> dvList,string path, string sheetName)
    //    //{
    //    //    try
    //    //    {
    //    //        //Assign Instance Fields
    //    //        this.dvList = dvList;

    //    //        #region NEW EXCEL DOCUMENT : Create Excel Objects

    //    //        //create new EXCEL application
    //    //        new Microsoft.Office.Interop.Excel.ApplicationClass
    //    //        EXL = new Microsoft.Office.Interop.Excel.ApplicationClass();
    //    //        //index to hold location of the requested sheetName in the workbook sheets
    //    //        //collection
    //    //        int indexOfsheetName;

    //    //        #region FILE EXISTS
    //    //        //Does the file exist for the given path
    //    //        if (File.Exists(path))
    //    //        {

    //    //            //Yes file exists, so open the file
    //    //            workbook = EXL.Workbooks.Open(path,
    //    //                0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "",
    //    //                true, false, 0, true, false, false);

    //    //            //get the workbook sheets collection
    //    //            sheets = workbook.Sheets;

    //    //            //set the location of the requested sheetName to -1, need to find where
    //    //            //it is. It may not actually exist
    //    //            indexOfsheetName = -1;

    //    //            //loop through the sheets collection
    //    //            for (int i = 1; i <= sheets.Count; i++)
    //    //            {
    //    //                //get the current worksheet at index (i)
    //    //                worksheet = (Worksheet)sheets.get_Item(i);

    //    //                //is the current worksheet the sheetName that was requested
    //    //                if (worksheet.Name.ToString().Equals(sheetName))
    //    //                {
    //    //                    //yes it is, so store its index
    //    //                    indexOfsheetName = i;

    //    //                    //Select all cells, and clear the contents
    //    //                    Microsoft.Office.Interop.Excel.Range myAllRange = worksheet.Cells;
    //    //                    myAllRange.Select();
    //    //                    myAllRange.CurrentRegion.Select();
    //    //                    myAllRange.ClearContents();
    //    //                }
    //    //            }

    //    //            //At this point it is known that the sheetName that was requested
    //    //            //does not exist within the found file, so create a new sheet within the
    //    //            //sheets collection
    //    //            if (indexOfsheetName == -1)
    //    //            {
    //    //                //Create a new sheet for the requested sheet
    //    //                Worksheet sh = (Worksheet)workbook.Sheets.Add(
    //    //                    Type.Missing, (Worksheet)sheets.get_Item(sheets.Count),
    //    //                    Type.Missing, Type.Missing);
    //    //                //Change its name to that requested
    //    //                sh.Name = sheetName;
    //    //            }
    //    //        }
    //    //        #endregion

    //    //        #region FILE DOESNT EXIST
    //    //        //No the file DOES NOT exist, so create a new file
    //    //        else
    //    //        {
    //    //            //Add a new workbook to the file
    //    //            workbook = EXL.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
    //    //            //get the workbook sheets collection
    //    //            sheets = workbook.Sheets;
    //    //            //get the new sheet
    //    //            worksheet = (Worksheet)sheets.get_Item(1);
    //    //            //Change its name to that requested
    //    //            worksheet.Name = sheetName;
    //    //        }
    //    //        #endregion

    //    //        #region get correct worksheet index for requested sheetName

    //    //        //get the workbook sheets collection
    //    //        sheets = workbook.Sheets;

    //    //        //set the location of the requested sheetName to -1, need to find where
    //    //        //it is. It will definately exist now as it has just been added
    //    //        indexOfsheetName = -1;

    //    //        //loop through the sheets collection
    //    //        for (int i = 1; i <= sheets.Count; i++)
    //    //        {
    //    //            //get the current worksheet at index (i)
    //    //            worksheet = (Worksheet)sheets.get_Item(i);



    //    //            //is the current worksheet the sheetName that was requested
    //    //            if (worksheet.Name.ToString().Equals(sheetName))
    //    //            {
    //    //                //yes it is, so store its index
    //    //                indexOfsheetName = i;
    //    //            }
    //    //        }

    //    //        //set the worksheet that the DataView should write to, to the known index of the
    //    //        //requested sheet
    //    //        worksheet = (Worksheet)sheets.get_Item(indexOfsheetName);
    //    //        #endregion

    //    //        #endregion

    //    //        // Set styles 1st
    //    //        SetUpStyles();
    //    //        //Fill EXCEL worksheet with DataView values
    //    //        FillWorksheet_WithDataView();
                
    //    //        ////Add the autoshapes to EXCEL
    //    //        //AddAutoShapesToExcel();
                
    //    //        //Select all used cells within current worksheet
    //    //        SelectAllUsedCells();

    //    //        #region Finish and Release
    //    //        try
    //    //        {
    //    //            NAR(sheets);
    //    //            NAR(worksheet);
    //    //            workbook.Close(true, path, Type.Missing);
    //    //            NAR(workbook);

    //    //            EXL.UserControl = false;

    //    //            EXL.Quit();
    //    //            NAR(EXL);

    //    //            //kill the EXCEL process as a safety measure
    //    //            KillExcel();
    //    //            // Show that processing is finished
    //    //            ProgressEventArgs pe = new ProgressEventArgs(100);
    //    //            OnProgressChange(pe);

    //    //            //MessageBox.Show("Finished adding dataview to Excel", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
    //    //        }
    //    //        catch (COMException cex)
    //    //        {
    //    //            MessageBox.Show("用户手动关闭了Excel程序，导出操作不成功" + cex.Message);
    //    //        }
    //    //        catch (Exception ex)
    //    //        {
    //    //            MessageBox.Show("错误 " + ex.Message);
    //    //        } 
    //    //        #endregion
    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        MessageBox.Show("错误 " + ex.Message);
    //    //    }
    //    //}
       
        
    //    #endregion
        
    //    #region EXCEL : UseTemplate
    //    //Exports a DataView to Excel. The following steps are carried out
    //    //in order to export the DataView to Excel
    //    //Create Excel Objects And Open Template File
    //    //Select All Used Cells
    //    //Create Headers/Footers
    //    //Set Status Finished
    //    //Save workbook & Tidy up all objects
    //    //@param path : The path to save/open the EXCEL file to/from
    //    //public void UseTemplate(string path, string templatePath, string[,] myTemplateValues)
    //    //{
    //    //    try
    //    //    {
    //    //        this.myTemplateValues = myTemplateValues;
    //    //        //create new EXCEL application
    //    //        EXL = new Microsoft.Office.Interop.Excel.ApplicationClass();
    //    //        //Yes file exists, so open the file
    //    //        workbook = EXL.Workbooks.Open(templatePath,
    //    //            0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "",
    //    //            true, false, 0, true, false, false);
    //    //        //get the workbook sheets collection
    //    //        sheets = workbook.Sheets;
    //    //        //get the new sheet
    //    //        worksheet = (Worksheet)sheets.get_Item(1);
    //    //        //Change its name to that requested
    //    //        worksheet.Name = "ATemplate";
    //    //        //Fills the Excel Template File Selected With A 2D Test Array
    //    //        FillTemplate_WithTestValues();
    //    //        //Select all used cells within current worksheet
    //    //        SelectAllUsedCells();

    //    //        #region Finish and Release
    //    //        try
    //    //        {
    //    //            NAR(sheets);
    //    //            NAR(worksheet);
    //    //            workbook.Close(true, path, Type.Missing);
    //    //            NAR(workbook);

    //    //            EXL.UserControl = false;

    //    //            EXL.Quit();
    //    //            NAR(EXL);

    //    //            //kill the EXCEL process as a safety measure
    //    //            KillExcel();
    //    //            // Show that processing is finished
    //    //            ProgressEventArgs pe = new ProgressEventArgs(100);
    //    //            OnProgressChange(pe);
                    
    //    //            //MessageBox.Show("Finished adding test values to Template", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

    //    //        }
    //    //        catch (COMException)
    //    //        {
    //    //            Console.WriteLine("用户手动关闭了Excel程序，导出操作不成功");
    //    //        } 
    //    //        #endregion
    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        MessageBox.Show("错误 " + ex.Message);
    //    //    }
    //    //}
    //    #endregion

    //    #region STEP 1 : Create Column & Row Workbook Cell Rendering Styles
    //    //Creates 2 Custom styles for the workbook These styles are
    //    //  styleColumnHeadings
    //    //  styleRows
    //    //These 2 styles are used when filling the individual Excel cells with the
    //    //DataView values. If the current cell relates to a DataView column heading
    //    //then the style styleColumnHeadings will be used to render the current cell.
    //    //If the current cell relates to a DataView row then the style styleRows will
    //    //be used to render the current cell.
    //    private void SetUpStyles()
    //    {

    //        // Style styleColumnHeadings
    //        try
    //        {
    //            styleColumnHeadings = workbook.Styles["styleColumnHeadings"];
    //        }
    //        // Style doesn't exist yet.
    //        catch
    //        {
    //            styleColumnHeadings = workbook.Styles.Add("styleColumnHeadings", Type.Missing);
    //            styleColumnHeadings.Font.Name = "Arial";
    //            styleColumnHeadings.Font.Size = 14;
    //            styleColumnHeadings.Font.Color = (255 << 16) | (255 << 8) | 255;
    //            styleColumnHeadings.Interior.Color = (0 << 16) | (0 << 8) | 0;
    //            styleColumnHeadings.Interior.Pattern = Microsoft.Office.Interop.Excel.XlPattern.xlPatternSolid;
    //        }

    //        // Style styleRows
    //        try
    //        {

    //            styleRows = workbook.Styles["styleRows"];
    //        }
    //        // Style doesn't exist yet.
    //        catch
    //        {
    //            styleRows = workbook.Styles.Add("styleRows", Type.Missing);
    //            styleRows.Font.Name = "Arial";
    //            styleRows.Font.Size = 10;
    //            styleRows.Font.Color = (0 << 16) | (0 << 8) | 0;
    //            styleRows.Interior.Color = (192 << 16) | (192 << 8) | 192;
    //            styleRows.Interior.Pattern = Microsoft.Office.Interop.Excel.XlPattern.xlPatternSolid;
    //        }
    //    }
    //    #endregion

    //    #region STEP 2 : Fill Worksheet With DataView
    //    //Fills an Excel worksheet with the values contained in the DataView
    //    //parameter
    //    private void FillWorksheet_WithDataView()
    //    {
    //        position = 0;
    //        //Add DataView Columns To Worksheet
    //        int row = 1;
    //        int col = 1;

    //        int rowIndex = 1;//记录写入Excel中Row的序号

    //        int allRowsCount = 0;
    //        foreach (DataView dv in dvList)
    //        {
    //            allRowsCount += dv.Count + 1;//列头部有一行
    //        }

    //        foreach (DataView dv in dvList)
    //        {
    //            // Loop thought the columns
    //            for (int i = 0; i < dv.Table.Columns.Count; i++)
    //            {
    //                FillExcelCell(worksheet, row, col++, dv.Table.Columns[i].ToString(), styleColumnHeadings.Name);
    //            }

    //            //Add DataView Rows To Worksheet
    //            row++;
    //            col = 1;
    //            rowIndex++;

    //            for (int i = 0; i < dv.Table.Rows.Count; i++)
    //            {
    //                for (int j = 0; j < dv.Table.Columns.Count; j++)
    //                {
    //                    FillExcelCell(worksheet, row, col++, dv[i][j].ToString(), styleRows.Name);
    //                }

    //                position = (100 * rowIndex) / (allRowsCount);
    //                ProgressEventArgs pe = new ProgressEventArgs(position);
    //                OnProgressChange(pe);

    //               col = 1;
    //               row++;
    //               rowIndex++;
    //            }

    //            row = row + 2;//第二个开始空两行
    //        }
    //    }
    //    #endregion

    //    #region STEP 3 : Fill Individual Cell and Render Using Predefined Style
    //    //Formats the current cell based on the Style setting parameter name
    //    //provided here
    //    //@param worksheet : The worksheet
    //    //@param row : Current row
    //    //@param col : Current Column
    //    //@param Value : The value for the cell
    //    //@param StyleName : The style name to use
    //    private void FillExcelCell(Worksheet worksheet, int row, int col, Object Value, string StyleName)
    //    {
    //        Range rng = (Range)worksheet.Cells[row, col];
    //        rng.Select();
    //        rng.NumberFormat = "@";
    //        rng.Value2 = Value.ToString();
    //        rng.Style = StyleName;
    //        rng.Columns.EntireColumn.AutoFit();
    //        rng.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
    //        rng.Borders.LineStyle = XlLineStyle.xlContinuous;
    //        rng.Borders.ColorIndex = Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic;
    //    }
    //    #endregion

    //    #region STEP 4 : Add Auto Shapes To Excel Worksheet
    //    //Add some WordArt objecs to the Excel worksheet
    //    private void AddAutoShapesToExcel()
    //    {
    //        //Method fields
    //        float txtSize = 80;
    //        float Left = 100.0F;
    //        float Top = 100.0F;
    //        //Have 2 objects
    //        int[] numShapes = new int[2];
    //        Microsoft.Office.Interop.Excel.Shape[] myShapes = new Microsoft.Office.Interop.Excel.Shape[numShapes.Length];

    //        try
    //        {
    //            //loop through the object count
    //            for (int i = 0; i < numShapes.Length; i++)
    //            {
    //                //Add the object to Excel
    //                myShapes[i] = worksheet.Shapes.AddTextEffect(MsoPresetTextEffect.msoTextEffect1, "DRAFT", "Arial Black",
    //                    txtSize, MsoTriState.msoFalse, MsoTriState.msoFalse, (Left * (i * 3)), Top);

    //                //Manipulate the object settings
    //                myShapes[i].Rotation = 45F;
    //                myShapes[i].Fill.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
    //                myShapes[i].Fill.Transparency = 0F;
    //                myShapes[i].Line.Weight = 1.75F;
    //                myShapes[i].Line.DashStyle = MsoLineDashStyle.msoLineSolid;
    //                myShapes[i].Line.Transparency = 0F;
    //                myShapes[i].Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
    //                myShapes[i].Line.ForeColor.RGB = (0 << 16) | (0 << 8) | 0;
    //                myShapes[i].Line.BackColor.RGB = (255 << 16) | (255 << 8) | 255;
    //            }
    //        }
    //        catch// (Exception ex)
    //        {
    //        }

    //    }
    //    #endregion

    //    #region STEP 5 : Select All Used Cells
    //    //Selects all used cells for the Excel worksheet
    //    private void SelectAllUsedCells()
    //    {

    //        Microsoft.Office.Interop.Excel.Range myAllRange = worksheet.Cells;
    //        myAllRange.Select();
    //        myAllRange.CurrentRegion.Select();

    //    }
    //    #endregion

    //    #region STEP 6 : Fill Template With Test Values
    //    //Fills the Excel Template File Selected With A 2D Test Array parameter
    //    private void FillTemplate_WithTestValues()
    //    {
    //        //Initilaise the correct Start Row/Column to match the Template
    //        int StartRow = 3;
    //        int StartCol = 2;

    //        position=0;

    //        // Display the array elements within the Output window, make sure its correct before
    //        for (int i=0; i <= myTemplateValues.GetUpperBound(0); i++) 
    //        {
    //            //loop through array and put into EXCEL template
    //            for (int j = 0 ; j <= myTemplateValues.GetUpperBound(1) ; j++)
    //            {
    //                //update position in progress bar
    //                position = (100 / myTemplateValues.Length) * i;
    //                ProgressEventArgs pe = new ProgressEventArgs(position);
    //                OnProgressChange(pe);

    //                //put into EXCEL template
    //                Range rng = (Range)worksheet.Cells[StartRow,StartCol++];
    //                rng.Select();
    //                rng.NumberFormat = "@";
    //                rng.Value2 = myTemplateValues[i,j].ToString();
    //                rng.Rows.EntireRow.AutoFit();
    //            }
    //            //New row, so column needs to be reset
    //            StartCol=2;
    //            StartRow++;
    //        }
    //    }

    //    #endregion

    //    #region Kill EXCEL
    //    //As a safety check go through all processes and make
    //    //doubly sure excel is shutdown. Working with COM
    //    //have sometimes noticed that the EXL.Quit() call
    //    //does always do the job
    //    private void KillExcel()
    //    {
    //        try
    //        {
    //            Process[] ps = Process.GetProcesses();
    //            foreach (Process p in ps)
    //            {
    //                if (p.ProcessName.ToLower().Equals("excel"))
    //                {
    //                    p.Kill();
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show("错误 " + ex.Message);
    //        }
    //    }

    //    /// <summary>
    //    /// 释放对象内存，推出进程
    //    /// </summary>
    //    /// <param name="obj"></param>
    //    private void NAR(object obj)
    //    {
    //        try
    //        {
    //            Marshal.ReleaseComObject(obj);
    //        }
    //        catch
    //        {
    //        }
    //        finally
    //        {
    //            obj = null;
    //        }
    //    }
    //    #endregion

    //    #region Events
    //    /// Raises the OnProgressChange event for the parent form. 
    //    public virtual void OnProgressChange(ProgressEventArgs e)
    //    {
    //        if (OnProgressHandler != null)
    //        {
    //            // Invokes the delegates. 
    //            OnProgressHandler(this, e);
    //        }
    //    }
    //    #endregion
    //}

    /// <summary>
    /// Provides the ProgressEventArgs 
    /// </summary>
    public class ProgressEventArgs : EventArgs
    {
        #region Instance Fields
        //Instance fields
        private int prgValue = 0;
        #endregion
        #region Public Constructor
        /// Constructs a new ProgressEventArgs object using the parameters provided
        /// @param prgValue : new progress value
        public ProgressEventArgs(int prgValue)
        {
            this.prgValue = prgValue;
        }
        #endregion
        #region Public Methods/Properties

        /// Returns the progress value
        public int ProgressValue
        {
            get { return prgValue; }
        }
        #endregion

    }

}
