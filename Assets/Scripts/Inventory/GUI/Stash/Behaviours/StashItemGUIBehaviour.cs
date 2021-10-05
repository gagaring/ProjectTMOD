using System;
using TMPro;
using UnityEngine;

namespace VEngine.Inventory.GUI.Stash
{
	public class StashItemGUIBehaviour : InventoryItemGUIBehaviour
	{
		[SerializeField] private StashItemGUIData _stashItemGUIData;
		[SerializeField] private StashItemGUIComponents _stashItemGUIComponents;

		protected override void Awake()
		{
			GetStashItemGUIComponents();
			base.Awake();
		}

		private void GetStashItemGUIComponents()
		{
			if (_stashItemGUIData == null)
				_stashItemGUIData = new StashItemGUIData();
			if (_stashItemGUIComponents == null)
				_stashItemGUIComponents = new StashItemGUIComponents();

			if (_stashItemGUIComponents.ItemName == null)
				_stashItemGUIComponents.SetItemName = GetComponentInChildren<TextMeshProUGUI>();
		}

		protected override InventoryItemGUI CreateItemGUI()
		{
			SetupData();
			SetupComponents();
			return new StashItemGUI(_stashItemGUIData, _stashItemGUIComponents);
		}


		protected override void SetupData()
		{
			base.SetupData();
			_stashItemGUIData.ItemGUIData = _itemGUIData;		
		}

		protected override void SetupComponents()
		{
			base.SetupComponents();
			_stashItemGUIComponents.ItemGUIComponents = _itemGUIComponents;
		}
		[Serializable]
		protected class StashItemGUIData : StashItemGUI.IStashItemGUIData
		{
			public InventoryItemGUI.IItemGUIData ItemGUIData { get; set; }
		}

		[Serializable]
		protected class StashItemGUIComponents : StashItemGUI.IStashItemGUIComponents
		{
			[SerializeField] private TextMeshProUGUI _itemName;

			public InventoryItemGUI.IItemGUIComponents ItemGUIComponents { get; set; }
			public TMP_Text ItemName { get => _itemName; }
			public TextMeshProUGUI SetItemName { set => _itemName = value; }
		}
	}
}
