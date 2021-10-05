using System;
using UnityEngine;
using VEngine;
using VEngine.SO.Variables;

namespace VEngine.Interaction.Command
{
	public class GrabInteractorToBehaviour : CommandBehaviour
	{
		[SerializeField] private Data _data;
		[SerializeField] private Components _components;

		protected override ICommand CreateCommand() => new GrabInteractorToCommand(_data, _components);

		[Serializable]
		public class Data : GrabInteractorToCommand.IData
		{
			[SerializeField] private FloatReference _maxMoveSpeed;
			[SerializeField] private FloatReference _maxRotationSpeed;
			[SerializeField] private FloatReference _maxSqrDistance;
			[SerializeField] private FloatReference _maxAngle;

			public float MaxMoveSpeed => _maxMoveSpeed.Value;
			public float MaxRotationSpeed => _maxRotationSpeed.Value;
			public float MaxSqrDistance => _maxSqrDistance.Value;
			public float MaxAngle => _maxAngle.Value;
		}

		[Serializable]
		public class Components : GrabInteractorToCommand.IComponents
		{
			[SerializeField] private Transform _target;

			public Transform Target => _target;
		}
	}
}
