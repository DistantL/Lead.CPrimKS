using System;
using System.Collections.Generic;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.StationCommon.DataArea
{
	/// <summary>
	/// 全局变量管理器
	/// </summary>
	public class DataInfo
	{
		#region Define_Event
		/// <summary>全局变量值变化时发生事件</summary>
		public event EventHandler OnChanged;
		#endregion



		#region Field
		/// <summary>值</summary>
		private object _value;
		#endregion



		#region Prop
		/// <summary>名称</summary>
		public string Name { get; set; }
		/// <summary>类型</summary>
		public DataType Type { get; set; }
		/// <summary>掉电保持</summary>
		public bool Save { get; set; }
		/// <summary>发生变化（保存之后/初始化之后/赋值之后）</summary>
		public bool Update { get; set; }
		/// <summary>值</summary>
		public object Value
		{
			get
			{
				return _value;
			}
			set
			{
				if(_value == value)
                {
					return;
                }
				_value = value;
				OnChanged?.Invoke(Name, null);
			}
		}
		/// <summary>类参数</summary>
		public List<Property> Properties { get; set; }
		#endregion
	}
}
