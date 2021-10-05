using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.Crafting
{
	//TODO Error msg keszites
	[CreateAssetMenu(menuName = "SO/Crafting/Events/CraftFinished")]
	public class CraftFinishedGameEvent : TGameEvent<IRecipe, bool, string>
	{
	}
}
