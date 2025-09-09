using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.FaiHelper.ComplexFais
{
	public class FormOffset : Form
	{
		private List<Offset> Offsets = new List<Offset>();

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;

		private DataGridView dataGridView1;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn Column2;

		private DataGridViewTextBoxColumn Column3;

		public FormOffset()
		{
			InitializeComponent();
		}

		public FormOffset(List<Offset> offsets)
		{
			InitializeComponent();
			Offsets = offsets;
			dataGridView1.DataSource = Offsets;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			dataGridView1 = new System.Windows.Forms.DataGridView();
			Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Columns.AddRange(Column1, Column2, Column3);
			dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			dataGridView1.Location = new System.Drawing.Point(0, 0);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.RowTemplate.Height = 23;
			dataGridView1.Size = new System.Drawing.Size(332, 479);
			dataGridView1.TabIndex = 4;
			Column1.DataPropertyName = "Index";
			Column1.HeaderText = "穴位号";
			Column1.Name = "Column1";
			Column1.Width = 65;
			Column2.DataPropertyName = "CompensationFactor";
			dataGridViewCellStyle1.Format = "N3";
			dataGridViewCellStyle1.NullValue = null;
			Column2.DefaultCellStyle = dataGridViewCellStyle1;
			Column2.HeaderText = "补偿系数";
			Column2.Name = "Column2";
			Column2.Width = 110;
			Column3.DataPropertyName = "Compensation";
			dataGridViewCellStyle2.Format = "N3";
			dataGridViewCellStyle2.NullValue = null;
			Column3.DefaultCellStyle = dataGridViewCellStyle2;
			Column3.HeaderText = "补偿值";
			Column3.Name = "Column3";
			Column3.Width = 115;
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			base.ClientSize = new System.Drawing.Size(332, 479);
			base.Controls.Add(dataGridView1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "FormOffset";
			Text = "补偿值";
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
		}
	}
}
