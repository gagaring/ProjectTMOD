using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.Crafting
{
	[CreateAssetMenu(menuName = "SO/Crafting/Events/RecipeGameEvent")]
	public class RecipeGameEvent : TGameEvent<IRecipe>
	{
#if UNITY_EDITOR
		public Recipe TestRecipe;
#endif
	}
}
