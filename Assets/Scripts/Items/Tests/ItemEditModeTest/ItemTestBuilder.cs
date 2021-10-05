using System.Collections.Generic;
using UnityEngine;
using VEngine.Inventory;
using VEngine.Items;

namespace VTest.Items
{
	public class ItemTestBuilder
	{
		private List<Item> _items = new List<Item>();

		public static ItemTestBuilder Create() => new ItemTestBuilder();

        public ItemTestBuilder CreateItem(uint amount = 1)
        {
            for (uint i = 0; i < amount; ++i)
            {
                var item = ScriptableObject.CreateInstance<Item>();
                item.name = $"Item{i}";
                var inventoryDetails = ScriptableObject.CreateInstance<InventoryItemComponent>();

                item.AddComponent(inventoryDetails);

                _items.Add(item);
            }
            return this;
        }

        public Item GetItem(int index = 0) => _items[index];

        public ItemTestBuilder SetStackable(bool stackable, int index = 0)
        {
            var inventoryDetails = InventoryItemComponent.FindOn(_items[index]);
            inventoryDetails.StackCount = stackable ? 1u : 2u;
            return this;
        }

        public ItemTestBuilder SetStackCount(uint count, int index = 0)
        {
            var inventoryDetails = InventoryItemComponent.FindOn(_items[index]);
            inventoryDetails.StackCount = count;
            return this;
        }
    }
}
