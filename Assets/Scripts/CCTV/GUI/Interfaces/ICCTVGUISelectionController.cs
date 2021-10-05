using System.Collections.Generic;

namespace VEngine.CCTV.GUI
{
	public interface ICCTVGUISelectionController
	{
		void Open(IReadOnlyList<ICCTVSelectable> selectable, bool firstSelected);
		void Close();
		void OnSelectionChanged(ICCTVSelectable selectable);
	}
}
