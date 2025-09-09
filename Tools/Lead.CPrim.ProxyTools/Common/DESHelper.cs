using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>加密帮助类</summary>
    public class DESHelper
    {
        /// <summary>DES常规加密（Key/IV直接赋值）</summary>
        /// <param name="sInputString"></param>
        /// <param name="sKey"></param>
        /// <param name="sIV"></param>
        /// <param name="result"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static int EncryptString(string sInputString, string sKey, string sIV, ref string result, ref string error)
        {
            try
            {
                result = null;
                error = null;
                byte[] data = Encoding.UTF8.GetBytes(sInputString);
                using (DESCryptoServiceProvider DES = new DESCryptoServiceProvider())
                {
                    DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                    DES.IV = ASCIIEncoding.ASCII.GetBytes(sIV);
                    ICryptoTransform desencrypt = DES.CreateEncryptor();
                    byte[] buffer = desencrypt.TransformFinalBlock(data, 0, data.Length);
                    result = string.Join("", BitConverter.ToString(buffer).Split(new char[] { '-' }));
                    return 0;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return -1;
            }
        }
        /// <summary>DES常规解密（Key/IV直接赋值）</summary>
        /// <param name="sInputString"></param>
        /// <param name="sKey"></param>
        /// <param name="sIV"></param>
        /// <param name="result"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static int DecryptString(string sInputString, string sKey, string sIV, ref string result, ref string error)
        {
            try
            {
                result = null;
                error = null;
                if (sInputString.Length != 16)
                {
                    error = "密钥长度为16位";
                    return -1;
                }
                byte[] data = new byte[sInputString.Length / 2];
                for (int i = 0; i < sInputString.Length / 2; i++)
                {
                    data[i] = byte.Parse(sInputString.Substring(i * 2, 2), NumberStyles.HexNumber);
                }
                DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
                DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(sIV);
                ICryptoTransform desencrypt = DES.CreateDecryptor();
                byte[] buffer = desencrypt.TransformFinalBlock(data, 0, data.Length);
                result = Encoding.UTF8.GetString(buffer);
                return 0;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return -1;
            }
        }
        /// <summary>DES数据解密（Key/IV采用加密手段）</summary>
        /// <param name="targetValue"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Decrypt(string targetValue, string key)
        {
            if (string.IsNullOrEmpty(targetValue))
            {
                return string.Empty;
            }
            DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
            int num = targetValue.Length / 2;
            byte[] array = new byte[num];
            for (int i = 0; i < num; i++)
            {
                int num2 = Convert.ToInt32(targetValue.Substring(i * 2, 2), 16);
                array[i] = (byte)num2;
            }
            dESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(key.Md5String().Substring(0, 8).Sha1String().Substring(0, 8));
            dESCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(key.Md5String().Substring(0, 8).Md5String().Substring(0, 8));
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(array, 0, array.Length);
            cryptoStream.FlushFinalBlock();
            return Encoding.Default.GetString(memoryStream.ToArray());
        }
        /// <summary>DES数据加密（Key/IV采用加密手段）</summary>
        /// <param name="targetValue">目标值</param>
        /// <param name="key">密钥</param>
        /// <returns>加密值</returns>
        public static string Encrypt(string targetValue, string key)
        {
            if (string.IsNullOrEmpty(targetValue))
            {
                return string.Empty;
            }
            StringBuilder stringBuilder = new StringBuilder();
            DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
            byte[] bytes = Encoding.Default.GetBytes(targetValue);
            dESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(key.Md5String().Substring(0, 8).Sha1String().Substring(0, 8));
            dESCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(key.Md5String().Substring(0, 8).Md5String().Substring(0, 8));
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] array = memoryStream.ToArray();
            foreach (byte b in array)
            {
                stringBuilder.AppendFormat("{0:X2}", b);
            }
            return stringBuilder.ToString();
        }
    }
}
