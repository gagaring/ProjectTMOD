using System;
using UnityEngine;
using UnityEngine.UI;

namespace VEngine.CCTV.GUI
{
	public class CCTVGUIRotateableControlPanelBehaviour : MonoBehaviour
	{
		[SerializeField] private Data _data;
		[SerializeField] private Components _components;

		private CCTVGUIRotateableControlPanel _panel;

		private void Awake()
		{
			_panel = new CCTVGUIRotateableControlPanel(_data, _components);
		}

		public void Open(ICCTVRotateable rotateable)
		{
			_panel.Open(rotateable);
		}

		public void Rotate(bool positive) => _panel.OnRotate(positive);

		[Serializable]
		public class Data : CCTVGUIRotateableControlPanel.IData
		{
			[SerializeField] private Color _enabledColor;
			[SerializeField] private Color _disabledColor;

			public Color InteractableImageColor => _enabledColor;
			public Color DisableImageColor => _disabledColor;
		}

		[Serializable]
		public class Components : CCTVGUIRotateableControlPanel.IComponents
		{
			[SerializeField] private GameObject _main;
			[SerializeField] private CCTVGUIRotateButtonBehaviour _rotatePositive;
			[SerializeField] private CCTVGUIRotateButtonBehaviour _rotateNegative;

			public GameObject Main => _main;
			public CCTVGUIRotateableControlPanel.IRotateButton RotatePositive => _rotatePositive;
			public CCTVGUIRotateableControlPanel.IRotateButton RotateNegavite => _rotateNegative;
		}
	}
}
