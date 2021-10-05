using UnityEngine;
using VEngine.Items;

namespace VEngine.Inventory
{

	[CreateAssetMenu(menuName = "SO/Inventory/Connector")]
    public class Connector : ScriptableObject, IConnector<Item>
    {
		public bool Move(IInventory from, IInventory to, Item item, uint amount)
		{
			if (from.Data.Contains(item) < amount || to.Data.AvailableFreeSpaceFor(item) < amount)
				return false;
			from.Service.Remove(item, amount);
			to.Service.AddItem(item, ref amount);
			return true;
		}

		public bool Move(IInventory from, IInventory to, Item item, int toIndex, uint amount)
		{
			var inventoryDetails = InventoryItemComponent.FindOn(item);
			if (inventoryDetails.StackCount < amount || from.Data.Contains(item) < amount || !to.Data.IsSlotAvailable(toIndex))
				return false;

			var toSlot = to.Data.Slots[toIndex];
			if (!toSlot.IsFree && ((Item)toSlot.Item != item || inventoryDetails.StackCount < amount + toSlot.Amount))
				return false;

			from.Service.Remove(item, amount);
			to.Service.AddItem(item, toIndex, ref amount);
			return true;
		}

		public bool Move(IInventory from, IInventory to, int fromIndex, int toIndex, uint amount)
		{
			if (from.Data.IsSlotFree(fromIndex) || !from.Data.IsSlotAvailable(fromIndex) || !to.Data.IsSlotAvailable(toIndex))
				return false;

			var fromSlot = from.Data.Slots[fromIndex];
			if (fromSlot.Amount < amount)
				return false;

			var item = (Item)fromSlot.Item;
			if(!to.Data.IsSlotFree(toIndex))
			{
				var toSlot = to.Data.Slots[toIndex];
				var toItem = (Item)toSlot.Item;
				if (toItem != item)
					return false;
				var inventoryDetails = InventoryItemComponent.FindOn(item);
				if (inventoryDetails.StackCount < amount + toSlot.Amount)
					return false;
			}

			from.Service.Remove(fromIndex, amount);
			to.Service.AddItem(item, toIndex, ref amount);
			return true;
		}

		public bool Move(IInventory from, IInventory to, int fromIndex, uint amount)
		{
			if (from.Data.IsSlotFree(fromIndex) || !from.Data.IsSlotAvailable(fromIndex))
				return false;

			var fromSlot = from.Data.Slots[fromIndex];
			if (fromSlot.Amount < amount)
				return false;

			var item = (Item)fromSlot.Item;
			if (to.Data.AvailableFreeSpaceFor(item) < amount)
				return false;
			from.Service.Remove(fromIndex, amount);
			to.Service.AddItem(item, ref amount);
			return true;
		}
	}
}
