using VEngine.GUI;
using VEngine.SO.Events;

namespace VEngine.PauseMenu
{
	public class PausedMenuWindow : Window, IPausedMenuWindow
	{
		private readonly IPausedMenuData _data;

		public PausedMenuWindow(IPausedMenuData data) : base(data) => _data = data;

		public void OnResumeClicked()
		{
			Close();
			_data.PauseGame.Raise(false);
		}

		protected override void OnWindowOpened(bool opened)
		{
			base.OnWindowOpened(opened);
			_data.IsOpened = _isOpened;
		}

		public interface IPausedMenuData : IWindowData
		{
			IGameEvent<bool> PauseGame { get; }
			bool IsOpened { set; }
		}
	}
}