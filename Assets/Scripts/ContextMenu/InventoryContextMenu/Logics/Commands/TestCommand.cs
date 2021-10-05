using UnityEngine;

namespace VEngine.Inventory.GUI.Context
{
	[CreateAssetMenu(menuName = "SO/Inventory/GUI/Commands/Test")]
	public class TestCommand : ItemCommandSO
	{
		[SerializeField] private bool _active;
		[SerializeField] private bool _enabled;

		public override void Action(IInventoryItemGUI itemGUI)
		{
			Debug.Log("Action");
		}

		public override bool Active(IInventoryItemGUI itemGUI) => _active;
		public override bool Enabled(IInventoryItemGUI itemGUI) => _enabled;
	}
}
