using UnityEngine;
using VEngine.Inventory.GUI.Context;

namespace VEngine.Inventory.GUI
{
	public class InventoryContextMenuControllerBehaviour : MonoBehaviour
	{
		[SerializeField] private SlotsGUIContainerReference _slotsContainerReference;
		[SerializeField] private InventoryContextMenuBehaviour _contextMenu;

		private IInventoryContextMenu InventoryContextMenu { get => _contextMenu.InventoryContextMenu; }
		private InventoryContextMenuController _controller;

		private void Start()
		{
			_controller = new InventoryContextMenuController(_slotsContainerReference, InventoryContextMenu);
		}
	}
}
