using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VEngine.SO.Variables;
using VEngine.Items;

namespace VEngine.Crafting
{
	[CreateAssetMenu(menuName = "SO/Crafting/Recipe")]
	public class Recipe : TVariable<List<Item>>, IRecipe
	{
		[SerializeField] private ResultData _result;

		public List<IItem> Materials => Value.ToList<IItem>();

		public IResult Result => _result;

		public bool IsEqual(List<IItem> materials)
		{
			var copy = Materials;
			foreach(var curr in materials)
			{ 
				if(!copy.Remove(curr))
					return false;
			}
			return copy.Count == 0;
		}

		[Serializable]
		private class ResultData : IResult
		{
			[SerializeField] private Item _item;
			[SerializeField] private uint _amount = 1u;

			public IItem Item => _item;
			public uint Amount => _amount;
		}
	}

	[Serializable]
	public class RecipeReference : TReference<List<Item>,Recipe>
	{
	}
}
