using UnityEngine;
using VEngine.SO.Variables;
using VEngine.Enviroment.Rotate;
using System;

namespace VEngine.Player
{
	public class PlayerRotatorBehaviour : MonoBehaviour
	{
		[SerializeField] private Data _data;
		[SerializeField] private Components _components;

		private IRotator _rotator;

		private IRotator Rotator
		{
			get
			{
				if (_rotator == null)
					CreateRotator();
				return _rotator;
			}
		}

		private void CreateRotator()
		{
			_rotator = new RotatorTransformSO(_data, _components);
		}

		protected void Update()
		{
			Rotator.Rotate();
		}

		[Serializable]
		private class Data : RotatorTransformSO.IData
		{
			[SerializeField] protected TransformSO _target;
			[SerializeField] protected FloatReference _speed;
			[SerializeField] protected FloatReference _rotate;

			public float Speed => _speed.Value;
			public float RotateX => 0f;
			public TransformSO Target => _target;

			public float RotateY => _rotate.Value;
			public float RotateZ => 0f;
		}

		[Serializable]
		private class Components : RotatorTransformSO.IComponents
		{

		}

		//[SerializeField] private FloatReference _maxAngleOnJump;

		//private bool _isJumping = false;
		//private Vector3 _jumpDirection;

		//public void FixRotationOnJump()
		//{
		//	if (!_isJumping)
		//		return;
		//	var angle = Vector3.SignedAngle(_rotation.Forward, _jumpDirection, _rotation.Up);
		//	if(angle < -_maxAngleOnJump.Value)
		//	{
		//		_rotation.LookAt(_rotation.Position + _jumpDirection);
		//		_rotation.Rotate(_rotation.Up, _maxAngleOnJump.Value);
		//	}
		//	else if(angle > _maxAngleOnJump.Value)
		//	{
		//		_rotation.LookAt(_rotation.Position + _jumpDirection);
		//		_rotation.Rotate(_rotation.Up, -_maxAngleOnJump.Value);
		//	}
		//}

		//public void OnJump(bool jump, Vector3 direction)
		//{
		//	_isJumping = jump;
		//	direction.y = 0;
		//	_jumpDirection = direction;
		//}

	}
}
