using System;
using System.Collections.Generic;
using UnityEngine;

namespace VEngine.Inventory.GUI
{
	[CreateAssetMenu(menuName = "SO/Inventory/GUI/SlotsGUIContainer")]
	public class SlotsGUIContainer : ScriptableObject
	{
		private List<ISlotGUI> _slotGUIs = new List<ISlotGUI>();


		private bool _isDirty;

		public IReadOnlyList<ISlotGUI> SlotGUIs => _slotGUIs.AsReadOnly();

		public void Add(ISlotGUI slotGUI)
		{
			_slotGUIs.Add(slotGUI);
			_isDirty = true;
		}

		public void Remove(ISlotGUI slotGUI)
		{
			_isDirty = _slotGUIs.Remove(slotGUI);
		}

		public void Clear()
		{
			if(_slotGUIs != null)
				_slotGUIs.Clear();
			if (_slotGUIs != null)
				_slotGUIs.Clear();
		}
	}


	public interface ISlotsGUIContainerReference
	{
		IReadOnlyList<ISlotGUI> SlotGUIs { get; }
	}

	[Serializable]
	public class SlotsGUIContainerReference : ISlotsGUIContainerReference
	{
		[SerializeField] private bool _useBehaviours;
		[SerializeField] private SlotsGUIBehaviourContainer _behaviours;
		[SerializeField] private SlotsGUIContainer _variable;

		public IReadOnlyList<ISlotGUI> SlotGUIs { get => _useBehaviours ? _behaviours.SlotGUIs : _variable.SlotGUIs; }
	}
}
