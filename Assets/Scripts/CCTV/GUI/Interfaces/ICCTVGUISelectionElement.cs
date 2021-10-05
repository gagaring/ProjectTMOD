using System;

namespace VEngine.CCTV.GUI
{
	public interface ICCTVGUISelectionElement
	{
		string Name { set; }
		bool Selected { set; }
		ICCTVSelectable Selectable { get; set; }

		Action<ICCTVGUISelectionElement> OnSelected { get; set; }

		void Show(bool show);
		void Press();
	}
}
