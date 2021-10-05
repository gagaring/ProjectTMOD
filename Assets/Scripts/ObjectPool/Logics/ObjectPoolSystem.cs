using System.Collections.Generic;
using UnityEngine;
using VEngine.Log;

namespace VEngine.ObjectPool
{
	public class ObjectPoolSystem : IObjectPoolSystem
	{
		private readonly IData _data;

		private Dictionary<int, int> _prefabOwners = new Dictionary<int, int>();

		public ObjectPoolSystem(IData data) => _data = data;

		public T Pull<T>(IObjectPoolEntity entity) where T : MonoBehaviour
		{
			return Pull<T>(entity.Id, entity.Prefab.name);
		}

		public T Pull<T>(T prefab) where T : MonoBehaviour
		{
			return Pull<T>(ObjectPoolEntity.GetId(prefab.gameObject), prefab.gameObject.name);
		}

		private T Pull<T>(int id, string name) where T : MonoBehaviour
		{
			if (!_data.ObjectPools.TryGetValue(id, out var objectPool))
			{
				VLog.Log(VLog.eFlag.Game, VLog.eLevel.Error, $"{id} (Prefab name: {name}) objectPool nem letezik");
				return null;
			}

			var t = (T)objectPool.Pull();
			_prefabOwners[t.GetHashCode()] = objectPool.Id;
			return t;
		}

		public void Push<T>(T obj) where T : MonoBehaviour
		{
			obj.gameObject.SetActive(false);
			_data.ObjectPools[_prefabOwners[obj.GetHashCode()]].Push(obj);
		}

		public interface IData
		{
			//Entity id - objectPool
			IReadOnlyDictionary<int, IObjectPool<MonoBehaviour>> ObjectPools { get; }
		}
	}
}
