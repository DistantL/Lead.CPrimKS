namespace Lead.CPrim.Interfaces.Dev
{
    public interface ILightSource
    {
        /// <summary>
        ///     控制光源开/关
        /// </summary>
        /// <param name="Channel">光源通道</param>
        /// <param name="On_Off">True:光源开；False:光源关</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Write(int Channel, bool On_Off);
    }
}