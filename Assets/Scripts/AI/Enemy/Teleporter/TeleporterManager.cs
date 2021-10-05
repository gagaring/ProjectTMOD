using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using VEngine.Camera;
using VEngine;
using VEngine.SO.Variables;

namespace VEngine.AI.Enemy.Teleporter
{
	public class TeleporterManager : MonoBehaviour
	{
		[SerializeField] private Teleporter _teleporter;

		[SerializeField] private List<TeleportZone> _zones;
		[SerializeField] private List<TeleportTrigger> _triggers;

		[SerializeField] private Vector2 _rangeToRandomTeleport = new Vector2( 5.0f, 7.5f );
		[SerializeField] private float _maxDistanceToRandomTeleport = 10.0f;
		[SerializeField] private int _calculateCountRandomPositionPerFrame = 10;

		[SerializeField] private TransformSO _playerTransform;

		private float _lastTeleporTime = 0.0f;
		private float NextPossibleTeleportTime { get => _lastTeleporTime + _teleportCooldown; }
		private float _teleportCooldown = Mathf.Infinity;

		private NavMeshPath _testPath;

		public void Init(Transform cameraAnchor)
		{
			InitZones();
			InitTriggers();
			_teleporter.Init(cameraAnchor);
			_testPath = new NavMeshPath();
		}

		private void InitZones()
		{
			foreach (var curr in _zones)
				InitZone(curr);
		}

		private void InitZone(TeleportZone zone)
		{
			zone.OnPlayerReachedNewZone += OnPlayerReachedNewZone;
		}

		private void InitTriggers()
		{
			foreach (var curr in _triggers)
				InitTrigger(curr);
		}

		private void InitTrigger(TeleportTrigger trigger)
		{
			trigger.OnPlayerEntered += OnPlayerEntered;
		}

		private void OnPlayerReachedNewZone(TeleportZone zone)
		{
			_teleportCooldown = zone.TeleporterCooldown;
		}

		private void OnPlayerEntered(TeleportTrigger trigger)
		{
			DoTeleport(trigger.TeleportPosition);
		}

		private void DoTeleport(Vector3 position)
		{
			_teleporter.TeleportToPosition(position);
			_lastTeleporTime = Time.time;
		}

		private void Update()
		{
			if (_teleporter.IsPlayerSeenProp || NextPossibleTeleportTime > Time.time)
				return;

			if (!GetValidatedRandomPositionToTeleport(out var validatedRandomPos))
				return;

			DoTeleport(validatedRandomPos);
		}

		private bool GetValidatedRandomPositionToTeleport(out Vector3 validatedRandomPos)
		{
			validatedRandomPos = Vector3.zero;
			for (int i = 0; i < _calculateCountRandomPositionPerFrame; ++i)
			{
				validatedRandomPos = GetRandomPositionToTeleport();
				if (!NavMesh.CalculatePath(_playerTransform.Position, validatedRandomPos, _teleporter.NavMeshAreaMask, _testPath))
					continue;
				if (_testPath.status != NavMeshPathStatus.PathComplete)
					continue;
				var sqrDistance = GetTestPathSqrDistance();
				if (sqrDistance > _maxDistanceToRandomTeleport)
					continue;
				for (int j = 0; j < _testPath.corners.Length - 1; j++)
					Debug.DrawLine(_testPath.corners[j], _testPath.corners[j + 1], Color.red, _teleportCooldown);
				return true;
			}
			return false;
		}

		private float GetTestPathSqrDistance()
		{
			float sqrDistance = 0.0f;
			for(int i = 0; i < _testPath.corners.Length - 1; ++i)
			{
				sqrDistance = Vector3.Distance(_testPath.corners[i], _testPath.corners[i + 1]);
			}
			return sqrDistance;
		}

		private Vector3 GetRandomPositionToTeleport()
		{
			return Utils.GetRandomPointOnNavMesh(_playerTransform.Position, _rangeToRandomTeleport);
		}

		//[Serializable]
		//private 
	}
}
