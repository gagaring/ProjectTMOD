using UnityEngine;
using VEngine.Items;

namespace VEngine.LockAndKey
{
	[CreateAssetMenu(menuName = "SO/Item/ItemComponents/KeyComponent")]
	public class KeyComponent : ItemComponent
    {
		[SerializeField] private bool _removeItemOnUse;

		public bool RemoveItemOnUse => _removeItemOnUse;
			
	}
}
