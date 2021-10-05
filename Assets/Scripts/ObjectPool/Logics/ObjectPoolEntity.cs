using Sirenix.OdinInspector;
using UnityEngine;

namespace VEngine.ObjectPool
{
	[CreateAssetMenu(menuName = "SO/ObjectPool/Entity")]
	public class ObjectPoolEntity : SerializedScriptableObject, IObjectPoolEntity
	{
		[Tooltip("Limitacio: Barmi lehet, de kell rajta lenni egy MonoBehaviournek. Defaultnak: ObjectPoolBaseEntityBehaviour (nem kell ebbol szarmaznia)")]
		[SerializeField] private MonoBehaviour _prefab;

		public int Id => GetId(_prefab.gameObject).GetHashCode();

		public GameObject Prefab => _prefab.gameObject;

		public static int GetId(GameObject obj) => obj.gameObject.GetHashCode();
	}
}
