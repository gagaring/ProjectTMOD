using System.Collections.Generic;
using UnityEngine;
using VEngine.Items;

namespace VEngine.Inventory.GUI
{
	public interface IInventoryGUIBuilder
	{
		IInventoryGUIBuilder CreateGUISlots(IInventoryData inventory, IInventoryGUIModifier inventoryGUIModifier, SlotsGUIBehaviourContainer slotGUIs, Transform parent);
		//IInventoryGUIBuilder CreateGUISlots(IItemContainer inventory, IInventoryGUIModifier inventoryGUIModifier, List<ISlotGUI> slotGUIs, Transform parent, Transform dragParent);

		IInventoryGUIBuilder RefreshGUISlots(IInventoryData inventory, IReadOnlyList<ISlotGUI> slotGUIs);
		IInventoryGUIBuilder RefreshGUISlots(IInventoryData inventory, SlotsGUIBehaviourContainer slotGUIs);
	}
}
