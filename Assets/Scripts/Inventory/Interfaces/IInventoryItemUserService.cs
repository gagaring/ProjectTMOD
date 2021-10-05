using VEngine.Items;

namespace VEngine.Inventory
{
	public interface IInventoryItemUserService
	{
		bool CanUse(IItem item);
		void OnUsed(IItem item);
	}
}