using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Lead.CPrim.CmpTrigHelper.CmpTrigUIs;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Newtonsoft.Json;

namespace Lead.CPrim.CmpTrigHelper.ConfigClass
{
    public class TrigTabMangerData
	{
		private Control _configUi;

		private bool _isSelected;

		private TriggerManager _manager;

		[JsonIgnore]
		public Control ConfigUi => _configUi;

		public Guid Gid { get; set; }

		public int Id { get; set; }

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

		public SortedList<int, TrigTabCfg> TrigsList { get; set; }

		public event UiSelected OnEventSelected;

		public TrigTabMangerData(string name, int id, SortedList<int, TrigTabCfg> trigPoints, TriggerManager manager)
		{
			Gid = Guid.NewGuid();
			Name = name;
			Id = id;
			TrigsList = trigPoints;
			_configUi = new TrigTabMangerControl(this)
			{
				Dock = DockStyle.Top
			};
			_manager = manager;
		}

		public TrigTabMangerData(TriggerManager manager)
		{
			Gid = Guid.NewGuid();
			Name = "";
			Id = -1;
			TrigsList = new SortedList<int, TrigTabCfg>();
			_configUi = new TrigTabMangerControl(this)
			{
				Dock = DockStyle.Top
			};
			_manager = manager;
		}

		public TrigTabMangerData()
		{
			Gid = Guid.NewGuid();
			Name = "";
			Id = -1;
			TrigsList = new SortedList<int, TrigTabCfg>();
			_configUi = new TrigTabMangerControl(this)
			{
				Dock = DockStyle.Top
			};
			_manager = TriggerManager.Instance;
		}

		public TrigTabMangerData(string name, int id, TriggerManager manager)
		{
			Gid = Guid.NewGuid();
			Name = name;
			Id = id;
			TrigsList = new SortedList<int, TrigTabCfg>();
			_configUi = new TrigTabMangerControl(this)
			{
				Dock = DockStyle.Top
			};
			_manager = manager;
		}

		public TrigTabMangerData(string name, TriggerManager manager)
		{
			Gid = Guid.NewGuid();
			Name = name;
			Id = 0;
			TrigsList = new SortedList<int, TrigTabCfg>();
			_configUi = new TrigTabMangerControl(this)
			{
				Dock = DockStyle.Top
			};
			_manager = manager;
		}

		public void RefreshTabs(ProductTrigInfo product)
		{
			if (TrigsList == null || product == null)
			{
				return;
			}
			int num = 0;
			int i;
			for (i = 0; i < TrigsList.Count; i++)
			{
				TriggerTableData value = product.TableTrigDatas.ToList().FirstOrDefault((KeyValuePair<Guid, TriggerTableData> p) => p.Value.Name == TrigsList[i].TabName).Value;
				if (value == null)
				{
					TrigsList.RemoveAt(i);
					i--;
					continue;
				}
				TrigsList[i].PointNum = product.TableTrigDatas.ToList().FirstOrDefault((KeyValuePair<Guid, TriggerTableData> p) => p.Value.Name == TrigsList[i].TabName).Value.TrigPoints.Count;
				TrigsList[i].StartIndex = num;
				num = TrigsList[i].PointNum + num;
			}
		}

		public int AddPoints(IPrim prim, int trigChannel)
		{
			return 0;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
