using System;
using UnityEngine;
using VEngine;

namespace VEngine.Interaction.Command
{
	public class GrabInteractorToCommand : ICommand
	{
		public string Name => GetType().Name;
		private readonly IData _data;
		private readonly IComponents _components;

		public GrabInteractorToCommand(IData data, IComponents components)
		{
			_data = data;
			_components = components;
		}

		public void OnStart(IInteractor interactor)
		{
		}

		public bool OnUpdate(IInteractor interactor, float deltaTime)
		{
			SetPosition(interactor, deltaTime);
			SetRotation(interactor, deltaTime);
			return IsPositionGood(interactor) && IsRotationGood(interactor);
		}

		private void SetRotation(IInteractor interactor, float deltaTime)
		{
			interactor.Rotation = Quaternion.RotateTowards(interactor.Rotation, GetTargetRotation(interactor), _data.MaxRotationSpeed * deltaTime);
		}

		private Quaternion GetTargetRotation(IInteractor interactor)
		{
			var targetRotation = _components.Target.rotation.eulerAngles.y;
			var interactorRotation = interactor.Rotation.eulerAngles;
			return Quaternion.Euler(new Vector3(interactorRotation.x, targetRotation, interactorRotation.z));
		}

		private void SetPosition(IInteractor interactor, float deltaTime)
		{
			interactor.Position = Vector3.MoveTowards(interactor.Position, GetTargetPosition(interactor), _data.MaxMoveSpeed * deltaTime);
		}

		private Vector3 GetTargetPosition(IInteractor interactor)
		{
			var targetPosition = _components.Target.position;
			targetPosition.y = interactor.Position.y;
			return targetPosition;
		}

		public void OnExit(IInteractor interactor)
		{
		}

		public void DoReset()
		{
		}

		private bool IsPositionGood(IInteractor interactor)
		{
			return Utils.DistanceSqr(interactor.Position, GetTargetPosition(interactor)) <= _data.MaxSqrDistance;
		}

		private bool IsRotationGood(IInteractor interactor)
		{
			return Quaternion.Angle(interactor.Rotation, GetTargetRotation(interactor)) <= _data.MaxAngle;
		}

		public interface IData
		{
			float MaxMoveSpeed { get; }
			float MaxRotationSpeed { get; }
			float MaxSqrDistance { get; }
			float MaxAngle { get; }
		}

		public interface IComponents
		{
			Transform Target { get; }
		}
	}
}
