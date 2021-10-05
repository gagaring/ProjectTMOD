using System.Collections.Generic;

namespace VEngine.Crafting
{
	public interface ICrafting
	{
		bool Craft(IRecipe recipe);
		bool Craft(IReadOnlyList<int> slots);
	}

	public interface ICraftingQueries
	{
		bool CanCraft(IRecipe recipe);
		bool HasEnoughMaterials(IRecipe recipe);
		bool HasEnoughSpaceForResult(IRecipe recipe);
		uint CraftableAmount(IRecipe recipe);
	}
}
