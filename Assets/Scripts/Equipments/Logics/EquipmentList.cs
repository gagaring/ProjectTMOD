using System.Collections.Generic;
using VEngine.Items;
using VEngine.SO.Events;

namespace VEngine.Equipments
{
	public class EquipmentList : IEquipmentList
	{
		private readonly IData _data;

		public int Count => ReadOnlyList.Count;
		public IReadOnlyList<IReadOnlyEquipmentSlot> ReadOnlyList => _data.Slots;

		public EquipmentList(IData data)
		{
			_data = data;
			Init(_data.Capacity);
		}

		public void Init(int capacity)
		{
			var slots = _data.Slots;
			for (int i = Count; i < capacity; ++i)
				slots.Add(new EquipmentSlot(i));
			for (int i = Count; i > capacity; --i)
				slots.RemoveAt(i - 1);
		}

		public void SetSlot(int slot, IItem item)
		{
			var slots = _data.Slots;
			if (slots.Count <= slot)
				return;
			if (item == null)
			{
				ClearSlot(slot);
				return;
			}
			if (GetEquippableComponent(item, out var component))
				return;

			var findIndex = slots.FindIndex( x => x != null && x.Item == item);
			if(findIndex != -1)
				DoSetSlot(findIndex, slots[slot].Item);
			DoSetSlot(slot, item);
			_data.OnSlotsChanged.Raise(this);
		}

		private bool GetEquippableComponent(IItem item, out EquippableComponent component)
		{
			component = ItemComponent.FindOn<EquippableComponent>(item);
			return component == null;
		}

		public void ClearSlot(int slot)
		{
			var slots = _data.Slots;
			slots[slot].Clear();
			_data.OnSlotsChanged.Raise(this);
		}

		private void DoSetSlot(int slot, IItem item)
		{
			var slots = _data.Slots;
			slots[slot].SetItem(item);
			_data.OnSlotsChanged.Raise(this);
		}

		public bool CheckSame(List<IItem> other)
		{
			var slots = _data.Slots;
			if (other.Count != slots.Count)
				return true;
			for(int i = 0; i < other.Count; ++i)
			{
				if (slots[i].Item == other[i])
					continue;
				return false;
			}
			return true;
		}

		public interface IData
		{
			int Capacity { get; }
			List<IEquipmentSlot> Slots { get; }
			TGameEvent<IReadOnlyEquipmentList> OnSlotsChanged { get; }
		}
	}
}
