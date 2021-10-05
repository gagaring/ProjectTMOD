using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using VEngine.Log;

namespace VEngine.ObjectPool
{
	[CreateAssetMenu(menuName = "SO/ObjectPool/SystemData")]
	class ObjectPoolSystemData : SerializedScriptableObject, ObjectPoolSystem.IData
	{
		[SerializeField] private List<ObjectPoolData> _objectPoolDataList;

		private Dictionary<int, IObjectPool<MonoBehaviour>> _objectPools = new Dictionary<int, IObjectPool<MonoBehaviour>>();

		public IReadOnlyDictionary<int, IObjectPool<MonoBehaviour>> ObjectPools => _objectPools;

		[EnableIf("@UnityEngine.Application.isPlaying == true")]
		[Button("RefreshDictionary")]
		public void InitDictionary(Transform parent = null)
		{
			bool needCheck = _objectPools.Count != 0;
			foreach (var curr in _objectPoolDataList)
			{
				if (needCheck && _objectPools.ContainsKey(curr.Id))
					continue;
				CreateAndAddObjectPool(curr, parent);
			}
		}

		private void CreateAndAddObjectPool(ObjectPoolData data, Transform parent = null)
		{
			CreateChild(data.Prefab.name, parent, out var childParent);
			var objectPool = CreateObjectPool(data, childParent);
			VLog.Log(VLog.eFlag.Game, VLog.eLevel.Normal, $"Object pool created: {data.Id} (Prefab name: {data.Prefab.name})");
			_objectPools.Add(data.Id, objectPool);
		}

		private void CreateChild(string name, Transform parent, out Transform childParent)
		{
#if !UNITY_EDITOR
			childParent = null;
			return;
#else
			if (parent == null)
			{
				childParent = null;
				return;
			}
			childParent = new GameObject(name).transform;
			childParent.parent = parent;
#endif
		}

		private IObjectPool<MonoBehaviour> CreateObjectPool(IObjectPoolData data, Transform parent = null)
		{
			var objectPool = new TObjectPool<MonoBehaviour>(data, parent);
			return objectPool;
		}
	}
}
