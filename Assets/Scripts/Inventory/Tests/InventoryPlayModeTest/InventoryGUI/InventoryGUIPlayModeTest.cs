using NSubstitute;
using NUnit.Framework;
using System.Collections;
using UnityEngine.TestTools;
using VEngine.Inventory;
using VEngine.Inventory.GUI;

namespace VTest.Inventory.GUI
{
    public class InventoryGUIPlayModeTest 
    {
		#region InventryGUIBuilder
		[UnityTest]
		public IEnumerator are_CreateSlots_create_enough_slot_with_10()
		{
			uint max = 10u;
			uint available = 0u;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIBuilder(out var inventoryGUIBuilder, out var normalParent, out var dragParent);
			var testBuilder = InventoryTestBuilder.Create().CreateInventory().SetInvAvailableCapacity(available).SetInvMaxCapacity(max);
			var inventoryGUIModifier = Substitute.For<IInventoryGUIModifier>();
			yield return null;
			var inventory = testBuilder.GetInventory();
			testGUIBuilder.CreateSlotGUIContanier(out var slots);
			inventoryGUIBuilder.CreateGUISlots(inventory, inventoryGUIModifier, slots, normalParent).RefreshGUISlots(inventory, slots);

			Assert.AreEqual(max, normalParent.childCount);
			Assert.AreEqual(max, slots.Behaviours.Count);
			for (int i = 0; i < max; ++i)
			{
				Assert.AreEqual(i, slots.Behaviours[i].SlotGUI.SlotIndex);
				Assert.AreEqual(inventoryGUIModifier, slots.Behaviours[i].SlotGUI.InventoryGUIModifier);
			}

			testBuilder.Destroy();
			testGUIBuilder.Destroy();
		}

		[UnityTest]
		public IEnumerator are_CreateSlots_create_enough_slot_with_100()
		{
			uint max = 100u;
			uint available = 0u;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIBuilder(out var inventoryGUIBuilder, out var normalParent, out var dragParent);
			var testBuilder = InventoryTestBuilder.Create().CreateInventory().SetInvAvailableCapacity(available).SetInvMaxCapacity(max);
			var inventoryGUIModifier = Substitute.For<IInventoryGUIModifier>();
			yield return null;
			var inventory = testBuilder.GetInventory();
			testGUIBuilder.CreateSlotGUIContanier(out var slots);
			inventoryGUIBuilder.CreateGUISlots(inventory, inventoryGUIModifier, slots, normalParent).RefreshGUISlots(inventory, slots);

			Assert.AreEqual(max, normalParent.childCount);
			Assert.AreEqual(max, slots.Behaviours.Count);
			for (int i = 0; i < max; ++i)
			{
				Assert.AreEqual(i, slots.Behaviours[i].SlotGUI.SlotIndex);
				Assert.AreEqual(inventoryGUIModifier, slots.Behaviours[i].SlotGUI.InventoryGUIModifier);
			}

			testBuilder.Destroy();
			testGUIBuilder.Destroy();
		}

		[UnityTest]
		public IEnumerator are_slots_available_good_after_set_if_available_slot_is_0_and_max_is_20()
		{
			uint max = 20u;
			uint available = 0u;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIBuilder(out var inventoryGUIBuilder, out var normalParent, out var dragParent);
			var testBuilder = InventoryTestBuilder.Create().CreateInventory().SetInvAvailableCapacity(available).SetInvMaxCapacity(max);
			var inventoryGUIModifier = Substitute.For<IInventoryGUIModifier>();
			yield return null;
			var inventory = testBuilder.GetInventory();
			testGUIBuilder.CreateSlotGUIContanier(out var slots);
			inventoryGUIBuilder.CreateGUISlots(inventory, inventoryGUIModifier, slots, normalParent).RefreshGUISlots(inventory, slots);

			for (int i = 0; i < max; ++i)
			{
				Assert.AreEqual(i < available, slots.Behaviours[i].SlotGUI.IsAvailable);
			}
			testBuilder.Destroy();
			testGUIBuilder.Destroy();
		}

		[UnityTest]
		public IEnumerator are_slots_available_good_after_set_if_available_slot_is_10_and_max_is_20()
		{
			uint max = 20u;
			uint available = 10u;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIBuilder(out var inventoryGUIBuilder, out var normalParent, out var dragParent);
			var testBuilder = InventoryTestBuilder.Create().CreateInventory().SetInvAvailableCapacity(available).SetInvMaxCapacity(max);
			var inventoryGUIModifier = Substitute.For<IInventoryGUIModifier>();
			yield return null;
			var inventory = testBuilder.GetInventory();
			testGUIBuilder.CreateSlotGUIContanier(out var slots);
			inventoryGUIBuilder.CreateGUISlots(inventory, inventoryGUIModifier, slots, normalParent).RefreshGUISlots(inventory, slots);

			for (int i = 0; i < max; ++i)
			{
				Assert.AreEqual(i < available, slots.Behaviours[i].SlotGUI.IsAvailable);
			}
			testBuilder.Destroy();
			testGUIBuilder.Destroy();
		}

		[UnityTest]
		public IEnumerator are_slots_available_good_after_set_if_available_slot_is_20_and_max_is_20()
		{
			uint max = 20u;
			uint available = 20u;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIBuilder(out var inventoryGUIBuilder, out var normalParent, out var dragParent);
			var testBuilder = InventoryTestBuilder.Create().CreateInventory().SetInvAvailableCapacity(available).SetInvMaxCapacity(max);
			var inventoryGUIModifier = Substitute.For<IInventoryGUIModifier>();
			yield return null;
			var inventory = testBuilder.GetInventory();
			testGUIBuilder.CreateSlotGUIContanier(out var slots);
			inventoryGUIBuilder.CreateGUISlots(inventory, inventoryGUIModifier, slots, normalParent).RefreshGUISlots(inventory, slots);

			for (int i = 0; i < max; ++i)
			{
				Assert.AreEqual(i < available, slots.Behaviours[i].SlotGUI.IsAvailable);
			}
			testBuilder.Destroy();
			testGUIBuilder.Destroy();
		}

		[UnityTest]
		public IEnumerator are_free_slots_good_after_set_if_available_slot_is_0_and_max_is_20_without_item()
		{
			uint max = 20u;
			uint available = 0u;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIBuilder(out var inventoryGUIBuilder, out var normalParent, out var dragParent);
			var testBuilder = InventoryTestBuilder.Create().CreateInventory().SetInvAvailableCapacity(available).SetInvMaxCapacity(max);
			var inventoryGUIModifier = Substitute.For<IInventoryGUIModifier>();
			yield return null;
			var inventory = testBuilder.GetInventory();
			testGUIBuilder.CreateSlotGUIContanier(out var slots);
			inventoryGUIBuilder.CreateGUISlots(inventory, inventoryGUIModifier, slots, normalParent).RefreshGUISlots(inventory, slots);

			for (int i = 0; i < max; ++i)
			{
				Assert.AreEqual(i < available, slots.Behaviours[i].SlotGUI.IsFree);
			}
			testBuilder.Destroy();
			testGUIBuilder.Destroy();

		}

		[UnityTest]
		public IEnumerator are_free_slots_good_after_set_if_available_slot_is_10_and_max_is_20_without_item()
		{
			uint max = 20u;
			uint available = 10u;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIBuilder(out var inventoryGUIBuilder, out var normalParent, out var dragParent);
			var testBuilder = InventoryTestBuilder.Create().CreateInventory().SetInvAvailableCapacity(available).SetInvMaxCapacity(max);
			var inventoryGUIModifier = Substitute.For<IInventoryGUIModifier>();
			yield return null;
			var inventory = testBuilder.GetInventory();
			testGUIBuilder.CreateSlotGUIContanier(out var slots);
			inventoryGUIBuilder.CreateGUISlots(inventory, inventoryGUIModifier, slots, normalParent).RefreshGUISlots(inventory, slots);

			for (int i = 0; i < max; ++i)
			{
				Assert.AreEqual(i < available, slots.SlotGUIs[i].IsFree);
			}
			testBuilder.Destroy();
			testGUIBuilder.Destroy();

		}

		[UnityTest]
		public IEnumerator are_free_slots_good_after_set_if_available_slot_is_10_and_max_is_20_with_items()
		{
			uint max = 20u;
			uint available = 10u;
			uint itemNumber = 5u;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIBuilder(out var inventoryGUIBuilder, out var normalParent, out var dragParent);
			var testBuilder = InventoryTestBuilder.Create().CreateInventory().SetInvAvailableCapacity(available).SetInvMaxCapacity(max);
			var inventoryGUIModifier = Substitute.For<IInventoryGUIModifier>();

			testBuilder.CreateItem(itemNumber);
			var inventory = testBuilder.GetInventory();

			for (int i = 0; i < itemNumber; ++i)
			{
				var item = testBuilder.GetItem(i);
				var details = InventoryItemComponent.FindOn(item);
				details.StackCount = 10;
				var amount = 1u;
				inventory.AddItem(item, ref amount);
			}

			yield return null;
			testGUIBuilder.CreateSlotGUIContanier(out var slots);
			inventoryGUIBuilder.CreateGUISlots(inventory, inventoryGUIModifier, slots, normalParent).RefreshGUISlots(inventory, slots);

			for (int j = 0; j < max; ++j)
			{
				Assert.AreEqual(j < available && j >= itemNumber, slots.Behaviours[j].SlotGUI.IsFree);
			}

			for (int k = 0; k < itemNumber; ++k)
			{
				Assert.IsFalse(slots.Behaviours[k].SlotGUI.IsFree);
			}
			testBuilder.Destroy();
			testGUIBuilder.Destroy();

		}

		[UnityTest]
		public IEnumerator are_free_slots_good_after_set_if_available_slot_is_20_and_max_is_20_with_items()
		{
			uint max = 20u;
			uint available = 20u;
			uint itemNumber = 20u;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIBuilder(out var inventoryGUIBuilder, out var normalParent, out var dragParent);
			var testBuilder = InventoryTestBuilder.Create().CreateInventory().SetInvAvailableCapacity(available).SetInvMaxCapacity(max);
			var inventoryGUIModifier = Substitute.For<IInventoryGUIModifier>();

			testBuilder.CreateItem(itemNumber);
			var inventory = testBuilder.GetInventory();

			for (int i = 0; i < itemNumber; ++i)
			{
				var item = testBuilder.GetItem(i);
				var details = InventoryItemComponent.FindOn(item);
				details.StackCount = 10;
				var amount = 1u;
				inventory.AddItem(item, ref amount);
			}

			yield return null;
			testGUIBuilder.CreateSlotGUIContanier(out var slots);
			inventoryGUIBuilder.CreateGUISlots(inventory, inventoryGUIModifier, slots, normalParent).RefreshGUISlots(inventory, slots);

			for (int j = 0; j < max; ++j)
			{
				Assert.AreEqual(j < available && j >= itemNumber, slots.Behaviours[j].SlotGUI.IsFree);
			}

			for (int k = 0; k < itemNumber; ++k)
			{
				Assert.IsFalse(slots.Behaviours[k].SlotGUI.IsFree);
			}
			testBuilder.Destroy();
			testGUIBuilder.Destroy();
		}

		[UnityTest]
		public IEnumerator are_items_good_after_setupslots_without_items()
		{
			uint max = 20u;
			uint available = 20u;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIBuilder(out var inventoryGUIBuilder, out var normalParent, out var dragParent);
			var testBuilder = InventoryTestBuilder.Create().CreateInventory().SetInvAvailableCapacity(available).SetInvMaxCapacity(max);
			var inventoryGUIModifier = Substitute.For<IInventoryGUIModifier>();

			var inventory = testBuilder.GetInventory();

			yield return null;
			testGUIBuilder.CreateSlotGUIContanier(out var slots);
			inventoryGUIBuilder.CreateGUISlots(inventory, inventoryGUIModifier, slots, normalParent).RefreshGUISlots(inventory, slots);

			for (int j = 0; j < max; ++j)
			{
				Assert.AreEqual(null, slots.Behaviours[j].SlotGUI.Item);
			}

			testBuilder.Destroy();
			testGUIBuilder.Destroy();
		}

		[UnityTest]
		public IEnumerator are_items_good_after_setupslots_with_half_on_items()
		{
			uint max = 20u;
			uint available = 20u;
			uint itemNumber = 10u;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIBuilder(out var inventoryGUIBuilder, out var normalParent, out var dragParent);
			var testBuilder = InventoryTestBuilder.Create().CreateInventory().SetInvAvailableCapacity(available).SetInvMaxCapacity(max);
			var inventoryGUIModifier = Substitute.For<IInventoryGUIModifier>();

			testBuilder.CreateItem(itemNumber);
			var inventory = testBuilder.GetInventory();

			for (int i = 0; i < itemNumber; ++i)
			{
				var item = testBuilder.GetItem(i);
				var details = InventoryItemComponent.FindOn(item);
				details.StackCount = 10;
				var amount = 1u;
				inventory.AddItem(item, ref amount);
			}

			yield return null;
			testGUIBuilder.CreateSlotGUIContanier(out var slots);
			inventoryGUIBuilder.CreateGUISlots(inventory, inventoryGUIModifier, slots, normalParent).RefreshGUISlots(inventory, slots);

			for (int i = 0; i < itemNumber; ++i)
			{
				Assert.AreEqual(testBuilder.GetItem(i), slots.Behaviours[i].SlotGUI.Item);
			}

			for (int i = (int)itemNumber; i < max; ++i)
			{
				Assert.AreEqual(null, slots.Behaviours[i].SlotGUI.Item);
			}

			testBuilder.Destroy();
			testGUIBuilder.Destroy();
		}

		[UnityTest]
		public IEnumerator are_items_good_after_setupslots_with_full_on_items()
		{
			uint max = 20u;
			uint available = 20u;
			uint itemNumber = 20u;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIBuilder(out var inventoryGUIBuilder, out var normalParent, out var dragParent);
			var testBuilder = InventoryTestBuilder.Create().CreateInventory().SetInvAvailableCapacity(available).SetInvMaxCapacity(max);
			var inventoryGUIModifier = Substitute.For<IInventoryGUIModifier>();

			testBuilder.CreateItem(itemNumber);
			var inventory = testBuilder.GetInventory();

			for (int i = 0; i < itemNumber; ++i)
			{
				var item = testBuilder.GetItem(i);
				var details = InventoryItemComponent.FindOn(item);
				details.StackCount = 10;
				var amount = 1u;
				inventory.AddItem(item, ref amount);
			}

			yield return null;
			testGUIBuilder.CreateSlotGUIContanier(out var slots);
			inventoryGUIBuilder.CreateGUISlots(inventory, inventoryGUIModifier, slots, normalParent).RefreshGUISlots(inventory, slots);

			for (int i = 0; i < itemNumber; ++i)
			{
				Assert.AreEqual(testBuilder.GetItem(i), slots.Behaviours[i].SlotGUI.Item);
			}

			for (int i = (int)itemNumber; i < max; ++i)
			{
				Assert.AreEqual(null, slots.Behaviours[i].SlotGUI.Item);
			}

			testBuilder.Destroy();
			testGUIBuilder.Destroy();
		}
		#endregion

	}

}
