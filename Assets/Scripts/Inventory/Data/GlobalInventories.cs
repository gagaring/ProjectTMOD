using System;
using UnityEngine;

namespace VEngine.Inventory
{
	[CreateAssetMenu(menuName = "SO/Inventory/GlobalInventories")]
	public class GlobalInventories : ScriptableObject, IGlobalInventories
	{
		[SerializeField] private Inventory _playerInventory;
		[SerializeField] private Inventory _stash;

		//public IItemContainer PlayerInventory => _playerInventory;
		//public IItemContainer Stash => _stash;
		public IInventory PlayerInventory => _playerInventory;
		public IInventory Stash => _stash;
	}

	public interface IInventoryReference
	{
		IInventory Inventory { get; }
	}

	[Serializable]
	public class InventoryReference : IInventoryReference
	{
		public enum InventoryType
		{
			Local,
			GlobalStash,
			GlobalInventory
		}

		[SerializeField] private InventoryType _type;
		[SerializeField] private Inventory _localInventory;
		[SerializeField] private GlobalInventories _globalInventories;

		public IInventory Inventory 
		{ 
			get
			{
				switch (_type)
				{
					case InventoryType.GlobalStash:
						return _globalInventories.Stash;
					case InventoryType.GlobalInventory:
						return _globalInventories.PlayerInventory;
					default:
						return _localInventory;
				}
			}
		}
	}
}
