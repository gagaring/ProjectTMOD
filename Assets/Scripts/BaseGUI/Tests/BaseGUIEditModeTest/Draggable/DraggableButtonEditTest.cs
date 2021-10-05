using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using VEngine.GUI.Draggable;

namespace VTest.GUI.Draggable
{
	class DraggableButtonEditTest
	{
		#region pointer click
		[Test]
		public void left_invoke_is_receive_if_left_button_click()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Left, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);
			fakeListener.DidNotReceive().OnLeftClicked();
			fakeListener.DidNotReceive().OnRightClicked();
			fakeListener.ClearReceivedCalls();
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Left;
			draggableButton.OnPointerClick(pData);
			fakeListener.Received().OnLeftClicked();
			fakeListener.DidNotReceive().OnRightClicked();
			fakeListener.DidNotReceive().OnMiddleClicked();

			builder.Destory();
		}

		[Test]
		public void right_invoke_is_receive_if_right_button_click()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Left, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);
			fakeListener.DidNotReceive().OnLeftClicked();
			fakeListener.DidNotReceive().OnRightClicked();
			fakeListener.ClearReceivedCalls();
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Right;
			draggableButton.OnPointerClick(pData);
			fakeListener.DidNotReceive().OnLeftClicked();
			fakeListener.Received().OnRightClicked();
			fakeListener.DidNotReceive().OnMiddleClicked();

			builder.Destory();
		}

		[Test]
		public void middle_click_invoke_is_receive_if_mid_button_click()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Left, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents, out var fakeListener);
			
			fakeListener.DidNotReceive().OnLeftClicked();
			fakeListener.DidNotReceive().OnRightClicked();
			fakeListener.ClearReceivedCalls();
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Middle;
			draggableButton.OnPointerClick(pData);
			fakeListener.DidNotReceive().OnLeftClicked();
			fakeListener.DidNotReceive().OnRightClicked();
			fakeListener.Received().OnMiddleClicked();

			builder.Destory();
		}

		[Test]
		public void no_click_invoke_is_receive_if_draggable_is_on_drag()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Left, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);
			
			fakeListener.DidNotReceive().OnLeftClicked();
			fakeListener.DidNotReceive().OnRightClicked();
			fakeListener.ClearReceivedCalls();
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Left;

			draggableButton.OnBeginDrag(pData);
			Assert.AreEqual(eState.OnDrag, draggableButton.State);

			fakeListener.ClearReceivedCalls();
			pData.button = PointerEventData.InputButton.Right;

			draggableButton.OnPointerClick(pData);
			fakeListener.DidNotReceive().OnRightClicked();

			fakeListener.ClearReceivedCalls();
			pData.button = PointerEventData.InputButton.Left;
			draggableButton.OnPointerClick(pData);
			fakeListener.DidNotReceive().OnLeftClicked();

			fakeListener.ClearReceivedCalls();
			pData.button = PointerEventData.InputButton.Middle;
			draggableButton.OnPointerClick(pData);
			fakeListener.DidNotReceive().OnMiddleClicked();

			builder.Destory();
		}
		#endregion

		#region state
		#region begindrag
		[Test]
		public void state_is_OnDrag_if_OnBeginDrag_with_left_button_if_left_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Left, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Left;

			draggableButton.OnBeginDrag(pData);
			Assert.AreEqual(eState.OnDrag, draggableButton.State);
			Assert.AreNotEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_StandBy_if_OnBeginDrag_with_right_button_if_left_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Left, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Right;

			draggableButton.OnBeginDrag(pData);
			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_StandBy_if_OnBeginDrag_with_middle_button_if_left_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Left, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Middle;

			draggableButton.OnBeginDrag(pData);
			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_StandBy_if_OnBeginDrag_with_left_button_if_right_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Right, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Left;

			draggableButton.OnBeginDrag(pData);
			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_OnDrag_if_OnBeginDrag_with_right_button_if_right_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Right, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Right;

			draggableButton.OnBeginDrag(pData);
			Assert.AreEqual(eState.OnDrag, draggableButton.State);
			Assert.AreNotEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_StandBy_if_OnBeginDrag_with_middle_button_if_right_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Right, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Middle;

			draggableButton.OnBeginDrag(pData);
			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_StandBy_if_OnBeginDrag_with_left_button_if_middle_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Middle, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Left;

			draggableButton.OnBeginDrag(pData);
			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_StandBy_if_OnBeginDrag_with_right_button_if_middle_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Middle, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Right;

			draggableButton.OnBeginDrag(pData);
			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_OnDrag_if_OnBeginDrag_with_middle_button_if_middle_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Middle, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Middle;

			draggableButton.OnBeginDrag(pData);
			Assert.AreEqual(eState.OnDrag, draggableButton.State);
			Assert.AreNotEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}
		#endregion

		#region ondrag
		[Test]
		public void state_is_OnDrag_if_OnDrag_with_left_button_after_OnBeginDrag_if_left_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Left, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Left;

			draggableButton.OnBeginDrag(pData);
			Assert.AreEqual(eState.OnDrag, draggableButton.State);

			draggableButton.OnDrag(pData);
			Assert.AreEqual(eState.OnDrag, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_Standby_if_OnDrag_with_left_button_without_OnBeginDrag_if_left_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Left, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Left;

			Assert.AreEqual(eState.StandBy, draggableButton.State);

			draggableButton.OnDrag(pData);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_Standby_if_OnDrag_with_right_button_after_OnBeginDrag_if_left_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Left, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Right;

			draggableButton.OnBeginDrag(pData);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			draggableButton.OnDrag(pData);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_Standby_if_OnDrag_with_right_button_without_OnBeginDrag_if_left_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Left, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Right;

			Assert.AreEqual(eState.StandBy, draggableButton.State);

			draggableButton.OnDrag(pData);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_Standby_if_OnDrag_with_middle_button_after_OnBeginDrag_if_left_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Left, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Middle;

			draggableButton.OnBeginDrag(pData);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			draggableButton.OnDrag(pData);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_Standby_if_OnDrag_with_middle_button_without_OnBeginDrag_if_left_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Left, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Middle;

			Assert.AreEqual(eState.StandBy, draggableButton.State);

			draggableButton.OnDrag(pData);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_StandBy_if_OnDrag_with_left_button_after_OnBeginDrag_if_right_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Right, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Left;

			Assert.AreEqual(eState.StandBy, draggableButton.State);

			draggableButton.OnDrag(pData);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_Standby_if_OnDrag_with_left_button_without_OnBeginDrag_if_right_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Right, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Left;

			Assert.AreEqual(eState.StandBy, draggableButton.State);

			draggableButton.OnDrag(pData);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_OnDrag_if_OnDrag_with_right_button_after_OnBeginDrag_if_right_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Right, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Right;

			draggableButton.OnBeginDrag(pData);
			Assert.AreEqual(eState.OnDrag, draggableButton.State);

			draggableButton.OnDrag(pData);
			Assert.AreEqual(eState.OnDrag, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_Standby_if_OnDrag_with_right_button_without_OnBeginDrag_if_right_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Right, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Right;

			Assert.AreEqual(eState.StandBy, draggableButton.State);

			draggableButton.OnDrag(pData);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_Standby_if_OnDrag_with_middle_button_after_OnBeginDrag_if_right_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Right, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Middle;

			draggableButton.OnBeginDrag(pData);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			draggableButton.OnDrag(pData);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_Standby_if_OnDrag_with_middle_button_without_OnBeginDrag_if_right_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Right, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Middle;

			Assert.AreEqual(eState.StandBy, draggableButton.State);

			draggableButton.OnDrag(pData);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_StandBy_if_OnDrag_with_left_button_after_OnBeginDrag_if_middle_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Middle, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Left;

			Assert.AreEqual(eState.StandBy, draggableButton.State);

			draggableButton.OnDrag(pData);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_Standby_if_OnDrag_with_left_button_without_OnBeginDrag_if_middle_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Middle, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Left;

			Assert.AreEqual(eState.StandBy, draggableButton.State);

			draggableButton.OnDrag(pData);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_Standby_if_OnDrag_with_right_button_after_OnBeginDrag_if_middle_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Middle, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Right;

			draggableButton.OnBeginDrag(pData);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			draggableButton.OnDrag(pData);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_Standby_if_OnDrag_with_right_button_without_OnBeginDrag_if_middle_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Middle, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Right;

			Assert.AreEqual(eState.StandBy, draggableButton.State);

			draggableButton.OnDrag(pData);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_OnDrag_if_OnDrag_with_middle_button_after_OnBeginDrag_if_middle_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Middle, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Middle;

			draggableButton.OnBeginDrag(pData);
			Assert.AreEqual(eState.OnDrag, draggableButton.State);

			draggableButton.OnDrag(pData);
			Assert.AreEqual(eState.OnDrag, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_Standby_if_OnDrag_with_middle_button_without_OnBeginDrag_if_middle_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Middle, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Middle;

			Assert.AreEqual(eState.StandBy, draggableButton.State);

			draggableButton.OnDrag(pData);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}
		#endregion

		#region endDrag
		[Test]
		public void state_is_standby_after_enddrag_with_left_button_if_dragbutton_is_left()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Left, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Left;

			draggableButton.OnBeginDrag(pData);
			Assert.AreEqual(eState.OnDrag, draggableButton.State);

			draggableButton.OnEndDrag(pData);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_OnDrag_after_enddrag_with_no_left_button_if_dragbutton_is_left()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Left, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Left;

			draggableButton.OnBeginDrag(pData);
			Assert.AreEqual(eState.OnDrag, draggableButton.State);

			pData.button = PointerEventData.InputButton.Right;
			draggableButton.OnEndDrag(pData);
			Assert.AreEqual(eState.OnDrag, draggableButton.State);

			pData.button = PointerEventData.InputButton.Middle;
			draggableButton.OnEndDrag(pData);
			Assert.AreEqual(eState.OnDrag, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_standby_after_enddrag_with_right_button_if_dragbutton_is_right()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Right, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Right;

			draggableButton.OnBeginDrag(pData);
			Assert.AreEqual(eState.OnDrag, draggableButton.State);

			draggableButton.OnEndDrag(pData);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_OnDrag_after_enddrag_with_no_right_button_if_dragbutton_is_right()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Right, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Right;

			draggableButton.OnBeginDrag(pData);
			Assert.AreEqual(eState.OnDrag, draggableButton.State);

			pData.button = PointerEventData.InputButton.Left;
			draggableButton.OnEndDrag(pData);
			Assert.AreEqual(eState.OnDrag, draggableButton.State);

			pData.button = PointerEventData.InputButton.Middle;
			draggableButton.OnEndDrag(pData);
			Assert.AreEqual(eState.OnDrag, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_standby_after_enddrag_with_middle_button_if_dragbutton_is_middle()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Middle, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Middle;

			draggableButton.OnBeginDrag(pData);
			Assert.AreEqual(eState.OnDrag, draggableButton.State);

			draggableButton.OnEndDrag(pData);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}

		[Test]
		public void state_is_OnDrag_after_enddrag_with_no_middle_button_if_dragbutton_is_middle()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Middle, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Middle;

			draggableButton.OnBeginDrag(pData);
			Assert.AreEqual(eState.OnDrag, draggableButton.State);

			pData.button = PointerEventData.InputButton.Left;
			draggableButton.OnEndDrag(pData);
			Assert.AreEqual(eState.OnDrag, draggableButton.State);

			pData.button = PointerEventData.InputButton.Right;
			draggableButton.OnEndDrag(pData);
			Assert.AreEqual(eState.OnDrag, draggableButton.State);

			builder.Destory();
		}
		#endregion

		#region state changed event
		[Test]
		public void did_OnStateChanged_receive_with_OnDrag_after_OnBeginDrag_with_left_if_left_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Left, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Left;

			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.Received().OnStateChanged(eState.OnDrag);
			builder.Destory();
		}

		[Test]
		public void did_not_OnStateChanged_receive_with_OnDrag_after_OnBeginDrag_with_no_left_if_left_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Left, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Right;
			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.DidNotReceive().OnStateChanged(eState.OnDrag);

			pData.button = PointerEventData.InputButton.Middle;
			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.DidNotReceive().OnStateChanged(eState.OnDrag);
			builder.Destory();
		}

		[Test]
		public void did_OnStateChanged_receive_with_OnDrag_after_OnBeginDrag_with_right_if_right_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Right, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Right;

			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.Received().OnStateChanged(eState.OnDrag);
			builder.Destory();
		}

		[Test]
		public void did_not_OnStateChanged_receive_with_OnDrag_after_OnBeginDrag_with_no_right_if_right_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Right, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Left;
			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.DidNotReceive().OnStateChanged(eState.OnDrag);

			pData.button = PointerEventData.InputButton.Middle;
			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.DidNotReceive().OnStateChanged(eState.OnDrag);
			builder.Destory();
		}

		[Test]
		public void did_OnStateChanged_receive_with_OnDrag_after_OnBeginDrag_with_middle_if_middle_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Middle, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Middle;

			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.Received().OnStateChanged(eState.OnDrag);
			builder.Destory();
		}

		[Test]
		public void did_not_OnStateChanged_receive_with_OnDrag_after_OnBeginDrag_with_no_middle_if_middle_button_is_the_dragbutton()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Middle, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Left;
			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.DidNotReceive().OnStateChanged(eState.OnDrag);

			pData.button = PointerEventData.InputButton.Right;
			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.DidNotReceive().OnStateChanged(eState.OnDrag);
			builder.Destory();
		}
		#endregion
		#endregion

		#region position
		#region OnPositionChanged 
		[Test]
		public void did_OnPositionChanged_receive_after_BeginDrag_with_left_if_draggable_button_is_left()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Left, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			var testPosition = Vector2.zero;
			Assert.AreEqual(testPosition, draggableButton.Position);

			testPosition = new Vector2(123.4f, 567.8f);
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Left;
			pData.position = testPosition;

			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);
			builder.Destory();
		}

		[Test]
		public void did_not_OnPositionChanged_receive_after_BeginDrag_with_no_left_if_draggable_button_is_left()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Left, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			var testPosition = Vector2.zero;
			Assert.AreEqual(testPosition, draggableButton.Position);

			testPosition = new Vector2(123.4f, 567.8f);
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.position = testPosition;

			pData.button = PointerEventData.InputButton.Right;
			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);

			pData.button = PointerEventData.InputButton.Middle;
			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);
			builder.Destory();
		}

		[Test]
		public void did_OnPositionChanged_receive_OnDrag_with_left_if_draggable_button_is_left()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Left, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			var testPosition = Vector2.zero;
			Assert.AreEqual(testPosition, draggableButton.Position);

			testPosition = new Vector2(123.4f, 567.8f);
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Left;
			pData.position = testPosition;

			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);


			testPosition = new Vector2(1230.4f, 5670.8f);
			pData.position = testPosition;

			fakeListener.ClearReceivedCalls();
			draggableButton.OnDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);

			builder.Destory();
		}

		[Test]
		public void did_not_OnPositionChanged_receive_OnDrag_with_no_left_if_draggable_button_is_left()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Left, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			var testPosition = Vector2.zero;
			Assert.AreEqual(testPosition, draggableButton.Position);

			testPosition = new Vector2(123.4f, 567.8f);
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Left;
			pData.position = testPosition;

			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);

			testPosition = new Vector2(1230.4f, 5670.8f);
			pData.position = testPosition;

			pData.button = PointerEventData.InputButton.Right;
			fakeListener.ClearReceivedCalls();
			draggableButton.OnDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);

			pData.button = PointerEventData.InputButton.Middle;
			fakeListener.ClearReceivedCalls();
			draggableButton.OnDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);

			builder.Destory();
		}

		[Test]
		public void did_not_OnPositionChanged_receive_OnEndDrag_if_draggable_button_is_left()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Left, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			var testPosition = Vector2.zero;
			Assert.AreEqual(testPosition, draggableButton.Position);

			testPosition = new Vector2(123.4f, 567.8f);
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Left;
			pData.position = testPosition;

			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);


			testPosition = new Vector2(1230.4f, 5670.8f);
			pData.position = testPosition;

			pData.button = PointerEventData.InputButton.Left;
			fakeListener.ClearReceivedCalls();
			draggableButton.OnEndDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);

			pData.button = PointerEventData.InputButton.Right;
			fakeListener.ClearReceivedCalls();
			draggableButton.OnEndDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);

			pData.button = PointerEventData.InputButton.Middle;
			fakeListener.ClearReceivedCalls();
			draggableButton.OnEndDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);

			builder.Destory();
		}

		[Test]
		public void did_OnPositionChanged_receive_after_BeginDrag_with_right_if_draggable_button_is_right()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Right, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			var testPosition = Vector2.zero;
			Assert.AreEqual(testPosition, draggableButton.Position);

			testPosition = new Vector2(123.4f, 567.8f);
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Right;
			pData.position = testPosition;

			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);
			builder.Destory();
		}

		[Test]
		public void did_not_OnPositionChanged_receive_after_BeginDrag_with_no_right_if_draggable_button_is_right()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Right, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			var testPosition = Vector2.zero;
			Assert.AreEqual(testPosition, draggableButton.Position);

			testPosition = new Vector2(123.4f, 567.8f);
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.position = testPosition;

			pData.button = PointerEventData.InputButton.Left;
			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);

			pData.button = PointerEventData.InputButton.Middle;
			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);
			builder.Destory();
		}

		[Test]
		public void did_OnPositionChanged_receive_OnDrag_with_right_if_draggable_button_is_right()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Right, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			var testPosition = Vector2.zero;
			Assert.AreEqual(testPosition, draggableButton.Position);

			testPosition = new Vector2(123.4f, 567.8f);
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Right;
			pData.position = testPosition;

			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);


			testPosition = new Vector2(1230.4f, 5670.8f);
			pData.position = testPosition;

			fakeListener.ClearReceivedCalls();
			draggableButton.OnDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);

			builder.Destory();
		}

		[Test]
		public void did_not_OnPositionChanged_receive_OnDrag_with_no_right_if_draggable_button_is_right()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Right, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			var testPosition = Vector2.zero;
			Assert.AreEqual(testPosition, draggableButton.Position);

			testPosition = new Vector2(123.4f, 567.8f);
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Right;
			pData.position = testPosition;

			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);

			testPosition = new Vector2(1230.4f, 5670.8f);
			pData.position = testPosition;

			pData.button = PointerEventData.InputButton.Left;
			fakeListener.ClearReceivedCalls();
			draggableButton.OnDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);

			pData.button = PointerEventData.InputButton.Middle;
			fakeListener.ClearReceivedCalls();
			draggableButton.OnDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);

			builder.Destory();
		}

		[Test]
		public void did_not_OnPositionChanged_receive_OnEndDrag_if_draggable_button_is_right()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Right, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			var testPosition = Vector2.zero;
			Assert.AreEqual(testPosition, draggableButton.Position);

			testPosition = new Vector2(123.4f, 567.8f);
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Right;
			pData.position = testPosition;

			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);


			testPosition = new Vector2(1230.4f, 5670.8f);
			pData.position = testPosition;

			pData.button = PointerEventData.InputButton.Left;
			fakeListener.ClearReceivedCalls();
			draggableButton.OnEndDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);

			pData.button = PointerEventData.InputButton.Right;
			fakeListener.ClearReceivedCalls();
			draggableButton.OnEndDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);

			pData.button = PointerEventData.InputButton.Middle;
			fakeListener.ClearReceivedCalls();
			draggableButton.OnEndDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);

			builder.Destory();
		}

		[Test]
		public void did_OnPositionChanged_receive_after_BeginDrag_with_middle_if_draggable_button_is_middle()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Middle, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			var testPosition = Vector2.zero;
			Assert.AreEqual(testPosition, draggableButton.Position);

			testPosition = new Vector2(123.4f, 567.8f);
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Middle;
			pData.position = testPosition;

			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);
			builder.Destory();
		}

		[Test]
		public void did_not_OnPositionChanged_receive_after_BeginDrag_with_no_middle_if_draggable_button_is_middle()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Middle, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			var testPosition = Vector2.zero;
			Assert.AreEqual(testPosition, draggableButton.Position);

			testPosition = new Vector2(123.4f, 567.8f);
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.position = testPosition;

			pData.button = PointerEventData.InputButton.Left;
			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);

			pData.button = PointerEventData.InputButton.Right;
			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);
			builder.Destory();
		}

		[Test]
		public void did_OnPositionChanged_receive_OnDrag_with_middle_if_draggable_button_is_middle()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Middle, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			var testPosition = Vector2.zero;
			Assert.AreEqual(testPosition, draggableButton.Position);

			testPosition = new Vector2(123.4f, 567.8f);
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Middle;
			pData.position = testPosition;

			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);


			testPosition = new Vector2(1230.4f, 5670.8f);
			pData.position = testPosition;

			fakeListener.ClearReceivedCalls();
			draggableButton.OnDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);

			builder.Destory();
		}

		[Test]
		public void did_not_OnPositionChanged_receive_OnDrag_with_no_middle_if_draggable_button_is_middle()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Middle, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			var testPosition = Vector2.zero;
			Assert.AreEqual(testPosition, draggableButton.Position);

			testPosition = new Vector2(123.4f, 567.8f);
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Middle;
			pData.position = testPosition;

			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);

			testPosition = new Vector2(1230.4f, 5670.8f);
			pData.position = testPosition;

			pData.button = PointerEventData.InputButton.Left;
			fakeListener.ClearReceivedCalls();
			draggableButton.OnDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);

			pData.button = PointerEventData.InputButton.Right;
			fakeListener.ClearReceivedCalls();
			draggableButton.OnDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);

			builder.Destory();
		}

		[Test]
		public void did_not_OnPositionChanged_receive_OnEndDrag_if_draggable_button_is_middle()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Middle, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			var testPosition = Vector2.zero;
			Assert.AreEqual(testPosition, draggableButton.Position);

			testPosition = new Vector2(123.4f, 567.8f);
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Middle;
			pData.position = testPosition;

			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);


			testPosition = new Vector2(1230.4f, 5670.8f);
			pData.position = testPosition;

			pData.button = PointerEventData.InputButton.Left;
			fakeListener.ClearReceivedCalls();
			draggableButton.OnEndDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);

			pData.button = PointerEventData.InputButton.Right;
			fakeListener.ClearReceivedCalls();
			draggableButton.OnEndDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);

			pData.button = PointerEventData.InputButton.Middle;
			fakeListener.ClearReceivedCalls();
			draggableButton.OnEndDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);

			builder.Destory();
		}
		#endregion

		#region position
		[Test]
		public void is_position_follow_event_data_OnDrag_with_left_after_begindrag_if_draggable_is_left()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Left, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreEqual(eState.StandBy, draggableButton.State);

			var testPosition = Vector2.zero;
			Assert.AreEqual(testPosition, draggableButton.Position);

			testPosition = new Vector2(123.4f, 567.8f);
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Left;
			pData.position = testPosition;

			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);
			Assert.AreEqual(testPosition, draggableButton.Position);

			fakeListener.ClearReceivedCalls();
			testPosition = new Vector2(542.5f, 1235.4f);
			pData.position = testPosition;
			draggableButton.OnDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);
			Assert.AreEqual(testPosition, draggableButton.Position);


			fakeListener.ClearReceivedCalls();
			testPosition = new Vector2(5342.5f, 14235.4f);
			pData.position = testPosition;
			draggableButton.OnDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);
			Assert.AreEqual(testPosition, draggableButton.Position);

			builder.Destory();
		}

		[Test]
		public void is_not_position_follow_event_data_OnDrag_with_no_left_after_begindrag_if_draggable_is_left()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Left, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreEqual(eState.StandBy, draggableButton.State);

			var testPosition = Vector2.zero;
			Assert.AreEqual(testPosition, draggableButton.Position);

			testPosition = new Vector2(123.4f, 567.8f);
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Left;
			pData.position = testPosition;

			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);
			Assert.AreEqual(testPosition, draggableButton.Position);

			pData.button = PointerEventData.InputButton.Right;
			fakeListener.ClearReceivedCalls();
			testPosition = new Vector2(542.5f, 1235.4f);
			pData.position = testPosition;
			draggableButton.OnDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);
			Assert.AreNotEqual(testPosition, draggableButton.Position);


			pData.button = PointerEventData.InputButton.Middle;
			fakeListener.ClearReceivedCalls();
			testPosition = new Vector2(5342.5f, 14235.4f);
			pData.position = testPosition;
			draggableButton.OnDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);
			Assert.AreNotEqual(testPosition, draggableButton.Position);

			builder.Destory();
		}

		[Test]
		public void is_not_position_follow_event_data_OnDrag_after_OnEndDrag_with_after_begindrag_if_draggable_is_left()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Left, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreEqual(eState.StandBy, draggableButton.State);

			var testPosition = Vector2.zero;
			Assert.AreEqual(testPosition, draggableButton.Position);

			testPosition = new Vector2(123.4f, 567.8f);
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Left;
			pData.position = testPosition;

			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);
			Assert.AreEqual(testPosition, draggableButton.Position);

			fakeListener.ClearReceivedCalls();
			draggableButton.OnEndDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);

			pData.button = PointerEventData.InputButton.Left;
			fakeListener.ClearReceivedCalls();
			testPosition = new Vector2(542.5f, 1235.4f);
			pData.position = testPosition;
			draggableButton.OnDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);
			Assert.AreNotEqual(testPosition, draggableButton.Position);

			pData.button = PointerEventData.InputButton.Right;
			fakeListener.ClearReceivedCalls();
			testPosition = new Vector2(542.5f, 1235.4f);
			pData.position = testPosition;
			draggableButton.OnDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);
			Assert.AreNotEqual(testPosition, draggableButton.Position);

			pData.button = PointerEventData.InputButton.Middle;
			fakeListener.ClearReceivedCalls();
			testPosition = new Vector2(5342.5f, 14235.4f);
			pData.position = testPosition;
			draggableButton.OnDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);
			Assert.AreNotEqual(testPosition, draggableButton.Position);

			builder.Destory();
		}

		[Test]
		public void is_position_follow_event_data_OnDrag_with_right_after_begindrag_if_draggable_is_right()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Right, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreEqual(eState.StandBy, draggableButton.State);

			var testPosition = Vector2.zero;
			Assert.AreEqual(testPosition, draggableButton.Position);

			testPosition = new Vector2(123.4f, 567.8f);
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Right;
			pData.position = testPosition;

			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);
			Assert.AreEqual(testPosition, draggableButton.Position);

			fakeListener.ClearReceivedCalls();
			testPosition = new Vector2(542.5f, 1235.4f);
			pData.position = testPosition;
			draggableButton.OnDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);
			Assert.AreEqual(testPosition, draggableButton.Position);


			fakeListener.ClearReceivedCalls();
			testPosition = new Vector2(5342.5f, 14235.4f);
			pData.position = testPosition;
			draggableButton.OnDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);
			Assert.AreEqual(testPosition, draggableButton.Position);

			builder.Destory();
		}

		[Test]
		public void is_not_position_follow_event_data_OnDrag_with_no_right_after_begindrag_if_draggable_is_right()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Right, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreEqual(eState.StandBy, draggableButton.State);

			var testPosition = Vector2.zero;
			Assert.AreEqual(testPosition, draggableButton.Position);

			testPosition = new Vector2(123.4f, 567.8f);
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Right;
			pData.position = testPosition;

			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);
			Assert.AreEqual(testPosition, draggableButton.Position);

			pData.button = PointerEventData.InputButton.Left;
			fakeListener.ClearReceivedCalls();
			testPosition = new Vector2(542.5f, 1235.4f);
			pData.position = testPosition;
			draggableButton.OnDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);
			Assert.AreNotEqual(testPosition, draggableButton.Position);


			pData.button = PointerEventData.InputButton.Middle;
			fakeListener.ClearReceivedCalls();
			testPosition = new Vector2(5342.5f, 14235.4f);
			pData.position = testPosition;
			draggableButton.OnDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);
			Assert.AreNotEqual(testPosition, draggableButton.Position);

			builder.Destory();
		}

		[Test]
		public void is_not_position_follow_event_data_OnDrag_after_OnEndDrag_with_after_begindrag_if_draggable_is_right()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Right, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreEqual(eState.StandBy, draggableButton.State);

			var testPosition = Vector2.zero;
			Assert.AreEqual(testPosition, draggableButton.Position);

			testPosition = new Vector2(123.4f, 567.8f);
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Right;
			pData.position = testPosition;

			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);
			Assert.AreEqual(testPosition, draggableButton.Position);

			fakeListener.ClearReceivedCalls();
			draggableButton.OnEndDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);

			pData.button = PointerEventData.InputButton.Left;
			fakeListener.ClearReceivedCalls();
			testPosition = new Vector2(542.5f, 1235.4f);
			pData.position = testPosition;
			draggableButton.OnDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);
			Assert.AreNotEqual(testPosition, draggableButton.Position);

			pData.button = PointerEventData.InputButton.Right;
			fakeListener.ClearReceivedCalls();
			testPosition = new Vector2(542.5f, 1235.4f);
			pData.position = testPosition;
			draggableButton.OnDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);
			Assert.AreNotEqual(testPosition, draggableButton.Position);

			pData.button = PointerEventData.InputButton.Middle;
			fakeListener.ClearReceivedCalls();
			testPosition = new Vector2(5342.5f, 14235.4f);
			pData.position = testPosition;
			draggableButton.OnDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);
			Assert.AreNotEqual(testPosition, draggableButton.Position);

			builder.Destory();
		}

		[Test]
		public void is_position_follow_event_data_OnDrag_with_middle_after_begindrag_if_draggable_is_middle()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Middle, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreEqual(eState.StandBy, draggableButton.State);

			var testPosition = Vector2.zero;
			Assert.AreEqual(testPosition, draggableButton.Position);

			testPosition = new Vector2(123.4f, 567.8f);
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Middle;
			pData.position = testPosition;

			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);
			Assert.AreEqual(testPosition, draggableButton.Position);

			fakeListener.ClearReceivedCalls();
			testPosition = new Vector2(542.5f, 1235.4f);
			pData.position = testPosition;
			draggableButton.OnDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);
			Assert.AreEqual(testPosition, draggableButton.Position);


			fakeListener.ClearReceivedCalls();
			testPosition = new Vector2(5342.5f, 14235.4f);
			pData.position = testPosition;
			draggableButton.OnDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);
			Assert.AreEqual(testPosition, draggableButton.Position);

			builder.Destory();
		}

		[Test]
		public void is_not_position_follow_event_data_OnDrag_with_no_middle_after_begindrag_if_draggable_is_middle()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Middle, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreEqual(eState.StandBy, draggableButton.State);

			var testPosition = Vector2.zero;
			Assert.AreEqual(testPosition, draggableButton.Position);

			testPosition = new Vector2(123.4f, 567.8f);
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Middle;
			pData.position = testPosition;

			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);
			Assert.AreEqual(testPosition, draggableButton.Position);

			pData.button = PointerEventData.InputButton.Left;
			fakeListener.ClearReceivedCalls();
			testPosition = new Vector2(542.5f, 1235.4f);
			pData.position = testPosition;
			draggableButton.OnDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);
			Assert.AreNotEqual(testPosition, draggableButton.Position);


			pData.button = PointerEventData.InputButton.Right;
			fakeListener.ClearReceivedCalls();
			testPosition = new Vector2(5342.5f, 14235.4f);
			pData.position = testPosition;
			draggableButton.OnDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);
			Assert.AreNotEqual(testPosition, draggableButton.Position);

			builder.Destory();
		}

		[Test]
		public void is_not_position_follow_event_data_OnDrag_after_OnEndDrag_with_after_begindrag_if_draggable_is_middle()
		{
			var builder = Builder.Create().CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Middle, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			Assert.AreEqual(eState.StandBy, draggableButton.State);

			var testPosition = Vector2.zero;
			Assert.AreEqual(testPosition, draggableButton.Position);

			testPosition = new Vector2(123.4f, 567.8f);
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = PointerEventData.InputButton.Middle;
			pData.position = testPosition;

			fakeListener.ClearReceivedCalls();
			draggableButton.OnBeginDrag(pData);
			fakeListener.Received().OnPositionChanged(testPosition);
			Assert.AreEqual(testPosition, draggableButton.Position);

			fakeListener.ClearReceivedCalls();
			draggableButton.OnEndDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);

			pData.button = PointerEventData.InputButton.Left;
			fakeListener.ClearReceivedCalls();
			testPosition = new Vector2(542.5f, 1235.4f);
			pData.position = testPosition;
			draggableButton.OnDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);
			Assert.AreNotEqual(testPosition, draggableButton.Position);

			pData.button = PointerEventData.InputButton.Right;
			fakeListener.ClearReceivedCalls();
			testPosition = new Vector2(542.5f, 1235.4f);
			pData.position = testPosition;
			draggableButton.OnDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);
			Assert.AreNotEqual(testPosition, draggableButton.Position);

			pData.button = PointerEventData.InputButton.Middle;
			fakeListener.ClearReceivedCalls();
			testPosition = new Vector2(5342.5f, 14235.4f);
			pData.position = testPosition;
			draggableButton.OnDrag(pData);
			fakeListener.DidNotReceive().OnPositionChanged(testPosition);
			Assert.AreNotEqual(testPosition, draggableButton.Position);

			builder.Destory();
		}
		#endregion
		#endregion

		#region OnPointerDown
		[Test]
		public void state_is_OnDrag_if_OnPointerDown_with_left_btn_delayed_if_draggable_button_is_left()
		{
			CheckPointerDown_positive(PointerEventData.InputButton.Left, PointerEventData.InputButton.Left);
		}

		[Test]
		public void state_is_StandBy_if_OnPointerDown_with_no_left_btn_delayed_if_draggable_button_is_left()
		{
			CheckPointerDown_negative(PointerEventData.InputButton.Left, PointerEventData.InputButton.Right);
			CheckPointerDown_negative(PointerEventData.InputButton.Left, PointerEventData.InputButton.Middle);
		}

		[Test]
		public void state_is_OnDrag_if_OnPointerDown_with_right_btn_delayed_if_draggable_button_is_right()
		{
			CheckPointerDown_positive(PointerEventData.InputButton.Right, PointerEventData.InputButton.Right);
		}

		[Test]
		public void state_is_StandBy_if_OnPointerDown_with_no_right_btn_delayed_if_draggable_button_is_right()
		{
			CheckPointerDown_negative(PointerEventData.InputButton.Right, PointerEventData.InputButton.Left);
			CheckPointerDown_negative(PointerEventData.InputButton.Right, PointerEventData.InputButton.Middle);
		}

		[Test]
		public void state_is_OnDrag_if_OnPointerDown_with_middle_btn_delayed_if_draggable_button_is_middle()
		{
			CheckPointerDown_positive(PointerEventData.InputButton.Middle, PointerEventData.InputButton.Middle);
		}

		[Test]
		public void state_is_StandBy_if_OnPointerDown_with_no_middle_btn_delayed_if_draggable_button_is_middle()
		{
			CheckPointerDown_negative(PointerEventData.InputButton.Middle, PointerEventData.InputButton.Left);
			CheckPointerDown_negative(PointerEventData.InputButton.Middle, PointerEventData.InputButton.Right);
		}

		[Test]
		public void is_position_of_dragable_change_with_left_btn_delayed_if_draggable_button_is_left()
		{
			var builder = Builder.Create().CreateCanvas(out var canvas).CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, PointerEventData.InputButton.Left, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);
			PointerEventData.InputButton testButton = PointerEventData.InputButton.Left;
			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = testButton;
			pData.position = new Vector2(123, 123);
			draggableButton.OnPointerDown(pData);
			draggableButton.Update(0.1f);
			Assert.AreEqual(pData.position, draggableButton.Position);
			Assert.AreEqual(eState.OnDrag, draggableButton.State);
			Assert.AreNotEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}

		private void CheckPointerDown_positive(PointerEventData.InputButton draggableButtonType, PointerEventData.InputButton testButton)
		{
			var builder = Builder.Create().CreateCanvas(out var canvas).CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, draggableButtonType, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = testButton;
			draggableButton.OnPointerDown(pData);
			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);
			draggableButton.Update(0.09f);
			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);
			draggableButton.Update(0.01f);
			Assert.AreEqual(eState.OnDrag, draggableButton.State);
			Assert.AreNotEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}

		private void CheckPointerDown_negative(PointerEventData.InputButton draggableButtonType, PointerEventData.InputButton testButton)
		{
			var builder = Builder.Create().CreateCanvas(out var canvas).CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, draggableButtonType, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = testButton;
			draggableButton.OnPointerDown(pData);
			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);
			draggableButton.Update(0.09f);
			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);
			draggableButton.Update(0.01f);
			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}
		#endregion

		#region OnPointerUp
		[Test]
		public void is_state_StandBy_after_OnPointerUp_with_left_if_draggable_button_is_left()
		{
			is_state_StandBy_after_OnPointerUp(PointerEventData.InputButton.Left);
		}

		[Test]
		public void is_state_StandBy_after_OnPointerUp_with_right_if_draggable_button_is_right()
		{
			is_state_StandBy_after_OnPointerUp(PointerEventData.InputButton.Right);
		}

		[Test]
		public void is_state_StandBy_after_OnPointerUp_with_middle_if_draggable_button_is_middle()
		{
			is_state_StandBy_after_OnPointerUp(PointerEventData.InputButton.Middle);
		}

		[Test]
		public void is_state_OnDrag_after_OnPointerUp_with_no_left_if_draggable_button_is_left()
		{
			is_state_OnDrag_after_OnPointerUp_with_bad_type(PointerEventData.InputButton.Left, PointerEventData.InputButton.Right);
			is_state_OnDrag_after_OnPointerUp_with_bad_type(PointerEventData.InputButton.Left, PointerEventData.InputButton.Middle);
		}

		[Test]
		public void is_state_OnDrag_after_OnPointerUp_with_no_right_if_draggable_button_is_right()
		{
			is_state_OnDrag_after_OnPointerUp_with_bad_type(PointerEventData.InputButton.Right, PointerEventData.InputButton.Left);
			is_state_OnDrag_after_OnPointerUp_with_bad_type(PointerEventData.InputButton.Right, PointerEventData.InputButton.Middle);
		}

		[Test]
		public void is_state_OnDrag_after_OnPointerUp_with_no_middle_if_draggable_button_is_middle()
		{
			is_state_OnDrag_after_OnPointerUp_with_bad_type(PointerEventData.InputButton.Middle, PointerEventData.InputButton.Left);
			is_state_OnDrag_after_OnPointerUp_with_bad_type(PointerEventData.InputButton.Middle, PointerEventData.InputButton.Right);
		}

		public void is_state_StandBy_after_OnPointerUp(PointerEventData.InputButton draggableButtonType)
		{
			var builder = Builder.Create().CreateCanvas(out var canvas).CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, draggableButtonType, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = draggableButtonType;
			draggableButton.OnPointerDown(pData);

			fakeListener.ClearReceivedCalls();
			draggableButton.Update(0.1f);
			Assert.AreEqual(eState.OnDrag, draggableButton.State);
			Assert.AreNotEqual(eState.StandBy, draggableButton.State);

			fakeListener.Received().OnStateChanged(eState.OnDrag);
			fakeListener.ClearReceivedCalls();

			draggableButton.OnPointerUp(pData);
			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
			Assert.AreEqual(eState.StandBy, draggableButton.State);

			builder.Destory();
		}

		public void is_state_OnDrag_after_OnPointerUp_with_bad_type(PointerEventData.InputButton draggableButtonType, PointerEventData.InputButton badType)
		{
			var builder = Builder.Create().CreateCanvas(out var canvas).CreateDraggableButton(out var draggableButton, out var isDragEnabledRef, draggableButtonType, 0.1f, true).CreateSubstituteListener(draggableButton, draggableButton.ClickEvents,  out var fakeListener);

			PointerEventData pData = new PointerEventData(EventSystem.current);
			pData.button = draggableButtonType;
			draggableButton.OnPointerDown(pData);
			fakeListener.ClearReceivedCalls();
			draggableButton.Update(0.1f);
			Assert.AreEqual(eState.OnDrag, draggableButton.State);
			Assert.AreNotEqual(eState.StandBy, draggableButton.State);

			fakeListener.Received().OnStateChanged(eState.OnDrag);
			fakeListener.ClearReceivedCalls();

			pData.button = badType;
			draggableButton.OnPointerUp(pData);
			fakeListener.DidNotReceive().OnStateChanged(eState.StandBy);
			fakeListener.ClearReceivedCalls();
			Assert.AreNotEqual(eState.StandBy, draggableButton.State);
			Assert.AreEqual(eState.OnDrag, draggableButton.State);

			pData.button = draggableButtonType;
			draggableButton.OnPointerUp(pData);
			fakeListener.Received().OnStateChanged(eState.StandBy);
			fakeListener.ClearReceivedCalls();
			Assert.AreEqual(eState.StandBy, draggableButton.State);
			Assert.AreNotEqual(eState.OnDrag, draggableButton.State);

			builder.Destory();
		}
		#endregion
	}
}
