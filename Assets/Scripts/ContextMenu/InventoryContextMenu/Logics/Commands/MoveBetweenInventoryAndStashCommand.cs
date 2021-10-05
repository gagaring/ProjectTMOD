using System;
using UnityEngine;
using VEngine.SO.Variables;
using VEngine.Items;

namespace VEngine.Inventory.GUI.Context
{
	[CreateAssetMenu(menuName = "SO/Inventory/GUI/Commands/MoveBetweenInventoryAndStashCommand.cs")]
	public class MoveBetweenInventoryAndStashCommand : ItemCommandSO
	{
		[SerializeField] private GlobalInventories _inventories;
		[SerializeField] private bool _toStashDirection;
		[SerializeField] private Connector _connector;
		[SerializeField] private BoolReference _isActive;

		public override void Action(IInventoryItemGUI itemGUI)
		{
			GetInventorys(out var from, out var to);
			_connector.Move(from, to, itemGUI.SlotGUI.SlotIndex, itemGUI.SlotGUI.Amount);
		}

		public override bool Active(IInventoryItemGUI itemGUI)
		{
			return _isActive.Value;
		}

		public override bool Enabled(IInventoryItemGUI itemGUI)
		{
			GetInventorys(out var from, out var to);
			return !to.Data.IsFull;
		}

		private void GetInventorys(out IInventory from, out IInventory to)
		{
			if(_toStashDirection)
			{
				from = _inventories.PlayerInventory;
				to = _inventories.Stash;
			}
			else
			{
				from = _inventories.Stash;
				to = _inventories.PlayerInventory;
			}
		}
	}
}
