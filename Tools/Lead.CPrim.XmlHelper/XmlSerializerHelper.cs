using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Lead.CPrim.XmlHelper
{
    /// <summary>XmlSerializerHelper帮助类</summary>
    public class XmlSerializerHelper
    {
        /// <summary>object→XML并保存</summary>
        /// <param name="myDs">object</param>
        /// <param name="XmlFilePath">地址</param>
        /// <param name="type">类型</param>
        /// <returns>bool</returns>
        public static bool WriteXML(object myDs, string XmlFilePath, Type type)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(XmlFilePath, append: false))
                {
                    XmlSerializer serializer = new XmlSerializer(type);
                    serializer.Serialize(writer, myDs);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>XML→object</summary>
        /// <param name="XmlFilePath">地址</param>
        /// <param name="type">类型</param>
        /// <returns>object</returns>
        public static object ReadXML(string XmlFilePath, Type type)
        {
            object object4Read = null;
            if (!File.Exists(XmlFilePath)) return null;
            while (object4Read == null)
            {
                try
                {
                    using (FileStream stream = new FileStream(XmlFilePath, FileMode.Open))
                    {
                        XmlSerializer serializer = new XmlSerializer(type);
                        object4Read = serializer.Deserialize(stream);
                    }
                }
                catch
                {
                    return null;
                }
            }
            return object4Read;
        }
        /// <summary>XML→object（原名：XmlDeserializeFromFile）</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="path">地址</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>object</returns>
        public static T ReadXML<T>(string path, Encoding encoding)
        {
            try
            {
                if (string.IsNullOrEmpty(path) || encoding == null)
                {
                    return default(T);
                }

                string xml = File.ReadAllText(path, encoding);
                XmlSerializer mySerializer = new XmlSerializer(typeof(T));
                using (MemoryStream ms = new MemoryStream(encoding.GetBytes(xml)))
                using (StreamReader sr = new StreamReader(ms, encoding))
                {
                    return (T)mySerializer.Deserialize(sr);
                }
            }
            catch
            {
                return default(T);
            }
        }








        /// <summary>
        /// XMLs the serialize internal.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="o">The o.</param>
        /// <param name="encoding">The encoding.</param>
        /// <exception cref="T:System.ArgumentNullException"></exception>
        private static void XmlSerializeInternal(Stream stream, object o, Encoding encoding)
        {
            if (o == null)
            {
                throw new ArgumentNullException("o");
            }
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding");
            }
            XmlSerializer serializer = new XmlSerializer(o.GetType());
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineChars = "\r\n";
            settings.Encoding = encoding;
            settings.IndentChars = "    ";
            XmlWriter writer = XmlWriter.Create(stream, settings);
            serializer.Serialize(writer, o);
            writer.Close();
        }
        /// <summary>
        /// Bytes to string.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>System.String.</returns>
        public static string ByteToString(byte[] data)
        {
            return Encoding.Default.GetString(data);
        }
        /// <summary>
        /// 字符串压缩
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>System.Byte[].</returns>
        /// <exception cref="T:System.Exception"></exception>
        public static byte[] Compress(byte[] data)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                GZipStream zip = new GZipStream(ms, CompressionMode.Compress, leaveOpen: true);
                zip.Write(data, 0, data.Length);
                zip.Close();
                byte[] buffer = new byte[ms.Length];
                ms.Position = 0L;
                ms.Read(buffer, 0, buffer.Length);
                ms.Close();
                return buffer;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// string 压缩
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>System.String.</returns>
        public static string CompressString(string str)
        {
            byte[] compressBeforeByte = Encoding.GetEncoding("UTF-8").GetBytes(str);
            byte[] compressAfterByte = Compress(compressBeforeByte);
            return Convert.ToBase64String(compressAfterByte);
        }
        /// <summary>
        /// 字符串解压缩
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>System.Byte[].</returns>
        /// <exception cref="T:System.Exception"></exception>
        public static byte[] Decompress(byte[] data)
        {
            try
            {
                MemoryStream ms = new MemoryStream(data);
                GZipStream zip = new GZipStream(ms, CompressionMode.Decompress, leaveOpen: true);
                MemoryStream msreader = new MemoryStream();
                byte[] buffer = new byte[4096];
                while (true)
                {
                    int reader = zip.Read(buffer, 0, buffer.Length);
                    if (reader <= 0)
                    {
                        break;
                    }
                    msreader.Write(buffer, 0, reader);
                }
                zip.Close();
                ms.Close();
                msreader.Position = 0L;
                buffer = msreader.ToArray();
                msreader.Close();
                return buffer;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// string 解压缩
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>System.String.</returns>
        public static string DecompressString(string str)
        {
            byte[] compressBeforeByte = Convert.FromBase64String(str);
            byte[] compressAfterByte = Decompress(compressBeforeByte);
            return Encoding.GetEncoding("UTF-8").GetString(compressAfterByte);
        }
        /// <summary>
        /// 把字节反序列化成相应的对象
        /// </summary>
        /// <param name="pBytes">字节流</param>
        /// <returns>object</returns>
        public static object DeserializeObject(byte[] pBytes)
        {
            object _newOjb = null;
            if (pBytes == null)
            {
                return _newOjb;
            }
            MemoryStream _memory = new MemoryStream(Decompress(pBytes));
            _memory.Position = 0L;
            BinaryFormatter formatter = new BinaryFormatter();
            _newOjb = formatter.Deserialize(_memory);
            _memory.Close();
            return _newOjb;
        }
        /// <summary>
        /// Des the XML serialize.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlString">The XML string.</param>
        /// <returns>T.</returns>
        public static T DeXMLSerialize<T>(string xmlString)
        {
            StringBuilder buffer = new StringBuilder();
            buffer.Append(xmlString);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            TextReader reader = new StringReader(buffer.ToString());
            object obj = serializer.Deserialize(reader);
            return (T)obj;
        }
        /// <summary>
        /// Read byte from file
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] ReadByteFromFile(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            long size = fs.Length;
            byte[] array = new byte[size];
            fs.Read(array, 0, array.Length);
            fs.Close();
            return array;
        }
        /// <summary>
        /// Read object from file
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>System.Object.</returns>
        public static object ReadObjectFromFile(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            long size = fs.Length;
            byte[] array = new byte[size];
            fs.Read(array, 0, array.Length);
            fs.Close();
            return DeserializeObject(array);
        }
        /// <summary>
        /// 把对象序列化为字符串
        /// </summary>
        /// <param name="pObj">The p object.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] SerializeObject(object pObj)
        {
            if (pObj == null)
            {
                return null;
            }
            MemoryStream _memory = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(_memory, pObj);
            _memory.Position = 0L;
            byte[] read = new byte[_memory.Length];
            _memory.Read(read, 0, read.Length);
            _memory.Close();
            return Compress(read);
        }
        /// <summary>
        /// Strings to byte.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] StringToByte(string value)
        {
            return Encoding.Default.GetBytes(value);
        }
        /// <summary>
        /// Write byte[] to file
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        /// <param name="filePath">The file path.</param>
        public static void WriteByteToFile(byte[] dataSource, string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Create);
            fs.Write(dataSource, 0, dataSource.Length);
            fs.Close();
        }
        /// <summary>
        /// Write object to file
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        /// <param name="filePath">The file path.</param>
        public static void WriteObjectToFile(object dataSource, string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Create);
            byte[] arraysource = SerializeObject(dataSource);
            fs.Write(arraysource, 0, arraysource.Length);
            fs.Close();
        }
        /// <summary>
        /// XMLs the configuration reader.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        public static object XmlConfigReader(string filePath, Type type)
        {
            object result = null;
            try
            {
                if (File.Exists(filePath))
                {
                    StreamReader reader = new StreamReader(filePath);
                    XmlSerializer xmlSerializer = new XmlSerializer(type);
                    result = xmlSerializer.Deserialize(reader);
                    reader.Close();
                }
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// XMLs the configuration writer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <param name="path">The path.</param>
        public static void XmlConfigWriter<T>(T obj, string path)
        {
            try
            {
                StreamWriter sw = new StreamWriter(path);
                Type t = obj.GetType();
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(sw, obj);
                sw.Close();
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }
        /// <summary>
        /// 将一个对象序列化为XML字符串
        /// </summary>
        /// <param name="o">要序列化的对象</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>序列化产生的XML字符串</returns>
        public static string XmlSerialize(object o, Encoding encoding)
        {
            MemoryStream stream = new MemoryStream();
            XmlSerializeInternal(stream, o, encoding);
            stream.Position = 0L;
            StreamReader reader = new StreamReader(stream, encoding);
            reader.Close();
            stream.Close();
            return reader.ReadToEnd();
        }
        /// <summary>
        /// XMLs the serialize.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>System.String.</returns>
        public static string XMLSerialize<T>(T entity)
        {
            StringBuilder buffer = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextWriter writer = new StringWriter(buffer))
            {
                serializer.Serialize(writer, entity);
            }
            return buffer.ToString();
        }
        /// <summary>
        /// 将一个对象按XML序列化的方式写入到一个文件
        /// </summary>
        /// <param name="o">要序列化的对象</param>
        /// <param name="path">保存文件路径</param>
        /// <param name="encoding">编码方式</param>
        /// <exception cref="T:System.ArgumentNullException">path</exception>
        public static void XmlSerializeToFile(object o, string path, Encoding encoding)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path");
            }
            FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);
            XmlSerializeInternal(file, o, encoding);
            file.Close();
        }
    }
}
