using Sirenix.OdinInspector;
using UnityEngine;

namespace VEngine.ObjectPool
{
	public class ObjectPoolClientBehaviour<T> : SerializedMonoBehaviour where T : MonoBehaviour
	{
		[SerializeField] private ObjectPoolSystemSO _system;
		[SerializeField] protected IObjectPoolEntity _entity;

		public IObjectPoolSystem System => _system.System;
	}
}
