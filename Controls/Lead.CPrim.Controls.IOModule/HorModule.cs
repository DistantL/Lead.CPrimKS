using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lead.CPrim.Controls.IOModule
{
	public class HorModule : UserControl
	{
		private int _count;

		private int _startAddr;

		private string _type;

		public List<HorAIO> AIos = new List<HorAIO>();

		public List<HorDIO> DIos = new List<HorDIO>();

		private IContainer components = null;

		private TableLayoutPanel tableLayout;

		public int Count => _count;

		public int StartAddr => _startAddr;

		public string Type => _type;

		public event Del_AIOControl Event_AIoModuleControlClick;

		public event Del_DIOControl Event_DIoModuleControlClick;

		public HorModule()
		{
			InitializeComponent();
		}

		public HorModule(string type, int count, int startAddr, string moduleType, Dictionary<int, string> dis)
		{
			InitializeComponent();
			InitializeControls(type, count, startAddr, moduleType, dis);
			_type = type;
			_count = count;
			_startAddr = startAddr;
		}

		private void AIoValueChanged(string input, double value)
		{
			this.Event_AIoModuleControlClick?.Invoke(input, value);
		}

		private void DIoClick(string input, bool status)
		{
			this.Event_DIoModuleControlClick?.Invoke(input, status);
		}

		private bool InitializeControls(string type, int count, int startAddr, string typeName, Dictionary<int, string> dis)
		{
			if (count <= 0)
			{
				return false;
			}
			List<float> list = new List<float>();
			List<float> list2 = new List<float>();
			list.Add(140f);
			for (int i = 0; i < count; i++)
			{
				list.Add(85f);
				list2.Add(70f);
			}
			List<float> list3 = new List<float>();
			for (int j = 0; j < count + 1; j++)
			{
				list3.Add(list[j] / list.Sum());
			}
			tableLayout.ColumnStyles.Clear();
			if (tableLayout.Controls.Count > 0)
			{
				tableLayout.Controls.Clear();
				tableLayout.Refresh();
			}
			tableLayout.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
			tableLayout.RowStyles[0].SizeType = SizeType.Percent;
			tableLayout.RowStyles[0].Height = 1f;
			for (int k = 0; k < count + 1; k++)
			{
				tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1f));
			}
			tableLayout.ColumnStyles[0].Width = list3[0];
			HorDesc control = new HorDesc(startAddr, typeName, DockStyle.Fill, type);
			tableLayout.Controls.Add(control, 0, 0);
			for (int l = 0; l < count; l++)
			{
				tableLayout.ColumnStyles[l + 1].Width = list3[l + 1];
				string info = "";
				if (dis.ContainsKey(l))
				{
					info = dis[l];
				}
				double address = (double)startAddr + (double)l * 0.01;
				if (type == "DI" || type == "DO")
				{
					HorDIO horDIO = new HorDIO(type, address, info, DockStyle.Fill);
					horDIO.Event_DIoControl -= DIoClick;
					horDIO.Event_DIoControl += DIoClick;
					Padding padding3 = (horDIO.Padding = (horDIO.Margin = new Padding(0)));
					horDIO.Name = $"{type}{(double)startAddr + (double)l * 0.01}";
					tableLayout.Controls.Add(horDIO, l + 1, 0);
					DIos.Add(horDIO);
				}
				else if (type == "AI" || type == "AO")
				{
					HorAIO horAIO = new HorAIO(type, address, info, DockStyle.Fill);
					horAIO.Event_AIoControl -= AIoValueChanged;
					horAIO.Event_AIoControl += AIoValueChanged;
					Padding padding3 = (horAIO.Padding = (horAIO.Margin = new Padding(0)));
					horAIO.Name = $"{type}{(double)startAddr + (double)l * 0.01}";
					tableLayout.Controls.Add(horAIO, l + 1, 0);
					AIos.Add(horAIO);
				}
			}
			tableLayout.ColumnCount = count + 1;
			tableLayout.Refresh();
			return true;
		}

		public void UpdateAIoValues(double[] value)
		{
			if (_type == "AI" || _type == "AO")
			{
				for (int i = 0; i < AIos.Count; i++)
				{
					AIos[i].UpdateValue((double)_startAddr + (double)i * 0.01, value[i]);
				}
			}
		}

		public void UpdateDIoStatus(uint value, int trueFlag = 1)
		{
			if (!(_type == "DI") && !(_type == "DO"))
			{
				return;
			}
			for (int i = 0; i < DIos.Count; i++)
			{
				if (trueFlag == 1)
				{
					DIos[i].UpdateValue((double)_startAddr + (double)i * 0.01, (value & (1 << i)) != 0);
				}
				else
				{
					DIos[i].UpdateValue((double)_startAddr + (double)i * 0.01, (value & (1 << i)) == 0);
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			tableLayout = new System.Windows.Forms.TableLayoutPanel();
			SuspendLayout();
			tableLayout.BackColor = System.Drawing.Color.Transparent;
			tableLayout.ColumnCount = 1;
			tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayout.Location = new System.Drawing.Point(0, 0);
			tableLayout.Name = "tableLayout";
			tableLayout.RowCount = 1;
			tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tableLayout.Size = new System.Drawing.Size(961, 70);
			tableLayout.TabIndex = 0;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(tableLayout);
			base.Name = "HorDIModule";
			base.Size = new System.Drawing.Size(961, 70);
			ResumeLayout(false);
		}
	}
}
