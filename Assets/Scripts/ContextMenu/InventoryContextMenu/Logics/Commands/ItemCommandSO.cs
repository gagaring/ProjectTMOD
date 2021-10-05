using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Inventory.GUI.Context
{
	[CreateAssetMenu(menuName = "SO/Inventory/GUI/Commands/XYZ")]
	public abstract class ItemCommandSO : ScriptableObject, IItemCommand
	{
		[SerializeField] private StringReference _text;

		public string Text { get => _text.Value; }
		public abstract void Action(IInventoryItemGUI itemGUI);
		public abstract bool Active(IInventoryItemGUI itemGUI);
		public abstract bool Enabled(IInventoryItemGUI itemGUI);
	}

	public interface IItemCommand
	{
		string Text { get;  }
		void Action(IInventoryItemGUI itemGUI);
		bool Active(IInventoryItemGUI itemGUI);
		bool Enabled(IInventoryItemGUI itemGUI);
	}
}
