using System.Collections.Concurrent;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Lead.CPrim.StationCommon.RtVars
{
    /// <summary>实时变量集合管理器</summary>
	[JsonObject(/*Could not decode attribute arguments.*/)]
	public class RtDataVars
	{
        #region Prop
		/// <summary>实时变量集合</summary>
        public ConcurrentDictionary<string, RtDataVar> DataVars { get; set; }
		/// <summary>UI</summary>
        [JsonIgnore]
        public Control VarsDisplayControl { get; set; }
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public RtDataVars()
        {
            DataVars = new ConcurrentDictionary<string, RtDataVar>();
            VarsDisplayControl = new RtVarsControl(this);
        }
        /// <summary>Ctor有1个参数</summary>
        /// <param name="keyName"></param>
        public RtDataVars(string keyName)
        {
            DataVars = new ConcurrentDictionary<string, RtDataVar>();
            VarsDisplayControl = new RtVarsControl(this);
        }
        /// <summary>Ctor有2个参数</summary>
        /// <param name="station"></param>
        /// <param name="keyName"></param>
        public RtDataVars(StationConfig station, string keyName)
        {
            DataVars = new ConcurrentDictionary<string, RtDataVar>();
            VarsDisplayControl = new RtVarsControl(this);
        } 
        #endregion
    }
}
