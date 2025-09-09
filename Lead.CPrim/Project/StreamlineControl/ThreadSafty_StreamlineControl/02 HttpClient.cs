using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafty_StreamlineControl
{
    public static class HttpClients
    {
        /// <summary>
        /// HttpPost访问
        /// </summary>
        /// <param name="JsonData"> 数据信息(Json格式)</param> 
        /// <param name="url">访问接口</param> 
        /// <returns></returns>
        public static string HttpPost(string jsonData, string url, string contentType = "application/json;charset=utf-8", int timeOut = 4000)
        {

			try
			{
				HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;

				req.Method = "POST";
                req.Timeout = timeOut;
                req.ContentType = contentType;
                req.ContentLength = Encoding.UTF8.GetByteCount(jsonData);
                using (StreamWriter reqSW = new StreamWriter(req.GetRequestStream()))
                {
                    reqSW.Write(jsonData);
                    reqSW.Close();
                }

                string result = string.Empty;
                HttpWebResponse resp = req.GetResponse()as HttpWebResponse;
                using (StreamReader reader = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                    reader.Close();
                }

                return result;
            }
			catch (WebException ex)
			{
				string result = string.Empty;
				HttpWebResponse resp = ex.Response as HttpWebResponse;
				if(resp!= null)
                {
					using (StreamReader reader = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
					{
						result = reader.ReadToEnd();
						reader.Close();
					}
				}
				return "Error:" +ex.Message+":"+ result;
			}
			catch (Exception ex)
            {
				return "Error:" + ex.Message;
            }
        }

		/// <summary>
		/// HIVE(httpPost)访问
		/// </summary>
		/// <param name="jsonData"> 数据信息(Json格式)</param>
		/// <param name="url">访问接口</param>
		/// <returns></returns>
		public static string HttpPostMultipartData(string jsonData, List<string> filePaths, string url)
		{
			string strValue = string.Empty, StrDate = string.Empty;
			try
			{
				var memStream = new MemoryStream();
				// 边界符
				var boundary = DateTime.Now.Ticks.ToString("X");
				// 边界符
				var beginBoundary = Encoding.ASCII.GetBytes("--" + boundary + "\r\n");
				// 最后的结束符
				var endBoundary = Encoding.ASCII.GetBytes("--" + boundary + "--\r\n");

				if (filePaths != null && filePaths.Count > 0)
				{
					for (int i = 0; i < filePaths.Count; i++)
					{
						if (string.IsNullOrEmpty(filePaths[i]))
						{
							continue;
						}
						if (!System.IO.File.Exists(filePaths[i]))
						{
							continue;
						}
						var fileStream = new FileStream(filePaths[i], FileMode.Open, FileAccess.Read);
						// 写入文件
						const string filePartHeader =
							"Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n" +
							"Content-Type: {2}\r\n\r\n";
						var header = string.Format(filePartHeader, "file" + (i + 1), filePaths[i].Substring(filePaths[i].LastIndexOf("\\") + 1), getmemtype(filePaths[i]));
						var headerbytes = Encoding.UTF8.GetBytes(header);

						memStream.Write(beginBoundary, 0, beginBoundary.Length);
						memStream.Write(headerbytes, 0, headerbytes.Length);
						byte[] buffer = new byte[1024 * 14];
						int bytesRead = 0;
						while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)//将文件内容写入流
						{
							memStream.Write(buffer, 0, bytesRead);
						}
						fileStream.Close();
						var enterbytes = Encoding.UTF8.GetBytes("\r\n");
						memStream.Write(enterbytes, 0, enterbytes.Length);
					}
				}

				memStream.Write(beginBoundary, 0, beginBoundary.Length);
				var databytes = Encoding.UTF8.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"" +
																	 "\r\n\r\n{1}\r\n", "jsondata", jsonData));
				//Comvaria.tabelname = newdata;
				memStream.Write(databytes, 0, databytes.Length);
				memStream.Write(endBoundary, 0, endBoundary.Length);

				memStream.Position = 0;
				var tempBuffer = new byte[memStream.Length];
				memStream.Read(tempBuffer, 0, tempBuffer.Length);
				memStream.Close();

				// System.Net.ServicePointManager.DefaultConnectionLimit = 200;
				System.GC.Collect();
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
				request.Timeout = 60 * 1000;
				//request.ServicePoint.Expect100Continue = false;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 
					| SecurityProtocolType.Tls 
					| SecurityProtocolType.Tls11 
					| SecurityProtocolType.Ssl3;
				request.Method = "POST";
				request.ContentType = "multipart/form-data;boundary=" + boundary;//multipart/form-data模式
																				 //request.UserAgent;

				using (Stream writer = request.GetRequestStream())
				{
					writer.Write(tempBuffer, 0, tempBuffer.Length);
					writer.Close();
				}


				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				Stream s = response.GetResponseStream();
				StreamReader Reader = new StreamReader(s, Encoding.UTF8);

				while ((StrDate = Reader.ReadLine()) != null)
				{
					strValue += StrDate;
				}
				response.Close();
				response = null;
			}
			catch (WebException ex)
			{
				string result = string.Empty;
				HttpWebResponse resp = ex.Response as HttpWebResponse;
				if (resp != null)
				{
					using (StreamReader reader = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
					{
						result = reader.ReadToEnd();
						reader.Close();
					}
				}
				return "Error:" + ex.Message + ":" + result;
			}
			catch (Exception ex)
			{
				//Console.WriteLine("Error:{0}", ex.Message.ToString());
				strValue = ex.Message.ToString();
			}
			return strValue;
        }
        /// <summary>
        /// HIVE(httpPost)访问
        /// </summary>
        /// <param name="jsonData"> 数据信息(Json格式)</param>
        /// <param name="url">访问接口</param>
        /// <returns></returns>
        public static string HttpPostMultipartData(List<string> filePaths, string url)
        {
            string strValue = string.Empty, StrDate = string.Empty;
            try
            {
                var memStream = new MemoryStream();
                // 边界符
                var boundary = DateTime.Now.Ticks.ToString("X");
                // 边界符
                var beginBoundary = Encoding.ASCII.GetBytes("--" + boundary + "\r\n");
                // 最后的结束符
                var endBoundary = Encoding.ASCII.GetBytes("--" + boundary + "--\r\n");

                if (filePaths != null && filePaths.Count > 0)
                {
                    for (int i = 0; i < filePaths.Count; i++)
                    {
                        if (string.IsNullOrEmpty(filePaths[i]))
                        {
                            continue;
                        }
                        if (!System.IO.File.Exists(filePaths[i]))
                        {
                            continue;
                        }
                        var fileStream = new FileStream(filePaths[i], FileMode.Open, FileAccess.Read);
                        // 写入文件
                        const string filePartHeader =
                            "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n" +
                            "Content-Type: {2}\r\n\r\n";
                        var header = string.Format(filePartHeader, "imgList", filePaths[i].Substring(filePaths[i].LastIndexOf("\\") + 1), getmemtype(filePaths[i]));
                        var headerbytes = Encoding.UTF8.GetBytes(header);

                        memStream.Write(beginBoundary, 0, beginBoundary.Length);
                        memStream.Write(headerbytes, 0, headerbytes.Length);
                        byte[] buffer = new byte[1024 * 14];
                        int bytesRead = 0;
                        while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)//将文件内容写入流
                        {
                            memStream.Write(buffer, 0, bytesRead);
                        }
                        fileStream.Close();
                        var enterbytes = Encoding.UTF8.GetBytes("\r\n");
                        memStream.Write(enterbytes, 0, enterbytes.Length);
                    }
                }

                memStream.Write(beginBoundary, 0, beginBoundary.Length);
                //Comvaria.tabelname = newdata;
                memStream.Write(endBoundary, 0, endBoundary.Length);

                memStream.Position = 0;
                var tempBuffer = new byte[memStream.Length];
                memStream.Read(tempBuffer, 0, tempBuffer.Length);
                memStream.Close();

                // System.Net.ServicePointManager.DefaultConnectionLimit = 200;
                System.GC.Collect();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 60 * 1000;
                //request.ServicePoint.Expect100Continue = false;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                    | SecurityProtocolType.Tls
                    | SecurityProtocolType.Tls11
                    | SecurityProtocolType.Ssl3;
                request.Method = "POST";
                request.ContentType = "multipart/form-data;boundary=" + boundary;//multipart/form-data模式
                                                                                 //request.UserAgent;

                using (Stream writer = request.GetRequestStream())
                {
                    writer.Write(tempBuffer, 0, tempBuffer.Length);
                    writer.Close();
                }


                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream s = response.GetResponseStream();
                StreamReader Reader = new StreamReader(s, Encoding.UTF8);

                while ((StrDate = Reader.ReadLine()) != null)
                {
                    strValue += StrDate;
                }
                response.Close();
                response = null;
            }
            catch (WebException ex)
            {
                string result = string.Empty;
                HttpWebResponse resp = ex.Response as HttpWebResponse;
                if (resp != null)
                {
                    using (StreamReader reader = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                    {
                        result = reader.ReadToEnd();
                        reader.Close();
                    }
                }
                return "Error:" + ex.Message + ":" + result;
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error:{0}", ex.Message.ToString());
                strValue = ex.Message.ToString();
            }
            return strValue;
        }

        /// <summary>
        /// 获取文件类型
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        internal static string getmemtype(string filename)
		{
			string mimeType = "application/octet-stream";
			string ext = Path.GetExtension(filename).ToLower();
			RegistryKey regKey = Registry.ClassesRoot.OpenSubKey(ext);
			if (regKey != null && regKey.GetValue("Content Type") != null)
			{
				mimeType = regKey.GetValue("Content Type").ToString();
			}
			return mimeType;
		}
	}
}
