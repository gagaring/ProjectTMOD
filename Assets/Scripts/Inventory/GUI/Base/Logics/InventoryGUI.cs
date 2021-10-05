using UnityEngine;
using VEngine.Items;

namespace VEngine.Inventory.GUI
{
	public class InventoryGUI : InventoryGUIBase, IInventoryGUIModifier
	{
		public InventoryGUI(IInventoryGUIData data) : base (data) {}

		public virtual void MoveTo(ISlotGUI targetSlot, IInventoryItemGUI itemGUI)
		{
			if (!InventoryService.MoveItem(itemGUI.SlotGUI.SlotIndex, targetSlot.SlotIndex))
				return; 
			//Refresh();
		}

		public virtual void StackTo(ISlotGUI targetSlot, IInventoryItemGUI itemGUI)
		{
			if (!InventoryService.MoveItem(itemGUI.SlotGUI.SlotIndex, targetSlot.SlotIndex))
				return;
			//Refresh();
		}

		public virtual void SwapWith(ISlotGUI targetSlot, IInventoryItemGUI itemGUI)
		{
			if (!InventoryService.MoveItem(itemGUI.SlotGUI.SlotIndex, targetSlot.SlotIndex))
				return;
			//Refresh();
		}
	}
}
