using VEngine.Equipments;
using VEngine.Inventory;

namespace VEngine.HandSystem
{
	public class HandInventoryHandler : IHandInventoryHandler
	{
		private readonly IData _data;

		public HandInventoryHandler(IData data)
		{
			_data = data;
		}

		public void OnInventoryChanged(IInventoryData inventoryData)
		{
			if (_data.EquipmentInHand.Item == null)
				return;
			if (inventoryData.Contains(_data.EquipmentInHand.Item) > 0)
				return;
			_data.EquipmentInHand.Copy(null);
			
		}

		public interface IData
		{
			IEquipmentSlotCopy EquipmentInHand { get; }
		}
	}
}
