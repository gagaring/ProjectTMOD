using VEngine.Items;

namespace VEngine.Equipments
{
	public interface IEquipmentSlot : IReadOnlyEquipmentSlot
	{
		void SetItem(IItem item);
		void Clear();
	}

	public interface IEquipmentSlotCopy : IReadOnlyEquipmentSlot
	{
		void Copy(IReadOnlyEquipmentSlot slot);
		void Clear();
	}

	public interface IReadOnlyEquipmentSlot
	{
		int Index { get; }
		IItem Item { get; }
	}
}
