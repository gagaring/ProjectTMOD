using UnityEngine;
using VEngine.LootSystem.Signboard;
using VEngine.SO.Events;
using VEngine.TimerSystem;

namespace VEngine.LootSystem.Destoryer
{
	public class LootableDestroyer : ILootableDestroyer
	{
		private readonly IData _data;
		
		public LootableDestroyer(IData data) => _data = data;

		public void Destroy(ILootable lootable)
		{
			if (_data.ActiveSignboardMap.TryGet(lootable, out var signboard))
				Destroy(signboard.GameObject);
			else
				Destroy(lootable.GameObject);
		}

		private void Destroy(GameObject gameObject)
		{
			gameObject.transform.position = Vector3.one * 6000;
			ITimable timable = new Timable(_data.DestroyDelay, () => DoDestroy(gameObject));
			_data.StartTimer.Raise(timable);
		}

		private void DoDestroy(GameObject gameObject)
		{
			Object.Destroy(gameObject);
		}

		public interface IData
		{
			IGameEvent<ITimable> StartTimer { get; }
			ILootableSignboardMapReference ActiveSignboardMap { get; }
			float DestroyDelay { get; }
		}
	}
}