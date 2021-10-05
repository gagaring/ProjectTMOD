using Sirenix.OdinInspector;
using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.ObjectPool
{
	[CreateAssetMenu( menuName = "SO/ObjectPool/ObjectPoolData")]
	public class ObjectPoolData : SerializedScriptableObject, IObjectPoolData 
	{
		[SerializeField] private IObjectPoolEntity _entity;
		[SerializeField] private IntReference _defaultNumber;

		public int DefaultNumber => _defaultNumber.Value;
		public int Id => _entity.Id;

		public GameObject Prefab => _entity.Prefab;
	}
}
