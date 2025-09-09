using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.Interfaces.IMotionCard
{
    public interface IPVT
    {
        #region PVT功能
        /// <summary>
        /// 开始PVT运动
        /// </summary>
        /// <param name="myAxis">轴ID数组</param>
        /// <returns></returns>
        int PvtMove(ushort[] myAxis);
        /// <summary>
        ///设置 PTT表格,所有数组的第一个参数必须为0
        /// </summary>
        /// <param name="myAxis">轴号</param>
        /// <param name="myPtTime">PTT时间数组，单位s</param>
        /// <param name="myPPos">PTT位置数组，单位unit</param>
        /// <returns></returns>
        int PttTableSet(ushort myAxis, double[] myPtTime, int[] myPPos);
        int PttTableSetAndMove(ushort myAxis, double[] myPtTime, int[] myPPos);
        /// <summary>
        /// 设置PTS表格,所有数组的第一个参数必须为0
        /// </summary>
        /// <param name="myAxis">轴号</param>
        /// <param name="myPtTime">PTS时间数组，单位s</param>
        /// <param name="myPPos">PTS位置数组，单位unit</param>
        /// <param name="myPPer">PTS百分比数组，即加速时间占运动时间的百分比</param>
        /// <returns></returns>
        int PtsTableSet(ushort myAxis, double[] myPtTime, int[] myPPos, double[] myPPer);
        int PtsTableSetAndMove(ushort myAxis, double[] myPtTime, int[] myPPos, double[] myPPer);
        /// <summary>
        /// 多轴的PVT运动，时间 位置 速度
        /// </summary>
        /// <param name="axisList">轴组的ID数组</param>
        /// <param name="count">点位数量/param>
        /// <param name="ptTime">时间的数量，单位s</param>
        /// <param name="ptPos">点位位置数组，单位unit</param>
        /// <param name="ptVel">点位速度数组，单位unit/s</param>
        /// <returns></returns>
        int PvtTableSet(ushort[] axisList, List<double[]> ptTime, List<int[]> ptPos, List<double[]> ptVel);
        int PvtTableSetAndMove(ushort[] axisList, List<double[]> ptTime, List<int[]> ptPos, List<double[]> ptVel);
        /// <summary>
        /// 多轴的PVTS运动，位置 时间
        /// </summary>
        /// <param name="axisList">轴组的ID数组</param>
        /// <param name="count">点位数量</param>
        /// <param name="ptTime">点位时间数组，单位s</param>
        /// <param name="ptPos">点位位置数组，单位unit</param>
        /// <param name="pVelBegin">轴起始速度数组</param>
        /// <param name="pVelEnd">轴停止速度数组</param>
        /// <returns></returns>
        int PvtsTableSet(ushort[] axisList, List<double[]> ptTime, List<int[]> ptPos, double[] pVelBegin = null, double[] pVelEnd = null);
        int PvtsTableSetAndMove(ushort[] axisList, List<double[]> ptTime, List<int[]> ptPos, double[] pVelBegin = null, double[] pVelEnd = null);
        #endregion
    }
}
