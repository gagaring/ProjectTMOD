using VEngine.GUI.Limiter;

namespace VEngine.Inventory.GUI
{
	public interface IItemGUIBehaviour
	{
		IInventoryItemGUI ItemGUI { get; }
		IAreaLimiterTarget AreaLimiterTarget { get; }
	}
}
