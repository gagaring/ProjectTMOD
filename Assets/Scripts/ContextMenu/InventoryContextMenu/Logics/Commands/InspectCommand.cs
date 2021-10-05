using UnityEngine;
using VEngine.Inspector;
using VEngine.Items;
using VEngine.SO.Events;

namespace VEngine.Inventory.GUI.Context
{
	[CreateAssetMenu(menuName = "SO/Inventory/GUI/Commands/InspectCommand")]
	public class InspectCommand : ItemCommandSO
	{
		[SerializeField] private ItemGameEvent _setInspectableObject;
		[SerializeField] private BoolGameEvent _openInspector;

		public override void Action(IInventoryItemGUI itemGUI)
		{
			_setInspectableObject.Raise(itemGUI.Item);
			_openInspector.Raise(true);
		}

		public override bool Active(IInventoryItemGUI itemGUI)
		{
			return itemGUI.Item.Find(typeof(InspectItemComponent)) != null;
		}

		public override bool Enabled(IInventoryItemGUI itemGUI)
		{
			return itemGUI.Item.Find(typeof(InspectItemComponent)) != null;
		}
	}
}
