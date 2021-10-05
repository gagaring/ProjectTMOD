using UnityEngine;

namespace VEngine.Crafting
{
	[CreateAssetMenu(menuName = "SO/Crafting/CombinatorSO")]
	public class CombinatorSO : ScriptableObject
	{
		[SerializeField] private RecipesReference _recipes;

		public ICombinator _combinator;

		public ICombinator Combinator 
		{ 
			get
			{
				if (_combinator == null)
					_combinator = new Combinator(_recipes);
				return _combinator;
			}
		}
	}
}
