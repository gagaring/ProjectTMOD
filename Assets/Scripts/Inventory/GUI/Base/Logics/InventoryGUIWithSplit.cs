using System;
using UnityEngine;
using VEngine.SO.Variables;
using VEngine.GUI.Split;
using VEngine.Items;

namespace VEngine.Inventory.GUI
{
	public class InventoryGUIWithSplit : InventoryGUI
	{
		private readonly IInventorySplitData _splitData;
		private readonly Command _command;

		private ISplitSlider SplitSlider { get => _splitData.SplitSlider.Value; }

		public InventoryGUIWithSplit(IInventorySplitData data)
			: base(data)
		{
			_splitData = data;
			_command = new Command(this);
		}

		public override void MoveTo(ISlotGUI targetSlot, IInventoryItemGUI itemGUI)
		{
			var inventoryDetails = InventoryItemComponent.FindOn(itemGUI.Item);
			if (!inventoryDetails.IsStackable || itemGUI.SlotGUI.Amount == 1u || !_splitData.SplitModifier.Value)
			{
				base.MoveTo(targetSlot, itemGUI);
				return;
			}
			if (_command.InProgress)
				return;
			_command.Set(targetSlot, itemGUI, InventoryService.MoveItem);
			SplitSlider.Open(1, itemGUI.SlotGUI.Amount, _command.OnCancel, _command.OnSlit);
		}

		public override void StackTo(ISlotGUI targetSlot, IInventoryItemGUI itemGUI)
		{
			var inventoryDetails = InventoryItemComponent.FindOn(itemGUI.Item);
			if (!inventoryDetails.IsStackable || itemGUI.SlotGUI.Amount == 1u || !_splitData.SplitModifier.Value)
			{
				base.StackTo(targetSlot, itemGUI);
				return;
			}
			uint freeAmountOnTargetSlot = inventoryDetails.StackCount - targetSlot.Amount;
			if (freeAmountOnTargetSlot == 0u)
				return;
			if (freeAmountOnTargetSlot == 1u)
			{
				base.StackTo(targetSlot, itemGUI);
				return;
			}
			if (_command.InProgress)
				return;
			_command.Set(targetSlot, itemGUI, InventoryService.MoveItem);
			SplitSlider.Open(1, freeAmountOnTargetSlot >= itemGUI.SlotGUI.Amount ? itemGUI.SlotGUI.Amount : freeAmountOnTargetSlot, _command.OnCancel, _command.OnSlit);
		}

		public interface IInventorySplitData : IInventoryGUIData
		{
			IReferenceWithConstant<bool, BoolVariable> SplitModifier { get; }
			ISplitSliderReference SplitSlider { get; }
		}

		private class Command
		{
			private readonly InventoryGUI _inventoryGUI;
			private bool _inProgress;
			private ISlotGUI _slotGUI;
			private IInventoryItemGUI _itemGUI;

			public bool InProgress { get; private set; }
			public Func<int, int, uint, bool> CommandOnSplit { get; set; }

			public Command(InventoryGUI inventoryGUI)
			{
				_inventoryGUI = inventoryGUI;
				Reset();
			}

			private void Reset()
			{
				InProgress = false;
				_slotGUI = null;
				_itemGUI = null;
			}

			public void OnSlit(uint amount)
			{
				if(CommandOnSplit.Invoke(_itemGUI.SlotGUI.SlotIndex, _slotGUI.SlotIndex, amount))
				{
					//_inventoryGUI.Refresh();
				}
				Reset();
			}

			public void OnCancel()
			{
				Reset();
			}

			public void Set(ISlotGUI slotGUI, IInventoryItemGUI itemGUI, Func<int, int, uint, bool> moveItem)
			{
				_slotGUI = slotGUI;
				_itemGUI = itemGUI;
				CommandOnSplit = moveItem;
				InProgress = true;
			}
		}
	}
}
