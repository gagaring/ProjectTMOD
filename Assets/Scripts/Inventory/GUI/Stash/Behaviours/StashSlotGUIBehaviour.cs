using System;
using TMPro;
using UnityEngine;
using static VEngine.Inventory.GUI.Stash.StashSlotGUI;

namespace VEngine.Inventory.GUI.Stash
{
    public class StashSlotGUIBehaviour : SlotGUIBehaviour
    {
		[SerializeField] private StashComponents _stashComponents;

		protected override SlotGUI CreateSlotGUI(int slotIndex, IInventoryGUIModifier inventoryGUIModifier)
		{
			SetupData(slotIndex);
			SetupComponents(inventoryGUIModifier);
			return new StashSlotGUI(_data, _stashComponents);
		}

		protected override void SetupComponents(IInventoryGUIModifier inventoryGUIModifier)
		{
			base.SetupComponents(inventoryGUIModifier);
			_stashComponents.SlotComponents = _slotComponents;
		}

		[Serializable]
		public class StashComponents : IStashComponents
		{
			[SerializeField] private GameObject _itemHolder;
			[SerializeField] private TextMeshProUGUI _itemName;
			public GameObject ItemHolder => _itemHolder;
			public TMP_Text ItemName => _itemName;
			public SlotGUI.ISlotComponents SlotComponents { get; set; }
		}
	}
}
