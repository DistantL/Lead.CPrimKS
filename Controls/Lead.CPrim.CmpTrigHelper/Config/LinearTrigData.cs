using System;
using System.Drawing;
using System.Windows.Forms;
using Lead.CPrim.CmpTrigHelper.CmpTrigUIs;
using Lead.CPrim.Global;
using Newtonsoft.Json;

namespace Lead.CPrim.CmpTrigHelper.ConfigClass
{
    public class LinearTrigData
	{
		private Control _configUi;

		private bool _isSelected;

		private TriggerManager _manager;

		[JsonIgnore]
		public Control ConfigUi => _configUi;

		public Guid Gid { get; set; }

		public int Id { get; set; }

		public double Increment { get; set; }

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
						this.OnEventSelected?.Invoke(this, ConfigType.Traj);
					}
				}
			}
		}

		[JsonIgnore]
		public TriggerManager Manager => _manager;

		public string Name { get; set; }

		public double StartPos { get; set; }

		public int TrigCount { get; set; }

		public event UiSelected OnEventSelected;

		public LinearTrigData(string name, int id, double increment, int trigCount, double startPos, TriggerManager manager)
		{
			Gid = Guid.NewGuid();
			Name = name;
			Id = id;
			Increment = increment;
			TrigCount = trigCount;
			StartPos = startPos;
			_configUi = new LinearTrigConfigControl(this)
			{
				Dock = DockStyle.Top
			};
			_manager = manager;
		}

		public LinearTrigData(TriggerManager manager)
		{
			Gid = Guid.NewGuid();
			Name = "";
			Id = -1;
			Increment = -1.0;
			TrigCount = 0;
			StartPos = 0.0;
			_configUi = new LinearTrigConfigControl(this)
			{
				Dock = DockStyle.Top
			};
			_manager = manager;
		}

		public LinearTrigData()
		{
			Gid = Guid.NewGuid();
			Name = "";
			Id = -1;
			Increment = -1.0;
			TrigCount = 0;
			StartPos = 0.0;
			_configUi = new LinearTrigConfigControl(this)
			{
				Dock = DockStyle.Top
			};
			_manager = TriggerManager.Instance;
		}

		public LinearTrigData(string name, int id, TriggerManager manager)
		{
			Gid = Guid.NewGuid();
			Name = name;
			Id = id;
			Increment = 0.0;
			TrigCount = 0;
			StartPos = 0.0;
			_configUi = new LinearTrigConfigControl(this)
			{
				Dock = DockStyle.Top
			};
			_manager = manager;
		}

		public LinearTrigData(string name, TriggerManager manager)
		{
			Gid = Guid.NewGuid();
			Name = name;
			Id = 0;
			Increment = 0.0;
			TrigCount = 0;
			StartPos = 0.0;
			_configUi = new LinearTrigConfigControl(this)
			{
				Dock = DockStyle.Top
			};
			_manager = manager;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
