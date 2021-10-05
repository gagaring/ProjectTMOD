using UnityEngine;
using VEngine.LockAndKey;

namespace VEngine.Inventory.GUI.Context
{
	[CreateAssetMenu(menuName = "SO/Inventory/GUI/Commands/UnlockCommand")]
	public class UnlockCommand : ItemCommandSO
	{
		[SerializeField] private ItemLockSystemSO _system;

		public override void Action(IInventoryItemGUI itemGUI)
		{
			_system.Use(itemGUI.Item);
		}

		public override bool Active(IInventoryItemGUI itemGUI)
		{
			return itemGUI.Item.Find(typeof(KeyComponent)) != null;
		}

		public override bool Enabled(IInventoryItemGUI itemGUI)
		{
			return _system.CanUse(itemGUI.Item);
		}
	}
}