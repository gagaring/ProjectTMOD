using System.Collections.Generic;
using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.Crafting
{
	[CreateAssetMenu(menuName = "SO/Crafting/Events/CraftingBySlotsEvent")]
	public class CraftingBySlotsEvent : TGameEvent<List<int>>
	{
	}
}
