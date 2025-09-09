using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Lead.CPrim.StationCommon.MainOutput
{
	/// <summary>主界面界面所有数据数据</summary>
	[JsonObject(/*Could not decode attribute arguments.*/)]
	public class TabDisplayConfig
	{
		#region Field
		/// <summary>主界面界面</summary>
		private Control _configUi;
		/// <summary>主界面已选择</summary>
		private bool _isSelected;
		#endregion


		#region Prop
		/// <summary>主界面界面</summary>
		[JsonIgnore]
		public Control ConfigUi => _configUi;
		/// <summary>主界面已选择</summary>
		[JsonIgnore]
		public bool IsSelected
		{
			get
			{
				return _isSelected;
			}
			set
			{
				if (value != _isSelected)
				{
					_isSelected = value;
					_configUi.BackColor = (value ? Color.Green : Color.LightGray);
					if (value)
					{
						this.OnEventSelected?.Invoke(this);
					}
				}
			}
		}
		/// <summary>主界面界面名称</summary>
		public string Name { get; set; }
		/// <summary>主界面界面序号</summary>
		public int TabIndex { get; set; }
		/// <summary>主界面界面使能</summary>
		public bool Enable { get; set; }
		/// <summary>主界面界面行数</summary>
		public int RowCount { get; set; }
		/// <summary>主界面界面列数</summary>
		public int ColCount { get; set; }
		/// <summary>主界面界面集合</summary>
		public List<PrimOutputConfig> Prims { get; set; }
		#endregion


		#region Define_Event
		/// <summary>主界面选择事件</summary>
		public event UiSelected OnEventSelected; 
		#endregion


		#region Ctor
		/// <summary>
		/// Ctor无参
		/// </summary>
		public TabDisplayConfig()
		{
			Name = "";
			Enable = false;
			TabIndex = 0;
			RowCount = 0;
			ColCount = 0;
			Prims = new List<PrimOutputConfig>();
			_configUi = new SingleDisplayConfigUi(this)
			{
				Dock = DockStyle.Top
			};
		}
		/// <summary>
		/// Ctor有一个参数
		/// </summary>
		/// <param name="newName"></param>
		public TabDisplayConfig(string newName)
		{
			Name = newName;
			Enable = false;
			TabIndex = 0;
			RowCount = 0;
			ColCount = 0;
			Prims = new List<PrimOutputConfig>();
			_configUi = new SingleDisplayConfigUi(this)
			{
				Dock = DockStyle.Top
			};
		} 
		#endregion


		#region Other
		/// <summary>
		/// 返回主界面信息
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return Name;
		} 
		#endregion
	}
}
