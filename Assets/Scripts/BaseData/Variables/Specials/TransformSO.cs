using Sirenix.OdinInspector;
using UnityEngine;
using VEngine.Log;
using VEngine.SO.Events;

namespace VEngine.SO.Variables
{
	[CreateAssetMenu(menuName ="SO/Variables/TransformSO")]
	public class TransformSO : SerializedScriptableObject, ITransformSO<GameEvent>
	{
		[SerializeField] private GameEvent _onPositionOverrided;
		[SerializeField] private GameEvent _onRotationOverrided;

		[ReadOnly][ShowInInspector] private Transform _transform;

		public void AssignTransform(Transform trans) => _transform = trans;

		public GameEvent OnPositionOverrided
		{
			get => _onPositionOverrided;
			set => _onPositionOverrided = value;
		}

		public GameEvent OnRotationOverrided 
		{ 
			get => _onRotationOverrided; 
			set => _onRotationOverrided = value;
		}

		public Vector3 Forward => _transform.forward;
		public Vector3 Up => _transform.up;
		public Vector3 Right => _transform.right;

		public Vector3 Position
		{
			get => _transform.position;
			set
			{
				_transform.position = value;
				_onPositionOverrided?.Raise();
			}
		}

		public Quaternion Rotation
		{
			get => _transform.rotation;
			set
			{
				_transform.rotation = value;
				_onRotationOverrided?.Raise();
			}
		}

		public void Rotate(Vector3 axis, float rotate)
		{
			_transform.Rotate(axis, rotate);
			_onRotationOverrided?.Raise();
		}

		public void LookAt(Vector3 to)
		{
			_transform.LookAt(to);
			_onRotationOverrided?.Raise();
		}
	}
}
