using Sirenix.OdinInspector;
using UnityEngine;
using VEngine.Equipments;
using VEngine.Items;

namespace VEngine.HandSystem
{
	public class HandControllerBehaviour : SerializedMonoBehaviour, HandController.IData, HandController.IComponents
	{
		[SerializeField] private EquipmentsReference _equipments;
		[SerializeField] private EquipmentSlotCopyVariable _equipmentInHand;
		[SerializeField] public ICanUseItem CanUseItem { get; private set; }

		private HandController _handController = null;
		private IHandController HandController
		{
			get
			{
				CreateController();
				return _handController;
			}
		}

		public void Awake() => CreateController();
		public void PickEquipment(int slot) => HandController.Activate(slot);
		public void PickEquipment(IEquipmentSlot slot) => HandController.Activate(slot);

		public IReadOnlyEquipmentList Equipments => _equipments.Value;
		public IReadOnlyEquipmentSlot ActiveEquipments
		{
			get => _equipmentInHand;
			set => _equipmentInHand.Copy(value);
		}

		private void CreateController()
		{
			if (_handController != null)
				return;
			_handController = new HandController(this, this);
		}
	}
}
