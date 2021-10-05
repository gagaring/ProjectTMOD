using System;

namespace VEngine.GUI.Context
{
	public interface IContextMenuElement
	{
		void Show(IContextMenuElementData rowData, int index, Action<int> onPressed);
		void Hide();
		bool OnPressed();
	}
}
