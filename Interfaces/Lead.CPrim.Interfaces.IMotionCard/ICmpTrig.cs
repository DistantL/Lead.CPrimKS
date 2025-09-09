namespace Lead.CPrim.Interfaces.IMotionCard
{
    public interface ICmpTrig
    {
        #region Trigger
        /// <summary>
        /// 触发模式等于、小于、大于时触发
        /// </summary>
        /// <param name="trigCh"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        int AddTrigPoint(int trigCh, int value);

        /// <summary>
        /// 获取触发数量
        /// </summary>
        /// <param name="trigCh"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        int GetTriggerCount(int trigCh, ref int count);

        /// <summary>
        /// 复位触发通道
        /// </summary>
        /// <param name="trigCh">触发通道</param>
        /// <returns></returns>
        int ResetTriggerCount(int trigCh);

        /// <summary>
        /// 线性触发表压点
        /// </summary>
        /// <param name="trigCh">触发通道</param>
        /// <param name="trigStart">开始位置</param>
        /// <param name="freq">间隔</param>
        /// <param name="count">总数量</param>
        /// <returns></returns>
        int SetLinearCompareTrig(int trigCh, int trigStart, int freq, int count);

        /// <summary>
        /// 手动触发
        /// </summary>
        /// <param name="trigCh">触发通道</param>
        /// <param name="pulseWidth">脉冲宽度</param>
        /// <returns></returns>
        int SetManualTrig(int trigCh, int pulseWidth = 200);

        /// <summary>
        /// 设置触发通道行进方向<br/>
        /// 0-负方向，1-正方向，2-无方向
        /// </summary>
        /// <param name="trigCh">触发通道</param>
        /// <param name="dir">行进方向（0-负方向，1-正方向，2-无方向）</param>
        /// <returns></returns>
        int SetTrigDir(int trigCh, int dir);

        /// <summary>
        /// 设置触发通道触发模式
        /// </summary>
        /// <param name="channel">触发通道</param>
        /// <param name="mode">触发模式</param>
        /// <returns></returns>
        int SetTriggerChannelMode(int channel, int mode);

        /// <summary>
        /// 设置触发参数<br/>
        /// 轴id、位置源、电平方向、脉冲宽度
        /// </summary>
        /// <param name="trigChannel"></param>
        /// <param name="axisId"></param>
        /// <param name="trigSource"></param>
        /// <param name="trigLogic"></param>
        /// <param name="widthTime"></param>
        /// <returns></returns>
        int SetTriggerConfig(int trigChannel, int axisId, int trigSource, int trigLogic, double widthTime);

        int SetTriggerTable(int tCmpCh, double[] arry, int arrSize);

        int SetTrigOutputLogic(int trigCh, int logic);

        /// <summary>
        /// 设置触发输出口输出脉宽
        /// </summary>
        /// <param name="trigCh">触发通道</param>
        /// <param name="widthTime">脉冲宽度</param>
        /// <returns></returns>
        int SetTrigOutputPulseWidth(int trigCh, double widthTime);
        #endregion Trigger
    }
}