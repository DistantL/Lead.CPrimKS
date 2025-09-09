namespace Lead.CPrim.Interfaces.Dev
{
    public interface IRobotDenso
    {
        /// <summary>
        ///     机械手外部速度
        /// </summary>
        /// <returns></returns>
        int ExtSpeed { get; set; }

        /// <summary>
        ///     机种编号
        /// </summary>
        /// <returns></returns>
        int ProductType { get; set; }

        float ValF10 { get; set; }
        float ValF11 { get; set; }
        float ValF12 { get; set; }
        float ValF13 { get; set; }
        float ValF14 { get; set; }
        float ValF15 { get; set; }
        float ValF16 { get; set; }
        float ValF17 { get; set; }
        float ValF18 { get; set; }
        int ValI10 { get; set; }
        int ValI11 { get; set; }
        int ValI12 { get; set; }
        int ValI13 { get; set; }
        int ValI14 { get; set; }
        int ValI15 { get; set; }
        int ValI16 { get; set; }
        int ValI17 { get; set; }
        int ValI18 { get; set; }

        void AddVariable(string varName);

        /// <summary>
        ///     报警清除
        /// </summary>
        void ClrErr();

        /// <summary>
        ///     动作命令
        /// </summary>
        /// <param name="Cmd"></param>
        /// <param name="sub"></param>
        void CmdAction(int Cmd, int sub = 0);

        /// <summary>
        ///     完成命令返回值
        /// </summary>
        /// <returns></returns>
        int CmdDone();

        /// <summary>
        ///     机械手当前坐标值
        /// </summary>
        /// <returns></returns>
        RobotPoint GetCurPos();

        /// <summary>
        ///     获取机械手所在区域
        /// </summary>
        /// <returns></returns>
        int GetRobotArea();

        object GetVariable(string varName);

        /// <summary>
        ///     判定特权任务是否运行
        /// </summary>
        /// <returns></returns>
        bool IsRuning();

        /// <summary>
        ///     程序复位
        /// </summary>
        void Reset();

        /// <summary>
        ///     相机标定
        /// </summary>
        /// <param name="pos"></param>
        void SetCalOffset(RobotPoint pos, int CamId);

        /// <summary>
        ///     偏差值
        /// </summary>
        /// <returns></returns>
        void SetOffset(RobotPoint pos);

        void SetVariable(string varName, object val);

        /// <summary>
        ///     暂停
        /// </summary>
        void TaskPause(int mode = 1);

        /// <summary>
        ///     cmd=0 单循环，cmd=1 死循环
        /// </summary>
        /// <param name="cmd"></param>
        void TaskStart(int cmd = 1);

        /// <summary>
        ///     等于1启动所有特权任务
        /// </summary>
        /// <param name="mode"></param>
        void TsrStart(int mode = 1);
    }

    public class RobotPoint
    {
        public RobotPoint(double x, double y, double z, double rx, double ry, double rz)
        {
            X = x;
            Y = y;
            Z = z;
            RX = rx;
            RY = ry;
            RZ = rz;
        }

        public RobotPoint(double x, double y, double rz)
        {
            X = x;
            Y = y;
            RZ = rz;
        }

        public double RX { set; get; }
        public double RY { set; get; }
        public double RZ { set; get; }
        public double X { set; get; }
        public double Y { set; get; }
        public double Z { set; get; }
    }
}