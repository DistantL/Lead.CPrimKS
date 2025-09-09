using Lead.CPrim.FaiHelper.ComplexFais;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;

namespace Lead.CPrim.FaiHelper
{
    /// <summary>产品级_配置管理器</summary>
    [JsonObject()]
    public class ProductFaiConfigs
    {
        #region Prop
        /// <summary>Id</summary>
        public Guid Gid { get; set; }
        /// <summary>名称</summary>
        public string Name { get; set; }
        /// <summary>简单FAI集合</summary>
        public ConcurrentDictionary<Guid, SimpleFaiConfigs> SimpleConfigs { get; set; }
        /// <summary>复杂FAI集合</summary>
        public ConcurrentDictionary<Guid, ComplexFaiConfigs> ComplexConfigs { get; set; }
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public ProductFaiConfigs()
        {
            Gid = Guid.NewGuid();
            Name = "";
            SimpleConfigs = new ConcurrentDictionary<Guid, SimpleFaiConfigs>();
            ComplexConfigs = new ConcurrentDictionary<Guid, ComplexFaiConfigs>();
        }
        /// <summary>Ctor有1个参数</summary>
        /// <param name="name">名称</param>
        public ProductFaiConfigs(string name)
        {
            Gid = Guid.NewGuid();
            Name = name;
            SimpleConfigs = new ConcurrentDictionary<Guid, SimpleFaiConfigs>();
            ComplexConfigs = new ConcurrentDictionary<Guid, ComplexFaiConfigs>();
        }
        #endregion



        #region Others
        /// <summary>Override ToString（返回产品名称）</summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return Name;
        }
        #endregion
    }



    /// <summary>工站级_配置管理器</summary>
    public class StationFaiConfigs
	{
        #region Ctor
        /// <summary>Ctor无参</summary>
        public StationFaiConfigs()
        {
            Products = new ConcurrentDictionary<string, ProductFaiConfigs>();
            CurrentProductName = "";
        }
        #endregion



        #region Prop
        /// <summary>当前产品</summary>
        public string CurrentProductName { get; set; }
        /// <summary>产品集合配置</summary>
        public ConcurrentDictionary<string, ProductFaiConfigs> Products { get; set; }
        #endregion



        #region Others
        /// <summary>Override ToString（返回当前产品）</summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return CurrentProductName;
        } 
        #endregion
    }
}
