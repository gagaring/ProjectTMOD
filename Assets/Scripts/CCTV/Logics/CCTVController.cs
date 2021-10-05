using System;
using System.Collections.Generic;
using VEngine.SO.Events;

namespace VEngine.CCTV
{
	public class CCTVController : ICCTVController
	{
		private readonly IData _data;
		private readonly IComponents _components;

		private ICCTVSelectable _currentSelectable;
		private ICCTVSelectable _currentCamera;
		private Action _onFinished;

		private ICCTVSelectable CurrentSelectable
		{
			set
			{
				if (_currentSelectable != null)
					_currentSelectable.Selected = false;
				_currentSelectable = value;
				if (value != null)
					value.Selected = true;
			}
		}

		private ICCTVSelectable CurrentCamera
		{
			set
			{
				if (_currentCamera != null)
					_currentCamera.Selected = false;
				_currentCamera = value;
				if (value != null)
					value.Selected = true;
			}
		}

		public CCTVController(IData data, IComponents components)
		{
			_data = data;
			_components = components;
			DeselectAll();
		}

		private void DeselectAll()
		{
			DeselectAll(_components.Cameras);
			DeselectAll(_components.Lasers);
			DeselectAll(_components.Mirrors);
			CurrentCamera = null;
			CurrentSelectable = null;
		}

		private void DeselectAll(IReadOnlyList<ICCTVSelectable> selectable)
		{
			foreach (var curr in selectable)
				curr.Selected = false;
		}

		public void Open(Action onFinished)
		{
			_onFinished = onFinished;
			if (_data.OpenGUI.RegisteredCount == 0)
			{
				Close();
				return;
			}
			_data.OpenGUI.Raise(_components.Cameras, _components.Lasers, _components.Mirrors);
		}

		public void Close()
		{
			DeselectAll();
			var onFinished = _onFinished;
			_onFinished = null;
			onFinished?.Invoke();
		}

		public void OnCameraSelected(ICCTVSelectable camera)
		{
			if (camera != null && !_components.ContainCamera(camera))
				return;
			CurrentCamera = camera;
		}

		public void OnSelectableChanged(ICCTVSelectable selectable)
		{
			if (selectable != null && !_components.ContainRotateable(selectable))
				return;
			CurrentSelectable = selectable;
		}

		public interface IData
		{
			IGameEvent<IReadOnlyList<ICCTVSelectable>, IReadOnlyList<ICCTVSelectable>, IReadOnlyList<ICCTVSelectable>> OpenGUI { get; }
		}

		public interface IComponents
		{
			IReadOnlyList<ICCTVSelectable> Lasers { get; }
			IReadOnlyList<ICCTVSelectable> Mirrors { get; }
			IReadOnlyList<ICCTVSelectable> Cameras { get; }

			bool ContainRotateable(ICCTVSelectable rotateable);
			bool ContainCamera(ICCTVSelectable camera);
		}
	}
}
