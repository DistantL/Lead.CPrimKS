using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>
    /// CSV帮助类<br/>
    /// 20250909
    /// </summary>
    public class CsvHelper
    {
        /// <summary>
        /// 字符串写入到Csv
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="data">待写入字符串</param>
        /// <param name="isReadOnly">True：只读；False：读写；</param>
        /// <param name="IsCreated">True：新建；False：追加；（默认False）</param>
        /// <returns>bool</returns>
        public static bool WriteStringToCsv(string fileName, string data, bool isReadOnly, bool IsCreated = false)
        {
            List<string> list = new List<string>();
            list.Add(data);
            return WriteListStringToCsv(fileName, list, isReadOnly, IsCreated);
        }

        /// <summary>
        /// 字符串写入到Csv
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="data">待写入字符串</param>
        /// <param name="isReadOnly">True：只读；False：读写；</param>
        /// <param name="IsCreated">True：新建；False：追加；（默认False）</param>
        /// <returns>bool</returns>
        public static async Task<bool> WriteStringToCsvAsync(string fileName, string data, bool isReadOnly, bool IsCreated = false)
        {
            List<string> list = new List<string>();
            list.Add(data);
            return await WriteListStringToCsvAsync(fileName, list, isReadOnly, IsCreated);
        }

        /// <summary>
        /// 集合ListString写入到Csv
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="datas">待写入集合ListString</param>
        /// <param name="isReadOnly">True：只读；False：读写；</param>
        /// <param name="IsCreated">True：新建；False：追加；（默认False）</param>
        /// <returns>bool</returns>
        public static bool WriteListStringToCsv(string fileName, List<string> datas, bool isReadOnly, bool IsCreated = false)
        {
            try
            {
                if (datas == null || datas.Count == 0)
                {
                    return false;
                }

                string dir = fileName?.Substring(0, fileName.LastIndexOf("\\"));
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Close();
                    Thread.Sleep(1);
                }

                FileInfo info = new FileInfo(fileName);
                info.Attributes = FileAttributes.Normal;

                using (StreamWriter sw = new StreamWriter(fileName, !IsCreated, Encoding.Default))
                {
                    foreach (var data in datas)
                    {
                        sw.WriteLine(data);
                    }
                    sw.AutoFlush = true;
                }

                if (isReadOnly)
                {
                    info.Attributes = FileAttributes.ReadOnly;
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Warn($"{nameof(CsvHelper)}.{nameof(WriteListStringToCsv)}", ex);
                return false;
            }
        }

        /// <summary>
        /// 集合ListString写入到Csv
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="datas">待写入集合ListString</param>
        /// <param name="isReadOnly">True：只读；False：读写；</param>
        /// <param name="IsCreated">True：新建；False：追加；（默认False）</param>
        /// <returns>bool</returns>
        public static async Task<bool> WriteListStringToCsvAsync(string fileName, List<string> datas, bool isReadOnly, bool IsCreated = false)
        {
            try
            {
                if (datas == null || datas.Count == 0)
                {
                    return false;
                }

                string dir = fileName?.Substring(0, fileName.LastIndexOf("\\"));
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Close();
                    await Task.Delay(1);
                }

                FileInfo info = new FileInfo(fileName);
                info.Attributes = FileAttributes.Normal;

                using (StreamWriter sw = new StreamWriter(fileName, !IsCreated, Encoding.Default))
                {
                    foreach (var data in datas)
                    {
                        await sw.WriteLineAsync(data);
                    }
                    sw.AutoFlush = true;
                }

                if (isReadOnly)
                {
                    info.Attributes = FileAttributes.ReadOnly;
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Warn($"{nameof(CsvHelper)}.{nameof(WriteListStringToCsvAsync)}", ex);
                return false;
            }
        }

        /// <summary>
        /// Csv文件读出到集合ListString
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="encoding">编码方式</param>
        /// <param name="isIgnoreTitle">true：忽略标题；false：不忽略标题；</param>
        /// <param name="datas">集合ListString</param>
        /// <returns>bool</returns>
        public static bool ReadCsvToListString(string fileName, Encoding encoding, bool isIgnoreTitle, out List<string> datas)
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    datas = null;
                    return false;
                }

                if (encoding == null)
                {
                    encoding = Encoding.Default;
                }

                datas = new List<string>();
                FileInfo info = new FileInfo(fileName);
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader sw = new StreamReader(fs, encoding))
                {
                    if (isIgnoreTitle)
                    {
                        sw.ReadLine();
                    }
                    while (!sw.EndOfStream)
                    {
                        string data = sw.ReadLine();
                        if (!string.IsNullOrEmpty(data))
                        {
                            datas.Add(data);
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Warn($"{nameof(CsvHelper)}.{nameof(ReadCsvToListString)}", ex);
                datas = null;
                return false;
            }
        }

        /// <summary>
        /// Csv文件读出到集合ListString
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="encoding">编码方式</param>
        /// <param name="isIgnoreTitle">true：忽略标题；false：不忽略标题；</param>
        /// <returns>bool</returns>
        public static async Task<List<string>> ReadCsvToListStringAsync(string fileName, Encoding encoding, bool isIgnoreTitle)
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    return null;
                }

                if (encoding == null)
                {
                    encoding = Encoding.Default;
                }

                List<string> datas = new List<string>();
                FileInfo info = new FileInfo(fileName);
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader sw = new StreamReader(fs, encoding))
                {
                    if (isIgnoreTitle)
                    {
                        await sw.ReadLineAsync();
                    }
                    while (!sw.EndOfStream)
                    {
                        string data = await sw.ReadLineAsync();
                        if (!string.IsNullOrEmpty(data))
                        {
                            datas.Add(data);
                        }
                    }
                }

                return datas;
            }
            catch (Exception ex)
            {
                LogHelper.Warn($"{nameof(CsvHelper)}.{nameof(ReadCsvToListStringAsync)}", ex);
                return null;
            }
        }

        /// <summary>
        /// 将DataTable写入到Csv文件
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="filePath">CSV文件路径</param>
        /// <param name="isContainTitle">true：包括标题；false：不包括标题；</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>true成功</returns>
        public static bool DataTableToCsvFile(DataTable dt, string filePath, bool isContainTitle = false, Encoding encoding = null)
        {
            string dirPath = filePath?.Substring(0, filePath.LastIndexOf("\\", StringComparison.Ordinal));
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath ?? throw new InvalidOperationException());
            }

            if (encoding == null)
            {
                encoding = Encoding.Default;
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true, encoding))
                {
                    var data = string.Empty;
                    //写出列名称
                    if (isContainTitle)
                    {
                        for (var i = 0; i < dt.Columns.Count; i++)
                        {
                            data += dt.Columns[i].ColumnName;
                            if (i < dt.Columns.Count - 1)
                            {
                                data += ",";
                            }
                        }
                    }

                    sw.WriteLine(data);
                    //写出各行数据
                    for (var i = 0; i < dt.Rows.Count; i++)
                    {
                        data = string.Empty;
                        for (var j = 0; j < dt.Columns.Count; j++)
                        {
                            data += dt.Rows[i][j].ToString();
                            if (j < dt.Columns.Count - 1)
                            {
                                data += ",";
                            }
                        }
                        sw.WriteLine(data);
                    }
                    sw.AutoFlush = true;

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
