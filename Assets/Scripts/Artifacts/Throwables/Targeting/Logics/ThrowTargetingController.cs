using UnityEngine;
using VEngine.Items;
using VEngine.SO.Variables;

namespace VEngine.Artifacts.Throwables
{
	public class ThrowTargetingController : TargetingController
	{
		private readonly IThrowData _data;
		private readonly TargetingData _currentTargeting = new TargetingData();

		public ThrowTargetingController(IData data, IThrowData throwData) : base(data)
		{
			_data = throwData;
			TargetingSuccess(false);
		}

		protected override void DoUpdate(float deltaTime)
		{
			UpdateTrajection(deltaTime);
		}

		private void UpdateTrajection(float deltaTime)
		{
			CalculateCollisionPosition(out var position, deltaTime);
			ShowMarker(position);
        }

		private void CalculateCollisionPosition(out Vector3 position, float deltaTime)
		{
			position = _currentTargeting.HandPosition.Position;
			var acceleration = _currentTargeting.ViewDirection.Forward * _data.ThrowForce / _currentTargeting.ThrowableData.Mass;
			var gravityAcc = Physics.gravity.y * deltaTime;
			var raycastDistance = _data.RaycastDistance;
			for (int i = 0; i < _data.MaxCollisionAttemptCount; i++)
			{
				acceleration.y += gravityAcc;
				var movement = acceleration * deltaTime;
				if (Physics.Raycast(position, movement, out var hit, raycastDistance, _data.LayerMask))
				{
					position = hit.point;
					break;
				}
				position += movement;
			}
		}

		private void ShowMarker(Vector3 position)
		{
			_data.Marker.SetActive(true);
			_data.Marker.transform.position = position;
		}

		protected override bool Targeting<T>(IItem item, IArtifactData data, T useage, ITransformSOReference handPosition, ITransformSOReference viewDirection)
		{
			if (!ArtifactUseage.ConvertUseage<ThrowableArtifactUseage>(useage, out var throwableUsage))
				return false;
			_currentTargeting.ThrowableData = throwableUsage.Data;
			_currentTargeting.HandPosition = handPosition;
			_currentTargeting.ViewDirection = viewDirection;
			return true;
		}

		protected override void Reset()
		{
			_currentTargeting.ThrowableData = null;
			_data.Marker.gameObject.SetActive(false);
		}

		public interface IThrowData : IData
		{
			float ThrowForce { get; }
			int MaxCollisionAttemptCount { get; }
			int LayerMask { get; }
			float RaycastDistance { get; }
			GameObject Marker { get; }
		}

		private class TargetingData
		{
			public ITransformSOReference HandPosition { get; set; }
			public ITransformSOReference ViewDirection { get; set; }
			public IThrowableData ThrowableData { get; set; }
		}
	}
}