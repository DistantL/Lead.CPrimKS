using System.Collections.Concurrent;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Windows.Forms;

namespace Lead.CPrim.PrimADLink_E
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

        public double Acc { set; get; }
        public double Curve { set; get; }
        public double Dec { set; get; }
        public double Equiv { set; get; }
        public double Ve { set; get; }
        public double Vm { set; get; }
        public double Vs { set; get; }
    }

    [JsonObject(MemberSerialization.OptOut)]
    public class EAiModule
    {
        public EAiModule(int slaveNo, int id, string typeName, int num, double[] value)
        {
            SlaveNo = slaveNo;
            Id = id;
            TypeName = typeName;
            Num = num;
            Value = value;
        }

        public EAiModule(int slaveNo, int id)
        {
            SlaveNo = slaveNo;
            Id = id;
        }

        public EAiModule()
        {
            SlaveNo = 0;
            Id = 0;
            TypeName = "";
            Num = 8;
            Value = new double[8];
        }

        public int Id { set; get; }
        public int Num { set; get; }
        public int SlaveNo { set; get; }
        public string TypeName { set; get; }

        [JsonIgnore]
        public double[] Value { set; get; }
    }

    [JsonObject(MemberSerialization.OptOut)]
    public class EAoModule
    {
        public EAoModule(int slaveNo, int id, string typeName, int num, double[] value)
        {
            SlaveNo = slaveNo;
            Id = id;
            TypeName = typeName;
            Num = num;
            Value = value;
        }

        public EAoModule(int slaveNo, int id)
        {
            SlaveNo = slaveNo;
            Id = id;
        }

        public EAoModule()
        {
            SlaveNo = 0;
            Id = 0;
            TypeName = "";
            Num = 8;
            Value = new double[8];
        }

        public int Id { set; get; }
        public int Num { set; get; }
        public int SlaveNo { set; get; }
        public string TypeName { set; get; }

        [JsonIgnore]
        public double[] Value { set; get; }
    }

    [JsonObject(MemberSerialization.OptOut)]
    public class EAxis
    {
        public EAxis()
        {
            SlaveNo = -1;
            Id = -1;
            Type = AxisType.Other;
            DefaultParam = new DefaultParameter();
            HomeParam = new HomeParameter();
            JogParam = new JogParameter();
            MotionIoStatus = -1;
            MotionStatus = -1;
            CmdPos = -1;
            ActualPos = -1;
            CmdVel = -1;
            ActualVel = -1;
            TargetPos = -1;
            ErrPos = -1;
        }

        public EAxis(int slaveNo, int id)
        {
            SlaveNo = slaveNo;
            Id = id;
            Type = AxisType.Other;
            DefaultParam = new DefaultParameter();
            HomeParam = new HomeParameter();
            JogParam = new JogParameter();
            MotionIoStatus = -1;
            MotionStatus = -1;
            CmdPos = -1;
            ActualPos = -1;
            CmdVel = -1;
            ActualVel = -1;
            TargetPos = -1;
            ErrPos = -1;
        }

        [JsonIgnore]
        public double ActualPos { set; get; }

        [JsonIgnore]
        public double ActualVel { set; get; }

        [JsonIgnore]
        public double CmdPos { set; get; }

        [JsonIgnore]
        public double CmdVel { set; get; }

        public DefaultParameter DefaultParam { set; get; }

        [JsonIgnore]
        public double ErrPos { set; get; }

        public HomeParameter HomeParam { set; get; }
        public int Id { set; get; }
        public JogParameter JogParam { set; get; }

        [JsonIgnore]
        public int MotionIoStatus { set; get; }

        [JsonIgnore]
        public int MotionStatus { set; get; }

        public int SlaveNo { set; get; }

        [JsonIgnore]
        public double TargetPos { set; get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public AxisType Type { set; get; }
    }

    public class EBusConfig
    {
        public EBusConfig()
        {
            StartAxisId = -1;
            TotalSlaveNum = -1;
            TotalAxisNum = -1;
            TotalDiModuleNum = -1;
            TotalDoModuleNum = -1;
            TotalAiModuleNum = -1;
            TotalAoModuleNum = -1;
            Axises = new ConcurrentDictionary<int, EAxis>();
            DiModules = new ConcurrentDictionary<int, EDiModule>();
            DoModules = new ConcurrentDictionary<int, EDoModule>();
            AiModules = new ConcurrentDictionary<int, EAiModule>();
            AoModules = new ConcurrentDictionary<int, EAoModule>();
            MiniCmpModules = new MiniCmp[4];
            for (var i = 0; i < MiniCmpModules.Length; i++)
            {
                MiniCmpModules[i] = new MiniCmp();
            }
        }

        public ConcurrentDictionary<int, EAiModule> AiModules { set; get; }
        public ConcurrentDictionary<int, EAoModule> AoModules { set; get; }
        public ConcurrentDictionary<int, EAxis> Axises { set; get; }
        public ConcurrentDictionary<int, EDiModule> DiModules { set; get; }
        public ConcurrentDictionary<int, EDoModule> DoModules { set; get; }
        public int StartAxisId { get; set; }
        public int TotalAiModuleNum { set; get; }
        public int TotalAoModuleNum { set; get; }
        public int TotalAxisNum { set; get; }
        public int TotalDiModuleNum { set; get; }
        public int TotalDoModuleNum { set; get; }
        public int TotalSlaveNum { get; set; }
        public MiniCmp[] MiniCmpModules { get; set; }
    }

    [JsonObject(MemberSerialization.OptOut)]
    public class EDiModule
    {
        public EDiModule(int slaveNo, int id, string typeName, int num, uint value)
        {
            SlaveNo = slaveNo;
            Id = id;
            TypeName = typeName;
            Num = num;
            Value = value;
        }

        public EDiModule(int slaveNo, int id)
        {
            SlaveNo = slaveNo;
            Id = id;
        }

        public EDiModule()
        {
            SlaveNo = 0;
            Id = 0;
            TypeName = "";
            Num = 8;
            Value = 0;
        }

        public int Id { set; get; }
        public int Num { set; get; }
        public int SlaveNo { set; get; }
        public string TypeName { set; get; }

        [JsonIgnore]
        public uint Value { set; get; }
    }

    [JsonObject(MemberSerialization.OptOut)]
    public class EDoModule
    {
        public EDoModule(int slaveNo, int id, string typeName, int num, uint value)
        {
            SlaveNo = slaveNo;
            Id = id;
            TypeName = typeName;
            Num = num;
            Value = value;
        }

        public EDoModule(int slaveNo, int id)
        {
            SlaveNo = slaveNo;
            Id = id;
        }

        public EDoModule()
        {
            SlaveNo = 0;
            Id = 0;
            TypeName = "";
            Num = 8;
            Value = 0;
        }

        public int Id { set; get; }
        public int Num { set; get; }
        public int SlaveNo { set; get; }
        public string TypeName { set; get; }

        [JsonIgnore]
        public uint Value { set; get; }
    }

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

    public class JogParameter
    {
        public JogParameter()
        {
            Mode = 0;
            Sf = 0;
            Acc = 2000.0;
            Dec = 2000.0;
            Vm = 1000.0;
            Offset = 1000.0;
            Delay = 500000;
        }

        public double Acc { set; get; }
        public double Dec { set; get; }
        public int Delay { set; get; }
        public int Mode { set; get; }
        public double Offset { set; get; }
        public double Sf { set; get; }
        public double Vm { set; get; }
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
}