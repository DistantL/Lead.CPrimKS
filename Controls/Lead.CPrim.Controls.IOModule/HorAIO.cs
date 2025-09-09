using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.Controls.IOModule
{
	public class HorAIO : UserControl
	{
		private delegate void UpdateControl(string type);

		private delegate void UpdateInputValue(double address, double value);

		private double _address;

		private Config.IOConfig _aIo;

		private IContainer components = null;

		private TableLayoutPanel tableLayoutPanel1;

		private RichTextBox textIo;

		private Label lbelIo;

		private TextBox tBoxValue;

		public event Del_AIOControl Event_AIoControl;

		public HorAIO()
		{
			InitializeComponent();
		}

		public HorAIO(string type, double address, string info, DockStyle dock)
		{
			Dock = dock;
			InitializeComponent();
			_aIo = new Config.IOConfig(address, info);
			Update(type);
			_address = address;
		}

		private void tBoxValue_TextChanged(object sender, EventArgs e)
		{
			if (double.TryParse(tBoxValue.Text, out var result))
			{
				this.Event_AIoControl?.Invoke(tBoxValue.Tag.ToString(), result);
			}
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
				lbelIo.Text = type + _aIo.Address.ToString("##.00");
				tBoxValue.Tag = type + _aIo.Address.ToString("##.00");
				textIo.Text = _aIo.Info ?? "";
				textIo.Tag = type + _aIo.Address.ToString("##.00");
			}
		}

		private void UpdateIoValue(double address, double value)
		{
			if (tBoxValue.InvokeRequired)
			{
				UpdateInputValue method = UpdateIoValue;
				tBoxValue.BeginInvoke(method, address, value);
			}
			else if (address == _address)
			{
				tBoxValue.Text = value.ToString();
			}
		}

		public void UpdateValue(double address, double value)
		{
			UpdateIoValue(address, value);
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textIo = new System.Windows.Forms.RichTextBox();
            this.lbelIo = new System.Windows.Forms.Label();
            this.tBoxValue = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.textIo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbelIo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tBoxValue, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(85, 79);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textIo
            // 
            this.textIo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textIo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textIo.Location = new System.Drawing.Point(3, 52);
            this.textIo.Name = "textIo";
            this.textIo.ReadOnly = true;
            this.textIo.Size = new System.Drawing.Size(79, 24);
            this.textIo.TabIndex = 1;
            this.textIo.Text = "Button of START";
            // 
            // lbelIo
            // 
            this.lbelIo.AutoSize = true;
            this.lbelIo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbelIo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbelIo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lbelIo.Location = new System.Drawing.Point(3, 0);
            this.lbelIo.Name = "lbelIo";
            this.lbelIo.Size = new System.Drawing.Size(79, 27);
            this.lbelIo.TabIndex = 4;
            this.lbelIo.Text = "AI10.0";
            this.lbelIo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tBoxValue
            // 
            this.tBoxValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tBoxValue.Location = new System.Drawing.Point(3, 30);
            this.tBoxValue.Name = "tBoxValue";
            this.tBoxValue.Size = new System.Drawing.Size(79, 21);
            this.tBoxValue.TabIndex = 5;
            this.tBoxValue.Text = "123456.23";
            this.tBoxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBoxValue.TextChanged += new System.EventHandler(this.tBoxValue_TextChanged);
            // 
            // HorAIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "HorAIO";
            this.Size = new System.Drawing.Size(85, 79);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

		}
	}
}
