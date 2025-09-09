using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lead.CPrim.FaiHelper.ComplexFais
{
	public class DistanceForm : Form
	{
		private ComplexFaiConfigs _fais;

		private ComplexFai _fatherFai;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;

		private Label label1;

		private Label label2;

		private ComboBox cmbF1;

		private ComboBox cmbC1;

		private ComboBox cmbC2;

		private ComboBox cmbF2;

		private Label label3;

		private Button btnApply;

		private Button btnOpenFai1Offsets;

		private Button btnOpenFai2Offsets;

		public DistanceForm(ComplexFai fatherFai, ComplexFaiConfigs fais)
		{
			InitializeComponent();
			_fais = fais;
			_fatherFai = fatherFai;
			if (_fatherFai != null)
			{
				while (_fatherFai.ChildFaiConfigs.Count < 2)
				{
					_fatherFai.ChildFaiConfigs.TryAdd(Guid.NewGuid(), new ComplexChildFai());
				}
			}
		}

		private void DistanceForm_Load(object sender, EventArgs e)
		{
			foreach (ComplexFai fatherFai in _fais.FaiConfigs.Values.OrderBy((ComplexFai p) => p.Index))
			{
				if (fatherFai.AglSelect != AglType.Distance)
				{
					cmbF1.Items.Add(fatherFai.Name);
					cmbF2.Items.Add(fatherFai.Name);
				}
			}
			if (_fatherFai.ChildFaiConfigs.Count > 1)
			{
				string fai1FullName = _fatherFai.ChildFaiConfigs.ToArray()[0].Value.Name;
				string fai2FullName = _fatherFai.ChildFaiConfigs.ToArray()[1].Value.Name;
				if (fai1FullName.Split(';').Length >= 2 && fai2FullName.Split(';').Length >= 2)
				{
					cmbC1.Text = ((fai1FullName.Split(';')[1] == null) ? "" : fai1FullName.Split(';')[1]);
					cmbF1.Text = fai1FullName.Split(';')[0];
					cmbC2.Text = ((fai2FullName.Split(';')[1] == null) ? "" : fai2FullName.Split(';')[1]);
					cmbF2.Text = fai2FullName.Split(';')[0];
				}
			}
		}

		private void cmbF1_SelectedIndexChanged(object sender, EventArgs e)
		{
			ICollection<ComplexChildFai> childFais = _fais.FaiConfigs.Values.FirstOrDefault((ComplexFai p) => p.Name == cmbF1.SelectedItem.ToString()).ChildFaiConfigs.Values;
			cmbC1.SelectedIndex = -1;
			cmbC1.Items.Clear();
			foreach (ComplexChildFai childFai in childFais.OrderBy((ComplexChildFai p) => p.Index))
			{
				cmbC1.Items.Add(childFai.Name);
			}
		}

		private void cmbF2_SelectedIndexChanged(object sender, EventArgs e)
		{
			ICollection<ComplexChildFai> childFais = _fais.FaiConfigs.Values.FirstOrDefault((ComplexFai p) => p.Name == cmbF2.SelectedItem.ToString()).ChildFaiConfigs.Values;
			cmbC2.SelectedIndex = -1;
			cmbC2.Items.Clear();
			foreach (ComplexChildFai childFai in childFais.OrderBy((ComplexChildFai p) => p.Index))
			{
				cmbC2.Items.Add(childFai.Name);
			}
		}

		private void btnApply_Click(object sender, EventArgs e)
		{
			string fai1 = "";
			string fai2 = "";
			if (cmbF1.SelectedItem == null || cmbF1.SelectedItem.ToString() == "")
			{
				MessageBox.Show("Fai1 未选择！");
				return;
			}
			fai1 = cmbF1.SelectedItem.ToString();
			if (cmbF1.SelectedItem == null || cmbF1.SelectedItem.ToString() == "")
			{
				MessageBox.Show("Fai2 未选择！");
				return;
			}
			fai2 = cmbF2.SelectedItem.ToString();
			fai1 = ((cmbC1.SelectedItem == null || cmbC1.SelectedItem.ToString().Length <= 0) ? (fai1 + "; ") : (fai1 + ";" + cmbC1.Text));
			fai2 = ((cmbC2.SelectedItem == null || cmbC2.SelectedItem.ToString().Length <= 0) ? (fai2 + "; ") : (fai2 + ";" + cmbC2.Text));
			_fatherFai.ChildFaiConfigs.Values.ToList()[0].Name = fai1;
			_fatherFai.ChildFaiConfigs.Values.ToList()[1].Name = fai2;
			if (cmbC1.SelectedItem == null || cmbF1.SelectedItem == null || cmbC2.SelectedItem == null || cmbF2.SelectedItem == null || string.IsNullOrEmpty(fai1) || fai1.Split(';').Length < 2 || string.IsNullOrEmpty(fai2) || fai2.Split(';').Length < 2)
			{
				if (cmbF1.SelectedItem == null)
				{
					cmbC1.Text = "";
					cmbF1.Text = "";
				}
				else if (cmbC1.SelectedItem == null)
				{
					cmbC1.Text = "";
				}
				if (cmbF2.SelectedItem == null)
				{
					cmbC2.Text = "";
					cmbF2.Text = "";
				}
				else if (cmbC2.SelectedItem == null)
				{
					cmbC2.Text = "";
				}
				MessageBox.Show("当前FAI算法配置子项有误，请检查");
			}
		}

		private void btnOpenFai1Offsets_Click(object sender, EventArgs e)
		{
			OpenOffsetsForm(0);
		}

		private void btnOpenFai2Offsets_Click(object sender, EventArgs e)
		{
			OpenOffsetsForm(1);
		}

		private void OpenOffsetsForm(int index)
		{
			List<ComplexChildFai> childs = _fatherFai.ChildFaiConfigs.Values.ToList();
			if (childs[index].Offsets == null)
			{
				childs[index].Offsets = new List<Offset>();
			}
			if (childs[index].Offsets.Count != _fatherFai.CaveCount)
			{
				childs[index].Offsets.Clear();
				for (int i = 0; i < _fatherFai.CaveCount; i++)
				{
					childs[index].Offsets.Add(new Offset(i));
				}
			}
			FormOffset frm = new FormOffset(childs[index].Offsets);
			frm.ShowDialog();
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
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			cmbF1 = new System.Windows.Forms.ComboBox();
			cmbC1 = new System.Windows.Forms.ComboBox();
			cmbC2 = new System.Windows.Forms.ComboBox();
			cmbF2 = new System.Windows.Forms.ComboBox();
			label3 = new System.Windows.Forms.Label();
			btnApply = new System.Windows.Forms.Button();
			btnOpenFai1Offsets = new System.Windows.Forms.Button();
			btnOpenFai2Offsets = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("宋体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label1.Location = new System.Drawing.Point(28, 27);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(209, 19);
			label1.TabIndex = 0;
			label1.Text = "Fai = ABS(Fai1-Fai2)";
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("宋体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label2.Location = new System.Drawing.Point(28, 88);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(79, 19);
			label2.TabIndex = 1;
			label2.Text = "Fai1 = ";
			cmbF1.FormattingEnabled = true;
			cmbF1.Location = new System.Drawing.Point(110, 87);
			cmbF1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			cmbF1.Name = "cmbF1";
			cmbF1.Size = new System.Drawing.Size(126, 25);
			cmbF1.TabIndex = 2;
			cmbF1.SelectedIndexChanged += new System.EventHandler(cmbF1_SelectedIndexChanged);
			cmbC1.FormattingEnabled = true;
			cmbC1.Location = new System.Drawing.Point(286, 88);
			cmbC1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			cmbC1.Name = "cmbC1";
			cmbC1.Size = new System.Drawing.Size(126, 25);
			cmbC1.TabIndex = 3;
			cmbC2.FormattingEnabled = true;
			cmbC2.Location = new System.Drawing.Point(286, 156);
			cmbC2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			cmbC2.Name = "cmbC2";
			cmbC2.Size = new System.Drawing.Size(126, 25);
			cmbC2.TabIndex = 6;
			cmbF2.FormattingEnabled = true;
			cmbF2.Location = new System.Drawing.Point(110, 155);
			cmbF2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			cmbF2.Name = "cmbF2";
			cmbF2.Size = new System.Drawing.Size(126, 25);
			cmbF2.TabIndex = 5;
			cmbF2.SelectedIndexChanged += new System.EventHandler(cmbF2_SelectedIndexChanged);
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("宋体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label3.Location = new System.Drawing.Point(28, 156);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(79, 19);
			label3.TabIndex = 4;
			label3.Text = "Fai2 = ";
			btnApply.BackColor = System.Drawing.Color.LimeGreen;
			btnApply.Location = new System.Drawing.Point(530, 210);
			btnApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btnApply.Name = "btnApply";
			btnApply.Size = new System.Drawing.Size(99, 29);
			btnApply.TabIndex = 7;
			btnApply.Text = "应用";
			btnApply.UseVisualStyleBackColor = false;
			btnApply.Click += new System.EventHandler(btnApply_Click);
			btnOpenFai1Offsets.BackColor = System.Drawing.Color.SkyBlue;
			btnOpenFai1Offsets.Location = new System.Drawing.Point(437, 81);
			btnOpenFai1Offsets.Name = "btnOpenFai1Offsets";
			btnOpenFai1Offsets.Size = new System.Drawing.Size(87, 35);
			btnOpenFai1Offsets.TabIndex = 8;
			btnOpenFai1Offsets.Text = "补偿值";
			btnOpenFai1Offsets.UseVisualStyleBackColor = false;
			btnOpenFai1Offsets.Visible = false;
			btnOpenFai1Offsets.Click += new System.EventHandler(btnOpenFai1Offsets_Click);
			btnOpenFai2Offsets.BackColor = System.Drawing.Color.SkyBlue;
			btnOpenFai2Offsets.Location = new System.Drawing.Point(437, 149);
			btnOpenFai2Offsets.Name = "btnOpenFai2Offsets";
			btnOpenFai2Offsets.Size = new System.Drawing.Size(87, 35);
			btnOpenFai2Offsets.TabIndex = 9;
			btnOpenFai2Offsets.Text = "补偿值";
			btnOpenFai2Offsets.UseVisualStyleBackColor = false;
			btnOpenFai2Offsets.Visible = false;
			btnOpenFai2Offsets.Click += new System.EventHandler(btnOpenFai2Offsets_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			base.ClientSize = new System.Drawing.Size(641, 252);
			base.Controls.Add(btnOpenFai2Offsets);
			base.Controls.Add(btnOpenFai1Offsets);
			base.Controls.Add(btnApply);
			base.Controls.Add(cmbC2);
			base.Controls.Add(cmbF2);
			base.Controls.Add(label3);
			base.Controls.Add(cmbC1);
			base.Controls.Add(cmbF1);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "DistanceForm";
			Text = "DistanceForm";
			base.Load += new System.EventHandler(DistanceForm_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
