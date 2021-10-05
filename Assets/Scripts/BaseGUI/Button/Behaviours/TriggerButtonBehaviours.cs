using System;
using UnityEngine;
using UnityEngine.UI;
using VEngine.SO.Variables;

namespace VEngine.GUI
{
    public class TriggerButtonBehaviours : MonoBehaviour, TriggerButton.IComponents, TriggerButton.IData
    {
		[SerializeField] private Image _activeImage;
		[SerializeField] private Image _deactiveImage;
        [SerializeField] private BoolVariableWithOnChangeEvent _variable;
        [SerializeField] private bool _pressedValue;
		[SerializeField] private Button _button;

		private TriggerButton _triggerButton;

		private TriggerButton TriggerButton 
		{
			get
			{
				CreateTriggerButton();
				return _triggerButton;
			}
		}

		public BoolVariableWithOnChangeEvent Variable => _variable;
		public bool PressedValue => _pressedValue;
		public Button Button => _button;
		public Image ActiveImage => _activeImage;
		public Image DeactiveImage => _deactiveImage;

		private void CreateTriggerButton()
		{
			if (_triggerButton != null)
				return;
			_triggerButton = new TriggerButton(this, this);
		}

		protected void Awake()
		{
			CreateTriggerButton();
		}

		public void OnVariableChanged(bool value) => TriggerButton.OnVariableChanged(value);
	}
}
