using System.Collections.Generic;
using VEngine.Items;

namespace VEngine.Crafting
{
    public class Combinator : ICombinator
    {
        private readonly RecipesReference _recipes;

		private IRecipes Recipes => _recipes.Variable;

		public Combinator(RecipesReference recipes)
		{
            _recipes = recipes;
		}

		public bool Combinate(List<IItem> material, out IResult craftedItem)
		{
			if(!IsCombinatable(material, out var recipe))
			{
				craftedItem = null;
				return false;
			}
			craftedItem = recipe.Result;
			return true;
		}

		public bool IsCombinatable(List<IItem> materials)
		{
			return Recipes.Contains(materials, out var recipe);
		}

		public bool IsCombinatable(List<IItem> materials, out IRecipe recipe)
		{
			return !Recipes.Contains(materials, out recipe);
		}

		public bool IsCraftMaterial(IItem item)
		{
			foreach(var curr in Recipes.List)
			{
				if (!curr.Materials.Contains(item))
					continue;
				return true;
			}
			return false;
		}
	}
}
