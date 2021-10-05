using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;

namespace VTest.GUI.Draggable
{
	class DraggableDropSlotComponentTest
	{
		[Test]
		public void OnDropSlotChanged_event_is_received_if_dropslot_is_changed()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabled).CreateDraggableDropSlotComponent(out var dropSlotComponent, draggableButton, draggableButton).CreateSubstituteListener(dropSlotComponent, out var fakeListener).CreateFakeDropSlot(out var dropSlot1).CreateFakeDropSlot(out var dropSlot2);
			Assert.IsNull(dropSlotComponent.DropSlot);
			fakeListener.ClearReceivedCalls();
			dropSlotComponent.DropSlot = dropSlot1;
			fakeListener.Received().OnDropSlotChanged(null, dropSlot1);
			Assert.AreEqual(dropSlot1, dropSlotComponent.DropSlot);

			fakeListener.ClearReceivedCalls();
			dropSlotComponent.DropSlot = dropSlot2;
			fakeListener.Received().OnDropSlotChanged(dropSlot1, dropSlot2);
			Assert.AreEqual(dropSlot2, dropSlotComponent.DropSlot);

			fakeListener.ClearReceivedCalls();
			dropSlotComponent.DropSlot = null;
			fakeListener.Received().OnDropSlotChanged(dropSlot2, null);
			Assert.AreEqual(null, dropSlotComponent.DropSlot);

			builder.Destory();
		}

		[Test]
		public void position_is_same_af_dropslot_after_state_become_standby_if_it_has_dropslot()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabled).CreateDraggableDropSlotComponent(out var dropSlotComponent, draggableButton, draggableButton).CreateSubstituteListener(dropSlotComponent, out var fakeListenerForDropSlot).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListenerForDraggable).CreateFakeDropSlot(out var dropSlot1).CreateFakeDropSlot(out var dropSlot2);

			var dropSlot1Position = new Vector2(134.345f, 1753.2334f);
			var dropSlot2Position = new Vector2(234.345f, 2753.2334f);
			dropSlot1.Position.Returns(dropSlot1Position);
			dropSlot2.Position.Returns(dropSlot2Position);

			IsPositionChanged(dropSlotComponent, dropSlot1, dropSlot1Position, fakeListenerForDraggable, draggableButton);
			IsPositionChanged(dropSlotComponent, dropSlot2, dropSlot2Position, fakeListenerForDraggable, draggableButton);

			builder.Destory();
		}

		[Test]
		public void position_doesnt_change_after_state_become_standby_if_it_doesnt_have_dropslot()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabled).CreateDraggableDropSlotComponent(out var dropSlotComponent, draggableButton, draggableButton).CreateSubstituteListener(dropSlotComponent, out var fakeListenerForDropSlot).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListenerForDraggable).CreateFakeDropSlot(out var dropSlot1).CreateFakeDropSlot(out var dropSlot2);

			var dropSlot1Position = new Vector2(134.345f, 1753.2334f);
			dropSlot1.Position.Returns(dropSlot1Position);

			IsPositionChanged(dropSlotComponent, dropSlot1, dropSlot1Position, fakeListenerForDraggable, draggableButton);
			IsPositionNotChangeWithNull(dropSlotComponent, fakeListenerForDraggable, draggableButton);

			builder.Destory();
		}

		private void IsPositionChanged(VEngine.GUI.Draggable.DraggableDropSlotComponent dropSlotComponent, VEngine.GUI.IDropSlot dropSlot1, Vector2 dropSlot1Position, IFakeListenerForDraggableButtonEvents fakeListenerForDraggable, VEngine.GUI.Draggable.DraggableButton draggableButton)
		{
			dropSlotComponent.DropSlot = dropSlot1;
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Left;
			pData.position = new Vector2(-987.6f, 5432.1f);
			draggableButton.OnBeginDrag(pData);
			fakeListenerForDraggable.Received().OnStateChanged(VEngine.GUI.Draggable.eState.OnDrag);
			fakeListenerForDraggable.ClearReceivedCalls();
			draggableButton.OnEndDrag(pData);
			fakeListenerForDraggable.Received().OnStateChanged(VEngine.GUI.Draggable.eState.StandBy);
			Assert.AreEqual(dropSlot1Position, draggableButton.Position);
		}

		private void IsPositionNotChangeWithNull(VEngine.GUI.Draggable.DraggableDropSlotComponent dropSlotComponent, IFakeListenerForDraggableButtonEvents fakeListenerForDraggable, VEngine.GUI.Draggable.DraggableButton draggableButton)
		{
			dropSlotComponent.DropSlot = null;
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Left;
			pData.position = new Vector2(-987.6f, 5432.1f);
			draggableButton.OnBeginDrag(pData);
			fakeListenerForDraggable.Received().OnStateChanged(VEngine.GUI.Draggable.eState.OnDrag);
			fakeListenerForDraggable.ClearReceivedCalls();

			var position = draggableButton.Position;
			draggableButton.OnEndDrag(pData);
			fakeListenerForDraggable.Received().OnStateChanged(VEngine.GUI.Draggable.eState.StandBy);
			Assert.AreEqual(position, draggableButton.Position);
		}
	}
}
