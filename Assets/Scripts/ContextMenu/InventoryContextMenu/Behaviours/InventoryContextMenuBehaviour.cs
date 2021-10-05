using System;
using System.Collections.Generic;
using UnityEngine;
using VEngine.GUI.Context;

namespace VEngine.Inventory.GUI.Context
{
	public class InventoryContextMenuBehaviour : ContextMenuBehaviour
	{
		[SerializeField] private InventoryContextMenuData _inventoryData;
		[SerializeField] private InventoryContextMenuComponents _inventoryComponents;

		public IInventoryContextMenu InventoryContextMenu { get => (InventoryContextMenu)_contextMenu; }

		private InventoryContextMenu _inventoryContextMenu;

		protected override void CreateContextMenu()
		{
			_inventoryContextMenu = new InventoryContextMenu(_inventoryData, _inventoryComponents);
			_contextMenu = _inventoryContextMenu;
		}
		
		protected override void InitData()
		{
			base.InitData();
			_inventoryData.Base = _data;
		}

		protected override void InitComponents()
		{
			base.InitComponents();
			_inventoryComponents.Base = _components;
		}

		[Serializable]
		public class InventoryContextMenuData : InventoryContextMenu.IInventoryContextMenuData
		{
			[SerializeField] private List<ItemCommandSO> _commands;

			public VEngine.GUI.Context.ContextMenu.IData Base { get; set; }
			public IReadOnlyList<IItemCommand> Commands => _commands;
		}

		[Serializable]
		public class InventoryContextMenuComponents : InventoryContextMenu.IInventoryContextMenuComponents
		{
			public VEngine.GUI.Context.ContextMenu.IComponents Base { get; set; }
		}
	}
}
