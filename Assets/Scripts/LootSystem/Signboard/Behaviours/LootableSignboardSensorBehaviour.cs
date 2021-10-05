using UnityEngine;
using VEngine.SO.Events;
using VEngine.SO.Variables;

namespace VEngine.LootSystem.Signboard
{
    public class LootableSignboardSensorBehaviour : MonoBehaviour, LootableSignboardSensor.IData
    {
        [SerializeField] private LootableSignboardGameEvent _activateLootableObject;
        [SerializeField] private LootableSignboardGameEvent _deactivateLootableObject;
        [SerializeField] private SphereCollider _detector;
        [SerializeField] private FloatReference _detectionRange;

        private ILootableSensor _sensor;

        public Transform Trigger => _detector.transform;
        public SphereCollider Detector => _detector;
        public float DetectionRange => _detectionRange.Value;
        public IGameEvent<ILootableSignboard> ActivateLootableObject => _activateLootableObject;
		public IGameEvent<ILootableSignboard> DeactivateLootableObject => _deactivateLootableObject;

		private void Awake() => _sensor = new LootableSignboardSensor(this);
		public void OnTriggerEnter(Collider other) => _sensor.OnTriggerEnter(other);
		public void OnTriggerExit(Collider other) => _sensor.OnTriggerExit(other);
	}
}
