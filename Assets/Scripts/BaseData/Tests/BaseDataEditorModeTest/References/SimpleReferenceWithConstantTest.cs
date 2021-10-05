using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using VEngine.SO.Variables;

namespace VTest
{
    public class SimpleReferenceWithConstantTest
    {
        #region bool
        [Test]
        public void bool_reference_value_equals_with_true_constant_if_use_true_constant()
        {
			var reference = new BoolReference();
			CheckBaseReferenceWithConstant_Constant<BoolReference, bool, BoolVariable>(reference, true);
        }

        [Test]
        public void bool_reference_value_equals_with_false_constant_if_use_true_constant()
        {
            var reference = new BoolReference();
            CheckBaseReferenceWithConstant_Constant<BoolReference, bool, BoolVariable>(reference, true);
        }

        [Test]
        public void bool_reference_value_equals_with_false_variable_value_if_use_false_constant()
        {
            var reference = new BoolReference();
            CheckBaseReferenceWithConstant_Variable<BoolReference, bool, BoolVariable>(reference, false);
        }

        [Test]
        public void bool_reference_value_equals_with_true_variable_value_if_use_false_constant()
        {
            var reference = new BoolReference();
            CheckBaseReferenceWithConstant_Variable<BoolReference, bool, BoolVariable>(reference, true);
        }
        #endregion

        #region float
        [Test]
        public void float_reference_value_equals_with_0_constant_if_use_true_constant()
        {
            var reference = new FloatReference();
            CheckBaseReferenceWithConstant_Constant<FloatReference, float, FloatVariable>(reference, 0f);
        }

        [Test]
        public void float_reference_value_equals_with_half_constant_if_use_true_constant()
        {
            var reference = new FloatReference();
            CheckBaseReferenceWithConstant_Constant<FloatReference, float, FloatVariable>(reference, 0.5f);
        }

        [Test]
        public void float_reference_value_equals_with_minus_half_constant_if_use_true_constant()
        {
            var reference = new FloatReference();
            CheckBaseReferenceWithConstant_Constant<FloatReference, float, FloatVariable>(reference, -0.5f);
        }

        [Test]
        public void float_reference_value_equals_with_0_variable_value_if_use_false_constant()
        {
            var reference = new FloatReference();
            CheckBaseReferenceWithConstant_Variable<FloatReference, float, FloatVariable>(reference, 0);
        }

        [Test]
        public void float_reference_value_equals_with_half_variable_value_if_use_false_constant()
        {
            var reference = new FloatReference();
            CheckBaseReferenceWithConstant_Variable<FloatReference, float, FloatVariable>(reference, 0.5f);
        }

        [Test]
        public void float_reference_value_equals_with_minus_half_variable_value_if_use_false_constant()
        {
            var reference = new FloatReference();
            CheckBaseReferenceWithConstant_Variable<FloatReference, float, FloatVariable>(reference, -0.5f);
        }
        #endregion

        #region int
        [Test]
        public void int_reference_value_equals_with_0_constant_if_use_true_constant()
        {
            var reference = new IntReference();
            CheckBaseReferenceWithConstant_Constant<IntReference, int, IntVariable>(reference, 0);
        }

        [Test]
        public void int_reference_value_equals_with_1_constant_if_use_true_constant()
        {
            var reference = new IntReference();
            CheckBaseReferenceWithConstant_Constant<IntReference, int, IntVariable>(reference, 1);
        }

        [Test]
        public void int_reference_value_equals_with_minus_1_constant_if_use_true_constant()
        {
            var reference = new IntReference();
            CheckBaseReferenceWithConstant_Constant<IntReference, int, IntVariable>(reference, -1);
        }

        [Test]
        public void int_reference_value_equals_with_0_variable_value_if_use_false_constant()
        {
            var reference = new IntReference();
            CheckBaseReferenceWithConstant_Variable<IntReference, int, IntVariable>(reference, 0);
        }

        [Test]
        public void int_reference_value_equals_with_1_variable_value_if_use_false_constant()
        {
            var reference = new IntReference();
            CheckBaseReferenceWithConstant_Variable<IntReference, int, IntVariable>(reference, 1);
        }

        [Test]
        public void int_reference_value_equals_with_minus_1_variable_value_if_use_false_constant()
        {
            var reference = new IntReference();
            CheckBaseReferenceWithConstant_Variable<IntReference, int, IntVariable>(reference, -1);
        }
        #endregion

        #region string
        [Test]
        public void int_reference_value_equals_with_empty_constant_if_use_true_constant()
        {
            var reference = new StringReference();
            CheckBaseReferenceWithConstant_Constant<StringReference, string, StringVariable>(reference, "");
        }

        [Test]
        public void int_reference_value_equals_with_hello_world_constant_if_use_true_constant()
        {
            var reference = new StringReference();
            CheckBaseReferenceWithConstant_Constant<StringReference, string, StringVariable>(reference, "Hello World");
        }

        [Test]
        public void int_reference_value_equals_with_empty_variable_value_if_use_false_constant()
        {
            var reference = new StringReference();
            CheckBaseReferenceWithConstant_Variable<StringReference, string, StringVariable>(reference, "");
        }

        [Test]
        public void int_reference_value_equals_with_hello_world_variable_value_if_use_false_constant()
        {
            var reference = new StringReference();
            CheckBaseReferenceWithConstant_Variable<StringReference, string, StringVariable>(reference, "Hello World");
        }
        #endregion

        #region Vector2
        [Test]
        public void vector2_reference_value_equals_with_zero_constant_if_use_true_constant()
        {
            var reference = new Vector2Reference();
            CheckBaseReferenceWithConstant_Constant<Vector2Reference, Vector2, Vector2Variable>(reference, Vector2.zero);
        }

        [Test]
        public void vector2_reference_value_equals_with_one_constant_if_use_true_constant()
        {
            var reference = new Vector2Reference();
            CheckBaseReferenceWithConstant_Constant<Vector2Reference, Vector2, Vector2Variable>(reference, Vector2.one);
        }

        [Test]
        public void vector2_reference_value_equals_with_custom_constant_if_use_true_constant()
        {
            var reference = new Vector2Reference();
            CheckBaseReferenceWithConstant_Constant<Vector2Reference, Vector2, Vector2Variable>(reference, new Vector2(123.45f, -123.45f));
        }

        [Test]
        public void vector2_reference_value_equals_with_zero_variable_value_if_use_false_constant()
        {
            var reference = new Vector2Reference();
            CheckBaseReferenceWithConstant_Variable<Vector2Reference, Vector2, Vector2Variable>(reference, Vector2.zero);
        }

        [Test]
        public void vector2_reference_value_equals_with_one_variable_value_if_use_false_constant()
        {
            var reference = new Vector2Reference();
            CheckBaseReferenceWithConstant_Variable<Vector2Reference, Vector2, Vector2Variable>(reference, Vector2.one);
        }

        [Test]
        public void vector2_reference_value_equals_with_custom_variable_value_if_use_false_constant()
        {
            var reference = new Vector2Reference();
            CheckBaseReferenceWithConstant_Variable<Vector2Reference, Vector2, Vector2Variable>(reference, new Vector2(123.45f, -123.45f));
        }
        #endregion

        #region Vector3
        [Test]
        public void vector3_reference_value_equals_with_zero_constant_if_use_true_constant()
        {
            var reference = new Vector3Reference();
            CheckBaseReferenceWithConstant_Constant<Vector3Reference, Vector3, Vector3Variable>(reference, Vector3.zero);
        }

        [Test]
        public void vector3_reference_value_equals_with_one_constant_if_use_true_constant()
        {
            var reference = new Vector3Reference();
            CheckBaseReferenceWithConstant_Constant<Vector3Reference, Vector3, Vector3Variable>(reference, Vector3.one);
        }

        [Test]
        public void vector3_reference_value_equals_with_custom_constant_if_use_true_constant()
        {
            var reference = new Vector3Reference();
            CheckBaseReferenceWithConstant_Constant<Vector3Reference, Vector3, Vector3Variable>(reference, new Vector3(123.45f, -123.45f, 564.32f));
        }

        [Test]
        public void vector3_reference_value_equals_with_zero_variable_value_if_use_false_constant()
        {
            var reference = new Vector3Reference();
            CheckBaseReferenceWithConstant_Variable<Vector3Reference, Vector3, Vector3Variable>(reference, Vector3.zero);
        }

        [Test]
        public void vector3_reference_value_equals_with_one_variable_value_if_use_false_constant()
        {
            var reference = new Vector3Reference();
            CheckBaseReferenceWithConstant_Variable<Vector3Reference, Vector3, Vector3Variable>(reference, Vector3.one);
        }

        [Test]
        public void vector3_reference_value_equals_with_custom_variable_value_if_use_false_constant()
        {
            var reference = new Vector3Reference();
            CheckBaseReferenceWithConstant_Variable<Vector3Reference, Vector3, Vector3Variable>(reference, new Vector3(123.45f, -123.45f, 564.32f));
        }
        #endregion

        #region layermask
        [Test]
        public void layermask_reference_value_equals_with_empty_constant_if_use_true_constant()
        {
            var reference = new LayerMaskReference();
            var layerMask = (LayerMask)0;
            CheckBaseReferenceWithConstant_Constant<LayerMaskReference, LayerMask, LayerMaskVariable>(reference, layerMask);
        }

        [Test]
        public void layermask_reference_value_equals_with_1_constant_if_use_true_constant()
        {
            var reference = new LayerMaskReference();
            var layerMask = (LayerMask)1;
            CheckBaseReferenceWithConstant_Constant<LayerMaskReference, LayerMask, LayerMaskVariable>(reference, layerMask);
        }

        [Test]
        public void layermask_reference_value_equals_with_1023_constant_if_use_true_constant()
        {
            var reference = new LayerMaskReference();
            var layerMask = (LayerMask)1023;
            CheckBaseReferenceWithConstant_Constant<LayerMaskReference, LayerMask, LayerMaskVariable>(reference, layerMask);
        }

        [Test]
        public void layermask_reference_value_equals_with_0_variable_value_if_use_false_constant()
        {
            var reference = new LayerMaskReference();
            var layerMask = (LayerMask)0;
            CheckBaseReferenceWithConstant_Variable<LayerMaskReference, LayerMask, LayerMaskVariable>(reference, layerMask);
        }

        [Test]
        public void layermask_reference_value_equals_with_1_variable_value_if_use_false_constant()
        {
            var reference = new LayerMaskReference();
            var layerMask = (LayerMask)1;
            CheckBaseReferenceWithConstant_Variable<LayerMaskReference, LayerMask, LayerMaskVariable>(reference, layerMask);
        }

        [Test]
        public void layermask_reference_value_equals_with_1023_variable_value_if_use_false_constant()
        {
            var reference = new LayerMaskReference();
            var layerMask = (LayerMask)1023;
            CheckBaseReferenceWithConstant_Variable<LayerMaskReference, LayerMask, LayerMaskVariable>(reference, layerMask);
        }
        #endregion

        private void CheckBaseReferenceWithConstant_Constant<R, T, V>(R reference, T value) where R : TReferenceWithConstant<T, V> where V : TVariable<T>
        {
            reference.Init(value);
            Assert.AreEqual(reference.Value, value);
        }

        private void CheckBaseReferenceWithConstant_Variable<R, T, V>(R reference, T value) where R : TReferenceWithConstant<T, V> where V : TVariable<T>
        {
            var variable = ScriptableObject.CreateInstance<V>();
            variable.Value = value;
            reference.Init(variable);
            Assert.AreEqual(reference.Value, variable.Value);
        }
    }
}
