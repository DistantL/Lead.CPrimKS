using Lead.CPrim.CmpTrigHelper.ConfigClass;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.Interfaces.IMotionCard;
using Lead.CPrim.Global;
using Lead.CPrim.MachineHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Lead.CPrim.CmpTrigHelper
{
    public class ComplexInterPolationCfg
	{
		private Control _configUi;

		private bool _isSelected;

		private TriggerManager _manager;

		public Guid Gid { get; set; }

		public int Id { get; set; }

		public string EleName { get; set; }

		public List<ActionConfig> Actions { get; set; }

		public string Name { get; set; }

		public int SpeedRate { get; set; }

		public int TAccDec { get; set; }

		public ushort Crd { get; set; } = 0;


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

		[JsonIgnore]
		public Control ConfigUi => _configUi;

		public event UiSelected OnEventSelected;

		public ComplexInterPolationCfg(string name, int id, string eleName, int speedRate, int tAccDec, TriggerManager manager)
		{
			Actions = new List<ActionConfig>();
			Gid = Guid.NewGuid();
			Name = name;
			Id = id;
			EleName = eleName;
			_manager = manager;
			SpeedRate = ((speedRate == 0) ? 100 : speedRate);
			TAccDec = ((tAccDec == 0) ? 10000 : tAccDec);
			Crd = 0;
			_configUi = new ComplexInterPolationCfgUi(this)
			{
				Dock = DockStyle.Top
			};
		}

		public ComplexInterPolationCfg(string name, int id, TriggerManager manager)
		{
			Gid = Guid.NewGuid();
			Actions = new List<ActionConfig>();
			Name = name;
			Id = id;
			SpeedRate = 100;
			TAccDec = 10000;
			Crd = 0;
			_manager = manager;
			_configUi = new ComplexInterPolationCfgUi(this)
			{
				Dock = DockStyle.Top
			};
		}

		public ComplexInterPolationCfg(TriggerManager manager)
		{
			Gid = Guid.NewGuid();
			Actions = new List<ActionConfig>();
			Name = "";
			Id = -1;
			EleName = "";
			SpeedRate = 100;
			TAccDec = 10000;
			Crd = 0;
			_configUi = new ComplexInterPolationCfgUi(this)
			{
				Dock = DockStyle.Top
			};
			_manager = manager;
		}

		public ComplexInterPolationCfg()
		{
			Actions = new List<ActionConfig>();
			Gid = Guid.NewGuid();
			Name = "";
			Id = -1;
			EleName = "";
			SpeedRate = 100;
			TAccDec = 10000;
			_manager = TriggerManager.Instance;
			_configUi = new ComplexInterPolationCfgUi(this)
			{
				Dock = DockStyle.Top
			};
			Crd = 0;
		}

		public void Move(IEleCartesian ele)
		{
			Move(ele, -1, asyncMode: false, null, null, null);
		}

		public int Move(IEleCartesian ele, int timeoutS, bool asyncMode, ITask task, string productName, string name)
		{
			IInterpolation val = (IInterpolation)PrimsManagerTransfer.GetPrimByName(ele.Axises[0].DevName);
			ushort num = (ushort)ele.AxisNum;
			ushort[] array = new ushort[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = (ushort)ele.Axises[i].Id;
			}
			Actions.Sort();
			val.InterpolationOpen((int)Crd, (int)num, array);
			for (int j = 0; j < Actions.Count; j++)
			{
				ActionConfig actionConfig = Actions[j];
				switch (actionConfig.actionType)
				{
				case ActionType.Move:
				{
					TrajPos val2 = new TrajPos();
					val2.Pos = ele.GetGearRatioArray(actionConfig.Pos);
					val2.TrajVm = (actionConfig.Vm * ele.Axises[0].GearRatio * (double)SpeedRate / 100.0);
					val2.Tacc = actionConfig.Vm / (double)TAccDec;
					val2.Tdec = actionConfig.Vm / (double)TAccDec;
					val.AddInterpolationPoint(Crd, num, array, val2);
					break;
				}
				case ActionType.Delay:
					val.AddInterpolationDelayS(Crd, actionConfig.DelayTime1S_1);
					break;
				case ActionType.IOCtrl:
					val.AddInterpolationDO(Crd, actionConfig.IoAdr, actionConfig.On_Off, actionConfig.DelayTime1S_2);
					break;
				case ActionType.WaitIO:
					val.AddInterpolatioWaitDI(Crd, actionConfig.IoAdr, actionConfig.On_Off, actionConfig.DelayTime1S_2);
					break;
				}
			}
			val.InterpolationStart((int)Crd);
			if (task != null)
			{
				((StationTask)task).JoinIfPause();
				((StationTask)task).AbortIfCancel("插补停止");
			}
			else
			{
				Application.DoEvents();
			}
			if (asyncMode)
			{
				return 0;
			}
			while (true)
			{
				if (task != null)
				{
					if ((int)((StationTask)task).RunningState != 3)
					{
						val.InterpolationPause((int)(short)Crd);
						((StationTask)task).JoinIfPause();
					}
					else
					{
						if (val.GetInterpolationSta((int)(short)Crd) == 1)
						{
							val.InterpolationStart((int)(short)Crd);
						}
						if (val.GetInterpolationSta((int)(short)Crd) == 5)
						{
							((StationTask)task).TaskLog("轴插补异常停止！", (LogLevel)2, true);
							((StationTask)task).AbortIfCancel("轴插补异常停止！");
							break;
						}
					}
				}
				if (val.GetAxisMotionMulticoorStatus((short)Crd) == 1)
				{
					break;
				}
				Thread.Sleep(50);
			}
			return 0;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
