using VEngine.Items;

namespace VEngine.Inventory
{
	public interface IGlobalInventories
	{
		IInventory PlayerInventory { get; }
		IInventory Stash { get; }
	}
}
