using Lead.CPrim.ProxyTools;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.StationCommon.Recipe
{
	public partial class CreatNewRecipe : Form
	{
		#region Field
		/// <summary>工站</summary>
		private StationConfig _station;

		/// <summary>配方</summary>
		public SingleRecipeCfg NewRecipe;
		#endregion



		#region Ctor
		/// <summary>Ctor</summary>
		/// <param name="station"></param>
		public CreatNewRecipe(StationConfig station)
		{
			InitializeComponent();
			_station = station;

			OnLanguageChanged();
			NLocalizer.LanguageChanged += OnLanguageChanged;
		}
		#endregion



		#region Button_Event
		/// <summary>取消</summary>
		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
		/// <summary>新建</summary>
		private void btnEnter_Click(object sender, EventArgs e)
		{
            try
            {
                string name = txbRecipeName.Text.Trim();
                if (string.IsNullOrEmpty(name))
                {
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_StationCommon_Recipe_CreatNewRecipe_ErrMes_RecipeNameIsEmpty", "配方名不能为空") );
                }

                if (_station.Recipes.ContainsKey(name))
                {
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_StationCommon_Recipe_CreatNewRecipe_ErrMes_RecipeNameExists", "配方名已存在") );
                }

                DateTime now = DateTime.Now;
                NewRecipe = new SingleRecipeCfg
                {
                    Name = name,
                    Creator = txbCreator.Text,
                    CreatTime = now,
                };
                Close();
            }
            catch (Exception ex)
            {
                ProxyTools.Notification.ShowError("新建失败：" + ex.Message);
            }
		}
        #endregion


        public void OnLanguageChanged()
        {
			this.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_Recipe_CreatNewRecipe_Title", "新建配方");
			labRecipeName.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_Recipe_CreatNewRecipe_RecipeName", "配方名:");
			labCreator.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_Recipe_CreatNewRecipe_Creator", "创建者:");
			btnEnter.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_Recipe_CreatNewRecipe_Enter", "新建");
			btnCancel.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_Recipe_CreatNewRecipe_Cancel", "取消");
		}
    }
}
