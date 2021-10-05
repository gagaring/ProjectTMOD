using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.Items
{
	[CreateAssetMenu(menuName = "SO/Item/Events/ItemGameEvent")]
	public class ItemGameEvent : TGameEvent<IItem>
	{
#if UNITY_EDITOR
		public Item TestItem;
#endif
	}
}
