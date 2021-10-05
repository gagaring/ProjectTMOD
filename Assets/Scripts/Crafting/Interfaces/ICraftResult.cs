using VEngine.Items;

namespace VEngine.Crafting
{
	public interface ICraftResult
	{
		IItem Item { get; }
		uint Amount { get; }
	}
}
