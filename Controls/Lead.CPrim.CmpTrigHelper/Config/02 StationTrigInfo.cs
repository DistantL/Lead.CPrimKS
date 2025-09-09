using System.Collections.Concurrent;
using Newtonsoft.Json;

namespace Lead.CPrim.Global
{
    [JsonObject(/*Could not decode attribute arguments.*/)]
    public class StationTrigInfo
    {
        #region Prop
        /// <summary>
        /// 当前产品
        /// </summary>
        public string CurrentProductName { get; set; }

        /// <summary>
        /// 所有产品配置信息
        /// </summary>
        public ConcurrentDictionary<string, ProductTrigInfo> Products { get; set; }
        #endregion



        #region Ctor
        public StationTrigInfo()
        {
            Products = new ConcurrentDictionary<string, ProductTrigInfo>();
            CurrentProductName = "";
        }
        #endregion



        #region Method_Override
        public override string ToString()
        {
            return CurrentProductName;
        }
        #endregion
    }
}
