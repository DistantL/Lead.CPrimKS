using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.Interfaces
{
    #region Define_Del
    public delegate int RemoteMsgReceived(string message);

    public delegate int RemoteQueueVariableChanged(string varName, object theLastValue);

    public delegate int RemoteVariableChanged(string varName, object currentValue, object lastValue); 
    #endregion



    /// <summary>信息交换类</summary>
    public class Var
    {
        /// <summary>Ctor有2个参数</summary>
        /// <param name="varName"></param>
        /// <param name="v"></param>
        public Var(string varName, string v)
        {
            Name = varName;
            Value = v;
        }

        /// <summary>名称</summary>
        public string Name { set; get; }
        /// <summary>值</summary>
        public string Value { set; get; }
    }



    /// <summary>信息交换类型</summary>
    public enum VarManagerType
    {
        /// <summary>服务器</summary>
        Server = 1,
        /// <summary>客户端</summary>
        Client = 2,
    }



    [JsonObject(MemberSerialization.OptOut)]
    public class RemoteVar
    {
        #region Prop
        /// <summary>名称</summary>
        public string Name { set; get; }
        [JsonConverter(typeof(StringEnumConverter))]
        /// <summary>数据类型</summary>
        public DataType DataType { set; get; }
        /// <summary>远程权限</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public DataPermission Permission { set; get; }
        /// <summary>读取模式</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public DataReadMode ReadMode { set; get; }
        /// <summary>事件通知</summary>
        public bool IsEventNotify { set; get; }
        /// <summary>当前值</summary>
        [JsonIgnore] public object CurrentValue { set; get; }
        /// <summary>上一次值</summary>
        [JsonIgnore] public object LastValue { set; get; }

        [JsonIgnore] public int CurrentCount { set; get; }

        [JsonIgnore] public int LastCount { set; get; }
        /// <summary>值变化标志</summary>
        [JsonIgnore] public bool IsChanged { set; get; }
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public RemoteVar()
        {
            Name = "";
            Permission = DataPermission.RW;
            ReadMode = DataReadMode.NonCycle;
            DataType = DataType.BOOL;
            IsEventNotify = false;
            IsChanged = false;
            CurrentValue = null;
            LastValue = null;
            CurrentCount = 0;
            LastCount = 0;
        }
        /// <summary>Ctor有1个参数</summary>
        /// <param name="name"></param>
        public RemoteVar(string name)
        {
            Name = name;
            Permission = DataPermission.RW;
            ReadMode = DataReadMode.NonCycle;
            DataType = DataType.BOOL;
            IsEventNotify = false;
            IsChanged = false;
            CurrentValue = null;
            LastValue = null;
            CurrentCount = 0;
            LastCount = 0;
        }
        #endregion



        #region Others
        public override string ToString()
        {
            return Name;
        } 
        #endregion
    }
}
