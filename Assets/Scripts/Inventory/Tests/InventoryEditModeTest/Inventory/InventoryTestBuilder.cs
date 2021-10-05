using System.Collections.Generic;
using UnityEngine;
using VEngine.Inventory;
using VEngine.SO.Variables;
using VEngine.SO.Events;
using NSubstitute;
using VEngine.Items;

namespace VTest.Inventory
{
    public class InventoryTestBuilder
    {
        private List<Item> _items = new List<Item>();
        private List<ItemSlot> _slots = new List<ItemSlot>();
        private List<VEngine.Inventory.Inventory> _inventorys = new List<VEngine.Inventory.Inventory>();
        private List<UIntReference> _maxInvCapacityRefs = new List<UIntReference>();
        private List<UIntReference> _availableInvCapacityRefs = new List<UIntReference>();
        private List<Connector> _connectors = new List<Connector>();
        private List<InventoryDataGameEvent> _gameEvents = new List<InventoryDataGameEvent>();
        private List<IGameEventListener<IInventoryData>> _gameEventListeners = new List<IGameEventListener<IInventoryData>>();

        public static InventoryTestBuilder Create() => new InventoryTestBuilder();

        public InventoryTestBuilder CreateItem(uint amount = 1)
        {
            for (uint i = 0; i < amount; ++i)
            {
                var item = ScriptableObject.CreateInstance<Item>();
                item.name = $"Item{i}";
                item.Details = new Details();
                var details = ScriptableObject.CreateInstance<InventoryItemComponent>();
                details.StackCount = 1;
                item.AddComponent(details);
                _items.Add(item);
            }
            return this;
        }

		private void AddComponent(Item item, InventoryItemComponent details)
        {
            item.AddComponent(details);
        }

		public Item GetItem(int index = 0) => _items[index];

        public InventoryTestBuilder SetStackCount(uint count, int index = 0)
        {
            var inventoryDetails = InventoryItemComponent.FindOn(_items[index]);
            inventoryDetails.StackCount = count;
            return this;
        }

        public InventoryTestBuilder CreateSlot(uint amount = 1u)
        {
            for (uint i = 0; i < amount; ++i)
            {
                 _slots.Add(new ItemSlot());
            }
            return this;
        }

        public ItemSlot GetSlot(int index = 0) => _slots[index];

        public InventoryTestBuilder AttachItemToSlot(uint amount = 1u, int slotIndex = 0, int itemIndex = 0)
        {
            _slots[slotIndex].SetItem(_items[itemIndex], ref amount);
            return this;
        }

        public VEngine.Inventory.Inventory GetInventory(int index = 0) => _inventorys[index];

        public InventoryTestBuilder CreateInventory()
        {
            var inventory = ScriptableObject.CreateInstance<VEngine.Inventory.Inventory>();
            _inventorys.Add(inventory);
            var maxCapacity = new UIntReference();
            _maxInvCapacityRefs.Add(maxCapacity);
            var availableCapacity = new UIntReference();
            _availableInvCapacityRefs.Add(availableCapacity);
            inventory.MaxCapacityRef = maxCapacity;
            inventory.AvailableCapacityRef = availableCapacity;
            var gameEvent = ScriptableObject.CreateInstance<InventoryDataGameEvent>();
            _gameEvents.Add(gameEvent);
            inventory.OnChangedEvent = gameEvent;
            var gameEventListener = Substitute.For<IGameEventListener<IInventoryData>>();
            gameEvent.RegisterListener(gameEventListener);
            _gameEventListeners.Add(gameEventListener);
            return this;
        }

        public InventoryTestBuilder SetInvMaxCapacity(uint capasity, int index = 0)
        {
            _maxInvCapacityRefs[index].Init(capasity);
            return this;
        }

        public InventoryTestBuilder SetInvAvailableCapacity(uint capasity, int index = 0)
        {
            _availableInvCapacityRefs[index].Init(capasity);
            return this;
        }

        public InventoryTestBuilder CreateConnector()
		{
            _connectors.Add(ScriptableObject.CreateInstance<Connector>());
            return this;
		}

        public Connector GetConnector(int index = 0) => _connectors[index];

        public InventoryDataGameEvent GetEvent(int index) => _gameEvents[index];
        public IGameEventListener<IInventoryData> GetEventListener(int index) => _gameEventListeners[index];

        public void Destroy()
        {
            foreach (var curr in _items)
                Object.DestroyImmediate(curr);
            foreach (var curr in _inventorys)
                Object.DestroyImmediate(curr);
            foreach (var curr in _gameEvents)
                Object.DestroyImmediate(curr);
            foreach (var curr in _connectors)
                Object.DestroyImmediate(curr);
        }
    }
}
