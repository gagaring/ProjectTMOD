using System;
using UnityEngine;
using VEngine.Enviroment.Rotate;
using VEngine.SO.Variables;

namespace VEngine.Interaction.Command
{
	public class RotateObjectCommandBehaviour : CommandBehaviour
	{
		[SerializeField] private Data _data;
		[SerializeField] private Components _components;

		public void Interrupt()
		{
			_data.IsFinished = true;
		}

		protected override ICommand CreateCommand() => new RotateObjectCommand(_data, _components);

		[Serializable]
		public class Data : RotateObjectCommand.ICommandData, RotateObjectCommand.IData
		{
			[SerializeField] private FloatReference _rotateSpeed;
			[SerializeField] private FloatReference _rotateX;
			[SerializeField] private FloatReference _rotateY;
			[SerializeField] private Vector2 _limitX;
			[SerializeField] private Vector2 _limitY;

			public float Speed => _rotateSpeed.Value;
			public Vector2 LimitX => _limitX;
			public Vector2 LimitY => _limitY;
			public Vector2 LimitZ => Vector2.zero;

			public RotatorClampTransform.IData BaseData => this;
			public float RotateX => -_rotateX.Value;
			public float RotateY => _rotateY.Value;
			public bool IsFinished { get; set; }
		}

		[Serializable]
		public class Components : RotateObjectCommand.IComponents
		{
			[SerializeField] private Transform _target;

			public Transform TargetX => _target;
			public Transform TargetY => _target;
			public Transform TargetZ => null;
		}
	}
}
