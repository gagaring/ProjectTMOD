using VEngine.Inventory;

namespace VEngine.HandSystem
{
	public interface IHandInventoryHandler
	{
		void OnInventoryChanged(IInventoryData inventoryData);
	}
}