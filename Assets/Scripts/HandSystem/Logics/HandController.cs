using VEngine.Equipments;
using VEngine.Items;

namespace VEngine.HandSystem
{
	public class HandController : IHandController
	{
		private readonly IData _data;
		private readonly IComponents _components;

		public HandController(IData data, IComponents components)
		{
			_data = data;
			_components = components;
			Clear();
		}


		public void Activate(int slotIndex)
		{
			if (slotIndex == -1 || slotIndex == _data.ActiveEquipments.Index)
				Clear();
			else
				SetSlot(slotIndex);
		}

		private void Clear()
		{
			_data.ActiveEquipments = null;
		}

		private void SetSlot(int index)
		{
			if (_data.Equipments.Count <= index)
				return;
			Activate(_data.Equipments.ReadOnlyList[index]);
		}

		public void Activate(IReadOnlyEquipmentSlot slot)
		{ 
			if (!_components.CanUseItem.CanUse(slot.Item))
				return;
			_data.ActiveEquipments = slot;
		}

		public interface IData
		{
			IReadOnlyEquipmentList Equipments { get; }
			IReadOnlyEquipmentSlot ActiveEquipments { get; set; }
		}

		public interface IComponents
		{
			ICanUseItem CanUseItem { get; }
		}
	}
}
