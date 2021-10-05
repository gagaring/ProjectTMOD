using UnityEngine;

namespace VEngine.Inventory.GUI
{
	public interface IInventoryContextMenu
	{
		void Open(Vector2 anchorPosition, IInventoryItemGUI itemGUI);
		void Close();
	}
}
