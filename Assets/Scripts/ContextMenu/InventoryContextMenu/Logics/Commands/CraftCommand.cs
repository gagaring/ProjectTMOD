using UnityEngine;
using VEngine.Crafting;
using VEngine.SO.Variables;

namespace VEngine.Inventory.GUI.Context
{
	[CreateAssetMenu(menuName = "SO/Inventory/GUI/Commands/CraftCommand")]
	public class CraftCommand : ItemCommandSO
	{
		[SerializeField] private BoolReference _isCraftingEnabled;
		[SerializeField] private InventoryItemGUIGameEvent _openCraftEvent;
		[SerializeField] private CombinatorSO _combinator;

		public override void Action(IInventoryItemGUI itemGUI)
		{
			_openCraftEvent.Raise(itemGUI);
		}

		public override bool Active(IInventoryItemGUI itemGUI)
		{
			return _combinator.Combinator.IsCraftMaterial(itemGUI.Item);
		}

		public override bool Enabled(IInventoryItemGUI itemGUI)
		{
			return _isCraftingEnabled.Value;
		}
	}
}
