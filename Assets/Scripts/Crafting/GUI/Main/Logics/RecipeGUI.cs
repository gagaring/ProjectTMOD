using System;
using System.Collections.Generic;
using UnityEngine;
using VEngine.Inventory.GUI;
using VEngine.Items;

namespace VEngine.Crafting.GUI
{
	public class RecipeGUI : IRecipeGUI
	{
		private readonly IData _data;
		private readonly IComponents _components;
		private IRecipe _recipe;

		public RecipeGUI(IData data, IComponents components)
		{
			_data = data;
			_components = components;
		}

		public IRecipe Recipe
		{
			get => _recipe;
			set
			{
				_recipe = value;
				if (value == null)
					Clear();
				else
					Set(value);
			}
		}

		private void Set(IRecipe recipe)
		{
			_components.Main.SetActive(true);
			_components.Name = recipe.Result.Item.Details.Name;
			_components.Description = recipe.Result.Item.Details.Description;
			var craftableAmount = _data.CraftingQueries.CraftableAmount(recipe);
			_components.Amount = $"{craftableAmount} x {recipe.Result.Amount}";
			var details = InventoryGUIItemComponent.FindOn(_recipe.Result.Item);
			_components.Avatar = details.Avatar;
			SetImages(recipe.Materials);
		}

		private void Clear()
		{
			_components.Main.SetActive(false);
			_components.Name = "";
			_components.Description = "";
			_components.Amount = "";
			_components.Avatar = null;
			ClearImages();
		}

		private void ClearImages()
		{
			SetImages(new List<IItem>());
		}

		private void SetImages(List<IItem> materials)
		{
			var materialGUIs = _components.Materials;
			for (int i = 0; i < materials.Count; ++i)
				materialGUIs[i].Set = materials[i];

			for(int i = materials.Count; i < materialGUIs.Count; ++i)
				materialGUIs[i].Set = null;
		}

		public interface IData
		{
			ICraftingQueries CraftingQueries { get; }
		}

		public interface IComponents
		{
			GameObject Main { get; }
			string Name { set; }
			string Description { set; }
			string Amount { set; }
			Sprite Avatar { set; }
			IReadOnlyList<IRecipeGUIMaterial> Materials { get; }
		}
	}
}
