using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.Controls.IOModule
{
	public class VerDI : UserControl
	{
		private delegate void UpdateControl();

		private delegate void UpdateInputStatus(bool status);

		private Config.IOConfig _in;

		private IContainer components = null;

		private SplitContainer splitContainer1;

		private Button btnIn;

		private TextBox textIn;

		public event Del_DIOControl Event_InputControl;

		public VerDI()
		{
			InitializeComponent();
		}

		public VerDI(double address, string info)
		{
			InitializeComponent();
			_in = new Config.IOConfig(address, info);
			Update();
		}

		private void BtnIn_Click(object sender, EventArgs e)
		{
			this.Event_InputControl?.Invoke(btnIn.Tag.ToString(), btnIn.BackColor != Color.LawnGreen);
		}

		private new void Update()
		{
			if (base.InvokeRequired)
			{
				UpdateControl method = Update;
				BeginInvoke(method);
				return;
			}
			btnIn.Text = "I" + _in.Address.ToString("##.00");
			btnIn.Tag = "I" + _in.Address.ToString("##.00");
			textIn.Text = _in.Info ?? "";
			textIn.Tag = "I" + _in.Address.ToString("##.00");
		}

		private void UpdateInput(bool status)
		{
			if (btnIn.InvokeRequired)
			{
				UpdateInputStatus method = UpdateInput;
				btnIn.BeginInvoke(method, status);
			}
			else
			{
				btnIn.BackColor = (status ? Color.LawnGreen : Color.Red);
			}
		}

		public void UpdateValue(bool status)
		{
			UpdateInput(status);
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnIn = new System.Windows.Forms.Button();
            this.textIn = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnIn);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textIn);
            this.splitContainer1.Size = new System.Drawing.Size(243, 20);
            this.splitContainer1.SplitterDistance = 60;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnIn
            // 
            this.btnIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Location = new System.Drawing.Point(0, 0);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(60, 20);
            this.btnIn.TabIndex = 0;
            this.btnIn.Text = "I10.00";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.BtnIn_Click);
            // 
            // textIn
            // 
            this.textIn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textIn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textIn.Location = new System.Drawing.Point(0, 0);
            this.textIn.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.textIn.Name = "textIn";
            this.textIn.ReadOnly = true;
            this.textIn.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textIn.Size = new System.Drawing.Size(179, 16);
            this.textIn.TabIndex = 0;
            this.textIn.Text = "AAAAAAAAAAAAAAAAaaaaaaaaaaaaaaaaaa";
            // 
            // VerDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "VerDI";
            this.Size = new System.Drawing.Size(243, 20);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
	}
}
