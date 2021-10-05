using System.Collections.Generic;
using UnityEngine;
using VEngine.Items;

namespace VEngine.Inventory.GUI
{
	public class InventoryGUIBuilder : IInventoryGUIBuilder
	{
		private readonly SlotGUIBehaviour _slotGUIPrefab;

		public InventoryGUIBuilder(SlotGUIBehaviour slotGUIPrefab)
		{
			_slotGUIPrefab = slotGUIPrefab;
		}

		public IInventoryGUIBuilder CreateGUISlots(IInventoryData inventoryData, IInventoryGUIModifier inventoryGUIModifier, SlotsGUIBehaviourContainer slotGUIs, Transform parent)
		{
			for (int i = slotGUIs.Behaviours.Count; i < inventoryData.MaxCapacity; ++i)
			{
				var slotGUI = Object.Instantiate(_slotGUIPrefab, parent);
#if UNITY_EDITOR
				slotGUI.name = $"{_slotGUIPrefab.GetType().Name} {i}";
#endif
				slotGUI.Init(i, inventoryGUIModifier);
				slotGUIs.Add(slotGUI);
			}
			return this;
		}

		public virtual IInventoryGUIBuilder RefreshGUISlots(IInventoryData inventoryData, IReadOnlyList<ISlotGUI> slotGUIs)
		{
			for (int i = 0; i < slotGUIs.Count; ++i)
			{
				if (!inventoryData.IsSlotAvailable(i))
				{
					slotGUIs[i].IsAvailable = false;
					slotGUIs[i].ClearItem();
					continue;
				}
				slotGUIs[i].IsAvailable = true;
				if (inventoryData.IsSlotFree(i))
				{
					slotGUIs[i].ClearItem();
					continue;
				}
				var slot = inventoryData.Slots[i];
				slotGUIs[i].SetItem(slot.Item, slot.Amount);
			}
			return this;
		}

		public IInventoryGUIBuilder RefreshGUISlots(IInventoryData inventoryData, SlotsGUIBehaviourContainer slotGUIBehaviours)
		{
			return RefreshGUISlots(inventoryData, slotGUIBehaviours.SlotGUIs);
		}
	}
}
