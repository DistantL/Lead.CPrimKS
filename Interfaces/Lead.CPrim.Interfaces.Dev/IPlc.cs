/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: IPlc.cs
 * Author: Victor
 * Description: Fins通讯用户接口
 * CreateTime: 2020-02-26
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.22.0904><Victor><20220904>
 * 1、增加文件说明
 * 
 * <3.3.22.1010><Victor><20221016>
 * 1、IOmronFins进行重构（由服务器获取数据变更为从服务器或者从byte[]）
******************************************************************************/

using CommunicationBase;

namespace Lead.CPrim.Interfaces
{
    /// <summary>Fins值变化委托</summary>
    /// <param name="valName">名称</param>
    /// <param name="valAddr">地址</param>
    /// <param name="valType">类型</param>
    /// <param name="valLast">上次值</param>
    /// <param name="valCur">当前值</param>
    /// <returns>int</returns>
    public delegate void Del_PlcVariableChanged(string valName, string valAddr, string valType, object valLast,
        object valCur);


    /// <summary>Fins类型</summary>
    public enum FinsType
    {
        /// <summary>Other</summary>
        Other = 0,
        /// <summary>Udp</summary>
        FinsUdp = 1,
        /// <summary>Net</summary>
        FinsNet = 2,
    }


    /// <summary>欧姆龙Fins（基元用户接口）</summary>
    public interface IPlc
    {
        /// <summary>值变化事件</summary>
        event Del_PlcVariableChanged OnPlcVariableChanged;

        /// <summary>值变化事件</summary>
        event Del_PlcVariableChanged OnPlcVariableChanged2;

        /// <summary>值变化事件</summary>
        event Del_PlcVariableChanged OnPlcVariableChanged3;

        /// <summary>true：连接成功；false：连接失败</summary>
        bool Conneted { get; }

        /// <summary>清除Fins事件订阅</summary>
        /// <returns></returns>
        void ClearOnPlcVariableChanged();

        /// <summary>清除Fins事件订阅</summary>
        /// <returns></returns>
        void ClearOnPlcVariableChanged2();

        /// <summary>清除Fins事件订阅</summary>
        /// <returns></returns>
        void ClearOnPlcVariableChanged3();

        /// <summary>
        /// 所有参数进行初始化
        /// </summary>
        void PlcVariableInit();

        /// <summary>按照地址读取数据</summary>
        /// <param name="valAddr"></param>
        /// <returns></returns>
        object ReadVariableFromAddr(string valAddr);
        /// <summary>按照地址类型读取数据</summary>
        /// <param name="valAddr"></param>
        /// <param name="valType"></param>
        /// <returns></returns>
        object ReadVariableFromAddr(string valAddr, ProtocolDataType valType, ushort length = 0);
        /// <summary>按照名称读取数据</summary>
        /// <param name="valName"></param>
        /// <returns></returns>
        object ReadVariableFromName(string valName);

        /// <summary>
        /// 根据名称写入数据
        /// </summary>
        /// <param name="valName">变量名称</param>
        /// <param name="varValue">变量值</param>
        /// <returns></returns>
        int Write(string valName, object varValue);
    }


    /// <summary>欧姆龙Fins（net与udp初始化使用）</summary>
    public interface IOmronFins
    {
        /// <summary>连接</summary>
        /// <returns></returns>
        bool Connect();

        /// <summary>断开连接</summary>
        /// <returns></returns>
        bool DisConnect();

        OperateResult<short> ReadInt16(string address, byte[] buffer = null, bool isReadFromServer = true);
        OperateResult<int> ReadInt32(string address, byte[] buffer = null, bool isReadFromServer = true);
        OperateResult<long> ReadInt64(string address, byte[] buffer = null, bool isReadFromServer = true);

        /// <summary>
        /// 读取float
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="buffer">null：从PLC获取；非null：直接将byte[]进行转化</param>
        /// <returns></returns>
        OperateResult<float> ReadFloat(string address, byte[] buffer = null);

        /// <summary>
        /// 读取float[]
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="length">长度</param>
        /// <param name="buffer">null：从PLC获取；非null：直接将byte[]进行转化</param>
        /// <returns></returns>
        OperateResult<float[]> ReadFloat(string address, ushort length, byte[] buffer = null);

        /// <summary>
        /// 读取ushort
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="buffer">null：从PLC获取；非null：直接将byte[]进行转化</param>
        /// <returns></returns>
        OperateResult<ushort> ReadUInt16(string address, byte[] buffer = null);

        OperateResult<uint> ReadUInt32(string address, byte[] buffer = null, bool isReadFromServer = true);
        OperateResult<ulong> ReadUInt64(string address, byte[] buffer = null, bool isReadFromServer = true);
        OperateResult<double> ReadDouble(string address, byte[] buffer = null, bool isReadFromServer = true);
        OperateResult<bool> ReadBool(string address, byte[] buffer = null, bool isReadFromServer = true);

        /// <summary>
        /// 读取string
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="length">长度</param>
        /// <param name="buffer">null：从PLC获取；非null：直接将byte[]进行转化</param>
        /// <returns></returns>
        OperateResult<string> ReadString(string address, ushort length, byte[] buffer = null);

        OperateResult<byte[]> ReadRegister(string address, ushort length);

        OperateResult<byte[]> ReadFromCoreServer(byte[] send);

        OperateResult WriteInt16(string address, short value);
        OperateResult WriteInt32(string address, int value);
        OperateResult WriteInt64(string address, long value);
        OperateResult WriteFloat(string address, float value);
        OperateResult WriteUInt16(string address, ushort value);
        OperateResult WriteUInt32(string address, uint value);
        OperateResult WriteUInt64(string address, ulong value);
        OperateResult WriteDouble(string address, double value);
        OperateResult WriteBool(string address, bool value);
        OperateResult WriteString(string address, string value);
    }
}