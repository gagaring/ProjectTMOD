using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.Crafting
{
	[CreateAssetMenu(menuName = "SO/Crafting/Events/RecipesGameEvent")]
	public class RecipesGameEvent : TGameEvent<IRecipes>
	{
	}
}
