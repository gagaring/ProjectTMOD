using System;
using System.Collections.Generic;
using UnityEngine;
using VEngine.CCTV.Events;
using VEngine.SO.Events;
using VEngine.SO.Variables;

namespace VEngine.CCTV.GUI
{
	public class CCTVGUISelectableControllerBehaviour : MonoBehaviour
	{
		[SerializeField] private Data _data;
		[SerializeField] private Components _components;

		private CCTVGUISelectionController _controller;

		public CCTVGUISelectionController Controller
		{
			get
			{
				Init();
				return _controller;
			}
		}

		private void Init()
		{
			if (_controller != null)
				return;
			CreateElements();
			_controller = new CCTVGUISelectionController(_data, _components);
		}

		private void CreateElements()
		{
			_components.CreateElements(_data.NameBase, _data.MaxCount);
		}

		[Serializable]
		public class Data : CCTVGUISelectionController.IData
		{
			[SerializeField] private StringReference _nameBase;
			[SerializeField] private IntReference _maxRotateableCount;

			public string NameBase => _nameBase.Value;
			public int MaxCount => _maxRotateableCount.Value;
		}

		[Serializable]
		public class Components : CCTVGUISelectionController.IComponents
		{
			[SerializeField] private GameObject _main;
			[SerializeField] private CCTVGUISelectionElementBehaviour _selectablePrefab;
			[SerializeField] private Transform _selectableParent;

			[Header("Events")]
			[SerializeField] private CCTVSelectableGameEvent _onSelectableSelected;

			private List<ICCTVGUISelectionElement> _selectables = new List<ICCTVGUISelectionElement>();

			public IReadOnlyList<ICCTVGUISelectionElement> SelectionElements => _selectables;
			public IGameEvent<ICCTVSelectable> SelectableSelectedEvent => _onSelectableSelected;

			public GameObject Main => _main;

			public void CreateElements(string nameBase, int count)
			{
				for(int i = 0; i < count; ++i)
				{
					var element = Instantiate(_selectablePrefab, _selectableParent).Element;
					element.Name = $"{nameBase} {i}";
					_selectables.Add(element);
				}
			}
		}
	}
}
