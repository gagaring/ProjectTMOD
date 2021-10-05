using UnityEngine;
using System;
using System.Collections.Generic;
using VEngine.SO.Variables;
using UnityEngine.UI;
using VEngine.Inventory;

namespace VEngine.Equipments.GUI
{
	public class EquipmentInHandGUIBehaviour : MonoBehaviour
	{
		[SerializeField] private Data _data; 
		[SerializeField] private Components _components;

		private EquipmentsGUI _equipmentsGUI = null;
		private EquipmentInHandGUI _equipmentInHandGUI = null;

		private EquipmentInHandGUI EquipmentInHandGUI
		{
			get
			{
				CreateActiveEquipmentGUI();
				return _equipmentInHandGUI;
			}
		}

		private EquipmentsGUI EquipmentsGUI
		{
			get
			{
				CreateEquipmentsGUI();
				return _equipmentsGUI;
			}
		}

		public void Awake()
		{
			CreateEquipmentsGUI();
			CreateActiveEquipmentGUI();
		}

		public void Start()
		{
			OnEquipmentsChanged(_data.Equipments);
		}

		private void CreateElements()
		{
			//Debug.Log($"EquipmentsCount: {_data.EquipmentsCount}");
			var maxCount = _data.EquipmentsCount;
			for (int i = _components.Elements.Count; i < maxCount; ++i)
			{
				var element = Instantiate(_components.Prefab, _components.Parent).Element;
				_components.AddElement(element);
				_components.AddAvatar(element.Components.Avatar);
			}
		}

		protected void CreateEquipmentsGUI()
		{
			if (_equipmentsGUI != null)
				return;
			CreateElements();
			_equipmentsGUI = new EquipmentsGUI(_data, _components);
		}

		private void CreateActiveEquipmentGUI()
		{
			if (_equipmentInHandGUI != null)
				return;
			CreateElements();
			_equipmentInHandGUI = new EquipmentInHandGUI(_data, _components);
		}

		public void OnEquipmentsChanged(IReadOnlyEquipmentList equipments) => EquipmentsGUI.OnEquipmentsChanged(equipments);
		public void OnActiveEquipmentChanged(IReadOnlyEquipmentSlot slot) => EquipmentInHandGUI.OnActiveHandSlotChanged(slot.Index);
		public void OnInventoryChanged(IInventoryData data) => EquipmentsGUI.OnInventoryChanged(data);

		[Serializable]
		private class Data : EquipmentsGUI.IData, EquipmentInHandGUI.IData
		{
			[SerializeField] private EquipmentsReference _equipments;
			[SerializeField] private FloatReference _activeSlotAlpha;
			[SerializeField] private FloatReference _deactiveSlotAlpha;
			[SerializeField] private ColorReference _availableColor;
			[SerializeField] private ColorReference _unavailableColor;

			public IReadOnlyEquipmentList Equipments => _equipments.Value;
			public int EquipmentsCount => Equipments.Count;

			public float ActiveAlpha => _activeSlotAlpha.Value;
			public float DeactiveAlpha => _deactiveSlotAlpha.Value;

			public Color AvailableColor => _availableColor.Value;
			public Color UnavailableColor => _unavailableColor.Value;
		}

		[Serializable]
		private class Components : EquipmentsGUI.IComponents, EquipmentInHandGUI.IComponents
		{
			[SerializeField] private Transform _parent;
			[SerializeField] private EquipmentGUIElementBehaviour _prefab;

			public Transform Parent => _parent;
			public EquipmentGUIElementBehaviour Prefab => _prefab;

			private List<EquipmentsGUIElement> _elements = new List<EquipmentsGUIElement>();
			public IReadOnlyList<EquipmentsGUIElement> Elements => _elements;
			public void AddElements(IEnumerable<EquipmentsGUIElement> elements) => _elements.AddRange(elements);
			public void AddElement(EquipmentsGUIElement element) => _elements.Add(element);

			private List<Image> _avatars = new List<Image>();
			public void AddAvatar(Image image) => _avatars.Add(image);
			public IReadOnlyList<Image> Avatars => _avatars;
		}
	}
}
