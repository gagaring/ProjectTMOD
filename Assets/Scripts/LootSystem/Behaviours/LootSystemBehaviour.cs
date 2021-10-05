using UnityEngine;
using VEngine.Inventory;
using VEngine.LootSystem.Destoryer;
using VEngine.SO.Events;

namespace VEngine.LootSystem
{
    public class LootSystemBehaviour : MonoBehaviour, LootSystem.IData
	{
		[SerializeField] private GlobalInventories _inventories;
		[SerializeField] private GameEvent _onInventoryFull;
		[SerializeField] private LootableGameEvent _destoryLootableGameEvent;

		private ILootSystem _lootSystem;

		public IInventory Inventory => _inventories.PlayerInventory;
		public IGameEvent OnInventoryFull => _onInventoryFull;
		public IGameEvent<ILootable> DestoryLootableGameEvent => _destoryLootableGameEvent;

		private void Awake() => _lootSystem = new LootSystem(this);

		public void OnLootableSelected(ILootable lootable) => _lootSystem.OnLootableSelected(lootable);
		public void Loot() => _lootSystem.PickUpLootable();
	}
}
