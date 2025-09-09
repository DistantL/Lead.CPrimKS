using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.Controls.IOModule
{
	public class HorDIO : UserControl
	{
		private delegate void UpdateControl(string type);

		private delegate void UpdateInputStatus(double address, bool status);

		private double _address;

		private Config.IOConfig _dIo;

		private IContainer components = null;

		private TableLayoutPanel tableLayoutPanel1;

		private RichTextBox textIo;

		private Button btnIo;

		public double Address => _address;

		public event Del_DIOControl Event_DIoControl;

		public HorDIO()
		{
			InitializeComponent();
		}

		public HorDIO(string type, double address, string info, DockStyle dock)
		{
			Dock = dock;
			InitializeComponent();
			_dIo = new Config.IOConfig(address, info);
			Update(type);
			_address = address;
		}

		private void btnIo_Click(object sender, EventArgs e)
		{
			this.Event_DIoControl?.Invoke(btnIo.Tag.ToString(), btnIo.BackColor != Color.LawnGreen);
		}

		private void Update(string type)
		{
			if (base.InvokeRequired)
			{
				UpdateControl method = Update;
				BeginInvoke(method, type);
			}
			else
			{
				btnIo.Text = type + _dIo.Address.ToString("##.00");
				btnIo.Tag = type + _dIo.Address.ToString("##.00");
				textIo.Text = _dIo.Info ?? "";
				textIo.Tag = type + _dIo.Address.ToString("##.00");
			}
		}

		private void UpdateIoStatus(double address, bool status)
		{
			if (btnIo.InvokeRequired)
			{
				UpdateInputStatus method = UpdateIoStatus;
				btnIo.BeginInvoke(method, address, status);
			}
			else if (address == _address)
			{
				btnIo.BackColor = (status ? Color.LawnGreen : Color.Red);
			}
		}

		public void UpdateValue(double address, bool status)
		{
			UpdateIoStatus(address, status);
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
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			textIo = new System.Windows.Forms.RichTextBox();
			btnIo = new System.Windows.Forms.Button();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tableLayoutPanel1.Controls.Add(textIo, 0, 0);
			tableLayoutPanel1.Controls.Add(btnIo, 0, 0);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40f));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14f));
			tableLayoutPanel1.Size = new System.Drawing.Size(85, 86);
			tableLayoutPanel1.TabIndex = 0;
			textIo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			textIo.Dock = System.Windows.Forms.DockStyle.Fill;
			textIo.Location = new System.Drawing.Point(3, 43);
			textIo.Name = "textIo";
			textIo.ReadOnly = true;
			textIo.Size = new System.Drawing.Size(79, 40);
			textIo.TabIndex = 1;
			textIo.Text = "Button of START";
			btnIo.Dock = System.Windows.Forms.DockStyle.Fill;
			btnIo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnIo.Location = new System.Drawing.Point(3, 3);
			btnIo.Name = "btnIo";
			btnIo.Size = new System.Drawing.Size(79, 34);
			btnIo.TabIndex = 2;
			btnIo.Text = "I10.01";
			btnIo.UseVisualStyleBackColor = true;
			btnIo.Click += new System.EventHandler(btnIo_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.ControlDark;
			base.Controls.Add(tableLayoutPanel1);
			base.Name = "HorIO";
			base.Size = new System.Drawing.Size(85, 86);
			tableLayoutPanel1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
