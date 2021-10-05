using UnityEngine;
using VEngine.Items;

namespace VEngine.Inventory.GUI
{
	[CreateAssetMenu(menuName = "SO/Item/ItemComponents/DetailsItemComponent")]
	public class InventoryGUIItemComponent : ItemComponent, IInventoryItemGUIDetails
	{
		public static InventoryGUIItemComponent FindOn(IItem item) => FindOn<InventoryGUIItemComponent>(item, false);

		[SerializeField] private Sprite _avatar;

		public Sprite Avatar { get => _avatar; }
	}
}
