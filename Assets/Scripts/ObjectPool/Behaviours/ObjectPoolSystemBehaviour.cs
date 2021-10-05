using UnityEngine;

namespace VEngine.ObjectPool
{
	public class ObjectPoolSystemBehaviour : MonoBehaviour
	{
		[SerializeField] private ObjectPoolSystemSO _globalObjectPoolSystem;

		public void Awake()
		{
			_globalObjectPoolSystem.Init(transform);
		}
	}
}
