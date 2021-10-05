namespace VEngine.GUI
{
	public interface IWindowStackHandler
	{
		void OnWindowOpened(IWindow window, bool opened);
		bool CloseTopWindow();
		bool CloseAllWindow();
	}
}