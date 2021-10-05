using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VEngine.CCTV.GUI
{
	public class CCTVGUISelectionElementBehaviour : MonoBehaviour
	{
		[SerializeField] private Data _data;
		[SerializeField] private Components _components;

		private CCTVGUISelectionElement _element;

		public ICCTVGUISelectionElement Element
		{
			get
			{
				if (_element == null)
					_element = new CCTVGUISelectionElement(_data, _components);
				return _element;
			}
		}

		[Serializable]
		public class Data : CCTVGUISelectionElement.IData
		{

		}

		[Serializable]
		public class Components : CCTVGUISelectionElement.IComponents
		{
			[SerializeField] private GameObject _main;
			[SerializeField] private Button _button;
			[SerializeField] private TextMeshProUGUI _text;
			[SerializeField] private GameObject _selectedMarker;

			public GameObject Main => _main;
			public Button Button => _button;
			public string Name { set => _text.text = value; }
			public GameObject SelectedMarker => _selectedMarker;
		}
	}
}
