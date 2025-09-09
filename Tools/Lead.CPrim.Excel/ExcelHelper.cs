/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: ExcelHelper.cs
 * Author: Victor
 * Description: Excel帮助文件
 * CreateTime: 2022-12-7
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.22.1125><Victor><20221207>
 * 1、初版
******************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Lead.CPrim.Excel
{
    /// <summary>Excel帮助类
    /// <para>将字符串写入到Excel文件 => WriteStringToExcel</para>
    /// <para>将集合ListString写入到Excel文件 => WriteListStringToExcel</para>
    /// <para>将Excel文件读出到集合ListString => ReadExcelToListString</para>
    /// <para></para>
    /// <para></para>
    /// <para></para>
    /// <para></para></summary>
    public class ExcelHelper
    {
        /// <summary>将字符串写入到Excel文件</summary>
        /// <param name="fileName">Excel文件地址</param>
        /// <param name="data">字符串（用英文,号进行分割）</param>
        /// <param name="isReadOnly">true：只读；false：读写</param>
        /// <param name="style">需要改变样式的列数组</param>
        /// <returns>bool</returns>
        public static bool WriteStringToExcel(string fileName, string data, bool isReadOnly, params int[] style)
        {
            try
            {
                if (string.IsNullOrEmpty(data))
                {
                    return false;
                }

                string dirPath = fileName?.Substring(0, fileName.LastIndexOf("\\"));
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Close();
                }

                FileInfo fi = new FileInfo(fileName);
                fi.Attributes = FileAttributes.Normal;

                ExcelPackage excel = new ExcelPackage(new FileInfo(fileName));
                ExcelWorksheets workSheets = excel.Workbook.Worksheets;
                ExcelWorksheet worksheet;
                int startRow = 0;
                if (workSheets.Count > 0)
                {
                    worksheet = workSheets[0];
                    startRow = worksheet.Dimension.Rows + 1;
                }
                else
                {
                    worksheet = workSheets.Add("Sheet1");
                    startRow = 1;
                }
                string[] temp = data.Split(new char[] { ',' });
                for (int i = 0; i < temp.Length; i++)
                {
                    var currentCell = worksheet.Cells[startRow, i + 1];
                    currentCell.Value = temp[i];
                }
                foreach (int item in style)
                {
                    if(item > temp.Length)
                    {
                        continue;
                    }

                    var currentCell = worksheet.Cells[startRow, item];
                    currentCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    currentCell.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
                }
                excel.Save();
                excel.Dispose();

                if (isReadOnly)
                {
                    fi.Attributes = FileAttributes.ReadOnly;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>将集合ListString写入到Excel文件</summary>
        /// <param name="fileName">Excel文件地址</param>
        /// <param name="data">字符串集合（字符串用英文,号进行分割）</param>
        /// <param name="isReadOnly">true：只读；false：读写</param>
        /// <param name="strSplit"></param>
        /// <returns>bool</returns>
        public static bool WriteListStringToExcel(string fileName, List<string> data, bool isReadOnly, string strSplit = ",")
        {
            try
            {
                if (data == null || data.Count == 0)
                {
                    return false;
                }

                string dirPath = fileName?.Substring(0, fileName.LastIndexOf("\\"));
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Close();
                }

                FileInfo fi = new FileInfo(fileName);
                fi.Attributes = FileAttributes.Normal;

                ExcelPackage excel = new ExcelPackage(fi);
                ExcelWorksheets workSheets = excel.Workbook.Worksheets;
                ExcelWorksheet worksheet;
                int startRow = 0;
                if (workSheets.Count > 0)
                {
                    worksheet = workSheets[0];
                    startRow = worksheet.Dimension.Rows + 1;
                }
                else
                {
                    worksheet = workSheets.Add("Sheet1");
                    startRow = 1;
                }
                foreach (var item in data)
                {
                    if(string.IsNullOrEmpty(item))
                    {
                        continue;
                    }
                    string[] temp = item.Split(new string[] { strSplit }, StringSplitOptions.None);
                    for (int i = 0; i < temp.Length; i++)
                    {
                        var currentCell = worksheet.Cells[startRow, i + 1];
                        currentCell.Value = temp[i];
                    }
                    startRow++;
                }
                excel.Save();
                excel.Dispose();

                if (isReadOnly)
                {
                    fi.Attributes = FileAttributes.ReadOnly;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>指定单元格值加1写入到Excel文件</summary>
        /// <param name="fileName">Excel文件地址</param>
        /// <param name="row">行</param>
        /// <param name="column">列</param>
        /// <param name="isReadOnly">true：只读；false：读写</param>
        /// <returns>bool</returns>
        public static bool WriteValueAddOneToExcel(string fileName, int row, int column, bool isReadOnly)
        {
            try
            {
                string dirPath = fileName?.Substring(0, fileName.LastIndexOf("\\"));
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Close();
                }

                FileInfo fi = new FileInfo(fileName);
                fi.Attributes = FileAttributes.Normal;

                ExcelPackage excel = new ExcelPackage(new FileInfo(fileName));
                ExcelWorksheets workSheets = excel.Workbook.Worksheets;
                ExcelWorksheet worksheet;
                int startRow = 0;
                if (workSheets.Count > 0)
                {
                    worksheet = workSheets[0];
                    startRow = worksheet.Dimension.Rows + 1;
                }
                else
                {
                    worksheet = workSheets.Add("Sheet1");
                    startRow = 1;
                }
                int currentValue;
                var currentCell = worksheet.Cells[row, column];
                if(!string.IsNullOrEmpty(currentCell.Value?.ToString()) && int.TryParse(currentCell.Value.ToString(), out currentValue))
                {
                    currentCell.Value = ++currentValue;
                }
                excel.Save();
                excel.Dispose();

                if (isReadOnly)
                {
                    fi.Attributes = FileAttributes.ReadOnly;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 将Excel文件读出到集合ListString
        /// </summary>
        /// <param name="fileName">Excel文件地址</param>
        /// <param name="workSheetName">工作表名称</param>
        /// <param name="encoding">编码方式</param>
        /// <param name="isReadFirstLine">true：读取第一行；false：不读取第一行</param>
        /// <param name="data">字符串集合</param>
        /// <param name="strSplit">默认英文,</param>
        /// <returns>bool</returns>
        public static bool ReadExcelToListString(string fileName, string workSheetName, Encoding encoding, bool isReadFirstLine, out List<string> data, string strSplit = ",")
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    data = null;
                    return false;
                }

                List<string> listString = new List<string>();
                ExcelWorksheet currentWorkSheet = null;
                ExcelPackage excel = new ExcelPackage(new FileInfo(fileName));
                foreach (var item in excel.Workbook.Worksheets)
                {
                    if (item.Name == workSheetName)
                    {
                        currentWorkSheet = item;
                        break;
                    }
                }
                if (currentWorkSheet == null)
                {
                    throw new Exception("WorkSheet不存在");
                }
                int rows = currentWorkSheet.Dimension.Rows;
                int columns = currentWorkSheet.Dimension.Columns;
                FileInfo fi = new FileInfo(fileName);
                for (int i = 1; i <= rows; i++)
                {
                    if (i == 1 && !isReadFirstLine)
                    {
                        i++;
                    }

                    StringBuilder text = new StringBuilder();
                    for (int j = 1; j <= columns; j++)
                    {
                        text.Append(currentWorkSheet.Cells[i, j].Value);
                        if (j < columns)
                        {
                            text.Append(strSplit);
                        }
                    }
                    listString.Add(text.ToString());
                }
                excel.Dispose();

                data = listString;
                return true;
            }
            catch
            {
                data = null;
                return false;
            }
        }
    }
}
