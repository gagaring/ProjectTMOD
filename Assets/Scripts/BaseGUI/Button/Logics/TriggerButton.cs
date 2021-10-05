using System;
using UnityEngine;
using UnityEngine.UI;
using VEngine.SO.Variables;

namespace VEngine.GUI
{
	public class TriggerButton
	{
		private readonly IData _data;
		private readonly IComponents _components;

		public TriggerButton(IData data, IComponents components)
		{
			_data = data;
			_components = components;

			_components.Button.onClick.AddListener(OnClicked);
		}

		~TriggerButton()
		{
			_components.Button.onClick.RemoveListener(OnClicked);
		}

		public void OnVariableChanged(bool value)
		{
			_data.Variable.Value = value;
			if (_components.ActiveImage)
				_components.ActiveImage.enabled = value;
			if (_components.DeactiveImage)
				_components.DeactiveImage.enabled = !value;
		}

		public void OnClicked()
		{
			OnVariableChanged(_data.PressedValue);
		}

		public interface IData
		{
			BoolVariableWithOnChangeEvent Variable { get; }
			bool PressedValue { get; }
		}

		public interface IComponents
		{
			Button Button { get; }
			Image ActiveImage { get; }
			Image DeactiveImage { get; }
		}
	}
}
