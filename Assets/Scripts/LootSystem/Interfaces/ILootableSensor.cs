using UnityEngine;

namespace VEngine.LootSystem
{
	public interface ILootableSensor
	{
		void OnTriggerEnter(Collider collider);
		void OnTriggerExit(Collider collider);
	}
}