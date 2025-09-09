using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Newtonsoft.Json;

namespace Lead.CPrim.PrimPCIEM60_E
{

    public class EBusConfig
    {
        public ConcurrentDictionary<int, EAxis> Axises { get; set; }

        public ConcurrentDictionary<int, EAiModule> AiModules { get; set; }

        public ConcurrentDictionary<int, EAoModule> AoModules { get; set; }

        public ConcurrentDictionary<int, ConcurrentDictionary<int, uint>> DiModules { get; set; }

        public ConcurrentDictionary<int, ConcurrentDictionary<int, uint>> DoModules { get; set; }

        public int TotalAxisNum { get; set; }

        public int TotalSlaveNum { get; set; }

        public int TotalDiModuleNum{ get; set; }

        public int TotalDoModuleNum { get; set; }

        public int TotalAiModuleNum { get; set; }

        public int TotalAoModuleNum { get; set; }

        public int TotalIoNum { get; set; }
    }

    public enum AxisTyoe
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
        Other = 100
    }

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

        public EAiModule(int slavoNo, int id)
        {
            SlaveNo = slavoNo;
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

        public int Id { get; set; }

        public int Num { get; set; }

        public int SlaveNo { get; set; }

        public string TypeName { get; set; }

        [JsonIgnore]
        public double[] Value { get; set; }
    }

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

        public int Id { get; set; }

        public int Num { get; set; }

        public int SlaveNo { get; set; }

        public string TypeName { get; set; }

        [JsonIgnore]
        public double[] Value { get; set; }
    }

    public class EDiModule
    {
        public EDiModule(ushort id, ushort num, uint value)
        {
            Id = id;
            Num = num;
            Value = value;
        }

        public EDiModule(ushort id)
        {
            Id = id;
        }

        public EDiModule()
        {
            Id = 0;
            Num = 16;
            Value = 0;
        }

        public ushort Id { get; set; }

        public ushort Num { get; set; }

        public uint Value { get; set; }
    }

    public class EDoModule
    {
        public EDoModule(ushort id, ushort num, uint value)
        {
            Id = id;
            Num = num;
            Value = value;
        }

        public EDoModule(ushort id)
        {
            Id = id;
        }

        public EDoModule()
        {
            Id = 0;
            Num = 16;
            Value = 0;
        }

        public ushort Id { get; set; }

        public ushort Num { get; set; }

        public uint Value { get; set; }
    }

    public class EAxis
    {
        public EAxis()
        {
            Id = 0;
            Type = AxisTyoe.Other;
            DefaultParam = new DefaultParameter();
            HomeParam = new HomeParameter();
            JogParam = new JogParameter();
            MotionIoStatus = -1;
            CmdPos = -1;
            ActualPos = -1;
            CmdVel = -1;
            ActualVel = -1;
            TargetPos = -1;
            ErrorPos = -1;
        }
        public EAxis(short id)
        {
            Id = id;
            Type = AxisTyoe.Other;
            DefaultParam = new DefaultParameter();
            HomeParam = new HomeParameter();
            JogParam = new JogParameter();
            MotionIoStatus = -1;
            CmdPos = -1;
            ActualPos = -1;
            CmdVel = -1;
            ActualVel = -1;
            TargetPos = -1;
            ErrorPos = -1;
        }
        [JsonIgnore]
        public double ActualPos { get; set; }
        [JsonIgnore]
        public double ActualVel { get; set; }
        [JsonIgnore]
        public double CmdPos { get; set; }
        [JsonIgnore]
        public double CmdVel { get; set; }
        public DefaultParameter DefaultParam { get; set; }
        [JsonIgnore]
        public double ErrorPos { get; set; }
        public HomeParameter HomeParam { get; set; }
        public short Id { get; set; }
        public JogParameter JogParam { get; set; }
        [JsonIgnore]
        public int MotionIoStatus { get; set; }
        [JsonIgnore]
        public double TargetPos { get; set; }
        public AxisTyoe Type { get; set; }
        public bool SInpEnable { set; get; } = true;
        public uint SInpError { set; get; } = 10;
        public uint SInpTimes { set; get; } = 5;
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

        public double Acc { get; set; }
        public double Dec { get; set; }
        public double Curve { get; set; }
        public double Equiv { get; set; }
        public double Ve { get; set; }
        public double Vm { get; set; }
        public double Vs { get; set; }
    }

    public class HomeParameter
    {
        public HomeParameter()
        {
            Mode = 0;
            Acc = 10000;
            Vs = 0;
            Ve = 1000;
            Offset = 0;
        }
        public uint Acc { get; set; }
        public short Mode { get; set; }
        public int Offset { get; set; }
        public uint Ve { get; set; }
        public uint Vs { get; set; }
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
        public double Acc { get; set; }
        public double Dec { get; set; }
        public int Delay { get; set; }
        public int Mode { get; set; }
        public double Offset { get; set; }
        public double Sf { get; set; }
        public double Vm { get; set; }
    }
}
