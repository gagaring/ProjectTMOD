using VEngine.GUI;
using VEngine.Interaction.Command;

namespace VEngine.Interaction.GUI
{
	public interface IPasswordWindow : IWindow
	{
		void OnOkClicked();
		void OnCancelClicked();
		void OnClearClicked();
		void OnBackspacePressed();
		void OpenPanel(IPasswordLock password);
	}
}