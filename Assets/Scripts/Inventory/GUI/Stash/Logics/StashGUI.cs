using UnityEngine;

namespace VEngine.Inventory.GUI.Stash
{
	public class StashGUI : InventoryGUI
	{
		private readonly IStashData _stashData;

		public StashGUI(IStashData data) : base(data)
		{
			_stashData = data;
		}

		public interface IStashData : IInventoryGUIData
		{
			GameObject AvailableTitle { get; }
			bool IsStashEnabled { get; }
			GameObject NotAvailableTitle { get; }
		}
	}
}
