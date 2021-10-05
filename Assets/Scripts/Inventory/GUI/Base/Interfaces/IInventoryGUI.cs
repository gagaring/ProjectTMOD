using System.Collections.Generic;
using VEngine.GUI;

namespace VEngine.Inventory.GUI
{
	public interface IInventoryGUI : IPanel
	{
		void Refresh();

		List<ISlotGUI> SlotGUIs { get; }
	}

	public interface IInventoryGUIModifier
	{
		void MoveTo(ISlotGUI targetSlot, IInventoryItemGUI itemGUI);
		void StackTo(ISlotGUI targetSlot, IInventoryItemGUI itemGUI);
		void SwapWith(ISlotGUI targetSlot, IInventoryItemGUI itemGUI);
	}
}
