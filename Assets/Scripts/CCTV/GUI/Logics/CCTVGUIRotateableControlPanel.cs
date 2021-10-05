using System;
using UnityEngine;
using UnityEngine.UI;

namespace VEngine.CCTV.GUI
{
	public class CCTVGUIRotateableControlPanel : ICCTVGUIControlPanel<ICCTVRotateable>
	{
		protected readonly IData _baseData;
		protected readonly IComponents _baseComponents;

		private ICCTVRotateable _currentRotateable;

		public CCTVGUIRotateableControlPanel(IData data, IComponents components)
		{
			_baseData = data;
			_baseComponents = components;
		}

		public void Open(ICCTVRotateable rotateable)
		{
			_currentRotateable = rotateable;
			RefreshButtons();
			Open(true);
		}

		public void Close()
		{
			Open(false);
		}

		private void Open(bool open)
		{
			_baseComponents.Main.SetActive(open);
		}

		public void OnRotate(bool positivDir)
		{
			_currentRotateable.Rotate(positivDir);
			RefreshButtons();
		}

		public void Refresh()
		{
			RefreshButtons();
		}

		private void RefreshButtons()
		{
			RefreshButtons(_baseComponents.RotatePositive, _currentRotateable.CanRotatePositive);
			RefreshButtons(_baseComponents.RotateNegavite, _currentRotateable.CanRotateNegative);
		}

		private void RefreshButtons(IRotateButton button, bool interactable)
		{
			button.Button.interactable = interactable;
			button.Image.color = interactable ? _baseData.InteractableImageColor : _baseData.DisableImageColor;
		}

		public interface IData
		{
			Color InteractableImageColor { get; }
			Color DisableImageColor { get; }
		}

		public interface IComponents
		{
			GameObject Main { get; }
			IRotateButton RotatePositive { get; }
			IRotateButton RotateNegavite { get; }
		}

		public interface IRotateButton
		{
			Button Button { get; }
			Image Image { get; }
		}
	}
}
