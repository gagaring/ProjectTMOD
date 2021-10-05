using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using VEngine.SO.Events;
using VEngine.SO.Variables;

namespace VTest
{
    public class SimpleSOVariableWithOnChangeEventTest
    {
        #region bool
        [Test]
        public void bool_variable_with_on_change_event_set_from_false_to_true()
        {
            CheckBool(false, true, true);
        }

        [Test]
        public void bool_variable_with_on_change_event_set_from_false_to_false()
        {
            CheckBool(false, false, false);
        }

        [Test]
        public void bool_variable_with_on_change_event_set_from_true_to_false()
        {
            CheckBool(true, false, true);
        }

        [Test]
        public void bool_variable_with_on_change_event_set_from_true_to_true()
        {
            CheckBool(true, true, false);
        }

        private void CheckBool(bool baseValue, bool targetValue, bool received)
        {
            Check<BoolVariable, BoolVariableWithOnChangeEvent, bool, BoolGameEvent, IGameEventListener<bool>>(baseValue, targetValue, received);
        }
        #endregion

        #region float
        [Test]
        public void float_variable_with_on_change_event_set_from_0_to_0()
        {
            CheckFloat(0, 0, false);
        }

        [Test]
        public void float_variable_with_on_change_event_set_from_0_to_half()
        {
            CheckFloat(0, 1, true);
        }

        [Test]
        public void float_variable_with_on_change_event_set_from_0_to_custom()
        {
            CheckFloat(0, 0.5f, true);
        }

        [Test]
        public void float_variable_with_on_change_event_set_from_1_0()
        {
            CheckFloat(1, 0, true);
        }

        [Test]
        public void float_variable_with_on_change_event_set_from_1_1()
        {
            CheckFloat(1, 1, false);
        }

        [Test]
        public void float_variable_with_on_change_event_set_from_1_custom()
        {
            CheckFloat(1, 0.5f, true);
        }

        [Test]
        public void float_variable_with_on_change_event_set_from_custom_0()
        {
            CheckFloat(0.5f, 0, true);
        }

        [Test]
        public void float_variable_with_on_change_event_set_from_custom_1()
        {
            CheckFloat(0.5f, 1, true);
        }

        [Test]
        public void float_variable_with_on_change_event_set_from_custom_custom()
        {
            CheckFloat(0.5f, 0.5f, false);
        }

        [Test]
        public void float_variable_with_on_change_event_set_from_custom_minus_custom()
        {
            CheckFloat(0.5f, -0.5f, true);
        }

        [Test]
        public void float_variable_with_on_change_event_set_from_minus_custom_to_custom()
        {
            CheckFloat(-0.5f, 0.5f, true);
        }

        [Test]
        public void float_variable_with_on_change_event_set_from_minus_custom_minus_custom()
        {
            CheckFloat(-0.5f, -0.5f, false);
        }

        private void CheckFloat(float baseValue, float targetValue, bool received)
        {
            Check<FloatVariable, FloatVariableWithOnChangeEvent, float, FloatGameEvent, IGameEventListener<float>>(baseValue, targetValue, received);
        }
        #endregion

        #region int
        [Test]
        public void int_variable_with_on_change_event_set_from_0_to_0()
        {
            CheckInt(0, 0, false);
        }

        [Test]
        public void int_variable_with_on_change_event_set_from_0_to_1()
        {
            CheckInt(0, 1, true);
        }

        [Test]
        public void int_variable_with_on_change_event_set_from_0_to_custom()
        {
            CheckInt(0, 1234, true);
        }

        [Test]
        public void int_variable_with_on_change_event_set_from_1_0()
        {
            CheckInt(1, 0, true);
        }

        [Test]
        public void int_variable_with_on_change_event_set_from_1_1()
        {
            CheckInt(1, 1, false);
        }

        [Test]
        public void int_variable_with_on_change_event_set_from_1_custom()
        {
            CheckInt(1, 1234, true);
        }

        [Test]
        public void int_variable_with_on_change_event_set_from_custom_0()
        {
            CheckInt(1234, 0, true);
        }

        [Test]
        public void int_variable_with_on_change_event_set_from_custom_1()
        {
            CheckInt(1234, 1, true);
        }

        [Test]
        public void int_variable_with_on_change_event_set_from_custom_custom()
        {
            CheckInt(1234, 1234, false);
        }

        [Test]
        public void int_variable_with_on_change_event_set_from_custom_minus_custom()
        {
            CheckInt(1234, -1234, true);
        }

        [Test]
        public void int_variable_with_on_change_event_set_from_minus_custom_to_custom()
        {
            CheckInt(-1234, 1234, true);
        }

        [Test]
        public void int_variable_with_on_change_event_set_from_minus_custom_minus_custom()
        {
            CheckInt(-1234, -1234, false);
        }

        private void CheckInt(int baseValue, int targetValue, bool received)
        {
            Check<IntVariable, IntVariableWithOnChangeEvent, int, IntGameEvent, IGameEventListener<int>>(baseValue, targetValue, received);
        }
        #endregion

        #region uint
        [Test]
        public void uint_variable_with_on_change_event_set_from_0_to_0()
        {
            CheckUInt(0, 0, false);
        }

        [Test]
        public void uint_variable_with_on_change_event_set_from_0_to_1()
        {
            CheckUInt(0, 1, true);
        }

        [Test]
        public void uint_variable_with_on_change_event_set_from_0_to_custom()
        {
            CheckUInt(0, 1234, true);
        }

        [Test]
        public void uint_variable_with_on_change_event_set_from_1_0()
        {
            CheckUInt(1, 0, true);
        }

        [Test]
        public void uint_variable_with_on_change_event_set_from_1_1()
        {
            CheckUInt(1, 1, false);
        }

        [Test]
        public void uint_variable_with_on_change_event_set_from_1_custom()
        {
            CheckUInt(1, 1234, true);
        }

        [Test]
        public void uint_variable_with_on_change_event_set_from_custom_0()
        {
            CheckUInt(1234, 0, true);
        }

        [Test]
        public void uint_variable_with_on_change_event_set_from_custom_1()
        {
            CheckUInt(1234, 1, true);
        }

        [Test]
        public void uint_variable_with_on_change_event_set_from_custom_custom()
        {
            CheckUInt(1234, 1234, false);
        }

        private void CheckUInt(uint baseValue, uint targetValue, bool received)
        {
            Check<UIntVariable, UIntVariableWithOnChangeEvent, uint, UIntGameEvent, IGameEventListener<uint>>(baseValue, targetValue, received);
        }
        #endregion

        #region Vector2
        [Test]
        public void vector2_variable_with_on_change_event_set_from_zero_to_zero()
        {
            CheckVector2(Vector2.zero, Vector2.zero, false);
        }

        [Test]
        public void vector2_variable_with_on_change_event_set_from_zero_to_one()
        {
            CheckVector2(Vector2.zero, Vector2.one, true);
        }

        [Test]
        public void vector2_variable_with_on_change_event_set_from_zero_to_custom()
        {
            CheckVector2(Vector2.zero, new Vector2(-12, 432), true);
        }

        [Test]
        public void vector2_variable_with_on_change_event_set_from_one_to_zero()
        {
            CheckVector2(Vector2.one, Vector2.zero, true);
        }

        [Test]
        public void vector2_variable_with_on_change_event_set_from_one_to_one()
        {
            CheckVector2(Vector2.one, Vector2.one, false);
        }

        [Test]
        public void vector2_variable_with_on_change_event_set_from_one_to_custom()
        {
            CheckVector2(Vector2.one, new Vector2(-12, 432), true);
        }

        [Test]
        public void vector2_variable_with_on_change_event_set_from_custom_to_zero()
        {
            CheckVector2(new Vector2(-12, 432), Vector2.zero, true);
        }

        [Test]
        public void vector2_variable_with_on_change_event_set_from_custom_to_one()
        {
            CheckVector2(new Vector2(-12, 432), Vector2.one, true);
        }

        [Test]
        public void vector2_variable_with_on_change_event_set_from_custom_to_custom()
        {
            CheckVector2(new Vector2(-12, 432), new Vector2(-12, 432), false);
        }

        private void CheckVector2(Vector2 baseValue, Vector2 targetValue, bool received)
        {
            Check<Vector2Variable, Vector2VariableWithOnChangeEvent, Vector2, Vector2GameEvent, IGameEventListener<Vector2>>(baseValue, targetValue, received);
        }
        #endregion

        #region Vector3
        [Test]
        public void vector3_variable_with_on_change_event_set_from_zero_to_zero()
        {
            CheckVector3(Vector3.zero, Vector3.zero, false);
        }

        [Test]
        public void vector3_variable_with_on_change_event_set_from_zero_to_one()
        {
            CheckVector3(Vector3.zero, Vector3.one, true);
        }

        [Test]
        public void vector3_variable_with_on_change_event_set_from_zero_to_custom()
        {
            CheckVector3(Vector3.zero, new Vector3(-12, 432, 0.4f), true);
        }

        [Test]
        public void vector3_variable_with_on_change_event_set_from_one_to_zero()
        {
            CheckVector3(Vector3.one, Vector3.zero, true);
        }

        [Test]
        public void vector3_variable_with_on_change_event_set_from_one_to_one()
        {
            CheckVector3(Vector3.one, Vector3.one, false);
        }

        [Test]
        public void vector3_variable_with_on_change_event_set_from_one_to_custom()
        {
            CheckVector3(Vector3.one, new Vector3(-12, 432, 0.4f), true);
        }

        [Test]
        public void vector3_variable_with_on_change_event_set_from_custom_to_zero()
        {
            CheckVector3(new Vector3(-12, 432, 0.4f), Vector3.zero, true);
        }

        [Test]
        public void vector3_variable_with_on_change_event_set_from_custom_to_one()
        {
            CheckVector3(new Vector3(-12, 432, 0.4f), Vector3.one, true);
        }

        [Test]
        public void vector3_variable_with_on_change_event_set_from_custom_to_custom()
        {
            CheckVector3(new Vector3(-12, 432, 0.4f), new Vector3(-12, 432, 0.4f), false);
        }

        private void CheckVector3(Vector3 baseValue, Vector3 targetValue, bool received)
        {
            Check<Vector3Variable, Vector3VariableWithOnChangeEvent, Vector3, Vector3GameEvent, IGameEventListener<Vector3>>(baseValue, targetValue, received);
        }
        #endregion

        #region Quaternion
        [Test]
        public void quaternion_variable_with_on_change_event_set_from_identity_to_identity()
        {
            CheckQuaternion(Quaternion.identity, Quaternion.identity, false);
        }

        [Test]
        public void quaternion_variable_with_on_change_event_set_from_identity_to_int_custom()
        {
            CheckQuaternion(Quaternion.identity, Quaternion.Euler(90, -90, 123), true);
        }

        [Test]
        public void quaternion_variable_with_on_change_event_set_from_identity_to_float_custom()
        {
            CheckQuaternion(Quaternion.identity, Quaternion.Euler(-235.6f, 190.2f, 63.2f), true);
        }

        [Test]
        public void quaternion_variable_with_on_change_event_set_from_int_custom_to_identity()
        {
            CheckQuaternion(Quaternion.Euler(90, -90, 123), Quaternion.identity, true);
        }

        [Test]
        public void quaternion_variable_with_on_change_event_set_from_int_custom_to_int_custom()
        {
            CheckQuaternion(Quaternion.Euler(90, -90, 123), Quaternion.Euler(90, -90, 123), false);
        }

        [Test]
        public void quaternion_variable_with_on_change_event_set_from_int_custom_to_float_custom()
        {
            CheckQuaternion(Quaternion.Euler(90, -90, 123), Quaternion.Euler(-235.6f, 190.2f, 63.2f), true);
        }

        [Test]
        public void quaternion_variable_with_on_change_event_set_from_float_custom_to_identity()
        {
            CheckQuaternion(Quaternion.Euler(-235.6f, 190.2f, 63.2f), Quaternion.identity, true);
        }

        [Test]
        public void quaternion_variable_with_on_change_event_set_from_float_custom_to_int_custom()
        {
            CheckQuaternion(Quaternion.Euler(-235.6f, 190.2f, 63.2f), Quaternion.Euler(90, -90, 123), true);
        }

        [Test]
        public void quaternion_variable_with_on_change_event_set_from_float_custom_to_float_custom()
        {
            CheckQuaternion(Quaternion.Euler(-235.6f, 190.2f, 63.2f), Quaternion.Euler(-235.6f, 190.2f, 63.2f), false);
        }

        private void CheckQuaternion(Quaternion baseValue, Quaternion targetValue, bool received)
        {
            Check<QuaternionVariable, QuaternionVariableWithOnChangeEvent, Quaternion, QuaternionGameEvent, IGameEventListener<Quaternion>>(baseValue, targetValue, received);
        }
        #endregion

        #region bases
        private void Check<T, TWE, TBase, E, LE>(TBase baseValue, TBase targetValue, bool received)
            where T : TVariable<TBase>
            where TWE : TVariableWithOnChangeEvent<TBase>
            where E : TGameEvent<TBase>
            where LE : IGameEventListener<TBase>
        {
            var gameEventListener = Substitute.For<IGameEventListener<TBase>>();
            CreateVariable<T, TWE, TBase, E, LE>(out var vwoce, out var variable, out var gameEvent);
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

        private void CreateVariable<T, TWE, TBase, E, LE>(out TWE variableWithOnChangeEvent, out T variable, out E gameEvent)
            where T : TVariable<TBase>
            where TWE : TVariableWithOnChangeEvent<TBase>
            where E : TGameEvent<TBase>
            where LE : IGameEventListener<TBase>
        {
            variableWithOnChangeEvent = ScriptableObject.CreateInstance<TWE>();
            variable = ScriptableObject.CreateInstance<T>();
            gameEvent = ScriptableObject.CreateInstance<E>();

            variableWithOnChangeEvent.SetVariable(variable);
            variableWithOnChangeEvent.SetOnChangeEvent(gameEvent);
        }

        private void CreateVariableWithRegisterListener<T, TWE, TBase, E, LE>(out TWE variableWithOnChangeEvent, out T variable, out E gameEvent, ref LE gameEventListener)
            where T : TVariable<TBase>
            where TWE : TVariableWithOnChangeEvent<TBase>
            where E : TGameEvent<TBase>
            where LE : IGameEventListener<TBase>
        {
            CreateVariable<T, TWE, TBase, E, LE>(out variableWithOnChangeEvent, out variable, out gameEvent);
            gameEvent.RegisterListener(gameEventListener);
        }
		#endregion
	}
}
