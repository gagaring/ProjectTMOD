using System;
using System.Collections.Generic;
using UnityEngine;

namespace VEngine.Inventory.GUI
{
	[CreateAssetMenu(menuName = "SO/Inventory/GUI/SlotsGUIBehaviourContainer")]
	public class SlotsGUIBehaviourContainer : ScriptableObject
	{
		[SerializeField] private List<SlotGUIBehaviour> _slotGUIBehaviours = new List<SlotGUIBehaviour>();

		private List<ISlotGUI> _slotGUIs = null;

		private bool _isDirty;

		public IReadOnlyList<SlotGUIBehaviour> Behaviours => _slotGUIBehaviours.AsReadOnly();
		public IReadOnlyList<ISlotGUI> SlotGUIs 
		{ 
			get
			{
				if (_slotGUIs == null || _isDirty)
					CreateSlotGUIs();
				return _slotGUIs.AsReadOnly();
			}
		
		}

		private void CreateSlotGUIs()
		{
			_slotGUIs = new List<ISlotGUI>();
			for(int i = 0; i < _slotGUIBehaviours.Count; ++i)
				_slotGUIs.Add(_slotGUIBehaviours[i].SlotGUI);
			_isDirty = false;
		}

		public void Add(SlotGUIBehaviour behaviour)
		{
			_slotGUIBehaviours.Add(behaviour);
			_isDirty = true;
		}

		public void Remove(SlotGUIBehaviour behaviour)
		{
			_isDirty = _slotGUIBehaviours.Remove(behaviour);
		}

		public void Clear()
		{
			if(_slotGUIBehaviours != null)
				_slotGUIBehaviours.Clear();
			if (_slotGUIs != null)
				_slotGUIs.Clear();
		}
	}

	[Serializable]
	public class SlotsGUIBehaviourContainerReference
	{
		[SerializeField] private SlotsGUIBehaviourContainer _variable;

		public IReadOnlyList<SlotGUIBehaviour> Behaviours { get => _variable.Behaviours; }
	}
}
