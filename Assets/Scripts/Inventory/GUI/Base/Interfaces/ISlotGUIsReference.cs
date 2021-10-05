using System.Collections.Generic;

namespace VEngine.Inventory.GUI
{
	public interface ISlotGUIHolder
	{
		List<SlotGUI> SlotGUIs { get; }
	}

	public interface IISlotGUIHolder
	{
		List<ISlotGUI> SlotGUIs { get; }
	}

	public interface IItemGUIReference
	{
		InventoryItemGUI ItemGUI { get; }
	}
}
