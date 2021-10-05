using UnityEngine;

namespace VEngine.AI.Senses.Sensors.Sight
{
	public class SightTarget_Flashlight : SightTarget
	{
		private Vector3 _positionCache = Vector3.positiveInfinity;

		public Vector3 Position 
		{
			set
			{
				transform.position = value;
				_positionCache = value;
			}
		}


		public bool IsLocked(UnityEngine.Light light)
		{
			if (!Targeted || _positionCache == Vector3.positiveInfinity)
				return false;
			var diffVector = _positionCache - light.transform.position;
			if (diffVector.sqrMagnitude > light.range * light.range)
				return false;
			var diffAngle = Vector3.Angle(diffVector, light.transform.forward);
			return diffAngle <= light.spotAngle;
		}

		public void StayInPosition()
		{
			Position = _positionCache;
		}
	}
}