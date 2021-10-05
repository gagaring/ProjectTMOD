using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.LootSystem.Signboard
{
    public class LootableSignboardSensor : ILootableSensor
    {
        private readonly IData _data;

		public LootableSignboardSensor(IData data)
		{
			_data = data;
			_data.Detector.radius = _data.DetectionRange;
		}

		public void OnTriggerEnter(Collider other)
		{
			if (!GetLootableObject(other, out var lootableObject))
				return;
			_data.ActivateLootableObject.Raise(lootableObject);
		}

		public void OnTriggerExit(Collider other)
		{
			if (!GetLootableObject(other, out var lootableObject))
				return;
			_data.DeactivateLootableObject.Raise(lootableObject);
		}

		private bool GetLootableObject(Collider other, out ILootableSignboard lootableObject)
		{
			var lootableObjectBehaviour = other.GetComponent<ILootableSignboardBehaviour>();
			if (lootableObjectBehaviour == null)
			{
				lootableObject = null;
				return false;
			}
			lootableObject = lootableObjectBehaviour.LootableObject;
			return true;
		}

		public interface IData
        {
			Transform Trigger { get; }
			IGameEvent<ILootableSignboard> ActivateLootableObject { get; }
			IGameEvent<ILootableSignboard> DeactivateLootableObject { get; }
			SphereCollider Detector { get; }
			float DetectionRange { get; }
        }
    }
}
