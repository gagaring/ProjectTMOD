using NSubstitute;
using NUnit.Framework;

namespace VTest.Inventory
{
    public class InventoryTest
    {
        #region additem (first)
        [Test]
        public void can_add_1_stackable_item_with_10_stackcount_to_inventory_if_max_capacitiy_is_1_and_available_capacitiy_is_1_and_it_has_no_item_after_remains_0()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem();
            var amount = 1u;
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(1, inventory.Slots[0].Amount);
            Assert.AreEqual(0, amount);

            builder.Destroy();
        }

        [Test]
        public void can_add_10_stackable_item_with_10_stackcount_to_inventory_if_max_capacitiy_is_1_and_available_capacitiy_is_1_and_it_has_no_item_after_remains_0()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem();
            var amount = 10u;
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(10, inventory.Slots[0].Amount);
            Assert.AreEqual(0, amount);

            builder.Destroy();
        }

        [Test]
        public void can_add_11_stackable_item_with_10_stackcount_to_inventory_if_max_capacitiy_is_1_and_available_capacitiy_is_1_and_it_has_no_item_after_remains_1()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem();
            var amount = 11u;
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(10, inventory.Slots[0].Amount);
            Assert.AreEqual(1, amount);

            builder.Destroy();
        }

        [Test]
        public void can_add_11_stackable_item_with_10_stackcount_to_inventory_if_max_capacitiy_is_2_and_available_capacitiy_is_1_and_it_has_no_item_after_remains_1()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem();
            var amount = 11u;
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.IsFalse(inventory.IsSlotAvailable(1));
            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(10, inventory.Slots[0].Amount);
            Assert.AreEqual(1, amount);

            builder.Destroy();
        }

        [Test]
        public void can_add_11_stackable_item_with_10_stackcount_to_inventory_if_max_capacitiy_is_2_and_available_capacitiy_is_2_and_it_has_no_item_after_remains_0()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem();
            var amount = 11u;
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.IsTrue(inventory.IsSlotAvailable(1));
            Assert.IsFalse(inventory.IsSlotFree(1));
            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(item1, inventory.Slots[1].Item);
            Assert.AreEqual(10, inventory.Slots[0].Amount);
            Assert.AreEqual(1, inventory.Slots[1].Amount);
            Assert.AreEqual(0, amount);

            builder.Destroy();
        }

        [Test]
        public void can_add_20_stackable_item_with_10_stackcount_to_inventory_if_max_capacitiy_is_2_and_available_capacitiy_is_2_and_it_has_no_item_after_remains_0()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem();
            var amount = 20u;
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.IsTrue(inventory.IsSlotAvailable(1));
            Assert.IsFalse(inventory.IsSlotFree(1));
            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(item1, inventory.Slots[1].Item);
            Assert.AreEqual(10, inventory.Slots[0].Amount);
            Assert.AreEqual(10, inventory.Slots[1].Amount);
            Assert.AreEqual(0, amount);

            builder.Destroy();
        }

        [Test]
        public void can_add_21_stackable_item_with_10_stackcount_to_inventory_if_max_capacitiy_is_2_and_available_capacitiy_is_2_and_it_has_no_item_after_remains_1()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem();
            var amount = 21u;
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.IsTrue(inventory.IsSlotAvailable(1));
            Assert.IsFalse(inventory.IsSlotFree(1));
            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(item1, inventory.Slots[1].Item);
            Assert.AreEqual(10, inventory.Slots[0].Amount);
            Assert.AreEqual(10, inventory.Slots[1].Amount);
            Assert.AreEqual(1, amount);

            builder.Destroy();
        }

        [Test]
        public void can_add_221_stackable_item_with_10_stackcount_to_inventory_if_max_capacitiy_is_22_and_available_capacitiy_is_22_and_it_has_no_item_after_remains_1()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(22).SetInvAvailableCapacity(22);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem();
            var amount = 221u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(1, amount);

            builder.Destroy();
        }

        [Test]
        public void cant_add_1_stackable_item_with_10_stackcount_to_inventory_if_max_capacitiy_is_1_and_available_capacitiy_is_1_and_it_has_1_item()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var item2 = builder.CreateItem().SetStackCount(10, 1).GetItem(1);
            var amount = 1u;
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));

            amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.AddItem(item2, ref amount));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);


            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(1, inventory.Slots[0].Amount);
            Assert.AreEqual(1, amount);

            builder.Destroy();
        }

        [Test]
        public void cant_add_1_stackable_item_with_10_stackcount_to_inventory_if_max_capacitiy_is_2_and_available_capacitiy_is_1_and_it_has_1_item()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var item2 = builder.CreateItem().SetStackCount(10, 1).GetItem(1);
            var amount = 1u;
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));

            amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.AddItem(item2, ref amount));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);


            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(1, inventory.Slots[0].Amount);
            Assert.AreEqual(1, amount);

            builder.Destroy();
        }

        [Test]
        public void can_add_1_stackable_item_with_10_stackcount_to_inventory_if_max_capacitiy_is_2_and_available_capacitiy_is_2_and_it_has_1_item_after_remains_0()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var item2 = builder.CreateItem().SetStackCount(10, 1).GetItem(1);
            var amount = 1u;
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.IsTrue(inventory.IsSlotFree(1));

            amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item2, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(1, inventory.Slots[0].Amount);

            Assert.AreEqual(item2, inventory.Slots[1].Item);
            Assert.AreEqual(1, inventory.Slots[1].Amount);
            Assert.AreEqual(0, amount);

            builder.Destroy();
        }

        [Test]
        public void can_add_10_stackable_item_with_10_stackcount_to_inventory_if_max_capacitiy_is_2_and_available_capacitiy_is_2_and_it_has_1_item_after_remains_0()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var item2 = builder.CreateItem().SetStackCount(10, 1).GetItem(1);
            var amount = 1u;
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.IsTrue(inventory.IsSlotFree(1));

            amount = 10u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item2, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(item2, inventory.Slots[1].Item);
            Assert.AreEqual(10, inventory.Slots[1].Amount);
            Assert.AreEqual(0, amount);

            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(1, inventory.Slots[0].Amount);

            builder.Destroy();
        }

        [Test]
        public void can_add_11_stackable_item_with_10_stackcount_to_inventory_if_max_capacitiy_is_2_and_available_capacitiy_is_2_and_it_has_1_item_after_remains_1()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var item2 = builder.CreateItem().SetStackCount(10, 1).GetItem(1);
            var amount = 1u;
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.IsTrue(inventory.IsSlotFree(1));

            amount = 11u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item2, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(item2, inventory.Slots[1].Item);
            Assert.AreEqual(10, inventory.Slots[1].Amount);
            Assert.AreEqual(1, amount);

            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(1, inventory.Slots[0].Amount);

            builder.Destroy();
        }

        [Test]
        public void can_add_1_not_stackable_item_to_inventory_if_max_capacitiy_is_1_and_available_capacitiy_is_1_and_it_has_no_item_after_remains_0()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var amount = 1u;
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(1, inventory.Slots[0].Amount);
            Assert.AreEqual(0, amount);

            builder.Destroy();
        }
        #endregion

        #region additem to slot
        [Test]
        public void cant_add_other_item_to_slot_if_it_is_not_free_and_inventory_max_capacity_is_1_and_available_capacity_is_1()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var item2 = builder.CreateItem().SetStackCount(10, 1).GetItem(1);
            var amount = 1u;
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.AreEqual(item1, inventory.Slots[0].Item);

            amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.AddItem(item2, 0, ref amount));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(1, inventory.Slots[0].Amount);
            Assert.AreEqual(1, amount);

            builder.Destroy();
        }

        [Test]
        public void cant_add_other_item_to_slot_if_it_is_not_free_and_inventory_max_capacity_is_2_and_available_capacity_is_2()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var item2 = builder.CreateItem().SetStackCount(10, 1).GetItem(1);
            var amount = 1u;
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.AreEqual(item1, inventory.Slots[0].Item);

            amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.AddItem(item2, 0, ref amount));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(1, inventory.Slots[0].Amount);
            Assert.AreEqual(1, amount);

            builder.Destroy();
        }

        [Test]
        public void can_add_1_item_to_slot_if_it_is_not_free_but_same_item_with_1_amount_and_its_stackable_with_10_stackcount_and_inventory_max_capacity_is_1_and_available_capacity_is_1_after_remains_0()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var amount = 1u;
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.AreEqual(item1, inventory.Slots[0].Item);

            amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(2, inventory.Slots[0].Amount);
            Assert.AreEqual(0, amount);

            builder.Destroy();
        }

        [Test]
        public void can_add_1_item_to_slot_if_it_is_not_free_but_same_item_with_9_amount_and_its_stackable_with_10_stackcount_and_inventory_max_capacity_is_1_and_available_capacity_is_1_after_remains_0()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var amount = 9u;
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.AreEqual(item1, inventory.Slots[0].Item);

            amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(10, inventory.Slots[0].Amount);
            Assert.AreEqual(0, amount);

            builder.Destroy();
        }

        [Test]
        public void can_add_2_item_to_slot_if_it_is_not_free_but_same_item_with_9_amount_and_its_stackable_with_10_stackcount_and_inventory_max_capacity_is_1_and_available_capacity_is_1_after_remains_1()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var amount = 9u;
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.AreEqual(item1, inventory.Slots[0].Item);

            amount = 2u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(10, inventory.Slots[0].Amount);
            Assert.AreEqual(1, amount);

            builder.Destroy();
        }

        [Test]
        public void can_add_2_item_to_slot_if_it_is_not_free_but_same_item_with_9_amount_and_its_stackable_with_10_stackcount_and_inventory_max_capacity_is_2_and_available_capacity_is_2_after_remains_1_and_slot_2_is_still_free()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var amount = 9u;
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.AreEqual(item1, inventory.Slots[0].Item);

            amount = 2u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(10, inventory.Slots[0].Amount);
            Assert.AreEqual(1, amount);
            Assert.IsTrue(inventory.IsSlotFree(1));

            builder.Destroy();
        }

        [Test]
        public void cant_add_1_item_to_slot_if_it_is_not_free_but_same_item_with_10_amount_and_its_stackable_with_10_stackcount_and_inventory_max_capacity_is_2_and_available_capacity_is_2_after_remains_1_and_slot_2_is_still_free()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var amount = 10u;
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.AreEqual(item1, inventory.Slots[0].Item);

            amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(10, inventory.Slots[0].Amount);
            Assert.AreEqual(1, amount);
            Assert.IsTrue(inventory.IsSlotFree(1));

            builder.Destroy();
        }

        [Test]
        public void cant_add_1_item_to_slot_if_it_is_not_free_but_same_item_but_it_not_stackable_and_inventory_max_capacity_is_2_and_available_capacity_is_2_after_remains_1_and_slot_2_is_still_free()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            var amount = 1u;
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.AreEqual(item1, inventory.Slots[0].Item);

            amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(1, inventory.Slots[0].Amount);
            Assert.AreEqual(1, amount);
            Assert.IsTrue(inventory.IsSlotFree(1));

            builder.Destroy();
        }

        [Test]
        public void can_add_1_item_to_slot_if_slot_is_free_and_item_is_stackable_with_10_stackcount_after_remains_0()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var amount = 1u;
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(1, inventory.Slots[0].Amount);
            Assert.AreEqual(0, amount);

            builder.Destroy();
        }

        [Test]
        public void can_add_10_item_to_slot_if_slot_is_free_and_item_is_stackable_with_10_stackcount_after_remains_0()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var amount = 10u;
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(10, inventory.Slots[0].Amount);
            Assert.AreEqual(0, amount);

            builder.Destroy();
        }

        [Test]
        public void can_add_11_item_to_slot_if_slot_is_free_and_item_is_stackable_with_10_stackcount_and_inventorys_max_capacitiy_is_1_and_available_capacity_is_1_after_remains_1()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var amount = 11u;
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(10, inventory.Slots[0].Amount);
            Assert.AreEqual(1, amount);

            builder.Destroy();
        }

        [Test]
        public void can_add_11_item_to_slot_if_slot_is_free_and_item_is_stackable_with_10_stackcount_and_inventorys_max_capacitiy_is_2_and_available_capacity_is_2_after_remains_1_and_slot_2_is_still_free()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var amount = 11u;
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(10, inventory.Slots[0].Amount);
            Assert.AreEqual(1, amount);
            Assert.IsTrue(inventory.IsSlotFree(1));

            builder.Destroy();
        }

        [Test]
        public void can_add_1_item_to_slot_if_slot_is_free_and_item_isnt_stackable_and_inventorys_max_capacitiy_is_1_and_available_capacity_is_1_after_remains_0()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            var amount = 1u;
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(1, inventory.Slots[0].Amount);
            Assert.AreEqual(0, amount);

            builder.Destroy();
        }

        [Test]
        public void can_add_2_item_to_slot_if_slot_is_free_and_item_isnt_stackable_and_inventorys_max_capacitiy_is_1_and_available_capacity_is_1_after_remains_1()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            var amount = 2u;
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(1, inventory.Slots[0].Amount);
            Assert.AreEqual(1, amount);

            builder.Destroy();
        }

        [Test]
        public void can_add_2_item_to_slot_if_slot_is_free_and_item_isnt_stackable_and_inventorys_max_capacitiy_is_2_and_available_capacity_is_2_after_remains_1_and_slot_2_is_still_free()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            var amount = 2u;
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(1, inventory.Slots[0].Amount);
            Assert.AreEqual(1, amount);
            Assert.IsTrue(inventory.IsSlotFree(1));

            builder.Destroy();
        }
        #endregion

        #region Contains amount
        [Test]
        public void inventory_is_not_contains_item_if_it_is_empty()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.Contains(item1, 1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void inventory_is_not_contains_item1_if_item2_was_added_to_inventory_and_inventorys_max_capacity_is_1_and_available_capacity_is_1()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            var item2 = builder.CreateItem().GetItem(1);
            Assert.IsTrue(inventory.IsSlotFree(0));
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item2, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.Contains(item1, 1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void inventory_is_not_contains_item1_if_item2_was_added_to_inventory_and_inventorys_max_capacity_is_2_and_available_capacity_is_2()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            var item2 = builder.CreateItem().GetItem(1);
            Assert.IsTrue(inventory.IsSlotFree(0));
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item2, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.Contains(item1, 1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void inventory_is_contains_1_item1_if_inventory_has_1_item1()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            Assert.IsTrue(inventory.IsSlotFree(0));
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(0u, amount);
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.Contains(item1, 1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void inventory_is_contains_10_item1_if_inventory_has_10_item1_if_item_is_not_stackable()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(10).SetInvAvailableCapacity(10);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            Assert.IsTrue(inventory.IsSlotFree(0));
            var amount = 10u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(0u, amount);
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.Contains(item1, 10));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void inventory_is_contains_10_item1_if_inventory_has_10_item1_if_item_is_stackable_with_10_stackcount()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(10).SetInvAvailableCapacity(10);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            Assert.IsTrue(inventory.IsSlotFree(0));
            var amount = 10u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(0u, amount);
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.Contains(item1, 10));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void inventory_is_contains_100_item1_if_inventory_has_100_item1_if_item_is_stackable_with_10_stackcount()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(10).SetInvAvailableCapacity(10);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            Assert.IsTrue(inventory.IsSlotFree(0));
            var amount = 100u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(0u, amount);
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.Contains(item1, 100));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void inventory_is_not_contains_101_item1_if_inventory_has_100_item1_if_item_is_stackable_with_10_stackcount()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(10).SetInvAvailableCapacity(10);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            Assert.IsTrue(inventory.IsSlotFree(0));
            var amount = 101u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(1u, amount);
            Assert.IsFalse(inventory.Contains(item1, 101));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.Contains(item1, 100));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }
        #endregion

        #region Contain
        [Test]
        public void inventory_contains_0_item1_if_inventory_is_empty_with_10_stackcount()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(10).SetInvAvailableCapacity(10);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(0u, inventory.Contains(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void inventory_contains_10_item1_if_10_items_were_added_with_10_stackcount()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(10).SetInvAvailableCapacity(10);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var times = 1;
            var amount = 5u;
            for (int i = 0; i < times; ++i)
            {
                var addAmount = amount;
                builder.GetEventListener(0).ClearReceivedCalls();
                Assert.IsTrue(inventory.AddItem(item1, ref addAmount));
                builder.GetEventListener(0).Received().OnEventRaised(inventory);
            }
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(times * amount, inventory.Contains(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void inventory_contains_20_item1_if_10_items_were_added_twice_with_10_stackcount()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(10).SetInvAvailableCapacity(10);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var times = 2;
            var amount = 10u;
            for (int i = 0; i < times; ++i)
            {
                var addAmount = amount;
                builder.GetEventListener(0).ClearReceivedCalls();
                Assert.IsTrue(inventory.AddItem(item1, ref addAmount));
                builder.GetEventListener(0).Received().OnEventRaised(inventory);

            }
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(times * amount, inventory.Contains(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void inventory_contains_50_item1_if_5_items_were_added_10_times_with_10_stackcount()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(10).SetInvAvailableCapacity(10);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var times = 10;
            var amount = 5u;
            for (int i = 0; i < times; ++i)
            {
                var addAmount = amount;
                builder.GetEventListener(0).ClearReceivedCalls();
                Assert.IsTrue(inventory.AddItem(item1, ref addAmount));
                builder.GetEventListener(0).Received().OnEventRaised(inventory);
            }
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(times * amount, inventory.Contains(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void inventory_contains_0_item1_if_inventory_is_empty_with_not_stackable()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(10).SetInvAvailableCapacity(10);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(0u, inventory.Contains(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void inventory_contains_10_item1_if_10_items_were_added_with_not_stackable()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(10).SetInvAvailableCapacity(10);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            var times = 10;
            var amount = 1u;
            for (int i = 0; i < times; ++i)
            {
                var addAmount = amount;
                builder.GetEventListener(0).ClearReceivedCalls();
                Assert.IsTrue(inventory.AddItem(item1, ref addAmount));
                builder.GetEventListener(0).Received().OnEventRaised(inventory);
            }
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(times * amount, inventory.Contains(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void inventory_contains_20_item1_if_10_items_were_added_twice_with_not_stackable()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(100).SetInvAvailableCapacity(100);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            var times = 2;
            var amount = 10u;
            for (int i = 0; i < times; ++i)
            {
                var addAmount = amount;
                builder.GetEventListener(0).ClearReceivedCalls();
                Assert.IsTrue(inventory.AddItem(item1, ref addAmount));
                builder.GetEventListener(0).Received().OnEventRaised(inventory);
            }
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(times * amount, inventory.Contains(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void inventory_contains_50_item1_if_5_items_were_added_10_times_with_not_stackable()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(100).SetInvAvailableCapacity(100);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            var times = 10;
            var amount = 5u;
            for (int i = 0; i < times; ++i)
            {
                var addAmount = amount;
                builder.GetEventListener(0).ClearReceivedCalls();
                Assert.IsTrue(inventory.AddItem(item1, ref addAmount));
                builder.GetEventListener(0).Received().OnEventRaised(inventory);
            }
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(times * amount, inventory.Contains(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }
        #endregion

        #region MoveItem
        [Test]
        public void can_not_move___item_from_0_to_1_slot_if_max_capacity_is_1_and_available_capacity_is_1_and_from_slot_has_item()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.MoveItem(0, 1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void can_not_move___item_from_0_to_1_slot_if_max_capacity_is_1_and_available_capacity_is_1_and_from_slot_is_free()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.MoveItem(0, 1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void can_not_move___item_from_0_to_1_slot_if_max_capacity_is_2_and_available_capacity_is_1()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.MoveItem(0, 1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);
        }

        [Test]
        public void can_not_move___item_from_0_to_1_slot_if_max_capacity_is_2_and_available_capacity_is_2_but_both_slots_are_free()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.MoveItem(0, 1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void can_not_move___item_from_0_to_1_slot_if_max_capacity_is_2_and_available_capacity_is_2_and___from_slot_is_free()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);
            Assert.IsTrue(inventory.IsSlotFree(0));
            Assert.IsFalse(inventory.IsSlotFree(1));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.MoveItem(0, 1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void can_not_move___item_from_0_to_1_slot_if_max_capacity_is_2_and_available_capacity_is_2_and___to_slot_has_1_not_stackable_item()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);
            Assert.IsTrue(inventory.IsSlotFree(0));
            Assert.IsFalse(inventory.IsSlotFree(1));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.MoveItem(0, 1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void can_not_move___item_from_0_to_1_slot_if_max_capacity_is_2_and_available_capacity_is_2_and__to_slot_has_1_stackable_item_with_10_stackcount()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);
            Assert.IsTrue(inventory.IsSlotFree(0));
            Assert.IsFalse(inventory.IsSlotFree(1));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.MoveItem(0, 1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void can_not_move___1___item_from_0_to_1_slot_if_max_capacity_is_2_and_available_capacity_is_2_and___to_slot_has_1_stackable_item_with_10_stackcount()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);
            Assert.IsTrue(inventory.IsSlotFree(0));
            Assert.IsFalse(inventory.IsSlotFree(1));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.MoveItem(0, 1, 1u));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);
            Assert.IsTrue(inventory.IsSlotFree(0));

            builder.Destroy();
        }

        [Test]
        public void can_move___item_from_0_to_1_slot_if_max_capacity_is_2_and_available_capacity_is_2_and___from_slot_has_1_not_stackable_item()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);
            Assert.IsFalse(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.MoveItem(0, 1));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);
            Assert.IsTrue(inventory.IsSlotFree(0));

            builder.Destroy();
        }

        [Test]
        public void can_move___item_from_0_to_1_slot_if_max_capacity_is_2_and_available_capacity_is_2_and___from_slot_has_1_stackable_item_with_10_stackcount()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);
            Assert.IsFalse(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.MoveItem(0, 1));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);
            Assert.IsTrue(inventory.IsSlotFree(0));

            builder.Destroy();
        }

        [Test]
        public void can_move___1___item_from_0_to_1_slot_if_max_capacity_is_2_and_available_capacity_is_2_and___from_slot_has_1_stackable_item_with_10_stackcount()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);
            Assert.IsFalse(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.MoveItem(0, 1, 1u));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsTrue(inventory.IsSlotFree(0));

            builder.Destroy();
        }

        [Test]
        public void can_move___2___item_from_0_to_1_slot_if_max_capacity_is_2_and_available_capacity_is_2_and___to_slot_has_1_stackable_item_with_10_stackcount()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.MoveItem(0, 1, 2u));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsTrue(inventory.IsSlotFree(0));

            builder.Destroy();
        }

        [Test]
        public void can_move___item_from_0_to_1_slot_if_max_capacity_is_2_and_available_capacity_is_2_and___both_slots_have_item_but_not_same()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            var item2 = builder.CreateItem().GetItem(1);
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item2, 1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.MoveItem(0, 1));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(item1, inventory.Slots[1].Item);
            Assert.AreEqual(item2, inventory.Slots[0].Item);

            builder.Destroy();
        }

        [Test]
        public void can_move___1___item_from_0_to_1_slot_if_max_capacity_is_2_and_available_capacity_is_2_and___both_slots_have_item_but_not_same()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            var item2 = builder.CreateItem().GetItem(1);
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item2, 1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.MoveItem(0, 1, 1u));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(item1, inventory.Slots[1].Item);
            Assert.AreEqual(item2, inventory.Slots[0].Item);

            builder.Destroy();
        }


        [Test]
        public void can_move___10___item_from_0_to_1_slot_if_max_capacity_is_2_and_available_capacity_is_2_and___both_slots_have_item_but_not_same()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            var item2 = builder.CreateItem().GetItem(1);
            var amount = 10u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item2, 1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.MoveItem(0, 1, 10u));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(item1, inventory.Slots[1].Item);
            Assert.AreEqual(item2, inventory.Slots[0].Item);

            builder.Destroy();
        }

        [Test]
        public void can___not_move___2___item_from_0_to_1_slot_if_max_capacity_is_2_and_available_capacity_is_2_and___both_slots_have_not_stackable_item_but_not_same_and_from_slots_amount_is_only_1()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            var item2 = builder.CreateItem().GetItem(1);
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item2, 1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.MoveItem(0, 1, 2u));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            Assert.AreEqual(item2, inventory.Slots[1].Item);
            Assert.AreEqual(item1, inventory.Slots[0].Item);

            builder.Destroy();
        }

        [Test]
        public void can___not_move___2___item_from_0_to_1_slot_if_max_capacity_is_2_and_available_capacity_is_2_and___both_slots_have_stackable_item_with_10_stackcount_but_not_same_and_from_slots_amount_is_only_1()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var item2 = builder.CreateItem().SetStackCount(10, 1).GetItem(1);
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item2, 1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.MoveItem(0, 1, 2u));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            Assert.AreEqual(item2, inventory.Slots[1].Item);
            Assert.AreEqual(item1, inventory.Slots[0].Item);

            builder.Destroy();
        }

        [Test]
        public void can_not_move___item_from_0_to_1_slot_if_max_capacity_is_2_and_available_capacity_is_2_and___both_slots_have_same_not_stackable_item()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.MoveItem(0, 1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void can_move___item_from_0_to_1_slot_if_max_capacity_is_2_and_available_capacity_is_2_and___both_slots_have_same_stackable_item_with_10_stackcount_and_from_slot_has_1_item_and_to_slot_has_1_item___after_from_slot_is_free()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.MoveItem(0, 1));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsTrue(inventory.IsSlotFree(0));

            builder.Destroy();
        }

        [Test]
        public void can_move___1___item_from_0_to_1_slot_if_max_capacity_is_2_and_available_capacity_is_2_and___both_slots_have_same_stackable_item_with_10_stackcount_and_from_slot_has_1_item_and_to_slot_has_1_item___after_from_slot_is_free_and_to_slot_has_2_item()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.MoveItem(0, 1, 1u));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(2, inventory.Slots[1].Amount);

            builder.Destroy();
        }

        [Test]
        public void can_move___2___item_from_0_to_1_slot_if_max_capacity_is_2_and_available_capacity_is_2_and___both_slots_have_same_stackable_item_with_10_stackcount_and_from_slot_has_1_item_and_to_slot_has_1_item___after_from_slot_is_free_and_to_slot_has_2_item()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.MoveItem(0, 1, 2u));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(2, inventory.Slots[1].Amount);

            builder.Destroy();
        }

        [Test]
        public void can_move___2___item_from_0_to_1_slot_if_max_capacity_is_2_and_available_capacity_is_2_and___both_slots_have_same_stackable_item_with_10_stackcount_and_from_slot_has_2_item_and_to_slot_has_8_item___after_from_slot_is_free_and_to_slot_has_10_amount()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var amount = 2u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            amount = 8u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.MoveItem(0, 1, 2u));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(10, inventory.Slots[1].Amount);
            Assert.IsTrue(inventory.IsSlotFree(0));

            builder.Destroy();
        }

        [Test]
        public void can_move___3___item_from_0_to_1_slot_if_max_capacity_is_2_and_available_capacity_is_2_and___both_slots_have_same_stackable_item_with_10_stackcount_and_from_slot_has_3_item_and_to_slot_has_8_item___after_from_slot_has_1_amount_and_to_slot_has_10_amount()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var amount = 3u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            amount = 8u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.MoveItem(0, 1, 3u));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(10, inventory.Slots[1].Amount);
            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.AreEqual(1, inventory.Slots[0].Amount);

            builder.Destroy();
        }

        [Test]
        public void can_destack_item_if_slot_1_has_8_stackable_item_with_10_stackcount_and_stack_2_is_free()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(10).SetInvAvailableCapacity(10);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            uint amount = 8u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsTrue(inventory.IsSlotFree(5));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.MoveItem(0, 5, 5u));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            var slots = inventory.Slots;

            Assert.AreEqual(item1, slots[0].Item);
            Assert.AreEqual(3u, slots[0].Amount);

            Assert.AreEqual(item1, slots[5].Item);
            Assert.AreEqual(5u, slots[5].Amount);

            builder.Destroy();
        }

        [Test]
        public void can_move_item_if_slot_1_has_8_stackable_item_with_10_stackcount_and_stack_2_is_free()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(10).SetInvAvailableCapacity(10);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            uint amount = 8u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsTrue(inventory.IsSlotFree(5));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.MoveItem(0, 5, 8u));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsTrue(inventory.IsSlotFree(0));
            Assert.AreEqual(item1, inventory.Slots[5].Item);
            Assert.AreEqual(8u, inventory.Slots[5].Amount);

            builder.Destroy();
        }

        [Test]
        public void can_stack_item_if_slot_1_has_3_and_slot_2_has_5_stackable_item_with_10_stackcount()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(10).SetInvAvailableCapacity(10);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            uint amount = 3u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            amount = 5u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 5, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.MoveItem(0, 5));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            var slots = inventory.Slots;

            Assert.IsTrue(inventory.IsSlotFree(0));
            Assert.AreEqual(item1, inventory.Slots[5].Item);
            Assert.AreEqual(8u, inventory.Slots[5].Amount);

            builder.Destroy();
        }
        #endregion

        #region Remove item
        [Test]
        public void can_not_remove_item_from_empty_inventory()
		{
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem();
            Assert.IsTrue(inventory.IsSlotFree(0));
            Assert.IsFalse(inventory.Contains(item1, 1u));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.Remove(item1, 1u));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            Assert.IsFalse(inventory.Contains(item1, 1u));

            builder.Destroy();
        }

        [Test]
        public void can_not_remove_item_from_inventory_which_is_not_that_item()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var item2 = builder.CreateItem().SetStackCount(10, 1).GetItem(1);
            Assert.IsTrue(inventory.IsSlotFree(0));
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item2, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.Contains(item1, 1u));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.Remove(item1, 1u));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            Assert.IsFalse(inventory.Contains(item1, 1u));

            builder.Destroy();
        }

        [Test]
        public void can_remove_1_not_stackable_item_from_inventory_if_inventory_has_1_item()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsTrue(inventory.Contains(item1, 1u));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.Remove(item1, 1u));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsTrue(inventory.Contains(item1, 0u));
            Assert.IsFalse(inventory.Contains(item1, 1u));

            builder.Destroy();
        }

        [Test]
        public void can_not_remove_2_not_stackable_item_from_inventory_if_inventory_has_1_item()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsTrue(inventory.Contains(item1, 1u));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.Remove(item1, 2u));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            Assert.IsTrue(inventory.Contains(item1, 1u));

            builder.Destroy();
        }

        [Test]
        public void can_remove_2_not_stackable_item_from_inventory_if_inventory_has_2_item()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            var amount = 2u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(0u, amount);
            Assert.IsTrue(inventory.Contains(item1, 2u));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.Remove(item1, 2u));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsTrue(inventory.Contains(item1, 0u));
            Assert.IsFalse(inventory.Contains(item1, 1u));

            builder.Destroy();
        }

        [Test]
        public void can_remove_1_stackable_item_from_inventory_if_inventory_has_1_item()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsTrue(inventory.Contains(item1, 1u));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.Remove(item1, 1u));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsFalse(inventory.Contains(item1, 1u));

            builder.Destroy();
        }

        [Test]
        public void can_not_remove_2_stackable_item_from_inventory_if_inventory_has_1_item()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsTrue(inventory.Contains(item1, 1u));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.Remove(item1, 2u));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            Assert.IsTrue(inventory.Contains(item1, 1u));

            builder.Destroy();
        }

        [Test]
        public void can_remove_2_stackable_item_from_inventory_if_inventory_has_2_item()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var amount = 2u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsTrue(inventory.Contains(item1, 2u));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.Remove(item1, 2u));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsTrue(inventory.Contains(item1, 0u));
            Assert.IsFalse(inventory.Contains(item1, 1u));

            builder.Destroy();
        }

        [Test]
        public void can_remove_20_stackable_item_from_inventory_if_inventory_has_20_item()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var amount = 20u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsTrue(inventory.Contains(item1, 20u));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.Remove(item1, 20u));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsTrue(inventory.Contains(item1, 0u));
            Assert.IsFalse(inventory.Contains(item1, 1u));

            builder.Destroy();
        }

        [Test]
        public void can_not_remove_21_stackable_item_from_inventory_if_inventory_has_20_item()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(3).SetInvAvailableCapacity(3);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var amount = 20u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsTrue(inventory.Contains(item1, 20u));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.Remove(item1, 21u));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            Assert.IsTrue(inventory.Contains(item1, 20u));

            builder.Destroy();
        }

        [Test]
        public void can_remove_19_stackable_item_from_inventory_if_inventory_has_20_item()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(3).SetInvAvailableCapacity(3);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var amount = 20u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsTrue(inventory.Contains(item1, 20u));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.Remove(item1, 19u));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsTrue(inventory.Contains(item1, 1u));
            Assert.IsFalse(inventory.Contains(item1, 2u));

            builder.Destroy();
        }


        [Test]
        public void can_remove_15_stackable_item_from_inventory_if_inventory_has_20_item()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(3).SetInvAvailableCapacity(3);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10, 0).GetItem(0);
            var amount = 20u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsTrue(inventory.Contains(item1, 20u));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.Remove(item1, 15u));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsTrue(inventory.Contains(item1, 5u));
            Assert.IsFalse(inventory.Contains(item1, 6u));

            builder.Destroy();
        }
        #endregion

        #region Remove from Slot
        [Test]
        public void can_not_remove_from_slot_if_it_is_free()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.Remove(0, 1u));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void can_not_remove_from_slot_if_it_is_not_available()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(0);
            var inventory = builder.GetInventory();
            Assert.IsFalse(inventory.IsSlotAvailable(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.Remove(0, 1u));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void can_not_remove_2_amount_from_slot_if_item_on_slot_is_not_stackable()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(1u, inventory.Slots[0].Amount);
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.Remove(0, 2u));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            Assert.AreEqual(1u, inventory.Slots[0].Amount);

            builder.Destroy();
        }

        [Test]
        public void can_not_remove_2_amount_from_slot_if_item_on_slot_is_stackable_with_10_stackcount_but_amount_is_only_1()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(1u, inventory.Slots[0].Amount);
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.Remove(0, 2u));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            Assert.AreEqual(1u, inventory.Slots[0].Amount);

            builder.Destroy();
        }

        [Test]
        public void can_not_remove_10_amount_from_slot_if_item_on_slot_is_stackable_with_10_stackcount_but_amount_is_only_1()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(1u, inventory.Slots[0].Amount);
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.Remove(0, 10u));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            Assert.AreEqual(1u, inventory.Slots[0].Amount);

            builder.Destroy();
        }

        [Test]
        public void can_not_remove_10_amount_from_slot_if_item_on_slot_is_stackable_with_10_stackcount_but_amount_is_only_9()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            var amount = 9u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsTrue(inventory.IsSlotFree(0));
            Assert.AreEqual(item1, inventory.Slots[1].Item);
            Assert.AreEqual(9u, inventory.Slots[1].Amount);
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.Remove(1, 10u));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            Assert.AreEqual(9u, inventory.Slots[1].Amount);

            builder.Destroy();
        }

        [Test]
        public void can_not_remove_11_amount_from_slot_if_item_on_slot_is_stackable_with_10_stackcount_but_amount_is_only_10()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            var amount = 10u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(10u, inventory.Slots[0].Amount);
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.Remove(0, 11u));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            Assert.AreEqual(10u, inventory.Slots[0].Amount);

            builder.Destroy();
        }

        [Test]
        public void can_remove_1_amount_from_slot_if_item_on_slot_is_stackable_with_10_stackcount_but_amount_is_1()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(1u, inventory.Slots[0].Amount);
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.Remove(0, 1u));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsTrue(inventory.IsSlotFree(0));

            builder.Destroy();
        }

		[Test]
        public void can_remove_1_amount_from_slot_if_item_on_slot_is_stackable_with_10_stackcount_but_amount_is_2()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            var amount = 2u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(item1, inventory.Slots[1].Item);
            Assert.AreEqual(2u, inventory.Slots[1].Amount);
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.Remove(1, 1u));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(1u, inventory.Slots[1].Amount);

            builder.Destroy();
        }

        [Test]
        public void can_remove_1_amount_from_slot_if_item_on_slot_is_stackable_with_10_stackcount_but_amount_is_10()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            var amount = 10u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, 1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(item1, inventory.Slots[1].Item);
            Assert.AreEqual(10u, inventory.Slots[1].Amount);
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.Remove(1, 1u));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(9u, inventory.Slots[1].Amount);

            builder.Destroy();
        }

        [Test]
        public void can_remove_10_amount_from_slot_if_item_on_slot_is_stackable_with_10_stackcount_but_amount_is_10()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            var amount = 10u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(10u, inventory.Slots[0].Amount);
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.Remove(0, 10u));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsTrue(inventory.IsSlotFree(0));

            builder.Destroy();
        }

        [Test]
        public void can_remove_1_amount_from_slot_if_item_on_slot_is_not_stackable()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            var amount = 1u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(1u, inventory.Slots[0].Amount);
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.Remove(0, 1u));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.IsTrue(inventory.IsSlotFree(0));

            builder.Destroy();
        }

        [Test]
        public void can_not_remove_2_amount_from_slot_if_item_on_slot_is_not_stackable_and_inventory_has_other_peace_of_that_item()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            var amount = 2u;
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            builder.GetEventListener(0).Received().OnEventRaised(inventory);

            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(item1, inventory.Slots[1].Item);
            Assert.AreEqual(1u, inventory.Slots[0].Amount);
            Assert.AreEqual(1u, inventory.Slots[1].Amount);
            Assert.IsTrue(inventory.Contains(item1, 2u));
            Assert.IsFalse(inventory.Contains(item1, 3u));

            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.Remove(0, 2u));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            Assert.AreEqual(item1, inventory.Slots[0].Item);
            Assert.AreEqual(item1, inventory.Slots[1].Item);
            Assert.AreEqual(1u, inventory.Slots[0].Amount);
            Assert.AreEqual(1u, inventory.Slots[1].Amount);
            Assert.IsTrue(inventory.Contains(item1, 2u));

            builder.Destroy();
        }
        #endregion

        #region IsSlotFree
        [Test]
        public void is_slot_free_if_inventory_is_empty()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void check_slots_are_free_or_not_if_1_not_stackable_item_was_added()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem();
            Assert.IsTrue(inventory.IsSlotFree(0));
            var amount = 1u;
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            Assert.IsFalse(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.IsSlotFree(1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void check_slots_are_free_or_not_if_2_not_stackable_items_were_added()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem();
            Assert.IsTrue(inventory.IsSlotFree(0));
            var amount = 2u;
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            Assert.IsFalse(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.IsSlotFree(1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }


        [Test]
        public void check_slots_are_free_or_not_if_1_stackable_item_with_10_stackcount_was_added()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem();
            Assert.IsTrue(inventory.IsSlotFree(0));
            var amount = 1u;
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            Assert.IsFalse(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.IsSlotFree(1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void check_slots_are_free_or_not_if_2_not_stackable_items_with_10_stackcount_were_added()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem();
            Assert.IsTrue(inventory.IsSlotFree(0));
            var amount = 2u;
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            Assert.IsFalse(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.IsSlotFree(1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void check_slots_are_free_or_not_if_10_not_stackable_items_with_10_stackcount_were_added()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem();
            Assert.IsTrue(inventory.IsSlotFree(0));
            var amount = 10u;
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            Assert.IsFalse(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.IsSlotFree(1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void check_slots_are_free_or_not_if_11_not_stackable_items_with_10_stackcount_were_added()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem();
            Assert.IsTrue(inventory.IsSlotFree(0));
            var amount = 11u;
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            Assert.IsFalse(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.IsSlotFree(1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }
        #endregion

        #region IsSlotAvailable
        [Test]
        public void check_slots_availabilities_if_inventorys_max_capacity_1_and_available_is_0()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(0);
            var inventory = builder.GetInventory();
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.IsSlotAvailable(0));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void check_slots_availabilities_if_inventorys_max_capacity_2_and_available_is_0()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(0);
            var inventory = builder.GetInventory();
            Assert.IsFalse(inventory.IsSlotAvailable(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.IsSlotAvailable(1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void check_slots_availabilities_if_inventorys_max_capacity_2_and_available_is_1()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            Assert.IsTrue(inventory.IsSlotAvailable(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsFalse(inventory.IsSlotAvailable(1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void check_slots_availabilities_if_inventorys_max_capacity_2_and_available_is_2()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            Assert.IsTrue(inventory.IsSlotAvailable(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.IsSlotAvailable(1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void check_slots_availabilities_if_inventorys_max_capacity_2_and_available_is_2_after_added_1_item()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem();
            var amount = 1u;
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            Assert.IsTrue(inventory.IsSlotAvailable(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.IsSlotAvailable(1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void check_slots_availabilities_if_inventorys_max_capacity_2_and_available_is_2_after_added_2_item()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem();
            var amount = 2u;
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            Assert.IsTrue(inventory.IsSlotAvailable(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.IsTrue(inventory.IsSlotAvailable(1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }
        #endregion

        #region AvailableAmountFor
        [Test]
        public void available_amount_is_0_for_not_stackable_item_if_inventory_has_0_available_slot()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(0);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            Assert.IsFalse(inventory.IsSlotAvailable(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(0u, inventory.AvailableFreeSpaceFor(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void available_amount_is_1_for_not_stackable_item_if_inventory_has_1_free_slot()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(1u, inventory.AvailableFreeSpaceFor(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void available_amount_is_2_for_not_stackable_item_if_inventory_has_2_free_slot()
        {
            var inventorySize = 2u;
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(inventorySize).SetInvAvailableCapacity(inventorySize);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            for (int i = 0; i < inventorySize; ++i)
                Assert.IsTrue(inventory.IsSlotFree(i));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(2u, inventory.AvailableFreeSpaceFor(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void available_amount_is_10_for_not_stackable_item_if_inventory_has_10_free_slot()
        {
            var inventorySize = 10u;
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(inventorySize).SetInvAvailableCapacity(inventorySize);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            for (int i = 0; i < inventorySize; ++i)
                Assert.IsTrue(inventory.IsSlotFree(i));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(10u, inventory.AvailableFreeSpaceFor(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void available_amount_is_1_for_not_stackable_item_if_inventory_has_1_free_and_1_has_same_item()
        {
            var inventorySize = 2u;
            var fullSlotCount = 1u;
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(inventorySize).SetInvAvailableCapacity(inventorySize);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            for (int i = 0; i < inventorySize; ++i)
                Assert.IsTrue(inventory.IsSlotFree(i));
            var amount = fullSlotCount;
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            for (int i = 0; i < fullSlotCount; ++i)
                Assert.IsFalse(inventory.IsSlotFree(i));

            for (int i = (int)fullSlotCount; i < inventorySize; ++i)
                Assert.IsTrue(inventory.IsSlotFree(i));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(1u, inventory.AvailableFreeSpaceFor(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void available_amount_is_5_for_not_stackable_item_if_inventory_has_5_free_and_5_not_free_slot()
        {
            var inventorySize = 10u;
            var fullSlotCount = 5u;
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(inventorySize).SetInvAvailableCapacity(inventorySize);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            for (int i = 0; i < inventorySize; ++i)
                Assert.IsTrue(inventory.IsSlotFree(i));
            var amount = fullSlotCount;
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            for (int i = 0; i < fullSlotCount; ++i)
                Assert.IsFalse(inventory.IsSlotFree(i));

            for (int i = (int)fullSlotCount; i < inventorySize; ++i)
                Assert.IsTrue(inventory.IsSlotFree(i));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(5u, inventory.AvailableFreeSpaceFor(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void available_amount_is_1_for_not_stackable_item_if_inventory_has_1_free_and_1_has_other_item()
        {
            var inventorySize = 2u;
            var fullSlotCount = 1u;
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(inventorySize).SetInvAvailableCapacity(inventorySize);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            var item2 = builder.CreateItem().GetItem(1);
            for (int i = 0; i < inventorySize; ++i)
                Assert.IsTrue(inventory.IsSlotFree(i));
            var amount = fullSlotCount;
            Assert.IsTrue(inventory.AddItem(item2, ref amount));
            for (int i = 0; i < fullSlotCount; ++i)
                Assert.IsFalse(inventory.IsSlotFree(i));

            for (int i = (int)fullSlotCount; i < inventorySize; ++i)
                Assert.IsTrue(inventory.IsSlotFree(i));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(1u, inventory.AvailableFreeSpaceFor(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void available_amount_is_5_for_not_stackable_item_if_inventory_has_5_free_and_5_has_other_item()
        {
            var inventorySize = 10u;
            var freeSlotCount = 5u;
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(inventorySize).SetInvAvailableCapacity(inventorySize);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem(0);
            var item2 = builder.CreateItem().GetItem(1);
            for (int i = 0; i < inventorySize; ++i)
                Assert.IsTrue(inventory.IsSlotFree(i));
            var amount = inventorySize - freeSlotCount;
            Assert.IsTrue(inventory.AddItem(item2, ref amount));
            for (int i = 0; i < freeSlotCount; ++i)
                Assert.IsFalse(inventory.IsSlotFree(i));

            for (int i = (int)freeSlotCount; i < inventorySize; ++i)
                Assert.IsTrue(inventory.IsSlotFree(i));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(5u, inventory.AvailableFreeSpaceFor(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void available_amount_is_0_for_stackable_item_with_10_stackcount_if_inventory_has_0_available_slot()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(0);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            Assert.IsFalse(inventory.IsSlotAvailable(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(0u, inventory.AvailableFreeSpaceFor(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void available_amount_is_10_for_stackable_item_with_10_stackcount_if_inventory_has_1_free_slot()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(10u, inventory.AvailableFreeSpaceFor(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void available_amount_is_100_for_stackable_item_with_10_stackcount_if_inventory_has_10_free_slot()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(10).SetInvAvailableCapacity(10);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            for(int i = 0; i < 10; ++i)
                Assert.IsTrue(inventory.IsSlotFree(i));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(100u, inventory.AvailableFreeSpaceFor(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void available_amount_is_50_for_stackable_item_with_10_stackcount_if_inventory_has_5_free_slot_and_5_slots_have_other_item()
        {
            var inventorySize = 10u;
            var fullSlotCount = 5u;
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(inventorySize).SetInvAvailableCapacity(inventorySize);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            var item2 = builder.CreateItem().SetStackCount(10, 1).GetItem(1);
            for (int i = 0; i < fullSlotCount; ++i)
            {
                var amount = 1u;
                Assert.IsTrue(inventory.AddItem(item2, i, ref amount));
                Assert.IsFalse(inventory.IsSlotFree(i));
                Assert.AreEqual(1u, inventory.Slots[i].Amount);
            }

            for (int i = (int)fullSlotCount; i < inventorySize; ++i)
            {
                Assert.IsTrue(inventory.IsSlotFree(i));
            }
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(50u, inventory.AvailableFreeSpaceFor(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void available_amount_is_50_for_stackable_item_with_10_stackcount_if_inventory_has_5_free_slot_and_5_slots_have_same_item_but_all_are_on_full()
        {
            var inventorySize = 10u;
            var fullSlotCount = 5u;
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(inventorySize).SetInvAvailableCapacity(inventorySize);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            for (int i = 0; i < fullSlotCount; ++i)
            {
                var amount = 10u;
                Assert.IsTrue(inventory.AddItem(item1, i, ref amount));
                Assert.IsFalse(inventory.IsSlotFree(i));
                Assert.AreEqual(10u, inventory.Slots[i].Amount);
            }

            for (int i = (int)fullSlotCount; i < inventorySize; ++i)
            {
                Assert.IsTrue(inventory.IsSlotFree(i));
            }
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(50u, inventory.AvailableFreeSpaceFor(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void available_amount_is_95_for_stackable_item_with_10_stackcount_if_inventory_has_5_free_slot_and_5_slots_have_same_item_but_all_are_has_only_1_amount()
        {
            var inventorySize = 10u;
            var fullSlotCount = 5u;
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(inventorySize).SetInvAvailableCapacity(inventorySize);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            for (int i = 0; i < fullSlotCount; ++i)
            {
                var amount = 1u;
                Assert.IsTrue(inventory.AddItem(item1, i, ref amount));
                Assert.IsFalse(inventory.IsSlotFree(i));
                Assert.AreEqual(1u, inventory.Slots[i].Amount);
            }

            for (int i = (int)fullSlotCount; i < inventorySize; ++i)
            {
                Assert.IsTrue(inventory.IsSlotFree(i));
            }
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(95u, inventory.AvailableFreeSpaceFor(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void available_amount_is_75_for_stackable_item_with_10_stackcount_if_inventory_has_5_free_slot_and_5_slots_have_same_item_but_all_are_has_only_5_amount()
        {
            var inventorySize = 10u;
            var fullSlotCount = 5u;
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(inventorySize).SetInvAvailableCapacity(inventorySize);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            for (int i = 0; i < fullSlotCount; ++i)
            {
                var amount = 5u;
                Assert.IsTrue(inventory.AddItem(item1, i, ref amount));
                Assert.IsFalse(inventory.IsSlotFree(i));
                Assert.AreEqual(5u, inventory.Slots[i].Amount);
            }

            for (int i = (int)fullSlotCount; i < inventorySize; ++i)
            {
                Assert.IsTrue(inventory.IsSlotFree(i));
            }
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(75u, inventory.AvailableFreeSpaceFor(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void available_amount_is_10_for_stackable_item_with_10_stackcount_if_inventory_has_1_free_slot_inventory_has_5_not_available_slot()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(1 + 5).SetInvAvailableCapacity(1);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            Assert.IsTrue(inventory.IsSlotFree(0));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(10u, inventory.AvailableFreeSpaceFor(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void available_amount_is_100_for_stackable_item_with_10_stackcount_if_inventory_has_10_free_slot_inventory_has_5_not_available_slot()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(10 + 5).SetInvAvailableCapacity(10);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            for (int i = 0; i < 10; ++i)
                Assert.IsTrue(inventory.IsSlotFree(i));
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(100u, inventory.AvailableFreeSpaceFor(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void available_amount_is_50_for_stackable_item_with_10_stackcount_if_inventory_has_5_free_slot_and_5_slots_have_other_item_inventory_has_5_not_available_slot()
        {
            var inventorySize = 10u;
            var fullSlotCount = 5u;
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(inventorySize + 5).SetInvAvailableCapacity(inventorySize);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            var item2 = builder.CreateItem().SetStackCount(10, 1).GetItem(1);
            for (int i = 0; i < fullSlotCount; ++i)
            {
                var amount = 1u;
                Assert.IsTrue(inventory.AddItem(item2, i, ref amount));
                Assert.IsFalse(inventory.IsSlotFree(i));
                Assert.AreEqual(1u, inventory.Slots[i].Amount);
            }

            for (int i = (int)fullSlotCount; i < inventorySize; ++i)
            {
                Assert.IsTrue(inventory.IsSlotFree(i));
            }
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(50u, inventory.AvailableFreeSpaceFor(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void available_amount_is_50_for_stackable_item_with_10_stackcount_if_inventory_has_5_free_slot_and_5_slots_have_same_item_but_all_are_on_full_inventory_has_5_not_available_slot()
        {
            var inventorySize = 10u;
            var fullSlotCount = 5u;
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(inventorySize + 5).SetInvAvailableCapacity(inventorySize);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            for (int i = 0; i < fullSlotCount; ++i)
            {
                var amount = 10u;
                Assert.IsTrue(inventory.AddItem(item1, i, ref amount));
                Assert.IsFalse(inventory.IsSlotFree(i));
                Assert.AreEqual(10u, inventory.Slots[i].Amount);
            }

            for (int i = (int)fullSlotCount; i < inventorySize; ++i)
            {
                Assert.IsTrue(inventory.IsSlotFree(i));
            }
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(50u, inventory.AvailableFreeSpaceFor(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void available_amount_is_95_for_stackable_item_with_10_stackcount_if_inventory_has_5_free_slot_and_5_slots_have_same_item_but_all_are_has_only_1_amount_inventory_has_5_not_available_slot()
        {
            var inventorySize = 10u;
            var fullSlotCount = 5u;
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(inventorySize + 5).SetInvAvailableCapacity(inventorySize);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            for (int i = 0; i < fullSlotCount; ++i)
            {
                var amount = 1u;
                Assert.IsTrue(inventory.AddItem(item1, i, ref amount));
                Assert.IsFalse(inventory.IsSlotFree(i));
                Assert.AreEqual(1u, inventory.Slots[i].Amount);
            }

            for (int i = (int)fullSlotCount; i < inventorySize; ++i)
            {
                Assert.IsTrue(inventory.IsSlotFree(i));
            }
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(95u, inventory.AvailableFreeSpaceFor(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }

        [Test]
        public void available_amount_is_75_for_stackable_item_with_10_stackcount_if_inventory_has_5_free_slot_and_5_slots_have_same_item_but_all_are_has_only_5_amount_and_inventory_has_5_not_available_slot()
        {
            var inventorySize = 10u;
            var fullSlotCount = 5u;
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(inventorySize + 5).SetInvAvailableCapacity(inventorySize);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            for (int i = 0; i < fullSlotCount; ++i)
            {
                var amount = 5u;
                Assert.IsTrue(inventory.AddItem(item1, i, ref amount));
                Assert.IsFalse(inventory.IsSlotFree(i));
                Assert.AreEqual(5u, inventory.Slots[i].Amount);
            }

            for (int i = (int)fullSlotCount; i < inventorySize; ++i)
            {
                Assert.IsTrue(inventory.IsSlotFree(i));
            }
            builder.GetEventListener(0).ClearReceivedCalls();
            Assert.AreEqual(75u, inventory.AvailableFreeSpaceFor(item1));
            builder.GetEventListener(0).DidNotReceive().OnEventRaised(inventory);

            builder.Destroy();
        }
        #endregion

        #region slots
        [Test]
        public void are_slot_references_good_after_add_items()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(10).SetInvAvailableCapacity(10);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            var item2 = builder.CreateItem().SetStackCount(5, 1).GetItem(1);
            var amount = 50u;
            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            amount = 25u;
            Assert.IsTrue(inventory.AddItem(item2, ref amount));
            var slots = inventory.Slots;
            for (int i = 0; i < 5; ++i)
            {
                Assert.AreEqual(item1, slots[i].Item);
                Assert.AreEqual(10u, slots[i].Amount);
            }
            for (int i = 5; i < 10; ++i)
            {
                Assert.AreEqual(item2, slots[i].Item);
                Assert.AreEqual(5u, slots[i].Amount);
            }

            builder.Destroy();
        }

        [Test]
        public void are_slot_references_good_after_add_items_to_slot()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(10).SetInvAvailableCapacity(10);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            var item2 = builder.CreateItem().SetStackCount(5, 1).GetItem(1);
            for(int i = 0; i < 10; ++i)
			{
                var amount = i % 2 == 0 ? 8u : 4u;
                var item = i % 2 == 0 ? item1 : item2;
                Assert.IsTrue(inventory.AddItem(item, i, ref amount));

            }
            var slots = inventory.Slots;
            for (int i = 0; i < 10; ++i)
            {
                var amount = i % 2 == 0 ? 8u : 4u;
                var item = i % 2 == 0 ? item1 : item2;
                Assert.AreEqual(item, slots[i].Item);
                Assert.AreEqual(amount, slots[i].Amount);
            }

            builder.Destroy();
        }

        [Test]
        public void are_slot_references_good_after_swap_items()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(10).SetInvAvailableCapacity(10);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            var item2 = builder.CreateItem().SetStackCount(5, 1).GetItem(1);
            uint amount = 8u;
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            amount = 4u;
            Assert.IsTrue(inventory.AddItem(item2, 5, ref amount));

            Assert.IsTrue(inventory.MoveItem(0, 5));

            var slots = inventory.Slots;
            Assert.AreEqual(item2, slots[0].Item);
            Assert.AreEqual(4u, slots[0].Amount);

            Assert.AreEqual(item1, slots[5].Item);
            Assert.AreEqual(8u, slots[5].Amount);

            builder.Destroy();
        }

        [Test]
        public void are_slot_references_good_after_stack_items()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(10).SetInvAvailableCapacity(10);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            uint amount = 4u;
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            amount = 4u;
            Assert.IsTrue(inventory.AddItem(item1, 5, ref amount));

            Assert.IsTrue(inventory.MoveItem(0, 5));

            var slots = inventory.Slots;
            Assert.IsTrue(slots[0].IsFree);

            Assert.AreEqual(item1, slots[5].Item);
            Assert.AreEqual(8u, slots[5].Amount);

            builder.Destroy();
        }

        [Test]
        public void are_slot_references_good_after_destack_item()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(10).SetInvAvailableCapacity(10);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            uint amount = 8u;
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            Assert.IsTrue(inventory.MoveItem(0, 5, 5u));

            var slots = inventory.Slots;

            Assert.AreEqual(item1, slots[0].Item);
            Assert.AreEqual(3u, slots[0].Amount);

            Assert.AreEqual(item1, slots[5].Item);
            Assert.AreEqual(5u, slots[5].Amount);

            builder.Destroy();
        }

        [Test]
        public void are_slot_references_good_after_move_item()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(10).SetInvAvailableCapacity(10);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            uint amount = 8u;
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));

            Assert.IsTrue(inventory.MoveItem(0, 5));

            var slots = inventory.Slots;
            Assert.IsTrue(slots[0].IsFree);

            Assert.AreEqual(item1, slots[5].Item);
            Assert.AreEqual(8u, slots[5].Amount);

            builder.Destroy();
        }

        [Test]
        public void are_slot_references_good_after_remove_1_item()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(10).SetInvAvailableCapacity(10);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            uint amount = 8u;
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            Assert.IsTrue(inventory.Remove(item1, 8u));
        
            var slots = inventory.Slots;
            Assert.IsTrue(slots[0].IsFree);

            builder.Destroy();
        }

        [Test]
        public void are_slot_references_good_after_remove_1_amount_of_item()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(10).SetInvAvailableCapacity(10);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            uint amount = 8u;
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));

            Assert.IsTrue(inventory.Remove(item1, 1u));

            var slots = inventory.Slots;
            Assert.AreEqual(item1, slots[0].Item);
            Assert.AreEqual(7u, slots[0].Amount);

            builder.Destroy();
        }

        [Test]
        public void are_slot_references_good_after_remove_from_slot()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(10).SetInvAvailableCapacity(10);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            uint amount = 8u;
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            amount = 8u;
            Assert.IsTrue(inventory.AddItem(item1, 1, ref amount));
            Assert.IsTrue(inventory.Remove(0, 8u));

            var slots = inventory.Slots;
            Assert.IsTrue(slots[0].IsFree);
            Assert.AreEqual(item1, slots[1].Item);
            Assert.AreEqual(8u, slots[1].Amount);

            builder.Destroy();
        }

        [Test]
        public void are_slot_references_good_after_remove_1_amount_from_slot()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(10).SetInvAvailableCapacity(10);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            uint amount = 8u;
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            amount = 8u;
            Assert.IsTrue(inventory.AddItem(item1, 1, ref amount));
            Assert.IsTrue(inventory.Remove(0, 1u));

            var slots = inventory.Slots;
            Assert.AreEqual(item1, slots[0].Item);
            Assert.AreEqual(7u, slots[0].Amount);
            Assert.AreEqual(item1, slots[1].Item);
            Assert.AreEqual(8u, slots[1].Amount);

            builder.Destroy();
        }

        [Test]
        public void are_slot_references_good_after_remove_all_items()
		{
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(10).SetInvAvailableCapacity(10);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            uint amount = 8u;
            Assert.IsTrue(inventory.AddItem(item1, 0, ref amount));
            amount = 8u;
            Assert.IsTrue(inventory.AddItem(item1, 1, ref amount));
            Assert.IsTrue(inventory.Remove(item1, 16u));

            var slots = inventory.Slots;
            for(int i = 0; i < 10; ++i)
                Assert.IsTrue(slots[i].IsFree);

            builder.Destroy();
        }
        #endregion

        #region IsFull
        [Test]
        public void isnt_inventory_full_if_it_has_free_slot()
        {
            var builder = InventoryTestBuilder.Create().CreateInventory().SetInvMaxCapacity(2).SetInvAvailableCapacity(2);
            var inventory = builder.GetInventory();
            var item1 = builder.CreateItem().GetItem();

            Assert.IsTrue(inventory.IsSlotFree(0));
            Assert.IsTrue(inventory.IsSlotFree(1));
            Assert.IsFalse(inventory.IsFull);

            var amount = 1u;

            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.IsTrue(inventory.IsSlotFree(1));
            Assert.IsFalse(inventory.IsFull);

            amount = 1u;

            Assert.IsTrue(inventory.AddItem(item1, ref amount));
            Assert.IsFalse(inventory.IsSlotFree(0));
            Assert.IsFalse(inventory.IsSlotFree(1));
            Assert.IsTrue(inventory.IsFull);

            Assert.IsTrue(inventory.Remove(item1, 1));
            Assert.IsTrue(inventory.IsSlotFree(0) || inventory.IsSlotFree(1));
            Assert.IsFalse(inventory.IsFull);

            Assert.IsTrue(inventory.Remove(item1, 1));
            Assert.IsTrue(inventory.IsSlotFree(0));
            Assert.IsTrue(inventory.IsSlotFree(1));
            Assert.IsFalse(inventory.IsFull);

            builder.Destroy();
        }

        #endregion
    }
}
