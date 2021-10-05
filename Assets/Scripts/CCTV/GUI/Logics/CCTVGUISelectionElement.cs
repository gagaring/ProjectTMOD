using System;
using UnityEngine;
using UnityEngine.UI;

namespace VEngine.CCTV.GUI
{
	public class CCTVGUISelectionElement : ICCTVGUISelectionElement
	{
		protected readonly IData _data;
		protected readonly IComponents _components;

		public Action<ICCTVGUISelectionElement> OnSelected { get; set; }
		public string Name { set => _components.Name = value; }
		public ICCTVSelectable Selectable { get; set; }

		public bool Selected
		{
			set
			{
				_components.SelectedMarker.SetActive(value);
			}
		}

		public CCTVGUISelectionElement(IData data, IComponents components)
		{
			_data = data;
			_components = components;
			_components.Button.onClick.AddListener(OnClicked);
		}

		private void OnClicked()
		{
			Selected = true;
			OnSelected?.Invoke(this);
		}

		public void Show(bool show)
		{
			_components.Main.SetActive(show);
		}

		public void Press()
		{
			_components.Button.onClick?.Invoke();
		}

		public interface IData
		{

		}

		public interface IComponents
		{
			GameObject Main { get; }
			Button Button { get; }
			string Name { set; }
			GameObject SelectedMarker { get; }
		}
	}
}
