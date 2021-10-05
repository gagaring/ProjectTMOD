using VEngine.Equipments;

namespace VEngine.HandSystem
{
	public interface IHandController
	{
		void Activate(int slotIndex);
		void Activate(IReadOnlyEquipmentSlot slot);
	}
}