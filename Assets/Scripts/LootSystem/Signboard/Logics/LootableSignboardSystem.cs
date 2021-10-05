using System;
using System.Collections.Generic;
using UnityEngine;
using VEngine.Log;
using VEngine.ObjectPool;
using VEngine.SO.Events;
using VEngine.TimerSystem;

namespace VEngine.LootSystem.Signboard
{
	public class LootableSignboardSystem : ILootableSignboardSystem
	{
		private readonly IData _data;

		public LootableSignboardSystem(IData data)
		{
			_data = data;
			_data.ActiveSignboardMap.Clear();
		}

		~LootableSignboardSystem() => _data.ActiveSignboardMap?.Clear();

		public void ActivateLootableObject(ILootableSignboard lootableSignboard)
		{
			if(lootableSignboard.AttachedModel != null)
			{
				VLog.Log(VLog.eFlag.Loot, VLog.eLevel.Warning, $"Double activated LootableObject ({lootableSignboard.Name}). Position: {lootableSignboard.Position}", lootableSignboard.AttachedModel.gameObject);
				return;
			}
			var lootableBehaviour =_data.ObjectPool.Pull<LootableBehaviour>(lootableSignboard.LootableEntity);
			_data.ActiveSignboardMap.Add(lootableBehaviour.Lootable, lootableSignboard);
			lootableSignboard.AttachedModel = lootableBehaviour;
		}

		public void DeactivateLootableObject(ILootableSignboard lootableObject)
		{
			if (lootableObject.AttachedModel == null)
			{
				VLog.Log(VLog.eFlag.Loot, VLog.eLevel.Warning, $"Deactiable LootableObject has no attached model  ({lootableObject.Name}). Position: {lootableObject.Position}");
				return;
			}
			var attachedModel = lootableObject.AttachedModel;
			lootableObject.AttachedModel = null;
			PushBack(attachedModel);
			_data.ActiveSignboardMap.Remove(attachedModel.Lootable);
		}

		private void PushBack(LootableBehaviour lootable)
		{
			lootable.transform.SetParent(null);
			lootable.transform.position = Vector3.one * 6000;
			ITimable timable = new Timable(_data.PushBackDelay, () => DoPushBack(lootable));
			_data.StartTimer.Raise(timable);
		}

		private void DoPushBack(LootableBehaviour lootable)
		{
			_data.ObjectPool.Push(lootable);
		}

		public interface IData
		{
			IObjectPoolSystem ObjectPool { get; }
			ILootableSignboardMap ActiveSignboardMap { get; }
			IGameEvent<ITimable> StartTimer { get; }
			float PushBackDelay { get; }
		}
	}
}
