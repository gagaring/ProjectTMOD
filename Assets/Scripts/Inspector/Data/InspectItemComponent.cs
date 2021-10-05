using UnityEngine;
using VEngine.Items;

namespace VEngine.Inspector
{
    [CreateAssetMenu( menuName = "SO/Item/ItemComponents/Inspectable" )]
    public class InspectItemComponent : ItemComponent, IInspectable
    {
        [SerializeField] private GameObject _prefab;

        public GameObject Prefab => _prefab;
	}
}
