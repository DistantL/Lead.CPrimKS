using System;
using System.Drawing;
using System.Windows.Forms;
using Lead.CPrim.CmpTrigHelper.ComplexInterpolation;
using Newtonsoft.Json;

namespace Lead.CPrim.CmpTrigHelper
{
	public class ActionConfig : IComparable<ActionConfig>
	{
		[JsonIgnore]
		public ComplexInterPolationCfg CrdManger;

		private bool _isSelected;

		public string Msg { get; set; } = "";


		public Guid Gid { get; set; }

		public bool On_Off { get; set; }

		public int Index { get; set; }

		public double[] Pos { get; set; }

		public double Vm { get; set; } = 30.0;


		public ushort IoAdr { get; set; } = 0;


		public double DelayTime1S_1 { get; set; } = 0.0;


		public double DelayTime1S_2 { get; set; } = 0.0;


		public ActionType actionType { get; set; } = ActionType.Move;


		public string CartesianName { get; set; }

		[JsonIgnore]
		public Control ConfigUi { get; set; }

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
					ConfigUi.BackColor = (value ? Color.Green : Color.LightGray);
					if (!value)
					{
					}
				}
			}
		}

		public ActionConfig()
		{
		}

		public ActionConfig(ActionType actionType, ComplexInterPolationCfg manger)
		{
			Gid = Guid.NewGuid();
			CrdManger = manger;
			this.actionType = actionType;
			switch (actionType)
			{
			case ActionType.Move:
				ConfigUi = new MoveIcon(this);
				break;
			case ActionType.Delay:
				ConfigUi = new DelayCtrl(this);
				break;
			case ActionType.IOCtrl:
				ConfigUi = new IOControl(this);
				break;
			case ActionType.WaitIO:
				ConfigUi = new WaitDICtrl(this);
				break;
			}
		}

		public int CompareTo(ActionConfig other)
		{
			return Index.CompareTo(other.Index);
		}
	}
}
