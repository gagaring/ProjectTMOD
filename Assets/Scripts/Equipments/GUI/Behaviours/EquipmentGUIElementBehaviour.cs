using System;
using UnityEngine;
using UnityEngine.UI;

namespace VEngine.Equipments.GUI
{
	public class EquipmentGUIElementBehaviour : MonoBehaviour
	{
		[SerializeField] private Data _data;
		[SerializeField] private Components _components;

		private EquipmentsGUIElement _element = null;

		public Image Avatar => _components.Avatar;

		public  EquipmentsGUIElement Element
		{
			get
			{
				CreateIfNeed();
				return _element;
			}
		}

		private void CreateIfNeed()
		{
			if (_element != null)
				return;
			_element = new EquipmentsGUIElement(_data, _components);
		}

		[Serializable]
		public class Data : EquipmentsGUIElement.IData
		{

		}

		[Serializable]
		public class Components : EquipmentsGUIElement.IComponents
		{
			[SerializeField] private Image _avatar;
			[SerializeField] private Button _removeButton;

			public Image Avatar => _avatar;
			public GameObject Remove => _removeButton == null ? null : _removeButton.gameObject;
		}
	}
}
