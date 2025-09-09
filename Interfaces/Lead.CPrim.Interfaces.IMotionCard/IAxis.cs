namespace Lead.CPrim.Interfaces.IMotionCard
{
    /// <summary>轴停止模式</summary>
    public enum StopMode
    {
        /// <summary>立即停止</summary>
        Immediate = 1,
        /// <summary>减速停止</summary>
        Free = 2,
        /// <summary>Other</summary>
        Other = 0
    }

    /// <summary>轴接口【IAxis】(单轴用户接口)</summary>
    public interface IAxis
    {
        #region State
        /// <summary>接口【IAxis】轴_负硬限位信号判断</summary>
        /// <param name="axisIdx">轴号</param>
        /// <returns>bool</returns>
        bool AxisInMel(int axisIdx);

        /// <summary>接口【IAxis】轴_原点信号判断</summary>
        /// <param name="axisIdx">轴号</param>
        /// <returns>bool</returns>
        bool AxisInOrigin(int axisIdx);

        /// <summary>接口【IAxis】轴_正硬限位信号判断</summary>
        /// <param name="axisIdx">轴号</param>
        /// <returns>bool</returns>
        bool AxisInPel(int axisIdx);

        /// <summary>接口【IAxis】轴_负软件限位信号判断</summary>
        /// <param name="axisIdx">轴号</param>
        /// <returns>bool</returns>
        bool AxisInSMel(int axisIdx);

        /// <summary>接口【IAxis】轴_正软限位信号判断</summary>
        /// <param name="axisIdx">轴号</param>
        /// <returns>bool</returns>
        bool AxisInSPel(int axisIdx);

        /// <summary>接口【IAxis】轴_伺服报警信号判断</summary>
        /// <param name="axisIdx">轴号</param>
        /// <returns>bool</returns>
        bool AxisIsAlarm(int axisIdx);
        /// <summary>接口【IAxis】轴_使能状态判断</summary>
        /// <param name="axisIdx">轴号</param>
        /// <returns>bool</returns>
        bool AxisIsEnble(int axisIdx);

        /// <summary>接口【IAxis】轴_停止状态判断</summary>
        /// <param name="axisIdx">轴号</param>
        /// <returns>true：停止中；false：运动中</returns>
        bool AxisIsStop(int axisIdx);

        /// <summary>接口【IAxis】轴_报警清除</summary>
        /// <param name="axisIdx">轴号</param>
        /// <returns>int</returns>
        int AxisResetAlarm(int axisIdx);

        /// <summary>接口【IAxis】轴_减速停止信号判断</summary>
        /// <param name="axisIdx">轴号</param>
        /// <returns>bool</returns>
        bool AxisSignalDStp(int axisIdx);

        /// <summary>接口【IAxis】轴_急停信号判断</summary>
        /// <param name="axisIdx">轴号</param>
        /// <returns>bool</returns>
        bool AxisSignalEmg(int axisIdx);
        /// <summary>接口【IAxis】轴_EZ信号判断</summary>
        /// <param name="axisIdx">轴号</param>
        /// <returns>bool</returns>
        bool AxisSignalEz(int axisIdx);

        /// <summary>接口【IAxis】轴_伺服到位信号（INP）判断</summary>
        /// <param name="axisIdx">轴号</param>
        /// <returns>bool</returns>
        bool AxisSignalInp(int axisIdx);
        /// <summary>接口【IAxis】轴_SInp信号判断</summary>
        /// <param name="axisIdx">轴号</param>
        /// <returns>bool</returns>
        bool AxisSignalOp(int axisIdx);

        /// <summary>接口【IAxis】轴_伺服准备信号判断</summary>
        /// <param name="axisIdx">轴号</param>
        /// <returns>bool</returns>
        bool AxisSignalRdy(int axisIdx);
        bool AxisSignalScl(int axisIdx);
        /// <summary>接口【IAxis】轴_停止运动</summary>
        /// <param name="axisIdx">轴Id</param>
        /// <returns>int</returns>
        int AxisStopMove(int axisIdx);
        /// <summary>接口【IAxis】轴编码器速度获取</summary>
        /// <param name="axisIdx">轴号</param>
        /// <param name="velocity">编码器速度</param>
        /// <returns>int</returns>
        int GetAxisActualVelocity(int axisIdx, ref double velocity);

        /// <summary>接口【IAxis】轴指令位置获取</summary>
        /// <param name="axisIdx">轴号</param>
        /// <param name="command">指令位置</param>
        /// <returns>int</returns>
        int GetAxisCommand(int axisIdx, ref double command);

        /// <summary>接口【IAxis】轴指令速度获取</summary>
        /// <param name="axisIdx">轴号</param>
        /// <param name="velocity">指令速度</param>
        /// <returns>int</returns>
        int GetAxisCommandVelocity(int axisIdx, ref double velocity);

        /// <summary>接口【IAxis】轴错误获取（未实现）</summary>
        /// <param name="axisIdx">轴号</param>
        /// <param name="errPos">错误位置</param>
        /// <returns>int</returns>
        int GetAxisErrPosition(int axisIdx, ref double errPos);

        /// <summary>接口【IAxis】轴编码器位置获取
        /// <para>与方法【GetFeedbackPulse】功能相同</para></summary>
        /// <param name="axisIdx">轴号</param>
        /// <param name="pos">编码器值</param>
        /// <returns>int</returns>
        int GetAxisPosition(int axisIdx, ref double pos);

        /// <summary>接口【IAxis】轴目标位置获取</summary>
        /// <param name="axisIdx">轴号</param>
        /// <param name="targetPos">目标位置</param>
        /// <returns>int</returns>
        int GetAxisTargetPosition(int axisIdx, ref double targetPos);

        /// <summary>接口【IAxis】轴编码器位置获取
        /// <para>与方法【GetAxisPosition】功能相同</para></summary>
        /// <param name="axisIdx">轴号</param>
        /// <param name="position">位置</param>
        /// <returns>int</returns>
        int GetFeedbackPulse(int axisIdx, ref double position);

        /// <summary>
        /// 接口【IAxis】设置轴的到位判断阈值（凌臣运动控制卡 与到位信号有关）//25997 2025-03-10
        /// </summary>
        /// <param name="axisIdx">指定轴号，从 1 开始计数</param>
        /// <param name="band">到位位置带设定，单位脉冲</param>
        /// <param name="time">到位稳定时间设定，单位 ms</param>
        /// <returns></returns>
        int SetAxisBand(int axisIdx, uint band, uint time);

        /// <summary>接口【IAxis】轴编码器位置设置为指令位置</summary>
        /// <param name="axisIdx">轴号</param>
        /// <returns>int</returns>
        int SetAxisFeedbackPulseToCommand(int axisIdx);

        /// <summary>接口【IAxis】轴指令位置/编码器位置设置</summary>
        /// <param name="axisIdx">轴号</param>
        /// <param name="position">位置</param>
        /// <returns>int</returns>
        int SetAxisPositionAndFeedbackPulse(int axisIdx, int position);

        /// <summary>接口【IAxis】紧急停止所有轴</summary>
        /// <returns>int</returns>
        int StopAllAxes();
        #endregion



        #region Move
        /// <summary>接口【IAxis】轴绝对移动</summary>
        /// <param name="axisId">轴号</param>
        /// <param name="pos">位置</param>
        /// <param name="maxVel">速度</param>
        /// <returns>int</returns>
        int AxisAbsMove(int axisId, double pos, double maxVel);
        /// <summary>接口【IAxis】轴当前运动速度在线更新（默认使用0.3s变速时间）</summary>
        /// <param name="axisId">轴号</param>
        /// <param name="newVel">速度</param>
        /// <returns>int</returns>
        int AxisChangeVel(int axisId, double newVel);
        /// <summary>接口【IAxis】轴相对运动</summary>
        /// <param name="axisId">轴号</param>
        /// <param name="dis">相对距离</param>
        /// <param name="maxVel">速度*速率</param>
        /// <returns>int</returns>
        int AxisRelMove(int axisId, double dis, double maxVel);
        /// <summary>接口【IAxis】轴设置加速时间</summary>
        /// <param name="axisId">轴号</param>
        /// <param name="acc">加速时间</param>
        /// <returns>int</returns>
        int AxisSetAcc(int axisId, double acc);
        /// <summary>接口【IAxis】轴设置起始速度/最大速度/加速时间/减速时间/停止速度</summary>
        /// <param name="Axis">轴号</param>
        /// <param name="minVel">起始速度</param>
        /// <param name="maxVel">最大速度</param>
        /// <param name="tAcc">加速时间</param>
        /// <param name="tDec">减速时间</param>
        /// <param name="stopVel">停止速度</param>
        /// <returns>int</returns>
        int AxisSetAccDec(int Axis, double minVel, double maxVel, double tAcc, double tDec, double stopVel);
        int AxisSetAccDec(int Axis, double minVel, double maxVel, double tAcc, double tDec, double stopVel, double stTime);
        /// <summary>接口【IAxis】轴设置减速时间</summary>
        /// <param name="axisId">轴Id</param>
        /// <param name="dec">减速时间</param>
        /// <returns>int</returns>
        int AxisSetDec(int axisId, double dec);

        int AxisSetElMode(int axisId, bool pelEnable, bool melEnable, StopMode pelStopMode, StopMode melStopMode);

        int AxisSetEmgMode(int axisId, int mode);
        /// <summary>接口【IAxis】轴使能设置</summary>
        /// <param name="axisId">轴号</param>
        /// <param name="enable">使能</param>
        /// <returns>int</returns>
        int AxisSetEnable(int axisId, bool enable);
        /// <summary>接口【IAxis】轴最大速度设置</summary>
        /// <param name="axisId">轴号</param>
        /// <param name="maxVel">最大速度</param>
        /// <returns>int</returns>
        int AxisSetMaxVel(int axisId, double maxVel);
        /// <summary>接口【IAxis】轴起始速度设置</summary>
        /// <param name="axisId">轴号</param>
        /// <param name="minVel">起始速度</param>
        /// <returns>int</returns>
        int AxisSetMinVel(int axisId, double minVel);

        int AxisSetSoftLimit(int axisId, bool sPelEnable, bool sMelEnable, double sPelValue, double sMelValue);

        /// <summary>
        /// 轴停止减速设置<br/>
        /// 适用于手动停止、急停<br/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pulse">脉冲当量</param>
        /// <returns></returns>
        int AxisSetStopDec(int id, int pulse);

        /// <summary>接口【IAxis】轴停止速度设置</summary>
        /// <param name="axisId">轴号</param>
        /// <param name="stopVel">停止速度</param>
        /// <returns>int</returns>
        int AxisSetStopVel(int axisId, double stopVel);
        /// <summary>接口【IAxis】轴速度模式</summary>
        /// <param name="axisId">轴号</param>
        /// <param name="maxVel">速度</param>
        /// <returns>int</returns>
        int AxisVelMove(int axisId, double maxVel);
        #endregion



        #region Home

        int AxisHomeMove(int axisId);

        int AxisHomeMove(int axisId, bool asyncMode);
        /// <summary>接口【IAxis】轴回原点</summary>
        /// <param name="axisId">轴Id</param>
        /// <param name="homeMode">回原点模式</param>
        /// <param name="vm">回零高速</param>
        /// <param name="vo">回零低速</param>
        /// <param name="acc">回零加减速</param>
        /// <param name="shift">回零偏移</param>
        /// <param name="asyncMode">是否异步</param>
        /// <param name="posSource">posSource（默认为1）</param>
        /// <returns>int</returns>
        int AxisHomeMove(int axisId, int homeMode, double vm, double vo, double acc, double shift, bool asyncMode = false, int posSource = 1);

        int AxisSetHomeMode(int axisId, int homeDir, int velMode, int homeMode, int posSource);

        int AxisSetHomeMode(int axisId, int homeMode, int posSource = 1);
        #endregion
    }
}