using System.Collections.Generic;
using UnityEngine;
using VEngine.Log;

namespace VEngine.ObjectPool
{
	public class TObjectPool<T> : IObjectPool<T> where T : MonoBehaviour
	{
		private readonly IObjectPoolData _data;
		private readonly Queue<T> _queue = new Queue<T>();
		private readonly Transform _parent;
		public int Id => _data.Id;

		private int _additionalNumber;
		private int RequiredEntityNumber => _data.DefaultNumber + _additionalNumber;

		public TObjectPool(IObjectPoolData data, Transform parent = null)
		{
			_data = data;
			_parent = parent;
			CreateEntities();
		}

		public void Push(T t)
		{
			t.gameObject.SetActive(false);
			t.transform.SetParent(_parent);
			_queue.Enqueue(t);
		}

		public T Pull() => _queue.Count == 0 ? CreateEntityWithError() : _queue.Dequeue();

		private void CreateEntities()
		{
			for (int i = 0; i < _data.DefaultNumber; ++i)
				Push(CreateEntity(i));
		}

		protected T CreateEntity(int namePostFix)
		{
			var gameObject = UnityEngine.Object.Instantiate(_data.Prefab, _parent);
#if UNITY_EDITOR
			gameObject.name = $"{_data.Prefab.name} {namePostFix}";
#endif
			T element = gameObject.GetComponent<T>();
			gameObject.SetActive(false);
			return element;
		}

		private T CreateEntityWithError()
		{
			++_additionalNumber;
			VLog.Log(VLog.eFlag.Game, VLog.eLevel.Warning, $"Not enought element in objectPool {_data.Prefab.name} ({typeof(T)}): DefaultNumber: {_data.DefaultNumber}, RequiredEntityNumber: {RequiredEntityNumber}");
			return CreateEntity(RequiredEntityNumber);
		}
	}
}
