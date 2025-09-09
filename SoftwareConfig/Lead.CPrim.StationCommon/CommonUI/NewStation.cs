using Lead.CPrim.ProxyTools;
using System;
using System.Windows.Forms;

namespace Lead.CPrim.StationCommon.CommonUI
{
    public partial class NewStation : Form
	{
		#region Field
		/// <summary>新建工站名称</summary>
		private string _productName = "";
		#endregion



		#region Ctor
		/// <summary>
		/// Ctor
		/// </summary>
		public NewStation()
		{
			InitializeComponent();

			OnLanguageChanged();
			NLocalizer.LanguageChanged += OnLanguageChanged;
		}
		#endregion



		#region Button_Event
		/// <summary>
		/// 取消
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnNew_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(tbName.Text))
			{
				_productName = tbName.Text;
                DialogResult = DialogResult.OK;
				Close();
			}
			else
			{
				Close();
			}
		} 
		#endregion



		#region Method_ExternalUsing
		/// <summary>
		/// 获取工站名称
		/// </summary>
		/// <returns></returns>
		public string GetNewStationName()
		{
			return _productName;
		}
		#endregion

		public void OnLanguageChanged()
		{
			this.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_NewStation_Title", "新建工站");
			btnNew.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_NewStation_NewCreate", "新建");
			btnCancel.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_NewStation_Cancel", "取消");
		}
	}
}
