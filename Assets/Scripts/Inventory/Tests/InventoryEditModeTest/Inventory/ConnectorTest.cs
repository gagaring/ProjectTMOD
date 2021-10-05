using NUnit.Framework;

namespace VTest.Inventory
{
    public class ConnectedTest
    {
		#region can not - inventory
        [Test]
        public void can_not_move_item_if_target_inventorys_all_slot_have_other_item()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(1, 0).SetInvAvailableCapacity(1, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(2, 1).SetInvAvailableCapacity(2, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            var item2 = builder.CreateItem().SetStackCount(10).GetItem(1);
            var amount = 1u;
            Assert.IsTrue(inventory2.AddItem(item2, 0, ref amount));
            amount = 1u;
            Assert.IsTrue(inventory2.AddItem(item2, 1, ref amount));
            Assert.AreEqual(item2, inventory2.Slots[0].Item);
            Assert.AreEqual(item2, inventory2.Slots[1].Item);

            amount = 10u;
            Assert.IsTrue(inventory1.AddItem(item1, 0, ref amount));
            
            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(item1, inventory1.Slots[0].Item);
            Assert.AreEqual(0u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsFalse(connector.Move(inventory1, inventory2, item1, 1u));

            Assert.AreEqual(0u, inventory2.AvailableFreeSpaceFor(item1));
            Assert.AreEqual(item1, inventory1.Slots[0].Item);
        }

        [Test]
        public void can_not_move_item_if_target_inventorys_all_slot_has_same_item_but_all_is_full__stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(1, 0).SetInvAvailableCapacity(1, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(2, 1).SetInvAvailableCapacity(2, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            var amount = 10u;
            Assert.IsTrue(inventory2.AddItem(item1, 0, ref amount));
            amount = 10u;
            Assert.IsTrue(inventory2.AddItem(item1, 1, ref amount));
            Assert.AreEqual(item1, inventory2.Slots[0].Item);
            Assert.AreEqual(item1, inventory2.Slots[1].Item);

            amount = 10u;

            Assert.IsTrue(inventory1.AddItem(item1, 0, ref amount));
            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(item1, inventory1.Slots[0].Item);
            Assert.AreEqual(0u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsFalse(connector.Move(inventory1, inventory2, item1, 1u));

            Assert.AreEqual(item1, inventory1.Slots[0].Item);
            Assert.AreEqual(0u, inventory2.AvailableFreeSpaceFor(item1));
        }

        [Test]
        public void can_not_move_item_if_target_inventorys_all_slot_has_same_item_but_all_is_full__not_stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(1, 0).SetInvAvailableCapacity(1, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(2, 1).SetInvAvailableCapacity(2, 1).GetInventory(1);
            var item1 = builder.CreateItem().GetItem(0);
            var amount = 1u;
            Assert.IsTrue(inventory2.AddItem(item1, 0, ref amount));
            amount = 1u;
            Assert.IsTrue(inventory2.AddItem(item1, 1, ref amount));
            Assert.AreEqual(item1, inventory2.Slots[0].Item);
            Assert.AreEqual(item1, inventory2.Slots[1].Item);

            amount = 1u;
            Assert.IsTrue(inventory1.AddItem(item1, 0, ref amount));
            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(item1, inventory1.Slots[0].Item);
            Assert.AreEqual(0u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsFalse(connector.Move(inventory1, inventory2, item1, 1u));

            Assert.AreEqual(item1, inventory1.Slots[0].Item);
            Assert.AreEqual(0u, inventory2.AvailableFreeSpaceFor(item1));
        }

        [Test]
        public void can_not_move_item_if_target_inventory_doesnt_have_enough_space_for_amount_because_all_slots_have_same_item_but_almost_full()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(1, 0).SetInvAvailableCapacity(1, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(2, 1).SetInvAvailableCapacity(2, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            var amount = 9u;
            Assert.IsTrue(inventory2.AddItem(item1, 0, ref amount));
            amount = 9u;
            Assert.IsTrue(inventory2.AddItem(item1, 1, ref amount));
            Assert.AreEqual(item1, inventory2.Slots[0].Item);
            Assert.AreEqual(item1, inventory2.Slots[1].Item);

            amount = 10u;
            Assert.IsTrue(inventory1.AddItem(item1, 0, ref amount));
            var connector = builder.CreateConnector().GetConnector();
            
            Assert.AreEqual(10u, inventory1.Contains(item1));
            Assert.AreEqual(2u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsFalse(connector.Move(inventory1, inventory2, item1, 3u));

            Assert.AreEqual(10u, inventory1.Contains(item1));
            Assert.AreEqual(2u, inventory2.AvailableFreeSpaceFor(item1));
        }

        [Test]
        public void can_not_move_item_if_target_inventory_doesnt_have_enough_space_for_amount_because_all_slots_are_free_but_inventory_doesnt_have_enough_space_for_amount__stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(2, 1).SetInvAvailableCapacity(2, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);

            var amount = 30u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));
            Assert.AreEqual(item1, inventory1.Slots[0].Item);
            Assert.AreEqual(item1, inventory1.Slots[1].Item);
            Assert.AreEqual(item1, inventory1.Slots[2].Item);

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(30u, inventory1.Contains(item1));
            Assert.AreEqual(20u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsFalse(connector.Move(inventory1, inventory2, item1, 21u));

            Assert.AreEqual(30u, inventory1.Contains(item1));
            Assert.AreEqual(20u, inventory2.AvailableFreeSpaceFor(item1));
        }

        [Test]
        public void can_not_move_item_if_target_inventory_doesnt_have_enough_space_for_amount_because_all_slots_are_free_but_inventory_doesnt_have_enough_space_for_amount__not_stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(2, 1).SetInvAvailableCapacity(2, 1).GetInventory(1);
            var item1 = builder.CreateItem().GetItem(0);

            var amount = 3u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));
            Assert.AreEqual(item1, inventory1.Slots[0].Item);
            Assert.AreEqual(item1, inventory1.Slots[1].Item);
            Assert.AreEqual(item1, inventory1.Slots[2].Item);

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(3u, inventory1.Contains(item1));
            Assert.AreEqual(2u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsFalse(connector.Move(inventory1, inventory2, item1, 3u));

            Assert.AreEqual(3u, inventory1.Contains(item1));
            Assert.AreEqual(2u, inventory2.AvailableFreeSpaceFor(item1));
        }

        [Test]
        public void can_not_move_item_if_target_inventory_doesnt_have_enough_space_for_amount_because_some_slot_is_free_and_some_doesnt_but_inventory_doest_have_enough_space_for_amount__stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(2, 1).SetInvAvailableCapacity(2, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);

            var amount = 9u;
            Assert.IsTrue(inventory2.AddItem(item1, 0, ref amount));

            amount = 30u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));
            Assert.AreEqual(item1, inventory1.Slots[0].Item);
            Assert.AreEqual(item1, inventory1.Slots[1].Item);
            Assert.AreEqual(item1, inventory1.Slots[2].Item);

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(30u, inventory1.Contains(item1));
            Assert.AreEqual(11u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsFalse(connector.Move(inventory1, inventory2, item1, 12u));

            Assert.AreEqual(30u, inventory1.Contains(item1));
            Assert.AreEqual(11u, inventory2.AvailableFreeSpaceFor(item1));
        }

        [Test]
        public void can_not_move_item_if_target_inventory_doesnt_have_enough_space_for_amount_because_some_slot_is_free_and_some_doesnt_but_inventory_doest_have_enough_space_for_amount__not_stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(2, 1).SetInvAvailableCapacity(2, 1).GetInventory(1);
            var item1 = builder.CreateItem().GetItem(0);

            var amount = 1u;
            Assert.IsTrue(inventory2.AddItem(item1, 0, ref amount));

            amount = 3u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));
            Assert.AreEqual(item1, inventory1.Slots[0].Item);
            Assert.AreEqual(item1, inventory1.Slots[1].Item);
            Assert.AreEqual(item1, inventory1.Slots[2].Item);

            var connector = builder.CreateConnector().GetConnector();
            
            Assert.AreEqual(3u, inventory1.Contains(item1));
            Assert.AreEqual(1u, inventory2.AvailableFreeSpaceFor(item1));
            
            Assert.IsFalse(connector.Move(inventory1, inventory2, item1, 2u));

            Assert.AreEqual(3u, inventory1.Contains(item1));
            Assert.AreEqual(1u, inventory2.AvailableFreeSpaceFor(item1));
        }
        #endregion

        #region can not - target slot
        [Test]
        public void can_not_move_item_if_target_slot_is_not_avaiable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(1, 0).SetInvAvailableCapacity(1, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(2, 1).SetInvAvailableCapacity(0, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            var amount = 1u;
            Assert.IsTrue(inventory1.AddItem(item1, 0, ref amount));
            var connector = builder.CreateConnector().GetConnector();
            
            Assert.AreEqual(item1, inventory1.Slots[0].Item);

            Assert.IsFalse(connector.Move(inventory1, inventory2, item1, 0, 1u));
        
            Assert.AreEqual(item1, inventory1.Slots[0].Item);
        }

        [Test]
        public void can_not_move_item_if_target_slot_has_other_item()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(1, 0).SetInvAvailableCapacity(1, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(3, 1).SetInvAvailableCapacity(3, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            var item2 = builder.CreateItem().SetStackCount(10).GetItem(1);
            var amount = 1u;
            Assert.IsTrue(inventory2.AddItem(item2, 1, ref amount));
            Assert.AreEqual(item2, inventory2.Slots[1].Item);

            amount = 10u;
            Assert.IsTrue(inventory1.AddItem(item1, 0, ref amount));
            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(10u, inventory1.Contains(item1));
            Assert.AreEqual(20u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsFalse(connector.Move(inventory1, inventory2, item1, 1, 1u));

            Assert.AreEqual(10u, inventory1.Contains(item1));
            Assert.AreEqual(20u, inventory2.AvailableFreeSpaceFor(item1));
        }

        [Test]
        public void can_not_move_item_if_target_slot_has_same_item_but_dont_have_enough_free_space__stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(1, 0).SetInvAvailableCapacity(1, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(3, 1).SetInvAvailableCapacity(3, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            var amount = 1u;
            Assert.IsTrue(inventory2.AddItem(item1, 1, ref amount));
            Assert.AreEqual(item1, inventory2.Slots[1].Item);

            amount = 10u;
            Assert.IsTrue(inventory1.AddItem(item1, 0, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(29u, inventory2.AvailableFreeSpaceFor(item1));
            Assert.AreEqual(10u, inventory1.Contains(item1)); 
            
            Assert.IsFalse(connector.Move(inventory1, inventory2, item1, 1, 10u));

            Assert.AreEqual(29u, inventory2.AvailableFreeSpaceFor(item1));
            Assert.AreEqual(10u, inventory1.Contains(item1));
        }

        [Test]
        public void can_not_move_item_if_target_slot_has_same_item_but_dont_have_enough_free_space__not_stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(3, 1).SetInvAvailableCapacity(3, 1).GetInventory(1);
            var item1 = builder.CreateItem().GetItem(0);
            var amount = 1u;
            Assert.IsTrue(inventory2.AddItem(item1, 1, ref amount));
            Assert.AreEqual(item1, inventory2.Slots[1].Item);

            amount = 3u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));
            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(2u, inventory2.AvailableFreeSpaceFor(item1));
            Assert.AreEqual(3u, inventory1.Contains(item1));

            Assert.IsFalse(connector.Move(inventory1, inventory2, item1, 1, 1u));

            Assert.AreEqual(2u, inventory2.AvailableFreeSpaceFor(item1));
            Assert.AreEqual(3u, inventory1.Contains(item1));
        }

        [Test]
        public void can_not_move_item_if_target_slot_is_free_but_amount_is_more_that_stackcount__stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(2, 0).SetInvAvailableCapacity(2, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(3, 1).SetInvAvailableCapacity(3, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            var amount = 1u;
            Assert.IsTrue(inventory2.AddItem(item1, 1, ref amount));
            Assert.AreEqual(item1, inventory2.Slots[1].Item);


            amount = 20u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));
            var connector = builder.CreateConnector().GetConnector();

            Assert.IsTrue(inventory2.IsSlotFree(0));
            Assert.AreEqual(29u, inventory2.AvailableFreeSpaceFor(item1));
            Assert.AreEqual(20u, inventory1.Contains(item1));

            Assert.IsFalse(connector.Move(inventory1, inventory2, item1, 0, 11u));

            Assert.IsTrue(inventory2.IsSlotFree(0));
            Assert.AreEqual(29u, inventory2.AvailableFreeSpaceFor(item1));
            Assert.AreEqual(20u, inventory1.Contains(item1));
        }


        [Test]
        public void can_not_move_item_if_target_slot_is_free_but_amount_is_more_that_stackcount__not_stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(2, 0).SetInvAvailableCapacity(2, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(3, 1).SetInvAvailableCapacity(3, 1).GetInventory(1);
            var item1 = builder.CreateItem().GetItem(0);
            var amount = 1u;
            Assert.IsTrue(inventory2.AddItem(item1, 1, ref amount));
            Assert.AreEqual(item1, inventory2.Slots[1].Item);

            amount = 2u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));
            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(2u, inventory2.AvailableFreeSpaceFor(item1));
            Assert.AreEqual(2u, inventory1.Contains(item1));
            Assert.IsTrue(inventory2.IsSlotFree(0));

            Assert.IsFalse(connector.Move(inventory1, inventory2, item1, 0, 2u));

            Assert.AreEqual(2u, inventory2.AvailableFreeSpaceFor(item1));
            Assert.AreEqual(2u, inventory1.Contains(item1));
            Assert.IsTrue(inventory2.IsSlotFree(0));
        }
        #endregion

        #region can not - source inventory
        [Test]
        public void can_not_move_item_if_source_inventory_is_empty()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(2, 0).SetInvAvailableCapacity(2, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(3, 1).SetInvAvailableCapacity(3, 1).GetInventory(1);
            var item1 = builder.CreateItem().GetItem(0);

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(0u, inventory1.Contains(item1));
            Assert.AreEqual(3u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsFalse(connector.Move(inventory1, inventory2, item1, 1u));

            Assert.AreEqual(0u, inventory1.Contains(item1));
            Assert.AreEqual(3u, inventory2.AvailableFreeSpaceFor(item1));
        }

        [Test]
        public void can_not_move_item_if_source_inventory_doesnt_target_item()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(2, 0).SetInvAvailableCapacity(2, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(3, 1).SetInvAvailableCapacity(3, 1).GetInventory(1);
            var item1 = builder.CreateItem().GetItem(0);
            var item2 = builder.CreateItem().GetItem(1);


            var amount = 2u;
            Assert.IsTrue(inventory1.AddItem(item2, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(2u, inventory1.Contains(item2));
            Assert.AreEqual(0u, inventory1.Contains(item1));
            Assert.AreEqual(3u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsFalse(connector.Move(inventory1, inventory2, item1, 1u));

            Assert.AreEqual(2u, inventory1.Contains(item2));
            Assert.AreEqual(0u, inventory1.Contains(item1));
            Assert.AreEqual(3u, inventory2.AvailableFreeSpaceFor(item1));
        }

        [Test]
        public void can_not_move_item_if_source_inventory_has_target_item_but_not_enough()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(2, 0).SetInvAvailableCapacity(2, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(3, 1).SetInvAvailableCapacity(3, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);

            var amount = 16u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(16u, inventory1.Contains(item1));
            Assert.AreEqual(30u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsFalse(connector.Move(inventory1, inventory2, item1, 17u));

            Assert.AreEqual(16u, inventory1.Contains(item1));
            Assert.AreEqual(30u, inventory2.AvailableFreeSpaceFor(item1));
        }
        #endregion

        #region can not - source slot
        [Test]
        public void can_not_move_item_if_source_slot_is_not_available()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(2, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(3, 1).SetInvAvailableCapacity(3, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);

            var amount = 16u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));
            Assert.AreEqual(16u, inventory1.Contains(item1));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(30u, inventory2.AvailableFreeSpaceFor(item1));
            Assert.IsFalse(inventory1.IsSlotAvailable(2));

            Assert.IsFalse(connector.Move(inventory1, inventory2, 2, 1u));

            Assert.AreEqual(30u, inventory2.AvailableFreeSpaceFor(item1));
            Assert.IsFalse(inventory1.IsSlotAvailable(2));
        }

        [Test]
        public void can_not_move_item_if_source_slot_is_free()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(3, 1).SetInvAvailableCapacity(3, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);

            var amount = 16u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(16u, inventory1.Contains(item1));
            Assert.AreEqual(30u, inventory2.AvailableFreeSpaceFor(item1));
            Assert.IsTrue(inventory1.IsSlotFree(2));

            Assert.IsFalse(connector.Move(inventory1, inventory2, 2, 1u));

            Assert.AreEqual(16u, inventory1.Contains(item1));
            Assert.AreEqual(30u, inventory2.AvailableFreeSpaceFor(item1));
            Assert.IsTrue(inventory1.IsSlotFree(2));
        }

        [Test]
        public void can_not_move_item_if_source_slot_doesnt_have_enough_item()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(3, 1).SetInvAvailableCapacity(3, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);

            var amount = 16u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(16u, inventory1.Contains(item1));
            Assert.AreEqual(30u, inventory2.AvailableFreeSpaceFor(item1));
            Assert.AreEqual(item1, inventory1.Slots[1].Item);
            Assert.AreEqual(6u, inventory1.Slots[1].Amount);

            Assert.IsFalse(connector.Move(inventory1, inventory2, 1, 7u));

            Assert.AreEqual(16u, inventory1.Contains(item1));
            Assert.AreEqual(30u, inventory2.AvailableFreeSpaceFor(item1));
            Assert.AreEqual(item1, inventory1.Slots[1].Item);
            Assert.AreEqual(6u, inventory1.Slots[1].Amount);
        }
        #endregion

        #region can - inventory - inventory
        [Test]
        public void can_move_item_if_source_inventory_has_equal_amount_of_item_and_target_inventorys_free_space_is_equal_to_that_amount__stackable() //= =
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(3, 1).SetInvAvailableCapacity(3, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);

            var amount = 30u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(30u, inventory1.Contains(item1));
            Assert.AreEqual(30u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsTrue(connector.Move(inventory1, inventory2, item1, 30u));

            Assert.AreEqual(0u, inventory1.Contains(item1));
            Assert.AreEqual(30u, inventory2.Contains(item1));
        }

        [Test]
        public void can_move_item_if_source_inventory_has_equal_amount_of_item_and_target_inventorys_free_space_is_more_than_that_amount__stackable()//= <
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(3, 1).SetInvAvailableCapacity(3, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);

            var amount = 20u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));

            var connector = builder.CreateConnector().GetConnector();
            
            Assert.AreEqual(20u, inventory1.Contains(item1));
            Assert.AreEqual(30u, inventory2.AvailableFreeSpaceFor(item1));
            
            Assert.IsTrue(connector.Move(inventory1, inventory2, item1, 20u));

            Assert.AreEqual(0u, inventory1.Contains(item1));
            Assert.AreEqual(20u, inventory2.Contains(item1));
        }

        [Test]
        public void can_move_item_if_source_inventory_has_enough_amount_of_item_and_target_inventorys_free_space_is_equal_to_that_amount__stackable()//< =
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(2, 1).SetInvAvailableCapacity(2, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);

            var amount = 30u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(30u, inventory1.Contains(item1));
            Assert.AreEqual(20u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsTrue(connector.Move(inventory1, inventory2, item1, 20u));
            Assert.AreEqual(10u, inventory1.Contains(item1));
            Assert.AreEqual(20u, inventory2.Contains(item1));
        }

        [Test]
        public void can_move_item_if_source_inventory_has_enough_amount_of_item_and_target_inventorys_free_space_is_more_than_that_amount__stackable()//< <
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(2, 1).SetInvAvailableCapacity(2, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);

            var amount = 20u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(20u, inventory1.Contains(item1));
            Assert.AreEqual(20u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsTrue(connector.Move(inventory1, inventory2, item1, 19u));
            Assert.AreEqual(1u, inventory1.Contains(item1));
            Assert.AreEqual(19u, inventory2.Contains(item1));
        }

        [Test]
        public void can_move_item_if_source_inventory_has_equal_amount_of_item_and_target_inventorys_free_space_is_equal_to_that_amount__not_stackable()//= =
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(2, 1).SetInvAvailableCapacity(2, 1).GetInventory(1);
            var item1 = builder.CreateItem().GetItem(0);

            var amount = 2u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(2u, inventory1.Contains(item1));
            Assert.AreEqual(2u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsTrue(connector.Move(inventory1, inventory2, item1, 2u));
            Assert.AreEqual(0u, inventory1.Contains(item1));
            Assert.AreEqual(2u, inventory2.Contains(item1));
        }

        [Test]
        public void can_move_item_if_source_inventory_has_equal_amount_of_item_and_target_inventorys_free_space_is_more_than_that_amount__not_stackable()//= <
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(3, 1).SetInvAvailableCapacity(3, 1).GetInventory(1);
            var item1 = builder.CreateItem().GetItem(0);

            var amount = 2u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(2u, inventory1.Contains(item1));
            Assert.AreEqual(3u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsTrue(connector.Move(inventory1, inventory2, item1, 2u));

            Assert.AreEqual(0u, inventory1.Contains(item1));
            Assert.AreEqual(2u, inventory2.Contains(item1));
        }

        [Test]
        public void can_move_item_if_source_inventory_has_enough_amount_of_item_and_target_inventorys_free_space_is_equal_to_that_amount__not_stackable() //< =
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(2, 1).SetInvAvailableCapacity(2, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(1).GetItem(0);

            var amount = 3u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(3u, inventory1.Contains(item1));
            Assert.AreEqual(2u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsTrue(connector.Move(inventory1, inventory2, item1, 2u));

            Assert.AreEqual(1u, inventory1.Contains(item1));
            Assert.AreEqual(2u, inventory2.Contains(item1));
        }


        [Test]
        public void can_move_item_if_source_inventory_has_enough_amount_of_item_and_target_inventorys_free_space_is_more_than_that_amount__not_stackable()//< <
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(3, 1).SetInvAvailableCapacity(3, 1).GetInventory(1);
            var item1 = builder.CreateItem().GetItem(0);

            var amount = 3u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(3u, inventory1.Contains(item1));
            Assert.AreEqual(3u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsTrue(connector.Move(inventory1, inventory2, item1, 2u));

            Assert.AreEqual(1u, inventory1.Contains(item1));
            Assert.AreEqual(2u, inventory2.Contains(item1));
        }
        #endregion

        #region can - inventory - slot
        [Test]
        public void can_move_item_if_source_inventory_has_equal_amount_of_item_and_target_slot_is_free_and_stackcount_is_more_than_amount__stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(1, 1).SetInvAvailableCapacity(1, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);

            var amount = 9u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(9u, inventory1.Contains(item1));
            Assert.AreEqual(10u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsTrue(connector.Move(inventory1, inventory2, item1, 0, 9u));

            Assert.AreEqual(0u, inventory1.Contains(item1));
            Assert.AreEqual(9u, inventory2.Contains(item1));
        }

        [Test]
        public void can_move_item_if_source_inventory_has_equal_amount_of_item_and_target_slot_is_free_and_stackcount_is_equal_to_amount__stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(1, 1).SetInvAvailableCapacity(1, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(9).GetItem(0);

            var amount = 9u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(9u, inventory1.Contains(item1));
            Assert.AreEqual(9u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsTrue(connector.Move(inventory1, inventory2, item1, 0, 9u));

            Assert.AreEqual(0u, inventory1.Contains(item1));
            Assert.AreEqual(9u, inventory2.Contains(item1));
        }

        [Test]
        public void can_move_item_if_source_inventory_has_equal_amount_of_item_and_target_slot_has_same_item_and_has_free_space_is_equal_same_as_amount__stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(1, 1).SetInvAvailableCapacity(1, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);

            var amount = 9u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));
            amount = 1u;
            Assert.IsTrue(inventory2.AddItem(item1, 0, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(9u, inventory1.Contains(item1));
            Assert.AreEqual(9u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsTrue(connector.Move(inventory1, inventory2, item1, 0, 9u));
            
            Assert.AreEqual(0u, inventory1.Contains(item1));
            Assert.AreEqual(10u, inventory2.Contains(item1));
        }

        [Test]
        public void can_move_item_if_source_inventory_has_equal_amount_of_item_and_target_slot_has_same_item_and_has_free_space_is_more_than_amount__stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(1, 1).SetInvAvailableCapacity(1, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(11).GetItem(0);

            var amount = 9u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));
            amount = 1u;
            Assert.IsTrue(inventory2.AddItem(item1, 0, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(9u, inventory1.Contains(item1));
            Assert.AreEqual(10u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsTrue(connector.Move(inventory1, inventory2, item1, 0, 9u));
        
            Assert.AreEqual(0u, inventory1.Contains(item1));
            Assert.AreEqual(10u, inventory2.Contains(item1));
        }

        [Test]
        public void can_move_item_if_source_inventory_has_equal_amount_of_item_and_target_slot_is_free__not_stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(1, 1).SetInvAvailableCapacity(1, 1).GetInventory(1);
            var item1 = builder.CreateItem().GetItem(0);

            var amount = 1u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(1u, inventory1.Contains(item1));
            Assert.AreEqual(0u, inventory2.Contains(item1));
            Assert.AreEqual(1u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsTrue(connector.Move(inventory1, inventory2, item1, 0, 1u));

            Assert.AreEqual(0u, inventory1.Contains(item1));
            Assert.AreEqual(1u, inventory2.Contains(item1));
        }

        [Test]
        public void can_move_item_if_source_inventory_has_enough_amount_of_item_and_target_slot_is_free__not_stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(1, 1).SetInvAvailableCapacity(1, 1).GetInventory(1);
            var item1 = builder.CreateItem().GetItem(0);

            var amount = 3u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(3u, inventory1.Contains(item1));
            Assert.AreEqual(1u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsTrue(connector.Move(inventory1, inventory2, item1, 0, 1u));
         
            Assert.AreEqual(2u, inventory1.Contains(item1));
            Assert.AreEqual(1u, inventory2.Contains(item1));
        }

        [Test]
        public void can_move_item_if_source_inventory_has_enough_amount_of_item_and_target_slot_is_free_and_stackcount_is_more_than_amount__stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(1, 1).SetInvAvailableCapacity(1, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);

            var amount = 10u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(10u, inventory1.Contains(item1));
            Assert.AreEqual(10u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsTrue(connector.Move(inventory1, inventory2, item1, 0, 9u));

            Assert.AreEqual(1u, inventory1.Contains(item1));
            Assert.AreEqual(9u, inventory2.Contains(item1));
        }

        [Test]
        public void can_move_item_if_source_inventory_has_enough_amount_of_item_and_target_slot_is_free_and_stackcount_is_equal_to_amount__stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(1, 1).SetInvAvailableCapacity(1, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(9).GetItem(0);

            var amount = 10u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(10u, inventory1.Contains(item1));
            Assert.AreEqual(9u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsTrue(connector.Move(inventory1, inventory2, item1, 0, 9u));

            Assert.AreEqual(1u, inventory1.Contains(item1));
            Assert.AreEqual(9u, inventory2.Contains(item1));
        }

        [Test]
        public void can_move_item_if_source_inventory_has_enough_amount_of_item_and_target_slot_has_same_item_and_has_free_space_is_equal_same_as_amount__stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(1, 1).SetInvAvailableCapacity(1, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);

            var amount = 10u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));
            amount = 1u;
            Assert.IsTrue(inventory2.AddItem(item1, 0, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(10u, inventory1.Contains(item1));
            Assert.AreEqual(9u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsTrue(connector.Move(inventory1, inventory2, item1, 0, 9u));

            Assert.AreEqual(1u, inventory1.Contains(item1));
            Assert.AreEqual(10u, inventory2.Contains(item1));
        }

        [Test]
        public void can_move_item_if_source_inventory_has_enough_amount_of_item_and_target_slot_has_same_item_and_has_free_space_is_more_than_amount__stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(1, 1).SetInvAvailableCapacity(1, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(11).GetItem(0);

            var amount = 10u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));
            amount = 1u;
            Assert.IsTrue(inventory2.AddItem(item1, 0, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(10u, inventory1.Contains(item1));
            Assert.AreEqual(10u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsTrue(connector.Move(inventory1, inventory2, item1, 0, 9u));

            Assert.AreEqual(1u, inventory1.Contains(item1));
            Assert.AreEqual(10u, inventory2.Contains(item1));
        }
        #endregion

        #region can - slot - slot
        [Test]
        public void can_move_item_if_source_slot_has_equal_amount_of_item_and_target_slot_is_free_and_stackcount_is_more_than_amount__stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(1, 1).SetInvAvailableCapacity(1, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(20).GetItem(0);

            var amount = 10u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(10u, inventory1.Slots[0].Amount);
            Assert.AreEqual(item1, inventory1.Slots[0].Item);
            Assert.IsTrue(inventory2.IsSlotFree(0));

            Assert.IsTrue(connector.Move(inventory1, inventory2, 0, 0, 10u));

            Assert.AreEqual(10u, inventory2.Slots[0].Amount);
            Assert.AreEqual(item1, inventory2.Slots[0].Item);
            Assert.IsTrue(inventory1.IsSlotFree(0));
        }

        [Test]
        public void can_move_item_if_source_slot_has_equal_amount_of_item_and_target_slot_is_free_and_stackcount_is_equal_to_amount__stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(1, 1).SetInvAvailableCapacity(1, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);

            var amount = 10u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(10u, inventory1.Slots[0].Amount);
            Assert.AreEqual(item1, inventory1.Slots[0].Item);
            Assert.IsTrue(inventory2.IsSlotFree(0));

            Assert.IsTrue(connector.Move(inventory1, inventory2, 0, 0, 10u));

            Assert.AreEqual(10u, inventory2.Slots[0].Amount);
            Assert.AreEqual(item1, inventory2.Slots[0].Item);
            Assert.IsTrue(inventory1.IsSlotFree(0));
        }

        [Test]
        public void can_move_item_if_source_slot_has_equal_amount_of_item_and_target_slot_has_same_item_and_has_free_space_is_equal_same_as_amount__stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(1, 1).SetInvAvailableCapacity(1, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);

            var amount = 9u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));

            amount = 1u;
            Assert.IsTrue(inventory2.AddItem(item1, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(9u, inventory1.Slots[0].Amount);
            Assert.AreEqual(item1, inventory1.Slots[0].Item);

            Assert.AreEqual(1u, inventory2.Slots[0].Amount);
            Assert.AreEqual(item1, inventory2.Slots[0].Item);
            Assert.AreEqual(9u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsTrue(connector.Move(inventory1, inventory2, 0, 0, 9u));

            Assert.AreEqual(10u, inventory2.Slots[0].Amount);
            Assert.AreEqual(item1, inventory2.Slots[0].Item);
            Assert.IsTrue(inventory1.IsSlotFree(0));
        }

        [Test]
        public void can_move_item_if_source_slot_has_equal_amount_of_item_and_target_slot_has_same_item_and_has_free_space_is_more_than_amount__stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(1, 1).SetInvAvailableCapacity(1, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(11).GetItem(0);

            var amount = 9u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));

            amount = 1u;
            Assert.IsTrue(inventory2.AddItem(item1, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(9u, inventory1.Slots[0].Amount);
            Assert.AreEqual(item1, inventory1.Slots[0].Item);

            Assert.AreEqual(1u, inventory2.Slots[0].Amount);
            Assert.AreEqual(item1, inventory2.Slots[0].Item);
            Assert.AreEqual(10u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsTrue(connector.Move(inventory1, inventory2, 0, 0, 9u));

            Assert.AreEqual(10u, inventory2.Slots[0].Amount);
            Assert.AreEqual(item1, inventory2.Slots[0].Item);
            Assert.IsTrue(inventory1.IsSlotFree(0));
        }

        [Test]
        public void can_move_not_stackable_item_if_source_slot_has_it_and_target_slot_is_free()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(1, 1).SetInvAvailableCapacity(1, 1).GetInventory(1);
            var item1 = builder.CreateItem().GetItem(0);

            var amount = 1u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(1u, inventory1.Slots[0].Amount);
            Assert.AreEqual(item1, inventory1.Slots[0].Item);
            Assert.IsTrue(inventory2.IsSlotFree(0));

            Assert.IsTrue(connector.Move(inventory1, inventory2, 0, 0, 1u));

            Assert.AreEqual(1u, inventory2.Slots[0].Amount);
            Assert.AreEqual(item1, inventory2.Slots[0].Item);
            Assert.IsTrue(inventory1.IsSlotFree(0));
        }
        #endregion

        #region can - slot - inventory
        [Test]
        public void can_move_item_if_source_slot_has_equal_amount_of_item_and_target_inventorys_free_space_is_equal_to_that_amount__stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(2, 1).SetInvAvailableCapacity(2, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            var item2 = builder.CreateItem().SetStackCount(10, 1).GetItem(1);

            uint amount;

            amount = 1u;
            Assert.IsTrue(inventory2.AddItem(item2, ref amount));

            amount = 10u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(10u, inventory1.Slots[0].Amount);
            Assert.AreEqual(item1, inventory1.Slots[0].Item);

            Assert.AreEqual(1u, inventory2.Slots[0].Amount);
            Assert.AreEqual(item2, inventory2.Slots[0].Item);
            Assert.IsTrue(inventory2.IsSlotFree(1));
            Assert.AreEqual(10u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsTrue(connector.Move(inventory1, inventory2, 0, 10u));

            Assert.AreEqual(1u, inventory2.Slots[0].Amount);
            Assert.AreEqual(item2, inventory2.Slots[0].Item);
            Assert.AreEqual(10u, inventory2.Slots[1].Amount);
            Assert.AreEqual(item1, inventory2.Slots[1].Item);
            Assert.IsTrue(inventory1.IsSlotFree(0));
        }

        [Test]
        public void can_move_item_if_source_slot_has_equal_amount_of_item_and_target_inventorys_free_space_is_more_than_that_amount__stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(3, 1).SetInvAvailableCapacity(3, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            var item2 = builder.CreateItem().SetStackCount(10, 1).GetItem(1);

            uint amount;

            amount = 1u;
            Assert.IsTrue(inventory2.AddItem(item2, ref amount));

            amount = 10u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(10u, inventory1.Slots[0].Amount);
            Assert.AreEqual(item1, inventory1.Slots[0].Item);

            Assert.AreEqual(1u, inventory2.Slots[0].Amount);
            Assert.AreEqual(item2, inventory2.Slots[0].Item);
            Assert.IsTrue(inventory2.IsSlotFree(1));
            Assert.IsTrue(inventory2.IsSlotFree(2));
            Assert.AreEqual(20u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsTrue(connector.Move(inventory1, inventory2, 0, 10u));

            Assert.AreEqual(1u, inventory2.Slots[0].Amount);
            Assert.AreEqual(item2, inventory2.Slots[0].Item);
            Assert.AreEqual(10u, inventory2.Slots[1].Amount);
            Assert.AreEqual(item1, inventory2.Slots[1].Item);
            Assert.IsTrue(inventory1.IsSlotFree(0));
        }

        [Test]
        public void can_move_item_if_source_slot_has_enough_amount_of_item_and_target_inventorys_free_space_is_equal_to_that_amount__stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(2, 1).SetInvAvailableCapacity(2, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            var item2 = builder.CreateItem().SetStackCount(10, 1).GetItem(1);

            uint amount;

            amount = 1u;
            Assert.IsTrue(inventory2.AddItem(item2, ref amount));

            amount = 10u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));

            amount = 1u;
            Assert.IsTrue(inventory2.AddItem(item1, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(10u, inventory1.Slots[0].Amount);
            Assert.AreEqual(item1, inventory1.Slots[0].Item);

            Assert.AreEqual(1u, inventory2.Slots[0].Amount);
            Assert.AreEqual(item2, inventory2.Slots[0].Item);
            Assert.AreEqual(1u, inventory2.Slots[1].Amount);
            Assert.AreEqual(item1, inventory2.Slots[1].Item);
            Assert.AreEqual(9u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsTrue(connector.Move(inventory1, inventory2, 0, 9u));

            Assert.AreEqual(1u, inventory2.Slots[0].Amount);
            Assert.AreEqual(item2, inventory2.Slots[0].Item);
            Assert.AreEqual(10u, inventory2.Slots[1].Amount);
            Assert.AreEqual(item1, inventory2.Slots[1].Item);

            Assert.AreEqual(1u, inventory1.Slots[0].Amount);
            Assert.AreEqual(item1, inventory1.Slots[0].Item);
        }

        [Test]
        public void can_move_item_if_source_slot_has_enough_amount_of_item_and_target_inventorys_free_space_is_more_than_that_amount__stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(3, 1).SetInvAvailableCapacity(3, 1).GetInventory(1);
            var item1 = builder.CreateItem().SetStackCount(10).GetItem(0);
            var item2 = builder.CreateItem().SetStackCount(10, 1).GetItem(1);

            uint amount;

            amount = 1u;
            Assert.IsTrue(inventory2.AddItem(item2, ref amount));

            amount = 10u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));

            amount = 1u;
            Assert.IsTrue(inventory2.AddItem(item1, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(10u, inventory1.Slots[0].Amount);
            Assert.AreEqual(item1, inventory1.Slots[0].Item);

            Assert.AreEqual(1u, inventory2.Slots[0].Amount);
            Assert.AreEqual(item2, inventory2.Slots[0].Item);
            Assert.AreEqual(1u, inventory2.Slots[1].Amount);
            Assert.AreEqual(item1, inventory2.Slots[1].Item);
            Assert.AreEqual(19u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsTrue(connector.Move(inventory1, inventory2, 0, 9u));

            Assert.AreEqual(1u, inventory2.Slots[0].Amount);
            Assert.AreEqual(item2, inventory2.Slots[0].Item);
            Assert.AreEqual(10u, inventory2.Slots[1].Amount);
            Assert.AreEqual(item1, inventory2.Slots[1].Item);

            Assert.AreEqual(1u, inventory1.Slots[0].Amount);
            Assert.AreEqual(item1, inventory1.Slots[0].Item);
        }

        [Test]
        public void can_move_item_if_source_slot_has_equal_amount_of_item_and_target_inventorys_free_space_is_equal_to_that_amount__not_stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(3, 1).SetInvAvailableCapacity(3, 1).GetInventory(1);
            var item1 = builder.CreateItem().GetItem(0);
            var item2 = builder.CreateItem().GetItem(1);

            uint amount;

            amount = 2u;
            Assert.IsTrue(inventory2.AddItem(item2, ref amount));

            amount = 1u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(1u, inventory1.Slots[0].Amount);
            Assert.AreEqual(item1, inventory1.Slots[0].Item);

            Assert.AreEqual(1u, inventory2.Slots[0].Amount);
            Assert.AreEqual(item2, inventory2.Slots[0].Item);
            Assert.AreEqual(1u, inventory2.Slots[1].Amount);
            Assert.AreEqual(item2, inventory2.Slots[1].Item);
            Assert.AreEqual(1u, inventory2.AvailableFreeSpaceFor(item1));

            Assert.IsTrue(connector.Move(inventory1, inventory2, 0, 1u));

            Assert.AreEqual(1u, inventory2.Slots[0].Amount);
            Assert.AreEqual(item2, inventory2.Slots[0].Item);
            Assert.AreEqual(1u, inventory2.Slots[1].Amount);
            Assert.AreEqual(item2, inventory2.Slots[1].Item);

            Assert.AreEqual(1u, inventory2.Slots[2].Amount);
            Assert.AreEqual(item1, inventory2.Slots[2].Item);

            Assert.IsTrue(inventory1.IsSlotFree(0));
        }

        [Test]
        public void can_move_item_if_source_slot_has_equal_amount_of_item_and_target_inventorys_free_space_is_more_than_that_amount__not_stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var inventory1 = builder.CreateInventory().SetInvMaxCapacity(3, 0).SetInvAvailableCapacity(3, 0).GetInventory(0);
            var inventory2 = builder.CreateInventory().SetInvMaxCapacity(3, 1).SetInvAvailableCapacity(3, 1).GetInventory(1);
            var item1 = builder.CreateItem().GetItem(0);
            var item2 = builder.CreateItem().GetItem(1);

            uint amount;

            amount = 1u;
            Assert.IsTrue(inventory2.AddItem(item2, ref amount));

            amount = 1u;
            Assert.IsTrue(inventory1.AddItem(item1, ref amount));

            var connector = builder.CreateConnector().GetConnector();

            Assert.AreEqual(1u, inventory1.Slots[0].Amount);
            Assert.AreEqual(item1, inventory1.Slots[0].Item);

            Assert.AreEqual(1u, inventory2.Slots[0].Amount);
            Assert.AreEqual(item2, inventory2.Slots[0].Item);
            Assert.AreEqual(2u, inventory2.AvailableFreeSpaceFor(item1));
            Assert.IsTrue(inventory2.IsSlotFree(1));
            Assert.IsTrue(inventory2.IsSlotFree(2));

            Assert.IsTrue(connector.Move(inventory1, inventory2, 0, 1u));

            Assert.AreEqual(1u, inventory2.Slots[0].Amount);
            Assert.AreEqual(item2, inventory2.Slots[0].Item);
            Assert.AreEqual(1u, inventory2.Slots[1].Amount);
            Assert.AreEqual(item1, inventory2.Slots[1].Item);
            Assert.IsTrue(inventory2.IsSlotFree(2));

            Assert.IsTrue(inventory1.IsSlotFree(0));
        }
        #endregion
    }
}
