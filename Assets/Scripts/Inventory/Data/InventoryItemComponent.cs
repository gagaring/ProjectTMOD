using UnityEngine;
using VEngine.Items;

namespace VEngine.Inventory
{
	[CreateAssetMenu(menuName = "SO/Item/ItemComponents/InventoryComponent")]
	public class InventoryItemComponent : ItemComponent
	{
		public static InventoryItemComponent FindOn(IItem item) => FindOn<InventoryItemComponent>(item, false);

		[SerializeField] private uint _stackCount = 1;

		public bool IsStackable { get => _stackCount > 1; }

		public uint StackCount 
		{ 
			get => IsStackable ? _stackCount : 1; 
			set => _stackCount = value;
		}

	}
}
