namespace Lead.CPrim.Interfaces.IMotionCard
{
    public interface IMotionCard
    {
        /// <summary>接口【IMotionCard】配置文件地址</summary>
        string ConfigFilePath { set; get; }
        /// <summary>接口【IMotionCard】运动控制卡/器ID</summary>
        int DevIndex { set; get; }
        /// <summary>接口【IMotionCard】加载配置文件</summary>
        void LoadConfigFile(string filePath);
    }
}