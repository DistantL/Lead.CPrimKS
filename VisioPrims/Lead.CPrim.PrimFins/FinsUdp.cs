/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: FinsUdp.cs
 * Author: Victor
 * Description: 欧姆龙Fins通讯FinsUdp通讯类
 * CreateTime: 2022-09-21
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * 3.3.22.0904 -> 
 * <Author> (Victor)    <Time> (20220921)
 * 1、初版1.0
******************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lead.CPrim.Interfaces;
using CommunicationBase;
using CommunicationBase.Profinet.Omron;
using System.Net;

namespace Lead.CPrim.PrimFinsNet
{
    public class FinsUdp : IOmronFins
    {
        #region Field
        private OmronFinsUdp _omronFinsUdp;
        #endregion



        #region Ctor
        public FinsUdp()
        {
            _omronFinsUdp = new OmronFinsUdp();
            _omronFinsUdp.ReceiveTimeout = 1000;
        }
        public FinsUdp(string ip, int port) : this()
        {
            _omronFinsUdp.IpAddress = ip;
            _omronFinsUdp.Port = port;
        }
        public  FinsUdp(string ip, int port, byte sa1, byte da1, byte da2) : this(ip, port)
        {
            _omronFinsUdp.SA1 = sa1;
            _omronFinsUdp.DA1 = da1;
            _omronFinsUdp.DA2 = da2;
        }
        #endregion



        #region Override IOmronFins
        public bool Connect()
        {
            return true;
        }
        public bool DisConnect()
        {
            return true;
        }

        public OperateResult<short> ReadInt16(string address, byte[] buffer = null, bool isReadFromServer = false)
        {
            return _omronFinsUdp.ReadInt16(address);
        }
        public OperateResult<int> ReadInt32(string address, byte[] buffer = null, bool isReadFromServer = false)
        {
            return _omronFinsUdp.ReadInt32(address);
        }
        public OperateResult<long> ReadInt64(string address, byte[] buffer = null, bool isReadFromServer = false)
        {
            return _omronFinsUdp.ReadInt64(address);
        }

        public OperateResult<float> ReadFloat(string address, byte[] buffer = null)
        {
            return _omronFinsUdp.ReadFloat(address, buffer);
        }

        public OperateResult<float[]> ReadFloat(string address, ushort length, byte[] buffer = null)
        {
            return _omronFinsUdp.ReadFloat(address, length, buffer);
        }

        public OperateResult<ushort> ReadUInt16(string address, byte[] buffer = null)
        {
            return _omronFinsUdp.ReadUInt16(address, buffer);
        }
        public OperateResult<uint> ReadUInt32(string address, byte[] buffer = null, bool isReadFromServer = false)
        {
            return _omronFinsUdp.ReadUInt32(address);
        }
        public OperateResult<ulong> ReadUInt64(string address, byte[] buffer = null, bool isReadFromServer = false)
        {
            return _omronFinsUdp.ReadUInt64(address);
        }
        public OperateResult<double> ReadDouble(string address, byte[] buffer = null, bool isReadFromServer = false)
        {
            return _omronFinsUdp.ReadDouble(address);
        }
        public OperateResult<bool> ReadBool(string address, byte[] buffer = null, bool isReadFromServer = false)
        {
            return _omronFinsUdp.ReadBool(address);
        }
        public OperateResult<string> ReadString(string address, ushort length, byte[] buffer = null)
        {
            return _omronFinsUdp.ReadString(address, length, buffer);
        }
        public OperateResult<byte[]> ReadRegister(string address, ushort length)
        {
            return _omronFinsUdp.Read(address, length);
        }
        public OperateResult<byte[]> ReadFromCoreServer(byte[] send)
        {
            return _omronFinsUdp.ReadFromCoreServer(send);
        }
        public OperateResult WriteInt16(string address, short value)
        {
            return _omronFinsUdp.Write(address, value);
        }
        public OperateResult WriteInt32(string address, int value)
        {
            return _omronFinsUdp.Write(address, value);
        }
        public OperateResult WriteInt64(string address, long value)
        {
            return _omronFinsUdp.Write(address, value);
        }
        public OperateResult WriteFloat(string address, float value)
        {
            return _omronFinsUdp.Write(address, value);
        }
        public OperateResult WriteUInt16(string address, ushort value)
        {
            return _omronFinsUdp.Write(address, value);
        }
        public OperateResult WriteUInt32(string address, uint value)
        {
            return _omronFinsUdp.Write(address, value);
        }
        public OperateResult WriteUInt64(string address, ulong value)
        {
            return _omronFinsUdp.Write(address, value);
        }
        public OperateResult WriteDouble(string address, double value)
        {
            return _omronFinsUdp.Write(address, value);
        }
        public OperateResult WriteBool(string address, bool value)
        {
            return _omronFinsUdp.Write(address, value);
        }
        public OperateResult WriteString(string address, string value)
        {
            return _omronFinsUdp.Write(address, value);
        }
        #endregion
    }
}
