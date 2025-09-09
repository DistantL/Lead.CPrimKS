using System;
using System.Collections.Generic;

namespace Lead.CPrim.StationCommon.Recipe
{
	[Serializable]
	public class RecipesConfig
	{
		public SingleRecipeCfg CurrentRecipe { get; set; }

		public string CurrentRecipeName { get; set; }

		public Dictionary<string, SingleRecipeCfg> Recipes { get; set; }

		public RecipesConfig()
		{
			Recipes = new Dictionary<string, SingleRecipeCfg>();
			CurrentRecipe = new SingleRecipeCfg();
			CurrentRecipeName = "";
		}

		public void SetCurrentRecipe()
		{
			CurrentRecipe = Recipes[CurrentRecipeName];
		}
	}
}
