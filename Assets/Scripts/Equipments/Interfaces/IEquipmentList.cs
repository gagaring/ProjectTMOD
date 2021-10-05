using System.Collections.Generic;
using VEngine.Items;

namespace VEngine.Equipments
{
	public interface IEquipmentList : IReadOnlyEquipmentList
	{
		void SetSlot(int slot, IItem item);
		void ClearSlot(int slot);
	}

	public interface IReadOnlyEquipmentList
	{
		int Count { get; }
		IReadOnlyList<IReadOnlyEquipmentSlot> ReadOnlyList { get; }
	}
}
