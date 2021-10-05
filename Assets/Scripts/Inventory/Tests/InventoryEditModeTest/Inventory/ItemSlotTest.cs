using NUnit.Framework;
using VEngine.Inventory;

namespace VTest.Inventory
{
	public class ItemSlotTest
	{
        #region set
        [Test]
        public void remain_1_amount_if_set_item_to_slot_with_2_amount_if_item_is_not_stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var item = builder.CreateItem().GetItem();
            var slot = builder.CreateSlot().GetSlot();
            uint amount = 2;
            Assert.IsTrue(slot.SetItem(item, ref amount));
            Assert.AreEqual(1, amount);
            Assert.AreEqual(builder.GetItem(), slot.ItemReference.Value);
            builder.Destroy();
        }

        [Test]
        public void remain_10_amount_if_set_item_to_slot_with_11_amount_if_item_is_not_stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var item = builder.CreateItem().GetItem();
            var slot = builder.CreateSlot().GetSlot();
            uint amount = 11;
            Assert.IsTrue(slot.SetItem(item, ref amount));
            Assert.AreEqual(10, amount);

            Assert.AreEqual(builder.GetItem(), slot.ItemReference.Value);
            builder.Destroy();
        }

        [Test]
        public void cant_set_item_to_slot_if_it_isnt_free()
        {
            var builder = InventoryTestBuilder.Create();
            var slot = builder.CreateItem().SetStackCount(10).CreateSlot().AttachItemToSlot().GetSlot();
            Assert.IsFalse(slot.IsFree);
            uint amount = 1;
            var item = InventoryTestBuilder.Create().CreateItem().GetItem();
            Assert.IsFalse(slot.SetItem(item, ref amount));
            Assert.AreEqual(builder.GetItem(), slot.ItemReference.Value);
            builder.Destroy();
        }

        [Test]
        public void can_set_item_to_slot_if_it_is_free_and_item_is_stackable_and_stackcount_is_10_and_amount_is_1()
        {
            var builder = InventoryTestBuilder.Create();
            var slot = builder.CreateSlot().GetSlot();
            Assert.IsTrue(slot.IsFree);
            uint amount = 1;
            var item = builder.CreateItem().SetStackCount(10).GetItem();
            Assert.IsTrue(slot.SetItem(item, ref amount));
            Assert.AreEqual(1, slot.Amount);
            Assert.AreEqual(0, amount);

            Assert.AreEqual(builder.GetItem(), slot.ItemReference.Value);
            builder.Destroy();
        }

        [Test]
        public void can_set_item_to_slot_if_it_is_free_and_item_is_stackable_and_stackcount_is_10_and_amount_is_10()
        {
            var builder = InventoryTestBuilder.Create();
            var slot = builder.CreateSlot().GetSlot();
            Assert.IsTrue(slot.IsFree);
            uint amount = 10;
            var item = builder.CreateItem().SetStackCount(10).GetItem();
            Assert.IsTrue(slot.SetItem(item, ref amount));
            Assert.AreEqual(10, slot.Amount);
            Assert.AreEqual(0, amount);

            Assert.AreEqual(builder.GetItem(), slot.ItemReference.Value);
            builder.Destroy();
        }


        [Test]
        public void can_set_item_to_slot_if_it_is_free_and_item_is_stackable_and_stackcount_is_10_and_amount_is_20()
        {
            var builder = InventoryTestBuilder.Create();
            var slot = builder.CreateSlot().GetSlot();
            Assert.IsTrue(slot.IsFree);
            uint amount = 20;
            var item = builder.CreateItem().SetStackCount(10).GetItem();
            Assert.IsTrue(slot.SetItem(item, ref amount));
            Assert.AreEqual(10, slot.Amount);
            Assert.AreEqual(10, amount);

            Assert.AreEqual(builder.GetItem(), slot.ItemReference.Value);
            builder.Destroy();
        }

        [Test]
        public void can_set_item_to_slot_if_it_is_free_and_item_isnt_stackable_and_amount_is_1()
        {
            var builder = InventoryTestBuilder.Create();
            var slot = builder.CreateSlot().GetSlot();
            Assert.IsTrue(slot.IsFree);
            uint amount = 1;
            var item = builder.CreateItem().GetItem();
            Assert.IsTrue(slot.SetItem(item, ref amount));
            Assert.AreEqual(1, slot.Amount);
            Assert.AreEqual(0, amount);

            Assert.AreEqual(builder.GetItem(), slot.ItemReference.Value);
            builder.Destroy();
        }

        [Test]
        public void can_set_item_to_slot_if_it_is_free_and_item_isnt_stackable_and_amount_is_10()
        {
            var builder = InventoryTestBuilder.Create();
            var slot = builder.CreateSlot().GetSlot();
            Assert.IsTrue(slot.IsFree);
            uint amount = 10;
            var item = builder.CreateItem().GetItem();
            Assert.IsTrue(slot.SetItem(item, ref amount));
            Assert.AreEqual(1, slot.Amount);
            Assert.AreEqual(9, amount);

            Assert.AreEqual(builder.GetItem(), slot.ItemReference.Value);
            builder.Destroy();
        }
        #endregion

        #region add
        [Test]
        public void cant_add_other_item_to_slot()
        {
            var builder = InventoryTestBuilder.Create();
            var slot = builder.CreateItem().SetStackCount(10).CreateSlot().AttachItemToSlot().GetSlot();
            Assert.IsFalse(slot.IsFree);
            uint amount = 1;
            var item = InventoryTestBuilder.Create().CreateItem().GetItem();
            Assert.IsFalse(slot.AddItem(item, ref amount));
            Assert.AreEqual(builder.GetItem(), slot.ItemReference.Value);
        }

        [Test]
        public void cant_add_same_item_to_slot_if_item_isnt_stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var slot = builder.CreateItem().CreateSlot().AttachItemToSlot().GetSlot();
            Assert.IsFalse(slot.IsFree);
            uint amount = 1;
            var item = builder.GetItem();
            var component = InventoryItemComponent.FindOn(item);
            Assert.IsFalse(component.IsStackable);
            Assert.IsFalse(slot.AddItem(item, ref amount));
            Assert.AreEqual(builder.GetItem(), slot.ItemReference.Value);
        }

        [Test]
        public void cant_add_same_item_to_slot_if_item_is_stackable_but_stack_is_full()
        {
            var builder = InventoryTestBuilder.Create();
            var slot = builder.CreateItem().SetStackCount(10).CreateSlot().AttachItemToSlot(10).GetSlot();
            Assert.IsFalse(slot.IsFree);
            uint amount = 1;
            var item = builder.GetItem();
            Assert.IsFalse(slot.AddItem(item, ref amount));
            Assert.AreEqual(builder.GetItem(), slot.ItemReference.Value);
        }

        [Test]
        public void can_add_same_item_to_slot_if_item_is_stackable_with_stack_count_10_and_current_amount_1_and_adding_amount_1()
        {
            var builder = InventoryTestBuilder.Create();
            var slot = builder.CreateItem().SetStackCount(10).CreateSlot().AttachItemToSlot(1).GetSlot();
            Assert.IsFalse(slot.IsFree);
            uint amount = 1;
            var item = builder.GetItem();
            Assert.IsTrue(slot.AddItem(item, ref amount));
            Assert.AreEqual(0, amount);
            Assert.AreEqual(2, slot.Amount);
        }

        [Test]
        public void can_add_same_item_to_slot_if_item_is_stackable_with_stack_count_10_and_current_amount_5_and_adding_amount_5()
        {
            var builder = InventoryTestBuilder.Create();
            var slot = builder.CreateItem().SetStackCount(10).CreateSlot().AttachItemToSlot(5).GetSlot();
            Assert.IsFalse(slot.IsFree);
            uint amount = 5;
            var item = builder.GetItem();
            Assert.IsTrue(slot.AddItem(item, ref amount));
            Assert.AreEqual(0, amount);
            Assert.AreEqual(10, slot.Amount);
        }

        [Test]
        public void can_add_same_item_to_slot_if_item_is_stackable_with_stack_count_10_and_current_amount_5_and_adding_amount_6_but_after_remaining_amount_in_slot_is_1()
        {
            var builder = InventoryTestBuilder.Create();
            var slot = builder.CreateItem().SetStackCount(10).CreateSlot().AttachItemToSlot(5).GetSlot();
            Assert.IsFalse(slot.IsFree);
            uint amount = 6;
            var item = builder.GetItem();
            Assert.IsTrue(slot.AddItem(item, ref amount));
            Assert.AreEqual(1, amount);
            Assert.AreEqual(10, slot.Amount);
        }

        [Test]
        public void can_add_same_item_to_slot_if_item_is_stackable_with_stack_count_10_and_current_amount_5_and_adding_amount_10_but_after_remaining_amount_in_slot_is_5()
        {
            var builder = InventoryTestBuilder.Create();
            var slot = builder.CreateItem().SetStackCount(10).CreateSlot().AttachItemToSlot(5).GetSlot();
            Assert.IsFalse(slot.IsFree);
            uint amount = 10;
            var item = builder.GetItem();
            Assert.IsTrue(slot.AddItem(item, ref amount));
            Assert.AreEqual(5, amount);
            Assert.AreEqual(10, slot.Amount);
        }

        [Test]
        public void can_add_same_item_to_slot_if_item_isnt_stackable_and_adding_amount_is_1()
        {
            var builder = InventoryTestBuilder.Create();
            var slot = builder.CreateItem().CreateSlot().AttachItemToSlot(1).GetSlot();
            Assert.IsFalse(slot.IsFree);
            uint amount = 1;
            var item = builder.GetItem();
            Assert.IsFalse(slot.AddItem(item, ref amount));
            Assert.AreEqual(1, amount);
            Assert.AreEqual(1, slot.Amount);
        }

        [Test]
        public void can_add_same_item_to_slot_if_item_isnt_stackable_and_adding_amount_is_10()
        {
            var builder = InventoryTestBuilder.Create();
            var slot = builder.CreateItem().CreateSlot().AttachItemToSlot(1).GetSlot();
            Assert.IsFalse(slot.IsFree);
            uint amount = 10;
            var item = builder.GetItem();
            Assert.IsFalse(slot.AddItem(item, ref amount));
            Assert.AreEqual(10, amount);
            Assert.AreEqual(1, slot.Amount);
        }
        #endregion

        #region remove
        [Test]
        public void cant_remove_item_from_free_slot()
        {
            var builder = InventoryTestBuilder.Create();
            var slot = builder.CreateSlot().GetSlot();
            Assert.IsTrue(slot.IsFree);
            uint amount = 1;
            var item = InventoryTestBuilder.Create().CreateItem().GetItem();
            Assert.IsFalse(slot.RemoveItem(item, ref amount));
            Assert.IsTrue(slot.IsFree);

            Assert.AreEqual(null, slot.ItemReference.Value);
            builder.Destroy();
        }

        [Test]
        public void cant_remove_other_item_from_slot()
        {
            var builder = InventoryTestBuilder.Create();
            var slot = builder.CreateItem().SetStackCount(10).CreateSlot().AttachItemToSlot(10).GetSlot();
            Assert.IsFalse(slot.IsFree);
            uint amount = 1;
            var item = InventoryTestBuilder.Create().CreateItem().GetItem();
            Assert.IsFalse(slot.RemoveItem(item, ref amount));
            Assert.IsFalse(slot.IsFree);

            Assert.AreEqual(builder.GetItem(), slot.ItemReference.Value);
            builder.Destroy();
        }

        [Test]
        public void cant_remove_0_item_from_slot_if_item_is_stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var slot = builder.CreateItem().SetStackCount(10).CreateSlot().AttachItemToSlot(1).GetSlot();
            Assert.IsFalse(slot.IsFree);
            uint amount = 0;
            var item = builder.GetItem();
            Assert.AreEqual(1, slot.Amount);
            Assert.IsFalse(slot.RemoveItem(item, ref amount));
            Assert.IsFalse(slot.IsFree);

            Assert.AreEqual(builder.GetItem(), slot.ItemReference.Value);
            builder.Destroy();
        }

        [Test]
        public void cant_remove_0_item_from_slot_if_item_is_not_stackable()
        {
            var builder = InventoryTestBuilder.Create();
            var slot = builder.CreateItem().CreateSlot().AttachItemToSlot(1).GetSlot();
            Assert.IsFalse(slot.IsFree);
            uint amount = 0;
            var item = builder.GetItem();
            Assert.AreEqual(1, slot.Amount);
            Assert.IsFalse(slot.RemoveItem(item, ref amount));
            Assert.IsFalse(slot.IsFree);

            Assert.AreEqual(builder.GetItem(), slot.ItemReference.Value);
            builder.Destroy();
        }

        [Test]
        public void can_remove_1_item_from_slot_if_item_is_stackable_and_stackcount_is_10_and_amount_10_after_after_remaining_amount_in_slot_is_9()
        {
            var builder = InventoryTestBuilder.Create();
            var slot = builder.CreateItem().SetStackCount(10).CreateSlot().AttachItemToSlot(10).GetSlot();
            Assert.IsFalse(slot.IsFree);
            uint amount = 1;
            var item = builder.GetItem();
            Assert.IsTrue(slot.RemoveItem(item, ref amount));
            Assert.IsFalse(slot.IsFree);
            Assert.AreEqual(0, amount);
            Assert.AreEqual(9, slot.Amount);

            Assert.AreEqual(builder.GetItem(), slot.ItemReference.Value);
            builder.Destroy();
        }

        [Test]
        public void can_remove_5_item_from_slot_if_item_is_stackable_and_stackcount_is_10_and_amount_10_after_after_remaining_amount_in_slot_is_5()
        {
            var builder = InventoryTestBuilder.Create();
            var slot = builder.CreateItem().SetStackCount(10).CreateSlot().AttachItemToSlot(10).GetSlot();
            Assert.IsFalse(slot.IsFree);
            uint amount = 5;
            var item = builder.GetItem();
            Assert.IsTrue(slot.RemoveItem(item, ref amount));
            Assert.IsFalse(slot.IsFree);
            Assert.AreEqual(0, amount);
            Assert.AreEqual(5, slot.Amount);

            Assert.AreEqual(builder.GetItem(), slot.ItemReference.Value);
            builder.Destroy();
        }

        [Test]
        public void can_remove_10_item_from_slot_if_item_is_stackable_and_stackcount_is_10_and_amount_10_after_after_remaining_amount_in_slot_is_0_and_slot_is_free()
        {
            var builder = InventoryTestBuilder.Create();
            var slot = builder.CreateItem().SetStackCount(10).CreateSlot().AttachItemToSlot(10).GetSlot();
            Assert.IsFalse(slot.IsFree);
            uint amount = 10;
            var item = builder.GetItem();
            Assert.IsTrue(slot.RemoveItem(item, ref amount));
            Assert.IsTrue(slot.IsFree);
            Assert.AreEqual(0, amount);
            Assert.AreEqual(0, slot.Amount);

            Assert.AreEqual(null, slot.ItemReference.Value);
            builder.Destroy();
        }

        [Test]
        public void can_remove_11_item_from_slot_if_item_is_stackable_and_stackcount_is_10_and_amount_10_after_after_remaining_amount_in_slot_is_0_and_slot_is_free_but_removable_amount_remainds_1()
        {
            var builder = InventoryTestBuilder.Create();
            var slot = builder.CreateItem().SetStackCount(10).CreateSlot().AttachItemToSlot(10).GetSlot();
            Assert.IsFalse(slot.IsFree);
            uint amount = 11;
            var item = builder.GetItem();
            Assert.IsTrue(slot.RemoveItem(item, ref amount));
            Assert.IsTrue(slot.IsFree);
            Assert.AreEqual(1, amount);
            Assert.AreEqual(0, slot.Amount);

            Assert.AreEqual(null, slot.ItemReference.Value);
            builder.Destroy();
        }

        [Test]
        public void can_remove_20_item_from_slot_if_item_is_stackable_and_stackcount_is_10_and_amount_10_after_after_remaining_amount_in_slot_is_0_and_slot_is_free_but_removable_amount_remainds_10()
        {
            var builder = InventoryTestBuilder.Create();
            var slot = builder.CreateItem().SetStackCount(10).CreateSlot().AttachItemToSlot(10).GetSlot();
            Assert.IsFalse(slot.IsFree);
            uint amount = 20;
            var item = builder.GetItem();
            Assert.IsTrue(slot.RemoveItem(item, ref amount));
            Assert.IsTrue(slot.IsFree);
            Assert.AreEqual(10, amount);
            Assert.AreEqual(0, slot.Amount);

            Assert.AreEqual(null, slot.ItemReference.Value);
            builder.Destroy();
        }

        [Test]
        public void can_remove_1_item_from_slot_if_item_is_not_stackable_after_after_remaining_amount_in_slot_is_0_and_slot_is_free_but_removable_amount_remainds_0()
        {
            var builder = InventoryTestBuilder.Create();
            var slot = builder.CreateItem().SetStackCount(1).CreateSlot().AttachItemToSlot(1).GetSlot();
            Assert.IsFalse(slot.IsFree);
            uint amount = 1;
            var item = builder.GetItem();
            Assert.IsTrue(slot.RemoveItem(item, ref amount));
            Assert.IsTrue(slot.IsFree);
            Assert.AreEqual(0, amount);
            Assert.AreEqual(0, slot.Amount);

            Assert.AreEqual(null, slot.ItemReference.Value);
            builder.Destroy();
        }

        [Test]
        public void can_remove_10_item_from_slot_if_item_is_not_stackable_after_after_remaining_amount_in_slot_is_0_and_slot_is_free_but_removable_amount_remainds_9()
        {
            var builder = InventoryTestBuilder.Create();
            var slot = builder.CreateItem().SetStackCount(1).CreateSlot().AttachItemToSlot(1).GetSlot();
            Assert.IsFalse(slot.IsFree);
            uint amount = 10;
            var item = builder.GetItem();
            Assert.IsTrue(slot.RemoveItem(item, ref amount));
            Assert.IsTrue(slot.IsFree);
            Assert.AreEqual(9, amount);
            Assert.AreEqual(0, slot.Amount);

            Assert.AreEqual(null, slot.ItemReference.Value);
            builder.Destroy();
        }
        #endregion
    }
}
