using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using VEngine.Inventory;
using VEngine.Inventory.GUI;
using VEngine.Items;

namespace VTest.Inventory.GUI
{
	public class InventoryGUIEditModeTest
	{
		private InventoryGUIItemComponent GetDetails(IItem item)
		{
			return InventoryGUIItemComponent.FindOn(item);
		}

		#region itemgui
		[Test]
		public void is_attributes_valid_after_SetItem()
		{
			var builder = InventoryGUITestBuilder.Create().CreateItemGUI(out var itemGUI, out var avatarImage, out var dragPressWindowTime, out var rectTransform, out var isDragEnabledRef);
			builder.CreateFakesAttributesForItemGUI(out var item);
			itemGUI.Item = item;
			Assert.AreEqual(item, itemGUI.Item);
			Assert.AreEqual(GetDetails(item).Avatar, itemGUI.Avatar.sprite);
			Assert.AreEqual(true, itemGUI.Avatar.enabled);
			builder.Destroy();
		}

		[Test]
		public void is_attributes_valid_after_ClearItem()
		{
			var builder = InventoryGUITestBuilder.Create().CreateItemGUI(out var itemGUI, out var avatarImage, out var dragPressWindowTime, out var rectTransform, out var isDragEnabledRef);
			builder.CreateFakesAttributesForItemGUI(out var item);
			itemGUI.Item = item;
			itemGUI.ClearItem();
			Assert.AreEqual(null, itemGUI.Item);
			Assert.AreEqual(false, itemGUI.Avatar.enabled);
			builder.Destroy();
		}

		[Test]
		public void is_slot_valid_after_SlotSlot()
		{
			var builder = InventoryGUITestBuilder.Create().CreateItemGUI(out var itemGUI, out var avatarImage, out var dragPressWindowTime, out var rectTransform, out var isDragEnabledRef);
			var slotGUI = Substitute.For<ISlotGUI>();
			itemGUI.SetSlot(slotGUI);
			Assert.AreEqual(slotGUI, itemGUI.SlotGUI);
			builder.Destroy();
		}

		[Test]
		public void is_slot_valid_after_ClearItem()
		{
			var builder = InventoryGUITestBuilder.Create().CreateItemGUI(out var itemGUI, out var avatarImage, out var dragPressWindowTime, out var rectTransform, out var isDragEnabledRef);
			var slotGUI = Substitute.For<ISlotGUI>();
			itemGUI.SetSlot(slotGUI);
			itemGUI.ClearItem();
			Assert.AreEqual(slotGUI, itemGUI.SlotGUI);
			builder.Destroy();
		}
		#endregion

		#region slotGUI
		#region InventoryGUI
		[Test]
		public void is_inventoryGUI_valid()
		{
			var inventoryGUIModifier = Substitute.For<IInventoryGUIModifier>();

			var builder = InventoryGUITestBuilder.Create();
			builder.CreateItemGUI(out var itemGUI, out var avatarImage, out var dragPressWindowTime, out var rectTransform, out var isDragEnabledRef);
			builder.CreateSlotGUI(out var slotGUI, 0, inventoryGUIModifier, itemGUI, out var rectTransformSlot, out var bgImage, out var amountText, out var spriteRef);

			Assert.AreEqual(inventoryGUIModifier, slotGUI.InventoryGUIModifier);

			builder.Destroy();
		}
		#endregion

		#region SlotIndex
		[Test]
		public void is_SlotIndex_valid_0()
		{
			var inventoryGUIModifier = Substitute.For<IInventoryGUIModifier>();

			var builder = InventoryGUITestBuilder.Create();
			builder.CreateItemGUI(out var itemGUI, out var avatarImage, out var dragPressWindowTime, out var rectTransform, out var isDragEnabledRef);
			builder.CreateSlotGUI(out var slotGUI, 0, inventoryGUIModifier, itemGUI, out var rectTransformSlot, out var bgImage, out var amountText, out var spriteRef);

			Assert.AreEqual(0, slotGUI.SlotIndex);

			builder.Destroy();
		}

		[Test]
		public void is_SlotIndex_valid_10()
		{
			var inventoryGUIModifier = Substitute.For<IInventoryGUIModifier>();

			var builder = InventoryGUITestBuilder.Create();
			builder.CreateItemGUI(out var itemGUI, out var avatarImage, out var dragPressWindowTime, out var rectTransform, out var isDragEnabledRef);
			builder.CreateSlotGUI(out var slotGUI, 10, inventoryGUIModifier, itemGUI, out var rectTransformSlot, out var bgImage, out var amountText, out var spriteRef);

			Assert.AreEqual(10, slotGUI.SlotIndex);

			builder.Destroy();
		}
		#endregion

		#region CurrentItem
		[Test]
		public void is_item_valid_after_SetItem()
		{
			var inventoryGUIModifier = Substitute.For<IInventoryGUIModifier>();

			var builderGUI = InventoryGUITestBuilder.Create();
			builderGUI.CreateItemGUI(out var itemGUI, out var avatarImage, out var dragPressWindowTime, out var rectTransform, out var isDragEnabledRef);
			builderGUI.CreateSlotGUI(out var slotGUI, 0, inventoryGUIModifier, itemGUI, out var rectTransformSlot, out var bgImage, out var amountText, out var spriteRef);

			builderGUI.CreateFakesAttributesForItemGUI(out var item);
			slotGUI.IsAvailable = true;
			slotGUI.SetItem(item, 1u);

			Assert.AreEqual(item, slotGUI.Item);
			Assert.AreEqual(GetDetails(item).Avatar, bgImage.sprite);

			builderGUI.Destroy();
		}

		[Test]
		public void is_item_valid_after_ClearItem()
		{
			var inventoryGUIModifier = Substitute.For<IInventoryGUIModifier>();

			var builderGUI = InventoryGUITestBuilder.Create();
			builderGUI.CreateItemGUI(out var itemGUI, out var avatarImage, out var dragPressWindowTime, out var rectTransform, out var isDragEnabledRef);
			builderGUI.CreateSlotGUI(out var slotGUI, 0, inventoryGUIModifier, itemGUI, out var rectTransformSlot, out var bgImage, out var amountText, out var spriteRef);

			builderGUI.CreateFakesAttributesForItemGUI(out var item);
			slotGUI.IsAvailable = true;
			slotGUI.SetItem(item, 10u);
			slotGUI.ClearItem();
			Assert.IsFalse(amountText.gameObject.activeSelf);
			Assert.IsFalse(avatarImage.enabled);
			Assert.AreEqual(null, itemGUI.Item);

			builderGUI.Destroy();
		}
		#endregion

		#region IsFree
		[Test]
		public void is_free_on_default()
		{
			var inventoryGUIModifier = Substitute.For<IInventoryGUIModifier>();

			var builderGUI = InventoryGUITestBuilder.Create();
			builderGUI.CreateItemGUI(out var itemGUI, out var avatarImage, out var dragPressWindowTime, out var rectTransform, out var isDragEnabledRef);
			builderGUI.CreateSlotGUI(out var slotGUI, 0, inventoryGUIModifier, itemGUI, out var rectTransformSlot, out var bgImage, out var amountText, out var spriteRef);

			builderGUI.CreateFakesAttributesForItemGUI(out var item);
			slotGUI.IsAvailable = true;

			Assert.IsTrue(slotGUI.IsFree);

			builderGUI.Destroy();
		}

		[Test]
		public void is_not_free_after_SetItem()
		{
			var inventoryGUIModifier = Substitute.For<IInventoryGUIModifier>();

			var builderGUI = InventoryGUITestBuilder.Create();
			builderGUI.CreateItemGUI(out var itemGUI, out var avatarImage, out var dragPressWindowTime, out var rectTransform, out var isDragEnabledRef);
			builderGUI.CreateSlotGUI(out var slotGUI, 0, inventoryGUIModifier, itemGUI, out var rectTransformSlot, out var bgImage, out var amountText, out var spriteRef);

			builderGUI.CreateFakesAttributesForItemGUI(out var item);
			slotGUI.IsAvailable = true;
			slotGUI.SetItem(item, 1u);

			Assert.IsFalse(slotGUI.IsFree);

			builderGUI.Destroy();
		}

		[Test]
		public void is_free_after_ClearItem()
		{
			var inventoryGUIModifier = Substitute.For<IInventoryGUIModifier>();

			var builderGUI = InventoryGUITestBuilder.Create();
			builderGUI.CreateItemGUI(out var itemGUI, out var avatarImage, out var dragPressWindowTime, out var rectTransform, out var isDragEnabledRef);
			builderGUI.CreateSlotGUI(out var slotGUI, 0, inventoryGUIModifier, itemGUI, out var rectTransformSlot, out var bgImage, out var amountText, out var spriteRef);

			builderGUI.CreateFakesAttributesForItemGUI(out var item);
			slotGUI.IsAvailable = true;
			slotGUI.SetItem(item, 10u);
			slotGUI.ClearItem();
			Assert.IsTrue(slotGUI.IsFree);

			builderGUI.Destroy();
		}
		#endregion

		#region Amount
		[Test]
		public void is_amount_valid_after_set_if_item_is_not_stackable()
		{
			var inventoryGUIModifier = Substitute.For<IInventoryGUIModifier>();

			var builderGUI = InventoryGUITestBuilder.Create();
			builderGUI.CreateItemGUI(out var itemGUI, out var avatarImage, out var dragPressWindowTime, out var rectTransform, out var isDragEnabledRef);
			builderGUI.CreateSlotGUI(out var slotGUI, 0, inventoryGUIModifier, itemGUI, out var rectTransformSlot, out var bgImage, out var amountText, out var spriteRef);

			builderGUI.CreateFakesAttributesForItemGUI(out var item);
			var inventoryDetails = InventoryItemComponent.FindOn(item);
			slotGUI.SetItem(item, 1u);
			Assert.IsFalse(amountText.gameObject.activeSelf);

			builderGUI.Destroy();
		}

		[Test]
		public void is_amount_valid_after_set_if_item_is_stackable_and_amount_is_1()
		{
			var inventoryGUIModifier = Substitute.For<IInventoryGUIModifier>();

			var builderGUI = InventoryGUITestBuilder.Create();
			builderGUI.CreateItemGUI(out var itemGUI, out var avatarImage, out var dragPressWindowTime, out var rectTransform, out var isDragEnabledRef);
			builderGUI.CreateSlotGUI(out var slotGUI, 0, inventoryGUIModifier, itemGUI, out var rectTransformSlot, out var bgImage, out var amountText, out var spriteRef);

			builderGUI.CreateFakesAttributesForItemGUI(out var item);
			var inventoryDetails = InventoryItemComponent.FindOn(item);
			inventoryDetails.StackCount = 10u;
			slotGUI.SetItem(item, 1u);
			Assert.IsTrue(amountText.enabled);
			Assert.AreEqual("1", amountText.text);

			builderGUI.Destroy();
		}

		[Test]
		public void is_amount_valid_after_set_if_item_is_stackable_and_amount_is_10()
		{
			var inventoryGUIModifier = Substitute.For<IInventoryGUIModifier>();

			var builderGUI = InventoryGUITestBuilder.Create();
			builderGUI.CreateItemGUI(out var itemGUI, out var avatarImage, out var dragPressWindowTime, out var rectTransform, out var isDragEnabledRef);
			builderGUI.CreateSlotGUI(out var slotGUI, 0, inventoryGUIModifier, itemGUI, out var rectTransformSlot, out var bgImage, out var amountText, out var spriteRef);

			builderGUI.CreateFakesAttributesForItemGUI(out var item);
			var inventoryDetails = InventoryItemComponent.FindOn(item);
			inventoryDetails.StackCount = 10u;
			slotGUI.SetItem(item, 10u);
			Assert.IsTrue(amountText.enabled);
			Assert.AreEqual("10", amountText.text);

			builderGUI.Destroy();
		}
		#endregion

		#region IsAvailable
		[Test]
		public void is_available_valid_after_set_true()
		{
			var inventoryGUIModifier = Substitute.For<IInventoryGUIModifier>();

			var builderGUI = InventoryGUITestBuilder.Create();
			builderGUI.CreateItemGUI(out var itemGUI, out var avatarImage, out var dragPressWindowTime, out var rectTransform, out var isDragEnabledRef);
			builderGUI.CreateSlotGUI(out var slotGUI, 0, inventoryGUIModifier, itemGUI, out var rectTransformSlot, out var bgImage, out var amountText, out var spriteRef);
			builderGUI.CreateFakesAttributesForItemGUI(out var item);
			slotGUI.SetItem(item, 10u);

			var spriteAvailable = Sprite.Create(null, new Rect(), Vector2.one);
			var spriteNotAvailable = Sprite.Create(null, new Rect(), Vector2.one);
			spriteRef.AvailableSprite.Returns(spriteAvailable);
			spriteRef.AvailableSprite.Returns(spriteNotAvailable);

			slotGUI.IsAvailable = true;
			Assert.AreEqual(spriteAvailable, bgImage.sprite);

			builderGUI.Destroy();
		}

		[Test]
		public void is_available_valid_after_set_false()
		{
			var inventoryGUIModifier = Substitute.For<IInventoryGUIModifier>();

			var builderGUI = InventoryGUITestBuilder.Create();
			builderGUI.CreateItemGUI(out var itemGUI, out var avatarImage, out var dragPressWindowTime, out var rectTransform, out var isDragEnabledRef);
			builderGUI.CreateSlotGUI(out var slotGUI, 0, inventoryGUIModifier, itemGUI, out var rectTransformSlot, out var bgImage, out var amountText, out var spriteRef);
			builderGUI.CreateFakesAttributesForItemGUI(out var item);
			slotGUI.SetItem(item, 10u);

			var spriteAvailable = Sprite.Create(null, new Rect(), Vector2.one);
			var spriteNotAvailable = Sprite.Create(null, new Rect(), Vector2.one);
			spriteRef.AvailableSprite.Returns(spriteAvailable);
			spriteRef.AvailableSprite.Returns(spriteNotAvailable);

			slotGUI.IsAvailable = false;
			Assert.AreEqual(spriteNotAvailable, bgImage.sprite);

			builderGUI.Destroy();
		}
		#endregion

		#region OnItemDropped
		[Test]
		public void OnItemDropped_call_move_if_target_slot_is_free()
		{
			var inventoryGUIModifier = Substitute.For<IInventoryGUIModifier>();

			var builderGUI = InventoryGUITestBuilder.Create();
			builderGUI.CreateItemGUI(out var itemGUI, out var avatarImage, out var dragPressWindowTime, out var rectTransform, out var isDragEnabledRef);
			builderGUI.CreateSlotGUI(out var slotGUI, 0, inventoryGUIModifier, itemGUI, out var rectTransformSlot, out var bgImage, out var amountText, out var spriteRef);

			builderGUI.CreateFakesAttributesForItemGUI(out var item);
			slotGUI.IsAvailable = true;
			Assert.IsTrue(slotGUI.IsFree);

			var droppedItemGUI = Substitute.For<IInventoryItemGUI>();
			var droppedItem = Substitute.For<IItem>();
			droppedItemGUI.Item.Returns(droppedItem);

			inventoryGUIModifier.ClearReceivedCalls();
			slotGUI.OnItemDropped(droppedItemGUI);
			inventoryGUIModifier.Received().MoveTo(slotGUI, droppedItemGUI);
			inventoryGUIModifier.DidNotReceive().StackTo(slotGUI, droppedItemGUI);
			inventoryGUIModifier.DidNotReceive().SwapWith(slotGUI, droppedItemGUI);

			builderGUI.Destroy();
		}

		[Test]
		public void OnItemDropped_call_stack_if_target_slot_has_same_item()
		{
			var inventoryGUIModifier = Substitute.For<IInventoryGUIModifier>();

			var builderGUI = InventoryGUITestBuilder.Create();
			builderGUI.CreateItemGUI(out var itemGUI, out var avatarImage, out var dragPressWindowTime, out var rectTransform, out var isDragEnabledRef);
			builderGUI.CreateSlotGUI(out var slotGUI, 0, inventoryGUIModifier, itemGUI, out var rectTransformSlot, out var bgImage, out var amountText, out var spriteRef);

			builderGUI.CreateFakesAttributesForItemGUI(out var item);
			slotGUI.IsAvailable = true;
			slotGUI.SetItem(item, 1u);
			Assert.IsFalse(slotGUI.IsFree);

			var droppedItemGUI = Substitute.For<IInventoryItemGUI>();
			droppedItemGUI.Item.Returns(item);

			Assert.AreEqual(droppedItemGUI.Item, slotGUI.Item);

			inventoryGUIModifier.ClearReceivedCalls();
			slotGUI.OnItemDropped(droppedItemGUI);
			inventoryGUIModifier.DidNotReceive().MoveTo(slotGUI, droppedItemGUI);
			inventoryGUIModifier.Received().StackTo(slotGUI, droppedItemGUI);
			inventoryGUIModifier.DidNotReceive().SwapWith(slotGUI, droppedItemGUI);

			builderGUI.Destroy();
		}

		[Test]
		public void OnItemDropped_call_stack_if_target_swap_has_different_item()
		{
			var inventoryGUIModifier = Substitute.For<IInventoryGUIModifier>();

			var builderGUI = InventoryGUITestBuilder.Create();
			builderGUI.CreateItemGUI(out var itemGUI, out var avatarImage, out var dragPressWindowTime, out var rectTransform, out var isDragEnabledRef);
			builderGUI.CreateSlotGUI(out var slotGUI, 0, inventoryGUIModifier, itemGUI, out var rectTransformSlot, out var bgImage, out var amountText, out var spriteRef);

			builderGUI.CreateFakesAttributesForItemGUI(out var item);
			slotGUI.IsAvailable = true;
			slotGUI.SetItem(item, 1u);
			Assert.IsFalse(slotGUI.IsFree);

			var droppedItemGUI = Substitute.For<IInventoryItemGUI>();
			var droppedItem = Substitute.For<IItem>();
			droppedItemGUI.Item.Returns(droppedItem);

			Assert.AreNotEqual(droppedItemGUI.Item, slotGUI.Item);

			inventoryGUIModifier.ClearReceivedCalls();
			slotGUI.OnItemDropped(droppedItemGUI);
			inventoryGUIModifier.DidNotReceive().MoveTo(slotGUI, droppedItemGUI);
			inventoryGUIModifier.DidNotReceive().StackTo(slotGUI, droppedItemGUI);
			inventoryGUIModifier.Received().SwapWith(slotGUI, droppedItemGUI);

			builderGUI.Destroy();
		}
		#endregion
		#endregion

		#region InventoryGUI
		[Test]
		public void inventoryParent_gameObject_is_active_on_open()
		{
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUI(out var inventoryGUI, out var fakeBuilder, out var fakeInventory, out var parent);
			parent.gameObject.SetActive(false);
			inventoryGUI.Open(true);
			Assert.IsTrue(parent.activeSelf);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void inventoryParent_gameObject_is_not_active_on_close()
		{
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUI(out var inventoryGUI, out var fakeBuilder, out var fakeInventory, out var parent);
			parent.gameObject.SetActive(true);
			inventoryGUI.Open(false);
			Assert.IsFalse(parent.activeSelf);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void builder_RefreshGUISlots_is_called_on_open()
		{
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUI(out var inventoryGUI, out var fakeBuilder, out var fakeInventory, out var parent);
			fakeBuilder.ClearReceivedCalls();
			inventoryGUI.Open(true);
			fakeBuilder.Received().RefreshGUISlots(fakeInventory.Data, Arg.Any<List<ISlotGUI>>());

			testGUIBuilder.Destroy();
		}

		[Test]
		public void builder_RefreshGUISlots_is_not_called_on_close()
		{
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUI(out var inventoryGUI, out var fakeBuilder, out var fakeInventory, out var parent);
			fakeBuilder.ClearReceivedCalls();
			inventoryGUI.Open(false);
			fakeBuilder.DidNotReceive().RefreshGUISlots(fakeInventory.Data, Arg.Any<List<ISlotGUI>>());

			testGUIBuilder.Destroy();
		}

		//TODO
		//Depricated [Test]
		public void builder_RefreshGUISlots_is_called_if_move_was_success()
		{
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUI(out var inventoryGUI, out var fakeBuilder, out var fakeInventory, out var parent);
			fakeInventory.Service.MoveItem(Arg.Any<int>(), Arg.Any<int>()).Returns(true);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			itemGUISlot.SlotIndex.Returns(0);
			itemGUI.SlotGUI.Returns(itemGUISlot);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(1);
			fakeBuilder.ClearReceivedCalls();
			inventoryGUI.MoveTo(targetSlot, itemGUI);
			fakeBuilder.Received().RefreshGUISlots(fakeInventory.Data, Arg.Any<List<ISlotGUI>>());

			testGUIBuilder.Destroy();
		}

		[Test]
		public void builder_RefreshGUISlots_is_not_called_if_move_was_not_success()
		{
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUI(out var inventoryGUI, out var fakeBuilder, out var fakeInventory, out var parent);
			fakeInventory.Service.MoveItem(Arg.Any<int>(), Arg.Any<int>()).Returns(false);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			itemGUISlot.SlotIndex.Returns(0);
			itemGUI.SlotGUI.Returns(itemGUISlot);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(1);
			fakeBuilder.ClearReceivedCalls();
			inventoryGUI.MoveTo(targetSlot, itemGUI);
			fakeBuilder.DidNotReceive().RefreshGUISlots(fakeInventory.Data, Arg.Any<List<ISlotGUI>>());

			testGUIBuilder.Destroy();
		}

		//TODO
		//Depricated [Test]
		public void builder_RefreshGUISlots_is_called_if_stack_was_success()
		{
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUI(out var inventoryGUI, out var fakeBuilder, out var fakeInventory, out var parent);
			fakeInventory.Service.MoveItem(Arg.Any<int>(), Arg.Any<int>()).Returns(true);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			itemGUISlot.SlotIndex.Returns(0);
			itemGUI.SlotGUI.Returns(itemGUISlot);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(1);
			fakeBuilder.ClearReceivedCalls();
			inventoryGUI.StackTo(targetSlot, itemGUI);
			fakeBuilder.Received().RefreshGUISlots(fakeInventory.Data, Arg.Any<List<ISlotGUI>>());

			testGUIBuilder.Destroy();
		}

		//TODO
		//Depricated [Test]
		public void builder_RefreshGUISlots_is_not_called_if_stack_was_not_success()
		{
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUI(out var inventoryGUI, out var fakeBuilder, out var fakeInventory, out var parent);
			fakeInventory.Service.MoveItem(Arg.Any<int>(), Arg.Any<int>()).Returns(true);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			itemGUISlot.SlotIndex.Returns(0);
			itemGUI.SlotGUI.Returns(itemGUISlot);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(1);
			fakeBuilder.ClearReceivedCalls();
			inventoryGUI.StackTo(targetSlot, itemGUI);
			fakeBuilder.Received().RefreshGUISlots(fakeInventory.Data, Arg.Any<List<ISlotGUI>>());

			testGUIBuilder.Destroy();
		}

		//TODO
		//Depricated [Test]
		public void builder_RefreshGUISlots_is_called_if_swap_was_success()
		{
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUI(out var inventoryGUI, out var fakeBuilder, out var fakeInventory, out var parent);
			fakeInventory.Service.MoveItem(Arg.Any<int>(), Arg.Any<int>()).Returns(true);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			itemGUISlot.SlotIndex.Returns(0);
			itemGUI.SlotGUI.Returns(itemGUISlot);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(1);
			fakeBuilder.ClearReceivedCalls();
			inventoryGUI.SwapWith(targetSlot, itemGUI);
			fakeBuilder.Received().RefreshGUISlots(fakeInventory.Data, Arg.Any<List<ISlotGUI>>());

			testGUIBuilder.Destroy();
		}

		//TODO
		//Depricated [Test]
		public void builder_RefreshGUISlots_is_not_called_if_swap_was_not_success()
		{
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUI(out var inventoryGUI, out var fakeBuilder, out var fakeInventory, out var parent);
			fakeInventory.Service.MoveItem(Arg.Any<int>(), Arg.Any<int>()).Returns(true);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			itemGUISlot.SlotIndex.Returns(0);
			itemGUI.SlotGUI.Returns(itemGUISlot);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(1);
			fakeBuilder.ClearReceivedCalls();
			inventoryGUI.SwapWith(targetSlot, itemGUI);
			fakeBuilder.Received().RefreshGUISlots(fakeInventory.Data, Arg.Any<List<ISlotGUI>>());

			testGUIBuilder.Destroy();
		}

		[Test]
		public void MoveTo_call_inventory_move_with_right_params_0_1()
		{
			int sourceIndex = 0;
			int targetIndex = 1;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUI(out var inventoryGUI, out var fakeBuilder, out var fakeInventory, out var parent);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);
			fakeInventory.ClearReceivedCalls();
			inventoryGUI.MoveTo(targetSlot, itemGUI);

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void MoveTo_call_inventory_move_with_right_params_0_10()
		{
			int sourceIndex = 0;
			int targetIndex = 10;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUI(out var inventoryGUI, out var fakeBuilder, out var fakeInventory, out var parent);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);
			fakeInventory.ClearReceivedCalls();
			inventoryGUI.MoveTo(targetSlot, itemGUI);

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void MoveTo_call_inventory_move_with_right_params_10_0()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUI(out var inventoryGUI, out var fakeBuilder, out var fakeInventory, out var parent);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);
			fakeInventory.ClearReceivedCalls();
			inventoryGUI.MoveTo(targetSlot, itemGUI);

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void StackTo_call_inventory_move_with_right_params_0_1()
		{
			int sourceIndex = 0;
			int targetIndex = 1;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUI(out var inventoryGUI, out var fakeBuilder, out var fakeInventory, out var parent);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);
			fakeInventory.ClearReceivedCalls();
			inventoryGUI.StackTo(targetSlot, itemGUI);

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void StackTo_call_inventory_move_with_right_params_0_10()
		{
			int sourceIndex = 0;
			int targetIndex = 10;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUI(out var inventoryGUI, out var fakeBuilder, out var fakeInventory, out var parent);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);
			fakeInventory.ClearReceivedCalls();
			inventoryGUI.StackTo(targetSlot, itemGUI);

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void StackTo_call_inventory_move_with_right_params_10_0()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUI(out var inventoryGUI, out var fakeBuilder, out var fakeInventory, out var parent);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);
			fakeInventory.ClearReceivedCalls();
			inventoryGUI.StackTo(targetSlot, itemGUI);

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void SwapWith_call_inventory_move_with_right_params_0_1()
		{
			int sourceIndex = 0;
			int targetIndex = 1;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUI(out var inventoryGUI, out var fakeBuilder, out var fakeInventory, out var parent);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);
			fakeInventory.ClearReceivedCalls();
			inventoryGUI.SwapWith(targetSlot, itemGUI);

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void SwapWith_call_inventory_move_with_right_params_0_10()
		{
			int sourceIndex = 0;
			int targetIndex = 10;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUI(out var inventoryGUI, out var fakeBuilder, out var fakeInventory, out var parent);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);
			fakeInventory.ClearReceivedCalls();
			inventoryGUI.SwapWith(targetSlot, itemGUI);

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void SwapWith_call_inventory_move_with_right_params_10_0()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUI(out var inventoryGUI, out var fakeBuilder, out var fakeInventory, out var parent);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);
			fakeInventory.ClearReceivedCalls();
			inventoryGUI.SwapWith(targetSlot, itemGUI);

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		#endregion

		#region InventoryGUIWithSplit
		#region MoveTo
		[Test]
		public void MoveTo_call_MoveItem_directly_if_item_is_not_stackable_and_amount_is_1_and_splitModifier_is_false()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();

			var item = testGUIBuilder.CreateItem().GetItem();

			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);
			itemGUI.Item.Returns(item);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);

			var inventoryDetails = InventoryItemComponent.FindOn(item);
			inventoryDetails.StackCount = 1u;
			splitModifier.Value.Returns(false);

			fakeInventory.ClearReceivedCalls();
			splitSlider.ClearReceivedCalls();

			inventoryGUIWithSplit.MoveTo(targetSlot, itemGUI);
			splitSlider.DidNotReceive().Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Any<Action>(), Arg.Any<Action<uint>>());

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void MoveTo_call_MoveItem_directly_if_item_is_not_stackable_and_amount_is_1_and_splitModifier_is_true()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			var item = testGUIBuilder.CreateItem().GetItem();

			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);
			itemGUI.Item.Returns(item);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);

			var inventoryDetails = InventoryItemComponent.FindOn(item);
			inventoryDetails.StackCount = 1u;

			splitModifier.Value.Returns(true);

			fakeInventory.ClearReceivedCalls();
			splitSlider.ClearReceivedCalls();

			inventoryGUIWithSplit.MoveTo(targetSlot, itemGUI);
			splitSlider.DidNotReceive().Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Any<Action>(), Arg.Any<Action<uint>>());

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void MoveTo_call_MoveItem_directly_if_item_is_not_stackable_and_amount_is_more_then_1_and_splitModifier_is_false()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			var item = testGUIBuilder.CreateItem().GetItem();

			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);
			itemGUI.Item.Returns(item);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);

			var inventoryDetails = InventoryItemComponent.FindOn(item);
			inventoryDetails.StackCount = 10u;
			splitModifier.Value.Returns(false);

			fakeInventory.ClearReceivedCalls();
			splitSlider.ClearReceivedCalls();

			inventoryGUIWithSplit.MoveTo(targetSlot, itemGUI);
			splitSlider.DidNotReceive().Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Any<Action>(), Arg.Any<Action<uint>>());

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void MoveTo_call_MoveItem_directly_if_item_is_stackable_and_amount_is_1_and_splitModifier_is_false()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			var item = testGUIBuilder.CreateItem().GetItem();

			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);
			itemGUI.Item.Returns(item);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);

			var inventoryDetails = InventoryItemComponent.FindOn(item);
			inventoryDetails.StackCount = 10u;
			itemGUI.SlotGUI.Amount.Returns(1u);
			splitModifier.Value.Returns(false);

			fakeInventory.ClearReceivedCalls();
			splitSlider.ClearReceivedCalls();

			inventoryGUIWithSplit.MoveTo(targetSlot, itemGUI);
			splitSlider.DidNotReceive().Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Any<Action>(), Arg.Any<Action<uint>>());

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void MoveTo_call_MoveItem_directly_if_item_is_stackable_and_amount_is_more_than_1_and_splitModifier_is_false()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			var item = testGUIBuilder.CreateItem().GetItem();

			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);
			itemGUI.Item.Returns(item);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);

			var inventoryDetails = InventoryItemComponent.FindOn(item);
			inventoryDetails.StackCount = 10u;
			itemGUI.SlotGUI.Amount.Returns(2u);
			splitModifier.Value.Returns(false);

			fakeInventory.ClearReceivedCalls();
			splitSlider.ClearReceivedCalls();

			inventoryGUIWithSplit.MoveTo(targetSlot, itemGUI);
			splitSlider.DidNotReceive().Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Any<Action>(), Arg.Any<Action<uint>>());

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void MoveTo_call_MoveItem_directly_if_item_is_stackable_and_amount_is_1_and_splitModifier_is_true()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			var item = testGUIBuilder.CreateItem().GetItem();

			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);
			itemGUI.Item.Returns(item);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);

			var inventoryDetails = InventoryItemComponent.FindOn(item);
			inventoryDetails.StackCount = 10u;
			itemGUI.SlotGUI.Amount.Returns(1u);
			splitModifier.Value.Returns(true);

			fakeInventory.ClearReceivedCalls();
			splitSlider.ClearReceivedCalls();

			inventoryGUIWithSplit.MoveTo(targetSlot, itemGUI);
			splitSlider.DidNotReceive().Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Any<Action>(), Arg.Any<Action<uint>>());

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void MoveTo_call_MoveItem_directly_if_item_is_not_stackable_and_amount_is_more_than_1_and_splitModifier_is_true()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			var item = testGUIBuilder.CreateItem().GetItem();

			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);
			itemGUI.Item.Returns(item);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);

			itemGUI.SlotGUI.Amount.Returns(2u);
			splitModifier.Value.Returns(true);

			fakeInventory.ClearReceivedCalls();
			splitSlider.ClearReceivedCalls();

			inventoryGUIWithSplit.MoveTo(targetSlot, itemGUI);
			splitSlider.DidNotReceive().Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Any<Action>(), Arg.Any<Action<uint>>());

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void MoveTo_open_splitslider_if_item_is_stackable_and_amount_is_more_than_1_and_splitModifier_is_true()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			var item = testGUIBuilder.CreateItem().GetItem();

			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);
			itemGUI.Item.Returns(item);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);

			var inventoryDetails = InventoryItemComponent.FindOn(item);
			inventoryDetails.StackCount = 10u;
			itemGUI.SlotGUI.Amount.Returns(2u);
			splitModifier.Value.Returns(true);

			fakeInventory.ClearReceivedCalls();
			splitSlider.ClearReceivedCalls();

			inventoryGUIWithSplit.MoveTo(targetSlot, itemGUI);
			splitSlider.Received().Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Any<Action>(), Arg.Any<Action<uint>>());

			fakeInventory.Service.DidNotReceive().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void MoveTo_can_not_open_splitslider_if_prev_is_not_finished()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			var item = testGUIBuilder.CreateItem().GetItem();

			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);
			itemGUI.Item.Returns(item);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);

			var inventoryDetails = InventoryItemComponent.FindOn(item);
			inventoryDetails.StackCount = 10u;
			itemGUI.SlotGUI.Amount.Returns(2u);
			splitModifier.Value.Returns(true);

			fakeInventory.ClearReceivedCalls();
			splitSlider.ClearReceivedCalls();

			inventoryGUIWithSplit.MoveTo(targetSlot, itemGUI);
			splitSlider.Received().Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Any<Action>(), Arg.Any<Action<uint>>());
			splitSlider.ClearReceivedCalls();

			inventoryGUIWithSplit.MoveTo(targetSlot, itemGUI);
			splitSlider.DidNotReceive().Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Any<Action>(), Arg.Any<Action<uint>>());
			splitSlider.ClearReceivedCalls();

			testGUIBuilder.Destroy();
		}

		[Test]
		public void MoveTo_splitslider_does_not_call_inventorys_MoveItem_if_splitslider_was_canceled()
		{
			//TODO lovesem sincsen hogyan kell ezt

			//int sourceIndex = 10;
			//int targetIndex = 0;
			//var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			//var itemGUI = Substitute.For<IItemGUI>();
			//var itemGUISlot = Substitute.For<ISlotGUI>();
			//			var item = testGUIBuilder.CreateItem().GetItem();

			//itemGUISlot.SlotIndex.Returns(sourceIndex);
			//itemGUI.SlotGUI.Returns(itemGUISlot);
			//itemGUI.Item.Returns(item);

			//var targetSlot = Substitute.For<ISlotGUI>();
			//targetSlot.SlotIndex.Returns(targetIndex);

			//item.IsStackable.Returns(true);
			//itemGUI.SlotGUI.Amount.Returns(2u);
			//splitModifier.Value.Returns(true);

			//fakeInventory.ClearReceivedCalls();
			//splitSlider.ClearReceivedCalls();

			//inventoryGUIWithSplit.MoveTo(targetSlot, itemGUI);

			//splitSlider.When( x=> x.Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Do<Action>(), Arg.Any<Action<uint>>())).Do( x => { cancel(); });
			//fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			//testGUIBuilder.Destroy();
		}

		[Test]
		public void MoveTo_splitslider_calls_inventorys_MoveItem_if_splitslider_was_oked()
		{
			//TODO lovesem sincsen hogyan kell ezt

			//int sourceIndex = 10;
			//int targetIndex = 0;
			//var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			//var itemGUI = Substitute.For<IItemGUI>();
			//var itemGUISlot = Substitute.For<ISlotGUI>();
			//			var item = testGUIBuilder.CreateItem().GetItem();

			//itemGUISlot.SlotIndex.Returns(sourceIndex);
			//itemGUI.SlotGUI.Returns(itemGUISlot);
			//itemGUI.Item.Returns(item);

			//var targetSlot = Substitute.For<ISlotGUI>();
			//targetSlot.SlotIndex.Returns(targetIndex);

			//item.IsStackable.Returns(true);
			//itemGUI.SlotGUI.Amount.Returns(2u);
			//splitModifier.Value.Returns(true);

			//fakeInventory.ClearReceivedCalls();
			//splitSlider.ClearReceivedCalls();

			//inventoryGUIWithSplit.MoveTo(targetSlot, itemGUI);

			//splitSlider.When( x=> x.Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Do<Action>(), Arg.Any<Action<uint>>())).Do( x => { cancel(); });
			//fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			//testGUIBuilder.Destroy();
		}
		#endregion

		#region StackTo
		[Test]
		public void StackTo_call_MoveItem_directly_if_item_is_not_stackable_and_amount_is_1_and_splitModifier_is_false()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			var item = testGUIBuilder.CreateItem().GetItem();

			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);
			itemGUI.Item.Returns(item);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);
			targetSlot.Amount.Returns(1u);

			itemGUI.SlotGUI.Amount.Returns(1u);
			splitModifier.Value.Returns(false);

			fakeInventory.ClearReceivedCalls();
			splitSlider.ClearReceivedCalls();

			inventoryGUIWithSplit.StackTo(targetSlot, itemGUI);
			splitSlider.DidNotReceive().Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Any<Action>(), Arg.Any<Action<uint>>());

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void StackTo_call_MoveItem_directly_if_item_is_not_stackable_and_amount_is_1_and_splitModifier_is_true()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			var item = testGUIBuilder.CreateItem().GetItem();

			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);
			itemGUI.Item.Returns(item);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);
			targetSlot.Amount.Returns(1u);

			itemGUI.SlotGUI.Amount.Returns(1u);
			splitModifier.Value.Returns(true);

			fakeInventory.ClearReceivedCalls();
			splitSlider.ClearReceivedCalls();

			inventoryGUIWithSplit.StackTo(targetSlot, itemGUI);
			splitSlider.DidNotReceive().Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Any<Action>(), Arg.Any<Action<uint>>());

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void StackTo_call_MoveItem_directly_if_item_is_not_stackable_and_amount_is_more_then_1_and_splitModifier_is_false()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			var item = testGUIBuilder.CreateItem().GetItem();

			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);
			itemGUI.Item.Returns(item);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);
			targetSlot.Amount.Returns(1u);

			itemGUI.SlotGUI.Amount.Returns(2u);
			splitModifier.Value.Returns(false);

			fakeInventory.ClearReceivedCalls();
			splitSlider.ClearReceivedCalls();

			inventoryGUIWithSplit.StackTo(targetSlot, itemGUI);
			splitSlider.DidNotReceive().Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Any<Action>(), Arg.Any<Action<uint>>());

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void StackTo_call_MoveItem_directly_if_item_is_stackable_and_amount_is_1_and_splitModifier_is_false()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			var item = testGUIBuilder.CreateItem().GetItem();

			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);
			itemGUI.Item.Returns(item);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);
			targetSlot.Amount.Returns(1u);

			var inventoryDetails = InventoryItemComponent.FindOn(item);
			inventoryDetails.StackCount = 10u;
			itemGUI.SlotGUI.Amount.Returns(1u);
			splitModifier.Value.Returns(false);

			fakeInventory.ClearReceivedCalls();
			splitSlider.ClearReceivedCalls();

			inventoryGUIWithSplit.StackTo(targetSlot, itemGUI);
			splitSlider.DidNotReceive().Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Any<Action>(), Arg.Any<Action<uint>>());

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void StackTo_call_MoveItem_directly_if_item_is_stackable_and_amount_is_more_than_1_and_splitModifier_is_false()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			var item = testGUIBuilder.CreateItem().GetItem();

			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);
			itemGUI.Item.Returns(item);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);
			targetSlot.Amount.Returns(1u);

			var inventoryDetails = InventoryItemComponent.FindOn(item);
			inventoryDetails.StackCount = 10u;
			itemGUI.SlotGUI.Amount.Returns(2u);
			splitModifier.Value.Returns(false);

			fakeInventory.ClearReceivedCalls();
			splitSlider.ClearReceivedCalls();

			inventoryGUIWithSplit.StackTo(targetSlot, itemGUI);
			splitSlider.DidNotReceive().Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Any<Action>(), Arg.Any<Action<uint>>());

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void StackTo_call_MoveItem_directly_if_item_is_stackable_and_amount_is_1_and_splitModifier_is_true()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			var item = testGUIBuilder.CreateItem().GetItem();

			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);
			itemGUI.Item.Returns(item);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);
			targetSlot.Amount.Returns(1u);

			var inventoryDetails = InventoryItemComponent.FindOn(item);
			inventoryDetails.StackCount = 10u;
			itemGUI.SlotGUI.Amount.Returns(1u);
			splitModifier.Value.Returns(true);

			fakeInventory.ClearReceivedCalls();
			splitSlider.ClearReceivedCalls();

			inventoryGUIWithSplit.StackTo(targetSlot, itemGUI);
			splitSlider.DidNotReceive().Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Any<Action>(), Arg.Any<Action<uint>>());

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void StackTo_call_MoveItem_directly_if_item_is_not_stackable_and_amount_is_more_than_1_and_splitModifier_is_true()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			var item = testGUIBuilder.CreateItem().GetItem();

			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);
			itemGUI.Item.Returns(item);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);
			targetSlot.Amount.Returns(1u);

			itemGUI.SlotGUI.Amount.Returns(2u);
			splitModifier.Value.Returns(true);

			fakeInventory.ClearReceivedCalls();
			splitSlider.ClearReceivedCalls();

			inventoryGUIWithSplit.StackTo(targetSlot, itemGUI);
			splitSlider.DidNotReceive().Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Any<Action>(), Arg.Any<Action<uint>>());

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void StackTo_open_splitslider_if_item_is_stackable_and_amount_is_more_than_1_and_splitModifier_is_true()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			var item = testGUIBuilder.CreateItem().GetItem();

			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);
			itemGUI.Item.Returns(item);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);
			targetSlot.Amount.Returns(1u);

			var inventoryDetails = InventoryItemComponent.FindOn(item);
			inventoryDetails.StackCount = 10u;
			itemGUI.SlotGUI.Amount.Returns(2u);
			splitModifier.Value.Returns(true);

			fakeInventory.ClearReceivedCalls();
			splitSlider.ClearReceivedCalls();

			inventoryGUIWithSplit.StackTo(targetSlot, itemGUI);
			splitSlider.Received().Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Any<Action>(), Arg.Any<Action<uint>>());

			fakeInventory.Service.DidNotReceive().MoveItem(Arg.Any<int>(), Arg.Any<int>());

			testGUIBuilder.Destroy();
		}

		[Test]
		public void StackTo_can_not_open_splitslider_if_prev_is_not_finished()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			var item = testGUIBuilder.CreateItem().GetItem();

			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);
			itemGUI.Item.Returns(item);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);
			targetSlot.Amount.Returns(1u);

			var inventoryDetails = InventoryItemComponent.FindOn(item);
			inventoryDetails.StackCount = 10u;
			itemGUI.SlotGUI.Amount.Returns(2u);
			splitModifier.Value.Returns(true);

			fakeInventory.ClearReceivedCalls();
			splitSlider.ClearReceivedCalls();

			inventoryGUIWithSplit.StackTo(targetSlot, itemGUI);
			splitSlider.Received().Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Any<Action>(), Arg.Any<Action<uint>>());
			splitSlider.ClearReceivedCalls();

			inventoryGUIWithSplit.StackTo(targetSlot, itemGUI);
			splitSlider.DidNotReceive().Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Any<Action>(), Arg.Any<Action<uint>>());
			splitSlider.ClearReceivedCalls();

			testGUIBuilder.Destroy();
		}

		[Test]
		public void StackTo_splitslider_does_not_call_inventorys_MoveItem_if_splitslider_was_canceled()
		{
			//TODO lovesem sincsen hogyan kell ezt

			//int sourceIndex = 10;
			//int targetIndex = 0;
			//var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			//var itemGUI = Substitute.For<IItemGUI>();
			//var itemGUISlot = Substitute.For<ISlotGUI>();
			//			var item = testGUIBuilder.CreateItem().GetItem();

			//itemGUISlot.SlotIndex.Returns(sourceIndex);
			//itemGUI.SlotGUI.Returns(itemGUISlot);
			//itemGUI.Item.Returns(item);

			//var targetSlot = Substitute.For<ISlotGUI>();
			//targetSlot.SlotIndex.Returns(targetIndex);

			//var inventoryDetails = InventoryItemComponent.Find(item);
			//			inventoryDetails.StackCount = 10u;
			//itemGUI.SlotGUI.Amount.Returns(2u);
			//splitModifier.Value.Returns(true);

			//fakeInventory.ClearReceivedCalls();
			//splitSlider.ClearReceivedCalls();

			//inventoryGUIWithSplit.StackTo(targetSlot, itemGUI);

			//splitSlider.When( x=> x.Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Do<Action>(), Arg.Any<Action<uint>>())).Do( x => { cancel(); });
			//fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			//testGUIBuilder.Destroy();
		}

		[Test]
		public void StackTo_splitslider_calls_inventorys_MoveItem_if_splitslider_was_oked()
		{
			//TODO lovesem sincsen hogyan kell ezt

			//int sourceIndex = 10;
			//int targetIndex = 0;
			//var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			//var itemGUI = Substitute.For<IItemGUI>();
			//var itemGUISlot = Substitute.For<ISlotGUI>();
			//			var item = testGUIBuilder.CreateItem().GetItem();

			//itemGUISlot.SlotIndex.Returns(sourceIndex);
			//itemGUI.SlotGUI.Returns(itemGUISlot);
			//itemGUI.Item.Returns(item);

			//var targetSlot = Substitute.For<ISlotGUI>();
			//targetSlot.SlotIndex.Returns(targetIndex);

			//var inventoryDetails = InventoryItemComponent.Find(item);
			//			inventoryDetails.StackCount = 10u;
			//itemGUI.SlotGUI.Amount.Returns(2u);
			//splitModifier.Value.Returns(true);

			//fakeInventory.ClearReceivedCalls();
			//splitSlider.ClearReceivedCalls();

			//inventoryGUIWithSplit.StackTo(targetSlot, itemGUI);

			//splitSlider.When( x=> x.Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Do<Action>(), Arg.Any<Action<uint>>())).Do( x => { cancel(); });
			//fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			//testGUIBuilder.Destroy();
		}
		#endregion


		#region SwapWith
		[Test]
		public void SwapWith_call_MoveItem_directly_if_item_is_not_stackable_and_amount_is_1_and_splitModifier_is_false()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			var item = testGUIBuilder.CreateItem().GetItem();

			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);
			itemGUI.Item.Returns(item);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);

			itemGUI.SlotGUI.Amount.Returns(1u);
			splitModifier.Value.Returns(false);

			fakeInventory.ClearReceivedCalls();
			splitSlider.ClearReceivedCalls();

			inventoryGUIWithSplit.SwapWith(targetSlot, itemGUI);
			splitSlider.DidNotReceive().Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Any<Action>(), Arg.Any<Action<uint>>());

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void SwapWith_call_MoveItem_directly_if_item_is_not_stackable_and_amount_is_1_and_splitModifier_is_true()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			var item = testGUIBuilder.CreateItem().GetItem();

			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);
			itemGUI.Item.Returns(item);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);

			itemGUI.SlotGUI.Amount.Returns(1u);
			splitModifier.Value.Returns(true);

			fakeInventory.ClearReceivedCalls();
			splitSlider.ClearReceivedCalls();

			inventoryGUIWithSplit.SwapWith(targetSlot, itemGUI);
			splitSlider.DidNotReceive().Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Any<Action>(), Arg.Any<Action<uint>>());

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void SwapWith_call_MoveItem_directly_if_item_is_not_stackable_and_amount_is_more_then_1_and_splitModifier_is_false()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			var item = testGUIBuilder.CreateItem().GetItem();

			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);
			itemGUI.Item.Returns(item);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);

			itemGUI.SlotGUI.Amount.Returns(2u);
			splitModifier.Value.Returns(false);

			fakeInventory.ClearReceivedCalls();
			splitSlider.ClearReceivedCalls();

			inventoryGUIWithSplit.SwapWith(targetSlot, itemGUI);
			splitSlider.DidNotReceive().Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Any<Action>(), Arg.Any<Action<uint>>());

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void SwapWith_call_MoveItem_directly_if_item_is_stackable_and_amount_is_1_and_splitModifier_is_false()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			var item = testGUIBuilder.CreateItem().GetItem();

			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);
			itemGUI.Item.Returns(item);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);

			var inventoryDetails = InventoryItemComponent.FindOn(item);
			inventoryDetails.StackCount = 10u;
			itemGUI.SlotGUI.Amount.Returns(1u);
			splitModifier.Value.Returns(false);

			fakeInventory.ClearReceivedCalls();
			splitSlider.ClearReceivedCalls();

			inventoryGUIWithSplit.SwapWith(targetSlot, itemGUI);
			splitSlider.DidNotReceive().Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Any<Action>(), Arg.Any<Action<uint>>());

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void SwapWith_call_MoveItem_directly_if_item_is_stackable_and_amount_is_more_than_1_and_splitModifier_is_false()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			var item = testGUIBuilder.CreateItem().GetItem();

			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);
			itemGUI.Item.Returns(item);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);

			var inventoryDetails = InventoryItemComponent.FindOn(item);
			inventoryDetails.StackCount = 10u;
			itemGUI.SlotGUI.Amount.Returns(2u);
			splitModifier.Value.Returns(false);

			fakeInventory.ClearReceivedCalls();
			splitSlider.ClearReceivedCalls();

			inventoryGUIWithSplit.SwapWith(targetSlot, itemGUI);
			splitSlider.DidNotReceive().Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Any<Action>(), Arg.Any<Action<uint>>());

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void SwapWith_call_MoveItem_directly_if_item_is_stackable_and_amount_is_1_and_splitModifier_is_true()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			var item = testGUIBuilder.CreateItem().GetItem();

			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);
			itemGUI.Item.Returns(item);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);

			var inventoryDetails = InventoryItemComponent.FindOn(item);
			inventoryDetails.StackCount = 10u;
			itemGUI.SlotGUI.Amount.Returns(1u);
			splitModifier.Value.Returns(true);

			fakeInventory.ClearReceivedCalls();
			splitSlider.ClearReceivedCalls();

			inventoryGUIWithSplit.SwapWith(targetSlot, itemGUI);
			splitSlider.DidNotReceive().Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Any<Action>(), Arg.Any<Action<uint>>());

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void SwapWith_call_MoveItem_directly_if_item_is_not_stackable_and_amount_is_more_than_1_and_splitModifier_is_true()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			var item = testGUIBuilder.CreateItem().GetItem();

			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);
			itemGUI.Item.Returns(item);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);

			itemGUI.SlotGUI.Amount.Returns(2u);
			splitModifier.Value.Returns(true);

			fakeInventory.ClearReceivedCalls();
			splitSlider.ClearReceivedCalls();

			inventoryGUIWithSplit.SwapWith(targetSlot, itemGUI);
			splitSlider.DidNotReceive().Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Any<Action>(), Arg.Any<Action<uint>>());

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}

		[Test]
		public void SwapWith_call_MoveItem_directly_if_item_is_stackable_and_amount_is_more_than_1_and_splitModifier_is_true()
		{
			int sourceIndex = 10;
			int targetIndex = 0;
			var testGUIBuilder = InventoryGUITestBuilder.Create().CreateInventoryGUIWithSplit(out var inventoryGUIWithSplit, out var fakeBuilder, out var fakeInventory, out var parent, out var splitModifier, out var splitSlider);
			var itemGUI = Substitute.For<IInventoryItemGUI>();
			var itemGUISlot = Substitute.For<ISlotGUI>();
			var item = testGUIBuilder.CreateItem().GetItem();

			itemGUISlot.SlotIndex.Returns(sourceIndex);
			itemGUI.SlotGUI.Returns(itemGUISlot);
			itemGUI.Item.Returns(item);

			var targetSlot = Substitute.For<ISlotGUI>();
			targetSlot.SlotIndex.Returns(targetIndex);

			var inventoryDetails = InventoryItemComponent.FindOn(item);
			inventoryDetails.StackCount = 10u;
			itemGUI.SlotGUI.Amount.Returns(2u);
			splitModifier.Value.Returns(true);

			fakeInventory.ClearReceivedCalls();
			splitSlider.ClearReceivedCalls();

			inventoryGUIWithSplit.SwapWith(targetSlot, itemGUI);
			splitSlider.DidNotReceive().Open(Arg.Any<uint>(), Arg.Any<uint>(), Arg.Any<Action>(), Arg.Any<Action<uint>>());

			fakeInventory.Service.Received().MoveItem(sourceIndex, targetIndex);

			testGUIBuilder.Destroy();
		}
		#endregion
		#endregion
	}
}
