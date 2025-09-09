using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lead.CPrim.StationCommon.Recipe
{
    public partial class RecipeElesConfigForm : Form
	{
		private SingleRecipeCfg _recipe;


		public RecipeElesConfigForm()
		{
			InitializeComponent();
		}

		public RecipeElesConfigForm(SingleRecipeCfg recipe)
		{
			InitializeComponent();
			_recipe = recipe;

			OnLanguageChanged();
			NLocalizer.LanguageChanged += OnLanguageChanged;
		}

		private void RecipeElesConfigForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Dictionary<int, EleMember> dicEles = new Dictionary<int, EleMember>();
			for (int i = 0; i < dgvEles.Rows.Count; i++)
			{
				IEle ele = ElesManagerTransfer.GetEleByName(dgvEles.Rows[i].Cells[1].Value.ToString());
				if (ele != null)
				{
					EleMemberType type = EleTypeConversion(dgvEles.Rows[i].Cells[0].Value.ToString());
					EleMember newEleMember = new EleMember(ele.Name, type, ele);
					dicEles.Add(i, newEleMember);
				}
			}
			_recipe.Eles.Clear();
			if (dicEles.Count <= 0)
			{
				return;
			}
			foreach (KeyValuePair<int, EleMember> eleMember in dicEles)
			{
				_recipe.Eles.TryAdd(eleMember.Key, eleMember.Value);
			}
		}

		private void RecipeElesConfigForm_Load(object sender, EventArgs e)
		{
			ElesInit(_recipe);
			btnRefreshEles_Click(null, null);
		}

		private void btnAddEle_Click(object sender, EventArgs e)
		{
			if (cmbEles.SelectedItem != null && !string.IsNullOrEmpty(cmbEles.SelectedItem.ToString()))
			{
				IEle newEle = ElesManagerTransfer.GetEleByName(cmbEles.SelectedItem.ToString());
				if (newEle != null)
				{
					EleMemberType type = EleTypeConversion(newEle.EleTypeName);
					DataGridViewRow newRow = new DataGridViewRow();
					dgvEles.Rows.Add(newRow);
					dgvEles.Rows[dgvEles.Rows.Count - 1].Cells[0].Value = type.ToString();
					dgvEles.Rows[dgvEles.Rows.Count - 1].Cells[1].Value = newEle.Name;
					EleMember newEleMember = new EleMember(newEle.Name, type, ElesManagerTransfer.GetEleByName(newEle.Name));
					_recipe.Eles.TryAdd(dgvEles.Rows.Count - 1, newEleMember);
					UpdateCBoxEles(_recipe.Eles);
				}
			}
		}

		private void btnEleDown_Click(object sender, EventArgs e)
		{
			ControlHelper.DgvDownRow(ref dgvEles);
			UpdateDicEles(_recipe.Eles);
		}

		private void btnEleUp_Click(object sender, EventArgs e)
		{
			ControlHelper.DgvUpRow(ref dgvEles);
			UpdateDicEles(_recipe.Eles);
		}

		private void btnRefreshEles_Click(object sender, EventArgs e)
		{
			if (ElesManagerTransfer.GetAllIEle().Count >= 1)
			{
				cmbEles.Items.Clear();
				ElesManagerTransfer.GetAllIEle().ForEach(p => cmbEles.Items.Add(p.Name));
				UpdateDicEles(_recipe.Eles);
				UpdateCBoxEles(_recipe.Eles);
			}
		}

		private void btnRemoveEle_Click(object sender, EventArgs e)
		{
			if (dgvEles.SelectedRows.Count != 0)
			{
				int i;
				for (i = 0; i < dgvEles.SelectedRows.Count; i++)
				{
					int index = dgvEles.SelectedRows[i].Index;
					dgvEles.Rows.Remove(dgvEles.Rows[index]);
					_recipe.Eles.TryRemove(index, out var _);
					i--;
				}
				dgvEles.Refresh();
				btnRefreshEles_Click(null, null);
			}
		}

		private void ElesInit(SingleRecipeCfg recipe)
		{
			DataGridViewComboBoxColumn column2 = new DataGridViewComboBoxColumn
			{
				Name = "EleType",
				HeaderText = "Type",
				Width = 120,
				Resizable = DataGridViewTriState.True
			};
			dgvEles.Columns.Add(column2);
			string[] enumNames2 = (string[])(column2.DataSource = Enum.GetNames(typeof(EleMemberType)));
			DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn
			{
				Name = "EleName",
				HeaderText = "Name",
				Width = 180,
				ReadOnly = true,
				Resizable = DataGridViewTriState.True
			};
			dgvEles.Columns.Add(column3);
			dgvEles.Rows.Clear();
			foreach (KeyValuePair<int, EleMember> ele in recipe.Eles)
			{
				DataGridViewRow newRow = new DataGridViewRow();
				dgvEles.Rows.Add(newRow);
				dgvEles.Rows[dgvEles.Rows.Count - 1].Cells[0].Value = ele.Value.EleType.ToString();
				dgvEles.Rows[dgvEles.Rows.Count - 1].Cells[1].Value = ele.Value.EleName;
			}
		}

		private EleMemberType EleTypeConversion(string EleType)
		{
			string[] enumNames = Enum.GetNames(typeof(EleMemberType));
			if (enumNames.Contains(EleType))
			{
				return (EleMemberType)Enum.Parse(typeof(EleMemberType), EleType);
			}
			return EleMemberType.Other;
		}

		private void UpdateCBoxEles(ConcurrentDictionary<int, EleMember> eles)
		{
			foreach (KeyValuePair<int, EleMember> item in eles)
			{
				if (cmbEles.Items.Contains(item.Value.EleName))
				{
					cmbEles.Items.Remove(item.Value.EleName);
					cmbEles.SelectedIndex = -1;
					cmbEles.Text = string.Empty;
					cmbEles.Refresh();
				}
			}
		}

		private void UpdateDicEles(ConcurrentDictionary<int, EleMember> eles)
		{
			eles.Clear();
			int i;
			for (i = 0; i < dgvEles.Rows.Count; i++)
			{
				IEle ele = ElesManagerTransfer.GetEleByName(dgvEles.Rows[i].Cells[1].Value?.ToString());
				if (ele != null)
				{
					EleMemberType type = EleTypeConversion(dgvEles.Rows[i].Cells[0].Value.ToString());
					eles.TryAdd(value: new EleMember(ele.Name, type, ele), key: i);
				}
			}
		}

		private void btnAddAllPrims_Click(object sender, EventArgs e)
		{
			List<string> lstAdded = new List<string>();
			for (int i = 0; i < dgvEles.Rows.Count; i++)
			{
				string name = dgvEles.Rows[i].Cells[1].Value.ToString();
				lstAdded.Add(name);
			}
			foreach (object item in cmbEles.Items)
			{
				if (item != null && !string.IsNullOrEmpty(item.ToString()))
				{
					string eleName = item.ToString();
					IEle newEle = ElesManagerTransfer.GetEleByName(eleName);
					if (newEle != null)
					{
						EleMemberType type = EleTypeConversion(newEle.EleTypeName);
						DataGridViewRow newRow = new DataGridViewRow();
						dgvEles.Rows.Add(newRow);
						dgvEles.Rows[dgvEles.Rows.Count - 1].Cells[0].Value = type.ToString();
						dgvEles.Rows[dgvEles.Rows.Count - 1].Cells[1].Value = newEle.Name;
						EleMember newELeMember = new EleMember(newEle.Name, type, newEle);
						_recipe.Eles.TryAdd(dgvEles.Rows.Count - 1, newELeMember);
					}
				}
			}
			UpdateCBoxEles(_recipe.Eles);
		}

		private void btnRemoveAllPrims_Click(object sender, EventArgs e)
		{
			if (dgvEles.Rows.Count != 0)
			{
				int i;
				for (i = 0; i < dgvEles.Rows.Count; i++)
				{
					int index = dgvEles.Rows[i].Index;
					dgvEles.Rows.Remove(dgvEles.Rows[index]);
					_recipe.Eles.TryRemove(index, out var _);
					i--;
				}
				dgvEles.Refresh();
				btnRefreshEles_Click(null, null);
			}
		}

		private void dgvEles_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
		}

		public void OnLanguageChanged()
		{
			grpEles.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_Recipe_RecipeElesConfigForm_grpEles", "Ôª¼þ");
		}
	}
}
