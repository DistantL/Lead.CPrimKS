using System;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>启动时由软件配置传入，底层模块无需反向引用 SoftwareConfig。</summary>
    public static class RuntimeConfigPaths
    {
        public static string LeadVersionFilePath { get; private set; } = @"D:\Config\IniConfig\Lead.ini";
        public static string TossingStatisticsFilePath { get; private set; } = @"D:\Config\IniConfig\TossingStaticitsInfo.ini";

        public static void Configure(string leadVersionFilePath, string tossingStatisticsFilePath)
        {
            if (string.IsNullOrWhiteSpace(leadVersionFilePath) || string.IsNullOrWhiteSpace(tossingStatisticsFilePath))
                throw new ArgumentException("版本文件和抛料统计文件路径不能为空。");
            LeadVersionFilePath = leadVersionFilePath;
            TossingStatisticsFilePath = tossingStatisticsFilePath;
            UIGlobal.Version = Lead.CPrim.Global.AudioSwVersion.Instance.Main_SW_versionName;
        }
    }
}
