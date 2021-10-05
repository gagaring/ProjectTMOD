using System;
using UnityEngine;
using VEngine.SO.Events;
using VEngine.Inventory;

namespace VEngine.Crafting
{
	[CreateAssetMenu(menuName = "SO/Crafting/CraftingSO")]
	public class CraftingSO : ScriptableObject
	{
		[SerializeField] private Data _data;

		private ICrafting _crafting;
		private ICraftingQueries _craftingQueries;

		public ICrafting Crafting
		{
			get
			{
				if (_crafting == null)
				{
					_data.Queries = CraftingQueries;
					_crafting = new Crafting(_data);
				}
				return _crafting;
			}
		}

		public ICraftingQueries CraftingQueries
		{
			get
			{
				if (_craftingQueries == null)
					_craftingQueries = new CraftingQueries(_data);
				return _craftingQueries;
			}
		}

		[Serializable]
		public class Data : Crafting.IData, CraftingQueries.IData
		{
			[SerializeField] private InventoryReference _invetory;
			[SerializeField] private Recipes _recipes;
			[SerializeField] private CraftFinishedGameEvent _onCraftFinished;

			public IRecipes Recipes => _recipes;

			public TGameEvent<IRecipe, bool, string> OnCraftFinished => _onCraftFinished;

			public ICraftingQueries Queries { get; set; }

			public IInventoryData InventoryData => _invetory.Inventory.Data;
			public IInventoryService InventoryService => _invetory.Inventory.Service;
		}
	}
}
