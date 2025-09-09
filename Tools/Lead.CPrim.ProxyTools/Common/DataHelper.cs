/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: DataHelper.cs
 * Author: Victor
 * Description: 数据转换帮助类
 * CreateTime: 2023-1-2
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.23.0101><Victor><20230102>
 * 1、ListToDataTable增加自定义排序
******************************************************************************/

using Lead.CPrim.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>
    /// 数据处理类
    /// </summary>
    public static class DataHelper
    {
        static readonly object objWrite = new object();



        /// <summary>List转化为DataTable</summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="list">集合</param>
        /// <returns>DataTable</returns>
        public static DataTable ListToDataTable<T>(this List<T> list) where T : class
        {
            if (list == null)
            {
                return null;
            }

            DataTable newDt = new DataTable();
            PropertyInfo[] propInfo = null;
            Dictionary<int, string> dicColName = GetDataTableColumns(list, ref propInfo, ref newDt);
            if (propInfo == null || propInfo.Length <= 0)
            {
                return null;
            }

            foreach (T item in list)
            {
                object[] values = GetDataTableRowValue(item, propInfo, dicColName);
                if (values == null || values.Length <= 0)
                {
                    return null;
                }
                newDt.Rows.Add(values);
            }
            return newDt;
        }

        /// <summary>string→DataType</summary>
        /// <param name="dtType">string</param>
        /// <returns>DataType</returns>
        public static DataType StringToDataType(string dtType)
        {
            DataType type = DataType.Other;
            Enum.TryParse(dtType, out type);
            return type;
        }

        /// <summary>string→DataReadMode</summary>
        /// <param name="dtRdModeStr">string</param>
        /// <returns>DataReadMode</returns>
        public static DataReadMode StringToDataReadMode(string dtRdModeStr)
        {
            DataReadMode rdMode = DataReadMode.Other;
            Enum.TryParse(dtRdModeStr, out rdMode);
            return rdMode;
        }

        /// <summary>string→DataPermission</summary>
        /// <param name="dtPermissionStr">string</param>
        /// <returns>DataPermission</returns>
        public static DataPermission StringToPermission(string dtPermissionStr)
        {
            DataPermission rdPermission = DataPermission.Other;
            Enum.TryParse(dtPermissionStr, out rdPermission);
            return rdPermission;
        }

        /// <summary>
        /// string→object by DataType
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object StringToObjectByDataType(this string value, DataType type)
        {
            object val = null;
            try
            {
                switch (type)
                {
                    case DataType.BOOL:
                        val = bool.Parse(value);
                        break;

                    case DataType.INT:
                        val = int.Parse(value);
                        break;

                    case DataType.DOUBLE:
                        val = double.Parse(value);
                        break;

                    case DataType.STRING:
                        val = value;
                        break;

                    default:
                        break;
                }
            }
            catch
            {
                return null;
            }
            return val;
        }

        /// <summary>string→ProtocolDataType</summary>
        /// <param name="dtProtocolDataType">string</param>
        /// <returns>ProtocolDataType</returns>
        public static ProtocolDataType StringToProtocolDataType(string dtProtocolDataType)
        {
            ProtocolDataType type = ProtocolDataType.OTHER;
            Enum.TryParse(dtProtocolDataType, out type);
            return type;
        }

        /// <summary>获取DataTableColumns</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">集合</param>
        /// <param name="propInfo">排序后PropertyInfo[]</param>
        /// <param name="newDt">DataTable</param>
        /// <returns>DataTableColumns</returns>
        public static Dictionary<int, string> GetDataTableColumns<T>(List<T> list, ref PropertyInfo[] propInfo, ref DataTable newDt)
        {
            Dictionary<int, string> dicColName = new Dictionary<int, string>();
            string[] order = new string[] { "Date", "Shift", "Unit SN", "Component SN", "Start Time", "End Time", "Pass","CT/s" };
            PropertyInfo[] propInfoTemp = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            if (propInfoTemp.Length <= 0)
            {
                return null;
            }

            propInfo = PropOrder(propInfoTemp, order);
            foreach (PropertyInfo p in propInfo)
            {
                if (p.PropertyType.Name.Contains("List"))
                {
                    IEnumerable<object> listVal = p.GetValue(list[0], null) as IEnumerable<object>;
                    if (listVal == null)
                    {
                        continue;
                    }
                    int i = 1;
                    foreach (object listItem in listVal)
                    {
                        newDt.Columns.Add(p.Name + i);
                        dicColName.Add(newDt.Columns.Count - 1, p.Name + i);
                        i++;
                    }
                }
                else if (p.PropertyType.Name.Contains("Dictionary"))
                {
                    IDictionary<object, object> dicVal = p.GetValue(list[0], null) as IDictionary<object, object>;
                    if (dicVal == null)
                    {
                        continue;
                    }

                    foreach (KeyValuePair<object, object> dicItem in dicVal)
                    {
                        newDt.Columns.Add(p.Name + "." + dicItem.Key);
                        dicColName.Add(newDt.Columns.Count - 1, p.Name + "." + dicItem.Key);
                    }
                }
                else
                {
                    newDt.Columns.Add(p.Name);
                    dicColName.Add(newDt.Columns.Count - 1, p.Name);
                }
            }
            return dicColName;
        }

        /// <summary>获取DataTableColumns</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">集合</param>
        /// <param name="propInfo">排序后PropertyInfo[]</param>
        /// <returns>DataTableColumns</returns>
        public static Dictionary<int, string> GetDataTableColumns<T>(List<T> list, ref PropertyInfo[] propInfo)
        {
            DataTable newDt = new DataTable();
            return GetDataTableColumns(list, ref propInfo, ref newDt);
        }

        /// <summary>PropertyInfo数组重新排序</summary>
        /// <param name="propsAll">PropertyInfo数组</param>
        /// <param name="defineOrders">自定义顺序</param>
        /// <returns>PropertyInfo数组</returns>
        public static PropertyInfo[] PropOrder(PropertyInfo[] propsAll, params string[] defineOrders)
        {
            if (propsAll == null || defineOrders == null || propsAll.Length <= 0 || defineOrders.Length <= 0)
            {
                return null;
            }
            List<PropertyInfo> lPropsTemp = new List<PropertyInfo>();
            List<PropertyInfo> lProps = propsAll.ToList();
            foreach (string prop in defineOrders)
            {
                PropertyInfo info = lProps.FirstOrDefault(p => p.Name == prop);
                if (info != null)
                {
                    lPropsTemp.Add(info);
                }
            }
            foreach (PropertyInfo prop in propsAll)
            {
                PropertyInfo info = lPropsTemp.FirstOrDefault(p => p.Name == prop.Name);
                if (info == null)
                {
                    lPropsTemp.Add(prop);
                }
            }
            return lPropsTemp.ToArray();
        }

        /// <summary>获取DataTableRowValue</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="propInfo">PropertyInfo数组</param>
        /// <param name="dicColName">DataTableColumns</param>
        /// <returns>object[]</returns>
        public static object[] GetDataTableRowValue<T>(T item, PropertyInfo[] propInfo, Dictionary<int, string> dicColName)
        {
            object[] values = new object[dicColName.Count];
            foreach (PropertyInfo p in propInfo)
            {
                if (p.PropertyType.Name.Contains("List"))
                {
                    IEnumerable<object> listVal = p.GetValue(item, null) as IEnumerable<object>;
                    if (listVal == null)
                    {
                        continue;
                    }

                    int j = 1;
                    foreach (object listItem in listVal)
                    {
                        int colIndex3 = dicColName.FirstOrDefault((KeyValuePair<int, string> x) => x.Value == p.Name + j).Key;
                        values[colIndex3] = listItem;
                        j++;
                    }
                }
                else if (p.PropertyType.Name.Contains("Dictionary"))
                {
                    IDictionary<object, object> dicVal = p.GetValue(item, null) as IDictionary<object, object>;
                    if (dicVal == null)
                    {
                        continue;
                    }

                    foreach (KeyValuePair<object, object> dicItem in dicVal)
                    {
                        int colIndex = dicColName.FirstOrDefault((KeyValuePair<int, string> x) => x.Value == p.Name + "." + dicItem.Key).Key;
                        values[colIndex] = dicItem.Value;
                    }
                }
                else
                {
                    int colIndex = dicColName.FirstOrDefault((KeyValuePair<int, string> x) => x.Value == p.Name).Key;
                    values[colIndex] = p.GetValue(item, null);
                }
            }
            return values;
        }

        /// <summary>类数据复制</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T CopyClass<T>(this T t) where T : new()
        {
            if (t == null)
            {
                return default(T);
            }

            PropertyInfo[] piSource = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            PropertyInfo[] piTarget = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            if (piTarget.Length == 0)
            {
                return default(T);
            }

            T setT = new T();
            foreach (PropertyInfo itemTarget in piTarget)
            {
                foreach (PropertyInfo itemSource in piSource)
                {
                    if (itemTarget.Name == itemSource.Name)
                    {
                        itemTarget.SetValue(setT, itemSource.GetValue(t, null), null);
                    }
                }
            }
            return setT;
        }

        /// <summary>文件写入</summary>
        /// <param name="path"></param>
        /// <param name="value"></param>
        public static bool WriteFile(string path, string value)
        {
            bool ret = false;
            try
            {
                if (string.IsNullOrEmpty(path))
                {
                    throw new Exception("地址为空");
                }
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(value);
                    sw.AutoFlush = true;
                }
                ret = true;
            }
            catch (Exception ex)
            {
                LogHelper.LogAdd(LogLevel.Warn, $"WriteFile失败：{ex.Message}", PrimLogId.Tool.ToString());
            }
            return ret;
        }

        /// <summary>
        /// 获取指定层级命名空间/类/方法名<br/>
        /// 2：调用方法的上一级</summary>
        /// <param name="msg"></param>
        /// <param name="floor">指定层级</param>
        public static void GetNamespaceClassMethodName(ref string msg, int floor = 2)
        {
            StackTrace st = new StackTrace();
            StackFrame[] sfs = st.GetFrames();

            if (sfs.Length > floor)
            {
                string namespaceName = sfs[floor].GetMethod().DeclaringType.Namespace;
                string className = sfs[floor].GetMethod().DeclaringType.Name;
                string methodName = sfs[floor].GetMethod().Name;

                msg = $"[{namespaceName}].[{className}].[{methodName}]\n\n{msg}";
            }
        }

        /// <summary>
        /// 文件写入<br/>
        /// 支持高并发
        /// </summary>
        /// <param name="path">文件地址</param>
        /// <param name="value">追加内容</param>
        /// <param name="isAppendNewLine">true：追加换行；false：不追加换行</param>
        /// <param name="append">true：追加；false：覆盖</param>
        public static void WriteFile(string path, string value, bool isAppendNewLine = true, bool append = true)
        {
            try
            {
                lock (objWrite)
                {
                    string dir = path.Substring(0, path.LastIndexOf('\\'));
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                    if (!File.Exists(path))
                    {
                        using var fs = File.Create(path);
                    }

                    using (var sw = new StreamWriter(path, append))
                    {
                        sw.WriteLine(isAppendNewLine ? value + Environment.NewLine : value);
                        sw.AutoFlush = true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogAdd(LogLevel.Warn, $"WriteFile失败：{ex.Message}", PrimLogId.Tool.ToString());
            }
        }

        /// <summary>
        /// 文件写入<br/>
        /// 支持高并发
        /// </summary>
        /// <param name="path">文件地址</param>
        /// <param name="value">追加内容</param>
        /// <param name="isAppendNewLine">true：追加换行；false：不追加换行</param>
        public static void WriteFileNotAppend(string path, string value, bool isAppendNewLine = true)
        {
            WriteFile(path, value, isAppendNewLine, false);
        }
    }
}
