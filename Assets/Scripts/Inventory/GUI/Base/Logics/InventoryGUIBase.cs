using System.Collections.Generic;
using VEngine.GUI;

namespace VEngine.Inventory.GUI
{
	public abstract class InventoryGUIBase : Panel, IInventoryGUI
	{
		protected readonly IInventoryGUIData _inventoryData;

		protected readonly List<ISlotGUI> _slotGUIs = new List<ISlotGUI>();

		public List<ISlotGUI> SlotGUIs { get => _slotGUIs; }

		protected IInventoryData InventoryData { get => _inventoryData.Inventory.Data; }
		protected IInventoryService InventoryService { get => _inventoryData.Inventory.Service; }

		public InventoryGUIBase(IInventoryGUIData data) : base(data)
		{
			_inventoryData = data;
		}

		public void AddSlotGUIs(IReadOnlyList<ISlotGUI> slotGUIs)
		{
			_slotGUIs.AddRange(slotGUIs);
		}

		protected override void OnWindowOpened(bool opened)
		{
			base.OnWindowOpened(opened);
			if (!opened)
				return;
			Refresh();
		}

		public void Refresh()
		{
			_inventoryData.Builder.RefreshGUISlots(InventoryData, _slotGUIs);
		}

		public interface IInventoryGUIData : IPanelData
		{
			IInventory Inventory { get; }
			IInventoryGUIBuilder Builder { get; }
		}
	}
}
