using UnityEngine;
using VEngine.Items;

namespace VEngine.Inventory
{
	public class InventoryItemUserService : IInventoryItemUserService
	{
		private readonly IData _data;

		public InventoryItemUserService(IData data) => _data = data;

		public bool CanUse(IItem item) => _data.Inventory.Data.Contains(item) >= GetRequiredNumberToUse(item);
		private uint GetRequiredNumberToUse(IItem item) => 1;

		public void OnUsed(IItem item)
		{
			_data.Inventory.Service.Remove(item, GetRequiredNumberToUse(item));
		}
		
		public interface IData
		{
			IInventory Inventory { get; }
		}
	}
}
