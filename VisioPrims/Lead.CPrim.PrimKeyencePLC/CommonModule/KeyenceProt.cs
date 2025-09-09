using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Lead.CPrim.Interfaces.Dev;

namespace Lead.CPrim.PrimKeyencePLC.CommonModule
{
    public class KeyenceProt
    {
        private string m_name = "KeyenceProt";

        public string m_Locip = "192.168.0.10";

        public int m_Locport = 8501;

        private int m_ComIndex = -1;

        private bool m_ThreadSign = false;

        private WaitHandle[] waitHandles = new WaitHandle[]
        {
            new AutoResetEvent(false)
        };

        private object m_keyencelockObj = new object();

        private object m_keyenceSendlock = new object();

        private List<byte> m_lstRxBuff = new List<byte>();

        private bool m_IsIdle = true;

        private PlcSendStruct m_curPlcSend = new PlcSendStruct();

        public ConcurrentDictionary<string, ushort> m_PLCData = new ConcurrentDictionary<string, ushort>();

        private int m_WaitTimeout = 1000;

        public string Name
        {
            get
            {
                return this.m_name;
            }
            set
            {
                this.m_name = value;
            }
        }

        public int WaitTimeout
        {
            get
            {
                return this.m_WaitTimeout;
            }
            set
            {
                this.m_WaitTimeout = value;
            }
        }

        public bool IsConnected()
        {
            bool result;
            try
            {
                result = Comm.IsConnected(this.m_ComIndex);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public void Close()
        {
            try
            {
                this.m_ThreadSign = false;
                Comm.Close(this.m_ComIndex);
            }
            catch (Exception ex)
            {
            }
        }

        public KeyenceProt(string IpAddress, int port)
        {
            this.m_Locip = IpAddress;
            this.m_Locport = port;
            try
            {
                this.m_ComIndex = Comm.OpenTcpClient(this.m_Locip, this.m_Locport);
                Thread thread = new Thread(new ThreadStart(this.threadComm));
                thread.IsBackground = true;
                this.m_ThreadSign = true;
                thread.Start();
                thread.Name = "Keyence通讯线程";
            }
            catch (Exception ex)
            {
                string text = this.m_name + "连接失败！" + ex.ToString();
                throw ex;
            }
        }
        private void threadComm()
        {
            while (this.m_ThreadSign)
            {
                bool flag = Comm.IsConnected(this.m_ComIndex);
                if (flag)
                {
                    int dataLength = Comm.GetDataLength(this.m_ComIndex);
                    bool flag2 = dataLength > 0;
                    if (flag2)
                    {
                        object keyencelockObj = this.m_keyencelockObj;
                        lock (keyencelockObj)
                        {
                            this.m_lstRxBuff.AddRange(Comm.PopBuffer(this.m_ComIndex, -1).ToList<byte>());
                        }
                        bool flag4 = this.m_lstRxBuff.Count > 2;
                        if (flag4)
                        {
                            this.DataAnalysis(this.m_lstRxBuff);
                        }
                    }
                }
                Thread.Sleep(1);
            }
        }

        public void DataAnalysis(List<byte> lstRxBuff)
        {
            ushort value = 0;
            while (lstRxBuff.Count > 2)
            {
                this.m_curPlcSend.plcRespons = PLCRespons.None;
                string text = Encoding.ASCII.GetString(lstRxBuff.ToArray());
                bool flag = !text.Contains("\r\n");
                if (flag)
                {
                    this.m_curPlcSend.plcRespons = PLCRespons.ERROR;
                    break;
                }
                lstRxBuff.Clear();
                int startIndex = text.IndexOf("\r\n");
                text = text.Remove(startIndex);
                string text2 = text;
                bool flag2 = text2.StartsWith("E") || text2.StartsWith("OK");
                if (flag2)
                {
                    try
                    {
                        this.m_curPlcSend.plcRespons = (PLCRespons)Enum.Parse(typeof(PLCRespons), text2);
                    }
                    catch (Exception)
                    {
                    }
                }
                bool flag3 = false;
                PLCRespons plcRespons = this.m_curPlcSend.plcRespons;
                PLCRespons pLCRespons = plcRespons;
                if (pLCRespons == PLCRespons.OK || (pLCRespons - PLCRespons.E0 <= 5) && plcRespons != PLCRespons.None)
                {
                    flag3 = true;
                }
                bool flag4 = !flag3;
                if (flag4)
                {
                    try
                    {
                        char[] separator = new char[]
                        {
                            ' '
                        };
                        string[] array = text.Split(separator);
                        string text3 = this.m_curPlcSend.plcSoftAddr;
                        bool flag5 = text3.StartsWith("DM") || text3.StartsWith("EM") || text3.StartsWith("ZF");
                        if (flag5)
                        {
                            string arg = text3.Substring(0, 2);
                            int num = int.Parse(text3.Substring(2));
                            string[] array2 = array;
                            for (int i = 0; i < array2.Length; i++)
                            {
                                string s = array2[i];
                                bool flag6 = ushort.TryParse(s, out value);
                                if (flag6)
                                {
                                    bool flag7 = this.m_PLCData.ContainsKey(text3);
                                    if (flag7)
                                    {
                                        this.m_PLCData[text3] = value;
                                    }
                                    else
                                    {
                                        this.m_PLCData.GetOrAdd(text3, value);
                                    }
                                    num++;
                                    text3 = arg + num;
                                }
                            }
                        }
                        else
                        {
                            bool flag8 = text3.StartsWith("R");
                            if (flag8)
                            {
                                int num2 = int.Parse(text3.Substring(1));
                                string[] array3 = array;
                                for (int j = 0; j < array3.Length; j++)
                                {
                                    string s2 = array3[j];
                                    bool flag9 = ushort.TryParse(s2, out value);
                                    if (flag9)
                                    {
                                        bool flag10 = this.m_PLCData.ContainsKey(text3);
                                        if (flag10)
                                        {
                                            this.m_PLCData[text3] = value;
                                        }
                                        else
                                        {
                                            this.m_PLCData.GetOrAdd(text3, value);
                                        }
                                        num2 += 100;
                                        text3 = "R" + num2;
                                    }
                                }
                            }
                            else
                            {
                                int num3 = int.Parse(text3.Substring(2));
                                string arg2 = text3.Substring(0, 2);
                                string[] array4 = array;
                                for (int k = 0; k < array4.Length; k++)
                                {
                                    string s3 = array4[k];
                                    bool flag11 = ushort.TryParse(s3, out value);
                                    if (flag11)
                                    {
                                        bool flag12 = this.m_PLCData.ContainsKey(text3);
                                        if (flag12)
                                        {
                                            this.m_PLCData[text3] = value;
                                        }
                                        else
                                        {
                                            this.m_PLCData.GetOrAdd(text3, value);
                                        }
                                        num3 += 100;
                                        text3 = arg2 + num3;
                                    }
                                }
                            }
                        }
                        this.m_curPlcSend.plcRespons = PLCRespons.ReadOK;
                    }
                    catch (Exception ex)
                    {
                        this.m_curPlcSend.plcRespons = PLCRespons.ERROR;
                    }
                }
                AutoResetEvent autoResetEvent = (AutoResetEvent)this.waitHandles[0];
                autoResetEvent.Set();
            }
        }

        private static string GetSendStruct(OrderType opt, string type, uint start, ushort data)
        {
            ushort[] datanum = new ushort[]
            {
                data
            };
            string result = "";
            switch (opt)
            {
                case OrderType.WR:
                    result = KeyenceProt.StrFormatWR(type, start, DataType.U, datanum);
                    break;
                case OrderType.RD:
                    result = KeyenceProt.StrFormatRD(type, start, DataType.U, datanum);
                    break;
                case OrderType.RS:
                    result = KeyenceProt.StrFormatRS(type, start, DataType.U, datanum);
                    break;
                case OrderType.ST:
                    result = KeyenceProt.StrFormatST(type, start, DataType.U, datanum);
                    break;
            }
            return result;
        }

        private static string GetSendStruct(OrderType opt, string type, uint start, ushort[] data)
        {
            string result = "";
            switch (opt)
            {
                case OrderType.WR:
                    result = KeyenceProt.StrFormatWR(type, start, DataType.U, data);
                    break;
                case OrderType.RD:
                    result = KeyenceProt.StrFormatRD(type, start, DataType.U, data);
                    break;
                case OrderType.RS:
                    result = KeyenceProt.StrFormatRS(type, start, DataType.U, data);
                    break;
                case OrderType.ST:
                    result = KeyenceProt.StrFormatST(type, start, DataType.U, data);
                    break;
            }
            return result;
        }

        private static string StrFormatRD(string softtype, uint softnum, DataType datatype, ushort[] datanum)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool flag = datanum[0] > 1;
            if (flag)
            {
                stringBuilder.Append("RDS");
            }
            else
            {
                stringBuilder.Append("RD");
            }
            stringBuilder.Append(" ");
            stringBuilder.Append(softtype);
            stringBuilder.Append(softnum.ToString());
            stringBuilder.Append(".");
            stringBuilder.Append(datatype.ToString());
            bool flag2 = datanum[0] > 1;
            if (flag2)
            {
                stringBuilder.Append(" ");
                stringBuilder.Append(datanum[0].ToString());
            }
            stringBuilder.Append("\r");
            return stringBuilder.ToString();
        }

        private static string StrFormatWR(string softtype, uint softnum, DataType datatype, ushort[] datanum)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool flag = datanum.Length > 1;
            if (flag)
            {
                stringBuilder.Append("WRS");
            }
            else
            {
                stringBuilder.Append("WR");
            }
            stringBuilder.Append(" ");
            stringBuilder.Append(softtype);
            stringBuilder.Append(softnum.ToString());
            stringBuilder.Append(".");
            stringBuilder.Append(datatype.ToString());
            bool flag2 = datanum.Length > 1;
            if (flag2)
            {
                stringBuilder.Append(" ");
                stringBuilder.Append(datanum.Length.ToString());
            }
            for (int i = 0; i < datanum.Length; i++)
            {
                int num = (int)datanum[i];
                stringBuilder.Append(" ");
                stringBuilder.Append(num.ToString());
            }
            stringBuilder.Append("\r");
            return stringBuilder.ToString();
        }

        private static string StrFormatST(string softtype, uint softnum, DataType datatype, ushort[] datanum)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool flag = datanum[0] > 1;
            if (flag)
            {
                stringBuilder.Append("STS");
            }
            else
            {
                stringBuilder.Append("ST");
            }
            stringBuilder.Append(" ");
            stringBuilder.Append(softtype);
            stringBuilder.Append(softnum.ToString());
            bool flag2 = datanum[0] > 1;
            if (flag2)
            {
                stringBuilder.Append(" ");
                stringBuilder.Append(datanum[0].ToString());
            }
            stringBuilder.Append("\r");
            return stringBuilder.ToString();
        }

        private static string StrFormatRS(string softtype, uint softnum, DataType datatype, ushort[] datanum)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool flag = datanum[0] > 1;
            if (flag)
            {
                stringBuilder.Append("RSS");
            }
            else
            {
                stringBuilder.Append("RS");
            }
            stringBuilder.Append(" ");
            stringBuilder.Append(softtype);
            stringBuilder.Append(softnum.ToString());
            bool flag2 = datanum[0] > 1;
            if (flag2)
            {
                stringBuilder.Append(" ");
                stringBuilder.Append(datanum[0].ToString());
            }
            stringBuilder.Append("\r");
            return stringBuilder.ToString();
        }

        private void SendString(string sendstr)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(sendstr);
            object keyencelockObj = this.m_keyencelockObj;
            lock (keyencelockObj)
            {
                Comm.Send(this.m_ComIndex, sendstr, Encoding.ASCII);
            }
        }

        public PLCRespons ReadBit(PLCBitSoftType type, uint Address, out bool data)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            PLCRespons result;
            object keyenceSendlock = this.m_keyenceSendlock;
            lock (keyenceSendlock)
            {
                try
                {
                    uint num = Address / 100u * 100u;
                    this.m_curPlcSend.plcSoftAddr = type.ToString() + num;
                    string sendStruct = KeyenceProt.GetSendStruct(OrderType.RD, type.ToString(), num, 1);
                    this.SendString(sendStruct);
                    int num2 = WaitHandle.WaitAny(this.waitHandles, this.m_WaitTimeout);
                    bool flag2 = num2 == 258;
                    if (flag2)
                    {
                        this.m_IsIdle = true;
                        data = false;
                        result = PLCRespons.TimeOut;
                    }
                    else
                    {
                        bool flag3 = this.m_curPlcSend.plcRespons == PLCRespons.ReadOK;
                        if (flag3)
                        {
                            uint num3 = Address - Address % 100u;
                            string key = type.ToString() + num3;
                            ushort num4;
                            bool flag4 = this.m_PLCData.TryRemove(key, out num4);
                            if (flag4)
                            {
                                ushort num5 = (ushort)(num4 >> (int)(Address % 100u) & 1);
                                bool flag5 = num5 == 0;
                                if (flag5)
                                {
                                    data = false;
                                }
                                else
                                {
                                    data = true;
                                }
                                result = this.m_curPlcSend.plcRespons;
                            }
                            else
                            {
                                this.m_PLCData.Clear();
                                data = false;
                                result = PLCRespons.ERROR;
                            }
                        }
                        else
                        {
                            this.m_PLCData.Clear();
                            data = false;
                            result = this.m_curPlcSend.plcRespons;
                        }
                    }
                }
                catch (Exception ex)
                {
                    data = false;
                    this.m_PLCData.Clear();
                    result = PLCRespons.ERROR;
                }
            }
            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > 500)
            {
                System.Reflection.MethodBase currentMethod = System.Reflection.MethodBase.GetCurrentMethod();
            }
            return result;
        }

        public PLCRespons ReadBit(PLCBitSoftType type, uint Address, uint length, out bool[] data)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            object keyenceSendlock = this.m_keyenceSendlock;
            PLCRespons pLCRespons;
            PLCRespons result;
            lock (keyenceSendlock)
            {
                try
                {
                    uint num = Address / 100u * 100u;
                    uint num2 = Address % 100u + length;
                    this.m_curPlcSend.plcSoftAddr = type.ToString() + num;
                    string sendStruct = KeyenceProt.GetSendStruct(OrderType.RD, type.ToString(), num, (ushort)(num2 / 16u + 1u));
                    this.SendString(sendStruct);
                    int num3 = WaitHandle.WaitAny(this.waitHandles, this.m_WaitTimeout);
                    bool flag2 = num3 == 258;
                    if (flag2)
                    {
                        this.m_IsIdle = true;
                        data = null;
                        pLCRespons = PLCRespons.TimeOut;
                    }
                    else
                    {
                        bool flag3 = this.m_curPlcSend.plcRespons == PLCRespons.ReadOK;
                        if (flag3)
                        {
                            List<bool> list = new List<bool>();
                            for (uint num4 = 0u; num4 < length; num4 += 1u)
                            {
                                uint num5 = (Address + num4) % 100u;
                                uint num6 = num + num5 / 16u * 100u + num5 % 16u;
                                uint num7 = num6 - num6 % 100u;
                                string key = type.ToString() + num7;
                                bool flag4 = !this.m_PLCData.ContainsKey(key);
                                if (flag4)
                                {
                                    data = null;
                                    this.m_PLCData.Clear();
                                    pLCRespons = PLCRespons.ERROR;
                                    result = pLCRespons;
                                    return result;
                                }
                                //#region 测试
                                //if (Address==5200)
                                //                        {
                                //	GtkFileLog.WriteError(this.m_logfilepath, key+ "值" +this.m_PLCData[key]);
                                //}
                                //                        #endregion
                                ushort num8 = this.m_PLCData[key];
                                ushort num9 = (ushort)(num8 >> (int)(num6 % 100u) & 1);
                                bool flag5 = num9 == 0;
                                if (flag5)
                                {
                                    list.Add(false);
                                }
                                else
                                {
                                    list.Add(true);
                                }
                            }
                            this.m_PLCData.Clear();

                            data = list.ToArray();
                            #region 测试
                            if (Address == 5200 && data[0] == data[1] == data[2] == true)
                            {
                                data[0] = false;
                                data[1] = false;
                                data[2] = false;
                            }
                            #endregion


                            pLCRespons = this.m_curPlcSend.plcRespons;
                        }
                        else
                        {
                            data = null;
                            this.m_PLCData.Clear();
                            pLCRespons = this.m_curPlcSend.plcRespons;
                        }
                    }
                }
                catch (Exception ex)
                {
                    data = null;
                    this.m_PLCData.Clear();
                    pLCRespons = PLCRespons.ERROR;
                }
            }
            result = pLCRespons;
            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > 500)
            {
                System.Reflection.MethodBase currentMethod = System.Reflection.MethodBase.GetCurrentMethod();
            }
            return result;
        }

        public PLCRespons ReadUInt16Word(PLCByteSoftType type, uint Address, out ushort data)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            object keyenceSendlock = this.m_keyenceSendlock;
            PLCRespons result;
            lock (keyenceSendlock)
            {
                try
                {
                    this.m_curPlcSend.plcSoftAddr = type.ToString() + Address;
                    string sendStruct = KeyenceProt.GetSendStruct(OrderType.RD, type.ToString(), Address, 1);
                    this.SendString(sendStruct);
                    int num = WaitHandle.WaitAny(this.waitHandles, this.m_WaitTimeout);
                    bool flag2 = num == 258;
                    if (flag2)
                    {
                        this.m_IsIdle = true;
                        data = 0;
                        result = PLCRespons.TimeOut;
                    }
                    else
                    {
                        bool flag3 = this.m_curPlcSend.plcRespons == PLCRespons.ReadOK;
                        if (flag3)
                        {
                            string key = type.ToString() + Address;
                            ushort num2;
                            bool flag4 = this.m_PLCData.TryRemove(key, out num2);
                            if (flag4)
                            {
                                data = num2;
                                result = this.m_curPlcSend.plcRespons;
                            }
                            else
                            {
                                data = 0;
                                this.m_PLCData.Clear();
                                result = PLCRespons.ERROR;
                            }
                        }
                        else
                        {
                            data = 0;
                            this.m_PLCData.Clear();
                            result = this.m_curPlcSend.plcRespons;
                        }
                    }
                }
                catch (Exception ex)
                {
                    data = 0;
                    this.m_PLCData.Clear();
                    result = PLCRespons.ERROR;
                }
            }
            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > 500)
            {
                System.Reflection.MethodBase currentMethod = System.Reflection.MethodBase.GetCurrentMethod();
            }
            return result;
        }

        public PLCRespons ReadUInt16Word(PLCByteSoftType type, uint Address, uint length, out ushort[] data)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            object keyenceSendlock = this.m_keyenceSendlock;
            PLCRespons pLCRespons;
            PLCRespons result;
            lock (keyenceSendlock)
            {
                try
                {
                    this.m_curPlcSend.plcSoftAddr = type.ToString() + Address;
                    string sendStruct = KeyenceProt.GetSendStruct(OrderType.RD, type.ToString(), Address, (ushort)length);
                    this.SendString(sendStruct);
                    int num = WaitHandle.WaitAny(this.waitHandles, this.m_WaitTimeout);
                    bool flag2 = num == 258;
                    if (flag2)
                    {
                        this.m_IsIdle = true;
                        data = null;
                        pLCRespons = PLCRespons.TimeOut;
                    }
                    else
                    {
                        bool flag3 = this.m_curPlcSend.plcRespons == PLCRespons.ReadOK;
                        if (flag3)
                        {
                            List<ushort> list = new List<ushort>();
                            for (uint num2 = 0u; num2 < length; num2 += 1u)
                            {
                                uint num3 = Address + num2;
                                string key = type.ToString() + num3;
                                ushort item;
                                bool flag4 = !this.m_PLCData.TryRemove(key, out item);
                                if (flag4)
                                {
                                    data = null;
                                    this.m_PLCData.Clear();
                                    pLCRespons = PLCRespons.ERROR;
                                    result = pLCRespons;
                                    return result;
                                }
                                list.Add(item);
                            }
                            data = list.ToArray();
                            pLCRespons = this.m_curPlcSend.plcRespons;
                        }
                        else
                        {
                            this.m_PLCData.Clear();
                            data = null;
                            pLCRespons = this.m_curPlcSend.plcRespons;
                        }
                    }
                }
                catch (Exception ex)
                {
                    data = null;
                    this.m_PLCData.Clear();
                    pLCRespons = PLCRespons.ERROR;
                }
            }
            result = pLCRespons;
            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > 500)
            {
                System.Reflection.MethodBase currentMethod = System.Reflection.MethodBase.GetCurrentMethod();
            }
            return result;
        }

        public PLCRespons ReadInt16Word(PLCByteSoftType type, uint Address, out short data)
        {
            ushort num = 0;
            PLCRespons result = this.ReadUInt16Word(type, Address, out num);
            data = (short)num;
            return result;
        }

        public PLCRespons ReadInt16Word(PLCByteSoftType type, uint Address, uint length, out short[] data)
        {
            ushort[] array = null;
            List<short> list = new List<short>();
            PLCRespons result = this.ReadUInt16Word(type, Address, length, out array);
            for (int i = 0; i < array.Length; i++)
            {
                list.Add(Convert.ToInt16(array[i]));
            }
            data = list.ToArray();
            return result;
        }

        public PLCRespons ReadUInt32Word(PLCByteSoftType type, uint Address, out uint data)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            object keyenceSendlock = this.m_keyenceSendlock;
            PLCRespons result;
            lock (keyenceSendlock)
            {
                try
                {
                    this.m_curPlcSend.plcSoftAddr = type.ToString() + Address;
                    string sendStruct = KeyenceProt.GetSendStruct(OrderType.RD, type.ToString(), Address, 2);
                    this.SendString(sendStruct);
                    int num = WaitHandle.WaitAny(this.waitHandles, this.m_WaitTimeout);
                    bool flag2 = num == 258;
                    if (flag2)
                    {
                        this.m_IsIdle = true;
                        data = 0u;
                        result = PLCRespons.TimeOut;
                    }
                    else
                    {
                        bool flag3 = this.m_curPlcSend.plcRespons == PLCRespons.ReadOK;
                        if (flag3)
                        {
                            string key = type.ToString() + Address;
                            string key2 = type.ToString() + (Address + 1u);
                            ushort num2 = 0;
                            ushort num3 = 0;
                            bool flag4 = this.m_PLCData.TryRemove(key, out num2) && this.m_PLCData.TryRemove(key2, out num3);
                            if (flag4)
                            {
                                data = (uint)num3 * 65536u + (uint)num2;
                                result = this.m_curPlcSend.plcRespons;
                            }
                            else
                            {
                                data = 0u;
                                this.m_PLCData.Clear();
                                result = PLCRespons.ERROR;
                            }
                        }
                        else
                        {
                            this.m_PLCData.Clear();
                            data = 0u;
                            result = this.m_curPlcSend.plcRespons;
                        }
                    }
                }
                catch (Exception ex)
                {
                    data = 0u;
                    this.m_PLCData.Clear();
                    result = PLCRespons.ERROR;
                }
            }
            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > 500)
            {
                System.Reflection.MethodBase currentMethod = System.Reflection.MethodBase.GetCurrentMethod();
            }
            return result;
        }

        public PLCRespons ReadUInt32Word(PLCByteSoftType type, uint Address, uint length, out uint[] data)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            object keyenceSendlock = this.m_keyenceSendlock;
            PLCRespons pLCRespons;
            PLCRespons result;
            lock (keyenceSendlock)
            {
                try
                {
                    this.m_curPlcSend.plcSoftAddr = type.ToString() + Address;
                    string sendStruct = KeyenceProt.GetSendStruct(OrderType.RD, type.ToString(), Address, (ushort)(length * 2u));
                    this.SendString(sendStruct);
                    int num = WaitHandle.WaitAny(this.waitHandles, this.m_WaitTimeout);
                    bool flag2 = num == 258;
                    if (flag2)
                    {
                        this.m_IsIdle = true;
                        data = null;
                        pLCRespons = PLCRespons.TimeOut;
                    }
                    else
                    {
                        bool flag3 = this.m_curPlcSend.plcRespons == PLCRespons.ReadOK;
                        if (flag3)
                        {
                            List<uint> list = new List<uint>();
                            for (uint num2 = 0u; num2 < length; num2 += 1u)
                            {
                                string key = type.ToString() + (Address + num2 * 2u);
                                string key2 = type.ToString() + (Address + num2 * 2u + 1u);
                                ushort num3 = 0;
                                ushort num4 = 0;
                                bool flag4 = !this.m_PLCData.TryRemove(key, out num3) || !this.m_PLCData.TryRemove(key2, out num4);
                                if (flag4)
                                {
                                    this.m_PLCData.Clear();
                                    data = null;
                                    pLCRespons = PLCRespons.ERROR;
                                    result = pLCRespons;
                                    return result;
                                }
                                uint item = (uint)num4 * 65536u + (uint)num3;
                                list.Add(item);
                            }
                            data = list.ToArray();
                            pLCRespons = this.m_curPlcSend.plcRespons;
                        }
                        else
                        {
                            this.m_PLCData.Clear();
                            data = null;
                            pLCRespons = this.m_curPlcSend.plcRespons;
                        }
                    }
                }
                catch (Exception ex)
                {
                    data = null;
                    this.m_PLCData.Clear();
                    pLCRespons = PLCRespons.ERROR;
                }
            }
            result = pLCRespons;
            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > 500)
            {
                System.Reflection.MethodBase currentMethod = System.Reflection.MethodBase.GetCurrentMethod();
            }
            return result;
        }

        public PLCRespons ReadInt32Word(PLCByteSoftType type, uint Address, out int data)
        {
            uint num = 0u;
            PLCRespons result = this.ReadUInt32Word(type, Address, out num);

            data = (int)num;
            return result;
        }

        public PLCRespons ReadInt32Word(PLCByteSoftType type, uint Address, uint length, out int[] data)
        {
            uint[] array = null;
            List<int> list = new List<int>();
            PLCRespons result = this.ReadUInt32Word(type, Address, length, out array);
            for (int i = 0; i < array.Length; i++)
            {
                list.Add((int)(array[i]));
            }
            data = list.ToArray();
            return result;
        }

        public PLCRespons ReadUInt64Word(PLCByteSoftType type, uint Address, out UInt64 data)
        {
            UInt64[] readData = new UInt64[1];
            ushort[] rdData = new ushort[4];
            PLCRespons result = this.ReadUInt16Word(type, Address, 4, out rdData);
            Buffer.BlockCopy(readData, 0, rdData, 0, 8);
            data = readData[0];
            return result;
        }

        public PLCRespons ReadUInt64Word(PLCByteSoftType type, uint Address, uint length, out UInt64[] data)
        {
            UInt64[] readData = new UInt64[length];
            ushort[] rdData = new ushort[length * 4];
            PLCRespons result = this.ReadUInt16Word(type, Address, length * 4, out rdData);
            Buffer.BlockCopy(readData, 0, rdData, 0, (int)length * 8);
            data = readData;
            return result;
        }

        public PLCRespons ReadInt64Word(PLCByteSoftType type, uint Address, out Int64 data)
        {
            Int64[] readData = new Int64[1];
            ushort[] rdData = new ushort[4];
            PLCRespons result = this.ReadUInt16Word(type, Address, 4, out rdData);
            Buffer.BlockCopy(readData, 0, rdData, 0, 8);
            data = readData[0];
            return result;
        }

        public PLCRespons ReadInt64Word(PLCByteSoftType type, uint Address, uint length, out Int64[] data)
        {
            Int64[] readData = new Int64[length];
            ushort[] rdData = new ushort[length * 4];
            PLCRespons result = this.ReadUInt16Word(type, Address, length * 4, out rdData);
            Buffer.BlockCopy(readData, 0, rdData, 0, (int)length * 8);
            data = readData;
            return result;
        }

        public PLCRespons ReadFloatWord(PLCByteSoftType type, uint Address, out float data)
        {
            uint value = 0u;
            PLCRespons result = this.ReadUInt32Word(type, Address, out value);
            data = BitConverter.ToSingle(BitConverter.GetBytes(value), 0);
            return result;
        }

        public PLCRespons ReadFloatWord(PLCByteSoftType type, uint Address, uint length, out float[] data)
        {
            uint[] array = null;
            List<float> list = new List<float>();
            PLCRespons result = this.ReadUInt32Word(type, Address, length, out array);
            for (int i = 0; i < array.Length; i++)
            {
                list.Add(BitConverter.ToSingle(BitConverter.GetBytes(array[i]), 0));
            }
            data = list.ToArray();
            return result;
        }
        public PLCRespons ReadDoubleWord(PLCByteSoftType type, uint Address, out double data)
        {
            Double[] readData = new Double[1];
            ushort[] rdData = new ushort[4];
            PLCRespons result = this.ReadUInt16Word(type, Address, 4, out rdData);
            Buffer.BlockCopy(readData, 0, rdData, 0, 8);
            data = readData[0];
            return result;
        }

        public PLCRespons ReadDoubleWord(PLCByteSoftType type, uint Address, uint length, out Double[] data)
        {
            Double[] readData = new Double[length];
            ushort[] rdData = new ushort[length * 4];
            PLCRespons result = this.ReadUInt16Word(type, Address, length * 4, out rdData);
            Buffer.BlockCopy(readData, 0, rdData, 0, (int)length * 8);
            data = readData;
            return result;
        }
        /// <summary>
        /// 读取指定字符长度的字符串
        /// </summary>
        /// <param name="length">字符长度</param>
        /// <returns></returns>
        public PLCRespons ReadString(PLCByteSoftType type, uint Address, out string data, uint length, Encoding encoding)
        {
            return this.ReadStr(type, Address, out data, length, encoding);
        }
        /// <summary>
        /// 读取指定字符长度的字符串
        /// </summary>
        /// <param name="length">字符长度</param>
        /// <returns></returns>
        public PLCRespons ReadString(PLCByteSoftType type, uint Address, out string data, uint length)
        {
            return this.ReadStr(type, Address, out data, length, Encoding.ASCII);
        }
        /// <summary>
        /// 读取指定字符长度的字符串
        /// </summary>
        /// <param name="length">字符长度</param>
        /// <returns></returns>
        private PLCRespons ReadStr(PLCByteSoftType type, uint Address, out string data, uint length, Encoding encoding)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            object keyenceSendlock = this.m_keyenceSendlock;
            PLCRespons pLCRespons;
            PLCRespons result;
            lock (keyenceSendlock)
            {
                try
                {
                    ushort num = (ushort)(length / 2u + length % 2u);
                    this.m_curPlcSend.plcSoftAddr = type.ToString() + Address;
                    string sendStruct = KeyenceProt.GetSendStruct(OrderType.RD, type.ToString(), Address, num);
                    this.SendString(sendStruct);
                    int num2 = WaitHandle.WaitAny(this.waitHandles, this.m_WaitTimeout);
                    bool flag2 = num2 == 258;
                    if (flag2)
                    {
                        this.m_IsIdle = true;
                        data = null;
                        this.m_PLCData.Clear();
                        pLCRespons = PLCRespons.TimeOut;
                    }
                    else
                    {
                        bool flag3 = this.m_curPlcSend.plcRespons == PLCRespons.ReadOK;
                        if (flag3)
                        {
                            byte[] array = new byte[(int)(num * 2)];
                            for (uint num3 = 0u; num3 < (uint)num; num3 += 1u)
                            {
                                uint num4 = Address + num3;
                                string key = type.ToString() + num4;
                                ushort num5;
                                bool flag4 = !this.m_PLCData.TryRemove(key, out num5);
                                if (flag4)
                                {
                                    data = null;
                                    this.m_PLCData.Clear();
                                    pLCRespons = PLCRespons.ERROR;
                                    result = pLCRespons;
                                    return result;
                                }
                                array[(int)((uint)((UIntPtr)(num3 * 2u)))] = (byte)(num5 / 256);
                                array[(int)((uint)((UIntPtr)(num3 * 2u + 1u)))] = (byte)(num5 % 256);
                            }
                            string @string = encoding.GetString(array);
                            bool flag5 = (ulong)length < (ulong)((long)@string.Length);
                            if (flag5)
                            {
                                data = @string.Substring(0, (int)length);
                            }
                            else
                            {
                                data = @string;
                            }
                            pLCRespons = this.m_curPlcSend.plcRespons;
                        }
                        else
                        {
                            data = null;
                            this.m_PLCData.Clear();
                            pLCRespons = this.m_curPlcSend.plcRespons;
                        }
                    }
                }
                catch (Exception ex)
                {
                    data = null;
                    this.m_PLCData.Clear();
                    pLCRespons = PLCRespons.ERROR;
                }
            }
            result = pLCRespons;
            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > 500)
            {
                System.Reflection.MethodBase currentMethod = System.Reflection.MethodBase.GetCurrentMethod();
            }
            return result;
        }
        /// <summary>
        /// 读取指定地址长度的字符串
        /// </summary>
        /// <param name="length">地址长度</param>
        /// <returns></returns>
        public PLCRespons ReadAddrLengthString(PLCByteSoftType type, uint Address, out string data, uint length, Encoding encoding)
        {
            return this.ReadAddrLengthStr(type, Address, out data, length, encoding);
        }
        /// <summary>
        /// 读取指定地址长度的字符串
        /// </summary>
        /// <param name="length">地址长度</param>
        /// <returns></returns>
        public PLCRespons ReadAddrLengthString(PLCByteSoftType type, uint Address, out string data, uint length)
        {
            return this.ReadAddrLengthStr(type, Address, out data, length, Encoding.ASCII);
        }
        /// <summary>
        /// 读取指定地址长度的字符串
        /// </summary>
        /// <param name="length">地址长度</param>
        /// <returns></returns>
        private PLCRespons ReadAddrLengthStr(PLCByteSoftType type, uint Address, out string data, uint length, Encoding encoding)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            object keyenceSendlock = this.m_keyenceSendlock;
            PLCRespons pLCRespons;
            PLCRespons result;
            lock (keyenceSendlock)
            {
                try
                {
                    ushort num = (ushort)(length);
                    this.m_curPlcSend.plcSoftAddr = type.ToString() + Address;
                    string sendStruct = KeyenceProt.GetSendStruct(OrderType.RD, type.ToString(), Address, num);
                    this.SendString(sendStruct);
                    int num2 = WaitHandle.WaitAny(this.waitHandles, this.m_WaitTimeout);
                    bool flag2 = num2 == 258;
                    if (flag2)
                    {
                        this.m_IsIdle = true;
                        data = null;
                        this.m_PLCData.Clear();
                        pLCRespons = PLCRespons.TimeOut;
                    }
                    else
                    {
                        bool flag3 = this.m_curPlcSend.plcRespons == PLCRespons.ReadOK;
                        if (flag3)
                        {
                            byte[] array = new byte[(int)(num * 2)];
                            for (uint num3 = 0u; num3 < (uint)num; num3 += 1u)
                            {
                                uint num4 = Address + num3;
                                string key = type.ToString() + num4;
                                ushort num5;
                                bool flag4 = !this.m_PLCData.TryRemove(key, out num5);
                                if (flag4)
                                {
                                    data = null;
                                    this.m_PLCData.Clear();
                                    pLCRespons = PLCRespons.ERROR;
                                    result = pLCRespons;
                                    return result;
                                }
                                array[(int)((uint)((UIntPtr)(num3 * 2u)))] = (byte)(num5 / 256);
                                array[(int)((uint)((UIntPtr)(num3 * 2u + 1u)))] = (byte)(num5 % 256);
                            }
                            string @string = encoding.GetString(array);
                            bool flag5 = (ulong)length < (ulong)((long)@string.Length);
                            if (flag5)
                            {
                                data = @string.Substring(0, (int)length);
                            }
                            else
                            {
                                data = @string;
                            }
                            pLCRespons = this.m_curPlcSend.plcRespons;
                        }
                        else
                        {
                            data = null;
                            this.m_PLCData.Clear();
                            pLCRespons = this.m_curPlcSend.plcRespons;
                        }
                    }
                }
                catch (Exception ex)
                {
                    data = null;
                    this.m_PLCData.Clear();
                    pLCRespons = PLCRespons.ERROR;
                }
            }
            result = pLCRespons;
            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > 500)
            {
                System.Reflection.MethodBase currentMethod = System.Reflection.MethodBase.GetCurrentMethod();
            }
            return result;
        }

        public PLCRespons WriteBit(PLCBitSoftType type, uint Address, bool data)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            object keyenceSendlock = this.m_keyenceSendlock;
            PLCRespons result;
            lock (keyenceSendlock)
            {
                try
                {
                    string sendStruct;
                    if (data)
                    {
                        sendStruct = KeyenceProt.GetSendStruct(OrderType.ST, type.ToString(), Address, 1);
                    }
                    else
                    {
                        sendStruct = KeyenceProt.GetSendStruct(OrderType.RS, type.ToString(), Address, 1);
                    }
                    this.SendString(sendStruct);
                    int num = WaitHandle.WaitAny(this.waitHandles, this.m_WaitTimeout);
                    bool flag2 = num == 258;
                    if (flag2)
                    {
                        this.m_IsIdle = true;
                        result = PLCRespons.TimeOut;
                    }
                    else
                    {
                        result = this.m_curPlcSend.plcRespons;
                    }
                }
                catch (Exception ex)
                {
                    result = PLCRespons.ERROR;
                }
            }
            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > 500)
            {
                System.Reflection.MethodBase currentMethod = System.Reflection.MethodBase.GetCurrentMethod();
            }
            return result;
        }

        public PLCRespons WriteBit(PLCBitSoftType type, uint Address, bool[] data)
        {
            PLCRespons result;
            try
            {
                PLCRespons pLCRespons = PLCRespons.None;
                uint num = 0u;
                while ((ulong)num < (ulong)((long)data.Length))
                {
                    uint num2 = Address / 100u * 100u;
                    uint num3 = (Address + num) % 100u;
                    uint address = num2 + num3 / 16u * 100u + num3 % 16u;
                    pLCRespons = this.WriteBit(type, address, data[(int)((uint)((UIntPtr)num))]);
                    num += 1u;
                }
                result = pLCRespons;
            }
            catch (Exception ex)
            {
                result = PLCRespons.ERROR;
            }
            return result;
        }

        public PLCRespons WriteUInt16Word(PLCByteSoftType type, uint Address, ushort data)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            object keyenceSendlock = this.m_keyenceSendlock;
            PLCRespons result;
            lock (keyenceSendlock)
            {
                try
                {
                    ushort[] expr_1B = new ushort[]
                    {
                        data
                    };
                    string sendStruct = KeyenceProt.GetSendStruct(OrderType.WR, type.ToString(), Address, data);
                    this.SendString(sendStruct);
                    int num = WaitHandle.WaitAny(this.waitHandles, this.m_WaitTimeout);
                    bool flag2 = num == 258;
                    if (flag2)
                    {
                        this.m_IsIdle = true;
                        result = PLCRespons.TimeOut;
                    }
                    else
                    {
                        result = this.m_curPlcSend.plcRespons;
                    }
                }
                catch (Exception ex)
                {
                    result = PLCRespons.ERROR;
                }
            }
            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > 500)
            {
                System.Reflection.MethodBase currentMethod = System.Reflection.MethodBase.GetCurrentMethod();
            }
            return result;
        }

        public PLCRespons WriteUInt16Word(PLCByteSoftType type, uint Address, ushort[] data)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            object keyenceSendlock = this.m_keyenceSendlock;
            PLCRespons result;
            lock (keyenceSendlock)
            {
                try
                {
                    bool flag2 = data != null && data.Length != 0;
                    if (flag2)
                    {
                        string sendStruct = KeyenceProt.GetSendStruct(OrderType.WR, type.ToString(), Address, data);
                        this.SendString(sendStruct);
                    }
                    int num = WaitHandle.WaitAny(this.waitHandles, this.m_WaitTimeout);
                    bool flag3 = num == 258;
                    if (flag3)
                    {
                        this.m_IsIdle = true;
                        result = PLCRespons.TimeOut;
                    }
                    else
                    {
                        result = this.m_curPlcSend.plcRespons;
                    }
                }
                catch (Exception ex)
                {
                    result = PLCRespons.ERROR;
                }
            }
            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > 500)
            {
                System.Reflection.MethodBase currentMethod = System.Reflection.MethodBase.GetCurrentMethod();
            }
            return result;
        }

        public PLCRespons WriteInt16Word(PLCByteSoftType type, uint Address, short data)
        {
            return this.WriteUInt16Word(type, Address, (ushort)data);
        }

        public PLCRespons WriteInt16Word(PLCByteSoftType type, uint Address, short[] data)
        {
            PLCRespons result;
            try
            {
                bool flag = data != null && data.Length != 0;
                if (flag)
                {
                    List<ushort> list = new List<ushort>();
                    for (int i = 0; i < data.Length; i++)
                    {
                        short num = data[i];
                        list.Add((ushort)num);
                    }
                    result = this.WriteUInt16Word(type, Address, list.ToArray());
                }
                else
                {
                    result = PLCRespons.ERROR;
                }
            }
            catch (Exception ex)
            {
                result = PLCRespons.ERROR;
            }
            return result;
        }

        public PLCRespons WriteUInt32Word(PLCByteSoftType type, uint Address, uint data)
        {
            PLCRespons result;
            try
            {
                ushort[] writeData = new ushort[2];
                Buffer.BlockCopy(new uint[] { data }, 0, writeData, 0, 4);
                result = this.WriteUInt16Word(type, Address, writeData);
            }
            catch (Exception ex)
            {
                result = PLCRespons.ERROR;
            }
            return result;
        }

        public PLCRespons WriteUInt32Word(PLCByteSoftType type, uint Address, uint[] data)
        {
            PLCRespons result;
            try
            {
                bool flag = data != null && data.Length != 0;
                if (flag)
                {
                    //List<ushort> list = new List<ushort>();
                    //for (int i = 0; i < data.Length; i++)
                    //{
                    //	uint num = data[i];
                    //	list.Add((ushort)(num % 65536u));
                    //	list.Add((ushort)(num / 65536u));
                    //}
                    ushort[] list = new ushort[data.Length * 2];
                    Buffer.BlockCopy(data, 0, list, 0, data.Length * 4);
                    result = this.WriteUInt16Word(type, Address, list.ToArray());
                }
                else
                {
                    result = PLCRespons.ERROR;
                }
            }
            catch (Exception ex)
            {
                result = PLCRespons.ERROR;
            }
            return result;
        }
        public PLCRespons WriteUInt64Word(PLCByteSoftType type, uint Address, UInt64 data)
        {
            PLCRespons result;
            try
            {
                ushort[] writeData = new ushort[4];
                Buffer.BlockCopy(new UInt64[] { data }, 0, writeData, 0, 8);
                result = this.WriteUInt16Word(type, Address, writeData);
            }
            catch (Exception ex)
            {
                result = PLCRespons.ERROR;
            }
            return result;
        }

        public PLCRespons WriteUInt64Word(PLCByteSoftType type, uint Address, UInt64[] data)
        {
            PLCRespons result;
            try
            {
                bool flag = data != null && data.Length != 0;
                if (flag)
                {
                    ushort[] list = new ushort[data.Length * 4];
                    Buffer.BlockCopy(data, 0, list, 0, data.Length * 8);
                    result = this.WriteUInt16Word(type, Address, list.ToArray());
                }
                else
                {
                    result = PLCRespons.ERROR;
                }
            }
            catch (Exception ex)
            {
                result = PLCRespons.ERROR;
            }
            return result;
        }
        public PLCRespons WriteInt32Word(PLCByteSoftType type, uint Address, int data)
        {
            PLCRespons result;
            try
            {
                ushort[] writeData = new ushort[2];
                Buffer.BlockCopy(new int[] { data }, 0, writeData, 0, 4);
                result = this.WriteUInt16Word(type, Address, writeData);
            }
            catch (Exception ex)
            {
                result = PLCRespons.ERROR;
            }
            return result;
        }

        public PLCRespons WriteInt32Word(PLCByteSoftType type, uint Address, int[] data)
        {
            PLCRespons result;
            try
            {
                bool flag = data != null && data.Length != 0;
                if (flag)
                {
                    ushort[] list = new ushort[data.Length * 2];
                    Buffer.BlockCopy(data, 0, list, 0, data.Length * 4);
                    result = this.WriteUInt16Word(type, Address, list.ToArray());
                }
                else
                {
                    result = PLCRespons.ERROR;
                }
            }
            catch (Exception ex)
            {
                result = PLCRespons.ERROR;
            }
            return result;
        }
        public PLCRespons WriteInt64Word(PLCByteSoftType type, uint Address, Int64 data)
        {
            PLCRespons result;
            try
            {
                ushort[] writeData = new ushort[4];
                Buffer.BlockCopy(new Int64[] { data }, 0, writeData, 0, 8);
                result = this.WriteUInt16Word(type, Address, writeData);
            }
            catch (Exception ex)
            {
                result = PLCRespons.ERROR;
            }
            return result;
        }

        public PLCRespons WriteInt64Word(PLCByteSoftType type, uint Address, Int64[] data)
        {
            PLCRespons result;
            try
            {
                bool flag = data != null && data.Length != 0;
                if (flag)
                {
                    ushort[] list = new ushort[data.Length * 4];
                    Buffer.BlockCopy(data, 0, list, 0, data.Length * 8);
                    result = this.WriteUInt16Word(type, Address, list.ToArray());
                }
                else
                {
                    result = PLCRespons.ERROR;
                }
            }
            catch (Exception ex)
            {
                result = PLCRespons.ERROR;
            }
            return result;
        }
        public PLCRespons WriteString(PLCByteSoftType type, uint Address, string data)
        {
            return this.WriteStr(type, Address, data, Encoding.ASCII);
        }

        public PLCRespons WriteString(PLCByteSoftType type, uint Address, string data, Encoding encoding)
        {
            return this.WriteStr(type, Address, data, encoding);
        }

        private PLCRespons WriteStr(PLCByteSoftType type, uint Address, string data, Encoding encoding)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            object keyenceSendlock = this.m_keyenceSendlock;
            PLCRespons result;
            lock (keyenceSendlock)
            {
                try
                {
                    bool flag2 = !string.IsNullOrEmpty(data) && data.Length > 0;
                    if (flag2)
                    {
                        byte[] bytes = encoding.GetBytes(data);
                        int num = bytes.Length / 2 + bytes.Length % 2;
                        ushort[] array = new ushort[num];
                        int i;
                        for (i = 0; i < bytes.Length / 2; i++)
                        {
                            int num2 = (int)bytes[i * 2];
                            num2 = (num2 << 8 | (int)bytes[i * 2 + 1]);
                            array[i] = Convert.ToUInt16(num2);
                        }
                        bool flag3 = bytes.Length % 2 > 0;
                        if (flag3)
                        {
                            int value = (int)bytes[bytes.Length - 1] << 8;
                            array[i] = Convert.ToUInt16(value);
                        }
                        string sendStruct = KeyenceProt.GetSendStruct(OrderType.WR, type.ToString(), Address, array);
                        this.SendString(sendStruct);
                    }
                    int num3 = WaitHandle.WaitAny(this.waitHandles, this.m_WaitTimeout);
                    bool flag4 = num3 == 258;
                    if (flag4)
                    {
                        this.m_IsIdle = true;
                        result = PLCRespons.TimeOut;
                    }
                    else
                    {
                        result = this.m_curPlcSend.plcRespons;
                    }
                }
                catch (Exception ex)
                {
                    result = PLCRespons.ERROR;
                }
            }
            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > 500)
            {
                System.Reflection.MethodBase currentMethod = System.Reflection.MethodBase.GetCurrentMethod();
            }
            return result;
        }
        /// <summary>
        /// 往指定长度的地址里写字符串
        /// </summary>
        /// <param name="length">地址长度</param>
        /// <returns></returns>
        public PLCRespons WriteAddrLengthString(PLCByteSoftType type, uint Address, string data, uint length)
        {
            return this.WriteAddrLengthStr(type, Address, data, length, Encoding.ASCII);
        }
        /// <summary>
        /// 往指定长度的地址里写字符串
        /// </summary>
        /// <param name="length">地址长度</param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public PLCRespons WriteAddrLengthString(PLCByteSoftType type, uint Address, string data, uint length, Encoding encoding)
        {
            return this.WriteAddrLengthStr(type, Address, data, length, encoding);
        }
        /// <summary>
        /// 往指定长度的地址里写字符串
        /// </summary>
        /// <param name="length">地址长度</param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        private PLCRespons WriteAddrLengthStr(PLCByteSoftType type, uint Address, string data, uint length, Encoding encoding)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            object keyenceSendlock = this.m_keyenceSendlock;
            PLCRespons result;
            lock (keyenceSendlock)
            {
                try
                {
                    bool flag2 = !string.IsNullOrEmpty(data) && data.Length > 0;
                    if (flag2)
                    {
                        byte[] bytes = new byte[length * 2];//一个寄存器两个字符
                        var data1 = encoding.GetBytes(data);
                        Array.Copy(data1, bytes, data1.Length);

                        //byte[] bytes = encoding.GetBytes(data);
                        int num = bytes.Length / 2 + bytes.Length % 2;
                        ushort[] array = new ushort[num];
                        int i;
                        for (i = 0; i < bytes.Length / 2; i++)
                        {
                            int num2 = (int)bytes[i * 2];
                            num2 = (num2 << 8 | (int)bytes[i * 2 + 1]);
                            array[i] = Convert.ToUInt16(num2);
                        }
                        bool flag3 = bytes.Length % 2 > 0;
                        if (flag3)
                        {
                            int value = (int)bytes[bytes.Length - 1] << 8;
                            array[i] = Convert.ToUInt16(value);
                        }
                        string sendStruct = KeyenceProt.GetSendStruct(OrderType.WR, type.ToString(), Address, array);
                        this.SendString(sendStruct);
                    }
                    int num3 = WaitHandle.WaitAny(this.waitHandles, this.m_WaitTimeout);
                    bool flag4 = num3 == 258;
                    if (flag4)
                    {
                        this.m_IsIdle = true;
                        result = PLCRespons.TimeOut;
                    }
                    else
                    {
                        result = this.m_curPlcSend.plcRespons;
                    }
                }
                catch (Exception ex)
                {
                    result = PLCRespons.ERROR;
                }
            }
            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > 500)
            {
                System.Reflection.MethodBase currentMethod = System.Reflection.MethodBase.GetCurrentMethod();
            }
            return result;
        }

        public PLCRespons WriteFloatWord(PLCByteSoftType type, uint Address, float data)
        {
            PLCRespons result;
            try
            {
                List<ushort> list = new List<ushort>();
                byte[] bytes = BitConverter.GetBytes(data);
                list.Add(BitConverter.ToUInt16(bytes, 0));
                list.Add(BitConverter.ToUInt16(bytes, 2));
                result = this.WriteUInt16Word(type, Address, list.ToArray());
            }
            catch (Exception ex)
            {
                result = PLCRespons.ERROR;
            }
            return result;
        }

        public PLCRespons WriteFloatWord(PLCByteSoftType type, uint Address, float[] data)
        {
            PLCRespons result;
            try
            {
                bool flag = data != null && data.Length != 0;
                if (flag)
                {
                    List<ushort> list = new List<ushort>();
                    for (int i = 0; i < data.Length; i++)
                    {
                        float value = data[i];
                        byte[] bytes = BitConverter.GetBytes(value);
                        list.Add(BitConverter.ToUInt16(bytes, 0));
                        list.Add(BitConverter.ToUInt16(bytes, 2));
                    }
                    result = this.WriteUInt16Word(type, Address, list.ToArray());
                }
                else
                {
                    result = PLCRespons.ERROR;
                }
            }
            catch (Exception ex)
            {
                result = PLCRespons.ERROR;
            }
            return result;
        }
        public PLCRespons WriteDoubleWord(PLCByteSoftType type, uint Address, Double data)
        {
            PLCRespons result;
            try
            {
                ushort[] writeData = new ushort[4];
                Buffer.BlockCopy(new Double[] { data }, 0, writeData, 0, 8);
                result = this.WriteUInt16Word(type, Address, writeData);
            }
            catch (Exception ex)
            {
                result = PLCRespons.ERROR;
            }
            return result;
        }

        public PLCRespons WriteDoubleWord(PLCByteSoftType type, uint Address, Double[] data)
        {
            PLCRespons result;
            try
            {
                bool flag = data != null && data.Length != 0;
                if (flag)
                {
                    ushort[] list = new ushort[data.Length * 4];
                    Buffer.BlockCopy(data, 0, list, 0, data.Length * 8);
                    result = this.WriteUInt16Word(type, Address, list.ToArray());
                }
                else
                {
                    result = PLCRespons.ERROR;
                }
            }
            catch (Exception ex)
            {
                result = PLCRespons.ERROR;
            }
            return result;
        }
    }
}
