using System.Collections.Generic;
using VEngine.GUI;
using VEngine.Log;
using VEngine.SO.Events;

namespace VEngine.CCTV.GUI
{
	public class CCTVWindow : Window, ICCTVWindow
	{
		private readonly ICCTVData _data;

		public CCTVWindow(ICCTVData data) : base(data)
		{
			VLog.Log(VLog.eFlag.Interaction, VLog.eLevel.Normal, $"CCTVGUIController created");
			_data = data;
			Close();
		}

		public void Open(IReadOnlyList<ICCTVSelectable> cameras, IReadOnlyList<ICCTVSelectable> lasers, IReadOnlyList<ICCTVSelectable> mirrors)
		{
			base.Open();
			OpenSelectionControllers(cameras, lasers, mirrors);
		}

		private void OpenSelectionControllers(IReadOnlyList<ICCTVSelectable> cameras, IReadOnlyList<ICCTVSelectable> lasers, IReadOnlyList<ICCTVSelectable> mirrors)
		{
			OpenSelectionController(_data.CameraController, cameras, true);
			bool firstSelected = OpenSelectionController(_data.LaserController, lasers, true);
			OpenSelectionController(_data.MirrorController, mirrors, !firstSelected);
		}

		public override void Close()
		{
			CloseSelectionControllers();
			_data.OnClosed.Raise();
			base.Close();
		}

		private void CloseSelectionControllers()
		{
			_data.CameraController.Close();
			_data.LaserController.Close();
			_data.MirrorController.Close();
		}

		private bool OpenSelectionController(ICCTVGUISelectionController guiController, IReadOnlyList<ICCTVSelectable> selectables, bool firstSelected)
		{
			if(selectables.Count == 0)
			{
				Close();
				return false;
			}
			guiController.Open(selectables, firstSelected);
			return true;
		}

		public void OnSelectableChanged(ICCTVSelectable selectable)
		{
			_data.LaserController.OnSelectionChanged(selectable);
			_data.MirrorController.OnSelectionChanged(selectable);
		}

		public void OnCameraChanged(ICCTVSelectable selectable)
		{
			_data.CameraController.OnSelectionChanged(selectable);
		}

		public interface ICCTVData : IWindowData
		{
			IGameEvent OnClosed { get; }
			ICCTVGUISelectionController CameraController { get; }
			ICCTVGUISelectionController LaserController { get; }
			ICCTVGUISelectionController MirrorController { get; }
		}
	}
}
