using NUnit.Framework;
using VEngine.Inventory;

namespace VTest.Items
{
    public class ItemTest
    {
        [Test]
        public void is_stackcount_1_if_isnt_stackable()
        {
            var item = ItemTestBuilder.Create().CreateItem().GetItem();
            var inventoryDetails = InventoryItemComponent.FindOn(item);
            Assert.IsFalse(inventoryDetails.IsStackable);
            Assert.AreEqual(1, inventoryDetails.StackCount);
        }

        [Test]
        public void is_stackcount_1_if_stackable_and_stackCount_set_to_0()
        {
            var item = ItemTestBuilder.Create().CreateItem().SetStackable(true).SetStackCount(0).GetItem();
            var inventoryDetails = InventoryItemComponent.FindOn(item);
            Assert.IsFalse(inventoryDetails.IsStackable);
            Assert.AreEqual(1, inventoryDetails.StackCount);
        }

        [Test]
        public void is_stackcount_10_if_stackable_and_stackCount_set_to_10()
        {
            var item = ItemTestBuilder.Create().CreateItem().SetStackable(true).SetStackCount(10).GetItem();
            var inventoryDetails = InventoryItemComponent.FindOn(item);
            Assert.IsTrue(inventoryDetails.IsStackable);
            Assert.AreEqual(10, inventoryDetails.StackCount);
        }

        [Test]
        public void is_stackcount_1000_if_stackable_and_stackCount_set_to_1000()
        {
            var item = ItemTestBuilder.Create().CreateItem().SetStackable(true).SetStackCount(1000).GetItem();
            var inventoryDetails = InventoryItemComponent.FindOn(item);
            Assert.IsTrue(inventoryDetails.IsStackable);
            Assert.AreEqual(1000, inventoryDetails.StackCount);
        }
    }
}
