using UnityEngine;
using VEngine.GUI;

namespace VEngine.Inventory.GUI
{
    public class InventoryGUIBehaviour : PanelBehaviour, InventoryGUIBase.IInventoryGUIData
	{
		[SerializeField] private InventoryReference _inventory;
		[SerializeField] private SlotsGUIBehaviourContainer _slotsGUIBehaviourContainer;
		[SerializeField] private WindowOpenedGameEvent _onWindowOpened;

		[SerializeField] private Transform _slotParent;
		[SerializeField] private SlotGUIBehaviour _slotPrefab;

		public SlotGUIBehaviour SlotPrefab => _slotPrefab;
		public Transform SlotParent => _slotParent;
		public IInventory Inventory => _inventory.Inventory;
		public IInventoryGUIBuilder Builder { get; private set; }
		public SlotsGUIBehaviourContainer SlotsGUIBehaviourContainer => _slotsGUIBehaviourContainer;

		private InventoryGUI InventoryGUI => (InventoryGUI)Panel;

		protected override void Awake()
		{
			base.Awake();
			SlotsGUIBehaviourContainer.Clear();
			Builder = CreateBuilder();
			Builder.CreateGUISlots(Inventory.Data, InventoryGUI, SlotsGUIBehaviourContainer, SlotParent);
			InventoryGUI.AddSlotGUIs(SlotsGUIBehaviourContainer.SlotGUIs);
			InventoryGUI.Refresh();
		}

		public void Refresh() => InventoryGUI.Refresh();

		protected virtual InventoryGUIBuilder CreateBuilder() => new InventoryGUIBuilder(SlotPrefab);
		protected override IPanel CreatePanel() => new InventoryGUI(this);

		private void OnDestroy() => SlotsGUIBehaviourContainer.Clear();
	}
}
