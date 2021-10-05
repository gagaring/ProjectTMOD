using VEngine.Items;

namespace VEngine.Inventory.GUI
{
	public interface ISlotGUI
	{
		IInventoryGUIModifier InventoryGUIModifier { get; }
		int SlotIndex { get; }
		bool IsFree { get; }
		bool IsAvailable { get; set; }
		IItem Item { get; }
		void SetItem(IItem item, uint amount);
		void ClearItem();
		uint Amount { get; }

		IInventoryItemGUI ItemGUI { get; }
		bool Select { get; set; }
	}

	public interface IItemGUIDroppedHandler
	{ 
		void OnItemDropped(IInventoryItemGUI itemGUI);
	}
}
