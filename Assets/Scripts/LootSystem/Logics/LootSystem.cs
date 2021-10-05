using VEngine.Inventory;
using VEngine.SO.Events;

namespace VEngine.LootSystem
{
    public class LootSystem : ILootSystem
    {
        private readonly IData _data;

        private ILootable _lootable;

        public LootSystem(IData data) => _data = data;

        public void OnLootableSelected(ILootable lootable)
        {
            _lootable = lootable;
        }

        public void PickUpLootable()
		{
            if (_lootable == null)
                return;
            if (!AddToinventory(_lootable))
            {
                _data.OnInventoryFull.Raise();
                return;
            }
            OnLootablePickedUp(_lootable);
        }

		private bool AddToinventory(ILootable lootable)
		{
            var remainingAmount = _lootable.CurrentAmount;
            _data.Inventory.Service.AddItem(_lootable.Item, ref remainingAmount);
            _lootable.CurrentAmount = remainingAmount;
            return remainingAmount == 0;
        }

		private void OnLootablePickedUp(ILootable lootable)
		{
            _data.DestoryLootableGameEvent.Raise(lootable);
        }

		public interface IData
        {
            IInventory Inventory { get; }
            IGameEvent OnInventoryFull { get; }
            IGameEvent<ILootable> DestoryLootableGameEvent { get; }
        }
    }
}
