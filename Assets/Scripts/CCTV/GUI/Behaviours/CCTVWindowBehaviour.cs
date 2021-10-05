using System;
using System.Collections.Generic;
using UnityEngine;
using VEngine.GUI;
using VEngine.SO.Events;

namespace VEngine.CCTV.GUI
{
	public class CCTVWindowBehaviour : WindowBehaviour, CCTVWindow.ICCTVData
	{
		[SerializeField] private GameEvent _onClosed;
		[SerializeField] private CCTVGUISelectableControllerBehaviour _cameraController;
		[SerializeField] private CCTVGUISelectableControllerBehaviour _laserController;
		[SerializeField] private CCTVGUISelectableControllerBehaviour _mirrorController;

		public IGameEvent OnClosed => _onClosed;
		public ICCTVGUISelectionController CameraController => _cameraController.Controller;
		public ICCTVGUISelectionController LaserController => _laserController.Controller;
		public ICCTVGUISelectionController MirrorController => _mirrorController.Controller;

		private ICCTVWindow CCTVWindow => (ICCTVWindow)Window;

		protected override IWindow CreateWindow() => new CCTVWindow(this);

		public void Open(IReadOnlyList<ICCTVSelectable> cameras, IReadOnlyList<ICCTVSelectable> lasers, IReadOnlyList<ICCTVSelectable> mirrors)
			=> CCTVWindow.Open(cameras, lasers, mirrors);
		public void OnSelectableChanged(ICCTVSelectable selectable) => CCTVWindow.OnSelectableChanged(selectable);
		public void OnCameraChanged(ICCTVSelectable camera) => CCTVWindow.OnCameraChanged(camera);
	}
}
