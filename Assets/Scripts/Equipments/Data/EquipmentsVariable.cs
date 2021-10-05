using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VEngine.SO.Events;
using VEngine.SO.Variables;

namespace VEngine.Equipments
{
	[CreateAssetMenu(menuName = "SO/Equipments/EquipmentsVariable", fileName = "EquipmentsVariable")]
	public class EquipmentsVariable : SerializedScriptableObject, EquipmentList.IData
	{
		[SerializeField] private IntReference _capacity;
		[SerializeField] private EquipmentsGameEvent _onSlotsChanged;
		[OnValueChanged(nameof(FixIndecies))]
		[SerializeField] private List<EquipmentSlot> _equipmentList;

		public int Capacity => _capacity.Value;
		public List<IEquipmentSlot> Slots => _equipmentList.ToList<IEquipmentSlot>();
		public TGameEvent<IReadOnlyEquipmentList> OnSlotsChanged => _onSlotsChanged;

		private IEquipmentList _equipments = null;

		public IEquipmentList EquipmentList
		{
			get
			{
				if (_equipments == null)
					CreateHandSlots();
				return _equipments;
			}
		}

		public IReadOnlyEquipmentList ReadOnlyEquipmentList
		{
			get
			{
				if (_equipments == null)
					CreateHandSlots();
				return _equipments;
			}
		}

		private void CreateHandSlots()
		{
			_equipments = new EquipmentList(this);
			FixIndecies();
		}

		private void FixIndecies()
		{
			var slots = _equipmentList;
			for (int i = 0; i < _equipmentList.Count; ++i)
				slots[i].Index = i;
			if(Application.isPlaying)
				CallOnSlotsChanged();
		}

		[EnableIf("@UnityEngine.Application.isPlaying")][Button("OnSlotsChanged")]
		private void CallOnSlotsChanged() => _onSlotsChanged.Raise(_equipments);
	}

	[Serializable]
	public class EquipmentsReference
	{
		[SerializeField] private EquipmentsVariable _variable;

		public IEquipmentList Value => _variable.EquipmentList;
	}
}
