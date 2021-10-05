using VEngine.SO.Events;
using VEngine.Inventory;

namespace VEngine.Crafting
{
	public class CraftingQueries : ICraftingQueries
	{
		private readonly IData _data;

		public CraftingQueries(IData data)
		{
			_data = data;
		}

		//TODO error system, hogy jobb visszajelzest kapjon a player
		public bool CanCraft(IRecipe recipe)
		{
			return HasEnoughSpaceForResult(recipe) && HasEnoughMaterials(recipe);
		}

		public uint CraftableAmount(IRecipe recipe)
		{
			var amount = uint.MaxValue;
			foreach (var curr in recipe.Materials)
			{
				var currAmount = _data.InventoryData.Contains(curr);
				if (currAmount == 0)
					return 0;
				if (currAmount < amount)
					amount = currAmount;
			}
			return amount == uint.MaxValue ? 0 : amount;
		}

		public bool HasEnoughMaterials(IRecipe recipe)
		{
			foreach (var curr in recipe.Materials)
			{
				if (_data.InventoryData.Contains(curr, 1))
					continue;
				return false;
			}
			return true;
		}

		public bool HasEnoughSpaceForResult(IRecipe recipe)
		{
			return _data.InventoryData.AvailableFreeSpaceFor(recipe.Result.Item) >= recipe.Result.Amount;
		}

		public interface IData
		{
			IInventoryData InventoryData { get; }
			IRecipes Recipes { get; }

			TGameEvent<IRecipe, bool, string> OnCraftFinished { get; }
		}
	}
}
