using UnityEngine;
using UnityEngine.UI;
using VEngine.GUI.Draggable;
using VEngine.Items;

namespace VEngine.Inventory.GUI
{
	public interface IInventoryItemGUI
	{
		IItem Item { get; set; }

		ISlotGUI SlotGUI { get; }
		Image Avatar { get; }

		void SetSlot(ISlotGUI slotGUI);
		void ClearItem();

		IClickEvents ClickEvents { get; }
		Vector2 Position { get; }
	}
}
