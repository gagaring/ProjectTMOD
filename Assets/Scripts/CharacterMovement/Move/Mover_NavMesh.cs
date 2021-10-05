using UnityEngine;
using UnityEngine.AI;
using VEngine.Log;

namespace VEngine.Game.Move
{
	public class Mover_NavMesh : Mover
	{
		[SerializeField] private NavMeshAgent _navAgent;

		private Vector3 _previousDestionation;

		public int NavMeshAreaMask { get => _navAgent.areaMask; }

		public bool MovePosition(Vector3 targetPosition)
		{
			if (!_navAgent.enabled)
			{
				VLog.Log(VLog.eFlag.Game, VLog.eLevel.Warning, $"MoveAgent but navAgent is inactive");
				return false;
			}

			if (IsPathChanged(targetPosition))
			{
				if (IsTargetUnreachable())
					return false;

				_navAgent.SetDestination(targetPosition);
				_previousDestionation = targetPosition;
			}

			return true;
		}

		private bool IsTargetUnreachable()
		{
			//TODO
			return false;
		}

		private bool IsPathChanged(Vector3 targetPos)
		{
			return _previousDestionation != targetPos || _navAgent.pathStatus == NavMeshPathStatus.PathInvalid || _navAgent.isPathStale /* && !agent.hasPath */;
		}

		public void TeleportTo(Vector3 targetPos)
		{
			_navAgent.Warp(targetPos);
		}

		public void SetNavAgentSpeed(float speed, float maxSpeed)
		{
			_navAgent.speed = speed;
		}
	}
}
