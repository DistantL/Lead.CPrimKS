using Lead.CPrim.CmpTrigHelper.CmpTrigUIs;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.Interfaces.IMotionCard;
using Lead.CPrim.MachineHelper;
using Lead.CPrim.Global;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Lead.CPrim.CmpTrigHelper.ConfigClass
{
    [JsonObject(/*Could not decode attribute arguments.*/)]
	public class InterPolationCfg
	{
		private Control _configUi;

		private bool _isSelected;

		private TriggerManager _manager;

		[JsonIgnore]
		public Control ConfigUi => _configUi;

		public string EleName { get; set; }

		public Guid Gid { get; set; }

		public int Id { get; set; }

		public List<InterPolationPos> InterPolationPoses { get; set; }

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

		public int SpeedRate { get; set; }

		public int TAccDec { get; set; }

		public ushort Crd { get; set; } = 0;


		public event UiSelected OnEventSelected;

		public InterPolationCfg(string name, int id, string eleName, int speedRate, int tAccDec, TriggerManager manager)
		{
			InterPolationPoses = new List<InterPolationPos>();
			Gid = Guid.NewGuid();
			Name = name;
			Id = id;
			EleName = eleName;
			_manager = manager;
			SpeedRate = ((speedRate == 0) ? 100 : speedRate);
			TAccDec = ((tAccDec == 0) ? 10000 : tAccDec);
			Crd = 0;
			_configUi = new InterpolationControl(this)
			{
				Dock = DockStyle.Top
			};
		}

		public InterPolationCfg(string name, int id, TriggerManager manager)
		{
			Gid = Guid.NewGuid();
			InterPolationPoses = new List<InterPolationPos>();
			Name = name;
			Id = id;
			SpeedRate = 100;
			TAccDec = 10000;
			Crd = 0;
			_manager = manager;
			_configUi = new InterpolationControl(this)
			{
				Dock = DockStyle.Top
			};
		}

		public InterPolationCfg(TriggerManager manager)
		{
			Gid = Guid.NewGuid();
			InterPolationPoses = new List<InterPolationPos>();
			Name = "";
			Id = -1;
			EleName = "";
			SpeedRate = 100;
			TAccDec = 10000;
			Crd = 0;
			_configUi = new InterpolationControl(this)
			{
				Dock = DockStyle.Top
			};
			_manager = manager;
		}

		public InterPolationCfg()
		{
			InterPolationPoses = new List<InterPolationPos>();
			Gid = Guid.NewGuid();
			Name = "";
			Id = -1;
			EleName = "";
			SpeedRate = 100;
			TAccDec = 10000;
			_manager = TriggerManager.Instance;
			_configUi = new InterpolationControl(this)
			{
				Dock = DockStyle.Top
			};
			Crd = 0;
		}

		public void Move(IEleCartesian ele)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Expected O, but got Unknown
			IInterpolation val = (IInterpolation)PrimsManagerTransfer.GetPrimByName(((IEle)ele).DevName);
			ushort num = (ushort)ele.AxisNum;
			ushort[] array = new ushort[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = (ushort)ele.Axises[i].Id;
			}
			List<TrajPos> list = new List<TrajPos>();
			foreach (InterPolationPos interPolationPose in InterPolationPoses)
			{
				TrajPos val2 = new TrajPos();
				val2.Pos = ele.PosToArray(interPolationPose.Pos);
				val2.TrajVm = interPolationPose.Vm;
				list.Add(val2);
			}
			val.InterpolationMove((int)Crd, (int)num, array, list);
		}

		public int Move(IEleCartesian ele, int timeoutS, bool asyncMode, ITask task, string productName, string name, Pos[] offsetPoses, bool continueEnable)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Expected O, but got Unknown
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Expected O, but got Unknown
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Expected O, but got Unknown
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a6: Expected O, but got Unknown
			//IL_0266: Unknown result type (might be due to invalid IL or missing references)
			//IL_0273: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02de: Invalid comparison between Unknown and I4
			//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_031b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0377: Unknown result type (might be due to invalid IL or missing references)
			//IL_038c: Unknown result type (might be due to invalid IL or missing references)
			IInterpolation val = (IInterpolation)PrimsManagerTransfer.GetPrimByName(ele.Axises[0].DevName);
			ushort num = (ushort)ele.AxisNum;
			ushort[] array = new ushort[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = (ushort)ele.Axises[i].Id;
			}
			List<TrajPos> list = new List<TrajPos>();
			foreach (InterPolationPos interPolationPose in InterPolationPoses)
			{
				TrajPos val2 = new TrajPos();
				Pos val3 = new Pos("", 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
				if (interPolationPose.offsetType > -1 && offsetPoses != null)
				{
					try
					{
						val3 = offsetPoses[interPolationPose.offsetType];
					}
					catch (Exception ex)
					{
						MessageBox.Show("偏移超出数组长度" + ex.ToString());
					}
				}
				if (val3 != null)
				{
					Pos val4 = new Pos("", interPolationPose.Pos.X + val3.X, interPolationPose.Pos.Y + val3.Y, interPolationPose.Pos.Z + val3.Z, interPolationPose.Pos.U + val3.U, interPolationPose.Pos.V + val3.V, interPolationPose.Pos.W + val3.W);
					val2.Pos = ele.PosToGearRatioArray(val4);
				}
				else
				{
					val2.Pos = ele.PosToGearRatioArray(interPolationPose.Pos);
				}
				val2.TrajVm = interPolationPose.Vm * ele.Axises[0].GearRatio * (double)SpeedRate / 100.0;
				val2.Tacc = interPolationPose.Vm / (double)TAccDec;
				val2.Tdec = interPolationPose.Vm / (double)TAccDec;
				list.Add(val2);
			}
			if (task != null)
			{
				((StationTask)task).JoinIfPause();
				((StationTask)task).AbortIfCancel("插补停止");
			}
			else
			{
				Application.DoEvents();
			}
			val.InterpolationStop((int)Crd, 0);
			val.InterpolationMove((int)Crd, (int)num, array, list);
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
						Thread.Sleep(100);
						if (continueEnable)
						{
							continue;
						}
						((StationTask)task).AbortIfCancel("插补异常停止");
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
			if (!ele.InLocation(InterPolationPoses.Last().Pos))
			{
				return -30;
			}
			return 0;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
