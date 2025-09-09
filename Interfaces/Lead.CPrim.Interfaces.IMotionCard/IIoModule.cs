using System.Collections.Generic;

namespace Lead.CPrim.Interfaces.IMotionCard
{
    public delegate void DIStateChanged(double addr, bool val, int mode);

    public delegate int DOStateChanged(int idx, bool val);


    /// <summary>IO公共接口</summary>
    public interface IIoModule
    {
        event DIStateChanged OnDIStateChanged;

        event DOStateChanged OnDOStateChanged;

        bool DIChangedEnable { set; get; }
        bool DOChangedEnable { set; get; }
        IOInfos IoInfos { set; get; }
        string IOInfosFilePath { get; set; }
        int ExportIoInfos();



        #region 数字量&&模拟量模块接口
        /// <summary>读取模拟量输入模块所有通道的输入电平</summary>
        /// <param name="startAddr">起始地址</param>
        /// <param name="value">输入端口电平</param>
        /// <returns>错误代码</returns>
        int ReadAiModule(int startAddr, out double[] value);
        /// <summary>写入模拟量输出模块所有通道的输出电平</summary>
        /// <param name="startAddr">起始地址</param>
        /// <param name="value">输出端口电平</param>
        /// <returns>错误代码</returns>
        int ReadAoModule(int startAddr, out double[] value);
        /// <summary>读取总线数字量输入模块所有通道的输入电平</summary>
        /// <param name="startAddr">起始地址</param>
        /// <param name="value">输入端口电平</param>
        /// <returns>错误代码</returns>
        int ReadDiModule(int startAddr, out uint value);
        /// <summary>读取总线数字量输出模块所有通道的输出电平</summary>
        /// <param name="startAddr">起始地址</param>
        /// <param name="value">输出端口电平</param>
        /// <returns>错误代码</returns>
        int ReadDoModule(int startAddr, out uint value);
        /// <summary>读取模拟量模块输入电平</summary>
        /// <param name="address">地址</param>
        /// <param name="val">输入端口电平值</param>
        /// <returns>错误代码</returns>
        int ReadSingleAInput(double address, out double val);
        /// <summary>读取模拟量模块输入电平</summary>
        /// <param name="address">地址</param>
        /// <param name="val">输入端口电平值</param>
        /// <returns>错误代码</returns>
        int ReadSingleAInput(double address, EleAnalogType type, out double val);
        /// <summary>读取模拟量模块输出电平</summary>
        /// <param name="address">地址</param>
        /// <param name="val">输出端口电平值</param>
        /// <returns>错误代码</returns>
        int ReadSingleAOutput(double address, out double val);
        /// <summary>读取数字量模块输入端口电平</summary>
        /// <param name="address">地址</param>
        /// <param name="val">输入端口电平值</param>
        /// <returns>错误代码</returns>
        int ReadSingleDInput(double address, out bool val);
        /// <summary>读取数字量模块输出端口电平</summary>
        /// <param name="address">地址</param>
        /// <param name="val">输出端口电平值</param>
        /// <returns>错误代码</returns>
        int ReadSingleDOutput(double address, out bool val);
        /// <summary>注册数字量输入模块该通道的数值发生变化的事件</summary>
        /// <param name="address">The index.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        int RegisterDIChanged(double address, int mode, int type = 2);
        /// <summary>注册数字量输出模块该通道的数值发生变化的事件</summary>
        /// <param name="address">The index.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        int RegisterDOChanged(double address, int mode);
        /// <summary>Removes the di changed.</summary>
        /// <param name="address">The index.</param>
        /// <returns></returns>
        int RemoveDIChanged(double address);
        /// <summary>Removes the do changed.</summary>
        /// <param name="address">The index.</param>
        /// <returns></returns>
        int RemoveDOChanged(double address);
        /// <summary>写入模拟量模块输出电平</summary>
        /// <param name="address">地址</param>
        /// <param name="val">输出端口电平值</param>
        /// <returns>错误代码</returns>
        int WriteSingleAOutput(double address, double val);
        /// <summary>写入数字量模块输出电平</summary>
        /// <param name="address">地址</param>
        /// <param name="val">输出端口电平值</param>
        /// <returns>错误代码</returns>
        int WriteSingleDOutput(double address, bool val);
        #endregion



        int ClearEventOnDIStateChanged();

        int ClearEventOnDOStateChanged();
    }


    /// <summary>IO属性</summary>
    public class IOInfo
    {
        #region Prop
        /// <summary>IO绑定基元名称</summary>
        public string PrimName { set; get; }
        /// <summary>IO地址</summary>
        public double Address { set; get; }
        /// <summary>IO下降沿</summary>
        public bool EnFallEvent { get; set; } = false;
        /// <summary>IO上升沿</summary>
        public bool EnRiseEvent { get; set; } = false;
        /// <summary>IO信息</summary>
        public string Info { set; get; }
        #endregion

        #region Ctor
        /// <summary>Ctor无参</summary>
        public IOInfo()
        {
            PrimName = "";
            Address = 0.0;
            Info = "";
        }
        /// <summary>Ctor有三个参数</summary>
        /// <param name="primName">IO绑定基元名称</param>
        /// <param name="addr">IO地址</param>
        /// <param name="info">IO信息</param>
        public IOInfo(string primName, double addr, string info)
        {
            PrimName = primName;
            Address = addr;
            Info = info;
        }
        #endregion
    }


    /// <summary>IO管理器</summary>
    public class IOInfos
    {
        public IOInfos()
        {
            Di = new List<IOInfo>();
            Do = new List<IOInfo>();
            Ai = new List<IOInfo>();
            Ao = new List<IOInfo>();
        }
        /// <summary>Ai模块集合</summary>
        public List<IOInfo> Ai { set; get; }
        /// <summary>Ao模块集合</summary>
        public List<IOInfo> Ao { set; get; }
        /// <summary>Di模块集合</summary>
        public List<IOInfo> Di { set; get; }
        /// <summary>Do模块集合</summary>
        public List<IOInfo> Do { set; get; }
    }
}