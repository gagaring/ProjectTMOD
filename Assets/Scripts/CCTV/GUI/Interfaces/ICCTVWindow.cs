using System.Collections.Generic;
using VEngine.GUI;

namespace VEngine.CCTV.GUI
{
	public interface ICCTVWindow : IWindow
	{
		void Open(IReadOnlyList<ICCTVSelectable> cameras, IReadOnlyList<ICCTVSelectable> lasers, IReadOnlyList<ICCTVSelectable> mirrors);
		void OnSelectableChanged(ICCTVSelectable selectable);
		void OnCameraChanged(ICCTVSelectable selectable);
	}
}