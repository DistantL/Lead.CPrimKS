/******************************************************************************
 * SunnyUI 开源控件库、工具类库、扩展类库、多页面开发框架。
 * CopyRight (C) 2022-2032
 *
 * SunnyUI.dll can be used for free under the GPL-3.0 license.
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 文件名称: UIGlobal.cs
 * 文件说明: 全局参数类
 * 当前版本: V3.1
 * 创建日期: 2020-01-01
 *
 * 2020-01-01: V2.2.0 增加文件说明
 * 
 * <3.3.22.1010><Victor><20221010>
 * 1、命名空间移入Lead.CPrim.ProxyTools
******************************************************************************/

using Lead.CPrim.Global;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>全局参数类</summary>
    public static class UIGlobal
    {
        /// <summary>控件版本</summary>
        public const string UIVersion = "SunnyUI.Net V3.1.3";

        /// <summary>最小高度</summary>
        public const int EditorMinHeight = 20;

        /// <summary>最大高度</summary>
        public const int EditorMaxHeight = 60;

        /// <summary>权限数据库</summary>
        public const string AuthorityDb = "AuorityManager";

        /// <summary>ErrorCode数据库</summary>
        public const string ErrorCodeDb = "ErrorCode";

        /// <summary>全局变量掉电保持数据库</summary>
        public const string GlobalVariableDb = "GlobalVariable";

        /// <summary>软件字体</summary>
        public const string FontName = "微软雅黑";

        /// <summary>
        /// PLC Hive数据库
        /// </summary>
        public const string StateMachinePlcDb = "StateMachinePlcDb";

        /// <summary>
        /// PC Hive数据库
        /// </summary>
        public const string StateMachinePcDb = "StateMachinePcDb";

        /// <summary>软件版本</summary>
        // 保留字段接口；启动配置加载后刷新，避免提前初始化时缓存旧目录的版本。
        public static string Version = AudioSwVersion.Instance.Main_SW_versionName;

        /// <summary>
        /// 自定义文件夹
        /// </summary>
        public static string DefinePath = @"D:\Config\DLL\Reference";
    }
}
