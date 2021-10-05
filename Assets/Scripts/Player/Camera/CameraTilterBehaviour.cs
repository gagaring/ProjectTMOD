using System;
using UnityEngine;
using VEngine.Enviroment.Rotate;
using VEngine.SO.Variables;

namespace VEngine.Player.Camera
{
	public class CameraTilterBehaviour : MonoBehaviour
	{
		[SerializeField] private Data _data;
		[SerializeField] private Components _components;

		private IRotatorClamp _rotator;
		private IRotatorClamp Rotator
		{
			get
			{
				if (_rotator == null)
					_rotator = new RotatorClampTransform(_data, _components);
				return _rotator;
			}
		}

		public void Tilt(float rotate)
		{
			Rotator.RotateX(rotate, Time.deltaTime);
		}

		[Serializable]
		public class Data : RotatorClampTransform.IData
		{
			[SerializeField] private FloatReference _tiltSpeed;
			[SerializeField] private Vector2Reference _tiltLimits;

			public Vector2 LimitX => _tiltLimits.Value;
			public Vector2 LimitY => Vector2.zero;
			public Vector2 LimitZ => Vector2.zero;
		
			public float Speed => -_tiltSpeed.Value;
		}

		[Serializable]
		public class Components : RotatorClampTransform.IComponents
		{
			[SerializeField] private Transform _camera;

			public Transform TargetX => _camera;
			public Transform TargetY => null;
			public Transform TargetZ => null;
		}
	}
}
