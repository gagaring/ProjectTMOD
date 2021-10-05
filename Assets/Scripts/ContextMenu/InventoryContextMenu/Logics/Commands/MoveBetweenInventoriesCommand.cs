using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Inventory.GUI.Context
{
	[CreateAssetMenu(menuName = "SO/Inventory/GUI/Commands/MoveBetweenInventoriesCommand")]
	public class MoveBetweenInventoriesCommand : ItemCommandSO
	{
		[SerializeField] private InventoryReference _fromInventory;
		[SerializeField] private InventoryReference _toInventory;
		[SerializeField] private Connector _connector;
		[SerializeField] private BoolReference _isActive;

		public override void Action(IInventoryItemGUI itemGUI)
		{
			_connector.Move(_fromInventory.Inventory, _toInventory.Inventory, itemGUI.SlotGUI.SlotIndex, itemGUI.SlotGUI.Amount);
		}

		public override bool Active(IInventoryItemGUI itemGUI)
		{
			return _isActive.Value;
		}

		public override bool Enabled(IInventoryItemGUI itemGUI)
		{
			return _toInventory.Inventory.Data.AvailableFreeSpaceFor(itemGUI.Item) >= itemGUI.SlotGUI.Amount;
		}
	}
}
