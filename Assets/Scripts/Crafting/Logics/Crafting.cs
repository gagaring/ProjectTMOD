using System.Collections.Generic;
using VEngine.SO.Events;
using VEngine.Inventory;
using VEngine.Items;

namespace VEngine.Crafting
{
	public class Crafting : ICrafting
	{
		private readonly IData _data;

		public Crafting(IData data)
		{
			_data = data;
		}

		public bool Craft(IRecipe recipe)
		{
			if (!_data.Queries.CanCraft(recipe))
			{
				OnCraftFinished(recipe, false);
				return false;
			}
			RemoveItemsFromInventory(recipe);
			AddItemToInventory(recipe);
			OnCraftFinished(recipe, true);
			return true;
		}

		public bool Craft(IReadOnlyList<int> slots)
		{
			if (!GetRecipe(slots, out var recipe) || !_data.Queries.CanCraft(recipe))
			{
				OnCraftFinished(recipe, false);
				return false;
			}
			RemoveItemsFromInventory(slots);
			AddItemToInventory(recipe);
			OnCraftFinished(recipe, true);
			return true;
		}


		private bool GetRecipe(IReadOnlyList<int> slots, out IRecipe recipe)
		{
			var materials = new List<IItem>();
			foreach (var curr in slots)
			{
				if (!_data.InventoryData.IsSlotAvailable(curr))
				{
					recipe = null;
					return false;
				}
				materials.Add(_data.InventoryData.Slots[curr].Item);
			}
			return _data.Recipes.Contains(materials, out recipe);
		}

		private void RemoveItemsFromInventory(IReadOnlyList<int> slots)
		{
			foreach(var curr in slots)
				_data.InventoryService.Remove(curr, 1);
		}

		private void RemoveItemsFromInventory(IRecipe recipe)
		{
			foreach (var curr in recipe.Materials)
				_data.InventoryService.Remove(curr, 1);
		}

		private void AddItemToInventory(IRecipe recipe)
		{
			uint amount = recipe.Result.Amount;
			_data.InventoryService.AddItem(recipe.Result.Item, ref amount);
		}

		private void OnCraftFinished(IRecipe recipe, bool success, string error = "")
		{
			if (success)
				_data.OnCraftFinished.Raise(recipe, true, error);
			else
				_data.OnCraftFinished.Raise(recipe, false, error);
		}

		public interface IData
		{
			IInventoryData InventoryData { get; }
			IInventoryService InventoryService { get; }
			IRecipes Recipes { get; }
			ICraftingQueries Queries { get; }

			TGameEvent<IRecipe, bool, string> OnCraftFinished { get; }
		}
	}
}
