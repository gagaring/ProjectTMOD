using NUnit.Framework;
using UnityEngine;
using VEngine.SO.Variables;

namespace VTest
{
    public class SimpleReferenceTest
    {
		#region quaternion
		[Test]
        public void check_quaternion_reference_value_same_as_variable()
        {
            CreateQuaternionReference(out var reference, out var variable);
            Assert.AreEqual(reference.Value, variable.Value);
        }

        [Test]
        public void check_quaternion_reference_value_same_as_variable_after_variable_value_change_to_identity()
        {
            CreateQuaternionReference(out var reference, out var variable);
            variable.Value = Quaternion.identity;
            Assert.AreEqual(reference.Value, variable.Value);
        }

        [Test]
        public void check_quaternion_reference_value_same_as_variable_after_variable_value_change_to_custom()
        {
            CreateQuaternionReference(out var reference, out var variable);
            variable.Value = Quaternion.Euler(90, 123, -231);
            Assert.AreEqual(reference.Value, variable.Value);
        }

        [Test]
        public void check_quaternion_reference_value_same_as_variable_after_variable_value_change_to_custom2()
        {
            CreateQuaternionReference(out var reference, out var variable);
            variable.Value = Quaternion.Euler(-20, -123, 1231);
            Assert.AreEqual(reference.Value, variable.Value);
        }

        [Test]
        public void check_quaternion_reference_value_not_same_as_variable_value_after_variable_is_changed_to_variable2()
        {
            CreateQuaternionReference(out var reference, out var variable);
            var variable2 = ScriptableObject.CreateInstance<QuaternionVariable>();
            reference.Init(variable2);
            variable2.Value = Quaternion.Euler(1, 2, 3);
            Assert.AreNotEqual(reference.Value, variable.Value);
        }

        [Test]
        public void check_quaternion_reference_value_same_as_variable2_value_after_variable_is_changed_to_variable2()
        {
            CreateQuaternionReference(out var reference, out var variable);
            var variable2 = ScriptableObject.CreateInstance<QuaternionVariable>();
            reference.Init(variable2);
            variable2.Value = Quaternion.Euler(1, 2, 3);
            Assert.AreEqual(reference.Value, variable2.Value);
        }
		#endregion

		public void CreateQuaternionReference(out QuaternionReference reference, out QuaternionVariable variable)
        {
            reference = new QuaternionReference();
            variable = ScriptableObject.CreateInstance<QuaternionVariable>();
            variable.Value = Quaternion.Euler(0, 0, 0);
            reference.Init(variable);
        }

        #region GameObject
        [Test]
        public void check_GameObject_reference_value_same_as_variable()
        {
            CreateGameObjectReference(out var reference, out var variable);
            Assert.AreEqual(reference.Value, variable.Value);
        }

        [Test]
        public void check_GameObject_reference_value_same_as_variable_after_variable_value_is_set()
        {
            CreateGameObjectReference(out var reference, out var variable);
            variable.Value = new GameObject();
            Assert.AreEqual(reference.Value, variable.Value);
            GameObject.DestroyImmediate(variable.Value);
        }

        [Test]
        public void check_GameObject_reference_value_not_same_as_variable_value_after_variable_is_changed_to_variable2()
        {
            CreateGameObjectReference(out var reference, out var variable);
            var variable2 = ScriptableObject.CreateInstance<GameObjectVariable>();
            reference.Init(variable2);
            variable2.Value = new GameObject();
            Assert.AreNotEqual(reference.Value, variable.Value);
            GameObject.DestroyImmediate(variable2.Value);
        }

        [Test]
        public void check_GameObject_reference_value_same_as_variable2_value_after_variable_is_changed_to_variable2()
        {
            CreateGameObjectReference(out var reference, out var variable);
            var variable2 = ScriptableObject.CreateInstance<GameObjectVariable>();
            reference.Init(variable2);
            variable2.Value = new GameObject();
            Assert.AreNotEqual(reference.Value, variable.Value);
            Assert.AreEqual(reference.Value, variable2.Value);
        }
        #endregion

        public void CreateGameObjectReference(out GameObjectReference reference, out GameObjectVariable variable)
        {
            reference = new GameObjectReference();
            variable = ScriptableObject.CreateInstance<GameObjectVariable>();
            variable.Value = null;
            reference.Init(variable);
        }

    }
}
