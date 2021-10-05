using System.Collections.Generic;
using UnityEngine;
using VEngine.SO.Events;
using Sirenix.OdinInspector;
using System;
using VEngine.CCTV.Events;

namespace VEngine.CCTV
{
	public class CCTVControllerBehaviour : SerializedMonoBehaviour, CCTVController.IData, CCTVController.IComponents
	{
		[SerializeField] private CCTVOpenGameEvent _openGUIEvent;
		[Title("Lists")]
		[SerializeField] private CCTVSelectableList _cameraList;
		[SerializeField] private CCTVSelectableList _laserList;
		[SerializeField] private CCTVSelectableList _mirrorList;

		public IReadOnlyList<ICCTVSelectable> Cameras => _cameraList.Selectables;
		public IReadOnlyList<ICCTVSelectable> Lasers => _laserList.Selectables;
		public IReadOnlyList<ICCTVSelectable> Mirrors => _mirrorList.Selectables;
		public IGameEvent<IReadOnlyList<ICCTVSelectable>, IReadOnlyList<ICCTVSelectable>, IReadOnlyList<ICCTVSelectable>> OpenGUI => _openGUIEvent;

		public ICCTVController Controller { get; private set; }

		private void Awake() => Controller = new CCTVController(this, this);
		public void Open(Action onFinished) => Controller.Open(onFinished);
		public void OnSelectableChanged(ICCTVSelectable selectable) => Controller.OnSelectableChanged(selectable);
		public void OnCameraSelected(ICCTVSelectable camera) => Controller.OnCameraSelected(camera);
		public bool ContainRotateable(ICCTVSelectable selectable) => _laserList.Contain(selectable) || _mirrorList.Contain(selectable);
		public bool ContainCamera(ICCTVSelectable selectable) => _cameraList.Contain(selectable);
		public void Close() => Controller.Close();

		[Button("Set lists dirty")]
		public void SetDirty()
		{
			_cameraList.SetDirty();
			_laserList.SetDirty();
			_mirrorList.SetDirty();
		}
	}
}
