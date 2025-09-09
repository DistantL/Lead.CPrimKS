using System;
using System.Management;

namespace Lead.CPrim.ProxyTools.Register
{
    public class Register
    {
        public static int[] intNumber = new int[25];//用于存机器码的Ascii值
        public static char[] Charcode = new char[25];//存储机器码字
        public static int[] intCode = new int[127];//使用机器码生成注册码_用于存密钥

        /// <summary>获得CPU的序列号</summary>
        /// <returns></returns>
        public static string getCpu()
        {
            string strCpu = null;
            ManagementClass myCpu = new ManagementClass("win32_Processor");
            ManagementObjectCollection myCpuConnection = myCpu.GetInstances();
            foreach (ManagementObject myObject in myCpuConnection)
            {
                strCpu = myObject.Properties["Processorid"].Value.ToString();
                break;
            }
            return strCpu;
        }
        /// <summary>取得设备硬盘的卷标号</summary>
        /// <returns></returns>
        public static string GetDiskVolumeSerialNumber()
        {
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            disk.Get();
            return disk.GetPropertyValue("VolumeSerialNumber").ToString();
        }

        /// <summary>生成机器码</summary>
        /// <returns></returns>
        private static string CreateCode()
        {
            //获得24位Cpu和硬盘序列号
            string temp = getCpu() + GetDiskVolumeSerialNumber();
            string[] strid = new string[24];
            for (int i = 0; i < 24; i++)
            {
                strid[i] = temp.Substring(i, 1);
            }
            temp = "";
            for (int i = 0; i < 24; i++)
            {
                temp += strid[i + 8 >= 24 ? i - 16 : i + 8];
            }
            return temp;
        }

        /// <summary>给数组赋值个小于10的随机数</summary>
        private static void setIntCode()
        {
            for (int i = 1; i < intCode.Length; i++)
            {
                intCode[i] = i + 3 > 9 ? 0 : i + 3;
            }
        }

        //生成注册码
        public static string GetCode()
        {
            string code = CreateCode();
            if (code != "")
            {
                //把机器码存入数组中
                //初始化127位数组
                setIntCode();
                //把机器码存入数组中
                for (int i = 1; i < Charcode.Length; i++)
                {
                    Charcode[i] = Convert.ToChar(code.Substring(i - 1, 1));
                }
                //把字符的ASCII值存入一个整数组中。
                for (int j = 1; j < intNumber.Length; j++)
                {
                    intNumber[j] = intCode[Convert.ToInt32(Charcode[j])] + Convert.ToInt32(Charcode[j]);
                }
                //用于存储机器码
                string strAsciiName = null;
                for (int j = 1; j < intNumber.Length; j++)
                {
                    //判断字符ASCII值是否0－9之间
                    if (intNumber[j] >= 48 && intNumber[j] <= 57)
                    {
                        strAsciiName += Convert.ToChar(intNumber[j]).ToString();
                    }
                    //判断字符ASCII值是否A－Z之间
                    else if (intNumber[j] >= 65 && intNumber[j] <= 90)
                    {
                        strAsciiName += Convert.ToChar(intNumber[j]).ToString();
                    }
                    //判断字符ASCII值是否a－z之间
                    else if (intNumber[j] >= 97 && intNumber[j] <= 122)
                    {
                        strAsciiName += Convert.ToChar(intNumber[j]).ToString();
                    }
                    //判断字符ASCII值不在以上范围内
                    else
                    {
                        //判断字符ASCII值是否大于z
                        if (intNumber[j] > 122)
                        {
                            strAsciiName += Convert.ToChar(intNumber[j] - 10).ToString();
                        }
                        else
                        {
                            strAsciiName += Convert.ToChar(intNumber[j] - 9).ToString();
                        }
                    }
                }
                return strAsciiName;
            }
            else
            {
                return "";
            }
        }
    }
}
