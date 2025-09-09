namespace Lead.CPrim.Interfaces.IMotionCard
{
    public interface IEtherCAT
    {
        /// <summary>获取从站对象字典参数值</summary>
        /// <param name="slaveNo">从站 EtherCAT 地址，第 i 个 EtherCAT 从站地址为 1000+i</param>
        /// <param name="odIndex">对象字典索引</param>
        /// <param name="subIndex">对象字典索引</param>
        /// <param name="length">对象字典索引长度(单位： bit)（该参数只有三个值： 8、 16 和 32）</param>
        /// <param name="value">对象字典索引参数值</param>
        /// <returns>0：OK；非0：错误代码</returns>
        int GetOdData(int slaveNo, int odIndex, int subIndex, int length, ref uint value);
        /// <summary>设置从站对象字典参数值</summary>
        /// <param name="slaveNo">从站 EtherCAT 地址，第 i 个 EtherCAT 从站地址为 1000+i</param>
        /// <param name="odIndex">对象字典索引</param>
        /// <param name="subIndex">对象字典子索引</param>
        /// <param name="length">对象字典索引长度(单位： bit)（该参数只有三个值： 8、 16 和 32）</param>
        /// <param name="value">对象字典索引参数值</param>
        /// <returns>0：OK；非0：错误代码</returns>
        int SetOdData(int slaveNo, int odIndex, int subIndex, int length, uint value);
    }
}