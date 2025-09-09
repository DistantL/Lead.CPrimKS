using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.Interfaces.Dev
{
    /// <summary>
    /// 基恩士PLC接口
    /// </summary>
    public interface IKeyencePlc
    {
        /// <summary>值变化事件</summary>
        event Del_PlcVariableChanged OnPlcVariableChanged;

        /// <summary>清除Fins事件订阅</summary>
        /// <returns></returns>
        int ClearOnPlcVariableChanged();
        /// <summary>获取当前连接状态 true：连接成功；false：连接失败</summary>
        bool IsConnect { get; }
        /// <summary>
        /// 关闭连接
        /// </summary>
        void Close();

        /// <summary>
        /// 从字中得到位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        PLCRespons ReadBit(PLCBitSoftType type, uint Address, out bool data);

        /// <summary>
        /// 从字中得到位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="length">值长度</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        PLCRespons ReadBit(PLCBitSoftType type, uint Address, uint length, out bool[] data);
        /// <summary>
        /// 获取Bool值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">bool值</param>
        /// <returns>响应码</returns>
        PLCRespons ReadBoolWord(PLCByteSoftType type, uint Address, out bool data);

        /// <summary>
        /// 获取无符号16位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">Uint16值</param>
        /// <returns>响应码</returns>
        PLCRespons ReadUInt16Word(PLCByteSoftType type, uint Address, out UInt16 data);


        /// <summary>
        /// 获取无符号16位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="length">值长度，也是地址长度</param>
        /// <param name="data">Uint16值</param>
        /// <returns>响应码</returns>
        PLCRespons ReadUInt16Word(PLCByteSoftType type, uint Address, uint length, out UInt16[] data);


        /// <summary>
        /// 获取有符号16位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">int16值</param>
        /// <returns>响应码</returns>
        PLCRespons ReadInt16Word(PLCByteSoftType type, uint Address, out Int16 data);


        /// <summary>
        /// 获取有符号16位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="length">值长度，也是地址长度</param>
        /// <param name="data">int16值</param>
        /// <returns>响应码</returns>
        PLCRespons ReadInt16Word(PLCByteSoftType type, uint Address, uint length, out Int16[] data);


        /// <summary>
        /// 获取无符号32位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">Uint32值</param>
        /// <returns>响应码</returns>
        PLCRespons ReadUInt32Word(PLCByteSoftType type, uint Address, out UInt32 data);


        /// <summary>
        /// 获取无符号32位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="length">值长度，不是地址长度</param>
        /// <param name="data">Uint32值</param>
        /// <returns>响应码</returns>
        PLCRespons ReadUInt32Word(PLCByteSoftType type, uint Address, uint length, out UInt32[] data);

        /// <summary>
        /// 获取无符号64位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">Uint64值</param>
        /// <returns>响应码</returns>
        PLCRespons ReadUInt64Word(PLCByteSoftType type, uint Address, out UInt64 data);


        /// <summary>
        /// 获取无符号64位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="length">值长度，不是地址长度</param>
        /// <param name="data">Uint64值</param>
        /// <returns>响应码</returns>
        PLCRespons ReadUInt64Word(PLCByteSoftType type, uint Address, uint length, out UInt64[] data);

        /// <summary>
        /// 获取有符号32位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">int32值</param>
        /// <returns>响应码</returns>
        PLCRespons ReadInt32Word(PLCByteSoftType type, uint Address, out Int32 data);


        /// <summary>
        /// 获取有符号32位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="length">值长度，不是地址长度</param>
        /// <param name="data">int32值</param>
        /// <returns>响应码</returns>
        PLCRespons ReadInt32Word(PLCByteSoftType type, uint Address, uint length, out Int32[] data);

        /// <summary>
        /// 获取有符号64位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">int64值</param>
        /// <returns>响应码</returns>
        PLCRespons ReadInt64Word(PLCByteSoftType type, uint Address, out Int64 data);


        /// <summary>
        /// 获取有符号64位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="length">值长度，不是地址长度</param>
        /// <param name="data">int64值</param>
        /// <returns>响应码</returns>
        PLCRespons ReadInt64Word(PLCByteSoftType type, uint Address, uint length, out Int64[] data);


        /// <summary>
        /// 获取float的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">Float值</param>
        /// <returns>响应码</returns>
        PLCRespons ReadFloatWord(PLCByteSoftType type, uint Address, out float data);

        /// <summary>
        /// 获取float的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="length">值长度，不是地址长度</param>
        /// <param name="data">Float值</param>
        /// <returns>响应码</returns>
        PLCRespons ReadFloatWord(PLCByteSoftType type, uint Address, uint length, out float[] data);

        /// <summary>
        /// 获取Double的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">Double值</param>
        /// <returns>响应码</returns>
        PLCRespons ReadDoubleWord(PLCByteSoftType type, uint Address, out Double data);

        /// <summary>
        /// 获取Double的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="length">值长度，不是地址长度</param>
        /// <param name="data">Double值</param>
        /// <returns>响应码</returns>
        PLCRespons ReadDoubleWord(PLCByteSoftType type, uint Address, uint length, out Double[] data);

        /// <summary>
        /// 获取string的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">Float值</param>
        /// <param name="length">字符串长度，不是地址长度</param>
        /// <returns>响应码</returns>
        PLCRespons ReadString(PLCByteSoftType type, uint Address, out string data, uint length = 2);
        /// <summary>
        /// 获取string的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="length">地址长度，不是字符串长度</param>
        /// <returns>响应码</returns>
        PLCRespons ReadAddrLengthString(PLCByteSoftType type, uint Address, out string data, uint length = 2);

        /// <summary>
        /// 获取中文字符的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">Float值</param>
        /// <param name="length">字符串长度，不是地址长度</param>
        /// <returns>响应码</returns>
        PLCRespons ReadChineseString(PLCByteSoftType type, uint Address, out string data, uint length = 2);

        /// <summary>
        /// 写位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        PLCRespons WriteBit(PLCBitSoftType type, uint Address, bool data);

        /// <summary>
        /// 写位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        PLCRespons WriteBit(PLCBitSoftType type, uint Address, bool[] data);
        /// <summary>
        /// 写bool值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        PLCRespons WritBoolWord(PLCByteSoftType type, uint Address, bool data);

        /// <summary>
        /// 写无符号16位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        PLCRespons WriteUInt16Word(PLCByteSoftType type, uint Address, UInt16 data);

        /// <summary>
        /// 写无符号16位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        PLCRespons WriteUInt16Word(PLCByteSoftType type, uint Address, UInt16[] data);

        /// <summary>
        /// 写有符号16位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        PLCRespons WriteInt16Word(PLCByteSoftType type, uint Address, Int16 data);

        /// <summary>
        /// 写有符号16位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        PLCRespons WriteInt16Word(PLCByteSoftType type, uint Address, Int16[] data);

        /// <summary>
        /// 写无符号32位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        PLCRespons WriteUInt32Word(PLCByteSoftType type, uint Address, UInt32 data);

        /// <summary>
        /// 写无符号32位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        PLCRespons WriteUInt32Word(PLCByteSoftType type, uint Address, UInt32[] data);

        /// <summary>
        /// 写无符号64位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        PLCRespons WriteUInt64Word(PLCByteSoftType type, uint Address, UInt64 data);

        /// <summary>
        /// 写无符号64位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        PLCRespons WriteUInt64Word(PLCByteSoftType type, uint Address, UInt64[] data);

        /// <summary>
        /// 写有符号32位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        PLCRespons WriteInt32Word(PLCByteSoftType type, uint Address, Int32 data);

        /// <summary>
        /// 写有符号32位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        PLCRespons WriteInt32Word(PLCByteSoftType type, uint Address, Int32[] data);

        /// <summary>
        /// 写有符号64位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        PLCRespons WriteInt64Word(PLCByteSoftType type, uint Address, Int64 data);

        /// <summary>
        /// 写有符号64位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        PLCRespons WriteInt64Word(PLCByteSoftType type, uint Address, Int64[] data);

        /// <summary>
        /// 写字符串的值-指定字符长度
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>字符串</returns>
        PLCRespons WriteString(PLCByteSoftType type, uint Address, string data);
        /// <summary>
        /// 写字符串的值-指定地址长度
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <param name="length">地址长度，不是字符串长度</param>
        /// <returns>字符串</returns>
        PLCRespons WriteAddrLengthString(PLCByteSoftType type, uint Address, string data, uint length);

        /// <summary>
        /// 写Float的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        PLCRespons WriteFloatWord(PLCByteSoftType type, uint Address, float data);

        /// <summary>
        /// 写Float的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        PLCRespons WriteFloatWord(PLCByteSoftType type, uint Address, float[] data);
        /// <summary>
        /// 写Double的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        PLCRespons WriteDoubleWord(PLCByteSoftType type, uint Address, Double data);

        /// <summary>
        /// 写Double的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        PLCRespons WriteDoubleWord(PLCByteSoftType type, uint Address, Double[] data);
        /// <summary>
        /// 写中文字符串
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <param name="IsReverseAlarm">是否反转写入PLC报警内容的高低字节,默认false</param>
        /// <returns>响应码</returns>
        PLCRespons WriteChineseString(PLCByteSoftType type, uint Address, string data, bool IsReverseAlarm = false);
        /// <summary>按照名称读取数据</summary>
        /// <param name="valName"></param>
        /// <returns></returns>
        object ReadVariableFromName(string valName);
        /// <summary>按照名称写入数据</summary>
        /// <param name="valName"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        int WriteVariableFromName(string valName, object val);

    }
    /// <summary>
    /// 基恩士PLC返回类型
    /// </summary>
    public enum PLCRespons
    {
        None,
        OK,
        ReadOK,
        E0,
        E1,
        E2,
        E4,
        E5,
        E6,
        ERROR,
        TimeOut
    }
    /// <summary>
    /// 基恩士PLC寄存器类型
    /// </summary>
    public enum PLCByteSoftType
    {
        DM,
        EM,
        ZF
    }
    /// <summary>
    /// 基恩士PLC寄存器类型
    /// </summary>
    public enum PLCBitSoftType
    {
        MR,
        R
    }
}
