using System;

namespace VEngine.Crafting.GUI
{
	public interface IRecipeListGUI
	{
		void Refresh(IRecipes availableRecipes);
		IRecipe Selected { set; }

		Action<IRecipe> OnRecipeClicked { get; set; }
	}
}
