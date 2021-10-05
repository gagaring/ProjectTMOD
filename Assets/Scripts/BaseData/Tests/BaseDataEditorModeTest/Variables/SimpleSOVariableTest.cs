using NUnit.Framework;
using UnityEngine;
using VEngine;
using VEngine.SO.Variables;

namespace VTest
{
    public class SimpleSOVariableTest
    {
        [Test]
        public void bool_variable_value_set_to_true()
        {
            var variable = ScriptableObject.CreateInstance<BoolVariable>();
            variable.Value = true;
            Assert.IsTrue(variable.Value);
        }

        [Test]
        public void bool_variable_value_set_to_false()
        {
            var variable = ScriptableObject.CreateInstance<BoolVariable>();
            variable.Value = false;
            Assert.IsFalse(variable.Value);
        }

        [Test]
        public void float_variable_value_set_to_1()
        {
            var variable = ScriptableObject.CreateInstance<FloatVariable>();
            variable.Value = 1.0f;
            Assert.AreEqual(variable.Value, 1.0f);
        }

        [Test]
        public void float_variable_value_set_to_minus_half()
        {
            var variable = ScriptableObject.CreateInstance<FloatVariable>();
            variable.Value = -0.5f;
            Assert.AreEqual(variable.Value, -0.5f);
        }

        [Test]
        public void int_variable_value_set_to_1()
        {
            var variable = ScriptableObject.CreateInstance<IntVariable>();
            variable.Value = 1;
            Assert.AreEqual(variable.Value, 1);
        }

        [Test]
        public void int_variable_value_set_to_minus_1()
        {
            var variable = ScriptableObject.CreateInstance<IntVariable>();
            variable.Value = -1;
            Assert.AreEqual(variable.Value, -1);
        }

        [Test]
        public void int_variable_value_set_to_10000()
        {
            var variable = ScriptableObject.CreateInstance<IntVariable>();
            variable.Value = 10000;
            Assert.AreEqual(variable.Value, 10000);
        }

        [Test]
        public void int_variable_value_set_to_minus_10000()
        {
            var variable = ScriptableObject.CreateInstance<IntVariable>();
            variable.Value = -10000;
            Assert.AreEqual(variable.Value, -10000);
        }

        [Test]
        public void uint_variable_value_set_to_1()
        {
            var variable = ScriptableObject.CreateInstance<UIntVariable>();
            variable.Value = 1;
            Assert.AreEqual(variable.Value, 1);
        }

        [Test]
        public void uint_variable_value_set_to_10000()
        {
            var variable = ScriptableObject.CreateInstance<UIntVariable>();
            variable.Value = 10000;
            Assert.AreEqual(variable.Value, 10000);
        }

        [Test]
        public void string_variable_value_set_to_empty()
        {
            var variable = ScriptableObject.CreateInstance<StringVariable>();
            variable.Value = "";
            Assert.IsEmpty(variable.Value);
        }

        [Test]
        public void string_variable_value_set_to_not_empty()
        {
            var variable = ScriptableObject.CreateInstance<StringVariable>();
            variable.Value = "Not empty";
            Assert.IsNotEmpty(variable.Value);
        }

        [Test]
        public void string_variable_value_set_to_hello_world()
        {
            var variable = ScriptableObject.CreateInstance<StringVariable>();
            variable.Value = "Hello World";
            Assert.AreEqual(variable.Value, "Hello World");
        }

        [Test]
        public void vector2_variable_value_set_to_zero()
        {
            var variable = ScriptableObject.CreateInstance<Vector2Variable>();
            variable.Value = Vector2.zero;
            Assert.AreEqual(variable.Value, Vector2.zero);
        }

        [Test]
        public void vector2_variable_value_set_to_one()
        {
            var variable = ScriptableObject.CreateInstance<Vector2Variable>();
            variable.Value = Vector2.one;
            Assert.AreEqual(variable.Value, Vector2.one);
        }

        [Test]
        public void vector3_variable_value_set_to_zero()
        {
            var variable = ScriptableObject.CreateInstance<Vector3Variable>();
            variable.Value = Vector3.zero;
            Assert.AreEqual(variable.Value, Vector3.zero);
        }

        [Test]
        public void vector3_variable_value_set_to_one()
        {
            var variable = ScriptableObject.CreateInstance<Vector3Variable>();
            variable.Value = Vector3.one;
            Assert.AreEqual(variable.Value, Vector3.one);
        }

        [Test]
        public void quaternion_variable_value_set_to_identity()
        {
            var variable = ScriptableObject.CreateInstance<QuaternionVariable>();
            variable.Value = Quaternion.identity;
            Assert.AreEqual(variable.Value, Quaternion.identity);
        }

        [Test]
        public void quaternion_variable_value_set_to_zero()
        {
            var variable = ScriptableObject.CreateInstance<QuaternionVariable>();
            variable.Value = Quaternion.Euler(0, 0, 0);
            Assert.AreEqual(variable.Value, Quaternion.Euler(0, 0, 0));
        }

        [Test]
        public void quaternion_variable_value_set_to_custom()
        {
            var variable = ScriptableObject.CreateInstance<QuaternionVariable>();
            variable.Value = Quaternion.Euler(1, 2, 3);
            Assert.AreEqual(variable.Value, Quaternion.Euler(1, 2, 3));
        }

        [Test]
        public void layerMask_variable_value_set_to_0()
        {
            var variable = ScriptableObject.CreateInstance<LayerMaskVariable>();
            variable.Value = (LayerMask)0;
            Assert.AreEqual(variable.Value, (LayerMask)0);
        }

        [Test]
        public void layerMask_variable_value_set_to_1()
        {
            var variable = ScriptableObject.CreateInstance<LayerMaskVariable>();
            variable.Value = (LayerMask)1;
            Assert.AreEqual(variable.Value, (LayerMask)1);
        }

        [Test]
        public void layerMask_variable_value_set_to_1023()
        {
            var variable = ScriptableObject.CreateInstance<LayerMaskVariable>();
            variable.Value = (LayerMask)1023;
            Assert.AreEqual(variable.Value, (LayerMask)1023);
        }

        [Test]
        public void singleLayer_variable_value_set_to_0()
        {
            //Default: 0
            var variable = ScriptableObject.CreateInstance<SingleUnityLayerVariable>();
            variable.Value = new SingleUnityLayer();
            variable.Value.Set(0);
            Assert.AreEqual(variable.Value.LayerIndex, LayerMask.NameToLayer("Default"));
            Assert.AreEqual(variable.Value.Mask, LayerMask.GetMask("Default"));
        }

        [Test]
        public void singleLayer_variable_value_set_to_1()
        {
            //TransparentFX: 1
            var variable = ScriptableObject.CreateInstance<SingleUnityLayerVariable>();
            variable.Value = new SingleUnityLayer();
            variable.Value.Set(1);
            Assert.AreEqual(variable.Value.LayerIndex, LayerMask.NameToLayer("TransparentFX"));
            Assert.AreEqual(variable.Value.Mask, LayerMask.GetMask("TransparentFX"));
        }

        [Test]
        public void singleLayer_variable_value_set_to_2()
        {
            //Ignore Raycast: 2
            var variable = ScriptableObject.CreateInstance<SingleUnityLayerVariable>();
            variable.Value = new SingleUnityLayer();
            variable.Value.Set(2);
            Assert.AreEqual(variable.Value.LayerIndex, LayerMask.NameToLayer("Ignore Raycast"));
            Assert.AreEqual(variable.Value.Mask, LayerMask.GetMask("Ignore Raycast"));
        }

        [Test]
        public void singleLayer_variable_value_set_to_4()
        {
            //Water: 4
            var variable = ScriptableObject.CreateInstance<SingleUnityLayerVariable>();
            variable.Value = new SingleUnityLayer();
            variable.Value.Set(4);
            Assert.AreEqual(variable.Value.LayerIndex, LayerMask.NameToLayer("Water"));
            Assert.AreEqual(variable.Value.Mask, LayerMask.GetMask("Water"));
        }

        [Test]
        public void singleLayer_variable_value_set_to_5()
        {
            //UI: 5
            var variable = ScriptableObject.CreateInstance<SingleUnityLayerVariable>();
            variable.Value = new SingleUnityLayer();
            variable.Value.Set(5);
            Assert.AreEqual(variable.Value.LayerIndex, LayerMask.NameToLayer("UI"));
            Assert.AreEqual(variable.Value.Mask, LayerMask.GetMask("UI"));
        }
    }
}
