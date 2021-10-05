using NSubstitute;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TestTools;
using VEngine.GUI.Draggable;

namespace VTest.GUI.Draggable
{
    public class DraggableButtonPlayTest
	{
		#region OnPointerDown
		//[UnityTest]
		//public IEnumerator state_is_OnDrag_if_OnPointerDown_with_left_btn_delayed_if_draggable_button_is_left()
		//{
		//	yield return CheckPointerDown_positive(PointerEventData.InputButton.Left, PointerEventData.InputButton.Left);
		//}

		//[UnityTest]
		//public IEnumerator state_is_StandBy_if_OnPointerDown_with_no_left_btn_delayed_if_draggable_button_is_left()
		//{
		//	yield return CheckPointerDown_negative(PointerEventData.InputButton.Left, PointerEventData.InputButton.Right);
		//	yield return CheckPointerDown_negative(PointerEventData.InputButton.Left, PointerEventData.InputButton.Middle);
		//}

		//[UnityTest]
		//public IEnumerator state_is_OnDrag_if_OnPointerDown_with_right_btn_delayed_if_draggable_button_is_right()
		//{
		//	yield return CheckPointerDown_positive(PointerEventData.InputButton.Right, PointerEventData.InputButton.Right);
		//}

		//[UnityTest]
		//public IEnumerator state_is_StandBy_if_OnPointerDown_with_no_right_btn_delayed_if_draggable_button_is_right()
		//{
		//	yield return CheckPointerDown_negative(PointerEventData.InputButton.Right, PointerEventData.InputButton.Left);
		//	yield return CheckPointerDown_negative(PointerEventData.InputButton.Right, PointerEventData.InputButton.Middle);
		//}

		//[UnityTest]
		//public IEnumerator state_is_OnDrag_if_OnPointerDown_with_middle_btn_delayed_if_draggable_button_is_middle()
		//{
		//	yield return CheckPointerDown_positive(PointerEventData.InputButton.Middle, PointerEventData.InputButton.Middle);
		//}

		//[UnityTest]
		//public IEnumerator state_is_StandBy_if_OnPointerDown_with_no_middle_btn_delayed_if_draggable_button_is_middle()
		//{
		//	yield return CheckPointerDown_negative(PointerEventData.InputButton.Middle, PointerEventData.InputButton.Left);
		//	yield return CheckPointerDown_negative(PointerEventData.InputButton.Middle, PointerEventData.InputButton.Right);
		//}

		//[UnityTest]
		//public IEnumerator is_position_of_dragable_change_with_left_btn_delayed_if_draggable_button_is_left()
		//{
		//	var builder = Builder.Create().CreateCanvas(out var canvas).CreateDraggableButton(out var draggableButton, PointerEventData.InputButton.Left).CreateSubstituteListener(draggableButton, out var fakeListener);
		//	PointerEventData.InputButton testButton = PointerEventData.InputButton.Left;
		//	PointerEventData pData = new PointerEventData(EventSystem.current);
		//	pData.button = testButton;
		//	pData.position = new Vector2(123, 123);
		//	draggableButton.OnPointerDown(pData);
		//	yield return new WaitForSeconds(0.1f);
		//	Assert.AreEqual(pData.position, draggableButton.Position);
		//	Assert.AreEqual(eState.OnDrag, draggableButton.State);
		//	Assert.AreNotEqual(eState.StandBy, draggableButton.State);

		//	builder.Destory();
		//}

		//private IEnumerator CheckPointerDown_positive(PointerEventData.InputButton draggableButtonType, PointerEventData.InputButton testButton)
		//{
		//	var builder = Builder.Create().CreateCanvas(out var canvas).CreateDraggableButton(out var draggableButton, draggableButtonType).CreateSubstituteListener(draggableButton, out var fakeListener);

		//	PointerEventData pData = new PointerEventData(EventSystem.current);
		//	pData.button = testButton;
		//	draggableButton.OnPointerDown(pData);
		//	Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
		//	Assert.AreEqual(eState.StandBy, draggableButton.State);
		//	yield return new WaitForSeconds(0.09f);
		//	Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
		//	Assert.AreEqual(eState.StandBy, draggableButton.State);
		//	yield return new WaitForSeconds(0.01f);
		//	Assert.AreEqual(eState.OnDrag, draggableButton.State);
		//	Assert.AreNotEqual(eState.StandBy, draggableButton.State);

		//	builder.Destory();
		//}

		//private IEnumerator CheckPointerDown_negative(PointerEventData.InputButton draggableButtonType, PointerEventData.InputButton testButton)
		//{
		//	var builder = Builder.Create().CreateCanvas(out var canvas).CreateDraggableButton(out var draggableButton, draggableButtonType).CreateSubstituteListener(draggableButton, out var fakeListener);

		//	PointerEventData pData = new PointerEventData(EventSystem.current);
		//	pData.button = testButton;
		//	draggableButton.OnPointerDown(pData);
		//	Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
		//	Assert.AreEqual(eState.StandBy, draggableButton.State);
		//	yield return new WaitForSeconds(0.09f);
		//	Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
		//	Assert.AreEqual(eState.StandBy, draggableButton.State);
		//	yield return new WaitForSeconds(0.01f);
		//	Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
		//	Assert.AreEqual(eState.StandBy, draggableButton.State);

		//	builder.Destory();
		//}
		//#endregion

		//#region OnPointerUp
		//[UnityTest]
		//public IEnumerator is_state_StandBy_after_OnPointerUp_with_left_if_draggable_button_is_left()
		//{
		//	yield return is_state_StandBy_after_OnPointerUp(PointerEventData.InputButton.Left);
		//}

		//[UnityTest]
		//public IEnumerator is_state_StandBy_after_OnPointerUp_with_right_if_draggable_button_is_right()
		//{
		//	yield return is_state_StandBy_after_OnPointerUp(PointerEventData.InputButton.Right);
		//}

		//[UnityTest]
		//public IEnumerator is_state_StandBy_after_OnPointerUp_with_middle_if_draggable_button_is_middle()
		//{
		//	yield return is_state_StandBy_after_OnPointerUp(PointerEventData.InputButton.Middle);
		//}

		//[UnityTest]
		//public IEnumerator is_state_OnDrag_after_OnPointerUp_with_no_left_if_draggable_button_is_left()
		//{
		//	yield return is_state_OnDrag_after_OnPointerUp_with_bad_type(PointerEventData.InputButton.Left, PointerEventData.InputButton.Right);
		//	yield return is_state_OnDrag_after_OnPointerUp_with_bad_type(PointerEventData.InputButton.Left, PointerEventData.InputButton.Middle);
		//}

		//[UnityTest]
		//public IEnumerator is_state_OnDrag_after_OnPointerUp_with_no_right_if_draggable_button_is_right()
		//{
		//	yield return is_state_OnDrag_after_OnPointerUp_with_bad_type(PointerEventData.InputButton.Right, PointerEventData.InputButton.Left);
		//	yield return is_state_OnDrag_after_OnPointerUp_with_bad_type(PointerEventData.InputButton.Right, PointerEventData.InputButton.Middle);
		//}

		//[UnityTest]
		//public IEnumerator is_state_OnDrag_after_OnPointerUp_with_no_middle_if_draggable_button_is_middle()
		//{
		//	yield return is_state_OnDrag_after_OnPointerUp_with_bad_type(PointerEventData.InputButton.Middle, PointerEventData.InputButton.Left);
		//	yield return is_state_OnDrag_after_OnPointerUp_with_bad_type(PointerEventData.InputButton.Middle, PointerEventData.InputButton.Right);
		//}

		//public IEnumerator is_state_StandBy_after_OnPointerUp(PointerEventData.InputButton draggableButtonType)
		//{
		//	var builder = Builder.Create().CreateCanvas(out var canvas).CreateDraggableButton(out var draggableButton, draggableButtonType).CreateSubstituteListener(draggableButton, out var fakeListener);

		//	PointerEventData pData = new PointerEventData(EventSystem.current);
		//	pData.button = draggableButtonType;
		//	draggableButton.OnPointerDown(pData);

		//	fakeListener.ClearReceivedCalls();
		//	yield return new WaitForSeconds(0.1f);
		//	Assert.AreEqual(eState.OnDrag, draggableButton.State);
		//	Assert.AreNotEqual(eState.StandBy, draggableButton.State);

		//	fakeListener.Received().OnStateChanged(eState.OnDrag);
		//	fakeListener.ClearReceivedCalls();

		//	draggableButton.OnPointerUp(pData);
		//	Assert.AreNotEqual(eState.OnDrag, draggableButton.State);
		//	Assert.AreEqual(eState.StandBy, draggableButton.State);

		//	builder.Destory();
		//}

		//public IEnumerator is_state_OnDrag_after_OnPointerUp_with_bad_type(PointerEventData.InputButton draggableButtonType, PointerEventData.InputButton badType)
		//{
		//	var builder = Builder.Create().CreateCanvas(out var canvas).CreateDraggableButton(out var draggableButton, draggableButtonType).CreateSubstituteListener(draggableButton, out var fakeListener);

		//	PointerEventData pData = new PointerEventData(EventSystem.current);
		//	pData.button = draggableButtonType;
		//	draggableButton.OnPointerDown(pData);
		//	fakeListener.ClearReceivedCalls();
		//	yield return new WaitForSeconds(0.1f);
		//	Assert.AreEqual(eState.OnDrag, draggableButton.State);
		//	Assert.AreNotEqual(eState.StandBy, draggableButton.State);

		//	fakeListener.Received().OnStateChanged(eState.OnDrag);
		//	fakeListener.ClearReceivedCalls();

		//	pData.button = badType;
		//	draggableButton.OnPointerUp(pData);
		//	fakeListener.DidNotReceive().OnStateChanged(eState.StandBy);
		//	fakeListener.ClearReceivedCalls();
		//	Assert.AreNotEqual(eState.StandBy, draggableButton.State);
		//	Assert.AreEqual(eState.OnDrag, draggableButton.State);

		//	pData.button = draggableButtonType;
		//	draggableButton.OnPointerUp(pData);
		//	fakeListener.Received().OnStateChanged(eState.StandBy);
		//	fakeListener.ClearReceivedCalls();
		//	Assert.AreEqual(eState.StandBy, draggableButton.State);
		//	Assert.AreNotEqual(eState.OnDrag, draggableButton.State);

		//	builder.Destory();
		//}
		#endregion
	}
}
