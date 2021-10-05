using System;
using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Enviroment.Rotate
{
    public class RotatorBehaviour : MonoBehaviour
	{
		[SerializeField] private Data _data;
		[SerializeField] private Components _components;

		public IRotator Rotator { get; private set; }

		protected void Awake()
		{
			Rotator = new RotatorTransform(_data, _components);
		}

		protected void Update()
		{
			if (!_data.IsRotateActive)
				return;
			Rotator.Rotate();
		}

		[Serializable]
		public class Data : RotatorTransform.IData
		{
			[SerializeField] private FloatReference _rotateSpeed;
			[SerializeField] private FloatReference _rotateX;
			[SerializeField] private FloatReference _rotateY;
			[SerializeField] private FloatReference _rotateZ;
			[SerializeField] private BoolReference _active;

			public float Speed => _rotateSpeed.Value;

			public float RotateX => _rotateX.Value;
			public float RotateY => _rotateY.Value;
			public float RotateZ => _rotateZ.Value;

			public bool IsRotateActive => _active.Value;
		}


		[Serializable]
		public class Components : RotatorTransform.IComponents
		{
			[SerializeField] private Transform _target;

			public Transform Target => _target;
		}
	}
}
