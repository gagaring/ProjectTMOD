using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using VEngine.Input;
using VEngine.SO.Events;
using VEngine.SO.Variables;

namespace VTest
{
    public class InputVariableTest
    {
		[Test]
		public void input_variable_with_on_change_event_set_from_false_to_true()
		{
			CheckInput(false, true, true);
		}

		[Test]
		public void input_variable_with_on_change_event_set_from_false_to_false()
		{
			CheckInput(false, false, true);
		}

		[Test]
		public void input_variable_with_on_change_event_set_from_true_to_false()
		{
			CheckInput(true, false, true);
		}

		[Test]
		public void input_variable_with_on_change_event_set_from_true_to_true()
		{
			CheckInput(true, true, true);

        }

        private void CheckInput(bool baseValue, bool targetValue, bool received)
        {
            var gameEventListener = Substitute.For<IGameEventListener<bool>>();
            CreateVariable(out var vwoce, out var variable, out var gameEvent);
            vwoce.Value = baseValue;
            gameEventListener.DidNotReceive().OnEventRaised(targetValue);
            gameEvent.RegisterListener(gameEventListener);
            vwoce.Value = targetValue;
            Assert.AreEqual(vwoce.Value, targetValue);
            if (received)
                gameEventListener.Received().OnEventRaised(targetValue);
            else
                gameEventListener.DidNotReceive().OnEventRaised(targetValue);
        }

        private void CreateVariable(out InputEnabledWithOnChangeEvent variableWithOnChangeEvent, out BoolVariable variable, out BoolGameEvent gameEvent)
        {
            variableWithOnChangeEvent = ScriptableObject.CreateInstance<InputEnabledWithOnChangeEvent>();
            variable = ScriptableObject.CreateInstance<BoolVariable>();
            gameEvent = ScriptableObject.CreateInstance<BoolGameEvent>();

            variableWithOnChangeEvent.SetVariable(variable);
            variableWithOnChangeEvent.SetOnChangeEvent(gameEvent);
        }

        private void CreateVariableWithRegisterListener(out InputEnabledWithOnChangeEvent variableWithOnChangeEvent, out BoolVariable variable, out BoolGameEvent gameEvent, ref IGameEventListener<bool> gameEventListener)
        {
            CreateVariable(out variableWithOnChangeEvent, out variable, out gameEvent);
            gameEvent.RegisterListener(gameEventListener);
        }
    }
}
