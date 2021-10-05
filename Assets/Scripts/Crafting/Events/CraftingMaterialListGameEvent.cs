using System.Collections.Generic;
using UnityEngine;
using VEngine.SO.Events;
using VEngine.Items;

namespace VEngine.Crafting
{
	[CreateAssetMenu(menuName = "SO/Crafting/Events/CraftingMaterialListGameEvent")]
	public class CraftingMaterialListGameEvent : TGameEvent<List<IItem>>
	{
	}
}
