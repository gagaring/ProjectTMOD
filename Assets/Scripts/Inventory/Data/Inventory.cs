using System;
using System.Collections.Generic;
using UnityEngine;
using VEngine.SO.Variables;
using VEngine.Items;

namespace VEngine.Inventory
{
	[CreateAssetMenu(menuName = "SO/Inventory/Inventory")]
	public class Inventory : ScriptableObject, IInventory, IInventoryData, IInventoryService
	{
		[SerializeField] private UIntReference _maxCapacity;
		[SerializeField] private UIntReference _availableCapacity;
		[SerializeField] private InventoryDataGameEvent _onChangedEvent;
		[SerializeField] private List<ItemSlot> _slots = new List<ItemSlot>();

		public IInventoryData Data => this;
		public IInventoryService Service => this;

		public uint MaxCapacity => _maxCapacity.Value;
		public uint AvailableCapacity => _availableCapacity.Value;

		public UIntReference MaxCapacityRef { get => _maxCapacity; set => _maxCapacity = value; }
		public UIntReference AvailableCapacityRef { get => _availableCapacity; set => _availableCapacity = value; }

		public InventoryDataGameEvent OnChangedEvent { get => _onChangedEvent; set => _onChangedEvent = value; }

		private List<IItemSlot> _iSlots = new List<IItemSlot>();

		public IReadOnlyList<IItemSlot> Slots
		{
			get
			{
				RefreshISlots();
				return _iSlots;
			}
		}

		public bool IsFull
		{
			get
			{
				if (_slots.Count < _availableCapacity.Value)
					return false;
				foreach (var curr in _slots)
				{
					if (curr.IsFree)
						return false;
				}
				return true;
			}
		}

		public int FreeSlotCount => _slots.FindAll(x => x.IsFree).Count + (int)AvailableCapacity - _slots.Count;

		private void RefreshISlots()
		{
			CreateSlots();
			_iSlots.Clear();
			_iSlots.AddRange(_slots);
		}

		private void CreateSlots()
		{
			if (_slots.Count >= AvailableCapacity)
				return;

			for(int i = _slots.Count; i < AvailableCapacity; ++i)
				_slots.Add(new ItemSlot());
		}

		public bool AddItem(IItem item, int slotIndex, ref uint amount)
		{
			if (slotIndex >= AvailableCapacity)
				return false;
			CreateSlots();
			if (!AddItemToSlot(item, _slots[slotIndex], ref amount))
				return false;
			OnSlotsChanged();
			return true;
		}

		private bool AddItemToSlot(IItem item, ItemSlot targetSlot, ref uint amount)
		{
			if (targetSlot.IsFree)
			{
				targetSlot.SetItem(item, ref amount);
				return true;
			}
			return targetSlot.AddItem(item, ref amount);
		}

		public bool AddItem(IItem item, ref uint amount)
		{
			if (amount == 0)
				return false;
			CreateSlots();
			bool addAtleaseOne = false;
			var inventoryDetails = InventoryItemComponent.FindOn(item);
			if (inventoryDetails.IsStackable)
				addAtleaseOne = TryToAddStacks(item, ref amount);
			var ret = false;
			do
			{
				ret = AddToFirstFreeSlots(item, ref amount);
				addAtleaseOne |= ret;
			}
			while (ret && amount > 0);

			if (!addAtleaseOne)
				return false;
			OnSlotsChanged();
			return true;
		}

		private bool TryToAddStacks(IItem item, ref uint amount)
		{
			bool addAtleaseOne = false;
			for(int i = 0; i < _slots.Count; ++i)
			{
				var curr = _slots[i];
				if (curr.IsFree || (IItem)curr.ItemReference.Value != item)
					continue;
				if (!curr.AddItem(item, ref amount))
					continue;
				if (amount == 0)
					return true;
				addAtleaseOne = true;
			}
			return addAtleaseOne;
		}

		private bool AddToFirstFreeSlots(IItem item, ref uint amount)
		{
			if (amount == 0)
				return false;
			bool addAtleaseOne = false;
			for (int i = 0; i < _slots.Count; ++i)
			{
				var curr = _slots[i];
				if (!curr.IsFree)
					continue;
				curr.SetItem(item, ref amount);
				if (amount == 0)
					return true;
				addAtleaseOne = true;
			}
			return addAtleaseOne;
		}

		public bool Contains(IItem item, uint requiredAmount = 1u)
		{
			return Contains(item) >= requiredAmount;
		}
		
		public uint Contains(IItem item)
		{
			var items = _slots.FindAll(x => (IItem)x.ItemReference.Value == item);
			var sumAmount = 0u;
			foreach (var curr in items)
			{
				sumAmount += curr.Amount;
			}
			return sumAmount;
		}

		public bool IsSlotAvailable(int slotIndex)
		{
			return AvailableCapacity > slotIndex;
		}

		public bool IsSlotFree(int slotIndex)
		{
			return IsSlotAvailable(slotIndex) && (_slots.Count <= slotIndex || _slots[slotIndex].IsFree);
		}

		public bool MoveItem(int fromIndex, int toIndex)
		{
			if (!IsSlotAvailable(fromIndex) || !IsSlotAvailable(toIndex) || IsSlotFree(fromIndex))
				return false;

			if (!MoveItemAfterValidateSlots(fromIndex, toIndex, _slots[fromIndex].Amount))
				return false;

			OnSlotsChanged();
			return true;
		}

		public bool MoveItem(int fromIndex, int toIndex, uint amount)
		{
			if (!IsSlotAvailable(fromIndex) || !IsSlotAvailable(toIndex) || IsSlotFree(fromIndex))
				return false;
			if (!MoveItemAfterValidateSlots(fromIndex, toIndex, amount))
				return false;

			OnSlotsChanged();
			return true;
		}

		private bool MoveItemAfterValidateSlots(int fromIndex, int toIndex, uint amount)
		{
			if (AreSameItemsOnSlots(fromIndex, toIndex))
				return StackItem(_slots[fromIndex], _slots[toIndex], amount);
			if(!IsSlotFree(toIndex))
				return _slots[fromIndex].Amount == amount && SwapItem(fromIndex, toIndex, amount);

			if (_slots[fromIndex].Amount == amount)
				return SwapItem(fromIndex, toIndex, amount);

			return StackItem(_slots[fromIndex], _slots[toIndex], amount);
		}

		private bool AreSameItemsOnSlots(int fromIndex, int toIndex)
		{
			return _slots[fromIndex].Item == _slots[toIndex].Item;
		}

		private bool StackItem(ItemSlot fromSlot, ItemSlot toSlot, uint amount)
		{
			var remainingAmount = amount < fromSlot.Amount ? amount : fromSlot.Amount;
			if (toSlot.IsFree)
			{
				if (!toSlot.SetItem(fromSlot.ItemReference.Value, ref remainingAmount))
					return false;
			}
			else if (!toSlot.AddItem(fromSlot.ItemReference.Value, ref remainingAmount))
				return false;
			var removeableAmount = amount - remainingAmount;
			return fromSlot.RemoveAmount(ref removeableAmount);
		}

		private bool SwapItem(int fromIndex, int toIndex, uint amount)
		{
			CreateSlots();
			var tmp = _slots[fromIndex];
			_slots[fromIndex] = _slots[toIndex];
			_slots[toIndex] = tmp;
			amount = 0;
			return true;
		}

		public bool Remove(IItem item, uint amount)
		{
			if (!Contains(item, amount))
				return false;
			var items = _slots.FindAll(x => (IItem)x.ItemReference.Value == item);
			foreach (var curr in items)
			{
				curr.RemoveItem(item, ref amount);
				if (amount == 0)
				{
					OnSlotsChanged();
					return true;
				}
			}
			OnSlotsChanged();
			return true;
		}

		public bool Remove(int slotIndex, uint amount)
		{
			if (!IsSlotAvailable(slotIndex) || IsSlotFree(slotIndex))
				return false;
			if (_slots[slotIndex].Amount < amount)
				return false;
			_slots[slotIndex].RemoveAmount(ref amount);
			OnSlotsChanged();
			return true;
		}

		public uint AvailableFreeSpaceFor(IItem item)
		{
			var items = _slots.FindAll(x => (IItem)x.ItemReference.Value == item);
			var availableAmount = 0u;
			InventoryItemComponent inventoryDetails;
			foreach (var curr in items)
			{
				inventoryDetails = InventoryItemComponent.FindOn(item);
				availableAmount += inventoryDetails.StackCount - curr.Amount;
			}
			inventoryDetails = InventoryItemComponent.FindOn(item);
			availableAmount += Convert.ToUInt32(FreeSlotCount) * inventoryDetails.StackCount;
			return availableAmount;
		}

		private void OnSlotsChanged()
		{
			OnChangedEvent.Raise(this);
		}
	}
}
