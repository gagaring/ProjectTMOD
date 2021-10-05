using UnityEngine;

namespace VEngine.GUI
{
    public class WindowStackHandlerBehaviour : MonoBehaviour, WindowStackHandler.IData
	{
        [SerializeField] private WindowStack _windowStack;

		private IWindowStackHandler _handler = null;
		public IWindowStack Stack => _windowStack;

		private void Awake()
		{
			_windowStack.Clear();
			_handler = new WindowStackHandler(this);
		}

		public void OnWindowOpened(IWindow window, bool opened) => _handler.OnWindowOpened(window, opened);
		public void CloseTopWindow() => _handler.CloseTopWindow();
		public void CloseAllWindow() => _handler.CloseAllWindow();
	}
}
