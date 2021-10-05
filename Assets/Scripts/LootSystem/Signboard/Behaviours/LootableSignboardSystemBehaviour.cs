using UnityEngine;
using VEngine.ObjectPool;
using VEngine.SO.Events;
using VEngine.SO.Variables;
using VEngine.TimerSystem;

namespace VEngine.LootSystem.Signboard
{
	public class LootableSignboardSystemBehaviour : MonoBehaviour, LootableSignboardSystem.IData
	{
		[SerializeField] private ObjectPoolSystemSO _objectPoolSytem;
		[SerializeField] private LootableSignboardMap _activeSignboardMap;
		[SerializeField] private FloatReference _pushBackDelay;
		[SerializeField] private TimerGameEvent _startTimer;

		private ILootableSignboardSystem _system;

		public IObjectPoolSystem ObjectPool => _objectPoolSytem.System;
		public ILootableSignboardMap ActiveSignboardMap => _activeSignboardMap;
		public IGameEvent<ITimable> StartTimer => _startTimer;
		public float PushBackDelay => _pushBackDelay.Value;

		private void Awake() => _system = new LootableSignboardSystem(this);
		public void ActivateLootableObject(ILootableSignboard obj) => _system.ActivateLootableObject(obj);
		public void DeactivateLootableObject(ILootableSignboard obj) => _system.DeactivateLootableObject(obj);
	}
}
