using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Lead.CPrim.Interfaces.IMotionCard
{
    public interface IInterpolation
    {
        int GetAxisMotionMulticoorStatus(short crd);

        int GetInterpolationSta(int v);

        int InterpolationPause(int crd);

        int InterpolationStart(int crd);
        int InterpolationOpen(int crd, int axisNum, ushort[] axisList);
        int InterpolationStop(int crd, int stopMode);
        int InterpolationMove(int crd, int axisNum, ushort[] axisArry, List<TrajPos> trajPos);
        /// <summary>
        /// 连续插补中相对于轨迹段终点 IO 提前输出（段内执行）
        /// </summary>
        /// <param name="Crd">插补系</param>
        /// <param name="DoAdr">IO地址 0-31</param>
        /// <param name="On_Off">0低电平，1高电平</param>
        /// <param name="isTimemode">0时间，1距离</param>
        /// <param name="delayCount1">提前输出的时间/距离</param>
        /// <param name="delayConut2">IO翻转的时间/距离</param>
        /// <returns></returns>
        int AddInterpolationDO_OnStopAhead(ushort Crd, ushort DoAdr, bool On_Off, ushort isTimemode, double delayCount1, double delayConut2);
        /// <summary>
        /// 连续插补中相对于轨迹段终点 IO 滞后输出
        /// </summary>
        /// <param name="Crd">插补系</param>
        /// <param name="DoAdr">IO地址 0-31</param>
        /// <param name="On_Off">0低电平，1高电平</param>
        /// <param name="delayCount1">滞后输出时间</param>
        /// <param name="delayConut2">翻转时间（IO持续时间）</param>
        /// <returns></returns>
        int AddInterpolationDO_OnStopDelay(ushort Crd, ushort DoAdr, bool On_Off, double delayCount1, double delayConut2);

        /// <summary>
        /// 连续插补中相对于轨迹段起点 IO 滞后输出（段内执行）
        /// </summary>
        /// <param name="Crd">插补系</param>
        /// <param name="DoAdr">IO地址</param>
        /// <param name="On_Off">0低电平，1高电平</param>
        /// <param name="isTimemode">0时间，1距离</param>
        /// <param name="delayCount1">延迟时间</param>
        /// <param name="delayConut2">翻转时间</param>
        /// <returns></returns>
        int AddInterpolationDO_OnStartDelay(ushort Crd, ushort DoAdr, bool On_Off, ushort isTimemode, double delayCount1, double delayConut2);

        int AddInterpolationDO(ushort Crd, ushort DoAdr, bool On_Off, double DelayTimeS);
        int AddInterpolationDelayS(ushort Crd, double DelayTimeS);
        int AddInterpolationPoint(ushort Crd, ushort AxisNum, ushort[] AxisArry, TrajPos trajPos);
        int AddInterpolatioWaitDI(ushort Crd, ushort DiAdr, bool On_Off, double TimeOutS = 0);
    }
    public class TrajPos
    {
        public int Index { get; set; }
        public double[] Pos { get; set; }
        public double Tacc { get; set; } = 0.1;
        public double Tdec { get; set; } = 0.1;
        public bool TrajEnable { get; set; } = true;
        public double TrajVe { get; set; } = 0;
        public double TrajVm { get; set; }
        /// <summary>
        /// 0 直线
        /// 1 两轴圆弧圆心插补
        /// 2 两轴圆心半径插补
        /// 3 三轴圆弧圆心螺旋插补
        /// 4 三轴圆心半径螺旋插补
        /// </summary>
        public int IterpolationType { get; set; }
        /// <summary>
        /// 0 顺时针
        /// 1 逆时针
        /// </summary>
        public int ArcDir { get; set; }
        public int Circle { get; set; }
        /// <summary>
        /// 0 相对运动
        /// 1 绝对运动
        /// </summary>
        public int PosiMode { get; set; }

        public string TrajType { get; set; } = "直线";//0直线；1圆弧；2点；3提前开胶；4滞后开胶；5关胶
        public int Circlenum { set; get; }
        public double DisOpentime { set; get; }
        public double LengthOpen { set; get; }
        public double LengthClose { set; get; }
        public string TypeOpen { set; get; }
        public double Bitno { set; get; }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct PTStatus
    {
        public ushort BitSts; //b0: Is PTB work? [1:working, 0:Stopped]

        //b1: Is point buffer full? [1:full, 0:not full]
        //b2: Is point buffer empty? [1:empty, 0:not empty]
        //b3, b4, b5: Reserved for future
        //b6~: Be always 0
        public ushort PntBufFreeSpace;

        public ushort PntBufUsageSpace;
        public uint RunningCnt;
    }
}