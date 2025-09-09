using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
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
            return Excel.ExcelHelper.WriteStringToExcel(fileName, data, isReadOnly, style);
        }
        /// <summary>将集合ListString写入到Excel文件</summary>
        /// <param name="fileName">Excel文件地址</param>
        /// <param name="data">字符串集合（字符串用英文,号进行分割）</param>
        /// <param name="isReadOnly">true：只读；false：读写</param>
        /// <param name="strSplit"></param>
        /// <returns>bool</returns>
        public static bool WriteListStringToExcel(string fileName, List<string> data, bool isReadOnly, string strSplit = ",")
        {
            return Excel.ExcelHelper.WriteListStringToExcel(fileName, data, isReadOnly, strSplit);
        }
        /// <summary>指定单元格值加1写入到Excel文件</summary>
        /// <param name="fileName">Excel文件地址</param>
        /// <param name="row">行</param>
        /// <param name="column">列</param>
        /// <param name="isReadOnly">true：只读；false：读写</param>
        /// <returns>bool</returns>
        public static bool WriteValueAddOneToExcel(string fileName, int row, int column, bool isReadOnly)
        {
            return Excel.ExcelHelper.WriteValueAddOneToExcel(fileName, row, column, isReadOnly);
        }
        /// <summary>
        /// 将Excel文件读出到集合ListString
        /// </summary>
        /// <param name="fileName">Excel文件地址</param>
        /// <param name="workSheetName">工作表名称</param>
        /// <param name="encoding">编码方式</param>
        /// <param name="isReadFirstLine">true：读取第一行；false：不读取第一行</param>
        /// <param name="data">字符串集合（字符串用英文,号进行分割）</param>
        /// <param name="strSplit">默认英文,</param>
        /// <returns>bool</returns>
        public static bool ReadExcelToListString(string fileName, string workSheetName, Encoding encoding, bool isReadFirstLine, out List<string> data, string strSplit = ",")
        {
            return Excel.ExcelHelper.ReadExcelToListString(fileName, workSheetName, encoding, isReadFirstLine, out data, strSplit);
        }
    }
}
