using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Lead.CPrim.Controls.IOModule
{
	public class HorDesc : UserControl
	{
		private IContainer components = null;

		private TableLayoutPanel tableLayoutPanel1;

		private Label lbelModuleType;

		private Label label2;

		private Label lbelType;

		private Label label5;

		private Label lbelSlaveNo;

		public HorDesc()
		{
			InitializeComponent();
		}

		public HorDesc(int no, string typeName, DockStyle dock, string type)
		{
			Dock = DockStyle.Fill;
			InitializeComponent();
			lbelSlaveNo.Text = no.ToString(CultureInfo.InvariantCulture);
			lbelType.Text = typeName;
			lbelModuleType.Text = type;
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
			label5 = new System.Windows.Forms.Label();
			lbelSlaveNo = new System.Windows.Forms.Label();
			lbelModuleType = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			lbelType = new System.Windows.Forms.Label();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
			tableLayoutPanel1.ColumnCount = 3;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35f));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35f));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62f));
			tableLayoutPanel1.Controls.Add(label5, 1, 0);
			tableLayoutPanel1.Controls.Add(lbelSlaveNo, 1, 1);
			tableLayoutPanel1.Controls.Add(lbelModuleType, 0, 0);
			tableLayoutPanel1.Controls.Add(label2, 1, 0);
			tableLayoutPanel1.Controls.Add(lbelType, 2, 1);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30f));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30f));
			tableLayoutPanel1.Size = new System.Drawing.Size(135, 68);
			tableLayoutPanel1.TabIndex = 0;
			label5.AutoSize = true;
			label5.Dock = System.Windows.Forms.DockStyle.Fill;
			label5.Location = new System.Drawing.Point(79, 2);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(56, 30);
			label5.TabIndex = 6;
			label5.Text = "Type:";
			label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			lbelSlaveNo.AutoSize = true;
			lbelSlaveNo.Dock = System.Windows.Forms.DockStyle.Fill;
			lbelSlaveNo.Location = new System.Drawing.Point(42, 34);
			lbelSlaveNo.Name = "lbelSlaveNo";
			lbelSlaveNo.Size = new System.Drawing.Size(29, 32);
			lbelSlaveNo.TabIndex = 5;
			lbelSlaveNo.Text = "1";
			lbelSlaveNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			lbelModuleType.AutoSize = true;
			lbelModuleType.Dock = System.Windows.Forms.DockStyle.Fill;
			lbelModuleType.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			lbelModuleType.Location = new System.Drawing.Point(5, 2);
			lbelModuleType.Name = "lbelModuleType";
			tableLayoutPanel1.SetRowSpan(lbelModuleType, 2);
			lbelModuleType.Size = new System.Drawing.Size(29, 64);
			lbelModuleType.TabIndex = 0;
			lbelModuleType.Text = "DI";
			lbelModuleType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label2.AutoSize = true;
			label2.Dock = System.Windows.Forms.DockStyle.Fill;
			label2.Location = new System.Drawing.Point(42, 2);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(29, 30);
			label2.TabIndex = 1;
			label2.Text = "No:";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			lbelType.AccessibleDescription = " ";
			lbelType.AutoSize = true;
			lbelType.Dock = System.Windows.Forms.DockStyle.Fill;
			lbelType.Location = new System.Drawing.Point(79, 34);
			lbelType.Name = "lbelType";
			lbelType.Size = new System.Drawing.Size(56, 32);
			lbelType.TabIndex = 2;
			lbelType.Text = "1121";
			lbelType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			base.Controls.Add(tableLayoutPanel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "HorDesc";
			base.Size = new System.Drawing.Size(135, 68);
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			ResumeLayout(false);
		}
	}
}
