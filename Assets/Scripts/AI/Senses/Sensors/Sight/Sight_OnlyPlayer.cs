using UnityEngine;

namespace VEngine.AI.Senses.Sensors.Sight
{
	public class Sight_OnlyPlayer : SensorBase<SightTarget_Player>
	{
		[SerializeField] private BoxCollider _sightCollider;

		public float SightRange { get => _sightCollider.size.z; }
	}
}
