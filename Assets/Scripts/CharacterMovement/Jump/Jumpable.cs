using UnityEngine;
using System.Collections.Generic;

namespace VEngine.Game.Entity.Jump
{
	public class Jumpable : MonoBehaviour
	{
		[SerializeField] private AnimationCurve _heightCurve;
		[SerializeField] private float _duration;
		[SerializeField] private float _height;
		[SerializeField] private List<Transform> _landingPoint;

		public float Duration { get => _duration; }
		public AnimationCurve HeightCurve { get => _heightCurve; }
		public float Height { get => _height; }

		public bool GetLandingPoint(Vector3 position, Vector3 direction, ref float maxAngle, ref Vector3 landingPoint)
		{
			Transform startPosition = GetStartPosition(position);
			return GetLandingPoint(startPosition, direction, ref maxAngle, ref landingPoint);
		}

		private Transform GetStartPosition(Vector3 position)
		{
			float minDist = float.MaxValue;
			Transform closest = null;
			foreach (var curr in _landingPoint)
			{
				var dist = Utils.DistanceSqr(position, curr.position);
				if (dist > minDist)
					continue;
				minDist = dist;
				closest = curr;
			}
			return closest;
		}

		private bool GetLandingPoint(Transform startPosition, Vector3 direction, ref float maxAngle, ref Vector3 landingPoint)
		{
			bool found = false;
			foreach(var curr in _landingPoint)
			{
				if (curr == startPosition)
					continue;
				var angle = Vector3.Angle(curr.position - startPosition.position, direction);
				if (angle > maxAngle)
					continue;
				maxAngle = angle;
				landingPoint = curr.position;
				found = true;
			}
			return found;
		}
	}
}