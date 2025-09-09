namespace Lead.CPrim.Interfaces
{
    /// <summary>
    ///     模拟量模块接口
    /// </summary>
    public interface IEleDA
    {
        /// <summary>
        ///     Gets or sets the actual max value.
        /// </summary>
        /// <value>The actual min value.</value>
        /// <remarks>Lead.CPrim</remarks>
        float ActMax { set; get; }

        /// <summary>
        ///     Gets or sets the actual min value.
        /// </summary>
        /// <value>The actual min value.</value>
        /// <remarks>Lead.CPrim</remarks>
        float ActMin { set; get; }

        /// <summary>
        ///     Gets or sets the address.
        /// </summary>
        /// <value></value>
        /// <remarks>Lead.CPrim</remarks>
        string Address { set; get; }

        /// <summary>
        ///     Gets or sets the type of the ele.
        /// </summary>
        /// <value>The type of the ele.</value>
        /// <remarks>Lead.CPrim</remarks>
        EleAnalogType EleType { set; get; }

        /// <summary>
        ///     Gets or sets the feedback max value.
        /// </summary>
        /// <value>The feedback max value.</value>
        /// <remarks>Lead.CPrim</remarks>
        float FeedBackMax { set; get; }

        /// <summary>
        ///     Gets or sets the feedback min value.
        /// </summary>
        /// <value>The feedback min value.</value>
        /// <remarks>Lead.CPrim</remarks>
        float FeedBackMin { set; get; }

        /// <summary>
        ///     Gets or sets the limit max value.
        /// </summary>
        /// <value>The limit max value.</value>
        /// <remarks>Lead.CPrim</remarks>
        float LimitMax { set; get; }

        /// <summary>
        ///     Gets or sets the limit min value.
        /// </summary>
        /// <value>The limit min value.</value>
        /// <remarks>Lead.CPrim</remarks>
        float LimitMin { set; get; }

        /// <summary>
        ///     Gets or sets the act value.
        /// </summary>
        /// <value>The feedback value.</value>
        /// <remarks>Lead.CPrim</remarks>
        float SetValue { set; get; }

        /// <summary>
        ///     Write digital value.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Write(float value);
    }
}