using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace DotNet.Utilities
{
    public class DownloadTemplate
    {
        /// <summary>
        /// 下载Excel模板(其实就是将Excel文件从一个路径Copy到另一个路径)
        /// Pcsky 2012.05.01 脱离非托管模式
        /// </summary>
        /// <param name="tempName">Excel文件名</param>
        public static void DownloadExcelTemplate(string tempName)
        {
            try
            {
                string StrPath;
                StrPath = Application.StartupPath + @"\template\" + tempName + @".xls";

                FolderBrowserDialog foler = new FolderBrowserDialog();
                string FileName = "";
                foler.Description = "选择保存模板的目录";
                if (foler.ShowDialog() == DialogResult.OK)
                {
                    if (foler.SelectedPath != "")
                        if (System.IO.File.Exists(StrPath))
                        {
                            FileName = foler.SelectedPath;
                            if (FileName.LastIndexOf(@"\") == (FileName.Length - 1))
                                FileName = foler.SelectedPath + tempName + @".xls";
                            else
                                FileName = foler.SelectedPath + @"\" + tempName + @".xls";

                            if (System.IO.File.Exists(FileName))
                            {
                                MessageBox.Show(foler.SelectedPath + @"  已经存在文件" + tempName + @".xls", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            File.Copy(StrPath, FileName);

                        }
                    if (FileName == "")
                        return;

                    if (MessageBox.Show("模板下载成功,是否打开？ ", AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Process.Start(FileName);
                    }
                }
                else
                {
                    MessageBox.Show("模板下载失败", AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        ///// <summary>
        ///// 下载Excel模板(其实就是将Excel文件从一个路径Copy到另一个路径)
        ///// </summary>
        ///// <param name="tempName">Excel文件名</param>
        //public static void DownloadExcelTemplate(string tempName)
        //{
        //    try
        //    {
        //        string StrPath;
        //        StrPath = Application.StartupPath + @"\template\" + tempName + @".xls";
        //        Excel.Application xlApp = new Excel.Application();
        //        Excel.Worksheet xlSheet;
        //        object missing = System.Reflection.Missing.Value;
        //        Excel.Workbook xlBook = xlApp.Workbooks.Open(StrPath, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
        //        xlSheet = (Excel.Worksheet)xlBook.Worksheets[1];
        //        FolderBrowserDialog foler = new FolderBrowserDialog();
        //        string FileName = "";
        //        foler.Description = "选择保存模板的目录";
        //        if (foler.ShowDialog() == DialogResult.OK)
        //        {
        //            if (foler.SelectedPath != "")
        //                if (System.IO.File.Exists(StrPath))
        //                {
        //                    FileName = foler.SelectedPath;
        //                    if (FileName.LastIndexOf(@"\") == (FileName.Length - 1))
        //                        FileName = foler.SelectedPath + tempName + @".xls";
        //                    else
        //                        FileName = foler.SelectedPath + @"\" + tempName + @".xls";
        //                    if (System.IO.File.Exists(FileName))
        //                    {
        //                        MessageBox.Show(foler.SelectedPath + @"  已经存在文件" + tempName + @".xls", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        return;
        //                    }
        //                    xlSheet.SaveAs(FileName, missing, missing, missing, missing, missing, missing, missing, missing);
        //                }
        //            xlApp.Quit();
        //            if (FileName == "")
        //                return;
        //            Excel.Application newApp = new Excel.Application();
        //            Excel.Workbook newBook;
        //            Excel.Worksheet newSheet;
        //            if (MessageBox.Show("模板下载成功,是否打开？ ", AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
        //            {
        //                newBook = newApp.Workbooks.Open(FileName, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
        //                newSheet = (Excel.Worksheet)newBook.Worksheets[1];
        //                newApp.Visible = true;
        //            } 
        //        }
        //        else
        //        {
        //            xlApp.Quit();
        //            MessageBox.Show("模板下载失败", AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //    catch (Exception err)
        //    {
        //        MessageBox.Show(err.Message, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
    }
}
