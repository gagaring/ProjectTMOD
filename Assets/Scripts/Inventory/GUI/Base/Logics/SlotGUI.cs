using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VEngine.GUI;
using VEngine.GUI.Draggable;
using VEngine.Items;

namespace VEngine.Inventory.GUI
{
	public class SlotGUI : DropSlot, ISlotGUI, IItemGUIDroppedHandler
	{
		private readonly ISlotData _data;
		private readonly ISlotComponents _componets;

		private bool _isAvailable = false;
		private uint _amount;

		public SlotGUI(ISlotData data, ISlotComponents slotComponents) : base(slotComponents.DropSlotComponents)
		{
			_data = data;
			_componets = slotComponents;
			_componets.ItemGUI.SetSlot(this);
		}

		public IInventoryGUIModifier InventoryGUIModifier { get => _componets.InventoryGUIModifier; }

		public IInventoryItemGUI ItemGUI { get => _componets.ItemGUI; }

		public int SlotIndex { get => _data.SlotIndex; }

		public IItem Item
		{
			get => _componets.ItemGUI.Item;
		}

		public bool IsFree
		{
			get => IsAvailable && Item == null;
		}

		public bool IsAvailable
		{
			get => _isAvailable;
			set
			{
				_isAvailable = value;
				if (value)
				{
					_componets.BackgroundImage.sprite = _data.AvailableSprite;
				}
				else
				{
					_componets.BackgroundImage.sprite = _data.UnavailableSprite;
					_componets.ItemGUI.ClearItem();
				}
			}
		}

		public uint Amount
		{
			get => _amount;
			private set
			{
				_amount = value;
				SetAmountText(value);
			}
		}

		public bool Select { get => _componets.Selection.IsSelected; set => _componets.Selection.IsSelected = value; }

		protected virtual void SetAmountText(uint value)
		{
			_componets.AmountText.text = IsShowAmountText(value) ? value.ToString() : "";
			SetAmountTextActive(value);
		}

		protected void SetAmountTextActive(uint value, bool forced = false, bool forcedValue = true)
		{
			if (forced)
				_componets.AmountTextHolder.SetActive(forcedValue);
			else
				_componets.AmountTextHolder.SetActive(IsShowAmountText(value));
		}

		public virtual void SetItem(IItem item, uint amount)
		{
			_componets.ItemGUI.Item = item;
			Amount = amount;
		}

		private bool IsShowAmountText(uint value)
		{
			if (value < 0 || _componets.ItemGUI.Item == null)
				return false;
			return InventoryItemComponent.FindOn(_componets.ItemGUI.Item).IsStackable;
		}

		public virtual void ClearItem()
		{
			_componets.ItemGUI.ClearItem();
			Amount = 0;
		}

		public override void OnDrop(PointerEventData eventData)
		{
			if (!IsAvailable)
				return;

			var draggableButtonGUIBehaviour = eventData.pointerDrag.GetComponent<IDraggableButtonBehaviour>();
			if (!draggableButtonGUIBehaviour.Handler.IsDragEnabled(eventData.button))
				return;

			var itemGUIBehaviour = eventData.pointerDrag.GetComponent<IItemGUIBehaviour>();
			if (itemGUIBehaviour == null)
				return;
			OnItemDropped(itemGUIBehaviour.ItemGUI);
		}

		public void OnItemDropped(IInventoryItemGUI itemGUI)
		{
			if (IsFree)
				_componets.InventoryGUIModifier.MoveTo(this, itemGUI);
			else if (Item == itemGUI.Item)
				_componets.InventoryGUIModifier.StackTo(this, itemGUI);
			else _componets.InventoryGUIModifier.SwapWith(this, itemGUI);
		}

		public interface ISlotData
		{
			int SlotIndex { get; }
			Sprite AvailableSprite { get; }
			Sprite UnavailableSprite { get; }
		}

		public interface ISlotComponents
		{
			IDropSlotComponents DropSlotComponents { get; }
			IInventoryGUIModifier InventoryGUIModifier { get; }
			InventoryItemGUI ItemGUI { get; }
			GameObject AmountTextHolder { get; }
			TMP_Text AmountText { get; }
			Image BackgroundImage { get; }
			ISelection Selection { get; }
		}
	}
}
