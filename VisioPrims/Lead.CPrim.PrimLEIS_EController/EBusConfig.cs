using System.Collections.Concurrent;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Windows.Forms;

namespace Lead.CPrim.PrimLESI_EController
{
    /// <summary>轴类型</summary>
    public enum AxisType
    {
        Servo = 1,
        Stepper = 2,
        Enconder = 3,
        IS620N = 11,
        CDHD = 12,
        STF = 13,
        SS = 14,
        HCX3E = 15,
        A6BF = 16,
        D1 = 17,
        Other = 100,
    }


    /// <summary>DI</summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class EDiModule
    {
        /// <summary>Ctor四个参数</summary>
        /// <param name="slaveNo">节点号</param>
        /// <param name="id">输入地址</param>
        /// <param name="num">数量</param>
        /// <param name="value">值</param>
        public EDiModule(ushort slaveNo, ushort id, ushort num, uint value) : this(slaveNo , id)
        {
            Num = num;
            Value = value;
        }
        /// <summary>Ctor有2个参数</summary>
        /// <param name="slaveNo">节点号</param>
        /// <param name="id">输入地址</param>
        public EDiModule(ushort slaveNo, ushort id)
        {
            SlaveNo = slaveNo;
            Id = id;
        }
        /// <summary>Ctor无参</summary>
        public EDiModule()
        {
            SlaveNo = 0;
            Id = 0;
            Num = 8;
            Value = 0;
        }


        /// <summary>IO输入地址</summary>
        public ushort Id { set; get; }
        /// <summary>IO数量</summary>
        public ushort Num { set; get; }
        /// <summary>IO节点号</summary>
        public ushort SlaveNo { set; get; }
        /// <summary>IO值</summary>
        [JsonIgnore]
        public uint Value { set; get; }
        /// <summary>IO端口号</summary>
        [JsonIgnore]
        public ushort PortNo { set; get; }
        /// <summary>IO起始位（所有节点排序）</summary>
        [JsonIgnore]
        public ushort StartBitNum { set; get; }
        /// <summary>IO起始位（当前节点排序）</summary>
        [JsonIgnore]
        public ushort StartNodeBitNum { set; get; }
    }


    /// <summary>DO</summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class EDoModule
    {
        /// <summary>Ctor四个参数</summary>
        /// <param name="slaveNo">节点号</param>
        /// <param name="id">输出地址</param>
        /// <param name="num">数量</param>
        /// <param name="value">值</param>
        public EDoModule(ushort slaveNo, ushort id, ushort num, ushort value) : this(slaveNo, id)
        {
            Num = num;
            Value = value;
        }
        /// <summary>Ctor有2个参数</summary>
        /// <param name="slaveNo">节点号</param>
        /// <param name="id">输出地址</param>
        public EDoModule(ushort slaveNo, ushort id)
        {
            SlaveNo = slaveNo;
            Id = id;
        }
        /// <summary>Ctor无参</summary>
        public EDoModule()
        {
            SlaveNo = 0;
            Id = 0;
            Num = 8;
            Value = 0;
        }


        /// <summary>IO输出地址</summary>
        public ushort Id { set; get; }
        /// <summary>IO数量</summary>
        public ushort Num { set; get; }
        /// <summary>IO节点号</summary>
        public ushort SlaveNo { set; get; }
        /// <summary>IO值</summary>
        [JsonIgnore]
        public uint Value { set; get; }
        /// <summary>IO起始位（所有节点排序）</summary>
        [JsonIgnore]
        public ushort StartBitNum { set; get; }
        /// <summary>IO起始位（当前节点排序）</summary>
        [JsonIgnore]
        public ushort StartNodeBitNum { set; get; }
    }


    /// <summary>AI</summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class EAiModule
    {
        /// <summary>Ctor有4个参数</summary>
        /// <param name="slaveNo">节点号</param>
        /// <param name="id">输入地址</param>
        /// <param name="typeName">类型名称</param>
        /// <param name="num">数量</param>
        /// <param name="value">值</param>
        public EAiModule(int slaveNo, int id, string typeName, int num, double[] value) : this(slaveNo, id)
        {
            TypeName = typeName;
            Num = num;
            Value = value;
        }
        /// <summary>Ctor有2个参数</summary>
        /// <param name="slaveNo">节点号</param>
        /// <param name="id">输入地址</param>
        public EAiModule(int slaveNo, int id)
        {
            SlaveNo = slaveNo;
            Id = id;
        }
        /// <summary>Ctor无参</summary>
        public EAiModule()
        {
            SlaveNo = 0;
            Id = 0;
            TypeName = "";
            Num = 8;
            Value = new double[8];
        } 


        /// <summary>IO输入地址</summary>
        public int Id { set; get; }
        /// <summary>IO数量</summary>
        public int Num { set; get; }
        /// <summary>节点号</summary>
        public int SlaveNo { set; get; }
        /// <summary>类型名称</summary>
        public string TypeName { set; get; }
        /// <summary>值</summary>
        [JsonIgnore]
        public double[] Value { set; get; }
    }


    /// <summary>AO</summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class EAoModule
    {
        /// <summary>Ctor有4个参数</summary>
        /// <param name="slaveNo">节点号</param>
        /// <param name="id">输出地址</param>
        /// <param name="typeName">类型名称</param>
        /// <param name="num">数量</param>
        /// <param name="value">值</param>
        public EAoModule(int slaveNo, int id, string typeName, int num, double[] value) : this(slaveNo, id)
        {
            TypeName = typeName;
            Num = num;
            Value = value;
        }
        /// <summary>Ctor有2个参数</summary>
        /// <param name="slaveNo">节点号</param>
        /// <param name="id">输出地址</param>
        public EAoModule(int slaveNo, int id)
        {
            SlaveNo = slaveNo;
            Id = id;
        }
        /// <summary>Ctor无参</summary>
        public EAoModule()
        {
            SlaveNo = 0;
            Id = 0;
            TypeName = "";
            Num = 8;
            Value = new double[8];
        }


        /// <summary>IO输出地址</summary>
        public int Id { set; get; }
        /// <summary>IO数量</summary>
        public int Num { set; get; }
        /// <summary>节点号</summary>
        public int SlaveNo { set; get; }
        /// <summary>类型名称</summary>
        public string TypeName { set; get; }
        /// <summary>值</summary>
        [JsonIgnore]
        public double[] Value { set; get; }
    }

    [JsonObject(MemberSerialization.OptOut)]


    public class HomeParameter
    {
        public HomeParameter()
        {
            HomeBy = 0;
            Mode = 0;
            Dir = 0;
            Curve = 0.5;
            Acc = 10000.0;
            Vs = 0;
            Vm = 1000.0;
            Shift = 0;
            Vo = 200;
            Eza = false;
            Pos = 0;
            Ez_Dir = 0;
        }

        public double Acc { set; get; }
        public double Curve { set; get; }
        public int Dir { set; get; }
        public int Ez_Dir { set; get; }
        public bool Eza { set; get; }
        public int HomeBy { set; get; }
        public int Mode { set; get; }
        public double Pos { set; get; }
        public double Shift { set; get; }
        public double Vm { set; get; }
        public double Vo { set; get; }
        public double Vs { set; get; }
    }

    public class DefaultParameter
    {
        public DefaultParameter()
        {
            Curve = 0;
            Acc = 10000000.0;
            Dec = 10000000.0;
            Vs = 0;
            Vm = 1000.0;
            Ve = 0;
            Equiv = 1;
        }
        /// <summary>S 段时间，单位：s</summary>
        public double Curve { set; get; }
        
        public double Equiv { set; get; }
        /// <summary>起始速度，单位：unit/s</summary>
        public double Vs { set; get; }
        /// <summary>最大速度，单位：unit/s</summary>
        public double Vm { set; get; }
        /// <summary>加速度，单位：unit/s^2</summary>
        public double Acc { set; get; }
        /// <summary>减速度，单位：unit/s^2</summary>
        public double Dec { set; get; }
        /// <summary>停止速度，单位：unit/s^2</summary>
        public double Ve { set; get; }
    }

    [JsonObject(MemberSerialization.OptOut)]
    public class MiniCmp
    {
        public int SlaveNo { set; get; }
        [JsonIgnore]
        public Control MiniCmpControl { set; get; }
        public MiniCmp()
        {
            SlaveNo = -1;
        }

    }


    /// <summary>轴配置</summary>
    public class EAxis
    {
        #region Ctor
        /// <summary>Ctor无参</summary>
        public EAxis()
        {
            SlaveNo = -1;
            Id = 0;
            Type = EcatAxisType.Other;
            DefaultParam = new DefaultParameter();
            HomeParam = new HomeParameter();
            MotionIoStatus = 0;
            MotionStatus = -1;
            CmdPos = -1;
            ActualPos = -1;
            CmdVel = -1;
            ActualVel = -1;
            TargetPos = -1;
            ErrPos = -1;
        }
        /// <summary>Ctor有2个参数</summary>
        /// <param name="slaveNo">节点号</param>
        /// <param name="id">轴Id</param>
        public EAxis(int slaveNo, ushort id)
        {
            SlaveNo = slaveNo;
            Id = id;
            Type = EcatAxisType.Other;
            DefaultParam = new DefaultParameter();
            HomeParam = new HomeParameter();
            MotionIoStatus = 0;
            MotionStatus = -1;
            CmdPos = -1;
            ActualPos = -1;
            CmdVel = -1;
            ActualVel = -1;
            TargetPos = -1;
            ErrPos = -1;
        }
        /// <summary>Ctor有3个参数</summary>
        /// <param name="slaveNo">节点号</param>
        /// <param name="id">轴Id</param>
        /// <param name="type">轴类型</param>
        public EAxis(int slaveNo, ushort id, EcatAxisType type)
        {
            SlaveNo = slaveNo;
            Id = id;
            Type = type;
            DefaultParam = new DefaultParameter();
            HomeParam = new HomeParameter();
            MotionIoStatus = 0;
            MotionStatus = -1;
            CmdPos = -1;
            ActualPos = -1;
            CmdVel = -1;
            ActualVel = -1;
            TargetPos = -1;
            ErrPos = -1;
        }
        #endregion


        /// <summary>从站节点</summary>
        public int SlaveNo { set; get; }
        /// <summary>轴Id</summary>
        public ushort Id { set; get; }
        /// <summary>轴使能</summary>
        [JsonIgnore]
        public bool ServoOn { set; get; }
        /// <summary>轴类型</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public EcatAxisType Type { set; get; }
        /// <summary>默认参数</summary>
        public DefaultParameter DefaultParam { set; get; }
        /// <summary>当前指令位置</summary>
        [JsonIgnore]
        public double CmdPos { set; get; }
        /// <summary>当前编码器位置</summary>
        [JsonIgnore]
        public double ActualPos { set; get; }
        /// <summary>当前指令速度</summary>
        [JsonIgnore]
        public double CmdVel { set; get; }
        /// <summary>当前编码器速度</summary>
        [JsonIgnore]
        public double ActualVel { set; get; }
        /// <summary>当前目标位置</summary>
        [JsonIgnore]
        public double TargetPos { set; get; }
        /// <summary>指定轴有关运动信号的状态</summary>
        [JsonIgnore]
        public uint MotionIoStatus { set; get; }



        [JsonIgnore]
        public double ErrPos { set; get; }
        public HomeParameter HomeParam { set; get; }
        public bool SInpEnable { set; get; } = true;
        public double SInpError { set; get; } = 10.0;
        public double SInpTimes { set; get; } = 0.0005;
        
        [JsonIgnore]
        public int MotionStatus { set; get; }
        [JsonIgnore]
        public bool CheckDone { set; get; }
        [JsonIgnore]
        public bool Inp { set; get; }
    }


    /// <summary>EBusConfig管理器</summary>
    public class EBusConfig
    {
        /// <summary>轴数</summary>
        public int TotalAxisNum { set; get; }
        /// <summary>从站数量</summary>
        public int TotalSlaveNum { get; set; }
        /// <summary>配置表集合</summary>
        public List<EcatNode> Nodes { set; get; }
        /// <summary>轴配置集合</summary>
        public ConcurrentDictionary<int, EAxis> Axises { set; get; }


        /// <summary>
        /// Ctor无参
        /// </summary>
        public EBusConfig()
        {
            TotalSlaveNum = 0;
            TotalAxisNum = 0;
            Nodes = new List<EcatNode>();
            Axises = new ConcurrentDictionary<int, EAxis>();
        }
    }
}