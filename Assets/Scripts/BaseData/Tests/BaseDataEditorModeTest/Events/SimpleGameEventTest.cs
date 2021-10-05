using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using VEngine.SO.Events;

namespace VTest
{
	public class SimpleGameEventTest
    {
		#region gameEvent
		[Test]
        public void game_event_list_count_1_after_register()
        {
            var gameEvent = ScriptableObject.CreateInstance<GameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener>();
            gameEvent.RegisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 1);
        }


        [Test]
        public void game_event_list_count_0_after_unregister()
        {
            var gameEvent = ScriptableObject.CreateInstance<GameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener>();
            gameEvent.RegisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 1);
            gameEvent.UnregisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 0);
        }

        [Test]
        public void event_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<GameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.Raise();
            gameEventListener.Received().OnEventRaised();
        }

        [Test]
        public void event_not_received_after_unregister_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<GameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.UnregisterListener(gameEventListener);
            gameEvent.Raise();
            gameEventListener.DidNotReceive().OnEventRaised();
        }
		#endregion

		#region bool
		[Test]
        public void bool_game_event_list_count_1_after_register()
        {
            var gameEvent = ScriptableObject.CreateInstance<BoolGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<bool>>();
            gameEvent.RegisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 1);
        }


        [Test]
        public void bool_game_event_list_count_0_after_unregister()
        {
            var gameEvent = ScriptableObject.CreateInstance<BoolGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<bool>>();
            gameEvent.RegisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 1);
            gameEvent.UnregisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 0);
        }

        [Test]
        public void event_with_true_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<BoolGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<bool>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.Raise(true);
            gameEventListener.Received().OnEventRaised(true);
        }

        [Test]
        public void event_with_false_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<BoolGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<bool>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.Raise(false);
            gameEventListener.Received().OnEventRaised(false);
        }

        [Test]
        public void event_with_true_not_received_after_unregister_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<BoolGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<bool>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.UnregisterListener(gameEventListener);
            gameEvent.Raise(true);
            gameEventListener.DidNotReceive().OnEventRaised(true);
        }

        [Test]
        public void event_with_false_not_received_after_unregister_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<BoolGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<bool>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.UnregisterListener(gameEventListener);
            gameEvent.Raise(false);
            gameEventListener.DidNotReceive().OnEventRaised(false);
        }
        #endregion

        #region float
        [Test]
        public void float_game_event_list_count_1_after_register()
        {
            var gameEvent = ScriptableObject.CreateInstance<FloatGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<float>>();
            gameEvent.RegisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 1);
        }


        [Test]
        public void float_game_event_list_count_0_after_unregister()
        {
            var gameEvent = ScriptableObject.CreateInstance<FloatGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<float>>();
            gameEvent.RegisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 1);
            gameEvent.UnregisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 0);
        }

        [Test]
        public void float_event_with_1_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<FloatGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<float>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.Raise(1.0f);
            gameEventListener.Received().OnEventRaised(1.0f);
        }


        [Test]
        public void float_event_with_minus_half_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<FloatGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<float>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.Raise(-.5f);
            gameEventListener.Received().OnEventRaised(-.5f);
        }

        [Test]
        public void float_event_with_1_not_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<FloatGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<float>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.UnregisterListener(gameEventListener);
            gameEvent.Raise(1.0f);
            gameEventListener.DidNotReceive().OnEventRaised(1.0f);
        }


        [Test]
        public void float_event_with_minus_half_not_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<FloatGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<float>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.UnregisterListener(gameEventListener);
            gameEvent.Raise(-.5f);
            gameEventListener.DidNotReceive().OnEventRaised(-.5f);
        }
        #endregion

        #region int
        [Test]
        public void int_game_event_list_count_1_after_register()
        {
            var gameEvent = ScriptableObject.CreateInstance<IntGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<int>>();
            gameEvent.RegisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 1);
        }

        [Test]
        public void int_game_event_list_count_0_after_unregister()
        {
            var gameEvent = ScriptableObject.CreateInstance<IntGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<int>>();
            gameEvent.RegisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 1);
            gameEvent.UnregisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 0);
        }

        [Test]
        public void int_event_with_1_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<IntGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<int>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.Raise(1);
            gameEventListener.Received().OnEventRaised(1);
        }


        [Test]
        public void int_event_with_minus_1_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<IntGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<int>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.Raise(-1);
            gameEventListener.Received().OnEventRaised(-1);
        }

        [Test]
        public void int_event_with_1_not_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<IntGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<int>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.UnregisterListener(gameEventListener);
            gameEvent.Raise(1);
            gameEventListener.DidNotReceive().OnEventRaised(1);
        }


        [Test]
        public void int_event_with_minus_1_not_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<IntGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<int>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.UnregisterListener(gameEventListener);
            gameEvent.Raise(-1);
            gameEventListener.DidNotReceive().OnEventRaised(-1);
        }
        #endregion

        #region uint
        [Test]
        public void uint_game_event_list_count_1_after_register()
        {
            var gameEvent = ScriptableObject.CreateInstance<UIntGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<uint>>();
            gameEvent.RegisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 1);
        }

        [Test]
        public void uint_game_event_list_count_0_after_unregister()
        {
            var gameEvent = ScriptableObject.CreateInstance<UIntGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<uint>>();
            gameEvent.RegisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 1);
            gameEvent.UnregisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 0);
        }

        [Test]
        public void uint_event_with_1_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<UIntGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<uint>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.Raise(1);
            gameEventListener.Received().OnEventRaised(1);
        }


        [Test]
        public void uint_event_with_1_not_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<UIntGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<uint>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.UnregisterListener(gameEventListener);
            gameEvent.Raise(1);
            gameEventListener.DidNotReceive().OnEventRaised(1);
        }
        #endregion

        #region vector2
        [Test]
        public void vector2_game_event_list_count_1_after_register()
        {
            var gameEvent = ScriptableObject.CreateInstance<Vector2GameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<Vector2>>();
            gameEvent.RegisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 1);
        }

        [Test]
        public void vector2_game_event_list_count_0_after_unregister()
        {
            var gameEvent = ScriptableObject.CreateInstance<Vector2GameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<Vector2>>();
            gameEvent.RegisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 1);
            gameEvent.UnregisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 0);
        }

        [Test]
        public void vector2_event_with_1_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<Vector2GameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<Vector2>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.Raise(Vector2.one);
            gameEventListener.Received().OnEventRaised(Vector2.one);
        }


        [Test]
        public void vector2_event_with_0_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<Vector2GameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<Vector2>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.Raise(Vector2.zero);
            gameEventListener.Received().OnEventRaised(Vector2.zero);
        }

        [Test]
        public void vector2_event_with_1_not_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<Vector2GameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<Vector2>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.UnregisterListener(gameEventListener);
            gameEvent.Raise(Vector2.one);
            gameEventListener.DidNotReceive().OnEventRaised(Vector2.one);
        }


        [Test]
        public void vector2_event_with_0_not_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<Vector2GameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<Vector2>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.UnregisterListener(gameEventListener);
            gameEvent.Raise(Vector2.zero);
            gameEventListener.DidNotReceive().OnEventRaised(Vector2.zero);
        }
        #endregion

        #region vector3
        [Test]
        public void vector3_game_event_list_count_1_after_register()
        {
            var gameEvent = ScriptableObject.CreateInstance<Vector3GameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<Vector3>>();
            gameEvent.RegisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 1);
        }

        [Test]
        public void vector3_game_event_list_count_0_after_unregister()
        {
            var gameEvent = ScriptableObject.CreateInstance<Vector3GameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<Vector3>>();
            gameEvent.RegisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 1);
            gameEvent.UnregisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 0);
        }

        [Test]
        public void vector3_event_with_1_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<Vector3GameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<Vector3>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.Raise(Vector3.one);
            gameEventListener.Received().OnEventRaised(Vector3.one);
        }


        [Test]
        public void vector3_event_with_0_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<Vector3GameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<Vector3>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.Raise(Vector3.zero);
            gameEventListener.Received().OnEventRaised(Vector3.zero);
        }

        [Test]
        public void vector3_event_with_1_not_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<Vector3GameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<Vector3>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.UnregisterListener(gameEventListener);
            gameEvent.Raise(Vector3.one);
            gameEventListener.DidNotReceive().OnEventRaised(Vector3.one);
        }


        [Test]
        public void vector3_event_with_0_not_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<Vector3GameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<Vector3>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.UnregisterListener(gameEventListener);
            gameEvent.Raise(Vector3.zero);
            gameEventListener.DidNotReceive().OnEventRaised(Vector3.zero);
        }
        #endregion

        #region quaternion
        [Test]
        public void quaternion_game_event_list_count_1_after_register()
        {
            var gameEvent = ScriptableObject.CreateInstance<QuaternionGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<Quaternion>>();
            gameEvent.RegisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 1);
        }

        [Test]
        public void quaternion_game_event_list_count_0_after_unregister()
        {
            var gameEvent = ScriptableObject.CreateInstance<QuaternionGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<Quaternion>>();
            gameEvent.RegisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 1);
            gameEvent.UnregisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 0);
        }

        [Test]
        public void quaternion_event_with_identity_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<QuaternionGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<Quaternion>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.Raise(Quaternion.identity);
            gameEventListener.Received().OnEventRaised(Quaternion.identity);
        }

        [Test]
        public void quaternion_event_with_0_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<QuaternionGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<Quaternion>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.Raise(Quaternion.Euler(0, 0, 0));
            gameEventListener.Received().OnEventRaised(Quaternion.Euler(0, 0, 0));
        }

        [Test]
        public void quaternion_event_with_custom_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<QuaternionGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<Quaternion>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.Raise(Quaternion.Euler(1, 2, 3));
            gameEventListener.Received().OnEventRaised(Quaternion.Euler(1, 2, 3));
        }

        [Test]
        public void quaternion_event_with_identity_not_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<QuaternionGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<Quaternion>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.UnregisterListener(gameEventListener);
            gameEvent.Raise(Quaternion.identity);
            gameEventListener.DidNotReceive().OnEventRaised(Quaternion.identity);
        }


        [Test]
        public void quaternion_event_with_0_not_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<QuaternionGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<Quaternion>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.UnregisterListener(gameEventListener);
            gameEvent.Raise(Quaternion.Euler(0, 0, 0));
            gameEventListener.DidNotReceive().OnEventRaised(Quaternion.Euler(0, 0, 0));
        }
        #endregion

        #region string
        [Test]
        public void string_game_event_list_count_1_after_register()
        {
            var gameEvent = ScriptableObject.CreateInstance<StringGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<string>>();
            gameEvent.RegisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 1);
        }

        [Test]
        public void string_game_event_list_count_0_after_unregister()
        {
            var gameEvent = ScriptableObject.CreateInstance<StringGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<string>>();
            gameEvent.RegisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 1);
            gameEvent.UnregisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 0);
        }

        [Test]
        public void string_event_with_empty_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<StringGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<string>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.Raise("");
            gameEventListener.Received().OnEventRaised("");
        }


        [Test]
        public void string_event_with_hello_world_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<StringGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<string>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.Raise("Hello World");
            gameEventListener.Received().OnEventRaised("Hello World");
        }

        [Test]
        public void string_event_with_empty_not_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<StringGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<string>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.UnregisterListener(gameEventListener);
            gameEvent.Raise("");
            gameEventListener.DidNotReceive().OnEventRaised("");
        }


        [Test]
        public void string_event_with_hello_world_not_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<StringGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<string>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.UnregisterListener(gameEventListener);
            gameEvent.Raise("Hello World");
            gameEventListener.DidNotReceive().OnEventRaised("Hello World");
        }
        #endregion

        #region GameObject
        [Test]
        public void GameObject_game_event_list_count_1_after_register()
        {
            var gameEvent = ScriptableObject.CreateInstance<GameObjectGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<GameObject>>();
            gameEvent.RegisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 1);
        }


        [Test]
        public void GameObject_game_event_list_count_0_after_unregister()
        {
            var gameEvent = ScriptableObject.CreateInstance<GameObjectGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<GameObject>>();
            gameEvent.RegisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 1);
            gameEvent.UnregisterListener(gameEventListener);
            Assert.AreEqual(gameEvent.RegisteredCount, 0);
        }

        [Test]
        public void event_with_gameObject_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<GameObjectGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<GameObject>>();
            var gameObject = new GameObject();
            gameEvent.RegisterListener(gameEventListener);
            gameEvent.Raise(gameObject);
            gameEventListener.Received().OnEventRaised(gameObject);
            GameObject.DestroyImmediate(gameObject);
        }

        [Test]
        public void event_with_null_received_after_register_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<GameObjectGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<GameObject>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.Raise(null);
            gameEventListener.Received().OnEventRaised(null);
        }

        [Test]
        public void event_with_gameObject_not_received_after_unregister_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<GameObjectGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<GameObject>>();
            var gameObject = new GameObject();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.UnregisterListener(gameEventListener);
            gameEvent.Raise(gameObject);
            gameEventListener.DidNotReceive().OnEventRaised(gameObject);
            GameObject.DestroyImmediate(gameObject);
        }

        [Test]
        public void event_with_null_not_received_after_unregister_on_game_event_raise()
        {
            var gameEvent = ScriptableObject.CreateInstance<GameObjectGameEvent>();
            var gameEventListener = Substitute.For<IGameEventListener<GameObject>>();

            gameEvent.RegisterListener(gameEventListener);
            gameEvent.UnregisterListener(gameEventListener);
            gameEvent.Raise(null);
            gameEventListener.DidNotReceive().OnEventRaised(null);
        }
        #endregion

    }
}
