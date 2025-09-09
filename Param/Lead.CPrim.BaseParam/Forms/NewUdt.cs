using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.BaseParam
{
	public partial class NewUdt : UIForm
	{
		public NewUdt()
		{
			this.InitializeComponent();

			OnLanguageChanged();
			NLocalizer.LanguageChanged += OnLanguageChanged;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void btnNew_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.tbName.Text))
			{
				this.TagString = this.tbName.Text;
				base.DialogResult = DialogResult.OK;
				base.Close();
			}
		}

		public void OnLanguageChanged()
		{
			this.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_NewUdt_Title", "新建用户自定义类型");
			btnNew.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_NewUdt_OK", "确认");
			btnCancel.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_NewUdt_Cancel", "取消");
		}
	}
}
