using UnityEngine;
using VEngine.LootSystem.Signboard;
using VEngine.SO.Events;
using VEngine.SO.Variables;
using VEngine.TimerSystem;

namespace VEngine.LootSystem.Destoryer
{
	public class LootableDestoyerBehaviour : MonoBehaviour, LootableDestroyer.IData
	{
		[SerializeField] private TimerGameEvent _startTimerGameEvent;
		[SerializeField] private LootableSignboardMapReference _activeSignboardMap;
		[SerializeField] private FloatReference _destroyDelay; 

		private ILootableDestroyer _destroyer;

		public IGameEvent<ITimable> StartTimer => _startTimerGameEvent;
		public ILootableSignboardMapReference ActiveSignboardMap => _activeSignboardMap.MapReference;
		public float DestroyDelay => _destroyDelay.Value;

		private void Awake() => _destroyer = new LootableDestroyer(this);
		public void DestroyLootable(ILootable lootable) => _destroyer.Destroy(lootable);
	}
}
