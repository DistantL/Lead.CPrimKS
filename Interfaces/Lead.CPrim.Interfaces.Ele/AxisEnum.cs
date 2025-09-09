namespace Lead.CPrim.Interfaces.Ele
{
    /// <summary>速度模式/时间模式</summary>
    public enum AccDecType
    {
        /// <summary>速度模式</summary>
        Velocity = 1,
        /// <summary>时间模式</summary>
        Time = 2,
        /// <summary>Other</summary>
        Other = 100
    }

    /// <summary>驱动类型（伺服/步进）</summary>
    public enum AxisType
    {
        /// <summary>伺服</summary>
        Servo = 1,
        /// <summary>步进</summary>
        Step = 2,
        /// <summary>Other</summary>
        Other = 100
    }

    /// <summary>控制类型（控制卡/机械手/PLC）</summary>
    public enum ByType
    {
        /// <summary>控制卡</summary>
        MotionCard = 1,
        /// <summary>机械手</summary>
        Robot = 2,
        /// <summary>PLC</summary>
        PLC = 3,
        /// <summary>Other</summary>
        Other = 100
    }

    /// <summary>控制模式（开环模式/闭环模式）</summary>
    public enum ControlType
    {
        /// <summary>开环模式</summary>
        OpendLoop = 1,
        /// <summary>闭环模式</summary>
        ClosedLoop = 2,
        /// <summary>Other</summary>
        Other = 100
    }

    /// <summary>反馈类型（增量式/绝对式）</summary>
    public enum FeedBackType
    {
        /// <summary>增量式</summary>
        Incremental = 1,
        /// <summary>绝对式</summary>
        Absolute = 2,
        /// <summary>Other</summary>
        Other = 100
    }
}