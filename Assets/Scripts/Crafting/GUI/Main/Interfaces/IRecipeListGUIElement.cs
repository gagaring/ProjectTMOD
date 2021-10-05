using System;
using VEngine.Items;

namespace VEngine.Crafting.GUI
{
	public interface IRecipeListGUIElement
	{
		Action<IRecipe> OnClicked { get; set; }
		IRecipe Recipe { get; set; }
		bool Selected { set; }
	}
}
