using VEngine.Items;

namespace VEngine.Inventory
{
	public interface IItemSlot
	{
		bool IsFree { get; }
		IItem Item { get; }
		uint Amount { get; }
	}
}
