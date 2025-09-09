using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.PrimKeyencePLC.CommonModule
{
    /// <summary>
    /// 此类针对向PLC中写入中文字符串使用
    /// </summary>
    public class ChineseToUshort
    {
        /// <summary>
        /// 按字节数对字符串进行分割
        /// </summary>
        /// <param name="str">中文字符串</param>
        /// <param name="count">行最大字节数</param>
        /// <returns></returns>
        public static List<string> SplitString(string str, int count)
        {
            str.Trim();
            str = ToDBC(str);
            byte[] strByte = Encoding.Default.GetBytes(str);

            int nLeftCount = strByte.Length;    // 未处理字节数
            int nCurBytesPos = 0;               // 当前字节位置
            int nMaxBytesNum = count;               // 行最大字节数
            int CurRowBytesNum;                 // 当前行所取字节数

            string strInf = "";
            List<string> listStr = new List<string>();
            while (true)
            {
                if (nLeftCount == 0) break;

                // 末处理字节数已不够一行最大字节数
                if (nLeftCount < nMaxBytesNum)
                {
                    strInf += Encoding.Default.GetString(strByte, nCurBytesPos, nLeftCount);
                    listStr.Add(strInf);
                    break;
                }

                // 末处理字节数已超过一行最大字节数， 先计算当前行应取的最大字节数
                if (BIsHZHalfBytes(strByte, nCurBytesPos + nMaxBytesNum - 1))   // 当前行最后一个字节是否是汉字的一半
                {
                    CurRowBytesNum = nMaxBytesNum - 1;  // 如果是半个汉字，则最后一个字节本行不要，留给下一行处理
                }
                else
                {
                    CurRowBytesNum = nMaxBytesNum;
                }

                // 按本行的最大数量，得到字符串
                string s1 = Encoding.Default.GetString(strByte, nCurBytesPos, CurRowBytesNum);
                // 如果行的字节数量没有达到最大数量，则对字符串进行格式化整理
                // 在汉字和ASCII码之间插入一个空格, 这样排版美观
                if (CurRowBytesNum != nMaxBytesNum)
                {
                    for (int i = 0; i < CurRowBytesNum; i++)
                    {
                        if (strByte[nCurBytesPos + i] < 0x8f)
                        {
                            if (i > 0)
                                s1 = s1.Insert(i - 1, " ");
                            else
                                //       s1 = s1.Insert(i, " ");
                                break;
                        }
                    }
                }
                listStr.Add(s1);

                nCurBytesPos += CurRowBytesNum;
                nLeftCount -= CurRowBytesNum;
            }
            for (int i = 0; i < listStr.Count; i++)
            {
                string result = string.Empty;
                bool flag = false;
                for (int j = 0; j < listStr[i].Length; j++)
                {
                    string xx = listStr[i].Substring(j, 1);
                    char temp = Convert.ToChar(xx);
                    if (temp >= 0x4e00 && temp <= 0x9fbb)
                    {
                        if (result.Length % 2 == 0)
                        {
                            result = (result + temp.ToString());
                            flag = true;
                            continue;
                        }
                        if (result.Length % 2 != 0 && flag == false)
                        {
                            result = result + " " + temp.ToString();
                            flag = true;
                            continue;
                        }
                        if (result.Length % 2 != 0 && flag == true)
                        {
                            result += temp.ToString();
                            continue;
                        }
                    }
                    else
                    {
                        result += temp.ToString();
                        flag = false;
                    }
                }
                listStr[i] = string.Empty;
                listStr[i] = result;
            }
            return listStr;
        }

        // 判断byte[]缓冲区中,指定位置的字节,是否为汉字的半字节
        static bool BIsHZHalfBytes(byte[] pBuf, int nPos)
        {
            if (pBuf[nPos] < 0x80) return false;    // 如果最后一个字节是ASCII码，则返回false

            int nCount = 0;

            // 计算末尾的汉字的字节数
            while (pBuf[nPos] >= 0x80)
            {
                nCount++;
                nPos--;
                if (nPos < 0) break;
            }

            // 如果末尾的汉字的字节是奇数，说明最后一个字节只取了汉字的一半
            return (nCount % 2) != 0;
        }
        /**/
        // /
        // / 转半角的函数(DBC case)
        // /
        // /任意字符串
        // /半角字符串
        // /
        // /全角空格为12288，半角空格为32
        // /其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        // /
        public static String ToDBC(String input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12290)
                {
                    c[i] = (char)46;
                    continue;
                }
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new String(c);
        }


        /// <summary>
        /// 写入的数据
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length">寄存器长度</param>
        /// <param name="IsReverseAlarm">是否反转写入PLC报警内容的高低字节,默认false</param>
        /// <returns></returns>
        public static ushort[] GetUshorts(string str, int length, bool IsReverseAlarm = false)
        {
            List<byte> outByteL = new List<byte>();
            int maxLength = length * 2;

            for (int i = 0; i < str.Length; i++)
            {
                if (outByteL.Count > maxLength)//超出PLC寄存器时退出
                {
                    break;
                }

                byte[] byte_len = System.Text.Encoding.Default.GetBytes(str[i].ToString());
                if (byte_len.Length == 2) //是汉字必须从偶数位开始
                {
                    if (outByteL.Count % 2 != 0)
                    {
                        outByteL.Add(0x20);
                    }

                }
                outByteL.AddRange(byte_len);
            }
            while (outByteL.Count < maxLength)
            {
                outByteL.Add(0x00);
            }

            ushort[] outUshort = new ushort[length];
            var outBytes = outByteL.ToArray();
            if (!IsReverseAlarm)//这是正常数据
            {
                outBytes = ReverseBytesByWord(outByteL.ToArray());
            }
            Buffer.BlockCopy(outBytes, 0, outUshort, 0, maxLength);
            return outUshort;
        }


        private static bool IsHanZi(string ch)
        {
            byte[] byte_len = System.Text.Encoding.Default.GetBytes(ch);
            if (byte_len.Length == 2) { return true; }
            return false;

        }



        /// <summary>
        /// 按照字节错位的方法
        /// </summary>
        /// <param name="buffer">实际的字节数据</param>
        /// <param name="index">起始字节位置</param>
        /// <param name="length">数据长度</param>
        /// <returns>处理过的数据信息</returns>
        private static byte[] ReverseBytesByWord(byte[] buffer, int index, int length)
        {
            if (buffer == null) return null;

            // copy data
            byte[] tmp = new byte[length];
            for (int i = 0; i < length; i++)
            {
                tmp[i] = buffer[index + i];
            }

            // change
            for (int i = 0; i < length / 2; i++)
            {
                byte b = tmp[i * 2 + 0];
                tmp[i * 2 + 0] = tmp[i * 2 + 1];
                tmp[i * 2 + 1] = b;
            }

            return tmp;
        }

        private static byte[] ReverseBytesByWord(byte[] buffer)
        {
            return ReverseBytesByWord(buffer, 0, buffer.Length);
        }
    }
}
