using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VEngine.SO.Variables;
using VEngine.Items;

namespace VEngine.Crafting
{
	[CreateAssetMenu(menuName = "SO/Crafting/Recipes")]
	public class Recipes : TVariable<List<Recipe>>, IRecipes
	{
		public List<IRecipe> List => Value.ToList<IRecipe>();

		public bool Contains(List<IItem> materials, out IRecipe recipe)
		{
			recipe = Value.Find(x => x.IsEqual(materials));
			return recipe != null;
		}
	}

	[Serializable]
	public class RecipesReference : TReference<List<Recipe>, Recipes>
	{
	}
}
