using System;
using System.Collections.Concurrent;

namespace Lead.CPrim.StationCommon.MainOutput
{
	/// <summary>主界面管理器</summary>
	public class SingleDisplayConfig
	{
		#region Field
		/// <summary>主界面集合</summary>
		private ConcurrentDictionary<Guid, TabDisplayConfig> _tabPagesDisplayConfig;
		#endregion


		#region Prop
		/// <summary>主界面名称</summary>
		public string Name { get; set; }
		/// <summary>主界面集合</summary>
		public ConcurrentDictionary<Guid, TabDisplayConfig> TabPagesDisplayConfig => _tabPagesDisplayConfig;
		#endregion


		#region Ctor
		public SingleDisplayConfig()
		{
			Name = "";
			_tabPagesDisplayConfig = new ConcurrentDictionary<Guid, TabDisplayConfig>();
		}
		public SingleDisplayConfig(string name)
		{
			Name = name;
			_tabPagesDisplayConfig = new ConcurrentDictionary<Guid, TabDisplayConfig>();
		} 
		#endregion
	}
}
