using UnityEngine;

namespace VEngine.ObjectPool
{
	[CreateAssetMenu(menuName = "SO/ObjectPool/System")]
	public class ObjectPoolSystemSO : ScriptableObject
	{
		[SerializeField] private ObjectPoolSystemData _data;

		private ObjectPoolSystem _system = null;

		public IObjectPoolSystem System 
		{ 
			get
			{
				Init();
				return _system;
			}
		}

		public void Init(Transform parent = null)
		{
			if (_system != null)
				return;
			_data.InitDictionary(parent);
			_system = new ObjectPoolSystem(_data);
		}
	}
}
