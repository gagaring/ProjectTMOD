using System;
using System.Collections.Generic;
using UnityEngine;
using VEngine.Items;
using VEngine.SO.Variables;

namespace VEngine.Equipments.GUI
{
	public class EquipmentSetterGUIControllerBehaviour : MonoBehaviour
	{
		[SerializeField] private Data _data;
		[SerializeField] private Components _components;

		public EquipmentsSetterGUIController Controller { get; private set; }
		public EquipmentsGUI EquipmentsGUI { get; private set; }

		public void Awake()
		{
			CreateHandler(_data.Equipments.Count);
			Controller = new EquipmentsSetterGUIController(_data, _components);
			EquipmentsGUI = new EquipmentsGUI(_data, _components);
			OnEquipmentsChanged(_data.Equipments);
		}

		private void CreateHandler(int count)
		{
			for (int i = 0; i < count; ++i)
			{
				var handler = CreateHandlerBehaviour();
				_components.AddHandler(handler.Handler);
				_components.AddElement(handler.Element);
			} 
		}

		private EquipmentsGUIDropHandlerBehaviour CreateHandlerBehaviour() => Instantiate(_components.Prefab, _components.Parent);

		public void OnEquipmentsChanged(IReadOnlyEquipmentList equipments) => EquipmentsGUI?.OnEquipmentsChanged(equipments);

		[Serializable]
		public class Data : EquipmentsSetterGUIController.IData, EquipmentsGUI.IData
		{
			[SerializeField] private EquipmentsReference _equipments;
			[SerializeField] private ColorReference _availableColor;
			[SerializeField] private ColorReference _unavailableColor;

			public IEquipmentList Equipments => _equipments.Value;
			public int EquipmentsCount => Equipments.Count;

			public Color AvailableColor => _availableColor.Value;
			public Color UnavailableColor => _unavailableColor.Value;
		}

		[Serializable]
		public class Components : EquipmentsSetterGUIController.IComponents, EquipmentsGUI.IComponents
		{
			[SerializeField] private Transform _parent;
			[SerializeField] private EquipmentsGUIDropHandlerBehaviour _prefab;

			public EquipmentsGUIDropHandlerBehaviour Prefab => _prefab;
			public Transform Parent => _parent;

			private List<EquipmentGUIDropHandler> _handlers = new List<EquipmentGUIDropHandler>();
			private List<EquipmentsGUIElement> _elements = new List<EquipmentsGUIElement>();

			public IReadOnlyList<EquipmentGUIDropHandler> Handlers => _handlers;
			public IReadOnlyList<EquipmentsGUIElement> Elements => _elements;

			public void AddHandler(EquipmentGUIDropHandler handler) => _handlers.Add(handler);
			public void AddElement(EquipmentsGUIElement element) => _elements.Add(element);
		}
	}
}
