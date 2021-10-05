using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VEngine.Inventory.GUI;

namespace VEngine.Equipments.GUI
{
	public class EquipmentsGUIDropHandlerBehaviour : MonoBehaviour, IDropHandler
	{
		[SerializeField] private Components _components;
		private EquipmentGUIDropHandler _handler = null;

		public EquipmentsGUIElement Element => _components.Element;

		public EquipmentGUIDropHandler Handler
		{
			get
			{
				if (_handler == null)
					_handler = new EquipmentGUIDropHandler(_components);
				return _handler;
			}
		}

		public void OnDrop(PointerEventData eventData)
		{
			var itemGUIBehaviour = eventData.pointerDrag.GetComponent<IItemGUIBehaviour>();
			if (itemGUIBehaviour == null)
				return;
			Handler.OnDrop(itemGUIBehaviour.ItemGUI.Item);
		}

		[Serializable]
		private class Components : EquipmentGUIDropHandler.IComponents
		{
			[SerializeField] private EquipmentGUIElementBehaviour _equipmentGUIElement;
			[SerializeField] private Button _clearButton;

			public EquipmentsGUIElement Element => _equipmentGUIElement.Element;
			public Button Clear => _clearButton;
		}
	}
}
