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
    /// <summary>
    /// 配方_基元管理器
    /// </summary>
    public partial class RecipePrimsConfigForm : Form
	{
		#region Field
		/// <summary>配方实例</summary>
		private SingleRecipeCfg _recipe;
		#endregion


		#region Ctor
		public RecipePrimsConfigForm()
		{
			InitializeComponent();
		}
		public RecipePrimsConfigForm(SingleRecipeCfg recipe)
		{
			InitializeComponent();
			_recipe = recipe;

			OnLanguageChanged();
			NLocalizer.LanguageChanged += OnLanguageChanged;
		}
		#endregion


		#region Ctor_Son
		/// <summary>
		/// 配方基元加载显示
		/// </summary>
		/// <param name="recipe"></param>
		private void PrimsInit(SingleRecipeCfg recipe)
		{
			dgvPrims.Columns.Clear();
			DataGridViewComboBoxColumn column0 = new DataGridViewComboBoxColumn
			{
				Name = "PrimType",
				HeaderText = "Type",
				Width = 120,
				Resizable = DataGridViewTriState.True
			};
			dgvPrims.Columns.Add(column0);
			//枚举转换为数组
			column0.DataSource = Enum.GetNames(typeof(PrimMemberType));
			DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn
			{
				Name = "PrimName",
				HeaderText = "Name",
				Width = 180,
				ReadOnly = true,
				Resizable = DataGridViewTriState.True
			};
			dgvPrims.Columns.Add(column1);
			dgvPrims.Rows.Clear();
			foreach (KeyValuePair<int, PrimMember> prim in recipe.Prims)
			{
				DataGridViewRow newRow = new DataGridViewRow();
				dgvPrims.Rows.Add(newRow);
				dgvPrims.Rows[dgvPrims.Rows.Count - 1].Cells[0].Value = prim.Value.PrimType.ToString();
				dgvPrims.Rows[dgvPrims.Rows.Count - 1].Cells[1].Value = prim.Value.PrimName;
			}
		}
		
		#endregion


		#region System_Event
		/// <summary>
		/// Load事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RecipePrimsConfigForm_Load(object sender, EventArgs e)
		{
			PrimsInit(_recipe);
			btnRefreshPrims_Click(null, null);
		}
		/// <summary>
		/// Closing事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RecipePrimsConfigForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Dictionary<int, PrimMember> dicPrims = new Dictionary<int, PrimMember>();
			for (int i = 0; i < dgvPrims.Rows.Count; i++)
			{
				IPrim prim = PrimsManagerTransfer.GetPrimByName(dgvPrims.Rows[i].Cells[1].Value.ToString());
				if (prim != null)
				{
					PrimMemberType type = PrimTypeConversion(dgvPrims.Rows[i].Cells[0].Value.ToString());
					PrimMember newPrimMember = new PrimMember(prim.Name, type, prim);
					dicPrims.Add(i, newPrimMember);
				}
			}
			_recipe.Prims.Clear();
			if (dicPrims.Count <= 0)
			{
				return;
			}
			foreach (KeyValuePair<int, PrimMember> primMember in dicPrims)
			{
				_recipe.Prims.TryAdd(primMember.Key, primMember.Value);
			}
		}
		#endregion


		#region Button_Event
		/// <summary>
		/// 基元添加
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAddPrim_Click(object sender, EventArgs e)
		{
			if (cmbPrims.SelectedItem != null && !string.IsNullOrEmpty(cmbPrims.SelectedItem.ToString()))
			{
				IPrim newPrim = PrimsManagerTransfer.GetPrimByName(cmbPrims.SelectedItem.ToString());
				if (newPrim != null)
				{
					PrimMemberType type = PrimTypeConversion(newPrim.HSType.ToString());
					//显示
					DataGridViewRow newRow = new DataGridViewRow();
					dgvPrims.Rows.Add(newRow);
					dgvPrims.Rows[dgvPrims.Rows.Count - 1].Cells[0].Value = type.ToString();
					dgvPrims.Rows[dgvPrims.Rows.Count - 1].Cells[1].Value = newPrim.Name;
					//配方基元集合更新
					PrimMember newPrimMember = new PrimMember(newPrim.Name, type, PrimsManagerTransfer.GetPrimByName(newPrim.Name));
					_recipe.Prims.TryAdd(dgvPrims.Rows.Count - 1, newPrimMember);

					UpdateCBoxPrims(_recipe.Prims);
				}
			}
		}
		/// <summary>
		/// 基元移除
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRemovePrim_Click(object sender, EventArgs e)
		{
			if (dgvPrims.SelectedRows.Count != 0)
			{
				for (int i = 0; i < dgvPrims.SelectedRows.Count; i++)
				{
					int index = dgvPrims.SelectedRows[i].Index;
					dgvPrims.Rows.Remove(dgvPrims.Rows[index]);
					_recipe.Prims.TryRemove(index, out var _);
					i--;
				}
				dgvPrims.Refresh();
				btnRefreshPrims_Click(null, null);
			}
		}
		/// <summary>
		/// 基元刷新
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRefreshPrims_Click(object sender, EventArgs e)
		{
			if (PrimsManagerTransfer.GetAllIPrim().Count >= 1)
			{
				cmbPrims.Items.Clear();
				PrimsManagerTransfer.GetAllIPrim().ForEach(p => cmbPrims.Items.Add(p.Name));
				UpdateDicPrims(_recipe.Prims);
				UpdateCBoxPrims(_recipe.Prims);
			}
		}
		/// <summary>
		/// 基元上移
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPrimUp_Click(object sender, EventArgs e)
		{
			ControlHelper.DgvUpRow(ref dgvPrims);
			UpdateDicPrims(_recipe.Prims);
		}
		/// <summary>
		/// 基元下移
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPrimDown_Click(object sender, EventArgs e)
		{
			ControlHelper.DgvDownRow(ref dgvPrims);
			UpdateDicPrims(_recipe.Prims);
		}
		/// <summary>
		/// 一键添加基元
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAddAllPrims_Click(object sender, EventArgs e)
		{
			List<string> lstAdded = new List<string>();
			for (int i = 0; i < dgvPrims.Rows.Count; i++)
			{
				string name = dgvPrims.Rows[i].Cells[1].Value.ToString();
				lstAdded.Add(name);
			}
			foreach (object item in cmbPrims.Items)
			{
				if (item != null && !string.IsNullOrEmpty(item.ToString()))
				{
					string primName = item.ToString();
					IPrim newPrim = PrimsManagerTransfer.GetPrimByName(primName);
					if (newPrim != null)
					{
						PrimMemberType type = PrimTypeConversion(newPrim.HSType.ToString());
						DataGridViewRow newRow = new DataGridViewRow();
						dgvPrims.Rows.Add(newRow);
						dgvPrims.Rows[dgvPrims.Rows.Count - 1].Cells[0].Value = type.ToString();
						dgvPrims.Rows[dgvPrims.Rows.Count - 1].Cells[1].Value = newPrim.Name;
						PrimMember newPrimMember = new PrimMember(newPrim.Name, type, PrimsManagerTransfer.GetPrimByName(newPrim.Name));
						_recipe.Prims.TryAdd(dgvPrims.Rows.Count - 1, newPrimMember);
					}
				}
			}
			UpdateCBoxPrims(_recipe.Prims);
		}
		/// <summary>
		/// 一键移除基元
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRemoveAllPrims_Click(object sender, EventArgs e)
		{
			if (dgvPrims.Rows.Count != 0)
			{
				int i;
				for (i = 0; i < dgvPrims.Rows.Count; i++)
				{
					int index = dgvPrims.Rows[i].Index;
					dgvPrims.Rows.Remove(dgvPrims.Rows[index]);
					_recipe.Prims.TryRemove(index, out var _);
					i--;
				}
				dgvPrims.Refresh();
				btnRefreshPrims_Click(null, null);
			}
		}
		#endregion


		#region other
		/// <summary>
		/// 将字符串转换为枚举
		/// </summary>
		/// <param name="primType"></param>
		/// <returns></returns>
		private PrimMemberType PrimTypeConversion(string primType)
		{
			string[] enumNames = Enum.GetNames(typeof(PrimMemberType));
			if (enumNames.Contains(primType))
			{
				return (PrimMemberType)Enum.Parse(typeof(PrimMemberType), primType);
			}
			return PrimMemberType.Other;
		}
		/// <summary>
		/// 基元下拉框内容更新
		/// </summary>
		/// <param name="prims"></param>
		private void UpdateCBoxPrims(ConcurrentDictionary<int, PrimMember> prims)
		{
			foreach (KeyValuePair<int, PrimMember> item in prims)
			{
				if (cmbPrims.Items.Contains(item.Value.PrimName))
				{
					cmbPrims.Items.Remove(item.Value.PrimName);
					cmbPrims.SelectedIndex = -1;
					cmbPrims.Text = string.Empty;
					cmbPrims.Refresh();
				}
			}
		}
		/// <summary>
		/// 配方基元集合更新
		/// </summary>
		/// <param name="prims"></param>
		private void UpdateDicPrims(ConcurrentDictionary<int, PrimMember> prims)
		{
			prims.Clear();
			for (int i = 0; i < dgvPrims.Rows.Count; i++)
			{
				IPrim prim = PrimsManagerTransfer.GetPrimByName(dgvPrims.Rows[i].Cells[1].Value.ToString());
				if (prim != null)
				{
					PrimMemberType type = PrimTypeConversion(dgvPrims.Rows[i].Cells[0].Value.ToString());
					prims.TryAdd(value: new PrimMember(prim.Name, type, PrimsManagerTransfer.GetPrimByName(prim.Name)), key: i);
				}
			}
		}
		private void dgvPrims_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
		}
		#endregion

		public void OnLanguageChanged()
		{
			grpPrims.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_Recipe_RecipePrimsConfigForm_grpPrims", "基元");
		}
	}
}
