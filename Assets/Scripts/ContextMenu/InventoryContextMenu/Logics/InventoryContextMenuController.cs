namespace VEngine.Inventory.GUI.Context
{
	public class InventoryContextMenuController
	{
		private readonly IInventoryContextMenu _inventoryContextMenu;
		private ISlotsGUIContainerReference _slotGUIContainer;

		public InventoryContextMenuController(IInventoryGUI inventoryGUI, IInventoryContextMenu contextMenu)
		{
		}

		public InventoryContextMenuController(ISlotsGUIContainerReference slotsContainerReference, IInventoryContextMenu contextMenu)
		{
			_slotGUIContainer = slotsContainerReference;
			_inventoryContextMenu = contextMenu;
			RegisterContextMenu();
		}

		private void RegisterContextMenu()
		{
			foreach (var curr in _slotGUIContainer.SlotGUIs)
				RegisterContextMenu(curr.ItemGUI);
		}

		private void RegisterContextMenu(IInventoryItemGUI itemGUI)
		{
			itemGUI.ClickEvents.OnRightClicked.AddListener(() => OnItemClicked(itemGUI));
		}

		private void OnItemClicked(IInventoryItemGUI itemGUI)
		{
			_inventoryContextMenu.Close();
			_inventoryContextMenu.Open(itemGUI.Position, itemGUI);
		}
	}
}
