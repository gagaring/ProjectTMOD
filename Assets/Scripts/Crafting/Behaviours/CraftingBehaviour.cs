using System;
using System.Collections.Generic;
using UnityEngine;
using VEngine.SO.Events;
using VEngine.Inventory;

namespace VEngine.Crafting
{
	public class CraftingBehaviour : MonoBehaviour
	{
		[SerializeField] private CraftingSO _craftingSO;

		public void Craft(IRecipe recipe)
		{
			_craftingSO.Crafting.Craft(recipe);
		}

		public void Craft(IReadOnlyList<int> slots)
		{
			_craftingSO.Crafting.Craft(slots);
		}
	}
}
