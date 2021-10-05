using System;

namespace VEngine.CCTV
{
	public interface ICCTVController
	{
		void Open(Action onFinished);
		void OnCameraSelected(ICCTVSelectable camera);
		void OnSelectableChanged(ICCTVSelectable selectable);
		void Close();
	}
}