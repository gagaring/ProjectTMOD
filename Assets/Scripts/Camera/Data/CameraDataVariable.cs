using System;
using UnityEngine;

namespace VEngine.SO.Variables
{
	[CreateAssetMenu(menuName = "SO/Variables/CameraData")]
	public class CameraDataVariable : TransformSO
	{
	}

	[Serializable]
	public class CameraDataReference
	{
		[SerializeField] private CameraDataVariable _value;
		public Vector3 Forward { get => _value.Forward; }
		public Vector3 Position { get => _value.Position; }
		public Quaternion Rotation { get => _value.Rotation; }
	}
}