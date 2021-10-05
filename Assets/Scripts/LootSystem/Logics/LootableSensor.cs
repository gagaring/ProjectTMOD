using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.LootSystem
{
	public class LootableSensor : ILootableSensor
	{
		private readonly IData _data;

		public LootableSensor(IData data)
		{
			_data = data;
			_data.Collection.Clear();
			_data.LootableSensorSign.Raise(false);
			_data.SensorTrigger.radius = _data.SensorRange;
		}

		public void OnTriggerEnter(Collider collider)
		{
			if (!GetLootable(collider, out var lootable))
				return;
			_data.Collection.Add(lootable);
			_data.LootableSensorSign.Raise(true);
		}

		public void OnTriggerExit(Collider collider)
		{
			if (!GetLootable(collider, out var lootable))
				return;
			_data.Collection.Remove(lootable);
			if (!_data.Collection.IsEmpty)
				return;
			_data.LootableSensorSign.Raise(false);
		}

		private bool GetLootable(Collider collider, out ILootable lootable)
		{
			var lootableBehaviour = collider.GetComponentInParent<ILootableBehaviour>();
			if(lootableBehaviour == null)
			{
				lootable = null;
				return false;
			}
			lootable = lootableBehaviour.Lootable;
			return true;
		}

		public interface IData
		{
			ILootableCollection Collection { get; }
			IGameEvent<bool> LootableSensorSign { get; }
			SphereCollider SensorTrigger { get; }
			float SensorRange { get; }
			Vector3 Position { set; }
		}
	}
}