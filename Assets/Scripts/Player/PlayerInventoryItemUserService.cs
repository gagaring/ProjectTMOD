using System;
using UnityEngine;
using VEngine.Inventory;
using VEngine.Items;

namespace VEngine.Player
{
	[CreateAssetMenu(menuName = "SO/Inventory/PlayerInventoryItemUserService")]
	public class PlayerInventoryItemUserService : ScriptableObject, InventoryItemUserService.IData, IOnItemUsed, ICanUseItem
	{
		[SerializeField] public GlobalInventories _globalInventories;

		private IInventoryItemUserService _service = null;

		public IInventoryItemUserService Service
		{
			get
			{
				CreateService();
				return _service;
			}
		}

		private void CreateService()
		{
			if (_service != null)
				return;
			_service = new InventoryItemUserService(this);
		}

		public IInventory Inventory => _globalInventories.PlayerInventory;
		public bool CanUse(IItem item) => Service.CanUse(item);
		public void OnUsed(IItem item) => Service.OnUsed(item);
	}
}
