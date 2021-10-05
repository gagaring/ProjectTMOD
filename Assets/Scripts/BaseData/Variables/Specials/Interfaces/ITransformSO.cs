using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.SO.Variables
{
	public interface ITransformSO<T> : ITransformSOReference where T : IGameEvent
	{
		T OnPositionOverrided { get; }
		T OnRotationOverrided { get; }
		void AssignTransform(Transform trans);

		void Rotate(Vector3 up, float rotate);
		void LookAt(Vector3 to);
	}

	public interface ITransformSOReference
	{
		Vector3 Forward { get; }
		Vector3 Up { get; }

		Vector3 Position { get; set; }
		Quaternion Rotation { get; set; }
	}
}
