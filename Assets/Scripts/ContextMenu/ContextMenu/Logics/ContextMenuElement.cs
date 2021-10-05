using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VEngine.GUI.Context
{
	public class ContextMenuElement : IContextMenuElement
	{
		private IComponents _components;

		private int _index;
		private Action<int> _onPressed;

		private string Text { set { _components.Text.text = value; } }
		private void Show(bool show) => _components.Main.gameObject.SetActive(show);

		public ContextMenuElement(IComponents components)
		{
			_components = components;
		}

		public void Show(IContextMenuElementData data, int index, Action<int> onPressed)
		{
			Show(true);
			Text = data.Text;
			_index = index;
			_onPressed = onPressed;
			Interactable = data.Enabled;
		}

		public void Hide()
		{
			Show(false);
		}

		public bool OnPressed()
		{
			if (!Interactable)
				return false;
			_onPressed(_index);
			return true;
		}

		private bool Interactable 
		{
			get => _components.Button.interactable;
			set
			{
				_components.Button.interactable = value;
			}
		}

		public interface IComponents
		{
			TMP_Text Text { get; }
			GameObject Main { get; }
			Button Button { get; } 
		}
	}
}
