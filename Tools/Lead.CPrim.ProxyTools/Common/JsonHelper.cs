/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: JsonHelper.cs
 * Author: Victor
 * Description: Json 文件读取类
 * CreateTime: 2020-01-01
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.22.1017><Victor><20221024>
 * 1、文件判断进行优化
******************************************************************************/

using Lead.CPrim.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>
    /// Json
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// 本地文件目录→object（方法一）（反序列化）
        /// </summary>
        /// <typeparam name="T">转换类型</typeparam>
        /// <param name="jsonFilePath">文件目录</param>
        /// <returns>T</returns>
        [Obsolete]
        public static T DeserializeJsonFileToObjectByInterface<T>(string jsonFilePath) where T : class
        {
            if (string.IsNullOrEmpty(jsonFilePath))
            {
                return null;
            }

            if (!File.Exists(jsonFilePath))
            {
                return null;
            }

            JsonSerializer val = new JsonSerializer() { TypeNameHandling = TypeNameHandling.All };
            try
            {
                using (StreamReader streamReader = File.OpenText(jsonFilePath))
                using (StringReader stringReader = new StringReader(streamReader.ReadToEnd()))
                {
                    object obj = val.Deserialize((JsonReader)(object)new JsonTextReader(stringReader), typeof(T));
                    return obj as T;
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 本地文件目录→T（方法一）（反序列化）
        /// </summary>
        /// <typeparam name="T">转换类型</typeparam>
        /// <param name="jsonFilePath">文件目录</param>
        /// <param name="ver"></param>
        /// <returns></returns>
        public static T DeserializeJsonFileToObjectByInterface<T>(string jsonFilePath, string ver = "1.0") where T : class
        {
            if (string.IsNullOrEmpty(jsonFilePath))
            {
                return null;
            }

            if (!File.Exists(jsonFilePath))
            {
                return null;
            }

            try
            {
                #region 屏蔽
                //方法一
                //string text = File.ReadAllText(jsonFilePath);
                //return JsonConvert.DeserializeObject<T>(text, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

                //方法二
                //using (StreamReader sr = new StreamReader(jsonFilePath, Encoding.Unicode))
                //{
                //    string text = sr.ReadToEnd();
                //    return JsonConvert.DeserializeObject<T>(text, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                //} 
                #endregion

                //方法三
                using (FileStream fs = new FileStream(jsonFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                {
                    string text = sr.ReadToEnd();
                    return JsonConvert.DeserializeObject<T>(text, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// object→本地文件目录（方法一）（序列化）
        /// </summary>
        /// <param name="o">object</param>
        /// <param name="jsonFilePath">文件目录</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>bool</returns>
        public static bool SerializeObjectToFileByInterface(object o, string jsonFilePath, Encoding encoding = null)
        {
            if (string.IsNullOrEmpty(jsonFilePath))
            {
                return false;
            }

            if (encoding == null)
            {
                encoding = Encoding.Unicode;
            }

            string text = jsonFilePath?.Substring(0, jsonFilePath.LastIndexOf("\\", StringComparison.Ordinal));
            if (!Directory.Exists(text)) Directory.CreateDirectory(text ?? throw new InvalidOperationException());

            bool result = true;
            string value = JsonConvert.SerializeObject(o, (Formatting)1, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
            try
            {
                using (FileStream stream = new FileStream(jsonFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                using (StreamWriter streamWriter = new StreamWriter(stream, encoding))
                {
                    streamWriter.NewLine = "\r\n";
                    streamWriter.Write(value);
                }
            }
            catch
            {
                result = false;
            }

            return result;
        }
        /// <summary>
        /// 本地文件目录→T（方法二）（反序列化）
        /// </summary>
        /// <typeparam name="T">转换类型</typeparam>
        /// <param name="jsonFilePath">文件目录</param>
        /// <returns></returns>
        public static T DeserializeJsonFileToObject<T>(string jsonFilePath) where T : class
        {
            try
            {
                if (string.IsNullOrEmpty(jsonFilePath))
                {
                    throw new Exception("路径为空");
                }

                if (!File.Exists(jsonFilePath))
                {
                    throw new Exception("路径[" + jsonFilePath + "]不存在");
                }

                JsonSerializer val = new JsonSerializer();
                using (StreamReader streamReader = File.OpenText(jsonFilePath))
                using (StringReader stringReader = new StringReader(streamReader.ReadToEnd()))
                {
                    object obj = val.Deserialize(new JsonTextReader(stringReader), typeof(T));
                    return obj as T;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogAdd(LogLevel.Warn, $"DeserializeJsonFileToObject -> {ex.Message}", PrimLogId.Tool.ToString());
                return null;
            }
        }
        /// <summary>
        /// object→本地文件目录（方法二）（序列化）
        /// </summary>
        /// <param name="o">object</param>
        /// <param name="jsonFilePath">文件目录</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>bool</returns>
        public static bool SerializeObjectToFile(object o, string jsonFilePath, Encoding encoding = null)
        {
            bool result = false;
            try
            {
                if (string.IsNullOrEmpty(jsonFilePath))
                {
                    throw new Exception("路径为空");
                }

                if (encoding == null)
                {
                    encoding = Encoding.Unicode;
                }

                FileInfo info = new FileInfo(jsonFilePath);
                if (info == null)
                {
                    throw new Exception("文件格式有误");
                }
                if (!Directory.Exists(info.DirectoryName))
                {
                    Directory.CreateDirectory(info.DirectoryName);
                }

                string value = JsonConvert.SerializeObject(o, (Formatting)1);
                using (FileStream stream = new FileStream(jsonFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                using (StreamWriter streamWriter = new StreamWriter(stream, encoding))
                {
                    streamWriter.NewLine = "\r\n";
                    streamWriter.Write(value);
                }
                result = true;
            }
            catch (Exception ex)
            {
                LogHelper.LogAdd(LogLevel.Warn, $"SerializeObjectToFile -> {ex.Message}", PrimLogId.Tool.ToString());
            }

            return result;
        }
        /// <summary>
        /// object→string（序列化）
        /// </summary>
        /// <param name="o">object</param>
        /// <returns>string</returns>
        public static string SerializeObject(object o)
        {
            if (o == null)
            {
                return null;
            }

            JsonSerializerSettings val = new JsonSerializerSettings()
            {
                DefaultValueHandling = (DefaultValueHandling)1,
                NullValueHandling = (NullValueHandling)1
            };
            return JsonConvert.SerializeObject(o, (Formatting)1, val);
        }
        /// <summary>
        /// string→T（泛型反序列化）
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="json">string</param>
        /// <returns>T</returns>
        public static T DeserializeJsonToObject<T>(string json) where T : class
        {
            if (string.IsNullOrEmpty(json))
            {
                return null;
            }

            JsonSerializer val = new JsonSerializer();
            StringReader stringReader = new StringReader(json);
            object obj = val.Deserialize(new JsonTextReader(stringReader), typeof(T));
            return obj as T;
        }
        /// <summary>
        /// string→object（反序列化）<br/>
        /// 1、此方法反序列化后不能转化为类
        /// </summary>
        /// <param name="json">string</param>
        /// <returns>object</returns>
        public static object DeserializeJsonToObject(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return null;
            }

            JsonSerializer val = new JsonSerializer();
            StringReader stringReader = new StringReader(json);
            return val.Deserialize(new JsonTextReader(stringReader));
        }
        /// <summary>
        /// 通过Json序列化、反序列化实现深拷贝<br/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T DeepCopyByJson<T>(this T t) where T : class
        {
            if (t == null)
            {
                return default;
            }

            var json = JsonConvert.SerializeObject(t);
            return JsonConvert.DeserializeObject<T>(json);
        }





        public static T DeserializeAnonymousType<T>(string json, T anonymousTypeObject)
        {
            return JsonConvert.DeserializeAnonymousType<T>(json, anonymousTypeObject);
        }

        public static List<T> DeserializeJsonToList<T>(string json) where T : class
        {
            if (string.IsNullOrEmpty(json))
            {
                return null;
            }

            JsonSerializer val = (JsonSerializer)(object)new JsonSerializer();
            StringReader stringReader = new StringReader(json);
            object obj = val.Deserialize((JsonReader)(object)new JsonTextReader((TextReader)stringReader), typeof(List<T>));
            return obj as List<T>;
        }
    }
}
