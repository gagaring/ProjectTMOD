using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using VEngine.Input;
using VEngine.SO.Events;
using VEngine.SO.Variables;

namespace VTest
{
    public class InputSetTest
	{
		[Test]
		public void inputStack_activated_event_received_after_activation()
		{
			var inputStack = ScriptableObject.CreateInstance<InputStack>();
			var inputList = new List<InputEnabledWithOnChangeEvent>();
			CreateInput(out var input, out var variable, out var gameEvent, out var gameEventListener);
			inputList.Add(input);

			var hash = inputStack.Activate(inputList);
			gameEventListener.Received().OnEventRaised(true);
		}

		[Test]
		public void inputStack_deactivated_event_received_after_deactivation()
		{
			var inputStack = ScriptableObject.CreateInstance<InputStack>();
			var inputList = new List<InputEnabledWithOnChangeEvent>();
			CreateInput(out var input, out var variable, out var gameEvent, out var gameEventListener);
			inputList.Add(input);

			var hash = inputStack.Activate(inputList);
			inputStack.Deactivate(hash);
			gameEventListener.Received().OnEventRaised(false);
		}

		[Test]
		public void inputStack_activated_event_received_after_second_inputs_activations()
		{
			var inputStack = ScriptableObject.CreateInstance<InputStack>();
			var inputList1 = new List<InputEnabledWithOnChangeEvent>();
			var inputList2 = new List<InputEnabledWithOnChangeEvent>();
			CreateInput(out var input1, out var variable1, out var gameEvent1, out var gameEventListener1);
			CreateInput(out var input2, out var variable2, out var gameEvent2, out var gameEventListener2);

			inputList1.Add(input1);
			inputList2.Add(input2);

			var hash1 = inputStack.Activate(inputList1);
			var hash2 = inputStack.Activate(inputList2);
			gameEventListener2.Received().OnEventRaised(true);
		}

		[Test]
		public void inputStack_deactivated_event_received_after_second_inputs_activations()
		{
			var inputStack = ScriptableObject.CreateInstance<InputStack>();
			var inputList1 = new List<InputEnabledWithOnChangeEvent>();
			var inputList2 = new List<InputEnabledWithOnChangeEvent>();
			CreateInput(out var input1, out var variable1, out var gameEvent1, out var gameEventListener1);
			CreateInput(out var input2, out var variable2, out var gameEvent2, out var gameEventListener2);

			inputList1.Add(input1);
			inputList2.Add(input2);

			var hash1 = inputStack.Activate(inputList1);
			var hash2 = inputStack.Activate(inputList2);
			gameEventListener1.Received().OnEventRaised(false);
		}

		[Test]
		public void all_inputStack_activated_event_received_after_activation()
		{
			var inputStack = ScriptableObject.CreateInstance<InputStack>();
			var inputList = new List<InputEnabledWithOnChangeEvent>();
			CreateInput(out var input1, out var variable1, out var gameEvent1, out var gameEventListener1);
			CreateInput(out var input2, out var variable2, out var gameEvent2, out var gameEventListener2);
			inputList.Add(input1);
			inputList.Add(input2);

			var hash = inputStack.Activate(inputList);
			gameEventListener1.Received().OnEventRaised(true);
			gameEventListener2.Received().OnEventRaised(true);
		}

		[Test]
		public void all_inputStack_deactivated_event_received_after_deactivation()
		{
			var inputStack = ScriptableObject.CreateInstance<InputStack>();
			var inputList = new List<InputEnabledWithOnChangeEvent>();
			CreateInput(out var input1, out var variable1, out var gameEvent1, out var gameEventListener1);
			CreateInput(out var input2, out var variable2, out var gameEvent2, out var gameEventListener2);
			inputList.Add(input1);
			inputList.Add(input2);

			var hash = inputStack.Activate(inputList);
			inputStack.Deactivate(hash);
			gameEventListener1.Received().OnEventRaised(false);
			gameEventListener2.Received().OnEventRaised(false);
		}

		[Test]
		public void all_inputStack_activated_event_received_after_second_inputs_activations()
		{
			var inputStack = ScriptableObject.CreateInstance<InputStack>();
			CreateInput(out var input1_1, out var variable1_1, out var gameEvent1_1, out var gameEventListener1_1);
			CreateInput(out var input1_2, out var variable1_2, out var gameEvent1_2, out var gameEventListener1_2);

			CreateInput(out var input2_1, out var variable2_1, out var gameEvent2_1, out var gameEventListener2_1);
			CreateInput(out var input2_2, out var variable2_2, out var gameEvent2_2, out var gameEventListener2_2);

			var inputList1 = new List<InputEnabledWithOnChangeEvent>();
			var inputList2 = new List<InputEnabledWithOnChangeEvent>();

			inputList1.Add(input1_1);
			inputList1.Add(input1_2);
			inputList2.Add(input2_1);
			inputList2.Add(input2_2);

			var hash1 = inputStack.Activate(inputList1);
			var hash2 = inputStack.Activate(inputList2);
			gameEventListener2_1.Received().OnEventRaised(true);
			gameEventListener2_2.Received().OnEventRaised(true);
		}

		[Test]
		public void all_inputStack_deactivated_event_received_after_second_inputs_activations()
		{
			var inputStack = ScriptableObject.CreateInstance<InputStack>();
			CreateInput(out var input1_1, out var variable1_1, out var gameEvent1_1, out var gameEventListener1_1);
			CreateInput(out var input1_2, out var variable1_2, out var gameEvent1_2, out var gameEventListener1_2);

			CreateInput(out var input2_1, out var variable2_1, out var gameEvent2_1, out var gameEventListener2_1);
			CreateInput(out var input2_2, out var variable2_2, out var gameEvent2_2, out var gameEventListener2_2);

			var inputList1 = new List<InputEnabledWithOnChangeEvent>();
			var inputList2 = new List<InputEnabledWithOnChangeEvent>();

			inputList1.Add(input1_1);
			inputList1.Add(input1_2);
			inputList2.Add(input2_1);
			inputList2.Add(input2_2);

			var hash1 = inputStack.Activate(inputList1);
			var hash2 = inputStack.Activate(inputList2);
			gameEventListener1_1.Received().OnEventRaised(false);
			gameEventListener1_2.Received().OnEventRaised(false);
		}

		private void CreateInput(out InputEnabledWithOnChangeEvent input, out BoolVariable variable, out BoolGameEvent gameEvent, out IGameEventListener<bool> gameEventListener)
		{
			input = ScriptableObject.CreateInstance<InputEnabledWithOnChangeEvent>();
			variable = ScriptableObject.CreateInstance<BoolVariable>();
			gameEvent = ScriptableObject.CreateInstance<BoolGameEvent>();
			gameEventListener = Substitute.For<IGameEventListener<bool>>();
			gameEvent.RegisterListener(gameEventListener);
			input.SetOnChangeEvent(gameEvent);
			input.SetVariable(variable);
		}
	}
}
