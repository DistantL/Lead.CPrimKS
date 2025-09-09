using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;

namespace Lead.CPrim.EleCommon.Forms
{
	public class EleDebugForm : UIPage
	{
		private const int SW_RESTORE = 9;

		private IEle _curEle = null;

		private Dictionary<string, FlowLayoutPanel> dicPnlDebug = new Dictionary<string, FlowLayoutPanel>();

		private bool flag = false;

	
		public IEle CurEle
		{
			get
			{
				return _curEle;
			}
			set
			{
				_curEle = value;
				_curEle.IsSelected = true;
			}
		}

		public EleDebugForm()
		{
			InitializeComponent();
			InitializeUI();
			dicPnlDebug.Clear();
		}

		[DllImport("User32.dll")]
		private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll ")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		private void EleDebugForm_Load(object sender, EventArgs e)
		{
			if (flag || ElesManager.Instance.DicEles == null || ElesManager.Instance.DicEles.Count == 0)
			{
				return;
			}
			foreach (KeyValuePair<string, string> dicEle in ElesManager.Instance.DicEles)
			{
				if (dicEle.Key == null)
				{
					continue;
				}
				TabPage tabPage = new TabPage();
				tabPage.Text = dicEle.Key;
				tabPage.Name = dicEle.Key;
				tabPage.AutoScroll = true;
				tabControlEle.TabPages.Add(tabPage);
				FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
				flowLayoutPanel.Name = tabPage.Name + "Panel";
				flowLayoutPanel.Dock = DockStyle.Fill;
				flowLayoutPanel.AutoScroll = true;
				foreach (IEle item in ElesManager.Instance.ListEle)
				{
					if (item != null && item.EleTypeName.ToLower().Contains(tabPage.Name.ToLower()))
					{
						item.EleDebugUI.Dock = DockStyle.Top;
						flowLayoutPanel.Controls.Add(item.EleDebugUI);
					}
				}
				tabPage.Controls.Add(flowLayoutPanel);
				dicPnlDebug.Add(flowLayoutPanel.Name, flowLayoutPanel);
			}
			flag = true;
		}

		private void flowLayoutPanelEle_Paint(object sender, PaintEventArgs e)
		{
		}

		private void InitializeUI()
		{
			
		}

		private int OnEleSelected_Handle(IEle ele)
		{
			int result = 0;
			foreach (IEle item in ElesManager.Instance.ListEle)
			{
				item.IsSelected = false;
			}
			ele.IsSelected = true;
			_curEle = ele;
			return result;
		}

		private void timer1UiRefresh_Tick(object sender, EventArgs e)
		{
			foreach (IEle item in ElesManager.Instance.ListEle)
			{
				item.IEleUiRefresh();
			}
		}

		private void tStripBtnDel_Click(object sender, EventArgs e)
		{
		}

		private void tStripBtnDel_Click_1(object sender, EventArgs e)
		{
		}

		private void tStripBtnSave_Click(object sender, EventArgs e)
		{
		}

		private void tStripBtnSave_Click_1(object sender, EventArgs e)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(ElesManager.Instance.ElesCofigPath);
			ElesManager.Instance.DataInfoManagerExport();
		}

		public int AddEleDebugUI(IEle ele)
		{
			if (!flag)
			{
				if (ElesManager.Instance.DicEles == null || ElesManager.Instance.DicEles.Count == 0)
				{
					return 0;
				}
				foreach (KeyValuePair<string, string> dicEle in ElesManager.Instance.DicEles)
				{
					if (dicEle.Key == null)
					{
						continue;
					}
					TabPage tabPage = new TabPage();
					tabPage.Text = dicEle.Key;
					tabPage.Name = dicEle.Key;
					tabPage.AutoScroll = true;
					tabControlEle.TabPages.Add(tabPage);
					FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
					flowLayoutPanel.Name = tabPage.Name + "Panel";
					flowLayoutPanel.Dock = DockStyle.Fill;
					flowLayoutPanel.AutoScroll = true;
					foreach (IEle item in ElesManager.Instance.ListEle)
					{
						if (item != null && item.EleTypeName.ToLower().Contains(tabPage.Name.ToLower()))
						{
							item.EleDebugUI.Dock = DockStyle.Top;
							flowLayoutPanel.Controls.Add(item.EleDebugUI);
						}
					}
					tabPage.Controls.Add(flowLayoutPanel);
					dicPnlDebug.Add(flowLayoutPanel.Name, flowLayoutPanel);
				}
				flag = true;
			}
			int result = 0;
			if (string.IsNullOrEmpty(ele.EleTypeName))
			{
				return -1;
			}
			foreach (KeyValuePair<string, FlowLayoutPanel> item2 in dicPnlDebug)
			{
				if (item2.Key.Replace("Panel", string.Empty) == ele.EleTypeName)
				{
					item2.Value.Controls.Add(ele.EleDebugUI);
					return 0;
				}
			}
			return result;
		}


		private IContainer components = null;


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
			components = new Container();
			tabControlEle = new TabControl();
			timer1 = new Timer(components);
			((Control)this).SuspendLayout();
			tabControlEle.Dock = DockStyle.Fill;
			tabControlEle.Location = new Point(0, 0);
			tabControlEle.Margin = new Padding(3, 4, 3, 4);
			tabControlEle.Name = "tabControlEle";
			tabControlEle.SelectedIndex = 0;
			tabControlEle.Size = new Size(1213, 647);
			tabControlEle.TabIndex = 1;
			timer1.Interval = 300;
			timer1.Tick += timer1UiRefresh_Tick;
			((ContainerControl)this).AutoScaleDimensions = new SizeF(9f, 20f);
			((ContainerControl)this).AutoScaleMode = AutoScaleMode.Font;
			((Form)this).ClientSize = new Size(1213, 647);
			((Control)this).Controls.Add(tabControlEle);
			((Control)(object)this).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			((Form)this).Margin = new Padding(3, 4, 3, 4);
			((Control)this).Name = "EleDebugForm";
			((Control)(object)this).Text = "EleDebugForm";
			((Form)this).Load += EleDebugForm_Load;
			((Control)this).ResumeLayout(performLayout: false);
		}

		private TabControl tabControlEle;

		private Timer timer1;
	}
}
