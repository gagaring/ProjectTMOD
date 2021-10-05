using Sirenix.OdinInspector;
using System;
using UnityEngine;
using VEngine.Items;
using VEngine.Log;
using VEngine.SO.Events;

namespace VEngine.Equipments
{
	[CreateAssetMenu(menuName = "SO/Equipments/ActiveEquipment")]
	public class EquipmentSlotCopyVariable : SerializedScriptableObject, IEquipmentSlotCopy
	{
		[SerializeField] public IGameEvent<IReadOnlyEquipmentSlot> OnEquipmentChanged { get; private set; }

		public int Index { get; private set; }
		public IItem Item { get; private set; }

		public void Copy(IReadOnlyEquipmentSlot slot)
		{
			if (slot == null)
				Clear();
			else
				Set(slot.Index, slot.Item);
		}

		public void Clear() => Set(-1, null);

		private void Set(int index, IItem item)
		{
			Index = index;
			Item = item;
			VLog.Log(VLog.eFlag.Game, VLog.eLevel.None, $"Active Equipment changed: {(Item == null ? "null" : Item.Details.Name)} (Slot: {Index})");
			OnEquipmentChanged.Raise(this);
		}
	}

	[Serializable]
	public class EquipmentSlotCopyReference
	{
		[SerializeField] private EquipmentSlotCopyVariable _active;
		public IReadOnlyEquipmentSlot ActiveSlot => _active; 
	}
}
