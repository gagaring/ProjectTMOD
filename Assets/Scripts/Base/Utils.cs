using System;
using System.IO;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.AI;
using VEngine.Log;

namespace VEngine
{
	public static class Utils
	{
		public static uint GetBitOfPosInt(uint number, uint bit)
		{
			return (number >> (int)bit) & 1;
		}

		public static int GetLowestOneBitPos(uint number)
		{
			int counter = 0;
			while (number != 0)
			{
				if (GetBitOfPosInt(number, 0) == 1)
					return counter;
				++counter;
				number = number >> 1;
			}
			return -1;
		}

		public static bool IsActiveLayerInLayerMask(LayerMask layerMask, uint layer)
		{
			return GetBitOfPosInt(Convert.ToUInt32(layerMask.value), layer) == 1;
		}

		public static float DistanceSqr(Vector3 first, Vector3 second)
		{
			var displacement = second - first;
			return displacement.x * displacement.x + displacement.y * displacement.y + displacement.z * displacement.z;
		}

		public static T Clone<T>(T source)
		{
			DataContractSerializer serializer = new DataContractSerializer(typeof(T));
			using (MemoryStream ms = new MemoryStream())
			{
				serializer.WriteObject(ms, source);
				ms.Seek(0, SeekOrigin.Begin);
				return (T)serializer.ReadObject(ms);
			}
		}

		public static bool IsEquals(float a, float b, float tolerance = 0.00001f)
		{
			return Mathf.Abs(a - b) < tolerance;
		}

		public static string ProcessStringEOL(string text)
		{
			var textArray = text.Split(new string[] { "\\n" }, System.StringSplitOptions.None);
			text = "";
			for (int i = 0; i < textArray.Length - 1; ++i)
			{
				text += textArray[i] + '\n';
			}
			text += textArray[textArray.Length - 1];
			return text;
		}

		public static bool Max<T>(ref T value, T max) where T : IComparable
		{
			if (value.CompareTo(max) == 1)
			{
				value = max;
				return true;
			}
			return false;
		}

		public static bool Min<T>(ref T value, T min) where T : IComparable
		{
			if (value.CompareTo(min) == -1)
			{
				value = min;
				return true;
			}
			return false;
		}

		public static void MinMax<T>(ref T value, T min, T max) where T : IComparable
		{
			Min(ref value, min);
			Max(ref value, max);
		}

		public static Vector3 GetRandomPointOnNavMesh(Vector3 center, Vector2 distance)
		{
			var randomCirclePoint = UnityEngine.Random.insideUnitCircle.normalized;
			var randomCirclePointInSpace = new Vector3(randomCirclePoint.x, 0.0f, randomCirclePoint.y);
			Vector3 randomPos = randomCirclePointInSpace * UnityEngine.Random.Range(distance.x, distance.y) + center;
			NavMeshHit hit; // NavMesh Sampling Info Container
			NavMesh.SamplePosition(randomPos, out hit, distance.y, NavMesh.AllAreas);

			return hit.position;
		}
	}
}
