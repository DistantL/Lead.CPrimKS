/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: FinsNet.cs
 * Author: Victor
 * Description: 欧姆龙Fins通讯FinsNet通讯类
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

using CommunicationBase;
using CommunicationBase.Profinet.Omron;
using Lead.CPrim.Interfaces;
using System.Threading.Tasks;

namespace Lead.CPrim.PrimFinsNet
{
    public class FinsNet : IOmronFins
    {
        #region Field
        private OmronFinsNet _omronFinsNet;
        #endregion



        #region Ctor
        public FinsNet()
        {
            _omronFinsNet = new OmronFinsNet();
            _omronFinsNet.ConnectTimeOut = 1000;
        }
        public FinsNet(string ip, int port) : this()
        {
            _omronFinsNet.IpAddress = ip;
            _omronFinsNet.Port = port;
        }
        public FinsNet(string ip, int port, byte sa1, byte da1, byte da2) : this(ip, port)
        {
            _omronFinsNet.SA1 = sa1;
            _omronFinsNet.DA1 = da1;
            _omronFinsNet.DA2 = da2;
        }
        #endregion



        #region Override IOmronFins
        public bool Connect()
        {
            OperateResult result = _omronFinsNet.ConnectServer();
            return result.IsSuccess;
        }
        public bool DisConnect()
        {
            OperateResult result = _omronFinsNet.ConnectClose();
            return result.IsSuccess;
        }

        public OperateResult<short> ReadInt16(string address, byte[] buffer = null, bool isReadFromServer = true)
        {
            return _omronFinsNet.ReadInt16(address);
        }
        public OperateResult<int> ReadInt32(string address, byte[] buffer = null, bool isReadFromServer = true)
        {
            return _omronFinsNet.ReadInt32(address);
        }
        public OperateResult<long> ReadInt64(string address, byte[] buffer = null, bool isReadFromServer = true)
        {
            return _omronFinsNet.ReadInt64(address);
        }
        public OperateResult<float> ReadFloat(string address, byte[] buffer = null)
        {
            return _omronFinsNet.ReadFloat(address, buffer);
        }

        public OperateResult<float[]> ReadFloat(string address, ushort length, byte[] buffer = null)
        {
            return _omronFinsNet.ReadFloat(address, length, buffer);
        }

        public OperateResult<ushort> ReadUInt16(string address, byte[] buffer = null)
        {
            return _omronFinsNet.ReadUInt16(address, buffer);
        }
        public OperateResult<uint> ReadUInt32(string address, byte[] buffer = null, bool isReadFromServer = true)
        {
            return _omronFinsNet.ReadUInt32(address);
        }
        public OperateResult<ulong> ReadUInt64(string address, byte[] buffer = null, bool isReadFromServer = true)
        {
            return _omronFinsNet.ReadUInt64(address);
        }
        public OperateResult<double> ReadDouble(string address, byte[] buffer = null, bool isReadFromServer = true)
        {
            return _omronFinsNet.ReadDouble(address);
        }
        public OperateResult<bool> ReadBool(string address, byte[] buffer = null, bool isReadFromServer = true)
        {
            return _omronFinsNet.ReadBool(address);
        }
        public OperateResult<string> ReadString(string address, ushort length, byte[] buffer = null)
        {
            return _omronFinsNet.ReadString(address, length, buffer);
        }
        public OperateResult<byte[]> ReadRegister(string address, ushort length)
        {
            return _omronFinsNet.Read(address, length);
        }
        public OperateResult<byte[]> ReadFromCoreServer(byte[] send)
        {
            return _omronFinsNet.ReadFromCoreServer(send);
        }


        public OperateResult WriteInt16(string address, short value)
        {
            return _omronFinsNet.Write(address, value);
        }
        public OperateResult WriteInt32(string address, int value)
        {
            return _omronFinsNet.Write(address, value);
        }
        public OperateResult WriteInt64(string address, long value)
        {
            return _omronFinsNet.Write(address, value);
        }
        public OperateResult WriteFloat(string address, float value)
        {
            return _omronFinsNet.Write(address, value);
        }
        public OperateResult WriteUInt16(string address, ushort value)
        {
            return _omronFinsNet.Write(address, value);
        }
        public OperateResult WriteUInt32(string address, uint value)
        {
            return _omronFinsNet.Write(address, value);
        }
        public OperateResult WriteUInt64(string address, ulong value)
        {
            return _omronFinsNet.Write(address, value);
        }
        public OperateResult WriteDouble(string address, double value)
        {
            return _omronFinsNet.Write(address, value);
        }
        public OperateResult WriteBool(string address, bool value)
        {
            return _omronFinsNet.Write(address, value);
        }
        public OperateResult WriteString(string address, string value)
        {
            return _omronFinsNet.Write(address, value);
        }
        #endregion
    }
}
