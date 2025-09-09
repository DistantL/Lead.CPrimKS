using System.Windows.Forms;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Lead.CPrim.StationCommon.RtVars
{
    /// <summary>实时变量管理器</summary>
	[JsonObject(/*Could not decode attribute arguments.*/)]
	public class RtDataVar
	{
        #region Prop
        /// <summary>名称</summary>
        public string Name { get; set; }

        /// <summary>UI</summary>
        [JsonIgnore]
        [BsonIgnore]
        public Control ShowControl { get; set; }

        /// <summary>数据类型</summary>
        public DataType Type { get; set; }

        /// <summary>值</summary>
        public string Value { get; set; }

        /// <summary>掉电保持</summary>
        public bool Save { get; set; }
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public RtDataVar()
        {
            Name = "";
            Type = DataType.Other;
            ShowControl = new VarControl(this);
        }
        /// <summary>Ctor有2个参数</summary>
        /// <param name="name">名称</param>
        /// <param name="type">数据类型</param>
        public RtDataVar(string name, DataType type)
        {
            Name = name;
            Type = type;
            ShowControl = new VarControl(this);
        }
        #endregion



        #region Method_ExternalUsing
        public void ClearValue()
        {
            Value = "0";
            ((VarControl)ShowControl).SetVarValue(Value);
            _ = MongodbHelper.UpdateOneAsync<RtDataVar>("Name", Name, "Value", Value, StationManager.Instance.CurrentStation.RtDataVarsCollection, null, false, null);
        }
        #endregion
    }
}
