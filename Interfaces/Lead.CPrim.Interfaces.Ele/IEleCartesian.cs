using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Windows.Forms;
using Lead.CPrim.Interfaces.StateMachine;
using Newtonsoft.Json;

namespace Lead.CPrim.Interfaces.Ele
{
    /// <summary>轴组名称</summary>
    public enum Axis
    {
        /// <summary>X轴</summary>
        X = 1,
        /// <summary>Y轴</summary>
        Y = 2,
        /// <summary>Z轴</summary>
        Z = 3,
        /// <summary>U轴</summary>
        U = 4,
        /// <summary>V轴</summary>
        V = 5,
        /// <summary>W轴</summary>
        W = 6
    }



    /// <summary>轴组轴组接口【IEleCartesian】对接用户</summary>
    public interface IEleCartesian
    {
        /// <summary>轴组接口【IEleCartesian】轴组配置目录</summary>
        string AxisesConfigPath { set; get; }
        /// <summary>轴组接口【IEleCartesian】轴组点位目录</summary>
        string PointsPath { set; get; }
        /// <summary>轴组接口【IEleCartesian】轴集合</summary>
        ConcurrentDictionary<int, IEleAxis> Axises { set; get; }
        /// <summary>轴组接口【IEleCartesian】轴总数</summary>
        int AxisNum { set; get; }
        /// <summary>轴组接口【IEleCartesian】轴Id数组</summary>
        int[] AxisIndex { get; }
        /// <summary>轴组接口【IEleCartesian】X轴Id</summary>
        int AxisXIndex { get; }
        /// <summary>轴组接口【IEleCartesian】Y轴Id</summary>
        int AxisYIndex { get; }
        /// <summary>轴组接口【IEleCartesian】Z轴Id</summary>
        int AxisZIndex { get; }
        /// <summary>轴组接口【IEleCartesian】U轴Id</summary>
        int AxisUIndex { get; }
        /// <summary>轴组接口【IEleCartesian】V轴Id</summary>
        int AxisVIndex { get; }
        /// <summary>轴组接口【IEleCartesian】W轴Id</summary>
        int AxisWIndex { get; }
        /// <summary>轴组接口【IEleCartesian】轴组点位集合</summary>
        CartesianPoints Points { set; get; }
        /// <summary>轴组接口【IEleCartesian】速度模式/时间模式</summary>
        AccDecType VelMode { set; get; }
        /// <summary>轴组接口【IEleCartesian】X轴</summary>
        IEleAxis X { set; get; }
        /// <summary>轴组接口【IEleCartesian】Y轴</summary>
        IEleAxis Y { set; get; }
        /// <summary>轴组接口【IEleCartesian】Z轴</summary>
        IEleAxis Z { set; get; }
        /// <summary>轴组接口【IEleCartesian】U轴</summary>
        IEleAxis U { set; get; }
        /// <summary>轴组接口【IEleCartesian】V轴</summary>
        IEleAxis V { set; get; }
        /// <summary>轴组接口【IEleCartesian】W轴</summary>
        IEleAxis W { set; get; }
        /// <summary>轴组接口【IEleCartesian】指令位置与编码器位置差值极限
        /// <para>暂未使用</para></summary>
        double PosLimit { set; get; }
        /// <summary>轴组接口【IEleCartesian】运动超时设定
        /// <para>暂未使用</para></summary>
        double TimeOutS { set; get; }


        #region GroupJumpAbs
        /// <summary>GroupJumpAbs</summary>
        /// <param name="posIndex"></param>
        /// <param name="jumpPosValue"></param>
        /// <param name="jumpMode">true：相对模式；false：绝对模式</param>
        /// <param name="ratio"></param>
        /// <param name="timeoutS"></param>
        /// <param name="asyncMode"></param>
        /// <param name="checkLimit"></param>
        /// <param name="task"></param>
        /// <param name="eleLevel"></param>
        /// <returns></returns>
        int GroupJumpAbs(int posIndex, double jumpPosValue, bool jumpMode = false, ushort ratio = 100,
            int timeoutS = -1, bool asyncMode = false, bool checkLimit = true, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err);
        int GroupJumpAbs(string posName, double jumpPosValue, bool jumpMode = false, ushort ratio = 100,
            int timeoutS = -1, bool asyncMode = false, bool checkLimit = true, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err);
        int GroupJumpAbs(double[] pos, double jumpPosValue, bool jumpMode = false, ushort ratio = 100,
            int timeoutS = -1, bool asyncMode = false, bool checkLimit = true, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err);
        int GroupJumpAbs(double[] pos, double[] vel, double jumpPosValue, bool jumpMode = false, ushort ratio = 100,
            int timeoutS = -1, bool asyncMode = false, bool checkLimit = true, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err);
        int GroupJumpAbs(Pos pos, double jumpPosValue, bool jumpMode = false, ushort ratio = 100, int timeoutS = -1,
            bool asyncMode = false, bool checkLimit = true, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err);
        #endregion

        #region GroupMoveAbs
        int GroupMoveAbs(int posIndex, ushort ratio = 100, int timeoutS = -1, bool asyncMode = false,
            bool checkLimit = true, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100);
        int GroupMoveAbs(string posName, ushort ratio = 100, int timeoutS = -1, bool asyncMode = false,
            bool checkLimit = true, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100);
        int GroupMoveAbs(double[] pos, ushort ratio = 100, int timeoutS = -1, bool asyncMode = false,
            bool checkLimit = true, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100);
        int GroupMoveAbs(double[] pos, double[] vel, ushort ratio = 100, int timeoutS = -1, bool asyncMode = false,
            bool checkLimit = true, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100);
        /// <summary>轴组接口【IEleCartesian】GroupMoveAbs（Pos最大速度指定速率）</summary>
        /// <param name="pos">Pos点位</param>
        /// <param name="ratio">速率</param>
        /// <param name="timeoutS">超时时间（s）</param>
        /// <param name="asyncMode">true：异步；false：同步</param>
        /// <param name="checkLimit">true：检查限位；false：不检查限位</param>
        /// <param name="task">任务</param>
        /// <param name="eleLevel">报警等级（默认err）</param>
        /// <param name="checkPosDelay">运动指令后延迟</param>
        /// <returns>0：OK；非0：报错代码</returns>
        int GroupMoveAbs(Pos pos, ushort ratio = 100, int timeoutS = -1, bool asyncMode = false, bool checkLimit = true, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100);
        /// <summary>轴组接口【IEleCartesian】GroupMoveAbs（Pos指定速度指定速率）</summary>
        /// <param name="pos">Pos点位</param>
        /// <param name="vel">速度</param>
        /// <param name="ratio">速率</param>
        /// <param name="timeoutS">超时时间（s）</param>
        /// <param name="asyncMode">true：异步；false：同步</param>
        /// <param name="checkLimit">true：检查限位；false：不检查限位</param>
        /// <param name="task">任务</param>
        /// <param name="eleLevel">报警等级（默认err）</param>
        /// <param name="checkPosDelay">运动指令后延迟</param>
        /// <returns>0：OK；非0：报错代码</returns>
        int GroupMoveAbs(Pos pos, Vel vel, ushort ratio = 100, int timeoutS = -1, bool asyncMode = false, bool checkLimit = true, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100);
        #endregion

        #region Group
        /// <summary>轴组接口【IEleCartesian】轴组回原点</summary>
        /// <param name="timeoutS">超时时间</param>
        /// <param name="task">任务</param>
        /// <param name="eleLevel">报警等级（默认Err）</param>
        /// <returns></returns>
        int GroupHome(int timeoutS = -1, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err);
        int GroupChangeVel(double[] newVel);
        int GroupChangeVel(Vel newVel);
        int GroupResetAlarm();
        /// <summary>轴组接口【IEleCartesian】轴组使能</summary>
        /// <param name="enable">true：上使能；false：下使能</param>
        /// <param name="task">任务</param>
        /// <param name="eleLevel">报警等级（默认Err）</param>
        /// <returns>int</returns>
        int GroupSetEnable(bool enable, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err);

        int GroupSetFeedbackToPostion();

        int GroupSetVelRatio(ushort ratio);
        /// <summary>轴组接口【IEleCartesian】轴组停止</summary>
        /// <returns>int</returns>
        int GroupStop();
        #endregion

        #region SingleMoveAbs
        int SingleMoveAbs(int axisIndex, double pos, double vel, ushort ratio = 100, bool checkLimit = true,
            bool asyncMode = false, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100);
        int SingleMoveAbs(int axisIndex, int posIndex, ushort ratio = 100, bool checkLimit = true,
            bool asyncMode = false, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100);
        int SingleMoveAbs(int axisIndex, string posName, ushort ratio = 100, bool checkLimit = true,
            bool asyncMode = false, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100);
        int SingleMoveAbs(string axisName, double pos, double vel, ushort ratio = 100, bool checkLimit = true,
            bool asyncMode = false, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100);
        int SingleMoveAbs(string axisName, int posIndex, ushort ratio = 100, bool checkLimit = true,
            bool asyncMode = false, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100);
        int SingleMoveAbs(string axisName, string posName, ushort ratio = 100, bool checkLimit = true,
            bool asyncMode = false, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100);
        #endregion

        #region SingleMoveRel
        int SingleMoveRel(int axisIndex, double pos, ushort ratio = 100, bool checkLimit = true, bool asyncMode = false,
            ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100);
        int SingleMoveRel(int axisIndex, double pos, double vel, ushort ratio = 100, bool checkLimit = true,
            bool asyncMode = false, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100);
        /// <summary>轴组接口【IEleCartesian】轴组单轴移动</summary>
        /// <param name="axisIndex">轴号</param>
        /// <param name="pos">位置</param>
        /// <param name="vel">速度</param>
        /// <param name="acc">加速时间</param>
        /// <param name="dec">减速时间</param>
        /// <param name="ratio">速度比率</param>
        /// <param name="checkLimit">极限检查</param>
        /// <param name="asyncMode">是否异步</param>
        /// <param name="task">任务</param>
        /// <param name="eleLevel">报警等级</param>
        /// <param name="checkPosDelay">位置检查延时</param>
        /// <returns>int</returns>
        int SingleMoveRel(int axisIndex, double pos, double vel, double acc, double dec, ushort ratio = 100,
            bool checkLimit = true, bool asyncMode = false, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100);
        int SingleMoveRel(string axisName, double pos, ushort ratio = 100, bool checkLimit = true,
            bool asyncMode = false, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100);
        int SingleMoveRel(string axisName, double pos, double vel, ushort ratio = 100, bool checkLimit = true,
            bool asyncMode = false, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100);
        int SingleMoveRel(string axisName, double pos, double vel, double acc, double dec, ushort ratio = 100,
            bool checkLimit = true, bool asyncMode = false, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100);
        #endregion

        #region Single
        int SingleChangeVel(int axisIndex, double newVel);
        int SingleChangeVel(string axisName, double newVel);
        /// <summary>轴组接口【IEleCartesian】轴组_轴回原点</summary>
        /// <param name="axisIndex">轴号</param>
        /// <param name="timeoutS">超时时间</param>
        /// <param name="task">任务</param>
        /// <param name="eleLevel">报警级别（默认Err）</param>
        /// <returns>int</returns>
        int SingleHome(int axisIndex, int timeoutS = -1, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err);

        int SingleHome(string axisName, int timeoutS = -1, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err);

        int SingleResetAlarm(int axisIndex);
        int SingleResetAlarm(string axisName);
        int SingleSetAccDec(int axisIndex, double acc, double dec);
        int SingleSetDefaultVel(int axisIndex, ushort ratio = 100);
        /// <summary>轴组接口【IEleCartesian】轴组_轴使能</summary>
        /// <param name="axisIndex">轴Id</param>
        /// <param name="enable">使能</param>
        /// <param name="task">任务</param>
        /// <param name="eleLevel">报警等级（默认Err）</param>
        /// <returns>int</returns>
        int SingleSetEnable(int axisIndex, bool enable, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err);
        int SingleSetEnable(string axisName, bool enable, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err);
        int SingleSetFeedbackToPosition(int axisIndex);
        int SingleSetPosition(int axisIndex, double pos);
        int SingleSetVel(int axisIndex, double startVel, double maxVel, double endVel, double acc, double dec);
        int SingleSetVel(int axisIndex, double startVel, double maxVel, double endVel);
        /// <summary>轴组接口【IEleCartesian】指定轴停止</summary>
        /// <param name="axisIndex">轴号</param>
        /// <returns>int</returns>
        int SingleStop(int axisIndex);
        int SingleStop(string axisName);
        #endregion

        #region Other

        bool IsStop { get; }

        int AxisHasAlarm(bool elEnable = true);

        bool AxisInLocation(int axisIndex, string posName);

        bool AxisInLocation(int axisIndex, int posIndex);

        bool AxisInLocation(int axisIndex, double pos);

        bool AxisInLocation(string axisName, string posName);

        bool AxisInLocation(string axisName, int posIndex);

        bool AxisInLocation(string axisName, double pos);

        List<Pos> CartDebugUi_GetPosList(Guid id);

        Pos GetActualPos();

        IEleAxis GetAxisByGId(string gid);

        IEleAxis GetAxisById(IPrim prim, int id);

        IEleAxis GetAxisByIndex(int index);

        IEleAxis GetAxisByName(string name);

        int GetPosByIndex(int index, out Pos position);

        int GetPosByName(string name, out Pos position);

        int GetPosByName(string name, out double[] position);

        bool InLocation(string posName);

        bool InLocation(int posIndex);

        bool InLocation(double[] pos);

        bool InLocation(Pos pos);

        bool InLocation(Pos pos, int multipleValue);

        bool InLocation(double[] pos, double[] errChk);

        bool InLocation(double[] pos, int[] axisIndex);

        bool InLocation(Pos pos, Pos errChkPos);
        /// <summary>轴组接口【IEleCartesian】DebugUi获取</summary>
        /// <param name="id">Guid</param>
        /// <param name="ele">轴组接口</param>
        /// <param name="poslist">点位列表</param>
        /// <param name="timerEnable">true：实时更新实时位置；false：不更新实时位置</param>
        /// <returns>Control</returns>
        Control NewCartDebugUi(Guid id, IEleCartesian ele, List<Pos> poslist, bool timerEnable = false);

        double[] PosToArray(Pos pos);

        double[] PosToGearRatioArray(Pos pos);

        void RefreshDebugUi();

        int[] ReturnAxisesId();

        Pos UpdatePos(Pos oldPos);
        #endregion

        #region StationTask
        /// <summary>轴组接口【IEleCartesian】任务</summary>
        ITask CurTask { set; get; }
        /// <summary>轴组接口【IEleCartesian】确认自动模式</summary>
        /// <param name="task">任务</param>
        /// <returns>bool</returns>
        bool AssertAutoMode(ITask task);
        /// <summary>轴组接口【IEleCartesian】进入任务</summary>
        /// <param name="task">任务</param>
        /// <returns>IEle</returns>
        IEle EnterTask(ITask task = null);
        /// <summary>轴组接口【IEleCartesian】进入任务</summary>
        /// <returns>IEle</returns>
        IEle ExitTask();
        #endregion StationTask
    }



    /// <summary>轴组点位集合</summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class CartesianPoints
    {
        /// <summary>Ctor无参</summary>
        public CartesianPoints()
        {
            GroupPoints = new ConcurrentDictionary<int, PosCartesian>();
            MotionPoints = new List<PosMotion>();
            SingleAxisPoints = new ConcurrentDictionary<int, SingleAxisPoints>();
        }

        /// <summary>轴组点位集合</summary>
        public ConcurrentDictionary<int, PosCartesian> GroupPoints { set; get; }
        /// <summary>DataGridView点位列表集合</summary>
        [JsonIgnore] public List<PosMotion> MotionPoints { set; get; }
        /// <summary>单轴集合</summary>
        public ConcurrentDictionary<int, SingleAxisPoints> SingleAxisPoints { set; get; }
    }
    public class PosCartesian
    {
        /// <summary>序号</summary>
        public int Index { set; get; }
        /// <summary>名称</summary>
        public string Name { set; get; }
        /// <summary>点位</summary>
        public double[] Pos { set; get; }
    }
    public class PosMotion
    {
        public int Index { set; get; }
        public string Name { set; get; }
        public double U { set; get; }
        public double V { set; get; }
        public double W { set; get; }
        public double X { set; get; }
        public double Y { set; get; }
        public double Z { set; get; }
    }
    /// <summary>点位管理_单轴点位集合</summary>
    public class SingleAxisPoints
    {
        /// <summary>Ctor无参</summary>
        public SingleAxisPoints()
        {
            Points = new ConcurrentDictionary<int, SingleAxisPoint>();
        }

        /// <summary>Ctor有一个参数</summary>
        /// <param name="points"></param>
        public SingleAxisPoints(ConcurrentDictionary<int, SingleAxisPoint> points)
        {
            Points = points;
        }

        public ConcurrentDictionary<int, SingleAxisPoint> Points { set; get; }
    }
    /// <summary>点位管理_单轴点位</summary>
    public struct SingleAxisPoint
    {
        /// <summary>点位序号</summary>
        public int Index;
        /// <summary>点位名称</summary>
        public string Name;
        /// <summary>点位坐标</summary>
        public double Position;
        /// <summary>最大速度</summary>
        public double Velocity;
        /// <summary>最小速度</summary>
        public double MinVelocity;
        /// <summary>加速时间</summary>
        public double AccTime;
        /// <summary>减速时间</summary>
        public double DecTime;
        /// <summary>加速度</summary>
        public double Acceleration;
        /// <summary>减速度</summary>
        public double Deceleration;
    }



    /// <summary>
    /// 点位（数组0对应名称；数组1-6对应X-W）
    /// </summary>
    public class Pos
    {
        #region Ctor
        public Pos()
        {
            Name = "";
            X = -999.999;
            Y = -999.999;
            Z = -999.999;
            U = -999.999;
            V = -999.999;
            W = -999.999;
        }
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="str">数组0对应名称；数组1-6对应X-W</param>
        public Pos(string str)
        {
            var strs = str.Split(',');
            if (strs.Length >= 7) W = double.TryParse(strs[6], out var value) ? value : -999.999;
            if (strs.Length >= 6) V = double.TryParse(strs[5], out var value) ? value : -999.999;
            if (strs.Length >= 5) U = double.TryParse(strs[4], out var value) ? value : -999.999;
            if (strs.Length >= 4) Z = double.TryParse(strs[3], out var value) ? value : -999.999;
            if (strs.Length >= 3) Y = double.TryParse(strs[2], out var value) ? value : -999.999;
            if (strs.Length >= 2) X = double.TryParse(strs[1], out var value) ? value : -999.999;
            Name = strs[0];
        }
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="name">点位名称</param>
        /// <param name="x">X轴坐标</param>
        /// <param name="y">Y轴坐标</param>
        /// <param name="z">Z轴坐标</param>
        /// <param name="u">U轴坐标</param>
        /// <param name="v">V轴坐标</param>
        /// <param name="w">W轴坐标</param>
        public Pos(string name, double x, double y, double z, double u, double v, double w)
        {
            Name = name;
            X = x;
            Y = y;
            Z = z;
            U = u;
            V = v;
            W = w;
        }
        #endregion



        #region Prop
        /// <summary>点位名称</summary>
        public string Name { set; get; }
        /// <summary>X轴坐标</summary>
        public double X { set; get; }
        /// <summary>Y轴坐标</summary>
        public double Y { set; get; }
        /// <summary>Z轴坐标</summary>
        public double Z { set; get; }
        /// <summary>U轴坐标</summary>
        public double U { set; get; }
        /// <summary>V轴坐标</summary>
        public double V { set; get; }
        /// <summary>W轴坐标</summary>
        public double W { set; get; }
        #endregion



        #region MethodExternalUsing
        /// <summary>返回点位名称及坐标拼接</summary>
        /// <returns>点位名称及坐标拼接</returns>
        public string PosToString()
        {
            return $"{Name},{X},{Y},{Z},{U},{V},{W}";
        }
        /// <summary>返回点位名称</summary>
        /// <returns>点位名称</returns>
        public override string ToString()
        {
            return Name;
        }
        /// <summary>点位相加</summary>
        /// <param name="b">点位b</param>
        /// <param name="c">点位c</param>
        /// <returns>b+c</returns>
        public static Pos operator+(Pos b, Pos c)
        {
            return new Pos("", b.X + c.X, b.Y + c.Y, b.Z + c.Z, b.U + c.U, b.V + c.V, b.W + c.W);
        }
        /// <summary>点位相减</summary>
        /// <param name="b">点位b</param>
        /// <param name="c">点位c</param>
        /// <returns>b-c</returns>
        public static Pos operator-(Pos b, Pos c)
        {
            return new Pos("", b.X - c.X, b.Y - c.Y, b.Z - c.Z, b.U - c.U, b.V - c.V, b.W - c.W);
        }
        #endregion
    }



    /// <summary>速度（数组0-5对应X-W）</summary>
    public class Vel
    {
        #region Ctor
        /// <summary>Ctor无参</summary>
        public Vel()
        {
            X = 0;
            Y = 0;
            Z = 0;
            U = 0;
            V = 0;
            W = 0;
        }
        /// <summary>Ctor有1个参数</summary>
        /// <param name="str">数组0-5对应X-W</param>
        public Vel(string str)
        {
            var strs = str.Split(',');
            if (strs.Length >= 6) W = double.TryParse(strs[5], out var value) ? value : 0;
            if (strs.Length >= 5) V = double.TryParse(strs[4], out var value) ? value : 0;
            if (strs.Length >= 4) U = double.TryParse(strs[3], out var value) ? value : 0;
            if (strs.Length >= 3) Z = double.TryParse(strs[2], out var value) ? value : 0;
            if (strs.Length >= 2) Y = double.TryParse(strs[1], out var value) ? value : 0;
            if (!string.IsNullOrEmpty(strs[0])) X = double.TryParse(strs[0], out var value) ? value : 0;
        }
        /// <summary>Ctor有2个参数</summary>
        /// <param name="axis">指定轴（指定轴指定速度，其余均为0）</param>
        /// <param name="vel">速度</param>
        public Vel(Axis axis, double vel)
        {
            switch (axis)
            {
                case Axis.X:
                    X = vel;
                    Y = 0;
                    Z = 0;
                    U = 0;
                    V = 0;
                    W = 0;
                    break;
                case Axis.Y:
                    X = 0;
                    Y = vel;
                    Z = 0;
                    U = 0;
                    V = 0;
                    W = 0;
                    break;
                case Axis.Z:
                    X = 0;
                    Y = 0;
                    Z = vel;
                    U = 0;
                    V = 0;
                    W = 0;
                    break;
                case Axis.U:
                    X = 0;
                    Y = 0;
                    Z = 0;
                    U = vel;
                    V = 0;
                    W = 0;
                    break;
                case Axis.V:
                    X = 0;
                    Y = 0;
                    Z = 0;
                    U = 0;
                    V = vel;
                    W = 0;
                    break;
                case Axis.W:
                    X = 0;
                    Y = 0;
                    Z = 0;
                    U = 0;
                    V = 0;
                    W = vel;
                    break;
            }
        }
        /// <summary>Ctor有6个参数</summary>
        /// <param name="x">X轴速度</param>
        /// <param name="y">Y轴速度</param>
        /// <param name="z">Z轴速度</param>
        /// <param name="u">U轴速度</param>
        /// <param name="v">V轴速度</param>
        /// <param name="w">W轴速度</param>
        public Vel(double x, double y, double z, double u, double v, double w)
        {
            X = x;
            Y = y;
            Z = z;
            U = u;
            V = v;
            W = w;
        }
        #endregion

        #region Prop
        /// <summary>X轴速度</summary>
        public double X { set; get; }
        /// <summary>Y轴速度</summary>
        public double Y { set; get; }
        /// <summary>Z轴速度</summary>
        public double Z { set; get; }
        /// <summary>U轴速度</summary>
        public double U { set; get; }
        /// <summary>V轴速度</summary>
        public double V { set; get; }
        /// <summary>W轴速度</summary>
        public double W { set; get; }
        #endregion

        #region Other
        /// <summary>返回速度拼接</summary>
        /// <returns>速度拼接</returns>
        public string VelToString()
        {
            return $"{X},{Y},{Z},{U},{V},{W}";
        }
        #endregion
    }
}