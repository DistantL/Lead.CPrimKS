using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.Interfaces.StateMachine;

namespace Lead.CPrim.CmpTrigHelper.ComplexInterpolation
{
	public class AxisTeach : UserControl
	{
		private IEleCartesian _cart;

		private int _index;

		private IEleAxis _axis;

		private ToolStripButton[] _btnJog;

		private IContainer components = null;

		private GroupBox grpAxisTeach;

		private ToolStrip tsMain;

		private ToolStripButton tsBtnEnable;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripButton tsBtnJogDec;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripComboBox tsCmbJogDistance;

		private ToolStripSeparator toolStripSeparator3;

		private ToolStripButton tsBtnJogAdd;

		private ToolStripSeparator toolStripSeparator4;

		private ToolStripLabel tsLabelPel;

		private ToolStripSeparator toolStripSeparator6;

		private ToolStripLabel tsLabelOrg;

		private ToolStripSeparator toolStripSeparator5;

		private ToolStripLabel tsLabelMel;

		private ToolStripSeparator toolStripSeparator7;

		private ToolStripLabel tsLabelAlm;

		private ToolStripSeparator toolStripSeparator8;

		private ToolStripButton tsBtnHome;

		private ToolStripSeparator toolStripSeparator9;

		private ToolStripButton tsBtnClrErr;

		private ToolStripSeparator toolStripSeparator13;

		private ToolStripButton tsBtnStop;

		private ToolStripSeparator toolStripSeparator12;

		private ToolStripLabel tsLabelActPos;

		private ToolStripSeparator toolStripSeparator10;

		private ToolStripSeparator toolStripSeparator11;

		private ToolStripButton tsBtnMovePoint;

		private ToolStripSeparator toolStripSeparator14;

		public AxisTeach()
		{
			InitializeComponent();
		}

		public AxisTeach(IEleCartesian cart, int index)
		{
			InitializeComponent();
			_cart = cart;
			_index = index;
			_axis = _cart.Axises[index];
		}

		private void tsBtnEnable_Click(object sender, EventArgs e)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Invalid comparison between Unknown and I4
			if (_axis.CheckManualEnable())
			{
				if ((int)_axis.DriveType == 2)
				{
					_axis.ServoEnable((ITask)null, _axis.IsServoOn, (EleAlarmLevel)2);
				}
				else
				{
					_axis.ServoEnable((ITask)null, !_axis.IsServoOn, (EleAlarmLevel)2);
				}
			}
		}

		private void tsBtnClrErr_Click(object sender, EventArgs e)
		{
			if (_axis.CheckManualEnable())
			{
				_axis.ResetAlarm();
			}
		}

		private void tsBtnHome_Click(object sender, EventArgs e)
		{
			if (_axis.CheckManualEnable())
			{
				_axis.Home((ITask)null, 50, (EleAlarmLevel)2);
			}
		}

		private void tsBtnStop_Click(object sender, EventArgs e)
		{
			if (_axis.CheckManualEnable())
			{
				_axis.StopMove();
			}
		}

		private void AxisTeach_Load(object sender, EventArgs e)
		{
			_btnJog = new ToolStripButton[2] { tsBtnJogAdd, tsBtnJogDec };
			_btnJog.ToList().ForEach(delegate(ToolStripButton p)
			{
				p.Click += BtnJog_Click;
			});
			tsCmbJogDistance.Items.Clear();
			tsCmbJogDistance.Items.AddRange(new object[12]
			{
				0.02, 0.1, 0.5, 1, 5, 10, 20, 30, 40, 50,
				100, 150
			});
			tsCmbJogDistance.SelectedItem = 10;
			grpAxisTeach.Text = _axis.Name;
			ToolStripButton[] btnJog = _btnJog;
			foreach (ToolStripButton toolStripButton in btnJog)
			{
				toolStripButton.BackColor = Color.White;
				toolStripButton.BackColor = Color.White;
			}
		}

		private void BtnJog_Click(object sender, EventArgs e)
		{
			if (!_axis.CheckManualEnable())
			{
				return;
			}
			ToolStripButton toolStripButton = sender as ToolStripButton;
			try
			{
				if (toolStripButton == null)
				{
					return;
				}
				toolStripButton.Enabled = false;
				Cursor = Cursors.WaitCursor;
				if (double.TryParse(tsCmbJogDistance.SelectedItem.ToString(), out var result))
				{
					if (toolStripButton.Text.Contains("+"))
					{
						_axis.MoveRel((ITask)null, result, _axis.JogVel, (ushort)100, -1, false, true, (EleAlarmLevel)2);
					}
					else if (toolStripButton.Text.Contains("-"))
					{
						_axis.MoveRel((ITask)null, 0.0 - result, _axis.JogVel, (ushort)100, -1, false, true, (EleAlarmLevel)2);
					}
				}
			}
			catch (Exception ex)
			{
				Cursor = Cursors.Default;
				MessageBox.Show("移动错误：" + ex.Message);
			}
			finally
			{
				Cursor = Cursors.Default;
				if (toolStripButton != null)
				{
					toolStripButton.Enabled = true;
				}
			}
		}

		private void tsBtnMovePoint_Click(object sender, EventArgs e)
		{
			if (_axis.CheckManualEnable() && double.TryParse(tsLabelActPos.Text, out var result))
			{
				_axis.MoveAbs((ITask)null, result, (ushort)50, 50, false, true, 1, (EleAlarmLevel)2);
			}
		}

		private void tsBtnTeach_Click(object sender, EventArgs e)
		{
		}

		internal void CycleUpdate()
		{
			if (base.InvokeRequired)
			{
				BeginInvoke(new Action(CycleUpdate));
				return;
			}
			tsLabelActPos.Text = _axis.ActualPos.ToString();
			tsLabelAlm.BackColor = (_axis.IsAlarm ? Color.Red : Color.Gray);
			tsLabelPel.BackColor = (_axis.InPel ? Color.Red : Color.Gray);
			tsLabelMel.BackColor = (_axis.InMel ? Color.Red : Color.Gray);
			tsLabelOrg.BackColor = (_axis.InOrigin ? Color.Green : Color.Gray);
			tsBtnEnable.BackColor = (_axis.IsServoOn ? Color.Green : Color.Red);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lead.CPrim.CmpTrigHelper.ComplexInterpolation.AxisTeach));
			this.grpAxisTeach = new System.Windows.Forms.GroupBox();
			this.tsMain = new System.Windows.Forms.ToolStrip();
			this.tsBtnEnable = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsBtnJogDec = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsCmbJogDistance = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsBtnJogAdd = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsLabelPel = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.tsLabelOrg = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.tsLabelMel = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.tsLabelAlm = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.tsBtnHome = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.tsBtnClrErr = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
			this.tsBtnStop = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
			this.tsLabelActPos = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
			this.tsBtnMovePoint = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
			this.grpAxisTeach.SuspendLayout();
			this.tsMain.SuspendLayout();
			base.SuspendLayout();
			this.grpAxisTeach.Controls.Add(this.tsMain);
			this.grpAxisTeach.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpAxisTeach.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.grpAxisTeach.Location = new System.Drawing.Point(0, 0);
			this.grpAxisTeach.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.grpAxisTeach.Name = "grpAxisTeach";
			this.grpAxisTeach.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.grpAxisTeach.Size = new System.Drawing.Size(1062, 60);
			this.grpAxisTeach.TabIndex = 0;
			this.grpAxisTeach.TabStop = false;
			this.grpAxisTeach.Text = "Name";
			this.tsMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[27]
			{
				this.tsBtnEnable, this.toolStripSeparator1, this.tsBtnJogDec, this.toolStripSeparator2, this.tsCmbJogDistance, this.toolStripSeparator3, this.tsBtnJogAdd, this.toolStripSeparator4, this.tsLabelPel, this.toolStripSeparator6,
				this.tsLabelOrg, this.toolStripSeparator5, this.tsLabelMel, this.toolStripSeparator7, this.tsLabelAlm, this.toolStripSeparator8, this.tsBtnHome, this.toolStripSeparator9, this.tsBtnClrErr, this.toolStripSeparator13,
				this.tsBtnStop, this.toolStripSeparator12, this.tsLabelActPos, this.toolStripSeparator10, this.toolStripSeparator11, this.tsBtnMovePoint, this.toolStripSeparator14
			});
			this.tsMain.Location = new System.Drawing.Point(3, 23);
			this.tsMain.Name = "tsMain";
			this.tsMain.Size = new System.Drawing.Size(1056, 33);
			this.tsMain.TabIndex = 182;
			this.tsMain.Text = "toolStrip1";
			this.tsBtnEnable.BackColor = System.Drawing.Color.Lavender;
			this.tsBtnEnable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsBtnEnable.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.tsBtnEnable.Image = (System.Drawing.Image)resources.GetObject("tsBtnEnable.Image");
			this.tsBtnEnable.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnEnable.Name = "tsBtnEnable";
			this.tsBtnEnable.Size = new System.Drawing.Size(41, 30);
			this.tsBtnEnable.Text = "使能";
			this.tsBtnEnable.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			this.tsBtnEnable.Click += new System.EventHandler(tsBtnEnable_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
			this.tsBtnJogDec.BackColor = System.Drawing.Color.Lavender;
			this.tsBtnJogDec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsBtnJogDec.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.tsBtnJogDec.Image = (System.Drawing.Image)resources.GetObject("tsBtnJogDec.Image");
			this.tsBtnJogDec.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnJogDec.Name = "tsBtnJogDec";
			this.tsBtnJogDec.Size = new System.Drawing.Size(48, 30);
			this.tsBtnJogDec.Text = "JOG-";
			this.tsBtnJogDec.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 33);
			this.tsCmbJogDistance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tsCmbJogDistance.Items.AddRange(new object[3] { "10", "1", "0.1" });
			this.tsCmbJogDistance.Name = "tsCmbJogDistance";
			this.tsCmbJogDistance.Size = new System.Drawing.Size(75, 33);
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 33);
			this.tsBtnJogAdd.BackColor = System.Drawing.Color.Lavender;
			this.tsBtnJogAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsBtnJogAdd.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.tsBtnJogAdd.Image = (System.Drawing.Image)resources.GetObject("tsBtnJogAdd.Image");
			this.tsBtnJogAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnJogAdd.Name = "tsBtnJogAdd";
			this.tsBtnJogAdd.Size = new System.Drawing.Size(53, 30);
			this.tsBtnJogAdd.Text = "JOG+";
			this.tsBtnJogAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 33);
			this.tsLabelPel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsLabelPel.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold);
			this.tsLabelPel.Name = "tsLabelPel";
			this.tsLabelPel.Size = new System.Drawing.Size(34, 30);
			this.tsLabelPel.Text = "PEL";
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 33);
			this.tsLabelOrg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsLabelOrg.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold);
			this.tsLabelOrg.Name = "tsLabelOrg";
			this.tsLabelOrg.Size = new System.Drawing.Size(41, 30);
			this.tsLabelOrg.Text = "ORG";
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 33);
			this.tsLabelMel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsLabelMel.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold);
			this.tsLabelMel.Name = "tsLabelMel";
			this.tsLabelMel.Size = new System.Drawing.Size(39, 30);
			this.tsLabelMel.Text = "MEL";
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 33);
			this.tsLabelAlm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsLabelAlm.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold);
			this.tsLabelAlm.Name = "tsLabelAlm";
			this.tsLabelAlm.Size = new System.Drawing.Size(42, 30);
			this.tsLabelAlm.Text = "ALM";
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 33);
			this.tsBtnHome.BackColor = System.Drawing.Color.Lavender;
			this.tsBtnHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsBtnHome.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.tsBtnHome.Image = (System.Drawing.Image)resources.GetObject("tsBtnHome.Image");
			this.tsBtnHome.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnHome.Name = "tsBtnHome";
			this.tsBtnHome.Size = new System.Drawing.Size(41, 30);
			this.tsBtnHome.Text = "回零";
			this.tsBtnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			this.tsBtnHome.Click += new System.EventHandler(tsBtnHome_Click);
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(6, 33);
			this.tsBtnClrErr.BackColor = System.Drawing.Color.Yellow;
			this.tsBtnClrErr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsBtnClrErr.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.tsBtnClrErr.Image = (System.Drawing.Image)resources.GetObject("tsBtnClrErr.Image");
			this.tsBtnClrErr.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnClrErr.Name = "tsBtnClrErr";
			this.tsBtnClrErr.Size = new System.Drawing.Size(55, 30);
			this.tsBtnClrErr.Text = "清报警";
			this.tsBtnClrErr.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			this.tsBtnClrErr.Click += new System.EventHandler(tsBtnClrErr_Click);
			this.toolStripSeparator13.Name = "toolStripSeparator13";
			this.toolStripSeparator13.Size = new System.Drawing.Size(6, 33);
			this.tsBtnStop.BackColor = System.Drawing.Color.OrangeRed;
			this.tsBtnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsBtnStop.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.tsBtnStop.Image = (System.Drawing.Image)resources.GetObject("tsBtnStop.Image");
			this.tsBtnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnStop.Name = "tsBtnStop";
			this.tsBtnStop.Size = new System.Drawing.Size(41, 30);
			this.tsBtnStop.Text = "停止";
			this.tsBtnStop.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			this.tsBtnStop.Click += new System.EventHandler(tsBtnStop_Click);
			this.toolStripSeparator12.Name = "toolStripSeparator12";
			this.toolStripSeparator12.Size = new System.Drawing.Size(6, 33);
			this.tsLabelActPos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsLabelActPos.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold);
			this.tsLabelActPos.Name = "tsLabelActPos";
			this.tsLabelActPos.Size = new System.Drawing.Size(78, 30);
			this.tsLabelActPos.Text = "-1000000";
			this.tsLabelActPos.ToolTipText = "实时位置";
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(6, 33);
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			this.toolStripSeparator11.Size = new System.Drawing.Size(6, 33);
			this.tsBtnMovePoint.BackColor = System.Drawing.Color.Lime;
			this.tsBtnMovePoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsBtnMovePoint.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.tsBtnMovePoint.Image = (System.Drawing.Image)resources.GetObject("tsBtnMovePoint.Image");
			this.tsBtnMovePoint.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnMovePoint.Name = "tsBtnMovePoint";
			this.tsBtnMovePoint.Size = new System.Drawing.Size(41, 30);
			this.tsBtnMovePoint.Text = "移动";
			this.tsBtnMovePoint.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			this.tsBtnMovePoint.Click += new System.EventHandler(tsBtnMovePoint_Click);
			this.toolStripSeparator14.Name = "toolStripSeparator14";
			this.toolStripSeparator14.Size = new System.Drawing.Size(6, 33);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.grpAxisTeach);
			this.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "AxisTeach";
			base.Size = new System.Drawing.Size(1062, 60);
			base.Load += new System.EventHandler(AxisTeach_Load);
			this.grpAxisTeach.ResumeLayout(false);
			this.grpAxisTeach.PerformLayout();
			this.tsMain.ResumeLayout(false);
			this.tsMain.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
