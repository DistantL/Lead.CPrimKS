using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lead.CPrim.Interfaces.Communicate
{
    public delegate int RemoteMsgReceived(string message);

    public delegate int RemoteQueueVariableChanged(string varName, object theLastValue);

    public delegate int RemoteVariableChanged(string varName, object currentValue, object lastValue);

    public interface IVarClient
    {
        event RemoteQueueVariableChanged OnQueueVariableChanged;

        event RemoteMsgReceived OnRemoteMsgReceived;

        event RemoteVariableChanged OnVariableChanged;

        object Dequeue(string varName);

        T DequeueMultiVar<T>(string varName) where T : class;

        int Enqueue(string varName, object value);

        int EnqueueMultiVar<T>(string varName, T value) where T : class;

        object Read(string varName);

        T ReadMultiVar<T>(string varName) where T : class;

        int SendMsg(string msg);

        int Write(string varName, object value);

        int WriteMultiVar<T>(string varName, T value) where T : class;
        int QueueCount(string varName);
        int ClearQueue(string varName);
    }

    public interface IVarServer
    {
        event RemoteQueueVariableChanged OnQueueVariableChanged;

        event RemoteVariableChanged OnVariableChanged;

        int AddVar(string varName, DataType varType = DataType.BOOL, DataPermission varPermission = DataPermission.RW,
            DataReadMode varReadMode = DataReadMode.NonCycle, bool varIsEventNotify = false);

        object Dequeue(string varName);

        int Enqueue(string varName, object value);
        int QueueCount(string varName);
        int ClearQueue(string varName);
        int PushMsg(string msg);

        int PushVar(string varName);

        object Read(string varName);

        int RemoveVar(string varName);

        int SendMsg(string sessionName, string msg);

        int Write(string varName, object value);

        int Write(string varName, string value);
    }

    [JsonObject(MemberSerialization.OptOut)]
    public class RemoteVariable
    {
        [JsonIgnore] public object CurrentValue { set; get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public DataType DataType { set; get; }

        public bool IsEventNotify { set; get; }
        [JsonIgnore] public object LastValue { set; get; }
        public string Name { set; get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public DataPermission Permission { set; get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public DataReadMode ReadMode { set; get; }

        public override string ToString()
        {
            return Name;
        }
    }
}