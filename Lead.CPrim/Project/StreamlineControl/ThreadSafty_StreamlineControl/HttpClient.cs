using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafty_StreamlineControl
{
    public static class HttpClient
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
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
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
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                using (StreamReader reader = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                    reader.Close();
                }

                return result;
            }
            catch (Exception ex)
            {
                return "Error:" + ex.Message;
            }
        }
    }
}
