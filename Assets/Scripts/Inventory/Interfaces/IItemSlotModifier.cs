using VEngine.Items;

namespace VEngine.Inventory
{
	public interface IItemSlotModifier
	{
		bool SetItem(IItem item, ref uint amount);
		bool RemoveItem(IItem item, ref uint amount);
		bool AddItem(IItem item, ref uint amount);
	}
}
