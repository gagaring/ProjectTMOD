using UnityEngine;
using VEngine.Items;
using VEngine.Artifacts;

namespace VEngine.Inventory.GUI.Context
{
	[CreateAssetMenu(menuName = "SO/Inventory/GUI/Commands/UseCommand")]
	public class UseCommand : ItemCommandSO
	{
		[SerializeField] private ItemGameEvent _useItemGameEvent;

		public override void Action(IInventoryItemGUI itemGUI)
		{
			_useItemGameEvent.Raise(itemGUI.Item);
		}

		public override bool Active(IInventoryItemGUI itemGUI)
		{
			return itemGUI.Item.Find(typeof(UseComponent)) != null;
		}

		public override bool Enabled(IInventoryItemGUI itemGUI)
		{
			return itemGUI.Item.Find(typeof(UseComponent)) != null;
		}
	}
}
