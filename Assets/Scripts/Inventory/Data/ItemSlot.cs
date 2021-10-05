using System;
using UnityEngine;
using VEngine.Items;

namespace VEngine.Inventory
{
	[Serializable]
	public class ItemSlot : IItemSlot, IItemSlotModifier
	{
		[SerializeField] private Item _item;
		[SerializeField] private uint _amount = 1;

		private ItemReference _itemRef = null;

		public bool IsFree => Item == null;
		public uint Amount { get => IsFree ? 0 : _amount; }

		public IItemReference ItemReference => ItemRef;

		private ItemReference ItemRef
		{
			get
			{
				if (_itemRef == null)
					_itemRef = new ItemReference(ItemValue);
				else if (_itemRef.Value != Item)
					_itemRef.SetValue(ItemValue);
				return _itemRef;
			}
		}

		public IItem Item
		{
			get => _item;
		}

		private Item ItemValue
		{
			get => _item;
			set
			{
				_item = value;
				ItemRef.SetValue(ItemValue);
			}
		}

		public bool SetItem(IItem item, ref uint amount)
		{
			if (amount == 0 || !IsFree)
				return false;
			if (!(item is Item))
				return false;
			ItemValue = (Item)item;
			_amount = 1;
			--amount;
			if (amount == 0)
				return true;
			AddItem(item, ref amount);
			return true;
		}

		public bool AddItem(IItem item, ref uint amount)
		{
			if (item != (IItem)ItemValue)
				return false;
			return AddAmount(ref amount);
		}

		private bool IsStackFull()
		{
			var inventoryDetails = InventoryItemComponent.FindOn(Item);
			return (!inventoryDetails.IsStackable && _amount == 1) || inventoryDetails.StackCount == _amount;
		}

		public bool RemoveItem(IItem item, ref uint amount)
		{
			if (item != (IItem)ItemValue)
				return false;

			return RemoveAmount(ref amount);
		}

		internal bool AddAmount(ref uint amount)
		{
			if (amount == 0 || IsStackFull())
				return false;

			var targetAmount = _amount + amount;
			var inventoryDetails = InventoryItemComponent.FindOn(Item);
			_amount = inventoryDetails.StackCount > targetAmount ? targetAmount : inventoryDetails.StackCount;
			amount = targetAmount - _amount;
			return true;
		}

		internal bool RemoveAmount(ref uint amount)
		{
			if (amount == 0)
				return false;
			if (_amount > amount)
			{
				_amount -= amount;
				amount = 0;
			}
			else
			{
				ItemValue = null;
				amount -= _amount;
				_amount = 0;
			}
			return true;
		}
	}
}
