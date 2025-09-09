using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.Controls.IOModule
{
	public class VerDIModule : UserControl
	{
		public List<VerDI> DIs = new List<VerDI>();

		private IContainer components = null;

		private TableLayoutPanel tableLayout;

		public event Del_DIOControl Event_ModuleInClick;

		public VerDIModule()
		{
			InitializeComponent();
		}

		public VerDIModule(int count, int startAddr, Dictionary<int, string> dis)
		{
			InitializeComponent();
			InitializeControls(count, startAddr, dis);
		}

		private void DiClick(string input, bool status)
		{
			this.Event_ModuleInClick?.Invoke(input, status);
		}

		private bool InitializeControls(int count, int startAddr, Dictionary<int, string> dis)
		{
			if (count <= 0)
			{
				return false;
			}
			base.Width = 245;
			base.Height = 20 * count;
			tableLayout.ColumnStyles.Clear();
			tableLayout.Height = 20 * count;
			tableLayout.Width = 245;
			if (tableLayout.Controls.Count > 0)
			{
				tableLayout.Controls.Clear();
				tableLayout.Refresh();
			}
			tableLayout.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
			tableLayout.RowCount = count;
			tableLayout.ColumnCount = 1;
			for (int i = 0; i < count; i++)
			{
				string info = "";
				if (dis.ContainsKey(i))
				{
					info = dis[i];
				}
				double address = (double)startAddr + (double)i * 0.01;
				VerDI verDI = new VerDI(address, info);
				verDI.Event_InputControl += DiClick;
				DIs.Add(verDI);
				tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 2f));
				tableLayout.RowStyles[i].Height = 1f / (float)count;
			}
			for (int j = 0; j < count; j++)
			{
				VerDI verDI2 = DIs[j];
				Padding padding3 = (verDI2.Padding = (verDI2.Margin = new Padding(0)));
				verDI2.Name = $"IN{(double)startAddr + (double)j * 0.01}";
				verDI2.Dock = DockStyle.Fill;
				tableLayout.Controls.Add(verDI2, 0, j);
			}
			tableLayout.Refresh();
			return true;
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
			tableLayout.ColumnCount = 1;
			tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayout.Location = new System.Drawing.Point(0, 0);
			tableLayout.Name = "tableLayout";
			tableLayout.RowCount = 1;
			tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
			tableLayout.Size = new System.Drawing.Size(245, 262);
			tableLayout.TabIndex = 0;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(tableLayout);
			base.Name = "VerDIModule";
			base.Size = new System.Drawing.Size(245, 262);
			ResumeLayout(false);
		}
	}
}
