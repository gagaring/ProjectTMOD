using System;
using UnityEngine;
using VEngine.Items;
using VEngine.Log;

namespace VEngine.Equipments
{
	[Serializable]
	public class EquipmentSlot : IEquipmentSlot, IReadOnlyEquipmentSlot
	{
		[SerializeField] private Item _item;

		public int Index { get; set; }
		public IItem Item => _item;
		public EquipmentSlot(int index) => Index = index;
		public void Clear() => SetItem(null);

		public void SetItem(IItem item)
		{
			_item = (Item)item;
			VLog.Log(VLog.eFlag.Game, VLog.eLevel.None, $"Equipment (Slot: {Index}) changed: {(Item == null ? "null" : Item.Details.Name)}");
		}
	}
}
