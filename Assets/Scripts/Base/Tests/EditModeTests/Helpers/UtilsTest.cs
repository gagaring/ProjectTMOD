using NUnit.Framework;
using System;
using UnityEngine;
using VEngine;

namespace VTest
{
	public class UtilsTest
	{
		#region GetBitOfPosInt
		[Test]
		public void test_GetBitOfPosInt_where_number_is_0_and_bit_0_equal_0()
		{
			uint number = 0;
			uint bitIndex = 0;
			uint expected = 0;
			Assert.AreEqual(expected, Utils.GetBitOfPosInt(number, bitIndex));
		}

		[Test]
		public void test_GetBitOfPosInt_where_number_is_1_and_bit_0_equal_1()
		{
			uint number = 1;
			uint bitIndex = 0;
			uint expected = 1;
			Assert.AreEqual(expected, Utils.GetBitOfPosInt(number, bitIndex));
		}

		[Test]
		public void test_GetBitOfPosInt_where_number_is_2_and_bit_0_equal_0()
		{
			uint number = 2;
			uint bitIndex = 0;
			uint expected = 0;
			Assert.AreEqual(expected, Utils.GetBitOfPosInt(number, bitIndex));
		}

		[Test]
		public void test_GetBitOfPosInt_where_number_is_15_and_bit_3_equal_1()
		{
			uint number = 15;
			uint bitIndex = 3;
			uint expected = 1;
			Assert.AreEqual(expected, Utils.GetBitOfPosInt(number, bitIndex));
		}

		[Test]
		public void test_GetBitOfPosInt_where_number_is_15_and_bit_4_equal_0()
		{
			uint number = 15;
			uint bitIndex = 4;
			uint expected = 0;
			Assert.AreEqual(expected, Utils.GetBitOfPosInt(number, bitIndex));
		}

		[Test]
		public void test_GetBitOfPosInt_where_number_is_105_and_bit_4_equal_0()
		{
			uint number = 105;
			uint bitIndex = 4;
			uint expected = 0;
			Assert.AreEqual(expected, Utils.GetBitOfPosInt(number, bitIndex));
		}

		[Test]
		public void test_GetBitOfPosInt_where_number_is_105_and_bit_5_equal_0()
		{
			uint number = 105;
			uint bitIndex = 5;
			uint expected = 1;
			Assert.AreEqual(expected, Utils.GetBitOfPosInt(number, bitIndex));
		}

		[Test]
		public void test_GetBitOfPosInt_where_number_is_105_and_bit_6_equal_1()
		{
			uint number = 105;
			uint bitIndex = 6;
			uint expected = 1;
			Assert.AreEqual(expected, Utils.GetBitOfPosInt(number, bitIndex));
		}

		[Test]
		public void test_GetBitOfPosInt_where_number_is_2147483648_and_bits_are_0_except_31()
		{
			uint number = 2147483648;
			for (uint i = 0; i < 30; ++i)
			{
				Assert.AreEqual(0, Utils.GetBitOfPosInt(number, i));
			}
			Assert.AreEqual(1, Utils.GetBitOfPosInt(number, 31));
		}

		[Test]
		public void test_GetBitOfPosInt_where_number_is_4294967295_and_all_bits_are_1()
		{
			uint number = 4294967295;
			for (uint i = 0; i < 31; ++i)
			{
				Assert.AreEqual(1, Utils.GetBitOfPosInt(number, i));
			}
		}
		#endregion

		#region GetLowestOneBitPos
		[Test]
		public void is_GetLowestOneBitPos_return_minus_1_where_number_is_0()
		{
			uint number = 0;
			int expected = -1;
			Assert.AreEqual(expected, Utils.GetLowestOneBitPos(number));
		}

		[Test]
		public void is_GetLowestOneBitPos_return_0_where_number_is_1()
		{
			uint number = 1;
			int expected = 0;
			Assert.AreEqual(expected, Utils.GetLowestOneBitPos(number));
		}

		[Test]
		public void is_GetLowestOneBitPos_return_1_where_number_is_15()
		{
			uint number = 15;
			int expected = 0;
			Assert.AreEqual(expected, Utils.GetLowestOneBitPos(number));
		}

		[Test]
		public void is_GetLowestOneBitPos_return_5_where_number_is_16()
		{
			uint number = 16;
			int expected = 4;
			Assert.AreEqual(expected, Utils.GetLowestOneBitPos(number));
		}

		[Test]
		public void is_GetLowestOneBitPos_return_2147483648_where_number_is_31()
		{
			uint number = 2147483648;
			int expected = 31;
			Assert.AreEqual(expected, Utils.GetLowestOneBitPos(number));
		}

		[Test]
		public void is_GetLowestOneBitPos_return_4294967295_where_number_is_0()
		{
			uint number = 4294967295;
			int expected = 0;
			Assert.AreEqual(expected, Utils.GetLowestOneBitPos(number));
		}

		[Test]
		public void is_GetLowestOneBitPos_return_x_where_number_is_2_on_x()
		{
			for (int i = 0; i < 31; ++i)
			{
				uint number = Convert.ToUInt32(Mathf.Pow(2, i));
				Assert.AreEqual(i, Utils.GetLowestOneBitPos(number));
			}
		}
		#endregion

		#region IsActiveLayerInLayerMask
		[Test]
		public void is_IsActiveLayerInLayerMask_return_true_where_layerMask_is_1_and_layer_is_0()
		{
			LayerMask layerMask = 1;
			uint layer = 0;
			Assert.IsTrue(Utils.IsActiveLayerInLayerMask(layerMask, layer));
		}

		[Test]
		public void is_IsActiveLayerInLayerMask_return_true_where_layerMask_is_123_and_layer_is_0()
		{
			LayerMask layerMask = 123;
			uint layer = 0;
			Assert.IsTrue(Utils.IsActiveLayerInLayerMask(layerMask, layer));
		}

		[Test]
		public void is_IsActiveLayerInLayerMask_return_true_where_layerMask_is_123_and_layer_is_1()
		{
			LayerMask layerMask = 123;
			uint layer = 1;
			Assert.IsTrue(Utils.IsActiveLayerInLayerMask(layerMask, layer));
		}

		[Test]
		public void is_IsActiveLayerInLayerMask_return_false_where_layerMask_is_123_and_layer_is_2()
		{
			LayerMask layerMask = 123;
			uint layer = 2;
			Assert.IsFalse(Utils.IsActiveLayerInLayerMask(layerMask, layer));
		}

		[Test]
		public void is_IsActiveLayerInLayerMask_return_true_where_layerMask_is_123_and_layer_is_3()
		{
			LayerMask layerMask = 123;
			uint layer = 3;
			Assert.IsTrue(Utils.IsActiveLayerInLayerMask(layerMask, layer));
		}

		[Test]
		public void is_IsActiveLayerInLayerMask_return_false_except_where_layer_is_x_where_layerMask_is_2_pow_x_and_layer_is_0_to_31()
		{
			for (int x = 0; x < 31; x++)
			{
				LayerMask layerMask = Convert.ToInt32(Mathf.Pow(2, x));
				for (uint layer = 0; layer < 31; ++layer)
				{
					Assert.AreEqual(x == layer, Utils.IsActiveLayerInLayerMask(layerMask, layer));
				}
			}
		}

		[Test]
		public void is_IsActiveLayerInLayerMask_return_false_where_layerMask_is_0_and_layer_is_0_to_31()
		{
			LayerMask layerMask = 0;
			for (uint layer = 0; layer < 31; ++layer)
				Assert.IsFalse(Utils.IsActiveLayerInLayerMask(layerMask, layer));
		}

		[Test]
		public void is_IsActiveLayerInLayerMask_return_true_where_layerMask_is_31_and_layer_is_0_to_4()
		{
			LayerMask layerMask = 31;
			for (uint layer = 0; layer < 4; ++layer)
				Assert.IsTrue(Utils.IsActiveLayerInLayerMask(layerMask, layer));
		}

		[Test]
		public void is_IsActiveLayerInLayerMask_return_false_where_layerMask_is_31_and_layer_is_5_to_31()
		{
			LayerMask layerMask = 31;
			for (uint layer = 5; layer < 31; ++layer)
				Assert.IsFalse(Utils.IsActiveLayerInLayerMask(layerMask, layer));
		}

		[Test]
		public void is_IsActiveLayerInLayerMask_return_true_where_layerMask_is_262143_and_layer_is_0_to_17()
		{
			LayerMask layerMask = 262143;
			for (uint layer = 0; layer < 17; ++layer)
				Assert.IsTrue(Utils.IsActiveLayerInLayerMask(layerMask, layer));
		}

		[Test]
		public void is_IsActiveLayerInLayerMask_return_false_where_layerMask_is_262143_and_layer_is_18_to_31()
		{
			LayerMask layerMask = 262143;
			for (uint layer = 185234523; layer < 31; ++layer)
				Assert.IsFalse(Utils.IsActiveLayerInLayerMask(layerMask, layer));
		}
		#endregion

		#region distanceSqr
		[Test]
		public void is_distance_sqr_good_where_first_is_zero_and_second_is_zero()
		{
			Vector3 first = Vector3.zero;
			Vector3 second = Vector3.zero;
			float expectedSqrt = Vector3.Distance(first, second);
			float expected = expectedSqrt * expectedSqrt;
			Assert.AreEqual(expected, Utils.DistanceSqr(first, second), expected * 0.0001f);
		}

		[Test]
		public void is_distance_sqr_good_where_first_is_zero_and_second_is_one()
		{
			Vector3 first = Vector3.zero;
			Vector3 second = Vector3.one;
			float expectedSqrt = Vector3.Distance(first, second);
			float expected = expectedSqrt * expectedSqrt;
			Assert.AreEqual(expected, Utils.DistanceSqr(first, second), expected * 0.0001f);
		}

		[Test]
		public void is_distance_sqr_good_where_first_is_custom_and_second_is_custom_1()
		{
			Vector3 first = new Vector3(123.4f, 15.0f, -1234.0f);
			Vector3 second = new Vector3(65.4f, -93.2f, 235.34f);
			float expectedSqrt = Vector3.Distance(first, second);
			float expected = expectedSqrt * expectedSqrt;
			Assert.AreEqual(expected, Utils.DistanceSqr(first, second), expected * 0.0001f);
		}

		[Test]
		public void is_distance_sqr_good_where_first_is_custom_and_second_is_custom_2()
		{
			Vector3 first = new Vector3(7456.4f, -231.0f, 0.1f);
			Vector3 second = new Vector3(1.2f, 45.4f, 34.0f);
			float expectedSqrt = Vector3.Distance(first, second);
			float expected = expectedSqrt * expectedSqrt;
			Assert.AreEqual(expected, Utils.DistanceSqr(first, second), expected * 0.0001f);
		}

		[Test]
		public void is_distance_sqr_good_where_first_is_custom_and_second_is_custom_3()
		{
			Vector3 first = new Vector3(0.01f, 0.02f, 0.03f);
			Vector3 second = new Vector3(-0.01f, -0.02f, -0.03f);
			float expectedSqrt = Vector3.Distance(first, second);
			float expected = expectedSqrt * expectedSqrt;
			Assert.AreEqual(expected, Utils.DistanceSqr(first, second), expected * 0.0001f);
		}
		#endregion
	}
}
