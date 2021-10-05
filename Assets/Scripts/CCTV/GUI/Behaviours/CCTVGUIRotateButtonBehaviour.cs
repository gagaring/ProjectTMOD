using System;
using UnityEngine;
using UnityEngine.UI;

namespace VEngine.CCTV.GUI
{
	public class CCTVGUIRotateButtonBehaviour : MonoBehaviour, CCTVGUIRotateableControlPanel.IRotateButton
	{
		[SerializeField] private Button _button;
		[SerializeField] private Image _image;

		public Button Button => _button;
		public Image Image => _image;
	}
}
