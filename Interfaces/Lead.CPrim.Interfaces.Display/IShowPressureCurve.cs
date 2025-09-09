using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.Interfaces.Display
{
    /// <summary>Lead.CPrim.ShowPressureCurve对外接口</summary>
    public interface IShowPressureCurve
    {
        /// <summary>启动压力采集</summary>
        /// <param name="id">压力传感器id</param>
        /// <param name="SN">二维码</param>
        /// <returns>int</returns>
        int Start(int id, string SN);
        /// <summary>停止压力采集</summary>
        /// <param name="id">压力传感器id</param>
        /// <param name="SN">二维码</param>
        /// <returns>int</returns>
        int Stop(int id, string SN = "");
        /// <summary>获取压力值</summary>
        /// <param name="id">压力传感器id</param>
        /// <returns>int</returns>
        float GetPress(int id);

        //void Test();
    }
}
