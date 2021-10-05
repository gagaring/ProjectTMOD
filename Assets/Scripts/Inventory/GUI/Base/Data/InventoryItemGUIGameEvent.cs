using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.Inventory.GUI
{
	[CreateAssetMenu(menuName = "SO/Inventory/InvItemGUIGameEvent")]
	public class InventoryItemGUIGameEvent : TGameEvent<IInventoryItemGUI>
	{
	}
}
