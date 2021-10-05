using System.Collections.Generic;
using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.CCTV.GUI
{
	public class CCTVGUISelectionController : ICCTVGUISelectionController
	{
		private readonly IData _data;
		private readonly IComponents _components;

		private ICCTVGUISelectionElement _currentElement;

		public CCTVGUISelectionController(IData data, IComponents components)
		{
			_data = data;
			_components = components;
			RegisterOnElements();
		}

		private void RegisterOnElements()
		{
			foreach (var curr in _components.SelectionElements)
				curr.OnSelected += OnSelectableSelected;
		}

		private void OnSelectableSelected(ICCTVGUISelectionElement selectable)
		{
			if(selectable != null)
				OnSelectionChanged(selectable.Selectable);
			_currentElement = selectable;
			_components.SelectableSelectedEvent.Raise(selectable.Selectable);
		}

		public void OnSelectionChanged(ICCTVSelectable selectable)
		{
			if (_currentElement == null || _currentElement.Selectable == selectable)
				return;
			_currentElement.Selected = false;
			_currentElement = null;
		}

		public void Open(IReadOnlyList<ICCTVSelectable> selectables, bool firstSelected)
		{
			OpenMain(true);
			for(int i = 0; i < selectables.Count; ++i)
			{
				var element = _components.SelectionElements[i];
				element.Selectable = selectables[i];
				element.Show(true);
			}
			for(int i = selectables.Count; i < _components.SelectionElements.Count; ++i)
				_components.SelectionElements[i].Show(false);

			if (firstSelected)
				_components.SelectionElements[0].Press();
		}

		public void Close()
		{
			OpenMain(false);
		}

		private void OpenMain(bool open)
		{
			_components.Main.SetActive(open);
		}

		public interface IData
		{

		}

		public interface IComponents
		{
			GameObject Main { get; }
			IReadOnlyList<ICCTVGUISelectionElement> SelectionElements { get; }
			IGameEvent<ICCTVSelectable> SelectableSelectedEvent { get; }
		}
	}
}
