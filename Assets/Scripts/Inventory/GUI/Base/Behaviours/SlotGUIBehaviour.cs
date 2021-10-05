using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VEngine.GUI;
using VEngine.GUI.Draggable;

namespace VEngine.Inventory.GUI
{
    public class SlotGUIBehaviour : DropSlotBehaviour
	{
		[SerializeField] protected SlotComponents _slotComponents;
		[SerializeField] protected SlotData _data;

		public ISlotGUI SlotGUI { get; private set; }

		protected override void Awake()
		{
			GetCompontents();
			base.Awake();
		}

		private void GetCompontents()
		{
			if (_slotComponents == null)
				_slotComponents = new SlotComponents();
			if (_slotComponents.BackgroundImage == null)
				_slotComponents.BackgroundImage = GetComponent<Image>();
			if (_slotComponents.ItemGUIBehaviour == null)
				_slotComponents.ItemGUIBehaviour = GetComponentInChildren<InventoryItemGUIBehaviour>();
			if (_slotComponents.AmountText == null)
				_slotComponents.AmountTextTMP = GetComponentInChildren<TextMeshProUGUI>();
			if (_slotComponents.AmountText != null && _slotComponents.AmountTextHolder == null)
				_slotComponents.AmountTextHolder = _slotComponents.AmountText.gameObject;

		}

		protected override void CreateDropSlot() {}

		public void Init(int slotIndex, IInventoryGUIModifier inventoryGUIModifier)
		{
			var slotGUI = CreateSlotGUI(slotIndex, inventoryGUIModifier);

			_dropSlotHandler = slotGUI;
			SlotGUI = slotGUI;
			_slotComponents.ItemGUIBehaviour.DropSlot = _dropSlotHandler;
		}

		protected virtual SlotGUI CreateSlotGUI(int slotIndex, IInventoryGUIModifier inventoryGUIModifier)
		{
			SetupData(slotIndex);
			SetupComponents(inventoryGUIModifier);
			return new SlotGUI(_data, _slotComponents);
		}

		protected virtual void SetupData(int slotIndex)
		{
			_data.SlotIndex = slotIndex;
		}

		protected virtual void SetupComponents(IInventoryGUIModifier inventoryGUIModifier)
		{
			_slotComponents.InventoryGUIModifier = inventoryGUIModifier;
			_slotComponents.DropSlotComponents = base._dropSlotComponents;
		}

		private void OnDestroy()
		{
			if (_slotComponents.ItemGUIBehaviour == null || _slotComponents.ItemGUIBehaviour.Events == null)
				return;
		}

		[Serializable]
		public class SlotData : SlotGUI.ISlotData
		{
			[SerializeField] protected SlotGUISpriteReference _sprites;

			public int SlotIndex { get; set; }
			public Sprite AvailableSprite => _sprites?.AvailableSprite;
			public Sprite UnavailableSprite => _sprites?.UnavailableSprite;
		}
		[Serializable]
		protected class SlotComponents : SlotGUI.ISlotComponents
		{
			[SerializeField] protected Image _backgroundImage;
			[SerializeField] protected InventoryItemGUIBehaviour _itemGUIBehaviour;
			[SerializeField] protected TextMeshProUGUI _amountText;
			[SerializeField] protected GameObject _amountTextHolder;
			[SerializeField] private SelectionBehaviour _selection;

			public ISelection Selection => _selection.Selection;
			public void SetSelection(SelectionBehaviour selection) => _selection = selection;

			public IInventoryGUIModifier InventoryGUIModifier { get; set; }

			public InventoryItemGUI ItemGUI => _itemGUIBehaviour.ItemGUI;

			public GameObject AmountTextHolder { get => _amountTextHolder; set => _amountTextHolder = value; }

			public TMP_Text AmountText => _amountText;
			public TextMeshProUGUI AmountTextTMP { set => _amountText = value; }

			public Image BackgroundImage { get => _backgroundImage; set => _backgroundImage = value; }
			public InventoryItemGUIBehaviour ItemGUIBehaviour { get => _itemGUIBehaviour; set => _itemGUIBehaviour = value; }

			public DropSlot.IDropSlotComponents DropSlotComponents { get; set; }
		}
	}
}
