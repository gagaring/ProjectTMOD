using UnityEngine;
using VEngine.Equipments;
using VEngine.Inventory;

namespace VEngine.HandSystem
{
	public class HandInventoryHandlerBehaviour : MonoBehaviour, HandInventoryHandler.IData
	{
		[SerializeField] private EquipmentSlotCopyVariable _equipmentInHand;

		public IEquipmentSlotCopy EquipmentInHand => _equipmentInHand;
		
		private IHandInventoryHandler _handler;

		private void Awake()
		{
			_handler = new HandInventoryHandler(this);
		}

		public void OnInventoryChanged(IInventoryData data) => _handler.OnInventoryChanged(data); 
	}
}
