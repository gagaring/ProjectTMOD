using UnityEngine;
using VEngine.SO.Events;
using VEngine.SO.Variables;

namespace VEngine.LootSystem
{
	public class LootableSensorBehaviour : MonoBehaviour, LootableSensor.IData
	{
		[SerializeField] private LootableContainer _lootableContainer;
		[SerializeField] private BoolGameEvent _lootableSensorSign;
		[SerializeField] private FloatReference _sensorRange;
		[SerializeField] private SphereCollider _sensorTrigger;
		[SerializeField] private TransformSO _followTarget;

		private ILootableSensor _sensor;

		public ILootableCollection Collection => _lootableContainer;
		public IGameEvent<bool> LootableSensorSign => _lootableSensorSign;
		public float SensorRange => _sensorRange.Value;
		public SphereCollider SensorTrigger => _sensorTrigger;
		public Vector3 Position { set => transform.position = value; }

		private void Start() => _sensor = new LootableSensor(this);
		private void OnTriggerEnter(Collider other) => _sensor.OnTriggerEnter(other);
		private void OnTriggerExit(Collider other) => _sensor.OnTriggerExit(other);
	}
}